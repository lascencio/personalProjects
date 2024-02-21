<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteComprasLocales
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteComprasLocales))
        Me.rvComprobantes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.panPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'rvComprobantes
        '
        Me.rvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        Me.rvComprobantes.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvComprobantes.LocalReport.ReportEmbeddedResource = "BusinessManager.rptComprasLocalesMensual.rdlc"
        Me.rvComprobantes.Location = New System.Drawing.Point(0, 62)
        Me.rvComprobantes.Name = "rvComprobantes"
        Me.rvComprobantes.Size = New System.Drawing.Size(1130, 595)
        Me.rvComprobantes.TabIndex = 5
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(167, 28)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(96, 23)
        Me.btnRefrescar.TabIndex = 5
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.MyProgressBar)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.Label7)
        Me.panPrincipal.Controls.Add(Me.cmbMes)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.cmbAño)
        Me.panPrincipal.Controls.Add(Me.btnRefrescar)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(1130, 62)
        Me.panPrincipal.TabIndex = 4
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(734, 37)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(336, 14)
        Me.MyProgressBar.TabIndex = 709
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(1076, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(42, 42)
        Me.btnExportarExcel.TabIndex = 708
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        Me.btnExportarExcel.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(69, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 707
        Me.Label7.Text = "MES"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(69, 30)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(91, 21)
        Me.cmbMes.TabIndex = 706
        Me.cmbMes.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 705
        Me.Label1.Text = "AÑO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAño
        '
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Location = New System.Drawing.Point(12, 30)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(55, 21)
        Me.cmbAño.TabIndex = 704
        '
        'frmReporteComprasLocales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 657)
        Me.Controls.Add(Me.rvComprobantes)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteComprasLocales"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE COMPRAS LOCALES"
        Me.panPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvComprobantes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
End Class
