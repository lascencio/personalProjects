Public Class frmProducto
    Private MyProducto As entProducto

    Private Sub frmProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaGenerica(cmbTipoExistencia, "_TIPO_EXISTENCIA")
        ActualizarListaGenerica(cmbUnidadMedida, "_UNIDAD_MEDIDA")
        ActualizarListaGenerica(cmbUnidadCompra, "_UNIDAD_MEDIDA")
        ActualizarListaGenerica(cmbUnidadVenta, "_UNIDAD_MEDIDA")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        ActualizarListaEmpresa(cmbFamilia, "PRODUCTO_FAMILIA")
        ActualizarListaEmpresa(cmbSubFamilia, "PRODUCTO_SUB_FAMILIA")
        ActualizarListaEmpresa(cmbTipo, "PRODUCTO_TIPO")
        ActualizarListaEmpresa(cmbSubTipo, "PRODUCTO_SUB_TIPO")
        ActualizarListaEmpresa(cmbUbicacion, "COM_ALMACEN_UBICACION")

        Call LimpiarFormulario(True)

        txtProducto.Focus()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
        UC_ToolBar.btnBorrar_Visible = False
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = txtProducto.Text.Trim

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            MyProducto = New entProducto
            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto)
                MyForm.ShowDialog()
            Else
                MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
            End If

            If Not MyProducto.producto Is Nothing Then
                Call PoblarFormulario()
            Else
                Call LimpiarFormulario(True)
                txtProducto.Text = MyCodigo
            End If
            txtDescripcionAmpliada.Focus()
        End If
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        Dim MyIndex As Integer
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            ActualizarSubTabla(cmbSubFamilia, "PRODUCTO_SUB_FAMILIA", sender.Items(MyIndex)("REFERENCIA"))
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Dim MyIndex As Integer
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            ActualizarSubTabla(cmbSubTipo, "PRODUCTO_SUB_TIPO", sender.Items(MyIndex)("REFERENCIA"))
        End If
    End Sub

    Private Sub txtDescripcionAmpliada_Validated(sender As Object, e As EventArgs) Handles txtDescripcionAmpliada.Validated
        If txtDescripcionAmpliada.Text.Trim.Length <> 0 Then
            If txtDescripcion.Text.Trim.Length = 0 Then txtDescripcion.Text = Strings.Left(txtDescripcionAmpliada.Text.Trim, 50)
        Else
            txtDescripcion.Text = Nothing
        End If
    End Sub

    Private Sub ckbIndicaNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaNuevo.CheckedChanged
        LimpiarFormulario(True)
        txtDescripcionAmpliada.Focus()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario(InicializarProducto As Boolean)
        If InicializarProducto = True Then MyProducto = New entProducto

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
                If ctrl.Name <> "ckbIndicaNuevo" Then
                    ctrl.Checked = False
                End If
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
    End Sub

    Private Sub PonerValoresDefault()
        cmbUnidadMedida.SelectedValue = "07" : cmbUnidadCompra.SelectedValue = "07" : cmbUnidadVenta.SelectedValue = "07"
        cmbTipoExistencia.SelectedValue = "01"
        cmbTipoMoneda.SelectedValue = "1"
        cmbFamilia.SelectedValue = "000" : cmbSubFamilia.SelectedValue = "000"
        cmbTipo.SelectedValue = "000" : cmbSubTipo.SelectedValue = "000"
        cmbProcedencia.SelectedIndex = 1
        cmbPrioridad.SelectedIndex = 1
        cmbAlmacen.SelectedValue = MyUsuario.almacen : cmbUbicacion.SelectedValue = "000000"
        ckbIndicaActivo.Checked = True : ckbIndicaAfecto.Checked = True : ckbIndicaValidaStock.Checked = True

        If ckbIndicaNuevo.Checked = True Then
            EnableTextBox(txtProducto, False)
            txtDescripcionAmpliada.Focus()
        Else
            EnableTextBox(txtProducto, True)
            txtProducto.Focus()
        End If
    End Sub

    Private Sub PoblarFormulario()
        Call LimpiarFormulario(False)
        txtProducto.ReadOnly = True
        txtProducto.BackColor = Color.LightYellow
        MyProducto = dalProducto.Obtener(MyProducto.empresa, MyProducto.producto)
        If Not MyProducto.producto Is Nothing Then Call LlenarFormulario()
    End Sub

    Private Sub LlenarFormulario()
        With MyProducto
            txtProducto.Text = .producto
            cmbTipoExistencia.SelectedValue = .tipo_existencia
            txtDescripcion.Text = .descripcion
            txtDescripcionAmpliada.Text = .descripcion_ampliada
            cmbFamilia.SelectedValue = .producto_familia
            cmbSubFamilia.SelectedValue = .producto_sub_familia
            cmbTipo.SelectedValue = .producto_tipo
            cmbSubTipo.SelectedValue = .producto_sub_tipo
            cmbUnidadMedida.SelectedValue = .unidad_medida
            cmbUnidadCompra.SelectedValue = .unidad_compra
            cmbUnidadVenta.SelectedValue = .unidad_venta

            cmbAlmacen.SelectedValue = .almacen
            cmbUbicacion.SelectedValue = .ubicacion

            cmbProcedencia.Text = IIf(.procedencia = "I", "IMPORTADO", "NACIONAL")
            cmbTipoMoneda.SelectedValue = .tipo_moneda
            cmbPrioridad.Text = IIf(.prioridad = "A", "ALTA", IIf(.prioridad = "B", "BAJA", "MEDIA"))
            txtCodigoCompra.Text = .codigo_compra
            txtDescripcionCompra.Text = .descripcion_compra
            ckbIndicaActivo.Checked = IIf(.estado = "A", True, False)
            ckbIndicaSerie.Checked = IIf(.indica_serie = "SI", True, False)
            ckbIndicaLote.Checked = IIf(.indica_lote = "SI", True, False)
            ckbIndicaVencimiento.Checked = IIf(.indica_vencimiento = "SI", True, False)
            ckbIndicaValidaStock.Checked = IIf(.indica_valida_stock = "SI", True, False)
            ckbIndicaAfecto.Checked = IIf(.indica_afecto = "SI", True, False)

            txtPartidaArancelaria.Text = .partida_arancelaria
            txtCodigoAntiguo.Text = .codigo_antiguo
            txtComentario.Text = .comentario
        End With
        txtDescripcionAmpliada.Focus()
    End Sub

    Private Sub CapturarDatos()
        With MyProducto
            .empresa = MyUsuario.empresa
            .producto = txtProducto.Text
            .descripcion_ampliada = txtDescripcionAmpliada.Text.Trim
            .descripcion = txtDescripcion.Text.Trim
            .codigo_antiguo = txtCodigoAntiguo.Text.Trim
            .codigo_compra = txtCodigoCompra.Text.Trim
            .descripcion_compra = txtDescripcionCompra.Text.Trim
            .unidad_medida = cmbUnidadMedida.SelectedValue
            .unidad_compra = cmbUnidadCompra.SelectedValue
            .unidad_venta = cmbUnidadVenta.SelectedValue
            .tipo_existencia = cmbTipoExistencia.SelectedValue
            .tipo_moneda = cmbTipoMoneda.SelectedValue
            .producto_tipo = cmbTipo.SelectedValue
            .producto_sub_tipo = cmbSubTipo.SelectedValue
            .producto_familia = cmbFamilia.SelectedValue
            .producto_sub_familia = cmbSubFamilia.SelectedValue
            .procedencia = cmbProcedencia.Text.Substring(0, 1)
            .partida_arancelaria = txtPartidaArancelaria.Text
            .prioridad = cmbPrioridad.Text.ToString.Substring(0, 1)
            .almacen = cmbAlmacen.SelectedValue
            .ubicacion = cmbUbicacion.SelectedValue
            .comentario = txtComentario.Text
            .indica_serie = IIf(ckbIndicaSerie.Checked = True, "SI", "NO")
            .indica_lote = IIf(ckbIndicaLote.Checked = True, "SI", "NO") '
            .indica_vencimiento = IIf(ckbIndicaVencimiento.Checked = True, "SI", "NO")
            .indica_afecto = IIf(ckbIndicaAfecto.Checked = True, "SI", "NO")
            .indica_valida_stock = IIf(ckbIndicaValidaStock.Checked = True, "SI", "NO")
            .estado = IIf(ckbIndicaActivo.Checked = True, "A", "I")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario
        End With
    End Sub

#End Region

#Region "Botones"

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_Toolbar_TB_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario(True)
    End Sub

    Private Sub UC_Toolbar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        Dim NombreCampo As String
        Dim GrabarRegistro As Boolean = True

        If txtDescripcionAmpliada.Text.Trim.Length = 0 Then NombreCampo = "DESCRIPCION" : GrabarRegistro = False

        If GrabarRegistro = False Then
            Resp = MsgBox("Falta registrar información en el campo " & NombreCampo, MsgBoxStyle.Critical, "PROCESO CANCELADO")
        Else
            Try
                Call CapturarDatos()

                MyProducto = dalProducto.Grabar(MyProducto)
                Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "REGISTRO DE PRODUCTO")
                Call LimpiarFormulario(True)

                Call ActualizarMyDTProductos()

            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub UC_Toolbar_TB_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyProducto = New entProducto
        Dim MyForm As New frmProductoLista(MyProducto)
        MyForm.ShowDialog()
        If Not MyProducto.producto Is Nothing Then Call PoblarFormulario()
    End Sub

#End Region


End Class
