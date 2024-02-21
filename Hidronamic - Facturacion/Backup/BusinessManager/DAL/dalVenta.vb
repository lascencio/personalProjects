Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalVenta

    Private Shared MyOtraVenta As entVenta

    Private Shared MySQL As String
    Private Shared MyOleDBString As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String

    Private Shared MyAlmacen As String
    Private Shared MyNumeroLote As String
    Private Shared MyVentaLinea As String
    Private Shared MyNumeroLinea As String
    Private Shared MyCantidad As Integer

    Private Shared MyImporteTotalOrigen As Decimal = 0
    Private Shared MyImporteSubTotalOrigen As Decimal = 0
    Private Shared MyBaseImponibleGravadaOrigen = 0
    Private Shared MyIGVOrigen = 0

    Private Shared MyImporteTotalMN As Decimal = 0
    Private Shared MyImporteSubTotalMN As Decimal = 0
    Private Shared MyBaseImponibleGravadaMN = 0
    Private Shared MyIGVMN = 0

    Private Shared MyImporteTotalME As Decimal = 0
    Private Shared MyImporteSubTotalME As Decimal = 0
    Private Shared MyBaseImponibleGravadaME = 0
    Private Shared MyIGVME = 0

    Private Shared MyTipoMoneda As String
    Private Shared MyTipoCambio As Decimal

    Private Shared NumReg1 As Integer = 0
    Private Shared NumReg2 As Integer = 0
    Private Shared NumReg3 As Integer = 0

    Private Sub New()
    End Sub

    Public Shared Function Obtener(ByVal pVenta As String, ByVal pLinea As String) As entVentaServicio
        CadenaSQL = "SELECT * FROM COM.VENTAS_SER WHERE EMPRESA='" & MyUsuario.empresa & "' AND VENTA='" & pVenta & "' AND LINEA='" & pLinea & "' "
        Return Obtener(New entVentaServicio, CadenaSQL)
    End Function

    Public Shared Function ObtenerVentaServicio(ByVal pVenta As String) As dsVentas.VENTAS_SERDataTable
        Dim MyDT As New dsVentas.VENTAS_SERDataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS_SER WHERE EMPRESA='" & MyUsuario.empresa & "' AND VENTA='" & pVenta & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerVentaProducto(ByVal pVenta As String) As dsVentas.VENTAS_PRODataTable
        Dim MyDT As New dsVentas.VENTAS_PRODataTable
        CadenaSQL = "SELECT * FROM COM.VENTAS_PRO WHERE EMPRESA='" & MyUsuario.empresa & "' AND VENTA='" & pVenta & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Private Shared Function Obtener(ByVal cVentaDetalle As entVentaServicio, ByVal MySQLString As String) As entVentaServicio
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

                .descuento_1 = MyDT(0).DESCUENTO_1
                .descuento_2 = MyDT(0).DESCUENTO_2
                .descuento_3 = MyDT(0).DESCUENTO_3

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

    Public Shared Function BuscarAsientosVentaMigrar(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pIndicaExportacion As String) As dsAsientoContable.ASIENTOS_VENTA_LISTADataTable
        MyStoreProcedure = "CON.ASIENTOS_VENTA_MIGRAR"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@INDICA_EXPORTACION", SqlDbType.Char, 2) : MyParameter_4.Value = pIndicaExportacion

        Dim MyDT As New dsAsientoContable.ASIENTOS_VENTA_LISTADataTable

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

    Public Shared Function BuscarAsientosCabeceraMigrar(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pIndicaExportacion As String) As dsAsientoContable.ASIENTOS_VENTA_CABECERADataTable
        MyStoreProcedure = "CON.ASIENTOS_CONCAR_CABECERA_MIGRAR"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@SUBDIARIO", SqlDbType.Char, 2) : MyParameter_4.Value = pMes
        Dim MyParameter_5 As New SqlParameter("@COMPROBANTE", SqlDbType.Char, 6) : MyParameter_5.Value = pMes

        Dim MyDT As New dsAsientoContable.ASIENTOS_VENTA_CABECERADataTable

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

    Public Shared Function BuscarAsientosDetalleMigrar(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pIndicaExportacion As String) As dsAsientoContable.ASIENTOS_VENTA_DETALLEDataTable
        MyStoreProcedure = "CON.ASIENTOS_CONCAR_CABECERA_MIGRAR"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@SUBDIARIO", SqlDbType.Char, 2) : MyParameter_4.Value = pMes
        Dim MyParameter_5 As New SqlParameter("@COMPROBANTE", SqlDbType.Char, 6) : MyParameter_5.Value = pMes

        Dim MyDT As New dsAsientoContable.ASIENTOS_VENTA_DETALLEDataTable

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

    Public Shared Function BuscarFacturacion(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String) As dsFacturacionLista.FACTURACION_LISTADataTable
        MyStoreProcedure = "COM.FACTURACION_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.VarChar, 8) : MyParameter_4.Value = pCuentaComercial

        Dim MyDT As New dsFacturacionLista.FACTURACION_LISTADataTable

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

    Public Shared Function BuscarFacturacionDetalles(ByVal pEmpresa As String, ByVal pVenta As String) As dsFacturacionDetallesLista.FACTURACION_SER_LISTADataTable
        MyStoreProcedure = "COM.FACTURACION_SER_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@VENTA", SqlDbType.Char, 12) : MyParameter_2.Value = pVenta

        Dim MyDT As New dsFacturacionDetallesLista.FACTURACION_SER_LISTADataTable
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

    Public Shared Function ObtenerDatosCabecera(ByVal pEmpresa As String, ByVal pVenta As String) As dsFacturasLista.FACTURAS_LISTADataTable
        MySQLString = "SELECT V.VENTA, V.FECHA_REGISTRO, V.COMENTARIO, V.ESTADO, C.RAZON_SOCIAL, D.DOMICILIO, D.ZONA, " & _
                      "D.DEPARTAMENTO, D.PROVINCIA, D.DISTRITO, C.NRO_DOCUMENTO, V.COMPROBANTE_SERIE, V.COMPROBANTE_NUMERO, V.COMPROBANTE_FECHA " & _
                      "FROM COM.VENTAS AS V INNER JOIN COM.CUENTAS_COMERCIALES AS C " & _
                      "ON V.EMPRESA=C.EMPRESA AND V.CUENTA_COMERCIAL=C.CUENTA_COMERCIAL INNER JOIN COM.DOMICILIO_FISCAL AS D " & _
                      "ON V.EMPRESA=D.EMPRESA AND V.CUENTA_COMERCIAL=D.CUENTA_COMERCIAL " & _
                      "WHERE V.EMPRESA=@vEmpresa AND V.VENTA=@vVenta "

        Dim MyDT As New dsFacturasLista.FACTURAS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
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

    Public Shared Function ObtenerDomicilio(ByVal pAnexo As String, ByVal pAvAnexo As String) As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable
        MySQLString = "SELECT * FROM CON.ANEXOS_DOMICILIO WHERE avanexo=@vAvanexo AND acodane=@vAcodane "

        Dim MyDT As New dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()

            MySQLCommand.Parameters.AddWithValue("vAvanexo", pAvAnexo)
            MySQLCommand.Parameters.AddWithValue("vAcodane", pAnexo)

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

    Public Shared Function ObtenerCorrelativoCONCAR(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pSubDiario As String) As dsCorrelativo.CORRELATIVO_CONCARDataTable
        MyStoreProcedure = "CON.CORRELATIVO_CONCAR"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@SUBDIARIO", SqlDbType.Char, 2) : MyParameter_4.Value = pSubDiario

        Dim MyDT As New dsCorrelativo.CORRELATIVO_CONCARDataTable
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

    Public Shared Function BuscarFacturacionMensuales(ByVal pEmpresa As String, ByVal pPeriodo As String, ByVal pMes As String) As dsFacturasMensuales.FACTURAS_MENSUALESDataTable
        MyStoreProcedure = "COM.FACTURAS_MENSUALES"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@PERIODO", SqlDbType.Char, 4) : MyParameter_2.Value = pPeriodo
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes

        Dim MyDT As New dsFacturasMensuales.FACTURAS_MENSUALESDataTable
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

    Public Shared Function BuscarVentas(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pCuentaComercial As String) As dsVentasLista.VENTAS_LISTADataTable
        MyStoreProcedure = "COM.VENTAS_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = pEjercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = pMes
        Dim MyParameter_4 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.VarChar, 8) : MyParameter_4.Value = pCuentaComercial

        Dim MyDT As New dsVentasLista.VENTAS_LISTADataTable

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

    Private Shared Function AsignarLinea(ByVal pVenta As String) As String

        MySQL = "SELECT ISNULL(MAX(LINEA),'') AS NUEVA_LINEA FROM COM.VENTAS_PRO " & _
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

    Public Shared Function ObtenerSiguiente(ByVal cVenta As entVenta) As entVenta
        With cVenta
            CadenaSQL = "SELECT TOP 1 * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND EJERCICIO='" & .ejercicio & _
                       "' AND MES='" & .mes & "' AND " & "VENTA>'" & .venta & "' "
        End With
        Return Obtener(New entVenta, CadenaSQL)
    End Function

    Public Shared Function ObtenerAnterior(ByVal cVenta As entVenta) As entVenta
        With cVenta
            CadenaSQL = "SELECT TOP 1 * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND EJERCICIO='" & .ejercicio & _
                       "' AND MES='" & .mes & "' AND " & "VENTA<'" & .venta & "' " & _
                       "ORDER BY VENTA DESC"
        End With
        Return Obtener(New entVenta, CadenaSQL)
    End Function

    Public Shared Function InsertarVenta(ByRef MyProgressBar As ProgressBar, ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal MyAsientosVenta As dsAsientoContable.ASIENTOS_VENTA_LISTADataTable) As Boolean
        Dim MyAsientoVentaDetalle As dsAsientoContable.ASIENTOS_VENTA_DETALLEDataTable

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)

            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyProgressBar.Visible = True

                MyProgressBar.Minimum = 0
                MyProgressBar.Maximum = MyAsientosVenta.Rows.Count
                MyProgressBar.Value = 0
                MyProgressBar.Step = 1

                For MyFilaC = 0 To MyAsientosVenta.Rows.Count - 1
                    If MyAsientosVenta(MyFilaC).cindica_exportacion = True Then
                        MyAsientoVentaDetalle = New dsAsientoContable.ASIENTOS_VENTA_DETALLEDataTable
                        MyOleDBString = "INSERT INTO ccc03" & pEjercicio.Substring(2, 2) & " " & _
                                        "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                        MyOleDBCommand.CommandType = CommandType.Text
                        MyOleDBCommand.CommandText = MyOleDBString

                        MyOleDBCommand.Parameters.Clear()
                        MyOleDBCommand.Parameters.AddWithValue("csubdia", MyAsientosVenta(MyFilaC).csubdia)
                        MyOleDBCommand.Parameters.AddWithValue("ccompro", MyAsientosVenta(MyFilaC).ccorrelativo)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom", MyAsientosVenta(MyFilaC).cfeccom)
                        MyOleDBCommand.Parameters.AddWithValue("ccodmon", MyAsientosVenta(MyFilaC).ccodmon)
                        MyOleDBCommand.Parameters.AddWithValue("csitua", MyAsientosVenta(MyFilaC).csitua)
                        MyOleDBCommand.Parameters.AddWithValue("ctipcam", MyAsientosVenta(MyFilaC).ctipcam)
                        MyOleDBCommand.Parameters.AddWithValue("cglosa", MyAsientosVenta(MyFilaC).cglosa.Trim)
                        MyOleDBCommand.Parameters.AddWithValue("ctotal", MyAsientosVenta(MyFilaC).ctotal)
                        MyOleDBCommand.Parameters.AddWithValue("ctipo", MyAsientosVenta(MyFilaC).ctipo)
                        MyOleDBCommand.Parameters.AddWithValue("cflag", MyAsientosVenta(MyFilaC).cflag)
                        MyOleDBCommand.Parameters.AddWithValue("cdate", MyAsientosVenta(MyFilaC).cdate2)
                        MyOleDBCommand.Parameters.AddWithValue("chora", "00:00:")
                        MyOleDBCommand.Parameters.AddWithValue("cuser", "SIST")
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("corig", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cform", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("ctipcom", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cextor", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom2", MyAsientosVenta(MyFilaC).cfeccom2)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam2", MyAsientosVenta(MyFilaC).cfeccam2)
                        MyOleDBCommand.ExecuteNonQuery()

                        MySqlString = "SELECT * FROM CON.ASIENTOS_VENTA_DETALLE " & _
                                      "WHERE dempresa='" & pEmpresa & "' AND dejercicio='" & pEjercicio & "' AND dmes='" & pMes & "' AND " & _
                                      "dsubdia='" & MyAsientosVenta(MyFilaC).csubdia & "' AND dcompro='" & MyAsientosVenta(MyFilaC).ccompro & "' "

                        Call ObtenerDataTableSQL(MySqlString, MyAsientoVentaDetalle)

                        If MyAsientoVentaDetalle.Rows.Count > 0 Then
                            MyOleDBString = "INSERT INTO ccd03" & pEjercicio.Substring(2, 2) & " " & _
                                            "(dsubdia, dcompro, dsecue, dfeccom, dcuenta, dcodane, dcencos, dcodmon, ddh, dimport, dtipdoc, dnumdoc, dfecdoc, dfecven, darea, dflag, ddate, dxglosa, " & _
                                            "dusimpor, dmnimpor, dcodarc, dfeccom2, dfecdoc2, dfecven2, dcodane2, dvanexo, dvanexo2, dtipcam, dcantid, drete, dporre, dtipdor, dnumdor, dfecdo2, dtiptas, " & _
                                            "dimptas, dimpbmn, dimpbus, dinacom, digvcom, dmedpag, dmoncom, dcolcom, dbascom, dtpconv, dflgcom, dtipaco, danecom) " & _
                                            "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                            MyOleDBCommand.CommandType = CommandType.Text
                            MyOleDBCommand.CommandText = MyOleDBString

                            For MyFilaD = 0 To MyAsientoVentaDetalle.Rows.Count - 1
                                MyOleDBCommand.Parameters.Clear()
                                MyOleDBCommand.Parameters.AddWithValue("dsubdia", MyAsientosVenta(MyFilaC).csubdia)
                                MyOleDBCommand.Parameters.AddWithValue("dcompro", MyAsientosVenta(MyFilaC).ccorrelativo)
                                MyOleDBCommand.Parameters.AddWithValue("dsecue", Strings.Right("0000" & CStr(MyFilaD + 1), 4))
                                MyOleDBCommand.Parameters.AddWithValue("dfeccom", MyAsientoVentaDetalle(MyFilaD).dfeccom)
                                MyOleDBCommand.Parameters.AddWithValue("dcuenta", MyAsientoVentaDetalle(MyFilaD).dcuenta)
                                MyOleDBCommand.Parameters.AddWithValue("dcodane", MyAsientoVentaDetalle(MyFilaD).dcodane.Trim)
                                MyOleDBCommand.Parameters.AddWithValue("dcencos", MyAsientoVentaDetalle(MyFilaD).dcencos.Trim)
                                MyOleDBCommand.Parameters.AddWithValue("dcodmon", MyAsientoVentaDetalle(MyFilaD).dcodmon)
                                MyOleDBCommand.Parameters.AddWithValue("ddh", MyAsientoVentaDetalle(MyFilaD).ddh)
                                MyOleDBCommand.Parameters.AddWithValue("dimport", MyAsientoVentaDetalle(MyFilaD).dimport)
                                MyOleDBCommand.Parameters.AddWithValue("dtipdoc", MyAsientoVentaDetalle(MyFilaD).dtipdoc)
                                MyOleDBCommand.Parameters.AddWithValue("dnumdoc", MyAsientoVentaDetalle(MyFilaD).dnumdoc)
                                MyOleDBCommand.Parameters.AddWithValue("dfecdoc", MyAsientoVentaDetalle(MyFilaD).dfecdoc)
                                MyOleDBCommand.Parameters.AddWithValue("dfecven", MyAsientoVentaDetalle(MyFilaD).dfecven)
                                MyOleDBCommand.Parameters.AddWithValue("darea", MyAsientoVentaDetalle(MyFilaD).darea)
                                MyOleDBCommand.Parameters.AddWithValue("dflag", MyAsientoVentaDetalle(MyFilaD).dflag)
                                'MyOleDBCommand.Parameters.AddWithValue("ddate", MyAsientoVentaDetalle(MyFilaD).ddate)
                                MyOleDBCommand.Parameters.AddWithValue("ddate", MyAsientoVentaDetalle(MyFilaD).dfeccom2)
                                MyOleDBCommand.Parameters.AddWithValue("dxglosa", MyAsientoVentaDetalle(MyFilaD).dxglosa.Trim)
                                MyOleDBCommand.Parameters.AddWithValue("dusimpor", MyAsientoVentaDetalle(MyFilaD).dusimpor)
                                MyOleDBCommand.Parameters.AddWithValue("dmnimpor", MyAsientoVentaDetalle(MyFilaD).dmnimpor)
                                MyOleDBCommand.Parameters.AddWithValue("dcodarc", MyAsientoVentaDetalle(MyFilaD).dcodarc)
                                MyOleDBCommand.Parameters.AddWithValue("dfeccom2", MyAsientoVentaDetalle(MyFilaD).dfeccom2)
                                MyOleDBCommand.Parameters.AddWithValue("dfecdoc2", MyAsientoVentaDetalle(MyFilaD).dfecdoc2)
                                MyOleDBCommand.Parameters.AddWithValue("dfecven2", MyAsientoVentaDetalle(MyFilaD).dfecven2)
                                MyOleDBCommand.Parameters.AddWithValue("dcodane2", MyAsientoVentaDetalle(MyFilaD).dcodane2.Trim)
                                MyOleDBCommand.Parameters.AddWithValue("dvanexo", MyAsientoVentaDetalle(MyFilaD).dvanexo)
                                MyOleDBCommand.Parameters.AddWithValue("dvanexo2", MyAsientoVentaDetalle(MyFilaD).dvanexo2)
                                MyOleDBCommand.Parameters.AddWithValue("dtipcam", MyAsientoVentaDetalle(MyFilaD).dtipcam)
                                MyOleDBCommand.Parameters.AddWithValue("dcantid", MyAsientoVentaDetalle(MyFilaD).dcantid)
                                MyOleDBCommand.Parameters.AddWithValue("drete", MyAsientoVentaDetalle(MyFilaD).drete)
                                MyOleDBCommand.Parameters.AddWithValue("dporre", MyAsientoVentaDetalle(MyFilaD).dporre)
                                MyOleDBCommand.Parameters.AddWithValue("dtipdor", MyAsientoVentaDetalle(MyFilaD).dtipdor)
                                MyOleDBCommand.Parameters.AddWithValue("dnumdor", MyAsientoVentaDetalle(MyFilaD).dnumdor)
                                MyOleDBCommand.Parameters.AddWithValue("dfecdo2", MyAsientoVentaDetalle(MyFilaD).dfecdo2)
                                MyOleDBCommand.Parameters.AddWithValue("dtiptas", MyAsientoVentaDetalle(MyFilaD).dtiptas)
                                MyOleDBCommand.Parameters.AddWithValue("dimptas", MyAsientoVentaDetalle(MyFilaD).dimptas)
                                MyOleDBCommand.Parameters.AddWithValue("dimpbmn", MyAsientoVentaDetalle(MyFilaD).dimpbmn)
                                MyOleDBCommand.Parameters.AddWithValue("dimpbus", MyAsientoVentaDetalle(MyFilaD).dimpbus)
                                MyOleDBCommand.Parameters.AddWithValue("dinacom", MyAsientoVentaDetalle(MyFilaD).dinacom)
                                MyOleDBCommand.Parameters.AddWithValue("digvcom", MyAsientoVentaDetalle(MyFilaD).digvcom)
                                MyOleDBCommand.Parameters.AddWithValue("dmedpag", MyAsientoVentaDetalle(MyFilaD).dmedpag)
                                MyOleDBCommand.Parameters.AddWithValue("dmoncom", MyAsientoVentaDetalle(MyFilaD).dmoncom)
                                MyOleDBCommand.Parameters.AddWithValue("dcolcom", MyAsientoVentaDetalle(MyFilaD).dcolcom)
                                MyOleDBCommand.Parameters.AddWithValue("dbascom", 1)
                                MyOleDBCommand.Parameters.AddWithValue("dtpconv", MyAsientoVentaDetalle(MyFilaD).dtpconv)
                                MyOleDBCommand.Parameters.AddWithValue("dflgcom", MyAsientoVentaDetalle(MyFilaD).dflgcom)
                                MyOleDBCommand.Parameters.AddWithValue("dtipaco", MyAsientoVentaDetalle(MyFilaD).dtipaco)
                                MyOleDBCommand.Parameters.AddWithValue("danecom", MyAsientoVentaDetalle(MyFilaD).danecom)
                                MyOleDBCommand.ExecuteNonQuery()
                            Next
                        End If
                    End If
                    MyProgressBar.Value += 1
                    MyProgressBar.Refresh()
                Next

                ' Commit the transaction.
                MyOleDBTransaction.Commit()

                MyProgressBar.Visible = False

                'Return True

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MyOleDBTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

        MySqlString = ""

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                For MyFilaC = 0 To MyAsientosVenta.Rows.Count - 1
                    If MyAsientosVenta(MyFilaC).cindica_exportacion = True Then
                        MySqlString = "UPDATE COM.VENTAS SET INDICA_EXPORTACION='SI' WHERE EMPRESA=@vEMPRESA AND VENTA=@vVENTA "
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString

                        MySQLCommand.Parameters.Clear()
                        MySQLCommand.Parameters.AddWithValue("vEMPRESA", MyAsientosVenta(MyFilaC).EMPRESA)
                        MySQLCommand.Parameters.AddWithValue("vVENTA", MyAsientosVenta(MyFilaC).VENTA)
                        MySQLCommand.ExecuteNonQuery()
                    End If
                Next

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

    Public Shared Function GrabarDomicilio(ByVal MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable) As Boolean
        If Not ExisteDomicilio(MyDomicilio) Then
            Call InsertarDomicilio(MyDomicilio)
        Else
            Call ActualizarDomicilio(MyDomicilio)
        End If
        Return ActualizarAnexoDomicilio(MyDomicilio)
    End Function

    Private Shared Function ExisteDomicilio(ByVal MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable) As Boolean
        MySqlString = "SELECT COUNT(*) FROM CON.ANEXOS_DOMICILIO WHERE avanexo=@vAvanexo AND acodane=@vAcodane"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vAvanexo", MyDomicilio(0).avanexo)
            MySQLCommand.Parameters.AddWithValue("vAcodane", MyDomicilio(0).acodane)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Sub InsertarDomicilio(ByVal MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable)
        MySQL = "INSERT INTO CON.ANEXOS_DOMICILIO " & _
                "(avanexo, acodane, adesane, arefane, arefane2, contacto_venta, contacto_compra) " & _
                "VALUES (@vAvanexo, @vAcodane, @vAdesane, @vArefane, @vArefane2, @vContacto_venta, @vContacto_compra) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAvanexo", MyDomicilio(0).avanexo)
                .AddWithValue("vAcodane", MyDomicilio(0).acodane)
                .AddWithValue("vAdesane", MyDomicilio(0).adesane)
                .AddWithValue("vArefane", MyDomicilio(0).arefane)
                .AddWithValue("vArefane2", MyDomicilio(0).arefane2)
                .AddWithValue("vContacto_venta", MyDomicilio(0).contacto_venta)
                .AddWithValue("vContacto_compra", MyDomicilio(0).contacto_compra)
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
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using

    End Sub

    Private Shared Sub ActualizarDomicilio(ByVal MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable)
        MySQL = "UPDATE CON.ANEXOS_DOMICILIO SET " & _
                "adesane=@vAdesane, arefane=@vArefane, arefane2=@vArefane2, contacto_venta=@vContacto_venta, contacto_compra=@vContacto_compra  " & _
                "WHERE avanexo=@vAvanexo AND acodane=@vAcodane "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAdesane", MyDomicilio(0).adesane)
                .AddWithValue("vArefane", MyDomicilio(0).arefane)
                .AddWithValue("vArefane2", MyDomicilio(0).arefane2)
                .AddWithValue("vContacto_venta", MyDomicilio(0).contacto_venta)
                .AddWithValue("vContacto_compra", MyDomicilio(0).contacto_compra)
                .AddWithValue("vAvanexo", MyDomicilio(0).avanexo)
                .AddWithValue("vAcodane", MyDomicilio(0).acodane)
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
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using

    End Sub

    Public Shared Function ActualizarAnexoDomicilio(ByVal MyDomicilio As dsCONCAR_Anexos.ANEXOS_DOMICILIODataTable) As Boolean
        MyOleDBString = "UPDATE can03 SET arefane=?  WHERE avanexo=? AND acodane=? "

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)

            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyOleDBCommand.Parameters.AddWithValue("arefane", MyDomicilio(0).arefane)
                MyOleDBCommand.Parameters.AddWithValue("avanexo", MyDomicilio(0).avanexo)
                MyOleDBCommand.Parameters.AddWithValue("acodane", MyDomicilio(0).acodane)

                MyOleDBCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MyOleDBTransaction.Commit()

                Return True

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MyOleDBTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

        Return True

    End Function

    Private Shared Sub ValorizarDocumento(ByVal PrecioUnitarioME As Decimal)
        MyImporteSubTotalOrigen = Math.Round(MyCantidad * PrecioUnitarioME, 2)
        MyBaseImponibleGravadaOrigen = Math.Round(MyImporteSubTotalOrigen / 1.18, 2)
        MyIGVOrigen = MyImporteSubTotalOrigen - MyBaseImponibleGravadaOrigen

        If MyTipoMoneda = "1" Then ' MN
            MyBaseImponibleGravadaMN = MyBaseImponibleGravadaOrigen
            MyImporteSubTotalMN = MyImporteSubTotalOrigen
            MyIGVMN = MyImporteSubTotalMN - MyBaseImponibleGravadaMN

            MyBaseImponibleGravadaME = Math.Round(MyBaseImponibleGravadaOrigen / MyTipoCambio, 2)
            MyImporteSubTotalME = Math.Round(MyImporteSubTotalOrigen / MyTipoCambio, 2)
            MyIGVME = MyImporteSubTotalME - MyBaseImponibleGravadaME
        Else
            MyBaseImponibleGravadaME = MyBaseImponibleGravadaOrigen
            MyImporteSubTotalME = MyImporteSubTotalOrigen
            MyIGVME = MyImporteSubTotalME - MyBaseImponibleGravadaME

            MyBaseImponibleGravadaMN = Math.Round(MyBaseImponibleGravadaOrigen * MyTipoCambio, 2)
            MyImporteSubTotalMN = Math.Round(MyImporteSubTotalOrigen * MyTipoCambio, 2)
            MyIGVMN = MyImporteSubTotalMN - MyBaseImponibleGravadaMN
        End If
    End Sub

    Private Shared Sub InsertarVentaDetalle(ByVal MyOrdenPedido As entOrdenPedido, ByVal MyDetallesPedido As dsOrdenPedido.DETALLES_PEDIDODataTable)
        MySQL = "INSERT INTO COM.VENTAS_PRO " & _
                "(empresa,venta,linea,tipo_cambio,tipo_moneda,producto,numero_lote,cantidad," & _
                "precio_unitario,base_imponible_gravada_origen,igv_origen,importe_total_origen," & _
                "base_imponible_gravada_mn,igv_mn,importe_total_mn," & _
                "base_imponible_gravada_me,igv_me,importe_total_me,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vTipo_cambio,@vTipo_moneda,@vProducto,@vNumero_lote,@vCantidad," & _
                "@vPrecio_unitario,@vBase_imponible_gravada_origen,@vIgv_origen,@vImporte_total_origen," & _
                "@vBase_imponible_gravada_mn,@vIgv_mn,@vImporte_total_mn," & _
                "@vBase_imponible_gravada_me,@vIgv_me,@vImporte_total_me,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyOrdenPedido.empresa)
                    .AddWithValue("vVenta", MyOrdenPedido.venta)
                    .AddWithValue("vLinea", MyNumeroLinea)
                    .AddWithValue("vTipo_cambio", MyOrdenPedido.tipo_cambio)
                    .AddWithValue("vTipo_moneda", MyOrdenPedido.pago_moneda)
                    .AddWithValue("vProducto", MyDetallesPedido(NumReg1).PRODUCTO)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vCantidad", MyCantidad)
                    .AddWithValue("vPrecio_unitario", MyDetallesPedido(NumReg1).PRECIO_UNITARIO_ME)
                    .AddWithValue("vBase_imponible_gravada_origen", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_origen", MyIGVOrigen)
                    .AddWithValue("vImporte_total_origen", MyImporteSubTotalOrigen)
                    .AddWithValue("vBase_imponible_gravada_mn", MyBaseImponibleGravadaMN)
                    .AddWithValue("vIgv_mn", MyIGVMN)
                    .AddWithValue("vImporte_total_mn", MyImporteSubTotalMN)
                    .AddWithValue("vBase_imponible_gravada_me", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_me", MyIGVOrigen)
                    .AddWithValue("vImporte_total_me", MyImporteSubTotalOrigen)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using

        Call ActualizarOrdenPedido(MyOrdenPedido, MyDetallesPedido(NumReg1).PRODUCTO)
    End Sub

    Private Shared Sub InsertarVentaDetalle(ByVal MyVentaDetalle As entVentaProducto)
        MySQL = "INSERT INTO COM.VENTAS_PRO " & _
                "(empresa,venta,linea,tipo_cambio,tipo_moneda,producto,numero_lote,cantidad," & _
                "precio_unitario,base_imponible_gravada_origen,igv_origen,importe_total_origen," & _
                "base_imponible_gravada_mn,igv_mn,importe_total_mn," & _
                "base_imponible_gravada_me,igv_me,importe_total_me,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vTipo_cambio,@vTipo_moneda,@vProducto,@vNumero_lote,@vCantidad," & _
                "@vPrecio_unitario,@vBase_imponible_gravada_origen,@vIgv_origen,@vImporte_total_origen," & _
                "@vBase_imponible_gravada_mn,@vIgv_mn,@vImporte_total_mn," & _
                "@vBase_imponible_gravada_me,@vIgv_me,@vImporte_total_me,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyVentaDetalle.empresa)
                    .AddWithValue("vVenta", MyVentaDetalle.venta)
                    .AddWithValue("vLinea", MyNumeroLinea)
                    .AddWithValue("vTipo_cambio", MyVentaDetalle.tipo_cambio)
                    .AddWithValue("vTipo_moneda", MyVentaDetalle.tipo_moneda)
                    .AddWithValue("vProducto", MyVentaDetalle.producto)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vCantidad", MyCantidad)
                    .AddWithValue("vPrecio_unitario", MyVentaDetalle.precio_unitario)
                    .AddWithValue("vBase_imponible_gravada_origen", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_origen", MyIGVOrigen)
                    .AddWithValue("vImporte_total_origen", MyImporteSubTotalOrigen)
                    .AddWithValue("vBase_imponible_gravada_mn", MyBaseImponibleGravadaMN)
                    .AddWithValue("vIgv_mn", MyIGVMN)
                    .AddWithValue("vImporte_total_mn", MyImporteSubTotalMN)
                    .AddWithValue("vBase_imponible_gravada_me", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_me", MyIGVOrigen)
                    .AddWithValue("vImporte_total_me", MyImporteSubTotalOrigen)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub InsertarVentaDetalleCompuesto(ByVal MyOrdenPedido As entOrdenPedido, ByVal MyStockCompuesto As dsStockAlmacen.STOCK_X_COMPUESTODataTable)
        MySQL = "INSERT INTO COM.VENTAS_COM (empresa,venta,linea,producto,numero_lote,cantidad,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vProducto,@vNumero_lote,@vCantidad,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyOrdenPedido.empresa)
                    .AddWithValue("vVenta", MyOrdenPedido.venta)
                    .AddWithValue("vLinea", MyNumeroLinea)
                    .AddWithValue("vProducto", MyStockCompuesto(NumReg3).PRODUCTO)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vCantidad", MyCantidad)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub InsertarVentaDetalleCompuesto(ByVal MyVentaDetalle As entVentaProducto, ByVal MyStockCompuesto As dsStockAlmacen.STOCK_X_COMPUESTODataTable)
        MySQL = "INSERT INTO COM.VENTAS_COM (empresa,venta,linea,producto,numero_lote,cantidad,usuario_registro) " & _
                "VALUES (@vEmpresa,@vVenta,@vLinea,@vProducto,@vNumero_lote,@vCantidad,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyVentaDetalle.empresa)
                    .AddWithValue("vVenta", MyVentaDetalle.venta)
                    .AddWithValue("vLinea", MyNumeroLinea)
                    .AddWithValue("vProducto", MyStockCompuesto(NumReg3).PRODUCTO)
                    .AddWithValue("vNumero_lote", MyNumeroLote)
                    .AddWithValue("vCantidad", MyCantidad)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub ActualizarOrdenPedido(ByVal MyOrdenPedido As entOrdenPedido, ByVal MyProducto As String)
        MySQL = "UPDATE COM.ORDEN_PEDIDO_DET SET " & _
                "venta=@vVenta,venta_linea=@vVenta_linea,venta_cantidad=venta_cantidad+@vCantidad," & _
                "usuario_modifica=@vUsuario_modifica,fecha_modifica=@vfecha_modifica " & _
                "WHERE empresa=@vEmpresa AND orden_pedido=@vOrden_pedido AND producto=@vProducto "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vVenta", MyOrdenPedido.venta)
                    .AddWithValue("vVenta_linea", MyNumeroLinea)
                    .AddWithValue("vCantidad", MyCantidad)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyOrdenPedido.empresa)
                    .AddWithValue("vOrden_pedido", MyOrdenPedido.orden_pedido)
                    .AddWithValue("vProducto", MyProducto)
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

    Public Shared Function EvaluarPedidoAtendido(ByVal pOrdenPedido) As Integer
        Dim MyCantidadControl As Integer = 0
        MySQL = "SELECT SUM(VENTA_CANTIDAD) AS CANTIDAD_CONTROL FROM COM.ORDEN_PEDIDO_DET " & _
                "WHERE EMPRESA= '" & MyUsuario.empresa & "' AND ORDEN_PEDIDO= '" & pOrdenPedido & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyCantidadControl = MySQLCommand.ExecuteScalar
        End Using
        Return MyCantidadControl
    End Function

    Public Shared Function VentasPorConsultar(ByVal pEjercicio As String, ByVal pMes As String, ByVal pConsultor As String, ByVal pCriterio1 As String, ByVal pCriterio2 As String, ByVal pCriterio3 As String) As dsVentas.VENTAS_LISTADataTable
        Dim nCriterio1 As String = Nothing
        Dim nCriterio2 As String = Nothing
        Dim nCriterio3 As String = Nothing

        Select Case pCriterio1
            Case Is = "PERIODO"
                nCriterio1 = Space(1)
            Case Is = "CONSULTOR"
                If pConsultor.Trim.Length <> 0 Then
                    nCriterio1 = "AND C.CODIGO_VENDEDOR=@vCodigo_vendedor "
                Else
                    nCriterio1 = Space(1)
                End If
        End Select

        Select Case pCriterio2
            Case Is = "ANULADAS"
                nCriterio2 = "AND C.ESTADO='N' "
            Case Is = "NO ANULADAS"
                nCriterio2 = "AND C.ESTADO<>'N' "
            Case Else
                nCriterio2 = Space(1)
        End Select

        Select Case pCriterio3
            Case Is = "BOLETA DE VENTA"
                nCriterio3 = "AND C.COMPROBANTE_TIPO='03' "
            Case Is = "FACTURA"
                nCriterio3 = "AND C.COMPROBANTE_TIPO='01' "
            Case Else
                nCriterio3 = "AND TIPO_VENTA='" & pCriterio3 & "' "
        End Select

        MySQL = "SELECT C.VENTA,C.COMPROBANTE_FECHA,C.COMPROBANTE_SERIE,C.COMPROBANTE_NUMERO,CC.RAZON_SOCIAL," & _
                "C.CODIGO_VENDEDOR AS VENDEDOR,ISNULL(V.DESCRIPCION,SPACE(1)) AS VENDEDOR_NOMBRE,M.TEXTO_01 AS MONEDA," & _
                "C.BASE_IMPONIBLE_GRAVADA_ORIGEN,C.IGV_ORIGEN,C.IMPORTE_TOTAL_ORIGEN,C.ESTADO " & _
                "FROM COM.VENTAS AS C INNER JOIN " & _
                "COM.CUENTAS_COMERCIALES AS CC ON C.CUENTA_COMERCIAL = CC.CUENTA_COMERCIAL LEFT OUTER JOIN " & _
                "GEN.TABLA_VENDEDORES AS V ON C.CODIGO_VENDEDOR = V.CODIGO INNER JOIN " & _
                "GEN.TABLAS_DETALLE AS M ON C.EMPRESA = M.EMPRESA AND C.TIPO_MONEDA = M.CODIGO_ITEM AND M.CODIGO_TABLA = '_TIPO_MONEDA' " & _
                "WHERE C.EMPRESA=@vEmpresa AND C.EJERCICIO=@vEjercicio AND C.MES=@vMes " & _
                nCriterio1 & nCriterio2 & nCriterio3 & _
                "ORDER BY C.VENTA DESC"

        Dim MyDT As New dsVentas.VENTAS_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
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

    Public Shared Function ObtenerDetalles(ByVal pVenta As String) As dsVentas.VENTAS_DETALLEDataTable
        MySQL = "SELECT  V.EMPRESA, V.VENTA, V.LINEA, V.PRODUCTO, P.DESCRIPCION_AMPLIADA, V.CANTIDAD, " & _
                "V.PRECIO_UNITARIO AS PRECIO_UNITARIO_ME, V.IMPORTE_TOTAL_ME, V.NUMERO_LOTE, P.INDICA_COMPUESTO, P.INDICA_VALIDA_STOCK " & _
                "FROM COM.VENTAS_PRO AS V INNER JOIN COM.PRODUCTOS AS P ON V.EMPRESA = P.EMPRESA AND V.PRODUCTO = P.PRODUCTO " & _
                "WHERE V.EMPRESA = @vEmpresa AND V.VENTA = @vVenta " & _
                "ORDER BY V.LINEA "

        Dim MyDT As New dsVentas.VENTAS_DETALLEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQL
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

#Region "Cabecera"

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

    Private Shared Function Existe(ByVal cVenta As entVenta, ByVal EsNuevo As Boolean) As entVenta
        With cVenta
            If EsNuevo = True Then
                CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND " & _
                            "CUENTA_COMERCIAL='" & .cuenta_comercial & "' AND COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "'"
            Else
                CadenaSQL = "SELECT * FROM COM.VENTAS WHERE EMPRESA='" & .empresa & "' AND " & _
                            "CUENTA_COMERCIAL='" & .cuenta_comercial & "' AND COMPROBANTE_TIPO='" & .comprobante_tipo & "' AND " & _
                            "COMPROBANTE_SERIE='" & .comprobante_serie & "' AND COMPROBANTE_NUMERO='" & .comprobante_numero & "' AND " & _
                            "VENTA<>'" & .venta & "'"
            End If
        End With
        Return Obtener(New entVenta, CadenaSQL)
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

    Public Shared Function Grabar(ByVal cVenta As entVenta) As entVenta
        With cVenta
            If String.IsNullOrEmpty(.cuenta_comercial) Then Throw New BusinessException(MSG000 & " DOCUMENTO IDENTIDAD")
            If String.IsNullOrEmpty(.comprobante_serie.Trim) Then Throw New BusinessException(MSG000 & " SERIE")
            If String.IsNullOrEmpty(.comprobante_numero.Trim) Then Throw New BusinessException(MSG000 & " NUMERO")
            If Year(.comprobante_fecha) * 100 + Month(.comprobante_fecha) = 190001 Then Throw New BusinessException(MSG000 & " FECHA EMISION")
            If Year(.comprobante_vencimiento) * 100 + Month(.comprobante_vencimiento) = 190001 Then Throw New BusinessException(MSG000 & " FECHA VENCIMIENTO")
            If .tipo_cambio = 0 Then Throw New BusinessException(MSG000 & " TIPO DE CAMBIO")
        End With
        Call BuscarComprobanteDuplicado(cVenta)
        If Not Existe(cVenta.venta) Then
            Return Insertar(cVenta)
        Else
            Return Actualizar(cVenta)
        End If
    End Function

    Private Shared Function Insertar(ByVal cVenta As entVenta) As entVenta
        With cVenta
            .venta = AsignarVenta()
            .asiento_numero = AsignarNumeroAsiento(.ejercicio, .mes, "05")
        End With
        MySQL = "INSERT INTO COM.VENTAS " & _
                "(empresa,venta,ejercicio,mes,asiento_tipo,asiento_numero,asiento_fecha,cuenta_comercial,comprobante_tipo,comprobante_serie," & _
                "comprobante_numero,comprobante_fecha,comprobante_vencimiento,tipo_cambio,tipo_moneda,almacen,codigo_domicilio," & _
                "valor_exportacion_origen,base_imponible_gravada_origen,importe_exonerado_origen,importe_inafecto_origen,isc_origen,igv_origen,ipm_origen," & _
                "base_imponible_gravada2_origen,igv2_origen,otros_tributos_origen,importe_total_origen," & _
                "valor_exportacion_mn,base_imponible_gravada_mn,importe_exonerado_mn,importe_inafecto_mn,isc_mn,igv_mn,ipm_mn," & _
                "base_imponible_gravada2_mn,igv2_mn,otros_tributos_mn,importe_total_mn," & _
                "valor_exportacion_me,base_imponible_gravada_me,importe_exonerado_me,importe_inafecto_me,isc_me,igv_me,ipm_me," & _
                "base_imponible_gravada2_me,igv2_me,otros_tributos_me,importe_total_me," & _
                "referencia_cuo,condicion_pago,fecha_ultimo_pago,importe_saldo,comentario,tipo_venta,zona_comercial,codigo_vendedor," & _
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
                "@vReferencia_cuo,@vCondicion_pago,@vFecha_ultimo_pago,@vImporte_saldo,@vComentario,@vTipo_venta,@vZona_comercial,@vCodigo_vendedor," & _
                "@vCodigo_cobrador,@vCentro_costo,@vLetra,@vFactoring,@vPlanilla_cobranza,@vGuia_remitente,@vGuia_transportista,@vOrden_pedido," & _
                "@vUsuario_envio,@vFecha_envio,@vFecha_recepcion,@vUbicacion_custodia,@vUsuario_custodia,@vFecha_custodia," & _
                "@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero,@vReferencia_fecha,@vIndica_exportacion," & _
                "@vOrigen,@vEstado,@vUsuario_registro,@vLista_precio,@vCentro_distribucion) "
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
                .AddWithValue("vTipo_cambio", cVenta.tipo_cambio)
                .AddWithValue("vTipo_moneda", cVenta.tipo_moneda)
                .AddWithValue("vAlmacen", cVenta.almacen)
                .AddWithValue("vCodigo_domicilio", cVenta.codigo_domicilio)
                .AddWithValue("vValor_exportacion_origen", cVenta.valor_exportacion_origen)
                .AddWithValue("vBase_imponible_gravada_origen", cVenta.base_imponible_gravada_origen)
                .AddWithValue("vimporte_exonerado_origen", cVenta.importe_exonerado_origen)
                .AddWithValue("vimporte_inafecto_origen", cVenta.importe_inafecto_origen)
                .AddWithValue("vIsc_origen", cVenta.isc_origen)
                .AddWithValue("vIgv_origen", cVenta.igv_origen)
                .AddWithValue("vIpm_origen", cVenta.ipm_origen)
                .AddWithValue("vBase_imponible_gravada2_origen", cVenta.base_imponible_gravada2_origen)
                .AddWithValue("vIgv2_origen", cVenta.igv2_origen)
                .AddWithValue("vOtros_tributos_origen", cVenta.otros_tributos_origen)
                .AddWithValue("vImporte_total_origen", cVenta.importe_total_origen)
                .AddWithValue("vValor_exportacion_mn", cVenta.valor_exportacion_mn)
                .AddWithValue("vBase_imponible_gravada_mn", cVenta.base_imponible_gravada_mn)
                .AddWithValue("vimporte_exonerado_mn", cVenta.importe_exonerado_mn)
                .AddWithValue("vimporte_inafecto_mn", cVenta.importe_inafecto_mn)
                .AddWithValue("vIsc_mn", cVenta.isc_mn)
                .AddWithValue("vIgv_mn", cVenta.igv_mn)
                .AddWithValue("vIpm_mn", cVenta.ipm_mn)
                .AddWithValue("vBase_imponible_gravada2_mn", cVenta.base_imponible_gravada2_mn)
                .AddWithValue("vIgv2_mn", cVenta.igv2_mn)
                .AddWithValue("vOtros_tributos_mn", cVenta.otros_tributos_mn)
                .AddWithValue("vImporte_total_mn", cVenta.importe_total_mn)
                .AddWithValue("vValor_exportacion_me", cVenta.valor_exportacion_me)
                .AddWithValue("vBase_imponible_gravada_me", cVenta.base_imponible_gravada_me)
                .AddWithValue("vimporte_exonerado_me", cVenta.importe_exonerado_me)
                .AddWithValue("vimporte_inafecto_me", cVenta.importe_inafecto_me)
                .AddWithValue("vIsc_me", cVenta.isc_me)
                .AddWithValue("vIgv_me", cVenta.igv_me)
                .AddWithValue("vIpm_me", cVenta.ipm_me)
                .AddWithValue("vBase_imponible_gravada2_me", cVenta.base_imponible_gravada2_me)
                .AddWithValue("vIgv2_me", cVenta.igv2_me)
                .AddWithValue("vOtros_tributos_me", cVenta.otros_tributos_me)
                .AddWithValue("vImporte_total_me", cVenta.importe_total_me)
                .AddWithValue("vReferencia_cuo", cVenta.referencia_cuo)
                .AddWithValue("vCondicion_pago", cVenta.condicion_pago)
                .AddWithValue("vFecha_ultimo_pago", cVenta.fecha_ultimo_pago)
                .AddWithValue("vImporte_saldo", cVenta.importe_saldo)
                .AddWithValue("vComentario", cVenta.comentario)
                .AddWithValue("vTipo_venta", cVenta.tipo_venta)
                .AddWithValue("vZona_comercial", cVenta.zona_comercial)
                .AddWithValue("vCodigo_vendedor", cVenta.codigo_vendedor)
                .AddWithValue("vCodigo_cobrador", cVenta.codigo_cobrador)
                .AddWithValue("vCentro_costo", cVenta.centro_costo)
                .AddWithValue("vLetra", cVenta.letra)
                .AddWithValue("vFactoring", cVenta.factoring)
                .AddWithValue("vPlanilla_cobranza", cVenta.planilla_cobranza)
                .AddWithValue("vGuia_remitente", cVenta.guia_remitente)
                .AddWithValue("vGuia_transportista", cVenta.guia_transportista)
                .AddWithValue("vOrden_pedido", cVenta.orden_pedido)
                .AddWithValue("vUsuario_envio", cVenta.usuario_envio)
                .AddWithValue("vFecha_envio", cVenta.fecha_envio)
                .AddWithValue("vFecha_recepcion", cVenta.fecha_recepcion)
                .AddWithValue("vUbicacion_custodia", cVenta.ubicacion_custodia)
                .AddWithValue("vUsuario_custodia", cVenta.usuario_custodia)
                .AddWithValue("vFecha_custodia", cVenta.fecha_custodia)
                .AddWithValue("vReferencia_tipo", cVenta.referencia_tipo)
                .AddWithValue("vReferencia_serie", cVenta.referencia_serie)
                .AddWithValue("vReferencia_numero", cVenta.referencia_numero)
                .AddWithValue("vReferencia_fecha", cVenta.referencia_fecha)
                .AddWithValue("vIndica_exportacion", cVenta.indica_exportacion)
                .AddWithValue("vOrigen", cVenta.origen)
                .AddWithValue("vEstado", cVenta.estado)
                .AddWithValue("vUsuario_registro", cVenta.usuario_registro)
                .AddWithValue("vLista_precio", cVenta.lista_precio)
                .AddWithValue("vCentro_distribucion", cVenta.centro_distribucion)
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

    Private Shared Function Actualizar(ByVal cVenta As entVenta) As entVenta

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
                        "Comprobante_vencimiento=@vComprobante_vencimiento,Tipo_cambio=@vTipo_cambio,Tipo_moneda=@vTipo_moneda," & _
                        "valor_exportacion_origen=@vValor_exportacion_origen,base_imponible_gravada_origen=@vBase_imponible_gravada_origen,importe_exonerado_origen=@vimporte_exonerado_origen," & _
                        "importe_inafecto_origen=@vimporte_inafecto_origen,isc_origen=@vIsc_origen,igv_origen=@vIgv_origen,ipm_origen=@vIpm_origen," & _
                        "base_imponible_gravada2_origen=@vBase_imponible_gravada2_origen,igv2_origen=@vIgv2_origen,otros_tributos_origen=@vOtros_tributos_origen,importe_total_origen=@vImporte_total_origen," & _
                        "valor_exportacion_mn=@vValor_exportacion_mn,base_imponible_gravada_mn=@vBase_imponible_gravada_mn,importe_exonerado_mn=@vimporte_exonerado_mn," & _
                        "importe_inafecto_mn=@vimporte_inafecto_mn,isc_mn=@vIsc_mn,igv_mn=@vIgv_mn,ipm_mn=@vIpm_mn," & _
                        "base_imponible_gravada2_mn=@vBase_imponible_gravada2_mn,igv2_mn=@vIgv2_mn,otros_tributos_mn=@vOtros_tributos_mn,importe_total_mn=@vImporte_total_mn," & _
                        "valor_exportacion_me=@vValor_exportacion_me,base_imponible_gravada_me=@vBase_imponible_gravada_me,importe_exonerado_me=@vimporte_exonerado_me," & _
                        "importe_inafecto_me=@vimporte_inafecto_me,isc_me=@vIsc_me,igv_me=@vIgv_me,ipm_me=@vIpm_me," & _
                        "base_imponible_gravada2_me=@vBase_imponible_gravada2_me,igv2_me=@vIgv2_me,otros_tributos_me=@vOtros_tributos_me,importe_total_me=@vImporte_total_me," & _
                        "referencia_cuo=@vReferencia_cuo,condicion_pago=@vCondicion_pago,fecha_ultimo_pago=@vFecha_ultimo_pago,importe_saldo=@vImporte_saldo,comentario=@vComentario," & _
                        "tipo_venta=@vTipo_venta,zona_comercial=@vZona_comercial,codigo_vendedor=@vCodigo_vendedor,codigo_cobrador=@vCodigo_cobrador,centro_costo=@vCentro_costo,letra=@vLetra,factoring=@vFactoring," & _
                        "planilla_cobranza=@vPlanilla_cobranza,guia_remitente=@vGuia_remitente,guia_transportista=@vGuia_transportista,Orden_pedido=@vOrden_pedido,usuario_envio=@vUsuario_envio,fecha_envio=@vFecha_envio," & _
                        "fecha_recepcion=@vFecha_recepcion,ubicacion_custodia=@vUbicacion_custodia,usuario_custodia=@vUsuario_custodia,fecha_custodia=@vFecha_custodia," & _
                        "indica_sujeta_detraccion=@vIndica_sujeta_detraccion,porcentaje_detraccion=@vPorcentaje_detraccion,fecha_detraccion=@vFecha_detraccion,numero_detraccion=@vNumero_detraccion," & _
                        "referencia_tipo=@vReferencia_tipo,referencia_serie=@vReferencia_serie,referencia_numero=@vReferencia_numero,referencia_fecha=@vReferencia_fecha,indica_exportacion=@vIndica_exportacion," & _
                        "origen=@vOrigen,estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica,lista_precio=@vLista_precio,centro_distribucion=@vCentro_distribucion,asiento_fecha=@vAsiento_fecha  " & _
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
                    .AddWithValue("vValor_exportacion_origen", cVenta.valor_exportacion_origen)
                    .AddWithValue("vBase_imponible_gravada_origen", cVenta.base_imponible_gravada_origen)
                    .AddWithValue("vimporte_exonerado_origen", cVenta.importe_exonerado_origen)
                    .AddWithValue("vimporte_inafecto_origen", cVenta.importe_inafecto_origen)
                    .AddWithValue("vIsc_origen", cVenta.isc_origen)
                    .AddWithValue("vIgv_origen", cVenta.igv_origen)
                    .AddWithValue("vIpm_origen", cVenta.ipm_origen)
                    .AddWithValue("vBase_imponible_gravada2_origen", cVenta.base_imponible_gravada2_origen)
                    .AddWithValue("vIgv2_origen", cVenta.igv2_origen)
                    .AddWithValue("vOtros_tributos_origen", cVenta.otros_tributos_origen)
                    .AddWithValue("vImporte_total_origen", cVenta.importe_total_origen)
                    .AddWithValue("vValor_exportacion_mn", cVenta.valor_exportacion_mn)
                    .AddWithValue("vBase_imponible_gravada_mn", cVenta.base_imponible_gravada_mn)
                    .AddWithValue("vimporte_exonerado_mn", cVenta.importe_exonerado_mn)
                    .AddWithValue("vimporte_inafecto_mn", cVenta.importe_inafecto_mn)
                    .AddWithValue("vIsc_mn", cVenta.isc_mn)
                    .AddWithValue("vIgv_mn", cVenta.igv_mn)
                    .AddWithValue("vIpm_mn", cVenta.ipm_mn)
                    .AddWithValue("vBase_imponible_gravada2_mn", cVenta.base_imponible_gravada2_mn)
                    .AddWithValue("vIgv2_mn", cVenta.igv2_mn)
                    .AddWithValue("vOtros_tributos_mn", cVenta.otros_tributos_mn)
                    .AddWithValue("vImporte_total_mn", cVenta.importe_total_mn)
                    .AddWithValue("vValor_exportacion_me", cVenta.valor_exportacion_me)
                    .AddWithValue("vBase_imponible_gravada_me", cVenta.base_imponible_gravada_me)
                    .AddWithValue("vimporte_exonerado_me", cVenta.importe_exonerado_me)
                    .AddWithValue("vimporte_inafecto_me", cVenta.importe_inafecto_me)
                    .AddWithValue("vIsc_me", cVenta.isc_me)
                    .AddWithValue("vIgv_me", cVenta.igv_me)
                    .AddWithValue("vIpm_me", cVenta.ipm_me)
                    .AddWithValue("vBase_imponible_gravada2_me", cVenta.base_imponible_gravada2_me)
                    .AddWithValue("vIgv2_me", cVenta.igv2_me)
                    .AddWithValue("vOtros_tributos_me", cVenta.otros_tributos_me)
                    .AddWithValue("vImporte_total_me", cVenta.importe_total_me)
                    .AddWithValue("vReferencia_cuo", cVenta.referencia_cuo)
                    .AddWithValue("vCondicion_pago", cVenta.condicion_pago)
                    .AddWithValue("vFecha_ultimo_pago", cVenta.fecha_ultimo_pago)
                    .AddWithValue("vImporte_saldo", cVenta.importe_saldo)
                    .AddWithValue("vComentario", cVenta.comentario)
                    .AddWithValue("vTipo_venta", cVenta.tipo_venta)
                    .AddWithValue("vZona_comercial", cVenta.zona_comercial)
                    .AddWithValue("vCodigo_vendedor", cVenta.codigo_vendedor)
                    .AddWithValue("vCodigo_cobrador", cVenta.codigo_cobrador)
                    .AddWithValue("vCentro_costo", cVenta.centro_costo)
                    .AddWithValue("vLetra", cVenta.letra)
                    .AddWithValue("vFactoring", cVenta.factoring)
                    .AddWithValue("vPlanilla_cobranza", cVenta.planilla_cobranza)
                    .AddWithValue("vGuia_remitente", cVenta.guia_remitente)
                    .AddWithValue("vGuia_transportista", cVenta.guia_transportista)
                    .AddWithValue("vOrden_pedido", cVenta.orden_pedido)
                    .AddWithValue("vUsuario_envio", cVenta.usuario_envio)
                    .AddWithValue("vFecha_envio", cVenta.fecha_envio)
                    .AddWithValue("vFecha_recepcion", cVenta.fecha_recepcion)
                    .AddWithValue("vUbicacion_custodia", cVenta.ubicacion_custodia)
                    .AddWithValue("vUsuario_custodia", cVenta.usuario_custodia)
                    .AddWithValue("vFecha_custodia", cVenta.fecha_custodia)
                    .AddWithValue("vIndica_sujeta_detraccion", cVenta.indica_sujeta_detraccion)
                    .AddWithValue("vPorcentaje_detraccion", cVenta.porcentaje_detraccion)
                    .AddWithValue("vFecha_detraccion", cVenta.fecha_detraccion)
                    .AddWithValue("vNumero_detraccion", cVenta.numero_detraccion)
                    .AddWithValue("vReferencia_tipo", cVenta.referencia_tipo)
                    .AddWithValue("vReferencia_serie", cVenta.referencia_serie)
                    .AddWithValue("vReferencia_numero", cVenta.referencia_numero)
                    .AddWithValue("vReferencia_fecha", cVenta.referencia_fecha)
                    .AddWithValue("vIndica_exportacion", cVenta.indica_exportacion)
                    .AddWithValue("vOrigen", cVenta.origen)
                    .AddWithValue("vEstado", cVenta.estado)
                    .AddWithValue("vUsuario_modifica", cVenta.usuario_registro)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vLista_precio", cVenta.lista_precio)
                    .AddWithValue("vCentro_distribucion", cVenta.centro_distribucion)
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

    Public Shared Function FacturarPedido(ByVal MyOrdenPedido As entOrdenPedido, ByVal MyDetallesPedido As dsOrdenPedido.DETALLES_PEDIDODataTable, ByRef gvVentaLineas As DataGridView, ByRef MyVenta As String, ByRef MyCantidadControl As Integer) As Decimal
        Dim MyProducto As String = ""
        Dim MyCantidadPendienteDespachar As Decimal = 0
        Dim MyStock As dsStockAlmacen.STOCK_X_PRODUCTODataTable
        Dim MyStockCompuesto As dsStockAlmacen.STOCK_X_COMPUESTODataTable
        Dim MyFactor As Integer = 0

        MyImporteTotalOrigen = 0
        MyVentaLinea = 0

        With MyOrdenPedido
            MyVenta = AsignarVenta()
            MyTipoCambio = .tipo_cambio
            MyTipoMoneda = .pago_moneda
            MyAlmacen = .almacen_venta
            .venta = MyVenta
            .asiento_numero = AsignarNumeroAsiento(.ejercicio_venta, .mes_venta, "05")
        End With

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                Call InsertarVentaCabecera(MyOrdenPedido)

                For NumReg1 = 0 To MyDetallesPedido.Rows.Count - 1
                    MyImporteSubTotalOrigen = 0
                    MyProducto = MyDetallesPedido(NumReg1).PRODUCTO
                    MyCantidadPendienteDespachar = MyDetallesPedido(NumReg1).CANTIDAD
                    If MyDetallesPedido(NumReg1).INDICA_VALIDA_STOCK = "NO" Then
                        MyVentaLinea = MyVentaLinea + 1
                        MyNumeroLote = "0000000000"
                        MyNumeroLinea = Strings.Right("000" & MyVentaLinea.ToString, 3)
                        MyCantidad = MyCantidadPendienteDespachar
                        With MyDetallesPedido(NumReg1)
                            Call ValorizarDocumento(.PRECIO_UNITARIO_ME)
                            MyCantidadControl = MyCantidadControl + MyCantidad
                            gvVentaLineas.Rows.Add(.EMPRESA, MyVenta, MyNumeroLinea, .PRODUCTO, .DESCRIPCION_AMPLIADA, MyCantidad, .PRECIO_UNITARIO_ME, MyImporteSubTotalOrigen, MyNumeroLote, "NO", "NO")
                            Call InsertarVentaDetalle(MyOrdenPedido, MyDetallesPedido)
                        End With
                    Else
                        If MyDetallesPedido(NumReg1).INDICA_COMPUESTO = "NO" Then
                            MyStock = dalOperacionAlmacen.BuscarStock(MyOrdenPedido.almacen_venta, MyProducto)
                            If MyStock.Rows.Count <> 0 Then
                                For NumReg2 = 0 To MyStock.Rows.Count - 1
                                    MyVentaLinea = MyVentaLinea + 1
                                    MyNumeroLote = MyStock(NumReg2).NUMERO_LOTE.Trim
                                    MyNumeroLinea = Strings.Right("000" & MyVentaLinea.ToString, 3)
                                    If MyStock(NumReg2).STOCK >= MyCantidadPendienteDespachar Then
                                        MyCantidad = MyCantidadPendienteDespachar
                                        MyCantidadPendienteDespachar = 0
                                    Else
                                        MyCantidad = MyStock(NumReg2).STOCK
                                        MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStock(NumReg2).STOCK
                                    End If
                                    With MyDetallesPedido(NumReg1)
                                        Call ValorizarDocumento(.PRECIO_UNITARIO_ME)
                                        MyCantidadControl = MyCantidadControl + MyCantidad
                                        gvVentaLineas.Rows.Add(.EMPRESA, MyVenta, MyNumeroLinea, .PRODUCTO, .DESCRIPCION_AMPLIADA, MyCantidad, .PRECIO_UNITARIO_ME, MyImporteSubTotalOrigen, MyNumeroLote, "NO", "SI")
                                        Call InsertarVentaDetalle(MyOrdenPedido, MyDetallesPedido)
                                        Call ActualizarStockResumen(MyDetallesPedido(NumReg1).PRODUCTO)
                                        Call ActualizarStockPeriodo(MyOrdenPedido.ejercicio_venta, MyOrdenPedido.mes_venta, MyDetallesPedido(NumReg1).PRODUCTO)
                                    End With
                                    If MyCantidadPendienteDespachar = 0 Then Exit For
                                Next
                            Else
                                With MyDetallesPedido(NumReg1)
                                    gvVentaLineas.Rows.Add(.EMPRESA, Space(1), Space(1), .PRODUCTO, .DESCRIPCION_AMPLIADA, 0, .PRECIO_UNITARIO_ME, 0, Space(1), "NO", "SI")
                                End With
                            End If
                        Else
                            MyStockCompuesto = dalOperacionAlmacen.BuscarStockCompuesto(MyOrdenPedido.almacen_venta, MyProducto)
                            If MyStockCompuesto.Rows.Count <> 0 Then
                                If MyStockCompuesto(0).STOCK <> 0 Then
                                    MyVentaLinea = MyVentaLinea + 1
                                    MyNumeroLote = "0000000000"
                                    MyNumeroLinea = Strings.Right("000" & MyVentaLinea.ToString, 3)
                                    If MyStockCompuesto(0).STOCK >= MyCantidadPendienteDespachar Then
                                        MyCantidad = MyCantidadPendienteDespachar
                                        MyCantidadPendienteDespachar = 0
                                    Else
                                        MyCantidad = MyStockCompuesto(0).STOCK
                                        MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStockCompuesto(0).STOCK
                                    End If
                                    With MyDetallesPedido(NumReg1)
                                        Call ValorizarDocumento(.PRECIO_UNITARIO_ME)
                                        MyCantidadControl = MyCantidadControl + MyCantidad
                                        gvVentaLineas.Rows.Add(.EMPRESA, MyVenta, MyNumeroLinea, .PRODUCTO, .DESCRIPCION_AMPLIADA, MyCantidad, .PRECIO_UNITARIO_ME, MyImporteSubTotalOrigen, "0000000000", "SI", "SI")
                                        Call InsertarVentaDetalle(MyOrdenPedido, MyDetallesPedido)
                                        '--- Código para descargar los productos que componen el compuesto
                                        MyFactor = MyCantidad
                                        For NumReg3 = 0 To MyStockCompuesto.Rows.Count - 1
                                            MyProducto = MyStockCompuesto(NumReg3).PRODUCTO
                                            MyCantidadPendienteDespachar = MyStockCompuesto(NumReg3).CANTIDAD * MyFactor
                                            MyStock = dalOperacionAlmacen.BuscarStock(MyOrdenPedido.almacen_venta, MyProducto)
                                            If MyStock.Rows.Count <> 0 Then
                                                For NumReg2 = 0 To MyStock.Rows.Count - 1
                                                    MyNumeroLote = MyStock(NumReg2).NUMERO_LOTE.Trim
                                                    If MyStock(NumReg2).STOCK >= MyCantidadPendienteDespachar Then
                                                        MyCantidad = MyCantidadPendienteDespachar
                                                        MyCantidadPendienteDespachar = 0
                                                    Else
                                                        MyCantidad = MyStock(NumReg2).STOCK
                                                        MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStock(NumReg2).STOCK
                                                    End If
                                                    Call InsertarVentaDetalleCompuesto(MyOrdenPedido, MyStockCompuesto)
                                                    Call ActualizarStockResumen(MyStockCompuesto(NumReg3).PRODUCTO)
                                                    Call ActualizarStockPeriodo(MyOrdenPedido.ejercicio_venta, MyOrdenPedido.mes_venta, MyStockCompuesto(NumReg3).PRODUCTO)
                                                    If MyCantidadPendienteDespachar = 0 Then Exit For
                                                Next
                                            End If
                                        Next
                                        '----------------------------------------------------------------
                                    End With
                                Else
                                    With MyDetallesPedido(NumReg1)
                                        gvVentaLineas.Rows.Add(.EMPRESA, Space(1), Space(1), .PRODUCTO, .DESCRIPCION_AMPLIADA, 0, .PRECIO_UNITARIO_ME, 0, Space(1), "SI", "SI")
                                    End With
                                End If
                            End If
                        End If
                    End If
                    MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
                Next

                If MyImporteTotalOrigen <> 0 Then
                    Call ActualizarImporteTotal(MyOrdenPedido.empresa, MyOrdenPedido.venta)
                End If

                MySQLTransactionScope.Complete()

                Return MyImporteTotalOrigen
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Sub ActualizarImporteTotal(ByVal cEmpresa As String, ByVal cVenta As String)
        MyBaseImponibleGravadaOrigen = Math.Round(MyImporteTotalOrigen / 1.18, 2)
        MyIGVOrigen = MyImporteTotalOrigen - MyBaseImponibleGravadaOrigen
        If MyTipoMoneda = "1" Then ' MN
            MyBaseImponibleGravadaMN = MyBaseImponibleGravadaOrigen
            MyImporteTotalMN = MyImporteTotalOrigen
            MyIGVMN = MyImporteTotalMN - MyBaseImponibleGravadaMN
            MyBaseImponibleGravadaME = Math.Round(MyBaseImponibleGravadaOrigen / MyTipoCambio, 2)
            MyImporteTotalME = Math.Round(MyImporteTotalOrigen / MyTipoCambio, 2)
            MyIGVME = MyImporteTotalME - MyBaseImponibleGravadaME
        Else
            MyBaseImponibleGravadaME = MyBaseImponibleGravadaOrigen
            MyImporteTotalME = MyImporteTotalOrigen
            MyIGVME = MyImporteTotalME - MyBaseImponibleGravadaME
            MyBaseImponibleGravadaMN = Math.Round(MyBaseImponibleGravadaOrigen * MyTipoCambio, 2)
            MyImporteTotalMN = Math.Round(MyImporteTotalOrigen * MyTipoCambio, 2)
            MyIGVMN = MyImporteTotalMN - MyBaseImponibleGravadaMN
        End If

        MySQL = "UPDATE COM.VENTAS SET " & _
                "base_imponible_gravada_origen=@vbase_imponible_gravada_origen,igv_origen=@vigv_origen,importe_total_origen=@vimporte_total_origen," & _
                "base_imponible_gravada_mn=@vbase_imponible_gravada_mn,igv_mn=@vigv_mn,importe_total_mn=@vimporte_total_mn," & _
                "base_imponible_gravada_me=@vbase_imponible_gravada_me,igv_me=@vigv_me,importe_total_me=@vimporte_total_me," & _
                "indica_sujeta_detraccion='NO',porcentaje_detraccion=0,origen='VEN' " & _
                "WHERE empresa=@vEmpresa AND venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vBase_imponible_gravada_origen", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_origen", MyIGVOrigen)
                    .AddWithValue("vImporte_total_origen", MyImporteTotalOrigen)
                    .AddWithValue("vBase_imponible_gravada_mn", MyBaseImponibleGravadaMN)
                    .AddWithValue("vIgv_mn", MyIGVMN)
                    .AddWithValue("vImporte_total_mn", MyImporteTotalMN)
                    .AddWithValue("vBase_imponible_gravada_me", MyBaseImponibleGravadaOrigen)
                    .AddWithValue("vIgv_me", MyIGVOrigen)
                    .AddWithValue("vImporte_total_me", MyImporteTotalOrigen)
                    .AddWithValue("vEmpresa", cEmpresa)
                    .AddWithValue("vVenta", cVenta)
                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub EliminarPedidoFacturado(ByVal MyVenta As String)
        MySQL = "DELETE FROM COM.VENTAS " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vVenta", MyVenta)
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
    End Sub

    Private Shared Sub InsertarVentaCabecera(ByVal MyOrdenPedido As entOrdenPedido)
        MySQL = "INSERT INTO COM.VENTAS (EMPRESA,VENTA,EJERCICIO,MES,ALMACEN,LISTA_PRECIO,TIPO_VENTA,CENTRO_DISTRIBUCION," & _
                "ORDEN_PEDIDO,ASIENTO_NUMERO,ASIENTO_FECHA,COMPROBANTE_TIPO,COMPROBANTE_SERIE," & _
                "COMPROBANTE_NUMERO,COMPROBANTE_FECHA,COMPROBANTE_VENCIMIENTO,CUENTA_COMERCIAL," & _
                "CODIGO_VENDEDOR,USUARIO_REGISTRO,TIPO_MONEDA,TIPO_CAMBIO) " & _
                "VALUES (@vEmpresa,@vVenta,@vEjercicio,@vMes,@vAlmacen,@vLista_precio,@vTipo_venta,@vCentro_distribucion," & _
                "@vOrden_pedido,@vAsiento_numero,@vAsiento_fecha,@vComprobante_tipo,@vComprobante_serie," & _
                "@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento,@vCuenta_comercial," & _
                "@vCodigo_vendedor,@vUsuario_registro,@vTipo_moneda,@vTipo_cambio) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyOrdenPedido.empresa)
                    .AddWithValue("vVenta", MyOrdenPedido.venta)
                    .AddWithValue("vEjercicio", MyOrdenPedido.ejercicio_venta)
                    .AddWithValue("vMes", MyOrdenPedido.mes_venta)
                    .AddWithValue("vAlmacen", MyOrdenPedido.almacen_venta)
                    .AddWithValue("vLista_precio", MyOrdenPedido.lista_precio)
                    .AddWithValue("vTipo_venta", MyOrdenPedido.tipo_venta)
                    .AddWithValue("vCentro_distribucion", MyOrdenPedido.centro_distribucion)
                    .AddWithValue("vOrden_pedido", MyOrdenPedido.orden_pedido)
                    .AddWithValue("vAsiento_numero", MyOrdenPedido.asiento_numero)
                    .AddWithValue("vAsiento_fecha", MyOrdenPedido.fecha_venta)
                    .AddWithValue("vComprobante_tipo", MyOrdenPedido.comprobante_tipo)
                    .AddWithValue("vComprobante_serie", MyOrdenPedido.comprobante_serie)
                    .AddWithValue("vComprobante_numero", MyOrdenPedido.comprobante_numero)
                    .AddWithValue("vComprobante_fecha", MyOrdenPedido.comprobante_fecha)
                    .AddWithValue("vComprobante_vencimiento", MyOrdenPedido.comprobante_vencimiento)
                    .AddWithValue("vCuenta_comercial", MyOrdenPedido.cuenta_comercial)
                    .AddWithValue("vCodigo_vendedor", MyOrdenPedido.codigo_vendedor)
                    .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                    .AddWithValue("vTipo_moneda", MyOrdenPedido.pago_moneda)
                    .AddWithValue("vTipo_cambio", MyOrdenPedido.tipo_cambio)


                End With
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

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

    Private Shared Sub ExtornarVenta(ByVal pVenta As String)
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
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub ExtornarVentaProductos(ByVal pVenta As String)
        Dim MyVentaProductos As New dsVentas.VENTAS_PRODUCTOSDataTable
        CadenaSQL = "SELECT V.EJERCICIO, V.MES, V.ALMACEN, V.PRODUCTO, V.NUMERO_LOTE, SUM(V.CANTIDAD) AS CANTIDAD " & _
                    "FROM COM.VENTAS_PRODUCTO AS V INNER JOIN COM.PRODUCTOS AS P ON V.EMPRESA=P.EMPRESA AND V.PRODUCTO=P.PRODUCTO " & _
                    "WHERE V.EMPRESA='" & MyEmpresa & "' AND V.VENTA='" & pVenta & "' AND P.INDICA_VALIDA_STOCK='SI' " & _
                    "GROUP BY V.EJERCICIO, V.MES, V.ALMACEN, V.PRODUCTO, V.NUMERO_LOTE "
        Call ObtenerDataTableSQL(CadenaSQL, MyVentaProductos)
        If MyVentaProductos.Rows.Count > 0 Then
            For NumReg1 = 0 To MyVentaProductos.Rows.Count - 1
                With MyVentaProductos(NumReg1)
                    MyAlmacen = .ALMACEN
                    MyNumeroLote = .NUMERO_LOTE
                    MyCantidad = .CANTIDAD * -1
                    Call ActualizarStockResumen(.PRODUCTO)
                    Call ActualizarStockPeriodo(.EJERCICIO, .MES, .PRODUCTO)
                End With
            Next
        End If
    End Sub

    Private Shared Sub ExtornarVentaPedido(ByVal pVenta As String)
        Dim MyVentaPedido As New dsVentas.VENTAS_PEDIDODataTable
        CadenaSQL = "SELECT LINEA, PRODUCTO, CANTIDAD " & _
                    "FROM COM.VENTAS_PRO " & _
                    "WHERE EMPRESA='" & MyEmpresa & "' AND VENTA='" & pVenta & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyVentaPedido)
        If MyVentaPedido.Rows.Count > 0 Then
            For NumReg1 = 0 To MyVentaPedido.Rows.Count - 1
                With MyVentaPedido(NumReg1)
                    Call ActualizarVentaPedido(.CANTIDAD, pVenta, .LINEA, .PRODUCTO)
                End With
            Next
        End If
    End Sub

    Private Shared Sub ActualizarVentaPedido(ByVal pCantidad As Integer, ByVal pVenta As String, ByVal pVentaLinea As String, ByVal pProducto As String)
        MySQL = "UPDATE COM.ORDEN_PEDIDO_DET SET " & _
                "VENTA=CASE WHEN VENTA_CANTIDAD-@vCantidad=0 THEN '000000000000' ELSE VENTA END," & _
                "VENTA_LINEA=CASE WHEN VENTA_CANTIDAD-@vCantidad=0 THEN '000' ELSE VENTA_LINEA END," & _
                "VENTA_CANTIDAD=VENTA_CANTIDAD-@vCantidad," & _
                "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Venta_linea=@vVenta_linea AND Producto=@vProducto "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLDbconnection.Open()
            Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vCantidad", pCantidad)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
                MySQLCommand.Parameters.AddWithValue("vVenta_linea", pVentaLinea)
                MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
                MySQLCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function Anular(ByVal cVenta As entVenta) As Boolean
        Dim MyIndicadorProcesoConcluido As Boolean
        Call BuscarComprobanteDuplicado(cVenta)
        If Not String.IsNullOrEmpty(cVenta.venta) Then
            Resp = MsgBox("Confirmar proceso de ANULACION.", MsgBoxStyle.YesNo, "ANULAR DOCUMENTO")
            If Resp.ToString = vbYes Then
                MyIndicadorProcesoConcluido = AnularVentaProductos(cVenta.venta, False)
                'Call AnularVentaServicios(cVenta.venta)
                Return MyIndicadorProcesoConcluido
            End If
        End If
    End Function

    Public Shared Function Eliminar(ByVal cVenta As entVenta) As Boolean
        Dim MyIndicadorProcesoConcluido As Boolean
        Call BuscarComprobanteDuplicado(cVenta)
        If Not String.IsNullOrEmpty(cVenta.venta) Then
            Resp = MsgBox("El Comprobante será eliminado permanentemente." & vbCrLf & _
                          "¿Desea continuar?", MsgBoxStyle.YesNo, "ELIMINAR DOCUMENTO")
            If Resp.ToString = vbYes Then
                Resp = MsgBox("Confirmar proceso de ELIMINACION.", MsgBoxStyle.YesNo, "ELIMINAR DOCUMENTO")
                If Resp.ToString = vbYes Then
                    MyIndicadorProcesoConcluido = AnularVentaProductos(cVenta.venta, True)
                    Return MyIndicadorProcesoConcluido
                End If
            End If
        End If
    End Function

    Private Shared Function AnularVentaProductos(ByVal pVenta As String, ByVal IndicaEliminado As Boolean) As Boolean
        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                Call ExtornarVentaPedido(pVenta)    ' Actualiza COM.ORDEN_PEDIDO_DET
                Call ExtornarVentaProductos(pVenta) ' Actualiza ALM.RESUMEN_X_ALMACEN y ALM.RESUMEN_X_PERIODO
                Call ExtornarVenta(pVenta)          ' Actualiza COM.VENTAS

                MySQL = "DELETE FROM COM.VENTAS_PRO " & _
                        "WHERE Empresa=@vEmpresa AND Venta=@vVenta"
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    MySQL = "DELETE FROM COM.VENTAS_COM " & _
                            "WHERE Empresa=@vEmpresa AND Venta=@vVenta"
                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    If IndicaEliminado = True Then
                        MySQL = "UPDATE COM.VENTAS SET " & _
                                "EJERCICIO='0000', MES='00', COMPROBANTE_SERIE='0000', COMPROBANTE_NUMERO='0000000000', ESTADO='X' " & _
                                "WHERE Empresa=@vEmpresa AND Venta=@vVenta"
                        Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                            MySQLCommand.Parameters.AddWithValue("vVenta", pVenta)
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

#End Region

#Region "Detalle"
    Public Shared Function Grabar(ByVal cVentaDetalle As entVentaServicio) As entVentaServicio
        With cVentaDetalle
            Dim ValidarImporte As Single = Math.Round(.importe_total_origen - .base_imponible_gravada_origen - .igv_origen - .importe_inafecto_origen - .otros_tributos_origen, 2)
            If RTrim(.glosa_1 & .glosa_2 & .glosa_3).Length = 0 Then Throw New BusinessException(MSG000 & " GLOSA DEL DETALLE")
            If .base_imponible_gravada_origen = 0 And .importe_inafecto_origen = 0 And .igv_origen = 0 And .otros_tributos_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR AFECTO")
            'If .importe_inafecto_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR EXENTO")
            'If .igv_origen = 0 Then Throw New BusinessException(MSG000 & " IMPUESTO")
            If ValidarImporte <> 0 Then Throw New BusinessException("LOS IMPORTES REGISTRADOR NO GUARDAN COHERENCIA")
            'If .centro_costo = "99999" Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")
            'If String.IsNullOrEmpty(.centro_costo.Trim) Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")
            'If .indica_proyecto Then If String.IsNullOrEmpty(.proyecto.Trim) Then Throw New BusinessException(MSG000 & " PROYECTO")
        End With
        If String.IsNullOrEmpty(cVentaDetalle.linea.Trim) Then
            'Return Insertar(cVentaDetalle)
        Else
            'Return Actualizar(cVentaDetalle)
        End If
    End Function

    Public Shared Function Grabar(ByVal cVentaDetalle As entVentaProducto, ByRef gvVentaLineas As DataGridView) As Boolean
        With cVentaDetalle
            Dim ValidarImporte As Single = Math.Round(.importe_total_origen - .base_imponible_gravada_origen - .igv_origen - .importe_inafecto_origen - .otros_tributos_origen, 2)
            If RTrim(.producto).Length = 0 Then Throw New BusinessException(MSG000 & " PRODUCTO")
            If .cantidad = 0 Then Throw New BusinessException(MSG000 & " CANTIDAD")

            'If .base_imponible_gravada_origen = 0 And .importe_inafecto_origen = 0 And .igv_origen = 0 And .otros_tributos_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR AFECTO")
            'If .importe_inafecto_origen = 0 Then Throw New BusinessException(MSG000 & " VALOR EXENTO")
            'If .igv_origen = 0 Then Throw New BusinessException(MSG000 & " IMPUESTO")
            'If ValidarImporte <> 0 Then Throw New BusinessException("LOS IMPORTES REGISTRADOR NO GUARDAN COHERENCIA")
            'If .centro_costo = "99999" Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")
            'If String.IsNullOrEmpty(.centro_costo.Trim) Then Throw New BusinessException(MSG000 & " CENTRO DE COSTO")
            'If .indica_proyecto Then If String.IsNullOrEmpty(.proyecto.Trim) Then Throw New BusinessException(MSG000 & " PROYECTO")
        End With
        If String.IsNullOrEmpty(cVentaDetalle.linea.Trim) Then
            Return Insertar(cVentaDetalle, gvVentaLineas)
        Else
            If Eliminar(cVentaDetalle, gvVentaLineas) = True Then
                Return Insertar(cVentaDetalle, gvVentaLineas)
            End If
        End If
    End Function

    Private Shared Function Insertar(ByVal MyVentaDetalle As entVentaProducto, ByRef gvVentaLineas As DataGridView) As Boolean
        Dim MyVenta As String = ""
        Dim MyProducto As String = ""
        Dim MyCantidadPendienteDespachar As Decimal = 0
        Dim MyStockDisponible As Decimal = 0
        Dim MyStock As dsStockAlmacen.STOCK_X_PRODUCTODataTable
        Dim MyStockCompuesto As dsStockAlmacen.STOCK_X_COMPUESTODataTable
        Dim MyFactor As Integer = 0

        MyImporteTotalOrigen = 0

        With MyVentaDetalle
            MyVenta = .venta
            MyTipoCambio = .tipo_cambio
            MyTipoMoneda = .tipo_moneda
            MyAlmacen = .almacen
            MyProducto = .producto
            MyCantidadPendienteDespachar = .cantidad
        End With

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                If MyVentaDetalle.indica_valida_stock = "NO" Then
                    MyNumeroLote = "0000000000"
                    MyNumeroLinea = AsignarLinea(MyVentaDetalle.venta)
                    MyCantidad = MyCantidadPendienteDespachar
                    With MyVentaDetalle
                        Call ValorizarDocumento(.precio_unitario)
                        gvVentaLineas.Rows.Add(.empresa, .venta, MyNumeroLinea, .producto, .descripcion_ampliada, MyCantidad, .precio_unitario, MyImporteSubTotalOrigen, MyNumeroLote, "NO", "NO")
                        Call InsertarVentaDetalle(MyVentaDetalle)
                    End With
                Else
                    If MyVentaDetalle.indica_compuesto = "NO" Then
                        MyStock = dalOperacionAlmacen.BuscarStock(MyVentaDetalle.almacen, MyVentaDetalle.producto)
                        If MyStock.Rows.Count = 0 Then
                            Resp = MsgBox("No existe Stock para este producto.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "PROCESO CANCELADO")
                        Else
                            Continuar = True
                            For NumReg2 = 0 To MyStock.Rows.Count - 1
                                MyStockDisponible = MyStockDisponible + MyStock(NumReg2).STOCK
                            Next
                            If MyStockDisponible = 0 Then
                                Resp = MsgBox("No existe Stock para este producto.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "PROCESO CANCELADO")
                                Continuar = False
                            ElseIf MyStockDisponible < MyCantidadPendienteDespachar Then
                                Resp = MsgBox("El Stock Disponible es menor que lo solicitado." & vbCrLf & _
                                              "Stock Disponible: " & EvalDato(MyStockDisponible, "E") & vbCrLf & _
                                              "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                If Resp.ToString = vbNo Then Continuar = False
                            End If
                            If Continuar = True Then
                                If Continuar = True Then
                                    For NumReg2 = 0 To MyStock.Rows.Count - 1
                                        MyNumeroLote = MyStock(NumReg2).NUMERO_LOTE.Trim
                                        MyNumeroLinea = AsignarLinea(MyVentaDetalle.venta)
                                        If MyStock(NumReg2).STOCK >= MyCantidadPendienteDespachar Then
                                            MyCantidad = MyCantidadPendienteDespachar
                                            MyCantidadPendienteDespachar = 0
                                        Else
                                            MyCantidad = MyStock(NumReg2).STOCK
                                            MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStock(NumReg2).STOCK
                                        End If
                                        With MyVentaDetalle
                                            Call ValorizarDocumento(.precio_unitario)
                                            gvVentaLineas.Rows.Add(.empresa, .venta, MyNumeroLinea, .producto, .descripcion_ampliada, MyCantidad, .precio_unitario, MyImporteSubTotalOrigen, MyNumeroLote, "NO")
                                            Call InsertarVentaDetalle(MyVentaDetalle)
                                            Call ActualizarStockResumen(.producto)
                                            Call ActualizarStockPeriodo(.ejercicio_venta, .mes_venta, .producto)
                                        End With
                                        If MyCantidadPendienteDespachar = 0 Then Exit For
                                    Next
                                End If
                            End If
                        End If
                    Else
                        MyStockCompuesto = dalOperacionAlmacen.BuscarStockCompuesto(MyVentaDetalle.almacen, MyProducto)
                        If MyStockCompuesto.Rows.Count = 0 Then
                            Resp = MsgBox("No existe Stock para este producto.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "PROCESO CANCELADO")
                        Else
                            Continuar = True
                            MyStockDisponible = MyStockCompuesto(0).STOCK
                            If MyStockDisponible = 0 Then
                                Resp = MsgBox("No existe Stock para este producto.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "PROCESO CANCELADO")
                                Continuar = False
                            ElseIf MyStockDisponible < MyCantidadPendienteDespachar Then
                                Resp = MsgBox("El Stock Disponible es menor que lo solicitado." & vbCrLf & _
                                              "Stock Disponible: " & EvalDato(MyStockDisponible, "E") & vbCrLf & _
                                              "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
                                If Resp.ToString = vbNo Then Continuar = False
                            End If
                            If Continuar = True Then
                                MyStockDisponible = MyStockCompuesto(0).STOCK
                                MyNumeroLote = "0000000000"
                                MyNumeroLinea = AsignarLinea(MyVentaDetalle.venta)
                                If MyStockDisponible >= MyCantidadPendienteDespachar Then
                                    MyCantidad = MyCantidadPendienteDespachar
                                    MyCantidadPendienteDespachar = 0
                                Else
                                    MyCantidad = MyStockDisponible
                                    MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStockDisponible
                                End If
                                With MyVentaDetalle
                                    Call ValorizarDocumento(.precio_unitario)
                                    gvVentaLineas.Rows.Add(.empresa, .venta, MyNumeroLinea, .producto, .descripcion_ampliada, MyCantidad, .precio_unitario, MyImporteSubTotalOrigen, "0000000000", "SI")
                                    Call InsertarVentaDetalle(MyVentaDetalle)
                                    '--- Código para descargar los productos que componen el compuesto
                                    MyFactor = MyCantidad
                                    For NumReg3 = 0 To MyStockCompuesto.Rows.Count - 1
                                        MyProducto = MyStockCompuesto(NumReg3).PRODUCTO
                                        MyCantidadPendienteDespachar = MyStockCompuesto(NumReg3).CANTIDAD * MyFactor
                                        MyStock = dalOperacionAlmacen.BuscarStock(MyVentaDetalle.almacen, MyProducto)
                                        If MyStock.Rows.Count <> 0 Then
                                            For NumReg2 = 0 To MyStock.Rows.Count - 1
                                                MyNumeroLote = MyStock(NumReg2).NUMERO_LOTE.Trim
                                                If MyStock(NumReg2).STOCK >= MyCantidadPendienteDespachar Then
                                                    MyCantidad = MyCantidadPendienteDespachar
                                                    MyCantidadPendienteDespachar = 0
                                                Else
                                                    MyCantidad = MyStock(NumReg2).STOCK
                                                    MyCantidadPendienteDespachar = MyCantidadPendienteDespachar - MyStock(NumReg2).STOCK
                                                End If
                                                Call InsertarVentaDetalleCompuesto(MyVentaDetalle, MyStockCompuesto)
                                                Call ActualizarStockResumen(MyStockCompuesto(NumReg3).PRODUCTO)
                                                Call ActualizarStockPeriodo(MyVentaDetalle.ejercicio_venta, MyVentaDetalle.mes_venta, MyStockCompuesto(NumReg3).PRODUCTO)
                                                If MyCantidadPendienteDespachar = 0 Then Exit For
                                            Next
                                        End If
                                    Next
                                    '----------------------------------------------------------------
                                End With


                            End If
                        End If
                    End If
                End If



                For Each row As DataGridViewRow In gvVentaLineas.Rows
                    MyImporteSubTotalOrigen = row.Cells(7).Value
                    MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
                Next

                Call ActualizarImporteTotal(MyVentaDetalle.empresa, MyVentaDetalle.venta)

                MySQLTransactionScope.Complete()

                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function Descartar(ByVal MyVentaDetalle As entVentaProducto, ByRef gvVentaLineas As DataGridView) As Boolean
        Return Eliminar(MyVentaDetalle, gvVentaLineas)
    End Function

    Private Shared Function Eliminar(ByVal MyVentaDetalle As entVentaProducto, ByRef gvVentaLineas As DataGridView) As Boolean
        Dim MyVenta As String = ""
        Dim MyProducto As String = ""
        Dim MyDGV_Row As New DataGridViewRow

        MyImporteTotalOrigen = 0
        MyVentaLinea = MyVentaDetalle.linea

        For Each row As DataGridViewRow In gvVentaLineas.Rows
            If row.Cells(2).Value = MyVentaLinea Then
                MyDGV_Row = gvVentaLineas.CurrentRow
                MyProducto = row.Cells(3).Value
            End If
        Next

        With MyVentaDetalle
            MyVenta = .venta
            MyTipoCambio = .tipo_cambio
            MyTipoMoneda = .tipo_moneda
            MyAlmacen = .almacen
        End With

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                If MyVentaDetalle.indica_valida_stock = "SI" Then
                    Call ExtornarVentaProducto(MyVentaDetalle.venta, MyVentaDetalle.linea) ' Actualiza ALM.RESUMEN_X_ALMACEN y ALM.RESUMEN_X_PERIODO
                End If

                If MyVentaDetalle.orden_pedido <> Space(1) Then
                    Call ActualizarVentaPedido(MyVentaDetalle.cantidad, MyVentaDetalle.venta, MyVentaDetalle.linea, MyVentaDetalle.producto)
                End If

                For Each row As DataGridViewRow In gvVentaLineas.Rows
                    If row.Cells(2).Value <> MyVentaLinea Then
                        MyImporteSubTotalOrigen = row.Cells(7).Value
                        MyImporteTotalOrigen = MyImporteTotalOrigen + MyImporteSubTotalOrigen
                    End If
                Next

                gvVentaLineas.Rows.Remove(MyDGV_Row)

                Call ActualizarImporteTotal(MyVentaDetalle.empresa, MyVentaDetalle.venta)

                MySQL = "INSERT INTO AUD.VENTAS_PRO " & _
                        "SELECT * FROM COM.VENTAS_PRO " & _
                        "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()

                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", MyVentaDetalle.venta)
                        MySQLCommand.Parameters.AddWithValue("vLinea", MyVentaDetalle.linea)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    MySQL = "INSERT INTO AUD.VENTAS_COM " & _
                            "SELECT * FROM COM.VENTAS_COM " & _
                            "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "

                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", MyVentaDetalle.venta)
                        MySQLCommand.Parameters.AddWithValue("vLinea", MyVentaDetalle.linea)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    MySQL = "DELETE FROM COM.VENTAS_PRO " & _
                            "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "
                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", MyVentaDetalle.venta)
                        MySQLCommand.Parameters.AddWithValue("vLinea", MyVentaDetalle.linea)
                        MySQLCommand.ExecuteNonQuery()
                    End Using

                    MySQL = "DELETE FROM COM.VENTAS_COM " & _
                            "WHERE Empresa=@vEmpresa AND Venta=@vVenta AND Linea=@vLinea "
                    Using MySQLCommand As New SqlCommand(MySQL, MySQLDbconnection)
                        MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                        MySQLCommand.Parameters.AddWithValue("vVenta", MyVentaDetalle.venta)
                        MySQLCommand.Parameters.AddWithValue("vLinea", MyVentaDetalle.linea)
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

    Private Shared Sub ExtornarVentaProducto(ByVal pVenta As String, ByVal pLinea As String)
        Dim MyVentaProductos As New dsVentas.VENTAS_PRODUCTOSDataTable
        CadenaSQL = "SELECT EJERCICIO, MES, ALMACEN, PRODUCTO, NUMERO_LOTE, SUM(CANTIDAD) AS CANTIDAD " & _
                    "FROM COM.VENTAS_LINEA " & _
                    "WHERE EMPRESA='" & MyEmpresa & "' AND VENTA='" & pVenta & "' AND LINEA='" & pLinea & "' " & _
                    "GROUP BY EJERCICIO, MES, ALMACEN, PRODUCTO, NUMERO_LOTE "
        Call ObtenerDataTableSQL(CadenaSQL, MyVentaProductos)
        If MyVentaProductos.Rows.Count > 0 Then
            For NumReg1 = 0 To MyVentaProductos.Rows.Count - 1
                With MyVentaProductos(NumReg1)
                    MyCantidad = .CANTIDAD * -1
                    MyAlmacen = .ALMACEN
                    MyNumeroLote = .NUMERO_LOTE
                    Call ActualizarStockResumen(.PRODUCTO)
                    Call ActualizarStockPeriodo(.EJERCICIO, .MES, .PRODUCTO)
                End With
            Next
        End If
    End Sub
#End Region

End Class
