Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmTResumenDiarioImprimir
    Private Empresa As String
    Private Venta As String
    Private NombrePDF As String
    Private ComprobanteNumero As String
    Private ClienteDireccion As String
    Private MonedaDescripcion As String
    Private Observaciones As String
    Private RazonSocial As String
    Private ImporteTexto As String
    Private DocumentoIdentidad As String
    Private TextoQR As String

    Private dsCabecera As dsVentas.VENTASDataTable

    Private Sub frmTResumenDiarioImprimir_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyUsuarios As New dsTablasGenericas.DETALLESDataTable

        CadenaSQL = "SELECT * FROM GEN.TABLAS_DETALLE " & _
                    "WHERE RTRIM(TEXTO_03)= '001' AND CODIGO_TABLA = 'USUARIOS' AND ESTADO = 'ACT' AND  LOGICO_02 = 1 " & _
                    "ORDER BY CODIGO_ITEM "

        Call ObtenerDataTableSQL(CadenaSQL, Myusuarios)

        cmbUsuario.DataSource = MyUsuarios
        cmbUsuario.SelectedValue = MyUsuario.usuario

        txtFecha.Text = EvalDato(MyFechaServidor, txtFecha.Tag)
        btnRefrescar.Focus()
    End Sub

    Private Sub ImprimirResumen()
        Dim dsDetalles As New dsVentas.ECOMPROBANTES_RESUMEN_DIARIODataTable
        Dim dsPago As New dsVentas.VENTAS_PAGO_RESUMENDataTable
        Dim Turno As String = cmbUsuario.Text

        dsDetalles = dalVenta.ObtenerResumenDiario(txtFecha.Text, cmbUsuario.SelectedValue)
        dsPago = dalVenta.ObtenerResumenDiarioPago(txtFecha.Text, cmbUsuario.SelectedValue)

        Dim MyParams(0) As ReportParameter
        MyParams(0) = New ReportParameter("pTurno", Turno, False)
        Me.rvEBoletaVenta.LocalReport.EnableExternalImages = True
        Me.rvEBoletaVenta.LocalReport.SetParameters(MyParams)

        Me.rvEBoletaVenta.LocalReport.DataSources.Clear()
        Me.rvEBoletaVenta.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvEBoletaVenta.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsPago", DirectCast(dsPago, DataTable)))

        Me.rvEBoletaVenta.DocumentMapCollapsed = True

        If ckbHabilitarVistaPrevia.Checked = True Then
            Me.rvEBoletaVenta.RefreshReport()
        Else
            clsImpresion.Imprimir(Me.rvEBoletaVenta.LocalReport)
        End If

        If ckbHabilitarVistaPrevia.Checked = False Then Me.Close()

    End Sub

    Private Sub txtFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            btnRefrescar.Focus()
        End If
    End Sub

    Private Sub txtFecha_Validated(sender As Object, e As EventArgs) Handles txtFecha.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If txtFecha.Text.Trim.Length <> 0 Then
            Call ImprimirResumen()
        End If
    End Sub

End Class