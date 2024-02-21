Imports System.Data.SqlClient

Public Class dalCuentaComercial

    Private Shared MySql As String
    Private Shared MySqlString As String

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pCuentaComercial As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaComercial) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCuentaComercial)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cCuentaComercial As entCuentaComercial) As Boolean
        If Not String.IsNullOrEmpty(cCuentaComercial.cuenta_comercial) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCuentaComercial.empresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", cCuentaComercial.cuenta_comercial)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String, ByVal pCuentaComercial As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipoDocumento " & _
                      "AND Nro_Documento=@vNumeroDocumento AND Cuenta_Comercial<>@vCuentaComercial "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vTipoDocumento", pTipoDocumento)
            MySQLCommand.Parameters.AddWithValue("vNumeroDocumento", pNumeroDocumento)
            MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCuentaComercial)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipoDocumento " & _
                      "AND Nro_Documento=@vNumeroDocumento "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vTipoDocumento", pTipoDocumento)
            MySQLCommand.Parameters.AddWithValue("vNumeroDocumento", pNumeroDocumento)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Obtener(ByVal pCuentaComercial As String) As entCuentaComercial
        If Existe(pCuentaComercial) Then
            CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES WHERE EMPRESA='" & MyUsuario.empresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "'"
            Return Obtener(New entCuentaComercial, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCuentaComercial
        End If
    End Function

    Public Shared Function Obtener(ByVal pTipoDocumento As String, ByVal pNroDocumento As String) As entCuentaComercial
        If Existe(pTipoDocumento, pNroDocumento) Then
            CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES WHERE EMPRESA='" & MyUsuario.empresa & "' AND TIPO_DOCUMENTO='" & pTipoDocumento & "' AND " & _
                        "NRO_DOCUMENTO='" & pNroDocumento & "'"
            Return Obtener(New entCuentaComercial, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCuentaComercial
        End If
    End Function

    Private Shared Function Obtener(ByVal cCuentaComercial As entCuentaComercial, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entCuentaComercial
        Dim MyDT As New dsCuentasComerciales.CUENTAS_COMERCIALESDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaComercial
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .tipo_documento = MyDT(0).TIPO_DOCUMENTO
                .nro_documento = MyDT(0).NRO_DOCUMENTO
                .razon_social = MyDT(0).RAZON_SOCIAL
                .domicilio = MyDT(0).DOMICILIO
                .siglas = MyDT(0).SIGLAS
                .via_tipo = MyDT(0).VIA_TIPO
                .via_nombre = MyDT(0).VIA_NOMBRE
                .via_numero = MyDT(0).VIA_NUMERO
                .via_interior = MyDT(0).VIA_INTERIOR
                .zona_tipo = MyDT(0).ZONA_TIPO
                .zona_nombre = MyDT(0).ZONA_NOMBRE
                .referencia = MyDT(0).REFERENCIA
                .pais = MyDT(0).PAIS
                .departamento = MyDT(0).DEPARTAMENTO
                .provincia = MyDT(0).PROVINCIA
                .ubigeo = MyDT(0).UBIGEO
                .indica_no_domiciliado = MyDT(0).INDICA_NO_DOMICILIADO
                .domicilio_envio = MyDT(0).DOMICILIO_ENVIO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .celular = MyDT(0).CELULAR
                .fax = MyDT(0).FAX
                .email = MyDT(0).EMAIL
                .pagina_web = MyDT(0).PAGINA_WEB
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .contacto_comercial = MyDT(0).CONTACTO_COMERCIAL
                .condicion_pago = MyDT(0).CONDICION_PAGO
                .tipo_pago = MyDT(0).TIPO_PAGO
                .tipo_documento_pago = MyDT(0).TIPO_DOCUMENTO_PAGO
                .linea_credito_mn = MyDT(0).LINEA_CREDITO_MN
                .linea_credito_me = MyDT(0).LINEA_CREDITO_ME
                .credito_disponible_mn = MyDT(0).CREDITO_DISPONIBLE_MN
                .credito_disponible_me = MyDT(0).CREDITO_DISPONIBLE_ME
                If Not MyDT(0).IsNull("VIGENCIA_CREDITO") Then .vigencia_credito = MyDT(0).VIGENCIA_CREDITO
                .lista_precios = MyDT(0).LISTA_PRECIOS
                .porcentaje_descuento_1 = MyDT(0).PORCENTAJE_DESCUENTO_1
                .porcentaje_descuento_2 = MyDT(0).PORCENTAJE_DESCUENTO_2
                .porcentaje_descuento_3 = MyDT(0).PORCENTAJE_DESCUENTO_3
                .cuenta_contable_cliente_mn = MyDT(0).CUENTA_CONTABLE_CLIENTE_MN
                .cuenta_contable_cliente_me = MyDT(0).CUENTA_CONTABLE_CLIENTE_ME
                .cuenta_contable_proveedor_mn = MyDT(0).CUENTA_CONTABLE_PROVEEDOR_MN
                .cuenta_contable_proveedor_me = MyDT(0).CUENTA_CONTABLE_PROVEEDOR_ME
                .cuenta_contable_ingreso = MyDT(0).CUENTA_CONTABLE_INGRESO
                .cuenta_contable_gasto = MyDT(0).CUENTA_CONTABLE_GASTO
                .cuenta_bancaria_mn = MyDT(0).CUENTA_BANCARIA_MN
                .cuenta_bancaria_me = MyDT(0).CUENTA_BANCARIA_ME
                .banco_pago_me = MyDT(0).BANCO_PAGO_ME
                .banco_pago_mn = MyDT(0).BANCO_PAGO_MN
                .vigente_sunat = MyDT(0).VIGENTE_SUNAT
                If Not MyDT(0).IsNull("FECHA_ALTA_SUNAT") Then .fecha_alta_sunat = MyDT(0).FECHA_ALTA_SUNAT
                .afecto_igv = MyDT(0).AFECTO_IGV
                .agente_retencion = MyDT(0).AGENTE_RETENCION
                .agente_detraccion = MyDT(0).AGENTE_DETRACCION
                .agente_percepcion = MyDT(0).AGENTE_PERCEPCION
                .indica_cliente = MyDT(0).INDICA_CLIENTE
                .indica_proveedor = MyDT(0).INDICA_PROVEEDOR
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_comprador = MyDT(0).CODIGO_COMPRADOR
                .ultima_compra = MyDT(0).ULTIMA_COMPRA
                .ultima_venta = MyDT(0).ULTIMA_VENTA
                .apellido_paterno = MyDT(0).APELLIDO_PATERNO
                .apellido_materno = MyDT(0).APELLIDO_MATERNO
                .nombres = MyDT(0).NOMBRES
                If Not MyDT(0).IsNull("FECHA_NACIMIENTO") Then .fecha_nacimiento = MyDT(0).FECHA_NACIMIENTO
                .sexo = MyDT(0).SEXO
                .calificacion = MyDT(0).CALIFICACION
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .comentario = MyDT(0).COMENTARIO
                .usuario_web = MyDT(0).USUARIO_WEB
                .clave_web = MyDT(0).CLAVE_WEB
                .codigo_antiguo = MyDT(0).CODIGO_ANTIGUO
                .cuenta_detraccion = MyDT(0).CUENTA_DETRACCION
                .porcentaje_detraccion = MyDT(0).PORCENTAJE_DETRACCION
                .estado = MyDT(0).ESTADO
                .item_flujo = MyDT(0).ITEM_FLUJO
                .exige_orden_compra = MyDT(0).EXIGE_ORDEN_COMPRA
                .tipo_orden_compra = MyDT(0).TIPO_ORDEN_COMPRA
                .exige_orden_pago = MyDT(0).EXIGE_ORDEN_PAGO
                .tipo_orden_pago = MyDT(0).TIPO_ORDEN_PAGO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cCuentaComercial
    End Function

    Public Shared Function Grabar(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial
        With cCuentaComercial
            If String.IsNullOrEmpty(.tipo_documento) Then Throw New BusinessException(MSG000 & " TIPO DE DOCUMENTO")
            If String.IsNullOrEmpty(.nro_documento.Trim) Then Throw New BusinessException(MSG000 & " NUMERO DE DOCUMENTO")
            If String.IsNullOrEmpty(.razon_social.Trim) Then Throw New BusinessException(MSG000 & " RAZON SOCIAL")
            If String.IsNullOrEmpty(.domicilio.Trim) Then Throw New BusinessException(MSG000 & " DOMICILIO FISCAL")

            If Not String.IsNullOrEmpty(.codigo_vendedor.Trim) Then
                If .codigo_vendedor.Trim.Length <> 7 Then Throw New BusinessException(MSG000 & " CODIGO VENDEDOR (7 CARACTERES)")
            End If

            'If String.IsNullOrEmpty(.siglas.Trim) Then Throw New BusinessException(MSG000 & " SIGLAS")
            'If String.IsNullOrEmpty(.item_flujo) Then Throw New BusinessException(MSG000 & " ITEM FLUJO")
            'If .exige_orden_compra = "SI" And String.IsNullOrEmpty(.tipo_orden_compra.Trim) Then Throw New BusinessException(MSG000 & " TIPO ORDEN DE COMPRA")
            'If .exige_orden_pago = "SI" And String.IsNullOrEmpty(.tipo_orden_pago.Trim) Then Throw New BusinessException(MSG000 & " TIPO ORDEN DE PAGO")

            If Existe(.tipo_documento, .nro_documento, .cuenta_comercial) Then
                Throw New BusinessException("El Tipo y Numero de Documento estan asignados a otra Cuenta Comercial")
            End If

        End With

        If Not Existe(cCuentaComercial) Then
            Return Insertar(cCuentaComercial, myConnectionStringSQL_Repository)
        Else
            Return Actualizar(cCuentaComercial)
        End If
    End Function

    Private Shared Function Insertar(ByVal cCuentaComercial As entCuentaComercial, ByVal MyConnectionString As String) As entCuentaComercial
        cCuentaComercial.cuenta_comercial = AsignarCodigo()
        MySql = "INSERT INTO COM.CUENTAS_COMERCIALES " & _
                "(empresa,cuenta_comercial,tipo_documento,nro_documento,razon_social,siglas,contacto_comercial,domicilio_envio,indica_no_domiciliado," & _
                "via_tipo,via_nombre,via_numero,via_interior,zona_tipo,zona_nombre,referencia,pais,departamento,provincia,ubigeo,codigo_postal,telefono," & _
                "celular,fax,email,pagina_web,tipo_moneda,condicion_pago,tipo_pago,tipo_documento_pago,linea_credito_mn,linea_credito_me," & _
                "cuenta_contable_cliente_mn,cuenta_contable_cliente_me,cuenta_contable_proveedor_mn,cuenta_contable_proveedor_me," & _
                "cuenta_bancaria_mn,cuenta_bancaria_me,banco_pago_mn,banco_pago_me,vigente_sunat,afecto_igv,agente_retencion," & _
                "agente_detraccion,agente_percepcion,indica_cliente,indica_proveedor,comentario,estado,item_flujo,usuario_registro,codigo_antiguo," & _
                "fecha_alta_sunat,fecha_nacimiento,vigencia_credito,porcentaje_descuento_1,porcentaje_descuento_2,porcentaje_descuento_3," & _
                "Cuenta_detraccion,Porcentaje_detraccion,Exige_orden_compra,Tipo_orden_compra,Exige_orden_pago,Tipo_orden_pago," & _
                "domicilio,codigo_vendedor,apellido_paterno,apellido_materno,nombres,sexo) " & _
                "VALUES (@vEmpresa,@vCuenta_comercial,@vTipo_documento,@vNro_documento,@vRazon_social,@vSiglas," & _
                "@vContacto_comercial,@vDomicilio_envio,@vIndica_no_domiciliado,@vVia_tipo,@vVia_nombre,@vVia_numero," & _
                "@vVia_interior,@vZona_tipo,@vZona_nombre,@vReferencia,@vPais,@vDepartamento,@vProvincia," & _
                "@vUbigeo,@vCodigo_postal,@vTelefono,@vCelular,@vFax,@vEmail,@vPagina_web,@vTipo_moneda," & _
                "@vCondicion_pago,@vTipo_pago,@vTipo_documento_pago,@vLinea_credito_mn,@vLinea_credito_me," & _
                "@vCuenta_contable_cliente_mn,@vCuenta_contable_cliente_me,@vCuenta_contable_proveedor_mn,@vCuenta_contable_proveedor_me," & _
                "@vCuenta_bancaria_mn,@vCuenta_bancaria_me,@vBanco_pago_mn,@vBanco_pago_mn,@vVigente_sunat,@vAfecto_igv,@vAgente_retencion," & _
                "@vAgente_detraccion,@vAgente_percepcion,@vIndica_cliente,@vIndica_proveedor,@vComentario,@vEstado,@vItem_flujo,@vUsuario_registro,@vCodigo_antiguo," & _
                "@vFecha_alta_sunat,@vFecha_nacimiento,@vVigencia_credito,@vPorcentaje_descuento_1,@vPorcentaje_descuento_2,@vPorcentaje_descuento_3," & _
                "@vCuenta_detraccion,@vPorcentaje_detraccion,@vExige_orden_compra,@vTipo_orden_compra,@vExige_orden_pago,@vTipo_orden_pago," & _
                "@vDomicilio,@vCodigo_vendedor,@vApellido_paterno,@vApellido_materno,@vNombres,@vSexo)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
                .AddWithValue("vTipo_documento", cCuentaComercial.tipo_documento)
                .AddWithValue("vNro_documento", cCuentaComercial.nro_documento)
                .AddWithValue("vRazon_social", cCuentaComercial.razon_social)
                .AddWithValue("vSiglas", cCuentaComercial.siglas)
                .AddWithValue("vContacto_comercial", cCuentaComercial.contacto_comercial)
                .AddWithValue("vDomicilio_envio", cCuentaComercial.domicilio_envio)
                .AddWithValue("vIndica_no_domiciliado", cCuentaComercial.indica_no_domiciliado)
                .AddWithValue("vVia_tipo", cCuentaComercial.via_tipo)
                .AddWithValue("vVia_nombre", cCuentaComercial.via_nombre)
                .AddWithValue("vVia_numero", cCuentaComercial.via_numero)
                .AddWithValue("vVia_interior", cCuentaComercial.via_interior)
                .AddWithValue("vZona_tipo", cCuentaComercial.zona_tipo)
                .AddWithValue("vZona_nombre", cCuentaComercial.zona_nombre)
                .AddWithValue("vReferencia", cCuentaComercial.referencia)
                .AddWithValue("vPais", cCuentaComercial.pais)
                .AddWithValue("vDepartamento", cCuentaComercial.departamento)
                .AddWithValue("vProvincia", cCuentaComercial.provincia)
                .AddWithValue("vUbigeo", cCuentaComercial.ubigeo)
                .AddWithValue("vCodigo_postal", cCuentaComercial.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vFax", cCuentaComercial.fax)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vPagina_web", cCuentaComercial.pagina_web)
                .AddWithValue("vTipo_moneda", cCuentaComercial.tipo_moneda)
                .AddWithValue("vCondicion_pago", cCuentaComercial.condicion_pago)
                .AddWithValue("vTipo_pago", cCuentaComercial.tipo_pago)
                .AddWithValue("vTipo_documento_pago", cCuentaComercial.tipo_documento_pago)
                .AddWithValue("vLinea_credito_mn", cCuentaComercial.linea_credito_mn)
                .AddWithValue("vLinea_credito_me", cCuentaComercial.linea_credito_me)
                .AddWithValue("vCuenta_contable_cliente_mn", cCuentaComercial.cuenta_contable_cliente_mn)
                .AddWithValue("vCuenta_contable_cliente_me", cCuentaComercial.cuenta_contable_cliente_me)
                .AddWithValue("vCuenta_contable_proveedor_mn", cCuentaComercial.cuenta_contable_proveedor_mn)
                .AddWithValue("vCuenta_contable_proveedor_me", cCuentaComercial.cuenta_contable_proveedor_me)
                .AddWithValue("vCuenta_bancaria_mn", cCuentaComercial.cuenta_bancaria_mn)
                .AddWithValue("vCuenta_bancaria_me", cCuentaComercial.cuenta_bancaria_me)
                .AddWithValue("vBanco_pago_mn", cCuentaComercial.banco_pago_mn)
                .AddWithValue("vBanco_pago_me", cCuentaComercial.banco_pago_me)
                .AddWithValue("vVigente_sunat", cCuentaComercial.vigente_sunat)
                .AddWithValue("vAfecto_igv", cCuentaComercial.afecto_igv)
                .AddWithValue("vAgente_retencion", cCuentaComercial.agente_retencion)
                .AddWithValue("vAgente_detraccion", cCuentaComercial.agente_detraccion)
                .AddWithValue("vAgente_percepcion", cCuentaComercial.agente_percepcion)
                .AddWithValue("vIndica_cliente", cCuentaComercial.indica_cliente)
                .AddWithValue("vIndica_proveedor", cCuentaComercial.indica_proveedor)
                .AddWithValue("vComentario", cCuentaComercial.comentario)
                .AddWithValue("vEstado", cCuentaComercial.estado)
                .AddWithValue("vItem_flujo", cCuentaComercial.item_flujo)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
                .AddWithValue("vCodigo_antiguo", cCuentaComercial.codigo_antiguo)
                .AddWithValue("vFecha_alta_sunat", cCuentaComercial.fecha_alta_sunat)
                .AddWithValue("vFecha_nacimiento", cCuentaComercial.fecha_nacimiento)
                .AddWithValue("vVigencia_credito", cCuentaComercial.vigencia_credito)
                .AddWithValue("vPorcentaje_descuento_1", cCuentaComercial.porcentaje_descuento_1)
                .AddWithValue("vPorcentaje_descuento_2", cCuentaComercial.porcentaje_descuento_2)
                .AddWithValue("vPorcentaje_descuento_3", cCuentaComercial.porcentaje_descuento_3)
                .AddWithValue("vCuenta_detraccion", cCuentaComercial.cuenta_detraccion)
                .AddWithValue("vPorcentaje_detraccion", cCuentaComercial.porcentaje_detraccion)
                .AddWithValue("vExige_orden_compra", cCuentaComercial.exige_orden_compra)
                .AddWithValue("vTipo_orden_compra", cCuentaComercial.tipo_orden_compra)
                .AddWithValue("vExige_orden_pago", cCuentaComercial.exige_orden_pago)
                .AddWithValue("vTipo_orden_pago", cCuentaComercial.tipo_orden_pago)

                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vCodigo_vendedor", cCuentaComercial.codigo_vendedor)
                .AddWithValue("vApellido_paterno", cCuentaComercial.apellido_paterno)
                .AddWithValue("vApellido_materno", cCuentaComercial.apellido_materno)
                .AddWithValue("vNombres", cCuentaComercial.nombres)
                .AddWithValue("vSexo", cCuentaComercial.sexo)

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

                Return cCuentaComercial

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

    Private Shared Function AsignarCodigo() As String

        MySql = "SELECT ISNULL(MAX(CUENTA_COMERCIAL),'') AS NUEVO_CODIGO FROM COM.CUENTAS_COMERCIALES "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "CC000001"
            Else
                Correlativo = CLng(NewCode.Substring(2, 6)) + 1
                NewCode = "CC" & Right("000000" & Correlativo.ToString, 6)
            End If
            Return NewCode

        End Using

    End Function

    Private Shared Function Actualizar(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial

        MySql = "UPDATE COM.CUENTAS_COMERCIALES SET " & _
        "tipo_documento=@vTipo_documento,nro_documento=@vNro_documento,razon_social=@vRazon_social,siglas=@vSiglas," & _
        "via_tipo=@vVia_tipo,via_nombre=@vVia_nombre,via_numero=@vVia_numero,via_interior=@vVia_interior,zona_tipo=@vZona_tipo,zona_nombre=@vZona_nombre," & _
        "referencia=@vReferencia,pais=@vPais,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo,indica_no_domiciliado=@vIndica_no_domiciliado," & _
        "domicilio_envio=@vDomicilio_envio,codigo_postal=@vCodigo_postal,telefono=@vTelefono,celular=@vCelular,fax=@vFax,email=@vEmail,pagina_web=@vPagina_web," & _
        "tipo_moneda=@vTipo_moneda,contacto_comercial=@vContacto_comercial,condicion_pago=@vCondicion_pago,tipo_pago=@vTipo_pago," & _
        "tipo_documento_pago=@vTipo_documento_pago,linea_credito_mn=@vLinea_credito_mn,linea_credito_me=@vLinea_credito_me," & _
        "credito_disponible_mn=@vCredito_disponible_mn,credito_disponible_me=@vCredito_disponible_me,vigencia_credito=@vVigencia_credito," & _
        "lista_precios=@vLista_precios,porcentaje_descuento_1=@vPorcentaje_descuento_1,porcentaje_descuento_2=@vPorcentaje_descuento_2," & _
        "porcentaje_descuento_3=@vPorcentaje_descuento_3,cuenta_contable_cliente_mn=@vCuenta_contable_cliente_mn," & _
        "cuenta_contable_cliente_me=@vCuenta_contable_cliente_me,cuenta_contable_proveedor_mn=@vCuenta_contable_proveedor_mn," & _
        "cuenta_contable_proveedor_me=@vCuenta_contable_proveedor_me,cuenta_bancaria_mn=@vCuenta_bancaria_mn,cuenta_bancaria_me=@vCuenta_bancaria_me," & _
        "banco_pago_mn=@vBanco_pago_mn,banco_pago_me=@vBanco_pago_me,vigente_sunat=@vVigente_sunat,fecha_alta_sunat=@vFecha_alta_sunat,afecto_igv=@vAfecto_igv," & _
        "Agente_retencion=@vAgente_retencion,agente_detraccion=@vAgente_detraccion,agente_percepcion=@vAgente_percepcion,indica_cliente=@vIndica_cliente," & _
        "indica_proveedor=@vIndica_proveedor,codigo_vendedor=@vCodigo_vendedor,codigo_comprador=@vCodigo_comprador," & _
        "ultima_compra=@vUltima_compra,ultima_venta=@vUltima_venta,apellido_paterno=@vApellido_paterno,apellido_materno=@vApellido_materno,nombres=@vNombres," & _
        "fecha_nacimiento=@vFecha_nacimiento,calificacion=@vCalificacion,zona_comercial=@vZona_comercial,comentario=@vComentario," & _
        "usuario_web=@vUsuario_web,clave_web=@vClave_web,estado=@vEstado,item_flujo=@vItem_flujo,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica,codigo_antiguo=@vCodigo_antiguo," & _
        "cuenta_detraccion=@vCuenta_detraccion,porcentaje_detraccion=@vPorcentaje_detraccion," & _
        "exige_orden_compra=@vExige_orden_compra,tipo_orden_compra=@vTipo_orden_compra,exige_orden_pago=@vExige_orden_pago,tipo_orden_pago=@vTipo_orden_pago," & _
        "domicilio=@vDomicilio,sexo=@vSexo " & _
        "WHERE empresa=@vEmpresa AND cuenta_comercial=@vCuenta_comercial "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vTipo_documento", cCuentaComercial.tipo_documento)
                .AddWithValue("vNro_documento", cCuentaComercial.nro_documento)
                .AddWithValue("vRazon_social", cCuentaComercial.razon_social)
                .AddWithValue("vSiglas", cCuentaComercial.siglas)
                .AddWithValue("vVia_tipo", cCuentaComercial.via_tipo)
                .AddWithValue("vVia_nombre", cCuentaComercial.via_nombre)
                .AddWithValue("vVia_numero", cCuentaComercial.via_numero)
                .AddWithValue("vVia_interior", cCuentaComercial.via_interior)
                .AddWithValue("vZona_tipo", cCuentaComercial.zona_tipo)
                .AddWithValue("vZona_nombre", cCuentaComercial.zona_nombre)
                .AddWithValue("vReferencia", cCuentaComercial.referencia)
                .AddWithValue("vPais", cCuentaComercial.pais)
                .AddWithValue("vDepartamento", cCuentaComercial.departamento)
                .AddWithValue("vProvincia", cCuentaComercial.provincia)
                .AddWithValue("vUbigeo", cCuentaComercial.ubigeo)
                .AddWithValue("vIndica_no_domiciliado", cCuentaComercial.indica_no_domiciliado)
                .AddWithValue("vDomicilio_envio", cCuentaComercial.domicilio_envio)
                .AddWithValue("vCodigo_postal", cCuentaComercial.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vFax", cCuentaComercial.fax)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vPagina_web", cCuentaComercial.pagina_web)
                .AddWithValue("vTipo_moneda", cCuentaComercial.tipo_moneda)
                .AddWithValue("vContacto_comercial", cCuentaComercial.contacto_comercial)
                .AddWithValue("vCondicion_pago", cCuentaComercial.condicion_pago)
                .AddWithValue("vTipo_pago", cCuentaComercial.tipo_pago)
                .AddWithValue("vTipo_documento_pago", cCuentaComercial.tipo_documento_pago)
                .AddWithValue("vLinea_credito_mn", cCuentaComercial.linea_credito_mn)
                .AddWithValue("vLinea_credito_me", cCuentaComercial.linea_credito_me)
                .AddWithValue("vCredito_disponible_mn", cCuentaComercial.credito_disponible_mn)
                .AddWithValue("vCredito_disponible_me", cCuentaComercial.credito_disponible_me)
                .AddWithValue("vVigencia_credito", cCuentaComercial.vigencia_credito)
                .AddWithValue("vLista_precios", cCuentaComercial.lista_precios)
                .AddWithValue("vPorcentaje_descuento_1", cCuentaComercial.porcentaje_descuento_1)
                .AddWithValue("vPorcentaje_descuento_2", cCuentaComercial.porcentaje_descuento_2)
                .AddWithValue("vPorcentaje_descuento_3", cCuentaComercial.porcentaje_descuento_3)
                .AddWithValue("vCuenta_contable_cliente_mn", cCuentaComercial.cuenta_contable_cliente_mn)
                .AddWithValue("vCuenta_contable_cliente_me", cCuentaComercial.cuenta_contable_cliente_me)
                .AddWithValue("vCuenta_contable_proveedor_mn", cCuentaComercial.cuenta_contable_proveedor_mn)
                .AddWithValue("vCuenta_contable_proveedor_me", cCuentaComercial.cuenta_contable_proveedor_me)
                .AddWithValue("vCuenta_bancaria_mn", cCuentaComercial.cuenta_bancaria_mn)
                .AddWithValue("vCuenta_bancaria_me", cCuentaComercial.cuenta_bancaria_me)
                .AddWithValue("vBanco_pago_mn", cCuentaComercial.banco_pago_mn)
                .AddWithValue("vBanco_pago_me", cCuentaComercial.banco_pago_me)
                .AddWithValue("vVigente_sunat", cCuentaComercial.vigente_sunat)
                .AddWithValue("vFecha_alta_sunat", IIf(cCuentaComercial.fecha_alta_sunat.Ticks = 0, FechaNulo, cCuentaComercial.fecha_alta_sunat))
                .AddWithValue("vAfecto_igv", cCuentaComercial.afecto_igv)
                .AddWithValue("vAgente_retencion", cCuentaComercial.agente_retencion)
                .AddWithValue("vAgente_detraccion", cCuentaComercial.agente_detraccion)
                .AddWithValue("vAgente_percepcion", cCuentaComercial.agente_percepcion)
                .AddWithValue("vIndica_cliente", cCuentaComercial.indica_cliente)
                .AddWithValue("vIndica_proveedor", cCuentaComercial.indica_proveedor)
                .AddWithValue("vCodigo_vendedor", cCuentaComercial.codigo_vendedor)
                .AddWithValue("vCodigo_comprador", cCuentaComercial.codigo_comprador)
                .AddWithValue("vUltima_compra", cCuentaComercial.ultima_compra)
                .AddWithValue("vUltima_venta", cCuentaComercial.ultima_venta)
                .AddWithValue("vApellido_paterno", cCuentaComercial.apellido_paterno)
                .AddWithValue("vApellido_materno", cCuentaComercial.apellido_materno)
                .AddWithValue("vNombres", cCuentaComercial.nombres)
                .AddWithValue("vFecha_nacimiento", IIf(cCuentaComercial.fecha_nacimiento.Ticks = 0, FechaNulo, cCuentaComercial.fecha_nacimiento))
                .AddWithValue("vCalificacion", cCuentaComercial.calificacion)
                .AddWithValue("vZona_comercial", cCuentaComercial.zona_comercial)
                .AddWithValue("vComentario", cCuentaComercial.comentario)
                .AddWithValue("vUsuario_web", cCuentaComercial.usuario_web)
                .AddWithValue("vClave_web", cCuentaComercial.clave_web)
                .AddWithValue("vEstado", cCuentaComercial.estado)
                .AddWithValue("vItem_flujo", cCuentaComercial.item_flujo)
                .AddWithValue("vUsuario_modifica", cCuentaComercial.usuario_registro)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vCodigo_antiguo", cCuentaComercial.codigo_antiguo)
                .AddWithValue("vCuenta_detraccion", cCuentaComercial.cuenta_detraccion)
                .AddWithValue("vPorcentaje_detraccion", cCuentaComercial.porcentaje_detraccion)
                .AddWithValue("vExige_orden_compra", cCuentaComercial.exige_orden_compra)
                .AddWithValue("vTipo_orden_compra", cCuentaComercial.tipo_orden_compra)
                .AddWithValue("vExige_orden_pago", cCuentaComercial.exige_orden_pago)
                .AddWithValue("vTipo_orden_pago", cCuentaComercial.tipo_orden_pago)
                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vSexo", cCuentaComercial.sexo)
                .AddWithValue("vEmpresa", cCuentaComercial.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
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
                Return cCuentaComercial

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

    Public Shared Function Borrar(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaComercial) Then
            Resp = MsgBox("Confirmar proceso de eliminación.", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                Call Eliminar(pEmpresa, pCuentaComercial)
                Return True
            End If
        End If
    End Function

    Private Shared Function Eliminar(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As Boolean
        MySqlString = "DELETE FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCuentaComercial)
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

    Public Shared Function BuscarCuentaComercialNombre(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pTipoCuenta As String) As dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable
        If pTipoCuenta = "T" Then
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND C.RAZON_SOCIAL LIKE '%'+@vRazon_Social+'%' " & _
                          "ORDER BY C.RAZON_SOCIAL "
        ElseIf pTipoCuenta = "C" Then
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND INDICA_CLIENTE='SI' AND C.RAZON_SOCIAL LIKE '%'+@vRazon_Social+'%' " & _
                          "ORDER BY C.RAZON_SOCIAL "
        Else
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND INDICA_PROVEEDOR='SI' AND C.RAZON_SOCIAL LIKE '%'+@vRazon_Social+'%' " & _
                          "ORDER BY C.RAZON_SOCIAL "
        End If

        Dim MyDT As New dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vRazon_Social", pDescripcion)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function BuscarCuentaComercialCodigo(ByVal pEmpresa As String, ByVal pCodigo As String, ByVal pTipoCuenta As String) As dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable
        If pTipoCuenta = "T" Then
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND C.NRO_DOCUMENTO LIKE @vNro_Documento+'%' " & _
                          "ORDER BY C.NRO_DOCUMENTO "
        ElseIf pTipoCuenta = "C" Then
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND INDICA_CLIENTE='SI' AND C.NRO_DOCUMENTO LIKE @vNro_Documento+'%' " & _
                          "ORDER BY C.NRO_DOCUMENTO "
        Else
            MySqlString = "SELECT C.NRO_DOCUMENTO, C.RAZON_SOCIAL, CASE WHEN C.ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO, " & _
                          "T.DESCRIPCION AS TIPO_DOCUMENTO, C.CUENTA_COMERCIAL, C.CODIGO_VENDEDOR " & _
                          "FROM COM.CUENTAS_COMERCIALES AS C INNER JOIN GEN.TABLA_DOCUMENTO_IDENTIDAD AS T ON C.TIPO_DOCUMENTO=T.CODIGO " & _
                          "WHERE C.EMPRESA=@vEmpresa AND INDICA_PROVEEDOR='SI' AND C.NRO_DOCUMENTO LIKE @vNro_Documento+'%' " & _
                          "ORDER BY C.NRO_DOCUMENTO "
        End If

        Dim MyDT As New dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vNro_Documento", pCodigo)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function BuscarCuentaComercial(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pTipoCuenta As String) As dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable
        Dim MyStoreProcedure As String = IIf(pTipoCuenta = "T", "COM.CUENTAS_COMERCIALES_LISTA", IIf(pTipoCuenta = "C", "COM.CLIENTES_LISTA", "COM.PROVEEDORES_LISTA"))
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 200) : MyParameter_2.Value = pDescripcion

        Dim MyDT As New dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarDomicilioDespacho(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As dsDomicilioDespacho.DOMICILIO_DESPACHODataTable
        Dim MyStoreProcedure As String = "COM.DOMICILIO_DESPACHO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.Char, 8) : MyParameter_2.Value = pCuentaComercial

        Dim MyDT As New dsDomicilioDespacho.DOMICILIO_DESPACHODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarDomicilioFiscal(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As dsDomicilioFiscal.DOMICILIO_FISCALDataTable
        Dim MyStoreProcedure As String = "COM.DOMICILIO_FISCAL_CLIENTE"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.Char, 8) : MyParameter_2.Value = pCuentaComercial

        Dim MyDT As New dsDomicilioFiscal.DOMICILIO_FISCALDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function GrabarDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio) As entCuentaComercialDomicilio
        With cCuentaComercialDomicilio
            If String.IsNullOrEmpty(.via_nombre) Then Throw New BusinessException(MSG000 & " VIA NOMBRE")
            If String.IsNullOrEmpty(.descripcion) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
        End With

        If Not ExisteDomicilio(cCuentaComercialDomicilio) Then
            Return InsertarDomicilio(cCuentaComercialDomicilio, myConnectionStringSQL_Repository)
        Else
            Return ActualizarDomicilio(cCuentaComercialDomicilio)
        End If
    End Function

    Private Shared Function ExisteDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio) As Boolean
        With cCuentaComercialDomicilio
            If Not String.IsNullOrEmpty(.cuenta_comercial) Then
                MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES_DOM " & _
                              "WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial AND Domicilio_Envio=@vDomicilioEnvio "
                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                    Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                    MySQLCommand.Parameters.AddWithValue("vEmpresa", .empresa)
                    MySQLCommand.Parameters.AddWithValue("vCuentaComercial", .cuenta_comercial)
                    MySQLCommand.Parameters.AddWithValue("vDomicilioEnvio", .domicilio_envio)
                    MySQLDbconnection.Open()
                    Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                    Return IIf(MyCount = 0, False, True)
                End Using
            End If
        End With
    End Function

    Private Shared Function InsertarDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio, ByVal MyConnectionString As String) As entCuentaComercialDomicilio
        cCuentaComercialDomicilio.domicilio_envio = AsignarDomicilio()
        MySql = "INSERT INTO COM.CUENTAS_COMERCIALES_DOM " & _
                "(empresa,cuenta_comercial,domicilio_envio,descripcion,via_tipo,via_nombre,via_numero,via_interior,zona_tipo,zona_nombre," & _
                "referencia,pais,departamento,provincia,ubigeo,codigo_postal,telefono,celular,fax,email,estado,usuario_registro) " & _
                "VALUES (@vEmpresa,@vCuenta_comercial,@vDomicilio_envio,@vDescripcion,@vVia_tipo,@vVia_nombre,@vVia_numero," & _
                "@vVia_interior,@vZona_tipo,@vZona_nombre,@vReferencia,@vPais,@vDepartamento,@vProvincia," & _
                "@vUbigeo,@vCodigo_postal,@vTelefono,@vCelular,@vFax,@vEmail,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCuentaComercialDomicilio.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercialDomicilio.cuenta_comercial)
                .AddWithValue("vDomicilio_envio", cCuentaComercialDomicilio.domicilio_envio)
                .AddWithValue("vDescripcion", cCuentaComercialDomicilio.descripcion)
                .AddWithValue("vVia_tipo", cCuentaComercialDomicilio.via_tipo)
                .AddWithValue("vVia_nombre", cCuentaComercialDomicilio.via_nombre)
                .AddWithValue("vVia_numero", cCuentaComercialDomicilio.via_numero)
                .AddWithValue("vVia_interior", cCuentaComercialDomicilio.via_interior)
                .AddWithValue("vZona_tipo", cCuentaComercialDomicilio.zona_tipo)
                .AddWithValue("vZona_nombre", cCuentaComercialDomicilio.zona_nombre)
                .AddWithValue("vReferencia", cCuentaComercialDomicilio.referencia)
                .AddWithValue("vPais", cCuentaComercialDomicilio.pais)
                .AddWithValue("vDepartamento", cCuentaComercialDomicilio.departamento)
                .AddWithValue("vProvincia", cCuentaComercialDomicilio.provincia)
                .AddWithValue("vUbigeo", cCuentaComercialDomicilio.ubigeo)
                .AddWithValue("vCodigo_postal", cCuentaComercialDomicilio.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercialDomicilio.telefono)
                .AddWithValue("vCelular", cCuentaComercialDomicilio.celular)
                .AddWithValue("vFax", cCuentaComercialDomicilio.fax)
                .AddWithValue("vEmail", cCuentaComercialDomicilio.email)
                .AddWithValue("vEstado", cCuentaComercialDomicilio.estado)
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

                Return cCuentaComercialDomicilio

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

    Private Shared Function AsignarDomicilio() As String

        MySql = "SELECT ISNULL(MAX(DOMICILIO_ENVIO),'') AS NUEVO_DOMICILIO FROM COM.CUENTAS_COMERCIALES_DOM "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "01"
            Else
                Correlativo = CLng(NewCode) + 1
                NewCode = Strings.Right("00" & Correlativo.ToString, 2)
            End If
            Return NewCode

        End Using

    End Function

    Private Shared Function ActualizarDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio) As entCuentaComercialDomicilio

        MySql = "UPDATE COM.CUENTAS_COMERCIALES_DOM SET " & _
        "descripcion=@vDescripcion,via_tipo=@vVia_tipo,via_nombre=@vVia_nombre,via_numero=@vVia_numero,via_interior=@vVia_interior,zona_tipo=@vZona_tipo,zona_nombre=@vZona_nombre," & _
        "referencia=@vReferencia,pais=@vPais,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo," & _
        "codigo_postal=@vCodigo_postal,telefono=@vTelefono,celular=@vCelular,fax=@vFax,email=@vEmail,estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
        "WHERE empresa=@vEmpresa AND cuenta_comercial=@vCuenta_comercial AND domicilio_envio=@vDomicilio_envio "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vDescripcion", cCuentaComercialDomicilio.descripcion)
                .AddWithValue("vVia_tipo", cCuentaComercialDomicilio.via_tipo)
                .AddWithValue("vVia_nombre", cCuentaComercialDomicilio.via_nombre)
                .AddWithValue("vVia_numero", cCuentaComercialDomicilio.via_numero)
                .AddWithValue("vVia_interior", cCuentaComercialDomicilio.via_interior)
                .AddWithValue("vZona_tipo", cCuentaComercialDomicilio.zona_tipo)
                .AddWithValue("vZona_nombre", cCuentaComercialDomicilio.zona_nombre)
                .AddWithValue("vReferencia", cCuentaComercialDomicilio.referencia)
                .AddWithValue("vPais", cCuentaComercialDomicilio.pais)
                .AddWithValue("vDepartamento", cCuentaComercialDomicilio.departamento)
                .AddWithValue("vProvincia", cCuentaComercialDomicilio.provincia)
                .AddWithValue("vUbigeo", cCuentaComercialDomicilio.ubigeo)
                .AddWithValue("vCodigo_postal", cCuentaComercialDomicilio.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercialDomicilio.telefono)
                .AddWithValue("vCelular", cCuentaComercialDomicilio.celular)
                .AddWithValue("vFax", cCuentaComercialDomicilio.fax)
                .AddWithValue("vEmail", cCuentaComercialDomicilio.email)
                .AddWithValue("vEstado", cCuentaComercialDomicilio.estado)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cCuentaComercialDomicilio.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercialDomicilio.cuenta_comercial)
                .AddWithValue("vDomicilio_envio", cCuentaComercialDomicilio.domicilio_envio)
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
                Return cCuentaComercialDomicilio

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

    Public Shared Function ObtenerDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio) As entCuentaComercialDomicilio
        If ExisteDomicilio(cCuentaComercialDomicilio) Then
            With cCuentaComercialDomicilio
                CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES_DOM " & _
                            "WHERE EMPRESA='" & .empresa & "' AND CUENTA_COMERCIAL='" & .cuenta_comercial & "' AND DOMICILIO_ENVIO='" & .domicilio_envio & "' "
            End With
            Return ObtenerDomicilio(New entCuentaComercialDomicilio, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCuentaComercialDomicilio
        End If
    End Function

    Private Shared Function ObtenerDomicilio(ByVal cCuentaComercialDomicilio As entCuentaComercialDomicilio, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entCuentaComercialDomicilio
        Dim MyDT As New dsCuentasComercialesDomicilio.CUENTAS_COMERCIALES_DOMDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaComercialDomicilio
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .domicilio_envio = MyDT(0).DOMICILIO_ENVIO
                .descripcion = MyDT(0).DESCRIPCION
                .via_tipo = MyDT(0).VIA_TIPO
                .via_nombre = MyDT(0).VIA_NOMBRE
                .via_numero = MyDT(0).VIA_NUMERO
                .via_interior = MyDT(0).VIA_INTERIOR
                .zona_tipo = MyDT(0).ZONA_TIPO
                .zona_nombre = MyDT(0).ZONA_NOMBRE
                .referencia = MyDT(0).REFERENCIA
                .pais = MyDT(0).PAIS
                .departamento = MyDT(0).DEPARTAMENTO
                .provincia = MyDT(0).PROVINCIA
                .ubigeo = MyDT(0).UBIGEO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .celular = MyDT(0).CELULAR
                .fax = MyDT(0).FAX
                .email = MyDT(0).EMAIL
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cCuentaComercialDomicilio
    End Function

    Public Shared Function BuscarDomicilioEnvioLista(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As dsDomicilioEnvioLista.DOMICILIO_ENVIO_LISTADataTable
        Dim MyStoreProcedure As String = "COM.DOMICILIO_ENVIO_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.Char, 8) : MyParameter_2.Value = pCuentaComercial

        Dim MyDT As New dsDomicilioEnvioLista.DOMICILIO_ENVIO_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Private Shared Function ExisteVendedor(ByVal CodigoVendedor As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM GEN.TABLAS_DETALLE WHERE EMPRESA=@vEmpresa AND CODIGO_TABLA = 'STD_VENDEDORES' AND CODIGO_ITEM=@vCodigo_item "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa)
            MySQLCommand.Parameters.AddWithValue("vCodigo_item", CodigoVendedor)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Sub GrabarVendedor(ByVal CodigoVendedor As String, ByVal RazonSocial As String, ByVal DNI As String)
        If ExisteVendedor(CodigoVendedor) Then
            ActualizarVendedor(CodigoVendedor, RazonSocial, DNI)
        Else
            InsertarVendedor(CodigoVendedor, RazonSocial, DNI)
        End If
    End Sub

    Private Shared Function ActualizarVendedor(ByVal CodigoVendedor As String, ByVal RazonSocial As String, ByVal DNI As String) As Boolean

        MySql = "UPDATE GEN.TABLAS_DETALLE SET " & _
                "NOMBRE_CORTO=LEFT(@vRazon_social,50), NOMBRE_LARGO=@vRazon_social,TEXTO_01=@vDni," & _
                "Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE EMPRESA=@vEmpresa AND CODIGO_TABLA='STD_VENDEDORES' AND CODIGO_ITEM=@vCodigo_item "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vRazon_social", RazonSocial)
                .AddWithValue("vDni", DNI)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vCodigo_item", CodigoVendedor)
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

                ' Actualizar en Tablas Genericas de memoria
                    ModificarFilaListaEmpresa("STD_VENDEDORES", CodigoVendedor, RazonSocial)

                Return True

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

    Private Shared Function InsertarVendedor(ByVal CodigoVendedor As String, ByVal RazonSocial As String, ByVal DNI As String) As Boolean

        MySql = "INSERT INTO GEN.TABLAS_DETALLE " & _
                "(empresa,codigo_tabla,codigo_item,nombre_corto,nombre_largo," & _
                "texto_01,texto_02,usuario_registro) " & _
                "VALUES (@vEmpresa,@vCodigo_tabla,@vCodigo_item,LEFT(@vRazon_social,50),@vRazon_social," & _
                "@vDni,@vTipo,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vCodigo_tabla", "STD_VENDEDORES")
                .AddWithValue("vCodigo_item", CodigoVendedor)
                .AddWithValue("vRazon_social", RazonSocial)
                .AddWithValue("vDni", DNI)
                .AddWithValue("vTipo", "CONSULTOR")
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

                ' Insertar en Tablas Genericas de memoria
                AgregarFilaListaEmpresa("STD_VENDEDORES", CodigoVendedor, RazonSocial)

                Return True

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

    Public Shared Sub ActualizarVendedor(ByVal CuentaComercial As String, ByVal CodigoVendedor As String)
        MySql = "UPDATE COM.CUENTAS_COMERCIALES SET " & _
                "CODIGO_VENDEDOR=@vCodigo_vendedor,Usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
                "WHERE EMPRESA=@vEmpresa AND CUENTA_COMERCIAL=@vCuenta_comercial "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vCodigo_vendedor", CodigoVendedor)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", MyUsuario.empresa)
                .AddWithValue("vCuenta_comercial", CuentaComercial)
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
                'Try to rollback the transaction
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
