<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEComprobantesServiciosLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEComprobantesServiciosLista))
        Me.rbtCuentaComercial = New System.Windows.Forms.RadioButton()
        Me.rbtTodos = New System.Windows.Forms.RadioButton()
        Me.cmbCuentaComercial = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gvVentas = New System.Windows.Forms.DataGridView()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_CAMBIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOSA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTO_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_AFECTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_EXENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtCuentaComercial
        '
        Me.rbtCuentaComercial.AutoSize = True
        Me.rbtCuentaComercial.Location = New System.Drawing.Point(12, 30)
        Me.rbtCuentaComercial.Name = "rbtCuentaComercial"
        Me.rbtCuentaComercial.Size = New System.Drawing.Size(70, 17)
        Me.rbtCuentaComercial.TabIndex = 2
        Me.rbtCuentaComercial.Text = "CLIENTE"
        Me.rbtCuentaComercial.UseVisualStyleBackColor = True
        Me.rbtCuentaComercial.Visible = False
        '
        'rbtTodos
        '
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Location = New System.Drawing.Point(12, 12)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(63, 17)
        Me.rbtTodos.TabIndex = 1
        Me.rbtTodos.TabStop = True
        Me.rbtTodos.Text = "TODOS"
        Me.rbtTodos.UseVisualStyleBackColor = True
        Me.rbtTodos.Visible = False
        '
        'cmbCuentaComercial
        '
        Me.cmbCuentaComercial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCuentaComercial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCuentaComercial.BackColor = System.Drawing.Color.Azure
        Me.cmbCuentaComercial.DisplayMember = "RAZON_SOCIAL"
        Me.cmbCuentaComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaComercial.Enabled = False
        Me.cmbCuentaComercial.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbCuentaComercial.FormattingEnabled = True
        Me.cmbCuentaComercial.Location = New System.Drawing.Point(113, 29)
        Me.cmbCuentaComercial.MaxDropDownItems = 16
        Me.cmbCuentaComercial.Name = "cmbCuentaComercial"
        Me.cmbCuentaComercial.Size = New System.Drawing.Size(588, 21)
        Me.cmbCuentaComercial.TabIndex = 3
        Me.cmbCuentaComercial.ValueMember = "CUENTA_COMERCIAL"
        Me.cmbCuentaComercial.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1011, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(131, 24)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gvVentas
        '
        Me.gvVentas.AllowUserToAddRows = False
        Me.gvVentas.AllowUserToDeleteRows = False
        Me.gvVentas.AllowUserToOrderColumns = True
        Me.gvVentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VENTA, Me.CUENTA_COMERCIAL, Me.RAZON_SOCIAL, Me.ASIENTO_NUMERO, Me.ASIENTO_FECHA, Me.MONEDA, Me.TIPO_CAMBIO, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.COMPROBANTE_FECHA, Me.GLOSA, Me.MONTO_TOTAL, Me.VALOR_AFECTO, Me.VALOR_EXENTO, Me.IMPUESTO, Me.ESTADO, Me.USUARIO_ENVIO, Me.FECHA_ENVIO})
        Me.gvVentas.Location = New System.Drawing.Point(9, 60)
        Me.gvVentas.MultiSelect = False
        Me.gvVentas.Name = "gvVentas"
        Me.gvVentas.ReadOnly = True
        Me.gvVentas.RowHeadersVisible = False
        Me.gvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentas.Size = New System.Drawing.Size(1133, 588)
        Me.gvVentas.TabIndex = 0
        Me.gvVentas.TabStop = False
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.Visible = False
        Me.VENTA.Width = 85
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "RUC/ANEXO"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        Me.CUENTA_COMERCIAL.Width = 90
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "CLIENTE"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 270
        '
        'ASIENTO_NUMERO
        '
        Me.ASIENTO_NUMERO.DataPropertyName = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.HeaderText = "ASIENTO"
        Me.ASIENTO_NUMERO.Name = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.ReadOnly = True
        Me.ASIENTO_NUMERO.Width = 60
        '
        'ASIENTO_FECHA
        '
        Me.ASIENTO_FECHA.DataPropertyName = "ASIENTO_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ASIENTO_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.ASIENTO_FECHA.HeaderText = "FECHA"
        Me.ASIENTO_FECHA.Name = "ASIENTO_FECHA"
        Me.ASIENTO_FECHA.ReadOnly = True
        Me.ASIENTO_FECHA.Width = 70
        '
        'MONEDA
        '
        Me.MONEDA.DataPropertyName = "MONEDA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MONEDA.DefaultCellStyle = DataGridViewCellStyle3
        Me.MONEDA.HeaderText = "MON"
        Me.MONEDA.Name = "MONEDA"
        Me.MONEDA.ReadOnly = True
        Me.MONEDA.Width = 40
        '
        'TIPO_CAMBIO
        '
        Me.TIPO_CAMBIO.DataPropertyName = "TIPO_CAMBIO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.TIPO_CAMBIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.TIPO_CAMBIO.HeaderText = "TC"
        Me.TIPO_CAMBIO.Name = "TIPO_CAMBIO"
        Me.TIPO_CAMBIO.ReadOnly = True
        Me.TIPO_CAMBIO.Width = 40
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.Width = 50
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        Me.COMPROBANTE_NUMERO.Width = 70
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle5
        Me.COMPROBANTE_FECHA.HeaderText = "FECHA"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.Width = 70
        '
        'GLOSA
        '
        Me.GLOSA.DataPropertyName = "GLOSA"
        Me.GLOSA.HeaderText = "GLOSA"
        Me.GLOSA.Name = "GLOSA"
        Me.GLOSA.ReadOnly = True
        Me.GLOSA.Visible = False
        '
        'MONTO_TOTAL
        '
        Me.MONTO_TOTAL.DataPropertyName = "MONTO_TOTAL"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.MONTO_TOTAL.DefaultCellStyle = DataGridViewCellStyle6
        Me.MONTO_TOTAL.HeaderText = "PRECIO_VENTA"
        Me.MONTO_TOTAL.Name = "MONTO_TOTAL"
        Me.MONTO_TOTAL.ReadOnly = True
        '
        'VALOR_AFECTO
        '
        Me.VALOR_AFECTO.DataPropertyName = "VALOR_AFECTO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.VALOR_AFECTO.DefaultCellStyle = DataGridViewCellStyle7
        Me.VALOR_AFECTO.HeaderText = "AFECTO"
        Me.VALOR_AFECTO.Name = "VALOR_AFECTO"
        Me.VALOR_AFECTO.ReadOnly = True
        Me.VALOR_AFECTO.Visible = False
        Me.VALOR_AFECTO.Width = 80
        '
        'VALOR_EXENTO
        '
        Me.VALOR_EXENTO.DataPropertyName = "VALOR_EXENTO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.VALOR_EXENTO.DefaultCellStyle = DataGridViewCellStyle8
        Me.VALOR_EXENTO.HeaderText = "EXENTO"
        Me.VALOR_EXENTO.Name = "VALOR_EXENTO"
        Me.VALOR_EXENTO.ReadOnly = True
        Me.VALOR_EXENTO.Visible = False
        Me.VALOR_EXENTO.Width = 80
        '
        'IMPUESTO
        '
        Me.IMPUESTO.DataPropertyName = "IMPUESTO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.IMPUESTO.DefaultCellStyle = DataGridViewCellStyle9
        Me.IMPUESTO.HeaderText = "IMPUESTO"
        Me.IMPUESTO.Name = "IMPUESTO"
        Me.IMPUESTO.ReadOnly = True
        Me.IMPUESTO.Visible = False
        Me.IMPUESTO.Width = 70
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle10
        Me.ESTADO.HeaderText = "EST"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        Me.ESTADO.Width = 40
        '
        'USUARIO_ENVIO
        '
        Me.USUARIO_ENVIO.DataPropertyName = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.HeaderText = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.Name = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.ReadOnly = True
        '
        'FECHA_ENVIO
        '
        Me.FECHA_ENVIO.DataPropertyName = "FECHA_ENVIO"
        DataGridViewCellStyle11.Format = "G"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.FECHA_ENVIO.DefaultCellStyle = DataGridViewCellStyle11
        Me.FECHA_ENVIO.HeaderText = "FECHA_ENVIO"
        Me.FECHA_ENVIO.Name = "FECHA_ENVIO"
        Me.FECHA_ENVIO.ReadOnly = True
        Me.FECHA_ENVIO.Width = 140
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(942, 6)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(200, 14)
        Me.MyProgressBar.TabIndex = 6
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(885, 10)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(40, 40)
        Me.btnExportarExcel.TabIndex = 5
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'frmFacturacionServiciosLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 660)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.rbtCuentaComercial)
        Me.Controls.Add(Me.rbtTodos)
        Me.Controls.Add(Me.cmbCuentaComercial)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.gvVentas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacionServiciosLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE COMPROBANTES"
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtCuentaComercial As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCuentaComercial As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_CAMBIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONTO_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_AFECTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_EXENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
