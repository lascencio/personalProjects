<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSerieVehicularLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvSeries = New System.Windows.Forms.DataGridView()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE_CHASIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA_OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvSeries
        '
        Me.gvSeries.AllowUserToAddRows = False
        Me.gvSeries.AllowUserToDeleteRows = False
        Me.gvSeries.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvSeries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMERO_SERIE, Me.NUMERO_SERIE_CHASIS, Me.COLOR, Me.REFERENCIA_OPERACION, Me.FECHA_OPERACION})
        Me.gvSeries.Location = New System.Drawing.Point(12, 12)
        Me.gvSeries.MultiSelect = False
        Me.gvSeries.Name = "gvSeries"
        Me.gvSeries.ReadOnly = True
        Me.gvSeries.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvSeries.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSeries.Size = New System.Drawing.Size(806, 474)
        Me.gvSeries.TabIndex = 2
        Me.gvSeries.TabStop = False
        '
        'NUMERO_SERIE
        '
        Me.NUMERO_SERIE.DataPropertyName = "NUMERO_SERIE"
        Me.NUMERO_SERIE.HeaderText = "NUMERO SERIE"
        Me.NUMERO_SERIE.Name = "NUMERO_SERIE"
        Me.NUMERO_SERIE.ReadOnly = True
        Me.NUMERO_SERIE.Width = 250
        '
        'NUMERO_SERIE_CHASIS
        '
        Me.NUMERO_SERIE_CHASIS.DataPropertyName = "NUMERO_SERIE_CHASIS"
        Me.NUMERO_SERIE_CHASIS.HeaderText = "NUMERO CHASIS"
        Me.NUMERO_SERIE_CHASIS.Name = "NUMERO_SERIE_CHASIS"
        Me.NUMERO_SERIE_CHASIS.ReadOnly = True
        Me.NUMERO_SERIE_CHASIS.Width = 250
        '
        'COLOR
        '
        Me.COLOR.DataPropertyName = "COLOR"
        Me.COLOR.HeaderText = "COLOR"
        Me.COLOR.Name = "COLOR"
        Me.COLOR.ReadOnly = True
        Me.COLOR.Width = 150
        '
        'REFERENCIA_OPERACION
        '
        Me.REFERENCIA_OPERACION.DataPropertyName = "REFERENCIA_OPERACION"
        Me.REFERENCIA_OPERACION.HeaderText = "REFERENCIA_OPERACION"
        Me.REFERENCIA_OPERACION.Name = "REFERENCIA_OPERACION"
        Me.REFERENCIA_OPERACION.ReadOnly = True
        Me.REFERENCIA_OPERACION.Visible = False
        '
        'FECHA_OPERACION
        '
        Me.FECHA_OPERACION.DataPropertyName = "FECHA_OPERACION"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHA_OPERACION.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHA_OPERACION.HeaderText = "FECHA OPERACION"
        Me.FECHA_OPERACION.Name = "FECHA_OPERACION"
        Me.FECHA_OPERACION.ReadOnly = True
        Me.FECHA_OPERACION.Width = 132
        '
        'frmSerieVehicularLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 498)
        Me.Controls.Add(Me.gvSeries)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSerieVehicularLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUMERO DE SERIES DISPONIBLES"
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvSeries As System.Windows.Forms.DataGridView
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE_CHASIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA_OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
