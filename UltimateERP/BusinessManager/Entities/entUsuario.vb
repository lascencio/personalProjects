Public Class entUsuario

    Private m_empresa As String
    Private m_usuario As String
    Private m_descripcion As String
    Private m_clave As String
    Private m_email As String
    Private m_perfil As String
    Private m_aprobar_mn As Decimal
    Private m_aprobar_me As Decimal
    Private m_privilegios As Byte
    Private m_es_plantilla As Boolean
    Private m_emite_ticket As Boolean
    Private m_estado As String
    Private m_es_conforme As Boolean
    Private m_cambiar_clave As Boolean
    Private m_ejercicio As String = ""
    Private m_mes As Byte = 0
    Private m_periodo_actual As String = ""
    Private m_ejercicio_anterior As String = ""
    Private m_mes_anterior As Byte = 0

    Private m_serie_asignada As String
    Private m_almacen As String

    Public Sub New()
        Me.empresa = Nothing
        Me.usuario = Nothing
        Me.descripcion = Nothing
        Me.clave = Nothing
        Me.email = Nothing
        Me.perfil = Nothing
        Me.aprobar_mn = Nothing
        Me.aprobar_me = Nothing
        Me.privilegios = Nothing
        Me.es_plantilla = Nothing
        Me.emite_ticket = Nothing
        Me.estado = Nothing
        Me.es_conforme = Nothing
        Me.cambiar_clave = Nothing
        Me.ejercicio = Nothing
        Me.mes = Nothing
        Me.periodo_actual = Nothing
        Me.ejercicio_anterior = Nothing
        Me.mes_anterior = Nothing
        Me.serie_asignada = Nothing
        Me.almacen = Nothing
    End Sub

    Public Sub New(ByVal Usuario As entUsuario)
        With Usuario
            m_empresa = .empresa
            m_usuario = .usuario
            m_descripcion = .descripcion
            m_clave = .clave
            m_email = .email
            m_perfil = .perfil
            m_aprobar_mn = .aprobar_mn
            m_aprobar_me = .aprobar_me
            m_privilegios = .privilegios
            m_es_plantilla = .es_plantilla
            m_emite_ticket = .emite_ticket
            m_estado = .estado
            m_es_conforme = .es_conforme
            m_cambiar_clave = .cambiar_clave
            m_ejercicio = .ejercicio
            m_mes = .mes
            m_periodo_actual = .periodo_actual
            m_ejercicio_anterior = .ejercicio_anterior
            m_mes_anterior = .mes_anterior
            m_serie_asignada = .serie_asignada
            m_almacen = .almacen
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

    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property perfil() As String
        Get
            Return m_perfil
        End Get
        Set(ByVal value As String)
            m_perfil = IIf(String.IsNullOrEmpty(value), usuario, value)
        End Set
    End Property

    Public Property aprobar_mn() As Decimal
        Get
            Return m_aprobar_mn
        End Get
        Set(ByVal value As Decimal)
            m_aprobar_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property aprobar_me() As Decimal
        Get
            Return m_aprobar_me
        End Get
        Set(ByVal value As Decimal)
            m_aprobar_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property privilegios() As Byte
        Get
            Return m_privilegios
        End Get
        Set(ByVal value As Byte)
            m_privilegios = IIf(String.IsNullOrEmpty(value), 4, value)
        End Set
    End Property

    Public Property es_plantilla() As Boolean
        Get
            Return m_es_plantilla
        End Get
        Set(ByVal value As Boolean)
            m_es_plantilla = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property emite_ticket() As Boolean
        Get
            Return m_emite_ticket
        End Get
        Set(ByVal value As Boolean)
            m_emite_ticket = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "INA", value)
        End Set
    End Property

    Public Property es_conforme() As Boolean
        Get
            Return m_es_conforme
        End Get
        Set(ByVal value As Boolean)
            m_es_conforme = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property cambiar_clave() As Boolean
        Get
            Return m_cambiar_clave
        End Get
        Set(ByVal value As Boolean)
            m_cambiar_clave = IIf(String.IsNullOrEmpty(value), False, value)
        End Set
    End Property

    Public Property ejercicio() As String
        Get
            Return m_ejercicio
        End Get
        Set(ByVal value As String)
            m_ejercicio = IIf(String.IsNullOrEmpty(value), Now.Year.ToString, value)
        End Set
    End Property

    Public Property mes() As Byte
        Get
            Return m_mes
        End Get
        Set(ByVal value As Byte)
            m_mes = IIf(String.IsNullOrEmpty(value), Now.Month, value)
        End Set
    End Property

    Public Property periodo_actual() As String
        Get
            Return m_periodo_actual
        End Get
        Set(ByVal value As String)
            m_periodo_actual = value
        End Set
    End Property

    Public Property ejercicio_anterior() As String
        Get
            Return m_ejercicio_anterior
        End Get
        Set(ByVal value As String)
            m_ejercicio_anterior = IIf(String.IsNullOrEmpty(value), Now.Year.ToString, value)
        End Set
    End Property

    Public Property mes_anterior() As Byte
        Get
            Return m_mes_anterior
        End Get
        Set(ByVal value As Byte)
            m_mes_anterior = IIf(String.IsNullOrEmpty(value), Now.Month, value)
        End Set
    End Property

    Public Property serie_asignada() As String
        Get
            Return m_serie_asignada
        End Get
        Set(ByVal value As String)
            m_serie_asignada = IIf(String.IsNullOrEmpty(value), "1", value)
        End Set
    End Property

    Public Property almacen() As String
        Get
            Return m_almacen
        End Get
        Set(ByVal value As String)
            m_almacen = IIf(String.IsNullOrEmpty(value), "001", value)
        End Set
    End Property

End Class
