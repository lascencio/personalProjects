Public Class entListaElemento

    Private m_codigo As String
    Private m_descripcion As String

    Public Sub New()
        Me.codigo = Nothing
        Me.descripcion = Nothing
    End Sub

    Public Sub New(ByVal ListaElemento As entListaElemento)
        With ListaElemento
            m_codigo = .codigo
            m_descripcion = .descripcion
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

End Class
