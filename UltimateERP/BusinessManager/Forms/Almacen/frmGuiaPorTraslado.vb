Public Class frmGuiaPorTraslado
    Private MyAccion As String = "NUEVO"

    Private MyOperacion As entOperacionAlmacen
    Private MyOperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
    Private MyOperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

    Private MyCuentaComercial As entCuentaComercial
    Private MyProducto As entProducto
    Private MyTipoOperacion As String = "S"
    Private MyStock As Decimal
    Private MyStockAlmacen As dsStockAlmacen.STOCK_X_ALMACENDataTable

    Private MyDetallesImprimir As dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable

    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable

    Private MyGuia As entGuia
    Private MyGuias As dsGuiasRemitente.GUIASDataTable
    Private MyGuiaDetalles As dsGuiasRemitente.GUIAS_DETDataTable
    Private MyGuiaDetalleSeries As dsGuiasRemitente.GUIAS_DET_SERIESDataTable

    Private FechaUltimoComprobante As Date
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String

    Private MyDireccionEnvio As dsCuentasComerciales.DIRECCION_ENVIODataTable

    Private AfectaStock As String

    Private Sub frmOperacionesAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOperacionesAlmacen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_GUIAS")
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)
        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnGrabar_Visible = False

        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ckbIndicaAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaAnulado.CheckedChanged
        If txtOperacion.Text.Trim.Length <> 0 Then
            If MyOperacion.estado = "A" Then
                If ckbIndicaAnulado.Checked = True Then
                    UC_ToolBar.btnAceptar_Visible = True
                Else
                    UC_ToolBar.btnAceptar_Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub cmbDireccionEnvio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDireccionEnvio.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            txtPuntoLlegada.Text = MyDireccionEnvio(sender.SelectedIndex).DIRECCION
            'txtPuntoLlegada.Text = sender.Items(sender.SelectedIndex)(4)
        Else
            txtPuntoLlegada.Text = Nothing
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProducto = New entProducto
            MyCodigo = sender.Text.Trim

            Call LimpiarLinea()

            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto, "NO", "A")
                MyForm.ShowDialog()
                If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyProducto.empresa, MyProducto.producto)
            Else
                If IsNumeric(MyCodigo) Then
                    MyCodigo = "P" & Strings.Right("0000000" & CStr(Val(MyCodigo.Trim)), 7)
                End If
                MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
            End If

            If Not MyProducto.producto Is Nothing Then
                Call BuscarStock(MyProducto.producto)
                If MyStockAlmacen.Rows.Count = 0 Then
                    Resp = MsgBox("No existe stock para este producto.", MsgBoxStyle.Information, "OPERACION DENEGADA")
                Else
                    txtProducto.Text = MyProducto.producto
                    txtProductoDescripcion.Text = MyProducto.descripcion_ampliada
                    txtIndicaSerie.Text = MyProducto.indica_serie
                    'Si ya ha sido registrado mostrar cantidad registrada
                    For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                        If MyOperacionDetalles(NEle).PRODUCTO = MyProducto.producto Then
                            txtCantidad.Text = EvalDato(MyOperacionDetalles(NEle).CANTIDAD, txtCantidad.Tag)
                        End If
                    Next
                    txtCantidad.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub gvGuiaLineas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvGuiaLineas.CellClick
        If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
            Dim MyIndex As Integer
            Dim CodigoProducto As String
            If Not sender.CurrentRow Is Nothing Then
                MyIndex = sender.CurrentRow.Index
                CodigoProducto = MyOperacionDetalles(MyIndex).PRODUCTO
                MyOperacionDetalles.Rows(MyIndex).Delete()
                If MyOperacionDetalleSeries.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyOperacionDetalleSeries.Rows.Count - 1
                        If MyOperacionDetalleSeries(NEle).PRODUCTO = CodigoProducto Then
                            MyOperacionDetalleSeries.Rows(NEle).Delete()
                            Exit For
                        End If
                    Next
                End If
                txtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtOperacionFecha" Then
                    cmbAlmacen.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumero As String = sender.text

        Dim CantidadStock As Decimal = CDec(txtCantidadStock.Text)
        Dim Cantidad As Decimal = 0

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            sender.Text = EvalDato(sender.Text, sender.Tag)
            Cantidad = CDec(sender.Text)

            If Cantidad > CantidadStock Then
                Resp = MsgBox("La cantidad registrada no puede ser mayor que el STOCK ACTUAL.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CANTIDAD NO VALIDA")
                sender.Text = EvalDato(0, sender.Tag)
            Else
                If txtIndicaSerie.Text = "SI" And Cantidad <> 0 Then
                    Dim MyForm As New frmOperacionDetalleSeries(cmbAlmacen.SelectedValue, txtProducto.Text, txtCantidad.Text, MyOperacionDetalleSeries, "GT")
                    MyForm.ShowDialog()
                    Call ValidarBotonAceptar()
                Else
                    btnAceptar.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As EventArgs) Handles txtCantidad.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If txtIndicaSerie.Text = "SI" Then
            Call ValidarBotonAceptar()
        Else
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub cmbAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAlmacen.SelectedIndexChanged
        If cmbAlmacen.SelectedIndex <> -1 And txtProducto.Text.Trim.Length <> 0 Then
            Call BuscarStock(txtProducto.Text.Trim)
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub obtIndicaTransportePublico_CheckedChanged(sender As Object, e As EventArgs) Handles obtIndicaTransportePublico.CheckedChanged
        If obtIndicaTransportePublico.Checked = True Then Call EvaluarTipoTransporte() : txtTransportistaRUC.Focus()
    End Sub

    Private Sub obtIndicaTransportePrivado_CheckedChanged(sender As Object, e As EventArgs) Handles obtIndicaTransportePrivado.CheckedChanged
        If obtIndicaTransportePrivado.Checked = True Then Call EvaluarTipoTransporte() : txtConductorDNI.Focus()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyAccion = "NUEVO"
        MyOperacion = New entOperacionAlmacen
        MyOperacionDetalles = New dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
        MyOperacionDetalleSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

        MyCorrelativo = New dsCorrelativo.CORRELATIVODataTable

        MyStock = 0
        MyStockAlmacen = New dsStockAlmacen.STOCK_X_ALMACENDataTable

        MyGuia = New entGuia
        MyGuias = New dsGuiasRemitente.GUIASDataTable
        MyGuiaDetalles = New dsGuiasRemitente.GUIAS_DETDataTable
        MyGuiaDetalleSeries = New dsGuiasRemitente.GUIAS_DET_SERIESDataTable

        MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable

        AfectaStock = "NO"

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.000000"
                    Case Is = "C" : ctrl.text = "0.000"
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = Nothing
                End Select
                'ElseIf TypeOf ctrl Is CheckBox Then
                '    ctrl.Checked = False
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.SelectedIndex = -1
            ElseIf TypeOf ctrl Is TabControl Then
                MyTabControl = ctrl
                For Each TCctrl As Object In MyTabControl.Controls
                    MyTabPage = TCctrl
                    For Each TPctrl As Object In MyTabPage.Controls
                        If TypeOf TPctrl Is TextBox Then
                            Select Case TPctrl.tag
                                Case Is = "V" : TPctrl.text = "0.0000"
                                Case Is = "C" : TPctrl.text = "0.000"
                                Case Is = "D" : TPctrl.text = "0.00"
                                Case Is = "E" : TPctrl.text = "0"
                                Case Else : TPctrl.text = Nothing
                            End Select
                            'ElseIf TypeOf TPctrl Is CheckBox Then
                            '    TPctrl.Checked = False
                        ElseIf TypeOf TPctrl Is ComboBox Then
                            TPctrl.SelectedIndex = -1
                        End If
                    Next
                Next
            End If
        Next

        cmbDireccionEnvio.DataSource = MyDireccionEnvio
        gvGuiaLineas.DataSource = MyOperacionDetalles

        Call PonerValoresDefault()
        Call ActivarDetalles(True)
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteFechaTraslado.Text = EvalDato(Now.Date, "F")

        ckbIndicaAnulado.Visible = False

        cmbDocumentoTipo.SelectedValue = "6"
        cmbComprobanteSerie.SelectedIndex = 0
        cmbDireccionEnvio.SelectedValue = "01"

        obtIndicaTransportePrivado.Checked = True

        cmbAlmacen.SelectedValue = MyUsuario.almacen
        txtPuntoPartida.Text = MyDomicilioFiscal & " " & MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento

        cmbComprobanteSerie.SelectedIndex = CInt(MyUsuario.serie_asignada) - 1

        Call PoblarCorrelativo()
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "SN")
                MyForm.ShowDialog()
                If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                End With
                EnableTextBox(txtRazonSocial, False)
                Call ActualizarDireccionEnvio()
                txtConductorDNI.Focus()
            Else
                txtCuentaComercial.Text = "G0000000"
                MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable
                MyDireccionEnvio.Rows.Add(MyUsuario.empresa, "G0000000", "OTROS", "99", Space(1), Space(1))
                cmbDireccionEnvio.DataSource = MyDireccionEnvio
                EnableTextBox(txtRazonSocial, True)
                txtRazonSocial.Text = Nothing
                txtRazonSocial.Focus()
            End If
        End If
    End Sub

    Private Sub ActualizarDireccionEnvio()
        MyDireccionEnvio = dalCuentaComercial.ObtenerDomicilioEnvio(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
        MyDireccionEnvio.Rows.Add(MyUsuario.empresa, "G0000000", "OTROS", "99", Space(1), Space(1))
        cmbDireccionEnvio.DataSource = MyDireccionEnvio
    End Sub

    Private Sub PoblarCorrelativo()
        If cmbComprobanteSerie.SelectedIndex <> -1 Then
            MyCorrelativo = dalVenta.ObtenerCorrelativo("09", cmbComprobanteSerie.SelectedValue, "SI")
            If MyCorrelativo.Rows.Count = 0 Then
                txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
                FechaUltimoComprobante = CDate("01/" & MyAsientoMes & "/" & MyAsientoEjercicio)
            Else
                txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
                FechaUltimoComprobante = MyCorrelativo(0).COMPROBANTE_FECHA
            End If
            'txtComprobanteFecha.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)
            txtComprobanteFecha.Text = EvalDato(Now.Date, txtComprobanteFecha.Tag)
        End If
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtComprobanteFechaTraslado, IndicaActivo)

        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)

        EnableComboBox(cmbDireccionEnvio, IndicaActivo)
        EnableTextBox(txtPuntoLlegada, IndicaActivo)

        EnableTextBox(txtConductorDNI, IndicaActivo)
        EnableTextBox(txtConductorNombre, IndicaActivo)
        EnableTextBox(txtNumeroPlaca, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtCantidad, IndicaActivo)
        btnNuevo.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3)
        EnableDataGridView(gvGuiaLineas, IndicaActivo)
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub PoblarFormulario()
        Dim Guia As String = MyGuia.guia
        Call LimpiarFormulario()
        MyGuia = dalGuia.ObtenerCabecera(Guia)
        If Not MyGuia.guia Is Nothing Then
            With MyGuia
                If .cuenta_comercial.Trim <> "G0000000" Then MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)

                txtGuia.Text = .guia
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                txtCuentaComercial.Text = .cuenta_comercial

                If .cuenta_comercial.Trim <> "G0000000" Then
                    cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento.Trim
                    txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                    txtRazonSocial.Text = MyCuentaComercial.razon_social
                    Call ActualizarDireccionEnvio()
                Else
                    cmbDocumentoTipo.SelectedValue = .destinatario_tipo_documento.Trim
                    txtDocumentoNumero.Text = .destinatario_nro_documento
                    txtRazonSocial.Text = .destinatario_razon_social
                    MyDireccionEnvio.Rows.Add(MyUsuario.empresa, "G0000000", "OTROS", "99", Space(1), Space(1))
                End If

                cmbDireccionEnvio.DataSource = MyDireccionEnvio

                cmbDireccionEnvio.SelectedValue = .domicilio_envio

                txtPuntoPartida.Text = .punto_partida
                txtPuntoLlegada.Text = .punto_llegada

                If .indica_transporte_publico = "SI" Then
                    obtIndicaTransportePublico.Checked = True
                    txtTransportistaRUC.Text = .transportista_ruc
                    txtTransportistaRazonSocial.Text = .transportista_razon_social
                Else
                    obtIndicaTransportePrivado.Checked = True
                    txtConductorDNI.Text = .conductor_dni
                    txtConductorNombre.Text = .conductor_nombre
                    txtNumeroPlaca.Text = .numero_placa
                End If

                cmbComprobanteSerie.SelectedValue = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                cmbAlmacen.SelectedValue = .almacen

                txtComentario.Text = .comentario

                Call ActivarCabecera(False)
                Call ActivarDetalles(False)

                ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)

                ckbIndicaAnulado.Visible = True

                If ckbIndicaAnulado.Checked = True Then
                    ckbIndicaAnulado.Enabled = False
                Else
                    ckbIndicaAnulado.Enabled = True
                End If

                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnNuevo_Focus = True
            End With
        End If

        MyOperacion = dalOperacionAlmacen.ObtenerGuiaTraslado(MyGuia.comprobante_tipo, MyGuia.comprobante_serie, MyGuia.comprobante_numero)

        If Not MyOperacion.operacion Is Nothing Then
            With MyOperacion
                txtOperacion.Text = .operacion
                txtReferenciaCUO.Text = MyGuia.guia
                Call ActualizarGrilla()
            End With

            MyOperacionDetalleSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, txtOperacion.Text)

            If MyOperacionDetalleSeries.Rows.Count <> 0 Then
                For NFil As Integer = 0 To MyOperacionDetalleSeries.Rows.Count - 1
                    If dalControlSeries.EvaluarSiExisteControlSeries(MyOperacionDetalleSeries(NFil).PRODUCTO, MyOperacionDetalleSeries(NFil).NUMERO_SERIE) Then
                        MyOperacionDetalleSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                    End If
                Next
            End If

            cmbAlmacen.Enabled = False
        End If

    End Sub

    Private Sub ActualizarGrilla()
        MyOperacionDetalles = dalOperacionAlmacen.ObtenerDetallesOperacion(cmbAlmacen.SelectedValue, txtOperacion.Text)
        Call EvaluarSiExisteResumen()
        gvGuiaLineas.DataSource = MyOperacionDetalles
        gvGuiaLineas.ClearSelection()
        Call LimpiarLinea()
    End Sub

    Private Sub ActualizarGrillaGuia()
        gvGuiaLineas.ClearSelection()
        Call LimpiarLinea()
    End Sub

    Private Sub EvaluarSiExisteResumen()
        If MyOperacionDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyOperacionDetalles(NEle).PRODUCTO) Then
                    MyOperacionDetalles(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                End If

                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyOperacionDetalles(NEle).PRODUCTO) Then
                    MyOperacionDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                End If
            Next
        End If
    End Sub

    Private Sub LimpiarLinea()
        txtLinea.Text = Nothing
        txtProducto.Text = Nothing
        txtProductoDescripcion.Text = Nothing
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
        txtIndicaSerie.Text = Nothing
        txtProducto.Focus()
    End Sub

    Private Sub BuscarStock(CodigoProducto As String)
        If cmbAlmacen.SelectedIndex <> -1 Then
            MyStockAlmacen = dalProducto.BuscarStocksAlmacen(cmbAlmacen.SelectedValue, CodigoProducto)
            If MyStockAlmacen.Rows.Count <> 0 Then
                txtCantidadStock.Text = EvalDato(MyStockAlmacen(0).STOCK, txtCantidadStock.Tag)
                txtCantidad.Focus()
            Else
                txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
            End If
        End If
    End Sub

    Private Sub ValidarBotonAceptar()
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim CantidadAtendida As Decimal = 0

        If MyOperacionDetalleSeries.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyOperacionDetalleSeries.Rows.Count - 1
                If MyOperacionDetalleSeries(NEle).PRODUCTO = txtProducto.Text Then
                    CantidadAtendida = CantidadAtendida + 1
                End If
            Next
        End If
        If CantidadAtendida <> Cantidad Then
            btnAceptar.Enabled = False
        Else
            GuardarDetalle()
            txtProducto.Focus()
        End If
    End Sub

    Private Function CapturarEncabezadoGuia() As Boolean
        Dim MyMensaje As String = ""

        If txtComprobanteFecha.Text.Trim.Length = 0 Then MyMensaje = "FECHA DE EMISION"
        If cmbComprobanteSerie.SelectedIndex = -1 Then MyMensaje = "SERIE"
        If txtCuentaComercial.Text.Trim.Length = 0 Then MyMensaje = "DOCUMENTO DE IDENTIDAD"

        If MyMensaje <> "" Then
            Resp = MsgBox("Debe registrar el valor del campo " & MyMensaje, MsgBoxStyle.Information, "PROCESO CANCELADO")
            Return False
        Else

            With MyGuia
                .empresa = MyUsuario.empresa
                .guia = txtGuia.Text
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .tipo_operacion = "G9" ' OTROS
                .cuenta_comercial = txtCuentaComercial.Text
                .comprobante_tipo = "09"
                .comprobante_serie = cmbComprobanteSerie.SelectedValue
                .comprobante_numero = txtComprobanteNumero.Text
                .comprobante_fecha = txtComprobanteFecha.Text
                .comprobante_fecha_traslado = txtComprobanteFechaTraslado.Text
                .almacen = cmbAlmacen.SelectedValue
                .almacen_destino = cmbAlmacen.SelectedValue
                .domicilio_envio = cmbDireccionEnvio.SelectedValue
                .motivo_traslado = "13" ' OTROS
                .punto_partida = txtPuntoPartida.Text
                .punto_llegada = txtPuntoLlegada.Text
                .destinatario_tipo_documento = cmbDocumentoTipo.SelectedValue
                .destinatario_nro_documento = txtDocumentoNumero.Text
                .destinatario_razon_social = txtRazonSocial.Text
                .conductor_dni = txtConductorDNI.Text
                .conductor_nombre = txtConductorNombre.Text
                .numero_placa = txtNumeroPlaca.Text
                .transportista_ruc = txtTransportistaRUC.Text
                .transportista_razon_social = txtTransportistaRazonSocial.Text
                .comentario = txtComentario.Text.Trim
                .indica_transporte_publico = IIf(obtIndicaTransportePublico.Checked = True, "SI", "NO")
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
                .usuario_registro = MyUsuario.usuario
                .usuario_modifica = MyUsuario.usuario
            End With
            Return True
        End If
    End Function

    Private Sub GrabarTraslado()
        Try
            MyOperacion = dalOperacionAlmacen.GrabarTraslado(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia)

            txtOperacion.Text = MyOperacion.operacion
            txtReferenciaCUO.Text = MyOperacion.referencia_cuo
            Resp = MsgBox("La operación se grabó con éxito.", MsgBoxStyle.Information, "PROCESO CONCLUIDO")
            txtGuia.Text = MyOperacion.referencia_cuo
            MyGuia.guia = MyOperacion.referencia_cuo
            Call LimpiarFormulario()
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub GuardarDetalle()
        Dim EsNuevoDetalle As Boolean = True
        Dim NumeroLinea As Integer = 0
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim ExisteResumenAlmacen As String = "NO"
        Dim ExisteResumenPeriodo As String = "NO"

        Dim MyIndice As Integer

        If cmbAlmacen.SelectedIndex <> -1 And txtProducto.Text.Trim.Length <> 0 And Cantidad <> 0 Then
            If MyOperacionDetalles.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                    If MyOperacionDetalles(NEle).PRODUCTO = txtProducto.Text Then EsNuevoDetalle = False : MyIndice = NEle
                    NumeroLinea = NumeroLinea + 1
                Next
            End If

            If EsNuevoDetalle = True Then
                If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenAlmacen = "SI"
                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenPeriodo = "SI"
                MyOperacionDetalles.Rows.Add(NumeroLinea, MyProducto.producto, MyProducto.descripcion_ampliada, Cantidad, MyProducto.indica_serie, ExisteResumenAlmacen, ExisteResumenPeriodo, ExisteResumenPeriodo)
            Else

                MyOperacionDetalles(MyIndice).CANTIDAD = Cantidad
            End If

            If MyOperacionDetalles.Rows.Count <> 0 Then
                EnableComboBox(cmbAlmacen, False)
            Else
                EnableComboBox(cmbAlmacen, True)
            End If

            gvGuiaLineas.DataSource = MyOperacionDetalles
            gvGuiaLineas.ClearSelection()
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub EvaluarTipoTransporte()
        EnableTextBox(txtConductorDNI, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtConductorNombre, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtNumeroPlaca, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtTransportistaRUC, obtIndicaTransportePublico.Checked)
        EnableTextBox(txtTransportistaRazonSocial, obtIndicaTransportePublico.Checked)
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        UC_ToolBar.btnGrabar_Visible = True
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        If txtComprobanteFecha.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar la Fecha de Emisión.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtComprobanteFechaTraslado.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar la Fecha de Traslado.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtDocumentoNumero.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar el Documento de Identidad del Destinatario.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtRazonSocial.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar el Nombre o Razón Social del Destinatario.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtPuntoPartida.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar el Punto de Partida.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtPuntoLlegada.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar el Punto de Partida.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf txtComentario.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe indicar un Comentario.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf MyOperacionDetalles.Rows.Count = 0 Then
            Resp = MsgBox("No existen detalles a procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        Else
            With MyOperacion
                .empresa = MyUsuario.empresa
                .almacen = cmbAlmacen.SelectedValue
                .almacen_destino = cmbAlmacen.SelectedValue
                .operacion = txtOperacion.Text
                .referencia_cuo = txtReferenciaCUO.Text
                .tipo_operacion = "12"   ' Retiro
                .ejercicio = txtEjercicio.Text
                .mes = txtMes.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .fecha_operacion = txtComprobanteFecha.Text
                .comentario = txtComentario.Text.Trim
                .tipo_es = MyTipoOperacion
                .referencia_cuenta_comercial = txtCuentaComercial.Text
                .referencia_tipo = "09"  ' Guia de Remision
                .referencia_serie = cmbComprobanteSerie.SelectedValue
                .referencia_numero = txtComprobanteNumero.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .referencia_fecha = txtComprobanteFecha.Text
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")

                .afecta_stock = AfectaStock
            End With

            For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                If MyOperacionDetalles(NEle).INDICA_SERIE = "SI" Then
                    If MyOperacionDetalleSeries.Rows.Count <> 0 Then
                        For NFil As Integer = 0 To MyOperacionDetalleSeries.Rows.Count - 1
                            If MyOperacionDetalleSeries(NFil).PRODUCTO = MyOperacionDetalles(NEle).PRODUCTO Then
                                If dalControlSeries.EvaluarSiExisteControlSeries(MyOperacionDetalleSeries(NFil).PRODUCTO, MyOperacionDetalleSeries(NFil).NUMERO_SERIE) Then
                                    MyOperacionDetalleSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                                End If
                            End If
                        Next
                    End If
                End If
            Next

            If txtOperacion.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                Resp = MsgBox("Confirmar proceso de anulación de la Guia de Traslado.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR GUIA")
                If Resp = 1 Then
                    If dalOperacionAlmacen.AnularTraslado(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia) = True Then
                        Resp = MsgBox("La Operación se anuló con éxito.", MsgBoxStyle.Information, "ANULAR GUIA")
                        Call LimpiarFormulario()
                    Else
                        ckbIndicaAnulado.Checked = False
                        UC_ToolBar.btnEditar_Focus = True
                    End If
                End If
            Else
                If CapturarEncabezadoGuia() = True Then Call GrabarTraslado()
            End If
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyGuia = New entGuia
        Dim MyForm As New frmGuiaTrasladoLista(MyGuia, txtEjercicio.Text, txtMes.Text, "A")
        MyForm.ShowDialog()
        If Not MyGuia.guia Is Nothing Then
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtGuia.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmGuiaRemitenteImprimir(MyGuia, "OTROS")
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Call GuardarDetalle()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarLinea()
    End Sub

#End Region


End Class
