Public Class frmOperacionesAlmacenes

    Private MyOperacionAlmacen As entOperacionAlmacen
    Private TipoIS As String
    Private EsIngresoTrasladoInterno As Boolean
    Private EsVehicular As String = "SN"

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal OperacionAlmacen As entOperacionAlmacen, ByVal TipoIngresoSalida As String, IngresoTrasladoInterno As Boolean, EsOperacionVehicular As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MyOperacionAlmacen = OperacionAlmacen
        TipoIS = TipoIngresoSalida
        EsIngresoTrasladoInterno = IngresoTrasladoInterno
        EsVehicular = EsOperacionVehicular
    End Sub

    Private Sub frmOperacionAlmacenLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyTiposOperacion As dsTablasGenericas.DETALLESDataTable
        Dim MyTiposOperacionNew As New dsTablasGenericas.DETALLESDataTable
        cmbAlmacen.DataSource = MyDTAlmacenes

        MyTiposOperacion = CargarTablaGenerica("_TIPO_OPERACION")
        If MyTiposOperacion.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyTiposOperacion.Rows.Count - 1
                If TipoIS = "S" Then
                    If MyTiposOperacion(NEle).LOGICO_01 = 0 Then
                        MyTiposOperacionNew.ImportRow(MyTiposOperacion(NEle))
                    End If
                Else
                    If MyTiposOperacion(NEle).LOGICO_01 = 1 Then
                        MyTiposOperacionNew.ImportRow(MyTiposOperacion(NEle))
                    End If
                End If
            Next
        End If

        cmbTipoOperacion.DataSource = MyTiposOperacionNew

        cmbAlmacen.SelectedIndex = -1
        cmbTipoOperacion.SelectedIndex = -1

        For NEle = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        cmbEjercicio.Text = MyUsuario.ejercicio
        cmbMes.SelectedIndex = MyUsuario.mes - 1
    End Sub

    Private Sub gvOperacionesAlmacen_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvOperacionesAlmacen.CellDoubleClick
        If Not gvOperacionesAlmacen.CurrentRow Is Nothing Then
            With gvOperacionesAlmacen.Rows(gvOperacionesAlmacen.CurrentRow.Index)
                MyOperacionAlmacen.almacen = cmbAlmacen.SelectedValue
                MyOperacionAlmacen.operacion = .Cells("OPERACION").Value
                If MyOperacionAlmacen.tipo_operacion = "11" Then ' Traslado entre almacenes
                    MyOperacionAlmacen.comentario = .Cells("COMENTARIO").Value & " ORIGEN: " & .Cells("ALMACEN_DESCRIPCION").Value
                Else
                    MyOperacionAlmacen.tipo_operacion = cmbTipoOperacion.SelectedValue
                End If
            End With
            Me.Close()
        End If
    End Sub

    Private Sub ActualizarGrilla()
        Dim MyOperacionesAlmacenes As dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable
        Dim MyOperacionesAlmacenesFinal As New dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable
        Dim MostrarRegistro As Boolean = True

        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            Dim MyEjercicio As String = cmbEjercicio.Text
            Dim MyMes As String = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)

            If MyOperacionAlmacen.tipo_operacion = "11" Then ' Trasnsferencia entre almacenes
                MyOperacionesAlmacenes = dalOperacionAlmacen.BuscarOperacionesTrasladoAlmacenes(MyEjercicio, MyMes)
            Else
                MyOperacionesAlmacenes = dalOperacionAlmacen.BuscarOperacionesAlmacenes(TipoIS, MyEjercicio, MyMes, EsVehicular)
            End If

            If TipoIS = "I" Then
                If MyOperacionesAlmacenes.Rows.Count <> 0 Then
                    If EsIngresoTrasladoInterno Then
                        For NEle As Integer = 0 To MyOperacionesAlmacenes.Rows.Count - 1
                            If MyOperacionesAlmacenes(NEle).TIPO_OPERACION = "11" Then
                                MyOperacionesAlmacenesFinal.ImportRow(MyOperacionesAlmacenes(NEle))
                            End If
                        Next
                    Else
                        For NEle As Integer = 0 To MyOperacionesAlmacenes.Rows.Count - 1
                            'If MyOperacionesAlmacenes(NEle).TIPO_OPERACION = "16" Then  ' Saldo Inicial
                            If MyOperacionesAlmacenes(NEle).TIPO_OPERACION <> "18" Then
                                ' No es Importacion
                                If MyOperacionAlmacen.tipo_operacion Is Nothing Then
                                    MyOperacionesAlmacenesFinal.ImportRow(MyOperacionesAlmacenes(NEle))
                                Else
                                    If MyOperacionesAlmacenes(NEle).TIPO_OPERACION = MyOperacionAlmacen.tipo_operacion And MyOperacionesAlmacenes(NEle).INDICA_CREDITO = MyOperacionAlmacen.indica_credito Then
                                        MyOperacionesAlmacenesFinal.ImportRow(MyOperacionesAlmacenes(NEle))
                                    End If
                                End If
                            End If
                        Next
                    End If
                    MyOperacionesAlmacenes = MyOperacionesAlmacenesFinal
                End If
            End If

            gvOperacionesAlmacen.DataSource = MyOperacionesAlmacenes
        End If
    End Sub

    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlmacen.SelectedIndexChanged, cmbTipoOperacion.SelectedIndexChanged, cmbEjercicio.SelectedIndexChanged, cmbMes.SelectedIndexChanged
        Call ActualizarGrilla()
    End Sub

End Class