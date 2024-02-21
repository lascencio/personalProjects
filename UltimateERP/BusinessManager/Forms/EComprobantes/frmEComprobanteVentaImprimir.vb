Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmEComprobanteVentaImprimir
    Private Comprobante As dsVentas.COMPROBANTEDataTable
    Private ComprobanteDetalles As dsVentas.VENTA_DETALLADataTable

    Private MyLocalReport As String

    Private Empresa As String
    Private Venta As String
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

    Private dsCabecera As dsVentas.VENTASDataTable

    Private MyVenta As entVenta

    Private MyCuentaComercial As entCuentaComercial

    Private EsVehicular As Boolean = False


    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(pVenta As entVenta, pReferencia As String, pCuentaComercial As entCuentaComercial, pEsVehicular As Boolean)
        Dim MySeries As String
        Dim MyProducto As entProducto
        Dim Producto As String

        Dim MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable

        Dim ComprobanteSeries As dsVentas.COMPROBANTE_SERIESDataTable

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = pVenta
        Empresa = MyVenta.empresa
        Venta = MyVenta.venta
        MyCuentaComercial = pCuentaComercial
        EsVehicular = pEsVehicular

        If MyVenta.comprobante_tipo = "07" Or MyVenta.comprobante_tipo = "08" Then
            Referencia = MyVenta.referencia_serie & "-" & MyVenta.referencia_numero
        Else
            Referencia = pReferencia
        End If

        ComprobanteNumero = MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero

        MonedaDescripcion = IIf(MyVenta.tipo_moneda = "1", "SOLES", "DOLARES AMERICANOS")

        If MyVenta.condicion_pago = "TG" Then
            Observaciones = "TRANSFERENCIA GRATUITA"
        ElseIf MyVenta.condicion_pago = "FD" Then
            Observaciones = "CONTADO CONTRA ENTREGA"
        Else
            Observaciones = MyVenta.comentario
        End If

        Comprobante = dalVenta.ObtenerComprobante(MyVenta.venta)

        If MyVenta.estado = "N" Then
            ComprobanteDetalles = New dsVentas.VENTA_DETALLADataTable
        ElseIf MyVenta.comprobante_tipo = "07" And MyVenta.tipo_operacion = "C2" Then
            ComprobanteDetalles = dalVenta.VentaDetalladaNC(MyVenta.venta)
        ElseIf MyVenta.comprobante_tipo = "08" Then
            ComprobanteDetalles = dalVenta.VentaDetalladaNC(MyVenta.venta)
        Else
            ComprobanteDetalles = dalVenta.VentaDetallada(MyVenta.venta)
        End If

        '------------------------------
        If MyVenta.comprobante_tipo = "07" Then
            ComprobanteSeries = dalVenta.ObtenerNotaCreditoSeries(MyVenta.venta)
        Else
            ComprobanteSeries = dalVenta.ObtenerComprobanteSeries(MyVenta.guia_remitente)
            If ComprobanteSeries.Rows.Count = 0 Then
                ComprobanteSeries = dalVenta.ObtenerComprobanteSeriesVentaDirecta(MyVenta.venta)
            End If
        End If

        If ComprobanteDetalles.Rows.Count <> 0 Then
            For NFila As Integer = 0 To ComprobanteDetalles.Rows.Count - 1
                If ComprobanteDetalles(NFila).INDICA_SERIE = "SI" Then
                    MySeries = "SERIES: "
                    Producto = ComprobanteDetalles(NFila).PRODUCTO
                    MyProducto = dalProducto.Obtener(MyUsuario.empresa, Producto)

                    If MyProducto.indica_compuesto = "NO" Then
                        If ComprobanteSeries.Rows.Count <> 0 Then
                            For NFila2 As Integer = 0 To ComprobanteSeries.Rows.Count - 1
                                If ComprobanteSeries(NFila2).PRODUCTO = Producto Then
                                    If MyProducto.producto_tipo = "001" Then
                                        MySeries = MySeries & "MOTOR: " & ComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " CHASIS: " & ComprobanteSeries(NFila2).NUMERO_SERIE_CHASIS.Trim & " COLOR: " & ComprobanteSeries(NFila2).COLOR.Trim & " / "
                                    Else
                                        MySeries = MySeries & ComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / "
                                    End If
                                End If
                            Next
                        End If
                    Else
                        MyProductoComponentes = dalProducto.ObtenerProductoComponentes(MyUsuario.empresa, Producto)
                        If MyProductoComponentes.Rows.Count <> 0 Then
                            For NFila3 As Integer = 0 To MyProductoComponentes.Rows.Count - 1
                                Producto = MyProductoComponentes(NFila3).PRODUCTO
                                If ComprobanteSeries.Rows.Count <> 0 Then
                                    For NFila2 As Integer = 0 To ComprobanteSeries.Rows.Count - 1
                                        If ComprobanteSeries(NFila2).PRODUCTO = Producto Then
                                            MySeries = MySeries & ComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / "
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                    MySeries = Strings.Left(MySeries, MySeries.Trim.Length - 1)
                    ComprobanteDetalles(NFila).DESCRIPCION = ComprobanteDetalles(NFila).DESCRIPCION.Trim & " " & MySeries
                End If
            Next
        End If

        ClienteDireccion = Comprobante(0).DIRECCION

        NombrePDF = MyRUC & "-" & MyVenta.comprobante_tipo & "-" & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero.Substring(2, 8)

        TextoQR = MyRUC & "|" & MyVenta.comprobante_tipo & "|" & MyVenta.comprobante_serie & "|" & _
                  MyVenta.comprobante_numero.Substring(2, 8) & "|" & CStr(MyVenta.igv_origen) & "|" & CStr(MyVenta.importe_total_origen) & "|" & MyVenta.comprobante_fecha & "|" & _
                  Strings.Right(pCuentaComercial.tipo_documento, 1) & "|" & pCuentaComercial.nro_documento & "|" & Space(1) & "|" & "" & "|"

        RazonSocial = Comprobante(0).RAZON_SOCIAL

        ImporteTexto = "SON: " & ConvertNumText(MyVenta.importe_total_origen, IIf(MyVenta.tipo_moneda = "1", "SOLES", "DOLARES AMERICANOS"))

        dsCabecera = New dsVentas.VENTASDataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & Empresa & "' AND VENTA='" & Venta & "'"

        If EsVehicular = True Then
            Select Case MyVenta.comprobante_tipo
                Case Is = "01" : MyLocalReport = "BusinessManager.rptEFacturaVehiculo.rdlc"
                Case Is = "03" : MyLocalReport = "BusinessManager.rptEBoletaVehiculo.rdlc"
                Case Is = "07" : MyLocalReport = "BusinessManager.rptENotaCredito.rdlc"
                Case Is = "08" : MyLocalReport = "BusinessManager.rptENotaDebito.rdlc"
            End Select
        Else
            If MyUsuario.emite_ticket = True Then
                Select Case MyVenta.comprobante_tipo
                    Case Is = "01" : MyLocalReport = "BusinessManager.rptTFactura.rdlc"
                    Case Is = "03" : MyLocalReport = "BusinessManager.rptTBoleta.rdlc"
                    Case Is = "07" : MyLocalReport = "BusinessManager.rptTNotaCredito.rdlc"
                    Case Is = "08" : MyLocalReport = "BusinessManager.rptTNotaDebito.rdlc"
                End Select
            Else
                Select Case MyVenta.comprobante_tipo
                    Case Is = "01" : MyLocalReport = "BusinessManager.rptEFactura.rdlc"
                    Case Is = "03" : MyLocalReport = "BusinessManager.rptEBoleta.rdlc"
                    Case Is = "07" : MyLocalReport = "BusinessManager.rptENotaCredito.rdlc"
                    Case Is = "08" : MyLocalReport = "BusinessManager.rptENotaDebito.rdlc"
                End Select
            End If
        End If

        Me.rvComprobante.LocalReport.ReportEmbeddedResource = MyLocalReport

        Call ObtenerDataTableSQL(CadenaSQL, dsCabecera)

        Call GenerarQR(TextoQR)

    End Sub

    Public Sub New(pVenta As entVenta, pRazonSocial As String, pClienteDireccion As String, pMonedaDescripcion As String, pObservaciones As String, pNombrePDF As String, pImporteTexto As String, pTextoQR As String, pPorcentajeIGV As Decimal, pComprobante As dsVentas.COMPROBANTEDataTable, pComprobanteDetalles As dsVentas.VENTA_DETALLADataTable)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = pVenta
        Empresa = MyVenta.empresa
        Venta = MyVenta.venta
        RazonSocial = pRazonSocial
        MonedaDescripcion = pMonedaDescripcion
        Observaciones = IIf(pObservaciones.Trim.Length = 0, Space(1), pObservaciones)
        NombrePDF = pNombrePDF
        ImporteTexto = pImporteTexto
        TextoQR = pTextoQR
        Comprobante = pComprobante

        If MyVenta.estado = "N" Then
            ComprobanteDetalles = New dsVentas.VENTA_DETALLADataTable
        Else
            ComprobanteDetalles = pComprobanteDetalles
        End If

        ClienteDireccion = IIf(Comprobante(0).DIRECCION.Trim.Length <> 0, Comprobante(0).DIRECCION.Trim, IIf(pClienteDireccion.Trim.Length <> 0, pClienteDireccion, Space(1)))

        If MyVenta.comprobante_tipo = "07" Or MyVenta.comprobante_tipo = "08" Then
            Referencia = MyVenta.referencia_serie & "-" & MyVenta.referencia_numero
        Else
            Referencia = Space(1)
        End If

        ComprobanteNumero = MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero

        dsCabecera = New dsVentas.VENTASDataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & Empresa & "' AND VENTA='" & Venta & "'"

        If EsVehicular = True Then
            Select Case MyVenta.comprobante_tipo
                Case Is = "01" : MyLocalReport = "BusinessManager.rptEFacturaVehiculo.rdlc"
                Case Is = "03" : MyLocalReport = "BusinessManager.rptEBoletaVehiculo.rdlc"
                Case Is = "07" : MyLocalReport = "BusinessManager.rptENotaCredito.rdlc"
                Case Is = "08" : MyLocalReport = "BusinessManager.rptENotaDebito.rdlc"
            End Select
        Else
            If MyUsuario.emite_ticket = True Then
                Select Case MyVenta.comprobante_tipo
                    Case Is = "01" : MyLocalReport = "BusinessManager.rptTFactura.rdlc"
                    Case Is = "03" : MyLocalReport = "BusinessManager.rptTBoleta.rdlc"
                    Case Is = "07" : MyLocalReport = "BusinessManager.rptTNotaCredito.rdlc"
                    Case Is = "08" : MyLocalReport = "BusinessManager.rptTNotaDebito.rdlc"
                    Case Is <= "11"

                End Select
            Else
                Select Case MyVenta.comprobante_tipo
                    Case Is = "01" : MyLocalReport = "BusinessManager.rptEFactura.rdlc"
                    Case Is = "03" : MyLocalReport = "BusinessManager.rptEBoleta.rdlc"
                    Case Is = "07" : MyLocalReport = "BusinessManager.rptENotaCredito.rdlc"
                    Case Is = "08" : MyLocalReport = "BusinessManager.rptENotaDebito.rdlc"
                End Select
            End If

        End If

        Me.rvComprobante.LocalReport.ReportEmbeddedResource = MyLocalReport

        Call ObtenerDataTableSQL(CadenaSQL, dsCabecera)

        Call GenerarQR(TextoQR)
    End Sub

    Private Sub frmComprobanteVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PorcentajeIGV As Decimal = 0

        RutaQR = "file:///" & MyTempPath & "\QR.png"

        If Comprobante(0).VALOR_VENTA <> 0 Then PorcentajeIGV = Math.Round(Comprobante(0).IMPUESTO / Comprobante(0).VALOR_VENTA, 2) * 100

        If Strings.Left(ClienteDireccion, 11) = "NO DEFINIDO" Then ClienteDireccion = Space(1)

        Me.rvComprobante.LocalReport.EnableExternalImages = True

        Dim NombreImpresora As String = ""
        For i As Integer = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
            Dim a As New Printing.PrinterSettings()
            a.PrinterName = Printing.PrinterSettings.InstalledPrinters(i).ToString()
            If a.IsDefaultPrinter Then NombreImpresora = Printing.PrinterSettings.InstalledPrinters(i).ToString()
        Next

        rvComprobante.PrinterSettings.PrinterName = NombreImpresora

        rvComprobante.LocalReport.DataSources.Clear()

        If MyVenta.comprobante_tipo = "01" Or MyVenta.comprobante_tipo = "03" Then
            If EsVehicular = True Then
                Dim MyParams(10) As Microsoft.Reporting.WinForms.ReportParameter

                MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
                MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
                MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
                MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
                MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
                MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", Venta, False)
                MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
                MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
                MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
                MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Referencia, False)
                MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)

                Me.rvComprobante.LocalReport.SetParameters(MyParams)

                rvComprobante.PrinterSettings.Copies = 1

                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(Comprobante, DataTable)))
                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(ComprobanteDetalles, DataTable)))
            Else
                Dim MyParams(10) As Microsoft.Reporting.WinForms.ReportParameter

                Observaciones = MyVenta.comentario

                MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
                MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
                MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
                MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
                MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
                MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", Venta, False)
                MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
                MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
                MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
                MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Referencia, False)
                MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)

                Me.rvComprobante.LocalReport.SetParameters(MyParams)

                rvComprobante.PrinterSettings.Copies = 1

                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(Comprobante, DataTable)))
                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(ComprobanteDetalles, DataTable)))
            End If
        Else
            If EsVehicular = True Then
                Dim MyParams(12) As Microsoft.Reporting.WinForms.ReportParameter

                If MyVenta.comprobante_tipo = "07" Then
                    MyVenta.tipo_operacion_nombre = dalTablasGenericas.ObtenerMotivoNotaCredito("000", IIf(MyVenta.tipo_operacion = "C7", "01", "10"))
                End If

                MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
                MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
                MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
                MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
                MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
                MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", Venta, False)
                MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
                MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
                MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoOperacionNombre", MyVenta.tipo_operacion_nombre, False)
                MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
                MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Referencia, False)
                MyParams(11) = New Microsoft.Reporting.WinForms.ReportParameter("pRUC", MyVenta.nro_documento, False)
                MyParams(12) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)

                Me.rvComprobante.LocalReport.SetParameters(MyParams)

                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(dsCabecera, DataTable)))
                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(ComprobanteDetalles, DataTable)))
            Else
                Dim MyParams(12) As Microsoft.Reporting.WinForms.ReportParameter

                If MyVenta.comprobante_tipo = "07" Then
                    MyVenta.tipo_operacion_nombre = dalTablasGenericas.ObtenerMotivoNotaCredito("000", IIf(MyVenta.tipo_operacion = "C1", "07", IIf(MyVenta.tipo_operacion = "C7", "01", "10")))
                End If

                MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pComprobanteNumero", ComprobanteNumero, False)
                MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteDireccion", ClienteDireccion, False)
                MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pMonedaDescripcion", MonedaDescripcion, False)
                MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pObservaciones", Observaciones, False)
                MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pEmpresa", Empresa, False)
                MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pVenta", Venta, False)
                MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", RazonSocial, False)
                MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pImporteTexto", ImporteTexto, False)
                MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoOperacionNombre", MyVenta.tipo_operacion_nombre, False)
                MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pPorcentajeIGV", PorcentajeIGV, False)
                MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pReferencia", Referencia, False)
                MyParams(11) = New Microsoft.Reporting.WinForms.ReportParameter("pRUC", MyVenta.nro_documento, False)
                MyParams(12) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)

                Me.rvComprobante.LocalReport.SetParameters(MyParams)

                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(dsCabecera, DataTable)))
                Me.rvComprobante.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(ComprobanteDetalles, DataTable)))
            End If
        End If

        Me.rvComprobante.DocumentMapCollapsed = True

        Me.rvComprobante.LocalReport.DisplayName = NombrePDF

        If MyUsuario.emite_ticket = False Then
            Me.rvComprobante.RefreshReport()
        Else
            clsImpresion.Imprimir(Me.rvComprobante.LocalReport)
        End If

        Dim warnings As Warning()
        Dim streamids As String()
        Dim mimeType As String
        Dim encoding As String
        Dim filenameExtension As String
        Dim bytes As Byte() = rvComprobante.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warnings)

        Dim fs As New FileStream(MyTempPath & "\" & NombrePDF & ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()

        If MyUsuario.emite_ticket = True Then Me.Close()

    End Sub

    Private Sub rvComprobante_Print(sender As Object, e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles rvComprobante.Print
        If e.Cancel = False Then
            ImpresionCancelada = False
            Me.Close()
        End If
    End Sub

End Class