Public Class UserControlToolBar

    Public Event TB_btnNuevo_Click()
    Public Event TB_btnEditar_Click()
    Public Event TB_btnImprimir_Click()
    Public Event TB_btnBorrar_Click()
    Public Event TB_btnGrabar_Click()
    Public Event TB_btnSalir_Click()
    Public Event TB_btnInformacion_Click()
    Public Event TB_btnAceptar_Click()
    Public Event TB_btnEnviar_Click()
    Public Event TB_btnSUNAT_Click()

    Private Sub UserControlToolBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Set up the delays for the ToolTip.
        'ToolTipToolBar.AutoPopDelay = 5000
        'ToolTipToolBar.InitialDelay = 1000
        'ToolTipToolBar.ReshowDelay = 500
        '' Force the ToolTip text to be displayed whether or not the form is active.
        'ToolTipToolBar.ShowAlways = True

    End Sub

    Public Sub CambiarEstados(ByVal PrivilegiosUsuario As Byte, ByVal PrivilegiosNivel As Byte, ByVal PermitirImprimir As Boolean)
        Select Case PrivilegiosUsuario
            Case Is = 1 ' CONTROL TOTAL
                ' Puede acceder a todos los Niveles y realizar todas las operaciones
                btnNuevo.Visible = True
                btnAceptar.Visible = True
            Case Is = 2 ' LECTURA/ESCRITURA
                btnImprimir_Visible = PermitirImprimir
                btnNuevo.Visible = True
                btnAceptar.Visible = True
            Case Is = 3 ' SOLO LECTURA
                btnAceptar.Visible = False
            Case Is = 4 ' PERSONALIZADO
                Select Case PrivilegiosNivel
                    Case Is = 1 ' CONTROL TOTAL 
                        ' Puede realizar todas las operaciones pare este Nivel
                    Case Is = 2 ' LECTURA/ESCRITURA
                        btnImprimir_Visible = PermitirImprimir
                    Case Is = 3 ' SOLO LECTURA
                        btnImprimir_Visible = PermitirImprimir
                End Select
        End Select
    End Sub

    Public Sub MostrarTextoAyuda(ByVal TipoRegistro As String)
        ' Set up the ToolTip text for the Button.
        ToolTipToolBar.SetToolTip(Me.btnNuevo, "Nuevo " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnEditar, "Editar " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnImprimir, "Imprimir " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnBorrar, "Borrar " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnGrabar, "Grabar " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnSalir, "Salir " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnInformacion, "Información " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnAceptar, "Aceptar " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnEnviar, "Enviar " & TipoRegistro)
        ToolTipToolBar.SetToolTip(Me.btnSUNAT, "Enviar a SUNAT " & TipoRegistro)
    End Sub

    Private Sub btnNuevo_MouseHover(sender As Object, e As EventArgs) Handles btnNuevo.MouseHover, btnEditar.MouseHover, btnImprimir.MouseHover, btnBorrar.MouseHover, btnGrabar.MouseHover, btnSalir.MouseHover, btnInformacion.MouseHover, btnAceptar.MouseHover, btnEnviar.MouseHover, btnSUNAT.MouseHover
        Dim TxtNombre As String = sender.Name
        Dim TxtMensaje As String = ""
        Dim TxtTitulo As String = ""

        Select Case TxtNombre
            Case Is = "btnNuevo" : TxtMensaje = "Limpiar o inicializar los campos del formulario."
            Case Is = "btnEditar" : TxtMensaje = "Editar información de un registro existente."
            Case Is = "btnImprimir" : TxtMensaje = "Imprimir comprobante o reporte."
            Case Is = "btnBorrar" : TxtMensaje = "Eliminar registro de la base de datos."
            Case Is = "btnGrabar" : TxtMensaje = "Grabar los cambios de un registro existente."
            Case Is = "btnSalir" : TxtMensaje = "Salir del formulario."
            Case Is = "btnInformacion" : TxtMensaje = "Información de imterés."
            Case Is = "btnAceptar" : TxtMensaje = "Grabar toda la informacióm del nuevo registro."
            Case Is = "btnEnviar" : TxtMensaje = "Enviar por correo al cliente."
            Case Is = "btnSUNAT" : TxtMensaje = "Consultar estado del comprobante."
        End Select

        ToolTipToolBar.ToolTipTitle = "Botón " & sender.AccessibleName
        ToolTipToolBar.SetToolTip(sender, TxtMensaje)

    End Sub

