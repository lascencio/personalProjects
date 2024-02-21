Imports System.Data.SqlClient

Public Class dalAgencia

    Private Shared MySqlString As String
    Private Shared MyStoreProcedure As String
    Private Shared MyCount As Integer

    Private Shared MySQLCommand As SqlCommand

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pAgencia As String) As dsAgencias.AGENCIASDataTable
        Dim MyDT As New dsAgencias.AGENCIASDataTable
        CadenaSQL = "SELECT * FROM COM.AGENCIAS WHERE EMPRESA='" & pEmpresa & "' AND AGENCIA='" & pAgencia & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function


End Class
