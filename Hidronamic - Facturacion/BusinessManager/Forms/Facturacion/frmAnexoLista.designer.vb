<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnexoLista
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNombreCodigoIntro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gvAnexos = New System.Windows.Forms.DataGridView()
        Me.acodane = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adesane = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.avanexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arefane = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvAnexos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtNombreCodigoIntro.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(129, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "DESCRIPCION DEL ANEXO"
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
        Me.txtCodigoIntro.TabIndex = 0
        Me.txtCodigoIntro.Tag = "EC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ANEXO"
        '
        'gvAnexos
        '
        Me.gvAnexos.AllowUserToAddRows = False
        Me.gvAnexos.AllowUserToDeleteRows = False
        Me.gvAnexos.AllowUserToOrderColumns = True
        Me.gvAnexos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAnexos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvAnexos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAnexos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acodane, Me.adesane, Me.avanexo, Me.arefane, Me.aestado})
        Me.gvAnexos.Location = New System.Drawing.Point(12, 58)
        Me.gvAnexos.MultiSelect = False
        Me.gvAnexos.Name = "gvAnexos"
        Me.gvAnexos.ReadOnly = True
        Me.gvAnexos.RowHeadersVisible = False
        Me.gvAnexos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvAnexos.Size = New System.Drawing.Size(898, 572)
        Me.gvAnexos.TabIndex = 2
        Me.gvAnexos.TabStop = False
        '
        'acodane
        '
        Me.acodane.DataPropertyName = "acodane"
        Me.acodane.HeaderText = "ANEXO"
        Me.acodane.Name = "acodane"
        Me.acodane.ReadOnly = True
        Me.acodane.Width = 140
        '
        'adesane
        '
        Me.adesane.DataPropertyName = "adesane"
        Me.adesane.HeaderText = "DESCRIPCION DEL ANEXO"
        Me.adesane.Name = "adesane"
        Me.adesane.ReadOnly = True
        Me.adesane.Width = 640
        '
        'avanexo
        '
        Me.avanexo.DataPropertyName = "avanexo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.avanexo.DefaultCellStyle = DataGridViewCellStyle2
        Me.avanexo.HeaderText = "TIPO"
        Me.avanexo.Name = "avanexo"
        Me.avanexo.ReadOnly = True
        Me.avanexo.Width = 30
        '
        'arefane
        '
        Me.arefane.DataPropertyName = "arefane"
        Me.arefane.HeaderText = "arefane"
        Me.arefane.Name = "arefane"
        Me.arefane.ReadOnly = True
        Me.arefane.Visible = False
        '
        'aestado
        '
        Me.aestado.DataPropertyName = "aestado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.aestado.DefaultCellStyle = DataGridViewCellStyle3
        Me.aestado.HeaderText = "ESTADO"
        Me.aestado.Name = "aestado"
        Me.aestado.ReadOnly = True
        Me.aestado.Width = 60
        '
        'frmAnexoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 642)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvAnexos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnexoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE ANEXOS"
        CType(Me.gvAnexos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gvAnexos As System.Windows.Forms.DataGridView
    Friend WithEvents acodane As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adesane As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents avanexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents arefane As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aestado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
