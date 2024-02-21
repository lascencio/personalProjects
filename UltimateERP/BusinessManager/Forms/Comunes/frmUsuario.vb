Public Class frmUsuario

    Private MyUsuarioSistema As entUsuario
    Private MyUser As dsUsuarios.USERSDataTable
    Private IndicaCliente As Boolean = True

    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private Sub frmUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")

        ActualizarListaEmpresa(cmbCargo, "OPE_CARGO")

        ActualizarLista(cmbAgencia, "A")
        ActualizarLista(cmbTrabajador, "A")
        ActualizarLista(cmbPerfil, "ACT")

        Call LimpiarFormulario(True)

        UC_ToolBar.CambiarEstados(MyUsuarioSistema.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = False

    End Sub

    Private Sub cmbDocumentoTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDocumentoTipo.SelectedIndexChanged
        Dim MyDocumentoTipo As String
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim

        If sender.SelectedIndex <> -1 Then
            MyDocumentoTipo = cmbDocumentoTipo.SelectedValue
            If MyDocumentoNumero.Length <> 0 Then
                MyUser = dalUser.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                Call EvaluarSiExiste(MyDocumentoTipo, MyDocumentoNumero)
            Else
                txtDocumentoNumero.Focus()
            End If
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim

        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            MyUsuarioSistema = New entUsuario
            MyUser = New dsUsuarios.USERSDataTable
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                'Dim MyForm As New frmUsuariolLista(MyUsuarioSistema,"TODOS")
                'MyForm.ShowDialog()
            Else
                MyUser = dalUser.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            Call EvaluarSiExiste(MyDocumentoTipo, MyDocumentoNumero)
        End If
    End Sub

    Private Sub ckbIndicaTrabajador_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaTrabajador.CheckedChanged
        EnableComboBox(cmbTrabajador, sender.Checked)
        If sender.Checked = False Then cmbTrabajador.SelectedValue = "T0000000"
    End Sub

    Private Sub ckbIndicaPerfilPersonalizado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaPerfilPersonalizado.CheckedChanged
        If ckbIndicaPerfilPersonalizado.Checked = True Then
            EnableComboBox(cmbPerfil, False)
            EnableComboBox(cmbPrivilegios, False)
            cmbPerfil.SelectedIndex = -1
            cmbPrivilegios.SelectedIndex = 3
            UC_ToolBar.btnGrabar_Focus = True
        Else
            EnableComboBox(cmbPerfil, True)
            EnableComboBox(cmbPrivilegios, True)
            cmbPerfil.Focus()
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim Usuario As String = txtUsuario.Text.Trim
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            If Usuario.Length <> 0 Then
                Call EvaluarSiExiste(Usuario)
            End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Tab Then
            If txtDocumentoNumero.Focused = True Then
                Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
                Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim

                If txtDocumentoNumero.Text.Trim.Length <> 0 Then
                    MyUser = dalUser.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                    Call EvaluarSiExiste(MyDocumentoTipo, MyDocumentoNumero)
                End If
            ElseIf txtUsuario.Focused = True Then
                Dim Usuario As String = txtUsuario.Text.Trim
                Call EvaluarSiExiste(Usuario)
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#Region "Funciones"

    Private Sub LimpiarFormulario(InicializarUsuario As Boolean)
        If InicializarUsuario = True Then
            MyUsuarioSistema = New entUsuario
            MyUser = New dsUsuarios.USERSDataTable
        End If

        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        Dim MyPanelControl As Panel

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
            ElseIf TypeOf ctrl Is Panel Then
                MyPanelControl = ctrl
                For Each Pctrl As Object In MyPanelControl.Controls
                    If TypeOf Pctrl Is TextBox Then
                        Select Case Pctrl.tag
                            Case Is = "V" : Pctrl.text = "0.0000"
                            Case Is = "C" : Pctrl.text = "0.000"
                            Case Is = "D" : Pctrl.text = "0.00"
                            Case Is = "E" : Pctrl.text = "0"
                            Case Else : Pctrl.text = Nothing
                        End Select
                    ElseIf TypeOf Pctrl Is CheckBox Then
                        Pctrl.Checked = False
                    ElseIf TypeOf Pctrl Is ComboBox Then
                        Pctrl.SelectedIndex = -1
                    End If
                Next
            End If
        Next

        Call PonerValoresDefault()

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        cmbDocumentoTipo.SelectedValue = "1"
        cmbCargo.SelectedValue = "NA"

        ckbIndicaActivo.Checked = True
    End Sub

    Private Sub ValidarDocumento(MyDocumentoTipo As String, MyDocumentoNumero As String)
        If MyDocumentoNumero.Length <> 0 Then
            If MyDocumentoTipo = "6" Then ' Persona Natural con RUC
                If MyDocumentoNumero.Trim.Length = 11 Then
                    If MyDocumentoNumero.Substring(0, 2) <> "10" Then
                        Resp = MsgBox("El RUC de una persona natural debe empezar con 10.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
                        txtDocumentoNumero.Focus()
                    Else
                        MyConsultaRUC = dalVenta.ObtenerDatosRUC(MyDocumentoNumero)
                        If Not MyConsultaRUC(0).RUC Is Nothing Then
                            Dim MyTexto As String = MyConsultaRUC(0).RAZON_SOCIAL
                            If MyConsultaRUC(0).ESTADO <> "ACTIVO" Then
                                Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta en estado " & MyConsultaRUC(0).ESTADO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                If Resp = vbYes Then
                                    txtDocumentoNumero.Text = MyDocumentoNumero
                                    txtNombreCompleto.Focus()
                                Else
                                    Call LimpiarFormulario(True)
                                    txtDocumentoNumero.Focus()
                                End If
                            ElseIf MyConsultaRUC(0).CONDICION_DOMICILIO <> "HABIDO" Then
                                Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta con domicilio " & MyConsultaRUC(0).CONDICION_DOMICILIO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                If Resp = vbYes Then
                                    txtDocumentoNumero.Text = MyDocumentoNumero
                                    txtNombreCompleto.Focus()
                                Else
                                    Call LimpiarFormulario(True)
                                    txtDocumentoNumero.Focus()
                                End If
                            Else
                                txtDocumentoNumero.Text = MyDocumentoNumero
                                txtNombreCompleto.Focus()
                            End If
                        Else
                            Resp = MsgBox("El RUC " & MyDocumentoNumero & " no existe en el padrón de Sunat." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                            If Resp = vbYes Then
                                txtDocumentoNumero.Text = MyDocumentoNumero
                                txtNombreCompleto.Focus()
                            Else
                                txtDocumentoNumero.Focus()
                            End If
                        End If
                    End If
                Else
                    Resp = MsgBox("El RUC " & MyDocumentoNumero & " no tiene 11 dígitos." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                    If Resp = vbYes Then
                        txtDocumentoNumero.Text = MyDocumentoNumero
                        txtNombreCompleto.Focus()
                    Else
                        txtDocumentoNumero.Focus()
                    End If
                End If
            Else
                txtDocumentoNumero.Text = MyDocumentoNumero
                txtNombreCompleto.Focus()
            End If
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub PoblarFormulario()
        Call LimpiarFormulario(False)
        MyUsuarioSistema = dalUsuario.ObtenerUsuario(MyUser(0).EMPRESA, MyUser(0).USUARIO)
        If Not MyUsuarioSistema.usuario Is Nothing Then Call LlenarFormulario()
    End Sub

    Private Sub LlenarFormulario()
        With MyUser(0)
            txtUsuario.Text = .USUARIO
            cmbCargo.SelectedValue = .CARGO
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO.Trim
            txtDocumentoNumero.Text = .NUMERO_DOCUMENTO
            txtNombreCompleto.Text = .NOMBRE_COMPLETO
            cmbAgencia.SelectedValue = .AGENCIA_ASIGNADA
            ckbIndicaTrabajador.Checked = IIf(.INDICA_TRABAJADOR = "SI", True, False)
            cmbTrabajador.SelectedValue = .CODIGO_TRABAJADOR
            ckbIndicaPerfilPersonalizado.Checked = IIf(.INDICA_PERFIL_PERSONALIZADO = "SI", True, False)
            ckbIndicaActivo.Checked = IIf(.ESTADO = "A", True, False)
        End With

        With MyUsuarioSistema
            txtClave.Text = .clave
            txtEmail.Text = .email
            If ckbIndicaPerfilPersonalizado.Checked = False Then cmbPerfil.SelectedValue = .perfil
            cmbPrivilegios.SelectedIndex = .privilegios - 1
        End With

    End Sub

    Private Sub CapturarDatos()
        MyUser = New dsUsuarios.USERSDataTable

        MyUser.Rows.Add(MyUsuario.empresa, _
                        txtUsuario.Text, _
                        cmbCargo.SelectedValue, _
                        cmbDocumentoTipo.SelectedValue, _
                        txtDocumentoNumero.Text, _
                        txtNombreCompleto.Text, _
                        cmbAgencia.SelectedValue, _
                        IIf(ckbIndicaTrabajador.Checked = True, "SI", "NO"), _
                        IIf(ckbIndicaTrabajador.Checked = True, cmbTrabajador.SelectedValue, Space(1)), _
                        IIf(ckbIndicaPerfilPersonalizado.Checked = True, "SI", "NO"), _
                        "A", MyUsuario.usuario, Now, MyUsuario.usuario, Now)

        With MyUsuarioSistema
            .empresa = MyUsuario.empresa
            .usuario = txtUsuario.Text
            .clave = txtClave.Text
            .descripcion = txtNombreCompleto.Text
            .email = txtEmail.Text
            If ckbIndicaPerfilPersonalizado.Checked = True Then
                .perfil = txtUsuario.Text
            Else
                .perfil = cmbPerfil.SelectedValue
            End If
            .privilegios = cmbPrivilegios.SelectedIndex + 1
        End With

    End Sub

    Private Sub EvaluarSiExiste(MyDocumentoTipo As String, MyDocumentoNumero As String)
        If MyUser.Rows.Count <> 0 Then
            Call PoblarFormulario()
        Else
            Call LimpiarFormulario(True)
            cmbDocumentoTipo.SelectedValue = MyDocumentoTipo
            txtDocumentoNumero.Text = MyDocumentoNumero
        End If
        txtNombreCompleto.Focus()
    End Sub

    Private Sub EvaluarSiExiste(Usuario As String)
        MyUsuarioSistema = dalUsuario.ObtenerUsuario(MyUsuario.empresa, Usuario)
        If Not MyUsuarioSistema.empresa Is Nothing Then
            Resp = MsgBox("El usuario " & Usuario & " ya esta registrado", MsgBoxStyle.Critical, "MANTENIMIENTO DE USUARIOS")
            txtUsuario.Text = Nothing
            txtUsuario.Focus()
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_Toolbar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_Toolbar_TB_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario(True)
    End Sub

    Private Sub UC_Toolbar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim NombreCampo As String
        Dim GrabarRegistro As Boolean = True

        If txtDocumentoNumero.Text.Trim.Length <> 0 Then
            If cmbPrivilegios.SelectedIndex = -1 Then NombreCampo = "PRIVILEGIOS" : GrabarRegistro = False
            If cmbPerfil.SelectedIndex = -1 And ckbIndicaPerfilPersonalizado.Checked = False Then NombreCampo = "PERFIL" : GrabarRegistro = False
            If txtClave.Text.Trim.Length = 0 Then NombreCampo = "CONTRASEÑA" : GrabarRegistro = False
            If txtUsuario.Text.Trim.Length = 0 Then NombreCampo = "USUARIO" : GrabarRegistro = False
            If cmbCargo.SelectedIndex = -1 Then NombreCampo = "CARGO" : GrabarRegistro = False
            If cmbAgencia.SelectedIndex = -1 Then NombreCampo = "AGENCIA ASIGNADA" : GrabarRegistro = False
            If txtNombreCompleto.Text.Trim.Length = 0 Then NombreCampo = "NOMBRES Y APPELLIDOS" : GrabarRegistro = False

            If GrabarRegistro = False Then
                Resp = MsgBox("Falta registrar información en el campo " & NombreCampo, MsgBoxStyle.Critical, "PROCESO CANCELADO")
            Else
                Try
                    Call CapturarDatos()

                    If dalUser.Grabar(MyUser, MyUsuarioSistema) = True Then
                        Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "REGISTRO DE USUARIOS")
                        Call LimpiarFormulario(True)
                    End If

                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

#End Region

End Class
