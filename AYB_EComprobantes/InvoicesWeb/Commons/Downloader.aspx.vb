Public Class Downloader
    Inherits System.Web.UI.Page

    Private MyUsuario As entUsuario
    Private MyNombreArchivo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ComprobanteTipo As String
        Dim ComprobanteSerie As String
        Dim ComprobanteNumero As String

        MyUsuario = Session("MyUsuario")
        MyNombreArchivo = Session("MyArchivoDescargar")

        Try

            If String.IsNullOrEmpty(MyNombreArchivo) Then Return

            ComprobanteTipo = MyNombreArchivo.Substring(12, 2)
            ComprobanteSerie = MyNombreArchivo.Substring(15, 4)
            ComprobanteNumero = "00" & MyNombreArchivo.Substring(20, 8)

            DownloadFile(Server.MapPath("../MyUploadInvoices/") & MyNombreArchivo, MyNombreArchivo)

            dalEComprobante.Actualizar(MyUsuario.empresa, ComprobanteTipo, ComprobanteSerie, ComprobanteNumero, MyUsuario.usuario)

        Catch ex As Exception
            lblMensaje.Visible = True
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Public Sub DownloadFile(ByVal FilePath As String, ByVal OriginalFileName As String)
        Dim fs As IO.FileStream = Nothing

        'obtenemos el archivo del servidor 
        fs = IO.File.Open(FilePath, IO.FileMode.Open, IO.FileAccess.Read)
        Dim byteBuffer(CInt(fs.Length - 1)) As Byte
        fs.Read(byteBuffer, 0, CInt(fs.Length))
        fs.Close()

        Using ms As New IO.MemoryStream(byteBuffer)
            'descargar con su nombre original 
            Response.AddHeader("Content-Disposition", "attachment; filename=" & OriginalFileName)
            ms.WriteTo(Response.OutputStream)
        End Using

    End Sub

End Class