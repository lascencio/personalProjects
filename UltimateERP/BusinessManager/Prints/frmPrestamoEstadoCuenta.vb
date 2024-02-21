Public Class frmPrestamoEstadoCuenta
    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable
    Private TipoPrestamo As String
    Private FormaPago As String

    Private IndicaHistorico As Boolean

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

End Class