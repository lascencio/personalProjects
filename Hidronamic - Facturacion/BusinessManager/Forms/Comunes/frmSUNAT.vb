Imports LibSunat

Public Class frmSUNAT

    Private Sub frmSUNAT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        'Dim ruc As String = txtRUC.Text.Trim
        'Dim myRuc As New Contribuyente(ruc)

        'If String.IsNullOrEmpty(myRuc.[Error]) Then
        '    txtRazonSocial.Text = myRuc.GetInfo.RazonSocial
        '    txtAntiguoRuc.Text = myRuc.GetInfo.AntiguoRuc
        '    txtEstado.Text = myRuc.GetInfo.Estado
        '    Me.txtEsAgenteRetencion.Text = myRuc.GetInfo.EsAgenteRetencion
        '    txtNombreComercial.Text = myRuc.GetInfo.NombreComercial
        '    txtDireccion.Text = myRuc.GetInfo.Direccion
        '    txtTelefono.Text = myRuc.GetInfo.Telefono
        '    txtDependencia.Text = myRuc.GetInfo.Dependencia
        '    Me.txtTipoEmpresa.Text = myRuc.GetInfo.Tipo
        'Else
        '    Resp = MsgBox(myRuc.[Error], MsgBoxStyle.Information, Me.Text)
        'End If

    End Sub

    Private Sub LimpiarFormulario()
        For Each ctrl As Object In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.name <> "txtRUC" Then
                    Select Case ctrl.tag
                        Case Is = "V" : ctrl.text = "0.0000"
                        Case Is = "C" : ctrl.text = "0.000"
                        Case Is = "D" : ctrl.text = "0.00"
                        Case Is = "E" : ctrl.text = "0"
                        Case Else : ctrl.text = Nothing
                    End Select
                End If
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.SelectedIndex = -1
            End If
        Next
    End Sub

    Private Sub txtRUC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUC.TextChanged
        Call LimpiarFormulario()
    End Sub

End Class