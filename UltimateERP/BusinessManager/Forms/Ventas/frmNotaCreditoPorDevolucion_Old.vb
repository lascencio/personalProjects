Public Class frmNotaCreditoPorDevolucion_Old

    Private MyCuentaComercial As entCuentaComercial

    Private MyVenta As entVenta
    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable

    Private MyReferencia As entVenta

    Private MyDetalles As dsVentas.VENTAS_DEVOLUCIONDataTable
    Private MyDetallesDevolucion As dsVentas.VENTAS_DEVOLUCIONDataTable
    Private MyDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable
    Private MyDetalleSeriesDevolucion As dsVentas.VENTA_DET_SERIESDataTable

    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String
    Private MyTipoCambio As Decimal

    Private FechaUltimoComprobante As Date

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmNotaCreditoPorDevolucion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmNotaCreditoPorDevolucion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")
        ActualizarListaGenerica(cmbComprobanteTipo, "_TIPO_COMPROBANTE_PAGO")


        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        Call LimpiarFormulario()

        'If MyTipoCambio = 0 Then
        '    Resp = MsgBox("Para continuar debe registrar el TIPO DE CAMBIO del " & EvalDato(MyAsientoFecha, "F") & ".", MsgBoxStyle.Information, Me.Text)
        '    UC_ToolBar.CambiarEstados(3, 3, False)
        'Else
        '    UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
        'End If

        If MyTipoCambio = 0 Then MyTipoCambio = 1

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        Me.Text = "NOTA DE CREDITO POR DEVOLUCION"

        lblComprobante.Text = Me.Text

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnInformacion_Visible = False

        txtReferenciaSerie.Focus()

    End Sub

    Private Sub ValidarFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated
        Dim MyFecha As Date
        Dim MyFechaAño As String
        Dim MyFechaMes As String
        Dim MyFechaDia As String

        If sender.text.ToString.Length > 0 Then
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtComprobanteFecha" Then
                    MyFecha = CDate(txtComprobanteFecha.Text)
                    If MyFecha > MyFechaServidor Then
                        Resp = MsgBox("La fecha a registrar no debe ser mayor de hoy.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                        ReiniciarFecha()
                    Else
                        If MyAsientoFecha.Year * 100 + MyAsientoFecha.Month <> MyFecha.Year * 100 + MyFecha.Month Then
                            Resp = MsgBox("La fecha debe estar dentro del periodo.", MsgBoxStyle.Information, "FECHA INCORRECTA")
                            Call ReiniciarFecha()
                        Else
                            If MyFecha < FechaUltimoComprobante Then
                                Resp = MsgBox("La fecha debe ser igual o mayor que el día " & FechaUltimoComprobante.Day.ToString, MsgBoxStyle.Information, "FECHA INCORRECTA")
                                Call ReiniciarFecha()
                            Else
                                MyFechaAño = MyFecha.Year.ToString
                                MyFechaMes = Strings.Right("00" & MyFecha.Month.ToString, 2)
                                MyFechaDia = Strings.Right("00" & MyFecha.Day.ToString, 2)

                                MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyFechaAño, MyFechaMes, MyFechaDia, "VENTA")
                                If MyTipoCambio = 0 Then
                                    Resp = MsgBox("No existe TIPO DE CAMBIO del " & EvalDato(MyFecha, "F") & ".", MsgBoxStyle.Information, "FALTA TIPO DE CAMBIO")
                                    Call ReiniciarFecha()
                                Else
                                    txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
                                    UC_ToolBar.btnGrabar_Focus = True
                                End If
                            End If
                        End If
                    End If
                End If

            Else
                If sender.name = "txtComprobanteFecha" Then Call ReiniciarFecha()
            End If

        End If
    End Sub

    Private Sub txtComprobanteNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprobanteSerie.KeyDown, txtComprobanteNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyNumero As String = sender.text
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            If sender.text.ToString.Length > 0 Then
                If IsNumeric(sender.text) Then
                    sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                    If txtVenta.Text = Nothing Then
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
                        If txtVenta.Text = Nothing Then Call PoblarCorrelativo()
                    ElseIf sender.name = "txtComprobanteNumero" Then
                        If txtVenta.Text = Nothing Then Call PoblarCorrelativo()
                    Else
                        sender.text = Nothing
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gvVentaLineas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvVentaLineas.CellClick
        If sender.Enabled = True Then
            If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
                Dim MyIndex As Integer
                Dim CodigoProducto As String
                If Not sender.CurrentRow Is Nothing Then
                    MyIndex = sender.CurrentRow.Index
                    CodigoProducto = MyDetalles(MyIndex).PRODUCTO
                    Dim MyDetalleSeriesNew As New dsVentas.VENTA_DET_SERIESDataTable
                    If MyDetalleSeries.Rows.Count <> 0 Then
                        For NEle As Integer = 0 To MyDetalleSeries.Rows.Count - 1
                            If MyDetalleSeries(NEle).PRODUCTO <> CodigoProducto Then
                                MyDetalleSeriesNew.ImportRow(MyDetalleSeries(NEle))
                            End If
                        Next
                    End If
                    MyDetalleSeries = MyDetalleSeriesNew
                    MyDetalles.Rows(MyIndex).Delete()
                End If
                Call ActualizarTotales()
                sender.DataSource = MyDetalles
                sender.ClearSelection()
            End If
        End If
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged
        If cmbProductos.SelectedIndex <> -1 Then
            Dim MyIndex As Integer
            Dim MyDetalle As dsVentas.VENTAS_DEVOLUCIONRow
            MyIndex = sender.SelectedIndex

            Dim PrimaryKey(0) As Object

            PrimaryKey(0) = cmbProductos.SelectedValue

            MyDetalle = MyDetallesDevolucion.Rows.Find(PrimaryKey)

            If Not (MyDetalle Is Nothing) Then
                With MyDetalle
                    'txtProducto.Text = MyDetalle.PRODUCTO
                    'txtIndicaSerie.Text = MyDetalle.INDICA_SERIE
                    txtCantidadVendida.Text = EvalDato(MyDetalle.CANTIDAD, txtCantidadVendida.Tag)
                    txtPrecioUnitario.Text = EvalDato(MyDetalle.PRECIO_UNITARIO, txtPrecioUnitario.Tag)
                    If MyDetalle.NUMERO_SERIE.Trim.Length <> 0 Then
                        txtCantidad.Text = EvalDato(1, txtCantidad.Tag)
                        txtCantidad.Enabled = False
                        btnAceptar.Focus()
                    Else
                        txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
                        txtCantidad.Enabled = True
                        txtCantidad.Focus()
                    End If
                End With
            End If
        Else
            txtCantidadVendida.Text = EvalDato(0, txtCantidad.Tag)
            txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)
            txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
            'txtProducto.Text = Nothing
            'txtIndicaSerie.Text = Nothing
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As EventArgs) Handles txtCantidad.Validated
        Dim Cantidad As Decimal
        Dim CantidadVendida As Decimal

        sender.Text = EvalDato(sender.Text, sender.Tag)
        If CDec(sender.Text) = 0 Then
            cmbProductos.Focus()
        Else
            Call EvaluarCantidad()
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call EvaluarCantidad()
        End If
    End Sub

    Private Sub cmbReferenciaTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReferenciaTipo.SelectedIndexChanged
        If cmbReferenciaTipo.SelectedIndex <> -1 Then
            txtReferenciaSerie.Focus()
            Call BuscarReferencia()
        End If
    End Sub

    Private Sub txtReferenciaNumero_Validated(sender As Object, e As EventArgs) Handles txtReferenciaSerie.Validated, txtReferenciaNumero.Validated
        If sender.text.ToString.Length <> 0 Then
            If IsNumeric(sender.text) Then
                If sender.Name = "txtReferenciaSerie" Then
                    If txtReferenciaSerie.Text.Length <> 4 Then
                        sender.text = IIf(cmbReferenciaTipo.Text.Substring(0, 1) = "B", "BV", "FT") & Strings.Right(CUO_Nulo & sender.text, 2)
                    End If
                Else
                    sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                End If
                Call BuscarReferencia()
            End If
        End If
    End Sub

    Private Sub ckbIndicaAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles ckbIndicaAnulado.CheckedChanged
        If txtVenta.Text.Trim.Length <> 0 Then
            If MyVenta.estado = "V" Then
                If ckbIndicaAnulado.Checked = True Then
                    UC_ToolBar.btnAceptar_Visible = True
                Else
                    UC_ToolBar.btnAceptar_Visible = False
                End If
            End If
        End If
    End Sub


