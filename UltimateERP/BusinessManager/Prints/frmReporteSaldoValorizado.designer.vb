<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteSaldoValorizado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteSaldoValorizado))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSubTipo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbSubFamilia = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.ckbProductoTodos = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.txtProductoHasta = New System.Windows.Forms.TextBox()
        Me.txtProductoHastaNombre = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtProductoDesdeNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.rvSaldoValorizado = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.ProgressBar1)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.Label8)
        Me.panPrincipal.Controls.Add(Me.cmbSubTipo)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.cmbTipo)
        Me.panPrincipal.Controls.Add(Me.Label13)
        Me.panPrincipal.Controls.Add(Me.cmbSubFamilia)
        Me.panPrincipal.Controls.Add(Me.Label19)
        Me.panPrincipal.Controls.Add(Me.cmbTipoMoneda)
        Me.panPrincipal.Controls.Add(Me.txtFecha)
        Me.panPrincipal.Controls.Add(Me.ckbProductoTodos)
        Me.panPrincipal.Controls.Add(Me.Label16)
        Me.panPrincipal.Controls.Add(Me.cmbFamilia)
        Me.panPrincipal.Controls.Add(Me.btnGenerar)
        Me.panPrincipal.Controls.Add(Me.txtProductoHasta)
        Me.panPrincipal.Controls.Add(Me.txtProductoHastaNombre)
        Me.panPrincipal.Controls.Add(Me.txtProducto)
        Me.panPrincipal.Controls.Add(Me.txtProductoDesdeNombre)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.cmbAlmacen)
        Me.panPrincipal.Controls.Add(Me.Label7)
        Me.panPrincipal.Controls.Add(Me.cmbMes)
        Me.panPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(829, 99)
        Me.panPrincipal.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(608, 77)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(161, 14)
        Me.ProgressBar1.TabIndex = 714
        Me.ProgressBar1.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(775, 50)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(42, 42)
        Me.btnExportarExcel.TabIndex = 713
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(483, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 18)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "SUBLINEA DE PRODUCTO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSubTipo
        '
        Me.cmbSubTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbSubTipo.DisplayMember = "DESCRIPCION"
        Me.cmbSubTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbSubTipo.FormattingEnabled = True
        Me.cmbSubTipo.Location = New System.Drawing.Point(483, 28)
        Me.cmbSubTipo.Name = "cmbSubTipo"
        Me.cmbSubTipo.Size = New System.Drawing.Size(220, 21)
        Me.cmbSubTipo.TabIndex = 37
        Me.cmbSubTipo.TabStop = False
        Me.cmbSubTipo.ValueMember = "CODIGO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(262, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "LINEA DE PRODUCTO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipo.DisplayMember = "DESCRIPCION"
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(262, 28)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(220, 21)
        Me.cmbTipo.TabIndex = 35
        Me.cmbTipo.ValueMember = "CODIGO"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(213, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(200, 18)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "MODELO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSubFamilia
        '
        Me.cmbSubFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSubFamilia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSubFamilia.BackColor = System.Drawing.Color.Azure
        Me.cmbSubFamilia.DisplayMember = "DESCRIPCION"
        Me.cmbSubFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubFamilia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbSubFamilia.FormattingEnabled = True
        Me.cmbSubFamilia.Location = New System.Drawing.Point(213, 71)
        Me.cmbSubFamilia.Name = "cmbSubFamilia"
        Me.cmbSubFamilia.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubFamilia.TabIndex = 22
        Me.cmbSubFamilia.ValueMember = "CODIGO"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(414, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 18)
        Me.Label19.TabIndex = 21
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
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(414, 71)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(95, 21)
        Me.cmbTipoMoneda.TabIndex = 20
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFecha.Location = New System.Drawing.Point(12, 28)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(68, 21)
        Me.txtFecha.TabIndex = 17
        Me.txtFecha.Tag = "F"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ckbProductoTodos
        '
        Me.ckbProductoTodos.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbProductoTodos.Checked = True
        Me.ckbProductoTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbProductoTodos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbProductoTodos.ForeColor = System.Drawing.Color.White
        Me.ckbProductoTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbProductoTodos.Location = New System.Drawing.Point(570, 57)
        Me.ckbProductoTodos.Name = "ckbProductoTodos"
        Me.ckbProductoTodos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbProductoTodos.Size = New System.Drawing.Size(34, 18)
        Me.ckbProductoTodos.TabIndex = 5
        Me.ckbProductoTodos.TabStop = False
        Me.ckbProductoTodos.Text = "TODOS LOS PRODUCTOS"
        Me.ckbProductoTodos.UseVisualStyleBackColor = False
        Me.ckbProductoTodos.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(12, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(200, 18)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "MARCA"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFamilia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFamilia.BackColor = System.Drawing.Color.Azure
        Me.cmbFamilia.DisplayMember = "DESCRIPCION"
        Me.cmbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFamilia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbFamilia.FormattingEnabled = True
        Me.cmbFamilia.Location = New System.Drawing.Point(12, 71)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(200, 21)
        Me.cmbFamilia.TabIndex = 3
        Me.cmbFamilia.ValueMember = "CODIGO"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(736, 9)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(81, 23)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'txtProductoHasta
        '
        Me.txtProductoHasta.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProductoHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoHasta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoHasta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProductoHasta.Location = New System.Drawing.Point(558, 52)
        Me.txtProductoHasta.MaxLength = 8
        Me.txtProductoHasta.Name = "txtProductoHasta"
        Me.txtProductoHasta.Size = New System.Drawing.Size(11, 21)
        Me.txtProductoHasta.TabIndex = 8
        Me.txtProductoHasta.Visible = False
        '
        'txtProductoHastaNombre
        '
        Me.txtProductoHastaNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoHastaNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoHastaNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoHastaNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoHastaNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoHastaNombre.Location = New System.Drawing.Point(546, 52)
        Me.txtProductoHastaNombre.MaxLength = 50
        Me.txtProductoHastaNombre.Name = "txtProductoHastaNombre"
        Me.txtProductoHastaNombre.ReadOnly = True
        Me.txtProductoHastaNombre.Size = New System.Drawing.Size(10, 21)
        Me.txtProductoHastaNombre.TabIndex = 9
        Me.txtProductoHastaNombre.TabStop = False
        Me.txtProductoHastaNombre.Visible = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(610, 52)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(14, 21)
        Me.txtProducto.TabIndex = 7
        Me.txtProducto.Visible = False
        '
        'txtProductoDesdeNombre
        '
        Me.txtProductoDesdeNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoDesdeNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDesdeNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDesdeNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDesdeNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDesdeNombre.Location = New System.Drawing.Point(630, 52)
        Me.txtProductoDesdeNombre.MaxLength = 50
        Me.txtProductoDesdeNombre.Name = "txtProductoDesdeNombre"
        Me.txtProductoDesdeNombre.ReadOnly = True
        Me.txtProductoDesdeNombre.Size = New System.Drawing.Size(14, 21)
        Me.txtProductoDesdeNombre.TabIndex = 10
        Me.txtProductoDesdeNombre.TabStop = False
        Me.txtProductoDesdeNombre.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(81, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 18)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "ALMACEN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(81, 28)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(180, 21)
        Me.cmbAlmacen.TabIndex = 2
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "FECHA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(527, 52)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(14, 21)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.TabStop = False
        Me.cmbMes.Visible = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(512, 52)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(14, 21)
        Me.cmbEjercicio.TabIndex = 0
        Me.cmbEjercicio.TabStop = False
        Me.cmbEjercicio.Visible = False
        '
        'rvSaldoValorizado
        '
        Me.rvSaldoValorizado.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvSaldoValorizado.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvSaldoValorizado.LocalReport.ReportEmbeddedResource = "BusinessManager.rptSaldoValorizado.rdlc"
        Me.rvSaldoValorizado.Location = New System.Drawing.Point(0, 99)
        Me.rvSaldoValorizado.Name = "rvSaldoValorizado"
        Me.rvSaldoValorizado.Size = New System.Drawing.Size(829, 562)
        Me.rvSaldoValorizado.TabIndex = 2
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(12, 126)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(783, 16)
        Me.MyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.MyProgressBar.TabIndex = 18
        Me.MyProgressBar.Visible = False
        '
        'frmReporteSaldoValorizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 661)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.rvSaldoValorizado)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteSaldoValorizado"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SALDO VALORIZADO"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents ckbProductoTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents txtProductoHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoHastaNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDesdeNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents rvSaldoValorizado As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
