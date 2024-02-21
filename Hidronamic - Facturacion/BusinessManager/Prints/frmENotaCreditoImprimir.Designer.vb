<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmENotaCreditoImprimir
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
        Me.rvENotaCredito = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvENotaCredito
        '
        Me.rvENotaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCabecera"
        ReportDataSource1.Value = Nothing
        ReportDataSource2.Name = "dsDetalles"
        ReportDataSource2.Value = Nothing
        Me.rvENotaCredito.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvENotaCredito.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvENotaCredito.LocalReport.ReportEmbeddedResource = "BusinessManager.rptENotaCredito.rdlc"
        Me.rvENotaCredito.Location = New System.Drawing.Point(0, 0)
        Me.rvENotaCredito.Name = "rvENotaCredito"
        Me.rvENotaCredito.Size = New System.Drawing.Size(790, 657)
        Me.rvENotaCredito.TabIndex = 0
        '
        'frmENotaCreditoImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 657)
        Me.Controls.Add(Me.rvENotaCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmENotaCreditoImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NOTA DE CREDITO ELECTRONICA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvENotaCredito As Microsoft.Reporting.WinForms.ReportViewer
End Class
