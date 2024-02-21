<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaIngresoAlmacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaIngresoAlmacen))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtComprobanteImporte = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbComprobanteTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOperacionFecha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCantidadStock = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.gvOperacionAlmacenLineas = New System.Windows.Forms.DataGridView()
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO_MN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO_ME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtIndicaSerie = New System.Windows.Forms.TextBox()
        Me.txtLinea = New System.Windows.Forms.TextBox()
        Me.Panel.SuspendLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(878, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtIndicaSerie)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.gvOperacionAlmacenLineas)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel.Controls.Add(Me.txtProductoDescripcion)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.btnNuevo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtCantidadStock)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtComprobanteImporte)
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
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtOperacionFecha)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbTipoOperacion)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtOperacion)
        Me.Panel.Size = New System.Drawing.Size(878, 572)
        Me.Panel.TabIndex = 0
        '
        'txtComentario
        '
        Me.txtComentario.AcceptsReturn = True
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(103, 74)
        Me.txtComentario.MaxLength = 150
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(761, 21)
        Me.txtComentario.TabIndex = 1
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(610, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(34, 21)
        Me.txtEjercicio.TabIndex = 24
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
        Me.txtMes.Location = New System.Drawing.Point(645, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(17, 21)
        Me.txtMes.TabIndex = 25
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(667, 31)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(13, 21)
        Me.txtCuentaComercial.TabIndex = 26
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCuentaComercial.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(744, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 18)
        Me.Label12.TabIndex = 40
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
        Me.txtComprobanteImporte.Location = New System.Drawing.Point(744, 160)
        Me.txtComprobanteImporte.MaxLength = 12
        Me.txtComprobanteImporte.Name = "txtComprobanteImporte"
        Me.txtComprobanteImporte.Size = New System.Drawing.Size(120, 21)
        Me.txtComprobanteImporte.TabIndex = 19
        Me.txtComprobanteImporte.TabStop = False
        Me.txtComprobanteImporte.Tag = "D"
        Me.txtComprobanteImporte.Text = "0.00"
        Me.txtComprobanteImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(11, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(222, 18)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "TIPO DE COMPROBANTE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "DESCRIPCION"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(11, 160)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(222, 21)
        Me.cmbComprobanteTipo.TabIndex = 8
        Me.cmbComprobanteTipo.TabStop = False
        Me.cmbComprobanteTipo.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(351, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "F. EMISION"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(277, 141)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 18)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "NUMERO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(234, 141)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(42, 18)
        Me.Label42.TabIndex = 36
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
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(351, 160)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(72, 21)
        Me.txtComprobanteFecha.TabIndex = 11
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(277, 160)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(73, 21)
        Me.txtComprobanteNumero.TabIndex = 10
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(234, 160)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(42, 21)
        Me.txtComprobanteSerie.TabIndex = 9
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(616, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 18)
        Me.Label18.TabIndex = 39
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
        Me.cmbComprobanteTipoMoneda.Location = New System.Drawing.Point(616, 160)
        Me.cmbComprobanteTipoMoneda.Name = "cmbComprobanteTipoMoneda"
        Me.cmbComprobanteTipoMoneda.Size = New System.Drawing.Size(127, 21)
        Me.cmbComprobanteTipoMoneda.TabIndex = 12
        Me.cmbComprobanteTipoMoneda.ValueMember = "CODIGO"
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 117)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 45
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(183, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(681, 18)
        Me.Label4.TabIndex = 34
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(183, 117)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(681, 21)
        Me.txtRazonSocial.TabIndex = 18
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 117)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(114, 21)
        Me.txtDocumentoNumero.TabIndex = 7
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(11, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 18)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "DOCUMENTO IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.SteelBlue
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(103, 55)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(761, 18)
        Me.Label36.TabIndex = 32
        Me.Label36.Text = "COMENTARIO"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(612, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(255, 20)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "NOTA DE INGRESO ALMACEN"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(686, 32)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(178, 20)
        Me.ckbIndicaAnulado.TabIndex = 15
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "OPERACION ANULADA"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = False
        Me.ckbIndicaAnulado.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 18)
        Me.Label13.TabIndex = 31
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
        Me.txtOperacionFecha.Location = New System.Drawing.Point(11, 74)
        Me.txtOperacionFecha.MaxLength = 50
        Me.txtOperacionFecha.Name = "txtOperacionFecha"
        Me.txtOperacionFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtOperacionFecha.TabIndex = 0
        Me.txtOperacionFecha.Tag = "F"
        Me.txtOperacionFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 18)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "TIPO DE OPERACION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoOperacion.DisplayMember = "NOMBRE_LARGO"
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(11, 31)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(261, 21)
        Me.cmbTipoOperacion.TabIndex = 13
        Me.cmbTipoOperacion.ValueMember = "CODIGO_ITEM"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(273, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 18)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "ALMACEN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.Enabled = False
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(273, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(245, 21)
        Me.cmbAlmacen.TabIndex = 14
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(521, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 18)
        Me.Label33.TabIndex = 30
        Me.Label33.Text = "OPERACION"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacion
        '
        Me.txtOperacion.BackColor = System.Drawing.Color.Moccasin
        Me.txtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOperacion.Location = New System.Drawing.Point(521, 31)
        Me.txtOperacion.MaxLength = 8
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.ReadOnly = True
        Me.txtOperacion.Size = New System.Drawing.Size(84, 21)
        Me.txtOperacion.TabIndex = 17
        Me.txtOperacion.TabStop = False
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(75, 207)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(491, 21)
        Me.txtProductoDescripcion.TabIndex = 20
        Me.txtProductoDescripcion.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(11, 207)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(63, 21)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.Tag = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(11, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(555, 18)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(822, 186)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(42, 42)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(572, 188)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 18)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "STOCK"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidadStock
        '
        Me.txtCantidadStock.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadStock.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadStock.Location = New System.Drawing.Point(572, 207)
        Me.txtCantidadStock.MaxLength = 10
        Me.txtCantidadStock.Name = "txtCantidadStock"
        Me.txtCantidadStock.ReadOnly = True
        Me.txtCantidadStock.Size = New System.Drawing.Size(60, 21)
        Me.txtCantidadStock.TabIndex = 21
        Me.txtCantidadStock.TabStop = False
        Me.txtCantidadStock.Tag = "Z"
        Me.txtCantidadStock.Text = "0"
        Me.txtCantidadStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(781, 186)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.UseVisualStyleBackColor = False
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
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(711, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 18)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "CANTIDAD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(711, 207)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(68, 21)
        Me.txtCantidad.TabIndex = 4
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(633, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 18)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "COST. UNIT."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(633, 207)
        Me.txtPrecioUnitario.MaxLength = 12
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(77, 21)
        Me.txtPrecioUnitario.TabIndex = 3
        Me.txtPrecioUnitario.Tag = "V"
        Me.txtPrecioUnitario.Text = "0.0000"
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.gvOperacionAlmacenLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.CODIGO_COMPRA, Me.DESCRIPCION_AMPLIADA, Me.PRECIO_UNITARIO_MN, Me.PRECIO_UNITARIO_ME, Me.CANTIDAD, Me.NUMERO_LOTE, Me.FECHA_VENCIMIENTO, Me.INDICA_SERIE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.ELIMINAR})
        Me.gvOperacionAlmacenLineas.EnableHeadersVisualStyles = False
        Me.gvOperacionAlmacenLineas.Location = New System.Drawing.Point(11, 231)
        Me.gvOperacionAlmacenLineas.MultiSelect = False
        Me.gvOperacionAlmacenLineas.Name = "gvOperacionAlmacenLineas"
        Me.gvOperacionAlmacenLineas.ReadOnly = True
        Me.gvOperacionAlmacenLineas.RowHeadersVisible = False
        Me.gvOperacionAlmacenLineas.RowHeadersWidth = 20
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.OldLace
        Me.gvOperacionAlmacenLineas.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gvOperacionAlmacenLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOperacionAlmacenLineas.Size = New System.Drawing.Size(853, 328)
        Me.gvOperacionAlmacenLineas.TabIndex = 6
        Me.gvOperacionAlmacenLineas.TabStop = False
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
        'CODIGO_COMPRA
        '
        Me.CODIGO_COMPRA.DataPropertyName = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.HeaderText = "CODIGO_COMPRA"
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
        Me.DESCRIPCION_AMPLIADA.Width = 450
        '
        'PRECIO_UNITARIO_MN
        '
        Me.PRECIO_UNITARIO_MN.DataPropertyName = "PRECIO_UNITARIO_MN"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PRECIO_UNITARIO_MN.DefaultCellStyle = DataGridViewCellStyle3
        Me.PRECIO_UNITARIO_MN.HeaderText = "C.U. MN"
        Me.PRECIO_UNITARIO_MN.Name = "PRECIO_UNITARIO_MN"
        Me.PRECIO_UNITARIO_MN.ReadOnly = True
        Me.PRECIO_UNITARIO_MN.Width = 90
        '
        'PRECIO_UNITARIO_ME
        '
        Me.PRECIO_UNITARIO_ME.DataPropertyName = "PRECIO_UNITARIO_ME"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N4"
        Me.PRECIO_UNITARIO_ME.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRECIO_UNITARIO_ME.HeaderText = "C.U. ME"
        Me.PRECIO_UNITARIO_ME.Name = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.ReadOnly = True
        Me.PRECIO_UNITARIO_ME.Width = 90
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle5
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 70
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NUMERO_LOTE.DefaultCellStyle = DataGridViewCellStyle6
        Me.NUMERO_LOTE.HeaderText = "NRO LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        Me.NUMERO_LOTE.Visible = False
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "VCMTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Visible = False
        Me.FECHA_VENCIMIENTO.Width = 70
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        Me.INDICA_SERIE.HeaderText = "IS"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Visible = False
        Me.INDICA_SERIE.Width = 30
        '
        'EXISTE_RESUMEN_ALMACEN
        '
        Me.EXISTE_RESUMEN_ALMACEN.DataPropertyName = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.HeaderText = "ERA"
        Me.EXISTE_RESUMEN_ALMACEN.Name = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.ReadOnly = True
        Me.EXISTE_RESUMEN_ALMACEN.Visible = False
        Me.EXISTE_RESUMEN_ALMACEN.Width = 30
        '
        'EXISTE_RESUMEN_PERIODO
        '
        Me.EXISTE_RESUMEN_PERIODO.DataPropertyName = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.HeaderText = "ERP"
        Me.EXISTE_RESUMEN_PERIODO.Name = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.ReadOnly = True
        Me.EXISTE_RESUMEN_PERIODO.Visible = False
        Me.EXISTE_RESUMEN_PERIODO.Width = 30
        '
        'ELIMINAR
        '
        Me.ELIMINAR.HeaderText = ""
        Me.ELIMINAR.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.ELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ELIMINAR.Name = "ELIMINAR"
        Me.ELIMINAR.ReadOnly = True
        Me.ELIMINAR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ELIMINAR.Width = 24
        '
        'txtIndicaSerie
        '
        Me.txtIndicaSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaSerie.Location = New System.Drawing.Point(0, 299)
        Me.txtIndicaSerie.MaxLength = 1
        Me.txtIndicaSerie.Name = "txtIndicaSerie"
        Me.txtIndicaSerie.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaSerie.TabIndex = 23
        Me.txtIndicaSerie.TabStop = False
        Me.txtIndicaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaSerie.Visible = False
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.Enabled = False
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(1, 272)
        Me.txtLinea.MaxLength = 3
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.ReadOnly = True
        Me.txtLinea.Size = New System.Drawing.Size(8, 21)
        Me.txtLinea.TabIndex = 22
        Me.txtLinea.Tag = ""
        Me.txtLinea.Visible = False
        '
        'frmNotaIngresoAlmacen
        '
        Me.ClientSize = New System.Drawing.Size(878, 626)
        Me.Name = "frmNotaIngresoAlmacen"
        Me.Text = "  NOTA DE INGRESO ALMACEN"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteImporte As System.Windows.Forms.TextBox
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
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOperacionFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtOperacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadStock As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents gvOperacionAlmacenLineas As System.Windows.Forms.DataGridView
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents txtIndicaSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_MN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn

End Class
