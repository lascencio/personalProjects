Public Class entCompra
    Private m_empresa As String
    Private m_compra As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_asiento_tipo As String
    Private m_asiento_numero As String
    Private m_asiento_fecha As Date
    Private m_cuenta_comercial As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_vencimiento As Date
    Private m_glosa As String
    Private m_tipo_cambio As Decimal
    Private m_tipo_moneda As String
    Private m_adquisicion_1_base_origen As Decimal
    Private m_adquisicion_1_igv_origen As Decimal
    Private m_adquisicion_2_base_origen As Decimal
    Private m_adquisicion_2_igv_origen As Decimal
    Private m_adquisicion_3_base_origen As Decimal
    Private m_adquisicion_3_igv_origen As Decimal
    Private m_adquisicion_no_gravada_origen As Decimal
    Private m_isc_origen As Decimal
    Private m_otros_tributos_origen As Decimal
    Private m_importe_total_origen As Decimal
    Private m_adquisicion_1_base_mn As Decimal
    Private m_adquisicion_1_igv_mn As Decimal
    Private m_adquisicion_2_base_mn As Decimal
    Private m_adquisicion_2_igv_mn As Decimal
    Private m_adquisicion_3_base_mn As Decimal
    Private m_adquisicion_3_igv_mn As Decimal
    Private m_adquisicion_no_gravada_mn As Decimal
    Private m_isc_mn As Decimal
    Private m_otros_tributos_mn As Decimal
    Private m_importe_total_mn As Decimal
    Private m_adquisicion_1_base_me As Decimal
    Private m_adquisicion_1_igv_me As Decimal
    Private m_adquisicion_2_base_me As Decimal
    Private m_adquisicion_2_igv_me As Decimal
    Private m_adquisicion_3_base_me As Decimal
    Private m_adquisicion_3_igv_me As Decimal
    Private m_adquisicion_no_gravada_me As Decimal
    Private m_isc_me As Decimal
    Private m_otros_tributos_me As Decimal
    Private m_importe_total_me As Decimal
    Private m_dependencia_aduanera As String
    Private m_ano_emision_aduana As String
    Private m_numero_detraccion As String
    Private m_fecha_detraccion As Date
    Private m_porcentaje_detraccion As Decimal
    Private m_condicion_pago As String
    Private m_fecha_ultimo_pago As Date
    Private m_importe_saldo As Decimal
    Private m_letra As String
    Private m_grupo_liquidaciones As String
    Private m_liquidacion As String
    Private m_guia_remitente As String
    Private m_guia_transportista As String
    Private m_orden_compra As String
    Private m_usuario_recepcion As String
    Private m_fecha_recepcion As Date
    Private m_ubicacion_custodia As String
    Private m_usuario_custodia As String
    Private m_fecha_custodia As Date
    Private m_origen As String
    Private m_estado As String
    Private m_indica_contabilizado As String
    Private m_indica_rendicion As String
    Private m_rendicion_cuenta_contable As String
    Private m_rendicion_cuenta_corriente As String
    Private m_rendicion_comprobante_tipo As String
    Private m_rendicion_comprobante_serie As String
    Private m_rendicion_comprobante_numero As String
    Private m_control_ejercicio As String
    Private m_control_mes As String
    Private m_control_secuencia As String
    Private m_referencia_tipo As String
    Private m_referencia_serie As String
    Private m_referencia_numero As String
    Private m_referencia_fecha As Date
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date
    Private m_indica_detraccion As Boolean
    Private m_indica_referencia As Boolean

    Public Sub New()
        Me.empresa = Nothing
        Me.compra = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.asiento_tipo = Nothing
        Me.asiento_numero = Nothing
        Me.asiento_fecha = Nothing
        Me.cuenta_comercial = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_vencimiento = Nothing
        Me.glosa = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.adquisicion_1_base_origen = Nothing
        Me.adquisicion_1_igv_origen = Nothing
        Me.adquisicion_2_base_origen = Nothing
        Me.adquisicion_2_igv_origen = Nothing
        Me.adquisicion_3_base_origen = Nothing
        Me.adquisicion_3_igv_origen = Nothing
        Me.adquisicion_no_gravada_origen = Nothing
        Me.isc_origen = Nothing
        Me.otros_tributos_origen = Nothing
        Me.importe_total_origen = Nothing
        Me.adquisicion_1_base_mn = Nothing
        Me.adquisicion_1_igv_mn = Nothing
        Me.adquisicion_2_base_mn = Nothing
        Me.adquisicion_2_igv_mn = Nothing
        Me.adquisicion_3_base_mn = Nothing
        Me.adquisicion_3_igv_mn = Nothing
        Me.adquisicion_no_gravada_mn = Nothing
        Me.isc_mn = Nothing
        Me.otros_tributos_mn = Nothing
        Me.importe_total_mn = Nothing
        Me.adquisicion_1_base_me = Nothing
        Me.adquisicion_1_igv_me = Nothing
        Me.adquisicion_2_base_me = Nothing
        Me.adquisicion_2_igv_me = Nothing
        Me.adquisicion_3_base_me = Nothing
        Me.adquisicion_3_igv_me = Nothing
        Me.adquisicion_no_gravada_me = Nothing
        Me.isc_me = Nothing
        Me.otros_tributos_me = Nothing
        Me.importe_total_me = Nothing
        Me.dependencia_aduanera = Nothing
        Me.ano_emision_aduana = Nothing
        Me.numero_detraccion = Nothing
        Me.fecha_detraccion = Nothing
        Me.porcentaje_detraccion = Nothing
        Me.condicion_pago = Nothing
        Me.fecha_ultimo_pago = Nothing
        Me.importe_saldo = Nothing
        Me.letra = Nothing
        Me.grupo_liquidaciones = Nothing
        Me.liquidacion = Nothing
        Me.guia_remitente = Nothing
        Me.guia_transportista = Nothing
        Me.orden_compra = Nothing
        Me.usuario_recepcion = Nothing
        Me.fecha_recepcion = Nothing
        Me.ubicacion_custodia = Nothing
        Me.usuario_custodia = Nothing
        Me.fecha_custodia = Nothing
        Me.origen = Nothing
        Me.estado = Nothing
        Me.indica_contabilizado = Nothing
        Me.indica_rendicion = Nothing
        Me.rendicion_cuenta_contable = Nothing
        Me.rendicion_cuenta_corriente = Nothing
        Me.rendicion_comprobante_tipo = Nothing
        Me.rendicion_comprobante_serie = Nothing
        Me.rendicion_comprobante_numero = Nothing
        Me.control_ejercicio = Nothing
        Me.control_mes = Nothing
        Me.control_secuencia = Nothing
        Me.referencia_tipo = Nothing
        Me.referencia_serie = Nothing
        Me.referencia_numero = Nothing
        Me.referencia_fecha = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
        Me.indica_detraccion = Nothing
        Me.indica_referencia = Nothing
    End Sub

    Public Sub New(ByVal Compra As entCompra)

        With Compra
            m_empresa = .empresa
            m_compra = .compra
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_asiento_tipo = .asiento_tipo
            m_asiento_numero = .asiento_numero
            m_asiento_fecha = .asiento_fecha
            m_cuenta_comercial = .cuenta_comercial
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_vencimiento = .comprobante_vencimiento
            m_glosa = .glosa
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_adquisicion_1_base_origen = .adquisicion_1_base_origen
            m_adquisicion_1_igv_origen = .adquisicion_1_igv_origen
            m_adquisicion_2_base_origen = .adquisicion_2_base_origen
            m_adquisicion_2_igv_origen = .adquisicion_2_igv_origen
            m_adquisicion_3_base_origen = .adquisicion_3_base_origen
            m_adquisicion_3_igv_origen = .adquisicion_3_igv_origen
            m_adquisicion_no_gravada_origen = .adquisicion_no_gravada_origen
            m_isc_origen = .isc_origen
            m_otros_tributos_origen = .otros_tributos_origen
            m_importe_total_origen = .importe_total_origen
            m_adquisicion_1_base_mn = .adquisicion_1_base_mn
            m_adquisicion_1_igv_mn = .adquisicion_1_igv_mn
            m_adquisicion_2_base_mn = .adquisicion_2_base_mn
            m_adquisicion_2_igv_mn = .adquisicion_2_igv_mn
            m_adquisicion_3_base_mn = .adquisicion_3_base_mn
            m_adquisicion_3_igv_mn = .adquisicion_3_igv_mn
            m_adquisicion_no_gravada_mn = .adquisicion_no_gravada_mn
            m_isc_mn = .isc_mn
            m_otros_tributos_mn = .otros_tributos_mn
            m_importe_total_mn = .importe_total_mn
            m_adquisicion_1_base_me = .adquisicion_1_base_me
            m_adquisicion_1_igv_me = .adquisicion_1_igv_me
            m_adquisicion_2_base_me = .adquisicion_2_base_me
            m_adquisicion_2_igv_me = .adquisicion_2_igv_me
            m_adquisicion_3_base_me = .adquisicion_3_base_me
            m_adquisicion_3_igv_me = .adquisicion_3_igv_me
            m_adquisicion_no_gravada_me = .adquisicion_no_gravada_me
            m_isc_me = .isc_me
            m_otros_tributos_me = .otros_tributos_me
            m_importe_total_me = .importe_total_me
            m_dependencia_aduanera = .dependencia_aduanera
            m_ano_emision_aduana = .ano_emision_aduana
            m_numero_detraccion = .numero_detraccion
            m_fecha_detraccion = .fecha_detraccion
            m_porcentaje_detraccion = .porcentaje_detraccion
            m_condicion_pago = .condicion_pago
            m_fecha_ultimo_pago = .fecha_ultimo_pago
            m_importe_saldo = .importe_saldo
            m_letra = .letra
            m_grupo_liquidaciones = .grupo_liquidaciones
            m_liquidacion = .liquidacion
            m_guia_remitente = .guia_remitente
            m_guia_transportista = .guia_transportista
            m_orden_compra = .orden_compra
            m_usuario_recepcion = .usuario_recepcion
            m_fecha_recepcion = .fecha_recepcion
            m_ubicacion_custodia = .ubicacion_custodia
            m_usuario_custodia = .usuario_custodia
            m_fecha_custodia = .fecha_custodia
            m_origen = .origen
            m_estado = .estado
            m_indica_contabilizado = .indica_contabilizado
            m_indica_rendicion = .indica_rendicion
            m_rendicion_cuenta_contable = .rendicion_cuenta_contable
            m_rendicion_cuenta_corriente = .rendicion_cuenta_corriente
            m_rendicion_comprobante_tipo = .rendicion_comprobante_tipo
            m_rendicion_comprobante_serie = .rendicion_comprobante_serie
            m_rendicion_comprobante_numero = .rendicion_comprobante_numero
            m_control_ejercicio = .control_ejercicio
            m_control_mes = .control_mes
            m_control_secuencia = .control_secuencia
            m_referencia_tipo = .referencia_tipo
            m_referencia_serie = .referencia_serie
            m_referencia_numero = .referencia_numero
            m_referencia_fecha = .referencia_fecha
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
            m_indica_detraccion = .indica_detraccion
            m_indica_referencia = .indica_referencia
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

    Public Property compra() As String
        Get
            Return m_compra
        End Get
        Set(ByVal value As String)
            m_compra = value
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

    Public Property glosa() As String
        Get
            Return m_glosa
        End Get
        Set(ByVal value As String)
            m_glosa = value
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

    Public Property adquisicion_1_base_origen() As Decimal
        Get
            Return m_adquisicion_1_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_origen() As Decimal
        Get
            Return m_adquisicion_1_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_origen() As Decimal
        Get
            Return m_adquisicion_2_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_origen() As Decimal
        Get
            Return m_adquisicion_2_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_origen() As Decimal
        Get
            Return m_adquisicion_3_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_origen() As Decimal
        Get
            Return m_adquisicion_3_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_origen() As Decimal
        Get
            Return m_adquisicion_no_gravada_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property otros_tributos_origen() As Decimal
        Get
            Return m_otros_tributos_origen
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property adquisicion_1_base_mn() As Decimal
        Get
            Return m_adquisicion_1_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_mn() As Decimal
        Get
            Return m_adquisicion_1_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_mn() As Decimal
        Get
            Return m_adquisicion_2_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_mn() As Decimal
        Get
            Return m_adquisicion_2_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_mn() As Decimal
        Get
            Return m_adquisicion_3_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_mn() As Decimal
        Get
            Return m_adquisicion_3_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_mn() As Decimal
        Get
            Return m_adquisicion_no_gravada_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_mn = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property otros_tributos_mn() As Decimal
        Get
            Return m_otros_tributos_mn
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_mn = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property adquisicion_1_base_me() As Decimal
        Get
            Return m_adquisicion_1_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_me() As Decimal
        Get
            Return m_adquisicion_1_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_me() As Decimal
        Get
            Return m_adquisicion_2_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_me() As Decimal
        Get
            Return m_adquisicion_2_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_me() As Decimal
        Get
            Return m_adquisicion_3_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_me() As Decimal
        Get
            Return m_adquisicion_3_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_me() As Decimal
        Get
            Return m_adquisicion_no_gravada_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property otros_tributos_me() As Decimal
        Get
            Return m_otros_tributos_me
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property dependencia_aduanera() As String
        Get
            Return m_dependencia_aduanera
        End Get
        Set(ByVal value As String)
            m_dependencia_aduanera = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ano_emision_aduana() As String
        Get
            Return m_ano_emision_aduana
        End Get
        Set(ByVal value As String)
            m_ano_emision_aduana = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property indica_detraccion() As Boolean
        Get
            Return m_indica_detraccion
        End Get
        Set(ByVal value As Boolean)
            m_indica_detraccion = IIf(String.IsNullOrEmpty(value), False, value)
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

    Public Property porcentaje_detraccion() As Decimal
        Get
            Return m_porcentaje_detraccion
        End Get
        Set(ByVal value As Decimal)
            m_porcentaje_detraccion = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property letra() As String
        Get
            Return m_letra
        End Get
        Set(ByVal value As String)
            m_letra = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property grupo_liquidaciones() As String
        Get
            Return m_grupo_liquidaciones
        End Get
        Set(ByVal value As String)
            m_grupo_liquidaciones = IIf(String.IsNullOrEmpty(value), Left(CUO_Nulo, 10), value)
        End Set
    End Property

    Public Property liquidacion() As String
        Get
            Return m_liquidacion
        End Get
        Set(ByVal value As String)
            m_liquidacion = IIf(String.IsNullOrEmpty(value), Left(CUO_Nulo, 10), value)
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

    Public Property orden_compra() As String
        Get
            Return m_orden_compra
        End Get
        Set(ByVal value As String)
            m_orden_compra = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property usuario_recepcion() As String
        Get
            Return m_usuario_recepcion
        End Get
        Set(ByVal value As String)
            m_usuario_recepcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property origen() As String
        Get
            Return m_origen
        End Get
        Set(ByVal value As String)
            m_origen = IIf(String.IsNullOrEmpty(value), "SIS", value)
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

    Public Property indica_contabilizado() As String
        Get
            Return m_indica_contabilizado
        End Get
        Set(ByVal value As String)
            m_indica_contabilizado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_rendicion() As String
        Get
            Return m_indica_rendicion
        End Get
        Set(ByVal value As String)
            m_indica_rendicion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property rendicion_cuenta_contable() As String
        Get
            Return m_rendicion_cuenta_contable
        End Get
        Set(ByVal value As String)
            m_rendicion_cuenta_contable = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_cuenta_corriente() As String
        Get
            Return m_rendicion_cuenta_corriente
        End Get
        Set(ByVal value As String)
            m_rendicion_cuenta_corriente = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_comprobante_tipo() As String
        Get
            Return m_rendicion_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_rendicion_comprobante_tipo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_comprobante_serie() As String
        Get
            Return m_rendicion_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_rendicion_comprobante_serie = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_comprobante_numero() As String
        Get
            Return m_rendicion_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_rendicion_comprobante_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property control_ejercicio() As String
        Get
            Return m_control_ejercicio
        End Get
        Set(ByVal value As String)
            m_control_ejercicio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property control_mes() As String
        Get
            Return m_control_mes
        End Get
        Set(ByVal value As String)
            m_control_mes = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property control_secuencia() As String
        Get
            Return m_control_secuencia
        End Get
        Set(ByVal value As String)
            m_control_secuencia = IIf(String.IsNullOrEmpty(value), Space(1), value)
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
        Set(ByVal value As DateTime)
            m_fecha_registro = IIf(value.Ticks = 0, FechaNulo, value)
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
            m_fecha_modifica = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

End Class
