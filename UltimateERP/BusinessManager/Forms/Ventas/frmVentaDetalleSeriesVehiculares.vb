Public Class frmVentaDetalleSeriesVehiculares
    Private MyVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable
    Private MyVentaDetalleSeriesProducto As dsVentas.VENTA_DET_SERIESDataTable

    Private MyControlSerie As dsControlSeries.CONTROL_SERIESDataTable
    Private MySerie As entSerie

    Private CodigoAlmacen As String
    Private CodigoProducto As String

    Private Cantidad As Decimal
    Private CantidadAtendida As Decimal = 0

    Public Sub New(ByVal pCodigoAlmacen As String, ByVal pCodigoProducto As String, ByRef pCantidadSolicitada As Decimal, ByRef VentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        CodigoAlmacen = pCodigoAlmacen
        CodigoProducto = pCodigoProducto
        Cantidad = pCantidadSolicitada
        MyVentaDetalleSeries = VentaDetalleSeries
    End Sub

    Private Sub frmVentaDetalleSeriesVehiculares_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarListaGenerica(cmbColor, "VEHICULO_COLOR")

        MyVentaDetalleSeriesProducto = New dsVentas.VENTA_DET_SERIESDataTable
        If MyVentaDetalleSeries.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto Then
                    MyVentaDetalleSeriesProducto.ImportRow(MyVentaDetalleSeries(NEle))
                    CantidadAtendida = CantidadAtendida + 1
                End If
            Next
            gvSeries.DataSource = MyVentaDetalleSeriesProducto
        End If
        txtCantidad.Text = EvalDato(Cantidad, txtCantidad.Tag)
        txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
        cmbColor.SelectedIndex = -1
        txtNumeroSerie.Focus()
    End Sub

    Private Sub txtNumeroSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroSerie.KeyDown
        Dim Continuar As Boolean = True
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MySerie = New entSerie
            If txtNumeroSerie.TextLength = 0 Then
                MySerie.empresa = MyUsuario.empresa
                MySerie.producto = CodigoProducto
                MySerie.almacen = CodigoAlmacen
                Dim MyForm As New frmSerieVehicularLista(MySerie)
                MyForm.ShowDialog()
                If Not String.IsNullOrEmpty(MySerie.numero_serie) Then
                    txtNumeroSerie.Text = MySerie.numero_serie
                    txtNumeroSerieChasis.Text = MySerie.numero_serie_chasis
                    If MySerie.color.Trim.Length = 0 Then
                        cmbColor.SelectedIndex = -1
                    Else
                        cmbColor.SelectedValue = MySerie.color
                    End If
                    Call GrabarSerie()
                End If
            Else
                If gvSeries.RowCount <> 0 Then
                    For NEle As Integer = 0 To MyVentaDetalleSeriesProducto.Rows.Count - 1
                        If MyVentaDetalleSeriesProducto(NEle).NUMERO_SERIE.Trim = txtNumeroSerie.Text Then
                            Continuar = False
                            Exit For
                        End If
                    Next
                End If

                If dalGuia.EvaluarSerieVendida(CodigoProducto, txtNumeroSerie.Text) = True Then
                    Resp = MsgBox("El Número de Serie registrado ya fué vendido.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
                    Continuar = False
                End If

                If Continuar = True Then
                    MyControlSerie = dalControlSeries.ObtenerControlSeries(MyUsuario.empresa, CodigoProducto, txtNumeroSerie.Text)
                    If MyControlSerie.Rows.Count <> 0 Then
                        If MyControlSerie(0).ESTADO <> "D" Then
                            Resp = MsgBox("El Número de Serie ingresado existe y no se encuentra DISPONIBLE.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
                            Continuar = False
                        End If
                    End If

                    If Continuar = False Then
                        txtNumeroSerie.Text = Nothing
                        txtNumeroSerie.Focus()
                    Else
                        txtNumeroSerieChasis.Focus()
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
                NumeroSerie = MyVentaDetalleSeriesProducto(MyIndex).NUMERO_SERIE
                MyVentaDetalleSeriesProducto.Rows(MyIndex).Delete()
                For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                    If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto And MyVentaDetalleSeries(NEle).NUMERO_SERIE = NumeroSerie Then
                        MyVentaDetalleSeries.Rows(NEle).Delete()
                        CantidadAtendida = CantidadAtendida - 1
                        txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GrabarSerie()
        Dim Color As String = Space(1)
        If CantidadAtendida + 1 > Cantidad Then
            Resp = MsgBox("La cantidad de series ingresadas esta completa.", MsgBoxStyle.Information, "REGISTRAR NUMEROS DE SERIE")
        Else
            Dim MyDetalle As dsVentas.VENTA_DET_SERIESRow
            Dim PrimaryKey(3) As Object

            PrimaryKey(0) = MyUsuario.empresa
            PrimaryKey(1) = CUO_Nulo
            PrimaryKey(2) = CodigoProducto
            PrimaryKey(3) = txtNumeroSerie.Text

            MyDetalle = MyVentaDetalleSeries.Rows.Find(PrimaryKey)

            If (MyDetalle Is Nothing) Then
                If cmbColor.SelectedIndex <> -1 Then
                    Color = cmbColor.Text
                Else
                    Color = MySerie.color
                End If
                MyVentaDetalleSeries.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, Color, "D", "NO")
                MyVentaDetalleSeriesProducto.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, Color, "D", "NO")

                gvSeries.DataSource = MyVentaDetalleSeriesProducto
                gvSeries.ClearSelection()
                CantidadAtendida = CantidadAtendida + 1
                txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
            End If
        End If
        txtNumeroSerie.Text = Nothing
        txtNumeroSerieChasis.Text = Nothing
        cmbColor.SelectedIndex = -1

    End Sub

    Private Sub txtNumeroSerieChasis_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroSerieChasis.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            cmbColor.Focus()
        End If
    End Sub

    Private Sub txtColor_KeyDown(sender As Object, e As KeyEventArgs)
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub cmbColor_Validated(sender As Object, e As EventArgs) Handles cmbColor.Validated
        If cmbColor.SelectedIndex <> -1 Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        CantidadAtendida = 0
        If MyVentaDetalleSeries.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto Then
                    CantidadAtendida = CantidadAtendida + 1
                End If
            Next
            gvSeries.DataSource = MyVentaDetalleSeriesProducto
        End If

        If CantidadAtendida <> Cantidad Then
            Resp = MsgBox("La cantidad de series ingresadas es diferente a la solicitada." & vbCrLf & _
                          "Si abandona este formulario perderá las series registradas." & vbCrLf & _
                          "¿Desea abandonar el formulario?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "CONFIRMAR ACCION")
            If Resp = 1 Then
                frmVentaDirecta.txtCantidad.Text = 0
                With frmVentaDirecta
                    .txtCantidad.Text = EvalDato(0, .txtCantidad.Tag)
                End With

                If MyVentaDetalleSeries.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyVentaDetalleSeries.Rows.Count - 1
                        If MyVentaDetalleSeries(NEle).PRODUCTO = CodigoProducto Then
                            MyVentaDetalleSeries(NEle).ESTADO = "N"
                        End If
                    Next
                End If
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim NumeroSerie As String = txtNumeroSerie.Text.Trim
        Dim NumeroSerieChasis As String = txtNumeroSerieChasis.Text.Trim
        Dim Color As String = cmbColor.Text

        If NumeroSerie.Length <> 0 And NumeroSerieChasis.Length <> 0 And Color.Length <> 0 Then
            MyVentaDetalleSeries.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, cmbColor.Text, "D", "NO")
            MyVentaDetalleSeriesProducto.Rows.Add(MyUsuario.empresa, CUO_Nulo, CodigoProducto, txtNumeroSerie.Text, txtNumeroSerieChasis.Text, cmbColor.Text, "D", "NO")
            gvSeries.DataSource = MyVentaDetalleSeriesProducto
            gvSeries.ClearSelection()
            CantidadAtendida = CantidadAtendida + 1
            txtCantidadAtendida.Text = EvalDato(CantidadAtendida, txtCantidadAtendida.Tag)
            txtNumeroSerie.Text = Nothing : txtNumeroSerieChasis.Text = Nothing : cmbColor.SelectedIndex = -1
            txtNumeroSerie.Focus()
        End If
    End Sub

End Class