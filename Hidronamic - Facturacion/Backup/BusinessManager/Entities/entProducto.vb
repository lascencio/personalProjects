Public Class entProducto

    Private m_empresa As String
    Private m_producto As String
    Private m_tipo_existencia As String
    Private m_descripcion As String
    Private m_descripcion_ampliada As String
    Private m_producto_familia As String
    Private m_producto_sub_familia As String
    Private m_producto_tipo As String
    Private m_producto_sub_tipo As String
    Private m_unidad_medida As String
    Private m_unidad_compra As String
    Private m_unidad_venta As String
    Private m_decimales As Byte
    Private m_factor_compra As Decimal
    Private m_factor_venta As Decimal
    Private m_volumen_compra As Decimal
    Private m_volumen_venta As Decimal
    Private m_peso_compra As Decimal
    Private m_peso_venta As Decimal
    Private m_stock_actual As Decimal
    Private m_stock_comprometido As Decimal
    Private m_stock_transito As Decimal
    Private m_almacen As String
    Private m_ubicacion As String
    Private m_precio_compra_mn As Decimal
    Private m_precio_venta_mn As Decimal
    Private m_precio_compra_me As Decimal
    Private m_precio_venta_me As Decimal
    Private m_procedencia As String
    Private m_cuenta_compra_mn As String
    Private m_cuenta_venta_mn As String
    Private m_cuenta_compra_me As String
    Private m_cuenta_venta_me As String
    Private m_cuenta_costo_mn As String
    Private m_cuenta_costo_me As String
    Private m_tipo_moneda As String
    Private m_prioridad As String
    Private m_codigo_compra As String
    Private m_descripcion_compra As String
    Private m_tiempo_entrega As Byte 'en semanas
    Private m_tiempo_proceso As Byte 'en semanas
    Private m_stock_seguridad As Byte 'en semanas
    Private m_caducidad As Byte 'en meses
    Private m_estado As String
    Private m_indica_serie As String
    Private m_indica_lote As String
    Private m_indica_vencimiento As String
    Private m_indica_valida_stock As String
    Private m_indica_afecto As String

    Private m_indica_compuesto As String
    Private m_indica_promocional As String

    Private m_indica_sin_planificacion As String
    Private m_porcentaje_ganancia_costo As Decimal
    Private m_porcentaje_ganancia_precio As Decimal
    Private m_puntos_bonificacion As Decimal
    Private m_largo_cms As Decimal
    Private m_ancho_cms As Decimal
    Private m_profundidad_cms As Decimal

    Private m_stock_minimo As Decimal
    Private m_stock_maximo As Decimal
    Private m_partida_arancelaria As String
    Private m_costo_fob As Decimal
    Private m_flete As Decimal
    Private m_seguros As Decimal
    Private m_agente_aduanas As Decimal
    Private m_derecho_advalorem As Decimal
    Private m_gastos_despacho As Decimal
    Private m_costo_estandar As Decimal
    Private m_codigo_antiguo As String
    Private m_codigo_vendedor As String
    Private m_codigo_comprador As String
    Private m_ultima_compra As String
    Private m_ultima_venta As String
    Private m_comentario As String
    Private m_imagen As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.producto = Nothing
        Me.tipo_existencia = Nothing
        Me.descripcion = Nothing
        Me.descripcion_ampliada = Nothing
        Me.producto_familia = Nothing
        Me.producto_sub_familia = Nothing
        Me.producto_tipo = Nothing
        Me.producto_sub_tipo = Nothing
        Me.unidad_medida = Nothing
        Me.unidad_compra = Nothing
        Me.unidad_venta = Nothing
        Me.decimales = Nothing
        Me.factor_compra = Nothing
        Me.factor_venta = Nothing
        Me.volumen_compra = Nothing
        Me.volumen_venta = Nothing
        Me.peso_compra = Nothing
        Me.peso_venta = Nothing
        Me.stock_actual = Nothing
        Me.stock_comprometido = Nothing
        Me.stock_transito = Nothing
        Me.almacen = Nothing
        Me.ubicacion = Nothing
        Me.precio_compra_mn = Nothing
        Me.precio_venta_mn = Nothing
        Me.precio_compra_me = Nothing
        Me.precio_venta_me = Nothing
        Me.procedencia = Nothing
        Me.cuenta_compra_mn = Nothing
        Me.cuenta_venta_mn = Nothing
        Me.cuenta_compra_me = Nothing
        Me.cuenta_venta_me = Nothing
        Me.cuenta_costo_mn = Nothing
        Me.cuenta_costo_me = Nothing
        Me.tipo_moneda = Nothing
        Me.prioridad = Nothing
        Me.codigo_compra = Nothing
        Me.descripcion_compra = Nothing
        Me.tiempo_entrega = Nothing
        Me.tiempo_proceso = Nothing
        Me.stock_seguridad = Nothing
        Me.caducidad = Nothing
        Me.estado = Nothing
        Me.indica_serie = Nothing
        Me.indica_lote = Nothing
        Me.indica_vencimiento = Nothing
        Me.indica_valida_stock = Nothing
        Me.indica_afecto = Nothing

        Me.indica_compuesto = Nothing
        Me.indica_promocional = Nothing

        Me.indica_sin_planificacion = Nothing
        Me.porcentaje_ganancia_costo = Nothing
        Me.porcentaje_ganancia_precio = Nothing
        Me.puntos_bonificacion = Nothing
        Me.largo_cms = Nothing
        Me.ancho_cms = Nothing
        Me.profundidad_cms = Nothing

        Me.stock_minimo = Nothing
        Me.stock_maximo = Nothing
        Me.partida_arancelaria = Nothing
        Me.costo_fob = Nothing
        Me.flete = Nothing
        Me.seguros = Nothing
        Me.agente_aduanas = Nothing
        Me.derecho_advalorem = Nothing
        Me.gastos_despacho = Nothing
        Me.costo_estandar = Nothing
        Me.codigo_antiguo = Nothing
        Me.codigo_vendedor = Nothing
        Me.codigo_comprador = Nothing
        Me.ultima_compra = Nothing
        Me.ultima_venta = Nothing
        Me.comentario = Nothing
        Me.imagen = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal Producto As entProducto)
        With Producto
            m_empresa = .empresa
            m_producto = .producto
            m_tipo_existencia = .tipo_existencia
            m_descripcion = .descripcion
            m_descripcion_ampliada = .descripcion_ampliada
            m_producto_familia = .producto_familia
            m_producto_sub_familia = .producto_sub_familia
            m_producto_tipo = .producto_tipo
            m_producto_sub_tipo = .producto_sub_tipo
            m_unidad_medida = .unidad_medida
            m_unidad_compra = .unidad_compra
            m_unidad_venta = .unidad_venta
            m_decimales = .decimales
            m_factor_compra = .factor_compra
            m_factor_venta = .factor_venta
            m_volumen_compra = .volumen_compra
            m_volumen_venta = .volumen_venta
            m_peso_compra = .peso_compra
            m_peso_venta = .peso_venta
            m_stock_actual = .stock_actual
            m_stock_comprometido = .stock_comprometido
            m_stock_transito = .stock_transito
            m_almacen = .almacen
            m_ubicacion = .ubicacion
            m_precio_compra_mn = .precio_compra_mn
            m_precio_venta_mn = .precio_venta_mn
            m_precio_compra_me = .precio_compra_me
            m_precio_venta_me = .precio_venta_me
            m_procedencia = .procedencia
            m_cuenta_compra_mn = .cuenta_compra_mn
            m_cuenta_venta_mn = .cuenta_venta_mn
            m_cuenta_compra_me = .cuenta_compra_me
            m_cuenta_venta_me = .cuenta_venta_me
            m_cuenta_costo_mn = .cuenta_costo_mn
            m_cuenta_costo_me = .cuenta_costo_me
            m_tipo_moneda = .tipo_moneda
            m_prioridad = .prioridad
            m_codigo_compra = .codigo_compra
            m_descripcion_compra = .descripcion_compra
            m_tiempo_entrega = .tiempo_entrega
            m_tiempo_proceso = .tiempo_proceso
            m_stock_seguridad = .stock_seguridad
            m_caducidad = .caducidad
            m_estado = .estado
            m_indica_serie = .indica_serie
            m_indica_lote = .indica_lote
            m_indica_vencimiento = .indica_vencimiento
            m_indica_valida_stock = .indica_valida_stock
            m_indica_afecto = .indica_afecto

            m_indica_compuesto = .indica_compuesto
            m_indica_promocional = .indica_promocional

            m_indica_sin_planificacion = .indica_sin_planificacion
            m_porcentaje_ganancia_costo = .porcentaje_ganancia_costo
            m_porcentaje_ganancia_precio = .porcentaje_ganancia_precio
            m_puntos_bonificacion = .puntos_bonificacion
            m_largo_cms = .largo_cms
            m_ancho_cms = .ancho_cms
            m_profundidad_cms = .profundidad_cms

            m_stock_minimo = .stock_minimo
            m_stock_maximo = .stock_maximo
            m_partida_arancelaria = .partida_arancelaria
            m_costo_fob = .costo_fob
            m_flete = .flete
            m_seguros = .seguros
            m_agente_aduanas = .agente_aduanas
            m_derecho_advalorem = .derecho_advalorem
            m_gastos_despacho = .gastos_despacho
            m_costo_estandar = .costo_estandar
            m_codigo_antiguo = .codigo_antiguo
            m_codigo_vendedor = .codigo_vendedor
            m_codigo_comprador = .codigo_comprador
            m_ultima_compra = .ultima_compra
            m_ultima_venta = .ultima_venta
            m_comentario = .comentario
            m_imagen = .imagen
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

    Public Property tipo_existencia() As String
        Get
            Return m_tipo_existencia
        End Get
        Set(ByVal value As String)
            m_tipo_existencia = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property

    Public Property descripcion_ampliada() As String
        Get
            Return m_descripcion_ampliada
        End Get
        Set(ByVal value As String)
            m_descripcion_ampliada = value
        End Set
    End Property

    Public Property producto_familia() As String
        Get
            Return m_producto_familia
        End Get
        Set(ByVal value As String)
            m_producto_familia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property producto_sub_familia() As String
        Get
            Return m_producto_sub_familia
        End Get
        Set(ByVal value As String)
            m_producto_sub_familia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property producto_tipo() As String
        Get
            Return m_producto_tipo
        End Get
        Set(ByVal value As String)
            m_producto_tipo = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property producto_sub_tipo() As String
        Get
            Return m_producto_sub_tipo
        End Get
        Set(ByVal value As String)
            m_producto_sub_tipo = IIf(String.IsNullOrEmpty(value), "000000", value)
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

    Public Property unidad_compra() As String
        Get
            Return m_unidad_compra
        End Get
        Set(ByVal value As String)
            m_unidad_compra = IIf(String.IsNullOrEmpty(value), "07", value)
        End Set
    End Property

    Public Property unidad_venta() As String
        Get
            Return m_unidad_venta
        End Get
        Set(ByVal value As String)
            m_unidad_venta = IIf(String.IsNullOrEmpty(value), "07", value)
        End Set
    End Property

    Public Property decimales() As Byte
        Get
            Return m_decimales
        End Get
        Set(ByVal value As Byte)
            m_decimales = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property factor_compra() As Decimal
        Get
            Return m_factor_compra
        End Get
        Set(ByVal value As Decimal)
            m_factor_compra = IIf(String.IsNullOrEmpty(value), 1, value)
        End Set
    End Property

    Public Property factor_venta() As Decimal
        Get
            Return m_factor_venta
        End Get
        Set(ByVal value As Decimal)
            m_factor_venta = IIf(String.IsNullOrEmpty(value), 1, value)
        End Set
    End Property

    Public Property volumen_compra() As Decimal
        Get
            Return m_volumen_compra
        End Get
        Set(ByVal value As Decimal)
            m_volumen_compra = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property volumen_venta() As Decimal
        Get
            Return m_volumen_venta
        End Get
        Set(ByVal value As Decimal)
            m_volumen_venta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property peso_compra() As Decimal
        Get
            Return m_peso_compra
        End Get
        Set(ByVal value As Decimal)
            m_peso_compra = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property peso_venta() As Decimal
        Get
            Return m_peso_venta
        End Get
        Set(ByVal value As Decimal)
            m_peso_venta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property stock_actual() As Decimal
        Get
            Return m_stock_actual
        End Get
        Set(ByVal value As Decimal)
            m_stock_actual = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property stock_comprometido() As Decimal
        Get
            Return m_stock_comprometido
        End Get
        Set(ByVal value As Decimal)
            m_stock_comprometido = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property stock_transito() As Decimal
        Get
            Return m_stock_transito
        End Get
        Set(ByVal value As Decimal)
            m_stock_transito = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property ubicacion() As String
        Get
            Return m_ubicacion
        End Get
        Set(ByVal value As String)
            m_ubicacion = IIf(String.IsNullOrEmpty(value), "000000", value)
        End Set
    End Property

    Public Property precio_compra_mn() As Decimal
        Get
            Return m_precio_compra_mn
        End Get
        Set(ByVal value As Decimal)
            m_precio_compra_mn = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property precio_compra_me() As Decimal
        Get
            Return m_precio_compra_me
        End Get
        Set(ByVal value As Decimal)
            m_precio_compra_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property procedencia() As String
        Get
            Return m_procedencia
        End Get
        Set(ByVal value As String)
            m_procedencia = IIf(String.IsNullOrEmpty(value), "N", value)
        End Set
    End Property

    Public Property cuenta_compra_mn() As String
        Get
            Return m_cuenta_compra_mn
        End Get
        Set(ByVal value As String)
            m_cuenta_compra_mn = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_venta_mn() As String
        Get
            Return m_cuenta_venta_mn
        End Get
        Set(ByVal value As String)
            m_cuenta_venta_mn = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_compra_me() As String
        Get
            Return m_cuenta_compra_me
        End Get
        Set(ByVal value As String)
            m_cuenta_compra_me = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_venta_me() As String
        Get
            Return m_cuenta_venta_me
        End Get
        Set(ByVal value As String)
            m_cuenta_venta_me = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_costo_mn() As String
        Get
            Return m_cuenta_costo_mn
        End Get
        Set(ByVal value As String)
            m_cuenta_costo_mn = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_costo_me() As String
        Get
            Return m_cuenta_costo_me
        End Get
        Set(ByVal value As String)
            m_cuenta_costo_me = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property prioridad() As String
        Get
            Return m_prioridad
        End Get
        Set(ByVal value As String)
            m_prioridad = IIf(String.IsNullOrEmpty(value), "M", value)
        End Set
    End Property

    Public Property codigo_compra() As String
        Get
            Return m_codigo_compra
        End Get
        Set(ByVal value As String)
            m_codigo_compra = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property descripcion_compra() As String
        Get
            Return m_descripcion_compra
        End Get
        Set(ByVal value As String)
            m_descripcion_compra = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tiempo_entrega() As Byte
        Get
            Return m_tiempo_entrega
        End Get
        Set(ByVal value As Byte)
            m_tiempo_entrega = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property tiempo_proceso() As Byte
        Get
            Return m_tiempo_proceso
        End Get
        Set(ByVal value As Byte)
            m_tiempo_proceso = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property stock_seguridad() As Byte
        Get
            Return m_stock_seguridad
        End Get
        Set(ByVal value As Byte)
            m_stock_seguridad = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property caducidad() As Byte
        Get
            Return m_caducidad
        End Get
        Set(ByVal value As Byte)
            m_caducidad = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property indica_serie() As String
        Get
            Return m_indica_serie
        End Get
        Set(ByVal value As String)
            m_indica_serie = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_lote() As String
        Get
            Return m_indica_lote
        End Get
        Set(ByVal value As String)
            m_indica_lote = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_vencimiento() As String
        Get
            Return m_indica_vencimiento
        End Get
        Set(ByVal value As String)
            m_indica_vencimiento = IIf(String.IsNullOrEmpty(value), "NO", value)
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

    Public Property indica_afecto() As String
        Get
            Return m_indica_afecto
        End Get
        Set(ByVal value As String)
            m_indica_afecto = IIf(String.IsNullOrEmpty(value), "SI", value)
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

    Public Property indica_promocional() As String
        Get
            Return m_indica_promocional
        End Get
        Set(ByVal value As String)
            m_indica_promocional = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_sin_planificacion() As String
        Get
            Return m_indica_sin_planificacion
        End Get
        Set(ByVal value As String)
            m_indica_sin_planificacion = IIf(String.IsNullOrEmpty(value), "SI", value)
        End Set
    End Property

    Public Property porcentaje_ganancia_costo() As Decimal
        Get
            Return m_porcentaje_ganancia_costo
        End Get
        Set(ByVal value As Decimal)
            m_porcentaje_ganancia_costo = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property porcentaje_ganancia_precio() As Decimal
        Get
            Return m_porcentaje_ganancia_precio
        End Get
        Set(ByVal value As Decimal)
            m_porcentaje_ganancia_precio = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property puntos_bonificacion() As Decimal
        Get
            Return m_puntos_bonificacion
        End Get
        Set(ByVal value As Decimal)
            m_puntos_bonificacion = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property largo_cms() As Decimal
        Get
            Return m_largo_cms
        End Get
        Set(ByVal value As Decimal)
            m_largo_cms = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ancho_cms() As Decimal
        Get
            Return m_ancho_cms
        End Get
        Set(ByVal value As Decimal)
            m_ancho_cms = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property profundidad_cms() As Decimal
        Get
            Return m_profundidad_cms
        End Get
        Set(ByVal value As Decimal)
            m_profundidad_cms = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property stock_minimo() As Decimal
        Get
            Return m_stock_minimo
        End Get
        Set(ByVal value As Decimal)
            m_stock_minimo = value
        End Set
    End Property

    Public Property stock_maximo() As Decimal
        Get
            Return m_stock_maximo
        End Get
        Set(ByVal value As Decimal)
            m_stock_maximo = value
        End Set
    End Property

    Public Property partida_arancelaria() As String
        Get
            Return m_partida_arancelaria
        End Get
        Set(ByVal value As String)
            m_partida_arancelaria = value
        End Set
    End Property

    Public Property costo_fob() As Decimal
        Get
            Return m_costo_fob
        End Get
        Set(ByVal value As Decimal)
            m_costo_fob = value
        End Set
    End Property

    Public Property flete() As Decimal
        Get
            Return m_flete
        End Get
        Set(ByVal value As Decimal)
            m_flete = value
        End Set
    End Property

    Public Property seguros() As Decimal
        Get
            Return m_seguros
        End Get
        Set(ByVal value As Decimal)
            m_seguros = value
        End Set
    End Property

    Public Property agente_aduanas() As Decimal
        Get
            Return m_agente_aduanas
        End Get
        Set(ByVal value As Decimal)
            m_agente_aduanas = value
        End Set
    End Property

    Public Property derecho_advalorem() As Decimal
        Get
            Return m_derecho_advalorem
        End Get
        Set(ByVal value As Decimal)
            m_derecho_advalorem = value
        End Set
    End Property

    Public Property gastos_despacho() As Decimal
        Get
            Return m_gastos_despacho
        End Get
        Set(ByVal value As Decimal)
            m_gastos_despacho = value
        End Set
    End Property

    Public Property costo_estandar() As Decimal
        Get
            Return m_costo_estandar
        End Get
        Set(ByVal value As Decimal)
            m_costo_estandar = value
        End Set
    End Property

    Public Property codigo_antiguo() As String
        Get
            Return m_codigo_antiguo
        End Get
        Set(ByVal value As String)
            m_codigo_antiguo = value
        End Set
    End Property

    Public Property codigo_vendedor() As String
        Get
            Return m_codigo_vendedor
        End Get
        Set(ByVal value As String)
            m_codigo_vendedor = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property codigo_comprador() As String
        Get
            Return m_codigo_comprador
        End Get
        Set(ByVal value As String)
            m_codigo_comprador = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ultima_compra() As String
        Get
            Return m_ultima_compra
        End Get
        Set(ByVal value As String)
            m_ultima_compra = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property ultima_venta() As String
        Get
            Return m_ultima_venta
        End Get
        Set(ByVal value As String)
            m_ultima_venta = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property comentario() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = value
        End Set
    End Property

    Public Property imagen() As String
        Get
            Return m_imagen
        End Get
        Set(ByVal value As String)
            m_imagen = value
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