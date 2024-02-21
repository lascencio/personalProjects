Public Class frmFacturacionProductosLista
    Private MyVenta As entVenta
    Private MyVentas As dsVentas.VENTAS_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String
    Private MyTipoVenta As String

    Public Sub New(ByVal Venta As entVenta, ByVal Ejercicio As String, ByVal Mes As String, ByVal Estado As String, ByVal Tipo As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = Venta
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyEstado = Estado
        MyTipoVenta = Tipo
    End Sub

    Private Sub frmFacturacionProductosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyTitulo As String

        Select Case MyTipoVenta.Substring(0, 1)
            Case Is = "B" : MyTitulo = "BOLETAS DE VENTA"
            Case Is = "F" : MyTitulo = "FACTURAS"
            Case Is = "C" : MyTitulo = "NOTAS DE CREDITO"
            Case Is = "D" : MyTitulo = "NOTAS DE DEBITO"
        End Select

        Call ActualzarListaConsultores(cmbConsultor)
        Me.Text = "RELACION DE " & MyTitulo
        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvComprobantes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvComprobantes.CellDoubleClick
        If Not gvComprobantes.CurrentRow Is Nothing Then
            MyVenta.venta = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("VENTA").Value
            MyVenta.comprobante_serie = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("COMPROBANTE_SERIE").Value
            MyVenta.comprobante_numero = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("COMPROBANTE_NUMERO").Value
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
        MyVentas = New dsVentas.VENTAS_LISTADataTable
        If TipoLista = "TODOS" Then
            MyVentas = dalVenta.VentasPorConsultar(MyEjercicio, MyMes, Space(1), "PERIODO", MyEstado, MyTipoVenta)
        Else
            If cmbConsultor.SelectedIndex <> -1 Then
                MyVentas = dalVenta.VentasPorConsultar(MyEjercicio, MyMes, cmbConsultor.SelectedValue, "CONSULTOR", MyEstado, MyTipoVenta)
            Else
                MyVentas = dalVenta.VentasPorConsultar(MyEjercicio, MyMes, Space(1), "CONSULTOR", MyEstado, MyTipoVenta)
            End If
        End If
        gvComprobantes.DataSource = MyVentas
        Call ActualzarListaConsultores(cmbConsultor)
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyVentas)
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