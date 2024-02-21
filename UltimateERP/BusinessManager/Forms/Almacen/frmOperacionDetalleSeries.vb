Public Class frmOperacionDetalleSeries

    Private MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
    Private MyDetallesOperacionSeriesProducto As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

    Private MyControlSerie As dsControlSeries.CONTROL_SERIESDataTable
    Private MySerie As entSerie

    Private CodigoAlmacen As String
    Private CodigoProducto As String
    Private Cantidad As Decimal
    Private CantidadAtendida As Decimal = 0
    Private Tipo_ES As String

    Public Sub New(pCodigoAlmacen As String, pCodigoProducto As String, pCantidad As Decimal, pDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, pTipoES As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CodigoAlmacen = pCodigoAlmacen
        CodigoProducto = pCodigoProducto
        Cantidad = pCantidad
        MyDetallesOperacionSeries = pDetallesOperacionSeries
        Tipo_ES = pTipoES
    End Sub

    Private Sub frmOperacionDetalleSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyDetallesOperacionSeriesProducto = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                If MyDetallesOperacionSeries(NEle).PRODUCTO = CodigoProducto Then
                    MyDetallesOperacionSeriesProducto.ImportRow(MyDetallesOperacionSeries(NEle))
                    CantidadAtendida = CantidadAtendida + 1
                End If
            Next
            gvSeries.DataSource = MyDetallesOperacionSeriesProducto
        End If
        txtCantidad.Text = EvalDato(Cantidad, txtCantidad.Tag)
        txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
        btnSalir.Focus()
    End Sub

    Private Sub txtNumeroSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroSerie.KeyDown
        Dim Continuar As Boolean = True
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MySerie = New entSerie
            If txtNumeroSerie.TextLength = 0 Then
                If Tipo_ES = "S" Or Tipo_ES = "GT" Or Tipo_ES = "TA" Then ' GT: Guia por Traslado, TA: Transferencia entre almacenes
                    MySerie.empresa = MyUsuario.empresa
                    MySerie.producto = CodigoProducto
                    MySerie.almacen = CodigoAlmacen
                    Dim MyForm As New frmSerieLista(MySerie)
                    MyForm.ShowDialog()
                    If Not String.IsNullOrEmpty(MySerie.numero_serie) Then
                        txtNumeroSerie.Text = MySerie.numero_serie
                        Call GrabarSerie()
                    End If
                End If
            Else
                If gvSeries.RowCount <> 0 Then
                    For NEle As Integer = 0 To MyDetallesOperacionSeriesProducto.Rows.Count - 1
                        If MyDetallesOperacionSeriesProducto(NEle).NUMERO_SERIE.Trim = txtNumeroSerie.Text Then
                            Continuar = False
                            Exit For
                        End If
                    Next
                End If

                If Continuar = True Then
                    MyControlSerie = dalControlSeries.ObtenerControlSeries(MyUsuario.empresa, CodigoProducto, txtNumeroSerie.Text)
                    If MyControlSerie.Rows.Count <> 0 Then
                        If Tipo_ES = "I" Then
                            If MyControlSerie(0).ESTADO = "D" Then
                                Resp = MsgBox("El Número de Serie ya fué registrado y se encuentra DISPONIBLE.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
                                Continuar = False
                            End If
                        Else
                            If MyControlSerie(0).ESTADO <> "D" Then
                                Resp = MsgBox("El Número de Serie ingresado existe y no se encuentra DISPONIBLE.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
                                Continuar = False
                            End If
                        End If
                    End If

                    If Continuar = False Then
                        txtNumeroSerie.Text = Nothing
                        txtNumeroSerie.Focus()
                    Else
                        Call GrabarSerie()
                    End If

                Else
                    txtNumeroSerie.Text = Nothing
                    txtNumeroSerie.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub gvSeries_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSeries.CellClick
        If sender.CurrentCell.GetType.FullName.ToString Like "*Image*" Then
            Dim MyIndex As Integer
            Dim NumeroSerie As String
            If Not sender.CurrentRow Is Nothing Then
                MyIndex = sender.CurrentRow.Index
                NumeroSerie = MyDetallesOperacionSeriesProducto(MyIndex).NUMERO_SERIE
                MyDetallesOperacionSeriesProducto.Rows(MyIndex).Delete()
                For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                    If MyDetallesOperacionSeries(NEle).PRODUCTO = CodigoProducto And MyDetallesOperacionSeries(NEle).NUMERO_SERIE = NumeroSerie Then
                        MyDetallesOperacionSeries.Rows(NEle).Delete()
                        CantidadAtendida = CantidadAtendida - 1
                        txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GrabarSerie()
        If CantidadAtendida + 1 > Cantidad Then
            Resp = MsgBox("La cantidad de series ingresadas esta completa.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
        Else
            Dim MyDetalle As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESRow

            Dim PrimaryKey(3) As Object

            PrimaryKey(0) = MyUsuario.empresa
            PrimaryKey(1) = CUO_Nulo
            PrimaryKey(2) = CodigoProducto
            PrimaryKey(3) = txtNumeroSerie.Text

            MyDetalle = MyDetallesOperacionSeries.Rows.Find(PrimaryKey)

            If (MyDetalle Is Nothing) Then
                MyDetallesOperacionSeries.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, "", "", "A", "", Now.Date, "", Now.Date, "NO")
                MyDetallesOperacionSeriesProducto.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, "", "", "A", "", Now.Date, "", Now.Date, "NO")
                gvSeries.DataSource = MyDetallesOperacionSeriesProducto
                gvSeries.ClearSelection()
                CantidadAtendida = CantidadAtendida + 1
                txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
            End If
        End If
        txtNumeroSerie.Text = Nothing
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        CantidadAtendida = 0
        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                If MyDetallesOperacionSeries(NEle).PRODUCTO = CodigoProducto Then
                    CantidadAtendida = CantidadAtendida + 1
                End If
            Next
            gvSeries.DataSource = MyDetallesOperacionSeriesProducto
        End If

        If CantidadAtendida <> Cantidad Then
            Resp = MsgBox("La cantidad de series ingresadas es diferente a la solicitada." & vbCrLf & _
                          "Si abandona este formulario perderá las series registradas." & vbCrLf & _
                          "¿Desea abandonar el formulario?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "CONFIRMAR ACCION")
            If Resp = 1 Then
                Select Case Tipo_ES
                    Case Is = "I" : frmNotaIngresoAlmacen.txtCantidad.Text = 0
                    Case Is = "S" : frmNotaSalidaAlmacen.txtCantidad.Text = 0
                        'Case Is = "GT" : frmGuiaPorTraslado.txtCantidad.Text = 0
                        'Case Is = "TA" : frmTransferenciasAlmacen.txtCantidad.Text = 0
                End Select

                If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                        If MyDetallesOperacionSeries(NEle).PRODUCTO = CodigoProducto Then
                            MyDetallesOperacionSeries(NEle).ESTADO = "N"
                        End If
                    Next
                End If
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

End Class