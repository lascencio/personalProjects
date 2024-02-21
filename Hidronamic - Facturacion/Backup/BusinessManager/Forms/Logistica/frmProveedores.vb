Public Class frmProveedores

    Private MyCuentaComercial As entCuentaComercial
    Private MyAnexo As entCONCAR_Anexo
    Private MyAccion As String = "NUEVO"

    Private Sub frmClienteJMO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmClienteJMO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, "01")
        ActualizarTabla("_ENTIDAD_FINANCIERA", cmbBancoMN, "02")
        ActualizarTabla("_ENTIDAD_FINANCIERA", cmbBancoME, "02")
        ActualizarTabla("_UBIGEO_REGION", cmbDepartamento, "15")
        ActualizarTabla("_NACIONALIDAD", cmbPais, "9589")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        ActualizarTablaProvincia("_UBIGEO_PROVINCIA", cmbProvincia, cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        ActualizarTablaUbigeo("_UBIGEO", cmbDistrito, cmbDepartamento.SelectedValue, cmbProvincia.SelectedValue)
    End Sub

    Private Sub ckbIndicaNoDomiciliado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbIndicaNoDomiciliado.CheckedChanged
        If sender.checked = True Then
            cmbDepartamento.SelectedValue = "15"
            cmbProvincia.Text = "LIMA"
            cmbDistrito.Text = "LIMA"
            cmbPais.Enabled = True
            cmbDepartamento.Enabled = False
            cmbProvincia.Enabled = False
            cmbDistrito.Enabled = False
        Else
            cmbPais.Enabled = False
            cmbPais.SelectedValue = "9589"
            cmbDepartamento.Enabled = True
            cmbProvincia.Enabled = True
            cmbDistrito.Enabled = True
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            MyCuentaComercial = New entCuentaComercial

            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P")
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                Call PoblarFormulario()
                txtRazonSocial.Focus()
            Else
                Call LimpiarFormulario()
                cmbDocumentoTipo.SelectedValue = MyDocumentoTipo
                If MyDocumentoNumero.Length <> 0 Then
                    txtDocumentoNumero.Text = MyDocumentoNumero
                    txtRazonSocial.Focus()
                Else
                    txtDocumentoNumero.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub AlinearTexto(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumentoNumero.Validated, txtRazonSocial.Validated, txtEmail.Validated, txtDomicilio.Validated, txtReferencia.Validated, txtTelefono.Validated, txtCelular.Validated, txtApellidoPaterno.Validated, txtApellidoMaterno.Validated, txtNombre.Validated, txtCuentaBancariaMN.Validated, txtCuentaBancariaME.Validated, txtCuentaDetraccion.Validated, txtComentario.Validated, txtCodigoPostal.Validated
        sender.Text = sender.Text.Trim
    End Sub

#Region "Botones"

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        MyCuentaComercial = New entCuentaComercial
        With MyCuentaComercial
            .empresa = MyUsuario.empresa
            .cuenta_comercial = txtCuentaComercial.Text
            .tipo_documento = cmbDocumentoTipo.SelectedValue
            .nro_documento = txtDocumentoNumero.Text
            .indica_proveedor = IIf(ckbIndicaProveedor.Checked = True, "SI", "NO")
            .indica_cliente = IIf(ckbIndicaCliente.Checked = True, "SI", "NO")
            .estado = IIf(ckbEstado.Checked = True, "A", "I")
            .razon_social = txtRazonSocial.Text
            .domicilio = txtDomicilio.Text
            .referencia = txtReferencia.Text
            .email = txtEmail.Text
            .departamento = cmbDepartamento.SelectedValue
            .provincia = cmbProvincia.SelectedValue
            .ubigeo = cmbDistrito.SelectedValue
            .indica_no_domiciliado = IIf(ckbIndicaNoDomiciliado.Checked = True, "SI", "NO")
            .pais = cmbPais.SelectedValue
            .codigo_postal = txtCodigoPostal.Text
            .telefono = txtTelefono.Text
            .celular = txtCelular.Text
            .apellido_paterno = txtApellidoPaterno.Text
            .apellido_materno = txtApellidoMaterno.Text
            .nombres = txtNombre.Text
            If txtFechaNacimiento.Text.Length <> 0 Then .fecha_nacimiento = txtFechaNacimiento.Text
            .sexo = cmbSexo.Text.Substring(0, 1)
            .banco_pago_mn = cmbBancoMN.SelectedValue
            .banco_pago_me = cmbBancoME.SelectedValue
            .cuenta_bancaria_mn = txtCuentaBancariaMN.Text
            .cuenta_bancaria_me = txtCuentaBancariaME.Text
            .cuenta_detraccion = txtCuentaDetraccion.Text
            .comentario = txtComentario.Text
            .usuario_registro = MyUsuario.usuario
        End With

        With MyAnexo
            .avanexo = "P"
            .acodane = txtDocumentoNumero.Text.Trim
            .adesane = txtRazonSocial.Text.Trim
            .aruc = .acodane
            .adocide = Strings.Right(cmbDocumentoTipo.SelectedValue.ToString, 1)
            .anumide = .aruc
            .atiptra = IIf(ckbIndicaNoDomiciliado.Checked = True, "J", IIf(.aruc.Length = 11, "J", "N"))
            .amemo = txtDomicilio.Text.Trim
        End With

        Try
            MyCuentaComercial = dalCuentaComercial.Grabar(MyCuentaComercial)
            MyAnexo = dalCONCAR_Anexo.Grabar(MyAnexo)
            Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
            Call LimpiarFormulario()
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyCuentaComercial = New entCuentaComercial
        MyAccion = "MODIFICAR"
        Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P")
        MyForm.ShowDialog()
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
    End Sub

#End Region

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyAnexo = New entCONCAR_Anexo

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

        Call PonerValoresDefault()

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub LlenarFormulario()
        MyCuentaComercial = dalCuentaComercial.Obtener(MyCuentaComercial.cuenta_comercial)
        With MyCuentaComercial
            txtCuentaComercial.Text = .cuenta_comercial
            cmbDocumentoTipo.SelectedValue = .tipo_documento
            txtDocumentoNumero.Text = .nro_documento
            ckbIndicaProveedor.Checked = IIf(.indica_proveedor = "SI", True, False)
            ckbIndicaCliente.Checked = IIf(.indica_cliente = "SI", True, False)
            ckbEstado.Checked = IIf(.estado = "A", True, False)
            txtRazonSocial.Text = .razon_social
            txtEmail.Text = .email
            txtDomicilio.Text = .domicilio
            txtReferencia.Text = .referencia
            cmbDepartamento.SelectedValue = .departamento
            cmbProvincia.SelectedValue = .provincia
            cmbDistrito.SelectedValue = .ubigeo
            ckbIndicaNoDomiciliado.Checked = IIf(.indica_no_domiciliado = "SI", True, False)
            cmbPais.SelectedValue = .pais
            txtCodigoPostal.Text = .codigo_postal
            txtTelefono.Text = .telefono
            txtCelular.Text = .celular
            cmbBancoMN.SelectedValue = .banco_pago_mn
            cmbBancoME.SelectedValue = .banco_pago_me
            txtCuentaBancariaMN.Text = .cuenta_bancaria_mn
            txtCuentaBancariaME.Text = .cuenta_bancaria_me
            txtCuentaDetraccion.Text = .cuenta_detraccion
            txtApellidoPaterno.Text = .apellido_paterno
            txtApellidoMaterno.Text = .apellido_materno
            txtNombre.Text = .nombres
            cmbSexo.SelectedIndex = IIf(.sexo = "M", 0, 1)
            txtComentario.Text = .comentario
            If .fecha_nacimiento.Date <> FechaNulo.Date Then txtFechaNacimiento.Text = .fecha_nacimiento
            txtCuentaDetraccion.Text = .cuenta_detraccion
        End With
    End Sub

    Private Sub PonerValoresDefault()
        cmbDocumentoTipo.SelectedValue = "01"
        cmbSexo.SelectedIndex = 0
        cmbBancoMN.SelectedValue = "02" : cmbBancoME.SelectedValue = "02"
        cmbDepartamento.SelectedValue = "15" : cmbProvincia.Text = "LIMA" : cmbDistrito.Text = "LIMA"
        cmbPais.SelectedValue = "9589"
        cmbBancoMN.SelectedIndex = -1 : cmbBancoME.SelectedIndex = -1
        ckbIndicaProveedor.Checked = True
        ckbIndicaCliente.Checked = False
        ckbEstado.Checked = True
    End Sub

    Private Sub ValidarDato(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaNacimiento.Validated
        sender.text = EvalDato(sender.text, sender.tag)
    End Sub

    Private Sub PoblarFormulario()
        Dim CuentaComercial As String = MyCuentaComercial.cuenta_comercial
        Call LimpiarFormulario()
        MyCuentaComercial = dalCuentaComercial.Obtener(CuentaComercial)
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
            Call LlenarFormulario()
        End If
    End Sub

#End Region

End Class
