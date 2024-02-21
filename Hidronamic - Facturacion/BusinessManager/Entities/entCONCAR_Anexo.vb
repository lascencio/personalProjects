Public Class entCONCAR_Anexo
    Private m_avanexo As String
    Private m_acodane As String
    Private m_adesane As String
    Private m_arefane As String
    Private m_aruc As String
    Private m_acodmon As String
    Private m_aestado As String
    Private m_adate As Date
    Private m_ahora As String

    Private m_apaterno As String
    Private m_amaterno As String
    Private m_anombre As String
    Private m_atiptra As String
    Private m_adocide As String
    Private m_anumide As String
    Private m_atippro As String
    Private m_anacio As String
    Private m_aessal As String
    Private m_adomic As String

    Private m_asitua As String
    Private m_aticonv As String

    Private m_amemo As String

    Public Sub New()
        Me.avanexo = Nothing
        Me.acodane = Nothing
        Me.adesane = Nothing
        Me.arefane = Nothing
        Me.aruc = Nothing
        Me.acodmon = Nothing
        Me.aestado = Nothing
        Me.adate = Nothing
        Me.ahora = Nothing

        Me.apaterno = Nothing
        Me.amaterno = Nothing
        Me.anombre = Nothing
        Me.atiptra = Nothing
        Me.adocide = Nothing
        Me.anumide = Nothing
        Me.atippro = Nothing
        Me.anacio = Nothing
        Me.aessal = Nothing
        Me.adomic = Nothing

        Me.asitua = Nothing
        Me.aticonv = Nothing

        Me.amemo = Nothing

    End Sub

    Public Sub New(ByVal Anexo As entCONCAR_Anexo)
        With Anexo
            m_avanexo = .avanexo
            m_acodane = .acodane
            m_adesane = .adesane
            m_arefane = .arefane
            m_aruc = .aruc
            m_acodmon = .acodmon
            m_aestado = .aestado
            m_adate = .adate
            m_ahora = .ahora

            m_apaterno = .apaterno
            m_amaterno = .amaterno
            m_anombre = .anombre
            m_atiptra = .atiptra
            m_adocide = .adocide
            m_anumide = .anumide
            m_atippro = .atippro
            m_anacio = .anacio
            m_aessal = .aessal
            m_adomic = .adomic

            m_asitua = .asitua
            m_aticonv = .aticonv

            m_amemo = .amemo
        End With
    End Sub

    Public Property avanexo() As String
        Get
            Return m_avanexo
        End Get
        Set(ByVal value As String)
            m_avanexo = value
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

    Public Property adate() As Date
        Get
            Return m_adate
        End Get
        Set(ByVal value As Date)
            m_adate = IIf(value.Ticks = 0, Now.Date, value)
        End Set
    End Property

    Public Property ahora() As String
        Get
            Return m_ahora
        End Get
        Set(ByVal value As String)
            m_ahora = IIf(String.IsNullOrEmpty(value), Strings.Right("00" & Now.Hour.ToString.Trim, 2) & ":" & Strings.Right("00" & Now.Minute.ToString.Trim, 2) & ":", value)
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

    Public Property atiptra() As String
        Get
            Return m_atiptra
        End Get
        Set(ByVal value As String)
            m_atiptra = IIf(String.IsNullOrEmpty(value), "N", value)
        End Set
    End Property

    Public Property adocide() As String
        Get
            Return m_adocide
        End Get
        Set(ByVal value As String)
            m_adocide = IIf(String.IsNullOrEmpty(value), "1", value)
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

    Public Property atippro() As String
        Get
            Return m_atippro
        End Get
        Set(ByVal value As String)
            m_atippro = IIf(String.IsNullOrEmpty(value), "N", value)
        End Set
    End Property

    Public Property anacio() As String
        Get
            Return m_anacio
        End Get
        Set(ByVal value As String)
            m_anacio = IIf(String.IsNullOrEmpty(value), "9589", value)
        End Set
    End Property

    Public Property aessal() As String
        Get
            Return m_aessal
        End Get
        Set(ByVal value As String)
            m_aessal = IIf(String.IsNullOrEmpty(value), "0", value)
        End Set
    End Property

    Public Property adomic() As String
        Get
            Return m_adomic
        End Get
        Set(ByVal value As String)
            m_adomic = IIf(String.IsNullOrEmpty(value), "SI", value)
        End Set
    End Property

    Public Property asitua() As String
        Get
            Return m_asitua
        End Get
        Set(ByVal value As String)
            m_asitua = IIf(String.IsNullOrEmpty(value), "01", value)
        End Set
    End Property

    Public Property aticonv() As String
        Get
            Return m_aticonv
        End Get
        Set(ByVal value As String)
            m_aticonv = IIf(String.IsNullOrEmpty(value), "00", value)
        End Set
    End Property

    Public Property amemo() As String
        Get
            Return m_amemo
        End Get
        Set(ByVal value As String)
            m_amemo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

End Class
