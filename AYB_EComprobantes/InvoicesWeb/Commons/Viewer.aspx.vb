Public Class Viewer
    Inherits System.Web.UI.Page

    Private MyProspectoCostoTerceros As entProspectoCostoTerceros

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyProspectoCostoTerceros = Session("MyProspectoCostoTerceros")

        If String.IsNullOrEmpty(MyProspectoCostoTerceros.costo) Then Return

        Dim OriginalFileName As String = MyProspectoCostoTerceros.cotizacion_proveedor
        Dim MyLetter As String = ""
        Dim ExtentionFile As String = ""
        Dim MyLengtString As Integer = MyProspectoCostoTerceros.cotizacion_proveedor.Trim.Length - 1

        Do While MyLetter <> "."
            MyLetter = OriginalFileName.Substring(MyLengtString, 1)
            ExtentionFile = MyLetter & ExtentionFile
            MyLengtString = MyLengtString - 1
        Loop

        Dim GuidFileName As String = "T01" & MyProspectoCostoTerceros.prospecto.Substring(3, 9) & MyProspectoCostoTerceros.costo & ExtentionFile

        urIframe.Attributes.Add("src", "../MyUploadFiles/" & GuidFileName)
    End Sub


End Class