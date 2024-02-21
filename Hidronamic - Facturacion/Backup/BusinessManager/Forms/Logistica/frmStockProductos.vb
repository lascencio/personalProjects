Public Class frmStockProductos

    Private MyProductTopBottom As dsProductos.PRODUCTOS_LISTADataTable
    Private MyProducto As entProducto


    Private Sub frmStockProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmStockProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")

        For NAño As Integer = 2015 To Now.Year + 1
            cmbEjercicio.Items.Add(NAño)
        Next
        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = Now.Month - 1
        cmbAlmacen.SelectedValue = "000"

        Call BuscarProducto(txtProductoDesde, True)
        txtProductoDesdeNombre.Text = MyProductTopBottom(0).DESCRIPCION_AMPLIADA

        Call BuscarProducto(txtProductoHasta, False)
        txtProductoHastaNombre.Text = MyProductTopBottom(0).DESCRIPCION_AMPLIADA

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BuscarProducto(ByRef MyTextBox As TextBox, ByVal EsPrimero As Boolean)
        MyProductTopBottom = dalProducto.ProductosTopBottom(cmbAlmacen.SelectedValue, EsPrimero)
        MyTextBox.Text = MyProductTopBottom(0).PRODUCTO
    End Sub

    Private Sub txtProductoDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductoDesde.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
        End If
    End Sub

    Private Sub txtProductoHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductoHasta.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoHastaNombre.Text = MyProducto.descripcion_ampliada
        End If
    End Sub

    Private Sub ValidarProducto(ByVal sender As Object)
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = sender.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
        Else
            MyProducto = dalProducto.Obtener(MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            btnImprimir.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If txtProductoDesdeNombre.Text.Trim.Length <> 0 And txtProductoHastaNombre.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmStockAlmacenImprimir(cmbEjercicio.Text, Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2), cmbAlmacen.SelectedValue, cmbAlmacen.Text, txtProductoDesde.Text, txtProductoHasta.Text)
            MyForm.ShowDialog()
        End If
    End Sub
End Class