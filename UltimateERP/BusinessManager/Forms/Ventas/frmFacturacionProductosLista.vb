Public Class frmFacturacionProductosLista
    Private MyVenta As entVenta
    Private MyVentas As dsVentas.VENTAS_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String
    Private MyTipoVenta As String
    Private MyIndicaConGuia As String

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Venta As entVenta, ByVal Ejercicio As String, ByVal Mes As String, ByVal Estado As String, ByVal Tipo As String, IndicaConGuia As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = Venta
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyEstado = Estado
        MyTipoVenta = Tipo
        MyIndicaConGuia = IndicaConGuia
    End Sub

    Public Sub New(ByVal Venta As entVenta, ByVal Ejercicio As String, ByVal Mes As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyVenta = Venta
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyEstado = "V"
        MyTipoVenta = "X"
        MyIndicaConGuia = "SN"
    End Sub

    Private Sub frmFacturacionProductosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyTitulo As String

        For NEle As Integer = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        ActualizarListaEmpresa(cmbEstado, "COM_ESTADO_CP")

        Select Case MyTipoVenta.Substring(0, 1)
            Case Is = "B" : MyTitulo = "BOLETAS DE VENTA"
            Case Is = "F" : MyTitulo = "FACTURAS"
            Case Is = "C" : MyTitulo = "NOTAS DE CREDITO"
            Case Is = "D" : MyTitulo = "NOTAS DE DEBITO"
            Case Is = "X" : MyTitulo = "COMPROBANTES A FINANCIAR"
        End Select

        Me.Text = "RELACION DE " & MyTitulo
        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1

        cmbEstado.SelectedValue = "V"
    End Sub

    Private Sub gvComprobantes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvComprobantes.CellDoubleClick
        If Not gvComprobantes.CurrentRow Is Nothing Then
            MyVenta.venta = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("VENTA").Value
            MyVenta.comprobante_serie = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("COMPROBANTE_SERIE").Value
            MyVenta.comprobante_numero = gvComprobantes.Rows(gvComprobantes.CurrentRow.Index).Cells("COMPROBANTE_NUMERO").Value
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        Dim MyVentasNew As New dsVentas.VENTAS_LISTADataTable

        MyVentas = New dsVentas.VENTAS_LISTADataTable

        If MyTipoVenta = "X" Then
            cmbEstado.Enabled = False
            MyVentas = dalVenta.VentasPorConsultar(MyEjercicio, MyMes, Space(1), "FINANCIADO", MyEstado, MyTipoVenta, MyIndicaConGuia)
            If MyVentas.Rows.Count <> 0 Then
                For NEle As Integer = 0 To MyVentas.Rows.Count - 1
                    If dalVenta.ExisteReferencia(IIf(MyVentas(NEle).COMPROBANTE_SERIE.Substring(0, 1) = "F", "01", "03"), MyVentas(NEle).COMPROBANTE_SERIE, MyVentas(NEle).COMPROBANTE_NUMERO) = False Then
                        MyVentasNew.ImportRow(MyVentas(NEle))
                    End If
                Next
                If MyVentasNew.Rows.Count <> 0 Then MyVentas = MyVentasNew
            End If
        Else
            MyVentas = dalVenta.VentasPorConsultar(MyEjercicio, MyMes, Space(1), "PERIODO", MyEstado, MyTipoVenta, MyIndicaConGuia)
        End If
        gvComprobantes.DataSource = MyVentas
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyVentas)
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

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 And cmbEstado.SelectedIndex <> -1 Then
            MyEstado = cmbEstado.Text.Substring(0, 1)
            Call PoblarGrilla()
        End If
    End Sub
End Class