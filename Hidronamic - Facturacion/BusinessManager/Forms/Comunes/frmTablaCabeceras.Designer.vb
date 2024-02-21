<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaCabeceras
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.gvTablas = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_T1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_T2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_T3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_T4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_T5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_V1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_V2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_V3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_V4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_V5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_L1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_L2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_L3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_L4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TITULO_L5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NECESIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.gvTablas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(800, 36)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbEmpresa)
        Me.Panel.Controls.Add(Me.gvTablas)
        Me.Panel.Size = New System.Drawing.Size(800, 511)
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(429, 18)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "EMPRESA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.Color.Azure
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 41)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(429, 21)
        Me.cmbEmpresa.TabIndex = 124
        Me.cmbEmpresa.TabStop = False
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'gvTablas
        '
        Me.gvTablas.AllowUserToAddRows = False
        Me.gvTablas.AllowUserToDeleteRows = False
        Me.gvTablas.AllowUserToOrderColumns = True
        Me.gvTablas.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvTablas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvTablas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.DESCRIPCION, Me.TITULO_T1, Me.TITULO_T2, Me.TITULO_T3, Me.TITULO_T4, Me.TITULO_T5, Me.TITULO_V1, Me.TITULO_V2, Me.TITULO_V3, Me.TITULO_V4, Me.TITULO_V5, Me.TITULO_L1, Me.TITULO_L2, Me.TITULO_L3, Me.TITULO_L4, Me.TITULO_L5, Me.ACTIVO, Me.NECESIDAD, Me.EMPRESA})
        Me.gvTablas.Location = New System.Drawing.Point(15, 68)
        Me.gvTablas.MultiSelect = False
        Me.gvTablas.Name = "gvTablas"
        Me.gvTablas.ReadOnly = True
        Me.gvTablas.RowHeadersWidth = 20
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.OldLace
        Me.gvTablas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gvTablas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvTablas.Size = New System.Drawing.Size(765, 430)
        Me.gvTablas.TabIndex = 122
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 150
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 250
        '
        'TITULO_T1
        '
        Me.TITULO_T1.DataPropertyName = "TITULO_T1"
        Me.TITULO_T1.HeaderText = "TITULO T1"
        Me.TITULO_T1.Name = "TITULO_T1"
        Me.TITULO_T1.ReadOnly = True
        Me.TITULO_T1.Width = 85
        '
        'TITULO_T2
        '
        Me.TITULO_T2.DataPropertyName = "TITULO_T2"
        Me.TITULO_T2.HeaderText = "TITULO T2"
        Me.TITULO_T2.Name = "TITULO_T2"
        Me.TITULO_T2.ReadOnly = True
        Me.TITULO_T2.Width = 85
        '
        'TITULO_T3
        '
        Me.TITULO_T3.DataPropertyName = "TITULO_T3"
        Me.TITULO_T3.HeaderText = "TITULO T3"
        Me.TITULO_T3.Name = "TITULO_T3"
        Me.TITULO_T3.ReadOnly = True
        Me.TITULO_T3.Width = 85
        '
        'TITULO_T4
        '
        Me.TITULO_T4.DataPropertyName = "TITULO_T4"
        Me.TITULO_T4.HeaderText = "TITULO T4"
        Me.TITULO_T4.Name = "TITULO_T4"
        Me.TITULO_T4.ReadOnly = True
        Me.TITULO_T4.Width = 85
        '
        'TITULO_T5
        '
        Me.TITULO_T5.DataPropertyName = "TITULO_T5"
        Me.TITULO_T5.HeaderText = "TITULO T5"
        Me.TITULO_T5.Name = "TITULO_T5"
        Me.TITULO_T5.ReadOnly = True
        Me.TITULO_T5.Width = 85
        '
        'TITULO_V1
        '
        Me.TITULO_V1.DataPropertyName = "TITULO_V1"
        Me.TITULO_V1.HeaderText = "TITULO V1"
        Me.TITULO_V1.Name = "TITULO_V1"
        Me.TITULO_V1.ReadOnly = True
        Me.TITULO_V1.Width = 85
        '
        'TITULO_V2
        '
        Me.TITULO_V2.DataPropertyName = "TITULO_V2"
        Me.TITULO_V2.HeaderText = "TITULO V2"
        Me.TITULO_V2.Name = "TITULO_V2"
        Me.TITULO_V2.ReadOnly = True
        Me.TITULO_V2.Width = 85
        '
        'TITULO_V3
        '
        Me.TITULO_V3.DataPropertyName = "TITULO_V3"
        Me.TITULO_V3.HeaderText = "TITULO V3"
        Me.TITULO_V3.Name = "TITULO_V3"
        Me.TITULO_V3.ReadOnly = True
        Me.TITULO_V3.Width = 85
        '
        'TITULO_V4
        '
        Me.TITULO_V4.DataPropertyName = "TITULO_V4"
        Me.TITULO_V4.HeaderText = "TITULO V4"
        Me.TITULO_V4.Name = "TITULO_V4"
        Me.TITULO_V4.ReadOnly = True
        Me.TITULO_V4.Width = 85
        '
        'TITULO_V5
        '
        Me.TITULO_V5.DataPropertyName = "TITULO_V5"
        Me.TITULO_V5.HeaderText = "TITULO V5"
        Me.TITULO_V5.Name = "TITULO_V5"
        Me.TITULO_V5.ReadOnly = True
        Me.TITULO_V5.Width = 85
        '
        'TITULO_L1
        '
        Me.TITULO_L1.DataPropertyName = "TITULO_L1"
        Me.TITULO_L1.HeaderText = "TITULO L1"
        Me.TITULO_L1.Name = "TITULO_L1"
        Me.TITULO_L1.ReadOnly = True
        '
        'TITULO_L2
        '
        Me.TITULO_L2.DataPropertyName = "TITULO_L2"
        Me.TITULO_L2.HeaderText = "TITULO L2"
        Me.TITULO_L2.Name = "TITULO_L2"
        Me.TITULO_L2.ReadOnly = True
        '
        'TITULO_L3
        '
        Me.TITULO_L3.DataPropertyName = "TITULO_L3"
        Me.TITULO_L3.HeaderText = "TITULO L3"
        Me.TITULO_L3.Name = "TITULO_L3"
        Me.TITULO_L3.ReadOnly = True
        '
        'TITULO_L4
        '
        Me.TITULO_L4.DataPropertyName = "TITULO_L4"
        Me.TITULO_L4.HeaderText = "TITULO L4"
        Me.TITULO_L4.Name = "TITULO_L4"
        Me.TITULO_L4.ReadOnly = True
        '
        'TITULO_L5
        '
        Me.TITULO_L5.DataPropertyName = "TITULO_L5"
        Me.TITULO_L5.HeaderText = "TITULO L5"
        Me.TITULO_L5.Name = "TITULO_L5"
        Me.TITULO_L5.ReadOnly = True
        '
        'ACTIVO
        '
        Me.ACTIVO.DataPropertyName = "ACTIVO"
        Me.ACTIVO.HeaderText = "ACTIVO"
        Me.ACTIVO.Name = "ACTIVO"
        Me.ACTIVO.ReadOnly = True
        '
        'NECESIDAD
        '
        Me.NECESIDAD.DataPropertyName = "NECESIDAD"
        Me.NECESIDAD.HeaderText = "NECESIDAD"
        Me.NECESIDAD.Name = "NECESIDAD"
        Me.NECESIDAD.ReadOnly = True
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(492, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(288, 20)
        Me.Label21.TabIndex = 178
        Me.Label21.Text = "MANTENIMIENTO DE TABLAS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTablaCabeceras
        '
        Me.ClientSize = New System.Drawing.Size(800, 547)
        Me.Name = "frmTablaCabeceras"
        Me.Text = " MANTENIMIENTO DE TABLAS"
        Me.Panel.ResumeLayout(False)
        CType(Me.gvTablas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents gvTablas As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_T1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_T2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_T3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_T4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_T5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_V1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_V2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_V3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_V4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_V5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_L1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_L2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_L3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_L4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TITULO_L5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTIVO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NECESIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
