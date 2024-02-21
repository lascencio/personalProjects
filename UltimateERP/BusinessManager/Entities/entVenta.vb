Public Class entVenta

    Private m_empresa As String
    Private m_venta As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_tipo_operacion As String
    Private m_orden_pedido As String
    Private m_asiento_tipo As String
    Private m_asiento_numero As String
    Private m_asiento_fecha As Date
    Private m_cuenta_comercial As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_vencimiento As Date
    Private m_tipo_cambio As Decimal
    Private m_tipo_moneda As String
    Private m_almacen As String
    Private m_lista_precio As String
    Private m_centro_distribucion As String
    Private m_codigo_domicilio As String

    Private m_valor_exportacion_origen As Decimal
    Private m_base_imponible_gravada_origen As Decimal
    Private m_importe_exonerado_origen As Decimal
    Private m_importe_inafecto_origen As Decimal
    Private m_isc_origen As Decimal
    Private m_igv_origen As Decimal
    Private m_ipm_origen As Decimal
    Private m_base_imponible_gravada2_origen As Decimal
    Private m_igv2_origen As Decimal
    Private m_otros_tributos_origen As Decimal
    Private m_descuento_global_origen As Decimal
    Private m_importe_total_origen As Decimal
    Private m_valor_exportacion_mn As Decimal
    Private m_base_imponible_gravada_mn As Decimal
    Private m_importe_exonerado_mn As Decimal
    Private m_importe_inafecto_mn As Decimal
    Private m_isc_mn As Decimal
    Private m_igv_mn As Decimal
    Private m_ipm_mn As Decimal
    Private m_base_imponible_gravada2_mn As Decimal
    Private m_igv2_mn As Decimal
    Private m_otros_tributos_mn As Decimal
    Private m_descuento_global_mn As Decimal
    Private m_importe_total_mn As Decimal
    Private m_valor_exportacion_me As Decimal
    Private m_base_imponible_gravada_me As Decimal
    Private m_importe_exonerado_me As Decimal
    Private m_importe_inafecto_me As Decimal
    Private m_isc_me As Decimal
    Private m_igv_me As Decimal
    Private m_ipm_me As Decimal
    Private m_base_imponible_gravada2_me As Decimal
    Private m_igv2_me As Decimal
    Private m_otros_tributos_me As Decimal
    Private m_descuento_global_me As Decimal
    Private m_importe_total_me As Decimal

    Private m_referencia_cuo As String
    Private m_condicion_pago As String
    Private m_forma_pago As String
    Private m_fecha_ultimo_pago As Date
    Private m_importe_saldo As Decimal
    Private m_comentario As String
    Private m_zona_comercial As String
    Private m_codigo_vendedor As String
    Private m_codigo_cobrador As String

    Private m_centro_costo As String
    Private m_letra As String
    Private m_factoring As String
    Private m_planilla_cobranza As String
    Private m_guia_remitente As String
    Private m_guia_transportista As String

    Private m_usuario_envio As String
    Private m_fecha_envio As Date
    Private m_estado_envio As String
    Private m_fecha_recepcion As Date
    Private m_indica_sujeta_detraccion As String
    Private m_porcentaje_detraccion As Decimal
    Private m_numero_detraccion As String
    Private m_fecha_detraccion As Date
    Private m_origen As String
    Private m_estado As String
    Private m_ubicacion_custodia As String
    Private m_usuario_custodia As String
    Private m_fecha_custodia As Date
    Private m_indica_referencia As Boolean
    Private m_referencia_tipo As String
    Private m_referencia_serie As String
    Private m_referencia_numero As String
    Private m_referencia_fecha As Date
    Private m_indica_impreso As String
    Private m_indica_exportacion As String
    Private m_indica_migrado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_grupo_comercial As String

    Private m_tipo_operacion_nombre As String

    Private m_tipo_documento As String
    Private m_nro_documento As String
    Private m_razon_social As String

    Private m_cuota_inicial As Decimal
    Private m_cuota_inicial_pagada As Decimal

    Public Sub New()
        Me.empresa = Nothing
        Me.venta = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.tipo_operacion = Nothing
        Me.orden_pedido = Nothing
        Me.asiento_tipo = Nothing
        Me.asiento_numero = Nothing
        Me.asiento_fecha = Nothing
        Me.cuenta_comercial = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_vencimiento = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.almacen = Nothing
        Me.lista_precio = Nothing
        Me.centro_distribucion = Nothing
        Me.codigo_domicilio = Nothing

        Me.valor_exportacion_origen = Nothing
        Me.base_imponible_gravada_origen = Nothing
        Me.importe_exonerado_origen = Nothing
        Me.importe_inafecto_origen = Nothing
        Me.isc_origen = Nothing
        Me.igv_origen = Nothing
        Me.ipm_origen = Nothing
        Me.base_imponible_gravada2_origen = Nothing
        Me.igv2_origen = Nothing
        Me.otros_tributos_origen = Nothing
        Me.descuento_global_origen = Nothing
        Me.importe_total_origen = Nothing

        Me.valor_exportacion_mn = Nothing
        Me.base_imponible_gravada_mn = Nothing
        Me.importe_exonerado_mn = Nothing
        Me.importe_inafecto_mn = Nothing
        Me.isc_mn = Nothing
        Me.igv_mn = Nothing
        Me.ipm_mn = Nothing
        Me.base_imponible_gravada2_mn = Nothing
        Me.igv2_mn = Nothing
        Me.otros_tributos_mn = Nothing
        Me.descuento_global_mn = Nothing
        Me.importe_total_mn = Nothing

        Me.valor_exportacion_me = Nothing
        Me.base_imponible_gravada_me = Nothing
        Me.importe_exonerado_me = Nothing
        Me.importe_inafecto_me = Nothing
        Me.isc_me = Nothing
        Me.igv_me = Nothing
        Me.ipm_me = Nothing
        Me.base_imponible_gravada2_me = Nothing
        Me.igv2_me = Nothing
        Me.otros_tributos_me = Nothing
        Me.descuento_global_me = Nothing
        Me.importe_total_me = Nothing

        Me.referencia_cuo = Nothing
        Me.condicion_pago = Nothing
        Me.forma_pago = Nothing
        Me.fecha_ultimo_pago = Nothing
        Me.importe_saldo = Nothing
        Me.comentario = Nothing
        Me.zona_comercial = Nothing
        Me.codigo_vendedor = Nothing
        Me.codigo_cobrador = Nothing

        Me.centro_costo = Nothing
        Me.letra = Nothing
        Me.factoring = Nothing
        Me.planilla_cobranza = Nothing
        Me.guia_remitente = Nothing
        Me.guia_transportista = Nothing

        Me.usuario_envio = Nothing
        Me.fecha_envio = Nothing
        Me.estado_envio = Nothing
        Me.fecha_recepcion = Nothing
        Me.indica_sujeta_detraccion = Nothing
        Me.porcentaje_detraccion = Nothing
        Me.numero_detraccion = Nothing
        Me.fecha_detraccion = Nothing
        Me.origen = Nothing
        Me.estado = Nothing
        Me.ubicacion_custodia = Nothing
        Me.usuario_custodia = Nothing
        Me.fecha_custodia = Nothing
        Me.indica_referencia = Nothing
        Me.referencia_tipo = Nothing
        Me.referencia_serie = Nothing
        Me.referencia_numero = Nothing
        Me.referencia_fecha = Nothing
        Me.indica_impreso = Nothing
        Me.indica_exportacion = Nothing
        Me.indica_migrado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.grupo_comercial = Nothing

        Me.tipo_operacion_nombre = Nothing

        Me.tipo_documento = Nothing
        Me.nro_documento = Nothing
        Me.razon_social = Nothing

        Me.cuota_inicial = Nothing
        Me.cuota_inicial_pagada = Nothing
    End Sub

    Public Sub New(ByVal Venta As entVenta)
        With Venta
            m_empresa = .empresa
            m_venta = .venta
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_tipo_operacion = .tipo_operacion
            m_orden_pedido = .orden_pedido
            m_asiento_tipo = .asiento_tipo
            m_asiento_numero = .asiento_numero
            m_asiento_fecha = .asiento_fecha
            m_cuenta_comercial = .cuenta_comercial
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_vencimiento = .comprobante_vencimiento
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_almacen = .almacen
            m_lista_precio = .lista_precio
            m_centro_distribucion = .centro_distribucion
            m_codigo_domicilio = .codigo_domicilio
            m_valor_exportacion_origen = .valor_exportacion_origen
            m_base_imponible_gravada_origen = .base_imponible_gravada_origen
            m_importe_exonerado_origen = .importe_exonerado_origen
            m_importe_inafecto_origen = .importe_inafecto_origen
            m_isc_origen = .isc_origen
            m_igv_origen = .igv_origen
            m_ipm_origen = .ipm_origen
            m_base_imponible_gravada2_origen = .base_imponible_gravada2_origen
            m_igv2_origen = .igv2_origen
            m_otros_tributos_origen = .otros_tributos_origen
            m_descuento_global_origen = .descuento_global_origen
            m_importe_total_origen = .importe_total_origen
            m_valor_exportacion_mn = .valor_exportacion_mn
            m_base_imponible_gravada_mn = .base_imponible_gravada_mn
            m_importe_exonerado_mn = .importe_exonerado_mn
            m_importe_inafecto_mn = .importe_inafecto_mn
            m_isc_mn = .isc_mn
            m_igv_mn = .igv_mn
            m_ipm_mn = .ipm_mn
            m_base_imponible_gravada2_mn = .base_imponible_gravada2_mn
            m_igv2_mn = .igv2_mn
            m_otros_tributos_mn = .otros_tributos_mn
            m_descuento_global_mn = .descuento_global_mn
            m_importe_total_mn = .importe_total_mn

            m_valor_exportacion_me = .valor_exportacion_me
            m_base_imponible_gravada_me = .base_imponible_gravada_me
            m_importe_exonerado_me = .importe_exonerado_me
            m_importe_inafecto_me = .importe_inafecto_me
            m_isc_me = .isc_me
            m_igv_me = .igv_me
            m_ipm_me = .ipm_me
            m_base_imponible_gravada2_me = .base_imponible_gravada2_me
            m_igv2_me = .igv2_me
            m_otros_tributos_me = .otros_tributos_me
            m_descuento_global_me = .descuento_global_me
            m_importe_total_me = .importe_total_me

            m_referencia_cuo = .referencia_cuo
            m_condicion_pago = .condicion_pago
            m_forma_pago = .forma_pago
            m_fecha_ultimo_pago = .fecha_ultimo_pago
            m_importe_saldo = .importe_saldo
            m_comentario = .comentario
            m_zona_comercial = .zona_comercial
            m_codigo_vendedor = .codigo_vendedor
            m_codigo_cobrador = .codigo_cobrador

            m_centro_costo = .centro_costo
            m_letra = .letra
            m_factoring = .factoring
            m_planilla_cobranza = .planilla_cobranza
            m_guia_remitente = .guia_remitente
            m_guia_transportista = .guia_transportista

            m_usuario_envio = .usuario_envio
            m_fecha_envio = .fecha_envio
            m_estado_envio = .estado_envio
            m_fecha_recepcion = .fecha_recepcion
            m_indica_sujeta_detraccion = .indica_sujeta_detraccion
            m_porcentaje_detraccion = .porcentaje_detraccion
            m_numero_detraccion = .numero_detraccion
            m_fecha_detraccion = .fecha_detraccion
            m_origen = .origen
            m_estado = .estado
            m_ubicacion_custodia = .ubicacion_custodia
            m_usuario_custodia = .usuario_custodia
            m_fecha_custodia = .fecha_custodia
            m_indica_referencia = .indica_referencia
            m_referencia_tipo = .referencia_tipo
            m_referencia_serie = .referencia_serie
            m_referencia_numero = .referencia_numero
            m_referencia_fecha = .referencia_fecha
            m_indica_impreso = .indica_impreso
            m_indica_exportacion = .indica_exportacion
            m_indica_migrado = .indica_migrado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_grupo_comercial = .grupo_comercial
            m_tipo_operacion_nombre = .tipo_operacion_nombre

            m_tipo_documento = .tipo_documento
            m_nro_documento = .nro_documento
            m_razon_social = .razon_social

            m_cuota_inicial = .cuota_inicial
            m_cuota_inicial_pagada = .cuota_inicial_pagada
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

    Public Property venta() As String
        Get
            Return m_venta
        End Get
        Set(ByVal value As String)
            m_venta = value
        End Set
    End Property

    Public Property ejercicio() As String
        Get
            Return m_ejercicio
        End Get
        Set(ByVal value As String)
            m_ejercicio = value
        End Set
    End Property

    Public Property mes() As String
        Get
            Return m_mes
        End Get
        Set(ByVal value As String)
            m_mes = value
        End Set
    End Property

    Public Property asiento_tipo() As String
        Get
            Return m_asiento_tipo
        End Get
        Set(ByVal value As String)
            m_asiento_tipo = IIf(String.IsNullOrEmpty(value), "05", value)
        End Set
    End Property

    Public Property asiento_numero() As String
        Get
            Return m_asiento_numero
        End Get
        Set(ByVal value As String)
            m_asiento_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property asiento_fecha() As Date
        Get
            Return m_asiento_fecha
        End Get
        Set(ByVal value As Date)
            m_asiento_fecha = IIf(value.Ticks = 0, FechaNulo, value)
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

    Public Property comprobante_tipo() As String
        Get
            Return m_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_comprobante_tipo = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property comprobante_serie() As String
        Get
            Return m_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_comprobante_serie = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property comprobante_numero() As String
        Get
            Return m_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_comprobante_numero = IIf(String.IsNullOrEmpty(value), "0000000000", value)
        End Set
    End Property

    Public Property comprobante_fecha() As Date
        Get
            Return m_comprobante_fecha
        End Get
        Set(ByVal value As Date)
            m_comprobante_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property comprobante_vencimiento() As Date
        Get
            Return m_comprobante_vencimiento
        End Get
        Set(ByVal value As Date)
            m_comprobante_vencimiento = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "1", value)
        End Set
    End Property

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property codigo_domicilio() As String
        Get
            Return m_codigo_domicilio
        End Get
        Set(ByVal value As String)
            m_codigo_domicilio = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property valor_exportacion_origen() As Decimal
        Get
            Return m_valor_exportacion_origen
        End Get
        Set(ByVal value As Decimal)
            m_valor_exportacion_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_origen() As Decimal
        Get
            Return m_base_imponible_gravada_origen
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_origen() As Decimal
        Get
            Return m_importe_exonerado_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_origen() As Decimal
        Get
            Return m_importe_inafecto_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_origen() As Decimal
        Get
            Return m_isc_origen
        End Get
        Set(ByVal value As Decimal)
            m_isc_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_origen() As Decimal
        Get
            Return m_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_origen() As Decimal
        Get
            Return m_ipm_origen
        End Get
        Set(ByVal value As Decimal)
            m_ipm_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_origen() As Decimal
        Get
            Return m_base_imponible_gravada2_origen
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_origen() As Decimal
        Get
            Return m_igv2_origen
        End Get
        Set(ByVal value As Decimal)
            m_igv2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_origen() As Decimal
        Get
            Return m_otros_tributos_origen
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_global_origen() As Decimal
        Get
            Return m_descuento_global_origen
        End Get
        Set(ByVal value As Decimal)
            m_descuento_global_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_origen() As Decimal
        Get
            Return m_importe_total_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_exportacion_mn() As Decimal
        Get
            Return m_valor_exportacion_mn
        End Get
        Set(ByVal value As Decimal)
            m_valor_exportacion_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_mn() As Decimal
        Get
            Return m_base_imponible_gravada_mn
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_mn() As Decimal
        Get
            Return m_importe_exonerado_mn
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_mn() As Decimal
        Get
            Return m_importe_inafecto_mn
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_mn() As Decimal
        Get
            Return m_isc_mn
        End Get
        Set(ByVal value As Decimal)
            m_isc_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_mn() As Decimal
        Get
            Return m_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_mn() As Decimal
        Get
            Return m_ipm_mn
        End Get
        Set(ByVal value As Decimal)
            m_ipm_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_mn() As Decimal
        Get
            Return m_base_imponible_gravada2_mn
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_mn() As Decimal
        Get
            Return m_igv2_mn
        End Get
        Set(ByVal value As Decimal)
            m_igv2_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_mn() As Decimal
        Get
            Return m_otros_tributos_mn
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_global_mn() As Decimal
        Get
            Return m_descuento_global_mn
        End Get
        Set(ByVal value As Decimal)
            m_descuento_global_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_mn() As Decimal
        Get
            Return m_importe_total_mn
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_exportacion_me() As Decimal
        Get
            Return m_valor_exportacion_me
        End Get
        Set(ByVal value As Decimal)
            m_valor_exportacion_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_me() As Decimal
        Get
            Return m_base_imponible_gravada_me
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_me() As Decimal
        Get
            Return m_importe_exonerado_me
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_me() As Decimal
        Get
            Return m_importe_inafecto_me
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_me() As Decimal
        Get
            Return m_isc_me
        End Get
        Set(ByVal value As Decimal)
            m_isc_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_me() As Decimal
        Get
            Return m_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_me() As Decimal
        Get
            Return m_ipm_me
        End Get
        Set(ByVal value As Decimal)
            m_ipm_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_me() As Decimal
        Get
            Return m_base_imponible_gravada2_me
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_me() As Decimal
        Get
            Return m_igv2_me
        End Get
        Set(ByVal value As Decimal)
            m_igv2_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_me() As Decimal
        Get
            Return m_otros_tributos_me
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_global_me() As Decimal
        Get
            Return m_descuento_global_me
        End Get
        Set(ByVal value As Decimal)
            m_descuento_global_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_me() As Decimal
        Get
            Return m_importe_total_me
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property referencia_cuo() As String
        Get
            Return m_referencia_cuo
        End Get
        Set(ByVal value As String)
            m_referencia_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property condicion_pago() As String
        Get
            Return m_condicion_pago
        End Get
        Set(ByVal value As String)
            m_condicion_pago = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property forma_pago() As String
        Get
            Return m_forma_pago
        End Get
        Set(ByVal value As String)
            m_forma_pago = IIf(String.IsNullOrEmpty(value), "EF", value)
        End Set
    End Property

    Public Property fecha_ultimo_pago() As Date
        Get
            Return m_fecha_ultimo_pago
        End Get
        Set(ByVal value As Date)
            m_fecha_ultimo_pago = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property importe_saldo() As Decimal
        Get
            Return m_importe_saldo
        End Get
        Set(ByVal value As Decimal)
            m_importe_saldo = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property tipo_operacion() As String
        Get
            Return m_tipo_operacion
        End Get
        Set(ByVal value As String)
            m_tipo_operacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property codigo_vendedor() As String
        Get
            Return m_codigo_vendedor
        End Get
        Set(ByVal value As String)
            m_codigo_vendedor = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property codigo_cobrador() As String
        Get
            Return m_codigo_cobrador
        End Get
        Set(ByVal value As String)
            m_codigo_cobrador = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property centro_costo() As String
        Get
            Return m_centro_costo
        End Get
        Set(ByVal value As String)
            m_centro_costo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property letra() As String
        Get
            Return m_letra
        End Get
        Set(ByVal value As String)
            m_letra = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property factoring() As String
        Get
            Return m_factoring
        End Get
        Set(ByVal value As String)
            m_factoring = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property planilla_cobranza() As String
        Get
            Return m_planilla_cobranza
        End Get
        Set(ByVal value As String)
            m_planilla_cobranza = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property guia_remitente() As String
        Get
            Return m_guia_remitente
        End Get
        Set(ByVal value As String)
            m_guia_remitente = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property guia_transportista() As String
        Get
            Return m_guia_transportista
        End Get
        Set(ByVal value As String)
            m_guia_transportista = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property orden_pedido() As String
        Get
            Return m_orden_pedido
        End Get
        Set(ByVal value As String)
            m_orden_pedido = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property usuario_envio() As String
        Get
            Return m_usuario_envio
        End Get
        Set(ByVal value As String)
            m_usuario_envio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_envio() As Date
        Get
            Return m_fecha_envio
        End Get
        Set(ByVal value As Date)
            m_fecha_envio = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property estado_envio() As String
        Get
            Return m_estado_envio
        End Get
        Set(ByVal value As String)
            m_estado_envio = IIf(String.IsNullOrEmpty(value), "P", value)
        End Set
    End Property

    Public Property fecha_recepcion() As Date
        Get
            Return m_fecha_recepcion
        End Get
        Set(ByVal value As Date)
            m_fecha_recepcion = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property indica_sujeta_detraccion() As String
        Get
            Return m_indica_sujeta_detraccion
        End Get
        Set(ByVal value As String)
            m_indica_sujeta_detraccion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property porcentaje_detraccion() As Decimal
        Get
            Return m_porcentaje_detraccion
        End Get
        Set(ByVal value As Decimal)
            m_porcentaje_detraccion = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property numero_detraccion() As String
        Get
            Return m_numero_detraccion
        End Get
        Set(ByVal value As String)
            m_numero_detraccion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_detraccion() As Date
        Get
            Return m_fecha_detraccion
        End Get
        Set(ByVal value As Date)
            m_fecha_detraccion = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property origen() As String
        Get
            Return m_origen
        End Get
        Set(ByVal value As String)
            m_origen = IIf(String.IsNullOrEmpty(value), "VEN", value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "V", value)
        End Set
    End Property

    Public Property ubicacion_custodia() As String
        Get
            Return m_ubicacion_custodia
        End Get
        Set(ByVal value As String)
            m_ubicacion_custodia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property usuario_custodia() As String
        Get
            Return m_usuario_custodia
        End Get
        Set(ByVal value As String)
            m_usuario_custodia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_custodia() As Date
        Get
            Return m_fecha_custodia
        End Get
        Set(ByVal value As Date)
            m_fecha_custodia = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property indica_referencia() As Boolean
        Get
            Return m_indica_referencia
        End Get
        Set(ByVal value As Boolean)
            m_indica_referencia = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property referencia_tipo() As String
        Get
            Return m_referencia_tipo
        End Get
        Set(ByVal value As String)
            m_referencia_tipo = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property referencia_serie() As String
        Get
            Return m_referencia_serie
        End Get
        Set(ByVal value As String)
            m_referencia_serie = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property referencia_numero() As String
        Get
            Return m_referencia_numero
        End Get
        Set(ByVal value As String)
            m_referencia_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property referencia_fecha() As Date
        Get
            Return m_referencia_fecha
        End Get
        Set(ByVal value As Date)
            m_referencia_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property indica_impreso() As String
        Get
            Return m_indica_impreso
        End Get
        Set(ByVal value As String)
            m_indica_impreso = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_exportacion() As String
        Get
            Return m_indica_exportacion
        End Get
        Set(ByVal value As String)
            m_indica_exportacion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_migrado() As String
        Get
            Return m_indica_migrado
        End Get
        Set(ByVal value As String)
            m_indica_migrado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property usuario_registro() As String
        Get
            Return m_usuario_registro
        End Get
        Set(ByVal value As String)
            m_usuario_registro = IIf(String.IsNullOrEmpty(value), MyUsuario.usuario, value)
        End Set
    End Property

    Public Property fecha_registro() As Date
        Get
            Return m_fecha_registro
        End Get
        Set(ByVal value As DateTime)
            m_fecha_registro = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property usuario_modifica() As String
        Get
            Return m_usuario_modifica
        End Get
        Set(ByVal value As String)
            m_usuario_modifica = IIf(String.IsNullOrEmpty(value), MyUsuario.usuario, value)
        End Set
    End Property

    Public Property fecha_modifica() As Date
        Get
            Return m_fecha_modifica
        End Get
        Set(ByVal value As Date)
            m_fecha_modifica = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property lista_precio() As String
        Get
            Return m_lista_precio
        End Get
        Set(ByVal value As String)
            m_lista_precio = IIf(String.IsNullOrEmpty(value), "LP0000000000", value)
        End Set
    End Property

    Public Property centro_distribucion() As String
        Get
            Return m_centro_distribucion
        End Get
        Set(ByVal value As String)
            m_centro_distribucion = IIf(String.IsNullOrEmpty(value), "01", value)
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

    Public Property tipo_operacion_nombre() As String
        Get
            Return m_tipo_operacion_nombre
        End Get
        Set(ByVal value As String)
            m_tipo_operacion_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_documento() As String
        Get
            Return m_tipo_documento
        End Get
        Set(ByVal value As String)
            m_tipo_documento = IIf(String.IsNullOrEmpty(value), "6", value)
        End Set
    End Property

    Public Property nro_documento() As String
        Get
            Return m_nro_documento
        End Get
        Set(ByVal value As String)
            m_nro_documento = IIf(String.IsNullOrEmpty(value), "-", value)
        End Set
    End Property

    Public Property razon_social() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuota_inicial() As Decimal
        Get
            Return m_cuota_inicial
        End Get
        Set(ByVal value As Decimal)
            m_cuota_inicial = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property cuota_inicial_pagada() As Decimal
        Get
            Return m_cuota_inicial_pagada
        End Get
        Set(ByVal value As Decimal)
            m_cuota_inicial_pagada = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

End Class
