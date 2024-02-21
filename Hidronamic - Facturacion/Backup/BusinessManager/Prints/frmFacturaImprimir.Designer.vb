<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaImprimir
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaImprimir))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.rvFactura = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvFactura
        '
        Me.rvFactura.BackgroundImage = CType(resources.GetObject("rvFactura.BackgroundImage"), System.Drawing.Image)
        Me.rvFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rvFactura.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsVentas_VENTAS_SER"
        Me.rvFactura.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvFactura.LocalReport.ReportEmbeddedResource = "BusinessManager.rptFactura_Binarix_New.rdlc"
        Me.rvFactura.Location = New System.Drawing.Point(0, 0)
        Me.rvFactura.Name = "rvFactura"
        Me.rvFactura.Size = New System.Drawing.Size(810, 576)
        Me.rvFactura.TabIndex = 0
        '
        'frmFacturaImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 576)
        Me.Controls.Add(Me.rvFactura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmFacturaImprimir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR FACTURA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvFactura As Microsoft.Reporting.WinForms.ReportViewer
End Class
