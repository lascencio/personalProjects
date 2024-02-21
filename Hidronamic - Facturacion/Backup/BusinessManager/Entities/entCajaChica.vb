Public Class entCajaChica
    Private m_empresa As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_area As String
    Private m_numero_caja As String
    Private m_codigo_ui As String
    Private m_tipo_moneda As String
    Private m_tipo_cambio As Decimal
    Private m_cuenta_contable As String
    Private m_item_flujo As String
    Private m_glosa As String
    Private m_fecha_apertura As Date
    Private m_importe_apertura As Decimal
    Private m_saldo_anterior As Decimal
    Private m_importe_reembolso As Decimal
    Private m_saldo_actual As Decimal
    Private m_pago_maximo As Decimal
    Private m_fecha_reembolso As Date
    Private m_indica_contabilizado As String
    Private m_fecha_contabilizado As Date

    Private m_asiento_subdiario As String
    Private m_asiento_comprobante As String

    Private m_asiento_subdiario_caja As String
    Private m_asiento_comprobante_caja As String

    Private m_asiento_subdiario_rendicion As String
    Private m_asiento_comprobante_rendicion As String

    Private m_asiento_subdiario_honorarios As String
    Private m_asiento_comprobante_honorarios As String

    Private m_numero_caja_anterior As String

    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.area = Nothing
        Me.numero_caja = Nothing
        Me.codigo_ui = Nothing
        Me.tipo_moneda = Nothing
        Me.tipo_cambio = Nothing
        Me.cuenta_contable = Nothing
        Me.item_flujo = Nothing
        Me.glosa = Nothing
        Me.fecha_apertura = Nothing
        Me.importe_apertura = Nothing
        Me.saldo_anterior = Nothing
        Me.importe_reembolso = Nothing
        Me.saldo_actual = Nothing
        Me.pago_maximo = Nothing
        Me.fecha_reembolso = Nothing
        Me.indica_contabilizado = Nothing
        Me.fecha_contabilizado = Nothing

        Me.asiento_subdiario = Nothing
        Me.asiento_comprobante = Nothing

        Me.asiento_subdiario_caja = Nothing
        Me.asiento_comprobante_caja = Nothing

        Me.asiento_subdiario_rendicion = Nothing
        Me.asiento_comprobante_rendicion = Nothing

        Me.asiento_subdiario_honorarios = Nothing
        Me.asiento_comprobante_honorarios = Nothing

        Me.numero_caja_anterior = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

    End Sub

    Public Sub New(ByVal CajaChica As entCajaChica)

        With CajaChica
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_area = .area
            m_numero_caja = .numero_caja
            m_codigo_ui = .codigo_ui
            m_tipo_moneda = .tipo_moneda
            m_tipo_cambio = .tipo_cambio
            m_cuenta_contable = .cuenta_contable
            m_item_flujo = .item_flujo
            m_glosa = .glosa
            m_fecha_apertura = .fecha_apertura
            m_importe_apertura = .importe_apertura
            m_saldo_anterior = .saldo_anterior
            m_importe_reembolso = .importe_reembolso
            m_saldo_actual = .saldo_actual
            m_pago_maximo = .pago_maximo
            m_fecha_reembolso = .fecha_reembolso
            m_indica_contabilizado = .indica_contabilizado
            m_fecha_contabilizado = .fecha_contabilizado

            m_asiento_subdiario = .asiento_subdiario
            m_asiento_comprobante = .asiento_comprobante

            m_asiento_subdiario_caja = .asiento_subdiario_caja
            m_asiento_comprobante_caja = .asiento_comprobante_caja

            m_asiento_subdiario_honorarios = .asiento_subdiario_honorarios
            m_asiento_comprobante_honorarios = .asiento_comprobante_honorarios

            m_numero_caja_anterior = .numero_caja_anterior
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

    Public Property area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property

    Public Property numero_caja() As String
        Get
            Return m_numero_caja
        End Get
        Set(ByVal value As String)
            m_numero_caja = value
        End Set
    End Property

    Public Property codigo_ui() As String
        Get
            Return m_codigo_ui
        End Get
        Set(ByVal value As String)
            m_codigo_ui = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "MN", value)
        End Set
    End Property

    Public Property tipo_cambio() As Decimal
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Decimal)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property cuenta_contable() As String
        Get
            Return m_cuenta_contable
        End Get
        Set(ByVal value As String)
            m_cuenta_contable = IIf(String.IsNullOrEmpty(value), "102101", value)
        End Set
    End Property

    Public Property item_flujo() As String
        Get
            Return m_item_flujo
        End Get
        Set(ByVal value As String)
            m_item_flujo = IIf(String.IsNullOrEmpty(value), "2030", value)
        End Set
    End Property

    Public Property glosa() As String
        Get
            Return m_glosa
        End Get
        Set(ByVal value As String)
            m_glosa = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fecha_apertura() As Date
        Get
            Return m_fecha_apertura
        End Get
        Set(ByVal value As Date)
            m_fecha_apertura = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property importe_apertura() As Decimal
        Get
            Return m_importe_apertura
        End Get
        Set(ByVal value As Decimal)
            m_importe_apertura = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property saldo_anterior() As Decimal
        Get
            Return m_saldo_anterior
        End Get
        Set(ByVal value As Decimal)
            m_saldo_anterior = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_reembolso() As Decimal
        Get
            Return m_importe_reembolso
        End Get
        Set(ByVal value As Decimal)
            m_importe_reembolso = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property saldo_actual() As Decimal
        Get
            Return m_saldo_actual
        End Get
        Set(ByVal value As Decimal)
            m_saldo_actual = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property pago_maximo() As Decimal
        Get
            Return m_pago_maximo
        End Get
        Set(ByVal value As Decimal)
            m_pago_maximo = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property fecha_reembolso() As Date
        Get
            Return m_fecha_reembolso
        End Get
        Set(ByVal value As Date)
            m_fecha_reembolso = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property indica_contabilizado() As String
        Get
            Return m_indica_contabilizado
        End Get
        Set(ByVal value As String)
            m_indica_contabilizado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property fecha_contabilizado() As Date
        Get
            Return m_fecha_contabilizado
        End Get
        Set(ByVal value As Date)
            m_fecha_contabilizado = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property asiento_subdiario() As String
        Get
            Return m_asiento_subdiario
        End Get
        Set(ByVal value As String)
            m_asiento_subdiario = value
        End Set
    End Property

    Public Property asiento_comprobante() As String
        Get
            Return m_asiento_comprobante
        End Get
        Set(ByVal value As String)
            m_asiento_comprobante = value
        End Set
    End Property

    Public Property asiento_subdiario_caja() As String
        Get
            Return m_asiento_subdiario_caja
        End Get
        Set(ByVal value As String)
            m_asiento_subdiario_caja = value
        End Set
    End Property

    Public Property asiento_comprobante_caja() As String
        Get
            Return m_asiento_comprobante_caja
        End Get
        Set(ByVal value As String)
            m_asiento_comprobante_caja = value
        End Set
    End Property

    Public Property asiento_subdiario_rendicion() As String
        Get
            Return m_asiento_subdiario_rendicion
        End Get
        Set(ByVal value As String)
            m_asiento_subdiario_rendicion = value
        End Set
    End Property

    Public Property asiento_comprobante_rendicion() As String
        Get
            Return m_asiento_comprobante_rendicion
        End Get
        Set(ByVal value As String)
            m_asiento_comprobante_rendicion = value
        End Set
    End Property

    Public Property asiento_subdiario_honorarios() As String
        Get
            Return m_asiento_subdiario_honorarios
        End Get
        Set(ByVal value As String)
            m_asiento_subdiario_honorarios = value
        End Set
    End Property

    Public Property asiento_comprobante_honorarios() As String
        Get
            Return m_asiento_comprobante_honorarios
        End Get
        Set(ByVal value As String)
            m_asiento_comprobante_honorarios = value
        End Set
    End Property

    Public Property numero_caja_anterior() As String
        Get
            Return m_numero_caja_anterior
        End Get
        Set(ByVal value As String)
            m_numero_caja_anterior = value
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
