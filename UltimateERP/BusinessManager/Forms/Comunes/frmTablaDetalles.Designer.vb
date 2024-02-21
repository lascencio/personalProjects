<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablaDetalles
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbTablas = New System.Windows.Forms.ComboBox()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gvElementos = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.L1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.L2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.L3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.L4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.L5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CODIGO_TABLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(941, 54)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.cmbTablas)
        Me.Panel.Controls.Add(Me.cmbEmpresa)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.gvElementos)
        Me.Panel.Size = New System.Drawing.Size(941, 513)
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(640, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(288, 20)
        Me.Label21.TabIndex = 185
        Me.Label21.Text = "MANTENIMIENTO DE ELEMENTOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTablas
        '
        Me.cmbTablas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTablas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTablas.BackColor = System.Drawing.Color.Azure
        Me.cmbTablas.DisplayMember = "DESCRIPCION"
        Me.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTablas.FormattingEnabled = True
        Me.cmbTablas.Location = New System.Drawing.Point(22, 86)
        Me.cmbTablas.Name = "cmbTablas"
        Me.cmbTablas.Size = New System.Drawing.Size(376, 21)
        Me.cmbTablas.TabIndex = 180
        Me.cmbTablas.ValueMember = "CODIGO"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.Color.Azure
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(22, 40)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(429, 21)
        Me.cmbEmpresa.TabIndex = 184
        Me.cmbEmpresa.TabStop = False
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(429, 18)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "EMPRESA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 18)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "TABLA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvElementos
        '
        Me.gvElementos.AllowUserToAddRows = False
        Me.gvElementos.AllowUserToDeleteRows = False
        Me.gvElementos.AllowUserToOrderColumns = True
        Me.gvElementos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvElementos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvElementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvElementos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
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
        Me.gvElementos.Location = New System.Drawing.Point(22, 113)
        Me.gvElementos.MultiSelect = False
        Me.gvElementos.Name = "gvElementos"
        Me.gvElementos.ReadOnly = True
        Me.gvElementos.RowHeadersWidth = 20
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.OldLace
        Me.gvElementos.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvElementos.Size = New System.Drawing.Size(906, 384)
        Me.gvElementos.TabIndex = 181
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
        Me.DESCRIPCION.Width = 105
        '
        'T1
        '
        Me.T1.DataPropertyName = "T1"
        Me.T1.HeaderText = "TEXTO 1"
        Me.T1.Name = "T1"
        Me.T1.ReadOnly = True
        Me.T1.Width = 77
        '
        'T2
        '
        Me.T2.DataPropertyName = "T2"
        Me.T2.HeaderText = "TEXTO 2"
        Me.T2.Name = "T2"
        Me.T2.ReadOnly = True
        Me.T2.Width = 77
        '
        'T3
        '
        Me.T3.DataPropertyName = "T3"
        Me.T3.HeaderText = "TEXTO 3"
        Me.T3.Name = "T3"
        Me.T3.ReadOnly = True
        Me.T3.Width = 77
        '
        'T4
        '
        Me.T4.DataPropertyName = "T4"
        Me.T4.HeaderText = "TEXTO 4"
        Me.T4.Name = "T4"
        Me.T4.ReadOnly = True
        Me.T4.Width = 77
        '
        'T5
        '
        Me.T5.DataPropertyName = "T5"
        Me.T5.HeaderText = "TEXTO 5"
        Me.T5.Name = "T5"
        Me.T5.ReadOnly = True
        Me.T5.Width = 77
        '
        'V1
        '
        Me.V1.DataPropertyName = "V1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.V1.DefaultCellStyle = DataGridViewCellStyle3
        Me.V1.HeaderText = "VALOR 1"
        Me.V1.Name = "V1"
        Me.V1.ReadOnly = True
        Me.V1.Width = 77
        '
        'V2
        '
        Me.V2.DataPropertyName = "V2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.V2.DefaultCellStyle = DataGridViewCellStyle4
        Me.V2.HeaderText = "VALOR 2"
        Me.V2.Name = "V2"
        Me.V2.ReadOnly = True
        Me.V2.Width = 77
        '
        'V3
        '
        Me.V3.DataPropertyName = "V3"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.V3.DefaultCellStyle = DataGridViewCellStyle5
        Me.V3.HeaderText = "VALOR 3"
        Me.V3.Name = "V3"
        Me.V3.ReadOnly = True
        Me.V3.Width = 77
        '
        'V4
        '
        Me.V4.DataPropertyName = "V4"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.V4.DefaultCellStyle = DataGridViewCellStyle6
        Me.V4.HeaderText = "VALOR 4"
        Me.V4.Name = "V4"
        Me.V4.ReadOnly = True
        Me.V4.Width = 77
        '
        'V5
        '
        Me.V5.DataPropertyName = "V5"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.V5.DefaultCellStyle = DataGridViewCellStyle7
        Me.V5.HeaderText = "VALOR 5"
        Me.V5.Name = "V5"
        Me.V5.ReadOnly = True
        Me.V5.Width = 77
        '
        'L1
        '
        Me.L1.DataPropertyName = "L1"
        Me.L1.FalseValue = "0"
        Me.L1.HeaderText = "LOGICO 1"
        Me.L1.Name = "L1"
        Me.L1.ReadOnly = True
        Me.L1.TrueValue = "1"
        Me.L1.Width = 62
        '
        'L2
        '
        Me.L2.DataPropertyName = "L2"
        Me.L2.FalseValue = "0"
        Me.L2.HeaderText = "LOGICO 2"
        Me.L2.Name = "L2"
        Me.L2.ReadOnly = True
        Me.L2.TrueValue = "1"
        Me.L2.Width = 62
        '
        'L3
        '
        Me.L3.DataPropertyName = "L3"
        Me.L3.FalseValue = "0"
        Me.L3.HeaderText = "LOGICO 3"
        Me.L3.Name = "L3"
        Me.L3.ReadOnly = True
        Me.L3.TrueValue = "1"
        Me.L3.Width = 62
        '
        'L4
        '
        Me.L4.DataPropertyName = "L4"
        Me.L4.FalseValue = "0"
        Me.L4.HeaderText = "LOGICO 4"
        Me.L4.Name = "L4"
        Me.L4.ReadOnly = True
        Me.L4.TrueValue = "1"
        Me.L4.Width = 62
        '
        'L5
        '
        Me.L5.DataPropertyName = "L5"
        Me.L5.FalseValue = "0"
        Me.L5.HeaderText = "LOGICO 5"
        Me.L5.Name = "L5"
        Me.L5.ReadOnly = True
        Me.L5.TrueValue = "1"
        Me.L5.Width = 62
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
        Me.CODIGO_TABLA.Width = 114
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        Me.EMPRESA.Width = 84
        '
        'frmTablaDetalles
        '
        Me.ClientSize = New System.Drawing.Size(941, 567)
        Me.Name = "frmTablaDetalles"
        Me.Text = "MANTENIMIENTO DE ELEMENTOS"
        Me.Panel.ResumeLayout(False)
        CType(Me.gvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbTablas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvElementos As System.Windows.Forms.DataGridView
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
