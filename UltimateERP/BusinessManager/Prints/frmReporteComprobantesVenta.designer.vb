<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteComprobantesVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteComprobantesVenta))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoVenta = New System.Windows.Forms.ComboBox()
        Me.ckbImportesSinIGV = New System.Windows.Forms.CheckBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.ckbClienteTodos = New System.Windows.Forms.CheckBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaHasta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaDesde = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.rvComprobantes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.MyProgressBar)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.Label5)
        Me.panPrincipal.Controls.Add(Me.cmbTipoVenta)
        Me.panPrincipal.Controls.Add(Me.ckbImportesSinIGV)
        Me.panPrincipal.Controls.Add(Me.txtCuentaComercial)
        Me.panPrincipal.Controls.Add(Me.ckbClienteTodos)
        Me.panPrincipal.Controls.Add(Me.cmbDocumentoTipo)
        Me.panPrincipal.Controls.Add(Me.txtRazonSocial)
        Me.panPrincipal.Controls.Add(Me.txtDocumentoNumero)
        Me.panPrincipal.Controls.Add(Me.Label8)
        Me.panPrincipal.Controls.Add(Me.txtFechaHasta)
        Me.panPrincipal.Controls.Add(Me.Label14)
        Me.panPrincipal.Controls.Add(Me.txtFechaDesde)
        Me.panPrincipal.Controls.Add(Me.Label24)
        Me.panPrincipal.Controls.Add(Me.cmbVendedor)
        Me.panPrincipal.Controls.Add(Me.Label4)
        Me.panPrincipal.Controls.Add(Me.cmbComprobanteTipo)
        Me.panPrincipal.Controls.Add(Me.btnRefrescar)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1130, 102)
        Me.panPrincipal.TabIndex = 0
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(951, 45)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(167, 14)
        Me.MyProgressBar.TabIndex = 63
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(897, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(48, 50)
        Me.btnExportarExcel.TabIndex = 62
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        Me.btnExportarExcel.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(608, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(263, 18)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "TIPO DE OPERACION"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoVenta
        '
        Me.cmbTipoVenta.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoVenta.DisplayMember = "DESCRIPCION"
        Me.cmbTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoVenta.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoVenta.FormattingEnabled = True
        Me.cmbTipoVenta.Location = New System.Drawing.Point(608, 31)
        Me.cmbTipoVenta.Name = "cmbTipoVenta"
        Me.cmbTipoVenta.Size = New System.Drawing.Size(263, 21)
        Me.cmbTipoVenta.TabIndex = 60
        Me.cmbTipoVenta.ValueMember = "CODIGO"
        '
        'ckbImportesSinIGV
        '
        Me.ckbImportesSinIGV.BackColor = System.Drawing.Color.Transparent
        Me.ckbImportesSinIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbImportesSinIGV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbImportesSinIGV.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckbImportesSinIGV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbImportesSinIGV.Location = New System.Drawing.Point(877, 80)
        Me.ckbImportesSinIGV.Name = "ckbImportesSinIGV"
        Me.ckbImportesSinIGV.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbImportesSinIGV.Size = New System.Drawing.Size(241, 18)
        Me.ckbImportesSinIGV.TabIndex = 59
        Me.ckbImportesSinIGV.TabStop = False
        Me.ckbImportesSinIGV.Text = "IMPORTES MONETARIOS SIN IGV"
        Me.ckbImportesSinIGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbImportesSinIGV.UseVisualStyleBackColor = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(996, 9)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 58
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'ckbClienteTodos
        '
        Me.ckbClienteTodos.BackColor = System.Drawing.Color.SteelBlue
        Me.ckbClienteTodos.Checked = True
        Me.ckbClienteTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbClienteTodos.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbClienteTodos.ForeColor = System.Drawing.Color.White
        Me.ckbClienteTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbClienteTodos.Location = New System.Drawing.Point(12, 56)
        Me.ckbClienteTodos.Name = "ckbClienteTodos"
        Me.ckbClienteTodos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ckbClienteTodos.Size = New System.Drawing.Size(859, 18)
        Me.ckbClienteTodos.TabIndex = 57
        Me.ckbClienteTodos.TabStop = False
        Me.ckbClienteTodos.Text = "TODOS LOS CLIENTES"
        Me.ckbClienteTodos.UseVisualStyleBackColor = False
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.Enabled = False
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(12, 75)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 53
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(150, 75)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(721, 21)
        Me.txtRazonSocial.TabIndex = 54
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(69, 75)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 52
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(102, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 18)
        Me.Label8.TabIndex = 51
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
        Me.txtFechaHasta.Location = New System.Drawing.Point(102, 31)
        Me.txtFechaHasta.MaxLength = 10
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(88, 21)
        Me.txtFechaHasta.TabIndex = 49
        Me.txtFechaHasta.Tag = "F"
        Me.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(12, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 18)
        Me.Label14.TabIndex = 50
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
        Me.txtFechaDesde.Location = New System.Drawing.Point(12, 31)
        Me.txtFechaDesde.MaxLength = 10
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(88, 21)
        Me.txtFechaDesde.TabIndex = 48
        Me.txtFechaDesde.Tag = "F"
        Me.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(196, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(266, 18)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "VENDEDOR "
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BackColor = System.Drawing.Color.Azure
        Me.cmbVendedor.DisplayMember = "DESCRIPCION"
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(196, 31)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(266, 21)
        Me.cmbVendedor.TabIndex = 3
        Me.cmbVendedor.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(468, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 18)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TIPO COMPROBANTE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Items.AddRange(New Object() {"TODOS", "BOLETA", "FACTURA", "NOTA DE CREDITO", "NOTA DE DEBITO"})
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(468, 31)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(134, 21)
        Me.cmbComprobanteTipo.TabIndex = 4
        Me.cmbComprobanteTipo.TabStop = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(1022, 9)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(96, 23)
        Me.btnRefrescar.TabIndex = 5
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'rvComprobantes
        '
        Me.rvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvComprobantes.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvComprobantes.LocalReport.ReportEmbeddedResource = "BusinessManager.rptComprobantesVenta.rdlc"
        Me.rvComprobantes.Location = New System.Drawing.Point(0, 102)
        Me.rvComprobantes.Name = "rvComprobantes"
        Me.rvComprobantes.Size = New System.Drawing.Size(1130, 555)
        Me.rvComprobantes.TabIndex = 1
        '
        'frmReporteComprobantesVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 657)
        Me.Controls.Add(Me.rvComprobantes)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteComprobantesVenta"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE COMPROBANTES DE VENTA"
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents rvComprobantes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ckbClienteTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents ckbImportesSinIGV As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoVenta As System.Windows.Forms.ComboBox
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As System.Windows.Forms.ComboBox
End Class
