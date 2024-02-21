Public Class entCONCAR_Tabla
    Private m_tcod As String
    Private m_tclave As String
    Private m_tdescri As String
    Private m_tdate As Date
    Private m_thora As String

    Public Sub New()
        Me.tcod = Nothing
        Me.tclave = Nothing
        Me.tdescri = Nothing
        Me.tdate = Nothing
        Me.thora = Nothing
    End Sub

    Public Sub New(ByVal Tabla As entCONCAR_Tabla)
        With Tabla
            m_tcod = .tcod
            m_tclave = .tclave
            m_tdescri = .tdescri
            m_tdate = .tdate
            m_thora = .thora
        End With
    End Sub

    Public Property tcod() As String
        Get
            Return m_tcod
        End Get
        Set(ByVal value As String)
            m_tcod = value
        End Set
    End Property

    Public Property tclave() As String
        Get
            Return m_tclave
        End Get
        Set(ByVal value As String)
            m_tclave = value
        End Set
    End Property

    Public Property tdescri() As String
        Get
            Return m_tdescri
        End Get
        Set(ByVal value As String)
            m_tdescri = value
        End Set
    End Property

    Public Property tdate() As Date
        Get
            Return m_tdate
        End Get
        Set(ByVal value As Date)
            m_tdate = IIf(value.Ticks = 0, Now.Date, value)
        End Set
    End Property

    Public Property thora() As String
        Get
            Return m_thora
        End Get
        Set(ByVal value As String)
            m_thora = IIf(String.IsNullOrEmpty(value), Strings.Right("00" & Now.Hour.ToString.Trim, 2) & ":" & Strings.Right("00" & Now.Minute.ToString.Trim, 2) & ":", value)
        End Set
    End Property


End Class
