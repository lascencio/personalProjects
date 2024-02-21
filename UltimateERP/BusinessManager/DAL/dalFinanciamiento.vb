Imports System.Data.SqlClient

Public Class dalFinanciamiento

    Private Shared MySQLString As String
    Private Shared MySQLString_1 As String
    Private Shared MySQLString_2 As String
    Private Shared MySQLString_3 As String
    Private Shared MyStoreProcedure As String

    Private Shared MyCount As Integer

    Private Shared MySQLCommand As SqlCommand

    Public Shared Function GrabarProforma(MyProforma As dsFinanciero.PROFORMASDataTable, EsVehicular As Boolean, CuotaInicial As Decimal, CuotaInicialPago As Decimal) As dsFinanciero.PROFORMASDataTable
        Dim ExisteCuotaInicial As Boolean
        MyProforma(0).PROFORMA = AsignarProforma()

        If EsVehicular = True Then ExisteCuotaInicial = dalVenta.ExisteCuotaInicial(MyProforma(0).EMPRESA, MyProforma(0).VENTA)

        MySQLString = "INSERT INTO FIN.PROFORMAS " &
                      "(EMPRESA,PROFORMA,EJERCICIO,MES,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,DOMICILIO,TIPO_PRESTAMO,FORMA_PAGO,FECHA_DESEMBOLSO,TIPO_MONEDA," &
                      "CAPITAL,NUMERO_CUOTAS,TASA_INTERES,TASA_MOROSIDAD,VALOR_CUOTA,TOTAL_INTERES,TOTAL_IMPUESTO,TOTAL_PRESTAMO,CUOTA_INICIAL,VENTA," &
                      "AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
                      "VALUES " &
                      "(@vEmpresa,@vProforma,@vEjercicio,@vMes,@vTipo_documento,@vNro_documento,@vRazon_social,@vDomicilio,@vTipo_prestamo,@vForma_pago,@vFecha_desembolso,@vTipo_moneda," &
                      "@vCapital,@vNumero_cuotas,@vTasa_interes,@vTasa_Morosidad,@vValor_Cuota,@vTotal_interes,@vTotal_impuesto,@vTotal_prestamo,@vCuota_inicial,@vVenta," &
                      "@vAgencia_registro,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyProforma(0).EMPRESA)
                .AddWithValue("vProforma", MyProforma(0).PROFORMA)
                .AddWithValue("vEjercicio", MyProforma(0).EJERCICIO)
                .AddWithValue("vMes", MyProforma(0).MES)
                .AddWithValue("vTipo_documento", MyProforma(0).TIPO_DOCUMENTO)
                .AddWithValue("vNro_documento", MyProforma(0).NRO_DOCUMENTO)
                .AddWithValue("vRazon_social", MyProforma(0).RAZON_SOCIAL)
                .AddWithValue("vDomicilio", MyProforma(0).DOMICILIO)
                .AddWithValue("vTipo_prestamo", MyProforma(0).TIPO_PRESTAMO)
                .AddWithValue("vForma_pago", MyProforma(0).FORMA_PAGO)
                .AddWithValue("vFecha_desembolso", MyProforma(0).FECHA_DESEMBOLSO)
                .AddWithValue("vTipo_moneda", MyProforma(0).TIPO_MONEDA)
                .AddWithValue("vCapital", MyProforma(0).CAPITAL)
                .AddWithValue("vNumero_cuotas", MyProforma(0).NUMERO_CUOTAS)
                .AddWithValue("vTasa_interes", MyProforma(0).TASA_INTERES)
                .AddWithValue("vTasa_Morosidad", MyProforma(0).TASA_MOROSIDAD)
                .AddWithValue("vValor_Cuota", MyProforma(0).VALOR_CUOTA)
                .AddWithValue("vTotal_interes", MyProforma(0).TOTAL_INTERES)
                .AddWithValue("vTotal_impuesto", MyProforma(0).TOTAL_IMPUESTO)
                .AddWithValue("vTotal_Prestamo", MyProforma(0).TOTAL_PRESTAMO)
                .AddWithValue("vCuota_inicial", MyProforma(0).CUOTA_INICIAL)
                .AddWithValue("vVenta", MyProforma(0).VENTA)
                .AddWithValue("vAgencia_registro", MyProforma(0).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_registro", MyProforma(0).USUARIO_REGISTRO)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                If EsVehicular = True Then
                    If ExisteCuotaInicial = True Then
                        MySQLString = "UPDATE COM.VENTAS_INI SET " &
                                      "Cuota_inicial=@vCuota_inicial, Cuota_inicial_pago=@vCuota_inicial_pago,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " &
                                      "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "
                    Else
                        MySQLString = "INSERT INTO COM.VENTAS_INI " & _
                                      "(EMPRESA, VENTA, CUOTA_INICIAL, CUOTA_INICIAL_PAGO, USUARIO_REGISTRO) " &
                                      "VALUES (@vEmpresa,@vVenta,@vCuota_inicial, @vCuota_inicial_pago, @vUsuario_registro)"
                    End If

                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString
                    MySQLCommand.Parameters.Clear()
                    With MySQLCommand.Parameters
                        .AddWithValue("vEmpresa", MyProforma(0).EMPRESA)
                        .AddWithValue("vVenta", MyProforma(0).VENTA)
                        .AddWithValue("vCuota_inicial", CuotaInicial)
                        .AddWithValue("vCuota_inicial_pago", CuotaInicialPago)
                        If ExisteCuotaInicial = True Then
                            .AddWithValue("vUsuario_modifica", MyProforma(0).USUARIO_REGISTRO)
                        Else
                            .AddWithValue("vUsuario_registro", MyProforma(0).USUARIO_REGISTRO)
                        End If
                    End With
                    MySQLCommand.ExecuteNonQuery()
                End If

                MySQLTransaction.Commit()

                Return MyProforma
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using


    End Function

    Private Shared Function AsignarProforma() As String
        MySQLString = "SELECT ISNULL(MAX(PROFORMA),'') AS NUEVO_CODIGO FROM FIN.PROFORMAS WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "P00000000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 11)) + 1
                NewCode = "P" & Right("00000000000" & Correlativo.ToString, 11)
            End If
            Return NewCode
        End Using
    End Function

    Public Shared Function ObtenerTipoPrestamo(ByVal pEmpresa As String, ByVal pTipoPrestamo As String) As dsFinanciero.TIPO_PRESTAMODataTable
        Dim MyDT As New dsFinanciero.TIPO_PRESTAMODataTable
        CadenaSQL = "SELECT EMPRESA, CODIGO, DESCRIPCION, TASA_INTERES, TASA_MOROSIDAD " & _
                    "FROM GEN.TABLA_TIPO_PRESTAMO " & _
                    "WHERE EMPRESA='" & pEmpresa & "' AND CODIGO='" & pTipoPrestamo & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerProformaNueva() As dsFinanciero.PROFORMASDataTable
        Dim MyDT As New dsFinanciero.PROFORMASDataTable
        CadenaSQL = "SELECT EMPRESA=SPACE(1), PROFORMA=SPACE(1), EJERCICIO=SPACE(1), MES=SPACE(1), TIPO_PRESTAMO=SPACE(1), FORMA_PAGO=SPACE(1), CUENTA_COMERCIAL=SPACE(1), " &
                    "FECHA_DESEMBOLSO=GETDATE(), TIPO_MONEDA=SPACE(1), CAPITAL=0, NUMERO_CUOTAS=0, TASA_INTERES=0, TASA_MOROSIDAD=0, " &
                    "VALOR_CUOTA=0, TOTAL_INTERES=0, TOTAL_IMPUESTO=0, TOTAL_PRESTAMO=0, CUOTA_INICIAL=0, VENTA=SPACE(1), " &
                    "REFERENCIA_CUO=SPACE(1), COMENTARIO=SPACE(1), TIPO_DOCUMENTO=SPACE(1), NRO_DOCUMENTO=SPACE(1), RAZON_SOCIAL=SPACE(1), DOMICILIO=SPACE(1), " &
                    "ESTADO=SPACE(1), AGENCIA_REGISTRO=SPACE(1), USUARIO_REGISTRO=SPACE(1), FECHA_REGISTRO=GETDATE(), AGENCIA_MODIFICA=SPACE(1), " &
                    "USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=GETDATE()  "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerProforma(ByVal pEmpresa As String, ByVal pProforma As String) As dsFinanciero.PROFORMASDataTable
        Dim MyDT As New dsFinanciero.PROFORMASDataTable
        CadenaSQL = "SELECT *  FROM FIN.PROFORMAS WHERE EMPRESA='" & pEmpresa & "' AND PROFORMA='" & pProforma & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerProformas(ByVal pEmpresa As String, ByVal pAgencia As String, ByVal pEjercicio As String, ByVal pMes As String) As dsFinanciero.PROFORMAS_LISTADataTable
        Dim MyDT As New dsFinanciero.PROFORMAS_LISTADataTable
        CadenaSQL = "SELECT P.PROFORMA, TP.DESCRIPCION AS TIPO_PRESTAMO, FECHA_REGISTRO, P.RAZON_SOCIAL, MONEDA=CASE WHEN P.TIPO_MONEDA='1' THEN 'PEN' ELSE 'USD' END, " &
                    "P.CAPITAL, P.NUMERO_CUOTAS, VALOR_CUOTA, TOTAL_PRESTAMO " &
                    "FROM FIN.PROFORMAS AS P INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA=TP.EMPRESA AND P.TIPO_PRESTAMO=TP.CODIGO " &
                    "WHERE P.EMPRESA='" & pEmpresa & "' AND ESTADO='P' AND P.AGENCIA_REGISTRO='" & pAgencia & "' AND P.EJERCICIO='" & pEjercicio & "' AND P.MES='" & pMes & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamoNuevo() As dsFinanciero.PRESTAMOSDataTable
        Dim MyDT As New dsFinanciero.PRESTAMOSDataTable
        CadenaSQL = "SELECT EMPRESA=SPACE(1), PRESTAMO=SPACE(1), EJERCICIO=SPACE(1), MES=SPACE(1), TIPO_DOCUMENTO=SPACE(1), NRO_DOCUMENTO=SPACE(1), RAZON_SOCIAL=SPACE(1), " &
                    "DOMICILIO=SPACE(1), TIPO_PRESTAMO=SPACE(1), FORMA_PAGO=SPACE(1), FECHA_DESEMBOLSO=GETDATE(), TIPO_MONEDA=SPACE(1), CAPITAL=0, NUMERO_CUOTAS=0, " &
                    "TASA_INTERES=0, TASA_MOROSIDAD=0, PORCENTAJE_IMPUESTO=0, VALOR_CUOTA=0, TOTAL_INTERES=0, TOTAL_IMPUESTO=0, TOTAL_PRESTAMO=0, TOTAL_SALDO=0, " &
                    "FECHA_PRIMER_PAGO=GETDATE(), MONTO_SOLICITADO=0, CUOTA_INICIAL=0, CUOTA_INICIAL_PAGADA=0, CUOTA_INICIAL_SALDO_FECHA_PAGO=GETDATE(), VENTA=SPACE(1), " &
                    "PROFORMA=SPACE(1), COMENTARIO=SPACE(1), INDICA_REFINANCIAMIENTO='NO', PRESTAMO_REFINANCIADO=SPACE(1), INDICA_PRONTO_PAGO='NO', INDICA_DEUDA_CONDONADA='NO'," &
                    "INDICA_INCOBRABLE='NO', USUARIO_DEVOLUCION=SPACE(1), FECHA_DEVOLUCION=GETDATE(), " &
                    "COMENTARIO_DEVOLUCION=SPACE(1), ESTADO=SPACE(1), AGENCIA_REGISTRO=SPACE(1), USUARIO_REGISTRO=SPACE(1), FECHA_REGISTRO=GETDATE(), AGENCIA_MODIFICA=SPACE(1), " &
                    "USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=GETDATE()  "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamo(ByVal pEmpresa As String, ByVal pPrestamo As String) As dsFinanciero.PRESTAMOSDataTable
        Dim MyDT As New dsFinanciero.PRESTAMOSDataTable
        CadenaSQL = "SELECT *  FROM FIN.PRESTAMOS WHERE EMPRESA='" & pEmpresa & "' AND PRESTAMO='" & pPrestamo & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamoCuotas(ByVal pEmpresa As String, ByVal pPrestamo As String) As dsFinanciero.PRESTAMOS_CUOTASDataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_CUOTASDataTable
        CadenaSQL = "SELECT *  FROM FIN.PRESTAMOS_CUOTAS WHERE EMPRESA='" & pEmpresa & "' AND PRESTAMO='" & pPrestamo & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamoCuotasLista(ByVal pEmpresa As String, ByVal pPrestamo As String, IndicaTodas As Boolean) As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        CadenaSQL = "SELECT CUOTA AS NUMERO_CUOTA, FECHA_VENCIMIENTO, VALOR_CUOTA, " &
                    "FECHA_PAGO=CASE WHEN YEAR(FECHA_PAGO)<=1900 THEN NULL ELSE FECHA_PAGO END, " &
                    "SALDO_CUOTA, " &
                    "DIAS_MORA=CASE WHEN SALDO_CUOTA=0 THEN 0 ELSE (CASE WHEN UTI.DIAS_MORA(CASE WHEN YEAR(FECHA_PAGO)>1900 THEN FECHA_PAGO ELSE FECHA_VENCIMIENTO END)<0 THEN 0 ELSE UTI.DIAS_MORA(CASE WHEN YEAR(FECHA_PAGO)>1900 THEN FECHA_PAGO ELSE FECHA_VENCIMIENTO END) END) END, MORA, " &
                    "CUOTA_PAGO=SALDO_CUOTA,MORA_PAGO=MORA, 0 AS TOTAL_PAGO, " &
                    "COMPROMISO_FECHA=CASE WHEN YEAR(COMPROMISO_FECHA)<=1900 THEN NULL ELSE COMPROMISO_FECHA END, COMPROMISO_COMENTARIO " &
                    "FROM FIN.PRESTAMOS_CUOTAS WHERE EMPRESA='" & pEmpresa & "' AND PRESTAMO='" & pPrestamo & "' " &
                    IIf(IndicaTodas = True, "", " AND SALDO_CUOTA<>0 ")
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranzas(ByVal pEmpresa As String, ByVal pCobranza As String) As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable
        CadenaSQL = "SELECT CD.CUOTA AS NUMERO_CUOTA, PC.FECHA_VENCIMIENTO, PC.VALOR_CUOTA, " &
                    "FECHA_PAGO=CASE WHEN YEAR(CD.FECHA_PAGO)<=1900 THEN NULL ELSE CD.FECHA_PAGO END, " &
                    "CD.SALDO_CUOTA, " &
                    "CD.DIAS_MORA, CD.MORA, " &
                    "CD.CUOTA_PAGO, CD.MORA_PAGO, CD.TOTAL_PAGO, " &
                    "COMPROMISO_FECHA=CASE WHEN YEAR(CD.COMPROMISO_FECHA)<=1900 THEN NULL ELSE CD.COMPROMISO_FECHA END, " &
                    "CD.COMPROMISO_COMENTARIO " &
                    "FROM FIN.COBRANZAS_DETALLES AS CD INNER JOIN FIN.PRESTAMOS_CUOTAS AS PC ON CD.EMPRESA = PC.EMPRESA AND CD.PRESTAMO = PC.PRESTAMO AND CD.CUOTA = PC.CUOTA " &
                    "WHERE CD.EMPRESA='" & pEmpresa & "' AND CD.COBRANZA = '" & pCobranza & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamos(ByVal pEmpresa As String, ByVal pAgencia As String, ByVal pEjercicio As String, ByVal pMes As String, pEstado As String) As dsFinanciero.PRESTAMOS_LISTADataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_LISTADataTable
        CadenaSQL = "SELECT P.PRESTAMO, TP.DESCRIPCION AS TIPO_PRESTAMO, P.FECHA_REGISTRO, P.RAZON_SOCIAL, MONEDA=CASE WHEN P.TIPO_MONEDA='1' THEN 'PEN' ELSE 'USD' END, " &
                    "P.CAPITAL, P.NUMERO_CUOTAS, " &
                    "VALOR_CUOTA=CASE WHEN P.VALOR_CUOTA=0 THEN ROUND(P.TOTAL_PRESTAMO/P.NUMERO_CUOTAS,2) ELSE P.VALOR_CUOTA END, " &
                    "P.TOTAL_PRESTAMO " &
                    "FROM FIN.PRESTAMOS AS P INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA=TP.EMPRESA AND P.TIPO_PRESTAMO=TP.CODIGO " &
                    "WHERE P.EMPRESA='" & pEmpresa & "' AND P.AGENCIA_REGISTRO='" & pAgencia & "' AND P.EJERCICIO='" & pEjercicio & "' AND P.MES='" & pMes & "' " &
                    IIf(pEstado = "TODOS", "", " AND P.ESTADO='" & pEstado & "' ") &
                    IIf(pEstado <> "V", "", " AND P.TOTAL_SALDO>0 ")
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamos(ByVal pCuentaComercial As entCuentaComercial, pEstado As String) As dsFinanciero.PRESTAMOS_LISTADataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_LISTADataTable
        CadenaSQL = "SELECT P.PRESTAMO, TP.DESCRIPCION AS TIPO_PRESTAMO, FECHA_REGISTRO, P.RAZON_SOCIAL, MONEDA=CASE WHEN P.TIPO_MONEDA='1' THEN 'PEN' ELSE 'USD' END, " &
                    "P.CAPITAL, P.NUMERO_CUOTAS, VALOR_CUOTA, TOTAL_PRESTAMO " &
                    "FROM FIN.PRESTAMOS AS P INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA=TP.EMPRESA AND P.TIPO_PRESTAMO=TP.CODIGO " &
                    "WHERE P.EMPRESA='" & pCuentaComercial.empresa & "' AND P.AGENCIA_REGISTRO='" & pCuentaComercial.agencia_registro &
                    "' AND P.TIPO_DOCUMENTO='" & pCuentaComercial.tipo_documento &
                    "' AND P.NRO_DOCUMENTO='" & pCuentaComercial.nro_documento &
                    IIf(pEstado = "TODOS", "' ", "' AND P.ESTADO='" & pEstado & "' ") &
                    IIf(pEstado <> "V", "", " AND P.TOTAL_SALDO>0 ")
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerPrestamo(ByVal pCobranza As dsFinanciero.COBRANZASDataTable) As dsFinanciero.PRESTAMOS_LISTADataTable
        Dim MyDT As New dsFinanciero.PRESTAMOS_LISTADataTable
        CadenaSQL = "SELECT P.PRESTAMO, TP.DESCRIPCION AS TIPO_PRESTAMO, P.FECHA_REGISTRO, P.RAZON_SOCIAL, MONEDA=CASE WHEN P.TIPO_MONEDA='1' THEN 'PEN' ELSE 'USD' END, " &
                    "P.CAPITAL, P.NUMERO_CUOTAS, " &
                    "VALOR_CUOTA=CASE WHEN P.VALOR_CUOTA=0 THEN ROUND(P.TOTAL_PRESTAMO/P.NUMERO_CUOTAS,2) ELSE P.VALOR_CUOTA END, " &
                    "P.TOTAL_PRESTAMO " &
                    "FROM FIN.PRESTAMOS AS P INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA=TP.EMPRESA AND P.TIPO_PRESTAMO=TP.CODIGO " &
                    "WHERE P.EMPRESA='" & pCobranza(0).EMPRESA & "' AND P.PRESTAMO='" & pCobranza(0).PRESTAMO & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranzaNueva() As dsFinanciero.COBRANZASDataTable
        Dim MyDT As New dsFinanciero.COBRANZASDataTable
        CadenaSQL = "SELECT EMPRESA=SPACE(1), COBRANZA=SPACE(1), PRESTAMO=SPACE(1), EJERCICIO=SPACE(1), MES=SPACE(1), TIPO=SPACE(1), TIPO_MONEDA_PAGO=SPACE(1), " &
                    "TIPO_CAMBIO_PAGO=0, IMPORTE_PAGO=0, IMPORTE=0, FECHA=GETDATE(), GLOSA=SPACE(1), FORMA_PAGO=SPACE(1), DINERO_RECIBIDO=0, DINERO_VUELTO_MN=0, " &
                    "RECIBO_INTERNO=SPACE(1), ESTADO=SPACE(1), AGENCIA_REGISTRO=SPACE(1), USUARIO_REGISTRO=SPACE(1), FECHA_REGISTRO=GETDATE(), AGENCIA_MODIFICA=SPACE(1), " &
                    "USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=GETDATE()  "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranzaProntoPagoNueva() As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable
        Dim MyDT As New dsFinanciero.COBRANZAS_PRONTO_PAGODataTable
        CadenaSQL = "SELECT EMPRESA=SPACE(1), COBRANZA=SPACE(1), PRESTAMO=SPACE(1),MESES_ACTUALES=0, MESES_ADICIONALES=0, PORCENTAJE_INTERES_ACUMULADO=0, " &
                    "INTERES_PAGAR=0, CAPITAL_INTERES_PAGAR=0, TOTAL_CUOTAS_PAGADAS=0, MORA_PAGAR=0, TOTAL_PRONTO_PAGO=0, AGENCIA_REGISTRO=SPACE(1), " &
                    "USUARIO_REGISTRO=SPACE(1), FECHA_REGISTRO=GETDATE(), AGENCIA_MODIFICA=SPACE(1), USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=GETDATE()  "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranzas(ByVal pEmpresa As String, ByVal pAgencia As String, ByVal pEjercicio As String, ByVal pMes As String, pTipo As String) As dsFinanciero.COBRANZAS_LISTADataTable
        Dim MyDT As New dsFinanciero.COBRANZAS_LISTADataTable
        CadenaSQL = "SELECT K.COBRANZA, TP.DESCRIPCION AS TIPO_PRESTAMO, K.FECHA_REGISTRO, P.RAZON_SOCIAL, CASE WHEN P.TIPO_MONEDA = '1' THEN 'PEN' ELSE 'USD' END AS MONEDA, K.IMPORTE " &
                    "FROM FIN.COBRANZAS AS K INNER JOIN FIN.PRESTAMOS AS P ON K.EMPRESA = P.EMPRESA AND K.PRESTAMO = P.PRESTAMO " &
                    "INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA = TP.EMPRESA AND P.TIPO_PRESTAMO = TP.CODIGO " &
                    "WHERE K.EMPRESA='" & pEmpresa & "' AND K.AGENCIA_REGISTRO='" & pAgencia & "' AND K.EJERCICIO='" & pEjercicio & "' AND K.MES='" & pMes & "' " &
                    IIf(pTipo = "TODOS", " ", " AND K.TIPO='" & pTipo & "' ") &
                    "ORDER BY K.COBRANZA DESC"
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranza(ByVal pEmpresa As String, ByVal pCobranza As String) As dsFinanciero.COBRANZASDataTable
        Dim MyDT As New dsFinanciero.COBRANZASDataTable
        CadenaSQL = "SELECT *  FROM FIN.COBRANZAS WHERE EMPRESA='" & pEmpresa & "' AND COBRANZA='" & pCobranza & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerCobranzaDetalles(ByVal pEmpresa As String, ByVal pCobranza As String) As dsFinanciero.COBRANZAS_DETALLESDataTable
        Dim MyDT As New dsFinanciero.COBRANZAS_DETALLESDataTable
        CadenaSQL = "SELECT * FROM FIN.COBRANZAS_DETALLES WHERE EMPRESA='" & pEmpresa & "' AND COBRANZA='" & pCobranza & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerProntoPago(ByVal pEmpresa As String, ByVal pCobranza As String) As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable
        Dim MyDT As New dsFinanciero.COBRANZAS_PRONTO_PAGODataTable
        CadenaSQL = "SELECT * FROM FIN.COBRANZAS_PRONTO_PAGO WHERE EMPRESA='" & pEmpresa & "' AND COBRANZA='" & pCobranza & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function GrabarPrestamo(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable, ByVal MyCuentaComercial As entCuentaComercial, Optional MyPrestamosRefinanciarCuotas As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable = Nothing) As dsFinanciero.PRESTAMOSDataTable
        Dim ExisteCliente As Boolean

        ExisteCliente = BuscarExisteCliente(MyCuentaComercial.empresa, MyCuentaComercial.tipo_documento.Trim, MyCuentaComercial.nro_documento.Trim)

        MyPrestamo(0).PRESTAMO = AsignarPrestamo()

        Try
            Using MySQLTransactionScope As New Transactions.TransactionScope
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    MySQLDbconnection.Open()
                    Using MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                        Call ActualizarCliente(ExisteCliente, MyCuentaComercial, MyPrestamo, MySQLCommand, MySQLDbconnection)
                        Call InsertarEncabezado(MyPrestamo, MySQLCommand)
                        Call InsertarDetalle(MyPrestamo, MyPrestamoCuotas, MySQLCommand)
                        If MyPrestamo(0).PRESTAMO_REFINANCIADO <> CUO_Nulo Then ActualizarPrestamoRefinanciado(MyPrestamo, MyPrestamosRefinanciarCuotas, MySQLCommand)
                    End Using
                End Using
                MySQLTransactionScope.Complete()
                Return MyPrestamo
            End Using

        Catch ex As Exception
            Throw New BusinessException(ERR1000 & ": " & ex.Message)
        End Try
    End Function

    Private Shared Function AsignarPrestamo() As String
        MySQLString = "SELECT ISNULL(MAX(PRESTAMO),'') AS NUEVO_CODIGO FROM FIN.PRESTAMOS WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "P00000000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 11)) + 1
                NewCode = "P" & Right("00000000000" & Correlativo.ToString, 11)
            End If
            Return NewCode
        End Using
    End Function

    Public Shared Function GrabarCliente(MyCuentaComercial As entCuentaComercial) As Boolean

        MySQLString = "UPDATE FIN.CLIENTES SET " &
                      "razon_social=@vRazon_social," &
                      "domicilio=@vDomicilio,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo,referencia=@vReferencia,telefono=@vTelefono," &
                      "telefono_otro=@vTelefono_otro,celular=@vCelular,email=@vEmail,fecha_nacimiento=@vFecha_nacimiento,sexo=@vSexo,estado_civil=@vEstado_civil," &
                      "nivel_educativo=@vNivel_educativo,ocupacion=@vOcupacion,direccion_trabajo=@vDireccion_trabajo," &
                      "referencia_trabajo=@vReferencia_trabajo,telefono_trabajo=@vTelefono_trabajo,saldo_pagar_mn=saldo_pagar_mn+@vSaldo_pagar_mn," &
                      "saldo_pagar_me=saldo_pagar_me+@vSaldo_pagar_me,afecto_igv=@vAfecto_igv,nombre_conviviente=@vNombre_conviviente," &
                      "agencia_modifica=@vAgencia_modifica,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                      "WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipo_documento AND Nro_Documento=@vNro_documento "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vRazon_social", MyCuentaComercial.razon_social)
                .AddWithValue("vDomicilio", MyCuentaComercial.domicilio)
                .AddWithValue("vDepartamento", MyCuentaComercial.departamento)
                .AddWithValue("vProvincia", MyCuentaComercial.provincia)
                .AddWithValue("vUbigeo", MyCuentaComercial.ubigeo)
                .AddWithValue("vReferencia", MyCuentaComercial.referencia)
                .AddWithValue("vTelefono", MyCuentaComercial.telefono)
                .AddWithValue("vTelefono_otro", MyCuentaComercial.telefono_otro)
                .AddWithValue("vCelular", MyCuentaComercial.celular)
                .AddWithValue("vEmail", MyCuentaComercial.email)
                .AddWithValue("vFecha_nacimiento", MyCuentaComercial.fecha_nacimiento)
                .AddWithValue("vSexo", MyCuentaComercial.sexo)
                .AddWithValue("vEstado_civil", MyCuentaComercial.estado_civil)
                .AddWithValue("vNivel_educativo", MyCuentaComercial.nivel_educativo)
                .AddWithValue("vOcupacion", MyCuentaComercial.ocupacion)
                .AddWithValue("vDireccion_trabajo", MyCuentaComercial.direccion_trabajo)
                .AddWithValue("vReferencia_trabajo", MyCuentaComercial.referencia_trabajo)
                .AddWithValue("vTelefono_trabajo", MyCuentaComercial.telefono_trabajo)
                .AddWithValue("vSaldo_pagar_mn", MyCuentaComercial.saldo_pagar_mn)
                .AddWithValue("vSaldo_pagar_me", MyCuentaComercial.saldo_pagar_me)
                .AddWithValue("vAfecto_igv", MyCuentaComercial.afecto_igv)
                .AddWithValue("vNombre_conviviente", MyCuentaComercial.nombre_conviviente)
                .AddWithValue("vEmpresa", MyCuentaComercial.empresa)
                .AddWithValue("vTipo_documento", MyCuentaComercial.tipo_documento.Trim)
                .AddWithValue("vNro_documento", MyCuentaComercial.nro_documento.Trim)
                .AddWithValue("vAgencia_modifica", MyCuentaComercial.agencia_modifica)
                .AddWithValue("vUsuario_modifica", MyCuentaComercial.usuario_modifica)
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
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Public Shared Function GrabarCompromiso(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, NumeroCuota As String, CompromisoFecha As Date, CompromisoComentario As String) As Boolean
        MySQLString = "UPDATE FIN.PRESTAMOS_CUOTAS SET COMPROMISO_FECHA=@vCompromiso_fecha, COMPROMISO_COMENTARIO=@vCompromiso_Comentario, AGENCIA_MODIFICA=@vAgencia_modifica, " &
                      "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                      "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND CUOTA=@vCuota "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vCompromiso_fecha", CompromisoFecha)
                .AddWithValue("vCompromiso_Comentario", CompromisoComentario)
                .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)

                .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
                .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                .AddWithValue("vCuota", NumeroCuota)

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
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Public Shared Function GrabarCobranza(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyPrestamoCuotasLista As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable, MyCobranza As dsFinanciero.COBRANZASDataTable) As dsFinanciero.COBRANZASDataTable
        Dim TotalPagoCuotas As Decimal

        MyCobranza(0).COBRANZA = AsignarCobranza()

        MySQLString = "INSERT INTO FIN.COBRANZAS " &
                      "(EMPRESA,COBRANZA,PRESTAMO,EJERCICIO, MES,TIPO,TIPO_MONEDA_PAGO,TIPO_CAMBIO_PAGO,IMPORTE_PAGO,IMPORTE,GLOSA," &
                      "FORMA_PAGO,DINERO_RECIBIDO,DINERO_VUELTO_MN,RECIBO_INTERNO,FECHA,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
                      "VALUES " &
                      "(@vEmpresa,@vCobranza,@vPrestamo,@vEjercicio,@vMes,@vTipo,@vTipo_moneda_pago,@vTipo_cambio_pago,@vImporte_pago,@vImporte,@vGlosa," &
                      "@vForma_pago,@vDinero_recibido,@vDinero_vuelto_mn,@vRecibo_interno,@vFecha,@vAgencia_registro,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyCobranza(0).EMPRESA)
                .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
                .AddWithValue("vPrestamo", MyCobranza(0).PRESTAMO)
                .AddWithValue("vEjercicio", MyCobranza(0).EJERCICIO)
                .AddWithValue("vMes", MyCobranza(0).MES)
                .AddWithValue("vTipo", MyCobranza(0).TIPO)
                .AddWithValue("vTipo_moneda_pago", MyCobranza(0).TIPO_MONEDA_PAGO)
                .AddWithValue("vTipo_cambio_pago", MyCobranza(0).TIPO_CAMBIO_PAGO)
                .AddWithValue("vImporte_pago", MyCobranza(0).IMPORTE_PAGO)
                .AddWithValue("vImporte", MyCobranza(0).IMPORTE)
                .AddWithValue("vGlosa", MyCobranza(0).GLOSA)
                .AddWithValue("vForma_pago", MyCobranza(0).FORMA_PAGO)
                .AddWithValue("vDinero_recibido", MyCobranza(0).DINERO_RECIBIDO)
                .AddWithValue("vDinero_vuelto_mn", MyCobranza(0).DINERO_VUELTO_MN)
                .AddWithValue("vRecibo_interno", MyCobranza(0).RECIBO_INTERNO)
                .AddWithValue("vFecha", MyCobranza(0).FECHA)
                .AddWithValue("vAgencia_registro", MyCobranza(0).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_registro", MyCobranza(0).USUARIO_REGISTRO)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLString = "INSERT INTO FIN.COBRANZAS_DETALLES " & _
                              "(Empresa,Cobranza,Prestamo,Concepto,Cuota,Valor_cuota,Saldo_cuota,Dias_mora,Mora,Cuota_pago,Mora_pago,Total_pago," &
                              "Fecha_pago,Compromiso_fecha,Compromiso_comentario,Agencia_registro,Usuario_registro) " &
                              "VALUES (" &
                              "@vEmpresa,@vCobranza,@vPrestamo,@vConcepto,@vCuota,@vValor_cuota,@vSaldo_cuota,@vDias_mora,@vMora,@vCuota_pago,@vMora_pago,@vTotal_pago," &
                              "@vFecha_pago,@vCompromiso_fecha,@vCompromiso_comentario,@vAgencia_registro,@vUsuario_registro) "

                If MyCobranza(0).TIPO = "CR" Then
                    For FilaDetalle As Integer = 0 To MyPrestamoCuotasLista.Rows.Count - 1
                        If MyPrestamoCuotasLista(FilaDetalle).SELECCIONAR = 1 Then
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySQLString
                            MySQLCommand.Parameters.Clear()

                            With MyPrestamoCuotasLista(FilaDetalle)
                                If .IsNull("FECHA_PAGO") Then .FECHA_PAGO = FechaNulo
                                If .IsNull("COMPROMISO_FECHA") Then .COMPROMISO_FECHA = FechaNulo
                                If .IsNull("COMPROMISO_COMENTARIO") Then .COMPROMISO_COMENTARIO = Space(1)
                            End With

                            With MySQLCommand.Parameters
                                .AddWithValue("vEmpresa", MyCobranza(0).EMPRESA)
                                .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
                                .AddWithValue("vPrestamo", MyCobranza(0).PRESTAMO)
                                .AddWithValue("vConcepto", "PC")
                                .AddWithValue("vCuota", MyPrestamoCuotasLista(FilaDetalle).NUMERO_CUOTA)
                                .AddWithValue("vValor_cuota", MyPrestamoCuotasLista(FilaDetalle).VALOR_CUOTA)
                                .AddWithValue("vSaldo_cuota", MyPrestamoCuotasLista(FilaDetalle).SALDO_CUOTA)
                                .AddWithValue("vDias_mora", MyPrestamoCuotasLista(FilaDetalle).DIAS_MORA)
                                .AddWithValue("vMora", MyPrestamoCuotasLista(FilaDetalle).MORA)
                                .AddWithValue("vCuota_pago", MyPrestamoCuotasLista(FilaDetalle).CUOTA_PAGO)
                                .AddWithValue("vMora_pago", MyPrestamoCuotasLista(FilaDetalle).MORA_PAGO)
                                .AddWithValue("vTotal_pago", MyPrestamoCuotasLista(FilaDetalle).TOTAL_PAGO)
                                .AddWithValue("vFecha_pago", MyPrestamoCuotasLista(FilaDetalle).FECHA_PAGO)
                                .AddWithValue("vCompromiso_fecha", MyPrestamoCuotasLista(FilaDetalle).COMPROMISO_FECHA)
                                .AddWithValue("vCompromiso_comentario", MyPrestamoCuotasLista(FilaDetalle).COMPROMISO_COMENTARIO)
                                .AddWithValue("vAgencia_registro", MyCobranza(0).AGENCIA_REGISTRO)
                                .AddWithValue("vUsuario_registro", MyCobranza(0).USUARIO_REGISTRO)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MySQLString_1 = "UPDATE FIN.PRESTAMOS_CUOTAS SET FECHA_PAGO=@vFecha_pago, SALDO_CUOTA=SALDO_CUOTA-@vCuota_pago, MORA=MORA+@vMora_pago," &
                                            "ESTADO=CASE WHEN SALDO_CUOTA-@vCuota_pago=0 THEN 'C' ELSE ESTADO END, AGENCIA_MODIFICA=@vAgencia_modifica," &
                                            "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                            "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND CUOTA=@vCuota "

                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySQLString_1
                            MySQLCommand.Parameters.Clear()
                            With MySQLCommand.Parameters

                                .AddWithValue("vFecha_pago", MyFechaServidor.Date)
                                .AddWithValue("vCuota_pago", MyPrestamoCuotasLista(FilaDetalle).CUOTA_PAGO)
                                .AddWithValue("vMora_pago", MyPrestamoCuotasLista(FilaDetalle).MORA_PAGO)
                                .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                                .AddWithValue("vEmpresa", MyUsuario.empresa)
                                .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                                .AddWithValue("vCuota", MyPrestamoCuotasLista(FilaDetalle).NUMERO_CUOTA)
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            TotalPagoCuotas = TotalPagoCuotas + MyPrestamoCuotasLista(FilaDetalle).CUOTA_PAGO
                        End If
                    Next

                    MySQLString_1 = "UPDATE FIN.PRESTAMOS SET TOTAL_SALDO=@vTotal_saldo, ESTADO=@vEstado, AGENCIA_MODIFICA=@vAgencia_modifica," &
                                    "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                    "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo "

                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString_1
                    MySQLCommand.Parameters.Clear()
                    With MySQLCommand.Parameters

                        .AddWithValue("vTotal_saldo", MyPrestamo(0).TOTAL_SALDO)
                        .AddWithValue("vEstado", MyPrestamo(0).ESTADO)
                        .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                        .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
                        .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                    End With
                    MySQLCommand.ExecuteNonQuery()

                    MySQLString_2 = "UPDATE FIN.CLIENTES SET SALDO_PAGAR_MN=SALDO_PAGAR_MN-@vSaldo_pagar_mn, SALDO_PAGAR_ME=SALDO_PAGAR_ME-@vSaldo_pagar_me, " &
                                    "AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                    "WHERE EMPRESA=@vEmpresa AND TIPO_DOCUMENTO=@vTipo_documento AND NRO_DOCUMENTO=@vNro_documento "

                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString_2
                    MySQLCommand.Parameters.Clear()
                    With MySQLCommand.Parameters
                        If MyPrestamo(0).TIPO_MONEDA = "1" Then
                            .AddWithValue("vSaldo_pagar_mn", TotalPagoCuotas)
                            .AddWithValue("vSaldo_pagar_me", 0)
                        Else
                            .AddWithValue("vSaldo_pagar_mn", 0)
                            .AddWithValue("vSaldo_pagar_me", TotalPagoCuotas)
                        End If
                        .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                        .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        .AddWithValue("vEmpresa", MyUsuario.empresa)
                        .AddWithValue("vTipo_documento", MyPrestamo(0).TIPO_DOCUMENTO)
                        .AddWithValue("vNro_documento", MyPrestamo(0).NRO_DOCUMENTO)
                    End With
                    MySQLCommand.ExecuteNonQuery()

                Else
                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString
                    MySQLCommand.Parameters.Clear()

                    With MySQLCommand.Parameters
                        .AddWithValue("vEmpresa", MyCobranza(0).EMPRESA)
                        .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
                        .AddWithValue("vPrestamo", MyCobranza(0).PRESTAMO)
                        .AddWithValue("vConcepto", MyCobranza(0).TIPO)
                        .AddWithValue("vCuota", "000")
                        .AddWithValue("vValor_cuota", 0)
                        .AddWithValue("vSaldo_cuota", 0)
                        .AddWithValue("vDias_mora", 0)
                        .AddWithValue("vMora", 0)
                        .AddWithValue("vCuota_pago", MyCobranza(0).IMPORTE)
                        .AddWithValue("vMora_pago", 0)
                        .AddWithValue("vTotal_pago", MyCobranza(0).IMPORTE)
                        .AddWithValue("vFecha_pago", MyCobranza(0).FECHA)
                        .AddWithValue("vCompromiso_fecha", MyCobranza(0).FECHA)
                        .AddWithValue("vCompromiso_comentario", MyCobranza(0).GLOSA)
                        .AddWithValue("vAgencia_registro", MyCobranza(0).AGENCIA_REGISTRO)
                        .AddWithValue("vUsuario_registro", MyCobranza(0).USUARIO_REGISTRO)
                    End With
                    MySQLCommand.ExecuteNonQuery()
                End If

                MySQLTransaction.Commit()

                Return MyCobranza
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Public Shared Function ActualizarCobranza(MyCobranza As dsFinanciero.COBRANZASDataTable) As Boolean
        MySQLString = "UPDATE FIN.COBRANZAS SET " &
                      "FORMA_PAGO=@vForma_pago,RECIBO_INTERNO=@vRecibo_interno,AGENCIA_MODIFICA=@vAgencia_modifica,USUARIO_MODIFICA=@vUsuario_modifica,FECHA_MODIFICA=GETDATE() " &
                      "WHERE EMPRESA=@vEmpresa AND COBRANZA=@vCobranza "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vForma_pago", MyCobranza(0).FORMA_PAGO)
                .AddWithValue("vRecibo_interno", MyCobranza(0).RECIBO_INTERNO)
                .AddWithValue("vAgencia_modifica", MyCobranza(0).AGENCIA_MODIFICA)
                .AddWithValue("vUsuario_modifica", MyCobranza(0).USUARIO_MODIFICA)
                .AddWithValue("vEmpresa", MyCobranza(0).EMPRESA)
                .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
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
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Public Shared Function GrabarCobranzaProntoPago(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyCobranza As dsFinanciero.COBRANZASDataTable, ByVal MyCobranzaProntoPago As dsFinanciero.COBRANZAS_PRONTO_PAGODataTable) As dsFinanciero.COBRANZASDataTable
        Dim DeudaCliente As New dsFinanciero.DEUDA_CLIENTEDataTable
        Dim DeudaMN As Decimal = 0
        Dim DeudaME As Decimal = 0

        MyCobranza(0).COBRANZA = AsignarCobranza()

        CadenaSQL = "SELECT P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, C.RAZON_SOCIAL AS CLIENTE, P.TIPO_MONEDA, SUM(P.TOTAL_SALDO) AS DEUDA_ACTUAL, " &
                    "COUNT(*) AS NRO_PRESTAMOS, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL " &
                    "FROM FIN.PRESTAMOS AS P " &
                    "INNER JOIN FIN.CLIENTES AS C ON P.EMPRESA = C.EMPRESA AND P.TIPO_DOCUMENTO = C.TIPO_DOCUMENTO AND P.NRO_DOCUMENTO = C.NRO_DOCUMENTO " &
                    "INNER JOIN COM.AGENCIAS AS A ON P.EMPRESA = A.EMPRESA AND P.AGENCIA_REGISTRO = A.AGENCIA " &
                    "WHERE P.EMPRESA='" & MyPrestamo(0).EMPRESA &
                    "' AND P.TIPO_DOCUMENTO='" & MyPrestamo(0).TIPO_DOCUMENTO &
                    "' AND P.NRO_DOCUMENTO='" & MyPrestamo(0).NRO_DOCUMENTO.Trim & "' AND P.ESTADO = 'V' " &
                    "GROUP BY P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, P.TIPO_MONEDA, C.RAZON_SOCIAL, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL "

        Call ObtenerDataTableSQL(CadenaSQL, DeudaCliente)

        If DeudaCliente.Rows.Count <> 0 Then
            For NFila As Integer = 0 To DeudaCliente.Rows.Count - 1
                If DeudaCliente(NFila).TIPO_MONEDA = "1" Then
                    DeudaMN = DeudaCliente(NFila).DEUDA_ACTUAL
                Else
                    DeudaME = DeudaCliente(NFila).DEUDA_ACTUAL
                End If
            Next
        End If

        MySQLString = "INSERT INTO FIN.COBRANZAS " &
                      "(EMPRESA,COBRANZA,PRESTAMO,EJERCICIO, MES,TIPO,TIPO_MONEDA_PAGO,TIPO_CAMBIO_PAGO,IMPORTE_PAGO,IMPORTE,GLOSA," &
                      "FORMA_PAGO,DINERO_RECIBIDO,DINERO_VUELTO_MN,RECIBO_INTERNO,FECHA,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
                      "VALUES " &
                      "(@vEmpresa,@vCobranza,@vPrestamo,@vEjercicio,@vMes,@vTipo,@vTipo_moneda_pago,@vTipo_cambio_pago,@vImporte_pago,@vImporte,@vGlosa," &
                      "@vForma_pago,@vDinero_recibido,@vDinero_vuelto_mn,@vRecibo_interno,@vFecha,@vAgencia_registro,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyCobranza(0).EMPRESA)
                .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
                .AddWithValue("vPrestamo", MyCobranza(0).PRESTAMO)
                .AddWithValue("vEjercicio", MyCobranza(0).EJERCICIO)
                .AddWithValue("vMes", MyCobranza(0).MES)
                .AddWithValue("vTipo", MyCobranza(0).TIPO)
                .AddWithValue("vTipo_moneda_pago", MyCobranza(0).TIPO_MONEDA_PAGO)
                .AddWithValue("vTipo_cambio_pago", MyCobranza(0).TIPO_CAMBIO_PAGO)
                .AddWithValue("vImporte_pago", MyCobranza(0).IMPORTE_PAGO)
                .AddWithValue("vImporte", MyCobranza(0).IMPORTE)
                .AddWithValue("vGlosa", MyCobranza(0).GLOSA)
                .AddWithValue("vForma_pago", MyCobranza(0).FORMA_PAGO)
                .AddWithValue("vDinero_recibido", MyCobranza(0).DINERO_RECIBIDO)
                .AddWithValue("vDinero_vuelto_mn", MyCobranza(0).DINERO_VUELTO_MN)
                .AddWithValue("vRecibo_interno", MyCobranza(0).RECIBO_INTERNO)
                .AddWithValue("vFecha", MyCobranza(0).FECHA)
                .AddWithValue("vAgencia_registro", MyCobranza(0).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_registro", MyCobranza(0).USUARIO_REGISTRO)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLString = "INSERT INTO FIN.COBRANZAS_PRONTO_PAGO " &
                              "(EMPRESA,COBRANZA,PRESTAMO,MESES_ACTUALES,MESES_ADICIONALES,PORCENTAJE_INTERES_ACUMULADO,INTERES_PAGAR,CAPITAL_INTERES_PAGAR," &
                              "TOTAL_CUOTAS_PAGADAS,MORA_PAGAR,TOTAL_PRONTO_PAGO,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
                              "VALUES " &
                              "(@vEmpresa,@vCobranza,@vPrestamo,@vMeses_actuales,@vMeses_adicionales,@vPorcentaje_interes_acumulado,@vInteres_pagar,@vCapital_interes_pagar," &
                              "@vTotal_cuotas_pagadas,@vMora_pagar,@vTotal_pronto_pago,@vAgencia_registro,@vUsuario_registro) "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQLString
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", MyCobranzaProntoPago(0).EMPRESA)
                    .AddWithValue("vCobranza", MyCobranza(0).COBRANZA)
                    .AddWithValue("vPrestamo", MyCobranzaProntoPago(0).PRESTAMO)
                    .AddWithValue("vMeses_actuales", MyCobranzaProntoPago(0).MESES_ACTUALES)
                    .AddWithValue("vMeses_adicionales", MyCobranzaProntoPago(0).MESES_ADICIONALES)
                    .AddWithValue("vPorcentaje_interes_acumulado", MyCobranzaProntoPago(0).PORCENTAJE_INTERES_ACUMULADO)
                    .AddWithValue("vInteres_pagar", MyCobranzaProntoPago(0).INTERES_PAGAR)
                    .AddWithValue("vCapital_interes_pagar", MyCobranzaProntoPago(0).CAPITAL_INTERES_PAGAR)
                    .AddWithValue("vTotal_cuotas_pagadas", MyCobranzaProntoPago(0).TOTAL_CUOTAS_PAGADAS)
                    .AddWithValue("vMora_pagar", MyCobranzaProntoPago(0).MORA_PAGAR)
                    .AddWithValue("vTotal_pronto_pago", MyCobranzaProntoPago(0).TOTAL_PRONTO_PAGO)
                    .AddWithValue("vAgencia_registro", MyCobranzaProntoPago(0).AGENCIA_REGISTRO)
                    .AddWithValue("vUsuario_registro", MyCobranzaProntoPago(0).USUARIO_REGISTRO)
                End With
                MySQLCommand.ExecuteNonQuery()

                MySQLString_1 = "UPDATE FIN.PRESTAMOS SET INDICA_PRONTO_PAGO='SI', TOTAL_SALDO=0, ESTADO='C', AGENCIA_MODIFICA=@vAgencia_modifica," &
                                "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo "
                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQLString_1
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
                    .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                End With
                MySQLCommand.ExecuteNonQuery()

                MySQLString_2 = "UPDATE FIN.PRESTAMOS_CUOTAS SET FECHA_PAGO=@vFecha_pago, MORA=UTI.CALCULAR_MORA(FECHA_VENCIMIENTO,SALDO_CUOTA,@vTasa_morosidad), " &
                                "COMPROMISO_COMENTARIO='PRONTO PAGO', ESTADO='C', " &
                                "AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND SALDO_CUOTA<>0 "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQLString_2
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("vFecha_pago", MyFechaServidor.Date)
                    .AddWithValue("vTasa_morosidad", MyPrestamo(0).TASA_MOROSIDAD)
                    .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                End With
                MySQLCommand.ExecuteNonQuery()

                MySQLString_3 = "UPDATE FIN.CLIENTES SET SALDO_PAGAR_MN=@vSaldo_pagar_mn, SALDO_PAGAR_ME=@vSaldo_pagar_me, " &
                                "AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                                "WHERE EMPRESA=@vEmpresa AND TIPO_DOCUMENTO=@vTipo_documento AND NRO_DOCUMENTO=@vNro_documento "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQLString_3
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    If MyPrestamo(0).TIPO_MONEDA = "1" Then
                        .AddWithValue("vSaldo_pagar_mn", DeudaMN - MyPrestamo(0).TOTAL_SALDO)
                        .AddWithValue("vSaldo_pagar_me", DeudaME)
                    Else
                        .AddWithValue("vSaldo_pagar_mn", DeudaMN)
                        .AddWithValue("vSaldo_pagar_me", DeudaME - MyPrestamo(0).TOTAL_SALDO)
                    End If
                    .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vTipo_documento", MyPrestamo(0).TIPO_DOCUMENTO)
                    .AddWithValue("vNro_documento", MyPrestamo(0).NRO_DOCUMENTO)
                End With
                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()

                Return MyCobranza
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Private Shared Function AsignarCobranza() As String
        MySQLString = "SELECT ISNULL(MAX(COBRANZA),'') AS NUEVO_CODIGO FROM FIN.COBRANZAS WHERE EMPRESA='" & MyUsuario.empresa & "' AND " &
                      "EJERCICIO='" & MyUsuario.ejercicio & "' AND " &
                      "MES='" & MyUsuario.mes.ToString("00") & "' AND " &
                      "AGENCIA_REGISTRO='A0000" & MyUsuario.almacen & "' "
        Dim Correlativo As Long
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLDbconnection.Open()
            Dim NewCode As String = MySQLCommand.ExecuteScalar
            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "K" & MyUsuario.almacen & MyUsuario.periodo_actual.Substring(2, 4) & "0001"
            Else
                Correlativo = CLng(NewCode.Substring(8, 4)) + 1
                NewCode = "K" & MyUsuario.almacen & MyUsuario.periodo_actual.Substring(2, 4) & Right("0000" & Correlativo.ToString, 4)
            End If
            Return NewCode
        End Using
    End Function

    Private Shared Function BuscarExisteCliente(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As Boolean
        MySQLString = "SELECT COUNT(*) FROM FIN.CLIENTES WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipoDocumento AND Nro_Documento=@vNumeroDocumento "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vTipoDocumento", pTipoDocumento)
            MySQLCommand.Parameters.AddWithValue("vNumeroDocumento", pNumeroDocumento)
            MySQLDbconnection.Open()
            MyCount = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function ObtenerCliente(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As entCuentaComercial
        If BuscarExisteCliente(pEmpresa, pTipoDocumento, pNumeroDocumento) Then
            CadenaSQL = "SELECT * FROM FIN.CLIENTES " &
                        "WHERE EMPRESA='" & pEmpresa & "' AND TIPO_DOCUMENTO='" & pTipoDocumento & "' AND NRO_DOCUMENTO='" & pNumeroDocumento.Trim & "' "
            Return ObtenerCliente(New entCuentaComercial, CadenaSQL)
        Else
            Return New entCuentaComercial
        End If
    End Function

    Private Shared Function ObtenerCliente(ByVal cCuentaComercial As entCuentaComercial, ByVal MySQL As String) As entCuentaComercial
        Dim MyDT As New dsFinanciero.CLIENTESDataTable
        Call ObtenerDataTableSQL(MySQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaComercial
                .empresa = MyDT(0).EMPRESA
                .tipo_documento = MyDT(0).TIPO_DOCUMENTO.Trim
                .nro_documento = MyDT(0).NRO_DOCUMENTO
                .razon_social = MyDT(0).RAZON_SOCIAL
                .domicilio = MyDT(0).DOMICILIO
                .referencia = MyDT(0).REFERENCIA
                .departamento = MyDT(0).DEPARTAMENTO
                .provincia = MyDT(0).PROVINCIA
                .ubigeo = MyDT(0).UBIGEO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .telefono_otro = MyDT(0).TELEFONO_OTRO
                .celular = MyDT(0).CELULAR
                .email = MyDT(0).EMAIL
                .direccion_trabajo = MyDT(0).DIRECCION_TRABAJO
                .referencia_trabajo = MyDT(0).REFERENCIA_TRABAJO
                .telefono_trabajo = MyDT(0).TELEFONO_TRABAJO
                .linea_credito_mn = MyDT(0).LINEA_CREDITO_MN
                .linea_credito_me = MyDT(0).LINEA_CREDITO_ME
                .saldo_pagar_mn = MyDT(0).SALDO_PAGAR_MN
                .saldo_pagar_me = MyDT(0).SALDO_PAGAR_ME
                .vigencia_credito = MyDT(0).VIGENCIA_CREDITO
                .afecto_igv = MyDT(0).AFECTO_IGV
                .apellido_paterno = MyDT(0).APELLIDO_PATERNO
                .apellido_materno = MyDT(0).APELLIDO_MATERNO
                .apellido_casada = MyDT(0).APELLIDO_CASADA
                .nombres = MyDT(0).NOMBRES
                If Not MyDT(0).IsNull("FECHA_NACIMIENTO") Then .fecha_nacimiento = MyDT(0).FECHA_NACIMIENTO
                .sexo = MyDT(0).SEXO
                .estado_civil = MyDT(0).ESTADO_CIVIL
                .nivel_educativo = MyDT(0).NIVEL_EDUCATIVO
                .ocupacion = MyDT(0).OCUPACION

                .nombre_conviviente = MyDT(0).NOMBRE_CONVIVIENTE

                .situacion_crediticia = MyDT(0).SITUACION_CREDITICIA
                .calificacion = MyDT(0).CALIFICACION
                .indica_preferente = MyDT(0).INDICA_PREFERENTE
                .indica_fallecido = MyDT(0).INDICA_FALLECIDO
                .exige_garante = MyDT(0).EXIGE_GARANTE
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .comentario = MyDT(0).COMENTARIO
                .usuario_web = MyDT(0).USUARIO_WEB
                .clave_web = MyDT(0).CLAVE_WEB
                .codigo_antiguo = MyDT(0).CODIGO_ANTIGUO
                .item_flujo = MyDT(0).ITEM_FLUJO

                .estado = MyDT(0).ESTADO
                .agencia_registro = MyDT(0).AGENCIA_REGISTRO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("AGENCIA_MODIFICA") Then .agencia_modifica = MyDT(0).AGENCIA_MODIFICA
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
                If Not MyDT(0).IsNull("USUARIO_APROBACION") Then .usuario_aprobacion = MyDT(0).USUARIO_APROBACION
                If Not MyDT(0).IsNull("FECHA_APROBACION") Then .fecha_aprobacion = MyDT(0).FECHA_APROBACION

            End With
        End If
        Return cCuentaComercial
    End Function

    Public Shared Function GrabarReprogramacionCuotas(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable) As Boolean

        MySQLString = "INSERT INTO FIN.CUOTAS_REPROGRAMADAS " &
        "(EMPRESA, PRESTAMO, CUOTA, EJERCICIO, MES, FECHA_VENCIMIENTO, AMORTIZACION, INTERES, IMPUESTO, VALOR_CUOTA, FECHA_PAGO, SALDO_CUOTA, MORA, COMPROMISO_FECHA, " &
        "COMPROMISO_COMENTARIO, ESTADO, AGENCIA_REGISTRO, USUARIO_REGISTRO, FECHA_REGISTRO, AGENCIA_MODIFICA, USUARIO_MODIFICA, FECHA_MODIFICA) " &
        "SELECT EMPRESA, PRESTAMO, CUOTA, EJERCICIO, MES, FECHA_VENCIMIENTO, AMORTIZACION, INTERES, IMPUESTO, VALOR_CUOTA, FECHA_PAGO, SALDO_CUOTA, MORA, COMPROMISO_FECHA, " &
        "COMPROMISO_COMENTARIO, ESTADO, AGENCIA_REGISTRO, USUARIO_REGISTRO, FECHA_REGISTRO, AGENCIA_MODIFICA, USUARIO_MODIFICA, FECHA_MODIFICA " &
        "FROM FIN.PRESTAMOS_CUOTAS " &
        "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND SALDO_CUOTA>0 AND ESTADO='V' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
                .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLString_2 = "UPDATE FIN.PRESTAMOS_CUOTAS SET " &
                                "Ejercicio=@vEjercicio,Mes=@vMes,Fecha_vencimiento=@vFecha_vencimiento,Fecha_Pago=@vFecha_Pago,Mora=0,Compromiso_fecha=@vCompromiso_fecha," &
                                "Compromiso_comentario=SPACE(1),Agencia_registro=@vAgencia_registro," &
                                "Usuario_registro=@vUsuario_registro,Fecha_registro=GETDATE(),Agencia_modifica=SPACE(1),Usuario_modifica=SPACE(1),Fecha_modifica=GETDATE() " &
                                "WHERE Empresa=@vEmpresa AND Prestamo=@vPrestamo AND Cuota=@vCuota "

                For FilaDetalle As Integer = 0 To MyPrestamoCuotas.Rows.Count - 1
                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySQLString_2
                    MySQLCommand.Parameters.Clear()

                    With MySQLCommand.Parameters
                        .AddWithValue("vEjercicio", MyPrestamoCuotas(FilaDetalle).EJERCICIO)
                        .AddWithValue("vMes", MyPrestamoCuotas(FilaDetalle).MES)
                        .AddWithValue("vFecha_vencimiento", MyPrestamoCuotas(FilaDetalle).FECHA_VENCIMIENTO)
                        .AddWithValue("vFecha_pago", FechaNulo)
                        .AddWithValue("vCompromiso_fecha", FechaNulo)
                        .AddWithValue("vAgencia_registro", MyPrestamoCuotas(FilaDetalle).AGENCIA_REGISTRO)
                        .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                        .AddWithValue("vEmpresa", MyUsuario.empresa)
                        .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                        .AddWithValue("vCuota", MyPrestamoCuotas(FilaDetalle).CUOTA)
                    End With
                    MySQLCommand.ExecuteNonQuery()
                Next

                MySQLTransaction.Commit()

                Return True
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using

    End Function

    Public Shared Function ObtenerCobranzaDiaria(ByVal pFecha As Date, pAgencia As String) As dsFinanciero.COBRANZAS_DIARIASDataTable
        Dim FechaInicial As String
        Dim FechaFinal As String

        FechaInicial = pFecha.ToString("yyyy-dd-MM 00:00:00")
        FechaFinal = DateAdd(DateInterval.Day, 1, pFecha).ToString("yyyy-dd-MM 23:59:00")

        MySQLString = "SELECT P.RAZON_SOCIAL,P.PRESTAMO,CUOTA='999',CONCEPTO=H.TIPO,H.IMPORTE, CUOTA_PAGO=0,MORA_PAGO=0,TOTAL_PAGO=H.IMPORTE_PAGO,H.FECHA_REGISTRO " &
                      "FROM FIN.COBRANZAS AS H INNER JOIN FIN.PRESTAMOS AS P ON H.EMPRESA = P.EMPRESA AND H.PRESTAMO = P.PRESTAMO " &
                      "WHERE H.EMPRESA = @vEmpresa AND H.ESTADO = 'V' AND H.AGENCIA_REGISTRO = @vAgencia_registro AND H.FECHA_REGISTRO BETWEEN CONVERT(DATETIME, '" & FechaInicial & "') AND CONVERT(DATETIME, '" & FechaFinal & "')  " & _
                      "ORDER BY H.FECHA_REGISTRO "

        Dim MyDT As New dsFinanciero.COBRANZAS_DIARIASDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAgencia_registro", pAgencia)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

#Region "Insertar Prestamos"

    Private Shared Sub InsertarEncabezado(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString = "INSERT INTO FIN.PRESTAMOS " &
        "(EMPRESA,PRESTAMO,EJERCICIO,MES,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,DOMICILIO,TIPO_PRESTAMO,FORMA_PAGO,FECHA_DESEMBOLSO,TIPO_MONEDA,CAPITAL,NUMERO_CUOTAS," &
        "TASA_INTERES,TASA_MOROSIDAD,PORCENTAJE_IMPUESTO,VALOR_CUOTA,TOTAL_INTERES,TOTAL_IMPUESTO,TOTAL_PRESTAMO,CUOTA_INICIAL,CUOTA_INICIAL_PAGADA, " &
        "CUOTA_INICIAL_SALDO_FECHA_PAGO,TOTAL_SALDO,FECHA_PRIMER_PAGO,MONTO_SOLICITADO,VENTA,PROFORMA,PRESTAMO_REFINANCIADO,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
        "VALUES " &
        "(@vEmpresa,@vPrestamo,@vEjercicio,@vMes,@vTipo_documento,@vNro_documento,@vRazon_social,@vDomicilio,@vTipo_prestamo,@vForma_pago,@vFecha_desembolso,@vTipo_moneda," &
        "@vCapital,@vNumero_cuotas,@vTasa_interes,@vTasa_Morosidad,@vPorcentaje_impuesto,@vValor_Cuota,@vTotal_interes,@vTotal_impuesto,@vTotal_prestamo,@vCuota_inicial,@vCuota_inicial_pagada," &
        "@vCuota_inicial_saldo_fecha_pago,@vTotal_saldo,@vFecha_primer_pago,@vMonto_solicitado,@vVenta,@vProforma,@vPrestamo_refinanciado,@vAgencia_registro,@vUsuario_registro) "

        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString
        MySQLCommand.Parameters.Clear()

        With MySQLCommand.Parameters
            .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
            .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
            .AddWithValue("vEjercicio", MyPrestamo(0).EJERCICIO)
            .AddWithValue("vMes", MyPrestamo(0).MES)
            .AddWithValue("vTipo_documento", MyPrestamo(0).TIPO_DOCUMENTO)
            .AddWithValue("vNro_documento", MyPrestamo(0).NRO_DOCUMENTO)
            .AddWithValue("vRazon_social", MyPrestamo(0).RAZON_SOCIAL)
            .AddWithValue("vDomicilio", MyPrestamo(0).DOMICILIO)
            .AddWithValue("vTipo_prestamo", MyPrestamo(0).TIPO_PRESTAMO)
            .AddWithValue("vForma_pago", MyPrestamo(0).FORMA_PAGO)
            .AddWithValue("vFecha_desembolso", MyPrestamo(0).FECHA_DESEMBOLSO)
            .AddWithValue("vTipo_moneda", MyPrestamo(0).TIPO_MONEDA)
            .AddWithValue("vCapital", MyPrestamo(0).CAPITAL)
            .AddWithValue("vNumero_cuotas", MyPrestamo(0).NUMERO_CUOTAS)
            .AddWithValue("vTasa_interes", MyPrestamo(0).TASA_INTERES)
            .AddWithValue("vTasa_Morosidad", MyPrestamo(0).TASA_MOROSIDAD)
            .AddWithValue("vPorcentaje_impuesto", MyPrestamo(0).PORCENTAJE_IMPUESTO)
            .AddWithValue("vValor_Cuota", MyPrestamo(0).VALOR_CUOTA)
            .AddWithValue("vTotal_interes", MyPrestamo(0).TOTAL_INTERES)
            .AddWithValue("vTotal_impuesto", MyPrestamo(0).TOTAL_IMPUESTO)
            .AddWithValue("vTotal_Prestamo", MyPrestamo(0).TOTAL_PRESTAMO)
            .AddWithValue("vCuota_inicial", MyPrestamo(0).CUOTA_INICIAL)
            .AddWithValue("vCuota_inicial_pagada", MyPrestamo(0).CUOTA_INICIAL_PAGADA)
            .AddWithValue("vCuota_inicial_saldo_fecha_pago", MyPrestamo(0).CUOTA_INICIAL_SALDO_FECHA_PAGO)
            .AddWithValue("vTotal_saldo", MyPrestamo(0).TOTAL_SALDO)
            .AddWithValue("vFecha_primer_pago", MyPrestamo(0).FECHA_PRIMER_PAGO)
            .AddWithValue("vMonto_solicitado", MyPrestamo(0).MONTO_SOLICITADO)
            .AddWithValue("vVenta", MyPrestamo(0).VENTA)
            .AddWithValue("vProforma", MyPrestamo(0).PROFORMA)
            .AddWithValue("vPrestamo_refinanciado", MyPrestamo(0).PRESTAMO_REFINANCIADO)
            .AddWithValue("vAgencia_registro", MyPrestamo(0).AGENCIA_REGISTRO)
            .AddWithValue("vUsuario_registro", MyPrestamo(0).USUARIO_REGISTRO)
        End With
        MySQLCommand.ExecuteNonQuery()

        If MyPrestamo(0).VENTA <> CUO_Nulo Then
            MySQLString_1 = "UPDATE COM.VENTAS SET INDICA_FINANCIADO='SI', AGENCIA_MODIFICA=@vAgencia_modifica," &
                            "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                            "WHERE EMPRESA=@vEmpresa AND VENTA=@vVenta "

            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString_1
            MySQLCommand.Parameters.Clear()
            With MySQLCommand.Parameters
                .AddWithValue("vAgencia_modifica", MyPrestamo(0).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vVenta", MyPrestamo(0).VENTA)
            End With
            MySQLCommand.ExecuteNonQuery()
        End If

        If MyPrestamo(0).PROFORMA <> CUO_Nulo Then
            MySQLString_1 = "UPDATE FIN.PROFORMAS SET ESTADO='A', AGENCIA_MODIFICA=@vAgencia_modifica," &
                            "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                            "WHERE EMPRESA=@vEmpresa AND PROFORMA=@vProforma "

            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString_1
            MySQLCommand.Parameters.Clear()
            With MySQLCommand.Parameters
                .AddWithValue("vAgencia_modifica", MyPrestamo(0).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vProforma", MyPrestamo(0).PROFORMA)
            End With
            MySQLCommand.ExecuteNonQuery()
        End If

    End Sub

    Private Shared Sub InsertarDetalle(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyPrestamoCuotas As dsFinanciero.PRESTAMOS_CUOTASDataTable, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString_2 = "INSERT INTO FIN.PRESTAMOS_CUOTAS " & _
                        "(empresa,prestamo,cuota,ejercicio,mes,fecha_vencimiento,amortizacion,interes,impuesto,valor_cuota,mora,fecha_pago,saldo_cuota,agencia_registro,usuario_registro) " &
                        "VALUES (" &
                        "@vEmpresa,@vPrestamo,@vCuota,@vEjercicio,@vMes,@vFecha_vencimiento,@vAmortizacion,@vInteres,@vImpuesto,@vValor_cuota,@vMora,@vFecha_pago,@vSaldo_cuota,@vAgencia_registro,@vUsuario_registro) "

        For FilaDetalle As Integer = 0 To MyPrestamoCuotas.Rows.Count - 1
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySQLString_2
            MySQLCommand.Parameters.Clear()

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO)
                .AddWithValue("vCuota", MyPrestamoCuotas(FilaDetalle).CUOTA)
                .AddWithValue("vEjercicio", MyPrestamoCuotas(FilaDetalle).EJERCICIO)
                .AddWithValue("vMes", MyPrestamoCuotas(FilaDetalle).MES)
                .AddWithValue("vFecha_vencimiento", MyPrestamoCuotas(FilaDetalle).FECHA_VENCIMIENTO)
                .AddWithValue("vAmortizacion", MyPrestamoCuotas(FilaDetalle).AMORTIZACION)
                .AddWithValue("vInteres", MyPrestamoCuotas(FilaDetalle).INTERES)
                .AddWithValue("vImpuesto", MyPrestamoCuotas(FilaDetalle).IMPUESTO)
                .AddWithValue("vValor_cuota", MyPrestamoCuotas(FilaDetalle).VALOR_CUOTA)
                .AddWithValue("vMora", 0)
                .AddWithValue("vFecha_pago", MyPrestamoCuotas(FilaDetalle).FECHA_PAGO)
                .AddWithValue("vSaldo_cuota", MyPrestamoCuotas(FilaDetalle).SALDO_CUOTA)
                .AddWithValue("vAgencia_registro", MyPrestamoCuotas(FilaDetalle).AGENCIA_REGISTRO)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
            End With
            MySQLCommand.ExecuteNonQuery()
        Next

    End Sub

    Private Shared Sub ActualizarCliente(ByVal ExisteCliente As Boolean, ByVal MyCuentaComercial As entCuentaComercial, ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand, ByRef MySQLDbconnection As System.Data.SqlClient.SqlConnection)
        Dim DeudaCliente As New dsFinanciero.DEUDA_CLIENTEDataTable
        Dim DeudaMN As Decimal = 0
        Dim DeudaME As Decimal = 0

        If ExisteCliente Then
            CadenaSQL = "SELECT P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, C.RAZON_SOCIAL AS CLIENTE, P.TIPO_MONEDA, SUM(P.TOTAL_SALDO) AS DEUDA_ACTUAL, " &
                        "COUNT(*) AS NRO_PRESTAMOS, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL " &
                        "FROM FIN.PRESTAMOS AS P " &
                        "INNER JOIN FIN.CLIENTES AS C ON P.EMPRESA = C.EMPRESA AND P.TIPO_DOCUMENTO = C.TIPO_DOCUMENTO AND P.NRO_DOCUMENTO = C.NRO_DOCUMENTO " &
                        "INNER JOIN COM.AGENCIAS AS A ON P.EMPRESA = A.EMPRESA AND P.AGENCIA_REGISTRO = A.AGENCIA " &
                        "WHERE P.EMPRESA='" & MyCuentaComercial.empresa &
                        "' AND P.TIPO_DOCUMENTO='" & MyCuentaComercial.tipo_documento &
                        "' AND P.NRO_DOCUMENTO='" & MyCuentaComercial.nro_documento.Trim & "' AND P.ESTADO = 'V' " &
                        IIf(MyPrestamo(0).PRESTAMO_REFINANCIADO <> CUO_Nulo, "AND P.PRESTAMO<>'" & MyPrestamo(0).PRESTAMO_REFINANCIADO & "' ", " ") &
                        "GROUP BY P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, P.TIPO_MONEDA, C.RAZON_SOCIAL, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL "

            Dim myDataAdapter As New SqlDataAdapter(CadenaSQL, MySQLDbconnection)
            myDataAdapter.Fill(DeudaCliente)

            If DeudaCliente.Rows.Count <> 0 Then
                For NFila As Integer = 0 To DeudaCliente.Rows.Count - 1
                    If DeudaCliente(NFila).TIPO_MONEDA = "1" Then
                        DeudaMN = DeudaCliente(NFila).DEUDA_ACTUAL
                    Else
                        DeudaME = DeudaCliente(NFila).DEUDA_ACTUAL
                    End If
                Next
            End If

            MySQLString = "UPDATE FIN.CLIENTES SET " &
                          "domicilio=@vDomicilio,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo,referencia=@vReferencia,telefono=@vTelefono," &
                          "telefono_otro=@vTelefono_otro,celular=@vCelular,email=@vEmail,fecha_nacimiento=@vFecha_nacimiento,sexo=@vSexo,estado_civil=@vEstado_civil," &
                          "nivel_educativo=@vNivel_educativo,ocupacion=@vOcupacion,direccion_trabajo=@vDireccion_trabajo,referencia_trabajo=@vReferencia_trabajo," &
                          "telefono_trabajo=@vTelefono_trabajo,saldo_pagar_mn=@vSaldo_pagar_mn,saldo_pagar_me=@vSaldo_pagar_me," &
                          "afecto_igv=@vAfecto_igv,nombre_conviviente=@vNombre_conviviente," &
                          "agencia_modifica=@vAgencia_modifica,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                          "WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipo_documento AND Nro_Documento=@vNro_documento "

            If MyPrestamo(0).TIPO_MONEDA = "1" Then
                DeudaMN = DeudaMN + MyPrestamo(0).TOTAL_PRESTAMO
            Else
                DeudaME = DeudaME + MyPrestamo(0).TOTAL_PRESTAMO
            End If

            MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_mn", DeudaMN)
            MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_me", DeudaME)
            MySQLCommand.Parameters.AddWithValue("vAgencia_modifica", MyCuentaComercial.agencia_modifica)
            MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", MyCuentaComercial.usuario_modifica)
        Else
            MySQLString = "INSERT INTO FIN.CLIENTES " &
                          "(EMPRESA,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,DOMICILIO,DEPARTAMENTO,PROVINCIA,UBIGEO,REFERENCIA,TELEFONO,TELEFONO_OTRO," &
                          "CELULAR,EMAIL,FECHA_NACIMIENTO,SEXO,ESTADO_CIVIL,NIVEL_EDUCATIVO,OCUPACION,DIRECCION_TRABAJO,REFERENCIA_TRABAJO," &
                          "TELEFONO_TRABAJO,SALDO_PAGAR_MN,SALDO_PAGAR_ME,AFECTO_IGV,NOMBRE_CONVIVIENTE,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
                          "VALUES " &
                          "(@vEmpresa,@vTipo_documento,@vNro_documento,@vRazon_social,@vDomicilio,@vDepartamento,@vProvincia,@vUbigeo,@vReferencia,@vTelefono,@vTelefono_otro," &
                          "@vCelular,@vEmail,@vFecha_nacimiento,@vSexo,@vEstado_civil,@vNivel_educativo,@vOcupacion,@vDireccion_trabajo,@vReferencia_trabajo," &
                          "@vTelefono_trabajo,@vSaldo_pagar_mn,@vSaldo_pagar_me,@vAfecto_igv,@vNombre_conviviente,@vAgencia_registro,@vUsuario_registro) "

            If MyPrestamo(0).TIPO_MONEDA = "1" Then
                MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_mn", MyPrestamo(0).TOTAL_PRESTAMO)
                MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_me", 0)
            Else
                MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_mn", 0)
                MySQLCommand.Parameters.AddWithValue("vSaldo_pagar_me", MyPrestamo(0).TOTAL_PRESTAMO)
            End If
            MySQLCommand.Parameters.AddWithValue("vRazon_social", MyCuentaComercial.razon_social)
            MySQLCommand.Parameters.AddWithValue("vAgencia_registro", MyCuentaComercial.agencia_registro)
            MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyCuentaComercial.usuario_registro)
        End If

        MySQLCommand.CommandText = MySQLString

        With MySQLCommand.Parameters
            .AddWithValue("vDomicilio", MyCuentaComercial.domicilio)
            .AddWithValue("vDepartamento", MyCuentaComercial.departamento)
            .AddWithValue("vProvincia", MyCuentaComercial.provincia)
            .AddWithValue("vUbigeo", MyCuentaComercial.ubigeo)
            .AddWithValue("vReferencia", MyCuentaComercial.referencia)
            .AddWithValue("vTelefono", MyCuentaComercial.telefono)
            .AddWithValue("vTelefono_otro", MyCuentaComercial.telefono_otro)
            .AddWithValue("vCelular", MyCuentaComercial.celular)
            .AddWithValue("vEmail", MyCuentaComercial.email)
            .AddWithValue("vFecha_nacimiento", MyCuentaComercial.fecha_nacimiento)
            .AddWithValue("vSexo", MyCuentaComercial.sexo)
            .AddWithValue("vEstado_civil", MyCuentaComercial.estado_civil)
            .AddWithValue("vNivel_educativo", MyCuentaComercial.nivel_educativo)
            .AddWithValue("vOcupacion", MyCuentaComercial.ocupacion)
            .AddWithValue("vDireccion_trabajo", MyCuentaComercial.direccion_trabajo)
            .AddWithValue("vReferencia_trabajo", MyCuentaComercial.referencia_trabajo)
            .AddWithValue("vTelefono_trabajo", MyCuentaComercial.telefono_trabajo)
            .AddWithValue("vAfecto_igv", MyCuentaComercial.afecto_igv)
            .AddWithValue("vNombre_conviviente", MyCuentaComercial.nombre_conviviente)
            .AddWithValue("vEmpresa", MyCuentaComercial.empresa)
            .AddWithValue("vTipo_documento", MyCuentaComercial.tipo_documento.Trim)
            .AddWithValue("vNro_documento", MyCuentaComercial.nro_documento.Trim)
        End With

        MySQLCommand.ExecuteNonQuery()
    End Sub

    Private Shared Sub ActualizarPrestamoRefinanciado(ByVal MyPrestamo As dsFinanciero.PRESTAMOSDataTable, ByVal MyPrestamosRefinanciarCuotas As dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        MySQLString_2 = "UPDATE FIN.PRESTAMOS SET INDICA_REFINANCIAMIENTO='SI', PRESTAMO_REFINANCIADO=@vPrestamo_nuevo,ESTADO='C', AGENCIA_MODIFICA=@vAgencia_modifica," &
                        "USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                        "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo "
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString_2
        MySQLCommand.Parameters.Clear()
        With MySQLCommand.Parameters
            .AddWithValue("vPrestamo_nuevo", MyPrestamo(0).PRESTAMO)
            .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
            .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
            .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO_REFINANCIADO)
        End With
        MySQLCommand.ExecuteNonQuery()

        If MyPrestamosRefinanciarCuotas.Rows.Count <> 0 Then
            MySQLString_3 = "UPDATE FIN.PRESTAMOS_CUOTAS SET FECHA_PAGO=@vFecha_pago, MORA=@vMora, COMPROMISO_COMENTARIO='REFINANC. '+@vPrestamoNuevo," &
                            "ESTADO='C', AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() " &
                            "WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND CUOTA=@vCuota "

            For FilaDetalle As Integer = 0 To MyPrestamosRefinanciarCuotas.Rows.Count - 1
                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySQLString_3
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("vFecha_pago", MyFechaServidor)
                    .AddWithValue("vMora", MyPrestamosRefinanciarCuotas(FilaDetalle).MORA)
                    .AddWithValue("vPrestamoNuevo", MyPrestamo(0).PRESTAMO)
                    .AddWithValue("vAgencia_modifica", MyAgencia(0).AGENCIA)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vEmpresa", MyPrestamo(0).EMPRESA)
                    .AddWithValue("vPrestamo", MyPrestamo(0).PRESTAMO_REFINANCIADO)
                    .AddWithValue("vCuota", MyPrestamosRefinanciarCuotas(FilaDetalle).NUMERO_CUOTA)
                End With
                MySQLCommand.ExecuteNonQuery()
            Next
        End If
    End Sub

    Private Shared Sub ActualizarSaldoCliente(ByVal MyCuentaComercial As entCuentaComercial, ByRef MySQLCommand As System.Data.SqlClient.SqlCommand)
        Dim DeudaCliente As New dsFinanciero.DEUDA_CLIENTEDataTable
        Dim DeudaMN As Decimal = 0
        Dim DeudaME As Decimal = 0

        CadenaSQL = "SELECT P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, C.RAZON_SOCIAL AS CLIENTE, P.TIPO_MONEDA, SUM(P.TOTAL_SALDO) AS DEUDA_ACTUAL, " &
                    "COUNT(*) AS NRO_PRESTAMOS, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL " &
                    "FROM FIN.PRESTAMOS AS P " &
                    "INNER JOIN FIN.CLIENTES AS C ON P.EMPRESA = C.EMPRESA AND P.TIPO_DOCUMENTO = C.TIPO_DOCUMENTO AND P.NRO_DOCUMENTO = C.NRO_DOCUMENTO " &
                    "INNER JOIN COM.AGENCIAS AS A ON P.EMPRESA = A.EMPRESA AND P.AGENCIA_REGISTRO = A.AGENCIA " &
                    "WHERE P.EMPRESA='" & MyCuentaComercial.empresa &
                    "' AND P.TIPO_DOCUMENTO='" & MyCuentaComercial.tipo_documento &
                    "' AND P.NRO_DOCUMENTO='" & MyCuentaComercial.nro_documento & "' AND P.ESTADO = 'V' " &
                    "GROUP BY P.EMPRESA, P.TIPO_DOCUMENTO, P.NRO_DOCUMENTO, P.TIPO_MONEDA, C.RAZON_SOCIAL, P.AGENCIA_REGISTRO, A.RAZON_SOCIAL "

        Call ObtenerDataTableSQL(CadenaSQL, DeudaCliente)
        If DeudaCliente.Rows.Count <> 0 Then
            For NFila As Integer = 0 To DeudaCliente.Rows.Count - 1
                If DeudaCliente(NFila).TIPO_MONEDA = "1" Then
                    DeudaMN = DeudaCliente(NFila).DEUDA_ACTUAL
                Else
                    DeudaME = DeudaCliente(NFila).DEUDA_ACTUAL
                End If
            Next
        End If

        MySQLString_3 = "UPDATE FIN.CLIENTES SET SALDO_PAGAR_MN=@vSaldo_pagar_mn, SALDO_PAGAR_ME=@vSaldo_pagar_me, " &
                        "AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE()" &
                        "WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipo_documento AND Nro_Documento=@vNro_documento "
        MySQLCommand.CommandType = CommandType.Text
        MySQLCommand.CommandText = MySQLString_3
        MySQLCommand.Parameters.Clear()
        With MySQLCommand.Parameters
            .AddWithValue("vSaldo_pagar_mn", DeudaMN)
            .AddWithValue("vSaldo_pagar_me", DeudaME)
            .AddWithValue("vAgencia_modifica", MyCuentaComercial.agencia_modifica)
            .AddWithValue("vUsuario_modifica", MyCuentaComercial.usuario_modifica)
            .AddWithValue("vEmpresa", MyCuentaComercial.empresa)
            .AddWithValue("vTipo_documento", MyCuentaComercial.tipo_documento.Trim)
            .AddWithValue("vNro_documento", MyCuentaComercial.nro_documento.Trim)
        End With
        MySQLCommand.ExecuteNonQuery()
    End Sub

#End Region

End Class
