Public Class frmEComprobantesServiciosLista

    Private MyVenta As entVenta
    Private MyVentas As dsVentas.VENTAS_LISTADataTable

    Private MyComprobanteTipo As String

    Public Sub New(ByVal Venta As entVenta, ByVal ComprobanteTipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = Venta
        MyComprobanteTipo = ComprobanteTipo
    End Sub

    Private Sub frmFacturacionServiciosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbCuentaComercial.DataSource = MyListaClientes
        cmbCuentaComercial.SelectedIndex = -1
        Call PoblarGrilla("TODOS")
    End Sub

    Private Sub gvVentas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVentas.CellDoubleClick
        If Not gvVentas.CurrentRow Is Nothing Then
            MyVenta.venta = gvVentas.Rows(gvVentas.CurrentRow.Index).Cells("VENTA").Value
            Me.Close()
        End If
    End Sub

    Private Sub rbtTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        If sender.checked = True Then
            cmbCuentaComercial.SelectedIndex = -1
            cmbCuentaComercial.Enabled = False
        End If
    End Sub

    Private Sub rbtCuentaComercial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCuentaComercial.CheckedChanged
        If sender.checked = True Then cmbCuentaComercial.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If rbtTodos.Checked = True Or (rbtCuentaComercial.Checked = True And cmbCuentaComercial.SelectedIndex <> -1) Then
            Call PoblarGrilla(IIf(rbtTodos.Checked = True, "TODOS", cmbCuentaComercial.SelectedValue))
        End If
    End Sub

    Private Sub PoblarGrilla(ByVal CuentaComercial As String)
        MyVentas = New dsVentas.VENTAS_LISTADataTable
        MyVentas = dalVenta.BuscarVentas(MyUsuario.empresa, MyUsuario.ejercicio, Strings.Right("00" & MyUsuario.mes.ToString, 2), CuentaComercial, MyComprobanteTipo)
        gvVentas.DataSource = MyVentas
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyVentas)
    End Sub
End Class