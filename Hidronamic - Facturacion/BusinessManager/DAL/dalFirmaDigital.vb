
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates

Public Class dalFirmaDigital
    ''' 
    '''	Firma un archivo XML con un certificado
    ''' 
    Public Sub SignXmlDocument(objXMLDocument As XmlDocument, objCertificate As X509Certificate2, Optional strReferenceToSign As String = "")

        Dim objSignedXml As New SignedXml(objXMLDocument)

        ' Añade la clave al documento SignedXml
        objSignedXml.SigningKey = DirectCast(objCertificate.PrivateKey, RSACryptoServiceProvider)
        ' Asigna el identificador de referencia
        If strReferenceToSign.Trim.Length <> 0 Then
            objSignedXml.AddReference(GetReference(strReferenceToSign))
        End If
        ' Añade la información de los parámetros de firma
        objSignedXml.Signature.KeyInfo = GetKeyInfoFromCertificate(objCertificate)
        ' Calcula la firma
        objSignedXml.ComputeSignature()
        ' Añade el elemento firmado al documento XML
        objXMLDocument.DocumentElement.AppendChild(objXMLDocument.ImportNode(objSignedXml.GetXml(), True))
    End Sub

    ''' 
    '''	Obtiene los datos de la referencia
    ''' 
    Private Function GetReference(strReferenceToSign As String) As Reference
        Dim objXmlReference As New Reference()

        ' Crea una referencia a firmar
        objXmlReference.Uri = "#" & strReferenceToSign
        ' Añade una transformación a la referencia
        objXmlReference.AddTransform(New XmlDsigEnvelopedSignatureTransform())
        ' Devuelve la referencia creada
        Return objXmlReference
    End Function

    ''' 
    '''	Obtiene la información de la firma asociada al certificado digital
    ''' 
    Private Function GetKeyInfoFromCertificate(objCertificate As X509Certificate2) As KeyInfo
        Dim objKeyInfo As New KeyInfo()

        ' Añade la cláusula con el certificado
        objKeyInfo.AddClause(New KeyInfoX509Data(objCertificate))
        ' Devuelve la información
        Return objKeyInfo
    End Function



End Class
