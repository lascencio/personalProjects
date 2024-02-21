Public Class frmMovimientosProducto

    Private dsDetalles As dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTODataTable
    Private MyProducto As entProducto

    Private MyFechaInicial As String
    Private MyFechaDesde As String
    Private MyFechaHasta As String

    Private RangoFechas As String

    Private Sub frmMovimientosProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dsDetalles = New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTODataTable
        cmbAlmacen.DataSource = MyDTAlmacenes

        ckbAlmacen.Checked = True
        cmbAlmacen.SelectedValue = MyUsuario.almacen

        txtFechaDesde.Text = EvalDato("01/01/" & Now.Year.ToString, "F")
        txtFechaHasta.Text = EvalDato(Now, "F")

        txtFechaDesde.Focus()
    End Sub

    Private Sub txtFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaDesde.KeyDown, txtFechaHasta.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            If sender.Name = "txtFechaDesde" Then
                txtFechaHasta.Focus()
            Else
                txtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaDesde.Validated, txtFechaHasta.Validated
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = EvalDato(sender.Text, sender.Tag)
            If sender.Name = "txtFechaDesde" Then
                txtFechaHasta.Focus()
            Else
                txtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub ckbAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles ckbAlmacen.CheckedChanged
        If ckbAlmacen.Checked = True Then
            EnableComboBox(cmbAlmacen, True)
            cmbAlmacen.Focus()
        Else
            EnableComboBox(cmbAlmacen, False)
            cmbAlmacen.SelectedIndex = -1
            btnRefrescar.Focus()
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
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            btnRefrescar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
        End If
    End Sub

    Private Sub RefrescarReporte()
        Dim DiaPrimero As Date
        Dim DiaAnterior As Date
        Dim dsDetallesFinal As New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTODataTable

        Dim MyStockInicial As Decimal = dalKardex.ObtenerStock(txtFechaDesde.Text.Substring(6, 4) & txtFechaDesde.Text.Substring(3, 2), txtProducto.Text, IIf(cmbAlmacen.SelectedIndex = -1, "TODOS", cmbAlmacen.SelectedValue))
        Dim MyStockFinal As Decimal = MyStockInicial

        Dim MyParams(3) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pRangoFechas", RangoFechas, False)

        If txtFechaDesde.Text.Substring(0, 2) <> "01" Then
            DiaPrimero = "01/" & txtFechaDesde.Text.Substring(3, 2) & "/" & txtFechaDesde.Text.Substring(6, 4)
            DiaAnterior = DateAdd(DateInterval.Day, -1, CDate(txtFechaDesde.Text))

            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                If dsDetalles(NEle).OPERACION_FECHA >= DiaPrimero And dsDetalles(NEle).OPERACION_FECHA <= DiaAnterior Then
                    If dsDetalles(NEle).TIPO_ES = "I" Then
                        MyStockInicial = MyStockInicial + dsDetalles(NEle).CANTIDAD
                    Else
                        MyStockInicial = MyStockInicial - dsDetalles(NEle).CANTIDAD
                    End If
                Else
                    dsDetallesFinal.ImportRow(dsDetalles(NEle))
                End If

                If dsDetalles(NEle).TIPO_ES = "I" Then
                    MyStockFinal = MyStockFinal + dsDetalles(NEle).CANTIDAD
                Else
                    MyStockFinal = MyStockFinal - dsDetalles(NEle).CANTIDAD
                End If
            Next
            dsDetalles = dsDetallesFinal
        Else
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                If dsDetalles(NEle).TIPO_ES = "I" Then
                    MyStockFinal = MyStockFinal + dsDetalles(NEle).CANTIDAD
                Else
                    MyStockFinal = MyStockFinal - dsDetalles(NEle).CANTIDAD
                End If
            Next
        End If

        If MyProducto.indica_compuesto = "SI" Then
            MyStockInicial = -MyStockFinal
            MyStockFinal = 0
        End If

        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pStockInicial", MyStockInicial, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pStockFinal", MyStockFinal, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pProducto", MyProducto.codigo_compra.Trim & " " & MyProducto.descripcion_ampliada.Trim, False)

        Me.rvMovimientosProducto.LocalReport.SetParameters(MyParams)

        Me.rvMovimientosProducto.LocalReport.DataSources.Clear()
        Me.rvMovimientosProducto.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvMovimientosProducto.DocumentMapCollapsed = True

        Me.rvMovimientosProducto.RefreshReport()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 And txtProducto.Text.Trim.Length <> 0 Then
            MyFechaInicial = txtFechaDesde.Text.Substring(6, 4) & "-" & txtFechaDesde.Text.Substring(3, 2) & "-01"
            MyFechaDesde = txtFechaDesde.Text.Substring(6, 4) & "-" & txtFechaDesde.Text.Substring(3, 2) & "-" & txtFechaDesde.Text.Substring(0, 2)
            MyFechaHasta = txtFechaHasta.Text.Substring(6, 4) & "-" & txtFechaHasta.Text.Substring(3, 2) & "-" & txtFechaHasta.Text.Substring(0, 2)
            RangoFechas = "DESDE EL " & txtFechaDesde.Text & " AL " & txtFechaHasta.Text
            dsDetalles = dalKardex.ObtenerMovimientosProducto(MyFechaInicial, MyFechaHasta, txtProducto.Text.Trim, IIf(cmbAlmacen.SelectedIndex = -1, "TODOS", cmbAlmacen.SelectedValue))

            Call RefrescarReporte()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("OPERACION_FECHA", Type.GetType("System.DateTime")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("ALMACEN_NOMBRE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("OPERACION_NOMBRE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("COMENTARIO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("CANTIDAD_INGRESO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("CANTIDAD_EGRESO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("ALMACEN_NOMBRE").MaxLength = 100
            .Columns("OPERACION_NOMBRE").MaxLength = 100
            .Columns("COMENTARIO").MaxLength = 1000
        End With

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                With dsDetalles(NEle)
                    MyDR = MyExcelReport.NewRow
                    If .OPERACION_FECHA.Year <> 1900 Then MyDR.Item("OPERACION_FECHA") = .OPERACION_FECHA
                    MyDR.Item("ALMACEN_NOMBRE") = .ALMACEN_NOMBRE
                    MyDR.Item("OPERACION_NOMBRE") = .OPERACION_NOMBRE
                    MyDR.Item("COMENTARIO") = LTrim(Strings.Left(.COMENTARIO & " " & IIf(Len(RTrim(.REFERENCIA_NUMERO)) <> 0, .REFERENCIA_TIPO & "/" & .REFERENCIA_SERIE & "-" & .REFERENCIA_NUMERO & " " & RTrim(.REFERENCIA_RAZON_SOCIAL) & " ", ""), 90))
                    MyDR.Item("CANTIDAD_INGRESO") = .CANTIDAD_INGRESO
                    MyDR.Item("CANTIDAD_EGRESO") = .CANTIDAD_EGRESO
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub
End Class