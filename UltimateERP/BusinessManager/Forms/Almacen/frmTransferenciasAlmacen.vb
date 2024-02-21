Public Class frmTransferenciasAlmacen

    Private MyAccion As String = "NUEVO"

    Private MyOperacion As entOperacionAlmacen
    Private MyOperacionTransferencia As entOperacionTransferencia
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

    Private Sub frmOperacionesAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOperacionesAlmacen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbAlmacenDestino, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbTransportista, "COM_TRANSPORTISTA")
        ActualizarListaEmpresa(cmbUnidadTransporte, "COM_UNIDAD_TRANSPORTE")
        ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_GUIAS")
        'ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, "6")

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

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
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
                If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
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

    Private Sub gvTransferenciasLineas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvTransferenciasLineas.CellClick
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

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperacionFecha.Validated, txtComprobanteFecha.Validated
        Dim MyFecha As Date
        Dim MyTipoFecha As String = sender.name
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                MyFecha = CDate(sender.Text)
                MyTipoFecha = IIf(sender.name = "txtOperacionFecha", "OPERACION", "GUIA")
                If MyFecha > MyFechaServidor Then
                    Resp = MsgBox("La fecha a registrar no debe ser mayor de hoy.", MsgBoxStyle.Information, "FECHA DE LA " & MyTipoFecha & " INCORRECTA")
                    sender.Text = Nothing
                Else
                    If MyFecha > MyUltimoDiaMes Or MyFecha < MyPrimerDiaMes Then
                        Resp = MsgBox("La fecha debe estar dentro del rango de dias del periodo" & vbCrLf & "actual de trabajo: " & _
                                      "Del " & MyPrimerDiaMes.ToString("dd/MM/yyyy") & " al " & MyUltimoDiaMes.ToString("dd/MM/yyyy"), MsgBoxStyle.Information, "FECHA DE LA " & MyTipoFecha & " INCORRECTA")
                        sender.Text = Nothing
                    Else
                        If MyTipoFecha = "OPERACION" Then
                            cmbAlmacen.Focus()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ckbExigeGuia_Click(sender As Object, e As EventArgs) Handles ckbExigeGuia.Click
        Call EvaluarExigeGuia()
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
                    Dim MyForm As New frmOperacionDetalleSeries(cmbAlmacen.SelectedValue, txtProducto.Text, txtCantidad.Text, MyOperacionDetalleSeries, "TA")
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

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyAccion = "NUEVO"
        MyOperacion = New entOperacionAlmacen
        MyOperacionTransferencia = New entOperacionTransferencia
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

        gvTransferenciasLineas.DataSource = MyOperacionDetalles
        cmbDireccionEnvio.DataSource = MyDireccionEnvio

        Call PonerValoresDefault()
        Call ActivarDetalles(True)
        Call ActivarCabecera(True)

        ckbExigeGuia.Enabled = True

        txtOperacionFecha.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtOperacionFecha.Text = EvalDato(Now.Date, "F")

        cmbAlmacen.Enabled = True
        ckbExigeGuia.Checked = False

        cmbAlmacen.SelectedValue = "001"

        ckbIndicaAnulado.Visible = False

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "NO")
                MyForm.ShowDialog()
                If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyCuentaComercial.cuenta_comercial)
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social

                    Call ActualizarDireccionEnvio()

                    cmbDireccionEnvio.SelectedValue = "01"
                End With
                txtComprobanteFecha.Focus()
            Else
                Resp = MsgBox("El Documento de Identidad consultado no existe.", MsgBoxStyle.Information, "OPERACION CANCELADA")
                txtDocumentoNumero.Text = Nothing
            End If
        End If
    End Sub

    Private Sub ActualizarDireccionEnvio()
        MyDireccionEnvio = dalCuentaComercial.ObtenerDomicilioEnvio(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
        If MyDireccionEnvio.Rows.Count <> 0 Then cmbDireccionEnvio.DataSource = MyDireccionEnvio

    End Sub

    Private Sub EvaluarExigeGuia()

        EnableComboBox(cmbDocumentoTipo, ckbExigeGuia.Checked)
        EnableComboBox(cmbComprobanteSerie, ckbExigeGuia.Checked)
        EnableComboBox(cmbTransportista, ckbExigeGuia.Checked)
        EnableComboBox(cmbUnidadTransporte, ckbExigeGuia.Checked)
        EnableTextBox(txtDocumentoNumero, ckbExigeGuia.Checked)
        EnableTextBox(txtComprobanteFecha, ckbExigeGuia.Checked)

        If ckbExigeGuia.Checked = False Then
            txtCuentaComercial.Text = Nothing
            cmbDocumentoTipo.SelectedIndex = -1
            cmbComprobanteSerie.SelectedIndex = -1
            cmbTransportista.SelectedIndex = -1
            cmbUnidadTransporte.SelectedIndex = -1
            txtDocumentoNumero.Text = Nothing
            txtRazonSocial.Text = Nothing
            txtComprobanteNumero.Text = Nothing
            txtComprobanteFecha.Text = Nothing
            UC_ToolBar.btnAceptar_Focus = True
        Else
            cmbDocumentoTipo.SelectedValue = "6"
            cmbComprobanteSerie.SelectedIndex = 0
            Call PoblarCorrelativo()
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub PoblarCorrelativo()
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
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtOperacionFecha, IndicaActivo)
        EnableComboBox(cmbAlmacen, IndicaActivo)
        EnableComboBox(cmbAlmacenDestino, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)

        EnableComboBox(cmbDocumentoTipo, Not IndicaActivo)
        EnableTextBox(txtDocumentoNumero, Not IndicaActivo)

        EnableComboBox(cmbComprobanteSerie, Not IndicaActivo)
        EnableTextBox(txtComprobanteNumero, Not IndicaActivo)
        EnableTextBox(txtComprobanteFecha, Not IndicaActivo)
        EnableComboBox(cmbUnidadTransporte, Not IndicaActivo)
        EnableComboBox(cmbTransportista, Not IndicaActivo)
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtCantidad, IndicaActivo)
        btnNuevo.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3)
        EnableDataGridView(gvTransferenciasLineas, IndicaActivo)
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub PoblarFormulario()
        Dim OperacionAlmacen As String = MyOperacion.operacion
        Dim AlmacenOperacion As String = MyOperacion.almacen
        Call LimpiarFormulario()
        MyOperacion = dalOperacionAlmacen.ObtenerOperacion(OperacionAlmacen)
        MyOperacionTransferencia = dalOperacionAlmacen.ObtenerTransferencia(OperacionAlmacen)

        If Not MyOperacion.operacion Is Nothing Then
            With MyOperacion
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtOperacion.Text = .operacion
                txtReferenciaCUO.Text = MyOperacionTransferencia.referencia_cuo
                txtOperacionFecha.Text = EvalDato(.fecha_operacion, "F")
                cmbAlmacen.SelectedValue = .almacen
                cmbAlmacenDestino.SelectedValue = MyOperacionTransferencia.almacen_destino
                txtComentario.Text = .comentario.Trim
                cmbComprobanteSerie.SelectedValue = .referencia_serie
                txtComprobanteNumero.Text = .referencia_numero
                If .referencia_numero.Trim.Length <> 0 Then
                    .exige_guia = "SI"
                    MyGuia = dalGuia.ObtenerCabecera(.referencia_tipo, .referencia_serie, .referencia_numero)

                    cmbComprobanteSerie.SelectedValue = .referencia_serie
                    txtComprobanteNumero.Text = .referencia_numero
                    If .referencia_fecha.Year <> 1900 Then txtComprobanteFecha.Text = EvalDato(.referencia_fecha, "F")

                    txtGuia.Text = MyGuia.guia
                    txtCuentaComercial.Text = MyGuia.cuenta_comercial

                    cmbDireccionEnvio.SelectedValue = MyGuia.centro_distribucion

                    MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyGuia.cuenta_comercial)

                    cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                    txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                    txtRazonSocial.Text = MyCuentaComercial.razon_social

                End If
                ActivarCabecera(False)
                ActivarDetalles(False)

                EnableComboBox(cmbComprobanteSerie, False)
                EnableTextBox(txtComprobanteNumero, False)
                EnableTextBox(txtComprobanteFecha, False)
                EnableComboBox(cmbUnidadTransporte, False)
                EnableComboBox(cmbTransportista, False)

                EnableComboBox(cmbDocumentoTipo, False)
                EnableTextBox(txtDocumentoNumero, False)

                ckbExigeGuia.Enabled = False
                cmbAlmacen.Enabled = False
                cmbAlmacenDestino.Enabled = False

                ckbIndicaAnulado.Visible = True

                '' Solo es posible modificar si se cumple que:
                '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó
                '' 2.- El movimiento no se encuentra anulado
                '' 3.- Si no ha sido enviado a SUNAT

                If .estado = "N" Then
                    ckbIndicaAnulado.Checked = True
                    ckbIndicaAnulado.Enabled = False
                Else
                    ckbIndicaAnulado.Checked = False
                    ckbIndicaAnulado.Enabled = True
                End If

                Call ActualizarGrilla()
            End With
            UC_ToolBar.btnGrabar_Visible = True
            UC_ToolBar.btnAceptar_Visible = False
            UC_ToolBar.btnNuevo_Focus = True
        End If
    End Sub

    Private Sub ActualizarGrilla()
        MyOperacionDetalles = dalOperacionAlmacen.ObtenerDetallesTransferencia(MyUsuario.empresa, cmbAlmacen.SelectedValue, txtOperacion.Text)
        MyOperacionDetalleSeries = dalOperacionAlmacen.ObtenerDetallesTransferenciaSeries(MyUsuario.empresa, txtOperacion.Text)
        gvTransferenciasLineas.DataSource = MyOperacionDetalles
        gvTransferenciasLineas.ClearSelection()
        Call LimpiarLinea()
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

    Private Sub BuscarStock(CodigoProducto)
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

    Private Sub CapturarEncabezadoOperacion()
        With MyOperacion
            .empresa = MyUsuario.empresa
            .almacen = cmbAlmacen.SelectedValue
            .almacen_destino = cmbAlmacenDestino.SelectedValue
            .operacion = txtOperacion.Text
            .referencia_cuo = txtReferenciaCUO.Text
            .tipo_operacion = "TA"   ' Transferencia entre almacenes
            .ejercicio = txtEjercicio.Text
            .mes = txtMes.Text
            If txtOperacionFecha.Text.Length <> 0 Then .fecha_operacion = txtOperacionFecha.Text
            .comentario = txtComentario.Text.Trim
            .tipo_es = MyTipoOperacion
            .referencia_cuenta_comercial = txtCuentaComercial.Text
            .referencia_tipo = "09"  ' Guia de Remision
            .referencia_serie = cmbComprobanteSerie.SelectedValue
            .referencia_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then .referencia_fecha = txtComprobanteFecha.Text
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")

            .exige_guia = IIf(ckbExigeGuia.Checked = True, "SI", "NO")
        End With
    End Sub

    Private Function CapturarEncabezadoGuia() As Boolean
        Dim MyMensaje As String = ""

        If cmbUnidadTransporte.SelectedIndex = -1 Then MyMensaje = "UNIDAD DE TRANSPORTE"
        If cmbTransportista.SelectedIndex = -1 Then MyMensaje = "TRANSPORTISTA/CONDUCTOR"
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
                .tipo_operacion = "G2"
                .cuenta_comercial = txtCuentaComercial.Text
                .centro_distribucion = cmbDireccionEnvio.SelectedValue
                .comprobante_tipo = "09"
                .comprobante_serie = cmbComprobanteSerie.SelectedValue
                .comprobante_numero = txtComprobanteNumero.Text
                .comprobante_fecha = txtComprobanteFecha.Text
                .comprobante_fecha_traslado = txtComprobanteFecha.Text
                .almacen = cmbAlmacen.SelectedValue
                .almacen_destino = cmbAlmacenDestino.SelectedValue
                .motivo_traslado = "04"
                .comentario = txtComentario.Text.Trim
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
                .usuario_registro = MyUsuario.usuario
                .usuario_modifica = MyUsuario.usuario
            End With
            Return True
        End If
    End Function

    Private Sub GrabarTransferencia()
        MyOperacion = dalOperacionAlmacen.GrabarTransferencia(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia)
        txtOperacion.Text = MyOperacion.operacion
        txtReferenciaCUO.Text = MyOperacion.referencia_cuo
        Resp = MsgBox("La transferencia se grabó con éxito.", MsgBoxStyle.Information, "PROCESO CONCLUIDO")
        Call LimpiarFormulario()
    End Sub

    Private Sub GuardarDetalle()
        Dim EsNuevoDetalle As Boolean = True
        Dim NumeroLinea As Integer = 0
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim ExisteResumenAlmacen As String = "NO"
        Dim ExisteResumenPeriodo As String = "NO"
        Dim ExisteResumenPeriodo2 As String = "NO"

        Dim MyIndice As Integer

        If cmbAlmacen.SelectedIndex <> -1 And txtProducto.Text.Trim.Length <> 0 And Cantidad <> 0 Then
            If MyOperacionDetalles.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                    If MyOperacionDetalles(NEle).PRODUCTO = txtProducto.Text Then EsNuevoDetalle = False : MyIndice = NEle
                    NumeroLinea = NumeroLinea + 1
                Next
            End If

            If EsNuevoDetalle = True Then
                If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacenDestino.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenAlmacen = "SI"
                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenPeriodo = "SI"
                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacenDestino.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenPeriodo2 = "SI"
                MyOperacionDetalles.Rows.Add(NumeroLinea, MyProducto.producto, MyProducto.descripcion_ampliada, Cantidad, MyProducto.indica_serie, ExisteResumenAlmacen, ExisteResumenPeriodo, ExisteResumenPeriodo2)
            Else

                MyOperacionDetalles(MyIndice).CANTIDAD = Cantidad
            End If

            gvTransferenciasLineas.DataSource = MyOperacionDetalles
            gvTransferenciasLineas.ClearSelection()
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub EvaluarIndicaSerie()
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
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        If cmbAlmacen.SelectedIndex = -1 Then
            Resp = MsgBox("Debe indicar el Almacen de Origen.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf cmbAlmacenDestino.SelectedIndex = -1 Then
            Resp = MsgBox("Debe indicar el Almacen de Destino.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf cmbAlmacen.SelectedValue = cmbAlmacenDestino.SelectedValue Then
            Resp = MsgBox("Los Almacenes de Origen y Destino no pueden ser los mismos.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        ElseIf MyOperacionDetalles.Rows.Count = 0 Then
            Resp = MsgBox("No existen detalles a procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        Else
            Call CapturarEncabezadoOperacion()
            Call EvaluarIndicaSerie()

            Try
                UC_ToolBar.btnAceptar_Visible = False
                If ckbExigeGuia.Checked = True Then
                    If CapturarEncabezadoGuia() = True Then Call GrabarTransferencia()
                Else
                    Call GrabarTransferencia()
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim PeriodoTrabajo = MyUsuario.ejercicio & MyUsuario.mes.ToString("00")
        Dim PeriodoComprobante = txtEjercicio.Text & txtMes.Text

        Dim CantidadStockAlmacenDestino As Decimal = 0
        Dim ContinuarAnulacion As Boolean = True
        Dim CantidadAnular As Decimal = 0

        Try
            UC_ToolBar.btnGrabar_Visible = False
            If txtOperacion.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                If PeriodoTrabajo <> PeriodoComprobante Then
                    Resp = MsgBox("Para anular la Guía debe cambiar el periodo de trabajo al mes de " &
                                  UCase(EvalMes(PeriodoComprobante.Substring(4, 2), "L")) & " del " &
                                  PeriodoComprobante.Substring(0, 4), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                    Call LimpiarFormulario()
                Else
                    For NEle As Integer = 0 To MyOperacionDetalles.Rows.Count - 1
                        CantidadAnular = MyOperacionDetalles(NEle).CANTIDAD
                        MyStockAlmacen = dalProducto.BuscarStocksAlmacen(cmbAlmacenDestino.SelectedValue, MyOperacionDetalles(NEle).PRODUCTO)
                        If MyStockAlmacen.Rows.Count <> 0 Then
                            CantidadStockAlmacenDestino = MyStockAlmacen(0).STOCK
                        Else
                            CantidadStockAlmacenDestino = 0
                        End If
                        If CantidadStockAlmacenDestino < CantidadAnular Then ContinuarAnulacion = False
                    Next

                    If ContinuarAnulacion = False Then
                        Resp = MsgBox("No existe stock suficiente en el almacén de destino para retornarlo al almacén de origen.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "PROCESO CANCELADO")
                        ckbIndicaAnulado.Checked = False
                        UC_ToolBar.btnGrabar_Visible = True
                        UC_ToolBar.btnEditar_Focus = True
                    Else
                        Resp = MsgBox("Confirmar proceso de anulación del Traslado entre Almacenes.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR TRASLADO")
                        If Resp = 1 Then
                            Call EvaluarIndicaSerie()
                            If dalOperacionAlmacen.AnularTransferencia(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia) = True Then
                                Resp = MsgBox("El Traslado entre Almacenes se anuló con éxito.", MsgBoxStyle.Information, "ANULAR TRASLADO")
                                Call LimpiarFormulario()
                                UC_ToolBar.btnEditar_Focus = True
                            Else
                                UC_ToolBar.btnGrabar_Visible = True
                                ckbIndicaAnulado.Checked = False
                                txtOperacionFecha.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        If cmbAlmacen.SelectedIndex <> -1 Then
            MyOperacion = New entOperacionAlmacen
            MyOperacion.almacen = cmbAlmacen.SelectedValue
            MyOperacion.tipo_operacion = "TA"
            Dim MyForm As New frmOperacionesAlmacenes(MyOperacion, MyTipoOperacion, True, "SN")
            MyForm.ShowDialog()
            If Not MyOperacion.operacion Is Nothing Then Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        Dim MyDetalles As New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        Dim MyDetallesImprimir As New dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable
        Dim CodigoProducto As String

        Dim MyComentario As String

        Dim MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        Dim MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        If txtOperacion.Text.Trim.Length <> 0 And txtGuia.Text.Length = 0 Then
            Dim FEmision As Date = CDate(txtOperacionFecha.Text)
            MyAccion = "IMPRIMIR"
            MyComentario = "ORIGEN: " & cmbAlmacen.Text & " DESTINO: " & cmbAlmacenDestino.Text & " " & txtComentario.Text

            MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, cmbAlmacen.SelectedValue, txtOperacion.Text)
            MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, txtOperacion.Text)

            If MyDetallesOperacion.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                    MyDetalles.ImportRow(MyDetallesOperacion(NEle))
                Next

                For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
                    If MyDetalles(NEle).INDICA_SERIE = "SI" Then
                        'CodigoProducto = MyDetalles(NEle).PRODUCTO
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & " SERIES: "
                        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                            For NFila As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                                If MyDetallesOperacionSeries(NFila).PRODUCTO = MyDetalles(NEle).PRODUCTO Then
                                    MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & MyDetallesOperacionSeries(NFila).NUMERO_SERIE & " / "
                                End If
                            Next
                        End If
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA.Substring(0, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim.Length - 1)
                    End If
                    MyDetallesImprimir.Rows.Add(MyDetalles(NEle).PRODUCTO, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim, MyDetalles(NEle).CODIGO_COMPRA, MyDetalles(NEle).CANTIDAD, MyDetalles(NEle).NUMERO_LOTE)
                Next
            End If

            Dim MyForm As New frmOperacionAlmacenImprimir(txtOperacion.Text, CDate(txtOperacionFecha.Text), cmbAlmacen.Text, "TRANSFERENCIA ENTRE ALMACENES", MyComentario, MyDetallesImprimir)
            MyForm.ShowDialog()
        Else
            If txtOperacion.Text.Trim.Length <> 0 And txtGuia.Text.Trim.Length <> 0 Then
                Dim MyForm As New frmGuiaRemitenteImprimir(txtGuia.Text.Trim, txtOperacion.Text.Trim)
                MyForm.ShowDialog()
            End If
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
