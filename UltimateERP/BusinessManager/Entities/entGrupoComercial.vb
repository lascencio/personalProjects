Public Class entGrupoComercial
    Private m_empresa As String
    Private m_grupo_comercial As String
    Private m_denominacion As String
    Private m_telefono As String
    Private m_celular As String
    Private m_fax As String
    Private m_email As String
    Private m_contacto_comercial As String
    Private m_linea_credito_mn As Single
    Private m_linea_credito_me As Single
    Private m_saldo_pagar_mn As Single
    Private m_saldo_pagar_me As Single
    Private m_vigencia_credito As Date
    Private m_lista_precios As String
    Private m_porcentaje_descuento_1 As Single
    Private m_porcentaje_descuento_2 As Single
    Private m_porcentaje_descuento_3 As Single
    Private m_calificacion As String
    Private m_zona_comercial As String
    Private m_comentario As String
    Private m_usuario_web As String
    Private m_clave_web As String
    Private m_codigo_vendedor As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.grupo_comercial = Nothing
        Me.denominacion = Nothing
        Me.telefono = Nothing
        Me.celular = Nothing
        Me.fax = Nothing
        Me.email = Nothing
        Me.contacto_comercial = Nothing
        Me.linea_credito_mn = Nothing
        Me.linea_credito_me = Nothing
        Me.saldo_pagar_mn = Nothing
        Me.saldo_pagar_me = Nothing
        Me.vigencia_credito = Nothing
        Me.lista_precios = Nothing
        Me.porcentaje_descuento_1 = Nothing
        Me.porcentaje_descuento_2 = Nothing
        Me.porcentaje_descuento_3 = Nothing
        Me.calificacion = Nothing
        Me.zona_comercial = Nothing
        Me.comentario = Nothing
        Me.usuario_web = Nothing
        Me.clave_web = Nothing
        Me.codigo_vendedor = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal GrupoComercial As entGrupoComercial)

        With GrupoComercial
            m_empresa = .empresa
            m_grupo_comercial = .grupo_comercial
            m_denominacion = .denominacion
            m_telefono = .telefono
            m_celular = .celular
            m_fax = .fax
            m_email = .email
            m_contacto_comercial = .contacto_comercial
            m_linea_credito_mn = .linea_credito_mn
            m_linea_credito_me = .linea_credito_me
            m_saldo_pagar_mn = .saldo_pagar_mn
            m_saldo_pagar_me = .saldo_pagar_me
            m_vigencia_credito = .vigencia_credito
            m_lista_precios = .lista_precios
            m_porcentaje_descuento_1 = .porcentaje_descuento_1
            m_porcentaje_descuento_2 = .porcentaje_descuento_2
            m_porcentaje_descuento_3 = .porcentaje_descuento_3
            m_calificacion = .calificacion
            m_zona_comercial = .zona_comercial
            m_comentario = .comentario
            m_usuario_web = .usuario_web
            m_clave_web = .clave_web
            m_codigo_vendedor = .codigo_vendedor
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

    Public Property grupo_comercial() As String
        Get
            Return m_grupo_comercial
        End Get
        Set(ByVal value As String)
            m_grupo_comercial = value
        End Set
    End Property

    Public Property denominacion() As String
        Get
            Return m_denominacion
        End Get
        Set(ByVal value As String)
            m_denominacion = value
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property celular() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property fax() As String
        Get
            Return m_fax
        End Get
        Set(ByVal value As String)
            m_fax = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property contacto_comercial() As String
        Get
            Return m_contacto_comercial
        End Get
        Set(ByVal value As String)
            m_contacto_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property linea_credito_mn() As Single
        Get
            Return m_linea_credito_mn
        End Get
        Set(ByVal value As Single)
            m_linea_credito_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property linea_credito_me() As Single
        Get
            Return m_linea_credito_me
        End Get
        Set(ByVal value As Single)
            m_linea_credito_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property saldo_pagar_mn() As Single
        Get
            Return m_saldo_pagar_mn
        End Get
        Set(ByVal value As Single)
            m_saldo_pagar_mn = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property saldo_pagar_me() As Single
        Get
            Return m_saldo_pagar_me
        End Get
        Set(ByVal value As Single)
            m_saldo_pagar_me = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property vigencia_credito() As Date
        Get
            Return m_vigencia_credito
        End Get
        Set(ByVal value As Date)
            m_vigencia_credito = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property lista_precios() As String
        Get
            Return m_lista_precios
        End Get
        Set(ByVal value As String)
            m_lista_precios = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property porcentaje_descuento_1() As Single
        Get
            Return m_porcentaje_descuento_1
        End Get
        Set(ByVal value As Single)
            m_porcentaje_descuento_1 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property porcentaje_descuento_2() As Single
        Get
            Return m_porcentaje_descuento_2
        End Get
        Set(ByVal value As Single)
            m_porcentaje_descuento_2 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property porcentaje_descuento_3() As Single
        Get
            Return m_porcentaje_descuento_3
        End Get
        Set(ByVal value As Single)
            m_porcentaje_descuento_3 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property calificacion() As String
        Get
            Return m_calificacion
        End Get
        Set(ByVal value As String)
            m_calificacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property zona_comercial() As String
        Get
            Return m_zona_comercial
        End Get
        Set(ByVal value As String)
            m_zona_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
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

    Public Property usuario_web() As String
        Get
            Return m_usuario_web
        End Get
        Set(ByVal value As String)
            m_usuario_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property clave_web() As String
        Get
            Return m_clave_web
        End Get
        Set(ByVal value As String)
            m_clave_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property codigo_vendedor() As String
        Get
            Return m_codigo_vendedor
        End Get
        Set(ByVal value As String)
            m_codigo_vendedor = IIf(String.IsNullOrEmpty(value), Space(1), value)
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
        Set(ByVal value As Date)
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
