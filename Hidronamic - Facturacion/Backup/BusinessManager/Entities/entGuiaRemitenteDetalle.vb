Public Class entGuiaRemitenteDetalle
    Private m_empresa As String
    Private m_guia_remitente As String
    Private m_linea As String
    Private m_producto As String
    Private m_numero_lote As String
    Private m_numero_serie As String
    Private m_unidad_medida As String
    Private m_cantidad As Decimal
    Private m_cantidad_devuelta As Decimal
    Private m_ubicacion As String
    Private m_fecha_vencimiento As Date
    Private m_peso_unitario As Decimal
    Private m_peso_total As Decimal
    Private m_costo_traslado_unitario As Decimal
    Private m_costo_traslado_total As Decimal
    Private m_precio_unitario As Decimal
    Private m_valor_venta As Decimal
    Private m_impuestos As Decimal
    Private m_precio_venta As Decimal
    Private m_estado As String
    Private m_comentario As String
    Private m_recepcion_cuo As String
    Private m_operacion_cuo As String
    Private m_venta_cuo As String
    Private m_cuo_linea As String
    Private m_cuo_secuencia As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.guia_remitente = Nothing
        Me.linea = Nothing
        Me.producto = Nothing
        Me.numero_lote = Nothing
        Me.numero_serie = Nothing
        Me.unidad_medida = Nothing
        Me.cantidad = Nothing
        Me.cantidad_devuelta = Nothing
        Me.ubicacion = Nothing
        Me.fecha_vencimiento = Nothing
        Me.peso_unitario = Nothing
        Me.peso_total = Nothing
        Me.costo_traslado_unitario = Nothing
        Me.costo_traslado_total = Nothing
        Me.precio_unitario = Nothing
        Me.valor_venta = Nothing
        Me.impuestos = Nothing
        Me.precio_venta = Nothing
        Me.estado = Nothing
        Me.comentario = Nothing
        Me.recepcion_CUO = Nothing
        Me.operacion_CUO = Nothing
        Me.venta_CUO = Nothing
        Me.CUO_linea = Nothing
        Me.CUO_secuencia = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal GuiaRemitenteDetalle As entGuiaRemitenteDetalle)

        With GuiaRemitenteDetalle
            m_empresa = .empresa
            m_guia_remitente = .guia_remitente
            m_linea = .linea
            m_producto = .producto
            m_numero_lote = .numero_lote
            m_numero_serie = .numero_serie
            m_unidad_medida = .unidad_medida
            m_cantidad = .cantidad
            m_cantidad_devuelta = .cantidad_devuelta
            m_ubicacion = .ubicacion
            m_fecha_vencimiento = .fecha_vencimiento
            m_peso_unitario = .peso_unitario
            m_peso_total = .peso_total
            m_costo_traslado_unitario = .costo_traslado_unitario
            m_costo_traslado_total = .costo_traslado_total
            m_precio_unitario = .precio_unitario
            m_valor_venta = .valor_venta
            m_impuestos = .impuestos
            m_precio_venta = .precio_venta
            m_estado = .estado
            m_comentario = .comentario
            m_recepcion_cuo = .recepcion_CUO
            m_operacion_cuo = .operacion_CUO
            m_venta_cuo = .venta_CUO
            m_cuo_linea = .CUO_linea
            m_cuo_secuencia = .CUO_secuencia
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

    Public Property guia_remitente() As String
        Get
            Return m_guia_remitente
        End Get
        Set(ByVal value As String)
            m_guia_remitente = value
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

    Public Property numero_lote() As String
        Get
            Return m_numero_lote
        End Get
        Set(ByVal value As String)
            m_numero_lote = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property unidad_medida() As String
        Get
            Return m_unidad_medida
        End Get
        Set(ByVal value As String)
            m_unidad_medida = IIf(String.IsNullOrEmpty(value), "07", value)
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

    Public Property cantidad_devuelta() As Decimal
        Get
            Return m_cantidad_devuelta
        End Get
        Set(ByVal value As Decimal)
            m_cantidad_devuelta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ubicacion() As String
        Get
            Return m_ubicacion
        End Get
        Set(ByVal value As String)
            m_ubicacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property peso_unitario() As Decimal
        Get
            Return m_peso_unitario
        End Get
        Set(ByVal value As Decimal)
            m_peso_unitario = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property peso_total() As Decimal
        Get
            Return m_peso_total
        End Get
        Set(ByVal value As Decimal)
            m_peso_total = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property costo_traslado_unitario() As Decimal
        Get
            Return m_costo_traslado_unitario
        End Get
        Set(ByVal value As Decimal)
            m_costo_traslado_unitario = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property costo_traslado_total() As Decimal
        Get
            Return m_costo_traslado_total
        End Get
        Set(ByVal value As Decimal)
            m_costo_traslado_total = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property valor_venta() As Decimal
        Get
            Return m_valor_venta
        End Get
        Set(ByVal value As Decimal)
            m_valor_venta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property impuestos() As Decimal
        Get
            Return m_impuestos
        End Get
        Set(ByVal value As Decimal)
            m_impuestos = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_venta() As Decimal
        Get
            Return m_precio_venta
        End Get
        Set(ByVal value As Decimal)
            m_precio_venta = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property comentario() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property recepcion_CUO() As String
        Get
            Return m_recepcion_cuo
        End Get
        Set(ByVal value As String)
            m_recepcion_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property operacion_CUO() As String
        Get
            Return m_operacion_cuo
        End Get
        Set(ByVal value As String)
            m_operacion_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property venta_CUO() As String
        Get
            Return m_venta_cuo
        End Get
        Set(ByVal value As String)
            m_venta_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property CUO_linea() As String
        Get
            Return m_cuo_linea
        End Get
        Set(ByVal value As String)
            m_cuo_linea = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property CUO_secuencia() As String
        Get
            Return m_cuo_secuencia
        End Get
        Set(ByVal value As String)
            m_cuo_secuencia = IIf(String.IsNullOrEmpty(value), "000", value)
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
