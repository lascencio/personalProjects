<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProformaPrestamo
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
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipoPrestamo = New System.Windows.Forms.ComboBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.lblTipoProforma = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProforma = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCapital = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumeroCuotas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTasaInteresMensual = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTasaMorosidadMensual = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtValorCuota = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVehiculoMarca = New System.Windows.Forms.TextBox()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNumeroSerieChasis = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtVehiculoModelo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCuotaInicial = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCuotaInicialPagada = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCuotaInicialSaldo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ckbIncluyeIGV = New System.Windows.Forms.CheckBox()
        Me.txtTotalInteres = New System.Windows.Forms.TextBox()
        Me.txtTotalImpuesto = New System.Windows.Forms.TextBox()
        Me.Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(804, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtTotalImpuesto)
        Me.Panel.Controls.Add(Me.txtTotalInteres)
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtCuotaInicialSaldo)
        Me.Panel.Controls.Add(Me.Label26)
        Me.Panel.Controls.Add(Me.txtCuotaInicialPagada)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.txtCuotaInicial)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.txtComprobante)
        Me.Panel.Controls.Add(Me.txtVehiculoModelo)
        Me.Panel.Controls.Add(Me.txtColor)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtNumeroSerieChasis)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.txtNumeroSerie)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.txtVehiculoMarca)
        Me.Panel.Controls.Add(Me.txtProductoDescripcion)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtImporteTotal)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtValorCuota)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtTotalPrestamo)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtTasaMorosidadMensual)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtTasaInteresMensual)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtNumeroCuotas)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtCapital)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbFormaPago)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtFechaEmision)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtProforma)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtDomicilio)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbTipoPrestamo)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.lblTipoProforma)
        Me.Panel.Size = New System.Drawing.Size(804, 343)
        Me.Panel.TabIndex = 0
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
        Me.Label43.Size = New System.Drawing.Size(777, 18)
        Me.Label43.TabIndex = 37
        Me.Label43.Text = "DOMICILIO"
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
        Me.txtDomicilio.Size = New System.Drawing.Size(777, 21)
        Me.txtDomicilio.TabIndex = 2
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(742, 30)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 30
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
        Me.txtMes.Location = New System.Drawing.Point(765, 30)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 31
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(11, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 18)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "TIPO DE PRESTAMO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(11, 162)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoPrestamo.TabIndex = 3
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
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
        Me.cmbDocumentoTipo.TabIndex = 12
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
        Me.Label2.Size = New System.Drawing.Size(639, 18)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "NOMBRE / RAZON SOCIAL"
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
        Me.txtRazonSocial.Size = New System.Drawing.Size(639, 21)
        Me.txtRazonSocial.TabIndex = 1
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
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(727, 30)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 29
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'lblTipoProforma
        '
        Me.lblTipoProforma.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoProforma.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoProforma.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTipoProforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoProforma.Location = New System.Drawing.Point(412, 1)
        Me.lblTipoProforma.Name = "lblTipoProforma"
        Me.lblTipoProforma.Size = New System.Drawing.Size(380, 20)
        Me.lblTipoProforma.TabIndex = 32
        Me.lblTipoProforma.Text = "PROFORMA DE PRESTAMO"
        Me.lblTipoProforma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "PROFORMA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProforma
        '
        Me.txtProforma.BackColor = System.Drawing.Color.Moccasin
        Me.txtProforma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProforma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProforma.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProforma.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProforma.Location = New System.Drawing.Point(11, 30)
        Me.txtProforma.MaxLength = 8
        Me.txtProforma.Name = "txtProforma"
        Me.txtProforma.ReadOnly = True
        Me.txtProforma.Size = New System.Drawing.Size(98, 21)
        Me.txtProforma.TabIndex = 10
        Me.txtProforma.TabStop = False
        Me.txtProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(112, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 18)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaEmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaEmision.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaEmision.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaEmision.Location = New System.Drawing.Point(112, 30)
        Me.txtFechaEmision.MaxLength = 10
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(74, 21)
        Me.txtFechaEmision.TabIndex = 11
        Me.txtFechaEmision.TabStop = False
        Me.txtFechaEmision.Tag = "F"
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(355, 143)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 40
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(355, 162)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 5
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(212, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 18)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "FORMA DE PAGO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPago.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Location = New System.Drawing.Point(212, 162)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPago.TabIndex = 4
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(463, 143)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(117, 18)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "CAPITAL"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCapital
        '
        Me.txtCapital.BackColor = System.Drawing.Color.Moccasin
        Me.txtCapital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapital.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCapital.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCapital.Location = New System.Drawing.Point(463, 162)
        Me.txtCapital.MaxLength = 14
        Me.txtCapital.Name = "txtCapital"
        Me.txtCapital.ReadOnly = True
        Me.txtCapital.Size = New System.Drawing.Size(117, 21)
        Me.txtCapital.TabIndex = 6
        Me.txtCapital.TabStop = False
        Me.txtCapital.Tag = "D"
        Me.txtCapital.Text = "0.00"
        Me.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(582, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 18)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "CUOTAS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroCuotas
        '
        Me.txtNumeroCuotas.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroCuotas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroCuotas.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroCuotas.Location = New System.Drawing.Point(582, 162)
        Me.txtNumeroCuotas.MaxLength = 14
        Me.txtNumeroCuotas.Name = "txtNumeroCuotas"
        Me.txtNumeroCuotas.ReadOnly = True
        Me.txtNumeroCuotas.Size = New System.Drawing.Size(57, 21)
        Me.txtNumeroCuotas.TabIndex = 7
        Me.txtNumeroCuotas.TabStop = False
        Me.txtNumeroCuotas.Tag = "E"
        Me.txtNumeroCuotas.Text = "0"
        Me.txtNumeroCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(640, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 18)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "% INTERES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaInteresMensual
        '
        Me.txtTasaInteresMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaInteresMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaInteresMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaInteresMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaInteresMensual.Location = New System.Drawing.Point(640, 162)
        Me.txtTasaInteresMensual.MaxLength = 14
        Me.txtTasaInteresMensual.Name = "txtTasaInteresMensual"
        Me.txtTasaInteresMensual.ReadOnly = True
        Me.txtTasaInteresMensual.Size = New System.Drawing.Size(73, 21)
        Me.txtTasaInteresMensual.TabIndex = 8
        Me.txtTasaInteresMensual.TabStop = False
        Me.txtTasaInteresMensual.Tag = "D"
        Me.txtTasaInteresMensual.Text = "0.00"
        Me.txtTasaInteresMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(715, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 18)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "% MORA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaMorosidadMensual
        '
        Me.txtTasaMorosidadMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaMorosidadMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaMorosidadMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaMorosidadMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaMorosidadMensual.Location = New System.Drawing.Point(715, 162)
        Me.txtTasaMorosidadMensual.MaxLength = 14
        Me.txtTasaMorosidadMensual.Name = "txtTasaMorosidadMensual"
        Me.txtTasaMorosidadMensual.ReadOnly = True
        Me.txtTasaMorosidadMensual.Size = New System.Drawing.Size(73, 21)
        Me.txtTasaMorosidadMensual.TabIndex = 9
        Me.txtTasaMorosidadMensual.TabStop = False
        Me.txtTasaMorosidadMensual.Tag = "D"
        Me.txtTasaMorosidadMensual.Text = "0.00"
        Me.txtTasaMorosidadMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(289, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 18)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "TOTAL PRESTAMO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamo
        '
        Me.txtTotalPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamo.Location = New System.Drawing.Point(289, 30)
        Me.txtTotalPrestamo.MaxLength = 14
        Me.txtTotalPrestamo.Name = "txtTotalPrestamo"
        Me.txtTotalPrestamo.ReadOnly = True
        Me.txtTotalPrestamo.Size = New System.Drawing.Size(117, 21)
        Me.txtTotalPrestamo.TabIndex = 14
        Me.txtTotalPrestamo.TabStop = False
        Me.txtTotalPrestamo.Tag = "D"
        Me.txtTotalPrestamo.Text = "0.00"
        Me.txtTotalPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(189, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 18)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "VALOR CUOTA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValorCuota
        '
        Me.txtValorCuota.BackColor = System.Drawing.Color.Moccasin
        Me.txtValorCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorCuota.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtValorCuota.ForeColor = System.Drawing.Color.DarkRed
        Me.txtValorCuota.Location = New System.Drawing.Point(189, 30)
        Me.txtValorCuota.MaxLength = 14
        Me.txtValorCuota.Name = "txtValorCuota"
        Me.txtValorCuota.ReadOnly = True
        Me.txtValorCuota.Size = New System.Drawing.Size(98, 21)
        Me.txtValorCuota.TabIndex = 13
        Me.txtValorCuota.TabStop = False
        Me.txtValorCuota.Tag = "D"
        Me.txtValorCuota.Text = "0.00"
        Me.txtValorCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(11, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(223, 20)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "INFORMACION DE LA VENTA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(11, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 18)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "VENTA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(11, 235)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(98, 21)
        Me.txtVenta.TabIndex = 15
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(270, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 18)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "PRECIO VENTA"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotal.Location = New System.Drawing.Point(270, 235)
        Me.txtImporteTotal.MaxLength = 14
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(90, 21)
        Me.txtImporteTotal.TabIndex = 18
        Me.txtImporteTotal.TabStop = False
        Me.txtImporteTotal.Tag = "D"
        Me.txtImporteTotal.Text = "0.00"
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(362, 235)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(426, 21)
        Me.txtProductoDescripcion.TabIndex = 23
        Me.txtProductoDescripcion.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(584, 30)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(46, 21)
        Me.txtProducto.TabIndex = 22
        Me.txtProducto.TabStop = False
        Me.txtProducto.Tag = ""
        Me.txtProducto.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.Location = New System.Drawing.Point(361, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(427, 18)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVehiculoMarca
        '
        Me.txtVehiculoMarca.BackColor = System.Drawing.Color.Moccasin
        Me.txtVehiculoMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculoMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehiculoMarca.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVehiculoMarca.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVehiculoMarca.Location = New System.Drawing.Point(644, 30)
        Me.txtVehiculoMarca.MaxLength = 20
        Me.txtVehiculoMarca.Name = "txtVehiculoMarca"
        Me.txtVehiculoMarca.ReadOnly = True
        Me.txtVehiculoMarca.Size = New System.Drawing.Size(29, 21)
        Me.txtVehiculoMarca.TabIndex = 24
        Me.txtVehiculoMarca.TabStop = False
        Me.txtVehiculoMarca.Visible = False
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.Moccasin
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColor.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtColor.ForeColor = System.Drawing.Color.DarkRed
        Me.txtColor.Location = New System.Drawing.Point(345, 277)
        Me.txtColor.MaxLength = 20
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(184, 21)
        Me.txtColor.TabIndex = 28
        Me.txtColor.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.Location = New System.Drawing.Point(345, 258)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(184, 18)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "COLOR"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroSerieChasis
        '
        Me.txtNumeroSerieChasis.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroSerieChasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerieChasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerieChasis.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroSerieChasis.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroSerieChasis.Location = New System.Drawing.Point(178, 277)
        Me.txtNumeroSerieChasis.MaxLength = 20
        Me.txtNumeroSerieChasis.Name = "txtNumeroSerieChasis"
        Me.txtNumeroSerieChasis.ReadOnly = True
        Me.txtNumeroSerieChasis.Size = New System.Drawing.Size(166, 21)
        Me.txtNumeroSerieChasis.TabIndex = 27
        Me.txtNumeroSerieChasis.TabStop = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label17.Location = New System.Drawing.Point(178, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(166, 18)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "NUMERO SERIE CHASIS (VIN)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroSerie.Location = New System.Drawing.Point(11, 277)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.ReadOnly = True
        Me.txtNumeroSerie.Size = New System.Drawing.Size(166, 21)
        Me.txtNumeroSerie.TabIndex = 26
        Me.txtNumeroSerie.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label18.Location = New System.Drawing.Point(11, 258)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(166, 18)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "NUMERO SERIE MOTOR"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVehiculoModelo
        '
        Me.txtVehiculoModelo.BackColor = System.Drawing.Color.Moccasin
        Me.txtVehiculoModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehiculoModelo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVehiculoModelo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVehiculoModelo.Location = New System.Drawing.Point(679, 30)
        Me.txtVehiculoModelo.MaxLength = 20
        Me.txtVehiculoModelo.Name = "txtVehiculoModelo"
        Me.txtVehiculoModelo.ReadOnly = True
        Me.txtVehiculoModelo.Size = New System.Drawing.Size(24, 21)
        Me.txtVehiculoModelo.TabIndex = 25
        Me.txtVehiculoModelo.TabStop = False
        Me.txtVehiculoModelo.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(110, 216)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 18)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "COMPROBANTE"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobante.Location = New System.Drawing.Point(110, 235)
        Me.txtComprobante.MaxLength = 8
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(94, 21)
        Me.txtComprobante.TabIndex = 16
        Me.txtComprobante.TabStop = False
        Me.txtComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(205, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 18)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "FECHA"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(205, 235)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.ReadOnly = True
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(64, 21)
        Me.txtComprobanteFecha.TabIndex = 17
        Me.txtComprobanteFecha.TabStop = False
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(535, 258)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 18)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "C. I."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCuotaInicial
        '
        Me.txtCuotaInicial.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuotaInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuotaInicial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuotaInicial.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuotaInicial.Location = New System.Drawing.Point(535, 277)
        Me.txtCuotaInicial.MaxLength = 14
        Me.txtCuotaInicial.Name = "txtCuotaInicial"
        Me.txtCuotaInicial.Size = New System.Drawing.Size(84, 21)
        Me.txtCuotaInicial.TabIndex = 19
        Me.txtCuotaInicial.Tag = "D"
        Me.txtCuotaInicial.Text = "0.00"
        Me.txtCuotaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(620, 258)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 18)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "C. I.  PAGADA"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCuotaInicialPagada
        '
        Me.txtCuotaInicialPagada.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuotaInicialPagada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuotaInicialPagada.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuotaInicialPagada.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCuotaInicialPagada.Location = New System.Drawing.Point(620, 277)
        Me.txtCuotaInicialPagada.MaxLength = 14
        Me.txtCuotaInicialPagada.Name = "txtCuotaInicialPagada"
        Me.txtCuotaInicialPagada.Size = New System.Drawing.Size(84, 21)
        Me.txtCuotaInicialPagada.TabIndex = 20
        Me.txtCuotaInicialPagada.Tag = "D"
        Me.txtCuotaInicialPagada.Text = "0.00"
        Me.txtCuotaInicialPagada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(705, 258)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 18)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "C. I.  SALDO"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCuotaInicialSaldo
        '
        Me.txtCuotaInicialSaldo.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuotaInicialSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuotaInicialSaldo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuotaInicialSaldo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCuotaInicialSaldo.Location = New System.Drawing.Point(705, 277)
        Me.txtCuotaInicialSaldo.MaxLength = 14
        Me.txtCuotaInicialSaldo.Name = "txtCuotaInicialSaldo"
        Me.txtCuotaInicialSaldo.ReadOnly = True
        Me.txtCuotaInicialSaldo.Size = New System.Drawing.Size(84, 21)
        Me.txtCuotaInicialSaldo.TabIndex = 21
        Me.txtCuotaInicialSaldo.TabStop = False
        Me.txtCuotaInicialSaldo.Tag = "D"
        Me.txtCuotaInicialSaldo.Text = "0.00"
        Me.txtCuotaInicialSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.ckbIncluyeIGV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 310)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 31)
        Me.Panel1.TabIndex = 103
        '
        'ckbIncluyeIGV
        '
        Me.ckbIncluyeIGV.AutoSize = True
        Me.ckbIncluyeIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIncluyeIGV.ForeColor = System.Drawing.Color.Navy
        Me.ckbIncluyeIGV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIncluyeIGV.Location = New System.Drawing.Point(654, 6)
        Me.ckbIncluyeIGV.Name = "ckbIncluyeIGV"
        Me.ckbIncluyeIGV.Size = New System.Drawing.Size(133, 17)
        Me.ckbIncluyeIGV.TabIndex = 5
        Me.ckbIncluyeIGV.TabStop = False
        Me.ckbIncluyeIGV.Text = "CUOTA INCLUYE IGV"
        Me.ckbIncluyeIGV.UseVisualStyleBackColor = True
        '
        'txtTotalInteres
        '
        Me.txtTotalInteres.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInteres.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalInteres.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalInteres.Location = New System.Drawing.Point(412, 30)
        Me.txtTotalInteres.MaxLength = 14
        Me.txtTotalInteres.Name = "txtTotalInteres"
        Me.txtTotalInteres.ReadOnly = True
        Me.txtTotalInteres.Size = New System.Drawing.Size(49, 21)
        Me.txtTotalInteres.TabIndex = 104
        Me.txtTotalInteres.TabStop = False
        Me.txtTotalInteres.Tag = "D"
        Me.txtTotalInteres.Text = "0.00"
        Me.txtTotalInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalInteres.Visible = False
        '
        'txtTotalImpuesto
        '
        Me.txtTotalImpuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalImpuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalImpuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalImpuesto.Location = New System.Drawing.Point(463, 30)
        Me.txtTotalImpuesto.MaxLength = 14
        Me.txtTotalImpuesto.Name = "txtTotalImpuesto"
        Me.txtTotalImpuesto.ReadOnly = True
        Me.txtTotalImpuesto.Size = New System.Drawing.Size(49, 21)
        Me.txtTotalImpuesto.TabIndex = 105
        Me.txtTotalImpuesto.TabStop = False
        Me.txtTotalImpuesto.Tag = "D"
        Me.txtTotalImpuesto.Text = "0.00"
        Me.txtTotalImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalImpuesto.Visible = False
        '
        'frmProformaPrestamo
        '
        Me.ClientSize = New System.Drawing.Size(804, 397)
        Me.Name = "frmProformaPrestamo"
        Me.Text = " PROFORMA DE PRESTAMO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoProforma As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProforma As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCapital As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTasaMorosidadMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTasaInteresMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtValorCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculoMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerieChasis As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculoModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaInicialPagada As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaInicialSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ckbIncluyeIGV As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalInteres As System.Windows.Forms.TextBox

End Class
