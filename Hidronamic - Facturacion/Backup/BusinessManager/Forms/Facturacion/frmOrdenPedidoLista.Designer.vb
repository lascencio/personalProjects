<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPedidoLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenPedidoLista))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar
        Me.btnExportarExcel = New System.Windows.Forms.Button
        Me.rbtConsultor = New System.Windows.Forms.RadioButton
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.cmbConsultor = New System.Windows.Forms.ComboBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.gvOrdenes = New System.Windows.Forms.DataGridView
        Me.ORDEN_PEDIDO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORDEN_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENDEDOR_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_BANCO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_IMPORTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGO_REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.gvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gvOrdenes
        '
        Me.gvOrdenes.AllowUserToAddRows = False
        Me.gvOrdenes.AllowUserToDeleteRows = False
        Me.gvOrdenes.AllowUserToOrderColumns = True
        Me.gvOrdenes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOrdenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOrdenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ORDEN_PEDIDO, Me.ORDEN_FECHA, Me.RAZON_SOCIAL, Me.VENDEDOR, Me.VENDEDOR_NOMBRE, Me.PAGO_TIPO, Me.PAGO_BANCO, Me.PAGO_MONEDA, Me.PAGO_FECHA, Me.PAGO_IMPORTE, Me.PAGO_REFERENCIA, Me.ESTADO})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvOrdenes.DefaultCellStyle = DataGridViewCellStyle8
        Me.gvOrdenes.Location = New System.Drawing.Point(12, 60)
        Me.gvOrdenes.MultiSelect = False
        Me.gvOrdenes.Name = "gvOrdenes"
        Me.gvOrdenes.ReadOnly = True
        Me.gvOrdenes.RowHeadersVisible = False
        Me.gvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOrdenes.Size = New System.Drawing.Size(1196, 588)
        Me.gvOrdenes.TabIndex = 0
        Me.gvOrdenes.TabStop = False
        '
        'ORDEN_PEDIDO
        '
        Me.ORDEN_PEDIDO.DataPropertyName = "ORDEN_PEDIDO"
        Me.ORDEN_PEDIDO.HeaderText = "N° ORDEN"
        Me.ORDEN_PEDIDO.Name = "ORDEN_PEDIDO"
        Me.ORDEN_PEDIDO.ReadOnly = True
        Me.ORDEN_PEDIDO.Width = 90
        '
        'ORDEN_FECHA
        '
        Me.ORDEN_FECHA.DataPropertyName = "ORDEN_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ORDEN_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.ORDEN_FECHA.HeaderText = "FECHA"
        Me.ORDEN_FECHA.Name = "ORDEN_FECHA"
        Me.ORDEN_FECHA.ReadOnly = True
        Me.ORDEN_FECHA.Width = 70
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 230
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
        Me.VENDEDOR_NOMBRE.Width = 230
        '
        'PAGO_TIPO
        '
        Me.PAGO_TIPO.DataPropertyName = "PAGO_TIPO"
        Me.PAGO_TIPO.HeaderText = "PAGO TIPO"
        Me.PAGO_TIPO.Name = "PAGO_TIPO"
        Me.PAGO_TIPO.ReadOnly = True
        Me.PAGO_TIPO.Width = 120
        '
        'PAGO_BANCO
        '
        Me.PAGO_BANCO.DataPropertyName = "PAGO_BANCO"
        Me.PAGO_BANCO.HeaderText = "BANCO"
        Me.PAGO_BANCO.Name = "PAGO_BANCO"
        Me.PAGO_BANCO.ReadOnly = True
        '
        'PAGO_MONEDA
        '
        Me.PAGO_MONEDA.DataPropertyName = "PAGO_MONEDA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PAGO_MONEDA.DefaultCellStyle = DataGridViewCellStyle4
        Me.PAGO_MONEDA.HeaderText = "MONEDA"
        Me.PAGO_MONEDA.Name = "PAGO_MONEDA"
        Me.PAGO_MONEDA.ReadOnly = True
        Me.PAGO_MONEDA.Width = 70
        '
        'PAGO_FECHA
        '
        Me.PAGO_FECHA.DataPropertyName = "PAGO_FECHA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PAGO_FECHA.DefaultCellStyle = DataGridViewCellStyle5
        Me.PAGO_FECHA.HeaderText = "FECHA"
        Me.PAGO_FECHA.Name = "PAGO_FECHA"
        Me.PAGO_FECHA.ReadOnly = True
        Me.PAGO_FECHA.Visible = False
        Me.PAGO_FECHA.Width = 75
        '
        'PAGO_IMPORTE
        '
        Me.PAGO_IMPORTE.DataPropertyName = "PAGO_IMPORTE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PAGO_IMPORTE.DefaultCellStyle = DataGridViewCellStyle6
        Me.PAGO_IMPORTE.HeaderText = "IMPORTE"
        Me.PAGO_IMPORTE.Name = "PAGO_IMPORTE"
        Me.PAGO_IMPORTE.ReadOnly = True
        Me.PAGO_IMPORTE.Width = 80
        '
        'PAGO_REFERENCIA
        '
        Me.PAGO_REFERENCIA.DataPropertyName = "PAGO_REFERENCIA"
        Me.PAGO_REFERENCIA.HeaderText = "REFERENCIA"
        Me.PAGO_REFERENCIA.Name = "PAGO_REFERENCIA"
        Me.PAGO_REFERENCIA.ReadOnly = True
        Me.PAGO_REFERENCIA.Width = 95
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle7
        Me.ESTADO.HeaderText = "EST"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 30
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
        'frmOrdenPedidoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1220, 660)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Controls.Add(Me.gvOrdenes)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.rbtConsultor)
        Me.Controls.Add(Me.rbtTodos)
        Me.Controls.Add(Me.cmbConsultor)
        Me.Controls.Add(Me.btnBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenPedidoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE ORDENES DEL MES"
        CType(Me.gvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents rbtConsultor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbConsultor As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gvOrdenes As System.Windows.Forms.DataGridView
    Friend WithEvents ORDEN_PEDIDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDEN_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENDEDOR_NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_BANCO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_IMPORTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGO_REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
