Public Class BusinessException

    Inherits ApplicationException

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

End Class
