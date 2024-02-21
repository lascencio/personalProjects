Public Class frmCobranzaPrestamo

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable
    Private MyCuentaComercial As New entCuentaComercial

    Private MyCobranza As dsFinanciero.COBRANZASDataTable
    Private MyCobranzaDetalles As dsFinanciero.COBRANZAS_DETALLESDataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private NumeroIndiceEditar As Integer

    Private MonedaPrestamo As String
    Private MonedaPago As String
    Private TipoCambioPago As Decimal

    Private Sub frmCobranzaPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCobranzaPrestamo_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMonedaPrestamo, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO_COBRANZA")
        ActualizarListaGenerica(cmbTipoMonedaPago, "_TIPO_MONEDA")

        EnableTextBox(txtNumeroReciboInterno, Not MyUsuario.emite_ticket)

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

    Private Sub gvCuotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvCuotas.CellContentClick
        Dim MyTotalCuotas As Decimal = 0
        Dim MyTotalMoras As Decimal = 0
        Dim MyIndex As Integer
        Dim MyIndexMax As Integer

        Dim ContinuarSeleccion As Boolean

        NumeroIndiceEditar = -1

        If Not sender.CurrentRow Is Nothing Then
            MyIndex = sender.CurrentRow.Index
            MyIndexMax = gvCuotas.Rows.Count - 1

            lblNumeroCuota.Enabled = True

            If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
                NumeroIndiceEditar = MyIndex
                If sender.Rows(MyIndex).Cells("SALDO_CUOTA").Value <> 0 Then
                    rbtCompromisoPago.Checked = True
                    txtNumeroCuota.Text = sender.Rows(MyIndex).Cells("NUMERO_CUOTA").Value

                    If IsDBNull(sender.Rows(MyIndex).Cells("FECHA_PAGO").Value) Then
                        txtFechaBaseCalculoMora.Text = sender.Rows(MyIndex).Cells("FECHA_VENCIMIENTO").Value
                    Else
                        txtFechaBaseCalculoMora.Text = sender.Rows(MyIndex).Cells("FECHA_PAGO").Value
                    End If

                    Call EditarCompromisoPago()
                    btnAceptar.Enabled = True
                    btnAceptar.ImageIndex = 1
                    btnEliminar.Enabled = True
                    btnEliminar.ImageIndex = 0
                    btnLimpiarLinea.Enabled = True
                End If
            Else
                If MyIndex = 0 Then
                    If sender.Rows(MyIndex + 1).Cells("SELECCIONAR").Value = 0 Then
                        ContinuarSeleccion = True
                    Else
                        ContinuarSeleccion = False
                    End If
                ElseIf MyIndex = MyIndexMax Then
                    If sender.Rows(MyIndex - 1).Cells("SELECCIONAR").Value = 1 Then
                        ContinuarSeleccion = True
                    Else
                        ContinuarSeleccion = False
                    End If
                Else
                    If sender.Rows(MyIndex - 1).Cells("SELECCIONAR").Value = 1 Then
                        If sender.Rows(MyIndex + 1).Cells("SELECCIONAR").Value = 0 Then
                            ContinuarSeleccion = True
                        Else
                            ContinuarSeleccion = False
                        End If
                    Else
                        ContinuarSeleccion = False
                    End If

                End If

                If ContinuarSeleccion = True Then
                    If sender.CurrentCell.GetType.FullName.ToString Like "*CheckBox*" Then
                        ckbSeleccionar.Checked = False
                        With sender
                            If .Rows(MyIndex).Cells("SALDO_CUOTA").Value <> 0 Then
                                If .Rows(MyIndex).Cells("SELECCIONAR").Value Then
                                    .Rows(MyIndex).Cells("SELECCIONAR").Value = 0
                                    .Rows(MyIndex).DefaultCellStyle.ForeColor = Color.Black
                                    If (MyIndex Mod 2) = 0 Then
                                        .Rows(MyIndex).DefaultCellStyle.BackColor = Color.OldLace
                                    Else
                                        .Rows(MyIndex).DefaultCellStyle.BackColor = Color.AntiqueWhite
                                    End If
                                Else
                                    .Rows(MyIndex).Cells("SELECCIONAR").Value = 1
                                    .Rows(MyIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
                                    .Rows(MyIndex).DefaultCellStyle.BackColor = Color.LightCyan
                                End If

                                If MyPrestamoCuotasLista.Rows.Count <> 0 Then
                                    For NEle As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                                        If MyPrestamoCuotasLista(NEle).SELECCIONAR = 1 Then
                                            MyTotalCuotas = MyTotalCuotas + MyPrestamoCuotasLista(NEle).CUOTA_PAGO
                                            MyTotalMoras = MyTotalMoras + MyPrestamoCuotasLista(NEle).MORA_PAGO
                                        End If
                                    Next
                                End If

                                txtTotalCuotas.Text = EvalDato(MyTotalCuotas, txtTotalCuotas.Tag)
                                txtTotalMoras.Text = EvalDato(MyTotalMoras, txtTotalMoras.Tag)
                                txtTotalPagar.Text = EvalDato(MyTotalCuotas + MyTotalMoras, txtTotalPagar.Tag)

                                sender.ClearSelection()
                            End If
                        End With
                        Call CalcularImportePago()
                        Call CalcularVueltoMN()
                        Call LimpiarCamposEditablesCuota()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Validar_Validated(sender As Object, e As EventArgs) Handles txtCompromisoFecha.Validated, txtCuotaPago.Validated, txtMoraPago.Validated, txtTipoCambioPago.Validated, txtDineroRecibido.Validated
        Dim FechaBaseCalculoMora As Date
        Dim FechaCompromiso As Date
        Dim DiasMora As Integer
        Dim TasaMorosidad As Decimal
        Dim ImporteMorosidad As Decimal
        Dim SaldoCuota As Decimal

        sender.Text = EvalDato(sender.Text, sender.Tag)
        If sender.Text.Trim.Length <> 0 Then
            If sender.Name = "txtCompromisoFecha" Then
                FechaBaseCalculoMora = CDate(txtFechaBaseCalculoMora.Text)
                FechaCompromiso = CDate(txtCompromisoFecha.Text)
                TasaMorosidad = MyPrestamo(0).TASA_MOROSIDAD
                SaldoCuota = CDec(gvCuotas.Rows(NumeroIndiceEditar).Cells("SALDO_CUOTA").Value)
                DiasMora = DateDiff(DateInterval.Day, FechaBaseCalculoMora, FechaCompromiso)
                ImporteMorosidad = Math.Round(SaldoCuota * TasaMorosidad / 100 / 30 * DiasMora, 2)
                txtDiasMora.Text = EvalDato(DiasMora, txtDiasMora.Tag)
                txtMoraProyectada.Text = EvalDato(ImporteMorosidad, txtMoraProyectada.Tag)
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

    Private Sub RadioButtonCheckedChanged(sender As Object, e As EventArgs) Handles rbtMontoPagar.CheckedChanged, rbtCompromisoPago.CheckedChanged
        If sender.Name = "rbtMontoPagar" Then
            Call EditarMontoPagar()
        Else
            Call EditarCompromisoPago()
        End If
    End Sub

    Private Sub ckbSeleccionar_Click(sender As Object, e As EventArgs) Handles ckbSeleccionar.Click
        Dim MyTotalCuotas As Decimal = 0
        Dim MyTotalMoras As Decimal = 0

        If gvCuotas.Rows.Count <> 0 Then
            With gvCuotas
                For NEle As Integer = 0 To .Rows.Count - 1
                    .Rows(NEle).Cells("SELECCIONAR").Value = IIf(ckbSeleccionar.Checked = True, 1, 0)
                    If ckbSeleccionar.Checked = True Then
                        .Rows(NEle).DefaultCellStyle.BackColor = Color.LightCyan
                        .Rows(NEle).DefaultCellStyle.ForeColor = Color.DarkBlue

                        MyTotalCuotas = MyTotalCuotas + .Rows(NEle).Cells("CUOTA_PAGO").Value
                        MyTotalMoras = MyTotalMoras + .Rows(NEle).Cells("MORA_PAGO").Value
                    Else
                        .Rows(NEle).DefaultCellStyle.ForeColor = Color.Black
                        If (NEle Mod 2) = 0 Then
                            .Rows(NEle).DefaultCellStyle.BackColor = Color.OldLace
                        Else
                            .Rows(NEle).DefaultCellStyle.BackColor = Color.AntiqueWhite
                        End If
                    End If
                Next
            End With
            txtTotalCuotas.Text = EvalDato(MyTotalCuotas, txtTotalCuotas.Tag)
            txtTotalMoras.Text = EvalDato(MyTotalMoras, txtTotalMoras.Tag)
            txtTotalPagar.Text = EvalDato(MyTotalCuotas + MyTotalMoras, txtTotalPagar.Tag)
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
        MyCobranzaDetalles = New dsFinanciero.COBRANZAS_DETALLESDataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        Call LimpiarCamposEditablesCuota()

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

        '        EnableComboBox(cmbPrestamo, True)
        EnableTextBox(txtCompromisoFecha, False)
        EnableTextBox(txtCompromisoComentario, False)

        cmbFormaPago.SelectedValue = "00000"
        cmbTipoMonedaPago.SelectedValue = "1"

        TipoCambioPago = 0

        btnAceptar.Enabled = False
        btnAceptar.ImageIndex = 3

        btnEliminar.Enabled = False
        btnEliminar.ImageIndex = 2

        ckbSeleccionar.Enabled = False

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

    Private Sub LimpiarCamposEditablesCuota()
        NumeroIndiceEditar = -1

        txtNumeroCuota.Text = Nothing

        txtCuotaPago.Text = EvalDato(0, txtCuotaPago.Tag)
        txtMoraPago.Text = EvalDato(0, txtMoraPago.Tag)
        txtCompromisoFecha.Text = Nothing
        txtCompromisoComentario.Text = Nothing

        EnableTextBox(txtCuotaPago, False)
        EnableTextBox(txtMoraPago, False)
        EnableTextBox(txtCompromisoFecha, False)
        EnableTextBox(txtCompromisoComentario, False)

        txtMoraProyectada.Text = EvalDato(0, txtMoraProyectada.Tag)
        txtFechaBaseCalculoMora.Text = Nothing
        txtDiasMora.Text = EvalDato(0, txtDiasMora.Tag)

        btnAceptar.Enabled = False
        btnAceptar.ImageIndex = 3
        btnEliminar.Enabled = False
        btnEliminar.ImageIndex = 2
        btnLimpiarLinea.Enabled = False

        lblNumeroCuota.Enabled = False
        lblMontoCuota.Enabled = False
        lblMontoMora.Enabled = False
        lblCompromisoFecha.Enabled = False
        lblCompromisoComentario.Enabled = False

        rbtMontoPagar.Enabled = False
        rbtMontoPagar.Checked = False
        rbtCompromisoPago.Enabled = False
        rbtCompromisoPago.Checked = False

        gvCuotas.ClearSelection()
    End Sub

    Private Sub EditarCompromisoPago()
        Dim CompromisoFecha As Date

        If NumeroIndiceEditar <> -1 Then
            rbtMontoPagar.Enabled = True
            rbtCompromisoPago.Enabled = True

            With gvCuotas
                If Not IsDBNull(.Rows(NumeroIndiceEditar).Cells("COMPROMISO_FECHA").Value) Then
                    CompromisoFecha = .Rows(NumeroIndiceEditar).Cells("COMPROMISO_FECHA").Value
                Else
                    CompromisoFecha = FechaNulo
                End If

                txtCompromisoComentario.Text = .Rows(NumeroIndiceEditar).Cells("COMPROMISO_COMENTARIO").Value
                If CompromisoFecha.Year = 1900 Then
                    txtCompromisoFecha.Text = Nothing
                Else
                    txtCompromisoFecha.Text = EvalDato(CompromisoFecha, txtCompromisoFecha.Tag)
                End If
            End With

            Call CambiarEstadoEditarNumeroCuota()
        End If
    End Sub

    Private Sub EditarMontoPagar()
        If NumeroIndiceEditar <> -1 Then
            With gvCuotas
                txtCuotaPago.Text = EvalDato(.Rows(NumeroIndiceEditar).Cells("CUOTA_PAGO").Value, txtCuotaPago.Tag)
                txtMoraPago.Text = EvalDato(.Rows(NumeroIndiceEditar).Cells("MORA_PAGO").Value, txtMoraPago.Tag)
            End With

            Call CambiarEstadoEditarNumeroCuota()
        End If
    End Sub

    Sub CambiarEstadoEditarNumeroCuota()
        If rbtMontoPagar.Checked = True Then
            EnableTextBox(txtCuotaPago, True)
            EnableTextBox(txtMoraPago, True)

            EnableTextBox(txtCompromisoFecha, False)
            EnableTextBox(txtCompromisoComentario, False)
            txtCompromisoFecha.Text = Nothing
            txtCompromisoComentario.Text = Nothing

            rbtMontoPagar.ForeColor = Color.White
            lblMontoCuota.Enabled = True
            lblMontoMora.Enabled = True
            rbtCompromisoPago.ForeColor = Color.Black
            lblCompromisoFecha.Enabled = False
            lblCompromisoComentario.Enabled = False

            txtCuotaPago.Focus()
        Else
            EnableTextBox(txtCompromisoFecha, True)
            EnableTextBox(txtCompromisoComentario, True)

            EnableTextBox(txtCuotaPago, False)
            EnableTextBox(txtMoraPago, False)
            txtCuotaPago.Text = EvalDato(0, txtCuotaPago.Tag)
            txtMoraPago.Text = EvalDato(0, txtMoraPago.Tag)

            rbtMontoPagar.ForeColor = Color.Black
            lblMontoCuota.Enabled = False
            lblMontoMora.Enabled = False
            rbtCompromisoPago.ForeColor = Color.White
            lblCompromisoFecha.Enabled = True
            lblCompromisoComentario.Enabled = True

            txtCompromisoFecha.Focus()
        End If
    End Sub

    Private Sub CalcularImportePago()
        Dim ImportePago As Decimal = 0
        Dim TotalPagar As Decimal = CDec(txtTotalPagar.Text)

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

    Private Sub PoblarPrestamo(IdPrestamo As String)
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, IdPrestamo)

        With MyPrestamo(0)
            txtPrestamo.Text = .PRESTAMO
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            cmbTipoMonedaPrestamo.SelectedValue = .TIPO_MONEDA
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
        End With
    End Sub

    Private Sub PoblarCuotasPendientes(IdPrestamo As String)
        Dim TasaMorosidad As Decimal
        Dim ImporteMorosidad As Decimal

        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, IdPrestamo)
        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerPrestamoCuotasLista(MyUsuario.empresa, IdPrestamo, False)

        txtPrestamo.Text = MyPrestamo(0).PRESTAMO
        cmbTipoMonedaPrestamo.SelectedValue = MyPrestamo(0).TIPO_MONEDA
        txtTotalPrestamo.Text = EvalDato(MyPrestamo(0).TOTAL_PRESTAMO, txtTotalPrestamo.Tag)

        'Inicializar Totales a Calcular
        txtImportePago.Text = EvalDato(0, txtImportePago.Tag)
        txtTotalCuotas.Text = EvalDato(0, txtTotalCuotas.Tag)
        txtTotalMoras.Text = EvalDato(0, txtTotalMoras.Tag)
        txtTotalPagar.Text = EvalDato(0, txtTotalPagar.Tag)
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
                    .TOTAL_PAGO = .CUOTA_PAGO + .MORA_PAGO
                End With
            Next
        End If

        ckbSeleccionar.Enabled = True
        ckbSeleccionar.Checked = False
        gvCuotas.DataSource = MyPrestamoCuotasLista
        gvCuotas.ClearSelection()
        cmbPrestamo.Focus()
    End Sub

    Private Sub PoblarCobranza()
        Dim TotalCuotas As Decimal = 0
        Dim TotalMoras As Decimal = 0
        ActivarCabecera(False)
        MyCobranza = dalFinanciamiento.ObtenerCobranza(MyUsuario.empresa, MyCobranza(0).COBRANZA)
        MyCobranzaDetalles = dalFinanciamiento.ObtenerCobranzaDetalles(MyUsuario.empresa, MyCobranza(0).COBRANZA)

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

        If MyCobranzaDetalles.Rows.Count <> 0 Then
            For NFila As Integer = 0 To MyCobranzaDetalles.Rows.Count - 1
                TotalCuotas = TotalCuotas + MyCobranzaDetalles(NFila).CUOTA_PAGO
                TotalMoras = TotalMoras + MyCobranzaDetalles(NFila).MORA_PAGO
            Next
        End If

        txtTotalCuotas.Text = EvalDato(TotalCuotas, txtTotalCuotas.Tag)
        txtTotalMoras.Text = EvalDato(TotalMoras, txtTotalMoras.Tag)
        txtTotalPagar.Text = EvalDato(TotalCuotas + TotalMoras, txtTotalPagar.Tag)

        MyPrestamosLista = dalFinanciamiento.ObtenerPrestamo(MyCobranza)
        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerCobranzas(MyUsuario.empresa, MyCobranza(0).COBRANZA)

        cmbPrestamo.DataSource = MyPrestamosLista
        cmbPrestamo.SelectedValue = MyCobranza(0).PRESTAMO
        '        EnableComboBox(cmbPrestamo, False)

        gvCuotas.DataSource = MyPrestamoCuotasLista
        gvCuotas.ClearSelection()

        UC_ToolBar.btnGrabar_Visible = True
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
        Dim TotalCuotasPagar As Decimal = CDec(txtTotalCuotas.Text)
        Dim TotalPagar As Decimal = CDec(txtTotalPagar.Text)
        Dim TipoCambio As Decimal = CDec(txtTipoCambioPago.Text)
        Dim ImportePago As Decimal = CDec(txtImportePago.Text)
        Dim DineroRecibido As Decimal = CDec(txtDineroRecibido.Text)

        Dim GrabarPago As Boolean = True

        If TotalCuotasPagar = 0 Then
            Resp = MsgBox("Debe seleccionar la cuota o cuotas a pagar.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            GrabarPago = False
            gvCuotas.Focus()
        ElseIf MyUsuario.emite_ticket = False And txtNumeroReciboInterno.Text.Trim.Length = 0 Then
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

                With MyCobranza(0)
                    .EMPRESA = MyUsuario.empresa
                    .PRESTAMO = MyPrestamo(0).PRESTAMO
                    .EJERCICIO = MyUsuario.ejercicio
                    .MES = MyUsuario.mes.ToString("00")
                    .TIPO = "CR"
                    .FORMA_PAGO = cmbFormaPago.SelectedValue
                    .TIPO_MONEDA_PAGO = cmbTipoMonedaPago.SelectedValue
                    .TIPO_CAMBIO_PAGO = TipoCambio
                    .IMPORTE_PAGO = ImportePago
                    .IMPORTE = CDec(txtTotalPagar.Text)
                    .GLOSA = Space(1)
                    .DINERO_RECIBIDO = DineroRecibido
                    .DINERO_VUELTO_MN = CDec(txtDineroVueltoMN.Text)
                    .RECIBO_INTERNO = IIf(txtNumeroReciboInterno.Text.Trim.Length = 0, Space(1), txtNumeroReciboInterno.Text)
                    .FECHA = MyFechaServidor
                    .AGENCIA_REGISTRO = MyAgencia(0).AGENCIA
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyPrestamo(0).TOTAL_SALDO = MyPrestamo(0).TOTAL_SALDO - TotalCuotasPagar
                If MyPrestamo(0).TOTAL_SALDO <= 0 Then MyPrestamo(0).ESTADO = "C"

                MyCobranza = dalFinanciamiento.GrabarCobranza(MyPrestamo, MyPrestamoCuotasLista, MyCobranza)
                If MyCobranza(0).COBRANZA.Trim.Length <> 0 Then
                    txtCobranza.Text = MyCobranza(0).COBRANZA
                    Call ActivarCabecera(False)
                    Resp = MsgBox("La Cobranza se grabó con éxito.", MsgBoxStyle.Information, "REGISTRAR COBRANZA")

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
            Dim MyForm As New frmTicketCobranzaImprimir(txtCobranza.Text, txtRazonSocial.Text, cmbTipoMonedaPrestamo.Text, False)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyCobranzaNew As New dsFinanciero.COBRANZASDataTable
        MyCobranzaNew = dalFinanciamiento.ObtenerCobranzaNueva()

        Dim MyForm As New frmCobranzasLista(MyCobranzaNew, txtEjercicio.Text, txtMes.Text, "CR")
        MyForm.ShowDialog()
        If MyCobranzaNew(0).COBRANZA.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyCobranza = MyCobranzaNew
            Call PoblarCobranza()
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If MyUsuario.emite_ticket = False And txtNumeroReciboInterno.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe ingresar el número de recibo interno.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtNumeroReciboInterno.Focus()
        Else
            Try
                UC_ToolBar.btnGrabar_Visible = False

                With MyCobranza(0)
                    .FORMA_PAGO = cmbFormaPago.SelectedValue
                    .RECIBO_INTERNO = IIf(txtNumeroReciboInterno.Text.Trim.Length = 0, Space(1), txtNumeroReciboInterno.Text)
                    .AGENCIA_MODIFICA = MyAgencia(0).AGENCIA
                    .USUARIO_MODIFICA = MyUsuario.usuario
                End With

                If dalFinanciamiento.ActualizarCobranza(MyCobranza) = True Then
                    Resp = MsgBox("Los cambios se grabaron con éxito.", MsgBoxStyle.Information, "MODIFICAR COBRANZA")
                    UC_ToolBar.btnGrabar_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim CompromisoFecha As Date
        Dim ContinuarGrabarLinea As Boolean = True

        Dim CuotaPago As Decimal = CDec(txtCuotaPago.Text)
        Dim MoraPago As Decimal = CDec(txtMoraPago.Text)

        If rbtMontoPagar.Checked = True Then
            If CuotaPago = 0 Then
                Resp = MsgBox("La Cuota a Pagar no puede ser cero.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                txtCuotaPago.Focus()
            Else
                If MyPrestamoCuotasLista.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                        With MyPrestamoCuotasLista(NEle)
                            If .NUMERO_CUOTA = txtNumeroCuota.Text Then
                                If CuotaPago > .SALDO_CUOTA Then
                                    Resp = MsgBox("La Cuota a Pagar no puede ser mayor que el Saldo de la Cuota.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                                    txtCuotaPago.Focus()
                                Else
                                    .CUOTA_PAGO = CuotaPago
                                    .MORA_PAGO = MoraPago
                                    .TOTAL_PAGO = CuotaPago + MoraPago
                                End If
                                Exit For
                            End If
                        End With
                    Next
                    LimpiarCamposEditablesCuota()
                End If
            End If
        Else
            If txtCompromisoFecha.Text.Trim.Length <> 0 Then
                CompromisoFecha = CDate(txtCompromisoFecha.Text)
                If CompromisoFecha <= MyFechaServidor Then
                    Resp = MsgBox("La Fecha del Compromiso debe ser mayor de hoy.", MsgBoxStyle.Information, "PROCESO CANCELADO")
                    txtCompromisoFecha.Focus()
                Else
                    If MyPrestamoCuotasLista.Rows.Count <> 0 Then
                        For NEle As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                            With MyPrestamoCuotasLista(NEle)
                                If .NUMERO_CUOTA = txtNumeroCuota.Text Then
                                    If txtCompromisoFecha.Text.Trim.Length <> 0 Then
                                        .COMPROMISO_FECHA = CDate(txtCompromisoFecha.Text)
                                        .COMPROMISO_COMENTARIO = txtCompromisoComentario.Text
                                    End If
                                    Exit For
                                End If
                            End With
                        Next
                        If dalFinanciamiento.GrabarCompromiso(MyPrestamo, txtNumeroCuota.Text, CDate(txtCompromisoFecha.Text), txtCompromisoComentario.Text) = True Then
                            LimpiarCamposEditablesCuota()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MyPrestamoCuotasLista.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                With MyPrestamoCuotasLista(NEle)
                    If .NUMERO_CUOTA = txtNumeroCuota.Text Then
                        .COMPROMISO_FECHA = FechaNulo
                        .COMPROMISO_COMENTARIO = Space(1)
                        Exit For
                    End If
                End With
            Next
            If dalFinanciamiento.GrabarCompromiso(MyPrestamo, txtNumeroCuota.Text, FechaNulo, Space(1)) = True Then
                LimpiarCamposEditablesCuota()
            End If
        End If
    End Sub

    Private Sub btnBuscarPrestamo_Click(sender As Object, e As EventArgs) Handles btnBuscarPrestamo.Click
        Dim MyPrestamoNew As New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoNew = dalFinanciamiento.ObtenerPrestamoNuevo()

        Dim MyForm As New frmPrestamosLista(MyPrestamoNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If MyPrestamoNew(0).PRESTAMO.Trim.Length <> 0 Then
            Call PoblarPrestamo(MyPrestamoNew(0).PRESTAMO)
            Call ValidarDocumento()
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub btnLimpiarLinea_Click(sender As Object, e As EventArgs) Handles btnLimpiarLinea.Click
        Call LimpiarCamposEditablesCuota()
    End Sub

#End Region


End Class
