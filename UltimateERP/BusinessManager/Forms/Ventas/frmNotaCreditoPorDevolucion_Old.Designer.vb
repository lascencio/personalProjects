<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCreditoPorDevolucion_Old
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaCreditoPorDevolucion_Old))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidadVendida = New System.Windows.Forms.TextBox()
        Me.gvVentaLineas = New System.Windows.Forms.DataGridView()
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.txtOrdenPedido = New System.Windows.Forms.TextBox()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtReferenciaFecha = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbReferenciaTipo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtReferenciaNumero = New System.Windows.Forms.TextBox()
        Me.txtReferenciaSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.txtValorExportacionOrige = New System.Windows.Forms.TextBox()
        Me.txtImporteInafectoOrigen = New System.Windows.Forms.TextBox()
        Me.txtOtrosTributosOrigen = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtImpuesto = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New System.Windows.Forms.TextBox()
        Me.txtImporteExoneradoOrigen = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtBaseImponible = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(920, 54)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtGuia)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtCantidadVendida)
        Me.Panel.Controls.Add(Me.gvVentaLineas)
        Me.Panel.Controls.Add(Me.btnLimpiar)
        Me.Panel.Controls.Add(Me.txtReferencia)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Controls.Add(Me.txtOrdenPedido)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtReferenciaFecha)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.cmbReferenciaTipo)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtReferenciaNumero)
        Me.Panel.Controls.Add(Me.txtReferenciaSerie)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Controls.Add(Me.txtValorExportacionOrige)
        Me.Panel.Controls.Add(Me.txtImporteInafectoOrigen)
        Me.Panel.Controls.Add(Me.txtOtrosTributosOrigen)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtImpuesto)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtImporteTotal)
        Me.Panel.Controls.Add(Me.txtImporteExoneradoOrigen)
        Me.Panel.Controls.Add(Me.Label31)
        Me.Panel.Controls.Add(Me.txtBaseImponible)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txtTipoCambio)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.cmbProductos)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Size = New System.Drawing.Size(920, 475)
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
        'txtGuia
        '
        Me.txtGuia.BackColor = System.Drawing.Color.Moccasin
        Me.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGuia.Location = New System.Drawing.Point(265, 7)
        Me.txtGuia.MaxLength = 8
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(25, 21)
        Me.txtGuia.TabIndex = 121
        Me.txtGuia.TabStop = False
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGuia.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(821, 148)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 120
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(615, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "CANT."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidadVendida
        '
        Me.txtCantidadVendida.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadVendida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadVendida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadVendida.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadVendida.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadVendida.Location = New System.Drawing.Point(615, 169)
        Me.txtCantidadVendida.MaxLength = 10
        Me.txtCantidadVendida.Name = "txtCantidadVendida"
        Me.txtCantidadVendida.ReadOnly = True
        Me.txtCantidadVendida.Size = New System.Drawing.Size(60, 21)
        Me.txtCantidadVendida.TabIndex = 118
        Me.txtCantidadVendida.TabStop = False
        Me.txtCantidadVendida.Tag = "E"
        Me.txtCantidadVendida.Text = "0"
        Me.txtCantidadVendida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gvVentaLineas
        '
        Me.gvVentaLineas.AllowUserToAddRows = False
        Me.gvVentaLineas.AllowUserToDeleteRows = False
        Me.gvVentaLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvVentaLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentaLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvVentaLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.CODIGO_COMPRA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.NUMERO_SERIE, Me.CANTIDAD, Me.PRECIO_UNITARIO, Me.IMPORTE_TOTAL, Me.INDICA_SERIE, Me.INDICA_LOTE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.ELIMINAR})
        Me.gvVentaLineas.EnableHeadersVisualStyles = False
        Me.gvVentaLineas.Location = New System.Drawing.Point(7, 196)
        Me.gvVentaLineas.MultiSelect = False
        Me.gvVentaLineas.Name = "gvVentaLineas"
        Me.gvVentaLineas.ReadOnly = True
        Me.gvVentaLineas.RowHeadersVisible = False
        Me.gvVentaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.OldLace
        Me.gvVentaLineas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gvVentaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentaLineas.Size = New System.Drawing.Size(895, 266)
        Me.gvVentaLineas.TabIndex = 117
        Me.gvVentaLineas.TabStop = False
        '
        'LINEA
        '
        Me.LINEA.DataPropertyName = "LINEA"
        Me.LINEA.HeaderText = "LINEA"
        Me.LINEA.Name = "LINEA"
        Me.LINEA.ReadOnly = True
        Me.LINEA.Visible = False
        '
        'CODIGO_COMPRA
        '
        Me.CODIGO_COMPRA.DataPropertyName = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.HeaderText = "CODIGO"
        Me.CODIGO_COMPRA.Name = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.ReadOnly = True
        Me.CODIGO_COMPRA.Width = 140
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Visible = False
        Me.PRODUCTO.Width = 65
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 570
        '
        'NUMERO_SERIE
        '
        Me.NUMERO_SERIE.DataPropertyName = "NUMERO_SERIE"
        Me.NUMERO_SERIE.HeaderText = "NUMERO_SERIE"
        Me.NUMERO_SERIE.Name = "NUMERO_SERIE"
        Me.NUMERO_SERIE.ReadOnly = True
        Me.NUMERO_SERIE.Visible = False
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
        Me.CANTIDAD.Width = 60
        '
        'PRECIO_UNITARIO
        '
        Me.PRECIO_UNITARIO.DataPropertyName = "PRECIO_UNITARIO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRECIO_UNITARIO.HeaderText = "P. UNIT"
        Me.PRECIO_UNITARIO.Name = "PRECIO_UNITARIO"
        Me.PRECIO_UNITARIO.ReadOnly = True
        Me.PRECIO_UNITARIO.Width = 75
        '
        'IMPORTE_TOTAL
        '
        Me.IMPORTE_TOTAL.DataPropertyName = "IMPORTE_TOTAL"
        Me.IMPORTE_TOTAL.HeaderText = "IMPORTE_TOTAL"
        Me.IMPORTE_TOTAL.Name = "IMPORTE_TOTAL"
        Me.IMPORTE_TOTAL.ReadOnly = True
        Me.IMPORTE_TOTAL.Visible = False
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_SERIE.DefaultCellStyle = DataGridViewCellStyle5
        Me.INDICA_SERIE.HeaderText = "INDICA_SERIE"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Visible = False
        Me.INDICA_SERIE.Width = 40
        '
        'INDICA_LOTE
        '
        Me.INDICA_LOTE.DataPropertyName = "INDICA_LOTE"
        Me.INDICA_LOTE.HeaderText = "INDICA_LOTE"
        Me.INDICA_LOTE.Name = "INDICA_LOTE"
        Me.INDICA_LOTE.ReadOnly = True
        Me.INDICA_LOTE.Visible = False
        '
        'EXISTE_RESUMEN_ALMACEN
        '
        Me.EXISTE_RESUMEN_ALMACEN.DataPropertyName = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.HeaderText = "ERA"
        Me.EXISTE_RESUMEN_ALMACEN.Name = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.ReadOnly = True
        Me.EXISTE_RESUMEN_ALMACEN.Visible = False
        '
        'EXISTE_RESUMEN_PERIODO
        '
        Me.EXISTE_RESUMEN_PERIODO.DataPropertyName = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.HeaderText = "ERP"
        Me.EXISTE_RESUMEN_PERIODO.Name = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.ReadOnly = True
        Me.EXISTE_RESUMEN_PERIODO.Visible = False
        '
        'ELIMINAR
        '
        Me.ELIMINAR.HeaderText = ""
        Me.ELIMINAR.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.ELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ELIMINAR.Name = "ELIMINAR"
        Me.ELIMINAR.ReadOnly = True
        Me.ELIMINAR.Width = 24
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = CType(resources.GetObject("btnLimpiar.BackgroundImage"), System.Drawing.Image)
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.Location = New System.Drawing.Point(860, 148)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(42, 42)
        Me.btnLimpiar.TabIndex = 116
        Me.btnLimpiar.TabStop = False
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.Moccasin
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReferencia.Location = New System.Drawing.Point(329, 7)
        Me.txtReferencia.MaxLength = 8
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(15, 21)
        Me.txtReferencia.TabIndex = 115
        Me.txtReferencia.TabStop = False
        Me.txtReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtReferencia.Visible = False
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "TEXTO_01"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.Enabled = False
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(457, 8)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(28, 21)
        Me.cmbComprobanteTipo.TabIndex = 85
        Me.cmbComprobanteTipo.TabStop = False
        Me.cmbComprobanteTipo.ValueMember = "CODIGO_ITEM"
        Me.cmbComprobanteTipo.Visible = False
        '
        'txtOrdenPedido
        '
        Me.txtOrdenPedido.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrdenPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrdenPedido.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrdenPedido.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtOrdenPedido.Location = New System.Drawing.Point(437, 8)
        Me.txtOrdenPedido.MaxLength = 8
        Me.txtOrdenPedido.Name = "txtOrdenPedido"
        Me.txtOrdenPedido.Size = New System.Drawing.Size(18, 21)
        Me.txtOrdenPedido.TabIndex = 80
        Me.txtOrdenPedido.TabStop = False
        Me.txtOrdenPedido.Visible = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(409, 7)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(22, 21)
        Me.cmbAlmacen.TabIndex = 79
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        Me.cmbAlmacen.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(393, 7)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 78
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(296, 7)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(27, 21)
        Me.txtVenta.TabIndex = 77
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVenta.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(246, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 18)
        Me.Label15.TabIndex = 102
        Me.Label15.Text = "FECHA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenciaFecha
        '
        Me.txtReferenciaFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtReferenciaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaFecha.Enabled = False
        Me.txtReferenciaFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReferenciaFecha.Location = New System.Drawing.Point(246, 69)
        Me.txtReferenciaFecha.MaxLength = 10
        Me.txtReferenciaFecha.Name = "txtReferenciaFecha"
        Me.txtReferenciaFecha.Size = New System.Drawing.Size(65, 21)
        Me.txtReferenciaFecha.TabIndex = 81
        Me.txtReferenciaFecha.TabStop = False
        Me.txtReferenciaFecha.Tag = "F"
        Me.txtReferenciaFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(8, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(754, 18)
        Me.Label9.TabIndex = 98
        Me.Label9.Text = "COMPROBANTE DE REFERENCIA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(8, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 18)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "TIPO COMPROBANTE"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbReferenciaTipo
        '
        Me.cmbReferenciaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbReferenciaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbReferenciaTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbReferenciaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReferenciaTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbReferenciaTipo.FormattingEnabled = True
        Me.cmbReferenciaTipo.Items.AddRange(New Object() {"FACTURA", "BOLETA DE VENTA"})
        Me.cmbReferenciaTipo.Location = New System.Drawing.Point(8, 69)
        Me.cmbReferenciaTipo.Name = "cmbReferenciaTipo"
        Me.cmbReferenciaTipo.Size = New System.Drawing.Size(125, 21)
        Me.cmbReferenciaTipo.TabIndex = 71
        Me.cmbReferenciaTipo.TabStop = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(175, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 18)
        Me.Label23.TabIndex = 101
        Me.Label23.Text = "NUMERO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(134, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 18)
        Me.Label24.TabIndex = 100
        Me.Label24.Text = "SERIE"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenciaNumero
        '
        Me.txtReferenciaNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferenciaNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferenciaNumero.Location = New System.Drawing.Point(175, 69)
        Me.txtReferenciaNumero.MaxLength = 10
        Me.txtReferenciaNumero.Name = "txtReferenciaNumero"
        Me.txtReferenciaNumero.Size = New System.Drawing.Size(70, 21)
        Me.txtReferenciaNumero.TabIndex = 70
        Me.txtReferenciaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReferenciaSerie
        '
        Me.txtReferenciaSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferenciaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferenciaSerie.Location = New System.Drawing.Point(134, 69)
        Me.txtReferenciaSerie.MaxLength = 4
        Me.txtReferenciaSerie.Name = "txtReferenciaSerie"
        Me.txtReferenciaSerie.Size = New System.Drawing.Size(40, 21)
        Me.txtReferenciaSerie.TabIndex = 69
        Me.txtReferenciaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(758, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "DEVOL."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(758, 169)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(60, 21)
        Me.txtCantidad.TabIndex = 95
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(522, 0)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(389, 20)
        Me.lblComprobante.TabIndex = 97
        Me.lblComprobante.Text = "NOTA DE CREDITO POR DEVOLUCION"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValorExportacionOrige
        '
        Me.txtValorExportacionOrige.BackColor = System.Drawing.Color.Moccasin
        Me.txtValorExportacionOrige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorExportacionOrige.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtValorExportacionOrige.ForeColor = System.Drawing.Color.DarkRed
        Me.txtValorExportacionOrige.Location = New System.Drawing.Point(541, 113)
        Me.txtValorExportacionOrige.MaxLength = 14
        Me.txtValorExportacionOrige.Name = "txtValorExportacionOrige"
        Me.txtValorExportacionOrige.ReadOnly = True
        Me.txtValorExportacionOrige.Size = New System.Drawing.Size(31, 21)
        Me.txtValorExportacionOrige.TabIndex = 89
        Me.txtValorExportacionOrige.TabStop = False
        Me.txtValorExportacionOrige.Tag = "D"
        Me.txtValorExportacionOrige.Text = "0.00"
        Me.txtValorExportacionOrige.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValorExportacionOrige.Visible = False
        '
        'txtImporteInafectoOrigen
        '
        Me.txtImporteInafectoOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteInafectoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteInafectoOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteInafectoOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteInafectoOrigen.Location = New System.Drawing.Point(508, 113)
        Me.txtImporteInafectoOrigen.MaxLength = 14
        Me.txtImporteInafectoOrigen.Name = "txtImporteInafectoOrigen"
        Me.txtImporteInafectoOrigen.ReadOnly = True
        Me.txtImporteInafectoOrigen.Size = New System.Drawing.Size(32, 21)
        Me.txtImporteInafectoOrigen.TabIndex = 88
        Me.txtImporteInafectoOrigen.TabStop = False
        Me.txtImporteInafectoOrigen.Tag = "D"
        Me.txtImporteInafectoOrigen.Text = "0.00"
        Me.txtImporteInafectoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteInafectoOrigen.Visible = False
        '
        'txtOtrosTributosOrigen
        '
        Me.txtOtrosTributosOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtOtrosTributosOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtrosTributosOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtOtrosTributosOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOtrosTributosOrigen.Location = New System.Drawing.Point(573, 113)
        Me.txtOtrosTributosOrigen.MaxLength = 14
        Me.txtOtrosTributosOrigen.Name = "txtOtrosTributosOrigen"
        Me.txtOtrosTributosOrigen.ReadOnly = True
        Me.txtOtrosTributosOrigen.Size = New System.Drawing.Size(31, 21)
        Me.txtOtrosTributosOrigen.TabIndex = 90
        Me.txtOtrosTributosOrigen.TabStop = False
        Me.txtOtrosTributosOrigen.Tag = "D"
        Me.txtOtrosTributosOrigen.Text = "0.00"
        Me.txtOtrosTributosOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOtrosTributosOrigen.Visible = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(704, 94)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(94, 18)
        Me.Label27.TabIndex = 110
        Me.Label27.Text = "IGV"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImpuesto
        '
        Me.txtImpuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImpuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImpuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImpuesto.Location = New System.Drawing.Point(704, 113)
        Me.txtImpuesto.MaxLength = 14
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.ReadOnly = True
        Me.txtImpuesto.Size = New System.Drawing.Size(94, 21)
        Me.txtImpuesto.TabIndex = 92
        Me.txtImpuesto.TabStop = False
        Me.txtImpuesto.Tag = "D"
        Me.txtImpuesto.Text = "0.00"
        Me.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(799, 94)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 18)
        Me.Label29.TabIndex = 111
        Me.Label29.Text = "PRECIO VENTA"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotal.Location = New System.Drawing.Point(799, 113)
        Me.txtImporteTotal.MaxLength = 14
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtImporteTotal.TabIndex = 93
        Me.txtImporteTotal.TabStop = False
        Me.txtImporteTotal.Tag = "D"
        Me.txtImporteTotal.Text = "0.00"
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteExoneradoOrigen
        '
        Me.txtImporteExoneradoOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteExoneradoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteExoneradoOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteExoneradoOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteExoneradoOrigen.Location = New System.Drawing.Point(474, 113)
        Me.txtImporteExoneradoOrigen.MaxLength = 14
        Me.txtImporteExoneradoOrigen.Name = "txtImporteExoneradoOrigen"
        Me.txtImporteExoneradoOrigen.ReadOnly = True
        Me.txtImporteExoneradoOrigen.Size = New System.Drawing.Size(33, 21)
        Me.txtImporteExoneradoOrigen.TabIndex = 87
        Me.txtImporteExoneradoOrigen.TabStop = False
        Me.txtImporteExoneradoOrigen.Tag = "D"
        Me.txtImporteExoneradoOrigen.Text = "0.00"
        Me.txtImporteExoneradoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteExoneradoOrigen.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SteelBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(609, 94)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(94, 18)
        Me.Label31.TabIndex = 109
        Me.Label31.Text = "VALOR VENTA"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBaseImponible
        '
        Me.txtBaseImponible.BackColor = System.Drawing.Color.Moccasin
        Me.txtBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseImponible.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtBaseImponible.ForeColor = System.Drawing.Color.DarkRed
        Me.txtBaseImponible.Location = New System.Drawing.Point(609, 113)
        Me.txtBaseImponible.MaxLength = 14
        Me.txtBaseImponible.Name = "txtBaseImponible"
        Me.txtBaseImponible.ReadOnly = True
        Me.txtBaseImponible.Size = New System.Drawing.Size(94, 21)
        Me.txtBaseImponible.TabIndex = 91
        Me.txtBaseImponible.TabStop = False
        Me.txtBaseImponible.Tag = "D"
        Me.txtBaseImponible.Text = "0.00"
        Me.txtBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(144, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(58, 94)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "NUMERO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(8, 94)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(49, 18)
        Me.Label42.TabIndex = 104
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(144, 113)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 74
        Me.txtComprobanteFecha.TabStop = False
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(58, 113)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 73
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(8, 113)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteSerie.TabIndex = 72
        Me.txtComprobanteSerie.TabStop = False
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(236, 94)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 107
        Me.Label19.Text = "MONEDA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(236, 113)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(85, 21)
        Me.cmbTipoMoneda.TabIndex = 83
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(393, 94)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 18)
        Me.Label22.TabIndex = 108
        Me.Label22.Text = "T. CAMBIO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.Moccasin
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTipoCambio.Location = New System.Drawing.Point(393, 113)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 21)
        Me.txtTipoCambio.TabIndex = 84
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(312, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(450, 18)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "NOMBRE O RAZON SOCIAL DEL CLIENTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Enabled = False
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(312, 69)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(450, 21)
        Me.txtRazonSocial.TabIndex = 82
        Me.txtRazonSocial.TabStop = False
        '
        'cmbProductos
        '
        Me.cmbProductos.BackColor = System.Drawing.Color.Azure
        Me.cmbProductos.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductos.Enabled = False
        Me.cmbProductos.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(8, 169)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(606, 21)
        Me.cmbProductos.TabIndex = 94
        Me.cmbProductos.ValueMember = "LINEA"
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(348, 7)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 75
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
        Me.txtMes.Location = New System.Drawing.Point(371, 7)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 76
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(7, 10)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(186, 18)
        Me.ckbIndicaAnulado.TabIndex = 86
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        Me.ckbIndicaAnulado.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(676, 150)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 18)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "P. UNITARIO"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(676, 169)
        Me.txtPrecioUnitario.MaxLength = 10
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.ReadOnly = True
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(80, 21)
        Me.txtPrecioUnitario.TabIndex = 96
        Me.txtPrecioUnitario.TabStop = False
        Me.txtPrecioUnitario.Tag = "D"
        Me.txtPrecioUnitario.Text = "0.00"
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(8, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(606, 18)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "PRODUCTO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmNotaCreditoPorDevolucion_Old
        '
        Me.ClientSize = New System.Drawing.Size(920, 529)
        Me.Name = "frmNotaCreditoPorDevolucion_Old"
        Me.Text = " NOTA DE CREDITO POR DEVOLUCION"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadVendida As System.Windows.Forms.TextBox
    Friend WithEvents gvVentaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtOrdenPedido As System.Windows.Forms.TextBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbReferenciaTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenciaSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents txtValorExportacionOrige As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteInafectoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtOtrosTributosOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteExoneradoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
