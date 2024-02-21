Public Class frmVentaDirectaLista
    Private MyVenta As entVenta
    Private MyVentas As dsVentas.VENTAS_GUIASDataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyCuentaComercial As String
    Private MyEstado As String
    Private EsVentaVehicular As Boolean
    'Private MyTipoOperacion As String

    Public Sub New(ByRef Venta As entVenta, ByVal Ejercicio As String, ByVal Mes As String, CuentaComercial As String, ByVal Estado As String, EsVehicular As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = Venta
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyCuentaComercial = CuentaComercial
        'MyTipoOperacion = TipoOperacion
        MyEstado = Estado
        EsVentaVehicular = EsVehicular
    End Sub

    Private Sub frmVentaLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For NAño As Integer = 2019 To Now.Year + 1
            cmbEjercicio.Items.Add(NAño)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1

        Call PoblarGrilla()
    End Sub

    Private Sub gvOrdenes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVentas.CellDoubleClick
        Dim MyIndex As Integer
        If Not gvVentas.CurrentRow Is Nothing Then
            MyIndex = gvVentas.CurrentRow.Index
            MyVenta.venta = MyVentas(MyIndex).VENTA
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyVentas = New dsVentas.VENTAS_GUIASDataTable
        MyVentas = dalVenta.ObtenerVentasGuias(MyUsuario.empresa, MyEjercicio, MyMes, True, EsVentaVehicular)
        gvVentas.DataSource = MyVentas
        gvVentas.ClearSelection()
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        If gvVentas.Rows.Count <> 0 Then
            Call ExportarExcel(MyProgressBar, MyVentas)
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