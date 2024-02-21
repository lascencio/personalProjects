<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaChica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajaChica))
        Me.btnSiguiente = New System.Windows.Forms.Button
        Me.btnAnterior = New System.Windows.Forms.Button
        Me.btnLibre = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.UC_ToolBar = New MyControlToolBar.UserControlToolBar
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbAreaResponsable = New System.Windows.Forms.ComboBox
        Me.txtCodigoUI = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtCajaEjercicio = New System.Windows.Forms.TextBox
        Me.txtCajaMes = New System.Windows.Forms.TextBox
        Me.txtCajaNumero = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAperturaFecha = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtAperturaImporte = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSaldoAnterior = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtSaldoActual = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtTotalEgresos = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.txtpagoMaximo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1440, 838)
        '
        'btnSiguiente
        '
        Me.btnSiguiente.BackgroundImage = CType(resources.GetObject("btnSiguiente.BackgroundImage"), System.Drawing.Image)
        Me.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSiguiente.FlatAppearance.BorderSize = 0
        Me.btnSiguiente.Location = New System.Drawing.Point(693, 59)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(20, 40)
        Me.btnSiguiente.TabIndex = 49
        Me.btnSiguiente.TabStop = False
        Me.btnSiguiente.UseVisualStyleBackColor = False
        '
        'btnAnterior
        '
        Me.btnAnterior.BackgroundImage = CType(resources.GetObject("btnAnterior.BackgroundImage"), System.Drawing.Image)
        Me.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAnterior.FlatAppearance.BorderSize = 0
        Me.btnAnterior.Location = New System.Drawing.Point(675, 59)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(20, 40)
        Me.btnAnterior.TabIndex = 48
        Me.btnAnterior.TabStop = False
        Me.btnAnterior.UseVisualStyleBackColor = False
        '
        'btnLibre
        '
        Me.btnLibre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLibre.FlatAppearance.BorderSize = 0
        Me.btnLibre.Location = New System.Drawing.Point(765, 59)
        Me.btnLibre.Name = "btnLibre"
        Me.btnLibre.Size = New System.Drawing.Size(40, 40)
        Me.btnLibre.TabIndex = 50
        Me.btnLibre.TabStop = False
        Me.btnLibre.UseVisualStyleBackColor = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(719, 59)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(40, 40)
        Me.btnGrabar.TabIndex = 47
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(811, 59)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 51
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.AutoSize = True
        Me.UC_ToolBar.btnBorrar_Visible = False
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnImprimir_Visible = False
        Me.UC_ToolBar.btnNuevo_Visible = False
        Me.UC_ToolBar.Location = New System.Drawing.Point(672, 12)
        Me.UC_ToolBar.Name = "UC_ToolBar"
        Me.UC_ToolBar.Size = New System.Drawing.Size(183, 43)
        Me.UC_ToolBar.TabIndex = 52
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.SteelBlue
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(385, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 15)
        Me.Label21.TabIndex = 106
        Me.Label21.Text = "# CAJA"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(80, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(298, 15)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "AREA / RESPONSABLE"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAreaResponsable
        '
        Me.cmbAreaResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAreaResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAreaResponsable.BackColor = System.Drawing.Color.Azure
        Me.cmbAreaResponsable.DisplayMember = "NOMBRE_LARGO"
        Me.cmbAreaResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreaResponsable.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAreaResponsable.FormattingEnabled = True
        Me.cmbAreaResponsable.Location = New System.Drawing.Point(80, 25)
        Me.cmbAreaResponsable.Name = "cmbAreaResponsable"
        Me.cmbAreaResponsable.Size = New System.Drawing.Size(298, 21)
        Me.cmbAreaResponsable.TabIndex = 87
        Me.cmbAreaResponsable.ValueMember = "CODIGO_ITEM"
        '
        'txtCodigoUI
        '
        Me.txtCodigoUI.BackColor = System.Drawing.Color.LightYellow
        Me.txtCodigoUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoUI.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCodigoUI.Location = New System.Drawing.Point(643, 132)
        Me.txtCodigoUI.MaxLength = 12
        Me.txtCodigoUI.Name = "txtCodigoUI"
        Me.txtCodigoUI.ReadOnly = True
        Me.txtCodigoUI.Size = New System.Drawing.Size(80, 20)
        Me.txtCodigoUI.TabIndex = 97
        Me.txtCodigoUI.TabStop = False
        Me.txtCodigoUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCodigoUI.Visible = False
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.SteelBlue
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(12, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(57, 15)
        Me.Label38.TabIndex = 98
        Me.Label38.Text = "PERIODO"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCajaEjercicio
        '
        Me.txtCajaEjercicio.BackColor = System.Drawing.Color.LightYellow
        Me.txtCajaEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCajaEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCajaEjercicio.Location = New System.Drawing.Point(12, 25)
        Me.txtCajaEjercicio.MaxLength = 4
        Me.txtCajaEjercicio.Name = "txtCajaEjercicio"
        Me.txtCajaEjercicio.ReadOnly = True
        Me.txtCajaEjercicio.Size = New System.Drawing.Size(35, 20)
        Me.txtCajaEjercicio.TabIndex = 85
        Me.txtCajaEjercicio.TabStop = False
        Me.txtCajaEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCajaMes
        '
        Me.txtCajaMes.BackColor = System.Drawing.Color.LightYellow
        Me.txtCajaMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCajaMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCajaMes.Location = New System.Drawing.Point(49, 25)
        Me.txtCajaMes.MaxLength = 2
        Me.txtCajaMes.Name = "txtCajaMes"
        Me.txtCajaMes.ReadOnly = True
        Me.txtCajaMes.Size = New System.Drawing.Size(20, 20)
        Me.txtCajaMes.TabIndex = 86
        Me.txtCajaMes.TabStop = False
        Me.txtCajaMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCajaNumero
        '
        Me.txtCajaNumero.BackColor = System.Drawing.Color.LightYellow
        Me.txtCajaNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCajaNumero.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCajaNumero.Location = New System.Drawing.Point(385, 25)
        Me.txtCajaNumero.MaxLength = 4
        Me.txtCajaNumero.Name = "txtCajaNumero"
        Me.txtCajaNumero.ReadOnly = True
        Me.txtCajaNumero.Size = New System.Drawing.Size(42, 20)
        Me.txtCajaNumero.TabIndex = 88
        Me.txtCajaNumero.TabStop = False
        Me.txtCajaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(553, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "F. APERTURA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAperturaFecha
        '
        Me.txtAperturaFecha.BackColor = System.Drawing.Color.LightYellow
        Me.txtAperturaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAperturaFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAperturaFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAperturaFecha.Location = New System.Drawing.Point(553, 25)
        Me.txtAperturaFecha.MaxLength = 10
        Me.txtAperturaFecha.Name = "txtAperturaFecha"
        Me.txtAperturaFecha.ReadOnly = True
        Me.txtAperturaFecha.Size = New System.Drawing.Size(71, 20)
        Me.txtAperturaFecha.TabIndex = 107
        Me.txtAperturaFecha.TabStop = False
        Me.txtAperturaFecha.Tag = "F"
        Me.txtAperturaFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(105, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 15)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "IMPORTE"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAperturaImporte
        '
        Me.txtAperturaImporte.BackColor = System.Drawing.Color.LightYellow
        Me.txtAperturaImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAperturaImporte.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAperturaImporte.Location = New System.Drawing.Point(105, 79)
        Me.txtAperturaImporte.MaxLength = 14
        Me.txtAperturaImporte.Name = "txtAperturaImporte"
        Me.txtAperturaImporte.ReadOnly = True
        Me.txtAperturaImporte.Size = New System.Drawing.Size(84, 20)
        Me.txtAperturaImporte.TabIndex = 111
        Me.txtAperturaImporte.TabStop = False
        Me.txtAperturaImporte.Tag = "D"
        Me.txtAperturaImporte.Text = "0.00"
        Me.txtAperturaImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(15, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "SALDO ANT."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSaldoAnterior
        '
        Me.txtSaldoAnterior.BackColor = System.Drawing.Color.LightYellow
        Me.txtSaldoAnterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoAnterior.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSaldoAnterior.Location = New System.Drawing.Point(15, 79)
        Me.txtSaldoAnterior.MaxLength = 14
        Me.txtSaldoAnterior.Name = "txtSaldoAnterior"
        Me.txtSaldoAnterior.ReadOnly = True
        Me.txtSaldoAnterior.Size = New System.Drawing.Size(84, 20)
        Me.txtSaldoAnterior.TabIndex = 113
        Me.txtSaldoAnterior.TabStop = False
        Me.txtSaldoAnterior.Tag = "D"
        Me.txtSaldoAnterior.Text = "0.00"
        Me.txtSaldoAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.SteelBlue
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(289, 63)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(89, 15)
        Me.Label34.TabIndex = 118
        Me.Label34.Text = "SALDO ACTUAL"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.BackColor = System.Drawing.Color.LightYellow
        Me.txtSaldoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoActual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSaldoActual.Location = New System.Drawing.Point(289, 79)
        Me.txtSaldoActual.MaxLength = 14
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.ReadOnly = True
        Me.txtSaldoActual.Size = New System.Drawing.Size(89, 20)
        Me.txtSaldoActual.TabIndex = 116
        Me.txtSaldoActual.TabStop = False
        Me.txtSaldoActual.Tag = "D"
        Me.txtSaldoActual.Text = "0.00"
        Me.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(195, 63)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(89, 15)
        Me.Label35.TabIndex = 117
        Me.Label35.Text = "TOT. EGRESOS"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalEgresos
        '
        Me.txtTotalEgresos.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotalEgresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalEgresos.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalEgresos.Location = New System.Drawing.Point(195, 79)
        Me.txtTotalEgresos.MaxLength = 14
        Me.txtTotalEgresos.Name = "txtTotalEgresos"
        Me.txtTotalEgresos.ReadOnly = True
        Me.txtTotalEgresos.Size = New System.Drawing.Size(89, 20)
        Me.txtTotalEgresos.TabIndex = 115
        Me.txtTotalEgresos.TabStop = False
        Me.txtTotalEgresos.Tag = "D"
        Me.txtTotalEgresos.Text = "0.00"
        Me.txtTotalEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(615, 15)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "COMENTARIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.Honeydew
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtGlosa.Location = New System.Drawing.Point(9, 132)
        Me.txtGlosa.MaxLength = 40
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(615, 20)
        Me.txtGlosa.TabIndex = 119
        Me.txtGlosa.TabStop = False
        '
        'txtpagoMaximo
        '
        Me.txtpagoMaximo.BackColor = System.Drawing.Color.Honeydew
        Me.txtpagoMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpagoMaximo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtpagoMaximo.Location = New System.Drawing.Point(762, 132)
        Me.txtpagoMaximo.MaxLength = 10
        Me.txtpagoMaximo.Name = "txtpagoMaximo"
        Me.txtpagoMaximo.Size = New System.Drawing.Size(89, 20)
        Me.txtpagoMaximo.TabIndex = 121
        Me.txtpagoMaximo.Tag = "D"
        Me.txtpagoMaximo.Text = "0.00"
        Me.txtpagoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(762, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 15)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "PAGO MAXIMO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCajaChica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(868, 173)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtpagoMaximo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtSaldoActual)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtTotalEgresos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSaldoAnterior)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtAperturaImporte)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAperturaFecha)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmbAreaResponsable)
        Me.Controls.Add(Me.txtCodigoUI)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtCajaEjercicio)
        Me.Controls.Add(Me.txtCajaMes)
        Me.Controls.Add(Me.txtCajaNumero)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnLibre)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.UC_ToolBar)
        Me.Name = "frmCajaChica"
        Me.Text = "CAJA CHICA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnLibre As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents UC_ToolBar As MyControlToolBar.UserControlToolBar
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAreaResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigoUI As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCajaEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtCajaMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCajaNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAperturaFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAperturaImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoActual As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtTotalEgresos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents txtpagoMaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
