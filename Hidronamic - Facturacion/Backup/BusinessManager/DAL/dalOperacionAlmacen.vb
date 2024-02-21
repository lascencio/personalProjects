Imports System.Data.SqlClient

Public Class dalOperacionAlmacen
    Private Shared MySql As String

    Private Shared Function Existe(ByVal cOperacionAlmacen As entOperacionAlmacen) As Boolean
        If Not String.IsNullOrEmpty(cOperacionAlmacen.operacion) Then
            MySql = "SELECT COUNT(*) FROM ALM.OPERACIONES_ALMACEN " & _
                    "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacen.almacen)
                MySQLCommand.Parameters.AddWithValue("vOperacion", cOperacionAlmacen.operacion)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal pAlmacen As String, ByVal pOperacion As String) As Boolean
        MySql = "SELECT COUNT(*) FROM ALM.OPERACIONES_ALMACEN " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As Boolean
        MySql = "SELECT COUNT(*) FROM ALM.OPERACIONES_ALMACEN_DET " & _
                "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion AND Linea=@vLinea "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
            MySQLCommand.Parameters.AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function EvaluarSiExisteResumenAlmacen(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As Boolean
        MySql = "SELECT COUNT(*) FROM ALM.RESUMEN_X_ALMACEN " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
            MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function EvaluarSiExisteResumenPeriodo(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As Boolean
        MySql = "SELECT COUNT(*) FROM ALM.RESUMEN_X_PERIODO " & _
                "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
            MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Grabar(ByVal cOperacionAlmacen As entOperacionAlmacen) As entOperacionAlmacen
        With cOperacionAlmacen
            If Year(.fecha_operacion) * 100 + Month(.fecha_operacion) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            If String.IsNullOrEmpty(.almacen) Then Throw New BusinessException(MSG000 & " ALMACEN")
            If String.IsNullOrEmpty(.tipo_operacion) Then Throw New BusinessException(MSG000 & " TIPO DE OPERACION")
            If String.IsNullOrEmpty(.comentario.Trim) Then Throw New BusinessException(MSG000 & " COMENTARIO")

            If .tipo_operacion = "02" Or .tipo_operacion = "92" Then ' Compra Local o Importacion
                If String.IsNullOrEmpty(.referencia_cuenta_comercial.Trim) Then Throw New BusinessException(MSG000 & " DOCUMENTO IDENTIDAD")
                If .tipo_operacion = "02" Then If String.IsNullOrEmpty(.referencia_serie.Trim) Then Throw New BusinessException(MSG000 & " SERIE")
                If String.IsNullOrEmpty(.referencia_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO")
                If Year(.referencia_fecha) * 100 + Month(.referencia_fecha) = 190001 Then Throw New BusinessException(MSG000 & " F. EMISION")
                'If .referencia_importe_total = 0 Then Throw New BusinessException(MSG000 & " IMPORTE TOTAL")
            End If
        End With

        If Not Existe(cOperacionAlmacen) Then
            Return Insertar(cOperacionAlmacen)
        Else
            Return Actualizar(cOperacionAlmacen)
        End If
    End Function

    Private Shared Function Insertar(ByVal cOperacionAlmacen As entOperacionAlmacen) As entOperacionAlmacen
        cOperacionAlmacen.operacion = AsignarOperacion()
        MySql = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,usuario_registro) " & _
                "VALUES " & _
                "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vUsuario_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacen.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacen.operacion)
                .AddWithValue("vTipo_operacion", cOperacionAlmacen.tipo_operacion)
                .AddWithValue("vEjercicio", cOperacionAlmacen.ejercicio)
                .AddWithValue("vMes", cOperacionAlmacen.mes)
                .AddWithValue("vFecha_operacion", cOperacionAlmacen.fecha_operacion)
                .AddWithValue("vComentario", cOperacionAlmacen.comentario)
                .AddWithValue("vTipo_es", cOperacionAlmacen.tipo_es)
                .AddWithValue("vReferencia_cuenta_comercial", cOperacionAlmacen.referencia_cuenta_comercial)
                .AddWithValue("vReferencia_tipo", cOperacionAlmacen.referencia_tipo)
                .AddWithValue("vReferencia_serie", cOperacionAlmacen.referencia_serie)
                .AddWithValue("vReferencia_numero", cOperacionAlmacen.referencia_numero)
                .AddWithValue("vReferencia_fecha", cOperacionAlmacen.referencia_fecha)
                .AddWithValue("vReferencia_tipo_moneda", cOperacionAlmacen.referencia_tipo_moneda)
                .AddWithValue("vReferencia_importe_total", cOperacionAlmacen.referencia_importe_total)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
            End With

            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return cOperacionAlmacen

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Function

    Private Shared Function Actualizar(ByVal cOperacionAlmacen As entOperacionAlmacen) As entOperacionAlmacen
        MySql = "INSERT INTO AUD.OPERACIONES_ALMACEN " & _
                "SELECT * FROM ALM.OPERACIONES_ALMACEN " & _
                "WHERE empresa=@vEmpresa AND almacen=@vAlmacen AND operacion=@vOperacion"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacen.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacen.operacion)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySql = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                "ejercicio=@vEjercicio,mes=@vMes,fecha_operacion=@vFecha_operacion,comentario=@vComentario,referencia_cuenta_comercial=@vReferencia_cuenta_comercial," & _
                "referencia_tipo=@vReferencia_tipo,referencia_serie=@vReferencia_serie,referencia_numero=@vReferencia_numero," & _
                "referencia_fecha=@vReferencia_fecha,referencia_tipo_moneda=@vReferencia_tipo_moneda,referencia_importe_total=@vReferencia_importe_total," & _
                "estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE empresa=@vEmpresa AND almacen=@vAlmacen AND operacion=@vOperacion"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vEjercicio", cOperacionAlmacen.ejercicio)
                    .AddWithValue("vMes", cOperacionAlmacen.mes)
                    .AddWithValue("vFecha_operacion", cOperacionAlmacen.fecha_operacion)
                    .AddWithValue("vComentario", cOperacionAlmacen.comentario)
                    .AddWithValue("vReferencia_cuenta_comercial", cOperacionAlmacen.referencia_cuenta_comercial)
                    .AddWithValue("vReferencia_tipo", cOperacionAlmacen.referencia_tipo)
                    .AddWithValue("vReferencia_serie", cOperacionAlmacen.referencia_serie)
                    .AddWithValue("vReferencia_numero", cOperacionAlmacen.referencia_numero)
                    .AddWithValue("vReferencia_fecha", cOperacionAlmacen.referencia_fecha)
                    .AddWithValue("vReferencia_tipo_moneda", cOperacionAlmacen.referencia_tipo_moneda)
                    .AddWithValue("vReferencia_importe_total", cOperacionAlmacen.referencia_importe_total)
                    .AddWithValue("vEstado", cOperacionAlmacen.estado)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vAlmacen", cOperacionAlmacen.almacen)
                    .AddWithValue("vOperacion", cOperacionAlmacen.operacion)
                End With

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cOperacionAlmacen

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function AsignarOperacion() As String

        MySql = "SELECT ISNULL(MAX(OPERACION),'') AS NUEVA_OPERACION FROM ALM.OPERACIONES_ALMACEN "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "OA0000000001"
            Else
                Correlativo = CLng(NewCode.Substring(2, 10)) + 1
                NewCode = "OA" & Right("0000000000" & Correlativo.ToString, 10)
            End If
            Return NewCode

        End Using

    End Function

    Public Shared Function Obtener(ByVal pAlmacen As String, ByVal pOperacion As String) As entOperacionAlmacen
        If Existe(pAlmacen, pOperacion) Then
            CadenaSQL = "SELECT * FROM ALM.OPERACIONES_ALMACEN " & _
                        "WHERE EMPRESA='" & MyUsuario.empresa & "' AND ALMACEN='" & pAlmacen & "' AND OPERACION='" & pOperacion & "' "
            Return Obtener(New entOperacionAlmacen, CadenaSQL)
        Else
            Return New entOperacionAlmacen
        End If
    End Function

    Private Shared Function Obtener(ByVal cOperacionAlmacen As entOperacionAlmacen, ByVal MyStringSQL As String) As entOperacionAlmacen
        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACENDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cOperacionAlmacen
                .empresa = MyDT(0).EMPRESA
                .almacen = MyDT(0).ALMACEN
                .operacion = MyDT(0).OPERACION
                .tipo_operacion = MyDT(0).TIPO_OPERACION
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .fecha_operacion = MyDT(0).FECHA_OPERACION
                .comentario = MyDT(0).COMENTARIO
                .tipo_es = MyDT(0).TIPO_ES
                .referencia_cuenta_comercial = MyDT(0).REFERENCIA_CUENTA_COMERCIAL
                .referencia_tipo = MyDT(0).REFERENCIA_TIPO
                .referencia_serie = MyDT(0).REFERENCIA_SERIE
                .referencia_numero = MyDT(0).REFERENCIA_NUMERO
                .referencia_fecha = MyDT(0).REFERENCIA_FECHA
                .referencia_tipo_moneda = MyDT(0).REFERENCIA_TIPO_MONEDA
                .referencia_importe_total = MyDT(0).REFERENCIA_IMPORTE_TOTAL
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cOperacionAlmacen
    End Function

    Public Shared Function BuscarOperacionAlmacen(ByVal pAlmacen As String, ByVal pTipoOperacion As String, ByVal pEjercicio As String, ByVal pMes As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_LISTADataTable
        Dim MyStoreProcedure As String = "ALM.OPERACIONES_ALMACEN_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen
        Dim MyParameter_3 As New SqlParameter("@TIPO_OPERACION", SqlDbType.Char, 2) : MyParameter_3.Value = pTipoOperacion
        Dim MyParameter_4 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_4.Value = pEjercicio
        Dim MyParameter_5 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_5.Value = pMes

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            MySQLCommand.Parameters.Add(MyParameter_5)

            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function Anular(ByVal pAlmacen As String, ByVal pOperacion As String, ByVal pEstado As String) As Boolean
        If Not String.IsNullOrEmpty(pOperacion) Then
            Resp = MsgBox("Confirmar proceso de anulación.", MsgBoxStyle.YesNo, "ANULAR OPERACION DE ALMACEN")
            If Resp.ToString = vbYes Then
                Call CambiarEstado(pAlmacen, pOperacion, pEstado)
                Return True
            End If
        End If
    End Function

    Public Shared Sub CambiarEstado(ByVal pAlmacen As String, ByVal pOperacion As String, ByVal pEstado As String)
        MySql = "UPDATE ALM.OPERACIONES_ALMACEN SET Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)

            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Sub

    Public Shared Function Grabar(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As entOperacionAlmacenDetalle
        Dim MismoProducto As Boolean = False
        Dim MismoLote As Boolean = False
        With cOperacionAlmacenDetalle
            If String.IsNullOrEmpty(.producto) Then Throw New BusinessException(MSG000 & " PRODUCTO")
            If .cantidad = 0 Then Throw New BusinessException(MSG000 & " CANTIDAD")

            If .producto_anterior.Trim = .producto.Trim Then MismoProducto = True
            If .numero_lote_anterior.Trim = .numero_lote.Trim Then MismoLote = True

            If .exige_lote = "SI" Then
                If String.IsNullOrEmpty(.numero_lote) Then Throw New BusinessException(MSG000 & " NRO. LOTE")
                If .numero_lote = "0000000000" Then Throw New BusinessException(MSG000 & " NRO. LOTE")
                If Year(.fecha_vencimiento) * 100 + Month(.fecha_vencimiento) = 190001 Then Throw New BusinessException(MSG000 & " F. VCMTO.")
            End If
        End With

        If String.IsNullOrEmpty(cOperacionAlmacenDetalle.linea.Trim) Then
            Return Insertar(cOperacionAlmacenDetalle)
        Else
            If MismoProducto = True And MismoLote = True Then
                Return ActualizarMismoProductoLote(cOperacionAlmacenDetalle)
            Else
                Return ActualizarOtroProductoLote(cOperacionAlmacenDetalle)
            End If
        End If
    End Function

    Private Shared Function Insertar(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As entOperacionAlmacenDetalle
        Dim SiExisteResumenAlmacen As Boolean = EvaluarSiExisteResumenAlmacen(cOperacionAlmacenDetalle)
        Dim SiExisteResumenPeriodo As Boolean = EvaluarSiExisteResumenPeriodo(cOperacionAlmacenDetalle)

        cOperacionAlmacenDetalle.linea = AsignarLinea(cOperacionAlmacenDetalle.empresa, cOperacionAlmacenDetalle.operacion, "I")
        MySql = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                "(empresa,almacen,operacion,linea,producto,cantidad,precio_unitario,numero_serie,numero_lote," & _
                "tipo_es,ejercicio,mes,fecha_vencimiento,comentario,usuario_registro) " & _
                "VALUES " & _
                "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vPrecio_unitario,@vNumero_serie,@vNumero_lote," & _
                "@vTipo_es,@vEjercicio,@vMes,@vFecha_vencimiento,@vComentario,@vUsuario_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
                .AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                .AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                .AddWithValue("vPrecio_unitario", cOperacionAlmacenDetalle.precio_unitario)
                .AddWithValue("vNumero_serie", cOperacionAlmacenDetalle.numero_serie)
                .AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                .AddWithValue("vTipo_es", cOperacionAlmacenDetalle.tipo_es)
                .AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                .AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                .AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                .AddWithValue("vComentario", cOperacionAlmacenDetalle.comentario)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
            End With

            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                If SiExisteResumenAlmacen = True Then
                    MySql = "UPDATE ALM.RESUMEN_X_ALMACEN SET Fecha_vencimiento=@vFecha_vencimiento, " & _
                            IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                            "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                            "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                Else
                    MySql = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                            "(empresa,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                            "VALUES " & _
                            "(@vEmpresa,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", cOperacionAlmacenDetalle.empresa)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                    MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(cOperacionAlmacenDetalle.tipo_es = "I", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(cOperacionAlmacenDetalle.tipo_es = "S", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End If

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                If SiExisteResumenPeriodo = True Then
                    MySql = "UPDATE ALM.RESUMEN_X_PERIODO SET Fecha_vencimiento=@vFecha_vencimiento," & _
                            IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                            "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                            "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento.Date)
                    MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                Else
                    MySql = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                            "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                            "VALUES " & _
                            "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", cOperacionAlmacenDetalle.empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                    MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(cOperacionAlmacenDetalle.tipo_es = "I", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(cOperacionAlmacenDetalle.tipo_es = "S", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento.Date)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End If

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return cOperacionAlmacenDetalle

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Function

    Private Shared Function ActualizarMismoProductoLote(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As entOperacionAlmacenDetalle
        MySql = "INSERT INTO AUD.OPERACIONES_ALMACEN_DET " & _
                "SELECT * FROM ALM.OPERACIONES_ALMACEN_DET " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySql = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                        "Cantidad=@vCantidad, Precio_unitario=@vPrecio_unitario," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

                MySQLCommand.CommandText = MySql
                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    .AddWithValue("vPrecio_unitario", cOperacionAlmacenDetalle.precio_unitario)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                    .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySql = "UPDATE ALM.RESUMEN_X_ALMACEN SET Fecha_vencimiento=@vFecha_vencimiento, " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()
                MySQLCommand.CommandText = MySql

                MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad - cOperacionAlmacenDetalle.cantidad_anterior)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)

                MySQLCommand.ExecuteNonQuery()

                MySql = "UPDATE ALM.RESUMEN_X_PERIODO SET Fecha_vencimiento=@vFecha_vencimiento, " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()
                MySQLCommand.CommandText = MySql

                MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad - cOperacionAlmacenDetalle.cantidad_anterior)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cOperacionAlmacenDetalle

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function ActualizarOtroProductoLote(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As entOperacionAlmacenDetalle
        Dim SiExisteResumenAlmacen As Boolean = EvaluarSiExisteResumenAlmacen(cOperacionAlmacenDetalle)
        Dim SiExisteResumenPeriodo As Boolean = EvaluarSiExisteResumenPeriodo(cOperacionAlmacenDetalle)

        MySql = "INSERT INTO AUD.OPERACIONES_ALMACEN_DET " & _
                "SELECT * FROM ALM.OPERACIONES_ALMACEN_DET " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySql = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                        "Producto=@vProducto,Numero_serie=@vNumero_serie,Numero_lote=@vNumero_lote,Fecha_vencimiento=@vFecha_vencimiento," & _
                        "Cantidad=@vCantidad, Precio_unitario=@vPrecio_unitario," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()
                MySQLCommand.CommandText = MySql

                With MySQLCommand.Parameters
                    .AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                    .AddWithValue("vNumero_serie", cOperacionAlmacenDetalle.numero_serie)
                    .AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    .AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    .AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    .AddWithValue("vPrecio_unitario", cOperacionAlmacenDetalle.precio_unitario)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                    .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                If SiExisteResumenAlmacen = True Then
                    MySql = "UPDATE ALM.RESUMEN_X_ALMACEN SET Fecha_vencimiento=@vFecha_vencimiento, " & _
                            IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                            "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                            "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                Else
                    MySql = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                            "(empresa,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                            "VALUES " & _
                            "(@vEmpresa,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", cOperacionAlmacenDetalle.empresa)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                    MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(cOperacionAlmacenDetalle.tipo_es = "I", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(cOperacionAlmacenDetalle.tipo_es = "S", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End If

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                MySql = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "-@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad_anterior)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote_anterior)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto_anterior)

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                If SiExisteResumenPeriodo = True Then
                    MySql = "UPDATE ALM.RESUMEN_X_PERIODO SET Fecha_vencimiento=@vFecha_vencimiento, " & _
                            IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "+@vCantidad," & _
                            "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                            "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento)
                    MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                Else
                    MySql = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                            "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                            "VALUES " & _
                            "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                    MySQLCommand.CommandText = MySql
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", cOperacionAlmacenDetalle.empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                    MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                    MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)
                    MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(cOperacionAlmacenDetalle.tipo_es = "I", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(cOperacionAlmacenDetalle.tipo_es = "S", cOperacionAlmacenDetalle.cantidad, 0))
                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", cOperacionAlmacenDetalle.fecha_vencimiento.Date)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End If

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                MySql = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "-@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad_anterior)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote_anterior)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto_anterior)

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cOperacionAlmacenDetalle

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function AsignarLinea(ByVal pEmpresa As String, ByVal pOperacion As String, ByVal pTipo As String) As String

        Dim MySql As String = "SELECT ISNULL(MAX(LINEA),'') AS NUEVA_LINEA FROM ALM.OPERACIONES_ALMACEN_DET " & _
                              "WHERE EMPRESA='" & pEmpresa & "' AND OPERACION='" & pOperacion & "'"
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewLine As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewLine.Trim) Then
                NewLine = "001"
            Else
                Correlativo = CLng(NewLine) + 1
                NewLine = Right("000" & Correlativo.ToString.Trim, 3)
            End If
            Return NewLine

        End Using

    End Function

    Public Shared Function ObtenerDetalles(ByVal pAlmacen As String, ByVal pOperacion As String) As dsOperacionesAlmacen.DETALLES_OPERACIONDataTable
        MySql = "SELECT D.LINEA,D.PRODUCTO,P.DESCRIPCION_AMPLIADA,D.NUMERO_LOTE,D.FECHA_VENCIMIENTO,D.CANTIDAD,D.PRECIO_UNITARIO,P.INDICA_LOTE " & _
                "FROM ALM.OPERACIONES_ALMACEN_DET AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA=P.EMPRESA AND D.PRODUCTO=P.PRODUCTO " & _
                "WHERE D.EMPRESA=@vEmpresa AND D.ALMACEN=@vAlmacen AND D.OPERACION=@vOperacion"

        Dim MyDT As New dsOperacionesAlmacen.DETALLES_OPERACIONDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Sub ActualizarImporteTotal(ByVal pAlmacen As String, ByVal pOperacion As String, ByVal ImporteTotal As Decimal)

        MySql = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                "Referencia_importe_total=@vReferencia_importe_total " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vReferencia_importe_total", ImporteTotal)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", pAlmacen)
                .AddWithValue("vOperacion", pOperacion)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Sub

    Public Shared Function Descartar(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As Boolean
        If Existe(cOperacionAlmacenDetalle) Then
            Return Eliminar(cOperacionAlmacenDetalle)
        Else
            Return False
        End If
    End Function

    Private Shared Function Eliminar(ByVal cOperacionAlmacenDetalle As entOperacionAlmacenDetalle) As Boolean
        MySql = "INSERT INTO AUD.OPERACIONES_ALMACEN_DET " & _
                "SELECT * FROM ALM.OPERACIONES_ALMACEN_DET " & _
                "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySql = "DELETE FROM ALM.OPERACIONES_ALMACEN_DET " & _
                        "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion AND Linea=@vLinea "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()
                MySQLCommand.CommandText = MySql

                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                    .AddWithValue("vOperacion", cOperacionAlmacenDetalle.operacion)
                    .AddWithValue("vLinea", cOperacionAlmacenDetalle.linea)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                MySql = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "-@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)

                MySQLCommand.ExecuteNonQuery()

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.Parameters.Clear()

                MySql = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                        IIf(cOperacionAlmacenDetalle.tipo_es = "I", "Ingresos=Ingresos", "Egresos=Egresos") & "-@vCantidad," & _
                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.AddWithValue("vCantidad", cOperacionAlmacenDetalle.cantidad)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cOperacionAlmacenDetalle.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cOperacionAlmacenDetalle.mes)
                MySQLCommand.Parameters.AddWithValue("vAlmacen", cOperacionAlmacenDetalle.almacen)
                MySQLCommand.Parameters.AddWithValue("vNumero_lote", cOperacionAlmacenDetalle.numero_lote)
                MySQLCommand.Parameters.AddWithValue("vProducto", cOperacionAlmacenDetalle.producto)

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return True

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function BuscarStock(ByVal pAlmacen As String, ByVal pProducto As String) As dsStockAlmacen.STOCK_X_PRODUCTODataTable
        Dim MyStoreProcedure As String = "ALM.STOCK_PRODUCTO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen
        Dim MyParameter_3 As New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto

        Dim MyDT As New dsStockAlmacen.STOCK_X_PRODUCTODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarStockCompuesto(ByVal pAlmacen As String, ByVal pProducto As String) As dsStockAlmacen.STOCK_X_COMPUESTODataTable
        Dim MyStoreProcedure As String = "ALM.STOCK_COMPUESTO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen
        Dim MyParameter_3 As New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto

        Dim MyDT As New dsStockAlmacen.STOCK_X_COMPUESTODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function StockAlmacen(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String) As dsStockAlmacen.STOCK_ALMACENDataTable
        MySql = "SELECT R.PRODUCTO, P.DESCRIPCION_AMPLIADA AS DESCRIPCION, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO, " & _
                "STOCK_INICIAL=SUM(CASE WHEN R.MES<@vMes THEN R.INGRESOS-R.EGRESOS ELSE 0 END)," & _
                "INGRESOS=SUM(CASE WHEN R.MES=@vMes THEN R.INGRESOS ELSE 0 END)," & _
                "EGRESOS=SUM(CASE WHEN R.MES=@vMes THEN R.EGRESOS ELSE 0 END)," & _
                "STOCK_FINAL=SUM(R.INGRESOS-R.EGRESOS) " & _
                "FROM ALM.RESUMEN_X_PERIODO AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO " & _
                "WHERE R.EMPRESA=@vEmpresa AND R.EJERCICIO=@vEjercicio AND R.MES<=@vMes AND R.ALMACEN=@vAlmacen " & _
                "GROUP BY R.PRODUCTO, P.DESCRIPCION_AMPLIADA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO "

        Dim MyDT As New dsStockAlmacen.STOCK_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function StockAlmacenRango(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String, ByVal pProductoInicial As String, ByVal pProductoFinal As String) As dsStockAlmacen.STOCK_ALMACENDataTable
        MySql = "SELECT R.PRODUCTO, P.DESCRIPCION_AMPLIADA AS DESCRIPCION, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO, " & _
                "STOCK_INICIAL=SUM(CASE WHEN R.MES<'11' THEN R.INGRESOS-R.EGRESOS ELSE 0 END)," & _
                "INGRESOS=SUM(CASE WHEN R.MES='11' THEN R.INGRESOS ELSE 0 END)," & _
                "EGRESOS=SUM(CASE WHEN R.MES='11' THEN R.EGRESOS ELSE 0 END)," & _
                "STOCK_FINAL=SUM(R.INGRESOS-R.EGRESOS) " & _
                "FROM ALM.RESUMEN_X_PERIODO AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO " & _
                "WHERE R.EMPRESA=@vEmpresa AND R.EJERCICIO=@vEjercicio AND R.MES<=@vMes AND R.ALMACEN=@vAlmacen " & _
                "AND (R.PRODUCTO BETWEEN @vProductoInicial AND @vProductoFinal) " & _
                "GROUP BY R.PRODUCTO, P.DESCRIPCION_AMPLIADA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO "

        Dim MyDT As New dsStockAlmacen.STOCK_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vProductoInicial", pProductoInicial)
            MySQLCommand.Parameters.AddWithValue("vProductoFinal", pProductoFinal)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
