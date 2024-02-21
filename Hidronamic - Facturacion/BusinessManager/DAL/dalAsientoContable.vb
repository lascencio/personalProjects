Imports System.Data.SqlClient

Public Class dalAsientoContable

    Private Shared vDebe_Origen, vHaber_Origen, vDebe_MN, vHaber_MN, vDebe_ME, vHaber_ME, vTotal_ME, vRetencion_ME, vNeto_ME As Decimal
    Private Shared cNroFila As String


    Public Shared Function BuscarCuentaCorriente(ByVal pEmpresa As String, ByVal pCuentaCorriente As String, ByVal pTipoTablaCuentaCorriente As String) As dsTablaAnexos.TABLA_ANEXOSDataTable
        Dim MySqlString As String
        If pTipoTablaCuentaCorriente = "TODOS" Then
            MySqlString = "SELECT * FROM CON.TABLA_ANEXOS " & _
                          "WHERE Empresa=@vEmpresa AND Cuenta_corriente=@vCuenta_corriente "
        Else
            MySqlString = "SELECT * FROM CON.TABLA_ANEXOS " & _
                          "WHERE Empresa=@vEmpresa AND Cuenta_corriente=@vCuenta_corriente AND Tipo_tabla_cuenta_corriente=@vTipo_tabla_cuenta_corriente "
        End If

        Dim MyDT As New dsTablaAnexos.TABLA_ANEXOSDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vCuenta_corriente", pCuentaCorriente)
            If pTipoTablaCuentaCorriente <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vTipo_tabla_cuenta_corriente", pTipoTablaCuentaCorriente)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerFecha(ByVal pFecha As Date, ByVal pPeriodo As Long) As Date
        Dim MyFecha As Date

        Dim MySqlString As String = "SELECT UTI.EVAL_FECHA_ASIENTO(@vFecha,@vPeriodo)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vFecha", pFecha)
            MySQLCommand.Parameters.AddWithValue("vPeriodo", pPeriodo)
            MySQLDbconnection.Open()

            MyFecha = MySQLCommand.ExecuteScalar
        End Using
        Return MyFecha
    End Function

    Public Shared Function ObtenerTipoCambio(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pTipo As String) As Decimal
        Dim MyTipoCambio As Decimal = 0

        Dim MySqlString As String = "SELECT ISNULL(" & pTipo & ",0) AS TIPO_CAMBIO FROM GEN.TIPO_CAMBIO " & _
                                    "WHERE EJERCICIO=@vEjercicio AND MES=@vMes AND DIA=@vDia "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vDia", pDia)
            MySQLDbconnection.Open()

            MyTipoCambio = MySQLCommand.ExecuteScalar
        End Using

        Return MyTipoCambio
    End Function

    Private Shared Function AsignarNumeroAsiento(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsientoTipo As String) As String

        Dim MySql As String = "SELECT ISNULL(MAX(ASIENTO_NUMERO),'') AS NUEVO_NUMERO " & _
                              "FROM CON.ASIENTOS_CONTABLES " & _
                              "WHERE EMPRESA='" & pEmpresa & "' AND EJERCICIO='" & pEjercicio & "' AND MES='" & pMes & "' AND ASIENTO_TIPO='" & pAsientoTipo & "' "

        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
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

    Private Shared Sub ObtenerDebeHaber(ByVal MyStringSQL As String, ByVal TipoMoneda As String, ByVal TipoCambio As Decimal)
        Dim MyDT As New dsAsientosContables.ASIENTOS_CONTABLES_DETDataTable
        vDebe_Origen = 0 : vHaber_Origen = 0 : vDebe_MN = 0 : vHaber_MN = 0 : vDebe_ME = 0 : vHaber_ME = 0
        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        If MyDT.Count > 0 Then
            For NEle = 0 To MyDT.Count - 1
                If TipoMoneda = "1" Then
                    vDebe_Origen = vDebe_Origen + MyDT(NEle).DEBE_MN
                    vHaber_Origen = vHaber_Origen + MyDT(NEle).HABER_MN
                    vDebe_MN = vDebe_MN + MyDT(NEle).DEBE_MN
                    vHaber_MN = vHaber_MN + MyDT(NEle).HABER_MN
                    If TipoCambio <> 0 Then
                        vDebe_ME = vDebe_ME + (MyDT(NEle).DEBE_MN / TipoCambio)
                        vHaber_ME = vHaber_ME + (MyDT(NEle).HABER_MN / TipoCambio)
                    End If
                Else
                    vDebe_Origen = vDebe_Origen + MyDT(NEle).DEBE_ME
                    vHaber_Origen = vHaber_Origen + MyDT(NEle).HABER_ME
                    vDebe_ME = vDebe_ME + MyDT(NEle).DEBE_ME
                    vHaber_ME = vHaber_ME + MyDT(NEle).HABER_ME
                    vDebe_MN = vDebe_MN + (MyDT(NEle).DEBE_ME * TipoCambio)
                    vHaber_MN = vHaber_MN + (MyDT(NEle).HABER_ME * TipoCambio)
                End If
            Next
        End If
    End Sub

    Private Shared Sub ObtenerDebeHaberVirtual(ByVal MyDT As dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable)
        vDebe_Origen = 0 : vHaber_Origen = 0 : vDebe_MN = 0 : vHaber_MN = 0 : vDebe_ME = 0 : vHaber_ME = 0
        If MyDT.Count > 0 Then
            For NEle = 0 To MyDT.Count - 1
                If MyDT(NEle).TIPO_MONEDA = "1" Then
                    vDebe_Origen = vDebe_Origen + MyDT(NEle).DEBE_MN
                    vHaber_Origen = vHaber_Origen + MyDT(NEle).HABER_MN
                    vDebe_MN = vDebe_MN + MyDT(NEle).DEBE_MN
                    vHaber_MN = vHaber_MN + MyDT(NEle).HABER_MN
                    If MyDT(NEle).TIPO_CAMBIO <> 0 Then
                        vDebe_ME = vDebe_ME + (MyDT(NEle).DEBE_MN / MyDT(NEle).TIPO_CAMBIO)
                        vHaber_ME = vHaber_ME + (MyDT(NEle).HABER_MN / MyDT(NEle).TIPO_CAMBIO)
                    End If
                Else
                    vDebe_Origen = vDebe_Origen + MyDT(NEle).DEBE_ME
                    vHaber_Origen = vHaber_Origen + MyDT(NEle).HABER_ME
                    vDebe_ME = vDebe_ME + MyDT(NEle).DEBE_ME
                    vHaber_ME = vHaber_ME + MyDT(NEle).HABER_ME
                    vDebe_MN = vDebe_MN + (MyDT(NEle).DEBE_ME * MyDT(NEle).TIPO_CAMBIO)
                    vHaber_MN = vHaber_MN + (MyDT(NEle).HABER_ME * MyDT(NEle).TIPO_CAMBIO)
                End If
            Next
        End If
    End Sub

    Public Shared Function Grabar(ByVal cAsientoContable As entAsientoContable) As entAsientoContable
        Dim MyOtroAsiento_numero As New entAsientoContable
        With cAsientoContable
            If String.IsNullOrEmpty(.glosa.Trim) Then Throw New BusinessException(MSG000 & " GLOSA DE LA CABECERA")
            If Year(.movimientos_fecha) * 100 + Month(.movimientos_fecha) = 190001 Then Throw New BusinessException(MSG000 & " F. OPERACION")
        End With

        If Not Existe(cAsientoContable) Then
            Return Insertar(cAsientoContable)
        Else
            Return Actualizar(cAsientoContable)
        End If
    End Function

    Private Shared Function Existe(ByVal cAsientoContable As entAsientoContable) As Boolean
        If Not String.IsNullOrEmpty(cAsientoContable.asiento_numero) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ASIENTOS_CONTABLES " & _
                                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                        "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cAsientoContable.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cAsientoContable.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cAsientoContable.mes)
                MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", cAsientoContable.asiento_tipo)
                MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", cAsientoContable.asiento_numero)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Insertar(ByVal cAsientoContable As entAsientoContable) As entAsientoContable
        With cAsientoContable
            .asiento_numero = AsignarNumeroAsiento(MyUsuario.empresa, .ejercicio, .mes, .asiento_tipo)
        End With

        Dim MySql As String = "INSERT INTO CON.ASIENTOS_CONTABLES " & _
                              "(EMPRESA, EJERCICIO, MES, ASIENTO_TIPO, ASIENTO_NUMERO, ASIENTO_FECHA, TIPO_MONEDA, TIPO_CAMBIO, GLOSA, DEBE_ORIGEN, HABER_ORIGEN," & _
                              "DEBE_MN, HABER_MN, DEBE_ME, HABER_ME, ORIGEN, REFERENCIA_CUO, RENDICION_ANEXO, RENDICION_NUMERO, RENDICION_FECHA, ESTADO, " & _
                              "INDICA_BLOQUEADO, USUARIO_BLOQUEO, FECHA_BLOQUEO, USUARIO_REGISTRO, FECHA_REGISTRO, MOVIMIENTOS_FECHA, MOVIMIENTOS_TIPO_CAMBIO, " & _
                              "ORIGEN_FONDOS, CUENTA_CORRIENTE, TIPO_MEDIO_PAGO, DOCUMENTO_PAGO, IMPORTE_PAGO, ITEM_FLUJO) " & _
                              "VALUES (@vEmpresa,@vEjercicio,@vMes,@vAsiento_tipo,@vAsiento_numero,@vAsiento_fecha,@vTipo_moneda,@vTipo_cambio,@vGlosa,@vDebe_origen,@vHaber_origen," & _
                              "@vDebe_mn,@vHaber_mn,@vDebe_me,@vHaber_me,@vOrigen,@vReferencia_CUO,@vRendicion_anexo,@vRendicion_numero,@vRendicion_fecha,@vEstado," & _
                              "@vIndica_bloqueado,@vUsuario_bloqueo,@vFecha_bloqueo,@vUsuario_registro,@vFecha_registro,@vMovimientos_fecha,@vMovimientos_tipo_cambio," & _
                              "@vOrigen_fondos,@vCuenta_corriente,@vTipo_medio_pago,@vDocumento_pago,@vImporte_pago,@vItem_flujo) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cAsientoContable.empresa)
                .AddWithValue("vEjercicio", cAsientoContable.ejercicio)
                .AddWithValue("vMes", cAsientoContable.mes)
                .AddWithValue("vAsiento_tipo", cAsientoContable.asiento_tipo)
                .AddWithValue("vAsiento_numero", cAsientoContable.asiento_numero)
                .AddWithValue("vAsiento_fecha", cAsientoContable.asiento_fecha)
                .AddWithValue("vTipo_moneda", cAsientoContable.tipo_moneda)
                .AddWithValue("vTipo_cambio", cAsientoContable.tipo_cambio)
                .AddWithValue("vGlosa", Strings.Left(cAsientoContable.glosa, 60))
                .AddWithValue("vDebe_origen", cAsientoContable.debe_origen)
                .AddWithValue("vHaber_origen", cAsientoContable.haber_origen)
                .AddWithValue("vDebe_mn", cAsientoContable.debe_mn)
                .AddWithValue("vHaber_mn", cAsientoContable.haber_mn)
                .AddWithValue("vDebe_me", cAsientoContable.debe_me)
                .AddWithValue("vHaber_me", cAsientoContable.haber_me)
                .AddWithValue("vOrigen", cAsientoContable.origen)
                .AddWithValue("vReferencia_CUO", cAsientoContable.referencia_CUO)
                .AddWithValue("vRendicion_anexo", cAsientoContable.rendicion_anexo)
                .AddWithValue("vRendicion_numero", cAsientoContable.rendicion_numero)
                .AddWithValue("vRendicion_fecha", cAsientoContable.rendicion_fecha)
                .AddWithValue("vEstado", cAsientoContable.estado)
                .AddWithValue("vIndica_bloqueado", cAsientoContable.indica_bloqueado)
                .AddWithValue("vUsuario_bloqueo", cAsientoContable.usuario_bloqueo)
                .AddWithValue("vFecha_bloqueo", cAsientoContable.fecha_bloqueo)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                .AddWithValue("vFecha_registro", Now)
                .AddWithValue("vMovimientos_fecha", cAsientoContable.movimientos_fecha)
                .AddWithValue("vMovimientos_tipo_cambio", cAsientoContable.movimientos_tipo_cambio)
                .AddWithValue("vOrigen_fondos", cAsientoContable.origen_fondos)
                .AddWithValue("vCuenta_corriente", cAsientoContable.cuenta_corriente)
                .AddWithValue("vTipo_medio_pago", cAsientoContable.tipo_medio_pago)
                .AddWithValue("vDocumento_pago", cAsientoContable.documento_pago)
                .AddWithValue("vImporte_pago", cAsientoContable.importe_pago)
                .AddWithValue("vItem_flujo", cAsientoContable.item_flujo)
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

                Return cAsientoContable

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

    Private Shared Function Actualizar(ByVal cAsientoContable As entAsientoContable) As entAsientoContable

        Dim MyStringSQL As String = "SELECT * FROM CON.ASIENTOS_CONTABLES_DET " & _
                                    "WHERE EMPRESA='" & cAsientoContable.empresa & "' AND EJERCICIO='" & cAsientoContable.ejercicio & "' AND MES='" & cAsientoContable.mes & "' AND " & _
                                    "ASIENTO_TIPO='" & cAsientoContable.asiento_tipo & "' AND ASIENTO_NUMERO='" & cAsientoContable.asiento_numero & "' "

        'Evaluar si el asiento a sido anulado
        If cAsientoContable.estado = "N" Then
            vDebe_Origen = 0 : vHaber_Origen = 0 : vDebe_MN = 0 : vHaber_MN = 0 : vDebe_ME = 0 : vHaber_ME = 0
        Else
            Call ObtenerDebeHaber(MyStringSQL, cAsientoContable.tipo_moneda, cAsientoContable.movimientos_tipo_cambio)
        End If

        Dim MySqlString As String = "UPDATE CON.ASIENTOS_CONTABLES SET " & _
        "Tipo_moneda=@vTipo_moneda,Tipo_cambio=@vTipo_cambio,Glosa=@vGlosa,Debe_origen=@vDebe_origen,Haber_origen=@vHaber_origen," & _
        "Debe_mn=@vDebe_mn,Haber_mn=@vHaber_mn,Debe_me=@vDebe_me,Haber_me=@vHaber_me,Origen=@vOrigen,Referencia_CUO=@vReferencia_CUO," & _
        "Rendicion_anexo=@vRendicion_anexo,Rendicion_numero=@vRendicion_numero,Rendicion_fecha=@vRendicion_fecha,Estado=@vEstado," & _
        "Indica_bloqueado=@vIndica_bloqueado,Usuario_bloqueo=@vUsuario_bloqueo,Fecha_bloqueo=@vFecha_bloqueo,Usuario_modifica=@vUsuario_modifica," & _
        "Fecha_modifica=@vFecha_modifica,Movimientos_fecha=@vMovimientos_fecha,Movimientos_tipo_cambio=@vMovimientos_tipo_cambio,Origen_fondos=@vOrigen_fondos," & _
        "Cuenta_corriente=@vCuenta_corriente,Tipo_medio_pago=@vTipo_medio_pago,Documento_pago=@vDocumento_pago,Importe_pago=@vImporte_pago,Item_flujo=@vItem_flujo " & _
        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND Asiento_tipo=@vAsiento_tipo AND Asiento_numero=@vAsiento_numero "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vTipo_moneda", cAsientoContable.tipo_moneda)
                .AddWithValue("vTipo_cambio", cAsientoContable.tipo_cambio)
                .AddWithValue("vGlosa", Strings.Left(cAsientoContable.glosa, 60))
                .AddWithValue("vDebe_origen", vDebe_Origen)
                .AddWithValue("vHaber_origen", vHaber_Origen)
                .AddWithValue("vDebe_mn", vDebe_MN)
                .AddWithValue("vHaber_mn", vHaber_MN)
                .AddWithValue("vDebe_me", vDebe_ME)
                .AddWithValue("vHaber_me", vHaber_ME)
                .AddWithValue("vOrigen", cAsientoContable.origen)
                .AddWithValue("vReferencia_CUO", cAsientoContable.referencia_CUO)
                .AddWithValue("vRendicion_anexo", cAsientoContable.rendicion_anexo)
                .AddWithValue("vRendicion_numero", cAsientoContable.rendicion_numero)
                .AddWithValue("vRendicion_fecha", cAsientoContable.rendicion_fecha)
                .AddWithValue("vEstado", cAsientoContable.estado)
                .AddWithValue("vIndica_bloqueado", cAsientoContable.indica_bloqueado)
                .AddWithValue("vUsuario_bloqueo", cAsientoContable.usuario_bloqueo)
                .AddWithValue("vFecha_bloqueo", cAsientoContable.fecha_bloqueo)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vMovimientos_fecha", cAsientoContable.movimientos_fecha)
                .AddWithValue("vMovimientos_tipo_cambio", cAsientoContable.movimientos_tipo_cambio)
                .AddWithValue("vOrigen_fondos", cAsientoContable.origen_fondos)
                .AddWithValue("vCuenta_corriente", cAsientoContable.cuenta_corriente)
                .AddWithValue("vTipo_medio_pago", cAsientoContable.tipo_medio_pago)
                .AddWithValue("vDocumento_pago", cAsientoContable.documento_pago)
                .AddWithValue("vImporte_pago", cAsientoContable.importe_pago)
                .AddWithValue("vItem_flujo", cAsientoContable.item_flujo)
                .AddWithValue("vEmpresa", cAsientoContable.empresa)
                .AddWithValue("vEjercicio", cAsientoContable.ejercicio)
                .AddWithValue("vMes", cAsientoContable.mes)
                .AddWithValue("vAsiento_tipo", cAsientoContable.asiento_tipo)
                .AddWithValue("vAsiento_numero", cAsientoContable.asiento_numero)
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

                If cAsientoContable.estado = "N" Then 'Si el asiento esta anulado eliminamos sus detalles
                    MySqlString = "DELETE FROM CON.ASIENTOS_CONTABLES_DET " & _
                                  "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                  "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "
                Else
                    If cAsientoContable.tipo_moneda = "1" Then
                        If cAsientoContable.movimientos_tipo_cambio = 0 Then
                            MySqlString = "UPDATE CON.ASIENTOS_CONTABLES_DET " & _
                                          "SET Tipo_moneda=@vTipo_moneda, Tipo_Cambio=@vTipo_Cambio,Comprobante_fecha=@vComprobante_fecha," & _
                                          "Debe_ME=0,Haber_ME=0,Estado=@vEstado " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                          "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "
                        Else
                            MySqlString = "UPDATE CON.ASIENTOS_CONTABLES_DET " & _
                                          "SET Tipo_moneda=@vTipo_moneda, Tipo_Cambio=@vTipo_Cambio,Comprobante_fecha=@vComprobante_fecha," & _
                                          "Debe_ME=ROUND(Debe_MN/@vTipo_Cambio,2),Haber_ME=ROUND(Haber_MN/@vTipo_Cambio,2),Estado=@vEstado " & _
                                          "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                          "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "
                        End If
                    Else
                        MySqlString = "UPDATE CON.ASIENTOS_CONTABLES_DET " & _
                                      "SET Tipo_moneda=@vTipo_moneda, Tipo_Cambio=@vTipo_Cambio,Comprobante_fecha=@vComprobante_fecha," & _
                                      "Debe_MN=ROUND(Debe_ME*@vTipo_Cambio,2),Haber_MN=ROUND(Haber_ME*@vTipo_Cambio,2),Estado=@vEstado  " & _
                                      "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                      "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "
                    End If
                End If

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vTipo_moneda", cAsientoContable.tipo_moneda)
                MySQLCommand.Parameters.AddWithValue("vTipo_cambio", cAsientoContable.movimientos_tipo_cambio)
                MySQLCommand.Parameters.AddWithValue("vComprobante_fecha", cAsientoContable.movimientos_fecha)
                MySQLCommand.Parameters.AddWithValue("vEstado", cAsientoContable.estado)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cAsientoContable.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cAsientoContable.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cAsientoContable.mes)
                MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", cAsientoContable.asiento_tipo)
                MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", cAsientoContable.asiento_numero)

                MySQLCommand.ExecuteNonQuery()


                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cAsientoContable

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

    Public Shared Function InsertarDetallesVirtual(ByVal cAsientoContableDetalle As dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable) As Boolean
        Dim MySqlString As String = "DELETE FROM CON.ASIENTOS_CONTABLES_DET " & _
                                    "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                                    "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cAsientoContableDetalle(0).EMPRESA)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", cAsientoContableDetalle(0).EJERCICIO)
            MySQLCommand.Parameters.AddWithValue("vMes", cAsientoContableDetalle(0).MES)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", cAsientoContableDetalle(0).ASIENTO_TIPO)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", cAsientoContableDetalle(0).ASIENTO_NUMERO)
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                For NEle = 0 To cAsientoContableDetalle.Rows.Count - 1
                    cNroFila = Strings.Right("0000" & CStr(NEle + 1), 4)
                    MySqlString = "INSERT INTO CON.ASIENTOS_CONTABLES_DET " & _
                                  "(EMPRESA, EJERCICIO, MES, ASIENTO_TIPO, ASIENTO_NUMERO, ASIENTO_LINEA, ASIENTO_FECHA, CUENTA_CONTABLE, TIPO_MONEDA, TIPO_CAMBIO, GLOSA," & _
                                  "CUENTA_CORRIENTE, COMPROBANTE_TIPO, COMPROBANTE_SERIE, COMPROBANTE_NUMERO, COMPROBANTE_FECHA, COMPROBANTE_VENCIMIENTO," & _
                                  "DEBE_ORIGEN, HABER_ORIGEN, DEBE_MN, HABER_MN, DEBE_ME, HABER_ME, CENTRO_COSTO, PROYECTO," & _
                                  "USUARIO_REGISTRO, FECHA_REGISTRO,USUARIO_MODIFICA, FECHA_MODIFICA) " & _
                                  "VALUES (@vEmpresa,@vEjercicio,@vMes,@vAsiento_tipo,@vAsiento_numero,@vAsiento_linea,@vAsiento_fecha,@vCuenta_contable,@vTipo_moneda,@vTipo_cambio,@vGlosa," & _
                                  "@vCuenta_corriente,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento," & _
                                  "@vDebe_origen,@vHaber_origen,@vDebe_mn,@vHaber_mn,@vDebe_me,@vHaber_me,@vCentro_costo,@vProyecto," & _
                                  "@vUsuario_registro,@vFecha_registro,@vUsuario_modifica,@vFecha_modifica) "

                    MySQLCommand.CommandType = CommandType.Text
                    MySQLCommand.CommandText = MySqlString
                    MySQLCommand.Parameters.Clear()

                    With MySQLCommand.Parameters
                        .AddWithValue("vEmpresa", cAsientoContableDetalle(NEle).EMPRESA)
                        .AddWithValue("vEjercicio", cAsientoContableDetalle(NEle).EJERCICIO)
                        .AddWithValue("vMes", cAsientoContableDetalle(NEle).MES)
                        .AddWithValue("vAsiento_tipo", cAsientoContableDetalle(NEle).ASIENTO_TIPO)
                        .AddWithValue("vAsiento_numero", cAsientoContableDetalle(NEle).ASIENTO_NUMERO)
                        .AddWithValue("vAsiento_linea", cNroFila)
                        .AddWithValue("vAsiento_fecha", cAsientoContableDetalle(NEle).ASIENTO_FECHA)
                        .AddWithValue("vCuenta_contable", cAsientoContableDetalle(NEle).CUENTA_CONTABLE)
                        .AddWithValue("vTipo_moneda", cAsientoContableDetalle(NEle).TIPO_MONEDA)
                        .AddWithValue("vTipo_cambio", cAsientoContableDetalle(NEle).TIPO_CAMBIO)
                        .AddWithValue("vGlosa", cAsientoContableDetalle(NEle).GLOSA)
                        .AddWithValue("vCuenta_corriente", cAsientoContableDetalle(NEle).CUENTA_CORRIENTE)
                        .AddWithValue("vComprobante_tipo", cAsientoContableDetalle(NEle).COMPROBANTE_TIPO)
                        .AddWithValue("vComprobante_serie", cAsientoContableDetalle(NEle).COMPROBANTE_SERIE)
                        .AddWithValue("vComprobante_numero", cAsientoContableDetalle(NEle).COMPROBANTE_NUMERO)
                        .AddWithValue("vComprobante_fecha", cAsientoContableDetalle(NEle).COMPROBANTE_FECHA)
                        .AddWithValue("vComprobante_vencimiento", cAsientoContableDetalle(NEle).COMPROBANTE_VENCIMIENTO)
                        .AddWithValue("vDebe_origen", cAsientoContableDetalle(NEle).DEBE_ORIGEN)
                        .AddWithValue("vHaber_origen", cAsientoContableDetalle(NEle).HABER_ORIGEN)
                        .AddWithValue("vDebe_mn", cAsientoContableDetalle(NEle).DEBE_MN)
                        .AddWithValue("vHaber_mn", cAsientoContableDetalle(NEle).HABER_MN)
                        .AddWithValue("vDebe_me", cAsientoContableDetalle(NEle).DEBE_ME)
                        .AddWithValue("vHaber_me", cAsientoContableDetalle(NEle).HABER_ME)
                        .AddWithValue("vCentro_costo", cAsientoContableDetalle(NEle).CENTRO_COSTO)
                        .AddWithValue("vProyecto", cAsientoContableDetalle(NEle).PROYECTO)
                        .AddWithValue("vUsuario_registro", cAsientoContableDetalle(NEle).USUARIO_REGISTRO)
                        .AddWithValue("vFecha_registro", cAsientoContableDetalle(NEle).FECHA_REGISTRO)
                        .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                        .AddWithValue("vFecha_modifica", Now)
                    End With

                    MySQLCommand.ExecuteNonQuery()
                Next

                Call ObtenerDebeHaberVirtual(cAsientoContableDetalle)

                MySqlString = "UPDATE CON.ASIENTOS_CONTABLES SET " & _
                              "Debe_origen=@vDebe_origen,Haber_origen=@vHaber_origen,Debe_mn=@vDebe_mn,Haber_mn=@vHaber_mn,Debe_me=@vDebe_me,Haber_me=@vHaber_me," & _
                              "Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
                              "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Mes=@vMes AND " & _
                              "Asiento_Tipo=@vAsiento_Tipo AND Asiento_Numero=@vAsiento_Numero "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vDebe_origen", vDebe_Origen)
                    .AddWithValue("vHaber_origen", vHaber_Origen)
                    .AddWithValue("vDebe_mn", vDebe_MN)
                    .AddWithValue("vHaber_mn", vHaber_MN)
                    .AddWithValue("vDebe_me", vDebe_ME)
                    .AddWithValue("vHaber_me", vHaber_ME)
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", cAsientoContableDetalle(0).EMPRESA)
                    .AddWithValue("vEjercicio", cAsientoContableDetalle(0).EJERCICIO)
                    .AddWithValue("vMes", cAsientoContableDetalle(0).MES)
                    .AddWithValue("vAsiento_Tipo", cAsientoContableDetalle(0).ASIENTO_TIPO)
                    .AddWithValue("vAsiento_numero", cAsientoContableDetalle(0).ASIENTO_NUMERO)
                End With

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

End Class
