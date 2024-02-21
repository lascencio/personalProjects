Public Class frmEComprobantes
    Private MyVenta As entVenta
    Private MyVentaDetallada As dsVentas.VENTA_DETALLADataTable

    Private MyEComprobantes As dsEComprobantes.ECOMPROBANTES_LISTADataTable
    Private MyEComprobante As entEComprobante
    Private MyEComprobanteFirma As entEComprobanteFirma

    Private MyComprobanteTipo As String

    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private MyCliente As entCuentaComercial

    Private MyClienteDocumentoTipo As String
    Private MyClienteDocumentoNumero As String
    Private MyClienteNombre As String
    Private MyClienteDomicilio As String
    Private MyIndice As Integer

    Private MyComprobante As dsVentas.COMPROBANTEDataTable
    Private MyComprobanteSeries As dsVentas.COMPROBANTE_SERIESDataTable

    Private DigestValue As String
    Private SignatureValue As String

    Private Sub frmEComprobantes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEComprobantes_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbComprobanteTipo, "SEE_TIPO_DOCUMENTO")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        cmbTipoMoneda.SelectedIndex = -1

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnSUNAT_Visible = False

        Call LimpiarFormulario()

        Call PoblarGrilla()

        rbtMovimientosMes.Checked = True
    End Sub

    Private Sub gvVentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvVentas.CellDoubleClick
        Call gvVentas_Click(gvVentas, True)
    End Sub

    Private Sub gvVentas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvVentas.CellFormatting
        Dim MyRow As DataGridViewRow = sender.Rows(e.RowIndex)
        If MyRow.Cells("ESTADO").Value.ToString.Substring(0, 1) = "R" Then
            MyRow.DefaultCellStyle.BackColor = Color.Tomato
            MyRow.DefaultCellStyle.ForeColor = Color.White
        ElseIf MyRow.Cells("ESTADO").Value.ToString.Substring(0, 1) = "A" Then
            MyRow.DefaultCellStyle.BackColor = Color.AliceBlue
            MyRow.DefaultCellStyle.ForeColor = Color.DarkBlue
        Else
            MyRow.DefaultCellStyle.BackColor = Color.White
            MyRow.DefaultCellStyle.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub gvVentas_LostFocus(sender As Object, e As EventArgs) Handles gvVentas.LostFocus
        gvVentas.ClearSelection()
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta

        MyCliente = New entCuentaComercial
        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        MyEComprobante = New entEComprobante
        MyEComprobanteFirma = New entEComprobanteFirma

        Dim MyPanelControl As Panel
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
            ElseIf TypeOf ctrl Is Panel Then
                MyPanelControl = ctrl
                For Each PCctrl As Object In MyPanelControl.Controls
                    If TypeOf PCctrl Is TextBox Then
                        Select Case PCctrl.tag
                            Case Is = "V" : PCctrl.text = "0.0000"
                            Case Is = "C" : PCctrl.text = "0.000"
                            Case Is = "D" : PCctrl.text = "0.00"
                            Case Is = "E" : PCctrl.text = "0"
                            Case Else : PCctrl.text = Nothing
                        End Select
                    ElseIf TypeOf PCctrl Is CheckBox Then
                        PCctrl.Checked = False
                    ElseIf TypeOf PCctrl Is ComboBox Then
                        PCctrl.SelectedIndex = -1
                    End If
                Next
            End If
        Next

        DigestValue = ""
        SignatureValue = ""

        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnAceptar_Visible = False

        gvVentas.ClearSelection()
    End Sub

    Private Sub PoblarGrilla()
        MyEComprobantes = New dsEComprobantes.ECOMPROBANTES_LISTADataTable
        MyEComprobantes = dalVenta.BuscarEComprobantes(MyUsuario.empresa, MyUsuario.ejercicio, Strings.Right("00" & MyUsuario.mes.ToString, 2), "", "")
        gvVentas.DataSource = MyEComprobantes
        gvVentas.Focus()
    End Sub

    Private Sub gvVentas_Click(sender As Object, EjecutarImpresion As Boolean)
        If Not gvVentas.CurrentRow Is Nothing Then
            Dim VentaSeleccion As String = sender.Rows(sender.CurrentRow.Index).Cells("VENTA").Value
            MyIndice = sender.CurrentRow.Index
            MyVenta = New entVenta

            MyVenta.empresa = MyUsuario.empresa
            MyVenta.venta = VentaSeleccion
            MyVenta = dalVenta.Obtener(VentaSeleccion)

            Select Case sender.Rows(MyIndice).Cells("COMPROBANTE_TIPO").Value
                Case Is = "FT" : cmbComprobanteTipo.SelectedValue = "01"
                Case Is = "BV" : cmbComprobanteTipo.SelectedValue = "03"
                Case Is = "NC" : cmbComprobanteTipo.SelectedValue = "07"
                Case Is = "ND" : cmbComprobanteTipo.SelectedValue = "08"
            End Select

            txtVenta.Text = VentaSeleccion
            txtAnexo.Text = sender.Rows(MyIndice).Cells("NRO_DOCUMENTO").Value
            txtAnexoNombre.Text = sender.Rows(MyIndice).Cells("RAZON_SOCIAL").Value
            txtComprobanteTipo.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_TIPO").Value
            txtComprobanteSerie.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_SERIE").Value
            txtComprobanteNumero.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_NUMERO").Value
            txtComprobanteFecha.Text = EvalDato(sender.Rows(MyIndice).Cells("COMPROBANTE_FECHA").Value, "F")
            cmbTipoMoneda.SelectedIndex = IIf(sender.Rows(MyIndice).Cells("MONEDA").Value = "S/", 1, 0)
            txtImporteTotalOrigen.Text = EvalDato(sender.Rows(MyIndice).Cells("MONTO_TOTAL").Value, txtImporteTotalOrigen.Tag)
            txtIGVOrigen.Text = EvalDato(sender.Rows(MyIndice).Cells("IMPUESTO").Value, txtIGVOrigen.Tag)

            txtTipoCambio.Text = EvalDato(sender.Rows(MyIndice).Cells("TIPO_CAMBIO").Value, txtTipoCambio.Tag)

            txtEmailFacturacion.Text = sender.Rows(MyIndice).Cells("EMAIL").Value.ToString.Trim

            MyClienteDocumentoTipo = sender.Rows(MyIndice).Cells("TIPO_DOCUMENTO").Value
            MyClienteDocumentoNumero = IIf(sender.Rows(MyIndice).Cells("NRO_DOCUMENTO").Value = "-", "0", sender.Rows(MyIndice).Cells("NRO_DOCUMENTO").Value)
            MyClienteNombre = sender.Rows(MyIndice).Cells("RAZON_SOCIAL").Value
            MyClienteDomicilio = "-"

            If sender.Rows(MyIndice).Cells("ESTADO").Value = "RECHAZADO" Then
                UC_ToolBar.btnSUNAT_Visible = True
            Else
                UC_ToolBar.btnSUNAT_Visible = False
            End If

            If sender.Rows(MyIndice).Cells("USUARIO_ENVIO").Value.ToString.Trim.Length = 0 Then
                UC_ToolBar.btnAceptar_Visible = True
            Else
                UC_ToolBar.btnAceptar_Visible = False
            End If

            If EjecutarImpresion = True Then Call EvaluarImpresion()
        End If
    End Sub

    Private Sub EvaluarImpresion()
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""
        If txtVenta.Text.Trim <> "" Then
            If DigestValue = "" And SignatureValue = "" Then
                UC_ToolBar.btnImprimir_Visible = False
                UC_ToolBar.btnAceptar_Visible = False
                If Not MyVenta.venta Is Nothing Then
                    Call ObtenerDatosComprobante()
                    MyVenta.tipo_documento = Strings.Right(MyClienteDocumentoTipo, 1)
                    MyVenta.nro_documento = MyClienteDocumentoNumero
                    MyVenta.razon_social = MyClienteNombre
                    If dalXML.EvaluarExisteXML(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero) = False Then
                        If dalXML.CrearComprobante(MyVenta, MyVentaDetallada) = True Then
                            If dalXML.FirmarDocumento(MyVenta, DigestValue, SignatureValue) = True Then
                                txtDigestValue.Text = DigestValue
                                txtSignatureValue.Text = SignatureValue
                                MyEComprobanteFirma = New entEComprobanteFirma
                                With MyEComprobanteFirma
                                    .empresa = MyVenta.empresa
                                    .venta = MyVenta.venta
                                    .digest_value = txtDigestValue.Text
                                    .signature_value = txtSignatureValue.Text
                                    .usuario_registro = Strings.Left(MyUsuario.usuario.Trim, 20)
                                End With
                                dalEComprobante.GrabarFirma(MyEComprobanteFirma)
                            End If
                        End If
                    End If

                    UC_ToolBar.btnAceptar_Visible = True

                    Call Imprimir_EComprobante()
                End If
                UC_ToolBar.btnImprimir_Visible = True
            End If
        End If
    End Sub

    Private Sub Imprimir_EComprobante()
        ImpresionCancelada = True
        Dim ImporteSoles As Decimal = 0
        Dim ValorVenta As Decimal = 0
        Dim SubTotal As Decimal = 0
        Dim PorcentajeIGV As Decimal = 0
        Dim PorcentajeServicio As Decimal = 0
        Dim Observaciones As String = Space(1)
        Dim NombreArchivo As String = Space(1)

        Dim ImporteTexto As String = Space(1)
        Dim TextoQR As String

        If txtVenta.Text.Trim <> "" And cmbTipoMoneda.SelectedIndex <> -1 Then
            If MyVenta.comprobante_tipo = "01" Then
                If txtAnexo.Text.Trim.Length = 11 Then
                    MyConsultaRUC = dalVenta.ObtenerDatosRUC(txtAnexo.Text)
                Else
                    MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
                End If
                If MyConsultaRUC.Rows.Count <> 0 Then
                    MyClienteDocumentoTipo = "6"
                    MyClienteDocumentoNumero = MyConsultaRUC(0).RUC
                    MyClienteNombre = MyConsultaRUC(0).RAZON_SOCIAL
                    MyClienteDomicilio = MyConsultaRUC(0).DOMICILIO_FISCAL & " " & MyConsultaRUC(0).DISTRITO & " " & MyConsultaRUC(0).PROVINCIA & " " & MyConsultaRUC(0)._REGION
                Else
                    MyClienteDocumentoTipo = "-"
                    MyClienteDocumentoNumero = "0"

                    MyClienteNombre = "CLIENTE DEL EXTERIOR"
                    MyClienteDomicilio = "NO DOMICILIADO"
                End If
            Else
                MyCliente = dalCuentaComercial.Obtener(MyUsuario.empresa, MyVenta.cuenta_comercial)
                MyClienteNombre = MyCliente.razon_social
                MyClienteDomicilio = MyCliente.domicilio
                MyClienteDocumentoTipo = MyCliente.tipo_documento
                MyClienteDocumentoNumero = MyCliente.nro_documento
            End If

            MyVenta.tipo_documento = MyClienteDocumentoTipo
            MyVenta.nro_documento = MyClienteDocumentoNumero
            MyVenta.razon_social = MyClienteNombre

            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "1", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

            If MyVenta.condicion_pago = "TG" Then Observaciones = "TRANSFERENCIA GRATUITA"
            If MyVenta.estado = "N" Then Observaciones = "COMPROBANTE ANULADO POR EL USUARIO " & MyVenta.usuario_modifica

            With MyVenta
                NombreArchivo = MyRUC & "-" & .comprobante_tipo & "-" & .comprobante_serie & "-" & .comprobante_numero.Substring(2, 8)

                TextoQR = MyRUC & "|" & .comprobante_tipo & "|" & .comprobante_serie & "|" & .comprobante_numero.Substring(2, 8) & "|" &
                          CStr(CDec(txtIGVOrigen.Text)) & "|" & CStr(CDec(txtImporteTotalOrigen.Text)) & "|" & txtComprobanteFecha.Text & "|" & _
                          MyClienteDocumentoTipo & "|" & MyClienteDocumentoNumero & "|" & txtDigestValue.Text & "|" & "" & "|"
            End With

            ImporteTexto = "SON: " & ConvertNumText(CDbl(txtImporteTotalOrigen.Text), cmbTipoMoneda.Text)

            Dim MyForm As New frmEComprobanteVentaImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR, PorcentajeIGV, MyComprobante, MyVentaDetallada)
            MyForm.ShowDialog()

        End If
    End Sub

    Private Sub EnviarComprobanteSUNAT()
        Dim Nombre_Archivo As String = Nothing
        Dim MyEstadoCDR As String
        UC_ToolBar.btnAceptar_Visible = False

        If txtVenta.Text.Trim <> "" Then
            If dalEComprobante.ExisteEComprobante(MyVenta.empresa, MyVenta.venta) Then
                Resp = MsgBox("El Comprobante Electrónico " & MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero &
                              " ya fué enviado a SUNAT.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
            Else
                Dim strRetorno As String = dalXML.EnviarDocumento(Nombre_Archivo, MyVenta)
                If strRetorno = "" Then
                    Resp = MsgBox("No existe archivo ZIP a enviar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                Else
                    MyCliente = New entCuentaComercial
                    MyEComprobante = New entEComprobante
                    If strRetorno.Substring(0, 5) = "ERROR" Then
                        Resp = MsgBox(strRetorno, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                        With MyEComprobante
                            .empresa = MyVenta.empresa
                            .cuenta_comercial = MyVenta.cuenta_comercial
                            .comprobante_tipo = MyVenta.comprobante_tipo
                            .comprobante_serie = MyVenta.comprobante_serie
                            .comprobante_numero = MyVenta.comprobante_numero
                            .estado_ticket = "98"
                            .estado_comprobante = IIf(Strings.Left(strRetorno, 5) = "ERROR", "1002", "1001")
                            .mensaje = Strings.Left(strRetorno, 120)
                            .usuario_registro = Strings.Left(MyUsuario.usuario, 20)
                        End With
                        dalEComprobante.GrabarError(MyEComprobante)
                        'CREAR OPCION PARA ENVIAR CORREO A ECOMPROBANTES
                        'dalEmails.EnviarCorreo(MyEComprobante.empresa, MyEComprobante.cuenta_comercial, Nombre_Archivo)
                    Else
                        MyEstadoCDR = dalXML.ObtenerEstadoCDR(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero)
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
                            .moneda = cmbTipoMoneda.SelectedValue
                            .valor_exportacion = MyVenta.valor_exportacion_origen
                            .base_imponible_gravada = MyVenta.base_imponible_gravada_origen
                            .importe_exonerado = MyVenta.importe_exonerado_origen
                            .importe_inafecto = MyVenta.importe_inafecto_origen
                            .isc = MyVenta.isc_origen
                            .igv = MyVenta.igv_origen
                            .ipm = MyVenta.ipm_origen
                            .base_imponible_gravada2 = MyVenta.base_imponible_gravada2_origen
                            .igv2 = MyVenta.igv2_origen
                            .otros_tributos = MyVenta.otros_tributos_origen
                            .descuento_global = MyVenta.descuento_global_origen
                            .importe_total = MyVenta.importe_total_origen
                            .referencia_tipo = MyVenta.referencia_tipo
                            .referencia_serie = MyVenta.referencia_serie
                            .referencia_numero = MyVenta.referencia_numero
                            .referencia_fecha = MyVenta.referencia_fecha
                            .nombre_archivo = Nombre_Archivo
                            .usuario_envio = Strings.Left(MyVenta.usuario_envio, 20)
                            .fecha_envio = MyVenta.fecha_envio
                            .estado_ticket = "98"
                            '.estado_comprobante = IIf(Strings.Left(strRetorno, 5) = "ERROR", "1002", "1001")
                            .estado_comprobante = MyEstadoCDR
                            .venta = MyVenta.venta

                            MyCliente = dalCuentaComercial.Obtener(MyUsuario.empresa, MyVenta.cuenta_comercial)
                            If MyCliente.razon_social.Trim.Length = 0 Then
                                .razon_social = txtAnexoNombre.Text.Trim
                            Else
                                .cuenta_comercial = MyCliente.nro_documento 'Corregido el 23/11/2018, esta grabando en la web el código en vez del RUC o DNI
                                .razon_social = MyCliente.razon_social
                                .email_contacto = MyCliente.email
                                .email_facturacion = MyCliente.email
                            End If

                            .mensaje = Strings.Left(strRetorno, 120)
                            .digest_value = txtDigestValue.Text
                            .signature_value = txtSignatureValue.Text
                            .usuario_registro = Strings.Left(MyUsuario.usuario, 20)
                        End With
                        dalEComprobante.GrabarEComprobante(MyEComprobante)
                        'dalEComprobante.CargarEComprobante(Nombre_Archivo & ".xml")
                        'dalEComprobante.CargarEComprobante(Nombre_Archivo & ".zip")
                        'dalEComprobante.CargarEComprobante(Nombre_Archivo & ".pdf")
                        'dalEComprobante.CargarEComprobante("R-" & Nombre_Archivo & ".zip")

                        If dalVenta.ActualizarEstadoEnvio(MyEComprobante.empresa, MyEComprobante.venta, IIf(MyEstadoCDR = "0", "A", "R")) = True Then
                            If MyEstadoCDR = "0" Then dalEmail.EnviarCorreo(MyEComprobante.empresa, MyCliente.nro_documento, Nombre_Archivo, MyEComprobante.comprobante_fecha)
                            LimpiarFormulario()
                            PoblarGrilla()
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ObtenerDatosComprobante()
        Dim MyProducto As entProducto
        Dim MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable
        Dim Producto As String
        Dim MySeries As String

        MyComprobante = dalVenta.ObtenerComprobante(MyVenta.venta)

        If MyVenta.estado = "N" Then
            MyVentaDetallada = New dsVentas.VENTA_DETALLADataTable
        ElseIf MyVenta.comprobante_tipo = "07" And MyVenta.tipo_operacion = "C2" Then
            MyVentaDetallada = dalVenta.VentaDetalladaNC(MyVenta.venta)
        ElseIf MyVenta.comprobante_tipo = "08" Then
            MyVentaDetallada = dalVenta.VentaDetalladaNC(MyVenta.venta)
        Else
            MyVentaDetallada = dalVenta.VentaDetallada(MyVenta.venta)
        End If

        If MyVenta.comprobante_tipo = "07" Then
            MyComprobanteSeries = dalVenta.ObtenerNotaCreditoSeries(MyVenta.venta)
        Else
            MyComprobanteSeries = dalVenta.ObtenerComprobanteSeries(MyVenta.guia_remitente)
            If MyComprobanteSeries.Rows.Count = 0 Then
                MyComprobanteSeries = dalVenta.ObtenerComprobanteSeriesVentaDirecta(MyVenta.venta)
            End If
        End If

        If MyVentaDetallada.Rows.Count <> 0 Then
            If MyVenta.tipo_operacion = "B7" Or MyVenta.tipo_operacion = "F7" Then ' Venta Vehicular
                MyVentaDetallada(0).DESCRIPCION = MyVentaDetallada(0).DESCRIPCION.Trim & _
                                      " SERIE MOTOR: " & MyComprobanteSeries(0).NUMERO_SERIE & _
                                      " SERIE CHASIS: " & MyComprobanteSeries(0).NUMERO_SERIE_CHASIS & _
                                      " COLOR: " & MyComprobanteSeries(0).COLOR
            Else
                For NFila As Integer = 0 To MyVentaDetallada.Rows.Count - 1
                    If MyVentaDetallada(NFila).INDICA_SERIE = "SI" Then
                        MySeries = "SERIES: "
                        Producto = MyVentaDetallada(NFila).PRODUCTO
                        MyProducto = dalProducto.Obtener(MyUsuario.empresa, Producto)

                        If MyProducto.indica_compuesto = "NO" Then
                            If MyComprobanteSeries.Rows.Count <> 0 Then
                                For NFila2 As Integer = 0 To MyComprobanteSeries.Rows.Count - 1
                                    If MyComprobanteSeries(NFila2).PRODUCTO = Producto Then
                                        MySeries = MySeries & MyComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / "
                                    End If
                                Next
                            End If
                        Else
                            MyProductoComponentes = dalProducto.ObtenerProductoComponentes(MyUsuario.empresa, Producto)
                            If MyProductoComponentes.Rows.Count <> 0 Then
                                For NFila3 As Integer = 0 To MyProductoComponentes.Rows.Count - 1
                                    Producto = MyProductoComponentes(NFila3).PRODUCTO
                                    If MyComprobanteSeries.Rows.Count <> 0 Then
                                        For NFila2 As Integer = 0 To MyComprobanteSeries.Rows.Count - 1
                                            If MyComprobanteSeries(NFila2).PRODUCTO = Producto Then
                                                MySeries = MySeries & MyComprobanteSeries(NFila2).NUMERO_SERIE.Trim & " / "
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        End If
                        MySeries = Strings.Left(MySeries, MySeries.Trim.Length - 1)
                        MyVentaDetallada(NFila).DESCRIPCION = MyVentaDetallada(NFila).DESCRIPCION.Trim & " " & MySeries
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_TB_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtVenta.Text.Trim.Length <> 0 Then
            UC_ToolBar.btnImprimir_Visible = False
            MyVenta = dalVenta.Obtener(txtVenta.Text.Trim)
            Call EvaluarImpresion()
            UC_ToolBar.btnImprimir_Visible = True
        End If
    End Sub

    Private Sub UC_ToolBar_TB_btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        UC_ToolBar.btnInformacion_Visible = False
        Call PoblarGrilla()
        UC_ToolBar.btnInformacion_Visible = True
    End Sub

    Private Sub UC_Toolbar_TB_btAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        UC_ToolBar.btnAceptar_Visible = False
        Call EnviarComprobanteSUNAT()
        gvVentas.Focus()
    End Sub

    Private Sub UC_ToolBar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

    Private Sub UC_ToolBar_TB_btnSUNAT_Click() Handles UC_ToolBar.TB_btnSUNAT_Click
        If cmbComprobanteTipo.SelectedIndex <> -1 And txtComprobanteSerie.Text.Trim.Length <> 0 And txtComprobanteNumero.Text.Trim.Length <> 0 Then
            Call dalXML.ObtenerEstadoCDR(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero)
        End If
    End Sub

#End Region


End Class
