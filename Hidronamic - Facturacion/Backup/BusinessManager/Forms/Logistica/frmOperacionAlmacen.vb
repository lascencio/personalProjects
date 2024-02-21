Public Class frmOperacionAlmacen

    Private MyAccion As String = "NUEVO"
    Private MyOperacionAlmacen As entOperacionAlmacen
    Private MyOperacionAlmacenDetalle As entOperacionAlmacenDetalle
    Private MyCuentaComercial As entCuentaComercial
    Private MyProducto As entProducto
    Private MyTipoOperacion As String
    Private MyStock As Decimal
    Private MyLotesStock As dsStockAlmacen.STOCK_X_ALMACENDataTable

    Private MyDetallesOperacion As dsOperacionesAlmacen.DETALLES_OPERACIONDataTable

    Private Sub frmOperacionesAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOperacionesAlmacen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ActualizarListaEmpresa(cmbTipoOperacion, "_TIPO_OPERACION")
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaEmpresa(cmbComprobanteTipo, "COM_TIPO_COMPROBANTE")
        ActualizarListaGenerica(cmbComprobanteTipoMoneda, "_TIPO_MONEDA")

        cmbProductos.DataSource = dalProducto.BuscarProducto("T")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            txtComprobanteNombre.Text = sender.Items(sender.SelectedIndex)(2).ToString
        Else
            txtComprobanteNombre.Text = Nothing
        End If
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperacionFecha.Validated, txtComprobanteFecha.Validated, txtFechaVencimiento.Validated
        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtOperacionFecha" Then
                    cmbAlmacen.Focus()
                End If

                '    Dim Fecha As Date = sender.text
                '    If Fecha.Year <> CInt(MyUsuario.ejercicio) Or Fecha.Month <> MyUsuario.mes Then
                '        Resp = MsgBox("La fecha debe estar dentro del Periodo de Trabajo actual." & Chr(13) & "¿Desea continuar de todas maneras?", MsgBoxStyle.Information, Me.Text)
                '        If Resp = vbYes Then
                '            If sender.name = "txtOperacionFecha" Then
                '                cmbAlmacen.Focus()
                '            Else
                '                cmbComprobanteTipoMoneda.Focus()
                '            End If
                '        Else
                '            sender.text = Nothing
                '            sender.focus()
                '        End If
                '    End If
            End If
        End If
    End Sub

    Private Sub ValidarImporte(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteImporte.Validated, txtCantidad.Validated, txtPrecioUnitario.Validated, txtPrecioTotal.Validated
        If sender.text.ToString.Length <> 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            Call ActualizarValores()
            If sender.name = "txtComprobanteImporte" Then
                UC_ToolBar.btnGrabar_Focus = True
            ElseIf sender.name = "txtCantidad" And MyTipoOperacion = "I" Then
                txtPrecioUnitario.Focus()
            Else
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Sub ckbOperacionAnulada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbOperacionAnulada.CheckedChanged
        If String.IsNullOrEmpty(txtOperacion.Text) Then
            MyAccion = Nothing
        Else
            If gvOperacionAlmacenLineas.RowCount > 0 Then
                MyAccion = Nothing
                Resp = MsgBox("Debe eliminar los DETALLES DE LA OPERACION antes de anular la OPERACION.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
            Else
                Try
                    If ckbOperacionAnulada.Checked = True Then
                        If MyAccion = "MODIFICAR" Then
                            MyAccion = "ANULAR"
                            If dalOperacionAlmacen.Anular(cmbAlmacen.SelectedValue, txtOperacion.Text, "N") = True Then
                                Resp = MsgBox("La Operación se anuló con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                            End If
                        End If
                    Else
                        If MyAccion = "ACTIVAR" Then
                            MyAccion = "MODIFICAR"
                            Call dalOperacionAlmacen.CambiarEstado(cmbAlmacen.SelectedValue, txtOperacion.Text, "A")
                            Resp = MsgBox("La Operación se activo con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                        End If
                    End If
                    Call LimpiarFormulario()
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
        Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCliente As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmCuentaComercialLista(MyCuentaComercial, "P")
                MyForm.ShowDialog()
            Else
                MyCuentaComercial = dalCuentaComercial.Obtener(MyDocumentoTipo, MyDocumentoNumero)
            End If
            Call ObtenerCuentaComercial()
        End If
    End Sub

    Private Sub txtComentario_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComentario.Validated
        If cmbTipoOperacion.SelectedValue <> "02" And cmbTipoOperacion.SelectedValue <> "92" Then
            UC_ToolBar.btnGrabar_Focus = True
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""

        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProducto = New entProducto
            MyCodigo = sender.Text.Trim

            Call LimpiarLinea()

            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto, "NO", "A")
                MyForm.ShowDialog()
            Else
                MyProducto = dalProducto.Obtener(MyCodigo)
            End If

            If Not MyProducto.producto Is Nothing Then
                Continuar = True
                If MyTipoOperacion = "S" Then
                    MyLotesStock = dalProducto.BuscarStocksAlmacen(cmbAlmacen.SelectedValue, MyProducto.producto)
                    If MyLotesStock.Rows.Count = 0 Then
                        Resp = MsgBox("No existe stock para este producto.", MsgBoxStyle.Information, "OPERACION DENEGADA")
                        Continuar = False
                    Else
                        If MyLotesStock.Rows.Count = 1 Then
                            txtNumeroLote.Text = MyLotesStock(0).NUMERO_LOTE
                            txtFechaVencimiento.Text = EvalDato(MyLotesStock(0).FECHA_VENCIMIENTO, txtFechaVencimiento.Tag)
                            txtStockAnterior.Text = EvalDato(MyLotesStock(0).STOCK, txtStockAnterior.Tag)
                            txtCantidad.Focus()
                        Else
                            Dim MyForm As New frmLotesStockLista(MyLotesStock, txtNumeroLote, txtFechaVencimiento, txtStockAnterior)
                            MyForm.ShowDialog()
                            If txtNumeroLote.Text <> Nothing Then
                                txtCantidad.Focus()
                            Else
                                txtProducto.Focus()
                                Continuar = False
                            End If
                        End If
                    End If
                End If
                If Continuar = True Then
                    txtProducto.Text = MyProducto.producto
                    cmbProductos.SelectedValue = MyProducto.producto
                    txtIndicaLote.Text = MyProducto.indica_lote
                    If MyProducto.indica_lote = "SI" Then
                        Call MostrarLote(True)
                        txtNumeroLote.Focus()
                    Else
                        txtCantidad.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbTipoOperacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
        If cmbTipoOperacion.SelectedIndex <> -1 Then
            MyTipoOperacion = cmbTipoOperacion.Text.Substring(0, 1)
            If MyTipoOperacion = "S" Then
                txtNumeroLote.BackColor = Color.Moccasin
                txtFechaVencimiento.BackColor = Color.Moccasin
                txtPrecioUnitario.BackColor = Color.Moccasin

                txtNumeroLote.ForeColor = Color.DarkRed
                txtFechaVencimiento.ForeColor = Color.DarkRed
                txtPrecioUnitario.ForeColor = Color.DarkRed

                txtNumeroLote.ReadOnly = True
                txtFechaVencimiento.ReadOnly = True
                txtPrecioUnitario.ReadOnly = True

                txtNumeroLote.TabStop = False
                txtFechaVencimiento.TabStop = False
                txtPrecioUnitario.TabStop = False
            Else
                txtNumeroLote.BackColor = Color.AliceBlue
                txtFechaVencimiento.BackColor = Color.AliceBlue
                txtNumeroLote.BackColor = Color.AliceBlue

                txtNumeroLote.ForeColor = Color.MediumBlue
                txtFechaVencimiento.ForeColor = Color.MediumBlue
                txtNumeroLote.ForeColor = Color.MediumBlue

                txtNumeroLote.ReadOnly = False
                txtFechaVencimiento.ReadOnly = False
                txtNumeroLote.ReadOnly = False

                txtNumeroLote.TabStop = True
                txtFechaVencimiento.TabStop = True
                txtNumeroLote.TabStop = True
            End If
        End If
    End Sub

    Private Sub gvOperacionAlmacenLineas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOperacionAlmacenLineas.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            Dim Linea As String = sender.Rows(sender.CurrentRow.Index).Cells("LINEA").Value
            Dim MyDetalle As dsOperacionesAlmacen.DETALLES_OPERACIONRow
            Dim PrimaryKey(0) As Object

            PrimaryKey(0) = Linea

            MyDetalle = MyDetallesOperacion.Rows.Find(PrimaryKey)

            If Not (MyDetalle Is Nothing) Then
                txtLinea.Text = MyDetalle.LINEA
                txtProducto.Text = MyDetalle.PRODUCTO
                cmbProductos.Text = MyDetalle.DESCRIPCION_AMPLIADA
                txtNumeroLote.Text = MyDetalle.NUMERO_LOTE
                If MyDetalle.FECHA_VENCIMIENTO <> FechaNulo Then txtFechaVencimiento.Text = MyDetalle.FECHA_VENCIMIENTO
                txtCantidad.Text = EvalDato(MyDetalle.CANTIDAD, txtCantidad.Tag)
                txtPrecioUnitario.Text = EvalDato(MyDetalle.PRECIO_UNITARIO, txtPrecioUnitario.Tag)
                txtPrecioTotal.Text = EvalDato(Math.Round(MyDetalle.CANTIDAD * MyDetalle.PRECIO_UNITARIO, 2), txtPrecioTotal.Tag)
                txtIndicaLote.Text = MyDetalle.INDICA_LOTE
                Call MostrarLote(IIf(txtIndicaLote.Text = "SI", True, False))
                Call BuscarStockLote()
                txtCantidad.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumeroLote_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroLote.Validated
        If txtNumeroLote.TextLength <> 0 Then BuscarStockLote()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyAccion = "NUEVO"
        MyOperacionAlmacen = New entOperacionAlmacen
        MyOperacionAlmacenDetalle = New entOperacionAlmacenDetalle
        MyCuentaComercial = New entCuentaComercial
        MyProducto = New entProducto

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

        gvOperacionAlmacenLineas.DataSource = New dsOperacionesAlmacen.DETALLES_OPERACIONDataTable
        Call PonerValoresDefault()
        Call ActivarDetalles(False)
        Call ActivarCabecera(True)

        txtOperacionFecha.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        txtOperacionFecha.Text = EvalDato(Now.Date, "F")
        cmbAlmacen.SelectedValue = "000"
        cmbTipoOperacion.SelectedValue = "92"
        cmbDocumentoTipo.SelectedValue = "00"
        cmbComprobanteTipo.SelectedValue = "OT"
        cmbComprobanteTipoMoneda.SelectedValue = "1"
        cmbProductos.SelectedIndex = -1

        Call MostrarLote(False)

        cmbAlmacen.Enabled = True : cmbTipoOperacion.Enabled = True
        txtIndicaLote.Text = "NO"
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        txtOperacionFecha.Enabled = IndicaActivo
        cmbAlmacen.Enabled = IndicaActivo
        cmbTipoOperacion.Enabled = IndicaActivo
        txtComentario.Enabled = IndicaActivo
        cmbDocumentoTipo.Enabled = IndicaActivo
        txtDocumentoNumero.Enabled = IndicaActivo
        cmbComprobanteTipo.Enabled = IndicaActivo
        txtComprobanteSerie.Enabled = IndicaActivo
        txtComprobanteNumero.Enabled = IndicaActivo
        txtComprobanteFecha.Enabled = IndicaActivo
        cmbComprobanteTipoMoneda.Enabled = IndicaActivo

        txtOperacionFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComentario.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtDocumentoNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteSerie.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteNumero.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        txtComprobanteFecha.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)

        txtOperacionFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComentario.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtDocumentoNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        txtProducto.Enabled = IndicaActivo
        txtCantidad.Enabled = IndicaActivo
        txtPrecioUnitario.Enabled = IIf(MyTipoOperacion = "I", IndicaActivo, False)
        btnAceptar.Enabled = IndicaActivo : btnDescartar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3) : btnDescartar.ImageIndex = IIf(IndicaActivo = True, 0, 2)
        cmbProductos.SelectedIndex = -1
        gvOperacionAlmacenLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then txtProducto.Focus()
    End Sub

    Private Sub PoblarFormulario()
        Dim OperacionAlmacen As String = MyOperacionAlmacen.operacion
        Dim AlmacenOperacion As String = MyOperacionAlmacen.almacen
        Call LimpiarFormulario()
        MyOperacionAlmacen = dalOperacionAlmacen.Obtener(AlmacenOperacion, OperacionAlmacen)
        If Not MyOperacionAlmacen.operacion Is Nothing Then
            With MyOperacionAlmacen
                ckbOperacionAnulada.Checked = IIf(.estado = "N", True, False)
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtOperacion.Text = .operacion
                txtOperacionFecha.Text = EvalDato(.fecha_operacion, "F")
                cmbAlmacen.SelectedValue = .almacen
                cmbTipoOperacion.SelectedValue = .tipo_operacion
                txtComentario.Text = .comentario.Trim
                txtCuentaComercial.Text = .referencia_cuenta_comercial
                cmbComprobanteTipo.SelectedValue = .referencia_tipo
                txtComprobanteSerie.Text = .referencia_serie
                txtComprobanteNumero.Text = .referencia_numero
                If .referencia_fecha.Year <> 1900 Then txtComprobanteFecha.Text = EvalDato(.referencia_fecha, "F")
                cmbComprobanteTipoMoneda.SelectedValue = .referencia_tipo_moneda
                txtComprobanteImporte.Text = EvalDato(.referencia_importe_total, txtComprobanteImporte.Tag)

                If .referencia_cuenta_comercial.Trim.Length <> 0 Then
                    MyCuentaComercial = dalCuentaComercial.Obtener(.referencia_cuenta_comercial)
                    Call ObtenerCuentaComercial()
                End If

                MyAccion = IIf(.estado = "N", "ACTIVAR", "MODIFICAR")

                Call ActualizarGrilla()
            End With
        End If
    End Sub

    Private Sub ObtenerCuentaComercial()
        If Not MyCuentaComercial.cuenta_comercial Is Nothing Then
            With MyCuentaComercial
                txtCuentaComercial.Text = .cuenta_comercial
                cmbDocumentoTipo.Text = .tipo_documento
                txtDocumentoNumero.Text = .nro_documento
                txtRazonSocial.Text = .razon_social
            End With
            txtComprobanteSerie.Focus()
        Else
            txtCuentaComercial.Text = Nothing
            txtDocumentoNumero.Text = Nothing
            txtRazonSocial.Text = Nothing
            txtDocumentoNumero.Focus()
        End If

    End Sub

    Private Sub ActualizarValores()
        Dim CantidadAnterior As Decimal = 0
        Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        Dim StockAnterior As Decimal = CDec(txtStockAnterior.Text)
        Dim StockActual As Decimal = 0
        Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)
        Dim PrecioTotal As Decimal = Math.Round(Cantidad * PrecioUnitario, 2)

        If txtLinea.Text <> Nothing Then
            Dim MyDetalle As dsOperacionesAlmacen.DETALLES_OPERACIONRow
            Dim PrimaryKey(0) As Object
            PrimaryKey(0) = txtLinea.Text
            MyDetalle = MyDetallesOperacion.Rows.Find(PrimaryKey)
            CantidadAnterior = MyDetalle.CANTIDAD
        End If

        StockActual = Math.Round(StockAnterior - CantidadAnterior + IIf(MyTipoOperacion = "I", Cantidad, -Cantidad), 3)

        txtPrecioTotal.Text = EvalDato(PrecioTotal, txtPrecioTotal.Tag)
        txtStockNuevo.Text = EvalDato(StockActual, txtStockNuevo.Tag)
    End Sub

    Private Sub ActualizarGrilla()
        Dim MyTotal As Decimal = 0

        Call LimpiarLinea()

        Call MostrarLote(False)

        MyDetallesOperacion = dalOperacionAlmacen.ObtenerDetalles(cmbAlmacen.SelectedValue, txtOperacion.Text)
        gvOperacionAlmacenLineas.DataSource = MyDetallesOperacion

        If MyDetallesOperacion.Rows.Count <> 0 Then
            For NumReg As Integer = 0 To MyDetallesOperacion.Rows.Count - 1
                MyTotal = MyTotal + (MyDetallesOperacion(NumReg).CANTIDAD * MyDetallesOperacion(NumReg).PRECIO_UNITARIO)
            Next
            Call dalOperacionAlmacen.ActualizarImporteTotal(cmbAlmacen.SelectedValue, txtOperacion.Text, MyTotal)
        End If

        txtComprobanteImporte.Text = EvalDato(MyTotal, txtComprobanteImporte.Tag)
        gvOperacionAlmacenLineas.ClearSelection()

        If MyOperacionAlmacen.ejercicio = MyUsuario.ejercicio And MyOperacionAlmacen.mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
            UC_ToolBar.btnGrabar_Visible = True
            If ckbOperacionAnulada.Checked = True Then
                Call ActivarCabecera(False)
                Call ActivarDetalles(False)
            Else
                Call ActivarDetalles(True)
                If MyDetallesOperacion.Rows.Count <> 0 Then
                    Call ActivarCabecera(False)
                Else
                    Call ActivarCabecera(True)
                End If
            End If
        Else
            UC_ToolBar.btnGrabar_Visible = False
            Call ActivarCabecera(False)
            Call ActivarDetalles(False)
        End If

        txtProducto.Focus()
    End Sub

    Private Sub BuscarDatosAnteriores()
        Dim MyDetalle As dsOperacionesAlmacen.DETALLES_OPERACIONRow

        Dim PrimaryKey(0) As Object

        PrimaryKey(0) = txtLinea.Text

        MyDetalle = MyDetallesOperacion.Rows.Find(PrimaryKey)

        If Not (MyDetalle Is Nothing) Then
            MyOperacionAlmacenDetalle.producto_anterior = MyDetalle.PRODUCTO
            MyOperacionAlmacenDetalle.numero_lote_anterior = MyDetalle.NUMERO_LOTE
            MyOperacionAlmacenDetalle.cantidad_anterior = MyDetalle.CANTIDAD
        End If

    End Sub

    Private Sub LLenarDetalle()
        With MyOperacionAlmacenDetalle
            .empresa = MyUsuario.empresa
            .almacen = cmbAlmacen.SelectedValue
            .operacion = txtOperacion.Text
            .linea = txtLinea.Text
            .producto = txtProducto.Text
            .cantidad = txtCantidad.Text
            .precio_unitario = CSng(txtPrecioUnitario.Text)
            .numero_lote = txtNumeroLote.Text.Trim
            .fecha_vencimiento = IIf(String.IsNullOrEmpty(txtFechaVencimiento.Text), FechaNulo, txtFechaVencimiento.Text)
            .tipo_es = MyTipoOperacion
            .ejercicio = txtEjercicio.Text
            '.mes = txtMes.Text
            .tipo_operacion = cmbTipoOperacion.SelectedValue
            .mes = IIf(.tipo_operacion = "16", "00", txtMes.Text) ' Si es Saldo Inicial el Mes es 00
            If .linea.Trim.Length <> 0 Then Call BuscarDatosAnteriores()
            .exige_lote = txtIndicaLote.Text
        End With
    End Sub

    Private Sub LimpiarLinea()
        txtLinea.Text = Nothing
        txtProducto.Text = Nothing
        cmbProductos.SelectedIndex = -1
        txtNumeroLote.Text = Nothing
        txtFechaVencimiento.Text = Nothing
        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)
        txtPrecioTotal.Text = EvalDato(0, txtPrecioTotal.Tag)
        txtIndicaLote.Text = "NO"
        txtStockNuevo.Text = EvalDato(0, txtStockNuevo.Tag)
        txtStockAnterior.Text = EvalDato(0, txtStockAnterior.Tag)
        Call MostrarLote(False)
        txtProducto.Focus()
    End Sub

    Private Sub MostrarLote(ByVal ActivarLote As Boolean)
        lblNumeroLote.Visible = ActivarLote
        txtNumeroLote.Visible = ActivarLote
        txtNumeroLote.Enabled = ActivarLote
        lblFechaVencimiento.Visible = ActivarLote
        txtFechaVencimiento.Visible = ActivarLote
        txtFechaVencimiento.Enabled = ActivarLote
    End Sub

    Private Sub BuscarStockLote()
        MyLotesStock = dalProducto.BuscarStockAlmacen(cmbAlmacen.SelectedValue, txtNumeroLote.Text.Trim, txtProducto.Text.Trim)
        If MyLotesStock.Rows.Count <> 0 Then
            txtStockAnterior.Text = EvalDato(MyLotesStock(0).STOCK, txtStockAnterior.Tag)
            txtFechaVencimiento.Text = EvalDato(MyLotesStock(0).FECHA_VENCIMIENTO, txtFechaVencimiento.Tag)
            Call ActivarTextBox(txtFechaVencimiento, False)
            txtCantidad.Focus()
        Else
            txtStockAnterior.Text = EvalDato(0, txtStockAnterior.Tag)
            Call ActivarTextBox(txtFechaVencimiento, True)
            txtFechaVencimiento.Focus()
        End If
    End Sub

    Private Sub ActivarTextBox(ByVal sender As System.Object, ByVal IndicaActivo As Boolean)
        sender.Enabled = IndicaActivo
        sender.BackColor = IIf(IndicaActivo, Color.AliceBlue, Color.Moccasin)
        sender.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
    End Sub

