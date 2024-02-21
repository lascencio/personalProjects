Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalGuia

    Private Shared MyOtraGuia As entGuiaRemitente

    Private Shared MySQL As String
    Private Shared MyOleDBString As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String

    Private Shared MyAlmacen As String
    Private Shared MyNumeroLote As String
    Private Shared MyGuiaLinea As String
    Private Shared MyNumeroLinea As String
    Private Shared MyCantidad As Integer


    Public Shared Function ObtenerCorrelativo(ByVal pSerieComprobante As String) As dsCorrelativo.CORRELATIVODataTable
        MySQL = "SELECT COMPROBANTE_SERIE, MAX(COMPROBANTE_NUMERO) AS COMPROBANTE_NUMERO, MAX(COMPROBANTE_FECHA) AS COMPROBANTE_FECHA " & _
                "FROM COM.GUIAS_REMITENTE " & _
                "WHERE EMPRESA = @vEmpresa AND COMPROBANTE_SERIE=@vComprobante_serie " & _
                "GROUP BY COMPROBANTE_SERIE "

        Dim MyDT As New dsCorrelativo.CORRELATIVODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vComprobante_serie", pSerieComprobante)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function Anular(ByVal cGuia As entGuiaRemitente) As Boolean
        Dim MyIndicadorProcesoConcluido As Boolean
        If Not String.IsNullOrEmpty(cGuia.guia_remitente) Then
            Resp = MsgBox("Confirmar proceso de ANULACION.", MsgBoxStyle.YesNo, "ANULAR GUIA")
            If Resp.ToString = vbYes Then
                MyIndicadorProcesoConcluido = AnularGuia(cGuia.guia_remitente, False)
                Return MyIndicadorProcesoConcluido
            End If
        End If
    End Function

    Private Shared Function AnularGuia(ByVal pGuia As String, ByVal IndicaEliminado As Boolean) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                Call ExtornarGuiaProductos(pGuia) ' Actualiza ALM.RESUMEN_X_ALMACEN y ALM.RESUMEN_X_PERIODO
                Call ExtornarGuia(pGuia)          ' Actualiza COM.VENTAS

                MySQL = "DELETE FROM COM.GUIAS_REMITENTE_DET " & _
                        "WHERE Empresa=@vEmpresa AND Guia_remitente=@vGuia_remitente "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vGuia_remitente", pGuia)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    If IndicaEliminado = True Then
                        MySQL = "UPDATE COM.GUIAS_REMITENTE SET " & _
                                "EJERCICIO='0000', MES='00', COMPROBANTE_SERIE='0000', COMPROBANTE_NUMERO='0000000000', ESTADO='X' " & _
                                "WHERE Empresa=@vEmpresa AND Guia_remitente=@vGuia_remitente "
                        Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vGuia_remitente", pGuia)
                            MySQLCommand.ExecuteNonQuery()
                        End Using
                    End If

                End Using

                MySQLTransactionScope.Complete()

                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Private Shared Sub ExtornarGuiaProductos(ByVal pVenta As String)
        Dim MyGuiaProductos As New dsVentas.VENTAS_PRODUCTOSDataTable
        CadenaSQL = "SELECT G.EJERCICIO, G.MES, G.ALMACEN, G.PRODUCTO, G.NUMERO_LOTE, SUM(G.CANTIDAD) AS CANTIDAD " & _
                    "FROM COM.GUIAS_PRODUCTO AS G INNER JOIN COM.PRODUCTOS AS P ON G.EMPRESA=P.EMPRESA AND G.PRODUCTO=P.PRODUCTO " & _
                    "WHERE G.EMPRESA='" & MyEmpresa & "' AND G.VENTA='" & pVenta & "' AND P.INDICA_VALIDA_STOCK='SI' " & _
                    "GROUP BY G.EJERCICIO, G.MES, G.ALMACEN, G.PRODUCTO, G.NUMERO_LOTE "
        Call ObtenerDataTableSQL(CadenaSQL, MyGuiaProductos)
        If MyGuiaProductos.Rows.Count > 0 Then
            For NumReg1 = 0 To MyGuiaProductos.Rows.Count - 1
                With MyGuiaProductos(NumReg1)
                    MyAlmacen = .ALMACEN
                    MyNumeroLote = .NUMERO_LOTE
                    MyCantidad = .CANTIDAD * -1
                    Call ActualizarStockResumen(.PRODUCTO)
                    Call ActualizarStockPeriodo(.EJERCICIO, .MES, .PRODUCTO)
                End With
            Next
        End If
    End Sub

    Private Shared Sub ActualizarStockResumen(ByVal MyProducto As String)
        MySQL = "UPDATE ALM.RESUMEN_X_ALMACEN SET egresos=egresos+@vEgresos, usuario_modifica=@vUsuario_modifica, fecha_modifica=@vFecha_modifica " & _
                "WHERE empresa=@vEmpresa AND almacen=@vAlmacen AND numero_lote=@vNumero_lote AND producto=@vProducto "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEgresos", MyCantidad)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vAlmacen", MyAlmacen)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vProducto", MyProducto)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub ActualizarStockPeriodo(ByVal MyEjercicio As String, ByVal MyMes As String, ByVal MyProducto As String)
        Dim SiExisteResumenPeriodo As Boolean = EvaluarSiExisteResumenPeriodo(MyEjercicio, MyMes, MyProducto)
        If SiExisteResumenPeriodo = True Then
            MySQL = "UPDATE ALM.RESUMEN_X_PERIODO SET egresos=egresos+@vEgresos, usuario_modifica=@vUsuario_modifica, fecha_modifica=@vFecha_modifica " & _
                    "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND almacen=@vAlmacen AND numero_lote=@vNumero_lote AND producto=@vProducto "
        Else
            MySQL = "INSERT INTO ALM.RESUMEN_X_PERIODO " & _
                    "(empresa,ejercicio,mes,almacen,numero_lote,producto,ingresos,egresos,fecha_vencimiento,usuario_registro) " & _
                    "SELECT empresa,@vEjercicio AS ejercicio,@vMes AS mes,almacen,numero_lote,producto," & _
                    "@vIngresos AS ingresos,@vEgresos AS egresos,fecha_vencimiento,@vUsuario_registro AS usuario_registro " & _
                    "FROM ALM.RESUMEN_X_ALMACEN " & _
                    "WHERE empresa=@vEmpresa AND almacen=@vAlmacen AND numero_lote=@vNumero_lote AND producto=@vProducto "
        End If
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vEjercicio", MyEjercicio)
                    .AddWithValue("vMes", MyMes)
                    .AddWithValue("vAlmacen", MyAlmacen)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vProducto", MyProducto)
                    .AddWithValue("vIngresos", 0)
                    .AddWithValue("vEgresos", MyCantidad)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Function EvaluarSiExisteResumenPeriodo(ByVal MyEjercicio As String, ByVal MyMes As String, ByVal MyProducto As String) As Boolean
        MySQL = "SELECT COUNT(*) FROM ALM.RESUMEN_X_PERIODO " & _
                "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Almacen=@vAlmacen AND Numero_lote=@vNumero_lote AND Producto=@vProducto "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vEjercicio", MyEjercicio)
                .AddWithValue("vMes", MyMes)
                .AddWithValue("vAlmacen", MyAlmacen)
                .AddWithValue("vNumero_lote", MyNumeroLote)
                .AddWithValue("vProducto", MyProducto)
            End With
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Sub ExtornarGuia(ByVal pGuia As String)
        MySQL = "UPDATE COM.GUIAS_REMITENTE SET " & _
                "CUENTA_COMERCIAL='0001', ESTADO='N', " & _
                "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Guia_remitente=@vGuia_remitente "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vGuia_remitente", pGuia)
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function Grabar(ByVal cGuia As entGuiaRemitente) As entGuiaRemitente
        With cGuia
            If String.IsNullOrEmpty(.venta) Then Throw New BusinessException(MSG000 & " DATOS DEL COMPROBANTE")
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " G/R SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " G/R NUMERO")
            If Year(.comprobante_fecha) * 100 + Month(.comprobante_fecha) = 190001 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
            If Year(.fecha_inicio_traslado) * 100 + Month(.fecha_inicio_traslado) = 190001 Then Throw New BusinessException(MSG000 & " FECHA TRASLADO")
            If String.IsNullOrEmpty(.destinatario_domicilio.Trim) Then Throw New BusinessException(MSG000 & " DOMICILIO DESTINATARIO")


        End With
        Call BuscarComprobanteDuplicado(cGuia)
        If Not Existe(cVenta.venta) Then
            Return Insertar(cVenta)
        Else
            Return Actualizar(cVenta)
        End If
    End Function

    Private Shared Sub BuscarComprobanteDuplicado(ByVal cGuia As entGuiaRemitente)
        MyOtraGuia = Existe(cGuia, IIf(cGuia.guia_remitente = Nothing, True, False))
        If MyOtraGuia.guia_remitente <> Nothing Then Throw New BusinessException(MSG1003 & MyOtraGuia.mes)
    End Sub

    Private Shared Function Existe(ByVal cGuia As entGuiaRemitente, ByVal EsNuevo As Boolean) As entGuiaRemitente
        With cGuia
            If EsNuevo = True Then
                CadenaSQL = "SELECT * FROM COM.GUIAS_REMITENTE WHERE EMPRESA='" & .empresa & "' AND " & _
                            "CUENTA_COMERCIAL='" & .cuenta_comercial & "' AND COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "'"
            Else
                CadenaSQL = "SELECT * FROM COM.GUIAS_REMITENTE WHERE EMPRESA='" & .empresa & "' AND " & _
                            "CUENTA_COMERCIAL='" & .cuenta_comercial & "' AND COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "' AND " & _
                            "GUIA_REMITENTE<>'" & .guia_remitente & "'"
            End If
        End With
        Return Obtener(New entGuiaRemitente, CadenaSQL)
    End Function

    Private Shared Function Obtener(ByVal cGuia As entGuiaRemitente, ByVal MySQLString As String) As entGuiaRemitente
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
                .fecha_ultimo_pago = MyDT(0).FECHA_ULTIMO_PAGO
                .importe_saldo = MyDT(0).IMPORTE_SALDO
                .comentario = MyDT(0).COMENTARIO
                .tipo_venta = MyDT(0).TIPO_VENTA
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
                .indica_exportacion = MyDT(0).INDICA_EXPORTACION
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cVenta
    End Function


End Class
