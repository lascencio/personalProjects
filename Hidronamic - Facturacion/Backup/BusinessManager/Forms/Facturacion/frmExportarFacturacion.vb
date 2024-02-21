Public Class frmExportarFacturacion

    Private MyDT_Cabecera As dsAsientoContable.ASIENTOS_VENTA_CABECERADataTable
    Private MyDT_Detalle As dsAsientoContable.ASIENTOS_VENTA_DETALLEDataTable

    Private MyAsientosVenta As dsAsientoContable.ASIENTOS_VENTA_LISTADataTable
    Private MyCorrelativo As dsCorrelativo.CORRELATIVO_CONCARDataTable

    Private Sub frmExportarFacturacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmExportarFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For NEle As Integer = 2014 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next
        Call LimpiarFormulario()
        Call PoblarGrilla()
    End Sub

    Private Sub gvAsientos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvAsientos.CellContentClick
        With gvAsientos
            If Not .CurrentRow Is Nothing Then
                If .Rows(.CurrentRow.Index).Cells("cindica_exportacion").Value Then
                    .Rows(.CurrentRow.Index).Cells("cindica_exportacion").Value = 0
                    .Rows(.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
                    .Rows(.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.Black
                Else
                    .Rows(.CurrentRow.Index).Cells("cindica_exportacion").Value = 1
                    .Rows(.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightCyan
                    .Rows(.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.DarkBlue
                End If
            End If
        End With
    End Sub

    Private Sub cmbTipoRegistros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoRegistros.SelectedIndexChanged
        If cmbTipoRegistros.SelectedIndex <> -1 Then Call PoblarGrilla()
    End Sub

    Private Sub ckbSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbSeleccionar.CheckedChanged
        If gvAsientos.RowCount > 0 Then
            With MyAsientosVenta
                For MyFila As Integer = 0 To .Rows.Count - 1
                    gvAsientos.Rows(MyFila).Cells("cindica_exportacion").Value = IIf(ckbSeleccionar.Checked = True, 1, 0)
                    gvAsientos.Rows(MyFila).DefaultCellStyle.BackColor = IIf(ckbSeleccionar.Checked = False, Color.White, Color.LightCyan)
                    gvAsientos.Rows(MyFila).DefaultCellStyle.ForeColor = IIf(ckbSeleccionar.Checked = False, Color.Black, Color.DarkBlue)
                Next
            End With
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()

        MyAsientosVenta = New dsAsientoContable.ASIENTOS_VENTA_LISTADataTable
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

        gvAsientos.DataSource = New dsAsientoContable.DETALLEDataTable

        Call PonerValoresDefault()
    End Sub

    Private Sub PonerValoresDefault()
        cmbTipoRegistros.SelectedIndex = 0
        cmbEjercicio.Text = MyUsuario.ejercicio
        txtAsientoMes.Text = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyCorrelativo = dalVenta.ObtenerCorrelativoCONCAR("003", cmbEjercicio.Text, txtAsientoMes.Text, "05")
        If MyCorrelativo.Rows.Count <> 0 Then txtAsientoNumero.Text = MyCorrelativo(0).COMPROBANTE_NUMERO.Trim
    End Sub

    Private Sub PoblarGrilla()
        Dim IndicaExportacion As String = IIf(cmbTipoRegistros.SelectedIndex = 0, "NO", "SI")
        Dim MyCorrelativoNumero As Long
        MyAsientosVenta = New dsAsientoContable.ASIENTOS_VENTA_LISTADataTable
        MyAsientosVenta = dalVenta.BuscarAsientosVentaMigrar("003", cmbEjercicio.Text, txtAsientoMes.Text, IndicaExportacion)
        If MyAsientosVenta.Rows.Count > 0 Then
            MyCorrelativoNumero = CLng(txtAsientoNumero.Text)
            With MyAsientosVenta
                For NumFil As Integer = 0 To .Rows.Count - 1
                    MyCorrelativoNumero = MyCorrelativoNumero + 1
                    MyAsientosVenta(NumFil).ccorrelativo = txtAsientoMes.Text & Strings.Right("0000" & MyCorrelativoNumero.ToString, 4)
                Next
            End With
        End If
        gvAsientos.DataSource = MyAsientosVenta
    End Sub

#End Region

#Region "Botones"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Try
            If MyAsientosVenta.Rows.Count > 0 Then
                With MyAsientosVenta
                    For NumFil As Integer = 0 To .Rows.Count - 1
                        'MyCorrelativoRendicion = MyAsientosVenta(NumFil).dcompro
                        'FilaRendiciones = 1
                        'Do While MyAsientosVenta(NumFil).dcompro = MyCorrelativoRendicion
                        '    If MyAsientosVenta(NumFil).ddh = "H" Then TotalRendiciones = TotalRendiciones + MyAsientosVenta(NumFil).dmnimpor
                        '    MyAsientosVenta(NumFil).dcompro = txtAsientoMes.Text & Strings.Right("0000" & AsientoRendicion.ToString, 4)
                        '    MyAsientosVenta(NumFil).dsecue = Strings.Right("0000" & FilaRendiciones.ToString, 4)
                        '    FilaRendiciones = FilaRendiciones + 1
                        '    NumFil = NumFil + 1
                        '    If NumFil > .Rows.Count - 1 Then Exit Do
                        'Loop
                        If NumFil > .Rows.Count - 1 Then
                            Exit For
                        Else
                            NumFil = NumFil - 1
                        End If
                        'AsientoRendicion = AsientoRendicion + 1
                    Next
                End With
            End If

            gvAsientos.DataSource = MyAsientosVenta

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try


    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim MyCorrelativo As String = txtAsientoNumero.Text

        Dim MyError_1 As String = "Debe registrar o indicar un valor en el campo "
        Dim Continuar As Boolean = False

        btnGrabar.Enabled = False

        Try
            If cmbEjercicio.SelectedIndex = -1 Then Throw New BusinessException(MyError_1 & "EJERCICIO")
            If String.IsNullOrEmpty(txtAsientoNumero.Text.Trim) Then Throw New BusinessException(MyError_1 & "COMPROBANTE")

            If gvAsientos.RowCount = 0 Then Throw New BusinessException("No existen documentos a migrar ")


            If MyAsientosVenta.Rows.Count > 0 Then
                If dalVenta.InsertarVenta(MyProgressBar, "003", cmbEjercicio.Text, txtAsientoMes.Text, MyAsientosVenta) = True Then
                    Resp = MsgBox("La migración se generó exitosamente.", MsgBoxStyle.Information, "MIGRAR VENTA")
                    Call LimpiarFormulario()
                    Me.Close()
                Else
                    Throw New BusinessException("No se generó el Comprobante, corregir errores.")
                End If

            End If

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message, MsgBoxStyle.Exclamation, "MIGRAR VENTA")
        Catch ex As Exception
            Resp = MsgBox(ex.Message)
        End Try

        btnGrabar.Enabled = True
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

#End Region



End Class