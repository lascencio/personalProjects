Public Class entProspecto
    Private m_empresa As String
    Private m_prospecto As String
    Private m_version As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_descripcion As String
    Private m_cuenta_comercial As String
    Private m_marca As String
    Private m_cuenta_comercial_descripcion As String
    Private m_marca_descripcion As String
    Private m_tipo_servicio As String
    Private m_tipo_servicio_descripcion As String
    Private m_responsable_venta As String
    Private m_responsable_ejecucion As String
    Private m_responsable_ejecucion_descripcion As String
    Private m_probabilidad As String
    Private m_etapa As String
    Private m_fecha_inicio As Date
    Private m_fecha_aprobacion As Date
    Private m_fecha_entrega As Date
    Private m_fecha_aceptacion As Date
    Private m_periodo_inicio As String
    Private m_periodo_cierre As String
    Private m_tipo_moneda As String
    Private m_monto_total As Decimal
    Private m_contacto_comercial As String
    Private m_costo_bienes As Decimal
    Private m_costo_subcontratas As Decimal
    Private m_gastos_generales As Decimal
    Private m_gastos_inversion As Decimal
    Private m_gastos_financiamiento As Decimal
    Private m_costos_laborales As Decimal
    Private m_overhead As Decimal
    Private m_margen_comercial As Decimal
    Private m_margen_costo_proveedor As Decimal
    Private m_comision_costo_proveedor As Decimal
    Private m_costos_cloud As Decimal
    Private m_overhead_cloud As Decimal
    Private m_margen_comercial_cloud As Decimal
    Private m_tipo_orden As String
    Private m_codigo_proyecto As String
    Private m_ultima_facturacion As String
    Private m_pendiente_facturar As Decimal
    Private m_fecha_encuesta As Date
    Private m_usuario_encuesta As String
    Private m_valorizacion_encuesta As Decimal
    Private m_comentario As String
    Private m_origen As String
    Private m_estado As String
    Private m_estado_descripcion As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date
    Private m_prefijo As String

    Public Sub New()
        Me.empresa = Nothing
        Me.prospecto = Nothing
        Me.version = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.descripcion = Nothing
        Me.cuenta_comercial = Nothing
        Me.marca = Nothing
        Me.cuenta_comercial_descripcion = Nothing
        Me.marca_descripcion = Nothing
        Me.tipo_servicio = Nothing
        Me.tipo_servicio_descripcion = Nothing
        Me.responsable_venta = Nothing
        Me.responsable_ejecucion = Nothing
        Me.responsable_ejecucion_descripcion = Nothing
        Me.probabilidad = Nothing
        Me.etapa = Nothing
        Me.fecha_inicio = Nothing
        Me.fecha_aprobacion = Nothing
        Me.fecha_entrega = Nothing
        Me.fecha_aceptacion = Nothing
        Me.periodo_inicio = Nothing
        Me.periodo_cierre = Nothing
        Me.tipo_moneda = Nothing
        Me.monto_total = Nothing
        Me.contacto_comercial = Nothing
        Me.costo_bienes = Nothing
        Me.costo_subcontratas = Nothing
        Me.gastos_generales = Nothing
        Me.gastos_inversion = Nothing
        Me.gastos_financiamiento = Nothing
        Me.costos_laborales = Nothing
        Me.overhead = Nothing
        Me.margen_comercial = Nothing
        Me.margen_costo_proveedor = Nothing
        Me.comision_costo_proveedor = Nothing
        Me.costos_cloud = Nothing
        Me.overhead_cloud = Nothing
        Me.margen_comercial_cloud = Nothing
        Me.tipo_orden = Nothing
        Me.codigo_proyecto = Nothing
        Me.ultima_facturacion = Nothing
        Me.pendiente_facturar = Nothing
        Me.fecha_encuesta = Nothing
        Me.usuario_encuesta = Nothing
        Me.valorizacion_encuesta = Nothing
        Me.comentario = Nothing
        Me.origen = Nothing
        Me.estado = Nothing
        Me.estado_descripcion = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
        Me.prefijo = Nothing
    End Sub

    Public Sub New(ByVal Prospecto As entProspecto)
        With Prospecto
            m_empresa = .empresa
            m_prospecto = .prospecto
            m_version = .version
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_descripcion = .descripcion
            m_cuenta_comercial = .cuenta_comercial
            m_marca = .marca
            m_cuenta_comercial_descripcion = .cuenta_comercial_descripcion
            m_marca_descripcion = .marca_descripcion
            m_tipo_servicio = .tipo_servicio
            m_tipo_servicio_descripcion = .tipo_servicio_descripcion
            m_responsable_venta = .responsable_venta
            m_responsable_ejecucion = .responsable_ejecucion
            m_responsable_ejecucion_descripcion = .responsable_ejecucion_descripcion
            m_probabilidad = .probabilidad
            m_etapa = .etapa
            m_fecha_inicio = .fecha_inicio
            m_fecha_aprobacion = .fecha_aprobacion
            m_fecha_entrega = .fecha_entrega
            m_fecha_aceptacion = .fecha_aceptacion
            m_periodo_inicio = .periodo_inicio
            m_periodo_cierre = .periodo_cierre
            m_tipo_moneda = .tipo_moneda
            m_contacto_comercial = .contacto_comercial
            m_monto_total = .monto_total
            m_costo_bienes = .costo_bienes
            m_costo_subcontratas = .costo_subcontratas
            m_gastos_generales = .gastos_generales
            m_gastos_inversion = .gastos_inversion
            m_gastos_financiamiento = .gastos_financiamiento
            m_costos_laborales = .costos_laborales
            m_overhead = .overhead
            m_margen_comercial = .margen_comercial
            m_margen_costo_proveedor = .margen_costo_proveedor
            m_comision_costo_proveedor = .comision_costo_proveedor
            m_costos_cloud = .costos_cloud
            m_overhead_cloud = .overhead_cloud
            m_margen_comercial_cloud = .margen_comercial_cloud
            m_tipo_orden = .tipo_orden
            m_codigo_proyecto = .codigo_proyecto
            m_ultima_facturacion = .ultima_facturacion
            m_pendiente_facturar = .pendiente_facturar
            fecha_encuesta = .fecha_encuesta
            m_usuario_encuesta = .usuario_encuesta
            m_valorizacion_encuesta = .valorizacion_encuesta
            m_comentario = .comentario
            m_origen = .origen
            m_estado = .estado
            m_estado_descripcion = .estado_descripcion
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
            m_prefijo = .prefijo
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

    Public Property prospecto() As String
        Get
            Return m_prospecto
        End Get
        Set(ByVal value As String)
            m_prospecto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property version() As String
        Get
            Return m_version
        End Get
        Set(ByVal value As String)
            m_version = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ejercicio() As String
        Get
            Return m_ejercicio
        End Get
        Set(ByVal value As String)
            m_ejercicio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property mes() As String
        Get
            Return m_mes
        End Get
        Set(ByVal value As String)
            m_mes = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property marca() As String
        Get
            Return m_marca
        End Get
        Set(ByVal value As String)
            m_marca = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property cuenta_comercial_descripcion() As String
        Get
            Return m_cuenta_comercial_descripcion
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial_descripcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property marca_descripcion() As String
        Get
            Return m_marca_descripcion
        End Get
        Set(ByVal value As String)
            m_marca_descripcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_servicio() As String
        Get
            Return m_tipo_servicio
        End Get
        Set(ByVal value As String)
            m_tipo_servicio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_servicio_descripcion() As String
        Get
            Return m_tipo_servicio_descripcion
        End Get
        Set(ByVal value As String)
            m_tipo_servicio_descripcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property responsable_venta() As String
        Get
            Return m_responsable_venta
        End Get
        Set(ByVal value As String)
            m_responsable_venta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property responsable_ejecucion() As String
        Get
            Return m_responsable_ejecucion
        End Get
        Set(ByVal value As String)
            m_responsable_ejecucion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property responsable_ejecucion_descripcion() As String
        Get
            Return m_responsable_ejecucion_descripcion
        End Get
        Set(ByVal value As String)
            m_responsable_ejecucion_descripcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property probabilidad() As String
        Get
            Return m_probabilidad
        End Get
        Set(ByVal value As String)
            m_probabilidad = IIf(String.IsNullOrEmpty(value), "BP", value)
        End Set
    End Property

    Public Property etapa() As String
        Get
            Return m_etapa
        End Get
        Set(ByVal value As String)
            m_etapa = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property fecha_inicio() As Date
        Get
            Return m_fecha_inicio
        End Get
        Set(ByVal value As Date)
            m_fecha_inicio = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property fecha_aprobacion() As Date
        Get
            Return m_fecha_aprobacion
        End Get
        Set(ByVal value As Date)
            m_fecha_aprobacion = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property fecha_entrega() As Date
        Get
            Return m_fecha_entrega
        End Get
        Set(ByVal value As Date)
            m_fecha_entrega = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property fecha_aceptacion() As Date
        Get
            Return m_fecha_aceptacion
        End Get
        Set(ByVal value As Date)
            m_fecha_aceptacion = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property periodo_inicio() As String
        Get
            Return m_periodo_inicio
        End Get
        Set(ByVal value As String)
            m_periodo_inicio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property periodo_cierre() As String
        Get
            Return m_periodo_cierre
        End Get
        Set(ByVal value As String)
            m_periodo_cierre = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property monto_total() As Decimal
        Get
            Return m_monto_total
        End Get
        Set(ByVal value As Decimal)
            m_monto_total = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property contacto_comercial() As String
        Get
            Return m_contacto_comercial
        End Get
        Set(ByVal value As String)
            m_contacto_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property costo_bienes() As Decimal
        Get
            Return m_costo_bienes
        End Get
        Set(ByVal value As Decimal)
            m_costo_bienes = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property costo_subcontratas() As Decimal
        Get
            Return m_costo_subcontratas
        End Get
        Set(ByVal value As Decimal)
            m_costo_subcontratas = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property gastos_generales() As Decimal
        Get
            Return m_gastos_generales
        End Get
        Set(ByVal value As Decimal)
            m_gastos_generales = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property gastos_inversion() As Decimal
        Get
            Return m_gastos_inversion
        End Get
        Set(ByVal value As Decimal)
            m_gastos_inversion = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property gastos_financiamiento() As Decimal
        Get
            Return m_gastos_financiamiento
        End Get
        Set(ByVal value As Decimal)
            m_gastos_financiamiento = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property costos_laborales() As Decimal
        Get
            Return m_costos_laborales
        End Get
        Set(ByVal value As Decimal)
            m_costos_laborales = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property overhead() As Decimal
        Get
            Return m_overhead
        End Get
        Set(ByVal value As Decimal)
            m_overhead = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property margen_comercial() As Decimal
        Get
            Return m_margen_comercial
        End Get
        Set(ByVal value As Decimal)
            m_margen_comercial = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property margen_costo_proveedor() As Decimal
        Get
            Return m_margen_costo_proveedor
        End Get
        Set(ByVal value As Decimal)
            m_margen_costo_proveedor = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property comision_costo_proveedor() As Decimal
        Get
            Return m_comision_costo_proveedor
        End Get
        Set(ByVal value As Decimal)
            m_comision_costo_proveedor = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property costos_cloud() As Decimal
        Get
            Return m_costos_cloud
        End Get
        Set(ByVal value As Decimal)
            m_costos_cloud = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property overhead_cloud() As Decimal
        Get
            Return m_overhead_cloud
        End Get
        Set(ByVal value As Decimal)
            m_overhead_cloud = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property margen_comercial_cloud() As Decimal
        Get
            Return m_margen_comercial_cloud
        End Get
        Set(ByVal value As Decimal)
            m_margen_comercial_cloud = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property tipo_orden() As String
        Get
            Return m_tipo_orden
        End Get
        Set(ByVal value As String)
            m_tipo_orden = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property codigo_proyecto() As String
        Get
            Return m_codigo_proyecto
        End Get
        Set(ByVal value As String)
            m_codigo_proyecto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ultima_facturacion() As String
        Get
            Return m_ultima_facturacion
        End Get
        Set(ByVal value As String)
            m_ultima_facturacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pendiente_facturar() As Decimal
        Get
            Return m_pendiente_facturar
        End Get
        Set(ByVal value As Decimal)
            m_pendiente_facturar = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property fecha_encuesta() As Date
        Get
            Return m_fecha_encuesta
        End Get
        Set(ByVal value As Date)
            m_fecha_encuesta = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property usuario_encuesta() As String
        Get
            Return m_usuario_encuesta
        End Get
        Set(ByVal value As String)
            m_usuario_encuesta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property valorizacion_encuesta() As Decimal
        Get
            Return m_valorizacion_encuesta
        End Get
        Set(ByVal value As Decimal)
            m_valorizacion_encuesta = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property origen() As String
        Get
            Return m_origen
        End Get
        Set(ByVal value As String)
            m_origen = IIf(String.IsNullOrEmpty(value), "SIS", value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "P", value)
        End Set
    End Property

    Public Property estado_descripcion() As String
        Get
            Return m_estado_descripcion
        End Get
        Set(ByVal value As String)
            m_estado_descripcion = IIf(String.IsNullOrEmpty(value), "PENDIENTE", value)
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
            m_fecha_registro = IIf(value = "#12:00:00 AM#", FechaNulo, value)
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
            m_fecha_modifica = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

    Public Property prefijo() As String
        Get
            Return m_prefijo
        End Get
        Set(ByVal value As String)
            m_prefijo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

End Class
