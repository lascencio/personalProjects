<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemitenteImprimir
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
        Me.rvGuiaRemitente = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvGuiaRemitente
        '
        Me.rvGuiaRemitente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvGuiaRemitente.LocalReport.ReportEmbeddedResource = "BusinessManager.rptEGuiaRemitente.rdlc"
        Me.rvGuiaRemitente.Location = New System.Drawing.Point(0, 0)
        Me.rvGuiaRemitente.Name = "rvGuiaRemitente"
        Me.rvGuiaRemitente.Size = New System.Drawing.Size(810, 607)
        Me.rvGuiaRemitente.TabIndex = 0
        '
        'frmGuiaRemitenteImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 607)
        Me.Controls.Add(Me.rvGuiaRemitente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemitenteImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR GUIA DE REMISION"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvGuiaRemitente As Microsoft.Reporting.WinForms.ReportViewer
End Class
