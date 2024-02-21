Public Class entProspectoCostoTerceros
    Private m_empresa As String
    Private m_prospecto As String
    Private m_costo As String
    Private m_tipo_proveedor As String
    Private m_tipo_moneda As String
    Private m_cuenta_comercial As String
    Private m_razon_social As String
    Private m_tipo_cambio As Decimal
    Private m_valor_venta_mn As Decimal
    Private m_impuesto_mn As Decimal
    Private m_precio_venta_mn As Decimal
    Private m_valor_venta_me As Decimal
    Private m_impuesto_me As Decimal
    Private m_precio_venta_me As Decimal
    Private m_tipo_impuesto As String
    Private m_comentario As String
    Private m_cotizacion_proveedor As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_proveedor_existe As Boolean

    Public Sub New()
        Me.empresa = Nothing
        Me.prospecto = Nothing
        Me.costo = Nothing
        Me.tipo_proveedor = Nothing
        Me.tipo_moneda = Nothing
        Me.cuenta_comercial = Nothing
        Me.razon_social = Nothing
        Me.tipo_cambio = Nothing
        Me.valor_venta_mn = Nothing
        Me.impuesto_mn = Nothing
        Me.precio_venta_mn = Nothing
        Me.valor_venta_me = Nothing
        Me.impuesto_me = Nothing
        Me.precio_venta_me = Nothing
        Me.tipo_impuesto = Nothing
        Me.comentario = Nothing
        Me.cotizacion_proveedor = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.m_indica_proveedor_existe = Nothing
    End Sub

    Public Sub New(ByVal ProspectoCostoTerceros As entProspectoCostoTerceros)
        With ProspectoCostoTerceros
            m_empresa = .empresa
            m_prospecto = .prospecto
            m_costo = .costo
            m_tipo_proveedor = .tipo_proveedor
            m_tipo_moneda = .tipo_moneda
            m_cuenta_comercial = .cuenta_comercial
            m_razon_social = .razon_social
            m_tipo_cambio = .tipo_cambio
            m_valor_venta_mn = .valor_venta_mn
            m_impuesto_mn = .impuesto_mn
            m_precio_venta_mn = .precio_venta_mn
            m_valor_venta_me = .valor_venta_me
            m_impuesto_me = .impuesto_me
            m_precio_venta_me = .precio_venta_me
            m_tipo_impuesto = .tipo_impuesto
            m_comentario = .comentario
            m_cotizacion_proveedor = .cotizacion_proveedor
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_indica_proveedor_existe = .indica_proveedor_existe
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

    Public Property prospecto() As String
        Get
            Return m_prospecto
        End Get
        Set(ByVal value As String)
            m_prospecto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property costo() As String
        Get
            Return m_costo
        End Get
        Set(ByVal value As String)
            m_costo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_proveedor() As String
        Get
            Return m_tipo_proveedor
        End Get
        Set(ByVal value As String)
            m_tipo_proveedor = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_venta_mn() As Decimal
        Get
            Return m_valor_venta_mn
        End Get
        Set(ByVal value As Decimal)
            m_valor_venta_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property impuesto_mn() As Decimal
        Get
            Return m_impuesto_mn
        End Get
        Set(ByVal value As Decimal)
            m_impuesto_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_venta_mn() As Decimal
        Get
            Return m_precio_venta_mn
        End Get
        Set(ByVal value As Decimal)
            m_precio_venta_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_venta_me() As Decimal
        Get
            Return m_valor_venta_me
        End Get
        Set(ByVal value As Decimal)
            m_valor_venta_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property impuesto_me() As Decimal
        Get
            Return m_impuesto_me
        End Get
        Set(ByVal value As Decimal)
            m_impuesto_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_venta_me() As Decimal
        Get
            Return m_precio_venta_me
        End Get
        Set(ByVal value As Decimal)
            m_precio_venta_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property tipo_impuesto() As String
        Get
            Return m_tipo_impuesto
        End Get
        Set(ByVal value As String)
            m_tipo_impuesto = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property cotizacion_proveedor() As String
        Get
            Return m_cotizacion_proveedor
        End Get
        Set(ByVal value As String)
            m_cotizacion_proveedor = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property indica_proveedor_existe() As Boolean
        Get
            Return m_indica_proveedor_existe
        End Get
        Set(ByVal value As Boolean)
            m_indica_proveedor_existe = IIf(String.IsNullOrEmpty(value), True, value)
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
            m_fecha_registro = IIf(value = "#12:00:00 AM#", FechaNulo, value)
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
            m_fecha_modifica = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

End Class
