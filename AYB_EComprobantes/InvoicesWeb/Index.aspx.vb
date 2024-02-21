Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Master.TextoEnLabel = "Login"
        'MyTempPath = Server.MapPath("~/Temp/")
        MyTempPath = Server.MapPath("/Temp/")
        Response.Redirect("/Commons/Login.aspx")
    End Sub

End Class