#End Region

#Region "Botones"

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        UC_ToolBar.btnGrabar_Visible = True
        Call LimpiarFormulario()
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
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
            .referencia_tipo = cmbComprobanteTipo.SelectedValue
            .referencia_serie = txtComprobanteSerie.Text
            .referencia_numero = txtComprobanteNumero.Text
            If txtComprobanteFecha.Text.Length <> 0 Then .referencia_fecha = txtComprobanteFecha.Text
            .referencia_tipo_moneda = cmbComprobanteTipoMoneda.SelectedValue
            .referencia_importe_total = txtComprobanteImporte.Text
            .estado = IIf(ckbOperacionAnulada.Checked = True, "N", "A")
        End With

        Try
            MyOperacionAlmacen = dalOperacionAlmacen.Grabar(MyOperacionAlmacen)
            txtOperacion.Text = MyOperacionAlmacen.operacion
            Resp = MsgBox("Los cambios del encabezado se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
            Call ActivarCabecera(Not ckbOperacionAnulada.Checked)
            Call ActivarDetalles(True)

            cmbAlmacen.Enabled = False : cmbTipoOperacion.Enabled = False

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyOperacionAlmacen = New entOperacionAlmacen
        MyOperacionAlmacen.almacen = cmbAlmacen.SelectedValue
        MyOperacionAlmacen.tipo_operacion = cmbTipoOperacion.SelectedValue
        Dim MyForm As New frmOperacionAlmacenLista(MyOperacionAlmacen)
        MyForm.ShowDialog()
        If Not MyOperacionAlmacen.operacion Is Nothing Then Call PoblarFormulario()
    End Sub

    Private Sub btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Dim MyForm As New frmStockAlmacenImprimir(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, cmbAlmacen.Text)
        MyForm.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtOperacion.Text.Trim.Length <> 0 Then
            Dim FEmision As Date = CDate(txtOperacionFecha.Text)
            MyAccion = "IMPRIMIR"
            Dim MyDatosImprimir(4) As String
            MyDatosImprimir(0) = Strings.Right(txtOperacion.Text.Trim, 6)
            MyDatosImprimir(1) = FEmision.Day.ToString & " de " & EvalMes(FEmision.Month, "L") & " del " & FEmision.Year
            MyDatosImprimir(2) = cmbAlmacen.Text
            MyDatosImprimir(3) = cmbTipoOperacion.Text
            MyDatosImprimir(4) = txtComentario.Text.Trim
            'MyDatosImprimir(5) = txtDomicilio.Text.Trim
            'MyDatosImprimir(6) = txtTelefono.Text.Trim
            'MyDatosImprimir(7) = txtEmail.Text.Trim
            'MyDatosImprimir(8) = ProperCase(txtContactoComercial.Text.Trim)
            'MyDatosImprimir(9) = FInicio.Day.ToString & " de " & EvalMes(FInicio.Month, "L") & " del " & FInicio.Year
            'MyDatosImprimir(10) = FEntrega.Day.ToString & " de " & EvalMes(FEntrega.Month, "L") & " del " & FEntrega.Year
            'MyDatosImprimir(11) = cmbBanco.Text.Trim & " " & txtCuentaBancaria.Text.Trim
            'MyDatosImprimir(12) = txtCuentaDetraccion.Text.Trim
            'MyDatosImprimir(13) = cmbTipoServicio.Text.Trim
            'MyDatosImprimir(14) = cmbCentroCosto.Text.Trim
            'MyDatosImprimir(15) = ProperCase(txtResponsableNombre.Text.Trim)
            'MyDatosImprimir(16) = txtProyectoAnexo.Text.Trim
            'MyDatosImprimir(17) = txtProyectoNombre.Text.Trim
            'MyDatosImprimir(18) = ProperCase(txtClienteNombre.Text.Trim)
            'MyDatosImprimir(19) = ProperCase(txtDirectorNombre.Text.Trim)
            'MyDatosImprimir(20) = ProperCase(txtEjecutivoNombre.Text.Trim)
            'MyDatosImprimir(21) = cmbCondicionPago.Text.Trim
            'MyDatosImprimir(22) = txtComentario.Text.Trim
            'MyDatosImprimir(23) = IIf(TImpuesto = "AI", "IGV 18%", IIf(TImpuesto = "CR", "RETENC. 8%", "RETENC. 0%"))

            Dim MyForm As New frmOperacionAlmacenImprimir(MyDatosImprimir, txtOperacion.Text, cmbAlmacen.SelectedValue)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim MyCodigo As String = txtProducto.Text
        Dim StockActual As Decimal = CDec(txtStockNuevo.Text)
        MyProducto = dalProducto.Obtener(MyCodigo)

        If txtOperacion.Text <> "" And cmbProductos.SelectedIndex <> -1 And CDec(txtCantidad.Text) <> 0 Then
            If StockActual < 0 Then
                Resp = MsgBox("No existe stock suficiente para concretar operación.", MsgBoxStyle.Information, "OPERACION CANCELADA")
                txtCantidad.Focus()
            ElseIf MyProducto.producto Is Nothing Then
                Resp = MsgBox("El Producto no existe.", MsgBoxStyle.Information, "OPERACION CANCELADA")
                txtProducto.Focus()
            Else
                Call LLenarDetalle()
                Try
                    MyOperacionAlmacenDetalle = dalOperacionAlmacen.Grabar(MyOperacionAlmacenDetalle)
                    Call ActualizarGrilla()
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        If txtLinea.TextLength <> 0 Then
            Call LLenarDetalle()
            Try
                If dalOperacionAlmacen.Descartar(MyOperacionAlmacenDetalle) = True Then
                    Call ActualizarGrilla()
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Call LimpiarLinea()
    End Sub

#End Region

End Class
