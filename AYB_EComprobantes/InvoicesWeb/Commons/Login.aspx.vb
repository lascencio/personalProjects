
Public Class Login
    Inherits System.Web.UI.Page

    Private MyDatosEmpresa As entCliente
    Private MyCliente As entCliente
    Private MyUsuario As entUsuario

    Protected divControl_1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected divControl_2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected divControl_3 As System.Web.UI.HtmlControls.HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            MyTempPath = Server.MapPath("/Temp/")

            'divControl_1 = CType(Master.FindControl("divControl_1"), System.Web.UI.HtmlControls.HtmlGenericControl)
            'divControl_1.Style("visibility") = "hidden"
            'divControl_2 = CType(Master.FindControl("divControl_2"), System.Web.UI.HtmlControls.HtmlGenericControl)
            'divControl_2.Style("visibility") = "hidden"
            'divControl_3 = CType(Master.FindControl("divControl_3"), System.Web.UI.HtmlControls.HtmlGenericControl)
            'divControl_3.Style("visibility") = "hidden"

            Session("UsuarioID") = "anonymus"
            lnkIniciarSesion.Focus()
        End If
    End Sub

    Protected Sub txtRUC_TextChanged(sender As Object, e As EventArgs) Handles txtRUC.TextChanged
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = sender.Text.ToUpper
            ReiniciarMensaje(lblMensaje)
            txtUsuario.Focus()
        End If
    End Sub

    Protected Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = sender.Text.ToUpper
            ReiniciarMensaje(lblMensaje)
            txtClave.Focus()
        End If
    End Sub

    Protected Sub txtClave_TextChanged(sender As Object, e As EventArgs) Handles txtClave.TextChanged
        If sender.Text.Trim.Length <> 0 Then
            sender.Text = sender.Text.ToUpper
            ReiniciarMensaje(lblMensaje)
            lnkIniciarSesion.Focus()
        End If
    End Sub

    Private Sub lnkIniciarSesion_Click(sender As Object, e As EventArgs) Handles lnkIniciarSesion.Click
        Dim MyClienteRUC As String = txtRUC.Text.Trim
        Dim MyClienteID As String = txtUsuario.Text.Trim
        Dim MyClienteClave As String = txtClave.Text.Trim
        Try
            If MyClienteRUC.Length = 0 Then Throw New Exception("Número de RUC no puede estar vacio")
            If MyClienteID.Length = 0 Then Throw New Exception("ID del Usuario no puede estar vacio")
            If MyClienteClave.Length = 0 Then Throw New Exception("Contraseña no puede estar vacio")

            MyDatosEmpresa = dalCliente.Obtener(MyEmpresa, MyRUC)
            MyCliente = dalCliente.Obtener(MyEmpresa, MyClienteRUC)

            If MyCliente.cuenta_comercial.Trim.Length = 0 Then
                Throw New Exception("El Número de RUC " & MyClienteRUC & " no se encuentra registrado en la relación de clientes de " & MyRazonSocial)
            Else
                If MyCliente.usuario_web.Trim.Length = 0 Then
                    txtUsuario.Text = Nothing
                    txtClave.Text = Nothing
                    Throw New Exception("No tienen registrado un ID de Usuario. Por favor solicitarlo al correo: " & MyDatosEmpresa.email_facturacion.ToLower)
                Else
                    If MyCliente.clave_web.Trim.Length = 0 Then
                        txtClave.Text = Nothing
                        Throw New Exception("No tienen registrado una Contraseña. Por favor solicitarla al correo: " & MyDatosEmpresa.email_facturacion.ToLower)
                    Else
                        If MyClienteID = MyCliente.usuario_web.Trim And MyClienteClave = MyCliente.clave_web.Trim Then
                            Session("MyCliente") = MyCliente
                            MyUsuario = New entUsuario
                            With MyUsuario
                                .empresa = MyEmpresa
                                .usuario = MyCliente.usuario_web.Trim
                                .descripcion = IIf(MyClienteRUC = MyRUC, "ADMINISTRADOR DEL SISTEMA", MyCliente.usuario_web)
                                .clave = MyCliente.clave_web.Trim
                                .email = MyCliente.email_facturacion.Trim
                                .perfil = IIf(MyClienteRUC = MyRUC, "ADMIN", "GUEST")
                                .aprobar_mn = 0
                                .aprobar_me = 0
                                .periodo_unico = IIf(MyClienteRUC = MyRUC, True, False)
                                .privilegios = IIf(MyClienteRUC = MyRUC, 1, 4)
                                .estado = MyCliente.estado
                                .RUC = MyCliente.cuenta_comercial.Trim
                            End With
                            Session("MyUsuario") = MyUsuario
                            Response.Redirect("/Comprobantes/BuscarComprobantes.aspx")
                        Else
                            Throw New Exception("El ID del Usuario o la Contraseña estan mal ingresados")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            lblMensaje.Visible = True
            lblMensaje.Text = ex.Message
        End Try
    End Sub

End Class