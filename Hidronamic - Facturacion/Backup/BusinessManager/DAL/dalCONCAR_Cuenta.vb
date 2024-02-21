Imports System.Data.SqlClient

Public Class dalCONCAR_Cuenta

    Private Shared Function ExisteCuentaContable(ByVal pCuentaContable As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaContable) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CUENTAS_CONTABLES WHERE pcuenta=@vCuenta_contable "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vCuenta_contable", pCuentaContable)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Obtener(ByVal cCuentaContable As entCONCAR_Cuenta, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entCONCAR_Cuenta
        Dim MyDT As New dsCONCAR_Cuentas.CUENTAS_CONTABLESDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaContable
                .pcuenta = MyDT(0).pcuenta
                .pdescri = MyDT(0).pdescri
                .pvanexo = MyDT(0).pvanexo
                .pmonref = MyDT(0).pmonref
                .pctacar = MyDT(0).pctacar
                .pctaabo = MyDT(0).pctaabo
                .pvcencos = MyDT(0).pvcencos
                .pvregcta = MyDT(0).pvregcta
                .pvtipcta = MyDT(0).pvtipcta
                .pvarea = MyDT(0).pvarea
                .pestado = MyDT(0).pestado
            End With
        End If
        Return cCuentaContable
    End Function

    Public Shared Function ObtenerCuentaContable(ByVal pCuentaContable As String) As entCONCAR_Cuenta
        If ExisteCuentaContable(pCuentaContable) Then
            CadenaSQL = "SELECT pcuenta, pdescri, pvanexo, pmonref, pctacar, pctaabo, pvcencos, pvregcta, pvtipcta, pvarea, pestado " & _
                        "FROM CON.CUENTAS_CONTABLES WHERE pcuenta='" & pCuentaContable & "' "
            Return Obtener(New entCONCAR_Cuenta, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Cuenta
        End If
    End Function

    Public Shared Function BuscarCuentaCodigo(ByVal pCuentaContable As String, ByVal pTipoCuenta As String, ByVal pSoloImputables As Boolean) As DataTable
        Dim MySqlString As String = "SELECT pcuenta, pdescri, pvanexo, pmonref, pctacar, pctaabo, pvcencos, pvregcta, pvtipcta, pvarea, pestado " & _
                                    "FROM CON.CUENTAS_CONTABLES WHERE pcuenta LIKE @vCuenta_contable+'%' "
        If pTipoCuenta = "INGRESO" Then
            MySqlString = MySqlString & " AND pcuenta LIKE '70%' "
        ElseIf pTipoCuenta = "GASTO" Then
            MySqlString = MySqlString & " AND pcuenta LIKE '6%' "
        ElseIf pTipoCuenta = "REEMBOLSO" Then
            MySqlString = MySqlString & " AND (LEFT(pcuenta,1)='6' OR LEFT(pcuenta,2) IN ('41','42')) "
        End If
        If pSoloImputables = True Then MySqlString = MySqlString & " AND LEN(RTRIM(pcuenta))=6 "
        MySqlString = MySqlString & " ORDER BY pcuenta "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vCuenta_contable", pCuentaContable.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarCuentaNombre(ByVal pDescripcion As String, ByVal pTipoCuenta As String, ByVal pSoloImputables As Boolean) As DataTable
        Dim MySqlString As String = "SELECT pcuenta, pdescri, pvanexo, pmonref, pctacar, pctaabo, pvcencos, pvregcta, pvtipcta, pvarea, pestado " & _
                                    "FROM CON.CUENTAS_CONTABLES WHERE pdescri LIKE '%'+@vDescripcion+'%' "
        If pTipoCuenta = "INGRESO" Then
            MySqlString = MySqlString & " AND pcuenta LIKE '70%' "
        ElseIf pTipoCuenta = "GASTO" Then
            MySqlString = MySqlString & " AND pcuenta LIKE '6%' "
        ElseIf pTipoCuenta = "REEMBOLSO" Then
            MySqlString = MySqlString & " AND (LEFT(pcuenta,1)='6' OR LEFT(pcuenta,2) IN ('41','42'))  "
        End If
        If pSoloImputables = True Then MySqlString = MySqlString & " AND LEN(RTRIM(pcuenta))=6 "
        MySqlString = MySqlString & " ORDER BY pdescri "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vDescripcion", pDescripcion.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
