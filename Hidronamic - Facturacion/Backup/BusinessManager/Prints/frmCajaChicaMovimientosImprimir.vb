Public Class frmCajaChicaMovimientosImprimir

    Private MyCajaChica As entCajaChica
    Private IndicaHistorico As Boolean

    Sub New(ByVal CajaChica As entCajaChica, ByVal IndicaCajaActual As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCajaChica = CajaChica
        IndicaHistorico = Not IndicaCajaActual
    End Sub

    Private Sub frmCajaChicaImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyParams(1) As Microsoft.Reporting.WinForms.ReportParameter
        Dim pPeriodo As String = EvalMes(CByte(MyCajaChica.mes), "L") & "-" & MyCajaChica.ejercicio

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pCajaChicaNumero", MyCajaChica.numero_caja, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", pPeriodo, False)

        Dim MyDT As New dsCajaChica.CAJA_CHICA_MOVIMIENTOSDataTable
        MyDT = dalCajaChica.ObtenerMovimientos(MyCajaChica, IndicaHistorico)

        Me.rvCajaChica.LocalReport.SetParameters(MyParams)
        Me.rvCajaChica.LocalReport.DataSources.Clear()
        Me.rvCajaChica.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCajaChica_CAJA_CHICA_MOVIMIENTOS", MyDT))
        Me.rvCajaChica.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rvCajaChica.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub
End Class