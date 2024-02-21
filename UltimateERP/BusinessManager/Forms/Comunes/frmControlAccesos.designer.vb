<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlAccesos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlAccesos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbPrivilegiosUsuario = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPrivilegiosNivel = New System.Windows.Forms.ComboBox()
        Me.gvAccesos = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVEL_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVEL_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVEL_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERMITIR_IMPRIMIR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PRIVILEGIOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIVILEGIOS_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckbPermitirImprimir = New System.Windows.Forms.CheckBox()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.cmbSubMenuItem = New System.Windows.Forms.ComboBox()
        Me.cmbSubMenu = New System.Windows.Forms.ComboBox()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.gvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(699, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbEmpresa)
        Me.Panel.Controls.Add(Me.cmbPrivilegiosUsuario)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.btnCancelar)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.cmbPrivilegiosNivel)
        Me.Panel.Controls.Add(Me.gvAccesos)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtUsuario)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.ckbPermitirImprimir)
        Me.Panel.Controls.Add(Me.cmbUsuario)
        Me.Panel.Controls.Add(Me.cmbSubMenuItem)
        Me.Panel.Controls.Add(Me.cmbSubMenu)
        Me.Panel.Controls.Add(Me.cmbMenu)
        Me.Panel.Size = New System.Drawing.Size(699, 576)
        Me.Panel.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(352, 18)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "EMPRESA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.Color.Azure
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(11, 43)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.cmbEmpresa.TabIndex = 6
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'cmbPrivilegiosUsuario
        '
        Me.cmbPrivilegiosUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrivilegiosUsuario.Enabled = False
        Me.cmbPrivilegiosUsuario.FormattingEnabled = True
        Me.cmbPrivilegiosUsuario.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA", "PERSONALIZADO"})
        Me.cmbPrivilegiosUsuario.Location = New System.Drawing.Point(502, 86)
        Me.cmbPrivilegiosUsuario.Name = "cmbPrivilegiosUsuario"
        Me.cmbPrivilegiosUsuario.Size = New System.Drawing.Size(183, 21)
        Me.cmbPrivilegiosUsuario.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(502, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(183, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "PRIVILEGIOS DE USUARIO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.ImageIndex = 0
        Me.btnCancelar.ImageList = Me.ilBotones
        Me.btnCancelar.Location = New System.Drawing.Point(558, 24)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(40, 40)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Visible = False
        '
        'ilBotones
        '
        Me.ilBotones.ImageStream = CType(resources.GetObject("ilBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ilBotones.Images.SetKeyName(0, "smallFail.gif")
        Me.ilBotones.Images.SetKeyName(1, "smallSuccess.gif")
        Me.ilBotones.Images.SetKeyName(2, "smallFail BW.gif")
        Me.ilBotones.Images.SetKeyName(3, "smallSuccess BW.gif")
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAceptar.ImageIndex = 1
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(641, 114)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(44, 44)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(366, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 18)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "PRIVILEGIOS DEL NIVEL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label6.Visible = False
        '
        'cmbPrivilegiosNivel
        '
        Me.cmbPrivilegiosNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrivilegiosNivel.Enabled = False
        Me.cmbPrivilegiosNivel.FormattingEnabled = True
        Me.cmbPrivilegiosNivel.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA"})
        Me.cmbPrivilegiosNivel.Location = New System.Drawing.Point(366, 43)
        Me.cmbPrivilegiosNivel.Name = "cmbPrivilegiosNivel"
        Me.cmbPrivilegiosNivel.Size = New System.Drawing.Size(183, 21)
        Me.cmbPrivilegiosNivel.TabIndex = 7
        Me.cmbPrivilegiosNivel.Visible = False
        '
        'gvAccesos
        '
        Me.gvAccesos.AllowUserToAddRows = False
        Me.gvAccesos.AllowUserToDeleteRows = False
        Me.gvAccesos.AllowUserToOrderColumns = True
        Me.gvAccesos.AllowUserToResizeColumns = False
        Me.gvAccesos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAccesos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.USUARIO, Me.NIVEL_1, Me.NIVEL_2, Me.NIVEL_3, Me.PERMITIR_IMPRIMIR, Me.PRIVILEGIOS, Me.PRIVILEGIOS_CODIGO, Me.ELIMINAR})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvAccesos.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvAccesos.EnableHeadersVisualStyles = False
        Me.gvAccesos.Location = New System.Drawing.Point(11, 163)
        Me.gvAccesos.Name = "gvAccesos"
        Me.gvAccesos.ReadOnly = True
        Me.gvAccesos.RowHeadersVisible = False
        Me.gvAccesos.Size = New System.Drawing.Size(674, 400)
        Me.gvAccesos.TabIndex = 5
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'USUARIO
        '
        Me.USUARIO.DataPropertyName = "USUARIO"
        Me.USUARIO.HeaderText = "USUARIO"
        Me.USUARIO.Name = "USUARIO"
        Me.USUARIO.ReadOnly = True
        Me.USUARIO.Visible = False
        '
        'NIVEL_1
        '
        Me.NIVEL_1.DataPropertyName = "NIVEL_1"
        Me.NIVEL_1.HeaderText = "NIVEL 1"
        Me.NIVEL_1.Name = "NIVEL_1"
        Me.NIVEL_1.ReadOnly = True
        Me.NIVEL_1.Width = 140
        '
        'NIVEL_2
        '
        Me.NIVEL_2.DataPropertyName = "NIVEL_2"
        Me.NIVEL_2.HeaderText = "NIVEL 2"
        Me.NIVEL_2.Name = "NIVEL_2"
        Me.NIVEL_2.ReadOnly = True
        Me.NIVEL_2.Width = 240
        '
        'NIVEL_3
        '
        Me.NIVEL_3.DataPropertyName = "NIVEL_3"
        Me.NIVEL_3.HeaderText = "NIVEL 3"
        Me.NIVEL_3.Name = "NIVEL_3"
        Me.NIVEL_3.ReadOnly = True
        Me.NIVEL_3.Width = 250
        '
        'PERMITIR_IMPRIMIR
        '
        Me.PERMITIR_IMPRIMIR.DataPropertyName = "PERMITIR_IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.FalseValue = "0"
        Me.PERMITIR_IMPRIMIR.HeaderText = "IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.Name = "PERMITIR_IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.ReadOnly = True
        Me.PERMITIR_IMPRIMIR.TrueValue = "1"
        Me.PERMITIR_IMPRIMIR.Visible = False
        Me.PERMITIR_IMPRIMIR.Width = 80
        '
        'PRIVILEGIOS
        '
        Me.PRIVILEGIOS.DataPropertyName = "PRIVILEGIOS"
        Me.PRIVILEGIOS.HeaderText = "PRIVILEGIOS"
        Me.PRIVILEGIOS.Name = "PRIVILEGIOS"
        Me.PRIVILEGIOS.ReadOnly = True
        Me.PRIVILEGIOS.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRIVILEGIOS.Visible = False
        Me.PRIVILEGIOS.Width = 160
        '
        'PRIVILEGIOS_CODIGO
        '
        Me.PRIVILEGIOS_CODIGO.DataPropertyName = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.HeaderText = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.Name = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.ReadOnly = True
        Me.PRIVILEGIOS_CODIGO.Visible = False
        '
        'ELIMINAR
        '
        Me.ELIMINAR.HeaderText = ""
        Me.ELIMINAR.Image = CType(resources.GetObject("ELIMINAR.Image"), System.Drawing.Image)
        Me.ELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ELIMINAR.Name = "ELIMINAR"
        Me.ELIMINAR.ReadOnly = True
        Me.ELIMINAR.Width = 24
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(152, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(349, 18)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "DESCRIPCION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.Moccasin
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.DarkRed
        Me.txtUsuario.Location = New System.Drawing.Point(152, 86)
        Me.txtUsuario.MaxLength = 50
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(349, 21)
        Me.txtUsuario.TabIndex = 20
        Me.txtUsuario.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "USUARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(388, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(250, 18)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "NIVEL 3"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(137, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "NIVEL 2"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(11, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 18)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "NIVEL 1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckbPermitirImprimir
        '
        Me.ckbPermitirImprimir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbPermitirImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbPermitirImprimir.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbPermitirImprimir.Location = New System.Drawing.Point(558, 46)
        Me.ckbPermitirImprimir.Name = "ckbPermitirImprimir"
        Me.ckbPermitirImprimir.Size = New System.Drawing.Size(127, 17)
        Me.ckbPermitirImprimir.TabIndex = 8
        Me.ckbPermitirImprimir.TabStop = False
        Me.ckbPermitirImprimir.Text = "PERMITIR IMPRIMIR"
        Me.ckbPermitirImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbPermitirImprimir.UseVisualStyleBackColor = True
        Me.ckbPermitirImprimir.Visible = False
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DisplayMember = "USUARIO"
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(11, 86)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuario.TabIndex = 0
        Me.cmbUsuario.Tag = ""
        Me.cmbUsuario.ValueMember = "DESCRIPCION"
        '
        'cmbSubMenuItem
        '
        Me.cmbSubMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubMenuItem.FormattingEnabled = True
        Me.cmbSubMenuItem.Location = New System.Drawing.Point(388, 134)
        Me.cmbSubMenuItem.Name = "cmbSubMenuItem"
        Me.cmbSubMenuItem.Size = New System.Drawing.Size(250, 23)
        Me.cmbSubMenuItem.TabIndex = 3
        '
        'cmbSubMenu
        '
        Me.cmbSubMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubMenu.FormattingEnabled = True
        Me.cmbSubMenu.Location = New System.Drawing.Point(137, 134)
        Me.cmbSubMenu.Name = "cmbSubMenu"
        Me.cmbSubMenu.Size = New System.Drawing.Size(250, 23)
        Me.cmbSubMenu.TabIndex = 2
        '
        'cmbMenu
        '
        Me.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(11, 134)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(125, 23)
        Me.cmbMenu.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(497, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(194, 20)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "CONTROL DE ACCESOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmControlAccesos
        '
        Me.ClientSize = New System.Drawing.Size(699, 630)
        Me.Name = "frmControlAccesos"
        Me.Text = "CONTROL DE ACCESOS"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents cmbEmpresa As ComboBox
    Friend WithEvents cmbPrivilegiosUsuario As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbPrivilegiosNivel As ComboBox
    Friend WithEvents gvAccesos As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ckbPermitirImprimir As CheckBox
    Friend WithEvents cmbUsuario As ComboBox
    Friend WithEvents cmbSubMenuItem As ComboBox
    Friend WithEvents cmbSubMenu As ComboBox
    Friend WithEvents cmbMenu As ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERMITIR_IMPRIMIR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PRIVILEGIOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIVILEGIOS_CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
End Class
