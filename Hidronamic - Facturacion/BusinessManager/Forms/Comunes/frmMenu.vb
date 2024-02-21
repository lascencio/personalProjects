
Public Class frmMenu

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActivarMenu()

        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Sub ActivarMenu()
        Try
            For Each OpcionMenu In MenuPrincipal.Items
                If OpcionMenu.Tag <> "P" Then OpcionMenu.Visible = False
                For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                    If OpcionSubMenu.Tag <> "P" Then OpcionSubMenu.Visible = False
                    For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                        If OpcionSubMenuItem.Tag <> "P" Then OpcionSubMenuItem.Visible = False
                    Next
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Message)
        End Try
    End Sub

    Private Sub LanzarFormulario(ByRef Formulario As System.Object, ByVal MyMenuItem As ToolStripMenuItem, ByVal Nivel As Byte)
        If MyUsuario.privilegios = 4 Then
            Dim Nivel1, Nivel2, Nivel3 As String
            Nivel1 = "" : Nivel2 = Nivel1 : Nivel3 = Nivel2

            With MyMenuItem
                If Nivel = 2 Then
                    If Not .OwnerItem.Text Is Nothing Then
                        Nivel1 = .OwnerItem.Text
                        Nivel2 = .Text
                    End If
                Else
                    Nivel1 = .OwnerItem.OwnerItem.Text
                    Nivel2 = .OwnerItem.Text
                    Nivel3 = .Text
                End If
            End With

            Dim MyControlAcceso As New dsControlAcceso.CONTROL_ACCESODataTable
            MyControlAcceso = dalControlAcceso.ObtenerAcceso(MyUsuario.empresa, MyUsuario.usuario, Nivel1, Nivel2, Nivel3)
            If MyControlAcceso.Count > 0 Then
                Formulario.Privilegios = MyControlAcceso(0).PRIVILEGIOS
                Formulario.Permitir_imprimir = MyControlAcceso(0).PERMITIR_IMPRIMIR
            End If
        End If

        Formulario.MdiParent = Me
        Formulario.Show()
    End Sub

    Private Sub LanzarFormulario(ByRef Formulario As System.Object, ByVal EsDialog As Boolean)
        If EsDialog = True Then
            Formulario.ShowDialog()
        Else
            Formulario.MdiParent = Me
            Formulario.Show()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ControlDeAccesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmControlAccesos, True)
    End Sub

    Private Sub PeriodoDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmPeriodoTrabajo, True)
    End Sub

    Private Sub SesionDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SesionDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmLogin, False)
    End Sub

    Private Sub TablasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmTablaCabeceras, sender, 3)
    End Sub

    Private Sub ElementosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmTablaDetalles, sender, 3)
    End Sub


    Private Sub TipoDeCambioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmTipoCambio, False)
    End Sub

    Private Sub ConsultarRUCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmSUNAT, True)
    End Sub

    Private Sub GenerarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmGenerarXML, sender, 2)
    End Sub

    Private Sub ValidarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmValidarXML, sender, 2)
    End Sub

    Private Sub FirmarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmFirmarXML, sender, 2)
    End Sub

    Private Sub EnviarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmEnviarXML, sender, 2)
    End Sub

    Private Sub LeerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmLeerXML, sender, 2)
    End Sub

    Private Sub ComprobantesElectrónicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobantesElectrónicosToolStripMenuItem.Click
        LanzarFormulario(frmEComprobantes, sender, 2)
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmCliente, sender, 2)
    End Sub

    Private Sub GlosaAlternaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmGlosaAlterna, sender, 2)
    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmENotaCreditoServicios, sender, 2)
    End Sub

    Private Sub NotasDeDébitoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmENotaDebitoServicios, sender, 2)
    End Sub

    Private Sub AccesoWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccesoWebToolStripMenuItem.Click
        LanzarFormulario(frmCliente, sender, 2)
    End Sub

    Private Sub ConsultarCDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarCDRToolStripMenuItem.Click
        LanzarFormulario(frmEstadoCDR, sender, 2)
    End Sub

    Private Sub ReporteDeComprobantesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReporteDeComprobantesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteDeComprobantesToolStripMenuItem1.Click
        Dim MyForm As New frmReporteComprobantesVenta(MyEjercicio, MyMes)
        MyForm.Show()
    End Sub

    Private Sub ReporteDeAuditoríaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeAuditoríaToolStripMenuItem.Click
        LanzarFormulario(frmAuditoria, sender, 2)
    End Sub
End Class