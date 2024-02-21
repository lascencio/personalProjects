Public Class frmStockProductoAlmacenImprimir

    Private m_Ejercicio As String
    Private m_Mes As String
    Private m_AlmacenCodigo As String
    Private m_AlmacenNombre As String
    Private m_ProductoInicial As String = ""
    Private m_ProductoFinal As String = ""

    Private MyProductTopBottom As dsProductos.PRODUCTOS_LISTADataTable
    Private MyProducto As entProducto

    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MyTipos As dsTablasGenericas.LISTADataTable
    Private MyAlmacen As dsTablasGenericas.LISTADataTable

    Private dsDetalles As New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable

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

    Sub New(ByVal Ejercicio As String, ByVal Mes As String, ByVal AlmacenCodigo As String, ByVal AlmacenNombre As String, ByVal ProductoInicial As String, ByVal ProductoFinal As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_Ejercicio = Ejercicio
        m_Mes = Mes
        m_AlmacenCodigo = AlmacenCodigo
        m_AlmacenNombre = AlmacenNombre
        m_ProductoInicial = ProductoInicial
        m_ProductoFinal = ProductoFinal
    End Sub

    Private Sub frmStockAlmacenImprimir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmStockAlmacenImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")
        MyTipos = ObtenerListaEmpresa("PRODUCTO_TIPO", "DESCRIPCION")

        dsDetalles = New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable
        MyAlmacen = New dsTablasGenericas.LISTADataTable

        MyAlmacen.Rows.Add("COM_ALMACEN", "TODOS", "TODOS", "TODOS", Space(1), 0)

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbFamilia.DataSource = MyFamilias
        cmbTipo.DataSource = MyTipos
        cmbAlmacen.DataSource = MyAlmacen

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        EnableTextBox(txtProductoDesde, False)

        txtFecha.Text = EvalDato(Now.Date, "F")
    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ValidarFecha_Validated(sender As Object, e As EventArgs) Handles txtFecha.Validated
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = EvalDato(sender.Text, sender.Tag)
        End If
    End Sub

    Private Sub txtProductoDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductoDesde.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub txtProductoHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductoHasta.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoHastaNombre.Text = MyProducto.descripcion_ampliada
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

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim MyFecha As Date
        Dim m_dia As String

        If txtFecha.Text.Trim.Length <> 0 Then
            m_AlmacenNombre = cmbAlmacen.Text

            If cmbAlmacen.Text = "TODOS" Then
                Me.rvStockAlmacen.LocalReport.ReportEmbeddedResource = "BusinessManager.rptStockProductoAlmacen.rdlc"
            Else
                Me.rvStockAlmacen.LocalReport.ReportEmbeddedResource = "BusinessManager.rptStockProductoAlmacenUnico.rdlc"
            End If

            MyFecha = txtFecha.Text

            m_dia = Strings.Right("00" & MyFecha.Day.ToString, 2)
            m_Mes = Strings.Right("00" & MyFecha.Month.ToString, 2)
            m_Ejercicio = MyFecha.Year.ToString

            m_AlmacenCodigo = cmbAlmacen.SelectedValue
            m_ProductoInicial = txtProductoDesde.Text
            m_ProductoFinal = txtProductoHasta.Text

            Dim MyParams(3) As Microsoft.Reporting.WinForms.ReportParameter
            Dim MesNombre As String = UCase(EvalMes(CByte(m_Mes), "L"))

            MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pAlmacen", m_AlmacenNombre, False)
            MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pMesNombre", MesNombre, False)
            MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pEjercicio", m_Ejercicio, False)
            MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pDia", m_dia, False)

            Me.rvStockAlmacen.LocalReport.SetParameters(MyParams)
            Me.rvStockAlmacen.LocalReport.DataSources.Clear()

            Dim MyResumenStock As New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable

            Dim MyMovimientosDelMes As New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTOSDataTable
            Dim MyCodigoAlmacen As String
            Dim MyCodigoProducto As String
            Dim MyTipoES As String
            Dim MyCantidad As Integer

            dsDetalles = New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable

            If ckbProductoTodos.Checked = True Then
                MyResumenStock = dalOperacionAlmacen.StockProductoAlmacen(m_Ejercicio, m_Mes, m_AlmacenCodigo, cmbFamilia.SelectedValue, cmbTipo.SelectedValue)
                MyMovimientosDelMes = dalOperacionAlmacen.MovimientoProductos(m_Ejercicio, m_Mes, m_AlmacenCodigo, cmbFamilia.SelectedValue, cmbTipo.SelectedValue)
            Else
                MyResumenStock = dalOperacionAlmacen.StockProductoAlmacenRango(m_Ejercicio, m_Mes, m_AlmacenCodigo, m_ProductoInicial, m_ProductoInicial)
                MyMovimientosDelMes = dalOperacionAlmacen.MovimientoProductosRango(m_Ejercicio, m_Mes, m_AlmacenCodigo, m_ProductoInicial, m_ProductoInicial)
            End If

            If MyResumenStock.Rows.Count <> 0 Then
                If MyMovimientosDelMes.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyMovimientosDelMes.Rows.Count - 1
                        If MyMovimientosDelMes(NEle).FECHA_OPERACION <= MyFecha Then
                            MyCodigoAlmacen = MyMovimientosDelMes(NEle).ALMACEN
                            MyCodigoProducto = MyMovimientosDelMes(NEle).PRODUCTO
                            MyTipoES = MyMovimientosDelMes(NEle).TIPO_ES
                            MyCantidad = MyMovimientosDelMes(NEle).CANTIDAD

                            Dim MyRegistroBuscar As dsStockAlmacen.STOCK_PRODUCTO_ALMACENRow
                            Dim PrimaryKey(1) As Object
                            PrimaryKey(0) = MyCodigoProducto
                            PrimaryKey(1) = MyCodigoAlmacen

                            MyRegistroBuscar = MyResumenStock.Rows.Find(PrimaryKey)

                            If MyRegistroBuscar IsNot Nothing Then
                                If MyTipoES = "I" Then
                                    MyRegistroBuscar.INGRESOS = MyRegistroBuscar.INGRESOS + MyCantidad
                                    MyRegistroBuscar.STOCK_FINAL = MyRegistroBuscar.STOCK_FINAL + MyCantidad
                                Else
                                    MyRegistroBuscar.EGRESOS = MyRegistroBuscar.EGRESOS + MyCantidad
                                    MyRegistroBuscar.STOCK_FINAL = MyRegistroBuscar.STOCK_FINAL - MyCantidad
                                End If
                            End If
                        End If
                    Next
                End If

                For NEle As Integer = 0 To MyResumenStock.Rows.Count - 1
                    With MyResumenStock(NEle)
                        If .STOCK_INICIAL + .INGRESOS + .EGRESOS + .STOCK_FINAL <> 0 Then
                            dsDetalles.ImportRow(MyResumenStock(NEle))
                        End If
                    End With
                Next
            End If

            Me.rvStockAlmacen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))

            Me.rvStockAlmacen.RefreshReport()
        End If
    End Sub

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        If ckbProductoTodos.Checked = False Then
            EnableTextBox(txtProductoDesde, True)
            txtProductoDesde.Focus()
        Else
            txtProductoDesde.Text = Nothing
            txtProductoDesdeNombre.Text = Nothing
            EnableTextBox(txtProductoDesde, False)
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("ALMACEN", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("DESCRIPCION", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("STOCK_INICIAL", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("INGRESOS", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("EGRESOS", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("STOCK_FINAL", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("ALMACEN").MaxLength = 500
            .Columns("DESCRIPCION").MaxLength = 500
        End With

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                With dsDetalles(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("ALMACEN") = .ALMACEN_DESCRIPCION
                    MyDR.Item("DESCRIPCION") = .DESCRIPCION
                    MyDR.Item("STOCK_INICIAL") = .STOCK_INICIAL
                    MyDR.Item("INGRESOS") = .INGRESOS
                    MyDR.Item("EGRESOS") = .EGRESOS
                    MyDR.Item("STOCK_FINAL") = .STOCK_FINAL
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub
End Class