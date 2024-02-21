<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReprogramarCuotasPendientes
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
        Me.btnBuscarPrestamo = New System.Windows.Forms.Button()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
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
        Me.seleccionar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrestamo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalCuotasPendientes = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalPrestamo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.txtFechaReprogramar = New System.Windows.Forms.TextBox()
        Me.txtFechaVigente = New System.Windows.Forms.TextBox()
        Me.lblCompromisoFecha = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCalcularFechas = New System.Windows.Forms.Button()
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
        Me.UC_ToolBar.Size = New System.Drawing.Size(647, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbTipoPrestamo)
        Me.Panel.Controls.Add(Me.btnCalcularFechas)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.lblCompromisoFecha)
        Me.Panel.Controls.Add(Me.txtFechaVigente)
        Me.Panel.Controls.Add(Me.txtFechaReprogramar)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbFormaPago)
        Me.Panel.Controls.Add(Me.btnBuscarPrestamo)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.gvCuotas)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cmbPrestamo)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtTotalCuotasPendientes)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtTotalPrestamo)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Size = New System.Drawing.Size(647, 446)
        Me.Panel.TabIndex = 0
        '
        'btnBuscarPrestamo
        '
        Me.btnBuscarPrestamo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPrestamo.Location = New System.Drawing.Point(118, 81)
        Me.btnBuscarPrestamo.Name = "btnBuscarPrestamo"
        Me.btnBuscarPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscarPrestamo.TabIndex = 3
        Me.btnBuscarPrestamo.Text = "..."
        Me.btnBuscarPrestamo.UseVisualStyleBackColor = True
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(11, 224)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 13
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
        Me.txtMes.Location = New System.Drawing.Point(34, 224)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 14
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(300, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(339, 20)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "REPROGRAMAR CUOTAS PENDIENTES"
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMERO_CUOTA, Me.FECHA_VENCIMIENTO, Me.VALOR_CUOTA, Me.FECHA_PAGO, Me.SALDO_CUOTA, Me.DIAS_MORA, Me.MORA, Me.CUOTA_PAGO, Me.MORA_PAGO, Me.TOTAL_PAGO, Me.COMPROMISO_FECHA, Me.COMPROMISO_COMENTARIO, Me.seleccionar})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvCuotas.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvCuotas.EnableHeadersVisualStyles = False
        Me.gvCuotas.Location = New System.Drawing.Point(272, 109)
        Me.gvCuotas.MultiSelect = False
        Me.gvCuotas.Name = "gvCuotas"
        Me.gvCuotas.ReadOnly = True
        Me.gvCuotas.RowHeadersVisible = False
        Me.gvCuotas.RowHeadersWidth = 13
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.OldLace
        Me.gvCuotas.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.gvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuotas.Size = New System.Drawing.Size(361, 324)
        Me.gvCuotas.TabIndex = 4
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
        Me.NUMERO_CUOTA.Width = 50
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
        Me.FECHA_VENCIMIENTO.Width = 88
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
        Me.VALOR_CUOTA.Width = 90
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
        Me.FECHA_PAGO.Visible = False
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
        Me.SALDO_CUOTA.Width = 90
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
        Me.DIAS_MORA.Visible = False
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
        Me.CUOTA_PAGO.Visible = False
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
        Me.MORA_PAGO.Visible = False
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
        Me.TOTAL_PAGO.Visible = False
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
        Me.COMPROMISO_FECHA.Visible = False
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
        Me.COMPROMISO_COMENTARIO.Visible = False
        Me.COMPROMISO_COMENTARIO.Width = 170
        '
        'seleccionar
        '
        Me.seleccionar.DataPropertyName = "SELECCIONAR"
        Me.seleccionar.HeaderText = ""
        Me.seleccionar.Name = "seleccionar"
        Me.seleccionar.ReadOnly = True
        Me.seleccionar.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 18)
        Me.Label5.TabIndex = 18
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
        Me.cmbPrestamo.Location = New System.Drawing.Point(11, 82)
        Me.cmbPrestamo.Name = "cmbPrestamo"
        Me.cmbPrestamo.Size = New System.Drawing.Size(107, 21)
        Me.cmbPrestamo.TabIndex = 1
        Me.cmbPrestamo.TabStop = False
        Me.cmbPrestamo.ValueMember = "PRESTAMO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(529, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "TOTAL CUOTAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalCuotasPendientes
        '
        Me.txtTotalCuotasPendientes.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalCuotasPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCuotasPendientes.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalCuotasPendientes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalCuotasPendientes.Location = New System.Drawing.Point(529, 82)
        Me.txtTotalCuotasPendientes.MaxLength = 14
        Me.txtTotalCuotasPendientes.Name = "txtTotalCuotasPendientes"
        Me.txtTotalCuotasPendientes.ReadOnly = True
        Me.txtTotalCuotasPendientes.Size = New System.Drawing.Size(104, 21)
        Me.txtTotalCuotasPendientes.TabIndex = 10
        Me.txtTotalCuotasPendientes.TabStop = False
        Me.txtTotalCuotasPendientes.Tag = "D"
        Me.txtTotalCuotasPendientes.Text = "0.00"
        Me.txtTotalCuotasPendientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SteelBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(251, 63)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 18)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "IMPORTE"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalPrestamo
        '
        Me.txtTotalPrestamo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrestamo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtTotalPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotalPrestamo.Location = New System.Drawing.Point(251, 82)
        Me.txtTotalPrestamo.MaxLength = 14
        Me.txtTotalPrestamo.Name = "txtTotalPrestamo"
        Me.txtTotalPrestamo.ReadOnly = True
        Me.txtTotalPrestamo.Size = New System.Drawing.Size(113, 21)
        Me.txtTotalPrestamo.TabIndex = 8
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
        Me.Label19.Location = New System.Drawing.Point(143, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 18)
        Me.Label19.TabIndex = 19
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(143, 82)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(106, 21)
        Me.cmbTipoMoneda.TabIndex = 7
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
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
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(11, 39)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 5
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
        Me.Label2.Location = New System.Drawing.Point(149, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(484, 18)
        Me.Label2.TabIndex = 17
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
        Me.txtRazonSocial.Location = New System.Drawing.Point(149, 39)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(484, 21)
        Me.txtRazonSocial.TabIndex = 6
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(68, 39)
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
        Me.Label15.Location = New System.Drawing.Point(11, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(366, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 18)
        Me.Label3.TabIndex = 21
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
        Me.cmbFormaPago.Location = New System.Drawing.Point(366, 82)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(141, 21)
        Me.cmbFormaPago.TabIndex = 9
        Me.cmbFormaPago.TabStop = False
        Me.cmbFormaPago.ValueMember = "CODIGO"
        '
        'txtFechaReprogramar
        '
        Me.txtFechaReprogramar.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaReprogramar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaReprogramar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaReprogramar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaReprogramar.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaReprogramar.Location = New System.Drawing.Point(181, 151)
        Me.txtFechaReprogramar.MaxLength = 50
        Me.txtFechaReprogramar.Name = "txtFechaReprogramar"
        Me.txtFechaReprogramar.Size = New System.Drawing.Size(68, 21)
        Me.txtFechaReprogramar.TabIndex = 12
        Me.txtFechaReprogramar.TabStop = False
        Me.txtFechaReprogramar.Tag = "F"
        Me.txtFechaReprogramar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaVigente
        '
        Me.txtFechaVigente.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaVigente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVigente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaVigente.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaVigente.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaVigente.Location = New System.Drawing.Point(181, 129)
        Me.txtFechaVigente.MaxLength = 10
        Me.txtFechaVigente.Name = "txtFechaVigente"
        Me.txtFechaVigente.ReadOnly = True
        Me.txtFechaVigente.Size = New System.Drawing.Size(68, 21)
        Me.txtFechaVigente.TabIndex = 11
        Me.txtFechaVigente.TabStop = False
        Me.txtFechaVigente.Tag = "F"
        Me.txtFechaVigente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCompromisoFecha
        '
        Me.lblCompromisoFecha.BackColor = System.Drawing.Color.Gray
        Me.lblCompromisoFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompromisoFecha.Enabled = False
        Me.lblCompromisoFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.lblCompromisoFecha.ForeColor = System.Drawing.Color.White
        Me.lblCompromisoFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCompromisoFecha.Location = New System.Drawing.Point(11, 129)
        Me.lblCompromisoFecha.Name = "lblCompromisoFecha"
        Me.lblCompromisoFecha.Size = New System.Drawing.Size(168, 21)
        Me.lblCompromisoFecha.TabIndex = 24
        Me.lblCompromisoFecha.Text = "FECHA VIGENTE"
        Me.lblCompromisoFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "FECHA A REPROGRAMAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(11, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(238, 21)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "PROXIMA FECHA DE VENCIMIENTO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCalcularFechas
        '
        Me.btnCalcularFechas.Enabled = False
        Me.btnCalcularFechas.ForeColor = System.Drawing.Color.Navy
        Me.btnCalcularFechas.Location = New System.Drawing.Point(11, 173)
        Me.btnCalcularFechas.Name = "btnCalcularFechas"
        Me.btnCalcularFechas.Size = New System.Drawing.Size(238, 43)
        Me.btnCalcularFechas.TabIndex = 2
        Me.btnCalcularFechas.Text = "CALCULAR NUEVAS FECHAS DE VENCIMIENTO"
        Me.btnCalcularFechas.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(11, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 18)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "TIPO DE PRESTAMO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'cmbTipoPrestamo
        '
        Me.cmbTipoPrestamo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoPrestamo.DisplayMember = "DESCRIPCION"
        Me.cmbTipoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrestamo.Enabled = False
        Me.cmbTipoPrestamo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoPrestamo.FormattingEnabled = True
        Me.cmbTipoPrestamo.Location = New System.Drawing.Point(11, 412)
        Me.cmbTipoPrestamo.Name = "cmbTipoPrestamo"
        Me.cmbTipoPrestamo.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoPrestamo.TabIndex = 79
        Me.cmbTipoPrestamo.TabStop = False
        Me.cmbTipoPrestamo.ValueMember = "CODIGO"
        Me.cmbTipoPrestamo.Visible = False
        '
        'frmReprogramarCuotasPendientes
        '
        Me.ClientSize = New System.Drawing.Size(647, 500)
        Me.Name = "frmReprogramarCuotasPendientes"
        Me.Text = "REPROGRAMAR CUOTAS PENDIENTES"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscarPrestamo As System.Windows.Forms.Button
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gvCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPrestamo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCuotasPendientes As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtFechaReprogramar As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVigente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCompromisoFecha As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCalcularFechas As System.Windows.Forms.Button
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
    Friend WithEvents seleccionar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrestamo As System.Windows.Forms.ComboBox

End Class
