Public Class frmGuiaPorTrasladoExterno

    Private MyOperacion As entOperacionAlmacen
    Private MyOperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
    Private MyOperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

    Private MyProducto As entProducto
    Private MyTipoOperacion As String = "T"
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

    Private AfectaStock As String

    Private MyAlmacenDestino As New dsTablasGenericas.LISTADataTable

    Private MotivoTrasladoDescripcion As String = "TRASLADO PARA EXHIBICION"
    Private TipoOperacion As String = "G8" ' G2 Translado entre almacenes, G4 - Venta Vehicular, G5 - Venta Directa, G8 - Eventos y Ferias

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmGuiaPorTrasladoInterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmGuiaPorTrasladoInterno_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        MyAlmacenDestino = AlmacenesExternos()

        cmbAlmacenDestino.DataSource = MyAlmacenDestino

        ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_GUIAS")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = MyUsuario.mes.ToString("00")
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")
        MyAsientoDia = MyAsientoFecha.Day.ToString("00")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated
        Dim MyFecha As Date

        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.Name = "txtComprobanteFechaTraslado" Then
                    MyFecha = CDate(txtComprobanteFechaTraslado.Text)
                    If MyFecha < CDate(txtComprobanteFecha.Text) Then
                        Resp = MsgBox("La fecha de traslado debe ser igual o mayor que la fecha del comprobante de venta.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                        txtComprobanteFechaTraslado.Text = Nothing
                        txtComprobanteFechaTraslado.Focus()
                    Else
                        cmbAlmacen.Focus()
                    End If
                End If
            End If
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
                    Dim MyForm As New frmOperacionDetalleSeriesVehiculares(cmbAlmacen.SelectedValue, txtProducto.Text, txtCantidad.Text, MyOperacionDetalleSeries, "GT")
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

    Private Sub txtConductorDNI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConductorDNI.KeyDown
        Dim MyElemento As New dsTablasGenericas.LISTADataTable
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCodigo = sender.Text.Trim

            If MyCodigo.Trim.Length = 0 Then
                Dim MyForm As New frmElementoLista(MyElemento, "COM_TRANSPORTE_PRIVADO", "TRANSPORTE PRIVADO")
                MyForm.ShowDialog()
                If MyElemento.Rows.Count <> 0 Then
                    txtConductorDNI.Text = MyElemento(0).CODIGO
                    txtConductorNombre.Text = MyElemento(0).DESCRIPCION_AMPLIADA
                    txtNumeroPlaca.Text = MyElemento(0).REFERENCIA
                    txtNumeroPlaca.Focus()
                End If
            Else
                txtConductorNombre.Focus()
            End If
        End If
    End Sub

    Private Sub txtTransportistaRUC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportistaRUC.KeyDown
        Dim MyElemento As New dsTablasGenericas.LISTADataTable
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCodigo = sender.Text.Trim

            If MyCodigo.Trim.Length = 0 Then
                Dim MyForm As New frmElementoLista(MyElemento, "COM_TRANSPORTE_PUBLICO", "TRANSPORTE PUBLICO")
                MyForm.ShowDialog()
                If MyElemento.Rows.Count <> 0 Then
                    txtTransportistaRUC.Text = MyElemento(0).CODIGO
                    txtTransportistaRazonSocial.Text = MyElemento(0).DESCRIPCION_AMPLIADA
                    txtComentario.Focus()
                End If
            Else
                txtTransportistaRazonSocial.Focus()
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyOperacion = New entOperacionAlmacen
        MyOperacionDetalles = New dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
        MyOperacionDetalleSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        MyProducto = New entProducto

        MyCorrelativo = New dsCorrelativo.CORRELATIVODataTable

        MyStock = 0
        MyStockAlmacen = New dsStockAlmacen.STOCK_X_ALMACENDataTable

        MyGuia = New entGuia
        MyGuias = New dsGuiasRemitente.GUIASDataTable
        MyGuiaDetalles = New dsGuiasRemitente.GUIAS_DETDataTable
        MyGuiaDetalleSeries = New dsGuiasRemitente.GUIAS_DET_SERIESDataTable

        AfectaStock = "SI"

        InicializarFormulario(Me)

        gvGuiaLineas.DataSource = MyOperacionDetalles

        Call PonerValoresDefault()
        Call ActivarDetalles(True)
        Call ActivarCabecera(True)

        cmbAlmacenDestino.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteFechaTraslado.Text = EvalDato(Now.Date, "F")
        ckbIndicaAnulado.Visible = False
        obtIndicaTransportePrivado.Checked = True
        cmbAlmacen.SelectedValue = MyUsuario.almacen
        txtPuntoPartida.Text = MyDomicilioFiscal & " " & MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento
        cmbComprobanteSerie.SelectedIndex = CInt(MyUsuario.serie_asignada) - 1

        Call PoblarCorrelativo()

        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnGrabar_Visible = False
    End Sub

    Private Sub PoblarCorrelativo()
        AsignarNumeroComprobante(cmbComprobanteSerie, txtComprobanteNumero, FechaUltimoComprobante)
    End Sub

    Private Sub PoblarFormulario()
        Dim Guia As String = MyGuia.guia
        Call LimpiarFormulario()
        MyGuia = dalGuia.ObtenerCabecera(Guia)
        If Not MyGuia.guia Is Nothing Then
            With MyGuia
                txtGuia.Text = .guia
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                cmbAlmacenDestino.SelectedValue = .almacen_destino

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
                txtComprobanteFechaTraslado.Text = EvalDato(.comprobante_fecha_traslado, "F")
                cmbAlmacen.SelectedValue = .almacen

                txtComentario.Text = .comentario

                Call ActivarCabecera(False)
                Call ActivarDetalles(False)

                '' Solo es posible modificar si se cumple que:
                '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó
                '' 2.- El movimiento no se encuentra anulado
                '' 3.- Para la Forma de Pago diferente a EF: Efectivo, que el valor del campo IMPORTE_SALDO sea igual al del campo IMPORTE_TOTAL_ORIGEN
                '' 4.- Si no ha sido enviado a SUNAT

                ckbIndicaAnulado.Visible = True

                If .estado = "N" Then
                    ckbIndicaAnulado.Checked = True
                    ckbIndicaAnulado.Enabled = False
                Else
                    ckbIndicaAnulado.Checked = False
                    ckbIndicaAnulado.Enabled = True
                End If

                If .estado_envio = "P" Then UC_ToolBar.btnSUNAT_Visible = True

                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnGrabar_Visible = True
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

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtComprobanteFechaTraslado, IndicaActivo)

        EnableComboBox(cmbAlmacenDestino, IndicaActivo)
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
    End Sub

    Private Function CapturarEncabezadoGuia() As Boolean
        Dim MyMensaje As String = ""

        If obtIndicaTransportePublico.Checked = True Then
            If txtTransportistaRazonSocial.Text.Trim.Length = 0 Then MyMensaje = "RAZON SOCIAL DEL TRANSPORTISTA"
            If txtTransportistaRUC.Text.Trim.Length = 0 Then MyMensaje = "RUC"
        Else
            If txtConductorNombre.Text.Trim.Length = 0 Then MyMensaje = "NOMBRE DEL CONDUCTOR"
            If txtConductorDNI.Text.Trim.Length = 0 Then MyMensaje = "DNI"
        End If

        If cmbAlmacenDestino.SelectedIndex = -1 Then MyMensaje = "PUNTO DE LLEGADA"
        If cmbAlmacen.SelectedIndex = -1 Then MyMensaje = "PUNTO DE PARTIDA"
        If txtComprobanteFechaTraslado.Text.Trim.Length = 0 Then MyMensaje = "FECHA DE TRASLADO"
        If txtComprobanteFecha.Text.Trim.Length = 0 Then MyMensaje = "FECHA DE EMISION"
        If cmbComprobanteSerie.SelectedIndex = -1 Then MyMensaje = "SERIE"

        If MyMensaje <> "" Then
            Resp = MsgBox("Debe registrar el valor del campo " & MyMensaje, MsgBoxStyle.Information, "PROCESO CANCELADO")
            Return False
        Else
            With MyGuia
                .empresa = MyUsuario.empresa
                .guia = txtGuia.Text
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .tipo_operacion = TipoOperacion
                .cuenta_comercial = "G0000000"
                .comprobante_tipo = "09"
                .comprobante_serie = cmbComprobanteSerie.SelectedValue
                .comprobante_numero = txtComprobanteNumero.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .comprobante_fecha = txtComprobanteFecha.Text
                If txtComprobanteFechaTraslado.Text.Length <> 0 Then .comprobante_fecha_traslado = txtComprobanteFechaTraslado.Text
                .almacen = cmbAlmacen.SelectedValue
                .almacen_destino = cmbAlmacenDestino.SelectedValue
                .motivo_traslado = "13" ' 01 - Venta, 04 - Traslado entre almacenes, 13 - Otros 
                .punto_partida = txtPuntoPartida.Text
                .punto_llegada = txtPuntoLlegada.Text
                .destinatario_tipo_documento = "6"
                .destinatario_nro_documento = MyRUC
                .destinatario_razon_social = MyRazonSocial
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

    Private Sub EvaluarTipoTransporte()
        EnableTextBox(txtConductorDNI, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtConductorNombre, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtNumeroPlaca, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtTransportistaRUC, obtIndicaTransportePublico.Checked)
        EnableTextBox(txtTransportistaRazonSocial, obtIndicaTransportePublico.Checked)

        If obtIndicaTransportePrivado.Checked = True Then
            txtTransportistaRUC.Text = Nothing
            txtTransportistaRazonSocial.Text = Nothing
        Else
            txtConductorDNI.Text = Nothing
            txtConductorNombre.Text = Nothing
            txtNumeroPlaca.Text = Nothing
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

    Private Sub GrabarTrasladoExterno()
        Try
            MyOperacion = dalOperacionAlmacen.GrabarTrasladoExterno(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia)

            txtOperacion.Text = MyOperacion.operacion
            txtGuia.Text = MyOperacion.referencia_cuo
            txtReferenciaCUO.Text = MyOperacion.referencia_cuo
            MyGuia.guia = MyOperacion.referencia_cuo
            MyGuia.referencia_cuo = MyOperacion.operacion
            Resp = MsgBox("La operación se grabó con éxito.", MsgBoxStyle.Information, "PROCESO CONCLUIDO")
            Call ActivarCabecera(False)
            Call ActivarDetalles(False)
            UC_ToolBar.btnImprimir_Visible = True
            UC_ToolBar.btnSUNAT_Visible = True
            UC_ToolBar.btnImprimir_Focus = True

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

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        If MyOperacionDetalles.Rows.Count = 0 Then
            Resp = MsgBox("No existen detalles a procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        Else
            With MyOperacion
                .empresa = MyUsuario.empresa
                .almacen = cmbAlmacen.SelectedValue
                .almacen_destino = cmbAlmacen.SelectedValue
                .operacion = txtOperacion.Text
                .referencia_cuo = txtReferenciaCUO.Text
                .tipo_operacion = "99"   ' Traslados varios (Eventos, Ferias)
                .ejercicio = txtEjercicio.Text
                .mes = txtMes.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .fecha_operacion = txtComprobanteFecha.Text
                .comentario = txtComentario.Text.Trim
                .tipo_es = MyTipoOperacion
                .referencia_cuenta_comercial = "G0000000"
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

            If CapturarEncabezadoGuia() = True Then
                UC_ToolBar.btnAceptar_Visible = False
                Call GrabarTrasladoExterno()
            End If
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim PeriodoTrabajo = MyUsuario.ejercicio & MyUsuario.mes.ToString("00")
        Dim PeriodoComprobante = txtEjercicio.Text & txtMes.Text

        Try
            If txtOperacion.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                UC_ToolBar.btnGrabar_Visible = False
                If PeriodoTrabajo <> PeriodoComprobante Then
                    Resp = MsgBox("Para anular el comprobante debe cambiar el periodo de trabajo al mes de " &
                                  UCase(EvalMes(PeriodoComprobante.Substring(4, 2), "L")) & " del " &
                                  PeriodoComprobante.Substring(0, 4), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                    Call LimpiarFormulario()

                ElseIf MyGuia.estado_traslado_interno = "R" Then
                    Resp = MsgBox("La guía ya fué recepcionada por el destinatario, no se puede anular.", MsgBoxStyle.Critical, "PROCESO DENEGADO")
                    Call LimpiarFormulario()

                Else
                    Resp = MsgBox("Confirmar proceso de anulación de la Guia de Traslado.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR GUIA")
                    If Resp = 1 Then
                        If dalOperacionAlmacen.AnularTrasladoExterno(MyOperacion, MyOperacionDetalles, MyOperacionDetalleSeries, MyGuia) = True Then
                            Resp = MsgBox("La Operación se anuló con éxito.", MsgBoxStyle.Information, "ANULAR GUIA")
                            Call LimpiarFormulario()
                        Else
                            ckbIndicaAnulado.Checked = False
                            UC_ToolBar.btnGrabar_Visible = True
                            UC_ToolBar.btnEditar_Focus = True
                        End If
                    Else
                        ckbIndicaAnulado.Checked = False
                        UC_ToolBar.btnGrabar_Visible = True
                        UC_ToolBar.btnEditar_Focus = True
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
        MyGuia = New entGuia
        Dim MyForm As New frmGuiaRemitenteLista(MyGuia, txtEjercicio.Text, txtMes.Text, "TODOS", "G8", "TODOS")
        MyForm.ShowDialog()
        If Not MyGuia.guia Is Nothing Then Call PoblarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnSUNAT_Click() Handles UC_ToolBar.TB_btnSUNAT_Click
        Dim Nombre_Archivo As String = Nothing
        Dim CodigoError As String = ""
        Try
            If txtGuia.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = False Then
                MyGuia.tipo_operacion_nombre = MotivoTrasladoDescripcion
                If dalXML.CrearGuia(MyGuia) = True Then
                    If dalXML.FirmarGuia(MyGuia) = True Then
                        If Servidor = "Desarrollo" Then
                            If dalGuia.ActualizarEstadoEnvio(MyUsuario.empresa, MyGuia.guia, "A") = True Then
                                Resp = MsgBox("El documento ha sido creado satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                Call LimpiarFormulario()
                            End If
                        Else
                            Dim strRetorno As String = dalXML.EnviarGuia(Nombre_Archivo, MyGuia)
                            If strRetorno = "" Then
                                Resp = MsgBox("No existe archivo ZIP a enviar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                            Else
                                If strRetorno.Substring(0, 5) = "ERROR" Then
                                    CodigoError = Strings.Right(strRetorno, 4)
                                    If CodigoError = "4000" Then
                                        Resp = MsgBox("El documento ya fue presentado anteriormente." & vbCrLf &
                                                      MyGuia.fecha_envio.ToLongDateString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                    Else
                                        Resp = MsgBox(strRetorno, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                    End If
                                Else
                                    If dalGuia.ActualizarEstadoEnvio(MyUsuario.empresa, MyGuia.guia, "A") = True Then
                                        Resp = MsgBox(strRetorno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ENVIAR GUIA A SUNAT")
                                    End If
                                End If
                                Call LimpiarFormulario()
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

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtGuia.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmGuiaRemitenteImprimir(MyGuia, MotivoTrasladoDescripcion)
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
