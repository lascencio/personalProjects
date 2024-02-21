<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCliente
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
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmailFacturacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtClaveWeb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuarioWeb = New System.Windows.Forms.TextBox()
        Me.ckbEstado = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtPrefijo = New System.Windows.Forms.TextBox()
        Me.ckbIndicaNoDomiciliado = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmailContacto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtNumeroRUC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(636, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtEmailFacturacion)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtClaveWeb)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtUsuarioWeb)
        Me.Panel.Controls.Add(Me.ckbEstado)
        Me.Panel.Controls.Add(Me.Label35)
        Me.Panel.Controls.Add(Me.txtPrefijo)
        Me.Panel.Controls.Add(Me.ckbIndicaNoDomiciliado)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtEmailContacto)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtNumeroRUC)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Size = New System.Drawing.Size(636, 252)
        Me.Panel.TabIndex = 0
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(11, 118)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(609, 18)
        Me.Label43.TabIndex = 13
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
        Me.txtDomicilio.Location = New System.Drawing.Point(11, 137)
        Me.txtDomicilio.MaxLength = 50
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(609, 21)
        Me.txtDomicilio.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(8, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(446, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "INFORMACION PARA EL SISTEMA DE EMISION ELECTRONICA (SEE - SUNAT)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(11, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(312, 21)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "CORREO  PARA ENVIO DE LA REPRESENTACION IMPRESA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Visible = False
        '
        'txtEmailFacturacion
        '
        Me.txtEmailFacturacion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmailFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailFacturacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailFacturacion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmailFacturacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmailFacturacion.Location = New System.Drawing.Point(11, 218)
        Me.txtEmailFacturacion.MaxLength = 80
        Me.txtEmailFacturacion.Name = "txtEmailFacturacion"
        Me.txtEmailFacturacion.Size = New System.Drawing.Size(358, 21)
        Me.txtEmailFacturacion.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(370, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 21)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "CLAVE WEB"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClaveWeb
        '
        Me.txtClaveWeb.BackColor = System.Drawing.Color.AliceBlue
        Me.txtClaveWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClaveWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveWeb.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtClaveWeb.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtClaveWeb.Location = New System.Drawing.Point(370, 218)
        Me.txtClaveWeb.MaxLength = 80
        Me.txtClaveWeb.Name = "txtClaveWeb"
        Me.txtClaveWeb.Size = New System.Drawing.Size(129, 21)
        Me.txtClaveWeb.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(325, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 21)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "USUARIO WEB"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'txtUsuarioWeb
        '
        Me.txtUsuarioWeb.BackColor = System.Drawing.Color.AliceBlue
        Me.txtUsuarioWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuarioWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuarioWeb.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtUsuarioWeb.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtUsuarioWeb.Location = New System.Drawing.Point(325, 300)
        Me.txtUsuarioWeb.MaxLength = 15
        Me.txtUsuarioWeb.Name = "txtUsuarioWeb"
        Me.txtUsuarioWeb.Size = New System.Drawing.Size(117, 21)
        Me.txtUsuarioWeb.TabIndex = 8
        Me.txtUsuarioWeb.TabStop = False
        Me.txtUsuarioWeb.Visible = False
        '
        'ckbEstado
        '
        Me.ckbEstado.BackColor = System.Drawing.Color.Transparent
        Me.ckbEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbEstado.Checked = True
        Me.ckbEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbEstado.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckbEstado.ForeColor = System.Drawing.Color.Navy
        Me.ckbEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbEstado.Location = New System.Drawing.Point(478, 161)
        Me.ckbEstado.Name = "ckbEstado"
        Me.ckbEstado.Size = New System.Drawing.Size(142, 17)
        Me.ckbEstado.TabIndex = 5
        Me.ckbEstado.TabStop = False
        Me.ckbEstado.Text = "INDICA  ACTIVO"
        Me.ckbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbEstado.UseVisualStyleBackColor = False
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(448, 281)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(56, 18)
        Me.Label35.TabIndex = 19
        Me.Label35.Text = "PREFIJO"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label35.Visible = False
        '
        'txtPrefijo
        '
        Me.txtPrefijo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPrefijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrefijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrefijo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtPrefijo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPrefijo.Location = New System.Drawing.Point(448, 300)
        Me.txtPrefijo.MaxLength = 4
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(56, 21)
        Me.txtPrefijo.TabIndex = 9
        Me.txtPrefijo.TabStop = False
        Me.txtPrefijo.Visible = False
        '
        'ckbIndicaNoDomiciliado
        '
        Me.ckbIndicaNoDomiciliado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaNoDomiciliado.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckbIndicaNoDomiciliado.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaNoDomiciliado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaNoDomiciliado.Location = New System.Drawing.Point(134, 57)
        Me.ckbIndicaNoDomiciliado.Name = "ckbIndicaNoDomiciliado"
        Me.ckbIndicaNoDomiciliado.Size = New System.Drawing.Size(247, 17)
        Me.ckbIndicaNoDomiciliado.TabIndex = 6
        Me.ckbIndicaNoDomiciliado.TabStop = False
        Me.ckbIndicaNoDomiciliado.Text = "INDICA NO DOMICILIADO"
        Me.ckbIndicaNoDomiciliado.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(11, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(358, 21)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "CORREO  PARA ENVIO DE COMPROBANTES ELECTRONICOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailContacto
        '
        Me.txtEmailContacto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmailContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailContacto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmailContacto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmailContacto.Location = New System.Drawing.Point(11, 300)
        Me.txtEmailContacto.MaxLength = 70
        Me.txtEmailContacto.Name = "txtEmailContacto"
        Me.txtEmailContacto.Size = New System.Drawing.Size(312, 21)
        Me.txtEmailContacto.TabIndex = 7
        Me.txtEmailContacto.TabStop = False
        Me.txtEmailContacto.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(609, 18)
        Me.Label1.TabIndex = 12
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(11, 94)
        Me.txtRazonSocial.MaxLength = 40
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(609, 21)
        Me.txtRazonSocial.TabIndex = 1
        '
        'txtNumeroRUC
        '
        Me.txtNumeroRUC.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroRUC.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroRUC.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroRUC.Location = New System.Drawing.Point(11, 51)
        Me.txtNumeroRUC.MaxLength = 18
        Me.txtNumeroRUC.Name = "txtNumeroRUC"
        Me.txtNumeroRUC.Size = New System.Drawing.Size(117, 21)
        Me.txtNumeroRUC.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(11, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "RUC"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(276, -1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(344, 20)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "MANTENIMIENTO DE CLIENTES"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCliente
        '
        Me.ClientSize = New System.Drawing.Size(636, 288)
        Me.Name = "frmCliente"
        Me.Text = "  MANTENIMIENTO DE CLIENTES"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmailFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClaveWeb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioWeb As System.Windows.Forms.TextBox
    Friend WithEvents ckbEstado As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPrefijo As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaNoDomiciliado As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroRUC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
