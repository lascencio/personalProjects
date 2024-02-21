Public Class frmPrestamosLista
    Private MyPrestamo As dsFinanciero.PRESTAMOSDataTable
    Private MyPrestamos As dsFinanciero.PRESTAMOS_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Prestamo As dsFinanciero.PRESTAMOSDataTable, ByVal Ejercicio As String, ByVal Mes As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyPrestamo = Prestamo
        MyEjercicio = Ejercicio
        MyMes = Mes
    End Sub

    Private Sub frmPrestamosLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        For NEle As Integer = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvPrestamos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvPrestamos.CellDoubleClick
        If Not gvPrestamos.CurrentRow Is Nothing Then
            MyPrestamo(0).PRESTAMO = gvPrestamos.Rows(gvPrestamos.CurrentRow.Index).Cells("PRESTAMO").Value
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyPrestamos = dalFinanciamiento.ObtenerPrestamos(MyUsuario.empresa, "A0000" & MyUsuario.almacen, MyEjercicio, MyMes, "V")
        gvPrestamos.DataSource = MyPrestamos
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyPrestamos)
    End Sub

    Private Sub cmbEjercicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEjercicio.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyEjercicio = cmbEjercicio.Text
            Call PoblarGrilla()
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyMes = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            Call PoblarGrilla()
        End If
    End Sub

End Class