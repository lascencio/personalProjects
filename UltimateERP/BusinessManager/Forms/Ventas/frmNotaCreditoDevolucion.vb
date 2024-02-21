Public Class frmNotaCreditoDevolucion
    Private MyNotaCredito As entVenta
    Private MyReferenciaDetalles As dsVentas.VENTA_DETDataTable
    Private MyReferenciaDetallesSeries As dsVentas.VENTA_DET_SERIESDataTable

    Private MyCuentaComercial As entCuentaComercial

    Private MyAsientoFecha As Date
    Private MyAsientoEjercicio As String
    Private MyAsientoMes As String
    Private MyAsientoDia As String
    Private MyTipoCambio As Decimal

    Private MyReferenciaID As String

    Private MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmNotaCreditoDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmNotaCreditoDevolucion_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        MyAsientoEjercicio = MyUsuario.ejercicio
        MyAsientoMes = Strings.Right("00" & MyUsuario.mes.ToString, 2)
        MyAsientoFecha = EvalDato(dalAsientoContable.ObtenerFecha(Now, MyAsientoEjercicio & MyAsientoMes), "F")

        MyAsientoDia = Strings.Right("00" & MyAsientoFecha.Day.ToString, 2)

        Call LimpiarFormulario()

        If MyTipoCambio = 0 Then MyTipoCambio = 1

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
        UC_ToolBar.btnInformacion_Visible = False

        txtReferenciaSerie.Focus()
    End Sub

    Private Sub cmbReferenciaTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReferenciaTipo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then Call BuscarReferencia()
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
                        Resp = MsgBox("La fecha a registrar no debe ser mayor de hoy.", MsgBoxStyle.Critical, "FECHA INCORRECTA")
                        ReiniciarFecha()
                    Else
                        If MyAsientoFecha.Year * 100 + MyAsientoFecha.Month <> MyFecha.Year * 100 + MyFecha.Month Then
                            Resp = MsgBox("La fecha debe estar dentro del periodo.", MsgBoxStyle.Critical, "FECHA INCORRECTA")
                            Call ReiniciarFecha()
                        Else
                            MyFechaAño = MyFecha.Year.ToString
                            MyFechaMes = Strings.Right("00" & MyFecha.Month.ToString, 2)
                            MyFechaDia = Strings.Right("00" & MyFecha.Day.ToString, 2)
                            UC_ToolBar.btnGrabar_Focus = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyNotaCredito = New entVenta
        MyReferenciaDetalles = New dsVentas.VENTA_DETDataTable
        MyReferenciaDetallesSeries = New dsVentas.VENTA_DET_SERIESDataTable

        MyCuentaComercial = New entCuentaComercial

        MyReferenciaID = Nothing

        InicializarFormulario(Me)

        gvVentaLineas.DataSource = MyReferenciaDetalles

        Call PonerValoresDefault()
        Call ActivarCabecera(False)
        Call ActivarDetalles(True)

        cmbReferenciaTipo.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        MyTipoCambio = dalAsientoContable.ObtenerTipoCambio(MyAsientoEjercicio, MyAsientoMes, MyAsientoDia, "VENTA")
        cmbTipoMoneda.SelectedValue = "1"
        txtComprobanteFecha.Text = EvalDato(Now.Date, "F")

        ckbIndicaAnulado.Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbReferenciaTipo, Not IndicaActivo)
        EnableTextBox(txtReferenciaSerie, Not IndicaActivo)
        EnableTextBox(txtReferenciaNumero, Not IndicaActivo)
    End Sub

    Private Sub ActivarDetalles(ByVal IndicaActivo As Boolean)
        gvVentaLineas.Enabled = IndicaActivo
    End Sub

    Private Sub BuscarReferencia()
        If cmbReferenciaTipo.SelectedIndex <> -1 And txtReferenciaSerie.Text.Trim.Length <> 0 And txtReferenciaNumero.Text.Trim.Length <> 0 Then
            Dim MyReferenciaTipo As String = IIf(cmbReferenciaTipo.SelectedIndex = 0, "01", "03")
            Dim MyReferenciaSerie As String = txtReferenciaSerie.Text.Trim
            Dim MyReferenciaNumero As String = txtReferenciaNumero.Text.Trim

            MyNotaCredito = dalVenta.Obtener(MyReferenciaTipo, MyReferenciaSerie, MyReferenciaNumero)
            If Not MyNotaCredito.venta Is Nothing Then
                MyReferenciaID = MyNotaCredito.venta

                MyReferenciaDetalles = dalVenta.ObtenerDetalles(MyUsuario.empresa, MyReferenciaTipo, MyReferenciaSerie, MyReferenciaNumero)
                MyReferenciaDetallesSeries = dalVenta.ObtenerDetalleSeries(MyUsuario.empresa, MyReferenciaID)
                Call EvaluarExisteResumen()

                txtReferenciaFecha.Text = MyNotaCredito.comprobante_fecha
                MyCuentaComercial = dalCuentaComercial.Obtener(MyNotaCredito.empresa, MyNotaCredito.cuenta_comercial)
                txtRazonSocial.Text = MyCuentaComercial.razon_social
                cmbTipoMoneda.SelectedValue = MyNotaCredito.tipo_moneda
                txtComprobanteSerie.Text = IIf(cmbReferenciaTipo.Text.Substring(0, 1) = "B", "BN", "FN") & MyNotaCredito.comprobante_serie.Substring(2, 2)
                txtImporteTotal.Text = EvalDato(MyNotaCredito.importe_total_origen, txtImporteTotal.Tag)

                With MyNotaCredito
                    .venta = Nothing
                    .tipo_operacion = "C1"

                    .referencia_fecha = .comprobante_fecha
                    .referencia_tipo = .comprobante_tipo
                    .referencia_serie = .comprobante_serie
                    .referencia_numero = .comprobante_numero

                    .comprobante_fecha = txtComprobanteFecha.Text
                    .comprobante_vencimiento = txtComprobanteFecha.Text
                    .comprobante_tipo = "07"
                    .comprobante_serie = txtComprobanteSerie.Text
                    .comprobante_numero = "0000000000"

                    .usuario_envio = Space(1)
                    .fecha_envio = FechaNulo
                    .estado_envio = "P"
                    .indica_migrado = "NO"
                    .comentario = txtComentario.Text
                End With

                Call ActivarCabecera(True)
                If txtNotaCredito.Text.Trim.Length = 0 Then txtComprobanteFecha.Focus()
                gvVentaLineas.DataSource = MyReferenciaDetalles
                txtComentario.Focus()
            Else
                Resp = MsgBox("El comprobante " & MyReferenciaSerie & "-" & MyReferenciaNumero & " no existe.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "PROCESO DENEGADO")
                Call LimpiarFormulario()
            End If
        End If
    End Sub

    Private Sub EvaluarExisteResumen()
        Dim MyProductoComponentesNew As dsProductos.PRODUCTO_COMPONENTESDataTable
        Dim CodigoProducto As String
        If MyReferenciaDetalles.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyReferenciaDetalles.Rows.Count - 1
                CodigoProducto = MyReferenciaDetalles(NEle).PRODUCTO

                If MyReferenciaDetalles(NEle).INDICA_COMPUESTO = "SI" Then
                    MyProductoComponentesNew = dalProducto.ObtenerProductoComponentes(MyUsuario.empresa, CodigoProducto)
                    If MyProductoComponentesNew.Rows.Count <> 0 Then
                        For NFila As Integer = 0 To MyProductoComponentesNew.Rows.Count - 1
                            If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(MyNotaCredito.almacen, "0000000000", MyProductoComponentesNew(NFila).PRODUCTO) Then
                                MyProductoComponentesNew(NFila).EXISTE_RESUMEN_ALMACEN = "SI"
                            End If
                            If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(MyUsuario.ejercicio, MyUsuario.mes.ToString("00"), MyNotaCredito.almacen, "0000000000", MyProductoComponentesNew(NFila).PRODUCTO) Then
                                MyProductoComponentesNew(NFila).EXISTE_RESUMEN_PERIODO = "SI"
                            End If
                            MyProductoComponentes.ImportRow(MyProductoComponentesNew(NFila))
                        Next
                    End If
                Else
                    If dalOrdenPedido.EvaluarSiExisteResumenAlmacen(MyNotaCredito.almacen, "0000000000", MyReferenciaDetalles(NEle).PRODUCTO) Then
                        MyReferenciaDetalles(NEle).EXISTE_RESUMEN_ALMACEN = "SI"
                    Else
                        MyReferenciaDetalles(NEle).EXISTE_RESUMEN_ALMACEN = "NO"
                    End If

                    If dalOrdenPedido.EvaluarSiExisteResumenPeriodo(MyUsuario.ejercicio, MyUsuario.mes.ToString("00"), MyNotaCredito.almacen, "0000000000", MyReferenciaDetalles(NEle).PRODUCTO) Then
                        MyReferenciaDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI"
                    Else
                        MyReferenciaDetalles(NEle).EXISTE_RESUMEN_PERIODO = "NO"
                    End If
                End If
            Next

            If MyReferenciaDetallesSeries.Rows.Count <> 0 Then
                For NFil As Integer = 0 To MyReferenciaDetallesSeries.Rows.Count - 1
                    If dalControlSeries.EvaluarSiExisteControlSeries(MyReferenciaDetallesSeries(NFil).PRODUCTO, MyReferenciaDetallesSeries(NFil).NUMERO_SERIE) Then
                        MyReferenciaDetallesSeries(NFil).EXISTE_CONTROL_SERIES = "SI"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ReiniciarFecha()
        txtComprobanteFecha.Text = Nothing
        txtComprobanteFecha.Focus()
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
        If txtNotaCredito.Text.Trim.Length = 0 Then
            UC_ToolBar.btnAceptar_Visible = False
            MyNotaCredito = dalVenta.GrabarNotaCredito(MyReferenciaID, MyNotaCredito, MyReferenciaDetalles, MyReferenciaDetallesSeries)
            txtNotaCredito.Text = MyNotaCredito.venta
            txtComprobanteNumero.Text = MyNotaCredito.comprobante_numero
            Resp = MsgBox("La Nota de Crédito se grabó con éxito.", MsgBoxStyle.Information, "GRABAR COMPROBANTE")
            ActivarDetalles(False)
            UC_ToolBar.btnImprimir_Focus = True
        End If
    End Sub

    Private Sub UC_ToolBar_btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If txtNotaCredito.Text.Trim.Length <> 0 Then
            Try
                UC_ToolBar.btnGrabar_Visible = False
                If txtNotaCredito.Text.Trim.Length <> 0 And ckbIndicaAnulado.Checked = True Then
                    Resp = MsgBox("Confirmar proceso de anulación de la Nota de Crédito.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "ANULAR COMPROBANTE")
                    If Resp = 1 Then
                        If dalVenta.AnularNotaCredito(MyNotaCredito, MyReferenciaDetalles, MyReferenciaDetallesSeries) = True Then
                            Resp = MsgBox("La Nota de Crédito se anuló con éxito.", MsgBoxStyle.Information, "ANULAR COMPROBANTE")
                            Call LimpiarFormulario()
                        Else
                            ckbIndicaAnulado.Checked = False
                            UC_ToolBar.btnGrabar_Visible = True
                        End If
                    Else
                        ckbIndicaAnulado.Checked = False
                        UC_ToolBar.btnGrabar_Visible = True
                    End If
                End If
                UC_ToolBar.btnEditar_Focus = True
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End If
    End Sub

#End Region




End Class
