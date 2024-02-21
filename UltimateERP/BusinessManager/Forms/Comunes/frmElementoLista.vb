Public Class frmElementoLista

    Private MyElementos As dsTablasGenericas.LISTADataTable
    Private MyElemento As dsTablasGenericas.LISTADataTable

    Public Sub New(ByRef Elemento As dsTablasGenericas.LISTADataTable, ByVal CodigoTabla As String, Titulo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyElemento = Elemento
        MyElementos = ObtenerListaEmpresa(CodigoTabla, True)
        Me.Text = Titulo
    End Sub

    Private Sub frmElementoLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        gvElementos.DataSource = MyElementos
        gvElementos.ClearSelection()
    End Sub

    Private Sub gvElementos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvElementos.CellDoubleClick
        Dim MyIndex As Integer
        If Not gvElementos.CurrentRow Is Nothing Then
            MyIndex = gvElementos.CurrentRow.Index
            MyElemento.ImportRow(MyElementos(MyIndex))
            Me.Close()
        End If
    End Sub




End Class