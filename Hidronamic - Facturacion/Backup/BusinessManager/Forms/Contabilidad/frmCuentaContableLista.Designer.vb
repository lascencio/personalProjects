<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaContableLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtNombreCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.gvCuentas = New System.Windows.Forms.DataGridView
        Me.pcuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pdescri = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pvanexo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pmonref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pctacar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pctaabo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pvcencos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pvregcta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pvtipcta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pvarea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pestado = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreCodigoIntro
        '
        Me.txtNombreCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtNombreCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreCodigoIntro.Location = New System.Drawing.Point(132, 32)
        Me.txtNombreCodigoIntro.MaxLength = 100
        Me.txtNombreCodigoIntro.Name = "txtNombreCodigoIntro"
        Me.txtNombreCodigoIntro.Size = New System.Drawing.Size(663, 20)
        Me.txtNombreCodigoIntro.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(129, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "DESCRIPCION"
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 32)
        Me.txtCodigoIntro.MaxLength = 20
        Me.txtCodigoIntro.Name = "txtCodigoIntro"
        Me.txtCodigoIntro.Size = New System.Drawing.Size(114, 20)
        Me.txtCodigoIntro.TabIndex = 5
        Me.txtCodigoIntro.Tag = "EC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CUENTA CONTABLE"
        '
        'gvCuentas
        '
        Me.gvCuentas.AllowUserToAddRows = False
        Me.gvCuentas.AllowUserToDeleteRows = False
        Me.gvCuentas.AllowUserToOrderColumns = True
        Me.gvCuentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcuenta, Me.pdescri, Me.pvanexo, Me.pmonref, Me.pctacar, Me.pctaabo, Me.pvcencos, Me.pvregcta, Me.pvtipcta, Me.pvarea, Me.pestado})
        Me.gvCuentas.Location = New System.Drawing.Point(12, 58)
        Me.gvCuentas.MultiSelect = False
        Me.gvCuentas.Name = "gvCuentas"
        Me.gvCuentas.ReadOnly = True
        Me.gvCuentas.RowHeadersVisible = False
        Me.gvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuentas.Size = New System.Drawing.Size(898, 572)
        Me.gvCuentas.TabIndex = 7
        Me.gvCuentas.TabStop = False
        '
        'pcuenta
        '
        Me.pcuenta.DataPropertyName = "pcuenta"
        Me.pcuenta.HeaderText = "CUENTA"
        Me.pcuenta.Name = "pcuenta"
        Me.pcuenta.ReadOnly = True
        Me.pcuenta.Width = 90
        '
        'pdescri
        '
        Me.pdescri.DataPropertyName = "pdescri"
        Me.pdescri.HeaderText = "DESCRIPCION "
        Me.pdescri.Name = "pdescri"
        Me.pdescri.ReadOnly = True
        Me.pdescri.Width = 740
        '
        'pvanexo
        '
        Me.pvanexo.DataPropertyName = "pvanexo"
        Me.pvanexo.HeaderText = "pvanexo"
        Me.pvanexo.Name = "pvanexo"
        Me.pvanexo.ReadOnly = True
        Me.pvanexo.Visible = False
        '
        'pmonref
        '
        Me.pmonref.DataPropertyName = "pmonref"
        Me.pmonref.HeaderText = "pmonref"
        Me.pmonref.Name = "pmonref"
        Me.pmonref.ReadOnly = True
        Me.pmonref.Visible = False
        '
        'pctacar
        '
        Me.pctacar.DataPropertyName = "pctacar"
        Me.pctacar.HeaderText = "pctacar"
        Me.pctacar.Name = "pctacar"
        Me.pctacar.ReadOnly = True
        Me.pctacar.Visible = False
        '
        'pctaabo
        '
        Me.pctaabo.DataPropertyName = "pctaabo"
        Me.pctaabo.HeaderText = "pctaabo"
        Me.pctaabo.Name = "pctaabo"
        Me.pctaabo.ReadOnly = True
        Me.pctaabo.Visible = False
        '
        'pvcencos
        '
        Me.pvcencos.DataPropertyName = "pvcencos"
        Me.pvcencos.HeaderText = "pvcencos"
        Me.pvcencos.Name = "pvcencos"
        Me.pvcencos.ReadOnly = True
        Me.pvcencos.Visible = False
        '
        'pvregcta
        '
        Me.pvregcta.DataPropertyName = "pvregcta"
        Me.pvregcta.HeaderText = "pvregcta"
        Me.pvregcta.Name = "pvregcta"
        Me.pvregcta.ReadOnly = True
        Me.pvregcta.Visible = False
        '
        'pvtipcta
        '
        Me.pvtipcta.DataPropertyName = "pvtipcta"
        Me.pvtipcta.HeaderText = "pvtipcta"
        Me.pvtipcta.Name = "pvtipcta"
        Me.pvtipcta.ReadOnly = True
        Me.pvtipcta.Visible = False
        '
        'pvarea
        '
        Me.pvarea.DataPropertyName = "pvarea"
        Me.pvarea.HeaderText = "pvarea"
        Me.pvarea.Name = "pvarea"
        Me.pvarea.ReadOnly = True
        Me.pvarea.Visible = False
        '
        'pestado
        '
        Me.pestado.DataPropertyName = "pestado"
        Me.pestado.HeaderText = "EST"
        Me.pestado.Name = "pestado"
        Me.pestado.ReadOnly = True
        Me.pestado.Width = 40
        '
        'frmCuentaContableLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 642)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvCuentas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaContableLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE CUENTAS CONTABLES"
        CType(Me.gvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gvCuentas As System.Windows.Forms.DataGridView
    Friend WithEvents pcuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pdescri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pvanexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pmonref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pctacar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pctaabo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pvcencos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pvregcta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pvtipcta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pvarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pestado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
