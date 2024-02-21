Public Class frmMigrar

    Private D1, D2, D3, D4, D5, D6, D7, D8, D9 As String
    Private D10 As Decimal

    Private Sub frmMigrar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmMigrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For NEle = 2013 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next
        cmbEjercicio.Text = Now.Year
        cmbMes.SelectedIndex = (Now.Month) - 1
    End Sub

    Private Sub txtTipoCambio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoCambio.Validated
        sender.text = EvalDato(sender.text, sender.tag)
    End Sub

    Private Sub btnMigrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrar.Click
        If txtTipoCambio.Text <> "0.000" Then
            Dim MyDT_Detalle As New dsMigrarDetalles.MIGRAR_DETALLESDataTable

            MyDT_Detalle = dalMigrar.EjecutarProcesos(MyProgressBar, "00BX", cmbEjercicio.Text, Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2), CDec(txtTipoCambio.Text))

            gvCabeceras.DataSource = MyDT_Detalle

            If MyDT_Detalle.Rows.Count = 0 Then
                Resp = MsgBox("No existe información a migrar para el período seleccionado.", MsgBoxStyle.Exclamation, " MIGRAR INFORMACION")
            Else
                Resp = MsgBox("La información se migró satisfactoriamente." & Chr(13) & "ADVERTENCIA: Es necesario reindexar el CONCAR.", MsgBoxStyle.Information, " MIGRAR INFORMACION")
            End If
        End If
    End Sub

End Class