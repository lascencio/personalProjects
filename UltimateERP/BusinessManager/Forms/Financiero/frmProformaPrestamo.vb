Public Class frmProformaPrestamo

    Private MyVenta As entVenta
    Private MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable
    Private MyCuentaComercial As New entCuentaComercial
    Private MyProducto As entProducto

    Private MyProforma As dsFinanciero.PROFORMASDataTable
    Private MyProformas As dsFinanciero.PROFORMAS_LISTADataTable
    Private MyProformaProyeccion As dsFinanciero.PROFORMA_PROYECCIONDataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private EsVehicular As Boolean


    Private Sub frmProformaPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmProformaPrestamo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyTipoPrestamo As New dsTablasGenericas.LISTADataTable
        Dim MyTipoPrestamoNV As dsTablasGenericas.LISTADataTable

        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO")

        MyTipoPrestamoNV = ObtenerListaEmpresa("FIN_TIPO_PRESTAMO", True)

        If MyTipoPrestamoNV.Rows.Count <> 0 Then
            If Tipo_accion = "VEHICULAR" Then
                For NEle As Integer = 0 To MyTipoPrestamoNV.Rows.Count - 1
                    If MyTipoPrestamoNV(NEle).CODIGO = "05" Then
                        MyTipoPrestamo.ImportRow(MyTipoPrestamoNV(NEle))
                    End If
                Next
                ckbIncluyeIGV.Enabled = False
                Me.Height = 397

            Else
                For NEle As Integer = 0 To MyTipoPrestamoNV.Rows.Count - 1
                    If MyTipoPrestamoNV(NEle).CODIGO <> "05" Then
                        MyTipoPrestamo.ImportRow(MyTipoPrestamoNV(NEle))
                    End If
                Next
                Me.Height = 279

            End If
        End If

        cmbTipoPrestamo.DataSource = MyTipoPrestamo

        lblTipoProforma.Text = "PROFORMA PRESTAMO " & Tipo_accion

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

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
        Call CalcularCuota()
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If cmbFormaPago.SelectedIndex <> -1 Then
            Call CalcularCuota()
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

    Private Sub ckbIncluyeIGV_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIncluyeIGV.CheckedChanged
        Call CalcularCuota()
    End Sub

    Private Sub ValidarCuotaInicial_Validated(sender As Object, e As EventArgs) Handles txtCuotaInicial.Validated, txtCuotaInicialPagada.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)

        If sender.Name = "txtCuotaInicial" Then
            txtCuotaInicialPagada.Focus()
        Else
            If txtCuotaInicialPagada.Text > txtCuotaInicial.Text Then txtCuotaInicialPagada.Text = "0.00"
        End If

        Call CalcularCuotaInicialSaldo()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta
        MyVentaVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable
        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

        MyProforma = New dsFinanciero.PROFORMASDataTable
        MyProformaProyeccion = New dsFinanciero.PROFORMA_PROYECCIONDataTable

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

        If Tipo_accion = "VEHICULAR" Then
            cmbTipoPrestamo.SelectedValue = "05"
            UC_ToolBar.btnInformacion_Visible = True
            ckbIncluyeIGV.Checked = True
            txtCapital.Focus()
            txtCapital.Select()
        Else
            cmbTipoPrestamo.SelectedValue = "01"
            UC_ToolBar.btnInformacion_Visible = False
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
        Else
            EnableComboBox(cmbDocumentoTipo, IndicaActivo)
            EnableTextBox(txtDocumentoNumero, IndicaActivo)
            EnableTextBox(txtRazonSocial, IndicaActivo)
            EnableTextBox(txtDomicilio, IndicaActivo)
        End If

        EnableComboBox(cmbTipoPrestamo, IndicaActivo)
        EnableComboBox(cmbFormaPago, IndicaActivo)
        EnableComboBox(cmbTipoMoneda, IndicaActivo)

        EnableTextBox(txtCapital, IndicaActivo)
        EnableTextBox(txtNumeroCuotas, IndicaActivo)
        EnableTextBox(txtTasaInteresMensual, IndicaActivo)
        EnableTextBox(txtTasaMorosidadMensual, IndicaActivo)

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
                EnableTextBox(txtDomicilio, False)

                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                    cmbTipoMoneda.SelectedValue = .tipo_moneda
                    txtDomicilio.Text = .domicilio
                End With

                EnableComboBox(cmbDocumentoTipo, False)
                txtCapital.Focus()
            Else
                EnableTextBox(txtRazonSocial, True)
                EnableTextBox(txtDomicilio, True)

                If Not String.IsNullOrEmpty(MyDocumentoNumero) Then
                    txtCuentaComercial.Text = "00000000"
                    txtRazonSocial.Text = Nothing
                    txtDomicilio.Text = Nothing
                    txtRazonSocial.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CalcularCuota()
        Dim Amortizacion As Decimal
        Dim Interes As Decimal
        Dim Impuesto As Decimal
        Dim ValorCuota As Decimal

        Dim TotalInteres As Decimal
        Dim TotalImpuesto As Decimal
        Dim TotalPrestamo As Decimal

        Dim NumeroCuotas As Decimal = CDec(txtNumeroCuotas.Text)
        MyProformaProyeccion = New dsFinanciero.PROFORMA_PROYECCIONDataTable

        If NumeroCuotas <> 0 Then
            Dim FormaPago As String = cmbFormaPago.Text
            Dim NFila As Integer = 1

            Dim Capital As Decimal = txtCapital.Text

            Dim TasaInteresMensual As Decimal = txtTasaInteresMensual.Text
            Dim InteresMensual As Decimal = Capital * TasaInteresMensual / 100

            Dim TotalInteresMensual As Decimal = InteresMensual * NumeroCuotas
            Dim TotalInteresQuincenal As Decimal = InteresMensual / 2 * NumeroCuotas
            Dim TotalInteresSemanal As Decimal = InteresMensual / 4 * NumeroCuotas
            Dim TotalInteresDiario As Decimal = InteresMensual / 30 * NumeroCuotas

            TotalInteres = 0 : TotalImpuesto = 0 : TotalPrestamo = 0

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
            'ValorCuota = Amortizacion + Interes + Impuesto
            ValorCuota = Math.Round((Capital + TotalInteres + TotalImpuesto) / NumeroCuotas, 2)


            'TotalPrestamo = ValorCuota * NumeroCuotas
            TotalPrestamo = Capital + TotalInteres + TotalImpuesto

            txtValorCuota.Text = EvalDato(ValorCuota, txtValorCuota.Tag)

            txtTotalInteres.Text = EvalDato(TotalInteres, txtTotalInteres.Tag)
            txtTotalImpuesto.Text = EvalDato(TotalImpuesto, txtTotalImpuesto.Tag)
            txtTotalPrestamo.Text = EvalDato(TotalPrestamo, txtTotalPrestamo.Tag)

            For Cuotas As Integer = NumeroCuotas + 1 To NumeroCuotas + 13
                TotalInteresMensual = InteresMensual * Cuotas
                TotalInteresQuincenal = InteresMensual / 2 * Cuotas
                TotalInteresSemanal = InteresMensual / 4 * Cuotas
                TotalInteresDiario = InteresMensual / 30 * Cuotas

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

                Amortizacion = Math.Round(Capital / Cuotas, 2)
                Interes = Math.Round(TotalInteres / Cuotas, 2)
                Impuesto = Math.Round(TotalImpuesto / Cuotas, 2)
                'ValorCuota = Amortizacion + Interes + Impuesto
                ValorCuota = Math.Round((Capital + TotalInteres + TotalImpuesto) / Cuotas, 2)

                'TotalPrestamo = ValorCuota * Cuotas
                TotalPrestamo = Capital + TotalInteres + TotalImpuesto

                MyProformaProyeccion.Rows.Add(NFila, Cuotas, Amortizacion, Interes, Impuesto, ValorCuota, TotalPrestamo)
                NFila = NFila + 1
            Next
        Else
            txtValorCuota.Text = "0.00"
            txtTotalInteres.Text = "0.00"
            txtTotalImpuesto.Text = "0.00"
            txtTotalPrestamo.Text = "0.00"
        End If
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
                    MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, .cuenta_comercial)
                    txtCuentaComercial.Text = .cuenta_comercial
                    txtRazonSocial.Text = MyCuentaComercial.razon_social
                    cmbDocumentoTipo.SelectedValue = MyCuentaComercial.tipo_documento
                    txtDocumentoNumero.Text = MyCuentaComercial.nro_documento
                    cmbTipoMoneda.SelectedValue = .tipo_moneda
                    txtDomicilio.Text = MyCuentaComercial.domicilio

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

    Private Sub PoblarFormulario()
        MyVenta = New entVenta
        ActivarCabecera(False)
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

        UC_ToolBar.btnImprimir_Visible = True
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnImprimir_Focus = True
    End Sub

    Private Sub CalcularCuotaInicialSaldo()
        Dim CuotaInicial As Decimal
        Dim CuotaInicialPagada As Decimal
        Dim CuotaInicialSaldo As Decimal

        CuotaInicial = CDec(txtCuotaInicial.Text)
        CuotaInicialPagada = CDec(txtCuotaInicialPagada.Text)

        CuotaInicialSaldo = CuotaInicial - CuotaInicialPagada

        txtCuotaInicialSaldo.Text = EvalDato(CuotaInicialSaldo, txtCuotaInicialSaldo.Tag)
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
        ElseIf CDec(txtCapital.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Capital.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtCapital.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtNumeroCuotas.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Numero de Cuotas.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtNumeroCuotas.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtTasaInteresMensual.Text) = 0 Then
            Resp = MsgBox("Debe registrar la Tasa de Interes.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTasaInteresMensual.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtTasaMorosidadMensual.Text) = 0 Then
            Resp = MsgBox("Debe registrar la Tasa de Morosidad.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTasaMorosidadMensual.Focus()
            ContinuarGrabar = False
        Else
            If Tipo_accion = "VEHICULAR" Then
                If CDec(txtCuotaInicial.Text) = 0 Then
                    Resp = MsgBox("Debe registrar la Cuota Inicial (C. I.).", MsgBoxStyle.Information, "PROCESO CANCELADO")
                    txtCuotaInicial.Focus()
                    ContinuarGrabar = False
                ElseIf CDec(txtCuotaInicialSaldo.Text) <> 0 Then
                    Resp = MsgBox("El Saldo de la Cuota Inicial (C. I. SALDO) es diferente de cero." & vbCrLf & "¿Desea grabar la proforma con esa condición?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR ACCION A REALIZAR")
                    If Resp = "7" Then ' 7 = vbNo
                        txtCuotaInicialPagada.Focus()
                        ContinuarGrabar = False
                    End If
                End If
            End If
        End If

        If ContinuarGrabar = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnInformacion_Visible = False

                MyProforma = dalFinanciamiento.ObtenerProformaNueva()

                With MyProforma(0)
                    .EMPRESA = MyUsuario.empresa
                    .EJERCICIO = txtEjercicio.Text
                    .MES = txtMes.Text
                    .TIPO_PRESTAMO = cmbTipoPrestamo.SelectedValue
                    .FORMA_PAGO = cmbFormaPago.SelectedValue
                    .FECHA_DESEMBOLSO = Now.ToShortDateString
                    .TIPO_MONEDA = cmbTipoMoneda.SelectedValue
                    .CAPITAL = CDec(txtCapital.Text)
                    .NUMERO_CUOTAS = CDec(txtNumeroCuotas.Text)
                    .TASA_INTERES = CDec(txtTasaInteresMensual.Text)
                    .TASA_MOROSIDAD = CDec(txtTasaMorosidadMensual.Text)
                    .VALOR_CUOTA = CDec(txtValorCuota.Text)
                    .TOTAL_INTERES = CDec(txtTotalInteres.Text)
                    .TOTAL_IMPUESTO = CDec(txtTotalImpuesto.Text)
                    .TOTAL_PRESTAMO = CDec(txtTotalPrestamo.Text)
                    .CUOTA_INICIAL = CDec(txtCuotaInicial.Text)
                    .VENTA = txtVenta.Text
                    .TIPO_DOCUMENTO = cmbDocumentoTipo.SelectedValue
                    .NRO_DOCUMENTO = txtDocumentoNumero.Text
                    .RAZON_SOCIAL = txtRazonSocial.Text
                    .DOMICILIO = txtDomicilio.Text
                    .AGENCIA_REGISTRO = "A0000" & MyUsuario.almacen
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyProforma = dalFinanciamiento.GrabarProforma(MyProforma, IIf(Tipo_accion = "VEHICULAR", True, False), CDec(txtCuotaInicial.Text), CDec(txtCuotaInicialPagada.Text))
                txtProforma.Text = MyProforma(0).PROFORMA
                Call ActivarCabecera(False)
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
                Resp = MsgBox("La Proforma se grabó con éxito.", MsgBoxStyle.Information, "GRABAR PROFORMA")
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If

    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyProformaNew As New dsFinanciero.PROFORMASDataTable
        MyProformaNew = dalFinanciamiento.ObtenerProformaNueva()

        Dim MyForm As New frmProformasLista(MyProformaNew, txtEjercicio.Text, txtMes.Text, IIf(Tipo_accion = "VEHICULAR", True, False))
        MyForm.ShowDialog()
        If MyProformaNew(0).PROFORMA.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyProforma = MyProformaNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtProforma.Text.Trim.Length <> 0 Then
            Call CalcularCuota()
            Dim MyForm As New frmProformaPrestamoImprimir(MyProforma, MyProformaProyeccion, cmbTipoPrestamo.Text, cmbFormaPago.Text)
            MyForm.ShowDialog()
        End If
    End Sub

#End Region

End Class
