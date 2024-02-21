Public Class frmControlAccesos
    Private MainMenu As New MenuStrip
    Private MyControlAcceso As entControlAcceso
    Private MyUsuarioCA As entUsuario
    Private MyAccesos As dsControlAcceso.CONTROL_ACCESO_LISTADataTable

    Private MyUsuariosCA As dsUsuarios.USUARIOSDataTable

    Private Sub frmControlAccesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmControlAccesos_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyAccesos = New dsControlAcceso.CONTROL_ACCESO_LISTADataTable

        MainMenu = frmMenu.MenuPrincipal
        If MainMenu.Items.Count <> 0 Then
            For Each OpcionMenu In MainMenu.Items
                cmbMenu.Items.Add(OpcionMenu.Text)
            Next
        End If

        cmbEmpresa.DataSource = MyDTEmpresas

        Call LimpiarFormulario()

        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If MyDTEmpresas.Rows.Count <> 0 Then
            MyUsuariosCA = New dsUsuarios.USUARIOSDataTable
            If cmbEmpresa.SelectedIndex <> -1 Then
                CadenaSQL = "SELECT * FROM GEN.USUARIOS WHERE EMPRESA='" & cmbEmpresa.SelectedValue & "' AND ESTADO='ACT'"
                Call ObtenerDataTableSQL(CadenaSQL, MyUsuariosCA)
            End If

            cmbUsuario.DataSource = MyUsuariosCA
            If MyUsuariosCA.Rows.Count <> 0 Then
                If MyUsuariosCA.Rows.Count > 1 Then
                    cmbUsuario.SelectedIndex = -1
                Else
                    cmbUsuario.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuario.SelectedIndexChanged
        Dim MyIndex As Integer
        MyUsuarioCA = New entUsuario
        MyAccesos = New dsControlAcceso.CONTROL_ACCESO_LISTADataTable

        EnableComboBox(cmbMenu, False)
        EnableComboBox(cmbSubMenu, False)
        EnableComboBox(cmbSubMenuItem, False)
        ActivarBotones(False)

        gvAccesos.DataSource = MyAccesos
        cmbPrivilegiosUsuario.SelectedIndex = -1
        cmbMenu.SelectedIndex = -1

        If cmbUsuario.SelectedIndex <> -1 Then
            MyIndex = cmbUsuario.SelectedIndex
            MyUsuarioCA.empresa = MyUsuariosCA(MyIndex).EMPRESA
            MyUsuarioCA.usuario = MyUsuariosCA(MyIndex).USUARIO
            MyUsuarioCA.perfil = MyUsuariosCA(MyIndex).PERFIL
            cmbPrivilegiosUsuario.SelectedIndex = CByte(MyUsuariosCA(MyIndex).PRIVILEGIOS) - 1
            If cmbPrivilegiosUsuario.Text <> "CONTROL TOTAL" Then EnableComboBox(cmbMenu, True)
            Call ActualizarAccesos()
        End If

        txtUsuario.Text = MyUsuarioCA.usuario

        cmbMenu.Focus()
    End Sub

    Private Sub cmbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMenu.SelectedIndexChanged
        cmbSubMenu.Items.Clear() : EnableComboBox(cmbSubMenu, False)
        cmbSubMenuItem.Items.Clear() : EnableComboBox(cmbSubMenuItem, False)
        EnableComboBox(cmbPrivilegiosNivel, False)
        ActivarBotones(False)
        If cmbMenu.SelectedIndex <> -1 Then
            For Each OpcionMenu In MainMenu.Items
                If OpcionMenu.Text = cmbMenu.Text Then
                    If OpcionMenu.DropDown.items.count <> 0 Then
                        EnableComboBox(cmbSubMenu, True)
                        For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                            cmbSubMenu.Items.Add(OpcionSubMenu.Text)
                        Next
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub cmbSubMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubMenu.SelectedIndexChanged
        cmbSubMenuItem.Items.Clear() : EnableComboBox(cmbSubMenuItem, False)
        EnableComboBox(cmbPrivilegiosNivel, False)
        ActivarBotones(False)
        If cmbSubMenu.SelectedIndex <> -1 Then
            For Each OpcionMenu In MainMenu.Items
                If OpcionMenu.Text = cmbMenu.Text Then
                    For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                        If OpcionSubMenu.Text = cmbSubMenu.Text Then
                            If OpcionSubMenu.DropDown.Items.count <> 0 Then
                                EnableComboBox(cmbSubMenuItem, True)
                                For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                                    cmbSubMenuItem.Items.Add(OpcionSubMenuItem.Text)
                                Next
                            Else
                                ActivarBotones(True)
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub cmbSubMenuItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubMenuItem.SelectedIndexChanged
        If cmbSubMenu.SelectedIndex <> -1 Then
            Call ActivarBotones(True)
        Else
            Call ActivarBotones(False)
        End If
    End Sub

    'Private Sub gvAccesos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvAccesos.CellClick
    '    If gvAccesos.SelectedCells.Count > 0 Then
    '        cmbSubMenu.SelectedIndex = -1 : cmbSubMenuItem.SelectedIndex = -1
    '        NFil = gvAccesos.CurrentCell.RowIndex
    '        'cmbMenu.Text = gvAccesos.Rows(NFil).Cells(2).Value()
    '        'cmbSubMenu.Text = gvAccesos.Rows(NFil).Cells(3).Value()
    '        'cmbSubMenuItem.Text = gvAccesos.Rows(NFil).Cells(4).Value()
    '        'ckbPermitirImprimir.Checked = gvAccesos.Rows(NFil).Cells(5).Value()
    '        'cmbPrivilegiosNivel.SelectedIndex = gvAccesos.Rows(NFil).Cells(7).Value() - 1

    '        cmbMenu.Text = MyAccesos(NFil).NIVEL_1
    '        cmbSubMenu.Text = MyAccesos(NFil).NIVEL_2
    '        cmbSubMenuItem.Text = MyAccesos(NFil).NIVEL_3
    '        ckbPermitirImprimir.Checked = MyAccesos(NFil).PERMITIR_IMPRIMIR
    '        cmbPrivilegiosNivel.SelectedIndex = MyAccesos(NFil).PRIVILEGIOS_CODIGO
    '    End If
    'End Sub

    Private Sub gvAccesos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvAccesos.CellClick
        If sender.Enabled = True Then
            If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
                Dim MyIndex As Integer
                If Not sender.CurrentRow Is Nothing Then
                    MyIndex = sender.CurrentRow.Index
                    MyControlAcceso = New entControlAcceso
                    With MyControlAcceso
                        .empresa = MyAccesos(MyIndex).EMPRESA
                        .usuario = MyUsuarioCA.usuario
                        .nivel_1 = MyAccesos(MyIndex).NIVEL_1
                        .nivel_2 = MyAccesos(MyIndex).NIVEL_2
                        .nivel_3 = MyAccesos(MyIndex).NIVEL_3
                        .privilegios = MyAccesos(MyIndex).PRIVILEGIOS_CODIGO
                        .permitir_imprimir = MyAccesos(MyIndex).PERMITIR_IMPRIMIR
                        .usuario_registro = MyUsuario.usuario
                    End With
                    dalControlAcceso.Borrar(MyControlAcceso)
                    ActualizarAccesos()
                End If
            End If
            sender.ClearSelection()
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyControlAcceso = New entControlAcceso
        MyUsuarioCA = New entUsuario
        MyAccesos = New dsControlAcceso.CONTROL_ACCESO_LISTADataTable

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

        gvAccesos.DataSource = MyAccesos

        If MyDTEmpresas.Rows.Count > 1 Then
            cmbEmpresa.SelectedIndex = -1
            cmbEmpresa.Focus()
        Else
            cmbEmpresa.SelectedIndex = 0
            cmbUsuario.Focus()
        End If

    End Sub

    Private Sub ActualizarAccesos()
        MyAccesos = dalControlAcceso.ObtenerAccesos(MyUsuarioCA)
        gvAccesos.DataSource = MyAccesos
        gvAccesos.ClearSelection()
    End Sub

    Private Sub ActivarBotones(IndicaActivo As Boolean)
        btnAceptar.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo, 1, 3)
        btnCancelar.ImageIndex = IIf(IndicaActivo, 0, 2)
        If IndicaActivo Then btnAceptar.Focus()
    End Sub

#End Region

#Region "Botones"
    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cmbUsuario.SelectedIndex <> -1 Then
            If cmbMenu.SelectedIndex <> -1 Then
                Continuar = True
                If cmbSubMenu.Items.Count > 0 And cmbSubMenu.SelectedIndex = -1 Then Continuar = False
                If cmbSubMenuItem.Items.Count > 0 And cmbSubMenuItem.SelectedIndex = -1 Then Continuar = False
                If Continuar Then
                    MyControlAcceso = New entControlAcceso
                    With MyControlAcceso
                        .empresa = cmbEmpresa.SelectedValue
                        .usuario = MyUsuarioCA.usuario
                        .nivel_1 = cmbMenu.Text
                        .nivel_2 = cmbSubMenu.Text
                        .nivel_3 = cmbSubMenuItem.Text
                        .privilegios = cmbPrivilegiosNivel.SelectedIndex + 1
                        .permitir_imprimir = IIf(ckbPermitirImprimir.Checked, 1, 0)
                        .usuario_registro = MyUsuario.usuario
                    End With
                    dalControlAcceso.Grabar(MyControlAcceso)
                    ActualizarAccesos()
                End If
            End If
        End If
    End Sub





#End Region


End Class
