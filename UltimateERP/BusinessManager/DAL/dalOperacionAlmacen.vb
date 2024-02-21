Imports System.Data.SqlClient

Public Class dalOperacionAlmacen

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand

    Private Shared MySQL As String
    Private Shared MySQL_1 As String
    Private Shared MySql_2 As String
    Private Shared MySql_3 As String
    Private Shared MySql_4 As String
    Private Shared MySql_5 As String

    Public Shared Function ObtenerOperacion(ByVal pOperacion As String) As entOperacionAlmacen
        CadenaSQL = "SELECT * FROM ALM.OPERACIONES_ALMACEN " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' AND OPERACION='" & pOperacion & "' "
        Return Obtener(New entOperacionAlmacen, CadenaSQL)
    End Function

    Public Shared Function ObtenerOperacionCompra(ByVal pOperacion As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable
        MySqlString = "SELECT * FROM ALM.OPERACIONES_ALMACEN_COM WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerOperacion(ByVal CuentaComercial As String, ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As entOperacionAlmacen
        CadenaSQL = "SELECT * FROM ALM.OPERACIONES_ALMACEN " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa &
                    "' AND REFERENCIA_CUENTA_COMERCIAL='" & CuentaComercial &
                    "' AND REFERENCIA_TIPO='" & pTipo &
                    "' AND REFERENCIA_SERIE='" & pSerie &
                    "' AND REFERENCIA_NUMERO='" & pNumero & "' "

        Return Obtener(New entOperacionAlmacen, CadenaSQL)
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
                .poliza = MyDT(0).POLIZA
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cOperacionAlmacen
    End Function

    Public Shared Function ObtenerDetallesOperacionAlmacen(ByVal pEmpresa As String, ByVal pAlmacen As String, pOperacion As String) As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable
        MySqlString = "SELECT D.LINEA, D.PRODUCTO, P.CODIGO_COMPRA, P.DESCRIPCION_AMPLIADA, D.PRECIO_UNITARIO_MN, D.PRECIO_UNITARIO_ME, " & _
                      "D.CANTIDAD, D.NUMERO_LOTE, D.FECHA_VENCIMIENTO, P.INDICA_SERIE, 'NO' AS EXISTE_RESUMEN_ALMACEN, 'NO' AS EXISTE_RESUMEN_PERIODO " & _
                      "FROM ALM.OPERACIONES_ALMACEN AS H INNER JOIN ALM.OPERACIONES_ALMACEN_DET AS D ON H.EMPRESA = D.EMPRESA AND H.ALMACEN = D.ALMACEN AND H.OPERACION = D.OPERACION " & _
                                                        "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " & _
                      "WHERE H.EMPRESA=@vEmpresa AND H.ALMACEN=@vAlmacen AND H.OPERACION=@vOperacion " & _
                      "ORDER BY D.PRODUCTO, D.NUMERO_LOTE "

        Dim MyDT As New dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetalleSeries(pEmpresa As String, pOperacion As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
        MySqlString = "SELECT EMPRESA, OPERACION, PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR, ESTADO, " & _
                      "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA, EXISTE_CONTROL_SERIES='NO' " & _
                      "FROM ALM.OPERACIONES_ALMACEN_DET_SERIES WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerControlVehiculo(pEmpresa As String, pProducto As String, pNumeroSerie As String) As dsProductos.CONTROL_VEHICULOSDataTable
        MySqlString = "SELECT * FROM COM.CONTROL_VEHICULOS WHERE EMPRESA=@vEmpresa AND PRODUCTO=@vProducto AND NUMERO_SERIE=@vNumeroSerie "

        Dim MyDT As New dsProductos.CONTROL_VEHICULOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            MySQLCommand.Parameters.AddWithValue("vNumeroSerie", pNumeroSerie)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerControlVehiculo(pEmpresa As String, pProducto As String) As dsProductos.CONTROL_VEHICULOSDataTable
        MySqlString = "SELECT TOP(1) * FROM COM.CONTROL_VEHICULOS WHERE EMPRESA=@vEmpresa AND PRODUCTO=@vProducto ORDER BY FECHA_REGISTRO DESC"

        Dim MyDT As New dsProductos.CONTROL_VEHICULOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarOperacionesAlmacenes(pTipoIS As String, ByVal pEjercicio As String, ByVal pMes As String, pEsVehicular As String) As dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable
        MySqlString = "SELECT R.OPERACION, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, ISNULL(R.FECHA_OPERACION, R.FECHA_REGISTRO) AS FECHA_REGISTRO," &
                      "R.TIPO_OPERACION, TOA.DESCRIPCION AS TIPO_OPERACION_DESCRIPCION," &
                      "COMENTARIO=CASE WHEN R.TIPO_OPERACION<>'02' THEN R.COMENTARIO ELSE 'F/'+R.REFERENCIA_SERIE+'-'+R.REFERENCIA_NUMERO+' '+CC.RAZON_SOCIAL END ," &
                      "INDICA_CREDITO=CASE WHEN ISNULL(OA.OPERACION,SPACE(1))=SPACE(1) THEN 'NO' ELSE (CASE WHEN ISNULL(OA.INDICA_CONSIGNACION,'NO')='SI' THEN 'NO' ELSE 'SI' END) END," &
                      "R.ESTADO " &
                      "FROM ALM.MOVIMIENTOS_ALMACEN AS R INNER JOIN GEN.TABLA_TIPO_OPERACION_ALMACEN AS TOA ON R.TIPO_OPERACION = TOA.CODIGO  " &
                                                        "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA = TA.EMPRESA AND R.ALMACEN = TA.CODIGO " &
                                                        "LEFT OUTER JOIN COM.CUENTAS_COMERCIALES AS CC ON R.EMPRESA=CC.EMPRESA AND R.REFERENCIA_CUENTA_COMERCIAL=CC.CUENTA_COMERCIAL " &
                                                        "LEFT OUTER JOIN ALM.OPERACIONES_ALMACEN_COM AS OA ON R.EMPRESA=OA.EMPRESA AND R.OPERACION=OA.OPERACION " &
                      "WHERE R.EMPRESA=@vEmpresa AND R.ALMACEN=@vAlmacen AND R.EJERCICIO=@vEjercicio AND R.MES=@vMes AND R.TIPO_ES=@vTipoES AND R.TIPO_OPERACION <> '11' " &
                      IIf(pEsVehicular = "SN", " ", "AND R.ES_VEHICULAR='" & pEsVehicular & "' ")

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vTipoES", pTipoIS)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarOperacionesTrasladoAlmacenes(ByVal pEjercicio As String, ByVal pMes As String) As dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable
        MySqlString = "SELECT R.OPERACION, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, ISNULL(R.FECHA_OPERACION, R.FECHA_REGISTRO) AS FECHA_REGISTRO, R.TIPO_OPERACION, " &
                      "TOA.DESCRIPCION AS TIPO_OPERACION_DESCRIPCION, " &
                      "CASE WHEN LEN(RTRIM(R.COMENTARIO))<>0 THEN R.COMENTARIO ELSE 'GUIA: ' + R.REFERENCIA_SERIE + '-' + R.REFERENCIA_NUMERO + ' FECHA: ' + CONVERT(VARCHAR, R.REFERENCIA_FECHA, 103) END AS COMENTARIO, " &
                      "INDICA_CREDITO='NO', R.ESTADO " & _
                      "FROM ALM.OPERACIONES_ALMACEN AS R INNER JOIN GEN.TABLA_TIPO_OPERACION_ALMACEN AS TOA ON R.TIPO_OPERACION = TOA.CODIGO " &
                                                        "INNER JOIN COM.GUIAS AS GR ON R.EMPRESA = GR.EMPRESA AND R.REFERENCIA_TIPO = GR.COMPROBANTE_TIPO AND R.REFERENCIA_SERIE = GR.COMPROBANTE_SERIE AND R.REFERENCIA_NUMERO = GR.COMPROBANTE_NUMERO " &
                                                        "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA = GR.EMPRESA AND GR.ALMACEN = TA.CODIGO " &
                      "WHERE R.EMPRESA=@vEmpresa AND R.ALMACEN=@vAlmacen AND R.EJERCICIO=@vEjercicio AND R.MES=@vMes AND R.TIPO_OPERACION = '11' AND GR.ESTADO_TRASLADO_INTERNO='P' "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACENESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function AnularOperacionAlmacen(MyOperacionAlmacen As entOperacionAlmacen, MyOperacionAlmacenDetalles As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, MyOperacionAlmacenDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                              "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                              "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)

                        End With
                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To MyOperacionAlmacenDetalles.Rows.Count - 1
                            MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                                    "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                    "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion AND Linea=@vLinea "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                                .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                                .AddWithValue("vLinea", MyOperacionAlmacenDetalles(NEle).LINEA)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            'Actualizar Stock por Almacen y por Periodo 
                            If MyOperacionAlmacenDetalles(NEle).EXISTE_RESUMEN_ALMACEN = "SI" Then
                                MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                                          "Ingresos=Ingresos-@vIngresos,Egresos=Egresos-@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_2
                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(NEle).PRODUCTO)
                            Else
                                MySql_2 = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                                          "(empresa,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_2
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", MyOperacionAlmacenDetalles(NEle).FECHA_VENCIMIENTO)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(NEle).PRODUCTO)

                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                            End If
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            If MyOperacionAlmacenDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI" Then
                                MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                                          "Ingresos=Ingresos-@vIngresos,Egresos=Egresos-@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_3
                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(NEle).PRODUCTO)
                            Else
                                MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                          "(empresa,ejercicio,mes,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyOperacionAlmacenDetalles(NEle).NUMERO_LOTE)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", MyOperacionAlmacenDetalles(NEle).FECHA_VENCIMIENTO)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(NEle).PRODUCTO)

                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyOperacionAlmacenDetalles(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                            End If
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        'Actualizar Series
                        If MyOperacionAlmacenDetalleSeries.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyOperacionAlmacenDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySql_3 = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " & _
                                          "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Operacion=@vOperacion AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                MySQLCommand.CommandText = MySql_3

                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(NEle).NUMERO_SERIE)
                                MySQLCommand.ExecuteNonQuery()

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If MyOperacionAlmacenDetalleSeries(NEle).EXISTE_CONTROL_SERIES = "SI" Then
                                    MySql_4 = "UPDATE COM.CONTROL_SERIES SET Referencia_operacion=@vReferencia_operacion,Fecha_operacion=@vFecha_operacion," & _
                                              "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                    MySQLCommand.CommandText = MySql_4
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", CUO_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", FechaNulo)
                                    If MyOperacionAlmacen.tipo_es = "I" Then
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "N")
                                    Else
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                                    End If
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(NEle).NUMERO_SERIE)
                                    MySQLCommand.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function GrabarOperacionAlmacen(OperacionAlmacen As entOperacionAlmacen, DetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, DetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable) As entOperacionAlmacen
        With OperacionAlmacen
            If Year(.fecha_operacion) * 100 + Month(.fecha_operacion) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            If String.IsNullOrEmpty(.almacen) Then Throw New BusinessException(MSG000 & " ALMACEN")
            If String.IsNullOrEmpty(.tipo_operacion) Then Throw New BusinessException(MSG000 & " TIPO DE OPERACION")

            If .tipo_operacion = "02" Or .tipo_operacion = "92" Then ' Compra Local o Importacion
                If String.IsNullOrEmpty(.referencia_cuenta_comercial.Trim) Then Throw New BusinessException(MSG000 & " DOCUMENTO IDENTIDAD")
                If String.IsNullOrEmpty(.referencia_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO")
                If Year(.referencia_fecha) * 100 + Month(.referencia_fecha) = 190001 Then Throw New BusinessException(MSG000 & " F. EMISION")
            End If
        End With

        Return InsertarOperacionAlmacen(OperacionAlmacen, DetallesOperacion, DetallesOperacionSeries)
    End Function

    Private Shared Function InsertarOperacionAlmacen(MyOperacionAlmacen As entOperacionAlmacen, MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable) As entOperacionAlmacen
        Dim Linea As Byte = 0
        Dim LineaOperacion As String

        MyOperacionAlmacen.operacion = AsignarOperacion()

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                              "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                              "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                              "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,poliza,usuario_registro) " & _
                              "VALUES " & _
                              "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                              "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                              "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vPoliza,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                            .AddWithValue("vTipo_operacion", MyOperacionAlmacen.tipo_operacion)
                            .AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                            .AddWithValue("vMes", MyOperacionAlmacen.mes)
                            .AddWithValue("vFecha_operacion", MyOperacionAlmacen.fecha_operacion)
                            .AddWithValue("vComentario", MyOperacionAlmacen.comentario)
                            .AddWithValue("vTipo_es", MyOperacionAlmacen.tipo_es)
                            .AddWithValue("vReferencia_cuenta_comercial", MyOperacionAlmacen.referencia_cuenta_comercial)
                            .AddWithValue("vReferencia_tipo", MyOperacionAlmacen.referencia_tipo)
                            .AddWithValue("vReferencia_serie", MyOperacionAlmacen.referencia_serie)
                            .AddWithValue("vReferencia_numero", MyOperacionAlmacen.referencia_numero)
                            .AddWithValue("vReferencia_fecha", MyOperacionAlmacen.referencia_fecha)
                            .AddWithValue("vReferencia_tipo_moneda", MyOperacionAlmacen.referencia_tipo_moneda)
                            .AddWithValue("vReferencia_importe_total", MyOperacionAlmacen.referencia_importe_total)
                            .AddWithValue("vPoliza", MyOperacionAlmacen.poliza)
                            .AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To MyDetallesOperacion.Rows.Count - 1
                            MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                                    "(empresa,almacen,operacion,linea,producto,cantidad,precio_unitario_mn,precio_unitario_me,numero_lote," & _
                                    "fecha_vencimiento,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                                    "VALUES " & _
                                    "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vPrecio_unitario_mn,@vPrecio_unitario_me,@vNumero_lote," & _
                                    "@vFecha_vencimiento,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                                .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                                .AddWithValue("vLinea", LineaOperacion)

                                .AddWithValue("vProducto", MyDetallesOperacion(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", MyDetallesOperacion(NEle).CANTIDAD)
                                .AddWithValue("vPrecio_unitario_mn", MyDetallesOperacion(NEle).PRECIO_UNITARIO_MN)
                                .AddWithValue("vPrecio_unitario_me", MyDetallesOperacion(NEle).PRECIO_UNITARIO_ME)
                                .AddWithValue("vNumero_lote", MyDetallesOperacion(NEle).NUMERO_LOTE)
                                .AddWithValue("vFecha_vencimiento", MyDetallesOperacion(NEle).FECHA_VENCIMIENTO)
                                .AddWithValue("vTipo_es", MyOperacionAlmacen.tipo_es)
                                .AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                                .AddWithValue("vMes", MyOperacionAlmacen.mes)
                                .AddWithValue("vComentario", MyOperacionAlmacen.comentario)
                                .AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            'Actualizar Stock por Almacen y por Periodo 
                            If MyDetallesOperacion(NEle).EXISTE_RESUMEN_ALMACEN = "SI" Then
                                MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                                          "Ingresos=Ingresos+@vIngresos,Egresos=Egresos+@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_2
                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesOperacion(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyDetallesOperacion(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyDetallesOperacion(NEle).NUMERO_LOTE)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(NEle).PRODUCTO)
                            Else
                                MySql_2 = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                                          "(empresa,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_2
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyDetallesOperacion(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyDetallesOperacion(NEle).NUMERO_LOTE)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", MyDetallesOperacion(NEle).FECHA_VENCIMIENTO)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(NEle).PRODUCTO)

                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesOperacion(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                            End If
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            If MyDetallesOperacion(NEle).EXISTE_RESUMEN_PERIODO = "SI" Then
                                MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                                          "Ingresos=Ingresos+@vIngresos,Egresos=Egresos+@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_3
                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesOperacion(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyDetallesOperacion(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyDetallesOperacion(NEle).NUMERO_LOTE)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(NEle).PRODUCTO)
                            Else
                                MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                          "(empresa,ejercicio,mes,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)

                                If MyDetallesOperacion(NEle).NUMERO_LOTE.Trim.Length = 0 Then
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", MyDetallesOperacion(NEle).NUMERO_LOTE)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", MyDetallesOperacion(NEle).FECHA_VENCIMIENTO)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(NEle).PRODUCTO)

                                If MyOperacionAlmacen.tipo_es = "I" Then
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                Else
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesOperacion(NEle).CANTIDAD)
                                End If

                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                            End If
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        'Actualizar Series
                        If MyDetallesOperacionSeries.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyDetallesOperacionSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySql_3 = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                                          "(empresa,operacion,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                          "VALUES (@vEmpresa,@vOperacion,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

                                MySQLCommand.CommandText = MySql_3

                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacionSeries(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesOperacionSeries(NEle).NUMERO_SERIE)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesOperacionSeries(NEle).NUMERO_SERIE_CHASIS)
                                MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesOperacionSeries(NEle).COLOR)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                                MySQLCommand.ExecuteNonQuery()

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If MyDetallesOperacionSeries(NEle).EXISTE_CONTROL_SERIES = "SI" Then
                                    MySql_4 = "UPDATE COM.CONTROL_SERIES SET " & _
                                              "Almacen=@vAlmacen,Referencia_operacion=@vReferencia_operacion,Fecha_operacion=@vFecha_operacion," & _
                                              "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                    MySQLCommand.CommandText = MySql_4
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", MyOperacionAlmacen.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", MyOperacionAlmacen.fecha_operacion)

                                    If MyOperacionAlmacen.tipo_es = "I" Then
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                                    Else
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "N")
                                    End If

                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacionSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesOperacionSeries(NEle).NUMERO_SERIE)
                                Else
                                    MySql_4 = "INSERT INTO COM.CONTROL_SERIES " & _
                                              "(empresa,producto,numero_serie,almacen,referencia_operacion,fecha_operacion,estado,usuario_registro) " & _
                                              "VALUES " & _
                                              "(@vEmpresa,@vProducto,@vNumero_serie,@vAlmacen,@vReferencia_operacion,@vFecha_operacion,@vEstado,@vUsuario_registro)"

                                    MySQLCommand.CommandText = MySql_4
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacionSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesOperacionSeries(NEle).NUMERO_SERIE)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", MyOperacionAlmacen.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", MyOperacionAlmacen.fecha_operacion)

                                    If MyOperacionAlmacen.tipo_es = "I" Then
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                                    Else
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "N")
                                    End If
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        If MyOperacionAlmacen.tipo_operacion = "11" Then 'Ingreso por Transferencia Interna
                            MySql_4 = "UPDATE COM.GUIAS SET " &
                                      "Usuario_recepcion=@vUsuario_recepcion, Fecha_recepcion=GETDATE(), Comentario_recepcion=@vComentario_recepcion, " &
                                      "Estado_traslado_interno='R' " &
                                      "WHERE Empresa=@vEmpresa AND Comprobante_tipo=@vComprobante_tipo AND Comprobante_serie=@vComprobante_serie " &
                                      "AND Comprobante_numero=@vComprobante_numero "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySql_4
                            MySQLCommand.Parameters.Clear()

                            MySQLCommand.CommandText = MySql_4
                            MySQLCommand.Parameters.AddWithValue("vUsuario_recepcion", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vComentario_recepcion", MyOperacionAlmacen.comentario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", MyOperacionAlmacen.referencia_tipo)
                            MySQLCommand.Parameters.AddWithValue("vComprobante_serie", MyOperacionAlmacen.referencia_serie)
                            MySQLCommand.Parameters.AddWithValue("vComprobante_numero", MyOperacionAlmacen.referencia_numero)
                            MySQLCommand.ExecuteNonQuery()
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyOperacionAlmacen
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function AsignarOperacion() As String
        MySqlString = "SELECT ISNULL(MAX(OPERACION),'') AS NUEVA_OPERACION FROM ALM.OPERACIONES_ALMACEN "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
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

    Public Shared Function StockProductoAlmacen(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String, pFamilia As String, pTipo As String) As dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable
        MySqlString = "SELECT R.PRODUCTO, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, P.CODIGO_COMPRA, LEFT(P.DESCRIPCION_AMPLIADA,75) AS DESCRIPCION, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO, " & _
                      "STOCK_INICIAL=SUM(CASE WHEN R.EJERCICIO+R.MES<@vEjercicio+@vMes THEN R.INGRESOS-R.EGRESOS ELSE 0 END)," & _
                      "INGRESOS=0," & _
                      "EGRESOS=0," & _
                      "STOCK_FINAL=SUM(CASE WHEN R.EJERCICIO+R.MES<@vEjercicio+@vMes THEN R.INGRESOS-R.EGRESOS ELSE 0 END) " & _
                      "FROM ALM.RESUMEN_X_PERIODO AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO " & _
                      "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA=TA.EMPRESA AND R.ALMACEN=TA.CODIGO " & _
                      "WHERE R.EMPRESA=@vEmpresa AND R.EJERCICIO+R.MES<=@vEjercicio+@vMes " & _
                      IIf(pAlmacen = "TODOS", "AND R.ALMACEN<>'900' ", "AND R.ALMACEN='" & pAlmacen & "' ") & _
                      IIf(pFamilia = "TODOS", " ", "AND P.PRODUCTO_FAMILIA='" & pFamilia & "' ") & _
                      IIf(pTipo = "TODOS", " ", "AND P.PRODUCTO_TIPO='" & pTipo & "' ") & _
                      "GROUP BY R.PRODUCTO, R.ALMACEN, TA.DESCRIPCION, P.CODIGO_COMPRA, P.DESCRIPCION_AMPLIADA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO "

        Dim MyDT As New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function MovimientoProductos(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String, pFamilia As String, pTipo As String) As dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTOSDataTable
        MySqlString = "SELECT M.EMPRESA, M.ALMACEN, M.ID_TIPO, M.ID_MOVIMIENTO, M.LINEA, M.TIPO_ES, M.EJERCICIO, M.MES, M.FECHA_OPERACION, M.PRODUCTO, M.CANTIDAD, " & _
                      "M.PRECIO_UNITARIO, M.NUMERO_LOTE, M.FECHA_VENCIMIENTO, M.OPERACION_CODIGO, TTO.DESCRIPCION AS OPERACION_DESCRIPCION, " & _
                      "M.REFERENCIA_CUENTA_COMERCIAL, M.REFERENCIA_TIPO, M.REFERENCIA_SERIE, M.REFERENCIA_NUMERO, M.REFERENCIA_TIPO_MONEDA, M.POLIZA, " & _
                      "M.ORDEN_COMPRA, M.ORDEN_COMPRA_LINEA, M.COMPRA, M.COMPRA_LINEA, M.COMENTARIO, M.ESTADO, " & _
                      "RTRIM(P.DESCRIPCION_AMPLIADA)  AS PRODUCTO_DESCRIPCION, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO " & _
                      "FROM ALM.MOVIMIENTOS_PRODUCTOS AS M INNER JOIN GEN.TABLA_TIPO_OPERACION_ALMACEN AS TTO ON M.OPERACION_CODIGO = TTO.CODIGO " & _
                                                          "INNER JOIN COM.PRODUCTOS AS P ON M.EMPRESA = P.EMPRESA AND M.PRODUCTO = P.PRODUCTO " & _
                      "WHERE M.EMPRESA=@vEmpresa AND M.EJERCICIO=@vEjercicio AND M.MES=@vMes AND M.ESTADO<>'N' " & _
                      IIf(pAlmacen = "TODOS", "AND M.ALMACEN<>'900' ", "AND M.ALMACEN='" & pAlmacen & "' ") & _
                      IIf(pFamilia = "TODOS", " ", "AND P.PRODUCTO_FAMILIA='" & pFamilia & "' ") & _
                      IIf(pTipo = "TODOS", " ", "AND P.PRODUCTO_TIPO='" & pTipo & "' ") & _
                      "ORDER BY M.EJERCICIO, M.MES, M.FECHA_OPERACION, M.TIPO_ES "

        Dim MyDT As New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function StockProductoAlmacenRango(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String, ByVal pProductoInicial As String, ByVal pProductoFinal As String) As dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable
        MySqlString = "SELECT R.PRODUCTO, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, P.CODIGO_COMPRA, LEFT(P.DESCRIPCION_AMPLIADA,75) AS DESCRIPCION, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO, " & _
                      "STOCK_INICIAL=SUM(CASE WHEN R.EJERCICIO+ R.MES<@vEjercicio+@vMes THEN R.INGRESOS-R.EGRESOS ELSE 0 END)," & _
                      "INGRESOS=0," & _
                      "EGRESOS=0," & _
                      "STOCK_FINAL=SUM(CASE WHEN R.EJERCICIO+ R.MES<@vEjercicio+@vMes THEN R.INGRESOS-R.EGRESOS ELSE 0 END) " & _
                      "FROM ALM.RESUMEN_X_PERIODO AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO " & _
                      "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA=TA.EMPRESA AND R.ALMACEN=TA.CODIGO " & _
                      "WHERE R.EMPRESA=@vEmpresa AND R.EJERCICIO+ R.MES<=@vEjercicio+@vMes " & _
                      IIf(pAlmacen = "TODOS", "AND R.ALMACEN<>'900' ", "AND R.ALMACEN='" & pAlmacen & "' ") & _
                      "AND (R.INGRESOS+R.EGRESOS)<>0 " & _
                      "AND (R.PRODUCTO BETWEEN @vProductoInicial AND @vProductoFinal) " & _
                      "GROUP BY R.PRODUCTO, R.ALMACEN, TA.DESCRIPCION, P.CODIGO_COMPRA, P.DESCRIPCION_AMPLIADA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO "

        Dim MyDT As New dsStockAlmacen.STOCK_PRODUCTO_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vProductoInicial", pProductoInicial)
            MySQLCommand.Parameters.AddWithValue("vProductoFinal", pProductoFinal)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function MovimientoProductosRango(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAlmacen As String, ByVal pProductoInicial As String, ByVal pProductoFinal As String) As dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTOSDataTable
        MySqlString = "SELECT M.EMPRESA, M.ALMACEN, M.ID_TIPO, M.ID_MOVIMIENTO, M.LINEA, M.TIPO_ES, M.EJERCICIO, M.MES, M.FECHA_OPERACION, M.PRODUCTO, M.CANTIDAD, " & _
                      "M.PRECIO_UNITARIO, M.NUMERO_LOTE, M.FECHA_VENCIMIENTO, M.OPERACION_CODIGO, TTO.DESCRIPCION AS OPERACION_DESCRIPCION, " & _
                      "M.REFERENCIA_CUENTA_COMERCIAL, M.REFERENCIA_TIPO, M.REFERENCIA_SERIE, M.REFERENCIA_NUMERO, M.REFERENCIA_TIPO_MONEDA, M.POLIZA, " & _
                      "M.ORDEN_COMPRA, M.ORDEN_COMPRA_LINEA, M.COMPRA, M.COMPRA_LINEA, M.COMENTARIO, M.ESTADO, " & _
                      "RTRIM(P.DESCRIPCION_AMPLIADA)  AS PRODUCTO_DESCRIPCION, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO " & _
                      "FROM ALM.MOVIMIENTOS_PRODUCTOS AS M INNER JOIN GEN.TABLA_TIPO_OPERACION_ALMACEN AS TTO ON M.OPERACION_CODIGO = TTO.CODIGO " & _
                                                          "INNER JOIN COM.PRODUCTOS AS P ON M.EMPRESA = P.EMPRESA AND M.PRODUCTO = P.PRODUCTO " & _
                      "WHERE M.EMPRESA=@vEmpresa AND M.EJERCICIO=@vEjercicio AND M.MES=@vMes AND M.ESTADO<>'N' " & _
                      IIf(pAlmacen = "TODOS", "AND M.ALMACEN<>'900' ", "AND M.ALMACEN='" & pAlmacen & "' ") & _
                      "AND (M.PRODUCTO BETWEEN @vProductoInicial AND @vProductoFinal) " & _
                      "ORDER BY M.EJERCICIO, M.MES, M.FECHA_OPERACION, M.TIPO_ES "

        Dim MyDT As New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vProductoInicial", pProductoInicial)
            MySQLCommand.Parameters.AddWithValue("vProductoFinal", pProductoFinal)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function StockProducto(pProducto As String) As dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MySqlString = "SELECT R.EMPRESA, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, TA.INDICA_VENTA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO," & _
                      "R.PRODUCTO, P.DESCRIPCION_AMPLIADA AS PRODUCTO_DESCRIPCION, R.INGRESOS, R.EGRESOS, R.INGRESOS - R.EGRESOS AS STOCK " & _
                      "FROM ALM.RESUMEN_X_ALMACEN AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO  " & _
                                                      "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA = TA.EMPRESA AND R.ALMACEN = TA.CODIGO " & _
                      "WHERE R.EMPRESA=@vEmpresa AND R.PRODUCTO=@vProducto "

        Dim MyDT As New dsStockAlmacen.RESUMEN_X_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function StockProducto(pProducto As String, pAlmacen As String) As dsStockAlmacen.RESUMEN_X_ALMACENDataTable
        MySqlString = "SELECT R.EMPRESA, R.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, TA.INDICA_VENTA, R.NUMERO_LOTE, R.FECHA_VENCIMIENTO," & _
                      "R.PRODUCTO, P.DESCRIPCION_AMPLIADA AS PRODUCTO_DESCRIPCION, R.INGRESOS, R.EGRESOS, " & _
                      "STOCK=CASE WHEN P.INDICA_VALIDA_STOCK='NO' THEN 1 ELSE R.INGRESOS - R.EGRESOS END " & _
                      "FROM ALM.RESUMEN_X_ALMACEN AS R INNER JOIN COM.PRODUCTOS AS P ON R.EMPRESA = P.EMPRESA AND R.PRODUCTO = P.PRODUCTO  " & _
                                                      "INNER JOIN GEN.TABLA_ALMACENES AS TA ON R.EMPRESA = TA.EMPRESA AND R.ALMACEN = TA.CODIGO " & _
                      "WHERE R.EMPRESA=@vEmpresa AND R.PRODUCTO=@vProducto AND R.ALMACEN=@vAlmacen "

        Dim MyDT As New dsStockAlmacen.RESUMEN_X_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobanteSeries(ByVal pOperacion As String) As dsGuiasRemitente.COMPROBANTE_SERIESDataTable
        MySqlString = "SELECT PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR " & _
                      "FROM ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND OPERACION= @vOperacion "

        Dim MyDT As New dsGuiasRemitente.COMPROBANTE_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerGuiaTraslado(ByVal pReferenciaTipo As String, ByVal pReferenciaSerie As String, pReferenciaNumero As String) As entOperacionAlmacen
        CadenaSQL = "SELECT * FROM ALM.OPERACIONES_ALMACEN " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' " & _
                    "AND REFERENCIA_TIPO='" & pReferenciaTipo & "' " & _
                    "AND REFERENCIA_SERIE='" & pReferenciaSerie & "' " & _
                    "AND REFERENCIA_NUMERO='" & pReferenciaNumero & "' "
        Return Obtener(New entOperacionAlmacen, CadenaSQL)
    End Function

    Public Shared Function ObtenerDetallesOperacion(ByVal pAlmacen As String, ByVal pOperacion As String) As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
        MySqlString = "SELECT D.LINEA,D.PRODUCTO,P.DESCRIPCION_AMPLIADA,D.CANTIDAD,P.INDICA_SERIE,EXISTE_RESUMEN_ALMACEN='NO',EXISTE_RESUMEN_PERIODO='NO',EXISTE_RESUMEN_PERIODO2='NO'  " & _
                      "FROM ALM.OPERACIONES_ALMACEN_DET AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA=P.EMPRESA AND D.PRODUCTO=P.PRODUCTO " & _
                      "WHERE D.EMPRESA=@vEmpresa AND D.ALMACEN=@vAlmacen AND D.OPERACION=@vOperacion"

        Dim MyDT As New dsOperacionesAlmacen.DETALLE_OPERACIONDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerSaldosFinales(ByVal pEmpresa As String, ByVal pFecha As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_SALDO_FINALDataTable
        MySQL = "SELECT K.EMPRESA, OPERACION='OA0000000'+K.ALMACEN, K.ALMACEN, ALMACEN_DESCRIPCION=TA.DESCRIPCION, " & _
                "COSTO_TOTAL_MN=SUM(K.COSTO_TOTAL_MN_DEBE-K.COSTO_TOTAL_MN_HABER), " & _
                "COSTO_TOTAL_ME=SUM(K.COSTO_TOTAL_ME_DEBE-K.COSTO_TOTAL_ME_HABER) " & _
                "FROM  CON.KARDEX_VALORIZADO_ACTUAL AS K INNER JOIN GEN.TABLA_ALMACENES AS TA ON K.EMPRESA = TA.EMPRESA AND K.ALMACEN = TA.CODIGO " & _
                "WHERE K.EMPRESA=@vEmpresa AND K.OPERACION_FECHA<=@vFecha " & _
                "GROUP BY K.EMPRESA, K.ALMACEN, TA.DESCRIPCION " & _
                "HAVING SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA)<>0 " & _
                "ORDER BY K.ALMACEN "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_SALDO_FINALDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vFecha", pFecha)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerOperacionesSaldosFinales(ByVal pEmpresa As String, ByVal pFecha As String) As dsOperacionesAlmacen.OPERACIONES_ALMACENDataTable
        MySQL = "SELECT K.EMPRESA, K.ALMACEN, OPERACION='OA0000000'+K.ALMACEN, TIPO_OPERACION='16', EJERCICIO=MAX(K.EJERCICIO), MES='12', FECHA_OPERACION=CONVERT(SMALLDATETIME,MAX(K.EJERCICIO)+'-31-12'), " & _
                "COMENTARIO='SALDOS AL 31-12-'+MAX(K.EJERCICIO), TIPO_ES='I',  REFERENCIA_CUENTA_COMERCIAL=SPACE(1),  REFERENCIA_TIPO='OT',  REFERENCIA_SERIE=SPACE(1),  REFERENCIA_NUMERO=SPACE(1), " & _
                "REFERENCIA_FECHA=CONVERT(SMALLDATETIME,'1900-01-01'),  REFERENCIA_TIPO_MONEDA='2',  REFERENCIA_IMPORTE_TOTAL=0, POLIZA='000000000000', ESTADO='A', " & _
                "USUARIO_REGISTRO='SISTEMAS', FECHA_REGISTRO=GETDATE(), USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=NULL " & _
                "FROM CON.KARDEX_VALORIZADO_ACTUAL AS K " & _
                "WHERE K.EMPRESA=@vEmpresa AND K.OPERACION_FECHA<=@vFecha " & _
                "GROUP BY K.EMPRESA, K.ALMACEN " & _
                "HAVING SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA)<>0 " & _
                "ORDER BY K.ALMACEN "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vFecha", pFecha)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerOperacionesDetallesSaldosFinales(ByVal pEmpresa As String, ByVal pFecha As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_SIDataTable
        MySQL = "SELECT K.EMPRESA, K.ALMACEN, OPERACION='OA0000000'+K.ALMACEN, LINEA='000', K.PRODUCTO, " & _
                "CANTIDAD=SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " & _
                "PRECIO_UNITARIO_MN=SUM(K.COSTO_TOTAL_MN_DEBE-K.COSTO_TOTAL_MN_HABER)/SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " & _
                "PRECIO_UNITARIO_ME=SUM(K.COSTO_TOTAL_ME_DEBE-K.COSTO_TOTAL_ME_HABER)/SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " & _
                "NUMERO_SERIE=SPACE(1), NUMERO_LOTE=SPACE(1), FECHA_VENCIMIENTO=CONVERT(SMALLDATETIME,'1900-01-01'), COMENTARIO='SALDOS AL 31-12-'+MAX(K.EJERCICIO), " & _
                "TIPO_ES='I', EJERCICIO='0000', MES='00', ORDEN_COMPRA='000000000000', ORDEN_COMPRA_LINEA='00', COMPRA='000000000000', COMPRA_LINEA='00', ESTADO='A', " & _
                "USUARIO_REGISTRO='SISTEMAS', FECHA_REGISTRO=GETDATE(), USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=NULL " & _
                "FROM CON.KARDEX_VALORIZADO_ACTUAL AS K " & _
                "WHERE K.EMPRESA=@vEmpresa AND K.OPERACION_FECHA<=@vFecha " & _
                "GROUP BY K.EMPRESA, K.ALMACEN, K.PRODUCTO " & _
                "HAVING SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA)<>0 " & _
                "ORDER BY K.ALMACEN,K.PRODUCTO "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_SIDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vFecha", pFecha)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function InsertarSaldosFinales(MyOperacionesAlmacen As dsOperacionesAlmacen.OPERACIONES_ALMACENDataTable, MyOperacionesAlmacenDetalles As dsOperacionesAlmacen.OPERACIONES_ALMACEN_SIDataTable) As Boolean
        Dim NumeroOperacion As Integer
        Dim Operacion As String
        Dim Linea As Integer = 0
        Dim LineaOperacion As String

        NumeroOperacion = ObtenerUltimaOperacion()

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySQL_1 = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                          "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                          "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                          "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,usuario_registro) " & _
                          "VALUES " & _
                          "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                          "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                          "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vUsuario_registro)"

                MySQL_2 = "INSERT INTO ALM.OPERACIONES_ALMACEN_SI " & _
                          "(empresa,almacen,operacion,linea,producto,cantidad,precio_unitario_mn,precio_unitario_me,numero_lote," & _
                          "fecha_vencimiento,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                          "VALUES " & _
                          "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vPrecio_unitario_mn,@vPrecio_unitario_me,@vNumero_lote," & _
                          "@vFecha_vencimiento,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQL_1, MySQLDbconnection)
                        For NCab As Integer = 0 To MyOperacionesAlmacen.Rows.Count - 1
                            NumeroOperacion = NumeroOperacion + 1
                            Operacion = "OA" & NumeroOperacion.ToString("0000000000")

                            MyOperacionesAlmacen(NCab).POLIZA = Operacion

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySQL_1
                            MySQLCommand.Parameters.Clear()
                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyOperacionesAlmacen(NCab).EMPRESA)
                                .AddWithValue("vAlmacen", MyOperacionesAlmacen(NCab).ALMACEN)
                                .AddWithValue("vOperacion", Operacion)
                                .AddWithValue("vTipo_operacion", MyOperacionesAlmacen(NCab).TIPO_OPERACION)
                                .AddWithValue("vEjercicio", MyOperacionesAlmacen(NCab).EJERCICIO)
                                .AddWithValue("vMes", MyOperacionesAlmacen(NCab).MES)
                                .AddWithValue("vFecha_operacion", MyOperacionesAlmacen(NCab).FECHA_OPERACION)
                                .AddWithValue("vComentario", MyOperacionesAlmacen(NCab).COMENTARIO)
                                .AddWithValue("vTipo_es", MyOperacionesAlmacen(NCab).TIPO_ES)
                                .AddWithValue("vReferencia_cuenta_comercial", MyOperacionesAlmacen(NCab).REFERENCIA_CUENTA_COMERCIAL)
                                .AddWithValue("vReferencia_tipo", MyOperacionesAlmacen(NCab).REFERENCIA_TIPO)
                                .AddWithValue("vReferencia_serie", MyOperacionesAlmacen(NCab).REFERENCIA_SERIE)
                                .AddWithValue("vReferencia_numero", MyOperacionesAlmacen(NCab).REFERENCIA_NUMERO)
                                .AddWithValue("vReferencia_fecha", MyOperacionesAlmacen(NCab).REFERENCIA_FECHA)
                                .AddWithValue("vReferencia_tipo_moneda", MyOperacionesAlmacen(NCab).REFERENCIA_TIPO_MONEDA)
                                .AddWithValue("vReferencia_importe_total", MyOperacionesAlmacen(NCab).REFERENCIA_IMPORTE_TOTAL)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        For NEle As Integer = 0 To MyOperacionesAlmacenDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySQL_2
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            For NCab As Integer = 0 To MyOperacionesAlmacen.Rows.Count - 1
                                If MyOperacionesAlmacen(NCab).OPERACION = MyOperacionesAlmacenDetalles(NEle).OPERACION Then
                                    Operacion = MyOperacionesAlmacen(NCab).POLIZA
                                    Exit For
                                End If
                            Next

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyOperacionesAlmacenDetalles(NEle).EMPRESA)
                                .AddWithValue("vAlmacen", MyOperacionesAlmacenDetalles(NEle).ALMACEN)
                                .AddWithValue("vOperacion", Operacion)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", MyOperacionesAlmacenDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", MyOperacionesAlmacenDetalles(NEle).CANTIDAD)
                                .AddWithValue("vPrecio_unitario_mn", MyOperacionesAlmacenDetalles(NEle).PRECIO_UNITARIO_MN)
                                .AddWithValue("vPrecio_unitario_me", MyOperacionesAlmacenDetalles(NEle).PRECIO_UNITARIO_ME)
                                .AddWithValue("vNumero_lote", MyOperacionesAlmacenDetalles(NEle).NUMERO_LOTE)
                                .AddWithValue("vFecha_vencimiento", MyOperacionesAlmacenDetalles(NEle).FECHA_VENCIMIENTO)
                                .AddWithValue("vTipo_es", MyOperacionesAlmacenDetalles(NEle).TIPO_ES)
                                .AddWithValue("vEjercicio", MyOperacionesAlmacenDetalles(NEle).EJERCICIO)
                                .AddWithValue("vMes", MyOperacionesAlmacenDetalles(NEle).MES)
                                .AddWithValue("vComentario", MyOperacionesAlmacenDetalles(NEle).COMENTARIO)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function ObtenerUltimaOperacion() As Integer

        MySQL = "SELECT ISNULL(MAX(OPERACION),'') AS NUEVA_OPERACION FROM ALM.OPERACIONES_ALMACEN "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "0"
            Else
                NewCode = CLng(NewCode.Substring(2, 10))
            End If
            Return CInt(NewCode)
        End Using

    End Function

    Public Shared Function ObtenerComprasExcel(ByVal pEmpresa As String, ByVal pEjercicio As String, pMes As String) As dsCompras.COMPRAS_LOCALESDataTable
        MySQL = "SELECT H.EMPRESA, H.EJERCICIO, H.MES, CC.NRO_DOCUMENTO, CC.RAZON_SOCIAL, H.REFERENCIA_TIPO, H.REFERENCIA_SERIE, H.REFERENCIA_NUMERO, H.REFERENCIA_FECHA, " & _
                "H.REFERENCIA_TIPO_MONEDA, D.PRODUCTO, P.DESCRIPCION, D.CANTIDAD, " & _
                "IMPORTE_TOTAL_MN=ROUND(D.PRECIO_UNITARIO_MN*1.18,2), " & _
                "IMPORTE_TOTAL_ME=ROUND(D.PRECIO_UNITARIO_ME*1.18,2), H.USUARIO_REGISTRO, H.FECHA_REGISTRO, H.ESTADO " & _
                "FROM ALM.OPERACIONES_ALMACEN AS H " & _
                "INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.REFERENCIA_CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                "INNER JOIN ALM.OPERACIONES_ALMACEN_DET AS D ON H.EMPRESA = D.EMPRESA AND H.ALMACEN = D.ALMACEN AND H.OPERACION = D.OPERACION " & _
                "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " & _
                "WHERE H.EMPRESA = @VEmpresa AND H.TIPO_OPERACION = '02' AND H.EJERCICIO=@vEjercicio AND H.MES=@vMes "

        Dim MyDT As New dsCompras.COMPRAS_LOCALESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function


