<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteInventarioValorizado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteInventarioValorizado))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSubFamilia = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSubTipo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.MyProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.ckbProductoTodos = New System.Windows.Forms.CheckBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtProductoDesdeNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.rvInventarioValorizado = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.cmbSubFamilia)
        Me.panPrincipal.Controls.Add(Me.Label16)
        Me.panPrincipal.Controls.Add(Me.cmbFamilia)
        Me.panPrincipal.Controls.Add(Me.Label8)
        Me.panPrincipal.Controls.Add(Me.cmbSubTipo)
        Me.panPrincipal.Controls.Add(Me.Label13)
        Me.panPrincipal.Controls.Add(Me.cmbTipo)
        Me.panPrincipal.Controls.Add(Me.Label19)
        Me.panPrincipal.Controls.Add(Me.cmbTipoMoneda)
        Me.panPrincipal.Controls.Add(Me.MyProgressBar2)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.ckbProductoTodos)
        Me.panPrincipal.Controls.Add(Me.btnGenerar)
        Me.panPrincipal.Controls.Add(Me.txtProducto)
        Me.panPrincipal.Controls.Add(Me.txtProductoDesdeNombre)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.cmbAlmacen)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1130, 103)
        Me.panPrincipal.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(214, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 18)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "MODELO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cmbSubFamilia.Location = New System.Drawing.Point(214, 69)
        Me.cmbSubFamilia.Name = "cmbSubFamilia"
        Me.cmbSubFamilia.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubFamilia.TabIndex = 61
        Me.cmbSubFamilia.ValueMember = "CODIGO"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(12, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(200, 18)
        Me.Label16.TabIndex = 60
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
        Me.cmbFamilia.Location = New System.Drawing.Point(12, 69)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(200, 21)
        Me.cmbFamilia.TabIndex = 59
        Me.cmbFamilia.ValueMember = "CODIGO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(469, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(240, 18)
        Me.Label8.TabIndex = 58
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
        Me.cmbSubTipo.Location = New System.Drawing.Point(469, 26)
        Me.cmbSubTipo.Name = "cmbSubTipo"
        Me.cmbSubTipo.Size = New System.Drawing.Size(240, 21)
        Me.cmbSubTipo.TabIndex = 57
        Me.cmbSubTipo.TabStop = False
        Me.cmbSubTipo.ValueMember = "CODIGO"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(227, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(240, 18)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "LINEA DE PRODUCTO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cmbTipo.Location = New System.Drawing.Point(227, 26)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(240, 21)
        Me.cmbTipo.TabIndex = 55
        Me.cmbTipo.ValueMember = "CODIGO"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(795, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 18)
        Me.Label19.TabIndex = 54
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
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(795, 25)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(93, 21)
        Me.cmbTipoMoneda.TabIndex = 53
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'MyProgressBar2
        '
        Me.MyProgressBar2.Location = New System.Drawing.Point(905, 10)
        Me.MyProgressBar2.Name = "MyProgressBar2"
        Me.MyProgressBar2.Size = New System.Drawing.Size(167, 14)
        Me.MyProgressBar2.TabIndex = 19
        Me.MyProgressBar2.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(1078, 7)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(40, 40)
        Me.btnExportarExcel.TabIndex = 18
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        Me.btnExportarExcel.Visible = False
        '
        'ckbProductoTodos
        '
        Me.ckbProductoTodos.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbProductoTodos.Checked = True
        Me.ckbProductoTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbProductoTodos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbProductoTodos.ForeColor = System.Drawing.Color.White
        Me.ckbProductoTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbProductoTodos.Location = New System.Drawing.Point(416, 50)
        Me.ckbProductoTodos.Name = "ckbProductoTodos"
        Me.ckbProductoTodos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbProductoTodos.Size = New System.Drawing.Size(472, 18)
        Me.ckbProductoTodos.TabIndex = 5
        Me.ckbProductoTodos.TabStop = False
        Me.ckbProductoTodos.Text = "TODOS LOS PRODUCTOS"
        Me.ckbProductoTodos.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(1037, 67)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(81, 23)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(416, 69)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(70, 21)
        Me.txtProducto.TabIndex = 7
        '
        'txtProductoDesdeNombre
        '
        Me.txtProductoDesdeNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoDesdeNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDesdeNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDesdeNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDesdeNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDesdeNombre.Location = New System.Drawing.Point(487, 69)
        Me.txtProductoDesdeNombre.MaxLength = 50
        Me.txtProductoDesdeNombre.Name = "txtProductoDesdeNombre"
        Me.txtProductoDesdeNombre.ReadOnly = True
        Me.txtProductoDesdeNombre.Size = New System.Drawing.Size(401, 21)
        Me.txtProductoDesdeNombre.TabIndex = 10
        Me.txtProductoDesdeNombre.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 18)
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
        Me.cmbAlmacen.Location = New System.Drawing.Point(12, 26)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(213, 21)
        Me.cmbAlmacen.TabIndex = 2
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'rvInventarioValorizado
        '
        Me.rvInventarioValorizado.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvInventarioValorizado.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvInventarioValorizado.LocalReport.ReportEmbeddedResource = "BusinessManager.rptInventarioValorizado.rdlc"
        Me.rvInventarioValorizado.Location = New System.Drawing.Point(0, 103)
        Me.rvInventarioValorizado.Name = "rvInventarioValorizado"
        Me.rvInventarioValorizado.Size = New System.Drawing.Size(1130, 558)
        Me.rvInventarioValorizado.TabIndex = 4
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(12, 130)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(1106, 16)
        Me.MyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.MyProgressBar.TabIndex = 20
        Me.MyProgressBar.Visible = False
        '
        'frmReporteInventarioValorizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 661)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.rvInventarioValorizado)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteInventarioValorizado"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTARIO PERMANENTE VALORIZADO"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents MyProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents ckbProductoTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDesdeNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents rvInventarioValorizado As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbFamilia As System.Windows.Forms.ComboBox
End Class
