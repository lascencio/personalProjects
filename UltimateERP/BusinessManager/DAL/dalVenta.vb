Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalVenta
    Private Shared MyOleDBString As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String
    Private Shared MySQLCommand As SqlCommand

    Private Shared MySQL_2 As String
    Private Shared MySQL_3 As String
    Private Shared MySQL_4 As String

    Private Shared ConsultaComprobantesInforme As String = "SELECT H.EMPRESA, H.VENTA, H.EJERCICIO, H.MES, H.TIPO_OPERACION, " &
        "TIPO_OPERACION_DESCRIPCION=CASE WHEN H.CONDICION_PAGO='TG' THEN 'TRANSFERENCIA GRATUITA' ELSE TTV.DESCRIPCION END, " &
        "H.ORDEN_PEDIDO, H.CUENTA_COMERCIAL, CC.RAZON_SOCIAL, " &
        "LEFT(H.TIPO_OPERACION, 1) + '/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO AS NRO_COMPROBANTE, H.COMPROBANTE_FECHA, H.COMPROBANTE_VENCIMIENTO, H.TIPO_MONEDA, " &
        "H.TIPO_CAMBIO, " &
        "VALOR_VENTA_ORIGEN=CASE WHEN H.ESTADO='N' THEN 0 ELSE H.BASE_IMPONIBLE_GRAVADA_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END," &
        "IMPUESTO_ORIGEN=CASE WHEN H.ESTADO='N' THEN 0 ELSE H.IGV_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "PRECIO_VENTA_ORIGEN=CASE WHEN H.ESTADO='N' THEN 0 ELSE H.IMPORTE_TOTAL_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "VALOR_VENTA_MN=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='1' THEN H.BASE_IMPONIBLE_GRAVADA_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "IMPUESTO_MN=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='1' THEN H.IGV_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "PRECIO_VENTA_MN=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='1' THEN H.IMPORTE_TOTAL_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "VALOR_VENTA_ME=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='2' THEN H.BASE_IMPONIBLE_GRAVADA_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "IMPUESTO_ME=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='2' THEN H.IGV_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "PRECIO_VENTA_ME=CASE WHEN H.ESTADO='N' THEN 0 ELSE (CASE WHEN H.TIPO_MONEDA='2' THEN H.IMPORTE_TOTAL_ORIGEN ELSE 0 END)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END) END, " &
        "0 AS IMPORTE_TOTAL_MN, 0 AS IMPORTE_TOTAL_ME, H.GUIA_REMITENTE AS GUIA, ISNULL(LEFT(G.TIPO_OPERACION, 1) + '/' + G.COMPROBANTE_SERIE + '-' + G.COMPROBANTE_NUMERO, SPACE(1)) AS NRO_GUIA," &
        "COMENTARIO=CASE WHEN H.COMPROBANTE_TIPO='07' THEN (CASE WHEN H.ESTADO='N' THEN 'ANULADO' ELSE (CASE WHEN H.IMPORTE_SALDO=0 THEN 'APLICADO' ELSE 'PENDIENTE' END) END) ELSE H.COMENTARIO END," &
        "TVD.INICIALES AS VENDEDOR, H.ESTADO " &
        "FROM COM.VENTAS AS H INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " &
        "INNER JOIN GEN.TABLA_TIPO_VENTA AS TTV ON H.EMPRESA = TTV.EMPRESA AND H.TIPO_OPERACION = TTV.CODIGO " &
        "INNER JOIN GEN.TABLA_VENDEDORES AS TVD ON H.EMPRESA=TVD.EMPRESA AND H.CODIGO_VENDEDOR=TVD.CODIGO " &
        "LEFT OUTER JOIN COM.GUIAS AS G ON H.EMPRESA = G.EMPRESA AND H.GUIA_REMITENTE = G.GUIA  "

    Public Shared Function ObtenerDatosRUC(ByVal pCuentaComercial As String) As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
        MyStoreProcedure = "GEN.CONSULTAR_DATOS_RUC_NV"
        Dim MyParameter_1 As New SqlParameter("@RUC", SqlDbType.Char, 11) : MyParameter_1.Value = pCuentaComercial

        Dim MyDT As New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Consulta_RUC)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerCorrelativo(ByVal pTipoComprobante As String, ByVal pSerieComprobante As String, pIndicaGuia As String) As dsCorrelativo.CORRELATIVODataTable
        MyStoreProcedure = "COM.CORRELATIVO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_2.Value = pTipoComprobante
        Dim MyParameter_3 As New SqlParameter("@COMPROBANTE_SERIE", SqlDbType.Char, 4) : MyParameter_3.Value = pSerieComprobante
        Dim MyParameter_4 As New SqlParameter("@INDICA_GUIA", SqlDbType.Char, 2) : MyParameter_4.Value = pIndicaGuia

        Dim MyDT As New dsCorrelativo.CORRELATIVODataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
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

    Public Shared Function Obtener(ByVal pVenta As String) As entVenta
        If Existe(pVenta) Then
            CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & MyEmpresa & "' AND VENTA='" & pVenta & "'"
            Return Obtener(New entVenta, CadenaSQL)
        Else
            Return New entVenta
        End If
    End Function

    Public Shared Function Obtener(ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As entVenta
        If Existe(pTipo, pSerie, pNumero) Then
            CadenaSQL = "SELECT * FROM COM.VENTAS " & _
                        "WHERE EMPRESA='" & MyUsuario.empresa & "' AND " & _
                        "COMPROBANTE_TIPO='" & pTipo & "' AND " & _
                        "COMPROBANTE_SERIE='" & pSerie & "' AND " & _
                        "COMPROBANTE_NUMERO='" & pNumero & "' "
            Return Obtener(New entVenta, CadenaSQL)
        Else
            Return New entVenta
        End If
    End Function

    Private Shared Function Existe(ByVal pVenta As String) As Boolean
        If Not String.IsNullOrEmpty(pVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.VENTAS WHERE Empresa=@vEmpresa AND Venta=@vVenta"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As Boolean
        If Not String.IsNullOrEmpty(pNumero) Then
            MySQLString = "SELECT COUNT(*) FROM COM.VENTAS " & _
                          "WHERE EMPRESA=@vEmpresa AND " & _
                          "COMPROBANTE_TIPO=@vComprobante_tipo AND " & _
                          "COMPROBANTE_SERIE=@vComprobante_serie AND " & _
                          "COMPROBANTE_NUMERO=@vComprobante_numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", pTipo)
                MySQLCommand.Parameters.AddWithValue("vComprobante_serie", pSerie)
                MySQLCommand.Parameters.AddWithValue("vComprobante_numero", pNumero)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function ExisteReferencia(ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As Boolean
        If Not String.IsNullOrEmpty(pNumero) Then
            MySQLString = "SELECT COUNT(*) FROM COM.VENTAS " & _
                          "WHERE EMPRESA=@vEmpresa AND " & _
                          "REFERENCIA_TIPO=@vReferencia_tipo AND " & _
                          "REFERENCIA_SERIE=@vReferencia_serie AND " & _
                          "REFERENCIA_NUMERO=@vReferencia_numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vReferencia_tipo", pTipo)
                MySQLCommand.Parameters.AddWithValue("vReferencia_serie", pSerie)
                MySQLCommand.Parameters.AddWithValue("vReferencia_numero", pNumero)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Obtener(ByVal cVenta As entVenta, ByVal MySQLString As String) As entVenta
        Dim MyDT As New dsVentas.VENTASDataTable
        Call ObtenerDataTableSQL(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cVenta
                .empresa = MyDT(0).EMPRESA
                .venta = MyDT(0).VENTA
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .asiento_tipo = MyDT(0).ASIENTO_TIPO
                .asiento_numero = MyDT(0).ASIENTO_NUMERO
                .asiento_fecha = MyDT(0).ASIENTO_FECHA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .comprobante_tipo = MyDT(0).COMPROBANTE_TIPO
                .comprobante_serie = MyDT(0).COMPROBANTE_SERIE
                .comprobante_numero = MyDT(0).COMPROBANTE_NUMERO
                .comprobante_fecha = MyDT(0).COMPROBANTE_FECHA
                .comprobante_vencimiento = MyDT(0).COMPROBANTE_VENCIMIENTO
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .almacen = MyDT(0).ALMACEN
                .lista_precio = MyDT(0).LISTA_PRECIO
                .centro_distribucion = MyDT(0).CENTRO_DISTRIBUCION
                .codigo_domicilio = MyDT(0).CODIGO_DOMICILIO
                .valor_exportacion_origen = MyDT(0).VALOR_EXPORTACION_ORIGEN
                .base_imponible_gravada_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA_ORIGEN
                .importe_exonerado_origen = MyDT(0).importe_exonerado_ORIGEN
                .importe_inafecto_origen = MyDT(0).importe_inafecto_ORIGEN
                .isc_origen = MyDT(0).ISC_ORIGEN
                .igv_origen = MyDT(0).IGV_ORIGEN
                .ipm_origen = MyDT(0).IPM_ORIGEN
                .base_imponible_gravada2_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ORIGEN
                .igv2_origen = MyDT(0).IGV2_ORIGEN
                .otros_tributos_origen = MyDT(0).OTROS_TRIBUTOS_ORIGEN
                .importe_total_origen = MyDT(0).IMPORTE_TOTAL_ORIGEN
                .valor_exportacion_mn = MyDT(0).VALOR_EXPORTACION_MN
                .base_imponible_gravada_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA_MN
                .importe_exonerado_mn = MyDT(0).importe_exonerado_MN
                .importe_inafecto_mn = MyDT(0).importe_inafecto_MN
                .isc_mn = MyDT(0).ISC_MN
                .igv_mn = MyDT(0).IGV_MN
                .ipm_mn = MyDT(0).IPM_MN
                .base_imponible_gravada2_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA2_MN
                .igv2_mn = MyDT(0).IGV2_MN
                .otros_tributos_mn = MyDT(0).OTROS_TRIBUTOS_MN
                .importe_total_mn = MyDT(0).IMPORTE_TOTAL_MN
                .valor_exportacion_me = MyDT(0).VALOR_EXPORTACION_ME
                .base_imponible_gravada_me = MyDT(0).BASE_IMPONIBLE_GRAVADA_ME
                .importe_exonerado_me = MyDT(0).importe_exonerado_ME
                .importe_inafecto_me = MyDT(0).importe_inafecto_ME
                .isc_me = MyDT(0).ISC_ME
                .igv_me = MyDT(0).IGV_ME
                .ipm_me = MyDT(0).IPM_ME
                .base_imponible_gravada2_me = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ME
                .igv2_me = MyDT(0).IGV2_ME
                .otros_tributos_me = MyDT(0).OTROS_TRIBUTOS_ME
                .importe_total_me = MyDT(0).IMPORTE_TOTAL_ME
                .referencia_cuo = MyDT(0).REFERENCIA_CUO
                .condicion_pago = MyDT(0).CONDICION_PAGO
                .forma_pago = MyDT(0).FORMA_PAGO
                .fecha_ultimo_pago = MyDT(0).FECHA_ULTIMO_PAGO
                .importe_saldo = MyDT(0).IMPORTE_SALDO
                .comentario = MyDT(0).COMENTARIO
                .tipo_operacion = MyDT(0).TIPO_OPERACION
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_cobrador = MyDT(0).CODIGO_COBRADOR
                .centro_costo = MyDT(0).CENTRO_COSTO
                .letra = MyDT(0).LETRA
                .factoring = MyDT(0).FACTORING
                .planilla_cobranza = MyDT(0).PLANILLA_COBRANZA
                .guia_remitente = MyDT(0).GUIA_REMITENTE
                .guia_transportista = MyDT(0).GUIA_TRANSPORTISTA
                .orden_pedido = MyDT(0).ORDEN_PEDIDO
                .usuario_envio = MyDT(0).USUARIO_ENVIO
                If Not MyDT(0).IsNull("FECHA_ENVIO") Then .fecha_envio = MyDT(0).FECHA_ENVIO
                .estado_envio = MyDT(0).ESTADO_ENVIO
                If Not MyDT(0).IsNull("FECHA_RECEPCION") Then .fecha_recepcion = MyDT(0).FECHA_RECEPCION
                .indica_sujeta_detraccion = MyDT(0).INDICA_SUJETA_DETRACCION
                .porcentaje_detraccion = MyDT(0).PORCENTAJE_DETRACCION
                .numero_detraccion = MyDT(0).NUMERO_DETRACCION
                If Not MyDT(0).IsNull("FECHA_DETRACCION") Then .fecha_detraccion = MyDT(0).FECHA_DETRACCION
                .origen = MyDT(0).ORIGEN
                .estado = MyDT(0).ESTADO
                .ubicacion_custodia = MyDT(0).UBICACION_CUSTODIA
                .usuario_custodia = MyDT(0).USUARIO_CUSTODIA
                If Not MyDT(0).IsNull("FECHA_CUSTODIA") Then .fecha_custodia = MyDT(0).FECHA_CUSTODIA
                .referencia_tipo = MyDT(0).REFERENCIA_TIPO
                .referencia_serie = MyDT(0).REFERENCIA_SERIE
                .referencia_numero = MyDT(0).REFERENCIA_NUMERO
                .referencia_fecha = MyDT(0).REFERENCIA_FECHA
                .indica_impreso = MyDT(0).INDICA_IMPRESO
                .indica_exportacion = MyDT(0).INDICA_EXPORTACION
                .indica_migrado = MyDT(0).INDICA_MIGRADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cVenta
    End Function

    Public Shared Function ObtenerDetalles(pEmpresa As String, pVenta As String) As dsVentas.VENTA_DETDataTable
        MySQLString = "SELECT D.LINEA, D.PRODUCTO, ISNULL(DS.DESCRIPCION,P.DESCRIPCION_AMPLIADA) AS DESCRIPCION_AMPLIADA, D.PRECIO_UNITARIO, D.CANTIDAD, " &
                      "D.IMPORTE_TOTAL_ORIGEN AS IMPORTE_TOTAL, P.INDICA_SERIE, 'NO' AS EXISTE_RESUMEN_ALMACEN, 'NO' AS EXISTE_RESUMEN_PERIODO, P.INDICA_COMPUESTO " &
                      "FROM COM.VENTAS_PRO AS D INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " &
                      "LEFT OUTER JOIN COM.VENTAS_SER AS DS ON D.EMPRESA=DS.EMPRESA AND D.VENTA=DS.VENTA AND D.LINEA=DS.LINEA " &
                      "WHERE D.EMPRESA=@vEmpresa AND D.VENTA=@vVenta "

        Dim MyDT As New dsVentas.VENTA_DETDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetalles(pEmpresa As String, pTipo As String, pSerie As String, pNumero As String) As dsVentas.VENTA_DETDataTable
        MySQLString = "SELECT D.LINEA, D.PRODUCTO, P.DESCRIPCION_AMPLIADA, D.PRECIO_UNITARIO, D.CANTIDAD, D.IMPORTE_TOTAL_ORIGEN AS IMPORTE_TOTAL, " &
                      "P.INDICA_SERIE, 'NO' AS EXISTE_RESUMEN_ALMACEN, 'NO' AS EXISTE_RESUMEN_PERIODO, P.INDICA_COMPUESTO " &
                      "FROM COM.VENTAS AS H INNER JOIN COM.VENTAS_PRO AS D ON H.EMPRESA=D.EMPRESA AND H.VENTA=D.VENTA " &
                                           "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " &
                      "WHERE H.EMPRESA=@vEmpresa AND H.COMPROBANTE_TIPO=@vTipo AND H.COMPROBANTE_SERIE=@vSerie AND H.COMPROBANTE_NUMERO=@vNumero "

        Dim MyDT As New dsVentas.VENTA_DETDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vTipo", pTipo)
            MySQLCommand.Parameters.AddWithValue("vSerie", pSerie)
            MySQLCommand.Parameters.AddWithValue("vNumero", pNumero)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetalleSeries(pEmpresa As String, pVenta As String) As dsVentas.VENTA_DET_SERIESDataTable
        MySQLString = "SELECT EMPRESA, VENTA, PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR, ESTADO, EXISTE_CONTROL_SERIES='NO' " & _
                      "FROM COM.VENTAS_SERIES WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

        Dim MyDT As New dsVentas.VENTA_DET_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function VentasPorConsultar(ByVal pEjercicio As String, ByVal pMes As String, ByVal pVendedor As String, ByVal pCriterio1 As String, ByVal pCriterio2 As String, ByVal pCriterio3 As String, ByVal pCriterio4 As String) As dsVentas.VENTAS_LISTADataTable
        Dim nCriterio1 As String = Nothing
        Dim nCriterio2 As String = Nothing
        Dim nCriterio3 As String = Nothing
        Dim nCriterio4 As String = Nothing

        Select Case pCriterio1
            Case Is = "PERIODO"
                nCriterio1 = Space(1)
            Case Is = "FINANCIADO"
                nCriterio1 = "AND C.CONDICION_PAGO='FD' "
            Case Is = "VENDEDOR"
                If pVendedor.Trim.Length <> 0 Then
                    nCriterio1 = "AND C.CODIGO_VENDEDOR=@vCodigo_vendedor "
                Else
                    nCriterio1 = Space(1)
                End If
        End Select

        Select Case pCriterio2
            Case Is = "TODOS"
                nCriterio2 = Space(1)
            Case Is = "ANULADAS"
                nCriterio2 = "AND C.ESTADO='N' "
            Case Is = "NO ANULADAS"
                nCriterio2 = "AND C.ESTADO<>'N' "
            Case Else
                nCriterio2 = "AND C.ESTADO='" & pCriterio2 & "' "
        End Select

        Select Case pCriterio3
            Case Is = "BOLETA DE VENTA"
                nCriterio3 = "AND C.COMPROBANTE_TIPO='03' "
            Case Is = "FACTURA"
                nCriterio3 = "AND C.COMPROBANTE_TIPO='01' "
            Case Is = "X" 'FINANCIADO
                nCriterio3 = "AND C.COMPROBANTE_TIPO<>'07' AND C.INDICA_FINANCIADO='NO' "
            Case Else
                nCriterio3 = "AND TIPO_OPERACION='" & pCriterio3 & "' "
        End Select

        Select Case pCriterio4
            Case Is = "SI"
                nCriterio4 = "AND C.GUIA_REMITENTE<>'000000000000' "
            Case Is = "NO"
                nCriterio4 = "AND C.GUIA_REMITENTE='000000000000' "
            Case Else
                nCriterio4 = Space(1)
        End Select

        MySQLString = "SELECT C.VENTA,C.COMPROBANTE_FECHA,C.COMPROBANTE_SERIE,C.COMPROBANTE_NUMERO,RTRIM(CC.RAZON_SOCIAL) AS RAZON_SOCIAL," & _
                      "C.CODIGO_VENDEDOR AS VENDEDOR,ISNULL(V.DESCRIPCION,SPACE(1)) AS VENDEDOR_NOMBRE,M.TEXTO_01 AS MONEDA," & _
                      "C.BASE_IMPONIBLE_GRAVADA_ORIGEN,C.IGV_ORIGEN,C.IMPORTE_TOTAL_ORIGEN,C.ESTADO " & _
                      "FROM COM.VENTAS AS C INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON C.EMPRESA = CC.EMPRESA AND C.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                           "INNER JOIN GEN.TABLA_VENDEDORES AS V ON C.CODIGO_VENDEDOR = V.CODIGO " & _
                                           "INNER JOIN GEN.TABLAS_DETALLE AS M ON M.EMPRESA='000' AND M.CODIGO_TABLA = '_TIPO_MONEDA' AND C.TIPO_MONEDA = M.CODIGO_ITEM " & _
                      "WHERE C.EMPRESA=@vEmpresa AND C.EJERCICIO=@vEjercicio AND C.MES=@vMes AND C.ALMACEN=@vAlmacen " & _
                      nCriterio1 & nCriterio2 & nCriterio3 & nCriterio4 & _
                      "ORDER BY C.VENTA DESC "

        Dim MyDT As New dsVentas.VENTAS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)
            If pVendedor.Trim.Length <> 0 Then MySQLCommand.Parameters.AddWithValue("vCodigo_vendedor", pVendedor)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Private Shared Function AsignarVenta() As String
        MySQLString = "SELECT ISNULL(MAX(VENTA),'') AS NUEVO_CODIGO FROM COM.VENTAS WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "V00000000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 11)) + 1
                NewCode = "V" & Right("00000000000" & Correlativo.ToString, 11)
            End If
            Return NewCode
        End Using
    End Function

    Private Shared Function AsignarSeparacion() As String
        MySQLString = "SELECT ISNULL(MAX(SEPARACION),'') AS NUEVO_CODIGO FROM COM.SEPARACION WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "S00000000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 11)) + 1
                NewCode = "S" & Right("00000000000" & Correlativo.ToString, 11)
            End If
            Return NewCode
        End Using
    End Function

    Public Shared Function AsignarCorrelativo(ByVal TipoComprobante As String, ByVal SerieComprobante As String, EsGuia As String) As String
        Dim MyCorrelativo As New dsCorrelativo.CORRELATIVODataTable
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_2.Value = TipoComprobante
        Dim MyParameter_3 As New SqlParameter("@COMPROBANTE_SERIE", SqlDbType.Char, 4) : MyParameter_3.Value = SerieComprobante
        Dim MyParameter_4 As New SqlParameter("@INDICA_GUIA", SqlDbType.Char, 2) : MyParameter_4.Value = EsGuia
        Dim NumeroCorrelativo As String
        Dim Correlativo As Long

        MyStoreProcedure = "COM.CORRELATIVO"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            MySQLCommand.Parameters.Add(MyParameter_4)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyCorrelativo)
        End Using

        If MyCorrelativo.Rows.Count = 0 Then
            NumeroCorrelativo = "0000000001"
        Else
            Correlativo = CLng(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1
            NumeroCorrelativo = Strings.Right("0000000000" & Correlativo.ToString, 10)
        End If

        Return NumeroCorrelativo
    End Function

    Private Shared Function AsignarNumeroAsiento(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsientoTipo As String) As String
        MySQLString = "SELECT ISNULL(MAX(ASIENTO_NUMERO),'') AS NUEVO_NUMERO " & _
                      "FROM COM.VENTAS " & _
                      "WHERE EMPRESA='" & MyUsuario.empresa & "' AND EJERCICIO='" & pEjercicio & "' AND MES='" & pMes & "' AND ASIENTO_TIPO='" & pAsientoTipo & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "00001"
            Else
                Correlativo = CLng(NewCode) + 1
                NewCode = Strings.Right("00000" & Correlativo.ToString, 5)
            End If
            Return NewCode
        End Using
    End Function

    Public Shared Function ObtenerComprobante(ByVal pVenta As String) As dsVentas.COMPROBANTEDataTable
        MySQLString = "SELECT V.EMPRESA, V.VENTA, V.COMPROBANTE_SERIE + '-' + V.COMPROBANTE_NUMERO AS COMPROBANTE, V.COMPROBANTE_FECHA, " & _
                      "CASE WHEN V.COMPROBANTE_TIPO IN ('07','08') THEN V.REFERENCIA_FECHA ELSE V.COMPROBANTE_VENCIMIENTO END AS COMPROBANTE_VENCIMIENTO, " & _
                      "CONDICIONES_PAGO=CASE WHEN V.CONDICION_PAGO='FD' THEN 'CONTADO CONTRA ENTREGA' ELSE TCP.DESCRIPCION END, " & _
                      "V.COMENTARIO, CC.RAZON_SOCIAL, CC.NRO_DOCUMENTO, DOM.DIRECCION, DOM.REFERENCIA, " & _
                      "CASE WHEN V.COMPROBANTE_TIPO IN ('07','08') THEN V.REFERENCIA_SERIE + '-' + V.REFERENCIA_NUMERO ELSE ISNULL(G.COMPROBANTE_SERIE + '-' + G.COMPROBANTE_NUMERO, SPACE(1)) END AS GUIA, V.TIPO_CAMBIO, V.TIPO_MONEDA, " & _
                      "V.BASE_IMPONIBLE_GRAVADA_ORIGEN AS VALOR_VENTA, IGV_ORIGEN AS IMPUESTO, IMPORTE_TOTAL_ORIGEN AS PRECIO_VENTA " & _
                      "FROM COM.VENTAS AS V INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON V.EMPRESA = CC.EMPRESA AND V.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                           "INNER JOIN GEN.TABLA_CONDICIONES_PAGO AS TCP ON V.CONDICION_PAGO = TCP.CODIGO " & _
                                           "INNER JOIN COM.DIRECCION_ENVIO AS DOM ON V.EMPRESA = DOM.EMPRESA AND V.CUENTA_COMERCIAL = DOM.CUENTA_COMERCIAL AND DOM.DOMICILIO_ENVIO='01' " & _
                                      "LEFT OUTER JOIN COM.GUIAS AS G ON V.EMPRESA = G.EMPRESA AND V.GUIA_REMITENTE = G.GUIA  " & _
                "WHERE V.EMPRESA=@vEmpresa AND V.VENTA= @vVenta "

        Dim MyDT As New dsVentas.COMPROBANTEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function VentaDetalladaNC(ByVal pVenta As String) As dsVentas.VENTA_DETALLADataTable
        MySQLString = "SELECT H.EMPRESA, H.VENTA, H.GUIA_REMITENTE AS GUIA, H.CUENTA_COMERCIAL, CC.RAZON_SOCIAL,  NRO_COMPROBANTE=LEFT(H.TIPO_OPERACION, 1) + '/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO, " & _
                      "H.COMPROBANTE_FECHA, H.TIPO_MONEDA, H.TIPO_CAMBIO, '001' AS LINEA, SPACE(1) AS PRODUCTO, H.COMENTARIO AS DESCRIPCION, CANTIDAD=1, PRECIO_UNITARIO=H.IMPORTE_TOTAL_ORIGEN, " & _
                      "VALOR_VENTA=H.BASE_IMPONIBLE_GRAVADA_ORIGEN, IMPUESTO=H.IMPORTE_TOTAL_ORIGEN-H.BASE_IMPONIBLE_GRAVADA_ORIGEN, PRECIO_VENTA=H.IMPORTE_TOTAL_ORIGEN, " & _
                      "NRO_GUIA=SPACE(1), SPACE(1) AS CODIGO_COMPRA, INDICA_SERIE='NO', PRODUCTO_FAMILIA='ND', SPACE(1) AS FAMILIA, PRODUCTO_TIPO='ND', SPACE(1) AS TIPO " & _
                      "FROM  COM.VENTAS AS H INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                            "INNER JOIN GEN.TABLA_TIPO_VENTA AS TTV ON H.EMPRESA = TTV.EMPRESA AND H.TIPO_OPERACION = TTV.CODIGO " & _
                      "WHERE H.EMPRESA=@vEmpresa AND H.VENTA='" & pVenta & "' "

        Dim MyDT As New dsVentas.VENTA_DETALLADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function VentaDetallada(ByVal pVenta As String) As dsVentas.VENTA_DETALLADataTable
        MySQLString = "SELECT H.EMPRESA, H.VENTA, H.GUIA_REMITENTE AS GUIA, H.CUENTA_COMERCIAL, CC.RAZON_SOCIAL,  NRO_COMPROBANTE=LEFT(H.TIPO_OPERACION, 1) + '/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO, H.COMPROBANTE_FECHA, " &
                      "H.TIPO_MONEDA, H.TIPO_CAMBIO, D.LINEA, D.PRODUCTO, " &
                      "DESCRIPCION=ISNULL(DS.DESCRIPCION,P.DESCRIPCION_AMPLIADA), D.CANTIDAD, D.PRECIO_UNITARIO,  " &
                      "VALOR_VENTA=CASE WHEN H.BASE_IMPONIBLE_GRAVADA_ORIGEN=0 THEN 0 ELSE ROUND(D.IMPORTE_TOTAL_ORIGEN/(H.IMPORTE_TOTAL_ORIGEN/H.BASE_IMPONIBLE_GRAVADA_ORIGEN),2) END, " &
                      "IMPUESTO=CASE WHEN H.BASE_IMPONIBLE_GRAVADA_ORIGEN=0 THEN 0 ELSE D.IMPORTE_TOTAL_ORIGEN-(ROUND(D.IMPORTE_TOTAL_ORIGEN/(H.IMPORTE_TOTAL_ORIGEN/H.BASE_IMPONIBLE_GRAVADA_ORIGEN),2)) END, " &
                      "PRECIO_VENTA=D.IMPORTE_TOTAL_ORIGEN, " &
                      "NRO_GUIA=ISNULL(LEFT(G.TIPO_OPERACION, 1) + '/' + G.COMPROBANTE_SERIE + '-' + G.COMPROBANTE_NUMERO, SPACE(1)), P.CODIGO_COMPRA, " &
                      "P.INDICA_SERIE, P.PRODUCTO_FAMILIA, TPF.DESCRIPCION AS FAMILIA, P.PRODUCTO_TIPO, TPT.DESCRIPCION AS TIPO " &
                      "FROM  COM.VENTAS AS H INNER JOIN COM.VENTAS_PRO AS D ON H.EMPRESA = D.EMPRESA AND H.VENTA = D.VENTA " &
                                            "LEFT OUTER JOIN COM.VENTAS_SER AS DS ON D.EMPRESA=DS.EMPRESA AND D.VENTA=DS.VENTA AND D.LINEA=DS.LINEA " &
                                            "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " &
                                            "INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " &
                                            "INNER JOIN GEN.TABLA_TIPO_VENTA AS TTV ON H.EMPRESA = TTV.EMPRESA AND H.TIPO_OPERACION = TTV.CODIGO " &
                                            "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON H.EMPRESA = TPF.EMPRESA AND P.PRODUCTO_FAMILIA = TPF.CODIGO " &
                                            "INNER JOIN GEN.TABLA_PRODUCTO_TIPO AS TPT ON H.EMPRESA = TPT.EMPRESA AND P.PRODUCTO_TIPO = TPT.CODIGO " &
                                       "LEFT OUTER JOIN COM.GUIAS AS G ON H.EMPRESA = G.EMPRESA AND H.GUIA_REMITENTE = G.GUIA " &
                      "WHERE H.EMPRESA=@vEmpresa AND H.VENTA='" & pVenta & "' "

        Dim MyDT As New dsVentas.VENTA_DETALLADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerNotaCreditoSeries(ByVal pVenta As String) As dsVentas.COMPROBANTE_SERIESDataTable
        MySQLString = "SELECT PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR " & _
                      "FROM COM.VENTAS_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND VENTA= @vVenta "

        Dim MyDT As New dsVentas.COMPROBANTE_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobanteSeries(ByVal pGuia As String) As dsVentas.COMPROBANTE_SERIESDataTable
        MySQLString = "SELECT PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR " & _
                      "FROM COM.GUIAS_DET_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND GUIA= @vGuia "

        Dim MyDT As New dsVentas.COMPROBANTE_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vGuia", pGuia)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobanteSeriesVentaDirecta(ByVal pVenta As String) As dsVentas.COMPROBANTE_SERIESDataTable
        MySQLString = "SELECT PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR " & _
                      "FROM COM.VENTAS_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND VENTA= @vVenta "

        Dim MyDT As New dsVentas.COMPROBANTE_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarEComprobantes(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String, ByVal pComprobanteTipo As String) As dsEComprobantes.ECOMPROBANTES_LISTADataTable
        MyStoreProcedure = "COM.ECOMPROBANTES_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.VarChar, 18) : MyParameter_4.Value = pCuentaComercial
        Dim MyParameter_5 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_5.Value = pComprobanteTipo

        Dim MyDT As New dsEComprobantes.ECOMPROBANTES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
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

    Public Shared Function BuscarEComprobantesDia(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, pDia As Integer) As dsEComprobantes.ECOMPROBANTES_LISTADataTable
        MyStoreProcedure = "COM.ECOMPROBANTES_LISTA_DIA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@DIA", SqlDbType.Int) : MyParameter_4.Value = pDia

        Dim MyDT As New dsEComprobantes.ECOMPROBANTES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MyStoreProcedure, MySQLDbconnection)
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

    Public Shared Function ActualizarEstadoEnvio(ByVal pEmpresa As String, ByVal pVenta As String, pEstado As String) As Boolean

        MySQLString = "UPDATE COM.VENTAS SET " & _
                      "Usuario_envio=@vUsuario_envio,Fecha_envio=GETDATE(), Estado_envio=@vEstado " & _
                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEstado", pEstado)
                .AddWithValue("vUsuario_envio", MyUsuario.usuario)
                .AddWithValue("vEmpresa", pEmpresa)
                .AddWithValue("vVenta", pVenta)
            End With

            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()
                Return True
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function ObtenerVentasGuias(ByVal cEmpresa As String, ByVal cEjErcicio As String, ByVal cMes As String, cIndicaSinGuia As Boolean, cEsVehicular As Boolean) As dsVentas.VENTAS_GUIASDataTable
        Dim MyDT As New dsVentas.VENTAS_GUIASDataTable
        CadenaSQL = "SELECT V.VENTA, V.COMPROBANTE_FECHA AS FECHA, COMPROBANTE=CASE WHEN V.COMPROBANTE_TIPO='01' THEN 'FT/' ELSE 'BV/' END+V.COMPROBANTE_SERIE+'-'+V.COMPROBANTE_NUMERO, " &
                    "MONEDA= CASE WHEN V.TIPO_MONEDA='1' THEN 'S/' ELSE 'US' END, V.IMPORTE_TOTAL_ORIGEN AS IMPORTE,V.CUENTA_COMERCIAL, " &
                    "TD=CASE CC.TIPO_DOCUMENTO WHEN '01' THEN 'DNI' WHEN '06' THEN 'RUC' ELSE 'OTR' END, ND=CC.NRO_DOCUMENTO, CC.RAZON_SOCIAL, NRO_GUIA=V.GUIA_REMITENTE " &
                    "FROM COM.VENTAS AS V INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON V.EMPRESA = CC.EMPRESA AND V.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " &
                    "WHERE V.EMPRESA='" & cEmpresa & "' AND V.EJERCICIO ='" & cEjErcicio & "' AND V.MES='" & cMes & "' AND V.COMPROBANTE_TIPO IN ('01','03') AND V.ESTADO <> 'N' " &
                    IIf(cIndicaSinGuia = True, "AND V.GUIA_REMITENTE = '000000000000' ", "AND V.GUIA_REMITENTE <> '000000000000' ") &
                    IIf(cEsVehicular = True, "AND V.TIPO_OPERACION IN ('B7','F7') ", "AND (NOT V.TIPO_OPERACION IN ('B7','F7')) ") &
                    "ORDER BY V.FECHA_REGISTRO DESC "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ActualizarVentaVehiculo(MyVenta As entVenta, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySQLString = "UPDATE COM.VENTAS SET " & _
                              "Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                              "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyVenta.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLString = "UPDATE COM.VENTAS_PRO SET " & _
                                      "Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySQLString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyVenta.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        'Actualizar Stock por Almacen y por Periodo 
                        MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-1," & _
                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySQL_2
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-1," & _
                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySQL_3
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
                        MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Series
                        If MyDetallesVentaSeries.Rows.Count <> 0 Then
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySQL_3 = "UPDATE COM.VENTAS_SERIES SET " & _
                                      "Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                            MySQLCommand.CommandText = MySQL_3
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(0).PRODUCTO)
                            MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(0).NUMERO_SERIE)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySQL_4 = "UPDATE COM.CONTROL_SERIES SET " & _
                                      "Numero_serie_chasis=@vNumero_serie_chasis,Color=@vColor,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                            MySQLCommand.CommandText = MySQL_4
                            MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesVentaSeries(0).NUMERO_SERIE_CHASIS)
                            MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesVentaSeries(0).COLOR)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(0).PRODUCTO)
                            MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(0).NUMERO_SERIE)
                            MySQLCommand.ExecuteNonQuery()

                        End If

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_4 = "UPDATE COM.VENTAS_VEHICULOS SET " &
                                  "Numero_serie_chasis=@vNumero_serie_chasis,Color=@vColor,Año_fabricacion=@vAño_fabricacion,Marca=@vMarca,Modelo=@vModelo,Capacidad_motor=@vCapacidad_motor," &
                                  "Numero_cilindros=@vNumero_cilindros,Potencia_hp=@vPotencia_hp,Potencia_kw=@vPotencia_kw,Torque_nm=@vTorque_nm,Torque_rpm=@vTorque_rpm," &
                                  "Numero_rpm=@vNumero_rpm,Peso_neto=@vPeso_neto,Carga_util=@vCarga_util,Peso_bruto=@vPeso_bruto,Numero_asientos=@vNumero_asientos," &
                                  "Numero_pasajeros=@vNumero_pasajeros,Numero_ruedas=@vNumero_ruedas,Numero_ejes=@vNumero_ejes,Combustible=@vCombustible," &
                                  "Longitud_largo=@vLongitud_largo,Longitud_ancho=@vLongitud_ancho,Longitud_altura=@vLongitud_altura,Poliza_numero=@vPoliza_numero," &
                                  "Poliza_año=@vPoliza_año,Poliza_item=@vPoliza_item,Poliza_ipl=@vPoliza_ipl,Categoria_vehicular=@vCategoria_vehicular," &
                                  "Numero_vin=@vNumero_vin,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySQL_4
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyVentaVehiculo(0).NUMERO_SERIE_CHASIS)
                        MySQLCommand.Parameters.AddWithValue("vColor", MyVentaVehiculo(0).COLOR)
                        MySQLCommand.Parameters.AddWithValue("vAño_fabricacion", MyVentaVehiculo(0).AÑO_FABRICACION)
                        MySQLCommand.Parameters.AddWithValue("vMarca", MyVentaVehiculo(0).MARCA)
                        MySQLCommand.Parameters.AddWithValue("vModelo", MyVentaVehiculo(0).MODELO)
                        MySQLCommand.Parameters.AddWithValue("vCapacidad_motor", MyVentaVehiculo(0).CAPACIDAD_MOTOR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_cilindros", MyVentaVehiculo(0).NUMERO_CILINDROS)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_hp", MyVentaVehiculo(0).POTENCIA_HP)
                        MySQLCommand.Parameters.AddWithValue("vPotencia_kw", MyVentaVehiculo(0).POTENCIA_KW)
                        MySQLCommand.Parameters.AddWithValue("vTorque_nm", MyVentaVehiculo(0).TORQUE_NM)
                        MySQLCommand.Parameters.AddWithValue("vTorque_rpm", MyVentaVehiculo(0).TORQUE_RPM)
                        MySQLCommand.Parameters.AddWithValue("vNumero_rpm", MyVentaVehiculo(0).NUMERO_RPM)
                        MySQLCommand.Parameters.AddWithValue("vPeso_neto", MyVentaVehiculo(0).PESO_NETO)
                        MySQLCommand.Parameters.AddWithValue("vCarga_util", MyVentaVehiculo(0).CARGA_UTIL)
                        MySQLCommand.Parameters.AddWithValue("vPeso_bruto", MyVentaVehiculo(0).PESO_BRUTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_asientos", MyVentaVehiculo(0).NUMERO_ASIENTOS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_pasajeros", MyVentaVehiculo(0).NUMERO_PASAJEROS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ruedas", MyVentaVehiculo(0).NUMERO_RUEDAS)
                        MySQLCommand.Parameters.AddWithValue("vNumero_ejes", MyVentaVehiculo(0).NUMERO_EJES)
                        MySQLCommand.Parameters.AddWithValue("vCombustible", MyVentaVehiculo(0).COMBUSTIBLE)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_largo", MyVentaVehiculo(0).LONGITUD_LARGO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_ancho", MyVentaVehiculo(0).LONGITUD_ANCHO)
                        MySQLCommand.Parameters.AddWithValue("vLongitud_altura", MyVentaVehiculo(0).LONGITUD_ALTURA)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_numero", MyVentaVehiculo(0).POLIZA_NUMERO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_año", MyVentaVehiculo(0).POLIZA_AÑO)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_item", MyVentaVehiculo(0).POLIZA_ITEM)
                        MySQLCommand.Parameters.AddWithValue("vPoliza_ipl", MyVentaVehiculo(0).POLIZA_IPL)
                        MySQLCommand.Parameters.AddWithValue("vCategoria_vehicular", MyVentaVehiculo(0).CATEGORIA_VEHICULAR)
                        MySQLCommand.Parameters.AddWithValue("vNumero_vin", MyVentaVehiculo(0).NUMERO_VIN)
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyVentaVehiculo(0).EMPRESA)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaVehiculo(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaVehiculo(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQL_4 = "UPDATE COM.CONTROL_VEHICULOS SET " &
                                  "Numero_serie_chasis=@vNumero_serie_chasis,Color=@vColor,Año_fabricacion=@vAño_fabricacion,Marca=@vMarca,Modelo=@vModelo,Capacidad_motor=@vCapacidad_motor," &
                                  "Numero_cilindros=@vNumero_cilindros,Potencia_hp=@vPotencia_hp,Potencia_kw=@vPotencia_kw,Torque_nm=@vTorque_nm,Torque_rpm=@vTorque_rpm," &
                                  "Numero_rpm=@vNumero_rpm,Peso_neto=@vPeso_neto,Carga_util=@vCarga_util,Peso_bruto=@vPeso_bruto,Numero_asientos=@vNumero_asientos," &
                                  "Numero_pasajeros=@vNumero_pasajeros,Numero_ruedas=@vNumero_ruedas,Numero_ejes=@vNumero_ejes,Combustible=@vCombustible," &
                                  "Longitud_largo=@vLongitud_largo,Longitud_ancho=@vLongitud_ancho,Longitud_altura=@vLongitud_altura,Poliza_numero=@vPoliza_numero," &
                                  "Poliza_año=@vPoliza_año,Poliza_item=@vPoliza_item,Poliza_ipl=@vPoliza_ipl,Categoria_vehicular=@vCategoria_vehicular," &
                                  "Numero_vin=@vNumero_vin,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySQL_4
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

    Public Shared Function ObtenerVentaVehiculo(pEmpresa As String, pVenta As String) As dsVentas.VENTAS_VEHICULOSDataTable
        MySQLString = "SELECT * FROM COM.VENTAS_VEHICULOS WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta"

        Dim MyDT As New dsVentas.VENTAS_VEHICULOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerSeparacionVehiculo(pEmpresa As String, pSeparacion As String) As dsVentas.VENTAS_VEHICULOSDataTable
        MySQLString = "SELECT * FROM COM.SEPARACIONES_VEHICULOS WHERE EMPRESA=@vEmpresa AND SEPARACION=@vSeparacion "

        Dim MyDT As New dsVentas.VENTAS_VEHICULOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vSeparacion", pSeparacion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ActualizarEstadoEnvio(ByVal pEmpresa As String, ByVal pTipo As String, pSerie As String, pNumero As String, pEstado_envio As String) As Boolean
        Dim Respuesta As Boolean = ExisteEnvio(pEmpresa, pTipo, pSerie, pNumero)

        If Respuesta = False Then
            MySQLString = "UPDATE COM.VENTAS SET " & _
                          "Estado_envio=@vEstado_envio,Usuario_envio=@vUsuario_modifica,Fecha_envio=GETDATE() " & _
                          "WHERE Empresa=@vEmpresa AND Comprobante_Tipo=@vComprobante_Tipo AND Comprobante_Serie=@vComprobante_Serie AND Comprobante_Numero=@vComprobante_Numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLTransaction As SqlTransaction
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

                With MySQLCommand.Parameters
                    .AddWithValue("vEstado_envio", pEstado_envio)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario.Trim)
                    .AddWithValue("vEmpresa", pEmpresa)
                    .AddWithValue("vComprobante_Tipo", pTipo)
                    .AddWithValue("vComprobante_Serie", pSerie)
                    .AddWithValue("vComprobante_Numero", pNumero)
                End With

                Try
                    MySQLDbconnection.Open()
                    MySQLTransaction = MySQLDbconnection.BeginTransaction()
                    MySQLCommand.Connection = MySQLDbconnection
                    MySQLCommand.Transaction = MySQLTransaction
                    MySQLCommand.ExecuteNonQuery()

                    MySQLTransaction.Commit()
                Catch ex As Exception
                    Try
                        MySQLTransaction.Rollback()
                    Catch
                        ' Do nothing here; transaction is not active.
                    End Try
                    Throw New BusinessException(ERR1000 & ": " & ex.Message)
                End Try
            End Using
        End If
        Return Respuesta
    End Function

    Private Shared Function ExisteEnvio(ByVal pEmpresa As String, ByVal pTipo As String, pSerie As String, pNumero As String) As Boolean
        Dim Respuesta As Boolean = True
        MySQLString = "SELECT Usuario_envio " & _
                      "FROM COM.VENTAS " & _
                      "WHERE EMPRESA='" & pEmpresa & "' AND Comprobante_Tipo='" & pTipo & "' AND Comprobante_Serie='" & pSerie & "' AND Comprobante_Numero='" & pNumero & "' " & _
                      "AND LEN(RTRIM(Usuario_envio))<>0 "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If NewCode Is Nothing Then Respuesta = False
            Return Respuesta
        End Using
    End Function

    Public Shared Function GrabarVentaDirecta(Venta As entVenta, VentaDetalles As dsVentas.VENTA_DETDataTable, VentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable, ProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable) As entVenta
        With Venta
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
        End With

        Return InsertarVentaDirecta(Venta, VentaDetalles, VentaDetalleSeries, ProductoComponentes)
    End Function

    Public Shared Function GrabarVentaVehiculo(Venta As entVenta, VentaDetalles As dsVentas.VENTA_DETDataTable, VentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable, VentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        With Venta
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
        End With

        Return InsertarVentaVehiculo(Venta, VentaDetalles, VentaDetalleSeries, VentaVehiculo)
    End Function

    Public Shared Function GrabarSeparacionVehiculo(Separacion As entVenta, SeparacionDetalles As dsVentas.VENTA_DETDataTable, SeparacionDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable, SeparacionVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        With Separacion
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
        End With

        Return InsertarVentaVehiculo(Separacion, SeparacionDetalles, SeparacionDetalleSeries, SeparacionVehiculo)
    End Function

    Public Shared Function GrabarNotaCredito(ReferenciaVenta As String, Venta As entVenta, VentaDetalles As dsVentas.VENTA_DETDataTable, VentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable) As entVenta
        With Venta
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
        End With

        Return InsertarNotaCredito(ReferenciaVenta, Venta, VentaDetalles, VentaDetalleSeries)
    End Function

    Public Shared Function GrabarNotaCreditoVehiculo(ReferenciaVenta As String, Venta As entVenta, VentaDetalles As dsVentas.VENTA_DETDataTable, VentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable, VentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        With Venta
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
        End With

        Return InsertarNotaCreditoVehiculo(ReferenciaVenta, Venta, VentaDetalles, VentaDetalleSeries, VentaVehiculo)
    End Function

    Private Shared Function InsertarVentaVehiculo(MyVenta As entVenta, MyDetallesVenta As dsVentas.VENTA_DETDataTable, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        Dim Linea As Integer = 0

        With MyVenta
            .venta = AsignarVenta()
            .comprobante_numero = AsignarCorrelativo(.comprobante_tipo, .comprobante_serie, "NO")
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
        End With

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call InsertarEncabezado(MyVenta, MySQLCommand)
                        Call InsertarDetalle(MyVenta, MyDetallesVenta, 0, Linea, MySQLCommand)
                        Call ActualizarResumenAlmacenPeriodo(MyVenta, MyDetallesVenta, 0, False, MySQLCommand)

                        Call InsertarVentaSerie(MyVenta, MyDetallesVentaSeries, 0, MySQLCommand)
                        Call InsertarControlSerie(MyVenta, MyDetallesVentaSeries, 0, False, MySQLCommand)
                        Call ActualizarControlVehiculo(MyVenta, MyDetallesVentaSeries, 0, False, MySQLCommand)

                        If MyVentaVehiculo.Rows.Count <> 0 Then Call InsertarVentaVehiculo(MyVenta, MyVentaVehiculo, MySQLCommand)
                        If MyVenta.cuota_inicial <> 0 Then Call InsertarCuotaInicial(MyVenta, MySQLCommand)

                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyVenta

            End Using

        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try

    End Function

    Private Shared Function InsertarSeparacionVehiculo(MySeparacion As entVenta, MyDetallesSeparacion As dsVentas.VENTA_DETDataTable, MyDetallesSeparacionSeries As dsVentas.VENTA_DET_SERIESDataTable, MySeparacionVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        Dim Linea As Integer = 0

        With MySeparacion
            .venta = AsignarSeparacion()
        End With

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call InsertarEncabezado(MySeparacion, MySQLCommand)
                        Call InsertarDetalle(MySeparacion, MyDetallesSeparacion, 0, Linea, MySQLCommand)

                        Call InsertarVentaSerie(MySeparacion, MyDetallesSeparacionSeries, 0, MySQLCommand)
                        Call InsertarControlSerie(MySeparacion, MyDetallesSeparacionSeries, 0, False, MySQLCommand)
                        Call ActualizarControlVehiculo(MySeparacion, MyDetallesSeparacionSeries, 0, False, MySQLCommand)
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MySeparacion

            End Using

        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try

    End Function

    Private Shared Function InsertarVentaDirecta(MyVenta As entVenta, MyDetallesVenta As dsVentas.VENTA_DETDataTable, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable) As entVenta
        Dim Linea As Integer = 0

        With MyVenta
            .venta = AsignarVenta()
            .comprobante_numero = AsignarCorrelativo(.comprobante_tipo, .comprobante_serie, "NO")
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
        End With

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call InsertarEncabezado(MyVenta, MySQLCommand)

                        For FilaDetalle As Integer = 0 To MyDetallesVenta.Rows.Count - 1
                            Call InsertarDetalle(MyVenta, MyDetallesVenta, FilaDetalle, Linea, MySQLCommand)
                            If MyDetallesVenta(FilaDetalle).PRODUCTO = "P0000000" Then ' Servicios varios 
                                Call InsertarDetalleServicio(MyVenta, MyDetallesVenta, FilaDetalle, Linea, MySQLCommand)
                            Else
                                If MyDetallesVenta(FilaDetalle).INDICA_COMPUESTO = "NO" Then
                                    Call ActualizarResumenAlmacenPeriodo(MyVenta, MyDetallesVenta, FilaDetalle, False, MySQLCommand)
                                Else
                                    Call InsertarDetalleCompuesto(MyVenta, MyDetallesVenta, MyProductoComponentes, FilaDetalle, Linea, MySQLCommand)
                                End If
                            End If
                        Next

                        If MyDetallesVentaSeries.Rows.Count <> 0 Then
                            For FilaDetalleSeries As Integer = 0 To MyDetallesVentaSeries.Rows.Count - 1
                                Call InsertarVentaSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, MySQLCommand)
                                Call InsertarControlSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, False, MySQLCommand)
                            Next
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyVenta
            End Using
        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try
    End Function

    Private Shared Function InsertarNotaCredito(MyReferenciaVenta As String, MyVenta As entVenta, MyDetallesVenta As dsVentas.VENTA_DETDataTable, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable) As entVenta
        Dim Linea As Byte = 0

        With MyVenta
            .venta = AsignarVenta()
            .comprobante_numero = AsignarCorrelativo(.comprobante_tipo, .comprobante_serie, "NO")
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
            .tipo_operacion = "C1"
        End With

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call InsertarEncabezado(MyVenta, MySQLCommand)

                        For FilaDetalle As Integer = 0 To MyDetallesVenta.Rows.Count - 1
                            Call InsertarDetalle(MyVenta, MyDetallesVenta, FilaDetalle, Linea, MySQLCommand)
                            Call ActualizarCantidadDevuelta(MyDetallesVenta, FilaDetalle, MyReferenciaVenta, MySQLCommand)
                            Call ActualizarResumenAlmacenPeriodo(MyVenta, MyDetallesVenta, FilaDetalle, True, MySQLCommand)
                        Next

                        If MyDetallesVentaSeries.Rows.Count <> 0 Then
                            For FilaDetalleSeries As Integer = 0 To MyDetallesVentaSeries.Rows.Count - 1
                                Call InsertarVentaSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, MySQLCommand)
                                Call InsertarControlSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, True, MySQLCommand)
                            Next
                        End If
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyVenta
            End Using
        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try
    End Function

    Private Shared Function InsertarNotaCreditoVehiculo(MyReferenciaVenta As String, MyVenta As entVenta, MyDetallesVenta As dsVentas.VENTA_DETDataTable, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable) As entVenta
        Dim Linea As Byte = 0

        With MyVenta
            .venta = AsignarVenta()
            .comprobante_numero = AsignarCorrelativo(.comprobante_tipo, .comprobante_serie, "NO")
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
        End With

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call InsertarEncabezado(MyVenta, MySQLCommand)

                        For FilaDetalle As Integer = 0 To MyDetallesVenta.Rows.Count - 1
                            Call InsertarDetalle(MyVenta, MyDetallesVenta, FilaDetalle, Linea, MySQLCommand)
                            Call ActualizarCantidadDevuelta(MyDetallesVenta, FilaDetalle, MyReferenciaVenta, MySQLCommand)
                            Call ActualizarResumenAlmacenPeriodo(MyVenta, MyDetallesVenta, FilaDetalle, True, MySQLCommand)
                        Next

                        If MyDetallesVentaSeries.Rows.Count <> 0 Then
                            For FilaDetalleSeries As Integer = 0 To MyDetallesVentaSeries.Rows.Count - 1
                                Call InsertarVentaSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, MySQLCommand)
                                Call InsertarControlSerie(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, True, MySQLCommand)
                                Call ActualizarControlVehiculo(MyVenta, MyDetallesVentaSeries, FilaDetalleSeries, True, MySQLCommand)
                            Next
                        End If

                        If MyVentaVehiculo.Rows.Count <> 0 Then Call InsertarVentaVehiculo(MyVenta, MyVentaVehiculo, MySQLCommand)
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyVenta
            End Using
        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try
    End Function

    Public Shared Function AnularVentaDirecta(MyVenta As entVenta, MyDetallesVenta As dsVentas.VENTA_DETDataTable, MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable) As Boolean
        Dim MyComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySQLString = "UPDATE COM.VENTAS SET " & _
                              "estado='N',usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " & _
                              "WHERE empresa=@vEmpresa AND VENTA=@vVenta "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyVenta.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLString = "UPDATE COM.VENTAS_PRO SET " & _
                                "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySQLString
                        MySQLCommand.ExecuteNonQuery()

                        MySQLString = "UPDATE COM.VENTAS_COM SET " & _
                                "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySQLString
                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To MyDetallesVenta.Rows.Count - 1
                            If MyDetallesVenta(NEle).INDICA_COMPUESTO = "NO" Then
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                'Actualizar Stock por Almacen y por Periodo 
                                MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-@vCantidad," & _
                                          "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySQL_2
                                MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(NEle).PRODUCTO)
                                MySQLCommand.ExecuteNonQuery()

                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-@vCantidad," & _
                                          "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                MySQLCommand.CommandText = MySQL_3
                                MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(NEle).CANTIDAD)
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
                                MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
                                MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                                MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(NEle).PRODUCTO)
                                MySQLCommand.ExecuteNonQuery()
                            Else
                                MyComponentes = New dsProductos.PRODUCTO_COMPONENTESDataTable
                                For FilaCom As Integer = 0 To MyProductoComponentes.Rows.Count - 1
                                    If MyProductoComponentes(FilaCom).PRODUCTO_COMPUESTO = MyDetallesVenta(NEle).PRODUCTO Then
                                        MyComponentes.ImportRow(MyProductoComponentes(FilaCom))
                                    End If
                                Next

                                If MyComponentes.Rows.Count <> 0 Then
                                    For NFila As Integer = 0 To MyComponentes.Rows.Count - 1
                                        MySQLCommand.CommandType = CommandType.Text
                                        MySQLCommand.Parameters.Clear()

                                        'Actualizar Stock por Almacen y por Periodo 
                                        MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-@vCantidad," & _
                                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                                  "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                        MySQLCommand.CommandText = MySQL_2
                                        MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(NEle).CANTIDAD * MyComponentes(NFila).CANTIDAD)
                                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                        MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(NFila).PRODUCTO)
                                        MySQLCommand.ExecuteNonQuery()

                                        MySQLCommand.CommandType = CommandType.Text
                                        MySQLCommand.Parameters.Clear()

                                        MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-@vCantidad," & _
                                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                                  "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                                        MySQLCommand.CommandText = MySQL_3
                                        MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(NEle).CANTIDAD * MyComponentes(NFila).CANTIDAD)
                                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                        MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
                                        MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
                                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                                        MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(NFila).PRODUCTO)
                                        MySQLCommand.ExecuteNonQuery()
                                    Next
                                End If
                            End If
                        Next

                        'Actualizar Series
                        If MyDetallesVentaSeries.Rows.Count <> 0 Then
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySQL_2 = "UPDATE COM.VENTAS_SERIES SET " & _
                                      "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "
                            MySQLCommand.CommandText = MySQL_2
                            With MySQLCommand.Parameters
                                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vVenta", MyVenta.venta)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            For NEle As Integer = 0 To MyDetallesVentaSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySQL_3 = "UPDATE COM.CONTROL_SERIES SET Referencia_venta=@vReferencia_venta,Fecha_venta=@vFecha_venta," & _
                                          "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                MySQLCommand.CommandText = MySQL_3
                                MySQLCommand.Parameters.AddWithValue("vReferencia_venta", CUO_Nulo)
                                MySQLCommand.Parameters.AddWithValue("vFecha_venta", FechaNulo)
                                MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(NEle).NUMERO_SERIE)
                                MySQLCommand.ExecuteNonQuery()
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

    Public Shared Function AnularVentaVehiculo(MyVenta As entVenta, MyVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySQLString = "UPDATE COM.VENTAS SET " & _
                              "base_imponible_gravada_origen=0,igv_origen=0,importe_total_origen=0," &
                              "base_imponible_gravada_mn=0,igv_mn=0,importe_total_mn=0," &
                              "base_imponible_gravada_me=0,igv_me=0,importe_total_me=0," &
                              "estado='N',usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                              "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyVenta.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLString = "UPDATE COM.VENTAS_PRO SET " &
                                      "estado='N',usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                                      "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySQLString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyVenta.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos-1," & _
                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySQL_2
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos-1," & _
                                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                        MySQLCommand.CommandText = MySQL_3
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
                        MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
                        MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
                        MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.ExecuteNonQuery()

                        'Actualizar Series
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_3 = "UPDATE COM.VENTAS_SERIES SET " & _
                                  "estado='N',usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                                  "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta AND PRODUCTO=@vProducto AND NUMERO_SERIE=@vNumero_serie  "

                        MySQLCommand.CommandText = MySQL_3

                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_4 = "UPDATE COM.CONTROL_SERIES SET " & _
                                  "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySQL_4
                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()

                        MySQL_4 = "UPDATE COM.VENTAS_VEHICULOS SET " & _
                                  "Estado='N',Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySQL_4

                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaDetalleSeries(0).NUMERO_SERIE)
                        MySQLCommand.ExecuteNonQuery()

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.Parameters.Clear()
                        MySQL_4 = "UPDATE COM.CONTROL_VEHICULOS SET " & _
                                  "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                        MySQLCommand.CommandText = MySQL_4
                        MySQLCommand.Parameters.AddWithValue("vEstado", "D")
                        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaDetalleSeries(0).PRODUCTO)
                        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaDetalleSeries(0).NUMERO_SERIE)
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

    Public Shared Function AnularNotaCredito(MyReferencia As entVenta, MyReferenciaDetalles As dsVentas.VENTA_DETDataTable, MyReferenciaDetallesSeries As dsVentas.VENTA_DET_SERIESDataTable) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySQLString = "UPDATE COM.VENTAS SET " & _
                              "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                              "WHERE Empresa=@vEmpresa AND Venta=@vVenta"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", MyReferencia.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySQLString = "UPDATE COM.VENTAS_PRO SET " & _
                                      "Estado='N', Usuario_modifica=@vUsuario_modifica, Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta"

                        MySQLCommand.ExecuteNonQuery()

                        For NEle As Byte = 0 To MyReferenciaDetalles.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            'Actualizar cantidad devuelta 
                            MySQL_2 = "UPDATE COM.VENTAS_PRO SET Cantidad_devuelta=Cantidad_devuelta-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "

                            MySQLCommand.CommandText = MySQL_2
                            MySQLCommand.Parameters.AddWithValue("vCantidad", MyReferenciaDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vVenta", MyReferencia.venta)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            'Actualizar Stock por Almacen y por Periodo 
                            MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Ingresos=Ingresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySQL_2
                            MySQLCommand.Parameters.AddWithValue("vCantidad", MyReferenciaDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyReferenciaDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.Parameters.Clear()

                            MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Ingresos=Ingresos-@vCantidad," & _
                                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

                            MySQLCommand.CommandText = MySQL_3
                            MySQLCommand.Parameters.AddWithValue("vCantidad", MyReferenciaDetalles(NEle).CANTIDAD)
                            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyUsuario.ejercicio)
                            MySQLCommand.Parameters.AddWithValue("vMes", MyUsuario.mes.ToString("00"))
                            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)
                            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
                            MySQLCommand.Parameters.AddWithValue("vProducto", MyReferenciaDetalles(NEle).PRODUCTO)
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        'Actualizar Series
                        If MyReferenciaDetallesSeries.Rows.Count <> 0 Then
                            For NEle As Integer = 0 To MyReferenciaDetallesSeries.Rows.Count - 1
                                MySQLCommand.CommandType = CommandType.Text
                                MySQLCommand.Parameters.Clear()

                                MySQL_4 = "UPDATE COM.CONTROL_SERIES SET Referencia_devolucion=@vReferencia_devolucion,Fecha_devolucion=@vFecha_devolucion," & _
                                          "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                                          "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

                                MySQLCommand.CommandText = MySQL_4
                                MySQLCommand.Parameters.AddWithValue("vReferencia_devolucion", CUO_Nulo)
                                MySQLCommand.Parameters.AddWithValue("vFecha_devolucion", FechaNulo)
                                MySQLCommand.Parameters.AddWithValue("vEstado", "N")
                                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                                MySQLCommand.Parameters.AddWithValue("vProducto", MyReferenciaDetallesSeries(NEle).PRODUCTO)
                                MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyReferenciaDetallesSeries(NEle).NUMERO_SERIE)
                                MySQLCommand.ExecuteNonQuery()
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

    Public Shared Function ObtenerVentasExcel(ByVal pEmpresa As String, ByVal pEjercicio As String, pMes As String) As dsVentas.VENTAS_RESUMENDataTable
        MyStoreProcedure = "COM.VENTAS_RESUMEN"
        Dim MyParameter_1 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_1.Value = pEjercicio
        Dim MyParameter_2 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_2.Value = pMes

        Dim MyDT As New dsVentas.VENTAS_RESUMENDataTable

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

    Public Shared Function ComprobantesInforme(ByVal pFechaDesde As String, ByVal pFechaHasta As String, pCuentaComercial As String, pTipoComprobante As String, ByVal pVendedor As String, pTipoOperacion As String) As dsVentas.VENTAS_INFORMEDataTable
        Dim EsTransferenciaGratuita As Boolean = False

        If pTipoOperacion = "B2" Then EsTransferenciaGratuita = True
        If pTipoOperacion = "F2" Then EsTransferenciaGratuita = True

        MySQLString = ConsultaComprobantesInforme &
                      "WHERE H.EMPRESA=@vEmpresa " &
                      "AND (H.COMPROBANTE_FECHA BETWEEN CONVERT(DATETIME, '" & pFechaDesde & "', 102) AND CONVERT(DATETIME, '" & pFechaHasta & "', 102)) " &
                      IIf(pCuentaComercial.Trim.Length = 0, " ", " AND H.CUENTA_COMERCIAL='" & pCuentaComercial & "' ") & " " &
                      IIf(pTipoOperacion = "TODOS", " ", IIf(EsTransferenciaGratuita = True, " AND H.CONDICION_PAGO='TG' ", " AND H.TIPO_OPERACION='" & pTipoOperacion & "' ")) & " " &
                      IIf(pTipoComprobante = "TODOS", " ", " AND H.COMPROBANTE_TIPO='" & pTipoComprobante & "' ") &
                      IIf(pVendedor = "TODOS", " ", " AND H.CODIGO_VENDEDOR='" & pVendedor & "' ") &
                      "ORDER BY H.COMPROBANTE_FECHA, H.COMPROBANTE_TIPO, H.COMPROBANTE_SERIE, H.COMPROBANTE_NUMERO "

        Dim MyDT As New dsVentas.VENTAS_INFORMEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobanteDetalles(ByVal pVenta As String) As dsVentas.COMPROBANTE_DETALLESDataTable

        MySQLString = "SELECT H.EMPRESA, H.VENTA, D.LINEA, D.PRODUCTO, RTRIM(P.DESCRIPCION_AMPLIADA) AS DESCRIPCION, D.NUMERO_SERIE, " &
                      "D.CANTIDAD, D.PRECIO_UNITARIO, D.BASE_IMPONIBLE_GRAVADA_ORIGEN AS VALOR_VENTA, " &
                      "D.IGV_ORIGEN AS IMPUESTO, D.IMPORTE_TOTAL_ORIGEN AS PRECIO_VENTA, ISNULL(G.GUIA,SPACE(1)) AS GUIA, P.INDICA_SERIE " &
                      "FROM COM.VENTAS AS H INNER JOIN COM.VENTAS_PRO AS D ON H.EMPRESA = D.EMPRESA AND H.VENTA = D.VENTA " &
                                           "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " &
                                           "LEFT OUTER JOIN COM.GUIAS AS G ON H.EMPRESA = G.EMPRESA AND H.GUIA_REMITENTE = G.GUIA  " &
                      "WHERE H.EMPRESA=@vEmpresa AND H.VENTA= @vVenta "

        Dim MyDT As New dsVentas.COMPROBANTE_DETALLESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function VentaDetallada(ByVal pFechaDesde As String, ByVal pFechaHasta As String, pFamilia As String, pTipo As String, pCliente As String, pProducto As String) As dsVentas.VENTA_DETALLADataTable

        MySQLString = "SELECT H.EMPRESA, H.VENTA, H.GUIA_REMITENTE AS GUIA, H.CUENTA_COMERCIAL, CC.RAZON_SOCIAL,  NRO_COMPROBANTE=LEFT(H.TIPO_OPERACION, 1) + '/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO, H.COMPROBANTE_FECHA, " & _
                "H.TIPO_MONEDA, TIPO_CAMBIO=CASE WHEN H.TIPO_CAMBIO<>0 THEN H.TIPO_CAMBIO ELSE ISNULL(TC.VENTA,0) END, D.LINEA, D.PRODUCTO, RTRIM(P.DESCRIPCION_AMPLIADA) AS DESCRIPCION, CASE WHEN H.COMPROBANTE_TIPO='07' THEN -D.CANTIDAD ELSE D.CANTIDAD END AS CANTIDAD, D.PRECIO_UNITARIO,  " & _
                "VALOR_VENTA=H.BASE_IMPONIBLE_GRAVADA_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                "IMPUESTO=(D.IMPORTE_TOTAL_ORIGEN-H.BASE_IMPONIBLE_GRAVADA_ORIGEN)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                "PRECIO_VENTA=D.IMPORTE_TOTAL_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                "NRO_GUIA=ISNULL(LEFT(G.TIPO_OPERACION, 1) + '/' + G.COMPROBANTE_SERIE + '-' + G.COMPROBANTE_NUMERO, SPACE(1)), P.CODIGO_COMPRA, " & _
                "P.INDICA_SERIE, P.PRODUCTO_FAMILIA, TPF.DESCRIPCION AS FAMILIA, P.PRODUCTO_TIPO, TPT.DESCRIPCION AS TIPO " & _
                "FROM  COM.VENTAS AS H INNER JOIN COM.VENTAS_PRO AS D ON H.EMPRESA = D.EMPRESA AND H.VENTA = D.VENTA " & _
                                      "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " & _
                                      "INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                      "INNER JOIN GEN.TABLA_TIPO_VENTA AS TTV ON H.EMPRESA = TTV.EMPRESA AND H.TIPO_OPERACION = TTV.CODIGO " & _
                                      "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON H.EMPRESA = TPF.EMPRESA AND P.PRODUCTO_FAMILIA = TPF.CODIGO " & _
                                      "INNER JOIN GEN.TABLA_PRODUCTO_TIPO AS TPT ON H.EMPRESA = TPT.EMPRESA AND P.PRODUCTO_TIPO = TPT.CODIGO " & _
                                      "LEFT OUTER JOIN GEN.TIPO_CAMBIO_FECHA AS TC ON H.COMPROBANTE_FECHA = TC.FECHA AND TC.MONEDA='2' " & _
                                      "LEFT OUTER JOIN COM.GUIAS AS G ON H.EMPRESA = G.EMPRESA AND H.GUIA_REMITENTE = G.GUIA " & _
                "WHERE H.EMPRESA=@vEmpresa AND H.ESTADO<>'N' " & _
                IIf(pCliente = "TODOS", " ", " AND H.CUENTA_COMERCIAL='" & pCliente & "' ") & _
                IIf(pProducto = "TODOS", " ", " AND D.PRODUCTO='" & pProducto & "' ") & _
                "AND (H.COMPROBANTE_FECHA BETWEEN CONVERT(DATETIME, '" & pFechaDesde & "', 102) AND CONVERT(DATETIME, '" & pFechaHasta & "', 102)) " & _
                IIf(pFamilia = "TODOS", " ", " AND P.PRODUCTO_FAMILIA='" & pFamilia & "' ") & " " & _
                IIf(pTipo = "TODOS", " ", " AND P.PRODUCTO_TIPO='" & pTipo & "' ")

        If pFamilia = "TODOS" And pTipo = "TODOS" And pCliente = "TODOS" And pProducto = "TODOS" Then
            MySQLString = MySQLString & _
                    "UNION ALL " & _
                    "SELECT H.EMPRESA, H.VENTA, H.GUIA_REMITENTE AS GUIA, H.CUENTA_COMERCIAL, CC.RAZON_SOCIAL, NRO_COMPROBANTE=LEFT(H.TIPO_OPERACION, 1) + '/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO, H.COMPROBANTE_FECHA, H.TIPO_MONEDA, H.TIPO_CAMBIO, " & _
                    "'001' AS LINEA, RIGHT(H.COMPROBANTE_NUMERO,8) AS PRODUCTO, RTRIM(H.COMENTARIO) AS DESCRIPCION, CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END AS CANTIDAD, H.IMPORTE_TOTAL_ORIGEN AS PRECIO_UNITARIO, " & _
                    "VALOR_VENTA=H.BASE_IMPONIBLE_GRAVADA_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                    "IMPUESTO=(H.IMPORTE_TOTAL_ORIGEN-H.BASE_IMPONIBLE_GRAVADA_ORIGEN)*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                    "PRECIO_VENTA=H.IMPORTE_TOTAL_ORIGEN*(CASE WHEN H.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END)," & _
                    "NRO_GUIA=SPACE(1), CODIGO_COMPRA=SPACE(1), INDICA_SERIE='NO', PRODUCTO_FAMILIA='114', FAMILIA='OTROS', PRODUCTO_TIPO='000', TIPO=TTV.DESCRIPCION " & _
                    "FROM  COM.VENTAS AS H INNER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                          "INNER JOIN GEN.TABLA_TIPO_VENTA AS TTV ON H.EMPRESA = TTV.EMPRESA AND H.TIPO_OPERACION = TTV.CODIGO " & _
                    "WHERE H.EMPRESA=@vEmpresa AND H.ESTADO<>'N' AND (H.TIPO_OPERACION IN ('B4','C2','D1','F4')) " & _
                    "AND (H.COMPROBANTE_FECHA BETWEEN CONVERT(DATETIME, '" & pFechaDesde & "', 102) AND CONVERT(DATETIME, '" & pFechaHasta & "', 102)) " & _
                    "ORDER BY COMPROBANTE_FECHA, NRO_COMPROBANTE "
        Else
            MySQLString = MySQLString & _
                    "ORDER BY COMPROBANTE_FECHA, NRO_COMPROBANTE "
        End If

        Dim MyDT As New dsVentas.VENTA_DETALLADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Sub ObtenerCuotaInicial(ByRef MyVenta As entVenta)
        MySQLString = "SELECT * FROM COM.VENTAS_INI WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

        Dim MyDT As New dsVentas.VENTAS_INIDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyVenta.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using

        If MyDT.Rows.Count <> 0 Then
            MyVenta.cuota_inicial = MyDT(0).CUOTA_INICIAL
            MyVenta.cuota_inicial_pagada = MyDT(0).CUOTA_INICIAL_PAGO
        End If

    End Sub

    Public Shared Function ExisteCuotaInicial(ByVal pEmpresa As String, ByVal pVenta As String) As Boolean
        Dim Respuesta As Boolean = True
        MySQLString = "SELECT usuario_registro FROM COM.VENTAS_INI WHERE EMPRESA='" & pEmpresa & "' AND VENTA='" & pVenta & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If NewCode Is Nothing Then Respuesta = False
            Return Respuesta
        End Using
    End Function

    Public Shared Function ObtenerResumenDiario(ByVal pFecha As Date, pUsuario As String) As dsVentas.ECOMPROBANTES_RESUMEN_DIARIODataTable
        Dim FechaInicial As String
        Dim FechaFinal As String

        FechaInicial = pFecha.ToString("yyyy-dd-MM 06:00:00")
        FechaFinal = DateAdd(DateInterval.Day, 1, pFecha).ToString("yyyy-dd-MM 06:00:00")

        MySQLString = "SELECT COMPROBANTE_TIPO=CASE V.COMPROBANTE_TIPO WHEN '01' THEN 'FACTURAS' WHEN '03' THEN 'BOLETAS DE VENTA' WHEN '07' THEN 'NOTAS DE CREDITO' WHEN '08' THEN 'NOTAS DE DEBITO' END, " & _
                      "COMPROBANTE=V.COMPROBANTE_SERIE + '-' + RIGHT(V.COMPROBANTE_NUMERO,8), V.COMPROBANTE_FECHA, " & _
                      "DOCUMENTO=RTRIM(V.ORDEN_COMPRA), SPACE(1) AS RAZON_SOCIAL, " & _
                      "VALOR_VENTA= V.BASE_IMPONIBLE_GRAVADA_ORIGEN*(CASE WHEN V.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                      "IMPUESTO=V.IGV_ORIGEN*(CASE WHEN V.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), " & _
                      "PRECIO_VENTA=V.IMPORTE_TOTAL_ORIGEN*(CASE WHEN V.COMPROBANTE_TIPO='07' THEN -1 ELSE 1 END), V.FECHA_REGISTRO " & _
                      "FROM COM.VENTAS AS V  " & _
                      "WHERE V.EMPRESA = @vEmpresa AND V.USUARIO_REGISTRO = @vUsuario_registro AND V.FECHA_REGISTRO BETWEEN CONVERT(DATETIME, '" & FechaInicial & "') AND CONVERT(DATETIME, '" & FechaFinal & "')  " & _
                      "ORDER BY COMPROBANTE_TIPO, COMPROBANTE "

        Dim MyDT As New dsVentas.ECOMPROBANTES_RESUMEN_DIARIODataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", pUsuario)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerResumenDiarioPago(ByVal pFecha As Date, pUsuario As String) As dsVentas.VENTAS_PAGO_RESUMENDataTable
        Dim FechaInicial As String
        Dim FechaFinal As String

        FechaInicial = pFecha.ToString("yyyy-dd-MM 06:00:00")
        FechaFinal = DateAdd(DateInterval.Day, 1, pFecha).ToString("yyyy-dd-MM 06:00:00")

        MySQLString = "SELECT FP.DESCRIPCION AS FORMA_PAGO_DESCRIPCION, V.TIPO_MONEDA, SUM(V.IMPORTE_TOTAL_ORIGEN) AS IMPORTE, " & _
                      "SUM(V.IMPORTE_TOTAL_ORIGEN) AS IMPORTE_PAGADO, SUM(V.IMPORTE_TOTAL_ORIGEN) AS IMPORTE_COBRADO, 0 AS IMPORTE_VUELTO " & _
                      "FROM COM.VENTAS AS V INNER JOIN GEN.TABLA_FORMA_PAGO_COMERCIAL AS FP ON V.FORMA_PAGO = FP.CODIGO " & _
                      "WHERE V.EMPRESA  = @vEmpresa AND USUARIO_REGISTRO = @vUsuario_registro AND FECHA_REGISTRO BETWEEN CONVERT(DATETIME, '" & FechaInicial & "') AND CONVERT(DATETIME, '" & FechaFinal & "')  " & _
                      "GROUP BY FP.DESCRIPCION,V.TIPO_MONEDA "

        Dim MyDT As New dsVentas.VENTAS_PAGO_RESUMENDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", pUsuario)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

