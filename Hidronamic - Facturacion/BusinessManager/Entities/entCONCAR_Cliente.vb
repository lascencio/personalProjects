Public Class entCONCAR_Cliente
    Private m_avanexo As String
    Private m_acodane As String
    Private m_adesane As String
    Private m_arefane As String
    Private m_aruc As String
    Private m_acodmon As String
    Private m_aestado As String
    Private m_atiptra As String
    Private m_apaterno As String
    Private m_amaterno As String
    Private m_anombre As String
    Private m_aemail As String
    Private m_ahost As String
    Private m_adocide As String
    Private m_anumide As String


    Public Sub New()
        Me.avanexo = Nothing
        Me.acodane = Nothing
        Me.adesane = Nothing
        Me.arefane = Nothing
        Me.aruc = Nothing
        Me.acodmon = Nothing
        Me.aestado = Nothing
        Me.atiptra = Nothing
        Me.apaterno = Nothing
        Me.amaterno = Nothing
        Me.anombre = Nothing
        Me.aemail = Nothing
        Me.ahost = Nothing
        Me.adocide = Nothing
        Me.anumide = Nothing
    End Sub

    Public Sub New(ByVal Anexo As entCONCAR_Cliente)
        With Anexo
            m_avanexo = .avanexo
            m_acodane = .acodane
            m_adesane = .adesane
            m_arefane = .arefane
            m_aruc = .aruc
            m_acodmon = .acodmon
            m_aestado = .aestado
            m_atiptra = .atiptra
            m_apaterno = .apaterno
            m_amaterno = .amaterno
            m_anombre = .anombre
            m_aemail = .aemail
            m_ahost = .ahost
            m_adocide = .adocide
            m_anumide = .anumide
        End With
    End Sub

    Public Property avanexo() As String
        Get
            Return m_avanexo
        End Get
        Set(ByVal value As String)
            m_avanexo = IIf(String.IsNullOrEmpty(value), "C", value)
        End Set
    End Property

    Public Property acodane() As String
        Get
            Return m_acodane
        End Get
        Set(ByVal value As String)
            m_acodane = value
        End Set
    End Property

    Public Property adesane() As String
        Get
            Return m_adesane
        End Get
        Set(ByVal value As String)
            m_adesane = value
        End Set
    End Property

    Public Property arefane() As String
        Get
            Return m_arefane
        End Get
        Set(ByVal value As String)
            m_arefane = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property aruc() As String
        Get
            Return m_aruc
        End Get
        Set(ByVal value As String)
            m_aruc = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property acodmon() As String
        Get
            Return m_acodmon
        End Get
        Set(ByVal value As String)
            m_acodmon = IIf(String.IsNullOrEmpty(value), "MN", value)
        End Set
    End Property

    Public Property aestado() As String
        Get
            Return m_aestado
        End Get
        Set(ByVal value As String)
            m_aestado = IIf(String.IsNullOrEmpty(value), "V", value)
        End Set
    End Property

    Public Property atiptra() As String
        Get
            Return m_atiptra
        End Get
        Set(ByVal value As String)
            m_atiptra = IIf(String.IsNullOrEmpty(value), "J", value)
        End Set
    End Property

    Public Property apaterno() As String
        Get
            Return m_apaterno
        End Get
        Set(ByVal value As String)
            m_apaterno = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property amaterno() As String
        Get
            Return m_amaterno
        End Get
        Set(ByVal value As String)
            m_amaterno = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property anombre() As String
        Get
            Return m_anombre
        End Get
        Set(ByVal value As String)
            m_anombre = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property aemail() As String
        Get
            Return m_aemail
        End Get
        Set(ByVal value As String)
            m_aemail = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property ahost() As String
        Get
            Return m_ahost
        End Get
        Set(ByVal value As String)
            m_ahost = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property adocide() As String
        Get
            Return m_adocide
        End Get
        Set(ByVal value As String)
            m_adocide = IIf(String.IsNullOrEmpty(value), "6", value)
        End Set
    End Property

    Public Property anumide() As String
        Get
            Return m_anumide
        End Get
        Set(ByVal value As String)
            m_anumide = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

End Class
