Public Class frmGlosaAlterna

    Private MyVenta As entVenta
    Private MyVentaGlosa As entVentaGlosa
    Private MyVentaDatos As dsVentas.VENTAS_DATOSDataTable

    Private Sub frmGlosaAlterna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGlosaAlterna_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarTabla("SEE_TIPO_DOCUMENTO", cmbComprobanteTipo, "01")
        ActualizarTabla("_TIPO_MONEDA", cmbTipoMoneda, "1")
        cmbTipoMoneda.SelectedIndex = -1

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnInformacion_Visible = False

    End Sub

    Private Sub ValidarComprobante(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.Validated, txtComprobanteSerie.Validated, txtComprobanteNumero.Validated
        If cmbComprobanteTipo.SelectedIndex <> -1 Then
            If txtComprobanteSerie.Text.Trim.Length = 4 Then
                txtComprobanteSerie.Text = UCase(txtComprobanteSerie.Text)
                If IsNumeric(txtComprobanteNumero.Text) Then
                    txtComprobanteNumero.Text = Strings.Right("0000000000" & txtComprobanteNumero.Text.Trim, 10)
                    MyVenta = dalVenta.Obtener(cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text, txtComprobanteNumero.Text)
                    If MyVenta.venta = "" Then
                        Resp = MsgBox("El Comprobante Electrónico NO EXISTE.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "REGISTRAR GLOSA ALTERNA")
                        Call LimpiarFormulario()
                    Else
                        txtComprobanteFecha.Text = EvalDato(MyVenta.comprobante_fecha, "F")
                        cmbTipoMoneda.SelectedValue = MyVenta.tipo_moneda
                        txtImporteTotalOrigen.Text = EvalDato(MyVenta.importe_total_origen, txtImporteTotalOrigen.Tag)
                        txtAnexoNombre.Text = MyVentaDatos(0).RazonSocial
                        txtVenta.Text = MyVenta.venta
                        MyVentaGlosa = dalVenta.ObtenerGlosa(MyVenta.empresa, MyVenta.venta)
                        If MyVentaGlosa.venta <> "" Then
                            txtGlosa1Linea.Text = MyVentaGlosa.glosa_1
                            txtGlosa2Linea.Text = MyVentaGlosa.glosa_2
                            txtGlosa3Linea.Text = MyVentaGlosa.glosa_3
                            txtGlosa4Linea.Text = MyVentaGlosa.glosa_4
                        End If
                        txtGlosa1Linea.Focus()
                    End If
                Else
                    txtComprobanteNumero.Text = ""
                End If
            Else
                txtComprobanteSerie.Text = ""
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta
        MyVentaGlosa = New entVentaGlosa
        MyVentaDatos = New dsVentas.VENTAS_DATOSDataTable

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

    Private Sub UC_ToolBar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click

        If txtVenta.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe ingresar los datos del comprobante a modificar.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "REGISTRAR GLOSA ALTERNA")
        Else
            Try
                MyVentaGlosa = New entVentaGlosa
                With MyVentaGlosa
                    .empresa = MyUsuario.empresa
                    .venta = txtVenta.Text
                    .linea = "001"
                    .tipo_cambio = MyVenta.tipo_cambio
                    .tipo_moneda = MyVenta.tipo_moneda
                    .glosa_1 = txtGlosa1Linea.Text
                    .glosa_2 = txtGlosa2Linea.Text
                    .glosa_3 = txtGlosa3Linea.Text
                    .glosa_4 = txtGlosa4Linea.Text
                    .valor_venta_origen = MyVenta.importe_total_origen
                    .usuario_registro = MyUsuario.usuario
                End With

                dalVenta.GrabarGlosa(MyVentaGlosa)

                Resp = MsgBox("Los cambios en la glosa se realizaron con éxito.", MsgBoxStyle.Information, "REGISTRAR GLOSA ALTERNA")
                Me.Close()

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



End Class
