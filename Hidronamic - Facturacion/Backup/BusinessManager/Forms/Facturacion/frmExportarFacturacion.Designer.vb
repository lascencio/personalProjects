<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportarFacturacion
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportarFacturacion))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvAsientos = New System.Windows.Forms.DataGridView
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbTipoRegistros = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.txtAsientoMes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAsientoNumero = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ckbSeleccionar = New System.Windows.Forms.CheckBox
        Me.cempresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cejercicio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.csubdia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ccompro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ccorrelativo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cfeccom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcodmon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.csitua = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctipcam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtipdoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dnumdoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dfecdoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dxglosa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cdate2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cfeccom2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cfeccam2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cflag = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cindica_exportacion = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvAsientos
        '
        Me.gvAsientos.AllowUserToAddRows = False
        Me.gvAsientos.AllowUserToDeleteRows = False
        Me.gvAsientos.AllowUserToResizeRows = False
        Me.gvAsientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.gvAsientos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gvAsientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAsientos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvAsientos.ColumnHeadersHeight = 30
        Me.gvAsientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cempresa, Me.cejercicio, Me.cmes, Me.csubdia, Me.ccompro, Me.ccorrelativo, Me.cfeccom, Me.dcodmon, Me.csitua, Me.ctipcam, Me.dtipdoc, Me.dnumdoc, Me.dfecdoc, Me.dxglosa, Me.ctotal, Me.cdate2, Me.cfeccom2, Me.cfeccam2, Me.ctipo, Me.cflag, Me.cindica_exportacion, Me.EMPRESA, Me.VENTA})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvAsientos.DefaultCellStyle = DataGridViewCellStyle11
        Me.gvAsientos.EnableHeadersVisualStyles = False
        Me.gvAsientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gvAsientos.Location = New System.Drawing.Point(12, 98)
        Me.gvAsientos.MultiSelect = False
        Me.gvAsientos.Name = "gvAsientos"
        Me.gvAsientos.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.gvAsientos.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.gvAsientos.RowHeadersWidth = 31
        Me.gvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gvAsientos.Size = New System.Drawing.Size(970, 529)
        Me.gvAsientos.TabIndex = 52
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(185, 77)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(300, 15)
        Me.MyProgressBar.TabIndex = 60
        Me.MyProgressBar.Visible = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(896, 9)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(40, 40)
        Me.btnGrabar.TabIndex = 53
        Me.btnGrabar.TabStop = False
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(942, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 57
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(12, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(156, 15)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "TIPO DE REGISTROS"
        '
        'cmbTipoRegistros
        '
        Me.cmbTipoRegistros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoRegistros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoRegistros.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoRegistros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRegistros.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoRegistros.FormattingEnabled = True
        Me.cmbTipoRegistros.Items.AddRange(New Object() {"POR EXPORTAR", "EXPORTADOS"})
        Me.cmbTipoRegistros.Location = New System.Drawing.Point(12, 71)
        Me.cmbTipoRegistros.Name = "cmbTipoRegistros"
        Me.cmbTipoRegistros.Size = New System.Drawing.Size(155, 21)
        Me.cmbTipoRegistros.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "EJERCICIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.Enabled = False
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(15, 25)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 77
        Me.cmbEjercicio.TabStop = False
        '
        'txtAsientoMes
        '
        Me.txtAsientoMes.BackColor = System.Drawing.Color.LightYellow
        Me.txtAsientoMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsientoMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAsientoMes.Location = New System.Drawing.Point(94, 25)
        Me.txtAsientoMes.MaxLength = 2
        Me.txtAsientoMes.Name = "txtAsientoMes"
        Me.txtAsientoMes.ReadOnly = True
        Me.txtAsientoMes.Size = New System.Drawing.Size(27, 20)
        Me.txtAsientoMes.TabIndex = 79
        Me.txtAsientoMes.TabStop = False
        Me.txtAsientoMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(126, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "ULT. COMP."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAsientoNumero
        '
        Me.txtAsientoNumero.BackColor = System.Drawing.Color.LightYellow
        Me.txtAsientoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsientoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAsientoNumero.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAsientoNumero.Location = New System.Drawing.Point(125, 25)
        Me.txtAsientoNumero.MaxLength = 10
        Me.txtAsientoNumero.Name = "txtAsientoNumero"
        Me.txtAsientoNumero.ReadOnly = True
        Me.txtAsientoNumero.Size = New System.Drawing.Size(76, 20)
        Me.txtAsientoNumero.TabIndex = 80
        Me.txtAsientoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(95, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "MES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckbSeleccionar
        '
        Me.ckbSeleccionar.AutoSize = True
        Me.ckbSeleccionar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbSeleccionar.ForeColor = System.Drawing.Color.MediumBlue
        Me.ckbSeleccionar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbSeleccionar.Location = New System.Drawing.Point(752, 73)
        Me.ckbSeleccionar.Name = "ckbSeleccionar"
        Me.ckbSeleccionar.Size = New System.Drawing.Size(230, 17)
        Me.ckbSeleccionar.TabIndex = 83
        Me.ckbSeleccionar.TabStop = False
        Me.ckbSeleccionar.Text = "SELECCIONAR/DESELECCIONAR TODO"
        Me.ckbSeleccionar.UseVisualStyleBackColor = True
        '
        'cempresa
        '
        Me.cempresa.DataPropertyName = "cempresa"
        Me.cempresa.HeaderText = "EMPRESA"
        Me.cempresa.Name = "cempresa"
        Me.cempresa.ReadOnly = True
        Me.cempresa.Visible = False
        '
        'cejercicio
        '
        Me.cejercicio.DataPropertyName = "cejercicio"
        Me.cejercicio.HeaderText = "EJERCICIO"
        Me.cejercicio.Name = "cejercicio"
        Me.cejercicio.ReadOnly = True
        Me.cejercicio.Visible = False
        '
        'cmes
        '
        Me.cmes.DataPropertyName = "cmes"
        Me.cmes.HeaderText = "MES"
        Me.cmes.Name = "cmes"
        Me.cmes.ReadOnly = True
        Me.cmes.Visible = False
        '
        'csubdia
        '
        Me.csubdia.DataPropertyName = "csubdia"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.csubdia.DefaultCellStyle = DataGridViewCellStyle2
        Me.csubdia.HeaderText = "SUB"
        Me.csubdia.Name = "csubdia"
        Me.csubdia.ReadOnly = True
        Me.csubdia.Width = 30
        '
        'ccompro
        '
        Me.ccompro.DataPropertyName = "ccompro"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ccompro.DefaultCellStyle = DataGridViewCellStyle3
        Me.ccompro.HeaderText = "ccompro"
        Me.ccompro.Name = "ccompro"
        Me.ccompro.ReadOnly = True
        Me.ccompro.Visible = False
        Me.ccompro.Width = 50
        '
        'ccorrelativo
        '
        Me.ccorrelativo.DataPropertyName = "ccorrelativo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ccorrelativo.DefaultCellStyle = DataGridViewCellStyle4
        Me.ccorrelativo.HeaderText = "COMP"
        Me.ccorrelativo.Name = "ccorrelativo"
        Me.ccorrelativo.ReadOnly = True
        Me.ccorrelativo.Width = 50
        '
        'cfeccom
        '
        Me.cfeccom.DataPropertyName = "cfeccom"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cfeccom.DefaultCellStyle = DataGridViewCellStyle5
        Me.cfeccom.HeaderText = "FECHA"
        Me.cfeccom.Name = "cfeccom"
        Me.cfeccom.ReadOnly = True
        Me.cfeccom.Width = 60
        '
        'dcodmon
        '
        Me.dcodmon.DataPropertyName = "ccodmon"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dcodmon.DefaultCellStyle = DataGridViewCellStyle6
        Me.dcodmon.HeaderText = "MON"
        Me.dcodmon.Name = "dcodmon"
        Me.dcodmon.ReadOnly = True
        Me.dcodmon.Width = 40
        '
        'csitua
        '
        Me.csitua.DataPropertyName = "csitua"
        Me.csitua.HeaderText = "csitua"
        Me.csitua.Name = "csitua"
        Me.csitua.ReadOnly = True
        Me.csitua.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.csitua.Visible = False
        Me.csitua.Width = 60
        '
        'ctipcam
        '
        Me.ctipcam.DataPropertyName = "ctipcam"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ctipcam.DefaultCellStyle = DataGridViewCellStyle7
        Me.ctipcam.HeaderText = "TC"
        Me.ctipcam.Name = "ctipcam"
        Me.ctipcam.ReadOnly = True
        Me.ctipcam.Width = 40
        '
        'dtipdoc
        '
        Me.dtipdoc.DataPropertyName = "dtipdoc"
        Me.dtipdoc.HeaderText = "DOC"
        Me.dtipdoc.Name = "dtipdoc"
        Me.dtipdoc.ReadOnly = True
        Me.dtipdoc.Width = 40
        '
        'dnumdoc
        '
        Me.dnumdoc.DataPropertyName = "dnumdoc"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dnumdoc.DefaultCellStyle = DataGridViewCellStyle8
        Me.dnumdoc.HeaderText = "NUMERO"
        Me.dnumdoc.Name = "dnumdoc"
        Me.dnumdoc.ReadOnly = True
        '
        'dfecdoc
        '
        Me.dfecdoc.DataPropertyName = "dfecdoc"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.dfecdoc.DefaultCellStyle = DataGridViewCellStyle9
        Me.dfecdoc.HeaderText = "FECHA"
        Me.dfecdoc.Name = "dfecdoc"
        Me.dfecdoc.ReadOnly = True
        Me.dfecdoc.Width = 60
        '
        'dxglosa
        '
        Me.dxglosa.DataPropertyName = "cglosa"
        Me.dxglosa.FillWeight = 79.47788!
        Me.dxglosa.HeaderText = "GLOSA"
        Me.dxglosa.Name = "dxglosa"
        Me.dxglosa.ReadOnly = True
        Me.dxglosa.Width = 395
        '
        'ctotal
        '
        Me.ctotal.DataPropertyName = "ctotal"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ctotal.DefaultCellStyle = DataGridViewCellStyle10
        Me.ctotal.HeaderText = "IMPORTE"
        Me.ctotal.Name = "ctotal"
        Me.ctotal.ReadOnly = True
        Me.ctotal.Width = 80
        '
        'cdate2
        '
        Me.cdate2.DataPropertyName = "cdate2"
        Me.cdate2.HeaderText = "cdate2"
        Me.cdate2.Name = "cdate2"
        Me.cdate2.ReadOnly = True
        Me.cdate2.Visible = False
        '
        'cfeccom2
        '
        Me.cfeccom2.DataPropertyName = "cfeccom2"
        Me.cfeccom2.HeaderText = "cfeccom2"
        Me.cfeccom2.Name = "cfeccom2"
        Me.cfeccom2.ReadOnly = True
        Me.cfeccom2.Visible = False
        '
        'cfeccam2
        '
        Me.cfeccam2.DataPropertyName = "cfeccam2"
        Me.cfeccam2.HeaderText = "cfeccam2"
        Me.cfeccam2.Name = "cfeccam2"
        Me.cfeccam2.ReadOnly = True
        Me.cfeccam2.Visible = False
        '
        'ctipo
        '
        Me.ctipo.DataPropertyName = "ctipo"
        Me.ctipo.HeaderText = "ctipo"
        Me.ctipo.Name = "ctipo"
        Me.ctipo.ReadOnly = True
        Me.ctipo.Visible = False
        '
        'cflag
        '
        Me.cflag.DataPropertyName = "cflag"
        Me.cflag.HeaderText = "cflag"
        Me.cflag.Name = "cflag"
        Me.cflag.ReadOnly = True
        Me.cflag.Visible = False
        '
        'cindica_exportacion
        '
        Me.cindica_exportacion.DataPropertyName = "cindica_exportacion"
        Me.cindica_exportacion.HeaderText = "SEL"
        Me.cindica_exportacion.Name = "cindica_exportacion"
        Me.cindica_exportacion.ReadOnly = True
        Me.cindica_exportacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cindica_exportacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cindica_exportacion.Width = 30
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.Visible = False
        '
        'frmExportarFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 639)
        Me.Controls.Add(Me.ckbSeleccionar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAsientoNumero)
        Me.Controls.Add(Me.txtAsientoMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmbTipoRegistros)
        Me.Controls.Add(Me.gvAsientos)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExportarFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EXPORTAR FACTURACION AL CONCAR"
        CType(Me.gvAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvAsientos As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoRegistros As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents txtAsientoMes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAsientoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckbSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents cempresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cejercicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents csubdia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ccompro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ccorrelativo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfeccom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcodmon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents csitua As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctipcam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtipdoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dnumdoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dfecdoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dxglosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdate2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfeccom2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfeccam2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cflag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cindica_exportacion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
