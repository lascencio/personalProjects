Public Class frmGuiaPorVenta

    Private MyCuentaComercial As entCuentaComercial
    Private MyDireccionEnvio As dsCuentasComerciales.DIRECCION_ENVIODataTable

    Private MyVenta As entVenta
    Private MyVentaDetalle As dsVentas.VENTA_DETDataTable

    Private MyGuia As entGuia

    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable
    Private MyAsientoTipo As String = "00"
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String

    Private MySender As String

    Private FechaUltimoComprobante As Date

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmGuiaPorVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmGuiaPorVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_GUIAS")
        ActualizarListaEmpresa(cmbConductor, "COM_TRANSPORTISTA")
        ActualizarListaEmpresa(cmbPlaca, "COM_UNIDAD_TRANSPORTE")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnGrabar_Visible = False

        UC_ToolBar.btnAceptar_Visible = True

    End Sub

    Private Sub ValidarFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated, txtComprobanteFechaTraslado.Validated
        Dim MyFecha As Date

        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.Name = "txtComprobanteFechaTraslado" Then
                    MyFecha = CDate(txtComprobanteFechaTraslado.Text)
                    If MyFecha < CDate(txtComprobanteFecha.Text) Then
                        Resp = MsgBox("La fecha de traslado debe ser igual o mayor que la fecha del comprobante de venta.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                        txtComprobanteFechaTraslado.Text = Nothing
                        txtComprobanteFechaTraslado.Focus()
                    Else
                        cmbConductor.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtComentario_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        UC_ToolBar.btnGrabar_Focus = True
    End Sub

    Private Sub txtComprobanteNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprobanteNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumero As String = sender.text
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            If sender.text.ToString.Length > 0 Then
                If IsNumeric(sender.text) Then
                    sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                    If txtGuia.Text = Nothing Then
                        If sender.name = "txtComprobanteSerie" Then
                            Call PoblarCorrelativo()
                            txtComprobanteNumero.Focus()
                        ElseIf sender.name = "txtComprobanteNumero" Then
                            UC_ToolBar.btnGrabar_Focus = True
                        End If
                    End If
                Else
                    If sender.name = "txtComprobanteSerie" Then
                        sender.text = "0001"
                        If txtGuia.Text = Nothing Then Call PoblarCorrelativo()
                    ElseIf sender.name = "txtComprobanteNumero" Then
                        If txtGuia.Text = Nothing Then Call PoblarCorrelativo()
                    Else
                        sender.text = Nothing
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbDireccionEnvio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDireccionEnvio.SelectedIndexChanged
        If cmbDireccionEnvio.SelectedIndex <> -1 Then
            txtReferencia.Text = cmbDireccionEnvio.Items(cmbDireccionEnvio.SelectedIndex)(4)
        Else
            txtReferencia.Text = Nothing
        End If
    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprobante.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyVenta = New entVenta
            Dim MyForm As New frmVentaDirectaLista(MyVenta, txtEjercicio.Text, txtMes.Text, "TODOS", "TODOS", True)
            MyForm.ShowDialog()
            If Not MyVenta.venta Is Nothing Then
                EnableTextBox(txtComprobante, False)
                Call PoblarVenta()
            End If
        End If
    End Sub

    Private Sub ckbIndicaAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaAnulado.CheckedChanged
        UC_ToolBar.btnAceptar_Visible = ckbIndicaAnulado.Checked
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()

        MyCuentaComercial = New entCuentaComercial
        MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable

        MyVenta = New entVenta
        MyVentaDetalle = New dsVentas.VENTA_DETDataTable

        MyGuia = New entGuia

        MyCorrelativo = New dsCorrelativo.CORRELATIVODataTable

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
            End If
        Next

        cmbDireccionEnvio.DataSource = MyDireccionEnvio
        gvVentaLineas.DataSource = MyVentaDetalle

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        ckbIndicaAnulado.Visible = False
        UC_ToolBar.btnAceptar_Visible = True

        txtComprobante.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")

        cmbAlmacen.SelectedValue = MyUsuario.almacen
        cmbDireccionEnvio.SelectedValue = "01"
        cmbConductor.SelectedIndex = 0
        cmbPlaca.SelectedIndex = 0
        txtComprobanteNumero.Text = Strings.Right(CUO_Nulo, txtComprobanteNumero.MaxLength)

        EnableTextBox(txtComprobante, True)

        cmbComprobanteSerie.SelectedIndex = CInt(MyUsuario.serie_asignada) - 1

        Call PoblarCorrelativo()

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub PoblarCorrelativo()
        MyCorrelativo = dalVenta.ObtenerCorrelativo("09", cmbComprobanteSerie.SelectedValue, "SI")
        If MyCorrelativo.Rows.Count = 0 Then
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = CDate("01/" & MyAsientoMes & "/" & MyAsientoEjercicio)
        Else
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
            FechaUltimoComprobante = MyCorrelativo(0).COMPROBANTE_FECHA
        End If
        txtComprobanteFecha.Text = EvalDato(Now.Date, txtComprobanteFecha.Tag)
        txtComprobanteFechaTraslado.Text = EvalDato(Now.Date, txtComprobanteFecha.Tag)
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub PoblarFormulario()
        Dim Comprobante As String
        Dim Guia As String = MyGuia.guia
        Call LimpiarFormulario()
        MyGuia = dalGuia.ObtenerCabecera(Guia)
        If Not MyGuia.guia Is Nothing Then
            With MyGuia
                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)
                MyVenta = dalVenta.Obtener(.venta)

                Comprobante = MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero

                txtComprobante.Text = Comprobante

                txtGuia.Text = .guia
                txtVenta.Text = .venta

                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtCuentaComercial.Text = .cuenta_comercial
                txtRazonSocial.Text = MyCuentaComercial.razon_social

                Call ActualizarDireccionEnvio()

                cmbDireccionEnvio.SelectedValue = .domicilio_envio

                txtReferencia.Text = cmbDireccionEnvio.Items(cmbDireccionEnvio.SelectedIndex)(4)

                cmbAlmacen.SelectedValue = .almacen
                cmbComprobanteSerie.SelectedValue = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                txtComprobanteFechaTraslado.Text = EvalDato(.comprobante_fecha_traslado, "F")
                cmbConductor.Text = .conductor_nombre
                cmbPlaca.SelectedValue = .numero_placa

                txtComentario.Text = .comentario

                EnableTextBox(txtComprobante, False)

                Call ActivarCabecera(False)

                '' Solo es posible modificar si se cumple que:
                '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó
                '' 2.- El movimiento no se encuentra anulado
                '' 3.- Para la Forma de Pago diferente a EF: Efectivo, que el valor del campo IMPORTE_SALDO sea igual al del campo IMPORTE_TOTAL_ORIGEN
                '' 4.- Si no ha sido enviado a SUNAT

                ckbIndicaAnulado.Visible = True

                If .estado = "N" Then
                    ckbIndicaAnulado.Checked = True
                    ckbIndicaAnulado.Enabled = False
                Else
                    ckbIndicaAnulado.Checked = False
                    ckbIndicaAnulado.Enabled = True
                End If
            End With

            MyVentaDetalle = dalVenta.ObtenerDetalles(MyUsuario.empresa, txtVenta.Text)

            gvVentaLineas.DataSource = MyVentaDetalle
            gvVentaLineas.ClearSelection()

            UC_ToolBar.btnAceptar_Visible = False
            UC_ToolBar.btnImprimir_Visible = True
            UC_ToolBar.btnImprimir_Focus = True
        End If
    End Sub

    Private Sub PoblarVenta()
        Dim Comprobante As String
        Dim Venta As String = MyVenta.venta
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            With MyVenta
                Comprobante = .comprobante_serie & "-" & .comprobante_numero
                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)
                txtComprobante.Text = Comprobante
                txtVenta.Text = .venta
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtCuentaComercial.Text = .cuenta_comercial
                txtRazonSocial.Text = MyCuentaComercial.razon_social

                Call ActualizarDireccionEnvio()
                cmbDireccionEnvio.SelectedValue = MyCuentaComercial.domicilio_envio
                txtReferencia.Text = cmbDireccionEnvio.Items(cmbDireccionEnvio.SelectedIndex)(4)

                MyVentaDetalle = dalVenta.ObtenerDetalles(MyUsuario.empresa, txtVenta.Text)

                gvVentaLineas.DataSource = MyVentaDetalle
                gvVentaLineas.ClearSelection()

                cmbAlmacen.SelectedValue = .almacen
                txtComprobanteFechaTraslado.Focus()
            End With
        End If
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtComprobanteFechaTraslado, IndicaActivo)

        EnableComboBox(cmbConductor, IndicaActivo)
        EnableComboBox(cmbPlaca, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)

        If IndicaActivo = True Then txtComprobanteFecha.Focus()
    End Sub

    Private Sub CapturarEncabezado()
        With MyGuia
            .empresa = MyUsuario.empresa
            .guia = txtGuia.Text
            .ejercicio = MyAsientoEjercicio
            .mes = MyAsientoMes
            .tipo_operacion = "G4"
            .venta = txtVenta.Text
            .cuenta_comercial = txtCuentaComercial.Text
            .comprobante_tipo = "09"
            .comprobante_serie = cmbComprobanteSerie.SelectedValue
            .comprobante_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then .comprobante_fecha = txtComprobanteFecha.Text
            If txtComprobanteFechaTraslado.Text.Length <> 0 Then .comprobante_fecha_traslado = txtComprobanteFechaTraslado.Text
            .almacen = cmbAlmacen.SelectedValue
            .centro_distribucion = cmbDireccionEnvio.SelectedValue
            .comentario = txtComentario.Text
            .conductor_dni = cmbConductor.SelectedValue
            .conductor_nombre = cmbConductor.SelectedText
            .numero_placa = cmbPlaca.SelectedValue
            .motivo_traslado = "01"
            '.estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario
        End With
    End Sub

    Private Sub ActualizarDireccionEnvio()
        MyDireccionEnvio = dalCuentaComercial.ObtenerDomicilioEnvio(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
        cmbDireccionEnvio.DataSource = MyDireccionEnvio
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Call CapturarEncabezado()
        Try
            UC_ToolBar.btnAceptar_Visible = False

            If txtVenta.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = False Then
                'MyGuia = dalGuia.GrabarPorVentaDirecta(MyGuia, MyVentaDetalle)
                'txtGuia.Text = MyGuia.guia

                'Resp = MsgBox("La Guia de Remisión se grabó con éxito.", MsgBoxStyle.Information, "GUIA DE REMISION POR VENTA")
                'UC_ToolBar.btnImprimir_Focus = True
            End If

            UC_ToolBar.btnAceptar_Visible = True
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyGuia = New entGuia
        Dim MyForm As New frmGuiaRemitenteLista(MyGuia, txtEjercicio.Text, txtMes.Text, "TODOS", "G4", "TODOS")
        MyForm.ShowDialog()
        If Not MyGuia.guia Is Nothing Then Call PoblarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtGuia.Text.Trim <> "" Then
            If txtGuia.Text.Trim.Length <> 0 Then
                Dim MyForm As New frmGuiaRemitenteImprimir(MyGuia, "VENTA")
                MyForm.ShowDialog()
            End If
        End If
    End Sub

#End Region

End Class
