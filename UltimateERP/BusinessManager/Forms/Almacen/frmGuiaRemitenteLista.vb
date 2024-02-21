Public Class frmGuiaRemitenteLista
    Private MyGuia As entGuia
    Private MyGuias As dsGuiasRemitente.GUIAS_SUNATDataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyCuentaComercial As String
    Private MyEstado As String
    Private MyTipoOperacion As String

    Public Sub New(ByRef Guia As entGuia, ByVal Ejercicio As String, ByVal Mes As String, CuentaComercial As String, ByVal TipoOperacion As String, ByVal Estado As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyGuia = Guia
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyCuentaComercial = CuentaComercial
        MyTipoOperacion = TipoOperacion
        MyEstado = Estado
    End Sub

    Private Sub frmGuiaRemitenteLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For NAño As Integer = 2019 To Now.Year + 1
            cmbEjercicio.Items.Add(NAño)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvOrdenes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvGuias.CellDoubleClick
        If Not gvGuias.CurrentRow Is Nothing Then
            MyGuia.guia = gvGuias.Rows(gvGuias.CurrentRow.Index).Cells("GUIA").Value
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyGuias = New dsGuiasRemitente.GUIAS_SUNATDataTable
        MyGuias = dalGuia.RelacionGuiasSunat(MyEjercicio, MyMes, MyCuentaComercial, MyTipoOperacion, MyEstado)
        gvGuias.DataSource = MyGuias
        gvGuias.ClearSelection()
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        If gvGuias.Rows.Count <> 0 Then
            Call ExportarExcel(MyProgressBar, MyGuias)
        End If
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