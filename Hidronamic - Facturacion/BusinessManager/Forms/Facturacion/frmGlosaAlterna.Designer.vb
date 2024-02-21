<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGlosaAlterna
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
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImporteTotalOrigen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtGlosa4Linea = New System.Windows.Forms.TextBox()
        Me.txtGlosa3Linea = New System.Windows.Forms.TextBox()
        Me.txtGlosa2Linea = New System.Windows.Forms.TextBox()
        Me.txtGlosa1Linea = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAnexoNombre = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(533, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.txtAnexoNombre)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtGlosa4Linea)
        Me.Panel.Controls.Add(Me.txtGlosa3Linea)
        Me.Panel.Controls.Add(Me.txtGlosa2Linea)
        Me.Panel.Controls.Add(Me.txtGlosa1Linea)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtImporteTotalOrigen)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Size = New System.Drawing.Size(533, 239)
        Me.Panel.TabIndex = 0
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "NOMBRE_CORTO"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(11, 32)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(126, 21)
        Me.cmbComprobanteTipo.TabIndex = 0
        Me.cmbComprobanteTipo.ValueMember = "CODIGO_ITEM"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(188, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 18)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "NUMERO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(138, 13)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(49, 18)
        Me.Label42.TabIndex = 13
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(188, 32)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 2
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(138, 32)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteSerie.TabIndex = 1
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "TIPO DOCUMENTO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(82, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 18)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "MONEDA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Moccasin
        Me.cmbTipoMoneda.DisplayMember = "NOMBRE_LARGO"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(82, 75)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(166, 21)
        Me.cmbTipoMoneda.TabIndex = 9
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO_ITEM"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(249, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "PRECIO VENTA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotalOrigen
        '
        Me.txtImporteTotalOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotalOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotalOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotalOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotalOrigen.Location = New System.Drawing.Point(249, 75)
        Me.txtImporteTotalOrigen.MaxLength = 14
        Me.txtImporteTotalOrigen.Name = "txtImporteTotalOrigen"
        Me.txtImporteTotalOrigen.ReadOnly = True
        Me.txtImporteTotalOrigen.Size = New System.Drawing.Size(94, 21)
        Me.txtImporteTotalOrigen.TabIndex = 10
        Me.txtImporteTotalOrigen.TabStop = False
        Me.txtImporteTotalOrigen.Tag = "D"
        Me.txtImporteTotalOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "F. EMISION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(11, 75)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.ReadOnly = True
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(70, 21)
        Me.txtComprobanteFecha.TabIndex = 8
        Me.txtComprobanteFecha.TabStop = False
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGlosa4Linea
        '
        Me.txtGlosa4Linea.BackColor = System.Drawing.Color.Honeydew
        Me.txtGlosa4Linea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGlosa4Linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa4Linea.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtGlosa4Linea.Location = New System.Drawing.Point(11, 207)
        Me.txtGlosa4Linea.MaxLength = 80
        Me.txtGlosa4Linea.Name = "txtGlosa4Linea"
        Me.txtGlosa4Linea.Size = New System.Drawing.Size(502, 13)
        Me.txtGlosa4Linea.TabIndex = 6
        '
        'txtGlosa3Linea
        '
        Me.txtGlosa3Linea.BackColor = System.Drawing.Color.Honeydew
        Me.txtGlosa3Linea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGlosa3Linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa3Linea.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtGlosa3Linea.Location = New System.Drawing.Point(11, 193)
        Me.txtGlosa3Linea.MaxLength = 80
        Me.txtGlosa3Linea.Name = "txtGlosa3Linea"
        Me.txtGlosa3Linea.Size = New System.Drawing.Size(502, 13)
        Me.txtGlosa3Linea.TabIndex = 5
        '
        'txtGlosa2Linea
        '
        Me.txtGlosa2Linea.BackColor = System.Drawing.Color.Honeydew
        Me.txtGlosa2Linea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGlosa2Linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa2Linea.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtGlosa2Linea.Location = New System.Drawing.Point(11, 179)
        Me.txtGlosa2Linea.MaxLength = 80
        Me.txtGlosa2Linea.Name = "txtGlosa2Linea"
        Me.txtGlosa2Linea.Size = New System.Drawing.Size(502, 13)
        Me.txtGlosa2Linea.TabIndex = 4
        '
        'txtGlosa1Linea
        '
        Me.txtGlosa1Linea.BackColor = System.Drawing.Color.Honeydew
        Me.txtGlosa1Linea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGlosa1Linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa1Linea.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtGlosa1Linea.Location = New System.Drawing.Point(11, 165)
        Me.txtGlosa1Linea.MaxLength = 80
        Me.txtGlosa1Linea.Name = "txtGlosa1Linea"
        Me.txtGlosa1Linea.Size = New System.Drawing.Size(502, 13)
        Me.txtGlosa1Linea.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(11, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(502, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "GLOSA ALTERNA"
        '
        'txtAnexoNombre
        '
        Me.txtAnexoNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtAnexoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexoNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtAnexoNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAnexoNombre.Location = New System.Drawing.Point(11, 119)
        Me.txtAnexoNombre.MaxLength = 120
        Me.txtAnexoNombre.Name = "txtAnexoNombre"
        Me.txtAnexoNombre.ReadOnly = True
        Me.txtAnexoNombre.Size = New System.Drawing.Size(499, 21)
        Me.txtAnexoNombre.TabIndex = 11
        Me.txtAnexoNombre.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(11, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(499, 18)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "CLIENTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(516, 119)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 7
        Me.txtVenta.TabStop = False
        Me.txtVenta.Visible = False
        '
        'frmGlosaAlterna
        '
        Me.ClientSize = New System.Drawing.Size(533, 275)
        Me.Name = "frmGlosaAlterna"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotalOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosa4Linea As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosa3Linea As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosa2Linea As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosa1Linea As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAnexoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox

End Class
