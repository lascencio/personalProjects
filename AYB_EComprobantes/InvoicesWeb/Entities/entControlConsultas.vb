Public Class entControlConsultas

    Private m_empresa As String
    Private m_usuario As String
    Private m_prospecto As String
    Private m_cuenta_comercial As String
    Private m_marca As String
    Private m_tipo_servicio As String
    Private m_area As String
    Private m_responsable_venta As String
    Private m_responsable_ejecucion As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.usuario = Nothing
        Me.prospecto = Nothing
        Me.cuenta_comercial = Nothing
        Me.marca = Nothing
        Me.tipo_servicio = Nothing
        Me.area = Nothing
        Me.responsable_venta = Nothing
        Me.responsable_ejecucion = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal ControlConsultas As entControlConsultas)
        With ControlConsultas
            m_empresa = .empresa
            m_usuario = .usuario
            m_prospecto = .prospecto
            m_cuenta_comercial = .cuenta_comercial
            m_marca = .marca
            m_tipo_servicio = .tipo_servicio
            m_area = .area
            m_responsable_venta = .responsable_venta
            m_responsable_ejecucion = .responsable_ejecucion
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

    Public Property usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Public Property prospecto() As String
        Get
            Return m_prospecto
        End Get
        Set(ByVal value As String)
            m_prospecto = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property marca() As String
        Get
            Return m_marca
        End Get
        Set(ByVal value As String)
            m_marca = IIf(String.IsNullOrEmpty(value), "ALL", value)
        End Set
    End Property

    Public Property tipo_servicio() As String
        Get
            Return m_tipo_servicio
        End Get
        Set(ByVal value As String)
            m_tipo_servicio = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property responsable_venta() As String
        Get
            Return m_responsable_venta
        End Get
        Set(ByVal value As String)
            m_responsable_venta = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property responsable_ejecucion() As String
        Get
            Return m_responsable_ejecucion
        End Get
        Set(ByVal value As String)
            m_responsable_ejecucion = IIf(String.IsNullOrEmpty(value), "TODOS", value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "T", value)
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
