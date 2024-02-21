Public Class frmGuiaRemitenteImprimir

    Private MyComprobante As dsGuiasRemitente.COMPROBANTEDataTable
    Private MyComprobanteDetalles As dsGuiasRemitente.GUIA_DETALLADataTable

    Private MyComprobanteSeries As dsGuiasRemitente.COMPROBANTE_SERIESDataTable

    Private MyGuia As entGuia
    Private MyNumeroGuia As String
    Private MyOperacion As String = ""
    Private MyVentaDirecta As String = ""

    Private MyMotivoTraslado As String

    Private RutaQR As String

    Private MyProductoVehicular As entProducto

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(NumeroGuia As String, Operacion As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyNumeroGuia = NumeroGuia
        MyOperacion = Operacion
    End Sub

    Public Sub New(Guia As entGuia, MotivoTraslado As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyGuia = Guia
        MyMotivoTraslado = MotivoTraslado

        Select Case MotivoTraslado
            Case Is = "VENTA" : MyVentaDirecta = MyGuia.venta
            Case Else : MyOperacion = MyGuia.referencia_cuo
        End Select
    End Sub

    Private Sub frmGuiaRemitente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Producto As String
        Dim Marca As String
        Dim Modelo As String

        Dim MySeries As String
        Dim MySeriesVehicular As String

        Dim TextoQR As String

        Dim MyParams(6) As Microsoft.Reporting.WinForms.ReportParameter

        Dim MyComprobanteSeriesVentaDirecta As dsVentas.COMPROBANTE_SERIESDataTable

        RutaQR = "file:///" & MyTempPath & "\QR.png"

        TextoQR = MyRUC & "|" & MyGuia.comprobante_tipo & "|" & MyGuia.comprobante_serie & "|" & MyGuia.comprobante_numero.Substring(2, 8) & "|" &
                  MyGuia.comprobante_fecha & "|" & MyGuia.destinatario_tipo_documento & "|" & MyGuia.destinatario_nro_documento & "|" & Space(1) & "|" & "" & "|"

        Call GenerarQR(TextoQR)

        MyComprobante = dalGuia.ObtenerComprobante(MyGuia.guia)
        MyComprobanteDetalles = dalGuia.GuiaDetallada(MyGuia.guia)

        MyComprobante(0).REFERENCIA = MyGuia.referencia

        If MyOperacion.Trim.Length <> 0 Then
            MyComprobanteSeries = dalOperacionAlmacen.ObtenerComprobanteSeries(MyOperacion)
        ElseIf MyVentaDirecta.Trim.Length <> 0 Then
            MyComprobanteSeries = New dsGuiasRemitente.COMPROBANTE_SERIESDataTable
            MyComprobanteSeriesVentaDirecta = dalVenta.ObtenerComprobanteSeriesVentaDirecta(MyVentaDirecta)
            If MyComprobanteSeriesVentaDirecta.Rows.Count <> -1 Then
                For NEle As Integer = 0 To MyComprobanteSeriesVentaDirecta.Rows.Count - 1
                    MyComprobanteSeries.Rows.Add(MyComprobanteSeriesVentaDirecta(NEle).PRODUCTO,
                                                 MyComprobanteSeriesVentaDirecta(NEle).NUMERO_SERIE,
                                                 MyComprobanteSeriesVentaDirecta(NEle).NUMERO_SERIE_CHASIS,
                                                 MyComprobanteSeriesVentaDirecta(NEle).COLOR)
                Next
            End If
        Else
            MyComprobanteSeries = dalGuia.ObtenerComprobanteSeries(MyNumeroGuia)
        End If

        If MyComprobanteDetalles.Rows.Count <> 0 Then
            For NFila As Integer = 0 To MyComprobanteDetalles.Rows.Count - 1
                If MyComprobanteDetalles(NFila).INDICA_SERIE = "SI" Then
                    MySeries = "SERIES: "
                    MySeriesVehicular = ""
                    Producto = MyComprobanteDetalles(NFila).PRODUCTO
                    If MyComprobanteSeries.Rows.Count <> 0 Then
                        For NFila2 As Integer = 0 To MyComprobanteSeries.Rows.Count - 1
                            If MyComprobanteSeries(NFila2).PRODUCTO = Producto Then
                                If MyComprobanteSeries(NFila2).NUMERO_SERIE_CHASIS.Trim.Length <> 0 Then
                                    MySeriesVehicular = MySeriesVehicular & vbCrLf & "MOTOR: " & MyComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / " &
                                    "CHASIS: " & MyComprobanteSeries(NFila2).NUMERO_SERIE_CHASIS.Trim & " / " &
                                    "COLOR: " & MyComprobanteSeries(NFila2).COLOR.Trim
                                Else
                                    MySeries = MySeries & MyComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / "
                                End If
                            End If
                        Next
                        MySeries = Strings.Left(MySeries, MySeries.Trim.Length - 2)
                    End If

                    If MySeriesVehicular = "" Then
                        MyComprobanteDetalles(NFila).DESCRIPCION = MyComprobanteDetalles(NFila).DESCRIPCION & " " & MySeries
                    Else
                        MyProductoVehicular = dalProducto.Obtener(MyUsuario.empresa, Producto)
                        Marca = ObtenerDescripcion("PRODUCTO_FAMILIA", MyProductoVehicular.producto_familia, False)
                        Modelo = ObtenerDescripcion("PRODUCTO_SUB_FAMILIA", MyProductoVehicular.producto_sub_familia, False)
                        MyComprobanteDetalles(NFila).DESCRIPCION = MyComprobanteDetalles(NFila).DESCRIPCION & " - MARCA: " & Marca & " - MODELO: " & Modelo & MySeriesVehicular
                    End If
                End If
            Next
        End If

        Me.rvGuiaRemitente.LocalReport.EnableExternalImages = True

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pMotivoTraslado", MyMotivoTraslado, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pDireccionPartida", MyGuia.punto_partida, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pDireccionLlegada", MyGuia.punto_llegada, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pConductor", MyGuia.conductor_nombre.Trim, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pNumeroPlaca", MyGuia.numero_placa, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaQR", RutaQR, False)
        MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pConductorDNI", MyGuia.conductor_dni.Trim, False)

        Me.rvGuiaRemitente.LocalReport.SetParameters(MyParams)

        Me.rvGuiaRemitente.LocalReport.DataSources.Clear()
        Me.rvGuiaRemitente.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(MyComprobante, DataTable)))
        Me.rvGuiaRemitente.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyComprobanteDetalles, DataTable)))
        Me.rvGuiaRemitente.DocumentMapCollapsed = True

        Me.rvGuiaRemitente.RefreshReport()
    End Sub
End Class