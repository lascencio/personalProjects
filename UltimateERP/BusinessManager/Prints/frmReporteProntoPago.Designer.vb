﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteProntoPago
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rvProntoPago = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvProntoPago
        '
        Me.rvProntoPago.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCabecera"
        ReportDataSource2.Name = "dsDetalles"
        Me.rvProntoPago.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvProntoPago.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvProntoPago.LocalReport.ReportEmbeddedResource = "BusinessManager.rptCobranzaProntoPago.rdlc"
        Me.rvProntoPago.Location = New System.Drawing.Point(0, 0)
        Me.rvProntoPago.Name = "rvProntoPago"
        Me.rvProntoPago.Size = New System.Drawing.Size(815, 632)
        Me.rvProntoPago.TabIndex = 0
        '
        'frmReporteProntoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 632)
        Me.Controls.Add(Me.rvProntoPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteProntoPago"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR PRONTO PAGO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvProntoPago As Microsoft.Reporting.WinForms.ReportViewer
End Class