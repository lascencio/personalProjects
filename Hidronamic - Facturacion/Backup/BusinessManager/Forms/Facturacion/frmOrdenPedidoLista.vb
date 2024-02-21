Public Class frmOrdenPedidoLista
    Private MyOrdenPedido As entOrdenPedido
    Private MyOrdenes As dsOrdenPedido.ORDEN_PEDIDO_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String
    Private MyTipoDocumento As String

    Public Sub New(ByRef OrdenPedido As entOrdenPedido, ByVal Ejercicio As String, ByVal Mes As String, ByVal Estado As String, ByVal TipoDocumento As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyOrdenPedido = OrdenPedido
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyEstado = Estado
        MyTipoDocumento = TipoDocumento
    End Sub

    Private Sub frmOrdenPedidoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ActualzarListaConsultores(cmbConsultor)
        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
        'Call PoblarGrilla("TODOS")
    End Sub

    Private Sub gvOrdenes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOrdenes.CellDoubleClick
        If Not gvOrdenes.CurrentRow Is Nothing Then
            MyOrdenPedido.orden_pedido = gvOrdenes.Rows(gvOrdenes.CurrentRow.Index).Cells("ORDEN_PEDIDO").Value
            Me.Close()
        End If
    End Sub

    Private Sub rbtTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        If sender.checked = True Then
            cmbConsultor.SelectedIndex = -1
            cmbConsultor.Enabled = False
        End If
    End Sub

    Private Sub rbtCuentaComercial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtConsultor.CheckedChanged
        If sender.checked = True Then cmbConsultor.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If rbtTodos.Checked = True Or (rbtConsultor.Checked = True And cmbConsultor.SelectedIndex <> -1) Then
            Call PoblarGrilla(IIf(rbtTodos.Checked = True, "TODOS", cmbConsultor.SelectedValue))
        End If
    End Sub

    Private Sub PoblarGrilla(ByVal TipoLista As String)
            MyOrdenes = New dsOrdenPedido.ORDEN_PEDIDO_LISTADataTable
        If TipoLista = "TODOS" Then
            MyOrdenes = dalOrdenPedido.PedidosPorConsultar(MyEjercicio, MyMes, Space(1), "PERIODO", MyEstado, MyTipoDocumento)
        Else
            If cmbConsultor.SelectedIndex <> -1 Then
                MyOrdenes = dalOrdenPedido.PedidosPorConsultar(MyEjercicio, MyMes, cmbConsultor.SelectedValue, "CONSULTOR", MyEstado, MyTipoDocumento)
            Else
                MyOrdenes = dalOrdenPedido.PedidosPorConsultar(MyEjercicio, MyMes, Space(1), "CONSULTOR", MyEstado, MyTipoDocumento)
            End If
        End If
        gvOrdenes.DataSource = MyOrdenes
        Call ActualzarListaConsultores(cmbConsultor)
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyOrdenes)
    End Sub

    Private Sub cmbEjercicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEjercicio.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyEjercicio = cmbEjercicio.Text
            Call PoblarGrilla(IIf(rbtTodos.Checked = True, "TODOS", cmbConsultor.SelectedValue))
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyMes = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            Call PoblarGrilla(IIf(rbtTodos.Checked = True, "TODOS", cmbConsultor.SelectedValue))
        End If
    End Sub

    Private Sub ActualzarListaConsultores(ByRef MyLista As ComboBox)
        MyLista.DataSource = dalOrdenPedido.ConsultoresPorPeriodo(MyEjercicio, MyMes)
        MyLista.SelectedIndex = -1
    End Sub

End Class