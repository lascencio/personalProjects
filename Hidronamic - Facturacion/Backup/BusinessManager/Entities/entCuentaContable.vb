Public Class entCuentaContable

    Private m_empresa As String
    Private m_cuenta_contable As String
    Private m_nombre_cuenta_contable As String
    Private m_cuenta_equivalente As String
    Private m_nombre_cuenta_equivalente As String
    Private m_tipo_cuenta As String
    Private m_indica_movimiento As String
    Private m_indica_conciliacion As String
    Private m_indica_moneda_extranjera As String
    Private m_indica_cuenta_corriente As String
    Private m_indica_documento_tipo As String
    Private m_indica_documento_serie As String
    Private m_indica_documento_numero As String
    Private m_indica_documento_fecha As String
    Private m_indica_documento_vencimiento As String
    Private m_indica_documento_rellenar As String
    Private m_indica_tabla_gastos_funcion As String
    Private m_indica_tabla_centro_costo As String
    Private m_indica_tabla_item_flujo As String
    Private m_indica_tabla_item_gasto As String
    Private m_indica_tabla_area_negocio As String
    Private m_indica_tabla_linea_negocio As String
    Private m_indica_tabla_proyecto As String
    Private m_indica_tabla_zona As String
    Private m_indica_tabla_vendedor As String
    Private m_indica_tabla_comprador As String
    Private m_indica_tabla_transportista As String
    Private m_indica_analisis_01 As String
    Private m_indica_analisis_02 As String
    Private m_indica_analisis_03 As String
    Private m_indica_analisis_04 As String
    Private m_indica_analisis_05 As String
    Private m_indica_analisis_06 As String
    Private m_indica_analisis_07 As String
    Private m_indica_analisis_08 As String
    Private m_indica_analisis_09 As String
    Private m_indica_analisis_10 As String
    Private m_generar_destino_automatico As String
    Private m_tipo_tabla_cuenta_corriente As String
    Private m_tipo_tabla_documento As String
    Private m_item_flujo As String
    Private m_item_gasto As String
    Private m_partida_presupuestal As String
    Private m_cuenta_cargo As String
    Private m_cuenta_abono As String
    Private m_aplicable_compras As String
    Private m_aplicable_ventas As String
    Private m_aplicable_ingresos As String
    Private m_aplicable_egresos As String
    Private m_aplicable_honorarios As String
    Private m_aplicable_planillas As String
    Private m_indica_cuenta_compra As String
    Private m_indica_cuenta_venta As String
    Private m_indica_cuenta_costo As String
    Private m_indica_cuenta_reparable As String
    Private m_estado As String
    Private m_usuario_registro As String = "SISTEMAS"
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String = " "
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.cuenta_contable = Nothing
        Me.cuenta_equivalente = Nothing
        Me.cuenta_equivalente = Nothing
        Me.nombre_cuenta_equivalente = Nothing
        Me.tipo_cuenta = Nothing
        Me.indica_movimiento = Nothing
        Me.indica_conciliacion = Nothing
        Me.indica_moneda_extranjera = Nothing
        Me.indica_cuenta_corriente = Nothing
        Me.indica_documento_tipo = Nothing
        Me.indica_documento_serie = Nothing
        Me.indica_documento_numero = Nothing
        Me.indica_documento_fecha = Nothing
        Me.indica_documento_vencimiento = Nothing
        Me.indica_documento_rellenar = Nothing
        Me.indica_tabla_gastos_funcion = Nothing
        Me.indica_tabla_centro_costo = Nothing
        Me.indica_tabla_item_flujo = Nothing
        Me.indica_tabla_item_gasto = Nothing
        Me.indica_tabla_area_negocio = Nothing
        Me.indica_tabla_linea_negocio = Nothing
        Me.indica_tabla_proyecto = Nothing
        Me.indica_tabla_zona = Nothing
        Me.indica_tabla_vendedor = Nothing
        Me.indica_tabla_comprador = Nothing
        Me.indica_tabla_transportista = Nothing
        Me.indica_analisis_01 = Nothing
        Me.indica_analisis_02 = Nothing
        Me.indica_analisis_03 = Nothing
        Me.indica_analisis_04 = Nothing
        Me.indica_analisis_05 = Nothing
        Me.indica_analisis_06 = Nothing
        Me.indica_analisis_07 = Nothing
        Me.indica_analisis_08 = Nothing
        Me.indica_analisis_09 = Nothing
        Me.indica_analisis_10 = Nothing
        Me.generar_destino_automatico = Nothing
        Me.tipo_tabla_cuenta_corriente = Nothing
        Me.tipo_tabla_documento = Nothing
        Me.item_flujo = Nothing
        Me.item_gasto = Nothing
        Me.partida_presupuestal = Nothing
        Me.cuenta_cargo = Nothing
        Me.cuenta_abono = Nothing
        Me.aplicable_compras = Nothing
        Me.aplicable_ventas = Nothing
        Me.aplicable_ingresos = Nothing
        Me.aplicable_egresos = Nothing
        Me.aplicable_honorarios = Nothing
        Me.aplicable_planillas = Nothing
        Me.indica_cuenta_compra = Nothing
        Me.indica_cuenta_venta = Nothing
        Me.indica_cuenta_costo = Nothing
        Me.indica_cuenta_reparable = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal CuentasContables As entCuentaContable)
        With CuentasContables
            m_empresa = .empresa
            m_cuenta_contable = .cuenta_contable
            m_nombre_cuenta_contable = .cuenta_equivalente
            m_cuenta_equivalente = .cuenta_equivalente
            m_nombre_cuenta_equivalente = .nombre_cuenta_equivalente
            m_tipo_cuenta = .tipo_cuenta
            m_indica_movimiento = .indica_movimiento
            m_indica_conciliacion = .indica_conciliacion
            m_indica_moneda_extranjera = .indica_moneda_extranjera
            m_indica_cuenta_corriente = .indica_cuenta_corriente
            m_indica_documento_tipo = .indica_documento_tipo
            m_indica_documento_serie = .indica_documento_serie
            m_indica_documento_numero = .indica_documento_numero
            m_indica_documento_fecha = .indica_documento_fecha
            m_indica_documento_vencimiento = .indica_documento_vencimiento
            m_indica_documento_rellenar = .indica_documento_rellenar
            m_indica_tabla_gastos_funcion = .indica_tabla_gastos_funcion
            m_indica_tabla_centro_costo = .indica_tabla_centro_costo
            m_indica_tabla_item_flujo = .indica_tabla_item_flujo
            m_indica_tabla_item_gasto = .indica_tabla_item_gasto
            m_indica_tabla_area_negocio = .indica_tabla_area_negocio
            m_indica_tabla_linea_negocio = .indica_tabla_linea_negocio
            m_indica_tabla_proyecto = .indica_tabla_proyecto
            m_indica_tabla_zona = .indica_tabla_zona
            m_indica_tabla_vendedor = .indica_tabla_vendedor
            m_indica_tabla_comprador = .indica_tabla_comprador
            m_indica_tabla_transportista = .indica_tabla_transportista
            m_indica_analisis_01 = .indica_analisis_01
            m_indica_analisis_02 = .indica_analisis_02
            m_indica_analisis_03 = .indica_analisis_03
            m_indica_analisis_04 = .indica_analisis_04
            m_indica_analisis_05 = .indica_analisis_05
            m_indica_analisis_06 = .indica_analisis_06
            m_indica_analisis_07 = .indica_analisis_07
            m_indica_analisis_08 = .indica_analisis_08
            m_indica_analisis_09 = .indica_analisis_09
            m_indica_analisis_10 = .indica_analisis_10
            m_generar_destino_automatico = .generar_destino_automatico
            m_tipo_tabla_cuenta_corriente = .tipo_tabla_cuenta_corriente
            m_tipo_tabla_documento = .tipo_tabla_documento
            m_item_flujo = .item_flujo
            m_item_gasto = .item_gasto
            m_partida_presupuestal = .partida_presupuestal
            m_cuenta_cargo = .cuenta_cargo
            m_cuenta_abono = .cuenta_abono
            m_aplicable_compras = .aplicable_compras
            m_aplicable_ventas = .aplicable_ventas
            m_aplicable_ingresos = .aplicable_ingresos
            m_aplicable_egresos = .aplicable_egresos
            m_aplicable_honorarios = .aplicable_honorarios
            m_aplicable_planillas = .aplicable_planillas
            m_indica_cuenta_compra = .indica_cuenta_compra
            m_indica_cuenta_venta = .indica_cuenta_venta
            m_indica_cuenta_costo = .indica_cuenta_costo
            m_indica_cuenta_reparable = .indica_cuenta_reparable
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

    Public Property cuenta_contable() As String
        Get
            Return m_cuenta_contable
        End Get
        Set(ByVal value As String)
            m_cuenta_contable = value
        End Set
    End Property

    Public Property nombre_cuenta_contable() As String
        Get
            Return m_nombre_cuenta_contable
        End Get
        Set(ByVal value As String)
            m_nombre_cuenta_contable = value
        End Set
    End Property

    Public Property cuenta_equivalente() As String
        Get
            Return m_cuenta_equivalente
        End Get
        Set(ByVal value As String)
            m_cuenta_equivalente = value
        End Set
    End Property

    Public Property nombre_cuenta_equivalente() As String
        Get
            Return m_nombre_cuenta_equivalente
        End Get
        Set(ByVal value As String)
            m_nombre_cuenta_equivalente = value
        End Set
    End Property

    Public Property tipo_cuenta() As String
        Get
            Return m_tipo_cuenta
        End Get
        Set(ByVal value As String)
            m_tipo_cuenta = IIf(String.IsNullOrEmpty(value), "1", value)
        End Set
    End Property

    Public Property indica_movimiento() As String
        Get
            Return m_indica_movimiento
        End Get
        Set(ByVal value As String)
            m_indica_movimiento = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_conciliacion() As String
        Get
            Return m_indica_conciliacion
        End Get
        Set(ByVal value As String)
            m_indica_conciliacion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_moneda_extranjera() As String
        Get
            Return m_indica_moneda_extranjera
        End Get
        Set(ByVal value As String)
            m_indica_moneda_extranjera = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_cuenta_corriente() As String
        Get
            Return m_indica_cuenta_corriente
        End Get
        Set(ByVal value As String)
            m_indica_cuenta_corriente = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_tipo() As String
        Get
            Return m_indica_documento_tipo
        End Get
        Set(ByVal value As String)
            m_indica_documento_tipo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_serie() As String
        Get
            Return m_indica_documento_serie
        End Get
        Set(ByVal value As String)
            m_indica_documento_serie = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_numero() As String
        Get
            Return m_indica_documento_numero
        End Get
        Set(ByVal value As String)
            m_indica_documento_numero = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_fecha() As String
        Get
            Return m_indica_documento_fecha
        End Get
        Set(ByVal value As String)
            m_indica_documento_fecha = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_vencimiento() As String
        Get
            Return m_indica_documento_vencimiento
        End Get
        Set(ByVal value As String)
            m_indica_documento_vencimiento = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_documento_rellenar() As String
        Get
            Return m_indica_documento_rellenar
        End Get
        Set(ByVal value As String)
            m_indica_documento_rellenar = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_gastos_funcion() As String
        Get
            Return m_indica_tabla_gastos_funcion
        End Get
        Set(ByVal value As String)
            m_indica_tabla_gastos_funcion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_centro_costo() As String
        Get
            Return m_indica_tabla_centro_costo
        End Get
        Set(ByVal value As String)
            m_indica_tabla_centro_costo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_item_flujo() As String
        Get
            Return m_indica_tabla_item_flujo
        End Get
        Set(ByVal value As String)
            m_indica_tabla_item_flujo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_item_gasto() As String
        Get
            Return m_indica_tabla_item_gasto
        End Get
        Set(ByVal value As String)
            m_indica_tabla_item_gasto = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_area_negocio() As String
        Get
            Return m_indica_tabla_area_negocio
        End Get
        Set(ByVal value As String)
            m_indica_tabla_area_negocio = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_linea_negocio() As String
        Get
            Return m_indica_tabla_linea_negocio
        End Get
        Set(ByVal value As String)
            m_indica_tabla_linea_negocio = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_proyecto() As String
        Get
            Return m_indica_tabla_proyecto
        End Get
        Set(ByVal value As String)
            m_indica_tabla_proyecto = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_zona() As String
        Get
            Return m_indica_tabla_zona
        End Get
        Set(ByVal value As String)
            m_indica_tabla_zona = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_vendedor() As String
        Get
            Return m_indica_tabla_vendedor
        End Get
        Set(ByVal value As String)
            m_indica_tabla_vendedor = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_comprador() As String
        Get
            Return m_indica_tabla_comprador
        End Get
        Set(ByVal value As String)
            m_indica_tabla_comprador = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_tabla_transportista() As String
        Get
            Return m_indica_tabla_transportista
        End Get
        Set(ByVal value As String)
            m_indica_tabla_transportista = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_01() As String
        Get
            Return m_indica_analisis_01
        End Get
        Set(ByVal value As String)
            m_indica_analisis_01 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_02() As String
        Get
            Return m_indica_analisis_02
        End Get
        Set(ByVal value As String)
            m_indica_analisis_02 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_03() As String
        Get
            Return m_indica_analisis_03
        End Get
        Set(ByVal value As String)
            m_indica_analisis_03 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_04() As String
        Get
            Return m_indica_analisis_04
        End Get
        Set(ByVal value As String)
            m_indica_analisis_04 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_05() As String
        Get
            Return m_indica_analisis_05
        End Get
        Set(ByVal value As String)
            m_indica_analisis_05 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_06() As String
        Get
            Return m_indica_analisis_06
        End Get
        Set(ByVal value As String)
            m_indica_analisis_06 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_07() As String
        Get
            Return m_indica_analisis_07
        End Get
        Set(ByVal value As String)
            m_indica_analisis_07 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_08() As String
        Get
            Return m_indica_analisis_08
        End Get
        Set(ByVal value As String)
            m_indica_analisis_08 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_09() As String
        Get
            Return m_indica_analisis_09
        End Get
        Set(ByVal value As String)
            m_indica_analisis_09 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_analisis_10() As String
        Get
            Return m_indica_analisis_10
        End Get
        Set(ByVal value As String)
            m_indica_analisis_10 = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property generar_destino_automatico() As String
        Get
            Return m_generar_destino_automatico
        End Get
        Set(ByVal value As String)
            m_generar_destino_automatico = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property tipo_tabla_cuenta_corriente() As String
        Get
            Return m_tipo_tabla_cuenta_corriente
        End Get
        Set(ByVal value As String)
            m_tipo_tabla_cuenta_corriente = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_tabla_documento() As String
        Get
            Return m_tipo_tabla_documento
        End Get
        Set(ByVal value As String)
            m_tipo_tabla_documento = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property item_flujo() As String
        Get
            Return m_item_flujo
        End Get
        Set(ByVal value As String)
            m_item_flujo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property item_gasto() As String
        Get
            Return m_item_gasto
        End Get
        Set(ByVal value As String)
            m_item_gasto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property partida_presupuestal() As String
        Get
            Return m_partida_presupuestal
        End Get
        Set(ByVal value As String)
            m_partida_presupuestal = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_cargo() As String
        Get
            Return m_cuenta_cargo
        End Get
        Set(ByVal value As String)
            m_cuenta_cargo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_abono() As String
        Get
            Return m_cuenta_abono
        End Get
        Set(ByVal value As String)
            m_cuenta_abono = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property aplicable_compras() As String
        Get
            Return m_aplicable_compras
        End Get
        Set(ByVal value As String)
            m_aplicable_compras = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property aplicable_ventas() As String
        Get
            Return m_aplicable_ventas
        End Get
        Set(ByVal value As String)
            m_aplicable_ventas = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property aplicable_ingresos() As String
        Get
            Return m_aplicable_ingresos
        End Get
        Set(ByVal value As String)
            m_aplicable_ingresos = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property aplicable_egresos() As String
        Get
            Return m_aplicable_egresos
        End Get
        Set(ByVal value As String)
            m_aplicable_egresos = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property aplicable_honorarios() As String
        Get
            Return m_aplicable_honorarios
        End Get
        Set(ByVal value As String)
            m_aplicable_honorarios = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property aplicable_planillas() As String
        Get
            Return m_aplicable_planillas
        End Get
        Set(ByVal value As String)
            m_aplicable_planillas = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_cuenta_compra() As String
        Get
            Return m_indica_cuenta_compra
        End Get
        Set(ByVal value As String)
            m_indica_cuenta_compra = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_cuenta_venta() As String
        Get
            Return m_indica_cuenta_venta
        End Get
        Set(ByVal value As String)
            m_indica_cuenta_venta = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_cuenta_costo() As String
        Get
            Return m_indica_cuenta_costo
        End Get
        Set(ByVal value As String)
            m_indica_cuenta_costo = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property indica_cuenta_reparable() As String
        Get
            Return m_indica_cuenta_reparable
        End Get
        Set(ByVal value As String)
            m_indica_cuenta_reparable = IIf(String.IsNullOrEmpty(value), "NO", value)
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
        Set(ByVal value As DateTime)
            m_fecha_registro = value
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
        Set(ByVal value As DateTime)
            m_fecha_modifica = value
        End Set
    End Property

End Class
