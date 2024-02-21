<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacionAlmacen
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperacionAlmacen))
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtOperacionFecha = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.gvOperacionAlmacenLineas = New System.Windows.Forms.DataGridView
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRECIO_UNITARIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtNumeroLote = New System.Windows.Forms.TextBox
        Me.txtLinea = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtOperacion = New System.Windows.Forms.TextBox
        Me.ckbOperacionAnulada = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtComprobanteNombre = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbComprobanteTipoMoneda = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtComprobanteImporte = New System.Windows.Forms.TextBox
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbProductos = New System.Windows.Forms.ComboBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblNumeroLote = New System.Windows.Forms.Label
        Me.btnDescartar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEjercicio = New System.Windows.Forms.TextBox
        Me.txtMes = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblFechaVencimiento = New System.Windows.Forms.Label
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox
        Me.txtIndicaLote = New System.Windows.Forms.TextBox
        Me.txtStockAnterior = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtStockNuevo = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtPrecioTotal = New System.Windows.Forms.TextBox
        Me.Panel.SuspendLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(980, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtPrecioTotal)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.btnLimpiar)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.txtStockNuevo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtStockAnterior)
        Me.Panel.Controls.Add(Me.txtIndicaLote)
        Me.Panel.Controls.Add(Me.lblFechaVencimiento)
        Me.Panel.Controls.Add(Me.txtFechaVencimiento)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.btnDescartar)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.lblNumeroLote)
        Me.Panel.Controls.Add(Me.cmbProductos)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtComprobanteImporte)
        Me.Panel.Controls.Add(Me.txtComprobanteNombre)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipoMoneda)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.Label36)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.ckbOperacionAnulada)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtOperacionFecha)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbTipoOperacion)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.gvOperacionAlmacenLineas)
        Me.Panel.Controls.Add(Me.txtNumeroLote)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtOperacion)
        Me.Panel.Size = New System.Drawing.Size(980, 624)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Chocolate
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(112, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 18)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "FECHA"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacionFecha
        '
        Me.txtOperacionFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOperacionFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacionFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperacionFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacionFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtOperacionFecha.Location = New System.Drawing.Point(112, 31)
        Me.txtOperacionFecha.MaxLength = 50
        Me.txtOperacionFecha.Name = "txtOperacionFecha"
        Me.txtOperacionFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtOperacionFecha.TabIndex = 0
        Me.txtOperacionFecha.Tag = "F"
        Me.txtOperacionFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 18)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "TIPO DE OPERACION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoOperacion.DisplayMember = "DESCRIPCION"
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(12, 74)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(261, 21)
        Me.cmbTipoOperacion.TabIndex = 2
        Me.cmbTipoOperacion.ValueMember = "CODIGO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(205, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 18)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "ALMACEN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(205, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(245, 21)
        Me.cmbAlmacen.TabIndex = 1
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'gvOperacionAlmacenLineas
        '
        Me.gvOperacionAlmacenLineas.AllowUserToAddRows = False
        Me.gvOperacionAlmacenLineas.AllowUserToDeleteRows = False
        Me.gvOperacionAlmacenLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvOperacionAlmacenLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOperacionAlmacenLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvOperacionAlmacenLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperacionAlmacenLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.NUMERO_LOTE, Me.FECHA_VENCIMIENTO, Me.CANTIDAD, Me.PRECIO_UNITARIO, Me.INDICA_LOTE})
        Me.gvOperacionAlmacenLineas.EnableHeadersVisualStyles = False
        Me.gvOperacionAlmacenLineas.Location = New System.Drawing.Point(11, 297)
        Me.gvOperacionAlmacenLineas.MultiSelect = False
        Me.gvOperacionAlmacenLineas.Name = "gvOperacionAlmacenLineas"
        Me.gvOperacionAlmacenLineas.ReadOnly = True
        Me.gvOperacionAlmacenLineas.RowHeadersWidth = 20
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.OldLace
        Me.gvOperacionAlmacenLineas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gvOperacionAlmacenLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOperacionAlmacenLineas.Size = New System.Drawing.Size(956, 314)
        Me.gvOperacionAlmacenLineas.TabIndex = 25
        '
        'LINEA
        '
        Me.LINEA.DataPropertyName = "LINEA"
        Me.LINEA.HeaderText = "LN"
        Me.LINEA.Name = "LINEA"
        Me.LINEA.ReadOnly = True
        Me.LINEA.Visible = False
        Me.LINEA.Width = 30
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 450
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NUMERO_LOTE.DefaultCellStyle = DataGridViewCellStyle3
        Me.NUMERO_LOTE.HeaderText = "LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "VCMTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Width = 70
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle4
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 80
        '
        'PRECIO_UNITARIO
        '
        Me.PRECIO_UNITARIO.DataPropertyName = "PRECIO_UNITARIO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle5
        Me.PRECIO_UNITARIO.HeaderText = "P. UNITARIO"
        Me.PRECIO_UNITARIO.Name = "PRECIO_UNITARIO"
        Me.PRECIO_UNITARIO.ReadOnly = True
        '
        'INDICA_LOTE
        '
        Me.INDICA_LOTE.DataPropertyName = "INDICA_LOTE"
        Me.INDICA_LOTE.HeaderText = "INDICAR_LOTE"
        Me.INDICA_LOTE.Name = "INDICA_LOTE"
        Me.INDICA_LOTE.ReadOnly = True
        Me.INDICA_LOTE.Visible = False
        '
        'txtNumeroLote
        '
        Me.txtNumeroLote.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroLote.Enabled = False
        Me.txtNumeroLote.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroLote.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroLote.Location = New System.Drawing.Point(514, 229)
        Me.txtNumeroLote.MaxLength = 10
        Me.txtNumeroLote.Name = "txtNumeroLote"
        Me.txtNumeroLote.Size = New System.Drawing.Size(108, 21)
        Me.txtNumeroLote.TabIndex = 20
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.Enabled = False
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(3, 229)
        Me.txtLinea.MaxLength = 3
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.ReadOnly = True
        Me.txtLinea.Size = New System.Drawing.Size(8, 21)
        Me.txtLinea.TabIndex = 26
        Me.txtLinea.Tag = ""
        Me.txtLinea.Visible = False
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Chocolate
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(98, 18)
        Me.Label33.TabIndex = 29
        Me.Label33.Text = "OPERACION"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacion
        '
        Me.txtOperacion.BackColor = System.Drawing.Color.Moccasin
        Me.txtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOperacion.Location = New System.Drawing.Point(12, 31)
        Me.txtOperacion.MaxLength = 8
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.ReadOnly = True
        Me.txtOperacion.Size = New System.Drawing.Size(98, 21)
        Me.txtOperacion.TabIndex = 11
        Me.txtOperacion.TabStop = False
        '
        'ckbOperacionAnulada
        '
        Me.ckbOperacionAnulada.BackColor = System.Drawing.Color.Transparent
        Me.ckbOperacionAnulada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbOperacionAnulada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbOperacionAnulada.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbOperacionAnulada.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbOperacionAnulada.Location = New System.Drawing.Point(770, 32)
        Me.ckbOperacionAnulada.Name = "ckbOperacionAnulada"
        Me.ckbOperacionAnulada.Size = New System.Drawing.Size(197, 20)
        Me.ckbOperacionAnulada.TabIndex = 10
        Me.ckbOperacionAnulada.TabStop = False
        Me.ckbOperacionAnulada.Text = "OPERACION ANULADA"
        Me.ckbOperacionAnulada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbOperacionAnulada.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(626, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(344, 20)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "MOVIMIENTOS DE ALMACEN"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Chocolate
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(275, 55)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(692, 18)
        Me.Label36.TabIndex = 34
        Me.Label36.Text = "COMENTARIO"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(275, 74)
        Me.txtComentario.MaxLength = 150
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(692, 21)
        Me.txtComentario.TabIndex = 3
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(12, 117)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 14
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Chocolate
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(184, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(690, 18)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "RAZON SOCIAL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(184, 117)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(690, 21)
        Me.txtRazonSocial.TabIndex = 15
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(69, 117)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(114, 21)
        Me.txtDocumentoNumero.TabIndex = 4
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Chocolate
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(12, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 18)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "DOCUMENTO IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteNombre
        '
        Me.txtComprobanteNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteNombre.Location = New System.Drawing.Point(60, 160)
        Me.txtComprobanteNombre.MaxLength = 80
        Me.txtComprobanteNombre.Name = "txtComprobanteNombre"
        Me.txtComprobanteNombre.ReadOnly = True
        Me.txtComprobanteNombre.Size = New System.Drawing.Size(267, 21)
        Me.txtComprobanteNombre.TabIndex = 18
        Me.txtComprobanteNombre.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Chocolate
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(315, 18)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "TIPO DE COMPROBANTE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "CODIGO"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(12, 160)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(47, 21)
        Me.cmbComprobanteTipo.TabIndex = 17
        Me.cmbComprobanteTipo.TabStop = False
        Me.cmbComprobanteTipo.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Chocolate
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(525, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 18)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "F. EMISION"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Chocolate
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(400, 141)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 18)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "NUMERO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Chocolate
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(329, 141)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(70, 18)
        Me.Label42.TabIndex = 39
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(525, 160)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 7
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(400, 160)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(124, 21)
        Me.txtComprobanteNumero.TabIndex = 6
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(329, 160)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(70, 21)
        Me.txtComprobanteSerie.TabIndex = 5
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Chocolate
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(617, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 18)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "MONEDA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipoMoneda
        '
        Me.cmbComprobanteTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbComprobanteTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipoMoneda.FormattingEnabled = True
        Me.cmbComprobanteTipoMoneda.Location = New System.Drawing.Point(617, 160)
        Me.cmbComprobanteTipoMoneda.Name = "cmbComprobanteTipoMoneda"
        Me.cmbComprobanteTipoMoneda.Size = New System.Drawing.Size(127, 21)
        Me.cmbComprobanteTipoMoneda.TabIndex = 8
        Me.cmbComprobanteTipoMoneda.ValueMember = "CODIGO"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Chocolate
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(745, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 18)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "IMPORTE TOTAL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteImporte
        '
        Me.txtComprobanteImporte.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteImporte.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteImporte.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteImporte.Location = New System.Drawing.Point(745, 160)
        Me.txtComprobanteImporte.MaxLength = 12
        Me.txtComprobanteImporte.Name = "txtComprobanteImporte"
        Me.txtComprobanteImporte.Size = New System.Drawing.Size(120, 21)
        Me.txtComprobanteImporte.TabIndex = 9
        Me.txtComprobanteImporte.TabStop = False
        Me.txtComprobanteImporte.Tag = "D"
        Me.txtComprobanteImporte.Text = "0.00"
        Me.txtComprobanteImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(877, 117)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(90, 21)
        Me.txtCuentaComercial.TabIndex = 16
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Text = "CC000150"
        Me.txtCuentaComercial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ilBotones
        '
        Me.ilBotones.ImageStream = CType(resources.GetObject("ilBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ilBotones.Images.SetKeyName(0, "smallFail.gif")
        Me.ilBotones.Images.SetKeyName(1, "smallSuccess.gif")
        Me.ilBotones.Images.SetKeyName(2, "smallFail BW.gif")
        Me.ilBotones.Images.SetKeyName(3, "smallSuccess BW.gif")
        '
        'cmbProductos
        '
        Me.cmbProductos.BackColor = System.Drawing.Color.Azure
        Me.cmbProductos.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductos.Enabled = False
        Me.cmbProductos.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(95, 229)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(418, 21)
        Me.cmbProductos.TabIndex = 27
        Me.cmbProductos.ValueMember = "PRODUCTO"
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 229)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(82, 21)
        Me.txtProducto.TabIndex = 19
        Me.txtProducto.Tag = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(715, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 18)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "CANTIDAD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(715, 229)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(81, 21)
        Me.txtCantidad.TabIndex = 22
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(95, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(418, 18)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label14.Location = New System.Drawing.Point(12, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 18)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "PRODUCTO"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroLote
        '
        Me.lblNumeroLote.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblNumeroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroLote.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroLote.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNumeroLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroLote.Location = New System.Drawing.Point(514, 210)
        Me.lblNumeroLote.Name = "lblNumeroLote"
        Me.lblNumeroLote.Size = New System.Drawing.Size(108, 18)
        Me.lblNumeroLote.TabIndex = 47
        Me.lblNumeroLote.Text = "NRO. LOTE"
        Me.lblNumeroLote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDescartar
        '
        Me.btnDescartar.BackgroundImage = CType(resources.GetObject("btnDescartar.BackgroundImage"), System.Drawing.Image)
        Me.btnDescartar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDescartar.ImageIndex = 2
        Me.btnDescartar.ImageList = Me.ilBotones
        Me.btnDescartar.Location = New System.Drawing.Point(926, 209)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(42, 42)
        Me.btnDescartar.TabIndex = 28
        Me.btnDescartar.TabStop = False
        Me.btnDescartar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(884, 209)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 24
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(12, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(955, 18)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "DETALLES DE LA OPERACION"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(530, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(34, 21)
        Me.txtEjercicio.TabIndex = 12
        Me.txtEjercicio.TabStop = False
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEjercicio.Visible = False
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.Color.Moccasin
        Me.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMes.Location = New System.Drawing.Point(565, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(17, 21)
        Me.txtMes.TabIndex = 13
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(797, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 18)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "COSTO . UNIT."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Enabled = False
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(797, 229)
        Me.txtPrecioUnitario.MaxLength = 10
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(86, 21)
        Me.txtPrecioUnitario.TabIndex = 23
        Me.txtPrecioUnitario.Tag = "V"
        Me.txtPrecioUnitario.Text = "0.0000"
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Chocolate
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(877, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 18)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "CTA. CTE."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaVencimiento.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaVencimiento.ForeColor = System.Drawing.Color.White
        Me.lblFechaVencimiento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(623, 210)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(91, 18)
        Me.lblFechaVencimiento.TabIndex = 48
        Me.lblFechaVencimiento.Text = "F. VCMTO."
        Me.lblFechaVencimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVencimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaVencimiento.Enabled = False
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVencimiento.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(623, 229)
        Me.txtFechaVencimiento.MaxLength = 10
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(91, 21)
        Me.txtFechaVencimiento.TabIndex = 21
        Me.txtFechaVencimiento.Tag = "F"
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIndicaLote
        '
        Me.txtIndicaLote.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaLote.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaLote.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaLote.Location = New System.Drawing.Point(187, 251)
        Me.txtIndicaLote.MaxLength = 2
        Me.txtIndicaLote.Name = "txtIndicaLote"
        Me.txtIndicaLote.ReadOnly = True
        Me.txtIndicaLote.Size = New System.Drawing.Size(30, 21)
        Me.txtIndicaLote.TabIndex = 51
        Me.txtIndicaLote.TabStop = False
        Me.txtIndicaLote.Tag = ""
        Me.txtIndicaLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStockAnterior
        '
        Me.txtStockAnterior.BackColor = System.Drawing.Color.Moccasin
        Me.txtStockAnterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockAnterior.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockAnterior.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockAnterior.Location = New System.Drawing.Point(715, 251)
        Me.txtStockAnterior.MaxLength = 10
        Me.txtStockAnterior.Name = "txtStockAnterior"
        Me.txtStockAnterior.ReadOnly = True
        Me.txtStockAnterior.Size = New System.Drawing.Size(81, 21)
        Me.txtStockAnterior.TabIndex = 52
        Me.txtStockAnterior.TabStop = False
        Me.txtStockAnterior.Tag = "Z"
        Me.txtStockAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(593, 251)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 21)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "STOCK ANTERIOR"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(593, 273)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 21)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "STOCK ACTUAL"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStockNuevo
        '
        Me.txtStockNuevo.BackColor = System.Drawing.Color.Moccasin
        Me.txtStockNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockNuevo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNuevo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockNuevo.Location = New System.Drawing.Point(715, 273)
        Me.txtStockNuevo.MaxLength = 10
        Me.txtStockNuevo.Name = "txtStockNuevo"
        Me.txtStockNuevo.ReadOnly = True
        Me.txtStockNuevo.Size = New System.Drawing.Size(81, 21)
        Me.txtStockNuevo.TabIndex = 54
        Me.txtStockNuevo.TabStop = False
        Me.txtStockNuevo.Tag = "Z"
        Me.txtStockNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(12, 251)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 21)
        Me.Label19.TabIndex = 56
        Me.Label19.Text = "EXIGE NUMERO DE LOTE"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiar.Location = New System.Drawing.Point(884, 250)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(83, 44)
        Me.btnLimpiar.TabIndex = 57
        Me.btnLimpiar.Text = "NUEVO"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(797, 251)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 21)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "COSTO TOTAL"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioTotal
        '
        Me.txtPrecioTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrecioTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrecioTotal.Location = New System.Drawing.Point(797, 273)
        Me.txtPrecioTotal.MaxLength = 12
        Me.txtPrecioTotal.Name = "txtPrecioTotal"
        Me.txtPrecioTotal.Size = New System.Drawing.Size(86, 21)
        Me.txtPrecioTotal.TabIndex = 60
        Me.txtPrecioTotal.TabStop = False
        Me.txtPrecioTotal.Tag = "D"
        Me.txtPrecioTotal.Text = "0.00"
        Me.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmOperacionAlmacen
        '
        Me.ClientSize = New System.Drawing.Size(980, 660)
        Me.Name = "frmOperacionAlmacen"
        Me.Text = " MOVIMIENTOS DE ALMACEN"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOperacionFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents gvOperacionAlmacenLineas As System.Windows.Forms.DataGridView
    Friend WithEvents txtNumeroLote As System.Windows.Forms.TextBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtOperacion As System.Windows.Forms.TextBox
    Friend WithEvents ckbOperacionAnulada As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroLote As System.Windows.Forms.Label
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblFechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaLote As System.Windows.Forms.TextBox
    Friend WithEvents txtStockAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtStockNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtPrecioTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
