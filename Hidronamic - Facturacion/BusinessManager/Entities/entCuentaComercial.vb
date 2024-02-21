Public Class entCuentaComercial
    Private m_empresa As String

    Private m_cuenta_comercial As String

    Private m_grupo_comercial As String

    Private m_tipo_documento As String

    Private m_nro_documento As String

    Private m_razon_social As String

    Private m_domicilio As String

    Private m_siglas As String

    Private m_via_tipo As String

    Private m_via_nombre As String

    Private m_via_numero As String

    Private m_via_interior As String

    Private m_zona_tipo As String

    Private m_zona_nombre As String

    Private m_referencia As String

    Private m_pais As String

    Private m_departamento As String

    Private m_provincia As String

    Private m_ubigeo As String

    Private m_indica_no_domiciliado As String

    Private m_domicilio_envio As String

    Private m_codigo_postal As String

    Private m_telefono As String

    Private m_celular As String

    Private m_fax As String

    Private m_email As String

    Private m_pagina_web As String

    Private m_tipo_moneda As String

    Private m_contacto_comercial As String

    Private m_condicion_pago As String

    Private m_tipo_pago As String

    Private m_tipo_documento_pago As String

    Private m_linea_credito_mn As Single

    Private m_linea_credito_me As Single

    Private m_saldo_pagar_mn As Single

    Private m_saldo_pagar_me As Single

    Private m_vigencia_credito As Date

    Private m_codigo_antiguo As String

    Private m_lista_precios As String

    Private m_porcentaje_descuento_1 As Single

    Private m_porcentaje_descuento_2 As Single

    Private m_porcentaje_descuento_3 As Single

    Private m_cuenta_contable_cliente_mn As String

    Private m_cuenta_contable_cliente_me As String

    Private m_cuenta_contable_proveedor_mn As String

    Private m_cuenta_contable_proveedor_me As String

    Private m_cuenta_contable_ingreso As String

    Private m_cuenta_contable_gasto As String

    Private m_cuenta_bancaria_mn As String

    Private m_cuenta_bancaria_me As String

    Private m_tipo_contable As String

    Private m_banco_pago_mn As String

    Private m_banco_pago_me As String

    Private m_vigente_sunat As String

    Private m_fecha_alta_sunat As Date

    Private m_afecto_igv As String

    Private m_agente_retencion As String

    Private m_agente_detraccion As String

    Private m_agente_percepcion As String

    Private m_indica_cliente As String

    Private m_indica_proveedor As String

    Private m_codigo_vendedor As String

    Private m_codigo_comprador As String

    Private m_ultima_compra As String

    Private m_ultima_venta As String

    Private m_apellido_paterno As String

    Private m_apellido_materno As String

    Private m_nombres As String

    Private m_fecha_nacimiento As Date

    Private m_sexo As String

    Private m_calificacion As String

    Private m_zona_comercial As String

    Private m_comentario As String

    Private m_usuario_web As String

    Private m_clave_web As String

    Private m_item_flujo As String

    Private m_porcentaje_detraccion As Single

    Private m_cuenta_detraccion As String

    Private m_estado As String

    Private m_exige_orden_compra As String

    Private m_tipo_orden_compra As String

    Private m_exige_orden_pago As String

    Private m_tipo_orden_pago As String

    Private m_usuario_registro As String

    Private m_fecha_registro As Date

    Private m_usuario_modifica As String

    Private m_fecha_modifica As Date



    Public Sub New()

        Me.empresa = Nothing

        Me.cuenta_comercial = Nothing

        Me.grupo_comercial = Nothing

        Me.tipo_documento = Nothing

        Me.nro_documento = Nothing

        Me.razon_social = Nothing

        Me.domicilio = Nothing

        Me.siglas = Nothing

        Me.via_tipo = Nothing

        Me.via_nombre = Nothing

        Me.via_numero = Nothing

        Me.via_interior = Nothing

        Me.zona_tipo = Nothing

        Me.zona_nombre = Nothing

        Me.referencia = Nothing

        Me.pais = Nothing

        Me.departamento = Nothing

        Me.provincia = Nothing

        Me.ubigeo = Nothing

        Me.indica_no_domiciliado = Nothing

        Me.domicilio_envio = Nothing

        Me.codigo_postal = Nothing

        Me.telefono = Nothing

        Me.celular = Nothing

        Me.fax = Nothing

        Me.email = Nothing

        Me.pagina_web = Nothing

        Me.tipo_moneda = Nothing

        Me.contacto_comercial = Nothing

        Me.condicion_pago = Nothing

        Me.tipo_pago = Nothing

        Me.tipo_documento_pago = Nothing

        Me.linea_credito_mn = Nothing

        Me.linea_credito_me = Nothing

        Me.saldo_pagar_mn = Nothing

        Me.saldo_pagar_me = Nothing

        Me.vigencia_credito = Nothing

        Me.codigo_antiguo = Nothing

        Me.lista_precios = Nothing

        Me.porcentaje_descuento_1 = Nothing

        Me.porcentaje_descuento_2 = Nothing

        Me.porcentaje_descuento_3 = Nothing

        Me.cuenta_contable_cliente_mn = Nothing

        Me.cuenta_contable_cliente_me = Nothing

        Me.cuenta_contable_proveedor_mn = Nothing

        Me.cuenta_contable_proveedor_me = Nothing

        Me.cuenta_contable_ingreso = Nothing

        Me.cuenta_contable_gasto = Nothing

        Me.cuenta_bancaria_mn = Nothing

        Me.cuenta_bancaria_me = Nothing

        Me.tipo_contable = Nothing

        Me.banco_pago_mn = Nothing

        Me.banco_pago_me = Nothing

        Me.vigente_sunat = Nothing

        Me.fecha_alta_sunat = Nothing

        Me.afecto_igv = Nothing

        Me.agente_retencion = Nothing

        Me.agente_detraccion = Nothing

        Me.agente_percepcion = Nothing

        Me.indica_cliente = Nothing

        Me.indica_proveedor = Nothing

        Me.codigo_vendedor = Nothing

        Me.codigo_comprador = Nothing

        Me.ultima_compra = Nothing

        Me.ultima_venta = Nothing

        Me.apellido_paterno = Nothing

        Me.apellido_materno = Nothing

        Me.nombres = Nothing

        Me.fecha_nacimiento = Nothing

        Me.sexo = Nothing

        Me.calificacion = Nothing

        Me.zona_comercial = Nothing

        Me.comentario = Nothing

        Me.usuario_web = Nothing

        Me.clave_web = Nothing

        Me.codigo_antiguo = Nothing

        Me.estado = Nothing

        Me.item_flujo = Nothing

        Me.porcentaje_detraccion = Nothing

        Me.cuenta_detraccion = Nothing

        Me.exige_orden_compra = Nothing

        Me.tipo_orden_compra = Nothing

        Me.exige_orden_pago = Nothing

        Me.tipo_orden_pago = Nothing

        Me.usuario_registro = Nothing

        Me.fecha_registro = Nothing

        Me.usuario_modifica = Nothing

        Me.fecha_modifica = Nothing

    End Sub



    Public Sub New(ByVal CuentaComercial As entCuentaComercial)



        With CuentaComercial

            m_empresa = .empresa

            m_cuenta_comercial = .cuenta_comercial

            m_grupo_comercial = .grupo_comercial

            m_tipo_documento = .tipo_documento

            m_nro_documento = .nro_documento

            m_razon_social = .razon_social

            m_domicilio = .domicilio

            m_siglas = .siglas

            m_via_tipo = .via_tipo

            m_via_nombre = .via_nombre

            m_via_numero = .via_numero

            m_via_interior = .via_interior

            m_zona_tipo = .zona_tipo

            m_zona_nombre = .zona_nombre

            m_referencia = .referencia

            m_pais = .pais

            m_departamento = .departamento

            m_provincia = .provincia

            m_ubigeo = .ubigeo

            m_indica_no_domiciliado = .indica_no_domiciliado

            m_domicilio_envio = .domicilio_envio

            m_codigo_postal = .codigo_postal

            m_telefono = .telefono

            m_celular = .celular

            m_fax = .fax

            m_email = .email

            m_pagina_web = .pagina_web

            m_tipo_moneda = .tipo_moneda

            m_contacto_comercial = .contacto_comercial

            m_condicion_pago = .condicion_pago

            m_tipo_pago = .tipo_pago

            m_tipo_documento_pago = .tipo_documento_pago

            m_linea_credito_mn = .linea_credito_mn

            m_linea_credito_me = .linea_credito_me

            m_saldo_pagar_mn = .saldo_pagar_mn

            m_saldo_pagar_me = .saldo_pagar_me

            m_vigencia_credito = .vigencia_credito

            m_codigo_antiguo = .codigo_antiguo

            m_lista_precios = .lista_precios

            m_porcentaje_descuento_1 = .porcentaje_descuento_1

            m_porcentaje_descuento_2 = .porcentaje_descuento_2

            m_porcentaje_descuento_3 = .porcentaje_descuento_3

            m_cuenta_contable_cliente_mn = .cuenta_contable_cliente_mn

            m_cuenta_contable_cliente_me = .cuenta_contable_cliente_me

            m_cuenta_contable_proveedor_mn = .cuenta_contable_proveedor_mn

            m_cuenta_contable_proveedor_me = .cuenta_contable_proveedor_me

            m_cuenta_contable_ingreso = .cuenta_contable_ingreso

            m_cuenta_contable_gasto = .cuenta_contable_gasto

            m_cuenta_bancaria_mn = .cuenta_bancaria_mn

            m_cuenta_bancaria_me = .cuenta_bancaria_me

            m_tipo_contable = .tipo_contable

            m_banco_pago_mn = .banco_pago_mn

            m_banco_pago_me = .banco_pago_me

            m_vigente_sunat = .vigente_sunat

            m_fecha_alta_sunat = .fecha_alta_sunat

            m_afecto_igv = .afecto_igv

            m_agente_retencion = .agente_retencion

            m_agente_detraccion = .agente_detraccion

            m_agente_percepcion = .agente_percepcion

            m_indica_cliente = .indica_cliente

            m_indica_proveedor = .indica_proveedor

            m_codigo_vendedor = .codigo_vendedor

            m_codigo_comprador = .codigo_comprador

            m_ultima_compra = .ultima_compra

            m_ultima_venta = .ultima_venta

            m_apellido_paterno = .apellido_paterno

            m_apellido_materno = .apellido_materno

            m_nombres = .nombres

            m_fecha_nacimiento = .fecha_nacimiento

            m_sexo = .sexo

            m_calificacion = .calificacion

            m_zona_comercial = .zona_comercial

            m_comentario = .comentario

            m_usuario_web = .usuario_web

            m_clave_web = .clave_web

            m_codigo_antiguo = .codigo_antiguo

            m_estado = .estado

            m_item_flujo = .item_flujo

            m_porcentaje_detraccion = .porcentaje_detraccion

            m_cuenta_detraccion = .cuenta_detraccion

            m_exige_orden_compra = .exige_orden_compra

            m_tipo_orden_compra = tipo_orden_compra

            m_exige_orden_pago = exige_orden_pago

            m_tipo_orden_pago = tipo_orden_pago

            m_usuario_registro = .usuario_registro

            m_fecha_registro = .fecha_registro

            m_usuario_modifica = .usuario_modifica

            m_fecha_modifica = .fecha_modifica

        End With

    End Sub



    Public Property empresa() As String

        Get

            Return m_empresa

        End Get

        Set(ByVal value As String)

            m_empresa = value

        End Set

    End Property



    Public Property cuenta_comercial() As String

        Get

            Return m_cuenta_comercial

        End Get

        Set(ByVal value As String)

            m_cuenta_comercial = value

        End Set

    End Property



    Public Property grupo_comercial() As String

        Get

            Return m_grupo_comercial

        End Get

        Set(ByVal value As String)

            m_grupo_comercial = IIf(String.IsNullOrEmpty(value), "G0000000", value)

        End Set

    End Property



    Public Property tipo_documento() As String

        Get

            Return m_tipo_documento

        End Get

        Set(ByVal value As String)

            m_tipo_documento = value

        End Set

    End Property



    Public Property nro_documento() As String

        Get

            Return m_nro_documento

        End Get

        Set(ByVal value As String)

            m_nro_documento = value

        End Set

    End Property



    Public Property razon_social() As String

        Get

            Return m_razon_social

        End Get

        Set(ByVal value As String)

            m_razon_social = value

        End Set

    End Property



    Public Property domicilio() As String

        Get

            Return m_domicilio

        End Get

        Set(ByVal value As String)

            m_domicilio = value

        End Set

    End Property



    Public Property siglas() As String

        Get

            Return m_siglas

        End Get

        Set(ByVal value As String)

            m_siglas = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property via_tipo() As String

        Get

            Return m_via_tipo

        End Get

        Set(ByVal value As String)

            m_via_tipo = IIf(String.IsNullOrEmpty(value), "01", value)

        End Set

    End Property



    Public Property via_nombre() As String

        Get

            Return m_via_nombre

        End Get

        Set(ByVal value As String)

            m_via_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property via_numero() As String

        Get

            Return m_via_numero

        End Get

        Set(ByVal value As String)

            m_via_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property via_interior() As String

        Get

            Return m_via_interior

        End Get

        Set(ByVal value As String)

            m_via_interior = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property zona_tipo() As String

        Get

            Return m_zona_tipo

        End Get

        Set(ByVal value As String)

            m_zona_tipo = IIf(String.IsNullOrEmpty(value), "01", value)

        End Set

    End Property



    Public Property zona_nombre() As String

        Get

            Return m_zona_nombre

        End Get

        Set(ByVal value As String)

            m_zona_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property referencia() As String

        Get

            Return m_referencia

        End Get

        Set(ByVal value As String)

            m_referencia = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property pais() As String

        Get

            Return m_pais

        End Get

        Set(ByVal value As String)

            m_pais = IIf(String.IsNullOrEmpty(value), "9589", value)

        End Set

    End Property



    Public Property departamento() As String

        Get

            Return m_departamento

        End Get

        Set(ByVal value As String)

            m_departamento = IIf(String.IsNullOrEmpty(value), "15", value)

        End Set

    End Property



    Public Property provincia() As String

        Get

            Return m_provincia

        End Get

        Set(ByVal value As String)

            m_provincia = IIf(String.IsNullOrEmpty(value), "1501", value)

        End Set

    End Property



    Public Property ubigeo() As String

        Get

            Return m_ubigeo

        End Get

        Set(ByVal value As String)

            m_ubigeo = IIf(String.IsNullOrEmpty(value), "150101", value)

        End Set

    End Property



    Public Property indica_no_domiciliado() As String

        Get

            Return m_indica_no_domiciliado

        End Get

        Set(ByVal value As String)

            m_indica_no_domiciliado = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property domicilio_envio() As String

        Get

            Return m_domicilio_envio

        End Get

        Set(ByVal value As String)

            m_domicilio_envio = IIf(String.IsNullOrEmpty(value), "01", value)

        End Set

    End Property



    Public Property codigo_postal() As String

        Get

            Return m_codigo_postal

        End Get

        Set(ByVal value As String)

            m_codigo_postal = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property telefono() As String

        Get

            Return m_telefono

        End Get

        Set(ByVal value As String)

            m_telefono = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property celular() As String

        Get

            Return m_celular

        End Get

        Set(ByVal value As String)

            m_celular = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property fax() As String

        Get

            Return m_fax

        End Get

        Set(ByVal value As String)

            m_fax = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property email() As String

        Get

            Return m_email

        End Get

        Set(ByVal value As String)

            m_email = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property pagina_web() As String

        Get

            Return m_pagina_web

        End Get

        Set(ByVal value As String)

            m_pagina_web = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property tipo_moneda() As String

        Get

            Return m_tipo_moneda

        End Get

        Set(ByVal value As String)

            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "2", value)

        End Set

    End Property



    Public Property contacto_comercial() As String

        Get

            Return m_contacto_comercial

        End Get

        Set(ByVal value As String)

            m_contacto_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property condicion_pago() As String

        Get

            Return m_condicion_pago

        End Get

        Set(ByVal value As String)

            m_condicion_pago = IIf(String.IsNullOrEmpty(value), "30", value)

        End Set

    End Property



    Public Property tipo_pago() As String

        Get

            Return m_tipo_pago

        End Get

        Set(ByVal value As String)

            m_tipo_pago = IIf(String.IsNullOrEmpty(value), "007", value)

        End Set

    End Property



    Public Property tipo_documento_pago() As String

        Get

            Return m_tipo_documento_pago

        End Get

        Set(ByVal value As String)

            m_tipo_documento_pago = IIf(String.IsNullOrEmpty(value), "01", value)

        End Set

    End Property



    Public Property linea_credito_mn() As Single

        Get

            Return m_linea_credito_mn

        End Get

        Set(ByVal value As Single)

            m_linea_credito_mn = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property linea_credito_me() As Single

        Get

            Return m_linea_credito_me

        End Get

        Set(ByVal value As Single)

            m_linea_credito_me = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property saldo_pagar_mn() As Single

        Get

            Return m_saldo_pagar_mn

        End Get

        Set(ByVal value As Single)

            m_saldo_pagar_mn = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property saldo_pagar_me() As Single

        Get

            Return m_saldo_pagar_me

        End Get

        Set(ByVal value As Single)

            m_saldo_pagar_me = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property vigencia_credito() As Date

        Get

            Return m_vigencia_credito

        End Get

        Set(ByVal value As Date)

            m_vigencia_credito = IIf(value.Ticks = 0, FechaNulo, value)

        End Set

    End Property



    Public Property lista_precios() As String

        Get

            Return m_lista_precios

        End Get

        Set(ByVal value As String)

            m_lista_precios = IIf(String.IsNullOrEmpty(value), "LP0000000000", value)

        End Set

    End Property



    Public Property porcentaje_descuento_1() As Single

        Get

            Return m_porcentaje_descuento_1

        End Get

        Set(ByVal value As Single)

            m_porcentaje_descuento_1 = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property porcentaje_descuento_2() As Single

        Get

            Return m_porcentaje_descuento_2

        End Get

        Set(ByVal value As Single)

            m_porcentaje_descuento_2 = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property porcentaje_descuento_3() As Single

        Get

            Return m_porcentaje_descuento_3

        End Get

        Set(ByVal value As Single)

            m_porcentaje_descuento_3 = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property cuenta_contable_cliente_mn() As String

        Get

            Return m_cuenta_contable_cliente_mn

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_cliente_mn = IIf(String.IsNullOrEmpty(value), "121201", value)

        End Set

    End Property



    Public Property cuenta_contable_cliente_me() As String

        Get

            Return m_cuenta_contable_cliente_me

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_cliente_me = IIf(String.IsNullOrEmpty(value), "121202", value)

        End Set

    End Property



    Public Property cuenta_contable_proveedor_mn() As String

        Get

            Return m_cuenta_contable_proveedor_mn

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_proveedor_mn = IIf(String.IsNullOrEmpty(value), "421201", value)

        End Set

    End Property



    Public Property cuenta_contable_proveedor_me() As String

        Get

            Return m_cuenta_contable_proveedor_me

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_proveedor_me = IIf(String.IsNullOrEmpty(value), "421202", value)

        End Set

    End Property



    Public Property cuenta_contable_ingreso() As String

        Get

            Return m_cuenta_contable_ingreso

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_ingreso = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property cuenta_contable_gasto() As String

        Get

            Return m_cuenta_contable_gasto

        End Get

        Set(ByVal value As String)

            m_cuenta_contable_gasto = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property cuenta_bancaria_mn() As String

        Get

            Return m_cuenta_bancaria_mn

        End Get

        Set(ByVal value As String)

            m_cuenta_bancaria_mn = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property cuenta_bancaria_me() As String

        Get

            Return m_cuenta_bancaria_me

        End Get

        Set(ByVal value As String)

            m_cuenta_bancaria_me = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property tipo_contable() As String

        Get

            Return m_tipo_contable

        End Get

        Set(ByVal value As String)

            m_tipo_contable = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property banco_pago_mn() As String

        Get

            Return m_banco_pago_mn

        End Get

        Set(ByVal value As String)

            m_banco_pago_mn = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property banco_pago_me() As String

        Get

            Return m_banco_pago_me

        End Get

        Set(ByVal value As String)

            m_banco_pago_me = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property vigente_sunat() As String

        Get

            Return m_vigente_sunat

        End Get

        Set(ByVal value As String)

            m_vigente_sunat = IIf(String.IsNullOrEmpty(value), "SI", value)

        End Set

    End Property



    Public Property fecha_alta_sunat() As Date

        Get

            Return m_fecha_alta_sunat

        End Get

        Set(ByVal value As Date)

            m_fecha_alta_sunat = IIf(value.Ticks = 0, FechaNulo, value)

        End Set

    End Property



    Public Property afecto_igv() As String

        Get

            Return m_afecto_igv

        End Get

        Set(ByVal value As String)

            m_afecto_igv = IIf(String.IsNullOrEmpty(value), "SI", value)

        End Set

    End Property



    Public Property agente_retencion() As String

        Get

            Return m_agente_retencion

        End Get

        Set(ByVal value As String)

            m_agente_retencion = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property agente_detraccion() As String

        Get

            Return m_agente_detraccion

        End Get

        Set(ByVal value As String)

            m_agente_detraccion = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property agente_percepcion() As String

        Get

            Return m_agente_percepcion

        End Get

        Set(ByVal value As String)

            m_agente_percepcion = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property indica_cliente() As String

        Get

            Return m_indica_cliente

        End Get

        Set(ByVal value As String)

            m_indica_cliente = IIf(String.IsNullOrEmpty(value), "SI", value)

        End Set

    End Property



    Public Property indica_proveedor() As String

        Get

            Return m_indica_proveedor

        End Get

        Set(ByVal value As String)

            m_indica_proveedor = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property codigo_vendedor() As String

        Get

            Return m_codigo_vendedor

        End Get

        Set(ByVal value As String)

            m_codigo_vendedor = IIf(String.IsNullOrEmpty(value), "000", value)

        End Set

    End Property



    Public Property codigo_comprador() As String

        Get

            Return m_codigo_comprador

        End Get

        Set(ByVal value As String)

            m_codigo_comprador = IIf(String.IsNullOrEmpty(value), "000", value)

        End Set

    End Property



    Public Property ultima_compra() As String

        Get

            Return m_ultima_compra

        End Get

        Set(ByVal value As String)

            m_ultima_compra = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)

        End Set

    End Property



    Public Property ultima_venta() As String

        Get

            Return m_ultima_venta

        End Get

        Set(ByVal value As String)

            m_ultima_venta = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)

        End Set

    End Property



    Public Property apellido_paterno() As String

        Get

            Return m_apellido_paterno

        End Get

        Set(ByVal value As String)

            m_apellido_paterno = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property apellido_materno() As String

        Get

            Return m_apellido_materno

        End Get

        Set(ByVal value As String)

            m_apellido_materno = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property nombres() As String

        Get

            Return m_nombres

        End Get

        Set(ByVal value As String)

            m_nombres = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property fecha_nacimiento() As Date

        Get

            Return m_fecha_nacimiento

        End Get

        Set(ByVal value As Date)

            m_fecha_nacimiento = IIf(value.Ticks = 0, FechaNulo, value)

        End Set

    End Property



    Public Property sexo() As String

        Get

            Return m_sexo

        End Get

        Set(ByVal value As String)

            m_sexo = IIf(String.IsNullOrEmpty(value), "M", value)

        End Set

    End Property



    Public Property calificacion() As String

        Get

            Return m_calificacion

        End Get

        Set(ByVal value As String)

            m_calificacion = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property zona_comercial() As String

        Get

            Return m_zona_comercial

        End Get

        Set(ByVal value As String)

            m_zona_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property comentario() As String

        Get

            Return m_comentario

        End Get

        Set(ByVal value As String)

            m_comentario = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property usuario_web() As String

        Get

            Return m_usuario_web

        End Get

        Set(ByVal value As String)

            m_usuario_web = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property clave_web() As String

        Get

            Return m_clave_web

        End Get

        Set(ByVal value As String)

            m_clave_web = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property codigo_antiguo() As String

        Get

            Return m_codigo_antiguo

        End Get

        Set(ByVal value As String)

            m_codigo_antiguo = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property estado() As String

        Get

            Return m_estado

        End Get

        Set(ByVal value As String)

            m_estado = IIf(String.IsNullOrEmpty(value), "A", value)

        End Set

    End Property



    Public Property item_flujo() As String

        Get

            Return m_item_flujo

        End Get

        Set(ByVal value As String)

            m_item_flujo = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property porcentaje_detraccion() As Single

        Get

            Return m_porcentaje_detraccion

        End Get

        Set(ByVal value As Single)

            m_porcentaje_detraccion = IIf(String.IsNullOrEmpty(value), 0, value)

        End Set

    End Property



    Public Property cuenta_detraccion() As String

        Get

            Return m_cuenta_detraccion

        End Get

        Set(ByVal value As String)

            m_cuenta_detraccion = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property exige_orden_compra() As String

        Get

            Return m_exige_orden_compra

        End Get

        Set(ByVal value As String)

            m_exige_orden_compra = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property tipo_orden_compra() As String

        Get

            Return m_tipo_orden_compra

        End Get

        Set(ByVal value As String)

            m_tipo_orden_compra = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property exige_orden_pago() As String

        Get

            Return m_exige_orden_pago

        End Get

        Set(ByVal value As String)

            m_exige_orden_pago = IIf(String.IsNullOrEmpty(value), "NO", value)

        End Set

    End Property



    Public Property tipo_orden_pago() As String

        Get

            Return m_tipo_orden_pago

        End Get

        Set(ByVal value As String)

            m_tipo_orden_pago = IIf(String.IsNullOrEmpty(value), Space(1), value)

        End Set

    End Property



    Public Property usuario_registro() As String

        Get

            Return m_usuario_registro

        End Get

        Set(ByVal value As String)

            m_usuario_registro = value

        End Set

    End Property



    Public Property fecha_registro() As Date

        Get

            Return m_fecha_registro

        End Get

        Set(ByVal value As Date)

            m_fecha_registro = IIf(value.Ticks = 0, Now, value)

        End Set

    End Property



    Public Property usuario_modifica() As String

        Get

            Return m_usuario_modifica

        End Get

        Set(ByVal value As String)

            m_usuario_modifica = value

        End Set

    End Property



    Public Property fecha_modifica() As Date

        Get

            Return m_fecha_modifica

        End Get

        Set(ByVal value As Date)

            m_fecha_modifica = IIf(value.Ticks = 0, Now, value)

        End Set

    End Property


End Class
