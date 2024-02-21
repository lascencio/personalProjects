Public Class frmClientePersonaNatural

    Private MyCuentaComercial As entCuentaComercial
    Private IndicaCliente As Boolean = True
    Private IndicaProveedor As Boolean = False

    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private Sub frmClientePersonaNatural_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmClientePersonaNatural_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbPais, "_NACIONALIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaGenerica(cmbEstadoCivil, "_ESTADO_CIVIL")
        ActualizarListaGenerica(cmbNivelEducativo, "_NIVEL_EDUCATIVO")
        ActualizarListaGenerica(cmbBancoMN, "_ENTIDAD_FINANCIERA")
        ActualizarListaGenerica(cmbBancoME, "_ENTIDAD_FINANCIERA")

        ActualizarListaEmpresa(cmbOcupacion, "OPE_OCUPACION")
        ActualizarListaEmpresa(cmbSituacionCrediticia, "OPE_SITUACION_CREDITICIA")
        ActualizarListaEmpresa(cmbCalificacion, "OPE_CALIFICACION")
        ActualizarListaEmpresa(cmbZonaComercial, "OPE_ZONAS_COMERCIALES")
        ActualizarListaEmpresa(cmbItemFlujo, "CON_ITEM_FLUJO")

        Call LimpiarFormulario(True)

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnGrabar_Visible = True
        UC_ToolBar.btnAceptar_Visible = False
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
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "NO")
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
                Call PoblarFormulario()
                txtApellidoPaterno.Focus()
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

    Private Sub ckbIndicaFallecido_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaFallecido.CheckedChanged
        EnableCheckBox(ckbIndicaActivo, Not sender.Checked)
        If ckbIndicaFallecido.Checked = True Then ckbIndicaActivo.Checked = False
    End Sub

    Private Sub ValidarDato_Validated(sender As Object, e As EventArgs) Handles txtFechaNacimiento.Validated, txtLineaCreditoME.Validated, txtLineaCreditoMN.Validated, txtPorcentajeDetraccion.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub

    Private Sub cmbDocumentoTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDocumentoTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            txtDocumentoNumero.Focus()
            If txtDocumentoNumero.Text.Trim.Length <> 0 Then Call ValidarDocumento(cmbDocumentoTipo.SelectedValue, txtDocumentoNumero.Text)
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario(InicializarCuentaCorriente As Boolean)
        If InicializarCuentaCorriente = True Then MyCuentaComercial = New entCuentaComercial

        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        'Dim MyPanelControl As Panel

        'Dim MyTabControl As TabControl
        'Dim MyTabPage As TabPage
        'For Each ctrl As Object In Panel.Controls
        '    If TypeOf ctrl Is TextBox Then
        '        Select Case ctrl.tag
        '            Case Is = "V" : ctrl.text = "0.000000"
        '            Case Is = "C" : ctrl.text = "0.000"
        '            Case Is = "D" : ctrl.text = "0.00"
        '            Case Is = "E" : ctrl.text = "0"
        '            Case Else : ctrl.text = Nothing
        '        End Select
        '    ElseIf TypeOf ctrl Is CheckBox Then
        '        ctrl.Checked = False
        '    ElseIf TypeOf ctrl Is ComboBox Then
        '        ctrl.SelectedIndex = -1
        '    ElseIf TypeOf ctrl Is TabControl Then
        '        MyTabControl = ctrl
        '        For Each TCctrl As Object In MyTabControl.Controls
        '            MyTabPage = TCctrl
        '            For Each TPctrl As Object In MyTabPage.Controls
        '                If TypeOf TPctrl Is TextBox Then
        '                    Select Case TPctrl.tag
        '                        Case Is = "V" : TPctrl.text = "0.0000"
        '                        Case Is = "C" : TPctrl.text = "0.000"
        '                        Case Is = "D" : TPctrl.text = "0.00"
        '                        Case Is = "E" : TPctrl.text = "0"
        '                        Case Else : TPctrl.text = Nothing
        '                    End Select
        '                ElseIf TypeOf TPctrl Is CheckBox Then
        '                    TPctrl.Checked = False
        '                ElseIf TypeOf TPctrl Is ComboBox Then
        '                    TPctrl.SelectedIndex = -1
        '                End If
        '            Next
        '        Next
        '    ElseIf TypeOf ctrl Is Panel Then
        '        MyPanelControl = ctrl
        '        For Each Pctrl As Object In MyPanelControl.Controls
        '            If TypeOf Pctrl Is TextBox Then
        '                Select Case Pctrl.tag
        '                    Case Is = "V" : Pctrl.text = "0.0000"
        '                    Case Is = "C" : Pctrl.text = "0.000"
        '                    Case Is = "D" : Pctrl.text = "0.00"
        '                    Case Is = "E" : Pctrl.text = "0"
        '                    Case Else : Pctrl.text = Nothing
        '                End Select
        '            ElseIf TypeOf Pctrl Is CheckBox Then
        '                Pctrl.Checked = False
        '            ElseIf TypeOf Pctrl Is ComboBox Then
        '                Pctrl.SelectedIndex = -1
        '            End If
        '        Next
        '    End If
        'Next

        InicializarFormulario(Me)

        Call PonerValoresDefault()

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        cmbDocumentoTipo.SelectedValue = "1"

        cmbPais.SelectedValue = "9589"
        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"
        cmbSituacionCrediticia.SelectedValue = "CAL"
        cmbCalificacion.SelectedValue = "A"
        cmbZonaComercial.SelectedValue = "LIMMET"
        cmbItemFlujo.SelectedValue = "9999"

        cmbBancoMN.SelectedValue = "02" : cmbBancoME.SelectedValue = "02"

        ckbExigeGarante.Checked = True
        ckbIndicaActivo.Checked = True

        UC_ToolBar.btnGrabar_Visible = True
    End Sub

    Private Sub CapturarDatos()
        With MyCuentaComercial
            .empresa = MyUsuario.empresa
            .cuenta_comercial = txtCuentaComercial.Text
            .tipo_cuenta = "N"
            .tipo_documento = cmbDocumentoTipo.SelectedValue
            .nro_documento = txtDocumentoNumero.Text
            .apellido_paterno = txtApellidoPaterno.Text.Trim
            .apellido_materno =  txtApellidoMaterno.Text.Trim
            .nombres = txtNombre.Text.Trim
            .razon_social = txtApellidoPaterno.Text.Trim & " " & txtApellidoMaterno.Text.Trim & " " & txtNombre.Text.Trim
            If txtFechaNacimiento.Text.Length <> 0 Then .fecha_nacimiento = CDate(txtFechaNacimiento.Text)
            .indica_no_domiciliado = IIf(ckbIndicaNoDomiciliado.Checked = True, "SI", "NO")
            .pais = cmbPais.SelectedValue
            .domicilio = txtDomicilio.Text.Trim
            .departamento = cmbDepartamento.SelectedValue
            .provincia = cmbProvincia.SelectedValue
            .ubigeo = cmbDistrito.SelectedValue
            .referencia = txtReferencia.Text.Trim
            .telefono = txtTelefono.Text
            .telefono_otro = txtTelefonoOtro.Text
            .celular = txtCelular.Text
            .email = txtEmail.Text.Trim
            .codigo_postal = txtCodigoPostal.Text
            .sexo = cmbSexo.Text.Substring(0, 1)
            .estado_civil = cmbEstadoCivil.SelectedValue
            .nivel_educativo = cmbNivelEducativo.SelectedValue
            .ocupacion = cmbOcupacion.SelectedValue
            .apellido_casada = txtApellidoCasada.Text
            .direccion_trabajo = txtDireccionTrabajo.Text.Trim
            .referencia_trabajo = txtReferenciaTrabajo.Text.Trim
            .telefono_trabajo = txtTelefonoTrabajo.Text
            .linea_credito_mn = CDec(txtLineaCreditoMN.Text)
            .linea_credito_me = CDec(txtLineaCreditoME.Text)
            .situacion_crediticia = cmbSituacionCrediticia.SelectedValue
            .calificacion = cmbCalificacion.SelectedValue
            .zona_comercial = cmbZonaComercial.SelectedValue
            .pagina_web = txtPaginaWeb.Text
            .usuario_web = txtUsuarioWeb.Text
            .clave_web = txtClaveWeb.Text
            .item_flujo = cmbItemFlujo.SelectedValue
            .banco_pago_mn = cmbBancoMN.SelectedValue
            .cuenta_bancaria_mn = txtCuentaBancariaMN.Text
            .banco_pago_me = cmbBancoME.SelectedValue
            .cuenta_bancaria_me = txtCuentaBancariaME.Text
            .cuenta_detraccion = txtCuentaDetraccion.Text
            .porcentaje_detraccion = CDec(txtPorcentajeDetraccion.Text)
            .comentario = txtComentario.Text
            .exige_garante = IIf(ckbExigeGarante.Checked = True, "SI", "NO")
            .indica_preferente = IIf(ckbIndicaPreferente.Checked = True, "SI", "NO")
            .indica_fallecido = IIf(ckbIndicaFallecido.Checked = True, "SI", "NO")
            .estado = IIf(ckbIndicaActivo.Checked = True, "A", "I")
            .indica_cliente = IIf(IndicaCliente = True, "SI", "NO")
            .indica_proveedor = IIf(IndicaProveedor = True, "SI", "NO")
            .agencia_registro = "A0000" & MyUsuario.almacen
            .agencia_modifica = "A0000" & MyUsuario.almacen
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario
        End With
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
            txtApellidoPaterno.Text = .apellido_paterno
            txtApellidoMaterno.Text = .apellido_materno
            txtNombre.Text = .nombres
            If .fecha_nacimiento.Date <> FechaNulo.Date Then txtFechaNacimiento.Text = .fecha_nacimiento
            ckbIndicaNoDomiciliado.Checked = IIf(.indica_no_domiciliado = "SI", True, False)
            cmbPais.SelectedValue = .pais
            txtDomicilio.Text = .domicilio
            cmbDepartamento.SelectedValue = .departamento
            cmbProvincia.SelectedValue = .provincia
            cmbDistrito.SelectedValue = .ubigeo
            txtReferencia.Text = .referencia
            txtTelefono.Text = .telefono
            txtTelefonoOtro.Text = .telefono_otro
            txtCelular.Text = .celular
            txtEmail.Text = .email
            txtCodigoPostal.Text = .codigo_postal
            cmbSexo.SelectedIndex = IIf(.sexo = "M", 0, 1)
            cmbEstadoCivil.SelectedValue = .estado_civil
            cmbNivelEducativo.SelectedValue = .nivel_educativo
            cmbOcupacion.SelectedValue = .ocupacion
            txtApellidoCasada.Text = .apellido_casada
            txtDireccionTrabajo.Text = .direccion_trabajo
            txtReferenciaTrabajo.Text = .referencia_trabajo
            txtTelefonoTrabajo.Text = .telefono_trabajo
            txtLineaCreditoMN.Text = EvalDato(.linea_credito_mn, txtLineaCreditoMN.Tag)
            txtLineaCreditoME.Text = EvalDato(.linea_credito_me, txtLineaCreditoME.Tag)
            cmbSituacionCrediticia.SelectedValue = .situacion_crediticia
            cmbCalificacion.SelectedValue = .calificacion
            cmbZonaComercial.SelectedValue = .zona_comercial
            txtPaginaWeb.Text = .pagina_web
            txtUsuarioWeb.Text = .usuario_web
            txtClaveWeb.Text = .clave_web
            cmbItemFlujo.SelectedValue = .item_flujo
            cmbBancoMN.SelectedValue = .banco_pago_mn
            txtCuentaBancariaMN.Text = .cuenta_bancaria_mn
            cmbBancoME.SelectedValue = .banco_pago_me
            txtCuentaBancariaME.Text = .cuenta_bancaria_me
            txtCuentaDetraccion.Text = .cuenta_detraccion
            txtPorcentajeDetraccion.Text = EvalDato(.porcentaje_detraccion, txtPorcentajeDetraccion.Tag)
            txtComentario.Text = .comentario
            ckbExigeGarante.Checked = IIf(.exige_garante = "SI", True, False)
            ckbIndicaPreferente.Checked = IIf(.indica_preferente = "SI", True, False)
            ckbIndicaFallecido.Checked = IIf(.indica_fallecido = "SI", True, False)
            ckbIndicaActivo.Checked = IIf(.estado = "A", True, False)
            IndicaCliente = IIf(.indica_cliente = "SI", True, False)
            IndicaProveedor = IIf(.indica_proveedor = "SI", True, False)
        End With
    End Sub

    Private Sub ValidarDocumento(MyDocumentoTipo As String, MyDocumentoNumero As String)
        Dim MyOtraCuentaComercial As New entCuentaComercial
        Dim MyDNI As String

        If MyDocumentoNumero.Length <> 0 Then
            If MyDocumentoTipo = "6" And ckbIndicaNoDomiciliado.Checked = False Then ' Persona Natural con RUC
                If MyDocumentoNumero.Trim.Length = 11 Then
                    If MyDocumentoNumero.Substring(0, 2) <> "10" Then
                        Resp = MsgBox("El RUC de una persona natural debe empezar con 10.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
                        txtDocumentoNumero.Focus()
                    Else
                        ' Buscar si existe la persona registrada con su DNI
                        MyDNI = MyDocumentoNumero.Substring(2, 8)
                        MyOtraCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, "01", MyDNI)
                        If Not MyOtraCuentaComercial.cuenta_comercial Is Nothing Then
                            Resp = MsgBox("El cliente " & MyOtraCuentaComercial.razon_social & " se encuentra registrado con su DNI " & MyOtraCuentaComercial.nro_documento, MsgBoxStyle.Critical, "PROCESO CANCELADO")
                            txtDocumentoNumero.Focus()
                        Else
                            MyConsultaRUC = dalVenta.ObtenerDatosRUC(MyDocumentoNumero)
                            If Not MyConsultaRUC(0).RUC Is Nothing Then
                                Dim MyTexto As String = MyConsultaRUC(0).RAZON_SOCIAL
                                Dim MyDelimitadores() As String = {" ", ","}
                                Dim MyVector() As String
                                Dim MyPosicion As Byte = 1

                                MyVector = MyTexto.Split(MyDelimitadores, StringSplitOptions.None)

                                For Each MyItem As String In MyVector
                                    Select Case MyPosicion
                                        Case Is = 1 : txtApellidoPaterno.Text = MyItem
                                        Case Is = 2 : txtApellidoMaterno.Text = MyItem
                                        Case Is = 3 : txtNombre.Text = MyItem
                                        Case Is = 4 : txtNombre.Text = txtNombre.Text & " " & MyItem
                                        Case Is = 5 : txtNombre.Text = txtNombre.Text & " " & MyItem
                                        Case Is = 6 : txtNombre.Text = txtNombre.Text & " " & MyItem
                                    End Select
                                    MyPosicion = MyPosicion + 1
                                Next

                                txtDomicilio.Text = MyConsultaRUC(0).DOMICILIO_FISCAL
                                cmbDepartamento.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 2)
                                cmbProvincia.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 4)
                                cmbDistrito.SelectedValue = MyConsultaRUC(0).UBIGEO.Substring(0, 6)

                                If MyConsultaRUC(0).ESTADO <> "ACTIVO" Then
                                    Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta en estado " & MyConsultaRUC(0).ESTADO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                    If Resp = vbYes Then
                                        txtDocumentoNumero.Text = MyDocumentoNumero
                                        txtFechaNacimiento.Focus()
                                    Else
                                        Call LimpiarFormulario(True)
                                        txtDocumentoNumero.Focus()
                                    End If
                                ElseIf MyConsultaRUC(0).CONDICION_DOMICILIO <> "HABIDO" Then
                                    Resp = MsgBox("El RUC " & MyDocumentoNumero & " se encuenta con domicilio " & MyConsultaRUC(0).CONDICION_DOMICILIO & "." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                    If Resp = vbYes Then
                                        txtDocumentoNumero.Text = MyDocumentoNumero
                                        txtFechaNacimiento.Focus()
                                    Else
                                        Call LimpiarFormulario(True)
                                        txtDocumentoNumero.Focus()
                                    End If
                                Else
                                    txtDocumentoNumero.Text = MyDocumentoNumero
                                    txtFechaNacimiento.Focus()
                                End If
                            Else
                                Resp = MsgBox("El RUC " & MyDocumentoNumero & " no existe en el padrón de Sunat." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                If Resp = vbYes Then
                                    txtDocumentoNumero.Text = MyDocumentoNumero
                                    txtApellidoPaterno.Focus()
                                Else
                                    txtDocumentoNumero.Focus()
                                End If
                            End If
                        End If
                    End If
                Else
                    Resp = MsgBox("El RUC " & MyDocumentoNumero & " no tiene 11 dígitos." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                    If Resp = vbYes Then
                        txtDocumentoNumero.Text = MyDocumentoNumero
                        txtApellidoPaterno.Focus()
                    Else
                        txtDocumentoNumero.Focus()
                    End If
                End If
            Else
                txtDocumentoNumero.Text = MyDocumentoNumero
                txtApellidoPaterno.Focus()
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
            If cmbOcupacion.SelectedIndex = -1 Then NombreCampo = "OCUPACION" : GrabarRegistro = False
            If cmbNivelEducativo.SelectedIndex = -1 Then NombreCampo = "NIVEL EDUCATIVO" : GrabarRegistro = False
            If cmbEstadoCivil.SelectedIndex = -1 Then NombreCampo = "ESTADO CIVIL" : GrabarRegistro = False
            If cmbSexo.SelectedIndex = -1 Then NombreCampo = "SEXO" : GrabarRegistro = False
            If txtCelular.Text.Trim.Length = 0 Then NombreCampo = "CELULAR" : GrabarRegistro = False
            If txtTelefono.Text.Trim.Length = 0 Then NombreCampo = "TELEFONO 1" : GrabarRegistro = False
            If txtDomicilio.Text.Trim.Length = 0 Then NombreCampo = "DOMICILIO" : GrabarRegistro = False
            If txtFechaNacimiento.Text.Trim.Length = 0 Then NombreCampo = "F. NACIMIENTO" : GrabarRegistro = False
            If txtNombre.Text.Trim.Length = 0 Then NombreCampo = "NOMBRE" : GrabarRegistro = False
            If txtApellidoMaterno.Text.Trim.Length = 0 Then NombreCampo = "APELLIDO MATERNO" : GrabarRegistro = False
            If txtApellidoPaterno.Text.Trim.Length = 0 Then NombreCampo = "APELLIDO PATERNO" : GrabarRegistro = False

            If GrabarRegistro = False Then
                Resp = MsgBox("Falta registrar información en el campo " & NombreCampo, MsgBoxStyle.Critical, "PROCESO CANCELADO")
            Else
                UC_ToolBar.btnGrabar_Visible = False
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
        Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "C", "NO")
        MyForm.ShowDialog()
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then Call PoblarFormulario()
    End Sub

#End Region

End Class
