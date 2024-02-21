Public Class frmVentaVehiculo

    Private MyCuentaComercial As New entCuentaComercial
    Private MyGrupoComercial As New entGrupoComercial

    Private MyVenta As entVenta
    Private MyVentaDetalle As dsVentas.VENTA_DETDataTable
    Private MyVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable
    Private MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable
    Private MyControlVehiculos As dsProductos.CONTROL_VEHICULOSDataTable

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

    Private ActualizarCombos As Boolean

    Private SaltarSiguiente As Boolean = True

    Private Sub frmVentaVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmVentaVehiculo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyCondicionesPago As New dsTablasGenericas.LISTADataTable

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        'ActualizarListaGenerica(cmbCondicionPago, "COM_CONDICION_PAGO")
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaEmpresa(cmbCategoriaVehicular, "OPE_CATEGORIA")

        MyCondicionesPago = ObtenerListaEmpresa("COM_CONDICION_PAGO", False)
        MyCondicionesPago.Rows.Add("COM_CONDICION_PAGO", "FD", "FINANCIMIENTO DIRECTO", "FINANCIMIENTO DIRECTO", Space(1), False)
        cmbCondicionPago.DataSource = MyCondicionesPago

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

    Private Sub cmbCondicionPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCondicionPago.SelectedIndexChanged
        If cmbCondicionPago.SelectedIndex <> -1 Then
            If ActualizarCombos Then
                If cmbCondicionPago.SelectedValue = "FD" Then
                    EnableTextBox(txtCuotaInicial, True)
                    EnableTextBox(txtCuotaInicialPagada, True)
                Else
                    EnableTextBox(txtCuotaInicial, False)
                    EnableTextBox(txtCuotaInicialPagada, False)
                End If
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

            If txtIndicaSerie.Text = "SI" And PrecioUnitario <> 0 Then
                MyVentaDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
                SaltarSiguiente = False
                ' MyProducto.producto_tipo = "001" - Vehicular
                Dim MyForm As New frmVentaDetalleSeriesVehiculares(cmbAlmacen.SelectedValue, txtProducto.Text, 1, MyVentaDetalleSeries)
                MyForm.ShowDialog()
                SaltarSiguiente = True

                If MyVentaDetalleSeries.Rows.Count <> 0 Then
                    If MyVentaDetalleSeries(0).ESTADO <> "D" Then
                        Resp = MsgBox("La serie seleccionada no se encuentra disponible para la venta.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                        Call LimpiarLinea()
                    Else
                        Call GuardarDetalle()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtComprobanteNumero_Validated(sender As Object, e As EventArgs) Handles txtComprobanteNumero.Validated
        Call ValidarNumeroComprobante()
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

    Private Sub ValidarCuotaInicial_Validated(sender As Object, e As EventArgs) Handles txtCuotaInicial.Validated, txtCuotaInicialPagada.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)

        If sender.Name = "txtCuotaInicial" Then
            txtCuotaInicialPagada.Focus()
        Else
            If txtCuotaInicialPagada.Text > txtCuotaInicial.Text Then txtCuotaInicialPagada.Text = "0.00"
        End If
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyGrupoComercial = New entGrupoComercial

        MyVenta = New entVenta
        MyVentaDetalle = New dsVentas.VENTA_DETDataTable
        MyVentaDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
        MyVentaVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        MyControlVehiculos = New dsProductos.CONTROL_VEHICULOSDataTable

        MyStockActual = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MyProducto = New entProducto

        MyPrecioUnitario = New entListaPreciosDetalle

        MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        cmbAlmacen.SelectedValue = MyUsuario.almacen
        cmbTipoMoneda.SelectedValue = "1"
        txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteVencimiento.Text = EvalDato(Now.Date, "F")
        cmbDocumentoTipo.SelectedValue = "1"
        cmbComprobanteTipo.SelectedIndex = 1
        cmbCondicionPago.SelectedValue = "FD"
        txtCombustible.Text = "GASOLINA"
        cmbCategoriaVehicular.SelectedValue = "L3"
        txtCantidad.Text = EvalDato(1, txtCantidad.Tag)

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

    Private Sub ActualizarVencimiento()
        Dim MyDias As Byte = 0
        Dim MyFechaVencimiento As Date
        If cmbCondicionPago.SelectedIndex <> -1 And txtComprobanteFecha.Text.Trim.Length <> 0 Then
            If cmbCondicionPago.SelectedValue = "TG" Or cmbCondicionPago.SelectedValue = "FD" Then
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

        'EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)

        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtPrecioUnitario, IndicaActivo)
        EnableTextBox(txtCantidad, IndicaActivo)

        EnableTextBox(txtCantidad, IndicaActivo)

        EnableComboBox(cmbComprobanteTipo, IndicaActivo)

        If IndicaActivo = True Then txtComprobanteFecha.Focus()
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

            If MyProducto.producto_familia.Substring(0, 2) = "ST" Then ' Servicio Técnico 
                EnableTextBox(txtCantidad, False)
                txtCantidad.Text = EvalDato(1, txtCantidad.Tag)
                txtIndicaSerie.Text = "NO"
                txtIndicaCompuesto.Text = "NO"
                txtCantidadStock.Text = EvalDato(1, txtCantidadStock.Tag)
            Else
                EnableTextBox(txtCantidad, True)
                txtPrecioUnitario.Text = EvalDato(MyPrecio, txtPrecioUnitario.Tag)

                txtIndicaSerie.Text = MyProducto.indica_serie
                txtIndicaCompuesto.Text = MyProducto.indica_compuesto

                MyStockActual = dalOperacionAlmacen.StockProducto(txtProducto.Text, cmbAlmacen.SelectedValue)
                If MyStockActual.Rows.Count <> 0 Then
                    txtCantidadStock.Text = EvalDato(MyStockActual(0).STOCK, txtCantidadStock.Tag)
                Else
                    txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
                End If

                If MyProducto.indica_valida_stock = "SI" Then
                    If CDec(txtCantidadStock.Text) = 0 Then
                        Resp = MsgBox("No existe stock del artículo " & txtProductoDescripcion.Text, MsgBoxStyle.Exclamation, "VENTA VEHICULAR")
                        StockDisponible = False
                    End If
                End If
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
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)

        txtVehiculoMarca.Text = Nothing
        txtVehiculoModelo.Text = Nothing
        txtNumeroSerie.Text = Nothing
        txtNumeroSerieChasis.Text = Nothing
        txtColor.Text = Nothing

        EnableTextBox(txtProducto, True)
        EnableTextBox(txtProductoDescripcion, False)
        EnableTextBox(txtCantidad, True)

        txtProducto.Focus()
    End Sub

    Private Sub GuardarDetalle()
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)
        Dim ImporteTotal As Decimal = Math.Round(Cantidad * PrecioUnitario, 2)

        Dim ValorVenta As Decimal = 0
        Dim Impuesto As Decimal = 0

        If txtProducto.Text.Trim.Length <> 0 Then
            MyVentaDetalle = New dsVentas.VENTA_DETDataTable
            MyVentaDetalle.Rows.Add("001", txtProducto.Text, txtProductoDescripcion.Text, PrecioUnitario, Cantidad, ImporteTotal, txtIndicaSerie.Text, "NO", "NO", txtIndicaCompuesto.Text)

            ValorVenta = Math.Round(ImporteTotal / (1 + (MyIGV / 100)), 2)
            Impuesto = ImporteTotal - ValorVenta

            txtImporteTotal.Text = EvalDato(ImporteTotal, txtImporteTotal.Tag)
            txtImpuesto.Text = EvalDato(Impuesto, txtImpuesto.Tag)
            txtBaseImponible.Text = EvalDato(ValorVenta, txtBaseImponible.Tag)

            txtNumeroSerie.Text = MyVentaDetalleSeries(0).NUMERO_SERIE
            txtNumeroSerieChasis.Text = MyVentaDetalleSeries(0).NUMERO_SERIE_CHASIS
            txtColor.Text = MyVentaDetalleSeries(0).COLOR

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
        If MyVentaDetalle.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyVentaDetalle.Rows.Count - 1
                CodigoProducto = MyVentaDetalle(NEle).PRODUCTO

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
            .tipo_operacion = IIf(cmbComprobanteTipo.Text = "BOLETA", "B7", "F7")
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

            .cuota_inicial = CDec(txtCuotaInicial.Text)
            .cuota_inicial_pagada = CDec(txtCuotaInicialPagada.Text)

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
            MyVenta.cuenta_comercial = MyCuentaComercial.cuenta_comercial
        End If

        MyVentaVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        With MyVentaVehiculo
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
        Dim Venta As String = MyVenta.venta
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            MyVentaVehiculo = dalVenta.ObtenerVentaVehiculo(MyUsuario.empresa, MyVenta.venta)
            If MyVentaVehiculo.Rows.Count = 0 Then
                Resp = MsgBox("El Comprobante " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero & " no ha sido registrado por esta opción.", MsgBoxStyle.Exclamation, "VENTA VEHICULAR")
                Call LimpiarFormulario()
            Else
                With MyVentaVehiculo(0)
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

                With MyVenta
                    cmbAlmacen.SelectedValue = MyVenta.almacen

                    MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, .cuenta_comercial)

                    txtCuentaComercial.Text = .cuenta_comercial
                    txtRazonSocial.Text = MyCuentaComercial.razon_social
                    cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                    txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                    cmbCondicionPago.SelectedValue = .condicion_pago
                    cmbTipoMoneda.SelectedValue = .tipo_moneda

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

                    cmbComprobanteTipo.Text = IIf(.tipo_operacion.Substring(0, 1) = "B", "BOLETA", "FACTURA")
                    cmbComprobanteSerie.SelectedValue = .comprobante_serie
                    txtComprobanteNumero.Text = .comprobante_numero
                    txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                    txtComprobanteVencimiento.Text = EvalDato(.comprobante_vencimiento, "F")

                    txtBaseImponible.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponible.Tag)
                    txtImpuesto.Text = EvalDato(.igv_origen, txtImpuesto.Tag)
                    txtImporteTotal.Text = EvalDato(.importe_total_origen, txtImporteTotal.Tag)

                    If MyVentaDetalle.Rows.Count <> 0 Then
                        txtProducto.Text = MyVentaDetalle(0).PRODUCTO
                        txtProductoDescripcion.Text = MyVentaDetalle(0).DESCRIPCION_AMPLIADA
                        txtPrecioUnitario.Text = EvalDato(MyVentaDetalle(0).PRECIO_UNITARIO, txtPrecioUnitario.Tag)

                        MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyVentaDetalle(0).PRODUCTO)

                        If Not MyProducto.empresa Is Nothing Then
                            txtVehiculoMarca.Text = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProducto.producto_familia, False)
                            txtVehiculoModelo.Text = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProducto.producto_sub_familia, False)
                        End If
                    End If

                    If MyVentaDetalleSeries.Rows.Count <> 0 Then
                        txtNumeroSerie.Text = MyVentaDetalleSeries(0).NUMERO_SERIE
                        txtNumeroSerieChasis.Text = MyVentaDetalleSeries(0).NUMERO_SERIE_CHASIS
                        txtColor.Text = MyVentaDetalleSeries(0).COLOR
                    End If

                    .tipo_documento = MyCuentaComercial.tipo_documento
                    .nro_documento = MyCuentaComercial.nro_documento
                    .razon_social = MyCuentaComercial.razon_social

                    Call dalVenta.ObtenerCuotaInicial(MyVenta)

                    txtCuotaInicial.Text = EvalDato(MyVenta.cuota_inicial, txtCuotaInicial.Tag)
                    txtCuotaInicialPagada.Text = EvalDato(MyVenta.cuota_inicial_pagada, txtCuotaInicial.Tag)

                    ActivarCabecera(False)

                    '' Solo es posible modificar si se cumple que:
                    '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó

                    If .estado = "N" Then
                        '' 2.- El movimiento no se encuentra anulado
                        PermitirModificar = False : MensajeModificar = "El comprobante se encuentra en estado ANULADO."
                    ElseIf .condicion_pago <> "00" And .importe_total_origen <> .importe_saldo Then
                        '' 3.- Para la Condicion de Pago es diferente a Contado Contra-Entrega, que el valor del campo IMPORTE_TOTAL_ORIGEN sea igual al del campo IMPORTE_SALDO
                        PermitirModificar = False
                        If .importe_saldo = 0 Then
                            MensajeModificar = "El comprobante se encuentra totalmente pagado."
                        Else
                            MensajeModificar = "El comprobante tiene pagos a cuenta, su saldo por pagar es de " & EvalDato(.importe_saldo, "D") & "."
                        End If
                    ElseIf .estado_envio <> "P" Then
                        '' 4.- Si no ha sido enviado a SUNAT
                        PermitirModificar = False : MensajeModificar = "El comprobante ya fué enviado a la SUNAT."
                    ElseIf MyControlVehiculos.Rows.Count <> 0 Then
                        If MyControlVehiculos(0).ESTADO = "D" Then
                            '' 5.- Si el número de serie no está disponible
                            PermitirModificar = False : MensajeModificar = "El número de serie de motor esta disponible para la venta."
                        End If
                    End If

                    If PermitirModificar = False Then
                        Resp = MsgBox("No es posible realizar cambios." & vbCrLf & MensajeModificar, MsgBoxStyle.Exclamation, "ANULAR COMPROBANTE DE VENTA")
                        UC_ToolBar.btnGrabar_Visible = False
                        ckbIndicaAnulado.Enabled = False
                        ckbIndicaAnulado.Visible = False
                    Else
                        ckbIndicaAnulado.Enabled = True
                        ckbIndicaAnulado.Visible = True
                        UC_ToolBar.btnGrabar_Visible = True
                    End If
                End With
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
            End If
        End If
    End Sub

    Private Sub ValidarNumeroComprobante()
        If IsNumeric(txtComprobanteNumero.Text) Then txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(txtComprobanteNumero.Text), txtComprobanteNumero.MaxLength)
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

        ElseIf cmbCondicionPago.SelectedValue = "FD" Then
            If CDec(txtCuotaInicial.Text) = 0 Then
                NombreCampo = "CUOTA INICIAL: IMPORTE" : EvaluarContinuar = False : txtCuotaInicial.Focus()
            ElseIf CDec(txtCuotaInicial.Text) = 0 Then
                NombreCampo = "CUOTA INICIAL: TOTAL PAGADO" : EvaluarContinuar = False : txtCuotaInicialPagada.Focus()
            End If
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
                MyVenta = dalVenta.GrabarVentaVehiculo(MyVenta, MyVentaDetalle, MyVentaDetalleSeries, MyVentaVehiculo)
                txtVenta.Text = MyVenta.venta
                txtComprobanteNumero.Text = MyVenta.comprobante_numero
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
        Dim ContinuarAnulación As Boolean = True

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
                            ContinuarAnulación = False
                        ElseIf MyControlVehiculos.Rows.Count <> 0 Then
                            If MyControlVehiculos(0).ESTADO = "D" Then
                                Resp = MsgBox("No es posible anular el Comprobante." & vbCrLf & _
                                              "El Número de Serie esta disponible.", MsgBoxStyle.Information, "PROCESO DENEGADO")
                                Call LimpiarFormulario()
                                ContinuarAnulación = False
                            End If
                        End If

                        If ContinuarAnulación = True Then
                            Resp = MsgBox("Confirmar proceso de anulación del Comprobante.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR COMPROBANTE DE VENTA")
                            If Resp = 1 Then
                                MyVenta.usuario_modifica = MyUsuario.usuario
                                If dalXML.EliminarArchivos(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero) = True Then
                                    If dalVenta.AnularVentaVehiculo(MyVenta, MyVentaDetalleSeries) = True Then
                                        Resp = MsgBox("El Comprobante se anuló con éxito.", MsgBoxStyle.Information, "ANULAR COMPROBANTE DE VENTA")
                                        Call LimpiarFormulario()
                                    Else
                                        ckbIndicaAnulado.Checked = False
                                        UC_ToolBar.btnEditar_Focus = True
                                    End If
                                Else
                                    UC_ToolBar.btnGrabar_Visible = True
                                    ckbIndicaAnulado.Checked = False
                                End If
                            Else
                                UC_ToolBar.btnGrabar_Visible = True
                                ckbIndicaAnulado.Checked = False
                            End If
                        End If
                    Else
                        With MyVentaVehiculo(0)
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

                        If dalVenta.ActualizarVentaVehiculo(MyVenta, MyVentaDetalleSeries, MyVentaVehiculo) = True Then
                            Resp = MsgBox("El Comprobante se actualizó con éxito.", MsgBoxStyle.Information, "ACTUALIZAR COMPROBANTE DE VENTA")
                            Call LimpiarFormulario()
                        End If
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
        Dim MyVentaNew As New entVenta
        Dim MyCantidadControl As Integer = 0
        Dim MyForm As New frmFacturacionProductosLista(MyVentaNew, txtEjercicio.Text, txtMes.Text, "V", IIf(cmbComprobanteTipo.Text = "BOLETA", "B7", "F7"), "SN")
        MyForm.ShowDialog()
        If Not MyVentaNew.venta Is Nothing Then
            MyVenta = MyVentaNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtVenta.Text.Trim.Length <> 0 Then
            MyVenta.nro_documento = MyCuentaComercial.nro_documento
            MyVenta.tipo_documento = MyCuentaComercial.tipo_documento
            MyVenta.razon_social = MyCuentaComercial.razon_social
            UC_ToolBar.btnImprimir_Visible = False
            If ckbIndicaAnulado.Checked = False Then
                Dim MyForm As New frmEComprobanteVentaVehiculoImprimir(MyVenta, MyCuentaComercial, MyProducto, MyVentaVehiculo)
                MyForm.ShowDialog()
            End If
            UC_ToolBar.btnImprimir_Visible = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarLinea()
    End Sub

#End Region


End Class
