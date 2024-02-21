Public Class frmAnexoLista

    Private MyAnexo As entCONCAR_Anexo
    Private m_anexo_tipo As String

    Public Sub New(ByVal Anexo As entCONCAR_Anexo, ByVal AnexoTipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyAnexo = Anexo
        m_anexo_tipo = AnexoTipo

    End Sub

    Private Sub gvAnexos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvAnexos.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerAnexoCONCAR(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub gvAnexos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvAnexos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerAnexoCONCAR(sender, sender.CurrentRow.Index)
        ElseIf e.KeyCode = Keys.Up Then
            If sender.CurrentRow.Index = 0 Then txtCodigoIntro.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Intro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoIntro.KeyDown, txtNombreCodigoIntro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            If sender.Name = "txtCodigoIntro" Then
                txtNombreCodigoIntro.Focus()
            Else
                txtCodigoIntro.Focus()
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If gvAnexos.Rows.Count > 0 Then gvAnexos.Focus()
        End If
    End Sub

    Private Sub Intro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoIntro.KeyPress, txtNombreCodigoIntro.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Intro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoIntro.TextChanged, txtNombreCodigoIntro.TextChanged
        If txtCodigoIntro.Text.Trim.Length > 0 And txtNombreCodigoIntro.Text.Trim.Length > 0 Then
            If sender.Name = "txtCodigoIntro" Then
                txtNombreCodigoIntro.Text = Nothing
            Else
                txtCodigoIntro.Text = Nothing
            End If
        End If
        Call ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        If txtCodigoIntro.Text.Trim.Length > 0 Or txtNombreCodigoIntro.Text.Trim.Length > 0 Then
            If txtCodigoIntro.Text.Trim.Length > 0 Then
                gvAnexos.DataSource = dalVenta.BuscarCuentaComercial(txtCodigoIntro.Text.Trim)

                'Select Case m_anexo_tipo
                '    Case Is = "CLIENTE"
                '        gvAnexos.DataSource = dalVenta.BuscarCuentaComercial(txtCodigoIntro.Text.Trim)
                '    Case Is = "PERSONAL"
                '        gvAnexos.DataSource = dalVenta.BuscarPersonalCodigo(txtCodigoIntro.Text.Trim)
                '    Case Else
                '        'gvAnexos.DataSource = dalCONCAR_Anexo.BuscarAnexoCodigo(txtCodigoIntro.Text.Trim, m_anexo_tipo)
                '        gvAnexos.DataSource = dalVenta.BuscarProyectoCodigo(txtCodigoIntro.Text.Trim)
                'End Select
            Else
                gvAnexos.DataSource = dalVenta.BuscarRazonSocial(txtNombreCodigoIntro.Text.Trim)

                'Select Case m_anexo_tipo
                '    Case Is = "CLIENTE"
                '        gvAnexos.DataSource = dalVenta.BuscarRazonSocial(txtNombreCodigoIntro.Text.Trim)
                '    Case Is = "PERSONAL"
                '        gvAnexos.DataSource = dalVenta.BuscarPersonalNombre(txtNombreCodigoIntro.Text.Trim)
                '    Case Else
                '        'gvAnexos.DataSource = dalCONCAR_Anexo.BuscarAnexoNombre(txtNombreCodigoIntro.Text.Trim, m_anexo_tipo)
                '        gvAnexos.DataSource = dalVenta.BuscarProyectoNombre(txtNombreCodigoIntro.Text.Trim)
                'End Select
            End If
        End If
    End Sub

    Private Sub ObtenerAnexoCONCAR(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyAnexo.acodane = sender.Rows(Indice).Cells("acodane").Value
        MyAnexo.adesane = sender.Rows(Indice).Cells("adesane").Value
        Me.Close()
    End Sub

End Class