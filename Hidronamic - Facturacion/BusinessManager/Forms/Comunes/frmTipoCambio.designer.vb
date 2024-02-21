<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoCambio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTipoCambio))
        Me.gvTipoCambio = New System.Windows.Forms.DataGridView
        Me.EJERCICIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DIA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROMEDIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPRA_PREFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA_PREFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPRA_REFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA_REFERENCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.USUARIO_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.USUARIO_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHA_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPromedio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVenta = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbDia = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCompra = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        CType(Me.gvTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvTipoCambio
        '
        Me.gvTipoCambio.AllowUserToAddRows = False
        Me.gvTipoCambio.AllowUserToDeleteRows = False
        Me.gvTipoCambio.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvTipoCambio.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvTipoCambio.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gvTipoCambio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvTipoCambio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EJERCICIO, Me.MES, Me.DIA, Me.MONEDA, Me.COMPRA, Me.VENTA, Me.PROMEDIO, Me.COMPRA_PREFERENCIAL, Me.VENTA_PREFERENCIAL, Me.COMPRA_REFERENCIAL, Me.VENTA_REFERENCIAL, Me.USUARIO_REGISTRO, Me.FECHA_REGISTRO, Me.USUARIO_MODIFICA, Me.FECHA_MODIFICA})
        Me.gvTipoCambio.Location = New System.Drawing.Point(12, 110)
        Me.gvTipoCambio.Name = "gvTipoCambio"
        Me.gvTipoCambio.ReadOnly = True
        Me.gvTipoCambio.RowHeadersWidth = 20
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.OldLace
        Me.gvTipoCambio.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gvTipoCambio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvTipoCambio.Size = New System.Drawing.Size(389, 507)
        Me.gvTipoCambio.TabIndex = 7
        '
        'EJERCICIO
        '
        Me.EJERCICIO.DataPropertyName = "EJERCICIO"
        Me.EJERCICIO.HeaderText = "EJERCICIO"
        Me.EJERCICIO.Name = "EJERCICIO"
        Me.EJERCICIO.ReadOnly = True
        Me.EJERCICIO.Visible = False
        '
        'MES
        '
        Me.MES.DataPropertyName = "MES"
        Me.MES.HeaderText = "MES"
        Me.MES.Name = "MES"
        Me.MES.ReadOnly = True
        Me.MES.Visible = False
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N3"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.COMPRA.DefaultCellStyle = DataGridViewCellStyle9
        Me.COMPRA.HeaderText = "COMPRA"
        Me.COMPRA.Name = "COMPRA"
        Me.COMPRA.ReadOnly = True
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N3"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.VENTA.DefaultCellStyle = DataGridViewCellStyle10
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        '
        'PROMEDIO
        '
        Me.PROMEDIO.DataPropertyName = "PROMEDIO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N3"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.PROMEDIO.DefaultCellStyle = DataGridViewCellStyle11
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(257, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "PROMEDIO"
        '
        'txtPromedio
        '
        Me.txtPromedio.BackColor = System.Drawing.Color.LightYellow
        Me.txtPromedio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPromedio.Location = New System.Drawing.Point(260, 84)
        Me.txtPromedio.MaxLength = 10
        Me.txtPromedio.Name = "txtPromedio"
        Me.txtPromedio.Size = New System.Drawing.Size(96, 20)
        Me.txtPromedio.TabIndex = 5
        Me.txtPromedio.TabStop = False
        Me.txtPromedio.Tag = "C"
        Me.txtPromedio.Text = "0.000"
        Me.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(157, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "VENTA"
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Honeydew
        Me.txtVenta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtVenta.Location = New System.Drawing.Point(160, 84)
        Me.txtVenta.MaxLength = 10
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(98, 20)
        Me.txtVenta.TabIndex = 4
        Me.txtVenta.Tag = "C"
        Me.txtVenta.Text = "0.000"
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "DIA"
        '
        'cmbDia
        '
        Me.cmbDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDia.BackColor = System.Drawing.Color.Azure
        Me.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDia.FormattingEnabled = True
        Me.cmbDia.Location = New System.Drawing.Point(13, 83)
        Me.cmbDia.MaxDropDownItems = 12
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(42, 21)
        Me.cmbDia.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(59, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "COMPRA"
        '
        'txtCompra
        '
        Me.txtCompra.BackColor = System.Drawing.Color.Honeydew
        Me.txtCompra.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCompra.Location = New System.Drawing.Point(62, 84)
        Me.txtCompra.MaxLength = 10
        Me.txtCompra.Name = "txtCompra"
        Me.txtCompra.Size = New System.Drawing.Size(96, 20)
        Me.txtCompra.TabIndex = 3
        Me.txtCompra.Tag = "C"
        Me.txtCompra.Text = "0.000"
        Me.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "MES"
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(103, 25)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "EJERCICIO"
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 25)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 0
        Me.cmbEjercicio.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(362, 64)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(40, 40)
        Me.btnGrabar.TabIndex = 14
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(362, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTipoCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 629)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.gvTipoCambio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPromedio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbDia)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCompra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoCambio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPO DE CAMBIO"
        CType(Me.gvTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvTipoCambio As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPromedio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDia As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
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
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
