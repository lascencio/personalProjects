Public Class entAsientoContableDetalle

    Private m_empresa As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_asiento_tipo As String
    Private m_asiento_numero As String
    Private m_asiento_linea As String
    Private m_asiento_fecha As Date
    Private m_cuenta_contable As String
    Private m_tipo_moneda As String
    Private m_tipo_cambio As Decimal
    Private m_glosa As String
    Private m_cuenta_corriente As String
    Private m_comprobante_tipo As String
    Private m_comprobante_serie As String
    Private m_comprobante_numero As String
    Private m_comprobante_fecha As Date
    Private m_comprobante_vencimiento As Date
    Private m_debe_origen As Decimal
    Private m_haber_origen As Decimal
    Private m_debe_mn As Decimal
    Private m_haber_mn As Decimal
    Private m_debe_me As Decimal
    Private m_haber_me As Decimal
    Private m_item_gasto As String
    Private m_item_flujo As String
    Private m_gasto_funcion As String
    Private m_centro_costo As String
    Private m_area As String
    Private m_linea_negocio As String
    Private m_proyecto As String
    Private m_zona As String
    Private m_vendedor As String
    Private m_comprador As String
    Private m_transportista As String
    Private m_analisis_01 As String
    Private m_analisis_02 As String
    Private m_analisis_03 As String
    Private m_analisis_04 As String
    Private m_analisis_05 As String
    Private m_analisis_06 As String
    Private m_analisis_07 As String
    Private m_analisis_08 As String
    Private m_analisis_09 As String
    Private m_analisis_10 As String
    Private m_cuenta_bancaria As String
    Private m_indica_conciliado As String
    Private m_ejercicio_conciliado As String
    Private m_mes_conciliado As String
    Private m_tipo_medio_pago As String
    Private m_documento_pago As String
    Private m_fecha_pago As Date
    Private m_indica_en_cartera As String
    Private m_origen As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.asiento_tipo = Nothing
        Me.asiento_numero = Nothing
        Me.asiento_linea = Nothing
        Me.asiento_fecha = Nothing
        Me.cuenta_contable = Nothing
        Me.glosa = Nothing
        Me.tipo_moneda = Nothing
        Me.tipo_cambio = Nothing
        Me.cuenta_corriente = Nothing
        Me.comprobante_tipo = Nothing
        Me.comprobante_serie = Nothing
        Me.comprobante_numero = Nothing
        Me.comprobante_fecha = Nothing
        Me.comprobante_vencimiento = Nothing
        Me.debe_origen = Nothing
        Me.haber_origen = Nothing
        Me.debe_mn = Nothing
        Me.haber_mn = Nothing
        Me.debe_me = Nothing
        Me.haber_me = Nothing
        Me.item_gasto = Nothing
        Me.item_flujo = Nothing
        Me.gasto_funcion = Nothing
        Me.centro_costo = Nothing
        Me.area = Nothing
        Me.linea_negocio = Nothing
        Me.proyecto = Nothing
        Me.zona = Nothing
        Me.vendedor = Nothing
        Me.comprador = Nothing
        Me.transportista = Nothing
        Me.analisis_01 = Nothing
        Me.analisis_02 = Nothing
        Me.analisis_03 = Nothing
        Me.analisis_04 = Nothing
        Me.analisis_05 = Nothing
        Me.analisis_06 = Nothing
        Me.analisis_07 = Nothing
        Me.analisis_08 = Nothing
        Me.analisis_09 = Nothing
        Me.analisis_10 = Nothing
        Me.cuenta_bancaria = Nothing
        Me.indica_conciliado = Nothing
        Me.ejercicio_conciliado = Nothing
        Me.mes_conciliado = Nothing
        Me.tipo_medio_pago = Nothing
        Me.documento_pago = Nothing
        Me.fecha_pago = Nothing
        Me.indica_en_cartera = Nothing
        Me.origen = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal AsientoContableDetalle As entAsientoContableDetalle)

        With AsientoContableDetalle
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_asiento_tipo = .asiento_tipo
            m_asiento_numero = .asiento_numero
            m_asiento_linea = .asiento_linea
            m_asiento_fecha = .asiento_fecha
            m_cuenta_contable = .cuenta_contable
            m_glosa = .glosa
            m_tipo_moneda = .tipo_moneda
            m_tipo_cambio = .tipo_cambio
            m_cuenta_corriente = .cuenta_corriente
            m_comprobante_tipo = .comprobante_tipo
            m_comprobante_serie = .comprobante_serie
            m_comprobante_numero = .comprobante_numero
            m_comprobante_fecha = .comprobante_fecha
            m_comprobante_vencimiento = .comprobante_vencimiento
            m_debe_origen = .debe_origen
            m_haber_origen = .haber_origen
            m_debe_mn = .debe_mn
            m_haber_mn = .haber_mn
            m_debe_me = .debe_me
            m_haber_me = .haber_me
            m_item_gasto = .item_gasto
            m_item_flujo = .item_flujo
            m_gasto_funcion = .gasto_funcion
            m_centro_costo = .centro_costo
            m_area = .area
            m_linea_negocio = .linea_negocio
            m_proyecto = .proyecto
            m_zona = .zona
            m_vendedor = .vendedor
            m_comprador = .comprador
            m_transportista = .transportista
            m_analisis_01 = .analisis_01
            m_analisis_02 = .analisis_02
            m_analisis_03 = .analisis_03
            m_analisis_04 = .analisis_04
            m_analisis_05 = .analisis_05
            m_analisis_06 = .analisis_06
            m_analisis_07 = .analisis_07
            m_analisis_08 = .analisis_08
            m_analisis_09 = .analisis_09
            m_analisis_10 = .analisis_10
            m_cuenta_bancaria = .cuenta_bancaria
            m_indica_conciliado = .indica_conciliado
            m_ejercicio_conciliado = .ejercicio_conciliado
            m_mes_conciliado = .mes_conciliado
            m_tipo_medio_pago = .tipo_medio_pago
            m_documento_pago = .documento_pago
            m_fecha_pago = .fecha_pago
            m_indica_en_cartera = .indica_en_cartera
            m_origen = .origen
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

    Public Property asiento_tipo() As String
        Get
            Return m_asiento_tipo
        End Get
        Set(ByVal value As String)
            m_asiento_tipo = value
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

    Public Property asiento_linea() As String
        Get
            Return m_asiento_linea
        End Get
        Set(ByVal value As String)
            m_asiento_linea = value
        End Set
    End Property

    Public Property asiento_fecha() As Date
        Get
            Return m_asiento_fecha
        End Get
        Set(ByVal value As Date)
            m_asiento_fecha = value
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

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "1", value)
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

    Public Property cuenta_corriente() As String
        Get
            Return m_cuenta_corriente
        End Get
        Set(ByVal value As String)
            m_cuenta_corriente = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property comprobante_tipo() As String
        Get
            Return m_comprobante_tipo
        End Get
        Set(ByVal value As String)
            m_comprobante_tipo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property comprobante_serie() As String
        Get
            Return m_comprobante_serie
        End Get
        Set(ByVal value As String)
            m_comprobante_serie = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property comprobante_numero() As String
        Get
            Return m_comprobante_numero
        End Get
        Set(ByVal value As String)
            m_comprobante_numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property glosa() As String
        Get
            Return m_glosa
        End Get
        Set(ByVal value As String)
            m_glosa = value
        End Set
    End Property

    Public Property debe_origen() As Decimal
        Get
            Return m_debe_origen
        End Get
        Set(ByVal value As Decimal)
            m_debe_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_origen() As Decimal
        Get
            Return m_haber_origen
        End Get
        Set(ByVal value As Decimal)
            m_haber_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property debe_mn() As Decimal
        Get
            Return m_debe_mn
        End Get
        Set(ByVal value As Decimal)
            m_debe_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_mn() As Decimal
        Get
            Return m_haber_mn
        End Get
        Set(ByVal value As Decimal)
            m_haber_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property debe_me() As Decimal
        Get
            Return m_debe_me
        End Get
        Set(ByVal value As Decimal)
            m_debe_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property haber_me() As Decimal
        Get
            Return m_haber_me
        End Get
        Set(ByVal value As Decimal)
            m_haber_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property item_flujo() As String
        Get
            Return m_item_flujo
        End Get
        Set(ByVal value As String)
            m_item_flujo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property gasto_funcion() As String
        Get
            Return m_gasto_funcion
        End Get
        Set(ByVal value As String)
            m_gasto_funcion = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property linea_negocio() As String
        Get
            Return m_linea_negocio
        End Get
        Set(ByVal value As String)
            m_linea_negocio = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property zona() As String
        Get
            Return m_zona
        End Get
        Set(ByVal value As String)
            m_zona = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property vendedor() As String
        Get
            Return m_vendedor
        End Get
        Set(ByVal value As String)
            m_vendedor = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property comprador() As String
        Get
            Return m_comprador
        End Get
        Set(ByVal value As String)
            m_comprador = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property transportista() As String
        Get
            Return m_transportista
        End Get
        Set(ByVal value As String)
            m_transportista = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_01() As String
        Get
            Return m_analisis_01
        End Get
        Set(ByVal value As String)
            m_analisis_01 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_02() As String
        Get
            Return m_analisis_02
        End Get
        Set(ByVal value As String)
            m_analisis_02 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_03() As String
        Get
            Return m_analisis_03
        End Get
        Set(ByVal value As String)
            m_analisis_03 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_04() As String
        Get
            Return m_analisis_04
        End Get
        Set(ByVal value As String)
            m_analisis_04 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_05() As String
        Get
            Return m_analisis_05
        End Get
        Set(ByVal value As String)
            m_analisis_05 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_06() As String
        Get
            Return m_analisis_06
        End Get
        Set(ByVal value As String)
            m_analisis_06 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_07() As String
        Get
            Return m_analisis_07
        End Get
        Set(ByVal value As String)
            m_analisis_07 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_08() As String
        Get
            Return m_analisis_08
        End Get
        Set(ByVal value As String)
            m_analisis_08 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_09() As String
        Get
            Return m_analisis_09
        End Get
        Set(ByVal value As String)
            m_analisis_09 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property analisis_10() As String
        Get
            Return m_analisis_10
        End Get
        Set(ByVal value As String)
            m_analisis_10 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property cuenta_bancaria() As String
        Get
            Return m_cuenta_bancaria
        End Get
        Set(ByVal value As String)
            m_cuenta_bancaria = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property indica_conciliado() As String
        Get
            Return m_indica_conciliado
        End Get
        Set(ByVal value As String)
            m_indica_conciliado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property ejercicio_conciliado() As String
        Get
            Return m_ejercicio_conciliado
        End Get
        Set(ByVal value As String)
            m_ejercicio_conciliado = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property mes_conciliado() As String
        Get
            Return m_mes_conciliado
        End Get
        Set(ByVal value As String)
            m_mes_conciliado = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_medio_pago() As String
        Get
            Return m_tipo_medio_pago
        End Get
        Set(ByVal value As String)
            m_tipo_medio_pago = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property documento_pago() As String
        Get
            Return m_documento_pago
        End Get
        Set(ByVal value As String)
            m_documento_pago = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_pago() As Date
        Get
            Return m_fecha_pago
        End Get
        Set(ByVal value As Date)
            m_fecha_pago = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property indica_en_cartera() As String
        Get
            Return m_indica_en_cartera
        End Get
        Set(ByVal value As String)
            m_indica_en_cartera = IIf(String.IsNullOrEmpty(value), "NO", value)
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

End Class
