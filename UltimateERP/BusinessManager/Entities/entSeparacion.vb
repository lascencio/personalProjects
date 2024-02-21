Public Class entSeparacion

    Private m_empresa As String
    Private m_separacion As String
    Private m_ejercicio As String
    Private m_mes As String
    Private m_cuenta_comercial As String
    Private m_tipo_moneda As String
    Private m_almacen As String
    Private m_base_imponible_gravada_origen As Decimal
    Private m_igv_origen As Decimal
    Private m_importe_total_origen As Decimal
    Private m_importe_saldo As Decimal
    Private m_comentario As String
    Private m_codigo_vendedor As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_grupo_comercial As String

    Private m_tipo_documento As String
    Private m_nro_documento As String
    Private m_razon_social As String

    Public Sub New()
        Me.empresa = Nothing
        Me.venta = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.cuenta_comercial = Nothing
        Me.tipo_moneda = Nothing
        Me.almacen = Nothing

        Me.base_imponible_gravada_origen = Nothing
        Me.igv_origen = Nothing
        Me.importe_total_origen = Nothing

        Me.importe_saldo = Nothing
        Me.comentario = Nothing
        Me.codigo_vendedor = Nothing

        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.grupo_comercial = Nothing

        Me.tipo_documento = Nothing
        Me.nro_documento = Nothing
        Me.razon_social = Nothing
    End Sub

    Public Sub New(ByVal Venta As entVenta)
        With Venta
            m_empresa = .empresa
            m_separacion = .venta
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_cuenta_comercial = .cuenta_comercial
            m_tipo_moneda = .tipo_moneda
            m_almacen = .almacen
            m_base_imponible_gravada_origen = .base_imponible_gravada_origen
            m_igv_origen = .igv_origen
            m_importe_total_origen = .importe_total_origen
            m_importe_saldo = .importe_saldo
            m_comentario = .comentario
            m_codigo_vendedor = .codigo_vendedor
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_grupo_comercial = .grupo_comercial

            m_tipo_documento = .tipo_documento
            m_nro_documento = .nro_documento
            m_razon_social = .razon_social

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
            Return m_separacion
        End Get
        Set(ByVal value As String)
            m_separacion = value
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = value
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

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = IIf(String.IsNullOrEmpty(value), "000", value)
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

    Public Property igv_origen() As Decimal
        Get
            Return m_igv_origen
        End Get
        Set(ByVal value As Decimal)
            m_igv_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property importe_saldo() As Decimal
        Get
            Return m_importe_saldo
        End Get
        Set(ByVal value As Decimal)
            m_importe_saldo = IIf(String.IsNullOrEmpty(value), 0, value)
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

    Public Property codigo_vendedor() As String
        Get
            Return m_codigo_vendedor
        End Get
        Set(ByVal value As String)
            m_codigo_vendedor = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "V", value)
        End Set
    End Property

    Public Property usuario_registro() As String
        Get
            Return m_usuario_registro
        End Get
        Set(ByVal value As String)
            m_usuario_registro = IIf(String.IsNullOrEmpty(value), MyUsuario.usuario, value)
        End Set
    End Property

    Public Property fecha_registro() As Date
        Get
            Return m_fecha_registro
        End Get
        Set(ByVal value As Date)
            m_fecha_registro = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property usuario_modifica() As String
        Get
            Return m_usuario_modifica
        End Get
        Set(ByVal value As String)
            m_usuario_modifica = IIf(String.IsNullOrEmpty(value), MyUsuario.usuario, value)
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

    Public Property grupo_comercial() As String
        Get
            Return m_grupo_comercial
        End Get
        Set(ByVal value As String)
            m_grupo_comercial = IIf(String.IsNullOrEmpty(value), "G0000000", value)
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

End Class
