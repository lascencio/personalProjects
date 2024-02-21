Public Class frmEstadoCuenta

    Private MyCuentaComercial As New entCuentaComercial
    Private MyPrestamosLista As dsFinanciero.PRESTAMOS_LISTADataTable

    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable
    Private TipoPrestamo As String
    Private FormaPago As String

    Private IndicaHistorico As Boolean = True

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(Prestamo As dsFinanciero.PRESTAMOSDataTable, PrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable, pTipoPrestamo As String, pFormaPago As String, EsHistorico As Boolean)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyPrestamo = Prestamo
        MyPrestamoCuotas = PrestamoCuotas
        TipoPrestamo = pTipoPrestamo
        FormaPago = pFormaPago
        IndicaHistorico = EsHistorico
    End Sub

    Private Sub frmPrestamoEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaGenerica(cmbDocumentoTipo, "_TIPO_DOCUMENTO_IDENTIDAD")
        ActualizarListaEmpresa(cmbTipoPrestamo, "FIN_TIPO_PRESTAMO")
        ActualizarListaEmpresa(cmbFormaPago, "FIN_FORMA_PAGO")
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        cmbDocumentoTipo.SelectedValue = "1"
        cmbEstado.SelectedIndex = 0
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarDocumento()
        End If
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
                If Not MyCuentaComercial.nro_documento Is Nothing Then MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyCuentaComercial.tipo_documento, MyCuentaComercial.nro_documento)
            Else
                MyCuentaComercial = dalFinanciamiento.ObtenerCliente(MyUsuario.empresa, MyDocumentoTipo, MyDocumentoNumero)
                If MyCuentaComercial.nro_documento Is Nothing Then
                    Resp = MsgBox("El documento de identidad ingresado " & MyDocumentoNumero & " no existe.", MsgBoxStyle.Critical, "PROCESO CANCELADO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                End If
            End If

            If Not MyCuentaComercial.nro_documento Is Nothing Then
                MyPrestamosLista = dalFinanciamiento.ObtenerPrestamos(MyCuentaComercial, "V")
                If MyPrestamosLista.Rows.Count = 0 Then
                    Resp = MsgBox("El cliente " & MyCuentaComercial.razon_social.Trim & " no tiene préstamos vigentes.", MsgBoxStyle.Exclamation, "PROCESO CANCELADO")
                    txtDocumentoNumero.Text = Nothing
                    txtDocumentoNumero.Focus()
                Else
                    With MyCuentaComercial
                        cmbDocumentoTipo.SelectedValue = .tipo_documento
                        txtDocumentoNumero.Text = .nro_documento
                        txtRazonSocial.Text = .razon_social.Trim
                        .agencia_registro = "A0000" & MyUsuario.almacen
                    End With
                    cmbPrestamo.Focus()
                End If
            Else
                MyPrestamosLista = New dsFinanciero.PRESTAMOS_LISTADataTable
                txtRazonSocial.Text = Nothing
            End If
            cmbPrestamo.DataSource = MyPrestamosLista
        End If
    End Sub

    Private Sub GenerarReporte()
        Dim MyParams(6) As Microsoft.Reporting.WinForms.ReportParameter
        Dim AgenciaNombre As String = MyAgencia(0).RAZON_SOCIAL
        Dim AgenciaDireccion As String = MyAgencia(0).DOMICILIO
        Dim AgenciaUbigeo As String = MyDomicilioDistrito & " " & MyDomicilioProvincia & " " & MyDomicilioDepartamento
        Dim Sectorista As String = MyUser(0).NOMBRE_COMPLETO

        Dim MyPrestamoCuotasNew As New dsFinanciero.PRESTAMOS_CUOTASDataTable

        If MyPrestamoCuotas.Rows.Count <> 0 Then
            If IndicaHistorico = True Then
                For NFila As Integer = 0 To MyPrestamoCuotas.Rows.Count - 1
                    With MyPrestamoCuotas(NFila)
                        If .FECHA_VENCIMIENTO < MyFechaServidor Then
                            .MORA = .SALDO_CUOTA * MyPrestamo(0).TASA_MOROSIDAD / 100 / 30 * (DateDiff(DateInterval.Day, .FECHA_VENCIMIENTO, MyFechaServidor))
                        End If
                        MyPrestamoCuotasNew.ImportRow(MyPrestamoCuotas(NFila))
                    End With
                Next
            Else
                For NFila As Integer = 0 To MyPrestamoCuotas.Rows.Count - 1
                    With MyPrestamoCuotas(NFila)
                        If .SALDO_CUOTA > 0 Then
                            If .FECHA_VENCIMIENTO < MyFechaServidor Then
                                .MORA = .SALDO_CUOTA * MyPrestamo(0).TASA_MOROSIDAD / 100 / 30 * (DateDiff(DateInterval.Day, .FECHA_VENCIMIENTO, MyFechaServidor))
                            End If
                            MyPrestamoCuotasNew.ImportRow(MyPrestamoCuotas(NFila))
                        End If
                    End With
                Next
            End If
        End If

        Me.rvEstadoCuenta.LocalReport.EnableExternalImages = True

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoPrestamo", TipoPrestamo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pFormaPago", FormaPago, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaNombre", AgenciaNombre, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaDireccion", AgenciaDireccion, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pAgenciaUbigeo", AgenciaUbigeo, False)
        MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pSectorista", Sectorista, False)
        MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pNumeroCuotas", MyPrestamoCuotasNew.Rows.Count, False)

        Me.rvEstadoCuenta.LocalReport.SetParameters(MyParams)

        Me.rvEstadoCuenta.LocalReport.DataSources.Clear()
        Me.rvEstadoCuenta.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsCabecera", DirectCast(MyPrestamo, DataTable)))
        Me.rvEstadoCuenta.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyPrestamoCuotasNew, DataTable)))

        Me.rvEstadoCuenta.DocumentMapCollapsed = True
        Me.rvEstadoCuenta.RefreshReport()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        If txtDocumentoNumero.Text.Trim.Length <> 0 Then
            If cmbPrestamo.SelectedIndex <> -1 Then
                TipoPrestamo = cmbTipoPrestamo.Text
                FormaPago = cmbFormaPago.Text
                MyPrestamoCuotas = dalFinanciamiento.ObtenerPrestamoCuotas(MyUsuario.empresa, cmbPrestamo.SelectedValue)
                Call GenerarReporte()
            End If
        End If
    End Sub

    Private Sub cmbPrestamo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrestamo.SelectedIndexChanged
        If cmbPrestamo.SelectedIndex = -1 Then
            MyPrestamo = New dsFinanciero.PRESTAMOSDataTable
            cmbTipoPrestamo.SelectedIndex = -1
            cmbFormaPago.SelectedIndex = -1
            cmbTipoMoneda.SelectedIndex = -1
        Else
            MyPrestamo = dalFinanciamiento.ObtenerPrestamo(MyUsuario.empresa, cmbPrestamo.SelectedValue)
            cmbTipoPrestamo.SelectedValue = MyPrestamo(0).TIPO_PRESTAMO
            cmbFormaPago.SelectedValue = MyPrestamo(0).FORMA_PAGO
            cmbTipoMoneda.SelectedValue = MyPrestamo(0).TIPO_MONEDA
        End If
    End Sub
End Class