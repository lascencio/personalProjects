Public Class frmCobranzaProntoPago

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable
    Private MyCuentaComercial As New entCuentaComercial

    Private MyCobranza As dsFinanciero.COBRANZASDataTable
    Private MyCobranzaProntoPago As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private MonedaPrestamo As String
    Private MonedaPago As String
    Private TipoCambioPago As Decimal

    Private Sub frmCobranzaProntoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCobranzaProntoPago_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMonedaPrestamo, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPagoPrestamo, "FIN_FORMA_PAGO")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO_COBRANZA")
        ActualizarListaEmpresa(cmbTipoPrestamo, "FIN_TIPO_PRESTAMO")
        ActualizarListaGenerica(cmbTipoMonedaPago, "_TIPO_MONEDA")

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
        If sender.SelectedIndex <> -1 And txtCobranza.Text.Trim.Length = 0 Then Call PoblarCuotasPendientes(sender.SelectedValue)
    End Sub

    Private Sub Validar_Validated(sender As Object, e As EventArgs) Handles txtMesesAdicionales.Validated, txtMorasPagar.Validated, txtTipoCambioPago.Validated, txtDineroRecibido.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If sender.Text.Trim.Length <> 0 Then
            If sender.Name = "txtMesesAdicionales" Then
                Call RecalcularTotalProntoPago()
            ElseIf sender.Name = "txtMorasPagar" Then
                Call RecalcularTotalProntoPago()
            ElseIf sender.Name = "txtTipoCambioPago" Then
                If MonedaPrestamo <> MonedaPago Then
                    If CDec(sender.text) = 0 Then
                        Resp = MsgBox("Debe ingresar el tipo de cambio.", MsgBoxStyle.Exclamation, "DATO NO VALIDO")
                    Else
                        Call CalcularImportePago()
                        Call CalcularVueltoMN()
                    End If
                End If
            ElseIf sender.Name = "txtDineroRecibido" Then
                Call CalcularVueltoMN()
            End If
        End If
    End Sub

    Private Sub cmbTipoMonedaPrestamo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMonedaPrestamo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            MonedaPrestamo = sender.SelectedValue
        End If
    End Sub

    Private Sub cmbTipoMonedaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMonedaPago.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            MonedaPago = sender.SelectedValue
            If txtCobranza.Text.Trim.Length = 0 Then
                Call CalcularImportePago()
                Call CalcularVueltoMN()
            Else
                EnableTextBox(txtTipoCambioPago, False)
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoCuotasLista = New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable

        MyCobranza = New dsFinanciero.COBRANZASDataTable
        MyCobranzaProntoPago = New dsFinanciero.COBRANZAS_PRONTO_PAGODataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        gvCuotas.DataSource = MyPrestamoCuotasLista

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        txtCuentaComercial.Text = "00000000"

        cmbTipoMonedaPrestamo.SelectedValue = "1"
        txtFechaEmision.Text = EvalDato(MyFechaServidor, "F")
        cmbDocumentoTipo.SelectedValue = "1"

        ActualizarCombos = True

        cmbFormaPago.SelectedValue = "00000"
        cmbTipoMonedaPago.SelectedValue = "1"

        TipoCambioPago = 0

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
        EnableComboBox(cmbTipoMonedaPago, IndicaActivo)
        EnableTextBox(txtDineroRecibido, IndicaActivo)
        EnableComboBox(cmbPrestamo, IndicaActivo)
        EnableTextBox(txtMesesAdicionales, IndicaActivo)
        EnableTextBox(txtMorasPagar, IndicaActivo)
        gvCuotas.Enabled = IndicaActivo
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
                    Resp = MsgBox("El documento de identidad ingresado " & MyDocumentoNumero & " no existe.", MsgBoxStyle.Critical, "DATO NO VALIDO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                End If
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                MyPrestamosLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "V")
                If MyPrestamosLista.Rows.Count = 0 Then
                    Resp = MsgBox("El cliente " & MyCuentaComercial.razon_social.Trim & " no tiene préstamos vigentes.", MsgBoxStyle.Exclamation, "CLIENTE SIN DEUDAS")
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
                MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable
                txtRazonSocial.Text = Nothing
            End If
            cmbPrestamo.DataSource = MyPrestamosLista
        End If
    End Sub

    Private Sub CalcularImportePago()
        Dim ImportePago As Decimal = 0
        Dim TotalPagar As Decimal = CDec(txtTotalProntoPago.Text)

        If MonedaPrestamo = MonedaPago Then
            TipoCambioPago = 0
            txtTipoCambioPago.Text = EvalDato(TipoCambioPago, txtTipoCambioPago.Tag)
            EnableTextBox(txtTipoCambioPago, False)
        Else
            TipoCambioPago = CDec(txtTipoCambioPago.Text)
            EnableTextBox(txtTipoCambioPago, True)
        End If

        If TipoCambioPago <> 0 Then
            If MonedaPrestamo <> MonedaPago Then
                If MonedaPrestamo = "1" And MonedaPago = "2" Then
                    ImportePago = TotalPagar / TipoCambioPago
                Else
                    ImportePago = TotalPagar * TipoCambioPago
                End If
            Else
                ImportePago = TotalPagar
            End If
        Else
            ImportePago = TotalPagar
        End If
        txtImportePago.Text = EvalDato(ImportePago, txtImportePago.Tag)
    End Sub

    Private Sub CalcularVueltoMN()
        Dim ImportePago As Decimal
        Dim DineroRecibido As Decimal
        Dim DineroVuelto As Decimal = 0
        Dim DineroVueltoMN As Decimal = 0

        ImportePago = CDec(txtImportePago.Text)
        DineroRecibido = CDec(txtDineroRecibido.Text)
        TipoCambioPago = CDec(txtTipoCambioPago.Text)

        If DineroRecibido >= ImportePago Then
            DineroVuelto = DineroRecibido - ImportePago
            If MonedaPago = "2" Then
                DineroVueltoMN = DineroVuelto * TipoCambioPago
            Else
                DineroVueltoMN = DineroVuelto
            End If
        End If

        txtDineroVueltoMN.Text = EvalDato(DineroVueltoMN, txtDineroVueltoMN.Tag)
    End Sub

    Private Sub RecalcularTotalProntoPago()
        Dim MesesActuales As Integer = CDec(txtMesesActuales.Text)
        Dim MesesAdicionales As Integer = CDec(txtMesesAdicionales.Text)
        Dim MesesTotales As Integer = MesesActuales + MesesAdicionales
        Dim PorcentajeInteresAcumulado As Decimal
        Dim InteresPagar As Decimal
        Dim CapitalInteresPagar As Decimal
        Dim TotalCuotasPagadas As Decimal = CDec(txtTotalCuotasPagadas.Text)
        Dim MorasPagar As Decimal = CDec(txtMorasPagar.Text)

        PorcentajeInteresAcumulado = MesesTotales * MyPrestamo(0).TASA_INTERES
        InteresPagar = PorcentajeInteresAcumulado * MyPrestamo(0).CAPITAL / 100
        CapitalInteresPagar = MyPrestamo(0).CAPITAL + InteresPagar

        txtMesesTotales.Text = EvalDato(MesesTotales, txtMesesTotales.Tag)
        txtPorcentajeInteresAcumulado.Text = EvalDato(PorcentajeInteresAcumulado, txtPorcentajeInteresAcumulado.Tag)
        txtInteresPagar.Text = EvalDato(InteresPagar, txtInteresPagar.Tag)
        txtCapitalInteresPagar.Text = EvalDato(CapitalInteresPagar, txtCapitalInteresPagar.Tag)
        txtTotalProntoPago.Text = EvalDato(CapitalInteresPagar - TotalCuotasPagadas + MorasPagar, txtTotalProntoPago.Tag)

        Call CalcularImportePago()
        Call CalcularVueltoMN()
    End Sub

    Private Sub PoblarCuotasPendientes(IdPrestamo As String)
        Dim TasaMorosidad As Decimal
        Dim ImporteMorosidad As Decimal
        Dim MesesActuales As Integer
        Dim MesesTotales As Integer
        Dim PorcentajeInteresAcumulado As Decimal
        Dim InteresPagar As Decimal
        Dim CapitalInteresPagar As Decimal

        Dim TotalCuotasPagadas As Decimal
        Dim MorasPagar As Decimal

        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerPrestamoCuotasLista(MyUsuario.empresa, IdPrestamo, True)

        Call PoblarPrestamo(IdPrestamo)

        MesesActuales = DateDiff(DateInterval.Month, MyPrestamo(0).FECHA_PRIMER_PAGO, MyFechaServidor) + 1
        MesesTotales = MesesActuales + 1

        PorcentajeInteresAcumulado = MesesTotales * MyPrestamo(0).TASA_INTERES
        InteresPagar = PorcentajeInteresAcumulado * MyPrestamo(0).CAPITAL / 100
        CapitalInteresPagar = MyPrestamo(0).CAPITAL + InteresPagar

        txtMesesActuales.Text = EvalDato(MesesActuales, txtMesesActuales.Tag)
        txtMesesAdicionales.Text = EvalDato(1, txtMesesAdicionales.Tag)
        txtMesesTotales.Text = EvalDato(MesesTotales, txtMesesTotales.Tag)
        txtPorcentajeInteresAcumulado.Text = EvalDato(PorcentajeInteresAcumulado, txtPorcentajeInteresAcumulado.Tag)
        txtInteresPagar.Text = EvalDato(InteresPagar, txtInteresPagar.Tag)
        txtCapitalInteresPagar.Text = EvalDato(CapitalInteresPagar, txtCapitalInteresPagar.Tag)

        'Inicializar Totales a Calcular
        txtImportePago.Text = EvalDato(0, txtImportePago.Tag)
        txtDineroVueltoMN.Text = EvalDato(0, txtDineroVueltoMN.Tag)

        If MyPrestamoCuotasLista.Rows.Count <> 0 Then
            TasaMorosidad = MyPrestamo(0).TASA_MOROSIDAD
            For NFila As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                With MyPrestamoCuotasLista(NFila)
                    If .FECHA_VENCIMIENTO < MyFechaServidor Then
                        If .SALDO_CUOTA > 0 Then
                            ImporteMorosidad = .SALDO_CUOTA * TasaMorosidad / 100 / 30 * .DIAS_MORA
                            .MORA = ImporteMorosidad
                            .MORA_PAGO = .MORA
                        End If
                    End If
                    TotalCuotasPagadas = TotalCuotasPagadas + (.VALOR_CUOTA - .SALDO_CUOTA)
                    MorasPagar = MorasPagar + .MORA
                    .TOTAL_PAGO = .CUOTA_PAGO + .MORA_PAGO
                End With
            Next
        End If

        txtTotalCuotasPagadas.Text = EvalDato(TotalCuotasPagadas, txtTotalCuotasPagadas.Tag)
        txtMorasPagar.Text = EvalDato(MorasPagar, txtMorasPagar.Tag)
        txtTotalProntoPago.Text = EvalDato(CapitalInteresPagar - TotalCuotasPagadas + MorasPagar, txtTotalProntoPago.Tag)

        Call CalcularImportePago()
        Call CalcularVueltoMN()

        gvCuotas.DataSource = MyPrestamoCuotasLista
        gvCuotas.ClearSelection()
        cmbPrestamo.Focus()
    End Sub

    Private Sub PoblarProntoPago()
        Dim TotalCuotas As Decimal = 0
        Dim TotalMoras As Decimal = 0
        ActivarCabecera(False)
        MyCobranza = dalFinanciamiento.ObtenerCobranza(MyUsuario.empresa, MyCobranza(0).COBRANZA)
        MyCobranzaProntoPago = dalFinanciamiento.ObtenerProntoPago(MyUsuario.empresa, MyCobranza(0).COBRANZA)

        With MyCobranza(0)
            txtCobranza.Text = .COBRANZA
            txtFechaEmision.Text = EvalDato(.FECHA, txtFechaEmision.Tag)
            cmbFormaPago.SelectedValue = .FORMA_PAGO
            cmbTipoMonedaPago.SelectedValue = .TIPO_MONEDA_PAGO
            txtTipoCambioPago.Text = EvalDato(.TIPO_CAMBIO_PAGO, txtTipoCambioPago.Tag)
            txtImportePago.Text = EvalDato(.IMPORTE_PAGO, txtImportePago.Tag)
            txtNumeroReciboInterno.Text = .RECIBO_INTERNO
            txtDineroRecibido.Text = .DINERO_RECIBIDO
            txtDineroVueltoMN.Text = .DINERO_VUELTO_MN
        End With

        Call PoblarPrestamo(MyCobranza(0).PRESTAMO)

        With MyCobranzaProntoPago(0)
            txtMesesActuales.Text = EvalDato(.MESES_ACTUALES, txtMesesActuales.Tag)
            txtMesesAdicionales.Text = EvalDato(.MESES_ADICIONALES, txtMesesAdicionales.Tag)
            txtMesesTotales.Text = EvalDato(.MESES_ACTUALES + .MESES_ADICIONALES, txtMesesTotales.Tag)
            txtPorcentajeInteresAcumulado.Text = EvalDato(.PORCENTAJE_INTERES_ACUMULADO, txtPorcentajeInteresAcumulado.Tag)
            txtInteresPagar.Text = EvalDato(.INTERES_PAGAR, txtInteresPagar.Tag)
            txtCapitalInteresPagar.Text = EvalDato(.CAPITAL_INTERES_PAGAR, txtCapitalInteresPagar.Tag)
            txtTotalCuotasPagadas.Text = EvalDato(.TOTAL_CUOTAS_PAGADAS, txtTotalCuotasPagadas.Tag)
            txtMorasPagar.Text = EvalDato(.MORA_PAGAR, txtMorasPagar.Tag)
            txtTotalProntoPago.Text = EvalDato(.TOTAL_PRONTO_PAGO, txtTotalProntoPago.Tag)
        End With

        With MyPrestamo(0)
            MyCuentaComercial = dalFinanciamiento.ObtenerCliente(.EMPRESA, .TIPO_DOCUMENTO, .NRO_DOCUMENTO)
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = MyCuentaComercial.razon_social
        End With

        MyPrestamosLista = dalFinanciamiento.ObtenerPrestamo(MyCobranza)

        cmbPrestamo.DataSource = MyPrestamosLista
        cmbPrestamo.SelectedValue = MyCobranza(0).PRESTAMO

        UC_ToolBar.btnGrabar_Visible = True
        UC_ToolBar.btnImprimir_Visible = True
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnImprimir_Focus = True
    End Sub

    Private Sub PoblarPrestamo(IdPrestamo)
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, IdPrestamo)
        With MyPrestamo(0)
            txtPrestamo.Text = .PRESTAMO
            cmbTipoMonedaPrestamo.SelectedValue = .TIPO_MONEDA
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
            txtCapital.Text = EvalDato(.CAPITAL, txtCapital.Tag)
            txtNumeroCuotas.Text = EvalDato(.NUMERO_CUOTAS, txtNumeroCuotas.Tag)
            txtTasaInteresMensual.Text = EvalDato(.TASA_INTERES, txtTasaInteresMensual.Tag)
            txtTasaMorosidadMensual.Text = EvalDato(.TASA_MOROSIDAD, txtTasaMorosidadMensual.Tag)
            cmbTipoPrestamo.SelectedValue = .TIPO_PRESTAMO
            cmbFormaPagoPrestamo.SelectedValue = .FORMA_PAGO
        End With
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
        Dim TipoCambio As Decimal = CDec(txtTipoCambioPago.Text)
        Dim ImportePago As Decimal = CDec(txtImportePago.Text)
        Dim DineroRecibido As Decimal = CDec(txtDineroRecibido.Text)
        Dim TotalPrestamo As Decimal = CDec(txtTotalPrestamo.Text)
        Dim TotalCuotasPagadas As Decimal = CDec(txtTotalCuotasPagadas.Text)

        Dim GrabarPago As Boolean = True

        If  MyUsuario.emite_ticket = False And txtNumeroReciboInterno.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe ingresar el número de recibo interno.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            GrabarPago = False
            txtNumeroReciboInterno.Focus()
        ElseIf MonedaPrestamo <> MonedaPago And TipoCambio = 0 Then
            Resp = MsgBox("Debe ingresar el tipo de cambio.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            GrabarPago = False
            txtTipoCambioPago.Focus()
        ElseIf DineroRecibido < ImportePago Then
            Resp = MsgBox("El total recibido es menor que el total a pagar.", MsgBoxStyle.Critical, "DATO NO VALIDO")
            GrabarPago = False
            txtDineroRecibido.Focus()
        End If

        If GrabarPago = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False

                Call CalcularImportePago()
                Call CalcularVueltoMN()

                MyCobranza = dalFinanciamiento.ObtenerCobranzaNueva

                MyCobranzaProntoPago = dalFinanciamiento.ObtenerCobranzaProntoPagoNueva

                With MyCobranza(0)
                    .EMPRESA = MyUsuario.empresa
                    .PRESTAMO = MyPrestamo(0).PRESTAMO
                    .EJERCICIO = MyUsuario.ejercicio
                    .MES = MyUsuario.mes.ToString("00")
                    .TIPO = "PP"
                    .FORMA_PAGO = cmbFormaPago.SelectedValue
                    .TIPO_MONEDA_PAGO = cmbTipoMonedaPago.SelectedValue
                    .TIPO_CAMBIO_PAGO = TipoCambio
                    .IMPORTE_PAGO = ImportePago
                    .IMPORTE = CDec(txtTotalProntoPago.Text)
                    .GLOSA = Space(1)
                    .DINERO_RECIBIDO = DineroRecibido
                    .DINERO_VUELTO_MN = CDec(txtDineroVueltoMN.Text)
                    .RECIBO_INTERNO = IIf(txtNumeroReciboInterno.Text.Trim.Length = 0, Space(1), txtNumeroReciboInterno.Text)
                    .FECHA = MyFechaServidor
                    .AGENCIA_REGISTRO = MyAgencia(0).AGENCIA
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                With MyCobranzaProntoPago(0)
                    .EMPRESA = MyUsuario.empresa
                    .PRESTAMO = MyPrestamo(0).PRESTAMO
                    .MESES_ACTUALES = CDec(txtMesesActuales.Text)
                    .MESES_ADICIONALES = CDec(txtMesesAdicionales.Text)
                    .PORCENTAJE_INTERES_ACUMULADO = CDec(txtPorcentajeInteresAcumulado.Text)
                    .INTERES_PAGAR = CDec(txtInteresPagar.Text)
                    .CAPITAL_INTERES_PAGAR = CDec(txtCapitalInteresPagar.Text)
                    .TOTAL_CUOTAS_PAGADAS = CDec(txtTotalCuotasPagadas.Text)
                    .MORA_PAGAR = CDec(txtMorasPagar.Text)
                    .TOTAL_PRONTO_PAGO = CDec(txtTotalProntoPago.Text)
                    .AGENCIA_REGISTRO = MyAgencia(0).AGENCIA
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyPrestamo(0).TOTAL_SALDO = TotalPrestamo - TotalCuotasPagadas
                MyPrestamo(0).ESTADO = "C"

                MyCobranza = dalFinanciamiento.GrabarCobranzaProntoPago(MyPrestamo, MyCobranza, MyCobranzaProntoPago)
                If MyCobranza(0).COBRANZA.Trim.Length <> 0 Then
                    txtCobranza.Text = MyCobranza(0).COBRANZA
                    Call ActivarCabecera(False)
                    Resp = MsgBox("La Cobranza se grabó con éxito.", MsgBoxStyle.Information, "REGISTRAR PRONTO PAGO")

                    MyPrestamoCuotasLista = dalFinanciamiento.ObtenerCobranzas(MyUsuario.empresa, MyCobranza(0).COBRANZA)
                    EnableComboBox(cmbPrestamo, False)
                    gvCuotas.DataSource = MyPrestamoCuotasLista
                    gvCuotas.ClearSelection()

                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                Else
                    UC_ToolBar.btnAceptar_Visible = True
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtCobranza.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmReporteProntoPago(MyPrestamo, MyCobranzaProntoPago, cmbTipoPrestamo.Text, cmbFormaPagoPrestamo.Text)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyCobranzaNew As New dsFinanciero.COBRANZASDataTable
        MyCobranzaNew = dalFinanciamiento.ObtenerCobranzaNueva()

        Dim MyForm As New frmCobranzasLista(MyCobranzaNew, txtEjercicio.Text, txtMes.Text, "PP")
        MyForm.ShowDialog()
        If MyCobranzaNew(0).COBRANZA.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyCobranza = MyCobranzaNew
            Call PoblarProntoPago()
        End If
    End Sub

#End Region

End Class
