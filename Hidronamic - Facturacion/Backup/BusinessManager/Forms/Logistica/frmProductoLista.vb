Public Class frmProductoLista

    Private MyProducto As entProducto
    Private m_estado As String = "T"
    Private m_indica_compuesto As String = "SN"

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Producto As entProducto)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyProducto = Producto
    End Sub

    Public Sub New(ByVal Producto As entProducto, ByVal Estado As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyProducto = Producto
        m_estado = Estado
    End Sub

    Public Sub New(ByVal Producto As entProducto, ByVal IndicaCompuesto As String, ByVal Estado As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyProducto = Producto
        m_indica_compuesto = IndicaCompuesto
        m_estado = Estado
    End Sub

    Private Sub gvProductos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvProductos.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerProducto(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub gvProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerProducto(sender, sender.CurrentRow.Index)
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
            If gvProductos.Rows.Count > 0 Then gvProductos.Focus()
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
                gvProductos.DataSource = dalProducto.BuscarProductoCodigo(MyUsuario.empresa, txtCodigoIntro.Text.Trim, m_indica_compuesto, m_estado)
            Else
                gvProductos.DataSource = dalProducto.BuscarProductoDescripcion(MyUsuario.empresa, txtNombreCodigoIntro.Text.Trim, m_indica_compuesto, m_estado)
            End If
        End If
    End Sub

    Private Sub ObtenerProducto(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyProducto.producto = sender.Rows(Indice).Cells("PRODUCTO").Value
        MyProducto.descripcion_ampliada = sender.Rows(Indice).Cells("DESCRIPCION_AMPLIADA").Value
        MyProducto.indica_lote = sender.Rows(Indice).Cells("INDICA_LOTE").Value
        MyProducto.indica_valida_stock = sender.Rows(Indice).Cells("INDICA_VALIDA_STOCK").Value
        MyProducto.indica_compuesto = sender.Rows(Indice).Cells("INDICA_COMPUESTO").Value
        MyProducto.estado = sender.Rows(Indice).Cells("ESTADO").Value
        Me.Close()
    End Sub

End Class