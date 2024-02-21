Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmEComprobanteVentaVehiculoImprimir
    Private MyVenta As entVenta
    Private MyCuentaComercial As entCuentaComercial
    Private MyProducto As entProducto
    Private MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable

    Private MyLocalReport As String

    Private Empresa As String
    Private VentaID As String
    Private Referencia As String
    Private NombrePDF As String
    Private ComprobanteNumero As String
    Private ClienteDireccion As String
    Private MonedaDescripcion As String
    Private Observaciones As String
    Private RazonSocial As String
    Private ImporteTexto As String
    Private TextoQR As String

    Private RutaQR As String

    Private Comprobante As New dsVentas.COMPROBANTEDataTable

    Private CondicionesPago As String
    Private DescripcionVehiculo As String
    Private CategoriaVehicular As String

    Private dsCabecera As dsVentas.VENTASDataTable

    Private MyVentaDetallada As New dsVentas.VENTA_DETALLADataTable

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(Venta As entVenta, CuentaComercial As entCuentaComercial, Producto As entProducto, VentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyVenta = Venta
        MyCuentaComercial = CuentaComercial
        MyProducto = Producto
        MyVentaVehiculo = VentaVehiculo

        ComprobanteNumero = MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero

        ClienteDireccion = MyCuentaComercial.domicilio & " " &
                           ObtenerDescripcion("_UBIGEO", MyCuentaComercial.ubigeo, True) & " " &
                           ObtenerDescripcion("_UBIGEO_PROVINCIA", MyCuentaComercial.ubigeo, True) & " " &
                           ObtenerDescripcion("_UBIGEO_REGION", MyCuentaComercial.ubigeo, True)

        MonedaDescripcion = IIf(MyVenta.tipo_moneda = "1", "SOLES", "DOLARES AMERICANOS")
        Observaciones = IIf(MyVenta.condicion_pago = "TG", "TRANSFERENCIA GRATUITA", MyVenta.comentario)
        Empresa = MyVenta.empresa
        VentaID = MyVenta.venta
        RazonSocial = MyCuentaComercial.razon_social
        ImporteTexto = "SON: " & ConvertNumText(MyVenta.importe_total_origen, IIf(MyVenta.tipo_moneda = "1", "SOLES", "DOLARES AMERICANOS"))
        Referencia = Space(1)
        DescripcionVehiculo = MyProducto.descripcion_ampliada
        CategoriaVehicular = ObtenerDescripcion("OPE_CATEGORIA", MyVentaVehiculo(0).CATEGORIA_VEHICULAR, False)

        With MyVenta
            If .condicion_pago = "FD" Then
                CondicionesPago = "CONTADO CONTRA ENTREGA"
            Else
                CondicionesPago = ObtenerDescripcion("COM_CONDICION_PAGO", .condicion_pago, True)
            End If
            Comprobante.Rows.Add(.empresa, .venta, ComprobanteNumero, .comprobante_fecha, .comprobante_vencimiento, CondicionesPago, .comentario, RazonSocial, MyCuentaComercial.nro_documento, ClienteDireccion, MyCuentaComercial.referencia, Space(1), .tipo_cambio, .tipo_moneda, .base_imponible_gravada_origen, .igv_origen, .importe_total_origen)
        End With

        NombrePDF = MyRUC & "-" & MyVenta.comprobante_tipo & "-" & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero.Substring(2, 8)

        TextoQR = MyRUC & "|" & MyVenta.comprobante_tipo & "|" & MyVenta.comprobante_serie & "|" & _
                  MyVenta.comprobante_numero.Substring(2, 8) & "|" & CStr(MyVenta.igv_origen) & "|" & CStr(MyVenta.importe_total_origen) & "|" & MyVenta.comprobante_fecha & "|" & _
                  Strings.Right(MyVenta.tipo_documento, 1) & "|" & MyVenta.nro_documento & "|" & Space(1) & "|" & "" & "|"

        If MyVenta.comprobante_tipo = "03" Then
            MyLocalReport = "BusinessManager.rptEBoletaVehiculo.rdlc"
        Else
            MyLocalReport = "BusinessManager.rptEFacturaVehiculo.rdlc"
        End If

        Me.rvComprobante.LocalReport.ReportEmbeddedResource = MyLocalReport

        Call GenerarQR(TextoQR)
    End Sub

    Private Sub frmComprobanteVentaVehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MyEComprobanteFirma As entEComprobanteFirma
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""

        Dim PorcentajeIGV As Decimal = 0

        RutaQR = "file:///" & MyTempPath & "\QR.png"

        If MyVenta.base_imponible_gravada_origen <> 0 Then PorcentajeIGV = Math.Round(MyVenta.igv_origen / MyVenta.base_imponible_gravada_origen, 2) * 100

        If Strings.Left(ClienteDireccion, 11) = "NO DEFINIDO" Then ClienteDireccion = Space(1)

        Me.rvComprobante.LocalReport.EnableExternalImages = True

        rvComprobante.LocalReport.DataSources.Clear()

        Dim MyParams(12) As Microsoft.Reporting.WinForms.ReportParameter

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", VentaID, False)
        MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
        MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
        MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
        MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Referencia, False)
        MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)
        MyParams(11) = New Microsoft.Reporting.WinForms.ReportParameter("pDescripcionVehiculo", DescripcionVehiculo, False)
        MyParams(12) = New Microsoft.Reporting.WinForms.ReportParameter("pCategoriaVehicular", CategoriaVehicular, False)

        Me.rvComprobante.LocalReport.SetParameters(MyParams)

        rvComprobante.PrinterSettings.Copies = 1

        Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(Comprobante, DataTable)))
        Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyVentaVehiculo, DataTable)))

        Me.rvComprobante.DocumentMapCollapsed = True

        Me.rvComprobante.LocalReport.DisplayName = NombrePDF

        Me.rvComprobante.RefreshReport()

        Dim warnings As Warning()
        Dim streamids As String()
        Dim mimeType As String
        Dim encoding As String
        Dim filenameExtension As String
        Dim bytes As Byte() = rvComprobante.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warnings)

        Dim fs As New FileStream(MyTempPath & "\" & NombrePDF & ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()

        If dalXML.EvaluarExisteXML(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero) = False Then
            MyVentaDetallada = dalVenta.VentaDetallada(MyVenta.venta)
            MyVentaDetallada(0).DESCRIPCION = MyVentaDetallada(0).DESCRIPCION.Trim & _
                                              " SERIE MOTOR: " & MyVentaVehiculo(0).NUMERO_SERIE & _
                                              " SERIE CHASIS: " & MyVentaVehiculo(0).NUMERO_SERIE_CHASIS & _
                                              " COLOR: " & MyVentaVehiculo(0).COLOR
            If dalXML.CrearComprobante(MyVenta, MyVentaDetallada) = True Then
                If dalXML.FirmarDocumento(MyVenta, DigestValue, SignatureValue) = True Then
                    MyEComprobanteFirma = New entEComprobanteFirma
                    With MyEComprobanteFirma
                        .empresa = MyVenta.empresa
                        .venta = MyVenta.venta
                        .digest_value = DigestValue
                        .signature_value = SignatureValue
                        .usuario_registro = Strings.Left(MyUsuario.usuario.Trim, 20)
                    End With
                    dalEComprobante.GrabarFirma(MyEComprobanteFirma)
                End If
            End If
        End If
    End Sub

    Private Sub rvComprobante_Print(sender As Object, e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles rvComprobante.Print
        If e.Cancel = False Then
            ImpresionCancelada = False
            Me.Close()
        End If
    End Sub

End Class