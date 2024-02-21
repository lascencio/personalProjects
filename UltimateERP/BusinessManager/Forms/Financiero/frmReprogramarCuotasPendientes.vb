Public Class frmReprogramarCuotasPendientes

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable
    Private MyCuentaComercial As New entCuentaComercial

    Private MyProximaFechaVencimiento As Date

    Private ReprogramacionGenerada As Boolean

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable

    Private Sub frmReprogramarCuotasPendientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReprogramarCuotasPendientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO")
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
        If cmbPrestamo.SelectedIndex <> -1 Then Call PoblarGrilla()
    End Sub

    Private Sub Validar_Validated(sender As Object, e As EventArgs) Handles txtFechaReprogramar.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        ReprogramacionGenerada = False
        btnCalcularFechas.Focus()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoCuotasLista = New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable

        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

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

        cmbTipoMoneda.SelectedValue = "1"
        cmbDocumentoTipo.SelectedValue = "1"

        ActualizarCombos = True

        EnableComboBox(cmbPrestamo, False)
        EnableTextBox(txtFechaReprogramar, False)
        btnCalcularFechas.Enabled = False

        ReprogramacionGenerada = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
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
                MyPrestamosLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "V")
                If MyPrestamosLista.Rows.Count = 0 Then
                    Resp = MsgBox("El cliente " & MyCuentaComercial.razon_social.Trim & " no tiene préstamos vigentes.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                    UC_ToolBar.btnImprimir_Visible = False
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
                    UC_ToolBar.btnImprimir_Visible = True
                    cmbPrestamo.Focus()
                End If
            Else
                MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable
                txtRazonSocial.Text = Nothing
                UC_ToolBar.btnImprimir_Visible = False
            End If
            cmbPrestamo.DataSource = MyPrestamosLista
        End If
    End Sub

    Private Sub PoblarGrilla()
        Dim ImporteCuotasPendientes As Decimal

        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, cmbPrestamo.SelectedValue)
        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerPrestamoCuotasLista(MyUsuario.empresa, cmbPrestamo.SelectedValue, False)

        cmbTipoMoneda.SelectedValue = MyPrestamo(0).TIPO_MONEDA
        cmbFormaPago.SelectedValue = MyPrestamo(0).FORMA_PAGO
        cmbTipoPrestamo.SelectedValue = MyPrestamo(0).TIPO_PRESTAMO

        txtTotalPrestamo.Text = EvalDato(MyPrestamo(0).TOTAL_PRESTAMO, txtTotalPrestamo.Tag)

        If MyPrestamoCuotasLista.Rows.Count <> 0 Then
            MyProximaFechaVencimiento = MyPrestamoCuotasLista(0).FECHA_VENCIMIENTO
            For NFila As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                With MyPrestamoCuotasLista(NFila)
                    ImporteCuotasPendientes = ImporteCuotasPendientes + .SALDO_CUOTA
                End With
            Next
        End If

        txtTotalCuotasPendientes.Text = EvalDato(ImporteCuotasPendientes, txtTotalCuotasPendientes.Tag)
        txtFechaVigente.Text = EvalDato(MyProximaFechaVencimiento, txtFechaVigente.Tag)

        EnableComboBox(cmbPrestamo, True)
        EnableTextBox(txtFechaReprogramar, True)
        btnCalcularFechas.Enabled = True

        gvCuotas.DataSource = MyPrestamoCuotasLista
        gvCuotas.ClearSelection()
        txtFechaReprogramar.Focus()
    End Sub

    Private Sub PoblarPrestamo(Prestamo As String)
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, Prestamo)

        With MyPrestamo(0)
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
            txtTotalPrestamo.Text = EvalDato(.TOTAL_PRESTAMO, txtTotalPrestamo.Tag)
        End With
    End Sub

    Private Sub GenerarCuotas()
        Dim MyMaxFilas As Integer
        Dim FechaVencimiento As Date
        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        With gvCuotas
            MyMaxFilas = .Rows.Count
            For NEle As Integer = 0 To MyMaxFilas - 1
                FechaVencimiento = .Rows(NEle).Cells("FECHA_VENCIMIENTO").Value
                MyPrestamoCuotas.Rows.Add(MyUsuario.empresa,
                                          cmbPrestamo.SelectedValue,
                                          .Rows(NEle).Cells("NUMERO_CUOTA").Value,
                                          FechaVencimiento.Year.ToString,
                                          FechaVencimiento.Month.ToString("00"),
                                          .Rows(NEle).Cells("FECHA_VENCIMIENTO").Value,
                                          0,
                                          0,
                                          0,
                                          .Rows(NEle).Cells("VALOR_CUOTA").Value,
                                          FechaNulo,
                                          .Rows(NEle).Cells("SALDO_CUOTA").Value,
                                          0,
                                          FechaNulo,
                                          Space(1),
                                          "V",
                                          MyAgencia(0).AGENCIA,
                                          MyUsuario.usuario,
                                          FechaNulo,
                                          Space(1),
                                          Space(1),
                                          FechaNulo)
            Next
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
        If ReprogramacionGenerada = True Then
            Try
                UC_ToolBar.btnAceptar_Visible = False
                Call GenerarCuotas()
                If dalFinanciamiento.GrabarReprogramacionCuotas(MyPrestamo, MyPrestamoCuotas) = True Then
                    EnableTextBox(txtFechaReprogramar, False)
                    btnCalcularFechas.Enabled = False
                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                    Resp = MsgBox("La reprogramación de fechas se grabó con éxito.", MsgBoxStyle.Information, "GRABAR REPROGRAMACION")
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If cmbPrestamo.SelectedIndex <> -1 Then
            MyPrestamoCuotas = dalFinanciamiento.ObtenerPrestamoCuotas(MyUsuario.empresa, MyPrestamo(0).PRESTAMO)
            Dim MyForm As New frmPrestamoEstadoCuenta(MyPrestamo, MyPrestamoCuotas, cmbTipoPrestamo.Text, cmbFormaPago.Text, False)
            MyForm.ShowDialog()
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
            cmbPrestamo.SelectedValue = MyPrestamoNew(0).PRESTAMO
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub btnCalcularFechas_Click(sender As Object, e As EventArgs) Handles btnCalcularFechas.Click
        Dim FormaPago As String = cmbFormaPago.Text
        Dim MyFechaReprogramar As Date
        Dim MyMaxFilas As Integer

        Dim FechaVencimiento As Date

        MyPrestamoCuotas = New dsFinanciero.PRESTAMOS_CUOTASDataTable

        ReprogramacionGenerada = False

        If txtFechaReprogramar.Text.Trim.Length <> 0 Then MyFechaReprogramar = CDate(txtFechaReprogramar.Text)

        If txtFechaReprogramar.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar la fecha a reprogramar.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            txtFechaReprogramar.Focus()
        ElseIf MyFechaReprogramar <= MyFechaServidor Then
            Resp = MsgBox("La Fecha a reprogramar debe ser mayor de hoy.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            txtFechaReprogramar.Focus()
        ElseIf MyProximaFechaVencimiento = MyFechaReprogramar Then
            Resp = MsgBox("La Fecha a reprogramar debe ser distinta a la fecha de la cuota vigente.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            txtFechaReprogramar.Focus()
        Else
            FechaVencimiento = MyFechaReprogramar
            With gvCuotas
                MyMaxFilas = .Rows.Count
                For NEle As Integer = 0 To MyMaxFilas - 1
                    If NEle = 0 Then
                        .Rows(NEle).Cells("FECHA_VENCIMIENTO").Value = FechaVencimiento
                    Else
                        Select Case FormaPago
                            Case Is = "DIARIO" : FechaVencimiento = DateAdd(DateInterval.Day, 1, FechaVencimiento)
                            Case Is = "SEMANAL" : FechaVencimiento = DateAdd(DateInterval.Day, 7, FechaVencimiento)
                            Case Is = "QUINCENAL" : FechaVencimiento = DateAdd(DateInterval.Day, 15, FechaVencimiento)
                            Case Is = "MENSUAL" : FechaVencimiento = DateAdd(DateInterval.Month, 1, FechaVencimiento)
                        End Select
                        .Rows(NEle).Cells("FECHA_VENCIMIENTO").Value = FechaVencimiento
                    End If
                Next
            End With
            Resp = MsgBox("Las fechas de vencimiento fueron modificadas preliminarmente." & vbCrLf &
                          "Para confirmar los cambios definitivamente debe presionar el " & vbCrLf &
                          "botón Check Final.", MsgBoxStyle.Information, "CALCULAR NUEVAS FECHAS")
            UC_ToolBar.btnAceptar_Focus = True
            ReprogramacionGenerada = True
        End If
    End Sub

#End Region


End Class
