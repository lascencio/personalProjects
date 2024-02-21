<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicketCobranzaImprimir
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
        Me.rvTicketCobranza = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvTicketCobranza
        '
        Me.rvTicketCobranza.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Nothing
        Me.rvTicketCobranza.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvTicketCobranza.LocalReport.ReportEmbeddedResource = "BusinessManager.rptTicketCobranza.rdlc"
        Me.rvTicketCobranza.Location = New System.Drawing.Point(0, 0)
        Me.rvTicketCobranza.Name = "rvTicketCobranza"
        Me.rvTicketCobranza.Size = New System.Drawing.Size(305, 429)
        Me.rvTicketCobranza.TabIndex = 0
        '
        'frmTicketCobranzaImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 429)
        Me.Controls.Add(Me.rvTicketCobranza)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTicketCobranzaImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TICKET DE COBRANZA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvTicketCobranza As Microsoft.Reporting.WinForms.ReportViewer
End Class
