Imports System.Data.SqlClient

Public Class dalAnexos
    Private Shared MySqlString As String

    Private Sub New()
    End Sub

    Public Shared Function PoblarAnexosClientes() As dsAnexos.ANEXOS_DETALLE_LISTADataTable
        MySqlString = "SELECT 'C' AS avanexo, 'TODOS' AS acodane, ' TODOS' AS adesane " & _
                      "UNION ALL " & _
                      "SELECT 'C' AS avanexo, RTRIM(CUENTA_COMERCIAL) AS acodane, LEFT(RAZON_SOCIAL,40) AS adesane " & _
                      "FROM COM.CLIENTES " & _
                      "ORDER BY adesane "
        Dim MyDT As New dsAnexos.ANEXOS_DETALLE_LISTADataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function PoblarAnexosProveedores() As dsAnexos.ANEXOS_DETALLE_LISTADataTable
        MySqlString = "SELECT 'P' AS avanexo, SPACE(1) AS acodane, SPACE(1) AS adesane " & _
                      "UNION ALL " & _
                      "SELECT avanexo, acodane, adesane FROM CON.ANEXO_PROVEEDORES " & _
                      "ORDER BY adesane "
        Dim MyDT As New dsAnexos.ANEXOS_DETALLE_LISTADataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
