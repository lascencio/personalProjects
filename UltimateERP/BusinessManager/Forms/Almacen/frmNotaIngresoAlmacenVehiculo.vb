Public Class frmNotaIngresoAlmacenVehiculo

    Private MyOperacionAlmacen As entOperacionAlmacen
    Private MyOperacionAlmacenCompra As dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable
    Private MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
    Private MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
    Private MyControlVehiculos As dsProductos.CONTROL_VEHICULOSDataTable

    Private MyCuentaComercial As New entCuentaComercial
    Private MyProducto As entProducto

    Private MyTipoIngresoSalida As String = "I"
    Private MyStock As Decimal

    Private MyStockAlmacen As dsStockAlmacen.STOCK_X_ALMACENDataTable

    Private SaltarSiguiente As Boolean = True

    Private PeriodoTrabajo As String
    Private PeriodoOperacion As String

    'Private TipoCompra As String

    'Public ReadOnly Property TipoCompraProperty() As String
    '    Get
    '        Return TipoCompra
    '    End Get
    'End Property

    Private Sub frmNotaIngresoAlmacen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmNotaIngresoAlmacen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyCondicionPago As dsTablasGenericas.DETALLESDataTable
        Dim MyCondicionPagoNew As New dsTablasGenericas.DETALLESDataTable

        MyCondicionPago = CargarTablaGenerica("COM_CONDICION_PAGO")
        ActualizarListaEmpresa(cmbCategoriaVehicular, "OPE_CATEGORIA")

        If MyCondicionPago.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyCondicionPago.Rows.Count - 1
                If MyCondicionPago(NEle).CODIGO_ITEM <> "TG" Then
                    If Tipo_accion = "CREDITO" Then
                        If MyCondicionPago(NEle).CODIGO_ITEM <> "00" Then
                            MyCondicionPagoNew.ImportRow(MyCondicionPago(NEle))
                        End If
                    Else
                        MyCondicionPagoNew.ImportRow(MyCondicionPago(NEle))
                    End If
                End If
            Next
        End If

        PeriodoTrabajo = MyUsuario.periodo_actual

        cmbCondicionPago.DataSource = MyCondicionPagoNew

        cmbAlmacen.DataSource = MyDTAlmacenes
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaEmpresa(cmbComprobanteTipo, "COM_TIPO_COMPROBANTE")
        ActualizarListaGenerica(cmbComprobanteTipoMoneda, "_TIPO_MONEDA")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = True

        If Tipo_accion = "CONTADO" Then
            Me.lblTitulo.Text = "NOTA POR COMPRA VEHICULAR"
            Me.Text = "NOTA POR COMPRA VEHICULAR"
        ElseIf Tipo_accion = "CREDITO" Then
            Me.lblTitulo.Text = "NOTA POR COMPRA AL CREDITO"
            Me.Text = "NOTA POR COMPRA AL CREDITO"
            lblCondicionPago.Visible = True
            cmbCondicionPago.Visible = True
        ElseIf Tipo_accion = "CONSIGNACION" Then
            Me.lblTitulo.Text = "NOTA DE INGRESO POR CONSIGNACION"
            Me.Text = "NOTA DE INGRESO POR CONSIGNACION"
        End If
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCliente As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P", "SI")
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If
            Call ObtenerCuentaComercial()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto()
        End If
    End Sub

    Private Sub ValidarImporte(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioUnitario.Validated
        If sender.text.ToString.Length <> 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            txtNumeroSerie.Focus()
        End If
    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If cmbComprobanteTipo.SelectedIndex <> -1 Then txtComprobanteSerie.Focus()
    End Sub

    Private Sub txtComprobanteSerie_Validated(sender As Object, e As EventArgs) Handles txtComprobanteSerie.Validated
        If sender.text.ToString.Length <> 0 Then
            If IsNumeric(sender.Text) Then sender.Text = Strings.Right("0000" & sender.Text.Trim, 4)
            EvaluarExisteComprobante()
        End If
    End Sub

    Private Sub txtComprobanteNumero_Validated(sender As Object, e As EventArgs) Handles txtComprobanteNumero.Validated
        If sender.text.ToString.Length <> 0 Then
            If IsNumeric(sender.Text) Then sender.Text = Strings.Right("0000000000" & sender.Text.Trim, 10)
            EvaluarExisteComprobante()
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
        MyOperacionAlmacen = New entOperacionAlmacen
        MyOperacionAlmacenCompra = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable
        MyDetallesOperacion = New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        MyDetallesOperacionSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
        MyControlVehiculos = New dsProductos.CONTROL_VEHICULOSDataTable

        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

        MyStockAlmacen = New dsStockAlmacen.STOCK_X_ALMACENDataTable
        MyStock = 0

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

        Call PonerValoresDefault()
        Call ActivarCabecera(True)
        Call ActivarDetalle(True)

    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        cmbAlmacen.SelectedValue = MyUsuario.almacen
        cmbDocumentoTipo.SelectedValue = "6"

        If Tipo_accion = "CONSIGNACION" Then
            cmbComprobanteTipo.SelectedValue = "GR"
        Else
            cmbComprobanteTipo.SelectedValue = "FT"
        End If
        cmbComprobanteTipoMoneda.SelectedValue = "1"

        txtCombustible.Text = "GASOLINA"

        cmbCategoriaVehicular.SelectedValue = "L3"

        EnableTextBox(txtNumeroSerie, True)

        ckbIndicaAnulado.Visible = False

        If Tipo_accion = "CREDITO" Then
            cmbCondicionPago.SelectedIndex = -1
        Else
            cmbCondicionPago.SelectedValue = "00"
        End If

        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnGrabar_Visible = False

    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbCondicionPago, IndicaActivo)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
        EnableComboBox(cmbComprobanteTipo, IndicaActivo)
        EnableTextBox(txtComprobanteSerie, IndicaActivo)
        EnableTextBox(txtComprobanteNumero, IndicaActivo)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableComboBox(cmbComprobanteTipoMoneda, IndicaActivo)

        EnableTextBox(txtProducto, IndicaActivo)

        EnableTextBox(txtPrecioUnitario, IIf(MyTipoIngresoSalida = "I", IndicaActivo, False))

        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub ActivarDetalle(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtVehiculoMarca, IndicaActivo)
        EnableTextBox(txtVehiculoModelo, IndicaActivo)
        EnableTextBox(txtNumeroSerieChasis, IndicaActivo)
        EnableTextBox(txtColor, IndicaActivo)
        EnableTextBox(txtAñoFabricacion, IndicaActivo)
        EnableTextBox(txtCapacidadMotor, IndicaActivo)
        EnableTextBox(txtNumeroCilindros, IndicaActivo)
        EnableTextBox(txtPotenciaHP, IndicaActivo)
        EnableTextBox(txtPotenciaKW, IndicaActivo)
        EnableTextBox(txtTorqueNM, IndicaActivo)
        EnableTextBox(txtTorqueRPM, IndicaActivo)
        EnableTextBox(txtNumeroRPM, IndicaActivo)
        EnableTextBox(txtPesoNeto, IndicaActivo)
        EnableTextBox(txtCargaUtil, IndicaActivo)
        EnableTextBox(txtNumeroAsientos, IndicaActivo)
        EnableTextBox(txtNumeroPasajeros, IndicaActivo)
        EnableTextBox(txtNumeroRuedas, IndicaActivo)
        EnableTextBox(txtNumeroEjes, IndicaActivo)
        EnableTextBox(txtLongitudLargo, IndicaActivo)
        EnableTextBox(txtLongitudAncho, IndicaActivo)
        EnableTextBox(txtLongitudAltura, IndicaActivo)
        EnableTextBox(txtPolizaNumero, IndicaActivo)
        EnableTextBox(txtPolizaAño, IndicaActivo)
        EnableTextBox(txtPolizaItem, IndicaActivo)
        EnableTextBox(txtCombustible, IndicaActivo)
        EnableComboBox(cmbCategoriaVehicular, IndicaActivo)
    End Sub

    Private Sub ObtenerCuentaComercial()
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
            With MyCuentaComercial
                txtCuentaComercial.Text = .cuenta_comercial
                cmbDocumentoTipo.SelectedValue = .tipo_documento
                txtDocumentoNumero.Text = .nro_documento
                txtRazonSocial.Text = .razon_social
            End With

            txtComprobanteSerie.Focus()
            EvaluarExisteComprobante()
        Else
            txtCuentaComercial.Text = Nothing
            txtDocumentoNumero.Text = Nothing
            txtRazonSocial.Text = Nothing
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub ValidarProducto()
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = txtProducto.Text.Trim

        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto, "NO", "A")
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

            MyControlVehiculos = dalOperacionAlmacen.ObtenerControlVehiculo(MyUsuario.empresa, MyProducto.producto)
            If MyControlVehiculos.Rows.Count <> 0 Then
                With MyControlVehiculos(0)
                    .NUMERO_SERIE = Space(1)
                    .NUMERO_SERIE_CHASIS = Space(1)
                    .COLOR = Space(1)
                    .AÑO_FABRICACION = 0
                    .POLIZA_NUMERO = Space(1)
                    .POLIZA_IPL = Space(1)
                    .POLIZA_AÑO = 0
                    .POLIZA_ITEM = 0
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

            txtPrecioUnitario.Focus()
        Else
            txtProductoDescripcion.Text = Nothing
            txtVehiculoMarca.Text = Nothing
            txtVehiculoModelo.Text = Nothing
        End If
    End Sub

    Private Sub PoblarFormulario()
        Dim ValorVenta As Decimal
        Dim Impuesto As Decimal
        Dim PrecioVenta As Decimal

        Dim OperacionAlmacen As String = MyOperacionAlmacen.operacion
        Dim AlmacenOperacion As String = MyOperacionAlmacen.almacen
        Call LimpiarFormulario()
        MyOperacionAlmacen = dalOperacionAlmacen.ObtenerOperacion(OperacionAlmacen)
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, MyOperacionAlmacen.almacen, MyOperacionAlmacen.operacion)
            If MyDetallesOperacion.Rows.Count = 0 Then
                Resp = MsgBox("La Nota de Ingreso no tiene registros.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                UC_ToolBar.btnEditar_Focus = True
            Else
                MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyDetallesOperacion(0).PRODUCTO)
                If MyProducto.producto Is Nothing Then
                    Resp = MsgBox("El Producto no existe.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                    UC_ToolBar.btnEditar_Focus = True
                Else
                    If MyProducto.indica_vehicular = "NO" Then
                        Resp = MsgBox("La Operación no corresponde a un ingreso vehicular.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                        UC_ToolBar.btnEditar_Focus = True
                    Else
                        With MyOperacionAlmacen
                            cmbAlmacen.SelectedValue = .almacen

                            If Tipo_accion <> "CONTADO" Then
                                MyOperacionAlmacenCompra = dalOperacionAlmacen.ObtenerOperacionCompra(OperacionAlmacen)
                                If Tipo_accion = "CREDITO" Then ' 02 Compra Local, 03 Consignacion Recibida
                                    cmbCondicionPago.SelectedValue = MyOperacionAlmacenCompra(0).CONDICION_PAGO
                                End If
                            End If

                            If .referencia_cuenta_comercial.Trim.Length <> 0 Then
                                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .referencia_cuenta_comercial)
                                Call ObtenerCuentaComercial()
                            End If

                            txtOperacion.Text = .operacion
                            txtEjercicio.Text = .ejercicio
                            txtMes.Text = .mes

                            MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, txtOperacion.Text)

                            MyControlVehiculos = dalOperacionAlmacen.ObtenerControlVehiculo(MyDetallesOperacionSeries(0).EMPRESA, _
                                                                                            MyDetallesOperacionSeries(0).PRODUCTO, _
                                                                                            MyDetallesOperacionSeries(0).NUMERO_SERIE)

                            cmbComprobanteTipo.SelectedValue = .referencia_tipo
                            txtComprobanteSerie.Text = .referencia_serie
                            txtComprobanteNumero.Text = .referencia_numero
                            If .referencia_fecha.Year <> 1900 Then txtComprobanteFecha.Text = EvalDato(.referencia_fecha, "F")
                            cmbComprobanteTipoMoneda.SelectedValue = .referencia_tipo_moneda

                            If MyDetallesOperacion.Rows.Count <> 0 Then
                                If .referencia_tipo_moneda = "1" Then
                                    PrecioVenta = MyDetallesOperacion(0).PRECIO_UNITARIO_MN
                                Else
                                    PrecioVenta = MyDetallesOperacion(0).PRECIO_UNITARIO_ME
                                End If
                                txtProducto.Text = MyDetallesOperacion(0).PRODUCTO
                                txtProductoDescripcion.Text = MyDetallesOperacion(0).DESCRIPCION_AMPLIADA
                                txtPrecioUnitario.Text = EvalDato(PrecioVenta, txtPrecioUnitario.Tag)

                                If Not MyProducto.empresa Is Nothing Then
                                    txtVehiculoMarca.Text = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProducto.producto_familia, False)
                                    txtVehiculoModelo.Text = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProducto.producto_sub_familia, False)
                                End If
                            End If

                            If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                                txtNumeroSerie.Text = MyDetallesOperacionSeries(0).NUMERO_SERIE
                                txtNumeroSerieChasis.Text = MyDetallesOperacionSeries(0).NUMERO_SERIE_CHASIS
                                txtColor.Text = MyDetallesOperacionSeries(0).COLOR
                            End If

                            ActivarCabecera(False)

                            If .estado = "N" Then
                                ckbIndicaAnulado.Checked = True
                                ckbIndicaAnulado.Enabled = False
                                ActivarDetalle(False)
                            Else
                                ckbIndicaAnulado.Checked = False
                                ckbIndicaAnulado.Enabled = True
                                UC_ToolBar.btnGrabar_Visible = True
                            End If
                        End With

                        If MyControlVehiculos.Rows.Count <> 0 Then
                            With MyControlVehiculos(0)
                                txtVehiculoMarca.Text = .MARCA
                                txtVehiculoModelo.Text = .MODELO
                                txtNumeroSerie.Text = .NUMERO_SERIE
                                txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                                txtColor.Text = .COLOR
                                txtAñoFabricacion.Text = EvalDato(.AÑO_FABRICACION, txtAñoFabricacion.Tag)
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
                                txtPolizaNumero.Text = .POLIZA_NUMERO
                                txtPolizaAño.Text = EvalDato(.POLIZA_AÑO, txtPolizaAño.Tag)
                                txtPolizaItem.Text = EvalDato(.POLIZA_ITEM, txtPolizaItem.Tag)
                                txtCombustible.Text = .COMBUSTIBLE
                                cmbCategoriaVehicular.SelectedValue = .CATEGORIA_VEHICULAR
                            End With
                        End If

                        ckbIndicaAnulado.Visible = True
                        UC_ToolBar.btnAceptar_Visible = False
                        EnableTextBox(txtNumeroSerie, False)
                        txtNumeroSerieChasis.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CapturarEncabezado()
        Dim MyFechaVencimiento As Date
        Dim MyDias As Byte = CByte(cmbCondicionPago.SelectedValue)

        With MyOperacionAlmacen
            .empresa = MyUsuario.empresa
            .almacen = cmbAlmacen.SelectedValue
            .operacion = txtOperacion.Text
            If Tipo_accion = "CONSIGNACION" Then
                .tipo_operacion = "03"
            Else
                .tipo_operacion = "02"
            End If
            .ejercicio = txtEjercicio.Text
            .mes = txtMes.Text
            .comentario = Space(1)
            .tipo_es = MyTipoIngresoSalida
            .referencia_cuenta_comercial = txtCuentaComercial.Text
            .referencia_tipo = cmbComprobanteTipo.SelectedValue
            .referencia_serie = txtComprobanteSerie.Text
            .referencia_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then
                .fecha_operacion = txtComprobanteFecha.Text
                .referencia_fecha = txtComprobanteFecha.Text
                MyFechaVencimiento = DateAdd(DateInterval.Day, MyDias, CDate(txtComprobanteFecha.Text))
            End If
            .referencia_tipo_moneda = cmbComprobanteTipoMoneda.SelectedValue
            .referencia_importe_total = txtPrecioUnitario.Text
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario

            If Tipo_accion <> "CONTADO" Then
                MyOperacionAlmacenCompra.Rows.Add(.empresa, _
                                                  .operacion, _
                                                  Math.Round(.referencia_importe_total + (.referencia_importe_total * MyIGV / 100), 1), _
                                                  MyFechaVencimiento, _
                                                  cmbCondicionPago.SelectedValue, _
                                                  IIf(Tipo_accion = "CONSIGNACION", "SI", "NO"), _
                                                  MyUsuario.usuario, _
                                                  Now.Date, _
                                                  Space(1), _
                                                  FechaNulo)
            End If
        End With
    End Sub

    Private Sub CapturarDetalle()
        Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)
        If txtProducto.Text.Trim.Length <> 0 Then
            MyDetallesOperacion = New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
            MyDetallesOperacionSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
            MyControlVehiculos = New dsProductos.CONTROL_VEHICULOSDataTable

            MyDetallesOperacion.Rows.Add("001", MyProducto.producto, MyProducto.codigo_compra, MyProducto.descripcion, _
                                                 IIf(cmbComprobanteTipoMoneda.SelectedValue = "1", PrecioUnitario, 0), _
                                                 IIf(cmbComprobanteTipoMoneda.SelectedValue = "2", PrecioUnitario, 0), _
                                                 1, Numero_Lote_Nulo, FechaNulo, "SI", "NO", "NO")

            With MyDetallesOperacion(0)
                If dalProducto.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, .NUMERO_LOTE, .PRODUCTO) Then .EXISTE_RESUMEN_ALMACEN = "SI"
                If dalProducto.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, .NUMERO_LOTE, .PRODUCTO) Then .EXISTE_RESUMEN_PERIODO = "SI"
            End With

            MyDetallesOperacionSeries.Rows.Add(MyUsuario.empresa, Space(1), MyProducto.producto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, txtColor.Text, "A", Space(1), FechaNulo, Space(1), FechaNulo, "NO")

            Call CrearControlVehiculo()
        End If
    End Sub

    Private Sub CrearControlVehiculo()
        MyControlVehiculos.Rows.Add(MyUsuario.empresa, MyProducto.producto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, txtColor.Text, CDec(txtAñoFabricacion.Text), _
                                    txtVehiculoMarca.Text, txtVehiculoModelo.Text, CDec(txtCapacidadMotor.Text), CDec(txtNumeroCilindros.Text), CDec(txtPotenciaHP.Text), _
                                    CDec(txtPotenciaKW.Text), CDec(txtTorqueNM.Text), CDec(txtTorqueRPM.Text), CDec(txtNumeroRPM.Text), CDec(txtPesoNeto.Text), _
                                    CDec(txtCargaUtil.Text), CDec(txtPesoBruto.Text), CDec(txtNumeroAsientos.Text), CDec(txtNumeroPasajeros.Text), CDec(txtNumeroRuedas.Text), _
                                    CDec(txtNumeroEjes.Text), txtCombustible.Text, CDec(txtLongitudLargo.Text), CDec(txtLongitudAncho.Text), CDec(txtLongitudAltura.Text), _
                                    txtPolizaNumero.Text, CDec(txtPolizaAño.Text), CDec(txtPolizaItem.Text), Space(1), cmbCategoriaVehicular.SelectedValue, Space(1), _
                                    "D", Space(1), FechaNulo, Space(1), FechaNulo)
    End Sub

    Private Function EvaluarContinuar() As Boolean
        Dim NombreCampo As String
        EvaluarContinuar = False

        If txtCuentaComercial.Text.Trim.Length = 0 Then : NombreCampo = "DOCUMENTO DE IDENTIDAD" : txtCuentaComercial.Focus()
        ElseIf Tipo_accion = "CREDITO" And cmbCondicionPago.SelectedIndex = -1 Then : NombreCampo = "CONDICIONES DE PAGO" : cmbCondicionPago.Focus()
        ElseIf txtProducto.Text.Trim.Length = 0 Then : NombreCampo = "PRODUCTO" : txtProducto.Focus()
        ElseIf Tipo_accion <> "CONSIGNACION" And CDec(txtPrecioUnitario.Text) = 0 Then : NombreCampo = "PRECIO UNITARIO" : txtPrecioUnitario.Focus()
        ElseIf txtVehiculoMarca.Text.Trim.Length = 0 Then : NombreCampo = "MARCA" : txtVehiculoMarca.Focus()
        ElseIf txtVehiculoModelo.Text.Trim.Length = 0 Then : NombreCampo = "MODELO" : txtVehiculoModelo.Focus()
        ElseIf txtNumeroSerie.Text.Trim.Length = 0 Then : NombreCampo = "NUMERO SERIE MOTOR" : txtNumeroSerie.Focus()
        ElseIf txtNumeroSerieChasis.Text.Trim.Length = 0 Then : NombreCampo = "NUMERO SERIE CHASIS" : txtNumeroSerieChasis.Focus()
        ElseIf txtColor.Text.Trim.Length = 0 Then : NombreCampo = "COLOR" : txtColor.Focus()
        ElseIf CDec(txtAñoFabricacion.Text) = 0 Then : NombreCampo = "AÑO FABRICACION" : txtAñoFabricacion.Focus()

            'ElseIf CDec(txtCapacidadMotor.Text) = 0 Then : NombreCampo = "CAPACIDAD DEL MOTOR" : txtCapacidadMotor.Focus()
            'ElseIf CDec(txtNumeroCilindros.Text) = 0 Then : NombreCampo = "NUMERO DE CILINDROS" : txtNumeroCilindros.Focus()
            'ElseIf CDec(txtPotenciaHP.Text) = 0 Then : NombreCampo = "POTENCIA DE MOTOR" : txtPotenciaHP.Focus()
            'ElseIf CDec(txtPotenciaKW.Text) = 0 Then : NombreCampo = "POTENCIA DE MOTOR" : txtPotenciaKW.Focus()

            'ElseIf txtPolizaNumero.Text.Trim.Length = 0 Then : NombreCampo = "DUA - NUMERO" : txtPolizaNumero.Focus()
            'ElseIf CDec(txtPolizaAño.Text) = 0 Then : NombreCampo = "DUA - AÑO" : txtPolizaAño.Focus()
            'ElseIf CDec(txtPolizaItem.Text) = 0 Then : NombreCampo = "DUA - ITEM" : txtPolizaItem.Focus()
        Else
            EvaluarContinuar = True
        End If

        If EvaluarContinuar = False Then Resp = MsgBox("Debe registrar información en el campo " & NombreCampo, MsgBoxStyle.Exclamation, "PROCESO CANCELADO")

        Return EvaluarContinuar
    End Function

    Private Sub EvaluarExisteComprobante()
        Dim OperacionAlmacen As String = txtOperacion.Text.Trim
        Dim CuentaComercial As String = txtCuentaComercial.Text.Trim
        Dim ComprobanteTipo As String = cmbComprobanteTipo.SelectedValue
        Dim ComprobanteSerie As String = txtComprobanteSerie.Text.Trim
        Dim ComprobanteNumero As String = txtComprobanteNumero.Text.Trim
        Dim MyOperacionAlmacenOtra As New entOperacionAlmacen
        Dim Comentario As String = Space(1)
        If OperacionAlmacen.Length = 0 And CuentaComercial.Length <> 0 And ComprobanteSerie.Length <> 0 And ComprobanteNumero.Length <> 0 Then
            MyOperacionAlmacenOtra = dalOperacionAlmacen.ObtenerOperacion(CuentaComercial, ComprobanteTipo, ComprobanteSerie, ComprobanteNumero)
            If Not MyOperacionAlmacenOtra.operacion Is Nothing Then
                With MyOperacionAlmacenOtra
                    txtOperacion.Text = .operacion
                    cmbAlmacen.SelectedValue = .almacen
                    txtComprobanteFecha.Text = EvalDato(.referencia_fecha, "F")
                    cmbComprobanteTipoMoneda.SelectedValue = .referencia_tipo_moneda
                    ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)

                    MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, .almacen, .operacion)
                    MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, .operacion)

                    Comentario = "El comprobante de ingreso ya fué registrado anteriormente por el usuario " & .usuario_registro & " el " & EvalDato(.fecha_registro, "F")
                End With

                If MyDetallesOperacion.Rows.Count <> 0 Then
                    With MyDetallesOperacion(0)
                        txtProducto.Text = .PRODUCTO
                        txtProductoDescripcion.Text = .DESCRIPCION_AMPLIADA
                        If MyOperacionAlmacenOtra.referencia_tipo_moneda = "1" Then
                            txtPrecioUnitario.Text = EvalDato(.PRECIO_UNITARIO_MN, txtPrecioUnitario.Tag)
                        Else
                            txtPrecioUnitario.Text = EvalDato(.PRECIO_UNITARIO_ME, txtPrecioUnitario.Tag)
                        End If
                        MyProducto = dalProducto.Obtener(MyUsuario.empresa, .PRODUCTO)
                    End With
                End If

                If Not MyProducto.empresa Is Nothing Then
                    txtVehiculoMarca.Text = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProducto.producto_familia, False)
                    txtVehiculoModelo.Text = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProducto.producto_sub_familia, False)
                End If

                If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                    With MyDetallesOperacionSeries(0)
                        txtNumeroSerie.Text = .NUMERO_SERIE
                        txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                        txtColor.Text = .COLOR
                    End With
                End If

                ActivarCabecera(False)
                ActivarDetalle(False)
                EnableTextBox(txtNumeroSerie, False)

                Resp = MsgBox(Comentario, MsgBoxStyle.Critical, "PROCESO DENEGADO")
                LimpiarFormulario()
            End If
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

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        If cmbAlmacen.SelectedIndex <> -1 Then
            MyOperacionAlmacen = New entOperacionAlmacen
            MyOperacionAlmacen.almacen = cmbAlmacen.SelectedValue
            If Tipo_accion = "CONSIGNACION" Then
                MyOperacionAlmacen.tipo_operacion = "03"

            Else
                MyOperacionAlmacen.tipo_operacion = "02"
                If Tipo_accion = "CREDITO" Then MyOperacionAlmacen.indica_credito = "SI"
            End If
            Dim MyForm As New frmOperacionesAlmacenes(MyOperacionAlmacen, MyTipoIngresoSalida, False, "SI")
            MyForm.ShowDialog()
            If Not MyOperacionAlmacen.operacion Is Nothing Then Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim MyCompraAnterior As New dsOperacionesAlmacen.COMPRAS_PROVEEDORDataTable

        If EvaluarContinuar() = True Then
            Try
                MyCompraAnterior = dalOperacionAlmacen.BuscarCompraAnterior(MyUsuario.empresa, txtProducto.Text, txtNumeroSerie.Text)
                If MyCompraAnterior.Rows.Count <> 0 Then
                    With MyCompraAnterior(0)
                        Resp = MsgBox("El Vehículo ya se encuenta registrado:" & vbCrLf &
                                      .PROVEEDOR & vbCrLf &
                                      .COMPROBANTE & vbCrLf &
                                      .COMPROBANTE_FECHA & vbCrLf &
                                      "Registrado por el usuario " & .USUARIO_REGISTRO & " el día " & EvalDato(.FECHA_REGISTRO, "F"), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                    End With
                Else
                    UC_ToolBar.btnAceptar_Visible = False
                    Call CapturarEncabezado()
                    Call CapturarDetalle()
                    MyOperacionAlmacen = dalOperacionAlmacen.GrabarNotaIngresoVehiculo(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries, MyControlVehiculos, MyOperacionAlmacenCompra)
                    txtOperacion.Text = MyOperacionAlmacen.operacion

                    Resp = MsgBox("La Nota de Almacén se grabó con éxito.", MsgBoxStyle.Information, "GRABAR NOTA DE ALMACEN")
                    Call ActivarCabecera(False)
                    UC_ToolBar.btnGrabar_Visible = True
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
                If txtOperacion.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
                If txtOperacion.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim ExisteControlVehiculo As Boolean = True
        PeriodoOperacion = MyOperacionAlmacen.ejercicio & MyOperacionAlmacen.mes

        If EvaluarContinuar() = True Then
            Try
                UC_ToolBar.btnGrabar_Visible = False
                If ckbIndicaAnulado.Checked = True Then
                    If PeriodoTrabajo <> PeriodoOperacion Then
                        Resp = MsgBox("Para anular la nota por compra vehicular debe cambiar el periodo de trabajo al mes de " &
                                      UCase(EvalMes(PeriodoOperacion.Substring(4, 2), "L")) & " del " &
                                      PeriodoOperacion.Substring(0, 4), MsgBoxStyle.Critical, "PROCESO DENEGADO")
                        Call LimpiarFormulario()
                    Else
                        If MyControlVehiculos(0).ESTADO <> "D" Then
                            Resp = MsgBox("No es posible anular la Nota de Almacén." & vbCrLf & _
                                          "El Número de Serie no esta disponible.", MsgBoxStyle.Critical, "PROCESO DENEGADO")
                        Else
                            Resp = MsgBox("Confirmar proceso de anulación de la Nota de Almacén.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR NOTA POR COMPRA VEHICULAR")
                            If Resp = 1 Then
                                If dalOperacionAlmacen.AnularIngresoVehiculo(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries) = True Then
                                    Resp = MsgBox("La Nota de Almacén se anuló con éxito.", MsgBoxStyle.Information, "ANULAR NOTA POR COMPRA VEHICULAR")
                                    Call LimpiarFormulario()
                                Else
                                    Resp = MsgBox("La Nota de Ingreso no pudo ser anulada.", MsgBoxStyle.Critical, "PROCESO DENEGADO")
                                    ckbIndicaAnulado.Checked = False
                                    UC_ToolBar.btnGrabar_Visible = True
                                    UC_ToolBar.btnGrabar_Focus = True
                                End If
                            Else
                                ckbIndicaAnulado.Checked = False
                                UC_ToolBar.btnGrabar_Visible = True
                                UC_ToolBar.btnGrabar_Focus = True
                            End If
                        End If
                    End If
                Else
                    MyDetallesOperacionSeries(0).NUMERO_SERIE_CHASIS = txtNumeroSerieChasis.Text
                    MyDetallesOperacionSeries(0).COLOR = txtColor.Text

                    If MyControlVehiculos.Rows.Count = 0 Then
                        Call CrearControlVehiculo()
                        ExisteControlVehiculo = False
                    Else
                        With MyControlVehiculos(0)
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
                    End If
                    If dalOperacionAlmacen.ActualizarIngresoVehiculo(MyOperacionAlmacen, MyDetallesOperacionSeries, MyControlVehiculos, ExisteControlVehiculo) = True Then
                        Resp = MsgBox("La Nota de Almacén se actualizó con éxito.", MsgBoxStyle.Information, "ACTUALIZAR NOTA POR COMPRA VEHICULAR")
                        Call LimpiarFormulario()
                    End If
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
                If txtOperacion.Text.Trim.Length <> 0 Then UC_ToolBar.btnGrabar_Visible = True
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
                If txtOperacion.Text.Trim.Length <> 0 Then UC_ToolBar.btnGrabar_Visible = True
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        Dim MyDetalles As New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        Dim MyDetallesImprimir As New dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable
        Dim CodigoProducto As String
        Dim Comentario As String = Space(1)
        Dim FechaOperacion As Date

        If txtOperacion.Text.Trim.Length <> 0 Then
            If MyOperacionAlmacen.estado = "N" Then
                FechaOperacion = MyOperacionAlmacen.fecha_modifica
                If FechaOperacion.Year = 1900 Then FechaOperacion = Now
                Comentario = "OPERACION ANULADA POR EL USUARIO " & MyOperacionAlmacen.usuario_modifica & " EL " & EvalDato(FechaOperacion, "F")
            Else
                FechaOperacion = MyOperacionAlmacen.fecha_registro
                If FechaOperacion.Year = 1900 Then FechaOperacion = Now
                Comentario = "OPERACION REGISTRADA POR EL USUARIO " & MyOperacionAlmacen.usuario_registro & " EL " & EvalDato(FechaOperacion, "F")
            End If

            If MyDetallesOperacion.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                    MyDetalles.ImportRow(MyDetallesOperacion(NEle))
                Next

                For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
                    CodigoProducto = MyDetalles(NEle).PRODUCTO
                    If MyDetalles(NEle).INDICA_SERIE = "SI" Then
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & " SERIES: "
                        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                            For NFila As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                                If MyDetallesOperacionSeries(NFila).PRODUCTO = CodigoProducto Then
                                    MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & MyDetallesOperacionSeries(NFila).NUMERO_SERIE & " / "
                                End If
                            Next
                        End If
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA.Substring(0, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim.Length - 1)
                    End If
                    MyDetallesImprimir.Rows.Add(CodigoProducto, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim, MyDetalles(NEle).CODIGO_COMPRA, MyDetalles(NEle).CANTIDAD, MyDetalles(NEle).NUMERO_LOTE)
                Next
            End If

            Dim MyForm As New frmOperacionAlmacenImprimir(txtOperacion.Text, CDate(txtComprobanteFecha.Text), cmbAlmacen.Text, Me.lblTitulo.Text, Comentario, MyDetallesImprimir)
            MyForm.ShowDialog()
        End If
    End Sub

#End Region

End Class