#Region "Insertar Comprobantes"

    Private Shared Sub InsertarEncabezado(ByVal MyVenta As entVenta, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO COM.VENTAS " & _
                      "(empresa,venta,ejercicio,mes,asiento_tipo,asiento_numero,asiento_fecha,cuenta_comercial,comprobante_tipo,comprobante_serie," & _
                      "comprobante_numero,comprobante_fecha,comprobante_vencimiento,tipo_cambio,tipo_moneda,almacen,codigo_domicilio," & _
                      "valor_exportacion_origen,base_imponible_gravada_origen,importe_exonerado_origen,importe_inafecto_origen,isc_origen,igv_origen,ipm_origen," & _
                      "base_imponible_gravada2_origen,igv2_origen,otros_tributos_origen,importe_total_origen," & _
                      "valor_exportacion_mn,base_imponible_gravada_mn,importe_exonerado_mn,importe_inafecto_mn,isc_mn,igv_mn,ipm_mn," & _
                      "base_imponible_gravada2_mn,igv2_mn,otros_tributos_mn,importe_total_mn," & _
                      "valor_exportacion_me,base_imponible_gravada_me,importe_exonerado_me,importe_inafecto_me,isc_me,igv_me,ipm_me," & _
                      "base_imponible_gravada2_me,igv2_me,otros_tributos_me,importe_total_me," & _
                      "referencia_cuo,condicion_pago,forma_pago,fecha_ultimo_pago,importe_saldo,comentario,tipo_operacion,zona_comercial,codigo_vendedor," & _
                      "codigo_cobrador,centro_costo,letra,factoring,planilla_cobranza,guia_remitente,guia_transportista,Orden_pedido," & _
                      "usuario_envio,fecha_envio,fecha_recepcion,ubicacion_custodia,usuario_custodia,fecha_custodia," & _
                      "referencia_tipo,referencia_serie,referencia_numero,referencia_fecha,indica_exportacion," & _
                      "origen,estado,usuario_registro,Lista_precio,Centro_distribucion) " & _
                      "VALUES (" & _
                      "@vEmpresa,@vVenta,@vEjercicio,@vMes,@vAsiento_tipo,@vAsiento_numero,@vAsiento_fecha,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie," & _
                      "@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento,@vTipo_cambio,@vTipo_moneda,@vAlmacen,@vCodigo_domicilio," & _
                      "@vValor_exportacion_origen,@vBase_imponible_gravada_origen,@vimporte_exonerado_origen,@vimporte_inafecto_origen,@vIsc_origen,@vIgv_origen,@vIpm_origen," & _
                      "@vBase_imponible_gravada2_origen,@vIgv2_origen,@vOtros_tributos_origen,@vImporte_total_origen," & _
                      "@vValor_exportacion_mn,@vBase_imponible_gravada_mn,@vimporte_exonerado_mn,@vimporte_inafecto_mn,@vIsc_mn,@vIgv_mn,@vIpm_mn," & _
                      "@vBase_imponible_gravada2_mn,@vIgv2_mn,@vOtros_tributos_mn,@vImporte_total_mn," & _
                      "@vValor_exportacion_me,@vBase_imponible_gravada_me,@vimporte_exonerado_me,@vimporte_inafecto_me,@vIsc_me,@vIgv_me,@vIpm_me," & _
                      "@vBase_imponible_gravada2_me,@vIgv2_me,@vOtros_tributos_me,@vImporte_total_me," & _
                      "@vReferencia_cuo,@vCondicion_pago,@vForma_pago,@vFecha_ultimo_pago,@vImporte_saldo,@vComentario,@vTipo_operacion,@vZona_comercial,@vCodigo_vendedor," & _
                      "@vCodigo_cobrador,@vCentro_costo,@vLetra,@vFactoring,@vPlanilla_cobranza,@vGuia_remitente,@vGuia_transportista,@vOrden_pedido," & _
                      "@vUsuario_envio,@vFecha_envio,@vFecha_recepcion,@vUbicacion_custodia,@vUsuario_custodia,@vFecha_custodia," & _
                      "@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero,@vReferencia_fecha,@vIndica_exportacion," & _
                      "@vOrigen,@vEstado,@vUsuario_registro,@vLista_precio,@vCentro_distribucion) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyUsuario.empresa)
            .AddWithValue("vVenta", MyVenta.venta)
            .AddWithValue("vEjercicio", MyVenta.ejercicio)
            .AddWithValue("vMes", MyVenta.mes)
            .AddWithValue("vAsiento_tipo", MyVenta.asiento_tipo)
            .AddWithValue("vAsiento_numero", MyVenta.asiento_numero)
            .AddWithValue("vAsiento_fecha", MyVenta.asiento_fecha)
            .AddWithValue("vCuenta_comercial", MyVenta.cuenta_comercial.Trim)
            .AddWithValue("vComprobante_tipo", MyVenta.comprobante_tipo)
            .AddWithValue("vComprobante_serie", MyVenta.comprobante_serie)
            .AddWithValue("vComprobante_numero", MyVenta.comprobante_numero)
            .AddWithValue("vComprobante_fecha", MyVenta.comprobante_fecha)
            .AddWithValue("vComprobante_vencimiento", MyVenta.comprobante_vencimiento)
            .AddWithValue("vTipo_cambio", MyVenta.tipo_cambio)
            .AddWithValue("vTipo_moneda", MyVenta.tipo_moneda)
            .AddWithValue("vAlmacen", MyVenta.almacen)
            .AddWithValue("vCodigo_domicilio", MyVenta.codigo_domicilio)
            .AddWithValue("vValor_exportacion_origen", MyVenta.valor_exportacion_origen)
            .AddWithValue("vBase_imponible_gravada_origen", MyVenta.base_imponible_gravada_origen)
            .AddWithValue("vimporte_exonerado_origen", MyVenta.importe_exonerado_origen)
            .AddWithValue("vimporte_inafecto_origen", MyVenta.importe_inafecto_origen)
            .AddWithValue("vIsc_origen", MyVenta.isc_origen)
            .AddWithValue("vIgv_origen", MyVenta.igv_origen)
            .AddWithValue("vIpm_origen", MyVenta.ipm_origen)
            .AddWithValue("vBase_imponible_gravada2_origen", MyVenta.base_imponible_gravada2_origen)
            .AddWithValue("vIgv2_origen", MyVenta.igv2_origen)
            .AddWithValue("vOtros_tributos_origen", MyVenta.otros_tributos_origen)
            .AddWithValue("vImporte_total_origen", MyVenta.importe_total_origen)
            .AddWithValue("vValor_exportacion_mn", MyVenta.valor_exportacion_mn)
            .AddWithValue("vBase_imponible_gravada_mn", MyVenta.base_imponible_gravada_mn)
            .AddWithValue("vimporte_exonerado_mn", MyVenta.importe_exonerado_mn)
            .AddWithValue("vimporte_inafecto_mn", MyVenta.importe_inafecto_mn)
            .AddWithValue("vIsc_mn", MyVenta.isc_mn)
            .AddWithValue("vIgv_mn", MyVenta.igv_mn)
            .AddWithValue("vIpm_mn", MyVenta.ipm_mn)
            .AddWithValue("vBase_imponible_gravada2_mn", MyVenta.base_imponible_gravada2_mn)
            .AddWithValue("vIgv2_mn", MyVenta.igv2_mn)
            .AddWithValue("vOtros_tributos_mn", MyVenta.otros_tributos_mn)
            .AddWithValue("vImporte_total_mn", MyVenta.importe_total_mn)
            .AddWithValue("vValor_exportacion_me", MyVenta.valor_exportacion_me)
            .AddWithValue("vBase_imponible_gravada_me", MyVenta.base_imponible_gravada_me)
            .AddWithValue("vimporte_exonerado_me", MyVenta.importe_exonerado_me)
            .AddWithValue("vimporte_inafecto_me", MyVenta.importe_inafecto_me)
            .AddWithValue("vIsc_me", MyVenta.isc_me)
            .AddWithValue("vIgv_me", MyVenta.igv_me)
            .AddWithValue("vIpm_me", MyVenta.ipm_me)
            .AddWithValue("vBase_imponible_gravada2_me", MyVenta.base_imponible_gravada2_me)
            .AddWithValue("vIgv2_me", MyVenta.igv2_me)
            .AddWithValue("vOtros_tributos_me", MyVenta.otros_tributos_me)
            .AddWithValue("vImporte_total_me", MyVenta.importe_total_me)
            .AddWithValue("vReferencia_cuo", MyVenta.referencia_cuo)
            .AddWithValue("vCondicion_pago", MyVenta.condicion_pago)
            .AddWithValue("vForma_pago", MyVenta.forma_pago)
            .AddWithValue("vFecha_ultimo_pago", MyVenta.fecha_ultimo_pago)
            .AddWithValue("vImporte_saldo", MyVenta.importe_saldo)
            .AddWithValue("vComentario", MyVenta.comentario)
            .AddWithValue("vTipo_operacion", MyVenta.tipo_operacion)
            .AddWithValue("vZona_comercial", MyVenta.zona_comercial)
            .AddWithValue("vCodigo_vendedor", MyVenta.codigo_vendedor)
            .AddWithValue("vCodigo_cobrador", MyVenta.codigo_cobrador)
            .AddWithValue("vCentro_costo", MyVenta.centro_costo)
            .AddWithValue("vLetra", MyVenta.letra)
            .AddWithValue("vFactoring", MyVenta.factoring)
            .AddWithValue("vPlanilla_cobranza", MyVenta.planilla_cobranza)
            .AddWithValue("vGuia_remitente", MyVenta.guia_remitente)
            .AddWithValue("vGuia_transportista", MyVenta.guia_transportista)
            .AddWithValue("vOrden_pedido", MyVenta.orden_pedido)
            .AddWithValue("vUsuario_envio", MyVenta.usuario_envio)
            .AddWithValue("vFecha_envio", MyVenta.fecha_envio)
            .AddWithValue("vFecha_recepcion", MyVenta.fecha_recepcion)
            .AddWithValue("vUbicacion_custodia", MyVenta.ubicacion_custodia)
            .AddWithValue("vUsuario_custodia", MyVenta.usuario_custodia)
            .AddWithValue("vFecha_custodia", MyVenta.fecha_custodia)
            .AddWithValue("vReferencia_tipo", MyVenta.referencia_tipo)
            .AddWithValue("vReferencia_serie", MyVenta.referencia_serie)
            .AddWithValue("vReferencia_numero", MyVenta.referencia_numero)
            .AddWithValue("vReferencia_fecha", MyVenta.referencia_fecha)
            .AddWithValue("vIndica_exportacion", MyVenta.indica_exportacion)
            .AddWithValue("vOrigen", MyVenta.origen)
            .AddWithValue("vEstado", MyVenta.estado)
            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
            .AddWithValue("vLista_precio", MyVenta.lista_precio)
            .AddWithValue("vCentro_distribucion", MyVenta.centro_distribucion)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarDetalle(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal FilaDetalle As Integer, ByRef Linea As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO COM.VENTAS_PRO " & _
                      "(empresa,venta,linea,tipo_cambio,tipo_moneda,producto,numero_serie,cantidad,precio_unitario,importe_total_origen,usuario_registro) " &
                      "VALUES (" &
                      "@vEmpresa,@vVenta,@vLinea,@vTipo_cambio,@vTipo_moneda,@vProducto,@vNumero_serie,@vCantidad,@vPrecio_unitario,@vImporte_total_origen,@vUsuario_registro) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        Linea = Linea + 1

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyUsuario.empresa)
            .AddWithValue("vVenta", MyVenta.venta)
            .AddWithValue("vLinea", Linea.ToString("000"))
            .AddWithValue("vTipo_cambio", MyVenta.tipo_cambio)
            .AddWithValue("vTipo_moneda", MyVenta.tipo_moneda)
            .AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
            .AddWithValue("vNumero_serie", Space(1))
            .AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD)
            .AddWithValue("vPrecio_unitario", MyDetallesVenta(FilaDetalle).PRECIO_UNITARIO)
            .AddWithValue("vImporte_total_origen", MyDetallesVenta(FilaDetalle).IMPORTE_TOTAL)
            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarDetalleServicio(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal FilaDetalle As Integer, ByRef Linea As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO COM.VENTAS_SER" & _
                      "(empresa,venta,linea,descripcion,importe_total,usuario_registro) " &
                      "VALUES (" &
                      "@vEmpresa,@vVenta,@vLinea,@vDescripcion,@vImporte_total,@vUsuario_registro) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyUsuario.empresa)
            .AddWithValue("vVenta", MyVenta.venta)
            .AddWithValue("vLinea", Linea.ToString("000"))
            .AddWithValue("vDescripcion", MyDetallesVenta(FilaDetalle).DESCRIPCION_AMPLIADA)
            .AddWithValue("vImporte_total", MyDetallesVenta(FilaDetalle).IMPORTE_TOTAL)
            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarDetalleComponente(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal MyComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable, ByVal FilaDetalle As Integer, ByVal FilaComponente As Integer, ByVal Linea As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO COM.VENTAS_COM " & _
                      "(empresa,venta,linea,producto,numero_serie,cantidad,usuario_registro) " & _
                      "VALUES (" & _
                      "@vEmpresa,@vVenta,@vLinea,@vProducto,@vNumero_serie,@vCantidad,@vUsuario_registro) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyUsuario.empresa)
            .AddWithValue("vVenta", MyVenta.venta)
            .AddWithValue("vLinea", Linea.ToString("000"))
            .AddWithValue("vProducto", MyComponentes(FilaComponente).PRODUCTO)
            .AddWithValue("vNumero_serie", Space(1))
            .AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD * MyComponentes(FilaComponente).CANTIDAD)
            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarDetalleCompuesto(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal MyProductoComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable, ByVal FilaDetalle As Integer, ByVal Linea As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        Dim MyComponentes As New dsProductos.PRODUCTO_COMPONENTESDataTable
        For FilaComponente As Integer = 0 To MyProductoComponentes.Rows.Count - 1
            If MyProductoComponentes(FilaComponente).PRODUCTO_COMPUESTO = MyDetallesVenta(FilaDetalle).PRODUCTO Then
                MyComponentes.ImportRow(MyProductoComponentes(FilaComponente))
            End If
        Next

        If MyComponentes.Rows.Count <> 0 Then
            For FilaComponente As Integer = 0 To MyComponentes.Rows.Count - 1
                Call InsertarDetalleComponente(MyVenta, MyDetallesVenta, MyComponentes, FilaDetalle, FilaComponente, Linea, MySQLCommand)
                Call ActualizarResumenAlmacenPeriodo(MyVenta, MyDetallesVenta, MyComponentes, FilaDetalle, FilaComponente, MySQLCommand)
            Next
        End If
    End Sub

    Private Shared Sub InsertarVentaSerie(ByVal MyVenta As entVenta, ByVal MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, ByVal FilaDetalleSeries As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        MySQL_3 = "INSERT INTO COM.VENTAS_SERIES (empresa,venta,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " &
                  "VALUES (@vEmpresa,@vVenta,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

        MySQLCommand.CommandText = MySQL_3

        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
        MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(FilaDetalleSeries).PRODUCTO)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE_CHASIS)
        MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesVentaSeries(FilaDetalleSeries).COLOR)
        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarControlSerie(ByVal MyVenta As entVenta, ByVal MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, ByVal FilaDetalleSeries As Integer, EsNotaCredito As Boolean, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        If MyDetallesVentaSeries(FilaDetalleSeries).EXISTE_CONTROL_SERIES = "SI" Then
            If EsNotaCredito = True Then
                MySQL_4 = "UPDATE COM.CONTROL_SERIES SET Referencia_devolucion=@vReferencia,Fecha_devolucion=@vFecha,"
            Else
                MySQL_4 = "UPDATE COM.CONTROL_SERIES SET Referencia_venta=@vReferencia,Fecha_venta=@vFecha,"
            End If
            MySQL_4 = MySQL_4 & "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                      "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

            MySQLCommand.CommandText = MySQL_4
            MySQLCommand.Parameters.AddWithValue("vReferencia", MyVenta.venta)
            MySQLCommand.Parameters.AddWithValue("vFecha", MyVenta.comprobante_fecha)
            MySQLCommand.Parameters.AddWithValue("vEstado", IIf(EsNotaCredito = True, "D", "V"))
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(FilaDetalleSeries).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE)
        Else
            MySQL_4 = "INSERT INTO COM.CONTROL_SERIES " & _
                    "(empresa,producto,numero_serie,numero_serie_chasis,color,almacen,referencia_venta,fecha_venta,estado,usuario_registro) " & _
                    "VALUES " & _
                    "(@vEmpresa,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAlmacen,@vReferencia_venta,@vFecha_venta,@vEstado,@vUsuario_registro)"

            MySQLCommand.CommandText = MySQL_4
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(FilaDetalleSeries).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE_CHASIS)
            MySQLCommand.Parameters.AddWithValue("vColor", MyDetallesVentaSeries(FilaDetalleSeries).COLOR)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vReferencia_venta", MyVenta.venta)
            MySQLCommand.Parameters.AddWithValue("vFecha_venta", MyVenta.comprobante_fecha)
            MySQLCommand.Parameters.AddWithValue("vEstado", "V")
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End If
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarVentaVehiculo(ByVal MyVenta As entVenta, ByVal MyVentaVehiculo As dsVentas.VENTAS_VEHICULOSDataTable, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        MySQL_4 = "INSERT INTO COM.VENTAS_VEHICULOS " & _
                  "(EMPRESA, VENTA, PRODUCTO, NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR, AÑO_FABRICACION, MARCA, MODELO, CAPACIDAD_MOTOR, NUMERO_CILINDROS, POTENCIA_HP, " &
                  "POTENCIA_KW, TORQUE_NM, TORQUE_RPM, NUMERO_RPM, PESO_NETO, CARGA_UTIL, PESO_BRUTO, NUMERO_ASIENTOS, NUMERO_PASAJEROS, NUMERO_RUEDAS, NUMERO_EJES, COMBUSTIBLE, " &
                  "LONGITUD_LARGO, LONGITUD_ANCHO, LONGITUD_ALTURA, POLIZA_NUMERO, POLIZA_AÑO, POLIZA_ITEM, POLIZA_IPL, CATEGORIA_VEHICULAR, NUMERO_VIN, USUARIO_REGISTRO) " &
                  "VALUES (@vEmpresa,@vVenta,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vAño_fabricacion, @vMarca, @vModelo, @vCapacidad_motor," &
                  "@vNumero_cilindros, @vPotencia_hp, @vPotencia_kw, @vTorque_nm, @vTorque_rpm, @vNumero_rpm, @vPeso_neto, @vCarga_util, @vPeso_bruto, " &
                  "@vNumero_asientos, @vNumero_pasajeros, @vNumero_ruedas, @vNumero_ejes, @vCombustible, @vLongitud_largo, @vLongitud_ancho, " &
                  "@vLongitud_altura, @vPoliza_numero, @vPoliza_año, @vPoliza_item, @vPoliza_ipl, @vCategoria_vehicular, @vNumero_vin, @vUsuario_registro)"

        MySQLCommand.CommandText = MySQL_4

        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
        MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
        MySQLCommand.Parameters.AddWithValue("vProducto", MyVentaVehiculo(0).PRODUCTO)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyVentaVehiculo(0).NUMERO_SERIE)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie_chasis", MyVentaVehiculo(0).NUMERO_SERIE_CHASIS)
        MySQLCommand.Parameters.AddWithValue("vColor", MyVentaVehiculo(0).COLOR)
        MySQLCommand.Parameters.AddWithValue("vAño_fabricacion", MyVentaVehiculo(0).AÑO_FABRICACION)
        MySQLCommand.Parameters.AddWithValue("vMarca", MyVentaVehiculo(0).MARCA)
        MySQLCommand.Parameters.AddWithValue("vModelo", MyVentaVehiculo(0).MODELO)
        MySQLCommand.Parameters.AddWithValue("vCapacidad_motor", MyVentaVehiculo(0).CAPACIDAD_MOTOR)
        MySQLCommand.Parameters.AddWithValue("vNumero_cilindros", MyVentaVehiculo(0).NUMERO_CILINDROS)
        MySQLCommand.Parameters.AddWithValue("vPotencia_hp", MyVentaVehiculo(0).POTENCIA_HP)
        MySQLCommand.Parameters.AddWithValue("vPotencia_kw", MyVentaVehiculo(0).POTENCIA_KW)
        MySQLCommand.Parameters.AddWithValue("vTorque_nm", MyVentaVehiculo(0).TORQUE_NM)
        MySQLCommand.Parameters.AddWithValue("vTorque_rpm", MyVentaVehiculo(0).TORQUE_RPM)
        MySQLCommand.Parameters.AddWithValue("vNumero_rpm", MyVentaVehiculo(0).NUMERO_RPM)
        MySQLCommand.Parameters.AddWithValue("vPeso_neto", MyVentaVehiculo(0).PESO_NETO)
        MySQLCommand.Parameters.AddWithValue("vCarga_util", MyVentaVehiculo(0).CARGA_UTIL)
        MySQLCommand.Parameters.AddWithValue("vPeso_bruto", MyVentaVehiculo(0).PESO_BRUTO)
        MySQLCommand.Parameters.AddWithValue("vNumero_asientos", MyVentaVehiculo(0).NUMERO_ASIENTOS)
        MySQLCommand.Parameters.AddWithValue("vNumero_pasajeros", MyVentaVehiculo(0).NUMERO_PASAJEROS)
        MySQLCommand.Parameters.AddWithValue("vNumero_ruedas", MyVentaVehiculo(0).NUMERO_RUEDAS)
        MySQLCommand.Parameters.AddWithValue("vNumero_ejes", MyVentaVehiculo(0).NUMERO_EJES)
        MySQLCommand.Parameters.AddWithValue("vCombustible", MyVentaVehiculo(0).COMBUSTIBLE)
        MySQLCommand.Parameters.AddWithValue("vLongitud_largo", MyVentaVehiculo(0).LONGITUD_LARGO)
        MySQLCommand.Parameters.AddWithValue("vLongitud_ancho", MyVentaVehiculo(0).LONGITUD_ANCHO)
        MySQLCommand.Parameters.AddWithValue("vLongitud_altura", MyVentaVehiculo(0).LONGITUD_ALTURA)
        MySQLCommand.Parameters.AddWithValue("vPoliza_numero", MyVentaVehiculo(0).POLIZA_NUMERO)
        MySQLCommand.Parameters.AddWithValue("vPoliza_año", MyVentaVehiculo(0).POLIZA_AÑO)
        MySQLCommand.Parameters.AddWithValue("vPoliza_item", MyVentaVehiculo(0).POLIZA_ITEM)
        MySQLCommand.Parameters.AddWithValue("vPoliza_ipl", MyVentaVehiculo(0).POLIZA_IPL)
        MySQLCommand.Parameters.AddWithValue("vCategoria_vehicular", MyVentaVehiculo(0).CATEGORIA_VEHICULAR)
        MySQLCommand.Parameters.AddWithValue("vNumero_vin", MyVentaVehiculo(0).NUMERO_VIN)
        MySQLCommand.Parameters.AddWithValue("vEstado", "A")
        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub InsertarCuotaInicial(ByVal MyVenta As entVenta, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        MySQL_4 = "INSERT INTO COM.VENTAS_INI " & _
                  "(EMPRESA, VENTA, CUOTA_INICIAL, CUOTA_INICIAL_PAGO, USUARIO_REGISTRO) " &
                  "VALUES (@vEmpresa,@vVenta,@vCuota_inicial, @vCuota_inicial_pago, @vUsuario_registro)"

        MySQLCommand.CommandText = MySQL_4

        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
        MySQLCommand.Parameters.AddWithValue("vVenta", MyVenta.venta)
        MySQLCommand.Parameters.AddWithValue("vCuota_inicial", MyVenta.cuota_inicial)
        MySQLCommand.Parameters.AddWithValue("vCuota_inicial_pago", MyVenta.cuota_inicial_pagada)
        MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub ActualizarControlVehiculo(ByVal MyVenta As entVenta, ByVal MyDetallesVentaSeries As dsVentas.VENTA_DET_SERIESDataTable, ByVal FilaDetalleSeries As Integer, EsNotaCredito As Boolean, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        MySQL_4 = "UPDATE COM.CONTROL_VEHICULOS SET " & _
                  "Estado=@vEstado,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                  "WHERE Empresa=@vEmpresa AND Producto=@vProducto AND Numero_serie=@vNumero_serie "

        MySQLCommand.CommandText = MySQL_4
        MySQLCommand.Parameters.AddWithValue("vEstado", IIf(EsNotaCredito = True, "D", "V"))
        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVentaSeries(FilaDetalleSeries).PRODUCTO)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie", MyDetallesVentaSeries(FilaDetalleSeries).NUMERO_SERIE)
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub ActualizarResumenAlmacenPeriodo(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal FilaDetalle As Integer, ByVal EsIngreso As Boolean, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        If MyDetallesVenta(FilaDetalle).EXISTE_RESUMEN_ALMACEN = "SI" Then
            If EsIngreso = True Then
                MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Ingresos=Ingresos+@vCantidad, Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() "
            Else
                MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos+@vCantidad, Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() "
            End If
            MySQL_2 = MySQL_2 & " WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

            MySQLCommand.CommandText = MySQL_2
            MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
        Else
            MySQL_2 = "INSERT INTO ALM.RESUMEN_X_ALMACEN (empresa,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " &
                      "VALUES (@vEmpresa,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

            MySQLCommand.CommandText = MySQL_2
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(EsIngreso = True, MyDetallesVenta(FilaDetalle).CANTIDAD, 0))
            MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(EsIngreso = True, 0, MyDetallesVenta(FilaDetalle).CANTIDAD))
            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End If
        MySQLCommand.ExecuteNonQuery()

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        If MyDetallesVenta(FilaDetalle).EXISTE_RESUMEN_PERIODO = "SI" Then
            If EsIngreso = True Then
                MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Ingresos=Ingresos+@vCantidad,"
            Else
                MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos+@vCantidad,"
            End If
            MySQL_3 = MySQL_3 & " Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

            MySQLCommand.CommandText = MySQL_3
            MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
        Else
            MySQL_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO (empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                      "VALUES (@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

            MySQLCommand.CommandText = MySQL_3
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vIngresos", IIf(EsIngreso = True, MyDetallesVenta(FilaDetalle).CANTIDAD, 0))
            MySQLCommand.Parameters.AddWithValue("vEgresos", IIf(EsIngreso = True, 0, MyDetallesVenta(FilaDetalle).CANTIDAD))
            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End If
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub ActualizarResumenAlmacenPeriodo(ByVal MyVenta As entVenta, ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal MyComponentes As dsProductos.PRODUCTO_COMPONENTESDataTable, ByVal FilaDetalle As Integer, ByVal FilaComponente As Integer, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        If MyComponentes(FilaComponente).EXISTE_RESUMEN_ALMACEN = "SI" Then
            MySQL_2 = "UPDATE ALM.RESUMEN_X_ALMACEN SET Egresos=Egresos+@vCantidad," & _
                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

            MySQLCommand.CommandText = MySQL_2
            MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD * MyComponentes(FilaComponente).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(FilaComponente).PRODUCTO)
        Else
            MySQL_2 = "INSERT INTO ALM.RESUMEN_X_ALMACEN " & _
                      "(empresa,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                      "VALUES " & _
                      "(@vEmpresa,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

            MySQLCommand.CommandText = MySQL_2
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(FilaComponente).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
            MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesVenta(FilaDetalle).CANTIDAD * MyComponentes(FilaComponente).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End If
        MySQLCommand.ExecuteNonQuery()

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        If MyComponentes(FilaComponente).EXISTE_RESUMEN_PERIODO = "SI" Then
            MySQL_3 = "UPDATE ALM.RESUMEN_X_PERIODO SET Egresos=Egresos+@vCantidad," & _
                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "

            MySQLCommand.CommandText = MySQL_3
            MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD * MyComponentes(FilaComponente).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(FilaComponente).PRODUCTO)
        Else
            MySQL_3 = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                    "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                    "VALUES " & _
                    "(@vEmpresa,@vEjercicio,@vMes,@vAlmacen,@vNumero_lote,@vProducto,@vIngresos,@vEgresos,@vFecha_vencimiento,@vUsuario_registro)"

            MySQLCommand.CommandText = MySQL_3
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", MyVenta.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", MyVenta.mes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyVenta.almacen)
            MySQLCommand.Parameters.AddWithValue("vNumero_lote", "0000000000")
            MySQLCommand.Parameters.AddWithValue("vProducto", MyComponentes(FilaComponente).PRODUCTO)
            MySQLCommand.Parameters.AddWithValue("vIngresos", 0)
            MySQLCommand.Parameters.AddWithValue("vEgresos", MyDetallesVenta(FilaDetalle).CANTIDAD * MyComponentes(FilaComponente).CANTIDAD)
            MySQLCommand.Parameters.AddWithValue("vFecha_vencimiento", FechaNulo)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End If
        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub ActualizarCantidadDevuelta(ByVal MyDetallesVenta As dsVentas.VENTA_DETDataTable, ByVal FilaDetalle As Integer, ByVal MyReferenciaVenta As String, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.Parameters.Clear()

        MySQL_2 = "UPDATE COM.VENTAS_PRO SET Cantidad_devuelta=Cantidad_devuelta+@vCantidad," & _
                  "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                  "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Numero_serie=@vNumero_serie AND Producto=@vProducto "

        MySQLCommand.CommandText = MySQL_2
        MySQLCommand.Parameters.AddWithValue("vCantidad", MyDetallesVenta(FilaDetalle).CANTIDAD)
        MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
        MySQLCommand.Parameters.AddWithValue("vVenta", MyReferenciaVenta)
        MySQLCommand.Parameters.AddWithValue("vNumero_serie", Space(1))
        MySQLCommand.Parameters.AddWithValue("vProducto", MyDetallesVenta(FilaDetalle).PRODUCTO)
        MySQLCommand.ExecuteNonQuery()
    End Sub

#End Region

#Region "Insertar Separaciones"

    Private Shared Sub InsertarSeparacion(ByVal MySeparacion As entVenta, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO COM.SEPARACIONES " & _
                      "(empresa,separacion,ejercicio,mes,cuenta_comercial,tipo_moneda,almacen,base_imponible_gravada_origen,igv_origen,importe_total_origen," & _
                      "importe_saldo,comentario,codigo_vendedor,estado,usuario_registro) " & _
                      "VALUES (" & _
                      "@vEmpresa,@vSeparacion,@vEjercicio,@vMes,@vCuenta_comercial,@vTipo_moneda,@vAlmacen,@vBase_imponible_gravada_origen,@vIgv_origen,@vImporte_total_origen," & _
                      "@vImporte_saldo,@vComentario,@vCodigo_vendedor,@vEstado,@vUsuario_registro) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyUsuario.empresa)
            .AddWithValue("vSeparacion", MySeparacion.venta)
            .AddWithValue("vEjercicio", MySeparacion.ejercicio)
            .AddWithValue("vMes", MySeparacion.mes)
            .AddWithValue("vCuenta_comercial", MySeparacion.cuenta_comercial.Trim)
            .AddWithValue("vTipo_moneda", MySeparacion.tipo_moneda)
            .AddWithValue("vAlmacen", MySeparacion.almacen)
            .AddWithValue("vBase_imponible_gravada_origen", MySeparacion.base_imponible_gravada_origen)
            .AddWithValue("vIgv_origen", MySeparacion.igv_origen)
            .AddWithValue("vImporte_total_origen", MySeparacion.importe_total_origen)
            .AddWithValue("vImporte_saldo", MySeparacion.importe_saldo)
            .AddWithValue("vComentario", MySeparacion.comentario)
            .AddWithValue("vCodigo_vendedor", MySeparacion.codigo_vendedor)
            .AddWithValue("vEstado", MySeparacion.estado)
            .AddWithValue("vUsuario_registro", MyUsuario.usuario)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub


#End Region

End Class
