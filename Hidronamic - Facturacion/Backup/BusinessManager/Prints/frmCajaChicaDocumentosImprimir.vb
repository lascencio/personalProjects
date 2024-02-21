Public Class frmCajaChicaDocumentosImprimir

    Private MyCajaChica As entCajaChica
    Private MyTipo As String

    Sub New(ByVal CajaChica As entCajaChica, ByVal Tipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCajaChica = CajaChica
        MyTipo = Tipo
    End Sub

    Private Sub frmCajaChicaImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyParams(2) As Microsoft.Reporting.WinForms.ReportParameter
        Dim MyTipoNombre As String
        Select Case MyTipo
            Case Is = "E" : MyTipoNombre = "ENTREGAS A RENDIR"
            Case Is = "L" : MyTipoNombre = "DOCUMENTOS LIQUIDADOS"
            Case Is = "R" : MyTipoNombre = "DOCUMENTOS REEMBOLSADOS"
        End Select
        Dim pPeriodo As String = EvalMes(CByte(MyCajaChica.mes), "L") & "-" & MyCajaChica.ejercicio

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pCajaChicaNumero", MyCajaChica.numero_caja, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", pPeriodo, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoDocumento", MyTipoNombre, False)

        Dim MyDT As New dsCajaChica.CAJA_CHICA_DOCUMENTOSDataTable
        MyDT = dalCajaChica.ObtenerDocumentos(MyCajaChica, MyTipo)

        Me.rvCajaChica.LocalReport.SetParameters(MyParams)
        Me.rvCajaChica.LocalReport.DataSources.Clear()
        Me.rvCajaChica.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCajaChica_CAJA_CHICA_DOCUMENTOS", MyDT))
        Me.rvCajaChica.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rvCajaChica.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub
End Class