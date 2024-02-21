Public Class frmGuiaPorVenta

    Private MyCuentaComercial As entCuentaComercial
    Private MyVenta As entVenta
    Private MyVentaDetalle As entVentaProducto
    Private MyGuiaRemitente As entGuiaRemitente
    Private MyGuiaRemitenteDetalle As entGuiaRemitenteDetalle
    Private MyProducto As entProducto
    Private MyStock As Decimal
    Private MyLotesStock As dsStockAlmacen.STOCK_X_ALMACENDataTable

    Private MyAnexo As entCONCAR_Anexo
    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable

    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String

    Private MyAccion As String = "NUEVO"
    Private MySender As String
    Private m_Tipo_Guia As String

    Private FechaUltimoComprobante As Date

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal TipoGuia As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_Tipo_Guia = TipoGuia
    End Sub

    Private Sub frmGuiaPorVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmGuiaPorVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ActualizarListaEmpresa(cmbAlmacenOrigen, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbAlmacenDestino, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbCentroDistribucion, "COM_CENTRO_DISTRIBUCION")

        ActualizarListaEmpresa(cmbTransportista, "STD_TRANSPORTISTA")
        ActualizarListaEmpresa(cmbUnidadTransporte, "STD_UNIDAD_TRANSPORTE")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)

        cmbProductos.DataSource = dalProducto.BuscarProducto("T")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

    End Sub

    Private Sub txtComprobanteVentaNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComprobanteVentaNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            If sender.text.ToString.Length > 0 Then sender.text = Strings.Right(CUO_Nulo & sender.text, 10)
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub ValidarSerieNumero(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteSerie.Validated, txtComprobanteNumero.Validated, txtComprobanteVentaSerie.Validated, txtComprobanteVentaNumero.Validated
        Dim MyNumero As String = sender.text
        If sender.text.ToString.Length > 0 Then
            If IsNumeric(sender.text) Then
                sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                If txtGuia.Text = Nothing Then
                    If sender.name = "txtComprobanteSerie" Then Call PoblarCorrelativo()
                End If
                If sender.name = "txtComprobanteVentaSerie" Then
                    If txtComprobanteVentaNumero.Text.ToString.Length > 0 Then
                        Call ValidarDocumento()
                    Else
                        txtComprobanteVentaNumero.Focus()
                    End If
                End If
            Else
                If sender.name = "txtComprobanteSerie" Then
                    sender.text = "0001"
                    If txtGuia.Text = Nothing Then Call PoblarCorrelativo()
                ElseIf sender.name = "txtComprobanteNumero" Then
                    If txtGuia.Text = Nothing Then Call PoblarCorrelativo()
                ElseIf sender.name = "txtComprobanteVentaSerie" Then
                    sender.text = "0001" : txtComprobanteVentaNumero.Focus()
                Else
                    sender.text = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub cmbComprobanteVentaTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComprobanteVentaTipo.SelectedIndexChanged
        If cmbComprobanteVentaTipo.SelectedIndex <> -1 Then txtComprobanteVentaNumero.Focus()
    End Sub

    Private Sub txtDestinatarioDomicilio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestinatarioDomicilio.Validated
        UC_ToolBar.btnGrabar_Focus = True
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyVenta = New entVenta
        MyVentaDetalle = New entVentaProducto
        MyGuiaRemitente = New entGuiaRemitente
        MyGuiaRemitenteDetalle = New entGuiaRemitenteDetalle
        MyProducto = New entProducto

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.0000"
                    Case Is = "C" : ctrl.text = "0.000"
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = Nothing
                End Select
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
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
                        ElseIf TypeOf TPctrl Is CheckBox Then
                            TPctrl.Checked = False
                        ElseIf TypeOf TPctrl Is ComboBox Then
                            TPctrl.SelectedIndex = -1
                        End If
                    Next
                Next
            End If
        Next

        If gvGuiaLineas.Rows.Count <> 0 Then
            gvGuiaLineas.Rows.Clear()
        End If

        Call PonerValoresDefault()
        Call ActivarDetalles(False)
        Call ActivarCabecera(True)

        txtComprobanteVentaNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()

        EnableTextBox(txtComprobanteVentaNumero, True)
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        cmbAlmacenOrigen.SelectedValue = "000"
        cmbAlmacenDestino.SelectedValue = "000"

        cmbUnidadTransporte.SelectedValue = "001"
        cmbTransportista.SelectedValue = "001"

        cmbComprobanteVentaTipo.SelectedIndex = 0

        cmbProductos.SelectedIndex = -1
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        cmbCentroDistribucion.SelectedValue = "LIM"
        txtComprobanteVentaSerie.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteVentaSerie.MaxLength)
        txtComprobanteSerie.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteSerie.MaxLength)
        txtComprobanteNumero.Text = Strings.Right(CUO_Nulo, txtComprobanteNumero.MaxLength)
        Call PoblarCorrelativo()
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        cmbComprobanteVentaTipo.Enabled = IndicaActivo
        txtComprobanteVentaSerie.Enabled = IndicaActivo
        txtComprobanteVentaNumero.Enabled = IndicaActivo
        'cmbAlmacenOrigen.Enabled = IndicaActivo
        'cmbAlmacenDestino.Enabled = IndicaActivo
        txtComprobanteSerie.Enabled = IndicaActivo
        txtComprobanteNumero.Enabled = IndicaActivo
        'txtComprobanteFecha.Enabled = IndicaActivo
        'txtComprobanteFechaTraslado.Enabled = IndicaActivo

        txtComprobanteVentaSerie.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteVentaNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteSerie.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        'txtComprobanteFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        'txtComprobanteFechaTraslado.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)

        txtComprobanteVentaSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteVentaNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtComprobanteFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtComprobanteFechaTraslado.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)

        If IndicaActivo = True Then txtComprobanteVentaNumero.Focus()
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        txtProducto.Enabled = IndicaActivo
        txtCantidad.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo : btnDescartar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3) : btnDescartar.ImageIndex = IIf(IndicaActivo = True, 0, 2)
        cmbProductos.SelectedIndex = -1
        gvGuiaLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub PoblarCorrelativo()
        MyCorrelativo = dalGuia.ObtenerCorrelativo(txtComprobanteSerie.Text)
        If MyCorrelativo.Rows.Count = 0 Then
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = CDate("01/" & MyAsientoMes & "/" & MyAsientoEjercicio)
        Else
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = MyCorrelativo(0).COMPROBANTE_FECHA
        End If
        txtComprobanteFecha.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)
        txtComprobanteFechaTraslado.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)
    End Sub

    Private Sub ValidarDocumento()
        Dim MyDetalles As dsVentas.VENTAS_DETALLEDataTable
        If cmbComprobanteVentaTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = IIf(cmbComprobanteVentaTipo.Text.Substring(0, 1) = "B", "03", "01")
            Dim MyDocumentoSerie As String = txtComprobanteVentaSerie.Text.Trim
            Dim MyDocumentoNumero As String = txtComprobanteVentaNumero.Text.Trim
            Dim MyCliente As String = ""
            MyVenta = New entVenta
            Continuar = True
            If String.IsNullOrEmpty(MyDocumentoSerie) Then
                txtComprobanteVentaSerie.Focus()
            Else
                MyCuentaComercial = New entCuentaComercial
                If String.IsNullOrEmpty(MyDocumentoNumero) Then
                    Dim MyForm As New frmFacturacionProductosLista(MyVenta, txtEjercicio.Text, txtMes.Text, "TODOS", cmbComprobanteVentaTipo.Text)
                    MyForm.ShowDialog()
                    If MyVenta.venta Is Nothing Then
                        Continuar = False
                    Else
                        MyDocumentoSerie = MyVenta.comprobante_serie
                        MyDocumentoNumero = MyVenta.comprobante_numero
                    End If
                End If

                If Continuar = True Then
                    Call LimpiarFormulario()
                    MyVenta = dalVenta.Obtener(MyDocumentoTipo, MyDocumentoSerie, MyDocumentoNumero)
                    If MyVenta.venta Is Nothing Then
                        Resp = MsgBox("La " & cmbComprobanteVentaTipo.Text & " NO EXISTE.", MsgBoxStyle.Information, "COMPROBANTE INCORRECTO")
                        txtComprobanteVentaNumero.Focus()
                    Else
                        With MyVenta
                            MyCuentaComercial = dalCuentaComercial.Obtener(.cuenta_comercial)
                            txtCuentaComercial.Text = .cuenta_comercial
                            txtVenta.Text = .venta
                            txtComprobanteVentaNumero.Text = .comprobante_numero
                            txtComprobanteVentaFecha.Text = .comprobante_fecha
                            txtDestinatarioNombre.Text = MyCuentaComercial.razon_social
                            txtDestinatarioDomicilio.Text = MyCuentaComercial.domicilio
                            cmbAlmacenOrigen.SelectedValue = .almacen
                            cmbAlmacenDestino.SelectedValue = .almacen
                            cmbCentroDistribucion.SelectedValue = .centro_distribucion

                            MyDetalles = dalVenta.ObtenerDetalles(txtVenta.Text)
                            If MyDetalles.Rows.Count <> 0 Then
                                For Each row As dsVentas.VENTAS_DETALLERow In MyDetalles.Rows
                                    gvGuiaLineas.Rows.Add(row.EMPRESA, row.VENTA, row.LINEA, row.PRODUCTO, row.DESCRIPCION_AMPLIADA, row.NUMERO_LOTE, row.CANTIDAD, row.INDICA_COMPUESTO)
                                Next
                            End If
                            gvGuiaLineas.ClearSelection()
                            txtComprobanteNumero.Focus()
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub ValidarProducto()
    '    Dim MyCodigo As String = ""
    '    Dim MyPrecio As Decimal = 0
    '    Dim MyCantidad As Decimal = 0

    '    MyProducto = New entProducto
    '    MyCodigo = txtProducto.Text.Trim
    '    If String.IsNullOrEmpty(MyCodigo) Then
    '        Dim MyForm As New frmProductoLista(MyProducto, "A")
    '        MyForm.ShowDialog()
    '    Else
    '        MyProducto = dalProducto.Obtener(MyCodigo)
    '    End If

    '    If Not MyProducto.producto Is Nothing Then
    '        MyPrecio = BuscarPrecioUnitario()
    '        txtProducto.Text = MyProducto.producto
    '        cmbProductos.SelectedValue = MyProducto.producto
    '        txtIndicaCompuesto.Text = MyProducto.indica_compuesto
    '        txtIndicaValidaStock.Text = MyProducto.indica_valida_stock
    '        txtCantidad.Focus()
    '    Else
    '        cmbProductos.SelectedIndex = -1
    '        txtProducto.Text = Nothing
    '        txtIndicaCompuesto.Text = Nothing
    '        txtCantidad.Text = "0.00"
    '        txtProducto.Focus()
    '    End If
    '    'If m_Tipo_Venta = "B2" Then ' Transferencia Gratuita
    '    '    txtPrecioUnitario.Text = "0.00"
    '    'Else
    '    txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)
    '    'End If
    '    Call ActualizarValores()
    'End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

