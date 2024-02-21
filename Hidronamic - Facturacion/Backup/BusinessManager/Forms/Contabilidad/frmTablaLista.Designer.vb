<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaLista
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
        Me.gvElementos = New System.Windows.Forms.DataGridView
        Me.tcod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tclave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tdescri = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.thora = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CODIGO"
        '
        'gvElementos
        '
        Me.gvElementos.AllowUserToAddRows = False
        Me.gvElementos.AllowUserToDeleteRows = False
        Me.gvElementos.AllowUserToOrderColumns = True
        Me.gvElementos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvElementos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvElementos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tcod, Me.tclave, Me.tdescri, Me.tdate, Me.thora})
        Me.gvElementos.Location = New System.Drawing.Point(12, 58)
        Me.gvElementos.MultiSelect = False
        Me.gvElementos.Name = "gvElementos"
        Me.gvElementos.ReadOnly = True
        Me.gvElementos.RowHeadersVisible = False
        Me.gvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvElementos.Size = New System.Drawing.Size(898, 572)
        Me.gvElementos.TabIndex = 7
        Me.gvElementos.TabStop = False
        '
        'tcod
        '
        Me.tcod.DataPropertyName = "tcod"
        Me.tcod.HeaderText = "tcod"
        Me.tcod.Name = "tcod"
        Me.tcod.ReadOnly = True
        Me.tcod.Visible = False
        '
        'tclave
        '
        Me.tclave.DataPropertyName = "tclave"
        Me.tclave.HeaderText = "CODIGO"
        Me.tclave.Name = "tclave"
        Me.tclave.ReadOnly = True
        Me.tclave.Width = 115
        '
        'tdescri
        '
        Me.tdescri.DataPropertyName = "tdescri"
        Me.tdescri.HeaderText = "DESCRIPCION "
        Me.tdescri.Name = "tdescri"
        Me.tdescri.ReadOnly = True
        Me.tdescri.Width = 760
        '
        'tdate
        '
        Me.tdate.DataPropertyName = "tdate"
        Me.tdate.HeaderText = "tdate"
        Me.tdate.Name = "tdate"
        Me.tdate.ReadOnly = True
        Me.tdate.Visible = False
        '
        'thora
        '
        Me.thora.DataPropertyName = "thora"
        Me.thora.HeaderText = "thora"
        Me.thora.Name = "thora"
        Me.thora.ReadOnly = True
        Me.thora.Visible = False
        '
        'frmTablaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 642)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvElementos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTablaLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE ELEMENTOS"
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gvElementos As System.Windows.Forms.DataGridView
    Friend WithEvents tcod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tclave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdescri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thora As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
