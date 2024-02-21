Imports System.Data.SqlClient

Public Class dalTablaCabecera

    Private Sub New()
    End Sub

    Public Shared Function Existe(ByVal TablaCabecera As entTablaCabecera) As Boolean
        Return Existe(TablaCabecera.empresa, TablaCabecera.codigo_tabla)
    End Function

    Private Shared Function Existe(ByVal Empresa As String, ByVal Codigo_Tabla As String) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.TABLAS_CABECERA " & _
                              "WHERE Empresa=@empresa AND RTRIM(codigo_tabla)=@codigo_tabla"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim command As New SqlCommand(MySql, MySQLDbconnection)
            command.Parameters.AddWithValue("empresa", Empresa)
            command.Parameters.AddWithValue("codigo_tabla", Codigo_Tabla)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(command.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Obtener(ByVal Empresa As String, ByVal Codigo_Tabla As String) As entTablaCabecera
        If Existe(Empresa, Codigo_Tabla) Then
            CadenaSQL = "SELECT * FROM GEN.TABLAS_CABECERA " & _
                        "WHERE EMPRESA='" & Empresa & "' AND CODIGO_TABLA='" & Codigo_Tabla & "' "
            Return Obtener(New entTablaCabecera, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entTablaCabecera
        End If
    End Function

    Public Shared Function Buscar(ByVal Empresa As String, ByVal Codigo_Tabla As String) As Boolean
        Return Existe(Empresa, Codigo_Tabla)
    End Function

    Private Shared Function Obtener(ByVal TablaCabecera As entTablaCabecera, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entTablaCabecera
        Dim MyDT As New dsTablasGenericas.TABLAS_CABECERADataTable

        Call ObtenerDataTableSQL_Web(MyStringSQL, MyDT)
        If MyDT.Count > 0 Then
            With TablaCabecera
                .empresa = MyDT(0).EMPRESA
                .codigo_tabla = MyDT(0).CODIGO_TABLA
                .nombre_corto = MyDT(0).NOMBRE_CORTO
                .nombre_largo = MyDT(0).NOMBRE_LARGO
                .necesidad = MyDT(0).NECESIDAD
                .ttexto_01 = MyDT(0).TTEXTO_01
                .ttexto_02 = MyDT(0).TTEXTO_02
                .ttexto_03 = MyDT(0).TTEXTO_03
                .ttexto_04 = MyDT(0).TTEXTO_04
                .ttexto_05 = MyDT(0).TTEXTO_05
                .tvalor_01 = MyDT(0).TVALOR_01
                .tvalor_02 = MyDT(0).TVALOR_02
                .tvalor_03 = MyDT(0).TVALOR_03
                .tvalor_04 = MyDT(0).TVALOR_04
                .tvalor_05 = MyDT(0).TVALOR_05
                .tlogico_01 = MyDT(0).TLOGICO_01
                .tlogico_02 = MyDT(0).TLOGICO_02
                .tlogico_03 = MyDT(0).TLOGICO_03
                .tlogico_04 = MyDT(0).TLOGICO_04
                .tlogico_05 = MyDT(0).TLOGICO_05
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return TablaCabecera
    End Function

    Public Shared Function Grabar(ByVal TablaCabecera As entTablaCabecera) As entTablaCabecera
        With TablaCabecera
            If String.IsNullOrEmpty(.codigo_tabla) Then Throw New BusinessException(MSG000 & " TABLA")
            If String.IsNullOrEmpty(.nombre_corto) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
            If String.IsNullOrEmpty(.nombre_largo) Then Throw New BusinessException(MSG000 & " DESCRIPCION AMPLIADA")
        End With

        If Not Existe(TablaCabecera) Then
            Return Insertar(TablaCabecera, myConnectionStringSQL_Repository, True)
        Else
            Return Actualizar(TablaCabecera)
        End If

    End Function

    Private Shared Function Actualizar(ByVal TablaCabecera As entTablaCabecera) As entTablaCabecera

        Dim MySql As String = " UPDATE GEN.TABLAS_CABECERA " & _
                              "SET nombre_corto =@nombre_corto,nombre_largo =@nombre_largo, necesidad =@necesidad," & _
                              "tlogico_01 =@tlogico_01, tlogico_02 =@tlogico_02, tlogico_03 =@tlogico_03," & _
                              "tlogico_04 =@tlogico_04, tlogico_05 =@tlogico_05, ttexto_01 =@ttexto_01," & _
                              "ttexto_02 =@ttexto_02, ttexto_03 =@ttexto_03, ttexto_04 =@ttexto_04," & _
                              "ttexto_05 =@ttexto_05, tvalor_01 =@tvalor_01, tvalor_02 =@tvalor_02," & _
                              "tvalor_03 =@tvalor_03, tvalor_04 =@tvalor_04, tvalor_05 =@tvalor_05," & _
                              "estado =@estado, usuario_modifica =@usuario_modifica, fecha_modifica =@fecha_modifica " & _
                              "WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("nombre_corto", TablaCabecera.nombre_corto)
                .AddWithValue("nombre_largo", TablaCabecera.nombre_largo)
                .AddWithValue("necesidad", TablaCabecera.necesidad)
                .AddWithValue("tlogico_01", TablaCabecera.tlogico_01)
                .AddWithValue("tlogico_02", TablaCabecera.tlogico_02)
                .AddWithValue("tlogico_03", TablaCabecera.tlogico_03)
                .AddWithValue("tlogico_04", TablaCabecera.tlogico_04)
                .AddWithValue("tlogico_05", TablaCabecera.tlogico_05)
                .AddWithValue("ttexto_01", TablaCabecera.ttexto_01)
                .AddWithValue("ttexto_02", TablaCabecera.ttexto_02)
                .AddWithValue("ttexto_03", TablaCabecera.ttexto_03)
                .AddWithValue("ttexto_04", TablaCabecera.ttexto_04)
                .AddWithValue("ttexto_05", TablaCabecera.ttexto_05)
                .AddWithValue("tvalor_01", TablaCabecera.tvalor_01)
                .AddWithValue("tvalor_02", TablaCabecera.tvalor_02)
                .AddWithValue("tvalor_03", TablaCabecera.tvalor_03)
                .AddWithValue("tvalor_04", TablaCabecera.tvalor_04)
                .AddWithValue("tvalor_05", TablaCabecera.tvalor_05)
                .AddWithValue("estado", TablaCabecera.estado)
                .AddWithValue("usuario_modifica", TablaCabecera.usuario_registro)
                .AddWithValue("fecha_modifica", Now)
                .AddWithValue("empresa", TablaCabecera.empresa)
                .AddWithValue("codigo_tabla", TablaCabecera.codigo_tabla)
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
                Return TablaCabecera

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

    Private Shared Function Insertar(ByVal TablaCabecera As entTablaCabecera, ByVal MyConnectionString As String, ByVal ObtenerCodigo As Boolean) As entTablaCabecera
        Dim MySql As String = " INSERT INTO GEN.TABLAS_CABECERA " & _
                              "(codigo_tabla,nombre_corto,nombre_largo,necesidad,empresa," & _
                              "tlogico_01,tlogico_02,tlogico_03,tlogico_04,tlogico_05," & _
                              "ttexto_01,ttexto_02,ttexto_03,ttexto_04,ttexto_05," & _
                              "tvalor_01,tvalor_02,tvalor_03,tvalor_04,tvalor_05," & _
                              "estado,usuario_registro,fecha_registro) " & _
                              "VALUES (@codigo_tabla,@nombre_corto,@nombre_largo,@necesidad,@empresa,@tlogico_01," & _
                              "@tlogico_02,@tlogico_03,@tlogico_04,@tlogico_05,@ttexto_01,@ttexto_02," & _
                              "@ttexto_03,@ttexto_04,@ttexto_05,@tvalor_01,@tvalor_02," & _
                              "@tvalor_03,@tvalor_04,@tvalor_05,@estado,@usuario_registro,@fecha_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("codigo_tabla", TablaCabecera.codigo_tabla)
                .AddWithValue("nombre_corto", TablaCabecera.nombre_corto)
                .AddWithValue("nombre_largo", TablaCabecera.nombre_largo)
                .AddWithValue("necesidad", TablaCabecera.necesidad)
                .AddWithValue("empresa", TablaCabecera.empresa)
                .AddWithValue("tlogico_01", TablaCabecera.tlogico_01)
                .AddWithValue("tlogico_02", TablaCabecera.tlogico_02)
                .AddWithValue("tlogico_03", TablaCabecera.tlogico_03)
                .AddWithValue("tlogico_04", TablaCabecera.tlogico_04)
                .AddWithValue("tlogico_05", TablaCabecera.tlogico_05)
                .AddWithValue("ttexto_01", TablaCabecera.ttexto_01)
                .AddWithValue("ttexto_02", TablaCabecera.ttexto_02)
                .AddWithValue("ttexto_03", TablaCabecera.ttexto_03)
                .AddWithValue("ttexto_04", TablaCabecera.ttexto_04)
                .AddWithValue("ttexto_05", TablaCabecera.ttexto_05)
                .AddWithValue("tvalor_01", TablaCabecera.tvalor_01)
                .AddWithValue("tvalor_02", TablaCabecera.tvalor_02)
                .AddWithValue("tvalor_03", TablaCabecera.tvalor_03)
                .AddWithValue("tvalor_04", TablaCabecera.tvalor_04)
                .AddWithValue("tvalor_05", TablaCabecera.tvalor_05)
                .AddWithValue("estado", TablaCabecera.estado)
                .AddWithValue("usuario_registro", TablaCabecera.usuario_registro)
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

                Return TablaCabecera

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

    Public Shared Function Borrar(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Nombre_Tabla As String) As Boolean
        Resp = MsgBox("Esta seguro de eliminar la tabla " & Nombre_Tabla & "?" & Chr(13) & _
                      "ADVERTENCIA: Todos sus elementos también serán eliminados.", MsgBoxStyle.YesNo, "ELIMINAR")
        If Resp.ToString = vbYes Then
            Call Eliminar(Empresa, Codigo_Tabla)
            Return True
        End If
    End Function

    Private Shared Function Eliminar(ByVal Empresa As String, ByVal Codigo_Tabla As String) As Boolean
        Dim MySql As String = "DELETE FROM GEN.TABLAS_CABECERA " & _
                              "WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", Empresa)
                .AddWithValue("codigo_tabla", Codigo_Tabla)
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

    Public Shared Function ObtenerTablas(ByVal Empresa As String) As dsTablasCabeceraLista.TABLAS_CABECERA_LISTADataTable
        Dim MyDT As New dsTablasCabeceraLista.TABLAS_CABECERA_LISTADataTable
        Dim MySql As String = "SELECT * FROM GEN.TABLAS_CABECERA_LISTA WHERE Empresa='" & Empresa & "' " & _
                              "ORDER BY Descripcion"
        Call ObtenerDataTableSQL_Web(MySql, MyDT)
        Return MyDT
    End Function

End Class