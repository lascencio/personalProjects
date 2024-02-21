Public Class entTablaCabecera
    Private m_empresa As String = "000"
    Private m_codigo_tabla As String
    Private m_nombre_corto As String
    Private m_nombre_largo As String
    Private m_necesidad As String = "GENERICA"
    Private m_ttexto_01 As String = " "
    Private m_ttexto_02 As String = " "
    Private m_ttexto_03 As String = " "
    Private m_ttexto_04 As String = " "
    Private m_ttexto_05 As String = " "
    Private m_tvalor_01 As String = " "
    Private m_tvalor_02 As String = " "
    Private m_tvalor_03 As String = " "
    Private m_tvalor_04 As String = " "
    Private m_tvalor_05 As String = " "
    Private m_tlogico_01 As String = " "
    Private m_tlogico_02 As String = " "
    Private m_tlogico_03 As String = " "
    Private m_tlogico_04 As String = " "
    Private m_tlogico_05 As String = " "
    Private m_estado As String = "ACT"
    Private m_usuario_registro As String = "SISTEMAS"
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String = " "
    Private m_fecha_modifica As Date

    Private m_CancelProcess As String

    Public Sub New()
        Me.empresa = Nothing
        Me.codigo_tabla = Nothing
        Me.nombre_corto = Nothing
        Me.nombre_largo = Nothing
        Me.necesidad = Nothing
        Me.ttexto_01 = Nothing
        Me.ttexto_02 = Nothing
        Me.ttexto_03 = Nothing
        Me.ttexto_04 = Nothing
        Me.ttexto_05 = Nothing
        Me.tvalor_01 = Nothing
        Me.tvalor_02 = Nothing
        Me.tvalor_03 = Nothing
        Me.tvalor_04 = Nothing
        Me.tvalor_05 = Nothing
        Me.tlogico_01 = Nothing
        Me.tlogico_02 = Nothing
        Me.tlogico_03 = Nothing
        Me.tlogico_04 = Nothing
        Me.tlogico_05 = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
        Me.CancelProcess = Nothing
    End Sub

    Public Sub New(ByVal TablaCabecera As entTablaCabecera)
        With TablaCabecera
            m_empresa = .empresa
            m_codigo_tabla = .codigo_tabla
            m_nombre_corto = .nombre_corto
            m_nombre_largo = .nombre_largo
            m_necesidad = .necesidad
            m_ttexto_01 = .ttexto_01
            m_ttexto_02 = .ttexto_02
            m_ttexto_03 = .ttexto_03
            m_ttexto_04 = .ttexto_04
            m_ttexto_05 = .ttexto_05
            m_tvalor_01 = .tvalor_01
            m_tvalor_02 = .tvalor_02
            m_tvalor_03 = .tvalor_03
            m_tvalor_04 = .tvalor_04
            m_tvalor_05 = .tvalor_05
            m_tlogico_01 = .tlogico_01
            m_tlogico_02 = .tlogico_02
            m_tlogico_03 = .tlogico_03
            m_tlogico_04 = .tlogico_04
            m_tlogico_05 = .tlogico_05
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica

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

    Public Property necesidad() As String
        Get
            Return m_necesidad
        End Get
        Set(ByVal value As String)
            m_necesidad = IIf(String.IsNullOrEmpty(value), "GENERAL", value)
        End Set
    End Property

    Public Property ttexto_01() As String
        Get
            Return m_ttexto_01
        End Get
        Set(ByVal value As String)
            m_ttexto_01 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property ttexto_02() As String
        Get
            Return m_ttexto_02
        End Get
        Set(ByVal value As String)
            m_ttexto_02 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property ttexto_03() As String
        Get
            Return m_ttexto_03
        End Get
        Set(ByVal value As String)
            m_ttexto_03 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property ttexto_04() As String
        Get
            Return m_ttexto_04
        End Get
        Set(ByVal value As String)
            m_ttexto_04 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property ttexto_05() As String
        Get
            Return m_ttexto_05
        End Get
        Set(ByVal value As String)
            m_ttexto_05 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tvalor_01() As String
        Get
            Return m_tvalor_01
        End Get
        Set(ByVal value As String)
            m_tvalor_01 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tvalor_02() As String
        Get
            Return m_tvalor_02
        End Get
        Set(ByVal value As String)
            m_tvalor_02 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tvalor_03() As String
        Get
            Return m_tvalor_03
        End Get
        Set(ByVal value As String)
            m_tvalor_03 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tvalor_04() As String
        Get
            Return m_tvalor_04
        End Get
        Set(ByVal value As String)
            m_tvalor_04 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tvalor_05() As String
        Get
            Return m_tvalor_05
        End Get
        Set(ByVal value As String)
            m_tvalor_05 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tlogico_01() As String
        Get
            Return m_tlogico_01
        End Get
        Set(ByVal value As String)
            m_tlogico_01 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tlogico_02() As String
        Get
            Return m_tlogico_02
        End Get
        Set(ByVal value As String)
            m_tlogico_02 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tlogico_03() As String
        Get
            Return m_tlogico_03
        End Get
        Set(ByVal value As String)
            m_tlogico_03 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tlogico_04() As String
        Get
            Return m_tlogico_04
        End Get
        Set(ByVal value As String)
            m_tlogico_04 = IIf(String.IsNullOrEmpty(value), " ", value)
        End Set
    End Property

    Public Property tlogico_05() As String
        Get
            Return m_tlogico_05
        End Get
        Set(ByVal value As String)
            m_tlogico_05 = IIf(String.IsNullOrEmpty(value), " ", value)
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

    Public Property CancelProcess() As String
        Get
            Return m_CancelProcess
        End Get
        Set(ByVal value As String)
            m_CancelProcess = If(String.IsNullOrEmpty(value), "YES", value)
        End Set
    End Property

End Class
