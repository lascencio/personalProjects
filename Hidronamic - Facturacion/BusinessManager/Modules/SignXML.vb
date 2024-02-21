Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

Module SignXML
    Sub Main(ByVal args() As String)
        Try
            ' Create a new CspParameters object to specify
            ' a key container.
            Dim cspParams As New CspParameters()
            cspParams.KeyContainerName = "XML_DSIG_RSA_KEY"
            ' Create a new RSA signing key and save it in the container. 
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)
            ' Create a new XML document.
            Dim xmlDoc As New XmlDocument()

            ' Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
            ' Sign the XML document. 
            SignXml(xmlDoc, rsaKey)

            Console.WriteLine("XML file signed.")

            ' Save the document.
            xmlDoc.Save("test.xml")


        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub


    ' Sign an XML file. 
    ' This document cannot be verified unless the verifying 
    ' code has the key with which it was signed.
    Sub SignXml(ByVal xmlDoc As XmlDocument, ByVal Rsakey As RSA)
        ' Check arguments.
        If xmlDoc Is Nothing Then
            Throw New ArgumentException("xmlDoc")
        End If
        If Rsakey Is Nothing Then
            Throw New ArgumentException("Key")
        End If
        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(xmlDoc)
        ' Add the key to the SignedXml document.
        signedXml.SigningKey = rsaKey
        ' Create a reference to be signed.
        Dim reference As New Reference()
        reference.Uri = ""
        ' Add an enveloped transformation to the reference.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)
        ' Add the reference to the SignedXml object.
        signedXml.AddReference(reference)
        ' Compute the signature.
        signedXml.ComputeSignature()
        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
        ' Append the element to the XML document.
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))
    End Sub

End Module
