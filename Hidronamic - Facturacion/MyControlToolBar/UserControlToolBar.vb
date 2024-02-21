Public Class UserControlToolBar
    Public Event TB_btnNuevo_Click()
    Public Event TB_btnEditar_Click()
    Public Event TB_btnImprimir_Click()
    Public Event TB_btnBorrar_Click()
    Public Event TB_btnGrabar_Click()
    Public Event TB_btnSalir_Click()
    Public Event TB_btnInformacion_Click()
    Public Event TB_btnAceptar_Click()
    Public Event TB_btnSUNAT_Click()

    Public MyToolTip As New ToolTip()

    Private Sub UserControlToolBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set up the delays for the ToolTip.
        MyToolTip.AutoPopDelay = 5000
        MyToolTip.InitialDelay = 1000
        MyToolTip.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        MyToolTip.ShowAlways = True
    End Sub

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

    Private Sub btnInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformacion.Click
        RaiseEvent TB_btnInformacion_Click()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RaiseEvent TB_btnAceptar_Click()
    End Sub

    Private Sub btnSUNAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSUNAT.Click
        RaiseEvent TB_btnSUNAT_Click()
    End Sub

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

    Public Property btnGrabar_Visible() As Boolean
        Get
            Return btnGrabar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnGrabar.Visible = value
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

    Public Property btnSalir_Visible() As Boolean
        Get
            Return btnSalir.Visible
        End Get
        Set(ByVal value As Boolean)
            btnSalir.Visible = value
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

    Public WriteOnly Property btnAceptar_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnAceptar.Focus()
        End Set
    End Property

    Public WriteOnly Property btnGrabar_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnGrabar.Focus()
        End Set
    End Property

    Public WriteOnly Property btnSalir_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnSalir.Focus()
        End Set
    End Property

    Public WriteOnly Property btnInformacion_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnInformacion.Focus()
        End Set
    End Property

    Public WriteOnly Property btnSUNAT_Focus() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then btnSUNAT.Focus()
        End Set
    End Property

    Public Sub CambiarEstados(ByVal PrivilegiosUsuario As Byte, ByVal PrivilegiosNivel As Byte, ByVal PermitirImprimir As Boolean)
        btnInformacion.Visible = True

        Select Case PrivilegiosUsuario
            Case Is = 1 ' CONTROL TOTAL
                ' Puede acceder a todos los Niveles y realizar todas las operaciones
                btnNuevo.Visible = True
                btnEditar.Visible = True
                btnGrabar.Visible = True
                btnBorrar.Visible = True
                btnImprimir.Visible = True
            Case Is = 2 ' LECTURA/ESCRITURA
                btnNuevo.Visible = True
                btnEditar.Visible = True
                btnGrabar.Visible = True
                btnBorrar.Visible = True
                btnImprimir_Visible = PermitirImprimir
            Case Is = 3 ' SOLO LECTURA
                btnNuevo.Visible = False
                btnEditar.Visible = True
                btnGrabar.Visible = False
                btnBorrar.Visible = False
                btnImprimir_Visible = PermitirImprimir
            Case Is = 4 ' PERSONALIZADO
                Select Case PrivilegiosNivel
                    Case Is = 1 ' CONTROL TOTAL 
                        ' Puede realizar todas las operaciones pare este Nivel
                        btnNuevo.Visible = True
                        btnEditar.Visible = True
                        btnGrabar.Visible = True
                        btnBorrar.Visible = True
                        btnImprimir.Visible = True
                    Case Is = 2 ' LECTURA/ESCRITURA
                        btnNuevo.Visible = True
                        btnEditar.Visible = True
                        btnGrabar.Visible = True
                        btnBorrar.Visible = True
                        btnImprimir_Visible = PermitirImprimir
                    Case Is = 3 ' SOLO LECTURA
                        btnNuevo.Visible = False
                        btnEditar.Visible = True
                        btnGrabar.Visible = False
                        btnBorrar.Visible = False
                        btnImprimir_Visible = PermitirImprimir
                End Select
        End Select
    End Sub

    Public Sub MostrarTextoAyuda(ByVal TipoRegistro As String)
        ' Set up the ToolTip text for the Button.
        MyToolTip.SetToolTip(Me.btnNuevo, "Nuevo " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnEditar, "Editar " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnImprimir, "Imprimir " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnBorrar, "Borrar " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnGrabar, "Grabar " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnSalir, "Salir " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnInformacion, "Información " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnAceptar, "Aceptar " & TipoRegistro)
        MyToolTip.SetToolTip(Me.btnSUNAT, "Sunat " & TipoRegistro)
    End Sub
End Class
