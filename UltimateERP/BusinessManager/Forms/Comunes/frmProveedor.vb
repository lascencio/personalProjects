Public Class frmProveedor

    Private MyCuentaComercial As entCuentaComercial
    Private IndicaCliente As Boolean = False
    Private IndicaProveedor As Boolean = True

    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private Sub frmProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbPais, "_NACIONALIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaGenerica(cmbMoneda, "_TIPO_MONEDA")
        ActualizarListaGenerica(cmbBancoMN, "_ENTIDAD_FINANCIERA")
        ActualizarListaGenerica(cmbBancoME, "_ENTIDAD_FINANCIERA")
        ActualizarListaGenerica(cmbCondicionPago, "COM_CONDICION_PAGO")

        ActualizarListaEmpresa(cmbFormaPago, "OPE_FORMA_PAGO")
        ActualizarListaEmpresa(cmbItemFlujo, "CON_ITEM_FLUJO")

        Call LimpiarFormulario(True)

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim

        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P", True)
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                Call PoblarFormulario()
                txtRazonSocial.Focus()
            Else
                Call LimpiarFormulario(True)
                cmbDocumentoTipo.SelectedValue = MyDocumentoTipo
                Call ValidarDocumento(MyDocumentoTipo, MyDocumentoNumero)
            End If
        End If
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        ActualizarTablaProvincia("_UBIGEO_PROVINCIA", cmbProvincia, cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        ActualizarTablaUbigeo("_UBIGEO", cmbDistrito, cmbDepartamento.SelectedValue, cmbProvincia.SelectedValue)
    End Sub

    Private Sub ckbIndicaNoDomiciliado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaNoDomiciliado.CheckedChanged
        EnableComboBox(cmbPais, sender.Checked)

        EnableComboBox(cmbDepartamento, Not sender.Checked)
        EnableComboBox(cmbProvincia, Not sender.Checked)
        EnableComboBox(cmbDistrito, Not sender.Checked)

        If sender.Checked = True Then
            cmbDepartamento.SelectedValue = "15"
            cmbProvincia.SelectedValue = "1501"
            cmbDistrito.SelectedValue = "150101"
            cmbPais.SelectedIndex = -1
        Else
            cmbPais.SelectedValue = "9589"
        End If
    End Sub

    Private Sub ValidarDato_Validated(sender As Object, e As EventArgs) Handles txtPorcentajeDetraccion.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario(InicializarCuentaCorriente As Boolean)
        If InicializarCuentaCorriente = True Then MyCuentaComercial = New entCuentaComercial

        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        Dim MyPanelControl As Panel

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
            ElseIf TypeOf ctrl Is Panel Then
                MyPanelControl = ctrl
                For Each Pctrl As Object In MyPanelControl.Controls
                    If TypeOf Pctrl Is TextBox Then
                        Select Case Pctrl.tag
                            Case Is = "V" : Pctrl.text = "0.0000"
                            Case Is = "C" : Pctrl.text = "0.000"
                            Case Is = "D" : Pctrl.text = "0.00"
                            Case Is = "E" : Pctrl.text = "0"
                            Case Else : Pctrl.text = Nothing
                        End Select
                    ElseIf TypeOf Pctrl Is CheckBox Then
                        Pctrl.Checked = False
                    ElseIf TypeOf Pctrl Is ComboBox Then
                        Pctrl.SelectedIndex = -1
                    End If
                Next
            End If
        Next

        Call PonerValoresDefault()

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        cmbDocumentoTipo.SelectedValue = "6"

        cmbPais.SelectedValue = "9589"
        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"
        cmbMoneda.SelectedValue = "1"
        cmbCondicionPago.SelectedValue = "00"
        cmbFormaPago.SelectedValue = "EF"

        cmbItemFlujo.SelectedValue = "9999"

        cmbBancoMN.SelectedValue = "02" : cmbBancoME.SelectedValue = "02"

        ckbAfectoIGV.Checked = True
        ckbVigenteSunat.Checked = True
        ckbIndicaActivo.Checked = True
    End Sub

    Private Sub PoblarFormulario()
        Call LimpiarFormulario(False)
        MyCuentaComercial = dalCuentaComercial.Obtener(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then Call LlenarFormulario()
    End Sub

    Private Sub LlenarFormulario()
        With MyCuentaComercial
            txtCuentaComercial.Text = .cuenta_comercial
            cmbDocumentoTipo.SelectedValue = .tipo_documento
            txtDocumentoNumero.Text = .nro_documento
            txtRazonSocial.Text = .razon_social
            txtSiglas.Text = .siglas
            ckbIndicaNoDomiciliado.Checked = IIf(.indica_no_domiciliado = "SI", True, False)
            cmbPais.SelectedValue = .pais
            txtDomicilio.Text = .domicilio
            cmbDepartamento.SelectedValue = .departamento
            cmbProvincia.SelectedValue = .provincia
            cmbDistrito.SelectedValue = .ubigeo
            txtReferencia.Text = .referencia
            txtTelefono.Text = .telefono
            txtCelular.Text = .celular
            txtEmail.Text = .email
            txtCodigoPostal.Text = .codigo_postal
            txtContactoComercial.Text = .contacto_comercial
            cmbMoneda.SelectedValue = .tipo_moneda
            cmbCondicionPago.SelectedValue = .condicion_pago
            cmbFormaPago.SelectedValue = .forma_pago
            cmbItemFlujo.SelectedValue = .item_flujo
            cmbBancoMN.SelectedValue = .banco_pago_mn
            txtCuentaBancariaMN.Text = .cuenta_bancaria_mn
            cmbBancoME.SelectedValue = .banco_pago_me
            txtCuentaBancariaME.Text = .cuenta_bancaria_me
            txtCuentaDetraccion.Text = .cuenta_detraccion
            txtPorcentajeDetraccion.Text = EvalDato(.porcentaje_detraccion, txtPorcentajeDetraccion.Tag)
            txtComentario.Text = .comentario
            ckbAfectoIGV.Checked = IIf(.afecto_igv = "SI", True, False)
            ckbAgentePercepcion.Checked = IIf(.agente_percepcion = "SI", True, False)
            ckbAgenteRetencion.Checked = IIf(.agente_retencion = "SI", True, False)
            ckbAgenteDetraccion.Checked = IIf(.agente_detraccion = "SI", True, False)
            ckbVigenteSunat.Checked = IIf(.vigente_sunat = "SI", True, False)
            ckbIndicaActivo.Checked = IIf(.estado = "A", True, False)
            IndicaCliente = IIf(.indica_cliente = "SI", True, False)
            IndicaProveedor = IIf(.indica_proveedor = "SI", True, False)
        End With
    End Sub

    Private Sub CapturarDatos()
        With MyCuentaComercial
            .empresa = MyUsuario.empresa
            .cuenta_comercial = txtCuentaComercial.Text
            .tipo_cuenta = "J"
            .tipo_documento = cmbDocumentoTipo.SelectedValue
            .nro_documento = txtDocumentoNumero.Text
            .razon_social = txtRazonSocial.Text
            .siglas = txtSiglas.Text
            .indica_no_domiciliado = IIf(ckbIndicaNoDomiciliado.Checked = True, "SI", "NO")
            .pais = cmbPais.SelectedValue
            .domicilio = txtDomicilio.Text
            .departamento = cmbDepartamento.SelectedValue
            .provincia = cmbProvincia.SelectedValue
            .ubigeo = cmbDistrito.SelectedValue
            .referencia = txtReferencia.Text
            .telefono = txtTelefono.Text
            .celular = txtCelular.Text
            .email = txtEmail.Text
            .codigo_postal = txtCodigoPostal.Text
            .contacto_comercial = txtContactoComercial.Text
            .tipo_moneda = cmbMoneda.SelectedValue
            .condicion_pago = cmbCondicionPago.SelectedValue
            .forma_pago = cmbFormaPago.SelectedValue
            .item_flujo = cmbItemFlujo.SelectedValue
            .banco_pago_mn = cmbBancoMN.SelectedValue
            .cuenta_bancaria_mn = txtCuentaBancariaMN.Text
            .banco_pago_me = cmbBancoME.SelectedValue
            .cuenta_bancaria_me = txtCuentaBancariaME.Text
            .cuenta_detraccion = txtCuentaDetraccion.Text
            .porcentaje_detraccion = CDec(txtPorcentajeDetraccion.Text)
            .comentario = txtComentario.Text
            .afecto_igv = IIf(ckbAfectoIGV.Checked = True, "SI", "NO")
            .agente_percepcion = IIf(ckbAgentePercepcion.Checked = True, "SI", "NO")
            .agente_retencion = IIf(ckbAgenteRetencion.Checked = True, "SI", "NO")
            .agente_detraccion = IIf(ckbAgenteDetraccion.Checked = True, "SI", "NO")
            .vigente_sunat = IIf(ckbVigenteSunat.Checked = True, "SI", "NO")
            .estado = IIf(ckbIndicaActivo.Checked = True, "A", "I")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario

            .indica_cliente = "NO"
            .indica_proveedor = "SI"
        End With
    End Sub

    Private Sub ValidarDocumento(MyDocumentoTipo As String, MyDocumentoNumero As String)
        If MyDocumentoNumero.Length <> 0 Then
            If MyDocumentoNumero.Trim.Length = 11 Then
                MyConsultaRUC = dalVenta.ObtenerDatosRUC(MyDocumentoNumero)
                If Not MyConsultaRUC(0).RUC Is Nothing Then
                    txtRazonSocial.Text = MyConsultaRUC(0).RAZON_SOCIAL
                    txtDomicilio.Text = MyConsultaRUC(0).DOMICILIO_FISCAL
                    cmbDepartamento.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 2)
                    cmbProvincia.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 4)
                    cmbDistrito.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 6)

                    If MyConsultaRUC(0).ESTADO <> "ACTIVO" Then
                        Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta en estado " & MyConsultaRUC(0).ESTADO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                        If Resp = vbYes Then
                            txtDocumentoNumero.Text = MyDocumentoNumero
                            txtTelefono.Focus()
                        Else
                            Call LimpiarFormulario(True)
                            txtDocumentoNumero.Focus()
                        End If
                    ElseIf MyConsultaRUC(0).CONDICION_DOMICILIO <> "HABIDO" Then
                        Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta con domicilio " & MyConsultaRUC(0).CONDICION_DOMICILIO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                        If Resp = vbYes Then
                            txtDocumentoNumero.Text = MyDocumentoNumero
                            txtTelefono.Focus()
                        Else
                            Call LimpiarFormulario(True)
                            txtDocumentoNumero.Focus()
                        End If
                    Else
                        txtDocumentoNumero.Text = MyDocumentoNumero
                        txtTelefono.Focus()
                    End If
                Else
                    Resp = MsgBox("El RUC " & MyDocumentoNumero & " no existe en el padrón de Sunat." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                    If Resp = vbYes Then
                        txtDocumentoNumero.Text = MyDocumentoNumero
                        txtRazonSocial.Focus()
                    Else
                        txtDocumentoNumero.Focus()
                    End If
                End If
            Else
                Resp = MsgBox("El RUC " & MyDocumentoNumero & " no tiene 11 dígitos." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                If Resp = vbYes Then
                    txtDocumentoNumero.Text = MyDocumentoNumero
                    txtRazonSocial.Focus()
                Else
                    txtDocumentoNumero.Focus()
                End If
            End If

        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_Toolbar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_Toolbar_TB_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario(True)
    End Sub

    Private Sub UC_Toolbar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim NombreCampo As String
        Dim GrabarRegistro As Boolean = True

        If txtDocumentoNumero.Text.Trim.Length <> 0 Then
            If txtDomicilio.Text.Trim.Length = 0 Then NombreCampo = "DOMICILIO" : GrabarRegistro = False
            If txtRazonSocial.Text.Trim.Length = 0 Then NombreCampo = "RAZON SOCIAL" : GrabarRegistro = False

            If GrabarRegistro = False Then
                Resp = MsgBox("Falta registrar información en el campo " & NombreCampo, MsgBoxStyle.Critical, "PROCESO CANCELADO")
            Else
                Try
                    Call CapturarDatos()

                    MyCuentaComercial = dalCuentaComercial.Grabar(MyCuentaComercial)
                    Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "REGISTRO DE CLIENTES")
                    Call LimpiarFormulario(True)

                    Call ActualizarMyDTCuentasComerciales()

                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub UC_Toolbar_TB_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyCuentaComercial = New entCuentaComercial
        Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P", True)
        MyForm.ShowDialog()
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then Call PoblarFormulario()
    End Sub

#End Region


End Class
