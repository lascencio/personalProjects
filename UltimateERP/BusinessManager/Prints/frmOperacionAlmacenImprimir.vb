Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmOperacionAlmacenImprimir
    Private OperacionAlmacen As String
    Private FechaOperacion As Date
    Private Almacen As String
    Private TipoOperacion As String
    Private Comentario As String

    Private dsDetalles As dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable

    Public Sub New(pOperacionAlmacen As String, pFechaOperacion As Date, pAlmacen As String, pTipoOperacion As String, pComentario As String, pdsDetalles As dsOperacionesAlmacen.DETALLES_IMPRIMIRDataTable)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        OperacionAlmacen = pOperacionAlmacen
        FechaOperacion = pFechaOperacion
        Almacen = pAlmacen
        TipoOperacion = pTipoOperacion
        Comentario = pComentario

        dsDetalles = pdsDetalles

    End Sub

    Private Sub frmOperacionAlmacenImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim MyParams(4) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pOperacionAlmacen", OperacionAlmacen, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pFechaOperacion", FechaOperacion, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAlmacen", Almacen, False)
        MyParams(3) = New Microsoft.Reporting.WinForms.ReportParameter("pTipoOperacion", TipoOperacion, False)
        MyParams(4) = New Microsoft.Reporting.WinForms.ReportParameter("pComentario", Comentario, False)

        Me.rvOperacionAlmacen.LocalReport.SetParameters(MyParams)

        Me.rvOperacionAlmacen.LocalReport.DataSources.Clear()
        Me.rvOperacionAlmacen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(dsDetalles, DataTable)))
        Me.rvOperacionAlmacen.DocumentMapCollapsed = True

        Me.rvOperacionAlmacen.RefreshReport()
    End Sub
End Class