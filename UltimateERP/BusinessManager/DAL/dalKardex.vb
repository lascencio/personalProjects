
Imports System.Data.SqlClient

Public Class dalKardex
    Private Shared MySql As String
    Private Shared MySql_2 As String
    Private Shared MySql_3 As String
    Private Shared MySql_4 As String

    Public Shared Function ObtenerMovimientosProducto(pFechaDesde As String, pFechaHasta As String, pProducto As String, pAlmacen As String) As dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTODataTable
        Dim MyDT As New dsKardexProductoAlmacen.MOVIMIENTOS_PRODUCTODataTable
        CadenaSQL = "SELECT M.EMPRESA, M.CLAVE, M.ALMACEN, M.ALMACEN_NOMBRE, M.OPERACION_ID, M.OPERACION_NOMBRE, M.OPERACION_FECHA, M.TIPO_ES, M.CODIGO_COMPRA, " & _
                    "M.PRODUCTO, M.PRODUCTO_NOMBRE, M.CANTIDAD, " & _
                    "CANTIDAD_INGRESO=CASE WHEN M.TIPO_ES='I' THEN M.CANTIDAD ELSE 0 END, " & _
                    "CANTIDAD_EGRESO=CASE WHEN M.TIPO_ES<>'I' THEN M.CANTIDAD ELSE 0 END, " & _
                    "M.PRECIO_UNITARIO_MN, M.PRECIO_UNITARIO_ME, M.NUMERO_LOTE, M.FECHA_VENCIMIENTO, " & _
                    "M.COMENTARIO, M.EJERCICIO, M.MES, M.REFERENCIA_CUENTA_COMERCIAL, ISNULL(TCP.TD, M.REFERENCIA_TIPO) AS REFERENCIA_TIPO, " & _
                    "M.REFERENCIA_SERIE, M.REFERENCIA_NUMERO, M.REFERENCIA_FECHA, M.REFERENCIA_TIPO_MONEDA, M.REFERENCIA_RAZON_SOCIAL " & _
                    "FROM ALM.MOVIMIENTOS_PRODUCTO AS M LEFT OUTER JOIN GEN.TABLA_TIPO_COMPROBANTE_PAGO AS TCP ON M.REFERENCIA_TIPO = TCP.CODIGO " & _
                    "WHERE M.EMPRESA='" & MyUsuario.empresa & "' AND M.PRODUCTO='" & pProducto & "' " & _
                    "AND (M.OPERACION_FECHA BETWEEN CONVERT(DATETIME, '" & pFechaDesde & "', 102) AND CONVERT(DATETIME, '" & pFechaHasta & "', 102)) " & _
                    IIf(pAlmacen = "TODOS", " ", "AND M.ALMACEN='" & pAlmacen & "' ") & _
                    "ORDER BY M.OPERACION_FECHA, M.CLAVE "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerStock(pPeriodo As String, pProducto As String, pAlmacen As String) As Decimal
        MySql = "SELECT ISNULL(SUM(INGRESOS-EGRESOS),0) AS STOCK " & _
                "FROM ALM.RESUMEN_X_PERIODO " & _
                "WHERE EMPRESA='" & MyUsuario.empresa & "' AND EJERCICIO+MES<'" & pPeriodo & "' AND PRODUCTO='" & pProducto & "' " & _
                IIf(pAlmacen = "TODOS", " ", "AND ALMACEN='" & pAlmacen & "' ")
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim MyStock As Decimal = MySQLCommand.ExecuteScalar

            Return MyStock
        End Using
    End Function

    Public Shared Function ObtenerStockVehicular(pEmpresa As String, pAlmacen As String, pMarca As String, pModelo As String) As dsStockAlmacen.STOCK_VEHICULARDataTable
        Dim MyDT As New dsStockAlmacen.STOCK_VEHICULARDataTable
        CadenaSQL = "SELECT V.EMPRESA, S.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, S.PRODUCTO, P.DESCRIPCION_AMPLIADA AS PRODUCTO_DESCRIPCION, " &
                    "MARCA=TPF.DESCRIPCION, MODELO=TPS.DESCRIPCION, V.NUMERO_SERIE, V.NUMERO_SERIE_CHASIS, V.COLOR, V.AÑO_FABRICACION, S.FECHA_OPERACION, " &
                    "TIPO_ADQUISICION=CASE WHEN ISNULL(OA.OPERACION,SPACE(1))=SPACE(1) THEN 'CON' ELSE (CASE WHEN ISNULL(OA.INDICA_CONSIGNACION,'SI')='SI' THEN 'CNS' ELSE 'CRE' END) END " &
                    "FROM COM.CONTROL_VEHICULOS AS V " &
                    "INNER JOIN COM.CONTROL_SERIES AS S ON V.EMPRESA=S.EMPRESA AND V.PRODUCTO=S.PRODUCTO AND V.NUMERO_SERIE=S.NUMERO_SERIE " &
                    "INNER JOIN COM.PRODUCTOS AS P ON S.EMPRESA=P.EMPRESA AND S.PRODUCTO=P.PRODUCTO " &
                    "INNER JOIN GEN.TABLA_ALMACENES AS TA ON S.EMPRESA=TA.EMPRESA AND S.ALMACEN=TA.CODIGO " &
                    "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON TPF.EMPRESA=P.EMPRESA AND TPF.CODIGO=P.PRODUCTO_FAMILIA " &
                    "INNER JOIN GEN.TABLA_PRODUCTO_SUB_FAMILIA AS TPS ON TPS.EMPRESA=P.EMPRESA AND TPS.CODIGO=P.PRODUCTO_SUB_FAMILIA " &
                    "LEFT OUTER JOIN ALM.OPERACIONES_ALMACEN_COM AS OA ON S.EMPRESA=OA.EMPRESA AND  S.REFERENCIA_OPERACION=OA.OPERACION " &
                    "WHERE V.EMPRESA='" & pEmpresa & "' AND S.ESTADO='D' " &
                    IIf(pAlmacen = "TODOS", "", "AND S.ALMACEN='" & pAlmacen & "' ") &
                    IIf(pMarca = "TODOS", "", "AND P.PRODUCTO_FAMILIA='" & pMarca & "' ") &
                    IIf(pModelo = "TODOS", "", "AND P.PRODUCTO_SUB_FAMILIA='" & pModelo & "' ") &
                    "ORDER BY P.DESCRIPCION_AMPLIADA "

        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerStockVehicular(pEmpresa As String, pAlmacen As String, pProducto As String) As dsStockAlmacen.STOCK_VEHICULARDataTable
        Dim MyDT As New dsStockAlmacen.STOCK_VEHICULARDataTable
        CadenaSQL = "SELECT V.EMPRESA, S.ALMACEN, TA.DESCRIPCION AS ALMACEN_DESCRIPCION, S.PRODUCTO, P.DESCRIPCION_AMPLIADA AS PRODUCTO_DESCRIPCION, " &
                    "V.MARCA, V.MODELO, V.NUMERO_SERIE, V.NUMERO_SERIE_CHASIS, V.COLOR, V.AÑO_FABRICACION, S.FECHA_OPERACION, " &
                    "TIPO_ADQUISICION=CASE WHEN ISNULL(OA.OPERACION,SPACE(1))=SPACE(1) THEN 'CON' ELSE (CASE WHEN ISNULL(OA.INDICA_CONSIGNACION,'SI')='SI' THEN 'CNS' ELSE 'CRE' END) END " &
                    "FROM COM.CONTROL_VEHICULOS AS V " &
                    "INNER JOIN COM.CONTROL_SERIES AS S ON V.EMPRESA=S.EMPRESA AND V.PRODUCTO=S.PRODUCTO AND V.NUMERO_SERIE=S.NUMERO_SERIE " &
                    "INNER JOIN COM.PRODUCTOS AS P ON S.EMPRESA=P.EMPRESA AND S.PRODUCTO=P.PRODUCTO " &
                    "INNER JOIN GEN.TABLA_ALMACENES AS TA ON S.EMPRESA=TA.EMPRESA AND S.ALMACEN=TA.CODIGO " &
                    "LEFT OUTER JOIN ALM.OPERACIONES_ALMACEN_COM AS OA ON S.EMPRESA=OA.EMPRESA AND  S.REFERENCIA_OPERACION=OA.OPERACION " &
                    "WHERE V.EMPRESA='" & pEmpresa & "' AND S.ESTADO='D' AND V.PRODUCTO='" & pProducto & "' " &
                    IIf(pAlmacen = "TODOS", "", "AND S.ALMACEN='" & pAlmacen & "' ") &
                    "ORDER BY P.DESCRIPCION_AMPLIADA "

        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function


End Class
