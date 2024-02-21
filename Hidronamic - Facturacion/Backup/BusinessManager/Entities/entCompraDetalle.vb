Public Class entCompraDetalle
    Private m_empresa As String
    Private m_compra As String
    Private m_linea As String
    Private m_glosa As String
    Private m_tipo_cambio As Decimal
    Private m_tipo_moneda As String
    Private m_adquisicion_1_base_origen As Decimal
    Private m_adquisicion_1_igv_origen As Decimal
    Private m_adquisicion_2_base_origen As Decimal
    Private m_adquisicion_2_igv_origen As Decimal
    Private m_adquisicion_3_base_origen As Decimal
    Private m_adquisicion_3_igv_origen As Decimal
    Private m_adquisicion_no_gravada_origen As Decimal
    Private m_isc_origen As Decimal
    Private m_otros_tributos_origen As Decimal
    Private m_importe_total_origen As Decimal
    Private m_adquisicion_1_base_mn As Decimal
    Private m_adquisicion_1_igv_mn As Decimal
    Private m_adquisicion_2_base_mn As Decimal
    Private m_adquisicion_2_igv_mn As Decimal
    Private m_adquisicion_3_base_mn As Decimal
    Private m_adquisicion_3_igv_mn As Decimal
    Private m_adquisicion_no_gravada_mn As Decimal
    Private m_isc_mn As Decimal
    Private m_otros_tributos_mn As Decimal
    Private m_importe_total_mn As Decimal
    Private m_adquisicion_1_base_me As Decimal
    Private m_adquisicion_1_igv_me As Decimal
    Private m_adquisicion_2_base_me As Decimal
    Private m_adquisicion_2_igv_me As Decimal
    Private m_adquisicion_3_base_me As Decimal
    Private m_adquisicion_3_igv_me As Decimal
    Private m_adquisicion_no_gravada_me As Decimal
    Private m_isc_me As Decimal
    Private m_otros_tributos_me As Decimal
    Private m_importe_total_me As Decimal
    Private m_centro_costo As String
    Private m_proyecto As String
    Private m_cuenta_contable_gasto As String
    Private m_fecha_pago As Date
    Private m_lote As String
    Private m_secuencia As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.compra = Nothing
        Me.linea = Nothing
        Me.glosa = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.adquisicion_1_base_origen = Nothing
        Me.adquisicion_1_igv_origen = Nothing
        Me.adquisicion_2_base_origen = Nothing
        Me.adquisicion_2_igv_origen = Nothing
        Me.adquisicion_3_base_origen = Nothing
        Me.adquisicion_3_igv_origen = Nothing
        Me.adquisicion_no_gravada_origen = Nothing
        Me.isc_origen = Nothing
        Me.otros_tributos_origen = Nothing
        Me.importe_total_origen = Nothing
        Me.adquisicion_1_base_mn = Nothing
        Me.adquisicion_1_igv_mn = Nothing
        Me.adquisicion_2_base_mn = Nothing
        Me.adquisicion_2_igv_mn = Nothing
        Me.adquisicion_3_base_mn = Nothing
        Me.adquisicion_3_igv_mn = Nothing
        Me.adquisicion_no_gravada_mn = Nothing
        Me.isc_mn = Nothing
        Me.otros_tributos_mn = Nothing
        Me.importe_total_mn = Nothing
        Me.adquisicion_1_base_me = Nothing
        Me.adquisicion_1_igv_me = Nothing
        Me.adquisicion_2_base_me = Nothing
        Me.adquisicion_2_igv_me = Nothing
        Me.adquisicion_3_base_me = Nothing
        Me.adquisicion_3_igv_me = Nothing
        Me.adquisicion_no_gravada_me = Nothing
        Me.isc_me = Nothing
        Me.otros_tributos_me = Nothing
        Me.importe_total_me = Nothing
        Me.centro_costo = Nothing
        Me.proyecto = Nothing
        Me.cuenta_contable_gasto = Nothing
        Me.fecha_pago = Nothing
        Me.lote = Nothing
        Me.secuencia = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal CompraDetalle As entCompraDetalle)

        With CompraDetalle
            m_empresa = .empresa
            m_compra = .compra
            m_linea = .linea
            m_glosa = .glosa
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_adquisicion_1_base_origen = .adquisicion_1_base_origen
            m_adquisicion_1_igv_origen = .adquisicion_1_igv_origen
            m_adquisicion_2_base_origen = .adquisicion_2_base_origen
            m_adquisicion_2_igv_origen = .adquisicion_2_igv_origen
            m_adquisicion_3_base_origen = .adquisicion_3_base_origen
            m_adquisicion_3_igv_origen = .adquisicion_3_igv_origen
            m_adquisicion_no_gravada_origen = .adquisicion_no_gravada_origen
            m_isc_origen = .isc_origen
            m_otros_tributos_origen = .otros_tributos_origen
            m_importe_total_origen = .importe_total_origen
            m_adquisicion_1_base_mn = .adquisicion_1_base_mn
            m_adquisicion_1_igv_mn = .adquisicion_1_igv_mn
            m_adquisicion_2_base_mn = .adquisicion_2_base_mn
            m_adquisicion_2_igv_mn = .adquisicion_2_igv_mn
            m_adquisicion_3_base_mn = .adquisicion_3_base_mn
            m_adquisicion_3_igv_mn = .adquisicion_3_igv_mn
            m_adquisicion_no_gravada_mn = .adquisicion_no_gravada_mn
            m_isc_mn = .isc_mn
            m_otros_tributos_mn = .otros_tributos_mn
            m_importe_total_mn = .importe_total_mn
            m_adquisicion_1_base_me = .adquisicion_1_base_me
            m_adquisicion_1_igv_me = .adquisicion_1_igv_me
            m_adquisicion_2_base_me = .adquisicion_2_base_me
            m_adquisicion_2_igv_me = .adquisicion_2_igv_me
            m_adquisicion_3_base_me = .adquisicion_3_base_me
            m_adquisicion_3_igv_me = .adquisicion_3_igv_me
            m_adquisicion_no_gravada_me = .adquisicion_no_gravada_me
            m_isc_me = .isc_me
            m_otros_tributos_me = .otros_tributos_me
            m_importe_total_me = .importe_total_me
            m_centro_costo = .centro_costo
            m_proyecto = .proyecto
            m_cuenta_contable_gasto = .cuenta_contable_gasto
            m_fecha_pago = .fecha_pago
            m_lote = .lote
            m_secuencia = .secuencia
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

    Public Property compra() As String
        Get
            Return m_compra
        End Get
        Set(ByVal value As String)
            m_compra = value
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

    Public Property glosa() As String
        Get
            Return m_glosa
        End Get
        Set(ByVal value As String)
            m_glosa = value
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

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "1", value)
        End Set
    End Property

    Public Property adquisicion_1_base_origen() As Decimal
        Get
            Return m_adquisicion_1_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_origen() As Decimal
        Get
            Return m_adquisicion_1_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_origen() As Decimal
        Get
            Return m_adquisicion_2_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_origen() As Decimal
        Get
            Return m_adquisicion_2_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_origen() As Decimal
        Get
            Return m_adquisicion_3_base_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_origen() As Decimal
        Get
            Return m_adquisicion_3_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_origen() As Decimal
        Get
            Return m_adquisicion_no_gravada_origen
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_origen() As Decimal
        Get
            Return m_isc_origen
        End Get
        Set(ByVal value As Decimal)
            m_isc_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_origen() As Decimal
        Get
            Return m_otros_tributos_origen
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total_origen() As Decimal
        Get
            Return m_importe_total_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_base_mn() As Decimal
        Get
            Return m_adquisicion_1_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_mn() As Decimal
        Get
            Return m_adquisicion_1_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_mn() As Decimal
        Get
            Return m_adquisicion_2_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_mn() As Decimal
        Get
            Return m_adquisicion_2_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_mn() As Decimal
        Get
            Return m_adquisicion_3_base_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_mn() As Decimal
        Get
            Return m_adquisicion_3_igv_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_mn() As Decimal
        Get
            Return m_adquisicion_no_gravada_mn
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_mn() As Decimal
        Get
            Return m_isc_mn
        End Get
        Set(ByVal value As Decimal)
            m_isc_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_mn() As Decimal
        Get
            Return m_otros_tributos_mn
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_mn = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property adquisicion_1_base_me() As Decimal
        Get
            Return m_adquisicion_1_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_1_igv_me() As Decimal
        Get
            Return m_adquisicion_1_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_1_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_base_me() As Decimal
        Get
            Return m_adquisicion_2_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_2_igv_me() As Decimal
        Get
            Return m_adquisicion_2_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_2_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_base_me() As Decimal
        Get
            Return m_adquisicion_3_base_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_base_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_3_igv_me() As Decimal
        Get
            Return m_adquisicion_3_igv_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_3_igv_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property adquisicion_no_gravada_me() As Decimal
        Get
            Return m_adquisicion_no_gravada_me
        End Get
        Set(ByVal value As Decimal)
            m_adquisicion_no_gravada_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc_me() As Decimal
        Get
            Return m_isc_me
        End Get
        Set(ByVal value As Decimal)
            m_isc_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos_me() As Decimal
        Get
            Return m_otros_tributos_me
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos_me = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property cuenta_contable_gasto() As String
        Get
            Return m_cuenta_contable_gasto
        End Get
        Set(ByVal value As String)
            m_cuenta_contable_gasto = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property lote() As String
        Get
            Return m_lote
        End Get
        Set(ByVal value As String)
            m_lote = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property secuencia() As String
        Get
            Return m_secuencia
        End Get
        Set(ByVal value As String)
            m_secuencia = IIf(String.IsNullOrEmpty(value), "0000", value)
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
