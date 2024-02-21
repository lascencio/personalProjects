Public Class entVentaProducto
    Private m_empresa As String
    Private m_venta As String
    Private m_linea As String
    Private m_tipo_cambio As Single
    Private m_tipo_moneda As String
    Private m_producto As String
    Private m_numero_lote As String
    Private m_unidad_medida As String
    Private m_cantidad As Single
    Private m_precio_unitario As Single

    Private m_descuento_1 As Single
    Private m_descuento_2 As Single
    Private m_descuento_3 As Single

    Private m_valor_exportacion_origen As Single
    Private m_base_imponible_gravada_origen As Single
    Private m_importe_exonerado_origen As Single
    Private m_importe_inafecto_origen As Single
    Private m_isc_origen As Single
    Private m_igv_origen As Single
    Private m_ipm_origen As Single
    Private m_base_imponible_gravada2_origen As Single
    Private m_igv2_origen As Single
    Private m_otros_tributos_origen As Single
    Private m_importe_total_origen As Single

    Private m_valor_exportacion_mn As Single
    Private m_base_imponible_gravada_mn As Single
    Private m_importe_exonerado_mn As Single
    Private m_importe_inafecto_mn As Single
    Private m_isc_mn As Single
    Private m_igv_mn As Single
    Private m_ipm_mn As Single
    Private m_base_imponible_gravada2_mn As Single
    Private m_igv2_mn As Single
    Private m_otros_tributos_mn As Single
    Private m_importe_total_mn As Single

    Private m_valor_exportacion_me As Single
    Private m_base_imponible_gravada_me As Single
    Private m_importe_exonerado_me As Single
    Private m_importe_inafecto_me As Single
    Private m_isc_me As Single
    Private m_igv_me As Single
    Private m_ipm_me As Single
    Private m_base_imponible_gravada2_me As Single
    Private m_igv2_me As Single
    Private m_otros_tributos_me As Single
    Private m_importe_total_me As Single

    Private m_estado As String
    Private m_guia_remitente As String
    Private m_centro_costo As String
    Private m_proyecto As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_proyecto As Boolean
    Private m_indica_compuesto As String
    Private m_almacen As String
    Private m_descripcion_ampliada As String
    Private m_ejercicio_venta As String
    Private m_mes_venta As String

    Private m_indica_valida_stock As String

    Private m_orden_pedido As String

    Public Sub New()
        Me.empresa = Nothing
        Me.venta = Nothing
        Me.linea = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.producto = Nothing
        Me.numero_lote = Nothing
        Me.unidad_medida = Nothing
        Me.cantidad = Nothing
        Me.precio_unitario = Nothing

        Me.descuento_1 = Nothing
        Me.descuento_2 = Nothing
        Me.descuento_3 = Nothing

        Me.valor_exportacion_origen = Nothing
        Me.base_imponible_gravada_origen = Nothing
        Me.importe_exonerado_origen = Nothing
        Me.importe_inafecto_origen = Nothing
        Me.isc_origen = Nothing
        Me.igv_origen = Nothing
        Me.ipm_origen = Nothing
        Me.base_imponible_gravada2_origen = Nothing
        Me.igv2_origen = Nothing
        Me.otros_tributos_origen = Nothing
        Me.importe_total_origen = Nothing

        Me.valor_exportacion_mn = Nothing
        Me.base_imponible_gravada_mn = Nothing
        Me.importe_exonerado_mn = Nothing
        Me.importe_inafecto_mn = Nothing
        Me.isc_mn = Nothing
        Me.igv_mn = Nothing
        Me.ipm_mn = Nothing
        Me.base_imponible_gravada2_mn = Nothing
        Me.igv2_mn = Nothing
        Me.otros_tributos_mn = Nothing
        Me.importe_total_mn = Nothing

        Me.valor_exportacion_me = Nothing
        Me.base_imponible_gravada_me = Nothing
        Me.importe_exonerado_me = Nothing
        Me.importe_inafecto_me = Nothing
        Me.isc_me = Nothing
        Me.igv_me = Nothing
        Me.ipm_me = Nothing
        Me.base_imponible_gravada2_me = Nothing
        Me.igv2_me = Nothing
        Me.otros_tributos_me = Nothing
        Me.importe_total_me = Nothing

        Me.estado = Nothing
        Me.guia_remitente = Nothing
        Me.centro_costo = Nothing
        Me.proyecto = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.indica_proyecto = Nothing
        Me.indica_compuesto = Nothing
        Me.almacen = Nothing
        Me.descripcion_ampliada = Nothing
        Me.ejercicio_venta = Nothing
        Me.mes_venta = Nothing

        Me.indica_valida_stock = Nothing
        Me.orden_pedido = Nothing
    End Sub

    Public Sub New(ByVal VentaProducto As entVentaProducto)

        With VentaProducto
            m_empresa = .empresa
            m_venta = .venta
            m_linea = .linea
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_producto = .producto
            m_numero_lote = .numero_lote
            m_unidad_medida = .unidad_medida
            m_cantidad = .cantidad
            m_precio_unitario = .precio_unitario

            m_descuento_1 = .descuento_1
            m_descuento_2 = .descuento_2
            m_descuento_2 = .descuento_2

            m_valor_exportacion_origen = .valor_exportacion_origen
            m_base_imponible_gravada_origen = .base_imponible_gravada_origen
            m_importe_exonerado_origen = .importe_exonerado_origen
            m_importe_inafecto_origen = .importe_inafecto_origen
            m_isc_origen = .isc_origen
            m_igv_origen = .igv_origen
            m_ipm_origen = .ipm_origen
            m_base_imponible_gravada2_origen = .base_imponible_gravada2_origen
            m_igv2_origen = .igv2_origen
            m_otros_tributos_origen = .otros_tributos_origen
            m_importe_total_origen = .importe_total_origen

            m_valor_exportacion_mn = .valor_exportacion_mn
            m_base_imponible_gravada_mn = .base_imponible_gravada_mn
            m_importe_exonerado_mn = .importe_exonerado_mn
            m_importe_inafecto_mn = .importe_inafecto_mn
            m_isc_mn = .isc_mn
            m_igv_mn = .igv_mn
            m_ipm_mn = .ipm_mn
            m_base_imponible_gravada2_mn = .base_imponible_gravada2_mn
            m_igv2_mn = .igv2_mn
            m_otros_tributos_mn = .otros_tributos_mn
            m_importe_total_mn = .importe_total_mn

            m_valor_exportacion_me = .valor_exportacion_me
            m_base_imponible_gravada_me = .base_imponible_gravada_me
            m_importe_exonerado_me = .importe_exonerado_me
            m_importe_inafecto_me = .importe_inafecto_me
            m_isc_me = .isc_me
            m_igv_me = .igv_me
            m_ipm_me = .ipm_me
            m_base_imponible_gravada2_me = .base_imponible_gravada2_me
            m_igv2_me = .igv2_me
            m_otros_tributos_me = .otros_tributos_me
            m_importe_total_me = .importe_total_me

            m_estado = .estado
            m_guia_remitente = .guia_remitente
            m_centro_costo = .centro_costo
            m_proyecto = .proyecto
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_indica_proyecto = .indica_proyecto
            m_indica_compuesto = .indica_compuesto
            m_almacen = .almacen
            m_descripcion_ampliada = .descripcion_ampliada
            m_ejercicio_venta = .ejercicio_venta
            m_mes_venta = .mes_venta

            m_indica_valida_stock = .indica_valida_stock
            m_orden_pedido = .orden_pedido

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

    Public Property venta() As String
        Get
            Return m_venta
        End Get
        Set(ByVal value As String)
            m_venta = value
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

    Public Property tipo_cambio() As Single
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Single)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
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

    Public Property producto() As String
        Get
            Return m_producto
        End Get
        Set(ByVal value As String)
            m_producto = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property unidad_medida() As String
        Get
            Return m_unidad_medida
        End Get
        Set(ByVal value As String)
            m_unidad_medida = IIf(String.IsNullOrEmpty(value), "07", value)
        End Set
    End Property

    Public Property cantidad() As Single
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Single)
            m_cantidad = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property precio_unitario() As Single
        Get
            Return m_precio_unitario
        End Get
        Set(ByVal value As Single)
            m_precio_unitario = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property valor_exportacion_origen() As Single
        Get
            Return m_valor_exportacion_origen
        End Get
        Set(ByVal value As Single)
            m_valor_exportacion_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_origen() As Single
        Get
            Return m_base_imponible_gravada_origen
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_origen() As Single
        Get
            Return m_importe_exonerado_origen
        End Get
        Set(ByVal value As Single)
            m_importe_exonerado_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_origen() As Single
        Get
            Return m_importe_inafecto_origen
        End Get
        Set(ByVal value As Single)
            m_importe_inafecto_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_origen() As Single
        Get
            Return m_isc_origen
        End Get
        Set(ByVal value As Single)
            m_isc_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_origen() As Single
        Get
            Return m_igv_origen
        End Get
        Set(ByVal value As Single)
            m_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_origen() As Single
        Get
            Return m_ipm_origen
        End Get
        Set(ByVal value As Single)
            m_ipm_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_origen() As Single
        Get
            Return m_base_imponible_gravada2_origen
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_origen() As Single
        Get
            Return m_igv2_origen
        End Get
        Set(ByVal value As Single)
            m_igv2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_origen() As Single
        Get
            Return m_otros_tributos_origen
        End Get
        Set(ByVal value As Single)
            m_otros_tributos_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_origen() As Single
        Get
            Return m_importe_total_origen
        End Get
        Set(ByVal value As Single)
            m_importe_total_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_exportacion_mn() As Single
        Get
            Return m_valor_exportacion_mn
        End Get
        Set(ByVal value As Single)
            m_valor_exportacion_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_mn() As Single
        Get
            Return m_base_imponible_gravada_mn
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_mn() As Single
        Get
            Return m_importe_exonerado_mn
        End Get
        Set(ByVal value As Single)
            m_importe_exonerado_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_mn() As Single
        Get
            Return m_importe_inafecto_mn
        End Get
        Set(ByVal value As Single)
            m_importe_inafecto_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_mn() As Single
        Get
            Return m_isc_mn
        End Get
        Set(ByVal value As Single)
            m_isc_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_mn() As Single
        Get
            Return m_igv_mn
        End Get
        Set(ByVal value As Single)
            m_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_mn() As Single
        Get
            Return m_ipm_mn
        End Get
        Set(ByVal value As Single)
            m_ipm_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_mn() As Single
        Get
            Return m_base_imponible_gravada2_mn
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada2_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_mn() As Single
        Get
            Return m_igv2_mn
        End Get
        Set(ByVal value As Single)
            m_igv2_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_mn() As Single
        Get
            Return m_otros_tributos_mn
        End Get
        Set(ByVal value As Single)
            m_otros_tributos_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_mn() As Single
        Get
            Return m_importe_total_mn
        End Get
        Set(ByVal value As Single)
            m_importe_total_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_exportacion_me() As Single
        Get
            Return m_valor_exportacion_me
        End Get
        Set(ByVal value As Single)
            m_valor_exportacion_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_me() As Single
        Get
            Return m_base_imponible_gravada_me
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_me() As Single
        Get
            Return m_importe_exonerado_me
        End Get
        Set(ByVal value As Single)
            m_importe_exonerado_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_me() As Single
        Get
            Return m_importe_inafecto_me
        End Get
        Set(ByVal value As Single)
            m_importe_inafecto_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_me() As Single
        Get
            Return m_isc_me
        End Get
        Set(ByVal value As Single)
            m_isc_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv_me() As Single
        Get
            Return m_igv_me
        End Get
        Set(ByVal value As Single)
            m_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_me() As Single
        Get
            Return m_ipm_me
        End Get
        Set(ByVal value As Single)
            m_ipm_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_me() As Single
        Get
            Return m_base_imponible_gravada2_me
        End Get
        Set(ByVal value As Single)
            m_base_imponible_gravada2_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_me() As Single
        Get
            Return m_igv2_me
        End Get
        Set(ByVal value As Single)
            m_igv2_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_me() As Single
        Get
            Return m_otros_tributos_me
        End Get
        Set(ByVal value As Single)
            m_otros_tributos_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_me() As Single
        Get
            Return m_importe_total_me
        End Get
        Set(ByVal value As Single)
            m_importe_total_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property guia_remitente() As String
        Get
            Return m_guia_remitente
        End Get
        Set(ByVal value As String)
            m_guia_remitente = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property centro_costo() As String
        Get
            Return m_centro_costo
        End Get
        Set(ByVal value As String)
            m_centro_costo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property proyecto() As String
        Get
            Return m_proyecto
        End Get
        Set(ByVal value As String)
            m_proyecto = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property indica_proyecto() As Boolean
        Get
            Return m_indica_proyecto
        End Get
        Set(ByVal value As Boolean)
            m_indica_proyecto = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property indica_compuesto() As String
        Get
            Return m_indica_compuesto
        End Get
        Set(ByVal value As String)
            m_indica_compuesto = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property descripcion_ampliada() As String
        Get
            Return m_descripcion_ampliada
        End Get
        Set(ByVal value As String)
            m_descripcion_ampliada = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ejercicio_venta() As String
        Get
            Return m_ejercicio_venta
        End Get
        Set(ByVal value As String)
            m_ejercicio_venta = IIf(String.IsNullOrEmpty(value), MyUsuario.ejercicio, value)
        End Set
    End Property

    Public Property indica_valida_stock() As String
        Get
            Return m_indica_valida_stock
        End Get
        Set(ByVal value As String)
            m_indica_valida_stock = IIf(String.IsNullOrEmpty(value), "SI", value)
        End Set
    End Property

    Public Property mes_venta() As String
        Get
            Return m_mes_venta
        End Get
        Set(ByVal value As String)
            m_mes_venta = IIf(String.IsNullOrEmpty(value), Strings.Right("00" & CStr(MyUsuario.mes), 2), value)
        End Set
    End Property

    Public Property orden_pedido() As String
        Get
            Return m_orden_pedido
        End Get
        Set(ByVal value As String)
            m_orden_pedido = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property


End Class
