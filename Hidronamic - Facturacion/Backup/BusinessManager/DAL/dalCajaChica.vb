Imports System.Data.SqlClient

Public Class dalCajaChica

    Private Shared vBIG, vIE, vII, vIGV, vOT, vIT As Single

#Region "Caja"
    Private Shared Function Existe(ByVal cCajaChica As entCajaChica) As Boolean
        With cCajaChica
            If Not String.IsNullOrEmpty(.numero_caja) Then
                Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CAJA_CHICA " & _
                                            "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND area=@vArea AND numero_caja=@vNumero_caja "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", .empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", .ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vArea", .area)
                    MySQLCommand.Parameters.AddWithValue("vNumero_caja", .numero_caja)
                    MySQLDbconnection.Open()
                    Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                    Return IIf(MyCount = 0, False, True)
                End Using
            End If
        End With
    End Function

    Private Shared Function ExisteNumeroCaja(ByVal cCajaChica As entCajaChica) As Boolean
        With cCajaChica
            If Not String.IsNullOrEmpty(.numero_caja) Then
                Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CAJA_CHICA " & _
                                            "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND area=@vArea AND numero_caja=@vNumero_caja " & _
                                            "AND codigo_ui<>@vCodigo_UI "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", .empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", .ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vArea", .area)
                    MySQLCommand.Parameters.AddWithValue("vNumero_caja", .numero_caja)
                    MySQLCommand.Parameters.AddWithValue("vCodigo_UI", .codigo_ui)
                    MySQLDbconnection.Open()
                    Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                    Return IIf(MyCount = 0, False, True)
                End Using
            End If
        End With
    End Function

    Public Shared Function Obtener(ByVal cCajaChica As entCajaChica) As entCajaChica
        If Existe(cCajaChica) Then
            Return ObtenerCajaChica(cCajaChica)
        Else
            Return New entCajaChica
        End If
    End Function

    Private Shared Function ObtenerCajaChica(ByVal cCajaChica As entCajaChica) As entCajaChica
        Dim MyDT As New dsCajaChica.CAJA_CHICADataTable
        If cCajaChica.numero_caja <> "0000" Then
            Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND area=@vArea AND numero_caja=@vNumero_caja "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChica.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChica.numero_caja)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
            If MyDT.Count > 0 Then Call PoblarCajaChica(cCajaChica, MyDT)
        End If
        Return cCajaChica
    End Function

    Private Shared Sub PoblarCajaChica(ByRef cCajaChica As entCajaChica, ByVal MyDT As dsCajaChica.CAJA_CHICADataTable)
        With cCajaChica
            .empresa = MyDT(0).empresa
            .ejercicio = MyDT(0).ejercicio
            .mes = MyDT(0).mes
            .area = MyDT(0).area
            .numero_caja = MyDT(0).numero_caja
            .codigo_ui = MyDT(0).codigo_ui
            .tipo_moneda = MyDT(0).tipo_moneda
            .tipo_cambio = MyDT(0).tipo_cambio
            .cuenta_contable = MyDT(0).cuenta_contable
            .item_flujo = MyDT(0).item_flujo
            .fecha_apertura = MyDT(0).fecha_apertura
            .importe_apertura = MyDT(0).importe_apertura
            .saldo_anterior = MyDT(0).saldo_anterior
            .saldo_actual = MyDT(0).saldo_actual
            .glosa = MyDT(0).glosa
            If Not MyDT(0).IsNull("FECHA_REEMBOLSO") Then .fecha_reembolso = MyDT(0).fecha_reembolso
            .importe_reembolso = MyDT(0).importe_reembolso
            .pago_maximo = MyDT(0).pago_maximo
            .indica_contabilizado = MyDT(0).indica_contabilizado
            If Not MyDT(0).IsNull("FECHA_CONTABILIZADO") Then .fecha_contabilizado = MyDT(0).fecha_contabilizado
            .estado = MyDT(0).estado
            .usuario_registro = MyDT(0).usuario_registro
            .fecha_registro = MyDT(0).fecha_registro
            If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).usuario_modifica
            If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).fecha_modifica
        End With
    End Sub

    Public Shared Function ObtenerUltimoNumeroCaja(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pArea As String) As String
        Dim MyValor As String = Nothing
        Dim MyStringSql As String = "SELECT ISNULL(MAX(numero_caja), '0000') AS MyValor FROM CON.CAJA_CHICA " & _
                                    "WHERE empresa='" & pEmpresa & "' AND ejercicio='" & pEjercicio & "' AND area='" & pArea & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
        End Using
        Return MyValor
    End Function

    Public Shared Function ObtenerTotalGastosCaja(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pArea As String, ByVal pNumeroCaja As String, ByVal pCorrelativo As String) As Decimal
        Dim MyValor As Decimal
        'Dim MyStringSql As String = "SELECT ISNULL(SUM(dimporte_total),0) AS MyValor FROM CON.CAJA_CHICA_DETALLE " & _
        '                            "WHERE dempresa='" & pEmpresa & "' AND dejercicio='" & pEjercicio & "' AND dmes='" & pMes & "' AND darea='" & pArea & "' AND dnumero_caja='" & pNumeroCaja & "' " & _
        '                            IIf(pCorrelativo <> "", " AND dcorrelativo<>'" & pCorrelativo & "' ", " ") & " AND destado='A' "
        Dim MyStringSql As String = "SELECT ISNULL(SUM(egreso),0) AS MyValor FROM CON.CAJA_CHICA_MOVIMIENTOS " & _
                                    "WHERE empresa='" & pEmpresa & "' AND ejercicio='" & pEjercicio & "' AND mes='" & pMes & "' AND area='" & pArea & "' AND numero_caja='" & pNumeroCaja & "' " & _
                                    IIf(pCorrelativo <> "", " AND correlativo<>'" & pCorrelativo & "' ", " ") & " AND estado='A' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
        End Using
        Return MyValor
    End Function

    Public Shared Function GenerarNumeroCaja(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pArea As String) As String
        Dim MyValor As String
        Dim Correlativo As Long
        Dim MyStringSql As String = "SELECT ISNULL(MAX(numero_caja), '0000') AS MyValor FROM CON.CAJA_CHICA " & _
                                    "WHERE empresa='" & pEmpresa & "' AND ejercicio='" & pEjercicio & "' AND area='" & pArea & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
            Correlativo = CLng(MyValor) + 1
            MyValor = Strings.Right("0000" & Correlativo.ToString.Trim, 4)
        End Using
        Return MyValor
    End Function

    Public Shared Function ObtenerEntregasPorRendir(ByVal cCajaChica As entCajaChica) As dsCajaChica.CAJA_CHICA_ENTREGAS_X_RENDIRDataTable
        Dim MyDT As New dsCajaChica.CAJA_CHICA_ENTREGAS_X_RENDIRDataTable
        If Not String.IsNullOrEmpty(cCajaChica.area) Then
            Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA_ENTREGAS_X_RENDIR WHERE cempresa=@vEmpresa AND carea=@vArea " & _
                                        "ORDER BY cbeneficiario_nombre "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
        End If
        Return MyDT
    End Function

    Public Shared Function ObtenerEntregasPorRendir(ByVal cEmpresa As String, ByVal cEjercicio As String, ByVal cBeneficiario As String) As dsCajaChica.CAJA_CHICA_ENTREGASDataTable
        Dim MyDT As New dsCajaChica.CAJA_CHICA_ENTREGASDataTable
        Dim MySqlString As String = "SELECT COUNT(*) AS nro_entregas, ISNULL(SUM(cimporte_total), 0) AS importe " & _
                                    "FROM CON.CAJA_CHICA_ENTREGAS_X_RENDIR " & _
                                    "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cbeneficiario=@vBeneficiario "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", cEjercicio)
            MySQLCommand.Parameters.AddWithValue("vBeneficiario", cBeneficiario)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDocumentos(ByVal cCajaChica As entCajaChica, ByVal pTipo As String) As dsCajaChica.CAJA_CHICA_DOCUMENTOSDataTable
        Dim MyDT As New dsCajaChica.CAJA_CHICA_DOCUMENTOSDataTable
        If Not String.IsNullOrEmpty(cCajaChica.numero_caja) Then
            Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA_DOCUMENTOS " & _
                                        "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja " & _
                                        IIf(pTipo = "TODOS", " AND ctipo<>'E' ", " AND ctipo='" & pTipo & "' ")
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChica.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cCajaChica.mes)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChica.numero_caja)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
        End If
        Return MyDT
    End Function

    Public Shared Function ObtenerMovimientos(ByVal cCajaChica As entCajaChica, ByVal IndicaHistorico As Boolean) As dsCajaChica.CAJA_CHICA_MOVIMIENTOSDataTable
        Dim MyDT As New dsCajaChica.CAJA_CHICA_MOVIMIENTOSDataTable
        If Not String.IsNullOrEmpty(cCajaChica.numero_caja) Then
            Dim MySqlString As String
            If IndicaHistorico = True Then
                MySqlString = "SELECT * FROM CON.CAJA_CHICA_MOVIMIENTOS_HISTORICO " & _
                              "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja " & _
                              "ORDER BY correlativo "
            Else
                MySqlString = "SELECT * FROM CON.CAJA_CHICA_MOVIMIENTOS " & _
                              "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja " & _
                              " AND estado IN ('A','P') " & _
                              "UNION ALL " & _
                              "SELECT M.* " & _
                              "FROM CON.CAJA_CHICA_MOVIMIENTOS AS M INNER JOIN CON.CAJA_CHICA_ENTREGAS_X_RENDIR_DIFERIDAS AS E ON " & _
                              "M.empresa = E.empresa AND M.ejercicio = E.ejercicio AND M.mes = E.mes AND M.area = E.area AND " & _
                              "M.numero_caja = E.numero_caja AND M.correlativo = E.correlativo " & _
                              "WHERE M.empresa=@vEmpresa AND M.ejercicio=@vEjercicio AND M.mes=@vMes AND M.area=@vArea AND M.numero_caja=@vNumero_caja " & _
                              " AND M.tipo='E' AND M.estado='C' " & _
                              "ORDER BY correlativo "
            End If

            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChica.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cCajaChica.mes)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChica.numero_caja)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
        End If
        Return MyDT
    End Function

    Public Shared Function ObtenerAsientosMigrar(ByVal cCajaChica As entCajaChica) As dsAsientoContable.DETALLEDataTable
        Dim MyFechaTexto As String  
        With cCajaChica
            If String.IsNullOrEmpty(.area) Then Throw New BusinessException(MSG000 & " AREA/RESPONSABLE")
            If String.IsNullOrEmpty(.numero_caja) Then Throw New BusinessException(MSG000 & " # CAJA")
            'If String.IsNullOrEmpty(.asiento_subdiario) Then Throw New BusinessException(MSG000 & " TIPO DE SUBDIARIO")
            If Year(.fecha_contabilizado) * 100 + Month(.fecha_contabilizado) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            If .tipo_cambio = 0 Then Throw New BusinessException(MSG000 & " TIPO DE CAMBIO")
            If String.IsNullOrEmpty(.asiento_comprobante_caja) Then Throw New BusinessException(MSG000 & " NRO. COMP. CAJA")
            If String.IsNullOrEmpty(.asiento_comprobante_rendicion) Then Throw New BusinessException(MSG000 & " NRO. COMP. RENDICION")
            If String.IsNullOrEmpty(.asiento_comprobante_honorarios) Then Throw New BusinessException(MSG000 & " NRO. COMP. HONORARIOS")
            If String.IsNullOrEmpty(.glosa) Then Throw New BusinessException(MSG000 & " GLOSA DEL COMPROBANTE")
            MyFechaTexto = .fecha_contabilizado.Year & "-" & Strings.Right("00" & .fecha_contabilizado.Month.ToString, 2) & "-" & Strings.Right("00" & .fecha_contabilizado.Day.ToString, 2)
        End With

        Return ObtenerAsientosCajaChica(cCajaChica, MyFechaTexto)

    End Function

    Private Shared Function ObtenerAsientosCajaChica(ByVal cCajaChica As entCajaChica, ByVal pFechaTexto As String) As dsAsientoContable.DETALLEDataTable
        Dim MyStoreProcedure As String = "CON.ASIENTOS_CAJA_CHICA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 4) : MyParameter_1.Value = cCajaChica.empresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = cCajaChica.ejercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = cCajaChica.mes
        Dim MyParameter_4 As New SqlParameter("@AREA", SqlDbType.Char, 6) : MyParameter_4.Value = cCajaChica.area
        Dim MyParameter_5 As New SqlParameter("@NUMERO_CAJA", SqlDbType.Char, 4) : MyParameter_5.Value = cCajaChica.numero_caja
        Dim MyParameter_6 As New SqlParameter("@FECHA", SqlDbType.Char, 10) : MyParameter_6.Value = pFechaTexto
        Dim MyParameter_7 As New SqlParameter("@TIPO_CAMBIO", SqlDbType.Decimal) : MyParameter_7.Value = cCajaChica.tipo_cambio

        Dim MyDT As New dsAsientoContable.DETALLEDataTable

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
            MySQLCommand.Parameters.Add(MyParameter_7)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function Grabar(ByVal cCajaChica As entCajaChica) As entCajaChica
        With cCajaChica
            If cCajaChica.codigo_ui = CUO_Nulo Then
                If .importe_apertura = 0 Then Throw New BusinessException(MSG000 & " REEMBOLSO")
                If Year(.fecha_apertura) * 100 + Month(.fecha_apertura) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            Else
                If .importe_reembolso = 0 Then Throw New BusinessException(MSG000 & " REEMBOLSO")
                If Year(.fecha_reembolso) * 100 + Month(.fecha_reembolso) = 190001 Then Throw New BusinessException(MSG000 & " FECHA")
            End If

            If String.IsNullOrEmpty(.numero_caja) Then Throw New BusinessException(MSG000 & " SIGUIENTE NUMERO DE CAJA")
        End With

        If Not cCajaChica.codigo_ui = CUO_Nulo Then
            If ExisteNumeroCaja(cCajaChica) Then Throw New BusinessException(" El NUMERO DE CAJA " & cCajaChica.numero_caja & " ya existe.")
        End If
        If cCajaChica.codigo_ui = CUO_Nulo Then
            Return Insertar(cCajaChica)
        Else
            Return Actualizar(cCajaChica)
        End If
    End Function

    Private Shared Function Insertar(ByVal cCajaChica As entCajaChica) As entCajaChica

        cCajaChica.codigo_ui = Strings.Left("CC" & NumeroAleatorio(), 12)

        Dim MySql As String = "INSERT INTO CON.CAJA_CHICA " & _
                              "(empresa,ejercicio,mes,area,numero_caja,codigo_ui,tipo_moneda,fecha_apertura,importe_apertura," & _
                              "saldo_anterior,saldo_actual,glosa,usuario_registro) " & _
                              "VALUES (" & _
                              "@vEmpresa,@vEjercicio,@vMes,@vArea,@vNumero_caja,@vCodigo_UI,@vTipo_moneda,@vFecha_apertura,@vImporte_apertura," & _
                              "@vSaldo_anterior,@vSaldo_actual,@vGlosa,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCajaChica.empresa)
                .AddWithValue("vEjercicio", cCajaChica.ejercicio)
                .AddWithValue("vMes", cCajaChica.mes)
                .AddWithValue("vArea", cCajaChica.area)
                .AddWithValue("vNumero_caja", cCajaChica.numero_caja)
                .AddWithValue("vCodigo_UI", cCajaChica.codigo_ui)
                .AddWithValue("vTipo_moneda", cCajaChica.tipo_moneda)
                .AddWithValue("vFecha_apertura", cCajaChica.fecha_apertura)
                .AddWithValue("vImporte_apertura", cCajaChica.importe_apertura)
                .AddWithValue("vSaldo_anterior", cCajaChica.saldo_anterior)
                .AddWithValue("vSaldo_actual", cCajaChica.saldo_actual)
                .AddWithValue("vGlosa", cCajaChica.glosa)
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

                Return cCajaChica

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

    Private Shared Function Actualizar(ByVal cCajaChica As entCajaChica) As entCajaChica

        Dim MySqlString As String = "UPDATE CON.CAJA_CHICA SET " & _
                                    "fecha_reembolso=@vFecha_reembolso,importe_reembolso=@vImporte_reembolso," & _
                                    "estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica  " & _
                                    "WHERE empresa=@vEmpresa AND codigo_ui=@vCodigo_UI "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vFecha_reembolso", cCajaChica.fecha_reembolso)
                .AddWithValue("vImporte_reembolso", cCajaChica.importe_reembolso)
                .AddWithValue("vEstado", cCajaChica.estado)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChica.empresa)
                .AddWithValue("vCodigo_UI", cCajaChica.codigo_ui)
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

                MySqlString = "INSERT INTO CON.CAJA_CHICA_MOVIMIENTOS_HISTORICO " & _
                              "(empresa, ejercicio, mes, area, numero_caja, codigo_ui, tipo, correlativo, beneficiario, beneficiario_nombre, " & _
                              "anexo, anexo_nombre, documento_fecha, documento_tipo, documento_numero, glosa, ingreso, egreso, estado) " & _
                              "(SELECT * FROM CON.CAJA_CHICA_MOVIMIENTOS " & _
                              "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja " & _
                              "AND estado IN ('A', 'P') " & _
                              "UNION ALL " & _
                              "SELECT M.* FROM CON.CAJA_CHICA_MOVIMIENTOS AS M INNER JOIN CON.CAJA_CHICA_ENTREGAS_X_RENDIR_DIFERIDAS AS E ON  " & _
                              "M.empresa = E.empresa AND M.ejercicio = E.ejercicio AND M.mes = E.mes AND M.area = E.area AND  " & _
                              "M.numero_caja = E.numero_caja AND M.correlativo = E.correlativo  " & _
                              "WHERE M.empresa=@vEmpresa AND M.ejercicio=@vEjercicio AND M.mes=@vMes AND M.area=@vArea AND M.numero_caja=@vNumero_caja " & _
                              "AND M.tipo='E' AND M.estado='C')"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChica.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cCajaChica.mes)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChica.numero_caja_anterior)

                MySQLCommand.ExecuteNonQuery()

                cCajaChica.codigo_ui = Strings.Left("CC" & NumeroAleatorio(), 12)

                MySqlString = "INSERT INTO CON.CAJA_CHICA " & _
                              "(empresa,ejercicio,mes,area,numero_caja,codigo_ui,tipo_moneda,fecha_apertura,importe_apertura," & _
                              "saldo_anterior,saldo_actual,glosa,usuario_registro) " & _
                              "VALUES (" & _
                              "@vEmpresa,@vEjercicio,@vMes,@vArea,@vNumero_caja,@vCodigo_UI,@vTipo_moneda,@vFecha_apertura,@vImporte_apertura," & _
                              "@vSaldo_anterior,@vSaldo_actual,@vGlosa,@vUsuario_registro) "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChica.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChica.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cCajaChica.mes)
                MySQLCommand.Parameters.AddWithValue("vArea", cCajaChica.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChica.numero_caja)
                MySQLCommand.Parameters.AddWithValue("vCodigo_UI", cCajaChica.codigo_ui)
                MySQLCommand.Parameters.AddWithValue("vTipo_moneda", cCajaChica.tipo_moneda)
                MySQLCommand.Parameters.AddWithValue("vFecha_apertura", cCajaChica.fecha_reembolso)
                MySQLCommand.Parameters.AddWithValue("vImporte_apertura", cCajaChica.importe_reembolso)
                MySQLCommand.Parameters.AddWithValue("vSaldo_anterior", cCajaChica.saldo_anterior)
                MySQLCommand.Parameters.AddWithValue("vSaldo_actual", cCajaChica.saldo_actual)
                MySQLCommand.Parameters.AddWithValue("vGlosa", cCajaChica.glosa)
                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)

                MySQLCommand.ExecuteNonQuery()

                    ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cCajaChica

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

    Public Shared Function CerrarEntregaPorRendir(ByVal cEntregaPorRendir As entCajaChicaCabecera) As Boolean

        'si existe un saldo se lo suma al saldo de la Caja Actual
        Dim MySqlString As String = "UPDATE CON.CAJA_CHICA SET " & _
                                    "saldo_actual=saldo_actual+@vSaldo,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                                    "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vSaldo", cEntregaPorRendir.importe_total)
                .AddWithValue("vUsuario_modifica", cEntregaPorRendir.usuario_modifica)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cEntregaPorRendir.empresa)
                .AddWithValue("vEjercicio", cEntregaPorRendir.ejercicio)
                .AddWithValue("vMes", cEntregaPorRendir.mes)
                .AddWithValue("vArea", cEntregaPorRendir.area)
                .AddWithValue("vNumero_caja", cEntregaPorRendir.numero_caja)
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

                'Cambia el estado a la Cabacera y Detalle que corresponde a la Entrega a Rendir que se otorgó
                MySqlString = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
                              "cestado='C',cejercicio_referencia=@vEjercicio, cmes_referencia=@vMes, carea_referencia=@vArea, cnumero_caja_referencia=@vNumero_caja," & _
                              "cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica " & _
                              "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio_referencia AND cmes=@vMes_referencia AND " & _
                              "carea=@vArea_referencia AND cnumero_caja=@vNumero_caja_referencia AND ccorrelativo=@vCorrelativo_referencia "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vEjercicio", cEntregaPorRendir.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cEntregaPorRendir.mes)
                MySQLCommand.Parameters.AddWithValue("vArea", cEntregaPorRendir.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cEntregaPorRendir.numero_caja)
                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", cEntregaPorRendir.usuario_modifica)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEntregaPorRendir.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio_referencia", cEntregaPorRendir.ejercicio_referencia)
                MySQLCommand.Parameters.AddWithValue("vMes_referencia", cEntregaPorRendir.mes_referencia)
                MySQLCommand.Parameters.AddWithValue("vArea_referencia", cEntregaPorRendir.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja_referencia", cEntregaPorRendir.numero_caja_referencia)
                MySQLCommand.Parameters.AddWithValue("vCorrelativo_referencia", cEntregaPorRendir.correlativo_referencia)
                MySQLCommand.Parameters.AddWithValue("vUsuario_registro", MyUsuario.usuario)

                MySQLCommand.ExecuteNonQuery()

                MySqlString = "UPDATE CON.CAJA_CHICA_DETALLE SET " & _
                              "destado='C',dusuario_modifica=@vUsuario_modifica,dfecha_modifica=@vFecha_modifica " & _
                              "WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dmes=@vMes AND darea=@vArea AND dnumero_caja=@vNumero_caja AND dcorrelativo=@vCorrelativo AND dsecuencia='0001' "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vUsuario_modifica", cEntregaPorRendir.usuario_modifica)
                MySQLCommand.Parameters.AddWithValue("vFecha_modifica", Now)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEntregaPorRendir.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cEntregaPorRendir.ejercicio_referencia)
                MySQLCommand.Parameters.AddWithValue("vMes", cEntregaPorRendir.mes_referencia)
                MySQLCommand.Parameters.AddWithValue("vArea", cEntregaPorRendir.area)
                MySQLCommand.Parameters.AddWithValue("vNumero_caja", cEntregaPorRendir.numero_caja_referencia)
                MySQLCommand.Parameters.AddWithValue("vCorrelativo", cEntregaPorRendir.correlativo_referencia)

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

