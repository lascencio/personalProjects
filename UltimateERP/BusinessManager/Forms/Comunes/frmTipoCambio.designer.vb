<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoCambio
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPromedio = New System.Windows.Forms.TextBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.txtCompra = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gvTipoCambio = New System.Windows.Forms.DataGridView()
        Me.EJERCICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROMEDIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPRA_PREFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTA_PREFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPRA_REFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTA_REFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.gvTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(530, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.gvTipoCambio)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtPromedio)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.txtCompra)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbDia)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbMes)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cmbEjercicio)
        Me.Panel.Size = New System.Drawing.Size(530, 571)
        Me.Panel.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(160, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "DIA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDia
        '
        Me.cmbDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDia.BackColor = System.Drawing.Color.Azure
        Me.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDia.FormattingEnabled = True
        Me.cmbDia.Location = New System.Drawing.Point(160, 46)
        Me.cmbDia.MaxDropDownItems = 31
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(38, 21)
        Me.cmbDia.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(81, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 21)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "MES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(81, 46)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(78, 21)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "EJERCICIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(11, 46)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(69, 21)
        Me.cmbEjercicio.TabIndex = 0
        Me.cmbEjercicio.TabStop = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(366, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(154, 20)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "TIPO DE CAMBIO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPromedio
        '
        Me.txtPromedio.BackColor = System.Drawing.Color.LightYellow
        Me.txtPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPromedio.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtPromedio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPromedio.Location = New System.Drawing.Point(395, 46)
        Me.txtPromedio.MaxLength = 10
        Me.txtPromedio.Name = "txtPromedio"
        Me.txtPromedio.Size = New System.Drawing.Size(96, 21)
        Me.txtPromedio.TabIndex = 5
        Me.txtPromedio.TabStop = False
        Me.txtPromedio.Tag = "C"
        Me.txtPromedio.Text = "0.000"
        Me.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Honeydew
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVenta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtVenta.Location = New System.Drawing.Point(296, 46)
        Me.txtVenta.MaxLength = 10
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(98, 21)
        Me.txtVenta.TabIndex = 4
        Me.txtVenta.Tag = "C"
        Me.txtVenta.Text = "0.000"
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCompra
        '
        Me.txtCompra.BackColor = System.Drawing.Color.Honeydew
        Me.txtCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCompra.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCompra.Location = New System.Drawing.Point(199, 46)
        Me.txtCompra.MaxLength = 10
        Me.txtCompra.Name = "txtCompra"
        Me.txtCompra.Size = New System.Drawing.Size(96, 21)
        Me.txtCompra.TabIndex = 3
        Me.txtCompra.Tag = "C"
        Me.txtCompra.Text = "0.000"
        Me.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(199, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 21)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "COMPRA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(296, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 21)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "VENTA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(395, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 21)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "PROMEDIO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvTipoCambio
        '
        Me.gvTipoCambio.AllowUserToAddRows = False
        Me.gvTipoCambio.AllowUserToDeleteRows = False
        Me.gvTipoCambio.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvTipoCambio.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvTipoCambio.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvTipoCambio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvTipoCambio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EJERCICIO, Me.MES, Me.DIA, Me.MONEDA, Me.COMPRA, Me.VENTA, Me.PROMEDIO, Me.COMPRA_PREFERENCIAL, Me.VENTA_PREFERENCIAL, Me.COMPRA_REFERENCIAL, Me.VENTA_REFERENCIAL, Me.USUARIO_REGISTRO, Me.FECHA_REGISTRO, Me.USUARIO_MODIFICA, Me.FECHA_MODIFICA})
        Me.gvTipoCambio.Location = New System.Drawing.Point(11, 73)
        Me.gvTipoCambio.Name = "gvTipoCambio"
        Me.gvTipoCambio.ReadOnly = True
        Me.gvTipoCambio.RowHeadersWidth = 20
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.OldLace
        Me.gvTipoCambio.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gvTipoCambio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvTipoCambio.Size = New System.Drawing.Size(506, 485)
        Me.gvTipoCambio.TabIndex = 6
        Me.gvTipoCambio.TabStop = False
        '
        'EJERCICIO
        '
        Me.EJERCICIO.DataPropertyName = "EJERCICIO"
        Me.EJERCICIO.HeaderText = "EJERCICIO"
        Me.EJERCICIO.Name = "EJERCICIO"
        Me.EJERCICIO.ReadOnly = True
        Me.EJERCICIO.Width = 70
        '
        'MES
        '
        Me.MES.DataPropertyName = "MES"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MES.DefaultCellStyle = DataGridViewCellStyle3
        Me.MES.HeaderText = "MES"
        Me.MES.Name = "MES"
        Me.MES.ReadOnly = True
        Me.MES.Width = 50
        '
        'DIA
        '
        Me.DIA.DataPropertyName = "DIA"
        Me.DIA.HeaderText = "DIA"
        Me.DIA.Name = "DIA"
        Me.DIA.ReadOnly = True
        Me.DIA.Width = 40
        '
        'MONEDA
        '
        Me.MONEDA.DataPropertyName = "MONEDA"
        Me.MONEDA.HeaderText = "MONEDA"
        Me.MONEDA.Name = "MONEDA"
        Me.MONEDA.ReadOnly = True
        Me.MONEDA.Visible = False
        '
        'COMPRA
        '
        Me.COMPRA.DataPropertyName = "COMPRA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.COMPRA.DefaultCellStyle = DataGridViewCellStyle4
        Me.COMPRA.HeaderText = "COMPRA"
        Me.COMPRA.Name = "COMPRA"
        Me.COMPRA.ReadOnly = True
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.VENTA.DefaultCellStyle = DataGridViewCellStyle5
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        '
        'PROMEDIO
        '
        Me.PROMEDIO.DataPropertyName = "PROMEDIO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N3"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PROMEDIO.DefaultCellStyle = DataGridViewCellStyle6
        Me.PROMEDIO.HeaderText = "PROMEDIO"
        Me.PROMEDIO.Name = "PROMEDIO"
        Me.PROMEDIO.ReadOnly = True
        '
        'COMPRA_PREFERENCIAL
        '
        Me.COMPRA_PREFERENCIAL.DataPropertyName = "COMPRA_PREFERENCIAL"
        Me.COMPRA_PREFERENCIAL.HeaderText = "COMPRA_PREFERENCIAL"
        Me.COMPRA_PREFERENCIAL.Name = "COMPRA_PREFERENCIAL"
        Me.COMPRA_PREFERENCIAL.ReadOnly = True
        Me.COMPRA_PREFERENCIAL.Visible = False
        '
        'VENTA_PREFERENCIAL
        '
        Me.VENTA_PREFERENCIAL.DataPropertyName = "VENTA_PREFERENCIAL"
        Me.VENTA_PREFERENCIAL.HeaderText = "VENTA_PREFERENCIAL"
        Me.VENTA_PREFERENCIAL.Name = "VENTA_PREFERENCIAL"
        Me.VENTA_PREFERENCIAL.ReadOnly = True
        Me.VENTA_PREFERENCIAL.Visible = False
        '
        'COMPRA_REFERENCIAL
        '
        Me.COMPRA_REFERENCIAL.DataPropertyName = "COMPRA_REFERENCIAL"
        Me.COMPRA_REFERENCIAL.HeaderText = "COMPRA_REFERENCIAL"
        Me.COMPRA_REFERENCIAL.Name = "COMPRA_REFERENCIAL"
        Me.COMPRA_REFERENCIAL.ReadOnly = True
        Me.COMPRA_REFERENCIAL.Visible = False
        '
        'VENTA_REFERENCIAL
        '
        Me.VENTA_REFERENCIAL.DataPropertyName = "VENTA_REFERENCIAL"
        Me.VENTA_REFERENCIAL.HeaderText = "VENTA_REFERENCIAL"
        Me.VENTA_REFERENCIAL.Name = "VENTA_REFERENCIAL"
        Me.VENTA_REFERENCIAL.ReadOnly = True
        Me.VENTA_REFERENCIAL.Visible = False
        '
        'USUARIO_REGISTRO
        '
        Me.USUARIO_REGISTRO.DataPropertyName = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.HeaderText = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.Name = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.ReadOnly = True
        Me.USUARIO_REGISTRO.Visible = False
        '
        'FECHA_REGISTRO
        '
        Me.FECHA_REGISTRO.DataPropertyName = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.HeaderText = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.Name = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.ReadOnly = True
        Me.FECHA_REGISTRO.Visible = False
        '
        'USUARIO_MODIFICA
        '
        Me.USUARIO_MODIFICA.DataPropertyName = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.HeaderText = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.Name = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.ReadOnly = True
        Me.USUARIO_MODIFICA.Visible = False
        '
        'FECHA_MODIFICA
        '
        Me.FECHA_MODIFICA.DataPropertyName = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.HeaderText = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.Name = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.ReadOnly = True
        Me.FECHA_MODIFICA.Visible = False
        '
        'frmTipoCambio
        '
        Me.ClientSize = New System.Drawing.Size(530, 625)
        Me.Name = "frmTipoCambio"
        Me.Text = " Tipo de Cambio"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPromedio As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCompra As System.Windows.Forms.TextBox
    Friend WithEvents gvTipoCambio As System.Windows.Forms.DataGridView
    Friend WithEvents EJERCICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROMEDIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPRA_PREFERENCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA_PREFERENCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPRA_REFERENCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA_REFERENCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_MODIFICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_MODIFICA As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
