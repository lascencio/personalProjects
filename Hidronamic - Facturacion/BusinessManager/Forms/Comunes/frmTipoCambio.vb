Public Class frmTipoCambio

    Private MyTipoCambio As entTipoCambio
    Private MyAccion As String = "NUEVO"

    Private Sub frmTipoCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For NEle = 2010 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next
        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = CByte(MyUsuario.mes) - 1
        Call ActualizarLista()
        'If MyUsuario.privilegios <> 1 Then btnAceptar.Visible = False
    End Sub

    Private Sub frmTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ActualizarListaTC(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEjercicio.SelectedIndexChanged, cmbMes.SelectedIndexChanged
        ActualizarLista()
    End Sub

    Private Sub ActualizarLista()
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            Call ActualizarGrilla()
            cmbDia.Items.Clear()
            FecIni = CDate("01/" & CStr(cmbMes.SelectedIndex + 1) & "/" & cmbEjercicio.Text)
            Do While Month(FecIni) = cmbMes.SelectedIndex + 1
                cmbDia.Items.Add(Strings.Right("00" & DateAndTime.Day(FecIni).ToString, 2))
                FecIni = DateAdd(DateInterval.Day, 1, FecIni)
            Loop
        End If
    End Sub

    Private Sub LimpiarFormulario()
        For Each ctrl As Object In Me.Controls
            Continuar = True
            If TypeOf ctrl Is TextBox Then
                If ctrl.tag = "C" Then
                    ctrl.text = "0.000"
                Else
                    ctrl.text = ""
                End If
            End If
        Next

        MyTipoCambio = New entTipoCambio

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

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
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

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class