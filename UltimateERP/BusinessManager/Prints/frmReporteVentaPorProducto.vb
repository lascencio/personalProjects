Imports Microsoft.Reporting.WinForms

Public Class frmReporteVentaPorProducto
    Private RangoFechas As String

    Private MyProducto As entProducto

    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MyTipos As dsTablasGenericas.LISTADataTable

    Private dsDetalles As dsVentas.VENTA_DETALLADataTable

    Private MyEstado As String

    Private dsDetallesVenta As dsVentas.COMPROBANTE_DETALLESDataTable

    Private dsDetallesVentaSeries As dsVentas.RELACION_SERIESDataTable

    Private dsSeries As dsVentas.COMPROBANTE_SERIESDataTable

    Private MyCuentaComercial As entCuentaComercial

    Private MyVenta As String
    Private MyGuia As String

    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmReporteVentaDetallada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmReporteVentaDetallada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")

        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")
        MyTipos = ObtenerListaEmpresa("PRODUCTO_TIPO", "DESCRIPCION")

        dsDetalles = New dsVentas.VENTA_DETALLADataTable

        cmbFamilia.DataSource = MyFamilias
        cmbTipo.DataSource = MyTipos

        EnableTextBox(txtProducto, False)
        EnableTextBox(txtDocumentoNumero, False)

        cmbDocumentoTipo.SelectedIndex = -1
        cmbTipoMoneda.Text = "SOLES"
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

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        txtProducto.Text = Nothing
        txtProductoDesdeNombre.Text = Nothing

        If ckbProductoTodos.Checked = False Then
            EnableTextBox(txtProducto, True)
            EnableComboBox(cmbFamilia, False)
            EnableComboBox(cmbTipo, False)
            cmbFamilia.SelectedIndex = 0
            cmbTipo.SelectedIndex = 0
            txtProducto.Focus()
        Else
            EnableTextBox(txtProducto, False)
            EnableComboBox(cmbFamilia, True)
            EnableComboBox(cmbTipo, True)
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub ckbClienteTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbClienteTodos.CheckedChanged
        txtDocumentoNumero.Text = Nothing
        txtCuentaComercial.Text = Nothing
        txtRazonSocial.Text = Nothing

        If ckbClienteTodos.Checked = False Then
            EnableTextBox(txtDocumentoNumero, True)
            txtDocumentoNumero.Focus()
        Else
            EnableTextBox(txtDocumentoNumero, False)
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub ValidarProducto(ByVal sender As Object)
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = sender.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            btnRefrescar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
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

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        Dim MyFechaDesde As String
        Dim MyFechaHasta As String

        Dim PrecioUnitario As Decimal
        Dim ValorVenta As Decimal
        Dim Impuesto As Decimal
        Dim PrecioVenta As Decimal

        Dim Cliente As String
        Dim Producto As String

        Cliente = IIf(ckbClienteTodos.Checked = True, "TODOS", txtCuentaComercial.Text)
        Producto = IIf(ckbProductoTodos.Checked = True, "TODOS", txtProducto.Text)

        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 Then
            MyFechaDesde = txtFechaDesde.Text.Substring(6, 4) & "-" & txtFechaDesde.Text.Substring(3, 2) & "-" & txtFechaDesde.Text.Substring(0, 2)
            MyFechaHasta = txtFechaHasta.Text.Substring(6, 4) & "-" & txtFechaHasta.Text.Substring(3, 2) & "-" & txtFechaHasta.Text.Substring(0, 2)
            RangoFechas = "DESDE EL " & txtFechaDesde.Text & " AL " & txtFechaHasta.Text

            dsDetalles = dalVenta.VentaDetallada(MyFechaDesde, MyFechaHasta, cmbFamilia.SelectedValue, cmbTipo.SelectedValue, Cliente, Producto)

            If ckbClienteTodos.Checked = False And txtCuentaComercial.Text.Trim.Length <> 0 And txtDocumentoNumero.Text.Trim.Length <> 0 Then
                If dsDetalles.Rows.Count <> 0 Then
                    Dim dsDetallesNew As New dsVentas.VENTA_DETALLADataTable
                    For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                        If dsDetalles(NEle).CUENTA_COMERCIAL.Trim = txtCuentaComercial.Text.Trim Then
                            dsDetallesNew.ImportRow(dsDetalles(NEle))
                        End If
                    Next
                    dsDetalles = dsDetallesNew
                End If
            End If

            If dsDetalles.Rows.Count <> 0 Then
                For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                    If cmbTipoMoneda.SelectedValue = "1" Then
                        If dsDetalles(NEle).TIPO_MONEDA = "2" Then
                            PrecioUnitario = dsDetalles(NEle).PRECIO_UNITARIO * dsDetalles(NEle).TIPO_CAMBIO
                            ValorVenta = dsDetalles(NEle).VALOR_VENTA * dsDetalles(NEle).TIPO_CAMBIO
                            Impuesto = dsDetalles(NEle).IMPUESTO * dsDetalles(NEle).TIPO_CAMBIO
                            PrecioVenta = dsDetalles(NEle).PRECIO_VENTA * dsDetalles(NEle).TIPO_CAMBIO

                            dsDetalles(NEle).PRECIO_UNITARIO = Math.Round(PrecioUnitario, 2)
                            dsDetalles(NEle).VALOR_VENTA = Math.Round(ValorVenta, 2)
                            dsDetalles(NEle).IMPUESTO = Math.Round(Impuesto, 2)
                            dsDetalles(NEle).PRECIO_VENTA = Math.Round(PrecioVenta, 2)
                        End If
                    Else
                        If dsDetalles(NEle).TIPO_MONEDA = "1" Then
                            If dsDetalles(NEle).TIPO_CAMBIO <> 0 Then
                                PrecioUnitario = dsDetalles(NEle).PRECIO_UNITARIO / dsDetalles(NEle).TIPO_CAMBIO
                                ValorVenta = dsDetalles(NEle).VALOR_VENTA / dsDetalles(NEle).TIPO_CAMBIO
                                Impuesto = dsDetalles(NEle).IMPUESTO / dsDetalles(NEle).TIPO_CAMBIO
                                PrecioVenta = dsDetalles(NEle).PRECIO_VENTA / dsDetalles(NEle).TIPO_CAMBIO
                            Else
                                PrecioUnitario = dsDetalles(NEle).PRECIO_UNITARIO / 1
                                ValorVenta = dsDetalles(NEle).VALOR_VENTA / 1
                                Impuesto = dsDetalles(NEle).IMPUESTO / 1
                                PrecioVenta = dsDetalles(NEle).PRECIO_VENTA / 1

                            End If

                            dsDetalles(NEle).PRECIO_UNITARIO = Math.Round(PrecioUnitario, 2)
                            dsDetalles(NEle).VALOR_VENTA = Math.Round(ValorVenta, 2)
                            dsDetalles(NEle).IMPUESTO = Math.Round(Impuesto, 2)
                            dsDetalles(NEle).PRECIO_VENTA = Math.Round(PrecioVenta, 2)
                        End If
                    End If
                Next
            End If

            Call RefrescarReporte()
        End If
    End Sub

    Private Sub RefrescarReporte()
        Dim MyParams(1) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pRangoFechas", RangoFechas, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pReexpresado", cmbTipoMoneda.Text, False)

        Me.rvVentaDetallada.LocalReport.SetParameters(MyParams)

        Me.rvVentaDetallada.LocalReport.DataSources.Clear()
        Me.rvVentaDetallada.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvVentaDetallada.DocumentMapCollapsed = True

        'Add a handler dor drillthrough.
        AddHandler rvVentaDetallada.Drillthrough, AddressOf MyDrillThroughEventHandler

        Me.rvVentaDetallada.RefreshReport()
    End Sub

    Private Sub MyDrillThroughEventHandler(ByVal sender As Object, ByVal e As DrillthroughEventArgs)
        Dim DrillThroughValues As ReportParameterInfoCollection = e.Report.GetParameters()
        Dim MyLocalReport As LocalReport = e.Report
        Dim MyCurrentReport As String = e.ReportPath

        Dim MyValue1 As ReportParameterInfo
        Dim MyValue2 As ReportParameterInfo
        Dim MyValue3 As ReportParameterInfo

        Dim MySeries As String = ""
        Dim MyProducto As String

        MyLocalReport.DataSources.Clear()

        If MyCurrentReport = "rptDetallesVentaSeries" Then
            If dsSeries.Rows.Count <> 0 Then
                dsDetallesVentaSeries = New dsVentas.RELACION_SERIESDataTable
                MyValue3 = DrillThroughValues.Item("pProducto")
                MyProducto = MyValue3.Values(0).ToString
                For NEle As Integer = 0 To dsSeries.Rows.Count - 1
                    If dsSeries(NEle).PRODUCTO = MyProducto Then
                        MySeries = MySeries & dsSeries(NEle).NUMERO_SERIE & " / "
                    End If
                Next
                If MySeries <> "" Then
                    MySeries = Strings.Left(MySeries, MySeries.Trim.Length - 2)
                    dsDetallesVentaSeries.Rows.Add(MyProducto, MySeries)
                    MyLocalReport.Refresh()
                Else
                    Resp = MsgBox("El producto indicado no tiene series.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SERIES DEL PRODUCTO")
                    e.Cancel = True
                End If
            End If
            MyLocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetallesVentaSeries", DirectCast(dsDetallesVentaSeries, DataTable)))
        Else
            MyValue1 = DrillThroughValues.Item("pVenta")
            MyValue2 = DrillThroughValues.Item("pGuia")

            MyVenta = MyValue1.Values(0).ToString
            MyGuia = MyValue2.Values(0).ToString

            dsDetallesVenta = dalVenta.ObtenerComprobanteDetalles(MyVenta)
            dsSeries = dalVenta.ObtenerComprobanteSeries(MyGuia)

            MyLocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetallesVenta", DirectCast(dsDetallesVenta, DataTable)))

            MyLocalReport.Refresh()
        End If


    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("PRODUCTO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("NRO_COMPROBANTE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("FECHA", Type.GetType("System.DateTime")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("NRO_GUIA", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("RAZON_SOCIAL", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("CANTIDAD", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRECIO_UNITARIO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("VALOR_VENTA", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("IMPUESTO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRECIO_VENTA", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("PRODUCTO").MaxLength = 500
            .Columns("NRO_COMPROBANTE").MaxLength = 500
            .Columns("NRO_GUIA").MaxLength = 500
            .Columns("RAZON_SOCIAL").MaxLength = 1000
        End With

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                With dsDetalles(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("PRODUCTO") = .DESCRIPCION
                    MyDR.Item("NRO_COMPROBANTE") = .NRO_COMPROBANTE
                    If .COMPROBANTE_FECHA.Year <> 1900 Then MyDR.Item("FECHA") = .COMPROBANTE_FECHA
                    MyDR.Item("NRO_GUIA") = .NRO_GUIA
                    MyDR.Item("RAZON_SOCIAL") = .RAZON_SOCIAL
                    MyDR.Item("CANTIDAD") = .CANTIDAD
                    MyDR.Item("PRECIO_UNITARIO") = .PRECIO_UNITARIO
                    MyDR.Item("VALOR_VENTA") = .VALOR_VENTA
                    MyDR.Item("IMPUESTO") = .IMPUESTO
                    MyDR.Item("PRECIO_VENTA") = .PRECIO_VENTA
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub
End Class