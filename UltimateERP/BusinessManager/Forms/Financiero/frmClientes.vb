
Public Class frmClientes

    Private MyCuentaComercial As New entCuentaComercial

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private Sub frmClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbPais, "_NACIONALIDAD")
        ActualizarListaGenerica(cmbDepartamento, "_UBIGEO_REGION")
        ActualizarListaGenerica(cmbEstadoCivil, "_ESTADO_CIVIL")
        ActualizarListaGenerica(cmbNivelEducativo, "_NIVEL_EDUCATIVO")
        ActualizarListaEmpresa(cmbOcupacion, "OPE_OCUPACION")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = False

    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub txtRazonSocial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRazonSocial.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDomicilio.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            cmbDepartamento.Focus()
        End If
    End Sub

    Private Sub ValidarFechas_Validated(sender As Object, e As EventArgs) Handles txtFechaNacimiento.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        ActualizarTablaProvincia("_UBIGEO_PROVINCIA", cmbProvincia, cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        ActualizarTablaUbigeo("_UBIGEO", cmbDistrito, cmbDepartamento.SelectedValue, cmbProvincia.SelectedValue)
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        cmbDocumentoTipo.SelectedValue = "1"
        cmbPais.SelectedValue = "9589"
        cmbDepartamento.SelectedValue = "15"
        cmbProvincia.SelectedValue = "1501"
        cmbDistrito.SelectedValue = "150101"

        ActualizarCombos = True

        Call ActivarCabecera(True)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnGrabar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmClientesLista(MyCuentaComercial)
                MyForm.ShowDialog()
                If Not MyCuentaComercial.nro_documento Is Nothing Then MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyCuentaComercial.tipo_documento, MyCuentaComercial.nro_documento)
            Else
                MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                Call ActivarCabecera(False)
                Call PoblarCuentaComercial()
                txtRazonSocial.Focus()
            Else
                Resp = MsgBox("El documento " & cmbDocumentoTipo.Text & " " & MyDocumentoNumero & " no se encuentra registrado.", MsgBoxStyle.Exclamation, "CLIENTE NO EXISTE")
                txtDocumentoNumero.Focus()
            End If
        End If
    End Sub

    Private Sub PoblarCuentaComercial()
        With MyCuentaComercial
            txtCuentaComercial.Text = .cuenta_comercial
            cmbDocumentoTipo.SelectedValue = .tipo_documento
            txtDocumentoNumero.Text = .nro_documento
            txtRazonSocial.Text = .razon_social
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
            If .fecha_nacimiento.Date <> FechaNulo.Date Then txtFechaNacimiento.Text = .fecha_nacimiento
            cmbSexo.SelectedIndex = IIf(.sexo = "M", 0, 1)
            cmbEstadoCivil.SelectedValue = .estado_civil
            cmbNivelEducativo.SelectedValue = .nivel_educativo
            cmbOcupacion.SelectedValue = .ocupacion
            txtNombreConviviente.Text = .apellido_casada
            txtDireccionTrabajo.Text = .direccion_trabajo
            txtReferenciaTrabajo.Text = .referencia_trabajo
            txtTelefonoTrabajo.Text = .telefono_trabajo
        End With
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Call LimpiarFormulario()
        Dim MyForm As New frmClientesLista(MyCuentaComercial)
        MyForm.ShowDialog()
        If Not MyCuentaComercial.nro_documento Is Nothing Then
            MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyCuentaComercial.tipo_documento, MyCuentaComercial.nro_documento)
            Call ActivarCabecera(False)
            Call PoblarCuentaComercial()
            txtRazonSocial.Focus()
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim ContinuarGrabar As Boolean = True

        If txtRazonSocial.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Nombre o Razón Social del Cliente .", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtRazonSocial.Focus()
            ContinuarGrabar = False
        ElseIf txtDomicilio.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Domicilio del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtDomicilio.Focus()
            ContinuarGrabar = False
        ElseIf txtTelefono.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Número de Teléfono 1.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtTelefono.Focus()
            ContinuarGrabar = False
        ElseIf txtCelular.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar el Número de Celular.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtCelular.Focus()
            ContinuarGrabar = False
        ElseIf txtFechaNacimiento.Text.Trim.Length = 0 Then
            Resp = MsgBox("Debe registrar la Fecha de Nacimiento del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            txtFechaNacimiento.Focus()
            ContinuarGrabar = False
        ElseIf cmbSexo.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Sexo del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbSexo.Focus()
            ContinuarGrabar = False
        ElseIf cmbEstadoCivil.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Estado Civil del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbEstadoCivil.Focus()
            ContinuarGrabar = False
        ElseIf cmbNivelEducativo.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar el Nivel Educativo del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbNivelEducativo.Focus()
            ContinuarGrabar = False
        ElseIf cmbOcupacion.SelectedIndex = -1 Then
            Resp = MsgBox("Debe registrar la Ocupación del Cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            cmbOcupacion.Focus()
            ContinuarGrabar = False
        End If

        If ContinuarGrabar = True Then
            Try
                UC_ToolBar.btnGrabar_Visible = False

                With MyCuentaComercial
                    .empresa = MyUsuario.empresa
                    .tipo_documento = cmbDocumentoTipo.SelectedValue
                    .nro_documento = txtDocumentoNumero.Text
                    .razon_social = txtRazonSocial.Text.Trim
                    .domicilio = txtDomicilio.Text.Trim
                    .referencia = txtReferencia.Text.Trim
                    .departamento = cmbDepartamento.SelectedValue
                    .provincia = cmbProvincia.SelectedValue
                    .ubigeo = cmbDistrito.SelectedValue
                    .telefono = txtTelefono.Text
                    .telefono_otro = txtTelefonoOtro.Text
                    .celular = txtCelular.Text
                    .email = txtEmail.Text.Trim
                    .direccion_trabajo = txtDireccionTrabajo.Text.Trim
                    .referencia_trabajo = txtReferenciaTrabajo.Text.Trim
                    .telefono_trabajo = txtTelefonoTrabajo.Text
                    If txtFechaNacimiento.Text.Length <> 0 Then .fecha_nacimiento = CDate(txtFechaNacimiento.Text)
                    .sexo = cmbSexo.Text.Substring(0, 1)
                    .estado_civil = cmbEstadoCivil.SelectedValue
                    .nivel_educativo = cmbNivelEducativo.SelectedValue
                    .ocupacion = cmbOcupacion.SelectedValue

                    .nombre_conviviente = txtNombreConviviente.Text

                    .agencia_registro = "A0000" & MyUsuario.almacen
                    .agencia_modifica = "A0000" & MyUsuario.almacen
                    .usuario_registro = MyUsuario.usuario
                    .usuario_modifica = MyUsuario.usuario
                End With

                If dalFinanciamiento.GrabarCliente(MyCuentaComercial) = True Then
                    Resp = MsgBox("Los cambios se grabaron con éxito.", MsgBoxStyle.Information, "GRABAR CLIENTE")
                    UC_ToolBar.btnGrabar_Visible = True
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If

    End Sub

#End Region

End Class
