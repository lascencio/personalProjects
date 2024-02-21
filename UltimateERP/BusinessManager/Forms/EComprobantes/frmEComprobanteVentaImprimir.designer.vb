<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEComprobanteVentaImprimir
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rvComprobante = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvComprobante
        '
        Me.rvComprobante.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCabecera"
        ReportDataSource1.Value = Nothing
        ReportDataSource2.Name = "dsDetalles"
        ReportDataSource2.Value = Nothing
        Me.rvComprobante.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvComprobante.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvComprobante.LocalReport.ReportEmbeddedResource = "BusinessManager.rptFactura.rdlc"
        Me.rvComprobante.Location = New System.Drawing.Point(0, 0)
        Me.rvComprobante.Margin = New System.Windows.Forms.Padding(0)
        Me.rvComprobante.Name = "rvComprobante"
        Me.rvComprobante.Size = New System.Drawing.Size(790, 657)
        Me.rvComprobante.TabIndex = 0
        '
        'frmEComprobanteVentaImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 657)
        Me.Controls.Add(Me.rvComprobante)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEComprobanteVentaImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR COMPROBANTE DE VENTA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvComprobante As Microsoft.Reporting.WinForms.ReportViewer
End Class
