Public Class frmValidarXML

    Private Sub frmValidarXML_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmValidarXML_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

#Region "Botones"
    Private Sub Salir() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Try
            If dalXML_Factura.ValidarDocumento = True Then
                MessageBox.Show("Validación exitosa", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region
End Class
