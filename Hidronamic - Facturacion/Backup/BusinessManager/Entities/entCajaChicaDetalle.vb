Public Class entCajaChicaDetalle
    Private m_empresa As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_area As String
    Private m_numero_caja As String
    Private m_correlativo As String
    Private m_secuencia As String
    Private m_codigo_ui As String
    Private m_cuenta As String
    Private m_anexo_tipo As String
    Private m_anexo As String
    Private m_avanexo As String
    Private m_centro_costo As String
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
    Private m_importe_total_origen As Decimal

    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_centro_costo As Boolean
    Private m_indica_proyecto As Boolean
    Private m_indica_cuenta_corriente As Boolean
    Private m_indica_rendicion_cuenta As Boolean
    Private m_importe_total_rendicion As Decimal
    Private m_es_conforme As Boolean


    Public Sub New()
        Me.empresa = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.area = Nothing
        Me.numero_caja = Nothing
        Me.correlativo = Nothing
        Me.secuencia = Nothing
        Me.codigo_ui = Nothing
        Me.cuenta = Nothing
        Me.anexo_tipo = Nothing
        Me.anexo = Nothing
        Me.avanexo = Nothing
        Me.centro_costo = Nothing
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
        Me.importe_total_origen = Nothing

        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.indica_centro_costo = False
        Me.indica_proyecto = False
        Me.indica_cuenta_corriente = False
        Me.indica_rendicion_cuenta = False
        Me.importe_total_rendicion = 0
        Me.es_conforme = True
    End Sub

    Public Sub New(ByVal CajaChicaDetalle As entCajaChicaDetalle)

        With CajaChicaDetalle
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_area = .area
            m_numero_caja = .numero_caja
            m_correlativo = .correlativo
            m_codigo_ui = .codigo_ui
            m_secuencia = .secuencia
            m_cuenta = .cuenta
            m_anexo_tipo = .anexo_tipo
            m_anexo = .anexo
            m_avanexo = .avanexo
            m_centro_costo = .centro_costo
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
            m_importe_total_origen = .importe_total_origen

            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_indica_centro_costo = .indica_centro_costo
            m_indica_proyecto = .indica_proyecto
            m_indica_cuenta_corriente = .indica_cuenta_corriente
            m_indica_rendicion_cuenta = .indica_rendicion_cuenta
            m_importe_total_rendicion = .importe_total_rendicion
            m_es_conforme = .es_conforme
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

    Public Property secuencia() As String
        Get
            Return m_secuencia
        End Get
        Set(ByVal value As String)
            m_secuencia = value
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

    Public Property cuenta() As String
        Get
            Return m_cuenta
        End Get
        Set(ByVal value As String)
            m_cuenta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property anexo_tipo() As String
        Get
            Return m_anexo_tipo
        End Get
        Set(ByVal value As String)
            m_anexo_tipo = IIf(String.IsNullOrEmpty(value), "NA", value)
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

    Public Property avanexo() As String
        Get
            Return m_avanexo
        End Get
        Set(ByVal value As String)
            m_avanexo = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property importe_total_origen() As Decimal
        Get
            Return m_importe_total_origen
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property indica_centro_costo() As Boolean
        Get
            Return m_indica_centro_costo
        End Get
        Set(ByVal value As Boolean)
            m_indica_centro_costo = value
        End Set
    End Property

    Public Property indica_proyecto() As Boolean
        Get
            Return m_indica_proyecto
        End Get
        Set(ByVal value As Boolean)
            m_indica_proyecto = value
        End Set
    End Property

    Public Property indica_cuenta_corriente() As Boolean
        Get
            Return m_indica_cuenta_corriente
        End Get
        Set(ByVal value As Boolean)
            m_indica_cuenta_corriente = value
        End Set
    End Property

    Public Property indica_rendicion_cuenta() As Boolean
        Get
            Return m_indica_rendicion_cuenta
        End Get
        Set(ByVal value As Boolean)
            m_indica_rendicion_cuenta = value
        End Set
    End Property

    Public Property importe_total_rendicion() As Decimal
        Get
            Return m_importe_total_rendicion
        End Get
        Set(ByVal value As Decimal)
            m_importe_total_rendicion = value
        End Set
    End Property

    Public Property es_conforme() As Boolean
        Get
            Return m_es_conforme
        End Get
        Set(ByVal value As Boolean)
            m_es_conforme = value
        End Set
    End Property

End Class
