Public Class frmFirmarXML

    Private Sub frmFirmarXML_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub


    Private Sub frmFirmarXML_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

#Region "Botones"
    Private Sub Salir() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""

        If dalXML_Factura.FirmarComunicacionBaja(DigestValue, SignatureValue) = True Then
            MessageBox.Show("Documento firmado exitosamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        'If dalXML_Factura.FirmarResumenDiario = True Then
        '    MessageBox.Show("Documento firmado exitosamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End If

    End Sub


#End Region
End Class
