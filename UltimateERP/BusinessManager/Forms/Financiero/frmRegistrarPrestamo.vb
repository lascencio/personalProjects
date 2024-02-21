Public Class frmRegistrarPrestamo

    Private MyVenta As entVenta
    Private MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable
    Private MyCuentaComercial As New entCuentaComercial
    Private MyProducto As entProducto

    Private MyProforma As dsFinanciero.PROFORMASDataTable
    Private MyProformas As dsFinanciero.PROFORMAS_LISTADataTable

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private Sub frmRegistrarPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRegistrarPrestamo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyTipoPrestamo As New dsTablasGenericas.LISTADataTable
        Dim MyTipoPrestamoNV As dsTablasGenericas.LISTADataTable

        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO")

        ActualizarListaGenerica(cmbPais, "_NACIONALIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaGenerica(cmbEstadoCivil, "_ESTADO_CIVIL")
        ActualizarListaGenerica(cmbNivelEducativo, "_NIVEL_EDUCATIVO")
        ActualizarListaEmpresa(cmbOcupacion, "OPE_OCUPACION")

        MyTipoPrestamoNV = ObtenerListaEmpresa("FIN_TIPO_PRESTAMO", True)

        If MyTipoPrestamoNV.Rows.Count <> 0 Then
            If Tipo_accion = "VEHICULAR" Then
                For NEle As Integer = 0 To MyTipoPrestamoNV.Rows.Count - 1
                    If MyTipoPrestamoNV(NEle).CODIGO = "05" Then
                        MyTipoPrestamo.ImportRow(MyTipoPrestamoNV(NEle))
                    End If
                Next
                ckbIncluyeIGV.Enabled = False
                Me.Height = 565

            Else
                For NEle As Integer = 0 To MyTipoPrestamoNV.Rows.Count - 1
                    If MyTipoPrestamoNV(NEle).CODIGO <> "05" Then
                        MyTipoPrestamo.ImportRow(MyTipoPrestamoNV(NEle))
                    End If
                Next
                Me.Height = 447

            End If
        End If

        cmbTipoPrestamo.DataSource = MyTipoPrestamo

        lblTipoPrestamo.Text = "REGISTRAR PRESTAMO " & Tipo_accion

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnInformacion_Visible = False
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
            cmbTipoPrestamo.Focus()
        End If
    End Sub

    Private Sub ValidarImportes_Validated(sender As Object, e As EventArgs) Handles txtCapital.Validated, txtNumeroCuotas.Validated, txtTasaInteresMensual.Validated, txtTasaMorosidadMensual.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        'Call CalcularCuota()
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaNacimiento.Validated, txtFechaPrimerPago.Validated, txtCuotaInicialFechaPagoSaldo.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If sender.Name = "txtFechaPrimerPago" Then
            If txtFechaPrimerPago.Text.Trim.Length = 0 Then CalcularFechaPrimerPago()
            'Call CalcularCuota()
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If cmbFormaPago.SelectedIndex <> -1 Then
            Call CalcularFechaPrimerPago()
            'Call CalcularCuota()
        End If
    End Sub

    Private Sub cmbTipoPrestamo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPrestamo.SelectedIndexChanged
        Dim TipoPrestamo As dsFinanciero.TIPO_PRESTAMODataTable
        If cmbTipoPrestamo.SelectedIndex <> -1 Then
            TipoPrestamo = dalFinanciamiento.ObtenerTipoPrestamo(MyUsuario.empresa, cmbTipoPrestamo.SelectedValue)
            txtTasaInteresMensual.Text = EvalDato(TipoPrestamo(0).TASA_INTERES, txtTasaInteresMensual.Tag)
            txtTasaMorosidadMensual.Text = EvalDato(TipoPrestamo(0).TASA_MOROSIDAD, txtTasaMorosidadMensual.Tag)
        End If
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        ActualizarTablaProvincia("_UBIGEO_PROVINCIA", cmbProvincia, cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        ActualizarTablaUbigeo("_UBIGEO", cmbDistrito, cmbDepartamento.SelectedValue, cmbProvincia.SelectedValue)
    End Sub

    Private Sub ckbIndicaNoDomiciliado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaNoDomiciliado.CheckedChanged
        EnableComboBox(cmbPais, sender.Checked)

        EnableComboBox(cmbDepartamento, Not sender.Checked)
        EnableComboBox(cmbProvincia, Not sender.Checked)
        EnableComboBox(cmbDistrito, Not sender.Checked)

        If sender.Checked = True Then
            cmbDepartamento.SelectedValue = "15"
            cmbProvincia.SelectedValue = "1501"
            cmbDistrito.SelectedValue = "150101"
            cmbPais.SelectedIndex = -1
        Else
            cmbPais.SelectedValue = "9589"
        End If
    End Sub

    Private Sub ckbIncluyeIGV_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIncluyeIGV.CheckedChanged
        'Call CalcularCuota()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta
        MyVentaVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

        MyProforma = New dsFinanciero.PROFORMASDataTable

        MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        txtCuentaComercial.Text = "00000000"

        cmbTipoMoneda.SelectedValue = "1"
        txtFechaEmision.Text = EvalDato(Now.Date, "F")
        cmbDocumentoTipo.SelectedValue = "1"
        cmbFormaPago.SelectedValue = "04"

        txtVenta.Text = "000000000000"
        txtProforma.Text = "000000000000"

        cmbPais.SelectedValue = "9589"
        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"

        If Tipo_accion = "VEHICULAR" Then
            cmbTipoPrestamo.SelectedValue = "05"
            ckbIncluyeIGV.Checked = True
            txtCapital.Focus()
            txtCapital.Select()
        Else
            cmbTipoPrestamo.SelectedValue = "01"
            ckbIncluyeIGV.Checked = False
            txtDocumentoNumero.Focus()
        End If

        ActualizarCombos = True

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)

        If Tipo_accion = "VEHICULAR" Then
            EnableComboBox(cmbDocumentoTipo, False)
            EnableTextBox(txtDocumentoNumero, False)
            EnableTextBox(txtRazonSocial, False)
            EnableTextBox(txtDomicilio, False)
            ckbIndicaNoDomiciliado.Enabled = False
            EnableComboBox(cmbDepartamento, False)
            EnableComboBox(cmbProvincia, False)
            EnableComboBox(cmbDistrito, False)
            EnableTextBox(txtReferencia, False)
        Else
            EnableComboBox(cmbDocumentoTipo, IndicaActivo)
            EnableTextBox(txtDocumentoNumero, IndicaActivo)
            EnableTextBox(txtRazonSocial, IndicaActivo)
            EnableTextBox(txtDomicilio, IndicaActivo)
            ckbIndicaNoDomiciliado.Enabled = IndicaActivo
            EnableComboBox(cmbDepartamento, IndicaActivo)
            EnableComboBox(cmbProvincia, IndicaActivo)
            EnableComboBox(cmbDistrito, IndicaActivo)
            EnableTextBox(txtReferencia, IndicaActivo)
        End If

        EnableComboBox(cmbTipoPrestamo, IndicaActivo)
        EnableComboBox(cmbFormaPago, IndicaActivo)
        EnableComboBox(cmbTipoMoneda, IndicaActivo)

        EnableComboBox(cmbSexo, IndicaActivo)
        EnableComboBox(cmbEstadoCivil, IndicaActivo)
        EnableComboBox(cmbNivelEducativo, IndicaActivo)
        EnableComboBox(cmbOcupacion, IndicaActivo)

        EnableTextBox(txtCapital, IndicaActivo)
        EnableTextBox(txtNumeroCuotas, IndicaActivo)
        EnableTextBox(txtTasaInteresMensual, IndicaActivo)
        EnableTextBox(txtTasaMorosidadMensual, IndicaActivo)

        EnableTextBox(txtTelefono, IndicaActivo)
        EnableTextBox(txtTelefonoOtro, IndicaActivo)
        EnableTextBox(txtCelular, IndicaActivo)
        EnableTextBox(txtEmail, IndicaActivo)
        EnableTextBox(txtFechaNacimiento, IndicaActivo)
        EnableTextBox(txtNombreConviviente, IndicaActivo)
        EnableTextBox(txtDireccionTrabajo, IndicaActivo)
        EnableTextBox(txtReferenciaTrabajo, IndicaActivo)
        EnableTextBox(txtTelefonoTrabajo, IndicaActivo)
        EnableTextBox(txtFechaPrimerPago, IndicaActivo)

        btnBuscarProforma.Enabled = IndicaActivo
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                If Tipo_accion = "VEHICULAR" Then
                    Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "SN")
                    MyForm.ShowDialog()
                    If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyCuentaComercial.cuenta_comercial)
                Else
                    Dim MyForm As New frmClientesLista(MyCuentaComercial)
                    MyForm.ShowDialog()
                    If Not MyCuentaComercial.nro_documento Is Nothing Then MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyCuentaComercial.tipo_documento, MyCuentaComercial.nro_documento)
                End If
            Else
                If Tipo_accion = "VEHICULAR" Then
                    MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                Else
                    MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                End If
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                EnableComboBox(cmbDocumentoTipo, False)
                EnableTextBox(txtDocumentoNumero, False)

                EnableTextBox(txtRazonSocial, False)

                Call PoblarCuentaComercial()

                'EnableComboBox(cmbDocumentoTipo, False)
                txtCapital.Focus()
            Else
                EnableTextBox(txtRazonSocial, True)
                EnableTextBox(txtDomicilio, True)

                If Not String.IsNullOrEmpty(MyDocumentoNumero) Then
                    txtCuentaComercial.Text = "00000000"
                    txtRazonSocial.Text = Nothing
                    txtDomicilio.Text = Nothing
                    txtRazonSocial.Focus()
                    ckbIndicaNoDomiciliado.Checked = False
                    cmbPais.SelectedValue = "9589"
                    cmbDepartamento.SelectedValue = "15"
                    cmbProvincia.SelectedValue = "1501"
                    cmbDistrito.SelectedValue = "150101"
                    txtReferencia.Text = Nothing
                    txtTelefono.Text = Nothing
                    txtTelefonoOtro.Text = Nothing
                    txtCelular.Text = Nothing
                    txtEmail.Text = Nothing
                    txtFechaNacimiento.Text = Nothing
                    cmbSexo.SelectedIndex = -1
                    cmbEstadoCivil.SelectedValue = -1
                    cmbNivelEducativo.SelectedValue = -1
                    cmbOcupacion.SelectedValue = -1
                    txtNombreConviviente.Text = Nothing
                    txtDireccionTrabajo.Text = Nothing
                    txtReferenciaTrabajo.Text = Nothing
                    txtTelefonoTrabajo.Text = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub PoblarCuentaComercial()
        With MyCuentaComercial
            txtCuentaComercial.Text = .cuenta_comercial
            cmbDocumentoTipo.SelectedValue = .tipo_documento
            txtDocumentoNumero.Text = .nro_documento
            txtRazonSocial.Text = .razon_social
            ckbIndicaNoDomiciliado.Checked = IIf(.indica_no_domiciliado = "SI", True, False)
            cmbPais.SelectedValue = .pais
            txtDomicilio.Text = .domicilio
            cmbDepartamento.SelectedValue = .departamento
            cmbProvincia.SelectedValue = .provincia
            cmbDistrito.SelectedValue = .ubigeo
            txtReferencia.Text = .referencia
            txtTelefono.Text = .telefono
            txtTelefonoOtro.Text = .telefono_otro
            txtCelular.Text = .celular
            txtEmail.Text = .email
            If .fecha_nacimiento.Date <> FechaNulo.Date Then txtFechaNacimiento.Text = .fecha_nacimiento
            cmbSexo.SelectedIndex = IIf(.sexo = "M", 0, 1)
            cmbEstadoCivil.SelectedValue = .estado_civil
            cmbNivelEducativo.SelectedValue = .nivel_educativo
            cmbOcupacion.SelectedValue = .ocupacion
            txtNombreConviviente.Text = .apellido_casada
            txtDireccionTrabajo.Text = .direccion_trabajo
            txtReferenciaTrabajo.Text = .referencia_trabajo
            txtTelefonoTrabajo.Text = .telefono_trabajo
        End With
    End Sub

    Private Sub CalcularFechaPrimerPago()
        Dim FechaPrimerPago As Date
        Dim FormaPago As String

        If cmbFormaPago.SelectedIndex <> -1 Then
            FormaPago = cmbFormaPago.Text
            Select Case FormaPago
                Case Is = "DIARIO" : FechaPrimerPago = DateAdd(DateInterval.Day, 1, Now.Date)
                Case Is = "SEMANAL" : FechaPrimerPago = DateAdd(DateInterval.Day, 7, Now.Date)
                Case Is = "QUINCENAL" : FechaPrimerPago = DateAdd(DateInterval.Day, 15, Now.Date)
                Case Is = "MENSUAL" : FechaPrimerPago = DateAdd(DateInterval.Month, 1, Now.Date)
            End Select
            txtFechaPrimerPago.Text = EvalDato(FechaPrimerPago, txtFechaPrimerPago.Tag)
        End If
    End Sub

    Private Sub CalcularCuota()
        Dim Amortizacion As Decimal
        Dim Interes As Decimal
        Dim Impuesto As Decimal
        Dim ValorCuota As Decimal

        Dim NumeroCuotas As Decimal = CDec(txtNumeroCuotas.Text)
        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        If NumeroCuotas <> 0 Then
            Dim FormaPago As String = cmbFormaPago.Text

            Dim Capital As Decimal = txtCapital.Text
            Dim TotalInteres As Decimal
            Dim TotalImpuesto As Decimal
            Dim TotalPrestamo As Decimal

            Dim TasaInteresMensual As Decimal = txtTasaInteresMensual.Text
            Dim InteresMensual As Decimal = Capital * TasaInteresMensual / 100

            Dim TotalInteresMensual As Decimal = InteresMensual * NumeroCuotas
            Dim TotalInteresQuincenal As Decimal = InteresMensual / 2 * NumeroCuotas
            Dim TotalInteresSemanal As Decimal = InteresMensual / 4 * NumeroCuotas
            Dim TotalInteresDiario As Decimal = InteresMensual / 30 * NumeroCuotas

            Amortizacion = 0 : Interes = 0 : Impuesto = 0 : ValorCuota = 0

            Select Case FormaPago
                Case Is = "DIARIO" : TotalInteres = TotalInteresDiario
                Case Is = "SEMANAL" : TotalInteres = TotalInteresSemanal
                Case Is = "QUINCENAL" : TotalInteres = TotalInteresQuincenal
                Case Is = "MENSUAL" : TotalInteres = TotalInteresMensual
            End Select

            If ckbIncluyeIGV.Checked = True Then
                TotalImpuesto = TotalInteres * MyIGV / 100
            Else
                TotalImpuesto = 0
            End If

            Amortizacion = Math.Round(Capital / NumeroCuotas, 2)
            Interes = Math.Round(TotalInteres / NumeroCuotas, 2)
            Impuesto = Math.Round(TotalImpuesto / NumeroCuotas, 2)
            ValorCuota = Amortizacion + Interes + Impuesto

            TotalPrestamo = ValorCuota * NumeroCuotas

            txtValorCuota.Text = EvalDato(ValorCuota, txtValorCuota.Tag)

            txtTotalInteres.Text = EvalDato(TotalInteres, txtTotalInteres.Tag)
            txtTotalImpuesto.Text = EvalDato(TotalImpuesto, txtTotalImpuesto.Tag)
            txtTotalPrestamo.Text = EvalDato(TotalPrestamo, txtTotalPrestamo.Tag)

            Call GenerarCuotas(FormaPago, Amortizacion, Interes, Impuesto, ValorCuota)
        Else
            MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable
            txtValorCuota.Text = "0.00"
            txtTotalInteres.Text = "0.00"
            txtTotalImpuesto.Text = "0.00"
            txtTotalPrestamo.Text = "0.00"
        End If
    End Sub

    Private Sub GenerarCuotas(ByVal FormaPago As String, ByVal Amortizacion As Decimal, ByVal Interes As Decimal, ByVal impuesto As Decimal, ByVal ValorCuota As Decimal)
        Dim NumeroCuotas As Decimal = txtNumeroCuotas.Text
        Dim FechaVencimiento As Date
        Dim CuotaNumero As String
        Dim Ejercicio As String
        Dim Mes As String

        Dim CuotaInicial As Decimal
        Dim CuotaInicialPagada As Decimal
        Dim FechaPagoSaldoCuotaInicial As Date
        Dim CuotaCero As Decimal


        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        If Tipo_accion = "VEHICULAR" Then

            If CDec(txtCuotaInicialSaldo.Text) <> 0 Then
                CuotaInicial = CDec(txtCuotaInicial.Text)
                CuotaInicialPagada = CDec(txtCuotaInicialPagada.Text)
                FechaPagoSaldoCuotaInicial = CDate(txtCuotaInicialFechaPagoSaldo.Text)
                CuotaCero = CuotaInicial - CuotaInicialPagada
                If CuotaCero <> 0 Then
                    Ejercicio = FechaPagoSaldoCuotaInicial.Year.ToString
                    Mes = FechaPagoSaldoCuotaInicial.Month.ToString("00")

                    MyPrestamoCuotas.Rows.Add(MyUsuario.empresa, Space(1), "000", Ejercicio, Mes, FechaPagoSaldoCuotaInicial, 0, 0, 0, CuotaCero, FechaNulo, CuotaCero, 0, FechaNulo, Space(1), "V", MyAgencia(0).AGENCIA, MyUsuario.usuario, FechaNulo, Space(1), Space(1), FechaNulo)
                End If
            End If
        End If

        For Cuota As Integer = 1 To NumeroCuotas
            If Cuota = 1 Then
                FechaVencimiento = CDate(txtFechaPrimerPago.Text)
            Else
                Select Case FormaPago
                    Case Is = "DIARIO" : FechaVencimiento = DateAdd(DateInterval.Day, 1, FechaVencimiento)
                    Case Is = "SEMANAL" : FechaVencimiento = DateAdd(DateInterval.Day, 7, FechaVencimiento)
                    Case Is = "QUINCENAL" : FechaVencimiento = DateAdd(DateInterval.Day, 15, FechaVencimiento)
                    Case Is = "MENSUAL" : FechaVencimiento = DateAdd(DateInterval.Month, 1, FechaVencimiento)
                End Select
            End If

            CuotaNumero = Cuota.ToString("000")
            Ejercicio = FechaVencimiento.Year.ToString
            Mes = FechaVencimiento.Month.ToString("00")

            MyPrestamoCuotas.Rows.Add(MyUsuario.empresa, Space(1), CuotaNumero, Ejercicio, Mes, FechaVencimiento, Amortizacion, Interes, impuesto, ValorCuota, FechaNulo, ValorCuota, 0, FechaNulo, Space(1), "V", MyAgencia(0).AGENCIA, MyUsuario.usuario, FechaNulo, Space(1), Space(1), FechaNulo)
        Next
    End Sub

    Private Sub PoblarVenta()
        Dim Venta As String = MyVenta.venta
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            MyVentaVehiculo = dalVenta.ObtenerVentaVehiculo(MyUsuario.empresa, MyVenta.venta)
            If MyVentaVehiculo.Rows.Count = 0 Then
                Resp = MsgBox("El Comprobante " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero & " no ha sido registrado por esta opción.", MsgBoxStyle.Exclamation, "VENTA VEHICULAR")
            Else
                With MyVentaVehiculo(0)
                    MyProducto = dalProducto.Obtener(MyUsuario.empresa, .PRODUCTO)
                    txtProducto.Text = MyProducto.producto
                    txtProductoDescripcion.Text = MyProducto.descripcion_ampliada

                    txtVehiculoMarca.Text = .MARCA
                    txtVehiculoModelo.Text = .MODELO
                    txtNumeroSerie.Text = .NUMERO_SERIE
                    txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                    txtColor.Text = .COLOR
                End With

                With MyVenta
                    If MyPrestamo.Rows.Count <> 0 Then
                        MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyPrestamo(0).TIPO_DOCUMENTO, MyPrestamo(0).NRO_DOCUMENTO)
                    ElseIf MyProforma.Rows.Count <> 0 Then
                        MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyProforma(0).TIPO_DOCUMENTO, MyProforma(0).NRO_DOCUMENTO)
                    End If

                    If MyCuentaComercial.nro_documento Is Nothing Then
                        MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyVenta.cuenta_comercial)
                    End If

                    Call PoblarCuentaComercial()

                    txtVenta.Text = .venta
                    txtComprobante.Text = .comprobante_serie & "-" & .comprobante_numero.Substring(2, 7)
                    txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, txtComprobanteFecha.Tag)
                    txtImporteTotal.Text = EvalDato(.importe_total_origen, txtImporteTotal.Tag)

                    Call dalVenta.ObtenerCuotaInicial(MyVenta)
                    txtCuotaInicial.Text = EvalDato(MyVenta.cuota_inicial, txtCuotaInicial.Tag)
                    txtCuotaInicialPagada.Text = EvalDato(MyVenta.cuota_inicial_pagada, txtCuotaInicial.Tag)
                    txtCuotaInicialSaldo.Text = EvalDato(MyVenta.cuota_inicial - MyVenta.cuota_inicial_pagada, txtCuotaInicial.Tag)
                End With
            End If
        End If
    End Sub

    Private Sub PoblarProforma()
        MyVenta = New entVenta
        MyProforma = dalFinanciamiento.ObtenerProforma(MyUsuario.empresa, MyProforma(0).PROFORMA)

        With MyProforma(0)
            txtProforma.Text = .PROFORMA
            txtFechaEmision.Text = EvalDato(.FECHA_DESEMBOLSO, txtFechaEmision.Tag)
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            txtDomicilio.Text = .DOMICILIO
            cmbTipoPrestamo.SelectedValue = .TIPO_PRESTAMO
            cmbFormaPago.SelectedValue = .FORMA_PAGO
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
            txtCapital.Text = EvalDato(.CAPITAL, txtCapital.Tag)
            txtNumeroCuotas.Text = EvalDato(.NUMERO_CUOTAS, txtNumeroCuotas.Tag)
            txtTasaInteresMensual.Text = EvalDato(.TASA_INTERES, txtTasaInteresMensual.Tag)
            txtTasaMorosidadMensual.Text = EvalDato(.TASA_MOROSIDAD, txtTasaMorosidadMensual.Tag)
            txtValorCuota.Text = EvalDato(.VALOR_CUOTA, txtValorCuota.Tag)
            txtTotalInteres.Text = EvalDato(.TOTAL_INTERES, txtTotalInteres.Tag)
            txtTotalImpuesto.Text = EvalDato(.TOTAL_IMPUESTO, txtTotalImpuesto.Tag)
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
            ckbIncluyeIGV.Checked = IIf(.TOTAL_IMPUESTO <> 0, True, False)
        End With

        If MyProforma(0).VENTA <> "000000000000" Then
            MyVenta.venta = MyProforma(0).VENTA
            PoblarVenta()
        End If

        MyCuentaComercial = New entCuentaComercial

        MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyProforma(0).TIPO_DOCUMENTO, MyProforma(0).NRO_DOCUMENTO.Trim)

        If MyCuentaComercial.cuenta_comercial Is Nothing Then
            MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyProforma(0).TIPO_DOCUMENTO, MyProforma(0).NRO_DOCUMENTO.Trim)
        End If


        If Not MyCuentaComercial.nro_documento Is Nothing Then
            EnableComboBox(cmbDocumentoTipo, False)
            EnableTextBox(txtDocumentoNumero, False)

            EnableTextBox(txtRazonSocial, False)

            Call PoblarCuentaComercial()

            'EnableComboBox(cmbDocumentoTipo, False)
            txtCapital.Focus()
        End If
    End Sub

    Private Sub PoblarFormulario()
        MyVenta = New entVenta
        ActivarCabecera(False)
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, MyPrestamo(0).PRESTAMO)

        With MyPrestamo(0)
            txtPrestamo.Text = .PRESTAMO
            txtFechaEmision.Text = EvalDato(.FECHA_DESEMBOLSO, txtFechaEmision.Tag)
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            txtDomicilio.Text = .DOMICILIO
            cmbTipoPrestamo.SelectedValue = .TIPO_PRESTAMO
            cmbFormaPago.SelectedValue = .FORMA_PAGO
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
            txtCapital.Text = EvalDato(.CAPITAL, txtCapital.Tag)
            txtNumeroCuotas.Text = EvalDato(.NUMERO_CUOTAS, txtNumeroCuotas.Tag)
            txtTasaInteresMensual.Text = EvalDato(.TASA_INTERES, txtTasaInteresMensual.Tag)
            txtTasaMorosidadMensual.Text = EvalDato(.TASA_MOROSIDAD, txtTasaMorosidadMensual.Tag)

            txtValorCuota.Text = EvalDato(.VALOR_CUOTA, txtValorCuota.Tag)
            txtTotalInteres.Text = EvalDato(.TOTAL_INTERES, txtTotalInteres.Tag)
            txtTotalImpuesto.Text = EvalDato(.TOTAL_IMPUESTO, txtTotalImpuesto.Tag)
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
            txtProforma.Text = .PROFORMA
            ckbIncluyeIGV.Checked = IIf(.PORCENTAJE_IMPUESTO = 0, False, True)

            txtCuotaInicial.Text = EvalDato(.CUOTA_INICIAL, txtCuotaInicial.Tag)
            txtCuotaInicialPagada.Text = EvalDato(.CUOTA_INICIAL_PAGADA, txtCuotaInicialPagada.Tag)
            If .CUOTA_INICIAL_SALDO_FECHA_PAGO.Year <> 1900 Then
                txtCuotaInicialFechaPagoSaldo.Text = EvalDato(.CUOTA_INICIAL_SALDO_FECHA_PAGO, txtCuotaInicialFechaPagoSaldo.Tag)
            End If

        End With

        If MyPrestamo(0).VENTA <> "000000000000" Then
            MyVenta.venta = MyPrestamo(0).VENTA
            PoblarVenta()
        Else
            MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyPrestamo(0).TIPO_DOCUMENTO, MyPrestamo(0).NRO_DOCUMENTO)
            Call PoblarCuentaComercial()
        End If

        MyPrestamoCuotas = dalFinanciamiento.ObtenerPrestamoCuotas(MyUsuario.empresa, MyPrestamo(0).PRESTAMO)

        UC_ToolBar.btnImprimir_Visible = True
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnImprimir_Focus = True
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Dim MyVentaNew As New entVenta
        Dim MyCantidadControl As Integer = 0
        Dim MyForm As New frmFacturacionProductosLista(MyVentaNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If Not MyVentaNew.venta Is Nothing Then
            MyVenta = MyVentaNew
            Call PoblarVenta()
            EnableComboBox(cmbDocumentoTipo, False)
            EnableTextBox(txtDocumentoNumero, False)
            txtCapital.Focus()
        Else
            EnableComboBox(cmbDocumentoTipo, True)
            EnableTextBox(txtDocumentoNumero, True)
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim ContinuarGrabar As Boolean = True

        If txtDocumentoNumero.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Documento de Identidad.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtDocumentoNumero.Focus()
            ContinuarGrabar = False
        ElseIf txtRazonSocial.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Nombre o Razón Social del Cliente .", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtRazonSocial.Focus()
            ContinuarGrabar = False
        ElseIf txtDomicilio.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Domicilio del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtDomicilio.Focus()
            ContinuarGrabar = False
        ElseIf txtTelefono.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Número de Teléfono 1.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTelefono.Focus()
            ContinuarGrabar = False
        ElseIf txtCelular.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Número de Celular.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtCelular.Focus()
            ContinuarGrabar = False
        ElseIf txtFechaNacimiento.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar la Fecha de Nacimiento del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtFechaNacimiento.Focus()
            ContinuarGrabar = False
        ElseIf cmbSexo.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Sexo del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbSexo.Focus()
            ContinuarGrabar = False
        ElseIf cmbEstadoCivil.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Estado Civil del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbEstadoCivil.Focus()
            ContinuarGrabar = False
        ElseIf cmbNivelEducativo.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Nivel Educativo del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbNivelEducativo.Focus()
            ContinuarGrabar = False
        ElseIf cmbOcupacion.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar la Ocupación del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbOcupacion.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtCapital.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Capital.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtCapital.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtNumeroCuotas.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Numero de Cuotas.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtNumeroCuotas.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtTasaInteresMensual.Text) = 0 Then
            Resp = MsgBox("Debe registrar la Tasa de Interes (% INTERES).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTasaInteresMensual.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtTasaMorosidadMensual.Text) = 0 Then
            Resp = MsgBox("Debe registrar la Tasa de Morosidad (% MORA).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTasaMorosidadMensual.Focus()
            ContinuarGrabar = False
        ElseIf txtFechaPrimerPago.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar la Fecha del Primer Pago (F. PRIMER PAGO).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtFechaPrimerPago.Focus()
            ContinuarGrabar = False
        Else
            If Tipo_accion = "VEHICULAR" Then
                If CDec(txtCuotaInicial.Text) = 0 Then
                    Resp = MsgBox("Debe registrar la Cuota Inicial (C. I.).", MsgBoxStyle.Information, "PROCESO CANCELADO")
                    txtCuotaInicial.Focus()
                    ContinuarGrabar = False
                ElseIf CDec(txtCuotaInicialPagada.Text) <> 0 Then
                    Dim CuotaInicial As Decimal = CDec(txtCuotaInicial.Text)
                    Dim CuotaInicialpagada As Decimal = CDec(txtCuotaInicialPagada.Text)
                    If CuotaInicialpagada > CuotaInicial Then
                        Resp = MsgBox("La Cuota Inicial Pagada no puede ser mayor que la Cuota Inicial.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                        txtCuotaInicialPagada.Focus()
                        ContinuarGrabar = False
                    End If
                ElseIf CDec(txtCuotaInicialSaldo.Text) <> 0 And txtCuotaInicialFechaPagoSaldo.Text.Trim.Length = 0 Then
                    Resp = MsgBox("Debe registrar la Fecha de Pago del Saldo de la Cuota Inicial (F. PAGO SALDO).", MsgBoxStyle.Information, "PROCESO CANCELADO")
                    txtCuotaInicialFechaPagoSaldo.Focus()
                    ContinuarGrabar = False
                ElseIf txtCuotaInicialFechaPagoSaldo.Text.Trim.Length <> 0 Then
                    Dim FechaPagoSaldoCuotaInicial As Date = CDate(txtCuotaInicialFechaPagoSaldo.Text)
                    Dim FechaPrimerPago As Date = CDate(txtFechaPrimerPago.Text)
                    If FechaPagoSaldoCuotaInicial >= FechaPrimerPago Then
                        Resp = MsgBox("La Fecha de Pago del Saldo de la Cuota Inicial (F. PAGO SALDO) no es válida." & vbCrLf & "Debe ser menor que la Fecha del Primer Pago.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                        txtCuotaInicialFechaPagoSaldo.Focus()
                        ContinuarGrabar = False
                    End If
                End If
            End If
        End If

        If ContinuarGrabar = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnInformacion_Visible = False

                Call CalcularCuota() ' <--- En este proceso se llena MyPrestamoCuotas

                With MyCuentaComercial
                    .empresa = MyUsuario.empresa
                    .tipo_documento = cmbDocumentoTipo.SelectedValue
                    .nro_documento = txtDocumentoNumero.Text
                    .razon_social = txtRazonSocial.Text.Trim
                    .domicilio = txtDomicilio.Text.Trim
                    .referencia = txtReferencia.Text.Trim
                    .departamento = cmbDepartamento.SelectedValue
                    .provincia = cmbProvincia.SelectedValue
                    .ubigeo = cmbDistrito.SelectedValue
                    .telefono = txtTelefono.Text
                    .telefono_otro = txtTelefonoOtro.Text
                    .celular = txtCelular.Text
                    .email = txtEmail.Text.Trim
                    .direccion_trabajo = txtDireccionTrabajo.Text.Trim
                    .referencia_trabajo = txtReferenciaTrabajo.Text.Trim
                    .telefono_trabajo = txtTelefonoTrabajo.Text

                    If cmbTipoMoneda.SelectedValue = "1" Then
                        .saldo_pagar_mn = .saldo_pagar_mn + CDec(txtTotalPrestamo.Text)
                    Else
                        .saldo_pagar_me = .saldo_pagar_me - CDec(txtTotalPrestamo.Text)
                    End If

                    .afecto_igv = IIf(ckbIncluyeIGV.Checked = True, "SI", "NO")

                    If txtFechaNacimiento.Text.Length <> 0 Then .fecha_nacimiento = CDate(txtFechaNacimiento.Text)
                    .sexo = cmbSexo.Text.Substring(0, 1)
                    .estado_civil = cmbEstadoCivil.SelectedValue
                    .nivel_educativo = cmbNivelEducativo.SelectedValue
                    .ocupacion = cmbOcupacion.SelectedValue

                    .nombre_conviviente = txtNombreConviviente.Text

                    .agencia_registro = "A0000" & MyUsuario.almacen
                    .agencia_modifica = "A0000" & MyUsuario.almacen
                    .usuario_registro = MyUsuario.usuario
                    .usuario_modifica = MyUsuario.usuario
                End With

                MyPrestamo = dalFinanciamiento.ObtenerPrestamoNuevo()

                With MyPrestamo(0)
                    .EMPRESA = MyUsuario.empresa
                    .EJERCICIO = txtEjercicio.Text
                    .MES = txtMes.Text
                    .TIPO_PRESTAMO = cmbTipoPrestamo.SelectedValue
                    .FORMA_PAGO = cmbFormaPago.SelectedValue
                    .FECHA_DESEMBOLSO = MyFechaServidor.ToShortDateString
                    .TIPO_MONEDA = cmbTipoMoneda.SelectedValue
                    .CAPITAL = CDec(txtCapital.Text)
                    .NUMERO_CUOTAS = CDec(txtNumeroCuotas.Text)
                    .TASA_INTERES = CDec(txtTasaInteresMensual.Text)
                    .TASA_MOROSIDAD = CDec(txtTasaMorosidadMensual.Text)
                    .PORCENTAJE_IMPUESTO = IIf(ckbIncluyeIGV.Checked = True, MyIGV, 0)
                    .VALOR_CUOTA = CDec(txtValorCuota.Text)
                    .TOTAL_INTERES = CDec(txtTotalInteres.Text)
                    .TOTAL_IMPUESTO = CDec(txtTotalImpuesto.Text)
                    .TOTAL_PRESTAMO = CDec(txtTotalPrestamo.Text)
                    .TOTAL_SALDO = CDec(txtTotalPrestamo.Text)
                    .FECHA_PRIMER_PAGO = CDate(txtFechaPrimerPago.Text)
                    .MONTO_SOLICITADO = CDec(txtCapital.Text)

                    If Tipo_accion = "VEHICULAR" Then
                        .CUOTA_INICIAL = CDec(txtCuotaInicial.Text)
                        .CUOTA_INICIAL_PAGADA = CDec(txtCuotaInicialPagada.Text)
                        If txtCuotaInicialFechaPagoSaldo.Text.Length <> 0 Then .CUOTA_INICIAL_SALDO_FECHA_PAGO = CDate(txtCuotaInicialFechaPagoSaldo.Text)
                    End If

                    .VENTA = txtVenta.Text
                    .PROFORMA = txtProforma.Text
                    .PRESTAMO_REFINANCIADO = CUO_Nulo
                    .TIPO_DOCUMENTO = cmbDocumentoTipo.SelectedValue
                    .NRO_DOCUMENTO = txtDocumentoNumero.Text
                    .RAZON_SOCIAL = txtRazonSocial.Text
                    .DOMICILIO = txtDomicilio.Text
                    .AGENCIA_REGISTRO = "A0000" & MyUsuario.almacen
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyPrestamo = dalFinanciamiento.GrabarPrestamo(MyPrestamo, MyPrestamoCuotas, MyCuentaComercial)
                txtPrestamo.Text = MyPrestamo(0).PRESTAMO
                Call ActivarCabecera(False)
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
                Resp = MsgBox("El Préstamo se grabó con éxito.", MsgBoxStyle.Information, "GRABAR PRESTAMO")
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If

    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyPrestamoNew As New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoNew = dalFinanciamiento.ObtenerPrestamoNuevo()

        Dim MyForm As New frmPrestamosLista(MyPrestamoNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If MyPrestamoNew(0).PRESTAMO.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyPrestamo = MyPrestamoNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtPrestamo.Text.Trim.Length <> 0 Then
            MyPrestamo(0).DOMICILIO = txtDomicilio.Text & " " & cmbDistrito.Text & " " & cmbProvincia.Text & " " & cmbDepartamento.Text
            Dim MyForm As New frmPrestamoEstadoCuenta(MyPrestamo, MyPrestamoCuotas, cmbTipoPrestamo.Text, cmbFormaPago.Text, True)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub btnBuscarProforma_Click(sender As Object, e As EventArgs) Handles btnBuscarProforma.Click
        Dim MyProformaNew As New dsFinanciero.PROFORMASDataTable
        MyProformaNew = dalFinanciamiento.ObtenerProformaNueva()

        Dim MyForm As New frmProformasLista(MyProformaNew, txtEjercicio.Text, txtMes.Text, IIf(Tipo_accion = "VEHICULAR", True, False))
        MyForm.ShowDialog()
        If MyProformaNew(0).PROFORMA.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyProforma = MyProformaNew
            Call PoblarProforma()
        End If
    End Sub

#End Region

End Class
