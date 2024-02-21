<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefinanciarPrestamo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRefinanciarPrestamo))
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamoRefinanciar = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalCuotas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalPagar = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalMoras = New System.Windows.Forms.TextBox()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.btnBuscarPrestamo = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtFechaPrimerPago = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTasaMorosidadMensual = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTasaInteresMensual = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumeroCuotas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCapital = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbFormaPagoRefinanciamiento = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFormaPagoPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtValorCuota = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamo = New System.Windows.Forms.TextBox()
        Me.txtTotalImpuesto = New System.Windows.Forms.TextBox()
        Me.txtTotalInteres = New System.Windows.Forms.TextBox()
        Me.cmbTipoPrestamo = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(846, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.cmbTipoPrestamo)
        Me.Panel.Controls.Add(Me.txtTotalImpuesto)
        Me.Panel.Controls.Add(Me.txtTotalInteres)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtTotalPrestamo)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtValorCuota)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.cmbFormaPagoPrestamo)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.txtFechaPrimerPago)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtTasaMorosidadMensual)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtTasaInteresMensual)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtNumeroCuotas)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtCapital)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.cmbFormaPagoRefinanciamiento)
        Me.Panel.Controls.Add(Me.btnBuscarPrestamo)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtPrestamo)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtTotalMoras)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtTotalPagar)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cmbPrestamo)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtTotalCuotas)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtTotalPrestamoRefinanciar)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtFechaEmision)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Size = New System.Drawing.Size(846, 206)
        Me.Panel.TabIndex = 0
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
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 72)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 2
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(149, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(678, 18)
        Me.Label2.TabIndex = 25
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 72)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(678, 21)
        Me.txtRazonSocial.TabIndex = 14
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 72)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(11, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label14.TabIndex = 23
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
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(249, 95)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 18)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamoRefinanciar
        '
        Me.txtTotalPrestamoRefinanciar.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamoRefinanciar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamoRefinanciar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamoRefinanciar.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamoRefinanciar.Location = New System.Drawing.Point(249, 114)
        Me.txtTotalPrestamoRefinanciar.MaxLength = 14
        Me.txtTotalPrestamoRefinanciar.Name = "txtTotalPrestamoRefinanciar"
        Me.txtTotalPrestamoRefinanciar.ReadOnly = True
        Me.txtTotalPrestamoRefinanciar.Size = New System.Drawing.Size(113, 21)
        Me.txtTotalPrestamoRefinanciar.TabIndex = 16
        Me.txtTotalPrestamoRefinanciar.TabStop = False
        Me.txtTotalPrestamoRefinanciar.Tag = "D"
        Me.txtTotalPrestamoRefinanciar.Text = "0.00"
        Me.txtTotalPrestamoRefinanciar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(142, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 27
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(142, 114)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 15
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(507, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "TOTAL CUOTAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalCuotas
        '
        Me.txtTotalCuotas.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCuotas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalCuotas.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalCuotas.Location = New System.Drawing.Point(507, 114)
        Me.txtTotalCuotas.MaxLength = 14
        Me.txtTotalCuotas.Name = "txtTotalCuotas"
        Me.txtTotalCuotas.ReadOnly = True
        Me.txtTotalCuotas.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalCuotas.TabIndex = 18
        Me.txtTotalCuotas.TabStop = False
        Me.txtTotalCuotas.Tag = "D"
        Me.txtTotalCuotas.Text = "0.00"
        Me.txtTotalCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 18)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "PRESTAMO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPrestamo
        '
        Me.cmbPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbPrestamo.DisplayMember = "PRESTAMO"
        Me.cmbPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPrestamo.FormattingEnabled = True
        Me.cmbPrestamo.Location = New System.Drawing.Point(11, 114)
        Me.cmbPrestamo.Name = "cmbPrestamo"
        Me.cmbPrestamo.Size = New System.Drawing.Size(107, 21)
        Me.cmbPrestamo.TabIndex = 3
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(719, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 18)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "TOTAL A PAGAR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPagar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPagar.Location = New System.Drawing.Point(719, 114)
        Me.txtTotalPagar.MaxLength = 14
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(108, 21)
        Me.txtTotalPagar.TabIndex = 20
        Me.txtTotalPagar.TabStop = False
        Me.txtTotalPagar.Tag = "D"
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(554, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(278, 20)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "REFINANCIAR PRESTAMO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(443, 30)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
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
        Me.txtMes.Location = New System.Drawing.Point(466, 30)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 13
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(613, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 18)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "TOTAL MORAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalMoras
        '
        Me.txtTotalMoras.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalMoras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMoras.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalMoras.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalMoras.Location = New System.Drawing.Point(613, 114)
        Me.txtTotalMoras.MaxLength = 14
        Me.txtTotalMoras.Name = "txtTotalMoras"
        Me.txtTotalMoras.ReadOnly = True
        Me.txtTotalMoras.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalMoras.TabIndex = 19
        Me.txtTotalMoras.TabStop = False
        Me.txtTotalMoras.Tag = "D"
        Me.txtTotalMoras.Text = "0.00"
        Me.txtTotalMoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'btnBuscarPrestamo
        '
        Me.btnBuscarPrestamo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPrestamo.Location = New System.Drawing.Point(118, 113)
        Me.btnBuscarPrestamo.Name = "btnBuscarPrestamo"
        Me.btnBuscarPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscarPrestamo.TabIndex = 1
        Me.btnBuscarPrestamo.Text = "..."
        Me.btnBuscarPrestamo.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(11, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 18)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "PRESTAMO"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrestamo
        '
        Me.txtPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrestamo.Location = New System.Drawing.Point(11, 30)
        Me.txtPrestamo.MaxLength = 8
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.Size = New System.Drawing.Size(98, 21)
        Me.txtPrestamo.TabIndex = 10
        Me.txtPrestamo.TabStop = False
        Me.txtPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.DataPropertyName = "EDITAR"
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.Width = 24
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.SteelBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(478, 151)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 18)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "F.  PRIMER PAGO"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaPrimerPago
        '
        Me.txtFechaPrimerPago.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaPrimerPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaPrimerPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaPrimerPago.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaPrimerPago.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaPrimerPago.Location = New System.Drawing.Point(478, 170)
        Me.txtFechaPrimerPago.MaxLength = 50
        Me.txtFechaPrimerPago.Name = "txtFechaPrimerPago"
        Me.txtFechaPrimerPago.ReadOnly = True
        Me.txtFechaPrimerPago.Size = New System.Drawing.Size(106, 21)
        Me.txtFechaPrimerPago.TabIndex = 9
        Me.txtFechaPrimerPago.TabStop = False
        Me.txtFechaPrimerPago.Tag = "F"
        Me.txtFechaPrimerPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(403, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 18)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "% MORA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaMorosidadMensual
        '
        Me.txtTasaMorosidadMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaMorosidadMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaMorosidadMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaMorosidadMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaMorosidadMensual.Location = New System.Drawing.Point(403, 170)
        Me.txtTasaMorosidadMensual.MaxLength = 14
        Me.txtTasaMorosidadMensual.Name = "txtTasaMorosidadMensual"
        Me.txtTasaMorosidadMensual.ReadOnly = True
        Me.txtTasaMorosidadMensual.Size = New System.Drawing.Size(73, 21)
        Me.txtTasaMorosidadMensual.TabIndex = 8
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
        Me.Label7.Location = New System.Drawing.Point(328, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 18)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "% INTERES"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaInteresMensual
        '
        Me.txtTasaInteresMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaInteresMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaInteresMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaInteresMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaInteresMensual.Location = New System.Drawing.Point(328, 170)
        Me.txtTasaInteresMensual.MaxLength = 14
        Me.txtTasaInteresMensual.Name = "txtTasaInteresMensual"
        Me.txtTasaInteresMensual.ReadOnly = True
        Me.txtTasaInteresMensual.Size = New System.Drawing.Size(73, 21)
        Me.txtTasaInteresMensual.TabIndex = 7
        Me.txtTasaInteresMensual.TabStop = False
        Me.txtTasaInteresMensual.Tag = "D"
        Me.txtTasaInteresMensual.Text = "0.00"
        Me.txtTasaInteresMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(269, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 18)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "CUOTAS"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroCuotas
        '
        Me.txtNumeroCuotas.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroCuotas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroCuotas.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroCuotas.Location = New System.Drawing.Point(269, 170)
        Me.txtNumeroCuotas.MaxLength = 14
        Me.txtNumeroCuotas.Name = "txtNumeroCuotas"
        Me.txtNumeroCuotas.ReadOnly = True
        Me.txtNumeroCuotas.Size = New System.Drawing.Size(57, 21)
        Me.txtNumeroCuotas.TabIndex = 6
        Me.txtNumeroCuotas.TabStop = False
        Me.txtNumeroCuotas.Tag = "E"
        Me.txtNumeroCuotas.Text = "0"
        Me.txtNumeroCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(154, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 18)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "CAPITAL"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCapital
        '
        Me.txtCapital.BackColor = System.Drawing.Color.Moccasin
        Me.txtCapital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapital.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCapital.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCapital.Location = New System.Drawing.Point(154, 170)
        Me.txtCapital.MaxLength = 14
        Me.txtCapital.Name = "txtCapital"
        Me.txtCapital.ReadOnly = True
        Me.txtCapital.Size = New System.Drawing.Size(113, 21)
        Me.txtCapital.TabIndex = 5
        Me.txtCapital.TabStop = False
        Me.txtCapital.Tag = "D"
        Me.txtCapital.Text = "0.00"
        Me.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(11, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 18)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "FORMA DE PAGO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPagoRefinanciamiento
        '
        Me.cmbFormaPagoRefinanciamiento.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPagoRefinanciamiento.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPagoRefinanciamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPagoRefinanciamiento.Enabled = False
        Me.cmbFormaPagoRefinanciamiento.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPagoRefinanciamiento.FormattingEnabled = True
        Me.cmbFormaPagoRefinanciamiento.Location = New System.Drawing.Point(11, 170)
        Me.cmbFormaPagoRefinanciamiento.Name = "cmbFormaPagoRefinanciamiento"
        Me.cmbFormaPagoRefinanciamiento.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPagoRefinanciamiento.TabIndex = 4
        Me.cmbFormaPagoRefinanciamiento.TabStop = False
        Me.cmbFormaPagoRefinanciamiento.ValueMember = "CODIGO"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(363, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 18)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "FORMA DE PAGO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPagoPrestamo
        '
        Me.cmbFormaPagoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPagoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPagoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPagoPrestamo.Enabled = False
        Me.cmbFormaPagoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPagoPrestamo.FormattingEnabled = True
        Me.cmbFormaPagoPrestamo.Location = New System.Drawing.Point(363, 114)
        Me.cmbFormaPagoPrestamo.Name = "cmbFormaPagoPrestamo"
        Me.cmbFormaPagoPrestamo.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPagoPrestamo.TabIndex = 17
        Me.cmbFormaPagoPrestamo.TabStop = False
        Me.cmbFormaPagoPrestamo.ValueMember = "CODIGO"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(595, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "VALOR CUOTA"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValorCuota
        '
        Me.txtValorCuota.BackColor = System.Drawing.Color.Moccasin
        Me.txtValorCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorCuota.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtValorCuota.ForeColor = System.Drawing.Color.DarkRed
        Me.txtValorCuota.Location = New System.Drawing.Point(595, 170)
        Me.txtValorCuota.MaxLength = 14
        Me.txtValorCuota.Name = "txtValorCuota"
        Me.txtValorCuota.ReadOnly = True
        Me.txtValorCuota.Size = New System.Drawing.Size(103, 21)
        Me.txtValorCuota.TabIndex = 55
        Me.txtValorCuota.TabStop = False
        Me.txtValorCuota.Tag = "D"
        Me.txtValorCuota.Text = "0.00"
        Me.txtValorCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(710, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 18)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "TOTAL PRESTAMO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamo
        '
        Me.txtTotalPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamo.Location = New System.Drawing.Point(710, 170)
        Me.txtTotalPrestamo.MaxLength = 14
        Me.txtTotalPrestamo.Name = "txtTotalPrestamo"
        Me.txtTotalPrestamo.ReadOnly = True
        Me.txtTotalPrestamo.Size = New System.Drawing.Size(117, 21)
        Me.txtTotalPrestamo.TabIndex = 57
        Me.txtTotalPrestamo.TabStop = False
        Me.txtTotalPrestamo.Tag = "D"
        Me.txtTotalPrestamo.Text = "0.00"
        Me.txtTotalPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalImpuesto
        '
        Me.txtTotalImpuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalImpuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalImpuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalImpuesto.Location = New System.Drawing.Point(313, 30)
        Me.txtTotalImpuesto.MaxLength = 14
        Me.txtTotalImpuesto.Name = "txtTotalImpuesto"
        Me.txtTotalImpuesto.ReadOnly = True
        Me.txtTotalImpuesto.Size = New System.Drawing.Size(49, 21)
        Me.txtTotalImpuesto.TabIndex = 109
        Me.txtTotalImpuesto.TabStop = False
        Me.txtTotalImpuesto.Tag = "D"
        Me.txtTotalImpuesto.Text = "0.00"
        Me.txtTotalImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalImpuesto.Visible = False
        '
        'txtTotalInteres
        '
        Me.txtTotalInteres.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInteres.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalInteres.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalInteres.Location = New System.Drawing.Point(262, 30)
        Me.txtTotalInteres.MaxLength = 14
        Me.txtTotalInteres.Name = "txtTotalInteres"
        Me.txtTotalInteres.ReadOnly = True
        Me.txtTotalInteres.Size = New System.Drawing.Size(49, 21)
        Me.txtTotalInteres.TabIndex = 108
        Me.txtTotalInteres.TabStop = False
        Me.txtTotalInteres.Tag = "D"
        Me.txtTotalInteres.Text = "0.00"
        Me.txtTotalInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalInteres.Visible = False
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(490, 30)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(94, 21)
        Me.cmbTipoPrestamo.TabIndex = 110
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
        Me.cmbTipoPrestamo.Visible = False
        '
        'frmRefinanciarPrestamo
        '
        Me.ClientSize = New System.Drawing.Size(846, 260)
        Me.Name = "frmRefinanciarPrestamo"
        Me.Text = "REFINANCIAR PRESTAMO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamoRefinanciar As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMoras As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents btnBuscarPrestamo As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPrimerPago As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTasaMorosidadMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTasaInteresMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCapital As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPagoRefinanciamiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPagoPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtValorCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalInteres As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox

End Class
