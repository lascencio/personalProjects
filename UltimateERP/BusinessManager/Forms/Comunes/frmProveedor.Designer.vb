<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.ckbIndicaNoDomiciliado = New System.Windows.Forms.CheckBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtContactoComercial = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCondicionPago = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSiglas = New System.Windows.Forms.TextBox()
        Me.ckbAfectoIGV = New System.Windows.Forms.CheckBox()
        Me.ckbAgentePercepcion = New System.Windows.Forms.CheckBox()
        Me.ckbAgenteRetencion = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaActivo = New System.Windows.Forms.CheckBox()
        Me.ckbAgenteDetraccion = New System.Windows.Forms.CheckBox()
        Me.ckbVigenteSunat = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtCuentaDetraccion = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeDetraccion = New System.Windows.Forms.TextBox()
        Me.cmbItemFlujo = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtCuentaBancariaME = New System.Windows.Forms.TextBox()
        Me.txtCuentaBancariaMN = New System.Windows.Forms.TextBox()
        Me.cmbBancoME = New System.Windows.Forms.ComboBox()
        Me.cmbBancoMN = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
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
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(900, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Controls.Add(Me.Label48)
        Me.Panel.Controls.Add(Me.txtCuentaBancariaME)
        Me.Panel.Controls.Add(Me.txtCuentaBancariaMN)
        Me.Panel.Controls.Add(Me.cmbBancoME)
        Me.Panel.Controls.Add(Me.cmbBancoMN)
        Me.Panel.Controls.Add(Me.Label28)
        Me.Panel.Controls.Add(Me.cmbItemFlujo)
        Me.Panel.Controls.Add(Me.Label40)
        Me.Panel.Controls.Add(Me.txtPorcentajeDetraccion)
        Me.Panel.Controls.Add(Me.Label41)
        Me.Panel.Controls.Add(Me.txtCuentaDetraccion)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbFormaPago)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtSiglas)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbCondicionPago)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.cmbMoneda)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.txtContactoComercial)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtCodigoPostal)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtEmail)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtCelular)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtTelefono)
        Me.Panel.Controls.Add(Me.ckbIndicaNoDomiciliado)
        Me.Panel.Controls.Add(Me.cmbPais)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.cmbDistrito)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.cmbProvincia)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.cmbDepartamento)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtReferencia)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Size = New System.Drawing.Size(900, 366)
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
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "DOCUMENTO IDENTIDAD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.Enabled = False
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 43)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 34
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(402, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(490, 20)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "MANTENIMIENTO DE PROVEEDORES"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Label1.Size = New System.Drawing.Size(501, 18)
        Me.Label1.TabIndex = 38
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(172, 43)
        Me.txtRazonSocial.MaxLength = 100
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(501, 21)
        Me.txtRazonSocial.TabIndex = 1
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(192, 66)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(695, 18)
        Me.Label43.TabIndex = 40
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
        Me.txtDomicilio.Location = New System.Drawing.Point(192, 85)
        Me.txtDomicilio.MaxLength = 200
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(695, 21)
        Me.txtDomicilio.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(329, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(220, 18)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "DISTRITO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDistrito
        '
        Me.cmbDistrito.BackColor = System.Drawing.Color.Azure
        Me.cmbDistrito.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrito.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(329, 127)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(220, 21)
        Me.cmbDistrito.TabIndex = 6
        Me.cmbDistrito.ValueMember = "CODIGO"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(128, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 18)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "PROVINCIA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.Azure
        Me.cmbProvincia.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(128, 127)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(200, 21)
        Me.cmbProvincia.TabIndex = 5
        Me.cmbProvincia.ValueMember = "CODIGO"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(11, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 18)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "REGION"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.BackColor = System.Drawing.Color.Azure
        Me.cmbDepartamento.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(11, 127)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(116, 21)
        Me.cmbDepartamento.TabIndex = 4
        Me.cmbDepartamento.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(550, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(337, 18)
        Me.Label9.TabIndex = 44
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
        Me.txtReferencia.Location = New System.Drawing.Point(550, 127)
        Me.txtReferencia.MaxLength = 40
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(337, 21)
        Me.txtReferencia.TabIndex = 7
        '
        'ckbIndicaNoDomiciliado
        '
        Me.ckbIndicaNoDomiciliado.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbIndicaNoDomiciliado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaNoDomiciliado.ForeColor = System.Drawing.Color.White
        Me.ckbIndicaNoDomiciliado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaNoDomiciliado.Location = New System.Drawing.Point(11, 66)
        Me.ckbIndicaNoDomiciliado.Name = "ckbIndicaNoDomiciliado"
        Me.ckbIndicaNoDomiciliado.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbIndicaNoDomiciliado.Size = New System.Drawing.Size(180, 18)
        Me.ckbIndicaNoDomiciliado.TabIndex = 68
        Me.ckbIndicaNoDomiciliado.TabStop = False
        Me.ckbIndicaNoDomiciliado.Text = "INDICA NO DOMICILIADO"
        Me.ckbIndicaNoDomiciliado.UseVisualStyleBackColor = False
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.Azure
        Me.cmbPais.DisplayMember = "DESCRIPCION"
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Enabled = False
        Me.cmbPais.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(11, 85)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(180, 21)
        Me.cmbPais.TabIndex = 35
        Me.cmbPais.TabStop = False
        Me.cmbPais.ValueMember = "CODIGO"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(102, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 18)
        Me.Label15.TabIndex = 46
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
        Me.txtCelular.Location = New System.Drawing.Point(102, 170)
        Me.txtCelular.MaxLength = 20
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(90, 21)
        Me.txtCelular.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(11, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 18)
        Me.Label14.TabIndex = 45
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
        Me.txtTelefono.Location = New System.Drawing.Point(11, 170)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(90, 21)
        Me.txtTelefono.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(193, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(250, 18)
        Me.Label4.TabIndex = 47
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
        Me.txtEmail.Location = New System.Drawing.Point(193, 170)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(250, 21)
        Me.txtEmail.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(444, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 18)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "COD. POSTAL"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoPostal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCodigoPostal.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoPostal.Location = New System.Drawing.Point(444, 170)
        Me.txtCodigoPostal.MaxLength = 20
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(86, 21)
        Me.txtCodigoPostal.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(531, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(356, 18)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "CONTACTO COMERCIAL"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactoComercial
        '
        Me.txtContactoComercial.BackColor = System.Drawing.Color.AliceBlue
        Me.txtContactoComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactoComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactoComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtContactoComercial.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtContactoComercial.Location = New System.Drawing.Point(531, 170)
        Me.txtContactoComercial.MaxLength = 70
        Me.txtContactoComercial.Name = "txtContactoComercial"
        Me.txtContactoComercial.Size = New System.Drawing.Size(356, 21)
        Me.txtContactoComercial.TabIndex = 13
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.SteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(11, 197)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 18)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "MONEDA"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMoneda
        '
        Me.cmbMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(11, 216)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(87, 21)
        Me.cmbMoneda.TabIndex = 14
        Me.cmbMoneda.TabStop = False
        Me.cmbMoneda.ValueMember = "CODIGO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(99, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 18)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "CONDICIONES DE PAGO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCondicionPago
        '
        Me.cmbCondicionPago.BackColor = System.Drawing.Color.Azure
        Me.cmbCondicionPago.DisplayMember = "DESCRIPCION"
        Me.cmbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCondicionPago.FormattingEnabled = True
        Me.cmbCondicionPago.Location = New System.Drawing.Point(99, 216)
        Me.cmbCondicionPago.Name = "cmbCondicionPago"
        Me.cmbCondicionPago.Size = New System.Drawing.Size(215, 21)
        Me.cmbCondicionPago.TabIndex = 15
        Me.cmbCondicionPago.ValueMember = "CODIGO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(674, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 18)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "NOMBRE COMERCIAL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSiglas
        '
        Me.txtSiglas.BackColor = System.Drawing.Color.AliceBlue
        Me.txtSiglas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSiglas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSiglas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtSiglas.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtSiglas.Location = New System.Drawing.Point(674, 43)
        Me.txtSiglas.MaxLength = 30
        Me.txtSiglas.Name = "txtSiglas"
        Me.txtSiglas.Size = New System.Drawing.Size(213, 21)
        Me.txtSiglas.TabIndex = 2
        Me.txtSiglas.TabStop = False
        '
        'ckbAfectoIGV
        '
        Me.ckbAfectoIGV.AutoSize = True
        Me.ckbAfectoIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAfectoIGV.Checked = True
        Me.ckbAfectoIGV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbAfectoIGV.ForeColor = System.Drawing.Color.Navy
        Me.ckbAfectoIGV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAfectoIGV.Location = New System.Drawing.Point(197, 6)
        Me.ckbAfectoIGV.Name = "ckbAfectoIGV"
        Me.ckbAfectoIGV.Size = New System.Drawing.Size(105, 17)
        Me.ckbAfectoIGV.TabIndex = 0
        Me.ckbAfectoIGV.TabStop = False
        Me.ckbAfectoIGV.Text = "AFECTO AL IGV"
        Me.ckbAfectoIGV.UseVisualStyleBackColor = True
        '
        'ckbAgentePercepcion
        '
        Me.ckbAgentePercepcion.AutoSize = True
        Me.ckbAgentePercepcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAgentePercepcion.ForeColor = System.Drawing.Color.Navy
        Me.ckbAgentePercepcion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAgentePercepcion.Location = New System.Drawing.Point(308, 6)
        Me.ckbAgentePercepcion.Name = "ckbAgentePercepcion"
        Me.ckbAgentePercepcion.Size = New System.Drawing.Size(116, 17)
        Me.ckbAgentePercepcion.TabIndex = 1
        Me.ckbAgentePercepcion.TabStop = False
        Me.ckbAgentePercepcion.Text = "AG. PERCEPCION"
        Me.ckbAgentePercepcion.UseVisualStyleBackColor = True
        '
        'ckbAgenteRetencion
        '
        Me.ckbAgenteRetencion.AutoSize = True
        Me.ckbAgenteRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAgenteRetencion.ForeColor = System.Drawing.Color.Navy
        Me.ckbAgenteRetencion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAgenteRetencion.Location = New System.Drawing.Point(430, 6)
        Me.ckbAgenteRetencion.Name = "ckbAgenteRetencion"
        Me.ckbAgenteRetencion.Size = New System.Drawing.Size(110, 17)
        Me.ckbAgenteRetencion.TabIndex = 2
        Me.ckbAgenteRetencion.TabStop = False
        Me.ckbAgenteRetencion.Text = "AG. RETENCION"
        Me.ckbAgenteRetencion.UseVisualStyleBackColor = True
        '
        'ckbIndicaActivo
        '
        Me.ckbIndicaActivo.AutoSize = True
        Me.ckbIndicaActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaActivo.Checked = True
        Me.ckbIndicaActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaActivo.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaActivo.Location = New System.Drawing.Point(783, 6)
        Me.ckbIndicaActivo.Name = "ckbIndicaActivo"
        Me.ckbIndicaActivo.Size = New System.Drawing.Size(104, 17)
        Me.ckbIndicaActivo.TabIndex = 5
        Me.ckbIndicaActivo.TabStop = False
        Me.ckbIndicaActivo.Text = "INDICA ACTIVO"
        Me.ckbIndicaActivo.UseVisualStyleBackColor = True
        '
        'ckbAgenteDetraccion
        '
        Me.ckbAgenteDetraccion.AutoSize = True
        Me.ckbAgenteDetraccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAgenteDetraccion.ForeColor = System.Drawing.Color.Navy
        Me.ckbAgenteDetraccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAgenteDetraccion.Location = New System.Drawing.Point(546, 6)
        Me.ckbAgenteDetraccion.Name = "ckbAgenteDetraccion"
        Me.ckbAgenteDetraccion.Size = New System.Drawing.Size(117, 17)
        Me.ckbAgenteDetraccion.TabIndex = 3
        Me.ckbAgenteDetraccion.TabStop = False
        Me.ckbAgenteDetraccion.Text = "AG. DETRACCION"
        Me.ckbAgenteDetraccion.UseVisualStyleBackColor = True
        '
        'ckbVigenteSunat
        '
        Me.ckbVigenteSunat.AutoSize = True
        Me.ckbVigenteSunat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbVigenteSunat.Checked = True
        Me.ckbVigenteSunat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbVigenteSunat.ForeColor = System.Drawing.Color.Navy
        Me.ckbVigenteSunat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbVigenteSunat.Location = New System.Drawing.Point(664, 6)
        Me.ckbVigenteSunat.Name = "ckbVigenteSunat"
        Me.ckbVigenteSunat.Size = New System.Drawing.Size(113, 17)
        Me.ckbVigenteSunat.TabIndex = 4
        Me.ckbVigenteSunat.TabStop = False
        Me.ckbVigenteSunat.Text = "VIGENTE SUNAT"
        Me.ckbVigenteSunat.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(315, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 18)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "FORMA DE PAGO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPago.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Location = New System.Drawing.Point(315, 216)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(125, 21)
        Me.cmbFormaPago.TabIndex = 16
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.SteelBlue
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(683, 240)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(204, 18)
        Me.Label41.TabIndex = 67
        Me.Label41.Text = "CTA. Y PORCENT. DETRACCION"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaDetraccion
        '
        Me.txtCuentaDetraccion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaDetraccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaDetraccion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaDetraccion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaDetraccion.Location = New System.Drawing.Point(683, 259)
        Me.txtCuentaDetraccion.MaxLength = 20
        Me.txtCuentaDetraccion.Name = "txtCuentaDetraccion"
        Me.txtCuentaDetraccion.Size = New System.Drawing.Size(162, 21)
        Me.txtCuentaDetraccion.TabIndex = 31
        '
        'txtPorcentajeDetraccion
        '
        Me.txtPorcentajeDetraccion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPorcentajeDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentajeDetraccion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtPorcentajeDetraccion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPorcentajeDetraccion.Location = New System.Drawing.Point(847, 259)
        Me.txtPorcentajeDetraccion.MaxLength = 14
        Me.txtPorcentajeDetraccion.Name = "txtPorcentajeDetraccion"
        Me.txtPorcentajeDetraccion.Size = New System.Drawing.Size(40, 21)
        Me.txtPorcentajeDetraccion.TabIndex = 32
        Me.txtPorcentajeDetraccion.TabStop = False
        Me.txtPorcentajeDetraccion.Tag = "D"
        Me.txtPorcentajeDetraccion.Text = "0.00"
        Me.txtPorcentajeDetraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItemFlujo
        '
        Me.cmbItemFlujo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbItemFlujo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemFlujo.BackColor = System.Drawing.Color.Azure
        Me.cmbItemFlujo.DisplayMember = "NOMBRE_LARGO"
        Me.cmbItemFlujo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemFlujo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbItemFlujo.FormattingEnabled = True
        Me.cmbItemFlujo.Location = New System.Drawing.Point(516, 216)
        Me.cmbItemFlujo.MaxDropDownItems = 12
        Me.cmbItemFlujo.Name = "cmbItemFlujo"
        Me.cmbItemFlujo.Size = New System.Drawing.Size(371, 21)
        Me.cmbItemFlujo.TabIndex = 26
        Me.cmbItemFlujo.TabStop = False
        Me.cmbItemFlujo.ValueMember = "CODIGO_ITEM"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.SteelBlue
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(516, 197)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(371, 18)
        Me.Label40.TabIndex = 64
        Me.Label40.Text = "ITEM FLUJO"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.SteelBlue
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(347, 240)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(335, 18)
        Me.Label48.TabIndex = 66
        Me.Label48.Text = "CUENTA CORRIENTE MONEDA EXTRANJERA"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaBancariaME
        '
        Me.txtCuentaBancariaME.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaBancariaME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaBancariaME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaBancariaME.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaBancariaME.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaBancariaME.Location = New System.Drawing.Point(498, 259)
        Me.txtCuentaBancariaME.MaxLength = 20
        Me.txtCuentaBancariaME.Name = "txtCuentaBancariaME"
        Me.txtCuentaBancariaME.Size = New System.Drawing.Size(184, 21)
        Me.txtCuentaBancariaME.TabIndex = 30
        '
        'txtCuentaBancariaMN
        '
        Me.txtCuentaBancariaMN.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaBancariaMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaBancariaMN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaBancariaMN.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaBancariaMN.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuentaBancariaMN.Location = New System.Drawing.Point(162, 259)
        Me.txtCuentaBancariaMN.MaxLength = 20
        Me.txtCuentaBancariaMN.Name = "txtCuentaBancariaMN"
        Me.txtCuentaBancariaMN.Size = New System.Drawing.Size(184, 21)
        Me.txtCuentaBancariaMN.TabIndex = 28
        '
        'cmbBancoME
        '
        Me.cmbBancoME.BackColor = System.Drawing.Color.Azure
        Me.cmbBancoME.DisplayMember = "DESCRIPCION"
        Me.cmbBancoME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoME.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbBancoME.FormattingEnabled = True
        Me.cmbBancoME.Location = New System.Drawing.Point(347, 259)
        Me.cmbBancoME.Name = "cmbBancoME"
        Me.cmbBancoME.Size = New System.Drawing.Size(150, 21)
        Me.cmbBancoME.TabIndex = 29
        Me.cmbBancoME.ValueMember = "CODIGO"
        '
        'cmbBancoMN
        '
        Me.cmbBancoMN.BackColor = System.Drawing.Color.Azure
        Me.cmbBancoMN.DisplayMember = "DESCRIPCION"
        Me.cmbBancoMN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoMN.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbBancoMN.FormattingEnabled = True
        Me.cmbBancoMN.Location = New System.Drawing.Point(11, 259)
        Me.cmbBancoMN.Name = "cmbBancoMN"
        Me.cmbBancoMN.Size = New System.Drawing.Size(150, 21)
        Me.cmbBancoMN.TabIndex = 27
        Me.cmbBancoMN.ValueMember = "CODIGO"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.SteelBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(11, 240)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(335, 18)
        Me.Label28.TabIndex = 65
        Me.Label28.Text = "CUENTA CORRIENTE MONEDA NACIONAL"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtCuentaComercial)
        Me.Panel1.Controls.Add(Me.ckbIndicaActivo)
        Me.Panel1.Controls.Add(Me.ckbVigenteSunat)
        Me.Panel1.Controls.Add(Me.ckbAgenteDetraccion)
        Me.Panel1.Controls.Add(Me.ckbAgenteRetencion)
        Me.Panel1.Controls.Add(Me.ckbAgentePercepcion)
        Me.Panel1.Controls.Add(Me.ckbAfectoIGV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 333)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 31)
        Me.Panel1.TabIndex = 33
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.White
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.txtCuentaComercial.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentaComercial.Location = New System.Drawing.Point(9, 5)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(100, 14)
        Me.txtCuentaComercial.TabIndex = 83
        Me.txtCuentaComercial.TabStop = False
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(11, 283)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(876, 18)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = "COMENTARIO"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(11, 302)
        Me.txtComentario.MaxLength = 200
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(876, 21)
        Me.txtComentario.TabIndex = 69
        '
        'frmProveedor
        '
        Me.ClientSize = New System.Drawing.Size(900, 420)
        Me.Name = "frmProveedor"
        Me.Text = " Mantenimiento de Proveedores"
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
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaNoDomiciliado As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtContactoComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSiglas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents ckbAfectoIGV As System.Windows.Forms.CheckBox
    Friend WithEvents ckbAgentePercepcion As System.Windows.Forms.CheckBox
    Friend WithEvents ckbAgenteRetencion As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbAgenteDetraccion As System.Windows.Forms.CheckBox
    Friend WithEvents ckbVigenteSunat As System.Windows.Forms.CheckBox
    Friend WithEvents txtPorcentajeDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents cmbItemFlujo As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaBancariaME As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaBancariaMN As System.Windows.Forms.TextBox
    Friend WithEvents cmbBancoME As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBancoMN As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox

End Class
