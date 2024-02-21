Public Class entCuentaComercialDomicilio

    Private m_empresa As String
    Private m_cuenta_comercial As String
    Private m_domicilio_envio As String
    Private m_descripcion As String
    Private m_via_tipo As String
    Private m_via_nombre As String
    Private m_via_numero As String
    Private m_via_interior As String
    Private m_zona_tipo As String
    Private m_zona_nombre As String
    Private m_referencia As String
    Private m_pais As String
    Private m_departamento As String
    Private m_provincia As String
    Private m_ubigeo As String
    Private m_codigo_postal As String
    Private m_telefono As String
    Private m_celular As String
    Private m_fax As String
    Private m_email As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
    End Sub

    Public Sub New(ByVal CuentaComercialDomicilio As entCuentaComercialDomicilio)

        With CuentaComercialDomicilio
            m_empresa = .empresa
            m_cuenta_comercial = .cuenta_comercial
            m_domicilio_envio = .domicilio_envio
            m_descripcion = .descripcion
            m_via_tipo = .via_tipo
            m_via_nombre = .via_nombre
            m_via_numero = .via_numero
            m_via_interior = .via_interior
            m_zona_tipo = .zona_tipo
            m_zona_nombre = .zona_nombre
            m_referencia = .referencia
            m_pais = .pais
            m_departamento = .departamento
            m_provincia = .provincia
            m_ubigeo = .ubigeo
            m_codigo_postal = .codigo_postal
            m_telefono = .telefono
            m_celular = .celular
            m_fax = .fax
            m_email = .email
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = value
        End Set
    End Property

    Public Property domicilio_envio() As String
        Get
            Return m_domicilio_envio
        End Get
        Set(ByVal value As String)
            m_domicilio_envio = value
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

    Public Property via_tipo() As String
        Get
            Return m_via_tipo
        End Get
        Set(ByVal value As String)
            m_via_tipo = value
        End Set
    End Property

    Public Property via_nombre() As String
        Get
            Return m_via_nombre
        End Get
        Set(ByVal value As String)
            m_via_nombre = value
        End Set
    End Property

    Public Property via_numero() As String
        Get
            Return m_via_numero
        End Get
        Set(ByVal value As String)
            m_via_numero = value
        End Set
    End Property

    Public Property via_interior() As String
        Get
            Return m_via_interior
        End Get
        Set(ByVal value As String)
            m_via_interior = value
        End Set
    End Property

    Public Property zona_tipo() As String
        Get
            Return m_zona_tipo
        End Get
        Set(ByVal value As String)
            m_zona_tipo = value
        End Set
    End Property

    Public Property zona_nombre() As String
        Get
            Return m_zona_nombre
        End Get
        Set(ByVal value As String)
            m_zona_nombre = value
        End Set
    End Property

    Public Property referencia() As String
        Get
            Return m_referencia
        End Get
        Set(ByVal value As String)
            m_referencia = value
        End Set
    End Property

    Public Property pais() As String
        Get
            Return m_pais
        End Get
        Set(ByVal value As String)
            m_pais = value
        End Set
    End Property

    Public Property departamento() As String
        Get
            Return m_departamento
        End Get
        Set(ByVal value As String)
            m_departamento = value
        End Set
    End Property

    Public Property provincia() As String
        Get
            Return m_provincia
        End Get
        Set(ByVal value As String)
            m_provincia = value
        End Set
    End Property

    Public Property ubigeo() As String
        Get
            Return m_ubigeo
        End Get
        Set(ByVal value As String)
            m_ubigeo = value
        End Set
    End Property

    Public Property codigo_postal() As String
        Get
            Return m_codigo_postal
        End Get
        Set(ByVal value As String)
            m_codigo_postal = value
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property

    Public Property celular() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = value
        End Set
    End Property

    Public Property fax() As String
        Get
            Return m_fax
        End Get
        Set(ByVal value As String)
            m_fax = value
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

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
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
            m_fecha_registro = IIf(value.Ticks = 0, Now, value)
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
            m_fecha_modifica = IIf(value.Ticks = 0, Now, value)
        End Set
    End Property

End Class
