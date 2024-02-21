Public Class frmStockProducto

    Private MyResumenAlmacen As dsStockAlmacen.RESUMEN_X_ALMACENDataTable
    Private MyProducto As entProducto

    Private MyComponentes As dsProductos.COMPONENTESDataTable

    Private Sub frmStockProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LimpiarFormulario()
        txtProducto.Focus()
    End Sub

    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
        End If
    End Sub

    Private Sub ValidarProducto(ByVal sender As Object)
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = sender.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
            If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            txtProductoDescripcion.Text = MyProducto.descripcion_ampliada
            Call ConsultarStock()
            'btnConsultar.Focus()
        Else
            Call LimpiarFormulario()
            sender.Focus()
        End If

    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Call ConsultarStock()
    End Sub

    Private Sub ConsultarStock()
        Dim StockActual As Decimal = 0
        MyResumenAlmacen = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable

        If txtProducto.Text.Trim.Length <> 0 Then
            If MyProducto.indica_valida_stock = "NO" Then
                gvStockProducto.DataSource = MyResumenAlmacen
                txtStockActual.Text = EvalDato(StockActual, txtStockActual.Tag)
            Else
                If MyProducto.indica_compuesto = "NO" Then
                    MyResumenAlmacen = dalOperacionAlmacen.StockProducto(txtProducto.Text)
                    gvStockProducto.DataSource = MyResumenAlmacen
                    gvStockProducto.ClearSelection()

                    If MyResumenAlmacen.Rows.Count = 0 Then
                        Resp = MsgBox("No existe stock para este producto.", MsgBoxStyle.Information, "STOCK POR PRODUCTO")
                        Call LimpiarFormulario()
                    Else
                        For NEle As Byte = 0 To MyResumenAlmacen.Rows.Count - 1
                            StockActual = StockActual + MyResumenAlmacen(NEle).STOCK
                        Next
                        txtStockActual.Text = EvalDato(StockActual, txtStockActual.Tag)
                    End If
                Else
                    MyComponentes = dalProducto.ObtenerStockComponentes(MyUsuario.empresa, "001", MyProducto.producto)
                    If MyComponentes.Rows.Count <> 0 Then
                        For NEle As Integer = 0 To MyComponentes.Rows.Count - 1
                            If MyComponentes(NEle).STOCK_ACTUAL > StockActual Then
                                StockActual = MyComponentes(NEle).STOCK_ACTUAL
                            End If
                        Next
                        If StockActual <> 0 Then
                            For NEle As Integer = 0 To MyComponentes.Rows.Count - 1
                                If MyComponentes(NEle).STOCK_ACTUAL < StockActual Then
                                    StockActual = MyComponentes(NEle).STOCK_ACTUAL
                                End If
                            Next
                        End If
                    End If
                    If StockActual = 0 Then
                        Resp = MsgBox("No existe stock para este producto.", MsgBoxStyle.Information, "STOCK POR PRODUCTO")
                        Call LimpiarFormulario()
                    Else
                        txtStockActual.Text = EvalDato(StockActual, txtStockActual.Tag)
                    End If
                End If
            End If

            btnNuevo.Focus()
        End If
    End Sub

    Private Sub LimpiarFormulario()
        txtProducto.Text = Nothing
        txtProductoDescripcion.Text = Nothing
        gvStockProducto.DataSource = New dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        txtStockActual.Text = EvalDato(0, txtStockActual.Tag)
        txtProducto.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarFormulario()
    End Sub
End Class