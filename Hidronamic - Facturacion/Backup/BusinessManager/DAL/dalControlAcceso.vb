Imports System.Data.SqlClient

Public Class dalControlAcceso
    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal Empresa As String, ByVal Usuario As String, ByVal Perfil As String) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.CONTROL_ACCESO " & _
                              "WHERE Empresa=@empresa AND Usuario=@usuario"
        Using MySQLConnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLConnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", Empresa)
                .AddWithValue("usuario", IIf(Perfil <> "", Perfil, Usuario))
            End With
            MySQLConnection.Open()
            Dim count As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(count = 0, False, True)
        End Using
    End Function

    Public Shared Function Existe(ByVal Usuario As entUsuario) As Boolean
        Return Existe(Usuario.empresa, Usuario.usuario, Usuario.perfil.Trim)
    End Function

    Public Shared Function ObtenerAccesos(ByVal Usuario As entUsuario) As dsControlAccesoLista.CONTROL_ACCESO_LISTADataTable
        Dim MyDT As New dsControlAccesoLista.CONTROL_ACCESO_LISTADataTable
        If Existe(Usuario) Then
            Dim MyStringSQL = "SELECT * " & _
                              "FROM GEN.CONTROL_ACCESO_LISTA " & _
                              "WHERE Empresa='" & Usuario.empresa & "' AND " & _
                              "Usuario='" & IIf(Usuario.perfil.Trim <> "", Usuario.perfil, Usuario.usuario) & "' " & _
                              "ORDER BY Nivel_1, Nivel_2, Nivel_3"
            Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        End If
        Return MyDT
    End Function

    Private Shared Function ExisteAcceso(ByVal ControlAcceso As entControlAcceso) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.CONTROL_ACCESO " & _
                              "WHERE Empresa=@empresa AND Usuario=@usuario AND Nivel_1=@nivel_1 AND Nivel_2=@nivel_2 AND Nivel_3=@nivel_3"
        Using MySQLConnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySql, MySQLConnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", ControlAcceso.empresa)
                .AddWithValue("usuario", ControlAcceso.usuario)
                .AddWithValue("nivel_1", ControlAcceso.nivel_1)
                .AddWithValue("nivel_2", ControlAcceso.nivel_2)
                .AddWithValue("nivel_3", ControlAcceso.nivel_3)
            End With
            MySQLConnection.Open()
            Dim count As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(count = 0, False, True)
        End Using
    End Function

    Public Shared Function ObtenerAcceso(ByVal Empresa As String, ByVal Usuario As String, ByVal Nivel_1 As String, ByVal Nivel_2 As String, ByVal Nivel_3 As String) As dsControlAcceso.CONTROL_ACCESODataTable
        Dim MyDT As New dsControlAcceso.CONTROL_ACCESODataTable
        Dim MystringSql As String = "SELECT * FROM GEN.CONTROL_ACCESO " & _
                                    "WHERE Empresa='" & Empresa & "' AND Usuario='" & Usuario & _
                                    "' AND Nivel_1='" & Nivel_1 & _
                                    "' AND Nivel_2='" & Nivel_2 & _
                                    "' AND Nivel_3='" & Nivel_3 & "'"
        Call ObtenerDataTableSQL(MystringSql, MyDT)
        Return MyDT
    End Function

    Public Shared Sub Grabar(ByVal ControlAcceso As entControlAcceso)
        If ExisteAcceso(ControlAcceso) Then
            Actualizar(ControlAcceso)
        Else
            Insertar(ControlAcceso)
        End If
    End Sub

    Public Shared Sub Borrar(ByVal ControlAcceso As entControlAcceso)
        If ExisteAcceso(ControlAcceso) Then Eliminar(ControlAcceso)
    End Sub

    Private Shared Sub Insertar(ByVal ControlAcceso As entControlAcceso)
        Dim MyStringSql As String = "INSERT INTO GEN.CONTROL_ACCESO " & _
                                    "(Empresa,Usuario,Nivel_1,Nivel_2,Nivel_3,Privilegios,permitir_imprimir, Usuario_Registro,Fecha_Registro) " & _
                                    "VALUES (@empresa,@usuario,@nivel_1,@nivel_2,@nivel_3,@privilegios,@permitir_imprimir,@usuario_registro,@fecha_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("empresa", ControlAcceso.empresa)
                .AddWithValue("usuario", ControlAcceso.usuario)
                .AddWithValue("nivel_1", ControlAcceso.nivel_1)
                .AddWithValue("nivel_2", ControlAcceso.nivel_2)
                .AddWithValue("nivel_3", ControlAcceso.nivel_3)
                .AddWithValue("privilegios", ControlAcceso.privilegios)
                .AddWithValue("permitir_imprimir", ControlAcceso.permitir_imprimir)
                .AddWithValue("usuario_registro", ControlAcceso.usuario_registro)
                .AddWithValue("fecha_registro", Now)
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

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Sub

    Private Shared Sub Actualizar(ByVal ControlAcceso As entControlAcceso)
        Dim MyStringSql As String = "UPDATE GEN.CONTROL_ACCESO " & _
                                    "SET Privilegios=@privilegios, Permitir_imprimir=@permitir_imprimir, Usuario_Modifica=@usuario_modifica, Fecha_Modifica=@fecha_modifica " & _
                                    "WHERE Empresa=@empresa AND Usuario=@usuario AND Nivel_1=@nivel_1 AND Nivel_2=@nivel_2 AND Nivel_3=@nivel_3"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("privilegios", ControlAcceso.privilegios)
                .AddWithValue("permitir_imprimir", ControlAcceso.permitir_imprimir)
                .AddWithValue("usuario_modifica", ControlAcceso.usuario_registro)
                .AddWithValue("fecha_modifica", Now)
                .AddWithValue("empresa", ControlAcceso.empresa)
                .AddWithValue("usuario", ControlAcceso.usuario)
                .AddWithValue("nivel_1", ControlAcceso.nivel_1)
                .AddWithValue("nivel_2", ControlAcceso.nivel_2)
                .AddWithValue("nivel_3", ControlAcceso.nivel_3)
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

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Sub

    Private Shared Sub Eliminar(ByVal ControlAcceso As entControlAcceso)
        Dim MystringSql As String = "DELETE FROM GEN.CONTROL_ACCESO " & _
                                    "WHERE Empresa=@empresa AND Usuario=@usuario AND Nivel_1=@nivel_1 AND Nivel_2=@nivel_2 AND Nivel_3=@nivel_3"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MystringSql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("empresa", ControlAcceso.empresa)
                .AddWithValue("usuario", ControlAcceso.usuario)
                .AddWithValue("nivel_1", ControlAcceso.nivel_1)
                .AddWithValue("nivel_2", ControlAcceso.nivel_2)
                .AddWithValue("nivel_3", ControlAcceso.nivel_3)
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

            Catch ex As Exception
                ' Try to rollback the transaction
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
