Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class frmReporteUtilidadProducto

    Private MyAlmacen As dsTablasGenericas.LISTADataTable
    Private MyProducto As entProducto
    Private MyTipos As dsTablasGenericas.LISTADataTable
    Private MySubTipos As dsTablasGenericas.LISTADataTable
    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MySubFamilias As dsTablasGenericas.LISTADataTable

    Private MyMovimientosProducto As dsCostos.MOVIMIENTOS_PRODUCTODataTable

    Private MyPeriodo As String
    Private MyTipoMoneda As String

    Private Procesado As Boolean

    Private MyUtilidadProductos As dsCostos.UTILIDAD_PRODUCTODataTable

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmReporteUtilidadProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")
        MyTipos = ObtenerListaEmpresa("PRODUCTO_TIPO", "DESCRIPCION")

        MyAlmacen = New dsTablasGenericas.LISTADataTable

        MyUtilidadProductos = New dsCostos.UTILIDAD_PRODUCTODataTable

        MyAlmacen.Rows.Add("COM_ALMACEN", "TODOS", "TODOS", "TODOS", Space(1), 0)

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbTipo.DataSource = MyTipos
        cmbSubTipo.DataSource = MySubTipos
        cmbFamilia.DataSource = MyFamilias
        cmbSubFamilia.DataSource = MySubFamilias
        cmbAlmacen.DataSource = MyAlmacen

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        txtFechaDesde.Text = EvalDato("01/01/" & Now.Year.ToString, "F")
        txtFechaHasta.Text = EvalDato(Now.Date, "F")
        cmbTipoMoneda.SelectedValue = "1"
    End Sub

    Private Sub txtFechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaDesde.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            txtFechaHasta.Focus()
        End If
    End Sub

    Private Sub txtFechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaHasta.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaDesde.Validated, txtFechaHasta.Validated
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = EvalDato(sender.Text, sender.Tag)
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubFamiliasNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubFamilias = New dsTablasGenericas.LISTADataTable
            MySubFamilias.Rows.Add("PRODUCTO_SUB_FAMILIA", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyFamilias(MyIndex).CODIGO <> "TODOS" Then
                MySubFamiliasNew = ObtenerListaEmpresa("PRODUCTO_SUB_FAMILIA", "DESCRIPCION")
                If MySubFamiliasNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubFamiliasNew.Rows.Count - 1
                        With MySubFamiliasNew(NEle)
                            If .REFERENCIA = MyFamilias(MyIndex).REFERENCIA Then
                                MySubFamilias.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubFamilia.DataSource = MySubFamilias
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubTiposNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubTipos = New dsTablasGenericas.LISTADataTable
            MySubTipos.Rows.Add("PRODUCTO_SUB_TIPO", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyTipos(MyIndex).CODIGO <> "TODOS" Then
                MySubTiposNew = ObtenerListaEmpresa("PRODUCTO_SUB_TIPO", "DESCRIPCION")
                If MySubTiposNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubTiposNew.Rows.Count - 1
                        With MySubTiposNew(NEle)
                            If .REFERENCIA = MyTipos(MyIndex).REFERENCIA Then
                                MySubTipos.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubTipo.DataSource = MySubTipos
        End If
    End Sub

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        If ckbProductoTodos.Checked = False Then
            EnableTextBox(txtProducto, True)
            txtProducto.Focus()
            cmbTipo.SelectedValue = "TODOS"
            cmbFamilia.SelectedValue = "TODOS"
        Else
            txtProducto.Text = Nothing
            txtProductoDesdeNombre.Text = Nothing
            EnableTextBox(txtProducto, False)
            btnGenerar.Focus()
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
            btnGenerar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
        End If
    End Sub

    Private Sub ImprimirReporte(FechaDesde As Long, FechaHasta As Long)
        Dim pAlmacen As String = cmbAlmacen.SelectedValue
        Dim pMarca As String = cmbFamilia.SelectedValue
        Dim pModelo As String = cmbSubFamilia.SelectedValue
        Dim pLinea As String = cmbTipo.SelectedValue
        Dim pSubLinea As String = cmbSubTipo.SelectedValue

        Dim pProducto As String = txtProducto.Text

        Dim pMoneda As String = cmbTipoMoneda.SelectedValue

        MyPeriodo = MyUsuario.ejercicio

        MyUtilidadProductos = dalCostoPromedio.ObtenerUtilidadProducto(MyUsuario.empresa, MyPeriodo, pAlmacen, pMarca, pModelo, pLinea, pSubLinea, pProducto, FechaDesde.ToString, FechaHasta.ToString)

        If MyUtilidadProductos.Rows.Count <> 0 Then

            For NEle As Integer = 0 To MyUtilidadProductos.Rows.Count - 1
                MyUtilidadProductos(NEle).VALOR_VENTA = IIf(pMoneda = "1", MyUtilidadProductos(NEle).VALOR_VENTA_MN, MyUtilidadProductos(NEle).VALOR_VENTA_ME)
                MyUtilidadProductos(NEle).COSTO_VENTA = IIf(pMoneda = "1", MyUtilidadProductos(NEle).COSTO_VENTA_MN, MyUtilidadProductos(NEle).COSTO_VENTA_ME)
                MyUtilidadProductos(NEle).UTILIDAD = MyUtilidadProductos(NEle).VALOR_VENTA - MyUtilidadProductos(NEle).COSTO_VENTA
            Next
        End If
        Dim MyParams(3) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", MyPeriodo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pMoneda", pMoneda, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaDesde", txtFechaDesde.Text, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaHasta", txtFechaHasta.Text, False)

        Me.rvUtilidadProducto.LocalReport.SetParameters(MyParams)

        Me.rvUtilidadProducto.LocalReport.DataSources.Clear()
        Me.rvUtilidadProducto.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyUtilidadProductos, DataTable)))
        Me.rvUtilidadProducto.DocumentMapCollapsed = True

        Me.rvUtilidadProducto.RefreshReport()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim FechaDesde As Date
        Dim FechaHasta As Date
        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 Then
            FechaDesde = CDate(txtFechaDesde.Text)
            FechaHasta = CDate(txtFechaHasta.Text)

            If Procesado = False Then
                Procesado = dalCostoPromedio.CalcularCostoPromedio(MyProgressBar)

                MyProgressBar.Visible = False
            End If

            Call ImprimirReporte(FechaDesde.Year * 10000 + FechaDesde.Month * 100 + FechaDesde.Day, FechaHasta.Year * 10000 + FechaHasta.Month * 100 + FechaHasta.Day)
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("ALMACEN", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRODUCTO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRODUCTO_NOMBRE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("UNIDADES_VENDIDAS", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("VALOR_VENTA", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("COSTO_VENTA", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("UTILIDAD", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("ALMACEN").MaxLength = 500
            .Columns("PRODUCTO").MaxLength = 500
            .Columns("PRODUCTO_NOMBRE").MaxLength = 1000
        End With

        If MyUtilidadProductos.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyUtilidadProductos.Rows.Count - 1
                With MyUtilidadProductos(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("ALMACEN") = .ALMACEN_NOMBRE
                    MyDR.Item("PRODUCTO") = .PRODUCTO
                    MyDR.Item("PRODUCTO_NOMBRE") = .PRODUCTO_NOMBRE
                    MyDR.Item("UNIDADES_VENDIDAS") = .UNIDADES_VENDIDAS
                    MyDR.Item("VALOR_VENTA") = .VALOR_VENTA
                    MyDR.Item("COSTO_VENTA") = .COSTO_VENTA
                    MyDR.Item("UTILIDAD") = .UTILIDAD
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub

End Class