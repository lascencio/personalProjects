Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalFacturacion

    Private Shared MySql As String

    Public Shared Sub AnularActivar(ByVal pVenta As String)

        MySql = "INSERT INTO AUD.VENTAS " & _
                "SELECT * FROM  COM.VENTAS " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vVenta", pVenta)
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

                MySql = "UPDATE COM.VENTAS SET " & _
                "Estado=CASE WHEN Estado='N' THEN 'A' ELSE 'N' END," & _
                "Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE Empresa=@vEmpresa AND Venta=@vVenta"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySql
                MySQLCommand.Parameters.Clear()

                With MySQLCommand.Parameters
                    .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                    .AddWithValue("vFecha_modifica", Now)
                    .AddWithValue("vEmpresa", MyUsuario.empresa)
                    .AddWithValue("vVenta", pVenta)
                End With

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

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
    End Sub

End Class
