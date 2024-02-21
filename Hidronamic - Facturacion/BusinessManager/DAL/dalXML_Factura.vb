Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.Data
Imports System.Xml.Schema
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices

Imports System.IO.Compression

Public Class dalXML_Factura
    Private Shared MyElementoXML As Linq.XElement

    Private Shared Success As Boolean
    Private Shared MyConexion As clsConexionSunat

    Private Shared MyVenta As entVenta
    Private Shared MyVentaDetalles As dsVentasDetalleLista.VENTAS_DET_LISTADataTable
    Private Shared MyFacturaDetalles As dsVentas.VENTAS_SERDataTable

    Private Shared MyVentaDatos As dsVentas.VENTAS_DATOSDataTable

    Private Shared MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private Shared MyClienteTipo As String
    Private Shared MyClienteRUC As String
    Private Shared MyClienteNombre As String

    Private Shared vBaseImponibleGravada, vImporteExonerado, vImporteInafecto, vValorExportacion, vIGV, vOtrosTributos, vSubTotal, vValorVenta, vImporteTotal, vImporteOperacionesGratuitas As Decimal
    Private Shared vImportePercepcion, vImporteRetencion, vImporteDetraccion, vImporteDescuentoGlobal As Decimal

    Private Shared dBaseImponibleGravada, dImporteExonerado, dImporteInafecto, dValorExportacion, dIGV, dImporteTotal, dValorVenta As Decimal

    Private Shared vMoneda As String
    Private Shared vTipoAfectacion As String
    Private Shared NombreArchivo As String

    Private Shared MyCodigoTipoOperacion As String = "0101" 'Catálogo N° 51 SUNAT

    Private Declare Function URLDownloadToFile Lib "urlmon" Alias "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, ByVal szFileName As String, ByVal dwReserved As Long, ByVal lpfnCB As Long) As IntPtr

    Private Shared MyDomicilioProvincia As String = "LIMA"
    Private Shared MyDomicilioDepartamento As String = "LIMA"
    Private Shared MyDomicilioUbigeo As String = "150130"
    Private Shared MyDomicilioDistrito As String = "SAN BORJA"


    Public Shared Function CrearDocumento(Venta As entVenta, VentaDetalles As dsVentasDetalleLista.VENTAS_DET_LISTADataTable, FacturaDetalles As dsVentas.VENTAS_SERDataTable, Razon_Social As String, TipoMoneda As String) As Boolean
        Dim EsConforme As Boolean = False
        Dim MyComprobanteXML As New Linq.XDocument

        MyVenta = Venta
        MyVentaDetalles = VentaDetalles
        MyFacturaDetalles = FacturaDetalles

        'MyVentaDatos = VentaDatos

        vBaseImponibleGravada = 0 : vImporteExonerado = 0 : vImporteInafecto = 0 : vValorExportacion = 0 : vIGV = 0 : vOtrosTributos = 0 : vValorVenta = 0 : vImporteTotal = 0
        vImporteDescuentoGlobal = 0 : vImporteOperacionesGratuitas = 0 : vImporteDetraccion = 0

        If MyFacturaDetalles.Rows.Count <> 0 Then
            For NEle As Byte = 0 To MyFacturaDetalles.Rows.Count - 1
                With MyFacturaDetalles(NEle)
                    vBaseImponibleGravada = vBaseImponibleGravada + .BASE_IMPONIBLE_GRAVADA_ORIGEN
                    vImporteExonerado = vImporteExonerado + .IMPORTE_EXONERADO_ORIGEN
                    vImporteInafecto = vImporteInafecto + .IMPORTE_INAFECTO_ORIGEN
                    vValorExportacion = vValorExportacion + .VALOR_EXPORTACION_ORIGEN
                    vIGV = vIGV + .IGV_ORIGEN
                    vOtrosTributos = vOtrosTributos + .OTROS_TRIBUTOS_ORIGEN
                    vImporteTotal = vImporteTotal + .IMPORTE_TOTAL_ORIGEN
                End With
            Next
        End If

        'vImporteInafecto = vImporteInafecto + vValorExportacion
        vSubTotal = vBaseImponibleGravada + vImporteExonerado + vImporteInafecto
        vImporteDescuentoGlobal = MyVenta.descuento_global_origen
        vValorVenta = vSubTotal - vImporteDescuentoGlobal

        If MyVenta.condicion_pago = "TG" Then
            vImporteOperacionesGratuitas = vImporteTotal
            vBaseImponibleGravada = 0
            vIGV = 0
            vImporteTotal = 0
            vTipoAfectacion = 11
        Else
            If MyVenta.indica_exportacion = "SI" Then
                vTipoAfectacion = "40"
            Else
                vTipoAfectacion = IIf(vBaseImponibleGravada <> 0, "10", IIf(vImporteExonerado <> 0, "20", IIf(vImporteInafecto <> 0, "30", "40")))
            End If
            If vImporteDescuentoGlobal <> 0 Then
                vBaseImponibleGravada = vBaseImponibleGravada - vImporteDescuentoGlobal
                vIGV = Math.Round(vBaseImponibleGravada * MyIGV / 100, 2)
                vImporteTotal = vBaseImponibleGravada + vIGV
            End If
        End If

        'vImporteDetraccion = Math.Round(IIf(vImporteTotal <> 0, vImporteTotal * MyDetraccion / 100, 0), 2)

        vMoneda = IIf(MyVenta.tipo_moneda = "1", "PEN", "USD")
        SEE1000 = "SON: " & ConvertNumText(vImporteTotal, TipoMoneda)

        MyConsultaRUC = dalVenta.ObtenerDatosRUC(MyVenta.cuenta_comercial.Trim)

        If MyConsultaRUC.Rows.Count <> 0 Then
            MyClienteRUC = MyConsultaRUC(0).RUC
            MyClienteTipo = "6"
            MyClienteNombre = MyConsultaRUC(0).RAZON_SOCIAL
        Else
            MyClienteRUC = MyVenta.cuenta_comercial.Trim
            MyClienteTipo = "0"
            MyClienteNombre = Razon_Social
            If MyVenta.comprobante_tipo = "01" Then
                'MyClienteRUC = MyVenta.cuenta_comercial.Trim
                MyClienteTipo = "6"
            ElseIf MyVenta.comprobante_tipo = "03" Then
                If IsNumeric(MyClienteRUC) Then
                    If MyClienteRUC.Length = 8 Then MyClienteTipo = "1"
                End If
            Else
                If MyVenta.referencia_tipo = "01" Then
                    ' MyClienteRUC = MyVenta.cuenta_comercial.Trim
                    MyClienteTipo = "6"
                Else
                    If IsNumeric(MyClienteRUC) Then
                        If MyClienteRUC.Length = 8 Then MyClienteTipo = "1"
                    End If
                End If
            End If
        End If

        NombreArchivo = MyRUC & "-" & MyVenta.comprobante_tipo & "-" & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero.Substring(2, 8)

        If MyVenta.comprobante_tipo = "01" Then MyComprobanteXML = CrearFactura2_1()
        If MyVenta.comprobante_tipo = "07" Then MyComprobanteXML = CrearNotaCredito2_1()
        'If MyVenta.comprobante_tipo = "08" Then MyComprobanteXML = CrearNotaDebito(MyComprobanteXML)
        If MyVenta.comprobante_tipo = "03" Then MyComprobanteXML = CrearBoleta2_1()
        Call GuardarArchivoXML(MyComprobanteXML)

        EsConforme = ValidarDocumento()
        Return EsConforme
    End Function

    Public Shared Function CrearComunicacionBaja() As XDocument
        NombreArchivo = "RA-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"

        Dim MyTextoXML As New XDocument
        MyTextoXML = <?xml version="1.0" encoding="ISO-8859-1" standalone="no"?>
                     <VoidedDocuments
                         xmlns="urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1"
                         xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                         xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                         xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                         xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                         xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1"
                         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.0</cbc:UBLVersionID>
                         <cbc:CustomizationID>1.0</cbc:CustomizationID>
                         <cbc:ID><%= NombreArchivo %></cbc:ID>
                         <cbc:ReferenceDate><%= EvalDato(Now.Date, "FSEE") %></cbc:ReferenceDate>
                         <cbc:IssueDate><%= EvalDato(Now.Date, "FSEE") %></cbc:IssueDate>
                         <cac:Signature>
                             <cbc:ID>IDSignSP</cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID><%= MyRUC %></cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>#signatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <cac:AccountingSupplierParty>
                             <cbc:CustomerAssignedAccountID><%= MyRUC %></cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                     </VoidedDocuments>

        Dim sac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("sac")
        Dim cbc As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cbc")

        Dim sactxt As String = "xmlns:sac=" & """" & "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1" & """"
        Dim cbctxt As String = "xmlns:cbc=" & """" & "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" & """"
        Dim xlmhead As String = "<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "utf-8" & """" & "?>"

        For NEle As Byte = 0 To 4

            MyElementoXML = New XElement(sac + "VoidedDocumentsLine")
            MyElementoXML.Add(New XElement(cbc + "LineID", NEle + 1))
            MyElementoXML.Add(New XElement(cbc + "DocumentTypeCode", "01"))
            MyElementoXML.Add(New XElement(sac + "DocumentSerialID", "FF11"))
            MyElementoXML.Add(New XElement(sac + "DocumentNumberID", 5304 + NEle))
            MyElementoXML.Add(New XElement(sac + "VoidReasonDescription", "ANULACION DE LA FACTURA " & CStr(5304 + NEle)))
            MyTextoXML.Root.Add(MyElementoXML)
        Next

        NombreArchivo = MyRUC & "-" & NombreArchivo

        Call GuardarArchivoXML(MyTextoXML)

        Return MyTextoXML
    End Function

    Public Shared Function CrearResumenDiario() As XDocument

        Dim MyDocuments(4, 3)

        MyDocuments(0, 0) = 11025 : MyDocuments(0, 1) = 25917.09 : MyDocuments(0, 2) = 21963.64 : MyDocuments(0, 3) = 3953.45
        MyDocuments(1, 0) = 11026 : MyDocuments(1, 1) = 15485.18 : MyDocuments(1, 2) = 13123.04 : MyDocuments(1, 3) = 2362.14
        MyDocuments(2, 0) = 11028 : MyDocuments(2, 1) = 23836 : MyDocuments(2, 2) = 20200 : MyDocuments(2, 3) = 3636
        MyDocuments(3, 0) = 11050 : MyDocuments(3, 1) = 74167.72 : MyDocuments(3, 2) = 62854 : MyDocuments(3, 3) = 11313.72
        MyDocuments(4, 0) = 11087 : MyDocuments(4, 1) = 9494.99 : MyDocuments(4, 2) = 8046.6 : MyDocuments(4, 3) = 1448.39


        vMoneda = "PEN"

        NombreArchivo = "RC-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"

        Dim MyTextoXML As New XDocument
        MyTextoXML = <?xml version="1.0" encoding="ISO-8859-1" standalone="no"?>
                     <SummaryDocuments
                         xmlns="urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1"
                         xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                         xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                         xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                         xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                         xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1"
                         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                         xsi:schemaLocation="urn:sunat:names:specification:ubl:peru:schema:xsd:InvoiceSummary-1 D:\UBL_SUNAT\SUNAT_xml_20110112\20110112\xsd\maindoc\UBLPE-InvoiceSummary-1.0.xsd">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.0</cbc:UBLVersionID>
                         <cbc:CustomizationID>1.0</cbc:CustomizationID>
                         <cbc:ID><%= NombreArchivo %></cbc:ID>
                         <cbc:ReferenceDate><%= EvalDato(Now.Date, "FSEE") %></cbc:ReferenceDate>
                         <cbc:IssueDate><%= EvalDato(Now.Date, "FSEE") %></cbc:IssueDate>
                         <cac:Signature>
                             <cbc:ID>IDSignSP</cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID><%= MyRUC %></cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>#signatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <cac:AccountingSupplierParty>
                             <cbc:CustomerAssignedAccountID><%= MyRUC %></cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                     </SummaryDocuments>

        Dim cac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cac")
        Dim sac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("sac")
        Dim cbc As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cbc")

        Dim cactxt As String = "xmlns:cac=" & """" & "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" & """"
        Dim sactxt As String = "xmlns:sac=" & """" & "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1" & """"
        Dim cbctxt As String = "xmlns:cbc=" & """" & "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" & """"
        Dim xlmhead As String = "<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "utf-8" & """" & "?>"

        For NEle As Byte = 0 To 4

            MyElementoXML = New XElement(sac + "SummaryDocumentsLine")
            MyElementoXML.Add(New XElement(cbc + "LineID", NEle + 1))
            MyElementoXML.Add(New XElement(cbc + "DocumentTypeCode", "03"))
            MyElementoXML.Add(New XElement(sac + "DocumentSerialID", "BB11"))

            MyElementoXML.Add(New XElement(sac + "StartDocumentNumberID", MyDocuments(NEle, 0)))
            MyElementoXML.Add(New XElement(sac + "EndDocumentNumberID", MyDocuments(NEle, 0)))
            MyElementoXML.Add(New XElement(sac + "TotalAmount", New XAttribute("currencyID", vMoneda), MyDocuments(NEle, 1)))

            MyElementoXML.Add(New XElement(sac + "BillingPayment",
                                           New XElement(cbc + "PaidAmount", New XAttribute("currencyID", vMoneda), MyDocuments(NEle, 2)), _
                                           New XElement(cbc + "InstructionID", "01")))

            MyElementoXML.Add(New XElement(sac + "BillingPayment",
                                           New XElement(cbc + "PaidAmount", New XAttribute("currencyID", vMoneda), 0), _
                                           New XElement(cbc + "InstructionID", "02")))

            MyElementoXML.Add(New XElement(sac + "BillingPayment",
                                           New XElement(cbc + "PaidAmount", New XAttribute("currencyID", vMoneda), 0), _
                                           New XElement(cbc + "InstructionID", "03")))

            MyElementoXML.Add(New XElement(cac + "AllowanceCharge",
                                           New XElement(cbc + "ChargeIndicator", "true"), _
                                           New XElement(cbc + "Amount", New XAttribute("currencyID", vMoneda), 0)))

            MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                           New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), 0), _
                                           New XElement(cac + "TaxSubtotal", _
                                                        New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), 0), _
                                                        New XElement(cac + "TaxCategory", _
                                                                     New XElement(cac + "TaxScheme", _
                                                                                  New XElement(cbc + "ID", 2000), _
                                                                                  New XElement(cbc + "Name", "ISC"), _
                                                                                  New XElement(cbc + "TaxTypeCode", "EXC"))))))

            MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                           New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), MyDocuments(NEle, 3)), _
                                           New XElement(cac + "TaxSubtotal", _
                                                        New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), MyDocuments(NEle, 3)), _
                                                        New XElement(cac + "TaxCategory", _
                                                                     New XElement(cac + "TaxScheme", _
                                                                                  New XElement(cbc + "ID", 1000), _
                                                                                  New XElement(cbc + "Name", "IGV"), _
                                                                                  New XElement(cbc + "TaxTypeCode", "VAT"))))))



            MyTextoXML.Root.Add(MyElementoXML)
        Next

        NombreArchivo = MyRUC & "-" & NombreArchivo

        Call GuardarArchivoXML(MyTextoXML)

        Return MyTextoXML
    End Function

    Private Shared Sub GuardarArchivoXML(XML_Guardar As Linq.XDocument)
        Dim MyWriteSettings As New XmlWriterSettings
        Dim ArchivoTXTPath As String = MyTempPath & "\" & NombreArchivo & ".xml"
        Dim MyWrite = XmlWriter.Create(ArchivoTXTPath, MyWriteSettings)

        XML_Guardar.Save(MyWrite)
        MyWrite.Flush()
        MyWrite.Close()

    End Sub

    Public Shared Function ValidarDocumento() As Boolean
        Return ValidarArchivoXML()
    End Function

    Private Shared Function ValidarArchivoXML() As Boolean
        Dim MyReadSettings As New XmlReaderSettings
        Dim MySchemas As New XmlSchemaSet
        Dim MyValidator As XmlReader
        Success = True
        MyReadSettings.ValidationType = ValidationType.Schema

        MySchemas.Add(Nothing, MyTempPath & "\maindoc\UBL-Invoice-2.1.xsd")

        'If MyVenta.comprobante_tipo = "01" Then MySchemas.Add(Nothing, MyTempPath & "\maindoc\UBL-Invoice-2.0.xsd")
        'If MyVenta.comprobante_tipo = "07" Then MySchemas.Add(Nothing, MyTempPath & "\maindoc\UBL-CreditNote-2.0.xsd")

        'Utilizando formato URI completo
        'If MyVenta.comprobante_tipo = "01" Then MySchemas.Add(Nothing, "file:///C:/Temp/maindoc/UBL-Invoice-2.0.xsd")
        'If MyVenta.comprobante_tipo = "07" Then MySchemas.Add(Nothing, "file:///C:/Temp/maindoc/UBL-CreditNote-2.0.xsd")


        MyReadSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings

        AddHandler MyReadSettings.ValidationEventHandler, AddressOf ValidationEventHandler

        MyValidator = XmlReader.Create(MyTempPath & "\" & NombreArchivo & ".xml", MyReadSettings)

        'Revisar por qué ya no valida adecuadamente
        'While MyValidator.Read() : End While

        MyValidator.Close()

        Return Success
    End Function

    Private Shared Function VerificarRUC(ByVal xNum As String) As Boolean
        Dim li_suma As Integer
        Dim li_residuo As Integer
        Dim li_diferencia As Integer
        Dim li_compara As Integer

        li_suma = (CInt(Mid(xNum, 1, 1)) * 5) + (CInt(Mid(xNum, 2, 1)) * 4) + (CInt(Mid(xNum, 3, 1)) * 3) + (CInt(Mid(xNum, 4, 1)) * 2) + (CInt(Mid(xNum, 5, 1)) * 7) + (CInt(Mid(xNum, 6, 1)) * 6) + (CInt(Mid(xNum, 7, 1)) * 5) + (CInt(Mid(xNum, 8, 1)) * 4) + (CInt(Mid(xNum, 9, 1)) * 3) + (CInt(Mid(xNum, 10, 1)) * 2)
        li_compara = CInt(Mid(xNum, 11, 1))
        li_residuo = li_suma Mod 11
        li_diferencia = Int(11 - li_residuo)

        If li_diferencia > 9 Then li_diferencia = li_diferencia - 10

        VerificarRUC = IIf(li_diferencia <> li_compara, False, True)
    End Function

#Region "2.1"

    Private Shared Function CrearFactura2_1() As XDocument

        Dim MyTextoXML As XDocument
        Dim MyTextCorp As XElement

        If MyVenta.condicion_pago = "TG" Then
            MyTextCorp = <Invoice
                             xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
                             xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                             xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                             xmlns:ccts="urn:oasis:names:specification:ubl:schema:xsd:CoreComponentParameters-2"
                             xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                             xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                             xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                             xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1"
                             xmlns:stat="urn:oasis:names:specification:ubl:schema:xsd:DocumentStatusCode-1.0"
                             xmlns:udt="urn:un:unece:uncefact:data:draft:UnqualifiedDataTypesSchemaModule:2">
                             <ext:UBLExtensions>
                                 <ext:UBLExtension>
                                     <ext:ExtensionContent>

                                     </ext:ExtensionContent>
                                 </ext:UBLExtension>
                             </ext:UBLExtensions>
                             <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
                             <cbc:CustomizationID>2.0</cbc:CustomizationID>
                             <cbc:ID><%= "F" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                             <cbc:IssueDate><%= EvalDato(MyVenta.comprobante_fecha, "FSEE") %></cbc:IssueDate>
                             <cbc:IssueTime><%= MyVenta.fecha_registro.TimeOfDay.ToString.Substring(0, 8) %></cbc:IssueTime>
                             <cbc:DueDate><%= EvalDato(MyVenta.comprobante_vencimiento, "FSEE") %></cbc:DueDate>
                             <cbc:InvoiceTypeCode listAgencyName="PE:SUNAT" listID="0101" listName="Tipo de Documento" listSchemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01" name="Tipo de Operacion">01</cbc:InvoiceTypeCode>
                             <cbc:Note languageLocaleID="1000"><%= SEE1002 %></cbc:Note>
                             <cbc:DocumentCurrencyCode listAgencyName="United Nations Economic Commission for Europe" listID="ISO 4217 Alpha" listName="Currency"><%= vMoneda %></cbc:DocumentCurrencyCode>
                             <cac:Signature>
                                 <cbc:ID><%= "F" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                                 <cac:SignatoryParty>
                                     <cac:PartyIdentification>
                                         <cbc:ID><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                 </cac:SignatoryParty>
                                 <cac:DigitalSignatureAttachment>
                                     <cac:ExternalReference>
                                         <cbc:URI>SignatureSP</cbc:URI>
                                     </cac:ExternalReference>
                                 </cac:DigitalSignatureAttachment>
                             </cac:Signature>
                             <!-- Datos del emisor (Empresa que vende) -->
                             <cac:AccountingSupplierParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <!-- Ruc del Emisor -->
                                         <!-- Tipo documento: @schemeID = 6 (RUC - Catálogo 06) -->
                                         <cbc:ID
                                             schemeID="6"
                                             schemeAgencyName="PE:SUNAT"
                                             schemeName="Documento de Identidad"
                                             schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <!-- Nombre comercial del Emisor -->
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                     <cac:PartyLegalEntity>
                                         <!-- Razon social del Emisor -->
                                         <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                         <cac:RegistrationAddress>
                                             <!-- Código asignado por la SUNAT para el establecimiento anexo declarado en el RUC, 0000 si no tiene -->
                                             <cbc:AddressTypeCode
                                                 listAgencyName="PE:SUNAT"
                                                 listName="Establecimientos anexos">0000</cbc:AddressTypeCode>
                                             <cbc:BuildingNumber/>
                                             <!-- Urbanización -->
                                             <cbc:CitySubdivisionName>-</cbc:CitySubdivisionName>
                                             <!-- Provincia -->
                                             <cbc:CityName><%= MyDomicilioProvincia %></cbc:CityName>
                                             <!-- Departamento -->
                                             <cbc:CountrySubentity><%= MyDomicilioDepartamento %></cbc:CountrySubentity>
                                             <!-- Ubigeo -->
                                             <cbc:CountrySubentityCode><%= MyDomicilioUbigeo %></cbc:CountrySubentityCode>
                                             <!-- Distrito -->
                                             <cbc:District><%= MyDomicilioDistrito %></cbc:District>
                                             <cac:AddressLine>
                                                 <!-- Dirección completa detallada -->
                                                 <cbc:Line><%= MyDomicilioFiscal %></cbc:Line>
                                             </cac:AddressLine>
                                             <cac:Country>
                                                 <!-- Codigo del pais -->
                                                 <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                             </cac:Country>
                                         </cac:RegistrationAddress>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingSupplierParty>
                             <cac:AccountingCustomerParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeAgencyName="PE:SUNAT" schemeID=<%= MyClienteTipo %> schemeName="Documento de Identidad" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyClienteRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyClienteNombre.Trim %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingCustomerParty>
                             <cac:SellerSupplierParty>
                                 <cac:Party>
                                     <cac:PostalAddress>
                                         <cbc:ID>150120</cbc:ID>
                                         <cbc:CitySubdivisionName/>
                                         <cbc:CityName>LIMA</cbc:CityName>
                                         <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                         <cbc:District><%= MyDistrito %></cbc:District>
                                         <cac:AddressLine>
                                             <cbc:Line><%= MyDomicilioFiscal %></cbc:Line>
                                         </cac:AddressLine>
                                         <cac:Country>
                                             <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                         </cac:Country>
                                     </cac:PostalAddress>
                                 </cac:Party>
                             </cac:SellerSupplierParty>
                             <!-- Forma de Pago -->
                             <cac:PaymentTerms>
                                 <cbc:ID>FormaPago</cbc:ID>
                                 <cbc:PaymentMeansID>Contado</cbc:PaymentMeansID>
                             </cac:PaymentTerms>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxableAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:TaxableAmount>
                                     <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:ID schemeAgencyName="United Nations Economic Commission for Europe" schemeID="UN/ECE 5305" schemeName="Tax Category Identifier">O</cbc:ID>
                                         <cac:TaxScheme>
                                             <cbc:ID schemeAgencyName="PE:SUNAT" schemeID="UN/ECE 5153" schemeName="Codigo de tributos">9996</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:LegalMonetaryTotal>
                                 <cbc:LineExtensionAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:LineExtensionAmount>
                                 <cbc:AllowanceTotalAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteDescuentoGlobal, "DSEE") %></cbc:AllowanceTotalAmount>
                                 <cbc:ChargeTotalAmount currencyID=<%= vMoneda %>>0.00</cbc:ChargeTotalAmount>
                                 <cbc:PayableAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:PayableAmount>
                             </cac:LegalMonetaryTotal>
                         </Invoice>

        Else
            MyTextCorp = <Invoice
                             xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
                             xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                             xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                             xmlns:ccts="urn:oasis:names:specification:ubl:schema:xsd:CoreComponentParameters-2"
                             xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                             xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                             xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                             xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1"
                             xmlns:stat="urn:oasis:names:specification:ubl:schema:xsd:DocumentStatusCode-1.0"
                             xmlns:udt="urn:un:unece:uncefact:data:draft:UnqualifiedDataTypesSchemaModule:2">
                             <ext:UBLExtensions>
                                 <ext:UBLExtension>
                                     <ext:ExtensionContent>

                                     </ext:ExtensionContent>
                                 </ext:UBLExtension>
                             </ext:UBLExtensions>
                             <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
                             <cbc:CustomizationID>2.0</cbc:CustomizationID>
                             <cbc:ID><%= "F" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                             <cbc:IssueDate><%= EvalDato(MyVenta.comprobante_fecha, "FSEE") %></cbc:IssueDate>
                             <cbc:IssueTime><%= MyVenta.fecha_registro.TimeOfDay.ToString.Substring(0, 8) %></cbc:IssueTime>
                             <cbc:DueDate><%= EvalDato(MyVenta.comprobante_vencimiento, "FSEE") %></cbc:DueDate>
                             <cbc:InvoiceTypeCode listAgencyName="PE:SUNAT" listID="0101" listName="Tipo de Documento" listSchemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01" name="Tipo de Operacion">01</cbc:InvoiceTypeCode>
                             <cbc:Note languageLocaleID="1000"><%= IIf(MyVenta.condicion_pago = "TG", SEE1002, SEE1000) %></cbc:Note>
                             <cbc:DocumentCurrencyCode listAgencyName="United Nations Economic Commission for Europe" listID="ISO 4217 Alpha" listName="Currency"><%= vMoneda %></cbc:DocumentCurrencyCode>
                             <cac:Signature>
                                 <cbc:ID><%= "F" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                                 <cac:SignatoryParty>
                                     <cac:PartyIdentification>
                                         <cbc:ID><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                 </cac:SignatoryParty>
                                 <cac:DigitalSignatureAttachment>
                                     <cac:ExternalReference>
                                         <cbc:URI>SignatureSP</cbc:URI>
                                     </cac:ExternalReference>
                                 </cac:DigitalSignatureAttachment>
                             </cac:Signature>
                             <cac:AccountingSupplierParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeAgencyName="PE:SUNAT" schemeID="6" schemeName="Documento de Identidad" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                         <cac:RegistrationAddress>
                                             <cbc:AddressTypeCode listAgencyName="PE:SUNAT" listName="Establecimientos anexos">0</cbc:AddressTypeCode>
                                             <cbc:BuildingNumber/>
                                             <cbc:CitySubdivisionName>-</cbc:CitySubdivisionName>
                                             <cbc:CityName>LIMA</cbc:CityName>
                                             <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                             <cbc:CountrySubentityCode>150120</cbc:CountrySubentityCode>
                                             <cbc:District><%= MyDistrito %></cbc:District>
                                             <cac:AddressLine>
                                                 <cbc:Line><%= MyDomicilioFiscal %></cbc:Line>
                                             </cac:AddressLine>
                                             <cac:Country>
                                                 <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                             </cac:Country>
                                         </cac:RegistrationAddress>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingSupplierParty>
                             <cac:AccountingCustomerParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeAgencyName="PE:SUNAT" schemeID=<%= MyClienteTipo %> schemeName="Documento de Identidad" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyClienteRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyClienteNombre.Trim %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingCustomerParty>
                             <cac:SellerSupplierParty>
                                 <cac:Party>
                                     <cac:PostalAddress>
                                         <cbc:ID>150120</cbc:ID>
                                         <cbc:CitySubdivisionName/>
                                         <cbc:CityName>LIMA</cbc:CityName>
                                         <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                         <cbc:District><%= MyDistrito %></cbc:District>
                                         <cac:AddressLine>
                                             <cbc:Line><%= MyDomicilioFiscal %></cbc:Line>
                                         </cac:AddressLine>
                                         <cac:Country>
                                             <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                         </cac:Country>
                                     </cac:PostalAddress>
                                 </cac:Party>
                             </cac:SellerSupplierParty>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxableAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:TaxableAmount>
                                     <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:ID schemeAgencyName="United Nations Economic Commission for Europe" schemeID="UN/ECE 5305" schemeName="Tax Category Identifier">S</cbc:ID>
                                         <cac:TaxScheme>
                                             <cbc:ID schemeAgencyName="PE:SUNAT" schemeID="UN/ECE 5153" schemeName="Codigo de tributos">1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:LegalMonetaryTotal>
                                 <cbc:LineExtensionAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:LineExtensionAmount>
                                 <cbc:AllowanceTotalAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteDescuentoGlobal, "DSEE") %></cbc:AllowanceTotalAmount>
                                 <cbc:ChargeTotalAmount currencyID=<%= vMoneda %>>0.00</cbc:ChargeTotalAmount>
                                 <cbc:PayableAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:PayableAmount>
                             </cac:LegalMonetaryTotal>
                         </Invoice>
        End If

        MyTextoXML = New XDocument(New XDeclaration("1.0", "ISO-8859-1", "no"), MyTextCorp)

        If MyFacturaDetalles.Rows.Count <> 0 Then
            Dim cac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cac")
            Dim cbc As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cbc")

            dBaseImponibleGravada = 0 : dImporteExonerado = 0 : dImporteInafecto = 0 : dValorExportacion = 0 : dIGV = 0
            dValorVenta = 0 : dImporteTotal = 0

            For NEle As Byte = 0 To MyFacturaDetalles.Rows.Count - 1
                With MyFacturaDetalles(NEle)
                    dBaseImponibleGravada = .BASE_IMPONIBLE_GRAVADA_ORIGEN
                    'dImporteExonerado = .importe_exonerado_ORIGEN
                    'dImporteInafecto = .importe_inafecto_ORIGEN
                    'dValorExportacion = .VALOR_EXPORTACION_ORIGEN
                    dIGV = .IGV_ORIGEN
                    'dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .importe_exonerado_ORIGEN + .importe_inafecto_ORIGEN + .VALOR_EXPORTACION_ORIGEN
                    dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .IMPORTE_EXONERADO_ORIGEN + .IMPORTE_INAFECTO_ORIGEN
                    dImporteTotal = .IMPORTE_TOTAL_ORIGEN

                    If MyVenta.condicion_pago = "TG" Then
                        dBaseImponibleGravada = 0
                        dIGV = 0
                        'dValorVenta = 0
                    End If

                    MyElementoXML = New XElement(cac + "InvoiceLine")
                    MyElementoXML.Add(New XElement(cbc + "ID", NEle + 1))
                    MyElementoXML.Add(New XElement(cbc + "InvoicedQuantity", New XAttribute("unitCode", "NIU"), New XAttribute("unitCodeListAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("unitCodeListID", "UN/ECE rec 20"), .CANTIDAD))
                    MyElementoXML.Add(New XElement(cbc + "LineExtensionAmount", New XAttribute("currencyID", vMoneda), EvalDato(dValorVenta, "DSEE")))
                    MyElementoXML.Add(New XElement(cbc + "FreeOfChargeIndicator", False))

                    If MyVenta.condicion_pago = "TG" Then
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(dBaseImponibleGravada, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "02"))))

                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "O"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), "36"), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "PE:SUNAT"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Codigo de tributos"), "9996"), _
                                                                                              New XElement(cbc + "Name", "GRA"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "FRE"))))))

                    Else
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(dImporteTotal, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "01"))))

                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(dValorVenta, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "S"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), vTipoAfectacion), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "PE:SUNAT"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Codigo de tributos"), "1000"), _
                                                                                              New XElement(cbc + "Name", "IGV"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "VAT"))))))

                    End If

                    MyElementoXML.Add(New XElement(cac + "Item", _
                                                   IIf(.GLOSA_1.Trim.Length = 0, "", New XElement(cbc + "Description", New XCData(Strings.Left(.GLOSA_1, 250)))), _
                                                   New XElement(cac + "SellersItemIdentification", New XElement(cbc + "ID", New XCData(.CODIGO)))))
                    MyElementoXML.Add(New XElement(cac + "Price", New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(IIf(MyVenta.condicion_pago = "TG", 0, dValorVenta), "DSEE"))))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cac", cac))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cbc", cbc))
                    MyTextoXML.Root.Add(MyElementoXML)

                End With
            Next
        End If
        Return MyTextoXML
    End Function

    Private Shared Function CrearBoleta2_1() As XDocument

        Dim MyTextoXML As XDocument
        Dim MyTextCorp As XElement

        If MyVenta.condicion_pago = "TG" Then
            MyTextCorp = <Invoice
                             xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
                             xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                             xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                             xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                             xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                             xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                             xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"
                             xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                             <ext:UBLExtensions>
                                 <ext:UBLExtension>
                                     <ext:ExtensionContent>

                                     </ext:ExtensionContent>
                                 </ext:UBLExtension>
                             </ext:UBLExtensions>
                             <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
                             <cbc:CustomizationID>2.0</cbc:CustomizationID>
                             <cbc:ProfileID schemeName="SUNAT:Identificador de Tipo de Operación" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17">0101</cbc:ProfileID>
                             <cbc:ID><%= "B" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                             <cbc:IssueDate><%= EvalDato(MyVenta.comprobante_fecha, "FSEE") %></cbc:IssueDate>
                             <cbc:IssueTime><%= MyVenta.fecha_registro.TimeOfDay.ToString.Substring(0, 8) %></cbc:IssueTime>
                             <cbc:InvoiceTypeCode listID=<%= MyCodigoTipoOperacion %> listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">03</cbc:InvoiceTypeCode>
                             <cbc:Note languageLocaleID="1000"><%= SEE1002 %></cbc:Note>
                             <cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName=" United Europe"><%= vMoneda %></cbc:DocumentCurrencyCode>
                             <cac:Signature>
                                 <cbc:ID><%= "B" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                                 <cac:SignatoryParty>
                                     <cac:PartyIdentification>
                                         <cbc:ID><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                 </cac:SignatoryParty>
                                 <cac:DigitalSignatureAttachment>
                                     <cac:ExternalReference>
                                         <cbc:URI>SignatureSP</cbc:URI>
                                     </cac:ExternalReference>
                                 </cac:DigitalSignatureAttachment>
                             </cac:Signature>
                             <cac:AccountingSupplierParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingSupplierParty>
                             <cac:AccountingCustomerParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeID=<%= MyClienteTipo %> schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyClienteRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyClienteNombre.Trim %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingCustomerParty>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxableAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:TaxableAmount>
                                     <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:ID schemeAgencyName="United Nations Economic Commission for Europe" schemeID="UN/ECE 5305" schemeName="Tax Category Identifier">O</cbc:ID>
                                         <cac:TaxScheme>
                                             <cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">9996</cbc:ID>
                                             <cbc:Name>GRA</cbc:Name>
                                             <cbc:TaxTypeCode>FRE</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:LegalMonetaryTotal>
                                 <cbc:LineExtensionAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:LineExtensionAmount>
                                 <cbc:TaxInclusiveAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:TaxInclusiveAmount>
                                 <cbc:AllowanceTotalAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteDescuentoGlobal, "DSEE") %></cbc:AllowanceTotalAmount>
                                 <cbc:PayableAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:PayableAmount>
                             </cac:LegalMonetaryTotal>
                         </Invoice>
        Else

            MyTextCorp = <Invoice
                             xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
                             xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                             xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                             xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                             xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                             xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                             xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"
                             xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                             <ext:UBLExtensions>
                                 <ext:UBLExtension>
                                     <ext:ExtensionContent>

                                     </ext:ExtensionContent>
                                 </ext:UBLExtension>
                             </ext:UBLExtensions>
                             <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
                             <cbc:CustomizationID>2.0</cbc:CustomizationID>
                             <cbc:ProfileID schemeName="SUNAT:Identificador de Tipo de Operación" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17">0101</cbc:ProfileID>
                             <cbc:ID><%= "B" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                             <cbc:IssueDate><%= EvalDato(MyVenta.comprobante_fecha, "FSEE") %></cbc:IssueDate>
                             <cbc:IssueTime><%= MyVenta.fecha_registro.TimeOfDay.ToString.Substring(0, 8) %></cbc:IssueTime>
                             <cbc:InvoiceTypeCode listID=<%= MyCodigoTipoOperacion %> listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">03</cbc:InvoiceTypeCode>
                             <cbc:Note languageLocaleID="1000"><%= SEE1000 %></cbc:Note>
                             <cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName=" United Europe"><%= vMoneda %></cbc:DocumentCurrencyCode>
                             <cac:Signature>
                                 <cbc:ID><%= "B" & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                                 <cac:SignatoryParty>
                                     <cac:PartyIdentification>
                                         <cbc:ID><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                 </cac:SignatoryParty>
                                 <cac:DigitalSignatureAttachment>
                                     <cac:ExternalReference>
                                         <cbc:URI>SignatureSP</cbc:URI>
                                     </cac:ExternalReference>
                                 </cac:DigitalSignatureAttachment>
                             </cac:Signature>
                             <cac:AccountingSupplierParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyName>
                                         <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                     </cac:PartyName>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingSupplierParty>
                             <cac:AccountingCustomerParty>
                                 <cac:Party>
                                     <cac:PartyIdentification>
                                         <cbc:ID schemeID=<%= MyClienteTipo %> schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyClienteRUC %></cbc:ID>
                                     </cac:PartyIdentification>
                                     <cac:PartyLegalEntity>
                                         <cbc:RegistrationName><%= MyClienteNombre.Trim %></cbc:RegistrationName>
                                     </cac:PartyLegalEntity>
                                 </cac:Party>
                             </cac:AccountingCustomerParty>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxableAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:TaxableAmount>
                                     <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:ID schemeAgencyName="United Nations Economic Commission for Europe" schemeID="UN/ECE 5305" schemeName="Tax Category Identifier">S</cbc:ID>
                                         <cac:TaxScheme>
                                             <cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:LegalMonetaryTotal>
                                 <cbc:LineExtensionAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:LineExtensionAmount>
                                 <cbc:TaxInclusiveAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:TaxInclusiveAmount>
                                 <cbc:AllowanceTotalAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteDescuentoGlobal, "DSEE") %></cbc:AllowanceTotalAmount>
                                 <cbc:PayableAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:PayableAmount>
                             </cac:LegalMonetaryTotal>
                         </Invoice>
        End If

        MyTextoXML = New XDocument(New XDeclaration("1.0", "ISO-8859-1", "no"), MyTextCorp)

        If MyFacturaDetalles.Rows.Count <> 0 Then
            Dim cac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cac")
            Dim cbc As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cbc")

            dBaseImponibleGravada = 0 : dImporteExonerado = 0 : dImporteInafecto = 0 : dValorExportacion = 0 : dIGV = 0
            dValorVenta = 0 : dImporteTotal = 0

            For NEle As Byte = 0 To MyFacturaDetalles.Rows.Count - 1
                With MyFacturaDetalles(NEle)
                    dBaseImponibleGravada = .BASE_IMPONIBLE_GRAVADA_ORIGEN
                    'dImporteExonerado = .importe_exonerado_ORIGEN
                    'dImporteInafecto = .importe_inafecto_ORIGEN
                    'dValorExportacion = .VALOR_EXPORTACION_ORIGEN
                    dIGV = .IGV_ORIGEN
                    'dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .importe_exonerado_ORIGEN + .importe_inafecto_ORIGEN + .VALOR_EXPORTACION_ORIGEN
                    dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .IMPORTE_EXONERADO_ORIGEN + .IMPORTE_INAFECTO_ORIGEN
                    dImporteTotal = .IMPORTE_TOTAL_ORIGEN
                    If MyVenta.condicion_pago = "TG" Then
                        dBaseImponibleGravada = 0
                        dIGV = 0
                        'dValorVenta = 0
                    End If

                    MyElementoXML = New XElement(cac + "InvoiceLine")
                    MyElementoXML.Add(New XElement(cbc + "ID", NEle + 1))
                    MyElementoXML.Add(New XElement(cbc + "InvoicedQuantity", New XAttribute("unitCode", "NIU"), New XAttribute("unitCodeListAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("unitCodeListID", "UN/ECE rec 20"), .CANTIDAD))
                    MyElementoXML.Add(New XElement(cbc + "LineExtensionAmount", New XAttribute("currencyID", vMoneda), EvalDato(IIf(MyVenta.condicion_pago = "TG", 0, dValorVenta), "DSEE")))
                    If MyVenta.condicion_pago = "TG" Then
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "02"))))
                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "O"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), "36"), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Tax Scheme Identifier"), "9996"), _
                                                                                              New XElement(cbc + "Name", "GRA"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "FRE"))))))
                    Else
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(dImporteTotal, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "01"))))
                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(dBaseImponibleGravada, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "S"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), vTipoAfectacion), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Tax Scheme Identifier"), "1000"), _
                                                                                              New XElement(cbc + "Name", "IGV"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "VAT"))))))
                    End If

                    MyElementoXML.Add(New XElement(cac + "Item", _
                                                   IIf(.GLOSA_1.Trim.Length = 0, "", New XElement(cbc + "Description", New XCData(.GLOSA_1))), _
                                                   New XElement(cac + "SellersItemIdentification", New XElement(cbc + "ID", New XCData(.CODIGO)))))
                    MyElementoXML.Add(New XElement(cac + "Price", New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(IIf(MyVenta.condicion_pago = "TG", 0, dValorVenta), "DSEE"))))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cac", cac))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cbc", cbc))

                    MyTextoXML.Root.Add(MyElementoXML)
                End With
            Next
        End If
        Return MyTextoXML
    End Function

    Private Shared Function CrearNotaCredito2_1() As XDocument

        Dim MyTextoXML As XDocument
        Dim MyTextCorp As XElement
        Dim TipoNotaCredito As String
        Dim TipoNotaCreditoDesripcion As String

        If MyVenta.tipo_operacion = "C1" Then
            TipoNotaCredito = "07"
        Else
            TipoNotaCredito = "10"
        End If

        TipoNotaCreditoDesripcion = dalTablaDetalle.ObtenerMotivoNotaCredito("000", TipoNotaCredito)
        MyTextCorp = <CreditNote
                         xmlns="urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2"
                         xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                         xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                         xmlns:ccts="urn:un:unece:uncefact:documentation:2"
                         xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                         xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                         xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                         xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1"
                         xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"
                         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>

                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
                         <cbc:CustomizationID>2.0</cbc:CustomizationID>
                         <cbc:ID><%= IIf(MyVenta.referencia_tipo = "03", "B", "F") & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                         <cbc:IssueDate><%= EvalDato(MyVenta.comprobante_fecha, "FSEE") %></cbc:IssueDate>
                         <cbc:IssueTime><%= MyVenta.fecha_registro.TimeOfDay.ToString.Substring(0, 8) %></cbc:IssueTime>
                         <cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName=" United Europe"><%= vMoneda %></cbc:DocumentCurrencyCode>
                         <cac:DiscrepancyResponse>
                             <cbc:ReferenceID><%= IIf(MyVenta.referencia_tipo = "03", "B", "F") & Strings.Right(MyVenta.referencia_serie, 3) & "-" & Strings.Right(MyVenta.referencia_numero.Trim, 8) %></cbc:ReferenceID>
                             <cbc:ResponseCode><%= TipoNotaCredito %></cbc:ResponseCode>
                             <cbc:Description><%= TipoNotaCreditoDesripcion %></cbc:Description>
                         </cac:DiscrepancyResponse>
                         <cac:BillingReference>
                             <cac:InvoiceDocumentReference>
                                 <cbc:ID><%= IIf(MyVenta.referencia_tipo = "03", "B", "F") & Strings.Right(MyVenta.referencia_serie, 3) & "-" & Strings.Right(MyVenta.referencia_numero.Trim, 8) %></cbc:ID>
                                 <cbc:DocumentTypeCode><%= MyVenta.referencia_tipo %></cbc:DocumentTypeCode>
                             </cac:InvoiceDocumentReference>
                         </cac:BillingReference>
                         <cac:Signature>
                             <cbc:ID><%= IIf(MyVenta.referencia_tipo = "03", "B", "F") & Strings.Right(MyVenta.comprobante_serie, 3) & "-" & MyVenta.comprobante_numero.Substring(2, 8) %></cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID><%= MyRUC %></cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>SignatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <!-- Datos del emisor (Empresa que vende) -->
                         <cac:AccountingSupplierParty>
                             <cac:Party>
                                 <cac:PartyIdentification>
                                     <!-- Ruc del Emisor -->
                                     <!-- Tipo documento: @schemeID = 6 (RUC - Catálogo 06) -->
                                     <cbc:ID
                                         schemeID="6"
                                         schemeName="Documento de Identidad"
                                         schemeAgencyName="PE:SUNAT"
                                         schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyRUC %></cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <!-- Nombre comercial del Emisor -->
                                     <cbc:Name><%= MyRazonSocial %></cbc:Name>
                                 </cac:PartyName>
                                 <cac:PartyLegalEntity>
                                     <!-- Razon social del Emisor -->
                                     <cbc:RegistrationName><%= MyRazonSocial %></cbc:RegistrationName>
                                     <cac:RegistrationAddress>
                                         <!-- Código asignado por la SUNAT para el establecimiento anexo declarado en el RUC, 0000 si no tiene -->
                                         <cbc:AddressTypeCode
                                             listAgencyName="PE:SUNAT"
                                             listName="Establecimientos anexos">0000</cbc:AddressTypeCode>
                                         <cbc:BuildingNumber/>
                                         <!-- Urbanización -->
                                         <cbc:CitySubdivisionName>-</cbc:CitySubdivisionName>
                                         <!-- Provincia -->
                                         <cbc:CityName><%= MyDomicilioProvincia %></cbc:CityName>
                                         <!-- Departamento -->
                                         <cbc:CountrySubentity><%= MyDomicilioDepartamento %></cbc:CountrySubentity>
                                         <!-- Ubigeo -->
                                         <cbc:CountrySubentityCode><%= MyDomicilioUbigeo %></cbc:CountrySubentityCode>
                                         <!-- Distrito -->
                                         <cbc:District><%= MyDomicilioDistrito %></cbc:District>
                                         <cac:AddressLine>
                                             <!-- Dirección completa detallada -->
                                             <cbc:Line><%= MyDomicilioFiscal %></cbc:Line>
                                         </cac:AddressLine>
                                         <cac:Country>
                                             <!-- Codigo del pais -->
                                             <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                         </cac:Country>
                                     </cac:RegistrationAddress>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                         <cac:AccountingCustomerParty>
                             <cac:Party>
                                 <cac:PartyIdentification>
                                     <cbc:ID schemeID=<%= MyClienteTipo %> schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"><%= MyClienteRUC %></cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName><%= MyClienteNombre.Trim %></cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingCustomerParty>
                         <!-- Forma de Pago -->
                         <cac:PaymentTerms>
                             <cbc:ID>FormaPago</cbc:ID>
                             <cbc:PaymentMeansID>Contado</cbc:PaymentMeansID>
                         </cac:PaymentTerms>
                         <cac:TaxTotal>
                             <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                             <cac:TaxSubtotal>
                                 <cbc:TaxableAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:TaxableAmount>
                                 <cbc:TaxAmount currencyID=<%= vMoneda %>><%= EvalDato(vIGV, "DSEE") %></cbc:TaxAmount>
                                 <cac:TaxCategory>
                                     <cbc:ID schemeAgencyName="United Nations Economic Commission for Europe" schemeID="UN/ECE 5305" schemeName="Tax Category Identifier">S</cbc:ID>
                                     <cac:TaxScheme>
                                         <cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">1000</cbc:ID>
                                         <cbc:Name>IGV</cbc:Name>
                                         <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                     </cac:TaxScheme>
                                 </cac:TaxCategory>
                             </cac:TaxSubtotal>
                         </cac:TaxTotal>
                         <cac:LegalMonetaryTotal>
                             <cbc:LineExtensionAmount currencyID=<%= vMoneda %>><%= EvalDato(vValorVenta, "DSEE") %></cbc:LineExtensionAmount>
                             <cbc:TaxInclusiveAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:TaxInclusiveAmount>
                             <cbc:AllowanceTotalAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteDescuentoGlobal, "DSEE") %></cbc:AllowanceTotalAmount>
                             <cbc:PayableAmount currencyID=<%= vMoneda %>><%= EvalDato(vImporteTotal, "DSEE") %></cbc:PayableAmount>
                         </cac:LegalMonetaryTotal>
                     </CreditNote>

        MyTextoXML = New XDocument(New XDeclaration("1.0", "ISO-8859-1", "no"), MyTextCorp)
        If MyFacturaDetalles.Rows.Count <> 0 Then
            Dim cac As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cac")
            Dim cbc As XNamespace = MyTextoXML.Root.GetNamespaceOfPrefix("cbc")
            dBaseImponibleGravada = 0 : dImporteExonerado = 0 : dImporteInafecto = 0 : dValorExportacion = 0 : dIGV = 0
            dValorVenta = 0 : dImporteTotal = 0

            For NEle As Byte = 0 To MyFacturaDetalles.Rows.Count - 1
                With MyFacturaDetalles(NEle)
                    dBaseImponibleGravada = .BASE_IMPONIBLE_GRAVADA_ORIGEN
                    'dImporteExonerado = .importe_exonerado_ORIGEN
                    'dImporteInafecto = .importe_inafecto_ORIGEN
                    'dValorExportacion = .VALOR_EXPORTACION_ORIGEN
                    dIGV = .IGV_ORIGEN
                    'dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .importe_exonerado_ORIGEN + .importe_inafecto_ORIGEN + .VALOR_EXPORTACION_ORIGEN
                    dValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .IMPORTE_EXONERADO_ORIGEN + .IMPORTE_INAFECTO_ORIGEN + .VALOR_EXPORTACION_ORIGEN
                    dImporteTotal = .IMPORTE_TOTAL_ORIGEN

                    If MyVenta.condicion_pago = "TG" Then
                        dBaseImponibleGravada = 0
                        dIGV = 0
                        dValorVenta = 0
                    End If

                    MyElementoXML = New XElement(cac + "CreditNoteLine")
                    MyElementoXML.Add(New XElement(cbc + "ID", NEle + 1))
                    MyElementoXML.Add(New XElement(cbc + "CreditedQuantity", New XAttribute("unitCode", "NIU"), New XAttribute("unitCodeListAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("unitCodeListID", "UN/ECE rec 20"), .CANTIDAD))
                    MyElementoXML.Add(New XElement(cbc + "LineExtensionAmount", New XAttribute("currencyID", vMoneda), EvalDato(IIf(MyVenta.condicion_pago = "TG", 0, dValorVenta), "DSEE")))

                    If MyVenta.condicion_pago = "TG" Then
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "02"))))
                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(0, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "O"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), "36"), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Tax Scheme Identifier"), "9996"), _
                                                                                              New XElement(cbc + "Name", "GRA"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "FRE"))))))
                    Else
                        MyElementoXML.Add(New XElement(cac + "PricingReference", _
                                                       New XElement(cac + "AlternativeConditionPrice", _
                                                                    New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(dImporteTotal, "DSEE")), _
                                                                    New XElement(cbc + "PriceTypeCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Tipo de Precio"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"), "01"))))
                        MyElementoXML.Add(New XElement(cac + "TaxTotal", _
                                                       New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                       New XElement(cac + "TaxSubtotal", _
                                                                    New XElement(cbc + "TaxableAmount", New XAttribute("currencyID", vMoneda), EvalDato(dBaseImponibleGravada, "DSEE")), _
                                                                    New XElement(cbc + "TaxAmount", New XAttribute("currencyID", vMoneda), EvalDato(dIGV, "DSEE")), _
                                                                    New XElement(cac + "TaxCategory", _
                                                                                 New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5305"), New XAttribute("schemeName", "Tax Category Identifier"), "S"), _
                                                                                 New XElement(cbc + "Percent", EvalDato(MyIGV, "DSEE")), _
                                                                                 New XElement(cbc + "TaxExemptionReasonCode", New XAttribute("listAgencyName", "PE:SUNAT"), New XAttribute("listName", "Afectacion del IGV"), New XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07"), vTipoAfectacion), _
                                                                                 New XElement(cac + "TaxScheme", _
                                                                                              New XElement(cbc + "ID", New XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"), New XAttribute("schemeID", "UN/ECE 5153"), New XAttribute("schemeName", "Tax Scheme Identifier"), "1000"), _
                                                                                              New XElement(cbc + "Name", "IGV"), _
                                                                                              New XElement(cbc + "TaxTypeCode", "VAT"))))))
                    End If

                    MyElementoXML.Add(New XElement(cac + "Item", _
                                                   IIf(.GLOSA_1.Trim.Length = 0, "", New XElement(cbc + "Description", New XCData(.GLOSA_1))), _
                                                   New XElement(cac + "SellersItemIdentification", New XElement(cbc + "ID", New XCData(.CODIGO)))))
                    MyElementoXML.Add(New XElement(cac + "Price", New XElement(cbc + "PriceAmount", New XAttribute("currencyID", vMoneda), EvalDato(IIf(MyVenta.condicion_pago = "TG", 0, dValorVenta), "DSEE"))))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cac", cac))
                    MyElementoXML.Add(New XAttribute(XNamespace.Xmlns + "cbc", cbc))
                    MyTextoXML.Root.Add(MyElementoXML)
                End With
            Next
        End If
        Return MyTextoXML

    End Function

#End Region

#Region "Enviar Comprobante"

    Public Shared Function EvaluarExisteXML(ComprobanteTipo As String, ComprobanteSerie As String, ComprobanteNumero As String) As Boolean
        Dim NombreArchivo As String
        Dim NombreArchivoXML As String
        Dim ArchivoExiste As Boolean = False

        NombreArchivo = MyRUC & "-" & ComprobanteTipo & "-" & ComprobanteSerie & "-" & ComprobanteNumero.Substring(2, 8)
        NombreArchivoXML = NombreArchivo & ".xml"

        If File.Exists(MyTempPath & "\" & NombreArchivoXML) Then ArchivoExiste = True

        Return ArchivoExiste
    End Function

    Public Shared Function EnviarDocumento(ByRef Nombre_Archivo As String, Venta As entVenta) As String
        MyVenta = Venta
        NombreArchivo = MyRUC & "-" & MyVenta.comprobante_tipo & "-" & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero.Substring(2, 8)

        Dim MyMensaje = EnviarArchivoZip()

        Nombre_Archivo = NombreArchivo
        Return MyMensaje
    End Function

    Private Shared Function EnviarArchivoZip() As String
        Dim FileZip As String = NombreArchivo & ".zip"
        MyConexion = New clsConexionSunat

        Dim MyMensaje = MyConexion.EnviarDocumento(FileZip)

        Return MyMensaje
    End Function

    Public Shared Function EnviarComunicacionBaja() As Boolean
        NombreArchivo = "RA-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"
        NombreArchivo = MyRUC & "-" & NombreArchivo
        Call EnviarArchivoZipBaja()
        Return True
    End Function

    Public Shared Function EnviarResumenDiario() As Boolean
        NombreArchivo = "RC-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"
        NombreArchivo = MyRUC & "-" & NombreArchivo
        Call EnviarArchivoZipBaja()
        Return True
    End Function

    Private Shared Sub EnviarArchivoZipBaja()
        Dim FileZip As String = NombreArchivo & ".zip"
        MyConexion = New clsConexionSunat

        Dim MyMensaje = MyConexion.EnviarResumenBaja(FileZip)
    End Sub

    Private Shared Sub ComprimirArchivo()

        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = "winrar"
        startInfo.Arguments = "a -afzip " & NombreArchivo & " " & NombreArchivo & ".xml"
        startInfo.WorkingDirectory = MyTempPath
        startInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(startInfo)

        'MessageBox.Show("Compresion realizada correctamente al archivo: " & NombreArchivo & ".zip")
    End Sub

    Public Shared Function ObtenerEstadoCDR(ComprobanteTipo As String, ComprobanteSerie As String, ComprobanteNumero As String) As String
        Dim MyStartInfo As New ProcessStartInfo
        Dim NombreArchivo As String
        Dim NombreArchivoXML As String
        Dim NombreArchivoZip As String
        Dim NombreArchivoRXML As String
        Dim NombreArchivoRZip As String

        Dim MyProcess As New Process

        Dim MyEstadoCDR As String = "1002" ' Error por default

        NombreArchivo = MyRUC & "-" & ComprobanteTipo & "-" & ComprobanteSerie & "-" & ComprobanteNumero.Substring(2, 8)
        NombreArchivoXML = NombreArchivo & ".xml"
        NombreArchivoZip = NombreArchivo & ".zip"
        NombreArchivoRXML = "R-" & NombreArchivoXML
        NombreArchivoRZip = "R-" & NombreArchivoZip

        If Directory.Exists(MyTempPath & "\Reader\dummy") Then Directory.Delete(MyTempPath & "\Reader\dummy")
        File.Delete(MyTempPath & "\Reader\" & NombreArchivoXML)
        File.Delete(MyTempPath & "\Reader\" & NombreArchivoZip)
        File.Delete(MyTempPath & "\Reader\" & NombreArchivoRXML)
        File.Delete(MyTempPath & "\Reader\" & NombreArchivoRZip)

        If File.Exists(MyTempPath & "\" & NombreArchivoRZip) Then
            File.Copy(MyTempPath & "\" & NombreArchivoRZip, MyTempPath & "\Reader\" & NombreArchivoRZip)

            MyStartInfo.FileName = "WinRAR"
            MyStartInfo.Arguments = "x " & MyTempPath & "\Reader\" & NombreArchivoRZip & " " & MyTempPath & "\Reader"
            MyStartInfo.WorkingDirectory = MyTempPath
            MyStartInfo.WindowStyle = ProcessWindowStyle.Hidden

            MyProcess.StartInfo = MyStartInfo
            MyProcess.Start()
            MyProcess.WaitForInputIdle()
            MyProcess.Close()

            MyEstadoCDR = LeeCDR_XML(MyTempPath & "\Reader\" & NombreArchivoRXML)

            Directory.Delete(MyTempPath & "\Reader\dummy")
            File.Delete(MyTempPath & "\Reader\" & NombreArchivoXML)
            File.Delete(MyTempPath & "\Reader\" & NombreArchivoZip)
            File.Delete(MyTempPath & "\Reader\" & NombreArchivoRXML)
            File.Delete(MyTempPath & "\Reader\" & NombreArchivoRZip)
        Else
            Resp = MsgBox("El archivo " & NombreArchivo & " no existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUNAT - ESTADO DEL CDR")
        End If

        Return MyEstadoCDR
    End Function

    Private Shared Function LeeCDR_XML(MyCDR_XML As String) As String
        Dim MyDoc As New XmlDocument
        Dim MyNodos As XmlNodeList
        Dim MyNodo As XmlNode

        Dim MyCDR_ReferenceID As String = ""
        Dim MyCDR_ResponseCode As String = ""
        Dim MyCDR_Description As String = ""

        MyDoc.Load(MyCDR_XML)

        MyNodos = MyDoc.ChildNodes()

        For Each MyNodo In MyNodos
            If MyNodo.Name = "ar:ApplicationResponse" Then
                Dim MyNodos2 As XmlNodeList
                MyNodos2 = MyNodo.ChildNodes
                For Each MyNodo2 In MyNodos2
                    If MyNodo2.Name = "cac:DocumentResponse" Then
                        Dim MyNodos3 As XmlNodeList
                        MyNodos3 = MyNodo2.ChildNodes
                        For Each MyNodo3 In MyNodos3
                            If MyNodo3.Name = "cac:Response" Then
                                Dim MyNodos4 As XmlNodeList
                                MyNodos4 = MyNodo3.ChildNodes
                                For Each MyNodo4 In MyNodos4
                                    Select Case MyNodo4.Name
                                        Case Is = "cbc:ReferenceID" : MyCDR_ReferenceID = MyNodo4.LastChild.Value 'MyNodo2.ChildNodes(0).ChildNodes(0).LastChild.Value
                                        Case Is = "cbc:ResponseCode" : MyCDR_ResponseCode = MyNodo4.LastChild.Value
                                        Case Is = "cbc:Description" : MyCDR_Description = MyNodo4.LastChild.Value
                                    End Select
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next

        If MyCDR_ResponseCode <> "0" Then
            Resp = MsgBox("El Comprobante " & MyCDR_ReferenceID & " fué RECHAZADO." & vbCrLf & _
                          "Código de Retorno: " & MyCDR_ResponseCode & vbCrLf & _
                          "Descripción: " & MyCDR_Description, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUNAT ESTADO DEL CDR")
        End If

        Return MyCDR_ResponseCode
    End Function

    Private Shared Sub GZipCompresion(strNombreArchivo As String)
        Dim fsArchivo As FileStream

        strNombreArchivo = MyTempPath & "\" & NombreArchivo & ".xml"

        Dim strNombreArchivoZip As String = MyTempPath & "\" & NombreArchivo & ".zip"

        Try
            ' Leemos el archivo a comprimir
            fsArchivo = New FileStream(strNombreArchivo, FileMode.Open, FileAccess.Read, FileShare.Read)
            'Definimos el buffer con el tamaño del archivo
            Dim btBuffer As Byte() = New Byte(fsArchivo.Length - 1) {}
            'Almacenamos los bytes del archivo en el buffer
            Dim intCount As Integer = fsArchivo.Read(btBuffer, 0, btBuffer.Length)
            fsArchivo.Close()

            'Definimos el nuevo stream que nos va a permitir grabar el zip
            Dim fsSalida As New FileStream(strNombreArchivo & ".zip", FileMode.Create, FileAccess.Write)
            'Rutina de compresion usando GZipStream
            Dim gzsArchivo As New GZipStream(fsSalida, CompressionMode.Compress, True)
            'Escribimos el resultado
            gzsArchivo.Write(btBuffer, 0, btBuffer.Length)
            gzsArchivo.Close()

            'Cerramos el archivo
            fsSalida.Flush()
            fsSalida.Close()

            My.Computer.FileSystem.RenameFile(strNombreArchivo & ".zip", NombreArchivo & ".zip")

            MessageBox.Show("Compresion realizada correctamente al archivo: " & strNombreArchivoZip)
        Catch ex As Exception

            MessageBox.Show("Ocurrió un error al comprimir: " + ex.Message)
        End Try
    End Sub

    Private Shared Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)
        MessageBox.Show("Mensaje: " & e.Message & vbLf & "Linea: " & e.Exception.LineNumber & vbLf & "Posición: " & e.Exception.LinePosition, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Success = False
    End Sub
#End Region

#Region "Firmar Documento"
    Public Shared Function FirmarDocumento(Venta As entVenta, ByRef DigestValue As String, ByRef SignatureValue As String) As Boolean
        MyVenta = Venta
        NombreArchivo = MyRUC & "-" & MyVenta.comprobante_tipo & "-" & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero.Substring(2, 8)

        Return FirmarArchivoXML(DigestValue, SignatureValue)
    End Function

    Public Shared Function FirmarComunicacionBaja(ByRef DigestValue As String, ByRef SignatureValue As String) As Boolean
        NombreArchivo = "RA-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"
        NombreArchivo = MyRUC & "-" & NombreArchivo
        Return FirmarArchivoXML(DigestValue, SignatureValue)
    End Function

    Public Shared Function FirmarResumenDiario(ByRef DigestValue As String, ByRef SignatureValue As String) As Boolean
        NombreArchivo = "RC-" & CStr(Now.Year * 10000 + Now.Month * 100 + Now.Day) & "-1"
        NombreArchivo = MyRUC & "-" & NombreArchivo
        Return FirmarArchivoXML(DigestValue, SignatureValue)
    End Function

    Private Shared Function FirmarArchivoXML(ByRef DigestValue As String, ByRef SignatureValue As String) As Boolean
        Dim l_xml As String = MyTempPath & "\" & NombreArchivo & ".xml"
        Dim l_xpath As String

        ' El Certificado digital puede tener extensión pfx o p12
        'Dim l_certificado As String = MyTempPath & "\" & MyRUC & "\Certificate\MPS20161007369462.pfx"
        Dim l_certificado As String = MyTempPath & "\" & MyRUC & "\Certificate\C20100233417.pfx"
        Dim l_pwd As String = "Hidronamic2020"

        Dim l_cert As New X509Certificate2(l_certificado, l_pwd)

        Dim xmlDoc As New XmlDocument()

        Dim MyDigestValue As String = ""
        Dim MySignatureValue As String = ""

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
            l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        ElseIf l_xml.Contains("-03-") Then
            'Boleta
            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
            l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        ElseIf l_xml.Contains("-07-") Then
            'nota de crédito
            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")
            l_xpath = "/tns:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        ElseIf l_xml.Contains("-08-") Then
            'nota de débito
            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2")
            l_xpath = "/tns:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        ElseIf l_xml.Contains("-RA-") Then
            ' communicacion de baja
            nsMgr.AddNamespace("tns", "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1")
            l_xpath = "/tns:VoidedDocuments/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        ElseIf l_xml.Contains("-RC-") Then
            ' Resumen diario
            nsMgr.AddNamespace("tns", "urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1")
            l_xpath = "/tns:SummaryDocuments/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
        End If

        nsMgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
        nsMgr.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
        nsMgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
        nsMgr.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
        nsMgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
        nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

        xmlDoc.SelectSingleNode(l_xpath, nsMgr).AppendChild(xmlDoc.ImportNode(signature, True))

        Try
            xmlDoc.Save(l_xml)

            'Call GZipCompresion(NombreArchivo)
            Call ComprimirArchivo()

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

            Dim nodeDigest As XmlNodeList = xmlDoc.GetElementsByTagName("DigestValue")
            MyDigestValue = nodeDigest.Item(0).InnerText
            DigestValue = MyDigestValue

            Dim nodeSignature As XmlNodeList = xmlDoc.GetElementsByTagName("SignatureValue")
            MySignatureValue = nodeSignature.Item(0).InnerText
            SignatureValue = MySignatureValue

            Return True
        Catch ex As Exception
            MessageBox.Show("ERROR: " & vbCrLf & ex.Message, "FIRMAR COMPROBANTE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Function
#End Region

#Region "Capcha"
    Public Shared Function ResolverCapcha() As Boolean
        Dim MyCatpchaResuelto As String

        Dim MyHTMLFile As String

        MyCatpchaResuelto = ObtenerCaptcha()

        MyHTMLFile = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS03Alias?accion=consPorRuc&nroRuc=" & "20549690077" & " &codigo=" & MyCatpchaResuelto & " &tipdoc=1"

        My.Computer.Network.DownloadFile(MyHTMLFile, MyTempPath & "\InfoSunat.txt")

        'MessageBox.Show(MyCatpcha, "Resultado del Captcha", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        ResolverCapcha = True
    End Function

    Private Shared Function ObtenerCaptcha() As String
        Dim MyCatpcha As String = ""
        If Not Directory.Exists(MyTempPath) Then Directory.CreateDirectory(MyTempPath)

        If File.Exists(MyTempPath & "\InfoSunat.txt") = True Then My.Computer.FileSystem.DeleteFile(MyTempPath & "\InfoSunat.txt")
        If File.Exists(MyTempPath & "\Captcha.jpg") = True Then My.Computer.FileSystem.DeleteFile(MyTempPath & "\Captcha.jpg")
        If File.Exists(MyTempPath & "\Captcha.txt") = True Then My.Computer.FileSystem.DeleteFile(MyTempPath & "\Captcha.txt")

        My.Computer.Network.DownloadFile("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image", MyTempPath & "\Captcha.jpg")

        Call ConvertirCaptcha()

        'Dim MyStream As New FileStream(MyTempPath & "\Captcha.txt", FileMode.Open, FileAccess.Read)

        Dim MyReader As New StreamReader(MyTempPath & "\Captcha.txt")

        MyCatpcha = MyReader.ReadLine.Trim.ToUpper
        MyReader.Close()

        Return MyCatpcha
    End Function

    Private Shared Sub ConvertirCaptcha()
        Try
            System.Diagnostics.Process.Start("tesseract", MyTempPath & "\Captcha.jpg " & MyTempPath & "\Captcha -psm 7")
        Catch ex As Exception
            MessageBox.Show("Mensaje: " & ex.Message & vbLf & ex.InnerException.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

#End Region

End Class
