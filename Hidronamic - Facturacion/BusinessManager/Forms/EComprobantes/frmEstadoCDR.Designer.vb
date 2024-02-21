<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCDR
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout
        Me.SuspendLayout
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = true
        Me.UC_ToolBar.btnEditar_Visible = true
        Me.UC_ToolBar.btnGrabar_Visible = true
        Me.UC_ToolBar.btnInformacion_Visible = true
        Me.UC_ToolBar.btnSalir_Visible = true
        Me.UC_ToolBar.Size = New System.Drawing.Size(351, 36)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Size = New System.Drawing.Size(351, 73)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(25, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 18)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "TIPO DOCUMENTO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(202, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 18)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "NUMERO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 8!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(152, 13)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(49, 18)
        Me.Label42.TabIndex = 31
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9!)
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(202, 32)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 29
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(152, 32)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteSerie.TabIndex = 28
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "NOMBRE_CORTO"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = true
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(25, 32)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(126, 21)
        Me.cmbComprobanteTipo.TabIndex = 27
        Me.cmbComprobanteTipo.ValueMember = "CODIGO_ITEM"
        '
        'frmEstadoCDR
        '
        Me.ClientSize = New System.Drawing.Size(351, 109)
        Me.Name = "frmEstadoCDR"
        Me.Panel.ResumeLayout(false)
        Me.Panel.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox

End Class
