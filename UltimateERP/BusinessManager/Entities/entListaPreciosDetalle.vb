Public Class entListaPreciosDetalle
    Private m_empresa As String
    Private m_lista_precios As String
    Private m_producto As String
    Private m_comentario As String
    Private m_valor_venta_mn As Single
    Private m_valor_venta_me As Single
    Private m_descuento_1 As Single
    Private m_descuento_2 As Single
    Private m_descuento_3 As Single
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.lista_precios = Nothing
        Me.producto = Nothing
        Me.comentario = Nothing
        Me.valor_venta_mn = Nothing
        Me.valor_venta_me = Nothing
        Me.descuento_1 = Nothing
        Me.descuento_2 = Nothing
        Me.descuento_3 = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal ListaPreciosDetalle As entListaPreciosDetalle)

        With ListaPreciosDetalle
            m_empresa = .empresa
            m_lista_precios = .lista_precios
            m_producto = .producto
            m_comentario = .comentario
            m_valor_venta_mn = .valor_venta_mn
            m_valor_venta_me = .valor_venta_me
            m_descuento_1 = .descuento_1
            m_descuento_2 = .descuento_2
            m_descuento_3 = .descuento_3
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

    Public Property lista_precios() As String
        Get
            Return m_lista_precios
        End Get
        Set(ByVal value As String)
            m_lista_precios = value
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

    Public Property comentario() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property valor_venta_mn() As Single
        Get
            Return m_valor_venta_mn
        End Get
        Set(ByVal value As Single)
            m_valor_venta_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_venta_me() As Single
        Get
            Return m_valor_venta_me
        End Get
        Set(ByVal value As Single)
            m_valor_venta_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_1() As Single
        Get
            Return m_descuento_1
        End Get
        Set(ByVal value As Single)
            m_descuento_1 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_2() As Single
        Get
            Return m_descuento_2
        End Get
        Set(ByVal value As Single)
            m_descuento_2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property descuento_3() As Single
        Get
            Return m_descuento_3
        End Get
        Set(ByVal value As Single)
            m_descuento_3 = IIf(String.IsNullOrEmpty(value), 0, value)
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
