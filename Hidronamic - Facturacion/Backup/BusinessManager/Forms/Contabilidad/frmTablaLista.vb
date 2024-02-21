Public Class frmTablaLista

    Private MyTabla As entCONCAR_Tabla
    Private m_tabla_tipo As String

    Public Sub New(ByVal Tabla As entCONCAR_Tabla, ByVal TablaTipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyTabla = Tabla
        m_tabla_tipo = TablaTipo

    End Sub

    Private Sub gvElementos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvElementos.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerTabla(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub gvElementos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvElementos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerTabla(sender, sender.CurrentRow.Index)
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
            If gvElementos.Rows.Count > 0 Then gvElementos.Focus()
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
                gvElementos.DataSource = dalCONCAR_Anexo.BuscarElementoCodigo(txtCodigoIntro.Text.Trim, m_tabla_tipo)
            Else
                gvElementos.DataSource = dalCONCAR_Anexo.BuscarElementoNombre(txtNombreCodigoIntro.Text.Trim, m_tabla_tipo)
            End If
        End If
    End Sub

    Private Sub ObtenerTabla(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyTabla.tclave = sender.Rows(Indice).Cells("tclave").Value
        MyTabla.tdescri = sender.Rows(Indice).Cells("tdescri").Value
        Me.Close()
    End Sub

End Class