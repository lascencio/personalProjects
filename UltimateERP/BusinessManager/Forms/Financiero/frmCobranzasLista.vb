Public Class frmCobranzasLista
    Private MyCobranza As dsFinanciero.COBRANZASDataTable
    Private MyCobranzas As dsFinanciero.COBRANZAS_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String
    Private MyTipo As String

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Cobranza As dsFinanciero.COBRANZASDataTable, ByVal Ejercicio As String, ByVal Mes As String, ByVal Tipo As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCobranza = Cobranza
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyTipo = Tipo
    End Sub

    Private Sub frmCobranzasLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        For NEle As Integer = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvCobranzas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCobranzas.CellDoubleClick
        If Not gvCobranzas.CurrentRow Is Nothing Then
            MyCobranza(0).COBRANZA = gvCobranzas.Rows(gvCobranzas.CurrentRow.Index).Cells("COBRANZA").Value
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyCobranzas = dalFinanciamiento.ObtenerCobranzas(MyUsuario.empresa, "A0000" & MyUsuario.almacen, MyEjercicio, MyMes, MyTipo)
        gvCobranzas.DataSource = MyCobranzas
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyCobranzas)
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