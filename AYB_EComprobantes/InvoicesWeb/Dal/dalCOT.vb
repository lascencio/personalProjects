Imports System.Data.SqlClient

Public Class dalCOT
    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand

    Private Shared Function ExisteControlConsulta(pEmpresa As String, ByVal pUsuario As String) As Boolean
        Dim MyCount As Integer = 0
        If Not String.IsNullOrEmpty(pUsuario) Then
            MySqlString = "SELECT COUNT(*) FROM COT.CONTROL_CONSULTAS WHERE Empresa=@vEmpresa AND Usuario=@vUsuario "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vUsuario", pUsuario)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
            End Using
        End If
        Return IIf(MyCount = 0, False, True)
    End Function

    Public Shared Function ObtenerControlConsultas(pEmpresa As String, ByVal pUsuario As String) As entControlConsultas
        If ExisteControlConsulta(pEmpresa, pUsuario) Then
            CadenaSQL = "SELECT * FROM COT.CONTROL_CONSULTAS WHERE EMPRESA='" & pEmpresa & "' AND USUARIO='" & pUsuario & "' "
            Return ObtenerControlConsultas(New entControlConsultas, CadenaSQL)
        Else
            Return New entControlConsultas
        End If
    End Function

    Private Shared Function ObtenerControlConsultas(ByVal cControlConsultas As entControlConsultas, ByVal MyStringSQL As String) As entControlConsultas
        Dim MyDT As New dsCOT.CONTROL_CONSULTASDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cControlConsultas
                .empresa = MyDT(0).EMPRESA
                .usuario = MyDT(0).USUARIO
                .prospecto = MyDT(0).PROSPECTO
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .marca = MyDT(0).MARCA
                .tipo_servicio = MyDT(0).TIPO_SERVICIO
                .area = MyDT(0).AREA
                .responsable_venta = MyDT(0).RESPONSABLE_VENTA
                .responsable_ejecucion = MyDT(0).RESPONSABLE_EJECUCION
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cControlConsultas
    End Function


End Class
