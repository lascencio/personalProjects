Imports System.Data.SqlClient

Public Class dalCuentaComercial
    Private Shared MyCuentaComercial As entCuentaComercial

    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyCount As Integer

    Public Shared Function Grabar(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial
        Dim LongTD As Integer

        With cCuentaComercial
            If .cuenta_comercial.Trim.Length <> 0 Then
                If Existe(.empresa, .tipo_documento, .nro_documento, .cuenta_comercial) Then Throw New BusinessException("El Tipo y Numero de Documento estan asignados a otra Cuenta Comercial")
            Else
                LongTD = .nro_documento.Trim.Length
                If .tipo_documento = "6" And LongTD <> 11 Then Throw New BusinessException("El RUC debe ser de 11 dígitos")
                If .tipo_documento = "1" And LongTD <> 8 Then Throw New BusinessException("El DNI debe ser de 8 dígitos")
            End If

        End With

        cCuentaComercial.agencia_registro = "A0000" & MyUsuario.almacen
        cCuentaComercial.agencia_modifica = "A0000" & MyUsuario.almacen

        If Not Existe(cCuentaComercial) Then
            MyCuentaComercial = Insertar(cCuentaComercial)
        Else
            MyCuentaComercial = Actualizar(cCuentaComercial)
        End If
        Return MyCuentaComercial
    End Function

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String, ByVal pCuentaComercial As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES " &
                      "WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipoDocumento AND Nro_Documento=@vNumeroDocumento AND Cuenta_Comercial<>@vCuentaComercial "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vTipoDocumento", pTipoDocumento)
            MySQLCommand.Parameters.AddWithValue("vNumeroDocumento", pNumeroDocumento)
            MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCuentaComercial)
            MySQLDbconnection.Open()
            MyCount = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES " &
                      "WHERE Empresa=@vEmpresa AND Tipo_Documento=@vTipoDocumento AND Nro_Documento=@vNumeroDocumento "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vTipoDocumento", pTipoDocumento)
            MySQLCommand.Parameters.AddWithValue("vNumeroDocumento", pNumeroDocumento)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal cCuentaComercial As entCuentaComercial) As Boolean
        If Not String.IsNullOrEmpty(cCuentaComercial.cuenta_comercial) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cCuentaComercial.empresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", cCuentaComercial.cuenta_comercial)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Insertar(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial
        cCuentaComercial.cuenta_comercial = AsignarCodigo(cCuentaComercial.empresa)
        MySqlString = "INSERT INTO COM.CUENTAS_COMERCIALES " &
        "(EMPRESA,CUENTA_COMERCIAL,GRUPO_COMERCIAL,TIPO_CUENTA,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,SIGLAS,VIA_TIPO,VIA_NOMBRE,VIA_NUMERO,VIA_INTERIOR,ZONA_TIPO," &
        "ZONA_NOMBRE,REFERENCIA,PAIS,DEPARTAMENTO,PROVINCIA,UBIGEO,INDICA_NO_DOMICILIADO,DOMICILIO_ENVIO,DOMICILIO,CODIGO_POSTAL,TELEFONO,TELEFONO_OTRO,CELULAR,FAX,EMAIL," &
        "PAGINA_WEB,DIRECCION_TRABAJO,REFERENCIA_TRABAJO,TELEFONO_TRABAJO,TIPO_MONEDA,CONTACTO_COMERCIAL,CONDICION_PAGO,FORMA_PAGO,DOCUMENTO_PAGO,LINEA_CREDITO_MN," &
        "LINEA_CREDITO_ME,SALDO_PAGAR_MN,SALDO_PAGAR_ME,VIGENCIA_CREDITO,LISTA_PRECIOS,PORCENTAJE_DESCUENTO_1,PORCENTAJE_DESCUENTO_2,PORCENTAJE_DESCUENTO_3," &
        "CUENTA_CONTABLE_CLIENTE_MN,CUENTA_CONTABLE_CLIENTE_ME,CUENTA_CONTABLE_PROVEEDOR_MN,CUENTA_CONTABLE_PROVEEDOR_ME,CUENTA_CONTABLE_INGRESO,CUENTA_CONTABLE_GASTO," &
        "CUENTA_BANCARIA_MN,CUENTA_BANCARIA_ME,BANCO_PAGO_MN,BANCO_PAGO_ME,TIPO_CONTABLE,VIGENTE_SUNAT,FECHA_ALTA_SUNAT,AFECTO_IGV,AGENTE_RETENCION,AGENTE_DETRACCION," &
        "AGENTE_PERCEPCION,PORCENTAJE_DETRACCION,CUENTA_DETRACCION,INDICA_CLIENTE,INDICA_PROVEEDOR,CODIGO_VENDEDOR,CODIGO_COMPRADOR,ULTIMA_COMPRA,ULTIMA_VENTA," &
        "APELLIDO_PATERNO,APELLIDO_MATERNO,APELLIDO_CASADA,NOMBRES,FECHA_NACIMIENTO,SEXO,ESTADO_CIVIL,NIVEL_EDUCATIVO,OCUPACION,SITUACION_CREDITICIA,CALIFICACION," &
        "INDICA_PREFERENTE,INDICA_FALLECIDO,EXIGE_GARANTE,ZONA_COMERCIAL,COMENTARIO,USUARIO_WEB,CLAVE_WEB,CODIGO_ANTIGUO,ITEM_FLUJO,EXIGE_ORDEN_COMPRA,TIPO_ORDEN_COMPRA," &
        "EXIGE_ORDEN_PAGO,TIPO_ORDEN_PAGO,ESTADO,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
        "VALUES " &
        "(@vEmpresa,@vCuenta_comercial,@vGrupo_comercial,@vTipo_cuenta,@vTipo_documento,@vNro_documento,@vRazon_social,@vSiglas,@vVia_tipo,@vVia_nombre,@vVia_numero,@vVia_interior,@vZona_tipo," &
        "@vZona_nombre,@vReferencia,@vPais,@vDepartamento,@vProvincia,@vUbigeo,@vIndica_no_domiciliado,@vDomicilio_envio,@vDomicilio,@vCodigo_postal,@vTelefono,@vTelefono_otro,@vCelular,@vFax,@vEmail," &
        "@vPagina_web,@vDireccion_trabajo,@vReferencia_trabajo,@vTelefono_trabajo,@vTipo_moneda,@vContacto_comercial,@vCondicion_pago,@vForma_pago,@vDocumento_pago,@vLinea_credito_mn," &
        "@vLinea_credito_me,@vSaldo_pagar_mn,@vSaldo_pagar_me,@vVigencia_credito,@vLista_precios,@vPorcentaje_descuento_1,@vPorcentaje_descuento_2,@vPorcentaje_descuento_3," &
        "@vCuenta_contable_cliente_mn,@vCuenta_contable_cliente_me,@vCuenta_contable_proveedor_mn,@vCuenta_contable_proveedor_me,@vCuenta_contable_ingreso,@vCuenta_contable_gasto," &
        "@vCuenta_bancaria_mn,@vCuenta_bancaria_me,@vBanco_pago_mn,@vBanco_pago_me,@vTipo_contable,@vVigente_sunat,@vFecha_alta_sunat,@vAfecto_igv,@vAgente_retencion,@vAgente_detraccion," &
        "@vAgente_percepcion,@vPorcentaje_detraccion,@vCuenta_detraccion,@vIndica_cliente,@vIndica_proveedor,@vCodigo_vendedor,@vCodigo_comprador,@vUltima_compra,@vUltima_venta," &
        "@vApellido_paterno,@vApellido_materno,@vApellido_casada,@vNombres,@vFecha_nacimiento,@vSexo,@vEstado_civil,@vNivel_educativo,@vOcupacion,@vSituacion_crediticia,@vCalificacion," &
        "@vIndica_preferente,@vIndica_fallecido,@vExige_garante,@vZona_comercial,@vComentario,@vUsuario_web,@vClave_web,@vCodigo_antiguo,@vItem_flujo,@vExige_orden_compra,@vTipo_orden_compra," &
        "@vExige_orden_pago,@vTipo_orden_pago,@vEstado,@vAgencia_registro,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCuentaComercial.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
                .AddWithValue("vGrupo_comercial", cCuentaComercial.grupo_comercial)
                .AddWithValue("vTipo_cuenta", cCuentaComercial.tipo_cuenta)
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
                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vCodigo_postal", cCuentaComercial.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vTelefono_otro", cCuentaComercial.telefono_otro)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vFax", cCuentaComercial.fax)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vPagina_web", cCuentaComercial.pagina_web)
                .AddWithValue("vDireccion_trabajo", cCuentaComercial.direccion_trabajo)
                .AddWithValue("vReferencia_trabajo", cCuentaComercial.referencia_trabajo)
                .AddWithValue("vTelefono_trabajo", cCuentaComercial.telefono_trabajo)
                .AddWithValue("vTipo_moneda", cCuentaComercial.tipo_moneda)
                .AddWithValue("vContacto_comercial", cCuentaComercial.contacto_comercial)
                .AddWithValue("vCondicion_pago", cCuentaComercial.condicion_pago)
                .AddWithValue("vForma_pago", cCuentaComercial.forma_pago)
                .AddWithValue("vDocumento_pago", cCuentaComercial.documento_pago)
                .AddWithValue("vLinea_credito_mn", cCuentaComercial.linea_credito_mn)
                .AddWithValue("vLinea_credito_me", cCuentaComercial.linea_credito_me)
                .AddWithValue("vSaldo_pagar_mn", cCuentaComercial.saldo_pagar_mn)
                .AddWithValue("vSaldo_pagar_me", cCuentaComercial.saldo_pagar_me)
                .AddWithValue("vVigencia_credito", cCuentaComercial.vigencia_credito)
                .AddWithValue("vLista_precios", cCuentaComercial.lista_precios)
                .AddWithValue("vPorcentaje_descuento_1", cCuentaComercial.porcentaje_descuento_1)
                .AddWithValue("vPorcentaje_descuento_2", cCuentaComercial.porcentaje_descuento_2)
                .AddWithValue("vPorcentaje_descuento_3", cCuentaComercial.porcentaje_descuento_3)
                .AddWithValue("vCuenta_contable_cliente_mn", cCuentaComercial.cuenta_contable_cliente_mn)
                .AddWithValue("vCuenta_contable_cliente_me", cCuentaComercial.cuenta_contable_cliente_me)
                .AddWithValue("vCuenta_contable_proveedor_mn", cCuentaComercial.cuenta_contable_proveedor_mn)
                .AddWithValue("vCuenta_contable_proveedor_me", cCuentaComercial.cuenta_contable_proveedor_me)
                .AddWithValue("vCuenta_contable_ingreso", cCuentaComercial.cuenta_contable_ingreso)
                .AddWithValue("vCuenta_contable_gasto", cCuentaComercial.cuenta_contable_gasto)
                .AddWithValue("vCuenta_bancaria_mn", cCuentaComercial.cuenta_bancaria_mn)
                .AddWithValue("vCuenta_bancaria_me", cCuentaComercial.cuenta_bancaria_me)
                .AddWithValue("vBanco_pago_mn", cCuentaComercial.banco_pago_mn)
                .AddWithValue("vBanco_pago_me", cCuentaComercial.banco_pago_me)
                .AddWithValue("vTipo_contable", cCuentaComercial.tipo_contable)
                .AddWithValue("vVigente_sunat", cCuentaComercial.vigente_sunat)
                .AddWithValue("vFecha_alta_sunat", cCuentaComercial.fecha_alta_sunat)
                .AddWithValue("vAfecto_igv", cCuentaComercial.afecto_igv)
                .AddWithValue("vAgente_retencion", cCuentaComercial.agente_retencion)
                .AddWithValue("vAgente_detraccion", cCuentaComercial.agente_detraccion)
                .AddWithValue("vAgente_percepcion", cCuentaComercial.agente_percepcion)
                .AddWithValue("vPorcentaje_detraccion", cCuentaComercial.porcentaje_detraccion)
                .AddWithValue("vCuenta_detraccion", cCuentaComercial.cuenta_detraccion)
                .AddWithValue("vIndica_cliente", cCuentaComercial.indica_cliente)
                .AddWithValue("vIndica_proveedor", cCuentaComercial.indica_proveedor)
                .AddWithValue("vCodigo_vendedor", cCuentaComercial.codigo_vendedor)
                .AddWithValue("vCodigo_comprador", cCuentaComercial.codigo_comprador)
                .AddWithValue("vUltima_compra", cCuentaComercial.ultima_compra)
                .AddWithValue("vUltima_venta", cCuentaComercial.ultima_venta)
                .AddWithValue("vApellido_paterno", cCuentaComercial.apellido_paterno)
                .AddWithValue("vApellido_materno", cCuentaComercial.apellido_materno)
                .AddWithValue("vApellido_casada", cCuentaComercial.apellido_casada)
                .AddWithValue("vNombres", cCuentaComercial.nombres)
                .AddWithValue("vFecha_nacimiento", cCuentaComercial.fecha_nacimiento)
                .AddWithValue("vSexo", cCuentaComercial.sexo)
                .AddWithValue("vEstado_civil", cCuentaComercial.estado_civil)
                .AddWithValue("vNivel_educativo", cCuentaComercial.nivel_educativo)
                .AddWithValue("vOcupacion", cCuentaComercial.ocupacion)
                .AddWithValue("vSituacion_crediticia", cCuentaComercial.situacion_crediticia)
                .AddWithValue("vCalificacion", cCuentaComercial.calificacion)
                .AddWithValue("vIndica_preferente", cCuentaComercial.indica_preferente)
                .AddWithValue("vIndica_fallecido", cCuentaComercial.indica_fallecido)
                .AddWithValue("vExige_garante", cCuentaComercial.exige_garante)
                .AddWithValue("vZona_comercial", cCuentaComercial.zona_comercial)
                .AddWithValue("vComentario", cCuentaComercial.comentario)
                .AddWithValue("vUsuario_web", cCuentaComercial.usuario_web)
                .AddWithValue("vClave_web", cCuentaComercial.clave_web)
                .AddWithValue("vCodigo_antiguo", cCuentaComercial.codigo_antiguo)
                .AddWithValue("vItem_flujo", cCuentaComercial.item_flujo)
                .AddWithValue("vExige_orden_compra", cCuentaComercial.exige_orden_compra)
                .AddWithValue("vTipo_orden_compra", cCuentaComercial.tipo_orden_compra)
                .AddWithValue("vExige_orden_pago", cCuentaComercial.exige_orden_pago)
                .AddWithValue("vTipo_orden_pago", cCuentaComercial.tipo_orden_pago)
                .AddWithValue("vEstado", cCuentaComercial.estado)
                .AddWithValue("vAgencia_registro", cCuentaComercial.agencia_registro)
                .AddWithValue("vUsuario_registro", cCuentaComercial.usuario_registro)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()

                Return cCuentaComercial
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function AsignarCodigo(pEmpresa As String) As String
        Dim Correlativo As Long
        MySqlString = "SELECT ISNULL(MAX(CUENTA_COMERCIAL),'') AS NUEVO_CODIGO FROM COM.CUENTAS_COMERCIALES WHERE EMPRESA='" & pEmpresa & "' "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "G0000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 7)) + 1
                NewCode = "G" & Right("0000000" & Correlativo.ToString, 7)
            End If
            Return NewCode
        End Using
    End Function

    Private Shared Function Actualizar(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial

        MySqlString = "UPDATE COM.CUENTAS_COMERCIALES SET " &
        "grupo_comercial=@vGrupo_comercial,Tipo_cuenta=@vTipo_cuenta,tipo_documento=@vTipo_documento,nro_documento=@vNro_documento,razon_social=@vRazon_social,siglas=@vSiglas," &
        "via_tipo=@vVia_tipo,via_nombre=@vVia_nombre,via_numero=@vVia_numero,via_interior=@vVia_interior,zona_tipo=@vZona_tipo,zona_nombre=@vZona_nombre,referencia=@vReferencia," &
        "pais=@vPais,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo,indica_no_domiciliado=@vIndica_no_domiciliado,domicilio_envio=@vDomicilio_envio," &
        "domicilio=@vDomicilio,codigo_postal=@vCodigo_postal,telefono=@vTelefono,telefono_otro=@vTelefono_otro,celular=@vCelular,fax=@vFax,email=@vEmail,pagina_web=@vPagina_web," &
        "direccion_trabajo=@vDireccion_trabajo,referencia_trabajo=@vReferencia_trabajo,telefono_trabajo=@vTelefono_trabajo,tipo_moneda=@vTipo_moneda,contacto_comercial=@vContacto_comercial," &
        "condicion_pago=@vCondicion_pago,Forma_pago=@vForma_pago,documento_pago=@vDocumento_pago,linea_credito_mn=@vLinea_credito_mn,linea_credito_me=@vLinea_credito_me," &
        "saldo_pagar_mn=@vSaldo_pagar_mn,saldo_pagar_me=@vSaldo_pagar_me,vigencia_credito=@vVigencia_credito,lista_precios=@vLista_precios,porcentaje_descuento_1=@vPorcentaje_descuento_1," &
        "porcentaje_descuento_2=@vPorcentaje_descuento_2,porcentaje_descuento_3=@vPorcentaje_descuento_3,cuenta_contable_cliente_mn=@vCuenta_contable_cliente_mn," &
        "cuenta_contable_cliente_me=@vCuenta_contable_cliente_me,cuenta_contable_proveedor_mn=@vCuenta_contable_proveedor_mn,cuenta_contable_proveedor_me=@vCuenta_contable_proveedor_me," &
        "cuenta_contable_ingreso=@vCuenta_contable_ingreso,cuenta_contable_gasto=@vCuenta_contable_gasto,cuenta_bancaria_mn=@vCuenta_bancaria_mn,cuenta_bancaria_me=@vCuenta_bancaria_me," &
        "banco_pago_mn=@vBanco_pago_mn,banco_pago_me=@vBanco_pago_me,tipo_contable=@vTipo_contable,vigente_sunat=@vVigente_sunat,fecha_alta_sunat=@vFecha_alta_sunat," &
        "afecto_igv=@vAfecto_igv,Agente_retencion=@vAgente_retencion,agente_detraccion=@vAgente_detraccion,agente_percepcion=@vAgente_percepcion,porcentaje_detraccion=@vPorcentaje_detraccion," &
        "cuenta_detraccion=@vCuenta_detraccion,indica_cliente=@vIndica_cliente,indica_proveedor=@vIndica_proveedor,codigo_vendedor=@vCodigo_vendedor,codigo_comprador=@vCodigo_comprador," &
        "ultima_compra=@vUltima_compra,ultima_venta=@vUltima_venta,apellido_paterno=@vApellido_paterno,apellido_materno=@vApellido_materno,apellido_casada=@vApellido_casada,nombres=@vNombres," &
        "fecha_nacimiento=@vFecha_nacimiento,sexo=@vSexo,estado_civil=@vEstado_civil,nivel_educativo=@vNivel_educativo,ocupacion=@vOcupacion,situacion_crediticia=@vSituacion_crediticia," &
        "calificacion=@vCalificacion,indica_preferente=@vIndica_preferente,indica_fallecido=@vIndica_fallecido,exige_garante=@vExige_garante,zona_comercial=@vZona_comercial," &
        "comentario=@vComentario,usuario_web=@vUsuario_web,clave_web=@vClave_web,codigo_antiguo=@vCodigo_antiguo,item_flujo=@vItem_flujo,exige_orden_compra=@vExige_orden_compra," &
        "tipo_orden_compra=@vTipo_orden_compra,exige_orden_pago=@vExige_orden_pago,tipo_orden_pago=@vTipo_orden_pago,estado=@vEstado,agencia_modifica=@vAgencia_modifica," &
        "usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
        "WHERE empresa=@vEmpresa AND cuenta_comercial=@vCuenta_comercial "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vGrupo_comercial", cCuentaComercial.grupo_comercial)
                .AddWithValue("vTipo_cuenta", cCuentaComercial.tipo_cuenta)
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
                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vCodigo_postal", cCuentaComercial.codigo_postal)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vTelefono_otro", cCuentaComercial.telefono_otro)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vFax", cCuentaComercial.fax)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vPagina_web", cCuentaComercial.pagina_web)
                .AddWithValue("vDireccion_trabajo", cCuentaComercial.direccion_trabajo)
                .AddWithValue("vReferencia_trabajo", cCuentaComercial.referencia_trabajo)
                .AddWithValue("vTelefono_trabajo", cCuentaComercial.telefono_trabajo)
                .AddWithValue("vTipo_moneda", cCuentaComercial.tipo_moneda)
                .AddWithValue("vContacto_comercial", cCuentaComercial.contacto_comercial)
                .AddWithValue("vCondicion_pago", cCuentaComercial.condicion_pago)
                .AddWithValue("vForma_pago", cCuentaComercial.forma_pago)
                .AddWithValue("vDocumento_pago", cCuentaComercial.documento_pago)
                .AddWithValue("vLinea_credito_mn", cCuentaComercial.linea_credito_mn)
                .AddWithValue("vLinea_credito_me", cCuentaComercial.linea_credito_me)
                .AddWithValue("vSaldo_pagar_mn", cCuentaComercial.saldo_pagar_mn)
                .AddWithValue("vSaldo_pagar_me", cCuentaComercial.saldo_pagar_me)
                .AddWithValue("vVigencia_credito", cCuentaComercial.vigencia_credito)
                .AddWithValue("vLista_precios", cCuentaComercial.lista_precios)
                .AddWithValue("vPorcentaje_descuento_1", cCuentaComercial.porcentaje_descuento_1)
                .AddWithValue("vPorcentaje_descuento_2", cCuentaComercial.porcentaje_descuento_2)
                .AddWithValue("vPorcentaje_descuento_3", cCuentaComercial.porcentaje_descuento_3)
                .AddWithValue("vCuenta_contable_cliente_mn", cCuentaComercial.cuenta_contable_cliente_mn)
                .AddWithValue("vCuenta_contable_cliente_me", cCuentaComercial.cuenta_contable_cliente_me)
                .AddWithValue("vCuenta_contable_proveedor_mn", cCuentaComercial.cuenta_contable_proveedor_mn)
                .AddWithValue("vCuenta_contable_proveedor_me", cCuentaComercial.cuenta_contable_proveedor_me)
                .AddWithValue("vCuenta_contable_ingreso", cCuentaComercial.cuenta_contable_ingreso)
                .AddWithValue("vCuenta_contable_gasto", cCuentaComercial.cuenta_contable_gasto)
                .AddWithValue("vCuenta_bancaria_mn", cCuentaComercial.cuenta_bancaria_mn)
                .AddWithValue("vCuenta_bancaria_me", cCuentaComercial.cuenta_bancaria_me)
                .AddWithValue("vBanco_pago_mn", cCuentaComercial.banco_pago_mn)
                .AddWithValue("vBanco_pago_me", cCuentaComercial.banco_pago_me)
                .AddWithValue("vTipo_contable", cCuentaComercial.tipo_contable)
                .AddWithValue("vVigente_sunat", cCuentaComercial.vigente_sunat)
                .AddWithValue("vFecha_alta_sunat", cCuentaComercial.fecha_alta_sunat)
                .AddWithValue("vAfecto_igv", cCuentaComercial.afecto_igv)
                .AddWithValue("vAgente_retencion", cCuentaComercial.agente_retencion)
                .AddWithValue("vAgente_detraccion", cCuentaComercial.agente_detraccion)
                .AddWithValue("vAgente_percepcion", cCuentaComercial.agente_percepcion)
                .AddWithValue("vPorcentaje_detraccion", cCuentaComercial.porcentaje_detraccion)
                .AddWithValue("vCuenta_detraccion", cCuentaComercial.cuenta_detraccion)
                .AddWithValue("vIndica_cliente", cCuentaComercial.indica_cliente)
                .AddWithValue("vIndica_proveedor", cCuentaComercial.indica_proveedor)
                .AddWithValue("vCodigo_vendedor", cCuentaComercial.codigo_vendedor)
                .AddWithValue("vCodigo_comprador", cCuentaComercial.codigo_comprador)
                .AddWithValue("vUltima_compra", cCuentaComercial.ultima_compra)
                .AddWithValue("vUltima_venta", cCuentaComercial.ultima_venta)
                .AddWithValue("vApellido_paterno", cCuentaComercial.apellido_paterno)
                .AddWithValue("vApellido_materno", cCuentaComercial.apellido_materno)
                .AddWithValue("vApellido_casada", cCuentaComercial.apellido_casada)
                .AddWithValue("vNombres", cCuentaComercial.nombres)
                .AddWithValue("vFecha_nacimiento", cCuentaComercial.fecha_nacimiento)
                .AddWithValue("vSexo", cCuentaComercial.sexo)
                .AddWithValue("vEstado_civil", cCuentaComercial.estado_civil)
                .AddWithValue("vNivel_educativo", cCuentaComercial.nivel_educativo)
                .AddWithValue("vOcupacion", cCuentaComercial.ocupacion)
                .AddWithValue("vSituacion_crediticia", cCuentaComercial.situacion_crediticia)
                .AddWithValue("vCalificacion", cCuentaComercial.calificacion)
                .AddWithValue("vIndica_preferente", cCuentaComercial.indica_preferente)
                .AddWithValue("vIndica_fallecido", cCuentaComercial.indica_fallecido)
                .AddWithValue("vExige_garante", cCuentaComercial.exige_garante)
                .AddWithValue("vZona_comercial", cCuentaComercial.zona_comercial)
                .AddWithValue("vComentario", cCuentaComercial.comentario)
                .AddWithValue("vUsuario_web", cCuentaComercial.usuario_web)
                .AddWithValue("vClave_web", cCuentaComercial.clave_web)
                .AddWithValue("vCodigo_antiguo", cCuentaComercial.codigo_antiguo)
                .AddWithValue("vItem_flujo", cCuentaComercial.item_flujo)
                .AddWithValue("vExige_orden_compra", cCuentaComercial.exige_orden_compra)
                .AddWithValue("vTipo_orden_compra", cCuentaComercial.tipo_orden_compra)
                .AddWithValue("vExige_orden_pago", cCuentaComercial.exige_orden_pago)
                .AddWithValue("vTipo_orden_pago", cCuentaComercial.tipo_orden_pago)
                .AddWithValue("vEstado", cCuentaComercial.estado)
                .AddWithValue("vAgencia_modifica", cCuentaComercial.agencia_modifica)
                .AddWithValue("vUsuario_modifica", cCuentaComercial.usuario_modifica)
                .AddWithValue("vEmpresa", cCuentaComercial.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
            End With
            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()
                Return cCuentaComercial
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As entCuentaComercial
        If Existe(pEmpresa, pCuentaComercial) Then
            CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "' "
            Return Obtener(New entCuentaComercial, CadenaSQL)
        Else
            Return New entCuentaComercial
        End If
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pTipoDocumento As String, ByVal pNumeroDocumento As String) As entCuentaComercial
        If Existe(pEmpresa, pTipoDocumento, pNumeroDocumento) Then
            CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES " &
                        "WHERE EMPRESA='" & pEmpresa & "' AND TIPO_DOCUMENTO='" & pTipoDocumento & "' AND NRO_DOCUMENTO='" & pNumeroDocumento & "' "
            Return Obtener(New entCuentaComercial, CadenaSQL)
        Else
            Return New entCuentaComercial
        End If
    End Function

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaComercial) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CUENTAS_COMERCIALES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCuentaComercial)
                MySQLDbconnection.Open()
                MyCount = CInt(MySQLCommand.ExecuteScalar)
            End Using
        End If
        Return IIf(MyCount = 0, False, True)
    End Function

    Private Shared Function Obtener(ByVal cCuentaComercial As entCuentaComercial, ByVal MySQL As String) As entCuentaComercial
        Dim MyDT As New dsCuentasComerciales.CUENTAS_COMERCIALESDataTable
        Call ObtenerDataTableSQL(MySQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaComercial
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .grupo_comercial = MyDT(0).GRUPO_COMERCIAL
                .tipo_cuenta = MyDT(0).TIPO_CUENTA
                .tipo_documento = MyDT(0).TIPO_DOCUMENTO.Trim
                .nro_documento = MyDT(0).NRO_DOCUMENTO
                .razon_social = MyDT(0).RAZON_SOCIAL
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
                .domicilio = MyDT(0).DOMICILIO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .telefono_otro = MyDT(0).TELEFONO_OTRO
                .celular = MyDT(0).CELULAR
                .fax = MyDT(0).FAX
                .email = MyDT(0).EMAIL
                .pagina_web = MyDT(0).PAGINA_WEB
                .direccion_trabajo = MyDT(0).DIRECCION_TRABAJO
                .referencia_trabajo = MyDT(0).REFERENCIA_TRABAJO
                .telefono_trabajo = MyDT(0).TELEFONO_TRABAJO
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .contacto_comercial = MyDT(0).CONTACTO_COMERCIAL
                .condicion_pago = MyDT(0).CONDICION_PAGO
                .forma_pago = MyDT(0).FORMA_PAGO
                .documento_pago = MyDT(0).DOCUMENTO_PAGO
                .linea_credito_mn = MyDT(0).LINEA_CREDITO_MN
                .linea_credito_me = MyDT(0).LINEA_CREDITO_ME
                .saldo_pagar_mn = MyDT(0).SALDO_PAGAR_MN
                .saldo_pagar_me = MyDT(0).SALDO_PAGAR_ME
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
                .banco_pago_mn = MyDT(0).BANCO_PAGO_MN
                .banco_pago_me = MyDT(0).BANCO_PAGO_ME
                .tipo_contable = MyDT(0).TIPO_CONTABLE
                .vigente_sunat = MyDT(0).VIGENTE_SUNAT
                If Not MyDT(0).IsNull("FECHA_ALTA_SUNAT") Then .fecha_alta_sunat = MyDT(0).FECHA_ALTA_SUNAT
                .afecto_igv = MyDT(0).AFECTO_IGV
                .agente_retencion = MyDT(0).AGENTE_RETENCION
                .agente_detraccion = MyDT(0).AGENTE_DETRACCION
                .agente_percepcion = MyDT(0).AGENTE_PERCEPCION
                .porcentaje_detraccion = MyDT(0).PORCENTAJE_DETRACCION
                .cuenta_detraccion = MyDT(0).CUENTA_DETRACCION
                .indica_cliente = MyDT(0).INDICA_CLIENTE
                .indica_proveedor = MyDT(0).INDICA_PROVEEDOR
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_comprador = MyDT(0).CODIGO_COMPRADOR
                .ultima_compra = MyDT(0).ULTIMA_COMPRA
                .ultima_venta = MyDT(0).ULTIMA_VENTA
                .apellido_paterno = MyDT(0).APELLIDO_PATERNO
                .apellido_materno = MyDT(0).APELLIDO_MATERNO
                .apellido_casada = MyDT(0).APELLIDO_CASADA
                .nombres = MyDT(0).NOMBRES
                If Not MyDT(0).IsNull("FECHA_NACIMIENTO") Then .fecha_nacimiento = MyDT(0).FECHA_NACIMIENTO
                .sexo = MyDT(0).SEXO
                .estado_civil = MyDT(0).ESTADO_CIVIL
                .nivel_educativo = MyDT(0).NIVEL_EDUCATIVO
                .ocupacion = MyDT(0).OCUPACION
                .situacion_crediticia = MyDT(0).SITUACION_CREDITICIA
                .calificacion = MyDT(0).CALIFICACION
                .indica_preferente = MyDT(0).INDICA_PREFERENTE
                .indica_fallecido = MyDT(0).INDICA_FALLECIDO
                .exige_garante = MyDT(0).EXIGE_GARANTE
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .comentario = MyDT(0).COMENTARIO
                .usuario_web = MyDT(0).USUARIO_WEB
                .clave_web = MyDT(0).CLAVE_WEB
                .codigo_antiguo = MyDT(0).CODIGO_ANTIGUO
                .item_flujo = MyDT(0).ITEM_FLUJO
                .exige_orden_compra = MyDT(0).EXIGE_ORDEN_COMPRA
                .tipo_orden_compra = MyDT(0).TIPO_ORDEN_COMPRA
                .exige_orden_pago = MyDT(0).EXIGE_ORDEN_PAGO
                .tipo_orden_pago = MyDT(0).TIPO_ORDEN_PAGO
                .estado = MyDT(0).ESTADO
                .agencia_registro = MyDT(0).AGENCIA_REGISTRO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("AGENCIA_MODIFICA") Then .agencia_modifica = MyDT(0).AGENCIA_MODIFICA
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
                If Not MyDT(0).IsNull("USUARIO_APROBACION") Then .usuario_aprobacion = MyDT(0).USUARIO_APROBACION
                If Not MyDT(0).IsNull("FECHA_APROBACION") Then .fecha_aprobacion = MyDT(0).FECHA_APROBACION
                If Not MyDT(0).IsNull("ULTIMO_PRODUCTO_CODIGO") Then .ultimo_producto_codigo = MyDT(0).ULTIMO_PRODUCTO_CODIGO
                If Not MyDT(0).IsNull("ULTIMO_PRODUCTO_FECHA") Then .ultimo_producto_fecha = MyDT(0).ULTIMO_PRODUCTO_FECHA
            End With
        End If
        Return cCuentaComercial
    End Function

    Public Shared Function ObtenerDomicilioEnvio(ByVal pEmpresa As String, ByVal pCuentaComercial As String) As dsCuentasComerciales.DIRECCION_ENVIODataTable
        Dim MyDT As New dsCuentasComerciales.DIRECCION_ENVIODataTable
        CadenaSQL = "SELECT EMPRESA, CUENTA_COMERCIAL, 'DOMICILIO FISCAL' AS DESCRIPCION, '01' AS DOMICILIO_ENVIO, DOMICILIO + ' ' + DISTRITO + ' ' + PROVINCIA + ' ' + DEPARTAMENTO AS DIRECCION, REFERENCIA " & _
                    "FROM COM.DOMICILIO_FISCAL " & _
                    "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "' " & _
                    "UNION ALL " & _
                    "SELECT EMPRESA, CUENTA_COMERCIAL, DESCRIPCION, DOMICILIO_ENVIO, DOMICILIO AS DIRECCION, REFERENCIA " & _
                    "FROM COM.CUENTAS_COMERCIALES_DOM " & _
                    "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCuentaComercial & "' AND ESTADO='A' " & _
                    "ORDER BY  DOMICILIO_ENVIO"
        Call ObtenerDataTableSQL(CadenaSQL, MyDT)
        Return MyDT
    End Function

    Public Shared Function GrabarCliente(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial

        With cCuentaComercial
            .tipo_cuenta = IIf(.tipo_documento.Trim = "6", "J", "N")
            .agencia_registro = "A0000" & MyUsuario.almacen
            .agencia_modifica = "A0000" & MyUsuario.almacen
        End With

        If cCuentaComercial.cuenta_comercial = "00000000" Then
            MyCuentaComercial = InsertarCliente(cCuentaComercial)
        Else
            MyCuentaComercial = ActualizarCliente(cCuentaComercial)
        End If
        Return MyCuentaComercial
    End Function

    Private Shared Function InsertarCliente(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial
        cCuentaComercial.cuenta_comercial = AsignarCodigo(cCuentaComercial.empresa)
        MySqlString = "INSERT INTO COM.CUENTAS_COMERCIALES " &
        "(EMPRESA,CUENTA_COMERCIAL,TIPO_CUENTA,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,INDICA_NO_DOMICILIADO,PAIS,DOMICILIO,DEPARTAMENTO,PROVINCIA,UBIGEO," &
        "REFERENCIA,TELEFONO,TELEFONO_OTRO,CELULAR,EMAIL,FECHA_NACIMIENTO,SEXO,ESTADO_CIVIL,NIVEL_EDUCATIVO,OCUPACION,APELLIDO_CASADA," &
        "DIRECCION_TRABAJO,REFERENCIA_TRABAJO,TELEFONO_TRABAJO,INDICA_CLIENTE,AGENCIA_REGISTRO,USUARIO_REGISTRO) " &
        "VALUES " &
        "(@vEmpresa,@vCuenta_comercial,@vTipo_cuenta,@vTipo_documento,@vNro_documento,@vRazon_social,@vIndica_no_domiciliado,@vPais,@vDomicilio,@vDepartamento,@vProvincia,@vUbigeo," &
        "@vReferencia,@vTelefono,@vTelefono_otro,@vCelular,@vEmail,@vFecha_nacimiento,@vSexo,@vEstado_civil,@vNivel_educativo,@vOcupacion,@vApellido_casada," &
        "@vDireccion_trabajo,@vReferencia_trabajo,@vTelefono_trabajo,@vIndica_cliente,@vAgencia_registro,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCuentaComercial.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
                .AddWithValue("vTipo_cuenta", cCuentaComercial.tipo_cuenta)
                .AddWithValue("vTipo_documento", cCuentaComercial.tipo_documento)
                .AddWithValue("vNro_documento", cCuentaComercial.nro_documento)
                .AddWithValue("vRazon_social", cCuentaComercial.razon_social)
                .AddWithValue("vIndica_no_domiciliado", cCuentaComercial.indica_no_domiciliado)
                .AddWithValue("vPais", cCuentaComercial.pais)
                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vDepartamento", cCuentaComercial.departamento)
                .AddWithValue("vProvincia", cCuentaComercial.provincia)
                .AddWithValue("vUbigeo", cCuentaComercial.ubigeo)
                .AddWithValue("vReferencia", cCuentaComercial.referencia)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vTelefono_otro", cCuentaComercial.telefono_otro)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vFecha_nacimiento", cCuentaComercial.fecha_nacimiento)
                .AddWithValue("vSexo", cCuentaComercial.sexo)
                .AddWithValue("vEstado_civil", cCuentaComercial.estado_civil)
                .AddWithValue("vNivel_educativo", cCuentaComercial.nivel_educativo)
                .AddWithValue("vOcupacion", cCuentaComercial.ocupacion)
                .AddWithValue("vApellido_casada", cCuentaComercial.apellido_casada)
                .AddWithValue("vDireccion_trabajo", cCuentaComercial.direccion_trabajo)
                .AddWithValue("vReferencia_trabajo", cCuentaComercial.referencia_trabajo)
                .AddWithValue("vTelefono_trabajo", cCuentaComercial.telefono_trabajo)
                .AddWithValue("vIndica_cliente", cCuentaComercial.indica_cliente)
                .AddWithValue("vAgencia_registro", cCuentaComercial.agencia_registro)
                .AddWithValue("vUsuario_registro", cCuentaComercial.usuario_registro)
            End With

            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()

                Return cCuentaComercial
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function ActualizarCliente(ByVal cCuentaComercial As entCuentaComercial) As entCuentaComercial

        MySqlString = "UPDATE COM.CUENTAS_COMERCIALES SET " &
        "indica_no_domiciliado=@vIndica_no_domiciliado,pais=@vPais,domicilio=@vDomicilio,departamento=@vDepartamento,provincia=@vProvincia,ubigeo=@vUbigeo," &
        "referencia=@vReferencia,telefono=@vTelefono,telefono_otro=@vTelefono_otro,celular=@vCelular,email=@vEmail," &
        "fecha_nacimiento=@vFecha_nacimiento,sexo=@vSexo,estado_civil=@vEstado_civil,nivel_educativo=@vNivel_educativo,ocupacion=@vOcupacion,apellido_casada=@vApellido_casada," &
        "direccion_trabajo=@vDireccion_trabajo,referencia_trabajo=@vReferencia_trabajo,telefono_trabajo=@vTelefono_trabajo," &
        "agencia_modifica=@vAgencia_modifica,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " &
        "WHERE empresa=@vEmpresa AND cuenta_comercial=@vCuenta_comercial "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vIndica_no_domiciliado", cCuentaComercial.indica_no_domiciliado)
                .AddWithValue("vPais", cCuentaComercial.pais)
                .AddWithValue("vDomicilio", cCuentaComercial.domicilio)
                .AddWithValue("vDepartamento", cCuentaComercial.departamento)
                .AddWithValue("vProvincia", cCuentaComercial.provincia)
                .AddWithValue("vUbigeo", cCuentaComercial.ubigeo)
                .AddWithValue("vReferencia", cCuentaComercial.referencia)
                .AddWithValue("vTelefono", cCuentaComercial.telefono)
                .AddWithValue("vTelefono_otro", cCuentaComercial.telefono_otro)
                .AddWithValue("vCelular", cCuentaComercial.celular)
                .AddWithValue("vEmail", cCuentaComercial.email)
                .AddWithValue("vFecha_nacimiento", cCuentaComercial.fecha_nacimiento)
                .AddWithValue("vSexo", cCuentaComercial.sexo)
                .AddWithValue("vEstado_civil", cCuentaComercial.estado_civil)
                .AddWithValue("vNivel_educativo", cCuentaComercial.nivel_educativo)
                .AddWithValue("vOcupacion", cCuentaComercial.ocupacion)
                .AddWithValue("vApellido_casada", cCuentaComercial.apellido_casada)
                .AddWithValue("vDireccion_trabajo", cCuentaComercial.direccion_trabajo)
                .AddWithValue("vReferencia_trabajo", cCuentaComercial.referencia_trabajo)
                .AddWithValue("vTelefono_trabajo", cCuentaComercial.telefono_trabajo)
                .AddWithValue("vAgencia_modifica", cCuentaComercial.agencia_modifica)
                .AddWithValue("vUsuario_modifica", cCuentaComercial.usuario_modifica)
                .AddWithValue("vEmpresa", cCuentaComercial.empresa)
                .AddWithValue("vCuenta_comercial", cCuentaComercial.cuenta_comercial)
            End With
            Try
                MySQLDbconnection.Open()

                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                MySQLCommand.ExecuteNonQuery()

                MySQLTransaction.Commit()
                Return cCuentaComercial
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function


End Class
