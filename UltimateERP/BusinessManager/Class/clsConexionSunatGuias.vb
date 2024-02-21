Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.Data

Public Class clsConexionSunatGuias
    Private wService As ServiceSUNAT_Guias.billServiceClient

    Private strRetorno As String
    Private FileZip As String
    Private FilePath As String

    Public Sub New()
        wService = New ServiceSUNAT_Guias.billServiceClient
        ServicePointManager.UseNagleAlgorithm = True
        ServicePointManager.Expect100Continue = False
        ServicePointManager.CheckCertificateRevocationList = True
    End Sub

    Public Function EnviarDocumento(pArchivo As String) As String
        strRetorno = ""
        FileZip = pArchivo
        FilePath = MyTempPath & "\" & FileZip

        If File.Exists(FilePath) = True Then
            Dim byteArray As Byte()

            Try
                byteArray = File.ReadAllBytes(FilePath)

                wService.Open()
                Dim returnByte As Byte() = wService.sendBill(FileZip, byteArray, "")
                wService.Close()

                Dim fs As New FileStream(MyTempPath & "\R-" & FileZip, FileMode.Create)
                fs.Write(returnByte, 0, returnByte.Length)
                fs.Close()
                strRetorno = "Archivo enviado con éxito."
            Catch ex As System.ServiceModel.FaultException
                strRetorno = "ERROR: " & ex.Code.Name & " - " & ex.Message
            End Try
        End If

        Return strRetorno
    End Function

    Public Function ObtenerEstado(pTicket As String) As String
        strRetorno = ""

        Try
            wService.Open()
            Dim returnString As ServiceSUNAT_Guias.statusResponse = wService.getStatus(pTicket)

            Dim retorno As String = returnString.statusCode
            wService.Close()

            strRetorno = retorno
        Catch ex As System.ServiceModel.FaultException
            strRetorno = ex.Code.Name
        End Try

        Return strRetorno
    End Function

End Class
