Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmTicketCobranzaImprimir

    Private NumeroCobranza As String
    Private Cliente As String
    Private Moneda As String

    Private MyLocalReport As String

    Private VistaPrevia As Boolean

    Public Sub New(pNumeroCobranza As String, pCliente As String, pMoneda As String, pVistaPrevia As Boolean)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        NumeroCobranza = pNumeroCobranza
        Cliente = pCliente
        Moneda = pMoneda

        VistaPrevia = pVistaPrevia

        'Me.Visible = False
    End Sub

    Private Sub frmTicketCobranzaImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsCabecera As New dsFinanciero.COBRANZASDataTable
        Dim dsDetalles As New dsFinanciero.COBRANZAS_DETALLESDataTable
        Dim dsPago As New dsFinanciero.COBRANZAS_PAGODataTable
        Dim ImporteTexto As String

        Dim MyParams(2) As ReportParameter

        Me.rvTicketCobranza.LocalReport.EnableExternalImages = True

        CadenaSQL = "SELECT * FROM FIN.COBRANZAS WHERE EMPRESA='" & MyUsuario.empresa & "' AND COBRANZA='" & NumeroCobranza & "'"
        Call ObtenerDataTableSQL(CadenaSQL, dsCabecera)

        If dsCabecera.Rows.Count <> 0 Then
            ImporteTexto = "SON: " & ConvertNumText(dsCabecera(0).IMPORTE, Moneda)

            CadenaSQL = "SELECT * FROM FIN.COBRANZAS_DETALLES WHERE EMPRESA='" & MyUsuario.empresa & "' AND COBRANZA='" & NumeroCobranza & "'"
            Call ObtenerDataTableSQL(CadenaSQL, dsDetalles)

            CadenaSQL = "SELECT TFP.DESCRIPCION AS FORMA_PAGO, TM.DESCRIPCION AS MONEDA, C.DINERO_RECIBIDO, C.DINERO_VUELTO_MN, C.TIPO_CAMBIO_PAGO AS TIPO_CAMBIO " &
                        "FROM  FIN.COBRANZAS AS C INNER JOIN GEN.TABLA_MONEDA AS TM ON C.TIPO_MONEDA_PAGO = TM.CODIGO " &
                        "INNER JOIN GEN.TABLA_FORMA_PAGO_COBRANZA AS TFP ON C.FORMA_PAGO = TFP.CODIGO " &
                        "WHERE C.EMPRESA ='" & MyUsuario.empresa & "' AND C.COBRANZA='" & NumeroCobranza & "'"
            Call ObtenerDataTableSQL(CadenaSQL, dsPago)
        End If

        MyParams(0) = New ReportParameter("pMoneda", Moneda, False)
        MyParams(1) = New ReportParameter("pCliente", Cliente, False)
        MyParams(2) = New ReportParameter("pImporteTexto", ImporteTexto, False)
        Me.rvTicketCobranza.LocalReport.SetParameters(MyParams)



        Me.rvTicketCobranza.LocalReport.DataSources.Clear()
        Me.rvTicketCobranza.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(dsCabecera, DataTable)))
        Me.rvTicketCobranza.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvTicketCobranza.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsPago", DirectCast(dsPago, DataTable)))

        Me.rvTicketCobranza.DocumentMapCollapsed = True



        If VistaPrevia = True Then
            Me.rvTicketCobranza.RefreshReport()
        Else
            clsImpresion.Imprimir(Me.rvTicketCobranza.LocalReport)
        End If

        If VistaPrevia = False Then Me.Close()


        'Me.rvTicketCobranza.RefreshReport()


        'Me.rvTicketCobranza.LocalReport.DisplayName = NombrePDF

        'If VistaPrevia = True Then
        '    Me.rvTicketCobranza.RefreshReport()
        'Else
        '    clsImpresion.Imprimir(Me.rvTicketCobranza.LocalReport)
        'End If

        'Dim warnings As Warning()
        'Dim streamids As String()
        'Dim mimeType As String
        'Dim encoding As String
        'Dim filenameExtension As String
        'Dim bytes As Byte() = rvTicketCobranza.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warnings)

        'Dim fs As New FileStream(MyTempPath & "\" & NombrePDF & ".pdf", FileMode.Create)
        'fs.Write(bytes, 0, bytes.Length)
        'fs.Close()

        'If VistaPrevia = False Then Me.Close()
    End Sub
End Class