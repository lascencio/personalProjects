<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotesStockLista
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvLotes = New System.Windows.Forms.DataGridView
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INGRESOS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EGRESOS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STOCKXALMACENBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsStockAlmacen = New BusinessManager.dsStockAlmacen
        CType(Me.gvLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKXALMACENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsStockAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvLotes
        '
        Me.gvLotes.AllowUserToAddRows = False
        Me.gvLotes.AllowUserToDeleteRows = False
        Me.gvLotes.AllowUserToResizeRows = False
        Me.gvLotes.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvLotes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.ALMACEN, Me.PRODUCTO, Me.DESCRIPCION, Me.NUMERO_LOTE, Me.INGRESOS, Me.EGRESOS, Me.STOCK, Me.FECHA_VENCIMIENTO})
        Me.gvLotes.DataSource = Me.STOCKXALMACENBindingSource
        Me.gvLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvLotes.EnableHeadersVisualStyles = False
        Me.gvLotes.Location = New System.Drawing.Point(0, 0)
        Me.gvLotes.MultiSelect = False
        Me.gvLotes.Name = "gvLotes"
        Me.gvLotes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvLotes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvLotes.RowHeadersVisible = False
        Me.gvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvLotes.Size = New System.Drawing.Size(724, 104)
        Me.gvLotes.TabIndex = 3
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'ALMACEN
        '
        Me.ALMACEN.DataPropertyName = "ALMACEN"
        Me.ALMACEN.HeaderText = "ALMACEN"
        Me.ALMACEN.Name = "ALMACEN"
        Me.ALMACEN.ReadOnly = True
        Me.ALMACEN.Visible = False
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 300
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        Me.NUMERO_LOTE.HeaderText = "NRO. LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        '
        'INGRESOS
        '
        Me.INGRESOS.DataPropertyName = "INGRESOS"
        Me.INGRESOS.HeaderText = "INGRESOS"
        Me.INGRESOS.Name = "INGRESOS"
        Me.INGRESOS.ReadOnly = True
        Me.INGRESOS.Visible = False
        '
        'EGRESOS
        '
        Me.EGRESOS.DataPropertyName = "EGRESOS"
        Me.EGRESOS.HeaderText = "EGRESOS"
        Me.EGRESOS.Name = "EGRESOS"
        Me.EGRESOS.ReadOnly = True
        Me.EGRESOS.Visible = False
        '
        'STOCK
        '
        Me.STOCK.DataPropertyName = "STOCK"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.STOCK.DefaultCellStyle = DataGridViewCellStyle2
        Me.STOCK.HeaderText = "STOCK"
        Me.STOCK.Name = "STOCK"
        Me.STOCK.ReadOnly = True
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        '
        'STOCKXALMACENBindingSource
        '
        Me.STOCKXALMACENBindingSource.DataMember = "STOCK_X_ALMACEN"
        Me.STOCKXALMACENBindingSource.DataSource = Me.DsStockAlmacen
        '
        'DsStockAlmacen
        '
        Me.DsStockAlmacen.DataSetName = "dsStockAlmacen"
        Me.DsStockAlmacen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmLotesStockLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 104)
        Me.Controls.Add(Me.gvLotes)
        Me.Cursor = System.Windows.Forms.Cursors.No
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLotesStockLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE LOTES DISPONIBLES"
        CType(Me.gvLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKXALMACENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsStockAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvLotes As System.Windows.Forms.DataGridView
    Friend WithEvents STOCKXALMACENBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsStockAlmacen As BusinessManager.dsStockAlmacen
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INGRESOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EGRESOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
