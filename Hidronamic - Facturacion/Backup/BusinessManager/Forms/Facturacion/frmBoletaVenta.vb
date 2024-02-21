﻿Public Class frmBoletaVenta

    Private MyCuentaComercial As entCuentaComercial
    Private MiAnexoVendedor As entListaElemento
    Private MyVenta As entVenta
    Private MyVentaDetalle As entVentaProducto
    Private MyFactura As entFactura
    Private MyFacturaDetalles As dsVentas.VENTAS_PRODataTable
    Private MyProducto As entProducto
    Private MyStock As dsStockAlmacen.STOCK_X_PRODUCTODataTable

    Private MyListaPrecio As dsListaPrecios.LISTA_PRECIOS_DETDataTable
    Private MyDetallesPedido As dsOrdenPedido.DETALLES_PEDIDODataTable

    Private MyAnexo As entCONCAR_Anexo
    Private MyListaElemento As entListaElemento
    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable
    Private MyAsientoTipo As String = "05"
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String
    Private MyTipoCambio As Decimal

    Private MyAccion As String = "NUEVO"
    Private MySender As String

    Private m_Tipo_Boleta As String
    Private m_Tipo_Venta As String
    Private m_Exige_Orden As Boolean
    Private m_Titulo_Comprobante As String

    Private ExisteVendedor As Boolean

    Private FechaUltimoComprobante As Date

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal Tipo As String, ByVal ExigeOrden As Boolean, ByVal TituloComprobante As String, ByVal TipoVenta As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_Tipo_Boleta = Tipo
        m_Tipo_Venta = TipoVenta
        m_Exige_Orden = ExigeOrden
        m_Titulo_Comprobante = TituloComprobante
        'Me.lblComprobante.Text = TituloComprobante & " DE VENTA"
        Call ExigirOrdenPedido(m_Exige_Orden)
    End Sub

    Private Sub frmBoletaVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmBoletaVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ActualizarLista(cmbListaPrecios)
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbCondicionPago, "COM_FORMA_PAGO")
        ActualizarListaEmpresa(cmbCentroDistribucion, "COM_CENTRO_DISTRIBUCION")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, "01")
        ActualizarTabla("_TIPO_COMPROBANTE_PAGO", cmbComprobanteTipo, "03")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        cmbProductos.DataSource = dalProducto.BuscarProductoActivos("")

        Call LimpiarFormulario()

        If MyTipoCambio = 0 Then
            Resp = MsgBox("Para continuar debe registrar el TIPO DE CAMBIO del " & EvalDato(MyAsientoFecha, "F") & ".", MsgBoxStyle.Information, Me.Text)
            UC_ToolBar.CambiarEstados(3, 3, False)
            Call EnableTextBox(txtDocumentoNumero, False)
        Else
            UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
        End If

        Select Case m_Tipo_Venta
            Case Is = "B1" : Me.Text = "BOLETA POR ORDEN DE PEDIDO"
            Case Is = "B2" : Me.Text = "BOLETA POR TRANSFERENCIA GRATUITA"
            Case Is = "B3" : Me.Text = "BOLETA POR VENTA MOSTRADOR"
            Case Is = "F1" : Me.Text = "FACTURA POR ORDEN DE PEDIDO"
            Case Is = "F2" : Me.Text = "FACTURA POR VENTA MOSTRADOR"
        End Select

        lblComprobante.Text = Me.Text

        UC_ToolBar.btnBorrar_Visible = False
        'UC_ToolBar.btnEditar_Visible = False

    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            txtComprobanteNombre.Text = sender.Items(sender.SelectedIndex)(3).ToString
        Else
            txtComprobanteNombre.Text = Nothing
        End If
    End Sub

    Private Sub ValidarFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated
        Dim MyFecha As Date
        Dim MyFechaAño As String
        Dim MyFechaMes As String
        Dim MyFechaDia As String

        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtComprobanteFecha" Then
                    MyFecha = CDate(txtComprobanteFecha.Text)
                    If MyAsientoFecha.Year * 100 + MyAsientoFecha.Month <> MyFecha.Year * 100 + MyFecha.Month Then
                        Resp = MsgBox("La fecha debe estar dentro del periodo.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                        Call ReiniciarFecha()
                    Else
                        If MyFecha < FechaUltimoComprobante Then
                            Resp = MsgBox("La fecha debe ser igual o mayor que el día " & FechaUltimoComprobante.Day.ToString, MsgBoxStyle.Information, "FECHA INCORRECTA")
                            Call ReiniciarFecha()
                        Else
                            MyFechaAño = MyFecha.Year.ToString
                            MyFechaMes = Strings.Right("00" & MyFecha.Month.ToString, 2)
                            MyFechaDia = Strings.Right("00" & MyFecha.Day.ToString, 2)

                            MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyFechaAño, MyFechaMes, MyFechaDia, "VENTA")
                            If MyTipoCambio = 0 Then
                                Resp = MsgBox("No existe TIPO DE CAMBIO del " & EvalDato(MyFecha, "F") & ".", MsgBoxStyle.Information, "FALTA TIPO DE CAMBIO")
                                Call ReiniciarFecha()
                            Else
                                txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
                                txtComprobanteVencimiento.Text = sender.text
                                cmbCondicionPago.Focus()
                            End If
                        End If
                    End If
                End If
            Else
                If sender.name = "txtComprobanteFecha" Then Call ReiniciarFecha()
            End If
        End If
    End Sub

    Private Sub ValidarImporte(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.Validated, txtPrecioUnitario.Validated, txtPrecioTotal.Validated
        If sender.text.ToString.Length <> 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            Call ActualizarValores()
        End If
    End Sub

    Private Sub txtComentario_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComentario.Validated
        UC_ToolBar.btnGrabar_Focus = True
    End Sub

    Private Sub ValidarSerieNumero(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteSerie.Validated, txtComprobanteNumero.Validated
        Dim MyNumero As String = sender.text
        If sender.text.ToString.Length > 0 Then
            If IsNumeric(sender.text) Then
                sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                If txtVenta.Text = Nothing Then
                    If sender.name = "txtComprobanteSerie" Then Call PoblarCorrelativo()
                End If
            Else
                If sender.name = "txtComprobanteSerie" Then
                    sender.text = "0001"
                    If txtVenta.Text = Nothing Then Call PoblarCorrelativo()
                ElseIf sender.name = "txtComprobanteNumero" Then
                    If txtVenta.Text = Nothing Then Call PoblarCorrelativo()
                Else
                    sender.text = Nothing
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

    Private Sub txtVendedorCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendedorCodigo.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarVendedor()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto()
        End If
    End Sub

    Private Sub cmbListaPrecios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbListaPrecios.SelectedIndexChanged
        If cmbListaPrecios.SelectedIndex <> -1 Then
            MyListaPrecio = dalListaPrecio.ObtenerListaPrecios(cmbListaPrecios.SelectedValue)
        End If
    End Sub

    Private Sub gvVentaLineas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVentaLineas.CellDoubleClick
        Dim MyIndex As Integer
        If Not sender.CurrentRow Is Nothing Then
            MyIndex = sender.CurrentRow.Index
            With sender.Rows(MyIndex)
                txtEditado.Text = "E"
                txtProducto.Text = .Cells("PRODUCTO").Value
                cmbProductos.Text = .Cells("DESCRIPCION_AMPLIADA").Value
                txtCantidad.Text = EvalDato(.Cells("CANTIDAD").Value, txtCantidad.Tag)
                txtPrecioUnitario.Text = EvalDato(.Cells("PRECIO_UNITARIO_ME").Value, txtPrecioUnitario.Tag)
                txtPrecioTotal.Text = EvalDato(.Cells("IMPORTE_TOTAL_ME").Value, txtPrecioTotal.Tag)
                txtLinea.Text = .Cells("LINEA").Value
                txtIndicaCompuesto.Text = .Cells("INDICA_COMPUESTO").Value
                txtIndicaValidaStock.Text = .Cells("INDICA_VALIDA_STOCK").Value
            End With
            txtCantidad.Focus()
        End If
    End Sub

#Region "Funciones"

    Private Sub ExigirOrdenPedido(ByVal ActivarOrdenPedido As Boolean)
        Call EnableComboBox(cmbCentroDistribucion, Not ActivarOrdenPedido)
        Call EnableComboBox(cmbDocumentoTipo, ActivarOrdenPedido)
        Call EnableTextBox(txtDocumentoNumero, Not ActivarOrdenPedido)
        Call EnableTextBox(txtVendedorCodigo, Not ActivarOrdenPedido)
        Call EnableComboBox(cmbTipoMoneda, ActivarOrdenPedido)
        Call EnableComboBox(cmbListaPrecios, ActivarOrdenPedido)
    End Sub

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta
        MyVentaDetalle = New entVentaProducto

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

        If gvVentaLineas.Rows.Count <> 0 Then
            gvVentaLineas.Rows.Clear()
        End If

        Call PonerValoresDefault()
        Call ActivarDetalles(False)
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")

        EnableTextBox(txtDocumentoNumero, True)
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        cmbAlmacen.SelectedValue = "000"
        cmbComprobanteTipo.SelectedValue = "03"
        If m_Titulo_Comprobante = "BOLETA" Then
            cmbDocumentoTipo.SelectedValue = "01"
            cmbComprobanteTipo.SelectedValue = "03"
        Else
            cmbDocumentoTipo.SelectedValue = "06"
            cmbComprobanteTipo.SelectedValue = "01"
        End If
        cmbTipoMoneda.SelectedValue = "2"
        cmbListaPrecios.SelectedValue = "CONSUMIDOR"
        cmbCondicionPago.SelectedValue = "00"
        txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        cmbProductos.SelectedIndex = -1
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteVencimiento.Text = EvalDato(Now.Date, "F")
        cmbCentroDistribucion.SelectedValue = "LIM"
        txtComprobanteSerie.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteSerie.MaxLength)
        txtComprobanteNumero.Text = Strings.Right(CUO_Nulo, txtComprobanteNumero.MaxLength)
        Call PoblarCorrelativo()
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        cmbAlmacen.Enabled = IndicaActivo
        'txtTipoCambio.Enabled = IndicaActivo
        txtDocumentoNumero.Enabled = IndicaActivo
        txtVendedorCodigo.Enabled = IndicaActivo
        txtComprobanteSerie.Enabled = IndicaActivo
        txtComprobanteNumero.Enabled = IndicaActivo
        txtComprobanteFecha.Enabled = IndicaActivo
        cmbListaPrecios.Enabled = IndicaActivo

        'txtTipoCambio.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtDocumentoNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtVendedorCodigo.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteSerie.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)

        'txtTipoCambio.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtDocumentoNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtVendedorCodigo.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)

        If IndicaActivo = True Then txtDocumentoNumero.Focus()
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        txtProducto.Enabled = IndicaActivo
        txtCantidad.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo : btnDescartar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3) : btnDescartar.ImageIndex = IIf(IndicaActivo = True, 0, 2)
        cmbProductos.SelectedIndex = -1
        gvVentaLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            ExisteVendedor = False
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C")
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.Text = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                    txtVendedorCodigo.Text = .codigo_vendedor.Trim
                    If txtVendedorCodigo.Text.Trim.Length <> 0 Then ExisteVendedor = True
                    MyCommonTables.ObtenerDescripcionListaEmpresa(txtVendedorNombre, "STD_VENDEDORES", .codigo_vendedor)
                End With
                If txtVendedorCodigo.Text.Trim = Nothing Then
                    txtVendedorCodigo.Focus()
                Else
                    txtComprobanteNumero.Focus()
                End If
            Else
                txtCuentaComercial.Text = Nothing
                txtDocumentoNumero.Text = Nothing
                txtRazonSocial.Text = Nothing
                txtVendedorCodigo.Text = Nothing
                txtVendedorNombre.Text() = Nothing
                txtDocumentoNumero.Focus()
            End If
        End If
    End Sub

    Private Sub ValidarVendedor()
        Dim MyTabla As String = "STD_VENDEDORES"
        Dim MyVendedor As String = txtVendedorCodigo.Text.Trim
        Dim EsNuevo As Boolean = False
        MiAnexoVendedor = New entListaElemento
        If String.IsNullOrEmpty(txtVendedorCodigo.Text.Trim) Then
            Dim MyForm As New frmLista(MiAnexoVendedor, MyTabla, "CONSULTORES")
            MyForm.ShowDialog()
        Else
            MiAnexoVendedor = dalTablaDetalle.ObtenerElemento(MyTabla, MyVendedor)
            If MiAnexoVendedor.codigo Is Nothing Then EsNuevo = True
        End If

        If Not MiAnexoVendedor.codigo Is Nothing Then
            txtVendedorCodigo.Text = MiAnexoVendedor.codigo.Trim
            txtVendedorNombre.Text = MiAnexoVendedor.descripcion.Trim
            txtComprobanteNumero.Focus()
        Else
            If MyVendedor = Nothing Then
                txtVendedorNombre.Text = Nothing
                txtVendedorCodigo.Text = Nothing
                txtVendedorCodigo.Focus()
            Else
                txtComprobanteNumero.Focus()
            End If
        End If
    End Sub

    Private Sub ValidarProducto()
        Dim MyCodigo As String = ""
        Dim MyPrecio As Decimal = 0
        Dim MyCantidad As Decimal = 0

        MyProducto = New entProducto
        MyCodigo = txtProducto.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto, "A")
            MyForm.ShowDialog()
        Else
            MyProducto = dalProducto.Obtener(MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            MyPrecio = BuscarPrecioUnitario()
            txtProducto.Text = MyProducto.producto
            cmbProductos.SelectedValue = MyProducto.producto
            txtIndicaCompuesto.Text = MyProducto.indica_compuesto
            txtIndicaValidaStock.Text = MyProducto.indica_valida_stock
            txtCantidad.Focus()
        Else
            cmbProductos.SelectedIndex = -1
            txtProducto.Text = Nothing
            txtIndicaCompuesto.Text = Nothing
            txtCantidad.Text = "0.00"
            txtProducto.Focus()
        End If
        'If m_Tipo_Venta = "B2" Then ' Transferencia Gratuita
        '    txtPrecioUnitario.Text = "0.00"
        'Else
        txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)
        'End If
        Call ActualizarValores()
    End Sub

    Private Function BuscarPrecioUnitario() As Decimal
        Dim MyPrecio As dsListaPrecios.LISTA_PRECIOS_DETRow
        Dim PrimaryKey(2) As Object

        PrimaryKey(0) = MyUsuario.empresa
        PrimaryKey(1) = cmbListaPrecios.SelectedValue
        PrimaryKey(2) = MyProducto.producto

        MyPrecio = MyListaPrecio.Rows.Find(PrimaryKey)

        If Not (MyPrecio Is Nothing) Then
            Return MyPrecio.VALOR_VENTA_ME
        Else
            Return 0
        End If
    End Function

    Private Sub ActualizarValores()
        Dim Cantidad As Decimal = 0
        Dim PrecioUnitario As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Cantidad = CDec(txtCantidad.Text)
        PrecioUnitario = CDec(txtPrecioUnitario.Text)
        PrecioTotal = Math.Round(Cantidad * PrecioUnitario, 2)
        txtPrecioTotal.Text = EvalDato(PrecioTotal, txtPrecioTotal.Tag)
    End Sub

    Private Sub PoblarCorrelativo()
        MyCorrelativo = dalVenta.ObtenerCorrelativo(cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text)
        If MyCorrelativo.Rows.Count = 0 Then
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = CDate("01/" & MyAsientoMes & "/" & MyAsientoEjercicio)
        Else
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = MyCorrelativo(0).COMPROBANTE_FECHA
        End If
        txtComprobanteFecha.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)
        txtComprobanteVencimiento.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)
    End Sub

    Private Sub CalcularTotales()
        Dim MyBaseImponibleGravadaOrigen As Decimal = 0
        Dim MyIGVOrigen As Decimal = 0
        Dim MyImporteSubTotalOrigen As Decimal = 0
        Dim MyImporteTotalOrigen As Decimal = 0

        txtEditado.Text = Nothing
        txtProducto.Text = Nothing
        cmbProductos.SelectedIndex = -1
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)
        txtPrecioTotal.Text = EvalDato(0, txtPrecioTotal.Tag)
        txtLinea.Text = Nothing

        For Each row As DataGridViewRow In gvVentaLineas.Rows
            MyImporteSubTotalOrigen = row.Cells(7).Value
            MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
        Next

        MyBaseImponibleGravadaOrigen = Math.Round(MyImporteTotalOrigen / 1.18, 2)
        MyIGVOrigen = MyImporteTotalOrigen - MyBaseImponibleGravadaOrigen
        txtBaseImponibleGravadaOrigen.Text = EvalDato(MyBaseImponibleGravadaOrigen, txtBaseImponibleGravadaOrigen.Tag)
        txtIGVOrigen.Text = EvalDato(MyIGVOrigen, txtIGVOrigen.Tag)
        txtImporteTotalOrigen.Text = EvalDato(MyImporteTotalOrigen, txtImporteTotalOrigen.Tag)

        gvVentaLineas.ClearSelection()
        txtProducto.Focus()
    End Sub

    Private Sub PoblarFormulario()
        Dim Venta As String = MyVenta.venta
        Dim MyDetalles As dsVentas.VENTAS_DETALLEDataTable
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            ExisteVendedor = False
            With MyVenta

                Call ActivarCabecera(False)
                Call ActivarDetalles(False)

                MyCuentaComercial = dalCuentaComercial.Obtener(.cuenta_comercial)

                txtVenta.Text = .venta
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtCuentaComercial.Text = .cuenta_comercial
                txtTipoCambio.Text = EvalDato(.tipo_cambio, txtTipoCambio.Tag)

                cmbAlmacen.SelectedValue = .almacen
                cmbCentroDistribucion.SelectedValue = .centro_distribucion
                cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                txtRazonSocial.Text = MyCuentaComercial.razon_social
                txtVendedorCodigo.Text = .codigo_vendedor.Trim
                If txtVendedorCodigo.Text.Trim.Length <> 0 Then
                    ExisteVendedor = True
                    Call ObtenerDescripcionListaEmpresa(txtVendedorNombre, "STD_VENDEDORES", .codigo_vendedor)
                End If

                txtComprobanteSerie.Text = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteSerie.Text = .comprobante_serie
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                txtComprobanteVencimiento.Text = EvalDato(.comprobante_vencimiento, "F")

                cmbTipoMoneda.SelectedValue = .tipo_moneda
                cmbListaPrecios.SelectedValue = .lista_precio
                cmbCondicionPago.SelectedValue = .condicion_pago

                txtBaseImponibleGravadaOrigen.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponibleGravadaOrigen.Tag)
                txtIGVOrigen.Text = EvalDato(.igv_origen, txtIGVOrigen.Tag)
                txtImporteTotalOrigen.Text = EvalDato(.importe_total_origen, txtImporteTotalOrigen.Tag)
                txtComentario.Text = .comentario

                If .ejercicio = MyUsuario.ejercicio And .mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
                    UC_ToolBar.btnGrabar_Visible = True
                Else
                    UC_ToolBar.btnGrabar_Visible = False
                End If

                ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)
                MyDetalles = dalVenta.ObtenerDetalles(txtVenta.Text)
                If MyDetalles.Rows.Count <> 0 Then
                    For Each row As dsVentas.VENTAS_DETALLERow In MyDetalles.Rows
                        gvVentaLineas.Rows.Add(row.EMPRESA, row.VENTA, row.LINEA, row.PRODUCTO, row.DESCRIPCION_AMPLIADA, row.CANTIDAD, row.PRECIO_UNITARIO_ME, row.IMPORTE_TOTAL_ME, row.NUMERO_LOTE, row.INDICA_COMPUESTO)
                    Next
                End If
                gvVentaLineas.ClearSelection()
            End With
        End If
    End Sub

    Private Sub GrabarBoletaVenta()
        If m_Exige_Orden = True Then

        End If
    End Sub

    Private Sub Salir()
        'If m_Titulo_Comprobante = "BOLETA" Then
        '    BV(3) = False
        'Else
        '    BV(5) = False
        'End If

        Select Case m_Tipo_Venta
            Case Is = "B2" : BV(2) = False
            Case Is = "B3" : BV(3) = False
            Case Is = "F2" : BV(5) = False
        End Select

        Me.Close()
    End Sub

    Private Sub ReiniciarFecha()
        txtTipoCambio.Text = "0.000"
        txtComprobanteVencimiento.Text = Nothing
        txtComprobanteFecha.Text = Nothing
        txtComprobanteFecha.Focus()
    End Sub

