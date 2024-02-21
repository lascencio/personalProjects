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
        Me.lblTipoPrestamo = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFechaNacimiento = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtNombreConviviente = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbOcupacion = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cmbNivelEducativo = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtTelefonoTrabajo = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtDireccionTrabajo = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtReferenciaTrabajo = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmbEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtTelefonoOtro = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(900, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.cmbPais)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtFechaNacimiento)
        Me.Panel.Controls.Add(Me.Label44)
        Me.Panel.Controls.Add(Me.txtNombreConviviente)
        Me.Panel.Controls.Add(Me.Label45)
        Me.Panel.Controls.Add(Me.cmbOcupacion)
        Me.Panel.Controls.Add(Me.Label46)
        Me.Panel.Controls.Add(Me.cmbNivelEducativo)
        Me.Panel.Controls.Add(Me.Label40)
        Me.Panel.Controls.Add(Me.txtTelefonoTrabajo)
        Me.Panel.Controls.Add(Me.Label41)
        Me.Panel.Controls.Add(Me.txtDireccionTrabajo)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtReferenciaTrabajo)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.cmbEstadoCivil)
        Me.Panel.Controls.Add(Me.Label34)
        Me.Panel.Controls.Add(Me.txtTelefonoOtro)
        Me.Panel.Controls.Add(Me.Label35)
        Me.Panel.Controls.Add(Me.cmbSexo)
        Me.Panel.Controls.Add(Me.Label37)
        Me.Panel.Controls.Add(Me.txtEmail)
        Me.Panel.Controls.Add(Me.Label38)
        Me.Panel.Controls.Add(Me.txtCelular)
        Me.Panel.Controls.Add(Me.Label39)
        Me.Panel.Controls.Add(Me.txtTelefono)
        Me.Panel.Controls.Add(Me.Label28)
        Me.Panel.Controls.Add(Me.txtReferencia)
        Me.Panel.Controls.Add(Me.Label30)
        Me.Panel.Controls.Add(Me.cmbDistrito)
        Me.Panel.Controls.Add(Me.Label31)
        Me.Panel.Controls.Add(Me.cmbProvincia)
        Me.Panel.Controls.Add(Me.Label32)
        Me.Panel.Controls.Add(Me.cmbDepartamento)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.lblTipoPrestamo)
        Me.Panel.Size = New System.Drawing.Size(900, 290)
        Me.Panel.TabIndex = 0
        '
        'lblTipoPrestamo
        '
        Me.lblTipoPrestamo.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoPrestamo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPrestamo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTipoPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoPrestamo.Location = New System.Drawing.Point(581, 1)
        Me.lblTipoPrestamo.Name = "lblTipoPrestamo"
        Me.lblTipoPrestamo.Size = New System.Drawing.Size(308, 20)
        Me.lblTipoPrestamo.TabIndex = 23
        Me.lblTipoPrestamo.Text = "MANTENIMIENTO DE CLIENTES"
        Me.lblTipoPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(581, 153)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 18)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "F. NACIMIENTO"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaNacimiento
        '
        Me.txtFechaNacimiento.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaNacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaNacimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaNacimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaNacimiento.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaNacimiento.Location = New System.Drawing.Point(581, 172)
        Me.txtFechaNacimiento.MaxLength = 50
        Me.txtFechaNacimiento.Name = "txtFechaNacimiento"
        Me.txtFechaNacimiento.Size = New System.Drawing.Size(100, 21)
        Me.txtFechaNacimiento.TabIndex = 11
        Me.txtFechaNacimiento.Tag = "F"
        Me.txtFechaNacimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.SteelBlue
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label44.Location = New System.Drawing.Point(435, 195)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(452, 18)
        Me.Label44.TabIndex = 40
        Me.Label44.Text = "NOMBRE DEL ESPOSO(A) O CONVIVIENTE"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreConviviente
        '
        Me.txtNombreConviviente.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombreConviviente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreConviviente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreConviviente.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNombreConviviente.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreConviviente.Location = New System.Drawing.Point(435, 214)
        Me.txtNombreConviviente.MaxLength = 120
        Me.txtNombreConviviente.Name = "txtNombreConviviente"
        Me.txtNombreConviviente.Size = New System.Drawing.Size(452, 21)
        Me.txtNombreConviviente.TabIndex = 16
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.SteelBlue
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(265, 195)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(169, 18)
        Me.Label45.TabIndex = 39
        Me.Label45.Text = "OCUPACION"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbOcupacion
        '
        Me.cmbOcupacion.BackColor = System.Drawing.Color.Azure
        Me.cmbOcupacion.DisplayMember = "DESCRIPCION"
        Me.cmbOcupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOcupacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbOcupacion.FormattingEnabled = True
        Me.cmbOcupacion.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbOcupacion.Location = New System.Drawing.Point(265, 214)
        Me.cmbOcupacion.Name = "cmbOcupacion"
        Me.cmbOcupacion.Size = New System.Drawing.Size(169, 21)
        Me.cmbOcupacion.TabIndex = 15
        Me.cmbOcupacion.ValueMember = "CODIGO"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.SteelBlue
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(11, 195)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(253, 18)
        Me.Label46.TabIndex = 38
        Me.Label46.Text = "NIVEL EDUCATIVO"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivelEducativo
        '
        Me.cmbNivelEducativo.BackColor = System.Drawing.Color.Azure
        Me.cmbNivelEducativo.DisplayMember = "DESCRIPCION"
        Me.cmbNivelEducativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelEducativo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbNivelEducativo.FormattingEnabled = True
        Me.cmbNivelEducativo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbNivelEducativo.Location = New System.Drawing.Point(11, 214)
        Me.cmbNivelEducativo.Name = "cmbNivelEducativo"
        Me.cmbNivelEducativo.Size = New System.Drawing.Size(253, 21)
        Me.cmbNivelEducativo.TabIndex = 14
        Me.cmbNivelEducativo.ValueMember = "CODIGO"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.SteelBlue
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(807, 237)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 18)
        Me.Label40.TabIndex = 43
        Me.Label40.Text = "TELEFONO"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelefonoTrabajo
        '
        Me.txtTelefonoTrabajo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTelefonoTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefonoTrabajo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefonoTrabajo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTelefonoTrabajo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTelefonoTrabajo.Location = New System.Drawing.Point(807, 256)
        Me.txtTelefonoTrabajo.MaxLength = 20
        Me.txtTelefonoTrabajo.Name = "txtTelefonoTrabajo"
        Me.txtTelefonoTrabajo.Size = New System.Drawing.Size(80, 21)
        Me.txtTelefonoTrabajo.TabIndex = 19
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.SteelBlue
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(11, 237)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(491, 18)
        Me.Label41.TabIndex = 41
        Me.Label41.Text = "DOMICILIO DEL CENTRO DE TRABAJO"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDireccionTrabajo
        '
        Me.txtDireccionTrabajo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDireccionTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccionTrabajo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccionTrabajo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDireccionTrabajo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDireccionTrabajo.Location = New System.Drawing.Point(11, 256)
        Me.txtDireccionTrabajo.MaxLength = 150
        Me.txtDireccionTrabajo.Name = "txtDireccionTrabajo"
        Me.txtDireccionTrabajo.Size = New System.Drawing.Size(491, 21)
        Me.txtDireccionTrabajo.TabIndex = 17
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(503, 237)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(303, 18)
        Me.Label42.TabIndex = 42
        Me.Label42.Text = "REFERENCIA"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenciaTrabajo
        '
        Me.txtReferenciaTrabajo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferenciaTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaTrabajo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaTrabajo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaTrabajo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferenciaTrabajo.Location = New System.Drawing.Point(503, 256)
        Me.txtReferenciaTrabajo.MaxLength = 40
        Me.txtReferenciaTrabajo.Name = "txtReferenciaTrabajo"
        Me.txtReferenciaTrabajo.Size = New System.Drawing.Size(303, 21)
        Me.txtReferenciaTrabajo.TabIndex = 18
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(772, 153)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(115, 18)
        Me.Label33.TabIndex = 37
        Me.Label33.Text = "ESTADO CIVIL"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.BackColor = System.Drawing.Color.Azure
        Me.cmbEstadoCivil.DisplayMember = "DESCRIPCION"
        Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCivil.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbEstadoCivil.FormattingEnabled = True
        Me.cmbEstadoCivil.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(772, 172)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(115, 21)
        Me.cmbEstadoCivil.TabIndex = 13
        Me.cmbEstadoCivil.ValueMember = "CODIGO"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.SteelBlue
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(102, 153)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(90, 18)
        Me.Label34.TabIndex = 32
        Me.Label34.Text = "TELEFONO 2"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelefonoOtro
        '
        Me.txtTelefonoOtro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTelefonoOtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefonoOtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefonoOtro.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTelefonoOtro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTelefonoOtro.Location = New System.Drawing.Point(102, 172)
        Me.txtTelefonoOtro.MaxLength = 20
        Me.txtTelefonoOtro.Name = "txtTelefonoOtro"
        Me.txtTelefonoOtro.Size = New System.Drawing.Size(90, 21)
        Me.txtTelefonoOtro.TabIndex = 8
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(683, 153)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(88, 18)
        Me.Label35.TabIndex = 36
        Me.Label35.Text = "SEXO"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.Color.Azure
        Me.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSexo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbSexo.Location = New System.Drawing.Point(683, 172)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(88, 21)
        Me.cmbSexo.TabIndex = 12
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.SteelBlue
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(284, 153)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(250, 18)
        Me.Label37.TabIndex = 34
        Me.Label37.Text = "CORREO ELECTRONICO"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmail.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmail.Location = New System.Drawing.Point(284, 172)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(250, 21)
        Me.txtEmail.TabIndex = 10
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.SteelBlue
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(193, 153)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(90, 18)
        Me.Label38.TabIndex = 33
        Me.Label38.Text = "CELULAR"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCelular.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCelular.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCelular.Location = New System.Drawing.Point(193, 172)
        Me.txtCelular.MaxLength = 20
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(90, 21)
        Me.txtCelular.TabIndex = 9
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.SteelBlue
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(11, 153)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(90, 18)
        Me.Label39.TabIndex = 31
        Me.Label39.Text = "TELEFONO 1"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTelefono.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTelefono.Location = New System.Drawing.Point(11, 172)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(90, 21)
        Me.txtTelefono.TabIndex = 7
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.SteelBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(550, 111)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(337, 18)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "REFERENCIA"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferencia.Location = New System.Drawing.Point(550, 130)
        Me.txtReferencia.MaxLength = 40
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(337, 21)
        Me.txtReferencia.TabIndex = 6
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.SteelBlue
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(329, 111)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(220, 18)
        Me.Label30.TabIndex = 29
        Me.Label30.Text = "DISTRITO"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDistrito
        '
        Me.cmbDistrito.BackColor = System.Drawing.Color.Azure
        Me.cmbDistrito.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrito.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(329, 130)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(220, 21)
        Me.cmbDistrito.TabIndex = 5
        Me.cmbDistrito.ValueMember = "CODIGO"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SteelBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(128, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(200, 18)
        Me.Label31.TabIndex = 28
        Me.Label31.Text = "PROVINCIA"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.Azure
        Me.cmbProvincia.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(128, 130)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(200, 21)
        Me.cmbProvincia.TabIndex = 4
        Me.cmbProvincia.ValueMember = "CODIGO"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.SteelBlue
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(11, 111)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(116, 18)
        Me.Label32.TabIndex = 27
        Me.Label32.Text = "REGION"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.BackColor = System.Drawing.Color.Azure
        Me.cmbDepartamento.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(11, 130)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(116, 21)
        Me.cmbDepartamento.TabIndex = 3
        Me.cmbDepartamento.ValueMember = "CODIGO"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(11, 69)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(876, 18)
        Me.Label43.TabIndex = 26
        Me.Label43.Text = "DOMICILIO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio.Location = New System.Drawing.Point(11, 88)
        Me.txtDomicilio.MaxLength = 150
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(876, 21)
        Me.txtDomicilio.TabIndex = 2
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
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 46)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 20
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
        Me.Label2.Location = New System.Drawing.Point(149, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(738, 18)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "NOMBRE / RAZON SOCIAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.AliceBlue
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 46)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(738, 21)
        Me.txtRazonSocial.TabIndex = 1
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 46)
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
        Me.Label15.Location = New System.Drawing.Point(11, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.Azure
        Me.cmbPais.DisplayMember = "DESCRIPCION"
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Enabled = False
        Me.cmbPais.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(435, 3)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(29, 21)
        Me.cmbPais.TabIndex = 22
        Me.cmbPais.TabStop = False
        Me.cmbPais.ValueMember = "CODIGO"
        Me.cmbPais.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(408, 3)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 21
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'frmClientes
        '
        Me.ClientSize = New System.Drawing.Size(900, 344)
        Me.Name = "frmClientes"
        Me.Text = "MANTENIMIENTO DE CLIENTES"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipoPrestamo As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFechaNacimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtNombreConviviente As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbOcupacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cmbNivelEducativo As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonoTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonoOtro As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox

End Class
