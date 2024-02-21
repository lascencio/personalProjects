Imports System.Data.SqlClient

Public Class dalProducto
    Private Shared MyProducto As entProducto

    Private Shared MySqlString As String
    Private Shared MyStoreProcedure As String
    Private Shared MyCount As Integer

    Private Shared MySQLCommand As SqlCommand
    Private Shared MyParameter_1 As SqlParameter
    Private Shared MyParameter_2 As SqlParameter
    Private Shared MyParameter_3 As SqlParameter
    Private Shared MyParameter_4 As SqlParameter
    Private Shared MyParameter_5 As SqlParameter

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pProducto As String) As entProducto
        If Existe(pEmpresa, pProducto) Then
            MySqlString = "SELECT * FROM COM.PRODUCTOS " & _
                          "WHERE EMPRESA='" & MyUsuario.empresa & "' AND PRODUCTO='" & pProducto & "'"
            Return Obtener(New entProducto)
        Else
            Return New entProducto
        End If
    End Function

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pProducto As String) As Boolean
        If Not String.IsNullOrEmpty(pProducto) Then
            pEmpresa = MyUsuario.empresa
            MySqlString = "SELECT COUNT(*) FROM COM.PRODUCTOS WHERE Empresa=@vEmpresa AND Producto=@vProducto"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Obtener(ByVal cProducto As entProducto) As entProducto
        Dim MyDT As New dsProductos.PRODUCTOSDataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)

        If MyDT.Count > 0 Then
            With cProducto
                .empresa = MyDT(0).EMPRESA
                .producto = MyDT(0).PRODUCTO
                .tipo_existencia = MyDT(0).TIPO_EXISTENCIA
                .descripcion = MyDT(0).DESCRIPCION
                .descripcion_ampliada = MyDT(0).DESCRIPCION_AMPLIADA
                .codigo_compra = MyDT(0).CODIGO_COMPRA
                .codigo_equivalente = MyDT(0).CODIGO_EQUIVALENTE
                .principio_activo = MyDT(0).PRINCIPIO_ACTIVO
                .descripcion_compra = MyDT(0).DESCRIPCION_COMPRA
                .producto_familia = MyDT(0).PRODUCTO_FAMILIA
                .producto_sub_familia = MyDT(0).PRODUCTO_SUB_FAMILIA
                .producto_tipo = MyDT(0).PRODUCTO_TIPO
                .producto_sub_tipo = MyDT(0).PRODUCTO_SUB_TIPO
                .unidad_medida = MyDT(0).UNIDAD_MEDIDA
                .unidad_compra = MyDT(0).UNIDAD_COMPRA
                .unidad_venta = MyDT(0).UNIDAD_VENTA
                .decimales = MyDT(0).DECIMALES
                .factor_compra = MyDT(0).FACTOR_COMPRA
                .factor_venta = MyDT(0).FACTOR_VENTA
                .volumen_compra = MyDT(0).VOLUMEN_COMPRA
                .volumen_venta = MyDT(0).VOLUMEN_VENTA
                .peso_compra = MyDT(0).PESO_COMPRA
                .peso_venta = MyDT(0).PESO_VENTA
                .stock_actual = MyDT(0).STOCK_ACTUAL
                .stock_comprometido = MyDT(0).STOCK_COMPROMETIDO
                .stock_transito = MyDT(0).STOCK_TRANSITO
                .almacen = MyDT(0).ALMACEN
                .ubicacion = MyDT(0).UBICACION
                .precio_compra_mn = MyDT(0).PRECIO_COMPRA_MN
                .precio_venta_mn = MyDT(0).PRECIO_VENTA_MN
                .precio_compra_me = MyDT(0).PRECIO_COMPRA_ME
                .precio_venta_me = MyDT(0).PRECIO_VENTA_ME
                .porcentaje_ganancia_costo = MyDT(0).PORCENTAJE_GANANCIA_COSTO
                .porcentaje_ganancia_precio = MyDT(0).PORCENTAJE_GANANCIA_PRECIO
                .cuenta_compra_cargo_mn = MyDT(0).CUENTA_COMPRA_CARGO_MN
                .cuenta_compra_abono_mn = MyDT(0).CUENTA_COMPRA_ABONO_MN
                .cuenta_compra_destino_cargo_mn = MyDT(0).CUENTA_COMPRA_DESTINO_CARGO_MN
                .cuenta_compra_destino_abono_mn = MyDT(0).CUENTA_COMPRA_DESTINO_ABONO_MN
                .cuenta_compra_cargo_me = MyDT(0).CUENTA_COMPRA_CARGO_ME
                .cuenta_compra_abono_me = MyDT(0).CUENTA_COMPRA_ABONO_ME
                .cuenta_compra_destino_cargo_me = MyDT(0).CUENTA_COMPRA_DESTINO_CARGO_ME
                .cuenta_compra_destino_abono_me = MyDT(0).CUENTA_COMPRA_DESTINO_ABONO_ME
                .cuenta_venta_cargo_mn = MyDT(0).CUENTA_VENTA_CARGO_MN
                .cuenta_venta_abono_mn = MyDT(0).CUENTA_VENTA_ABONO_MN
                .cuenta_venta_cargo_me = MyDT(0).CUENTA_VENTA_CARGO_ME
                .cuenta_venta_abono_me = MyDT(0).CUENTA_VENTA_ABONO_ME
                .cuenta_costo_cargo_mn = MyDT(0).CUENTA_COSTO_CARGO_MN
                .cuenta_costo_abono_mn = MyDT(0).CUENTA_COSTO_ABONO_MN
                .cuenta_costo_destino_cargo_mn = MyDT(0).CUENTA_COSTO_DESTINO_CARGO_MN
                .cuenta_costo_destino_abono_mn = MyDT(0).CUENTA_COSTO_DESTINO_ABONO_MN
                .cuenta_costo_cargo_me = MyDT(0).CUENTA_COSTO_CARGO_ME
                .cuenta_costo_abono_me = MyDT(0).CUENTA_COSTO_ABONO_ME
                .cuenta_costo_destino_cargo_me = MyDT(0).CUENTA_COSTO_DESTINO_CARGO_ME
                .cuenta_costo_destino_abono_me = MyDT(0).CUENTA_COSTO_DESTINO_ABONO_ME
                .cuenta_IGV_mn = MyDT(0).CUENTA_IGV_MN
                .cuenta_IGV_me = MyDT(0).CUENTA_IGV_ME
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .prioridad = MyDT(0).PRIORIDAD
                .tiempo_entrega = MyDT(0).TIEMPO_ENTREGA
                .tiempo_proceso = MyDT(0).TIEMPO_PROCESO
                .stock_seguridad = MyDT(0).STOCK_SEGURIDAD
                .caducidad = MyDT(0).CADUCIDAD
                .indica_serie = MyDT(0).INDICA_SERIE
                .indica_lote = MyDT(0).INDICA_LOTE
                .indica_vencimiento = MyDT(0).INDICA_VENCIMIENTO
                .indica_valida_stock = MyDT(0).INDICA_VALIDA_STOCK
                .indica_afecto = MyDT(0).INDICA_AFECTO
                .indica_compuesto = MyDT(0).INDICA_COMPUESTO
                .indica_promocional = MyDT(0).INDICA_PROMOCIONAL
                .indica_sin_planificacion = MyDT(0).INDICA_SIN_PLANIFICACION
                .indica_producto_controlado = MyDT(0).INDICA_PRODUCTO_CONTROLADO
                .indica_usado = MyDT(0).INDICA_USADO
                .procedencia = MyDT(0).PROCEDENCIA
                .puntos_bonificacion = MyDT(0).PUNTOS_BONIFICACION
                .largo_cms = MyDT(0).LARGO_CMS
                .ancho_cms = MyDT(0).ANCHO_CMS
                .profundidad_cms = MyDT(0).PROFUNDIDAD_CMS
                .stock_minimo = MyDT(0).STOCK_MINIMO
                .stock_maximo = MyDT(0).STOCK_MAXIMO
                .partida_arancelaria = MyDT(0).PARTIDA_ARANCELARIA
                .costo_fob = MyDT(0).COSTO_FOB
                .flete = MyDT(0).FLETE
                .seguros = MyDT(0).SEGUROS
                .agente_aduanas = MyDT(0).AGENTE_ADUANAS
                .derecho_advalorem = MyDT(0).DERECHO_ADVALOREM
                .gastos_despacho = MyDT(0).GASTOS_DESPACHO
                .costo_estandar = MyDT(0).COSTO_ESTANDAR
                If Not String.IsNullOrEmpty(MyDT(0).CODIGO_ANTIGUO.Trim) Then .codigo_antiguo = MyDT(0).CODIGO_ANTIGUO
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_comprador = MyDT(0).CODIGO_COMPRADOR
                .ultima_compra = MyDT(0).ULTIMA_COMPRA
                .ultima_venta = MyDT(0).ULTIMA_VENTA
                If Not String.IsNullOrEmpty(MyDT(0).COMENTARIO.Trim) Then .comentario = MyDT(0).COMENTARIO
                If Not String.IsNullOrEmpty(MyDT(0).IMAGEN.Trim) Then .imagen = MyDT(0).IMAGEN
                .marca = MyDT(0).MARCA
                .modelo = MyDT(0).MODELO
                .codigo_ean = MyDT(0).CODIGO_EAN
                .codigo_osce = MyDT(0).CODIGO_OSCE
                .codigo_cubso = MyDT(0).CODIGO_CUBSO
                .codigo_unspsc = MyDT(0).CODIGO_UNSPSC
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA

                If ObtenerEsVehicular("PRODUCTO_TIPO", .producto_tipo) = True Then .indica_vehicular = "SI"
            End With
        End If
        Return cProducto
    End Function

    Public Shared Function BuscarCompuestoCodigo(ByVal pEmpresa As String, ByVal pCodigo As String, ByVal pEstado As String) As dsProductos.MyDTProductosDataTable
        MyStoreProcedure = "COM.COMPUESTO_X_CODIGO"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@PRODUCTO", SqlDbType.VarChar, 8) : MyParameter_2.Value = RTrim(pCodigo)
        MyParameter_3 = New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_3.Value = pEstado

        Dim MyDT As New dsProductos.MyDTProductosDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
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

    Public Shared Function BuscarCompuestoDescripcion(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pEstado As String) As dsProductos.MyDTProductosDataTable
        MyStoreProcedure = "COM.COMPUESTO_X_NOMBRE"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 200) : MyParameter_2.Value = pDescripcion
        MyParameter_3 = New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_3.Value = pEstado

        Dim MyDT As New dsProductos.MyDTProductosDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
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

    Public Shared Function Grabar(ByVal cProducto As entProducto) As entProducto
        If Not Existe(cProducto) Then
            Return Insertar(cProducto)
        Else
            Return Actualizar(cProducto)
        End If
    End Function

    Private Shared Function Existe(ByVal cProducto As entProducto) As Boolean
        If Not String.IsNullOrEmpty(cProducto.producto) Then
            MySqlString = "SELECT COUNT(*) FROM COM.PRODUCTOS WHERE Empresa=@vEmpresa AND Producto=@vProducto"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cProducto.empresa)
                MySQLCommand.Parameters.AddWithValue("vProducto", cProducto.producto)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
            End Using
            Return IIf(MyCount = 0, False, True)
        End If
    End Function

    Private Shared Function Insertar(ByVal cProducto As entProducto) As entProducto
        cProducto.producto = AsignarCodigo()
        MySqlString = "INSERT INTO COM.PRODUCTOS " & _
                      "(empresa,producto,tipo_existencia,descripcion,descripcion_ampliada,codigo_compra,descripcion_compra," & _
                      "producto_familia,producto_sub_familia,producto_tipo,producto_sub_tipo,unidad_medida,unidad_compra,unidad_venta," & _
                      "decimales,factor_compra,factor_venta,volumen_compra,volumen_venta,peso_compra,peso_venta,almacen,ubicacion," & _
                      "procedencia,tipo_moneda,prioridad,tiempo_entrega,tiempo_proceso,stock_seguridad,caducidad,estado," & _
                      "indica_serie,indica_lote,indica_vencimiento,indica_valida_stock,indica_afecto,indica_compuesto,indica_promocional," & _
                      "indica_sin_planificacion,porcentaje_ganancia_costo,porcentaje_ganancia_precio,puntos_bonificacion," & _
                      "largo_cms,ancho_cms,profundidad_cms,partida_arancelaria,codigo_antiguo,comentario,imagen,usuario_registro) " & _
                      "VALUES (@vEmpresa,@vProducto,@vTipo_existencia,@vDescripcion,@vDescripcion_ampliada,@vCodigo_compra,@vDescripcion_compra," & _
                      "@vProducto_familia,@vProducto_sub_familia,@vProducto_tipo,@vProducto_sub_tipo,@vUnidad_medida,@vUnidad_compra,@vUnidad_venta," & _
                      "@vDecimales,@vFactor_compra,@vFactor_venta,@vVolumen_compra,@vVolumen_venta,@vPeso_compra,@vPeso_venta,@vAlmacen,@vUbicacion," & _
                      "@vProcedencia,@vTipo_moneda,@vPrioridad,@vTiempo_entrega,@vTiempo_proceso,@vStock_seguridad,@vCaducidad,@vEstado," & _
                      "@vIndica_serie,@vIndica_lote,@vIndica_vencimiento,@vIndica_valida_stock,@vIndica_afecto,@vIndica_compuesto,@vIndica_promocional," & _
                      "@vIndica_sin_planificacion,@vPorcentaje_ganancia_costo,@vPorcentaje_ganancia_precio,@vPuntos_bonificacion," & _
                      "@vLargo_cms,@vAncho_cms,@vProfundidad_cms,@vPartida_arancelaria,@vCodigo_antiguo,@vComentario,@vImagen,@vUsuario_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cProducto.empresa)
                .AddWithValue("vProducto", cProducto.producto)
                .AddWithValue("vTipo_existencia", cProducto.tipo_existencia)
                .AddWithValue("vDescripcion", cProducto.descripcion)
                .AddWithValue("vDescripcion_ampliada", cProducto.descripcion_ampliada)
                .AddWithValue("vCodigo_compra", cProducto.codigo_compra)
                .AddWithValue("vDescripcion_compra", cProducto.descripcion_compra)
                .AddWithValue("vProducto_familia", cProducto.producto_familia)
                .AddWithValue("vProducto_sub_familia", cProducto.producto_sub_familia)
                .AddWithValue("vProducto_tipo", cProducto.producto_tipo)
                .AddWithValue("vProducto_sub_tipo", cProducto.producto_sub_tipo)
                .AddWithValue("vUnidad_medida", cProducto.unidad_medida)
                .AddWithValue("vUnidad_compra", cProducto.unidad_compra)
                .AddWithValue("vUnidad_venta", cProducto.unidad_venta)
                .AddWithValue("vDecimales", cProducto.decimales)
                .AddWithValue("vFactor_compra", cProducto.factor_compra)
                .AddWithValue("vFactor_venta", cProducto.factor_venta)
                .AddWithValue("vVolumen_compra", cProducto.volumen_compra)
                .AddWithValue("vVolumen_venta", cProducto.volumen_venta)
                .AddWithValue("vPeso_compra", cProducto.peso_compra)
                .AddWithValue("vPeso_venta", cProducto.peso_venta)
                .AddWithValue("vAlmacen", cProducto.almacen)
                .AddWithValue("vUbicacion", cProducto.ubicacion)
                .AddWithValue("vProcedencia", cProducto.procedencia)
                .AddWithValue("vTipo_moneda", cProducto.tipo_moneda)
                .AddWithValue("vPrioridad", cProducto.prioridad)
                .AddWithValue("vTiempo_entrega", cProducto.tiempo_entrega)
                .AddWithValue("vTiempo_proceso", cProducto.tiempo_proceso)
                .AddWithValue("vStock_seguridad", cProducto.stock_seguridad)
                .AddWithValue("vCaducidad", cProducto.caducidad)
                .AddWithValue("vEstado", cProducto.estado)
                .AddWithValue("vIndica_serie", cProducto.indica_serie)
                .AddWithValue("vIndica_lote", cProducto.indica_lote)
                .AddWithValue("vIndica_vencimiento", cProducto.indica_vencimiento)
                .AddWithValue("vIndica_valida_stock", cProducto.indica_valida_stock)
                .AddWithValue("vIndica_afecto", cProducto.indica_afecto)
                .AddWithValue("vIndica_compuesto", cProducto.indica_compuesto)
                .AddWithValue("vIndica_promocional", cProducto.indica_promocional)
                .AddWithValue("vIndica_sin_planificacion", cProducto.indica_sin_planificacion)
                .AddWithValue("vPorcentaje_ganancia_costo", cProducto.porcentaje_ganancia_costo)
                .AddWithValue("vPorcentaje_ganancia_precio", cProducto.porcentaje_ganancia_precio)
                .AddWithValue("vPuntos_bonificacion", cProducto.puntos_bonificacion)
                .AddWithValue("vLargo_cms", cProducto.largo_cms)
                .AddWithValue("vAncho_cms", cProducto.ancho_cms)
                .AddWithValue("vProfundidad_cms", cProducto.profundidad_cms)
                .AddWithValue("vPartida_arancelaria", cProducto.partida_arancelaria)
                .AddWithValue("vCodigo_antiguo", cProducto.codigo_antiguo)
                .AddWithValue("vComentario", cProducto.comentario)
                .AddWithValue("vImagen", cProducto.imagen)
                .AddWithValue("vUsuario_registro", cProducto.usuario_registro)
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

                Return cProducto

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

    Private Shared Function AsignarCodigo() As String
        MySqlString = "SELECT ISNULL(MAX(PRODUCTO),'') AS NUEVO_CODIGO FROM COM.PRODUCTOS " & _
                      "WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "P0000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 7)) + 1
                NewCode = "P" & Right("0000000" & Correlativo.ToString, 7)
            End If
            Return NewCode
        End Using
    End Function

    Private Shared Function Actualizar(ByVal cProducto As entProducto) As entProducto
        MySqlString = " UPDATE COM.PRODUCTOS SET " & _
                      "tipo_existencia=@vTipo_existencia,descripcion=@vDescripcion,descripcion_ampliada=@vDescripcion_ampliada," & _
                      "codigo_compra=@vCodigo_compra,descripcion_compra=@vDescripcion_compra,producto_familia=@vProducto_familia,producto_sub_familia=@vProducto_sub_familia," & _
                      "producto_tipo=@vProducto_tipo,producto_sub_tipo=@vProducto_sub_tipo,unidad_medida=@vUnidad_medida,unidad_compra=@vUnidad_compra,unidad_venta=@vUnidad_venta," & _
                      "decimales=@vDecimales,factor_compra=@vFactor_compra,factor_venta=@vFactor_venta,volumen_compra=@vVolumen_compra,volumen_venta=@vVolumen_venta,peso_compra=@vPeso_compra,peso_venta=@vPeso_venta," & _
                      "almacen=@vAlmacen,ubicacion=@vUbicacion,procedencia=@vProcedencia,tipo_moneda=@vTipo_moneda,prioridad=@vPrioridad," & _
                      "tiempo_entrega=@vTiempo_entrega,tiempo_proceso=@vTiempo_proceso,stock_seguridad=@vStock_seguridad,caducidad =@vCaducidad,estado=@vEstado," & _
                      "indica_serie=@vIndica_serie,indica_lote=@vIndica_lote,indica_vencimiento=@vIndica_vencimiento,indica_valida_stock=@vIndica_valida_stock,indica_afecto=@vIndica_afecto," & _
                      "indica_compuesto=@vIndica_compuesto,indica_promocional=@vIndica_promocional,indica_sin_planificacion=@vIndica_sin_planificacion,porcentaje_ganancia_costo=@vPorcentaje_ganancia_costo," & _
                      "porcentaje_ganancia_precio=@vPorcentaje_ganancia_precio,puntos_bonificacion=@vPuntos_bonificacion,largo_cms=@vLargo_cms,ancho_cms=@vAncho_cms,profundidad_cms=@vProfundidad_cms," & _
                      "partida_arancelaria=@vPartida_arancelaria,codigo_antiguo=@vCodigo_antiguo,comentario=@vcomentario,imagen=@vImagen,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " & _
                      "WHERE empresa=@vEmpresa and producto=@vProducto"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vTipo_existencia", cProducto.tipo_existencia)
                .AddWithValue("vDescripcion", cProducto.descripcion)
                .AddWithValue("vDescripcion_ampliada", cProducto.descripcion_ampliada)
                .AddWithValue("vCodigo_compra", cProducto.codigo_compra)
                .AddWithValue("vDescripcion_compra", cProducto.descripcion_compra)
                .AddWithValue("vProducto_familia", cProducto.producto_familia)
                .AddWithValue("vProducto_sub_familia", cProducto.producto_sub_familia)
                .AddWithValue("vProducto_tipo", cProducto.producto_tipo)
                .AddWithValue("vProducto_sub_tipo", cProducto.producto_sub_tipo)
                .AddWithValue("vUnidad_medida", cProducto.unidad_medida)
                .AddWithValue("vUnidad_compra", cProducto.unidad_compra)
                .AddWithValue("vUnidad_venta", cProducto.unidad_venta)
                .AddWithValue("vDecimales", cProducto.decimales)
                .AddWithValue("vFactor_compra", cProducto.factor_compra)
                .AddWithValue("vFactor_venta", cProducto.factor_venta)
                .AddWithValue("vVolumen_compra", cProducto.volumen_compra)
                .AddWithValue("vVolumen_venta", cProducto.volumen_venta)
                .AddWithValue("vPeso_compra", cProducto.peso_compra)
                .AddWithValue("vPeso_venta", cProducto.peso_venta)
                .AddWithValue("vAlmacen", cProducto.almacen)
                .AddWithValue("vUbicacion", cProducto.ubicacion)
                .AddWithValue("vProcedencia", cProducto.procedencia)
                .AddWithValue("vTipo_moneda", cProducto.tipo_moneda)
                .AddWithValue("vPrioridad", cProducto.prioridad)
                .AddWithValue("vTiempo_entrega", cProducto.tiempo_entrega)
                .AddWithValue("vTiempo_proceso", cProducto.tiempo_proceso)
                .AddWithValue("vStock_seguridad", cProducto.stock_seguridad)
                .AddWithValue("vCaducidad", cProducto.caducidad)
                .AddWithValue("vEstado", cProducto.estado)
                .AddWithValue("vIndica_serie", cProducto.indica_serie)
                .AddWithValue("vIndica_lote", cProducto.indica_lote)
                .AddWithValue("vIndica_vencimiento", cProducto.indica_vencimiento)
                .AddWithValue("vIndica_valida_stock", cProducto.indica_valida_stock)
                .AddWithValue("vIndica_afecto", cProducto.indica_afecto)
                .AddWithValue("vIndica_compuesto", cProducto.indica_compuesto)
                .AddWithValue("vIndica_promocional", cProducto.indica_promocional)
                .AddWithValue("vIndica_sin_planificacion", cProducto.indica_sin_planificacion)
                .AddWithValue("vPorcentaje_ganancia_costo", cProducto.porcentaje_ganancia_costo)
                .AddWithValue("vPorcentaje_ganancia_precio", cProducto.porcentaje_ganancia_precio)
                .AddWithValue("vPuntos_bonificacion", cProducto.puntos_bonificacion)
                .AddWithValue("vLargo_cms", cProducto.largo_cms)
                .AddWithValue("vAncho_cms", cProducto.ancho_cms)
                .AddWithValue("vProfundidad_cms", cProducto.profundidad_cms)
                .AddWithValue("vPartida_arancelaria", cProducto.partida_arancelaria)
                .AddWithValue("vCodigo_antiguo", cProducto.codigo_antiguo)
                .AddWithValue("vComentario", cProducto.comentario)
                .AddWithValue("vImagen", cProducto.imagen)
                .AddWithValue("vUsuario_modifica", cProducto.usuario_registro)
                .AddWithValue("vEmpresa", cProducto.empresa)
                .AddWithValue("vProducto", cProducto.producto)
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
                Return cProducto

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

    Public Shared Function BuscarStocksAlmacen(ByVal pAlmacen As String, ByVal pProducto As String) As dsStockAlmacen.STOCK_X_ALMACENDataTable
        MySqlString = "SELECT EMPRESA, ALMACEN, NUMERO_LOTE, PRODUCTO, DESCRIPCION, INGRESOS, EGRESOS, STOCK, FECHA_VENCIMIENTO " & _
                      "FROM ALM.STOCK_X_ALMACEN " & _
                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND producto=@vProducto AND STOCK<>0 "

        Dim MyDT As New dsStockAlmacen.STOCK_X_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function EvaluarSiExisteResumenAlmacen(pAlmacen As String, pNumeroLote As String, pProducto As String) As Boolean
        Dim MyDT As New dsStockAlmacen.EXISTE_STOCKDataTable
        MySqlString = "SELECT COUNT(*) AS CANTIDAD FROM ALM.RESUMEN_X_ALMACEN " & _
                      "WHERE Empresa='" & MyUsuario.empresa & "' AND Almacen='" & pAlmacen & "' AND Numero_lote='" & pNumeroLote & "' AND Producto='" & pProducto & "' "

        Call ObtenerExisteStock(MySqlString, MyDT)

        If MyDT(0).CANTIDAD = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function EvaluarSiExisteResumenPeriodo(pEjercicio As String, pMes As String, pAlmacen As String, pNumeroLote As String, pProducto As String) As Boolean
        Dim MyDT As New dsStockAlmacen.EXISTE_STOCKDataTable
        MySqlString = "SELECT COUNT(*) AS CANTIDAD FROM ALM.RESUMEN_X_PERIODO " & _
                      "WHERE Empresa='" & MyUsuario.empresa & "' AND Ejercicio='" & pEjercicio & "' AND Mes='" & pMes & "' AND Almacen='" & pAlmacen & "' AND Numero_lote='" & pNumeroLote & "' AND Producto='" & pProducto & "' "

        Call ObtenerExisteStock(MySqlString, MyDT)

        If MyDT(0).CANTIDAD = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function ProductosTopBottom(ByVal pAlmacen As String, ByVal pEsPrimero As Boolean) As dsProductos.PRODUCTOS_LISTADataTable
        MySqlString = "SELECT TOP (1) PRODUCTO, DESCRIPCION, DESCRIPCION_AMPLIADA, TIPO_EXISTENCIA, PRODUCTO_FAMILIA, PRODUCTO_SUB_FAMILIA, PRODUCTO_TIPO, PRODUCTO_SUB_TIPO " & _
                      "FROM COM.PRODUCTOS " & _
                      "WHERE Empresa=@vEmpresa " & _
                      "ORDER BY PRODUCTO " & IIf(pEsPrimero = True, "ASC", "DESC")

        Dim MyDT As New dsProductos.PRODUCTOS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerStockComponentes(ByVal pEmpresa As String, ByVal pAlmacen As String, ByVal pProductoCompuesto As String) As dsProductos.COMPONENTESDataTable
        Dim MyStockActual As New dsStockAlmacen.RESUMEN_X_ALMACENDataTable

        MySqlString = "SELECT PC.PRODUCTO, P.DESCRIPCION_AMPLIADA, P.CODIGO_COMPRA, PC.CANTIDAD, 0 AS STOCK_ACTUAL, P.INDICA_SERIE, P.INDICA_LOTE " & _
                      "FROM COM.PRODUCTOS_COMPUESTOS AS PC INNER JOIN COM.PRODUCTOS AS P ON PC.EMPRESA=P.EMPRESA AND PC.PRODUCTO=P.PRODUCTO " & _
                      "WHERE PC.Empresa=@vEmpresa AND PC.Producto_compuesto=@vProducto_compuesto "

        Dim MyDT As New dsProductos.COMPONENTESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto_compuesto", pProductoCompuesto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using

        If MyDT.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyDT.Rows.Count - 1
                MyStockActual = dalOperacionAlmacen.StockProducto(MyDT(NEle).PRODUCTO, pAlmacen)
                If MyStockActual.Rows.Count <> 0 Then
                    MyDT(NEle).STOCK_ACTUAL = Math.Truncate(MyStockActual(0).STOCK / MyDT(NEle).CANTIDAD)
                End If
            Next
        End If
        Return MyDT
    End Function

    Public Shared Function BuscarProductosSerie(ByVal pNumeroSerie As String) As dsControlSeries.PRODUCTOS_SERIEDataTable
        pNumeroSerie = "%" & pNumeroSerie & "%"

        MySqlString = "SELECT DISTINCT EMPRESA, PRODUCTO, CODIGO_COMPRA, DESCRIPCION_AMPLIADA, NUMERO_SERIE " & _
                      "FROM COM.SERIES_HISTORICO " & _
                      "WHERE EMPRESA=@vEmpresa AND NUMERO_SERIE LIKE @vNumero_serie "

        Dim MyDT As New dsControlSeries.PRODUCTOS_SERIEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", pNumeroSerie)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarNumeroSerie(ByVal pNumeroSerie As String) As dsControlSeries.SERIES_HISTORICODataTable
        MySqlString = "SELECT EMPRESA, PRODUCTO, CODIGO_COMPRA, DESCRIPCION_AMPLIADA, NUMERO_SERIE, REFERENCIA, REFERENCIA_ALMACEN, REFERENCIA_FECHA, " & _
                      "REFERENCIA_ESTADO, TIPO_OPERACION, DESCRIPCION, COMENTARIO, ALMACEN, ESTADO, ORDEN " & _
                      "FROM COM.SERIES_HISTORICO " & _
                      "WHERE EMPRESA=@vEmpresa AND NUMERO_SERIE=@vNumero_serie " & _
                      "ORDER BY ORDEN "

        Dim MyDT As New dsControlSeries.SERIES_HISTORICODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", pNumeroSerie)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerProductoComponentes(ByVal pEmpresa As String, pProductoCompuesto As String) As dsProductos.PRODUCTO_COMPONENTESDataTable
        MySqlString = "SELECT PRODUCTO_COMPUESTO, PRODUCTO, CANTIDAD, 'NO' AS EXISTE_RESUMEN_ALMACEN, 'NO' AS EXISTE_RESUMEN_PERIODO " & _
                      "FROM COM.PRODUCTOS_COMPUESTOS " & _
                      "WHERE Empresa=@vEmpresa AND Producto_compuesto=@vProducto_compuesto "

        Dim MyDT As New dsProductos.PRODUCTO_COMPONENTESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto_compuesto", pProductoCompuesto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using

        Return MyDT
    End Function

End Class
