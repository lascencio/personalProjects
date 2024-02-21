Public Class entAsientoContable

    Private m_empresa As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_asiento_tipo As String
    Private m_asiento_numero As String
    Private m_asiento_fecha As Date
    Private m_tipo_moneda As String
    Private m_tipo_cambio As Decimal
    Private m_glosa As String
    Private m_debe_origen As Decimal
    Private m_haber_origen As Decimal
    Private m_debe_mn As Decimal
    Private m_haber_mn As Decimal
    Private m_debe_me As Decimal
    Private m_haber_me As Decimal
    Private m_origen As String
    Private m_movimientos_fecha As Date
    Private m_movimientos_tipo_cambio As Decimal
    Private m_referencia_CUO As String
    Private m_rendicion_anexo As String
    Private m_rendicion_numero As String
    Private m_rendicion_fecha As Date
    Private m_origen_fondos As String
    Private m_cuenta_corriente As String
    Private m_tipo_medio_pago As String
    Private m_documento_pago As String
    Private m_importe_pago As Decimal
    Private m_item_flujo As String
    Private m_estado As String
    Private m_indica_bloqueado As String
    Private m_usuario_bloqueo As String
    Private m_fecha_bloqueo As Date
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.glosa = Nothing
        Me.tipo_moneda = Nothing
        Me.tipo_cambio = Nothing
        Me.asiento_tipo = Nothing
        Me.asiento_numero = Nothing
        Me.asiento_fecha = Nothing
        Me.debe_origen = Nothing
        Me.haber_origen = Nothing
        Me.debe_mn = Nothing
        Me.haber_mn = Nothing
        Me.debe_me = Nothing
        Me.haber_me = Nothing
        Me.origen = Nothing
        Me.movimientos_fecha = Nothing
        Me.movimientos_tipo_cambio = Nothing
        Me.referencia_CUO = Nothing
        Me.rendicion_anexo = Nothing
        Me.rendicion_numero = Nothing
        Me.rendicion_fecha = Nothing
        Me.origen_fondos = Nothing
        Me.cuenta_corriente = Nothing
        Me.tipo_medio_pago = Nothing
        Me.documento_pago = Nothing
        Me.importe_pago = Nothing
        Me.item_flujo = Nothing
        Me.estado = Nothing
        Me.indica_bloqueado = Nothing
        Me.usuario_bloqueo = Nothing
        Me.fecha_bloqueo = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal AsientoContable As entAsientoContable)

        With AsientoContable
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_glosa = .glosa
            m_tipo_moneda = .tipo_moneda
            m_tipo_cambio = .tipo_cambio
            m_asiento_tipo = .asiento_tipo
            m_asiento_numero = .asiento_numero
            m_asiento_fecha = .asiento_fecha
            m_debe_origen = .debe_origen
            m_haber_origen = .haber_origen
            m_debe_mn = .debe_mn
            m_haber_mn = .haber_mn
            m_debe_me = .debe_me
            m_haber_me = .haber_me
            m_origen = .origen
            m_movimientos_fecha = .movimientos_fecha
            m_movimientos_tipo_cambio = .movimientos_tipo_cambio
            m_referencia_CUO = .referencia_CUO
            m_rendicion_anexo = .rendicion_anexo
            m_rendicion_numero = .rendicion_numero
            m_rendicion_fecha = .rendicion_fecha
            m_origen_fondos = .origen_fondos
            m_cuenta_corriente = .cuenta_corriente
            m_tipo_medio_pago = .tipo_medio_pago
            m_documento_pago = .documento_pago
            m_importe_pago = .importe_pago
            m_item_flujo = .item_flujo
            m_estado = .estado
            m_indica_bloqueado = .indica_bloqueado
            m_usuario_bloqueo = .usuario_bloqueo
            m_fecha_bloqueo = .fecha_bloqueo
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
            m_asiento_tipo = value
        End Set
    End Property

    Public Property asiento_numero() As String
        Get
            Return m_asiento_numero
        End Get
        Set(ByVal value As String)
            m_asiento_numero = value
        End Set
    End Property

    Public Property asiento_fecha() As Date
        Get
            Return m_asiento_fecha
        End Get
        Set(ByVal value As Date)
            m_asiento_fecha = value
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

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
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

    Public Property debe_origen() As Decimal
        Get
            Return m_debe_origen
        End Get
        Set(ByVal value As Decimal)
            m_debe_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_origen() As Decimal
        Get
            Return m_haber_origen
        End Get
        Set(ByVal value As Decimal)
            m_haber_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property debe_mn() As Decimal
        Get
            Return m_debe_mn
        End Get
        Set(ByVal value As Decimal)
            m_debe_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_mn() As Decimal
        Get
            Return m_haber_mn
        End Get
        Set(ByVal value As Decimal)
            m_haber_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property debe_me() As Decimal
        Get
            Return m_debe_me
        End Get
        Set(ByVal value As Decimal)
            m_debe_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_me() As Decimal
        Get
            Return m_haber_me
        End Get
        Set(ByVal value As Decimal)
            m_haber_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property movimientos_fecha() As Date
        Get
            Return m_movimientos_fecha
        End Get
        Set(ByVal value As Date)
            m_movimientos_fecha = If(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property movimientos_tipo_cambio() As Decimal
        Get
            Return m_movimientos_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_movimientos_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
        End Set
    End Property

    Public Property referencia_CUO() As String
        Get
            Return m_referencia_CUO
        End Get
        Set(ByVal value As String)
            m_referencia_CUO = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property rendicion_anexo() As String
        Get
            Return m_rendicion_anexo
        End Get
        Set(ByVal value As String)
            m_rendicion_anexo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_numero() As String
        Get
            Return m_rendicion_numero
        End Get
        Set(ByVal value As String)
            m_rendicion_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property rendicion_fecha() As Date
        Get
            Return m_rendicion_fecha
        End Get
        Set(ByVal value As DateTime)
            m_rendicion_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property origen_fondos() As String
        Get
            Return m_origen_fondos
        End Get
        Set(ByVal value As String)
            m_origen_fondos = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_corriente() As String
        Get
            Return m_cuenta_corriente
        End Get
        Set(ByVal value As String)
            m_cuenta_corriente = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_medio_pago() As String
        Get
            Return m_tipo_medio_pago
        End Get
        Set(ByVal value As String)
            m_tipo_medio_pago = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property documento_pago() As String
        Get
            Return m_documento_pago
        End Get
        Set(ByVal value As String)
            m_documento_pago = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property importe_pago() As Decimal
        Get
            Return m_importe_pago
        End Get
        Set(ByVal value As Decimal)
            m_importe_pago = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "A", value)
        End Set
    End Property

    Public Property indica_bloqueado() As String
        Get
            Return m_indica_bloqueado
        End Get
        Set(ByVal value As String)
            m_indica_bloqueado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property usuario_bloqueo() As String
        Get
            Return m_usuario_bloqueo
        End Get
        Set(ByVal value As String)
            m_usuario_bloqueo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_bloqueo() As Date
        Get
            Return m_fecha_bloqueo
        End Get
        Set(ByVal value As Date)
            m_fecha_bloqueo = IIf(value.Ticks = 0, FechaNulo, value)
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
