<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTResumenCobranzaDiaria
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
        Me.rvCobranzas = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.ckbHabilitarVistaPrevia = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'rvCobranzas
        '
        Me.rvCobranzas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rvCobranzas.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ReportDataSource1.Name = "dsDetalles"
        Me.rvCobranzas.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvCobranzas.LocalReport.ReportEmbeddedResource = "BusinessManager.rptCobranzasDiario_01.rdlc"
        Me.rvCobranzas.Location = New System.Drawing.Point(0, 69)
        Me.rvCobranzas.Name = "rvCobranzas"
        Me.rvCobranzas.Size = New System.Drawing.Size(328, 588)
        Me.rvCobranzas.TabIndex = 3
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
        Me.Label1.Text = "AGENCIA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAgencia
        '
        Me.cmbAgencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAgencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAgencia.BackColor = System.Drawing.Color.Azure
        Me.cmbAgencia.DisplayMember = "DESCRIPCION"
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(75, 34)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(137, 21)
        Me.cmbAgencia.TabIndex = 7
        Me.cmbAgencia.ValueMember = "CODIGO"
        '
        'frmTResumenCobranzaDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 657)
        Me.Controls.Add(Me.cmbAgencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ckbHabilitarVistaPrevia)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.rvCobranzas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTResumenCobranzaDiaria"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESUMEN DE COBRANZA DIARIA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rvCobranzas As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents ckbHabilitarVistaPrevia As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
End Class
