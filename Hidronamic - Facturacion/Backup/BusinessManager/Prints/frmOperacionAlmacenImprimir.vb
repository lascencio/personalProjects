Public Class frmOperacionAlmacenImprimir

    Private MyDatos(4) As String

    Private m_Operacion As String
    Private m_Almacen As String

    Sub New(ByVal MisDatos As Array, ByVal NumeroOperacion As String, ByVal Almacen As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        m_Operacion = NumeroOperacion
        m_Almacen = Almacen
        MyDatos = MisDatos
    End Sub

    Private Sub frmOperacionAlmacenImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyParams(4) As Microsoft.Reporting.WinForms.ReportParameter

        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pOperacionAlmacen", MyDatos(0), False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaOperacion", MyDatos(1), False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAlmacen", MyDatos(2), False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoOperacion", MyDatos(3), False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pComentario", MyDatos(4), False)
        'MyParams(5) = New Microsoft.Reporting.WinForms.ReportParameter("pDomicilio", MyDatos(5), False)
        'MyParams(6) = New Microsoft.Reporting.WinForms.ReportParameter("pTelefono", MyDatos(6), False)
        'MyParams(7) = New Microsoft.Reporting.WinForms.ReportParameter("pEmail", MyDatos(7), False)
        'MyParams(8) = New Microsoft.Reporting.WinForms.ReportParameter("pContactoComercial", MyDatos(8), False)
        'MyParams(9) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaInicio", MyDatos(9), False)
        'MyParams(10) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaEntrega", MyDatos(10), False)
        'MyParams(11) = New Microsoft.Reporting.WinForms.ReportParameter("pCuentaAbono", MyDatos(11), False)
        'MyParams(12) = New Microsoft.Reporting.WinForms.ReportParameter("pCuentaDetraccion", MyDatos(12), False)
        'MyParams(13) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoServicio", MyDatos(13), False)
        'MyParams(14) = New Microsoft.Reporting.WinForms.ReportParameter("pAreaSolicitante", MyDatos(14), False)
        'MyParams(15) = New Microsoft.Reporting.WinForms.ReportParameter("pResponsable", MyDatos(15), False)
        'MyParams(16) = New Microsoft.Reporting.WinForms.ReportParameter("pProyectoCodigo", MyDatos(16), False)
        'MyParams(17) = New Microsoft.Reporting.WinForms.ReportParameter("pProyectoNombre", MyDatos(17), False)
        'MyParams(18) = New Microsoft.Reporting.WinForms.ReportParameter("pClienteNombre", MyDatos(18), False)
        'MyParams(19) = New Microsoft.Reporting.WinForms.ReportParameter("pDirectorCuenta", MyDatos(19), False)
        'MyParams(20) = New Microsoft.Reporting.WinForms.ReportParameter("pEjecutivoCuenta", MyDatos(20), False)
        'MyParams(21) = New Microsoft.Reporting.WinForms.ReportParameter("pCondicionesPago", MyDatos(21), False)
        'MyParams(22) = New Microsoft.Reporting.WinForms.ReportParameter("pComentario", MyDatos(22), False)
        'MyParams(23) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoImpuesto", MyDatos(23), False)


        Dim MyDT As New dsOperacionesAlmacen.DETALLES_OPERACIONDataTable
        MyDT = dalOperacionAlmacen.ObtenerDetalles(m_Almacen, m_Operacion)

        Me.rvMovimientoAlmacen.LocalReport.SetParameters(MyParams)
        Me.rvMovimientoAlmacen.LocalReport.DataSources.Clear()
        Me.rvMovimientoAlmacen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsOperacionesAlmacen_DETALLES_OPERACION", MyDT))

        Me.rvMovimientoAlmacen.RefreshReport()
    End Sub
End Class