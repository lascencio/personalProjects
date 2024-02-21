Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MyUsuario As entUsuario = Session("MyUsuario")
        'Master.TextoEnLabel = "Logout"
        Master.TextoEnUsuario = MyUsuario.descripcion
    End Sub

End Class