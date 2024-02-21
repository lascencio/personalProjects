Public Class frmEnviarXML

    Private Sub frmEnviarXML_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmEnviarXML_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

#Region "Botones"
    Private Sub Salir() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        If dalXML_Factura.EnviarComunicacionBaja = True Then
            MessageBox.Show("Documento enviado exitosamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        'If dalXML_Factura.EnviarResumenDiario = True Then
        '    MessageBox.Show("Documento enviado exitosamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End If

    End Sub

#End Region


End Class
