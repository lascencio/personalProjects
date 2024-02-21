Public Class frmOperacionAlmacenLista

    Private MyOperacionAlmacen As entOperacionAlmacen

    Public Sub New(ByVal OperacionAlmacen As entOperacionAlmacen)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyOperacionAlmacen = OperacionAlmacen
    End Sub

    Private Sub frmOperacionAlmacenLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ActualizarListaEmpresa(cmbTipoOperacion, "_TIPO_OPERACION")
        ActualizarListaEmpresa(cmbAlmacen, "COM_ALMACEN")

        cmbAlmacen.SelectedValue = MyOperacionAlmacen.almacen
        cmbTipoOperacion.SelectedValue = MyOperacionAlmacen.tipo_operacion

        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = MyUsuario.mes - 1

    End Sub

    Private Sub gvOperacionesAlmacen_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOperacionesAlmacen.CellDoubleClick
        If Not gvOperacionesAlmacen.CurrentRow Is Nothing Then
            With gvOperacionesAlmacen.Rows(gvOperacionesAlmacen.CurrentRow.Index)
                MyOperacionAlmacen.almacen = cmbAlmacen.SelectedValue
                MyOperacionAlmacen.operacion = .Cells("OPERACION").Value
                MyOperacionAlmacen.tipo_operacion = cmbTipoOperacion.SelectedValue
            End With
            Me.Close()
        End If

    End Sub

    Private Sub ActualizarGrilla()
        If cmbAlmacen.SelectedIndex <> -1 And cmbTipoOperacion.SelectedIndex <> -1 And cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            Dim MyEjercicio As String = cmbEjercicio.Text
            Dim MyMes As String = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            gvOperacionesAlmacen.DataSource = dalOperacionAlmacen.BuscarOperacionAlmacen(cmbAlmacen.SelectedValue, cmbTipoOperacion.SelectedValue, MyEjercicio, MyMes)
        End If
    End Sub

    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlmacen.SelectedIndexChanged, cmbTipoOperacion.SelectedIndexChanged, cmbEjercicio.SelectedIndexChanged, cmbMes.SelectedIndexChanged
        Call ActualizarGrilla()
    End Sub

End Class