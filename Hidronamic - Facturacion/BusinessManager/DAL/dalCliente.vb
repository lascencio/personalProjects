Imports System.Data.SqlClient

Public Class dalCliente

    Private Shared MySql As String
    Private Shared MySqlString As String

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pCliente As String) As Boolean
        If Not String.IsNullOrEmpty(pCliente) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CLIENTES WHERE Codigo=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCliente.Trim)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pCliente As String) As entCONCAR_Cliente
        If Existe(pCliente) Then
            CadenaSQL = "SELECT * FROM COM.CLIENTES WHERE Codigo='" & pCliente.Trim & "'"
            Return Obtener(New entCONCAR_Cliente, CadenaSQL)
        Else
            Return New entCONCAR_Cliente
        End If
    End Function

    Private Shared Function Obtener(ByVal cCliente As entCONCAR_Cliente, ByVal MyStringSQL As String) As entCONCAR_Cliente
        Dim MyDT As New dsClientes.GESNET_CLIENTESDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCliente
                .avanexo = "C"
                .acodane = MyDT(0).Codigo
                .adesane = MyDT(0).Gestor
                .arefane = MyDT(0).Direccion
                .aruc = MyDT(0).RUC
                .acodmon = "1"
                '.aestado = MyDT(0).AESTADO
                .atiptra = IIf(MyDT(0).Personeria = "1", "N", "J")
                '.apaterno = MyDT(0).APATERNO
                '.amaterno = MyDT(0).AMATERNO
                '.anombre = MyDT(0).ANOMBRE
                .aemail = MyDT(0).Email
                '.ahost = MyDT(0).AHOST
                .adocide = IIf(MyDT(0).TipoDocumentoIdentidadId = "3", "6", "1")
                .anumide = IIf(MyDT(0).RUC.Trim.Length <> 0, MyDT(0).RUC, MyDT(0).DocumentoIdentidad)
            End With
        End If
        Return cCliente
    End Function

    Public Shared Function BuscarClientesCodigo(pCuentaComercial As String) As dsClientes.CLIENTES_LISTADataTable

        MySqlString = "SELECT CUENTA_COMERCIAL, RAZON_SOCIAL, PREFIJO " & _
                      "FROM COM.CLIENTES WHERE EMPRESA='001' AND CUENTA_COMERCIAL LIKE @vCuenta_comercial+'%' " & _
                      "ORDER BY CUENTA_COMERCIAL "

        Dim MyDT As New dsClientes.CLIENTES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", pCuentaComercial)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarClientesNombre(pRazonSocial As String) As dsClientes.CLIENTES_LISTADataTable

        MySqlString = "SELECT CUENTA_COMERCIAL, RAZON_SOCIAL, PREFIJO " & _
                      "FROM COM.CLIENTES WHERE EMPRESA='001' AND RAZON_SOCIAL LIKE '%'+@vRazon_social+'%' " & _
                      "ORDER BY RAZON_SOCIAL "

        Dim MyDT As New dsClientes.CLIENTES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vRazon_social", pRazonSocial)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
