Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net
Imports System.IO
Imports System.Text

Public Class dalEmails
    Private Shared MySql As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyAttachment1 As Attachment
    Private Shared MyAttachment2 As Attachment

    Public Shared Function ObtenerDestinatarioCorreo(pEmpresa As String, ByVal pCuentaComercial As String) As String
        MySql = "SELECT ISNULL(MAX(EMAIL_FACTURACION),SPACE(1)) AS EMAIL_FACTURACION FROM COM.CLIENTES " & _
                "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            MySQLCommand = New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim Email As String = MySQLCommand.ExecuteScalar
            Return Email
        End Using

    End Function

    Public Shared Sub EnviarCorreo(pEmpresa As String, ByVal pCuentaComercial As String, Nombre_Archivo As String)
        Dim MyCuerpo As String = ""
        Dim MyAsunto As String = "Comprobante Electrónico " & Nombre_Archivo.Substring(15, 13)
        Dim MyDestinatario As String = ObtenerDestinatarioCorreo(pEmpresa, pCuentaComercial)
        If MyDestinatario <> Space(1) Then
            MyCuerpo = "<br/>Estimado Cliente: <br/><br/>"
            MyCuerpo = MyCuerpo & "Por medio del presente estamos adjuntando los archivos de su Comprobante Electrónico en formato XML y PDF para su consideración.<br/>"
            MyCuerpo = MyCuerpo & "Puede disponer de estos comprobantes en cualquier momento accediendo al siguiente link: hingesac.ecomprobantes.com con las siguientes credenciales:<br/>"
            MyCuerpo = MyCuerpo & "Número de RUC  : doc. de identidad<br/>"
            MyCuerpo = MyCuerpo & "ID del Usuario : correo al que se envío este comprobante<br/>"
            MyCuerpo = MyCuerpo & "Contraseña     : primeros 4 dígitos del doc. de identidad<br/><br/>"
            MyCuerpo = MyCuerpo & "Este correo ha sido generado de forma automática, por favor NO RESPONDER. <br/><br/>"
            MyCuerpo = MyCuerpo & "Atentamente,<br/>"
            'MyCuerpo = MyCuerpo & "HIDRONAMIC INGENIEROS SAC"

            Call EnviarEmail2(MyDestinatario, MyAsunto, MyCuerpo, Nombre_Archivo)
        End If
    End Sub

    Private Shared Sub EnviarEmail1(pDestinatario As String, pAsunto As String, pCuerpo As String, Nombre_Archivo As String)
        Dim objEmail As New MailMessage

        MyAttachment1 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".pdf")
        MyAttachment2 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".zip")

        objEmail.IsBodyHtml = True
        objEmail.Priority = MailPriority.High

        Dim htmlBody As String = "<html><body>" & "<img src=""cid:MyLogo""><br/><br/>" + _
                                pCuerpo + _
                                "</body></html>"

        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, MediaTypeNames.Text.Html)

        Dim MyLogo As LinkedResource = New LinkedResource(MyTempPath & "\Logo.jpg", MediaTypeNames.Image.Jpeg)
        MyLogo.ContentId = "MyLogo"
        htmlView.LinkedResources.Add(MyLogo)

        Dim textBody As String = pCuerpo
        Dim txtView As AlternateView = AlternateView.CreateAlternateViewFromString(textBody, Nothing, MediaTypeNames.Text.Html)

        objEmail.AlternateViews.Add(htmlView)
        objEmail.AlternateViews.Add(txtView)

        objEmail.From = New MailAddress("comprobanteselectronicos@hidronamic.com", "Hidronamic Ingenieros SAC", System.Text.Encoding.UTF8)
        objEmail.To.Add(pDestinatario)
        objEmail.Priority = MailPriority.High
        objEmail.Subject = pAsunto

        objEmail.Attachments.Add(MyAttachment1)
        objEmail.Attachments.Add(MyAttachment2)


        Dim objSmtp As New SmtpClient("smtp.gmail.com")
        objSmtp.Port = 587
        objSmtp.EnableSsl = True
        objSmtp.UseDefaultCredentials = False
        objSmtp.Credentials = New NetworkCredential("comprobanteselectronicos@hidronamic.com", "DiamondPony36")

        Try
            objSmtp.Send(objEmail)
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Shared Sub EnviarEmail2(pDestinatario As String, pAsunto As String, pCuerpo As String, Nombre_Archivo As String)
        Dim objEmail As New MailMessage

        MyAttachment1 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".pdf")
        MyAttachment2 = New Attachment(MyTempPath & "\" & Nombre_Archivo & ".zip")

        objEmail.IsBodyHtml = True
        objEmail.Priority = MailPriority.High

        Dim b As Bitmap = New Bitmap(My.Resources.logo_email)
        Dim ic As ImageConverter = New ImageConverter
        Dim ba() As Byte = CType(ic.ConvertTo(b, GetType(Byte())), Byte())
        Dim logo As MemoryStream = New MemoryStream(ba)

        Dim htmlBody As String = pCuerpo + "<img src=cid:logoEmpresa >"

        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, MediaTypeNames.Text.Html)

        Dim MyLogo As LinkedResource = New LinkedResource(logo, MediaTypeNames.Image.Jpeg)
        MyLogo.ContentId = "logoEmpresa"
        htmlView.LinkedResources.Add(MyLogo)

        'Dim textBody As String = pCuerpo
        'Dim txtView As AlternateView = AlternateView.CreateAlternateViewFromString(textBody, Nothing, MediaTypeNames.Text.Html)

        objEmail.AlternateViews.Add(htmlView)
        'objEmail.AlternateViews.Add(txtView)

        objEmail.From = New MailAddress("comprobanteselectronicos@hidronamic.com", "Hidronamic Ingenieros SAC", System.Text.Encoding.UTF8)
        objEmail.To.Add(pDestinatario)
        objEmail.Priority = MailPriority.High
        objEmail.Subject = pAsunto

       

        objEmail.Attachments.Add(MyAttachment1)
        objEmail.Attachments.Add(MyAttachment2)


        Dim objSmtp As New SmtpClient("smtp.gmail.com")
        objSmtp.Port = 587
        objSmtp.EnableSsl = True
        objSmtp.UseDefaultCredentials = False
        objSmtp.Credentials = New NetworkCredential("comprobanteselectronicos@hidronamic.com", "DiamondPony36")

        Try
            objSmtp.Send(objEmail)
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub
End Class
