Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.ServiceModel

Namespace ConsoleApplication1
    Class Program
        Private Shared Sub Main(args As String())
            Dim l_xml As String = MyTempPath & "\Prueba.xml"
            Dim l_certificado As String = "D:\Clientes\Faraona\GlobalSign\Certificado Digital\CERTIFICADO.CER"
            Dim l_pwd As String = "Gl0b4lS1gn2016"
            Dim l_xpath As String

            Dim l_cert As New X509Certificate2(l_certificado, l_pwd)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load(l_xml)

            Dim signedXml As New SignedXml(xmlDoc)

            signedXml.SigningKey = l_cert.PrivateKey
            Dim KeyInfo As New KeyInfo()

            Dim Reference As New Reference()
            Reference.Uri = ""

            Reference.AddTransform(New XmlDsigEnvelopedSignatureTransform())
            signedXml.AddReference(Reference)

            Dim X509Chain As New X509Chain()
            X509Chain.Build(l_cert)

            Dim local_element As X509ChainElement = X509Chain.ChainElements(0)
            Dim x509Data As New KeyInfoX509Data(local_element.Certificate)
            Dim subjectName As String = local_element.Certificate.Subject

            x509Data.AddSubjectName(subjectName)
            KeyInfo.AddClause(x509Data)

            signedXml.KeyInfo = KeyInfo
            signedXml.ComputeSignature()

            Dim signature As XmlElement = signedXml.GetXml()
            signature.Prefix = "ds"
            signedXml.ComputeSignature()

            For Each loop_node As XmlNode In signature.SelectNodes("descendant-or-self::*[namespace-uri()='http://www.w3.org/2000/09/xmldsig#']")
                If loop_node.LocalName = "Signature" Then
                    Dim newAttribute As XmlAttribute = xmlDoc.CreateAttribute("Id")
                    newAttribute.Value = "SignatureSP"
                    loop_node.Attributes.Append(newAttribute)

                End If
            Next

            Dim nsMgr As New XmlNamespaceManager(xmlDoc.NameTable)
            nsMgr.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
            nsMgr.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2")
            nsMgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")

            If l_xml.Contains("-01-") Then
                'factura
                nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
                l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent"
            ElseIf l_xml.Contains("-07-") Then
                'nota de crédito
                nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")
                l_xpath = "/tns:CreditNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent"
            ElseIf l_xml.Contains("-08-") Then
                'nota de débito
                nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2")
                l_xpath = "/tns:DebitNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent"
            Else
                ' communicacion de baja
                nsMgr.AddNamespace("tns", "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1")
                l_xpath = "/tns:VoidedDocuments/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
            End If

            nsMgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            nsMgr.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
            nsMgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
            nsMgr.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
            nsMgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

            xmlDoc.SelectSingleNode(l_xpath, nsMgr).AppendChild(xmlDoc.ImportNode(signature, True))

            xmlDoc.Save(l_xml)

            'check signature
            Dim nodeList As XmlNodeList = xmlDoc.GetElementsByTagName("ds:Signature")
            'MessageBox.Show("Verification failed: No Signature was found in the document.");
            If nodeList.Count <= 0 Then
                'MessageBox.Show("Verification failed: More that one signature was found for the document.");
            ElseIf nodeList.Count >= 2 Then
            Else
                signedXml.LoadXml(DirectCast(nodeList(0), XmlElement))
                'signature ok
                If signedXml.CheckSignature() Then
                    'signature failed
                Else
                End If
            End If



        End Sub
    End Class
End Namespace
