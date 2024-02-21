Public Class frmRefinanciarPrestamo

    Private MyCuentaComercial As New entCuentaComercial

    Private MyPrestamoRefinanciar As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamosRefinanciarLista As dsFinanciero.PRESTAMOS_LISTADataTable

    Private MyPrestamoRefinanciarCuotas As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable

    Private MyNuevoPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyNuevoPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private NumeroIndiceEditar As Integer

    Private Sub frmRefinanciarPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRefinanciarPrestamo_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPagoPrestamo, "FIN_FORMA_PAGO")
        ActualizarListaEmpresa(cmbFormaPagoRefinanciamiento, "FIN_FORMA_PAGO")
        ActualizarListaEmpresa(cmbTipoPrestamo, "FIN_TIPO_PRESTAMO")

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

    Private Sub cmbPrestamo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrestamo.SelectedIndexChanged
        If cmbPrestamo.SelectedIndex <> -1 Then
            Call PoblarCuotasPendientes(cmbPrestamo.SelectedValue)
            Call ActivarRefinanciamiento(True)
        Else
            Call ActivarRefinanciamiento(False)
        End If
    End Sub

    Private Sub cmbFormaPagoRefinanciamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPagoRefinanciamiento.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            Call CalcularFechaPrimerPago()
            Call CalcularCuota()
        End If
    End Sub

    Private Sub ValidarImportes_Validated(sender As Object, e As EventArgs) Handles txtCapital.Validated, txtNumeroCuotas.Validated, txtTasaInteresMensual.Validated, txtTasaMorosidadMensual.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        Call CalcularCuota()
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaPrimerPago.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If sender.Name = "txtFechaPrimerPago" Then
            If txtFechaPrimerPago.Text.Trim.Length = 0 Then CalcularFechaPrimerPago()
        End If
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyPrestamoRefinanciar = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoRefinanciarCuotas = New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        MyPrestamosRefinanciarLista = New dsFinanciero.PRESTAMOS_LISTADataTable

        MyNuevoPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyNuevoPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        cmbTipoMoneda.SelectedValue = "1"
        txtFechaEmision.Text = EvalDato(MyFechaServidor, "F")
        cmbDocumentoTipo.SelectedValue = "1"

        ActualizarCombos = True

        EnableComboBox(cmbPrestamo, True)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
    End Sub

    Private Sub ActivarRefinanciamiento(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbFormaPagoRefinanciamiento, IndicaActivo)
        EnableTextBox(txtCapital, IndicaActivo)
        EnableTextBox(txtNumeroCuotas, IndicaActivo)
        EnableTextBox(txtTasaInteresMensual, IndicaActivo)
        EnableTextBox(txtTasaMorosidadMensual, IndicaActivo)
        EnableTextBox(txtFechaPrimerPago, IndicaActivo)

        If IndicaActivo = True Then cmbFormaPagoRefinanciamiento.Focus()
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmClientesLista(MyCuentaComercial)
                MyForm.ShowDialog()
                If Not MyCuentaComercial.nro_documento Is Nothing Then MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyCuentaComercial.tipo_documento, MyCuentaComercial.nro_documento)
            Else
                MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                If MyCuentaComercial.nro_documento Is Nothing Then
                    Resp = MsgBox("El documento de identidad ingresado " & MyDocumentoNumero & " no existe.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                End If
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                MyPrestamosRefinanciarLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "V")
                If MyPrestamosRefinanciarLista.Rows.Count = 0 Then
                    Resp = MsgBox("El cliente " & MyCuentaComercial.razon_social.Trim & " no tiene préstamos vigentes.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                Else
                    EnableComboBox(cmbDocumentoTipo, False)
                    EnableTextBox(txtDocumentoNumero, False)
                    With MyCuentaComercial
                        cmbDocumentoTipo.SelectedValue = .tipo_documento
                        txtDocumentoNumero.Text = .nro_documento
                        txtRazonSocial.Text = .razon_social.Trim
                        .agencia_registro = "A0000" & MyUsuario.almacen
                    End With
                    cmbPrestamo.Focus()
                End If
            Else
                MyPrestamosRefinanciarLista = New dsFinanciero.PRESTAMOS_LISTADataTable
                txtRazonSocial.Text = Nothing
            End If
            cmbPrestamo.DataSource = MyPrestamosRefinanciarLista
        End If
    End Sub

    Private Sub PoblarCuotasPendientes(IdPrestamo As String)
        Dim TasaMorosidad As Decimal
        Dim ImporteMorosidad As Decimal
        Dim TotalCuotas As Decimal
        Dim TotalMoras As Decimal

        MyPrestamoRefinanciar = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, IdPrestamo)
        MyPrestamoRefinanciarCuotas = dalFinanciamiento.ObtenerPrestamoCuotasLista(MyUsuario.empresa, IdPrestamo, False)

        txtPrestamo.Text = MyPrestamoRefinanciar(0).PRESTAMO
        cmbTipoMoneda.SelectedValue = MyPrestamoRefinanciar(0).TIPO_MONEDA
        cmbFormaPagoPrestamo.SelectedValue = MyPrestamoRefinanciar(0).FORMA_PAGO
        cmbTipoPrestamo.SelectedValue = MyPrestamoRefinanciar(0).TIPO_PRESTAMO
        txtTotalPrestamoRefinanciar.Text = EvalDato(MyPrestamoRefinanciar(0).TOTAL_PRESTAMO, txtTotalPrestamoRefinanciar.Tag)

        If MyPrestamoRefinanciarCuotas.Rows.Count <> 0 Then
            TasaMorosidad = MyPrestamoRefinanciar(0).TASA_MOROSIDAD
            For NFila As Integer = 0 To MyPrestamoRefinanciarCuotas.Rows.Count - 1
                With MyPrestamoRefinanciarCuotas(NFila)
                    If .FECHA_VENCIMIENTO < MyFechaServidor Then
                        If .SALDO_CUOTA > 0 Then
                            ImporteMorosidad = .SALDO_CUOTA * TasaMorosidad / 100 / 30 * .DIAS_MORA
                            .MORA = ImporteMorosidad
                            .MORA_PAGO = .MORA
                            TotalMoras = TotalMoras + ImporteMorosidad
                        End If
                    End If
                    TotalCuotas = TotalCuotas + .SALDO_CUOTA
                    .TOTAL_PAGO = .CUOTA_PAGO + .MORA_PAGO
                End With
            Next
        End If

        txtTotalCuotas.Text = EvalDato(TotalCuotas, txtTotalCuotas.Tag)
        txtTotalMoras.Text = EvalDato(TotalMoras, txtTotalMoras.Tag)
        txtTotalPagar.Text = EvalDato(TotalCuotas + TotalMoras, txtTotalPagar.Tag)

        cmbPrestamo.Focus()
    End Sub

    Private Sub PoblarPrestamo(Prestamo As String)
        MyPrestamoRefinanciar = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, Prestamo)

        With MyPrestamoRefinanciar(0)
            txtPrestamo.Text = .PRESTAMO
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
            txtTotalPrestamoRefinanciar.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamoRefinanciar.Tag)
        End With
    End Sub

    Private Sub CalcularFechaPrimerPago()
        Dim FechaPrimerPago As Date
        Dim FormaPago As String

        If cmbFormaPagoRefinanciamiento.SelectedIndex <> -1 Then
            FormaPago = cmbFormaPagoRefinanciamiento.Text
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
        MyNuevoPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        If NumeroCuotas <> 0 Then
            Dim FormaPago As String = cmbFormaPagoRefinanciamiento.Text

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

            If MyPrestamoRefinanciar(0).PORCENTAJE_IMPUESTO <> 0 Then
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

            Call GenerarCuotas(FormaPago, Amortizacion, Interes, Impuesto, ValorCuota) '<-- Aqui se generan las nuevas cuotas
        Else
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

        MyNuevoPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        For Cuota As Integer = 1 To NumeroCuotas
            If Cuota = 1 Then
                If txtFechaPrimerPago.Text.Trim.Length <> 0 Then FechaVencimiento = CDate(txtFechaPrimerPago.Text)
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

            MyNuevoPrestamoCuotas.Rows.Add(MyUsuario.empresa, Space(1), CuotaNumero, Ejercicio, Mes, FechaVencimiento, Amortizacion, Interes, impuesto, ValorCuota, FechaNulo, ValorCuota, 0, FechaNulo, Space(1), "V", MyAgencia(0).AGENCIA, MyUsuario.usuario, FechaNulo, Space(1), Space(1), FechaNulo)
        Next
    End Sub

    Private Sub PoblarFormulario()
        ActivarCabecera(False)
        ActivarRefinanciamiento(False)
        MyNuevoPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, MyNuevoPrestamo(0).PRESTAMO)

        With MyNuevoPrestamo(0)
            txtPrestamo.Text = .PRESTAMO
            txtFechaEmision.Text = EvalDato(.FECHA_DESEMBOLSO, txtFechaEmision.Tag)
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            cmbTipoPrestamo.SelectedValue = .TIPO_PRESTAMO
            cmbFormaPagoRefinanciamiento.SelectedValue = .FORMA_PAGO
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
            txtCapital.Text = EvalDato(.CAPITAL, txtCapital.Tag)
            txtNumeroCuotas.Text = EvalDato(.NUMERO_CUOTAS, txtNumeroCuotas.Tag)
            txtTasaInteresMensual.Text = EvalDato(.TASA_INTERES, txtTasaInteresMensual.Tag)
            txtTasaMorosidadMensual.Text = EvalDato(.TASA_MOROSIDAD, txtTasaMorosidadMensual.Tag)

            txtValorCuota.Text = EvalDato(.VALOR_CUOTA, txtValorCuota.Tag)
            txtTotalInteres.Text = EvalDato(.TOTAL_INTERES, txtTotalInteres.Tag)
            txtTotalImpuesto.Text = EvalDato(.TOTAL_IMPUESTO, txtTotalImpuesto.Tag)
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
        End With

        MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyNuevoPrestamo(0).TIPO_DOCUMENTO, MyNuevoPrestamo(0).NRO_DOCUMENTO)

        MyNuevoPrestamoCuotas = dalFinanciamiento.ObtenerPrestamoCuotas(MyUsuario.empresa, MyNuevoPrestamo(0).PRESTAMO)

        UC_ToolBar.btnImprimir_Visible = True
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

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim ContinuarGrabar As Boolean = True

        If txtDocumentoNumero.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Documento de Identidad.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtDocumentoNumero.Focus()
            ContinuarGrabar = False
        ElseIf cmbFormaPagoRefinanciamiento.SelectedIndex = -1 Then
            Resp = MsgBox("Debe indicar la Forma de Pago.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbFormaPagoRefinanciamiento.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtCapital.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Capital.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtCapital.Focus()
            ContinuarGrabar = False
        ElseIf CDec(txtNumeroCuotas.Text) = 0 Then
            Resp = MsgBox("Debe registrar el Numero de Cuotas.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtNumeroCuotas.Focus()
            ContinuarGrabar = False
            'ElseIf CDec(txtTasaInteresMensual.Text) = 0 Then
            '    Resp = MsgBox("Debe registrar la Tasa de Interes (% INTERES).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            '    txtTasaInteresMensual.Focus()
            '    ContinuarGrabar = False
            'ElseIf CDec(txtTasaMorosidadMensual.Text) = 0 Then
            '    Resp = MsgBox("Debe registrar la Tasa de Morosidad (% MORA).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            '    txtTasaMorosidadMensual.Focus()
            '    ContinuarGrabar = False
        ElseIf txtFechaPrimerPago.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar la Fecha del Primer Pago (F. PRIMER PAGO).", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtFechaPrimerPago.Focus()
            ContinuarGrabar = False
        End If

        If ContinuarGrabar = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False
                UC_ToolBar.btnInformacion_Visible = False

                Call CalcularCuota() ' <--- En este proceso se llena MyPrestamoCuotas

                With MyCuentaComercial
                    .agencia_registro = "A0000" & MyUsuario.almacen
                    .agencia_modifica = "A0000" & MyUsuario.almacen
                    .usuario_registro = MyUsuario.usuario
                    .usuario_modifica = MyUsuario.usuario
                End With

                MyNuevoPrestamo = dalFinanciamiento.ObtenerPrestamoNuevo()

                With MyNuevoPrestamo(0)
                    .EMPRESA = MyUsuario.empresa
                    .EJERCICIO = txtEjercicio.Text
                    .MES = txtMes.Text
                    .TIPO_PRESTAMO = MyPrestamoRefinanciar(0).TIPO_PRESTAMO
                    .FORMA_PAGO = cmbFormaPagoRefinanciamiento.SelectedValue
                    .FECHA_DESEMBOLSO = MyFechaServidor.ToShortDateString
                    .TIPO_MONEDA = cmbTipoMoneda.SelectedValue
                    .CAPITAL = CDec(txtCapital.Text)
                    .NUMERO_CUOTAS = CDec(txtNumeroCuotas.Text)
                    .TASA_INTERES = CDec(txtTasaInteresMensual.Text)
                    .TASA_MOROSIDAD = CDec(txtTasaMorosidadMensual.Text)
                    .PORCENTAJE_IMPUESTO = IIf(MyPrestamoRefinanciar(0).PORCENTAJE_IMPUESTO <> 0, MyIGV, 0)
                    .VALOR_CUOTA = CDec(txtValorCuota.Text)
                    .TOTAL_INTERES = CDec(txtTotalInteres.Text)
                    .TOTAL_IMPUESTO = CDec(txtTotalImpuesto.Text)
                    .TOTAL_PRESTAMO = CDec(txtTotalPrestamo.Text)
                    .TOTAL_SALDO = CDec(txtTotalPrestamo.Text)
                    .FECHA_PRIMER_PAGO = CDate(txtFechaPrimerPago.Text)
                    .MONTO_SOLICITADO = CDec(txtCapital.Text)
                    .VENTA = MyPrestamoRefinanciar(0).VENTA
                    .PROFORMA = MyPrestamoRefinanciar(0).PROFORMA
                    .PRESTAMO_REFINANCIADO = MyPrestamoRefinanciar(0).PRESTAMO
                    .TIPO_DOCUMENTO = cmbDocumentoTipo.SelectedValue
                    .NRO_DOCUMENTO = txtDocumentoNumero.Text
                    .RAZON_SOCIAL = txtRazonSocial.Text
                    .DOMICILIO = MyPrestamoRefinanciar(0).DOMICILIO
                    .AGENCIA_REGISTRO = "A0000" & MyUsuario.almacen
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyNuevoPrestamo = dalFinanciamiento.GrabarPrestamo(MyNuevoPrestamo, MyNuevoPrestamoCuotas, MyCuentaComercial, MyPrestamoRefinanciarCuotas)
                txtPrestamo.Text = MyNuevoPrestamo(0).PRESTAMO
                Call ActivarCabecera(False)
                Call ActivarRefinanciamiento(False)
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnImprimir_Focus = True
                Resp = MsgBox("El Refinanciamiento se grabó con éxito.", MsgBoxStyle.Information, "GRABAR REFINANCIAMIENTO")
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtPrestamo.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmPrestamoEstadoCuenta(MyNuevoPrestamo, MyNuevoPrestamoCuotas, cmbTipoPrestamo.Text, cmbFormaPagoRefinanciamiento.Text, True)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyPrestamoNew As New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoNew = dalFinanciamiento.ObtenerPrestamoNuevo()

        Dim MyForm As New frmPrestamosLista(MyPrestamoNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If MyPrestamoNew(0).PRESTAMO.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyNuevoPrestamo = MyPrestamoNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub btnBuscarPrestamo_Click(sender As Object, e As EventArgs) Handles btnBuscarPrestamo.Click
        Dim MyPrestamoRefinanciarNew As New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoRefinanciarNew = dalFinanciamiento.ObtenerPrestamoNuevo()

        Dim MyForm As New frmPrestamosLista(MyPrestamoRefinanciarNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If MyPrestamoRefinanciarNew(0).PRESTAMO.Trim.Length <> 0 Then
            Call PoblarPrestamo(MyPrestamoRefinanciarNew(0).PRESTAMO)
            Call ValidarDocumento()
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub


#End Region


End Class
