Imports System.Data.SqlClient

Public Class dalTablasGenericas

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyCount As Integer

    Public Shared Function BuscarElementosCodigo(ByVal pEmpresa As String, ByVal pTabla As String, ByVal pCodigo As String) As dsTablasGenericas.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasGenericas.TABLAS_DETALLE_LISTADataTable
        MySqlString = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & pEmpresa & "'  AND CODIGO_TABLA='" & pTabla & "' AND " & _
                      "CODIGO LIKE '" & pCodigo & "%'" & _
                      "ORDER BY CODIGO "
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function ObtenerMotivoNotaCredito(ByVal pEmpresa As String, ByVal pTipoNotaCredito As String) As String
        Dim MyCentroCosto As String
        MySqlString = "SELECT NOMBRE_CORTO AS MOTIVO FROM GEN.TABLAS_DETALLE " & _
                      "WHERE Empresa=@vEmpresa AND Codigo_tabla='SEE_TIPO_NOTA_CREDITO' AND Codigo_item=@vCodigo_item "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MyCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MyCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MyCommand.Parameters.AddWithValue("vCodigo_item", pTipoNotaCredito)
            MySQLDbconnection.Open()
            MyCentroCosto = MyCommand.ExecuteScalar
        End Using
        Return MyCentroCosto
    End Function

