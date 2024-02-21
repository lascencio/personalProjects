Public Class frmCobranzaGastos

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable
    Private MyCuentaComercial As New entCuentaComercial

    Private MyCobranza As dsFinanciero.COBRANZASDataTable
    Private MyCobranzaDetalles As dsFinanciero.COBRANZAS_DETALLESDataTable

    Private ActualizarCombos As Boolean
    Private SaltarSiguiente As Boolean = True

    Private Sub frmCobranzaGastos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If SaltarSiguiente Then SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCobranzaGastos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        Call LimpiarFormulario()

        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnInformacion_Visible = False
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
    End Sub

    Private Sub cmbPrestamo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrestamo.SelectedIndexChanged
        If sender.SelectedIndex <> -1 Then
            Call PoblarPrestamo(sender.SelectedValue)
            txtImporte.Focus()
        End If
    End Sub

    Private Sub ValidarDatos(sender As Object, e As EventArgs) Handles txtImporte.Validated
        sender.Text = EvalDato(sender.Text, sender.Tag)

        If sender.Name = "txtImporte" Then
            If CDec(sender.Text) <> 0 Then txtGlosa.Focus()
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyCuentaComercial = New entCuentaComercial

        MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoCuotasLista = New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable

        MyCobranza = New dsFinanciero.COBRANZASDataTable
        MyCobranzaDetalles = New dsFinanciero.COBRANZAS_DETALLESDataTable

        InicializarFormulario(Me)

        Call PonerValoresDefault()
        Call ActivarCabecera(True)

        txtDocumentoNumero.Focus()
    End Sub

    Private Sub PonerValoresDefault()
        ActualizarCombos = False

        txtEjercicio.Text = MyUsuario.ejercicio
        txtMes.Text = MyUsuario.mes.ToString("00")

        txtCuentaComercial.Text = "00000000"

        cmbTipoMoneda.SelectedValue = "1"
        txtFechaEmision.Text = EvalDato(MyFechaServidor, "F")
        cmbDocumentoTipo.SelectedValue = "1"

        ActualizarCombos = True

        EnableComboBox(cmbPrestamo, True)

        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnAceptar_Visible = True
    End Sub

    Private Sub ActivarCabecera(ByVal IndicaActivo As Boolean)
        EnableComboBox(cmbDocumentoTipo, IndicaActivo)
        EnableTextBox(txtDocumentoNumero, IndicaActivo)
        EnableTextBox(txtImporte, IndicaActivo)
        EnableTextBox(txtGlosa, IndicaActivo)

    End Sub

    Private Sub ValidarDocumento()
        If cmbDocumentoTipo.SelectedIndex <> -1 Then
            Dim MyDocumentoTipo As String = cmbDocumentoTipo.SelectedValue
            Dim MyDocumentoNumero As String = txtDocumentoNumero.Text.Trim
            Dim MyCliente As String = ""
            MyCuentaComercial = New entCuentaComercial
            If String.IsNullOrEmpty(MyDocumentoNumero) Then
                Dim MyForm As New frmClientesLista(MyCuentaComercial)
                MyForm.ShowDialog()
                If Not MyCuentaComercial.cuenta_comercial Is Nothing Then MyCuentaComercial = dalCuentaComercial.Obtener(MyUsuario.empresa, MyCuentaComercial.cuenta_comercial)
            Else
                MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                EnableComboBox(cmbDocumentoTipo, False)
                EnableTextBox(txtDocumentoNumero, False)

                With MyCuentaComercial
                    cmbDocumentoTipo.SelectedValue = .tipo_documento
                    txtDocumentoNumero.Text = .nro_documento
                    txtRazonSocial.Text = .razon_social
                    .agencia_registro = "A0000" & MyUsuario.almacen
                End With
                MyPrestamosLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "V")
            Else
                MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable
                txtRazonSocial.Text = Nothing
            End If
            cmbPrestamo.DataSource = MyPrestamosLista
            cmbPrestamo.Focus()
        End If
    End Sub

    Private Sub PoblarFormulario()
        Dim TotalCuotas As Decimal = 0
        ActivarCabecera(False)
        MyCobranza = dalFinanciamiento.ObtenerCobranza(MyUsuario.empresa, MyCobranza(0).COBRANZA)
        MyCobranzaDetalles = dalFinanciamiento.ObtenerCobranzaDetalles(MyUsuario.empresa, MyCobranza(0).COBRANZA)

        With MyCobranza(0)
            txtCobranza.Text = .COBRANZA
            txtFechaEmision.Text = EvalDato(.FECHA, txtFechaEmision.Tag)
            txtGlosa.Text = .GLOSA
        End With

        Call PoblarPrestamo(MyCobranza(0).PRESTAMO)

        If MyCobranzaDetalles.Rows.Count <> 0 Then
            For NFila As Integer = 0 To MyCobranzaDetalles.Rows.Count - 1
                TotalCuotas = TotalCuotas + MyCobranzaDetalles(NFila).CUOTA_PAGO
            Next
        End If

        txtImporte.Text = EvalDato(TotalCuotas, txtImporte.Tag)

        MyPrestamosLista = dalFinanciamiento.ObtenerPrestamo(MyCobranza)
        MyPrestamoCuotasLista = dalFinanciamiento.ObtenerCobranzas(MyUsuario.empresa, MyCobranza(0).COBRANZA)

        cmbPrestamo.DataSource = MyPrestamosLista
        cmbPrestamo.SelectedValue = MyCobranza(0).PRESTAMO

        EnableComboBox(cmbPrestamo, False)

        UC_ToolBar.btnImprimir_Visible = True
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnImprimir_Focus = True
    End Sub

    Private Sub PoblarPrestamo(Prestamo As String)
        MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, Prestamo)

        With MyPrestamo(0)
            txtPrestamo.Text = .PRESTAMO
            cmbDocumentoTipo.SelectedValue = .TIPO_DOCUMENTO
            txtDocumentoNumero.Text = .NRO_DOCUMENTO
            txtRazonSocial.Text = .RAZON_SOCIAL
            cmbTipoMoneda.SelectedValue = .TIPO_MONEDA
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

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim ImportePagar As Decimal = CDec(txtImporte.Text)
        Dim Glosa As String = txtGlosa.Text.Trim

        If ImportePagar = 0 Then
            Resp = MsgBox("Debe registrar el importe a pagar.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            txtImporte.Focus()
        ElseIf Glosa.Length = 0 Then
            Resp = MsgBox("Debe registrar la glosa de la operacion.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
            txtGlosa.Focus()
        Else
            Try
                UC_ToolBar.btnAceptar_Visible = False

                MyCobranza = dalFinanciamiento.ObtenerCobranzaNueva

                With MyCobranza(0)
                    .EMPRESA = MyUsuario.empresa
                    .PRESTAMO = MyPrestamo(0).PRESTAMO
                    .EJERCICIO = MyUsuario.ejercicio
                    .MES = MyUsuario.mes.ToString("00")
                    .TIPO = "GA"
                    .IMPORTE = ImportePagar
                    .GLOSA = Glosa
                    .FECHA = MyFechaServidor
                    .AGENCIA_REGISTRO = MyAgencia(0).AGENCIA
                    .USUARIO_REGISTRO = MyUsuario.usuario
                End With

                MyCobranza = dalFinanciamiento.GrabarCobranza(MyPrestamo, MyPrestamoCuotasLista, MyCobranza)
                If MyCobranza(0).COBRANZA.Trim.Length <> 0 Then
                    txtCobranza.Text = MyCobranza(0).COBRANZA
                    Call ActivarCabecera(False)
                    Resp = MsgBox("La Cobranza se grabó con éxito.", MsgBoxStyle.Information, "REGISTRAR COBRANZA")

                    MyPrestamoCuotasLista = dalFinanciamiento.ObtenerCobranzas(MyUsuario.empresa, MyCobranza(0).COBRANZA)
                    EnableComboBox(cmbPrestamo, False)

                    UC_ToolBar.btnImprimir_Visible = True
                    UC_ToolBar.btnImprimir_Focus = True
                Else
                    UC_ToolBar.btnAceptar_Visible = True
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If

    End Sub

    Private Sub UC_ToolBar_btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click
        If txtCobranza.Text.Trim.Length <> 0 Then
            Dim MyForm As New frmTicketCobranzaImprimir(txtCobranza.Text, txtRazonSocial.Text, cmbTipoMoneda.Text, True)
            MyForm.ShowDialog()
        End If
    End Sub

    Private Sub UC_ToolBar_btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        Dim MyCobranzaNew As New dsFinanciero.COBRANZASDataTable
        MyCobranzaNew = dalFinanciamiento.ObtenerCobranzaNueva()

        Dim MyForm As New frmCobranzasLista(MyCobranzaNew, txtEjercicio.Text, txtMes.Text, "GA")
        MyForm.ShowDialog()
        If MyCobranzaNew(0).COBRANZA.Trim.Length <> 0 Then
            LimpiarFormulario()
            MyCobranza = MyCobranzaNew
            Call PoblarFormulario()
        End If
    End Sub

    Private Sub btnBuscarPrestamo_Click(sender As Object, e As EventArgs) Handles btnBuscarPrestamo.Click
        Dim MyPrestamoNew As New dsFinanciero.PRESTAMOSDataTable
        MyPrestamoNew = dalFinanciamiento.ObtenerPrestamoNuevo()

        Dim MyForm As New frmPrestamosLista(MyPrestamoNew, txtEjercicio.Text, txtMes.Text)
        MyForm.ShowDialog()
        If MyPrestamoNew(0).PRESTAMO.Trim.Length <> 0 Then
            Call PoblarPrestamo(MyPrestamoNew(0).PRESTAMO)
            Call ValidarDocumento()
        Else
            txtDocumentoNumero.Focus()
        End If
    End Sub

#End Region

End Class
