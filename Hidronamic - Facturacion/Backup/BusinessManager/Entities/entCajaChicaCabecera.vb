Public Class entCajaChicaCabecera
    Private m_empresa As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_area As String
    Private m_numero_caja As String
    Private m_correlativo As String
    Private m_codigo_ui As String
    Private m_tipo As String
    Private m_beneficiario_tipo As String
    Private m_beneficiario As String
    Private m_beneficiario_nombre As String
    Private m_subdiario As String
    Private m_documento_tipo As String
    Private m_documento_serie As String
    Private m_documento_numero As String
    Private m_documento_fecha As Date
    Private m_documento_vencimiento As Date
    Private m_tipo_cambio As Decimal
    Private m_tipo_moneda As String
    Private m_avanexo As String
    Private m_anexo As String
    Private m_anexo_nombre As String

    Private m_glosa As String
    Private m_base_imponible_gravada As Decimal
    Private m_importe_exonerado As Decimal
    Private m_importe_inafecto As Decimal
    Private m_isc As Decimal
    Private m_igv As Decimal
    Private m_ipm As Decimal
    Private m_base_imponible_gravada2 As Decimal
    Private m_igv2 As Decimal
    Private m_otros_tributos As Decimal
    Private m_importe_total As Decimal

    Private m_ejercicio_referencia As String
    Private m_mes_referencia As String
    Private m_area_referencia As String
    Private m_numero_caja_referencia As String
    Private m_correlativo_referencia As String
    Private m_importe_total_referencia As Decimal
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_beneficiario_nuevo As Boolean
    Private m_indica_proveedor_nuevo As Boolean

    Public Sub New()
        Me.empresa = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.area = Nothing
        Me.numero_caja = Nothing
        Me.correlativo = Nothing
        Me.codigo_ui = Nothing
        Me.tipo = Nothing
        Me.beneficiario_tipo = Nothing
        Me.beneficiario = Nothing
        Me.beneficiario_nombre = Nothing
        Me.subdiario = Nothing
        Me.documento_tipo = Nothing
        Me.documento_serie = Nothing
        Me.documento_numero = Nothing
        Me.documento_fecha = Nothing
        Me.documento_vencimiento = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.avanexo = Nothing
        Me.anexo = Nothing
        Me.anexo_nombre = Nothing

        Me.glosa = Nothing
        Me.base_imponible_gravada = Nothing
        Me.importe_exonerado = Nothing
        Me.importe_inafecto = Nothing
        Me.isc = Nothing
        Me.igv = Nothing
        Me.ipm = Nothing
        Me.base_imponible_gravada2 = Nothing
        Me.igv2 = Nothing
        Me.otros_tributos = Nothing
        Me.importe_total = Nothing

        Me.ejercicio_referencia = Nothing
        Me.mes_referencia = Nothing
        Me.area_referencia = Nothing
        Me.numero_caja_referencia = Nothing
        Me.correlativo_referencia = Nothing
        Me.importe_total_referencia = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.indica_beneficiario_nuevo = Nothing
        Me.indica_proveedor_nuevo = Nothing
    End Sub

    Public Sub New(ByVal CajaChicaCabecera As entCajaChicaCabecera)

        With CajaChicaCabecera
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_area = .area
            m_numero_caja = .numero_caja
            m_correlativo = .correlativo
            m_codigo_ui = .codigo_ui
            m_tipo = .tipo
            m_beneficiario_tipo = .beneficiario_tipo
            m_beneficiario = .beneficiario
            m_beneficiario_nombre = .beneficiario_nombre
            m_subdiario = .subdiario
            m_documento_tipo = .documento_tipo
            m_documento_serie = .documento_serie
            m_documento_numero = .documento_numero
            m_documento_fecha = .documento_fecha
            m_documento_vencimiento = .documento_vencimiento
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_avanexo = .avanexo
            m_anexo = .anexo
            m_anexo_nombre = .anexo_nombre
            m_glosa = .glosa
            m_base_imponible_gravada = .base_imponible_gravada
            m_importe_exonerado = .importe_exonerado
            m_importe_inafecto = .importe_inafecto
            m_isc = .isc
            m_igv = .igv
            m_ipm = .ipm
            m_base_imponible_gravada2 = .base_imponible_gravada2
            m_igv2 = .igv2
            m_otros_tributos = .otros_tributos
            m_importe_total = .importe_total

            m_ejercicio_referencia = .ejercicio_referencia
            m_mes_referencia = .mes_referencia
            m_area_referencia = .area_referencia
            m_numero_caja_referencia = .numero_caja_referencia
            m_correlativo_referencia = .correlativo_referencia
            m_importe_total_referencia = .importe_total_referencia
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
            m_indica_beneficiario_nuevo = .indica_beneficiario_nuevo
            m_indica_proveedor_nuevo = .indica_proveedor_nuevo
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

    Public Property correlativo() As String
        Get
            Return m_correlativo
        End Get
        Set(ByVal value As String)
            m_correlativo = value
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

    Public Property tipo() As String
        Get
            Return m_tipo
        End Get
        Set(ByVal value As String)
            m_tipo = value
        End Set
    End Property

    Public Property beneficiario_tipo() As String
        Get
            Return m_beneficiario_tipo
        End Get
        Set(ByVal value As String)
            m_beneficiario_tipo = IIf(String.IsNullOrEmpty(value), "T", value)
        End Set
    End Property

    Public Property beneficiario() As String
        Get
            Return m_beneficiario
        End Get
        Set(ByVal value As String)
            m_beneficiario = value
        End Set
    End Property

    Public Property beneficiario_nombre() As String
        Get
            Return m_beneficiario_nombre
        End Get
        Set(ByVal value As String)
            m_beneficiario_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property subdiario() As String
        Get
            Return m_subdiario
        End Get
        Set(ByVal value As String)
            m_subdiario = value
        End Set
    End Property

    Public Property documento_tipo() As String
        Get
            Return m_documento_tipo
        End Get
        Set(ByVal value As String)
            m_documento_tipo = IIf(String.IsNullOrEmpty(value), "VR", value)
        End Set
    End Property

    Public Property documento_serie() As String
        Get
            Return m_documento_serie
        End Get
        Set(ByVal value As String)
            m_documento_serie = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property documento_numero() As String
        Get
            Return m_documento_numero
        End Get
        Set(ByVal value As String)
            m_documento_numero = IIf(String.IsNullOrEmpty(value), "0000000000", value)
        End Set
    End Property

    Public Property documento_fecha() As Date
        Get
            Return m_documento_fecha
        End Get
        Set(ByVal value As Date)
            m_documento_fecha = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property documento_vencimiento() As Date
        Get
            Return m_documento_vencimiento
        End Get
        Set(ByVal value As Date)
            m_documento_vencimiento = IIf(value.Ticks = 0, FechaNulo, value)
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

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "MN", value)
        End Set
    End Property

    Public Property avanexo() As String
        Get
            Return m_avanexo
        End Get
        Set(ByVal value As String)
            m_avanexo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property anexo() As String
        Get
            Return m_anexo
        End Get
        Set(ByVal value As String)
            m_anexo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property anexo_nombre() As String
        Get
            Return m_anexo_nombre
        End Get
        Set(ByVal value As String)
            m_anexo_nombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property base_imponible_gravada() As Decimal
        Get
            Return m_base_imponible_gravada
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_exonerado() As Decimal
        Get
            Return m_importe_exonerado
        End Get
        Set(ByVal value As Decimal)
            m_importe_exonerado = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_inafecto() As Decimal
        Get
            Return m_importe_inafecto
        End Get
        Set(ByVal value As Decimal)
            m_importe_inafecto = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property isc() As Decimal
        Get
            Return m_isc
        End Get
        Set(ByVal value As Decimal)
            m_isc = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv() As Decimal
        Get
            Return m_igv
        End Get
        Set(ByVal value As Decimal)
            m_igv = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ipm() As Decimal
        Get
            Return m_ipm
        End Get
        Set(ByVal value As Decimal)
            m_ipm = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property base_imponible_gravada2() As Decimal
        Get
            Return m_base_imponible_gravada2
        End Get
        Set(ByVal value As Decimal)
            m_base_imponible_gravada2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property igv2() As Decimal
        Get
            Return m_igv2
        End Get
        Set(ByVal value As Decimal)
            m_igv2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property otros_tributos() As Decimal
        Get
            Return m_otros_tributos
        End Get
        Set(ByVal value As Decimal)
            m_otros_tributos = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property importe_total() As Decimal
        Get
            Return m_importe_total
        End Get
        Set(ByVal value As Decimal)
            m_importe_total = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property ejercicio_referencia() As String
        Get
            Return m_ejercicio_referencia
        End Get
        Set(ByVal value As String)
            m_ejercicio_referencia = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property mes_referencia() As String
        Get
            Return m_mes_referencia
        End Get
        Set(ByVal value As String)
            m_mes_referencia = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property area_referencia() As String
        Get
            Return m_area_referencia
        End Get
        Set(ByVal value As String)
            m_area_referencia = IIf(String.IsNullOrEmpty(value), "000000", value)
        End Set
    End Property

    Public Property numero_caja_referencia() As String
        Get
            Return m_numero_caja_referencia
        End Get
        Set(ByVal value As String)
            m_numero_caja_referencia = IIf(String.IsNullOrEmpty(value), "0000", value)
        End Set
    End Property

    Public Property correlativo_referencia() As String
        Get
            Return m_correlativo_referencia
        End Get
        Set(ByVal value As String)
            m_correlativo_referencia = IIf(String.IsNullOrEmpty(value), "000000", value)
        End Set
    End Property

    Public Property importe_total_referencia() As Decimal
        Get
            Return m_importe_total_referencia
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_referencia = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property indica_beneficiario_nuevo() As Boolean
        Get
            Return m_indica_beneficiario_nuevo
        End Get
        Set(ByVal value As Boolean)
            m_indica_beneficiario_nuevo = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property indica_proveedor_nuevo() As Boolean
        Get
            Return m_indica_proveedor_nuevo
        End Get
        Set(ByVal value As Boolean)
            m_indica_proveedor_nuevo = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

End Class
