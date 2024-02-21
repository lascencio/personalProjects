<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockAlmacenImprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockAlmacenImprimir))
        Me.STOCK_ALMACENBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsStockAlmacen = New BusinessManager.dsStockAlmacen
        Me.rvStockAlmacen = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.STOCK_ALMACENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsStockAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'STOCK_ALMACENBindingSource
        '
        Me.STOCK_ALMACENBindingSource.DataMember = "STOCK_ALMACEN"
        Me.STOCK_ALMACENBindingSource.DataSource = Me.dsStockAlmacen
        '
        'dsStockAlmacen
        '
        Me.dsStockAlmacen.DataSetName = "dsStockAlmacen"
        Me.dsStockAlmacen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rvStockAlmacen
        '
        Me.rvStockAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsStockAlmacen_STOCK_ALMACEN"
        ReportDataSource1.Value = Me.STOCK_ALMACENBindingSource
        Me.rvStockAlmacen.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvStockAlmacen.LocalReport.ReportEmbeddedResource = "BusinessManager.rptStockAlmacen.rdlc"
        Me.rvStockAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.rvStockAlmacen.Name = "rvStockAlmacen"
        Me.rvStockAlmacen.Size = New System.Drawing.Size(884, 711)
        Me.rvStockAlmacen.TabIndex = 0
        '
        'frmStockAlmacenImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 711)
        Me.Controls.Add(Me.rvStockAlmacen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockAlmacenImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK POR ALMACEN"
        CType(Me.STOCK_ALMACENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsStockAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvStockAlmacen As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents STOCK_ALMACENBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsStockAlmacen As BusinessManager.dsStockAlmacen
End Class
