Public Class frmOrdenPedido

    Private MyCuentaComercial As entCuentaComercial
    Private MiAnexoVendedor As entListaElemento

    Private MyOrdenPedido As entOrdenPedido
    Private MyOrdenPedidoDetalle As entOrdenPedidoDetalle
    Private MyProducto As entProducto

    Private MyListaPrecio As dsListaPrecios.LISTA_PRECIOS_DETDataTable
    Private MyDetallesPedido As dsOrdenPedido.DETALLES_PEDIDODataTable

    Private MyAnexo As entCONCAR_Anexo
    Private MyListaElemento As entListaElemento
    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable

    Private MyAccion As String = "NUEVO"
    Private MySender As String

    Private ExisteVendedor As Boolean

    Private MyCantidadControl As Integer


    Private Sub frmOrdenPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmOrdenPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ActualizarLista(cmbListaPrecios)
        ActualizarListaEmpresa(cmbPagoTipo, "COM_FORMA_PAGO")
        ActualizarListaEmpresa(cmbCentroDistribucion, "COM_CENTRO_DISTRIBUCION")
        ActualizarListaGenerica(cmbPagoBanco, "_ENTIDAD_FINANCIERA")
        ActualizarListaGenerica(cmbPagoMoneda, "_TIPO_MONEDA")
        ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, "01")

        cmbProductos.DataSource = dalProducto.BuscarProductoActivos("")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

    End Sub

    Private Sub txtVendedorCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendedorCodigo.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarVendedor()
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub txtPagoReferencia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoReferencia.Validated
        UC_ToolBar.btnGrabar_Focus = True
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto()
        End If
    End Sub

    Private Sub ckbIndicaAnulado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ckbIndicaAnulado.Validating
        If txtOrdenPedido.TextLength <> 0 Then
            If gvOrdenPedidoLineas.Rows.Count <> 0 And ckbIndicaAnulado.Checked = True Then
                Resp = MsgBox("Para anular una Orden de Pedido debe primero eliminar sus detalles.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PROCESO CANCELADO")
                ckbIndicaAnulado.Checked = Not ckbIndicaAnulado.Checked
            Else
                Resp = MsgBox("Confirmar si desea " & IIf(ckbIndicaAnulado.Checked = True, "ANULAR", "ACTIVAR"), MsgBoxStyle.Information + MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                If Resp = vbYes Then
                    Call dalOrdenPedido.AnularActivar(txtOrdenPedido.Text)
                    Call LimpiarFormulario()
                End If
            End If
        End If
    End Sub

    Private Sub cmbListaPrecios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbListaPrecios.SelectedIndexChanged
        If cmbListaPrecios.SelectedIndex <> -1 Then
            MyListaPrecio = dalListaPrecio.ObtenerListaPrecios(cmbListaPrecios.SelectedValue)
        End If
    End Sub

    Private Sub gvOrdenPedidoLineas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOrdenPedidoLineas.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            Dim Producto As String = sender.Rows(sender.CurrentRow.Index).Cells("PRODUCTO").Value
            Dim MyDetalle As dsOrdenPedido.DETALLES_PEDIDORow
            Dim PrimaryKey(2) As Object

            PrimaryKey(0) = MyUsuario.empresa
            PrimaryKey(1) = MyOrdenPedido.orden_pedido
            PrimaryKey(2) = Producto

            MyDetalle = MyDetallesPedido.Rows.Find(PrimaryKey)

            If Not (MyDetalle Is Nothing) Then
                txtEditado.Text = "E"
                txtProducto.Text = MyDetalle.PRODUCTO
                cmbProductos.Text = MyDetalle.DESCRIPCION_AMPLIADA
                txtCantidad.Text = EvalDato(MyDetalle.CANTIDAD, txtCantidad.Tag)
                txtPrecioUnitario.Text = EvalDato(MyDetalle.PRECIO_UNITARIO_ME, txtPrecioUnitario.Tag)
                txtPrecioTotal.Text = EvalDato(Math.Round(MyDetalle.CANTIDAD * MyDetalle.PRECIO_UNITARIO_ME, 2), txtPrecioTotal.Tag)
                txtVenta.Text = MyDetalle.VENTA
                txtVentaLinea.Text = MyDetalle.VENTA_LINEA
                txtCantidad.Focus()
            End If
        End If
    End Sub

    Private Sub gvOrdenesPendientes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOrdenesPendientes.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            Dim Pedido As String = sender.Rows(sender.CurrentRow.Index).Cells("ORDENPEDIDO").Value
            MyOrdenPedido = New entOrdenPedido
            MyOrdenPedido.orden_pedido = Pedido
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrdenFecha.Validated, txtPagoFecha.Validated
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtOrdenFecha" Then
                    txtDocumentoNumero.Focus()
                Else
                    txtPagoReferencia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub ValidarImporte(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoImporte.Validated, txtCantidad.Validated, txtPrecioUnitario.Validated, txtPrecioTotal.Validated
        If sender.text.ToString.Length <> 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            Call ActualizarValores()
        End If
    End Sub

    Private Sub txtDocumentoNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumentoNumero.Validated
        If Not String.IsNullOrEmpty(txtDocumentoNumero.Text.Trim) Then Call ValidarDocumento()
    End Sub

    Private Sub txtVendedorCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVendedorCodigo.Validated
        If Not String.IsNullOrEmpty(txtVendedorCodigo.Text.Trim) Then Call ValidarVendedor()
    End Sub

    Private Sub txtProducto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.Validated
        If Not String.IsNullOrEmpty(txtProducto.Text.Trim) Then Call ValidarProducto()
    End Sub

#Region "Botones"

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
        UC_ToolBar.btnGrabar_Visible = True
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        'If txtOrdenPedido.Text.Trim.Length <> 0 Then
        Call GrabarCabecera()
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtProducto.TextLength <> 0 And CDec(txtCantidad.Text) <> 0 Then
            If txtVenta.Text <> CUO_Nulo Then
                Resp = MsgBox("La linea ha sido facturada.", MsgBoxStyle.Information, "PROCESO DENEGADO")
            Else
                With MyOrdenPedidoDetalle
                    .empresa = MyUsuario.empresa
                    .orden_pedido = txtOrdenPedido.Text.Trim
                    .producto = txtProducto.Text
                    .cantidad = CDec(txtCantidad.Text)
                    .precio_unitario_me = CDec(txtPrecioUnitario.Text)
                    .importe_total_me = CDec(txtPrecioTotal.Text)
                End With

                Try
                    MyOrdenPedidoDetalle = dalOrdenPedido.Grabar(MyOrdenPedidoDetalle)
                    Call ActualizarGrilla()
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        If txtProducto.TextLength <> 0 Then
            If txtVenta.Text <> CUO_Nulo Then
                Resp = MsgBox("La linea ha sido facturada.", MsgBoxStyle.Information, "PROCESO DENEGADO")
            Else
                With MyOrdenPedidoDetalle
                    .empresa = MyUsuario.empresa
                    .orden_pedido = txtOrdenPedido.Text.Trim
                    .producto = txtProducto.Text
                End With

                Try
                    If dalOrdenPedido.Descartar(MyOrdenPedidoDetalle) = True Then
                        Call ActualizarGrilla()
                    End If
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyOrdenPedido = New entOrdenPedido
        MyAccion = "MODIFICAR" : MyCantidadControl = 0
        Dim MyForm As New frmOrdenPedidoLista(MyOrdenPedido, txtEjercicio.Text, txtMes.Text, "TODOS", "TODOS")
        MyForm.ShowDialog()
        If Not MyOrdenPedido.orden_pedido Is Nothing Then
            MyCantidadControl = dalVenta.EvaluarPedidoAtendido(MyOrdenPedido.orden_pedido)
            Call PoblarFormulario()
        End If
    End Sub

#End Region

#Region "Funciones"

    Private Sub GrabarCabecera()
        With MyOrdenPedido
            .empresa = MyUsuario.empresa
            .orden_pedido = txtOrdenPedido.Text.Trim
            .ejercicio = txtEjercicio.Text
            .mes = txtMes.Text
            If txtOrdenFecha.Text.Length <> 0 Then .orden_fecha = txtOrdenFecha.Text
            .centro_distribucion = cmbCentroDistribucion.SelectedValue
            .codigo_vendedor = txtVendedorCodigo.Text
            .cuenta_comercial = txtCuentaComercial.Text
            .lista_precio = cmbListaPrecios.SelectedValue
            .pago_tipo = cmbPagoTipo.SelectedValue
            .pago_banco = cmbPagoBanco.SelectedValue
            .pago_moneda = cmbPagoMoneda.SelectedValue
            If txtPagoFecha.Text.Length <> 0 Then .pago_fecha = txtPagoFecha.Text
            .pago_importe = CDec(txtPagoImporte.Text)
            .pago_referencia = txtPagoReferencia.Text
            .tipo_cambio = CDec(txtTipoCambio.Text)
            .indica_primera_compra = IIf(ckbIndicaPrimeraCompra.Checked = True, "SI", "NO")
            .indica_ascenso = IIf(ckbIndicaAscenso.Checked = True, "SI", "NO")
            .indica_mantenimiento = IIf(ckbIndicaMantenimiento.Checked = True, "SI", "NO")
            .indica_compra_extra = IIf(ckbIndicaCompraExtra.Checked = True, "SI", "NO")
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
        End With

        Try
            MyOrdenPedido = dalOrdenPedido.Grabar(MyOrdenPedido)
            If txtVendedorCodigo.Text.Trim.Length <> 0 Then
                dalCuentaComercial.GrabarVendedor(txtVendedorCodigo.Text, txtRazonSocial.Text, txtDocumentoNumero.Text)
                dalCuentaComercial.ActualizarVendedor(txtCuentaComercial.Text, txtVendedorCodigo.Text)
            End If

            txtOrdenPedido.Text = MyOrdenPedido.orden_pedido
            Resp = MsgBox("Los cambios del encabezado se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")

            cmbListaPrecios.Enabled = False
            Call ActivarDetalles(True)
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub PoblarFormulario()
        Dim OrdenPedido As String = MyOrdenPedido.orden_pedido
        Call LimpiarFormulario()
        MyOrdenPedido = dalOrdenPedido.Obtener(OrdenPedido)
        If Not MyOrdenPedido.orden_pedido Is Nothing Then
            ExisteVendedor = False
            With MyOrdenPedido
                MyCuentaComercial = dalCuentaComercial.Obtener(.cuenta_comercial)

                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtCuentaComercial.Text = .cuenta_comercial
                txtOrdenPedido.Text = .orden_pedido
                txtOrdenFecha.Text = EvalDato(.orden_fecha, "F")
                cmbCentroDistribucion.SelectedValue = .centro_distribucion
                txtVendedorCodigo.Text = .codigo_vendedor.Trim
                If txtVendedorCodigo.Text.Trim.Length <> 0 Then
                    ExisteVendedor = True
                    Call ObtenerDescripcionListaEmpresa(txtVendedorNombre, "STD_VENDEDORES", .codigo_vendedor)
                End If
                cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                txtRazonSocial.Text = MyCuentaComercial.razon_social
                cmbListaPrecios.SelectedValue = .lista_precio
                cmbPagoTipo.SelectedValue = .pago_tipo
                cmbPagoBanco.SelectedValue = .pago_banco
                cmbPagoMoneda.SelectedValue = .pago_moneda
                If .pago_fecha.Year <> 1900 Then txtPagoFecha.Text = .pago_fecha
                txtPagoImporte.Text = EvalDato(.pago_importe, txtPagoImporte.Tag)
                txtPagoReferencia.Text = .pago_referencia
                txtTipoCambio.Text = EvalDato(.tipo_cambio, txtTipoCambio.Tag)

                If MyCantidadControl <> 0 Then
                    Resp = MsgBox("La Orden de Pedido ya a sido facturada.", MsgBoxStyle.Information, "PROCESO DENEGADO")
                    UC_ToolBar.btnGrabar_Visible = False
                    Call ActivarCabecera(False)
                    Call ActivarDetalles(False)
                Else
                    If .ejercicio = MyUsuario.ejercicio And .mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
                        UC_ToolBar.btnGrabar_Visible = True
                        Call ActivarCabecera(IIf(.estado = "A", True, False))
                        Call ActivarDetalles(IIf(.estado = "A", True, False))
                    Else
                        UC_ToolBar.btnGrabar_Visible = False
                        Call ActivarCabecera(False)
                        Call ActivarDetalles(False)
                    End If
                End If
                ckbIndicaPrimeraCompra.Checked = IIf(.indica_primera_compra = "SI", True, False)
                ckbIndicaAscenso.Checked = IIf(.indica_ascenso = "SI", True, False)
                ckbIndicaMantenimiento.Checked = IIf(.indica_mantenimiento = "SI", True, False)
                ckbIndicaCompraExtra.Checked = IIf(.indica_compra_extra = "SI", True, False)
                ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)
                Call ActualizarGrilla()

                gvOrdenesPendientes.DataSource = dalOrdenPedido.ObtenerPedidosPendientes(txtCuentaComercial.Text)
                gvOrdenesPendientes.ClearSelection()

            End With
        End If
    End Sub

    Private Sub LimpiarFormulario()
        MyOrdenPedido = New entOrdenPedido
        MyOrdenPedidoDetalle = New entOrdenPedidoDetalle

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

        gvOrdenPedidoLineas.DataSource = New dsOrdenPedido.DETALLES_PEDIDODataTable
        gvOrdenesPendientes.DataSource = New dsOrdenPedido.ORDEN_PEDIDO_PENDIENTESDataTable

        Call PonerValoresDefault()
        Call ActivarDetalles(False)
        Call ActivarCabecera(True)

        txtOrdenFecha.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        cmbCentroDistribucion.SelectedValue = "LIM"
        cmbDocumentoTipo.SelectedValue = "01"
        cmbListaPrecios.Enabled = True
        cmbListaPrecios.SelectedValue = "CONSULTOR_EF"
        cmbPagoTipo.SelectedValue = "20"
        cmbPagoBanco.SelectedValue = "02"
        cmbPagoMoneda.SelectedValue = "2"
        txtTipoCambio.Text = "1.000"
        cmbProductos.SelectedIndex = -1
        txtOrdenFecha.Text = EvalDato(Now.Date, "F")
        txtPagoFecha.Text = EvalDato(Now.Date, "F")
    End Sub

    Private Sub ActualizarValores()
        Dim Cantidad As Decimal = 0
        Dim PrecioUnitario As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Cantidad = CDec(txtCantidad.Text)
        PrecioUnitario = CDec(txtPrecioUnitario.Text)
        PrecioTotal = Math.Round(Cantidad * PrecioUnitario, 2)
        txtPrecioTotal.Text = EvalDato(PrecioTotal, txtPrecioTotal.Tag)
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        txtOrdenFecha.Enabled = IndicaActivo
        'cmbCentroDistribucion.Enabled = IndicaActivo
        txtVendedorCodigo.Enabled = IndicaActivo
        cmbDocumentoTipo.Enabled = IndicaActivo
        txtDocumentoNumero.Enabled = IndicaActivo
        txtPagoFecha.Enabled = IndicaActivo
        'txtPagoImporte.Enabled = IndicaActivo
        txtPagoReferencia.Enabled = IndicaActivo
        cmbListaPrecios.Enabled = IndicaActivo
        'cmbPagoTipo.Enabled = IndicaActivo
        'cmbPagoBanco.Enabled = IndicaActivo
        cmbPagoMoneda.Enabled = IndicaActivo
        'ckbIndicaPrimeraCompra.Enabled = IndicaActivo
        'ckbIndicaAscenso.Enabled = IndicaActivo
        'ckbIndicaMantenimiento.Enabled = IndicaActivo
        'ckbIndicaCompraExtra.Enabled = IndicaActivo
        'ckbIndicaAnulado.Enabled = IndicaActivo

        txtOrdenFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtVendedorCodigo.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtDocumentoNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtPagoFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        'txtPagoImporte.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtPagoReferencia.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)

        txtOrdenFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtVendedorCodigo.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtDocumentoNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtPagoFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtPagoImporte.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtPagoReferencia.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)

        If IndicaActivo = True Then txtOrdenFecha.Focus()
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        txtProducto.Enabled = IndicaActivo
        txtCantidad.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo : btnDescartar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3) : btnDescartar.ImageIndex = IIf(IndicaActivo = True, 0, 2)
        cmbProductos.SelectedIndex = -1
        gvOrdenPedidoLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Function BuscarPrecioUnitario() As Decimal
        Dim MyPrecio As dsListaPrecios.LISTA_PRECIOS_DETRow
        Dim PrimaryKey(2) As Object

        PrimaryKey(0) = MyUsuario.empresa
        PrimaryKey(1) = MyOrdenPedido.lista_precio
        PrimaryKey(2) = MyProducto.producto

        MyPrecio = MyListaPrecio.Rows.Find(PrimaryKey)

        If Not (MyPrecio Is Nothing) Then
            Return MyPrecio.VALOR_VENTA_ME
        Else
            Return 0
        End If
    End Function

    Private Function BuscarCantidad() As Decimal
        Dim MyDetalle As dsOrdenPedido.DETALLES_PEDIDORow

        Dim PrimaryKey(2) As Object

        PrimaryKey(0) = MyUsuario.empresa
        PrimaryKey(1) = MyOrdenPedido.orden_pedido
        PrimaryKey(2) = MyProducto.producto

        MyDetalle = MyDetallesPedido.Rows.Find(PrimaryKey)

        If Not (MyDetalle Is Nothing) Then
            txtEditado.Text = "E"
            txtVenta.Text = MyDetalle.VENTA
            txtVentaLinea.Text = MyDetalle.VENTA_LINEA
            Return MyDetalle.CANTIDAD
        Else
            txtEditado.Text = Nothing
            txtVenta.Text = CUO_Nulo
            txtVentaLinea.Text = "000"
            Return 0
        End If
    End Function

    Private Sub ActualizarGrilla()
        Dim MyTotal As Decimal = 0
        txtEditado.Text = Nothing
        txtProducto.Text = Nothing
        cmbProductos.SelectedIndex = -1
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)
        txtPrecioTotal.Text = EvalDato(0, txtPrecioTotal.Tag)
        txtVenta.Text = Nothing
        txtVentaLinea.Text = Nothing

        MyDetallesPedido = dalOrdenPedido.ObtenerDetalles(MyOrdenPedido.orden_pedido)
        gvOrdenPedidoLineas.DataSource = MyDetallesPedido

        If MyDetallesPedido.Rows.Count <> 0 Then
            For NumReg As Integer = 0 To MyDetallesPedido.Rows.Count - 1
                MyTotal = MyTotal + MyDetallesPedido(NumReg).IMPORTE_TOTAL_ME
            Next
            Call dalOrdenPedido.ActualizarPagoImporte(txtOrdenPedido.Text, MyTotal)
        End If

        txtPagoImporte.Text = EvalDato(MyTotal, txtPagoImporte.Tag)
        gvOrdenPedidoLineas.ClearSelection()
        txtProducto.Focus()
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
                    cmbPagoTipo.Focus()
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
            cmbPagoTipo.Focus()
        Else
            If MyVendedor = Nothing Then
                txtVendedorNombre.Text = Nothing
                txtVendedorCodigo.Text = Nothing
                txtVendedorCodigo.Focus()
            Else
                cmbPagoTipo.Focus()
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
            Dim MyForm As New frmProductoLista(MyProducto, "SN", "A")
            MyForm.ShowDialog()
        Else
            MyProducto = dalProducto.Obtener(MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            MyPrecio = BuscarPrecioUnitario()
            txtProducto.Text = MyProducto.producto
            cmbProductos.SelectedValue = MyProducto.producto
            If gvOrdenPedidoLineas.RowCount <> 0 Then
                MyCantidad = BuscarCantidad()
                txtCantidad.Text = EvalDato(MyCantidad, txtCantidad.Tag)
            Else
                txtEditado.Text = Nothing
                txtVenta.Text = CUO_Nulo
                txtVentaLinea.Text = "000"
            End If
            txtCantidad.Focus()
        Else
            cmbProductos.SelectedIndex = -1
            txtEditado.Text = Nothing
            txtVenta.Text = Nothing
            txtVentaLinea.Text = Nothing
            txtCantidad.Text = "0.00"
            txtProducto.Text = Nothing
            txtProducto.Focus()
        End If
        txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)
        Call ActualizarValores()
    End Sub

#End Region


End Class
