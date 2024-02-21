Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalOrdenPedido
    Private Shared MySql As String

    Private Shared Function Existe(ByVal cOrdenPedido As entOrdenPedido) As Boolean
        MySql = "SELECT COUNT(*) FROM COM.ORDEN_PEDIDO WHERE EMPRESA=@vEmpresa AND ORDEN_PEDIDO=@vOrden_pedido"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", cOrdenPedido.orden_pedido)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As Boolean
        MySql = "SELECT COUNT(*) FROM COM.ORDEN_PEDIDO_DET " & _
                "WHERE EMPRESA=@vEmpresa AND ORDEN_PEDIDO=@vOrden_pedido AND PRODUCTO=@vProducto"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
            MySQLCommand.Parameters.AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal pOrdenPedido As String) As Boolean
        MySql = "SELECT COUNT(*) FROM COM.ORDEN_PEDIDO WHERE EMPRESA=@vEmpresa AND ORDEN_PEDIDO=@vOrden_pedido"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", pOrdenPedido)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Grabar(ByVal cOrdenPedido As entOrdenPedido) As entOrdenPedido
        With cOrdenPedido
            If Year(.orden_fecha) * 100 + Month(.orden_fecha) = 190001 Then Throw New BusinessException(MSG000 & " FEC. PEDIDO")
            If String.IsNullOrEmpty(.codigo_vendedor) Then Throw New BusinessException(MSG000 & " CODIGO")
            If String.IsNullOrEmpty(.cuenta_comercial) Then Throw New BusinessException(MSG000 & " DNI/RUC")
            If Year(.pago_fecha) * 100 + Month(.pago_fecha) = 190001 Then Throw New BusinessException(MSG000 & " FEC. PAGO")
            'If .pago_importe = 0 Then Throw New BusinessException(MSG000 & " IMPORTE")
            If .pago_tipo = "20" Then 'Deposito bancario
                If String.IsNullOrEmpty(.pago_referencia.Trim) Then Throw New BusinessException(MSG000 & " REFERENCIA")
            End If
        End With

        If String.IsNullOrEmpty(cOrdenPedido.orden_pedido) Then
            Return Insertar(cOrdenPedido)
        Else
            If Existe(cOrdenPedido) Then
                Return Actualizar(cOrdenPedido)
            End If
        End If
    End Function

    Private Shared Function Insertar(ByVal cOrdenPedido As entOrdenPedido) As entOrdenPedido
        cOrdenPedido.orden_pedido = AsignarOrden()

        MySql = "INSERT INTO COM.ORDEN_PEDIDO " & _
                "(empresa,orden_pedido,ejercicio,mes,cuenta_comercial,orden_fecha,codigo_vendedor,centro_distribucion,lista_precio," & _
                "importe_total_me,importe_total_mn,pago_tipo,pago_banco,pago_moneda,pago_fecha,pago_importe,pago_referencia," & _
                "indica_primera_compra,indica_ascenso,indica_mantenimiento,indica_compra_extra,comentario,estado,usuario_registro,tipo_cambio) " & _
                "VALUES (" & _
                "@vEmpresa,@vOrden_pedido,@vEjercicio,@vMes,@vCuenta_comercial,@vOrden_fecha,@vCodigo_vendedor,@vCentro_distribucion,@vLista_precio," & _
                "@vImporte_total_me,@vImporte_total_mn,@vPago_tipo,@vPago_banco,@vPago_moneda,@vPago_fecha,@vPago_importe,@vPago_referencia," & _
                "@vIndica_primera_compra,@vIndica_ascenso,@vIndica_mantenimiento,@vIndica_compra_extra,@vComentario,@vEstado,@vUsuario_registro,@vTipo_cambio) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", cOrdenPedido.orden_pedido)
                .AddWithValue("vEjercicio", cOrdenPedido.ejercicio)
                .AddWithValue("vMes", cOrdenPedido.mes)
                .AddWithValue("vCuenta_comercial", cOrdenPedido.cuenta_comercial.Trim)
                .AddWithValue("vOrden_fecha", cOrdenPedido.orden_fecha)
                .AddWithValue("vCodigo_vendedor", cOrdenPedido.codigo_vendedor)
                .AddWithValue("vCentro_distribucion", cOrdenPedido.centro_distribucion)
                .AddWithValue("vLista_precio", cOrdenPedido.lista_precio)
                .AddWithValue("vImporte_total_me", cOrdenPedido.importe_total_me)
                .AddWithValue("vImporte_total_mn", cOrdenPedido.importe_total_mn)
                .AddWithValue("vPago_tipo", cOrdenPedido.pago_tipo)
                .AddWithValue("vPago_banco", cOrdenPedido.pago_banco)
                .AddWithValue("vPago_moneda", cOrdenPedido.pago_moneda)
                .AddWithValue("vPago_fecha", cOrdenPedido.pago_fecha)
                .AddWithValue("vPago_importe", cOrdenPedido.pago_importe)
                .AddWithValue("vPago_referencia", cOrdenPedido.pago_referencia)
                .AddWithValue("vIndica_primera_compra", cOrdenPedido.indica_primera_compra)
                .AddWithValue("vIndica_ascenso", cOrdenPedido.indica_ascenso)
                .AddWithValue("vIndica_mantenimiento", cOrdenPedido.indica_mantenimiento)
                .AddWithValue("vIndica_compra_extra", cOrdenPedido.indica_compra_extra)
                .AddWithValue("vComentario", cOrdenPedido.comentario)
                .AddWithValue("vEstado", cOrdenPedido.estado)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                .AddWithValue("vTipo_cambio", cOrdenPedido.tipo_cambio)
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

                Return cOrdenPedido

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

    Private Shared Function AsignarOrden() As String

        Dim MySql As String = "SELECT ISNULL(MAX(ORDEN_PEDIDO),'') AS NUEVO_CODIGO FROM COM.ORDEN_PEDIDO "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "OP0000000001"
            Else
                Correlativo = CLng(NewCode.Substring(2, 10)) + 1
                NewCode = "OP" & Right("0000000000" & Correlativo.ToString, 10)
            End If
            Return NewCode

        End Using

    End Function

    Private Shared Function Actualizar(ByVal cOrdenPedido As entOrdenPedido) As entOrdenPedido

        MySql = "INSERT INTO AUD.ORDEN_PEDIDO " & _
                "SELECT * FROM  COM.ORDEN_PEDIDO " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", cOrdenPedido.orden_pedido)
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

                MySql = "UPDATE COM.ORDEN_PEDIDO SET " & _
                "Ejercicio=@vEjercicio,Mes=@vMes,Cuenta_comercial=@vCuenta_comercial,Centro_distribucion=@vCentro_distribucion," & _
                "Codigo_vendedor=@vCodigo_vendedor,Lista_precio=@vLista_precio,Importe_total_me=@vImporte_total_me,Importe_total_mn=@vImporte_total_mn," & _
                "Pago_tipo=@vPago_tipo,Pago_banco=@vPago_banco,Pago_moneda=@vPago_moneda,Pago_fecha=@vPago_fecha,Pago_importe=@vPago_importe," & _
                "Pago_referencia=@vPago_referencia,Indica_primera_compra=@vIndica_primera_compra,Indica_ascenso=@vIndica_ascenso," & _
                "Indica_mantenimiento=@vIndica_mantenimiento,Indica_compra_extra=@vIndica_compra_extra,Comentario=@vComentario,Estado=@vEstado,Tipo_cambio=@vTipo_cambio," & _
                "Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vEjercicio", cOrdenPedido.ejercicio)
                    .AddWithValue("vMes", cOrdenPedido.mes)
                    .AddWithValue("vCuenta_comercial", cOrdenPedido.cuenta_comercial.Trim)
                    .AddWithValue("vCentro_distribucion", cOrdenPedido.centro_distribucion)
                    .AddWithValue("vOrden_fecha", cOrdenPedido.orden_fecha)
                    .AddWithValue("vCodigo_vendedor", cOrdenPedido.codigo_vendedor)
                    .AddWithValue("vLista_precio", cOrdenPedido.lista_precio)
                    .AddWithValue("vImporte_total_me", cOrdenPedido.importe_total_me)
                    .AddWithValue("vImporte_total_mn", cOrdenPedido.importe_total_mn)
                    .AddWithValue("vPago_tipo", cOrdenPedido.pago_tipo)
                    .AddWithValue("vPago_banco", cOrdenPedido.pago_banco)
                    .AddWithValue("vPago_moneda", cOrdenPedido.pago_moneda)
                    .AddWithValue("vPago_fecha", cOrdenPedido.pago_fecha)
                    .AddWithValue("vPago_importe", cOrdenPedido.pago_importe)
                    .AddWithValue("vPago_referencia", cOrdenPedido.pago_referencia)
                    .AddWithValue("vIndica_primera_compra", cOrdenPedido.indica_primera_compra)
                    .AddWithValue("vIndica_ascenso", cOrdenPedido.indica_ascenso)
                    .AddWithValue("vIndica_mantenimiento", cOrdenPedido.indica_mantenimiento)
                    .AddWithValue("vIndica_compra_extra", cOrdenPedido.indica_compra_extra)
                    .AddWithValue("vComentario", cOrdenPedido.comentario)
                    .AddWithValue("vEstado", cOrdenPedido.estado)
                    .AddWithValue("vTipo_cambio", cOrdenPedido.tipo_cambio)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vOrden_pedido", cOrdenPedido.orden_pedido)
                End With

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cOrdenPedido

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

    Public Shared Sub AnularActivar(ByVal pOrdenPedido As String)

        MySql = "INSERT INTO AUD.ORDEN_PEDIDO " & _
                "SELECT * FROM  COM.ORDEN_PEDIDO " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", pOrdenPedido)
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

                MySql = "UPDATE COM.ORDEN_PEDIDO SET " & _
                "Estado=CASE WHEN Estado='N' THEN 'A' ELSE 'N' END," & _
                "Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vOrden_pedido", pOrdenPedido)
                End With

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

    Public Shared Function Grabar(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As entOrdenPedidoDetalle
        With cOrdenPedidoDetalle
            If String.IsNullOrEmpty(.producto) Then Throw New BusinessException(MSG000 & " PRODUCTO")
            If .cantidad = 0 Then Throw New BusinessException(MSG000 & " CANTIDAD")
        End With

        If Not Existe(cOrdenPedidoDetalle) Then
            Return Insertar(cOrdenPedidoDetalle)
        Else
            Return Actualizar(cOrdenPedidoDetalle)
        End If
    End Function

    Public Shared Function Descartar(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As Boolean
        If Existe(cOrdenPedidoDetalle) Then
            Return Eliminar(cOrdenPedidoDetalle)
        Else
            Return False
        End If
    End Function

    Private Shared Function Insertar(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As entOrdenPedidoDetalle

        MySql = "INSERT INTO COM.ORDEN_PEDIDO_DET " & _
                "(empresa,orden_pedido,producto,cantidad,precio_unitario_mn,precio_unitario_me," & _
                "importe_total_mn,importe_total_me,comentario,estado,usuario_registro) " & _
                "VALUES (" & _
                "@vEmpresa,@vOrden_pedido,@vProducto,@vCantidad,@vPrecio_unitario_mn,@vPrecio_unitario_me," & _
                "@vImporte_total_mn,@vImporte_total_me,@vComentario,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
                .AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
                .AddWithValue("vCantidad", cOrdenPedidoDetalle.cantidad)
                .AddWithValue("vPrecio_unitario_mn", cOrdenPedidoDetalle.precio_unitario_mn)
                .AddWithValue("vPrecio_unitario_me", cOrdenPedidoDetalle.precio_unitario_me)
                .AddWithValue("vImporte_total_mn", cOrdenPedidoDetalle.importe_total_mn)
                .AddWithValue("vImporte_total_me", cOrdenPedidoDetalle.importe_total_me)
                .AddWithValue("vComentario", cOrdenPedidoDetalle.comentario)
                .AddWithValue("vEstado", cOrdenPedidoDetalle.estado)
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

                Return cOrdenPedidoDetalle

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

    Private Shared Function Actualizar(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As entOrdenPedidoDetalle
        MySql = "INSERT INTO AUD.ORDEN_PEDIDO_DET " & _
                "SELECT * FROM  COM.ORDEN_PEDIDO_DET " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido AND Producto=@vProducto "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
                .AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
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

                MySql = "UPDATE COM.ORDEN_PEDIDO_DET SET " & _
                        "Cantidad=@vCantidad,Precio_unitario_mn=@vPrecio_unitario_mn,Precio_unitario_me=@vPrecio_unitario_me," & _
                        "Importe_total_mn=@vImporte_total_mn,Importe_total_me=@vImporte_total_me,Comentario=@vComentario,Estado=@vEstado," & _
                        "Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                        "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido AND Producto=@vProducto "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vCantidad", cOrdenPedidoDetalle.cantidad)
                    .AddWithValue("vPrecio_unitario_mn", cOrdenPedidoDetalle.precio_unitario_mn)
                    .AddWithValue("vPrecio_unitario_me", cOrdenPedidoDetalle.precio_unitario_me)
                    .AddWithValue("vImporte_total_mn", cOrdenPedidoDetalle.importe_total_mn)
                    .AddWithValue("vImporte_total_me", cOrdenPedidoDetalle.importe_total_me)
                    .AddWithValue("vComentario", cOrdenPedidoDetalle.comentario)
                    .AddWithValue("vEstado", cOrdenPedidoDetalle.estado)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
                    .AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
                End With

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cOrdenPedidoDetalle

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

    Private Shared Function Eliminar(ByVal cOrdenPedidoDetalle As entOrdenPedidoDetalle) As Boolean
        MySql = "INSERT INTO AUD.ORDEN_PEDIDO_DET " & _
                "SELECT * FROM  COM.ORDEN_PEDIDO_DET " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido AND Producto=@vProducto "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
                .AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
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

                MySql = "DELETE FROM COM.ORDEN_PEDIDO_DET " & _
                        "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido AND Producto=@vProducto "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vOrden_pedido", cOrdenPedidoDetalle.orden_pedido)
                    .AddWithValue("vProducto", cOrdenPedidoDetalle.producto)
                End With

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

    Public Shared Function ObtenerDetalles(ByVal pOrdenPedido As String) As dsOrdenPedido.DETALLES_PEDIDODataTable
        MySql = "SELECT D.EMPRESA, D.ORDEN_PEDIDO, D.PRODUCTO, P.DESCRIPCION, P.DESCRIPCION_AMPLIADA, P.INDICA_COMPUESTO, " & _
                "P.INDICA_VALIDA_STOCK, D.CANTIDAD, D.PRECIO_UNITARIO_ME, D.IMPORTE_TOTAL_ME, D.VENTA, D.VENTA_LINEA " & _
                "FROM COM.ORDEN_PEDIDO_DET AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA=P.EMPRESA AND D.PRODUCTO=P.PRODUCTO " & _
                "WHERE D.EMPRESA=@vEmpresa AND D.ORDEN_PEDIDO=@vOrden_pedido "

        Dim MyDT As New dsOrdenPedido.DETALLES_PEDIDODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", pOrdenPedido)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetalle(ByVal pOrdenPedido As String, ByVal pProducto As String) As dsOrdenPedido.DETALLES_PEDIDODataTable
        MySql = "SELECT D.EMPRESA, D.ORDEN_PEDIDO, D.PRODUCTO, P.DESCRIPCION, P.DESCRIPCION_AMPLIADA, " & _
                "D.CANTIDAD, D.PRECIO_UNITARIO_ME, D.IMPORTE_TOTAL_ME " & _
                "FROM COM.ORDEN_PEDIDO_DET AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA=P.EMPRESA AND D.PRODUCTO=P.PRODUCTO " & _
                "WHERE D.EMPRESA=@vEmpresa AND D.ORDEN_PEDIDO=@vOrden_pedido AND D.PRODUCTO=@vProducto "

        Dim MyDT As New dsOrdenPedido.DETALLES_PEDIDODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", pOrdenPedido)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetallesPendienteVenta(ByVal pOrdenPedido As String) As dsOrdenPedido.DETALLES_PEDIDODataTable
        MySql = "SELECT D.EMPRESA, D.ORDEN_PEDIDO, D.PRODUCTO, P.DESCRIPCION, P.DESCRIPCION_AMPLIADA, P.INDICA_COMPUESTO, P.INDICA_VALIDA_STOCK, " & _
                "D.CANTIDAD-D.VENTA_CANTIDAD AS CANTIDAD, D.PRECIO_UNITARIO_ME, D.IMPORTE_TOTAL_ME, D.VENTA, D.VENTA_LINEA " & _
                "FROM COM.ORDEN_PEDIDO_DET AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA=P.EMPRESA AND D.PRODUCTO=P.PRODUCTO " & _
                "WHERE D.EMPRESA=@vEmpresa AND D.ORDEN_PEDIDO=@vOrden_pedido AND D.CANTIDAD-D.VENTA_CANTIDAD>0 " & _
                "ORDER BY D.FECHA_REGISTRO"

        Dim MyDT As New dsOrdenPedido.DETALLES_PEDIDODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOrden_pedido", pOrdenPedido)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerPedidosPendientes(ByVal pCuentaComercial As String) As dsOrdenPedido.ORDEN_PEDIDO_PENDIENTESDataTable
        MySql = "SELECT EMPRESA, ORDEN_PEDIDO, PAGO_FECHA, PAGO_BANCO, PAGO_MONEDA, PAGO_IMPORTE, " & _
                "PAGO_REFERENCIA, ESTADO, USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA " & _
                "FROM COM.ORDEN_PEDIDO_PENDIENTES " & _
                "WHERE EMPRESA=@vEmpresa AND CUENTA_COMERCIAL=@vCuenta_Comercial " & _
                "ORDER BY PAGO_FECHA "

        Dim MyDT As New dsOrdenPedido.ORDEN_PEDIDO_PENDIENTESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vCuenta_Comercial", pCuentaComercial)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function PedidosPorConsultar(ByVal pEjercicio As String, ByVal pMes As String, ByVal pConsultor As String, ByVal pCriterio1 As String, ByVal pCriterio2 As String, ByVal pCriterio3 As String) As dsOrdenPedido.ORDEN_PEDIDO_LISTADataTable
        Dim nCriterio1 As String = Nothing
        Dim nCriterio2 As String = Nothing
        Dim nCriterio3 As String = Nothing

        Select Case pCriterio1
            Case Is = "PERIODO"
                nCriterio1 = Space(1)
            Case Is = "CONSULTOR"
                If pConsultor.Trim.Length <> 0 Then
                    nCriterio1 = "AND O.CODIGO_VENDEDOR=@vCodigo_vendedor "
                Else
                    nCriterio1 = Space(1)
                End If
        End Select

        Select Case pCriterio2
            Case Is = "FACTURADAS"
                nCriterio2 = "AND R.CANTIDAD_CONTROL=0 "
            Case Is = "POR FACTURAR"
                nCriterio2 = "AND R.CANTIDAD_CONTROL<>0 "
            Case Else
                nCriterio2 = Space(1)
        End Select

        Select Case pCriterio3
            Case Is = "BOLETA"
                nCriterio3 = "AND CC.TIPO_DOCUMENTO<>'06' "
            Case Is = "FACTURA"
                nCriterio3 = "AND CC.TIPO_DOCUMENTO='06' "
            Case Else
                nCriterio3 = Space(1)
        End Select

        MySql = "SELECT O.ORDEN_PEDIDO,O.ORDEN_FECHA,CC.RAZON_SOCIAL, O.CODIGO_VENDEDOR AS VENDEDOR,ISNULL(V.DESCRIPCION,SPACE(1)) AS VENDEDOR_NOMBRE,PT.NOMBRE_LARGO AS PAGO_TIPO," & _
                "PB.NOMBRE_CORTO AS PAGO_BANCO,PM.TEXTO_01 AS PAGO_MONEDA,O.PAGO_FECHA,O.PAGO_IMPORTE,O.PAGO_REFERENCIA,O.ESTADO " & _
                "FROM COM.ORDEN_X_FACTURAR_RESUMEN AS R INNER JOIN " & _
                "COM.ORDEN_PEDIDO AS O ON R.EMPRESA=O.EMPRESA AND R.ORDEN_PEDIDO=O.ORDEN_PEDIDO INNER JOIN " & _
                "COM.CUENTAS_COMERCIALES AS CC ON O.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL LEFT OUTER JOIN " & _
                "GEN.TABLA_VENDEDORES AS V ON O.CODIGO_VENDEDOR = V.CODIGO INNER JOIN " & _
                "GEN.TABLAS_DETALLE AS PT ON O.EMPRESA = PT.EMPRESA AND O.PAGO_TIPO = PT.CODIGO_ITEM AND PT.CODIGO_TABLA = 'COM_FORMA_PAGO' INNER JOIN " & _
                "GEN.TABLAS_DETALLE AS PB ON O.EMPRESA = PB.EMPRESA AND O.PAGO_BANCO = PB.CODIGO_ITEM AND PB.CODIGO_TABLA = '_ENTIDAD_FINANCIERA' INNER JOIN " & _
                "GEN.TABLAS_DETALLE AS PM ON O.EMPRESA = PM.EMPRESA AND O.PAGO_MONEDA = PM.CODIGO_ITEM AND PM.CODIGO_TABLA = '_TIPO_MONEDA' " & _
                "WHERE O.EMPRESA=@vEmpresa AND O.EJERCICIO=@vEjercicio AND O.MES=@vMes " & _
                nCriterio1 & nCriterio2 & nCriterio3 & _
                "ORDER BY O.ORDEN_PEDIDO DESC"

        Dim MyDT As New dsOrdenPedido.ORDEN_PEDIDO_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            If pConsultor.Trim.Length <> 0 Then MySQLCommand.Parameters.AddWithValue("vCodigo_vendedor", pConsultor)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ConsultoresPorPeriodo(ByVal pEjercicio As String, ByVal pMes As String) As dsTablasGenericas.LISTADataTable
        MySql = "SELECT 'CONSULTORES' AS TABLA, O.CODIGO_VENDEDOR AS CODIGO, V.DESCRIPCION AS DESCRIPCION " & _
                "FROM COM.ORDEN_PEDIDO AS O INNER JOIN " & _
                "GEN.TABLA_VENDEDORES AS V ON O.CODIGO_VENDEDOR = V.CODIGO " & _
                "WHERE O.EMPRESA=@vEmpresa AND O.EJERCICIO=@vEjercicio AND O.MES=@vMes " & _
                "GROUP BY O.CODIGO_VENDEDOR, V.DESCRIPCION " & _
                "ORDER BY V.DESCRIPCION "

        Dim MyDT As New dsTablasGenericas.LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySql
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function Obtener(ByVal pOrdenPedido As String) As entOrdenPedido
        If Existe(pOrdenPedido) Then
            CadenaSQL = "SELECT * FROM COM.ORDEN_PEDIDO " & _
                        "WHERE EMPRESA='" & MyUsuario.empresa & "' AND ORDEN_PEDIDO='" & pOrdenPedido & "'"
            Return Obtener(New entOrdenPedido, CadenaSQL)
        Else
            Return New entOrdenPedido
        End If
    End Function

    Private Shared Function Obtener(ByVal cOrdenPedido As entOrdenPedido, ByVal MyStringSQL As String) As entOrdenPedido
        Dim MyDT As New dsOrdenPedido.ORDEN_PEDIDODataTable
        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        If MyDT.Count > 0 Then
            With cOrdenPedido
                .empresa = MyDT(0).EMPRESA
                .orden_pedido = MyDT(0).ORDEN_PEDIDO
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .orden_fecha = MyDT(0).ORDEN_FECHA
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .centro_distribucion = MyDT(0).CENTRO_DISTRIBUCION
                .lista_precio = MyDT(0).LISTA_PRECIO
                .importe_total_me = MyDT(0).IMPORTE_TOTAL_ME
                .importe_total_mn = MyDT(0).IMPORTE_TOTAL_MN
                .pago_tipo = MyDT(0).PAGO_TIPO
                .pago_banco = MyDT(0).PAGO_BANCO
                .pago_moneda = MyDT(0).PAGO_MONEDA
                If Not MyDT(0).IsNull("PAGO_FECHA") Then .pago_fecha = MyDT(0).PAGO_FECHA
                .pago_importe = MyDT(0).PAGO_IMPORTE
                .pago_referencia = MyDT(0).PAGO_REFERENCIA
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .indica_primera_compra = MyDT(0).INDICA_PRIMERA_COMPRA
                .indica_ascenso = MyDT(0).INDICA_ASCENSO
                .indica_mantenimiento = MyDT(0).INDICA_MANTENIMIENTO
                .indica_compra_extra = MyDT(0).INDICA_COMPRA_EXTRA
                .indica_anticipo = MyDT(0).INDICA_ANTICIPO
                .indica_extorno_anticipo = MyDT(0).INDICA_EXTORNO_ANTICIPO
                .venta_anticipo = MyDT(0).VENTA_ANTICIPO
                .comentario = MyDT(0).COMENTARIO
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cOrdenPedido
    End Function

    Public Shared Sub ActualizarPagoImporte(ByVal OrdenPedido As String, ByVal PagoImporte As Decimal)

        MySql = "UPDATE COM.ORDEN_PEDIDO SET " & _
                "Pago_importe=@vPago_importe " & _
                "WHERE Empresa=@vEmpresa AND Orden_pedido=@vOrden_pedido"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vPago_importe", PagoImporte)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vOrden_pedido", OrdenPedido)
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
End Class
