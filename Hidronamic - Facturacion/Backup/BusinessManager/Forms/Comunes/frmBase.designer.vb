<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBase))
        Me.Panel = New System.Windows.Forms.Panel
        Me.UC_ToolBar = New MyControlToolBar.UserControlToolBar
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(0, 36)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(747, 627)
        Me.Panel.TabIndex = 126
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.AutoSize = True
        Me.UC_ToolBar.BackColor = System.Drawing.Color.White
        Me.UC_ToolBar.btnBorrar_Visible = False
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnImprimir_Visible = False
        Me.UC_ToolBar.btnNuevo_Visible = False
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.UC_ToolBar.Margin = New System.Windows.Forms.Padding(0)
        Me.UC_ToolBar.Name = "UC_ToolBar"
        Me.UC_ToolBar.Size = New System.Drawing.Size(747, 36)
        Me.UC_ToolBar.TabIndex = 125
        '
        'frmBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(747, 663)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.UC_ToolBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBase"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = " "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents UC_ToolBar As MyControlToolBar.UserControlToolBar
    Protected Friend WithEvents Panel As System.Windows.Forms.Panel
End Class
