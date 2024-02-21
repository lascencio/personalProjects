Public Class frmENotaCreditoServicios
    Private MyVentaReferencia As entVenta
    Private MyVenta As entVenta
    Private MyVentaDetalle As entVentaServicio
    Private MyVentaDetalles As dsVentasDetalleLista.VENTAS_DET_LISTADataTable

    Private MyFactura As entFactura
    Private MyFacturaDetalles As dsVentas.VENTAS_SERDataTable

    Private MyCliente As entCONCAR_Cliente
    Private MyAnexo As entCONCAR_Anexo
    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private MyClienteDocumentoTipo As String
    Private MyClienteDocumentoNumero As String
    Private MyClienteNombre As String
    Private MyClienteDomicilio As String

    Private MyAsientoContable As entAsientoContable
    Private MyAsientoContableDetalle As entAsientoContableDetalle
    Private MyAsientoContableDetallesVirtual As dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable
    Private MyTipoCambio As Decimal

    Private MyCorrelativo As dsCorrelativo.CORRELATIVODataTable

    Private MyEComprobante As entEComprobante
    Private MyEComprobantes As dsVentas.ECOMPROBANTESDataTable
    Private MyEComprobanteFirma As entEComprobanteFirma

    Private MyAccion As String = "NUEVO"
    Private MyAsientoTipo As String = "05"
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String
    Private MySender As String

    Private ExistePDF As Boolean

    Private Sub frmNotaCreditoServicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmNotaCreditoServicios_Load(sender As Object, e As EventArgs) Handles Me.Load
        'ActualizarTablaCodigo("SEE_TIPO_DOCUMENTO", cmbComprobanteTipo, "01")
        ActualizarTabla("SEE_TIPO_DOCUMENTO", cmbComprobanteTipo, "07")

        ActualizarTabla("_TIPO_MONEDA", cmbTipoMoneda, "1")
        ActualizarTabla("COM_CONDICION_PAGO", cmbCondicionPago, "00")
        ActualizarTablaCodigo("SEE_TIPO_NOTA_CREDITO", cmbTipoOperacion, "01")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        If MyTipoCambio = 0 Then
            Resp = MsgBox("Para continuar debe registrar el TIPO DE CAMBIO del " & EvalDato(MyAsientoFecha, "F") & ".", MsgBoxStyle.Information, Me.Text)
            UC_ToolBar.CambiarEstados(3, 3, False)
        Else
            UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
        End If
    End Sub

    Private Sub txtNro_RUC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnexo.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCliente As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyAnexo = New entCONCAR_Anexo
            If String.IsNullOrEmpty(sender.Text.Trim) Then
                Dim MyForm As New frmAnexoLista(MyAnexo, "CLIENTE")
                MyForm.ShowDialog()
            Else
                MyCliente = sender.Text.Trim
                MyAnexo = dalCONCAR_Anexo.ObtenerCliente(MyCliente)
            End If
            If Not MyAnexo.acodane Is Nothing Then
                txtAnexo.Text = MyAnexo.acodane.Trim
                txtAnexoNombre.Text = MyAnexo.adesane.Trim
                txtAvAnexo.Text = "C"
                txtComprobanteSerie.Focus()
            Else
                txtAnexo.Text = Nothing
                txtAnexoNombre.Text = Nothing
                txtAvAnexo.Text = Nothing
                sender.Focus()
            End If
        End If
    End Sub

    Private Sub cmbComprobanteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobanteTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then txtComprobanteNombre.Text = sender.Items(sender.SelectedIndex)(3).ToString
    End Sub

    Private Sub txtOrdenPago_Validated(sender As Object, e As EventArgs)
        UC_ToolBar.btnGrabar_Focus = True
    End Sub

    Private Sub txtAnexoLinea_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnexoLinea.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyAnexoLinea As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyAnexo = New entCONCAR_Anexo
            If String.IsNullOrEmpty(sender.Text.Trim) Then
                Dim MyForm As New frmAnexoLista(MyAnexo, "PROYECTO")
                MyForm.ShowDialog()
            Else
                MyAnexoLinea = sender.Text.Trim
                MyAnexo = dalCONCAR_Anexo.ObtenerProyecto(MyAnexoLinea)
            End If
            If Not MyAnexo.acodane Is Nothing Then
                txtAnexoLinea.Text = MyAnexo.acodane.Trim
                txtAnexoLineaNombre.Text = MyAnexo.adesane.Trim
                txtBaseImponibleGravadaLinea.Focus()
            Else
                txtAnexoLinea.Text = Nothing
                txtAnexoLineaNombre.Text = Nothing
                sender.Focus()
            End If
        End If
    End Sub

    Private Sub gvVentaLineas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvVentaLineas.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            Dim Linea As String = sender.Rows(sender.CurrentRow.Index).Cells("LINEA").Value
            MyVentaDetalle = dalVenta.ObtenerDetalle(MyVenta.empresa, MyVenta.venta, Linea)
            If Not MyVentaDetalle.venta Is Nothing Then
                With MyVentaDetalle
                    txtLinea.Text = .linea
                    txtGlosa1Linea.Text = .glosa_1
                    txtGlosa2Linea.Text = .glosa_2
                    txtGlosa3Linea.Text = .glosa_3
                    txtGlosa4Linea.Text = .glosa_4
                    txtBaseImponibleGravadaLinea.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponibleGravadaLinea.Tag)
                    txtImporteExoneradoLinea.Text = EvalDato(.importe_exonerado_origen, txtImporteExoneradoLinea.Tag)
                    txtImporteInafectoLinea.Text = EvalDato(.importe_inafecto_origen, txtImporteInafectoLinea.Tag)
                    'txtValorExportacionOrigenLinea.Text = EvalDato(.valor_exportacion_origen, txtValorExportacionOrigenLinea.Tag)
                    txtIGVLinea.Text = EvalDato(.igv_origen, txtIGVLinea.Tag)
                    'txtOtrosTributosOrigenLinea.Text = EvalDato(.otros_tributos_origen, txtOtrosTributosOrigenLinea.Tag)
                    txtImporteTotalLinea.Text = EvalDato(.importe_total_origen, txtImporteTotalLinea.Tag)
                    txtAnexoLinea.Text = .proyecto
                End With
            End If
        End If
    End Sub

    Private Sub ValidarReferencia(sender As Object, e As EventArgs) Handles txtReferenciaSerie.Validated, txtReferenciaNumero.Validated
        Dim ReferenciaTipo, ReferenciaSerie, ReferenciaNumero As String
        If sender.text.ToString.Length > 0 Then
            If sender.name = "txtReferenciaNumero" Then
                If IsNumeric(sender.text) Then
                    sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                End If
            End If
        End If

        If txtReferenciaSerie.Text.Trim.Length <> 0 And txtReferenciaNumero.Text.Trim.Length <> 0 Then
            ReferenciaTipo = IIf(cmbReferenciaTipo.SelectedIndex = 0, "01", "03")
            ReferenciaSerie = txtReferenciaSerie.Text.Trim
            ReferenciaNumero = txtReferenciaNumero.Text.Trim
            Call LimpiarFormulario()

            MyVentaReferencia = dalVenta.Obtener(ReferenciaTipo, ReferenciaSerie, ReferenciaNumero)

            If MyVentaReferencia.venta = Nothing Then
                Resp = MsgBox("El Comprobante de referencia no existe.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE COMPROBANTE")
            Else
                With MyVentaReferencia
                    cmbReferenciaTipo.SelectedIndex = IIf(.comprobante_tipo = "01", 0, 1)
                    txtReferenciaSerie.Text = .comprobante_serie
                    txtReferenciaNumero.Text = .comprobante_numero
                    txtVentaReferencia.Text = .venta
                    txtReferenciaFecha.Text = .comprobante_fecha
                    If .comprobante_tipo = "01" Then
                        MyCliente = dalCliente.Obtener(.cuenta_comercial.Trim)
                        txtAnexoNombre.Text = MyCliente.adesane
                        txtAnexo.Text = MyCliente.acodane
                        txtAvAnexo.Text = "C"
                    Else
                        MyAnexo = dalCONCAR_Anexo.ObtenerPersonal(.cuenta_comercial.Trim, "T")
                        txtAnexoNombre.Text = MyAnexo.adesane.Trim
                        txtAnexo.Text = MyAnexo.acodane.Trim
                        txtAvAnexo.Text = "T"
                    End If
                    cmbTipoMoneda.SelectedValue = .tipo_moneda
                End With
            End If
        End If
    End Sub

    Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
        If cmbTipoOperacion.SelectedIndex <> -1 And txtVentaReferencia.Text.Trim.Length <> 0 And txtVenta.Text.Trim.Length = 0 Then
            If cmbTipoOperacion.SelectedIndex = 0 Then

                UC_ToolBar.btnImprimir_Visible = False
                UC_ToolBar.btnAceptar_Visible = False

                MyVentaDetalles = dalVenta.BuscarVentaDetalles(MyUsuario.empresa, txtVentaReferencia.Text)
                MyFacturaDetalles = dalVenta.ObtenerVentaServicio(txtVentaReferencia.Text)

                With MyVentaReferencia
                    txtBaseImponibleGravadaOrigen.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponibleGravadaOrigen.Tag)
                    txtImporteExoneradoOrigen.Text = EvalDato(.importe_exonerado_origen, txtImporteExoneradoOrigen.Tag)
                    txtImporteInafectoOrigen.Text = EvalDato(.importe_inafecto_origen, txtImporteInafectoOrigen.Tag)
                    txtIGVOrigen.Text = EvalDato(.igv_origen, txtIGVOrigen.Tag)
                    txtOtrosTributosOrigen.Text = EvalDato(.otros_tributos_origen, txtOtrosTributosOrigen.Tag)
                    txtImporteTotalOrigen.Text = EvalDato(.importe_total_origen, txtImporteTotalOrigen.Tag)
                    txtDescuentoGlobalOrigen.Text = EvalDato(.descuento_global_origen, txtDescuentoGlobalOrigen.Tag)
                    ckbIndicaExportacion.Checked = IIf(.indica_exportacion = "SI", True, False)
                End With
            Else
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnAceptar_Visible = True

                MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
                MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable

                txtBaseImponibleGravadaOrigen.Text = EvalDato(0, txtBaseImponibleGravadaOrigen.Tag)
                txtImporteExoneradoOrigen.Text = EvalDato(0, txtImporteExoneradoOrigen.Tag)
                txtImporteInafectoOrigen.Text = EvalDato(0, txtImporteInafectoOrigen.Tag)
                txtIGVOrigen.Text = EvalDato(0, txtIGVOrigen.Tag)
                txtOtrosTributosOrigen.Text = EvalDato(0, txtOtrosTributosOrigen.Tag)
                txtImporteTotalOrigen.Text = EvalDato(0, txtImporteTotalOrigen.Tag)
                txtDescuentoGlobalOrigen.Text = EvalDato(0, txtDescuentoGlobalOrigen.Tag)
                ckbIndicaExportacion.Checked = False
            End If
            gvVentaLineas.DataSource = MyVentaDetalles
            gvVentaLineas.ClearSelection()
            txtComentario.Focus()
        End If
    End Sub

    Private Sub cmbReferenciaTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReferenciaTipo.SelectedIndexChanged
        If cmbReferenciaTipo.SelectedIndex <> -1 Then

            If cmbReferenciaTipo.SelectedIndex = 0 Then
                txtComprobanteSerie.Text = "F001"
            Else
                txtComprobanteSerie.Text = "B001"
            End If
            Call PoblarCorrelativo()
        End If
    End Sub

