<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSerieConsulta
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigoCompra = New System.Windows.Forms.TextBox()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.gvSerieHistorico = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.gvProductosSerie = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.gvSerieHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.gvProductosSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(1028, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.gvSerieHistorico)
        Me.Panel.Controls.Add(Me.pnlPrincipal)
        Me.Panel.Size = New System.Drawing.Size(1028, 436)
        Me.Panel.TabIndex = 0
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroSerie.Location = New System.Drawing.Point(425, 23)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.Size = New System.Drawing.Size(138, 21)
        Me.txtNumeroSerie.TabIndex = 0
        Me.txtNumeroSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(877, 23)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(50, 21)
        Me.txtProductoDescripcion.TabIndex = 2
        Me.txtProductoDescripcion.TabStop = False
        Me.txtProductoDescripcion.Visible = False
        '
        'txtCodigoCompra
        '
        Me.txtCodigoCompra.BackColor = System.Drawing.Color.Moccasin
        Me.txtCodigoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCompra.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCodigoCompra.Location = New System.Drawing.Point(822, 23)
        Me.txtCodigoCompra.MaxLength = 20
        Me.txtCodigoCompra.Name = "txtCodigoCompra"
        Me.txtCodigoCompra.ReadOnly = True
        Me.txtCodigoCompra.Size = New System.Drawing.Size(49, 21)
        Me.txtCodigoCompra.TabIndex = 1
        Me.txtCodigoCompra.TabStop = False
        Me.txtCodigoCompra.Tag = ""
        Me.txtCodigoCompra.Visible = False
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(0, 0)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(1026, 20)
        Me.lblComprobante.TabIndex = 5
        Me.lblComprobante.Text = "CONSULTAR NUMERO DE SERIE"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(935, 23)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(12, 21)
        Me.txtProducto.TabIndex = 3
        Me.txtProducto.TabStop = False
        Me.txtProducto.Tag = ""
        Me.txtProducto.Visible = False
        '
        'gvSerieHistorico
        '
        Me.gvSerieHistorico.AllowUserToAddRows = False
        Me.gvSerieHistorico.AllowUserToDeleteRows = False
        Me.gvSerieHistorico.AllowUserToOrderColumns = True
        Me.gvSerieHistorico.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.gvSerieHistorico.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvSerieHistorico.BackgroundColor = System.Drawing.Color.White
        Me.gvSerieHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvSerieHistorico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvSerieHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvSerieHistorico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.PRODUCTO, Me.CODIGO_COMPRA, Me.DESCRIPCION_AMPLIADA, Me.NUMERO_SERIE, Me.REFERENCIA, Me.REFERENCIA_ALMACEN, Me.REFERENCIA_FECHA, Me.REFERENCIA_ESTADO, Me.TIPO_OPERACION, Me.DESCRIPCION, Me.COMENTARIO, Me.ALMACEN, Me.ESTADO, Me.ORDEN})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvSerieHistorico.DefaultCellStyle = DataGridViewCellStyle5
        Me.gvSerieHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvSerieHistorico.Enabled = False
        Me.gvSerieHistorico.EnableHeadersVisualStyles = False
        Me.gvSerieHistorico.GridColor = System.Drawing.Color.White
        Me.gvSerieHistorico.Location = New System.Drawing.Point(0, 180)
        Me.gvSerieHistorico.MultiSelect = False
        Me.gvSerieHistorico.Name = "gvSerieHistorico"
        Me.gvSerieHistorico.ReadOnly = True
        Me.gvSerieHistorico.RowHeadersVisible = False
        Me.gvSerieHistorico.RowHeadersWidth = 13
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.gvSerieHistorico.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gvSerieHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSerieHistorico.Size = New System.Drawing.Size(1026, 254)
        Me.gvSerieHistorico.TabIndex = 4
        Me.gvSerieHistorico.TabStop = False
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
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Visible = False
        Me.PRODUCTO.Width = 60
        '
        'CODIGO_COMPRA
        '
        Me.CODIGO_COMPRA.DataPropertyName = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.HeaderText = "CODIGO "
        Me.CODIGO_COMPRA.Name = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.ReadOnly = True
        Me.CODIGO_COMPRA.Visible = False
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Visible = False
        Me.DESCRIPCION_AMPLIADA.Width = 545
        '
        'NUMERO_SERIE
        '
        Me.NUMERO_SERIE.DataPropertyName = "NUMERO_SERIE"
        Me.NUMERO_SERIE.HeaderText = "NUMERO_SERIE"
        Me.NUMERO_SERIE.Name = "NUMERO_SERIE"
        Me.NUMERO_SERIE.ReadOnly = True
        Me.NUMERO_SERIE.Visible = False
        '
        'REFERENCIA
        '
        Me.REFERENCIA.DataPropertyName = "REFERENCIA"
        Me.REFERENCIA.HeaderText = "REFERENCIA"
        Me.REFERENCIA.Name = "REFERENCIA"
        Me.REFERENCIA.ReadOnly = True
        Me.REFERENCIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.REFERENCIA.Width = 85
        '
        'REFERENCIA_ALMACEN
        '
        Me.REFERENCIA_ALMACEN.DataPropertyName = "REFERENCIA_ALMACEN"
        Me.REFERENCIA_ALMACEN.HeaderText = "ALMACEN"
        Me.REFERENCIA_ALMACEN.Name = "REFERENCIA_ALMACEN"
        Me.REFERENCIA_ALMACEN.ReadOnly = True
        Me.REFERENCIA_ALMACEN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.REFERENCIA_ALMACEN.Width = 210
        '
        'REFERENCIA_FECHA
        '
        Me.REFERENCIA_FECHA.DataPropertyName = "REFERENCIA_FECHA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.REFERENCIA_FECHA.DefaultCellStyle = DataGridViewCellStyle3
        Me.REFERENCIA_FECHA.HeaderText = "FECHA"
        Me.REFERENCIA_FECHA.Name = "REFERENCIA_FECHA"
        Me.REFERENCIA_FECHA.ReadOnly = True
        Me.REFERENCIA_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.REFERENCIA_FECHA.Width = 70
        '
        'REFERENCIA_ESTADO
        '
        Me.REFERENCIA_ESTADO.DataPropertyName = "REFERENCIA_ESTADO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.REFERENCIA_ESTADO.DefaultCellStyle = DataGridViewCellStyle4
        Me.REFERENCIA_ESTADO.HeaderText = "EST"
        Me.REFERENCIA_ESTADO.Name = "REFERENCIA_ESTADO"
        Me.REFERENCIA_ESTADO.ReadOnly = True
        Me.REFERENCIA_ESTADO.Width = 25
        '
        'TIPO_OPERACION
        '
        Me.TIPO_OPERACION.DataPropertyName = "TIPO_OPERACION"
        Me.TIPO_OPERACION.HeaderText = "TIPO_OPERACION"
        Me.TIPO_OPERACION.Name = "TIPO_OPERACION"
        Me.TIPO_OPERACION.ReadOnly = True
        Me.TIPO_OPERACION.Visible = False
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "TIPO DE OPERACION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 250
        '
        'COMENTARIO
        '
        Me.COMENTARIO.DataPropertyName = "COMENTARIO"
        Me.COMENTARIO.HeaderText = "COMENTARIO"
        Me.COMENTARIO.Name = "COMENTARIO"
        Me.COMENTARIO.ReadOnly = True
        Me.COMENTARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMENTARIO.Width = 380
        '
        'ALMACEN
        '
        Me.ALMACEN.DataPropertyName = "ALMACEN"
        Me.ALMACEN.HeaderText = "ALMACEN"
        Me.ALMACEN.Name = "ALMACEN"
        Me.ALMACEN.ReadOnly = True
        Me.ALMACEN.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'ORDEN
        '
        Me.ORDEN.DataPropertyName = "ORDEN"
        Me.ORDEN.HeaderText = "ORDEN"
        Me.ORDEN.Name = "ORDEN"
        Me.ORDEN.ReadOnly = True
        Me.ORDEN.Visible = False
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.gvProductosSerie)
        Me.pnlPrincipal.Controls.Add(Me.txtNumeroSerie)
        Me.pnlPrincipal.Controls.Add(Me.txtProducto)
        Me.pnlPrincipal.Controls.Add(Me.txtProductoDescripcion)
        Me.pnlPrincipal.Controls.Add(Me.lblComprobante)
        Me.pnlPrincipal.Controls.Add(Me.txtCodigoCompra)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1026, 180)
        Me.pnlPrincipal.TabIndex = 8
        '
        'gvProductosSerie
        '
        Me.gvProductosSerie.AllowUserToAddRows = False
        Me.gvProductosSerie.AllowUserToDeleteRows = False
        Me.gvProductosSerie.AllowUserToOrderColumns = True
        Me.gvProductosSerie.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.MediumBlue
        Me.gvProductosSerie.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gvProductosSerie.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.gvProductosSerie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvProductosSerie.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gvProductosSerie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvProductosSerie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.MediumBlue
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvProductosSerie.DefaultCellStyle = DataGridViewCellStyle9
        Me.gvProductosSerie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gvProductosSerie.EnableHeadersVisualStyles = False
        Me.gvProductosSerie.GridColor = System.Drawing.Color.AliceBlue
        Me.gvProductosSerie.Location = New System.Drawing.Point(0, 50)
        Me.gvProductosSerie.MultiSelect = False
        Me.gvProductosSerie.Name = "gvProductosSerie"
        Me.gvProductosSerie.ReadOnly = True
        Me.gvProductosSerie.RowHeadersVisible = False
        Me.gvProductosSerie.RowHeadersWidth = 13
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.MediumBlue
        Me.gvProductosSerie.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gvProductosSerie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvProductosSerie.Size = New System.Drawing.Size(1026, 130)
        Me.gvProductosSerie.TabIndex = 18
        Me.gvProductosSerie.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "EMPRESA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "EMPRESA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PRODUCTO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CODIGO_COMPRA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 170
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 700
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "NUMERO_SERIE"
        Me.DataGridViewTextBoxColumn5.HeaderText = "NRO. DE SERIE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 135
        '
        'frmSerieConsulta
        '
        Me.ClientSize = New System.Drawing.Size(1028, 490)
        Me.Name = "frmSerieConsulta"
        Me.Text = " CONSULTAR NUMERO DE SERIE"
        Me.Panel.ResumeLayout(False)
        CType(Me.gvSerieHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        CType(Me.gvProductosSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCompra As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents gvSerieHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents gvProductosSerie As System.Windows.Forms.DataGridView
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
