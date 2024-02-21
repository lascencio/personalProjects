Public Class frmLista

    Private MyListaElemento As entListaElemento
    Private m_Tabla As String
    Private m_Titulo As String

    Public Sub New(ByVal Lista As entListaElemento, ByVal Tabla As String, ByVal Titulo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyListaElemento = Lista
        m_Tabla = Tabla
        m_Titulo = Titulo

    End Sub

    Private Sub frmLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "RELACION DE " & m_Titulo
    End Sub

    Private Sub gvElementos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvElementos.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerLista(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub gvElementos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvElementos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerLista(sender, sender.CurrentRow.Index)
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
                gvElementos.DataSource = dalTablaDetalle.BuscarListaCodigo(m_Tabla, txtCodigoIntro.Text.Trim)
            Else
                gvElementos.DataSource = dalTablaDetalle.BuscarListaNombre(m_Tabla, txtNombreCodigoIntro.Text.Trim)
            End If
        End If
    End Sub

    Private Sub ObtenerLista(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyListaElemento.codigo = sender.Rows(Indice).Cells("CODIGO").Value
        MyListaElemento.descripcion = sender.Rows(Indice).Cells("DESCRIPCION").Value
        Me.Close()
    End Sub

End Class