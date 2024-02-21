<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobranzaProntoPago
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobranzaProntoPago))
        Me.txtDineroRecibido = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblPagoCambio = New System.Windows.Forms.Label()
        Me.txtImportePago = New System.Windows.Forms.TextBox()
        Me.txtTipoCambioPago = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbTipoMonedaPago = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblNumeroReciboInterno = New System.Windows.Forms.Label()
        Me.txtNumeroReciboInterno = New System.Windows.Forms.TextBox()
        Me.txtFechaBaseCalculoMora = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnBuscarPrestamo = New System.Windows.Forms.Button()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gvCuotas = New System.Windows.Forms.DataGridView()
        Me.NUMERO_CUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_CUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDO_CUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS_MORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUOTA_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MORA_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROMISO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROMISO_COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECCIONAR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EDITAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMonedaPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtCobranza = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDineroVueltoMN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTasaMorosidadMensual = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTasaInteresMensual = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumeroCuotas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCapital = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalCuotasPagadas = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtMesesActuales = New System.Windows.Forms.TextBox()
        Me.txtMesesAdicionales = New System.Windows.Forms.TextBox()
        Me.txtMesesTotales = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtInteresPagar = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtCapitalInteresPagar = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtMorasPagar = New System.Windows.Forms.TextBox()
        Me.txtTotalProntoPago = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtPorcentajeInteresAcumulado = New System.Windows.Forms.TextBox()
        Me.cmbFormaPagoPrestamo = New System.Windows.Forms.ComboBox()
        Me.cmbTipoPrestamo = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout()
        CType(Me.gvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(861, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.cmbTipoPrestamo)
        Me.Panel.Controls.Add(Me.cmbFormaPagoPrestamo)
        Me.Panel.Controls.Add(Me.txtPorcentajeInteresAcumulado)
        Me.Panel.Controls.Add(Me.Label37)
        Me.Panel.Controls.Add(Me.txtTotalProntoPago)
        Me.Panel.Controls.Add(Me.txtMorasPagar)
        Me.Panel.Controls.Add(Me.Label36)
        Me.Panel.Controls.Add(Me.Label35)
        Me.Panel.Controls.Add(Me.txtCapitalInteresPagar)
        Me.Panel.Controls.Add(Me.Label34)
        Me.Panel.Controls.Add(Me.txtInteresPagar)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtMesesTotales)
        Me.Panel.Controls.Add(Me.txtMesesAdicionales)
        Me.Panel.Controls.Add(Me.txtMesesActuales)
        Me.Panel.Controls.Add(Me.Label32)
        Me.Panel.Controls.Add(Me.Label31)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtTotalCuotasPagadas)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtTasaMorosidadMensual)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtTasaInteresMensual)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtNumeroCuotas)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtCapital)
        Me.Panel.Controls.Add(Me.txtDineroRecibido)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.Label30)
        Me.Panel.Controls.Add(Me.lblPagoCambio)
        Me.Panel.Controls.Add(Me.txtImportePago)
        Me.Panel.Controls.Add(Me.txtTipoCambioPago)
        Me.Panel.Controls.Add(Me.Label28)
        Me.Panel.Controls.Add(Me.cmbTipoMonedaPago)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.cmbFormaPago)
        Me.Panel.Controls.Add(Me.lblNumeroReciboInterno)
        Me.Panel.Controls.Add(Me.txtNumeroReciboInterno)
        Me.Panel.Controls.Add(Me.txtFechaBaseCalculoMora)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label26)
        Me.Panel.Controls.Add(Me.btnBuscarPrestamo)
        Me.Panel.Controls.Add(Me.lblTipoCambio)
        Me.Panel.Controls.Add(Me.txtPrestamo)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.gvCuotas)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cmbPrestamo)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtTotalPrestamo)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMonedaPrestamo)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.txtFechaEmision)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.Label47)
        Me.Panel.Controls.Add(Me.txtCobranza)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.txtDineroVueltoMN)
        Me.Panel.Size = New System.Drawing.Size(861, 586)
        Me.Panel.TabIndex = 0
        '
        'txtDineroRecibido
        '
        Me.txtDineroRecibido.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDineroRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDineroRecibido.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDineroRecibido.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDineroRecibido.Location = New System.Drawing.Point(648, 114)
        Me.txtDineroRecibido.MaxLength = 14
        Me.txtDineroRecibido.Name = "txtDineroRecibido"
        Me.txtDineroRecibido.Size = New System.Drawing.Size(102, 21)
        Me.txtDineroRecibido.TabIndex = 6
        Me.txtDineroRecibido.TabStop = False
        Me.txtDineroRecibido.Tag = "D"
        Me.txtDineroRecibido.Text = "0.00"
        Me.txtDineroRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(648, 95)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 18)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "TOTAL RECIBIDO"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.SteelBlue
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(751, 95)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(96, 18)
        Me.Label30.TabIndex = 52
        Me.Label30.Text = "VUELTO SOLES"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPagoCambio
        '
        Me.lblPagoCambio.BackColor = System.Drawing.Color.SteelBlue
        Me.lblPagoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPagoCambio.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.lblPagoCambio.ForeColor = System.Drawing.Color.White
        Me.lblPagoCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPagoCambio.Location = New System.Drawing.Point(449, 11)
        Me.lblPagoCambio.Name = "lblPagoCambio"
        Me.lblPagoCambio.Size = New System.Drawing.Size(96, 18)
        Me.lblPagoCambio.TabIndex = 40
        Me.lblPagoCambio.Text = "TOTAL A PAGAR"
        Me.lblPagoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImportePago
        '
        Me.txtImportePago.BackColor = System.Drawing.Color.Moccasin
        Me.txtImportePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImportePago.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImportePago.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImportePago.Location = New System.Drawing.Point(449, 30)
        Me.txtImportePago.MaxLength = 14
        Me.txtImportePago.Name = "txtImportePago"
        Me.txtImportePago.ReadOnly = True
        Me.txtImportePago.Size = New System.Drawing.Size(96, 21)
        Me.txtImportePago.TabIndex = 13
        Me.txtImportePago.TabStop = False
        Me.txtImportePago.Tag = "D"
        Me.txtImportePago.Text = "0.00"
        Me.txtImportePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambioPago
        '
        Me.txtTipoCambioPago.BackColor = System.Drawing.Color.Moccasin
        Me.txtTipoCambioPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambioPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambioPago.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambioPago.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTipoCambioPago.Location = New System.Drawing.Point(376, 30)
        Me.txtTipoCambioPago.MaxLength = 10
        Me.txtTipoCambioPago.Name = "txtTipoCambioPago"
        Me.txtTipoCambioPago.ReadOnly = True
        Me.txtTipoCambioPago.Size = New System.Drawing.Size(72, 21)
        Me.txtTipoCambioPago.TabIndex = 10
        Me.txtTipoCambioPago.TabStop = False
        Me.txtTipoCambioPago.Tag = "C"
        Me.txtTipoCambioPago.Text = "0.00"
        Me.txtTipoCambioPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.SteelBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(300, 11)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(75, 18)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "MONEDA"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMonedaPago
        '
        Me.cmbTipoMonedaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMonedaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMonedaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMonedaPago.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMonedaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMonedaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMonedaPago.FormattingEnabled = True
        Me.cmbTipoMonedaPago.Location = New System.Drawing.Point(300, 30)
        Me.cmbTipoMonedaPago.Name = "cmbTipoMonedaPago"
        Me.cmbTipoMonedaPago.Size = New System.Drawing.Size(75, 21)
        Me.cmbTipoMonedaPago.TabIndex = 9
        Me.cmbTipoMonedaPago.TabStop = False
        Me.cmbTipoMonedaPago.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(186, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 18)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "FORMA PAGO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPago.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Location = New System.Drawing.Point(186, 30)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(113, 21)
        Me.cmbFormaPago.TabIndex = 8
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'lblNumeroReciboInterno
        '
        Me.lblNumeroReciboInterno.BackColor = System.Drawing.Color.SteelBlue
        Me.lblNumeroReciboInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroReciboInterno.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.lblNumeroReciboInterno.ForeColor = System.Drawing.Color.White
        Me.lblNumeroReciboInterno.Location = New System.Drawing.Point(662, 30)
        Me.lblNumeroReciboInterno.Name = "lblNumeroReciboInterno"
        Me.lblNumeroReciboInterno.Size = New System.Drawing.Size(104, 21)
        Me.lblNumeroReciboInterno.TabIndex = 41
        Me.lblNumeroReciboInterno.Text = "NRO. DE RECIBO"
        Me.lblNumeroReciboInterno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroReciboInterno
        '
        Me.txtNumeroReciboInterno.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroReciboInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroReciboInterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroReciboInterno.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroReciboInterno.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroReciboInterno.Location = New System.Drawing.Point(767, 30)
        Me.txtNumeroReciboInterno.MaxLength = 18
        Me.txtNumeroReciboInterno.Name = "txtNumeroReciboInterno"
        Me.txtNumeroReciboInterno.Size = New System.Drawing.Size(80, 21)
        Me.txtNumeroReciboInterno.TabIndex = 7
        Me.txtNumeroReciboInterno.TabStop = False
        Me.txtNumeroReciboInterno.Tag = ""
        '
        'txtFechaBaseCalculoMora
        '
        Me.txtFechaBaseCalculoMora.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaBaseCalculoMora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaBaseCalculoMora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaBaseCalculoMora.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaBaseCalculoMora.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaBaseCalculoMora.Location = New System.Drawing.Point(641, 29)
        Me.txtFechaBaseCalculoMora.MaxLength = 10
        Me.txtFechaBaseCalculoMora.Name = "txtFechaBaseCalculoMora"
        Me.txtFechaBaseCalculoMora.ReadOnly = True
        Me.txtFechaBaseCalculoMora.Size = New System.Drawing.Size(16, 21)
        Me.txtFechaBaseCalculoMora.TabIndex = 18
        Me.txtFechaBaseCalculoMora.TabStop = False
        Me.txtFechaBaseCalculoMora.Tag = "F"
        Me.txtFechaBaseCalculoMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaBaseCalculoMora.Visible = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(351, 206)
        Me.Label27.Margin = New System.Windows.Forms.Padding(0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 36)
        Me.Label27.TabIndex = 68
        Me.Label27.Text = "Cuota a Pagar"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(251, 206)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 36)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Saldo Cuota"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(314, 206)
        Me.Label25.Margin = New System.Windows.Forms.Padding(0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 36)
        Me.Label25.TabIndex = 67
        Me.Label25.Text = "Dias"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(412, 206)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 36)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "Mora a Pagar"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(535, 206)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(292, 18)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Compromiso de Pago"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscarPrestamo
        '
        Me.btnBuscarPrestamo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPrestamo.Location = New System.Drawing.Point(111, 113)
        Me.btnBuscarPrestamo.Name = "btnBuscarPrestamo"
        Me.btnBuscarPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscarPrestamo.TabIndex = 3
        Me.btnBuscarPrestamo.Text = "..."
        Me.btnBuscarPrestamo.UseVisualStyleBackColor = True
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.BackColor = System.Drawing.Color.SteelBlue
        Me.lblTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoCambio.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.lblTipoCambio.ForeColor = System.Drawing.Color.White
        Me.lblTipoCambio.Location = New System.Drawing.Point(376, 11)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(72, 18)
        Me.lblTipoCambio.TabIndex = 39
        Me.lblTipoCambio.Text = "T. CAMBIO"
        Me.lblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrestamo
        '
        Me.txtPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrestamo.Location = New System.Drawing.Point(552, 29)
        Me.txtPrestamo.MaxLength = 8
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.Size = New System.Drawing.Size(16, 21)
        Me.txtPrestamo.TabIndex = 14
        Me.txtPrestamo.TabStop = False
        Me.txtPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrestamo.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(827, 206)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 36)
        Me.Label23.TabIndex = 74
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(605, 224)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(222, 18)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "Comentario"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(535, 224)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 18)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "Fecha"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(181, 206)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 36)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "Fecha Pago"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(116, 206)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 36)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Valor Cuota"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(46, 206)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 36)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "Fecha Vencimiento"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 206)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 36)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Cuota"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(598, 29)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(17, 21)
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
        Me.txtMes.Location = New System.Drawing.Point(623, 29)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(10, 21)
        Me.txtMes.TabIndex = 17
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(579, 29)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 15
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(567, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(284, 20)
        Me.Label21.TabIndex = 75
        Me.Label21.Text = "COBRANZA POR PRONTO PAGO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gvCuotas
        '
        Me.gvCuotas.AllowUserToAddRows = False
        Me.gvCuotas.AllowUserToDeleteRows = False
        Me.gvCuotas.AllowUserToOrderColumns = True
        Me.gvCuotas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvCuotas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuotas.ColumnHeadersVisible = False
        Me.gvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMERO_CUOTA, Me.FECHA_VENCIMIENTO, Me.VALOR_CUOTA, Me.FECHA_PAGO, Me.SALDO_CUOTA, Me.DIAS_MORA, Me.MORA, Me.CUOTA_PAGO, Me.MORA_PAGO, Me.TOTAL_PAGO, Me.COMPROMISO_FECHA, Me.COMPROMISO_COMENTARIO, Me.SELECCIONAR, Me.EDITAR})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvCuotas.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvCuotas.EnableHeadersVisualStyles = False
        Me.gvCuotas.Location = New System.Drawing.Point(11, 242)
        Me.gvCuotas.MultiSelect = False
        Me.gvCuotas.Name = "gvCuotas"
        Me.gvCuotas.ReadOnly = True
        Me.gvCuotas.RowHeadersVisible = False
        Me.gvCuotas.RowHeadersWidth = 13
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.OldLace
        Me.gvCuotas.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.gvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuotas.Size = New System.Drawing.Size(836, 334)
        Me.gvCuotas.TabIndex = 2
        Me.gvCuotas.TabStop = False
        '
        'NUMERO_CUOTA
        '
        Me.NUMERO_CUOTA.DataPropertyName = "NUMERO_CUOTA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NUMERO_CUOTA.DefaultCellStyle = DataGridViewCellStyle3
        Me.NUMERO_CUOTA.HeaderText = "Cuota"
        Me.NUMERO_CUOTA.Name = "NUMERO_CUOTA"
        Me.NUMERO_CUOTA.ReadOnly = True
        Me.NUMERO_CUOTA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NUMERO_CUOTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NUMERO_CUOTA.Width = 32
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.FECHA_VENCIMIENTO.DefaultCellStyle = DataGridViewCellStyle4
        Me.FECHA_VENCIMIENTO.HeaderText = "Fecha Vencimiento"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_VENCIMIENTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FECHA_VENCIMIENTO.Width = 70
        '
        'VALOR_CUOTA
        '
        Me.VALOR_CUOTA.DataPropertyName = "VALOR_CUOTA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.VALOR_CUOTA.DefaultCellStyle = DataGridViewCellStyle5
        Me.VALOR_CUOTA.HeaderText = "Valor Cuota"
        Me.VALOR_CUOTA.Name = "VALOR_CUOTA"
        Me.VALOR_CUOTA.ReadOnly = True
        Me.VALOR_CUOTA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VALOR_CUOTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VALOR_CUOTA.Width = 65
        '
        'FECHA_PAGO
        '
        Me.FECHA_PAGO.DataPropertyName = "FECHA_PAGO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.FECHA_PAGO.DefaultCellStyle = DataGridViewCellStyle6
        Me.FECHA_PAGO.HeaderText = "Fecha Pago"
        Me.FECHA_PAGO.Name = "FECHA_PAGO"
        Me.FECHA_PAGO.ReadOnly = True
        Me.FECHA_PAGO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_PAGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FECHA_PAGO.Width = 70
        '
        'SALDO_CUOTA
        '
        Me.SALDO_CUOTA.DataPropertyName = "SALDO_CUOTA"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.SALDO_CUOTA.DefaultCellStyle = DataGridViewCellStyle7
        Me.SALDO_CUOTA.HeaderText = "Saldo Cuota"
        Me.SALDO_CUOTA.Name = "SALDO_CUOTA"
        Me.SALDO_CUOTA.ReadOnly = True
        Me.SALDO_CUOTA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SALDO_CUOTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SALDO_CUOTA.Width = 65
        '
        'DIAS_MORA
        '
        Me.DIAS_MORA.DataPropertyName = "DIAS_MORA"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DIAS_MORA.DefaultCellStyle = DataGridViewCellStyle8
        Me.DIAS_MORA.HeaderText = "Dias"
        Me.DIAS_MORA.Name = "DIAS_MORA"
        Me.DIAS_MORA.ReadOnly = True
        Me.DIAS_MORA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DIAS_MORA.Width = 35
        '
        'MORA
        '
        Me.MORA.DataPropertyName = "MORA"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.MORA.DefaultCellStyle = DataGridViewCellStyle9
        Me.MORA.HeaderText = "Mora"
        Me.MORA.Name = "MORA"
        Me.MORA.ReadOnly = True
        Me.MORA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MORA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MORA.Visible = False
        Me.MORA.Width = 60
        '
        'CUOTA_PAGO
        '
        Me.CUOTA_PAGO.DataPropertyName = "CUOTA_PAGO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.CUOTA_PAGO.DefaultCellStyle = DataGridViewCellStyle10
        Me.CUOTA_PAGO.HeaderText = "Cuota Pagar"
        Me.CUOTA_PAGO.Name = "CUOTA_PAGO"
        Me.CUOTA_PAGO.ReadOnly = True
        Me.CUOTA_PAGO.Width = 65
        '
        'MORA_PAGO
        '
        Me.MORA_PAGO.DataPropertyName = "MORA_PAGO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.MORA_PAGO.DefaultCellStyle = DataGridViewCellStyle11
        Me.MORA_PAGO.HeaderText = "Mora Pagar"
        Me.MORA_PAGO.Name = "MORA_PAGO"
        Me.MORA_PAGO.ReadOnly = True
        Me.MORA_PAGO.Width = 55
        '
        'TOTAL_PAGO
        '
        Me.TOTAL_PAGO.DataPropertyName = "TOTAL_PAGO"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.TOTAL_PAGO.DefaultCellStyle = DataGridViewCellStyle12
        Me.TOTAL_PAGO.HeaderText = "Total a Pagar"
        Me.TOTAL_PAGO.Name = "TOTAL_PAGO"
        Me.TOTAL_PAGO.ReadOnly = True
        Me.TOTAL_PAGO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TOTAL_PAGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TOTAL_PAGO.Width = 65
        '
        'COMPROMISO_FECHA
        '
        Me.COMPROMISO_FECHA.DataPropertyName = "COMPROMISO_FECHA"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "d"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.COMPROMISO_FECHA.DefaultCellStyle = DataGridViewCellStyle13
        Me.COMPROMISO_FECHA.HeaderText = "Fecha Compromiso"
        Me.COMPROMISO_FECHA.Name = "COMPROMISO_FECHA"
        Me.COMPROMISO_FECHA.ReadOnly = True
        Me.COMPROMISO_FECHA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COMPROMISO_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROMISO_FECHA.Width = 70
        '
        'COMPROMISO_COMENTARIO
        '
        Me.COMPROMISO_COMENTARIO.DataPropertyName = "COMPROMISO_COMENTARIO"
        Me.COMPROMISO_COMENTARIO.HeaderText = "Comentario"
        Me.COMPROMISO_COMENTARIO.Name = "COMPROMISO_COMENTARIO"
        Me.COMPROMISO_COMENTARIO.ReadOnly = True
        Me.COMPROMISO_COMENTARIO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COMPROMISO_COMENTARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROMISO_COMENTARIO.Width = 222
        '
        'SELECCIONAR
        '
        Me.SELECCIONAR.DataPropertyName = "SELECCIONAR"
        Me.SELECCIONAR.HeaderText = ""
        Me.SELECCIONAR.Name = "SELECCIONAR"
        Me.SELECCIONAR.ReadOnly = True
        Me.SELECCIONAR.Visible = False
        Me.SELECCIONAR.Width = 30
        '
        'EDITAR
        '
        Me.EDITAR.DataPropertyName = "EDITAR"
        Me.EDITAR.HeaderText = ""
        Me.EDITAR.Image = CType(resources.GetObject("EDITAR.Image"), System.Drawing.Image)
        Me.EDITAR.Name = "EDITAR"
        Me.EDITAR.ReadOnly = True
        Me.EDITAR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EDITAR.Visible = False
        Me.EDITAR.Width = 24
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 44
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
        Me.cmbPrestamo.Size = New System.Drawing.Size(100, 21)
        Me.cmbPrestamo.TabIndex = 1
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(211, 95)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(80, 18)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamo
        '
        Me.txtTotalPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamo.Location = New System.Drawing.Point(211, 114)
        Me.txtTotalPrestamo.MaxLength = 14
        Me.txtTotalPrestamo.Name = "txtTotalPrestamo"
        Me.txtTotalPrestamo.ReadOnly = True
        Me.txtTotalPrestamo.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalPrestamo.TabIndex = 22
        Me.txtTotalPrestamo.TabStop = False
        Me.txtTotalPrestamo.Tag = "D"
        Me.txtTotalPrestamo.Text = "0.00"
        Me.txtTotalPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(135, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 18)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "MONEDA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMonedaPrestamo
        '
        Me.cmbTipoMonedaPrestamo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMonedaPrestamo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMonedaPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.cmbTipoMonedaPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMonedaPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipoMonedaPrestamo.Enabled = False
        Me.cmbTipoMonedaPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipoMonedaPrestamo.FormattingEnabled = True
        Me.cmbTipoMonedaPrestamo.Location = New System.Drawing.Point(135, 114)
        Me.cmbTipoMonedaPrestamo.Name = "cmbTipoMonedaPrestamo"
        Me.cmbTipoMonedaPrestamo.Size = New System.Drawing.Size(75, 21)
        Me.cmbTipoMonedaPrestamo.TabIndex = 21
        Me.cmbTipoMonedaPrestamo.TabStop = False
        Me.cmbTipoMonedaPrestamo.ValueMember = "CODIGO"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(111, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 18)
        Me.Label14.TabIndex = 36
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
        Me.txtFechaEmision.Location = New System.Drawing.Point(111, 30)
        Me.txtFechaEmision.MaxLength = 10
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(74, 21)
        Me.txtFechaEmision.TabIndex = 12
        Me.txtFechaEmision.TabStop = False
        Me.txtFechaEmision.Tag = "F"
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.cmbDocumentoTipo.TabIndex = 19
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(149, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(698, 18)
        Me.Label2.TabIndex = 43
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
        Me.txtRazonSocial.Size = New System.Drawing.Size(698, 21)
        Me.txtRazonSocial.TabIndex = 20
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
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(11, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.SteelBlue
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(11, 11)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(98, 18)
        Me.Label47.TabIndex = 35
        Me.Label47.Text = "COBRANZA"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCobranza
        '
        Me.txtCobranza.BackColor = System.Drawing.Color.Moccasin
        Me.txtCobranza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCobranza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCobranza.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobranza.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCobranza.Location = New System.Drawing.Point(11, 30)
        Me.txtCobranza.MaxLength = 8
        Me.txtCobranza.Name = "txtCobranza"
        Me.txtCobranza.ReadOnly = True
        Me.txtCobranza.Size = New System.Drawing.Size(98, 21)
        Me.txtCobranza.TabIndex = 11
        Me.txtCobranza.TabStop = False
        Me.txtCobranza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(470, 206)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 36)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Importe a Pagar"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDineroVueltoMN
        '
        Me.txtDineroVueltoMN.BackColor = System.Drawing.Color.Moccasin
        Me.txtDineroVueltoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDineroVueltoMN.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDineroVueltoMN.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDineroVueltoMN.Location = New System.Drawing.Point(751, 114)
        Me.txtDineroVueltoMN.MaxLength = 14
        Me.txtDineroVueltoMN.Name = "txtDineroVueltoMN"
        Me.txtDineroVueltoMN.ReadOnly = True
        Me.txtDineroVueltoMN.Size = New System.Drawing.Size(96, 21)
        Me.txtDineroVueltoMN.TabIndex = 27
        Me.txtDineroVueltoMN.TabStop = False
        Me.txtDineroVueltoMN.Tag = "D"
        Me.txtDineroVueltoMN.Text = "0.00"
        Me.txtDineroVueltoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(503, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 18)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "% MORA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaMorosidadMensual
        '
        Me.txtTasaMorosidadMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaMorosidadMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaMorosidadMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaMorosidadMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaMorosidadMensual.Location = New System.Drawing.Point(503, 114)
        Me.txtTasaMorosidadMensual.MaxLength = 14
        Me.txtTasaMorosidadMensual.Name = "txtTasaMorosidadMensual"
        Me.txtTasaMorosidadMensual.ReadOnly = True
        Me.txtTasaMorosidadMensual.Size = New System.Drawing.Size(71, 21)
        Me.txtTasaMorosidadMensual.TabIndex = 26
        Me.txtTasaMorosidadMensual.TabStop = False
        Me.txtTasaMorosidadMensual.Tag = "D"
        Me.txtTasaMorosidadMensual.Text = "0.00"
        Me.txtTasaMorosidadMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(431, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 18)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "% INTERES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTasaInteresMensual
        '
        Me.txtTasaInteresMensual.BackColor = System.Drawing.Color.Moccasin
        Me.txtTasaInteresMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaInteresMensual.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTasaInteresMensual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTasaInteresMensual.Location = New System.Drawing.Point(431, 114)
        Me.txtTasaInteresMensual.MaxLength = 14
        Me.txtTasaInteresMensual.Name = "txtTasaInteresMensual"
        Me.txtTasaInteresMensual.ReadOnly = True
        Me.txtTasaInteresMensual.Size = New System.Drawing.Size(71, 21)
        Me.txtTasaInteresMensual.TabIndex = 25
        Me.txtTasaInteresMensual.TabStop = False
        Me.txtTasaInteresMensual.Tag = "D"
        Me.txtTasaInteresMensual.Text = "0.00"
        Me.txtTasaInteresMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(373, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "CUOTAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroCuotas
        '
        Me.txtNumeroCuotas.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroCuotas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroCuotas.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroCuotas.Location = New System.Drawing.Point(373, 114)
        Me.txtNumeroCuotas.MaxLength = 14
        Me.txtNumeroCuotas.Name = "txtNumeroCuotas"
        Me.txtNumeroCuotas.ReadOnly = True
        Me.txtNumeroCuotas.Size = New System.Drawing.Size(57, 21)
        Me.txtNumeroCuotas.TabIndex = 24
        Me.txtNumeroCuotas.TabStop = False
        Me.txtNumeroCuotas.Tag = "E"
        Me.txtNumeroCuotas.Text = "0"
        Me.txtNumeroCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(292, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "CAPITAL"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCapital
        '
        Me.txtCapital.BackColor = System.Drawing.Color.Moccasin
        Me.txtCapital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapital.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCapital.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCapital.Location = New System.Drawing.Point(292, 114)
        Me.txtCapital.MaxLength = 14
        Me.txtCapital.Name = "txtCapital"
        Me.txtCapital.ReadOnly = True
        Me.txtCapital.Size = New System.Drawing.Size(80, 21)
        Me.txtCapital.TabIndex = 23
        Me.txtCapital.TabStop = False
        Me.txtCapital.Tag = "D"
        Me.txtCapital.Text = "0.00"
        Me.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(560, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(190, 21)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "TOTAL CUOTAS PAGADAS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCuotasPagadas
        '
        Me.txtTotalCuotasPagadas.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalCuotasPagadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCuotasPagadas.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalCuotasPagadas.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalCuotasPagadas.Location = New System.Drawing.Point(751, 138)
        Me.txtTotalCuotasPagadas.MaxLength = 14
        Me.txtTotalCuotasPagadas.Name = "txtTotalCuotasPagadas"
        Me.txtTotalCuotasPagadas.ReadOnly = True
        Me.txtTotalCuotasPagadas.Size = New System.Drawing.Size(96, 21)
        Me.txtTotalCuotasPagadas.TabIndex = 33
        Me.txtTotalCuotasPagadas.TabStop = False
        Me.txtTotalCuotasPagadas.Tag = "D"
        Me.txtTotalCuotasPagadas.Text = "0.00"
        Me.txtTotalCuotasPagadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(11, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(190, 21)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "NUMERO DE MESES A LA FECHA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SteelBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(11, 160)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(190, 21)
        Me.Label31.TabIndex = 54
        Me.Label31.Text = "NUMERO DE MESES A FAVOR"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.SteelBlue
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(11, 182)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(190, 21)
        Me.Label32.TabIndex = 55
        Me.Label32.Text = "NUMERO TOTAL DE MESES"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMesesActuales
        '
        Me.txtMesesActuales.BackColor = System.Drawing.Color.Moccasin
        Me.txtMesesActuales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMesesActuales.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtMesesActuales.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMesesActuales.Location = New System.Drawing.Point(202, 138)
        Me.txtMesesActuales.MaxLength = 14
        Me.txtMesesActuales.Name = "txtMesesActuales"
        Me.txtMesesActuales.ReadOnly = True
        Me.txtMesesActuales.Size = New System.Drawing.Size(30, 21)
        Me.txtMesesActuales.TabIndex = 28
        Me.txtMesesActuales.TabStop = False
        Me.txtMesesActuales.Tag = "E"
        Me.txtMesesActuales.Text = "0"
        Me.txtMesesActuales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMesesAdicionales
        '
        Me.txtMesesAdicionales.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMesesAdicionales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMesesAdicionales.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtMesesAdicionales.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtMesesAdicionales.Location = New System.Drawing.Point(202, 160)
        Me.txtMesesAdicionales.MaxLength = 14
        Me.txtMesesAdicionales.Name = "txtMesesAdicionales"
        Me.txtMesesAdicionales.Size = New System.Drawing.Size(30, 21)
        Me.txtMesesAdicionales.TabIndex = 4
        Me.txtMesesAdicionales.TabStop = False
        Me.txtMesesAdicionales.Tag = "E"
        Me.txtMesesAdicionales.Text = "0"
        Me.txtMesesAdicionales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMesesTotales
        '
        Me.txtMesesTotales.BackColor = System.Drawing.Color.Moccasin
        Me.txtMesesTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMesesTotales.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtMesesTotales.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMesesTotales.Location = New System.Drawing.Point(202, 182)
        Me.txtMesesTotales.MaxLength = 14
        Me.txtMesesTotales.Name = "txtMesesTotales"
        Me.txtMesesTotales.ReadOnly = True
        Me.txtMesesTotales.Size = New System.Drawing.Size(30, 21)
        Me.txtMesesTotales.TabIndex = 29
        Me.txtMesesTotales.TabStop = False
        Me.txtMesesTotales.Tag = "E"
        Me.txtMesesTotales.Text = "0"
        Me.txtMesesTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(255, 138)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(190, 21)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "% INTERES ACUMULADO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.SteelBlue
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(255, 160)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(190, 21)
        Me.Label34.TabIndex = 57
        Me.Label34.Text = "INTERES POR PAGAR"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInteresPagar
        '
        Me.txtInteresPagar.BackColor = System.Drawing.Color.Moccasin
        Me.txtInteresPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInteresPagar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtInteresPagar.ForeColor = System.Drawing.Color.DarkRed
        Me.txtInteresPagar.Location = New System.Drawing.Point(446, 160)
        Me.txtInteresPagar.MaxLength = 14
        Me.txtInteresPagar.Name = "txtInteresPagar"
        Me.txtInteresPagar.ReadOnly = True
        Me.txtInteresPagar.Size = New System.Drawing.Size(96, 21)
        Me.txtInteresPagar.TabIndex = 31
        Me.txtInteresPagar.TabStop = False
        Me.txtInteresPagar.Tag = "D"
        Me.txtInteresPagar.Text = "0.00"
        Me.txtInteresPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(255, 182)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(190, 21)
        Me.Label35.TabIndex = 58
        Me.Label35.Text = "CAPITAL + INTERES POR PAGAR"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCapitalInteresPagar
        '
        Me.txtCapitalInteresPagar.BackColor = System.Drawing.Color.Moccasin
        Me.txtCapitalInteresPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapitalInteresPagar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCapitalInteresPagar.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCapitalInteresPagar.Location = New System.Drawing.Point(446, 182)
        Me.txtCapitalInteresPagar.MaxLength = 14
        Me.txtCapitalInteresPagar.Name = "txtCapitalInteresPagar"
        Me.txtCapitalInteresPagar.ReadOnly = True
        Me.txtCapitalInteresPagar.Size = New System.Drawing.Size(96, 21)
        Me.txtCapitalInteresPagar.TabIndex = 32
        Me.txtCapitalInteresPagar.TabStop = False
        Me.txtCapitalInteresPagar.Tag = "D"
        Me.txtCapitalInteresPagar.Text = "0.00"
        Me.txtCapitalInteresPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.SteelBlue
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(560, 160)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(190, 21)
        Me.Label36.TabIndex = 60
        Me.Label36.Text = "MORAS GENERADAS POR PAGAR"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMorasPagar
        '
        Me.txtMorasPagar.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMorasPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMorasPagar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtMorasPagar.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtMorasPagar.Location = New System.Drawing.Point(751, 160)
        Me.txtMorasPagar.MaxLength = 14
        Me.txtMorasPagar.Name = "txtMorasPagar"
        Me.txtMorasPagar.Size = New System.Drawing.Size(96, 21)
        Me.txtMorasPagar.TabIndex = 5
        Me.txtMorasPagar.TabStop = False
        Me.txtMorasPagar.Tag = "D"
        Me.txtMorasPagar.Text = "0.00"
        Me.txtMorasPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalProntoPago
        '
        Me.txtTotalProntoPago.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalProntoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalProntoPago.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalProntoPago.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalProntoPago.Location = New System.Drawing.Point(751, 182)
        Me.txtTotalProntoPago.MaxLength = 14
        Me.txtTotalProntoPago.Name = "txtTotalProntoPago"
        Me.txtTotalProntoPago.ReadOnly = True
        Me.txtTotalProntoPago.Size = New System.Drawing.Size(96, 21)
        Me.txtTotalProntoPago.TabIndex = 34
        Me.txtTotalProntoPago.TabStop = False
        Me.txtTotalProntoPago.Tag = "D"
        Me.txtTotalProntoPago.Text = "0.00"
        Me.txtTotalProntoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Brown
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(560, 182)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(190, 21)
        Me.Label37.TabIndex = 61
        Me.Label37.Text = "TOTAL POR PAGAR"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPorcentajeInteresAcumulado
        '
        Me.txtPorcentajeInteresAcumulado.BackColor = System.Drawing.Color.Moccasin
        Me.txtPorcentajeInteresAcumulado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentajeInteresAcumulado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtPorcentajeInteresAcumulado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPorcentajeInteresAcumulado.Location = New System.Drawing.Point(446, 138)
        Me.txtPorcentajeInteresAcumulado.MaxLength = 14
        Me.txtPorcentajeInteresAcumulado.Name = "txtPorcentajeInteresAcumulado"
        Me.txtPorcentajeInteresAcumulado.ReadOnly = True
        Me.txtPorcentajeInteresAcumulado.Size = New System.Drawing.Size(96, 21)
        Me.txtPorcentajeInteresAcumulado.TabIndex = 30
        Me.txtPorcentajeInteresAcumulado.TabStop = False
        Me.txtPorcentajeInteresAcumulado.Tag = "D"
        Me.txtPorcentajeInteresAcumulado.Text = "0.00"
        Me.txtPorcentajeInteresAcumulado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbFormaPagoPrestamo
        '
        Me.cmbFormaPagoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPagoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPagoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPagoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPagoPrestamo.FormattingEnabled = True
        Me.cmbFormaPagoPrestamo.Location = New System.Drawing.Point(579, 114)
        Me.cmbFormaPagoPrestamo.Name = "cmbFormaPagoPrestamo"
        Me.cmbFormaPagoPrestamo.Size = New System.Drawing.Size(26, 21)
        Me.cmbFormaPagoPrestamo.TabIndex = 76
        Me.cmbFormaPagoPrestamo.TabStop = False
        Me.cmbFormaPagoPrestamo.ValueMember = "CODIGO"
        Me.cmbFormaPagoPrestamo.Visible = False
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(611, 114)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(31, 21)
        Me.cmbTipoPrestamo.TabIndex = 77
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
        Me.cmbTipoPrestamo.Visible = False
        '
        'frmCobranzaProntoPago
        '
        Me.ClientSize = New System.Drawing.Size(861, 640)
        Me.Name = "frmCobranzaProntoPago"
        Me.Text = "COBRANZA POR PRONTO PAGO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDineroRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblPagoCambio As System.Windows.Forms.Label
    Friend WithEvents txtImportePago As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambioPago As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMonedaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumeroReciboInterno As System.Windows.Forms.Label
    Friend WithEvents txtNumeroReciboInterno As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaBaseCalculoMora As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gvCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMonedaPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtCobranza As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDineroVueltoMN As System.Windows.Forms.TextBox
    Friend WithEvents NUMERO_CUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_CUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDO_CUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS_MORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUOTA_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MORA_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROMISO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROMISO_COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECCIONAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EDITAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTasaMorosidadMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTasaInteresMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCapital As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtCapitalInteresPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtInteresPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtMesesTotales As System.Windows.Forms.TextBox
    Friend WithEvents txtMesesAdicionales As System.Windows.Forms.TextBox
    Friend WithEvents txtMesesActuales As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCuotasPagadas As System.Windows.Forms.TextBox
    Friend WithEvents txtMorasPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtTotalProntoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentajeInteresAcumulado As System.Windows.Forms.TextBox
    Friend WithEvents cmbFormaPagoPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox

End Class
