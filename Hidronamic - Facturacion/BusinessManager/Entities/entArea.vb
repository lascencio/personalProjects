Public Class entArea
    Private m_codigo As String
    Private m_descripcion As String
    Private m_director_cuenta As String

    Public Sub New()
        Me.codigo = Nothing
        Me.descripcion = Nothing
        Me.director_cuenta = Nothing
    End Sub

    Public Sub New(ByVal area As entArea)

        With area
            m_codigo = .codigo
            m_descripcion = .descripcion
            m_director_cuenta = .director_cuenta
        End With
    End Sub

    Public Property codigo() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
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

    Public Property director_cuenta() As String
        Get
            Return m_director_cuenta
        End Get
        Set(ByVal value As String)
            m_director_cuenta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

End Class