#Region "Vehicular"

    Public Shared Function GrabarNotaIngresoVehiculo(MyOperacionAlmacen As entOperacionAlmacen, MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, MyControlVehiculos As dsProductos.CONTROL_VEHICULOSDataTable, MyOperacionAlmacenCompra As dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable) As entOperacionAlmacen
        Return IngresoVehiculo(MyOperacionAlmacen, MyDetallesOperacion, MyDetallesOperacionSeries, MyControlVehiculos, MyOperacionAlmacenCompra)
    End Function

    Private Shared Function IngresoVehiculo(MyOperacionAlmacen As entOperacionAlmacen, MyDetallesOperacion As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, MyDetallesOperacionSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, MyControlVehiculos As dsProductos.CONTROL_VEHICULOSDataTable, MyOperacionAlmacenCompra As dsOperacionesAlmacen.OPERACIONES_ALMACEN_COMDataTable) As entOperacionAlmacen
        MyOperacionAlmacen.operacion = AsignarOperacion()

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                              "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                              "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                              "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,poliza,usuario_registro) " & _
                              "VALUES " & _
                              "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                              "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                              "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vPoliza,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                            .AddWithValue("vTipo_operacion", MyOperacionAlmacen.tipo_operacion)
                            .AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                            .AddWithValue("vMes", MyOperacionAlmacen.mes)
                            .AddWithValue("vFecha_operacion", MyOperacionAlmacen.fecha_operacion)
                            .AddWithValue("vComentario", MyOperacionAlmacen.comentario)
                            .AddWithValue("vTipo_es", MyOperacionAlmacen.tipo_es)
                            .AddWithValue("vReferencia_cuenta_comercial", MyOperacionAlmacen.referencia_cuenta_comercial)
                            .AddWithValue("vReferencia_tipo", MyOperacionAlmacen.referencia_tipo)
                            .AddWithValue("vReferencia_serie", MyOperacionAlmacen.referencia_serie)
                            .AddWithValue("vReferencia_numero", MyOperacionAlmacen.referencia_numero)
                            .AddWithValue("vReferencia_fecha", MyOperacionAlmacen.referencia_fecha)
                            .AddWithValue("vReferencia_tipo_moneda", MyOperacionAlmacen.referencia_tipo_moneda)
                            .AddWithValue("vReferencia_importe_total", MyOperacionAlmacen.referencia_importe_total)
                            .AddWithValue("vPoliza", MyOperacionAlmacen.poliza)
                            .AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                                      "(empresa,almacen,operacion,linea,producto,cantidad,precio_unitario_mn,precio_unitario_me,numero_lote," & _
                                      "fecha_vencimiento,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vPrecio_unitario_mn,@vPrecio_unitario_me,@vNumero_lote," & _
                                      "@vFecha_vencimiento,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                            .AddWithValue("vLinea", "001")
                            .AddWithValue("vProducto", MyDetallesOperacion(0).PRODUCTO)
                            .AddWithValue("vCantidad", MyDetallesOperacion(0).CANTIDAD)
                            .AddWithValue("vPrecio_unitario_mn", MyDetallesOperacion(0).PRECIO_UNITARIO_MN)
                            .AddWithValue("vPrecio_unitario_me", MyDetallesOperacion(0).PRECIO_UNITARIO_ME)
                            .AddWithValue("vNumero_lote", MyDetallesOperacion(0).NUMERO_LOTE)
                            .AddWithValue("vFecha_vencimiento", MyDetallesOperacion(0).FECHA_VENCIMIENTO)
                            .AddWithValue("vTipo_es", MyOperacionAlmacen.tipo_es)
                            .AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                            .AddWithValue("vMes", MyOperacionAlmacen.mes)
                            .AddWithValue("vComentario", MyOperacionAlmacen.comentario)
                            .AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        'Actualizar Stock por Almacen y por Periodo 
                        If MyDetallesOperacion(0).EXISTE_RESUMEN_ALMACEN = "SI" Then
                            MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                                      "Ingresos=Ingresos+@vIngresos,Egresos=Egresos+@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_2
                            MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(0).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyOperacionAlmacen.usuario_modifica)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(0).PRODUCTO)
                        Else
                            MySql_2 = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                                      "(empresa,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                            MySQLCommand.CommandText = MySql_2
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(0).PRODUCTO)
                            MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(0).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        End If
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        If MyDetallesOperacion(0).EXISTE_RESUMEN_PERIODO = "SI" Then
                            MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                                      "Ingresos=Ingresos+@vIngresos,Egresos=Egresos+@vEgresos,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(0).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                            MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(0).PRODUCTO)
                        Else
                            MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                      "(empresa,ejercicio,mes,almacen,numero_lote,fecha_vencimiento,producto,ingresos,egresos,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vFecha_vencimiento,@vProducto,@vIngresos,@vEgresos,@vUsuario_registro)"

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                            MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacion(0).PRODUCTO)
                            MySQLCommand.Parameters.AddWithValue("vIngresos", MyDetallesOperacion(0).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        End If
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Serie
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_3 = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                                  "(empresa,operacion,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                  "VALUES (@vEmpresa,@vOperacion,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

                        MySQLCommand.CommandText = MySql_3

                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacionSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesOperacionSeries(0).NUMERO_SERIE)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesOperacionSeries(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesOperacionSeries(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_4 = "INSERT INTO COM.CONTROL_SERIES " & _
                                  "(empresa,producto,numero_serie,numero_serie_chasis,color,almacen,referencia_operacion,fecha_operacion,usuario_registro) " & _
                                  "VALUES " & _
                                  "(@vEmpresa,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAlmacen,@vReferencia_operacion,@vFecha_operacion,@vUsuario_registro)"

                        MySQLCommand.CommandText = MySql_4
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesOperacionSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesOperacionSeries(0).NUMERO_SERIE)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesOperacionSeries(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesOperacionSeries(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                        MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", MyOperacionAlmacen.operacion)
                        MySQLCommand.Parameters.AddWithValue("vFecha_operacion", MyOperacionAlmacen.fecha_operacion)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Vehiculo
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_5 = "INSERT INTO COM.CONTROL_VEHICULOS " & _
                                  "(empresa,producto,numero_serie,numero_serie_chasis,color,año_fabricacion,marca,modelo,capacidad_motor," &
                                  "numero_cilindros,potencia_hp,potencia_kw,torque_nm,torque_rpm,numero_rpm,peso_neto,carga_util,peso_bruto," &
                                  "numero_asientos,numero_pasajeros,numero_ruedas,numero_ejes,combustible,longitud_largo,longitud_ancho,longitud_altura," &
                                  "poliza_numero,poliza_año,poliza_item,poliza_ipl,categoria_vehicular,numero_vin,usuario_registro) " & _
                                  "VALUES " & _
                                  "(@vEmpresa,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAño_fabricacion,@vMarca,@vModelo,@vCapacidad_motor," &
                                  "@vNumero_cilindros,@vPotencia_hp,@vPotencia_kw,@vTorque_nm,@vTorque_rpm,@vNumero_rpm,@vPeso_neto,@vCarga_util,@vPeso_bruto," &
                                  "@vNumero_asientos,@vNumero_pasajeros,@vNumero_ruedas,@vNumero_ejes,@vCombustible,@vLongitud_largo,@vLongitud_ancho,@vLongitud_altura," &
                                  "@vPoliza_numero,@vPoliza_año,@vPoliza_item,@vPoliza_ipl,@vCategoria_vehicular,@vNumero_vin,@vUsuario_registro) "

                        MySQLCommand.CommandText = MySql_5
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyControlVehiculos(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyControlVehiculos(0).NUMERO_SERIE)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyControlVehiculos(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyControlVehiculos(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vAño_fabricacion", MyControlVehiculos(0).AÑO_FABRICACION)
                        MySQLCommand.Parameters.AddWithValue("vMarca", MyControlVehiculos(0).MARCA)
                        MySQLCommand.Parameters.AddWithValue("vModelo", MyControlVehiculos(0).MODELO)
                        MySQLCommand.Parameters.AddWithValue("vCapacidad_motor", MyControlVehiculos(0).CAPACIDAD_MOTOR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_cilindros", MyControlVehiculos(0).NUMERO_CILINDROS)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_hp", MyControlVehiculos(0).POTENCIA_HP)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_kw", MyControlVehiculos(0).POTENCIA_KW)
                        MySQLCommand.Parameters.AddWithValue("vTorque_nm", MyControlVehiculos(0).TORQUE_NM)
                        MySQLCommand.Parameters.AddWithValue("vTorque_rpm", MyControlVehiculos(0).TORQUE_RPM)
                        MySQLCommand.Parameters.AddWithValue("vNumero_rpm", MyControlVehiculos(0).NUMERO_RPM)
                        MySQLCommand.Parameters.AddWithValue("vPeso_neto", MyControlVehiculos(0).PESO_NETO)
                        MySQLCommand.Parameters.AddWithValue("vCarga_util", MyControlVehiculos(0).CARGA_UTIL)
                        MySQLCommand.Parameters.AddWithValue("vPeso_bruto", MyControlVehiculos(0).PESO_BRUTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_asientos", MyControlVehiculos(0).NUMERO_ASIENTOS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_pasajeros", MyControlVehiculos(0).NUMERO_PASAJEROS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ruedas", MyControlVehiculos(0).NUMERO_RUEDAS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ejes", MyControlVehiculos(0).NUMERO_EJES)
                        MySQLCommand.Parameters.AddWithValue("vCombustible", MyControlVehiculos(0).COMBUSTIBLE)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_largo", MyControlVehiculos(0).LONGITUD_LARGO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_ancho", MyControlVehiculos(0).LONGITUD_ANCHO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_altura", MyControlVehiculos(0).LONGITUD_ALTURA)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_numero", MyControlVehiculos(0).POLIZA_NUMERO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_año", MyControlVehiculos(0).POLIZA_AÑO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_item", MyControlVehiculos(0).POLIZA_ITEM)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_ipl", MyControlVehiculos(0).POLIZA_IPL)
                        MySQLCommand.Parameters.AddWithValue("vCategoria_vehicular", MyControlVehiculos(0).CATEGORIA_VEHICULAR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_vin", MyControlVehiculos(0).NUMERO_VIN)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyOperacionAlmacen.usuario_registro)
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Compra al Crédito o Ingreso por Consignación si fuera el caso

                        If MyOperacionAlmacenCompra.Rows.Count <> 0 Then
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_COM " &
                                          "(empresa,operacion,importe_saldo,fecha_vencimiento,condicion_pago,indica_consignacion,usuario_registro) " &
                                          "VALUES " &
                                          "(@vEmpresa,@vOperacion,@vImporte_saldo,@vFecha_vencimiento,@vCondicion_pago,@vIndica_consignacion,@vUsuario_registro)"

                            MySQLCommand.CommandText = MySqlString
                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                                .AddWithValue("vImporte_saldo", MyOperacionAlmacenCompra(0).IMPORTE_SALDO)
                                .AddWithValue("vFecha_vencimiento", MyOperacionAlmacenCompra(0).FECHA_VENCIMIENTO)
                                .AddWithValue("vCondicion_pago", MyOperacionAlmacenCompra(0).CONDICION_PAGO)
                                .AddWithValue("vIndica_consignacion", MyOperacionAlmacenCompra(0).INDICA_CONSIGNACION)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyOperacionAlmacen
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function ActualizarIngresoVehiculo(MyOperacionAlmacen As entOperacionAlmacen, MyOperacionAlmacenDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, MyControlVehiculo As dsProductos.CONTROL_VEHICULOSDataTable, ExisteControlVehiculo As Boolean) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " &
                              "Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " &
                              "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)

                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " &
                                      "Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " &
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        'Actualizar Series
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_3 = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " &
                                  "Numero_serie_chasis=@vNumero_serie_chasis, Color=@vColor, Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " &
                                  "WHERE Empresa=@vEmpresa AND Operacion=@vOperacion AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySql_3
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyOperacionAlmacenDetalleSeries(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_4 = "UPDATE COM.CONTROL_SERIES SET " &
                                  "Numero_serie_chasis=@vNumero_serie_chasis,Color=@vColor,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySql_4
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyOperacionAlmacenDetalleSeries(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        If ExisteControlVehiculo = False Then
                            MySql_5 = "INSERT INTO COM.CONTROL_VEHICULOS " &
                                      "(empresa,producto,numero_serie,numero_serie_chasis,color,año_fabricacion,marca,modelo,capacidad_motor," &
                                      "numero_cilindros,potencia_hp,potencia_kw,torque_nm,torque_rpm,numero_rpm,peso_neto,carga_util,peso_bruto," &
                                      "numero_asientos,numero_pasajeros,numero_ruedas,numero_ejes,combustible,longitud_largo,longitud_ancho,longitud_altura," &
                                      "poliza_numero,poliza_año,poliza_item,poliza_ipl,categoria_vehicular,numero_vin,usuario_registro) " &
                                      "VALUES " &
                                      "(@vEmpresa,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAño_fabricacion,@vMarca,@vModelo,@vCapacidad_motor," &
                                      "@vNumero_cilindros,@vPotencia_hp,@vPotencia_kw,@vTorque_nm,@vTorque_rpm,@vNumero_rpm,@vPeso_neto,@vCarga_util,@vPeso_bruto," &
                                      "@vNumero_asientos,@vNumero_pasajeros,@vNumero_ruedas,@vNumero_ejes,@vCombustible,@vLongitud_largo,@vLongitud_ancho,@vLongitud_altura," &
                                      "@vPoliza_numero,@vPoliza_año,@vPoliza_item,@vPoliza_ipl,@vCategoria_vehicular,@vNumero_vin,@vUsuario_registro) "
                        Else
                            MySql_5 = "UPDATE COM.CONTROL_VEHICULOS SET " &
                                      "Numero_serie_chasis=@vNumero_serie_chasis,Color=@vColor,Año_fabricacion=@vAño_fabricacion,Marca=@vMarca,Modelo=@vModelo,Capacidad_motor=@vCapacidad_motor," &
                                      "Numero_cilindros=@vNumero_cilindros,Potencia_hp=@vPotencia_hp,Potencia_kw=@vPotencia_kw,Torque_nm=@vTorque_nm,Torque_rpm=@vTorque_rpm," &
                                      "Numero_rpm=@vNumero_rpm,Peso_neto=@vPeso_neto,Carga_util=@vCarga_util,Peso_bruto=@vPeso_bruto,Numero_asientos=@vNumero_asientos," &
                                      "Numero_pasajeros=@vNumero_pasajeros,Numero_ruedas=@vNumero_ruedas,Numero_ejes=@vNumero_ejes,Combustible=@vCombustible," &
                                      "Longitud_largo=@vLongitud_largo,Longitud_ancho=@vLongitud_ancho,Longitud_altura=@vLongitud_altura,Poliza_numero=@vPoliza_numero," &
                                      "Poliza_año=@vPoliza_año,Poliza_item=@vPoliza_item,Poliza_ipl=@vPoliza_ipl,Categoria_vehicular=@vCategoria_vehicular," &
                                      "Numero_vin=@vNumero_vin,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                      "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "
                        End If

                        MySQLCommand.CommandText = MySql_5
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyControlVehiculo(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyControlVehiculo(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vAño_fabricacion", MyControlVehiculo(0).AÑO_FABRICACION)
                        MySQLCommand.Parameters.AddWithValue("vMarca", MyControlVehiculo(0).MARCA)
                        MySQLCommand.Parameters.AddWithValue("vModelo", MyControlVehiculo(0).MODELO)
                        MySQLCommand.Parameters.AddWithValue("vCapacidad_motor", MyControlVehiculo(0).CAPACIDAD_MOTOR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_cilindros", MyControlVehiculo(0).NUMERO_CILINDROS)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_hp", MyControlVehiculo(0).POTENCIA_HP)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_kw", MyControlVehiculo(0).POTENCIA_KW)
                        MySQLCommand.Parameters.AddWithValue("vTorque_nm", MyControlVehiculo(0).TORQUE_NM)
                        MySQLCommand.Parameters.AddWithValue("vTorque_rpm", MyControlVehiculo(0).TORQUE_RPM)
                        MySQLCommand.Parameters.AddWithValue("vNumero_rpm", MyControlVehiculo(0).NUMERO_RPM)
                        MySQLCommand.Parameters.AddWithValue("vPeso_neto", MyControlVehiculo(0).PESO_NETO)
                        MySQLCommand.Parameters.AddWithValue("vCarga_util", MyControlVehiculo(0).CARGA_UTIL)
                        MySQLCommand.Parameters.AddWithValue("vPeso_bruto", MyControlVehiculo(0).PESO_BRUTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_asientos", MyControlVehiculo(0).NUMERO_ASIENTOS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_pasajeros", MyControlVehiculo(0).NUMERO_PASAJEROS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ruedas", MyControlVehiculo(0).NUMERO_RUEDAS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ejes", MyControlVehiculo(0).NUMERO_EJES)
                        MySQLCommand.Parameters.AddWithValue("vCombustible", MyControlVehiculo(0).COMBUSTIBLE)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_largo", MyControlVehiculo(0).LONGITUD_LARGO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_ancho", MyControlVehiculo(0).LONGITUD_ANCHO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_altura", MyControlVehiculo(0).LONGITUD_ALTURA)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_numero", MyControlVehiculo(0).POLIZA_NUMERO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_año", MyControlVehiculo(0).POLIZA_AÑO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_item", MyControlVehiculo(0).POLIZA_ITEM)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_ipl", MyControlVehiculo(0).POLIZA_IPL)
                        MySQLCommand.Parameters.AddWithValue("vCategoria_vehicular", MyControlVehiculo(0).CATEGORIA_VEHICULAR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_vin", MyControlVehiculo(0).NUMERO_VIN)

                        If ExisteControlVehiculo = False Then
                            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        Else
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        End If

                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyControlVehiculo(0).EMPRESA)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyControlVehiculo(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyControlVehiculo(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function AnularIngresoVehiculo(MyOperacionAlmacen As entOperacionAlmacen, MyOperacionAlmacenDetalles As dsOperacionesAlmacen.NOTA_ALMACEN_DETDataTable, MyOperacionAlmacenDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                              "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                              "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)

                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                                      "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Operacion=@vOperacion "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                            .AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        'Actualizar Stock por Almacen y por Periodo 
                        MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET " & _
                                  "Ingresos=Ingresos-1,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySql_2
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET " & _
                                  "Ingresos=Ingresos-1,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySql_3
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vEjercicio", MyOperacionAlmacen.ejercicio)
                        MySQLCommand.Parameters.AddWithValue("vMes", MyOperacionAlmacen.mes)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyOperacionAlmacen.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalles(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Series
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_3 = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " & _
                                  "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Operacion=@vOperacion AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySql_3
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vOperacion", MyOperacionAlmacen.operacion)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_4 = "UPDATE COM.CONTROL_SERIES SET " & _
                                  "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySql_4
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySql_5 = "UPDATE COM.CONTROL_VEHICULOS SET " & _
                                  "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySql_5
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyOperacionAlmacenDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyOperacionAlmacenDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function BuscarCompraAnterior(ByVal pEmpresa As String, ByVal pProducto As String, pNumeroSerie As String) As dsOperacionesAlmacen.COMPRAS_PROVEEDORDataTable
        MySqlString = "SELECT " &
                      "PROVEEDOR='Proveedor: ' + RTRIM(CC.RAZON_SOCIAL), " &
                      "COMPROBANTE='Comprobante: ' + H.REFERENCIA_TIPO + '/' + H.REFERENCIA_SERIE + '-' + H.REFERENCIA_NUMERO, " &
                      "COMPROBANTE_FECHA='Fecha: ' + CONVERT(VARCHAR, H.REFERENCIA_FECHA, 103), H.USUARIO_REGISTRO, H.FECHA_REGISTRO " &
                      "FROM ALM.OPERACIONES_ALMACEN_DET_SERIES AS D " &
                      "INNER JOIN ALM.OPERACIONES_ALMACEN AS H ON D.EMPRESA = H.EMPRESA AND D.OPERACION = H.OPERACION " &
                      "INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.REFERENCIA_CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " &
                      "WHERE D.EMPRESA=@vEmpresa AND H.TIPO_OPERACION = '02' AND D.PRODUCTO=@vProducto AND D.NUMERO_SERIE=@vNumero_serie "
        Dim MyDT As New dsOperacionesAlmacen.COMPRAS_PROVEEDORDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", pNumeroSerie)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

#End Region

#Region "Traslado Interno"

    Public Shared Function GrabarTraslado(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        With Guia
            If .indica_transporte_publico = "SI" Then
                If .transportista_ruc.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " RUC DEL TRANSPORTISTA")
                If .transportista_razon_social.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " RAZON SOCIAL DEL TRNASPORTISTA")
            Else
                If .conductor_dni.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " DNI DEL CONDUCTOR")
                If .conductor_nombre.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " NOMBRE DEL CONDUCTOR")
                If .numero_placa.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " NUMERO DE PLACA")
            End If
        End With

        Return InsertarTraslado(Operacion, OperacionDetalles, OperacionDetalleSeries, Guia)
    End Function

    Private Shared Function InsertarTraslado(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        Dim Linea As Byte = 0
        Dim LineaOperacion As String

        Operacion.operacion = AsignarOperacion()
        Guia.guia = AsignarGuia()
        Operacion.referencia_cuo = Guia.guia

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                              "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                              "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                              "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,usuario_registro) " & _
                              "VALUES " & _
                              "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                              "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                              "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                            .AddWithValue("vTipo_operacion", Operacion.tipo_operacion)
                            .AddWithValue("vEjercicio", Operacion.ejercicio)
                            .AddWithValue("vMes", Operacion.mes)
                            .AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                            .AddWithValue("vComentario", Operacion.comentario)
                            .AddWithValue("vTipo_es", "S")
                            .AddWithValue("vReferencia_cuenta_comercial", Operacion.referencia_cuenta_comercial)
                            .AddWithValue("vReferencia_tipo", Operacion.referencia_tipo)
                            .AddWithValue("vReferencia_serie", Operacion.referencia_serie)
                            .AddWithValue("vReferencia_numero", Operacion.referencia_numero)
                            .AddWithValue("vReferencia_fecha", Operacion.referencia_fecha)
                            .AddWithValue("vReferencia_tipo_moneda", Operacion.referencia_tipo_moneda)
                            .AddWithValue("vReferencia_importe_total", Operacion.referencia_importe_total)
                            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                                      "(empresa,almacen,operacion,linea,producto,cantidad,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", Operacion.almacen)
                                .AddWithValue("vOperacion", Operacion.operacion)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vTipo_es", "S")
                                .AddWithValue("vEjercicio", Operacion.ejercicio)
                                .AddWithValue("vMes", Operacion.mes)
                                .AddWithValue("vComentario", Operacion.comentario)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            If Operacion.afecta_stock = "SI" Then
                                '' El Resumen_x_Almacen para el origen se supone que existe por eso solo se actualiza, 

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos+@vCantidad," & _
                                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_2
                                MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                MySQLCommand.ExecuteNonQuery()

                                '' El Resumen_x_Periodo tanto para el origen (EXISTE_RESUMEN_PERIODO) como para 
                                ''el destino (EXISTE_RESUMEN_PERIODO2)se debió averiguar y actualizar el campo   
                                ''respectivo.

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If OperacionDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI" Then
                                    MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos+@vCantidad," & _
                                              "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                    MySQLCommand.CommandText = MySql_3
                                    MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                    MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                Else
                                    MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                            "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                                            "VALUES " & _
                                            "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                                    MySQLCommand.CommandText = MySql_3
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                    MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", OperacionDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            End If
                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                                          "(empresa,operacion,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vOperacion,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro)"
                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.CommandText = MySqlString
                                MySQLCommand.Parameters.Clear()

                                With MySQLCommand.Parameters
                                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                                    .AddWithValue("vOperacion", Operacion.operacion)
                                    .AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    .AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    .AddWithValue("vNumero_serie_chasis", OperacionDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                    .AddWithValue("vColor", OperacionDetalleSeries(NEle).COLOR)
                                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End With
                                MySQLCommand.ExecuteNonQuery()

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If OperacionDetalleSeries(NEle).EXISTE_CONTROL_SERIES = "SI" Then
                                    MySql_2 = "UPDATE COM.CONTROL_SERIES SET " & _
                                              "Almacen=@vAlmacen,Estado=@vEstado,Referencia_operacion=@vReferencia_operacion,Fecha_operacion=@vFecha_operacion," & _
                                              "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                    MySQLCommand.CommandText = MySql_2
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)

                                    If Operacion.tipo_es = "I" Then
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                                    Else
                                        MySQLCommand.Parameters.AddWithValue("vEstado", "N")
                                    End If

                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", Operacion.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                Else
                                    MySql_2 = "INSERT INTO COM.CONTROL_SERIES " & _
                                            "(empresa,producto,numero_serie,numero_serie_chasis,color,almacen,referencia_operacion,fecha_operacion,usuario_registro) " & _
                                            "VALUES " & _
                                            "(@vEmpresa,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAlmacen,@vReferencia_operacion,@vFecha_operacion,@vUsuario_registro)"

                                    MySQLCommand.CommandText = MySql_2
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", OperacionDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                    MySQLCommand.Parameters.AddWithValue("vColor", OperacionDetalleSeries(NEle).COLOR)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", Operacion.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        Linea = 0

                        MySqlString = "INSERT INTO COM.GUIAS " &
                                      "(empresa,guia,ejercicio,mes,tipo_operacion,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero," &
                                      "comprobante_fecha,comprobante_fecha_traslado,almacen,almacen_destino,referencia_cuo,domicilio_envio,motivo_traslado,punto_partida," &
                                      "punto_llegada,destinatario_tipo_documento,destinatario_nro_documento,destinatario_razon_social,conductor_dni,conductor_nombre," &
                                      "numero_placa,transportista_ruc,transportista_razon_social,comentario,indica_transporte_publico,usuario_registro) " &
                                      "VALUES (" &
                                      "@vEmpresa,@vGuia,@vEjercicio,@vMes,@vTipo_operacion,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero," &
                                      "@vComprobante_fecha,@vComprobante_fecha_traslado,@vAlmacen,@vAlmacen_destino,@vReferencia_cuo,@vDomicilio_envio,@vMotivo_traslado,@vPunto_partida," &
                                      "@vPunto_llegada,@vDestinatario_tipo_documento,@vDestinatario_nro_documento,@vDestinatario_razon_social,@vConductor_dni,@vconductor_nombre," &
                                      "@vNumero_placa,@vTransportista_ruc,@vTransportista_razon_social,@vComentario,@vIndica_transporte_publico,@vUsuario_registro) "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", Guia.empresa)
                            .AddWithValue("vGuia", Guia.guia)
                            .AddWithValue("vEjercicio", Guia.ejercicio)
                            .AddWithValue("vMes", Guia.mes)
                            .AddWithValue("vTipo_operacion", Guia.tipo_operacion)
                            .AddWithValue("vCuenta_comercial", Guia.cuenta_comercial.Trim)
                            .AddWithValue("vComprobante_tipo", Guia.comprobante_tipo)
                            .AddWithValue("vComprobante_serie", Guia.comprobante_serie)
                            .AddWithValue("vComprobante_numero", Guia.comprobante_numero)
                            .AddWithValue("vComprobante_fecha", Guia.comprobante_fecha)
                            .AddWithValue("vComprobante_fecha_traslado", Guia.comprobante_fecha_traslado)
                            .AddWithValue("vAlmacen", Guia.almacen)
                            .AddWithValue("vAlmacen_destino", Guia.almacen_destino)
                            .AddWithValue("vDomicilio_envio", Guia.domicilio_envio)

                            .AddWithValue("vReferencia_cuo", Operacion.operacion)

                            .AddWithValue("vMotivo_traslado", Guia.motivo_traslado)
                            .AddWithValue("vPunto_partida", Guia.punto_partida)
                            .AddWithValue("vPunto_llegada", Guia.punto_llegada)
                            .AddWithValue("vDestinatario_tipo_documento", Guia.destinatario_tipo_documento)
                            .AddWithValue("vDestinatario_nro_documento", Guia.destinatario_nro_documento)
                            .AddWithValue("vDestinatario_razon_social", Guia.destinatario_razon_social)
                            .AddWithValue("vConductor_dni", Guia.conductor_dni)
                            .AddWithValue("vConductor_nombre", Guia.conductor_nombre)
                            .AddWithValue("vNumero_placa", Guia.numero_placa)
                            .AddWithValue("vTransportista_ruc", Guia.transportista_ruc)
                            .AddWithValue("vTransportista_razon_social", Guia.transportista_razon_social)
                            .AddWithValue("vComentario", Guia.comentario)
                            .AddWithValue("vIndica_transporte_publico", Guia.indica_transporte_publico)
                            .AddWithValue("vUsuario_registro", Guia.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO COM.GUIAS_DET " & _
                                      "(empresa,guia,linea,producto,cantidad_por_atender,cantidad_atendida,indica_serie,usuario_registro) " & _
                                      "VALUES (@vEmpresa,@vGuia,@vLinea,@vProducto,@vCantidad_por_atender,@vCantidad_atendida,@vIndica_serie,@vUsuario_registro) "
                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vGuia", Guia.guia)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad_por_atender", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vCantidad_atendida", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vIndica_serie", OperacionDetalles(NEle).INDICA_SERIE)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "INSERT INTO COM.GUIAS_DET_SERIES " & _
                                          "(empresa,guia,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                          "VALUES (@vEmpresa,@vGuia,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.CommandText = MySqlString
                                MySQLCommand.Parameters.Clear()

                                With MySQLCommand.Parameters
                                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                                    .AddWithValue("vGuia", Guia.guia)
                                    .AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    .AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    .AddWithValue("vNumero_serie_chasis", OperacionDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                    .AddWithValue("vColor", OperacionDetalleSeries(NEle).COLOR)
                                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End With
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return Operacion
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function AsignarGuia() As String
        MySqlString = "SELECT ISNULL(MAX(GUIA),'') AS NUEVO_CODIGO FROM COM.GUIAS " & _
                      "WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "GR0000000001"
            Else
                Correlativo = CLng(NewCode.Substring(2, 10)) + 1
                NewCode = "GR" & Right("0000000000" & Correlativo.ToString, 10)
            End If
            Return NewCode
        End Using
    End Function

    Public Shared Function AnularTraslado(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As Boolean

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                              "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                              "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"
                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            If Operacion.afecta_stock = "SI" Then
                                '' El Resumen_x_Almacen para el origen se supone que existe por eso solo se actualiza, 

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-@vCantidad," & _
                                          "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_2
                                MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", 0)
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                MySQLCommand.ExecuteNonQuery()

                                '' El Resumen_x_Periodo tanto para el origen (EXISTE_RESUMEN_PERIODO) como para 
                                ''el destino (EXISTE_RESUMEN_PERIODO2)se debió averiguar y actualizar el campo   
                                ''respectivo.

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If OperacionDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI" Then
                                    MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-@vCantidad," & _
                                              "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                    MySQLCommand.CommandText = MySql_3
                                    MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                    MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                Else
                                    MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                            "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                                            "VALUES " & _
                                            "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                                    MySQLCommand.CommandText = MySql_3
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                    MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_lote", Numero_Lote_Nulo)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vIngresos", OperacionDetalles(NEle).CANTIDAD)
                                    MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            End If
                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " & _
                                          "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                          "WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion"

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vOperacion", Operacion.operacion)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If OperacionDetalleSeries(NEle).EXISTE_CONTROL_SERIES = "SI" Then
                                    MySql_2 = "UPDATE COM.CONTROL_SERIES SET " & _
                                              "estado='D', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                              "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                    MySQLCommand.CommandText = MySql_2
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        MySqlString = "UPDATE COM.GUIAS SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia"

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", Guia.usuario_registro)
                            .AddWithValue("vEmpresa", Guia.empresa)
                            .AddWithValue("vGuia", Guia.guia)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE COM.GUIAS_DET SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia"
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.ExecuteNonQuery()
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

#End Region

#Region "Traslado Externo "

    Public Shared Function GrabarTrasladoExterno(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        With Guia
            If .indica_transporte_publico = "SI" Then
                If .transportista_ruc.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " RUC DEL TRANSPORTISTA")
                If .transportista_razon_social.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " RAZON SOCIAL DEL TRNASPORTISTA")
            Else
                If .conductor_dni.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " DNI DEL CONDUCTOR")
                If .conductor_nombre.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " NOMBRE DEL CONDUCTOR")
                If .numero_placa.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " NUMERO DE PLACA")
            End If
        End With

        Return InsertarTrasladoExterno(Operacion, OperacionDetalles, OperacionDetalleSeries, Guia)
    End Function

    Private Shared Function InsertarTrasladoExterno(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        Dim Linea As Byte = 0
        Dim LineaOperacion As String

        Operacion.operacion = AsignarOperacion()
        Guia.guia = AsignarGuia()
        Operacion.referencia_cuo = Guia.guia

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                              "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                              "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                              "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,usuario_registro) " & _
                              "VALUES " & _
                              "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                              "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                              "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                            .AddWithValue("vTipo_operacion", Operacion.tipo_operacion)
                            .AddWithValue("vEjercicio", Operacion.ejercicio)
                            .AddWithValue("vMes", Operacion.mes)
                            .AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                            .AddWithValue("vComentario", Operacion.comentario)
                            .AddWithValue("vTipo_es", "S")
                            .AddWithValue("vReferencia_cuenta_comercial", Operacion.referencia_cuenta_comercial)
                            .AddWithValue("vReferencia_tipo", Operacion.referencia_tipo)
                            .AddWithValue("vReferencia_serie", Operacion.referencia_serie)
                            .AddWithValue("vReferencia_numero", Operacion.referencia_numero)
                            .AddWithValue("vReferencia_fecha", Operacion.referencia_fecha)
                            .AddWithValue("vReferencia_tipo_moneda", Operacion.referencia_tipo_moneda)
                            .AddWithValue("vReferencia_importe_total", Operacion.referencia_importe_total)
                            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                                      "(empresa,almacen,operacion,linea,producto,cantidad,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", Operacion.almacen)
                                .AddWithValue("vOperacion", Operacion.operacion)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vTipo_es", "S")
                                .AddWithValue("vEjercicio", Operacion.ejercicio)
                                .AddWithValue("vMes", Operacion.mes)
                                .AddWithValue("vComentario", Operacion.comentario)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                                          "(empresa,operacion,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vOperacion,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro)"
                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.CommandText = MySqlString
                                MySQLCommand.Parameters.Clear()

                                With MySQLCommand.Parameters
                                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                                    .AddWithValue("vOperacion", Operacion.operacion)
                                    .AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    .AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    .AddWithValue("vNumero_serie_chasis", OperacionDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                    .AddWithValue("vColor", OperacionDetalleSeries(NEle).COLOR)
                                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End With
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        Linea = 0

                        MySqlString = "INSERT INTO COM.GUIAS " &
                                      "(empresa,guia,ejercicio,mes,tipo_operacion,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero," &
                                      "comprobante_fecha,comprobante_fecha_traslado,almacen,almacen_destino,referencia_cuo,domicilio_envio,motivo_traslado,punto_partida," &
                                      "punto_llegada,destinatario_tipo_documento,destinatario_nro_documento,destinatario_razon_social,conductor_dni,conductor_nombre," &
                                      "numero_placa,transportista_ruc,transportista_razon_social,comentario,indica_transporte_publico,usuario_registro) " &
                                      "VALUES (" &
                                      "@vEmpresa,@vGuia,@vEjercicio,@vMes,@vTipo_operacion,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero," &
                                      "@vComprobante_fecha,@vComprobante_fecha_traslado,@vAlmacen,@vAlmacen_destino,@vReferencia_cuo,@vDomicilio_envio,@vMotivo_traslado,@vPunto_partida," &
                                      "@vPunto_llegada,@vDestinatario_tipo_documento,@vDestinatario_nro_documento,@vDestinatario_razon_social,@vConductor_dni,@vconductor_nombre," &
                                      "@vNumero_placa,@vTransportista_ruc,@vTransportista_razon_social,@vComentario,@vIndica_transporte_publico,@vUsuario_registro) "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", Guia.empresa)
                            .AddWithValue("vGuia", Guia.guia)
                            .AddWithValue("vEjercicio", Guia.ejercicio)
                            .AddWithValue("vMes", Guia.mes)
                            .AddWithValue("vTipo_operacion", Guia.tipo_operacion)
                            .AddWithValue("vCuenta_comercial", Guia.cuenta_comercial.Trim)
                            .AddWithValue("vComprobante_tipo", Guia.comprobante_tipo)
                            .AddWithValue("vComprobante_serie", Guia.comprobante_serie)
                            .AddWithValue("vComprobante_numero", Guia.comprobante_numero)
                            .AddWithValue("vComprobante_fecha", Guia.comprobante_fecha)
                            .AddWithValue("vComprobante_fecha_traslado", Guia.comprobante_fecha_traslado)
                            .AddWithValue("vAlmacen", Guia.almacen)
                            .AddWithValue("vAlmacen_destino", Guia.almacen_destino)
                            .AddWithValue("vDomicilio_envio", Guia.domicilio_envio)

                            .AddWithValue("vReferencia_cuo", Operacion.operacion)

                            .AddWithValue("vMotivo_traslado", Guia.motivo_traslado)
                            .AddWithValue("vPunto_partida", Guia.punto_partida)
                            .AddWithValue("vPunto_llegada", Guia.punto_llegada)
                            .AddWithValue("vDestinatario_tipo_documento", Guia.destinatario_tipo_documento)
                            .AddWithValue("vDestinatario_nro_documento", Guia.destinatario_nro_documento)
                            .AddWithValue("vDestinatario_razon_social", Guia.destinatario_razon_social)
                            .AddWithValue("vConductor_dni", Guia.conductor_dni)
                            .AddWithValue("vConductor_nombre", Guia.conductor_nombre)
                            .AddWithValue("vNumero_placa", Guia.numero_placa)
                            .AddWithValue("vTransportista_ruc", Guia.transportista_ruc)
                            .AddWithValue("vTransportista_razon_social", Guia.transportista_razon_social)
                            .AddWithValue("vComentario", Guia.comentario)
                            .AddWithValue("vIndica_transporte_publico", Guia.indica_transporte_publico)
                            .AddWithValue("vUsuario_registro", Guia.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO COM.GUIAS_DET " & _
                                      "(empresa,guia,linea,producto,cantidad_por_atender,cantidad_atendida,indica_serie,usuario_registro) " & _
                                      "VALUES (@vEmpresa,@vGuia,@vLinea,@vProducto,@vCantidad_por_atender,@vCantidad_atendida,@vIndica_serie,@vUsuario_registro) "
                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vGuia", Guia.guia)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad_por_atender", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vCantidad_atendida", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vIndica_serie", OperacionDetalles(NEle).INDICA_SERIE)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        MySqlString = "INSERT INTO COM.GUIAS_DET_SERIES " & _
                                      "(empresa,guia,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                      "VALUES (@vEmpresa,@vGuia,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

                        For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vGuia", Guia.guia)
                                .AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                .AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                .AddWithValue("vNumero_serie_chasis", OperacionDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                .AddWithValue("vColor", OperacionDetalleSeries(NEle).COLOR)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return Operacion
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function AnularTrasladoExterno(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As Boolean

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                              "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                              "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"
                        MySQLCommand.ExecuteNonQuery()

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " & _
                                          "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                          "WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion"

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vOperacion", Operacion.operacion)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        End If

                        MySqlString = "UPDATE COM.GUIAS SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia"

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", Guia.usuario_registro)
                            .AddWithValue("vEmpresa", Guia.empresa)
                            .AddWithValue("vGuia", Guia.guia)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE COM.GUIAS_DET SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia"
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE COM.GUIAS_DET_SERIES SET " & _
                                      "estado='N', fecha_modifica=GETDATE(), usuario_modifica=@vUsuario_modifica " & _
                                      "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia"
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.ExecuteNonQuery()

                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

#End Region


#Region "Transferencias"

    Public Shared Function ObtenerDetallesTransferencia(pEmpresa As String, pAlmacen As String, pOperacion As String) As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable
        MySqlString = "SELECT D.LINEA, D.PRODUCTO, RTRIM(P.DESCRIPCION_AMPLIADA) AS DESCRIPCION_AMPLIADA, D.CANTIDAD, P.INDICA_SERIE, " & _
                      "'SI' AS EXISTE_RESUMEN_ALMACEN, 'SI' AS EXISTE_RESUMEN_PERIODO, 'SI' AS EXISTE_RESUMEN_PERIODO2 " & _
                      "FROM ALM.OPERACIONES_ALMACEN AS H INNER JOIN ALM.OPERACIONES_ALMACEN_DET AS D ON H.EMPRESA = D.EMPRESA AND H.ALMACEN = D.ALMACEN AND H.OPERACION = D.OPERACION " & _
                                                        "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " & _
                      "WHERE H.EMPRESA=@vEmpresa AND H.ALMACEN=@vAlmacen AND H.OPERACION=@vOperacion "

        Dim MyDT As New dsOperacionesAlmacen.DETALLE_OPERACIONDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetallesTransferenciaSeries(pEmpresa As String, pOperacion As String) As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable
        MySqlString = "SELECT EMPRESA, OPERACION, PRODUCTO, NUMERO_SERIE, ESTADO, USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA, EXISTE_CONTROL_SERIES='SI' " & _
                      "FROM ALM.OPERACIONES_ALMACEN_DET_SERIES WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vOperacion", pOperacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerTransferencia(ByVal pOperacion As String) As entOperacionTransferencia
        CadenaSQL = "SELECT * FROM ALM.OPERACIONES_ALMACEN_TRA WHERE EMPRESA='" & MyUsuario.empresa & "' AND OPERACION='" & pOperacion & "' "
        Return ObtenerTransferencia(New entOperacionTransferencia, CadenaSQL)
    End Function

    Private Shared Function ObtenerTransferencia(ByVal cOperacionTransferencia As entOperacionTransferencia, ByVal MyStringSQL As String) As entOperacionTransferencia
        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cOperacionTransferencia
                .empresa = MyDT(0).EMPRESA
                .operacion = MyDT(0).OPERACION
                .almacen_origen = MyDT(0).ALMACEN_ORIGEN
                .almacen_destino = MyDT(0).ALMACEN_DESTINO
                .referencia_cuo = MyDT(0).REFERENCIA_CUO
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cOperacionTransferencia
    End Function

    Public Shared Function GrabarTransferencia(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        With Operacion
            If Year(.fecha_operacion) * 100 + Month(.fecha_operacion) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            If String.IsNullOrEmpty(.almacen) Then Throw New BusinessException(MSG000 & " ALMACEN")
            If String.IsNullOrEmpty(.tipo_operacion) Then Throw New BusinessException(MSG000 & " TIPO DE OPERACION")
        End With

        Return InsertarTransferencia(Operacion, OperacionDetalles, OperacionDetalleSeries, Guia)
    End Function

    Private Shared Function InsertarTransferencia(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As entOperacionAlmacen
        Dim Linea As Byte = 0
        Dim LineaOperacion As String

        Operacion.operacion = AsignarOperacion()

        If Operacion.exige_guia = "SI" Then
            Guia.guia = AsignarGuia()
            Operacion.referencia_cuo = Guia.guia
        End If

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN " & _
                              "(empresa,almacen,operacion,tipo_operacion,ejercicio,mes,fecha_operacion,comentario,tipo_es," & _
                              "referencia_cuenta_comercial,referencia_tipo,referencia_serie,referencia_numero," & _
                              "referencia_fecha,referencia_tipo_moneda,referencia_importe_total,usuario_registro) " & _
                              "VALUES " & _
                              "(@vEmpresa,@vAlmacen,@vOperacion,@vTipo_operacion,@vEjercicio,@vMes,@vFecha_operacion,@vComentario,@vTipo_es," & _
                              "@vReferencia_cuenta_comercial,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero," & _
                              "@vReferencia_fecha,@vReferencia_tipo_moneda,@vReferencia_importe_total,@vUsuario_registro)"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                            .AddWithValue("vTipo_operacion", Operacion.tipo_operacion)
                            .AddWithValue("vEjercicio", Operacion.ejercicio)
                            .AddWithValue("vMes", Operacion.mes)
                            .AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                            .AddWithValue("vComentario", Operacion.comentario)
                            .AddWithValue("vTipo_es", "T")
                            .AddWithValue("vReferencia_cuenta_comercial", Operacion.referencia_cuenta_comercial)
                            .AddWithValue("vReferencia_tipo", Operacion.referencia_tipo)
                            .AddWithValue("vReferencia_serie", Operacion.referencia_serie)
                            .AddWithValue("vReferencia_numero", Operacion.referencia_numero)
                            .AddWithValue("vReferencia_fecha", Operacion.referencia_fecha)
                            .AddWithValue("vReferencia_tipo_moneda", Operacion.referencia_tipo_moneda)
                            .AddWithValue("vReferencia_importe_total", Operacion.referencia_importe_total)
                            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_TRA " & _
                                      "(empresa,operacion,almacen_origen,almacen_destino,referencia_cuo,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vOperacion,@vAlmacen_origen,@vAlmacen_destino,@vReferencia_cuo,@vUsuario_registro)"
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vOperacion", Operacion.operacion)
                            .AddWithValue("vAlmacen_origen", Operacion.almacen)
                            .AddWithValue("vAlmacen_destino", Operacion.almacen_destino)
                            .AddWithValue("vReferencia_cuo", Operacion.referencia_cuo)
                            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET " & _
                                      "(empresa,almacen,operacion,linea,producto,cantidad,tipo_es,ejercicio,mes,comentario,usuario_registro) " & _
                                      "VALUES " & _
                                      "(@vEmpresa,@vAlmacen,@vOperacion,@vLinea,@vProducto,@vCantidad,@vTipo_es,@vEjercicio,@vMes,@vComentario,@vUsuario_registro)"

                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", Operacion.almacen)
                                .AddWithValue("vOperacion", Operacion.operacion)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vTipo_es", "S")
                                .AddWithValue("vEjercicio", Operacion.ejercicio)
                                .AddWithValue("vMes", Operacion.mes)
                                .AddWithValue("vComentario", Operacion.comentario)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vAlmacen", Operacion.almacen_destino)
                                .AddWithValue("vOperacion", Operacion.operacion)
                                .AddWithValue("vLinea", LineaOperacion)
                                .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                .AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                .AddWithValue("vTipo_es", "I")
                                .AddWithValue("vEjercicio", Operacion.ejercicio)
                                .AddWithValue("vMes", Operacion.mes)
                                .AddWithValue("vComentario", Operacion.comentario)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            '' El Resumen_x_Almacen para el origen se supone que existe por eso solo se actualiza, 
                            '' para el destino se debió averiguar y actualizar el campo EXISTE_RESUMEN_ALMACEN 
                            '' a fin de determinar si se actualiza o se inserta un nuevo registro.

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos+@vCantidad," & _
                                    "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                    "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_2
                            MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            If OperacionDetalles(NEle).EXISTE_RESUMEN_ALMACEN = "SI" Then
                                MySql_3 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Ingresos=Ingresos+@vCantidad," & _
                                        "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                        "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            Else
                                MySql_3 = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                                        "(empresa,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                                        "VALUES " & _
                                        "(@vEmpresa,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vIngresos", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End If
                            MySQLCommand.ExecuteNonQuery()

                            '' El Resumen_x_Periodo tanto para el origen (EXISTE_RESUMEN_PERIODO) como para 
                            ''el destino (EXISTE_RESUMEN_PERIODO2)se debió averiguar y actualizar el campo   
                            ''respectivo.

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            If OperacionDetalles(NEle).EXISTE_RESUMEN_PERIODO = "SI" Then
                                MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos+@vCantidad," & _
                                          "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            Else
                                MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                        "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                                        "VALUES " & _
                                        "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
                                MySQLCommand.Parameters.AddWithValue("vEgresos", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End If
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            If OperacionDetalles(NEle).EXISTE_RESUMEN_PERIODO2 = "SI" Then
                                MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Ingresos=Ingresos+@vCantidad," & _
                                          "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            Else
                                MySql_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                                        "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                                        "VALUES " & _
                                        "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

                                MySQLCommand.CommandText = MySql_3
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vIngresos", OperacionDetalles(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vEgresos", 0)
                                MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End If
                            MySQLCommand.ExecuteNonQuery()

                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySqlString = "INSERT INTO ALM.OPERACIONES_ALMACEN_DET_SERIES " & _
                                          "(empresa,operacion,producto,numero_serie,usuario_registro) " & _
                                          "VALUES " & _
                                          "(@vEmpresa,@vOperacion,@vProducto,@vNumero_serie,@vUsuario_registro)"
                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.CommandText = MySqlString
                                MySQLCommand.Parameters.Clear()

                                With MySQLCommand.Parameters
                                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                                    .AddWithValue("vOperacion", Operacion.operacion)
                                    .AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    .AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End With
                                MySQLCommand.ExecuteNonQuery()

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                If OperacionDetalleSeries(NEle).EXISTE_CONTROL_SERIES = "SI" Then
                                    MySql_2 = "UPDATE COM.CONTROL_SERIES SET " & _
                                              "Almacen=@vAlmacen,Referencia_operacion=@vReferencia_operacion,Fecha_operacion=@vFecha_operacion," & _
                                              "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                              "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                    MySQLCommand.CommandText = MySql_2
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", Operacion.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                Else
                                    MySql_2 = "INSERT INTO COM.CONTROL_SERIES " & _
                                            "(empresa,producto,numero_serie,almacen,referencia_operacion,fecha_operacion,usuario_registro) " & _
                                            "VALUES " & _
                                            "(@vEmpresa,@vProducto,@vNumero_serie,@vAlmacen,@vReferencia_operacion,@vFecha_operacion,@vUsuario_registro)"

                                    MySQLCommand.CommandText = MySql_2
                                    MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                    MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                    MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                    MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                                    MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", Operacion.operacion)
                                    MySQLCommand.Parameters.AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                                    MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End If
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        If Operacion.exige_guia = "SI" Then
                            Linea = 0
                            MySqlString = "INSERT INTO COM.GUIAS " & _
                                          "(empresa,guia,ejercicio,mes,tipo_operacion,cuenta_comercial,centro_distribucion," & _
                                          "comprobante_tipo,comprobante_serie,comprobante_numero,comprobante_fecha,comprobante_fecha_traslado," & _
                                          "almacen,almacen_destino,transportista,unidad_transporte,motivo_traslado,comentario,usuario_registro) " & _
                                          "VALUES (" & _
                                          "@vEmpresa,@vGuia,@vEjercicio,@vMes,@vTipo_operacion,@vCuenta_comercial,@vCentro_distribucion," & _
                                          "@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha,@vComprobante_fecha_traslado," & _
                                          "@vAlmacen,@vAlmacen_destino,@vTransportista,@vUnidad_transporte,@vMotivo_traslado,@vComentario,@vUsuario_registro) "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", Guia.empresa)
                                .AddWithValue("vGuia", Guia.guia)
                                .AddWithValue("vEjercicio", Guia.ejercicio)
                                .AddWithValue("vMes", Guia.mes)
                                .AddWithValue("vTipo_operacion", Guia.tipo_operacion)
                                .AddWithValue("vCuenta_comercial", Guia.cuenta_comercial.Trim)
                                .AddWithValue("vCentro_distribucion", Guia.centro_distribucion)
                                .AddWithValue("vComprobante_tipo", Guia.comprobante_tipo)
                                .AddWithValue("vComprobante_serie", Guia.comprobante_serie)
                                .AddWithValue("vComprobante_numero", Guia.comprobante_numero)
                                .AddWithValue("vComprobante_fecha", Guia.comprobante_fecha)
                                .AddWithValue("vComprobante_fecha_traslado", Guia.comprobante_fecha_traslado)
                                .AddWithValue("vAlmacen", Guia.almacen)
                                .AddWithValue("vAlmacen_destino", Guia.almacen_destino)
                                .AddWithValue("vMotivo_traslado", Guia.motivo_traslado)
                                .AddWithValue("vComentario", Guia.comentario)
                                .AddWithValue("vUsuario_registro", Guia.usuario_registro)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySqlString = "INSERT INTO COM.GUIAS_DET " & _
                                          "(empresa,guia,linea,producto,cantidad_por_atender,cantidad_atendida,indica_serie,usuario_registro) " & _
                                          "VALUES (@vEmpresa,@vGuia,@vLinea,@vProducto,@vCantidad_por_atender,@vCantidad_atendida,@vIndica_serie,@vUsuario_registro) "
                            For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.CommandText = MySqlString
                                MySQLCommand.Parameters.Clear()

                                Linea = Linea + 1
                                LineaOperacion = Strings.Right("000" & Linea.ToString, 3)

                                With MySQLCommand.Parameters
                                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                                    .AddWithValue("vGuia", Guia.guia)
                                    .AddWithValue("vLinea", LineaOperacion)
                                    .AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                                    .AddWithValue("vCantidad_por_atender", OperacionDetalles(NEle).CANTIDAD)
                                    .AddWithValue("vCantidad_atendida", OperacionDetalles(NEle).CANTIDAD)
                                    .AddWithValue("vIndica_serie", OperacionDetalles(NEle).INDICA_SERIE)
                                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                                End With
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return Operacion
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function AnularTransferencia(ByVal Operacion As entOperacionAlmacen, OperacionDetalles As dsOperacionesAlmacen.DETALLE_OPERACIONDataTable, OperacionDetalleSeries As dsOperacionesAlmacen.OPERACIONES_ALMACEN_DET_SERIESDataTable, Guia As entGuia) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN SET " & _
                        "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                        "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vAlmacen", Operacion.almacen)
                            .AddWithValue("vOperacion", Operacion.operacion)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_TRA SET " & _
                                      "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                       "WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion"

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "UPDATE ALM.OPERACIONES_ALMACEN_DET SET " & _
                                      "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE EMPRESA=@vEmpresa AND ALMACEN=@vAlmacen AND OPERACION=@vOperacion"

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To OperacionDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_2
                            MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_3 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Ingresos=Ingresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()


                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                            MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Ingresos=Ingresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vCantidad", OperacionDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vEjercicio", Operacion.ejercicio)
                            MySQLCommand.Parameters.AddWithValue("vMes", Operacion.mes)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", Operacion.almacen_destino)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()

                        Next

                        If OperacionDetalleSeries.Rows.Count <> 0 Then
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySql_3 = "UPDATE ALM.OPERACIONES_ALMACEN_DET_SERIES SET " & _
                                      "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE EMPRESA=@vEmpresa AND OPERACION=@vOperacion "

                            MySQLCommand.CommandText = MySql_3
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", Operacion.empresa)
                            MySQLCommand.Parameters.AddWithValue("vOperacion", Operacion.operacion)
                            MySQLCommand.ExecuteNonQuery()

                            For NEle As Byte = 0 To OperacionDetalleSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()
                                MySql_4 = "UPDATE COM.CONTROL_SERIES SET Referencia_operacion=@vReferencia_operacion,Fecha_operacion=@vFecha_operacion," & _
                                          "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                MySQLCommand.CommandText = MySql_4
                                MySQLCommand.Parameters.AddWithValue("vReferencia_operacion", Operacion.operacion)
                                MySQLCommand.Parameters.AddWithValue("vFecha_operacion", Operacion.fecha_operacion)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vProducto", OperacionDetalleSeries(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie", OperacionDetalleSeries(NEle).NUMERO_SERIE)
                                MySQLCommand.ExecuteNonQuery()
                            Next
                        End If

                        If Operacion.exige_guia = "SI" Then
                            MySqlString = "UPDATE COM.GUIAS SET " & _
                                          "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                          "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                .AddWithValue("vEmpresa", Guia.empresa)
                                .AddWithValue("vGuia", Guia.guia)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySqlString = "UPDATE COM.GUIAS_DET SET " & _
                                          "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                           "WHERE EMPRESA=@vEmpresa AND GUIA=@vGuia "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.ExecuteNonQuery()
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function ObtenerTransferencia() As dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

        MySqlString = "SELECT * FROM ALM.OPERACIONES_ALMACEN_TRA WHERE EMPRESA='" & MyUsuario.empresa & "' "

        Dim MyDT As New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

#End Region

End Class
