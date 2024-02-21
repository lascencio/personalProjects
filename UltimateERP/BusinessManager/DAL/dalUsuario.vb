Imports System.Data.SqlClient

Public Class dalUsuario

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyCount As Integer

    Public Shared Function Obtener(ByVal Usuario As String, ByVal Clave As String) As entUsuario
        If Existe(Usuario, Clave) Then
            CadenaSQL = "SELECT * FROM GEN.USUARIOS WHERE Usuario='" & Usuario & "' AND Clave='" & Clave & "'"
            Return Obtener(New entUsuario, CadenaSQL)
        Else
            Return New entUsuario
        End If
    End Function

    Private Shared Function Existe(ByVal Usuario As String, ByVal Clave As String) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.USUARIOS WHERE  Usuario=@Usuario AND Clave=@clave"

        Using MyConection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim command As New SqlCommand(MySql, MyConection)
            command.Parameters.AddWithValue("usuario", Usuario)
            command.Parameters.AddWithValue("clave", Clave)

            MyConection.Open()

            Dim count As Integer = CInt(command.ExecuteScalar)

            Return IIf(count = 0, False, True)

        End Using
    End Function

    Public Shared Function CambiarClave(ByVal Usuario As entUsuario) As entUsuario

        Dim MySql As String = "UPDATE TABLAS_DETALLE " & _
                              "SET TEXTO_01=@clave, USUARIO_MODIFICA=@usuario_modifica, FECHA_MODIFICA=@fecha_modifica " & _
                              "WHERE EMPRESA=@empresa AND codigo_tabla ='USUARIOS' AND codigo_item =@usuario_modifica "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters

                .AddWithValue("clave", Usuario.clave)
                .AddWithValue("usuario_modifica", Usuario.usuario)
                .AddWithValue("fecha_modifica", Now)
                .AddWithValue("empresa", Usuario.empresa)

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

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return Usuario

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException("ERROR: " & ex.Message & Chr(13) & "ORIGEN: " & ex.Source)
            End Try
        End Using
    End Function

    Public Shared Function ObtenerUsuario(ByVal pEmpresa As String, ByVal pUsuario As String) As entUsuario
        CadenaSQL = "SELECT * FROM GEN.USUARIOS WHERE Empresa='" & pEmpresa & "' AND Usuario='" & pUsuario & "' "
        Return Obtener(New entUsuario, CadenaSQL)
    End Function

    Private Shared Function Obtener(ByVal Usuario As entUsuario, ByVal MyStringSQL As String) As entUsuario
        Dim MyDT As New dsUsuarios.USUARIOSDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With Usuario
                .usuario = MyDT(0).USUARIO
                .descripcion = MyDT(0).DESCRIPCION
                .clave = MyDT(0).CLAVE
                .email = MyDT(0).EMAIL
                .empresa = MyDT(0).EMPRESA
                .perfil = MyDT(0).PERFIL
                .aprobar_mn = MyDT(0).APROBAR_MN
                .aprobar_me = MyDT(0).APROBAR_ME
                .privilegios = MyDT(0).PRIVILEGIOS
                .es_plantilla = IIf(MyDT(0).ES_PLANTILLA = 1, True, False)
                .emite_ticket = IIf(MyDT(0).EMITE_TICKET = 1, True, False)
                .estado = MyDT(0).ESTADO

                .serie_asignada = MyDT(0).SERIE_ASIGNADA
            End With
        End If

        If Not Usuario.perfil Is Nothing Then
            MyStringSQL = "SELECT * FROM GEN.USUARIOS WHERE Usuario='" & Usuario.perfil & "' AND Estado='ACT'"
            MyDT = New dsUsuarios.USUARIOSDataTable
            Call ObtenerDataTableSQL(MyStringSQL, MyDT)
            If MyDT.Count > 0 Then
                With Usuario
                    .privilegios = MyDT(0).PRIVILEGIOS
                End With
            End If
        End If

        Return Usuario
    End Function

End Class
