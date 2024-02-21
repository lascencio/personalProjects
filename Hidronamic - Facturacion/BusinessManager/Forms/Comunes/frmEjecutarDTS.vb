Imports System.Data.SqlClient

Public Class frmEjecutarDTS

    Private Sub frmEjecutarDTS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        'Dim MyDR As SqlDataReader 'variable donde se guarMyDA los resultados de la consulta
        'Dim MySQLDbconnection As New SqlConnection(myConnectionStringSQL_StarSoft) ' variable conexion
        'Dim MyDA As New SqlDataAdapter 'el que hace la funcion de la consulta
        'Dim MyQuery As String
        'Dim dts_name As String = "dts_APC_TimeTrac"

        'MyQuery = "sp_execdts"
        'MyDA = New SqlDataAdapter(MyQuery, MySQLDbconnection)
        'MyDA.SelectCommand.CommandType = CommandType.StoredProcedure
        'MyDA.SelectCommand.Parameters.AddWithValue("@nombre", dts_name)
        'MyDA.SelectCommand.CommandTimeout = 0
        'MyDA.SelectCommand.Connection.Open()
        'MyDR = MyDA.SelectCommand.ExecuteReader()

        'MySQLDbconnection.Close()



    End Sub
End Class