Public Class frmLotesStockLista

    Private MyLotesStock As dsStockAlmacen.STOCK_X_ALMACENDataTable
    Private MyLoteNumero As TextBox
    Private MyLoteVencimiento As TextBox
    Private MyLoteStock As TextBox

    Public Sub New(ByVal LotesStock As dsStockAlmacen.STOCK_X_ALMACENDataTable, ByRef Lote As TextBox, ByRef Vencimiento As TextBox, ByRef Stock As TextBox)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyLotesStock = LotesStock
        MyLoteNumero = Lote
        MyLoteVencimiento = Vencimiento
        MyLoteStock = Stock
    End Sub

    Private Sub frmLotesStockLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyLoteNumero.Text = Nothing
        MyLoteVencimiento.Text = Nothing
        MyLoteStock.Text = EvalDato(0, MyLoteStock.Tag)
        gvLotes.DataSource = MyLotesStock
    End Sub

    Private Sub gvLotes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvLotes.CellClick
        If Not gvLotes.CurrentRow Is Nothing Then
            With gvLotes.Rows(gvLotes.CurrentRow.Index)
                MyLoteNumero.Text = .Cells("NUMERO_LOTE").Value
                MyLoteVencimiento.Text = .Cells("FECHA_VENCIMIENTO").Value
                MyLoteStock.Text = EvalDato(.Cells("STOCK").Value, MyLoteStock.Tag)
            End With
            Me.Close()
        End If

    End Sub
End Class