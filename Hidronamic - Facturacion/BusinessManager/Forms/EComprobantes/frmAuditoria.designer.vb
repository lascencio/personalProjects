<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditoria
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvVentas = New System.Windows.Forms.DataGridView()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIENE_EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_CAMBIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOSA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTO_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_AFECTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_EXENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(1254, 36)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.gvVentas)
        Me.Panel.Size = New System.Drawing.Size(1254, 614)
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
        Me.gvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VENTA, Me.COMPROBANTE_FECHA, Me.COMPROBANTE_TIPO, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.CUENTA_COMERCIAL, Me.RAZON_SOCIAL, Me.TIENE_EMAIL, Me.ASIENTO_NUMERO, Me.ASIENTO_FECHA, Me.MONEDA, Me.TIPO_CAMBIO, Me.GLOSA, Me.MONTO_TOTAL, Me.VALOR_AFECTO, Me.VALOR_EXENTO, Me.IMPUESTO, Me.USUARIO_REGISTRO, Me.FECHA_REGISTRO, Me.ESTADO, Me.EMAIL})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvVentas.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvVentas.EnableHeadersVisualStyles = False
        Me.gvVentas.Location = New System.Drawing.Point(0, 0)
        Me.gvVentas.MultiSelect = False
        Me.gvVentas.Name = "gvVentas"
        Me.gvVentas.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.gvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentas.Size = New System.Drawing.Size(1252, 612)
        Me.gvVentas.TabIndex = 2
        Me.gvVentas.TabStop = False
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VENTA.Visible = False
        Me.VENTA.Width = 85
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPROBANTE_FECHA.HeaderText = "FECHA EMISION"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_FECHA.Visible = False
        Me.COMPROBANTE_FECHA.Width = 140
        '
        'COMPROBANTE_TIPO
        '
        Me.COMPROBANTE_TIPO.DataPropertyName = "COMPROBANTE_TIPO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COMPROBANTE_TIPO.DefaultCellStyle = DataGridViewCellStyle3
        Me.COMPROBANTE_TIPO.HeaderText = "TIPO"
        Me.COMPROBANTE_TIPO.Name = "COMPROBANTE_TIPO"
        Me.COMPROBANTE_TIPO.ReadOnly = True
        Me.COMPROBANTE_TIPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_TIPO.Width = 35
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_SERIE.Width = 45
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        Me.COMPROBANTE_NUMERO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_NUMERO.Width = 70
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "RUC"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        Me.CUENTA_COMERCIAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CUENTA_COMERCIAL.Width = 90
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "CLIENTE"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RAZON_SOCIAL.Width = 280
        '
        'TIENE_EMAIL
        '
        Me.TIENE_EMAIL.DataPropertyName = "TIENE_EMAIL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TIENE_EMAIL.DefaultCellStyle = DataGridViewCellStyle4
        Me.TIENE_EMAIL.HeaderText = "EMAIL"
        Me.TIENE_EMAIL.Name = "TIENE_EMAIL"
        Me.TIENE_EMAIL.ReadOnly = True
        Me.TIENE_EMAIL.Width = 40
        '
        'ASIENTO_NUMERO
        '
        Me.ASIENTO_NUMERO.DataPropertyName = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.HeaderText = "ASIENTO"
        Me.ASIENTO_NUMERO.Name = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.ReadOnly = True
        Me.ASIENTO_NUMERO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ASIENTO_NUMERO.Visible = False
        Me.ASIENTO_NUMERO.Width = 60
        '
        'ASIENTO_FECHA
        '
        Me.ASIENTO_FECHA.DataPropertyName = "ASIENTO_FECHA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ASIENTO_FECHA.DefaultCellStyle = DataGridViewCellStyle5
        Me.ASIENTO_FECHA.HeaderText = "FECHA"
        Me.ASIENTO_FECHA.Name = "ASIENTO_FECHA"
        Me.ASIENTO_FECHA.ReadOnly = True
        Me.ASIENTO_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ASIENTO_FECHA.Visible = False
        Me.ASIENTO_FECHA.Width = 140
        '
        'MONEDA
        '
        Me.MONEDA.DataPropertyName = "MONEDA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MONEDA.DefaultCellStyle = DataGridViewCellStyle6
        Me.MONEDA.HeaderText = "MON"
        Me.MONEDA.Name = "MONEDA"
        Me.MONEDA.ReadOnly = True
        Me.MONEDA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MONEDA.Width = 40
        '
        'TIPO_CAMBIO
        '
        Me.TIPO_CAMBIO.DataPropertyName = "TIPO_CAMBIO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TIPO_CAMBIO.DefaultCellStyle = DataGridViewCellStyle7
        Me.TIPO_CAMBIO.HeaderText = "TC"
        Me.TIPO_CAMBIO.Name = "TIPO_CAMBIO"
        Me.TIPO_CAMBIO.ReadOnly = True
        Me.TIPO_CAMBIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TIPO_CAMBIO.Visible = False
        Me.TIPO_CAMBIO.Width = 40
        '
        'GLOSA
        '
        Me.GLOSA.DataPropertyName = "GLOSA"
        Me.GLOSA.HeaderText = "GLOSA"
        Me.GLOSA.Name = "GLOSA"
        Me.GLOSA.ReadOnly = True
        Me.GLOSA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOSA.Visible = False
        '
        'MONTO_TOTAL
        '
        Me.MONTO_TOTAL.DataPropertyName = "MONTO_TOTAL"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.MONTO_TOTAL.DefaultCellStyle = DataGridViewCellStyle8
        Me.MONTO_TOTAL.HeaderText = "PRECIO_VENTA"
        Me.MONTO_TOTAL.Name = "MONTO_TOTAL"
        Me.MONTO_TOTAL.ReadOnly = True
        Me.MONTO_TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'VALOR_AFECTO
        '
        Me.VALOR_AFECTO.DataPropertyName = "VALOR_AFECTO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.VALOR_AFECTO.DefaultCellStyle = DataGridViewCellStyle9
        Me.VALOR_AFECTO.HeaderText = "AFECTO"
        Me.VALOR_AFECTO.Name = "VALOR_AFECTO"
        Me.VALOR_AFECTO.ReadOnly = True
        Me.VALOR_AFECTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VALOR_AFECTO.Visible = False
        Me.VALOR_AFECTO.Width = 80
        '
        'VALOR_EXENTO
        '
        Me.VALOR_EXENTO.DataPropertyName = "VALOR_EXENTO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.VALOR_EXENTO.DefaultCellStyle = DataGridViewCellStyle10
        Me.VALOR_EXENTO.HeaderText = "EXENTO"
        Me.VALOR_EXENTO.Name = "VALOR_EXENTO"
        Me.VALOR_EXENTO.ReadOnly = True
        Me.VALOR_EXENTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VALOR_EXENTO.Visible = False
        Me.VALOR_EXENTO.Width = 80
        '
        'IMPUESTO
        '
        Me.IMPUESTO.DataPropertyName = "IMPUESTO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.IMPUESTO.DefaultCellStyle = DataGridViewCellStyle11
        Me.IMPUESTO.HeaderText = "IMPUESTO"
        Me.IMPUESTO.Name = "IMPUESTO"
        Me.IMPUESTO.ReadOnly = True
        Me.IMPUESTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IMPUESTO.Visible = False
        Me.IMPUESTO.Width = 70
        '
        'USUARIO_REGISTRO
        '
        Me.USUARIO_REGISTRO.DataPropertyName = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.HeaderText = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.Name = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.ReadOnly = True
        Me.USUARIO_REGISTRO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.USUARIO_REGISTRO.Width = 120
        '
        'FECHA_REGISTRO
        '
        Me.FECHA_REGISTRO.DataPropertyName = "FECHA_REGISTRO"
        DataGridViewCellStyle12.Format = "G"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.FECHA_REGISTRO.DefaultCellStyle = DataGridViewCellStyle12
        Me.FECHA_REGISTRO.HeaderText = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.Name = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.ReadOnly = True
        Me.FECHA_REGISTRO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FECHA_REGISTRO.Width = 140
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle13
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ESTADO.Width = 80
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        Me.EMAIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EMAIL.Visible = False
        '
        'frmAuditoria
        '
        Me.ClientSize = New System.Drawing.Size(1254, 650)
        Me.Name = "frmAuditoria"
        Me.Panel.ResumeLayout(False)
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIENE_EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_CAMBIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONTO_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_AFECTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_EXENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
