<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtCuentaDetraccion = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtFechaNacimiento = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtCodigoVendedor = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtCuentaBancariaME = New System.Windows.Forms.TextBox
        Me.txtCuentaBancariaMN = New System.Windows.Forms.TextBox
        Me.cmbBancoME = New System.Windows.Forms.ComboBox
        Me.cmbBancoMN = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmbDomicilioEnvio = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbDistrito = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbProvincia = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.ckbIndicaCliente = New System.Windows.Forms.CheckBox
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmbSexo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.cmbPais = New System.Windows.Forms.ComboBox
        Me.ckbIndicaNoDomiciliado = New System.Windows.Forms.CheckBox
        Me.ckbEstado = New System.Windows.Forms.CheckBox
        Me.ckbIndicaProveedor = New System.Windows.Forms.CheckBox
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(900, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.ckbIndicaProveedor)
        Me.Panel.Controls.Add(Me.ckbEstado)
        Me.Panel.Controls.Add(Me.cmbPais)
        Me.Panel.Controls.Add(Me.ckbIndicaNoDomiciliado)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbSexo)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label48)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.Label41)
        Me.Panel.Controls.Add(Me.txtCuentaDetraccion)
        Me.Panel.Controls.Add(Me.Label39)
        Me.Panel.Controls.Add(Me.txtFechaNacimiento)
        Me.Panel.Controls.Add(Me.Label35)
        Me.Panel.Controls.Add(Me.txtCodigoVendedor)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtApellidoPaterno)
        Me.Panel.Controls.Add(Me.Label28)
        Me.Panel.Controls.Add(Me.txtApellidoMaterno)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtNombre)
        Me.Panel.Controls.Add(Me.txtCuentaBancariaME)
        Me.Panel.Controls.Add(Me.txtCuentaBancariaMN)
        Me.Panel.Controls.Add(Me.cmbBancoME)
        Me.Panel.Controls.Add(Me.cmbBancoMN)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.cmbDomicilioEnvio)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtEmail)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtCelular)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtTelefono)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtCodigoPostal)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.cmbDistrito)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.cmbProvincia)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.cmbDepartamento)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtReferencia)
        Me.Panel.Controls.Add(Me.ckbIndicaCliente)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Size = New System.Drawing.Size(900, 404)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Chocolate
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(357, 276)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(340, 18)
        Me.Label48.TabIndex = 47
        Me.Label48.Text = "CUENTA CORRIENTE MONEDA NACIONAL"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Chocolate
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(12, 99)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(573, 18)
        Me.Label43.TabIndex = 32
        Me.Label43.Text = "DOMICILIO FISCAL"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio.Location = New System.Drawing.Point(12, 118)
        Me.txtDomicilio.MaxLength = 150
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(573, 21)
        Me.txtDomicilio.TabIndex = 5
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Chocolate
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(731, 276)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(155, 18)
        Me.Label41.TabIndex = 48
        Me.Label41.Text = "CUENTA DETRACCION"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaDetraccion
        '
        Me.txtCuentaDetraccion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaDetraccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaDetraccion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaDetraccion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaDetraccion.Location = New System.Drawing.Point(731, 295)
        Me.txtCuentaDetraccion.MaxLength = 20
        Me.txtCuentaDetraccion.Name = "txtCuentaDetraccion"
        Me.txtCuentaDetraccion.Size = New System.Drawing.Size(156, 21)
        Me.txtCuentaDetraccion.TabIndex = 23
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Chocolate
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(639, 228)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(107, 18)
        Me.Label39.TabIndex = 44
        Me.Label39.Text = "F. NACIMIENTO"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaNacimiento
        '
        Me.txtFechaNacimiento.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaNacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaNacimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaNacimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaNacimiento.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaNacimiento.Location = New System.Drawing.Point(639, 247)
        Me.txtFechaNacimiento.MaxLength = 50
        Me.txtFechaNacimiento.Name = "txtFechaNacimiento"
        Me.txtFechaNacimiento.Size = New System.Drawing.Size(107, 21)
        Me.txtFechaNacimiento.TabIndex = 17
        Me.txtFechaNacimiento.Tag = "F"
        Me.txtFechaNacimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Chocolate
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(289, 12)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(110, 18)
        Me.Label35.TabIndex = 28
        Me.Label35.Text = "CODIGO EXIGO"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoVendedor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodigoVendedor.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(289, 31)
        Me.txtCodigoVendedor.MaxLength = 7
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(110, 21)
        Me.txtCodigoVendedor.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Chocolate
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(12, 228)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(205, 18)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "APELLIDO PATERNO"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.BackColor = System.Drawing.Color.AliceBlue
        Me.txtApellidoPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoPaterno.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtApellidoPaterno.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(12, 247)
        Me.txtApellidoPaterno.MaxLength = 50
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(205, 21)
        Me.txtApellidoPaterno.TabIndex = 14
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Chocolate
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(218, 228)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(205, 18)
        Me.Label28.TabIndex = 42
        Me.Label28.Text = "APELLIDO MATERNO"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.BackColor = System.Drawing.Color.AliceBlue
        Me.txtApellidoMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoMaterno.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtApellidoMaterno.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(218, 247)
        Me.txtApellidoMaterno.MaxLength = 50
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(205, 21)
        Me.txtApellidoMaterno.TabIndex = 15
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Chocolate
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(425, 228)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(193, 18)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "NOMBRE"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombre.Location = New System.Drawing.Point(425, 247)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(193, 21)
        Me.txtNombre.TabIndex = 16
        '
        'txtCuentaBancariaME
        '
        Me.txtCuentaBancariaME.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaBancariaME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaBancariaME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaBancariaME.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaBancariaME.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaBancariaME.Location = New System.Drawing.Point(525, 295)
        Me.txtCuentaBancariaME.MaxLength = 20
        Me.txtCuentaBancariaME.Name = "txtCuentaBancariaME"
        Me.txtCuentaBancariaME.Size = New System.Drawing.Size(172, 21)
        Me.txtCuentaBancariaME.TabIndex = 22
        '
        'txtCuentaBancariaMN
        '
        Me.txtCuentaBancariaMN.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaBancariaMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaBancariaMN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaBancariaMN.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaBancariaMN.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaBancariaMN.Location = New System.Drawing.Point(180, 295)
        Me.txtCuentaBancariaMN.MaxLength = 20
        Me.txtCuentaBancariaMN.Name = "txtCuentaBancariaMN"
        Me.txtCuentaBancariaMN.Size = New System.Drawing.Size(172, 21)
        Me.txtCuentaBancariaMN.TabIndex = 20
        '
        'cmbBancoME
        '
        Me.cmbBancoME.BackColor = System.Drawing.Color.Azure
        Me.cmbBancoME.DisplayMember = "NOMBRE_LARGO"
        Me.cmbBancoME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoME.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbBancoME.FormattingEnabled = True
        Me.cmbBancoME.Location = New System.Drawing.Point(357, 295)
        Me.cmbBancoME.Name = "cmbBancoME"
        Me.cmbBancoME.Size = New System.Drawing.Size(167, 21)
        Me.cmbBancoME.TabIndex = 21
        Me.cmbBancoME.ValueMember = "CODIGO_ITEM"
        '
        'cmbBancoMN
        '
        Me.cmbBancoMN.BackColor = System.Drawing.Color.Azure
        Me.cmbBancoMN.DisplayMember = "NOMBRE_LARGO"
        Me.cmbBancoMN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoMN.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbBancoMN.FormattingEnabled = True
        Me.cmbBancoMN.Location = New System.Drawing.Point(12, 295)
        Me.cmbBancoMN.Name = "cmbBancoMN"
        Me.cmbBancoMN.Size = New System.Drawing.Size(167, 21)
        Me.cmbBancoMN.TabIndex = 19
        Me.cmbBancoMN.ValueMember = "CODIGO_ITEM"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Chocolate
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(12, 276)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(340, 18)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "CUENTA CORRIENTE MONEDA NACIONAL"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Chocolate
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(237, 185)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(254, 18)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "DOMICILIO DE ENVIO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDomicilioEnvio
        '
        Me.cmbDomicilioEnvio.BackColor = System.Drawing.Color.Azure
        Me.cmbDomicilioEnvio.DisplayMember = "DESCRIPCION"
        Me.cmbDomicilioEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDomicilioEnvio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDomicilioEnvio.FormattingEnabled = True
        Me.cmbDomicilioEnvio.Location = New System.Drawing.Point(237, 204)
        Me.cmbDomicilioEnvio.Name = "cmbDomicilioEnvio"
        Me.cmbDomicilioEnvio.Size = New System.Drawing.Size(254, 21)
        Me.cmbDomicilioEnvio.TabIndex = 13
        Me.cmbDomicilioEnvio.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Chocolate
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(633, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(254, 18)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "CORREO ELECTRONICO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmail.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmail.Location = New System.Drawing.Point(633, 75)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(254, 21)
        Me.txtEmail.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Chocolate
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(121, 185)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 18)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "CELULAR"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCelular.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCelular.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCelular.Location = New System.Drawing.Point(121, 204)
        Me.txtCelular.MaxLength = 20
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(110, 21)
        Me.txtCelular.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Chocolate
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(12, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 18)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "TELEFONO"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTelefono.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTelefono.Location = New System.Drawing.Point(12, 204)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(108, 21)
        Me.txtTelefono.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Chocolate
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(745, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 18)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "CODIGO POSTAL"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoPostal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCodigoPostal.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoPostal.Location = New System.Drawing.Point(745, 161)
        Me.txtCodigoPostal.MaxLength = 20
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(142, 21)
        Me.txtCodigoPostal.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Chocolate
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(470, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(274, 18)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "DISTRITO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDistrito
        '
        Me.cmbDistrito.BackColor = System.Drawing.Color.Azure
        Me.cmbDistrito.DisplayMember = "NOMBRE_LARGO"
        Me.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrito.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(471, 161)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(272, 21)
        Me.cmbDistrito.TabIndex = 9
        Me.cmbDistrito.ValueMember = "CODIGO_ITEM"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Chocolate
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(203, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(266, 18)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "PROVINCIA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.Azure
        Me.cmbProvincia.DisplayMember = "NOMBRE_LARGO"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(203, 161)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(266, 21)
        Me.cmbProvincia.TabIndex = 8
        Me.cmbProvincia.ValueMember = "CODIGO_ITEM"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Chocolate
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(12, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(190, 18)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "REGION"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.BackColor = System.Drawing.Color.Azure
        Me.cmbDepartamento.DisplayMember = "NOMBRE_LARGO"
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(12, 161)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(190, 21)
        Me.cmbDepartamento.TabIndex = 7
        Me.cmbDepartamento.ValueMember = "CODIGO_ITEM"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Chocolate
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(586, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(301, 18)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "REFERENCIA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferencia.Location = New System.Drawing.Point(586, 118)
        Me.txtReferencia.MaxLength = 40
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(301, 21)
        Me.txtReferencia.TabIndex = 6
        '
        'ckbIndicaCliente
        '
        Me.ckbIndicaCliente.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaCliente.Checked = True
        Me.ckbIndicaCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaCliente.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaCliente.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaCliente.Location = New System.Drawing.Point(416, 32)
        Me.ckbIndicaCliente.Name = "ckbIndicaCliente"
        Me.ckbIndicaCliente.Size = New System.Drawing.Size(95, 20)
        Me.ckbIndicaCliente.TabIndex = 25
        Me.ckbIndicaCliente.TabStop = False
        Me.ckbIndicaCliente.Text = "CLIENTE"
        Me.ckbIndicaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaCliente.UseVisualStyleBackColor = False
        Me.ckbIndicaCliente.Visible = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(160, 31)
        Me.txtDocumentoNumero.MaxLength = 15
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(117, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(103, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 18)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "DOCUMENTO IDENTIDAD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "NOMBRE_LARGO"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(103, 31)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 1
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO_ITEM"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(620, 18)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "RAZON SOCIAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.AliceBlue
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtRazonSocial.Location = New System.Drawing.Point(12, 75)
        Me.txtRazonSocial.MaxLength = 40
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(620, 21)
        Me.txtRazonSocial.TabIndex = 3
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Chocolate
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 18)
        Me.Label33.TabIndex = 26
        Me.Label33.Text = "CONTROL"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(12, 31)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(82, 21)
        Me.txtCuentaComercial.TabIndex = 24
        Me.txtCuentaComercial.TabStop = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(425, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(461, 20)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "MANTENIMIENTO DE CLIENTE"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.Color.Azure
        Me.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSexo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbSexo.Location = New System.Drawing.Point(764, 247)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(122, 21)
        Me.cmbSexo.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(764, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 18)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "SEXO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Chocolate
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(12, 326)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(874, 18)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "COMENTARIO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(12, 345)
        Me.txtComentario.MaxLength = 200
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(874, 44)
        Me.txtComentario.TabIndex = 49
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.Azure
        Me.cmbPais.DisplayMember = "NOMBRE_LARGO"
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Enabled = False
        Me.cmbPais.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(639, 204)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(247, 21)
        Me.cmbPais.TabIndex = 69
        Me.cmbPais.TabStop = False
        Me.cmbPais.ValueMember = "CODIGO_ITEM"
        '
        'ckbIndicaNoDomiciliado
        '
        Me.ckbIndicaNoDomiciliado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaNoDomiciliado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaNoDomiciliado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaNoDomiciliado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaNoDomiciliado.Location = New System.Drawing.Point(639, 186)
        Me.ckbIndicaNoDomiciliado.Name = "ckbIndicaNoDomiciliado"
        Me.ckbIndicaNoDomiciliado.Size = New System.Drawing.Size(247, 17)
        Me.ckbIndicaNoDomiciliado.TabIndex = 70
        Me.ckbIndicaNoDomiciliado.TabStop = False
        Me.ckbIndicaNoDomiciliado.Text = "INDICA NO DOMICILIADO"
        Me.ckbIndicaNoDomiciliado.UseVisualStyleBackColor = False
        '
        'ckbEstado
        '
        Me.ckbEstado.BackColor = System.Drawing.Color.Transparent
        Me.ckbEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbEstado.Checked = True
        Me.ckbEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbEstado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbEstado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbEstado.Location = New System.Drawing.Point(745, 32)
        Me.ckbEstado.Name = "ckbEstado"
        Me.ckbEstado.Size = New System.Drawing.Size(142, 20)
        Me.ckbEstado.TabIndex = 169
        Me.ckbEstado.TabStop = False
        Me.ckbEstado.Text = "INDICA  ACTIVO"
        Me.ckbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbEstado.UseVisualStyleBackColor = False
        '
        'ckbIndicaProveedor
        '
        Me.ckbIndicaProveedor.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaProveedor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaProveedor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaProveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaProveedor.Location = New System.Drawing.Point(525, 32)
        Me.ckbIndicaProveedor.Name = "ckbIndicaProveedor"
        Me.ckbIndicaProveedor.Size = New System.Drawing.Size(117, 20)
        Me.ckbIndicaProveedor.TabIndex = 170
        Me.ckbIndicaProveedor.TabStop = False
        Me.ckbIndicaProveedor.Text = "PROVEEDOR"
        Me.ckbIndicaProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaProveedor.UseVisualStyleBackColor = False
        Me.ckbIndicaProveedor.Visible = False
        '
        'frmClientes
        '
        Me.ClientSize = New System.Drawing.Size(900, 440)
        Me.Name = "frmClientes"
        Me.Text = "MANTENIMIENTO DE CLIENTE"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtFechaNacimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtApellidoPaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtApellidoMaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaBancariaME As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaBancariaMN As System.Windows.Forms.TextBox
    Friend WithEvents cmbBancoME As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBancoMN As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbDomicilioEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaCliente As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents ckbIndicaNoDomiciliado As System.Windows.Forms.CheckBox
    Friend WithEvents ckbEstado As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaProveedor As System.Windows.Forms.CheckBox

End Class
