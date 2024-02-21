Public Class frmHistoricoPrestamos

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable
    Private MyCuentaComercial As New entCuentaComercial

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private NumeroIndiceEditar As Integer

    Private Sub frmHistoricoPrestamos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmHistoricoPrestamos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO")
        ActualizarListaEmpresa(cmbTipoPrestamo, "FIN_TIPO_PRESTAMO")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
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

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoCuotasLista = New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable

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

        cmbTipoMoneda.SelectedValue = "1"
        cmbDocumentoTipo.SelectedValue = "1"

        ActualizarCombos = True

        EnableComboBox(cmbPrestamo, True)

        UC_ToolBar.btnImprimir_Visible = False
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
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
                    Resp = MsgBox("El documento de identidad ingresado " & MyDocumentoNumero & " no existe.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                End If
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                MyPrestamosLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "C")
                If MyPrestamosLista.Rows.Count = 0 Then
                    Resp = MsgBox("El cliente " & MyCuentaComercial.razon_social.Trim & " no tiene préstamos cancelados.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
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
            If MyPrestamosLista.Rows.Count <> 0 Then
                UC_ToolBar.btnImprimir_Visible = True
            Else
                UC_ToolBar.btnImprimir_Visible = False
            End If

            cmbPrestamo.DataSource = MyPrestamosLista
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, cmbPrestamo.SelectedValue)
        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerPrestamoCuotasLista(MyUsuario.empresa, cmbPrestamo.SelectedValue, True)

        txtPrestamo.Text = MyPrestamo(0).PRESTAMO
        cmbTipoPrestamo.SelectedValue = MyPrestamo(0).TIPO_PRESTAMO
        cmbFormaPago.SelectedValue = MyPrestamo(0).FORMA_PAGO
        cmbTipoMoneda.SelectedValue = MyPrestamo(0).TIPO_MONEDA
        txtTotalPrestamo.Text = EvalDato(MyPrestamo(0).TOTAL_PRESTAMO, txtTotalPrestamo.Tag)

        gvCuotas.DataSource = MyPrestamoCuotasLista
        gvCuotas.ClearSelection()
        cmbPrestamo.Focus()
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtPrestamo.Text.Trim.Length <> 0 Then
            Dim MyPrestamoCuotas As New dsFinanciero.PRESTAMOS_CUOTASDataTable
            MyPrestamoCuotas = dalFinanciamiento.ObtenerPrestamoCuotas(MyUsuario.empresa, cmbPrestamo.SelectedValue)
            Dim MyForm As New frmPrestamoEstadoCuenta(MyPrestamo, MyPrestamoCuotas, cmbTipoPrestamo.Text, cmbFormaPago.Text, True)
            MyForm.ShowDialog()
        End If
    End Sub

#End Region


End Class
