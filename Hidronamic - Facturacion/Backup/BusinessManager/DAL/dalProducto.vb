Imports System.Data.SqlClient

Public Class dalProducto
    Private Shared MySqlString As String
    Private Shared MySql As String
    Private Shared MyCount As Integer
    Private Shared MyStoreProcedure As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyParameter_1 As SqlParameter
    Private Shared MyParameter_2 As SqlParameter
    Private Shared MyParameter_3 As SqlParameter
    Private Shared MyParameter_4 As SqlParameter

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pProducto As String) As Boolean
        If Not String.IsNullOrEmpty(pProducto) Then
            MySqlString = "SELECT COUNT(*) FROM COM.PRODUCTOS WHERE Empresa=@vEmpresa AND Producto=@vProducto"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
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
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pProducto As String) As entProducto
        If Existe(pProducto) Then
            MySqlString = "SELECT * FROM COM.PRODUCTOS " & _
                          "WHERE EMPRESA='" & MyUsuario.empresa & "' AND PRODUCTO='" & pProducto & "'"
            Return Obtener(New entProducto)
        Else
            Return New entProducto
        End If
    End Function

    Public Shared Function ObtenerDescripcion(ByVal cProducto As String) As String
        MySql = "SELECT ISNULL(DESCRIPCION_AMPLIADA,DESCRIPCION) AS DESCRIPCION FROM COM.PRODUCTOS " & _
                "WHERE EMPRESA='" & MyUsuario.empresa & "' AND PRODUCTO='" & cProducto & "' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim MyDescripcion As String = MySQLCommand.ExecuteScalar
            Return MyDescripcion
        End Using
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

                .procedencia = MyDT(0).PROCEDENCIA
                .cuenta_compra_mn = MyDT(0).CUENTA_COMPRA_MN
                .cuenta_venta_mn = MyDT(0).CUENTA_VENTA_MN
                .cuenta_compra_me = MyDT(0).CUENTA_COMPRA_ME
                .cuenta_venta_me = MyDT(0).CUENTA_VENTA_ME
                .cuenta_costo_mn = MyDT(0).CUENTA_COSTO_MN
                .cuenta_costo_me = MyDT(0).CUENTA_COSTO_ME
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .prioridad = MyDT(0).PRIORIDAD
                .codigo_compra = MyDT(0).CODIGO_COMPRA
                .descripcion_compra = MyDT(0).DESCRIPCION_COMPRA
                .tiempo_entrega = MyDT(0).TIEMPO_ENTREGA
                .tiempo_proceso = MyDT(0).TIEMPO_PROCESO
                .stock_seguridad = MyDT(0).STOCK_SEGURIDAD
                .caducidad = MyDT(0).CADUCIDAD
                .estado = MyDT(0).ESTADO
                .indica_serie = MyDT(0).INDICA_SERIE
                .indica_lote = MyDT(0).INDICA_LOTE
                .indica_vencimiento = MyDT(0).INDICA_VENCIMIENTO
                .indica_valida_stock = MyDT(0).INDICA_VALIDA_STOCK
                .indica_afecto = MyDT(0).INDICA_AFECTO

                .indica_compuesto = MyDT(0).INDICA_COMPUESTO
                .indica_promocional = MyDT(0).INDICA_PROMOCIONAL
                .indica_sin_planificacion = MyDT(0).INDICA_SIN_PLANIFICACION
                .porcentaje_ganancia_costo = MyDT(0).PORCENTAJE_GANANCIA_COSTO
                .porcentaje_ganancia_precio = MyDT(0).PORCENTAJE_GANANCIA_PRECIO
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
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cProducto
    End Function

    Public Shared Function Grabar(ByVal cProducto As entProducto) As entProducto
        If String.IsNullOrEmpty(cProducto.descripcion.Trim) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
        If String.IsNullOrEmpty(cProducto.descripcion_ampliada.Trim) Then Throw New BusinessException(MSG000 & " DESCRIPCION AMPLIADA")
        If Not Existe(cProducto) Then
            Return Insertar(cProducto)
        Else
            Return Actualizar(cProducto)
        End If
    End Function

    Private Shared Function Insertar(ByVal cProducto As entProducto) As entProducto
        'cProducto.producto = AsignarCodigo()
        MySql = "INSERT INTO COM.PRODUCTOS " & _
                "(empresa,producto,tipo_existencia,descripcion,descripcion_ampliada," & _
                "producto_familia,producto_sub_familia,producto_tipo,producto_sub_tipo,unidad_medida,unidad_compra,unidad_venta," & _
                "decimales,factor_compra,factor_venta,volumen_compra,volumen_venta,peso_compra,peso_venta,almacen,ubicacion," & _
                "procedencia,cuenta_compra_mn,cuenta_compra_me,cuenta_venta_mn,cuenta_venta_me,cuenta_costo_mn,cuenta_costo_me,tipo_moneda," & _
                "prioridad,codigo_compra,descripcion_compra,tiempo_entrega,tiempo_proceso,stock_seguridad,caducidad,estado," & _
                "indica_serie,indica_lote,indica_vencimiento,indica_valida_stock,indica_afecto,partida_arancelaria," & _
                "codigo_antiguo,comentario,imagen,usuario_registro,indica_compuesto,indica_promocional) " & _
                "VALUES (@vEmpresa,@vProducto,@vTipo_existencia,@vDescripcion,@vDescripcion_ampliada," & _
                "@vProducto_familia,@vProducto_sub_familia,@vProducto_tipo,@vProducto_sub_tipo,@vUnidad_medida,@vUnidad_compra,@vUnidad_venta," & _
                "@vDecimales,@vFactor_compra,@vFactor_venta,@vVolumen_compra,@vVolumen_venta,@vPeso_compra,@vPeso_venta,@vAlmacen,@vUbicacion," & _
                "@vProcedencia,@vCuenta_compra_mn,@vCuenta_compra_me,@vCuenta_venta_mn,@vCuenta_venta_me,@vCuenta_costo_mn,@vCuenta_costo_me,@vTipo_moneda," & _
                "@vPrioridad,@vCodigo_compra,@vDescripcion_compra,@vTiempo_entrega,@vTiempo_proceso,@vStock_seguridad,@vCaducidad,@vEstado," & _
                "@vIndica_serie,@vIndica_lote,@vIndica_vencimiento,@vIndica_valida_stock,@vIndica_afecto,@vPartida_arancelaria," & _
                "@vCodigo_antiguo,@vComentario,@vImagen,@vUsuario_registro,@vIndica_compuesto,@vIndica_promocional)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cProducto.empresa)
                .AddWithValue("vProducto", cProducto.producto)
                .AddWithValue("vTipo_existencia", cProducto.tipo_existencia)
                .AddWithValue("vDescripcion", cProducto.descripcion)
                .AddWithValue("vDescripcion_ampliada", cProducto.descripcion_ampliada)
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
                .AddWithValue("vCuenta_compra_mn", cProducto.cuenta_compra_mn)
                .AddWithValue("vCuenta_compra_me", cProducto.cuenta_compra_me)
                .AddWithValue("vCuenta_venta_mn", cProducto.cuenta_venta_mn)
                .AddWithValue("vCuenta_venta_me", cProducto.cuenta_venta_me)
                .AddWithValue("vCuenta_costo_mn", cProducto.cuenta_costo_mn)
                .AddWithValue("vCuenta_costo_me", cProducto.cuenta_costo_me)
                .AddWithValue("vTipo_moneda", cProducto.tipo_moneda)
                .AddWithValue("vPrioridad", cProducto.prioridad)
                .AddWithValue("vCodigo_compra", cProducto.codigo_compra)
                .AddWithValue("vDescripcion_compra", cProducto.descripcion_compra)
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
                .AddWithValue("vPartida_arancelaria", cProducto.partida_arancelaria)
                .AddWithValue("vCodigo_antiguo", cProducto.codigo_antiguo)
                .AddWithValue("vComentario", cProducto.comentario)
                .AddWithValue("vImagen", cProducto.imagen)
                .AddWithValue("vUsuario_registro", cProducto.usuario_registro)
                .AddWithValue("vIndica_compuesto", cProducto.indica_compuesto)
                .AddWithValue("vIndica_promocional", cProducto.indica_promocional)
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

        MySql = "SELECT ISNULL(MAX(PRODUCTO),'') AS NUEVO_CODIGO FROM COM.PRODUCTOS "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            MySQLCommand = New SqlCommand(MySql, MySQLDbconnection)
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

        MySql = " UPDATE COM.PRODUCTOS SET " & _
        "tipo_existencia=@vTipo_existencia,descripcion=@vDescripcion,descripcion_ampliada=@vDescripcion_ampliada," & _
        "producto_familia=@vProducto_familia,producto_sub_familia=@vProducto_sub_familia,producto_tipo=@vProducto_tipo,producto_sub_tipo=@vProducto_sub_tipo," & _
        "unidad_medida=@vUnidad_medida,unidad_compra=@vUnidad_compra,unidad_venta=@vUnidad_venta,decimales=@vDecimales,factor_compra=@vFactor_compra,factor_venta=@vFactor_venta," & _
        "volumen_compra=@vVolumen_compra,volumen_venta=@vVolumen_venta,peso_compra=@vPeso_compra,peso_venta=@vPeso_venta," & _
        "stock_actual=@vStock_actual,stock_comprometido=@vStock_comprometido,stock_transito=@vStock_transito,almacen=@vAlmacen,ubicacion=@vUbicacion," & _
        "precio_compra_mn=@vPrecio_compra_mn,precio_compra_me=@vPrecio_compra_me,precio_venta_mn=@vPrecio_venta_mn,precio_venta_me=@vPrecio_venta_me,procedencia=@vProcedencia," & _
        "cuenta_compra_mn=@vCuenta_compra_mn,cuenta_compra_me=@vCuenta_compra_me,cuenta_venta_mn=@vCuenta_venta_mn,cuenta_venta_me=@vCuenta_venta_me," & _
        "cuenta_costo_mn=@vCuenta_costo_mn,cuenta_costo_me=@vCuenta_costo_me,tipo_moneda=@vTipo_moneda,prioridad=@vPrioridad,codigo_compra=@vCodigo_compra,descripcion_compra=@vDescripcion_compra," & _
        "tiempo_entrega=@vTiempo_entrega,tiempo_proceso=@vTiempo_proceso,stock_seguridad=@vStock_seguridad,caducidad =@vCaducidad,estado=@vEstado," & _
        "indica_serie=@vIndica_serie,indica_lote=@vIndica_lote,indica_vencimiento=@vIndica_vencimiento,indica_valida_stock=@vIndica_valida_stock,indica_afecto=@vIndica_afecto," & _
        "stock_minimo=@vStock_minimo,stock_maximo=@vStock_maximo,partida_arancelaria=@vPartida_arancelaria,costo_fob=@vCosto_fob,flete=@vFlete,seguros=@vSeguros," & _
        "agente_aduanas=@vAgente_aduanas,derecho_advalorem=@vDerecho_advalorem,gastos_despacho=@vGastos_despacho,costo_estandar=@vCosto_estandar," & _
        "codigo_antiguo=@vCodigo_antiguo,codigo_vendedor=@vCodigo_vendedor,codigo_comprador=@vCodigo_comprador,ultima_compra=@vUltima_compra,ultima_venta=@vUltima_venta," & _
        "comentario=@vcomentario,imagen=@vImagen,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica,indica_compuesto=@vIndica_compuesto,indica_promocional=@vIndica_promocional " & _
        "WHERE empresa=@vEmpresa and producto=@vProducto"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vTipo_existencia", cProducto.tipo_existencia)
                .AddWithValue("vDescripcion", cProducto.descripcion)
                .AddWithValue("vDescripcion_ampliada", cProducto.descripcion_ampliada)
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
                .AddWithValue("vStock_actual", cProducto.stock_actual)
                .AddWithValue("vStock_comprometido", cProducto.stock_comprometido)
                .AddWithValue("vStock_transito", cProducto.stock_transito)
                .AddWithValue("vAlmacen", cProducto.almacen)
                .AddWithValue("vUbicacion", cProducto.ubicacion)
                .AddWithValue("vPrecio_compra_mn", cProducto.precio_compra_mn)
                .AddWithValue("vPrecio_compra_me", cProducto.precio_compra_me)
                .AddWithValue("vPrecio_venta_mn", cProducto.precio_venta_mn)
                .AddWithValue("vPrecio_venta_me", cProducto.precio_venta_me)
                .AddWithValue("vProcedencia", cProducto.procedencia)
                .AddWithValue("vCuenta_compra_mn", cProducto.cuenta_compra_mn)
                .AddWithValue("vCuenta_compra_me", cProducto.cuenta_compra_me)
                .AddWithValue("vCuenta_venta_mn", cProducto.cuenta_venta_mn)
                .AddWithValue("vCuenta_venta_me", cProducto.cuenta_venta_me)
                .AddWithValue("vCuenta_costo_mn", cProducto.cuenta_costo_mn)
                .AddWithValue("vCuenta_costo_me", cProducto.cuenta_costo_me)
                .AddWithValue("vTipo_moneda", cProducto.tipo_moneda)
                .AddWithValue("vPrioridad", cProducto.prioridad)
                .AddWithValue("vCodigo_compra", cProducto.codigo_compra)
                .AddWithValue("vDescripcion_compra", cProducto.descripcion_compra)
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
                .AddWithValue("vStock_minimo", cProducto.stock_minimo)
                .AddWithValue("vStock_maximo", cProducto.stock_maximo)
                .AddWithValue("vPartida_arancelaria", cProducto.partida_arancelaria)
                .AddWithValue("vCosto_fob", cProducto.costo_fob)
                .AddWithValue("vFlete", cProducto.flete)
                .AddWithValue("vSeguros", cProducto.seguros)
                .AddWithValue("vAgente_aduanas", cProducto.agente_aduanas)
                .AddWithValue("vDerecho_advalorem", cProducto.derecho_advalorem)
                .AddWithValue("vGastos_despacho", cProducto.gastos_despacho)
                .AddWithValue("vCosto_estandar", cProducto.costo_estandar)
                .AddWithValue("vCodigo_antiguo", cProducto.codigo_antiguo)
                .AddWithValue("vCodigo_vendedor", cProducto.codigo_vendedor)
                .AddWithValue("vCodigo_comprador", cProducto.codigo_comprador)
                .AddWithValue("vUltima_compra", cProducto.ultima_compra)
                .AddWithValue("vUltima_venta", cProducto.ultima_venta)
                .AddWithValue("vComentario", cProducto.comentario)
                .AddWithValue("vImagen", cProducto.imagen)
                .AddWithValue("vUsuario_modifica", cProducto.usuario_registro)
                .AddWithValue("@vFecha_modifica", Now)
                .AddWithValue("@vIndica_compuesto", cProducto.indica_compuesto)
                .AddWithValue("@vIndica_promocional", cProducto.indica_promocional)
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

    Public Shared Function Borrar(ByVal pEmpresa As String, ByVal pProducto As String) As Boolean
        If Not String.IsNullOrEmpty(pProducto) Then
            Resp = MsgBox("Confirmar proceso de eliminación.", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                Call Eliminar(pEmpresa, pProducto)
                Return True
            End If
        End If
    End Function

    Private Shared Function Eliminar(ByVal pEmpresa As String, ByVal pProducto As String) As Boolean
        MySqlString = "DELETE FROM COM.PRODUCTOS WHERE Empresa=@vEmpresa AND Producto=@vProducto"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
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

                Return True

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

    Public Shared Function BuscarProducto(ByVal pEstado As String) As dsProductosLista.PRODUCTOS_LISTADataTable
        MySqlString = "SELECT PRODUCTO, DESCRIPCION_AMPLIADA,CASE WHEN ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, UNIDAD_COMPRA, " & _
                      "UNIDAD_MEDIDA, STOCK_ACTUAL, STOCK_COMPROMETIDO, STOCK_TRANSITO, UNIDAD_VENTA, INDICA_AFECTO " & _
                      "FROM COM.PRODUCTOS " & _
                      "WHERE Empresa=@vEmpresa AND ESTADO<>@vEstado " & _
                      "ORDER BY DESCRIPCION_AMPLIADA "

        Dim MyDT As New dsProductosLista.PRODUCTOS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProductoActivos(ByVal pDescripcion As String) As dsProductosLista.PRODUCTOS_LISTADataTable
        MyStoreProcedure = "COM.PRODUCTOS_LISTA_ACTIVOS"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        MyParameter_2 = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 200) : MyParameter_2.Value = pDescripcion

        Dim MyDT As New dsProductosLista.PRODUCTOS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProductosImprimir(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pIndicaStock As Byte) As dsProductosImprimir.PRODUCTOS_IMPRIMIRDataTable
        MyStoreProcedure = "COM.PRODUCTOS_IMPRIMIR"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 200) : MyParameter_2.Value = pDescripcion
        MyParameter_3 = New SqlParameter("@INDICA_STOCK", SqlDbType.TinyInt) : MyParameter_3.Value = pIndicaStock

        Dim MyDT As New dsProductosImprimir.PRODUCTOS_IMPRIMIRDataTable

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

    Public Shared Function BuscarStockLote(ByVal pNumeroLote As String, ByVal pProducto As String) As dsStockAlmacen.STOCK_X_LOTEDataTable
        MySqlString = "SELECT EMPRESA, NUMERO_LOTE, PRODUCTO, DESCRIPCION, INGRESOS, EGRESOS, STOCK, FECHA_VENCIMIENTO " & _
                      "FROM ALM.STOCK_X_LOTE " & _
                      "WHERE Empresa=@vEmpresa AND Numero_lote=@vNumero_lote AND producto=@vProducto "

        Dim MyDT As New dsStockAlmacen.STOCK_X_LOTEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", pNumeroLote)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarStockAlmacen(ByVal pAlmacen As String, ByVal pNumeroLote As String, ByVal pProducto As String) As dsStockAlmacen.STOCK_X_ALMACENDataTable
        MySqlString = "SELECT EMPRESA, ALMACEN, NUMERO_LOTE, PRODUCTO, DESCRIPCION, INGRESOS, EGRESOS, STOCK, FECHA_VENCIMIENTO " & _
                      "FROM ALM.STOCK_X_ALMACEN " & _
                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND producto=@vProducto "

        Dim MyDT As New dsStockAlmacen.STOCK_X_ALMACENDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", pNumeroLote)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
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

    Public Shared Function BuscarKardexProductoAlmacen(ByVal pEmpresa As String, ByVal pAlmacen As String, ByVal pProducto As String) As dsKardexProductoAlmacen.KARDEX_PRODUCTO_ALMACENDataTable
        MyStoreProcedure = "COM.KARDEX_PRODUCTO_ALMACEN"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen
        MyParameter_3 = New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto

        Dim MyDT As New dsKardexProductoAlmacen.KARDEX_PRODUCTO_ALMACENDataTable

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

    Public Shared Function BuscarKardexValorizadoAlmacen(ByVal pEmpresa As String, ByVal pAlmacen As String, ByVal pProducto As String, ByVal pFecha As Date) As dsKardexValorizadoAlmacen.KARDEX_VALORIZADODataTable
        MyStoreProcedure = "COM.KARDEX_VALORIZADO_ALMACEN"

        pFecha = DateAdd(DateInterval.Day, 1, pFecha)

        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen
        MyParameter_3 = New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto
        MyParameter_4 = New SqlParameter("@FECHA_MOVIMIENTO", SqlDbType.DateTime) : MyParameter_4.Value = pFecha

        Dim MyDT As New dsKardexValorizadoAlmacen.KARDEX_VALORIZADODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProductosRegularizar(ByVal pEmpresa As String, ByVal pAlmacen As String) As dsProductosRegularizacionLista.PRODUCTOS_REGULARIZAR_LISTADataTable
        MyStoreProcedure = "COM.PRODUCTOS_REGULARIZAR_LISTA"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen

        Dim MyDT As New dsProductosRegularizacionLista.PRODUCTOS_REGULARIZAR_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProductosRegularizarImprimir(ByVal pEmpresa As String, ByVal pAlmacen As String) As dsProductosRegularizarImprimir.PRODUCTOS_REGULARIZAR_IMPRIMIRDataTable
        MyStoreProcedure = "COM.PRODUCTOS_REGULARIZAR_IMPRIMIR"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@ALMACEN", SqlDbType.Char, 3) : MyParameter_2.Value = pAlmacen

        Dim MyDT As New dsProductosRegularizarImprimir.PRODUCTOS_REGULARIZAR_IMPRIMIRDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProducto(ByVal pEmpresa As String, ByVal pProducto As String, ByVal pCodigoBarras As String) As String
        MySql = "SELECT ISNULL(DESCRIPCION_AMPLIADA,'') AS NOMBRE_PRODUCTO FROM COM.PRODUCTOS " & _
                "WHERE EMPRESA='" & pEmpresa & "' AND CODIGO_ANTIGUO='" & pCodigoBarras & "' AND PRODUCTO<>'" & pProducto & "' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            Return NewCode
        End Using
    End Function

    Public Shared Function BuscarCodigoBarras(ByVal pEmpresa As String, ByVal pCodigoBarras As String) As String
        MySql = "SELECT ISNULL(PRODUCTO,'') AS PRODUCTO FROM COM.PRODUCTOS " & _
                "WHERE EMPRESA='" & pEmpresa & "' AND CODIGO_ANTIGUO='" & pCodigoBarras & "' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            Return NewCode
        End Using
    End Function

    Public Shared Function BuscarProductoCodigo(ByVal pEmpresa As String, ByVal pCodigo As String, ByVal pIndicaCompuesto As String, ByVal pEstado As String) As dsProductosLista.PRODUCTOS_LISTADataTable
        MyStoreProcedure = "COM.PRODUCTO_X_CODIGO"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@PRODUCTO", SqlDbType.VarChar, 8) : MyParameter_2.Value = RTrim(pCodigo)
        MyParameter_3 = New SqlParameter("@INDICA_COMPUESTO", SqlDbType.Char, 2) : MyParameter_3.Value = pIndicaCompuesto
        MyParameter_4 = New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_4.Value = pEstado

        Dim MyDT As New dsProductosLista.PRODUCTOS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarProductoDescripcion(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pIndicaCompuesto As String, ByVal pEstado As String) As dsProductosLista.PRODUCTOS_LISTADataTable
        MyStoreProcedure = "COM.PRODUCTO_X_NOMBRE"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 200) : MyParameter_2.Value = pDescripcion
        MyParameter_3 = New SqlParameter("@INDICA_COMPUESTO", SqlDbType.Char, 2) : MyParameter_3.Value = pIndicaCompuesto
        MyParameter_4 = New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_4.Value = pEstado

        Dim MyDT As New dsProductosLista.PRODUCTOS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComponentes(ByVal pEmpresa As String, ByVal pCodigo As String) As dsProductos.COMPUESTOSDataTable
        MyStoreProcedure = "COM.COMPONENTES_X_COMPUESTO"
        MyParameter_1 = New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        MyParameter_2 = New SqlParameter("@PRODUCTO", SqlDbType.VarChar, 8) : MyParameter_2.Value = RTrim(pCodigo)

        Dim MyDT As New dsProductos.COMPUESTOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Private Shared Function Existe(ByVal cCompuesto As String, ByVal cComponente As String, ByVal cCantidad As Integer) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.PRODUCTOS_COMPUESTOS " & _
                      "WHERE Empresa=@vEmpresa AND producto_compuesto=@vProducto_compuesto AND producto=@vProducto"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto_compuesto", cCompuesto)
            MySQLCommand.Parameters.AddWithValue("vProducto", cComponente)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Grabar(ByVal cCompuesto As String, ByVal cComponente As String, ByVal cCantidad As Integer) As Boolean
        If Not Existe(cCompuesto, cComponente, cCantidad) Then
            Return Insertar(cCompuesto, cComponente, cCantidad)
        Else
            Return Actualizar(cCompuesto, cComponente, cCantidad)
        End If
    End Function

    Private Shared Function Insertar(ByVal cCompuesto As String, ByVal cComponente As String, ByVal cCantidad As Integer) As Boolean
        MySql = "INSERT INTO COM.PRODUCTOS_COMPUESTOS " & _
                "(empresa,producto_compuesto,producto,cantidad,usuario_registro) " & _
                "VALUES (@vEmpresa,@vProducto_compuesto,@vProducto,@vCantidad,@vUsuario_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vProducto_compuesto", cCompuesto)
                .AddWithValue("vProducto", cComponente)
                .AddWithValue("vCantidad", cCantidad)
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

                Return True

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

    Private Shared Function Actualizar(ByVal cCompuesto As String, ByVal cComponente As String, ByVal cCantidad As Integer) As Boolean

        MySql = "UPDATE COM.PRODUCTOS_COMPUESTOS SET " & _
                "cantidad=@vCantidad,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE empresa=@vEmpresa AND producto_compuesto=@vProducto_compuesto AND producto=@vProducto"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vCantidad", cCantidad)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("@vFecha_modifica", Now)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vProducto_compuesto", cCompuesto)
                .AddWithValue("vProducto", cComponente)
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

End Class