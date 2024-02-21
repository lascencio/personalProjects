Public Class frmEComprobantes
    Private MyVentas As dsVentas.VENTAS_LISTADataTable

    Private MyVenta As entVenta
    'Private MyVentaDatos As dsVentas.VENTAS_DATOSDataTable

    Private MyVentaDetalles As dsVentasDetalleLista.VENTAS_DET_LISTADataTable
    Private MyFacturaDetalles As dsVentas.VENTAS_SERDataTable

    Private MyEComprobante As entEComprobante
    Private MyEComprobanteFirma As entEComprobanteFirma
    Private MyEComprobantes As dsVentas.ECOMPROBANTESDataTable

    Private MyComprobanteTipo As String

    Private MyConsultaRUC As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

    Private MyCliente As entCONCAR_Cliente
    Private MyClienteWeb As entCliente

    Private MyClienteDocumentoTipo As String
    Private MyClienteDocumentoNumero As String
    Private MyClienteNombre As String
    Private MyClienteDomicilio As String
    Private MyClienteRUC As String
    Private MyClienteEmail As String
    Private MyIndice As Integer

    Private MyComprobanteCliente As dsComprobantesCliente.COMPROBANTESDataTable

    Private DigestValue As String
    Private SignatureValue As String

    Private Sub frmEComprobantes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEComprobantes_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarTabla("SEE_TIPO_DOCUMENTO", cmbComprobanteTipo, "01")
        ActualizarTabla("_TIPO_MONEDA", cmbTipoMoneda, "1")
        cmbTipoMoneda.SelectedIndex = -1

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnAceptar_Visible = False

        Call PoblarGrilla()

        rbtMovimientosMes.Checked = True
    End Sub

    Private Sub txtFechaBuscar_Validated(sender As Object, e As EventArgs) Handles txtFechaBuscar.Validated
        Dim Fecha As Date
        Dim Ejercicio As Integer
        Dim Mes As Byte

        sender.text = EvalDato(sender.text, sender.tag)
        If sender.Text.Trim.Length <> 0 Then
            Fecha = txtFechaBuscar.Text
            If Fecha.Year.ToString <> MyUsuario.ejercicio Then
                sender.Text = Nothing
            Else
                If Fecha.Month <> MyUsuario.mes Then
                    sender.Text = Nothing
                Else
                    Call PoblarGrilla()
                End If
            End If
        End If

        gvVentas.Focus()
    End Sub

    Private Sub gvVentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvVentas.CellClick
        'Call gvVentas_Click(gvVentas, False)
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

    'Private Sub rbtMovimientos_CheckedChanged(sender As Object, e As EventArgs)
    '    If rbtMovimientosMes.Checked = True Then
    '        txtFechaBuscar.ReadOnly = True
    '        txtFechaBuscar.BackColor = Color.Moccasin
    '        txtFechaBuscar.ForeColor = Color.DarkRed
    '        Call PoblarGrilla()
    '        gvVentas.Focus()
    '    Else
    '        txtFechaBuscar.ReadOnly = False
    '        txtFechaBuscar.BackColor = Color.Honeydew
    '        txtFechaBuscar.ForeColor = Color.MediumBlue
    '        txtFechaBuscar.Focus()
    '    End If
    'End Sub

