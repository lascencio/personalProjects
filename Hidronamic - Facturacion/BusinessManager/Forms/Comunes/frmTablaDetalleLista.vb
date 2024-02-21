Public Class frmTablaDetalleLista

    Private MyTablaDetalle As entTablaDetalle

    Private m_Empresa As String
    Private m_Tabla As String
    Private m_Estado As String

    Public Sub New(ByVal TablaDetalle As entTablaDetalle, ByVal Empresa As String, ByVal Tabla As String, ByVal Estado As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyTablaDetalle = TablaDetalle

        m_Empresa = Empresa
        m_Tabla = Tabla
        m_Estado = Estado
    End Sub

    Private Sub frmTablaDetalleLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gvElementos.DataSource = dalTablaDetalle.ObtenerDetalles(m_Empresa, m_Tabla, m_Estado)
        gvElementos.ClearSelection()
    End Sub

    Private Sub gvElementos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvElementos.CellDoubleClick
        If Not gvElementos.CurrentRow Is Nothing Then Call ObtenerCodigo(gvElementos.CurrentRow.Index)
    End Sub

    Private Sub gvElementos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvElementos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerCodigo(sender.CurrentRow.Index)
        ElseIf e.KeyCode = Keys.Up Then
            If sender.CurrentRow.Index = 0 Then txtCodigoIntro.Focus() : gvElementos.ClearSelection()
        ElseIf e.KeyCode = Keys.Escape Then
            MyTablaDetalle.codigo_item = Nothing : Me.Close()
        End If
    End Sub

    Private Sub Intro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoIntro.KeyDown, txtNombreIntro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            If sender.Name = "txtCodigoIntro" Then
                txtNombreIntro.Focus()
            Else
                txtCodigoIntro.Focus()
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If gvElementos.Rows.Count > 0 Then gvElementos.Focus() : gvElementos.Rows(0).Selected = True
        End If
    End Sub

    Private Sub Intro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoIntro.KeyPress, txtNombreIntro.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then MyTablaDetalle.codigo_item = Nothing : Me.Close()
    End Sub

    Private Sub Intro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoIntro.TextChanged, txtNombreIntro.TextChanged
        If txtCodigoIntro.Text.Trim.Length > 0 And txtNombreIntro.Text.Trim.Length > 0 Then
            If sender.Name = "txtCodigoIntro" Then
                txtNombreIntro.Text = Nothing
            Else
                txtCodigoIntro.Text = Nothing
            End If
        End If
        Call ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        If txtCodigoIntro.Text.Trim.Length > 0 Or txtNombreIntro.Text.Trim.Length > 0 Then
            If txtCodigoIntro.Text.Trim.Length > 0 Then
                gvElementos.DataSource = dalTablaDetalle.BuscarElementosCodigo(m_Empresa, m_Tabla, txtCodigoIntro.Text.Trim)
            Else
                gvElementos.DataSource = dalTablaDetalle.BuscarElementosNombre(m_Empresa, m_Tabla, txtNombreIntro.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub ObtenerCodigo(ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyTablaDetalle.codigo_item = gvElementos.Rows(Indice).Cells("CODIGO").Value
        Me.Close()
    End Sub

End Class