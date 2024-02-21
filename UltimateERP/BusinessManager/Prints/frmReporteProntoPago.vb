Public Class frmReporteProntoPago
    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyCobranzaProntoPago As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable
    Private TipoPrestamo As String
    Private FormaPago As String

    Private IndicaHistorico As Boolean

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(Prestamo As dsFinanciero.PRESTAMOSDataTable, CobranzaProntoPago As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable, pTipoPrestamo As String, pFormaPago As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyPrestamo = Prestamo
        MyCobranzaProntoPago = CobranzaProntoPago
        TipoPrestamo = pTipoPrestamo
        FormaPago = pFormaPago
    End Sub

    Private Sub frmReporteProntoPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MyParams(5) As Microsoft.Reporting.WinForms.ReportParameter
        Dim AgenciaNombre As String = MyAgencia(0).RAZON_SOCIAL
        Dim AgenciaDireccion As String = MyAgencia(0).DOMICILIO
        Dim AgenciaUbigeo As String = MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento
        Dim Sectorista As String = MyUser(0).NOMBRE_COMPLETO

        Me.rvProntoPago.LocalReport.EnableExternalImages = True

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoPrestamo", TipoPrestamo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pFormaPago", FormaPago, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaNombre", AgenciaNombre, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaDireccion", AgenciaDireccion, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaUbigeo", AgenciaUbigeo, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pSectorista", Sectorista, False)

        Me.rvProntoPago.LocalReport.SetParameters(MyParams)

        Me.rvProntoPago.LocalReport.DataSources.Clear()
        Me.rvProntoPago.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(MyPrestamo, DataTable)))
        Me.rvProntoPago.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyCobranzaProntoPago, DataTable)))

        Me.rvProntoPago.DocumentMapCollapsed = True
        Me.rvProntoPago.RefreshReport()
    End Sub

End Class