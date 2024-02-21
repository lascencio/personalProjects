Public Class frmLiquidarCajaChica

    Private MyDT_Cabecera As dsAsientoContable.CABECERADataTable
    Private MyDT_Detalle As dsAsientoContable.DETALLEDataTable

    Private Sub frmLiquidarCajaChica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmLiquidarCajaChica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEjercicio.Text = Now.Year.ToString
        cmbMes.SelectedIndex = Now.Month - 1
        cmbOrigenFondos.SelectedIndex = 0
    End Sub

    Private Sub ActualizarGrilla()
        If cmbEjercicio.SelectedIndex <> -1 Then
            MyDT_Detalle = dalLiquidarCaja.BuscarRegistros(cmbEjercicio.Text)

            gvAsientoDetalles.DataSource = MyDT_Detalle

            If MyDT_Detalle.Rows.Count = 0 Then Resp = MsgBox("No existe información a migrar para el período seleccionado.", MsgBoxStyle.Exclamation, " MIGRAR INFORMACION")

        End If
    End Sub

    Private Sub btnDocumentosLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumentosLiquidar.Click
        btnDocumentosLiquidar.Enabled = False
        Call ActualizarGrilla()
        btnDocumentosLiquidar.Enabled = True
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub gvAsientoDetalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvAsientoDetalles.CellContentClick
        With gvAsientoDetalles
            If Not .CurrentRow Is Nothing Then
                If .Rows(.CurrentRow.Index).Cells("DbascomDataGridViewCheckBoxColumn").Value = 1 Then
                    .Rows(.CurrentRow.Index).Cells("DbascomDataGridViewCheckBoxColumn").Value = 0
                    .Rows(.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
                    .Rows(.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.Black
                Else
                    .Rows(.CurrentRow.Index).Cells("DbascomDataGridViewCheckBoxColumn").Value = 1
                    .Rows(.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightCyan
                    .Rows(.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.DarkBlue
                End If

                Dim MyTotalMN As Decimal = 0
                For MyFila As Integer = 0 To gvAsientoDetalles.RowCount - 1
                    If gvAsientoDetalles.Rows(MyFila).Cells("DbascomDataGridViewCheckBoxColumn").Value = 1 Then
                        MyTotalMN = MyTotalMN + CDec(gvAsientoDetalles.Rows(MyFila).Cells("DmnimporDataGridViewTextBoxColumn").Value)
                    End If
                Next
                txtTotalMN.Text = EvalDato(MyTotalMN, txtTotalMN.Tag)
                If txtTipoCambio.Text <> "0.000" Then
                    txtTotalME.Text = EvalDato(Math.Round(MyTotalMN / CDec(txtTipoCambio.Text), 2), txtTotalMN.Tag)
                Else
                    txtTotalME.Text = "0.00"
                End If

            End If
        End With
    End Sub

    Private Sub ckbSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbSeleccionar.CheckedChanged
        If gvAsientoDetalles.RowCount > 0 Then
            Dim MyTotalMN As Decimal = 0
            For MyFila As Integer = 0 To gvAsientoDetalles.RowCount - 1
                gvAsientoDetalles.Rows(MyFila).Cells("DbascomDataGridViewCheckBoxColumn").Value = IIf(ckbSeleccionar.Checked = True, 1, 0)
                gvAsientoDetalles.Rows(MyFila).DefaultCellStyle.BackColor = IIf(ckbSeleccionar.Checked = False, Color.White, Color.LightCyan)
                gvAsientoDetalles.Rows(MyFila).DefaultCellStyle.ForeColor = IIf(ckbSeleccionar.Checked = False, Color.Black, Color.DarkBlue)
                If ckbSeleccionar.Checked = True Then MyTotalMN = MyTotalMN + CDec(gvAsientoDetalles.Rows(MyFila).Cells("DmnimporDataGridViewTextBoxColumn").Value)
            Next
            txtTotalMN.Text = EvalDato(MyTotalMN, txtTotalMN.Tag)
            If txtTipoCambio.Text <> "0.000" Then
                txtTotalME.Text = EvalDato(Math.Round(MyTotalMN / CDec(txtTipoCambio.Text), 2), txtTotalMN.Tag)
            Else
                txtTotalME.Text = "0.00"
            End If

        End If
    End Sub

    Private Sub Validar(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.Validated, txtTipoCambio.Validated
        If sender.Text <> Nothing Then
            sender.text = EvalDato(sender.text, sender.tag)
            If txtTipoCambio.Text <> "0.000" Then
                txtTotalME.Text = EvalDato(Math.Round(CSng(txtTotalMN.Text) / CSng(txtTipoCambio.Text), 2), txtTotalME.Tag)
            Else
                txtTotalME.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txtN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAsientoNumero.Validated
        If IsNumeric(sender.Text) Then
            sender.Text = Strings.Right("0000" & CStr(CInt(sender.Text)), 4)
        Else
            sender.Text = Nothing
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        If cmbMes.SelectedIndex <> -1 Then
            txtAsientoMes.Text = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim MyDT_Detalle_Sel As New dsAsientoContable.DETALLEDataTable
        Dim MyError_1 As String = "Debe registrar o indicar un valor en el campo "
        Dim Continuar As Boolean = False

        btnGrabar.Enabled = False

        Try
            If cmbEjercicio.SelectedIndex = -1 Then Throw New BusinessException(MyError_1 & "EJERCICIO")
            If cmbMes.SelectedIndex = -1 Then Throw New BusinessException(MyError_1 & "MES")
            If String.IsNullOrEmpty(txtFecha.Text.Trim) Then Throw New BusinessException(MyError_1 & "FECHA")
            If CSng(txtTipoCambio.Text) = 0 Then Throw New BusinessException(MyError_1 & "TIPO DE CAMBIO")
            If cmbSubdiario.SelectedIndex = -1 Then Throw New BusinessException(MyError_1 & "TIPO DE SUBDIARIO")
            If String.IsNullOrEmpty(txtAsientoNumero.Text.Trim) Then Throw New BusinessException(MyError_1 & "NRO. COMP.")
            If String.IsNullOrEmpty(txtGlosa.Text.Trim) Then Throw New BusinessException(MyError_1 & "GLOSA DEL COMPROBANTE")

            If gvAsientoDetalles.RowCount = 0 Then Throw New BusinessException("No existen documentos a liquidar ")

            For MyFila As Integer = 0 To MyDT_Detalle.Rows.Count - 1
                If MyDT_Detalle(MyFila).dbascom = 1 Then MyDT_Detalle_Sel.ImportRow(MyDT_Detalle(MyFila))
            Next

            If MyDT_Detalle_Sel.Rows.Count = 0 Then Throw New BusinessException("No se han seleccionado documentos a liquidar ")

            If dalLiquidarCaja.Existe(cmbEjercicio.Text, cmbSubdiario.Text.Substring(0, 2), txtAsientoMes.Text & txtAsientoNumero.Text) Then
                If ckbIndicaReemplazar.Checked = False Then Throw New BusinessException("El Comprobante " & txtAsientoMes.Text & txtAsientoNumero.Text & " existe. Debe indicar si desea reemplazarlo.")
            End If

            If dalLiquidarCaja.Insertar(MyProgressBar, cmbEjercicio.Text, txtAsientoMes.Text, txtFecha.Text, txtTipoCambio.Text, cmbSubdiario.Text.Substring(0, 2), txtAsientoMes.Text & txtAsientoNumero.Text, txtGlosa.Text, txtTotalMN.Text, txtTotalME.Text, cmbOrigenFondos.Text.Substring(0, 6), ckbIndicaReemplazar.Checked, MyDT_Detalle_Sel) = True Then
                Resp = MsgBox("El Comprobante " & txtAsientoMes.Text & txtAsientoNumero.Text & " se generó exitosamente.", MsgBoxStyle.Information, "LIQUIDAR CAJA CHICA")
                Call LimpiarFormulario()
            Else
                Throw New BusinessException("No se generó el Comprobante, corregir errores.")
            End If

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LIQUIDAR CAJA CHICA")
        Catch ex As Exception
            Resp = MsgBox(ex.Message)
        End Try

        btnGrabar.Enabled = True

    End Sub

    Private Sub LimpiarFormulario()
        txtFecha.Text = Nothing : txtAsientoNumero.Text = Nothing : txtGlosa.Text = Nothing
        txtTipoCambio.Text = "0.000" : txtTotalMN.Text = "0.00" : txtTotalME.Text = "0.00"
        cmbOrigenFondos.SelectedIndex = 0
        cmbSubdiario.SelectedIndex = -1
        ckbSeleccionar.Checked = False : ckbIndicaReemplazar.Checked = False
        gvAsientoDetalles.ClearSelection()
        gvAsientoDetalles.DataSource = New dsAsientoContable.DETALLEDataTable
    End Sub


End Class