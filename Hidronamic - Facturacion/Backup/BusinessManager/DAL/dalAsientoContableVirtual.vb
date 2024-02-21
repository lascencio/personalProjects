Imports System.Data.SqlClient

Public Class dalAsientoContableVirtual

    Private Sub New()
    End Sub

    Public Shared Function ObtenerCabecera(ByVal pEmpresa As String, ByVal pCUO As String, ByVal pAsiento_Tipo As String) As dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable
        Dim MyStoreProcedure As String = "CON.ASIENTOS_CABECERA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUO", SqlDbType.Char, 12) : MyParameter_2.Value = pCUO
        Dim MyParameter_3 As New SqlParameter("@ASIENTO_TIPO", SqlDbType.Char, 2) : MyParameter_3.Value = pAsiento_Tipo

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable

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

    Public Shared Function ObtenerDetalles(ByVal pEmpresa As String, ByVal pCUO As String, ByVal pAsiento_Tipo As String) As dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable
        Dim MyStoreProcedure As String = "CON.ASIENTOS_DETALLE"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUO", SqlDbType.Char, 12) : MyParameter_2.Value = pCUO
        Dim MyParameter_3 As New SqlParameter("@ASIENTO_TIPO", SqlDbType.Char, 2) : MyParameter_3.Value = pAsiento_Tipo

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable

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

    Public Shared Function ObtenerCabeceraHonorarios(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsiento_Tipo As String, ByVal pAsiento_Numero As String) As dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable

        Dim MySqlString As String = "SELECT EMPRESA, EJERCICIO, MES, ASIENTO_FECHA, ASIENTO_TIPO, ASIENTO_NUMERO," & _
                                        "TIPO_MONEDA, GLOSA, DEBE_ORIGEN, HABER_ORIGEN, DEBE_MN, HABER_MN, DEBE_ME, HABER_ME, TIPO_CAMBIO, REFERENCIA_CUO," & _
                                        "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA, NRO_RUC, BENEFICIARIO " & _
                                        "FROM CON.ASIENTOS_CABECERA_HONORARIOS " & _
                                        "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND MES=@vMes AND ASIENTO_TIPO=@vAsiento_Tipo AND ASIENTO_NUMERO=@vAsiento_Numero"

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", pAsiento_Tipo)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", pAsiento_Numero)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function ObtenerDetallesHonorarios(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsiento_Tipo As String, ByVal pAsiento_Numero As String) As dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable

        Dim MySqlString As String = "SELECT A.EMPRESA, A.EJERCICIO, A.MES, A.ASIENTO_FECHA, A.ASIENTO_TIPO, A.ASIENTO_NUMERO," & _
                                    "RIGHT('0000'+CONVERT(VARCHAR,ROW_NUMBER() OVER (ORDER BY LINEA)),4) AS ASIENTO_LINEA," & _
                                    "A.TIPO_MONEDA, A.CUENTA_CONTABLE, C.NOMBRE_CUENTA_CONTABLE, A.GLOSA," & _
                                    "A.CUENTA_CORRIENTE, A.COMPROBANTE_TIPO, A.COMPROBANTE_SERIE, A.COMPROBANTE_NUMERO, A.COMPROBANTE_FECHA, A.COMPROBANTE_VENCIMIENTO," & _
                                    "A.DEBE_ORIGEN, A.HABER_ORIGEN, A.DEBE_MN, A.HABER_MN, A.DEBE_ME, A.HABER_ME, A.TIPO_CAMBIO, A.CENTRO_COSTO, A.PROYECTO, A.USUARIO_REGISTRO," & _
                                    "A.FECHA_REGISTRO, A.USUARIO_MODIFICA, A.FECHA_MODIFICA, A.NRO_RUC " & _
                                    "FROM CON.ASIENTOS_DETALLE_HONORARIOS AS A INNER JOIN CON.CUENTAS_CONTABLES AS C ON A.EMPRESA=C.EMPRESA AND A.CUENTA_CONTABLE=C.CUENTA_CONTABLE " & _
                                    "WHERE A.EMPRESA=@vEmpresa AND A.EJERCICIO=@vEjercicio AND A.MES=@vMes AND A.ASIENTO_TIPO=@vAsiento_Tipo AND A.ASIENTO_NUMERO=@vAsiento_Numero AND A.DEBE_ORIGEN+A.HABER_ORIGEN<>0"

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", pAsiento_Tipo)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", pAsiento_Numero)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function ObtenerCabeceraCompras(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsiento_Tipo As String, ByVal pAsiento_Numero As String) As dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable

        Dim MySqlString As String = "SELECT EMPRESA, EJERCICIO, MES, ASIENTO_FECHA, ASIENTO_TIPO, ASIENTO_NUMERO," & _
                                        "TIPO_MONEDA, GLOSA, DEBE_ORIGEN, HABER_ORIGEN, DEBE_MN, HABER_MN, DEBE_ME, HABER_ME, TIPO_CAMBIO, REFERENCIA_CUO," & _
                                        "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA, NRO_RUC, BENEFICIARIO " & _
                                        "FROM CON.ASIENTOS_CABECERA_COMPRAS " & _
                                        "WHERE EMPRESA=@vEmpresa AND EJERCICIO=@vEjercicio AND MES=@vMes AND ASIENTO_TIPO=@vAsiento_Tipo AND ASIENTO_NUMERO=@vAsiento_Numero"

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_CABECERADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", pAsiento_Tipo)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", pAsiento_Numero)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function ObtenerDetallesCompras(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pAsiento_Tipo As String, ByVal pAsiento_Numero As String) As dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable

        Dim MySqlString As String = "SELECT A.EMPRESA, A.EJERCICIO, A.MES, A.ASIENTO_FECHA, A.ASIENTO_TIPO, A.ASIENTO_NUMERO," & _
                                    "RIGHT('0000'+CONVERT(VARCHAR,ROW_NUMBER() OVER (ORDER BY LINEA)),4) AS ASIENTO_LINEA," & _
                                    "A.TIPO_MONEDA, A.CUENTA_CONTABLE, C.NOMBRE_CUENTA_CONTABLE, A.GLOSA," & _
                                    "A.CUENTA_CORRIENTE, A.COMPROBANTE_TIPO, A.COMPROBANTE_SERIE, A.COMPROBANTE_NUMERO, A.COMPROBANTE_FECHA, A.COMPROBANTE_VENCIMIENTO," & _
                                    "A.DEBE_ORIGEN, A.HABER_ORIGEN, A.DEBE_MN, A.HABER_MN, A.DEBE_ME, A.HABER_ME, A.TIPO_CAMBIO, A.CENTRO_COSTO, A.PROYECTO, A.USUARIO_REGISTRO," & _
                                    "A.FECHA_REGISTRO, A.USUARIO_MODIFICA, A.FECHA_MODIFICA, A.NRO_RUC " & _
                                    "FROM CON.ASIENTOS_DETALLE_VENTAS AS A INNER JOIN CON.CUENTAS_CONTABLES AS C ON A.EMPRESA=C.EMPRESA AND A.CUENTA_CONTABLE=C.CUENTA_CONTABLE " & _
                                    "WHERE A.EMPRESA=@vEmpresa AND A.EJERCICIO=@vEjercicio AND A.MES=@vMes AND A.ASIENTO_TIPO=@vAsiento_Tipo AND A.ASIENTO_NUMERO=@vAsiento_Numero AND A.DEBE_ORIGEN+A.HABER_ORIGEN<>0"

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_DETALLEDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Tipo", pAsiento_Tipo)
            MySQLCommand.Parameters.AddWithValue("vAsiento_Numero", pAsiento_Numero)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function ObtenerDetallesVirtual(ByVal pEmpresa As String, ByVal pTipoAsiento As String, ByVal pCUO As String) As dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable
        Dim MySqlString As String = "SELECT EMPRESA, EJERCICIO, MES, ASIENTO_FECHA, ASIENTO_TIPO, ASIENTO_NUMERO, LINEA AS ASIENTO_LINEA," & _
                                    "TIPO_MONEDA, CUENTA_CONTABLE, SPACE(1) AS NOMBRE_CUENTA_CONTABLE, GLOSA, CUENTA_CORRIENTE, COMPROBANTE_TIPO, COMPROBANTE_SERIE, " & _
                                    "COMPROBANTE_NUMERO, COMPROBANTE_FECHA, COMPROBANTE_VENCIMIENTO, DEBE_ORIGEN, HABER_ORIGEN, DEBE_MN, HABER_MN, " & _
                                    "DEBE_ME, HABER_ME, TIPO_CAMBIO, CENTRO_COSTO, PROYECTO, USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA, SPACE(1) AS NRO_RUC "

        Select Case pTipoAsiento
            Case Is = "05"
                MySqlString = MySqlString & "FROM CON.ASIENTOS_DETALLE_VENTAS " & _
                              "WHERE EMPRESA=@vEmpresa AND VENTA=@vCUO AND DEBE_ORIGEN+HABER_ORIGEN<>0 "
            Case Is = "16"
                MySqlString = MySqlString & "FROM CON.ASIENTOS_DETALLE_HONORARIOS " & _
                              "WHERE EMPRESA=@vEmpresa AND HONORARIO=@vCUO AND DEBE_ORIGEN+HABER_ORIGEN<>0 "
        End Select

        Dim MyDT As New dsAsientosContablesVirtual.ASIENTOS_DETALLE_VENTASDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vCUO", pCUO)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

End Class
