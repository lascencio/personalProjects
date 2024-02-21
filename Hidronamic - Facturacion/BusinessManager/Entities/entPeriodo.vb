Public Class entPeriodo
    Private m_empresa As String
    Private m_ejercicio As String
    Private m_modulo As String
    Private m_mes_01 As Byte
    Private m_mes_02 As Byte
    Private m_mes_03 As Byte
    Private m_mes_04 As Byte
    Private m_mes_05 As Byte
    Private m_mes_06 As Byte
    Private m_mes_07 As Byte
    Private m_mes_08 As Byte
    Private m_mes_09 As Byte
    Private m_mes_10 As Byte
    Private m_mes_11 As Byte
    Private m_mes_12 As Byte
    Private m_indica_activo As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
    End Sub

    Public Sub New(ByVal Periodo As entPeriodo)
        With Periodo
            m_empresa = .empresa
            m_ejercicio = .ejercicio
            m_modulo = .modulo
            m_mes_01 = .mes_01
            m_mes_02 = .mes_02
            m_mes_03 = .mes_03
            m_mes_04 = .mes_04
            m_mes_05 = .mes_05
            m_mes_06 = .mes_06
            m_mes_07 = .mes_07
            m_mes_08 = .mes_08
            m_mes_09 = .mes_09
            m_mes_10 = .mes_10
            m_mes_11 = .mes_11
            m_mes_12 = .mes_12
            m_indica_activo = .indica_activo
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

    Public Property ejercicio() As String
        Get
            Return m_ejercicio
        End Get
        Set(ByVal value As String)
            m_ejercicio = value
        End Set
    End Property

    Public Property modulo() As String
        Get
            Return m_modulo
        End Get
        Set(ByVal value As String)
            m_modulo = value
        End Set
    End Property

    Public Property mes_01() As Byte
        Get
            Return m_mes_01
        End Get
        Set(ByVal value As Byte)
            m_mes_01 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_02() As Byte
        Get
            Return m_mes_02
        End Get
        Set(ByVal value As Byte)
            m_mes_02 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_03() As Byte
        Get
            Return m_mes_03
        End Get
        Set(ByVal value As Byte)
            m_mes_03 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_04() As Byte
        Get
            Return m_mes_04
        End Get
        Set(ByVal value As Byte)
            m_mes_04 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_05() As Byte
        Get
            Return m_mes_05
        End Get
        Set(ByVal value As Byte)
            m_mes_05 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_06() As Byte
        Get
            Return m_mes_06
        End Get
        Set(ByVal value As Byte)
            m_mes_06 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_07() As Byte
        Get
            Return m_mes_07
        End Get
        Set(ByVal value As Byte)
            m_mes_07 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_08() As Byte
        Get
            Return m_mes_08
        End Get
        Set(ByVal value As Byte)
            m_mes_08 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_09() As Byte
        Get
            Return m_mes_09
        End Get
        Set(ByVal value As Byte)
            m_mes_09 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_10() As Byte
        Get
            Return m_mes_10
        End Get
        Set(ByVal value As Byte)
            m_mes_10 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_11() As Byte
        Get
            Return m_mes_11
        End Get
        Set(ByVal value As Byte)
            m_mes_11 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property mes_12() As Byte
        Get
            Return m_mes_12
        End Get
        Set(ByVal value As Byte)
            m_mes_12 = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property indica_activo() As String
        Get
            Return m_indica_activo
        End Get
        Set(ByVal value As String)
            m_indica_activo = IIf(String.IsNullOrEmpty(value), "SI", value)
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