#Region "Evento Click"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        RaiseEvent TB_btnNuevo_Click()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        RaiseEvent TB_btnEditar_Click()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        RaiseEvent TB_btnImprimir_Click()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        RaiseEvent TB_btnBorrar_Click()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        RaiseEvent TB_btnGrabar_Click()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        RaiseEvent TB_btnSalir_Click()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RaiseEvent TB_btnAceptar_Click()
    End Sub

    Private Sub btnInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformacion.Click
        RaiseEvent TB_btnInformacion_Click()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        RaiseEvent TB_btnEnviar_Click()
    End Sub

    Private Sub btnSUNAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSUNAT.Click
        RaiseEvent TB_btnSUNAT_Click()
    End Sub

#End Region

#Region "Propiedad Visible"

    Public Property btnNuevo_Visible() As Boolean
        Get
            Return btnNuevo.Visible
        End Get
        Set(ByVal value As Boolean)
            btnNuevo.Visible = value
        End Set
    End Property

    Public Property btnEditar_Visible() As Boolean
        Get
            Return btnEditar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnEditar.Visible = value
        End Set
    End Property

    Public Property btnImprimir_Visible() As Boolean
        Get
            Return btnImprimir.Visible
        End Get
        Set(ByVal value As Boolean)
            btnImprimir.Visible = value
        End Set
    End Property

    Public Property btnBorrar_Visible() As Boolean
        Get
            Return btnBorrar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnBorrar.Visible = value
        End Set
    End Property

    Public Property btnInformacion_Visible() As Boolean
        Get
            Return btnInformacion.Visible
        End Get
        Set(ByVal value As Boolean)
            btnInformacion.Visible = value
        End Set
    End Property

    Public Property btnAceptar_Visible() As Boolean
        Get
            Return btnAceptar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnAceptar.Visible = value
        End Set
    End Property

    Public Property btnGrabar_Visible() As Boolean
        Get
            Return btnGrabar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnGrabar.Visible = value
        End Set
    End Property

    Public Property btnSalir_Visible() As Boolean
        Get
            Return btnSalir.Visible
        End Get
        Set(ByVal value As Boolean)
            btnSalir.Visible = value
        End Set
    End Property

    Public Property btnEnviar_Visible() As Boolean
        Get
            Return btnEnviar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnEnviar.Visible = value
        End Set
    End Property

    Public Property btnSUNAT_Visible() As Boolean
        Get
            Return btnSUNAT.Visible
        End Get
        Set(ByVal value As Boolean)
            btnSUNAT.Visible = value
        End Set
    End Property

#End Region

#Region "Propiedad Focus"

    Public WriteOnly Property btnEditar_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnEditar.Focus()
        End Set
    End Property

    Public WriteOnly Property btnGrabar_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnGrabar.Focus()
        End Set
    End Property

    Public WriteOnly Property btnNuevo_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnNuevo.Focus()
        End Set
    End Property

    Public WriteOnly Property btnSalir_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnSalir.Focus()
        End Set
    End Property

    Public WriteOnly Property btnAceptar_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnAceptar.Focus()
        End Set
    End Property

    Public WriteOnly Property btnImprimir_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnImprimir.Focus()
        End Set
    End Property

    Public WriteOnly Property btnSUNAT_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnSUNAT.Focus()
        End Set
    End Property

#End Region

#Region "Propiedad Enable"

    Public Property btnNuevo_Enabled() As Boolean
        Get
            Return btnNuevo.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnNuevo.Enabled = value
        End Set
    End Property

    Public Property btnEditar_Enabled() As Boolean
        Get
            Return btnEditar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnEditar.Enabled = value
        End Set
    End Property

    Public Property btnImprimir_Enabled() As Boolean
        Get
            Return btnImprimir.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnImprimir.Enabled = value
        End Set
    End Property

    Public Property btnBorrar_Enabled() As Boolean
        Get
            Return btnBorrar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnBorrar.Enabled = value
        End Set
    End Property

    Public Property btnInformacion_Enabled() As Boolean
        Get
            Return btnInformacion.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnInformacion.Enabled = value
        End Set
    End Property

    Public Property btnAceptar_Enabled() As Boolean
        Get
            Return btnAceptar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnAceptar.Enabled = value
        End Set
    End Property

    Public Property btnGrabar_Enabled() As Boolean
        Get
            Return btnGrabar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnGrabar.Enabled = value
        End Set
    End Property

    Public Property btnSalir_Enabled() As Boolean
        Get
            Return btnSalir.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnSalir.Enabled = value
        End Set
    End Property

    Public Property btnEnviar_Enabled() As Boolean
        Get
            Return btnEnviar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnEnviar.Enabled = value
        End Set
    End Property

    Public Property btnSUNAT_Enabled() As Boolean
        Get
            Return btnSUNAT.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnSUNAT.Enabled = value
        End Set
    End Property

#End Region


End Class
