Imports System.Data.SqlClient

Module MyCommonTables

    Private myCommand As String

    Private MyTablaGenerica As New dsTablasGenericas.TABLAS_DETALLEDataTable

    Private MyListaGenerica As New dsTablasGenericas.LISTADataTable
    Private MyListaEmpresa As New dsTablasGenericas.LISTADataTable

    Sub New()
        Call ActualizarTablasGenericas()
    End Sub

    Public Sub ActualizarTablasGenericas()
        MyListaGenerica = New dsTablasGenericas.LISTADataTable
        MyListaEmpresa = New dsTablasGenericas.LISTADataTable

        myCommand = "SELECT * FROM GEN.TABLAS_DETALLE WHERE EMPRESA IN ('000','" & MyUsuario.empresa & "') AND ESTADO='ACT'"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenerica)

        If MyTablaGenerica.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyTablaGenerica.Rows.Count - 1
                With MyTablaGenerica(NEle)
                    If .EMPRESA = "000" Then
                        MyListaGenerica.Rows.Add(.CODIGO_TABLA, .CODIGO_ITEM, .NOMBRE_CORTO, .NOMBRE_LARGO, .TEXTO_01, .LOGICO_01)
                    Else
                        MyListaEmpresa.Rows.Add(.CODIGO_TABLA, .CODIGO_ITEM, .NOMBRE_CORTO, .NOMBRE_LARGO, .TEXTO_01, .LOGICO_01)
                    End If
                End With
            Next
        End If
    End Sub

    Public Sub ActualizarMyDTProductos()
        CadenaSQL = "SELECT EMPRESA, PRODUCTO, RTRIM(DESCRIPCION_AMPLIADA) AS DESCRIPCION_AMPLIADA, UNIDAD_MEDIDA, RTRIM(CODIGO_COMPRA) AS CODIGO_COMPRA," & _
                    "RTRIM(DESCRIPCION_COMPRA) AS DESCRIPCION_COMPRA, INDICA_SERIE, INDICA_LOTE, INDICA_VENCIMIENTO, INDICA_VALIDA_STOCK, INDICA_AFECTO, " & _
                    "INDICA_COMPUESTO, INDICA_PROMOCIONAL, PARTIDA_ARANCELARIA, CODIGO_ANTIGUO, CASE WHEN ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO " & _
                    "FROM COM.PRODUCTOS " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Call ObtenerProductos(CadenaSQL)
    End Sub

    Public Sub ActualizarMyDTCuentasComerciales()
        CadenaSQL = "SELECT EMPRESA, CUENTA_COMERCIAL, GRUPO_COMERCIAL, TIPO_CUENTA, TIPO_DOCUMENTO, NRO_DOCUMENTO,RTRIM(RAZON_SOCIAL) AS RAZON_SOCIAL," & _
                    "RTRIM(DOMICILIO) AS DOMICILIO, INDICA_NO_DOMICILIADO, TIPO_MONEDA, CONDICION_PAGO, LINEA_CREDITO_MN, LINEA_CREDITO_ME, LISTA_PRECIOS, " & _
                    "AFECTO_IGV, AGENTE_RETENCION, AGENTE_DETRACCION, AGENTE_PERCEPCION, INDICA_CLIENTE, INDICA_PROVEEDOR, CODIGO_VENDEDOR, CODIGO_COMPRADOR, " & _
                    "CODIGO_ANTIGUO, CASE WHEN ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO " & _
                    "FROM COM.CUENTAS_COMERCIALES " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Call ObtenerCuentasComerciales(CadenaSQL)
    End Sub

    Public Sub ActualizarMyDTClientes()
        CadenaSQL = "SELECT EMPRESA,  ROW_NUMBER() OVER (ORDER BY CODIGO_ANTIGUO) AS CUENTA_COMERCIAL, SPACE(1) AS GRUPO_COMERCIAL, SPACE(1) AS TIPO_CUENTA, TIPO_DOCUMENTO, NRO_DOCUMENTO,RTRIM(RAZON_SOCIAL) AS RAZON_SOCIAL," & _
                    "RTRIM(DOMICILIO) AS DOMICILIO, INDICA_NO_DOMICILIADO='NO', TIPO_MONEDA='1', SPACE(1) AS CONDICION_PAGO, LINEA_CREDITO_MN, LINEA_CREDITO_ME, SPACE(1) AS LISTA_PRECIOS, " & _
                    "AFECTO_IGV, AGENTE_RETENCION='NO', AGENTE_DETRACCION='NO', AGENTE_PERCEPCION='NO', INDICA_CLIENTE='SI', INDICA_PROVEEDOR='NO', SPACE(1) AS CODIGO_VENDEDOR, SPACE(1) AS CODIGO_COMPRADOR, " & _
                    "CODIGO_ANTIGUO, CASE WHEN ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO " & _
                    "FROM FIN.CLIENTES " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' "
        Call ObtenerClientes(CadenaSQL)
    End Sub

    Public Sub ActualizarMyDTAlmacenes()
        CadenaSQL = "SELECT 'ALMACEN' AS TABLA, CODIGO, DESCRIPCION, DESCRIPCION AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                    "FROM GEN.TABLA_ALMACENES " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' AND INDICA_ACTIVO='SI' "
        Call ObtenerAlmacenes(CadenaSQL)
    End Sub

    Public Function AlmacenesExternos() As dsTablasGenericas.LISTADataTable
        Dim MyDT As New dsTablasGenericas.LISTADataTable
        CadenaSQL = "SELECT 'COM_ALMACEN' AS TABLA, CODIGO, DESCRIPCION, DESCRIPCION AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                    "FROM GEN.TABLA_ALMACENES " & _
                    "WHERE EMPRESA='" & MyUsuario.empresa & "' AND CODIGO>='800' AND INDICA_VENTA='SI' "
        Procesos.ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Sub ActualizarListaGenerica(ByRef Sender As ComboBox, ByVal CodigoTabla As String)
        Sender.DataSource = MyListaGenerica.Select("TABLA='" & CodigoTabla & "' ", "DESCRIPCION")
    End Sub

    Public Sub ActualizarListaEmpresa(ByRef Sender As ComboBox, ByVal CodigoTabla As String)
        Sender.DataSource = MyListaEmpresa.Select("TABLA='" & CodigoTabla & "' ", "DESCRIPCION")
    End Sub

    Public Sub ActualizarTablaProvincia(ByVal CodigoTabla As String, ByRef MyCombo As ComboBox, ByVal CodigoRegion As String)
        MyCombo.DataSource = MyListaGenerica.Select("TABLA='" & CodigoTabla & "' AND SUBSTRING(CODIGO,1,2)='" & CodigoRegion & "' ", "DESCRIPCION")
    End Sub

    Public Sub ActualizarTablaUbigeo(ByVal CodigoTabla As String, ByRef MyCombo As ComboBox, ByVal CodigoRegion As String, ByVal CodigoProvincia As String)
        MyCombo.DataSource = MyListaGenerica.Select("TABLA='" & CodigoTabla & "' AND SUBSTRING(CODIGO,1,4)='" & CodigoProvincia & "' ", "DESCRIPCION")
    End Sub

    Public Sub ActualizarLista(ByRef Sender As ComboBox, pEstado As String)
        Dim MyTabla As New dsTablasGenericas.LISTADataTable
        Select Case Sender.Name
            Case Is = "cmbListaPrecios"
                myCommand = "SELECT 'LISTA_PRECIO' AS TABLA, LISTA_PRECIOS AS CODIGO, LEFT(COMENTARIO,50) AS DESCRIPCION, LEFT(COMENTARIO,250) AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                            "FROM COM.LISTA_PRECIOS " & _
                            "WHERE EMPRESA='" & MyUsuario.empresa & "' " & _
                            IIf(pEstado = "TODOS", " ", " AND ESTADO='" & pEstado & "' ") & _
                            "ORDER BY COMENTARIO "
            Case Is = "cmbGrupoComercial"
                myCommand = "SELECT 'GRUPO_COMERCIAL' AS TABLA, GRUPO_COMERCIAL AS CODIGO, LEFT(DENOMINACION,50) AS DESCRIPCION, LEFT(DENOMINACION,250) AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                            "FROM COM.GRUPOS_COMERCIALES " & _
                            "WHERE EMPRESA='" & MyUsuario.empresa & "' " & _
                            IIf(pEstado = "TODOS", " ", " AND ESTADO='" & pEstado & "' ") & _
                            "ORDER BY DENOMINACION"
            Case Is = "cmbAgencia"
                myCommand = "SELECT 'AGENCIA' AS TABLA, AGENCIA AS CODIGO, LEFT(ABREVIATURA,50) AS DESCRIPCION, LEFT(RAZON_SOCIAL,250) AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                            "FROM COM.AGENCIAS " & _
                            "WHERE EMPRESA='" & MyUsuario.empresa & "' AND AGENCIA<>'A0000000' " & _
                            IIf(pEstado = "TODOS", " ", " AND ESTADO='" & pEstado & "' ") & _
                            "ORDER BY ABREVIATURA"
            Case Is = "cmbTrabajador"
                myCommand = "SELECT 'TRABAJADOR' AS TABLA, TRABAJADOR AS CODIGO, LEFT(APELLIDO_PATERNO+' '+APELLIDO_MATERNO+' '+NOMBRE,50) AS DESCRIPCION, LEFT(APELLIDO_PATERNO+' '+APELLIDO_MATERNO+' '+NOMBRE,250) AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                            "FROM REM.TRABAJADORES " & _
                            "WHERE EMPRESA='" & MyUsuario.empresa & "' " & _
                            IIf(pEstado = "TODOS", " ", " AND ESTADO='" & pEstado & "' ") & _
                            "ORDER BY APELLIDO_PATERNO, APELLIDO_MATERNO, NOMBRE"
            Case Is = "cmbPerfil"
                myCommand = "SELECT 'PERFIL' AS TABLA, CODIGO_ITEM AS CODIGO, LEFT(NOMBRE_CORTO,50) AS DESCRIPCION, LEFT(NOMBRE_LARGO,250) AS DESCRIPCION_AMPLIADA, SPACE(1) AS REFERENCIA, 0 AS ES_VEHICULAR " & _
                            "FROM GEN.TABLAS_DETALLE " & _
                            "WHERE EMPRESA='000' AND CODIGO_TABLA='USUARIOS' AND TEXTO_03='" & MyUsuario.empresa & "' AND LOGICO_01=1 " & _
                            IIf(pEstado = "TODOS", " ", " AND ESTADO='" & pEstado & "' ") & _
                            "ORDER BY NOMBRE_LARGO"
        End Select
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTabla)
        Sender.DataSource = MyTabla
    End Sub

    Public Sub DomicilioEnvio(ByVal pEmpresa As String, ByVal pCuentaComercial As String, ByRef NombreCombo As ComboBox)
        Dim MyStoreProcedure As String = "COM.DOMICILIO_ENVIO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.Char, 8) : MyParameter_2.Value = pCuentaComercial

        Dim MyDT As New DataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        NombreCombo.DataSource = MyDT
    End Sub

    Public Sub ActualizarSubTabla(ByRef Sender As ComboBox, ByVal CodigoTabla As String, ByVal CodigoReferencia As String)
        Sender.DataSource = MyListaEmpresa.Select("TABLA='" & CodigoTabla & "' AND REFERENCIA='" & CodigoReferencia & "' ", "DESCRIPCION")
    End Sub

    Public Function CargarTablaGenerica(ByVal CodigoTabla As String) As dsTablasGenericas.DETALLESDataTable
        Dim query As System.Data.EnumerableRowCollection(Of BusinessManager.dsTablasGenericas.TABLAS_DETALLERow)

        Dim MyDT As New dsTablasGenericas.DETALLESDataTable

        query = From elements In MyTablaGenerica _
                Where elements.EMPRESA = "000" And elements.CODIGO_TABLA = CodigoTabla _
                Order By elements.NOMBRE_LARGO _
                Select elements

        Dim MyDTElementsView As DataView = query.AsDataView

        For Each MyFila As DataRowView In MyDTElementsView
            With MyFila
                MyDT.Rows.Add(.Item("EMPRESA"), .Item("CODIGO_TABLA"), .Item("CODIGO_ITEM"), .Item("NOMBRE_CORTO"), .Item("NOMBRE_LARGO") _
                              , .Item("TEXTO_01"), .Item("TEXTO_02"), .Item("TEXTO_03"), .Item("TEXTO_04"), .Item("TEXTO_05") _
                              , .Item("VALOR_01"), .Item("VALOR_02"), .Item("VALOR_03"), .Item("VALOR_04"), .Item("VALOR_05") _
                              , .Item("LOGICO_01"), .Item("LOGICO_02"), .Item("LOGICO_03"), .Item("LOGICO_04"), .Item("LOGICO_05") _
                              , .Item("ESTADO"), .Item("PERMITE_ELIMINAR"), .Item("VALOR_DEFECTO"), .Item("USUARIO_REGISTRO"), .Item("FECHA_REGISTRO") _
                              , .Item("USUARIO_MODIFICA"), .Item("FECHA_MODIFICA"))
            End With
        Next

        Return MyDT

    End Function

    Public Function ObtenerListaEmpresa(ByVal CodigoTabla As String, Orden As String) As dsTablasGenericas.LISTADataTable
        Dim MyLista As New dsTablasGenericas.LISTADataTable
        Dim MyDataView = New DataView(MyListaEmpresa, "TABLA='" & CodigoTabla & "' ", Orden, DataViewRowState.CurrentRows)

        Dim Tabla As String
        Dim Codigo As String
        Dim Descripcion As String
        Dim Descripcion_Ampliada As String
        Dim Referencia As String
        Dim EsVehicular As Boolean

        MyLista.Rows.Add(CodigoTabla, "TODOS", "TODOS", "TODOS", Space(1), False)

        For I = 0 To MyDataView.Count - 1
            Tabla = MyDataView.Item(I)(0)                ' CODIGO_TABLA
            Codigo = MyDataView.Item(I)(1)               ' CODIGO_ITEM
            Descripcion = MyDataView.Item(I)(2)          ' NOMBRE_CORTO
            Descripcion_Ampliada = MyDataView.Item(I)(3) ' NOMBRE_LARGO
            Referencia = MyDataView.Item(I)(4)           ' TEXTO_01
            EsVehicular = MyDataView.Item(I)(5)          ' LOGICO_01

            MyLista.Rows.Add(Tabla, Codigo.Trim, Descripcion.Trim, Descripcion_Ampliada.Trim, Referencia.Trim, EsVehicular)
        Next I

        Return MyLista
    End Function

    Public Function ObtenerListaEmpresa(ByVal CodigoTabla As String, EsTablaEmpresa As Boolean) As dsTablasGenericas.LISTADataTable
        Dim MyLista As New dsTablasGenericas.LISTADataTable
        Dim MyDataView As DataView

        If EsTablaEmpresa = True Then
            MyDataView = New DataView(MyListaEmpresa, "TABLA='" & CodigoTabla & "' ", "DESCRIPCION_AMPLIADA", DataViewRowState.CurrentRows)
        Else
            MyDataView = New DataView(MyListaGenerica, "TABLA='" & CodigoTabla & "' ", "DESCRIPCION_AMPLIADA", DataViewRowState.CurrentRows)
        End If

        Dim Tabla As String
        Dim Codigo As String
        Dim Descripcion As String
        Dim Descripcion_Ampliada As String
        Dim Referencia As String
        Dim EsVehicular As Boolean

        For I = 0 To MyDataView.Count - 1
            Tabla = MyDataView.Item(I)(0)                ' CODIGO_TABLA
            Codigo = MyDataView.Item(I)(1)               ' CODIGO_ITEM
            Descripcion = MyDataView.Item(I)(2)          ' NOMBRE_CORTO
            Descripcion_Ampliada = MyDataView.Item(I)(3) ' NOMBRE_LARGO
            Referencia = MyDataView.Item(I)(4)           ' TEXTO_01
            EsVehicular = MyDataView.Item(I)(5)          ' LOGICO_01

            MyLista.Rows.Add(Tabla, Codigo.Trim, Descripcion.Trim, Descripcion_Ampliada.Trim, Referencia.Trim, EsVehicular)
        Next I

        Return MyLista
    End Function

    Public Function ObtenerDescripcion(ByVal CodigoTabla As String, ByVal CodigoItem As String, EsGenerica As Boolean) As String
        Dim Descripcion As String
        Dim MyElementoLista As dsTablasGenericas.LISTARow

        Dim PrimaryKey(1) As Object
        PrimaryKey(0) = CodigoTabla
        PrimaryKey(1) = CodigoItem

        If EsGenerica = True Then
            MyElementoLista = MyListaGenerica.Rows.Find(PrimaryKey)
        Else
            MyElementoLista = MyListaEmpresa.Rows.Find(PrimaryKey)
        End If

        If Not MyElementoLista Is Nothing Then
            Descripcion = MyElementoLista.DESCRIPCION_AMPLIADA
        Else
            Descripcion = Space(1)
        End If
        Return Descripcion
    End Function

    Public Function ObtenerEsVehicular(ByVal CodigoTabla As String, ByVal CodigoItem As String) As Boolean
        Dim EsVehicular As Boolean
        Dim MyElementoLista As dsTablasGenericas.LISTARow

        Dim PrimaryKey(1) As Object
        PrimaryKey(0) = CodigoTabla
        PrimaryKey(1) = CodigoItem

        MyElementoLista = MyListaEmpresa.Rows.Find(PrimaryKey)

        If Not MyElementoLista Is Nothing Then
            EsVehicular = MyElementoLista.ES_VEHICULAR
        Else
            EsVehicular = False
        End If
        Return EsVehicular
    End Function

    Public Function NumeroAleatorio() As String
        Dim Random As New Random()
        Dim Numero As Long = Random.Next(1, 9999)
        Return Now.ToString("hhmmss") & Numero.ToString("0000")
    End Function

End Module
