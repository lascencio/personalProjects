Public Class frmProductoImprimir

    Private Sub frmProductoImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim MyParams(0) As Microsoft.Reporting.WinForms.ReportParameter

        'MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("", m_Nombre, False)

        Dim MyDT As New dsProductosImprimir.PRODUCTOS_IMPRIMIRDataTable
        MyDT = dalProducto.BuscarProductosImprimir(MyUsuario.empresa, "", 0)

        'Me.rvProductos.LocalReport.SetParameters(MyParams)
        Me.rvProductos.LocalReport.DataSources.Clear()
        Me.rvProductos.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsProductosImprimir_PRODUCTOS_IMPRIMIR", MyDT))

        Me.rvProductos.RefreshReport()

    End Sub
End Class