#End Region

#Region "Botones"

    Private Sub btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Dim MyForm As New frmStockAlmacenImprimir(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, cmbAlmacen.Text)
        MyForm.ShowDialog()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        With MyVenta
            .empresa = MyUsuario.empresa
            .venta = txtVenta.Text
            .ejercicio = MyAsientoEjercicio
            .mes = MyAsientoMes
            .almacen = cmbAlmacen.SelectedValue
            .lista_precio = cmbListaPrecios.SelectedValue
            .tipo_venta = m_Tipo_Venta
            .centro_distribucion = cmbCentroDistribucion.SelectedValue
            .asiento_tipo = MyAsientoTipo
            .asiento_fecha = MyAsientoFecha
            .cuenta_comercial = txtCuentaComercial.Text
            .comprobante_tipo = cmbComprobanteTipo.SelectedValue
            .comprobante_serie = txtComprobanteSerie.Text
            .comprobante_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then
                .comprobante_fecha = txtComprobanteFecha.Text
                .asiento_fecha = txtComprobanteFecha.Text
            End If
            If txtComprobanteVencimiento.Text.Length <> 0 Then .comprobante_vencimiento = txtComprobanteVencimiento.Text
            .tipo_cambio = CDec(txtTipoCambio.Text)
            .tipo_moneda = cmbTipoMoneda.SelectedValue
            .base_imponible_gravada_origen = CDec(txtBaseImponibleGravadaOrigen.Text)
            .igv_origen = CDec(txtIGVOrigen.Text)
            .importe_total_origen = CDec(txtImporteTotalOrigen.Text)
            If .tipo_moneda = "1" Then ' MN
                .base_imponible_gravada_mn = .base_imponible_gravada_origen
                .importe_total_mn = .importe_total_origen
                .igv_mn = .igv_origen
                .base_imponible_gravada_me = Math.Round(.base_imponible_gravada_origen / MyTipoCambio, 2)
                .importe_total_me = Math.Round(.importe_total_origen / MyTipoCambio, 2)
                .igv_me = .importe_total_me - .base_imponible_gravada_me
            Else
                .base_imponible_gravada_me = .base_imponible_gravada_origen
                .importe_total_me = .importe_total_origen
                .igv_me = .igv_origen
                .base_imponible_gravada_mn = Math.Round(.base_imponible_gravada_origen * MyTipoCambio, 2)
                .importe_total_mn = Math.Round(.importe_total_origen * MyTipoCambio, 2)
                .igv_mn = .importe_total_mn - .base_imponible_gravada_mn
            End If

            .condicion_pago = cmbCondicionPago.SelectedValue
            .codigo_vendedor = txtVendedorCodigo.Text
            '.orden_pedido = txtOrdenPedido.Text
            .comentario = txtComentario.Text
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
            .usuario_registro = MyUsuario.usuario
        End With

        Try
            If txtVenta.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                If dalVenta.Anular(MyVenta) = True Then
                    Call LimpiarFormulario()
                    txtDocumentoNumero.Focus()
                Else
                    ckbIndicaAnulado.Checked = False
                    txtComprobanteSerie.Focus()
                End If
            Else
                MyVenta = dalVenta.Grabar(MyVenta)
                txtVenta.Text = MyVenta.venta

                Resp = MsgBox("Los cambios del encabezado se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                Call ActivarCabecera(False)
                Call ActivarDetalles(True)
                txtComprobanteSerie.Focus()
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

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyCantidadControl As Integer = 0
        MyVenta = New entVenta
        MyAccion = "MODIFICAR"
        Dim MyForm As New frmFacturacionProductosLista(MyVenta, txtEjercicio.Text, txtMes.Text, "TODOS", m_Tipo_Venta)
        MyForm.ShowDialog()
        If Not MyVenta.venta Is Nothing Then
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtVenta.Text.Trim <> "" Then
            MyAccion = "IMPRIMIR"
            MyAnexo = New entCONCAR_Anexo
            MyAnexo = dalCONCAR_Anexo.ObtenerCliente(txtDocumentoNumero.Text)
            MyPrintDocument = New Printing.PrintDocument

            AddHandler MyPrintDocument.PrintPage, AddressOf Print_PrintPage

            MyPrintPreview.Document = MyPrintDocument
            MyLabel.Text = m_Titulo_Comprobante

            MyFactura = New entFactura
            With MyFactura
                .Venta = txtVenta.Text
                .Documento_Serie = txtComprobanteSerie.Text
                .Documento_Numero = Strings.Right(txtComprobanteNumero.Text, 7)
                .Fecha_Emision = txtComprobanteFecha.Text
                .Fecha_Vencimiento = txtComprobanteVencimiento.Text
                .Razon_Social = txtRazonSocial.Text
                .RUC = txtDocumentoNumero.Text
                .Domicilio_01 = MyAnexo.amemo
                '.Domicilio_02 = txtDomicilio2.Text
                .Condicion_Pago = cmbCondicionPago.SelectedValue
                .Tipo_Moneda = cmbTipoMoneda.SelectedValue
                .Valor_Venta = CDec(txtBaseImponibleGravadaOrigen.Text) + CDec(txtImporteExoneradoOrigen.Text) + CDec(txtImporteInafectoOrigen.Text)
                .IGV = CDec(txtIGVOrigen.Text)
                .Precio_Venta = CDec(txtImporteTotalOrigen.Text)
                .Precio_Venta_Texto = ConvertNumText(CDec(txtImporteTotalOrigen.Text), cmbTipoMoneda.SelectedValue)

                MyTextboxSerie.Text = .Documento_Serie
                MyTextboxNumero.Text = .Documento_Numero
                MyTextboxFecha.Text = .Fecha_Emision

            End With

            ControlarCorrelativo = IIf(MyFactura.Documento_Serie <> "000", False, True)
            Try
                'MyPrintPreview.MdiParent = frmMenu
                'MyPrintPreview.Show()
                'Me.Select()
                MyPrintPreview.ShowDialog()

            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                'Resp = MsgBox("ERROR: " & ex.Message.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Resp = MsgBox("ERROR: " & ex.Message.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "IMPRIMIR COMPROBANTE")
            End Try

            'If AsignarCorrelativo Then
            '    MyVenta.comprobante_fecha = MyFactura.Fecha_Emision
            '    MyCorrelativo = dalVenta.ActualizarCorrelativo(MyVenta)
            '    If MyCorrelativo.Count > 0 Then
            '        Resp = MsgBox("Se asignó el correlativo SERIE: " & MyCorrelativo(0).COMPROBANTE_SERIE & " NUMERO: " & MyCorrelativo(0).COMPROBANTE_NUMERO, MessageBoxButtons.OK, "FACTURA")
            '        Call InicializarFormulario()
            '    End If
            'End If


        End If
    End Sub

    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim ImporteSoles As Decimal
        Dim MyProductoDescripcion As String
        MyFacturaDetalles = dalVenta.ObtenerVentaProducto(MyFactura.Venta)

        Try
            'Definir la fuente
            Dim prFont As New Font("Courier New", 9, FontStyle.Regular)
            Dim prFontB As New Font("Courier New", 9, FontStyle.Bold)
            Dim prFontT As New Font("Arial Narrow", 9, FontStyle.Regular)
            Dim prFontTB As New Font("Arial Narrow", 9, FontStyle.Bold)
            If m_Titulo_Comprobante = "BOLETA" Then
                e.Graphics.DrawString(MyFactura.Documento_Serie & "-" & MyFactura.Documento_Numero, prFont, Brushes.Black, 540, 207)
                e.Graphics.DrawString(MyFactura.Razon_Social, prFontB, Brushes.Black, 85, 230)
                e.Graphics.DrawString(MyFactura.Domicilio_01, prFont, Brushes.Black, 85, 260)
                e.Graphics.DrawString(MyFactura.RUC, prFontB, Brushes.Black, 105, 295)
                e.Graphics.DrawString(MyFactura.Fecha_Emision, prFont, Brushes.Black, 600, 295)

                NFil = 358
                'imprimimos Detalles
                For NEle = 0 To MyFacturaDetalles.Count - 1
                    MyProductoDescripcion = dalProducto.ObtenerDescripcion(MyFacturaDetalles(NEle).PRODUCTO)
                    e.Graphics.DrawString(Strings.Right(Space(4) & EvalDato(MyFacturaDetalles(NEle).CANTIDAD, "E").ToString, 4), prFont, Brushes.Black, 0, NFil)
                    'e.Graphics.DrawString(MyProductoDescripcion, prFont, Brushes.Black, 80, NFil)
                    e.Graphics.DrawString(MyProductoDescripcion, prFontT, Brushes.Black, 75, NFil)
                    e.Graphics.DrawString(Strings.Right(Space(10) & EvalDato(MyFacturaDetalles(NEle).PRECIO_UNITARIO, "D").ToString, 10), prFont, Brushes.Black, 540, NFil)
                    e.Graphics.DrawString(Strings.Right(Space(12) & EvalDato(MyFacturaDetalles(NEle).IMPORTE_TOTAL_ME, "D").ToString, 12), prFont, Brushes.Black, 640, NFil)
                    NFil = NFil + 20
                Next NEle

                ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

                e.Graphics.DrawString(ConvertNumText(CDbl(txtImporteTotalOrigen.Text), MyFactura.Tipo_Moneda), prFontB, Brushes.Black, 65, 690)

                e.Graphics.DrawString(IIf(cmbTipoMoneda.SelectedValue = "2", "U$.", "S/."), prFontB, Brushes.Black, 635, 730)
                e.Graphics.DrawString(Strings.Right(Space(12) & txtImporteTotalOrigen.Text, 12), prFontB, Brushes.Black, 640, 730)
            Else
                e.Graphics.DrawString(MyFactura.Documento_Serie & "-" & MyFactura.Documento_Numero, prFont, Brushes.Black, 540, 175)
                e.Graphics.DrawString(MyFactura.Fecha_Emision.Day, prFont, Brushes.Black, 45, 185)
                e.Graphics.DrawString(EvalMes(MyFactura.Fecha_Emision.Month, "L").ToUpper, prFont, Brushes.Black, 100, 185)
                e.Graphics.DrawString(MyFactura.Fecha_Emision.Year.ToString.Substring(2, 2), prFont, Brushes.Black, 285, 185)
                e.Graphics.DrawString(MyFactura.Razon_Social, prFontB, Brushes.Black, 80, 215)
                e.Graphics.DrawString(MyFactura.RUC, prFontB, Brushes.Black, 600, 215)
                e.Graphics.DrawString(MyFactura.Domicilio_01, prFont, Brushes.Black, 80, 245)

                NFil = 333
                'imprimimos Detalles
                For NEle = 0 To MyFacturaDetalles.Count - 1
                    MyProductoDescripcion = dalProducto.ObtenerDescripcion(MyFacturaDetalles(NEle).PRODUCTO)
                    e.Graphics.DrawString(Strings.Right(Space(4) & EvalDato(MyFacturaDetalles(NEle).CANTIDAD, "E").ToString, 4), prFont, Brushes.Black, 50, NFil)
                    'e.Graphics.DrawString(MyProductoDescripcion, prFont, Brushes.Black, 90, NFil)
                    e.Graphics.DrawString(MyProductoDescripcion, prFontT, Brushes.Black, 110, NFil)
                    e.Graphics.DrawString(Strings.Right(Space(10) & EvalDato(MyFacturaDetalles(NEle).PRECIO_UNITARIO, "D").ToString, 10), prFont, Brushes.Black, 550, NFil)
                    e.Graphics.DrawString(Strings.Right(Space(12) & EvalDato(MyFacturaDetalles(NEle).IMPORTE_TOTAL_ME, "D").ToString, 12), prFont, Brushes.Black, 630, NFil)
                    NFil = NFil + 20
                Next NEle

                ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

                e.Graphics.DrawString(ConvertNumText(CDbl(txtImporteTotalOrigen.Text), MyFactura.Tipo_Moneda), prFontB, Brushes.Black, 90, 665)

                e.Graphics.DrawString(Strings.Right(Space(12) & txtBaseImponibleGravadaOrigen.Text, 12), prFontB, Brushes.Black, 630, 695)
                e.Graphics.DrawString(EvalDato(MyIGV, "E") & "%", prFontB, Brushes.Black, 600, 725)
                e.Graphics.DrawString(Strings.Right(Space(12) & txtIGVOrigen.Text, 12), prFontB, Brushes.Black, 630, 725)
                e.Graphics.DrawString(IIf(cmbTipoMoneda.SelectedValue = "2", "U$.", "S/."), prFontB, Brushes.Black, 600, 760)
                e.Graphics.DrawString(Strings.Right(Space(12) & txtImporteTotalOrigen.Text, 12), prFontB, Brushes.Black, 630, 760)
            End If

            'indicamos que hemos llegado al final de la pagina
            e.HasMorePages = False

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtProducto.TextLength <> 0 And CDec(txtCantidad.Text) <> 0 Then
            If txtVenta.Text <> Nothing Then
                With MyVentaDetalle
                    .empresa = MyUsuario.empresa
                    .venta = txtVenta.Text.Trim
                    .linea = txtLinea.Text
                    .tipo_cambio = CDec(txtTipoCambio.Text)
                    .tipo_moneda = cmbTipoMoneda.SelectedValue
                    .producto = txtProducto.Text
                    .cantidad = CDec(txtCantidad.Text)
                    .precio_unitario = CDec(txtPrecioUnitario.Text)
                    .importe_total_me = CDec(txtPrecioTotal.Text)
                    .indica_compuesto = txtIndicaCompuesto.Text
                    .almacen = cmbAlmacen.SelectedValue
                    .descripcion_ampliada = cmbProductos.Text
                    .ejercicio_venta = txtEjercicio.Text
                    .mes_venta = txtMes.Text
                    .indica_valida_stock = txtIndicaValidaStock.Text
                End With

                Try
                    If dalVenta.Grabar(MyVentaDetalle, gvVentaLineas) = True Then
                        Call CalcularTotales()
                    End If
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        If txtProducto.TextLength <> 0 And txtLinea.TextLength <> 0 Then
            With MyVentaDetalle
                .empresa = MyUsuario.empresa
                .venta = txtVenta.Text.Trim
                .linea = txtLinea.Text
                .producto = txtProducto.Text
                .tipo_cambio = CDec(txtTipoCambio.Text)
                .tipo_moneda = cmbTipoMoneda.SelectedValue
                .almacen = cmbAlmacen.SelectedValue
                .indica_valida_stock = txtIndicaValidaStock.Text
            End With

            Try
                If dalVenta.Descartar(MyVentaDetalle, gvVentaLineas) = True Then
                    Call CalcularTotales()
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub



#End Region

End Class