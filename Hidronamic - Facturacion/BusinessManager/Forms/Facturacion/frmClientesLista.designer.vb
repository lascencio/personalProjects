<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNombreCodigoIntro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gvCuentasComerciales = New System.Windows.Forms.DataGridView()
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PREFIJO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreCodigoIntro
        '
        Me.txtNombreCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtNombreCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCodigoIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreCodigoIntro.Location = New System.Drawing.Point(132, 30)
        Me.txtNombreCodigoIntro.MaxLength = 100
        Me.txtNombreCodigoIntro.Name = "txtNombreCodigoIntro"
        Me.txtNombreCodigoIntro.Size = New System.Drawing.Size(663, 21)
        Me.txtNombreCodigoIntro.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(132, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "RAZON SOCIAL"
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 30)
        Me.txtCodigoIntro.MaxLength = 20
        Me.txtCodigoIntro.Name = "txtCodigoIntro"
        Me.txtCodigoIntro.Size = New System.Drawing.Size(114, 21)
        Me.txtCodigoIntro.TabIndex = 5
        Me.txtCodigoIntro.Tag = "EC"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "RUC/DNI"
        '
        'gvCuentasComerciales
        '
        Me.gvCuentasComerciales.AllowUserToAddRows = False
        Me.gvCuentasComerciales.AllowUserToDeleteRows = False
        Me.gvCuentasComerciales.AllowUserToOrderColumns = True
        Me.gvCuentasComerciales.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuentasComerciales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvCuentasComerciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuentasComerciales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CUENTA_COMERCIAL, Me.RAZON_SOCIAL, Me.PREFIJO})
        Me.gvCuentasComerciales.Location = New System.Drawing.Point(12, 56)
        Me.gvCuentasComerciales.MultiSelect = False
        Me.gvCuentasComerciales.Name = "gvCuentasComerciales"
        Me.gvCuentasComerciales.ReadOnly = True
        Me.gvCuentasComerciales.RowHeadersVisible = False
        Me.gvCuentasComerciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuentasComerciales.Size = New System.Drawing.Size(974, 572)
        Me.gvCuentasComerciales.TabIndex = 7
        Me.gvCuentasComerciales.TabStop = False
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "RUC"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "RAZON SOCIAL"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 780
        '
        'PREFIJO
        '
        Me.PREFIJO.DataPropertyName = "PREFIJO"
        Me.PREFIJO.HeaderText = "PREFIJO"
        Me.PREFIJO.Name = "PREFIJO"
        Me.PREFIJO.ReadOnly = True
        Me.PREFIJO.Width = 50
        '
        'frmClientesLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 641)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvCuentasComerciales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientesLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE CLIENTES"
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gvCuentasComerciales As System.Windows.Forms.DataGridView
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PREFIJO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
