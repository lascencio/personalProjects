Public Class entOperacionAlmacenDetalle

    Private m_empresa As String
    Private m_almacen As String
    Private m_operacion As String
    Private m_linea As String
    Private m_producto As String
    Private m_cantidad As Decimal
    Private m_precio_unitario As Decimal
    Private m_numero_serie As String
    Private m_numero_lote As String
    Private m_fecha_vencimiento As Date
    Private m_comentario As String
    Private m_tipo_es As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_producto_anterior As String
    Private m_numero_lote_anterior As String
    Private m_cantidad_anterior As Decimal

    Private m_exige_lote As String

    Private m_tipo_operacion As String

    Public Sub New()
        Me.empresa = Nothing
        Me.almacen = Nothing
        Me.operacion = Nothing
        Me.linea = Nothing
        Me.producto = Nothing
        Me.cantidad = Nothing
        Me.precio_unitario = Nothing
        Me.numero_serie = Nothing
        Me.numero_lote = Nothing
        Me.fecha_vencimiento = Nothing
        Me.comentario = Nothing
        Me.tipo_es = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.producto_anterior = Nothing
        Me.numero_lote_anterior = Nothing
        Me.cantidad_anterior = Nothing

        Me.exige_lote = Nothing

        Me.tipo_operacion = Nothing
    End Sub

    Public Sub New(ByVal OperacionAlmacenDetalle As entOperacionAlmacenDetalle)

        With OperacionAlmacenDetalle
            m_empresa = .empresa
            m_almacen = .almacen
            m_operacion = .operacion
            m_linea = .linea
            m_producto = .producto
            m_cantidad = .cantidad
            m_precio_unitario = .precio_unitario
            m_numero_serie = .numero_serie
            m_numero_lote = .numero_lote
            m_fecha_vencimiento = .fecha_vencimiento
            m_comentario = .comentario
            m_tipo_es = .tipo_es
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_producto_anterior = .producto_anterior
            m_numero_lote_anterior = .numero_lote_anterior
            m_cantidad_anterior = .cantidad_anterior

            m_exige_lote = .exige_lote
            m_tipo_operacion = .tipo_operacion
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

    Public Property linea() As String
        Get
            Return m_linea
        End Get
        Set(ByVal value As String)
            m_linea = value
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

    Public Property precio_unitario() As Decimal
        Get
            Return m_precio_unitario
        End Get
        Set(ByVal value As Decimal)
            m_precio_unitario = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property numero_serie() As String
        Get
            Return m_numero_serie
        End Get
        Set(ByVal value As String)
            m_numero_serie = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property numero_lote() As String
        Get
            Return m_numero_lote
        End Get
        Set(ByVal value As String)
            m_numero_lote = IIf(String.IsNullOrEmpty(value), "0000000000", value)
        End Set
    End Property

    Public Property fecha_vencimiento() As Date
        Get
            Return m_fecha_vencimiento
        End Get
        Set(ByVal value As Date)
            m_fecha_vencimiento = IIf(value.Ticks = 0, FechaNulo, value)
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

    Public Property ejercicio() As String
        Get
            Return m_ejercicio
        End Get
        Set(ByVal value As String)
            m_ejercicio = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property mes() As String
        Get
            Return m_mes
        End Get
        Set(ByVal value As String)
            m_mes = IIf(String.IsNullOrEmpty(value), "00", value)
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

    Public Property producto_anterior() As String
        Get
            Return m_producto_anterior
        End Get
        Set(ByVal value As String)
            m_producto_anterior = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property numero_lote_anterior() As String
        Get
            Return m_numero_lote_anterior
        End Get
        Set(ByVal value As String)
            m_numero_lote_anterior = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cantidad_anterior() As Decimal
        Get
            Return m_cantidad_anterior
        End Get
        Set(ByVal value As Decimal)
            m_cantidad_anterior = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property exige_lote() As String
        Get
            Return m_exige_lote
        End Get
        Set(ByVal value As String)
            m_exige_lote = IIf(String.IsNullOrEmpty(value), "NO", value)
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

End Class
