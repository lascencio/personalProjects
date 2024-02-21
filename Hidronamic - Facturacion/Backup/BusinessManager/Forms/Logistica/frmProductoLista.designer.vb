<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductoLista))
        Me.gvProductos = New System.Windows.Forms.DataGridView
        Me.txtNombreCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UNIDAD_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UNIDAD_MEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STOCK_ACTUAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STOCK_COMPROMETIDO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STOCK_TRANSITO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UNIDAD_VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_VALIDA_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_COMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvProductos
        '
        Me.gvProductos.AllowUserToAddRows = False
        Me.gvProductos.AllowUserToDeleteRows = False
        Me.gvProductos.AllowUserToOrderColumns = True
        Me.gvProductos.AllowUserToResizeRows = False
        Me.gvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.ESTADO, Me.UNIDAD_COMPRA, Me.UNIDAD_MEDIDA, Me.STOCK_ACTUAL, Me.STOCK_COMPROMETIDO, Me.STOCK_TRANSITO, Me.UNIDAD_VENTA, Me.INDICA_LOTE, Me.INDICA_VALIDA_STOCK, Me.INDICA_COMPUESTO})
        Me.gvProductos.Location = New System.Drawing.Point(12, 58)
        Me.gvProductos.MultiSelect = False
        Me.gvProductos.Name = "gvProductos"
        Me.gvProductos.ReadOnly = True
        Me.gvProductos.RowHeadersVisible = False
        Me.gvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvProductos.Size = New System.Drawing.Size(898, 489)
        Me.gvProductos.TabIndex = 0
        Me.gvProductos.TabStop = False
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
        Me.txtNombreCodigoIntro.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(129, 16)
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
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 32)
        Me.txtCodigoIntro.MaxLength = 20
        Me.txtCodigoIntro.Name = "txtCodigoIntro"
        Me.txtCodigoIntro.Size = New System.Drawing.Size(114, 20)
        Me.txtCodigoIntro.TabIndex = 1
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
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CODIGO"
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "CODIGO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 80
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 700
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        '
        'UNIDAD_COMPRA
        '
        Me.UNIDAD_COMPRA.DataPropertyName = "UNIDAD_COMPRA"
        Me.UNIDAD_COMPRA.HeaderText = "UNIDAD_COMPRA"
        Me.UNIDAD_COMPRA.Name = "UNIDAD_COMPRA"
        Me.UNIDAD_COMPRA.ReadOnly = True
        Me.UNIDAD_COMPRA.Visible = False
        '
        'UNIDAD_MEDIDA
        '
        Me.UNIDAD_MEDIDA.DataPropertyName = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.HeaderText = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.Name = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.ReadOnly = True
        Me.UNIDAD_MEDIDA.Visible = False
        '
        'STOCK_ACTUAL
        '
        Me.STOCK_ACTUAL.DataPropertyName = "STOCK_ACTUAL"
        Me.STOCK_ACTUAL.HeaderText = "STOCK_ACTUAL"
        Me.STOCK_ACTUAL.Name = "STOCK_ACTUAL"
        Me.STOCK_ACTUAL.ReadOnly = True
        Me.STOCK_ACTUAL.Visible = False
        '
        'STOCK_COMPROMETIDO
        '
        Me.STOCK_COMPROMETIDO.DataPropertyName = "STOCK_COMPROMETIDO"
        Me.STOCK_COMPROMETIDO.HeaderText = "STOCK_COMPROMETIDO"
        Me.STOCK_COMPROMETIDO.Name = "STOCK_COMPROMETIDO"
        Me.STOCK_COMPROMETIDO.ReadOnly = True
        Me.STOCK_COMPROMETIDO.Visible = False
        '
        'STOCK_TRANSITO
        '
        Me.STOCK_TRANSITO.DataPropertyName = "STOCK_TRANSITO"
        Me.STOCK_TRANSITO.HeaderText = "STOCK_TRANSITO"
        Me.STOCK_TRANSITO.Name = "STOCK_TRANSITO"
        Me.STOCK_TRANSITO.ReadOnly = True
        Me.STOCK_TRANSITO.Visible = False
        '
        'UNIDAD_VENTA
        '
        Me.UNIDAD_VENTA.DataPropertyName = "UNIDAD_VENTA"
        Me.UNIDAD_VENTA.HeaderText = "UNIDAD_VENTA"
        Me.UNIDAD_VENTA.Name = "UNIDAD_VENTA"
        Me.UNIDAD_VENTA.ReadOnly = True
        Me.UNIDAD_VENTA.Visible = False
        '
        'INDICA_LOTE
        '
        Me.INDICA_LOTE.DataPropertyName = "INDICA_LOTE"
        Me.INDICA_LOTE.HeaderText = "INDICA_LOTE"
        Me.INDICA_LOTE.Name = "INDICA_LOTE"
        Me.INDICA_LOTE.ReadOnly = True
        Me.INDICA_LOTE.Visible = False
        '
        'INDICA_VALIDA_STOCK
        '
        Me.INDICA_VALIDA_STOCK.DataPropertyName = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.HeaderText = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.Name = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.ReadOnly = True
        Me.INDICA_VALIDA_STOCK.Visible = False
        '
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.HeaderText = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        '
        'frmProductoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 566)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE PRODUCTOS"
        CType(Me.gvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDAD_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDAD_MEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK_ACTUAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK_COMPROMETIDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK_TRANSITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDAD_VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VALIDA_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_COMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
