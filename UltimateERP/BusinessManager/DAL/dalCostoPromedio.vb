Imports System.Data.SqlClient

Public Class dalCostoPromedio
    Private Shared MyStoreProcedure As String
    Private Shared MySQL As String
    Private Shared MySQL_1 As String
    Private Shared MySQL_2 As String

    Public Shared Function MovimientosPorCostear(ByVal pEmpresa As String, ByVal pEjercicio As String) As dsCostos.MOVIMIENTOS_PRODUCTODataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_POR_COSTEAR"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio

        Dim MyDT As New dsCostos.MOVIMIENTOS_PRODUCTODataTable

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

    Public Shared Function ObtenerMovimientosKardex(ByVal pEmpresa As String, ByVal pEjercicio As String) As dsCostos.KARDEX_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio

        Dim MyDT As New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexFecha(pEmpresa As String, pEjercicio As String, pFecha As String) As dsCostos.KARDEX_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX_X_FECHA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@FECHA", SqlDbType.Char, 8) : MyParameter_3.Value = pFecha

        Dim MyDT As New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexSaldo(ByVal pEmpresa As String, ByVal pEjercicio As String) As dsCostos.SALDO_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio

        Dim MyDT As New dsCostos.SALDO_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexProducto(ByVal pEmpresa As String, ByVal pEjercicio As String, pProducto As String) As dsCostos.KARDEX_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX_PRODUCTO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto

        Dim MyDT As New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexFechaSaldo(pEmpresa As String, pEjercicio As String, pFecha As String) As dsCostos.SALDO_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX_X_FECHA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@FECHA", SqlDbType.Char, 8) : MyParameter_3.Value = pFecha

        Dim MyDT As New dsCostos.SALDO_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexFechaProductoSaldo(pEmpresa As String, pEjercicio As String, pProducto As String, pFecha As String) As dsCostos.SALDO_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX_X_FECHA_PRODUCTO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@PRODUCTO", SqlDbType.Char, 8) : MyParameter_3.Value = pProducto
        Dim MyParameter_4 As New SqlParameter("@FECHA", SqlDbType.Char, 8) : MyParameter_4.Value = pFecha

        Dim MyDT As New dsCostos.SALDO_VALORIZADO_DETALLESDataTable

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

    Public Shared Function ObtenerMovimientosKardexEspecifico(ByVal pEmpresa As String, ByVal pEjercicio As String, pAlmacen As String, pLinea As String, pTipo As String, pProducto As String) As dsCostos.SALDO_VALORIZADO_DETALLESDataTable
        MyStoreProcedure = "CON.MOVIMIENTOS_KARDEX_ESPECIFICO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@ALMACEN", SqlDbType.VarChar, 20) : MyParameter_3.Value = pAlmacen
        Dim MyParameter_4 As New SqlParameter("@PRODUCTO_FAMILIA", SqlDbType.VarChar, 20) : MyParameter_4.Value = pLinea
        Dim MyParameter_5 As New SqlParameter("@PRODUCTO_TIPO", SqlDbType.VarChar, 20) : MyParameter_5.Value = pTipo
        Dim MyParameter_6 As New SqlParameter("@PRODUCTO", SqlDbType.VarChar, 8) : MyParameter_6.Value = pProducto

        Dim MyDT As New dsCostos.SALDO_VALORIZADO_DETALLESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            MySQLCommand.Parameters.Add(MyParameter_5)
            MySQLCommand.Parameters.Add(MyParameter_6)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerAlmacenes() As dsCostos.TABLA_ALMACENESDataTable

        MySQL = "SELECT CODIGO, DESCRIPCION, INDICA_VENTA, INDICA_ACTIVO " & _
                "FROM GEN.TABLA_ALMACENES " & _
                "WHERE EMPRESA=@vEmpresa " & _
                "ORDER BY CODIGO"

        Dim MyDT As New dsCostos.TABLA_ALMACENESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerCostoImportacion(pPoliza As String, pCompra As String, pLinea As String, pProducto As String) As dsCostos.COSTO_IMPORTACIONDataTable

        MySQL = "SELECT P.EMPRESA, P.POLIZA, D.COMPRA, D.LINEA, D.PRODUCTO, D.CANTIDAD_FACTURADA AS CANTIDAD, D.CU_FOB_ME, D.CU_FOB_MN, D.CU_TOTAL_ME, D.CU_TOTAL_MN, P.COMENTARIO, 1 AS ORDEN " & _
                "FROM IMP.POLIZAS AS P INNER JOIN IMP.COSTEO AS C ON P.EMPRESA = C.EMPRESA AND P.POLIZA = C.POLIZA " & _
                                      "INNER JOIN IMP.COSTEO_DET AS D ON C.EMPRESA = D.EMPRESA AND C.COSTEO = D.COSTEO " & _
                "WHERE P.EMPRESA=@vEmpresa AND P.POLIZA=@vPoliza AND D.COMPRA=@vCompra AND D.LINEA=@vLinea AND D.PRODUCTO=@vProducto AND C.ESTADO<>'N' " & _
                "UNION ALL " & _
                "SELECT P.EMPRESA, P.POLIZA, D.COMPRA, D.LINEA, D.PRODUCTO, D.CANTIDAD_FACTURADA AS CANTIDAD, D.PRECIO_UNITARIO AS CU_FOB_ME, D.PRECIO_UNITARIO*C.TIPO_CAMBIO AS CU_FOB_MN, 0 AS CU_TOTAL_ME, 0 AS CU_TOTAL_MN, P.COMENTARIO, 2 AS ORDEN " & _
                "FROM IMP.POLIZAS AS P INNER JOIN COM.COMPRAS AS C ON P.EMPRESA = C.EMPRESA AND P.POLIZA = C.POLIZA " & _
                                      "INNER JOIN COM.COMPRAS_PRO AS D ON C.EMPRESA=D.EMPRESA AND C.COMPRA=D.COMPRA " & _
                "WHERE P.EMPRESA=@vEmpresa AND P.POLIZA=@vPoliza AND D.COMPRA=@vCompra AND D.LINEA=@vLinea AND D.PRODUCTO=@vProducto AND C.ESTADO<>'N' " & _
                "ORDER BY P.EMPRESA, P.POLIZA, D.COMPRA, D.LINEA, D.PRODUCTO, ORDEN "

        Dim MyDT As New dsCostos.COSTO_IMPORTACIONDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vPoliza", pPoliza)
            MySQLCommand.Parameters.AddWithValue("vCompra", pCompra)
            MySQLCommand.Parameters.AddWithValue("vLinea", pLinea)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerCostoOperacionesAnteriores(pComprobanteTipo As String, pComprobanteSerie As String, pComprobanteNumero As String, pProducto As String) As dsCostos.COSTO_OPERACIONES_ANTERIORESDataTable

        MySQL = "SELECT EMPRESA, COMPROBANTE_TIPO, COMPROBANTE_SERIE, COMPROBANTE_NUMERO, PRODUCTO, COSTO_UNITARIO_ME, COSTO_UNITARIO_MN, " & _
                "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA " & _
                "FROM CON.COSTO_OPERACIONES_ANTERIORES " & _
                "WHERE EMPRESA=@vEmpresa AND COMPROBANTE_TIPO=@vComprobante_tipo AND COMPROBANTE_SERIE=@vComprobante_serie AND COMPROBANTE_NUMERO=@vComprobante_numero AND PRODUCTO=@vProducto "

        Dim MyDT As New dsCostos.COSTO_OPERACIONES_ANTERIORESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", pComprobanteTipo)
            MySQLCommand.Parameters.AddWithValue("vComprobante_serie", pComprobanteSerie)
            MySQLCommand.Parameters.AddWithValue("vComprobante_numero", pComprobanteNumero)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerUtilidadProducto(pEmpresa As String, pEjercicio As String, pAlmacen As String, pMarca As String, pModelo As String, pLinea As String, pSubLinea As String, pProducto As String, pFechaDesde As String, pFechaHasta As String) As dsCostos.UTILIDAD_PRODUCTODataTable
        MySQL = "SELECT PRODUCTO, CODIGO_COMPRA, PRODUCTO_FAMILIA, PRODUCTO_SUB_FAMILIA, PRODUCTO_TIPO, PRODUCTO_SUB_TIPO, ALMACEN, ALMACEN_NOMBRE, PRODUCTO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE, " & _
                "UNIDADES_VENDIDAS=SUM(UNIDADES_VENDIDAS), " & _
                "VALOR_VENTA_MN= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)*(CASE WHEN TIPO_MONEDA='1' THEN 1 ELSE TC  END)), " & _
                "VALOR_VENTA_ME= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)/(CASE WHEN TIPO_MONEDA='2' THEN 1 ELSE TC  END)), " & _
                "COSTO_VENTA_MN=SUM(COSTO_UNITARIO_MN*UNIDADES_VENDIDAS), " & _
                "COSTO_VENTA_ME=SUM(COSTO_UNITARIO_ME*UNIDADES_VENDIDAS), " & _
                "UTILIDAD_MN=0, UTILIDAD_ME=0, VALOR_VENTA=0, COSTO_VENTA=0, UTILIDAD=0 " & _
                "FROM CON.MOVIMIENTOS_UTILIDAD " & _
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND (COMPROBANTE_FECHA BETWEEN @vFechaDesde AND @vFechaHasta) " & _
                IIf(pAlmacen = "TODOS", "", "AND ALMACEN='" & pAlmacen & "' ") & _
                IIf(pLinea = "TODOS", "", "AND PRODUCTO_TIPO='" & pLinea & "' ") &
                IIf(pSubLinea = "TODOS", "", "AND PRODUCTO_SUB_TIPO='" & pSubLinea & "' ") &
                IIf(pMarca = "TODOS", "", "AND PRODUCTO_FAMILIA='" & pMarca & "' ") &
                IIf(pModelo = "TODOS", "", "AND PRODUCTO_SUB_FAMILIA='" & pModelo & "' ") &
                IIf(pProducto = "", "", "AND PRODUCTO='" & pProducto & "' ") & _
                "GROUP BY PRODUCTO, CODIGO_COMPRA, PRODUCTO_FAMILIA, PRODUCTO_SUB_FAMILIA, PRODUCTO_TIPO, PRODUCTO_SUB_TIPO, ALMACEN, ALMACEN_NOMBRE, PRODUCTO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE " & _
                "ORDER BY ALMACEN_NOMBRE, PRODUCTO_TIPO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_NOMBRE"

        Dim MyDT As New dsCostos.UTILIDAD_PRODUCTODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vFechaDesde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFechaHasta", pFechaHasta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerUtilidadEspecificaProducto(pEmpresa As String, pEjercicio As String, pAlmacen As String, pMarca As String, pModelo As String, pLinea As String, pSubLinea As String, pProducto As String, pFechaDesde As String, pFechaHasta As String) As dsCostos.UTILIDAD_ESPECIFICADataTable
        MySQL = "SELECT PRODUCTO, PRODUCTO_FAMILIA, PRODUCTO_SUB_FAMILIA, PRODUCTO_TIPO, PRODUCTO_SUB_TIPO, ALMACEN, ALMACEN_NOMBRE, PRODUCTO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE, " & _
                "PRECIO_COMPRA_MN, PRECIO_COMPRA_ME, PRECIO_VENTA_MN, PRECIO_VENTA_ME, " & _
                "UTILIDAD_MN=PRECIO_VENTA_MN-PRECIO_COMPRA_MN, " & _
                "UTILIDAD_ME=PRECIO_VENTA_ME-PRECIO_COMPRA_ME, " & _
                "CLIENTE, VENTA_COMPROBANTE, VENTA_FECHA, VENTA_MONEDA, PROVEEDOR, COMPRA_COMPROBANTE, COMPRA_FECHA, COMPRA_MONEDA " & _
                "FROM CON.MOVIMIENTOS_UTILIDAD_ESPECIFICA " & _
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND (VENTA_FECHA BETWEEN @vFechaDesde AND @vFechaHasta) " & _
                IIf(pAlmacen = "TODOS", "", "AND ALMACEN='" & pAlmacen & "' ") & _
                IIf(pLinea = "TODOS", "", "AND PRODUCTO_TIPO='" & pLinea & "' ") &
                IIf(pSubLinea = "TODOS", "", "AND PRODUCTO_SUB_TIPO='" & pSubLinea & "' ") &
                IIf(pMarca = "TODOS", "", "AND PRODUCTO_FAMILIA='" & pMarca & "' ") &
                IIf(pModelo = "TODOS", "", "AND PRODUCTO_SUB_FAMILIA='" & pModelo & "' ") &
                IIf(pProducto = "", "", "AND PRODUCTO='" & pProducto & "' ") & _
                "ORDER BY VENTA_FECHA "

        Dim MyDT As New dsCostos.UTILIDAD_ESPECIFICADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vFechaDesde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFechaHasta", pFechaHasta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerUtilidadCliente(pEmpresa As String, pEjercicio As String, pCliente As String, pFechaDesde As String, pFechaHasta As String) As dsCostos.UTILIDAD_CLIENTEDataTable
        MySQL = "SELECT RAZON_SOCIAL, " & _
                "VALOR_VENTA_MN= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)*(CASE WHEN TIPO_MONEDA='1' THEN 1 ELSE TC  END)), " & _
                "VALOR_VENTA_ME= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)/(CASE WHEN TIPO_MONEDA='2' THEN 1 ELSE TC  END)), " & _
                "COSTO_VENTA_MN=SUM(COSTO_UNITARIO_MN*UNIDADES_VENDIDAS), " & _
                "COSTO_VENTA_ME=SUM(COSTO_UNITARIO_ME*UNIDADES_VENDIDAS), " & _
                "UTILIDAD_MN=0, UTILIDAD_ME=0, VALOR_VENTA=0, COSTO_VENTA=0, UTILIDAD=0 " & _
                "FROM CON.MOVIMIENTOS_UTILIDAD " & _
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND (COMPROBANTE_FECHA BETWEEN @vFechaDesde AND @vFechaHasta) " & _
                IIf(pCliente = "", "", "AND CUENTA_COMERCIAL='" & pCliente & "' ") & _
                "GROUP BY RAZON_SOCIAL  " & _
                "ORDER BY RAZON_SOCIAL "

        Dim MyDT As New dsCostos.UTILIDAD_CLIENTEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vFechaDesde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFechaHasta", pFechaHasta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerUtilidadVendedor(pEmpresa As String, pEjercicio As String, pVendedor As String, pFechaDesde As String, pFechaHasta As String) As dsCostos.UTILIDAD_VENDEDORDataTable
        MySQL = "SELECT VENDEDOR, VENDEDOR_NOMBRE, PRODUCTO, CODIGO_COMPRA, PRODUCTO_FAMILIA, PRODUCTO_TIPO,  PRODUCTO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE, " & _
                "UNIDADES_VENDIDAS=SUM(UNIDADES_VENDIDAS), " & _
                "VALOR_VENTA_MN= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)*(CASE WHEN TIPO_MONEDA='1' THEN 1 ELSE TC  END)), " & _
                "VALOR_VENTA_ME= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)/(CASE WHEN TIPO_MONEDA='2' THEN 1 ELSE TC  END)), " & _
                "COSTO_VENTA_MN=SUM(COSTO_UNITARIO_MN*UNIDADES_VENDIDAS), " & _
                "COSTO_VENTA_ME=SUM(COSTO_UNITARIO_ME*UNIDADES_VENDIDAS), " & _
                "UTILIDAD_MN=0, UTILIDAD_ME=0, VALOR_VENTA=0, COSTO_VENTA=0, UTILIDAD=0 " & _
                "FROM CON.MOVIMIENTOS_UTILIDAD " & _
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND (COMPROBANTE_FECHA BETWEEN @vFechaDesde AND @vFechaHasta) " & _
                IIf(pVendedor = "TODOS", "", "AND VENDEDOR='" & pVendedor & "' ") & _
                "GROUP BY VENDEDOR, VENDEDOR_NOMBRE, PRODUCTO, CODIGO_COMPRA, PRODUCTO_FAMILIA, PRODUCTO_TIPO,  PRODUCTO_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE " & _
                "ORDER BY VENDEDOR_NOMBRE, PRODUCTO_FAMILIA_NOMBRE, PRODUCTO_TIPO_NOMBRE, PRODUCTO_NOMBRE "

        Dim MyDT As New dsCostos.UTILIDAD_VENDEDORDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vFechaDesde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFechaHasta", pFechaHasta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerUtilidadDocumento(pEmpresa As String, pEjercicio As String, pTipo As String, pSerie As String, pNumero As String, pFechaDesde As String, pFechaHasta As String) As dsCostos.UTILIDAD_DOCUMENTODataTable
        MySQL = "SELECT RAZON_SOCIAL, COMPROBANTE, COMPROBANTE_FECHA, PRODUCTO, CODIGO_COMPRA, PRODUCTO_NOMBRE, " & _
                "UNIDADES_VENDIDAS=SUM(UNIDADES_VENDIDAS), " & _
                "VALOR_VENTA_MN= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)*(CASE WHEN TIPO_MONEDA='1' THEN 1 ELSE TC  END)), " & _
                "VALOR_VENTA_ME= SUM(IMPORTE_TOTAL_ORIGEN/(1+PORCENTAJE_IGV)/(CASE WHEN TIPO_MONEDA='2' THEN 1 ELSE TC  END)), " & _
                "COSTO_VENTA_MN=SUM(COSTO_UNITARIO_MN*UNIDADES_VENDIDAS), " & _
                "COSTO_VENTA_ME=SUM(COSTO_UNITARIO_ME*UNIDADES_VENDIDAS), " & _
                "UTILIDAD_MN=0, UTILIDAD_ME=0, VALOR_VENTA=0, COSTO_VENTA=0, UTILIDAD=0 " & _
                "FROM CON.MOVIMIENTOS_UTILIDAD " & _
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND (COMPROBANTE_FECHA BETWEEN @vFechaDesde AND @vFechaHasta) " & _
                IIf(pTipo = "", "", "AND COMPROBANTE_TIPO='" & pTipo & "' ") & _
                IIf(pSerie = "", "", "AND COMPROBANTE_SERIE='" & pSerie & "' ") & _
                IIf(pNumero = "", "", "AND COMPROBANTE_NUMERO='" & pNumero & "' ") & _
                "GROUP BY RAZON_SOCIAL, COMPROBANTE, COMPROBANTE_FECHA, PRODUCTO, CODIGO_COMPRA, PRODUCTO_NOMBRE " & _
                "ORDER BY RAZON_SOCIAL, COMPROBANTE, PRODUCTO_NOMBRE "

        Dim MyDT As New dsCostos.UTILIDAD_DOCUMENTODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vFechaDesde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFechaHasta", pFechaHasta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerInventarioValorizadoMN(ByVal pEmpresa As String, ByVal pEjercicio As String, pAlmacen As String, pProducto As String, pLinea As String, pSubLinea As String, pMarca As String, pModelo As String) As dsCostos.INVENTARIO_VALORIZADODataTable
        MySQL = "SELECT K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, A.DESCRIPCION AS ALMACEN_NOMBRE, K.PRODUCTO_NOMBRE, " & _
                "DOCUMENTO_FECHA=K.OPERACION_FECHA, " & _
                "DOCUMENTO_TIPO=CASE K.REFERENCIA_TIPO WHEN 'FT' THEN '01' WHEN 'BV' THEN '03' ELSE K.REFERENCIA_TIPO END, " & _
                "DOCUMENTO_SERIE=K.REFERENCIA_SERIE, " & _
                "DOCUMENTO_NUMERO=K.REFERENCIA_NUMERO, " & _
                "TIPO_OPERACION=K.CODIGO_SUNAT, " & _
                "K.CANTIDAD_ENTRADA, " & _
                "COSTO_UNITARIO_ENTRADA=CASE WHEN K.TIPO_ES='I' THEN K.PRECIO_UNITARIO_MN ELSE 0 END, " & _
                "COSTO_TOTAL_ENTRADA=CASE WHEN K.TIPO_ES='I' THEN K.COSTO_TOTAL_MN_DEBE ELSE 0 END, " & _
                "K.CANTIDAD_SALIDA, " & _
                "COSTO_UNITARIO_SALIDA=CASE WHEN K.TIPO_ES='S' THEN K.COSTO_UNITARIO_MN ELSE 0 END," & _
                "COSTO_TOTAL_SALIDA=CASE WHEN K.TIPO_ES='S' THEN K.COSTO_TOTAL_MN_HABER ELSE 0 END," & _
                "CANTIDAD_STOCK=K.CANTIDAD_SALDO," & _
                "COSTO_UNITARIO_STOCK=CASE WHEN K.CANTIDAD_SALDO<>0 THEN K.COSTO_SALDO_MN/K.CANTIDAD_SALDO ELSE 0 END, " & _
                "COSTO_TOTAL_STOCK=K.COSTO_SALDO_MN, ORDEN=CASE WHEN LEFT(K.OPERACION,2)='OA' THEN 1 ELSE 2 END " & _
                "FROM CON.KARDEX_VALORIZADO_ACTUAL AS K INNER JOIN GEN.TABLA_ALMACENES AS A ON K.EMPRESA=A.EMPRESA AND K.ALMACEN=A.CODIGO " & _
                "INNER JOIN COM.PRODUCTOS AS P ON P.EMPRESA=K.EMPRESA AND P.PRODUCTO=K.PRODUCTO " & _
                "WHERE K.EMPRESA=@vEmpresa " & _
                IIf(pAlmacen = "TODOS", "", "AND K.ALMACEN='" & pAlmacen & "' ") &
                IIf(pProducto = "", "", "AND K.PRODUCTO='" & pProducto & "' ") &
                IIf(pLinea = "TODOS", "", "AND P.PRODUCTO_TIPO='" & pLinea & "' ") &
                IIf(pSubLinea = "TODOS", "", "AND P.PRODUCTO_SUB_TIPO='" & pSubLinea & "' ") &
                IIf(pMarca = "TODOS", "", "AND P.PRODUCTO_FAMILIA='" & pMarca & "' ") &
                IIf(pModelo = "TODOS", "", "AND P.PRODUCTO_SUB_FAMILIA='" & pModelo & "' ") &
                "ORDER BY K.ALMACEN, K.PRODUCTO_NOMBRE, K.OPERACION_FECHA, K.TIPO_ES, ORDEN "

        Dim MyDT As New dsCostos.INVENTARIO_VALORIZADODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerInventarioValorizadoME(ByVal pEmpresa As String, ByVal pEjercicio As String, pAlmacen As String, pProducto As String, pLinea As String, pSubLinea As String, pMarca As String, pModelo As String) As dsCostos.INVENTARIO_VALORIZADODataTable
        MySQL = "SELECT K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, A.DESCRIPCION AS ALMACEN_NOMBRE, K.PRODUCTO_NOMBRE, " & _
                "DOCUMENTO_FECHA=K.OPERACION_FECHA, " & _
                "DOCUMENTO_TIPO=CASE K.REFERENCIA_TIPO WHEN 'FT' THEN '01' WHEN 'BV' THEN '03' ELSE K.REFERENCIA_TIPO END, " & _
                "DOCUMENTO_SERIE=K.REFERENCIA_SERIE, " & _
                "DOCUMENTO_NUMERO=K.REFERENCIA_NUMERO, " & _
                "TIPO_OPERACION=K.CODIGO_SUNAT, " & _
                "K.CANTIDAD_ENTRADA, " & _
                "COSTO_UNITARIO_ENTRADA=CASE WHEN K.TIPO_ES='I' THEN K.PRECIO_UNITARIO_ME ELSE 0 END, " & _
                "COSTO_TOTAL_ENTRADA=CASE WHEN K.TIPO_ES='I' THEN K.COSTO_TOTAL_ME_DEBE ELSE 0 END, " & _
                "K.CANTIDAD_SALIDA, " & _
                "COSTO_UNITARIO_SALIDA=CASE WHEN K.TIPO_ES='S' THEN K.COSTO_UNITARIO_ME ELSE 0 END," & _
                "COSTO_TOTAL_SALIDA=CASE WHEN K.TIPO_ES='S' THEN K.COSTO_TOTAL_ME_HABER ELSE 0 END," & _
                "CANTIDAD_STOCK=K.CANTIDAD_SALDO," & _
                "COSTO_UNITARIO_STOCK=CASE WHEN K.CANTIDAD_SALDO<>0 THEN K.COSTO_SALDO_ME/K.CANTIDAD_SALDO ELSE 0 END, " & _
                "COSTO_TOTAL_STOCK=K.COSTO_SALDO_ME, ORDEN=CASE WHEN LEFT(K.OPERACION,2)='OA' THEN 1 ELSE 2 END " & _
                "FROM CON.KARDEX_VALORIZADO_ACTUAL AS K INNER JOIN GEN.TABLA_ALMACENES AS A ON K.EMPRESA=A.EMPRESA AND K.ALMACEN=A.CODIGO " & _
                "INNER JOIN COM.PRODUCTOS AS P ON P.EMPRESA=K.EMPRESA AND P.PRODUCTO=K.PRODUCTO " & _
                "WHERE K.EMPRESA=@vEmpresa " & _
                IIf(pAlmacen = "TODOS", "", "AND K.ALMACEN='" & pAlmacen & "' ") &
                IIf(pProducto = "", "", "AND K.PRODUCTO='" & pProducto & "' ") &
                IIf(pLinea = "TODOS", "", "AND P.PRODUCTO_TIPO='" & pLinea & "' ") &
                IIf(pSubLinea = "TODOS", "", "AND P.PRODUCTO_SUB_TIPO='" & pSubLinea & "' ") &
                IIf(pMarca = "TODOS", "", "AND P.PRODUCTO_FAMILIA='" & pMarca & "' ") &
                IIf(pModelo = "TODOS", "", "AND P.PRODUCTO_SUB_FAMILIA='" & pModelo & "' ") &
                "ORDER BY K.ALMACEN, K.PRODUCTO_NOMBRE, K.OPERACION_FECHA, K.TIPO_ES, ORDEN "

        Dim MyDT As New dsCostos.INVENTARIO_VALORIZADODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerSaldoValorizadoMN(ByVal pEmpresa As String, ByVal pFecha As String, pAlmacen As String, pProducto As String, pProductoMarca As String, pProductoModelo As String, pProductoLinea As String, pProductoSubLinea As String) As dsCostos.SALDO_VALORIZADODataTable
        MySQL = "SELECT K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO, TA.DESCRIPCION AS ALMACEN_NOMBRE, K.PRODUCTO_NOMBRE, " &
                "TPF.DESCRIPCION AS PRODUCTO_FAMILIA_NOMBRE, TPT.DESCRIPCION AS PRODUCTO_TIPO_NOMBRE, " &
                "STOCK=SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " &
                "COSTO_PROMEDIO=SUM(K.COSTO_TOTAL_MN_DEBE-K.COSTO_TOTAL_MN_HABER)/SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " &
                "COSTO_TOTAL=SUM(K.COSTO_TOTAL_MN_DEBE-K.COSTO_TOTAL_MN_HABER) " &
                "FROM  CON.KARDEX_VALORIZADO_ACTUAL AS K INNER JOIN COM.PRODUCTOS AS P ON K.EMPRESA = P.EMPRESA AND K.PRODUCTO = P.PRODUCTO " &
                "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON P.EMPRESA = TPF.EMPRESA AND P.PRODUCTO_FAMILIA = TPF.CODIGO " &
                "INNER JOIN GEN.TABLA_PRODUCTO_TIPO AS TPT ON P.EMPRESA = TPT.EMPRESA AND P.PRODUCTO_TIPO = TPT.CODIGO " &
                "INNER JOIN GEN.TABLA_ALMACENES AS TA ON K.EMPRESA = TA.EMPRESA AND K.ALMACEN = TA.CODIGO " &
                "WHERE K.EMPRESA=@vEmpresa AND K.OPERACION_FECHA<=@vFecha " &
                IIf(pAlmacen = "TODOS", "", "AND K.ALMACEN='" & pAlmacen & "' ") &
                IIf(pProducto = "", "", "AND K.PRODUCTO='" & pProducto & "' ") &
                IIf(pProductoLinea = "TODOS", "", "AND P.PRODUCTO_TIPO='" & pProductoLinea & "' ") &
                IIf(pProductoSubLinea = "TODOS", "", "AND P.PRODUCTO_SUB_TIPO='" & pProductoSubLinea & "' ") &
                IIf(pProductoMarca = "TODOS", "", "AND P.PRODUCTO_FAMILIA='" & pProductoMarca & "' ") &
                IIf(pProductoModelo = "TODOS", "", "AND P.PRODUCTO_SUB_FAMILIA='" & pProductoModelo & "' ") &
                "GROUP BY K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO, TA.DESCRIPCION, K.PRODUCTO_NOMBRE, TPF.DESCRIPCION, TPT.DESCRIPCION " &
                "HAVING SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA)<>0 " &
                "ORDER BY K.ALMACEN, TPT.DESCRIPCION, TPF.DESCRIPCION,K.PRODUCTO "


        Dim MyDT As New dsCostos.SALDO_VALORIZADODataTable

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

    Public Shared Function ObtenerSaldoValorizadoME(ByVal pEmpresa As String, ByVal pFecha As String, pAlmacen As String, pProducto As String, pProductoMarca As String, pProductoModelo As String, pProductoLinea As String, pProductoSubLinea As String) As dsCostos.SALDO_VALORIZADODataTable
        MySQL = "SELECT   K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO, TA.DESCRIPCION AS ALMACEN_NOMBRE, K.PRODUCTO_NOMBRE, " &
                "TPF.DESCRIPCION AS PRODUCTO_FAMILIA_NOMBRE, TPT.DESCRIPCION AS PRODUCTO_TIPO_NOMBRE, " &
                "STOCK=SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " &
                "COSTO_PROMEDIO=SUM(K.COSTO_TOTAL_ME_DEBE-K.COSTO_TOTAL_ME_HABER)/SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA), " &
                "COSTO_TOTAL=SUM(K.COSTO_TOTAL_ME_DEBE-K.COSTO_TOTAL_ME_HABER) " &
                "FROM  CON.KARDEX_VALORIZADO_ACTUAL AS K INNER JOIN COM.PRODUCTOS AS P ON K.EMPRESA = P.EMPRESA AND K.PRODUCTO = P.PRODUCTO " &
                "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON P.EMPRESA = TPF.EMPRESA AND P.PRODUCTO_FAMILIA = TPF.CODIGO " &
                "INNER JOIN GEN.TABLA_PRODUCTO_TIPO AS TPT ON P.EMPRESA = TPT.EMPRESA AND P.PRODUCTO_TIPO = TPT.CODIGO " &
                "INNER JOIN GEN.TABLA_ALMACENES AS TA ON K.EMPRESA = TA.EMPRESA AND K.ALMACEN = TA.CODIGO " &
                "WHERE K.EMPRESA=@vEmpresa AND K.OPERACION_FECHA<=@vFecha " &
                IIf(pAlmacen = "TODOS", "", "AND K.ALMACEN='" & pAlmacen & "' ") &
                IIf(pProducto = "", "", "AND K.PRODUCTO='" & pProducto & "' ") &
                IIf(pProductoLinea = "TODOS", "", "AND P.PRODUCTO_TIPO='" & pProductoLinea & "' ") &
                IIf(pProductoSubLinea = "TODOS", "", "AND P.PRODUCTO_SUB_TIPO='" & pProductoSubLinea & "' ") &
                IIf(pProductoMarca = "TODOS", "", "AND P.PRODUCTO_FAMILIA='" & pProductoMarca & "' ") &
                IIf(pProductoModelo = "TODOS", "", "AND P.PRODUCTO_SUB_FAMILIA='" & pProductoModelo & "' ") &
                "GROUP BY K.ALMACEN, K.PRODUCTO, K.CODIGO_COMPRA, P.PRODUCTO_FAMILIA, P.PRODUCTO_TIPO, TA.DESCRIPCION, K.PRODUCTO_NOMBRE, TPF.DESCRIPCION, TPT.DESCRIPCION " &
                "HAVING SUM(K.CANTIDAD_ENTRADA-K.CANTIDAD_SALIDA)<>0 " &
                "ORDER BY K.ALMACEN, TPT.DESCRIPCION, TPF.DESCRIPCION,K.PRODUCTO "


        Dim MyDT As New dsCostos.SALDO_VALORIZADODataTable

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

    Public Shared Function CalcularCostoPromedio(ByRef MyProgressBar As ProgressBar) As Boolean
        Dim NumeroRegistros As Long
        Dim NumeroFila As Long

        Dim CostoUnitarioMN As Decimal
        Dim CostoUnitarioME As Decimal

        Dim MyKardexValorizadoDetalles = New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable
        Dim MySaldosValorizados = New dsCostos.SALDOS_VALORIZADOSDataTable
        Dim MyOperacionesAlmacenTransferencia = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable
        Dim MyCostoImportacion = New dsCostos.COSTO_IMPORTACIONDataTable
        Dim MyCostoOperacionesAnteriores = New dsCostos.COSTO_OPERACIONES_ANTERIORESDataTable

        Dim MyAlmacenes = New dsCostos.TABLA_ALMACENESDataTable

        Dim MyKardexValorizadoDetallesFinal = New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable

        Dim AlmacenOrigen As String
        Dim AlmacenDestino As String

        Dim MyKardexVentas As New dsCostos.KARDEX_VENTASDataTable

        Dim MyTransferenciasDestino As New dsCostos.TRANSFERENCIAS_DESTINODataTable

        MyAlmacenes = dalCostoPromedio.ObtenerAlmacenes

        MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardex(MyUsuario.empresa, MyUsuario.ejercicio)

        MyTransferenciasDestino = dalCostoPromedio.ObtenerTransferenciasDestino(MyUsuario.ejercicio)

        If MyKardexValorizadoDetalles.Rows.Count <> 0 Then
            NumeroRegistros = MyKardexValorizadoDetalles.Rows.Count - 1

            MyProgressBar.Maximum = NumeroRegistros + 1
            MyProgressBar.Value = 0
            MyProgressBar.ForeColor = Drawing.Color.Red
            MyProgressBar.Visible = True

            Do While NumeroFila <= NumeroRegistros
                Dim MySaldoValorizado As dsCostos.SALDOS_VALORIZADOSRow
                Dim PrimaryKey1(1) As Object
                With MyKardexValorizadoDetalles(NumeroFila)
                    PrimaryKey1(0) = .ALMACEN
                    PrimaryKey1(1) = .PRODUCTO
                    MySaldoValorizado = MySaldosValorizados.Rows.Find(PrimaryKey1)
                    If Not (MySaldoValorizado Is Nothing) Then
                        Dim MyKardexVenta As dsCostos.KARDEX_VENTASRow
                        Dim PrimaryKey5(1) As Object
                        PrimaryKey5(0) = .VENTA
                        PrimaryKey5(1) = .PRODUCTO

                        If .TIPO_ES = "I" Then
                            If .OPERACION_NOMBRE = "INGRESO POR IMPORTACION" Then
                                If .PRECIO_UNITARIO_ME = 0 Then
                                    MyCostoImportacion = dalCostoPromedio.ObtenerCostoImportacion(.POLIZA, .COMPRA, .LINEA, .PRODUCTO)
                                    If MyCostoImportacion.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_MN, MyCostoImportacion(0).CU_FOB_MN)
                                        .PRECIO_UNITARIO_ME = IIf(MyCostoImportacion(0).ORDEN = 1, MyCostoImportacion(0).CU_TOTAL_ME, MyCostoImportacion(0).CU_FOB_ME)
                                    End If
                                End If

                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                            ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                MyKardexVenta = MyKardexVentas.Rows.Find(PrimaryKey5)

                                If Not (MyKardexVenta Is Nothing) Then
                                    .PRECIO_UNITARIO_MN = MyKardexVenta.COSTO_UNITARIO_MN
                                    .PRECIO_UNITARIO_ME = MyKardexVenta.COSTO_UNITARIO_ME

                                    MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                    MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                                Else
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME

                                        MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                        MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                                    Else
                                        .PRECIO_UNITARIO_MN = MySaldoValorizado.COSTO_PROMEDIO_MN
                                        .PRECIO_UNITARIO_ME = MySaldoValorizado.COSTO_PROMEDIO_ME

                                        MySaldoValorizado.COSTO_TOTAL_MN = (MySaldoValorizado.COSTO_PROMEDIO_MN) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                        MySaldoValorizado.COSTO_TOTAL_ME = (MySaldoValorizado.COSTO_PROMEDIO_ME) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                    End If
                                End If
                            Else
                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                            End If

                            MySaldoValorizado.STOCK = MySaldoValorizado.STOCK + .CANTIDAD

                            CostoUnitarioMN = Math.Round(MySaldoValorizado.COSTO_TOTAL_MN / MySaldoValorizado.STOCK, 5)
                            CostoUnitarioME = Math.Round(MySaldoValorizado.COSTO_TOTAL_ME / MySaldoValorizado.STOCK, 5)

                            If .OPERACION_NOMBRE <> "INGRESO POR DEVOLUCION DE VENTA" Then
                                MySaldoValorizado.COSTO_PROMEDIO_MN = CostoUnitarioMN
                                MySaldoValorizado.COSTO_PROMEDIO_ME = CostoUnitarioME
                            End If

                        Else
                            If MySaldoValorizado.STOCK <> 0 Then
                                CostoUnitarioMN = Math.Round(MySaldoValorizado.COSTO_TOTAL_MN / MySaldoValorizado.STOCK, 5)
                                CostoUnitarioME = Math.Round(MySaldoValorizado.COSTO_TOTAL_ME / MySaldoValorizado.STOCK, 5)

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK - .CANTIDAD
                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN - .CANTIDAD * CostoUnitarioMN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME - .CANTIDAD * CostoUnitarioME
                            End If
                        End If

                        .CANTIDAD_SALDO = MySaldoValorizado.STOCK

                        .COSTO_UNITARIO_MN = CostoUnitarioMN
                        .COSTO_UNITARIO_ME = CostoUnitarioME

                        If .TIPO_ES = "I" Then
                            If .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                If Not (MyKardexVenta Is Nothing) Then
                                    .COSTO_TOTAL_MN_DEBE = .CANTIDAD * MyKardexVenta.COSTO_UNITARIO_MN
                                    .COSTO_TOTAL_ME_DEBE = .CANTIDAD * MyKardexVenta.COSTO_UNITARIO_ME
                                Else
                                    MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                    If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                        .COSTO_TOTAL_MN_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                        .COSTO_TOTAL_ME_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                    Else
                                        .COSTO_TOTAL_MN_DEBE = .CANTIDAD * CostoUnitarioMN
                                        .COSTO_TOTAL_ME_DEBE = .CANTIDAD * CostoUnitarioME
                                    End If
                                End If
                            Else
                                .COSTO_TOTAL_MN_DEBE = .CANTIDAD * .PRECIO_UNITARIO_MN
                                .COSTO_TOTAL_ME_DEBE = .CANTIDAD * .PRECIO_UNITARIO_ME
                            End If
                        Else
                            .COSTO_TOTAL_MN_HABER = .CANTIDAD * .COSTO_UNITARIO_MN
                            .COSTO_TOTAL_ME_HABER = .CANTIDAD * .COSTO_UNITARIO_ME
                        End If

                        .COSTO_SALDO_MN = MySaldoValorizado.COSTO_TOTAL_MN
                        .COSTO_SALDO_ME = MySaldoValorizado.COSTO_TOTAL_ME

                        If .CODIGO_SUNAT <> "11" Then
                            MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila))

                            If .CODIGO_SUNAT = "01" Then ' Salida por Ventas de cualquier tipo
                                MyKardexVentas.Rows.Add(MyKardexValorizadoDetalles(NumeroFila).OPERACION,
                                                        MyKardexValorizadoDetalles(NumeroFila).PRODUCTO,
                                                        MyKardexValorizadoDetalles(NumeroFila).COSTO_UNITARIO_MN,
                                                        MyKardexValorizadoDetalles(NumeroFila).COSTO_UNITARIO_ME)
                            End If
                        Else
                            Dim MyTransferenciaDestino As dsCostos.TRANSFERENCIAS_DESTINORow
                            Dim PrimaryKey2(2) As Object
                            PrimaryKey2(0) = .REFERENCIA_TIPO
                            PrimaryKey2(1) = .REFERENCIA_SERIE
                            PrimaryKey2(2) = .REFERENCIA_NUMERO

                            MyTransferenciaDestino = MyTransferenciasDestino.Rows.Find(PrimaryKey2)
                            If Not (MyTransferenciaDestino Is Nothing) Then
                                Dim MyAlmacen As dsCostos.TABLA_ALMACENESRow
                                Dim PrimaryKey4(0) As Object
                                PrimaryKey4(0) = MyTransferenciaDestino.ALMACEN
                                MyAlmacen = MyAlmacenes.Rows.Find(PrimaryKey4)

                                AlmacenOrigen = .ALMACEN_NOMBRE
                                AlmacenDestino = MyAlmacen.DESCRIPCION

                                MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila)) 'Guardamos el movimiento de Salida por Transferencia

                                ' Reasignar el valor de los campos para el movimiento de Ingreso por Transferencia
                                .ALMACEN = MyTransferenciaDestino.ALMACEN
                                .ALMACEN_NOMBRE = MyAlmacen.DESCRIPCION
                                .OPERACION_NOMBRE = "INGRESO POR TRANSFERENCIA"
                                .TIPO_ES = "I"

                                Dim MySaldoValorizadoTransferencia As dsCostos.SALDOS_VALORIZADOSRow
                                Dim PrimaryKey3(1) As Object
                                PrimaryKey3(0) = MyTransferenciaDestino.ALMACEN
                                PrimaryKey3(1) = .PRODUCTO
                                MySaldoValorizadoTransferencia = MySaldosValorizados.Rows.Find(PrimaryKey3)

                                .PRECIO_UNITARIO_MN = CostoUnitarioMN
                                .PRECIO_UNITARIO_ME = CostoUnitarioME

                                If Not (MySaldoValorizadoTransferencia Is Nothing) Then
                                    MySaldoValorizadoTransferencia.STOCK = MySaldoValorizadoTransferencia.STOCK + .CANTIDAD
                                    MySaldoValorizadoTransferencia.COSTO_TOTAL_MN = MySaldoValorizadoTransferencia.COSTO_TOTAL_MN + Math.Round(.CANTIDAD * CostoUnitarioMN, 5)
                                    MySaldoValorizadoTransferencia.COSTO_TOTAL_ME = MySaldoValorizadoTransferencia.COSTO_TOTAL_ME + Math.Round(.CANTIDAD * CostoUnitarioME, 5)

                                    MyKardexValorizadoDetallesFinal.Rows.Add(.EMPRESA, .EJERCICIO, .MES, .ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .OPERACION, .ALMACEN_NOMBRE, _
                                                                             .PRODUCTO_NOMBRE, .OPERACION_NOMBRE, .OPERACION_FECHA, .TIPO_ES, .CANTIDAD, .NUMERO_LOTE, _
                                                                             .FECHA_VENCIMIENTO, .COMENTARIO, .REFERENCIA_CUENTA_COMERCIAL, .REFERENCIA_TIPO, _
                                                                             .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .REFERENCIA_FECHA, .REFERENCIA_TIPO_MONEDA, .REFERENCIA_RAZON_SOCIAL, _
                                                                             .VENDEDOR, .VENDEDOR_NOMBRE, .CODIGO_SUNAT,
                                                                             .CANTIDAD, 0, MySaldoValorizadoTransferencia.STOCK, _
                                                                             .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, _
                                                                             CostoUnitarioMN, CostoUnitarioME, _
                                                                             Math.Round(.CANTIDAD * CostoUnitarioMN, 5), 0, _
                                                                             Math.Round(.CANTIDAD * CostoUnitarioME, 5), 0, _
                                                                             MySaldoValorizadoTransferencia.COSTO_TOTAL_MN, MySaldoValorizadoTransferencia.COSTO_TOTAL_ME, .POLIZA, .COMPRA, .LINEA, .ORDEN, .VENTA)
                                Else
                                    MySaldosValorizados.Rows.Add(MyTransferenciaDestino.ALMACEN, .PRODUCTO, .CODIGO_COMPRA, MyAlmacen.DESCRIPCION, .PRODUCTO_NOMBRE, .CANTIDAD, CostoUnitarioMN, CostoUnitarioME, Math.Round(.CANTIDAD * CostoUnitarioMN, 5), Math.Round(.CANTIDAD * CostoUnitarioME, 5))

                                    MyKardexValorizadoDetallesFinal.Rows.Add(.EMPRESA, .EJERCICIO, .MES, .ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .OPERACION, .ALMACEN_NOMBRE, _
                                                                             .PRODUCTO_NOMBRE, .OPERACION_NOMBRE, .OPERACION_FECHA, .TIPO_ES, .CANTIDAD, .NUMERO_LOTE, _
                                                                             .FECHA_VENCIMIENTO, .COMENTARIO, .REFERENCIA_CUENTA_COMERCIAL, .REFERENCIA_TIPO, _
                                                                             .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .REFERENCIA_FECHA, .REFERENCIA_TIPO_MONEDA, .REFERENCIA_RAZON_SOCIAL, _
                                                                             .VENDEDOR, .VENDEDOR_NOMBRE, .CODIGO_SUNAT, _
                                                                             .CANTIDAD, 0, .CANTIDAD, _
                                                                             .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, _
                                                                             CostoUnitarioMN, CostoUnitarioME, _
                                                                             Math.Round(.CANTIDAD * CostoUnitarioMN, 5), 0, _
                                                                             Math.Round(.CANTIDAD * CostoUnitarioME, 5), 0, _
                                                                             Math.Round(.CANTIDAD * CostoUnitarioMN, 5), Math.Round(.CANTIDAD * CostoUnitarioME, 5), .POLIZA, .COMPRA, .LINEA, .ORDEN, .VENTA)
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
                            End If

                            MySaldosValorizados.Rows.Add(.ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, .CANTIDAD, .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, Math.Round(.CANTIDAD * .PRECIO_UNITARIO_MN, 5), Math.Round(.CANTIDAD * .PRECIO_UNITARIO_ME, 5))

                            .CANTIDAD_SALDO = .CANTIDAD
                            .COSTO_UNITARIO_MN = .PRECIO_UNITARIO_MN
                            .COSTO_UNITARIO_ME = .PRECIO_UNITARIO_ME

                            .COSTO_TOTAL_MN_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_MN, 5)
                            .COSTO_TOTAL_ME_DEBE = Math.Round(.CANTIDAD * .COSTO_UNITARIO_ME, 5)

                            .COSTO_SALDO_MN = .COSTO_TOTAL_MN_DEBE - .COSTO_TOTAL_MN_HABER
                            .COSTO_SALDO_ME = .COSTO_TOTAL_ME_DEBE - .COSTO_TOTAL_ME_HABER

                            MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila))
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
        End If

        If MyKardexValorizadoDetallesFinal.Rows.Count <> 0 Then
            Dim MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySql As String = "TRUNCATE TABLE CON.KARDEX_VALORIZADO_ACTUAL "

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            ' creo el objeto BulkCopy
            Dim copia As New SqlBulkCopy(MySQLDbconnection)

            'abro la conexión de destino
            MySQLDbconnection.Open()

            MySQLCommand.ExecuteNonQuery()

            'le digo la tabla que va migrar
            copia.DestinationTableName = "CON.KARDEX_VALORIZADO_ACTUAL"

            'copio los datos
            copia.WriteToServer(MyKardexValorizadoDetallesFinal)

            'cierro la conexión
            MySQLDbconnection.Close()
        End If

    End Function

    Public Shared Function CalcularCostoPromedioOld(ByRef MyProgressBar As ProgressBar) As Boolean
        Dim NumeroRegistros As Long
        Dim NumeroFila As Long

        Dim CostoUnitarioMN As Decimal
        Dim CostoUnitarioME As Decimal

        Dim MyKardexValorizadoDetalles = New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable
        Dim MySaldosValorizados = New dsCostos.SALDOS_VALORIZADOSDataTable
        Dim MyOperacionesAlmacenTransferencia = New dsOperacionesAlmacen.OPERACIONES_ALMACEN_TRADataTable
        Dim MyCostoImportacion = New dsCostos.COSTO_IMPORTACIONDataTable
        Dim MyCostoOperacionesAnteriores = New dsCostos.COSTO_OPERACIONES_ANTERIORESDataTable

        Dim MyAlmacenes = New dsCostos.TABLA_ALMACENESDataTable

        Dim MyKardexValorizadoDetallesFinal = New dsCostos.KARDEX_VALORIZADO_DETALLESDataTable

        Dim AlmacenOrigen As String
        Dim AlmacenDestino As String

        MyAlmacenes = dalCostoPromedio.ObtenerAlmacenes

        MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardex(MyUsuario.empresa, MyUsuario.ejercicio)
        'MyKardexValorizadoDetalles = dalCostoPromedio.ObtenerMovimientosKardexProducto(MyUsuario.empresa, MyUsuario.ejercicio, "P0001356")

        MyOperacionesAlmacenTransferencia = dalOperacionAlmacen.ObtenerTransferencia

        If MyKardexValorizadoDetalles.Rows.Count <> 0 Then
            NumeroRegistros = MyKardexValorizadoDetalles.Rows.Count - 1

            MyProgressBar.Maximum = NumeroRegistros + 1
            MyProgressBar.Value = 0
            MyProgressBar.ForeColor = Drawing.Color.Red
            MyProgressBar.Visible = True

            Do While NumeroFila <= NumeroRegistros
                Dim MySaldoValorizado As dsCostos.SALDOS_VALORIZADOSRow
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

                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                            ElseIf .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                    .PRECIO_UNITARIO_MN = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                    .PRECIO_UNITARIO_ME = MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME

                                    MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                    MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                                Else
                                    .PRECIO_UNITARIO_MN = MySaldoValorizado.COSTO_PROMEDIO_MN
                                    .PRECIO_UNITARIO_ME = MySaldoValorizado.COSTO_PROMEDIO_ME

                                    MySaldoValorizado.COSTO_TOTAL_MN = (MySaldoValorizado.COSTO_PROMEDIO_MN) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                    MySaldoValorizado.COSTO_TOTAL_ME = (MySaldoValorizado.COSTO_PROMEDIO_ME) * (MySaldoValorizado.STOCK + .CANTIDAD)
                                End If
                            Else
                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN + .CANTIDAD * .PRECIO_UNITARIO_MN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME + .CANTIDAD * .PRECIO_UNITARIO_ME
                            End If

                            MySaldoValorizado.STOCK = MySaldoValorizado.STOCK + .CANTIDAD

                            CostoUnitarioMN = Math.Round(MySaldoValorizado.COSTO_TOTAL_MN / MySaldoValorizado.STOCK, 5)
                            CostoUnitarioME = Math.Round(MySaldoValorizado.COSTO_TOTAL_ME / MySaldoValorizado.STOCK, 5)

                            If .OPERACION_NOMBRE <> "INGRESO POR DEVOLUCION DE VENTA" Then
                                MySaldoValorizado.COSTO_PROMEDIO_MN = CostoUnitarioMN
                                MySaldoValorizado.COSTO_PROMEDIO_ME = CostoUnitarioME
                            End If

                        Else
                            If MySaldoValorizado.STOCK <> 0 Then
                                CostoUnitarioMN = Math.Round(MySaldoValorizado.COSTO_TOTAL_MN / MySaldoValorizado.STOCK, 5)
                                CostoUnitarioME = Math.Round(MySaldoValorizado.COSTO_TOTAL_ME / MySaldoValorizado.STOCK, 5)

                                MySaldoValorizado.STOCK = MySaldoValorizado.STOCK - .CANTIDAD
                                MySaldoValorizado.COSTO_TOTAL_MN = MySaldoValorizado.COSTO_TOTAL_MN - .CANTIDAD * CostoUnitarioMN
                                MySaldoValorizado.COSTO_TOTAL_ME = MySaldoValorizado.COSTO_TOTAL_ME - .CANTIDAD * CostoUnitarioME
                            End If
                        End If

                        .CANTIDAD_SALDO = MySaldoValorizado.STOCK

                        .COSTO_UNITARIO_MN = CostoUnitarioMN
                        .COSTO_UNITARIO_ME = CostoUnitarioME

                        If .TIPO_ES = "I" Then
                            If .OPERACION_NOMBRE = "INGRESO POR DEVOLUCION DE VENTA" Then
                                MyCostoOperacionesAnteriores = dalCostoPromedio.ObtenerCostoOperacionesAnteriores(.REFERENCIA_TIPO, .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .PRODUCTO)
                                If MyCostoOperacionesAnteriores.Rows.Count <> 0 Then
                                    .COSTO_TOTAL_MN_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_MN
                                    .COSTO_TOTAL_ME_DEBE = .CANTIDAD * MyCostoOperacionesAnteriores(0).COSTO_UNITARIO_ME
                                Else
                                    .COSTO_TOTAL_MN_DEBE = .CANTIDAD * CostoUnitarioMN
                                    .COSTO_TOTAL_ME_DEBE = .CANTIDAD * CostoUnitarioME
                                End If
                            Else
                                .COSTO_TOTAL_MN_DEBE = .CANTIDAD * .PRECIO_UNITARIO_MN
                                .COSTO_TOTAL_ME_DEBE = .CANTIDAD * .PRECIO_UNITARIO_ME
                            End If
                        Else
                            .COSTO_TOTAL_MN_HABER = .CANTIDAD * .COSTO_UNITARIO_MN
                            .COSTO_TOTAL_ME_HABER = .CANTIDAD * .COSTO_UNITARIO_ME
                        End If

                        .COSTO_SALDO_MN = MySaldoValorizado.COSTO_TOTAL_MN
                        .COSTO_SALDO_ME = MySaldoValorizado.COSTO_TOTAL_ME

                        If .OPERACION_NOMBRE <> "SALIDA POR TRANSFERENCIA" Then
                            MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila))
                        Else

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
                                    MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila))
                                    .ALMACEN_NOMBRE = AlmacenOrigen

                                    Dim MySaldoValorizadoTransferencia As dsCostos.SALDOS_VALORIZADOSRow
                                    Dim PrimaryKey3(1) As Object
                                    PrimaryKey3(0) = MyOperacionAlmacenTransferencia.ALMACEN_DESTINO
                                    PrimaryKey3(1) = .PRODUCTO
                                    MySaldoValorizadoTransferencia = MySaldosValorizados.Rows.Find(PrimaryKey3)

                                    .PRECIO_UNITARIO_MN = CostoUnitarioMN
                                    .PRECIO_UNITARIO_ME = CostoUnitarioME

                                    If Not (MySaldoValorizadoTransferencia Is Nothing) Then
                                        MySaldoValorizadoTransferencia.STOCK = MySaldoValorizadoTransferencia.STOCK + .CANTIDAD
                                        MySaldoValorizadoTransferencia.COSTO_TOTAL_MN = MySaldoValorizadoTransferencia.COSTO_TOTAL_MN + Math.Round(.CANTIDAD * CostoUnitarioMN, 5)
                                        MySaldoValorizadoTransferencia.COSTO_TOTAL_ME = MySaldoValorizadoTransferencia.COSTO_TOTAL_ME + Math.Round(.CANTIDAD * CostoUnitarioME, 5)

                                        MyKardexValorizadoDetallesFinal.Rows.Add(.EMPRESA, .EJERCICIO, .MES, MyOperacionAlmacenTransferencia.ALMACEN_DESTINO, .PRODUCTO, .CODIGO_COMPRA, _
                                                                                 .OPERACION, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, "INGRESO POR TRANSFERENCIA", .OPERACION_FECHA, "I", _
                                                                                 .CANTIDAD, .NUMERO_LOTE, .FECHA_VENCIMIENTO, .COMENTARIO, .REFERENCIA_CUENTA_COMERCIAL, .REFERENCIA_TIPO, _
                                                                                 .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .REFERENCIA_FECHA, .REFERENCIA_TIPO_MONEDA, .REFERENCIA_RAZON_SOCIAL, _
                                                                                 .VENDEDOR, .VENDEDOR_NOMBRE, .CODIGO_SUNAT,
                                                                                 .CANTIDAD, 0, MySaldoValorizadoTransferencia.STOCK, _
                                                                                 .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, _
                                                                                 CostoUnitarioMN, CostoUnitarioME, _
                                                                                 Math.Round(.CANTIDAD * CostoUnitarioMN, 5), 0, _
                                                                                 Math.Round(.CANTIDAD * CostoUnitarioME, 5), 0, _
                                                                                 MySaldoValorizadoTransferencia.COSTO_TOTAL_MN, MySaldoValorizadoTransferencia.COSTO_TOTAL_ME, .POLIZA, .COMPRA, .LINEA)
                                    Else
                                        MySaldosValorizados.Rows.Add(MyOperacionAlmacenTransferencia.ALMACEN_DESTINO, .PRODUCTO, .CODIGO_COMPRA, MyAlmacen.DESCRIPCION, .PRODUCTO_NOMBRE, .CANTIDAD, CostoUnitarioMN, CostoUnitarioME, Math.Round(.CANTIDAD * CostoUnitarioMN, 5), Math.Round(.CANTIDAD * CostoUnitarioME, 5))

                                        MyKardexValorizadoDetallesFinal.Rows.Add(.EMPRESA, .EJERCICIO, .MES, MyOperacionAlmacenTransferencia.ALMACEN_DESTINO, .PRODUCTO, .CODIGO_COMPRA, _
                                                                                 .OPERACION, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, "INGRESO POR TRANSFERENCIA", .OPERACION_FECHA, "I", _
                                                                                 .CANTIDAD, .NUMERO_LOTE, .FECHA_VENCIMIENTO, .COMENTARIO, .REFERENCIA_CUENTA_COMERCIAL, .REFERENCIA_TIPO, _
                                                                                 .REFERENCIA_SERIE, .REFERENCIA_NUMERO, .REFERENCIA_FECHA, .REFERENCIA_TIPO_MONEDA, .REFERENCIA_RAZON_SOCIAL, _
                                                                                 .VENDEDOR, .VENDEDOR_NOMBRE, .CODIGO_SUNAT, _
                                                                                 .CANTIDAD, 0, .CANTIDAD, _
                                                                                 .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, _
                                                                                 CostoUnitarioMN, CostoUnitarioME, _
                                                                                 Math.Round(.CANTIDAD * CostoUnitarioMN, 5), 0, _
                                                                                 Math.Round(.CANTIDAD * CostoUnitarioME, 5), 0, _
                                                                                 Math.Round(.CANTIDAD * CostoUnitarioMN, 5), Math.Round(.CANTIDAD * CostoUnitarioME, 5), .POLIZA, .COMPRA, .LINEA)
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

                            MySaldosValorizados.Rows.Add(.ALMACEN, .PRODUCTO, .CODIGO_COMPRA, .ALMACEN_NOMBRE, .PRODUCTO_NOMBRE, .CANTIDAD, .PRECIO_UNITARIO_MN, .PRECIO_UNITARIO_ME, Math.Round(.CANTIDAD * .PRECIO_UNITARIO_MN, 5), Math.Round(.CANTIDAD * .PRECIO_UNITARIO_ME, 5))

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

                            MyKardexValorizadoDetallesFinal.ImportRow(MyKardexValorizadoDetalles(NumeroFila))
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
        End If

        If MyKardexValorizadoDetallesFinal.Rows.Count <> 0 Then
            Dim MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySql As String = "TRUNCATE TABLE CON.KARDEX_VALORIZADO_ACTUAL "

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            ' creo el objeto BulkCopy
            Dim copia As New SqlBulkCopy(MySQLDbconnection)

            'abro la conexión de destino
            MySQLDbconnection.Open()

            MySQLCommand.ExecuteNonQuery()

            'le digo la tabla que va migrar
            copia.DestinationTableName = "CON.KARDEX_VALORIZADO_ACTUAL"

            'copio los datos
            copia.WriteToServer(MyKardexValorizadoDetallesFinal)

            'cierro la conexión
            MySQLDbconnection.Close()
        End If

        Return True
    End Function

    Public Shared Function ObtenerTransferenciasDestino(pEjercicio As String) As dsCostos.TRANSFERENCIAS_DESTINODataTable

        MySQL = "SELECT REFERENCIA_TIPO='GR',REFERENCIA_SERIE,REFERENCIA_NUMERO,  ALMACEN, OPERACION " &
                "FROM ALM.OPERACIONES_ALMACEN " &
                "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND TIPO_OPERACION='11' AND TIPO_ES='I' AND REFERENCIA_TIPO='09' AND ESTADO<>'N' " &
                "ORDER BY REFERENCIA_TIPO, REFERENCIA_SERIE, REFERENCIA_NUMERO "

        Dim MyDT As New dsCostos.TRANSFERENCIAS_DESTINODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
