Public Class frmGenerarXML

    Private Sub frmGenerarXML_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmGenerarXML_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

#Region "Botones"
    Private Sub Salir() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim MyDocumentoXML As XDocument

        MyDocumentoXML = dalXML_Factura.CrearComunicacionBaja
        'MyDocumentoXML = dalXML_Factura.CrearResumenDiario
        MessageBox.Show("Proceso concluído", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

    End Sub

#End Region

End Class
