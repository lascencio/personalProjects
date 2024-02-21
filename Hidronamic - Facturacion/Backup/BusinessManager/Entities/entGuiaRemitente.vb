Public Class entGuiaRemitente
    Private m_empresa As String
    Private m_guia_remitente As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_almacen_origen As String
    Private m_almacen_destino As String
    Private m_tipo_guia As String
    Private m_centro_distribucion As String
    Private m_cuenta_comercial As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_fecha_inicio_traslado As Date
    Private m_domicilio_partida As String
    Private m_domicilio_llegada As String
    Private m_destinatario_nombre As String
    Private m_destinatario_domicilio As String
    Private m_transportista As String
    Private m_unidad_transporte As String
    Private m_motivo_traslado As String
    Private m_orden_venta As String
    Private m_venta As String
    Private m_guia_envio As String
    Private m_comentario As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.guia_remitente = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.almacen_origen = Nothing
        Me.almacen_destino = Nothing
        Me.tipo_guia = Nothing
        Me.centro_distribucion = Nothing
        Me.cuenta_comercial = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.fecha_inicio_traslado = Nothing
        Me.domicilio_partida = Nothing
        Me.domicilio_llegada = Nothing
        Me.destinatario_nombre = Nothing
        Me.destinatario_domicilio = Nothing
        Me.transportista = Nothing
        Me.unidad_transporte = Nothing
        Me.motivo_traslado = Nothing
        Me.orden_venta = Nothing
        Me.venta = Nothing
        Me.guia_envio = Nothing
        Me.comentario = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal GuiaRemitente As entGuiaRemitente)

        With GuiaRemitente
            m_empresa = .empresa
            m_guia_remitente = .guia_remitente
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_almacen_origen = .almacen_origen
            m_almacen_destino = .almacen_destino
            m_tipo_guia = .tipo_guia
            m_centro_distribucion = .centro_distribucion
            m_cuenta_comercial = .cuenta_comercial
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_fecha_inicio_traslado = .fecha_inicio_traslado
            m_domicilio_partida = .domicilio_partida
            m_domicilio_llegada = .domicilio_llegada
            m_destinatario_nombre = .destinatario_nombre
            m_destinatario_domicilio = .destinatario_domicilio
            m_transportista = .transportista
            m_unidad_transporte = .unidad_transporte
            m_motivo_traslado = .motivo_traslado
            m_orden_venta = .orden_venta
            m_venta = .venta
            m_guia_envio = .guia_envio
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

    Public Property guia_remitente() As String
        Get
            Return m_guia_remitente
        End Get
        Set(ByVal value As String)
            m_guia_remitente = value
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

    Public Property almacen_origen() As String
        Get
            Return m_almacen_origen
        End Get
        Set(ByVal value As String)
            m_almacen_origen = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property almacen_destino() As String
        Get
            Return m_almacen_destino
        End Get
        Set(ByVal value As String)
            m_almacen_destino = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property tipo_guia() As String
        Get
            Return m_tipo_guia
        End Get
        Set(ByVal value As String)
            m_tipo_guia = IIf(String.IsNullOrEmpty(value), "G1", value)
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = value
        End Set
    End Property

    Public Property comprobante_tipo() As String
        Get
            Return m_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_comprobante_tipo = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property comprobante_serie() As String
        Get
            Return m_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_comprobante_serie = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property comprobante_numero() As String
        Get
            Return m_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_comprobante_numero = IIf(String.IsNullOrEmpty(value), "0000000000", value)
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

    Public Property fecha_inicio_traslado() As Date
        Get
            Return m_fecha_inicio_traslado
        End Get
        Set(ByVal value As Date)
            m_fecha_inicio_traslado = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property domicilio_partida() As String
        Get
            Return m_domicilio_partida
        End Get
        Set(ByVal value As String)
            m_domicilio_partida = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property domicilio_llegada() As String
        Get
            Return m_domicilio_llegada
        End Get
        Set(ByVal value As String)
            m_domicilio_llegada = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property destinatario_nombre() As String
        Get
            Return m_destinatario_nombre
        End Get
        Set(ByVal value As String)
            m_destinatario_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property destinatario_domicilio() As String
        Get
            Return m_destinatario_domicilio
        End Get
        Set(ByVal value As String)
            m_destinatario_domicilio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property transportista() As String
        Get
            Return m_transportista
        End Get
        Set(ByVal value As String)
            m_transportista = IIf(String.IsNullOrEmpty(value), "00000000", value)
        End Set
    End Property

    Public Property unidad_transporte() As String
        Get
            Return m_unidad_transporte
        End Get
        Set(ByVal value As String)
            m_unidad_transporte = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property motivo_traslado() As String
        Get
            Return m_motivo_traslado
        End Get
        Set(ByVal value As String)
            m_motivo_traslado = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property orden_venta() As String
        Get
            Return m_orden_venta
        End Get
        Set(ByVal value As String)
            m_orden_venta = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property venta() As String
        Get
            Return m_venta
        End Get
        Set(ByVal value As String)
            m_venta = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property guia_envio() As String
        Get
            Return m_guia_envio
        End Get
        Set(ByVal value As String)
            m_guia_envio = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
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
