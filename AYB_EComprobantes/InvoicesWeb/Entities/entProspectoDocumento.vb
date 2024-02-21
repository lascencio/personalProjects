Public Class entProspectoDocumento
    Private m_empresa As String
    Private m_prospecto As String
    Private m_documento As String
    Private m_tipo_documento As String
    Private m_nombre_archivo As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Private m_indica_proveedor_existe As Boolean
    Private m_codigo_archivo As String

    Public Sub New()
        Me.empresa = Nothing
        Me.prospecto = Nothing
        Me.documento = Nothing
        Me.tipo_documento = Nothing
        Me.nombre_archivo = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing

        Me.m_indica_proveedor_existe = Nothing
        Me.m_codigo_archivo = Nothing
    End Sub

    Public Sub New(ByVal ProspectoDocumento As entProspectoDocumento)
        With ProspectoDocumento
            m_empresa = .empresa
            m_prospecto = .prospecto
            m_documento = .documento
            m_tipo_documento = .tipo_documento
            m_nombre_archivo = .nombre_archivo
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

            m_indica_proveedor_existe = .indica_proveedor_existe
            m_codigo_archivo = .codigo_archivo
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

    Public Property prospecto() As String
        Get
            Return m_prospecto
        End Get
        Set(ByVal value As String)
            m_prospecto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property documento() As String
        Get
            Return m_documento
        End Get
        Set(ByVal value As String)
            m_documento = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_documento() As String
        Get
            Return m_tipo_documento
        End Get
        Set(ByVal value As String)
            m_tipo_documento = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property nombre_archivo() As String
        Get
            Return m_nombre_archivo
        End Get
        Set(ByVal value As String)
            m_nombre_archivo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property codigo_archivo() As String
        Get
            Return m_codigo_archivo
        End Get
        Set(ByVal value As String)
            m_codigo_archivo = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property indica_proveedor_existe() As Boolean
        Get
            Return m_indica_proveedor_existe
        End Get
        Set(ByVal value As Boolean)
            m_indica_proveedor_existe = IIf(String.IsNullOrEmpty(value), True, value)
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
            m_fecha_registro = IIf(value = "#12:00:00 AM#", FechaNulo, value)
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
            m_fecha_modifica = IIf(value = "#12:00:00 AM#", FechaNulo, value)
        End Set
    End Property

End Class
