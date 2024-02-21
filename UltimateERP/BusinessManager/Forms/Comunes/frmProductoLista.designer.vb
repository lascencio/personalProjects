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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvProductos = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIDAD_MEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_VALIDA_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_AFECTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_COMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_PROMOCIONAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARTIDA_ARANCELARIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_ANTIGUO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescripcionIntro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCounter = New System.Windows.Forms.Label()
        CType(Me.gvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvProductos
        '
        Me.gvProductos.AllowUserToAddRows = False
        Me.gvProductos.AllowUserToDeleteRows = False
        Me.gvProductos.AllowUserToOrderColumns = True
        Me.gvProductos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.UNIDAD_MEDIDA, Me.CODIGO_COMPRA, Me.DESCRIPCION_COMPRA, Me.INDICA_SERIE, Me.INDICA_LOTE, Me.INDICA_VENCIMIENTO, Me.INDICA_VALIDA_STOCK, Me.INDICA_AFECTO, Me.INDICA_COMPUESTO, Me.INDICA_PROMOCIONAL, Me.PARTIDA_ARANCELARIA, Me.CODIGO_ANTIGUO, Me.ESTADO})
        Me.gvProductos.EnableHeadersVisualStyles = False
        Me.gvProductos.Location = New System.Drawing.Point(12, 58)
        Me.gvProductos.MultiSelect = False
        Me.gvProductos.Name = "gvProductos"
        Me.gvProductos.ReadOnly = True
        Me.gvProductos.RowHeadersVisible = False
        Me.gvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvProductos.Size = New System.Drawing.Size(1010, 541)
        Me.gvProductos.TabIndex = 2
        Me.gvProductos.TabStop = False
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
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
        Me.DESCRIPCION_AMPLIADA.Width = 645
        '
        'UNIDAD_MEDIDA
        '
        Me.UNIDAD_MEDIDA.DataPropertyName = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.HeaderText = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.Name = "UNIDAD_MEDIDA"
        Me.UNIDAD_MEDIDA.ReadOnly = True
        Me.UNIDAD_MEDIDA.Visible = False
        '
        'CODIGO_COMPRA
        '
        Me.CODIGO_COMPRA.DataPropertyName = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.HeaderText = "CODIGO COMPRA"
        Me.CODIGO_COMPRA.Name = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.ReadOnly = True
        Me.CODIGO_COMPRA.Width = 155
        '
        'DESCRIPCION_COMPRA
        '
        Me.DESCRIPCION_COMPRA.DataPropertyName = "DESCRIPCION_COMPRA"
        Me.DESCRIPCION_COMPRA.HeaderText = "DESCRIPCION_COMPRA"
        Me.DESCRIPCION_COMPRA.Name = "DESCRIPCION_COMPRA"
        Me.DESCRIPCION_COMPRA.ReadOnly = True
        Me.DESCRIPCION_COMPRA.Visible = False
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_SERIE.DefaultCellStyle = DataGridViewCellStyle2
        Me.INDICA_SERIE.HeaderText = "SERIE"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Width = 46
        '
        'INDICA_LOTE
        '
        Me.INDICA_LOTE.DataPropertyName = "INDICA_LOTE"
        Me.INDICA_LOTE.HeaderText = "INDICA_LOTE"
        Me.INDICA_LOTE.Name = "INDICA_LOTE"
        Me.INDICA_LOTE.ReadOnly = True
        Me.INDICA_LOTE.Visible = False
        '
        'INDICA_VENCIMIENTO
        '
        Me.INDICA_VENCIMIENTO.DataPropertyName = "INDICA_VENCIMIENTO"
        Me.INDICA_VENCIMIENTO.HeaderText = "INDICA_VENCIMIENTO"
        Me.INDICA_VENCIMIENTO.Name = "INDICA_VENCIMIENTO"
        Me.INDICA_VENCIMIENTO.ReadOnly = True
        Me.INDICA_VENCIMIENTO.Visible = False
        '
        'INDICA_VALIDA_STOCK
        '
        Me.INDICA_VALIDA_STOCK.DataPropertyName = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.HeaderText = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.Name = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.ReadOnly = True
        Me.INDICA_VALIDA_STOCK.Visible = False
        '
        'INDICA_AFECTO
        '
        Me.INDICA_AFECTO.DataPropertyName = "INDICA_AFECTO"
        Me.INDICA_AFECTO.HeaderText = "INDICA_AFECTO"
        Me.INDICA_AFECTO.Name = "INDICA_AFECTO"
        Me.INDICA_AFECTO.ReadOnly = True
        Me.INDICA_AFECTO.Visible = False
        '
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.HeaderText = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        '
        'INDICA_PROMOCIONAL
        '
        Me.INDICA_PROMOCIONAL.DataPropertyName = "INDICA_PROMOCIONAL"
        Me.INDICA_PROMOCIONAL.HeaderText = "INDICA_PROMOCIONAL"
        Me.INDICA_PROMOCIONAL.Name = "INDICA_PROMOCIONAL"
        Me.INDICA_PROMOCIONAL.ReadOnly = True
        Me.INDICA_PROMOCIONAL.Visible = False
        '
        'PARTIDA_ARANCELARIA
        '
        Me.PARTIDA_ARANCELARIA.DataPropertyName = "PARTIDA_ARANCELARIA"
        Me.PARTIDA_ARANCELARIA.HeaderText = "PARTIDA_ARANCELARIA"
        Me.PARTIDA_ARANCELARIA.Name = "PARTIDA_ARANCELARIA"
        Me.PARTIDA_ARANCELARIA.ReadOnly = True
        Me.PARTIDA_ARANCELARIA.Visible = False
        '
        'CODIGO_ANTIGUO
        '
        Me.CODIGO_ANTIGUO.DataPropertyName = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.HeaderText = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.Name = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.ReadOnly = True
        Me.CODIGO_ANTIGUO.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle3
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 62
        '
        'txtDescripcionIntro
        '
        Me.txtDescripcionIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtDescripcionIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionIntro.Location = New System.Drawing.Point(128, 32)
        Me.txtDescripcionIntro.MaxLength = 100
        Me.txtDescripcionIntro.Name = "txtDescripcionIntro"
        Me.txtDescripcionIntro.Size = New System.Drawing.Size(663, 20)
        Me.txtDescripcionIntro.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(128, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(663, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "DESCRIPCION"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtCodigoIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CODIGO COMPRA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCounter
        '
        Me.LblCounter.Enabled = False
        Me.LblCounter.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCounter.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblCounter.Location = New System.Drawing.Point(800, 32)
        Me.LblCounter.Name = "LblCounter"
        Me.LblCounter.Size = New System.Drawing.Size(222, 20)
        Me.LblCounter.TabIndex = 5
        Me.LblCounter.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'frmProductoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 611)
        Me.Controls.Add(Me.LblCounter)
        Me.Controls.Add(Me.txtDescripcionIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE PRODUCTOS"
        CType(Me.gvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescripcionIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblCounter As System.Windows.Forms.Label
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDAD_MEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VALIDA_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_AFECTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_COMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_PROMOCIONAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARTIDA_ARANCELARIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_ANTIGUO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