#Region "Cabecera"

    Public Shared Function Obtener(ByVal Empresa As String, ByVal Codigo_Tabla As String) As entTablaCabecera
        If Existe(Empresa, Codigo_Tabla) Then
            CadenaSQL = "SELECT * FROM GEN.TABLAS_CABECERA " & _
                        "WHERE EMPRESA='" & Empresa & "' AND CODIGO_TABLA='" & Codigo_Tabla & "' "
            Return Obtener(New entTablaCabecera, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entTablaCabecera
        End If
    End Function

    Private Shared Function Existe(ByVal Empresa As String, ByVal Codigo_Tabla As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM GEN.TABLAS_CABECERA WHERE Empresa=@empresa AND RTRIM(codigo_tabla)=@codigo_tabla"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("empresa", Empresa)
            MySQLCommand.Parameters.AddWithValue("codigo_tabla", Codigo_Tabla)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Obtener(ByVal TablaCabecera As entTablaCabecera, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entTablaCabecera
        Dim MyDT As New dsTablasGenericas.TABLAS_CABECERADataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
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

    Public Shared Function ObtenerTablas(ByVal Empresa As String) As dsTablasGenericas.TABLAS_CABECERA_LISTADataTable
        Dim MyDT As New dsTablasGenericas.TABLAS_CABECERA_LISTADataTable
        MySqlString = "SELECT * FROM GEN.TABLAS_CABECERA_LISTA WHERE Empresa='" & Empresa & "' ORDER BY Descripcion"
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
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
        MySqlString = "DELETE FROM GEN.TABLAS_CABECERA WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", Empresa)
                .AddWithValue("codigo_tabla", Codigo_Tabla)
            End With

            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()

                Return True

            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
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

    Public Shared Function Existe(ByVal TablaCabecera As entTablaCabecera) As Boolean
        Return Existe(TablaCabecera.empresa, TablaCabecera.codigo_tabla)
    End Function

    Private Shared Function Insertar(ByVal TablaCabecera As entTablaCabecera, ByVal MyConnectionString As String, ByVal ObtenerCodigo As Boolean) As entTablaCabecera
        MySqlString = " INSERT INTO GEN.TABLAS_CABECERA " & _
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
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
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
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()

                Return TablaCabecera
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Function

    Private Shared Function Actualizar(ByVal TablaCabecera As entTablaCabecera) As entTablaCabecera

        MySqlString = " UPDATE GEN.TABLAS_CABECERA " & _
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
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

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
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()

                Return TablaCabecera
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

#End Region

#Region "Detalles"

    Public Shared Function Obtener(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As entTablaDetalle
        If Existe(Empresa, Codigo_Tabla, Codigo_Item) Then
            CadenaSQL = "SELECT * FROM GEN.TABLAS_DETALLE " & _
                         "WHERE EMPRESA='" & Empresa & "' AND CODIGO_TABLA='" & Codigo_Tabla & "' AND CODIGO_ITEM='" & Codigo_Item & "' "
            Return Obtener(New entTablaDetalle, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entTablaDetalle
        End If
    End Function

    Private Shared Function Existe(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM GEN.TABLAS_DETALLE WHERE Empresa=@empresa AND codigo_tabla=@codigo_tabla and codigo_item=@codigo_item"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("empresa", Empresa)
            MySQLCommand.Parameters.AddWithValue("codigo_tabla", Codigo_Tabla)
            MySQLCommand.Parameters.AddWithValue("codigo_item", Codigo_Item)
            MySQLDbconnection.Open()
            MyCount = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Obtener(ByVal TablaDetalle As entTablaDetalle, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entTablaDetalle
        Dim MyDT As New dsTablasGenericas.TABLAS_DETALLEDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        If MyDT.Count > 0 Then
            With TablaDetalle
                .empresa = MyDT(0).EMPRESA
                .codigo_tabla = MyDT(0).CODIGO_TABLA
                .codigo_item = MyDT(0).CODIGO_ITEM
                .nombre_corto = MyDT(0).NOMBRE_CORTO
                .nombre_largo = MyDT(0).NOMBRE_LARGO
                .texto_01 = MyDT(0).TEXTO_01
                .texto_02 = MyDT(0).TEXTO_02
                .texto_03 = MyDT(0).TEXTO_03
                .texto_04 = MyDT(0).TEXTO_04
                .texto_05 = MyDT(0).TEXTO_05
                .valor_01 = MyDT(0).VALOR_01
                .valor_02 = MyDT(0).VALOR_02
                .valor_03 = MyDT(0).VALOR_03
                .valor_04 = MyDT(0).VALOR_04
                .valor_05 = MyDT(0).VALOR_05
                .logico_01 = MyDT(0).LOGICO_01
                .logico_02 = MyDT(0).LOGICO_02
                .logico_03 = MyDT(0).LOGICO_03
                .logico_04 = MyDT(0).LOGICO_04
                .logico_05 = MyDT(0).LOGICO_05
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return TablaDetalle
    End Function

    Public Shared Function ObtenerDetalles(ByVal Empresa As String, ByVal CodigoTabla As String, ByVal Estado As String) As dsTablasGenericas.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasGenericas.TABLAS_DETALLE_LISTADataTable
        MySqlString = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & Empresa & "'  AND CODIGO_TABLA='" & CodigoTabla & "' " & _
                      IIf(Estado <> "T", "AND ACTIVO=1 ", " ") & _
                      "ORDER BY CODIGO"
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function Borrar(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String, ByVal Nombre_Item As String) As Boolean
        Resp = MsgBox("Esta seguro de eliminar el item " & Nombre_Item & "?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
        If Resp = 6 Then
            Call Eliminar(Empresa, Codigo_Tabla, Codigo_Item)
            Return True
        End If
    End Function

    Private Shared Function Eliminar(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As Boolean
        MySqlString = "DELETE FROM GEN.TABLAS_DETALLE " & _
                      "WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla AND codigo_item =@codigo_item"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", Empresa)
                .AddWithValue("codigo_tabla", Codigo_Tabla)
                .AddWithValue("codigo_item", Codigo_Item)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
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

    Public Shared Function Grabar(ByVal TablaDetalle As entTablaDetalle) As entTablaDetalle
        With TablaDetalle
            If String.IsNullOrEmpty(.codigo_tabla) Then Throw New BusinessException(MSG000 & " TABLA")
            If String.IsNullOrEmpty(.nombre_corto) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
            If String.IsNullOrEmpty(.nombre_largo) Then Throw New BusinessException(MSG000 & " DESCRIPCION AMPLIADA")
            If .codigo_tabla = "USUARIOS" And String.IsNullOrEmpty(.texto_03) Then Throw New BusinessException(MSG000 & " EMPRESA")
            If .codigo_tabla = "USUARIOS" And String.IsNullOrEmpty(.texto_05) Then Throw New BusinessException(MSG000 & " PRIVILEGIOS")
        End With
        If Not Existe(TablaDetalle) Then
            Return Insertar(TablaDetalle, True)
        Else
            Return Actualizar(TablaDetalle)
        End If
    End Function

    Public Shared Function Existe(ByVal TablaDetalle As entTablaDetalle) As Boolean
        Return Existe(TablaDetalle.empresa, TablaDetalle.codigo_tabla, TablaDetalle.codigo_item)
    End Function

    Private Shared Function Insertar(ByVal TablaDetalle As entTablaDetalle, ByVal ObtenerCodigo As Boolean) As entTablaDetalle
        MySqlString = "INSERT INTO GEN.TABLAS_DETALLE " & _
                      "(empresa,codigo_tabla,codigo_item,nombre_corto,nombre_largo,logico_01,logico_02,logico_03,logico_04,logico_05,texto_01,texto_02,texto_03," & _
                      "texto_04,texto_05,valor_01,valor_02,valor_03,valor_04,valor_05,estado,usuario_registro) " & _
                      "VALUES (@empresa,@codigo_tabla,@codigo_item,@nombre_corto,@nombre_largo,@logico_01,@logico_02,@logico_03,@logico_04,@logico_05,@texto_01," & _
                      "@texto_02,@texto_03,@texto_04,@texto_05,@valor_01,@valor_02,@valor_03,@valor_04,@valor_05,@estado,@usuario_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("empresa", TablaDetalle.empresa)
                .AddWithValue("codigo_tabla", TablaDetalle.codigo_tabla)
                .AddWithValue("codigo_item", TablaDetalle.codigo_item)
                .AddWithValue("nombre_corto", TablaDetalle.nombre_corto)
                .AddWithValue("nombre_largo", TablaDetalle.nombre_largo)
                .AddWithValue("logico_01", TablaDetalle.logico_01)
                .AddWithValue("logico_02", TablaDetalle.logico_02)
                .AddWithValue("logico_03", TablaDetalle.logico_03)
                .AddWithValue("logico_04", TablaDetalle.logico_04)
                .AddWithValue("logico_05", TablaDetalle.logico_05)
                .AddWithValue("texto_01", TablaDetalle.texto_01)
                .AddWithValue("texto_02", TablaDetalle.texto_02)
                .AddWithValue("texto_03", TablaDetalle.texto_03)
                .AddWithValue("texto_04", TablaDetalle.texto_04)
                .AddWithValue("texto_05", TablaDetalle.texto_05)
                .AddWithValue("valor_01", TablaDetalle.valor_01)
                .AddWithValue("valor_02", TablaDetalle.valor_02)
                .AddWithValue("valor_03", TablaDetalle.valor_03)
                .AddWithValue("valor_04", TablaDetalle.valor_04)
                .AddWithValue("valor_05", TablaDetalle.valor_05)
                .AddWithValue("estado", TablaDetalle.estado)
                .AddWithValue("usuario_registro", TablaDetalle.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()

                Return TablaDetalle
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

    Private Shared Function Actualizar(ByVal TablaDetalle As entTablaDetalle) As entTablaDetalle

        MySqlString = "UPDATE GEN.TABLAS_DETALLE set nombre_corto=@nombre_corto,nombre_largo=@nombre_largo,logico_01=@logico_01, logico_02=@logico_02, " & _
                      "logico_03=@logico_03,logico_04=@logico_04, logico_05=@logico_05, texto_01=@texto_01, texto_02=@texto_02, texto_03=@texto_03, texto_04=@texto_04, " & _
                      "texto_05=@texto_05, valor_01=@valor_01, valor_02=@valor_02,valor_03=@valor_03, valor_04=@valor_04, valor_05=@valor_05, estado=@estado, " & _
                      "usuario_modifica=@usuario_modifica, fecha_modifica=GETDATE() " & _
                      "WHERE empresa=@empresa AND codigo_tabla=@codigo_tabla AND codigo_item=@codigo_item"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters

                .AddWithValue("nombre_corto", TablaDetalle.nombre_corto)
                .AddWithValue("nombre_largo", TablaDetalle.nombre_largo)
                .AddWithValue("logico_01", TablaDetalle.logico_01)
                .AddWithValue("logico_02", TablaDetalle.logico_02)
                .AddWithValue("logico_03", TablaDetalle.logico_03)
                .AddWithValue("logico_04", TablaDetalle.logico_04)
                .AddWithValue("logico_05", TablaDetalle.logico_05)
                .AddWithValue("texto_01", TablaDetalle.texto_01)
                .AddWithValue("texto_02", TablaDetalle.texto_02)
                .AddWithValue("texto_03", TablaDetalle.texto_03)
                .AddWithValue("texto_04", TablaDetalle.texto_04)
                .AddWithValue("texto_05", TablaDetalle.texto_05)
                .AddWithValue("valor_01", TablaDetalle.valor_01)
                .AddWithValue("valor_02", TablaDetalle.valor_02)
                .AddWithValue("valor_03", TablaDetalle.valor_03)
                .AddWithValue("valor_04", TablaDetalle.valor_04)
                .AddWithValue("valor_05", TablaDetalle.valor_05)
                .AddWithValue("estado", TablaDetalle.estado)
                .AddWithValue("usuario_modifica", TablaDetalle.usuario_registro)
                .AddWithValue("empresa", TablaDetalle.empresa)
                .AddWithValue("codigo_tabla", TablaDetalle.codigo_tabla)
                .AddWithValue("codigo_item", TablaDetalle.codigo_item)

            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()

                Return TablaDetalle
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

    Public Shared Function MantenimientoUsuario(ByVal TablaDetalle As entTablaDetalle, EsNuevo As Boolean) As Boolean
        Dim MyTablaDetalle As New entTablaDetalle
        If EsNuevo Then
            MyTablaDetalle = Insertar(TablaDetalle, True)
        Else
            MyTablaDetalle = Actualizar(TablaDetalle)
        End If
        Return True
    End Function

    'Public Shared Function ObtenerTipoGuias() As dsTablasGenericas.TABLA_TIPO_GUIADataTable
    '    Dim MyDT As New dsTablasGenericas.TABLA_TIPO_GUIADataTable
    '    Dim MySql As String = "SELECT EMPRESA, CODIGO_ITEM AS CODIGO, NOMBRE_CORTO AS DESCRIPCION," & _
    '                          "CASE WHEN LOGICO_01=0 THEN 'NO' ELSE 'SI' END AS AFECTA_STOCK," & _
    '                          "CASE WHEN ESTADO='ACT' THEN 'SI' ELSE 'NO' END AS INDICA_ACTIVO " & _
    '                          "FROM GEN.TABLAS_DETALLE " & _
    '                          "WHERE EMPRESA='" & MyUsuario.empresa & "' AND CODIGO_TABLA = 'COM_TIPO_GUIA' " & _
    '                          "ORDER BY CODIGO"
    '    Call ObtenerDataTableSQL(MySql, MyDT)
    '    Return MyDT
    'End Function

#End Region

End Class
