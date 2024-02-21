Public Class Main
    Inherits System.Web.UI.MasterPage

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'ResolveClientUrl("~/App_Themes/MyTheme/MyStyles.css")
    'End Sub

    'Public Property TextoEnLabel() As String
    '    Get
    '        Return lblLogInOut.Text
    '    End Get
    '    Set(ByVal value As String)
    '        lblLogInOut.Text = value
    '    End Set
    'End Property

    Public Property TextoEnUsuario() As String
        Get
            Return lblUsuario.Text
        End Get
        Set(ByVal value As String)
            lblUsuario.Text = value
        End Set
    End Property


End Class