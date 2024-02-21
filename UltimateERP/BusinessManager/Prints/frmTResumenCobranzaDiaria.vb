Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmTResumenCobranzaDiaria
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
        ActualizarLista(cmbAgencia, "A")
        cmbAgencia.SelectedValue = MyUser(0).AGENCIA_ASIGNADA
        txtFecha.Text = EvalDato(MyFechaServidor, txtFecha.Tag)
        btnRefrescar.Focus()
    End Sub

    Private Sub ImprimirResumen()
        Dim dsDetalles As dsFinanciero.COBRANZAS_DIARIASDataTable
        Dim Agencia As String = cmbAgencia.Text

        dsDetalles = dalFinanciamiento.ObtenerCobranzaDiaria(txtFecha.Text, cmbAgencia.SelectedValue)

        Dim MyParams(0) As ReportParameter
        MyParams(0) = New ReportParameter("pAgencia", Agencia, False)
        Me.rvCobranzas.LocalReport.EnableExternalImages = True
        Me.rvCobranzas.LocalReport.SetParameters(MyParams)

        Me.rvCobranzas.LocalReport.DataSources.Clear()
        Me.rvCobranzas.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))

        Me.rvCobranzas.DocumentMapCollapsed = True

        If ckbHabilitarVistaPrevia.Checked = True Then
            Me.rvCobranzas.RefreshReport()
        Else
            clsImpresion.Imprimir(Me.rvCobranzas.LocalReport)
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