<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
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
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreCompleto = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ckbIndicaTrabajador = New System.Windows.Forms.CheckBox()
        Me.cmbTrabajador = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ckbIndicaPerfilPersonalizado = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaActivo = New System.Windows.Forms.CheckBox()
        Me.cmbPrivilegios = New System.Windows.Forms.ComboBox()
        Me.cmbPerfil = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(748, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbAgencia)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cmbPrivilegios)
        Me.Panel.Controls.Add(Me.cmbPerfil)
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Controls.Add(Me.ckbIndicaTrabajador)
        Me.Panel.Controls.Add(Me.cmbTrabajador)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.cmbCargo)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtEmail)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtClave)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.txtUsuario)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtNombreCompleto)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Size = New System.Drawing.Size(748, 235)
        Me.Panel.TabIndex = 0
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 43)
        Me.txtDocumentoNumero.MaxLength = 15
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(103, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(11, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 18)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "DOCUMENTO IDENTIDAD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 43)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 9
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(172, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(562, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "NOMBRES Y APELLIDOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreCompleto
        '
        Me.txtNombreCompleto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombreCompleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCompleto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNombreCompleto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreCompleto.Location = New System.Drawing.Point(172, 43)
        Me.txtNombreCompleto.MaxLength = 100
        Me.txtNombreCompleto.Name = "txtNombreCompleto"
        Me.txtNombreCompleto.Size = New System.Drawing.Size(562, 21)
        Me.txtNombreCompleto.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(248, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(490, 20)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "MANTENIMIENTO DE USUARIOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(142, 110)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(130, 18)
        Me.Label27.TabIndex = 18
        Me.Label27.Text = "CONTRASEÑA"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClave
        '
        Me.txtClave.BackColor = System.Drawing.Color.AliceBlue
        Me.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtClave.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtClave.Location = New System.Drawing.Point(142, 129)
        Me.txtClave.MaxLength = 50
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(130, 21)
        Me.txtClave.TabIndex = 5
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.SteelBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(11, 110)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(130, 18)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "USUARIO"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtUsuario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtUsuario.Location = New System.Drawing.Point(11, 129)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(130, 21)
        Me.txtUsuario.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(206, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(177, 18)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "CARGO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCargo
        '
        Me.cmbCargo.BackColor = System.Drawing.Color.Azure
        Me.cmbCargo.DisplayMember = "DESCRIPCION"
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbCargo.Location = New System.Drawing.Point(206, 86)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(177, 21)
        Me.cmbCargo.TabIndex = 3
        Me.cmbCargo.ValueMember = "CODIGO"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmail.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmail.Location = New System.Drawing.Point(273, 129)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(250, 21)
        Me.txtEmail.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(273, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(250, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "CORREO ELECTRONICO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbIndicaTrabajador
        '
        Me.ckbIndicaTrabajador.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbIndicaTrabajador.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaTrabajador.ForeColor = System.Drawing.Color.White
        Me.ckbIndicaTrabajador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaTrabajador.Location = New System.Drawing.Point(384, 67)
        Me.ckbIndicaTrabajador.Name = "ckbIndicaTrabajador"
        Me.ckbIndicaTrabajador.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbIndicaTrabajador.Size = New System.Drawing.Size(351, 18)
        Me.ckbIndicaTrabajador.TabIndex = 10
        Me.ckbIndicaTrabajador.TabStop = False
        Me.ckbIndicaTrabajador.Text = "INDICA TRABAJADOR"
        Me.ckbIndicaTrabajador.UseVisualStyleBackColor = False
        '
        'cmbTrabajador
        '
        Me.cmbTrabajador.BackColor = System.Drawing.Color.Azure
        Me.cmbTrabajador.DisplayMember = "DESCRIPCION"
        Me.cmbTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrabajador.Enabled = False
        Me.cmbTrabajador.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTrabajador.FormattingEnabled = True
        Me.cmbTrabajador.Location = New System.Drawing.Point(384, 86)
        Me.cmbTrabajador.Name = "cmbTrabajador"
        Me.cmbTrabajador.Size = New System.Drawing.Size(351, 21)
        Me.cmbTrabajador.TabIndex = 11
        Me.cmbTrabajador.TabStop = False
        Me.cmbTrabajador.ValueMember = "CODIGO"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.ckbIndicaPerfilPersonalizado)
        Me.Panel1.Controls.Add(Me.ckbIndicaActivo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(746, 31)
        Me.Panel1.TabIndex = 22
        '
        'ckbIndicaPerfilPersonalizado
        '
        Me.ckbIndicaPerfilPersonalizado.AutoSize = True
        Me.ckbIndicaPerfilPersonalizado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaPerfilPersonalizado.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaPerfilPersonalizado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaPerfilPersonalizado.Location = New System.Drawing.Point(426, 6)
        Me.ckbIndicaPerfilPersonalizado.Name = "ckbIndicaPerfilPersonalizado"
        Me.ckbIndicaPerfilPersonalizado.Size = New System.Drawing.Size(196, 17)
        Me.ckbIndicaPerfilPersonalizado.TabIndex = 1
        Me.ckbIndicaPerfilPersonalizado.TabStop = False
        Me.ckbIndicaPerfilPersonalizado.Text = "INDICA PERFIL PERSONALIZADO"
        Me.ckbIndicaPerfilPersonalizado.UseVisualStyleBackColor = True
        '
        'ckbIndicaActivo
        '
        Me.ckbIndicaActivo.AutoSize = True
        Me.ckbIndicaActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaActivo.Checked = True
        Me.ckbIndicaActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaActivo.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaActivo.Location = New System.Drawing.Point(628, 6)
        Me.ckbIndicaActivo.Name = "ckbIndicaActivo"
        Me.ckbIndicaActivo.Size = New System.Drawing.Size(104, 17)
        Me.ckbIndicaActivo.TabIndex = 0
        Me.ckbIndicaActivo.TabStop = False
        Me.ckbIndicaActivo.Text = "INDICA ACTIVO"
        Me.ckbIndicaActivo.UseVisualStyleBackColor = True
        '
        'cmbPrivilegios
        '
        Me.cmbPrivilegios.BackColor = System.Drawing.Color.Azure
        Me.cmbPrivilegios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrivilegios.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPrivilegios.FormattingEnabled = True
        Me.cmbPrivilegios.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA", "PERSONALIZADO"})
        Me.cmbPrivilegios.Location = New System.Drawing.Point(11, 172)
        Me.cmbPrivilegios.Name = "cmbPrivilegios"
        Me.cmbPrivilegios.Size = New System.Drawing.Size(208, 21)
        Me.cmbPrivilegios.TabIndex = 8
        '
        'cmbPerfil
        '
        Me.cmbPerfil.BackColor = System.Drawing.Color.Azure
        Me.cmbPerfil.DisplayMember = "DESCRIPCION"
        Me.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfil.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPerfil.FormattingEnabled = True
        Me.cmbPerfil.Location = New System.Drawing.Point(524, 129)
        Me.cmbPerfil.Name = "cmbPerfil"
        Me.cmbPerfil.Size = New System.Drawing.Size(211, 21)
        Me.cmbPerfil.TabIndex = 7
        Me.cmbPerfil.ValueMember = "CODIGO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(524, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(211, 18)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "PERFIL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(11, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 18)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "PRIVILEGIOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "AGENCIA ASIGNADA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAgencia
        '
        Me.cmbAgencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAgencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAgencia.BackColor = System.Drawing.Color.Azure
        Me.cmbAgencia.DisplayMember = "DESCRIPCION"
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(11, 86)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(194, 21)
        Me.cmbAgencia.TabIndex = 2
        Me.cmbAgencia.ValueMember = "CODIGO"
        '
        'frmUsuario
        '
        Me.ClientSize = New System.Drawing.Size(748, 289)
        Me.Name = "frmUsuario"
        Me.Text = "Mantenimiento de Usuarios"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreCompleto As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaTrabajador As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTrabajador As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ckbIndicaActivo As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPrivilegios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents ckbIndicaPerfilPersonalizado As System.Windows.Forms.CheckBox

End Class
