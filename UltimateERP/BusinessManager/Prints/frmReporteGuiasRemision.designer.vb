<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteGuiasRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteGuiasRemision))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.rvGuias = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnPrincipal
        '
        Me.pnPrincipal.Controls.Add(Me.MyProgressBar)
        Me.pnPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.pnPrincipal.Controls.Add(Me.Label1)
        Me.pnPrincipal.Controls.Add(Me.cmbDia)
        Me.pnPrincipal.Controls.Add(Me.Label3)
        Me.pnPrincipal.Controls.Add(Me.Label2)
        Me.pnPrincipal.Controls.Add(Me.cmbMes)
        Me.pnPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.pnPrincipal.Controls.Add(Me.btnRefrescar)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(1130, 58)
        Me.pnPrincipal.TabIndex = 2
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(734, 37)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(336, 14)
        Me.MyProgressBar.TabIndex = 711
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
        Me.btnExportarExcel.TabIndex = 710
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(208, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 18)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "DIA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDia
        '
        Me.cmbDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDia.BackColor = System.Drawing.Color.Azure
        Me.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDia.FormattingEnabled = True
        Me.cmbDia.Location = New System.Drawing.Point(208, 30)
        Me.cmbDia.MaxDropDownItems = 31
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(42, 21)
        Me.cmbDia.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(91, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 18)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 18)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "EJERCICIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(91, 30)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 46
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 30)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 45
        Me.cmbEjercicio.TabStop = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(266, 28)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(173, 23)
        Me.btnRefrescar.TabIndex = 44
        Me.btnRefrescar.Text = "REFRESCAR REPORTE"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'rvGuias
        '
        Me.rvGuias.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvGuias.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvGuias.LocalReport.ReportEmbeddedResource = "BusinessManager.rptGuiasRemitente.rdlc"
        Me.rvGuias.Location = New System.Drawing.Point(0, 58)
        Me.rvGuias.Name = "rvGuias"
        Me.rvGuias.Size = New System.Drawing.Size(1130, 649)
        Me.rvGuias.TabIndex = 3
        '
        'frmReporteGuiasRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 707)
        Me.Controls.Add(Me.rvGuias)
        Me.Controls.Add(Me.pnPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmReporteGuiasRemision"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE GUIAS A DE REMISION"
        Me.pnPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents rvGuias As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDia As System.Windows.Forms.ComboBox
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
