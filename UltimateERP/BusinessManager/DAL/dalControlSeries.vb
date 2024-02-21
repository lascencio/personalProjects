Imports System.Data.SqlClient

Public Class dalControlSeries

    Private Shared MySqlString As String


    Public Shared Function BuscarSeriesDisponibles(ByVal pAlmacen As String, ByVal pProducto As String) As dsProductos.SERIESDataTable
        MySqlString = "SELECT NUMERO_SERIE, REFERENCIA_OPERACION, FECHA_OPERACION " & _
                      "FROM COM.CONTROL_SERIES " & _
                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND producto=@vProducto AND ESTADO='D' "

        Dim MyDT As New dsProductos.SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarSeriesVehicularDisponibles(ByVal pAlmacen As String, ByVal pProducto As String) As dsProductos.SERIES_VEHICULARDataTable
        MySqlString = "SELECT NUMERO_SERIE, NUMERO_SERIE_CHASIS, COLOR, REFERENCIA_OPERACION, FECHA_OPERACION " & _
                      "FROM COM.CONTROL_SERIES " & _
                      "WHERE Empresa=@vEmpresa AND Almacen=@vAlmacen AND producto=@vProducto AND ESTADO='D' "

        Dim MyDT As New dsProductos.SERIES_VEHICULARDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vAlmacen", pAlmacen)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerControlSeries(pEmpresa As String, pProducto As String, pNumeroSerie As String) As dsControlSeries.CONTROL_SERIESDataTable
        MySqlString = "SELECT EMPRESA, PRODUCTO, NUMERO_SERIE, ALMACEN, REFERENCIA_OPERACION, FECHA_OPERACION, REFERENCIA_VENTA, FECHA_VENTA, REFERENCIA_SERVICIO, " & _
                      "FECHA_SERVICIO, REFERENCIA_PEDIDO, FECHA_PEDIDO, REFERENCIA_GUIA, FECHA_GUIA, REFERENCIA_DEVOLUCION, FECHA_DEVOLUCION, ESTADO, " & _
                      "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA " & _
                      "FROM COM.CONTROL_SERIES " & _
                      "WHERE EMPRESA=@vEmpresa AND PRODUCTO=@vProducto AND NUMERO_SERIE=@vNumero_serie "

        Dim MyDT As New dsControlSeries.CONTROL_SERIESDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.CommandText = MySqlString
            MySQLCommand.Parameters.Clear()
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vProducto", pProducto)
            MySQLCommand.Parameters.AddWithValue("vNumero_serie", pNumeroSerie)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function EvaluarSiExisteControlSeries(pProducto As String, pNumeroSerie As String) As Boolean
        Dim MyDT As New dsStockAlmacen.EXISTE_STOCKDataTable
        MySqlString = "SELECT COUNT(*) AS CANTIDAD FROM COM.CONTROL_SERIES " & _
                      "WHERE Empresa='" & MyUsuario.empresa & "' AND Producto='" & pProducto & "' AND Numero_serie='" & pNumeroSerie & "' "

        Call ObtenerExisteStock(MySqlString, MyDT)

        If MyDT(0).CANTIDAD = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


End Class