#End Region

#Region "Cabecera"
    Private Shared Function Existe(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As Boolean
        With cCajaChicaCabecera
            If Not String.IsNullOrEmpty(.correlativo) Then
                Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CAJA_CHICA_CABECERA " & _
                                            "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND " & _
                                            "cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", .empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", .ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", .mes)
                    MySQLCommand.Parameters.AddWithValue("vArea", .area)
                    MySQLCommand.Parameters.AddWithValue("vNumero_caja", .numero_caja)
                    MySQLCommand.Parameters.AddWithValue("vCorrelativo", .correlativo)
                    MySQLDbconnection.Open()
                    Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                    Return IIf(MyCount = 0, False, True)
                End Using
            End If
        End With
    End Function

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pCodigo_UI As String) As Boolean
        If pCodigo_UI <> CUO_Nulo Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CAJA_CHICA_CABECERA WHERE cempresa=@vEmpresa AND ccodigo_ui=@vCodigo_UI "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vCodigo_UI", pCodigo_UI)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera
        If Existe(cCajaChicaCabecera) Then
            Return ObtenerCabecera(cCajaChicaCabecera)
        Else
            Return New entCajaChicaCabecera
        End If
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pCodigo_UI As String) As entCajaChicaCabecera
        If Existe(pEmpresa, pCodigo_UI) Then
            Return ObtenerCabecera(pEmpresa, pCodigo_UI)
        Else
            Return New entCajaChicaCabecera
        End If
    End Function

    Private Shared Function ObtenerCabecera(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera
        Dim MyDT As New dsCajaChica.CAJA_CHICA_CABECERADataTable
        With cCajaChicaCabecera
            If Not String.IsNullOrEmpty(.correlativo) Then
                Dim MySqlString As String = "SELECT * " & _
                                            "FROM CON.CAJA_CHICA_CABECERA " & _
                                            "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND " & _
                                            "cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", .empresa)
                    MySQLCommand.Parameters.AddWithValue("vEjercicio", .ejercicio)
                    MySQLCommand.Parameters.AddWithValue("vMes", .mes)
                    MySQLCommand.Parameters.AddWithValue("vArea", .area)
                    MySQLCommand.Parameters.AddWithValue("vNumero_caja", .numero_caja)
                    MySQLCommand.Parameters.AddWithValue("vCorrelativo", .correlativo)
                    MySQLCommand.Connection = MySQLDbconnection
                    MySQLCommand.CommandType = CommandType.Text
                    Dim MyDA As New SqlDataAdapter(MySQLCommand)
                    MyDA.Fill(MyDT)
                End Using
                If MyDT.Count > 0 Then Call PoblarCabecera(cCajaChicaCabecera, MyDT)
            End If
        End With
        Return cCajaChicaCabecera
    End Function

    Private Shared Function ObtenerCabecera(ByVal pEmpresa As String, ByVal pCodigo_UI As String) As entCajaChicaCabecera
        Dim MyDT As New dsCajaChica.CAJA_CHICA_CABECERADataTable
        Dim cCajaChicaCabecera As New entCajaChicaCabecera
        If pCodigo_UI <> CUO_Nulo Then
            Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA_CABECERA WHERE cempresa=@vEmpresa AND ccodigo_ui=@vCodigo_UI "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vCodigo_UI", pCodigo_UI)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
            If MyDT.Count > 0 Then Call PoblarCabecera(cCajaChicaCabecera, MyDT)
        End If
        Return cCajaChicaCabecera
    End Function

    Private Shared Function ObtenerCabecera(ByVal cCajaChicaCabecera As entCajaChicaCabecera, ByVal MySqlString As String) As entCajaChicaCabecera
        Dim MyDT As New dsCajaChica.CAJA_CHICA_CABECERADataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        If MyDT.Count > 0 Then Call PoblarCabecera(cCajaChicaCabecera, MyDT)
        Return cCajaChicaCabecera
    End Function

    Public Shared Function ObtenerSiguiente(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera
        With cCajaChicaCabecera
            CadenaSQL = "SELECT TOP 1 * FROM CON.CAJA_CHICA_CABECERA WHERE cempresa='" & .empresa & "' AND cejercicio='" & .ejercicio & _
                       "' AND cmes='" & .mes & "' AND " & "cnumero_caja='" & .numero_caja & "' AND ccorrelativo>'" & .correlativo & "' AND ctipo='" & .tipo & "' "
        End With
        Return ObtenerCabecera(New entCajaChicaCabecera, CadenaSQL)
    End Function

    Public Shared Function ObtenerAnterior(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera
        With cCajaChicaCabecera
            CadenaSQL = "SELECT TOP 1 * FROM CON.CAJA_CHICA_CABECERA WHERE cempresa='" & .empresa & "' AND cejercicio='" & .ejercicio & _
                       "' AND cmes='" & .mes & "' AND " & "cnumero_caja='" & .numero_caja & "' AND ccorrelativo<'" & .correlativo & "' AND ctipo='" & .tipo & "' " & _
                       "ORDER BY ccorrelativo DESC"
        End With
        Return ObtenerCabecera(New entCajaChicaCabecera, CadenaSQL)
    End Function

    Private Shared Sub PoblarCabecera(ByRef cCajaChicaCabecera As entCajaChicaCabecera, ByVal MyDT As dsCajaChica.CAJA_CHICA_CABECERADataTable)
        With cCajaChicaCabecera
            .empresa = MyDT(0).cempresa
            .ejercicio = MyDT(0).cejercicio
            .mes = MyDT(0).cmes
            .area = MyDT(0).carea
            .numero_caja = MyDT(0).cnumero_caja
            .correlativo = MyDT(0).ccorrelativo
            .codigo_ui = MyDT(0).ccodigo_ui
            .tipo = MyDT(0).ctipo
            .beneficiario_tipo = MyDT(0).cbeneficiario_tipo
            .beneficiario = MyDT(0).cbeneficiario
            .subdiario = MyDT(0).csubdiario
            .documento_tipo = MyDT(0).cdocumento_tipo
            .documento_serie = MyDT(0).cdocumento_serie
            .documento_numero = MyDT(0).cdocumento_numero
            .documento_fecha = MyDT(0).cdocumento_fecha
            .documento_vencimiento = MyDT(0).cdocumento_vencimiento
            .tipo_cambio = MyDT(0).ctipo_cambio
            .tipo_moneda = MyDT(0).ctipo_moneda
            .anexo = MyDT(0).canexo
            .avanexo = MyDT(0).cavanexo
            .glosa = MyDT(0).cglosa

            .base_imponible_gravada = MyDT(0).cbase_imponible_gravada
            .importe_exonerado = MyDT(0).cimporte_exonerado
            .importe_inafecto = MyDT(0).cimporte_inafecto
            .igv = MyDT(0).cigv
            .otros_tributos = MyDT(0).cotros_tributos
            .importe_total = MyDT(0).cimporte_total

            .ejercicio_referencia = MyDT(0).cejercicio_referencia
            .mes_referencia = MyDT(0).cmes_referencia
            .area_referencia = MyDT(0).carea_referencia
            .numero_caja_referencia = MyDT(0).cnumero_caja_referencia
            .correlativo_referencia = MyDT(0).ccorrelativo_referencia
            .importe_total_referencia = MyDT(0).cimporte_total_referencia
            .estado = MyDT(0).cestado
            .usuario_registro = MyDT(0).cusuario_registro
            .fecha_registro = MyDT(0).cfecha_registro
            If Not MyDT(0).IsNull("CUSUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).cusuario_modifica
            If Not MyDT(0).IsNull("CFECHA_MODIFICA") Then .fecha_modifica = MyDT(0).cfecha_modifica
        End With
    End Sub

    Private Shared Function ExisteDocumento(ByVal cCajaChicaCabecera As entCajaChicaCabecera, ByVal EsNuevo As Boolean) As entCajaChicaCabecera
        With cCajaChicaCabecera
            CadenaSQL = "SELECT * FROM CON.CAJA_CHICA_CABECERA " & _
                        "WHERE cempresa='" & .empresa & "' AND canexo='" & .anexo & "' AND cavanexo='" & .avanexo & "' AND " & _
                        "cdocumento_tipo='" & .documento_tipo & "' AND cdocumento_serie='" & .documento_serie & "' " & "AND cdocumento_numero='" & .documento_numero & "' "
            If EsNuevo = False Then CadenaSQL = CadenaSQL & " AND ccodigo_ui<>'" & .codigo_ui & "' "
        End With
        Return ObtenerCabecera(New entCajaChicaCabecera, CadenaSQL)
    End Function

    Public Shared Function Grabar(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera
        Dim MyOtroDocumento As New entCajaChicaCabecera
        With cCajaChicaCabecera
            If String.IsNullOrEmpty(.beneficiario.Trim) Then Throw New BusinessException(MSG000 & " BENEFICIARIO")
            If .indica_beneficiario_nuevo = True Then
                If String.IsNullOrEmpty(.beneficiario_nombre.Trim) Then Throw New BusinessException(MSG000 & " NOMBRE DEL BENEFICIARIO")
                If String.IsNullOrEmpty(.beneficiario_tipo.Trim) Then Throw New BusinessException(MSG000 & " TIPO DE BENEFICIARIO")
            End If
            If .tipo <> "E" Then ' Para todos excepto las Entregas a Rendir
                If .documento_tipo <> "VR" Then
                    If .documento_serie = "0000" Then Throw New BusinessException(MSG000 & " SERIE")
                End If
                If .documento_numero = "0000000000" Then Throw New BusinessException(MSG000 & " NUMERO")
                If Year(.documento_fecha) * 100 + Month(.documento_fecha) = 190001 Then Throw New BusinessException(MSG000 & " F. EMISION")
                If Year(.documento_vencimiento) * 100 + Month(.documento_vencimiento) = 190001 Then Throw New BusinessException(MSG000 & " F. VCMTO.")
            Else
                If Year(.documento_fecha) * 100 + Month(.documento_fecha) = 190001 Then Throw New BusinessException(MSG000 & " F. ENTREGA")
                If .importe_total = 0 Then Throw New BusinessException(MSG000 & " IMPORTE")
            End If

            If .documento_tipo <> "VR" Then
                If String.IsNullOrEmpty(.anexo.Trim) Then Throw New BusinessException(MSG000 & " RUC")
            End If

            If .indica_proveedor_nuevo = True Then
                If String.IsNullOrEmpty(.anexo_nombre.Trim) Then Throw New BusinessException(MSG000 & " NOMBRE DEL PROVEEDOR")
                If String.IsNullOrEmpty(.avanexo.Trim) Then Throw New BusinessException(MSG000 & " TIPO DE PROVEEDOR")
            End If

            If String.IsNullOrEmpty(.glosa.Trim) Then Throw New BusinessException(MSG000 & " CONCEPTO DEL GASTO")
        End With

        If cCajaChicaCabecera.tipo <> "E" Then MyOtroDocumento = ExisteDocumento(cCajaChicaCabecera, IIf(cCajaChicaCabecera.codigo_ui = CUO_Nulo, True, False))

        If Not String.IsNullOrEmpty(MyOtroDocumento.correlativo) Then Throw New BusinessException(MSG1004 & " Periodo: " & MyOtroDocumento.ejercicio & "-" & MyOtroDocumento.mes & " Caja: " & MyOtroDocumento.numero_caja & " - " & MyOtroDocumento.correlativo)

        If cCajaChicaCabecera.codigo_ui = CUO_Nulo Then
            Return Insertar(cCajaChicaCabecera)
        Else
            Return Actualizar(cCajaChicaCabecera)
        End If
    End Function

    Private Shared Function Insertar(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera

        Dim MyStringSQL As String

        With cCajaChicaCabecera
            .codigo_ui = Strings.Left("CH" & NumeroAleatorio(), 12)

            If .tipo = "E" Then
                .documento_serie = GenerarSerieEntregaRendir(.empresa, .tipo, .beneficiario_tipo, .beneficiario)
                .documento_numero = "ER" & ((Now.Year * 10000) + (Now.Month * 100) + Now.Day)
            End If

        End With

        MyStringSQL = "INSERT INTO CON.CAJA_CHICA_CABECERA " & _
                              "(cempresa,cejercicio,cmes,carea,cnumero_caja,ccorrelativo,ccodigo_ui,ctipo,cbeneficiario_tipo,cbeneficiario,csubdiario,cdocumento_tipo," & _
                              "cdocumento_serie,cdocumento_numero,cdocumento_fecha,cdocumento_vencimiento,canexo,cavanexo,cglosa," & _
                              "cbase_imponible_gravada,cimporte_exonerado,cimporte_inafecto,cigv,cotros_tributos,cimporte_total,cejercicio_referencia,cmes_referencia," & _
                              "carea_referencia,cnumero_caja_referencia,ccorrelativo_referencia,cimporte_total_referencia,cestado,cusuario_registro) " & _
                              "VALUES (" & _
                              "@vEmpresa,@vEjercicio,@vMes,@vArea,@vNumero_caja,@vCorrelativo,@vCodigo_UI,@vTipo,@vBeneficiario_tipo,@vBeneficiario,@vSubdiario,@vDocumento_tipo," & _
                              "@vDocumento_serie,@vDocumento_numero,@vDocumento_fecha,@vDocumento_vencimiento,@vAnexo,@vAvAnexo,@vGlosa," & _
                              "@vBase_imponible_gravada,@vimporte_exonerado,@vimporte_inafecto,@vIgv,@vOtros_tributos,@vImporte_total,@vEjercicio_referencia,@vMes_referencia," & _
                              "@vArea_referencia,@vNumero_caja_referencia,@vCorrelativo_referencia,@vImporte_total_referencia,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MyStringSQL, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCajaChicaCabecera.empresa)
                .AddWithValue("vEjercicio", cCajaChicaCabecera.ejercicio)
                .AddWithValue("vMes", cCajaChicaCabecera.mes)
                .AddWithValue("vArea", cCajaChicaCabecera.area)
                .AddWithValue("vNumero_caja", cCajaChicaCabecera.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaCabecera.correlativo)
                .AddWithValue("vCodigo_UI", cCajaChicaCabecera.codigo_ui)
                .AddWithValue("vTipo", cCajaChicaCabecera.tipo)
                .AddWithValue("vBeneficiario_tipo", cCajaChicaCabecera.beneficiario_tipo)
                .AddWithValue("vBeneficiario", cCajaChicaCabecera.beneficiario)
                .AddWithValue("vSubdiario", cCajaChicaCabecera.subdiario)
                .AddWithValue("vDocumento_tipo", cCajaChicaCabecera.documento_tipo)
                .AddWithValue("vDocumento_serie", cCajaChicaCabecera.documento_serie)
                .AddWithValue("vDocumento_numero", cCajaChicaCabecera.documento_numero)
                .AddWithValue("vDocumento_fecha", cCajaChicaCabecera.documento_fecha)
                .AddWithValue("vDocumento_vencimiento", cCajaChicaCabecera.documento_vencimiento)
                .AddWithValue("vAnexo", cCajaChicaCabecera.anexo)
                .AddWithValue("vAvAnexo", cCajaChicaCabecera.avanexo)
                .AddWithValue("vGlosa", cCajaChicaCabecera.glosa)
                .AddWithValue("vBase_imponible_gravada", cCajaChicaCabecera.base_imponible_gravada)
                .AddWithValue("vimporte_exonerado", cCajaChicaCabecera.importe_exonerado)
                .AddWithValue("vimporte_inafecto", cCajaChicaCabecera.importe_inafecto)
                .AddWithValue("vIgv", cCajaChicaCabecera.igv)
                .AddWithValue("vOtros_tributos", cCajaChicaCabecera.otros_tributos)
                .AddWithValue("vImporte_total", cCajaChicaCabecera.importe_total)
                .AddWithValue("vEjercicio_referencia", cCajaChicaCabecera.ejercicio_referencia)
                .AddWithValue("vMes_referencia", cCajaChicaCabecera.mes_referencia)
                .AddWithValue("vArea_referencia", cCajaChicaCabecera.area_referencia)
                .AddWithValue("vNumero_caja_referencia", cCajaChicaCabecera.numero_caja_referencia)
                .AddWithValue("vCorrelativo_referencia", cCajaChicaCabecera.correlativo_referencia)
                .AddWithValue("vImporte_total_referencia", cCajaChicaCabecera.importe_total_referencia)
                .AddWithValue("vEstado", cCajaChicaCabecera.estado)
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

                Return cCajaChicaCabecera

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

    Private Shared Function Actualizar(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As entCajaChicaCabecera

        Dim MySql As String = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
        "ctipo=@vTipo,cbeneficiario_tipo=@vBeneficiario_tipo,cbeneficiario=@vBeneficiario,csubdiario=@vSubdiario," & _
        "cdocumento_tipo=@vDocumento_tipo,cdocumento_serie=@vDocumento_serie,cdocumento_numero=@vDocumento_numero,cdocumento_fecha=@vDocumento_fecha," & _
        "cdocumento_vencimiento=@vDocumento_vencimiento,canexo=@vAnexo,cavanexo=@vAvAnexo,cglosa=@vGlosa," & _
        "cbase_imponible_gravada=@vBase_imponible_gravada,cimporte_exonerado=@vimporte_exonerado," & _
        "cimporte_inafecto=@vimporte_inafecto,cigv=@vIgv,cotros_tributos=@vOtros_tributos,cimporte_total=@vImporte_total," & _
        "cestado=@vEstado,cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica  " & _
        "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vTipo", cCajaChicaCabecera.tipo)
                .AddWithValue("vBeneficiario_tipo", cCajaChicaCabecera.beneficiario_tipo)
                .AddWithValue("vBeneficiario", cCajaChicaCabecera.beneficiario)
                .AddWithValue("vSubdiario", cCajaChicaCabecera.subdiario)
                .AddWithValue("vDocumento_tipo", cCajaChicaCabecera.documento_tipo)
                .AddWithValue("vDocumento_serie", cCajaChicaCabecera.documento_serie)
                .AddWithValue("vDocumento_numero", cCajaChicaCabecera.documento_numero)
                .AddWithValue("vDocumento_fecha", cCajaChicaCabecera.documento_fecha)
                .AddWithValue("vDocumento_vencimiento", cCajaChicaCabecera.documento_vencimiento)
                .AddWithValue("vAnexo", cCajaChicaCabecera.anexo)
                .AddWithValue("vAvAnexo", cCajaChicaCabecera.avanexo)
                .AddWithValue("vGlosa", cCajaChicaCabecera.glosa)
                .AddWithValue("vBase_imponible_gravada", cCajaChicaCabecera.base_imponible_gravada)
                .AddWithValue("vimporte_exonerado", cCajaChicaCabecera.importe_exonerado)
                .AddWithValue("vimporte_inafecto", cCajaChicaCabecera.importe_inafecto)
                .AddWithValue("vIgv", cCajaChicaCabecera.igv)
                .AddWithValue("vOtros_tributos", cCajaChicaCabecera.otros_tributos)
                .AddWithValue("vImporte_total", cCajaChicaCabecera.importe_total)
                .AddWithValue("vEstado", cCajaChicaCabecera.estado)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChicaCabecera.empresa)
                .AddWithValue("vEjercicio", cCajaChicaCabecera.ejercicio)
                .AddWithValue("vMes", cCajaChicaCabecera.mes)
                .AddWithValue("vArea", cCajaChicaCabecera.area)
                .AddWithValue("vNumero_caja", cCajaChicaCabecera.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaCabecera.correlativo)
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
                Return cCajaChicaCabecera

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

    Public Shared Function Eliminar(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As Boolean
        Dim MySqlString As String = "DELETE FROM CON.CAJA_CHICA_CABECERA " & _
                                    "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChicaCabecera.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChicaCabecera.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", cCajaChicaCabecera.mes)
            MySQLCommand.Parameters.AddWithValue("vArea", cCajaChicaCabecera.area)
            MySQLCommand.Parameters.AddWithValue("vNumero_caja", cCajaChicaCabecera.numero_caja)
            MySQLCommand.Parameters.AddWithValue("vCorrelativo", cCajaChicaCabecera.correlativo)

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

    Public Shared Function ActualizarCabecera(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As Boolean

        Dim MySqlString As String

        With cCajaChicaCabecera
            MySqlString = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa='" & .empresa & "' AND dejercicio='" & .ejercicio & "' AND dmes='" & .mes & "' " & _
                          "AND darea='" & .area & "' AND dnumero_caja='" & .numero_caja & "' AND dcorrelativo='" & .correlativo & "' "
        End With

        Call ObtenerValores(MySqlString)

        MySqlString = "UPDATE CON.CAJA_CHICA_DETALLE SET " & _
                      "cbase_imponible_gravada=@vBase_imponible_gravada,cimporte_exonerado=@vimporte_exonerado,cimporte_inafecto=@vimporte_inafecto," & _
                      "cigv=@vIgv,cotros_tributos=@vOtros_tributos,cimporte_total=@vImporte_total,cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica " & _
                      "WHERE cempresa=@vEmpresa AND ccodigo_ui=@vCodigo_UI "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vBase_imponible_gravada", vBIG)
                .AddWithValue("vimporte_exonerado", vIE)
                .AddWithValue("vimporte_inafecto", vII)
                .AddWithValue("vIgv", vIGV)
                .AddWithValue("vOtros_tributos", vOT)
                .AddWithValue("vImporte_total", vIT)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChicaCabecera.empresa)
                .AddWithValue("vCodigo_UI", cCajaChicaCabecera.codigo_ui)
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

    Public Shared Function GenerarCorrelativoCaja(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pArea As String, ByVal pNumeroCaja As String) As String
        Dim MyValor As String
        Dim Correlativo As Long
        Dim MyStringSql As String = "SELECT ISNULL(MAX(ccorrelativo), '000000') AS MyValor FROM CON.CAJA_CHICA_CABECERA " & _
                                    "WHERE cempresa='" & pEmpresa & "' AND cejercicio='" & pEjercicio & "' AND cmes='" & pMes & "' AND " & _
                                    "carea='" & pArea & "' AND cnumero_caja='" & pNumeroCaja & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
            Correlativo = CLng(MyValor) + 1
            MyValor = Strings.Right("000000" & Correlativo.ToString.Trim, 6)
        End Using
        Return MyValor
    End Function

    Public Shared Function BuscarBeneficiarios(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pArea As String, ByVal pNumeroCaja As String) As dsCONCAR_Anexos.ANEXOS_DETALLEDataTable
        Dim MyDT As New dsCONCAR_Anexos.ANEXOS_DETALLEDataTable
        Dim MyStringSql As String = "SELECT C.cbeneficiario_tipo AS avanexo, C.cbeneficiario AS acodane, A.adesane, A.arefane, A.aruc, A.acodmon, A.aestado, A.adate, A.ahora, A.avrete, A.aporre " & _
                                    "FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN CON.ANEXO_CUENTA_CORRIENTE AS A ON C.cbeneficiario_tipo = A.avanexo AND C.cbeneficiario = A.acodane " & _
                                    "WHERE cempresa='" & pEmpresa & "' AND cejercicio='" & pEjercicio & "' AND cmes='" & pMes & "' AND carea='" & pArea & "' AND cnumero_caja='" & pNumeroCaja & "' AND C.ctipo='R' " & _
                                    "GROUP BY C.cbeneficiario_tipo, C.cbeneficiario, A.adesane, A.arefane, A.aruc, A.acodmon, A.aestado, A.adate, A.ahora, A.avrete, A.aporre " & _
                                    "ORDER BY A.adesane "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarDocumentos(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pArea As String, ByVal pNumeroCaja As String, ByVal pTipo As String, ByVal pBeneficiario As String) As DataTable
        Dim MyDT As New DataTable
        Dim MyStringSql As String
        If pTipo = "E" Then
            MyStringSql = "SELECT C.ccorrelativo, RTRIM(C.canexo) AS canexo, RTRIM(A1.adesane) AS adesane, C.ctipo_moneda, C.cdocumento_tipo, C.cdocumento_serie, C.cdocumento_numero, C.cdocumento_fecha, C.cglosa, " & _
                          "C.cimporte_total, C.cbase_imponible_gravada, C.cimporte_exonerado, C.cigv, C.cestado, C.ccodigo_ui " & _
                          "FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN CON.ANEXO_CUENTA_CORRIENTE AS A1 ON C.cavanexo = A1.avanexo AND C.canexo = A1.acodane " & _
                          "WHERE C.cempresa='" & pEmpresa & "' AND C.ctipo='" & pTipo & "' AND C.cestado='A' " & _
                          IIf(pBeneficiario = "TODOS", " ", " AND C.cbeneficiario='" & pBeneficiario & "' ") & _
                          "ORDER BY C.ccorrelativo "

            '"UNION ALL " & _
            '"SELECT C.ccorrelativo, RTRIM(C.canexo) AS canexo, RTRIM(A1.adesane) AS adesane, C.ctipo_moneda, C.cdocumento_tipo, C.cdocumento_serie, C.cdocumento_numero, C.cdocumento_fecha, C.cglosa, " & _
            '"C.cimporte_total, C.cbase_imponible_gravada, C.cimporte_exonerado, C.cigv, C.cestado, C.ccodigo_ui " & _
            '"FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN AUX.ANEXOS_X_MIGRAR AS A1 ON C.cavanexo = A1.avanexo AND C.canexo = A1.acodane " & _
            '"WHERE C.cempresa='" & pEmpresa & "' AND C.ctipo='" & pTipo & "' AND C.cestado='A' AND A1.indica_proceso='NO' " & _
            'IIf(pBeneficiario = "TODOS", " ", " AND C.cbeneficiario='" & pBeneficiario & "' ") & _
        Else
            MyStringSql = "SELECT C.ccorrelativo, RTRIM(C.canexo) AS canexo, RTRIM(A1.adesane) AS adesane, C.ctipo_moneda, C.cdocumento_tipo, C.cdocumento_serie, C.cdocumento_numero, C.cdocumento_fecha, C.cglosa, " & _
                          "C.cimporte_total, C.cbase_imponible_gravada, C.cimporte_exonerado, C.cigv, C.cestado, C.ccodigo_ui " & _
                          "FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN CON.ANEXO_CUENTA_CORRIENTE AS A1 ON C.cavanexo = A1.avanexo AND C.canexo = A1.acodane " & _
                          "WHERE C.cempresa='" & pEmpresa & "' AND C.cejercicio='" & pEjercicio & "' AND C.cmes='" & pMes & "' AND C.carea='" & pArea & "' AND C.cnumero_caja='" & pNumeroCaja & "' AND C.ctipo='" & pTipo & "' " & _
                          IIf(pBeneficiario = "TODOS", " ", " AND C.cbeneficiario='" & pBeneficiario & "' ") & _
                          "UNION ALL " & _
                          "SELECT C.ccorrelativo, C.canexo, SPACE(1) AS adesane, C.ctipo_moneda, C.cdocumento_tipo, C.cdocumento_serie, C.cdocumento_numero, C.cdocumento_fecha, C.cglosa, " & _
                          "C.cimporte_total, C.cbase_imponible_gravada, C.cimporte_exonerado, C.cigv, C.cestado, C.ccodigo_ui " & _
                          "FROM CON.CAJA_CHICA_CABECERA AS C " & _
                          "WHERE C.cempresa='" & pEmpresa & "' AND C.cejercicio='" & pEjercicio & "' AND C.cmes='" & pMes & "' AND C.carea='" & pArea & "' AND C.cnumero_caja='" & pNumeroCaja & "' AND C.ctipo='" & pTipo & "' " & _
                          " AND RTRIM(C.canexo)='' " & _
                          "ORDER BY C.ccorrelativo "

            '"UNION ALL " & _
            '"SELECT C.ccorrelativo, RTRIM(C.canexo) AS canexo, RTRIM(A1.adesane) AS adesane, C.ctipo_moneda, C.cdocumento_tipo, C.cdocumento_serie, C.cdocumento_numero, C.cdocumento_fecha, C.cglosa, " & _
            '"C.cimporte_total, C.cbase_imponible_gravada, C.cimporte_exonerado, C.cigv, C.cestado, C.ccodigo_ui " & _
            '"FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN AUX.ANEXOS_X_MIGRAR AS A1 ON C.cavanexo = A1.avanexo AND C.canexo = A1.acodane " & _
            '"WHERE C.cempresa='" & pEmpresa & "' AND C.cejercicio='" & pEjercicio & "' AND C.cmes='" & pMes & "' AND C.carea='" & pArea & "' AND C.cnumero_caja='" & pNumeroCaja & "' AND C.ctipo='" & pTipo & "' AND A1.indica_proceso='NO' " & _
            'IIf(pBeneficiario = "TODOS", " ", " AND C.cbeneficiario='" & pBeneficiario & "' ") & _
        End If
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Private Shared Sub ObtenerValores(ByVal MyStringSQL As String)
        Dim MyDT As New dsCajaChica.CAJA_CHICA_DETALLEDataTable
        vBIG = 0 : vIE = 0 : vII = 0 : vIGV = 0 : vOT = 0 : vIT = 0

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        If MyDT.Count <> 0 Then
            For NEle As Byte = 0 To MyDT.Count - 1
                vBIG = vBIG + MyDT(NEle).dbase_imponible_gravada
                vIE = vIE + MyDT(NEle).dimporte_exonerado
                vII = vII + MyDT(NEle).dimporte_inafecto
                vIGV = vIGV + MyDT(NEle).digv
                vOT = vOT + MyDT(NEle).dotros_tributos
                vIT = vIT + MyDT(NEle).dimporte_total

            Next
        End If
    End Sub

    Public Shared Function ActualizarEntregaPorRendir(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As Decimal
        Dim MyImporteRendido As Decimal = 0
        Dim MyImportePorRendir As Decimal = 0
        Dim MyStringSql As String
        With cCajaChicaDetalle
            MyStringSql = "SELECT ISNULL(SUM(D.dimporte_total),0) AS importe_rendido " & _
                          "FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN CON.CAJA_CHICA_DETALLE AS D ON " & _
                          "C.cempresa=D.dempresa AND C.cejercicio=D.dejercicio AND C.cmes=D.dmes AND C.carea=D.darea AND " & _
                          "C.cnumero_caja=D.dnumero_caja AND C.ccorrelativo=D.dcorrelativo " & _
                          "WHERE C.cempresa='" & .empresa & "' AND C.cejercicio_referencia='" & .ejercicio & "' AND C.cmes_referencia='" & .mes & "' AND " & _
                          "C.carea_referencia='" & .area & "' AND C.cnumero_caja_referencia='" & .numero_caja & "' AND C.ccorrelativo_referencia='" & .correlativo & "' "
        End With
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyImporteRendido = MySQLCommand.ExecuteScalar
        End Using

        MyImportePorRendir = cCajaChicaDetalle.importe_total_rendicion - MyImporteRendido

        MyStringSql = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
                      "cimporte_total=@vImporte_total,cimporte_inafecto=@vImporte_inafecto,cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica  " & _
                      "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vImporte_total", MyImportePorRendir)
                .AddWithValue("vImporte_inafecto", MyImportePorRendir)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                .AddWithValue("vMes", cCajaChicaDetalle.mes)
                .AddWithValue("vArea", cCajaChicaDetalle.area)
                .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
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

                MyStringSql = "UPDATE CON.CAJA_CHICA_DETALLE SET " & _
                              "dimporte_total=@vImporte_total,dimporte_inafecto=@vImporte_inafecto,dusuario_modifica=@vUsuario_modifica,dfecha_modifica=@vFecha_modifica " & _
                              "WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dmes=@vMes AND darea=@vArea AND dnumero_caja=@vNumero_caja AND dcorrelativo=@vCorrelativo AND dsecuencia='0001' "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MyStringSql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vImporte_total", IIf(MyImportePorRendir < 0, 0, MyImportePorRendir))
                    .AddWithValue("vImporte_inafecto", IIf(MyImportePorRendir < 0, 0, MyImportePorRendir))
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                    .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                    .AddWithValue("vMes", cCajaChicaDetalle.mes)
                    .AddWithValue("vArea", cCajaChicaDetalle.area)
                    .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                    .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
                End With

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return MyImportePorRendir

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

    Private Shared Function GenerarSerieEntregaRendir(ByVal pEmpresa As String, ByVal pTipo As String, ByVal pBeneficiarioTipo As String, ByVal pBeneficiario As String) As String
        Dim MyValor As String
        Dim Correlativo As Long
        Dim MyStringSql As String = "SELECT ISNULL(MAX(cdocumento_serie), '0000') AS MyValor FROM CON.CAJA_CHICA_CABECERA " & _
                                    "WHERE cempresa='" & pEmpresa & "' AND ctipo='" & pTipo & "' AND cbeneficiario_tipo='" & pBeneficiarioTipo & "' AND " & _
                                    "cbeneficiario='" & pBeneficiario & "'  "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
            Correlativo = CLng(MyValor) + 1
            MyValor = Strings.Right("0000" & Correlativo.ToString.Trim, 4)
        End Using
        Return MyValor
    End Function


#End Region

#Region "Detalles"

    Public Shared Function Grabar(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As entCajaChicaDetalle

        With cCajaChicaDetalle
            Dim ValidarImporte As Single = Math.Round(.base_imponible_gravada + .importe_exonerado + .importe_inafecto + .igv, 2)

            If String.IsNullOrEmpty(.cuenta.Trim) Then Throw New BusinessException(MSG000 & " CUENTA CONTABLE")
            If .cuenta.Trim.Length <> 6 Then Throw New BusinessException(MSG1099 & " CUENTA CONTABLE (6 DIGITOS)")

            If .indica_proyecto = True Then If String.IsNullOrEmpty(.anexo.Trim) Then Throw New BusinessException(MSG000 & " PROYECTO")
            If .indica_cuenta_corriente = True Then If String.IsNullOrEmpty(.anexo.Trim) Then Throw New BusinessException(MSG000 & " CUENTA CORRIENTE")

            If .indica_centro_costo = True Then If String.IsNullOrEmpty(.centro_costo.Trim) Then Throw New BusinessException(MSG000 & " CENTRO COSTO")

            If ValidarImporte = 0 Then Throw New BusinessException("DEBE REGISTRAR IMPORTES SEGUN CORRESPONDA")

        End With

        If String.IsNullOrEmpty(cCajaChicaDetalle.secuencia.Trim) Then
            Return Insertar(cCajaChicaDetalle)
        Else
            Return Actualizar(cCajaChicaDetalle)
        End If
    End Function

    Public Shared Function Borrar(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As Boolean
        If Not String.IsNullOrEmpty(cCajaChicaDetalle.secuencia.Trim) Then
            Return Eliminar(cCajaChicaDetalle)
        Else
            Return False
        End If
    End Function

    Private Shared Function Eliminar(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As Boolean
        Dim MySqlString As String
        Dim MyTotalGastosCaja As Decimal = 0

        With cCajaChicaDetalle
            If .estado = "A" Then MyTotalGastosCaja = ObtenerTotalGastosCaja(.empresa, .ejercicio, .mes, .area, .numero_caja, .correlativo)
            MySqlString = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa='" & .empresa & "' AND dejercicio='" & .ejercicio & "' AND dmes='" & .mes & "' " & _
                          "AND darea='" & .area & "' AND dnumero_caja='" & .numero_caja & "' AND dcorrelativo='" & .correlativo & "' AND dsecuencia<>'" & .secuencia & "' "

            Call ObtenerValores(MySqlString)

            MyTotalGastosCaja = MyTotalGastosCaja + vIT
        End With

        MySqlString = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
                      "cbase_imponible_gravada=@vBase_imponible_gravada,cimporte_exonerado=@vimporte_exonerado," & _
                      "cimporte_inafecto=@vimporte_inafecto,cigv=@vIgv,cotros_tributos=@vOtros_tributos,cimporte_total=@vImporte_total," & _
                      "cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica  " & _
                      "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vBase_imponible_gravada", vBIG)
                .AddWithValue("vimporte_exonerado", vIE)
                .AddWithValue("vimporte_inafecto", vII)
                .AddWithValue("vIgv", vIGV)
                .AddWithValue("vOtros_tributos", vOT)
                .AddWithValue("vImporte_total", vIT)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                .AddWithValue("vMes", cCajaChicaDetalle.mes)
                .AddWithValue("vArea", cCajaChicaDetalle.area)
                .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
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

                MySqlString = "DELETE FROM CON.CAJA_CHICA_DETALLE " & _
                              "WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dmes=@vMes AND darea=@vArea AND dnumero_caja=@vNumero_caja AND dcorrelativo=@vCorrelativo AND dsecuencia=@vSecuencia "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                    .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                    .AddWithValue("vMes", cCajaChicaDetalle.mes)
                    .AddWithValue("vArea", cCajaChicaDetalle.area)
                    .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                    .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
                    .AddWithValue("vSecuencia", cCajaChicaDetalle.secuencia)
                End With

                MySQLCommand.ExecuteNonQuery()

                If cCajaChicaDetalle.estado = "A" Then ' Solo si Estado es igual al valor (A)plicar se descuenta contra el Saldo Actual de Caja 
                    If cCajaChicaDetalle.indica_rendicion_cuenta = False Then ' Si no es Rendicion de Cuenta actualizar el Saldo Actual de Caja
                        MySqlString = "UPDATE CON.CAJA_CHICA SET " & _
                                      "saldo_actual=importe_apertura+saldo_anterior-@vTotal_gastos_caja,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                                      "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja "
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vTotal_gastos_caja", MyTotalGastosCaja)
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vFecha_modifica", Now)
                            .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                            .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                            .AddWithValue("vMes", cCajaChicaDetalle.mes)
                            .AddWithValue("vArea", cCajaChicaDetalle.area)
                            .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                        End With
                        MySQLCommand.ExecuteNonQuery()
                    End If
                End If

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

    Public Shared Function EvaluarImportePorRendir(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As Boolean
        Dim MyImporteRendido As Decimal
        Dim MyStringSql As String
        With cCajaChicaDetalle
            MyStringSql = "SELECT ISNULL(SUM(D.dimporte_total),0) AS importe_rendido " & _
                          "FROM CON.CAJA_CHICA_CABECERA AS C INNER JOIN CON.CAJA_CHICA_DETALLE AS D ON " & _
                          "C.cempresa=D.dempresa AND C.cejercicio=D.dejercicio AND C.cmes=D.dmes AND C.carea=D.darea AND " & _
                          "C.cnumero_caja=D.dnumero_caja AND C.ccorrelativo=D.dcorrelativo " & _
                          "WHERE C.cempresa='" & .empresa & "' AND C.cejercicio_referencia='" & .ejercicio & "' AND C.cmes_referencia='" & .mes & "' AND " & _
                          "C.carea_referencia='" & .area & "' AND C.cnumero_caja_referencia='" & .numero_caja & "' AND C.ccorrelativo_referencia='" & .correlativo & "' "
        End With
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyImporteRendido = MySQLCommand.ExecuteScalar
        End Using

        With cCajaChicaDetalle
            MyImporteRendido = MyImporteRendido - .importe_total_origen + .importe_total
            If MyImporteRendido > .importe_total_rendicion Then
                Resp = MsgBox("Este registro hace que la suma de la rendición de cuenta sea mayor que el SALDO A RENDIR en " & _
                              EvalDato((MyImporteRendido - .importe_total_rendicion), "DS") & Chr(13) & _
                              "Para poder continuar debe primero debe incrementar el importe de la ENTREGA A RENDIR." & Chr(13) & _
                              "", MsgBoxStyle.Information, "PROCESO CANCELADO")
                Return False
            Else
                Return True
            End If
        End With

    End Function

    Private Shared Function Insertar(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As entCajaChicaDetalle

        Dim MySqlString As String
        Dim MyTotalGastosCaja As Decimal = 0

        With cCajaChicaDetalle
            If .estado = "A" Then
                MyTotalGastosCaja = ObtenerTotalGastosCaja(.empresa, .ejercicio, .mes, .area, .numero_caja, .correlativo)
                MyTotalGastosCaja = MyTotalGastosCaja + .importe_total
            End If

            MySqlString = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa='" & .empresa & "' AND dejercicio='" & .ejercicio & "' AND dmes='" & .mes & "' " & _
                          "AND darea='" & .area & "' AND dnumero_caja='" & .numero_caja & "' AND dcorrelativo='" & .correlativo & "' "

            Call ObtenerValores(MySqlString)

            vBIG = vBIG + .base_imponible_gravada
            vIE = vIE + .importe_exonerado
            vII = vII + .importe_inafecto
            vIGV = vIGV + .igv
            vOT = vOT + .otros_tributos
            vIT = vIT + .importe_total

            .secuencia = GenerarSecuenciaCaja(.empresa, .ejercicio, .mes, .area, .numero_caja, .correlativo)
            .codigo_ui = Strings.Left("CD" & NumeroAleatorio(), 12)
        End With

        Dim MySql As String = "INSERT INTO CON.CAJA_CHICA_DETALLE " & _
                              "(dempresa,dejercicio,dmes,darea,dnumero_caja,dcorrelativo,dsecuencia,dcodigo_ui,dcuenta,danexo_tipo,danexo,davanexo,dcentro_costo,dglosa," & _
                              "dbase_imponible_gravada,dimporte_exonerado,dimporte_inafecto,digv,dotros_tributos,dimporte_total,destado,dusuario_registro) " & _
                              "VALUES (" & _
                              "@vEmpresa,@vEjercicio,@vMes,@vArea,@vNumero_caja,@vCorrelativo,@vSecuencia,@vCodigo_UI,@vCuenta,@vAnexo_tipo,@vAnexo,@vAvAnexo,@vCentro_costo,@vGlosa," & _
                              "@vBase_imponible_gravada,@vimporte_exonerado,@vimporte_inafecto,@vIgv,@vOtros_tributos,@vImporte_total,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                .AddWithValue("vMes", cCajaChicaDetalle.mes)
                .AddWithValue("vArea", cCajaChicaDetalle.area)
                .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
                .AddWithValue("vSecuencia", cCajaChicaDetalle.secuencia)
                .AddWithValue("vCodigo_UI", cCajaChicaDetalle.codigo_ui)
                .AddWithValue("vCuenta", cCajaChicaDetalle.cuenta)
                .AddWithValue("vAnexo_tipo", cCajaChicaDetalle.anexo_tipo)
                .AddWithValue("vAnexo", cCajaChicaDetalle.anexo)
                .AddWithValue("vAvAnexo", cCajaChicaDetalle.avanexo)
                .AddWithValue("vCentro_costo", cCajaChicaDetalle.centro_costo)
                .AddWithValue("vGlosa", cCajaChicaDetalle.glosa)
                .AddWithValue("vBase_imponible_gravada", cCajaChicaDetalle.base_imponible_gravada)
                .AddWithValue("vimporte_exonerado", cCajaChicaDetalle.importe_exonerado)
                .AddWithValue("vimporte_inafecto", cCajaChicaDetalle.importe_inafecto)
                .AddWithValue("vIgv", cCajaChicaDetalle.igv)
                .AddWithValue("vOtros_tributos", cCajaChicaDetalle.otros_tributos)
                .AddWithValue("vImporte_total", cCajaChicaDetalle.importe_total)
                .AddWithValue("vEstado", cCajaChicaDetalle.estado)
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

                MySql = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
                        "cbase_imponible_gravada=@vBase_imponible_gravada,cimporte_exonerado=@vimporte_exonerado," & _
                        "cimporte_inafecto=@vimporte_inafecto,cigv=@vIgv,cotros_tributos=@vOtros_tributos,cimporte_total=@vImporte_total," & _
                        "cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica " & _
                        "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "
                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vBase_imponible_gravada", vBIG)
                    .AddWithValue("vimporte_exonerado", vIE)
                    .AddWithValue("vimporte_inafecto", vII)
                    .AddWithValue("vIgv", vIGV)
                    .AddWithValue("vOtros_tributos", vOT)
                    .AddWithValue("vImporte_total", vIT)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                    .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                    .AddWithValue("vMes", cCajaChicaDetalle.mes)
                    .AddWithValue("vArea", cCajaChicaDetalle.area)
                    .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                    .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
                End With

                MySQLCommand.ExecuteNonQuery()

                If cCajaChicaDetalle.estado = "A" Then ' Solo si Estado es igual al valor (A)plicar se descuenta contra el Saldo Actual de Caja 
                    If cCajaChicaDetalle.indica_rendicion_cuenta = False Then ' Si no es Rendicion de Cuenta actualizar el Saldo Actual de Caja
                        MySqlString = "UPDATE CON.CAJA_CHICA SET " & _
                                      "saldo_actual=importe_apertura+saldo_anterior-@vTotal_gastos_caja,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                                      "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja "
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vTotal_gastos_caja", MyTotalGastosCaja)
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vFecha_modifica", Now)
                            .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                            .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                            .AddWithValue("vMes", cCajaChicaDetalle.mes)
                            .AddWithValue("vArea", cCajaChicaDetalle.area)
                            .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                        End With
                        MySQLCommand.ExecuteNonQuery()
                    End If
                End If

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return cCajaChicaDetalle

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

    Private Shared Function Actualizar(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As entCajaChicaDetalle

        Dim MySqlString As String
        Dim MyTotalGastosCaja As Decimal = 0

        With cCajaChicaDetalle
            If .estado = "A" Then MyTotalGastosCaja = ObtenerTotalGastosCaja(.empresa, .ejercicio, .mes, .area, .numero_caja, .correlativo)

            MySqlString = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa='" & .empresa & "' AND dejercicio='" & .ejercicio & "' AND dmes='" & .mes & "' " & _
                          "AND darea='" & .area & "' AND dnumero_caja='" & .numero_caja & "' AND dcorrelativo='" & .correlativo & "' AND dsecuencia<>'" & .secuencia & "' "

            Call ObtenerValores(MySqlString)

            vBIG = vBIG + .base_imponible_gravada
            vIE = vIE + .importe_exonerado
            vII = vII + .importe_inafecto
            vIGV = vIGV + .igv
            vOT = vOT + .otros_tributos
            vIT = vIT + .importe_total
            MyTotalGastosCaja = MyTotalGastosCaja + vIT
        End With

        MySqlString = "UPDATE CON.CAJA_CHICA_CABECERA SET " & _
                      "cbase_imponible_gravada=@vBase_imponible_gravada,cimporte_exonerado=@vimporte_exonerado," & _
                      "cimporte_inafecto=@vimporte_inafecto,cigv=@vIgv,cotros_tributos=@vOtros_tributos,cimporte_total=@vImporte_total," & _
                      "cusuario_modifica=@vUsuario_modifica,cfecha_modifica=@vFecha_modifica  " & _
                      "WHERE cempresa=@vEmpresa AND cejercicio=@vEjercicio AND cmes=@vMes AND carea=@vArea AND cnumero_caja=@vNumero_caja AND ccorrelativo=@vCorrelativo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vBase_imponible_gravada", vBIG)
                .AddWithValue("vimporte_exonerado", vIE)
                .AddWithValue("vimporte_inafecto", vII)
                .AddWithValue("vIgv", vIGV)
                .AddWithValue("vOtros_tributos", vOT)
                .AddWithValue("vImporte_total", vIT)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                .AddWithValue("vMes", cCajaChicaDetalle.mes)
                .AddWithValue("vArea", cCajaChicaDetalle.area)
                .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
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

                MySqlString = "UPDATE CON.CAJA_CHICA_DETALLE SET " & _
                              "danexo_tipo=@vAnexo_tipo,danexo=@vAnexo,davanexo=@vAvAnexo,dcentro_costo=@vCentro_costo,dglosa=@vGlosa," & _
                              "dbase_imponible_gravada=@vBase_imponible_gravada,dimporte_exonerado=@vImporte_exonerado," & _
                              "dimporte_inafecto=@vImporte_inafecto,digv=@vIgv,dotros_tributos=@vOtros_tributos,dimporte_total=@vImporte_total," & _
                              "dusuario_modifica=@vUsuario_modifica,dfecha_modifica=@vFecha_modifica " & _
                              "WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dmes=@vMes AND darea=@vArea AND dnumero_caja=@vNumero_caja AND dcorrelativo=@vCorrelativo AND dsecuencia=@vSecuencia "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vAnexo_tipo", cCajaChicaDetalle.anexo_tipo)
                    .AddWithValue("vAnexo", cCajaChicaDetalle.anexo)
                    .AddWithValue("vAvAnexo", cCajaChicaDetalle.avanexo)
                    .AddWithValue("vCentro_costo", cCajaChicaDetalle.centro_costo)
                    .AddWithValue("vGlosa", cCajaChicaDetalle.glosa)
                    .AddWithValue("vBase_imponible_gravada", cCajaChicaDetalle.base_imponible_gravada)
                    .AddWithValue("vimporte_exonerado", cCajaChicaDetalle.importe_exonerado)
                    .AddWithValue("vimporte_inafecto", cCajaChicaDetalle.importe_inafecto)
                    .AddWithValue("vIgv", cCajaChicaDetalle.igv)
                    .AddWithValue("vOtros_tributos", cCajaChicaDetalle.otros_tributos)
                    .AddWithValue("vImporte_total", cCajaChicaDetalle.importe_total)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                    .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                    .AddWithValue("vMes", cCajaChicaDetalle.mes)
                    .AddWithValue("vArea", cCajaChicaDetalle.area)
                    .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                    .AddWithValue("vCorrelativo", cCajaChicaDetalle.correlativo)
                    .AddWithValue("vSecuencia", cCajaChicaDetalle.secuencia)
                End With

                MySQLCommand.ExecuteNonQuery()

                If cCajaChicaDetalle.estado = "A" Then ' Solo si Estado es igual al valor (A)plicar se descuenta contra el Saldo Actual de Caja 
                    If cCajaChicaDetalle.indica_rendicion_cuenta = False Then ' Si no es Rendicion de Cuenta actualizar el Saldo Actual de Caja
                        MySqlString = "UPDATE CON.CAJA_CHICA SET " & _
                                      "saldo_actual=importe_apertura+saldo_anterior-@vTotal_gastos_caja,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                                      "WHERE empresa=@vEmpresa AND ejercicio=@vEjercicio AND mes=@vMes AND area=@vArea AND numero_caja=@vNumero_caja "
                        MySQLCommand.CommandType = CommandType.Text
                        MySQLCommand.CommandText = MySqlString
                        MySQLCommand.Parameters.Clear()
                        With MySQLCommand.Parameters
                            .AddWithValue("vTotal_gastos_caja", MyTotalGastosCaja)
                            .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                            .AddWithValue("vFecha_modifica", Now)
                            .AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
                            .AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
                            .AddWithValue("vMes", cCajaChicaDetalle.mes)
                            .AddWithValue("vArea", cCajaChicaDetalle.area)
                            .AddWithValue("vNumero_caja", cCajaChicaDetalle.numero_caja)
                        End With
                        MySQLCommand.ExecuteNonQuery()
                    End If
                End If

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cCajaChicaDetalle

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

    Private Shared Function Obtener(ByVal cCajaChicaDetalle As entCajaChicaDetalle) As entCajaChicaDetalle
        Dim MyDT As New dsCajaChica.CAJA_CHICA_DETALLEDataTable
        Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dcodigo_ui=@vCodigo_UI "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cCajaChicaDetalle.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", cCajaChicaDetalle.ejercicio)
            MySQLCommand.Parameters.AddWithValue("vCodigo_UI", cCajaChicaDetalle.codigo_ui)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        If MyDT.Count = 0 Then
            cCajaChicaDetalle = New entCajaChicaDetalle
        Else
            With cCajaChicaDetalle
                .empresa = MyDT(0).dempresa
                .ejercicio = MyDT(0).dejercicio
                .mes = MyDT(0).dmes
                .area = MyDT(0).darea
                .numero_caja = MyDT(0).dnumero_caja
                .correlativo = MyDT(0).dcorrelativo
                .secuencia = MyDT(0).dsecuencia
                .codigo_ui = MyDT(0).dcodigo_ui
                .cuenta = MyDT(0).dcuenta
                .anexo_tipo = MyDT(0).danexo_tipo
                .anexo = MyDT(0).danexo
                .avanexo = MyDT(0).davanexo
                .centro_costo = MyDT(0).dcentro_costo
                .glosa = MyDT(0).dglosa

                .base_imponible_gravada = MyDT(0).dbase_imponible_gravada
                .importe_exonerado = MyDT(0).dimporte_exonerado
                .importe_inafecto = MyDT(0).dimporte_inafecto
                .igv = MyDT(0).digv
                .otros_tributos = MyDT(0).dotros_tributos
                .importe_total = MyDT(0).dimporte_total

                .estado = MyDT(0).destado
                .usuario_registro = MyDT(0).dusuario_registro
                .fecha_registro = MyDT(0).dfecha_registro
                If Not MyDT(0).IsNull("CUSUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).dusuario_modifica
                If Not MyDT(0).IsNull("CFECHA_MODIFICA") Then .fecha_modifica = MyDT(0).dfecha_modifica
            End With
        End If
        Return cCajaChicaDetalle
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pCodigo_UI As String) As entCajaChicaDetalle
        If Existe(pEmpresa, pCodigo_UI) Then
            Return ObtenerDetalle(pEmpresa, pEjercicio, pCodigo_UI)
        Else
            Return New entCajaChicaDetalle
        End If
    End Function

    Public Shared Function GenerarSecuenciaCaja(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pArea As String, ByVal pNumeroCaja As String, ByVal pCorrelativo As String) As String
        Dim MyValor As String
        Dim Correlativo As Long
        Dim MyStringSql As String = "SELECT ISNULL(MAX(dsecuencia), '0000') AS MyValor FROM CON.CAJA_CHICA_DETALLE " & _
                                    "WHERE dempresa='" & pEmpresa & "' AND dejercicio='" & pEjercicio & "' AND dmes='" & pMes & "' AND " & _
                                    "darea='" & pArea & "' AND dnumero_caja='" & pNumeroCaja & "' AND dcorrelativo='" & pCorrelativo & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLDbconnection.Open()
            MyValor = MySQLCommand.ExecuteScalar
            Correlativo = CLng(MyValor) + 1
            MyValor = Strings.Right("0000" & Correlativo.ToString.Trim, 4)
        End Using
        Return MyValor
    End Function

    Public Shared Function BuscarDocumentoDetalles(ByVal cCajaChicaCabecera As entCajaChicaCabecera) As dsCajaChica.CAJA_CHICA_DETALLESDataTable
        Dim MyStoreProcedure As String = "CON.CAJA_CHICA_DETALLES"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 4) : MyParameter_1.Value = cCajaChicaCabecera.empresa
        Dim MyParameter_2 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_2.Value = cCajaChicaCabecera.ejercicio
        Dim MyParameter_3 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_3.Value = cCajaChicaCabecera.mes
        Dim MyParameter_4 As New SqlParameter("@AREA", SqlDbType.Char, 6) : MyParameter_4.Value = cCajaChicaCabecera.area
        Dim MyParameter_5 As New SqlParameter("@NUMERO_CAJA", SqlDbType.Char, 4) : MyParameter_5.Value = cCajaChicaCabecera.numero_caja
        Dim MyParameter_6 As New SqlParameter("@CORRELATIVO", SqlDbType.Char, 6) : MyParameter_6.Value = cCajaChicaCabecera.correlativo

        Dim MyDT As New dsCajaChica.CAJA_CHICA_DETALLESDataTable
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

    Public Shared Function ObtenerDetalle(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pCodigo_UI As String) As entCajaChicaDetalle
        Dim MyDT As New dsCajaChica.CAJA_CHICA_DETALLEDataTable
        Dim cCajaChicaDetalle As New entCajaChicaDetalle
        If pCodigo_UI <> CUO_Nulo Then
            Dim MySqlString As String = "SELECT * FROM CON.CAJA_CHICA_DETALLE WHERE dempresa=@vEmpresa AND dejercicio=@vEjercicio AND dcodigo_ui=@vCodigo_UI "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
                MySQLCommand.Parameters.AddWithValue("vCodigo_UI", pCodigo_UI)
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.CommandType = CommandType.Text
                Dim MyDA As New SqlDataAdapter(MySQLCommand)
                MyDA.Fill(MyDT)
            End Using
            If MyDT.Count > 0 Then Call PoblarDetalle(cCajaChicaDetalle, MyDT)
        End If
        Return cCajaChicaDetalle
    End Function

    Private Shared Sub PoblarDetalle(ByRef cCajaChicaDetalle As entCajaChicaDetalle, ByVal MyDT As dsCajaChica.CAJA_CHICA_DETALLEDataTable)
        With cCajaChicaDetalle
            .empresa = MyDT(0).dempresa
            .ejercicio = MyDT(0).dejercicio
            .mes = MyDT(0).dmes
            .area = MyDT(0).darea
            .numero_caja = MyDT(0).dnumero_caja
            .correlativo = MyDT(0).dcorrelativo
            .secuencia = MyDT(0).dsecuencia
            .codigo_ui = MyDT(0).dcodigo_ui
            .cuenta = MyDT(0).dcuenta
            .anexo_tipo = MyDT(0).danexo_tipo
            .anexo = MyDT(0).danexo
            .avanexo = MyDT(0).davanexo
            .centro_costo = MyDT(0).dcentro_costo
            .glosa = MyDT(0).dglosa
            .base_imponible_gravada = MyDT(0).dbase_imponible_gravada
            .importe_exonerado = MyDT(0).dimporte_exonerado
            .importe_inafecto = MyDT(0).dimporte_inafecto
            .igv = MyDT(0).digv
            .otros_tributos = MyDT(0).dotros_tributos
            .importe_total = MyDT(0).dimporte_total
            .importe_total_origen = MyDT(0).dimporte_total
            .estado = MyDT(0).destado
            .usuario_registro = MyDT(0).dusuario_registro
            .fecha_registro = MyDT(0).dfecha_registro
            If Not MyDT(0).IsNull("DUSUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).dusuario_modifica
            If Not MyDT(0).IsNull("DFECHA_MODIFICA") Then .fecha_modifica = MyDT(0).dfecha_modifica
        End With
    End Sub

#End Region

End Class
