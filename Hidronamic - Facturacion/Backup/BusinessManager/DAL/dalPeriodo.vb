Imports System.Data.SqlClient

Public Class dalPeriodo
    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pModulo As String) As Boolean
        If Not String.IsNullOrEmpty(pModulo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Modulo=@vModulo "

            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
                MySQLCommand.Parameters.AddWithValue("vModulo", pModulo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cPeriodo As entPeriodo) As Boolean
        If Not String.IsNullOrEmpty(cPeriodo.ejercicio) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                                        "WHERE Empresa=@vEmpresa AND Ejercicio=@vEjercicio AND Modulo=@vModulo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cPeriodo.empresa)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cPeriodo.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vModulo", cPeriodo.modulo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pModulo As String) As entPeriodo
        If Existe(pEmpresa, pEjercicio, pModulo) Then
            CadenaSQL = "SELECT * FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                        "WHERE EMPRESA='" & pEmpresa & "' AND Ejercicio='" & pEjercicio & "' AND Modulo='" & pModulo & "' "
            Return Obtener(New entPeriodo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entPeriodo
        End If
    End Function

    Private Shared Function Obtener(ByVal cPeriodo As entPeriodo, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entPeriodo
        Dim MyDT As New dsPeriodos.PERIODOSDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cPeriodo
                .empresa = MyDT(0).EMPRESA
                .ejercicio = MyDT(0).EJERCICIO
                .modulo = MyDT(0).MODULO
                .mes_01 = MyDT(0).MES_01
                .mes_02 = MyDT(0).MES_02
                .mes_03 = MyDT(0).MES_03
                .mes_04 = MyDT(0).MES_04
                .mes_05 = MyDT(0).MES_05
                .mes_06 = MyDT(0).MES_06
                .mes_07 = MyDT(0).MES_07
                .mes_08 = MyDT(0).MES_08
                .mes_09 = MyDT(0).MES_09
                .mes_10 = MyDT(0).MES_10
                .mes_11 = MyDT(0).MES_11
                .mes_12 = MyDT(0).MES_12
                .indica_activo = MyDT(0).INDICA_ACTIVO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cPeriodo
    End Function

    Public Shared Function Grabar(ByVal cPeriodo As entPeriodo) As entPeriodo
        If Not Existe(cPeriodo) Then
            Return Insertar(cPeriodo, myConnectionStringSQL_Repository)
        Else
            Return Actualizar(cPeriodo)
        End If
    End Function

    Private Shared Function Insertar(ByVal cPeriodo As entPeriodo, ByVal MyConnectionString As String) As entPeriodo
        Dim MySql As String = "INSERT INTO " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
        "(empresa,ejercicio,modulo,mes_01,mes_02,mes_03,mes_04,mes_05,mes_06,mes_07,mes_08,mes_09,mes_10,mes_11,mes_12,indica_activo,usuario_registro) " & _
        "VALUES (@vEmpresa,@vEjercicio,@vModulo,@vMes_01,@vMes_02,@vMes_03,@vMes_04,@vMes_05,@vMes_06,@vMes_07,@vMes_08,@vMes_09,@vMes_10,@vMes_11,@vMes_12,@vIndica_activo,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cPeriodo.empresa)
                .AddWithValue("vEjercicio", cPeriodo.ejercicio)
                .AddWithValue("vModulo", cPeriodo.modulo)
                .AddWithValue("vMes_01", cPeriodo.mes_01)
                .AddWithValue("vMes_02", cPeriodo.mes_02)
                .AddWithValue("vMes_03", cPeriodo.mes_03)
                .AddWithValue("vMes_04", cPeriodo.mes_04)
                .AddWithValue("vMes_05", cPeriodo.mes_05)
                .AddWithValue("vMes_06", cPeriodo.mes_06)
                .AddWithValue("vMes_07", cPeriodo.mes_07)
                .AddWithValue("vMes_08", cPeriodo.mes_08)
                .AddWithValue("vMes_09", cPeriodo.mes_09)
                .AddWithValue("vMes_10", cPeriodo.mes_10)
                .AddWithValue("vMes_11", cPeriodo.mes_11)
                .AddWithValue("vMes_12", cPeriodo.mes_12)
                .AddWithValue("vIndica_activo", cPeriodo.indica_activo)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
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

                Return cPeriodo

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
    End Function

    Private Shared Function Actualizar(ByVal cPeriodo As entPeriodo) As entPeriodo

        Dim MySql As String = "UPDATE " & MyModulo.Substring(0, 3) & ".PERIODOS SET " & _
        "Mes_01=@vMes_01,Mes_02=@vMes_02,Mes_03=@vMes_03,Mes_04=@vMes_04,Mes_05=@vMes_05,Mes_06=@vMes_06,Mes_07=@vMes_07,Mes_08=@vMes_08,Mes_09=@vMes_09," & _
        "Mes_10=@vMes_10,Mes_11=@vMes_11,Mes_12=@vMes_12,Indica_activo=@vIndica_activo,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=@vFecha_modifica " & _
        "WHERE Empresa=@vEmpresa  AND Ejercicio=@vEjercicio AND Modulo=@vModulo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vMes_01", cPeriodo.mes_01)
                .AddWithValue("vMes_02", cPeriodo.mes_02)
                .AddWithValue("vMes_03", cPeriodo.mes_03)
                .AddWithValue("vMes_04", cPeriodo.mes_04)
                .AddWithValue("vMes_05", cPeriodo.mes_05)
                .AddWithValue("vMes_06", cPeriodo.mes_06)
                .AddWithValue("vMes_07", cPeriodo.mes_07)
                .AddWithValue("vMes_08", cPeriodo.mes_08)
                .AddWithValue("vMes_09", cPeriodo.mes_09)
                .AddWithValue("vMes_10", cPeriodo.mes_10)
                .AddWithValue("vMes_11", cPeriodo.mes_11)
                .AddWithValue("vMes_12", cPeriodo.mes_12)
                .AddWithValue("vIndica_activo", cPeriodo.indica_activo)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cPeriodo.empresa)
                .AddWithValue("vEjercicio", cPeriodo.ejercicio)
                .AddWithValue("vModulo", cPeriodo.modulo)
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
                Return cPeriodo

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
    End Function

    Public Shared Function Borrar(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pModulo As String) As Boolean
        If Not String.IsNullOrEmpty(pModulo) Then
            Resp = MsgBox("Confirmar proceso de eliminación.", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                Return Eliminar(pEmpresa, pEjercicio, pModulo)
            End If
        End If
    End Function

    Private Shared Function Eliminar(ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pModulo As String) As Boolean
        Dim MySqlString As String = "DELETE FROM " & MyModulo.Substring(0, 3) & ".PERIODOS WHERE Empresa=@vEmpresa  AND Ejercicio=@vEjercicio AND Modulo=@vModulo "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vModulo", pModulo)
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

                Return True

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
    End Function

    Public Shared Function ObtenerPeriodos(ByVal Usuario As entUsuario) As dsPeriodos.PERIODOSDataTable

        Dim MyPeriodos As New dsPeriodos.PERIODOSDataTable

        Dim MyStringSQL As String = "SELECT * FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                                    "WHERE EMPRESA='" & Usuario.empresa & "' AND INDICA_ACTIVO='SI' " & _
                                    "ORDER BY EJERCICIO"

        Call ObtenerDataTableSQL(MyStringSQL, MyPeriodos)

        Return MyPeriodos

    End Function

End Class
