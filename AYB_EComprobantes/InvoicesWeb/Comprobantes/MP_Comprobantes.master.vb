Public Class MP_Comprobantes
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MyUsuario As entUsuario
        MyUsuario = Session("MyUsuario")
        'Master.TextoEnUsuario = "USUARIO: " & MyUsuario.descripcion
    End Sub

End Class