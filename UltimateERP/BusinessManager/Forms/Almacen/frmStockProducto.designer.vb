<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockProducto
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockProducto))
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gvStockProducto = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INGRESOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EGRESOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtStockActual = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.gvStockProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 18)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 18)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "CODIGO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 37)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(76, 21)
        Me.txtProducto.TabIndex = 0
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(12, 80)
        Me.txtProductoDescripcion.MaxLength = 50
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(555, 21)
        Me.txtProductoDescripcion.TabIndex = 3
        Me.txtProductoDescripcion.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(555, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "DESCRIPCION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvStockProducto
        '
        Me.gvStockProducto.AllowUserToAddRows = False
        Me.gvStockProducto.AllowUserToDeleteRows = False
        Me.gvStockProducto.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvStockProducto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvStockProducto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gvStockProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvStockProducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.ALMACEN, Me.ALMACEN_DESCRIPCION, Me.INDICA_VENTA, Me.NUMERO_LOTE, Me.FECHA_VENCIMIENTO, Me.PRODUCTO, Me.PRODUCTO_DESCRIPCION, Me.INGRESOS, Me.EGRESOS, Me.STOCK})
        Me.gvStockProducto.Enabled = False
        Me.gvStockProducto.EnableHeadersVisualStyles = False
        Me.gvStockProducto.Location = New System.Drawing.Point(12, 107)
        Me.gvStockProducto.MultiSelect = False
        Me.gvStockProducto.Name = "gvStockProducto"
        Me.gvStockProducto.ReadOnly = True
        Me.gvStockProducto.RowHeadersVisible = False
        Me.gvStockProducto.RowHeadersWidth = 13
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.OldLace
        Me.gvStockProducto.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gvStockProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvStockProducto.Size = New System.Drawing.Size(555, 307)
        Me.gvStockProducto.TabIndex = 4
        Me.gvStockProducto.TabStop = False
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
        'ALMACEN_DESCRIPCION
        '
        Me.ALMACEN_DESCRIPCION.DataPropertyName = "ALMACEN_DESCRIPCION"
        Me.ALMACEN_DESCRIPCION.HeaderText = "ALMACEN"
        Me.ALMACEN_DESCRIPCION.Name = "ALMACEN_DESCRIPCION"
        Me.ALMACEN_DESCRIPCION.ReadOnly = True
        Me.ALMACEN_DESCRIPCION.Width = 380
        '
        'INDICA_VENTA
        '
        Me.INDICA_VENTA.DataPropertyName = "INDICA_VENTA"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_VENTA.DefaultCellStyle = DataGridViewCellStyle8
        Me.INDICA_VENTA.HeaderText = "DISPONIBLE"
        Me.INDICA_VENTA.Name = "INDICA_VENTA"
        Me.INDICA_VENTA.ReadOnly = True
        Me.INDICA_VENTA.Width = 70
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        Me.NUMERO_LOTE.HeaderText = "NUMERO_LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        Me.NUMERO_LOTE.Visible = False
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Visible = False
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Visible = False
        Me.PRODUCTO.Width = 70
        '
        'PRODUCTO_DESCRIPCION
        '
        Me.PRODUCTO_DESCRIPCION.DataPropertyName = "PRODUCTO_DESCRIPCION"
        Me.PRODUCTO_DESCRIPCION.HeaderText = "PRODUCTO_DESCRIPCION"
        Me.PRODUCTO_DESCRIPCION.Name = "PRODUCTO_DESCRIPCION"
        Me.PRODUCTO_DESCRIPCION.ReadOnly = True
        Me.PRODUCTO_DESCRIPCION.Visible = False
        Me.PRODUCTO_DESCRIPCION.Width = 570
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.STOCK.DefaultCellStyle = DataGridViewCellStyle9
        Me.STOCK.HeaderText = "STOCK"
        Me.STOCK.Name = "STOCK"
        Me.STOCK.ReadOnly = True
        Me.STOCK.Width = 75
        '
        'btnConsultar
        '
        Me.btnConsultar.ForeColor = System.Drawing.Color.Navy
        Me.btnConsultar.Location = New System.Drawing.Point(94, 37)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(102, 23)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.TabStop = False
        Me.btnConsultar.Text = "CONSULTAR"
        Me.btnConsultar.UseVisualStyleBackColor = True
        Me.btnConsultar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(527, 18)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(481, 18)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(40, 40)
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtStockActual
        '
        Me.txtStockActual.BackColor = System.Drawing.Color.Moccasin
        Me.txtStockActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStockActual.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockActual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockActual.Location = New System.Drawing.Point(398, 37)
        Me.txtStockActual.MaxLength = 10
        Me.txtStockActual.Name = "txtStockActual"
        Me.txtStockActual.ReadOnly = True
        Me.txtStockActual.Size = New System.Drawing.Size(77, 21)
        Me.txtStockActual.TabIndex = 80
        Me.txtStockActual.TabStop = False
        Me.txtStockActual.Tag = "E"
        Me.txtStockActual.Text = "0"
        Me.txtStockActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(302, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 21)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "STOCK TOTAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmStockProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStockActual)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.gvStockProducto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.txtProductoDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockProducto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK POR PRODUCTO"
        CType(Me.gvStockProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvStockProducto As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INGRESOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EGRESOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtStockActual As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
