Public Class frmTipoCambio

    Private MyTipoCambio As entTipoCambio
    Private MyAccion As String = "NUEVO"

    Private Sub frmTipoCambioNew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTipoCambioNew_Load(sender As Object, e As EventArgs) Handles Me.Load
        For NEle = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next
        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = CByte(MyUsuario.mes) - 1
        Call ActualizarLista()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnEnviar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
    End Sub

    Private Sub ActualizarListaTC(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEjercicio.SelectedIndexChanged, cmbMes.SelectedIndexChanged
        ActualizarLista()
    End Sub

    Private Sub ActualizarLista()
        Dim MyEjercicio As String
        Dim MyMes As String
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyEjercicio = cmbEjercicio.Text
            MyMes = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            Call ActualizarGrilla()
            cmbDia.Items.Clear()
            FecIni = CDate("01/" & CStr(MyMes) & "/" & MyEjercicio)
            Do While Month(FecIni) = cmbMes.SelectedIndex + 1
                cmbDia.Items.Add(Strings.Right("00" & DateAndTime.Day(FecIni).ToString, 2))
                FecIni = DateAdd(DateInterval.Day, 1, FecIni)
            Loop
        End If
    End Sub

    Private Sub LimpiarFormulario()
        MyTipoCambio = New entTipoCambio

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.000000"
                    Case Is = "C" : ctrl.text = "0.000"
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = Nothing
                End Select
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            ElseIf TypeOf ctrl Is TabControl Then
                MyTabControl = ctrl
                For Each TCctrl As Object In MyTabControl.Controls
                    MyTabPage = TCctrl
                    For Each TPctrl As Object In MyTabPage.Controls
                        If TypeOf TPctrl Is TextBox Then
                            Select Case TPctrl.tag
                                Case Is = "V" : TPctrl.text = "0.000000"
                                Case Is = "C" : TPctrl.text = "0.000"
                                Case Is = "D" : TPctrl.text = "0.00"
                                Case Is = "E" : TPctrl.text = "0"
                                Case Else : TPctrl.text = Nothing
                            End Select
                        ElseIf TypeOf TPctrl Is CheckBox Then
                            TPctrl.Checked = False
                        End If
                    Next
                Next
            End If
        Next
        cmbDia.SelectedIndex = -1

    End Sub

    Private Sub ActualizarGrilla()
        gvTipoCambio.DataSource = dalTipoCambio.BuscarTipoCambioMes(cmbEjercicio.Text, Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2), "2")
        gvTipoCambio.ClearSelection()
        Call LimpiarFormulario()
    End Sub

    Private Sub ValidarImporte(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompra.Validated, txtVenta.Validated, txtPromedio.Validated
        If Not sender Is Nothing Then sender.Text = EvalDato(sender.Text, sender.Tag)
        If CSng(txtCompra.Text) <> 0 And CSng(txtVenta.Text) <> 0 Then
            txtPromedio.Text = EvalDato((CSng(txtCompra.Text) + CSng(txtVenta.Text)) / 2, txtPromedio.Tag)
        End If
    End Sub

    Private Sub gvTipoCambio_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvTipoCambio.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            With sender.Rows(sender.CurrentRow.Index)
                cmbDia.Text = .Cells("DIA").Value
                txtCompra.Text = EvalDato(.Cells("COMPRA").Value, txtCompra.Tag)
                txtVenta.Text = EvalDato(.Cells("VENTA").Value, txtVenta.Tag)
                txtPromedio.Text = EvalDato(.Cells("PROMEDIO").Value, txtPromedio.Tag)
            End With
        End If
    End Sub

    Private Sub cmbDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDia.Validated
        Dim pDia As String
        pDia = cmbDia.Text
        MyTipoCambio = dalTipoCambio.Obtener(cmbEjercicio.Text, Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2), pDia, "2")
        If MyTipoCambio.ejercicio <> Nothing Then
            txtCompra.Text = EvalDato(MyTipoCambio.compra, txtCompra.Tag)
            txtVenta.Text = EvalDato(MyTipoCambio.venta, txtVenta.Tag)
            txtPromedio.Text = EvalDato((MyTipoCambio.compra + MyTipoCambio.venta) / 2, txtPromedio.Tag)
        Else
            txtCompra.Text = "0.000" : txtVenta.Text = "0.000" : txtPromedio.Text = "0.000"
        End If
    End Sub

    Private Sub UC_Toolbar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If cmbDia.SelectedIndex <> -1 And CSng(txtCompra.Text) <> 0 And CSng(txtVenta.Text) <> 0 Then
            With MyTipoCambio
                .ejercicio = cmbEjercicio.Text
                .mes = cmbMes.SelectedIndex + 1
                .dia = cmbDia.Text
                .moneda = "2"
                .compra = CSng(txtCompra.Text)
                .venta = CSng(txtVenta.Text)
                .promedio = (.compra + .venta) / 2
                .usuario_registro = MyUsuario.usuario
            End With

            Try
                MyTipoCambio = dalTipoCambio.Grabar(MyTipoCambio)
                Call ActualizarGrilla()
                cmbDia.Focus()
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_Toolbar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

End Class
