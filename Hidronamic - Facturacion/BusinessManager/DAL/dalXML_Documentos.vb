Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.Data
Imports System.Xml.Schema
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices
Imports System.Xml.XPath

Public Class dalXML_Documentos

    Private Shared MyTextoXML As Linq.XDocument
    Private Shared MyElementoXML As Linq.XElement

    Private Shared Success As Boolean
    Private Shared MyConexion As clsConexionSunat

    Private MyFactura As entFactura
    Private MyFacturaDetalles As dsVentas.VENTAS_SERDataTable

    Private Declare Function URLDownloadToFile Lib "urlmon" Alias "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, ByVal szFileName As String, ByVal dwReserved As Long, ByVal lpfnCB As Long) As IntPtr

    Public Shared Function CrearDocumento() As Boolean
        Call CrearFactura()
        Call GuardarArchivoXML()
        Return True
    End Function

    Public Shared Function ValidarDocumento() As Boolean
        Return ValidarArchivoXML()
    End Function

    Public Shared Function FirmarDocumento() As Boolean
        Call FirmarArchivoXML()
        Return True
    End Function

    Public Shared Function EnviarDocumento() As Boolean
        Call EnviarArchivoZip()
        Return True
    End Function

    Private Shared Function CrearFactura() As XDocument
        MyTextoXML = New XDocument

        MyTextoXML = <?xml version="1.0" encoding="ISO-8859-1" standalone="no"?>
                     <Invoice
                         xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
                         xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
                         xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
                         xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                         xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
                         xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
                         xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                             <ext:UBLExtension>
                                 <cbc:ID>SUNAT</cbc:ID>
                                 <ext:ExtensionContent>
                                     <sac:AdditionalInformation>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1001</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">3000.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1002</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">0.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1003</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">0.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1004</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">0.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>2003</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">300.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalProperty>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Value>
                                                 <![CDATA[TRES MIL QUINIENTOS CUARENTA CON 00/100]]>
                                             </cbc:Value>
                                         </sac:AdditionalProperty>
                                         <sac:AdditionalProperty>
                                             <cbc:ID>2006</cbc:ID>
                                             <cbc:Value>
                                                 <![CDATA[OPERACION SUJETA A DETRACCION]]>
                                             </cbc:Value>
                                         </sac:AdditionalProperty>
                                     </sac:AdditionalInformation>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.0</cbc:UBLVersionID>
                         <cbc:CustomizationID>1.0</cbc:CustomizationID>
                         <cbc:ID>FF11-5166</cbc:ID>
                         <cbc:IssueDate>2016-10-31</cbc:IssueDate>
                         <cbc:InvoiceTypeCode>01</cbc:InvoiceTypeCode>
                         <cbc:DocumentCurrencyCode>PEN</cbc:DocumentCurrencyCode>
                         <cac:Signature>
                             <cbc:ID>IDSignSP</cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID>20547481675</cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name><![CDATA[BINARIX]]></cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>#signatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <cac:AccountingSupplierParty>
                             <cbc:CustomerAssignedAccountID>20547481675</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyName>
                                     <cbc:Name><![CDATA[BINARIX]]></cbc:Name>
                                 </cac:PartyName>
                                 <cac:PostalAddress>
                                     <cbc:ID>150122</cbc:ID>
                                     <cbc:StreetName><![CDATA[CALLE DIEZ CANSECO 219 - PISO 2]]></cbc:StreetName>
                                     <cbc:CitySubdivisionName></cbc:CitySubdivisionName>
                                     <cbc:CityName>LIMA</cbc:CityName>
                                     <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                     <cbc:District>MIRAFLORES</cbc:District>
                                     <cac:Country>
                                         <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                     </cac:Country>
                                 </cac:PostalAddress>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName><![CDATA[BINARIX S.A.]]></cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                         <cac:AccountingCustomerParty>
                             <cbc:CustomerAssignedAccountID>20263322496</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName><![CDATA[NESTLE PERU S A]]></cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingCustomerParty>
                         <cac:TaxTotal>
                             <cbc:TaxAmount currencyID="PEN">540.00</cbc:TaxAmount>
                             <cac:TaxSubtotal>
                                 <cbc:TaxAmount currencyID="PEN">540.00</cbc:TaxAmount>
                                 <cbc:Percent>18.0</cbc:Percent>
                                 <cac:TaxCategory>
                                     <cac:TaxScheme>
                                         <cbc:ID>1000</cbc:ID>
                                         <cbc:Name>IGV</cbc:Name>
                                         <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                     </cac:TaxScheme>
                                 </cac:TaxCategory>
                             </cac:TaxSubtotal>
                         </cac:TaxTotal>
                         <cac:LegalMonetaryTotal>
                             <cbc:PayableAmount currencyID="PEN">3540.00</cbc:PayableAmount>
                         </cac:LegalMonetaryTotal>
                         <cac:InvoiceLine>
                             <cbc:ID>1</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">300.00</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">3000.00</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">11.80</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">540.00</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">540.00</cbc:TaxAmount>
                                     <cbc:Percent>18.0</cbc:Percent>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description><![CDATA[ILUSTRACION DE 1 DISENO PARA CAMPANA DIA DEL PADRE]]></cbc:Description>
                                 <cbc:Description><![CDATA[CODIGO PROVEEDOR: 100943003]]></cbc:Description>
                                 <cbc:Description><![CDATA[PEDIDO 4511163767 31.05.2016]]></cbc:Description>
                                 <cbc:Description><![CDATA[CODIGO RECEPCION: 6001453949]]></cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>NEST-PRO-009-16</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">10.00</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                     </Invoice>
        Return MyTextoXML
    End Function

    Private Shared Function CrearFactura_Original() As XDocument
        MyTextoXML = New XDocument

        'MyTextoXML = <ds:Signature Id="SignatureSP">
        '                 <ds:SignedInfo>
        '                     <ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
        '                     <ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/>
        '                     <ds:Reference URI="">
        '                         <ds:Transforms>
        '                             <ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"/>
        '                         </ds:Transforms>
        '                         <ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/>
        '                         <ds:DigestValue></ds:DigestValue>
        '                     </ds:Reference>
        '                 </ds:SignedInfo>
        '                 <ds:SignatureValue></ds:SignatureValue>
        '                 <ds:KeyInfo>
        '                     <ds:X509Data>
        '                         <ds:X509SubjectName></ds:X509SubjectName>
        '                         <ds:X509Certificate></ds:X509Certificate>
        '                     </ds:X509Data>
        '                     <ds:KeyValue>
        '                         <ds:RSAKeyValue>
        '                             <ds:Modulus></ds:Modulus>
        '                             <ds:Exponent></ds:Exponent>
        '                         </ds:RSAKeyValue>
        '                     </ds:KeyValue>
        '                 </ds:KeyInfo>
        '             </ds:Signature>


        MyTextoXML = <?xml version="1.0" encoding="ISO-8859-1" standalone="no"?>
                     <Invoice xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                     <ds:Signature Id="SignatureSP">
                                         <ds:SignedInfo>
                                             <ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
                                             <ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/>
                                             <ds:Reference URI="">
                                                 <ds:Transforms>
                                                     <ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"/>
                                                 </ds:Transforms>
                                                 <ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/>
                                                 <ds:DigestValue></ds:DigestValue>
                                             </ds:Reference>
                                         </ds:SignedInfo>
                                         <ds:SignatureValue></ds:SignatureValue>
                                         <ds:KeyInfo>
                                             <ds:X509Data>
                                                 <ds:X509SubjectName></ds:X509SubjectName>
                                                 <ds:X509Certificate></ds:X509Certificate>
                                             </ds:X509Data>
                                         </ds:KeyInfo>
                                     </ds:Signature>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.0</cbc:UBLVersionID>
                         <cbc:CustomizationID>1.0</cbc:CustomizationID>
                         <cbc:ID>F001-4355</cbc:ID>
                         <cbc:IssueDate>2012-03-14</cbc:IssueDate>
                         <cbc:InvoiceTypeCode>01</cbc:InvoiceTypeCode>
                         <cbc:DocumentCurrencyCode>PEN</cbc:DocumentCurrencyCode>
                         <cac:Signature>
                             <cbc:ID>IDSignWPP</cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID>20100454523</cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name>SOPORTE TECNOLOGICO EIRL</cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>#SignatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <cac:AccountingSupplierParty>
                             <cbc:CustomerAssignedAccountID>20100454523</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PostalAddress>
                                     <cbc:ID>150111</cbc:ID>
                                     <cbc:StreetName>AV. LOS PRECURSORES #1245</cbc:StreetName>
                                     <cbc:CitySubdivisionName>URB. MIGUEL GRAU</cbc:CitySubdivisionName>
                                     <cbc:CityName>LIMA</cbc:CityName>
                                     <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                     <cbc:District>EL AGUSTINO</cbc:District>
                                     <cac:Country>
                                         <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                     </cac:Country>
                                 </cac:PostalAddress>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName>SOPORTE TECNOLOGICOS EIRL</cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                         <cac:AccountingCustomerParty>
                             <cbc:CustomerAssignedAccountID>20587896411</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName>SERVICABINAS S.A.</cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingCustomerParty>
                         <cac:TaxTotal>
                             <cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount>
                             <cac:TaxSubtotal>
                                 <cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount>
                                 <cac:TaxCategory>
                                     <cac:TaxScheme>
                                         <cbc:ID>1000</cbc:ID>
                                         <cbc:Name>IGV</cbc:Name>
                                         <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                     </cac:TaxScheme>
                                 </cac:TaxCategory>
                             </cac:TaxSubtotal>
                         </cac:TaxTotal>
                         <cac:LegalMonetaryTotal>
                             <cbc:PayableAmount currencyID="PEN">423225.00</cbc:PayableAmount>
                         </cac:LegalMonetaryTotal>
                         <cac:InvoiceLine>
                             <cbc:ID>1</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">2000</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">149491.53</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">98.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Grabadora LG Externo Modelo: GE20LU10</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>GLG199</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">83.05</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>2</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">300</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">133983.05</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">620.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Monitor LCD ViewSonic VG2028WM 20</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>MVS546</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">525.42</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>3</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">250</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">13000.00</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>20</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Memoria DDR-3 B1333 Kingston</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>MPC35</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>4</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">500</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">83050.85</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">196.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Teclado Microsoft SideWinder X6</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>TMS22</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">166.10</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>5</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">5</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">30.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>02</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>31</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Web cam Genius iSlim 310VVU </cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>WCG01</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                     </Invoice>
        Return MyTextoXML
    End Function

    Private Shared Sub GuardarArchivoXML()
        Dim MyWriteSettings As New XmlWriterSettings
        'MyWriteSettings.Encoding = New UTF8Encoding

        Dim MyWrite = XmlWriter.Create(MyTempPath & "\20547481675-01-FF11-5166.xml", MyWriteSettings)

        MyTextoXML.Save(MyWrite)
        MyWrite.Close()


    End Sub

    Private Shared Function ValidarArchivoXML() As Boolean
        Dim MyReadSettings As New XmlReaderSettings
        Dim MySchemas As New XmlSchemaSet
        Dim MyValidator As XmlReader
        Success = True
        MyReadSettings.ValidationType = ValidationType.Schema

        MyReadSettings.Schemas = MySchemas

        'MySchemas.Add("http://www.w3.org/2000/09/xmldsig#", "http://www.w3.org/TR/xmldsig-core/xmldsig-core-schema.xsd")
        'MySchemas.Add("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.0.xsd")

        MySchemas.Add(Nothing, MyTempPath & "\Common\UBL-Invoice-2.0.xsd")


        MyReadSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings

        AddHandler MyReadSettings.ValidationEventHandler, AddressOf ValidationEventHandler

        MyValidator = XmlReader.Create(MyTempPath & "\20547481675-01-FF11-5166.xml", MyReadSettings)
        'MyValidator = XmlReader.Create(MyTempPath & "\20100108616-01-F006-00000283.xml", MyReadSettings)

        While MyValidator.Read() : End While

        Return Success
    End Function

    Private Shared Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)
        MessageBox.Show("Mensaje: " & e.Message & vbLf & "Linea: " & e.Exception.LineNumber & vbLf & "Posición: " & e.Exception.LinePosition, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Success = False
    End Sub

    Private Shared Sub FirmarArchivoXML()
        Dim l_xml As String = MyTempPath & "\20547481675-01-FF11-5166.xml"
        Dim l_certificado As String = MyTempPath & "\Certificate\MPS20160808344882.pfx"
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
            'l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent"
            l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent"
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

    Private Shared Sub EnviarArchivoZip()
        Dim FileZip As String = "20547481675-01-FF11-5166.zip"
        MyConexion = New clsConexionSunat
        Dim MyMensaje = MyConexion.EnviarDocumento(FileZip)
    End Sub

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

    Private Shared Sub EscribirXml()
        'Declaramos el documento y su definición
        Dim document As New XDocument(New XDeclaration("1.0", "utf-8", Nothing))

        'Creamos el nodo raiz y lo añadimos al documento
        Dim nodoRaiz As New XElement("empleados")
        document.Add(nodoRaiz)

        For i As Integer = 1 To 5
            'Creamos el nodo empleado y el contenido con sus nodos hijos
            Dim nodoEmpleado As New XElement("empleado")
            nodoEmpleado.Add(New XElement("idEmpleado", i))
            nodoEmpleado.Add(New XElement("nombre", "UnNombre" & i))
            nodoEmpleado.Add(New XElement("apellidos", "UnosApellidos" & i))
            nodoEmpleado.Add(New XElement("numeroSS", "111-111-11" & i))
            nodoEmpleado.Add(New XElement("telefonos", New XElement("fijo", "90000000" & i), New XElement("movil", "60000000" & i)))

            'Añadirmos el nodo empleado y escribimos en el documento
            nodoRaiz.Add(nodoEmpleado)
        Next

        document.Save("")
    End Sub

    Private Function CrearNodoXml(id As String, nom As String, ape As String, nss As String, fijo As String, mvl As String) As XmlNode
        Dim documento = New XmlDocument()

        'Creamos el nodo que deseamos insertar.
        Dim empleado As XmlElement = documento.CreateElement("")

        'Creamos el elemento idEmpleado.
        Dim idEmpleado As XmlElement = documento.CreateElement("idEmpleado", "cbc")
        idEmpleado.InnerText = id
        empleado.AppendChild(idEmpleado)

        'Creamos el elemento nombre.
        Dim nombre As XmlElement = documento.CreateElement("nombre")
        nombre.InnerText = nom
        empleado.AppendChild(nombre)

        'Creamos el elemento apellidos.
        Dim apellidos As XmlElement = documento.CreateElement("apellidos")
        apellidos.InnerText = ape
        empleado.AppendChild(apellidos)

        'Creamos el elemento numeroSS.
        Dim numeroSS As XmlElement = documento.CreateElement("numeroSS")
        numeroSS.InnerText = nss
        empleado.AppendChild(numeroSS)

        'Creamos el elemento telefonos.
        Dim telefonos As XmlElement = documento.CreateElement("telefonos")
        empleado.AppendChild(telefonos)

        'Creamos el elemento fijo.
        Dim nodoFijo As XmlElement = documento.CreateElement("fijo")
        nodoFijo.InnerText = fijo
        telefonos.AppendChild(nodoFijo)
        'Creamos el elemento movil.
        Dim movil As XmlElement = documento.CreateElement("movil")
        movil.InnerText = mvl
        telefonos.AppendChild(movil)

        Return empleado
    End Function

    Private Sub addNode(idEmpleado As String, nombre As String, edad As String)
        Dim miXML As XDocument = XDocument.Load("C:\Prueba\MiDoc.xml")
        'Cargamos
        'Obtiene la raiz del documento (Empleados)                         
        miXML.Root.Add(New XElement("Empleado", New XAttribute("Id_Empleado", idEmpleado), New XElement("Nombre", nombre), New XElement("Edad", edad)))
        miXML.Save("C:\Prueba\MiDoc.xml")
    End Sub

    Private Sub Backup()

        MyTextoXML = <?xml version="1.0" encoding="ISO-8859-1" standalone="no"?>
                     <Invoice xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:sac="urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                         <ext:UBLExtensions>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                     <sac:AdditionalInformation>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1001</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">348199.15</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1003</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">12350.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>1004</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">30.00</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalMonetaryTotal>
                                             <cbc:ID>2005</cbc:ID>
                                             <cbc:PayableAmount currencyID="PEN">59230.51</cbc:PayableAmount>
                                         </sac:AdditionalMonetaryTotal>
                                         <sac:AdditionalProperty>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Value>CUATROCIENTOS VEINTITRES MIL DOSCIENTOS VEINTICINCO Y 00/100</cbc:Value>
                                         </sac:AdditionalProperty>
                                     </sac:AdditionalInformation>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                             <ext:UBLExtension>
                                 <ext:ExtensionContent>
                                     <ds:Signature Id="SignatureSP">
                                         <ds:SignedInfo>
                                             <ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
                                             <ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/>
                                             <ds:Reference URI="">
                                                 <ds:Transforms>
                                                     <ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"/>
                                                 </ds:Transforms>
                                                 <ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/>
                                                 <ds:DigestValue></ds:DigestValue>
                                             </ds:Reference>
                                         </ds:SignedInfo>
                                         <ds:SignatureValue></ds:SignatureValue>
                                         <ds:KeyInfo>
                                             <ds:X509Data>
                                                 <ds:X509SubjectName></ds:X509SubjectName>
                                                 <ds:X509Certificate></ds:X509Certificate>
                                             </ds:X509Data>
                                         </ds:KeyInfo>
                                     </ds:Signature>
                                 </ext:ExtensionContent>
                             </ext:UBLExtension>
                         </ext:UBLExtensions>
                         <cbc:UBLVersionID>2.0</cbc:UBLVersionID>
                         <cbc:CustomizationID>1.0</cbc:CustomizationID>
                         <cbc:ID>F001-4355</cbc:ID>
                         <cbc:IssueDate>2012-03-14</cbc:IssueDate>
                         <cbc:InvoiceTypeCode>01</cbc:InvoiceTypeCode>
                         <cbc:DocumentCurrencyCode>PEN</cbc:DocumentCurrencyCode>
                         <cac:Signature>
                             <cbc:ID>IDSignSP</cbc:ID>
                             <cac:SignatoryParty>
                                 <cac:PartyIdentification>
                                     <cbc:ID>20100454523</cbc:ID>
                                 </cac:PartyIdentification>
                                 <cac:PartyName>
                                     <cbc:Name>SOPORTE TECNOLOGICO EIRL</cbc:Name>
                                 </cac:PartyName>
                             </cac:SignatoryParty>
                             <cac:DigitalSignatureAttachment>
                                 <cac:ExternalReference>
                                     <cbc:URI>#SignatureSP</cbc:URI>
                                 </cac:ExternalReference>
                             </cac:DigitalSignatureAttachment>
                         </cac:Signature>
                         <cac:AccountingSupplierParty>
                             <cbc:CustomerAssignedAccountID>20100454523</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PostalAddress>
                                     <cbc:ID>150111</cbc:ID>
                                     <cbc:StreetName>AV. LOS PRECURSORES #1245</cbc:StreetName>
                                     <cbc:CitySubdivisionName>URB. MIGUEL GRAU</cbc:CitySubdivisionName>
                                     <cbc:CityName>LIMA</cbc:CityName>
                                     <cbc:CountrySubentity>LIMA</cbc:CountrySubentity>
                                     <cbc:District>EL AGUSTINO</cbc:District>
                                     <cac:Country>
                                         <cbc:IdentificationCode>PE</cbc:IdentificationCode>
                                     </cac:Country>
                                 </cac:PostalAddress>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName>SOPORTE TECNOLOGICOS EIRL</cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingSupplierParty>
                         <cac:AccountingCustomerParty>
                             <cbc:CustomerAssignedAccountID>20587896411</cbc:CustomerAssignedAccountID>
                             <cbc:AdditionalAccountID>6</cbc:AdditionalAccountID>
                             <cac:Party>
                                 <cac:PartyLegalEntity>
                                     <cbc:RegistrationName>SERVICABINAS S.A.</cbc:RegistrationName>
                                 </cac:PartyLegalEntity>
                             </cac:Party>
                         </cac:AccountingCustomerParty>
                         <cac:TaxTotal>
                             <cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount>
                             <cac:TaxSubtotal>
                                 <cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount>
                                 <cac:TaxCategory>
                                     <cac:TaxScheme>
                                         <cbc:ID>1000</cbc:ID>
                                         <cbc:Name>IGV</cbc:Name>
                                         <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                     </cac:TaxScheme>
                                 </cac:TaxCategory>
                             </cac:TaxSubtotal>
                         </cac:TaxTotal>
                         <cac:LegalMonetaryTotal>
                             <cbc:PayableAmount currencyID="PEN">423225.00</cbc:PayableAmount>
                         </cac:LegalMonetaryTotal>
                         <cac:InvoiceLine>
                             <cbc:ID>1</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">2000</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">149491.53</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">98.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Grabadora LG Externo Modelo: GE20LU10</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>GLG199</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">83.05</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>2</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">300</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">133983.05</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">620.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Monitor LCD ViewSonic VG2028WM 20</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>MVS546</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">525.42</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>3</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">250</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">13000.00</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>20</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Memoria DDR-3 B1333 Kingston</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>MPC35</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>4</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">500</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">83050.85</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">196.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>10</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Teclado Microsoft SideWinder X6</cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>TMS22</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">166.10</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                         <cac:InvoiceLine>
                             <cbc:ID>5</cbc:ID>
                             <cbc:InvoicedQuantity unitCode="NIU">5</cbc:InvoicedQuantity>
                             <cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount>
                             <cac:PricingReference>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>01</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                                 <cac:AlternativeConditionPrice>
                                     <cbc:PriceAmount currencyID="PEN">30.00</cbc:PriceAmount>
                                     <cbc:PriceTypeCode>02</cbc:PriceTypeCode>
                                 </cac:AlternativeConditionPrice>
                             </cac:PricingReference>
                             <cac:TaxTotal>
                                 <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                 <cac:TaxSubtotal>
                                     <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount>
                                     <cac:TaxCategory>
                                         <cbc:TaxExemptionReasonCode>31</cbc:TaxExemptionReasonCode>
                                         <cac:TaxScheme>
                                             <cbc:ID>1000</cbc:ID>
                                             <cbc:Name>IGV</cbc:Name>
                                             <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode>
                                         </cac:TaxScheme>
                                     </cac:TaxCategory>
                                 </cac:TaxSubtotal>
                             </cac:TaxTotal>
                             <cac:Item>
                                 <cbc:Description>Web cam Genius iSlim 310VVU </cbc:Description>
                                 <cac:SellersItemIdentification>
                                     <cbc:ID>WCG01</cbc:ID>
                                 </cac:SellersItemIdentification>
                             </cac:Item>
                             <cac:Price>
                                 <cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount>
                             </cac:Price>
                         </cac:InvoiceLine>
                     </Invoice>

    End Sub

End Class
