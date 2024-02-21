Public Class entUsuario

    Private m_usuario As String
    Private m_descripcion As String
    Private m_clave As String
    Private m_email As String
    Private m_empresa As String
    Private m_perfil As String
    Private m_aprobar_mn As Single = 0
    Private m_aprobar_me As Single = 0
    Private m_privilegios As Byte = 3
    Private m_periodo_unico As Boolean
    Private m_estado As String = "INA"
    Private m_es_conforme As Boolean = False
    Private m_cambiar_clave As Boolean = False
    Private m_ejercicio As String = ""
    Private m_mes As Byte = 0
    Private m_ejercicio_anterior As String = ""
    Private m_mes_anterior As Byte = 0

    Public Sub New()
    End Sub

    Public Sub New(ByVal Usuario As entUsuario)
        With Usuario
            m_usuario = .usuario
            m_descripcion = .descripcion
            m_clave = .clave
            m_email = .email
            m_empresa = .empresa
            m_perfil = .perfil
            m_aprobar_mn = .aprobar_mn
            m_aprobar_me = .aprobar_me
            m_privilegios = .privilegios
            m_periodo_unico = .periodo_unico
            m_estado = .estado
            m_es_conforme = .es_conforme
            m_cambiar_clave = .cambiar_clave
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_ejercicio_anterior = .ejercicio_anterior
            m_mes_anterior = .mes_anterior
        End With
    End Sub

    Public Property usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property

    Public Property clave() As String
        Get
            Return m_clave
        End Get
        Set(ByVal value As String)
            m_clave = value
        End Set
    End Property

    Public Property perfil() As String
        Get
            Return m_perfil
        End Get
        Set(ByVal value As String)
            m_perfil = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
        End Set
    End Property

    Public Property periodo_unico() As Boolean
        Get
            Return m_periodo_unico
        End Get
        Set(ByVal value As Boolean)
            m_periodo_unico = value
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

    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property

    Public Property empresa() As String
        Get
            Return m_empresa
        End Get
        Set(ByVal value As String)
            m_empresa = value
        End Set
    End Property

    Public Property aprobar_mn() As Single
        Get
            Return m_aprobar_mn
        End Get
        Set(ByVal value As Single)
            m_aprobar_mn = value
        End Set
    End Property

    Public Property aprobar_me() As Single
        Get
            Return m_aprobar_me
        End Get
        Set(ByVal value As Single)
            m_aprobar_me = value
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

    Public Property cambiar_clave() As Boolean
        Get
            Return m_cambiar_clave
        End Get
        Set(ByVal value As Boolean)
            m_cambiar_clave = value
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

    Public Property mes() As Byte
        Get
            Return m_mes
        End Get
        Set(ByVal value As Byte)
            m_mes = value
        End Set
    End Property

    Public Property ejercicio_anterior() As String
        Get
            Return m_ejercicio_anterior
        End Get
        Set(ByVal value As String)
            m_ejercicio_anterior = value
        End Set
    End Property

    Public Property mes_anterior() As Byte
        Get
            Return m_mes_anterior
        End Get
        Set(ByVal value As Byte)
            m_mes_anterior = value
        End Set
    End Property

End Class
