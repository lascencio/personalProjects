Public Class frmNotaSalidaAlmacen

    Private MyOperacionAlmacen As entOperacionAlmacen
    Private MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
    Private MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

    Private MyCuentaComercial As New entCuentaComercial
    Private MyProducto As entProducto

    Private MyTipoOperacion As String = "S"
    Private MyStock As Decimal

    Private MyStockAlmacen As dsStockAlmacen.STOCK_X_ALMACENDataTable

    Private EvaluarDisponible As Boolean

    Private Sub frmNotaSalidaAlmacenNew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmNotaSalidaAlmacenNew_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyTiposOperacion As dsTablasGenericas.DETALLESDataTable
        Dim MyTiposOperacionNew As New dsTablasGenericas.DETALLESDataTable

        MyTiposOperacion = CargarTablaGenerica("_TIPO_OPERACION")

        If MyTiposOperacion.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyTiposOperacion.Rows.Count - 1
                If MyTiposOperacion(NEle).LOGICO_01 = 0 Then
                    MyTiposOperacionNew.ImportRow(MyTiposOperacion(NEle))
                End If
            Next
        End If

        cmbTipoOperacion.DataSource = MyTiposOperacionNew

        cmbAlmacen.DataSource = MyDTAlmacenes

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = True

    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperacionFecha.Validated
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtOperacionFecha" Then
                    txtComentario.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto()
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As EventArgs) Handles txtCantidad.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)
        If CDec(sender.Text) = 0 Then
            txtProducto.Focus()
        Else
            If txtIndicaSerie.Text = "SI" Then
                Call ValidarBotonAceptar()
            Else
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumero As String = sender.text
        Dim IndicaRegistroValido As Boolean = True

        Dim CodigoProducto As String = ""

        Dim CantidadSolicitada As Decimal

        Dim MyDetallesOperacionSeriesNew As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        Dim CantidadStock As Decimal = CDec(txtCantidadStock.Text)

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True

            txtCantidad.Text = EvalDato(txtCantidad.Text, txtCantidad.Tag)
            CantidadSolicitada = CDec(txtCantidad.Text)

            If CantidadSolicitada > CantidadStock And MyTipoOperacion <> "I" Then
                Resp = MsgBox("La cantidad registrada no puede ser mayor que el STOCK ACTUAL.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CANTIDAD NO VALIDA")
                txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
            Else
                If txtIndicaSerie.Text = "SI" And CantidadSolicitada <> 0 Then

                    If MyProducto.producto_tipo = "001" Then
                        Dim MyForm As New frmOperacionDetalleSeriesVehiculares(cmbAlmacen.SelectedValue, txtProducto.Text, CantidadSolicitada, MyDetallesOperacionSeries, MyTipoOperacion)
                        MyForm.ShowDialog()
                    Else
                        Dim MyForm As New frmOperacionDetalleSeries(cmbAlmacen.SelectedValue, txtProducto.Text, CantidadSolicitada, MyDetallesOperacionSeries, MyTipoOperacion)
                        MyForm.ShowDialog()
                    End If

                    If CDec(txtCantidad.Text) = 0 Then IndicaRegistroValido = False

                    If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                        For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                            If MyDetallesOperacionSeries(NEle).ESTADO = "N" Then
                                IndicaRegistroValido = False
                                CodigoProducto = MyDetallesOperacionSeries(NEle).PRODUCTO
                            Else
                                MyDetallesOperacionSeriesNew.ImportRow(MyDetallesOperacionSeries(NEle))
                            End If
                        Next
                    End If

                    If IndicaRegistroValido = True Then
                        Call ValidarBotonAceptar()
                    Else
                        MyDetallesOperacionSeries = MyDetallesOperacionSeriesNew
                        If MyDetallesOperacion.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                                If MyDetallesOperacion(NEle).PRODUCTO = CodigoProducto Then
                                    MyDetallesOperacion.Rows(NEle).Delete()
                                    Exit For
                                End If
                            Next
                            gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion
                        End If

                        Call LimpiarLinea()
                    End If
                Else
                    btnAceptar.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub ckbIndicaAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaAnulado.CheckedChanged
        If txtOperacion.Text.Trim.Length <> 0 Then
            If MyOperacionAlmacen.ejercicio = MyUsuario.ejercicio And MyOperacionAlmacen.mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
                If MyOperacionAlmacen.estado = "A" Then
                    If ckbIndicaAnulado.Checked = True Then
                        UC_ToolBar.btnAceptar_Visible = True
                    Else
                        UC_ToolBar.btnAceptar_Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gvOperacionAlmacenLineas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvOperacionAlmacenLineas.CellClick
        If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
            Dim MyIndex As Integer
            Dim Linea As String = sender.Rows(sender.CurrentRow.Index).Cells("LINEA").Value
            Dim CodigoProducto As String = sender.Rows(sender.CurrentRow.Index).Cells("PRODUCTO").Value
            Dim MyDetallesOperacionSeriesNew As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
            If Not sender.CurrentRow Is Nothing Then
                MyIndex = sender.CurrentRow.Index
                Linea = sender.Rows(MyIndex).Cells("LINEA").Value
                CodigoProducto = sender.Rows(MyIndex).Cells("PRODUCTO").Value

                If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                        If MyDetallesOperacionSeries(NEle).PRODUCTO = CodigoProducto Then MyDetallesOperacionSeries(NEle).ESTADO = "N"
                    Next

                    For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                        If MyDetallesOperacionSeries(NEle).ESTADO <> "N" Then
                            MyDetallesOperacionSeriesNew.ImportRow(MyDetallesOperacionSeries(NEle))
                        End If
                    Next

                End If

                MyDetallesOperacionSeries = MyDetallesOperacionSeriesNew
                MyDetallesOperacion.Rows(MyIndex).Delete()
            End If

            If MyDetallesOperacion.Rows.Count = 0 Then EnableComboBox(cmbAlmacen, True)

            sender.DataSource = MyDetallesOperacion
            sender.ClearSelection()
        End If
    End Sub

    Private Sub cmbAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAlmacen.SelectedIndexChanged
        If cmbAlmacen.SelectedIndex <> -1 And txtProducto.Text.Trim.Length <> 0 Then
            Call BuscarStock(txtProducto.Text.Trim)
        End If

    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyOperacionAlmacen = New entOperacionAlmacen
        MyDetallesOperacion = New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        MyDetallesOperacionSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

        MyStockAlmacen = New dsStockAlmacen.STOCK_X_ALMACENDataTable
        MyStock = 0

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

        gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion

        Call PonerValoresDefault()
        Call ActivarFormulario(True)

        txtComentario.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtOperacionFecha.Text = EvalDato(Now.Date, "F")
        cmbTipoOperacion.SelectedValue = "25"
        cmbAlmacen.SelectedValue = MyUsuario.almacen

        ckbIndicaAnulado.Visible = False

        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarFormulario(ByVal IndicaActivo As Boolean)
        'EnableComboBox(cmbAlmacen, IndicaActivo)
        EnableComboBox(cmbTipoOperacion, IndicaActivo)

        EnableTextBox(txtOperacionFecha, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)
        EnableTextBox(txtProducto, IndicaActivo)
        EnableTextBox(txtCantidad, IndicaActivo)

        btnAceptar.Enabled = IndicaActivo
        btnNuevo.Enabled = IndicaActivo

        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3)
        btnNuevo.ImageIndex = IIf(IndicaActivo = True, 0, 2)

        EnableDataGridView(gvOperacionAlmacenLineas, IndicaActivo)

    End Sub

    Private Sub ValidarProducto()
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = txtProducto.Text.Trim

        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto, "NO", "A")
            MyForm.ShowDialog()
        Else
            If IsNumeric(MyCodigo) Then
                MyCodigo = "P" & Strings.Right("0000000" & CStr(Val(MyCodigo.Trim)), 7)
            End If
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyProducto.producto)
            txtProducto.Text = MyProducto.producto
            txtProductoDescripcion.Text = MyProducto.descripcion_ampliada
            txtIndicaSerie.Text = MyProducto.indica_serie

            Call BuscarStock(MyProducto.producto)
            If MyTipoOperacion = "S" Then
                If MyStockAlmacen.Rows.Count = 0 Then
                    Resp = MsgBox("No existe stock para este producto.", MsgBoxStyle.Information, "OPERACION DENEGADA")
                    Call LimpiarLinea()
                End If
            End If
        Else
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub BuscarStock(CodigoProducto As String)
        If cmbAlmacen.SelectedIndex <> -1 Then
            MyStockAlmacen = dalProducto.BuscarStocksAlmacen(cmbAlmacen.SelectedValue, CodigoProducto)
            If MyStockAlmacen.Rows.Count <> 0 Then
                txtCantidadStock.Text = EvalDato(MyStockAlmacen(0).STOCK, txtCantidadStock.Tag)
            Else
                txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
            End If
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub LimpiarLinea()
        txtLinea.Text = Nothing
        txtIndicaSerie.Text = Nothing
        txtProducto.Text = Nothing
        txtProductoDescripcion.Text = Nothing
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtCantidadStock.Text = EvalDato(0, txtCantidadStock.Tag)
        txtProducto.Focus()
    End Sub

    Private Sub ValidarBotonAceptar()
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)

        Dim ContinuarGuardarDetalle As Boolean = True

        If Cantidad = 0 Then
            Resp = MsgBox("Falta registrar un valor en el campo CANTIDAD.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PROCESO CANCELADO")
            ContinuarGuardarDetalle = False
        End If

        If ContinuarGuardarDetalle = True Then
            Call GuardarDetalle()
            txtProducto.Focus()
        End If
    End Sub

    Private Sub GuardarDetalle()
        Dim NumeroLinea As Byte = 0
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)

        Dim GrabarNuevaLinea As Boolean = True

        If txtProducto.Text.Trim.Length <> 0 Then
            If MyDetallesOperacion.Rows.Count <> 0 Then
                For NEle As Byte = 0 To MyDetallesOperacion.Rows.Count - 1
                    If MyDetallesOperacion(NEle).PRODUCTO = txtProducto.Text Then
                        MyDetallesOperacion(NEle).CANTIDAD = Cantidad
                        GrabarNuevaLinea = False
                    End If
                    NumeroLinea = CByte(MyDetallesOperacion(NEle).LINEA)
                Next
            End If

            If GrabarNuevaLinea = True Then
                NumeroLinea = NumeroLinea + 1
                MyDetallesOperacion.Rows.Add(NumeroLinea, MyProducto.producto, MyProducto.codigo_compra, MyProducto.descripcion, 0, 0, Cantidad, Numero_Lote_Nulo, FechaNulo, txtIndicaSerie.Text, "NO", "NO")

                EnableComboBox(cmbAlmacen, False)
            End If

            gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion
            gvOperacionAlmacenLineas.ClearSelection()
            Call LimpiarLinea()
        End If
    End Sub

    Private Sub PoblarFormulario()
        Dim OperacionAlmacen As String = MyOperacionAlmacen.operacion
        Dim AlmacenOperacion As String = MyOperacionAlmacen.almacen
        Call LimpiarFormulario()
        MyOperacionAlmacen = dalOperacionAlmacen.ObtenerOperacion(OperacionAlmacen)
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            With MyOperacionAlmacen

                cmbAlmacen.SelectedValue = .almacen
                cmbTipoOperacion.SelectedValue = .tipo_operacion

                txtOperacion.Text = .operacion
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, cmbAlmacen.SelectedValue, txtOperacion.Text)
                MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, txtOperacion.Text)


                Call EvaluarExisteResumen()

                gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion
                gvOperacionAlmacenLineas.ClearSelection()

                txtOperacionFecha.Text = EvalDato(.fecha_operacion, "F")
                txtComentario.Text = .comentario.Trim

                ActivarFormulario(False)

                ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)
            End With
        End If
    End Sub

    Private Sub EvaluarExisteResumen()
        Dim CodigoProducto As String
        'If txtOperacion.Text.Trim.Length = 0 And MyDetallesOperacion.Rows.Count <> 0 Then

        If MyDetallesOperacion.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                CodigoProducto = MyDetallesOperacion(NEle).PRODUCTO

                If dalProducto.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, MyDetallesOperacion(NEle).NUMERO_LOTE, MyDetallesOperacion(NEle).PRODUCTO) Then
                    MyDetallesOperacion(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                End If

                If dalProducto.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, MyDetallesOperacion(NEle).NUMERO_LOTE, MyDetallesOperacion(NEle).PRODUCTO) Then
                    MyDetallesOperacion(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                End If
            Next

            Call EvaluarExisteControlSeries()

        End If
    End Sub

    Private Sub EvaluarExisteControlSeries()
        EvaluarDisponible = True
        Dim MyControlSerie As dsControlSeries.CONTROL_SERIESDataTable
        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
            For NFil As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                MyControlSerie = dalControlSeries.ObtenerControlSeries(MyUsuario.empresa, MyDetallesOperacionSeries(NFil).PRODUCTO, MyDetallesOperacionSeries(NFil).NUMERO_SERIE)
                If MyControlSerie.Rows.Count <> 0 Then
                    MyDetallesOperacionSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                    If ckbIndicaAnulado.Checked = True Then
                        If MyControlSerie(0).ESTADO = "D" Then
                            EvaluarDisponible = False
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub CapturarEncabezado()
        With MyOperacionAlmacen
            .empresa = MyUsuario.empresa
            .almacen = cmbAlmacen.SelectedValue
            .operacion = txtOperacion.Text
            .tipo_operacion = cmbTipoOperacion.SelectedValue
            .ejercicio = txtEjercicio.Text
            .mes = txtMes.Text
            If txtOperacionFecha.Text.Length <> 0 Then .fecha_operacion = txtOperacionFecha.Text
            .comentario = txtComentario.Text.Trim
            .tipo_es = MyTipoOperacion
            .referencia_cuenta_comercial = txtCuentaComercial.Text
            .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
            .usuario_registro = MyUsuario.usuario
            .usuario_modifica = MyUsuario.usuario
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
        MyOperacionAlmacen = New entOperacionAlmacen
        MyOperacionAlmacen.almacen = cmbAlmacen.SelectedValue
        MyOperacionAlmacen.tipo_operacion = cmbTipoOperacion.SelectedValue
        Dim MyForm As New frmOperacionesAlmacenes(MyOperacionAlmacen, MyTipoOperacion, False, "SN")
        MyForm.ShowDialog()
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            Call PoblarFormulario()
            ckbIndicaAnulado.Visible = True
            UC_ToolBar.btnAceptar_Visible = False
        End If
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click

        If MyDetallesOperacion.Rows.Count = 0 Then
            Resp = MsgBox("Debe registrar productos a vender.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        Else
            Call EvaluarExisteResumen()

            Call CapturarEncabezado()
            Try
                UC_ToolBar.btnAceptar_Visible = False

                If txtOperacion.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                    If EvaluarDisponible = False Then
                        Resp = MsgBox("No es posible anular la Nota de Almacén." & vbCrLf & _
                                      "Existen Números de Serie disponibles.", MsgBoxStyle.Information, "ANULAR NOTA DE ALMACEN")
                    Else
                        Resp = MsgBox("Confirmar proceso de anulación de la Nota de Almacén.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR NOTA DE ALMACEN")
                        If Resp = 1 Then
                            If dalOperacionAlmacen.AnularOperacionAlmacen(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries) = True Then
                                Resp = MsgBox("La Nota de Almacén se anuló con éxito.", MsgBoxStyle.Information, "ANULAR NOTA DE ALMACEN")
                                Call LimpiarFormulario()
                            Else
                                ckbIndicaAnulado.Checked = False
                                UC_ToolBar.btnEditar_Focus = True
                            End If
                        End If
                    End If
                Else
                    MyOperacionAlmacen = dalOperacionAlmacen.GrabarOperacionAlmacen(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries)
                    txtOperacion.Text = MyOperacionAlmacen.operacion

                    Resp = MsgBox("La Nota de Almacén se grabó con éxito.", MsgBoxStyle.Information, "GRABAR NOTA DE ALMACEN")
                    Call ActivarFormulario(False)
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
                If txtOperacion.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
                If txtOperacion.Text.Trim.Length = 0 Then UC_ToolBar.btnAceptar_Visible = True
            End Try
        End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        Dim MyDetalles As New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        Dim MyDetallesImprimir As New dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable
        Dim CodigoProducto As String

        If txtOperacion.Text.Trim.Length <> 0 Then
            If MyDetallesOperacion.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                    MyDetalles.ImportRow(MyDetallesOperacion(NEle))
                Next

                For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
                    If MyDetalles(NEle).INDICA_SERIE = "SI" Then
                        'CodigoProducto = MyDetalles(NEle).PRODUCTO
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & " SERIES: "
                        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                            For NFila As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                                If MyDetallesOperacionSeries(NFila).PRODUCTO = MyDetalles(NEle).PRODUCTO Then
                                    MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & MyDetallesOperacionSeries(NFila).NUMERO_SERIE & " / "
                                End If
                            Next
                        End If
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA.Substring(0, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim.Length - 1)
                    End If
                    MyDetallesImprimir.Rows.Add(MyDetalles(NEle).PRODUCTO, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim, MyDetalles(NEle).CODIGO_COMPRA, MyDetalles(NEle).CANTIDAD, MyDetalles(NEle).NUMERO_LOTE)
                Next
            End If

            Dim MyForm As New frmOperacionAlmacenImprimir(txtOperacion.Text, CDate(txtOperacionFecha.Text), cmbAlmacen.Text, cmbTipoOperacion.Text, txtComentario.Text, MyDetallesImprimir)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarLinea()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Call ValidarBotonAceptar()
    End Sub

#End Region

End Class
