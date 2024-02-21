<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteComprobantesVenta
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.VENTAS_LISTABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsVentas = New BusinessManager.dsVentas()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaHasta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaDesde = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.rvComprobantes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.VENTAS_LISTABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VENTAS_LISTABindingSource
        '
        Me.VENTAS_LISTABindingSource.DataMember = "VENTAS_LISTA"
        Me.VENTAS_LISTABindingSource.DataSource = Me.dsVentas
        '
        'dsVentas
        '
        Me.dsVentas.DataSetName = "dsVentas"
        Me.dsVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(1008, 6)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 75
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'cmbClientes
        '
        Me.cmbClientes.BackColor = System.Drawing.Color.Azure
        Me.cmbClientes.DisplayMember = "RAZON_SOCIAL"
        Me.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientes.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(338, 28)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(654, 21)
        Me.cmbClientes.TabIndex = 72
        Me.cmbClientes.TabStop = False
        Me.cmbClientes.ValueMember = "CUENTA_COMERCIAL"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(104, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 18)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "FEC. HASTA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaHasta.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaHasta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaHasta.Location = New System.Drawing.Point(104, 28)
        Me.txtFechaHasta.MaxLength = 10
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(88, 21)
        Me.txtFechaHasta.TabIndex = 68
        Me.txtFechaHasta.Tag = "F"
        Me.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(14, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 18)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "FEC. DESDE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BackColor = System.Drawing.Color.AliceBlue
        Me.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaDesde.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaDesde.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaDesde.Location = New System.Drawing.Point(14, 28)
        Me.txtFechaDesde.MaxLength = 10
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(88, 21)
        Me.txtFechaDesde.TabIndex = 67
        Me.txtFechaDesde.Tag = "F"
        Me.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(198, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 18)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "TIPO COMPROBANTE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Items.AddRange(New Object() {" ", "BOLETA", "FACTURA", "NOTA DE CREDITO", "NOTA DE DEBITO"})
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(198, 28)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(134, 21)
        Me.cmbComprobanteTipo.TabIndex = 63
        Me.cmbComprobanteTipo.TabStop = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(1024, 9)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(96, 23)
        Me.btnRefrescar.TabIndex = 64
        Me.btnRefrescar.Text = "GENERAR"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'rvComprobantes
        '
        ReportDataSource4.Name = "dsVentas"
        ReportDataSource4.Value = Me.VENTAS_LISTABindingSource
        Me.rvComprobantes.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rvComprobantes.LocalReport.ReportEmbeddedResource = "BusinessManager.rptComprobantesVenta.rdlc"
        Me.rvComprobantes.Location = New System.Drawing.Point(0, 61)
        Me.rvComprobantes.Name = "rvComprobantes"
        Me.rvComprobantes.Size = New System.Drawing.Size(1130, 555)
        Me.rvComprobantes.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(338, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(654, 18)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "CLIENTE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReporteComprobantesVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 620)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rvComprobantes)
        Me.Controls.Add(Me.txtCuentaComercial)
        Me.Controls.Add(Me.cmbClientes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFechaHasta)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFechaDesde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbComprobanteTipo)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Name = "frmReporteComprobantesVenta"
        Me.Text = "frmReporteComprobantesVenta"
        CType(Me.VENTAS_LISTABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents rvComprobantes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents VENTAS_LISTABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsVentas As BusinessManager.dsVentas
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
