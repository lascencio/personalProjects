<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoricoPrestamos
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
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistoricoPrestamos))
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(810, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbFormaPago)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbTipoPrestamo)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label26)
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
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Size = New System.Drawing.Size(810, 513)
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
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 44)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 11
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
        Me.Label2.Location = New System.Drawing.Point(149, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(643, 18)
        Me.Label2.TabIndex = 32
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 44)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(643, 21)
        Me.txtRazonSocial.TabIndex = 17
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 44)
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
        Me.Label15.Location = New System.Drawing.Point(11, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(569, 67)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 18)
        Me.Label29.TabIndex = 35
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamo
        '
        Me.txtTotalPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamo.Location = New System.Drawing.Point(569, 86)
        Me.txtTotalPrestamo.MaxLength = 14
        Me.txtTotalPrestamo.Name = "txtTotalPrestamo"
        Me.txtTotalPrestamo.ReadOnly = True
        Me.txtTotalPrestamo.Size = New System.Drawing.Size(113, 21)
        Me.txtTotalPrestamo.TabIndex = 19
        Me.txtTotalPrestamo.TabStop = False
        Me.txtTotalPrestamo.Tag = "D"
        Me.txtTotalPrestamo.Text = "0.00"
        Me.txtTotalPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(461, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 34
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(461, 86)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 18
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 18)
        Me.Label5.TabIndex = 33
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
        Me.cmbPrestamo.Location = New System.Drawing.Point(11, 86)
        Me.cmbPrestamo.Name = "cmbPrestamo"
        Me.cmbPrestamo.Size = New System.Drawing.Size(107, 21)
        Me.cmbPrestamo.TabIndex = 1
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
        '
        'gvCuotas
        '
        Me.gvCuotas.AllowUserToAddRows = False
        Me.gvCuotas.AllowUserToDeleteRows = False
        Me.gvCuotas.AllowUserToOrderColumns = True
        Me.gvCuotas.AllowUserToResizeRows = False
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvCuotas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle31
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.gvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuotas.ColumnHeadersVisible = False
        Me.gvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMERO_CUOTA, Me.FECHA_VENCIMIENTO, Me.VALOR_CUOTA, Me.FECHA_PAGO, Me.SALDO_CUOTA, Me.DIAS_MORA, Me.MORA, Me.CUOTA_PAGO, Me.MORA_PAGO, Me.TOTAL_PAGO, Me.COMPROMISO_FECHA, Me.COMPROMISO_COMENTARIO, Me.SELECCIONAR})
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvCuotas.DefaultCellStyle = DataGridViewCellStyle44
        Me.gvCuotas.EnableHeadersVisualStyles = False
        Me.gvCuotas.Location = New System.Drawing.Point(11, 150)
        Me.gvCuotas.MultiSelect = False
        Me.gvCuotas.Name = "gvCuotas"
        Me.gvCuotas.ReadOnly = True
        Me.gvCuotas.RowHeadersVisible = False
        Me.gvCuotas.RowHeadersWidth = 13
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.OldLace
        Me.gvCuotas.RowsDefaultCellStyle = DataGridViewCellStyle45
        Me.gvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuotas.Size = New System.Drawing.Size(781, 350)
        Me.gvCuotas.TabIndex = 2
        Me.gvCuotas.TabStop = False
        '
        'NUMERO_CUOTA
        '
        Me.NUMERO_CUOTA.DataPropertyName = "NUMERO_CUOTA"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NUMERO_CUOTA.DefaultCellStyle = DataGridViewCellStyle33
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
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.Format = "d"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.FECHA_VENCIMIENTO.DefaultCellStyle = DataGridViewCellStyle34
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
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "N2"
        DataGridViewCellStyle35.NullValue = Nothing
        Me.VALOR_CUOTA.DefaultCellStyle = DataGridViewCellStyle35
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
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle36.Format = "d"
        DataGridViewCellStyle36.NullValue = Nothing
        Me.FECHA_PAGO.DefaultCellStyle = DataGridViewCellStyle36
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
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.SALDO_CUOTA.DefaultCellStyle = DataGridViewCellStyle37
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
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.NullValue = Nothing
        Me.DIAS_MORA.DefaultCellStyle = DataGridViewCellStyle38
        Me.DIAS_MORA.HeaderText = "Dias"
        Me.DIAS_MORA.Name = "DIAS_MORA"
        Me.DIAS_MORA.ReadOnly = True
        Me.DIAS_MORA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DIAS_MORA.Width = 35
        '
        'MORA
        '
        Me.MORA.DataPropertyName = "MORA"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "N2"
        Me.MORA.DefaultCellStyle = DataGridViewCellStyle39
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
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "N2"
        Me.CUOTA_PAGO.DefaultCellStyle = DataGridViewCellStyle40
        Me.CUOTA_PAGO.HeaderText = "Cuota Pagar"
        Me.CUOTA_PAGO.Name = "CUOTA_PAGO"
        Me.CUOTA_PAGO.ReadOnly = True
        Me.CUOTA_PAGO.Width = 65
        '
        'MORA_PAGO
        '
        Me.MORA_PAGO.DataPropertyName = "MORA_PAGO"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.Format = "N2"
        Me.MORA_PAGO.DefaultCellStyle = DataGridViewCellStyle41
        Me.MORA_PAGO.HeaderText = "Mora Pagar"
        Me.MORA_PAGO.Name = "MORA_PAGO"
        Me.MORA_PAGO.ReadOnly = True
        Me.MORA_PAGO.Width = 55
        '
        'TOTAL_PAGO
        '
        Me.TOTAL_PAGO.DataPropertyName = "TOTAL_PAGO"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        Me.TOTAL_PAGO.DefaultCellStyle = DataGridViewCellStyle42
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
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle43.Format = "d"
        DataGridViewCellStyle43.NullValue = Nothing
        Me.COMPROMISO_FECHA.DefaultCellStyle = DataGridViewCellStyle43
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
        Me.COMPROMISO_COMENTARIO.Width = 170
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
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(565, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(232, 20)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "HISTORICO DE PRESTAMOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(751, 86)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 25
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
        Me.txtMes.Location = New System.Drawing.Point(774, 86)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 26
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(736, 86)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(9, 21)
        Me.txtCuentaComercial.TabIndex = 24
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 114)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 36)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Cuota"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(46, 114)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 36)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Fecha Vencimiento"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(116, 114)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 36)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Valor Cuota"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(181, 114)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 36)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Fecha Pago"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(251, 114)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 36)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "Saldo Cuota"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(412, 114)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 36)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "Mora a Pagar"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(470, 114)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 36)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Importe a Pagar"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(535, 132)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 18)
        Me.Label20.TabIndex = 54
        Me.Label20.Text = "Fecha"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(605, 132)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(170, 18)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Comentario"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(775, 114)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(17, 36)
        Me.Label23.TabIndex = 56
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(314, 114)
        Me.Label25.Margin = New System.Windows.Forms.Padding(0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 36)
        Me.Label25.TabIndex = 49
        Me.Label25.Text = "Dias"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(535, 114)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(240, 18)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "Compromiso de Pago"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(351, 114)
        Me.Label27.Margin = New System.Windows.Forms.Padding(0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 36)
        Me.Label27.TabIndex = 50
        Me.Label27.Text = "Cuota a Pagar"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'txtPrestamo
        '
        Me.txtPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrestamo.Location = New System.Drawing.Point(708, 86)
        Me.txtPrestamo.MaxLength = 8
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.Size = New System.Drawing.Size(21, 21)
        Me.txtPrestamo.TabIndex = 16
        Me.txtPrestamo.TabStop = False
        Me.txtPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrestamo.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(319, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 18)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "FORMA DE PAGO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.Azure
        Me.cmbFormaPago.DisplayMember = "DESCRIPCION"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Location = New System.Drawing.Point(319, 86)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPago.TabIndex = 81
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(119, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 18)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "TIPO DE PRESTAMO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.Enabled = False
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(119, 86)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoPrestamo.TabIndex = 80
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
        '
        'frmHistoricoPrestamos
        '
        Me.ClientSize = New System.Drawing.Size(810, 567)
        Me.Name = "frmHistoricoPrestamos"
        Me.Text = "HISTORICO DE PRESTAMOS"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gvCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
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
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox

End Class
