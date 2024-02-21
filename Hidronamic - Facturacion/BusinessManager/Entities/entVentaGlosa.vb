Public Class entVentaGlosa
    Private m_empresa As String
    Private m_venta As String
    Private m_linea As String
    Private m_tipo_cambio As Single
    Private m_tipo_moneda As String
    Private m_glosa_1 As String
    Private m_glosa_2 As String
    Private m_glosa_3 As String
    Private m_glosa_4 As String
    Private m_valor_venta_origen As Single
    Private m_estado As String
    Private m_centro_costo As String
    Private m_proyecto As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.venta = Nothing
        Me.linea = Nothing
        Me.tipo_cambio = Nothing
        Me.tipo_moneda = Nothing
        Me.glosa_1 = Nothing
        Me.glosa_2 = Nothing
        Me.glosa_3 = Nothing
        Me.glosa_4 = Nothing
        Me.estado = Nothing
        Me.centro_costo = Nothing
        Me.proyecto = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal VentaServicio As entVentaServicio)
        With VentaServicio
            m_empresa = .empresa
            m_venta = .venta
            m_linea = .linea
            m_tipo_cambio = .tipo_cambio
            m_tipo_moneda = .tipo_moneda
            m_glosa_1 = .glosa_1
            m_glosa_2 = .glosa_2
            m_glosa_3 = .glosa_3
            m_glosa_4 = .glosa_4
            m_estado = .estado
            m_centro_costo = .centro_costo
            m_proyecto = .proyecto
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

    Public Property venta() As String
        Get
            Return m_venta
        End Get
        Set(ByVal value As String)
            m_venta = value
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

    Public Property tipo_cambio() As Single
        Get
            Return m_tipo_cambio
        End Get
        Set(ByVal value As Single)
            m_tipo_cambio = IIf(String.IsNullOrEmpty(value), 1, value)
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

    Public Property glosa_1() As String
        Get
            Return m_glosa_1
        End Get
        Set(ByVal value As String)
            m_glosa_1 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property glosa_2() As String
        Get
            Return m_glosa_2
        End Get
        Set(ByVal value As String)
            m_glosa_2 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property glosa_3() As String
        Get
            Return m_glosa_3
        End Get
        Set(ByVal value As String)
            m_glosa_3 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property glosa_4() As String
        Get
            Return m_glosa_4
        End Get
        Set(ByVal value As String)
            m_glosa_4 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property valor_venta_origen() As Single
        Get
            Return m_valor_venta_origen
        End Get
        Set(ByVal value As Single)
            m_valor_venta_origen = IIf(String.IsNullOrEmpty(value), 0, value)
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
