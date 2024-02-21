Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalListaPrecio

    Private Shared MySqlString As String

    Public Shared Function ObtenerListaPrecios(ByVal pListaPrecios As String) As dsListaPrecios.LISTA_PRECIOS_DETDataTable
        MySqlString = "SELECT * FROM COM.LISTA_PRECIOS_DET WHERE EMPRESA='" & MyUsuario.empresa & "' AND LISTA_PRECIOS=@vLista_precios "

        Dim MyDT As New dsListaPrecios.LISTA_PRECIOS_DETDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vLista_precios", pListaPrecios)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function


End Class
