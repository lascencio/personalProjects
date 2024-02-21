Imports System.Data.SqlClient

Public Class dalGuia

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand

    Public Shared Function EvaluarSerieVendida(pProducto As String, pNumeroSerie As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CONTROL_SERIES WHERE Empresa='" & MyUsuario.empresa & "' AND Producto='" & pProducto & "' AND Numero_serie='" & pNumeroSerie & "' AND Estado='V' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", pNumeroSerie)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using

    End Function

    Public Shared Function ObtenerCabecera(ByVal pGuia As String) As entGuia
        CadenaSQL = "SELECT * FROM COM.GUIAS WHERE EMPRESA='" & MyEmpresa & "' AND GUIA='" & pGuia & "'"
        Return Obtener(New entGuia, CadenaSQL)
    End Function

    Public Shared Function ObtenerGuiaTrasladoInterno(ByVal pNumeroGuia As String) As entGuia
        Dim Serie As String = Strings.Left(pNUmeroGuia, 4)
        Dim Numero As String = Strings.Mid(pNumeroGuia, 4, 10)
        CadenaSQL = "SELECT * FROM COM.GUIAS WHERE EMPRESA='" & MyEmpresa & "' AND COMPROBANTE_TIPO='09' " &
                    "AND COMPROBANTE_SERIE='" & Serie & "' " &
                    "AND COMPROBANTE_NUMERO='" & Numero & "' "
        Return Obtener(New entGuia, CadenaSQL)
    End Function

    Public Shared Function ObtenerGuiaTrasladoInterno(ByVal pSerie As String, ByVal pNumero As String) As entGuia
        CadenaSQL = "SELECT * FROM COM.GUIAS WHERE EMPRESA='" & MyEmpresa & "' AND COMPROBANTE_TIPO='09' " &
                    "AND COMPROBANTE_SERIE='" & pSerie & "' " &
                    "AND COMPROBANTE_NUMERO='" & pNumero & "' "
        Return Obtener(New entGuia, CadenaSQL)
    End Function

    Public Shared Function ObtenerGuiaTrasladoInterno(ByVal pGuia As entGuia) As entGuia
        CadenaSQL = "SELECT * FROM COM.GUIAS " & "WHERE EMPRESA='" & MyEmpresa & "' AND GUIA='" & pGuia.guia & "' "
        Return Obtener(New entGuia, CadenaSQL)
    End Function

    Private Shared Function Obtener(ByVal cGuia As entGuia, ByVal MySQLString As String) As entGuia
        Dim MyDT As New dsGuiasRemitente.GUIASDataTable
        Dim AgenciaOrigen As New dsAgencias.AGENCIASDataTable

        Call ObtenerDataTableSQL(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cGuia
                .empresa = MyDT(0).EMPRESA
                .guia = MyDT(0).GUIA
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .tipo_operacion = MyDT(0).TIPO_OPERACION
                .orden_pedido = MyDT(0).ORDEN_PEDIDO
                .venta = MyDT(0).VENTA
                .asiento_tipo = MyDT(0).ASIENTO_TIPO
                .asiento_numero = MyDT(0).ASIENTO_NUMERO
                .asiento_fecha = MyDT(0).ASIENTO_FECHA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .comprobante_tipo = MyDT(0).COMPROBANTE_TIPO
                .comprobante_serie = MyDT(0).COMPROBANTE_SERIE
                .comprobante_numero = MyDT(0).COMPROBANTE_NUMERO
                .comprobante_fecha = MyDT(0).COMPROBANTE_FECHA
                .comprobante_fecha_traslado = MyDT(0).COMPROBANTE_FECHA_TRASLADO
                .almacen = MyDT(0).ALMACEN
                .almacen_destino = MyDT(0).ALMACEN_DESTINO
                .centro_distribucion = MyDT(0).CENTRO_DISTRIBUCION
                .domicilio_envio = MyDT(0).DOMICILIO_ENVIO
                .referencia_cuo = MyDT(0).REFERENCIA_CUO
                .motivo_traslado = MyDT(0).MOTIVO_TRASLADO
                .punto_partida = MyDT(0).PUNTO_PARTIDA
                .punto_llegada = MyDT(0).PUNTO_LLEGADA
                .destinatario_tipo_documento = MyDT(0).DESTINATARIO_TIPO_DOCUMENTO
                .destinatario_nro_documento = MyDT(0).DESTINATARIO_NRO_DOCUMENTO
                .destinatario_razon_social = MyDT(0).DESTINATARIO_RAZON_SOCIAL
                .conductor_dni = MyDT(0).CONDUCTOR_DNI
                .conductor_nombre = MyDT(0).CONDUCTOR_NOMBRE
                .numero_placa = MyDT(0).NUMERO_PLACA
                .transportista_ruc = MyDT(0).TRANSPORTISTA_RUC
                .transportista_razon_social = MyDT(0).TRANSPORTISTA_RAZON_SOCIAL
                .comentario = MyDT(0).COMENTARIO
                .indica_transporte_publico = MyDT(0).INDICA_TRANSPORTE_PUBLICO
                .indica_impreso = MyDT(0).INDICA_IMPRESO
                .indica_exportacion = MyDT(0).INDICA_EXPORTACION
                .indica_migrado = MyDT(0).INDICA_MIGRADO

                .usuario_envio = MyDT(0).USUARIO_ENVIO
                .fecha_envio = MyDT(0).FECHA_ENVIO
                .estado_envio = MyDT(0).ESTADO_ENVIO
                .usuario_recepcion = MyDT(0).USUARIO_RECEPCION
                .fecha_recepcion = MyDT(0).FECHA_RECEPCION
                .comentario_recepion = MyDT(0).COMENTARIO_RECEPCION
                .estado_traslado_interno = MyDT(0).ESTADO_TRASLADO_INTERNO

                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA

                .ubigeo_origen = MyDomicilioUbigeo ' Viene y se define en frmLogin

                If .tipo_operacion = "G2" Then 'Traslado entre almacenes
                    Dim AgenciaDestino As New dsAgencias.AGENCIASDataTable
                    AgenciaDestino = dalAgencia.Obtener(MyUsuario.empresa, "A0000" & .almacen_destino)
                    .ubigeo_destino = AgenciaDestino(0).UBIGEO
                ElseIf .tipo_operacion = "G4" Then 'Venta vehicular

                End If
            End With
        End If
        Return cGuia
    End Function

    Public Shared Function GrabarGuiaPorVentaDirecta(cGuia As entGuia, cVentaDetalle As dsVentas.VENTA_DETDataTable, cVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable) As entGuia
        With cGuia
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE COMPROBANTE")
            If Year(.comprobante_fecha) = 1900 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
            If Year(.comprobante_fecha_traslado) = 1900 Then Throw New BusinessException(MSG000 & " FECHA TRASLADO")
        End With

        Return InsertarGuiaPorVentaDirecta(cGuia, cVentaDetalle, cVentaDetalleSeries)
    End Function

    Private Shared Function InsertarGuiaPorVentaDirecta(ByVal cGuia As entGuia, cVentaDetalle As dsVentas.VENTA_DETDataTable, cVentaDetalleSeries As dsVentas.VENTA_DET_SERIESDataTable) As entGuia
        Dim Linea As Byte = 0
        Dim LineaGuia As String

        cGuia.guia = AsignarGuia()

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO COM.GUIAS " &
                              "(empresa,guia,ejercicio,mes,tipo_operacion,venta,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero,comprobante_fecha," &
                              "comprobante_fecha_traslado,almacen,almacen_destino,domicilio_envio,motivo_traslado,punto_partida,punto_llegada,destinatario_tipo_documento," &
                              "destinatario_nro_documento,destinatario_razon_social,conductor_dni,conductor_nombre,numero_placa,transportista_ruc,transportista_razon_social," &
                              "comentario,indica_transporte_publico,usuario_registro) " &
                              "VALUES (" &
                              "@vEmpresa,@vGuia,@vEjercicio,@vMes,@vTipo_operacion,@vVenta,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha," &
                              "@vComprobante_fecha_traslado,@vAlmacen,@vAlmacen_destino,@vDomicilio_envio,@vMotivo_traslado,@vPunto_partida,@vPunto_llegada,@vDestinatario_tipo_documento," &
                              "@vDestinatario_nro_documento,@vDestinatario_razon_social,@vConductor_dni,@vconductor_nombre,@vNumero_placa,@vTransportista_ruc,@vTransportista_razon_social," &
                              "@vComentario,@vIndica_transporte_publico,@vUsuario_registro) "


                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        With MySQLCommand.Parameters
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vGuia", cGuia.guia)
                            .AddWithValue("vEjercicio", cGuia.ejercicio)
                            .AddWithValue("vMes", cGuia.mes)
                            .AddWithValue("vTipo_operacion", cGuia.tipo_operacion)
                            .AddWithValue("vVenta", cGuia.venta)
                            .AddWithValue("vCuenta_comercial", cGuia.cuenta_comercial.Trim)
                            .AddWithValue("vComprobante_tipo", cGuia.comprobante_tipo)
                            .AddWithValue("vComprobante_serie", cGuia.comprobante_serie)
                            .AddWithValue("vComprobante_numero", cGuia.comprobante_numero)
                            .AddWithValue("vComprobante_fecha", cGuia.comprobante_fecha)
                            .AddWithValue("vComprobante_fecha_traslado", cGuia.comprobante_fecha_traslado)
                            .AddWithValue("vAlmacen", cGuia.almacen)
                            .AddWithValue("vAlmacen_destino", cGuia.almacen_destino)
                            .AddWithValue("vDomicilio_envio", cGuia.domicilio_envio)

                            .AddWithValue("vMotivo_traslado", cGuia.motivo_traslado)
                            .AddWithValue("vPunto_partida", cGuia.punto_partida)
                            .AddWithValue("vPunto_llegada", cGuia.punto_llegada)
                            .AddWithValue("vDestinatario_tipo_documento", cGuia.destinatario_tipo_documento)
                            .AddWithValue("vDestinatario_nro_documento", cGuia.destinatario_nro_documento)
                            .AddWithValue("vDestinatario_razon_social", cGuia.destinatario_razon_social)
                            .AddWithValue("vConductor_dni", cGuia.conductor_dni)
                            .AddWithValue("vConductor_nombre", cGuia.conductor_nombre)
                            .AddWithValue("vNumero_placa", cGuia.numero_placa)
                            .AddWithValue("vTransportista_ruc", cGuia.transportista_ruc)
                            .AddWithValue("vTransportista_razon_social", cGuia.transportista_razon_social)
                            .AddWithValue("vComentario", cGuia.comentario)
                            .AddWithValue("vIndica_transporte_publico", cGuia.indica_transporte_publico)
                            .AddWithValue("vUsuario_registro", cGuia.usuario_registro)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                        MySqlString = "INSERT INTO COM.GUIAS_DET " & _
                                      "(empresa,guia,linea,producto,cantidad_por_atender,cantidad_atendida,indica_serie,venta,venta_linea,usuario_registro) " & _
                                      "VALUES (@vEmpresa,@vGuia,@vLinea,@vProducto,@vCantidad_por_atender,@vCantidad_atendida,@vIndica_serie,@vVenta,@vVenta_linea,@vUsuario_registro) "

                        For NEle As Integer = 0 To cVentaDetalle.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            Linea = Linea + 1
                            LineaGuia = Strings.Right("000" & Linea.ToString, 3)

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vGuia", cGuia.guia)
                                .AddWithValue("vLinea", LineaGuia)
                                .AddWithValue("vProducto", cVentaDetalle(NEle).PRODUCTO)
                                .AddWithValue("vCantidad_por_atender", cVentaDetalle(NEle).CANTIDAD)
                                .AddWithValue("vCantidad_atendida", cVentaDetalle(NEle).CANTIDAD)
                                .AddWithValue("vIndica_serie", cVentaDetalle(NEle).INDICA_SERIE)
                                .AddWithValue("vVenta", cGuia.venta)
                                .AddWithValue("vVenta_linea", cVentaDetalle(NEle).LINEA)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        MySqlString = "INSERT INTO COM.GUIAS_DET_SERIES " & _
                                      "(empresa,guia,producto,numero_serie,numero_serie_chasis,color,usuario_registro) " & _
                                      "VALUES (@vEmpresa,@vGuia,@vProducto,@vNumero_serie,@vNumero_serie_chasis,@vColor,@vUsuario_registro) "

                        For NEle As Integer = 0 To cVentaDetalleSeries.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vGuia", cGuia.guia)
                                .AddWithValue("vProducto", cVentaDetalleSeries(NEle).PRODUCTO)
                                .AddWithValue("vNumero_serie", cVentaDetalleSeries(NEle).NUMERO_SERIE)
                                .AddWithValue("vNumero_serie_chasis", cVentaDetalleSeries(NEle).NUMERO_SERIE_CHASIS)
                                .AddWithValue("vColor", cVentaDetalleSeries(NEle).COLOR)
                                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                            End With
                            MySQLCommand.ExecuteNonQuery()
                        Next

                        MySqlString = "UPDATE COM.VENTAS SET " &
                                      "Guia_remitente=@vGuia, Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()

                        With MySQLCommand.Parameters
                            .AddWithValue("vGuia", cGuia.guia)
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vEmpresa", MyUsuario.empresa)
                            .AddWithValue("vVenta", cGuia.venta)
                        End With
                        MySQLCommand.ExecuteNonQuery()

                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return cGuia
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

    Public Shared Function RelacionGuias(ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String, ByVal pTipoOperacion As String, ByVal pEstado As String) As dsGuiasRemitente.GUIAS_LISTADataTable
        MySqlString = "SELECT G.GUIA,G.COMPROBANTE_SERIE,G.COMPROBANTE_NUMERO,G.COMPROBANTE_FECHA,G.COMPROBANTE_FECHA_TRASLADO," &
                      "ISNULL(CC.RAZON_SOCIAL,G.DESTINATARIO_RAZON_SOCIAL) AS RAZON_SOCIAL,G.ORDEN_PEDIDO,G.ESTADO " &
                      "FROM COM.GUIAS AS G LEFT OUTER JOIN COM.CUENTAS_COMERCIALES AS CC ON G.EMPRESA=CC.EMPRESA AND G.CUENTA_COMERCIAL=CC.CUENTA_COMERCIAL " &
                      "WHERE G.EMPRESA=@vEmpresa AND G.EJERCICIO=@vEjercicio AND G.MES=@vMes AND G.GUIA<>'GR0000000000' AND G.ALMACEN=@vAlmacen " &
                      IIf(pCuentaComercial <> "TODOS", " AND G.CUENTA_COMERCIAL=@vCuenta_comercial ", " ") &
                      IIf(pTipoOperacion <> "TODOS", " AND G.TIPO_OPERACION=@vTipo_operacion ", "") &
                      IIf(pEstado <> "TODOS", " AND G.ESTADO=@vEstado ", " ") &
                      "ORDER BY G.GUIA DESC"

        Dim MyDT As New dsGuiasRemitente.GUIAS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)

            If pCuentaComercial <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", pCuentaComercial)
            If pTipoOperacion <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vTipo_operacion", pTipoOperacion)
            If pEstado <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function RelacionGuiasSunat(ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String, ByVal pTipoOperacion As String, ByVal pEstado As String) As dsGuiasRemitente.GUIAS_SUNATDataTable
        MySqlString = "SELECT G.GUIA,G.COMPROBANTE_SERIE,G.COMPROBANTE_NUMERO,G.COMPROBANTE_FECHA,G.COMPROBANTE_FECHA_TRASLADO," &
                      "ISNULL(CC.RAZON_SOCIAL,G.DESTINATARIO_RAZON_SOCIAL) AS RAZON_SOCIAL,G.USUARIO_ENVIO," &
                      "FECHA_ENVIO=CASE WHEN YEAR(G.FECHA_ENVIO)=1900 THEN NULL ELSE G.FECHA_ENVIO END,G.ESTADO_ENVIO,G.ESTADO " &
                      "FROM COM.GUIAS AS G LEFT OUTER JOIN COM.CUENTAS_COMERCIALES AS CC ON G.EMPRESA=CC.EMPRESA AND G.CUENTA_COMERCIAL=CC.CUENTA_COMERCIAL " &
                      "WHERE G.EMPRESA=@vEmpresa AND G.EJERCICIO=@vEjercicio AND G.MES=@vMes AND G.GUIA<>'GR0000000000' AND G.ALMACEN=@vAlmacen " &
                      IIf(pCuentaComercial <> "TODOS", " AND G.CUENTA_COMERCIAL=@vCuenta_comercial ", " ") &
                      IIf(pTipoOperacion <> "TODOS", " AND G.TIPO_OPERACION=@vTipo_operacion ", "") &
                      IIf(pEstado <> "TODOS", " AND G.ESTADO=@vEstado ", " ") &
                      "ORDER BY G.GUIA DESC"

        Dim MyDT As New dsGuiasRemitente.GUIAS_SUNATDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", MyUsuario.almacen)

            If pCuentaComercial <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", pCuentaComercial)
            If pTipoOperacion <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vTipo_operacion", pTipoOperacion)
            If pEstado <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function RelacionGuiasTrasladoInterno(ByVal pEjercicio As String, ByVal pMes As String, pEstadoTrasladoInterno As String, pAlmacenDestino As String) As dsGuiasRemitente.GUIAS_TRASLADODataTable
        MySqlString = "SELECT G.GUIA, G.ALMACEN, ALMACEN_DESCRIPCION=TA.DESCRIPCION, G.COMPROBANTE_SERIE,G.COMPROBANTE_NUMERO, " &
                      "G.COMPROBANTE_FECHA, G.COMPROBANTE_FECHA_TRASLADO, G.USUARIO_REGISTRO, G.COMENTARIO, G.REFERENCIA_CUO " &
                      "FROM COM.GUIAS AS G INNER JOIN GEN.TABLA_ALMACENES AS TA ON G.EMPRESA=TA.EMPRESA AND G.ALMACEN=TA.CODIGO " &
                      "WHERE G.EMPRESA=@vEmpresa AND G.EJERCICIO=@vEjercicio AND G.MES=@vMes AND G.TIPO_OPERACION='G2' " &
                      "AND G.ALMACEN_DESTINO=@vAlmacen_destino AND G.ESTADO<>'N' AND G.ESTADO_TRASLADO_INTERNO=@vEstado_traslado_interno " &
                      "ORDER BY G.GUIA DESC"

        Dim MyDT As New dsGuiasRemitente.GUIAS_TRASLADODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAlmacen_destino", pAlmacenDestino)
            MySQLCommand.Parameters.AddWithValue("vEstado_traslado_interno", pEstadoTrasladoInterno)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerComprobante(ByVal pGuia As String) As dsGuiasRemitente.COMPROBANTEDataTable
        MySqlString = "SELECT H.EMPRESA, H.GUIA, H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO AS COMPROBANTE, H.COMPROBANTE_FECHA, H.COMPROBANTE_FECHA_TRASLADO, " &
                      "H.COMENTARIO,H.CUENTA_COMERCIAL, RAZON_SOCIAL=ISNULL(CC.RAZON_SOCIAL,H.DESTINATARIO_RAZON_SOCIAL)," &
                      "NRO_DOCUMENTO=ISNULL(CC.NRO_DOCUMENTO, H.DESTINATARIO_NRO_DOCUMENTO), DIRECCION=ISNULL(DOM.DIRECCION,H.PUNTO_LLEGADA), " &
                      "REFERENCIA=ISNULL(DOM.REFERENCIA,SPACE(1)), TRANSPORTISTA=H.TRANSPORTISTA_RAZON_SOCIAL, BREVETE=SPACE(1), UNIDAD_TRANSPORTE=H.NUMERO_PLACA, " &
                      "ISNULL(LEFT(V.TIPO_OPERACION, 1) + '/' + V.COMPROBANTE_SERIE + '-' + V.COMPROBANTE_NUMERO, SPACE(1)) AS COMPROBANTE_VENTA " &
                      "FROM COM.GUIAS AS H LEFT OUTER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " &
                                          "LEFT OUTER JOIN COM.DIRECCION_ENVIO AS DOM ON H.EMPRESA = DOM.EMPRESA AND H.CUENTA_COMERCIAL = DOM.CUENTA_COMERCIAL AND H.CENTRO_DISTRIBUCION = DOM.DOMICILIO_ENVIO " &
                                          "LEFT OUTER JOIN COM.VENTAS AS V ON H.EMPRESA = V.EMPRESA AND H.VENTA = V.VENTA   " &
                "WHERE H.EMPRESA=@vEmpresa AND H.GUIA= @vGuia "

        Dim MyDT As New dsGuiasRemitente.COMPROBANTEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vGuia", pGuia)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function GuiaDetallada(ByVal pGuia As String) As dsGuiasRemitente.GUIA_DETALLADataTable
        MySqlString = "SELECT H.EMPRESA, H.GUIA, H.CUENTA_COMERCIAL, RAZON_SOCIAL=ISNULL(CC.RAZON_SOCIAL,H.DESTINATARIO_RAZON_SOCIAL), " & _
                      "NRO_COMPROBANTE= 'G/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO, H.COMPROBANTE_FECHA, D.LINEA, " & _
                      "D.PRODUCTO, RTRIM(P.DESCRIPCION_AMPLIADA) AS DESCRIPCION, D.CANTIDAD_ATENDIDA AS CANTIDAD, " & _
                      " P.CODIGO_COMPRA, P.INDICA_SERIE, P.PRODUCTO_FAMILIA, TPF.DESCRIPCION AS FAMILIA, P.PRODUCTO_TIPO, TPT.DESCRIPCION AS TIPO " & _
                      "FROM COM.GUIAS AS H INNER JOIN COM.GUIAS_DET AS D ON H.EMPRESA = D.EMPRESA AND H.GUIA = D.GUIA " & _
                                          "INNER JOIN COM.PRODUCTOS AS P ON D.EMPRESA = P.EMPRESA AND D.PRODUCTO = P.PRODUCTO " & _
                                          "LEFT OUTER JOIN COM.CUENTAS_COMERCIALES AS CC ON H.EMPRESA = CC.EMPRESA AND H.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL " & _
                                          "INNER JOIN GEN.TABLA_PRODUCTO_FAMILIA AS TPF ON P.EMPRESA = TPF.EMPRESA AND P.PRODUCTO_FAMILIA = TPF.CODIGO " & _
                                          "INNER JOIN GEN.TABLA_PRODUCTO_TIPO AS TPT ON P.EMPRESA = TPT.EMPRESA AND P.PRODUCTO_TIPO = TPT.CODIGO " & _
                "WHERE H.EMPRESA=@vEmpresa AND H.GUIA='" & pGuia & "' "

        Dim MyDT As New dsGuiasRemitente.GUIA_DETALLADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
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

    Public Shared Function ObtenerComprobanteSeries(ByVal pGuia As String) As dsGuiasRemitente.COMPROBANTE_SERIESDataTable
        MySqlString = "SELECT PRODUCTO, NUMERO_SERIE " & _
                      "FROM COM.GUIAS_DET_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND GUIA= @vGuia "

        Dim MyDT As New dsGuiasRemitente.COMPROBANTE_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vGuia", pGuia)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ActualizarEstadoEnvio(ByVal pEmpresa As String, ByVal pGuia As String, pEstado As String) As Boolean

        MySqlString = "UPDATE COM.GUIAS SET " & _
                      "Usuario_envio=@vUsuario_envio,Fecha_envio=GETDATE(), Estado_envio=@vEstado " & _
                      "WHERE Empresa=@vEmpresa AND Guia=@vGuia "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEstado", pEstado)
                .AddWithValue("vUsuario_envio", MyUsuario.usuario)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vGuia", pGuia)
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

    Public Shared Function ObtenerCabecera(ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As entGuia
        CadenaSQL = "SELECT * FROM COM.GUIAS WHERE EMPRESA='" & MyEmpresa & "' AND COMPROBANTE_TIPO='" & pTipo & "' AND COMPROBANTE_SERIE='" & pSerie & "' AND COMPROBANTE_NUMERO='" & pNumero & "'"
        Return Obtener(New entGuia, CadenaSQL)
    End Function

    Public Shared Function GuiasInforme(ByVal pEjercicio As String, ByVal pMes As String, pDia As Byte, ByVal pEstado As String) As dsGuiasRemitente.GUIAS_INFORMEDataTable

        MySqlString = "SELECT H.EMPRESA, H.GUIA, H.EJERCICIO, H.MES, H.TIPO_OPERACION, TTG.DESCRIPCION AS TIPO_OPERACION_DESCRIPCION, H.ORDEN_PEDIDO, H.VENTA, H.CUENTA_COMERCIAL, " &
                      "H.DESTINATARIO_RAZON_SOCIAL, " &
                      "'G/' + H.COMPROBANTE_SERIE + '-' + H.COMPROBANTE_NUMERO AS NRO_GUIA, H.COMPROBANTE_FECHA, H.COMPROBANTE_FECHA_TRASLADO, H.ALMACEN, TAO.DESCRIPCION AS ALMACEN_DECRIPCION," &
                      "H.ALMACEN_DESTINO, CASE WHEN H.TIPO_OPERACION = 'G2' THEN TAD.DESCRIPCION ELSE SPACE(1) END AS ALMACEN_DESTINO_DESCRIPCION, H.COMENTARIO, " &
                      "H.CONDUCTOR_DNI, H.CONDUCTOR_NOMBRE, H.NUMERO_PLACA, H.TRANSPORTISTA_RUC, H.TRANSPORTISTA_RAZON_SOCIAL, " &
                      "ISNULL(V.COMPROBANTE_SERIE + '-' + V.COMPROBANTE_NUMERO, SPACE(1)) AS NRO_COMPROBANTE, H.USUARIO_REGISTRO, H.USUARIO_ENVIO, H.FECHA_ENVIO, H.ESTADO_ENVIO " &
                      "FROM COM.GUIAS AS H INNER JOIN GEN.TABLA_TIPO_GUIA AS TTG ON H.EMPRESA = TTG.EMPRESA AND H.TIPO_OPERACION = TTG.CODIGO " &
                                          "INNER JOIN GEN.TABLA_ALMACENES AS TAO ON H.EMPRESA = TAO.EMPRESA AND H.ALMACEN = TAO.CODIGO " &
                                          "INNER JOIN GEN.TABLA_ALMACENES AS TAD ON H.EMPRESA = TAD.EMPRESA AND H.ALMACEN_DESTINO = TAD.CODIGO " &
                                          "LEFT OUTER JOIN COM.VENTAS AS V ON H.EMPRESA = V.EMPRESA AND H.VENTA = V.VENTA " &
                      "WHERE H.EMPRESA=@vEmpresa AND H.EJERCICIO= @vEjercicio AND H.MES=@vMes AND H.GUIA<>'GR0000000000' " &
                      IIf(pDia = 0, " ", " AND DAY(H.COMPROBANTE_FECHA)=" & pDia & " ") &
                      "ORDER BY H.GUIA "

        Dim MyDT As New dsGuiasRemitente.GUIAS_INFORMEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
