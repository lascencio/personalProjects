
Public Class frmControlAccesos

    Dim MainMenu As New MenuStrip
    Private MyControlAcceso As New entControlAcceso
    Private MyUsuarioCA As New entUsuario

    Private Sub frmControlAccesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEmpresa.DataSource = MyDTEmpresas

        Dim MyDT As New dsUsuarios.USUARIOSDataTable
        CadenaSQL = "SELECT * FROM GEN.USUARIOS WHERE ESTADO='ACT'"
        Call ObtenerDataTableSQL_Web(CadenaSQL, MyDT)
        cmbUsuario.DataSource = MyDT
        MainMenu = frmMenu.MenuPrincipal
        cmbMenu.Items.Clear()
        For Each OpcionMenu In MainMenu.Items
            cmbMenu.Items.Add(OpcionMenu.Text)
        Next
        ActualizarAccesos(False)
        cmbPrivilegiosNivel.SelectedIndex = 0
    End Sub

    Private Sub cmbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMenu.SelectedIndexChanged
        If cmbMenu.SelectedIndex <> -1 Then
            cmbSubMenu.Items.Clear()
            cmbSubMenuItem.Items.Clear()
            For Each OpcionMenu In MainMenu.Items
                If OpcionMenu.Text = cmbMenu.Text Then
                    For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                        cmbSubMenu.Items.Add(OpcionSubMenu.Text)
                    Next
                End If
            Next
            ActualizarAccesos(False)
        End If
    End Sub

    Private Sub cmbSubMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubMenu.SelectedIndexChanged
        If cmbSubMenu.SelectedIndex <> -1 Then
            cmbSubMenuItem.Items.Clear()
            For Each OpcionMenu In MainMenu.Items
                If OpcionMenu.Text = cmbMenu.Text Then
                    For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                        If OpcionSubMenu.Text = cmbSubMenu.Text Then
                            For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                                cmbSubMenuItem.Items.Add(OpcionSubMenuItem.Text)
                            Next
                        End If
                    Next
                End If
            Next
        End If
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
                    ActualizarAccesos(True)
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ActualizarAccesos(ByVal Refresh As Boolean)
        gvAccesos.DataSource = dalControlAcceso.ObtenerAccesos(MyUsuarioCA)
        gvAccesos.ClearSelection()
        cmbMenu.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If gvAccesos.CurrentCell Is Nothing Then
            MsgBox("Debe seleccionar un registro de la lista", MsgBoxStyle.Information, "ELIMINAR")
        Else
            Resp = MsgBox("Esta seguro de eliminar el registro seleccionado?", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                NFil = gvAccesos.CurrentCell.RowIndex
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
                dalControlAcceso.Borrar(MyControlAcceso)
                ActualizarAccesos(True)
            End If
        End If
    End Sub

    Private Sub gvAccesos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvAccesos.CellClick
        If gvAccesos.SelectedCells.Count > 0 Then
            cmbSubMenu.SelectedIndex = -1 : cmbSubMenuItem.SelectedIndex = -1
            NFil = gvAccesos.CurrentCell.RowIndex
            cmbMenu.Text = gvAccesos.Rows(NFil).Cells(2).Value()
            cmbSubMenu.Text = gvAccesos.Rows(NFil).Cells(3).Value()
            cmbSubMenuItem.Text = gvAccesos.Rows(NFil).Cells(4).Value()
            ckbPermitirImprimir.Checked = gvAccesos.Rows(NFil).Cells(5).Value()
            cmbPrivilegiosNivel.SelectedIndex = gvAccesos.Rows(NFil).Cells(7).Value() - 1
        End If
    End Sub

    Private Sub cmbPrivilegiosNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrivilegiosNivel.SelectedIndexChanged
        If cmbPrivilegiosNivel.SelectedIndex <> -1 Then
            If cmbPrivilegiosNivel.SelectedIndex = 0 Then
                ckbPermitirImprimir.Visible = False
                ckbPermitirImprimir.Checked = True
            Else
                ckbPermitirImprimir.Visible = True
            End If
        End If
    End Sub

    Private Sub CambiarCombos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuario.SelectedIndexChanged, cmbEmpresa.SelectedIndexChanged
        If cmbUsuario.SelectedIndex <> -1 Then
            txtUsuario.Text = cmbUsuario.SelectedValue
            MyControlAcceso.usuario = cmbUsuario.Text
            MyControlAcceso.empresa = cmbEmpresa.SelectedValue
            MyUsuarioCA.empresa = cmbEmpresa.SelectedValue
            MyUsuarioCA.usuario = MyControlAcceso.usuario
            MyUsuarioCA.perfil = cmbUsuario.Items(cmbUsuario.SelectedIndex)(5)
            MyUsuarioCA.privilegios = cmbUsuario.Items(cmbUsuario.SelectedIndex)(6)
            cmbPrivilegiosUsuario.SelectedIndex = MyUsuarioCA.privilegios - 1
            ActualizarAccesos(False)
            cmbMenu.Enabled = IIf(cmbPrivilegiosUsuario.SelectedIndex = 0, False, True)
            cmbSubMenu.Enabled = IIf(cmbPrivilegiosUsuario.SelectedIndex = 0, False, True)
            cmbSubMenuItem.Enabled = IIf(cmbPrivilegiosUsuario.SelectedIndex = 0, False, True)
        End If
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuario.SelectedIndexChanged
        If cmbUsuario.SelectedIndex <> -1 Then
            cmbMenu.SelectedIndex = -1
            cmbSubMenu.SelectedIndex = -1
            cmbSubMenuItem.SelectedIndex = -1
        End If
    End Sub

End Class