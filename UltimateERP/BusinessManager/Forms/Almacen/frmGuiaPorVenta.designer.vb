<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaPorVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaPorVenta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.txtVendedorCodigo = New System.Windows.Forms.TextBox()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPlaca = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbConductor = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtComprobanteFechaTraslado = New System.Windows.Forms.TextBox()
        Me.cmbDireccionEnvio = New System.Windows.Forms.ComboBox()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteSerie = New System.Windows.Forms.ComboBox()
        Me.txtComentarioPedido = New System.Windows.Forms.TextBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(707, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.gvVentaLineas)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.txtComentarioPedido)
        Me.Panel.Controls.Add(Me.cmbComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.txtReferencia)
        Me.Panel.Controls.Add(Me.cmbDireccionEnvio)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbPlaca)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbConductor)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtComprobanteFechaTraslado)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtComprobante)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txtTipoCambio)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.txtVendedorCodigo)
        Me.Panel.Controls.Add(Me.txtGuia)
        Me.Panel.Size = New System.Drawing.Size(707, 522)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1350, 689)
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(751, 186)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 20
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(380, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 18)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "T. CAMBIO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label22.Visible = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.Moccasin
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTipoCambio.Location = New System.Drawing.Point(380, 30)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 21)
        Me.txtTipoCambio.TabIndex = 8
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(12, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(682, 18)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "RAZON SOCIAL"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(12, 72)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(682, 21)
        Me.txtRazonSocial.TabIndex = 9
        Me.txtRazonSocial.TabStop = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(729, 160)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(10, 21)
        Me.txtEjercicio.TabIndex = 14
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
        Me.txtMes.Location = New System.Drawing.Point(708, 160)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(10, 21)
        Me.txtMes.TabIndex = 13
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(508, 33)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(186, 18)
        Me.ckbIndicaAnulado.TabIndex = 22
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        '
        'txtVendedorCodigo
        '
        Me.txtVendedorCodigo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtVendedorCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendedorCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedorCodigo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendedorCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtVendedorCodigo.Location = New System.Drawing.Point(773, 186)
        Me.txtVendedorCodigo.MaxLength = 7
        Me.txtVendedorCodigo.Name = "txtVendedorCodigo"
        Me.txtVendedorCodigo.Size = New System.Drawing.Size(10, 21)
        Me.txtVendedorCodigo.TabIndex = 21
        Me.txtVendedorCodigo.TabStop = False
        Me.txtVendedorCodigo.Tag = ""
        Me.txtVendedorCodigo.Visible = False
        '
        'txtGuia
        '
        Me.txtGuia.BackColor = System.Drawing.Color.Moccasin
        Me.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGuia.Location = New System.Drawing.Point(465, 29)
        Me.txtGuia.MaxLength = 8
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(10, 21)
        Me.txtGuia.TabIndex = 19
        Me.txtGuia.TabStop = False
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGuia.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DimGray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(152, 143)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(66, 143)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "NUMERO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.DimGray
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(12, 143)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(53, 18)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(152, 162)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 1
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(66, 162)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.ReadOnly = True
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 12
        Me.txtComprobanteNumero.TabStop = False
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(129, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(243, 18)
        Me.Label18.TabIndex = 25
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
        Me.cmbAlmacen.Location = New System.Drawing.Point(129, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(243, 21)
        Me.cmbAlmacen.TabIndex = 7
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
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
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.Azure
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobante.Location = New System.Drawing.Point(12, 31)
        Me.txtComprobante.MaxLength = 12
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(114, 21)
        Me.txtComprobante.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 18)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "COMPROBANTE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(472, -1)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(227, 20)
        Me.lblComprobante.TabIndex = 23
        Me.lblComprobante.Text = "GUIA DE REMISION POR VENTA"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(12, 94)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(682, 18)
        Me.Label43.TabIndex = 28
        Me.Label43.Text = "DOMICILIO DE ENVIO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DimGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(571, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 18)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "PLACA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPlaca
        '
        Me.cmbPlaca.BackColor = System.Drawing.Color.Azure
        Me.cmbPlaca.DisplayMember = "DESCRIPCION"
        Me.cmbPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlaca.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPlaca.FormattingEnabled = True
        Me.cmbPlaca.Location = New System.Drawing.Point(571, 162)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.Size = New System.Drawing.Size(123, 21)
        Me.cmbPlaca.TabIndex = 4
        Me.cmbPlaca.TabStop = False
        Me.cmbPlaca.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(336, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "CONDUCTOR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbConductor
        '
        Me.cmbConductor.BackColor = System.Drawing.Color.Azure
        Me.cmbConductor.DisplayMember = "DESCRIPCION"
        Me.cmbConductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConductor.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbConductor.FormattingEnabled = True
        Me.cmbConductor.Location = New System.Drawing.Point(336, 162)
        Me.cmbConductor.Name = "cmbConductor"
        Me.cmbConductor.Size = New System.Drawing.Size(234, 21)
        Me.cmbConductor.TabIndex = 3
        Me.cmbConductor.TabStop = False
        Me.cmbConductor.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(244, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 18)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "F. TRASLADO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFechaTraslado
        '
        Me.txtComprobanteFechaTraslado.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFechaTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFechaTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFechaTraslado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFechaTraslado.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFechaTraslado.Location = New System.Drawing.Point(244, 162)
        Me.txtComprobanteFechaTraslado.MaxLength = 10
        Me.txtComprobanteFechaTraslado.Name = "txtComprobanteFechaTraslado"
        Me.txtComprobanteFechaTraslado.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFechaTraslado.TabIndex = 2
        Me.txtComprobanteFechaTraslado.Tag = "F"
        Me.txtComprobanteFechaTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbDireccionEnvio
        '
        Me.cmbDireccionEnvio.BackColor = System.Drawing.Color.Azure
        Me.cmbDireccionEnvio.DisplayMember = "DIRECCION"
        Me.cmbDireccionEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbDireccionEnvio.Enabled = False
        Me.cmbDireccionEnvio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDireccionEnvio.FormattingEnabled = True
        Me.cmbDireccionEnvio.Location = New System.Drawing.Point(12, 113)
        Me.cmbDireccionEnvio.Name = "cmbDireccionEnvio"
        Me.cmbDireccionEnvio.Size = New System.Drawing.Size(682, 21)
        Me.cmbDireccionEnvio.TabIndex = 10
        Me.cmbDireccionEnvio.ValueMember = "DOMICILIO_ENVIO"
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.Moccasin
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtReferencia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReferencia.Location = New System.Drawing.Point(773, 160)
        Me.txtReferencia.MaxLength = 40
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(10, 21)
        Me.txtReferencia.TabIndex = 16
        Me.txtReferencia.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 21)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "COMENTARIO "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(108, 186)
        Me.txtComentario.MaxLength = 100
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(586, 21)
        Me.txtComentario.TabIndex = 5
        '
        'cmbComprobanteSerie
        '
        Me.cmbComprobanteSerie.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteSerie.DisplayMember = "CODIGO"
        Me.cmbComprobanteSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteSerie.Enabled = False
        Me.cmbComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteSerie.FormattingEnabled = True
        Me.cmbComprobanteSerie.Location = New System.Drawing.Point(12, 162)
        Me.cmbComprobanteSerie.Name = "cmbComprobanteSerie"
        Me.cmbComprobanteSerie.Size = New System.Drawing.Size(53, 21)
        Me.cmbComprobanteSerie.TabIndex = 11
        Me.cmbComprobanteSerie.TabStop = False
        Me.cmbComprobanteSerie.ValueMember = "CODIGO"
        '
        'txtComentarioPedido
        '
        Me.txtComentarioPedido.BackColor = System.Drawing.Color.Moccasin
        Me.txtComentarioPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentarioPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioPedido.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioPedido.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComentarioPedido.Location = New System.Drawing.Point(751, 160)
        Me.txtComentarioPedido.MaxLength = 100
        Me.txtComentarioPedido.Name = "txtComentarioPedido"
        Me.txtComentarioPedido.ReadOnly = True
        Me.txtComentarioPedido.Size = New System.Drawing.Size(10, 21)
        Me.txtComentarioPedido.TabIndex = 15
        Me.txtComentarioPedido.TabStop = False
        Me.txtComentarioPedido.Visible = False
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(708, 186)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 18
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVenta.Visible = False
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
        Me.gvVentaLineas.Location = New System.Drawing.Point(12, 212)
        Me.gvVentaLineas.MultiSelect = False
        Me.gvVentaLineas.Name = "gvVentaLineas"
        Me.gvVentaLineas.ReadOnly = True
        Me.gvVentaLineas.RowHeadersVisible = False
        Me.gvVentaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.OldLace
        Me.gvVentaLineas.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gvVentaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentaLineas.Size = New System.Drawing.Size(682, 297)
        Me.gvVentaLineas.TabIndex = 6
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
        Me.DESCRIPCION_AMPLIADA.Width = 520
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.IMPORTE_TOTAL.DefaultCellStyle = DataGridViewCellStyle5
        Me.IMPORTE_TOTAL.HeaderText = "P.VENTA"
        Me.IMPORTE_TOTAL.Name = "IMPORTE_TOTAL"
        Me.IMPORTE_TOTAL.ReadOnly = True
        Me.IMPORTE_TOTAL.Visible = False
        Me.IMPORTE_TOTAL.Width = 70
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_SERIE.DefaultCellStyle = DataGridViewCellStyle6
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_COMPUESTO.DefaultCellStyle = DataGridViewCellStyle7
        Me.INDICA_COMPUESTO.HeaderText = "IC"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        Me.INDICA_COMPUESTO.Width = 40
        '
        'frmGuiaPorVenta
        '
        Me.ClientSize = New System.Drawing.Size(707, 576)
        Me.Name = "frmGuiaPorVenta"
        Me.Text = "GUIA DE REMISION POR ORDEN DE PEDIDO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtVendedorCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaca As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbConductor As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFechaTraslado As System.Windows.Forms.TextBox
    Friend WithEvents cmbDireccionEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteSerie As System.Windows.Forms.ComboBox
    Friend WithEvents txtComentarioPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents gvVentaLineas As System.Windows.Forms.DataGridView
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

End Class
