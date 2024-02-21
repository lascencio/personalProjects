<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaCabecera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTablaCabecera))
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.cmbNecesidad = New System.Windows.Forms.ComboBox
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ckbActivo = New System.Windows.Forms.CheckBox
        Me.txtDescripcionAmpliada = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTexto5 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTexto4 = New System.Windows.Forms.TextBox
        Me.lblTexto3 = New System.Windows.Forms.Label
        Me.lblTexto2 = New System.Windows.Forms.Label
        Me.lblTexto1 = New System.Windows.Forms.Label
        Me.txtTexto3 = New System.Windows.Forms.TextBox
        Me.txtTexto2 = New System.Windows.Forms.TextBox
        Me.txtTexto1 = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtValor5 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtValor4 = New System.Windows.Forms.TextBox
        Me.lblValor3 = New System.Windows.Forms.Label
        Me.lblValor2 = New System.Windows.Forms.Label
        Me.lblValor1 = New System.Windows.Forms.Label
        Me.txtValor1 = New System.Windows.Forms.TextBox
        Me.txtValor3 = New System.Windows.Forms.TextBox
        Me.txtValor2 = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtLogico5 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLogico4 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtLogico1 = New System.Windows.Forms.TextBox
        Me.txtLogico3 = New System.Windows.Forms.TextBox
        Me.txtLogico2 = New System.Windows.Forms.TextBox
        Me.lblLogico3 = New System.Windows.Forms.Label
        Me.lblLogico2 = New System.Windows.Forms.Label
        Me.lblLogico1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
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
        Me.Panel.Controls.Add(Me.txtCodigo)
        Me.Panel.Controls.Add(Me.cmbNecesidad)
        Me.Panel.Controls.Add(Me.txtEmpresa)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.ckbActivo)
        Me.Panel.Controls.Add(Me.txtDescripcionAmpliada)
        Me.Panel.Controls.Add(Me.txtDescripcion)
        Me.Panel.Controls.Add(Me.TabControl1)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Size = New System.Drawing.Size(600, 375)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(311, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(271, 20)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "MANTENIMIENTO DE TABLA"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigo.Location = New System.Drawing.Point(13, 48)
        Me.txtCodigo.MaxLength = 25
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(189, 21)
        Me.txtCodigo.TabIndex = 0
        '
        'cmbNecesidad
        '
        Me.cmbNecesidad.BackColor = System.Drawing.Color.Azure
        Me.cmbNecesidad.DisplayMember = "DESCRIPCION"
        Me.cmbNecesidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNecesidad.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbNecesidad.FormattingEnabled = True
        Me.cmbNecesidad.Location = New System.Drawing.Point(204, 342)
        Me.cmbNecesidad.Name = "cmbNecesidad"
        Me.cmbNecesidad.Size = New System.Drawing.Size(159, 21)
        Me.cmbNecesidad.TabIndex = 6
        Me.cmbNecesidad.ValueMember = "CODIGO"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmpresa.Location = New System.Drawing.Point(16, 318)
        Me.txtEmpresa.MaxLength = 20
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpresa.TabIndex = 4
        Me.txtEmpresa.TabStop = False
        Me.txtEmpresa.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Chocolate
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(564, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "DESCRIPCION AMPLIADA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Chocolate
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(208, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(369, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "DESCRIPCION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "TABLA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbActivo
        '
        Me.ckbActivo.AutoSize = True
        Me.ckbActivo.Checked = True
        Me.ckbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbActivo.Location = New System.Drawing.Point(16, 346)
        Me.ckbActivo.Name = "ckbActivo"
        Me.ckbActivo.Size = New System.Drawing.Size(65, 17)
        Me.ckbActivo.TabIndex = 5
        Me.ckbActivo.TabStop = False
        Me.ckbActivo.Text = "ACTIVO"
        Me.ckbActivo.UseVisualStyleBackColor = True
        '
        'txtDescripcionAmpliada
        '
        Me.txtDescripcionAmpliada.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcionAmpliada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionAmpliada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionAmpliada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionAmpliada.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionAmpliada.Location = New System.Drawing.Point(13, 94)
        Me.txtDescripcionAmpliada.MaxLength = 250
        Me.txtDescripcionAmpliada.Name = "txtDescripcionAmpliada"
        Me.txtDescripcionAmpliada.Size = New System.Drawing.Size(564, 21)
        Me.txtDescripcionAmpliada.TabIndex = 2
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcion.Location = New System.Drawing.Point(208, 48)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(369, 21)
        Me.txtDescripcion.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 122)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(565, 190)
        Me.TabControl1.TabIndex = 3
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtTexto5)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtTexto4)
        Me.TabPage1.Controls.Add(Me.lblTexto3)
        Me.TabPage1.Controls.Add(Me.lblTexto2)
        Me.TabPage1.Controls.Add(Me.lblTexto1)
        Me.TabPage1.Controls.Add(Me.txtTexto3)
        Me.TabPage1.Controls.Add(Me.txtTexto2)
        Me.TabPage1.Controls.Add(Me.txtTexto1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(557, 164)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Titulos TEXTO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 21)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "TEXTO 5"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTexto5
        '
        Me.txtTexto5.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto5.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto5.Location = New System.Drawing.Point(185, 123)
        Me.txtTexto5.MaxLength = 25
        Me.txtTexto5.Name = "txtTexto5"
        Me.txtTexto5.Size = New System.Drawing.Size(355, 21)
        Me.txtTexto5.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "TEXTO 4"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTexto4
        '
        Me.txtTexto4.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto4.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto4.Location = New System.Drawing.Point(185, 96)
        Me.txtTexto4.MaxLength = 25
        Me.txtTexto4.Name = "txtTexto4"
        Me.txtTexto4.Size = New System.Drawing.Size(355, 21)
        Me.txtTexto4.TabIndex = 3
        '
        'lblTexto3
        '
        Me.lblTexto3.BackColor = System.Drawing.Color.Transparent
        Me.lblTexto3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto3.Location = New System.Drawing.Point(21, 69)
        Me.lblTexto3.Name = "lblTexto3"
        Me.lblTexto3.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto3.TabIndex = 23
        Me.lblTexto3.Text = "TEXTO 3"
        Me.lblTexto3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTexto2
        '
        Me.lblTexto2.BackColor = System.Drawing.Color.Transparent
        Me.lblTexto2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto2.Location = New System.Drawing.Point(21, 43)
        Me.lblTexto2.Name = "lblTexto2"
        Me.lblTexto2.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto2.TabIndex = 22
        Me.lblTexto2.Text = "TEXTO 2"
        Me.lblTexto2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTexto1
        '
        Me.lblTexto1.BackColor = System.Drawing.Color.Transparent
        Me.lblTexto1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto1.Location = New System.Drawing.Point(21, 17)
        Me.lblTexto1.Name = "lblTexto1"
        Me.lblTexto1.Size = New System.Drawing.Size(155, 21)
        Me.lblTexto1.TabIndex = 21
        Me.lblTexto1.Text = "TEXTO 1"
        Me.lblTexto1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTexto3
        '
        Me.txtTexto3.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto3.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto3.Location = New System.Drawing.Point(185, 69)
        Me.txtTexto3.MaxLength = 25
        Me.txtTexto3.Name = "txtTexto3"
        Me.txtTexto3.Size = New System.Drawing.Size(355, 21)
        Me.txtTexto3.TabIndex = 2
        '
        'txtTexto2
        '
        Me.txtTexto2.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto2.Location = New System.Drawing.Point(185, 43)
        Me.txtTexto2.MaxLength = 25
        Me.txtTexto2.Name = "txtTexto2"
        Me.txtTexto2.Size = New System.Drawing.Size(355, 21)
        Me.txtTexto2.TabIndex = 1
        '
        'txtTexto1
        '
        Me.txtTexto1.BackColor = System.Drawing.Color.Honeydew
        Me.txtTexto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTexto1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto1.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTexto1.Location = New System.Drawing.Point(185, 17)
        Me.txtTexto1.MaxLength = 25
        Me.txtTexto1.Name = "txtTexto1"
        Me.txtTexto1.Size = New System.Drawing.Size(355, 21)
        Me.txtTexto1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtValor5)
        Me.TabPage2.Controls.Add(Me.Label6)
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
        Me.TabPage2.Size = New System.Drawing.Size(557, 164)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Titulos VALOR"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "VALOR 5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor5
        '
        Me.txtValor5.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor5.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor5.Location = New System.Drawing.Point(185, 123)
        Me.txtValor5.MaxLength = 25
        Me.txtValor5.Name = "txtValor5"
        Me.txtValor5.Size = New System.Drawing.Size(355, 21)
        Me.txtValor5.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 21)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "VALOR 4"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor4
        '
        Me.txtValor4.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor4.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor4.Location = New System.Drawing.Point(185, 96)
        Me.txtValor4.MaxLength = 25
        Me.txtValor4.Name = "txtValor4"
        Me.txtValor4.Size = New System.Drawing.Size(355, 21)
        Me.txtValor4.TabIndex = 8
        '
        'lblValor3
        '
        Me.lblValor3.BackColor = System.Drawing.Color.Transparent
        Me.lblValor3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor3.Location = New System.Drawing.Point(21, 69)
        Me.lblValor3.Name = "lblValor3"
        Me.lblValor3.Size = New System.Drawing.Size(155, 21)
        Me.lblValor3.TabIndex = 26
        Me.lblValor3.Text = "VALOR 3"
        Me.lblValor3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValor2
        '
        Me.lblValor2.BackColor = System.Drawing.Color.Transparent
        Me.lblValor2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor2.Location = New System.Drawing.Point(21, 43)
        Me.lblValor2.Name = "lblValor2"
        Me.lblValor2.Size = New System.Drawing.Size(155, 21)
        Me.lblValor2.TabIndex = 25
        Me.lblValor2.Text = "VALOR 2"
        Me.lblValor2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValor1
        '
        Me.lblValor1.BackColor = System.Drawing.Color.Transparent
        Me.lblValor1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor1.Location = New System.Drawing.Point(21, 17)
        Me.lblValor1.Name = "lblValor1"
        Me.lblValor1.Size = New System.Drawing.Size(155, 21)
        Me.lblValor1.TabIndex = 24
        Me.lblValor1.Text = "VALOR 1"
        Me.lblValor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor1
        '
        Me.txtValor1.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor1.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor1.Location = New System.Drawing.Point(185, 17)
        Me.txtValor1.MaxLength = 25
        Me.txtValor1.Name = "txtValor1"
        Me.txtValor1.Size = New System.Drawing.Size(355, 21)
        Me.txtValor1.TabIndex = 5
        '
        'txtValor3
        '
        Me.txtValor3.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor3.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor3.Location = New System.Drawing.Point(185, 69)
        Me.txtValor3.MaxLength = 25
        Me.txtValor3.Name = "txtValor3"
        Me.txtValor3.Size = New System.Drawing.Size(355, 21)
        Me.txtValor3.TabIndex = 7
        '
        'txtValor2
        '
        Me.txtValor2.BackColor = System.Drawing.Color.Honeydew
        Me.txtValor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtValor2.Location = New System.Drawing.Point(185, 43)
        Me.txtValor2.MaxLength = 25
        Me.txtValor2.Name = "txtValor2"
        Me.txtValor2.Size = New System.Drawing.Size(355, 21)
        Me.txtValor2.TabIndex = 6
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage3.Controls.Add(Me.txtLogico5)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.txtLogico4)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtLogico1)
        Me.TabPage3.Controls.Add(Me.txtLogico3)
        Me.TabPage3.Controls.Add(Me.txtLogico2)
        Me.TabPage3.Controls.Add(Me.lblLogico3)
        Me.TabPage3.Controls.Add(Me.lblLogico2)
        Me.TabPage3.Controls.Add(Me.lblLogico1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(557, 164)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Titulos LOGICO"
        '
        'txtLogico5
        '
        Me.txtLogico5.BackColor = System.Drawing.Color.Honeydew
        Me.txtLogico5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogico5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogico5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogico5.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLogico5.Location = New System.Drawing.Point(185, 123)
        Me.txtLogico5.MaxLength = 25
        Me.txtLogico5.Name = "txtLogico5"
        Me.txtLogico5.Size = New System.Drawing.Size(355, 21)
        Me.txtLogico5.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 21)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "LOGICO 5"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLogico4
        '
        Me.txtLogico4.BackColor = System.Drawing.Color.Honeydew
        Me.txtLogico4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogico4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogico4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogico4.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLogico4.Location = New System.Drawing.Point(185, 96)
        Me.txtLogico4.MaxLength = 25
        Me.txtLogico4.Name = "txtLogico4"
        Me.txtLogico4.Size = New System.Drawing.Size(355, 21)
        Me.txtLogico4.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 21)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "LOGICO 4"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLogico1
        '
        Me.txtLogico1.BackColor = System.Drawing.Color.Honeydew
        Me.txtLogico1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogico1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogico1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogico1.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLogico1.Location = New System.Drawing.Point(185, 17)
        Me.txtLogico1.MaxLength = 25
        Me.txtLogico1.Name = "txtLogico1"
        Me.txtLogico1.Size = New System.Drawing.Size(355, 21)
        Me.txtLogico1.TabIndex = 10
        '
        'txtLogico3
        '
        Me.txtLogico3.BackColor = System.Drawing.Color.Honeydew
        Me.txtLogico3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogico3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogico3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogico3.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLogico3.Location = New System.Drawing.Point(185, 69)
        Me.txtLogico3.MaxLength = 25
        Me.txtLogico3.Name = "txtLogico3"
        Me.txtLogico3.Size = New System.Drawing.Size(355, 21)
        Me.txtLogico3.TabIndex = 12
        '
        'txtLogico2
        '
        Me.txtLogico2.BackColor = System.Drawing.Color.Honeydew
        Me.txtLogico2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogico2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogico2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogico2.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLogico2.Location = New System.Drawing.Point(185, 43)
        Me.txtLogico2.MaxLength = 25
        Me.txtLogico2.Name = "txtLogico2"
        Me.txtLogico2.Size = New System.Drawing.Size(355, 21)
        Me.txtLogico2.TabIndex = 11
        '
        'lblLogico3
        '
        Me.lblLogico3.BackColor = System.Drawing.Color.Transparent
        Me.lblLogico3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico3.Location = New System.Drawing.Point(21, 68)
        Me.lblLogico3.Name = "lblLogico3"
        Me.lblLogico3.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico3.TabIndex = 26
        Me.lblLogico3.Text = "LOGICO 3"
        Me.lblLogico3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogico2
        '
        Me.lblLogico2.BackColor = System.Drawing.Color.Transparent
        Me.lblLogico2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico2.Location = New System.Drawing.Point(21, 42)
        Me.lblLogico2.Name = "lblLogico2"
        Me.lblLogico2.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico2.TabIndex = 25
        Me.lblLogico2.Text = "LOGICO 2"
        Me.lblLogico2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogico1
        '
        Me.lblLogico1.BackColor = System.Drawing.Color.Transparent
        Me.lblLogico1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogico1.Location = New System.Drawing.Point(21, 16)
        Me.lblLogico1.Name = "lblLogico1"
        Me.lblLogico1.Size = New System.Drawing.Size(155, 21)
        Me.lblLogico1.TabIndex = 24
        Me.lblLogico1.Text = "LOGICO 1"
        Me.lblLogico1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Chocolate
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(204, 323)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 18)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "NECESIDAD"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(495, 323)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(40, 40)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(541, 323)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTablaCabecera
        '
        Me.ClientSize = New System.Drawing.Size(600, 375)
        Me.Name = "frmTablaCabecera"
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
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmbNecesidad As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ckbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescripcionAmpliada As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTexto5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTexto4 As System.Windows.Forms.TextBox
    Friend WithEvents lblTexto3 As System.Windows.Forms.Label
    Friend WithEvents lblTexto2 As System.Windows.Forms.Label
    Friend WithEvents lblTexto1 As System.Windows.Forms.Label
    Friend WithEvents txtTexto3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTexto2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTexto1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValor5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtValor4 As System.Windows.Forms.TextBox
    Friend WithEvents lblValor3 As System.Windows.Forms.Label
    Friend WithEvents lblValor2 As System.Windows.Forms.Label
    Friend WithEvents lblValor1 As System.Windows.Forms.Label
    Friend WithEvents txtValor1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValor3 As System.Windows.Forms.TextBox
    Friend WithEvents txtValor2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtLogico5 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLogico4 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLogico1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLogico3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLogico2 As System.Windows.Forms.TextBox
    Friend WithEvents lblLogico3 As System.Windows.Forms.Label
    Friend WithEvents lblLogico2 As System.Windows.Forms.Label
    Friend WithEvents lblLogico1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
