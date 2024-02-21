<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaDetalleLista
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvElementos = New System.Windows.Forms.DataGridView
        Me.txtNombreIntro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.L1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.L2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.L3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.L4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.L5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CODIGO_TABLA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvElementos
        '
        Me.gvElementos.AllowUserToAddRows = False
        Me.gvElementos.AllowUserToDeleteRows = False
        Me.gvElementos.AllowUserToOrderColumns = True
        Me.gvElementos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvElementos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvElementos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvElementos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.DESCRIPCION, Me.T1, Me.T2, Me.T3, Me.T4, Me.T5, Me.V1, Me.V2, Me.V3, Me.V4, Me.V5, Me.L1, Me.L2, Me.L3, Me.L4, Me.L5, Me.ACTIVO, Me.CODIGO_TABLA, Me.EMPRESA})
        Me.gvElementos.Location = New System.Drawing.Point(12, 57)
        Me.gvElementos.MultiSelect = False
        Me.gvElementos.Name = "gvElementos"
        Me.gvElementos.ReadOnly = True
        Me.gvElementos.RowHeadersWidth = 20
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.OldLace
        Me.gvElementos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvElementos.Size = New System.Drawing.Size(770, 590)
        Me.gvElementos.TabIndex = 2
        '
        'txtNombreIntro
        '
        Me.txtNombreIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtNombreIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreIntro.Location = New System.Drawing.Point(132, 31)
        Me.txtNombreIntro.MaxLength = 100
        Me.txtNombreIntro.Name = "txtNombreIntro"
        Me.txtNombreIntro.Size = New System.Drawing.Size(494, 20)
        Me.txtNombreIntro.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(129, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "DESCRIPCION"
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 31)
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
        Me.Label4.Location = New System.Drawing.Point(9, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CODIGO"
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 74
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 600
        '
        'T1
        '
        Me.T1.DataPropertyName = "T1"
        Me.T1.HeaderText = "TEXTO 1"
        Me.T1.Name = "T1"
        Me.T1.ReadOnly = True
        Me.T1.Visible = False
        Me.T1.Width = 90
        '
        'T2
        '
        Me.T2.DataPropertyName = "T2"
        Me.T2.HeaderText = "TEXTO 2"
        Me.T2.Name = "T2"
        Me.T2.ReadOnly = True
        Me.T2.Visible = False
        Me.T2.Width = 90
        '
        'T3
        '
        Me.T3.DataPropertyName = "T3"
        Me.T3.HeaderText = "TEXTO 3"
        Me.T3.Name = "T3"
        Me.T3.ReadOnly = True
        Me.T3.Visible = False
        Me.T3.Width = 90
        '
        'T4
        '
        Me.T4.DataPropertyName = "T4"
        Me.T4.HeaderText = "TEXTO 4"
        Me.T4.Name = "T4"
        Me.T4.ReadOnly = True
        Me.T4.Visible = False
        Me.T4.Width = 90
        '
        'T5
        '
        Me.T5.DataPropertyName = "T5"
        Me.T5.HeaderText = "TEXTO 5"
        Me.T5.Name = "T5"
        Me.T5.ReadOnly = True
        Me.T5.Visible = False
        Me.T5.Width = 90
        '
        'V1
        '
        Me.V1.DataPropertyName = "V1"
        Me.V1.HeaderText = "VALOR 1"
        Me.V1.Name = "V1"
        Me.V1.ReadOnly = True
        Me.V1.Visible = False
        Me.V1.Width = 90
        '
        'V2
        '
        Me.V2.DataPropertyName = "V2"
        Me.V2.HeaderText = "VALOR 2"
        Me.V2.Name = "V2"
        Me.V2.ReadOnly = True
        Me.V2.Visible = False
        Me.V2.Width = 90
        '
        'V3
        '
        Me.V3.DataPropertyName = "V3"
        Me.V3.HeaderText = "VALOR 3"
        Me.V3.Name = "V3"
        Me.V3.ReadOnly = True
        Me.V3.Visible = False
        Me.V3.Width = 90
        '
        'V4
        '
        Me.V4.DataPropertyName = "V4"
        Me.V4.HeaderText = "VALOR 4"
        Me.V4.Name = "V4"
        Me.V4.ReadOnly = True
        Me.V4.Visible = False
        Me.V4.Width = 90
        '
        'V5
        '
        Me.V5.DataPropertyName = "V5"
        Me.V5.HeaderText = "VALOR 5"
        Me.V5.Name = "V5"
        Me.V5.ReadOnly = True
        Me.V5.Visible = False
        Me.V5.Width = 90
        '
        'L1
        '
        Me.L1.DataPropertyName = "L1"
        Me.L1.FalseValue = "0"
        Me.L1.HeaderText = "LOGICO 1"
        Me.L1.Name = "L1"
        Me.L1.ReadOnly = True
        Me.L1.TrueValue = "1"
        Me.L1.Visible = False
        Me.L1.Width = 71
        '
        'L2
        '
        Me.L2.DataPropertyName = "L2"
        Me.L2.FalseValue = "0"
        Me.L2.HeaderText = "LOGICO 2"
        Me.L2.Name = "L2"
        Me.L2.ReadOnly = True
        Me.L2.TrueValue = "1"
        Me.L2.Visible = False
        Me.L2.Width = 71
        '
        'L3
        '
        Me.L3.DataPropertyName = "L3"
        Me.L3.FalseValue = "0"
        Me.L3.HeaderText = "LOGICO 3"
        Me.L3.Name = "L3"
        Me.L3.ReadOnly = True
        Me.L3.TrueValue = "1"
        Me.L3.Visible = False
        Me.L3.Width = 71
        '
        'L4
        '
        Me.L4.DataPropertyName = "L4"
        Me.L4.FalseValue = "0"
        Me.L4.HeaderText = "LOGICO 4"
        Me.L4.Name = "L4"
        Me.L4.ReadOnly = True
        Me.L4.TrueValue = "1"
        Me.L4.Visible = False
        Me.L4.Width = 71
        '
        'L5
        '
        Me.L5.DataPropertyName = "L5"
        Me.L5.FalseValue = "0"
        Me.L5.HeaderText = "LOGICO 5"
        Me.L5.Name = "L5"
        Me.L5.ReadOnly = True
        Me.L5.TrueValue = "1"
        Me.L5.Visible = False
        Me.L5.Width = 71
        '
        'ACTIVO
        '
        Me.ACTIVO.DataPropertyName = "ACTIVO"
        Me.ACTIVO.FalseValue = "INA"
        Me.ACTIVO.HeaderText = "ACTIVO"
        Me.ACTIVO.Name = "ACTIVO"
        Me.ACTIVO.ReadOnly = True
        Me.ACTIVO.TrueValue = "ACT"
        Me.ACTIVO.Width = 52
        '
        'CODIGO_TABLA
        '
        Me.CODIGO_TABLA.DataPropertyName = "CODIGO_TABLA"
        Me.CODIGO_TABLA.HeaderText = "CODIGO_TABLA"
        Me.CODIGO_TABLA.Name = "CODIGO_TABLA"
        Me.CODIGO_TABLA.ReadOnly = True
        Me.CODIGO_TABLA.Visible = False
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'frmTablaDetalleLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 659)
        Me.Controls.Add(Me.txtNombreIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvElementos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTablaDetalleLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISTA DE ELEMENTOS"
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvElementos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents L1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents L2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents L3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents L4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents L5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ACTIVO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CODIGO_TABLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
