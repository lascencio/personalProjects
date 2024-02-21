Public Class frmSeparacionVehiculo

    Private MyCuentaComercial As New entCuentaComercial
    Private MyGrupoComercial As New entGrupoComercial

    Private MySeparacion As entVenta
    Private MySeparacionDetalle As dsVentas.VENTA_DETDataTable
    Private MySeparacionDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable
    Private MySeparacionVehiculo As dsVentas.VENTAS_VEHICULOSDataTable

    Private MyStockActual As New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
    Private MyProducto As entProducto

    Private ActualizarCombos As Boolean

    Private SaltarSiguiente As Boolean = True

    Private MyControlVehiculos As dsProductos.CONTROL_VEHICULOSDataTable

    Private Sub frmSeparacionVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmSeparacionVehiculo_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaEmpresa(cmbCategoriaVehicular, "OPE_CATEGORIA")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
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

    Private Sub ValidarFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.Validated
        Dim MyFecha As Date
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If txtVenta.Text.Trim.Length = 0 Then
                    MyFecha = CDate(txtFecha.Text)
                    If MyFecha > MyFechaServidor Then
                        Resp = MsgBox("La fecha a registrar no debe ser mayor de hoy.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                    Else
                        cmbTipoMoneda.Focus()
                    End If
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

    Private Sub txtPrecioUnitario_Validated(sender As Object, e As EventArgs) Handles txtPrecioUnitario.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub

    Private Sub txtPrecioUnitario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioUnitario.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim PrecioUnitario As Decimal

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            sender.Text = EvalDato(sender.Text, sender.Tag)
            PrecioUnitario = CDec(sender.Text)

            MySeparacionDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
            SaltarSiguiente = False
            ' MyProducto.producto_tipo = "001" - Vehicular
            Dim MyForm As New frmVentaDetalleSeriesVehiculares(cmbAlmacen.SelectedValue, txtProducto.Text, 1, MySeparacionDetalleSeries)
            MyForm.ShowDialog()
            SaltarSiguiente = True

            If MySeparacionDetalleSeries.Rows.Count <> 0 Then
                If MySeparacionDetalleSeries(0).ESTADO <> "D" Then
                    Resp = MsgBox("La serie seleccionada no se encuentra disponible para la venta.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                    Call LimpiarLinea()
                Else
                    Call GuardarDetalle()
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
            If txtDocumentoNumero.Text.Trim.Length <> 0 Then Call ValidarDocumento()
            txtDocumentoNumero.Focus()
            ActualizarCombos = True
        End If
    End Sub

    Private Sub ValidarPesos_Validated(sender As Object, e As EventArgs) Handles txtPesoNeto.Validated, txtCargaUtil.Validated
        Dim PesoNeto As Decimal
        Dim CargaUtil As Decimal
        Dim PesoBruto As Decimal

        sender.Text = EvalDato(sender.Text, sender.Tag)

        PesoNeto = txtPesoNeto.Text
        CargaUtil = txtCargaUtil.Text
        PesoBruto = PesoNeto + CargaUtil

        txtPesoBruto.Text = EvalDato(PesoBruto, txtPesoBruto.Tag)
    End Sub

    Private Sub ValidarPotencia_Validated(sender As Object, e As EventArgs) Handles txtPotenciaHP.Validated, txtPotenciaKW.Validated
        Dim PotenciaHP As Decimal
        Dim PotenciaKW As Decimal

        sender.Text = EvalDato(sender.Text, sender.Tag)

        If sender.Name = "txtPotenciaHP" Then
            PotenciaHP = CDec(txtPotenciaHP.Text)
            PotenciaKW = Math.Round(PotenciaHP / 1.34, 2)
            txtPotenciaKW.Text = EvalDato(PotenciaKW, txtPotenciaKW.Tag)
        Else
            PotenciaKW = CDec(txtPotenciaKW.Text)
            PotenciaHP = Math.Round(PotenciaKW / 0.74, 2)
            txtPotenciaHP.Text = EvalDato(PotenciaHP, txtPotenciaHP.Tag)
        End If

        txtTorqueNM.Focus()
    End Sub

    Private Sub ValidarImportes_Validated(sender As Object, e As EventArgs) Handles txtAñoFabricacion.Validated, txtCapacidadMotor.Validated, txtNumeroCilindros.Validated, txtTorqueNM.Validated, txtTorqueRPM.Validated, txtNumeroRPM.Validated, txtNumeroAsientos.Validated, txtNumeroPasajeros.Validated, txtNumeroRuedas.Validated, txtNumeroEjes.Validated, txtLongitudLargo.Validated, txtLongitudAncho.Validated, txtLongitudAltura.Validated, txtPolizaAño.Validated, txtPolizaItem.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyGrupoComercial = New entGrupoComercial

        MySeparacion = New entVenta
        MySeparacionDetalle = New dsVentas.VENTA_DETDataTable
        MySeparacionDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
        MySeparacionVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        MyControlVehiculos = New dsProductos.CONTROL_VEHICULOSDataTable

        MyStockActual = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MyProducto = New entProducto

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        cmbAlmacen.SelectedValue = MyUsuario.almacen
        cmbTipoMoneda.SelectedValue = "1"
        cmbDocumentoTipo.SelectedValue = "1"
        txtCombustible.Text = "GASOLINA"
        cmbCategoriaVehicular.SelectedValue = "L3"

        EnableTextBox(txtRazonSocial, False)
        EnableTextBox(txtDomicilio, False)

        EnableComboBox(cmbDepartamento, False)
        EnableComboBox(cmbProvincia, False)
        EnableComboBox(cmbDistrito, False)

        EnableTextBox(txtTelefono, False)
        EnableTextBox(txtProducto, True)

        ActualizarCombos = True

        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"

        ckbIndicaAnulado.Visible = False

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbTipoMoneda, IndicaActivo)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)

        'EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)

        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtPrecioUnitario, IndicaActivo)
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
        Dim StockDisponible As Boolean = True

        MyStockActual = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MyProducto = New entProducto
        MyCodigo = txtProducto.Text.Trim

        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto, "SN", "A")
            MyForm.ShowDialog()
            If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & CStr(Val(MyCodigo.Trim)), 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            txtProducto.Text = MyProducto.producto
            txtProductoDescripcion.Text = MyProducto.descripcion_ampliada
            txtVehiculoMarca.Text = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProducto.producto_familia, False)
            txtVehiculoModelo.Text = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProducto.producto_sub_familia, False)

            txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)

            MyStockActual = dalOperacionAlmacen.StockProducto(txtProducto.Text, cmbAlmacen.SelectedValue)
            If MyStockActual.Rows.Count <> 0 Then
                txtCantidadStock.Text = EvalDato(MyStockActual(0).STOCK, txtCantidadStock.Tag)
            Else
                txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
            End If

            If CDec(txtCantidadStock.Text) = 0 Then
                Resp = MsgBox("No existe stock del artículo " & txtProductoDescripcion.Text, MsgBoxStyle.Exclamation, "VENTA VEHICULAR")
                StockDisponible = False
            End If

            If StockDisponible = False Then
                Call LimpiarLinea()
            Else
                MyControlVehiculos = dalOperacionAlmacen.ObtenerControlVehiculo(MyUsuario.empresa, MyProducto.producto)
                If MyControlVehiculos.Rows.Count <> 0 Then
                    With MyControlVehiculos(0)
                        txtCapacidadMotor.Text = EvalDato(.CAPACIDAD_MOTOR, txtCapacidadMotor.Tag)
                        txtNumeroCilindros.Text = EvalDato(.NUMERO_CILINDROS, txtNumeroCilindros.Tag)
                        txtPotenciaHP.Text = EvalDato(.POTENCIA_HP, txtPotenciaHP.Tag)
                        txtPotenciaKW.Text = EvalDato(.POTENCIA_KW, txtPotenciaKW.Tag)
                        txtTorqueNM.Text = EvalDato(.TORQUE_NM, txtTorqueNM.Tag)
                        txtTorqueRPM.Text = EvalDato(.TORQUE_RPM, txtTorqueRPM.Tag)
                        txtNumeroRPM.Text = EvalDato(.NUMERO_RPM, txtNumeroRPM.Tag)
                        txtPesoNeto.Text = EvalDato(.PESO_NETO, txtPesoNeto.Tag)
                        txtCargaUtil.Text = EvalDato(.CARGA_UTIL, txtCargaUtil.Tag)
                        txtPesoBruto.Text = EvalDato(.PESO_BRUTO, txtPesoBruto.Tag)
                        txtNumeroAsientos.Text = EvalDato(.NUMERO_ASIENTOS, txtNumeroAsientos.Tag)
                        txtNumeroPasajeros.Text = EvalDato(.NUMERO_PASAJEROS, txtNumeroPasajeros.Tag)
                        txtNumeroRuedas.Text = EvalDato(.NUMERO_RUEDAS, txtNumeroRuedas.Tag)
                        txtNumeroEjes.Text = EvalDato(.NUMERO_EJES, txtNumeroEjes.Tag)
                        txtLongitudLargo.Text = EvalDato(.LONGITUD_LARGO, txtLongitudLargo.Tag)
                        txtLongitudAncho.Text = EvalDato(.LONGITUD_ANCHO, txtLongitudAncho.Tag)
                        txtLongitudAltura.Text = EvalDato(.LONGITUD_ALTURA, txtLongitudAltura.Tag)
                        txtCombustible.Text = .COMBUSTIBLE
                        cmbCategoriaVehicular.SelectedValue = .CATEGORIA_VEHICULAR
                    End With
                End If
                EnableTextBox(txtProductoDescripcion, False)
                txtPrecioUnitario.Focus()
            End If
        Else
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub LimpiarLinea()
        txtProducto.Text = Nothing
        txtProductoDescripcion.Text = Nothing
        txtProducto.Focus()
        txtVenta.Text = Nothing
        txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)

        txtVehiculoMarca.Text = Nothing
        txtVehiculoModelo.Text = Nothing
        txtNumeroSerie.Text = Nothing
        txtNumeroSerieChasis.Text = Nothing
        txtColor.Text = Nothing

        EnableTextBox(txtProducto, True)
        EnableTextBox(txtProductoDescripcion, False)

        txtProducto.Focus()
    End Sub

    Private Sub GuardarDetalle()
        Dim ImporteTotal As Decimal = CDec(txtPrecioUnitario.Text)

        Dim ValorVenta As Decimal = 0
        Dim Impuesto As Decimal = 0

        If txtProducto.Text.Trim.Length <> 0 Then
            MySeparacionDetalle = New dsVentas.VENTA_DETDataTable
            MySeparacionDetalle.Rows.Add("001", txtProducto.Text, txtProductoDescripcion.Text, ImporteTotal, 1, ImporteTotal, "SI", "NO", "NO", "NO")

            ValorVenta = Math.Round(ImporteTotal / (1 + (MyIGV / 100)), 2)
            Impuesto = ImporteTotal - ValorVenta

            txtImporteTotal.Text = EvalDato(ImporteTotal, txtImporteTotal.Tag)
            txtImpuesto.Text = EvalDato(Impuesto, txtImpuesto.Tag)
            txtBaseImponible.Text = EvalDato(ValorVenta, txtBaseImponible.Tag)

            txtNumeroSerie.Text = MySeparacionDetalleSeries(0).NUMERO_SERIE
            txtNumeroSerieChasis.Text = MySeparacionDetalleSeries(0).NUMERO_SERIE_CHASIS
            txtColor.Text = MySeparacionDetalleSeries(0).COLOR

            MyControlVehiculos = dalOperacionAlmacen.ObtenerControlVehiculo(MyUsuario.empresa, MyProducto.producto, txtNumeroSerie.Text.Trim)

            If MyControlVehiculos.Rows.Count <> 0 Then
                With MyControlVehiculos(0)
                    txtAñoFabricacion.Text = EvalDato(.AÑO_FABRICACION, txtAñoFabricacion.Tag)
                    txtPolizaNumero.Text = .POLIZA_NUMERO
                    txtPolizaAño.Text = EvalDato(.POLIZA_AÑO, txtPolizaAño.Tag)
                    txtPolizaItem.Text = EvalDato(.POLIZA_ITEM, txtPolizaItem.Tag)
                End With
            End If

            EnableTextBox(txtProducto, False)

            txtAñoFabricacion.Focus()
        End If
    End Sub

    Private Sub EvaluarExisteResumen()
        Dim MyProductoComponentesNew As dsProductos.PRODUCTO_COMPONENTESDataTable
        Dim CodigoProducto As String
        If MySeparacionDetalle.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MySeparacionDetalle.Rows.Count - 1
                CodigoProducto = MySeparacionDetalle(NEle).PRODUCTO

                If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MySeparacionDetalle(NEle).PRODUCTO) Then
                    MySeparacionDetalle(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                Else
                    MySeparacionDetalle(NEle).EXISTE_RESUMEN_ALMACEN = "NO"
                End If

                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MySeparacionDetalle(NEle).PRODUCTO) Then
                    MySeparacionDetalle(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                Else
                    MySeparacionDetalle(NEle).EXISTE_RESUMEN_PERIODO = "NO"
                End If
            Next

            If MySeparacionDetalleSeries.Rows.Count <> 0 Then
                For NFil As Integer = 0 To MySeparacionDetalleSeries.Rows.Count - 1
                    If dalControlSeries.EvaluarSiExisteControlSeries(MySeparacionDetalleSeries(NFil).PRODUCTO, MySeparacionDetalleSeries(NFil).NUMERO_SERIE) Then
                        MySeparacionDetalleSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub CapturarEncabezado()
        Dim MyTipoCambio As Decimal = 1

        With MySeparacion
            .empresa = MyUsuario.empresa
            .venta = txtVenta.Text
            .ejercicio = MyUsuario.ejercicio
            .mes = MyUsuario.mes.ToString("00")
            .almacen = cmbAlmacen.SelectedValue
            .cuenta_comercial = txtCuentaComercial.Text
            .tipo_moneda = cmbTipoMoneda.SelectedValue

            .base_imponible_gravada_origen = CDec(txtBaseImponible.Text)
            .igv_origen = CDec(txtImpuesto.Text)
            .importe_total_origen = CDec(txtImporteTotal.Text)

            .importe_saldo = IIf(.condicion_pago = "TG", 0, IIf(.condicion_pago = "00", 0, .importe_total_origen))

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

            .tipo_documento = MyCuentaComercial.tipo_documento
            .nro_documento = MyCuentaComercial.nro_documento
            .razon_social = MyCuentaComercial.razon_social
        End With
    End Sub

    Private Sub CrearCliente()
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
            MySeparacion.cuenta_comercial = MyCuentaComercial.cuenta_comercial
        End If

        MySeparacionVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        With MySeparacionVehiculo
            .Rows.Add(MyUsuario.empresa, Space(1), txtProducto.Text, txtNumeroSerie.Text.Trim, txtNumeroSerieChasis.Text.Trim, txtColor.Text.Trim, CDec(txtAñoFabricacion.Text), _
                      txtVehiculoMarca.Text, txtVehiculoModelo.Text, CDec(txtCapacidadMotor.Text), CDec(txtNumeroCilindros.Text), CDec(txtPotenciaHP.Text), _
                      CDec(txtPotenciaKW.Text), CDec(txtTorqueNM.Text), CDec(txtTorqueRPM.Text), CDec(txtNumeroRPM.Text), CDec(txtPesoNeto.Text), _
                      CDec(txtCargaUtil.Text), CDec(txtPesoBruto.Text), CDec(txtNumeroAsientos.Text), CDec(txtNumeroPasajeros.Text), CDec(txtNumeroRuedas.Text), _
                      CDec(txtNumeroEjes.Text), txtCombustible.Text.Trim, CDec(txtLongitudLargo.Text), CDec(txtLongitudAncho.Text), CDec(txtLongitudAltura.Text), _
                      txtPolizaNumero.Text.Trim, CDec(txtPolizaAño.Text), CDec(txtPolizaItem.Text), Space(1), cmbCategoriaVehicular.SelectedValue, txtNumeroSerieChasis.Text.Trim, _
                      "A", MyUsuario.usuario, Now.Date, MyUsuario.usuario, Now.Date)
        End With

    End Sub

    Private Sub PoblarFormulario()
        Dim PermitirModificar As Boolean = True
        Dim MensajeModificar As String = ""
        Dim Venta As String = MySeparacion.venta
        Call LimpiarFormulario()
        MySeparacion = dalVenta.Obtener(Venta)
        If Not MySeparacion.venta Is Nothing Then
            MySeparacionVehiculo = dalVenta.ObtenerSeparacionVehiculo(MyUsuario.empresa, MySeparacion.venta)
            If MySeparacionVehiculo.Rows.Count = 0 Then
                Resp = MsgBox("El Comprobante " & MySeparacion.comprobante_serie & "-" & MySeparacion.comprobante_numero & " no ha sido registrado por esta opción.", MsgBoxStyle.Exclamation, "VENTA VEHICULAR")
                Call LimpiarFormulario()
            Else
                With MySeparacionVehiculo(0)
                    txtVehiculoMarca.Text = .MARCA
                    txtVehiculoModelo.Text = .MODELO
                    txtNumeroSerie.Text = .NUMERO_SERIE
                    txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                    txtColor.Text = .COLOR
                    txtCapacidadMotor.Text = EvalDato(.CAPACIDAD_MOTOR, txtCapacidadMotor.Tag)
                    txtNumeroCilindros.Text = EvalDato(.NUMERO_CILINDROS, txtNumeroCilindros.Tag)
                    txtPotenciaHP.Text = EvalDato(.POTENCIA_HP, txtPotenciaHP.Tag)
                    txtPotenciaKW.Text = EvalDato(.POTENCIA_KW, txtPotenciaKW.Tag)
                    txtTorqueNM.Text = EvalDato(.TORQUE_NM, txtTorqueNM.Tag)
                    txtTorqueRPM.Text = EvalDato(.TORQUE_RPM, txtTorqueRPM.Tag)
                    txtNumeroRPM.Text = EvalDato(.NUMERO_RPM, txtNumeroRPM.Tag)
                    txtPesoNeto.Text = EvalDato(.PESO_NETO, txtPesoNeto.Tag)
                    txtCargaUtil.Text = EvalDato(.CARGA_UTIL, txtCargaUtil.Tag)
                    txtPesoBruto.Text = EvalDato(.PESO_BRUTO, txtPesoBruto.Tag)
                    txtNumeroAsientos.Text = EvalDato(.NUMERO_ASIENTOS, txtNumeroAsientos.Tag)
                    txtNumeroPasajeros.Text = EvalDato(.NUMERO_PASAJEROS, txtNumeroPasajeros.Tag)
                    txtNumeroRuedas.Text = EvalDato(.NUMERO_RUEDAS, txtNumeroRuedas.Tag)
                    txtNumeroEjes.Text = EvalDato(.NUMERO_EJES, txtNumeroEjes.Tag)
                    txtLongitudLargo.Text = EvalDato(.LONGITUD_LARGO, txtLongitudLargo.Tag)
                    txtLongitudAncho.Text = EvalDato(.LONGITUD_ANCHO, txtLongitudAncho.Tag)
                    txtLongitudAltura.Text = EvalDato(.LONGITUD_ALTURA, txtLongitudAltura.Tag)
                    txtAñoFabricacion.Text = EvalDato(.AÑO_FABRICACION, txtAñoFabricacion.Tag)
                    txtPolizaNumero.Text = .POLIZA_NUMERO
                    txtPolizaAño.Text = EvalDato(.POLIZA_AÑO, txtPolizaAño.Tag)
                    txtPolizaItem.Text = EvalDato(.POLIZA_ITEM, txtPolizaItem.Tag)
                    txtCombustible.Text = .COMBUSTIBLE
                    cmbCategoriaVehicular.SelectedValue = .CATEGORIA_VEHICULAR
                    MyControlVehiculos = dalOperacionAlmacen.ObtenerControlVehiculo(.EMPRESA, .PRODUCTO, .NUMERO_SERIE)
                End With

                With MySeparacion
                    cmbAlmacen.SelectedValue = MySeparacion.almacen

                    MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, .cuenta_comercial)

                    txtCuentaComercial.Text = .cuenta_comercial
                    txtRazonSocial.Text = MyCuentaComercial.razon_social
                    cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                    txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                    cmbTipoMoneda.SelectedValue = .tipo_moneda

                    txtDomicilio.Text = MyCuentaComercial.domicilio
                    cmbDepartamento.SelectedValue = MyCuentaComercial.departamento
                    cmbProvincia.SelectedValue = MyCuentaComercial.provincia
                    cmbDistrito.SelectedValue = MyCuentaComercial.ubigeo

                    txtVenta.Text = .venta
                    txtEjercicio.Text = .ejercicio
                    txtMes.Text = .mes

                    MySeparacionDetalle = dalVenta.ObtenerDetalles(MyUsuario.empresa, txtVenta.Text)
                    MySeparacionDetalleSeries = dalVenta.ObtenerDetalleSeries(MyUsuario.empresa, txtVenta.Text)

                    txtBaseImponible.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponible.Tag)
                    txtImpuesto.Text = EvalDato(.igv_origen, txtImpuesto.Tag)
                    txtImporteTotal.Text = EvalDato(.importe_total_origen, txtImporteTotal.Tag)

                    If MySeparacionDetalle.Rows.Count <> 0 Then
                        txtProducto.Text = MySeparacionDetalle(0).PRODUCTO
                        txtProductoDescripcion.Text = MySeparacionDetalle(0).DESCRIPCION_AMPLIADA
                        txtPrecioUnitario.Text = EvalDato(MySeparacionDetalle(0).PRECIO_UNITARIO, txtPrecioUnitario.Tag)

                        MyProducto = dalProducto.Obtener(MyUsuario.empresa, MySeparacionDetalle(0).PRODUCTO)

                        If Not MyProducto.empresa Is Nothing Then
                            txtVehiculoMarca.Text = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProducto.producto_familia, False)
                            txtVehiculoModelo.Text = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProducto.producto_sub_familia, False)
                        End If
                    End If

                    If MySeparacionDetalleSeries.Rows.Count <> 0 Then
                        txtNumeroSerie.Text = MySeparacionDetalleSeries(0).NUMERO_SERIE
                        txtNumeroSerieChasis.Text = MySeparacionDetalleSeries(0).NUMERO_SERIE_CHASIS
                        txtColor.Text = MySeparacionDetalleSeries(0).COLOR
                    End If

                    .tipo_documento = MyCuentaComercial.tipo_documento
                    .nro_documento = MyCuentaComercial.nro_documento
                    .razon_social = MyCuentaComercial.razon_social

                    Call dalVenta.ObtenerCuotaInicial(MySeparacion)

                    ActivarCabecera(False)

                    '' Solo es posible modificar si se cumple que:
                    '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó

                    If .estado = "N" Then
                        '' 2.- El movimiento no se encuentra anulado
                        PermitirModificar = False : MensajeModificar = "El comprobante se encuentra en estado ANULADO."
                    ElseIf MyControlVehiculos.Rows.Count <> 0 Then
                        If MyControlVehiculos(0).ESTADO = "D" Then
                            '' 5.- Si el número de serie no está disponible
                            PermitirModificar = False : MensajeModificar = "El número de serie de motor esta disponible para la venta."
                        End If
                    End If

                    ckbIndicaAnulado.Visible = True

                    If PermitirModificar = False Then
                        Resp = MsgBox("No es posible realizar cambios." & vbCrLf & MensajeModificar, MsgBoxStyle.Exclamation, "ANULAR COMPROBANTE DE VENTA")
                        ckbIndicaAnulado.Enabled = False
                        UC_ToolBar.btnGrabar_Visible = False
                    Else
                        ckbIndicaAnulado.Enabled = True
                        UC_ToolBar.btnGrabar_Visible = True
                    End If
                End With
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
            End If
        End If
    End Sub

    Private Function EvaluarContinuar() As Boolean
        Dim NombreCampo As String
        EvaluarContinuar = True

        If txtCuentaComercial.Text.Trim.Length = 0 Then
            If txtDocumentoNumero.Text.Trim.Length = 0 Then
                NombreCampo = "DOCUMENTO IDENTIDAD" : EnableTextBox(txtDocumentoNumero, True) : EvaluarContinuar = False : txtDocumentoNumero.Focus()
            ElseIf txtRazonSocial.Text.Trim.Length = 0 Then
                NombreCampo = "NOMBRE DEL ADQUIRIENTE" : EnableTextBox(txtRazonSocial, True) : EvaluarContinuar = False : txtRazonSocial.Focus()
            ElseIf txtDomicilio.Text.Trim.Length = 0 Then
                NombreCampo = "DOMICILIO DEL ADQUIRIENTE" : EnableTextBox(txtDomicilio, True) : EvaluarContinuar = False : txtDomicilio.Focus()
            End If
        ElseIf txtVehiculoMarca.Text.Trim.Length = 0 Then : NombreCampo = "MARCA" : EvaluarContinuar = False : txtVehiculoMarca.Focus()
        ElseIf txtVehiculoModelo.Text.Trim.Length = 0 Then : NombreCampo = "MODELO" : EvaluarContinuar = False : txtVehiculoModelo.Focus()
        ElseIf txtNumeroSerie.Text.Trim.Length = 0 Then : NombreCampo = "NUMERO SERIE MOTOR" : EvaluarContinuar = False : txtNumeroSerie.Focus()
        ElseIf txtNumeroSerieChasis.Text.Trim.Length = 0 Then : NombreCampo = "NUMERO SERIE CHASIS" : EvaluarContinuar = False : txtNumeroSerieChasis.Focus()
        ElseIf txtColor.Text.Trim.Length = 0 Then : NombreCampo = "COLOR" : EvaluarContinuar = False : txtColor.Focus()
        ElseIf CDec(txtAñoFabricacion.Text) = 0 Then : NombreCampo = "AÑO FABRICACION" : EvaluarContinuar = False : txtAñoFabricacion.Focus()

            'ElseIf CDec(txtCapacidadMotor.Text) = 0 Then : NombreCampo = "CAPACIDAD DEL MOTOR" : EvaluarContinuar = False :txtCapacidadMotor.Focus()
            'ElseIf CDec(txtNumeroCilindros.Text) = 0 Then : NombreCampo = "NUMERO DE CILINDROS" : EvaluarContinuar = False :txtNumeroCilindros.Focus()
            'ElseIf CDec(txtPotenciaHP.Text) = 0 Then : NombreCampo = "POTENCIA DE MOTOR" : EvaluarContinuar = False :txtPotenciaHP.Focus()
            'ElseIf CDec(txtPotenciaKW.Text) = 0 Then : NombreCampo = "POTENCIA DE MOTOR" : EvaluarContinuar = False :txtPotenciaKW.Focus()

            'ElseIf txtPolizaNumero.Text.Trim.Length = 0 Then : NombreCampo = "DUA - NUMERO" : EvaluarContinuar = False : txtPolizaNumero.Focus()
            'ElseIf CDec(txtPolizaAño.Text) = 0 Then : NombreCampo = "DUA - AÑO" : EvaluarContinuar = False : txtPolizaAño.Focus()
            'ElseIf CDec(txtPolizaItem.Text) = 0 Then : NombreCampo = "DUA - ITEM" : EvaluarContinuar = False : txtPolizaItem.Focus()

        End If

        If EvaluarContinuar = False Then Resp = MsgBox("Debe registrar información en el campo " & NombreCampo, MsgBoxStyle.Exclamation, "PROCESO CANCELADO")

        Return EvaluarContinuar
    End Function

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim MyImporteTotal As Decimal = CDec(txtImporteTotal.Text)

        If EvaluarContinuar() = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False
                Call EvaluarExisteResumen()
                Call CapturarEncabezado()
                Call CrearCliente()
                MySeparacion = dalVenta.GrabarSeparacionVehiculo(MySeparacion, MySeparacionDetalle, MySeparacionDetalleSeries, MySeparacionVehiculo)
                txtVenta.Text = MySeparacion.venta
                EnableTextBox(txtProducto, False)
                Resp = MsgBox("El Comprobante de Venta se grabó con éxito.", MsgBoxStyle.Information, "GRABAR COMPROBANTE")
                Call ActivarCabecera(False)
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
                If txtVenta.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
                If txtVenta.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            End Try

        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim ExisteControlVehiculo As Boolean = True
        Dim PeriodoTrabajo = MyUsuario.ejercicio & MyUsuario.mes.ToString("00")
        Dim PeriodoComprobante = txtEjercicio.Text & txtMes.Text

        If EvaluarContinuar() = True Then
            Try
                UC_ToolBar.btnGrabar_Visible = False
                If txtVenta.Text.Trim.Length <> 0 Then
                    If ckbIndicaAnulado.Checked = True Then
                        If PeriodoTrabajo <> PeriodoComprobante Then
                            Resp = MsgBox("Para anular el comprobante debe cambiar el periodo de trabajo al mes de " &
                                          UCase(EvalMes(PeriodoComprobante.Substring(4, 2), "L")) & " del " &
                                          PeriodoComprobante.Substring(0, 4), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                            Call LimpiarFormulario()
                        ElseIf MyControlVehiculos.Rows.Count <> 0 Then
                            If MyControlVehiculos(0).ESTADO = "D" Then
                                Resp = MsgBox("No es posible anular el Comprobante." & vbCrLf & _
                                              "El Número de Serie esta disponible.", MsgBoxStyle.Information, "PROCESO DENEGADO")
                                Call LimpiarFormulario()
                            End If
                        Else
                            Resp = MsgBox("Confirmar proceso de anulación del Comprobante.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR COMPROBANTE DE VENTA")
                            If Resp = 1 Then
                                MySeparacion.usuario_modifica = MyUsuario.usuario
                                'If dalXML.EliminarArchivos(MySeparacion.comprobante_tipo, MySeparacion.comprobante_serie, MySeparacion.comprobante_numero) = True Then
                                '    If dalVenta.AnularSeparacionVehiculo(MySeparacion, MySeparacionDetalleSeries) = True Then
                                '        Resp = MsgBox("El Comprobante se anuló con éxito.", MsgBoxStyle.Information, "ANULAR COMPROBANTE DE VENTA")
                                '        Call LimpiarFormulario()
                                '    Else
                                '        ckbIndicaAnulado.Checked = False
                                '        UC_ToolBar.btnEditar_Focus = True
                                '    End If
                                'Else
                                '    UC_ToolBar.btnGrabar_Visible = True
                                '    ckbIndicaAnulado.Checked = False
                                'End If
                            Else
                                UC_ToolBar.btnGrabar_Visible = True
                                ckbIndicaAnulado.Checked = False
                            End If
                        End If
                    Else
                        With MySeparacionVehiculo(0)
                            .NUMERO_SERIE_CHASIS = txtNumeroSerieChasis.Text
                            .COLOR = txtColor.Text
                            .AÑO_FABRICACION = CDec(txtAñoFabricacion.Text)
                            .MARCA = txtVehiculoMarca.Text
                            .MODELO = txtVehiculoModelo.Text
                            .CAPACIDAD_MOTOR = CDec(txtCapacidadMotor.Text)
                            .NUMERO_CILINDROS = CDec(txtNumeroCilindros.Text)
                            .POTENCIA_HP = CDec(txtPotenciaHP.Text)
                            .POTENCIA_KW = CDec(txtPotenciaKW.Text)
                            .TORQUE_NM = CDec(txtTorqueNM.Text)
                            .TORQUE_RPM = CDec(txtTorqueRPM.Text)
                            .NUMERO_RPM = CDec(txtNumeroRPM.Text)
                            .PESO_NETO = CDec(txtPesoNeto.Text)
                            .CARGA_UTIL = CDec(txtCargaUtil.Text)
                            .PESO_BRUTO = CDec(txtPesoBruto.Text)
                            .NUMERO_ASIENTOS = CDec(txtNumeroAsientos.Text)
                            .NUMERO_PASAJEROS = CDec(txtNumeroPasajeros.Text)
                            .NUMERO_RUEDAS = CDec(txtNumeroRuedas.Text)
                            .NUMERO_EJES = CDec(txtNumeroEjes.Text)
                            .COMBUSTIBLE = txtCombustible.Text
                            .LONGITUD_LARGO = CDec(txtLongitudLargo.Text)
                            .LONGITUD_ANCHO = CDec(txtLongitudAncho.Text)
                            .LONGITUD_ALTURA = CDec(txtLongitudAltura.Text)
                            .POLIZA_NUMERO = txtPolizaNumero.Text
                            .POLIZA_AÑO = CDec(txtPolizaAño.Text)
                            .POLIZA_ITEM = CDec(txtPolizaItem.Text)
                            .CATEGORIA_VEHICULAR = cmbCategoriaVehicular.SelectedValue
                        End With

                        'If dalVenta.ActualizarSeparacionVehiculo(MySeparacion, MySeparacionDetalleSeries, MySeparacionVehiculo) = True Then
                        '    Resp = MsgBox("El Comprobante se actualizó con éxito.", MsgBoxStyle.Information, "ACTUALIZAR COMPROBANTE DE VENTA")
                        '    Call LimpiarFormulario()
                        'End If
                    End If
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
                If txtVenta.Text.Trim.Length <> 0 Then UC_ToolBar.btnGrabar_Visible = True
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
                If txtVenta.Text.Trim.Length <> 0 Then UC_ToolBar.btnGrabar_Visible = True
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        'Dim MySeparacionNew As New entVenta
        'Dim MyCantidadControl As Integer = 0
        'Dim MyForm As New frmFacturacionProductosLista(MySeparacionNew, txtEjercicio.Text, txtMes.Text, "V", IIf(cmbComprobanteTipo.Text = "BOLETA", "B7", "F7"), "SN")
        'MyForm.ShowDialog()
        'If Not MySeparacionNew.venta Is Nothing Then
        '    MySeparacion = MySeparacionNew
        '    Call PoblarFormulario()
        'End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtVenta.Text.Trim.Length <> 0 Then
            MySeparacion.nro_documento = MyCuentaComercial.nro_documento
            MySeparacion.tipo_documento = MyCuentaComercial.tipo_documento
            MySeparacion.razon_social = MyCuentaComercial.razon_social
            UC_ToolBar.btnImprimir_Visible = False
            'If ckbIndicaAnulado.Checked = False Then
            '    Dim MyForm As New frmEComprobanteSeparacionVehiculoImprimir(MySeparacion, MyCuentaComercial, MyProducto, MySeparacionVehiculo)
            '    MyForm.ShowDialog()
            'End If
            UC_ToolBar.btnImprimir_Visible = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarLinea()
    End Sub

#End Region


End Class
