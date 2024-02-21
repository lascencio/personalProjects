<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockVehicularImprimir
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockVehicularImprimir))
        Me.rvStockAlmacen = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.ckbProductoTodos = New System.Windows.Forms.CheckBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtProductoNombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbSubFamilia = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.txtProductoHasta = New System.Windows.Forms.TextBox()
        Me.txtProductoHastaNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'rvStockAlmacen
        '
        Me.rvStockAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvStockAlmacen.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvStockAlmacen.LocalReport.ReportEmbeddedResource = "BusinessManager.rptStockVehicular.rdlc"
        Me.rvStockAlmacen.Location = New System.Drawing.Point(0, 101)
        Me.rvStockAlmacen.Name = "rvStockAlmacen"
        Me.rvStockAlmacen.Size = New System.Drawing.Size(1080, 560)
        Me.rvStockAlmacen.TabIndex = 1
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.MyProgressBar)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.ckbProductoTodos)
        Me.panPrincipal.Controls.Add(Me.txtProducto)
        Me.panPrincipal.Controls.Add(Me.txtProductoNombre)
        Me.panPrincipal.Controls.Add(Me.Label13)
        Me.panPrincipal.Controls.Add(Me.cmbSubFamilia)
        Me.panPrincipal.Controls.Add(Me.Label16)
        Me.panPrincipal.Controls.Add(Me.cmbFamilia)
        Me.panPrincipal.Controls.Add(Me.btnGenerar)
        Me.panPrincipal.Controls.Add(Me.txtProductoHasta)
        Me.panPrincipal.Controls.Add(Me.txtProductoHastaNombre)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.cmbAlmacen)
        Me.panPrincipal.Controls.Add(Me.cmbMes)
        Me.panPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1080, 101)
        Me.panPrincipal.TabIndex = 0
        '
        'ckbProductoTodos
        '
        Me.ckbProductoTodos.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbProductoTodos.Checked = True
        Me.ckbProductoTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbProductoTodos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbProductoTodos.ForeColor = System.Drawing.Color.White
        Me.ckbProductoTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbProductoTodos.Location = New System.Drawing.Point(12, 9)
        Me.ckbProductoTodos.Name = "ckbProductoTodos"
        Me.ckbProductoTodos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbProductoTodos.Size = New System.Drawing.Size(697, 18)
        Me.ckbProductoTodos.TabIndex = 16
        Me.ckbProductoTodos.TabStop = False
        Me.ckbProductoTodos.Text = "TODOS LOS PRODUCTOS"
        Me.ckbProductoTodos.UseVisualStyleBackColor = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 28)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(70, 21)
        Me.txtProducto.TabIndex = 17
        '
        'txtProductoNombre
        '
        Me.txtProductoNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoNombre.Location = New System.Drawing.Point(83, 28)
        Me.txtProductoNombre.MaxLength = 50
        Me.txtProductoNombre.Name = "txtProductoNombre"
        Me.txtProductoNombre.ReadOnly = True
        Me.txtProductoNombre.Size = New System.Drawing.Size(626, 21)
        Me.txtProductoNombre.TabIndex = 18
        Me.txtProductoNombre.TabStop = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(468, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(241, 18)
        Me.Label13.TabIndex = 15
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
        Me.cmbSubFamilia.Location = New System.Drawing.Point(468, 71)
        Me.cmbSubFamilia.Name = "cmbSubFamilia"
        Me.cmbSubFamilia.Size = New System.Drawing.Size(241, 21)
        Me.cmbSubFamilia.TabIndex = 4
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
        Me.Label16.Location = New System.Drawing.Point(227, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(238, 18)
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
        Me.cmbFamilia.Location = New System.Drawing.Point(227, 71)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(238, 21)
        Me.cmbFamilia.TabIndex = 3
        Me.cmbFamilia.ValueMember = "CODIGO"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(715, 69)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(95, 23)
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
        Me.txtProductoHasta.Location = New System.Drawing.Point(866, 71)
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
        Me.txtProductoHastaNombre.Location = New System.Drawing.Point(880, 71)
        Me.txtProductoHastaNombre.MaxLength = 50
        Me.txtProductoHastaNombre.Name = "txtProductoHastaNombre"
        Me.txtProductoHastaNombre.ReadOnly = True
        Me.txtProductoHastaNombre.Size = New System.Drawing.Size(10, 21)
        Me.txtProductoHastaNombre.TabIndex = 9
        Me.txtProductoHastaNombre.TabStop = False
        Me.txtProductoHastaNombre.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 52)
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
        Me.cmbAlmacen.Location = New System.Drawing.Point(12, 71)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(213, 21)
        Me.cmbAlmacen.TabIndex = 2
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(845, 71)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(19, 21)
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
        Me.cmbEjercicio.Location = New System.Drawing.Point(821, 71)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(22, 21)
        Me.cmbEjercicio.TabIndex = 0
        Me.cmbEjercicio.TabStop = False
        Me.cmbEjercicio.Visible = False
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(715, 9)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(353, 14)
        Me.MyProgressBar.TabIndex = 713
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(1026, 53)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(42, 42)
        Me.btnExportarExcel.TabIndex = 712
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'frmStockVehicularImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 661)
        Me.Controls.Add(Me.rvStockAlmacen)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmStockVehicularImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK VEHICULAR"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvStockAlmacen As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents txtProductoHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoHastaNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents ckbProductoTodos As System.Windows.Forms.CheckBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoNombre As System.Windows.Forms.TextBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
