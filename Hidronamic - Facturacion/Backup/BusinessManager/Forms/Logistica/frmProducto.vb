Public Class frmProducto
    Private MyAccion As String = "NUEVO"
    Private MyProducto As entProducto

    Private Sub frmProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarTabla("_TIPO_EXISTENCIA", cmbTipoExistencia, "01")
        ActualizarTabla("_UNIDAD_MEDIDA", cmbUnidadMedida, "07")
        ActualizarTabla("_UNIDAD_MEDIDA", cmbUnidadCompra, "07")
        ActualizarTabla("_UNIDAD_MEDIDA", cmbUnidadVenta, "07")
        ActualizarTabla("_TIPO_MONEDA", cmbTipoMoneda, "2")

        ActualizarListaEmpresa(cmbFamilia, "PRODUCTO_FAMILIA")
        ActualizarListaEmpresa(cmbSubFamilia, "PRODUCTO_SUB_FAMILIA")
        ActualizarListaEmpresa(cmbTipo, "PRODUCTO_SUBTIPO")
        ActualizarListaEmpresa(cmbSubTipo, "PRODUCTO_TIPO")
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")
        ActualizarListaEmpresa(cmbUbicacion, "COM_ALMACEN_UBICACION")

        Call LimpiarFormulario(True)

        txtProducto.Focus()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
    End Sub

    Private Sub LimpiarFormulario(ByVal LimpiarNumeroDocumento As Boolean)
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.name = "txtCodigoProducto" Then
                    If LimpiarNumeroDocumento Then ctrl.text = ""
                Else
                    Select Case ctrl.tag
                        Case Is = "D" : ctrl.text = "0.00"
                        Case Is = "E" : ctrl.text = "0"
                        Case Else : ctrl.text = ""
                    End Select
                End If
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            End If
        Next

        Call PonerValoresDefault()
        txtProducto.ReadOnly = False
        txtProducto.Focus()

    End Sub

    Private Sub PonerValoresDefault()
        cmbUnidadMedida.SelectedValue = "07" : cmbUnidadCompra.SelectedValue = "07" : cmbUnidadVenta.SelectedValue = "07"
        cmbTipoExistencia.SelectedValue = "01"
        cmbTipoMoneda.SelectedValue = "2"
        cmbFamilia.SelectedValue = "000" : cmbSubFamilia.SelectedValue = "000000"
        cmbTipo.SelectedValue = "000" : cmbSubTipo.SelectedValue = "000000"
        cmbProcedencia.SelectedIndex = 1
        cmbPrioridad.SelectedIndex = 1
        cmbAlmacen.SelectedValue = "000" : cmbUbicacion.SelectedValue = "000000"
        cmbCuentaCompraMN.SelectedIndex = -1 : cmbCuentaCompraME.SelectedIndex = -1
        cmbCuentaVentaMN.SelectedIndex = -1 : cmbCuentaVentaME.SelectedIndex = -1
        cmbCuentaCostoMN.SelectedIndex = -1 : cmbCuentaCostoME.SelectedIndex = -1
        ckbEstado.Checked = True : ckbIndicaAfecto.Checked = True : ckbIndicaValidaStock.Checked = True
    End Sub

    Private Sub LlenarFormulario()
        MyProducto = dalProducto.Obtener(MyProducto.producto)
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
            txtDecimales.Text = .decimales
            txtFactorCompra.Text = EvalDato(.factor_compra, txtFactorCompra.Tag)
            txtFactorVenta.Text = EvalDato(.factor_venta, txtFactorVenta.Tag)
            txtVolumenCompra.Text = EvalDato(.volumen_compra, txtVolumenCompra.Tag)
            txtVolumenVenta.Text = EvalDato(.volumen_venta, txtVolumenVenta.Tag)
            txtPesoCompra.Text = EvalDato(.peso_compra, txtPesoCompra.Tag)
            txtPesoVenta.Text = EvalDato(.peso_venta, txtPesoVenta.Tag)

            txtStockActual.Text = .stock_actual
            txtStockComprometido.Text = .stock_comprometido
            txtStockTransito.Text = .stock_transito

            cmbAlmacen.SelectedValue = .almacen
            cmbUbicacion.SelectedValue = .ubicacion

            txtPrecioCompraMN.Text = .precio_compra_mn
            txtPrecioVentaMN.Text = .precio_venta_mn
            txtPrecioCompraME.Text = .precio_compra_me
            txtPrecioVentaME.Text = .precio_venta_me

            cmbProcedencia.Text = IIf(.procedencia = "I", "IMPORTADO", "NACIONAL")
            cmbCuentaCompraMN.SelectedValue = .cuenta_compra_mn
            cmbCuentaVentaMN.SelectedValue = .cuenta_venta_mn
            cmbCuentaCompraME.SelectedValue = .cuenta_compra_me
            cmbCuentaVentaME.SelectedValue = .cuenta_venta_me
            cmbCuentaCostoMN.SelectedValue = .cuenta_costo_mn
            cmbCuentaCostoME.SelectedValue = .cuenta_costo_me
            cmbTipoMoneda.SelectedValue = .tipo_moneda
            cmbPrioridad.Text = IIf(.prioridad = "A", "ALTA", IIf(.prioridad = "B", "BAJA", "MEDIA"))
            txtCodigoCompra.Text = .codigo_compra
            txtDescripcionCompra.Text = .descripcion_compra
            txtTiempoEntrega.Text = .tiempo_entrega
            txtTiempoProceso.Text = .tiempo_proceso
            txtStockSeguridad.Text = .stock_seguridad
            txtCaducidad.Text = .caducidad
            ckbEstado.Checked = IIf(.estado = "A", True, False)
            ckbIndicaSerie.Checked = IIf(.indica_serie = "SI", True, False)
            ckbIndicaLote.Checked = IIf(.indica_lote = "SI", True, False)
            ckbIndicaVencimiento.Checked = IIf(.indica_vencimiento = "SI", True, False)
            ckbIndicaValidaStock.Checked = IIf(.indica_valida_stock = "SI", True, False)
            ckbIndicaAfecto.Checked = IIf(.indica_afecto = "SI", True, False)
            ckbIndicaPromocional.Checked = IIf(.indica_promocional = "SI", True, False)
            ckbIndicaCompuesto.Checked = IIf(.indica_compuesto = "SI", True, False)
            txtStockMinimo.Text = .stock_minimo
            txtStockMaximo.Text = .stock_maximo
            txtPartidaArancelaria.Text = .partida_arancelaria

            txtCostoFOB.Text = .costo_fob
            txtFlete.Text = .flete
            txtSeguros.Text = .seguros
            txtAgenteAduanas.Text = .agente_aduanas
            txtDerechoAdValorem.Text = .derecho_advalorem
            txtGastosDespacho.Text = .gastos_despacho
            txtCostoEstandar.Text = .costo_estandar

            txtCodigoAntiguo.Text = .codigo_antiguo
            txtComentario.Text = .comentario
            txtImagen.Text = .imagen
        End With
    End Sub

    'Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
    '    If cmbFamilia.SelectedIndex <> -1 Then
    '        'ActualizarTabla(MyUsuario.empresa, "PRODUCTO_SUB_FAMILIA", cmbFamilia.SelectedValue, cmbSubFamilia, "000000")
    '        ActualizarTabla(MyUsuario.empresa, "PRODUCTO_SUB_FAMILIA", "000", cmbSubFamilia, "000000")
    '        cmbSubFamilia.SelectedIndex = 0
    '    End If
    'End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.SelectedIndex <> -1 Then
            ActualizarTabla(MyUsuario.empresa, "PRODUCTO_SUB_TIPO", cmbTipo.SelectedValue, cmbSubTipo, "000000")
            cmbSubTipo.SelectedIndex = 0
        End If
    End Sub

    Private Sub ValidarNumero(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDecimales.Validated, txtCaducidad.Validated, txtTiempoProceso.Validated, txtTiempoEntrega.Validated, txtStockSeguridad.Validated, txtFactorCompra.Validated, txtFactorVenta.Validated, txtPesoCompra.Validated, txtPesoVenta.Validated, txtVolumenCompra.Validated, txtVolumenVenta.Validated
        sender.text = EvalDato(sender.text, sender.tag)
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProducto = New entProducto
            MyCodigo = sender.Text.Trim
            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto)
                MyForm.ShowDialog()
            Else
                MyProducto = dalProducto.Obtener(MyCodigo)
            End If

            If Not MyProducto.producto Is Nothing Then
                Call LimpiarFormulario(True)
                Call LlenarFormulario()
                txtProducto.ReadOnly = True
                txtDescripcion.Focus()
            Else
                Call LimpiarFormulario(True)
                txtProducto.ReadOnly = False
                If MyCodigo = "" Then
                    txtProducto.Focus()
                Else
                    txtProducto.Text = MyCodigo
                    txtDescripcion.Focus()
                End If

            End If
        End If
    End Sub

