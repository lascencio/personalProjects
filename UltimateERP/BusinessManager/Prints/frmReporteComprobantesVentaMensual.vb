﻿Public Class frmReporteComprobantesVentaMensual

    Private MyVentasExcel As New dsVentas.VENTAS_RESUMENDataTable

    Private Sub frmReporteComprobantesVentaMensual_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Ejercicio As Integer = 2019 To Now.Year + 1
            cmbAño.Items.Add(Ejercicio)
        Next
        cmbAño.Text = MyUsuario.ejercicio
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If cmbAño.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            Dim Ejercicio As String = cmbAño.Text
            Dim Mes As String = CStr(cmbMes.SelectedIndex + 1)

            Mes = Strings.Right("00" & Mes, 2)

            MyVentasExcel = dalVenta.ObtenerVentasExcel(MyUsuario.empresa, Ejercicio, Mes)

            Call RefrescarReporte()

            btnExportarExcel.Visible = True
        End If
    End Sub

    Private Sub RefrescarReporte()
        Dim MyParams(0) As Microsoft.Reporting.WinForms.ReportParameter
        Dim Periodo As String = cmbMes.Text & " - " & cmbAño.Text


        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", Periodo, False)

        Me.rvComprobantes.LocalReport.SetParameters(MyParams)

        Me.rvComprobantes.LocalReport.DataSources.Clear()
        Me.rvComprobantes.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyVentasExcel, DataTable)))
        Me.rvComprobantes.DocumentMapCollapsed = True

        Me.rvComprobantes.RefreshReport()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If MyVentasExcel.Rows.Count <> 0 Then
            Call ExportarExcel(MyProgressBar, MyVentasExcel)
        End If
    End Sub
End Class