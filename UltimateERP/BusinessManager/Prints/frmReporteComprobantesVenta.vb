Imports Microsoft.Reporting.WinForms

Public Class frmReporteComprobantesVenta

    Private RangoFechas As String

    Private MyEjercicio As String
    Private MyMes As String
    Private MyDia As Byte = 0
    Private MyTipoComprobante As String = "TODOS"
    Private MyTipoOperacion As String = "TODOS"

    Private MyEstado As String

    Private dsDetalles As dsVentas.VENTAS_INFORMEDataTable

    Private dsDetallesVenta As dsVentas.COMPROBANTE_DETALLESDataTable

    Private dsDetallesVentaSeries As dsVentas.RELACION_SERIESDataTable

    Private dsSeries As dsVentas.COMPROBANTE_SERIESDataTable

    Private MyCuentaComercial As entCuentaComercial

    Private MyVenta As String
    Private MyGuia As String


    Private MyLocalReport As LocalReport
    Private MyCurrentReport As String = ""

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(Ejercicio As String, Mes As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyEjercicio = Ejercicio
        MyMes = Mes
    End Sub

    Private Sub frmComprobantesVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechaDesde As Date = "1/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio
        Dim FechaHasta As Date = Now.Day.ToString & "/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio

        'ActualizarListaEmpresa(cmbTipoVenta, "COM_TIPO_VENTA")

        cmbVendedor.DataSource = ObtenerListaEmpresa("STD_VENDEDORES", "DESCRIPCION")

        cmbTipoVenta.DataSource = ObtenerListaEmpresa("COM_TIPO_VENTA", "DESCRIPCION")

        'For NEle = 2019 To Year(Now)
        '    cmbEjercicio.Items.Add(NEle)
        'Next

        'cmbEjercicio.Text = MyEjercicio
        'cmbMes.SelectedIndex = CByte(MyMes) - 1

        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")

        EnableTextBox(txtDocumentoNumero, False)

        txtFechaDesde.Text = EvalDato(FechaDesde, "F")
        txtFechaHasta.Text = EvalDato(FechaHasta, "F")

        txtFechaDesde.Focus()

        cmbComprobanteTipo.SelectedIndex = 0
        cmbDocumentoTipo.SelectedIndex = -1

    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            Select Case sender.Text
                Case Is = "TODOS" : MyTipoComprobante = "TODOS"
                Case Is = "BOLETA" : MyTipoComprobante = "03"
                Case Is = "FACTURA" : MyTipoComprobante = "01"
                Case Is = "NOTA DE CREDITO" : MyTipoComprobante = "07"
                Case Is = "NOTA DE DEBITO" : MyTipoComprobante = "08"
            End Select
        End If
    End Sub

    Private Sub cmbTipoVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoVenta.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            MyTipoOperacion = sender.SelectedValue
        End If
    End Sub

    Private Sub txtFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaDesde.KeyDown, txtFechaHasta.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            If sender.Name = "txtFechaDesde" Then
                txtFechaHasta.Focus()
            Else
                btnRefrescar.Focus()
            End If
        End If
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaDesde.Validated, txtFechaHasta.Validated
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = EvalDato(sender.Text, sender.Tag)
            If sender.Name = "txtFechaDesde" Then
                txtFechaHasta.Focus()
            Else
                btnRefrescar.Focus()
            End If
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "SN")
                MyForm.ShowDialog()
                If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyCuentaComercial.cuenta_comercial)
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                With MyCuentaComercial
                    txtCuentaComercial.Text = .cuenta_comercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                End With
            End If
        End If

    End Sub

    Private Sub ckbClienteTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbClienteTodos.CheckedChanged
        txtDocumentoNumero.Text = Nothing
        txtCuentaComercial.Text = Nothing
        txtRazonSocial.Text = Nothing

        If ckbClienteTodos.Checked = False Then
            EnableComboBox(cmbDocumentoTipo, True)
            EnableTextBox(txtDocumentoNumero, True)
            txtDocumentoNumero.Focus()
        Else
            EnableComboBox(cmbDocumentoTipo, False)
            EnableTextBox(txtDocumentoNumero, False)
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        'If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
        '    Call RefrescarReporte()
        'End If

        Dim MyFechaDesde As String
        Dim MyFechaHasta As String

        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 Then
            MyFechaDesde = txtFechaDesde.Text.Substring(6, 4) & "-" & txtFechaDesde.Text.Substring(3, 2) & "-" & txtFechaDesde.Text.Substring(0, 2)
            MyFechaHasta = txtFechaHasta.Text.Substring(6, 4) & "-" & txtFechaHasta.Text.Substring(3, 2) & "-" & txtFechaHasta.Text.Substring(0, 2)
            RangoFechas = "DESDE EL " & txtFechaDesde.Text & " AL " & txtFechaHasta.Text
            dsDetalles = dalVenta.ComprobantesInforme(MyFechaDesde, MyFechaHasta, txtCuentaComercial.Text, MyTipoComprobante, cmbVendedor.SelectedValue, MyTipoOperacion)

            Call RefrescarReporte()
        End If
    End Sub

    Private Sub RefrescarReporte()
        If MyCurrentReport.Trim.Length <> 0 Then
            If MyCurrentReport = "rptDetallesVentaSeries" Then
                Me.rvComprobantes.PerformBack()
                Me.rvComprobantes.PerformBack()
            Else
                Me.rvComprobantes.PerformBack()
            End If
        End If

        Dim MyParams(1) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", RangoFechas, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pVendedor", cmbVendedor.Text, False)

        Me.rvComprobantes.LocalReport.SetParameters(MyParams)

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                If dsDetalles(NEle).ESTADO = "N" Then
                    dsDetalles(NEle).IMPORTE_TOTAL_MN = 0
                    dsDetalles(NEle).IMPORTE_TOTAL_ME = 0
                Else
                    If ckbImportesSinIGV.Checked = True Then
                        dsDetalles(NEle).IMPORTE_TOTAL_MN = dsDetalles(NEle).VALOR_VENTA_MN
                        dsDetalles(NEle).IMPORTE_TOTAL_ME = dsDetalles(NEle).VALOR_VENTA_ME
                    Else
                        dsDetalles(NEle).IMPORTE_TOTAL_MN = dsDetalles(NEle).PRECIO_VENTA_MN
                        dsDetalles(NEle).IMPORTE_TOTAL_ME = dsDetalles(NEle).PRECIO_VENTA_ME
                    End If
                End If
            Next
        End If

        Me.rvComprobantes.LocalReport.DataSources.Clear()
        Me.rvComprobantes.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvComprobantes.DocumentMapCollapsed = True

        'Add a handler dor drillthrough.
        AddHandler rvComprobantes.Drillthrough, AddressOf MyDrillThroughEventHandler

        Me.rvComprobantes.RefreshReport()

        btnExportarExcel.Visible = IIf(dsDetalles.Rows.Count <> 0, True, False)
    End Sub

    Private Sub MyDrillThroughEventHandler(ByVal sender As Object, ByVal e As DrillthroughEventArgs)
        Dim DrillThroughValues As ReportParameterInfoCollection = e.Report.GetParameters()
        MyLocalReport = e.Report
        MyCurrentReport = e.ReportPath

        Dim MyValue1 As ReportParameterInfo
        Dim MyValue2 As ReportParameterInfo
        Dim MyValue3 As ReportParameterInfo

        Dim MySeries As String = ""
        Dim MyProducto As String

        MyLocalReport.DataSources.Clear()

        If MyCurrentReport = "rptDetallesVentaSeries" Then
            dsDetallesVentaSeries = New dsVentas.RELACION_SERIESDataTable
            MyValue3 = DrillThroughValues.Item("pProducto")
            MyProducto = MyValue3.Values(0).ToString

            If dsSeries.Rows.Count <> 0 Then
                For NEle As Integer = 0 To dsSeries.Rows.Count - 1
                    If dsSeries(NEle).PRODUCTO = MyProducto Then
                        MySeries = MySeries & dsSeries(NEle).NUMERO_SERIE & " / "
                    End If
                Next
                If MySeries <> "" Then
                    MySeries = Strings.Left(MySeries, MySeries.Trim.Length - 2)
                Else
                    MySeries = "NO SE ENCONTRARON SERIES REGISTRADAS PARA ESTE PRODUCTO"
                End If
            Else
                MySeries = "NO SE ENCONTRARON SERIES REGISTRADAS PARA ESTE PRODUCTO"
            End If

            dsDetallesVentaSeries.Rows.Add(MyProducto, MySeries)
            MyLocalReport.Refresh()


            MyLocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetallesVentaSeries", DirectCast(dsDetallesVentaSeries, DataTable)))

        Else
            MyValue1 = DrillThroughValues.Item("pVenta")
            MyValue2 = DrillThroughValues.Item("pGuia")

            MyVenta = MyValue1.Values(0).ToString
            MyGuia = MyValue2.Values(0).ToString

            dsDetallesVenta = dalVenta.ObtenerComprobanteDetalles(MyVenta)
            dsSeries = dalVenta.ObtenerComprobanteSeries(MyGuia)

            If dsSeries.Rows.Count = 0 Then
                dsSeries = dalVenta.ObtenerComprobanteSeriesVentaDirecta(MyVenta)
            End If

            MyLocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetallesVenta", DirectCast(dsDetallesVenta, DataTable)))

            MyLocalReport.Refresh()
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Call ExportarExcel(MyProgressBar, dsDetalles)
    End Sub

End Class