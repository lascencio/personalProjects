<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobranzaGastos
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
        Me.btnBuscarPrestamo = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtCobranza = New System.Windows.Forms.TextBox()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(812, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtGlosa)
        Me.Panel.Controls.Add(Me.btnBuscarPrestamo)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtPrestamo)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cmbPrestamo)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtImporte)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtFechaEmision)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.Label47)
        Me.Panel.Controls.Add(Me.txtCobranza)
        Me.Panel.Size = New System.Drawing.Size(812, 150)
        Me.Panel.TabIndex = 0
        '
        'btnBuscarPrestamo
        '
        Me.btnBuscarPrestamo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPrestamo.Location = New System.Drawing.Point(118, 113)
        Me.btnBuscarPrestamo.Name = "btnBuscarPrestamo"
        Me.btnBuscarPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscarPrestamo.TabIndex = 3
        Me.btnBuscarPrestamo.Text = "..."
        Me.btnBuscarPrestamo.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(282, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 18)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "PRESTAMO"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Visible = False
        '
        'txtPrestamo
        '
        Me.txtPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrestamo.Location = New System.Drawing.Point(282, 30)
        Me.txtPrestamo.MaxLength = 8
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.Size = New System.Drawing.Size(98, 21)
        Me.txtPrestamo.TabIndex = 9
        Me.txtPrestamo.TabStop = False
        Me.txtPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrestamo.Visible = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(443, 30)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 12
        Me.txtEjercicio.TabStop = False
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEjercicio.Visible = False
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.Color.Moccasin
        Me.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMes.Location = New System.Drawing.Point(466, 30)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 13
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(428, 30)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 11
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(433, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(370, 20)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "COBRANZA DE GASTOS ADMINISTRATIVOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 18)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "PRESTAMO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPrestamo
        '
        Me.cmbPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbPrestamo.DisplayMember = "PRESTAMO"
        Me.cmbPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPrestamo.FormattingEnabled = True
        Me.cmbPrestamo.Location = New System.Drawing.Point(11, 114)
        Me.cmbPrestamo.Name = "cmbPrestamo"
        Me.cmbPrestamo.Size = New System.Drawing.Size(107, 21)
        Me.cmbPrestamo.TabIndex = 4
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(251, 95)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 18)
        Me.Label29.TabIndex = 22
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporte.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporte.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporte.Location = New System.Drawing.Point(251, 114)
        Me.txtImporte.MaxLength = 10
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(71, 21)
        Me.txtImporte.TabIndex = 1
        Me.txtImporte.TabStop = False
        Me.txtImporte.Tag = "D"
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(143, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "MONEDA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.Enabled = False
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(143, 114)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 6
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(112, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 18)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaEmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaEmision.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaEmision.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaEmision.Location = New System.Drawing.Point(112, 30)
        Me.txtFechaEmision.MaxLength = 10
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(74, 21)
        Me.txtFechaEmision.TabIndex = 8
        Me.txtFechaEmision.TabStop = False
        Me.txtFechaEmision.Tag = "F"
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDocumentoTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 72)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 5
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(149, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(649, 18)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "NOMBRE / RAZON SOCIAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 72)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(649, 21)
        Me.txtRazonSocial.TabIndex = 10
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 72)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(11, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.SteelBlue
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(11, 11)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(98, 18)
        Me.Label47.TabIndex = 15
        Me.Label47.Text = "COBRANZA"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCobranza
        '
        Me.txtCobranza.BackColor = System.Drawing.Color.Moccasin
        Me.txtCobranza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCobranza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCobranza.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobranza.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCobranza.Location = New System.Drawing.Point(11, 30)
        Me.txtCobranza.MaxLength = 8
        Me.txtCobranza.Name = "txtCobranza"
        Me.txtCobranza.ReadOnly = True
        Me.txtCobranza.Size = New System.Drawing.Size(98, 21)
        Me.txtCobranza.TabIndex = 7
        Me.txtCobranza.TabStop = False
        Me.txtCobranza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.Moccasin
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlosa.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGlosa.Location = New System.Drawing.Point(324, 115)
        Me.txtGlosa.MaxLength = 50
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.Size = New System.Drawing.Size(474, 21)
        Me.txtGlosa.TabIndex = 2
        Me.txtGlosa.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(324, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(474, 19)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "GLOSA DE LA OPERACION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCobranzaGastos
        '
        Me.ClientSize = New System.Drawing.Size(812, 204)
        Me.Name = "frmCobranzaGastos"
        Me.Text = "COBRANZA DE GASTOS ADMINISTRATIVOS"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscarPrestamo As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtCobranza As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox

End Class
