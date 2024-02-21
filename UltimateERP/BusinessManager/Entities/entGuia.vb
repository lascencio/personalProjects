Public Class entGuia
    Private m_empresa As String
    Private m_guia As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_tipo_operacion As String
    Private m_orden_pedido As String
    Private m_venta As String
    Private m_asiento_tipo As String
    Private m_asiento_numero As String
    Private m_asiento_fecha As Date
    Private m_cuenta_comercial As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_fecha_traslado As Date
    Private m_almacen As String
    Private m_almacen_destino As String

    Private m_centro_distribucion As String
    Private m_domicilio_envio As String

    Private m_referencia_cuo As String
    Private m_motivo_traslado As String
    Private m_punto_partida As String
    Private m_punto_llegada As String
    Private m_destinatario_tipo_documento As String
    Private m_destinatario_nro_documento As String
    Private m_destinatario_razon_social As String

    Private m_conductor_dni As String
    Private m_conductor_nombre As String

    Private m_numero_placa As String
    Private m_transportista_ruc As String
    Private m_transportista_razon_social As String
    Private m_comentario As String

    Private m_indica_transporte_publico As String

    Private m_indica_impreso As String
    Private m_indica_exportacion As String
    Private m_indica_migrado As String

    Private m_usuario_envio As String
    Private m_fecha_envio As Date
    Private m_estado_envio As String
    Private m_usuario_recepcion As String
    Private m_fecha_recepcion As Date
    Private m_comentario_recepion As String
    Private m_estado_traslado_interno As String

    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_total_facturado As String

    Private m_nota As String

    Private m_tipo_operacion_nombre As String

    Private m_tipo_documento As String
    Private m_nro_documento As String
    Private m_razon_social As String

    Private m_ubigeo_origen As String
    Private m_ubigeo_destino As String

    Private m_referencia As String

    Public Sub New()
        Me.empresa = Nothing
        Me.guia = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.tipo_operacion = Nothing
        Me.orden_pedido = Nothing
        Me.venta = Nothing
        Me.asiento_tipo = Nothing
        Me.asiento_numero = Nothing
        Me.asiento_fecha = Nothing
        Me.cuenta_comercial = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_fecha_traslado = Nothing
        Me.almacen = Nothing
        Me.almacen_destino = Nothing
        Me.centro_distribucion = Nothing
        Me.domicilio_envio = Nothing
        Me.referencia_cuo = Nothing
        Me.motivo_traslado = Nothing
        Me.punto_partida = Nothing
        Me.punto_llegada = Nothing
        Me.destinatario_tipo_documento = Nothing
        Me.destinatario_nro_documento = Nothing
        Me.destinatario_razon_social = Nothing

        Me.conductor_dni = Nothing
        Me.conductor_nombre = Nothing

        Me.numero_placa = Nothing
        Me.transportista_ruc = Nothing
        Me.transportista_razon_social = Nothing
        Me.comentario = Nothing

        Me.indica_transporte_publico = Nothing

        Me.indica_impreso = Nothing
        Me.indica_exportacion = Nothing
        Me.indica_migrado = Nothing

        Me.usuario_envio = Nothing
        Me.fecha_envio = Nothing
        Me.estado_envio = Nothing
        Me.usuario_recepcion = Nothing
        Me.fecha_recepcion = Nothing
        Me.comentario_recepion = Nothing
        Me.estado_traslado_interno = Nothing

        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.indica_total_facturado = Nothing

        Me.nota = Nothing

        Me.tipo_operacion_nombre = Nothing

        Me.tipo_documento = Nothing
        Me.nro_documento = Nothing
        Me.razon_social = Nothing

        Me.ubigeo_origen = Nothing
        Me.ubigeo_destino = Nothing

        Me.referencia = Nothing

    End Sub

    Public Sub New(ByVal Guia As entGuia)

        With Guia
            m_empresa = .empresa
            m_guia = .guia
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_tipo_operacion = .tipo_operacion
            m_orden_pedido = .orden_pedido
            m_venta = .venta
            m_asiento_tipo = .asiento_tipo
            m_asiento_numero = .asiento_numero
            m_asiento_fecha = .asiento_fecha
            m_cuenta_comercial = .cuenta_comercial
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_fecha_traslado = .comprobante_fecha_traslado
            m_almacen = .almacen
            m_almacen_destino = .almacen_destino
            m_centro_distribucion = .centro_distribucion
            m_domicilio_envio = .domicilio_envio
            m_referencia_cuo = .referencia_cuo
            m_motivo_traslado = .motivo_traslado
            m_punto_partida = .punto_partida
            m_punto_llegada = .punto_llegada
            m_destinatario_tipo_documento = .destinatario_tipo_documento
            m_destinatario_nro_documento = .destinatario_nro_documento
            m_destinatario_razon_social = .destinatario_razon_social

            m_conductor_dni = .conductor_dni
            m_conductor_nombre = .conductor_nombre

            m_numero_placa = .numero_placa
            m_transportista_ruc = .transportista_ruc
            m_transportista_razon_social = .transportista_razon_social
            m_comentario = .comentario

            m_indica_transporte_publico = .indica_transporte_publico

            m_indica_impreso = .indica_impreso
            m_indica_exportacion = .indica_exportacion
            m_indica_migrado = .indica_migrado

            m_usuario_envio = .usuario_envio
            m_fecha_envio = .fecha_envio
            m_estado_envio = .estado_envio
            m_usuario_recepcion = .usuario_recepcion
            m_fecha_recepcion = .fecha_recepcion
            m_comentario_recepion = .comentario_recepion
            m_estado_traslado_interno = .estado_traslado_interno

            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_indica_total_facturado = .indica_total_facturado

            m_nota = .nota

            m_tipo_operacion_nombre = .tipo_operacion_nombre

            m_tipo_documento = .tipo_documento
            m_nro_documento = .nro_documento
            m_razon_social = .razon_social

            m_ubigeo_origen = .ubigeo_origen
            m_ubigeo_destino = .ubigeo_destino

            m_referencia = .referencia

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

    Public Property guia() As String
        Get
            Return m_guia
        End Get
        Set(ByVal value As String)
            m_guia = value
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

    Public Property tipo_operacion() As String
        Get
            Return m_tipo_operacion
        End Get
        Set(ByVal value As String)
            m_tipo_operacion = IIf(String.IsNullOrEmpty(value), "G1", value)
        End Set
    End Property

    Public Property orden_pedido() As String
        Get
            Return m_orden_pedido
        End Get
        Set(ByVal value As String)
            m_orden_pedido = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property asiento_tipo() As String
        Get
            Return m_asiento_tipo
        End Get
        Set(ByVal value As String)
            m_asiento_tipo = IIf(String.IsNullOrEmpty(value), "05", value)
        End Set
    End Property

    Public Property asiento_numero() As String
        Get
            Return m_asiento_numero
        End Get
        Set(ByVal value As String)
            m_asiento_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property asiento_fecha() As Date
        Get
            Return m_asiento_fecha
        End Get
        Set(ByVal value As Date)
            m_asiento_fecha = IIf(value.Ticks = 0, FechaNulo, value)
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
            m_comprobante_tipo = IIf(String.IsNullOrEmpty(value), "09", value)
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

    Public Property comprobante_fecha_traslado() As Date
        Get
            Return m_comprobante_fecha_traslado
        End Get
        Set(ByVal value As Date)
            m_comprobante_fecha_traslado = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = IIf(String.IsNullOrEmpty(value), "001", value)
        End Set
    End Property

    Public Property almacen_destino() As String
        Get
            Return m_almacen_destino
        End Get
        Set(ByVal value As String)
            m_almacen_destino = IIf(String.IsNullOrEmpty(value), "001", value)
        End Set
    End Property

    Public Property centro_distribucion() As String
        Get
            Return m_centro_distribucion
        End Get
        Set(ByVal value As String)
            m_centro_distribucion = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property domicilio_envio() As String
        Get
            Return m_domicilio_envio
        End Get
        Set(ByVal value As String)
            m_domicilio_envio = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property referencia_cuo() As String
        Get
            Return m_referencia_cuo
        End Get
        Set(ByVal value As String)
            m_referencia_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
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

    Public Property numero_placa() As String
        Get
            Return m_numero_placa
        End Get
        Set(ByVal value As String)
            m_numero_placa = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property indica_impreso() As String
        Get
            Return m_indica_impreso
        End Get
        Set(ByVal value As String)
            m_indica_impreso = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_exportacion() As String
        Get
            Return m_indica_exportacion
        End Get
        Set(ByVal value As String)
            m_indica_exportacion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_migrado() As String
        Get
            Return m_indica_migrado
        End Get
        Set(ByVal value As String)
            m_indica_migrado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property punto_partida() As String
        Get
            Return m_punto_partida
        End Get
        Set(ByVal value As String)
            m_punto_partida = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property punto_llegada() As String
        Get
            Return m_punto_llegada
        End Get
        Set(ByVal value As String)
            m_punto_llegada = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property destinatario_razon_social() As String
        Get
            Return m_destinatario_razon_social
        End Get
        Set(ByVal value As String)
            m_destinatario_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property destinatario_tipo_documento() As String
        Get
            Return m_destinatario_tipo_documento
        End Get
        Set(ByVal value As String)
            m_destinatario_tipo_documento = IIf(String.IsNullOrEmpty(value), "6", value)
        End Set
    End Property

    Public Property destinatario_nro_documento() As String
        Get
            Return m_destinatario_nro_documento
        End Get
        Set(ByVal value As String)
            m_destinatario_nro_documento = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property indica_total_facturado() As String
        Get
            Return m_indica_total_facturado
        End Get
        Set(ByVal value As String)
            m_indica_total_facturado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property conductor_dni() As String
        Get
            Return m_conductor_dni
        End Get
        Set(ByVal value As String)
            m_conductor_dni = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property conductor_nombre() As String
        Get
            Return m_conductor_nombre
        End Get
        Set(ByVal value As String)
            m_conductor_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property transportista_ruc() As String
        Get
            Return m_transportista_ruc
        End Get
        Set(ByVal value As String)
            m_transportista_ruc = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property transportista_razon_social() As String
        Get
            Return m_transportista_razon_social
        End Get
        Set(ByVal value As String)
            m_transportista_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property indica_transporte_publico() As String
        Get
            Return m_indica_transporte_publico
        End Get
        Set(ByVal value As String)
            m_indica_transporte_publico = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property estado_traslado_interno() As String
        Get
            Return m_estado_traslado_interno
        End Get
        Set(ByVal value As String)
            m_estado_traslado_interno = IIf(String.IsNullOrEmpty(value), "P", value)
        End Set
    End Property

    Public Property usuario_envio() As String
        Get
            Return m_usuario_envio
        End Get
        Set(ByVal value As String)
            m_usuario_envio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_envio() As Date
        Get
            Return m_fecha_envio
        End Get
        Set(ByVal value As Date)
            m_fecha_envio = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property estado_envio() As String
        Get
            Return m_estado_envio
        End Get
        Set(ByVal value As String)
            m_estado_envio = IIf(String.IsNullOrEmpty(value), "P", value)
        End Set
    End Property

    Public Property usuario_recepcion() As String
        Get
            Return m_usuario_recepcion
        End Get
        Set(ByVal value As String)
            m_usuario_recepcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_recepcion() As Date
        Get
            Return m_fecha_recepcion
        End Get
        Set(ByVal value As Date)
            m_fecha_recepcion = IIf(String.IsNullOrEmpty(value), FechaNulo, value)
        End Set
    End Property

    Public Property comentario_recepion() As String
        Get
            Return m_comentario_recepion
        End Get
        Set(ByVal value As String)
            m_comentario_recepion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property nota() As String
        Get
            Return m_nota
        End Get
        Set(ByVal value As String)
            m_nota = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_operacion_nombre() As String
        Get
            Return m_tipo_operacion_nombre
        End Get
        Set(ByVal value As String)
            m_tipo_operacion_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_documento() As String
        Get
            Return m_tipo_documento
        End Get
        Set(ByVal value As String)
            m_tipo_documento = IIf(String.IsNullOrEmpty(value), "6", value)
        End Set
    End Property

    Public Property nro_documento() As String
        Get
            Return m_nro_documento
        End Get
        Set(ByVal value As String)
            m_nro_documento = IIf(String.IsNullOrEmpty(value), "-", value)
        End Set
    End Property

    Public Property razon_social() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ubigeo_origen() As String
        Get
            Return m_ubigeo_origen
        End Get
        Set(ByVal value As String)
            m_ubigeo_origen = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ubigeo_destino() As String
        Get
            Return m_ubigeo_destino
        End Get
        Set(ByVal value As String)
            m_ubigeo_destino = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property referencia() As String
        Get
            Return m_referencia
        End Get
        Set(ByVal value As String)
            m_referencia = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

End Class
