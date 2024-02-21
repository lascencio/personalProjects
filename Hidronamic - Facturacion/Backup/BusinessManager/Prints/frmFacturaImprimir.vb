Public Class frmFacturaImprimir

    Private MyFactura As entFactura

    Sub New(ByVal Factura As entFactura)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyFactura = Factura
    End Sub

    Private Sub frmFacturaImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyParams(18) As Microsoft.Reporting.WinForms.ReportParameter

        Dim MyDia As String
        Dim MyMes As String
        Dim MyAño As String
        Dim MyValorVenta As String
        Dim MyIGV As String
        Dim MyPrecioVenta As String
        Dim MyImagen As String = "D:\Local Win Applications\SoftBusiness_BINARIX\BusinessManager\Images\Factura Binarix.jpg"
        Dim MyGlosaDetraccion As String = "SUJETO A DETRACCION " & EvalDato(MyDetraccion, "EC") & "% CTA. B. NACION 00046-041984"

        With MyFactura
            MyDia = .Fecha_Emision.Day.ToString
            MyMes = EvalMes(.Fecha_Emision.Month, "L")
            MyAño = .Fecha_Emision.Year
            MyValorVenta = EvalDato(.Valor_Venta, "D")
            MyIGV = EvalDato(.IGV, "D")
            MyPrecioVenta = EvalDato(.Precio_Venta, "D")
        End With

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pDocumentoSerie", MyFactura.Documento_Serie, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pDocumentoNumero", MyFactura.Documento_Numero, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pDia", MyDia, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pMes", MyMes, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pAño", MyAño, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pRazonSocial", MyFactura.Razon_Social, False)
        MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pRUC", MyFactura.RUC, False)
        MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pDomicilio_1", MyFactura.Domicilio_01, False)
        MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pDomicilio_2", MyFactura.Domicilio_02, False)
        MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pPrecioVentaTexto", MyFactura.Precio_Venta_Texto, False)
        MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pValorVenta", MyValorVenta, False)
        MyParams(11) = New Microsoft.Reporting.WinForms.ReportParameter("pIGV", MyIGV, False)
        MyParams(12) = New Microsoft.Reporting.WinForms.ReportParameter("pPrecioVenta", MyPrecioVenta, False)
        MyParams(13) = New Microsoft.Reporting.WinForms.ReportParameter("pMoneda", MyFactura.Tipo_Moneda, False)
        MyParams(14) = New Microsoft.Reporting.WinForms.ReportParameter("pRutaImagen", MyImagen, False)
        MyParams(15) = New Microsoft.Reporting.WinForms.ReportParameter("pGlosaDetraccion", MyGlosaDetraccion, False)
        MyParams(16) = New Microsoft.Reporting.WinForms.ReportParameter("pContactoCliente", MyFactura.Contacto_Cliente & " ", False)
        MyParams(17) = New Microsoft.Reporting.WinForms.ReportParameter("pContactoVenta", MyFactura.Contacto_Venta & " ", False)
        MyParams(18) = New Microsoft.Reporting.WinForms.ReportParameter("pCondicionPago", MyFactura.Condicion_Pago, False)

        Me.rvFactura.LocalReport.SetParameters(MyParams)
        Me.rvFactura.LocalReport.DataSources.Clear()

        Dim MyDT As New dsVentas.VENTAS_SERDataTable
        MyDT = dalVenta.ObtenerVentaServicio(MyFactura.Venta)

        Me.rvFactura.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsVentas_VENTAS_SER", MyDT))

        'Me.rvFactura.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

        Me.rvFactura.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage

        Me.rvFactura.RefreshReport()

    End Sub

    Private Sub rvFactura_Print(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rvFactura.Print
        'Me.rvFactura.LocalReport.
    End Sub

End Class