#End Region

#Region "Botones"

    Private Sub btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Dim MyForm As New frmStockAlmacenImprimir(txtEjercicio.Text, txtMes.Text, cmbAlmacenOrigen.SelectedValue, cmbAlmacenOrigen.Text)
        MyForm.ShowDialog()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        With MyGuiaRemitente
            .empresa = MyUsuario.empresa
            .guia_remitente = txtGuia.Text
            .ejercicio = MyAsientoEjercicio
            .mes = MyAsientoMes
            .almacen_origen = cmbAlmacenOrigen.SelectedValue
            .almacen_destino = cmbAlmacenDestino.SelectedValue
            .tipo_guia = "G1"
            .centro_distribucion = cmbCentroDistribucion.SelectedValue
            .cuenta_comercial = txtCuentaComercial.Text
            .comprobante_tipo = "09"
            .comprobante_serie = txtComprobanteSerie.Text
            .comprobante_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then .comprobante_fecha = txtComprobanteFecha.Text
            If txtComprobanteFechaTraslado.Text.Length <> 0 Then .fecha_inicio_traslado = txtComprobanteFechaTraslado.Text
            .destinatario_nombre = txtDestinatarioNombre.Text
            .destinatario_domicilio = txtDestinatarioDomicilio.Text
            .transportista = cmbTransportista.SelectedValue
            .unidad_transporte = cmbUnidadTransporte.SelectedValue
            .motivo_traslado = "01"
            .venta = txtVenta.Text
            .comentario = txtComentario.Text
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
            .usuario_registro = MyUsuario.usuario
        End With

        Try
            If txtGuia.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                If dalGuia.Anular(MyGuiaRemitente) = True Then
                    Call LimpiarFormulario()
                    txtComprobanteVentaNumero.Focus()
                Else
                    ckbIndicaAnulado.Checked = False
                    txtComprobanteNumero.Focus()
                End If
            Else
                MyVenta = dalVenta.Grabar(MyVenta)
                txtGuia.Text = MyGuiaRemitente.guia_remitente

                Resp = MsgBox("La Guia se grabó con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                Call ActivarCabecera(False)
                Call ActivarDetalles(True)
                txtComprobanteVentaNumero.Focus()
            End If
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

    'Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
    '    Dim MyCantidadControl As Integer = 0
    '    MyVenta = New entVenta
    '    MyAccion = "MODIFICAR"
    '    Dim MyForm As New frmFacturacionProductosLista(MyVenta, txtEjercicio.Text, txtMes.Text, "TODOS", m_Tipo_Venta)
    '    MyForm.ShowDialog()
    '    If Not MyVenta.venta Is Nothing Then
    '        Call PoblarFormulario()
    '    End If
    'End Sub

    'Private Sub btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
    '    If txtVenta.Text.Trim <> "" Then
    '        MyAccion = "IMPRIMIR"
    '        MyAnexo = New entCONCAR_Anexo
    '        MyAnexo = dalCONCAR_Anexo.ObtenerCliente(txtDocumentoNumero.Text)
    '        MyPrintDocument = New Printing.PrintDocument

    '        AddHandler MyPrintDocument.PrintPage, AddressOf Print_PrintPage

    '        MyPrintPreview.Document = MyPrintDocument
    '        MyLabel.Text = m_Titulo_Comprobante

    '        MyFactura = New entFactura
    '        With MyFactura
    '            .Venta = txtVenta.Text
    '            .Documento_Serie = txtComprobanteSerie.Text
    '            .Documento_Numero = Strings.Right(txtComprobanteNumero.Text, 7)
    '            .Fecha_Emision = txtComprobanteFecha.Text
    '            .Fecha_Vencimiento = txtComprobanteVencimiento.Text
    '            .Razon_Social = txtRazonSocial.Text
    '            .RUC = txtDocumentoNumero.Text
    '            .Domicilio_01 = MyAnexo.amemo
    '            '.Domicilio_02 = txtDomicilio2.Text
    '            .Condicion_Pago = cmbCondicionPago.SelectedValue
    '            .Tipo_Moneda = cmbTipoMoneda.SelectedValue
    '            .Valor_Venta = CDec(txtBaseImponibleGravadaOrigen.Text) + CDec(txtImporteExoneradoOrigen.Text) + CDec(txtImporteInafectoOrigen.Text)
    '            .IGV = CDec(txtIGVOrigen.Text)
    '            .Precio_Venta = CDec(txtImporteTotalOrigen.Text)
    '            .Precio_Venta_Texto = ConvertNumText(CDec(txtImporteTotalOrigen.Text), cmbTipoMoneda.SelectedValue)

    '            MyTextboxSerie.Text = .Documento_Serie
    '            MyTextboxNumero.Text = .Documento_Numero
    '            MyTextboxFecha.Text = .Fecha_Emision

    '        End With

    '        ControlarCorrelativo = IIf(MyFactura.Documento_Serie <> "000", False, True)
    '        Try
    '            'MyPrintPreview.MdiParent = frmMenu
    '            'MyPrintPreview.Show()
    '            'Me.Select()
    '            MyPrintPreview.ShowDialog()

    '        Catch ex As BusinessException
    '            Resp = MsgBox(ex.Message)
    '        Catch ex As Exception
    '            'Resp = MsgBox("ERROR: " & ex.Message.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Resp = MsgBox("ERROR: " & ex.Message.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "IMPRIMIR COMPROBANTE")
    '        End Try

    '        'If AsignarCorrelativo Then
    '        '    MyVenta.comprobante_fecha = MyFactura.Fecha_Emision
    '        '    MyCorrelativo = dalVenta.ActualizarCorrelativo(MyVenta)
    '        '    If MyCorrelativo.Count > 0 Then
    '        '        Resp = MsgBox("Se asignó el correlativo SERIE: " & MyCorrelativo(0).COMPROBANTE_SERIE & " NUMERO: " & MyCorrelativo(0).COMPROBANTE_NUMERO, MessageBoxButtons.OK, "FACTURA")
    '        '        Call InicializarFormulario()
    '        '    End If
    '        'End If


    '    End If
    'End Sub

    'Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
    '    Dim ImporteSoles As Decimal
    '    Dim MyProductoDescripcion As String
    '    MyFacturaDetalles = dalVenta.ObtenerVentaProducto(MyFactura.Venta)

    '    Try
    '        'Definir la fuente
    '        Dim prFont As New Font("Courier New", 9, FontStyle.Regular)
    '        Dim prFontB As New Font("Courier New", 9, FontStyle.Bold)
    '        Dim prFontT As New Font("Arial Narrow", 9, FontStyle.Regular)
    '        Dim prFontTB As New Font("Arial Narrow", 9, FontStyle.Bold)
    '        If m_Titulo_Comprobante = "BOLETA" Then
    '            e.Graphics.DrawString(MyFactura.Documento_Serie & "-" & MyFactura.Documento_Numero, prFont, Brushes.Black, 540, 207)
    '            e.Graphics.DrawString(MyFactura.Razon_Social, prFontB, Brushes.Black, 85, 230)
    '            e.Graphics.DrawString(MyFactura.Domicilio_01, prFont, Brushes.Black, 85, 260)
    '            e.Graphics.DrawString(MyFactura.RUC, prFontB, Brushes.Black, 105, 295)
    '            e.Graphics.DrawString(MyFactura.Fecha_Emision, prFont, Brushes.Black, 600, 295)

    '            NFil = 358
    '            'imprimimos Detalles
    '            For NEle = 0 To MyFacturaDetalles.Count - 1
    '                MyProductoDescripcion = dalProducto.ObtenerDescripcion(MyFacturaDetalles(NEle).PRODUCTO)
    '                e.Graphics.DrawString(Strings.Right(Space(4) & EvalDato(MyFacturaDetalles(NEle).CANTIDAD, "E").ToString, 4), prFont, Brushes.Black, 0, NFil)
    '                'e.Graphics.DrawString(MyProductoDescripcion, prFont, Brushes.Black, 80, NFil)
    '                e.Graphics.DrawString(MyProductoDescripcion, prFontT, Brushes.Black, 75, NFil)
    '                e.Graphics.DrawString(Strings.Right(Space(10) & EvalDato(MyFacturaDetalles(NEle).PRECIO_UNITARIO, "D").ToString, 10), prFont, Brushes.Black, 540, NFil)
    '                e.Graphics.DrawString(Strings.Right(Space(12) & EvalDato(MyFacturaDetalles(NEle).IMPORTE_TOTAL_ME, "D").ToString, 12), prFont, Brushes.Black, 640, NFil)
    '                NFil = NFil + 20
    '            Next NEle

    '            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

    '            e.Graphics.DrawString(ConvertNumText(CDbl(txtImporteTotalOrigen.Text), MyFactura.Tipo_Moneda), prFontB, Brushes.Black, 65, 690)

    '            e.Graphics.DrawString(IIf(cmbTipoMoneda.SelectedValue = "2", "U$.", "S/."), prFontB, Brushes.Black, 635, 730)
    '            e.Graphics.DrawString(Strings.Right(Space(12) & txtImporteTotalOrigen.Text, 12), prFontB, Brushes.Black, 640, 730)
    '        Else
    '            e.Graphics.DrawString(MyFactura.Documento_Serie & "-" & MyFactura.Documento_Numero, prFont, Brushes.Black, 540, 175)
    '            e.Graphics.DrawString(MyFactura.Fecha_Emision.Day, prFont, Brushes.Black, 45, 185)
    '            e.Graphics.DrawString(EvalMes(MyFactura.Fecha_Emision.Month, "L").ToUpper, prFont, Brushes.Black, 100, 185)
    '            e.Graphics.DrawString(MyFactura.Fecha_Emision.Year.ToString.Substring(2, 2), prFont, Brushes.Black, 285, 185)
    '            e.Graphics.DrawString(MyFactura.Razon_Social, prFontB, Brushes.Black, 80, 215)
    '            e.Graphics.DrawString(MyFactura.RUC, prFontB, Brushes.Black, 600, 215)
    '            e.Graphics.DrawString(MyFactura.Domicilio_01, prFont, Brushes.Black, 80, 245)

    '            NFil = 333
    '            'imprimimos Detalles
    '            For NEle = 0 To MyFacturaDetalles.Count - 1
    '                MyProductoDescripcion = dalProducto.ObtenerDescripcion(MyFacturaDetalles(NEle).PRODUCTO)
    '                e.Graphics.DrawString(Strings.Right(Space(4) & EvalDato(MyFacturaDetalles(NEle).CANTIDAD, "E").ToString, 4), prFont, Brushes.Black, 50, NFil)
    '                'e.Graphics.DrawString(MyProductoDescripcion, prFont, Brushes.Black, 90, NFil)
    '                e.Graphics.DrawString(MyProductoDescripcion, prFontT, Brushes.Black, 110, NFil)
    '                e.Graphics.DrawString(Strings.Right(Space(10) & EvalDato(MyFacturaDetalles(NEle).PRECIO_UNITARIO, "D").ToString, 10), prFont, Brushes.Black, 550, NFil)
    '                e.Graphics.DrawString(Strings.Right(Space(12) & EvalDato(MyFacturaDetalles(NEle).IMPORTE_TOTAL_ME, "D").ToString, 12), prFont, Brushes.Black, 630, NFil)
    '                NFil = NFil + 20
    '            Next NEle

    '            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

    '            e.Graphics.DrawString(ConvertNumText(CDbl(txtImporteTotalOrigen.Text), MyFactura.Tipo_Moneda), prFontB, Brushes.Black, 90, 665)

    '            e.Graphics.DrawString(Strings.Right(Space(12) & txtBaseImponibleGravadaOrigen.Text, 12), prFontB, Brushes.Black, 630, 695)
    '            e.Graphics.DrawString(EvalDato(MyIGV, "E") & "%", prFontB, Brushes.Black, 600, 725)
    '            e.Graphics.DrawString(Strings.Right(Space(12) & txtIGVOrigen.Text, 12), prFontB, Brushes.Black, 630, 725)
    '            e.Graphics.DrawString(IIf(cmbTipoMoneda.SelectedValue = "2", "U$.", "S/."), prFontB, Brushes.Black, 600, 760)
    '            e.Graphics.DrawString(Strings.Right(Space(12) & txtImporteTotalOrigen.Text, 12), prFontB, Brushes.Black, 630, 760)
    '        End If

    '        'indicamos que hemos llegado al final de la pagina
    '        e.HasMorePages = False

    '    Catch ex As BusinessException
    '        Resp = MsgBox(ex.Message)
    '    Catch ex As Exception
    '        Resp = MsgBox("ERROR: " & ex.Message.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
    '    If txtProducto.TextLength <> 0 And CDec(txtCantidad.Text) <> 0 Then
    '        If txtVenta.Text <> Nothing Then
    '            With MyVentaDetalle
    '                .empresa = MyUsuario.empresa
    '                .venta = txtVenta.Text.Trim
    '                .linea = txtLinea.Text
    '                .tipo_cambio = CDec(txtTipoCambio.Text)
    '                .tipo_moneda = cmbTipoMoneda.SelectedValue
    '                .producto = txtProducto.Text
    '                .cantidad = CDec(txtCantidad.Text)
    '                .precio_unitario = CDec(txtPrecioUnitario.Text)
    '                .importe_total_me = CDec(txtPrecioTotal.Text)
    '                .indica_compuesto = txtIndicaCompuesto.Text
    '                .almacen = cmbAlmacen.SelectedValue
    '                .descripcion_ampliada = cmbProductos.Text
    '                .ejercicio_venta = txtEjercicio.Text
    '                .mes_venta = txtMes.Text
    '                .indica_valida_stock = txtIndicaValidaStock.Text
    '            End With

    '            Try
    '                If dalVenta.Grabar(MyVentaDetalle, gvVentaLineas) = True Then
    '                    Call CalcularTotales()
    '                End If
    '            Catch ex As BusinessException
    '                Resp = MsgBox(ex.Message)
    '            Catch ex As Exception
    '                Resp = MsgBox("ERROR: " & ex.Message.ToString)
    '            End Try
    '        End If
    '    End If
    'End Sub

    'Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
    '    If txtProducto.TextLength <> 0 And txtLinea.TextLength <> 0 Then
    '        With MyVentaDetalle
    '            .empresa = MyUsuario.empresa
    '            .venta = txtVenta.Text.Trim
    '            .linea = txtLinea.Text
    '            .producto = txtProducto.Text
    '            .tipo_cambio = CDec(txtTipoCambio.Text)
    '            .tipo_moneda = cmbTipoMoneda.SelectedValue
    '            .almacen = cmbAlmacen.SelectedValue
    '            .indica_valida_stock = txtIndicaValidaStock.Text
    '        End With

    '        Try
    '            If dalVenta.Descartar(MyVentaDetalle, gvVentaLineas) = True Then
    '                Call CalcularTotales()
    '            End If
    '        Catch ex As BusinessException
    '            Resp = MsgBox(ex.Message)
    '        Catch ex As Exception
    '            Resp = MsgBox("ERROR: " & ex.Message.ToString)
    '        End Try
    '    End If
    'End Sub

#End Region



End Class
