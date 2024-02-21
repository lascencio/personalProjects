<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacionProductosLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacionProductosLista))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gvComprobantes = New System.Windows.Forms.DataGridView
        Me.btnExportarExcel = New System.Windows.Forms.Button
        Me.rbtConsultor = New System.Windows.Forms.RadioButton
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.cmbConsultor = New System.Windows.Forms.ComboBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENDEDOR_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IGV_ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IMPORTE_TOTAL_ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(1008, 1)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(200, 14)
        Me.MyProgressBar.TabIndex = 11
        Me.MyProgressBar.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(1033, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(954, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "EJERCICIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(1033, 36)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 6
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Items.AddRange(New Object() {"2015", "2016", "2017"})
        Me.cmbEjercicio.Location = New System.Drawing.Point(954, 36)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 5
        Me.cmbEjercicio.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(123, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(588, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "NOMBRE DEL CONSULTOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gvComprobantes
        '
        Me.gvComprobantes.AllowUserToAddRows = False
        Me.gvComprobantes.AllowUserToDeleteRows = False
        Me.gvComprobantes.AllowUserToOrderColumns = True
        Me.gvComprobantes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvComprobantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VENTA, Me.COMPROBANTE_FECHA, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.RAZON_SOCIAL, Me.VENDEDOR, Me.VENDEDOR_NOMBRE, Me.MONEDA, Me.BASE_IMPONIBLE_GRAVADA_ORIGEN, Me.IGV_ORIGEN, Me.IMPORTE_TOTAL_ORIGEN, Me.ESTADO})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvComprobantes.DefaultCellStyle = DataGridViewCellStyle9
        Me.gvComprobantes.Location = New System.Drawing.Point(12, 60)
        Me.gvComprobantes.MultiSelect = False
        Me.gvComprobantes.Name = "gvComprobantes"
        Me.gvComprobantes.ReadOnly = True
        Me.gvComprobantes.RowHeadersVisible = False
        Me.gvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvComprobantes.Size = New System.Drawing.Size(1196, 588)
        Me.gvComprobantes.TabIndex = 0
        Me.gvComprobantes.TabStop = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(1168, 15)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(40, 40)
        Me.btnExportarExcel.TabIndex = 7
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'rbtConsultor
        '
        Me.rbtConsultor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConsultor.Location = New System.Drawing.Point(12, 33)
        Me.rbtConsultor.Name = "rbtConsultor"
        Me.rbtConsultor.Size = New System.Drawing.Size(100, 18)
        Me.rbtConsultor.TabIndex = 2
        Me.rbtConsultor.Text = "CONSULTOR"
        Me.rbtConsultor.UseVisualStyleBackColor = True
        '
        'rbtTodos
        '
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTodos.Location = New System.Drawing.Point(12, 8)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(100, 18)
        Me.rbtTodos.TabIndex = 1
        Me.rbtTodos.TabStop = True
        Me.rbtTodos.Text = "TODOS"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'cmbConsultor
        '
        Me.cmbConsultor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbConsultor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbConsultor.BackColor = System.Drawing.Color.Azure
        Me.cmbConsultor.DisplayMember = "DESCRIPCION"
        Me.cmbConsultor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsultor.Enabled = False
        Me.cmbConsultor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbConsultor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbConsultor.FormattingEnabled = True
        Me.cmbConsultor.Location = New System.Drawing.Point(123, 36)
        Me.cmbConsultor.MaxDropDownItems = 16
        Me.cmbConsultor.Name = "cmbConsultor"
        Me.cmbConsultor.Size = New System.Drawing.Size(588, 21)
        Me.cmbConsultor.TabIndex = 3
        Me.cmbConsultor.ValueMember = "CODIGO"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnBuscar.Location = New System.Drawing.Point(717, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(131, 28)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.Visible = False
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPROBANTE_FECHA.HeaderText = "FECHA"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.Width = 70
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.Width = 80
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "RAZON SOCIAL"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 250
        '
        'VENDEDOR
        '
        Me.VENDEDOR.DataPropertyName = "VENDEDOR"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.VENDEDOR.DefaultCellStyle = DataGridViewCellStyle3
        Me.VENDEDOR.HeaderText = "EXIGO"
        Me.VENDEDOR.Name = "VENDEDOR"
        Me.VENDEDOR.ReadOnly = True
        Me.VENDEDOR.Width = 55
        '
        'VENDEDOR_NOMBRE
        '
        Me.VENDEDOR_NOMBRE.DataPropertyName = "VENDEDOR_NOMBRE"
        Me.VENDEDOR_NOMBRE.HeaderText = "CONSULTOR"
        Me.VENDEDOR_NOMBRE.Name = "VENDEDOR_NOMBRE"
        Me.VENDEDOR_NOMBRE.ReadOnly = True
        Me.VENDEDOR_NOMBRE.Width = 250
        '
        'MONEDA
        '
        Me.MONEDA.DataPropertyName = "MONEDA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MONEDA.DefaultCellStyle = DataGridViewCellStyle4
        Me.MONEDA.HeaderText = "MONEDA"
        Me.MONEDA.Name = "MONEDA"
        Me.MONEDA.ReadOnly = True
        Me.MONEDA.Width = 70
        '
        'BASE_IMPONIBLE_GRAVADA_ORIGEN
        '
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.DataPropertyName = "BASE_IMPONIBLE_GRAVADA_ORIGEN"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.DefaultCellStyle = DataGridViewCellStyle5
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.HeaderText = "V. VENTA"
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.Name = "BASE_IMPONIBLE_GRAVADA_ORIGEN"
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.ReadOnly = True
        Me.BASE_IMPONIBLE_GRAVADA_ORIGEN.Width = 90
        '
        'IGV_ORIGEN
        '
        Me.IGV_ORIGEN.DataPropertyName = "IGV_ORIGEN"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.IGV_ORIGEN.DefaultCellStyle = DataGridViewCellStyle6
        Me.IGV_ORIGEN.HeaderText = "IGV"
        Me.IGV_ORIGEN.Name = "IGV_ORIGEN"
        Me.IGV_ORIGEN.ReadOnly = True
        Me.IGV_ORIGEN.Width = 80
        '
        'IMPORTE_TOTAL_ORIGEN
        '
        Me.IMPORTE_TOTAL_ORIGEN.DataPropertyName = "IMPORTE_TOTAL_ORIGEN"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.IMPORTE_TOTAL_ORIGEN.DefaultCellStyle = DataGridViewCellStyle7
        Me.IMPORTE_TOTAL_ORIGEN.HeaderText = "P. VENTA"
        Me.IMPORTE_TOTAL_ORIGEN.Name = "IMPORTE_TOTAL_ORIGEN"
        Me.IMPORTE_TOTAL_ORIGEN.ReadOnly = True
        Me.IMPORTE_TOTAL_ORIGEN.Width = 90
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle8
        Me.ESTADO.HeaderText = "EST"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 30
        '
        'frmFacturacionProductosLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1220, 660)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gvComprobantes)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.rbtConsultor)
        Me.Controls.Add(Me.rbtTodos)
        Me.Controls.Add(Me.cmbConsultor)
        Me.Controls.Add(Me.btnBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacionProductosLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE FACTURAS DE VENTA"
        CType(Me.gvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvComprobantes As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents rbtConsultor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbConsultor As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENDEDOR_NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BASE_IMPONIBLE_GRAVADA_ORIGEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IGV_ORIGEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE_TOTAL_ORIGEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