#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyVenta = New entVenta
        MyCorrelativo = New dsCorrelativo.CORRELATIVODataTable

        MyReferencia = New entVenta

        MyDetalles = New dsVentas.VENTAS_DEVOLUCIONDataTable
        MyDetallesDevolucion = New dsVentas.VENTAS_DEVOLUCIONDataTable

        MyDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
        MyDetalleSeriesDevolucion = New dsVentas.VENTA_DET_SERIESDataTable

        InicializarFormulario(Me)

        cmbProductos.DataSource = MyDetallesDevolucion
        gvVentaLineas.DataSource = MyDetalles

        Call PonerValoresDefault()
        Call ActivarCabecera(False)
        Call ActivarDetalles(True)
        EnableTextBox(txtCantidad, True)

        txtReferenciaSerie.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")

        cmbReferenciaTipo.SelectedIndex = 0

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = Strings.Right("00" & CStr(MyUsuario.mes), 2)
        cmbAlmacen.SelectedValue = MyUsuario.almacen
        cmbTipoMoneda.SelectedValue = "1"
        'txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        cmbComprobanteTipo.SelectedValue = "07"
        cmbProductos.SelectedIndex = -1

        ckbIndicaAnulado.Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub BuscarReferencia()
        If cmbReferenciaTipo.SelectedIndex <> -1 And txtReferenciaSerie.Text.Trim.Length <> 0 And txtReferenciaNumero.Text.Trim.Length <> 0 Then
            MyDetallesDevolucion = New dsVentas.VENTAS_DEVOLUCIONDataTable

            Dim MyReferenciaTipo As String = IIf(cmbReferenciaTipo.SelectedIndex = 0, "01", "03")
            Dim MyReferenciaSerie As String = txtReferenciaSerie.Text.Trim
            Dim MyReferenciaNumero As String = txtReferenciaNumero.Text.Trim

            MyReferencia = dalVenta.Obtener(MyReferenciaTipo, MyReferenciaSerie, MyReferenciaNumero)
            If Not MyReferencia.venta Is Nothing Then
                txtReferencia.Text = MyReferencia.venta
                txtReferenciaFecha.Text = MyReferencia.comprobante_fecha
                cmbAlmacen.SelectedValue = MyReferencia.almacen
                txtGuia.Text = MyReferencia.guia_remitente
                MyCuentaComercial = dalCuentaComercial.Obtener(MyReferencia.empresa, MyReferencia.cuenta_comercial)
                txtCuentaComercial.Text = MyCuentaComercial.cuenta_comercial
                txtRazonSocial.Text = MyCuentaComercial.razon_social

                cmbTipoMoneda.SelectedValue = MyReferencia.tipo_moneda

                txtComprobanteSerie.Text = IIf(cmbReferenciaTipo.Text.Substring(0, 1) = "B", "BN", "FN") & MyReferencia.comprobante_serie.Substring(2, 2)

                Call PoblarCorrelativo()

                Call ActualizarDetallesComprobante()

                Call ActivarCabecera(True)
            Else
                txtReferencia.Text = Nothing
                txtReferenciaFecha.Text = Nothing

                MyCuentaComercial = New entCuentaComercial
                txtCuentaComercial.Text = Nothing
                txtRazonSocial.Text = Nothing
                txtComprobanteSerie.Text = Nothing
                txtComprobanteNumero.Text = Nothing
                txtComprobanteFecha.Text = Nothing

                cmbProductos.DataSource = MyDetallesDevolucion

                Call ActivarCabecera(False)
            End If

        End If
    End Sub

    Private Sub PoblarCorrelativo()
        Dim MyFechaAño As String
        Dim MyFechaMes As String
        Dim MyFechaDia As String

        If txtVenta.Text.Trim.Length = 0 Then
            MyCorrelativo = dalVenta.ObtenerCorrelativo(cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text, "NO")
            If MyCorrelativo.Rows.Count = 0 Then
                txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
                FechaUltimoComprobante = CDate("01/" & MyAsientoMes & "/" & MyAsientoEjercicio)
            Else
                txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
                FechaUltimoComprobante = MyCorrelativo(0).COMPROBANTE_FECHA
            End If
            'txtComprobanteFecha.Text = EvalDato(FechaUltimoComprobante, txtComprobanteFecha.Tag)

            txtComprobanteFecha.Text = EvalDato(Now.Date, txtComprobanteFecha.Tag)

            Dim MyFechaTC As Date = CDate(txtComprobanteFecha.Text)
            MyFechaAño = MyFechaTC.Year.ToString
            MyFechaMes = Strings.Right("00" & MyFechaTC.Month.ToString, 2)
            MyFechaDia = Strings.Right("00" & MyFechaTC.Day.ToString, 2)

            MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyFechaAño, MyFechaMes, MyFechaDia, "VENTA")

            txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        End If
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub PoblarFormulario()
        Dim Venta As String = MyVenta.venta
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            With MyVenta
                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)
                txtOrdenPedido.Text = .orden_pedido
                txtReferencia.Text = .referencia_cuo
                txtVenta.Text = .venta
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes
                txtCuentaComercial.Text = .cuenta_comercial
                txtTipoCambio.Text = EvalDato(.tipo_cambio, txtTipoCambio.Tag)

                cmbAlmacen.SelectedValue = .almacen

                cmbReferenciaTipo.SelectedIndex = IIf(.referencia_tipo = "01", 0, 1)
                txtReferenciaSerie.Text = .referencia_serie
                txtReferenciaNumero.Text = .referencia_numero
                txtReferenciaFecha.Text = EvalDato(.referencia_fecha, "F")

                txtRazonSocial.Text = MyCuentaComercial.razon_social

                txtComprobanteSerie.Text = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")

                cmbTipoMoneda.SelectedValue = .tipo_moneda

                txtBaseImponible.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponible.Tag)
                txtImpuesto.Text = EvalDato(.igv_origen, txtImpuesto.Tag)
                txtImporteTotal.Text = EvalDato(.importe_total_origen, txtImporteTotal.Tag)

                If .ejercicio = MyUsuario.ejercicio And .mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
                    If .estado = "V" Then
                        Call ActivarCabecera(IIf(.indica_impreso = "NO", True, False))
                        Call ActivarDetalles(IIf(.indica_impreso = "NO", True, False))
                    Else
                        Call ActivarCabecera(False)
                        Call ActivarDetalles(False)
                    End If
                Else
                    Call ActivarCabecera(False)
                    Call ActivarDetalles(False)
                End If

                ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)

                If .importe_total_origen = .importe_saldo Then
                    ckbIndicaAnulado.Visible = True
                Else
                    ckbIndicaAnulado.Visible = False
                End If

                Call ActualizarGrilla()
            End With
        End If
    End Sub

    Private Sub ActualizarGrilla()

        'MyDetalles = dalVenta.ObtenerDetallesParaDevolucion(txtVenta.Text)
        gvVentaLineas.DataSource = MyDetalles
        gvVentaLineas.ClearSelection()

        Call LimpiarLinea()

        Call ActualizarDetallesComprobante()

        Call CalcularTotales()

    End Sub

    Private Sub ActualizarDetallesComprobante()
        Dim TipoVenta As String
        Dim Referencia As String

        'MyDetallesDevolucion = dalVenta.ObtenerDetallesParaDevolucion(MyReferencia.venta)

        If MyDetallesDevolucion.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetallesDevolucion.Rows.Count - 1

                If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyDetallesDevolucion(NEle).PRODUCTO) Then
                    MyDetallesDevolucion(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                End If

                If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyDetallesDevolucion(NEle).PRODUCTO) Then
                    MyDetallesDevolucion(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                End If

            Next
        End If

        Select Case MyReferencia.tipo_operacion
            Case Is = "B3" : TipoVenta = "V" : Referencia = MyReferencia.venta
            Case Is = "F3" : TipoVenta = "V" : Referencia = MyReferencia.venta
            Case Else : TipoVenta = "G" : Referencia = MyReferencia.guia_remitente
        End Select

        'MyDetalleSeriesDevolucion = dalVenta.ObtenerSeriesParaDevolucion(TipoVenta, Referencia)

        If MyDetalleSeriesDevolucion.Rows.Count = 0 Then
            'MyDetalleSeriesDevolucion = dalVenta.ObtenerSeriesParaDevolucionAlterno(TipoVenta, Referencia)
        End If

        cmbProductos.DataSource = MyDetallesDevolucion
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbReferenciaTipo, Not IndicaActivo)
        EnableTextBox(txtReferenciaSerie, Not IndicaActivo)
        EnableTextBox(txtReferenciaNumero, Not IndicaActivo)

        'EnableTextBox(txtComprobanteSerie, IndicaActivo)
        'EnableTextBox(txtComprobanteNumero, IndicaActivo)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)

        If IndicaActivo = True Then
            cmbProductos.Focus()
        Else
            cmbReferenciaTipo.Focus()
        End If
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        btnAceptar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3)
        cmbProductos.SelectedIndex = -1
        cmbProductos.Enabled = IndicaActivo
        gvVentaLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then cmbProductos.Focus()
    End Sub

    Private Sub ReiniciarFecha()
        txtTipoCambio.Text = "0.000"
        txtComprobanteFecha.Text = Nothing
        txtComprobanteFecha.Focus()
    End Sub

    Private Sub CalcularTotales()
        Dim MyBaseImponibleGravadaOrigen As Decimal = 0
        Dim MyIGVOrigen As Decimal = 0
        Dim MyImporteSubTotalOrigen As Decimal = 0
        Dim MyImporteTotalOrigen As Decimal = 0

        cmbProductos.SelectedIndex = -1
        txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)

        If MyDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
                MyImporteSubTotalOrigen = MyDetalles(NEle).IMPORTE_TOTAL
                MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
            Next
        End If

        'For Each row As DataGridViewRow In gvVentaLineas.Rows
        '    MyImporteSubTotalOrigen = row.Cells(9).Value
        '    MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
        'Next

        MyBaseImponibleGravadaOrigen = Math.Round(MyImporteTotalOrigen / (1 + (MyIGV / 100)), 2)
        MyIGVOrigen = MyImporteTotalOrigen - MyBaseImponibleGravadaOrigen
        txtBaseImponible.Text = EvalDato(MyBaseImponibleGravadaOrigen, txtBaseImponible.Tag)
        txtImpuesto.Text = EvalDato(MyIGVOrigen, txtImpuesto.Tag)
        txtImporteTotal.Text = EvalDato(MyImporteTotalOrigen, txtImporteTotal.Tag)

        gvVentaLineas.ClearSelection()
    End Sub

    Private Sub EvaluarCantidad()
        Dim Cantidad As Decimal
        Dim CantidadVendida As Decimal

        If cmbProductos.SelectedIndex <> -1 Then
            Cantidad = CDec(txtCantidad.Text)
            If Cantidad > 0 Then
                CantidadVendida = CDec(txtCantidadVendida.Text)
                If Cantidad <= CantidadVendida Then
                    'If txtIndicaSerie.Text = "SI" Then
                    '    Call CapturarSeries(Cantidad)
                    'Else
                    '    Call GuardarDetalle()
                    'End If
                Else
                    Resp = MsgBox("La cantidad a devolver es mayor que la cantidad vendida.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PROCESO CANCELADO")
                    txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
                    txtCantidad.Focus()
                End If
            End If
        Else
            cmbProductos.Focus()
        End If
    End Sub

    Private Sub CapturarEncabezado()
        If Not MyReferencia.venta Is Nothing Then
            MyTipoCambio = IIf(MyTipoCambio = 0, 1, MyTipoCambio)
            With MyVenta
                .empresa = MyReferencia.empresa
                .venta = txtVenta.Text
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .almacen = MyReferencia.almacen
                '.tipo_operacion = m_Tipo_Venta
                '.asiento_tipo = MyAsientoTipo
                .cuenta_comercial = txtCuentaComercial.Text
                .comprobante_tipo = cmbComprobanteTipo.SelectedValue
                .comprobante_serie = txtComprobanteSerie.Text
                .comprobante_numero = txtComprobanteNumero.Text
                If txtComprobanteFecha.Text.Length <> 0 Then
                    .comprobante_fecha = txtComprobanteFecha.Text
                    .comprobante_vencimiento = txtComprobanteFecha.Text
                    .asiento_fecha = txtComprobanteFecha.Text
                End If
                .tipo_cambio = CDec(txtTipoCambio.Text)
                .tipo_moneda = cmbTipoMoneda.SelectedValue
                .base_imponible_gravada_origen = CDec(txtBaseImponible.Text)
                .igv_origen = CDec(txtImpuesto.Text)
                .importe_total_origen = CDec(txtImporteTotal.Text)
                .importe_saldo = .importe_total_origen
                If .tipo_moneda = "1" Then ' MN
                    .base_imponible_gravada_mn = .base_imponible_gravada_origen
                    .importe_total_mn = .importe_total_origen
                    .igv_mn = .igv_origen
                    .base_imponible_gravada_me = Math.Round(.base_imponible_gravada_origen / MyTipoCambio, 2)
                    .importe_total_me = Math.Round(.importe_total_origen / MyTipoCambio, 2)
                    .igv_me = .importe_total_me - .base_imponible_gravada_me
                Else
                    .base_imponible_gravada_me = .base_imponible_gravada_origen
                    .importe_total_me = .importe_total_origen
                    .igv_me = .igv_origen
                    .base_imponible_gravada_mn = Math.Round(.base_imponible_gravada_origen * MyTipoCambio, 2)
                    .importe_total_mn = Math.Round(.importe_total_origen * MyTipoCambio, 2)
                    .igv_mn = .importe_total_mn - .base_imponible_gravada_mn
                End If

                .referencia_cuo = MyReferencia.venta
                .referencia_tipo = MyReferencia.comprobante_tipo
                .referencia_serie = MyReferencia.comprobante_serie
                .referencia_numero = MyReferencia.comprobante_numero
                .referencia_fecha = MyReferencia.comprobante_fecha

                .codigo_vendedor = MyReferencia.codigo_vendedor
                .orden_pedido = MyReferencia.orden_pedido
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "V")
                .usuario_registro = MyUsuario.usuario
                .usuario_modifica = MyUsuario.usuario
            End With
        End If
    End Sub

    Private Sub CapturarDetalle()
        'MyVentaDetalle = New entVentaProducto
        'With MyVentaDetalle
        '    .empresa = MyUsuario.empresa
        '    .venta = txtVenta.Text
        '    .almacen = cmbAlmacen.SelectedValue

        '    .producto = txtProducto.Text

        '    .tipo_cambio = CDec(txtTipoCambio.Text)
        '    .tipo_moneda = cmbTipoMoneda.SelectedValue
        '    .cantidad = CDec(txtCantidad.Text)
        '    .precio_unitario = CDec(txtPrecioUnitario.Text)
        '    .base_imponible_gravada_origen = Math.Round(CDec(.importe_total_origen / (1 + (MyIGV / 100))), 2)
        '    .igv_origen = .importe_total_origen - .base_imponible_gravada_origen
        '    If .tipo_moneda = "1" Then ' MN
        '        .base_imponible_gravada_mn = .base_imponible_gravada_origen
        '        .importe_total_mn = .importe_total_origen
        '        .igv_mn = .igv_origen
        '        .base_imponible_gravada_me = Math.Round(.base_imponible_gravada_origen / MyTipoCambio, 2)
        '        .importe_total_me = Math.Round(.importe_total_origen / MyTipoCambio, 2)
        '        .igv_me = .importe_total_me - .base_imponible_gravada_me
        '    Else
        '        .base_imponible_gravada_me = .base_imponible_gravada_origen
        '        .importe_total_me = .importe_total_origen
        '        .igv_me = .igv_origen
        '        .base_imponible_gravada_mn = Math.Round(.base_imponible_gravada_origen * MyTipoCambio, 2)
        '        .importe_total_mn = Math.Round(.importe_total_origen * MyTipoCambio, 2)
        '        .igv_mn = .importe_total_mn - .base_imponible_gravada_mn
        '    End If
        '    .ejercicio = txtEjercicio.Text
        '    .mes = txtMes.Text
        '    .fecha_venta = CDate(txtComprobanteFecha.Text)

        '    .orden_pedido = txtOrdenPedido.Text
        '    .usuario_registro = MyUsuario.usuario
        '    .usuario_modifica = MyUsuario.usuario
        'End With
    End Sub

    Private Sub CapturarSeries(Cantidad As Decimal)
        'Dim CantidadAtendida As Decimal
        'Dim IndicaRegistroValido As Boolean = True
        'Dim CodigoProducto As String = txtProducto.Text

        'Dim MyDetalleSeriesNew As New dsVentas.VENTA_DET_SERIESDataTable

        ''Dim MyForm As New frmNotaCreditoDetalleSeries(cmbComprobanteTipo.SelectedValue, txtComprobanteSerie.Text, txtComprobanteNumero.Text, cmbAlmacen.SelectedValue, CodigoProducto, Cantidad, MyDetalleSeries, MyDetalleSeriesDevolucion)

        'Dim MyForm As New frmNotaCreditoDetalleSeries(cmbAlmacen.SelectedValue, CodigoProducto, Cantidad, MyDetalleSeries, MyDetalleSeriesDevolucion)

        'MyForm.ShowDialog()

        'If MyDetalleSeries.Rows.Count <> 0 Then
        '    For NEle As Integer = 0 To MyDetalleSeries.Rows.Count - 1
        '        If MyDetalleSeries(NEle).ESTADO <> "N" Then
        '            MyDetalleSeriesNew.ImportRow(MyDetalleSeries(NEle))

        '            If MyDetalleSeries(NEle).PRODUCTO = CodigoProducto Then
        '                CantidadAtendida = CantidadAtendida + 1
        '            End If
        '        End If
        '    Next
        '    If CantidadAtendida <> Cantidad Then IndicaRegistroValido = False
        'Else
        '    IndicaRegistroValido = False
        'End If

        'If IndicaRegistroValido = True Then
        '    Call GuardarDetalle()
        'Else
        '    MyDetalleSeries = MyDetalleSeriesNew
        '    If MyDetalles.Rows.Count <> 0 Then
        '        For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
        '            If MyDetalles(NEle).PRODUCTO = CodigoProducto Then
        '                MyDetalles.Rows(NEle).Delete()
        '                Exit For
        '            End If
        '        Next
        '        gvVentaLineas.DataSource = MyDetalles
        '    End If

        '    Call LimpiarLinea()
        'End If
    End Sub

    Private Sub GuardarDetalle()
        'Dim NumeroLinea As Integer = 0
        'Dim Cantidad As Decimal = CDec(txtCantidad.Text)
        'Dim PrecioUnitario As Decimal = CDec(txtPrecioUnitario.Text)
        'Dim ImporteTotal As Decimal = Math.Round(Cantidad * PrecioUnitario, 2)

        'Dim ExisteResumenAlmacen As String = "NO"
        'Dim ExisteResumenPeriodo As String = "NO"

        'Dim GrabarNuevaLinea As Boolean = True

        'If txtProducto.Text.Trim.Length <> 0 Then
        '    If MyDetalles.Rows.Count <> 0 Then
        '        For NEle As Integer = 0 To MyDetalles.Rows.Count - 1
        '            If MyDetalles(NEle).PRODUCTO = txtProducto.Text Then
        '                MyDetalles(NEle).CANTIDAD = Cantidad
        '                MyDetalles(NEle).PRECIO_UNITARIO = PrecioUnitario
        '                MyDetalles(NEle).IMPORTE_TOTAL = ImporteTotal
        '                GrabarNuevaLinea = False
        '            End If
        '            NumeroLinea = CInt(MyDetalles(NEle).LINEA) + 1
        '        Next
        '    End If

        '    If GrabarNuevaLinea = True Then
        '        MyProducto = dalProducto.Obtener(txtProducto.Text)

        '        If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(cmbAlmacen.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenAlmacen = "SI"
        '        If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(txtEjercicio.Text, txtMes.Text, cmbAlmacen.SelectedValue, "0000000000", MyProducto.producto) Then ExisteResumenPeriodo = "SI"

        '        MyDetalles.Rows.Add(NumeroLinea.ToString("000"), MyProducto.codigo_compra, MyProducto.producto, MyProducto.descripcion_ampliada.Trim, "", Cantidad, PrecioUnitario, ImporteTotal, MyProducto.indica_serie, MyProducto.indica_lote, ExisteResumenAlmacen, ExisteResumenPeriodo)
        '    End If

        '    Call ActualizarTotales()

        '    gvVentaLineas.DataSource = MyDetalles
        '    gvVentaLineas.ClearSelection()
        '    Call LimpiarLinea()
        'End If

    End Sub

    Private Sub ActualizarTotales()
        Dim ValorVenta As Decimal = 0
        Dim Impuesto As Decimal = 0
        Dim ImporteTotal As Decimal = 0

        If MyDetalles.Rows.Count <> 0 Then
            For NEle As Byte = 0 To MyDetalles.Rows.Count - 1
                ImporteTotal = ImporteTotal + MyDetalles(NEle).IMPORTE_TOTAL
            Next
        End If

        ValorVenta = Math.Round(ImporteTotal / (1 + (MyIGV / 100)), 2)
        Impuesto = ImporteTotal - ValorVenta

        txtImporteTotal.Text = EvalDato(ImporteTotal, txtImporteTotal.Tag)
        txtImpuesto.Text = EvalDato(Impuesto, txtImpuesto.Tag)
        txtBaseImponible.Text = EvalDato(ValorVenta, txtBaseImponible.Tag)
    End Sub

    Private Sub LimpiarLinea()
        'cmbProductos.SelectedIndex = -1
        'txtCantidadVendida.Text = EvalDato(0, txtCantidadVendida.Tag)
        'txtPrecioUnitario.Text = EvalDato(0, txtPrecioUnitario.Tag)

        'txtCantidad.Text = EvalDato(0, txtCantidad.Tag)
        'txtProducto.Text = Nothing
        'txtIndicaSerie.Text = Nothing
        'cmbProductos.Focus()
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
        'If txtCuentaComercial.Text.Trim.Length = 0 Then
        '    Resp = MsgBox("Debe registrar un cliente.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        'ElseIf MyDetalles.Rows.Count = 0 Then
        '    Resp = MsgBox("Debe registrar productos a devolver.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        'Else
        '    Call CapturarEncabezado()
        '    Try
        '        UC_ToolBar.btnAceptar_Visible = False

        '        If txtVenta.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
        '            Resp = MsgBox("Confirmar proceso de anulación de la Nota de Crédito.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR COMPROBANTE")
        '            If Resp = 1 Then
        '                If dalVenta.AnularNotaCredito(MyReferencia.venta, MyVenta, MyDetalles, MyDetalleSeries) = True Then
        '                    Resp = MsgBox("La Nota de Crédito se anuló con éxito.", MsgBoxStyle.Information, "ANULAR COMPROBANTE")
        '                    Call LimpiarFormulario()
        '                Else
        '                    ckbIndicaAnulado.Checked = False
        '                    UC_ToolBar.btnEditar_Focus = True
        '                End If
        '            End If
        '        Else
        '            MyVenta = dalVenta.GrabarNotaCredito(MyReferencia.venta, MyVenta, MyDetalles, MyDetalleSeries)
        '            txtVenta.Text = MyVenta.venta

        '            Resp = MsgBox("La Nota de Crédito se grabó con éxito.", MsgBoxStyle.Information, "GRABAR COMPROBANTE")
        '            ActivarDetalles(False)
        '            EnableTextBox(txtCantidad, False)
        '            UC_ToolBar.btnAceptar_Visible = False
        '            UC_ToolBar.btnImprimir_Focus = True
        '        End If

        '        UC_ToolBar.btnAceptar_Visible = False
        '    Catch ex As BusinessException
        '        Resp = MsgBox(ex.Message)
        '    Catch ex As Exception
        '        Resp = MsgBox("ERROR: " & ex.Message.ToString)
        '    End Try
        'End If

    End Sub

    Private Sub UC_ToolBar_btnBorrar_Click() Handles UC_ToolBar.TB_btnBorrar_Click
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        'Dim MyCantidadControl As Integer = 0
        'MyVenta = New entVenta
        'MyAccion = "MODIFICAR"
        'Dim MyForm As New frmFacturacionProductosLista(MyVenta, txtEjercicio.Text, txtMes.Text, "V", m_Tipo_Venta)
        'MyForm.ShowDialog()
        'If Not MyVenta.venta Is Nothing Then
        '    Call PoblarFormulario()
        '    Call ActivarDetalles(False)
        '    ckbIndicaAnulado.Visible = True
        '    UC_ToolBar.btnAceptar_Visible = False
        '    UC_ToolBar.btnImprimir_Focus = True
        'End If
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        'If txtVenta.Text.Trim.Length <> 0 Then
        '    'Dim MyForm As New frmComprobanteVentaImprimir(txtVenta.Text.Trim, txtVenta.Text.Trim, cmbComprobanteTipo.SelectedValue)
        '    Dim MyForm As New frmEComprobanteVentaImprimir(MyVenta, txtReferencia.Text.Trim, MyCuentaComercial)
        '    MyForm.ShowDialog()
        'End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'If cmbProductos.SelectedIndex <> -1 Then
        '    Call LimpiarLinea()
        'End If
    End Sub

#End Region



End Class
