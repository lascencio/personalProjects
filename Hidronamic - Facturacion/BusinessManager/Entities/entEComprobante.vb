Public Class entEComprobante
    Private m_empresa As String
    Private m_cuenta_comercial As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_vencimiento As Date
    Private m_ejercicio As String
    Private m_mes As String
    Private m_dia As String
    Private m_tipo_cambio As Decimal
    Private m_moneda As String
    Private m_valor_exportacion As Decimal
    Private m_base_imponible_gravada As Decimal
    Private m_importe_exonerado As Decimal
    Private m_importe_inafecto As Decimal
    Private m_isc As Decimal
    Private m_igv As Decimal
    Private m_ipm As Decimal
    Private m_base_imponible_gravada2 As Decimal
    Private m_igv2 As Decimal
    Private m_otros_tributos As Decimal
    Private m_descuento_global As Decimal
    Private m_importe_total As Decimal
    Private m_referencia_tipo As String
    Private m_referencia_serie As String
    Private m_referencia_numero As String
    Private m_referencia_fecha As Date
    Private m_nombre_archivo As String
    Private m_usuario_envio As String
    Private m_fecha_envio As Date
    Private m_estado_ticket As String
    Private m_estado_comprobante As String
    Private m_email_contacto As String
    Private m_email_facturacion As String
    Private m_usuario_descarga_web As String
    Private m_fecha_descarga_web As Date
    Private m_venta As String
    Private m_razon_social As String
    Private m_mensaje As String
    Private m_digest_value As String
    Private m_signature_value As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.cuenta_comercial = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_vencimiento = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.dia = Nothing
        Me.tipo_cambio = Nothing
        Me.moneda = Nothing
        Me.valor_exportacion = Nothing
        Me.base_imponible_gravada = Nothing
        Me.importe_exonerado = Nothing
        Me.importe_inafecto = Nothing
        Me.isc = Nothing
        Me.igv = Nothing
        Me.ipm = Nothing
        Me.base_imponible_gravada2 = Nothing
        Me.igv2 = Nothing
        Me.otros_tributos = Nothing
        Me.descuento_global = Nothing
        Me.importe_total = Nothing
        Me.referencia_tipo = Nothing
        Me.referencia_serie = Nothing
        Me.referencia_numero = Nothing
        Me.referencia_fecha = Nothing
        Me.nombre_archivo = Nothing
        Me.usuario_envio = Nothing
        Me.fecha_envio = Nothing
        Me.estado_ticket = Nothing
        Me.estado_comprobante = Nothing
        Me.email_contacto = Nothing
        Me.email_facturacion = Nothing
        Me.usuario_descarga_web = Nothing
        Me.fecha_descarga_web = Nothing
        Me.venta = Nothing
        Me.razon_social = Nothing
        Me.mensaje = Nothing
        Me.digest_value = Nothing
        Me.signature_value = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal Comprobante As entEComprobante)
        With Comprobante
            m_empresa = .empresa
            m_cuenta_comercial = .cuenta_comercial
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_vencimiento = .comprobante_vencimiento
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_dia = .dia
            m_tipo_cambio = .tipo_cambio
            m_moneda = .moneda
            m_valor_exportacion = .valor_exportacion
            m_base_imponible_gravada = .base_imponible_gravada
            m_importe_exonerado = .importe_exonerado
            m_importe_inafecto = .importe_inafecto
            m_isc = .isc
            m_igv = .igv
            m_ipm = .ipm
            m_base_imponible_gravada2 = .base_imponible_gravada2
            m_igv2 = .igv2
            m_otros_tributos = .otros_tributos
            m_descuento_global = .descuento_global
            m_importe_total = .importe_total
            m_referencia_tipo = .referencia_tipo
            m_referencia_serie = .referencia_serie
            m_referencia_numero = .referencia_numero
            m_referencia_fecha = .referencia_fecha
            m_nombre_archivo = .nombre_archivo
            m_usuario_envio = .usuario_envio
            m_fecha_envio = .fecha_envio
            m_estado_ticket = .estado_ticket
            m_estado_comprobante = .estado_comprobante
            m_email_contacto = .email_contacto
            m_email_facturacion = .email_facturacion
            m_usuario_descarga_web = .usuario_descarga_web
            m_fecha_descarga_web = .fecha_descarga_web
            m_venta = .venta
            m_razon_social = .razon_social
            m_mensaje = .mensaje
            m_digest_value = .digest_value
            m_signature_value = .signature_value
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

    Public Property comprobante_tipo() As String
        Get
            Return m_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_comprobante_tipo = value
        End Set
    End Property

    Public Property comprobante_serie() As String
        Get
            Return m_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_comprobante_serie = value
        End Set
    End Property

    Public Property comprobante_numero() As String
        Get
            Return m_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_comprobante_numero = value
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

    Public Property dia() As String
        Get
            Return m_dia
        End Get
        Set(ByVal value As String)
            m_dia = value
        End Set
    End Property

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
        End Set
    End Property

    Public Property moneda() As String
        Get
            Return m_moneda
        End Get
        Set(ByVal value As String)
            m_moneda = IIf(String.IsNullOrEmpty(value), "S/.", value)
        End Set
    End Property

    Public Property valor_exportacion() As Decimal
        Get
            Return m_valor_exportacion
        End Get
        Set(ByVal value As Decimal)
            m_valor_exportacion = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada() As Decimal
        Get
            Return m_base_imponible_gravada
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado() As Decimal
        Get
            Return m_importe_exonerado
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto() As Decimal
        Get
            Return m_importe_inafecto
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc() As Decimal
        Get
            Return m_isc
        End Get
        Set(ByVal value As Decimal)
            m_isc = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv() As Decimal
        Get
            Return m_igv
        End Get
        Set(ByVal value As Decimal)
            m_igv = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm() As Decimal
        Get
            Return m_ipm
        End Get
        Set(ByVal value As Decimal)
            m_ipm = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2() As Decimal
        Get
            Return m_base_imponible_gravada2
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2() As Decimal
        Get
            Return m_igv2
        End Get
        Set(ByVal value As Decimal)
            m_igv2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos() As Decimal
        Get
            Return m_otros_tributos
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_global() As Decimal
        Get
            Return m_descuento_global
        End Get
        Set(ByVal value As Decimal)
            m_descuento_global = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total() As Decimal
        Get
            Return m_importe_total
        End Get
        Set(ByVal value As Decimal)
            m_importe_total = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property nombre_archivo() As String
        Get
            Return m_nombre_archivo
        End Get
        Set(ByVal value As String)
            m_nombre_archivo = value
        End Set
    End Property

    Public Property usuario_envio() As String
        Get
            Return m_usuario_envio
        End Get
        Set(ByVal value As String)
            m_usuario_envio = value
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

    Public Property estado_ticket() As String
        Get
            Return m_estado_ticket
        End Get
        Set(ByVal value As String)
            m_estado_ticket = IIf(String.IsNullOrEmpty(value), "0", value)
        End Set
    End Property

    Public Property estado_comprobante() As String
        Get
            Return m_estado_comprobante
        End Get
        Set(ByVal value As String)
            m_estado_comprobante = IIf(String.IsNullOrEmpty(value), "0001", value)
        End Set
    End Property

    Public Property email_contacto() As String
        Get
            Return m_email_contacto
        End Get
        Set(ByVal value As String)
            m_email_contacto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property email_facturacion() As String
        Get
            Return m_email_facturacion
        End Get
        Set(ByVal value As String)
            m_email_facturacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property usuario_descarga_web() As String
        Get
            Return m_usuario_descarga_web
        End Get
        Set(ByVal value As String)
            m_usuario_descarga_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_descarga_web() As Date
        Get
            Return m_fecha_descarga_web
        End Get
        Set(ByVal value As Date)
            m_fecha_descarga_web = IIf(value.Ticks = 0, FechaNulo, value)
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

    Public Property razon_social() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property mensaje() As String
        Get
            Return m_mensaje
        End Get
        Set(ByVal value As String)
            m_mensaje = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property digest_value() As String
        Get
            Return m_digest_value
        End Get
        Set(ByVal value As String)
            m_digest_value = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property signature_value() As String
        Get
            Return m_signature_value
        End Get
        Set(ByVal value As String)
            m_signature_value = IIf(String.IsNullOrEmpty(value), Space(1), value)
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
