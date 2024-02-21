Public Class frmStockAlmacenImprimir

    Private m_Ejercicio As String
    Private m_Mes As String
    Private m_AlmacenCodigo As String
    Private m_AlmacenNombre As String
    Private m_ProductoInicial As String = ""
    Private m_ProductoFinal As String = ""

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

    Private Sub frmStockAlmacenImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyParams(2) As Microsoft.Reporting.WinForms.ReportParameter
        Dim MesNombre As String = UCase(EvalMes(CByte(m_Mes), "L"))

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pAlmacen", m_AlmacenNombre, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pMesNombre", MesNombre, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pEjercicio", m_Ejercicio, False)

        Me.rvStockAlmacen.LocalReport.SetParameters(MyParams)
        Me.rvStockAlmacen.LocalReport.DataSources.Clear()


        Dim MyDT As New dsStockAlmacen.STOCK_ALMACENDataTable

        If m_ProductoInicial.Length <> 0 Then
            MyDT = dalOperacionAlmacen.StockAlmacenRango(m_Ejercicio, m_Mes, m_AlmacenCodigo, m_ProductoInicial, m_ProductoFinal)
        Else
            MyDT = dalOperacionAlmacen.StockAlmacen(m_Ejercicio, m_Mes, m_AlmacenCodigo)
        End If

        Me.rvStockAlmacen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsStockAlmacen_STOCK_ALMACEN", MyDT))

        Me.rvStockAlmacen.RefreshReport()
    End Sub
End Class