<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElementoLista
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
        Me.gvElementos = New System.Windows.Forms.DataGridView()
        Me.TABLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ES_VEHICULAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvElementos
        '
        Me.gvElementos.AllowUserToAddRows = False
        Me.gvElementos.AllowUserToDeleteRows = False
        Me.gvElementos.AllowUserToOrderColumns = True
        Me.gvElementos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvElementos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvElementos.ColumnHeadersVisible = False
        Me.gvElementos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TABLA, Me.CODIGO, Me.DESCRIPCION, Me.DESCRIPCION_AMPLIADA, Me.REFERENCIA, Me.ES_VEHICULAR})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvElementos.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvElementos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvElementos.Location = New System.Drawing.Point(0, 0)
        Me.gvElementos.MultiSelect = False
        Me.gvElementos.Name = "gvElementos"
        Me.gvElementos.ReadOnly = True
        Me.gvElementos.RowHeadersVisible = False
        Me.gvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvElementos.Size = New System.Drawing.Size(380, 457)
        Me.gvElementos.TabIndex = 15
        Me.gvElementos.TabStop = False
        '
        'TABLA
        '
        Me.TABLA.DataPropertyName = "TABLA"
        Me.TABLA.HeaderText = "TABLA"
        Me.TABLA.Name = "TABLA"
        Me.TABLA.ReadOnly = True
        Me.TABLA.Visible = False
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Visible = False
        Me.DESCRIPCION.Width = 360
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 250
        '
        'REFERENCIA
        '
        Me.REFERENCIA.DataPropertyName = "REFERENCIA"
        Me.REFERENCIA.HeaderText = "REFERENCIA"
        Me.REFERENCIA.Name = "REFERENCIA"
        Me.REFERENCIA.ReadOnly = True
        Me.REFERENCIA.Visible = False
        '
        'ES_VEHICULAR
        '
        Me.ES_VEHICULAR.DataPropertyName = "ES_VEHICULAR"
        Me.ES_VEHICULAR.HeaderText = "ES_VEHICULAR"
        Me.ES_VEHICULAR.Name = "ES_VEHICULAR"
        Me.ES_VEHICULAR.ReadOnly = True
        Me.ES_VEHICULAR.Visible = False
        '
        'frmElementoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 457)
        Me.Controls.Add(Me.gvElementos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmElementoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ELEMENTOS"
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvElementos As System.Windows.Forms.DataGridView
    Friend WithEvents TABLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ES_VEHICULAR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
