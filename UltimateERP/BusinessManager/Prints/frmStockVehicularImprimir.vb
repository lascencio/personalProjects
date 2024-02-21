Public Class frmStockVehicularImprimir

    Private m_Ejercicio As String
    Private m_Mes As String
    Private m_AlmacenCodigo As String
    Private m_AlmacenNombre As String

    Private MyAlmacen As dsTablasGenericas.LISTADataTable
    Private MyProducto As entProducto
    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MySubFamilias As dsTablasGenericas.LISTADataTable

    Private dsDetalles As dsStockAlmacen.STOCK_VEHICULARDataTable

    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub New(ByVal Ejercicio As String, ByVal Mes As String, ByVal AlmacenCodigo As String, ByVal AlmacenNombre As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_Ejercicio = Ejercicio
        m_Mes = Mes
        m_AlmacenCodigo = AlmacenCodigo
        m_AlmacenNombre = AlmacenNombre
    End Sub

    Private Sub frmStockVehicularImprimir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmStockVehicularImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")

        MyAlmacen = New dsTablasGenericas.LISTADataTable

        dsDetalles = New dsStockAlmacen.STOCK_VEHICULARDataTable

        MyAlmacen.Rows.Add("COM_ALMACEN", "TODOS", "TODOS", "TODOS", Space(1), 0)

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbFamilia.DataSource = MyFamilias
        cmbSubFamilia.DataSource = MySubFamilias
        cmbAlmacen.DataSource = MyAlmacen

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        EnableTextBox(txtProducto, False)

    End Sub

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        If ckbProductoTodos.Checked = False Then
            cmbFamilia.SelectedIndex = 0
            cmbSubFamilia.SelectedIndex = 0
            EnableComboBox(cmbFamilia, False)
            EnableComboBox(cmbSubFamilia, False)
            EnableTextBox(txtProducto, True)
            txtProducto.Focus()
        Else
            EnableComboBox(cmbFamilia, True)
            EnableComboBox(cmbSubFamilia, True)
            txtProducto.Text = Nothing
            txtProductoNombre.Text = Nothing
            EnableTextBox(txtProducto, False)
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoNombre.Text = MyProducto.descripcion_ampliada
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
            If Not MyProducto.producto Is Nothing Then MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            cmbFamilia.SelectedValue = MyProducto.producto_familia
            cmbSubFamilia.SelectedValue = MyProducto.producto_sub_familia
            btnGenerar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
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

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If ckbProductoTodos.Checked = True Then
            dsDetalles = dalKardex.ObtenerStockVehicular(MyUsuario.empresa, cmbAlmacen.SelectedValue, cmbFamilia.SelectedValue, cmbSubFamilia.SelectedValue)
        Else
            dsDetalles = dalKardex.ObtenerStockVehicular(MyUsuario.empresa, cmbAlmacen.SelectedValue, txtProducto.Text)
        End If

        Me.rvStockAlmacen.LocalReport.DataSources.Clear()

        Me.rvStockAlmacen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))

        Me.rvStockAlmacen.RefreshReport()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("ALMACEN", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRODUCTO_DESCRIPCION", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("MARCA", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("MODELO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("SERIE_MOTOR", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("SERIE_CHASIS", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("COLOR", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("AÑO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("ADQ", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("DIAS", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("ALMACEN").MaxLength = 500
            .Columns("PRODUCTO_DESCRIPCION").MaxLength = 500
            .Columns("MARCA").MaxLength = 100
            .Columns("MODELO").MaxLength = 100
            .Columns("SERIE_MOTOR").MaxLength = 50
            .Columns("SERIE_CHASIS").MaxLength = 50
            .Columns("COLOR").MaxLength = 50
            .Columns("AÑO").MaxLength = 20
            .Columns("ADQ").MaxLength = 20
        End With

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                With dsDetalles(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("ALMACEN") = .ALMACEN_DESCRIPCION
                    MyDR.Item("PRODUCTO_DESCRIPCION") = .PRODUCTO_DESCRIPCION
                    MyDR.Item("MARCA") = .MARCA
                    MyDR.Item("MODELO") = .MODELO
                    MyDR.Item("SERIE_MOTOR") = .NUMERO_SERIE
                    MyDR.Item("SERIE_CHASIS") = .NUMERO_SERIE_CHASIS
                    MyDR.Item("COLOR") = .COLOR
                    MyDR.Item("AÑO") = .AÑO_FABRICACION
                    MyDR.Item("ADQ") = .TIPO_ADQUISICION
                    MyDR.Item("DIAS") = DateDiff(DateInterval.Day, .FECHA_OPERACION, Now.Date)
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub
End Class