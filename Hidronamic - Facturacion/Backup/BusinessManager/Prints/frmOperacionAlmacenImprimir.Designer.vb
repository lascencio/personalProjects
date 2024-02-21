<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacionAlmacenImprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperacionAlmacenImprimir))
        Me.rvMovimientoAlmacen = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsOperacionesAlmacen = New BusinessManager.dsOperacionesAlmacen
        Me.DETALLES_OPERACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsOperacionesAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETALLES_OPERACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvMovimientoAlmacen
        '
        Me.rvMovimientoAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsOperacionesAlmacen_DETALLES_OPERACION"
        ReportDataSource1.Value = Me.DETALLES_OPERACIONBindingSource
        Me.rvMovimientoAlmacen.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvMovimientoAlmacen.LocalReport.ReportEmbeddedResource = "BusinessManager.rptOperacionAlmacen.rdlc"
        Me.rvMovimientoAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.rvMovimientoAlmacen.Name = "rvMovimientoAlmacen"
        Me.rvMovimientoAlmacen.Size = New System.Drawing.Size(984, 711)
        Me.rvMovimientoAlmacen.TabIndex = 0
        '
        'dsOperacionesAlmacen
        '
        Me.dsOperacionesAlmacen.DataSetName = "dsOperacionesAlmacen"
        Me.dsOperacionesAlmacen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DETALLES_OPERACIONBindingSource
        '
        Me.DETALLES_OPERACIONBindingSource.DataMember = "DETALLES_OPERACION"
        Me.DETALLES_OPERACIONBindingSource.DataSource = Me.dsOperacionesAlmacen
        '
        'frmOperacionAlmacenImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 711)
        Me.Controls.Add(Me.rvMovimientoAlmacen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOperacionAlmacenImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR MOVIMIENTO DE ALMACEN"
        CType(Me.dsOperacionesAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETALLES_OPERACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvMovimientoAlmacen As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DETALLES_OPERACIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsOperacionesAlmacen As BusinessManager.dsOperacionesAlmacen
End Class
