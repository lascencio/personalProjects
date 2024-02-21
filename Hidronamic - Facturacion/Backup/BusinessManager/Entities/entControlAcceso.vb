Public Class entControlAcceso
    Private m_empresa As String = "000"
    Private m_usuario As String
    Private m_nivel_1 As String
    Private m_nivel_2 As String
    Private m_nivel_3 As String
    Private m_privilegios As Byte = 3
    Private m_permitir_imprimir As Boolean
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
    End Sub

    Public Sub New(ByVal ControlAcceso As entControlAcceso)
        With ControlAcceso
            m_empresa = .empresa
            m_usuario = .usuario
            m_nivel_1 = .nivel_1
            m_nivel_2 = .nivel_2
            m_nivel_3 = .nivel_3
            m_privilegios = .privilegios
            m_permitir_imprimir = .permitir_imprimir
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
            m_empresa = IIf(String.IsNullOrEmpty(value), "000", value)
        End Set
    End Property

    Public Property usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Public Property nivel_1() As String
        Get
            Return m_nivel_1
        End Get
        Set(ByVal value As String)
            m_nivel_1 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property nivel_2() As String
        Get
            Return m_nivel_2
        End Get
        Set(ByVal value As String)
            m_nivel_2 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property nivel_3() As String
        Get
            Return m_nivel_3
        End Get
        Set(ByVal value As String)
            m_nivel_3 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property privilegios() As Byte
        Get
            Return m_privilegios
        End Get
        Set(ByVal value As Byte)
            m_privilegios = value
        End Set
    End Property

    Public Property permitir_imprimir() As Boolean
        Get
            Return m_permitir_imprimir
        End Get
        Set(ByVal value As Boolean)
            m_permitir_imprimir = value
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
            m_usuario_modifica = IIf(String.IsNullOrEmpty(value), " ", value)
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

End Class