#Region "Funciones"
    Private Sub LimpiarFormulario()
        MyVentaReferencia = New entVenta
        MyVenta = New entVenta
        MyVentaDetalle = New entVentaServicio
        MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable

        MyFactura = New entFactura
        MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable

        MyCliente = New entCONCAR_Cliente
        MyAnexo = New entCONCAR_Anexo
        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        MyAsientoContable = New entAsientoContable
        MyAsientoContableDetalle = New entAsientoContableDetalle
        MyAsientoContableDetallesVirtual = New dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable

        MyCorrelativo = New dsCorrelativo.CORRELATIVODataTable

        MyEComprobante = New entEComprobante
        MyEComprobantes = New dsVentas.ECOMPROBANTESDataTable
        MyEComprobanteFirma = New entEComprobanteFirma

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

        gvVentaLineas.DataSource = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtAnexo.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")
        txtTipoCambio.Text = EvalDato(MyTipoCambio, txtTipoCambio.Tag)
        cmbReferenciaTipo.SelectedIndex = 0
        cmbComprobanteTipo.SelectedValue = "07"
        txtComprobanteFecha.Text = MyAsientoFecha
        txtComprobanteVencimiento.Text = MyAsientoFecha
        cmbTipoMoneda.SelectedValue = "1" : cmbCondicionPago.SelectedValue = "00"
        cmbTipoOperacion.SelectedIndex = -1
        ckbIndicaAnulado.Checked = False : ckbIndicaExportacion.Checked = False
        txtAsientoFecha.Text = MyAsientoFecha : txtAsientoMes.Text = MyAsientoMes : txtAsientoTipo.Text = "05"
        ExistePDF = False
        Call LimpiarLinea()
        Call ActivarDetalles(False)
        Call ActivarCabecera(True)
    End Sub

    Private Sub LimpiarLinea()
        txtLinea.Text = Nothing
        txtGlosa1Linea.Text = Nothing : txtGlosa2Linea.Text = Nothing : txtGlosa3Linea.Text = Nothing : txtGlosa4Linea.Text = Nothing
        txtAnexoLinea.Text = Nothing : txtAnexoLineaNombre.Text = Nothing
        txtBaseImponibleGravadaLinea.Text = "0.00" : txtImporteExoneradoLinea.Text = "0.00" : txtImporteInafectoLinea.Text = "0.00"
        txtIGVLinea.Text = "0.00" : txtImporteTotalLinea.Text = "0.00"
        txtGlosa1Linea.Focus()
    End Sub

    Private Sub ValidarFecha(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteFecha.Validated, txtComprobanteVencimiento.Validated
        If sender.text.ToString.Length > 0 Then
            Dim TipoCambio As Decimal = 0
            Dim Vencimiento As Date
            sender.text = EvalDato(sender.text, sender.tag)
            If IsDate(sender.text) Then
                If sender.name = "txtComprobanteFecha" Then
                    Dim Fecha As Date = sender.text
                    If Fecha.Year <> CInt(MyUsuario.ejercicio) Or Fecha.Month <> MyUsuario.mes Then
                        Resp = MsgBox("La fecha debe estar dentro del Periodo de Trabajo actual.", MsgBoxStyle.Information, Me.Text)
                        sender.text = Nothing
                        sender.focus()
                    Else
                        Vencimiento = DateAdd(DateInterval.Day, CDbl(cmbCondicionPago.SelectedValue), CDate(sender.text))
                        txtComprobanteVencimiento.Text = EvalDato(Vencimiento, txtComprobanteVencimiento.Tag)
                        TipoCambio = dalAsientoContable.ObtenerTipoCambio(sender.Text.Substring(6, 4), sender.Text.Substring(3, 2), sender.Text.Substring(0, 2), "VENTA")
                        txtTipoCambio.Text = EvalDato(TipoCambio, txtTipoCambio.Tag)
                        If TipoCambio = 0 Then
                            Resp = MsgBox("No existe el Tipo de Cambio para la fecha del Comprobante.", MsgBoxStyle.Information, Me.Text)
                            txtComprobanteFecha.Text = Nothing
                            txtComprobanteVencimiento.Text = Nothing
                            txtComprobanteFecha.Focus()
                        End If
                    End If
                ElseIf sender.name = "txtComprobanteVencimiento" Then
                    Dim FechaComprobante As Date = txtComprobanteFecha.Text
                    Dim FechaVencimiento As Date = txtComprobanteVencimiento.Text
                    If FechaVencimiento < FechaComprobante Then
                        Resp = MsgBox("La Fecha de Vencimiento no puede ser menor que la Fecha del Comprobante.", MsgBoxStyle.Information, Me.Text)
                        txtComprobanteVencimiento.Text = Nothing
                        txtComprobanteVencimiento.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ValidarSerieNumero(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobanteSerie.Validated, txtComprobanteNumero.Validated
        Dim MyNumero As String = sender.text
        If sender.text.ToString.Length > 0 Then

            If sender.name = "txtComprobanteNumero" Then
                If IsNumeric(sender.text) Then
                    sender.text = Strings.Right(CUO_Nulo & sender.text, sender.MaxLength)
                Else
                    Call PoblarCorrelativo()
                End If
            Else
                If sender.Text.Substring(0, 1) = "F" Then
                    Call PoblarCorrelativo()
                Else
                    sender.text = "F001"
                    Call PoblarCorrelativo()
                End If
            End If
        End If
    End Sub

    Private Sub ValidarNumero(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseImponibleGravadaLinea.Validated, txtImporteExoneradoLinea.Validated, txtImporteInafectoLinea.Validated, txtIGVLinea.Validated
        sender.text = EvalDato(sender.text, sender.tag)
        If sender.name <> "txtIGVLinea" Then
            If CDec(txtBaseImponibleGravadaLinea.Text) <> 0 Then txtIGVLinea.Text = EvalDato(CDec(txtBaseImponibleGravadaLinea.Text) * MyIGV / 100, txtIGVLinea.Tag)
        End If
        txtImporteTotalLinea.Text = EvalDato(CDec(txtBaseImponibleGravadaLinea.Text) + CDec(txtImporteExoneradoLinea.Text) + CDec(txtImporteInafectoLinea.Text) + CDec(txtIGVLinea.Text), txtImporteTotalLinea.Tag)
    End Sub

    Private Sub PoblarCorrelativo()
        MyCorrelativo = dalVenta.ObtenerCorrelativo("07", txtComprobanteSerie.Text)
        If MyCorrelativo.Rows.Count = 0 Then
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & "1", txtComprobanteNumero.MaxLength)
        Else
            txtComprobanteNumero.Text = Strings.Right(CUO_Nulo & CInt(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1, txtComprobanteNumero.MaxLength)
        End If
    End Sub

    Private Sub InicializarFormulario()
        MyAccion = "NUEVO"
        Call LimpiarFormulario()
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        'txtAnexo.Enabled = IndicaActivo
        cmbReferenciaTipo.Enabled = IndicaActivo
        txtReferenciaSerie.Enabled = IndicaActivo
        txtReferenciaNumero.Enabled = IndicaActivo
        txtComprobanteSerie.Enabled = IndicaActivo
        cmbTipoOperacion.Enabled = IndicaActivo
        'cmbTipoMoneda.Enabled = IndicaActivo

        'cmbComprobanteTipo.Enabled = IndicaActivo
        'txtComprobanteNumero.Enabled = IndicaActivo 
        'txtComprobanteFecha.Enabled = IndicaActivo
        'txtComprobanteVencimiento.Enabled = IndicaActivo 
        'cmbCondicionPago.Enabled = IndicaActivo 
        'ckbIndicaExportacion.Enabled = IndicaActivo
        'ckbIndicaAnulado.Enabled = IndicaActivo

        'txtAnexo.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        txtReferenciaSerie.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        txtReferenciaNumero.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        txtComprobanteSerie.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)

        'cmbTipoMoneda.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)

        'cmbComprobanteTipo.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        'txtComprobanteNumero.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        'txtComprobanteFecha.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        'txtComprobanteVencimiento.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)
        'cmbCondicionPago.BackColor = IIf(IndicaActivo, Color.Honeydew, Color.LightYellow)

        'txtAnexo.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtReferenciaSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtReferenciaNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        txtComprobanteSerie.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'cmbTipoMoneda.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)

        'cmbComprobanteTipo.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtComprobanteNumero.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtComprobanteFecha.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'txtComprobanteVencimiento.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)
        'cmbCondicionPago.ForeColor = IIf(IndicaActivo, Color.MediumBlue, Color.DarkRed)

        If IndicaActivo = True Then txtGlosa1Linea.Focus()
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        txtGlosa1Linea.Enabled = IndicaActivo
        txtGlosa2Linea.Enabled = IndicaActivo
        txtGlosa3Linea.Enabled = IndicaActivo
        txtGlosa4Linea.Enabled = IndicaActivo
        txtAnexoLinea.Enabled = IndicaActivo
        txtBaseImponibleGravadaLinea.Enabled = IndicaActivo
        txtImporteExoneradoLinea.Enabled = IndicaActivo
        txtImporteInafectoLinea.Enabled = IndicaActivo
        txtImporteInafectoLinea.Enabled = IndicaActivo
        txtIGVLinea.Enabled = IndicaActivo
        btnAceptar.Enabled = IndicaActivo
        btnBorrar.Enabled = IndicaActivo
        btnAceptar.ImageIndex = IIf(IndicaActivo = True, 1, 3)
        btnBorrar.ImageIndex = IIf(IndicaActivo = True, 0, 2)
        gvVentaLineas.Enabled = IndicaActivo
        If IndicaActivo = True Then txtGlosa1Linea.Focus()
    End Sub

    Private Sub ActualizarAsientosDetalles()
        MyAsientoContableDetallesVirtual = dalAsientoContableVirtual.ObtenerDetallesVirtual(MyUsuario.empresa, MyAsientoTipo, txtVenta.Text)
        If MyAsientoContableDetallesVirtual.Rows.Count > 0 Then dalAsientoContable.InsertarDetallesVirtual(MyAsientoContableDetallesVirtual)
    End Sub

    Private Sub PoblarFormulario(pVenta As String)
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(pVenta)
        MyVentaReferencia = dalVenta.Obtener(MyVenta.referencia_tipo, MyVenta.referencia_serie, MyVenta.referencia_numero)
        If Not MyVenta.venta Is Nothing Then
            MyEComprobanteFirma = dalVenta.Obtener(MyVenta.empresa, MyVenta.venta)
            With MyVenta
                If .ejercicio = MyUsuario.ejercicio And .mes = Strings.Right("00" & MyUsuario.mes.ToString, 2) Then
                    Call ActivarCabecera(False)
                    Call ActivarDetalles(IIf(.tipo_operacion = "01", False, True))

                    txtVenta.Text = .venta
                    If .referencia_tipo = "03" Then
                        MyAnexo = dalCONCAR_Anexo.ObtenerPersonal(.cuenta_comercial.Trim, "T")
                        txtAnexoNombre.Text = MyAnexo.adesane.Trim
                        txtAnexo.Text = MyAnexo.acodane.Trim
                        txtAvAnexo.Text = "T"
                    Else
                        MyCliente = dalCliente.Obtener(.cuenta_comercial.Trim)
                        txtAnexoNombre.Text = MyCliente.adesane
                        txtAnexo.Text = MyCliente.acodane
                        txtAvAnexo.Text = "C"
                    End If
                    txtAsientoFecha.Text = EvalDato(.asiento_fecha, "F")
                    txtAsientoNumero.Text = .asiento_numero
                    txtTipoCambio.Text = EvalDato(.tipo_cambio, txtTipoCambio.Tag)
                    cmbTipoMoneda.SelectedValue = .tipo_moneda
                    cmbCondicionPago.SelectedValue = .condicion_pago
                    txtBaseImponibleGravadaOrigen.Text = EvalDato(.base_imponible_gravada_origen, txtBaseImponibleGravadaOrigen.Tag)
                    txtImporteExoneradoOrigen.Text = EvalDato(.importe_exonerado_origen, txtImporteExoneradoOrigen.Tag)
                    txtImporteInafectoOrigen.Text = EvalDato(.importe_inafecto_origen, txtImporteInafectoOrigen.Tag)
                    txtIGVOrigen.Text = EvalDato(.igv_origen, txtIGVOrigen.Tag)
                    txtOtrosTributosOrigen.Text = EvalDato(.otros_tributos_origen, txtOtrosTributosOrigen.Tag)
                    txtImporteTotalOrigen.Text = EvalDato(.importe_total_origen, txtImporteTotalOrigen.Tag)

                    txtDescuentoGlobalOrigen.Text = EvalDato(.descuento_global_origen, txtDescuentoGlobalOrigen.Tag)

                    txtComentario.Text = .comentario

                    cmbTipoOperacion.SelectedIndex = CByte(.tipo_operacion) - 1

                    txtVentaReferencia.Text = MyVentaReferencia.venta
                    cmbReferenciaTipo.SelectedIndex = IIf(.referencia_tipo = "01", 0, 1)
                    txtReferenciaSerie.Text = .referencia_serie
                    txtReferenciaNumero.Text = .referencia_numero
                    txtReferenciaFecha.Text = .referencia_fecha

                    cmbComprobanteTipo.SelectedValue = .comprobante_tipo
                    txtComprobanteSerie.Text = .comprobante_serie
                    txtComprobanteNumero.Text = .comprobante_numero
                    txtComprobanteFecha.Text = .comprobante_fecha
                    txtComprobanteVencimiento.Text = .comprobante_vencimiento

                    ckbIndicaExportacion.Checked = IIf(.indica_exportacion = "SI", True, False)
                    ckbIndicaAnulado.Checked = IIf(.estado = "N", True, False)

                    txtDigestValue.Text = MyEComprobanteFirma.digest_value
                    txtSignatureValue.Text = MyEComprobanteFirma.signature_value

                    Call ActualizarGrilla()
                    txtGlosa1Linea.Focus()
                End If
            End With
        End If
    End Sub

    Private Sub ActualizarGrilla()
        Dim vBaseImponibleGravada, vImporteExonerado, vImporteInafecto, vValorExportacion, vIGV, vOtrosTributos, vImporteTotal As Decimal
        Dim vImporteDescuentoGlobal As Decimal = CDec(txtDescuentoGlobalOrigen.Text)
        Dim MyVentasResumen As New entVentaResumen

        MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
        MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable

        If txtVenta.Text <> Nothing Then
            MyVentaDetalles = dalVenta.BuscarVentaDetalles(MyUsuario.empresa, txtVenta.Text)
            MyFacturaDetalles = dalVenta.ObtenerVentaServicio(txtVenta.Text)
        End If

        gvVentaLineas.DataSource = MyVentaDetalles
        gvVentaLineas.ClearSelection()
        For NEle = 0 To MyVentaDetalles.Rows.Count - 1
            vBaseImponibleGravada = vBaseImponibleGravada + MyVentaDetalles(NEle).BASE_IMPONIBLE_GRAVADA_ORIGEN
            vImporteExonerado = vImporteExonerado + MyVentaDetalles(NEle).IMPORTE_EXONERADO_ORIGEN
            vImporteInafecto = vImporteInafecto + MyVentaDetalles(NEle).IMPORTE_INAFECTO_ORIGEN
            vValorExportacion = vValorExportacion + MyVentaDetalles(NEle).VALOR_EXPORTACION_ORIGEN
            vIGV = vIGV + MyVentaDetalles(NEle).IGV_ORIGEN
            vOtrosTributos = vOtrosTributos + MyVentaDetalles(NEle).OTROS_TRIBUTOS_ORIGEN
            vImporteTotal = vImporteTotal + MyVentaDetalles(NEle).IMPORTE_TOTAL_ORIGEN
        Next

        If vImporteDescuentoGlobal <> 0 Then
            vBaseImponibleGravada = vBaseImponibleGravada - vImporteDescuentoGlobal
            vIGV = Math.Round(vBaseImponibleGravada * MyIGV / 100, 2)
            vImporteTotal = vBaseImponibleGravada + vIGV
        End If
        txtBaseImponibleGravadaOrigen.Text = EvalDato(vBaseImponibleGravada, txtBaseImponibleGravadaOrigen.Tag)
        txtImporteExoneradoOrigen.Text = EvalDato(vImporteExonerado, txtImporteExoneradoOrigen.Tag)
        txtImporteInafectoOrigen.Text = EvalDato(vImporteInafecto, txtImporteInafectoOrigen.Tag)
        txtIGVOrigen.Text = EvalDato(vIGV, txtIGVOrigen.Tag)
        txtOtrosTributosOrigen.Text = EvalDato(vOtrosTributos, txtOtrosTributosOrigen.Tag)
        txtImporteTotalOrigen.Text = EvalDato(vImporteTotal, txtImporteTotalOrigen.Tag)

        If txtVenta.Text <> Nothing And vImporteTotal <> 0 Then
            With MyVentasResumen
                .empresa = MyUsuario.empresa
                .venta = txtVenta.Text
                .valor_exportacion_origen = vValorExportacion
                .base_imponible_gravada_origen = vBaseImponibleGravada
                .importe_exonerado_origen = vImporteExonerado
                .importe_inafecto_origen = vImporteInafecto
                .igv_origen = vIGV
                .otros_tributos_origen = vOtrosTributos
                .descuento_global_origen = vImporteDescuentoGlobal
                .importe_total_origen = vImporteTotal
            End With
            MyVentasResumen = dalVenta.ActualizarResumen(MyVentasResumen)
        End If
    End Sub

    Private Sub CargarDetalles()
        With MyVentaDetalle
            .empresa = MyUsuario.empresa
            .venta = txtVenta.Text
            .linea = txtLinea.Text
            .glosa_1 = txtGlosa1Linea.Text
            .glosa_2 = txtGlosa2Linea.Text
            .glosa_3 = txtGlosa3Linea.Text
            .glosa_4 = txtGlosa4Linea.Text
            .tipo_cambio = CDec(txtTipoCambio.Text)
            .tipo_moneda = cmbTipoMoneda.SelectedValue
            .base_imponible_gravada_origen = CDec(txtBaseImponibleGravadaLinea.Text)
            .importe_exonerado_origen = CDec(txtImporteExoneradoLinea.Text)
            .importe_inafecto_origen = CDec(txtImporteInafectoLinea.Text)
            .igv_origen = CDec(txtIGVLinea.Text)
            .importe_total_origen = CDec(txtImporteTotalLinea.Text)
            If .tipo_moneda = "1" Then
                .base_imponible_gravada_mn = .base_imponible_gravada_origen
                .importe_exonerado_mn = .importe_exonerado_origen
                .importe_inafecto_mn = .importe_inafecto_origen
                .valor_exportacion_mn = .valor_exportacion_origen
                .igv_mn = .igv_origen
                .otros_tributos_mn = .otros_tributos_origen
                .importe_total_mn = .importe_total_origen
                .base_imponible_gravada_me = .base_imponible_gravada_origen / .tipo_cambio
                .importe_exonerado_me = .importe_exonerado_origen / .tipo_cambio
                .importe_inafecto_me = .importe_inafecto_origen / .tipo_cambio
                .valor_exportacion_me = .valor_exportacion_origen / .tipo_cambio
                .igv_me = .igv_origen / .tipo_cambio
                .otros_tributos_me = .otros_tributos_origen / .tipo_cambio
                .importe_total_me = .importe_total_origen / .tipo_cambio
            Else

                .base_imponible_gravada_me = .base_imponible_gravada_origen
                .importe_exonerado_me = .importe_exonerado_origen
                .importe_inafecto_me = .importe_inafecto_origen
                .valor_exportacion_me = .valor_exportacion_origen
                .igv_me = .igv_origen
                .otros_tributos_me = .otros_tributos_origen
                .importe_total_me = .importe_total_origen
                .base_imponible_gravada_mn = .base_imponible_gravada_origen * .tipo_cambio
                .importe_exonerado_mn = .importe_exonerado_origen * .tipo_cambio
                .importe_inafecto_mn = .importe_inafecto_origen * .tipo_cambio
                .valor_exportacion_mn = .valor_exportacion_origen * .tipo_cambio
                .igv_mn = .igv_origen * .tipo_cambio
                .otros_tributos_mn = .otros_tributos_origen * .tipo_cambio
                .importe_total_mn = .importe_total_origen * .tipo_cambio
            End If
            .indica_proyecto = True
            .proyecto = txtAnexoLinea.Text
            .usuario_registro = MyUsuario.usuario
        End With
    End Sub

    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim ImporteSoles As Decimal
        Dim ValorVenta As Decimal
        Dim SubTotal As Decimal


        Dim MyLogo As Drawing.Image
        MyLogo = Image.FromFile("C:\TEMP\Logo_CIA.jpg")

        MyConsultaRUC = dalVenta.ObtenerDatosRUC(txtAnexo.Text)

        If MyConsultaRUC.Rows.Count <> 0 Then
            MyClienteNombre = MyConsultaRUC(0).RAZON_SOCIAL
            MyClienteDomicilio = MyConsultaRUC(0).DOMICILIO_FISCAL & " " & MyConsultaRUC(0).DISTRITO & " " & MyConsultaRUC(0).PROVINCIA & " " & MyConsultaRUC(0)._REGION
        Else
            MyClienteNombre = txtAnexoNombre.Text
            MyClienteDomicilio = Space(1)
        End If

        Try
            'Definir la fuente
            Dim prFont As New Font("Courier New", 9, FontStyle.Regular)
            Dim prFontB As New Font("Courier New", 9, FontStyle.Bold)
            Dim prFontT As New Font("Courier New", 11, FontStyle.Bold)
            'Dim prFontD As New Font("Arial Narrow", 9, FontStyle.Regular)
            Dim prFontD As New Font("Courier New", 8, FontStyle.Regular)
            Dim prFontDB As New Font("Arial Narrow", 9, FontStyle.Bold)


            Dim prFontTB As New Font("Arial Narrow", 9, FontStyle.Bold)


            e.Graphics.DrawImage(MyLogo, New Rectangle(50, 20, 200, 40))
            e.Graphics.DrawString(MyRazonSocial, prFontT, Brushes.DarkBlue, 60, 65)
            e.Graphics.DrawString(MyDomicilioFiscal, prFontB, Brushes.DarkBlue, 60, 85)
            e.Graphics.DrawString(MyDistrito, prFontB, Brushes.DarkBlue, 60, 100)


            e.Graphics.DrawRectangle(Pens.DarkRed, New Rectangle(540, 20, 240, 75))
            e.Graphics.DrawString("FACTURA ELECTRONICA", prFontT, Brushes.DarkRed, 570, 30)
            e.Graphics.DrawString("RUC " & MyRUC, prFontT, Brushes.DarkRed, 588, 50)
            e.Graphics.DrawString(MyFactura.Documento_Serie & "-" & MyFactura.Documento_Numero, prFontT, Brushes.DarkRed, 588, 70)

            e.Graphics.DrawLine(Pens.Black, 60, 125, 780, 125)

            e.Graphics.DrawString("Fecha de Emisión     : " & MyFactura.Fecha_Emision, prFont, Brushes.DarkBlue, 60, 140)
            e.Graphics.DrawString("Fecha de Vencimientos: " & MyFactura.Fecha_Vencimiento, prFont, Brushes.DarkBlue, 60, 155)
            e.Graphics.DrawString("Cliente   : " & MyClienteNombre, prFontB, Brushes.DarkBlue, 60, 175)
            e.Graphics.DrawString("RUC       : " & MyFactura.RUC, prFontB, Brushes.DarkBlue, 60, 190)
            e.Graphics.DrawString("Dirección : " & MyClienteDomicilio, prFontB, Brushes.DarkBlue, 60, 205)
            e.Graphics.DrawString("Moneda    : " & cmbTipoMoneda.Text, prFontB, Brushes.DarkBlue, 60, 220)
            e.Graphics.DrawString("Observaciones : ", prFontB, Brushes.DarkBlue, 60, 235)

            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

            If MyFactura.Indica_Exportacion = "NO" Then
                If MyAfectoDetraccion = "SI" Then
                    If ImporteSoles > MyMinimoDetraccion Then
                        e.Graphics.DrawString("Observaciones : OPERACION SUJETA AL PAGO DE DETRACCIONES CON EL GOBIERNO CENTRAL (" & EvalDato(MyDetraccion, "E") & "%)", prFontB, Brushes.DarkBlue, 60, 235)
                        e.Graphics.DrawString("                DEPOSITAR A LA CTA. CTE. BANCO DE LA NACION N° " & MyCuentaDetraccion, prFontB, Brushes.DarkBlue, 60, 248)

                    End If
                End If
            End If

            e.Graphics.DrawRectangle(Pens.Black, 60, 270, 720, 30)
            e.Graphics.DrawString("Cantidad", prFontD, Brushes.DarkBlue, 65, 280)
            e.Graphics.DrawString("U. Medida", prFontD, Brushes.DarkBlue, 130, 280)
            e.Graphics.DrawString("Descripción", prFontD, Brushes.DarkBlue, 210, 280)
            e.Graphics.DrawString("Valor Unitario", prFontD, Brushes.DarkBlue, 675, 280)

            NFil = 320
            'imprimimos Detalles

            For NEle = 0 To MyFacturaDetalles.Count - 1
                With MyFacturaDetalles(NEle)
                    ValorVenta = .BASE_IMPONIBLE_GRAVADA_ORIGEN + .VALOR_EXPORTACION_ORIGEN + .importe_exonerado_ORIGEN + .importe_inafecto_ORIGEN
                    SubTotal = SubTotal + ValorVenta
                    e.Graphics.DrawString("1.00", prFontD, Brushes.DarkBlue, 75, NFil)
                    e.Graphics.DrawString("UNIDAD", prFontD, Brushes.DarkBlue, 130, NFil)
                    If .GLOSA_1.Trim.Length > 0 Then
                        e.Graphics.DrawString(.GLOSA_1, prFontD, Brushes.DarkBlue, 210, NFil)
                    End If
                    If .GLOSA_2.Trim.Length > 0 Then
                        NFil = NFil + 15
                        e.Graphics.DrawString(.GLOSA_2, prFontD, Brushes.DarkBlue, 210, NFil)
                    End If
                    If .GLOSA_3.Trim.Length > 0 Then
                        NFil = NFil + 15
                        e.Graphics.DrawString(.GLOSA_3, prFontD, Brushes.DarkBlue, 210, NFil)
                    End If
                End With
                e.Graphics.DrawString(Strings.Right(Space(12) & EvalDato(ValorVenta, "D").ToString, 12), prFontD, Brushes.DarkBlue, 685, NFil)
                NFil = NFil + 20
            Next NEle

            If txtComentario.TextLength <> 0 Then
                NFil = NFil + 15
                e.Graphics.DrawString(Strings.Left(txtComentario.Text, 80), prFontTB, Brushes.DarkBlue, 80, NFil)
                If Strings.Len(txtComentario.Text.Trim) > 80 Then
                    e.Graphics.DrawString(Strings.Mid(txtComentario.Text, 81, 80), prFontTB, Brushes.DarkBlue, 80, NFil + 10)
                    If Strings.Len(txtComentario.Text.Trim) > 160 Then
                        e.Graphics.DrawString(Strings.Mid(txtComentario.Text, 161, 80), prFontTB, Brushes.DarkBlue, 80, NFil + 20)
                    End If
                End If
            End If

            NFil = NFil + 50

            e.Graphics.DrawString("VALOR VENTA  : " & Strings.Right(Space(12) & EvalDato(SubTotal, "D").ToString, 12), prFontB, Brushes.DarkBlue, 560, NFil)
            e.Graphics.DrawString("IGV          : " & Strings.Right(Space(12) & txtIGVOrigen.Text, 12), prFontB, Brushes.DarkBlue, 560, NFil + 20)
            e.Graphics.DrawString("PRECIO VENTA : " & Strings.Right(Space(12) & txtImporteTotalOrigen.Text, 12), prFontB, Brushes.DarkBlue, 560, NFil + 40)

            NFil = NFil + 80

            e.Graphics.DrawString("SON: " & ConvertNumText(CDbl(txtImporteTotalOrigen.Text), cmbTipoMoneda.Text), prFontB, Brushes.DarkBlue, 75, NFil)

            NFil = NFil + 35

            e.Graphics.DrawLine(Pens.Black, 60, NFil, 780, NFil)

            NFil = NFil + 25

            e.Graphics.DrawString("Autorizados a emitir Comprobantes Electrónicos desde el 18/01/2017, mediante R.I. N° 032-005-0001126/SUNAT.", prFontDB, Brushes.DarkBlue, 60, NFil)
            e.Graphics.DrawString("Representación Impresa de la Factura Electrónica, puede consultar en https://ecomprobantes.wundermanphantasia.pe ", prFontDB, Brushes.DarkBlue, 60, NFil + 20)

            'indicamos que hemos llegado al final de la pagina
            e.HasMorePages = False

            ExistePDF = True

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Imprimir_Comprobante()
        Dim EsConforme As Boolean = False
        Dim MyCorrelativo As dsCorrelativo.CORRELATIVODataTable
        If txtVenta.Text.Trim <> "" And cmbTipoMoneda.SelectedIndex <> -1 Then
            MyAccion = "IMPRIMIR"

            MyFactura = New entFactura
            With MyFactura
                .Venta = txtVenta.Text
                .Documento_Serie = txtComprobanteSerie.Text
                .Documento_Numero = txtComprobanteNumero.Text
                .Fecha_Emision = txtComprobanteFecha.Text
                .Fecha_Vencimiento = txtComprobanteVencimiento.Text
                .Razon_Social = txtAnexoNombre.Text
                .RUC = txtAnexo.Text
                .Condicion_Pago = cmbCondicionPago.SelectedValue
                .Tipo_Moneda = cmbTipoMoneda.SelectedValue
                .Valor_Venta = CDec(txtBaseImponibleGravadaOrigen.Text) + CDec(txtImporteExoneradoOrigen.Text) + CDec(txtImporteInafectoOrigen.Text)
                .IGV = CDec(txtIGVOrigen.Text)
                .Precio_Venta = CDec(txtImporteTotalOrigen.Text)
                .Precio_Venta_Texto = ConvertNumText(CDec(txtImporteTotalOrigen.Text), cmbTipoMoneda.SelectedValue)
                .Indica_Exportacion = IIf(ckbIndicaExportacion.Checked = True, "SI", "NO")

                MyTextboxSerie.Text = .Documento_Serie
                MyTextboxNumero.Text = .Documento_Numero
                MyTextboxFecha.Text = .Fecha_Emision
            End With

            MyPrintDocument = New Printing.PrintDocument

            AddHandler MyPrintDocument.PrintPage, AddressOf Print_PrintPage

            MyPrintPreview.Document = MyPrintDocument
            MyLabel.Text = "FACTURA"

            ControlarCorrelativo = IIf(MyFactura.Documento_Serie <> "000", False, True)

            DirectCast(MyPrintPreview, Form).WindowState = FormWindowState.Maximized
            MyPrintPreview.ShowDialog()

            If AsignarCorrelativo Then
                MyVenta.comprobante_fecha = MyFactura.Fecha_Emision
                MyCorrelativo = dalVenta.ActualizarCorrelativo(MyVenta)
                If MyCorrelativo.Count > 0 Then
                    Resp = MsgBox("Se asignó el correlativo SERIE: " & MyCorrelativo(0).COMPROBANTE_SERIE & " NUMERO: " & MyCorrelativo(0).COMPROBANTE_NUMERO, MessageBoxButtons.OK, "FACTURA")
                    Call InicializarFormulario()
                End If
            End If
        End If
    End Sub

    Private Sub Imprimir_EComprobante()
        Dim ImporteSoles As Decimal = 0
        Dim ValorVenta As Decimal = 0
        Dim SubTotal As Decimal = 0
        Dim Observaciones As String = Space(1)
        Dim NombreArchivo As String = Space(1)

        Dim ImporteTexto As String = Space(1)
        Dim TextoQR As String

        If txtVenta.Text.Trim <> "" And cmbTipoMoneda.SelectedIndex <> -1 Then

            MyEComprobantes = New dsVentas.ECOMPROBANTESDataTable
            Dim MyDR As DataRow = MyEComprobantes.NewRow()

            MyDR("EMPRESA") = MyVenta.empresa
            MyDR("CUENTA_COMERCIAL") = MyVenta.cuenta_comercial
            MyDR("COMPROBANTE_TIPO") = MyVenta.comprobante_tipo
            MyDR("COMPROBANTE_SERIE") = MyVenta.comprobante_serie
            MyDR("COMPROBANTE_NUMERO") = MyVenta.comprobante_numero
            MyDR("VENTA") = MyVenta.venta

            MyEComprobantes.Rows.Add(MyDR)

            MyEComprobantes = dalVenta.Obtener(MyEComprobantes)

            MyConsultaRUC = dalVenta.ObtenerDatosRUC(txtAnexo.Text)

            If MyConsultaRUC.Rows.Count <> 0 Then
                MyClienteDocumentoTipo = "06"
                MyClienteDocumentoNumero = MyConsultaRUC(0).RUC
                MyClienteNombre = MyConsultaRUC(0).RAZON_SOCIAL
                MyClienteDomicilio = MyConsultaRUC(0).DOMICILIO_FISCAL & " " & MyConsultaRUC(0).DISTRITO & " " & MyConsultaRUC(0).PROVINCIA & " " & MyConsultaRUC(0)._REGION
            Else
                MyClienteDocumentoTipo = "-"
                MyClienteDocumentoNumero = "0"
                MyClienteNombre = txtAnexoNombre.Text
                MyClienteDomicilio = Space(1)
            End If

            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

            If MyVenta.condicion_pago = "TG" Then
                Observaciones = "TRANSFERENCIA GRATUITA"
            Else
                If MyVenta.indica_exportacion = "NO" Then
                    If MyAfectoDetraccion = "SI" Then
                        If ImporteSoles > MyMinimoDetraccion Then
                            Observaciones = "SUJETA AL PAGO DE DETRACCIONES (" & EvalDato(MyDetraccion, "E") & "%), CTA. CTE. BANCO DE LA NACION N° " & MyCuentaDetraccion
                        End If
                    End If
                End If
            End If

            With MyVenta
                NombreArchivo = MyRUC & "-" & .comprobante_tipo & "-" & .comprobante_serie & "-" & .comprobante_numero.Substring(2, 8)
                TextoQR = MyRUC & "|" & .comprobante_tipo & "|" & .comprobante_serie & "|" & .comprobante_numero.Substring(2, 8) & "|" & CStr(CDec(txtIGVOrigen.Text)) & "|" & CStr(CDec(txtImporteTotalOrigen.Text)) & "|" & txtComprobanteFecha.Text & "|" & _
                          MyClienteDocumentoTipo & "|" & MyClienteDocumentoNumero & "|" & txtDigestValue.Text & "|" & "" & "|"
            End With

            ImporteTexto = "SON: " & ConvertNumText(CDbl(txtImporteTotalOrigen.Text), cmbTipoMoneda.Text)

            'Dim MyForm As New frmENotaCreditoImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR)

            'MyForm.ShowDialog()
        End If
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_TB_btnBorrar_Click()
        MyAccion = "ANULAR"
        If String.IsNullOrEmpty(txtVenta.Text) Then
            MyAccion = Nothing
        Else
            Resp = MsgBox("Confirmar proceso de anulación." & Chr(13) & "Todas las líneas del documento serán eliminadas." & Chr(13) & "¿Desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, MyAccion & " REGISTRO")
            If Resp = vbYes Then
                Try
                    If dalVenta.Anular(MyVenta) = True Then
                        Resp = MsgBox("El Comprobante se anuló con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                        Call LimpiarFormulario()
                    End If
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If

    End Sub

    Private Sub UC_ToolBar_TB_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyAccion = "EDITAR"
        Dim MyForm As New frmEComprobantesServiciosLista(MyVenta, "07")
        MyForm.ShowDialog()
        If Not MyVenta.venta Is Nothing Then
            Call PoblarFormulario(MyVenta.venta)
            If MyVenta.estado = "A" Then
                btnAceptar.Enabled = True : btnBorrar.Enabled = True
            Else
                btnAceptar.Enabled = False : btnBorrar.Enabled = False
            End If
        End If
    End Sub

    Private Sub UC_Toolbar_TB_btAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim Nombre_Archivo As String = Nothing
        Dim MyEstadoCDR As String

        UC_ToolBar.btnAceptar_Visible = False

        If txtVenta.Text.Trim <> "" Then
            If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
                Resp = MsgBox("El Comprobante Electrónico " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero & " ya fué enviado a SUNAT.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
            Else
                Dim strRetorno As String = dalXML_Factura.EnviarDocumento(Nombre_Archivo, MyVenta)
                If strRetorno = "" Then
                    Resp = MsgBox("No existe archivo ZIP a enviar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                Else
                    Resp = MsgBox(strRetorno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")

                    If strRetorno.Substring(0, 5) <> "ERROR" Then
                        Call ActivarCabecera(False)
                        MyEstadoCDR = dalXML_Factura.ObtenerEstadoCDR(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero)
                        MyEComprobante = New entEComprobante
                        With MyEComprobante
                            .empresa = MyVenta.empresa
                            .cuenta_comercial = MyVenta.cuenta_comercial
                            .comprobante_tipo = MyVenta.comprobante_tipo
                            .comprobante_serie = MyVenta.comprobante_serie
                            .comprobante_numero = MyVenta.comprobante_numero
                            .comprobante_fecha = MyVenta.comprobante_fecha
                            .comprobante_vencimiento = MyVenta.comprobante_vencimiento
                            .ejercicio = MyVenta.ejercicio
                            .mes = MyVenta.mes
                            .dia = Strings.Right("00" & MyVenta.comprobante_fecha.Day, 2)
                            .tipo_cambio = MyVenta.tipo_cambio
                            .moneda = cmbTipoMoneda.Items(cmbTipoMoneda.SelectedIndex)("TEXTO_01")
                            .valor_exportacion = CDec(txtValorExportacionOrigen.Text)
                            .base_imponible_gravada = CDec(txtBaseImponibleGravadaOrigen.Text)
                            .importe_exonerado = CDec(txtImporteExoneradoOrigen.Text)
                            .importe_inafecto = CDec(txtImporteInafectoOrigen.Text)
                            .isc = MyVenta.isc_origen
                            .igv = CDec(txtIGVOrigen.Text)
                            .ipm = MyVenta.ipm_origen
                            .base_imponible_gravada2 = MyVenta.base_imponible_gravada2_origen
                            .igv2 = MyVenta.igv2_origen
                            .otros_tributos = CDec(txtOtrosTributosOrigen.Text)
                            .descuento_global = CDec(txtDescuentoGlobalOrigen.Text)
                            .importe_total = CDec(txtImporteTotalOrigen.Text)
                            .referencia_tipo = MyVenta.referencia_tipo
                            .referencia_serie = MyVenta.referencia_serie
                            .referencia_numero = MyVenta.referencia_numero
                            .referencia_fecha = MyVenta.referencia_fecha
                            .nombre_archivo = Nombre_Archivo
                            .usuario_envio = MyVenta.usuario_envio
                            .fecha_envio = MyVenta.fecha_envio
                            .estado_ticket = "98"
                            '.estado_comprobante = IIf(Strings.Left(strRetorno, 5) = "ERROR", "1002", "1001")
                            .estado_comprobante = MyEstadoCDR
                            .venta = MyVenta.venta
                            If MyVenta.referencia_tipo = "01" Then
                                MyCliente = dalCliente.Obtener(MyVenta.cuenta_comercial)
                                .razon_social = MyCliente.adesane
                                .email_contacto = MyCliente.aemail
                                .email_facturacion = MyCliente.aemail
                            Else
                                .razon_social = txtAnexoNombre.Text.Trim
                            End If
                            .mensaje = Strings.Left(strRetorno, 120)
                            .digest_value = txtDigestValue.Text
                            .signature_value = txtSignatureValue.Text
                            .usuario_registro = MyUsuario.usuario
                        End With
                        dalVenta.Grabar(MyEComprobante)
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".xml")
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".zip")
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".pdf")
                        dalVenta.CargarEComprobante("R-" & Nombre_Archivo & ".zip")

                        If MyEComprobante.estado_comprobante = "1001" And MyEComprobante.referencia_tipo = "01" Then
                            dalEmails.EnviarCorreo(MyEComprobante.empresa, MyEComprobante.cuenta_comercial, Nombre_Archivo)
                        End If

                        If dalVenta.ActualizarEstadoEnvio(MyEComprobante.empresa, MyEComprobante.venta, IIf(MyEstadoCDR = "0", "A", "R")) = True Then
                            LimpiarFormulario()
                        End If

                    End If

                    'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & Nombre_Archivo & ".xml")
                    'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & Nombre_Archivo & ".zip")
                    'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & Nombre_Archivo & ".pdf")
                    'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & "R-" & Nombre_Archivo & ".zip")

                End If
            End If
        End If
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub UC_ToolBar_TB_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""
        If txtVenta.Text.Trim <> "" Then
            If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
                MyVenta.tipo_operacion_nombre = cmbTipoOperacion.Text
                MyVenta.comentario = txtComentario.Text.Trim
                If dalXML_Factura.CrearDocumento(MyVenta, MyVentaDetalles, MyFacturaDetalles, txtAnexoNombre.Text, cmbTipoMoneda.Text) = True Then
                    If dalXML_Factura.FirmarDocumento(MyVenta, DigestValue, SignatureValue) = True Then
                        Resp = MsgBox("El Comprobante Electrónico " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero & " ha sido creado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
                        txtDigestValue.Text = DigestValue
                        txtSignatureValue.Text = SignatureValue
                        MyEComprobanteFirma = New entEComprobanteFirma
                        With MyEComprobanteFirma
                            .empresa = MyVenta.empresa
                            .venta = MyVenta.venta
                            .digest_value = txtDigestValue.Text
                            .signature_value = txtSignatureValue.Text
                            .usuario_registro = MyUsuario.usuario
                        End With
                        dalVenta.Grabar(MyEComprobanteFirma)
                    End If
                End If
            End If
            Call Imprimir_EComprobante()
        End If
    End Sub

    Private Sub UC_ToolBar_TB_btnImprimir_Click_Old()
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""
        If txtVenta.Text.Trim <> "" Then
            If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
                If dalXML_Factura.CrearDocumento(MyVenta, MyVentaDetalles, MyFacturaDetalles, txtAnexoNombre.Text, cmbTipoMoneda.Text) = True Then
                    If dalXML_Factura.FirmarDocumento(MyVenta, DigestValue, SignatureValue) = True Then
                        Resp = MsgBox("El Comprobante Electrónico " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero & " ha sido creado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
                        txtDigestValue.Text = DigestValue
                        txtSignatureValue.Text = SignatureValue
                    End If
                End If
            End If
            Call Imprimir_Comprobante()
        End If
    End Sub

    Private Sub UC_ToolBar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

    Private Sub UC_ToolBar_TB_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call InicializarFormulario()
    End Sub

    Private Sub UC_ToolBar_TB_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click

        If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
            Resp = MsgBox("El Comprobante Electrónico ya fué enviado a SUNAT." & vbLf & "No es posible grabar cambios.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
        Else
            With MyVenta
                .empresa = MyUsuario.empresa
                .venta = txtVenta.Text
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .asiento_tipo = MyAsientoTipo
                .asiento_numero = txtAsientoNumero.Text
                .asiento_fecha = txtAsientoFecha.Text
                .cuenta_comercial = txtAnexo.Text
                .comprobante_tipo = cmbComprobanteTipo.SelectedValue
                .comprobante_serie = txtComprobanteSerie.Text
                .comprobante_numero = txtComprobanteNumero.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .comprobante_fecha = txtComprobanteFecha.Text
                If txtComprobanteVencimiento.Text.Length <> 0 Then .comprobante_vencimiento = txtComprobanteVencimiento.Text
                .tipo_cambio = CDec(txtTipoCambio.Text)
                .tipo_moneda = cmbTipoMoneda.SelectedValue
                .comentario = txtComentario.Text
                .tipo_operacion = cmbTipoOperacion.SelectedValue
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
                .indica_exportacion = IIf(ckbIndicaExportacion.Checked = True, "SI", "NO")
                .usuario_registro = MyUsuario.usuario

                .referencia_tipo = IIf(cmbReferenciaTipo.SelectedIndex = 0, "01", "03")
                .referencia_serie = txtReferenciaSerie.Text
                .referencia_numero = txtReferenciaNumero.Text
                If txtReferenciaFecha.Text.Length <> 0 Then .referencia_fecha = txtReferenciaFecha.Text

            End With

            With MyAsientoContable
                .empresa = MyUsuario.empresa
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .asiento_tipo = MyAsientoTipo
                .asiento_numero = txtAsientoNumero.Text
                .asiento_fecha = txtAsientoFecha.Text
                .tipo_moneda = cmbTipoMoneda.SelectedValue
                .tipo_cambio = CDec(txtTipoCambio.Text)
                If txtComprobanteFecha.Text.Length <> 0 Then .movimientos_fecha = txtComprobanteFecha.Text
                .movimientos_tipo_cambio = CDec(txtTipoCambio.Text)
                .glosa = txtComentario.Text
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
                .usuario_registro = MyUsuario.usuario
            End With

            Try
                MyVenta = dalVenta.GrabarNota(MyVenta)
                MyAsientoContable = dalAsientoContable.Grabar(MyAsientoContable)
                txtVenta.Text = MyVenta.venta
                txtAsientoNumero.Text = MyVenta.asiento_numero

                If cmbTipoOperacion.SelectedValue = "01" Then
                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnAceptar_Visible = True
                    UC_ToolBar.btnSalir_Focus = True
                    If dalVenta.InsertarDetalleNota(txtVenta.Text, txtVentaReferencia.Text) = True Then
                        Dim MyVentasResumen As New entVentaResumen
                        With MyVentasResumen
                            .empresa = MyUsuario.empresa
                            .venta = txtVenta.Text
                            '.valor_exportacion_origen = vValorExportacion
                            .base_imponible_gravada_origen = CDec(txtBaseImponibleGravadaOrigen.Text)
                            .importe_exonerado_origen = CDec(txtImporteExoneradoOrigen.Text)
                            .importe_inafecto_origen = CDec(txtImporteInafectoOrigen.Text)
                            .igv_origen = CDec(txtIGVOrigen.Text)
                            .otros_tributos_origen = CDec(txtOtrosTributosOrigen.Text)
                            '.descuento_global_origen = vImporteDescuentoGlobal
                            .importe_total_origen = CDec(txtImporteTotalOrigen.Text)
                        End With
                        MyVentasResumen = dalVenta.ActualizarResumen(MyVentasResumen)
                        Resp = MsgBox("La anulación de la operación se realizó con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                    End If
                Else
                    Resp = MsgBox("Los cambios del encabezado se realizaron con éxito.", MsgBoxStyle.Information, MyAccion & " REGISTRO")
                    Call ActivarDetalles(True)
                    txtGlosa1Linea.Focus()
                End If



            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
            Resp = MsgBox("El Comprobante Electrónico ya fué enviado a SUNAT." & vbLf & "No es posible grabar cambios.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
        Else
            If Not String.IsNullOrEmpty(txtVenta.Text.Trim) Then
                Call CargarDetalles()
                Try
                    MyVentaDetalle = dalVenta.Grabar(MyVentaDetalle)

                    'Call ActualizarAsientosDetalles()
                    Call ActualizarGrilla()
                    Call LimpiarLinea()
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) Then
            Resp = MsgBox("El Comprobante Electrónico ya fué enviado a SUNAT." & vbLf & "No es posible grabar cambios.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
        Else
            If txtVenta.Text.Trim.Length <> 0 And txtLinea.Text.Trim.Length <> 0 Then
                Call CargarDetalles()
                Try
                    If dalVenta.Borrar(MyVentaDetalle) = True Then
                        Call ActualizarGrilla()
                        Call LimpiarLinea()
                    End If
                Catch ex As BusinessException
                    Resp = MsgBox(ex.Message)
                Catch ex As Exception
                    Resp = MsgBox("ERROR: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#End Region



    Private Sub txtReferenciaNumero_TextChanged(sender As Object, e As EventArgs) Handles txtReferenciaNumero.TextChanged

    End Sub
End Class
