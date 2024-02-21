Imports System.Data.SqlClient

Public Class dalOrdenPedido
    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand


    Public Shared Function EvaluarSiExisteResumenAlmacen(pAlmacen As String, pNumeroLote As String, pProducto As String) As Boolean
        Dim MyDT As New dsStockAlmacen.EXISTE_STOCKDataTable
        MySqlString = "SELECT COUNT(*) AS CANTIDAD FROM ALM.RESUMEN_X_ALMACEN " & _
                      "WHERE Empresa='" & MyUsuario.empresa & "' AND Almacen='" & pAlmacen & "' AND Numero_lote='" & pNumeroLote & "' AND Producto='" & pProducto & "' "

        Call ObtenerExisteStock(MySqlString, MyDT)

        If MyDT(0).CANTIDAD = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function EvaluarSiExisteResumenPeriodo(pEjercicio As String, pMes As String, pAlmacen As String, pNumeroLote As String, pProducto As String) As Boolean
        Dim MyDT As New dsStockAlmacen.EXISTE_STOCKDataTable
        MySqlString = "SELECT COUNT(*) AS CANTIDAD FROM ALM.RESUMEN_X_PERIODO " & _
                      "WHERE Empresa='" & MyUsuario.empresa & "' AND Ejercicio='" & pEjercicio & "' AND Mes='" & pMes & "' AND Almacen='" & pAlmacen & "' AND Numero_lote='" & pNumeroLote & "' AND Producto='" & pProducto & "' "

        Call ObtenerExisteStock(MySqlString, MyDT)

        If MyDT(0).CANTIDAD = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function ConsultoresPorPeriodo(ByVal pEjercicio As String, ByVal pMes As String) As dsTablasGenericas.LISTADataTable
        MySqlString = "SELECT 'CONSULTORES' AS TABLA, O.CODIGO_VENDEDOR AS CODIGO, V.DESCRIPCION AS DESCRIPCION " & _
                      "FROM COM.ORDEN_PEDIDO AS O INNER JOIN " & _
                      "GEN.TABLA_VENDEDORES AS V ON O.CODIGO_VENDEDOR = V.CODIGO " & _
                      "WHERE O.EMPRESA=@vEmpresa AND O.EJERCICIO=@vEjercicio AND O.MES=@vMes " & _
                      "GROUP BY O.CODIGO_VENDEDOR, V.DESCRIPCION " & _
                      "ORDER BY V.DESCRIPCION "

        Dim MyDT As New dsTablasGenericas.LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
