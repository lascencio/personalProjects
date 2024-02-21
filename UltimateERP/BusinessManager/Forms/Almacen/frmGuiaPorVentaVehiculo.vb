Public Class frmGuiaPorVentaVehiculo

    Private MyCuentaComercial As entCuentaComercial
    Private MyDireccionEnvio As dsCuentasComerciales.DIRECCION_ENVIODataTable

    Private MyVenta As entVenta
    Private MyVentaDetalle As dsVentas.VENTA_DETDataTable
    Private MyVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable
    Private MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable

    Private MyGuia As entGuia

    Private MyProducto As entProducto

    Private MyAsientoTipo As String = "00"
    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String

    Private MySender As String

    Private FechaUltimoComprobante As Date

    Private MotivoTrasladoDescripcion As String = "VENTA"
    Private TipoOperacion As String = "G4" ' G2 Translado entre almacenes, G4 - Venta Vehicular, G5 - Venta Directa

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmGuiaPorVentaVehiculo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmGuiaPorVentaVehiculo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbAlmacen.DataSource = MyDTAlmacenes

        ActualizarListaEmpresa(cmbComprobanteSerie, "STD_SERIES_GUIAS")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = MyUsuario.mes.ToString("00")
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")
        MyAsientoDia = MyAsientoFecha.Day.ToString("00")

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
                        txtConductorDNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtComentario_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        UC_ToolBar.btnGrabar_Focus = True
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

    Private Sub obtIndicaTransportePublico_CheckedChanged(sender As Object, e As EventArgs) Handles obtIndicaTransportePublico.CheckedChanged
        If obtIndicaTransportePublico.Checked = True Then Call EvaluarTipoTransporte() : txtTransportistaRUC.Focus()
    End Sub

    Private Sub obtIndicaTransportePrivado_CheckedChanged(sender As Object, e As EventArgs) Handles obtIndicaTransportePrivado.CheckedChanged
        If obtIndicaTransportePrivado.Checked = True Then Call EvaluarTipoTransporte() : txtConductorDNI.Focus()
    End Sub

    Private Sub txtConductorDNI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConductorDNI.KeyDown
        Dim MyElemento As New dsTablasGenericas.LISTADataTable
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCodigo = sender.Text.Trim

            If MyCodigo.Trim.Length = 0 Then
                Dim MyForm As New frmElementoLista(MyElemento, "COM_TRANSPORTE_PRIVADO", "TRANSPORTE PRIVADO")
                MyForm.ShowDialog()
                If MyElemento.Rows.Count <> 0 Then
                    txtConductorDNI.Text = MyElemento(0).CODIGO
                    txtConductorNombre.Text = MyElemento(0).DESCRIPCION_AMPLIADA
                    txtNumeroPlaca.Text = MyElemento(0).REFERENCIA
                    txtNumeroPlaca.Focus()
                End If
            Else
                txtConductorNombre.Focus()
            End If
        End If
    End Sub

    Private Sub txtTransportistaRUC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportistaRUC.KeyDown
        Dim MyElemento As New dsTablasGenericas.LISTADataTable
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyCodigo = sender.Text.Trim

            If MyCodigo.Trim.Length = 0 Then
                Dim MyForm As New frmElementoLista(MyElemento, "COM_TRANSPORTE_PUBLICO", "TRANSPORTE PUBLICO")
                MyForm.ShowDialog()
                If MyElemento.Rows.Count <> 0 Then
                    txtTransportistaRUC.Text = MyElemento(0).CODIGO
                    txtTransportistaRazonSocial.Text = MyElemento(0).DESCRIPCION_AMPLIADA
                    txtComentario.Focus()
                End If
            Else
                txtTransportistaRazonSocial.Focus()
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial
        MyDireccionEnvio = New dsCuentasComerciales.DIRECCION_ENVIODataTable

        MyVenta = New entVenta
        MyVentaDetalle = New dsVentas.VENTA_DETDataTable
        MyVentaDetalleSeries = New dsVentas.VENTA_DET_SERIESDataTable
        MyVentaVehiculo = New dsVentas.VENTAS_VEHICULOSDataTable

        MyGuia = New entGuia
        MyProducto = New entProducto

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarDetalles(True)
        Call ActivarCabecera(True)

        EnableTextBox(txtComprobante, True)
        txtComprobante.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")
        txtComprobanteFechaTraslado.Text = EvalDato(Now.Date, "F")
        ckbIndicaAnulado.Visible = False
        obtIndicaTransportePrivado.Checked = True
        cmbAlmacen.SelectedValue = MyUsuario.almacen
        txtComprobanteNumero.Text = Strings.Right(CUO_Nulo, txtComprobanteNumero.MaxLength)
        cmbComprobanteSerie.SelectedIndex = CInt(MyUsuario.serie_asignada) - 1

        Call PoblarCorrelativo()

        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnGrabar_Visible = False
    End Sub

    Private Sub PoblarCorrelativo()
        AsignarNumeroComprobante(cmbComprobanteSerie, txtComprobanteNumero, FechaUltimoComprobante)
    End Sub

    Private Sub PoblarFormulario()
        Dim Comprobante As String
        Dim Guia As String = MyGuia.guia
        Call LimpiarFormulario()
        MyGuia = dalGuia.ObtenerCabecera(Guia)
        If Not MyGuia.guia Is Nothing Then
            With MyGuia
                txtGuia.Text = .guia
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                txtVenta.Text = .venta
                MyVenta = dalVenta.Obtener(.venta)
                Comprobante = MyVenta.comprobante_serie & "-" & MyVenta.comprobante_numero
                txtComprobante.Text = Comprobante


                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)
                txtRazonSocial.Text = MyCuentaComercial.razon_social

                Call ActualizarDomicilioEnvio()
                cmbDomicilioEnvio.SelectedValue = MyGuia.domicilio_envio

                If .indica_transporte_publico = "SI" Then
                    obtIndicaTransportePublico.Checked = True
                    txtTransportistaRUC.Text = .transportista_ruc
                    txtTransportistaRazonSocial.Text = .transportista_razon_social
                Else
                    obtIndicaTransportePrivado.Checked = True
                    txtConductorDNI.Text = .conductor_dni
                    txtConductorNombre.Text = .conductor_nombre
                    txtNumeroPlaca.Text = .numero_placa
                End If

                cmbComprobanteSerie.SelectedValue = .comprobante_serie
                txtComprobanteNumero.Text = .comprobante_numero
                txtComprobanteFecha.Text = EvalDato(.comprobante_fecha, "F")
                txtComprobanteFechaTraslado.Text = EvalDato(.comprobante_fecha_traslado, "F")
                cmbAlmacen.SelectedValue = .almacen

                txtComentario.Text = .comentario

                EnableTextBox(txtComprobante, False)

                Call ActivarCabecera(False)

                '' Solo es posible modificar si se cumple que:
                '' 1.- La fecha del movimiento se encuentra dentro del periodo que se generó
                '' 2.- El movimiento no se encuentra anulado
                '' 3.- Para la Forma de Pago diferente a EF: Efectivo, que el valor del campo IMPORTE_SALDO sea igual al del campo IMPORTE_TOTAL_ORIGEN
                '' 4.- Si no ha sido enviado a SUNAT

                'ckbIndicaAnulado.Visible = True

                'If .estado = "N" Then
                '    ckbIndicaAnulado.Checked = True
                '    ckbIndicaAnulado.Enabled = False
                'Else
                '    ckbIndicaAnulado.Checked = False
                '    ckbIndicaAnulado.Enabled = True
                'End If

                If .estado_envio = "P" Then UC_ToolBar.btnSUNAT_Visible = True

                UC_ToolBar.btnImprimir_Visible = True
                UC_ToolBar.btnAceptar_Visible = False
                'UC_ToolBar.btnGrabar_Visible = True
                UC_ToolBar.btnNuevo_Focus = True
            End With

            MyVentaVehiculo = dalVenta.ObtenerVentaVehiculo(MyUsuario.empresa, MyVenta.venta)

            With MyVentaVehiculo(0)
                MyProducto = dalProducto.Obtener(MyUsuario.empresa, .PRODUCTO)
                txtProducto.Text = MyProducto.producto
                txtProductoDescripcion.Text = MyProducto.descripcion_ampliada

                txtVehiculoMarca.Text = .MARCA
                txtVehiculoModelo.Text = .MODELO
                txtNumeroSerie.Text = .NUMERO_SERIE
                txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                txtColor.Text = .COLOR
            End With
        End If
    End Sub

    Private Sub PoblarVenta()
        Dim Comprobante As String
        Dim Venta As String = MyVenta.venta
        Call LimpiarFormulario()
        MyVenta = dalVenta.Obtener(Venta)
        If Not MyVenta.venta Is Nothing Then
            With MyVenta
                txtVenta.Text = .venta
                txtEjercicio.Text = .ejercicio
                txtMes.Text = .mes

                Comprobante = .comprobante_serie & "-" & .comprobante_numero
                MyCuentaComercial = dalCuentaComercial.Obtener(.empresa, .cuenta_comercial)
                txtComprobante.Text = Comprobante
                txtRazonSocial.Text = MyCuentaComercial.razon_social

                Call ActualizarDomicilioEnvio()
                cmbDomicilioEnvio.SelectedValue = MyCuentaComercial.domicilio_envio

                MyVentaDetalle = dalVenta.ObtenerDetalles(MyUsuario.empresa, txtVenta.Text)
                MyVentaDetalleSeries = dalVenta.ObtenerDetalleSeries(MyUsuario.empresa, txtVenta.Text)

                txtProducto.Text = MyVentaDetalle(0).PRODUCTO
                txtProductoDescripcion.Text = MyVentaDetalle(0).DESCRIPCION_AMPLIADA

                cmbAlmacen.SelectedValue = .almacen

                MyVentaVehiculo = dalVenta.ObtenerVentaVehiculo(MyUsuario.empresa, MyVenta.venta)

                With MyVentaVehiculo(0)
                    txtVehiculoMarca.Text = .MARCA
                    txtVehiculoModelo.Text = .MODELO
                    txtNumeroSerie.Text = .NUMERO_SERIE
                    txtNumeroSerieChasis.Text = .NUMERO_SERIE_CHASIS
                    txtColor.Text = .COLOR
                End With

                txtComprobanteFechaTraslado.Focus()
            End With
        End If
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableTextBox(txtComprobanteFecha, IndicaActivo)
        EnableTextBox(txtComprobanteFechaTraslado, IndicaActivo)

        EnableComboBox(cmbDomicilioEnvio, IndicaActivo)
        EnableTextBox(txtConductorDNI, IndicaActivo)
        EnableTextBox(txtConductorNombre, IndicaActivo)
        EnableTextBox(txtNumeroPlaca, IndicaActivo)
        EnableTextBox(txtComentario, IndicaActivo)
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        'EnableTextBox(txtVehiculoMarca, IndicaActivo)
        'EnableTextBox(txtVehiculoModelo, IndicaActivo)
        'EnableTextBox(txtNumeroSerie, IndicaActivo)
        'EnableTextBox(txtNumeroSerieChasis, IndicaActivo)
        'EnableTextBox(txtColor, IndicaActivo)
    End Sub

    Private Function CapturarEncabezadoGuia() As Boolean
        Dim MyMensaje As String = ""

        If obtIndicaTransportePublico.Checked = True Then
            If txtTransportistaRazonSocial.Text.Trim.Length = 0 Then MyMensaje = "RAZON SOCIAL DEL TRANSPORTISTA"
            If txtTransportistaRUC.Text.Trim.Length = 0 Then MyMensaje = "RUC"
        Else
            If txtConductorNombre.Text.Trim.Length = 0 Then MyMensaje = "NOMBRE DEL CONDUCTOR"
            If txtConductorDNI.Text.Trim.Length = 0 Then MyMensaje = "DNI"
        End If

        If cmbDomicilioEnvio.SelectedIndex = -1 Then MyMensaje = "PUNTO DE LLEGADA"
        If txtComprobanteFechaTraslado.Text.Trim.Length = 0 Then MyMensaje = "FECHA DE TRASLADO"
        If txtComprobanteFecha.Text.Trim.Length = 0 Then MyMensaje = "FECHA DE EMISION"
        If cmbComprobanteSerie.SelectedIndex = -1 Then MyMensaje = "SERIE"

        If MyMensaje <> "" Then
            Resp = MsgBox("Debe registrar el valor del campo " & MyMensaje, MsgBoxStyle.Information, "PROCESO CANCELADO")
            Return False
        Else
            With MyGuia
                .empresa = MyUsuario.empresa
                .guia = txtGuia.Text
                .ejercicio = MyAsientoEjercicio
                .mes = MyAsientoMes
                .tipo_operacion = TipoOperacion
                .cuenta_comercial = MyCuentaComercial.cuenta_comercial
                .venta = txtVenta.Text
                .comprobante_tipo = "09"
                .comprobante_serie = cmbComprobanteSerie.SelectedValue
                .comprobante_numero = txtComprobanteNumero.Text
                If txtComprobanteFecha.Text.Length <> 0 Then .comprobante_fecha = txtComprobanteFecha.Text
                If txtComprobanteFechaTraslado.Text.Length <> 0 Then .comprobante_fecha_traslado = txtComprobanteFechaTraslado.Text
                .almacen = cmbAlmacen.SelectedValue
                .domicilio_envio = cmbDomicilioEnvio.SelectedValue
                .motivo_traslado = "01" ' 01 - Venta, 04 - Traslado entre almacenes, 13 - Otros 
                .punto_partida = MyDomicilioFiscal & " " & MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento
                .punto_llegada = cmbDomicilioEnvio.Text
                .destinatario_tipo_documento = MyCuentaComercial.tipo_documento
                .destinatario_nro_documento = MyCuentaComercial.nro_documento
                .destinatario_razon_social = MyCuentaComercial.razon_social
                .conductor_dni = txtConductorDNI.Text
                .conductor_nombre = txtConductorNombre.Text
                .numero_placa = txtNumeroPlaca.Text
                .transportista_ruc = txtTransportistaRUC.Text
                .transportista_razon_social = txtTransportistaRazonSocial.Text
                .comentario = IIf(txtComentario.Text.Trim.Length = 0, "VENTA VEHICULAR", txtComentario.Text.Trim)
                .indica_transporte_publico = IIf(obtIndicaTransportePublico.Checked = True, "SI", "NO")
                .estado = IIf(ckbIndicaAnulado.Checked = True, "N", "A")
                .usuario_registro = MyUsuario.usuario
                .usuario_modifica = MyUsuario.usuario
            End With
            Return True
        End If
    End Function

    Private Sub ActualizarDomicilioEnvio()
        MyDireccionEnvio = dalCuentaComercial.ObtenerDomicilioEnvio(MyCuentaComercial.empresa, MyCuentaComercial.cuenta_comercial)
        cmbDomicilioEnvio.DataSource = MyDireccionEnvio
    End Sub

    Private Sub EvaluarTipoTransporte()
        EnableTextBox(txtConductorDNI, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtConductorNombre, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtNumeroPlaca, obtIndicaTransportePrivado.Checked)
        EnableTextBox(txtTransportistaRUC, obtIndicaTransportePublico.Checked)
        EnableTextBox(txtTransportistaRazonSocial, obtIndicaTransportePublico.Checked)

        If obtIndicaTransportePrivado.Checked = True Then
            txtTransportistaRUC.Text = Nothing
            txtTransportistaRazonSocial.Text = Nothing
        Else
            txtConductorDNI.Text = Nothing
            txtConductorNombre.Text = Nothing
            txtNumeroPlaca.Text = Nothing
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Try
            If CapturarEncabezadoGuia() = True Then
                UC_ToolBar.btnAceptar_Visible = False

                If txtVenta.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = False Then
                    MyGuia = dalGuia.GrabarGuiaPorVentaDirecta(MyGuia, MyVentaDetalle, MyVentaDetalleSeries)
                    txtGuia.Text = MyGuia.guia

                    Resp = MsgBox("La Guia de Remisión se grabó con éxito.", MsgBoxStyle.Information, "GUIA DE REMISION POR VENTA")
                    Call ActivarCabecera(False)
                    Call ActivarDetalles(False)
                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnSUNAT_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                End If
            End If
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

    Private Sub UC_ToolBar_btnSUNAT_Click() Handles UC_ToolBar.TB_btnSUNAT_Click
        Dim Nombre_Archivo As String = Nothing
        Dim CodigoError As String = ""
        Try
            If txtGuia.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = False Then
                MyGuia.tipo_operacion_nombre = MotivoTrasladoDescripcion
                MyGuia.ubigeo_origen = MyDomicilioUbigeo ' Viene y se define en frmLogin
                MyGuia.ubigeo_destino = MyCuentaComercial.ubigeo
                If dalXML.CrearGuia(MyGuia) = True Then
                    If dalXML.FirmarGuia(MyGuia) = True Then
                        If Servidor = "Desarrollo" Then
                            If dalGuia.ActualizarEstadoEnvio(MyUsuario.empresa, MyGuia.guia, "A") = True Then
                                Resp = MsgBox("El documento ha sido creado satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                Call LimpiarFormulario()
                            End If
                        Else
                            Dim strRetorno As String = dalXML.EnviarGuia(Nombre_Archivo, MyGuia)
                            If strRetorno = "" Then
                                Resp = MsgBox("No existe archivo ZIP a enviar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                            Else
                                If strRetorno.Substring(0, 5) = "ERROR" Then
                                    CodigoError = Strings.Right(strRetorno, 4)
                                    If CodigoError = "4000" Then
                                        Resp = MsgBox("El documento ya fue presentado anteriormente." & vbCrLf &
                                                      MyGuia.fecha_envio.ToLongDateString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                    Else
                                        Resp = MsgBox(strRetorno, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ESTADO DEL ENVIO")
                                    End If
                                Else
                                    If dalGuia.ActualizarEstadoEnvio(MyUsuario.empresa, MyGuia.guia, "A") = True Then
                                        Resp = MsgBox(strRetorno, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ENVIAR GUIA A SUNAT")
                                    End If
                                End If
                                Call LimpiarFormulario()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtGuia.Text.Trim <> "" Then
            If txtGuia.Text.Trim.Length <> 0 Then
                MyGuia.referencia = txtComprobante.Text
                Dim MyForm As New frmGuiaRemitenteImprimir(MyGuia, MotivoTrasladoDescripcion)
                MyForm.ShowDialog()
            End If
        End If
    End Sub

#End Region

End Class
