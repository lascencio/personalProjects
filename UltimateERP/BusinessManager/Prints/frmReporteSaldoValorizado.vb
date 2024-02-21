Public Class frmReporteSaldoValorizado

    Private MyAlmacen As dsTablasGenericas.LISTADataTable
    Private MyProducto As entProducto
    Private MyTipos As dsTablasGenericas.LISTADataTable
    Private MySubTipos As dsTablasGenericas.LISTADataTable
    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MySubFamilias As dsTablasGenericas.LISTADataTable

    Private MyKardexValorizadoDetalles As dsCostos.SALDO_VALORIZADO_DETALLESDataTable
    Private MySaldosValorizados As dsCostos.SALDO_VALORIZADODataTable
    Private MyOperacionesAlmacenTransferencia As dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

    Private MyCostoImportacion As dsCostos.COSTO_IMPORTACIONDataTable
    Private MyAlmacenes As dsCostos.TABLA_ALMACENESDataTable

    Private MyCostoOperacionesAnteriores As dsCostos.COSTO_OPERACIONES_ANTERIORESDataTable

    Private MyPeriodo As String
    Private MyTipoMoneda As String

    Private Procesado As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmReporteSaldoValorizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")
        MyTipos = ObtenerListaEmpresa("PRODUCTO_TIPO", "DESCRIPCION")

        MyAlmacen = New dsTablasGenericas.LISTADataTable

        MySaldosValorizados = New dsCostos.SALDO_VALORIZADODataTable

        MyAlmacen.Rows.Add("COM_ALMACEN", "TODOS", "TODOS", "TODOS", Space(1), 0)

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbTipo.DataSource = MyTipos
        cmbSubTipo.DataSource = MySubTipos
        cmbFamilia.DataSource = MyFamilias
        cmbSubFamilia.DataSource = MySubFamilias
        cmbAlmacen.DataSource = MyAlmacen

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        MyAlmacenes = dalCostoPromedio.ObtenerAlmacenes

        txtFecha.Text = EvalDato(Now.Date, "F")
        cmbTipoMoneda.SelectedValue = "1"
    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ValidarFecha_Validated(sender As Object, e As EventArgs) Handles txtFecha.Validated
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = EvalDato(sender.Text, sender.Tag)
        End If

        If sender.Text.Trim.Length = 0 Then
            sender.Text = EvalDato(Now.Date, sender.Tag)
        End If

    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubFamiliasNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubFamilias = New dsTablasGenericas.LISTADataTable
            MySubFamilias.Rows.Add("PRODUCTO_SUB_FAMILIA", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyFamilias(MyIndex).CODIGO <> "TODOS" Then
                MySubFamiliasNew = ObtenerListaEmpresa("PRODUCTO_SUB_FAMILIA", "DESCRIPCION")
                If MySubFamiliasNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubFamiliasNew.Rows.Count - 1
                        With MySubFamiliasNew(NEle)
                            If .REFERENCIA = MyFamilias(MyIndex).REFERENCIA Then
                                MySubFamilias.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubFamilia.DataSource = MySubFamilias
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubTiposNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubTipos = New dsTablasGenericas.LISTADataTable
            MySubTipos.Rows.Add("PRODUCTO_SUB_TIPO", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyTipos(MyIndex).CODIGO <> "TODOS" Then
                MySubTiposNew = ObtenerListaEmpresa("PRODUCTO_SUB_TIPO", "DESCRIPCION")
                If MySubTiposNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubTiposNew.Rows.Count - 1
                        With MySubTiposNew(NEle)
                            If .REFERENCIA = MyTipos(MyIndex).REFERENCIA Then
                                MySubTipos.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubTipo.DataSource = MySubTipos
        End If
    End Sub

    Private Sub cmbTipoMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMoneda.SelectedIndexChanged
        If cmbTipoMoneda.SelectedIndex <> -1 Then
            MyTipoMoneda = cmbTipoMoneda.SelectedValue
            Procesado = False
        End If
    End Sub

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        If ckbProductoTodos.Checked = False Then
            EnableTextBox(txtProducto, True)
            txtProducto.Focus()
        Else
            txtProducto.Text = Nothing
            txtProductoDesdeNombre.Text = Nothing
            EnableTextBox(txtProducto, False)
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub ValidarProducto(ByVal sender As Object)
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = sender.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            btnGenerar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
        End If
    End Sub

    Private Sub GenerarTodo()
        Dim NumeroRegistros As Long
        Dim NumeroFila As Long

        Dim CostoUnitario As Decimal

        Dim AlmacenOrigen As String
        Dim AlmacenDestino As String

        If Procesado = False Then
            Procesado = True

            MyKardexValorizadoDetalles = New dsCostos.SALDO_VALORIZADO_DETALLESDataTable
            MySaldosValorizados = New dsCostos.SALDO_VALORIZADODataTable
            MyOperacionesAlmacenTransferencia = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

            MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardexSaldo(MyUsuario.empresa, MyUsuario.ejercicio)

            MyOperacionesAlmacenTransferencia = dalOperacionAlmacen.ObtenerTransferencia

            If MyKardexValorizadoDetalles.Rows.Count <> 0 Then
                NumeroRegistros = MyKardexValorizadoDetalles.Rows.Count - 1

                MyProgressBar.Maximum = NumeroRegistros + 1
                MyProgressBar.Value = 0
                MyProgressBar.ForeColor = Drawing.Color.Red
                MyProgressBar.Visible = True

                Do While NumeroFila <= NumeroRegistros
                    Dim MySaldoValorizado As dsCostos.SALDO_VALORIZADORow
                    Dim PrimaryKey1(1) As Object

                    With MyKardexValorizadoDetalles(NumeroFila)
                        PrimaryKey1(0) = .ALMACEN
                        PrimaryKey1(1) = .PRODUCTO

                        MySaldoValorizado = MySaldosValorizados.Rows.Find(PrimaryKey1)
                        If Not (MySaldoValorizado Is Nothing) Then
                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR IMPORTACION" Then
                                    If .PRECIO_UNITARIO_ME = 0 Then
                                        MyCostoImportacion = dalCostoPromedio.ObtenerCostoImportacion(.POLIZA, .COMPRA, .LINEA, .PRODUCTO)
                                        If MyCostoImportacion.Rows.Count <> 0 Then
                                            .PRECIO_UNITARIO_MN = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_MN, MyCostoImportacion(0).CU_FOB_MN)
                                            .PRECIO_UNITARIO_ME = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_ME, MyCostoImportacion(0).CU_FOB_ME)
                                        End If
                                    End If
                                    MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME

                                        MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                    Else
                                        If MyTipoMoneda = "1" Then
                                            .PRECIO_UNITARIO_MN = MySaldoValorizado.COSTO_PROMEDIO
                                        Else
                                            .PRECIO_UNITARIO_ME = MySaldoValorizado.COSTO_PROMEDIO
                                        End If

                                        MySaldoValorizado.COSTO_TOTAL = (MySaldoValorizado.COSTO_PROMEDIO) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                    End If
                                Else
                                    MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                End If

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK + .CANTIDAD
                                CostoUnitario = Math.Round(MySaldoValorizado.COSTO_TOTAL / MySaldoValorizado.STOCK, 5)

                                If .OPERACION_NOMBRE <> "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MySaldoValorizado.COSTO_PROMEDIO = CostoUnitario
                                End If
                            Else
                                If MySaldoValorizado.STOCK = 0 Then
                                    CostoUnitario = 0
                                Else
                                    CostoUnitario = Math.Round(MySaldoValorizado.COSTO_TOTAL / MySaldoValorizado.STOCK, 5)
                                End If

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK - .CANTIDAD
                                MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL - .CANTIDAD * CostoUnitario
                            End If

                            .CANTIDAD_SALDO = MySaldoValorizado.STOCK

                            If MyTipoMoneda = "1" Then
                                .COSTO_UNITARIO_MN = CostoUnitario
                            Else
                                .COSTO_UNITARIO_ME = CostoUnitario
                            End If

                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        If MyTipoMoneda = "1" Then
                                            .COSTO_TOTAL_MN_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        Else
                                            .COSTO_TOTAL_ME_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                        End If
                                    Else
                                        .COSTO_TOTAL_ME_DEBE = .CANTIDAD * CostoUnitario
                                    End If
                                Else
                                    If MyTipoMoneda = "1" Then
                                        .COSTO_TOTAL_MN_DEBE = .CANTIDAD * .PRECIO_UNITARIO_MN
                                    Else
                                        .COSTO_TOTAL_ME_DEBE = .CANTIDAD * .PRECIO_UNITARIO_ME
                                    End If
                                End If
                            Else
                                If MyTipoMoneda = "1" Then
                                    .COSTO_TOTAL_MN_HABER = .CANTIDAD * .COSTO_UNITARIO_MN
                                Else
                                    .COSTO_TOTAL_ME_HABER = .CANTIDAD * .COSTO_UNITARIO_ME
                                End If
                            End If

                            .COSTO_SALDO_MN = IIf(MyTipoMoneda = "1", MySaldoValorizado.COSTO_TOTAL, 0)
                            .COSTO_SALDO_ME = IIf(MyTipoMoneda = "2", MySaldoValorizado.COSTO_TOTAL, 0)

                            If .OPERACION_NOMBRE = "SALIDA POR TRANSFERENCIA" Then
                                If MyOperacionesAlmacenTransferencia.Rows.Count <> 0 Then
                                    Dim MyOperacionAlmacenTransferencia As dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRARow
                                    Dim PrimaryKey2(1) As Object
                                    PrimaryKey2(0) = .EMPRESA
                                    PrimaryKey2(1) = .OPERACION

                                    MyOperacionAlmacenTransferencia = MyOperacionesAlmacenTransferencia.Rows.Find(PrimaryKey2)

                                    If Not (MyOperacionAlmacenTransferencia Is Nothing) Then
                                        Dim MyAlmacen As dsCostos.TABLA_ALMACENESRow
                                        Dim PrimaryKey4(0) As Object
                                        PrimaryKey4(0) = MyOperacionAlmacenTransferencia.ALMACEN_DESTINO
                                        MyAlmacen = MyAlmacenes.Rows.Find(PrimaryKey4)

                                        AlmacenOrigen = .ALMACEN_NOMBRE
                                        AlmacenDestino = MyAlmacen.DESCRIPCION

                                        .ALMACEN_NOMBRE = AlmacenDestino
                                        .ALMACEN_NOMBRE = AlmacenOrigen

                                        Dim MySaldoValorizadoTransferencia As dsCostos.SALDO_VALORIZADORow
                                        Dim PrimaryKey3(1) As Object
                                        PrimaryKey3(0) = MyOperacionAlmacenTransferencia.ALMACEN_DESTINO
                                        PrimaryKey3(1) = .PRODUCTO
                                        MySaldoValorizadoTransferencia = MySaldosValorizados.Rows.Find(PrimaryKey3)

                                        If MyTipoMoneda = "1" Then
                                            .PRECIO_UNITARIO_MN = CostoUnitario
                                        Else
                                            .PRECIO_UNITARIO_ME = CostoUnitario
                                        End If

                                        If Not (MySaldoValorizadoTransferencia Is Nothing) Then
                                            MySaldoValorizadoTransferencia.STOCK = MySaldoValorizadoTransferencia.STOCK + .CANTIDAD
                                            MySaldoValorizadoTransferencia.COSTO_TOTAL = MySaldoValorizadoTransferencia.COSTO_TOTAL + Math.Round(.CANTIDAD * CostoUnitario, 5)
                                        Else
                                            MySaldosValorizados.Rows.Add(MyOperacionAlmacenTransferencia.ALMACEN_DESTINO, .PRODUCTO, .CODIGO_COMPRA, .PRODUCTO_FAMILIA, .PRODUCTO_TIPO, MyAlmacen.DESCRIPCION, .PRODUCTO_NOMBRE, .PRODUCTO_FAMILIA_NOMBRE, .PRODUCTO_TIPO_NOMBRE, .CANTIDAD, CostoUnitario, Math.Round(.CANTIDAD * CostoUnitario, 5))
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR IMPORTACION" Then
                                    If .PRECIO_UNITARIO_ME = 0 Then
                                        MyCostoImportacion = dalCostoPromedio.ObtenerCostoImportacion(.POLIZA, .COMPRA, .LINEA, .PRODUCTO)
                                        If MyCostoImportacion.Rows.Count <> 0 Then
                                            .PRECIO_UNITARIO_MN = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_MN, MyCostoImportacion(0).CU_FOB_MN)
                                            .PRECIO_UNITARIO_ME = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_ME, MyCostoImportacion(0).CU_FOB_ME)
                                        End If
                                    End If
                                ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                    End If
                                End If

                                MySaldosValorizados.Rows.Add(.ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .PRODUCTO_FAMILIA, .PRODUCTO_TIPO, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, .PRODUCTO_FAMILIA_NOMBRE, .PRODUCTO_TIPO_NOMBRE, .CANTIDAD, IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME), Math.Round(.CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME), 5))

                                .CANTIDAD_SALDO = .CANTIDAD
                                .COSTO_UNITARIO_MN = .PRECIO_UNITARIO_MN
                                .COSTO_UNITARIO_ME = .PRECIO_UNITARIO_ME

                                If .TIPO_ES = "I" Then
                                    .COSTO_TOTAL_MN_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_MN, 5)
                                    .COSTO_TOTAL_ME_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_ME, 5)
                                Else
                                    .COSTO_TOTAL_MN_HABER = Math.Round(.CANTIDAD * .COSTO_UNITARIO_MN, 5)
                                    .COSTO_TOTAL_ME_HABER = Math.Round(.CANTIDAD * .COSTO_UNITARIO_ME, 5)
                                End If

                                .COSTO_SALDO_MN = .COSTO_TOTAL_MN_DEBE - .COSTO_TOTAL_MN_HABER
                                .COSTO_SALDO_ME = .COSTO_TOTAL_ME_DEBE - .COSTO_TOTAL_ME_HABER
                            End If
                        End If
                    End With

                    NumeroFila = NumeroFila + 1

                    If NumeroFila > NumeroRegistros Then
                        Exit Do
                    Else
                        MyProgressBar.Value += 1
                    End If
                Loop

                'Resp = MsgBox("Proceso concluído satisfactoriamente.", MsgBoxStyle.Information, "COSTEAR INVENTARIOS")

                MyProgressBar.Visible = False
            End If
        End If

        Call ImprimirReporte()
    End Sub

    Private Sub GenerarFecha()
        Dim NumeroRegistros As Long
        Dim NumeroFila As Long
        Dim FechaDate As Date
        Dim FechaString As String
        Dim CostoUnitario As Decimal
        Dim AlmacenOrigen As String
        Dim AlmacenDestino As String

        FechaDate = txtFecha.Text
        FechaString = CStr(FechaDate.Year * 10000 + FechaDate.Month * 100 + FechaDate.Day)

        If FechaString.Trim.Length <> 0 Then
            Procesado = True

            MyKardexValorizadoDetalles = New dsCostos.SALDO_VALORIZADO_DETALLESDataTable
            MySaldosValorizados = New dsCostos.SALDO_VALORIZADODataTable
            MyOperacionesAlmacenTransferencia = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

            'MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardexFechaSaldo(MyUsuario.empresa, MyUsuario.ejercicio, FechaString)
            MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardexFechaProductoSaldo(MyUsuario.empresa, MyUsuario.ejercicio, FechaString, "P0001356")

            MyOperacionesAlmacenTransferencia = dalOperacionAlmacen.ObtenerTransferencia

            If MyKardexValorizadoDetalles.Rows.Count <> 0 Then
                NumeroRegistros = MyKardexValorizadoDetalles.Rows.Count - 1

                MyProgressBar.Maximum = NumeroRegistros + 1
                MyProgressBar.Value = 0
                MyProgressBar.ForeColor = Drawing.Color.Red
                MyProgressBar.Visible = True

                Do While NumeroFila <= NumeroRegistros
                    Dim MySaldoValorizado As dsCostos.SALDO_VALORIZADORow
                    Dim PrimaryKey1(1) As Object

                    With MyKardexValorizadoDetalles(NumeroFila)
                        PrimaryKey1(0) = .ALMACEN
                        PrimaryKey1(1) = .PRODUCTO

                        MySaldoValorizado = MySaldosValorizados.Rows.Find(PrimaryKey1)
                        If Not (MySaldoValorizado Is Nothing) Then
                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR IMPORTACION" Then
                                    If .PRECIO_UNITARIO_ME = 0 Then
                                        MyCostoImportacion = dalCostoPromedio.ObtenerCostoImportacion(.POLIZA, .COMPRA, .LINEA, .PRODUCTO)
                                        If MyCostoImportacion.Rows.Count <> 0 Then
                                            .PRECIO_UNITARIO_MN = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_MN, MyCostoImportacion(0).CU_FOB_MN)
                                            .PRECIO_UNITARIO_ME = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_ME, MyCostoImportacion(0).CU_FOB_ME)
                                        End If
                                    End If

                                    MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME

                                        MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                    Else
                                        If MyTipoMoneda = "1" Then
                                            .PRECIO_UNITARIO_MN = MySaldoValorizado.COSTO_PROMEDIO
                                        Else
                                            .PRECIO_UNITARIO_ME = MySaldoValorizado.COSTO_PROMEDIO
                                        End If

                                        MySaldoValorizado.COSTO_TOTAL = (MySaldoValorizado.COSTO_PROMEDIO) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                    End If
                                Else
                                    MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL + .CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME)
                                End If

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK + .CANTIDAD

                                CostoUnitario = Math.Round(MySaldoValorizado.COSTO_TOTAL / MySaldoValorizado.STOCK, 5)

                                If .OPERACION_NOMBRE <> "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MySaldoValorizado.COSTO_PROMEDIO = CostoUnitario
                                End If
                            Else
                                If MySaldoValorizado.STOCK = 0 Then
                                    CostoUnitario = 0
                                Else
                                    CostoUnitario = Math.Round(MySaldoValorizado.COSTO_TOTAL / MySaldoValorizado.STOCK, 5)
                                End If

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK - .CANTIDAD
                                MySaldoValorizado.COSTO_TOTAL = MySaldoValorizado.COSTO_TOTAL - .CANTIDAD * CostoUnitario
                            End If

                            .CANTIDAD_SALDO = MySaldoValorizado.STOCK

                            If MyTipoMoneda = "1" Then
                                .COSTO_UNITARIO_MN = CostoUnitario
                            Else
                                .COSTO_UNITARIO_ME = CostoUnitario
                            End If

                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        If MyTipoMoneda = "1" Then
                                            .COSTO_TOTAL_MN_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        Else
                                            .COSTO_TOTAL_ME_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                        End If
                                    Else
                                        If MyTipoMoneda = "1" Then
                                            .COSTO_TOTAL_MN_DEBE = .CANTIDAD * CostoUnitario
                                        Else
                                            .COSTO_TOTAL_ME_DEBE = .CANTIDAD * CostoUnitario
                                        End If
                                    End If
                                Else
                                    If MyTipoMoneda = "1" Then
                                        .COSTO_TOTAL_MN_DEBE = .CANTIDAD * .PRECIO_UNITARIO_MN
                                    Else
                                        .COSTO_TOTAL_ME_DEBE = .CANTIDAD * .PRECIO_UNITARIO_ME
                                    End If
                                End If
                            Else
                                If MyTipoMoneda = "1" Then
                                    .COSTO_TOTAL_MN_HABER = .CANTIDAD * .COSTO_UNITARIO_MN
                                Else
                                    .COSTO_TOTAL_ME_HABER = .CANTIDAD * .COSTO_UNITARIO_ME
                                End If
                            End If

                            .COSTO_SALDO_MN = IIf(MyTipoMoneda = "1", MySaldoValorizado.COSTO_TOTAL, 0)
                            .COSTO_SALDO_ME = IIf(MyTipoMoneda = "2", MySaldoValorizado.COSTO_TOTAL, 0)

                            If .OPERACION_NOMBRE = "SALIDA POR TRANSFERENCIA" Then
                                If MyOperacionesAlmacenTransferencia.Rows.Count <> 0 Then
                                    Dim MyOperacionAlmacenTransferencia As dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRARow
                                    Dim PrimaryKey2(1) As Object
                                    PrimaryKey2(0) = .EMPRESA
                                    PrimaryKey2(1) = .OPERACION

                                    MyOperacionAlmacenTransferencia = MyOperacionesAlmacenTransferencia.Rows.Find(PrimaryKey2)

                                    If Not (MyOperacionAlmacenTransferencia Is Nothing) Then
                                        Dim MyAlmacen As dsCostos.TABLA_ALMACENESRow
                                        Dim PrimaryKey4(0) As Object
                                        PrimaryKey4(0) = MyOperacionAlmacenTransferencia.ALMACEN_DESTINO
                                        MyAlmacen = MyAlmacenes.Rows.Find(PrimaryKey4)

                                        AlmacenOrigen = .ALMACEN_NOMBRE
                                        AlmacenDestino = MyAlmacen.DESCRIPCION

                                        .ALMACEN_NOMBRE = AlmacenDestino
                                        .ALMACEN_NOMBRE = AlmacenOrigen

                                        Dim MySaldoValorizadoTransferencia As dsCostos.SALDO_VALORIZADORow
                                        Dim PrimaryKey3(1) As Object
                                        PrimaryKey3(0) = MyOperacionAlmacenTransferencia.ALMACEN_DESTINO
                                        PrimaryKey3(1) = .PRODUCTO
                                        MySaldoValorizadoTransferencia = MySaldosValorizados.Rows.Find(PrimaryKey3)

                                        If MyTipoMoneda = "1" Then
                                            .PRECIO_UNITARIO_MN = CostoUnitario
                                        Else
                                            .PRECIO_UNITARIO_ME = CostoUnitario
                                        End If

                                        If Not (MySaldoValorizadoTransferencia Is Nothing) Then
                                            MySaldoValorizadoTransferencia.STOCK = MySaldoValorizadoTransferencia.STOCK + .CANTIDAD
                                            MySaldoValorizadoTransferencia.COSTO_TOTAL = MySaldoValorizadoTransferencia.COSTO_TOTAL + Math.Round(.CANTIDAD * CostoUnitario, 5)
                                        Else
                                            MySaldosValorizados.Rows.Add(MyOperacionAlmacenTransferencia.ALMACEN_DESTINO, .PRODUCTO, .CODIGO_COMPRA, .PRODUCTO_FAMILIA, .PRODUCTO_TIPO, MyAlmacen.DESCRIPCION, .PRODUCTO_NOMBRE, .PRODUCTO_FAMILIA_NOMBRE, .PRODUCTO_TIPO_NOMBRE, .CANTIDAD, CostoUnitario, Math.Round(.CANTIDAD * CostoUnitario, 5))
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If .TIPO_ES = "I" Then
                                If .OPERACION_NOMBRE = "INGRESO POR IMPORTACION" Then
                                    If .PRECIO_UNITARIO_ME = 0 Then
                                        MyCostoImportacion = dalCostoPromedio.ObtenerCostoImportacion(.POLIZA, .COMPRA, .LINEA, .PRODUCTO)
                                        If MyCostoImportacion.Rows.Count <> 0 Then
                                            .PRECIO_UNITARIO_MN = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_MN, MyCostoImportacion(0).CU_FOB_MN)
                                            .PRECIO_UNITARIO_ME = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_ME, MyCostoImportacion(0).CU_FOB_ME)
                                        End If
                                    End If
                                ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                    End If
                                End If

                                MySaldosValorizados.Rows.Add(.ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .PRODUCTO_FAMILIA, .PRODUCTO_TIPO, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, .PRODUCTO_FAMILIA_NOMBRE, .PRODUCTO_TIPO_NOMBRE, .CANTIDAD, IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME), Math.Round(.CANTIDAD * IIf(MyTipoMoneda = "1", .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME), 5))

                                .CANTIDAD_SALDO = .CANTIDAD
                                .COSTO_UNITARIO_MN = .PRECIO_UNITARIO_MN
                                .COSTO_UNITARIO_ME = .PRECIO_UNITARIO_ME

                                If .TIPO_ES = "I" Then
                                    .COSTO_TOTAL_MN_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_MN, 5)
                                    .COSTO_TOTAL_ME_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_ME, 5)
                                Else
                                    .COSTO_TOTAL_MN_HABER = Math.Round(.CANTIDAD * .COSTO_UNITARIO_MN, 5)
                                    .COSTO_TOTAL_ME_HABER = Math.Round(.CANTIDAD * .COSTO_UNITARIO_ME, 5)
                                End If

                                .COSTO_SALDO_MN = .COSTO_TOTAL_MN_DEBE - .COSTO_TOTAL_MN_HABER
                                .COSTO_SALDO_ME = .COSTO_TOTAL_ME_DEBE - .COSTO_TOTAL_ME_HABER
                            End If
                        End If
                    End With

                    NumeroFila = NumeroFila + 1

                    If NumeroFila > NumeroRegistros Then
                        Exit Do
                    Else
                        MyProgressBar.Value += 1
                    End If
                Loop

                'Resp = MsgBox("Proceso concluído satisfactoriamente.", MsgBoxStyle.Information, "COSTEAR INVENTARIOS")

                MyProgressBar.Visible = False
            End If
        End If

        Call ImprimirReporte()
    End Sub

    Private Sub ImprimirReporte()
        Dim MySaldosValorizadosNew As New dsCostos.SALDO_VALORIZADODataTable
        Dim pAlmacen As String = cmbAlmacen.SelectedValue
        Dim pMarca As String = cmbFamilia.SelectedValue
        Dim pModelo As String = cmbSubFamilia.SelectedValue
        Dim pLinea As String = cmbTipo.SelectedValue
        Dim pSubLinea As String = cmbSubTipo.SelectedValue
        Dim pProducto As String = txtProducto.Text
        Dim pMoneda As String = cmbTipoMoneda.SelectedValue
        Dim pFecha As Date = CDate(txtFecha.Text)

        MyPeriodo = MyUsuario.ejercicio

        If cmbTipoMoneda.SelectedIndex = 1 Then
            MySaldosValorizados = dalCostoPromedio.ObtenerSaldoValorizadoMN(MyUsuario.empresa, pFecha.Year * 10000 + pFecha.Month * 100 + pFecha.Day, pAlmacen, pProducto, pMarca, pModelo, pLinea, pSubLinea)
        Else
            MySaldosValorizados = dalCostoPromedio.ObtenerSaldoValorizadoME(MyUsuario.empresa, pFecha.Year * 10000 + pFecha.Month * 100 + pFecha.Day, pAlmacen, pProducto, pMarca, pModelo, pLinea, pSubLinea)
        End If

        Dim MyParams(2) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pPeriodo", MyPeriodo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pMoneda", pMoneda, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pFecha", pFecha, False)

        Me.rvSaldoValorizado.LocalReport.SetParameters(MyParams)

        Me.rvSaldoValorizado.LocalReport.DataSources.Clear()
        Me.rvSaldoValorizado.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MySaldosValorizados, DataTable)))

        Me.rvSaldoValorizado.DocumentMapCollapsed = True

        Me.rvSaldoValorizado.RefreshReport()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If Procesado = False Then
            Procesado = dalCostoPromedio.CalcularCostoPromedio(MyProgressBar)

            MyProgressBar.Visible = False
        End If

        Call ImprimirReporte()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim MyExcelReport As DataTable = New DataTable("ExcelReport")

        Dim MyDC As DataColumn
        Dim MyDR As DataRow

        MyDC = New DataColumn("ALMACEN", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRODUCTO", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("PRODUCTO_NOMBRE", Type.GetType("System.String")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("STOCK", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("COSTO_UNITARIO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)
        MyDC = New DataColumn("SALDO_VALORIZADO", Type.GetType("System.Decimal")) : MyExcelReport.Columns.Add(MyDC)

        With MyExcelReport
            .Columns("ALMACEN").MaxLength = 500
            .Columns("PRODUCTO").MaxLength = 500
            .Columns("PRODUCTO_NOMBRE").MaxLength = 1000
        End With

        If MySaldosValorizados.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MySaldosValorizados.Rows.Count - 1
                With MySaldosValorizados(NEle)
                    MyDR = MyExcelReport.NewRow
                    MyDR.Item("ALMACEN") = .ALMACEN_NOMBRE
                    MyDR.Item("PRODUCTO") = .PRODUCTO
                    MyDR.Item("PRODUCTO_NOMBRE") = .PRODUCTO_NOMBRE
                    MyDR.Item("STOCK") = .STOCK
                    MyDR.Item("COSTO_UNITARIO") = .COSTO_PROMEDIO
                    MyDR.Item("SALDO_VALORIZADO") = .COSTO_TOTAL
                    MyExcelReport.Rows.Add(MyDR)
                End With
            Next
            Call ExportarExcel(MyProgressBar, MyExcelReport)
        End If
    End Sub


End Class