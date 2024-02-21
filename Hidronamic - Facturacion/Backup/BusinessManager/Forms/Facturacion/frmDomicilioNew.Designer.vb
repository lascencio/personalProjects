<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDomicilioNew
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
        Me.txtDomicilio2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAnexoNombre = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAvAnexo = New System.Windows.Forms.TextBox
        Me.Panel.SuspendLayout()
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
        Me.Panel.Controls.Add(Me.txtAvAnexo)
        Me.Panel.Controls.Add(Me.txtDomicilio2)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtAnexoNombre)
        Me.Panel.Controls.Add(Me.txtAnexo)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Size = New System.Drawing.Size(756, 177)
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'txtDomicilio2
        '
        Me.txtDomicilio2.BackColor = System.Drawing.Color.Honeydew
        Me.txtDomicilio2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio2.Location = New System.Drawing.Point(12, 143)
        Me.txtDomicilio2.MaxLength = 50
        Me.txtDomicilio2.Name = "txtDomicilio2"
        Me.txtDomicilio2.Size = New System.Drawing.Size(727, 20)
        Me.txtDomicilio2.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(727, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "DISTRITO / CIUDAD"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.Honeydew
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio.Location = New System.Drawing.Point(12, 105)
        Me.txtDomicilio.MaxLength = 50
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(727, 20)
        Me.txtDomicilio.TabIndex = 15
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(12, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(727, 15)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "DOMICILIO"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(12, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(623, 15)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "CLIENTE"
        '
        'txtAnexoNombre
        '
        Me.txtAnexoNombre.BackColor = System.Drawing.Color.Honeydew
        Me.txtAnexoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnexoNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtAnexoNombre.Location = New System.Drawing.Point(12, 67)
        Me.txtAnexoNombre.MaxLength = 120
        Me.txtAnexoNombre.Name = "txtAnexoNombre"
        Me.txtAnexoNombre.Size = New System.Drawing.Size(623, 20)
        Me.txtAnexoNombre.TabIndex = 14
        '
        'txtAnexo
        '
        Me.txtAnexo.BackColor = System.Drawing.Color.Honeydew
        Me.txtAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnexo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtAnexo.Location = New System.Drawing.Point(12, 25)
        Me.txtAnexo.MaxLength = 11
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(75, 20)
        Me.txtAnexo.TabIndex = 13
        Me.txtAnexo.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 15)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "RUC"
        '
        'txtAvAnexo
        '
        Me.txtAvAnexo.BackColor = System.Drawing.Color.LightYellow
        Me.txtAvAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvAnexo.Enabled = False
        Me.txtAvAnexo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAvAnexo.Location = New System.Drawing.Point(635, 67)
        Me.txtAvAnexo.MaxLength = 1
        Me.txtAvAnexo.Name = "txtAvAnexo"
        Me.txtAvAnexo.ReadOnly = True
        Me.txtAvAnexo.Size = New System.Drawing.Size(14, 20)
        Me.txtAvAnexo.TabIndex = 21
        Me.txtAvAnexo.TabStop = False
        Me.txtAvAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmDomicilioNew
        '
        Me.ClientSize = New System.Drawing.Size(756, 213)
        Me.Name = "frmDomicilioNew"
        Me.Text = " DOMICILIO DE FACTURACION"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDomicilio2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAnexoNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAvAnexo As System.Windows.Forms.TextBox

End Class
