<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDomicilio
    Inherits BusinessManager.frmBase

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtAvAnexo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAnexoNombre = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtDomicilio2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(756, 36)
        '
        'Panel
        '
        Me.Panel.Size = New System.Drawing.Size(756, 214)
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'txtAvAnexo
        '
        Me.txtAvAnexo.BackColor = System.Drawing.Color.LightYellow
        Me.txtAvAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvAnexo.Enabled = False
        Me.txtAvAnexo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAvAnexo.Location = New System.Drawing.Point(621, 113)
        Me.txtAvAnexo.MaxLength = 1
        Me.txtAvAnexo.Name = "txtAvAnexo"
        Me.txtAvAnexo.ReadOnly = True
        Me.txtAvAnexo.Size = New System.Drawing.Size(14, 20)
        Me.txtAvAnexo.TabIndex = 2
        Me.txtAvAnexo.TabStop = False
        Me.txtAvAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(12, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(623, 15)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "CLIENTE"
        '
        'txtAnexoNombre
        '
        Me.txtAnexoNombre.BackColor = System.Drawing.Color.Honeydew
        Me.txtAnexoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnexoNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtAnexoNombre.Location = New System.Drawing.Point(12, 113)
        Me.txtAnexoNombre.MaxLength = 120
        Me.txtAnexoNombre.Name = "txtAnexoNombre"
        Me.txtAnexoNombre.Size = New System.Drawing.Size(607, 20)
        Me.txtAnexoNombre.TabIndex = 1
        '
        'txtAnexo
        '
        Me.txtAnexo.BackColor = System.Drawing.Color.Honeydew
        Me.txtAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnexo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtAnexo.Location = New System.Drawing.Point(12, 69)
        Me.txtAnexo.MaxLength = 11
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(75, 20)
        Me.txtAnexo.TabIndex = 0
        Me.txtAnexo.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 15)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "RUC"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.Honeydew
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio.Location = New System.Drawing.Point(12, 164)
        Me.txtDomicilio.MaxLength = 50
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(727, 20)
        Me.txtDomicilio.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(12, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(727, 15)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "DOMICILIO"
        '
        'txtDomicilio2
        '
        Me.txtDomicilio2.BackColor = System.Drawing.Color.Honeydew
        Me.txtDomicilio2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio2.Location = New System.Drawing.Point(12, 209)
        Me.txtDomicilio2.MaxLength = 50
        Me.txtDomicilio2.Name = "txtDomicilio2"
        Me.txtDomicilio2.Size = New System.Drawing.Size(727, 20)
        Me.txtDomicilio2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(727, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "DISTRITO / CIUDAD"
        '
        'frmDomicilio
        '
        Me.ClientSize = New System.Drawing.Size(756, 250)
        Me.Controls.Add(Me.txtDomicilio2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtAvAnexo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtAnexoNombre)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.Label15)
        Me.Name = "frmDomicilio"
        Me.Text = " DOMICILIO DE FACTURACION"
        Me.Controls.SetChildIndex(Me.UC_ToolBar, 0)
        Me.Controls.SetChildIndex(Me.Panel, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txtAnexo, 0)
        Me.Controls.SetChildIndex(Me.txtAnexoNombre, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtAvAnexo, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.txtDomicilio, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtDomicilio2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAvAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAnexoNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents UC_ToolBar As MyControlToolBar.UserControlToolBar
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
