Public Class ExportToExcel
    Inherits System.Web.UI.Page
    Private MyProspecto As entProspecto
    Private MyProspectoRecursosLista As dsProspectos.PROSPECTO_RECURSOS_LISTADataTable
    Private MyProspectoCostoTercerosLista As dsProspectos.PROSPECTOS_COSTO_TERCEROS_LISTADataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyProspectoRecursosLista = Session("MyProspectoRecursosLista")
        MyProspectoCostoTercerosLista = Session("MyProspectoCostoTercerosLista")
        Response.Charset = "UTF-8"
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=DatosCotizacion.xls")
        If MyProspectoRecursosLista.Rows.Count <> 0 Then
            Response.Write("<table border=1>")
            Response.Write("<tr><td>Area</td><td>Recurso</td><td>Costo_Hora</td><td>Horas</td><td>Total_Horas</td></tr>")
            For NEle As Byte = 0 To MyProspectoCostoTercerosLista.Rows.Count - 1
                Response.Write("<tr><td>" & MyProspectoRecursosLista(NEle).CENTRO_COSTO_DESCRIPCION & "</td><td>" & MyProspectoRecursosLista(NEle).CODIGO_DESCRIPCION & "</td><td>" & MyProspectoRecursosLista(NEle).COSTO_HORA & "</td><td>" & MyProspectoRecursosLista(NEle).HORAS & "</td><td>" & MyProspectoRecursosLista(NEle).TOTAL_HORAS & "</td></tr>")
            Next
            Response.Write("</table>")
        End If

    End Sub

End Class