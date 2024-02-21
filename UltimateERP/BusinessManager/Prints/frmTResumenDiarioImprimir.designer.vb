<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTResumenDiarioImprimir
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
        Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsVentas = New BusinessManager.dsVentas()
        Me.VENTAS_PAGO_RESUMENBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rvEBoletaVenta = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.ckbHabilitarVistaPrevia = New System.Windows.Forms.CheckBox()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTAS_PAGO_RESUMENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ECOMPROBANTES_RESUMEN_DIARIOBindingSource
        '
        Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource.DataMember = "ECOMPROBANTES_RESUMEN_DIARIO"
        Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource.DataSource = Me.dsVentas
        '
        'dsVentas
        '
        Me.dsVentas.DataSetName = "dsVentas"
        Me.dsVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VENTAS_PAGO_RESUMENBindingSource
        '
        Me.VENTAS_PAGO_RESUMENBindingSource.DataMember = "VENTAS_PAGO_RESUMEN"
        Me.VENTAS_PAGO_RESUMENBindingSource.DataSource = Me.dsVentas
        '
        'rvEBoletaVenta
        '
        Me.rvEBoletaVenta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rvEBoletaVenta.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ReportDataSource1.Name = "dsDetalles"
        ReportDataSource1.Value = Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource
        ReportDataSource2.Name = "dsPago"
        ReportDataSource2.Value = Me.VENTAS_PAGO_RESUMENBindingSource
        Me.rvEBoletaVenta.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvEBoletaVenta.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvEBoletaVenta.LocalReport.ReportEmbeddedResource = "BusinessManager.rptTResumenDiario_01.rdlc"
        Me.rvEBoletaVenta.Location = New System.Drawing.Point(0, 69)
        Me.rvEBoletaVenta.Name = "rvEBoletaVenta"
        Me.rvEBoletaVenta.Size = New System.Drawing.Size(328, 588)
        Me.rvEBoletaVenta.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 22)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "FECHA"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.txtFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFecha.Location = New System.Drawing.Point(12, 32)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(62, 23)
        Me.txtFecha.TabIndex = 0
        Me.txtFecha.Tag = "F"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFecha.WordWrap = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefrescar.Location = New System.Drawing.Point(218, 9)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(98, 30)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'ckbHabilitarVistaPrevia
        '
        Me.ckbHabilitarVistaPrevia.AutoSize = True
        Me.ckbHabilitarVistaPrevia.BackColor = System.Drawing.Color.Transparent
        Me.ckbHabilitarVistaPrevia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbHabilitarVistaPrevia.Checked = True
        Me.ckbHabilitarVistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbHabilitarVistaPrevia.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbHabilitarVistaPrevia.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbHabilitarVistaPrevia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbHabilitarVistaPrevia.Location = New System.Drawing.Point(218, 42)
        Me.ckbHabilitarVistaPrevia.Name = "ckbHabilitarVistaPrevia"
        Me.ckbHabilitarVistaPrevia.Size = New System.Drawing.Size(98, 20)
        Me.ckbHabilitarVistaPrevia.TabIndex = 2
        Me.ckbHabilitarVistaPrevia.TabStop = False
        Me.ckbHabilitarVistaPrevia.Text = "VISTA PREVIA"
        Me.ckbHabilitarVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbHabilitarVistaPrevia.UseVisualStyleBackColor = False
        '
        'cmbUsuario
        '
        Me.cmbUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUsuario.BackColor = System.Drawing.Color.Azure
        Me.cmbUsuario.DisplayMember = "NOMBRE_LARGO"
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Items.AddRange(New Object() {"A-I", "A-IIA", "TODOS"})
        Me.cmbUsuario.Location = New System.Drawing.Point(75, 32)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(137, 24)
        Me.cmbUsuario.TabIndex = 4
        Me.cmbUsuario.TabStop = False
        Me.cmbUsuario.ValueMember = "CODIGO_ITEM"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(75, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 22)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "USUARIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmTResumenDiarioImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 657)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.ckbHabilitarVistaPrevia)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.rvEBoletaVenta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTResumenDiarioImprimir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESUMEN DE VENTA DIARIO"
        CType(Me.ECOMPROBANTES_RESUMEN_DIARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTAS_PAGO_RESUMENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rvEBoletaVenta As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents ckbHabilitarVistaPrevia As System.Windows.Forms.CheckBox
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ECOMPROBANTES_RESUMEN_DIARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsVentas As BusinessManager.dsVentas
    Friend WithEvents VENTAS_PAGO_RESUMENBindingSource As System.Windows.Forms.BindingSource
End Class
