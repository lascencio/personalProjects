Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Net

Public Class dalVenta
    Private Shared MyOtraVenta As entVenta
    Private Shared MySQL As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String

    Public Shared Function BuscarVentasAud(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String, ByVal pComprobanteTipo As String) As dsVentas.VENTAS_LISTA_AUDIDataTable
        MyStoreProcedure = "COM.VENTAS_LISTA_AUDI"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.VarChar, 18) : MyParameter_4.Value = pCuentaComercial
        Dim MyParameter_5 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_5.Value = pComprobanteTipo

        Dim MyDT As New dsVentas.VENTAS_LISTA_AUDIDataTable

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

    Public Shared Function BuscarVentas(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String, ByVal pComprobanteTipo As String) As dsVentas.VENTAS_LISTADataTable
        MyStoreProcedure = "COM.VENTAS_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.VarChar, 18) : MyParameter_4.Value = pCuentaComercial
        Dim MyParameter_5 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_5.Value = pComprobanteTipo

        Dim MyDT As New dsVentas.VENTAS_LISTADataTable

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

    Public Shared Function BuscarVentasDia(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, pDia As Integer) As dsVentas.VENTAS_LISTADataTable
        MyStoreProcedure = "COM.VENTAS_LISTA_DIA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@DIA", SqlDbType.Int) : MyParameter_4.Value = pDia

        Dim MyDT As New dsVentas.VENTAS_LISTADataTable

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

    Public Shared Function ObtenerDatosRUC(ByVal pCuentaComercial As String) As dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
        MyStoreProcedure = "GEN.CONSULTAR_DATOS_RUC"
        Dim MyParameter_1 As New SqlParameter("@RUC", SqlDbType.Char, 11) : MyParameter_1.Value = pCuentaComercial

        Dim MyDT As New dsPadronReducidoRUC.CONSULTAR_DATOS_RUCDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Consulta_RUC)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
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
                .codigo_domicilio = MyDT(0).CODIGO_DOMICILIO
                .valor_exportacion_origen = MyDT(0).VALOR_EXPORTACION_ORIGEN
                .base_imponible_gravada_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA_ORIGEN
                .importe_exonerado_origen = MyDT(0).IMPORTE_EXONERADO_ORIGEN
                .importe_inafecto_origen = MyDT(0).IMPORTE_INAFECTO_ORIGEN
                .isc_origen = MyDT(0).ISC_ORIGEN
                .igv_origen = MyDT(0).IGV_ORIGEN
                .ipm_origen = MyDT(0).IPM_ORIGEN
                .base_imponible_gravada2_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ORIGEN
                .igv2_origen = MyDT(0).IGV2_ORIGEN
                .otros_tributos_origen = MyDT(0).OTROS_TRIBUTOS_ORIGEN
                .descuento_global_origen = MyDT(0).DESCUENTO_GLOBAL_ORIGEN
                .importe_total_origen = MyDT(0).IMPORTE_TOTAL_ORIGEN
                .valor_exportacion_mn = MyDT(0).VALOR_EXPORTACION_MN
                .base_imponible_gravada_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA_MN
                .importe_exonerado_mn = MyDT(0).IMPORTE_EXONERADO_MN
                .importe_inafecto_mn = MyDT(0).IMPORTE_INAFECTO_MN
                .isc_mn = MyDT(0).ISC_MN
                .igv_mn = MyDT(0).IGV_MN
                .ipm_mn = MyDT(0).IPM_MN
                .base_imponible_gravada2_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA2_MN
                .igv2_mn = MyDT(0).IGV2_MN
                .otros_tributos_mn = MyDT(0).OTROS_TRIBUTOS_MN
                .descuento_global_mn = MyDT(0).DESCUENTO_GLOBAL_MN
                .importe_total_mn = MyDT(0).IMPORTE_TOTAL_MN
                .valor_exportacion_me = MyDT(0).VALOR_EXPORTACION_ME
                .base_imponible_gravada_me = MyDT(0).BASE_IMPONIBLE_GRAVADA_ME
                .importe_exonerado_me = MyDT(0).IMPORTE_EXONERADO_ME
                .importe_inafecto_me = MyDT(0).IMPORTE_INAFECTO_ME
                .isc_me = MyDT(0).ISC_ME
                .igv_me = MyDT(0).IGV_ME
                .ipm_me = MyDT(0).IPM_ME
                .base_imponible_gravada2_me = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ME
                .igv2_me = MyDT(0).IGV2_ME
                .otros_tributos_me = MyDT(0).OTROS_TRIBUTOS_ME
                .descuento_global_me = MyDT(0).DESCUENTO_GLOBAL_ME
                .importe_total_me = MyDT(0).IMPORTE_TOTAL_ME
                .referencia_cuo = MyDT(0).REFERENCIA_CUO
                .condicion_pago = MyDT(0).CONDICION_PAGO
                If Not MyDT(0).IsNull("FECHA_ULTIMO_PAGO") Then .fecha_ultimo_pago = MyDT(0).FECHA_ULTIMO_PAGO
                .importe_saldo = MyDT(0).IMPORTE_SALDO
                .comentario = MyDT(0).COMENTARIO
                .tipo_venta = MyDT(0).TIPO_VENTA
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_cobrador = MyDT(0).CODIGO_COBRADOR
                .contacto_venta = MyDT(0).CONTACTO_VENTA
                .contacto_compra = MyDT(0).CONTACTO_COMPRA
                .centro_costo = MyDT(0).CENTRO_COSTO
                .letra = MyDT(0).LETRA
                .factoring = MyDT(0).FACTORING
                .planilla_cobranza = MyDT(0).PLANILLA_COBRANZA
                .guia_remitente = MyDT(0).GUIA_REMITENTE
                .guia_transportista = MyDT(0).GUIA_TRANSPORTISTA
                .orden_venta = MyDT(0).ORDEN_VENTA
                .orden_compra = MyDT(0).ORDEN_COMPRA
                .orden_pago = MyDT(0).ORDEN_PAGO
                .usuario_envio = MyDT(0).USUARIO_ENVIO
                If Not MyDT(0).IsNull("FECHA_ENVIO") Then .fecha_envio = MyDT(0).FECHA_ENVIO
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
                .tipo_operacion = MyDT(0).TIPO_OPERACION
                .referencia_tipo = MyDT(0).REFERENCIA_TIPO
                .referencia_serie = MyDT(0).REFERENCIA_SERIE
                .referencia_numero = MyDT(0).REFERENCIA_NUMERO
                If Not MyDT(0).IsNull("REFERENCIA_FECHA") Then .referencia_fecha = MyDT(0).REFERENCIA_FECHA
                .indica_exportacion = MyDT(0).INDICA_EXPORTACION
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cVenta
    End Function

    Private Shared Function Existe(ByVal pVenta As String) As Boolean
        If Not String.IsNullOrEmpty(pVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.VENTAS WHERE Empresa=@vEmpresa AND Venta=@vVenta"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
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

    Public Shared Function BuscarVentaDetalles(ByVal pEmpresa As String, ByVal pVenta As String) As dsVentasDetalleLista.VENTAS_DET_LISTADataTable
        MyStoreProcedure = "COM.VENTAS_DET_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@VENTA", SqlDbType.Char, 12) : MyParameter_2.Value = pVenta

        Dim MyDT As New dsVentasDetalleLista.VENTAS_DET_LISTADataTable
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

    Public Shared Function ObtenerVentaServicio(ByVal pVenta As String) As dsVentas.VENTAS_SERDataTable
        Dim MyDT As New dsVentas.VENTAS_SERDataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS_DET WHERE EMPRESA='" & MyUsuario.empresa & "' AND VENTA='" & pVenta & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobanteCliente(ByVal pOrdenCompra As String) As dsComprobantesCliente.COMPROBANTESDataTable
        Dim MyDT As New dsComprobantesCliente.COMPROBANTESDataTable
        CadenaSQL = "SELECT * FROM COM.COMPROBANTES WHERE ComprobanteId='" & pOrdenCompra & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function



