<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCreditoVehiculo
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtReferenciaFecha = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbReferenciaTipo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtReferenciaNumero = New System.Windows.Forms.TextBox()
        Me.txtReferenciaSerie = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.txtNotaCredito = New System.Windows.Forms.TextBox()
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
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(530, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtNotaCredito)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.gvVentaLineas)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtImporteTotal)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtReferenciaFecha)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.cmbReferenciaTipo)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtReferenciaNumero)
        Me.Panel.Controls.Add(Me.txtReferenciaSerie)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Size = New System.Drawing.Size(530, 446)
        Me.Panel.TabIndex = 0
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(236, 0)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(286, 20)
        Me.lblComprobante.TabIndex = 14
        Me.lblComprobante.Text = "NOTA DE CREDITO VEHICULAR"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(269, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 18)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "FECHA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenciaFecha
        '
        Me.txtReferenciaFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtReferenciaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReferenciaFecha.Location = New System.Drawing.Point(269, 69)
        Me.txtReferenciaFecha.MaxLength = 10
        Me.txtReferenciaFecha.Name = "txtReferenciaFecha"
        Me.txtReferenciaFecha.Size = New System.Drawing.Size(75, 21)
        Me.txtReferenciaFecha.TabIndex = 5
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
        Me.Label9.Location = New System.Drawing.Point(11, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(505, 18)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "COMPROBANTE DE REFERENCIA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 18)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "TIPO"
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
        Me.cmbReferenciaTipo.Location = New System.Drawing.Point(11, 69)
        Me.cmbReferenciaTipo.Name = "cmbReferenciaTipo"
        Me.cmbReferenciaTipo.Size = New System.Drawing.Size(125, 21)
        Me.cmbReferenciaTipo.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(188, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 18)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "NUMERO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(137, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 18)
        Me.Label24.TabIndex = 17
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
        Me.txtReferenciaNumero.Location = New System.Drawing.Point(188, 69)
        Me.txtReferenciaNumero.MaxLength = 10
        Me.txtReferenciaNumero.Name = "txtReferenciaNumero"
        Me.txtReferenciaNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtReferenciaNumero.TabIndex = 2
        Me.txtReferenciaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReferenciaSerie
        '
        Me.txtReferenciaSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtReferenciaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferenciaSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtReferenciaSerie.Location = New System.Drawing.Point(137, 69)
        Me.txtReferenciaSerie.MaxLength = 4
        Me.txtReferenciaSerie.Name = "txtReferenciaSerie"
        Me.txtReferenciaSerie.Size = New System.Drawing.Size(50, 21)
        Me.txtReferenciaSerie.TabIndex = 1
        Me.txtReferenciaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(11, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(505, 18)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "NOMBRE O RAZON SOCIAL DEL CLIENTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(11, 112)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(505, 21)
        Me.txtRazonSocial.TabIndex = 8
        Me.txtRazonSocial.TabStop = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(345, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 20
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
        Me.cmbTipoMoneda.Enabled = False
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(345, 69)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(85, 21)
        Me.cmbTipoMoneda.TabIndex = 6
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(431, 50)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 18)
        Me.Label29.TabIndex = 21
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotal.Location = New System.Drawing.Point(431, 69)
        Me.txtImporteTotal.MaxLength = 14
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(85, 21)
        Me.txtImporteTotal.TabIndex = 7
        Me.txtImporteTotal.TabStop = False
        Me.txtImporteTotal.Tag = "D"
        Me.txtImporteTotal.Text = "0.00"
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(143, 162)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 18)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "FECHA"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(62, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 18)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "NUMERO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(11, 162)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(50, 18)
        Me.Label42.TabIndex = 24
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
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(143, 181)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(75, 21)
        Me.txtComprobanteFecha.TabIndex = 11
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(62, 181)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtComprobanteNumero.TabIndex = 10
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(11, 181)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(50, 21)
        Me.txtComprobanteSerie.TabIndex = 9
        Me.txtComprobanteSerie.TabStop = False
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(219, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(297, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "COMENTARIO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(219, 181)
        Me.txtComentario.MaxLength = 200
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(297, 21)
        Me.txtComentario.TabIndex = 3
        Me.txtComentario.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(505, 18)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "NOTA DE CREDITO EMITIDA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.gvVentaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.PRECIO_UNITARIO, Me.CANTIDAD, Me.IMPORTE_TOTAL, Me.INDICA_SERIE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.INDICA_COMPUESTO})
        Me.gvVentaLineas.EnableHeadersVisualStyles = False
        Me.gvVentaLineas.Location = New System.Drawing.Point(11, 204)
        Me.gvVentaLineas.MultiSelect = False
        Me.gvVentaLineas.Name = "gvVentaLineas"
        Me.gvVentaLineas.ReadOnly = True
        Me.gvVentaLineas.RowHeadersVisible = False
        Me.gvVentaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.OldLace
        Me.gvVentaLineas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gvVentaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentaLineas.Size = New System.Drawing.Size(505, 229)
        Me.gvVentaLineas.TabIndex = 12
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
        Me.DESCRIPCION_AMPLIADA.Width = 420
        '
        'PRECIO_UNITARIO
        '
        Me.PRECIO_UNITARIO.DataPropertyName = "PRECIO_UNITARIO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle3
        Me.PRECIO_UNITARIO.HeaderText = "P. UNIT"
        Me.PRECIO_UNITARIO.Name = "PRECIO_UNITARIO"
        Me.PRECIO_UNITARIO.ReadOnly = True
        Me.PRECIO_UNITARIO.Visible = False
        Me.PRECIO_UNITARIO.Width = 75
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
        Me.CANTIDAD.Width = 60
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
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.HeaderText = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(11, 10)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(186, 18)
        Me.ckbIndicaAnulado.TabIndex = 4
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        Me.ckbIndicaAnulado.Visible = False
        '
        'txtNotaCredito
        '
        Me.txtNotaCredito.BackColor = System.Drawing.Color.Moccasin
        Me.txtNotaCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotaCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotaCredito.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaCredito.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNotaCredito.Location = New System.Drawing.Point(203, 7)
        Me.txtNotaCredito.MaxLength = 8
        Me.txtNotaCredito.Name = "txtNotaCredito"
        Me.txtNotaCredito.ReadOnly = True
        Me.txtNotaCredito.Size = New System.Drawing.Size(10, 21)
        Me.txtNotaCredito.TabIndex = 13
        Me.txtNotaCredito.TabStop = False
        Me.txtNotaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNotaCredito.Visible = False
        '
        'frmNotaCreditoVehiculo
        '
        Me.ClientSize = New System.Drawing.Size(530, 500)
        Me.Name = "frmNotaCreditoVehiculo"
        Me.Text = " NOTA DE CREDITO VEHICULAR"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbReferenciaTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenciaSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents gvVentaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
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
    Friend WithEvents txtNotaCredito As System.Windows.Forms.TextBox

End Class
