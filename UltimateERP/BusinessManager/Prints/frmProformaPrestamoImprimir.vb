Public Class frmProformaPrestamoImprimir
    Private MyProforma As dsFinanciero.PROFORMASDataTable
    Private MyProformaProyeccion As dsFinanciero.PROFORMA_PROYECCIONDataTable
    Private TipoPrestamo As String
    Private FormaPago As String

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(Proforma As dsFinanciero.PROFORMASDataTable, ProformaProyeccion As dsFinanciero.PROFORMA_PROYECCIONDataTable, pTipoPrestamo As String, pFormaPago As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyProforma = Proforma
        MyProformaProyeccion = ProformaProyeccion
        TipoPrestamo = pTipoPrestamo
        FormaPago = pFormaPago
    End Sub

    Private Sub frmProformaPrestamoImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MyParams(5) As Microsoft.Reporting.WinForms.ReportParameter
        Dim AgenciaNombre As String = MyAgencia(0).RAZON_SOCIAL
        Dim AgenciaDireccion As String = MyAgencia(0).DOMICILIO
        Dim AgenciaUbigeo As String = MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento
        Dim Sectorista As String = MyUser(0).NOMBRE_COMPLETO

        Me.rvProformaPrestamo.LocalReport.EnableExternalImages = True

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoPrestamo", TipoPrestamo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pFormaPago", FormaPago, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaNombre", AgenciaNombre, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaDireccion", AgenciaDireccion, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaUbigeo", AgenciaUbigeo, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pSectorista", Sectorista, False)

        Me.rvProformaPrestamo.LocalReport.SetParameters(MyParams)

        Me.rvProformaPrestamo.LocalReport.DataSources.Clear()
        Me.rvProformaPrestamo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(MyProforma, DataTable)))
        Me.rvProformaPrestamo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyProformaProyeccion, DataTable)))

        Me.rvProformaPrestamo.DocumentMapCollapsed = True

        Me.rvProformaPrestamo.RefreshReport()
    End Sub
End Class