#Region "Botones"

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        MyProducto = New entProducto
        With MyProducto
            .empresa = MyUsuario.empresa
            .producto = txtProducto.Text
            .tipo_existencia = cmbTipoExistencia.SelectedValue '
            .descripcion = txtDescripcion.Text '
            .descripcion_ampliada = txtDescripcionAmpliada.Text '
            .producto_familia = cmbFamilia.SelectedValue '
            .producto_sub_familia = cmbSubFamilia.SelectedValue '
            .producto_tipo = cmbTipo.SelectedValue '
            .producto_sub_tipo = cmbSubTipo.SelectedValue '
            .unidad_medida = cmbUnidadMedida.SelectedValue '
            .unidad_compra = cmbUnidadCompra.SelectedValue '
            .unidad_venta = cmbUnidadVenta.SelectedValue '
            .decimales = txtDecimales.Text '
            .factor_compra = txtFactorCompra.Text '
            .factor_venta = txtFactorVenta.Text '
            .volumen_compra = txtVolumenCompra.Text '
            .volumen_venta = txtVolumenVenta.Text '
            .peso_compra = txtPesoCompra.Text '
            .peso_venta = txtPesoVenta.Text '
            .stock_actual = txtStockActual.Text
            .stock_comprometido = txtStockComprometido.Text
            .stock_transito = txtStockTransito.Text
            .almacen = cmbAlmacen.SelectedValue '
            .ubicacion = cmbUbicacion.SelectedValue '
            .precio_compra_mn = txtPrecioCompraMN.Text
            .precio_venta_mn = txtPrecioVentaMN.Text
            .precio_compra_me = txtPrecioCompraME.Text
            .precio_venta_me = txtPrecioVentaME.Text
            .procedencia = cmbProcedencia.Text.Substring(0, 1) '
            .cuenta_compra_mn = cmbCuentaCompraMN.SelectedValue '
            .cuenta_compra_me = cmbCuentaCompraME.SelectedValue '
            .cuenta_venta_mn = cmbCuentaVentaMN.SelectedValue '
            .cuenta_venta_me = cmbCuentaVentaME.SelectedValue '
            .cuenta_costo_mn = cmbCuentaCostoMN.SelectedValue '
            .cuenta_costo_me = cmbCuentaCostoME.SelectedValue '
            .tipo_moneda = cmbTipoMoneda.SelectedValue '
            .prioridad = cmbPrioridad.Text.ToString.Substring(0, 1) '
            .codigo_compra = txtCodigoCompra.Text '
            .descripcion_compra = txtDescripcionCompra.Text '
            .tiempo_entrega = txtTiempoEntrega.Text '
            .tiempo_proceso = txtTiempoProceso.Text '
            .stock_seguridad = txtStockSeguridad.Text '
            .caducidad = txtCaducidad.Text '
            .estado = IIf(ckbEstado.Checked = True, "A", "I") '
            .indica_serie = IIf(ckbIndicaSerie.Checked = True, "SI", "NO") '
            .indica_lote = IIf(ckbIndicaLote.Checked = True, "SI", "NO") '
            .indica_vencimiento = IIf(ckbIndicaVencimiento.Checked = True, "SI", "NO") '
            .indica_valida_stock = IIf(ckbIndicaValidaStock.Checked = True, "SI", "NO") '
            .indica_afecto = IIf(ckbIndicaAfecto.Checked = True, "SI", "NO") '
            .indica_compuesto = IIf(ckbIndicaCompuesto.Checked = True, "SI", "NO") '
            .indica_promocional = IIf(ckbIndicaPromocional.Checked = True, "SI", "NO") '
            .stock_minimo = txtStockMinimo.Text
            .stock_maximo = txtStockMaximo.Text
            .partida_arancelaria = txtPartidaArancelaria.Text '
            .costo_fob = txtCostoFOB.Text
            .flete = txtFlete.Text
            .seguros = txtSeguros.Text
            .agente_aduanas = txtAgenteAduanas.Text
            .derecho_advalorem = txtDerechoAdValorem.Text
            .gastos_despacho = txtGastosDespacho.Text
            .costo_estandar = txtCostoEstandar.Text
            .codigo_antiguo = txtCodigoAntiguo.Text '
            .codigo_vendedor = Nothing '
            .codigo_comprador = Nothing '
            .ultima_compra = Nothing '
            .ultima_venta = Nothing '
            .comentario = txtComentario.Text '
            .imagen = txtImagen.Text '
            .usuario_registro = MyUsuario.usuario '
        End With

        Try
            MyProducto = dalProducto.Grabar(MyProducto)
            Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
            Call LimpiarFormulario(True)
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click() Handles UC_ToolBar.TB_btnBorrar_Click
        If String.IsNullOrEmpty(txtProducto.Text) Then
            MyAccion = Nothing
        Else
            MyAccion = "ELIMINAR"
            Try
                If dalProducto.Borrar(MyProducto.empresa, MyProducto.producto) = True Then
                    Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                    Call LimpiarFormulario(True)
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyProducto = New entProducto
        If txtProducto.Text Is Nothing Then
            MyAccion = Nothing : MsgBox("Debe seleccionar una Producto", MsgBoxStyle.Information, "MODIFICAR")
        Else
            MyAccion = "MODIFICAR"
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
            If Not MyProducto.producto Is Nothing Then
                Call LimpiarFormulario(True)
                Call LlenarFormulario()
                txtProducto.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        MyAccion = "IMPRIMIR"
        Dim MyForm As New frmProductoImprimir()
        MyForm.ShowDialog()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario(True)
        Call PonerValoresDefault()
    End Sub

#End Region

End Class
