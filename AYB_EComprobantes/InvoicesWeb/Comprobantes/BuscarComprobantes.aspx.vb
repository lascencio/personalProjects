Public Class BuscarComprobantes
    Inherits System.Web.UI.Page

    Private MyUsuario As entUsuario
    Private MyEComprobante As entEComprobante
    Private MySelectedClient As String
    Private MyEComprobantesLista As dsEComprobantes.ECOMPROBANTES_LISTADataTable

    Public Sub EvalSession()
        MyUsuario = Session("MyUsuario")
        If MyUsuario.usuario Is Nothing Then Response.Redirect("/Commons/Login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EvalSession()
        If Page.IsPostBack = False Then
            MyUsuario = Session("MyUsuario")
            MyEComprobante = New entEComprobante
            ddlClientes.DataSource = dalAnexos.PoblarAnexosClientes
            ddlClientes.DataBind()

            If MyUsuario.RUC <> MyRUC Then
                ddlClientes.Enabled = False
                ddlClientes.SelectedValue = MyUsuario.RUC
                txtDocIdentidad.Enabled = False
                txtDocIdentidad.Text = MyUsuario.RUC
                chk1.Enabled = False
                chk2.Enabled = False
                chk1.Checked = False
            End If

        End If
    End Sub

    Protected Sub lbtBuscar_Click(sender As Object, e As EventArgs) Handles lbtBuscar.Click
        If txtFechaDesde.Text.Trim.Length <> 0 And txtFechaHasta.Text.Trim.Length <> 0 Then
            Call ActualizarGrilla()
        End If
    End Sub

    Private Sub ActualizarGrilla()
        Dim FechaDesde As Date = CDate(txtFechaDesde.Text)
        Dim FechaHasta As Date = CDate(txtFechaHasta.Text)

        Dim MyFechaDesde As String = CStr(FechaDesde.Year * 10000 + FechaDesde.Month * 100 + FechaDesde.Day)
        Dim MyFechaHasta As String = CStr(FechaHasta.Year * 10000 + FechaHasta.Month * 100 + FechaHasta.Day)

        EvalSession()

        If chk1.Checked = True Then
            MySelectedClient = ddlClientes.SelectedValue.Trim
        Else
            MySelectedClient = txtDocIdentidad.Text.Trim
        End If

        MyEComprobantesLista = dalEComprobante.ObtenerEComprobantes(MyUsuario.empresa, MySelectedClient, MyFechaDesde, MyFechaHasta)
        If MyEComprobantesLista.Rows.Count = 0 Then
            gvComprobantes.DataSource = Nothing
        Else
            gvComprobantes.DataSource = MyEComprobantesLista
        End If
        gvComprobantes.DataBind()
    End Sub

    Private Sub gvComprobantes_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvComprobantes.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = sender.Rows(index)
        Dim MyNombreArchivo As String
        sender.SelectedIndex = index

        MyNombreArchivo = sender.SelectedDataKey("Nombre_archivo")
        If (e.CommandName = "DescargarPDF") Then
            Session("MyArchivoDescargar") = MyNombreArchivo & ".pdf"
            Response.Redirect("/Commons/Downloader.aspx")
        ElseIf (e.CommandName = "DescargarXML") Then
            Session("MyArchivoDescargar") = MyNombreArchivo & ".zip"
            Response.Redirect("/Commons/Downloader.aspx")
        End If
    End Sub

    Protected Sub chk1_CheckedChanged(sender As Object, e As EventArgs) Handles chk1.CheckedChanged
        chk2.Checked = False
        ddlClientes.Enabled = True
        txtDocIdentidad.Enabled = False
        If chk1.Checked = False Then
            chk2.Checked = True
            ddlClientes.Enabled = False
            txtDocIdentidad.Enabled = True
        End If
    End Sub

    Protected Sub chk2_CheckedChanged(sender As Object, e As EventArgs) Handles chk2.CheckedChanged
        chk1.Checked = False
        ddlClientes.Enabled = False
        txtDocIdentidad.Enabled = True
        If chk2.Checked = False Then
            chk1.Checked = True
            ddlClientes.Enabled = True
            txtDocIdentidad.Enabled = False
        End If
    End Sub
End Class