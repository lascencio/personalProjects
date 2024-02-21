Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.Data

Public Class clsConexionSunat

    'Private wService As ServiceSUNAT_Comprobantes_Beta.billServiceClient
    Private wService As ServiceSUNAT_Comprobantes.billServiceClient

    Private wServiceConsulta As ServiceSUNAT_ConsultaCDR.billServiceClient

    Private strRetorno As String
    Private FileZip As String
    Private FilePath As String


    Public Sub New()
        'wService = New ServiceSUNAT_Comprobantes_Beta.billServiceClient
        wService = New ServiceSUNAT_Comprobantes.billServiceClient

        wServiceConsulta = New ServiceSUNAT_ConsultaCDR.billServiceClient

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
                'strRetorno = "ERROR" & vbLf & "Código: " & ex.Code.Name & vbLf & ex.Message & vbLf
                strRetorno = "ERROR: " & ex.Code.Name & " - " & ex.Message
            End Try
        End If

        Return strRetorno
    End Function

    Public Function EnviarResumenBaja(pArchivo As String) As String
        strRetorno = ""
        FileZip = pArchivo
        FilePath = MyTempPath & "\" & FileZip

        Dim byteArray As Byte() = File.ReadAllBytes(FilePath)

        Try
            wService.Open()
            Dim ticket As String = wService.sendSummary(FileZip, byteArray, "")
            wService.Close()

            strRetorno = ticket
        Catch ex As System.ServiceModel.FaultException
            strRetorno = ex.Code.Name
        End Try

        Return strRetorno
    End Function

    Public Function ObtenerEstado(pTicket As String) As String
        strRetorno = ""

        Try
            wService.Open()
            'Dim returnString As ServiceSUNAT_Comprobantes_Beta.statusResponse = wService.getStatus(pTicket)
            Dim returnString As ServiceSUNAT_Comprobantes.statusResponse = wService.getStatus(pTicket)

            'wServiceConsulta.Open()
            'Dim responseString As ServiceConsultasSunat.statusResponse = wServiceConsulta.getStatusCdr("RUC", "Tipo Comprobante", "Serie Comprobante", "Numero comprobante")


            Dim retorno As String = returnString.statusCode
            wService.Close()

            strRetorno = retorno
        Catch ex As System.ServiceModel.FaultException
            strRetorno = ex.Code.Name
        End Try

        Return strRetorno
    End Function

    Public Function ObtenerEstadoCDR(ComprobanteTipo As String, ComprobanteSerie As String, ComprobanteNumero As String) As String
        strRetorno = ""
        FileZip = MyRUC & "-" & ComprobanteTipo & "-" & ComprobanteSerie & "-" & ComprobanteNumero & ".zip"

        Try
            wService.Open()
            wServiceConsulta.Open()

            Dim responseString As ServiceSUNAT_ConsultaCDR.statusResponse = wServiceConsulta.getStatus(MyRUC, ComprobanteTipo, ComprobanteSerie, ComprobanteNumero)
            Dim responseFile As ServiceSUNAT_ConsultaCDR.statusResponse = wServiceConsulta.getStatusCdr(MyRUC, ComprobanteTipo, ComprobanteSerie, ComprobanteNumero)

            Dim retorno As String = responseFile.statusCode & " : " & responseFile.statusMessage & vbCr & responseString.statusCode & " : " & responseString.statusMessage

            Dim returnByte As Byte() = responseFile.content
            wService.Close()

            If Not returnByte Is Nothing Then
                Dim fs As New FileStream(MyTempPath & "\R-" & FileZip, FileMode.Create)
                fs.Write(returnByte, 0, returnByte.Length)
                fs.Close()
            End If

            strRetorno = retorno

        Catch ex As System.ServiceModel.FaultException
            strRetorno = "Error # " & ex.Code.Name & ": " & ex.Message
        End Try

        Return strRetorno
    End Function

End Class
