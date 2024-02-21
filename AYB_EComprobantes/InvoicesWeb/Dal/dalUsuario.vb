Imports System.Data.SqlClient

Public Class dalUsuario

    Private Sub New()
    End Sub

    Public Shared Function Obtener(ByVal Usuario As String, ByVal Clave As String) As entUsuario
        If Existe(Usuario, Clave) Then
            CadenaSQL = "SELECT * FROM GEN.USUARIOS WHERE Usuario='" & Usuario & "' AND Clave='" & Clave & "'"
            Return Obtener(New entUsuario, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entUsuario
        End If
    End Function

    Private Shared Function Obtener(ByVal Usuario As entUsuario, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entUsuario

        Dim MyDT As New dsUsuarios.USUARIOSDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With Usuario
                .usuario = MyDT(0).USUARIO
                .descripcion = MyDT(0).DESCRIPCION
                .clave = MyDT(0).CLAVE
                .email = MyDT(0).EMAIL
                .empresa = "001"
                .perfil = MyDT(0).PERFIL
                .aprobar_mn = MyDT(0).APROBAR_MN
                .aprobar_me = MyDT(0).APROBAR_ME
                .periodo_unico = IIf(MyDT(0).PERIODO_UNICO = 1, True, False)
                .privilegios = MyDT(0).PRIVILEGIOS
                .periodo_unico = IIf(MyDT(0).PERIODO_UNICO = 1, True, False)
                .estado = MyDT(0).ESTADO
            End With
        End If

        If Usuario.perfil.Trim <> "" Then
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

    Private Shared Function Existe(ByVal Usuario As String, ByVal Clave As String) As Boolean
        'Dim MySql As String = "SELECT COUNT(*) FROM GEN.USUARIOS WHERE  Usuario=@usuario AND Clave=@clave"
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

        Dim MySql As String = "UPDATE GEN.TABLAS_DETALLE " & _
                              "SET TEXTO_01=@clave, USUARIO_MODIFICA=@usuario_modifica, FECHA_MODIFICA=@fecha_modifica " & _
                              "WHERE EMPRESA=@empresa AND codigo_tabla ='USUARIOS' AND codigo_item =@usuario_modifica "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters

                .AddWithValue("clave", Usuario.clave)
                .AddWithValue("usuario_modifica", Usuario.usuario)
                .AddWithValue("fecha_modifica", Now)
                .AddWithValue("empresa", "000")

            End With

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
        End Using

    End Function

End Class
