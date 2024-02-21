<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoCompuesto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvComponentes = New System.Windows.Forms.DataGridView
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtComponente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtComponenteDescripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCompuestoDescripcion = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtCompuesto = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel.SuspendLayout()
        CType(Me.gvComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.gvComponentes)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtComponente)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtComponenteDescripcion)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtCompuestoDescripcion)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtCompuesto)
        Me.Panel.Size = New System.Drawing.Size(747, 384)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'gvComponentes
        '
        Me.gvComponentes.AllowUserToAddRows = False
        Me.gvComponentes.AllowUserToDeleteRows = False
        Me.gvComponentes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvComponentes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvComponentes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvComponentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PRODUCTO, Me.DESCRIPCION, Me.CANTIDAD})
        Me.gvComponentes.EnableHeadersVisualStyles = False
        Me.gvComponentes.Location = New System.Drawing.Point(12, 148)
        Me.gvComponentes.MultiSelect = False
        Me.gvComponentes.Name = "gvComponentes"
        Me.gvComponentes.ReadOnly = True
        Me.gvComponentes.RowHeadersVisible = False
        Me.gvComponentes.RowHeadersWidth = 20
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.OldLace
        Me.gvComponentes.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gvComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvComponentes.Size = New System.Drawing.Size(718, 221)
        Me.gvComponentes.TabIndex = 5
        Me.gvComponentes.TabStop = False
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "COMPONENTE"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DECRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 535
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle3
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 70
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(9, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(196, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "DETALLES DEL COMPONENTES"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(650, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "CANTIDAD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.Honeydew
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(650, 121)
        Me.txtCantidad.MaxLength = 7
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(80, 21)
        Me.txtCantidad.TabIndex = 4
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "COMPONENTE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComponente
        '
        Me.txtComponente.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComponente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComponente.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComponente.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComponente.Location = New System.Drawing.Point(12, 121)
        Me.txtComponente.MaxLength = 8
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(100, 21)
        Me.txtComponente.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Chocolate
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(113, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(536, 18)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "DESCRIPCION"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComponenteDescripcion
        '
        Me.txtComponenteDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtComponenteDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComponenteDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComponenteDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComponenteDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComponenteDescripcion.Location = New System.Drawing.Point(113, 121)
        Me.txtComponenteDescripcion.MaxLength = 50
        Me.txtComponenteDescripcion.Name = "txtComponenteDescripcion"
        Me.txtComponenteDescripcion.ReadOnly = True
        Me.txtComponenteDescripcion.Size = New System.Drawing.Size(536, 21)
        Me.txtComponenteDescripcion.TabIndex = 3
        Me.txtComponenteDescripcion.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(105, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(625, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "DESCRIPCION AMPLIADA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompuestoDescripcion
        '
        Me.txtCompuestoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtCompuestoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompuestoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompuestoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompuestoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCompuestoDescripcion.Location = New System.Drawing.Point(105, 48)
        Me.txtCompuestoDescripcion.MaxLength = 200
        Me.txtCompuestoDescripcion.Name = "txtCompuestoDescripcion"
        Me.txtCompuestoDescripcion.ReadOnly = True
        Me.txtCompuestoDescripcion.Size = New System.Drawing.Size(625, 21)
        Me.txtCompuestoDescripcion.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Chocolate
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 29)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(92, 18)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "COMPUESTO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompuesto
        '
        Me.txtCompuesto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCompuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompuesto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCompuesto.Location = New System.Drawing.Point(12, 48)
        Me.txtCompuesto.MaxLength = 8
        Me.txtCompuesto.Name = "txtCompuesto"
        Me.txtCompuesto.Size = New System.Drawing.Size(92, 21)
        Me.txtCompuesto.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(334, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(400, 20)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "PRODUCTO COMPUESTO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmProductoCompuesto
        '
        Me.ClientSize = New System.Drawing.Size(747, 420)
        Me.Name = "frmProductoCompuesto"
        Me.Text = " PRODUCTO COMPUESTO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvComponentes As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComponenteDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompuestoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCompuesto As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
