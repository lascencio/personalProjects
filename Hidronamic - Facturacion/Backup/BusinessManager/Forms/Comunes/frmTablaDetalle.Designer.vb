<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaDetalle
    Inherits BusinessManager.frmSubBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTablaDetalle))
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.txtDescripcionAmpliada = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckbActivo = New System.Windows.Forms.CheckBox
        Me.txtDescripcionTabla = New System.Windows.Forms.TextBox
        Me.txtCodigoTabla = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cmbTexto5 = New System.Windows.Forms.ComboBox
        Me.cmbTexto4 = New System.Windows.Forms.ComboBox
        Me.cmbTexto3 = New System.Windows.Forms.ComboBox
        Me.lblTexto5 = New System.Windows.Forms.Label
        Me.txttexto5 = New System.Windows.Forms.TextBox
        Me.lblTexto4 = New System.Windows.Forms.Label
        Me.txttexto4 = New System.Windows.Forms.TextBox
        Me.lblTexto3 = New System.Windows.Forms.Label
        Me.lblTexto2 = New System.Windows.Forms.Label
        Me.lblTexto1 = New System.Windows.Forms.Label
        Me.txtTexto3 = New System.Windows.Forms.TextBox
        Me.txtTexto2 = New System.Windows.Forms.TextBox
        Me.txtTexto1 = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblValor5 = New System.Windows.Forms.Label
        Me.txtValor5 = New System.Windows.Forms.TextBox
        Me.lblValor4 = New System.Windows.Forms.Label
        Me.txtValor4 = New System.Windows.Forms.TextBox
        Me.lblValor3 = New System.Windows.Forms.Label
        Me.lblValor2 = New System.Windows.Forms.Label
        Me.lblValor1 = New System.Windows.Forms.Label
        Me.txtValor1 = New System.Windows.Forms.TextBox
        Me.txtValor3 = New System.Windows.Forms.TextBox
        Me.txtValor2 = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lblLogico5 = New System.Windows.Forms.Label
        Me.ckbLogico5 = New System.Windows.Forms.CheckBox
        Me.lblLogico4 = New System.Windows.Forms.Label
        Me.ckbLogico4 = New System.Windows.Forms.CheckBox
        Me.lblLogico3 = New System.Windows.Forms.Label
        Me.lblLogico2 = New System.Windows.Forms.Label
        Me.lblLogico1 = New System.Windows.Forms.Label
        Me.ckbLogico3 = New System.Windows.Forms.CheckBox
        Me.ckbLogico2 = New System.Windows.Forms.CheckBox
        Me.ckbLogico1 = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Panel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.btnGrabar)
        Me.Panel.Controls.Add(Me.btnSalir)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.txtEmpresa)
        Me.Panel.Controls.Add(Me.txtDescripcionAmpliada)
        Me.Panel.Controls.Add(Me.txtDescripcion)
        Me.Panel.Controls.Add(Me.txtCodigo)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.ckbActivo)
        Me.Panel.Controls.Add(Me.txtDescripcionTabla)
        Me.Panel.Controls.Add(Me.txtCodigoTabla)
        Me.Panel.Controls.Add(Me.TabControl1)
        Me.Panel.Size = New System.Drawing.Size(600, 400)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.Color.Moccasin
        Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(240, 357)
        Me.txtEmpresa.MaxLength = 20
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(100, 20)
        Me.txtEmpresa.TabIndex = 7
        Me.txtEmpresa.TabStop = False
        Me.txtEmpresa.Visible = False
        '
        'txtDescripcionAmpliada
        '
        Me.txtDescripcionAmpliada.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcionAmpliada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionAmpliada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionAmpliada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionAmpliada.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionAmpliada.Location = New System.Drawing.Point(13, 138)
        Me.txtDescripcionAmpliada.MaxLength = 250
        Me.txtDescripcionAmpliada.Name = "txtDescripcionAmpliada"
        Me.txtDescripcionAmpliada.Size = New System.Drawing.Size(564, 21)
        Me.txtDescripcionAmpliada.TabIndex = 4
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcion.Location = New System.Drawing.Point(130, 94)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(447, 21)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigo.Location = New System.Drawing.Point(13, 94)
        Me.txtCodigo.MaxLength = 20
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(111, 21)
        Me.txtCodigo.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Chocolate
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(564, 18)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "DESCRIPCION AMPLIADA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Chocolate
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(130, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(447, 18)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "DESCRIPCION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(208, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(369, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "DESCRIPCION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 18)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "ELEMENTO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "TABLA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbActivo
        '
        Me.ckbActivo.AutoSize = True
        Me.ckbActivo.Checked = True
        Me.ckbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbActivo.Location = New System.Drawing.Point(20, 360)
        Me.ckbActivo.Name = "ckbActivo"
        Me.ckbActivo.Size = New System.Drawing.Size(65, 17)
        Me.ckbActivo.TabIndex = 6
        Me.ckbActivo.TabStop = False
        Me.ckbActivo.Text = "ACTIVO"
        Me.ckbActivo.UseVisualStyleBackColor = True
        '
        'txtDescripcionTabla
        '
        Me.txtDescripcionTabla.BackColor = System.Drawing.Color.Moccasin
        Me.txtDescripcionTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionTabla.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionTabla.Location = New System.Drawing.Point(208, 48)
        Me.txtDescripcionTabla.MaxLength = 50
        Me.txtDescripcionTabla.Name = "txtDescripcionTabla"
        Me.txtDescripcionTabla.ReadOnly = True
        Me.txtDescripcionTabla.Size = New System.Drawing.Size(369, 21)
        Me.txtDescripcionTabla.TabIndex = 1
        Me.txtDescripcionTabla.TabStop = False
        '
        'txtCodigoTabla
        '
        Me.txtCodigoTabla.BackColor = System.Drawing.Color.Moccasin
        Me.txtCodigoTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoTabla.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoTabla.Location = New System.Drawing.Point(13, 48)
        Me.txtCodigoTabla.MaxLength = 20
        Me.txtCodigoTabla.Name = "txtCodigoTabla"
        Me.txtCodigoTabla.ReadOnly = True
        Me.txtCodigoTabla.Size = New System.Drawing.Size(187, 21)
        Me.txtCodigoTabla.TabIndex = 0
        Me.txtCodigoTabla.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 165)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(564, 182)
        Me.TabControl1.TabIndex = 5
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage1.Controls.Add(Me.cmbTexto5)
        Me.TabPage1.Controls.Add(Me.cmbTexto4)
        Me.TabPage1.Controls.Add(Me.cmbTexto3)
        Me.TabPage1.Controls.Add(Me.lblTexto5)
        Me.TabPage1.Controls.Add(Me.txttexto5)
        Me.TabPage1.Controls.Add(Me.lblTexto4)
        Me.TabPage1.Controls.Add(Me.txttexto4)
        Me.TabPage1.Controls.Add(Me.lblTexto3)
        Me.TabPage1.Controls.Add(Me.lblTexto2)
        Me.TabPage1.Controls.Add(Me.lblTexto1)
        Me.TabPage1.Controls.Add(Me.txtTexto3)
        Me.TabPage1.Controls.Add(Me.txtTexto2)
        Me.TabPage1.Controls.Add(Me.txtTexto1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(556, 156)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Campos TEXTO"
        '
        'cmbTexto5
        '
        Me.cmbTexto5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTexto5.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTexto5.FormattingEnabled = True
        Me.cmbTexto5.Items.AddRange(New Object() {"CONTROL TOTAL", "LECTURA/ESCRITURA", "SOLO LECTURA", "PERSONALIZADO"})
        Me.cmbTexto5.Location = New System.Drawing.Point(188, 119)
        Me.cmbTexto5.Name = "cmbTexto5"
        Me.cmbTexto5.Size = New System.Drawing.Size(348, 21)
        Me.cmbTexto5.TabIndex = 4
        '
        'cmbTexto4
        '
        Me.cmbTexto4.BackColor = System.Drawing.Color.Azure
        Me.cmbTexto4.DisplayMember = "DESCRIPCION"
        Me.cmbTexto4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTexto4.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTexto4.FormattingEnabled = True
        Me.cmbTexto4.Location = New System.Drawing.Point(188, 93)
        Me.cmbTexto4.Name = "cmbTexto4"
        Me.cmbTexto4.Size = New System.Drawing.Size(348, 21)
        Me.cmbTexto4.TabIndex = 3
        Me.cmbTexto4.TabStop = False
        Me.cmbTexto4.ValueMember = "CODIGO"
        Me.cmbTexto4.Visible = False
        '
        'cmbTexto3
        '
        Me.cmbTexto3.BackColor = System.Drawing.Color.Azure
        Me.cmbTexto3.DisplayMember = "DESCRIPCION"
        Me.cmbTexto3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTexto3.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTexto3.FormattingEnabled = True
        Me.cmbTexto3.Location = New System.Drawing.Point(188, 67)
        Me.cmbTexto3.Name = "cmbTexto3"
        Me.cmbTexto3.Size = New System.Drawing.Size(348, 21)
        Me.cmbTexto3.TabIndex = 2
        Me.cmbTexto3.TabStop = False
        Me.cmbTexto3.ValueMember = "CODIGO"
        Me.cmbTexto3.Visible = False
        '
        'lblTexto5
        '
        Me.lblTexto5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto5.Location = New System.Drawing.Point(20, 119)
        Me.lblTexto5.Name = "lblTexto5"
        Me.lblTexto5.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto5.TabIndex = 9
        Me.lblTexto5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttexto5
        '
        Me.txttexto5.BackColor = System.Drawing.Color.Honeydew
        Me.txttexto5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttexto5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttexto5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttexto5.ForeColor = System.Drawing.Color.MediumBlue
        Me.txttexto5.Location = New System.Drawing.Point(188, 119)
        Me.txttexto5.MaxLength = 50
        Me.txttexto5.Name = "txttexto5"
        Me.txttexto5.Size = New System.Drawing.Size(348, 21)
        Me.txttexto5.TabIndex = 4
        '
        'lblTexto4
        '
        Me.lblTexto4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto4.Location = New System.Drawing.Point(20, 93)
        Me.lblTexto4.Name = "lblTexto4"
        Me.lblTexto4.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto4.TabIndex = 8
        Me.lblTexto4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttexto4
        '
        Me.txttexto4.BackColor = System.Drawing.Color.Honeydew
        Me.txttexto4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttexto4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttexto4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttexto4.ForeColor = System.Drawing.Color.MediumBlue
        Me.txttexto4.Location = New System.Drawing.Point(188, 93)
        Me.txttexto4.MaxLength = 50
        Me.txttexto4.Name = "txttexto4"
        Me.txttexto4.Size = New System.Drawing.Size(348, 21)
        Me.txttexto4.TabIndex = 3
        '
        'lblTexto3
        '
        Me.lblTexto3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto3.Location = New System.Drawing.Point(20, 67)
        Me.lblTexto3.Name = "lblTexto3"
        Me.lblTexto3.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto3.TabIndex = 7
        Me.lblTexto3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTexto2
        '
        Me.lblTexto2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto2.Location = New System.Drawing.Point(20, 41)
        Me.lblTexto2.Name = "lblTexto2"
        Me.lblTexto2.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto2.TabIndex = 6
        Me.lblTexto2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTexto1
        '
        Me.lblTexto1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto1.Location = New System.Drawing.Point(20, 15)
        Me.lblTexto1.Name = "lblTexto1"
        Me.lblTexto1.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto1.TabIndex = 5
        Me.lblTexto1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTexto3
        '
        Me.txtTexto3.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto3.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto3.Location = New System.Drawing.Point(188, 67)
        Me.txtTexto3.MaxLength = 50
        Me.txtTexto3.Name = "txtTexto3"
        Me.txtTexto3.Size = New System.Drawing.Size(348, 21)
        Me.txtTexto3.TabIndex = 5
        '
        'txtTexto2
        '
        Me.txtTexto2.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto2.Location = New System.Drawing.Point(188, 41)
        Me.txtTexto2.MaxLength = 50
        Me.txtTexto2.Name = "txtTexto2"
        Me.txtTexto2.Size = New System.Drawing.Size(348, 21)
        Me.txtTexto2.TabIndex = 1
        '
        'txtTexto1
        '
        Me.txtTexto1.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto1.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto1.Location = New System.Drawing.Point(188, 15)
        Me.txtTexto1.MaxLength = 50
        Me.txtTexto1.Name = "txtTexto1"
        Me.txtTexto1.Size = New System.Drawing.Size(348, 21)
        Me.txtTexto1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblValor5)
        Me.TabPage2.Controls.Add(Me.txtValor5)
        Me.TabPage2.Controls.Add(Me.lblValor4)
        Me.TabPage2.Controls.Add(Me.txtValor4)
        Me.TabPage2.Controls.Add(Me.lblValor3)
        Me.TabPage2.Controls.Add(Me.lblValor2)
        Me.TabPage2.Controls.Add(Me.lblValor1)
        Me.TabPage2.Controls.Add(Me.txtValor1)
        Me.TabPage2.Controls.Add(Me.txtValor3)
        Me.TabPage2.Controls.Add(Me.txtValor2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(556, 156)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Campos VALOR"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblValor5
        '
        Me.lblValor5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor5.Location = New System.Drawing.Point(20, 119)
        Me.lblValor5.Name = "lblValor5"
        Me.lblValor5.Size = New System.Drawing.Size(155, 21)
        Me.lblValor5.TabIndex = 9
        Me.lblValor5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor5
        '
        Me.txtValor5.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor5.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor5.Location = New System.Drawing.Point(188, 119)
        Me.txtValor5.Name = "txtValor5"
        Me.txtValor5.Size = New System.Drawing.Size(120, 21)
        Me.txtValor5.TabIndex = 4
        Me.txtValor5.Text = "0"
        Me.txtValor5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValor4
        '
        Me.lblValor4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor4.Location = New System.Drawing.Point(20, 93)
        Me.lblValor4.Name = "lblValor4"
        Me.lblValor4.Size = New System.Drawing.Size(155, 21)
        Me.lblValor4.TabIndex = 8
        Me.lblValor4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor4
        '
        Me.txtValor4.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor4.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor4.Location = New System.Drawing.Point(188, 93)
        Me.txtValor4.Name = "txtValor4"
        Me.txtValor4.Size = New System.Drawing.Size(120, 21)
        Me.txtValor4.TabIndex = 3
        Me.txtValor4.Text = "0"
        Me.txtValor4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValor3
        '
        Me.lblValor3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor3.Location = New System.Drawing.Point(20, 67)
        Me.lblValor3.Name = "lblValor3"
        Me.lblValor3.Size = New System.Drawing.Size(155, 21)
        Me.lblValor3.TabIndex = 7
        Me.lblValor3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValor2
        '
        Me.lblValor2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor2.Location = New System.Drawing.Point(20, 41)
        Me.lblValor2.Name = "lblValor2"
        Me.lblValor2.Size = New System.Drawing.Size(155, 21)
        Me.lblValor2.TabIndex = 6
        Me.lblValor2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValor1
        '
        Me.lblValor1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor1.Location = New System.Drawing.Point(20, 15)
        Me.lblValor1.Name = "lblValor1"
        Me.lblValor1.Size = New System.Drawing.Size(155, 21)
        Me.lblValor1.TabIndex = 5
        Me.lblValor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor1
        '
        Me.txtValor1.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor1.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor1.Location = New System.Drawing.Point(188, 15)
        Me.txtValor1.Name = "txtValor1"
        Me.txtValor1.Size = New System.Drawing.Size(120, 21)
        Me.txtValor1.TabIndex = 0
        Me.txtValor1.Text = "0"
        Me.txtValor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValor3
        '
        Me.txtValor3.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor3.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor3.Location = New System.Drawing.Point(188, 67)
        Me.txtValor3.Name = "txtValor3"
        Me.txtValor3.Size = New System.Drawing.Size(120, 21)
        Me.txtValor3.TabIndex = 2
        Me.txtValor3.Text = "0"
        Me.txtValor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValor2
        '
        Me.txtValor2.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor2.Location = New System.Drawing.Point(188, 41)
        Me.txtValor2.Name = "txtValor2"
        Me.txtValor2.Size = New System.Drawing.Size(120, 21)
        Me.txtValor2.TabIndex = 1
        Me.txtValor2.Text = "0"
        Me.txtValor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblLogico5)
        Me.TabPage3.Controls.Add(Me.ckbLogico5)
        Me.TabPage3.Controls.Add(Me.lblLogico4)
        Me.TabPage3.Controls.Add(Me.ckbLogico4)
        Me.TabPage3.Controls.Add(Me.lblLogico3)
        Me.TabPage3.Controls.Add(Me.lblLogico2)
        Me.TabPage3.Controls.Add(Me.lblLogico1)
        Me.TabPage3.Controls.Add(Me.ckbLogico3)
        Me.TabPage3.Controls.Add(Me.ckbLogico2)
        Me.TabPage3.Controls.Add(Me.ckbLogico1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(556, 156)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Campos LOGICO"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblLogico5
        '
        Me.lblLogico5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico5.Location = New System.Drawing.Point(20, 119)
        Me.lblLogico5.Name = "lblLogico5"
        Me.lblLogico5.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico5.TabIndex = 9
        Me.lblLogico5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbLogico5
        '
        Me.ckbLogico5.AutoSize = True
        Me.ckbLogico5.Location = New System.Drawing.Point(190, 122)
        Me.ckbLogico5.Name = "ckbLogico5"
        Me.ckbLogico5.Size = New System.Drawing.Size(15, 14)
        Me.ckbLogico5.TabIndex = 4
        Me.ckbLogico5.UseVisualStyleBackColor = True
        '
        'lblLogico4
        '
        Me.lblLogico4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico4.Location = New System.Drawing.Point(20, 93)
        Me.lblLogico4.Name = "lblLogico4"
        Me.lblLogico4.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico4.TabIndex = 8
        Me.lblLogico4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbLogico4
        '
        Me.ckbLogico4.AutoSize = True
        Me.ckbLogico4.Location = New System.Drawing.Point(190, 96)
        Me.ckbLogico4.Name = "ckbLogico4"
        Me.ckbLogico4.Size = New System.Drawing.Size(15, 14)
        Me.ckbLogico4.TabIndex = 3
        Me.ckbLogico4.UseVisualStyleBackColor = True
        '
        'lblLogico3
        '
        Me.lblLogico3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico3.Location = New System.Drawing.Point(20, 67)
        Me.lblLogico3.Name = "lblLogico3"
        Me.lblLogico3.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico3.TabIndex = 7
        Me.lblLogico3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogico2
        '
        Me.lblLogico2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico2.Location = New System.Drawing.Point(20, 41)
        Me.lblLogico2.Name = "lblLogico2"
        Me.lblLogico2.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico2.TabIndex = 6
        Me.lblLogico2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogico1
        '
        Me.lblLogico1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico1.Location = New System.Drawing.Point(20, 15)
        Me.lblLogico1.Name = "lblLogico1"
        Me.lblLogico1.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico1.TabIndex = 5
        Me.lblLogico1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbLogico3
        '
        Me.ckbLogico3.AutoSize = True
        Me.ckbLogico3.Location = New System.Drawing.Point(190, 71)
        Me.ckbLogico3.Name = "ckbLogico3"
        Me.ckbLogico3.Size = New System.Drawing.Size(15, 14)
        Me.ckbLogico3.TabIndex = 2
        Me.ckbLogico3.UseVisualStyleBackColor = True
        '
        'ckbLogico2
        '
        Me.ckbLogico2.AutoSize = True
        Me.ckbLogico2.Location = New System.Drawing.Point(190, 45)
        Me.ckbLogico2.Name = "ckbLogico2"
        Me.ckbLogico2.Size = New System.Drawing.Size(15, 14)
        Me.ckbLogico2.TabIndex = 1
        Me.ckbLogico2.UseVisualStyleBackColor = True
        '
        'ckbLogico1
        '
        Me.ckbLogico1.AutoSize = True
        Me.ckbLogico1.Location = New System.Drawing.Point(190, 19)
        Me.ckbLogico1.Name = "ckbLogico1"
        Me.ckbLogico1.Size = New System.Drawing.Size(15, 14)
        Me.ckbLogico1.TabIndex = 0
        Me.ckbLogico1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(256, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(326, 20)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "MANTENIMIENTO DE ELEMENTO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(491, 353)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(40, 40)
        Me.btnGrabar.TabIndex = 8
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(537, 353)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTablaDetalle
        '
        Me.ClientSize = New System.Drawing.Size(600, 400)
        Me.Name = "frmTablaDetalle"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionAmpliada As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescripcionTabla As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTabla As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbTexto5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTexto4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTexto3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblTexto5 As System.Windows.Forms.Label
    Friend WithEvents txttexto5 As System.Windows.Forms.TextBox
    Friend WithEvents lblTexto4 As System.Windows.Forms.Label
    Friend WithEvents txttexto4 As System.Windows.Forms.TextBox
    Friend WithEvents lblTexto3 As System.Windows.Forms.Label
    Friend WithEvents lblTexto2 As System.Windows.Forms.Label
    Friend WithEvents lblTexto1 As System.Windows.Forms.Label
    Friend WithEvents txtTexto3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTexto2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTexto1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblValor5 As System.Windows.Forms.Label
    Friend WithEvents txtValor5 As System.Windows.Forms.TextBox
    Friend WithEvents lblValor4 As System.Windows.Forms.Label
    Friend WithEvents txtValor4 As System.Windows.Forms.TextBox
    Friend WithEvents lblValor3 As System.Windows.Forms.Label
    Friend WithEvents lblValor2 As System.Windows.Forms.Label
    Friend WithEvents lblValor1 As System.Windows.Forms.Label
    Friend WithEvents txtValor1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValor3 As System.Windows.Forms.TextBox
    Friend WithEvents txtValor2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblLogico5 As System.Windows.Forms.Label
    Friend WithEvents ckbLogico5 As System.Windows.Forms.CheckBox
    Friend WithEvents lblLogico4 As System.Windows.Forms.Label
    Friend WithEvents ckbLogico4 As System.Windows.Forms.CheckBox
    Friend WithEvents lblLogico3 As System.Windows.Forms.Label
    Friend WithEvents lblLogico2 As System.Windows.Forms.Label
    Friend WithEvents lblLogico1 As System.Windows.Forms.Label
    Friend WithEvents ckbLogico3 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbLogico2 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbLogico1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button

End Class
