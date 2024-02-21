Imports System.Data.SqlClient

Public Class dalUser

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyCount As Integer

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pUsuario As String) As dsUsuarios.USERSDataTable
        Dim MyDT As New dsUsuarios.USERSDataTable
        CadenaSQL = "SELECT * FROM COM.USUARIOS WHERE EMPRESA='" & pEmpresa & "' AND USUARIO='" & pUsuario & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As dsUsuarios.USERSDataTable
        Dim MyDT As New dsUsuarios.USERSDataTable
        CadenaSQL = "SELECT * FROM COM.USUARIOS WHERE EMPRESA='" & pEmpresa & "' AND TIPO_DOCUMENTO='" & pTipoDocumento & "' AND NUMERO_DOCUMENTO='" & pNumeroDocumento & "' "
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Private Shared Function Existe(ByVal cUser As dsUsuarios.USERSDataTable) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.USUARIOS WHERE Empresa=@Empresa AND Usuario=@Usuario"

        Using MyConection As New SqlConnection(myConnectionStringSQL_Repository)

            MySQLCommand = New SqlCommand(MySqlString, MyConection)
            MySQLCommand.Parameters.AddWithValue("Empresa", cUser(0).EMPRESA)
            MySQLCommand.Parameters.AddWithValue("Usuario", cUser(0).USUARIO)

            MyConection.Open()

            Dim count As Integer = CInt(MySQLCommand.ExecuteScalar)

            Return IIf(count = 0, False, True)
        End Using
    End Function

    Public Shared Function Grabar(ByVal cUser As dsUsuarios.USERSDataTable, cUsuario As entUsuario) As Boolean
        Dim cTablaDetalle As New entTablaDetalle

        With cTablaDetalle
            .empresa = "000"
            .codigo_tabla = "USUARIOS"
            .codigo_item = cUser(0).USUARIO
            .nombre_corto = Strings.Left(cUser(0).NOMBRE_COMPLETO, 50)
            .nombre_largo = cUser(0).NOMBRE_COMPLETO
            .texto_01 = cUsuario.clave
            .texto_02 = cUsuario.email
            .texto_03 = cUser(0).EMPRESA
            .texto_04 = cUsuario.perfil
            .texto_05 = cUsuario.privilegios
            .estado = cUsuario.estado
            .usuario_registro = cUser(0).USUARIO_REGISTRO
            .usuario_modifica = cUser(0).USUARIO_MODIFICA
        End With

        If Not Existe(cUser) Then
            Call Insertar(cUser, cTablaDetalle)
        Else
            Call Actualizar(cUser, cTablaDetalle)
        End If

        Return True
    End Function

    Private Shared Sub Insertar(ByVal cUser As dsUsuarios.USERSDataTable, ByVal cTablaDetalle As entTablaDetalle)
        MySqlString = "INSERT INTO COM.USUARIOS " &
                      "(EMPRESA, USUARIO, CARGO, TIPO_DOCUMENTO, NUMERO_DOCUMENTO, NOMBRE_COMPLETO, AGENCIA_ASIGNADA, " &
                      "INDICA_TRABAJADOR, CODIGO_TRABAJADOR, INDICA_PERFIL_PERSONALIZADO, USUARIO_REGISTRO) " &
                      "VALUES " &
                      "(@vEmpresa,@vUsuario,@vCargo,@vTipo_documento,@vNumero_documento,@vNombre_completo,@vAgencia_asignada," &
                      "@vIndica_trabajador,@vCodigo_trabajador,@vIndica_perfil_personalizado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cUser(0).EMPRESA)
                .AddWithValue("vUsuario", cUser(0).USUARIO)
                .AddWithValue("vCargo", cUser(0).CARGO)
                .AddWithValue("vTipo_documento", cUser(0).TIPO_DOCUMENTO)
                .AddWithValue("vNumero_documento", cUser(0).NUMERO_DOCUMENTO)
                .AddWithValue("vNombre_completo", cUser(0).NOMBRE_COMPLETO)
                .AddWithValue("vAgencia_asignada", cUser(0).AGENCIA_ASIGNADA)
                .AddWithValue("vIndica_trabajador", cUser(0).INDICA_TRABAJADOR)
                .AddWithValue("vCodigo_trabajador", cUser(0).CODIGO_TRABAJADOR)
                .AddWithValue("vIndica_perfil_personalizado", cUser(0).INDICA_PERFIL_PERSONALIZADO)
                .AddWithValue("vUsuario_registro", cUser(0).USUARIO_REGISTRO)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySqlString = "INSERT INTO GEN.TABLAS_DETALLE " & _
                              "(empresa,codigo_tabla,codigo_item,nombre_corto,nombre_largo,texto_01,texto_02,texto_03,texto_04,texto_05,usuario_registro) " & _
                              "VALUES (@empresa,@codigo_tabla,@codigo_item,@nombre_corto,@nombre_largo,@texto_01,@texto_02,@texto_03,@texto_04,@texto_05,@usuario_registro)"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("empresa", cTablaDetalle.empresa)
                    .AddWithValue("codigo_tabla", cTablaDetalle.codigo_tabla)
                    .AddWithValue("codigo_item", cTablaDetalle.codigo_item)
                    .AddWithValue("nombre_corto", cTablaDetalle.nombre_corto)
                    .AddWithValue("nombre_largo", cTablaDetalle.nombre_largo)
                    .AddWithValue("texto_01", cTablaDetalle.texto_01)
                    .AddWithValue("texto_02", cTablaDetalle.texto_02)
                    .AddWithValue("texto_03", cTablaDetalle.texto_03)
                    .AddWithValue("texto_04", cTablaDetalle.texto_04)
                    .AddWithValue("texto_05", cTablaDetalle.texto_05)
                    .AddWithValue("usuario_registro", cTablaDetalle.usuario_registro)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()

            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Sub

    Private Shared Sub Actualizar(ByVal cUser As dsUsuarios.USERSDataTable, ByVal cTablaDetalle As entTablaDetalle)
        MySqlString = "UPDATE COM.USUARIOS SET " &
                      "cargo=@vCargo,tipo_documento=@vTipo_documento,numero_documento=@vNumero_documento,nombre_completo=@vNombre_completo,agencia_asignada=@vAgencia_asignada," &
                      "indica_trabajador=@vIndica_trabajador,codigo_trabajador=@vCodigo_trabajador,indica_perfil_personalizado=@vIndica_perfil_personalizado," &
                      "estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
                      "WHERE empresa=@vEmpresa AND usuario=@vUsuario "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vCargo", cUser(0).CARGO)
                .AddWithValue("vTipo_documento", cUser(0).TIPO_DOCUMENTO)
                .AddWithValue("vNumero_documento", cUser(0).NUMERO_DOCUMENTO)
                .AddWithValue("vNombre_completo", cUser(0).NOMBRE_COMPLETO)
                .AddWithValue("vAgencia_asignada", cUser(0).AGENCIA_ASIGNADA)
                .AddWithValue("vIndica_trabajador", cUser(0).INDICA_TRABAJADOR)
                .AddWithValue("vCodigo_trabajador", cUser(0).CODIGO_TRABAJADOR)
                .AddWithValue("vIndica_perfil_personalizado", cUser(0).INDICA_PERFIL_PERSONALIZADO)
                .AddWithValue("vEstado", cUser(0).ESTADO)
                .AddWithValue("vUsuario_modifica", cUser(0).USUARIO_MODIFICA)
                .AddWithValue("vEmpresa", cUser(0).EMPRESA)
                .AddWithValue("vUsuario", cUser(0).USUARIO)
            End With
            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySqlString = "UPDATE GEN.TABLAS_DETALLE SET " &
                              "nombre_corto=@nombre_corto,nombre_largo=@nombre_largo, texto_01=@texto_01, texto_02=@texto_02, texto_03=@texto_03, " &
                              "texto_04=@texto_04, texto_05=@texto_05, estado=@estado, usuario_modifica=@usuario_modifica, fecha_modifica=GETDATE() " & _
                              "WHERE empresa=@empresa AND codigo_tabla=@codigo_tabla AND codigo_item=@codigo_item"

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()
                With MySQLCommand.Parameters
                    .AddWithValue("nombre_corto", cTablaDetalle.nombre_corto)
                    .AddWithValue("nombre_largo", cTablaDetalle.nombre_largo)
                    .AddWithValue("texto_01", cTablaDetalle.texto_01)
                    .AddWithValue("texto_02", cTablaDetalle.texto_02)
                    .AddWithValue("texto_03", cTablaDetalle.texto_03)
                    .AddWithValue("texto_04", cTablaDetalle.texto_04)
                    .AddWithValue("texto_05", cTablaDetalle.texto_05)
                    .AddWithValue("estado", cTablaDetalle.estado)
                    .AddWithValue("usuario_modifica", cTablaDetalle.usuario_modifica)
                    .AddWithValue("empresa", cTablaDetalle.empresa)
                    .AddWithValue("codigo_tabla", cTablaDetalle.codigo_tabla)
                    .AddWithValue("codigo_item", cTablaDetalle.codigo_item)
                End With

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()

            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Sub


End Class
