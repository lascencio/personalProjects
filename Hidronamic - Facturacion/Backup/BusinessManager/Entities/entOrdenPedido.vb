Public Class entOrdenPedido
    Private m_empresa As String
    Private m_orden_pedido As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_cuenta_comercial As String
    Private m_orden_fecha As Date
    Private m_codigo_vendedor As String
    Private m_lista_precio As String
    Private m_centro_distribucion As String
    Private m_importe_total_me As Decimal
    Private m_importe_total_mn As Decimal
    Private m_pago_tipo As String
    Private m_pago_banco As String
    Private m_pago_moneda As String
    Private m_pago_importe As Decimal
    Private m_pago_fecha As Date
    Private m_pago_referencia As String
    Private m_tipo_cambio As Decimal
    Private m_indica_primera_compra As String
    Private m_indica_ascenso As String
    Private m_indica_mantenimiento As String
    Private m_indica_compra_extra As String
    Private m_indica_anticipo As String
    Private m_indica_extorno_anticipo As String
    Private m_venta_anticipo As String
    Private m_comentario As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_venta As String
    Private m_tipo_venta As String
    Private m_ejercicio_venta As String
    Private m_mes_venta As String
    Private m_fecha_venta As Date
    Private m_almacen_venta As String
    Private m_asiento_numero As String

    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_vencimiento As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.orden_pedido = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.cuenta_comercial = Nothing
        Me.orden_fecha = Nothing
        Me.codigo_vendedor = Nothing
        Me.lista_precio = Nothing
        Me.centro_distribucion = Nothing
        Me.importe_total_me = Nothing
        Me.importe_total_mn = Nothing
        Me.pago_tipo = Nothing
        Me.pago_banco = Nothing
        Me.pago_moneda = Nothing
        Me.pago_importe = Nothing
        Me.pago_fecha = Nothing
        Me.pago_referencia = Nothing
        Me.tipo_cambio = Nothing
        Me.indica_primera_compra = Nothing
        Me.indica_ascenso = Nothing
        Me.indica_mantenimiento = Nothing
        Me.indica_compra_extra = Nothing
        Me.indica_anticipo = Nothing
        Me.indica_extorno_anticipo = Nothing
        Me.venta_anticipo = Nothing
        Me.comentario = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
        Me.venta = Nothing
        Me.tipo_venta = Nothing
        Me.ejercicio_venta = Nothing
        Me.mes_venta = Nothing
        Me.fecha_venta = Nothing
        Me.almacen_venta = Nothing
        Me.asiento_numero = Nothing

        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_vencimiento = Nothing
    End Sub

    Public Sub New(ByVal OrdenPedido As entOrdenPedido)
        With OrdenPedido
            m_empresa = .empresa
            m_orden_pedido = .orden_pedido
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_cuenta_comercial = .cuenta_comercial
            m_orden_fecha = .orden_fecha
            m_codigo_vendedor = .codigo_vendedor
            m_lista_precio = .lista_precio
            m_centro_distribucion = .centro_distribucion
            m_importe_total_me = .importe_total_me
            m_importe_total_mn = .importe_total_mn
            m_pago_tipo = .pago_tipo
            m_pago_banco = .pago_banco
            m_pago_moneda = .pago_moneda
            m_pago_importe = .pago_importe
            m_pago_fecha = .pago_fecha
            m_pago_referencia = .pago_referencia
            m_tipo_cambio = .tipo_cambio
            m_indica_primera_compra = .indica_primera_compra
            m_indica_ascenso = .indica_ascenso
            m_indica_mantenimiento = .indica_mantenimiento
            m_indica_compra_extra = .indica_compra_extra
            m_indica_anticipo = .indica_anticipo
            m_indica_extorno_anticipo = .indica_extorno_anticipo
            m_venta_anticipo = .venta_anticipo
            m_comentario = .comentario
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
            m_venta = .venta
            m_tipo_venta = .tipo_venta
            m_ejercicio_venta = .ejercicio_venta
            m_mes_venta = .mes_venta
            m_fecha_venta = .mes_venta
            m_almacen_venta = .almacen_venta
            m_asiento_numero = .asiento_numero

            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_vencimiento = .comprobante_vencimiento
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = value
        End Set
    End Property

    Public Property orden_fecha() As Date
        Get
            Return m_orden_fecha
        End Get
        Set(ByVal value As Date)
            m_orden_fecha = IIf(value.Ticks = 0, FechaNulo, value)
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

    Public Property lista_precio() As String
        Get
            Return m_lista_precio
        End Get
        Set(ByVal value As String)
            m_lista_precio = IIf(String.IsNullOrEmpty(value), "000000000000", value)
        End Set
    End Property

    Public Property centro_distribucion() As String
        Get
            Return m_centro_distribucion
        End Get
        Set(ByVal value As String)
            m_centro_distribucion = IIf(String.IsNullOrEmpty(value), "LIM", value)
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

    Public Property pago_tipo() As String
        Get
            Return m_pago_tipo
        End Get
        Set(ByVal value As String)
            m_pago_tipo = IIf(String.IsNullOrEmpty(value), "99", value)
        End Set
    End Property

    Public Property pago_banco() As String
        Get
            Return m_pago_banco
        End Get
        Set(ByVal value As String)
            m_pago_banco = IIf(String.IsNullOrEmpty(value), "99", value)
        End Set
    End Property

    Public Property pago_moneda() As String
        Get
            Return m_pago_moneda
        End Get
        Set(ByVal value As String)
            m_pago_moneda = IIf(String.IsNullOrEmpty(value), "2", value)
        End Set
    End Property

    Public Property pago_importe() As Decimal
        Get
            Return m_pago_importe
        End Get
        Set(ByVal value As Decimal)
            m_pago_importe = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property pago_fecha() As Date
        Get
            Return m_pago_fecha
        End Get
        Set(ByVal value As Date)
            m_pago_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property pago_referencia() As String
        Get
            Return m_pago_referencia
        End Get
        Set(ByVal value As String)
            m_pago_referencia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
        End Set
    End Property

    Public Property indica_primera_compra() As String
        Get
            Return m_indica_primera_compra
        End Get
        Set(ByVal value As String)
            m_indica_primera_compra = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_ascenso() As String
        Get
            Return m_indica_ascenso
        End Get
        Set(ByVal value As String)
            m_indica_ascenso = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_mantenimiento() As String
        Get
            Return m_indica_mantenimiento
        End Get
        Set(ByVal value As String)
            m_indica_mantenimiento = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_compra_extra() As String
        Get
            Return m_indica_compra_extra
        End Get
        Set(ByVal value As String)
            m_indica_compra_extra = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_anticipo() As String
        Get
            Return m_indica_anticipo
        End Get
        Set(ByVal value As String)
            m_indica_anticipo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_extorno_anticipo() As String
        Get
            Return m_indica_extorno_anticipo
        End Get
        Set(ByVal value As String)
            m_indica_extorno_anticipo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property venta_anticipo() As String
        Get
            Return m_venta_anticipo
        End Get
        Set(ByVal value As String)
            m_venta_anticipo = IIf(String.IsNullOrEmpty(value), "NO", value)
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

    Public Property ejercicio_venta() As String
        Get
            Return m_ejercicio_venta
        End Get
        Set(ByVal value As String)
            m_ejercicio_venta = IIf(String.IsNullOrEmpty(value), MyUsuario.ejercicio, value)
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

    Public Property fecha_venta() As Date
        Get
            Return m_fecha_venta
        End Get
        Set(ByVal value As Date)
            m_fecha_venta = IIf(String.IsNullOrEmpty(value), Now, value)
        End Set
    End Property

    Public Property almacen_venta() As String
        Get
            Return m_almacen_venta
        End Get
        Set(ByVal value As String)
            m_almacen_venta = IIf(String.IsNullOrEmpty(value), "000", value)
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

    Public Property tipo_venta() As String
        Get
            Return m_tipo_venta
        End Get
        Set(ByVal value As String)
            m_tipo_venta = value
        End Set
    End Property

    Public Property asiento_numero() As String
        Get
            Return m_asiento_numero
        End Get
        Set(ByVal value As String)
            m_asiento_numero = value
        End Set
    End Property

    Public Property comprobante_tipo() As String
        Get
            Return m_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_comprobante_tipo = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property comprobante_serie() As String
        Get
            Return m_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_comprobante_serie = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property comprobante_numero() As String
        Get
            Return m_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_comprobante_numero = IIf(String.IsNullOrEmpty(value), "0000000", value)
        End Set
    End Property

    Public Property comprobante_fecha() As Date
        Get
            Return m_comprobante_fecha
        End Get
        Set(ByVal value As Date)
            m_comprobante_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property comprobante_vencimiento() As Date
        Get
            Return m_comprobante_vencimiento
        End Get
        Set(ByVal value As Date)
            m_comprobante_vencimiento = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

End Class
