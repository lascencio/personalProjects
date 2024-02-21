<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCuenta
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
        Me.rvEstadoCuenta = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipoPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'rvEstadoCuenta
        '
        Me.rvEstadoCuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvEstadoCuenta.LocalReport.ReportEmbeddedResource = "BusinessManager.rptPrestamoEstadoCuentaCompacto.rdlc"
        Me.rvEstadoCuenta.Location = New System.Drawing.Point(0, 103)
        Me.rvEstadoCuenta.Name = "rvEstadoCuenta"
        Me.rvEstadoCuenta.Size = New System.Drawing.Size(815, 529)
        Me.rvEstadoCuenta.TabIndex = 1
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.cmbFormaPago)
        Me.panPrincipal.Controls.Add(Me.Label19)
        Me.panPrincipal.Controls.Add(Me.cmbTipoMoneda)
        Me.panPrincipal.Controls.Add(Me.Label8)
        Me.panPrincipal.Controls.Add(Me.cmbTipoPrestamo)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.cmbEstado)
        Me.panPrincipal.Controls.Add(Me.Label5)
        Me.panPrincipal.Controls.Add(Me.cmbPrestamo)
        Me.panPrincipal.Controls.Add(Me.cmbDocumentoTipo)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.txtRazonSocial)
        Me.panPrincipal.Controls.Add(Me.txtDocumentoNumero)
        Me.panPrincipal.Controls.Add(Me.Label15)
        Me.panPrincipal.Controls.Add(Me.btnRefrescar)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(815, 103)
        Me.panPrincipal.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(433, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 18)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "FORMA DE PAGO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPago.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Location = New System.Drawing.Point(433, 75)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPago.TabIndex = 82
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(575, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "MONEDA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.Enabled = False
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(575, 75)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 83
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(233, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 18)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "TIPO DE PRESTAMO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.Enabled = False
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(233, 75)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoPrestamo.TabIndex = 81
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ESTADO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEstado
        '
        Me.cmbEstado.BackColor = System.Drawing.Color.Azure
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"TODOS", "VIGENTES", "CANCELADOS"})
        Me.cmbEstado.Location = New System.Drawing.Point(12, 75)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(107, 21)
        Me.cmbEstado.TabIndex = 1
        Me.cmbEstado.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(120, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 18)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "PRESTAMO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPrestamo
        '
        Me.cmbPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbPrestamo.DisplayMember = "PRESTAMO"
        Me.cmbPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPrestamo.FormattingEnabled = True
        Me.cmbPrestamo.Location = New System.Drawing.Point(120, 75)
        Me.cmbPrestamo.Name = "cmbPrestamo"
        Me.cmbPrestamo.Size = New System.Drawing.Size(107, 21)
        Me.cmbPrestamo.TabIndex = 2
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
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
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(12, 28)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 4
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(150, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(653, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "NOMBRE / RAZON SOCIAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(150, 28)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(653, 21)
        Me.txtRazonSocial.TabIndex = 5
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(69, 28)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(707, 73)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(96, 23)
        Me.btnRefrescar.TabIndex = 3
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'frmEstadoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 632)
        Me.Controls.Add(Me.rvEstadoCuenta)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstadoCuenta"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADO DE CUENTA"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvEstadoCuenta As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox
End Class
