Public Class entSerie
    Private m_empresa As String
    Private m_producto As String
    Private m_numero_serie As String
    Private m_numero_serie_chasis As String
    Private m_color As String
    Private m_almacen As String
    Private m_referencia_operacion As String
    Private m_fecha_operacion As Date
    Private m_referencia_venta As String
    Private m_fecha_venta As Date
    Private m_referencia_servicio As String
    Private m_fecha_servicio As Date
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.producto = Nothing
        Me.numero_serie = Nothing
        Me.numero_serie_chasis = Nothing
        Me.color = Nothing
        Me.almacen = Nothing
        Me.referencia_operacion = Nothing
        Me.fecha_operacion = Nothing
        Me.referencia_venta = Nothing
        Me.fecha_venta = Nothing
        Me.referencia_servicio = Nothing
        Me.fecha_servicio = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal Serie As entSerie)
        With Serie
            m_empresa = .empresa
            m_producto = .producto
            m_numero_serie = .numero_serie
            m_numero_serie_chasis = .numero_serie_chasis
            m_color = .color
            m_almacen = .almacen
            m_referencia_operacion = .m_referencia_operacion
            m_fecha_operacion = .m_fecha_operacion
            m_referencia_venta = .m_referencia_venta
            m_fecha_venta = .m_fecha_venta
            m_referencia_servicio = .m_referencia_servicio
            m_fecha_servicio = .m_fecha_servicio
            m_estado = .estado
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

    Public Property producto() As String
        Get
            Return m_producto
        End Get
        Set(ByVal value As String)
            m_producto = value
        End Set
    End Property

    Public Property numero_serie() As String
        Get
            Return m_numero_serie
        End Get
        Set(ByVal value As String)
            m_numero_serie = value
        End Set
    End Property

    Public Property numero_serie_chasis() As String
        Get
            Return m_numero_serie_chasis
        End Get
        Set(ByVal value As String)
            m_numero_serie_chasis = value
        End Set
    End Property

    Public Property color() As String
        Get
            Return m_color
        End Get
        Set(ByVal value As String)
            m_color = value
        End Set
    End Property

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = value
        End Set
    End Property

    Public Property referencia_operacion() As String
        Get
            Return m_referencia_operacion
        End Get
        Set(ByVal value As String)
            m_referencia_operacion = CUO_Nulo
        End Set
    End Property

    Public Property fecha_operacion() As Date
        Get
            Return m_fecha_operacion
        End Get
        Set(ByVal value As Date)
            m_fecha_operacion = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property referencia_venta() As String
        Get
            Return m_referencia_venta
        End Get
        Set(ByVal value As String)
            m_referencia_venta = CUO_Nulo
        End Set
    End Property

    Public Property fecha_venta() As Date
        Get
            Return m_fecha_venta
        End Get
        Set(ByVal value As Date)
            m_fecha_venta = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property referencia_servicio() As String
        Get
            Return m_referencia_servicio
        End Get
        Set(ByVal value As String)
            m_referencia_servicio = CUO_Nulo
        End Set
    End Property

    Public Property fecha_servicio() As Date
        Get
            Return m_fecha_servicio
        End Get
        Set(ByVal value As Date)
            m_fecha_servicio = IIf(value.Ticks = 0, FechaNulo, value)
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
