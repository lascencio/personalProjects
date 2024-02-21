Public Class frmVentaDirecta

    Private MyCuentaComercial As New entCuentaComercial
    Private MyGrupoComercial As New entGrupoComercial

    Private MyVenta As entVenta
    Private MyVentaDetalle As dsVentas.VENTA_DETDataTable
    Private MyVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable

    Private MyStockActual As New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
    Private MyProducto As entProducto

    Private MyPrecioUnitario As entListaPreciosDetalle

    Private MyAsientoTipo As String = "05"
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String
    Private MyTipoCambio As Decimal

    Private FechaUltimoComprobante As Date

    Private MyDireccionEnvio As dsCuentasComerciales.DIRECCION_ENVIODataTable

    Private MyComponentes As dsProductos.COMPONENTESDataTable

    Private MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable

    Private ActualizarCombos As Boolean

    Private SaltarSiguiente As Boolean = True

    Private Sub frmFacturarProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFacturarProducto_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        ActualizarListaGenerica(cmbCondicionPago, "COM_CONDICION_PAGO")
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")

        ActualizarListaEmpresa(cmbFormaPago, "COM_FORMA_PAGO")

        Call LimpiarFormulario()

        If ExigirTipoCambio = True Then
            If MyTipoCambio = 0 Then
                Resp = MsgBox("Para continuar debe registrar el TIPO DE CAMBIO del " & EvalDato(MyAsientoFecha, "F") & ".", MsgBoxStyle.Information, Me.Text)
                UC_ToolBar.CambiarEstados(3, 3, False)
            Else
                UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
            End If
        End If

        If MyTipoCambio = 0 Then MyTipoCambio = 1

        'UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            If ActualizarCombos Then
                ActualizarTablaProvincia("_UBIGEO_PROVINCIA", cmbProvincia, cmbDepartamento.SelectedValue)
                cmbProvincia.Focus()
            End If
        End If
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            If ActualizarCombos Then
                ActualizarTablaUbigeo("_UBIGEO", cmbDistrito, cmbDepartamento.SelectedValue, cmbProvincia.SelectedValue)
                cmbDistrito.Focus()
            End If
        End If
    End Sub

    Private Sub cmbDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrito.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            txtProducto.Focus()
        End If
    End Sub

    Private Sub cmbCondicionPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCondicionPago.SelectedIndexChanged
        If cmbCondicionPago.SelectedIndex <> -1 Then
            If ActualizarCombos Then
                Call ActualizarVencimiento()
            End If
        End If
    End Sub

    Private Sub ValidarFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MyFecha As Date
        Dim MyFechaAño As String
        Dim MyFechaMes As String
        Dim MyFechaDia As String

        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If txtVenta.Text.Trim.Length = 0 Then
                    If sender.name = "txtComprobanteFecha" Then
                        MyFecha = CDate(txtComprobanteFecha.Text)
                        If MyFecha > MyFechaServidor Then
                            Resp = MsgBox("La fecha a registrar no debe ser mayor de hoy.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                            ReiniciarFecha()
                        Else
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
                                        Call ActualizarVencimiento()
                                        cmbTipoMoneda.Focus()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                If sender.name = "txtComprobanteFecha" Then Call ReiniciarFecha()
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

    Private Sub txtRazonSocial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRazonSocial.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDomicilio.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            txtProducto.Focus()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto()
        End If
    End Sub

    Private Sub ValidarPrecioUnitario_Validated(sender As Object, e As EventArgs) Handles txtPrecioUnitario.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If txtProducto.Text = "P0000000" Then ' Servicios varios
            btnAceptar.Focus()
        Else
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As EventArgs) Handles txtCantidad.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If CDec(sender.Text) = 0 Then
            txtProducto.Focus()
        Else
            If txtIndicaSerie.Text = "SI" Then
                Call ValidarBotonAceptar()
            Else
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumero As String = sender.text
        Dim IndicaRegistroValido As Boolean = True

        Dim CodigoProducto As String = ""

        Dim CantidadSolicitada As Decimal

        Dim MyVentaDetalleSeriesNew As New dsVentas.VENTA_DET_SERIESDataTable

        Dim CantidadStock As Decimal = CDec(txtCantidadStock.Text)

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            txtCantidad.Text = EvalDato(txtCantidad.Text, txtCantidad.Tag)
            CantidadSolicitada = CDec(txtCantidad.Text)

            If CantidadSolicitada > CantidadStock And MyProducto.indica_valida_stock = "SI" Then
                Resp = MsgBox("La cantidad registrada no puede ser mayor que el STOCK ACTUAL.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CANTIDAD NO VALIDA")
                txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
            Else
                If txtIndicaSerie.Text = "SI" And CantidadSolicitada <> 0 Then

                    If txtIndicaCompuesto.Text = "NO" Then
                        SaltarSiguiente = False
                        If MyProducto.producto_tipo = "001" Then
                            Dim MyForm As New frmVentaDetalleSeriesVehiculares(cmbAlmacen.SelectedValue, txtProducto.Text, CantidadSolicitada, MyVentaDetalleSeries)
                            MyForm.ShowDialog()
                        Else
                            Dim MyForm As New frmVentaDetalleSeries(cmbAlmacen.SelectedValue, txtProducto.Text, CantidadSolicitada, MyVentaDetalleSeries)
                            MyForm.ShowDialog()
                        End If
                        SaltarSiguiente = True
                        If CDec(txtCantidad.Text) = 0 Then IndicaRegistroValido = False

                        If MyVentaDetalleSeries.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                If MyVentaDetalleSeries(NEle).ESTADO = "N" Then
                                    IndicaRegistroValido = False
                                    CodigoProducto = MyVentaDetalleSeries(NEle).PRODUCTO
                                Else
                                    MyVentaDetalleSeriesNew.ImportRow(MyVentaDetalleSeries(NEle))
                                End If
                            Next
                        End If
                    Else
                        If MyComponentes.Rows.Count <> 0 Then
                            For NumFil As Integer = 0 To MyComponentes.Rows.Count - 1
                                If MyComponentes(NumFil).INDICA_SERIE = "SI" Then
                                    Dim MyForm As New frmVentaDetalleComponentesSeries(cmbAlmacen.SelectedValue, _
                                                                                       MyComponentes(NumFil).PRODUCTO, _
                                                                                       MyComponentes(NumFil).DESCRIPCION_AMPLIADA, _
                                                                                       MyComponentes(NumFil).CODIGO_COMPRA, _
                                                                                       CantidadSolicitada * MyComponentes(NumFil).CANTIDAD, MyVentaDetalleSeries)
                                    MyForm.ShowDialog()

                                    If CDec(txtCantidad.Text) = 0 Then IndicaRegistroValido = False

                                    If MyVentaDetalleSeries.Rows.Count <> 0 Then
                                        For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                            If MyVentaDetalleSeries(NEle).ESTADO = "N" Then IndicaRegistroValido = False
                                        Next
                                    End If
                                End If

                                If IndicaRegistroValido = False Then Exit For
                            Next

                            If IndicaRegistroValido = False Then
                                For NumFil As Integer = 0 To MyComponentes.Rows.Count - 1
                                    If MyVentaDetalleSeries.Rows.Count <> 0 Then
                                        For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                            If MyVentaDetalleSeries(NEle).PRODUCTO = MyComponentes(NumFil).PRODUCTO Then MyVentaDetalleSeries(NEle).ESTADO = "N"
                                        Next
                                    End If
                                Next
                            End If

                            If MyVentaDetalleSeries.Rows.Count <> 0 Then
                                For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                    If MyVentaDetalleSeries(NEle).ESTADO <> "N" Then
                                        MyVentaDetalleSeriesNew.ImportRow(MyVentaDetalleSeries(NEle))
                                    End If
                                Next
                            End If

                        End If
                    End If

                    If IndicaRegistroValido = True Then
                        Call ValidarBotonAceptar()
                    Else
                        MyVentaDetalleSeries = MyVentaDetalleSeriesNew
                        If MyVentaDetalle.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyVentaDetalle.Rows.Count - 1
                                If MyVentaDetalle(NEle).PRODUCTO = CodigoProducto Then
                                    MyVentaDetalle.Rows(NEle).Delete()
                                    Exit For
                                End If
                            Next
                            gvVentaLineas.DataSource = MyVentaDetalle
                        End If

                        Call LimpiarLinea()
                    End If
                Else
                    btnAceptar.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub gvVentaLineas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvVentaLineas.CellClick
        If sender.Enabled = True Then
            If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
                Dim MyIndex As Integer
                Dim CodigoProducto As String
                If Not sender.CurrentRow Is Nothing Then
                    MyIndex = sender.CurrentRow.Index
                    CodigoProducto = sender.Rows(MyIndex).Cells("PRODUCTO").Value
                    Dim MyVentaDetalleSeriesNew As New dsVentas.VENTA_DET_SERIESDataTable
                    If MyVentaDetalleSeries.Rows.Count <> 0 Then
                        If sender.Rows(MyIndex).Cells("INDICA_COMPUESTO").Value = "SI" Then
                            MyComponentes = dalProducto.ObtenerStockComponentes(MyUsuario.empresa, cmbAlmacen.SelectedValue, CodigoProducto)
                            If MyComponentes.Rows.Count <> 0 Then
                                For NFila As Integer = 0 To MyComponentes.Rows.Count - 1
                                    CodigoProducto = MyComponentes(NFila).PRODUCTO
                                    For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                        If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto Then MyVentaDetalleSeries(NEle).ESTADO = "N"
                                    Next
                                Next
                            End If
                        Else
                            For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                                If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto Then MyVentaDetalleSeries(NEle).ESTADO = "N"
                            Next
                        End If

                        For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                            If MyVentaDetalleSeries(NEle).ESTADO <> "N" Then
                                MyVentaDetalleSeriesNew.ImportRow(MyVentaDetalleSeries(NEle))
                            End If
                        Next
                    End If
                    MyVentaDetalleSeries = MyVentaDetalleSeriesNew
                    MyVentaDetalle.Rows(MyIndex).Delete()
                End If
                Call ActualizarTotales()
                sender.DataSource = MyVentaDetalle
                sender.ClearSelection()
            End If
        End If
    End Sub

    Private Sub txtComprobanteNumero_Validated(sender As Object, e As EventArgs) Handles txtComprobanteNumero.Validated
        Call ValidarNumeroComprobante()
    End Sub

    Private Sub ckbIndicaAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaAnulado.CheckedChanged
        If txtVenta.Text.Trim.Length <> 0 Then
            If MyVenta.estado = "V" Then
                If MyVenta.fecha_envio.Year <> 1900 Then
                    Resp = MsgBox("El comprobante ya fué enviado a SUNAT.", MsgBoxStyle.Critical, "PROCESO DENEGADO")
                Else
                    If ckbIndicaAnulado.Checked = True Then
                        UC_ToolBar.btnGrabar_Visible = True
                    Else
                        UC_ToolBar.btnGrabar_Visible = False
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub txtProductoDescripcion_Validated(sender As Object, e As EventArgs) Handles txtProductoDescripcion.Validated
        If sender.Text.Trim.Length Then txtPrecioUnitario.Focus()
    End Sub

    Private Sub cmbDocumentoTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDocumentoTipo.SelectedIndexChanged
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            ActualizarCombos = False
            If cmbDocumentoTipo.SelectedValue = "6" Then
                cmbComprobanteTipo.SelectedIndex = 0
                cmbComprobanteSerie.SelectedValue = "FT" & Strings.Right("00" & MyUsuario.serie_asignada, 2)
            Else
                cmbComprobanteTipo.SelectedIndex = 1
                cmbComprobanteSerie.SelectedValue = "BV" & Strings.Right("00" & MyUsuario.serie_asignada, 2)
            End If
            If txtDocumentoNumero.Text.Trim.Length <> 0 Then Call ValidarDocumento()
            txtDocumentoNumero.Focus()
            ActualizarCombos = True
        End If
    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            ActualizarCombos = False
            If sender.Text = "BOLETA" Then
                ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_BOLETAS")
            Else
                ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_FACTURAS")
            End If
            cmbComprobanteSerie.SelectedIndex = CInt(MyUsuario.serie_asignada) - 1
            ActualizarCombos = True
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyGrupoComercial = New entGrupoComercial

        MyVenta = New entVenta
        MyVentaDetalle = New dsVentas.VENTA_DETDataTable
        MyVentaDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable

        MyStockActual = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MyProducto = New entProducto

        MyPrecioUnitario = New entListaPreciosDetalle

        MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable

        MyProductoComponentes = New dsProductos.PRODUCTO_COMPONENTESDataTable

        InicializarFormulario(Me)

        gvVentaLineas.DataSource = MyVentaDetalle

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")

        MyTipoCambio = 1

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        cmbTipoMoneda.SelectedValue = "1"
        txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteVencimiento.Text = EvalDato(Now.Date, "F")
        cmbDocumentoTipo.SelectedValue = "1"
        cmbComprobanteTipo.SelectedIndex = 1
        cmbCondicionPago.SelectedValue = "00"
        cmbFormaPago.SelectedValue = "EF"

        EnableTextBox(txtRazonSocial, False)
        EnableTextBox(txtDomicilio, False)

        EnableComboBox(cmbDepartamento, False)
        EnableComboBox(cmbProvincia, False)
        EnableComboBox(cmbDistrito, False)

        EnableTextBox(txtTelefono, False)

        EnableTextBox(txtProducto, True)
        btnAceptar.Enabled = True
        EnableDataGridView(gvVentaLineas, True)
        ActualizarCombos = True

        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"

        ckbIndicaAnulado.Visible = False

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActualizarVencimiento()
        Dim MyDias As Byte = 0
        Dim MyFechaVencimiento As Date
        If cmbCondicionPago.SelectedIndex <> -1 And txtComprobanteFecha.Text.Trim.Length <> 0 Then
            If cmbCondicionPago.SelectedValue = "TG" Then
                MyDias = 0
            Else
                MyDias = CByte(cmbCondicionPago.SelectedValue)
            End If
            MyFechaVencimiento = DateAdd(DateInterval.Day, MyDias, CDate(txtComprobanteFecha.Text))
            txtComprobanteVencimiento.Text = EvalDato(MyFechaVencimiento, txtComprobanteVencimiento.Tag)
        End If
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbTipoMoneda, IndicaActivo)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableComboBox(cmbCondicionPago, IndicaActivo)
        EnableComboBox(cmbComprobanteTipo, IndicaActivo)

        EnableTextBox(txtDocumentoNumero, IndicaActivo)
        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtPrecioUnitario, IndicaActivo)
        EnableTextBox(txtCantidad, IndicaActivo)

        gvVentaLineas.Enabled = IndicaActivo

        btnAceptar.Enabled = IndicaActivo
        btnNuevo.Enabled = IndicaActivo

        If IndicaActivo = True Then txtDocumentoNumero.Focus()
    End Sub

    Private Sub ReiniciarFecha()
        txtTipoCambio.Text = "0.000"
        txtComprobanteVencimiento.Text = Nothing
        txtComprobanteFecha.Text = Nothing
        txtComprobanteFecha.Focus()
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            MyGrupoComercial = New entGrupoComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "SN")
                MyForm.ShowDialog()
                If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyCuentaComercial.cuenta_comercial)
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable
                EnableTextBox(txtRazonSocial, False)
                EnableTextBox(txtDomicilio, False)
                EnableComboBox(cmbDepartamento, False)
                EnableComboBox(cmbProvincia, False)
                EnableComboBox(cmbDistrito, False)
                EnableTextBox(txtTelefono, False)

                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                    cmbTipoMoneda.SelectedValue = .tipo_moneda
                    txtDomicilio.Text = .domicilio
                    cmbDepartamento.SelectedValue = .departamento
                    cmbProvincia.SelectedValue = .provincia
                    cmbDistrito.SelectedValue = .ubigeo
                    txtTelefono.Text = .telefono
                End With

                EnableComboBox(cmbComprobanteTipo, False)
                EnableComboBox(cmbDocumentoTipo, False)
                txtProducto.Focus()
            Else
                EnableTextBox(txtRazonSocial, True)
                EnableTextBox(txtDomicilio, True)
                EnableComboBox(cmbDepartamento, True)
                EnableComboBox(cmbProvincia, True)
                EnableComboBox(cmbDistrito, True)
                EnableTextBox(txtTelefono, True)

                If Not String.IsNullOrEmpty(MyDocumentoNumero) Then
                    txtCuentaComercial.Text = Nothing
                    txtRazonSocial.Text = Nothing
                    txtDomicilio.Text = Nothing
                    txtTelefono.Text = Nothing
                    txtRazonSocial.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub ValidarProducto()
        Dim MyCodigo As String = ""
        Dim MyPrecio As Decimal = 0
        Dim MyCantidad As Decimal = 0
        Dim MyStock As Decimal = 0

        MyStockActual = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MyProducto = New entProducto
        MyCodigo = txtProducto.Text.Trim

        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto, "SN", "A")
            MyForm.ShowDialog()
            If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            txtProducto.Text = MyProducto.producto
            txtProductoDescripcion.Text = MyProducto.descripcion_ampliada

            If MyProducto.producto_tipo = "STE" Then ' Servicio Técnico 
                txtCantidad.Text = EvalDato(1, txtCantidad.Tag)
                txtIndicaSerie.Text = "NO"
                txtIndicaCompuesto.Text = "NO"
                txtCantidadStock.Text = EvalDato(1, txtCantidadStock.Tag)

                EnableTextBox(txtProductoDescripcion, True)
                'EnableTextBox(txtCantidad, False)
                txtProductoDescripcion.Focus()

            ElseIf MyProducto.indica_vehicular = "SI" Then
                Resp = MsgBox("El producto " & MyProducto.descripcion_ampliada & " es vehicular." & vbCrLf & "No puede ser procesado en esta opción.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                Call LimpiarLinea()
            Else
                EnableTextBox(txtCantidad, True)
                txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)

                txtIndicaSerie.Text = MyProducto.indica_serie
                txtIndicaCompuesto.Text = MyProducto.indica_compuesto

                If MyProducto.indica_compuesto = "NO" Then
                    MyStockActual = dalOperacionAlmacen.StockProducto(txtProducto.Text, cmbAlmacen.SelectedValue)
                    If MyStockActual.Rows.Count <> 0 Then
                        txtCantidadStock.Text = EvalDato(MyStockActual(0).STOCK, txtCantidadStock.Tag)
                    Else
                        txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
                    End If
                Else
                    MyComponentes = dalProducto.ObtenerStockComponentes(MyUsuario.empresa, cmbAlmacen.SelectedValue, MyProducto.producto)
                    If MyComponentes.Rows.Count <> 0 Then
                        For NEle As Integer = 0 To MyComponentes.Rows.Count - 1
                            If MyComponentes(NEle).STOCK_ACTUAL > MyStock Then
                                MyStock = MyComponentes(NEle).STOCK_ACTUAL
                            End If
                        Next
                        If MyStock <> 0 Then
                            For NEle As Integer = 0 To MyComponentes.Rows.Count - 1
                                If MyComponentes(NEle).STOCK_ACTUAL < MyStock Then
                                    MyStock = MyComponentes(NEle).STOCK_ACTUAL
                                End If
                            Next
                        End If
                    End If
                    txtCantidadStock.Text = EvalDato(MyStock, txtCantidadStock.Tag)
                End If
                EnableTextBox(txtProductoDescripcion, False)
                EnableTextBox(txtCantidad, True)
                txtPrecioUnitario.Focus()
            End If
        Else
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub LimpiarLinea()
        txtIndicaSerie.Text = Nothing
        txtProducto.Text = Nothing
        txtProductoDescripcion.Text = Nothing
        txtProducto.Focus()
        txtVenta.Text = Nothing
        txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)
        EnableTextBox(txtProductoDescripcion, False)
        EnableTextBox(txtCantidad, True)
        txtProducto.Focus()
    End Sub

    Private Sub ValidarBotonAceptar()
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)

        If Cantidad = 0 Then
            Resp = MsgBox("Falta registrar un valor en el campo CANTIDAD.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PROCESO CANCELADO")
        ElseIf PrecioUnitario = 0 Then
            Resp = MsgBox("Falta registrar un valor en el campo PRECIO UNITARIO.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PROCESO CANCELADO")
        Else
            Call GuardarDetalle()
            txtProducto.Focus()
        End If
    End Sub

    Private Sub GuardarDetalle()
        Dim NumeroLinea As Byte = 0
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)
        Dim ImporteTotal As Decimal = Math.Round(Cantidad * PrecioUnitario, 2)

        Dim GrabarNuevaLinea As Boolean = True

        If txtProducto.Text.Trim.Length <> 0 Then
            If MyVentaDetalle.Rows.Count <> 0 Then
                For NEle As Byte = 0 To MyVentaDetalle.Rows.Count - 1
                    If MyVentaDetalle(NEle).PRODUCTO = txtProducto.Text Then
                        MyVentaDetalle(NEle).CANTIDAD = Cantidad
                        MyVentaDetalle(NEle).PRECIO_UNITARIO = PrecioUnitario
                        MyVentaDetalle(NEle).IMPORTE_TOTAL = ImporteTotal
                        GrabarNuevaLinea = False
                    End If
                    NumeroLinea = CByte(MyVentaDetalle(NEle).LINEA)
                Next
            End If

            If GrabarNuevaLinea = True Then
                NumeroLinea = NumeroLinea + 1
                MyVentaDetalle.Rows.Add(NumeroLinea, txtProducto.Text, txtProductoDescripcion.Text, PrecioUnitario, Cantidad, ImporteTotal, txtIndicaSerie.Text, "NO", "NO", txtIndicaCompuesto.Text)
            End If

            Call ActualizarTotales()

            gvVentaLineas.DataSource = MyVentaDetalle
            gvVentaLineas.ClearSelection()
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub ActualizarTotales()
        Dim ValorVenta As Decimal = 0
        Dim Impuesto As Decimal = 0
        Dim ImporteTotal As Decimal = 0
        Dim CondicionesPago As String = cmbCondicionPago.SelectedValue

        If MyVentaDetalle.Rows.Count <> 0 Then
            For NEle As Byte = 0 To MyVentaDetalle.Rows.Count - 1
                ImporteTotal = ImporteTotal + MyVentaDetalle(NEle).IMPORTE_TOTAL
            Next
        End If

        ValorVenta = Math.Round(ImporteTotal / (1 + (MyIGV / 100)), 2)
        Impuesto = ImporteTotal - ValorVenta

        txtImporteTotal.Text = EvalDato(ImporteTotal, txtImporteTotal.Tag)
        txtImpuesto.Text = EvalDato(Impuesto, txtImpuesto.Tag)
        txtBaseImponible.Text = EvalDato(ValorVenta, txtBaseImponible.Tag)
    End Sub

    Private Sub EvaluarExisteResumen()
        Dim MyProductoComponentesNew As dsProductos.PRODUCTO_COMPONENTESDataTable
        Dim CodigoProducto As String
        If MyVentaDetalle.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyVentaDetalle.Rows.Count - 1
                CodigoProducto = MyVentaDetalle(NEle).PRODUCTO

                If MyVentaDetalle(NEle).INDICA_COMPUESTO = "SI" Then
                    MyProductoComponentesNew = dalProducto.ObtenerProductoComponentes(MyUsuario.empresa, CodigoProducto)
                    If MyProductoComponentesNew.Rows.Count <> 0 Then
                        For NFila As Integer = 0 To MyProductoComponentesNew.Rows.Count - 1
                            If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyProductoComponentesNew(NFila).PRODUCTO) Then
                                MyProductoComponentesNew(NFila).EXISTE_RESUMEN_ALMACEN = "SI"
                            End If
                            If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyProductoComponentesNew(NFila).PRODUCTO) Then
                                MyProductoComponentesNew(NFila).EXISTE_RESUMEN_PERIODO = "SI"
                            End If
                            MyProductoComponentes.ImportRow(MyProductoComponentesNew(NFila))
                        Next
                    End If
                Else
                    If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyVentaDetalle(NEle).PRODUCTO) Then
                        MyVentaDetalle(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                    Else
                        MyVentaDetalle(NEle).EXISTE_RESUMEN_ALMACEN = "NO"
                    End If

                    If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyVentaDetalle(NEle).PRODUCTO) Then
                        MyVentaDetalle(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                    Else
                        MyVentaDetalle(NEle).EXISTE_RESUMEN_PERIODO = "NO"
                    End If
                End If
            Next

            If MyVentaDetalleSeries.Rows.Count <> 0 Then
                For NFil As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                    If dalControlSeries.EvaluarSiExisteControlSeries(MyVentaDetalleSeries(NFil).PRODUCTO, MyVentaDetalleSeries(NFil).NUMERO_SERIE) Then
                        MyVentaDetalleSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub CapturarEncabezado()
        With MyVenta
            .empresa = MyUsuario.empresa
            .venta = txtVenta.Text
            .ejercicio = MyAsientoEjercicio
            .mes = MyAsientoMes
            .almacen = cmbAlmacen.SelectedValue
            .tipo_operacion = IIf(cmbComprobanteTipo.Text = "BOLETA", "B3", "F3")
            .asiento_tipo = MyAsientoTipo
            .cuenta_comercial = txtCuentaComercial.Text
            .comprobante_tipo = IIf(cmbComprobanteTipo.Text = "BOLETA", "03", "01")
            .comprobante_serie = cmbComprobanteSerie.SelectedValue
            .comprobante_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then
                .comprobante_fecha = txtComprobanteFecha.Text
                .asiento_fecha = txtComprobanteFecha.Text
            End If
            If txtComprobanteVencimiento.Text.Length <> 0 Then .comprobante_vencimiento = txtComprobanteVencimiento.Text

            .tipo_cambio = CDec(txtTipoCambio.Text)
            .tipo_moneda = cmbTipoMoneda.SelectedValue
            .condicion_pago = cmbCondicionPago.SelectedValue
            .forma_pago = cmbFormaPago.SelectedValue

            .base_imponible_gravada_origen = CDec(txtBaseImponible.Text)
            .igv_origen = CDec(txtImpuesto.Text)
            .importe_total_origen = CDec(txtImporteTotal.Text)

            .importe_saldo = IIf(.condicion_pago = "TG", 0, .importe_total_origen) 'XXXX

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


            If MyCuentaComercial.grupo_comercial <> "G0000000" Then
                .codigo_vendedor = MyGrupoComercial.codigo_vendedor
                .grupo_comercial = MyCuentaComercial.grupo_comercial
            Else
                .codigo_vendedor = MyCuentaComercial.codigo_vendedor
            End If

            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "V")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario
        End With
    End Sub

    Private Sub PoblarFormulario()
        Dim Venta As String = MyVenta.venta
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            With MyVenta
                cmbAlmacen.SelectedValue = MyVenta.almacen

                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, .cuenta_comercial)

                txtCuentaComercial.Text = .cuenta_comercial
                txtRazonSocial.Text = MyCuentaComercial.razon_social
                cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                cmbCondicionPago.SelectedValue = .condicion_pago
                cmbTipoMoneda.SelectedValue = .tipo_moneda
                cmbFormaPago.SelectedValue = .forma_pago

                txtDomicilio.Text = MyCuentaComercial.domicilio
                cmbDepartamento.SelectedValue = MyCuentaComercial.departamento
                cmbProvincia.SelectedValue = MyCuentaComercial.provincia
                cmbDistrito.SelectedValue = MyCuentaComercial.ubigeo

                txtVenta.Text = .venta
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtTipoCambio.Text = EvalDato(.tipo_cambio, txtTipoCambio.Tag)

                MyVentaDetalle = dalVenta.ObtenerDetalles(MyUsuario.empresa, txtVenta.Text)

                MyVentaDetalleSeries = dalVenta.ObtenerDetalleSeries(MyUsuario.empresa, txtVenta.Text)

                gvVentaLineas.DataSource = MyVentaDetalle
                gvVentaLineas.ClearSelection()

                cmbComprobanteTipo.Text = IIf(.tipo_operacion.Substring(0, 1) = "B", "BOLETA", "FACTURA")
                cmbComprobanteSerie.SelectedValue = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                txtComprobanteVencimiento.Text = EvalDato(.comprobante_vencimiento, "F")

                txtBaseImponible.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponible.Tag)
                txtImpuesto.Text = EvalDato(.igv_origen, txtImpuesto.Tag)
                txtImporteTotal.Text = EvalDato(.importe_total_origen, txtImporteTotal.Tag)

                ActivarCabecera(False)

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
                    If .importe_total_origen = .importe_saldo Then
                        ckbIndicaAnulado.Enabled = True
                    Else
                        ckbIndicaAnulado.Enabled = False
                    End If
                End If
            End With
            UC_ToolBar.btnAceptar_Visible = False
            UC_ToolBar.btnImprimir_Visible = True
            UC_ToolBar.btnImprimir_Focus = True
        End If
    End Sub

    Private Sub ValidarNumeroComprobante()
        If IsNumeric(txtComprobanteNumero.Text) Then txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(txtComprobanteNumero.Text), txtComprobanteNumero.MaxLength)
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyCantidadControl As Integer = 0
        Dim MyVentaNew As New entVenta

        Dim MyForm As New frmFacturacionProductosLista(MyVentaNew, txtEjercicio.Text, txtMes.Text, "V", IIf(cmbComprobanteTipo.Text = "BOLETA", "B3", "F3"), "SN")
        MyForm.ShowDialog()
        If Not MyVentaNew.venta Is Nothing Then
            MyVenta = MyVentaNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtVenta.Text.Trim.Length <> 0 Then
            MyVenta.comentario = cmbFormaPago.Text

            Dim MyForm As New frmEComprobanteVentaImprimir(MyVenta, " ", MyCuentaComercial, False)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim MyImporteTotal As Decimal = CDec(txtImporteTotal.Text)
        Dim ContinuarGrabar As Boolean = True

        Dim AfectaSaldoDisponible As Boolean = True

        If cmbCondicionPago.SelectedValue = "00" Then AfectaSaldoDisponible = False
        If cmbCondicionPago.SelectedValue = "TG" Then AfectaSaldoDisponible = False
        If ckbIndicaAnulado.Checked = True Then AfectaSaldoDisponible = False

        If txtCuentaComercial.Text.Trim.Length = 0 Then
            If txtDocumentoNumero.Text.Trim.Length = 0 Then
                Resp = MsgBox("Debe registrar el número de documento de identidad.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                EnableTextBox(txtDocumentoNumero, True)
                txtDocumentoNumero.Focus()
                ContinuarGrabar = False
            ElseIf txtRazonSocial.Text.Trim.Length = 0 Then
                Resp = MsgBox("Debe registrar el nombre del adquiriente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                EnableTextBox(txtRazonSocial, True)
                txtRazonSocial.Focus()
                ContinuarGrabar = False
            ElseIf txtDomicilio.Text.Trim.Length = 0 Then
                Resp = MsgBox("Debe registrar el domicilio del adquiriente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                EnableTextBox(txtDomicilio, True)
                txtDomicilio.Focus()
                ContinuarGrabar = False
            End If
        End If

        If ContinuarGrabar = True Then
            If MyVentaDetalle.Rows.Count = 0 Then
                Resp = MsgBox("Debe registrar productos a vender.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            Else
                Call EvaluarExisteResumen()

                Call CapturarEncabezado()
                Try
                    UC_ToolBar.btnAceptar_Visible = False

                    If txtCuentaComercial.Text.Trim.Length = 0 Then
                        MyCuentaComercial = New entCuentaComercial
                        With MyCuentaComercial
                            .empresa = MyUsuario.empresa
                            .cuenta_comercial = txtCuentaComercial.Text.Trim
                            .tipo_documento = cmbDocumentoTipo.SelectedValue
                            .nro_documento = txtDocumentoNumero.Text.Trim
                            .razon_social = txtRazonSocial.Text.Trim
                            .domicilio = txtDomicilio.Text
                            .departamento = cmbDepartamento.SelectedValue
                            .provincia = cmbProvincia.SelectedValue
                            .ubigeo = cmbDistrito.SelectedValue
                            .telefono = txtTelefono.Text
                            .condicion_pago = "00"
                            .lista_precios = "LP0000000000"
                            .indica_cliente = "SI"
                            .indica_proveedor = "NO"
                            .estado = "A"
                            .usuario_registro = MyUsuario.usuario
                            .tipo_moneda = cmbTipoMoneda.SelectedValue
                        End With
                        MyCuentaComercial = dalCuentaComercial.Grabar(MyCuentaComercial)
                        MyVenta.cuenta_comercial = MyCuentaComercial.cuenta_comercial
                    End If

                    MyVenta = dalVenta.GrabarVentaDirecta(MyVenta, MyVentaDetalle, MyVentaDetalleSeries, MyProductoComponentes)
                    txtVenta.Text = MyVenta.venta
                    txtComprobanteNumero.Text = MyVenta.comprobante_numero
                    EnableTextBox(txtProducto, False)
                    btnAceptar.Enabled = False
                    EnableDataGridView(gvVentaLineas, False)
                    Resp = MsgBox("El Comprobante de Venta se grabó con éxito.", MsgBoxStyle.Information, "GRABAR COMPROBANTE")
                    Call ActivarCabecera(False)
                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If

    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim PeriodoTrabajo = MyUsuario.ejercicio & MyUsuario.mes.ToString("00")
        Dim PeriodoComprobante = txtEjercicio.Text & txtMes.Text

        Try
            If txtVenta.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                UC_ToolBar.btnGrabar_Visible = False
                If PeriodoTrabajo <> PeriodoComprobante Then
                    Resp = MsgBox("Para anular el comprobante debe cambiar el periodo de trabajo al mes de " &
                                  UCase(EvalMes(PeriodoComprobante.Substring(4, 2), "L")) & " del " &
                                  PeriodoComprobante.Substring(0, 4), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                    Call LimpiarFormulario()
                Else
                    Resp = MsgBox("Confirmar proceso de anulación del Comprobante de Venta.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR COMPROBANTE")
                    If Resp = 1 Then
                        If dalVenta.AnularVentaDirecta(MyVenta, MyVentaDetalle, MyVentaDetalleSeries, MyProductoComponentes) = True Then
                            Resp = MsgBox("El Comprobante de Venta se anuló con éxito.", MsgBoxStyle.Information, "ANULAR COMPROBANTE")
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarLinea()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim MyCantidadStock As Decimal = CDec(txtCantidadStock.Text)
        Dim MyCantidad As Decimal = CDec(txtCantidad.Text)

        If MyProducto.indica_valida_stock = "NO" Then
            Call ValidarBotonAceptar()
        ElseIf MyCantidadStock >= MyCantidad Then
            Call ValidarBotonAceptar()
        Else
            Call LimpiarLinea()
        End If
    End Sub

#End Region

End Class
