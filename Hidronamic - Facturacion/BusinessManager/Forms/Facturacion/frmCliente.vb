Public Class frmCliente
    Private MyCliente As entCliente
    Private MyAccion As String = "NUEVO"

    Private MyCuentaComercial As entCuentaComercial

    Private Sub frmCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCliente_Load(sender As Object, e As EventArgs) Handles Me.Load
        'ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, "01")

        Call LimpiarFormulario()
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
    End Sub

    Private Sub txtEmail_Validated(sender As Object, e As EventArgs) Handles txtEmailContacto.Validated, txtEmailFacturacion.Validated
        If txtEmailContacto.Text.Trim.Length <> 0 Then
            Try
                Dim testAddress = New System.Net.Mail.MailAddress(sender.Text)
            Catch ex As FormatException
                Resp = MsgBox("Ingrese un email válido.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "FORMATO DE CORREO INVALIDO")
                sender.Text = Nothing
                sender.Focus()
            End Try
        End If
    End Sub

    Private Sub txtNumeroRUC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroRUC.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Dim MyNumeroRUC As String = txtNumeroRUC.Text.Trim
            If String.IsNullOrEmpty(MyNumeroRUC) Then
                Call Editar()
            Else
                MyCliente.empresa = MyUsuario.empresa
                MyCliente.cuenta_comercial = MyNumeroRUC
                MyCliente = dalCuentaComercial.ObtenerECliente(MyCliente)
                If MyCliente.cuenta_comercial.Trim.Length = 0 Then
                    MyCuentaComercial = dalCuentaComercial.ObtenerClienteRUC(MyNumeroRUC)
                    If String.IsNullOrEmpty(MyCuentaComercial.cuenta_comercial) Then
                        Call LimpiarFormulario()
                        Resp = MsgBox("No existen datos para el documento consultado.", MsgBoxStyle.Information, "CLIENTE NO EXISTE")
                    Else
                        Call PoblarFormulario()
                    End If
                Else
                    Call PoblarFormulario()
                End If
            End If
        End If

    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCliente = New entCliente

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.0000"
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

        Call HabilitarNumeroRUC(True)

        txtNumeroRUC.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ckbEstado.Checked = True
    End Sub

    Private Sub Editar()
        MyCliente = New entCliente
        MyAccion = "EDITAR"
        Dim MyForm As New frmClientesLista(MyCliente)
        MyForm.ShowDialog()
        If Not MyCliente.cuenta_comercial Is Nothing Then
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub PoblarFormulario()
        'With MyCuentaComercial
        '    txtNumeroRUC.Text = .nro_documento
        '    txtRazonSocial.Text = .razon_social
        'End With

        txtNumeroRUC.Text = MyCliente.cuenta_comercial
        txtRazonSocial.Text = MyCliente.razon_social

        MyCliente = dalCuentaComercial.ObtenerECliente(MyCliente)
        With MyCliente
            txtPrefijo.Text = .prefijo
            txtDomicilio.Text = .domicilio
            txtEmailContacto.Text = .email_contacto
            txtEmailFacturacion.Text = .email_facturacion.Trim
            txtUsuarioWeb.Text = .usuario_web
            txtClaveWeb.Text = .clave_web.Trim
            ckbIndicaNoDomiciliado.Checked = IIf(.indica_no_domiciliado = "SI", True, False)
            ckbEstado.Checked = IIf(.estado = "A", True, False)
        End With

        'HabilitarNumeroRUC(False)
        txtEmailFacturacion.Focus()
    End Sub

    Private Sub HabilitarNumeroRUC(IndicaActivo As Boolean)
        txtNumeroRUC.ReadOnly = Not IndicaActivo
        txtNumeroRUC.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtNumeroRUC.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtNumeroRUC.TabStop = IndicaActivo
        If IndicaActivo Then
            txtNumeroRUC.Focus()
        Else
            txtRazonSocial.Focus()
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If txtEmailFacturacion.Text.Trim.Length <> 0 And txtClaveWeb.Text.Trim.Length <> 0 Then
            MyCliente = New entCliente
            With MyCliente
                .empresa = MyUsuario.empresa
                .cuenta_comercial = txtNumeroRUC.Text
                .razon_social = txtRazonSocial.Text
                .prefijo = txtPrefijo.Text
                .indica_no_domiciliado = IIf(ckbIndicaNoDomiciliado.Checked = True, "SI", "NO")
                .domicilio = txtDomicilio.Text
                .email_contacto = txtEmailContacto.Text.Trim
                .email_facturacion = txtEmailFacturacion.Text.Trim
                .usuario_web = txtUsuarioWeb.Text.Trim
                .clave_web = txtClaveWeb.Text.Trim
                .estado = IIf(ckbEstado.Checked = True, "A", "I")
                .usuario_registro = MyUsuario.usuario
            End With

            Try
                MyCliente = dalCuentaComercial.GrabarECliente(MyCliente)
                Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                Call LimpiarFormulario()
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Call Editar()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
    End Sub

#End Region

    Private Sub UC_ToolBar_Load(sender As Object, e As EventArgs) Handles UC_ToolBar.Load

    End Sub
End Class
