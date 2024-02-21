<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.AplicacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodoDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SesionDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobantesElectrónicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarCDRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccesoWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeComprobantesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeAuditoríaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuario.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUsuario.Location = New System.Drawing.Point(1111, 28)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(229, 20)
        Me.lblUsuario.TabIndex = 46
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AplicacionToolStripMenuItem
        '
        Me.AplicacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem, Me.ConfiguracionToolStripMenuItem, Me.SesionDeTrabajoToolStripMenuItem})
        Me.AplicacionToolStripMenuItem.Name = "AplicacionToolStripMenuItem"
        Me.AplicacionToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.AplicacionToolStripMenuItem.Tag = "P"
        Me.AplicacionToolStripMenuItem.Text = "Aplicacion"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SalirToolStripMenuItem.Tag = "P"
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PeriodoDeTrabajoToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ConfiguracionToolStripMenuItem.Tag = ""
        Me.ConfiguracionToolStripMenuItem.Text = "Configuracion"
        '
        'PeriodoDeTrabajoToolStripMenuItem
        '
        Me.PeriodoDeTrabajoToolStripMenuItem.Name = "PeriodoDeTrabajoToolStripMenuItem"
        Me.PeriodoDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PeriodoDeTrabajoToolStripMenuItem.Text = "Periodo de Trabajo"
        '
        'SesionDeTrabajoToolStripMenuItem
        '
        Me.SesionDeTrabajoToolStripMenuItem.Name = "SesionDeTrabajoToolStripMenuItem"
        Me.SesionDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SesionDeTrabajoToolStripMenuItem.Tag = "P"
        Me.SesionDeTrabajoToolStripMenuItem.Text = "Sesion de Trabajo"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComprobantesElectrónicosToolStripMenuItem, Me.ConsultarCDRToolStripMenuItem, Me.AccesoWebToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'ComprobantesElectrónicosToolStripMenuItem
        '
        Me.ComprobantesElectrónicosToolStripMenuItem.Name = "ComprobantesElectrónicosToolStripMenuItem"
        Me.ComprobantesElectrónicosToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ComprobantesElectrónicosToolStripMenuItem.Text = "Comprobantes Electrónicos "
        '
        'ConsultarCDRToolStripMenuItem
        '
        Me.ConsultarCDRToolStripMenuItem.Name = "ConsultarCDRToolStripMenuItem"
        Me.ConsultarCDRToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ConsultarCDRToolStripMenuItem.Text = "Consultar CDR"
        '
        'AccesoWebToolStripMenuItem
        '
        Me.AccesoWebToolStripMenuItem.Name = "AccesoWebToolStripMenuItem"
        Me.AccesoWebToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AccesoWebToolStripMenuItem.Text = "Acceso Web"
        '
        'MenuPrincipal
        '
        Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AplicacionToolStripMenuItem, Me.VentasToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal.Name = "MenuPrincipal"
        Me.MenuPrincipal.Size = New System.Drawing.Size(1350, 24)
        Me.MenuPrincipal.TabIndex = 1
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteDeComprobantesToolStripMenuItem1, Me.ReporteDeAuditoríaToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ReporteDeComprobantesToolStripMenuItem1
        '
        Me.ReporteDeComprobantesToolStripMenuItem1.Name = "ReporteDeComprobantesToolStripMenuItem1"
        Me.ReporteDeComprobantesToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.ReporteDeComprobantesToolStripMenuItem1.Text = "Reporte de Comprobantes"
        '
        'ReporteDeAuditoríaToolStripMenuItem
        '
        Me.ReporteDeAuditoríaToolStripMenuItem.Name = "ReporteDeAuditoríaToolStripMenuItem"
        Me.ReporteDeAuditoríaToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ReporteDeAuditoríaToolStripMenuItem.Text = "Reporte de Auditoría"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.BusinessManager.My.Resources.Resources.Imagen_Menu
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1350, 687)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.MenuPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuPrincipal
        Me.MaximizeBox = False
        Me.Name = "frmMenu"
        Me.Text = "FACTURACION ELECTRONICA"
        Me.MenuPrincipal.ResumeLayout(False)
        Me.MenuPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents AplicacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PeriodoDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SesionDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprobantesElectrónicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarCDRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccesoWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteDeComprobantesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteDeAuditoríaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
