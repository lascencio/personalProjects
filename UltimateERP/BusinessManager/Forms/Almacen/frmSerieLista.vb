Public Class frmSerieLista
    Private MySerie As entSerie

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(Serie As entSerie)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MySerie = Serie
    End Sub

    Private Sub frmSerieLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ActualizarGrilla()
    End Sub

    Private Sub gvSeries_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSeries.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerSerie(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub ObtenerSerie(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MySerie.numero_serie = sender.Rows(Indice).Cells("NUMERO_SERIE").Value
        Me.Close()
    End Sub

    Private Sub ActualizarGrilla()
        gvSeries.DataSource = dalControlSeries.BuscarSeriesDisponibles(MySerie.almacen, MySerie.producto)
    End Sub

End Class