﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaChicaMovimientosImprimir
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajaChicaMovimientosImprimir))
        Me.rvCajaChica = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvCajaChica
        '
        Me.rvCajaChica.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCajaChica_CAJA_CHICA_MOVIMIENTOS"
        Me.rvCajaChica.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvCajaChica.LocalReport.ReportEmbeddedResource = "BusinessManager.rptCajaChica.rdlc"
        Me.rvCajaChica.Location = New System.Drawing.Point(0, 0)
        Me.rvCajaChica.Name = "rvCajaChica"
        Me.rvCajaChica.Size = New System.Drawing.Size(1110, 625)
        Me.rvCajaChica.TabIndex = 0
        '
        'frmCajaChicaImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 625)
        Me.Controls.Add(Me.rvCajaChica)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCajaChicaImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAJA CHICA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvCajaChica As Microsoft.Reporting.WinForms.ReportViewer
End Class
