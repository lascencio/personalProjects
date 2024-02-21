Public Class entTipoCambio

    Private m_ejercicio As String
    Private m_mes As String
    Private m_dia As String
    Private m_moneda As String
    Private m_compra As Single
    Private m_venta As Single
    Private m_promedio As Single
    Private m_compra_referencial As Single
    Private m_venta_referencial As Single
    Private m_compra_preferencial As Single
    Private m_venta_preferencial As Single
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.dia = Nothing
        Me.moneda = Nothing
        Me.compra = Nothing
        Me.venta = Nothing
        Me.promedio = Nothing
        Me.compra_referencial = Nothing
        Me.venta_referencial = Nothing
        Me.compra_preferencial = Nothing
        Me.venta_preferencial = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal TipoCambio As entTipoCambio)
        With TipoCambio
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_dia = .dia
            m_moneda = .moneda
            m_compra = .compra
            m_venta = .venta
            m_promedio = .promedio
            m_compra_referencial = .compra_referencial
            m_venta_referencial = .venta_referencial
            m_compra_preferencial = .compra_preferencial
            m_venta_preferencial = .venta_preferencial
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
        End With
    End Sub

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
            m_mes = Strings.Right("00" & value, 2)
        End Set
    End Property

    Public Property dia() As String
        Get
            Return m_dia
        End Get
        Set(ByVal value As String)
            m_dia = Strings.Right("00" & value, 2)
        End Set
    End Property

    Public Property moneda() As String
        Get
            Return m_moneda
        End Get
        Set(ByVal value As String)
            m_moneda = IIf(String.IsNullOrEmpty(value), "2", value)
        End Set
    End Property

    Public Property compra() As Single
        Get
            Return m_compra
        End Get
        Set(ByVal value As Single)
            m_compra = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property venta() As Single
        Get
            Return m_venta
        End Get
        Set(ByVal value As Single)
            m_venta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property promedio() As Single
        Get
            Return m_promedio
        End Get
        Set(ByVal value As Single)
            m_promedio = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property compra_referencial() As Single
        Get
            Return m_compra_referencial
        End Get
        Set(ByVal value As Single)
            m_compra_referencial = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property venta_referencial() As Single
        Get
            Return m_venta_referencial
        End Get
        Set(ByVal value As Single)
            m_venta_referencial = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property compra_preferencial() As Single
        Get
            Return m_compra_preferencial
        End Get
        Set(ByVal value As Single)
            m_compra_preferencial = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property venta_preferencial() As Single
        Get
            Return m_venta_preferencial
        End Get
        Set(ByVal value As Single)
            m_venta_preferencial = IIf(String.IsNullOrEmpty(value), 0, value)
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
