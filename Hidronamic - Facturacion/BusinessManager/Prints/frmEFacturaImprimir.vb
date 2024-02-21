Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmEFacturaImprimir

    Private Empresa As String
    Private Venta As String
    Private NombrePDF As String
    Private ComprobanteNumero As String
    Private ClienteDireccion As String
    Private MonedaDescripcion As String
    Private Observaciones As String
    Private RazonSocial As String
    Private ImporteTexto As String
    Private TextoQR As String
    Private PorcentajeIGV As Decimal
    Private PorcentajeServicio As Decimal

    Private dsCabecera As dsVentas.VENTASDataTable

    Public Sub New(pVenta As entVenta, pRazonSocial As String, pClienteDireccion As String, pMonedaDescripcion As String, pObservaciones As String, pNombrePDF As String, pImporteTexto As String, pTextoQR As String, pPorcentajeIGV As Decimal, pPorcentajeServicio As Decimal)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Empresa = pVenta.empresa
        Venta = pVenta.venta
        ComprobanteNumero = pVenta.comprobante_serie & "-" & pVenta.comprobante_numero
        ClienteDireccion = IIf(pClienteDireccion.Trim.Length = 0, Space(1), pClienteDireccion)
        MonedaDescripcion = pMonedaDescripcion
        Observaciones = pVenta.comentario 'IIf(pObservaciones.Trim.Length = 0, Space(1), pObservaciones)
        NombrePDF = pNombrePDF
        RazonSocial = pRazonSocial
        ImporteTexto = pImporteTexto
        TextoQR = pTextoQR

        PorcentajeIGV = pPorcentajeIGV
        PorcentajeServicio = pPorcentajeServicio

        dsCabecera = New dsVentas.VENTASDataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & Empresa & "' AND VENTA='" & Venta & "'"

        Call ObtenerDataTableSQL(CadenaSQL, dsCabecera)

        Call GenerarQR(TextoQR)

    End Sub

    Private Sub frmEFacturaImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsDetalles As New dsVentas.ECOMPROBANTE_SERVICIOSDataTable
        Dim dsDetallesGlobales As New dsVentas.ECOMPROBANTE_SERVICIOSDataTable
        Dim MyContratos As String

        Dim MyParams(10) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", Venta, False)
        MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
        MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
        MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
        MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeServicio", PorcentajeServicio, False)
        MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Space(1), False)

        Me.rvEFactura.LocalReport.EnableExternalImages = True

        Me.rvEFactura.LocalReport.SetParameters(MyParams)

        dsDetalles = dalVenta.ObtenerDetalles(Empresa, Venta)

        'If dsCabecera(0).COMPROBANTE_SERIE = "0008" Then
        '    dsDetallesGlobales = dalVenta.ObtenerDetallesFacturasGlobales(Empresa, Venta)
        '    If dsDetallesGlobales.Rows.Count <> 0 Then
        '        For NEle As Integer = 0 To dsDetallesGlobales.Rows.Count - 1
        '            MyContratos = MyContratos & dsDetallesGlobales(NEle).GLOSA & "-"
        '        Next
        '        MyContratos = MyContratos.Substring(0, MyContratos.Length - 1)
        '    End If
        'End If

        'If dsDetalles.Rows.Count > 1 Then dsDetalles(1).GLOSA = MyContratos

        Me.rvEFactura.LocalReport.DataSources.Clear()
        Me.rvEFactura.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(dsCabecera, DataTable)))
        Me.rvEFactura.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvEFactura.DocumentMapCollapsed = True

        Me.rvEFactura.LocalReport.DisplayName = NombrePDF

        Dim NombreImpresora As String = ""
        For i As Integer = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
            Dim a As New Printing.PrinterSettings()
            a.PrinterName = Printing.PrinterSettings.InstalledPrinters(i).ToString()
            If a.IsDefaultPrinter Then NombreImpresora = Printing.PrinterSettings.InstalledPrinters(i).ToString()
        Next

        rvEFactura.PrinterSettings.PrinterName = NombreImpresora
        rvEFactura.PrinterSettings.Copies = 1

        Me.rvEFactura.RefreshReport()

        Dim warnings As Warning()
        Dim streamids As String()
        Dim mimeType As String
        Dim encoding As String
        Dim filenameExtension As String
        Dim bytes As Byte() = rvEFactura.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warnings)

        Dim fs As New FileStream(MyTempPath & "\" & NombrePDF & ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Private Sub rvEFactura_Print(sender As Object, e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles rvEFactura.Print
        If e.Cancel = False Then
            ImpresionCancelada = False
            Me.Close()
        End If
    End Sub

End Class