#Region "Funciones"

    Private Sub gvVentas_Click(sender As Object, EjecutarImpresion As Boolean)
        If Not gvVentas.CurrentRow Is Nothing Then
            Dim VentaSeleccion As String = sender.Rows(sender.CurrentRow.Index).Cells("VENTA").Value
            MyIndice = sender.CurrentRow.Index
            MyVenta = New entVenta
            MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
            MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable
            'MyVentaDatos = New dsVentas.VENTAS_DATOSDataTable

            MyVenta.empresa = "001"
            MyVenta.venta = VentaSeleccion
            MyVenta = dalVenta.Obtener(VentaSeleccion)

            Select Case sender.Rows(MyIndice).Cells("COMPROBANTE_TIPO").Value
                Case Is = "FT" : cmbComprobanteTipo.SelectedValue = "01"
                Case Is = "BV" : cmbComprobanteTipo.SelectedValue = "03"
                Case Is = "NC" : cmbComprobanteTipo.SelectedValue = "07"
                Case Is = "ND" : cmbComprobanteTipo.SelectedValue = "08"
            End Select

            txtVenta.Text = VentaSeleccion
            txtAnexo.Text = sender.Rows(MyIndice).Cells("CUENTA_COMERCIAL").Value
            txtAnexoNombre.Text = sender.Rows(MyIndice).Cells("RAZON_SOCIAL").Value
            txtComprobanteTipo.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_TIPO").Value
            txtComprobanteSerie.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_SERIE").Value
            txtComprobanteNumero.Text = sender.Rows(MyIndice).Cells("COMPROBANTE_NUMERO").Value
            txtComprobanteFecha.Text = EvalDato(sender.Rows(MyIndice).Cells("COMPROBANTE_FECHA").Value, "F")
            cmbTipoMoneda.SelectedIndex = IIf(sender.Rows(MyIndice).Cells("MONEDA").Value = "S/.", 1, 0)
            txtImporteTotalOrigen.Text = EvalDato(sender.Rows(MyIndice).Cells("MONTO_TOTAL").Value, txtImporteTotalOrigen.Tag)
            txtIGVOrigen.Text = EvalDato(sender.Rows(MyIndice).Cells("IMPUESTO").Value, txtIGVOrigen.Tag)

            txtTipoCambio.Text = EvalDato(sender.Rows(MyIndice).Cells("TIPO_CAMBIO").Value, txtTipoCambio.Tag)

            txtEmailFacturacion.Text = sender.Rows(MyIndice).Cells("EMAIL").Value.ToString.Trim

            'Valores para generar usuario y clave web automáticos
            MyClienteNombre = txtAnexoNombre.Text.ToString.Trim
            MyClienteEmail = txtEmailFacturacion.Text
            MyClienteRUC = txtAnexo.Text

            MyClienteWeb = New entCliente
            With MyClienteWeb
                .empresa = "001"
                .cuenta_comercial = MyClienteRUC
                .razon_social = MyClienteNombre
                .email_facturacion = MyClienteEmail
                .usuario_web = MyClienteEmail
                .clave_web = MyClienteRUC.Substring(0, 4)
                .usuario_registro = "SISTEMAS"
            End With

            If Not String.IsNullOrEmpty(MyClienteEmail) Then
                If Not dalCuentaComercial.ExisteECliente(MyClienteWeb) Then
                    MyClienteWeb = dalCuentaComercial.InsertarECliente(MyClienteWeb)
                End If
            End If


            If sender.Rows(MyIndice).Cells("ESTADO").Value = "RECHAZADO" Then
                UC_ToolBar.btnSUNAT_Visible = True
            Else
                UC_ToolBar.btnSUNAT_Visible = False
            End If

            If dalXML_Factura.EvaluarExisteXML(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero) Then
                If sender.Rows(MyIndice).Cells("ESTADO").Value.ToString.Trim.Length = 0 Then
                    UC_ToolBar.btnAceptar_Visible = True

                Else
                    UC_ToolBar.btnAceptar_Visible = False
                End If
            Else
                UC_ToolBar.btnAceptar_Visible = False
            End If

            If EjecutarImpresion = True Then Call EvaluarImpresion()
        End If
    End Sub

    Private Sub LimpiarFormulario()
        MyVenta = New entVenta
        MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
        MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable

        MyCliente = New entCONCAR_Cliente
        MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable

        MyEComprobante = New entEComprobante
        MyEComprobantes = New dsVentas.ECOMPROBANTESDataTable
        MyEComprobanteFirma = New entEComprobanteFirma

        MyComprobanteCliente = New dsComprobantesCliente.COMPROBANTESDataTable

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

        DigestValue = ""
        SignatureValue = ""

        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnAceptar_Visible = False

        gvVentas.ClearSelection()

        gvVentas.Focus()
    End Sub

    Private Sub PoblarGrilla()
        MyVentas = New dsVentas.VENTAS_LISTADataTable
        If rbtMovimientosMes.Checked = True Then
            MyVentas = dalVenta.BuscarVentas(MyUsuario.empresa, MyUsuario.ejercicio, Strings.Right("00" & MyUsuario.mes.ToString, 2), "", "")
        Else
            If IsDate(txtFechaBuscar.Text) Then
                MyVentas = dalVenta.BuscarVentasDia(MyUsuario.empresa, MyUsuario.ejercicio, Strings.Right("00" & MyUsuario.mes.ToString, 2), CDate(txtFechaBuscar.Text).Day)
            End If
        End If
        gvVentas.DataSource = MyVentas
        If MyVentas.Rows.Count > 0 Then
            txtFechaBuscar.Text = EvalDato(MyVentas(0).COMPROBANTE_FECHA, "F")
        Else
            txtFechaBuscar.Text = Nothing
        End If
        txtFechaBuscar.Focus()
    End Sub

    Private Sub ImprimirDirecto()
        If gvVentas.Rows.Count <> 0 Then
            Dim VentaSeleccion As String
            MyIndice = 0
            With gvVentas
                VentaSeleccion = .Rows(MyIndice).Cells("VENTA").Value
                MyVenta = New entVenta
                MyVentaDetalles = New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
                MyFacturaDetalles = New dsVentas.VENTAS_SERDataTable
                'MyVentaDatos = New dsVentas.VENTAS_DATOSDataTable

                MyVenta.empresa = "001"
                MyVenta.venta = VentaSeleccion

                txtVenta.Text = VentaSeleccion
                txtAnexo.Text = .Rows(MyIndice).Cells("CUENTA_COMERCIAL").Value
                txtAnexoNombre.Text = .Rows(MyIndice).Cells("RAZON_SOCIAL").Value
                txtComprobanteTipo.Text = .Rows(MyIndice).Cells("COMPROBANTE_TIPO").Value
                txtComprobanteSerie.Text = .Rows(MyIndice).Cells("COMPROBANTE_SERIE").Value
                txtComprobanteNumero.Text = .Rows(MyIndice).Cells("COMPROBANTE_NUMERO").Value
                txtComprobanteFecha.Text = EvalDato(.Rows(MyIndice).Cells("COMPROBANTE_FECHA").Value, "F")
                cmbTipoMoneda.SelectedIndex = IIf(.Rows(MyIndice).Cells("MONEDA").Value = "S/.", 1, 0)
                txtImporteTotalOrigen.Text = EvalDato(.Rows(MyIndice).Cells("MONTO_TOTAL").Value, txtImporteTotalOrigen.Tag)
                txtIGVOrigen.Text = EvalDato(.Rows(MyIndice).Cells("IMPUESTO").Value, txtIGVOrigen.Tag)

                txtTipoCambio.Text = EvalDato(.Rows(MyIndice).Cells("TIPO_CAMBIO").Value, txtTipoCambio.Tag)

                Call EvaluarImpresion()
            End With
        End If
    End Sub

    Private Sub EvaluarImpresion()
        Dim DigestValue As String = ""
        Dim SignatureValue As String = ""
        If txtVenta.Text.Trim <> "" Then
            If DigestValue = "" And SignatureValue = "" Then
                UC_ToolBar.btnImprimir_Visible = False
                UC_ToolBar.btnAceptar_Visible = False
                MyVenta = dalVenta.Obtener(txtVenta.Text.Trim)
                If Not MyVenta.venta Is Nothing Then
                    MyVentaDetalles = dalVenta.BuscarVentaDetalles(MyUsuario.empresa, txtVenta.Text)
                    MyFacturaDetalles = dalVenta.ObtenerVentaServicio(txtVenta.Text)
                    MyEComprobanteFirma = dalVenta.Obtener(MyVenta.empresa, MyVenta.venta)
                    MyComprobanteCliente = dalVenta.ObtenerComprobanteCliente(MyVenta.orden_compra)

                    'Comentar linea de abajo(condición) cuando se quiera volver a generar el xml
                    If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) = False Then
                        If dalXML_Factura.CrearDocumento(MyVenta, MyVentaDetalles, MyFacturaDetalles, txtAnexoNombre.Text, cmbTipoMoneda.Text) = True Then
                            If dalXML_Factura.FirmarDocumento(MyVenta, DigestValue, SignatureValue) = True Then
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
                                dalVenta.Grabar(MyEComprobanteFirma)
                            End If
                        End If
                    End If
                    Call Imprimir_EComprobante()
                End If
                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnAceptar_Visible = True
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

        PorcentajeIGV = MyIGV

        If MyComprobanteCliente.Rows.Count <> 0 Then
            PorcentajeIGV = MyComprobanteCliente(0).PorcentajeIGV
        End If

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

            If MyVenta.comprobante_tipo = "03" Or MyVenta.referencia_tipo = "03" Then
                MyClienteDocumentoTipo = "-"
                MyClienteDocumentoNumero = IIf(txtAnexo.Text = "-", "0", txtAnexo.Text)
                If MyComprobanteCliente.Rows.Count <> 0 Then
                    MyClienteNombre = MyComprobanteCliente(0).NombreCliente
                    MyClienteDomicilio = MyComprobanteCliente(0).Direccion
                Else
                    MyClienteNombre = "CLIENTE VARIOS"
                    MyClienteDomicilio = "-"
                End If
                'If MyVenta.indica_exportacion = "SI" Then Observaciones = "EXPORTACIÓN DE SERVICIOS SEGÚN DECRETO LEGISLATIVO No. 919"
            Else
                If txtAnexo.Text.Trim.Length = 11 Then
                    MyConsultaRUC = dalVenta.ObtenerDatosRUC(txtAnexo.Text)
                Else
                    MyConsultaRUC = New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
                End If
                If MyConsultaRUC.Rows.Count <> 0 Then
                    MyClienteDocumentoTipo = "6"
                    MyClienteDocumentoNumero = MyConsultaRUC(0).RUC
                    'MyClienteNombre = MyConsultaRUC(0).RAZON_SOCIAL.Replace("-", "Ñ")

                    MyClienteDomicilio = MyConsultaRUC(0).DOMICILIO_FISCAL & " " & MyConsultaRUC(0).DISTRITO & " " & MyConsultaRUC(0).PROVINCIA & " " & MyConsultaRUC(0)._REGION
                Else
                    MyClienteDocumentoTipo = "6"
                    MyClienteDocumentoNumero = txtAnexo.Text.Trim
                    If MyComprobanteCliente.Rows.Count <> 0 Then
                        MyClienteNombre = MyComprobanteCliente(0).NombreCliente
                        MyClienteDomicilio = MyComprobanteCliente(0).Direccion
                    Else
                        MyClienteNombre = "CLIENTE DEL EXTERIOR"
                        MyClienteDomicilio = "NO DOMICILIADO"
                    End If
                End If
            End If

            ImporteSoles = Math.Round(IIf(cmbTipoMoneda.SelectedValue = "2", CDec(txtImporteTotalOrigen.Text) * CDec(txtTipoCambio.Text), CDec(txtImporteTotalOrigen.Text)), 2)

            'If MyVenta.condicion_pago = "TG" Then
            '    Observaciones = "TRANSFERENCIA GRATUITA"
            'Else
            '    If MyVenta.indica_exportacion = "NO" Then
            '        If MyAfectoDetraccion = "SI" Then
            '            If ImporteSoles > MyMinimoDetraccion Then
            '                Observaciones = "SUJETA AL PAGO DE DETRACCIONES (" & EvalDato(MyDetraccion, "E") & "%), CTA. CTE. BANCO DE LA NACION N° " & MyCuentaDetraccion
            '            End If
            '        End If
            '    End If
            'End If

            With MyVenta
                NombreArchivo = MyRUC & "-" & .comprobante_tipo & "-" & .comprobante_serie & "-" & .comprobante_numero.Substring(2, 8)

                TextoQR = MyRUC & "|" & .comprobante_tipo & "|" & _
                          .comprobante_serie & "|" & _
                          .comprobante_numero.Substring(2, 8) & "|" & CStr(CDec(txtIGVOrigen.Text)) & "|" & CStr(CDec(txtImporteTotalOrigen.Text)) & "|" & txtComprobanteFecha.Text & "|" & _
                          MyClienteDocumentoTipo & "|" & MyClienteDocumentoNumero & "|" & txtDigestValue.Text & "|" & "" & "|"
            End With

            ImporteTexto = "SON: " & ConvertNumText(CDbl(txtImporteTotalOrigen.Text), cmbTipoMoneda.Text)

            If MyVenta.comprobante_tipo = "03" Then
                Dim MyForm As New frmEBoletaVentaImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR, PorcentajeIGV, PorcentajeServicio)
                MyForm.ShowDialog()
            ElseIf MyVenta.comprobante_tipo = "07" Then
                Dim MyForm As New frmENotaCreditoImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR, PorcentajeIGV, PorcentajeServicio)
                MyForm.ShowDialog()
            ElseIf MyVenta.comprobante_tipo = "08" Then
                Dim MyForm As New frmENotaDebitoImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR, PorcentajeIGV, PorcentajeServicio)
                MyForm.ShowDialog()
            Else
                Dim MyForm As New frmEFacturaImprimir(MyVenta, MyClienteNombre, MyClienteDomicilio, cmbTipoMoneda.Text, Observaciones, NombreArchivo, ImporteTexto, TextoQR, PorcentajeIGV, PorcentajeServicio)
                MyForm.ShowDialog()
            End If

            'If ImpresionCancelada = False Then
            '    Call EnviarComprobanteSUNAT()
            'End If
        End If
    End Sub

    Private Sub EnviarComprobanteSUNAT()
        Dim Nombre_Archivo As String = Nothing
        Dim MyFechaMovimientosDia As String = txtFechaBuscar.Text
        Dim MyEstadoCDR As String
        UC_ToolBar.btnAceptar_Visible = False

        If txtVenta.Text.Trim <> "" Then
            If dalVenta.ExisteEComprobante(MyVenta.empresa, MyVenta.comprobante_serie, MyVenta.comprobante_numero, MyVenta.comprobante_tipo) = True Then
                Resp = MsgBox("El Comprobante Electrónico " & _
                            MyVenta.comprobante_serie & "-" & _
                            MyVenta.comprobante_numero & " ya fué enviado a SUNAT.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "COMPROBANTE SUNAT")
            Else
                Dim strRetorno As String = dalXML_Factura.EnviarDocumento(Nombre_Archivo, MyVenta)
                If strRetorno = "" Then
                    Resp = MsgBox("No existe archivo ZIP a enviar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                Else
                    MyCliente = New entCONCAR_Cliente
                    MyEComprobante = New entEComprobante
                    If strRetorno.Substring(0, 5) = "ERROR" Then
                        Resp = MsgBox(strRetorno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
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
                        dalVenta.GrabarError(MyEComprobante)
                        'CREAR OPCION PARA ENVIAR CORREO A ECOMPROBANTES
                        'dalEmails.EnviarCorreo(MyEComprobante.empresa, MyEComprobante.cuenta_comercial, Nombre_Archivo)
                    Else
                        MyEstadoCDR = dalXML_Factura.ObtenerEstadoCDR(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero)
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

                            MyCliente = dalCliente.Obtener(MyVenta.cuenta_comercial)
                            If MyCliente.adesane.Trim.Length = 0 Then
                                .razon_social = txtAnexoNombre.Text.Trim
                            Else
                                .razon_social = MyCliente.adesane
                                .email_contacto = MyCliente.aemail
                                .email_facturacion = MyCliente.aemail
                            End If

                            .mensaje = Strings.Left(strRetorno, 120)
                            .digest_value = txtDigestValue.Text
                            .signature_value = txtSignatureValue.Text
                            .usuario_registro = Strings.Left(MyUsuario.usuario, 20)
                        End With
                        dalVenta.Grabar(MyEComprobante)
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".xml")
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".zip")
                        dalVenta.CargarEComprobante(Nombre_Archivo & ".pdf")
                        dalVenta.CargarEComprobante("R-" & Nombre_Archivo & ".zip")

                        If strRetorno = "Archivo enviado con éxito." Then
                            dalEmails.EnviarCorreo(MyEComprobante.empresa, MyEComprobante.cuenta_comercial, Nombre_Archivo)
                        End If

                        If dalVenta.ActualizarEstadoEnvio(MyEComprobante.empresa, MyEComprobante.venta, IIf(MyEstadoCDR = "0", "V", "R")) = True Then
                            LimpiarFormulario()
                            txtFechaBuscar.Text = MyFechaMovimientosDia
                            PoblarGrilla()
                        End If
                        UC_ToolBar.btnAceptar_Visible = False

                    End If
                End If
            End If
        End If

        UC_ToolBar.btnAceptar_Visible = False
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_TB_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        UC_ToolBar.btnImprimir_Visible = False
        Call Imprimir_EComprobante()
        UC_ToolBar.btnImprimir_Visible = True
    End Sub

    Private Sub UC_ToolBar_TB_btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Call PoblarGrilla()
        UC_ToolBar.btnAceptar_Visible = False
    End Sub

    Private Sub UC_Toolbar_TB_btAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        UC_ToolBar.btnAceptar_Visible = False
        Call EnviarComprobanteSUNAT()
        UC_ToolBar.btnAceptar_Visible = True
        gvVentas.Focus()
    End Sub

    Private Sub UC_ToolBar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub

    Private Sub UC_ToolBar_TB_btnSUNAT_Click() Handles UC_ToolBar.TB_btnSUNAT_Click
        If cmbComprobanteTipo.SelectedIndex <> -1 And txtComprobanteSerie.Text.Trim.Length <> 0 And txtComprobanteNumero.Text.Trim.Length <> 0 Then
            Call dalXML_Factura.ObtenerEstadoCDR(MyVenta.comprobante_tipo, MyVenta.comprobante_serie, MyVenta.comprobante_numero)
        End If
    End Sub

#End Region

End Class
