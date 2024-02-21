Public Class frmGuiaTrasladoLista
    Private MyGuia As entGuia
    Private MyGuiasTraslado As dsGuiasRemitente.GUIAS_TRASLADODataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyCuentaComercial As String
    Private MyEstado As String
    Private MyTipoOperacion As String

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByRef Guia As entGuia, ByVal Ejercicio As String, ByVal Mes As String, ByVal EstadoTrasladoInterno As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyGuia = Guia
        MyEjercicio = Ejercicio
        MyMes = Mes
        MyEstado = EstadoTrasladoInterno
    End Sub

    Private Sub frmGuiaTrasladoLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        For NAño As Integer = 2019 To Now.Year + 1
            cmbEjercicio.Items.Add(NAño)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvGuias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvGuias.CellDoubleClick
        Dim Index As Integer
        If Not sender.CurrentRow Is Nothing Then
            Index = sender.CurrentRow.Index
            'MyGuia.guia = gvGuias.Rows(sender.CurrentRow.Index).Cells("GUIA").Value
            'MyGuia.referencia_cuo = gvGuias.Rows(sender.CurrentRow.Index).Cells("REFERENCIA_CUO").Value
            MyGuia.guia = MyGuiasTraslado(Index).GUIA
            MyGuia.referencia_cuo = MyGuiasTraslado(Index).REFERENCIA_CUO
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        MyGuiasTraslado = New dsGuiasRemitente.GUIAS_TRASLADODataTable
        MyGuiasTraslado = dalGuia.RelacionGuiasTrasladoInterno(MyEjercicio, MyMes, MyEstado, MyUsuario.almacen)
        gvGuias.DataSource = MyGuiasTraslado
        gvGuias.ClearSelection()
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