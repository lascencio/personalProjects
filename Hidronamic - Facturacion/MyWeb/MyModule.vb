Module MyModule

    Public Sub MoverArchivoTemp(FileName As String, FileType As String, TipoAdjunto As String, Prospecto As String, Secuencia As String)
        Dim SourceFile As String = MyTempPath & FileName
        'Dim DestinationFile As String = Server.MapPath("~/MyUploadFiles/") & TipoAdjunto & Prospecto.Substring(3, 9) & Secuencia & FileType
        Dim DestinationFile As String = HttpContext.Current.Server.MapPath("/MyUploadFiles/") & TipoAdjunto & Prospecto.Substring(3, 9) & Secuencia & FileType
        If System.IO.File.Exists(DestinationFile) Then System.IO.File.Delete(DestinationFile)
        System.IO.File.Move(SourceFile, DestinationFile)
    End Sub


End Module
