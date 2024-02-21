Public Class frmReporteGuiasRemision
    Private MyEjercicio As String
    Private MyMes As String
    Private MyDia As Byte = 0
    Private MyEstado As String

    Private dsDetalles As dsGuiasRemitente.GUIAS_INFORMEDataTable

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmReporteGuiasRemision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For NEle = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = MyUsuario.mes - 1
        Call RefrescarReporte()
    End Sub

    Private Sub RefrescarReporte()
        Dim MyPeriodo As String = cmbMes.Text & "-" & cmbEjercicio.Text

        Dim MyParams(0) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", MyPeriodo, False)

        Me.rvGuias.LocalReport.SetParameters(MyParams)

        dsDetalles = dalGuia.GuiasInforme(MyEjercicio, MyMes, MyDia, "TODOS")

        Me.rvGuias.LocalReport.DataSources.Clear()
        Me.rvGuias.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvGuias.DocumentMapCollapsed = True

        Me.rvGuias.RefreshReport()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            Call RefrescarReporte()
        End If
    End Sub

    Private Sub cmbEjercicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEjercicio.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 Then
            MyEjercicio = cmbEjercicio.Text
            Call ActualizarDias()
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMes.SelectedIndexChanged
        If cmbMes.SelectedIndex <> -1 Then
            MyMes = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            Call ActualizarDias()
        End If
    End Sub

    Private Sub cmbDia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDia.SelectedIndexChanged
        If cmbDia.SelectedIndex = -1 Then
            MyDia = 0
        Else
            MyDia = CByte(cmbDia.Text)
        End If
    End Sub

    Private Sub ActualizarDias()
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            cmbDia.Items.Clear()
            FecIni = CDate("01/" & CStr(MyMes) & "/" & MyEjercicio)
            Do While Month(FecIni) = cmbMes.SelectedIndex + 1
                cmbDia.Items.Add(Strings.Right("00" & DateAndTime.Day(FecIni).ToString, 2))
                FecIni = DateAdd(DateInterval.Day, 1, FecIni)
            Loop
            MyDia = 0
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("NRO_GUIA", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("FECHA", Type.GetType("System.DateTime")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("RAZON_SOCIAL", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("COMPROBANTE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("USUARIO_REGISTRO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("ALMACEN_ORIGEN", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("ALMACEN_DESTINO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("USUARIO_ENVIO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("FECHA_ENVIO", Type.GetType("System.DateTime")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("ESTADO_ENVIO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("NRO_GUIA").MaxLength = 20
            .Columns("RAZON_SOCIAL").MaxLength = 100
            .Columns("COMPROBANTE").MaxLength = 20
            .Columns("USUARIO_REGISTRO").MaxLength = 20
            .Columns("ALMACEN_ORIGEN").MaxLength = 50
            .Columns("ALMACEN_DESTINO").MaxLength = 50
            .Columns("USUARIO_ENVIO").MaxLength = 20
            .Columns("ESTADO_ENVIO").MaxLength = 20
        End With

        If dsDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To dsDetalles.Rows.Count - 1
                With dsDetalles(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("NRO_GUIA") = .NRO_GUIA
                    MyDR.Item("FECHA") = .COMPROBANTE_FECHA
                    MyDR.Item("RAZON_SOCIAL") = .DESTINATARIO_RAZON_SOCIAL
                    MyDR.Item("COMPROBANTE") = .NRO_COMPROBANTE
                    MyDR.Item("USUARIO_REGISTRO") = .USUARIO_REGISTRO
                    MyDR.Item("ALMACEN_ORIGEN") = .ALMACEN_DECRIPCION
                    MyDR.Item("ALMACEN_DESTINO") = .ALMACEN_DESTINO_DESCRIPCION
                    MyDR.Item("USUARIO_ENVIO") = .USUARIO_ENVIO
                    If .FECHA_ENVIO.Year <> 1900 Then MyDR.Item("FECHA_ENVIO") = .FECHA_ENVIO
                    MyDR.Item("ESTADO_ENVIO") = .ESTADO_ENVIO
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub
End Class