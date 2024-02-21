Public Class entVentaResumen

    Private m_empresa As String
    Private m_venta As String
    Private m_valor_exportacion_origen As Decimal
    Private m_base_imponible_gravada_origen As Decimal
    Private m_importe_exonerado_origen As Decimal
    Private m_importe_inafecto_origen As Decimal
    Private m_isc_origen As Decimal
    Private m_igv_origen As Decimal
    Private m_ipm_origen As Decimal
    Private m_base_imponible_gravada2_origen As Decimal
    Private m_igv2_origen As Decimal
    Private m_otros_tributos_origen As Decimal
    Private m_descuento_global_origen As Decimal
    Private m_importe_total_origen As Decimal

    Public Sub New()
        Me.empresa = Nothing
        Me.venta = Nothing
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
        Me.descuento_global_origen = Nothing
        Me.importe_total_origen = Nothing
    End Sub

    Public Sub New(ByVal VentaResumen As entVentaResumen)

        With VentaResumen
            m_empresa = .empresa
            m_venta = .venta
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
            m_descuento_global_origen = .descuento_global_origen
            m_importe_total_origen = .importe_total_origen
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

    Public Property valor_exportacion_origen() As Decimal
        Get
            Return m_valor_exportacion_origen
        End Get
        Set(ByVal value As Decimal)
            m_valor_exportacion_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada_origen() As Decimal
        Get
            Return m_base_imponible_gravada_origen
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado_origen() As Decimal
        Get
            Return m_importe_exonerado_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto_origen() As Decimal
        Get
            Return m_importe_inafecto_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property igv_origen() As Decimal
        Get
            Return m_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm_origen() As Decimal
        Get
            Return m_ipm_origen
        End Get
        Set(ByVal value As Decimal)
            m_ipm_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2_origen() As Decimal
        Get
            Return m_base_imponible_gravada2_origen
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2_origen() As Decimal
        Get
            Return m_igv2_origen
        End Get
        Set(ByVal value As Decimal)
            m_igv2_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property descuento_global_origen() As Decimal
        Get
            Return m_descuento_global_origen
        End Get
        Set(ByVal value As Decimal)
            m_descuento_global_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

End Class
