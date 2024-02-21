Public Class frmReporteComprobantesVenta
    Private RangoFechas As String

    Private MyEjercicio As String
    Private MyMes As String
    Private MyDia As Byte = 0
    Private MyTipoComprobante As String = "TODOS"

    Private MyEstado As String
    Private MyVentas As dsVentas.VENTAS_LISTADataTable
    Private MyVenta As entVenta
    Private MyCuentaComercial As entCuentaComercial
    Private MyCliente As entCliente
    Private MyAccion As String = "NUEVO"
    Private MyGuia As String


    'Private MyLocalReport As LocalReport
    Private MyCurrentReport As String = ""
    Public Sub New(Ejercicio As String, Mes As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyEjercicio = Ejercicio
        MyMes = Mes
    End Sub

    Private Sub frmReporteComprobantesVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechaDesde As Date = "1/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio
        Dim FechaHasta As Date = Now.Day.ToString & "/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio
        Dim MyDT As New dsClientes.CLIENTES_COMPROBANTESDataTable
        Dim Cadena As String = "SELECT * FROM COM.CLIENTES_COMPROBANTES ORDER BY RAZON_SOCIAL"
        ObtenerDataTableSQL(Cadena, MyDT)

        cmbClientes.DataSource = MyDT

        'ActualizarListaEmpresa(cmbTipoVenta, "COM_TIPO_VENTA")

        'For NEle = 2017 To Year(Now)
        '    cmbEjercicio.Items.Add(NEle)
        'Next

        'cmbEjercicio.Text = MyEjercicio
        'cmbMes.SelectedIndex = CByte(MyMes) - 1

        txtFechaDesde.Text = EvalDato(FechaDesde, "F")
        txtFechaHasta.Text = EvalDato(FechaHasta, "F")

        txtFechaDesde.Focus()

        cmbComprobanteTipo.SelectedIndex = 0
    End Sub
    Private Sub cmbComprobanteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            Select Case sender.Text
                Case Is = Space(1) : MyTipoComprobante = "TODOS"
                Case Is = "BOLETA" : MyTipoComprobante = "BV"
                Case Is = "FACTURA" : MyTipoComprobante = "FT"
                Case Is = "NOTA DE CREDITO" : MyTipoComprobante = "NC"
                Case Is = "NOTA DE DEBITO" : MyTipoComprobante = "NB"
            End Select
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

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        Dim MyFechaDesde As String
        Dim MyFechaHasta As String

        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 Then
            MyFechaDesde = txtFechaDesde.Text.Substring(6, 4) & "-" & txtFechaDesde.Text.Substring(3, 2) & "-" & txtFechaDesde.Text.Substring(0, 2)
            MyFechaHasta = txtFechaHasta.Text.Substring(6, 4) & "-" & txtFechaHasta.Text.Substring(3, 2) & "-" & txtFechaHasta.Text.Substring(0, 2)
            RangoFechas = "DESDE EL " & txtFechaDesde.Text & " AL " & txtFechaHasta.Text
            MyVentas = dalVenta.ComprobantesInforme(MyFechaDesde, MyFechaHasta, cmbClientes.SelectedValue, MyTipoComprobante)

            Call RefrescarReporte()
        End If
    End Sub

    Private Sub RefrescarReporte()
        Dim MyParams(0) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", RangoFechas, False)

        Me.rvComprobantes.LocalReport.SetParameters(MyParams)

        'If dsDetalles.Rows.Count <> 0 Then
        '    For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
        '        If dsDetalles(NEle).ESTADO = "N" Then
        '            dsDetalles(NEle).IMPORTE_TOTAL_MN = 0
        '            dsDetalles(NEle).IMPORTE_TOTAL_ME = 0
        '        Else
        '            If ckbImportesSinIGV.Checked = True Then
        '                dsDetalles(NEle).IMPORTE_TOTAL_MN = dsDetalles(NEle).VALOR_VENTA_MN
        '                dsDetalles(NEle).IMPORTE_TOTAL_ME = dsDetalles(NEle).VALOR_VENTA_ME
        '            Else
        '                dsDetalles(NEle).IMPORTE_TOTAL_MN = dsDetalles(NEle).PRECIO_VENTA_MN
        '                dsDetalles(NEle).IMPORTE_TOTAL_ME = dsDetalles(NEle).PRECIO_VENTA_ME
        '            End If
        '        End If
        '    Next
        'End If

        Me.rvComprobantes.LocalReport.DataSources.Clear()
        Me.rvComprobantes.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsVentas", DirectCast(MyVentas, DataTable)))
        Me.rvComprobantes.DocumentMapCollapsed = True

        Me.rvComprobantes.RefreshReport()
    End Sub
End Class