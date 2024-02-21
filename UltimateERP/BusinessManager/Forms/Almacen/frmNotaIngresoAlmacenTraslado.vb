Public Class frmNotaIngresoAlmacenTraslado
    Private MyGuia As entGuia
    Private MyOperacionAlmacen As entOperacionAlmacen
    Private MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
    Private MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

    Private MyTipoIngresoSalida As String = "I"

    Private SaltarSiguiente As Boolean = True

    Private Sub frmNotaIngresoAlmacenTraslado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmNotaIngresoAlmacenTraslado_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")
        Call LimpiarFormulario(True)

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumeroGuia As String = txtNumeroGuia.Text.Trim
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyGuia = New entGuia
            If String.IsNullOrEmpty(MyNumeroGuia) Then
                Dim MyForm As New frmGuiaTrasladoLista(MyGuia, txtEjercicio.Text, txtMes.Text, "P")
                MyForm.ShowDialog()
                If Not MyGuia.guia Is Nothing Then MyGuia = dalGuia.ObtenerGuiaTrasladoInterno(MyGuia)
            Else
                MyGuia = dalGuia.ObtenerGuiaTrasladoInterno(MyNumeroGuia)
            End If
            If Not MyGuia.guia Is Nothing Then
                EnableTextBox(txtNumeroGuia, FALSE)
                txtNumeroGuia.Text = MyGuia.comprobante_serie & "/" & MyGuia.comprobante_numero
                txtFechaEmision.Text = EvalDato(MyGuia.comprobante_fecha, txtFechaEmision.Tag)
                txtFechaTraslado.Text = EvalDato(MyGuia.comprobante_fecha_traslado, txtFechaTraslado.Tag)
                MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, MyGuia.almacen, MyGuia.referencia_cuo)
                gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion
                txtOperacionFecha.Focus()
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario(IniciarGuia As Boolean)
        If IniciarGuia = True Then MyGuia = New entGuia
        MyOperacionAlmacen = New entOperacionAlmacen
        MyDetallesOperacion = New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        MyDetallesOperacionSeries = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

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

        txtNumeroGuia.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtOperacionFecha.Text = EvalDato(Now.Date, "F")

        EnableTextBox(txtNumeroGuia, True)

        ckbIndicaAnulado.Visible = False
        UC_ToolBar.btnAceptar_Visible = True
        txtNumeroGuia.Focus()
    End Sub

    Private Sub ActivarFormulario(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtOperacionFecha, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)
        EnableDataGridView(gvOperacionAlmacenLineas, IndicaActivo)
    End Sub

    Private Sub EvaluarExisteResumen()
        Dim CodigoProducto As String

        If MyDetallesOperacion.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                CodigoProducto = MyDetallesOperacion(NEle).PRODUCTO
                MyDetallesOperacion(NEle).FECHA_VENCIMIENTO = FechaNulo
                If dalProducto.EvaluarSiExisteResumenAlmacen(MyUsuario.almacen, MyDetallesOperacion(NEle).NUMERO_LOTE, MyDetallesOperacion(NEle).PRODUCTO) Then
                    MyDetallesOperacion(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                End If

                If dalProducto.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, MyUsuario.almacen, MyDetallesOperacion(NEle).NUMERO_LOTE, MyDetallesOperacion(NEle).PRODUCTO) Then
                    MyDetallesOperacion(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                End If
            Next

            Call EvaluarExisteControlSeries()
        End If
    End Sub

    Private Sub EvaluarExisteControlSeries()
        Dim MyControlSerie As dsControlSeries.CONTROL_SERIESDataTable
        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
            For NFil As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                MyControlSerie = dalControlSeries.ObtenerControlSeries(MyUsuario.empresa, MyDetallesOperacionSeries(NFil).PRODUCTO, MyDetallesOperacionSeries(NFil).NUMERO_SERIE)
                If MyControlSerie.Rows.Count <> 0 Then
                    MyDetallesOperacionSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                End If
            Next
        End If
    End Sub

    Private Sub PoblarFormulario()
        Dim Operacion As String = MyOperacionAlmacen.operacion
        Dim Comentario As String = MyOperacionAlmacen.comentario
        Call LimpiarFormulario(True)

        MyOperacionAlmacen = dalOperacionAlmacen.ObtenerOperacion(Operacion)
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            MyGuia = dalGuia.ObtenerGuiaTrasladoInterno(MyOperacionAlmacen.referencia_serie, MyOperacionAlmacen.referencia_numero)

            With MyOperacionAlmacen
                txtOperacion.Text = .operacion
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                EnableTextBox(txtNumeroGuia, False)
                txtNumeroGuia.Text = MyGuia.comprobante_serie & "/" & MyGuia.comprobante_numero
                txtFechaEmision.Text = EvalDato(MyGuia.comprobante_fecha, txtFechaEmision.Tag)
                txtFechaTraslado.Text = EvalDato(MyGuia.comprobante_fecha_traslado, txtFechaTraslado.Tag)

                MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetallesOperacionAlmacen(MyUsuario.empresa, MyUsuario.almacen, .operacion)
                MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, txtOperacion.Text)
                gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion

                If .comentario.Trim.Length = 0 Then
                    txtComentario.Text = Comentario
                Else
                    txtComentario.Text = .comentario.Trim
                End If

                ActivarFormulario(False)
            End With
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario(True)
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyOperacionAlmacen = New entOperacionAlmacen
        MyOperacionAlmacen.almacen = MyUsuario.almacen
        MyOperacionAlmacen.tipo_operacion = "11"
        Dim MyForm As New frmOperacionesAlmacenes(MyOperacionAlmacen, MyTipoIngresoSalida, True, "SN")
        MyForm.ShowDialog()
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            Call PoblarFormulario()
            UC_ToolBar.btnAceptar_Visible = False
            UC_ToolBar.btnEditar_Focus = True
        End If

    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        MyOperacionAlmacen = dalOperacionAlmacen.ObtenerOperacion(MyGuia.referencia_cuo)
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            Try
                UC_ToolBar.btnAceptar_Visible = False

                MyOperacionAlmacen.operacion = Nothing
                MyOperacionAlmacen.almacen = MyUsuario.almacen
                MyOperacionAlmacen.ejercicio = MyUsuario.ejercicio
                MyOperacionAlmacen.mes = MyUsuario.mes.ToString("00")
                MyOperacionAlmacen.tipo_es = "I"
                MyOperacionAlmacen.fecha_operacion = EvalDato(txtOperacionFecha.Text, "F")
                MyOperacionAlmacen.comentario = IIf(txtComentario.Text.Trim.Length = 0, Space(1), txtComentario.Text)
                MyOperacionAlmacen.usuario_registro = MyUsuario.usuario
                MyOperacionAlmacen.usuario_modifica = MyUsuario.usuario

                MyDetallesOperacionSeries = dalOperacionAlmacen.ObtenerDetalleSeries(MyUsuario.empresa, MyGuia.referencia_cuo)

                Call EvaluarExisteResumen()

                MyOperacionAlmacen = dalOperacionAlmacen.GrabarOperacionAlmacen(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries)
                txtOperacion.Text = MyOperacionAlmacen.operacion

                Resp = MsgBox("La Nota de Ingreso por Traslado se grabó con éxito.", MsgBoxStyle.Information, "GRABAR NOTA DE INGRESO POR TRASLADO")
                Call ActivarFormulario(False)
                UC_ToolBar.btnImprimir_Focus = True
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
        Dim Comentario As String = txtComentario.Text.Trim

        If txtOperacion.Text.Trim.Length <> 0 Then
            If MyDetallesOperacion.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                    MyDetalles.ImportRow(MyDetallesOperacion(NEle))
                Next

                For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
                    CodigoProducto = MyDetalles(NEle).PRODUCTO
                    If MyDetalles(NEle).INDICA_SERIE = "SI" Then
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & " SERIES: "
                        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                            For NFila As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                                If MyDetallesOperacionSeries(NFila).PRODUCTO = CodigoProducto Then
                                    MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA & MyDetallesOperacionSeries(NFila).NUMERO_SERIE & " / "
                                End If
                            Next
                        End If
                        MyDetalles(NEle).DESCRIPCION_AMPLIADA = MyDetalles(NEle).DESCRIPCION_AMPLIADA.Substring(0, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim.Length - 1)
                    End If
                    MyDetallesImprimir.Rows.Add(CodigoProducto, MyDetalles(NEle).DESCRIPCION_AMPLIADA.Trim, MyDetalles(NEle).CODIGO_COMPRA, MyDetalles(NEle).CANTIDAD, MyDetalles(NEle).NUMERO_LOTE)
                Next
            End If

            Dim MyForm As New frmOperacionAlmacenImprimir(txtOperacion.Text, CDate(txtOperacionFecha.Text), MyUsuario.almacen, "TRASLADO INTERNO", IIf(Comentario.Length = 0, Space(1), Comentario), MyDetallesImprimir)
            MyForm.ShowDialog()
            UC_ToolBar.btnEditar_Focus = True
        End If
    End Sub

#End Region


End Class
