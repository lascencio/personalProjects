﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoImprimir
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.rvProductos = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PRODUCTOS_LISTABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsProductosLista = New BusinessManager.dsProductosLista
        CType(Me.PRODUCTOS_LISTABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsProductosLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvProductos
        '
        Me.rvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rvProductos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "dsProductosLista_PRODUCTOS_LISTA"
        ReportDataSource2.Value = Me.PRODUCTOS_LISTABindingSource
        Me.rvProductos.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvProductos.LocalReport.ReportEmbeddedResource = "BusinessManager.rptProductos.rdlc"
        Me.rvProductos.Location = New System.Drawing.Point(0, 0)
        Me.rvProductos.Name = "rvProductos"
        Me.rvProductos.Size = New System.Drawing.Size(820, 681)
        Me.rvProductos.TabIndex = 0
        '
        'PRODUCTOS_LISTABindingSource
        '
        Me.PRODUCTOS_LISTABindingSource.DataMember = "PRODUCTOS_LISTA"
        Me.PRODUCTOS_LISTABindingSource.DataSource = Me.dsProductosLista
        '
        'dsProductosLista
        '
        Me.dsProductosLista.DataSetName = "dsProductosLista"
        Me.dsProductosLista.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmProductoImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 681)
        Me.Controls.Add(Me.rvProductos)
        Me.Name = "frmProductoImprimir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE PRODUCTOS"
        CType(Me.PRODUCTOS_LISTABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsProductosLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvProductos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PRODUCTOS_LISTABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsProductosLista As BusinessManager.dsProductosLista
End Class
