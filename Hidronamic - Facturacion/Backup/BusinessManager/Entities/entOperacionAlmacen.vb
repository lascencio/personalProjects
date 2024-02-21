Public Class entOperacionAlmacen
    Private m_empresa As String
    Private m_almacen As String
    Private m_operacion As String
    Private m_tipo_operacion As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_fecha_operacion As Date
    Private m_comentario As String
    Private m_tipo_es As String
    Private m_referencia_cuenta_comercial As String
    Private m_referencia_tipo As String
    Private m_referencia_serie As String
    Private m_referencia_numero As String
    Private m_referencia_fecha As Date
    Private m_referencia_tipo_moneda As String
    Private m_referencia_importe_total As Decimal
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.almacen = Nothing
        Me.operacion = Nothing
        Me.tipo_operacion = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.fecha_operacion = Nothing
        Me.comentario = Nothing
        Me.tipo_es = Nothing
        Me.referencia_cuenta_comercial = Nothing
        Me.referencia_tipo = Nothing
        Me.referencia_serie = Nothing
        Me.referencia_numero = Nothing
        Me.referencia_fecha = Nothing
        Me.referencia_tipo_moneda = Nothing
        Me.referencia_importe_total = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal OperacionAlmacen As entOperacionAlmacen)

        With OperacionAlmacen
            m_empresa = .empresa
            m_almacen = .almacen
            m_operacion = .operacion
            m_tipo_operacion = .tipo_operacion
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_fecha_operacion = .fecha_operacion
            m_comentario = .comentario
            m_tipo_es = .tipo_es
            m_referencia_cuenta_comercial = .referencia_cuenta_comercial
            m_referencia_tipo = .referencia_tipo
            m_referencia_serie = .referencia_serie
            m_referencia_numero = .referencia_numero
            m_referencia_fecha = .referencia_fecha
            m_referencia_tipo_moneda = .referencia_tipo_moneda
            m_referencia_importe_total = .referencia_importe_total
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

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = value
        End Set
    End Property

    Public Property operacion() As String
        Get
            Return m_operacion
        End Get
        Set(ByVal value As String)
            m_operacion = value
        End Set
    End Property

    Public Property tipo_operacion() As String
        Get
            Return m_tipo_operacion
        End Get
        Set(ByVal value As String)
            m_tipo_operacion = value
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

    Public Property fecha_operacion() As Date
        Get
            Return m_fecha_operacion
        End Get
        Set(ByVal value As Date)
            m_fecha_operacion = value
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

    Public Property tipo_es() As String
        Get
            Return m_tipo_es
        End Get
        Set(ByVal value As String)
            m_tipo_es = IIf(String.IsNullOrEmpty(value), "S", value)
        End Set
    End Property

    Public Property referencia_cuenta_comercial() As String
        Get
            Return m_referencia_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_referencia_cuenta_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property referencia_tipo() As String
        Get
            Return m_referencia_tipo
        End Get
        Set(ByVal value As String)
            m_referencia_tipo = IIf(String.IsNullOrEmpty(value), "OT", value)
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

    Public Property referencia_tipo_moneda() As String
        Get
            Return m_referencia_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_referencia_tipo_moneda = IIf(String.IsNullOrEmpty(value), "2", value)
        End Set
    End Property

    Public Property referencia_importe_total() As Decimal
        Get
            Return m_referencia_importe_total
        End Get
        Set(ByVal value As Decimal)
            m_referencia_importe_total = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), Space(1), value)
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
