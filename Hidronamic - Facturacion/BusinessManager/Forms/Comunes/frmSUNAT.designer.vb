<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSUNAT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSUNAT))
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtRUC = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAntiguoRuc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ckbAgenteRetencion = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombreComercial = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSituacion = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDependencia = New System.Windows.Forms.TextBox
        Me.btnMostrar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(12, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(641, 15)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "RAZON SOCIAL"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.LightYellow
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(12, 62)
        Me.txtRazonSocial.MaxLength = 100
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(640, 20)
        Me.txtRazonSocial.TabIndex = 2
        Me.txtRazonSocial.TabStop = False
        '
        'txtRUC
        '
        Me.txtRUC.BackColor = System.Drawing.Color.Honeydew
        Me.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRUC.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtRUC.Location = New System.Drawing.Point(12, 24)
        Me.txtRUC.MaxLength = 11
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(83, 20)
        Me.txtRUC.TabIndex = 0
        Me.txtRUC.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 15)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "RUC"
        '
        'txtAntiguoRuc
        '
        Me.txtAntiguoRuc.BackColor = System.Drawing.Color.LightYellow
        Me.txtAntiguoRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAntiguoRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAntiguoRuc.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAntiguoRuc.Location = New System.Drawing.Point(471, 100)
        Me.txtAntiguoRuc.MaxLength = 11
        Me.txtAntiguoRuc.Name = "txtAntiguoRuc"
        Me.txtAntiguoRuc.ReadOnly = True
        Me.txtAntiguoRuc.Size = New System.Drawing.Size(83, 20)
        Me.txtAntiguoRuc.TabIndex = 4
        Me.txtAntiguoRuc.TabStop = False
        Me.txtAntiguoRuc.Tag = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(471, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "ANTIGUO RUC"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.Color.LightYellow
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEstado.Location = New System.Drawing.Point(561, 100)
        Me.txtEstado.MaxLength = 20
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(90, 20)
        Me.txtEstado.TabIndex = 5
        Me.txtEstado.TabStop = False
        Me.txtEstado.Tag = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(561, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "ESTADO"
        '
        'ckbAgenteRetencion
        '
        Me.ckbAgenteRetencion.AutoSize = True
        Me.ckbAgenteRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAgenteRetencion.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbAgenteRetencion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAgenteRetencion.Location = New System.Drawing.Point(498, 24)
        Me.ckbAgenteRetencion.Name = "ckbAgenteRetencion"
        Me.ckbAgenteRetencion.Size = New System.Drawing.Size(154, 17)
        Me.ckbAgenteRetencion.TabIndex = 10
        Me.ckbAgenteRetencion.TabStop = False
        Me.ckbAgenteRetencion.Text = "AGENTE DE RETENCION"
        Me.ckbAgenteRetencion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(441, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "NOMBRE COMERCIAL"
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.BackColor = System.Drawing.Color.LightYellow
        Me.txtNombreComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreComercial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNombreComercial.Location = New System.Drawing.Point(12, 100)
        Me.txtNombreComercial.MaxLength = 100
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.ReadOnly = True
        Me.txtNombreComercial.Size = New System.Drawing.Size(440, 20)
        Me.txtNombreComercial.TabIndex = 3
        Me.txtNombreComercial.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(641, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "DOMICILIO"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.LightYellow
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDireccion.Location = New System.Drawing.Point(12, 138)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(640, 20)
        Me.txtDireccion.TabIndex = 6
        Me.txtDireccion.TabStop = False
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.LightYellow
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTelefono.Location = New System.Drawing.Point(12, 176)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(90, 20)
        Me.txtTelefono.TabIndex = 7
        Me.txtTelefono.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "TELEFONO"
        '
        'txtSituacion
        '
        Me.txtSituacion.BackColor = System.Drawing.Color.LightYellow
        Me.txtSituacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSituacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSituacion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSituacion.Location = New System.Drawing.Point(108, 176)
        Me.txtSituacion.MaxLength = 20
        Me.txtSituacion.Name = "txtSituacion"
        Me.txtSituacion.ReadOnly = True
        Me.txtSituacion.Size = New System.Drawing.Size(90, 20)
        Me.txtSituacion.TabIndex = 8
        Me.txtSituacion.TabStop = False
        Me.txtSituacion.Tag = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(108, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "SITUACION"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(361, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(291, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "DEPENDENCIA"
        '
        'txtDependencia
        '
        Me.txtDependencia.BackColor = System.Drawing.Color.LightYellow
        Me.txtDependencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDependencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependencia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDependencia.Location = New System.Drawing.Point(361, 176)
        Me.txtDependencia.MaxLength = 100
        Me.txtDependencia.Name = "txtDependencia"
        Me.txtDependencia.ReadOnly = True
        Me.txtDependencia.Size = New System.Drawing.Size(290, 20)
        Me.txtDependencia.TabIndex = 9
        Me.txtDependencia.TabStop = False
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = CType(resources.GetObject("btnMostrar.BackgroundImage"), System.Drawing.Image)
        Me.btnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMostrar.FlatAppearance.BorderSize = 0
        Me.btnMostrar.Location = New System.Drawing.Point(102, 9)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(35, 35)
        Me.btnMostrar.TabIndex = 1
        Me.btnMostrar.UseVisualStyleBackColor = False
        '
        'frmSUNAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 212)
        Me.Controls.Add(Me.btnMostrar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDependencia)
        Me.Controls.Add(Me.txtSituacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombreComercial)
        Me.Controls.Add(Me.ckbAgenteRetencion)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAntiguoRuc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.txtRUC)
        Me.Controls.Add(Me.Label15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmSUNAT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTAR RUC - SUNAT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtRUC As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAntiguoRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckbAgenteRetencion As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSituacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDependencia As System.Windows.Forms.TextBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
End Class
