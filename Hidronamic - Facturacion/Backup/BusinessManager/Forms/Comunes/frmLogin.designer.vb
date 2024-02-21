<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.lblClaveActual = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.btnAcceder = New System.Windows.Forms.Button
        Me.PanelNuevaClave = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtClaveConfirmar = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtClaveNueva = New System.Windows.Forms.TextBox
        Me.ckbCambiarClave = New System.Windows.Forms.CheckBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.cmbModulo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.PanelNuevaClave.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblClaveActual
        '
        Me.lblClaveActual.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblClaveActual.Location = New System.Drawing.Point(9, 43)
        Me.lblClaveActual.Name = "lblClaveActual"
        Me.lblClaveActual.Size = New System.Drawing.Size(85, 20)
        Me.lblClaveActual.TabIndex = 8
        Me.lblClaveActual.Text = "CLAVE"
        Me.lblClaveActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "USUARIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClave
        '
        Me.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Location = New System.Drawing.Point(100, 43)
        Me.txtClave.MaxLength = 20
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(132, 20)
        Me.txtClave.TabIndex = 1
        Me.txtClave.UseSystemPasswordChar = True
        '
        'txtUsuario
        '
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Location = New System.Drawing.Point(100, 17)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(132, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'btnAcceder
        '
        Me.btnAcceder.BackgroundImage = CType(resources.GetObject("btnAcceder.BackgroundImage"), System.Drawing.Image)
        Me.btnAcceder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAcceder.Location = New System.Drawing.Point(325, 145)
        Me.btnAcceder.Name = "btnAcceder"
        Me.btnAcceder.Size = New System.Drawing.Size(40, 40)
        Me.btnAcceder.TabIndex = 4
        Me.btnAcceder.UseVisualStyleBackColor = False
        '
        'PanelNuevaClave
        '
        Me.PanelNuevaClave.Controls.Add(Me.Label4)
        Me.PanelNuevaClave.Controls.Add(Me.txtClaveConfirmar)
        Me.PanelNuevaClave.Controls.Add(Me.Label3)
        Me.PanelNuevaClave.Controls.Add(Me.txtClaveNueva)
        Me.PanelNuevaClave.Location = New System.Drawing.Point(11, 216)
        Me.PanelNuevaClave.Name = "PanelNuevaClave"
        Me.PanelNuevaClave.Size = New System.Drawing.Size(354, 59)
        Me.PanelNuevaClave.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(17, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CONFIRMAR CLAVE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClaveConfirmar
        '
        Me.txtClaveConfirmar.BackColor = System.Drawing.Color.Ivory
        Me.txtClaveConfirmar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClaveConfirmar.Location = New System.Drawing.Point(183, 32)
        Me.txtClaveConfirmar.MaxLength = 20
        Me.txtClaveConfirmar.Name = "txtClaveConfirmar"
        Me.txtClaveConfirmar.Size = New System.Drawing.Size(132, 20)
        Me.txtClaveConfirmar.TabIndex = 1
        Me.txtClaveConfirmar.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(17, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "NUEVA CLAVE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClaveNueva
        '
        Me.txtClaveNueva.BackColor = System.Drawing.Color.Ivory
        Me.txtClaveNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClaveNueva.Location = New System.Drawing.Point(183, 6)
        Me.txtClaveNueva.MaxLength = 20
        Me.txtClaveNueva.Name = "txtClaveNueva"
        Me.txtClaveNueva.Size = New System.Drawing.Size(132, 20)
        Me.txtClaveNueva.TabIndex = 0
        Me.txtClaveNueva.UseSystemPasswordChar = True
        '
        'ckbCambiarClave
        '
        Me.ckbCambiarClave.ForeColor = System.Drawing.Color.Maroon
        Me.ckbCambiarClave.Location = New System.Drawing.Point(11, 168)
        Me.ckbCambiarClave.Name = "ckbCambiarClave"
        Me.ckbCambiarClave.Size = New System.Drawing.Size(120, 20)
        Me.ckbCambiarClave.TabIndex = 6
        Me.ckbCambiarClave.TabStop = False
        Me.ckbCambiarClave.Text = "Cambiar Clave"
        Me.ckbCambiarClave.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(279, 145)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'cmbModulo
        '
        Me.cmbModulo.BackColor = System.Drawing.Color.Azure
        Me.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModulo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbModulo.FormattingEnabled = True
        Me.cmbModulo.Items.AddRange(New Object() {"CONTABILIDAD", "REMUNERACIONES"})
        Me.cmbModulo.Location = New System.Drawing.Point(100, 73)
        Me.cmbModulo.Name = "cmbModulo"
        Me.cmbModulo.Size = New System.Drawing.Size(265, 21)
        Me.cmbModulo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "MODULO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(9, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "EMPRESA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.Color.Azure
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(100, 109)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(265, 21)
        Me.cmbEmpresa.TabIndex = 3
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(377, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbModulo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.ckbCambiarClave)
        Me.Controls.Add(Me.PanelNuevaClave)
        Me.Controls.Add(Me.lblClaveActual)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAcceder)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SESION DE TRABAJO"
        Me.PanelNuevaClave.ResumeLayout(False)
        Me.PanelNuevaClave.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblClaveActual As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAcceder As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents PanelNuevaClave As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtClaveConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtClaveNueva As System.Windows.Forms.TextBox
    Friend WithEvents ckbCambiarClave As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
End Class
