Public Class entTablaDetalle
    Private m_empresa As String = "000"
    Private m_codigo_tabla As String
    Private m_codigo_item As String
    Private m_nombre_corto As String
    Private m_nombre_largo As String
    Private m_texto_01 As String = " "
    Private m_texto_02 As String = " "
    Private m_texto_03 As String = " "
    Private m_texto_04 As String = " "
    Private m_texto_05 As String = " "
    Private m_valor_01 As Single = 0
    Private m_valor_02 As Single = 0
    Private m_valor_03 As Single = 0
    Private m_valor_04 As Single = 0
    Private m_valor_05 As Single = 0
    Private m_logico_01 As Boolean = 0
    Private m_logico_02 As Boolean = 0
    Private m_logico_03 As Boolean = 0
    Private m_logico_04 As Boolean = 0
    Private m_logico_05 As Boolean = 0
    Private m_estado As String = "ACT"
    Private m_usuario_registro As String = "SISTEMAS"
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String = " "
    Private m_fecha_modifica As Date
    Private m_nombre_tabla As String

    Private m_CancelProcess As String

    Public Sub New()
        Me.empresa = Nothing
        Me.codigo_tabla = Nothing
        Me.codigo_item = Nothing
        Me.nombre_corto = Nothing
        Me.nombre_largo = Nothing
        Me.texto_01 = Nothing
        Me.texto_02 = Nothing
        Me.texto_03 = Nothing
        Me.texto_04 = Nothing
        Me.texto_05 = Nothing
        Me.valor_01 = Nothing
        Me.valor_02 = Nothing
        Me.valor_03 = Nothing
        Me.valor_04 = Nothing
        Me.valor_05 = Nothing
        Me.logico_01 = Nothing
        Me.logico_02 = Nothing
        Me.logico_03 = Nothing
        Me.logico_04 = Nothing
        Me.logico_05 = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
        Me.nombre_tabla = Nothing
        Me.CancelProcess = Nothing
    End Sub

    Public Sub New(ByVal tabladetalle As entTablaDetalle)
        With tabladetalle
            m_empresa = .empresa
            m_codigo_tabla = .codigo_tabla
            m_codigo_item = .codigo_item
            m_nombre_corto = .nombre_corto
            m_nombre_largo = .nombre_largo
            m_texto_01 = .texto_01
            m_texto_02 = .texto_02
            m_texto_03 = .texto_03
            m_texto_04 = .texto_04
            m_texto_05 = .texto_05
            m_valor_01 = .valor_01
            m_valor_02 = .valor_02
            m_valor_03 = .valor_03
            m_valor_04 = .valor_04
            m_valor_05 = .valor_05
            m_logico_01 = .logico_01
            m_logico_02 = .logico_02
            m_logico_03 = .logico_03
            m_logico_04 = .logico_04
            m_logico_05 = .logico_05
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
            m_nombre_tabla = .nombre_tabla
            m_CancelProcess = .CancelProcess
        End With
    End Sub

    Public Property empresa() As String
        Get
            Return m_empresa
        End Get
        Set(ByVal value As String)
            m_empresa = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property codigo_tabla() As String
        Get
            Return m_codigo_tabla
        End Get
        Set(ByVal value As String)
            m_codigo_tabla = value
        End Set
    End Property

    Public Property codigo_item() As String
        Get
            Return m_codigo_item
        End Get
        Set(ByVal value As String)
            m_codigo_item = value
        End Set
    End Property

    Public Property nombre_corto() As String
        Get
            Return m_nombre_corto
        End Get
        Set(ByVal value As String)
            m_nombre_corto = value
        End Set
    End Property

    Public Property nombre_largo() As String
        Get
            Return m_nombre_largo
        End Get
        Set(ByVal value As String)
            m_nombre_largo = value
        End Set
    End Property
   
    Public Property texto_01() As String
        Get
            Return m_texto_01
        End Get
        Set(ByVal value As String)
            m_texto_01 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property texto_02() As String
        Get
            Return m_texto_02
        End Get
        Set(ByVal value As String)
            m_texto_02 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property texto_03() As String
        Get
            Return m_texto_03
        End Get
        Set(ByVal value As String)
            m_texto_03 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property texto_04() As String
        Get
            Return m_texto_04
        End Get
        Set(ByVal value As String)
            m_texto_04 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property texto_05() As String
        Get
            Return m_texto_05
        End Get
        Set(ByVal value As String)
            m_texto_05 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property valor_01() As Single
        Get
            Return m_valor_01
        End Get
        Set(ByVal value As Single)
            m_valor_01 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_02() As Single
        Get
            Return m_valor_02
        End Get
        Set(ByVal value As Single)
            m_valor_02 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_03() As Single
        Get
            Return m_valor_03
        End Get
        Set(ByVal value As Single)
            m_valor_03 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_04() As Single
        Get
            Return m_valor_04
        End Get
        Set(ByVal value As Single)
            m_valor_04 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property valor_05() As Single
        Get
            Return m_valor_05
        End Get
        Set(ByVal value As Single)
            m_valor_05 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property logico_01() As Boolean
        Get
            Return m_logico_01
        End Get
        Set(ByVal value As Boolean)
            m_logico_01 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property logico_02() As Boolean
        Get
            Return m_logico_02
        End Get
        Set(ByVal value As Boolean)
            m_logico_02 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property logico_03() As Boolean
        Get
            Return m_logico_03
        End Get
        Set(ByVal value As Boolean)
            m_logico_03 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property logico_04() As Boolean
        Get
            Return m_logico_04
        End Get
        Set(ByVal value As Boolean)
            m_logico_04 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property logico_05() As Boolean
        Get
            Return m_logico_05
        End Get
        Set(ByVal value As Boolean)
            m_logico_05 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "ACT", value)
        End Set
    End Property

    Public Property usuario_registro() As String
        Get
            Return m_usuario_registro
        End Get
        Set(ByVal value As String)
            m_usuario_registro = IIf(String.IsNullOrEmpty(value), "SISTEMAS", value)
        End Set
    End Property

    Public Property fecha_registro() As DateTime
        Get
            Return m_fecha_registro
        End Get
        Set(ByVal value As DateTime)
            m_fecha_registro = IIf(String.IsNullOrEmpty(value), Now, value)
        End Set
    End Property

    Public Property usuario_modifica() As String
        Get
            Return m_usuario_modifica
        End Get
        Set(ByVal value As String)
            m_usuario_modifica = If(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property fecha_modifica() As DateTime
        Get
            Return m_fecha_modifica
        End Get
        Set(ByVal value As DateTime)
            m_fecha_modifica = IIf(String.IsNullOrEmpty(value), Now, value)
        End Set
    End Property

    Public Property nombre_tabla() As String
        Get
            Return m_nombre_tabla
        End Get
        Set(ByVal value As String)
            m_nombre_tabla = value
        End Set
    End Property

    Public Property CancelProcess() As String
        Get
            Return m_CancelProcess
        End Get
        Set(ByVal value As String)
            m_CancelProcess = If(String.IsNullOrEmpty(value), "YES", value)
        End Set
    End Property

End Class
