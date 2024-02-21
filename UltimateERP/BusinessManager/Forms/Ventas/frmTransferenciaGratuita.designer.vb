<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaGratuita
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferenciaGratuita))
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCondicionPago = New System.Windows.Forms.ComboBox()
        Me.txtIndicaSerie = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gvVentaLineas = New System.Windows.Forms.DataGridView()
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_COMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCantidadStock = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtLinea = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtImpuesto = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtBaseImponible = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtComprobanteVencimiento = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteSerie = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.txtIndicaCompuesto = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(845, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.txtTelefono)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.cmbDistrito)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.cmbProvincia)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.cmbDepartamento)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.txtIndicaCompuesto)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtImpuesto)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtImporteTotal)
        Me.Panel.Controls.Add(Me.Label31)
        Me.Panel.Controls.Add(Me.txtBaseImponible)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.txtComprobanteVencimiento)
        Me.Panel.Controls.Add(Me.cmbComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel.Controls.Add(Me.txtIndicaSerie)
        Me.Panel.Controls.Add(Me.txtProductoDescripcion)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.gvVentaLineas)
        Me.Panel.Controls.Add(Me.btnNuevo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtCantidadStock)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbCondicionPago)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txtTipoCambio)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Size = New System.Drawing.Size(845, 558)
        Me.Panel.TabIndex = 0
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(11, 31)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(98, 21)
        Me.txtVenta.TabIndex = 13
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "VENTA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(638, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(193, 20)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "VENTA DIRECTA"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(533, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 18)
        Me.Label22.TabIndex = 45
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
        Me.txtTipoCambio.Location = New System.Drawing.Point(533, 31)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 21)
        Me.txtTipoCambio.TabIndex = 21
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(360, 31)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 15
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDocumentoTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 73)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 22
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(149, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(682, 18)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "RAZON SOCIAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 73)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(682, 21)
        Me.txtRazonSocial.TabIndex = 5
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 73)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(11, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(632, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 18)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "CONDICIONES DE PAGO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCondicionPago
        '
        Me.cmbCondicionPago.BackColor = System.Drawing.Color.Azure
        Me.cmbCondicionPago.DisplayMember = "DESCRIPCION"
        Me.cmbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCondicionPago.FormattingEnabled = True
        Me.cmbCondicionPago.Location = New System.Drawing.Point(632, 157)
        Me.cmbCondicionPago.Name = "cmbCondicionPago"
        Me.cmbCondicionPago.Size = New System.Drawing.Size(199, 21)
        Me.cmbCondicionPago.TabIndex = 9
        Me.cmbCondicionPago.TabStop = False
        Me.cmbCondicionPago.ValueMember = "CODIGO"
        '
        'txtIndicaSerie
        '
        Me.txtIndicaSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaSerie.Location = New System.Drawing.Point(1, 303)
        Me.txtIndicaSerie.MaxLength = 1
        Me.txtIndicaSerie.Name = "txtIndicaSerie"
        Me.txtIndicaSerie.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaSerie.TabIndex = 36
        Me.txtIndicaSerie.TabStop = False
        Me.txtIndicaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaSerie.Visible = False
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(75, 254)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(469, 21)
        Me.txtProductoDescripcion.TabIndex = 31
        Me.txtProductoDescripcion.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(11, 254)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(63, 21)
        Me.txtProducto.TabIndex = 1
        Me.txtProducto.Tag = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(11, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(533, 18)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvVentaLineas
        '
        Me.gvVentaLineas.AllowUserToAddRows = False
        Me.gvVentaLineas.AllowUserToDeleteRows = False
        Me.gvVentaLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvVentaLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentaLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.gvVentaLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.PRECIO_UNITARIO, Me.CANTIDAD, Me.IMPORTE_TOTAL, Me.INDICA_SERIE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.INDICA_COMPUESTO, Me.ELIMINAR})
        Me.gvVentaLineas.EnableHeadersVisualStyles = False
        Me.gvVentaLineas.Location = New System.Drawing.Point(11, 276)
        Me.gvVentaLineas.MultiSelect = False
        Me.gvVentaLineas.Name = "gvVentaLineas"
        Me.gvVentaLineas.ReadOnly = True
        Me.gvVentaLineas.RowHeadersVisible = False
        Me.gvVentaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.OldLace
        Me.gvVentaLineas.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.gvVentaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentaLineas.Size = New System.Drawing.Size(820, 265)
        Me.gvVentaLineas.TabIndex = 34
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
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "CODIGO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 65
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 500
        '
        'PRECIO_UNITARIO
        '
        Me.PRECIO_UNITARIO.DataPropertyName = "PRECIO_UNITARIO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle11
        Me.PRECIO_UNITARIO.HeaderText = "P. UNIT"
        Me.PRECIO_UNITARIO.Name = "PRECIO_UNITARIO"
        Me.PRECIO_UNITARIO.ReadOnly = True
        Me.PRECIO_UNITARIO.Width = 75
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle12
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 60
        '
        'IMPORTE_TOTAL
        '
        Me.IMPORTE_TOTAL.DataPropertyName = "IMPORTE_TOTAL"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        Me.IMPORTE_TOTAL.DefaultCellStyle = DataGridViewCellStyle13
        Me.IMPORTE_TOTAL.HeaderText = "P.VENTA"
        Me.IMPORTE_TOTAL.Name = "IMPORTE_TOTAL"
        Me.IMPORTE_TOTAL.ReadOnly = True
        Me.IMPORTE_TOTAL.Width = 70
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_SERIE.DefaultCellStyle = DataGridViewCellStyle14
        Me.INDICA_SERIE.HeaderText = "SERIE"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Visible = False
        Me.INDICA_SERIE.Width = 40
        '
        'EXISTE_RESUMEN_ALMACEN
        '
        Me.EXISTE_RESUMEN_ALMACEN.DataPropertyName = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.HeaderText = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.Name = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.ReadOnly = True
        Me.EXISTE_RESUMEN_ALMACEN.Visible = False
        '
        'EXISTE_RESUMEN_PERIODO
        '
        Me.EXISTE_RESUMEN_PERIODO.DataPropertyName = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.HeaderText = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.Name = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.ReadOnly = True
        Me.EXISTE_RESUMEN_PERIODO.Visible = False
        '
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_COMPUESTO.DefaultCellStyle = DataGridViewCellStyle15
        Me.INDICA_COMPUESTO.HeaderText = "IC"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        Me.INDICA_COMPUESTO.Width = 40
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
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(545, 235)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 18)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "STOCK"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidadStock
        '
        Me.txtCantidadStock.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadStock.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadStock.Location = New System.Drawing.Point(545, 254)
        Me.txtCantidadStock.MaxLength = 10
        Me.txtCantidadStock.Name = "txtCantidadStock"
        Me.txtCantidadStock.ReadOnly = True
        Me.txtCantidadStock.Size = New System.Drawing.Size(60, 21)
        Me.txtCantidadStock.TabIndex = 32
        Me.txtCantidadStock.TabStop = False
        Me.txtCantidadStock.Tag = "Z"
        Me.txtCantidadStock.Text = "0"
        Me.txtCantidadStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(677, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 66
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
        Me.txtCantidad.Location = New System.Drawing.Point(677, 254)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(70, 21)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.Enabled = False
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(2, 276)
        Me.txtLinea.MaxLength = 3
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.ReadOnly = True
        Me.txtLinea.Size = New System.Drawing.Size(8, 21)
        Me.txtLinea.TabIndex = 35
        Me.txtLinea.Tag = ""
        Me.txtLinea.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(606, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "P. UNIT."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Enabled = False
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(606, 254)
        Me.txtPrecioUnitario.MaxLength = 10
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(70, 21)
        Me.txtPrecioUnitario.TabIndex = 2
        Me.txtPrecioUnitario.Tag = "D"
        Me.txtPrecioUnitario.Text = "0.00"
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(625, 34)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(206, 18)
        Me.ckbIndicaAnulado.TabIndex = 38
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        Me.ckbIndicaAnulado.Visible = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(375, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 16
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
        Me.txtMes.Location = New System.Drawing.Point(398, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 17
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(111, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(243, 18)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "ALMACEN"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.Enabled = False
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(111, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(243, 21)
        Me.cmbAlmacen.TabIndex = 14
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(638, 180)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 18)
        Me.Label27.TabIndex = 61
        Me.Label27.Text = "IGV"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImpuesto
        '
        Me.txtImpuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImpuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImpuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImpuesto.Location = New System.Drawing.Point(638, 199)
        Me.txtImpuesto.MaxLength = 14
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.ReadOnly = True
        Me.txtImpuesto.Size = New System.Drawing.Size(89, 21)
        Me.txtImpuesto.TabIndex = 29
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
        Me.Label29.Location = New System.Drawing.Point(728, 180)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 18)
        Me.Label29.TabIndex = 62
        Me.Label29.Text = "PRECIO VENTA"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotal.Location = New System.Drawing.Point(728, 199)
        Me.txtImporteTotal.MaxLength = 14
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtImporteTotal.TabIndex = 30
        Me.txtImporteTotal.TabStop = False
        Me.txtImporteTotal.Tag = "D"
        Me.txtImporteTotal.Text = "0.00"
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SteelBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(543, 180)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(94, 18)
        Me.Label31.TabIndex = 60
        Me.Label31.Text = "VALOR VENTA"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBaseImponible
        '
        Me.txtBaseImponible.BackColor = System.Drawing.Color.Moccasin
        Me.txtBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseImponible.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtBaseImponible.ForeColor = System.Drawing.Color.DarkRed
        Me.txtBaseImponible.Location = New System.Drawing.Point(543, 199)
        Me.txtBaseImponible.MaxLength = 14
        Me.txtBaseImponible.Name = "txtBaseImponible"
        Me.txtBaseImponible.ReadOnly = True
        Me.txtBaseImponible.Size = New System.Drawing.Size(94, 21)
        Me.txtBaseImponible.TabIndex = 28
        Me.txtBaseImponible.TabStop = False
        Me.txtBaseImponible.Tag = "D"
        Me.txtBaseImponible.Text = "0.00"
        Me.txtBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 18)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "TIPO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(386, 180)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(156, 18)
        Me.Label19.TabIndex = 59
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(386, 199)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(156, 21)
        Me.cmbTipoMoneda.TabIndex = 12
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(311, 180)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 18)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "F. VCMTO."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteVencimiento
        '
        Me.txtComprobanteVencimiento.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteVencimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteVencimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteVencimiento.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteVencimiento.Location = New System.Drawing.Point(311, 199)
        Me.txtComprobanteVencimiento.MaxLength = 10
        Me.txtComprobanteVencimiento.Name = "txtComprobanteVencimiento"
        Me.txtComprobanteVencimiento.ReadOnly = True
        Me.txtComprobanteVencimiento.Size = New System.Drawing.Size(74, 21)
        Me.txtComprobanteVencimiento.TabIndex = 27
        Me.txtComprobanteVencimiento.TabStop = False
        Me.txtComprobanteVencimiento.Tag = "F"
        Me.txtComprobanteVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbComprobanteSerie
        '
        Me.cmbComprobanteSerie.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteSerie.DisplayMember = "CODIGO"
        Me.cmbComprobanteSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteSerie.Enabled = False
        Me.cmbComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteSerie.FormattingEnabled = True
        Me.cmbComprobanteSerie.Location = New System.Drawing.Point(93, 199)
        Me.cmbComprobanteSerie.Name = "cmbComprobanteSerie"
        Me.cmbComprobanteSerie.Size = New System.Drawing.Size(55, 21)
        Me.cmbComprobanteSerie.TabIndex = 11
        Me.cmbComprobanteSerie.TabStop = False
        Me.cmbComprobanteSerie.ValueMember = "CODIGO"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(236, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 18)
        Me.Label14.TabIndex = 57
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
        Me.Label17.Location = New System.Drawing.Point(150, 180)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 56
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
        Me.Label42.Location = New System.Drawing.Point(93, 180)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(55, 18)
        Me.Label42.TabIndex = 55
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
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(236, 199)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.ReadOnly = True
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(74, 21)
        Me.txtComprobanteFecha.TabIndex = 26
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(150, 199)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.ReadOnly = True
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 25
        Me.txtComprobanteNumero.TabStop = False
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Items.AddRange(New Object() {"FACTURA", "BOLETA"})
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(11, 199)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(81, 21)
        Me.cmbComprobanteTipo.TabIndex = 10
        Me.cmbComprobanteTipo.TabStop = False
        '
        'txtIndicaCompuesto
        '
        Me.txtIndicaCompuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaCompuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaCompuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaCompuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaCompuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaCompuesto.Location = New System.Drawing.Point(0, 330)
        Me.txtIndicaCompuesto.MaxLength = 1
        Me.txtIndicaCompuesto.Name = "txtIndicaCompuesto"
        Me.txtIndicaCompuesto.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaCompuesto.TabIndex = 37
        Me.txtIndicaCompuesto.TabStop = False
        Me.txtIndicaCompuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaCompuesto.Visible = False
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(11, 96)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(628, 18)
        Me.Label43.TabIndex = 48
        Me.Label43.Text = "DOMICILIO FISCAL"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.Moccasin
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDomicilio.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDomicilio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDomicilio.Location = New System.Drawing.Point(11, 115)
        Me.txtDomicilio.MaxLength = 150
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(628, 21)
        Me.txtDomicilio.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(641, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(190, 18)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "REGION"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.BackColor = System.Drawing.Color.Azure
        Me.cmbDepartamento.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.Enabled = False
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(641, 114)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(190, 21)
        Me.cmbDepartamento.TabIndex = 23
        Me.cmbDepartamento.ValueMember = "CODIGO"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(273, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 18)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "DISTRITO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDistrito
        '
        Me.cmbDistrito.BackColor = System.Drawing.Color.Azure
        Me.cmbDistrito.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrito.Enabled = False
        Me.cmbDistrito.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(273, 157)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(262, 21)
        Me.cmbDistrito.TabIndex = 8
        Me.cmbDistrito.ValueMember = "CODIGO"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(261, 18)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "PROVINCIA"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.Azure
        Me.cmbProvincia.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(11, 157)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(261, 21)
        Me.cmbProvincia.TabIndex = 7
        Me.cmbProvincia.ValueMember = "CODIGO"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.Moccasin
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTelefono.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTelefono.Location = New System.Drawing.Point(537, 157)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(93, 21)
        Me.txtTelefono.TabIndex = 67
        Me.txtTelefono.TabStop = False
        Me.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.SteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(537, 138)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 18)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "TELEFONO"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 24
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(789, 233)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(42, 42)
        Me.btnNuevo.TabIndex = 33
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.Location = New System.Drawing.Point(748, 233)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'frmVentaDirecta
        '
        Me.ClientSize = New System.Drawing.Size(845, 612)
        Me.Name = "frmVentaDirecta"
        Me.Text = " VENTA DIRECTA"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtIndicaSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gvVentaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadStock As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteSerie As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Public WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaCompuesto As System.Windows.Forms.TextBox
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_COMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox

End Class
