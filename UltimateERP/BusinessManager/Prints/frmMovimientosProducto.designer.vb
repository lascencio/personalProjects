<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientosProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientosProducto))
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.ckbAlmacen = New System.Windows.Forms.CheckBox()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtProductoDesdeNombre = New System.Windows.Forms.TextBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaHasta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaDesde = New System.Windows.Forms.TextBox()
        Me.rvMovimientosProducto = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pnPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnPrincipal
        '
        Me.pnPrincipal.Controls.Add(Me.MyProgressBar)
        Me.pnPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.pnPrincipal.Controls.Add(Me.ckbAlmacen)
        Me.pnPrincipal.Controls.Add(Me.cmbAlmacen)
        Me.pnPrincipal.Controls.Add(Me.Label1)
        Me.pnPrincipal.Controls.Add(Me.txtProducto)
        Me.pnPrincipal.Controls.Add(Me.txtProductoDesdeNombre)
        Me.pnPrincipal.Controls.Add(Me.btnRefrescar)
        Me.pnPrincipal.Controls.Add(Me.Label8)
        Me.pnPrincipal.Controls.Add(Me.txtFechaHasta)
        Me.pnPrincipal.Controls.Add(Me.Label14)
        Me.pnPrincipal.Controls.Add(Me.txtFechaDesde)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(1130, 58)
        Me.pnPrincipal.TabIndex = 0
        '
        'ckbAlmacen
        '
        Me.ckbAlmacen.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbAlmacen.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbAlmacen.ForeColor = System.Drawing.Color.White
        Me.ckbAlmacen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbAlmacen.Location = New System.Drawing.Point(754, 11)
        Me.ckbAlmacen.Name = "ckbAlmacen"
        Me.ckbAlmacen.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbAlmacen.Size = New System.Drawing.Size(150, 18)
        Me.ckbAlmacen.TabIndex = 9
        Me.ckbAlmacen.TabStop = False
        Me.ckbAlmacen.Text = "ALMACEN"
        Me.ckbAlmacen.UseVisualStyleBackColor = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.Enabled = False
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(754, 30)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(150, 21)
        Me.cmbAlmacen.TabIndex = 5
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(152, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "PRODUCTO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(152, 30)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(58, 21)
        Me.txtProducto.TabIndex = 0
        '
        'txtProductoDesdeNombre
        '
        Me.txtProductoDesdeNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoDesdeNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDesdeNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDesdeNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDesdeNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDesdeNombre.Location = New System.Drawing.Point(211, 30)
        Me.txtProductoDesdeNombre.MaxLength = 50
        Me.txtProductoDesdeNombre.Name = "txtProductoDesdeNombre"
        Me.txtProductoDesdeNombre.ReadOnly = True
        Me.txtProductoDesdeNombre.Size = New System.Drawing.Size(541, 21)
        Me.txtProductoDesdeNombre.TabIndex = 4
        Me.txtProductoDesdeNombre.TabStop = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(909, 28)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(79, 23)
        Me.btnRefrescar.TabIndex = 3
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(78, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 18)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "FEC. HASTA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaHasta.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaHasta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaHasta.Location = New System.Drawing.Point(78, 30)
        Me.txtFechaHasta.MaxLength = 10
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(72, 21)
        Me.txtFechaHasta.TabIndex = 2
        Me.txtFechaHasta.Tag = "F"
        Me.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(5, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 18)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "FEC. DESDE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaDesde.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaDesde.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaDesde.Location = New System.Drawing.Point(5, 30)
        Me.txtFechaDesde.MaxLength = 10
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(72, 21)
        Me.txtFechaDesde.TabIndex = 1
        Me.txtFechaDesde.Tag = "F"
        Me.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rvMovimientosProducto
        '
        Me.rvMovimientosProducto.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvMovimientosProducto.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvMovimientosProducto.LocalReport.ReportEmbeddedResource = "BusinessManager.rptMovimientosProducto.rdlc"
        Me.rvMovimientosProducto.Location = New System.Drawing.Point(0, 58)
        Me.rvMovimientosProducto.Name = "rvMovimientosProducto"
        Me.rvMovimientosProducto.Size = New System.Drawing.Size(1130, 649)
        Me.rvMovimientosProducto.TabIndex = 1
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(1076, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(42, 42)
        Me.btnExportarExcel.TabIndex = 711
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(909, 9)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(161, 14)
        Me.MyProgressBar.TabIndex = 712
        Me.MyProgressBar.Visible = False
        '
        'frmMovimientosProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 707)
        Me.Controls.Add(Me.rvMovimientosProducto)
        Me.Controls.Add(Me.pnPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmMovimientosProducto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOVIMIENTOS POR PRODUCTO"
        Me.pnPrincipal.ResumeLayout(False)
        Me.pnPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDesdeNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rvMovimientosProducto As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents ckbAlmacen As System.Windows.Forms.CheckBox
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
End Class
