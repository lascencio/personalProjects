Public Class frmEstadoCDR
    Private Sub frmEstadoCDR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles Panel.Paint

    End Sub

    Private Sub frmEstadoCDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarTabla("SEE_TIPO_DOCUMENTO", cmbComprobanteTipo, "01")

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
    End Sub

    Private Sub txtComprobanteNumero_Validated(sender As Object, e As EventArgs) Handles txtComprobanteNumero.Validated
        If IsNumeric(txtComprobanteNumero.Text) Then
            txtComprobanteNumero.Text = Strings.Right("0000000000" & txtComprobanteNumero.Text.Trim, 8)
        End If
        UC_ToolBar.btnAceptar_Focus = True
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
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

        cmbComprobanteTipo.Focus()
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_TB_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim MyConexion = New clsConexionSunat
        Dim strRetorno As String
        Dim CodigoRetorno As String
        Dim Nombre_Archivo As String
        Dim Comprobante As String


        If cmbComprobanteTipo.SelectedIndex <> -1 And txtComprobanteSerie.Text.Trim.Length <> 0 And txtComprobanteNumero.Text.Trim.Length <> 0 Then
            Comprobante = cmbComprobanteTipo.Text & ": " & txtComprobanteSerie.Text & "-" & txtComprobanteNumero.Text
            strRetorno = MyConexion.ObtenerEstadoCDR(cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text, txtComprobanteNumero.Text)

            Try
                Nombre_Archivo = MyRUC & "-" & cmbComprobanteTipo.SelectedValue & "-" & txtComprobanteSerie.Text & "-" & txtComprobanteNumero.Text
                CodigoRetorno = strRetorno.Substring(0, 4)

                If CodigoRetorno = "0127" Then
                    Resp = MsgBox(Comprobante & vbCrLf & vbCrLf & strRetorno, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                Else
                    Resp = MsgBox(Comprobante & vbCrLf & vbCrLf & strRetorno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                    If dalVenta.EvaluarExisteEnvio(MyUsuario.empresa, cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text, "00" & txtComprobanteNumero.Text, IIf(CodigoRetorno = "0004", "V", "R")) = True Then
                        dalVenta.CargarEComprobante("R-" & Nombre_Archivo & ".zip")
                    End If
                End If
                txtComprobanteNumero.Focus()

            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub UC_ToolBar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

#End Region

    Private Sub UC_ToolBar_Load(sender As Object, e As EventArgs) Handles UC_ToolBar.Load

    End Sub
End Class
