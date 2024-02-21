Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net
Imports System.Text

Public Class dalEmail
    Private Shared MySQLString As String
    Private Shared MySQLCommand As SqlCommand

    Private Shared MyAttachment As Attachment
    Private Shared MyAttachment1 As Attachment
    Private Shared MyAttachment2 As Attachment

    Public Shared Sub EnviarCorreo(pEmpresa As String, ByVal pCuentaComercial As String, Nombre_Archivo As String, ComprobanteFecha As Date)
        Dim MyCuerpo As String = ""
        Dim MyAsunto As String = "Comprobante Electrónico " & Nombre_Archivo.Substring(15, 13)
        Dim Comprobante As String = Nombre_Archivo.Substring(15, 13)
        Dim ComprobanteTipo As String = Nombre_Archivo.Substring(12, 2)
        Dim ComprobanteSerie As String = Nombre_Archivo.Substring(15, 4)
        Dim ComprobanteNumero As String = Nombre_Archivo.Substring(20, 8)
        Dim ComprobanteFechaS As String = ComprobanteFecha.Day.ToString("00") & "/" & ComprobanteFecha.Month.ToString("00") & "/" & ComprobanteFecha.Year.ToString

        Dim ComprobanteNombre As String = IIf(ComprobanteTipo = "01", "Factura", IIf(ComprobanteTipo = "03", "Boleta de Venta", IIf(ComprobanteTipo = "07", "Nota de Crédito", "Nota de Débito")))

        Dim MyDestinatario As String = ObtenerDestinatarioCorreo(pEmpresa, pCuentaComercial)
        If MyDestinatario <> Space(1) Then
            'MyCuerpo = "Estimado Cliente: <br/><br/>"
            'MyCuerpo = MyCuerpo & "Por medio del presente estamos adjuntando los archivos de su Comprobante Electrónico en formato XML y PDF para su consideración.<br/>"
            'MyCuerpo = MyCuerpo & "Puede disponer de estos comprobantes en cualquier momento accediendo al siguiente link: primemusic.ecomprobantes.com <br/><br/>"
            'MyCuerpo = MyCuerpo & "Este correo ha sido generado de forma automática, por favor NO RESPONDER. <br/><br/>"
            'MyCuerpo = MyCuerpo & "Atentamente,<br/><br/>"
            'MyCuerpo = MyCuerpo & "PRIME MUSIC SAC"

            MyCuerpo = "Estimado Cliente: <br/><br/>"
            MyCuerpo = MyCuerpo & "Por la presente le hacemos llegar el siguiente comprobante electrónico:<br/>"
            MyCuerpo = MyCuerpo & "Tipo de Documento: " & ComprobanteNombre & "<br/>"
            MyCuerpo = MyCuerpo & "Serie y Número: " & Comprobante & "<br/>"
            MyCuerpo = MyCuerpo & "Fecha de Emisión: " & ComprobanteFechaS & "<br/><br/>"
            MyCuerpo = MyCuerpo & "Se adjunta la Representación Impresa del documento en formato PDF y el archivo XML (comprimido) validado por SUNAT. <br/>"
            MyCuerpo = MyCuerpo & "Puede disponer de su comprobante accediendo al siguiente link: primemusic.ecomprobantes.com <br/><br/>"
            MyCuerpo = MyCuerpo & "Este correo ha sido generado de forma automática, por favor NO RESPONDER. <br/><br/>"
            MyCuerpo = MyCuerpo & "Atentamente,<br/><br/>"
            MyCuerpo = MyCuerpo & "INVERSIONES LIDOMA"

            Call EnviarEmail(MyDestinatario, MyAsunto, MyCuerpo, Nombre_Archivo)
        End If
    End Sub

    Public Shared Function ObtenerDestinatarioCorreo(pEmpresa As String, ByVal pCuentaComercial As String) As String
        MySQLString = "SELECT ISNULL(MAX(EMAIL_FACTURACION),SPACE(1)) AS EMAIL_FACTURACION FROM COM.CLIENTES " & _
                      "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim Email As String = MySQLCommand.ExecuteScalar
            Return Email
        End Using
    End Function

    Private Shared Sub EnviarEmail(pDestinatario As String, pAsunto As String, pCuerpo As String, Nombre_Archivo As String)
        Dim objEmail As New MailMessage

        MyAttachment1 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".pdf")
        MyAttachment2 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".zip")

        objEmail.IsBodyHtml = True
        objEmail.Priority = MailPriority.High

        'objEmail.ReplyTo = New MailAddress("Cuenta@MiDominio.com")
        'objEmail.Bcc.Add("facturaselectronicas@phantasia.pe")

        'Dim htmlBody As String = "<html><body><h1>Picture</h1><br>" & "<img src=""cid:MyLogo""></body></html>"

        Dim htmlBody As String = "<html><body>" & "<img src=""cid:MyLogo""><br/><br/>" + _
                                 pCuerpo + _
                                 "</body></html>"

        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, MediaTypeNames.Text.Html)

        Dim MyLogo As LinkedResource = New LinkedResource(MyTempPath & "\Logo.jpg", MediaTypeNames.Image.Jpeg)
        MyLogo.ContentId = "MyLogo"
        htmlView.LinkedResources.Add(MyLogo)

        Dim textBody As String = pCuerpo
        Dim txtView As AlternateView = AlternateView.CreateAlternateViewFromString(textBody, Nothing, MediaTypeNames.Text.Plain)

        objEmail.AlternateViews.Add(htmlView)
        objEmail.AlternateViews.Add(txtView)

        objEmail.From = New MailAddress("inversioneslidoma@ecomprobantes.com", "Inversiones Lidoma EIRL", System.Text.Encoding.UTF8)
        objEmail.To.Add(pDestinatario)
        objEmail.Priority = MailPriority.High
        objEmail.Subject = pAsunto

        objEmail.Attachments.Add(MyAttachment1)
        objEmail.Attachments.Add(MyAttachment2)

        Dim objSmtp As New SmtpClient("mail.ecomprobantes.com")
        objSmtp.Port = 8889
        objSmtp.EnableSsl = False
        objSmtp.UseDefaultCredentials = False
        objSmtp.Credentials = New NetworkCredential("inversioneslidoma@ecomprobantes.com", "InversionesLidoma!")

        Try
            objSmtp.Send(objEmail)
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub


End Class
