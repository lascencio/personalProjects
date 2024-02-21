Imports System.Data.SqlClient

Public Class dalTablaDetalle

    Private Shared MyStringSql As String

    Private Sub New()
    End Sub

    Public Shared Function Existe(ByVal TablaDetalle As entTablaDetalle) As Boolean
        Return Existe(TablaDetalle.empresa, TablaDetalle.codigo_tabla, TablaDetalle.codigo_item)
    End Function

    Private Shared Function Existe(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.TABLAS_DETALLE " & _
                              "WHERE Empresa=@empresa AND codigo_tabla=@codigo_tabla and codigo_item=@codigo_item"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MyCommand As New SqlCommand(MySql, MySQLDbconnection)
            MyCommand.Parameters.AddWithValue("empresa", Empresa)
            MyCommand.Parameters.AddWithValue("codigo_tabla", Codigo_Tabla)
            MyCommand.Parameters.AddWithValue("codigo_item", Codigo_Item)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MyCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Obtener(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As entTablaDetalle
        If Existe(Empresa, Codigo_Tabla, Codigo_Item) Then
            CadenaSQL = "SELECT * FROM GEN.TABLAS_DETALLE " & _
                         "WHERE EMPRESA='" & Empresa & "' AND CODIGO_TABLA='" & Codigo_Tabla & "' AND CODIGO_ITEM='" & Codigo_Item & "' "
            Return Obtener(New entTablaDetalle, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entTablaDetalle
        End If
    End Function

    Public Shared Function Buscar(ByVal Empresa As String, ByVal codigo_tabla As String, ByVal codigo_item As String) As Boolean
        If Existe(Empresa, codigo_tabla, codigo_item) Then Return True
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

    Public Shared Function Grabar(ByVal TablaDetalle As entTablaDetalle) As entTablaDetalle

        With TablaDetalle
            If String.IsNullOrEmpty(.codigo_tabla) Then Throw New BusinessException(MSG000 & " TABLA")
            If String.IsNullOrEmpty(.nombre_corto) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
            If String.IsNullOrEmpty(.nombre_largo) Then Throw New BusinessException(MSG000 & " DESCRIPCION AMPLIADA")
            If .codigo_tabla = "USUARIOS" And String.IsNullOrEmpty(.texto_03) Then Throw New BusinessException(MSG000 & " EMPRESA")
            If .codigo_tabla = "USUARIOS" And String.IsNullOrEmpty(.texto_05) Then Throw New BusinessException(MSG000 & " PRIVILEGIOS")
        End With
        If Not Existe(TablaDetalle) Then
            Return Insertar(TablaDetalle, myConnectionStringSQL_Repository, True)
        Else
            Return Actualizar(TablaDetalle)
        End If
    End Function

    Private Shared Function Actualizar(ByVal TablaDetalle As entTablaDetalle) As entTablaDetalle

        Dim MySql As String = " UPDATE GEN.TABLAS_DETALLE set nombre_corto =@nombre_corto" & _
                              ",nombre_largo =@nombre_largo" & _
                              ",logico_01 =@logico_01, logico_02 =@logico_02, logico_03 =@logico_03" & _
                              ",logico_04 =@logico_04, logico_05 =@logico_05, texto_01 =@texto_01" & _
                              " ,texto_02 =@texto_02, texto_03 =@texto_03, texto_04 =@texto_04" & _
                              " ,texto_05 =@texto_05, valor_01 =@valor_01, valor_02 =@valor_02" & _
                              " ,valor_03 =@valor_03, valor_04 =@valor_04, valor_05 =@valor_05" & _
                              " ,estado =@estado" & _
                              " ,usuario_modifica =@usuario_modifica, fecha_modifica =@fecha_modifica" & _
                              " WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla AND codigo_item =@codigo_item"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

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
                .AddWithValue("fecha_modifica", Now)
                .AddWithValue("empresa", TablaDetalle.empresa)
                .AddWithValue("codigo_tabla", TablaDetalle.codigo_tabla)
                .AddWithValue("codigo_item", TablaDetalle.codigo_item)

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

    Private Shared Function Insertar(ByVal TablaDetalle As entTablaDetalle, ByVal MyConnectionString As String, ByVal ObtenerCodigo As Boolean) As entTablaDetalle
        Dim MySql As String = " INSERT INTO GEN.TABLAS_DETALLE " & _
                             "(empresa,codigo_tabla,codigo_item,nombre_corto" & _
                              ",nombre_largo,logico_01,logico_02,logico_03" & _
                              ",logico_04,logico_05,texto_01,texto_02,texto_03" & _
                              ",texto_04,texto_05,valor_01,valor_02,valor_03" & _
                              ",valor_04,valor_05,estado,usuario_registro" & _
                              ",fecha_registro)" & _
                              " VALUES (@empresa,@codigo_tabla,@codigo_item,@nombre_corto,@nombre_largo" & _
                              ",@logico_01,@logico_02,@logico_03,@logico_04,@logico_05,@texto_01" & _
                              ",@texto_02,@texto_03,@texto_04,@texto_05,@valor_01" & _
                              ",@valor_02,@valor_03,@valor_04,@valor_05,@estado,@usuario_registro" & _
                              ",@fecha_registro)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

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

    Public Shared Function Borrar(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String, ByVal Nombre_Item As String) As Boolean
        Resp = MsgBox("Esta seguro de eliminar el item " & Nombre_Item & "?", MsgBoxStyle.YesNo, "CONFIRMAR PROCESO")
        If Resp = 6 Then
            Call Eliminar(Empresa, Codigo_Tabla, Codigo_Item)
            Return True
        End If
    End Function

    Private Shared Function Eliminar(ByVal Empresa As String, ByVal Codigo_Tabla As String, ByVal Codigo_Item As String) As Boolean
        Dim MySql As String = "DELETE FROM GEN.TABLAS_DETALLE " & _
                              "WHERE  empresa =@empresa AND codigo_tabla =@codigo_tabla AND codigo_item =@codigo_item"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("empresa", Empresa)
                .AddWithValue("codigo_tabla", Codigo_Tabla)
                .AddWithValue("codigo_item", Codigo_Item)
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

    Public Shared Function ObtenerDetalles(ByVal Empresa As String, ByVal CodigoTabla As String, ByVal Estado As String) As dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MySql As String = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & Empresa & "'  AND CODIGO_TABLA='" & CodigoTabla & "' " & _
                              IIf(Estado <> "T", "AND ACTIVO=1 ", " ") & _
                              "ORDER BY CODIGO"
        Call ObtenerDataTableSQL(MySql, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarElemento(ByVal pEmpresa As String, ByVal pTabla As String, ByVal pDescripcion As String) As dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MySql As String = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & pEmpresa & "'  AND CODIGO_TABLA='" & pTabla & "' AND " & _
                              "DESCRIPCION LIKE '%" & pDescripcion & "%'" & _
                              "ORDER BY DESCRIPCION "
        Call ObtenerDataTableSQL(MySql, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarElementosNombre(ByVal pEmpresa As String, ByVal pTabla As String, ByVal pDescripcion As String) As dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MySql As String = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & pEmpresa & "'  AND CODIGO_TABLA='" & pTabla & "' AND " & _
                              "DESCRIPCION LIKE '%" & pDescripcion & "%'" & _
                              "ORDER BY DESCRIPCION "
        Call ObtenerDataTableSQL(MySql, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarElementosCodigo(ByVal pEmpresa As String, ByVal pTabla As String, ByVal pCodigo As String) As dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MyDT As New dsTablasDetalleLista.TABLAS_DETALLE_LISTADataTable
        Dim MySql As String = "SELECT * FROM GEN.TABLAS_DETALLE_LISTA WHERE EMPRESA='" & pEmpresa & "'  AND CODIGO_TABLA='" & pTabla & "' AND " & _
                              "CODIGO LIKE '" & pCodigo & "%'" & _
                              "ORDER BY CODIGO "
        Call ObtenerDataTableSQL(MySql, MyDT)
        Return MyDT
    End Function

    Public Shared Function GrabarSiNoExiste(ByVal TablaDetalle As entTablaDetalle) As entTablaDetalle
        If Not ExisteElemento(TablaDetalle) Then
            TablaDetalle.codigo_item = AsignarCodigoElemento(TablaDetalle)
            Return Insertar(TablaDetalle, myConnectionStringSQL_Repository, True)
        Else
            Return New entTablaDetalle
        End If
    End Function

    Private Shared Function ExisteElemento(ByVal TablaDetalle As entTablaDetalle) As Boolean
        Dim MySql As String = "SELECT COUNT(*) FROM GEN.TABLAS_DETALLE " & _
                              "WHERE Empresa=@Empresa AND Codigo_tabla=@Codigo_tabla and Nombre_corto=@Nombre_corto"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MyCommand As New SqlCommand(MySql, MySQLDbconnection)
            MyCommand.Parameters.AddWithValue("Empresa", TablaDetalle.empresa)
            MyCommand.Parameters.AddWithValue("Codigo_tabla", TablaDetalle.codigo_tabla)
            MyCommand.Parameters.AddWithValue("Nombre_corto", TablaDetalle.nombre_corto.Trim)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MyCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function AsignarCodigoElemento(ByVal TablaDetalle As entTablaDetalle) As String
        Dim MySql As String = "SELECT MAX(CODIGO_ITEM) AS ULTIMO_CODIGO FROM GEN.TABLAS_DETALLE " & _
                              "WHERE Empresa=@Empresa AND Codigo_tabla=@Codigo_tabla"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MyCommand As New SqlCommand(MySql, MySQLDbconnection)
            MyCommand.Parameters.AddWithValue("Empresa", TablaDetalle.empresa)
            MyCommand.Parameters.AddWithValue("Codigo_tabla", TablaDetalle.codigo_tabla)
            MySQLDbconnection.Open()
            Dim MyLastCode As String = MyCommand.ExecuteScalar
            Dim MyNewCode As String = CStr(Val(MyLastCode) + 1)
            Return MyNewCode
        End Using
    End Function

    Public Shared Function ObtenerCentroCosto(ByVal pEmpresa As String, ByVal pDigitos As String) As String
        Dim MyCentroCosto As String
        Dim MySql As String = "SELECT TEXTO_01 AS CENTRO_COSTO FROM GEN.TABLAS_DETALLE " & _
                              "WHERE Empresa=@vEmpresa AND Codigo_tabla='CON_ESTUDIO_CCOSTO' AND Codigo_item=@vCodigo_item "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MyCommand As New SqlCommand(MySql, MySQLDbconnection)
            MyCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MyCommand.Parameters.AddWithValue("vCodigo_item", pDigitos)
            MySQLDbconnection.Open()
            MyCentroCosto = MyCommand.ExecuteScalar
        End Using
        Return MyCentroCosto
    End Function

    Public Shared Function ObtenerElemento(ByVal pTabla As String, ByVal pCodigo As String) As entListaElemento
        If ExisteListaElemento(pTabla, pCodigo) Then
            MyStringSql = "SELECT CODIGO_TABLA AS TABLA, CODIGO_ITEM AS CODIGO, NOMBRE_LARGO AS DESCRIPCION " & _
                          "FROM GEN.TABLAS_DETALLE " & _
                          "WHERE EMPRESA='" & MyUsuario.empresa & "' AND CODIGO_TABLA= '" & pTabla & "' AND CODIGO_ITEM='" & pCodigo & "' "
            Return Obtener(New entListaElemento, MyStringSql)
        Else
            Return New entListaElemento
        End If
    End Function

    Private Shared Function ExisteListaElemento(ByVal pTabla As String, ByVal pCodigo As String) As Boolean
        If Not String.IsNullOrEmpty(pCodigo) Then
            MyStringSql = "SELECT COUNT(*) FROM GEN.TABLAS_DETALLE " & _
                          "WHERE EMPRESA=@vEmpresa AND CODIGO_TABLA=@vCodigo_tabla AND CODIGO_ITEM=@vCodigo_item "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vCodigo_tabla", pTabla)
                MySQLCommand.Parameters.AddWithValue("vCodigo_item", pCodigo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Obtener(ByVal cListaElemento As entListaElemento, ByVal MyStringSQL As String) As entListaElemento
        Dim MyDT As New dsTablasGenericas.LISTADataTable
        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cListaElemento
                .codigo = MyDT(0).CODIGO
                .descripcion = MyDT(0).DESCRIPCION
            End With
        End If
        Return cListaElemento

    End Function

    Public Shared Function BuscarListaCodigo(ByVal pTabla As String, ByVal pCodigo As String) As DataTable
        MyStringSql = "SELECT CODIGO_ITEM AS CODIGO, NOMBRE_LARGO AS DESCRIPCION " & _
                      "FROM GEN.TABLAS_DETALLE " & _
                      "WHERE EMPRESA=@vEmpresa AND CODIGO_TABLA=@vCodigo_tabla AND CODIGO_ITEM LIKE @vCodigo+'%' " & _
                      "ORDER BY CODIGO_ITEM "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vCodigo_tabla", pTabla)
            MySQLCommand.Parameters.AddWithValue("vCodigo", pCodigo)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarListaNombre(ByVal pTabla As String, ByVal pDescripcion As String) As DataTable
        MyStringSql = "SELECT CODIGO_ITEM AS CODIGO, NOMBRE_LARGO AS DESCRIPCION " & _
                      "FROM GEN.TABLAS_DETALLE " & _
                      "WHERE EMPRESA=@vEmpresa AND CODIGO_TABLA=@vCodigo_tabla AND NOMBRE_LARGO LIKE '%'+@vDescripcion+'%' " & _
                      "ORDER BY NOMBRE_LARGO "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vCodigo_tabla", pTabla)
            MySQLCommand.Parameters.AddWithValue("vDescripcion", pDescripcion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function


End Class
