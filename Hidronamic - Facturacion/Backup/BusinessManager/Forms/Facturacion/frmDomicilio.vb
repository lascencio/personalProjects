Public Class frmDomicilio

    Private MyAnexo As entCONCAR_Anexo
    Private MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable

    Private Sub frmDomicilio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmDomicilio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LimpiarFormulario()
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
    End Sub

    Private Sub txtAnexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnexo.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCliente As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyAnexo = New entCONCAR_Anexo
            MyDomicilio = New dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable
            If String.IsNullOrEmpty(sender.Text.Trim) Then
                Dim MyForm As New frmAnexoLista(MyAnexo, "CLIENTE")
                MyForm.ShowDialog()
            Else
                MyCliente = sender.Text.Trim
                MyAnexo = dalCONCAR_Anexo.ObtenerCliente(MyCliente)
            End If
            If Not MyAnexo.acodane Is Nothing Then
                txtAnexo.Text = MyAnexo.acodane.Trim
                txtAnexoNombre.Text = MyAnexo.adesane.Trim
                txtAvAnexo.Text = MyAnexo.avanexo.Trim
                txtDomicilio.Text = MyAnexo.arefane.Trim
                MyDomicilio = dalVenta.ObtenerDomicilio(txtAnexo.Text, txtAvAnexo.Text)
                If MyDomicilio.Rows.Count > 0 Then
                    txtDomicilio2.Text = MyDomicilio(0).arefane2.Trim
                Else
                    txtDomicilio2.Text = Nothing
                End If
            Else
                txtAnexo.Text = Nothing
                txtAnexoNombre.Text = Nothing
                txtAvAnexo.Text = Nothing
                txtDomicilio.Text = Nothing
                txtDomicilio2.Text = Nothing
            End If
            txtDomicilio2.Focus()
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyDomicilio = New dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable
        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Me.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.0000"
                    Case Is = "C" : ctrl.text = "0.000"
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = Nothing
                End Select
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.SelectedIndex = -1
            ElseIf TypeOf ctrl Is TabControl Then
                MyTabControl = ctrl
                For Each TCctrl As Object In MyTabControl.Controls
                    MyTabPage = TCctrl
                    For Each TPctrl As Object In MyTabPage.Controls
                        If TypeOf TPctrl Is TextBox Then
                            Select Case TPctrl.tag
                                Case Is = "V" : TPctrl.text = "0.0000"
                                Case Is = "C" : TPctrl.text = "0.000"
                                Case Is = "D" : TPctrl.text = "0.00"
                                Case Is = "E" : TPctrl.text = "0"
                                Case Else : TPctrl.text = Nothing
                            End Select
                        ElseIf TypeOf TPctrl Is CheckBox Then
                            TPctrl.Checked = False
                        ElseIf TypeOf TPctrl Is ComboBox Then
                            TPctrl.SelectedIndex = -1
                        End If
                    Next
                Next
            End If
        Next
        txtAnexo.Focus()
    End Sub

#End Region

#Region "Botones"

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If txtAnexo.TextLength <> 0 Then

            MyDomicilio = New dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable
            Dim MyDomicilioRow As dsCONCAR_Anexos.ANEXOS_DOMICILIORow
            MyDomicilioRow = MyDomicilio.NewRow

            With MyDomicilioRow
                .avanexo = txtAvAnexo.Text
                .acodane = txtAnexo.Text
                .adesane = txtAnexoNombre.Text
                .arefane = txtDomicilio.Text.Trim
                .arefane2 = txtDomicilio2.Text.Trim
                .contacto_compra = Space(1)
                .contacto_venta = Space(1)
            End With

            MyDomicilio.Rows.Add(MyDomicilioRow)

            Try
                If dalVenta.GrabarDomicilio(MyDomicilio) = True Then
                    Resp = MsgBox("Los cambios del encabezado se realizaron con éxito.", MsgBoxStyle.Information, " GUARDAR CAMBIOS")
                End If

                txtAnexo.Focus()

            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub
#End Region

 
End Class
