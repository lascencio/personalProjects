Public Class entOrdenPedidoDetalle

    Private m_empresa As String
    Private m_orden_pedido As String
    Private m_producto As String
    Private m_cantidad As Decimal
    Private m_precio_unitario_me As Decimal
    Private m_precio_unitario_mn As Decimal
    Private m_importe_total_me As Decimal
    Private m_importe_total_mn As Decimal
    Private m_comentario As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.orden_pedido = Nothing
        Me.producto = Nothing
        Me.cantidad = Nothing
        Me.precio_unitario_me = Nothing
        Me.precio_unitario_mn = Nothing
        Me.importe_total_me = Nothing
        Me.importe_total_mn = Nothing
        Me.comentario = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal OrdenPedidoDetalle As entOrdenPedidoDetalle)
        With OrdenPedidoDetalle
            m_empresa = .empresa
            m_orden_pedido = .orden_pedido
            m_producto = .producto
            m_cantidad = .cantidad
            m_precio_unitario_me = .precio_unitario_me
            m_precio_unitario_mn = .precio_unitario_mn
            m_importe_total_me = .importe_total_me
            m_importe_total_mn = .importe_total_mn
            m_comentario = .comentario
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

    Public Property orden_pedido() As String
        Get
            Return m_orden_pedido
        End Get
        Set(ByVal value As String)
            m_orden_pedido = value
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

    Public Property cantidad() As Decimal
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Decimal)
            m_cantidad = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_unitario_me() As Decimal
        Get
            Return m_precio_unitario_me
        End Get
        Set(ByVal value As Decimal)
            m_precio_unitario_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_unitario_mn() As Decimal
        Get
            Return m_precio_unitario_mn
        End Get
        Set(ByVal value As Decimal)
            m_precio_unitario_mn = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property importe_total_me() As Decimal
        Get
            Return m_importe_total_me
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_me = IIf(String.IsNullOrEmpty(value), 0, value)
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
            m_fecha_registro = IIf(String.IsNullOrEmpty(value), Now, value)
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
            m_fecha_modifica = IIf(String.IsNullOrEmpty(value), Now, value)
        End Set
    End Property


End Class