#Region "EComprobante"

    Public Shared Function ComprobantesInforme(ByVal pFechaDesde As String, ByVal pFechaHasta As String, pCuentaComercial As String, pTipoComprobante As String) As dsVentas.VENTAS_LISTADataTable

        MySQL = "SELECT * FROM COM.REPORTE_COMPROBANTES " & _
                "WHERE (CAST(FECHA_ENVIO AS date) BETWEEN '" & pFechaDesde & "' AND '" & pFechaHasta & "') " & _
                IIf(pCuentaComercial.Trim.Length = 0, " ", " AND CUENTA_COMERCIAL='" & pCuentaComercial & "' ") & " " & _
                IIf(pTipoComprobante = "TODOS", " ", " AND COMPROBANTE_TIPO='" & pTipoComprobante & "' ") & _
                "ORDER BY FECHA_ENVIO "

        Dim MyDT As New dsVentas.VENTAS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDetalles(ByVal pEmpresa As String, pVenta As String) As dsVentas.ECOMPROBANTE_SERVICIOSDataTable
        If ExisteGlosa(pEmpresa, pVenta) Then
            MyStoreProcedure = "COM.ECOMPROBANTE_GLOSA"
        Else
            MyStoreProcedure = "COM.ECOMPROBANTE_SERVICIOS"
        End If
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@VENTA", SqlDbType.Char, 12) : MyParameter_2.Value = pVenta

        Dim MyDT As New dsVentas.ECOMPROBANTE_SERVICIOSDataTable
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

    Public Shared Function ObtenerDetallesFacturasGlobales(ByVal pEmpresa As String, pVenta As String) As dsVentas.ECOMPROBANTE_SERVICIOSDataTable
        Dim MyDT As New dsVentas.ECOMPROBANTE_SERVICIOSDataTable
        CadenaSQL = "SELECT EMPRESA, VENTA, LINEA, 1 AS ORDEN, SUBSTRING(RTRIM(GLOSA_1),28,10) AS GLOSA, 1 AS CANTIDAD, 0 AS VALOR_VENTA, 0 AS IGV, 0 AS PRECIO_VENTA, 'SI' ES_ULTIMO " & _
                    "FROM COM.VENTAS_SER " & _
                    "WHERE EMPRESA='" & pEmpresa & "' AND VENTA='" & pVenta & "' " & _
                    "ORDER BY  RIGHT(RTRIM(GLOSA_1),10) "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerDatos(ByVal pTransaccionDocumentoId As String) As dsVentas.VENTAS_DATOSDataTable
        MyStoreProcedure = "COM.ECOMPROBANTE_DATOS"
        Dim MyParameter_1 As New SqlParameter("@TransaccionDocumentoId", SqlDbType.NVarChar, 20) : MyParameter_1.Value = pTransaccionDocumentoId

        Dim MyDT As New dsVentas.VENTAS_DATOSDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ExisteEComprobante(ByVal cEmpresa As String, cSerie As String, cNumero As String, cTipo As String) As Boolean
        If Not String.IsNullOrEmpty(cNumero) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES WHERE Empresa=@vEmpresa AND COMPROBANTE_SERIE=@vSerie AND COMPROBANTE_NUMERO=@vNumero AND COMPROBANTE_TIPO=@vTipo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
                MySQLCommand.Parameters.AddWithValue("vSerie", cSerie)
                MySQLCommand.Parameters.AddWithValue("vNumero", cNumero)
                MySQLCommand.Parameters.AddWithValue("vTipo", cTipo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function ExisteEComprobanteFirma(ByVal cEmpresa As String, cVenta As String) As Boolean
        If Not String.IsNullOrEmpty(cVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cVenta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cEComprobante As entEComprobante) As Boolean
        If Not String.IsNullOrEmpty(cEComprobante.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES " & _
                          "WHERE Empresa=@vEmpresa AND Cuenta_comercial=@vCuenta_comercial AND " & _
                          "Comprobante_tipo=@vComprobante_tipo AND Comprobante_serie=@vComprobante_serie AND " & _
                          "Comprobante_numero=@vComprobante_numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEComprobante.empresa)
                MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial)
                MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                MySQLCommand.Parameters.AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                MySQLCommand.Parameters.AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cEComprobanteFirma As entEComprobanteFirma) As Boolean
        If Not String.IsNullOrEmpty(cEComprobanteFirma.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cEComprobanteFirma.venta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteGlosa(ByVal cVentaGlosa As entVentaGlosa) As Boolean
        MySQLString = "SELECT COUNT(*) FROM COM.VENTAS_GLOSA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cVentaGlosa.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", cVentaGlosa.venta)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function ExisteGlosa(ByVal cEmpresa As String, cVenta As String) As Boolean
        MySQLString = "SELECT COUNT(*) FROM COM.VENTAS_GLOSA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", cVenta)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Obtener(ByVal cEComprobante As dsVentas.ECOMPROBANTESDataTable) As dsVentas.ECOMPROBANTESDataTable
        Dim MyDT As New dsVentas.ECOMPROBANTESDataTable
        If ExisteEComprobante(cEComprobante(0).EMPRESA, cEComprobante(0).COMPROBANTE_SERIE, cEComprobante(0).COMPROBANTE_NUMERO, cEComprobante(0).COMPROBANTE_TIPO) Then
            With cEComprobante(0)
                CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES " & _
                            "WHERE Empresa='" & .EMPRESA & "' AND Cuenta_comercial='" & .CUENTA_COMERCIAL & "' AND " & _
                            "Comprobante_tipo='" & .COMPROBANTE_TIPO & "' AND Comprobante_serie='" & .COMPROBANTE_SERIE & "' AND " & _
                            "Comprobante_numero='" & .COMPROBANTE_NUMERO & "' "
            End With
            Call ObtenerDataTableSQL_EComprobantes(CadenaSQL, MyDT)
        End If
        Return MyDT
    End Function

    Public Shared Function Obtener(cEmpresa As String, cVenta As String) As entEComprobanteFirma
        If ExisteEComprobanteFirma(cEmpresa, cVenta) Then
            CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa='" & cEmpresa & "' AND Venta='" & cVenta & "' "
            Return Obtener(New entEComprobanteFirma, CadenaSQL)
        Else
            Return New entEComprobanteFirma
        End If
    End Function

    Public Shared Function Obtener(ByVal cEComprobante As entEComprobante) As entEComprobante
        If Existe(cEComprobante) Then
            With cEComprobante
                CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES " & _
                            "WHERE Empresa='" & .empresa & "' AND Cuenta_comercial='" & .cuenta_comercial & "' AND " & _
                            "Comprobante_tipo='" & .comprobante_tipo & "' AND Comprobante_serie='" & .comprobante_serie & "' AND " & _
                            "Comprobante_numero='" & .comprobante_numero & "' "
            End With
            Return Obtener(New entEComprobante, CadenaSQL)
        Else
            Return New entEComprobante
        End If
    End Function

    Private Shared Function Obtener(ByVal cEComprobante As entEComprobante, ByVal MySQLString As String) As entEComprobante
        Dim MyDT As New dsVentas.ECOMPROBANTESDataTable
        Call ObtenerDataTableSQL_EComprobantes(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cEComprobante
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .comprobante_tipo = MyDT(0).COMPROBANTE_TIPO
                .comprobante_serie = MyDT(0).COMPROBANTE_SERIE
                .comprobante_numero = MyDT(0).COMPROBANTE_NUMERO
                .comprobante_fecha = MyDT(0).COMPROBANTE_FECHA
                .comprobante_vencimiento = MyDT(0).COMPROBANTE_VENCIMIENTO
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .dia = MyDT(0).DIA
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .moneda = MyDT(0).MONEDA
                .valor_exportacion = MyDT(0).VALOR_EXPORTACION
                .base_imponible_gravada = MyDT(0).BASE_IMPONIBLE_GRAVADA
                .importe_exonerado = MyDT(0).IMPORTE_EXONERADO
                .importe_inafecto = MyDT(0).IMPORTE_INAFECTO
                .isc = MyDT(0).ISC
                .igv = MyDT(0).IGV
                .ipm = MyDT(0).IPM
                .base_imponible_gravada2 = MyDT(0).BASE_IMPONIBLE_GRAVADA2
                .igv2 = MyDT(0).IGV2
                .otros_tributos = MyDT(0).OTROS_TRIBUTOS
                .descuento_global = MyDT(0).DESCUENTO_GLOBAL
                .importe_total = MyDT(0).IMPORTE_TOTAL
                .referencia_tipo = MyDT(0).REFERENCIA_TIPO
                .referencia_serie = MyDT(0).REFERENCIA_SERIE
                .referencia_numero = MyDT(0).REFERENCIA_NUMERO
                If Not MyDT(0).IsNull("REFERENCIA_FECHA") Then .referencia_fecha = MyDT(0).REFERENCIA_FECHA
                .nombre_archivo = MyDT(0).NOMBRE_ARCHIVO
                .usuario_envio = MyDT(0).USUARIO_ENVIO
                .fecha_envio = MyDT(0).FECHA_ENVIO
                .estado_ticket = MyDT(0).ESTADO_TICKET
                .estado_comprobante = MyDT(0).ESTADO_COMPROBANTE
                .email_contacto = MyDT(0).EMAIL_CONTACTO
                .email_facturacion = MyDT(0).EMAIL_FACTURACION
                .usuario_descarga_web = MyDT(0).USUARIO_DESCARGA_WEB
                .fecha_descarga_web = MyDT(0).FECHA_DESCARGA_WEB
                .venta = MyDT(0).VENTA
                .razon_social = MyDT(0).RAZON_SOCIAL
                .mensaje = MyDT(0).MENSAJE
                .digest_value = MyDT(0).DIGEST_VALUE
                .signature_value = MyDT(0).SIGNATURE_VALUE
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cEComprobante
    End Function

    Private Shared Function Obtener(ByVal cEComprobanteFirma As entEComprobanteFirma, ByVal MySQLString As String) As entEComprobanteFirma
        Dim MyDT As New dsVentas.ECOMPROBANTES_FIRMADataTable
        Call ObtenerDataTableSQL_EComprobantes(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cEComprobanteFirma
                .empresa = MyDT(0).EMPRESA
                .venta = MyDT(0).VENTA
                .digest_value = MyDT(0).DIGEST_VALUE
                .signature_value = MyDT(0).SIGNATURE_VALUE
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cEComprobanteFirma
    End Function

    Public Shared Function ObtenerGlosa(pEmpresa As String, ByVal pVenta As String) As entVentaGlosa
        If ExisteGlosa(pEmpresa, pVenta) Then
            CadenaSQL = "SELECT * FROM COM.VENTAS_GLOSA WHERE EMPRESA='" & pEmpresa & "' AND VENTA='" & pVenta & "'"
            Return ObtenerGlosa(New entVentaGlosa, CadenaSQL)
        Else
            Return New entVentaGlosa
        End If
    End Function

    Private Shared Function ObtenerGlosa(ByVal cVentaGlosa As entVentaGlosa, ByVal MySQLString As String) As entVentaGlosa
        Dim MyDT As New dsVentas.VENTAS_GLOSADataTable
        Call ObtenerDataTableSQL(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cVentaGlosa
                .empresa = MyDT(0).EMPRESA
                .venta = MyDT(0).VENTA
                .linea = MyDT(0).LINEA
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .glosa_1 = MyDT(0).GLOSA_1
                .glosa_2 = MyDT(0).GLOSA_2
                .glosa_3 = MyDT(0).GLOSA_3
                .glosa_4 = MyDT(0).GLOSA_4
                .valor_venta_origen = MyDT(0).VALOR_VENTA_ORIGEN
                .centro_costo = MyDT(0).CENTRO_COSTO
                .proyecto = MyDT(0).PROYECTO
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cVentaGlosa
    End Function

    Public Shared Sub Grabar(ByVal cEComprobante As entEComprobante)
        If Not Existe(cEComprobante) Then
            Insertar(cEComprobante)
        End If
    End Sub

    Public Shared Sub GrabarError(ByVal cEComprobante As entEComprobante)
        InsertarError(cEComprobante)
    End Sub

    Private Shared Function Insertar(ByVal cEComprobante As entEComprobante) As entEComprobante
        MySQL = "INSERT INTO COM.ECOMPROBANTES " & _
                "(empresa,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero,comprobante_fecha,comprobante_vencimiento," & _
                "ejercicio,mes,dia,tipo_cambio,moneda,valor_exportacion,base_imponible_gravada,importe_exonerado,importe_inafecto,isc,igv,ipm," & _
                "base_imponible_gravada2,igv2,otros_tributos,descuento_global,importe_total,referencia_tipo,referencia_serie,referencia_numero,referencia_fecha," & _
                "nombre_archivo,usuario_envio,fecha_envio,estado_ticket,estado_comprobante,email_contacto,email_facturacion,venta, razon_social," & _
                "mensaje,digest_value,signature_value,usuario_registro) " & _
                "VALUES (@vEmpresa,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento," & _
                "@vEjercicio,@vMes,@vDia,@vTipo_cambio,@vMoneda,@vValor_exportacion,@vBase_imponible_gravada,@vImporte_exonerado,@vImporte_inafecto,@vIsc,@vIgv,@vIpm," & _
                "@vBase_imponible_gravada2,@vIgv2,@vOtros_tributos,@vDescuento_global,@vImporte_total,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero,@vReferencia_fecha," & _
                "@vNombre_archivo,@vUsuario_envio,@vFecha_envio,@vEstado_ticket,@vEstado_comprobante,@vEmail_contacto,@vEmail_facturacion,@vVenta,@vRazon_social," & _
                "@vMensaje,@vDigest_value,@vSignature_value,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobante.empresa)
                .AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial.Trim)
                .AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                .AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                .AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                .AddWithValue("vComprobante_fecha", cEComprobante.comprobante_fecha)
                .AddWithValue("vComprobante_vencimiento", cEComprobante.comprobante_vencimiento)
                .AddWithValue("vEjercicio", cEComprobante.ejercicio)
                .AddWithValue("vMes", cEComprobante.mes)
                .AddWithValue("vDia", cEComprobante.dia)
                .AddWithValue("vTipo_cambio", cEComprobante.tipo_cambio)
                .AddWithValue("vMoneda", cEComprobante.moneda)
                .AddWithValue("vValor_exportacion", cEComprobante.valor_exportacion)
                .AddWithValue("vBase_imponible_gravada", cEComprobante.base_imponible_gravada)
                .AddWithValue("vImporte_exonerado", cEComprobante.importe_exonerado)
                .AddWithValue("vImporte_inafecto", cEComprobante.importe_inafecto)
                .AddWithValue("vIsc", cEComprobante.isc)
                .AddWithValue("vIgv", cEComprobante.igv)
                .AddWithValue("vIpm", cEComprobante.ipm)
                .AddWithValue("vBase_imponible_gravada2", cEComprobante.base_imponible_gravada2)
                .AddWithValue("vIgv2", cEComprobante.igv2)
                .AddWithValue("vOtros_tributos", cEComprobante.otros_tributos)
                .AddWithValue("vDescuento_global", cEComprobante.descuento_global)
                .AddWithValue("vImporte_total", cEComprobante.importe_total)
                .AddWithValue("vReferencia_tipo", cEComprobante.referencia_tipo)
                .AddWithValue("vReferencia_serie", cEComprobante.referencia_serie)
                .AddWithValue("vReferencia_numero", cEComprobante.referencia_numero)
                .AddWithValue("vReferencia_fecha", cEComprobante.referencia_fecha)
                .AddWithValue("vNombre_archivo", cEComprobante.nombre_archivo)
                .AddWithValue("vUsuario_envio", cEComprobante.usuario_envio)
                .AddWithValue("vFecha_envio", cEComprobante.fecha_envio)
                .AddWithValue("vEstado_ticket", cEComprobante.estado_ticket)
                .AddWithValue("vEstado_comprobante", cEComprobante.estado_comprobante)
                .AddWithValue("vEmail_contacto", cEComprobante.email_contacto)
                .AddWithValue("vEmail_facturacion", cEComprobante.email_facturacion)
                .AddWithValue("vVenta", cEComprobante.venta)
                .AddWithValue("vRazon_social", cEComprobante.razon_social)
                .AddWithValue("vMensaje", cEComprobante.mensaje)
                .AddWithValue("vDigest_value", cEComprobante.digest_value)
                .AddWithValue("vSignature_value", cEComprobante.signature_value)
                .AddWithValue("vUsuario_registro", cEComprobante.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobante
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

    Private Shared Function InsertarError(ByVal cEComprobante As entEComprobante) As entEComprobante
        MySQL = "INSERT INTO COM.ECOMPROBANTES_ERROR " & _
                "(empresa,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero," & _
                "estado_ticket,estado_comprobante,mensaje,usuario_registro) " & _
                "VALUES (@vEmpresa,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero," & _
                "@vEstado_ticket,@vEstado_comprobante,@vMensaje,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobante.empresa)
                .AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial.Trim)
                .AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                .AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                .AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                .AddWithValue("vEstado_ticket", cEComprobante.estado_ticket)
                .AddWithValue("vEstado_comprobante", cEComprobante.estado_comprobante)
                .AddWithValue("vMensaje", cEComprobante.mensaje)
                .AddWithValue("vUsuario_registro", cEComprobante.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobante
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

    Public Shared Sub Grabar(ByVal cEComprobanteFirma As entEComprobanteFirma)
        If Not Existe(cEComprobanteFirma) Then
            Insertar(cEComprobanteFirma)
        Else
            Actualizar(cEComprobanteFirma)
        End If
    End Sub

    Private Shared Function Insertar(ByVal cEComprobanteFirma As entEComprobanteFirma) As entEComprobanteFirma
        MySQL = "INSERT INTO COM.ECOMPROBANTES_FIRMA " & _
                "(empresa,venta,digest_value,signature_value,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vDigest_value,@vSignature_value,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                .AddWithValue("vVenta", cEComprobanteFirma.venta)
                .AddWithValue("vDigest_value", cEComprobanteFirma.digest_value)
                .AddWithValue("vSignature_value", cEComprobanteFirma.signature_value)
                .AddWithValue("vUsuario_registro", cEComprobanteFirma.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobanteFirma
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

    Private Shared Function Actualizar(ByVal cEComprobanteFirma As entEComprobanteFirma) As entEComprobanteFirma
        MySQL = "UPDATE COM.ECOMPROBANTES_FIRMA SET " & _
                "Digest_value=@vDigest_value,Signature_value=@vSignature_value,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vDigest_value", cEComprobanteFirma.digest_value)
                .AddWithValue("vSignature_value", cEComprobanteFirma.signature_value)
                .AddWithValue("vUsuario_modifica", cEComprobanteFirma.usuario_registro)
                .AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                .AddWithValue("vVenta", cEComprobanteFirma.venta)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobanteFirma
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

    Public Shared Sub GrabarGlosa(ByVal cVentaGlosa As entVentaGlosa)
        If Not ExisteGlosa(cVentaGlosa) Then
            InsertarGlosa(cVentaGlosa)
        Else
            ActualizarGlosa(cVentaGlosa)
        End If
    End Sub

    Private Shared Function InsertarGlosa(ByVal cVentaGlosa As entVentaGlosa) As entVentaGlosa
        MySQL = "INSERT INTO COM.VENTAS_GLOSA " & _
                "(EMPRESA, VENTA, LINEA, TIPO_CAMBIO, TIPO_MONEDA, GLOSA_1, GLOSA_2, GLOSA_3, GLOSA_4, VALOR_VENTA_ORIGEN,USUARIO_REGISTRO) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vTipo_Cambio,@vTipo_Moneda,@vGlosa_1,@vGlosa_2,@vGlosa_3,@vGlosa_4,@vValor_venta_origen,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cVentaGlosa.empresa)
                .AddWithValue("vVenta", cVentaGlosa.venta)
                .AddWithValue("vLinea", cVentaGlosa.linea)
                .AddWithValue("vTipo_Cambio", cVentaGlosa.tipo_cambio)
                .AddWithValue("vTipo_Moneda", cVentaGlosa.tipo_moneda)
                .AddWithValue("vGlosa_1", cVentaGlosa.glosa_1)
                .AddWithValue("vGlosa_2", cVentaGlosa.glosa_2)
                .AddWithValue("vGlosa_3", cVentaGlosa.glosa_3)
                .AddWithValue("vGlosa_4", cVentaGlosa.glosa_4)
                .AddWithValue("vValor_venta_origen", cVentaGlosa.valor_venta_origen)
                .AddWithValue("vUsuario_registro", cVentaGlosa.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cVentaGlosa
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

    Private Shared Function ActualizarGlosa(ByVal cVentaGlosa As entVentaGlosa) As entVentaGlosa
        MySQL = "UPDATE COM.VENTAS_GLOSA SET " & _
                "GLOSA_1=@vGlosa_1, GLOSA_2=@vGlosa_2, GLOSA_3=@vGlosa_3, GLOSA_4=@vGlosa_4, USUARIO_MODIFICA=@vUsuario_registro, FECHA_MODIFICA=GETDATE() " & _
                "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta AND LINEA=@vLinea "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vGlosa_1", cVentaGlosa.glosa_1)
                .AddWithValue("vGlosa_2", cVentaGlosa.glosa_2)
                .AddWithValue("vGlosa_3", cVentaGlosa.glosa_3)
                .AddWithValue("vGlosa_4", cVentaGlosa.glosa_4)
                .AddWithValue("vUsuario_registro", cVentaGlosa.usuario_registro)
                .AddWithValue("vEmpresa", cVentaGlosa.empresa)
                .AddWithValue("vVenta", cVentaGlosa.venta)
                .AddWithValue("vLinea", cVentaGlosa.linea)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cVentaGlosa
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

    Public Shared Sub CargarEComprobante(NombreArchivo As String)
        Dim miUri As String = "ftp://ftp.smarterasp.net/" & NombreArchivo

        Dim miRequest As Net.FtpWebRequest = Net.WebRequest.Create(miUri)
        miRequest.Credentials = New Net.NetworkCredential("hidronamic2", "71312091")
        miRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
        Try
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(MyTempPath & "\" & NombreArchivo)
            Dim miStream As System.IO.Stream = miRequest.GetRequestStream()
            miStream.Write(bFile, 0, bFile.Length)
            miStream.Close()
            miStream.Dispose()

            'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & NombreArchivo)

        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Public Shared Function EvaluarExisteEnvio(ByVal pEmpresa As String, ByVal pTipo As String, pSerie As String, pNumero As String, pEstado As String) As Boolean
        Dim Respuesta As Boolean = ExisteEnvio(pEmpresa, pTipo, pSerie, pNumero)

        If Respuesta = False Then
            MySQLString = "UPDATE COM.VENTAS SET " & _
                          "Estado=@vEstado,Usuario_envio=@vUsuario_modifica,Fecha_envio=GETDATE(), " & _
                          "Fecha_recepcion=CASE WHEN @vEstado='R' THEN (GETDATE()+0.001) ELSE GETDATE() END " & _
                          "WHERE Empresa=@vEmpresa AND Comprobante_Tipo=@vComprobante_Tipo AND Comprobante_Serie=@vComprobante_Serie AND Comprobante_Numero=@vComprobante_Numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLTransaction As SqlTransaction
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

                With MySQLCommand.Parameters
                    .AddWithValue("vEstado", pEstado)
                    .AddWithValue("vUsuario_modifica", Strings.Left(MyUsuario.usuario.Trim, 20))
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
        MySQL = "SELECT Usuario_envio " & _
                "FROM COM.VENTAS " & _
                "WHERE EMPRESA='" & pEmpresa & "' AND Comprobante_Tipo='" & pTipo & "' AND Comprobante_Serie='" & pSerie & "' AND Comprobante_Numero='" & pNumero & "' " & _
                "AND LEN(RTRIM(Usuario_envio))<>0 "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If NewCode Is Nothing Then Respuesta = False
            Return Respuesta
        End Using
    End Function

    Public Shared Function ActualizarEstadoEnvio(ByVal pEmpresa As String, ByVal pVenta As String, pEstado As String) As Boolean

        MySQLString = "UPDATE COM.VENTAS SET " & _
                      "Estado=@vEstado,Usuario_envio=@vUsuario_modifica,Fecha_envio=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEstado", pEstado)
                .AddWithValue("vUsuario_modifica", Strings.Left(MyUsuario.usuario.Trim, 20))
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

    Public Shared Function ObtenerCorrelativo(ByVal pTipoComprobante As String, ByVal pSerieComprobante As String) As dsCorrelativo.CORRELATIVODataTable
        MyStoreProcedure = "COM.CORRELATIVO_VENTAS"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@COMPROBANTE_TIPO", SqlDbType.Char, 2) : MyParameter_2.Value = pTipoComprobante
        Dim MyParameter_3 As New SqlParameter("@COMPROBANTE_SERIE", SqlDbType.Char, 4) : MyParameter_3.Value = pSerieComprobante

        Dim MyDT As New dsCorrelativo.CORRELATIVODataTable
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

#End Region

#Region "Detalle"
    Public Shared Function Grabar(ByVal cVentaDetalle As entVentaServicio) As entVentaServicio
        With cVentaDetalle
            Dim ValidarImporte As Single = Math.Round(.importe_total_origen - .base_imponible_gravada_origen - .igv_origen - .importe_inafecto_origen - .otros_tributos_origen, 2)
            If RTrim(.glosa_1 & .glosa_2 & .glosa_3 & .glosa_4).Length = 0 Then Throw New BusinessException(MSG000 & " GLOSA DEL DETALLE")
            'If .base_imponible_gravada_origen = 0 And .importe_inafecto_origen = 0 And .igv_origen = 0 And .otros_tributos_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR AFECTO")
            'If .importe_inafecto_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR EXENTO")
            'If .igv_origen = 0 Then Throw New BusinessException(MSG000 & " IMPUESTO")
            'If ValidarImporte <> 0 Then Throw New BusinessException("LOS IMPORTES REGISTRADOR NO GUARDAN COHERENCIA")
            'If .centro_costo = "99999" Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")
            'If String.IsNullOrEmpty(.centro_costo.Trim) Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")

            If .indica_proyecto = True Then
                If String.IsNullOrEmpty(.proyecto.Trim) Then Throw New BusinessException(MSG000 & " PROYECTO")
            End If
        End With
        If String.IsNullOrEmpty(cVentaDetalle.linea.Trim) Then
            Return Insertar(cVentaDetalle)
        Else
            Return Actualizar(cVentaDetalle)
        End If
    End Function

    Private Shared Function Insertar(ByVal cVentaDetalle As entVentaServicio) As entVentaServicio

        cVentaDetalle.linea = AsignarLinea(cVentaDetalle.venta, "S")

        MySQL = "INSERT INTO COM.VENTAS_SER " & _
                "(empresa,venta,linea,glosa_1,glosa_2,glosa_3,glosa_4,tipo_cambio,tipo_moneda," & _
                "valor_exportacion_origen,base_imponible_gravada_origen,importe_exonerado_origen,importe_inafecto_origen,isc_origen,igv_origen,ipm_origen," & _
                "base_imponible_gravada2_origen,igv2_origen,otros_tributos_origen,importe_total_origen," & _
                "valor_exportacion_mn,base_imponible_gravada_mn,importe_exonerado_mn,importe_inafecto_mn,isc_mn,igv_mn,ipm_mn," & _
                "base_imponible_gravada2_mn,igv2_mn,otros_tributos_mn,importe_total_mn," & _
                "valor_exportacion_me,base_imponible_gravada_me,importe_exonerado_me,importe_inafecto_me,isc_me,igv_me,ipm_me," & _
                "base_imponible_gravada2_me,igv2_me,otros_tributos_me,importe_total_me," & _
                "centro_costo,proyecto,estado,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vGlosa_1,@vGlosa_2,@vGlosa_3,@vGlosa_4,@vTipo_cambio,@vTipo_moneda," & _
                "@vValor_exportacion_origen,@vBase_imponible_gravada_origen,@vimporte_exonerado_origen,@vimporte_inafecto_origen,@vIsc_origen,@vIgv_origen,@vIpm_origen," & _
                "@vBase_imponible_gravada2_origen,@vIgv2_origen,@vOtros_tributos_origen,@vImporte_total_origen," & _
                "@vValor_exportacion_mn,@vBase_imponible_gravada_mn,@vimporte_exonerado_mn,@vimporte_inafecto_mn,@vIsc_mn,@vIgv_mn,@vIpm_mn," & _
                "@vBase_imponible_gravada2_mn,@vIgv2_mn,@vOtros_tributos_mn,@vImporte_total_mn," & _
                "@vValor_exportacion_me,@vBase_imponible_gravada_me,@vimporte_exonerado_me,@vimporte_inafecto_me,@vIsc_me,@vIgv_me,@vIpm_me," & _
                "@vBase_imponible_gravada2_me,@vIgv2_me,@vOtros_tributos_me,@vImporte_total_me," & _
                "@vCentro_costo,@vProyecto,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cVentaDetalle.empresa)
                .AddWithValue("vVenta", cVentaDetalle.venta)
                .AddWithValue("vLinea", cVentaDetalle.linea)
                .AddWithValue("vGlosa_1", cVentaDetalle.glosa_1)
                .AddWithValue("vGlosa_2", cVentaDetalle.glosa_2)
                .AddWithValue("vGlosa_3", cVentaDetalle.glosa_3)
                .AddWithValue("vGlosa_4", cVentaDetalle.glosa_4)
                .AddWithValue("vTipo_cambio", cVentaDetalle.tipo_cambio)
                .AddWithValue("vTipo_moneda", cVentaDetalle.tipo_moneda)
                .AddWithValue("vValor_exportacion_origen", cVentaDetalle.valor_exportacion_origen)
                .AddWithValue("vBase_imponible_gravada_origen", cVentaDetalle.base_imponible_gravada_origen)
                .AddWithValue("vimporte_exonerado_origen", cVentaDetalle.importe_exonerado_origen)
                .AddWithValue("vimporte_inafecto_origen", cVentaDetalle.importe_inafecto_origen)
                .AddWithValue("vIsc_origen", cVentaDetalle.isc_origen)
                .AddWithValue("vIgv_origen", cVentaDetalle.igv_origen)
                .AddWithValue("vIpm_origen", cVentaDetalle.ipm_origen)
                .AddWithValue("vBase_imponible_gravada2_origen", cVentaDetalle.base_imponible_gravada2_origen)
                .AddWithValue("vIgv2_origen", cVentaDetalle.igv2_origen)
                .AddWithValue("vOtros_tributos_origen", cVentaDetalle.otros_tributos_origen)
                .AddWithValue("vImporte_total_origen", cVentaDetalle.importe_total_origen)
                .AddWithValue("vValor_exportacion_mn", cVentaDetalle.valor_exportacion_mn)
                .AddWithValue("vBase_imponible_gravada_mn", cVentaDetalle.base_imponible_gravada_mn)
                .AddWithValue("vimporte_exonerado_mn", cVentaDetalle.importe_exonerado_mn)
                .AddWithValue("vimporte_inafecto_mn", cVentaDetalle.importe_inafecto_mn)
                .AddWithValue("vIsc_mn", cVentaDetalle.isc_mn)
                .AddWithValue("vIgv_mn", cVentaDetalle.igv_mn)
                .AddWithValue("vIpm_mn", cVentaDetalle.ipm_mn)
                .AddWithValue("vBase_imponible_gravada2_mn", cVentaDetalle.base_imponible_gravada2_mn)
                .AddWithValue("vIgv2_mn", cVentaDetalle.igv2_mn)
                .AddWithValue("vOtros_tributos_mn", cVentaDetalle.otros_tributos_mn)
                .AddWithValue("vImporte_total_mn", cVentaDetalle.importe_total_mn)
                .AddWithValue("vValor_exportacion_me", cVentaDetalle.valor_exportacion_me)
                .AddWithValue("vBase_imponible_gravada_me", cVentaDetalle.base_imponible_gravada_me)
                .AddWithValue("vimporte_exonerado_me", cVentaDetalle.importe_exonerado_me)
                .AddWithValue("vimporte_inafecto_me", cVentaDetalle.importe_inafecto_me)
                .AddWithValue("vIsc_me", cVentaDetalle.isc_me)
                .AddWithValue("vIgv_me", cVentaDetalle.igv_me)
                .AddWithValue("vIpm_me", cVentaDetalle.ipm_me)
                .AddWithValue("vBase_imponible_gravada2_me", cVentaDetalle.base_imponible_gravada2_me)
                .AddWithValue("vIgv2_me", cVentaDetalle.igv2_me)
                .AddWithValue("vOtros_tributos_me", cVentaDetalle.otros_tributos_me)
                .AddWithValue("vImporte_total_me", cVentaDetalle.importe_total_me)
                .AddWithValue("vCentro_costo", cVentaDetalle.centro_costo)
                .AddWithValue("vProyecto", cVentaDetalle.proyecto)
                .AddWithValue("vEstado", cVentaDetalle.estado)
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

                Return cVentaDetalle

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

    Private Shared Function Actualizar(ByVal cVentaDetalle As entVentaServicio) As entVentaServicio


        MySQLString = "UPDATE COM.VENTAS_SER SET " & _
                      "valor_exportacion_origen=@vValor_exportacion_origen,base_imponible_gravada_origen=@vBase_imponible_gravada_origen,importe_exonerado_origen=@vimporte_exonerado_origen," & _
                      "importe_inafecto_origen=@vimporte_inafecto_origen,isc_origen=@vIsc_origen,igv_origen=@vIgv_origen,ipm_origen=@vIpm_origen," & _
                      "base_imponible_gravada2_origen=@vBase_imponible_gravada2_origen,igv2_origen=@vIgv2_origen,otros_tributos_origen=@vOtros_tributos_origen,importe_total_origen=@vImporte_total_origen," & _
                      "valor_exportacion_mn=@vValor_exportacion_mn,base_imponible_gravada_mn=@vBase_imponible_gravada_mn,importe_exonerado_mn=@vimporte_exonerado_mn," & _
                      "importe_inafecto_mn=@vimporte_inafecto_mn,isc_mn=@vIsc_mn,igv_mn=@vIgv_mn,ipm_mn=@vIpm_mn," & _
                      "base_imponible_gravada2_mn=@vBase_imponible_gravada2_mn,igv2_mn=@vIgv2_mn,otros_tributos_mn=@vOtros_tributos_mn,importe_total_mn=@vImporte_total_mn," & _
                      "valor_exportacion_me=@vValor_exportacion_me,base_imponible_gravada_me=@vBase_imponible_gravada_me,importe_exonerado_me=@vimporte_exonerado_me," & _
                      "importe_inafecto_me=@vimporte_inafecto_me,isc_me=@vIsc_me,igv_me=@vIgv_me,ipm_me=@vIpm_me," & _
                      "base_imponible_gravada2_me=@vBase_imponible_gravada2_me,igv2_me=@vIgv2_me,otros_tributos_me=@vOtros_tributos_me,importe_total_me=@vImporte_total_me," & _
                      "glosa_1=@vGlosa_1,glosa_2=@vGlosa_2,glosa_3=@vGlosa_3,glosa_4=@vGlosa_4,Centro_costo=@vCentro_costo,Proyecto=@vProyecto," & _
                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vValor_exportacion_origen", cVentaDetalle.valor_exportacion_origen)
                .AddWithValue("vBase_imponible_gravada_origen", cVentaDetalle.base_imponible_gravada_origen)
                .AddWithValue("vimporte_exonerado_origen", cVentaDetalle.importe_exonerado_origen)
                .AddWithValue("vimporte_inafecto_origen", cVentaDetalle.importe_inafecto_origen)
                .AddWithValue("vIsc_origen", cVentaDetalle.isc_origen)
                .AddWithValue("vIgv_origen", cVentaDetalle.igv_origen)
                .AddWithValue("vIpm_origen", cVentaDetalle.ipm_origen)
                .AddWithValue("vBase_imponible_gravada2_origen", cVentaDetalle.base_imponible_gravada2_origen)
                .AddWithValue("vIgv2_origen", cVentaDetalle.igv2_origen)
                .AddWithValue("vOtros_tributos_origen", cVentaDetalle.otros_tributos_origen)
                .AddWithValue("vImporte_total_origen", cVentaDetalle.importe_total_origen)
                .AddWithValue("vValor_exportacion_mn", cVentaDetalle.valor_exportacion_mn)
                .AddWithValue("vBase_imponible_gravada_mn", cVentaDetalle.base_imponible_gravada_mn)
                .AddWithValue("vimporte_exonerado_mn", cVentaDetalle.importe_exonerado_mn)
                .AddWithValue("vimporte_inafecto_mn", cVentaDetalle.importe_inafecto_mn)
                .AddWithValue("vIsc_mn", cVentaDetalle.isc_mn)
                .AddWithValue("vIgv_mn", cVentaDetalle.igv_mn)
                .AddWithValue("vIpm_mn", cVentaDetalle.ipm_mn)
                .AddWithValue("vBase_imponible_gravada2_mn", cVentaDetalle.base_imponible_gravada2_mn)
                .AddWithValue("vIgv2_mn", cVentaDetalle.igv2_mn)
                .AddWithValue("vOtros_tributos_mn", cVentaDetalle.otros_tributos_mn)
                .AddWithValue("vImporte_total_mn", cVentaDetalle.importe_total_mn)
                .AddWithValue("vValor_exportacion_me", cVentaDetalle.valor_exportacion_me)
                .AddWithValue("vBase_imponible_gravada_me", cVentaDetalle.base_imponible_gravada_me)
                .AddWithValue("vimporte_exonerado_me", cVentaDetalle.importe_exonerado_me)
                .AddWithValue("vimporte_inafecto_me", cVentaDetalle.importe_inafecto_me)
                .AddWithValue("vIsc_me", cVentaDetalle.isc_me)
                .AddWithValue("vIgv_me", cVentaDetalle.igv_me)
                .AddWithValue("vIpm_me", cVentaDetalle.ipm_me)
                .AddWithValue("vBase_imponible_gravada2_me", cVentaDetalle.base_imponible_gravada2_me)
                .AddWithValue("vIgv2_me", cVentaDetalle.igv2_me)
                .AddWithValue("vOtros_tributos_me", cVentaDetalle.otros_tributos_me)
                .AddWithValue("vImporte_total_me", cVentaDetalle.importe_total_me)
                .AddWithValue("vGlosa_1", cVentaDetalle.glosa_1)
                .AddWithValue("vGlosa_2", cVentaDetalle.glosa_2)
                .AddWithValue("vGlosa_3", cVentaDetalle.glosa_3)
                .AddWithValue("vGlosa_4", cVentaDetalle.glosa_4)
                .AddWithValue("vCentro_costo", cVentaDetalle.centro_costo)
                .AddWithValue("vProyecto", cVentaDetalle.proyecto)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vEmpresa", cVentaDetalle.empresa)
                .AddWithValue("vVenta", cVentaDetalle.venta)
                .AddWithValue("vLinea", cVentaDetalle.linea)
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
                Return cVentaDetalle

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

    Public Shared Function Borrar(ByVal cVentaDetalle As entVentaServicio) As Boolean
        MySQL = "DELETE FROM COM.VENTAS_SER " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)

            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", cVentaDetalle.venta)
            MySQLCommand.Parameters.AddWithValue("vLinea", cVentaDetalle.linea)
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

    Public Shared Function ObtenerDetalle(ByVal pEmpresa As String, ByVal pVenta As String, ByVal pLinea As String) As entVentaServicio
        CadenaSQL = "SELECT * FROM COM.VENTAS_SER WHERE EMPRESA='" & pEmpresa & "' AND VENTA='" & pVenta & "' AND LINEA='" & pLinea & "' "
        Return ObtenerDetalle(New entVentaServicio, CadenaSQL)
    End Function

    Private Shared Function ObtenerDetalle(ByVal cVentaDetalle As entVentaServicio, ByVal MySQLString As String) As entVentaServicio
        Dim MyDT As New dsVentas.VENTAS_SERDataTable

        Call ObtenerDataTableSQL(MySQLString, MyDT)

        If MyDT.Count > 0 Then
            With cVentaDetalle
                .empresa = MyDT(0).EMPRESA
                .venta = MyDT(0).VENTA
                .linea = MyDT(0).LINEA
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .tipo_moneda = MyDT(0).TIPO_MONEDA

                .glosa_1 = MyDT(0).GLOSA_1
                .glosa_2 = MyDT(0).GLOSA_2
                .glosa_3 = MyDT(0).GLOSA_3
                .glosa_4 = MyDT(0).GLOSA_4

                .descuento_1 = MyDT(0).DESCUENTO_1
                .descuento_2 = MyDT(0).DESCUENTO_2
                .descuento_3 = MyDT(0).DESCUENTO_3

                .valor_exportacion_origen = MyDT(0).VALOR_EXPORTACION_ORIGEN
                .base_imponible_gravada_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA_ORIGEN
                .importe_exonerado_origen = MyDT(0).IMPORTE_EXONERADO_ORIGEN
                .importe_inafecto_origen = MyDT(0).IMPORTE_INAFECTO_ORIGEN
                .isc_origen = MyDT(0).ISC_ORIGEN
                .igv_origen = MyDT(0).IGV_ORIGEN
                .ipm_origen = MyDT(0).IPM_ORIGEN
                .base_imponible_gravada2_origen = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ORIGEN
                .igv2_origen = MyDT(0).IGV2_ORIGEN
                .otros_tributos_origen = MyDT(0).OTROS_TRIBUTOS_ORIGEN
                .importe_total_origen = MyDT(0).IMPORTE_TOTAL_ORIGEN

                .valor_exportacion_mn = MyDT(0).VALOR_EXPORTACION_MN
                .base_imponible_gravada_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA_MN
                .importe_exonerado_mn = MyDT(0).IMPORTE_EXONERADO_MN
                .importe_inafecto_mn = MyDT(0).IMPORTE_INAFECTO_MN
                .isc_mn = MyDT(0).ISC_MN
                .igv_mn = MyDT(0).IGV_MN
                .ipm_mn = MyDT(0).IPM_MN
                .base_imponible_gravada2_mn = MyDT(0).BASE_IMPONIBLE_GRAVADA2_MN
                .igv2_mn = MyDT(0).IGV2_MN
                .otros_tributos_mn = MyDT(0).OTROS_TRIBUTOS_MN
                .importe_total_mn = MyDT(0).IMPORTE_TOTAL_MN

                .valor_exportacion_me = MyDT(0).VALOR_EXPORTACION_ME
                .base_imponible_gravada_me = MyDT(0).BASE_IMPONIBLE_GRAVADA_ME
                .importe_exonerado_me = MyDT(0).IMPORTE_EXONERADO_ME
                .importe_inafecto_me = MyDT(0).IMPORTE_INAFECTO_ME
                .isc_me = MyDT(0).ISC_ME
                .igv_me = MyDT(0).IGV_ME
                .ipm_me = MyDT(0).IPM_ME
                .base_imponible_gravada2_me = MyDT(0).BASE_IMPONIBLE_GRAVADA2_ME
                .igv2_me = MyDT(0).IGV2_ME
                .otros_tributos_me = MyDT(0).OTROS_TRIBUTOS_ME
                .importe_total_me = MyDT(0).IMPORTE_TOTAL_ME

                .estado = MyDT(0).ESTADO
                .guia_remitente = MyDT(0).GUIA_REMITENTE
                .centro_costo = MyDT(0).CENTRO_COSTO
                .proyecto = MyDT(0).PROYECTO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cVentaDetalle
    End Function

    Private Shared Function AsignarLinea(ByVal pVenta As String, pTipoVenta As String) As String

        MySQL = "SELECT ISNULL(MAX(LINEA),'') AS NUEVA_LINEA FROM " & IIf(pTipoVenta = "S", "COM.VENTAS_SER ", "COM.VENTAS_PRO ") & _
                "WHERE EMPRESA='" & MyUsuario.empresa & "' AND VENTA='" & pVenta & "'"
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewLine As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewLine.Trim) Then
                NewLine = "001"
            Else
                Correlativo = CLng(NewLine) + 1
                NewLine = Strings.Right("000" & Correlativo.ToString.Trim, 3)
            End If
            Return NewLine

        End Using

    End Function

#End Region

#Region "Notas"

    Public Shared Function GrabarNota(ByVal cVenta As entVenta) As entVenta
        If cVenta.venta.Trim.Length = 0 Then
            Return InsertarNota(cVenta)
        Else
            Return ActualizarNota(cVenta)
        End If
    End Function

    Private Shared Function InsertarNota(ByVal cVenta As entVenta) As entVenta
        With cVenta
            .venta = AsignarVenta()
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
        End With
        MySQL = "INSERT INTO COM.VENTAS " & _
                "(empresa,venta,ejercicio,mes," & _
                "asiento_tipo,asiento_numero,asiento_fecha," & _
                "cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero,comprobante_fecha,comprobante_vencimiento," & _
                "referencia_tipo,referencia_serie,referencia_numero,referencia_fecha," & _
                "tipo_cambio,tipo_moneda,condicion_pago,comentario,tipo_operacion,indica_exportacion,estado,usuario_registro) " & _
                "VALUES (" & _
                "@vEmpresa,@vVenta,@vEjercicio,@vMes," & _
                "@vAsiento_tipo,@vAsiento_numero,@vAsiento_fecha," & _
                "@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento," & _
                "@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero,@vReferencia_fecha," & _
                "@vTipo_cambio,@vTipo_moneda,@vCondicion_pago,@vComentario,@vTipo_operacion,@vIndica_exportacion,@vEstado,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cVenta.empresa)
                .AddWithValue("vVenta", cVenta.venta)
                .AddWithValue("vEjercicio", cVenta.ejercicio)
                .AddWithValue("vMes", cVenta.mes)
                .AddWithValue("vAsiento_tipo", cVenta.asiento_tipo)
                .AddWithValue("vAsiento_numero", cVenta.asiento_numero)
                .AddWithValue("vAsiento_fecha", cVenta.asiento_fecha)
                .AddWithValue("vCuenta_comercial", cVenta.cuenta_comercial.Trim)
                .AddWithValue("vComprobante_tipo", cVenta.comprobante_tipo)
                .AddWithValue("vComprobante_serie", cVenta.comprobante_serie)
                .AddWithValue("vComprobante_numero", cVenta.comprobante_numero)
                .AddWithValue("vComprobante_fecha", cVenta.comprobante_fecha)
                .AddWithValue("vComprobante_vencimiento", cVenta.comprobante_vencimiento)
                .AddWithValue("vReferencia_tipo", cVenta.referencia_tipo)
                .AddWithValue("vReferencia_serie", cVenta.referencia_serie)
                .AddWithValue("vReferencia_numero", cVenta.referencia_numero)
                .AddWithValue("vReferencia_fecha", cVenta.referencia_fecha)
                .AddWithValue("vTipo_cambio", cVenta.tipo_cambio)
                .AddWithValue("vTipo_moneda", cVenta.tipo_moneda)
                .AddWithValue("vCondicion_pago", cVenta.condicion_pago)
                .AddWithValue("vComentario", cVenta.comentario)
                .AddWithValue("vTipo_operacion", cVenta.tipo_operacion)
                .AddWithValue("vIndica_exportacion", cVenta.indica_exportacion)
                .AddWithValue("vEstado", cVenta.estado)
                .AddWithValue("vUsuario_registro", cVenta.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cVenta
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

    Private Shared Function ActualizarNota(ByVal cVenta As entVenta) As entVenta

        MySQL = "INSERT INTO AUD.VENTAS " & _
                "SELECT * FROM COM.VENTAS " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vVenta", cVenta.venta)
            End With

            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()

                MySQL = "UPDATE COM.VENTAS SET " & _
                        "Ejercicio=@vEjercicio,Mes=@vMes,Cuenta_comercial=@vCuenta_comercial," & _
                        "Comprobante_tipo=@vComprobante_tipo,Comprobante_serie=@vComprobante_serie,Comprobante_numero=@vComprobante_numero,Comprobante_fecha=@vComprobante_fecha," & _
                        "Comprobante_vencimiento=@vComprobante_vencimiento,Tipo_cambio=@vTipo_cambio,Tipo_moneda=@vTipo_moneda,Condicion_pago=@vCondicion_pago,Comentario=@vComentario," & _
                        "Referencia_tipo=@vReferencia_tipo,Referencia_serie=@vReferencia_serie,Referencia_numero=@vReferencia_numero,Referencia_fecha=@vReferencia_fecha," & _
                        "Tipo_operacion=@vTipo_operacion," & _
                        "indica_exportacion=@vIndica_exportacion,estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE(),asiento_fecha=@vAsiento_fecha  " & _
                        "WHERE empresa=@vEmpresa AND venta=@vVenta"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQL
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vEjercicio", cVenta.ejercicio)
                    .AddWithValue("vMes", cVenta.mes)
                    .AddWithValue("vCuenta_comercial", cVenta.cuenta_comercial)
                    .AddWithValue("vComprobante_tipo", cVenta.comprobante_tipo)
                    .AddWithValue("vComprobante_serie", cVenta.comprobante_serie)
                    .AddWithValue("vComprobante_numero", cVenta.comprobante_numero)
                    .AddWithValue("vComprobante_fecha", cVenta.comprobante_fecha)
                    .AddWithValue("vComprobante_vencimiento", cVenta.comprobante_vencimiento)
                    .AddWithValue("vTipo_cambio", cVenta.tipo_cambio)
                    .AddWithValue("vTipo_moneda", cVenta.tipo_moneda)
                    .AddWithValue("vCondicion_pago", cVenta.condicion_pago)
                    .AddWithValue("vComentario", cVenta.comentario)
                    .AddWithValue("vReferencia_tipo", cVenta.referencia_tipo)
                    .AddWithValue("vReferencia_serie", cVenta.referencia_serie)
                    .AddWithValue("vReferencia_numero", cVenta.referencia_numero)
                    .AddWithValue("vReferencia_fecha", cVenta.referencia_fecha)
                    .AddWithValue("vTipo_operacion", cVenta.tipo_operacion)
                    .AddWithValue("vIndica_exportacion", cVenta.indica_exportacion)
                    .AddWithValue("vEstado", cVenta.estado)
                    .AddWithValue("vUsuario_modifica", cVenta.usuario_registro)
                    .AddWithValue("vAsiento_fecha", cVenta.asiento_fecha)
                    .AddWithValue("vEmpresa", cVenta.empresa)
                    .AddWithValue("vVenta", cVenta.venta)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()
                Return cVenta
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

    Public Shared Function InsertarDetalleNota(ByVal cVenta As String, ByVal cVentaReferencia As String) As Boolean

        MySQL = "INSERT INTO COM.VENTAS_SER " & _
                "(empresa,venta,linea,glosa_1,glosa_2,glosa_3,glosa_4,tipo_cambio,tipo_moneda," & _
                "valor_exportacion_origen,base_imponible_gravada_origen,importe_exonerado_origen,importe_inafecto_origen,isc_origen,igv_origen,ipm_origen," & _
                "base_imponible_gravada2_origen,igv2_origen,otros_tributos_origen,importe_total_origen," & _
                "valor_exportacion_mn,base_imponible_gravada_mn,importe_exonerado_mn,importe_inafecto_mn,isc_mn,igv_mn,ipm_mn," & _
                "base_imponible_gravada2_mn,igv2_mn,otros_tributos_mn,importe_total_mn," & _
                "valor_exportacion_me,base_imponible_gravada_me,importe_exonerado_me,importe_inafecto_me,isc_me,igv_me,ipm_me," & _
                "base_imponible_gravada2_me,igv2_me,otros_tributos_me,importe_total_me," & _
                "centro_costo,proyecto,estado,usuario_registro) " & _
                "SELECT empresa,@vVenta,linea,glosa_1,glosa_2,glosa_3,glosa_4,tipo_cambio,tipo_moneda," & _
                "valor_exportacion_origen,base_imponible_gravada_origen,importe_exonerado_origen,importe_inafecto_origen,isc_origen,igv_origen,ipm_origen," & _
                "base_imponible_gravada2_origen,igv2_origen,otros_tributos_origen,importe_total_origen," & _
                "valor_exportacion_mn,base_imponible_gravada_mn,importe_exonerado_mn,importe_inafecto_mn,isc_mn,igv_mn,ipm_mn," & _
                "base_imponible_gravada2_mn,igv2_mn,otros_tributos_mn,importe_total_mn," & _
                "valor_exportacion_me,base_imponible_gravada_me,importe_exonerado_me,importe_inafecto_me,isc_me,igv_me,ipm_me," & _
                "base_imponible_gravada2_me,igv2_me,otros_tributos_me,importe_total_me," & _
                "centro_costo,proyecto,estado,@vUsuario_registro " & _
                "FROM COM.VENTAS_SER " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVentaReferencia "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vVenta", cVenta)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vVentaReferencia", cVentaReferencia)
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

    Public Shared Function ActualizarResumen(ByVal cVentaResumen As entVentaResumen) As entVentaResumen

        MySQLString = "UPDATE COM.VENTAS SET " & _
                      "valor_exportacion_origen=@vValor_exportacion_origen,base_imponible_gravada_origen=@vBase_imponible_gravada_origen,importe_exonerado_origen=@vImporte_exonerado_origen," & _
                      "importe_inafecto_origen=@vImporte_inafecto_origen,isc_origen=@vIsc_origen,igv_origen=@vIgv_origen,ipm_origen=@vIpm_origen,descuento_global_origen=@vDescuento_global_origen," & _
                      "base_imponible_gravada2_origen=@vBase_imponible_gravada2_origen,igv2_origen=@vIgv2_origen,otros_tributos_origen=@vOtros_tributos_origen,importe_total_origen=@vImporte_total_origen," & _
                      "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vValor_exportacion_origen", cVentaResumen.valor_exportacion_origen)
                .AddWithValue("vBase_imponible_gravada_origen", cVentaResumen.base_imponible_gravada_origen)
                .AddWithValue("vImporte_exonerado_origen", cVentaResumen.importe_exonerado_origen)
                .AddWithValue("vImporte_inafecto_origen", cVentaResumen.importe_inafecto_origen)
                .AddWithValue("vIsc_origen", cVentaResumen.isc_origen)
                .AddWithValue("vIgv_origen", cVentaResumen.igv_origen)
                .AddWithValue("vIpm_origen", cVentaResumen.ipm_origen)
                .AddWithValue("vDescuento_global_origen", cVentaResumen.descuento_global_origen)
                .AddWithValue("vBase_imponible_gravada2_origen", cVentaResumen.base_imponible_gravada2_origen)
                .AddWithValue("vIgv2_origen", cVentaResumen.igv2_origen)
                .AddWithValue("vOtros_tributos_origen", cVentaResumen.otros_tributos_origen)
                .AddWithValue("vImporte_total_origen", cVentaResumen.importe_total_origen)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vEmpresa", cVentaResumen.empresa)
                .AddWithValue("vVenta", cVentaResumen.venta)
            End With

            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()
                Return cVentaResumen
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

    Private Shared Function AsignarVenta() As String
        MySQL = "SELECT ISNULL(MAX(VENTA),'') AS NUEVO_CODIGO FROM COM.VENTAS "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
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

    Private Shared Function AsignarNumeroAsiento(ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsientoTipo As String) As String
        MySQL = "SELECT ISNULL(MAX(ASIENTO_NUMERO),'') AS NUEVO_NUMERO " & _
                "FROM COM.VENTAS " & _
                "WHERE EMPRESA='" & MyUsuario.empresa & "' AND EJERCICIO='" & pEjercicio & "' AND MES='" & pMes & "' AND ASIENTO_TIPO='" & pAsientoTipo & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
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

    Public Shared Function BuscarCuentaComercial(ByVal pCuentaComercial) As DataTable
        Dim MySqlString As String = "SELECT RTRIM(CUENTA_COMERCIAL) AS acodane, RTRIM(RAZON_SOCIAL) AS adesane, 'C' AS avanexo, SPACE(1) AS arefane, 'V' AS aestado " & _
                                    "FROM COM.CLIENTES " & _
                                    "WHERE EMPRESA=@vEmpresa AND CUENTA_COMERCIAL LIKE @vCuenta_comercial+'%' "
        MySqlString = MySqlString & "ORDER BY CUENTA_COMERCIAL "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", pCuentaComercial.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarRazonSocial(ByVal pRazonSocial As String) As DataTable
        Dim MySqlString As String = "SELECT RTRIM(CUENTA_COMERCIAL) AS acodane, RTRIM(RAZON_SOCIAL) AS adesane, 'C' AS avanexo, SPACE(1) AS arefane, 'V' AS aestado " & _
                                    "FROM COM.CLIENTES " & _
                                    "WHERE EMPRESA=@vEmpresa AND RAZON_SOCIAL LIKE '%'+@vRazon_Social+'%' "
        MySqlString = MySqlString & "ORDER BY RAZON_SOCIAL "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vRazon_Social", pRazonSocial.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ActualizarCorrelativo(ByVal cVenta As entVenta) As dsCorrelativo.CORRELATIVODataTable
        Dim MyCorrelativo As dsCorrelativo.CORRELATIVODataTable
        MyCorrelativo = dalVenta.ObtenerCorrelativo(cVenta.comprobante_tipo, cVenta.comprobante_serie)

        If MyCorrelativo.Count > 0 Then

            MySQLString = "UPDATE COM.VENTAS SET " & _
                          "comprobante_serie=@vComprobante_serie,comprobante_numero=@vComprobante_numero,comprobante_fecha=@vComprobante_fecha,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                          "WHERE empresa=@vEmpresa AND venta=@vVenta "

            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

                Dim MySQLTransaction As SqlTransaction
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)

                With MySQLCommand.Parameters
                    .AddWithValue("vComprobante_serie", MyCorrelativo(0).COMPROBANTE_SERIE)
                    .AddWithValue("vComprobante_numero", MyCorrelativo(0).COMPROBANTE_NUMERO)
                    .AddWithValue("vComprobante_fecha", cVenta.comprobante_fecha)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", cVenta.empresa)
                    .AddWithValue("vVenta", cVenta.venta)
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

                    Dim nNumero_a_imprimir As Long = CLng(MyCorrelativo(0).COMPROBANTE_NUMERO) + 1
                    Dim pNumero_a_imprimir As String = Right("0000000" & nNumero_a_imprimir.ToString.Trim, 7)

                    MySQLString = "UPDATE COM.CONTROL_TALONARIOS SET  " & _
                                  "Numero_impreso=Numero_a_imprimir, Numero_a_imprimir=@vNumero_a_imprimir,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica  " & _
                                  "WHERE empresa=@vEmpresa AND Comprobante_tipo='01' AND Comprobante_serie=@vComprobante_serie "

                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString
                    MySQLCommand.Parameters.Clear()

                    MySQLCommand.Parameters.AddWithValue("vNumero_a_imprimir", pNumero_a_imprimir)
                    MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", cVenta.empresa)
                    MySQLCommand.Parameters.AddWithValue("vComprobante_serie", MyCorrelativo(0).COMPROBANTE_SERIE)

                    MySQLCommand.ExecuteNonQuery()

                    ' Commit the transaction.
                    MySQLTransaction.Commit()
                    Return MyCorrelativo

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

        End If

    End Function

    Public Shared Function Anular(ByVal cVenta As entVenta) As Boolean
        Dim MyIndicadorProcesoConcluido As Boolean
        Call BuscarComprobanteDuplicado(cVenta)
        If Not String.IsNullOrEmpty(cVenta.venta) Then
            Resp = MsgBox("Confirmar proceso de ANULACION.", MsgBoxStyle.YesNo, "ANULAR DOCUMENTO")
            If Resp.ToString = vbYes Then
                'MyIndicadorProcesoConcluido = AnularVentaProductos(cVenta.venta, False)
                Call AnularVentaServicios(cVenta.venta)
                Return MyIndicadorProcesoConcluido
            End If
        End If
    End Function

    Private Shared Function AnularVentaServicios(ByVal pVenta As String) As Boolean
        MySQL = "UPDATE COM.VENTAS SET " & _
                "VALOR_EXPORTACION_ORIGEN=0, BASE_IMPONIBLE_GRAVADA_ORIGEN=0, IMPORTE_EXONERADO_ORIGEN=0, " & _
                "IMPORTE_INAFECTO_ORIGEN=0, ISC_ORIGEN=0, IGV_ORIGEN=0, IPM_ORIGEN=0, OTROS_TRIBUTOS_ORIGEN=0, IMPORTE_TOTAL_ORIGEN=0, " & _
                "VALOR_EXPORTACION_MN=0, BASE_IMPONIBLE_GRAVADA_MN=0, IMPORTE_EXONERADO_MN=0, " & _
                "IMPORTE_INAFECTO_MN=0, ISC_MN=0, IGV_MN=0, IPM_MN=0, OTROS_TRIBUTOS_MN=0, IMPORTE_TOTAL_MN=0, " & _
                "VALOR_EXPORTACION_ME=0, BASE_IMPONIBLE_GRAVADA_ME=0, IMPORTE_EXONERADO_ME=0, " & _
                "IMPORTE_INAFECTO_ME=0, ISC_ME=0, IGV_ME=0, IPM_ME=0, OTROS_TRIBUTOS_ME=0, IMPORTE_TOTAL_ME=0, " & _
                "TIPO_CAMBIO=0, TIPO_MONEDA='1', CUENTA_COMERCIAL='0001', ESTADO='N', " & _
                "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()

                MySQL = "DELETE FROM COM.VENTAS_SER WHERE Empresa=@vEmpresa AND Venta=@vVenta "
                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQL
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


    Private Shared Sub BuscarComprobanteDuplicado(ByVal cVenta As entVenta)
        MyOtraVenta = Existe(cVenta, IIf(cVenta.venta = Nothing, True, False))
        If MyOtraVenta.venta <> Nothing Then Throw New BusinessException(MSG1003 & MyOtraVenta.mes & MyOtraVenta.asiento_tipo & MyOtraVenta.asiento_numero)
    End Sub

    Private Shared Function Existe(ByVal cVenta As entVenta, ByVal EsNuevo As Boolean) As entVenta
        With cVenta
            If EsNuevo = True Then
                CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND " & _
                            "COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "'"
            Else
                CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND " & _
                            "COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "' AND " & _
                            "VENTA<>'" & .venta & "'"
            End If
        End With
        Return Obtener(New entVenta, CadenaSQL)
    End Function

#End Region

End Class
