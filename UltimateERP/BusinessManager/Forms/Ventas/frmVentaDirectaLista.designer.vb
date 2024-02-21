<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaDirectaLista
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaDirectaLista))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.gvVentas = New System.Windows.Forms.DataGridView()
        Me.DsVentas = New BusinessManager.dsVentas()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.GUIAREMITENTELISTABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsGuiasRemitente = New BusinessManager.dsGuiasRemitente()
        Me.VENTASGUIASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NROGUIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZONSOCIALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GUIAREMITENTELISTABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsGuiasRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASGUIASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(584, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(505, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "EJERCICIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(584, 38)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 18
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(505, 38)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 17
        Me.cmbEjercicio.TabStop = False
        '
        'gvVentas
        '
        Me.gvVentas.AllowUserToAddRows = False
        Me.gvVentas.AllowUserToDeleteRows = False
        Me.gvVentas.AllowUserToOrderColumns = True
        Me.gvVentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gvVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VENTADataGridViewTextBoxColumn, Me.FECHADataGridViewTextBoxColumn, Me.COMPROBANTEDataGridViewTextBoxColumn, Me.MONEDADataGridViewTextBoxColumn, Me.IMPORTEDataGridViewTextBoxColumn, Me.CUENTACOMERCIALDataGridViewTextBoxColumn, Me.TDDataGridViewTextBoxColumn, Me.NDDataGridViewTextBoxColumn, Me.RAZONSOCIALDataGridViewTextBoxColumn, Me.NROGUIADataGridViewTextBoxColumn})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvVentas.DefaultCellStyle = DataGridViewCellStyle6
        Me.gvVentas.Location = New System.Drawing.Point(12, 63)
        Me.gvVentas.MultiSelect = False
        Me.gvVentas.Name = "gvVentas"
        Me.gvVentas.ReadOnly = True
        Me.gvVentas.RowHeadersVisible = False
        Me.gvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentas.Size = New System.Drawing.Size(747, 585)
        Me.gvVentas.TabIndex = 12
        Me.gvVentas.TabStop = False
        '
        'DsVentas
        '
        Me.DsVentas.DataSetName = "dsVentas"
        Me.DsVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(559, 3)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(200, 14)
        Me.MyProgressBar.TabIndex = 23
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(719, 17)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(40, 40)
        Me.btnExportarExcel.TabIndex = 19
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'GUIAREMITENTELISTABindingSource
        '
        Me.GUIAREMITENTELISTABindingSource.DataMember = "GUIA_REMITENTE_LISTA"
        Me.GUIAREMITENTELISTABindingSource.DataSource = Me.DsGuiasRemitente
        '
        'DsGuiasRemitente
        '
        Me.DsGuiasRemitente.DataSetName = "dsGuiasRemitente"
        Me.DsGuiasRemitente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VENTASGUIASBindingSource
        '
        Me.VENTASGUIASBindingSource.DataMember = "VENTAS_GUIAS"
        Me.VENTASGUIASBindingSource.DataSource = Me.DsVentas
        '
        'NROGUIADataGridViewTextBoxColumn
        '
        Me.NROGUIADataGridViewTextBoxColumn.DataPropertyName = "NRO_GUIA"
        Me.NROGUIADataGridViewTextBoxColumn.HeaderText = "NRO_GUIA"
        Me.NROGUIADataGridViewTextBoxColumn.Name = "NROGUIADataGridViewTextBoxColumn"
        Me.NROGUIADataGridViewTextBoxColumn.ReadOnly = True
        Me.NROGUIADataGridViewTextBoxColumn.Visible = False
        '
        'RAZONSOCIALDataGridViewTextBoxColumn
        '
        Me.RAZONSOCIALDataGridViewTextBoxColumn.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZONSOCIALDataGridViewTextBoxColumn.HeaderText = "RAZON_SOCIAL"
        Me.RAZONSOCIALDataGridViewTextBoxColumn.Name = "RAZONSOCIALDataGridViewTextBoxColumn"
        Me.RAZONSOCIALDataGridViewTextBoxColumn.ReadOnly = True
        Me.RAZONSOCIALDataGridViewTextBoxColumn.Width = 350
        '
        'NDDataGridViewTextBoxColumn
        '
        Me.NDDataGridViewTextBoxColumn.DataPropertyName = "ND"
        Me.NDDataGridViewTextBoxColumn.HeaderText = "ND"
        Me.NDDataGridViewTextBoxColumn.Name = "NDDataGridViewTextBoxColumn"
        Me.NDDataGridViewTextBoxColumn.ReadOnly = True
        Me.NDDataGridViewTextBoxColumn.Visible = False
        '
        'TDDataGridViewTextBoxColumn
        '
        Me.TDDataGridViewTextBoxColumn.DataPropertyName = "TD"
        Me.TDDataGridViewTextBoxColumn.HeaderText = "TD"
        Me.TDDataGridViewTextBoxColumn.Name = "TDDataGridViewTextBoxColumn"
        Me.TDDataGridViewTextBoxColumn.ReadOnly = True
        Me.TDDataGridViewTextBoxColumn.Visible = False
        '
        'CUENTACOMERCIALDataGridViewTextBoxColumn
        '
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn.HeaderText = "CUENTA_COMERCIAL"
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn.Name = "CUENTACOMERCIALDataGridViewTextBoxColumn"
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CUENTACOMERCIALDataGridViewTextBoxColumn.Visible = False
        '
        'IMPORTEDataGridViewTextBoxColumn
        '
        Me.IMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.IMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.IMPORTEDataGridViewTextBoxColumn.HeaderText = "IMPORTE"
        Me.IMPORTEDataGridViewTextBoxColumn.Name = "IMPORTEDataGridViewTextBoxColumn"
        Me.IMPORTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.IMPORTEDataGridViewTextBoxColumn.Width = 85
        '
        'MONEDADataGridViewTextBoxColumn
        '
        Me.MONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MONEDADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.MONEDADataGridViewTextBoxColumn.HeaderText = "MONEDA"
        Me.MONEDADataGridViewTextBoxColumn.Name = "MONEDADataGridViewTextBoxColumn"
        Me.MONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.MONEDADataGridViewTextBoxColumn.Width = 75
        '
        'COMPROBANTEDataGridViewTextBoxColumn
        '
        Me.COMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "COMPROBANTE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COMPROBANTEDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.COMPROBANTEDataGridViewTextBoxColumn.HeaderText = "COMPROBANTE"
        Me.COMPROBANTEDataGridViewTextBoxColumn.Name = "COMPROBANTEDataGridViewTextBoxColumn"
        Me.COMPROBANTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.COMPROBANTEDataGridViewTextBoxColumn.Width = 120
        '
        'FECHADataGridViewTextBoxColumn
        '
        Me.FECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        Me.FECHADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHADataGridViewTextBoxColumn.HeaderText = "FECHA"
        Me.FECHADataGridViewTextBoxColumn.Name = "FECHADataGridViewTextBoxColumn"
        Me.FECHADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHADataGridViewTextBoxColumn.Width = 80
        '
        'VENTADataGridViewTextBoxColumn
        '
        Me.VENTADataGridViewTextBoxColumn.DataPropertyName = "VENTA"
        Me.VENTADataGridViewTextBoxColumn.HeaderText = "VENTA"
        Me.VENTADataGridViewTextBoxColumn.Name = "VENTADataGridViewTextBoxColumn"
        Me.VENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.VENTADataGridViewTextBoxColumn.Visible = False
        '
        'frmVentaDirectaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 660)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Controls.Add(Me.gvVentas)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentaDirectaLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE COMPROBANTES DE VENTA"
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GUIAREMITENTELISTABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsGuiasRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASGUIASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents gvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents GUIAREMITENTELISTABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsGuiasRemitente As BusinessManager.dsGuiasRemitente
    Friend WithEvents GUIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA_TRASLADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDEN_PEDIDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsVentas As BusinessManager.dsVentas
    Friend WithEvents VENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTACOMERCIALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZONSOCIALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROGUIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTASGUIASBindingSource As System.Windows.Forms.BindingSource
End Class
