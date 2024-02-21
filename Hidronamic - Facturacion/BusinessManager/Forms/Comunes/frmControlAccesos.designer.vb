<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlAccesos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlAccesos))
        Me.gvAccesos = New System.Windows.Forms.DataGridView
        Me.NIVEL_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NIVEL_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NIVEL_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRIVILEGIOS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PERMITIR_IMPRIMIR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.USUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRIVILEGIOS_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ckbPermitirImprimir = New System.Windows.Forms.CheckBox
        Me.cmbUsuario = New System.Windows.Forms.ComboBox
        Me.cmbSubMenuItem = New System.Windows.Forms.ComboBox
        Me.cmbSubMenu = New System.Windows.Forms.ComboBox
        Me.cmbMenu = New System.Windows.Forms.ComboBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.cmbPrivilegiosNivel = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbPrivilegiosUsuario = New System.Windows.Forms.ComboBox
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.gvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvAccesos
        '
        Me.gvAccesos.AllowUserToAddRows = False
        Me.gvAccesos.AllowUserToDeleteRows = False
        Me.gvAccesos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAccesos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NIVEL_1, Me.NIVEL_2, Me.NIVEL_3, Me.PRIVILEGIOS, Me.PERMITIR_IMPRIMIR, Me.EMPRESA, Me.USUARIO, Me.PRIVILEGIOS_CODIGO})
        Me.gvAccesos.EnableHeadersVisualStyles = False
        Me.gvAccesos.Location = New System.Drawing.Point(12, 175)
        Me.gvAccesos.Name = "gvAccesos"
        Me.gvAccesos.ReadOnly = True
        Me.gvAccesos.RowHeadersVisible = False
        Me.gvAccesos.Size = New System.Drawing.Size(846, 361)
        Me.gvAccesos.TabIndex = 8
        '
        'NIVEL_1
        '
        Me.NIVEL_1.DataPropertyName = "NIVEL_1"
        Me.NIVEL_1.HeaderText = "NIVEL 1"
        Me.NIVEL_1.Name = "NIVEL_1"
        Me.NIVEL_1.ReadOnly = True
        Me.NIVEL_1.Width = 130
        '
        'NIVEL_2
        '
        Me.NIVEL_2.DataPropertyName = "NIVEL_2"
        Me.NIVEL_2.HeaderText = "NIVEL 2"
        Me.NIVEL_2.Name = "NIVEL_2"
        Me.NIVEL_2.ReadOnly = True
        Me.NIVEL_2.Width = 220
        '
        'NIVEL_3
        '
        Me.NIVEL_3.DataPropertyName = "NIVEL_3"
        Me.NIVEL_3.HeaderText = "NIVEL 3"
        Me.NIVEL_3.Name = "NIVEL_3"
        Me.NIVEL_3.ReadOnly = True
        Me.NIVEL_3.Width = 240
        '
        'PRIVILEGIOS
        '
        Me.PRIVILEGIOS.DataPropertyName = "PRIVILEGIOS"
        Me.PRIVILEGIOS.HeaderText = "PRIVILEGIOS"
        Me.PRIVILEGIOS.Name = "PRIVILEGIOS"
        Me.PRIVILEGIOS.ReadOnly = True
        Me.PRIVILEGIOS.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRIVILEGIOS.Width = 160
        '
        'PERMITIR_IMPRIMIR
        '
        Me.PERMITIR_IMPRIMIR.DataPropertyName = "PERMITIR_IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.FalseValue = "0"
        Me.PERMITIR_IMPRIMIR.HeaderText = "IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.Name = "PERMITIR_IMPRIMIR"
        Me.PERMITIR_IMPRIMIR.ReadOnly = True
        Me.PERMITIR_IMPRIMIR.TrueValue = "1"
        Me.PERMITIR_IMPRIMIR.Width = 80
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
        'PRIVILEGIOS_CODIGO
        '
        Me.PRIVILEGIOS_CODIGO.DataPropertyName = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.HeaderText = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.Name = "PRIVILEGIOS_CODIGO"
        Me.PRIVILEGIOS_CODIGO.ReadOnly = True
        Me.PRIVILEGIOS_CODIGO.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(157, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(350, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "DESCRIPCION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.LightYellow
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.DarkRed
        Me.txtUsuario.Location = New System.Drawing.Point(157, 84)
        Me.txtUsuario.MaxLength = 50
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(349, 21)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "USUARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(344, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "NIVEL 3"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(136, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "NIVEL 2"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "NIVEL 1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckbPermitirImprimir
        '
        Me.ckbPermitirImprimir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbPermitirImprimir.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbPermitirImprimir.Location = New System.Drawing.Point(596, 113)
        Me.ckbPermitirImprimir.Name = "ckbPermitirImprimir"
        Me.ckbPermitirImprimir.Size = New System.Drawing.Size(171, 17)
        Me.ckbPermitirImprimir.TabIndex = 3
        Me.ckbPermitirImprimir.TabStop = False
        Me.ckbPermitirImprimir.Text = "PERMITIR IMPRIMIR"
        Me.ckbPermitirImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbPermitirImprimir.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DisplayMember = "USUARIO"
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(12, 84)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuario.TabIndex = 0
        Me.cmbUsuario.Tag = ""
        Me.cmbUsuario.ValueMember = "DESCRIPCION"
        '
        'cmbSubMenuItem
        '
        Me.cmbSubMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubMenuItem.FormattingEnabled = True
        Me.cmbSubMenuItem.Location = New System.Drawing.Point(344, 151)
        Me.cmbSubMenuItem.Name = "cmbSubMenuItem"
        Me.cmbSubMenuItem.Size = New System.Drawing.Size(239, 21)
        Me.cmbSubMenuItem.TabIndex = 6
        '
        'cmbSubMenu
        '
        Me.cmbSubMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubMenu.FormattingEnabled = True
        Me.cmbSubMenu.Location = New System.Drawing.Point(136, 151)
        Me.cmbSubMenu.Name = "cmbSubMenu"
        Me.cmbSubMenu.Size = New System.Drawing.Size(207, 21)
        Me.cmbSubMenu.TabIndex = 5
        '
        'cmbMenu
        '
        Me.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(12, 151)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(123, 21)
        Me.cmbMenu.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(818, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAceptar.Location = New System.Drawing.Point(773, 132)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(40, 40)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.Location = New System.Drawing.Point(818, 132)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(40, 40)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'cmbPrivilegiosNivel
        '
        Me.cmbPrivilegiosNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrivilegiosNivel.FormattingEnabled = True
        Me.cmbPrivilegiosNivel.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA"})
        Me.cmbPrivilegiosNivel.Location = New System.Drawing.Point(584, 151)
        Me.cmbPrivilegiosNivel.Name = "cmbPrivilegiosNivel"
        Me.cmbPrivilegiosNivel.Size = New System.Drawing.Size(183, 21)
        Me.cmbPrivilegiosNivel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(584, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 18)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "PRIVILEGIOS DEL NIVEL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(512, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(183, 18)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "PRIVILEGIOS DE USUARIO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPrivilegiosUsuario
        '
        Me.cmbPrivilegiosUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrivilegiosUsuario.Enabled = False
        Me.cmbPrivilegiosUsuario.FormattingEnabled = True
        Me.cmbPrivilegiosUsuario.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA", "PERSONALIZADO"})
        Me.cmbPrivilegiosUsuario.Location = New System.Drawing.Point(512, 84)
        Me.cmbPrivilegiosUsuario.Name = "cmbPrivilegiosUsuario"
        Me.cmbPrivilegiosUsuario.Size = New System.Drawing.Size(183, 21)
        Me.cmbPrivilegiosUsuario.TabIndex = 18
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.Color.Azure
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 36)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.cmbEmpresa.TabIndex = 19
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(352, 18)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "EMPRESA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmControlAccesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.cmbPrivilegiosUsuario)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbPrivilegiosNivel)
        Me.Controls.Add(Me.gvAccesos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ckbPermitirImprimir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.cmbSubMenuItem)
        Me.Controls.Add(Me.cmbSubMenu)
        Me.Controls.Add(Me.cmbMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmControlAccesos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE ACCESOS"
        CType(Me.gvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvAccesos As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ckbPermitirImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubMenuItem As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubMenu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMenu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrivilegiosNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbPrivilegiosUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NIVEL_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIVILEGIOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERMITIR_IMPRIMIR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIVILEGIOS_CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
