<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReembolsoGastoLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.rbtBeneficiario = New System.Windows.Forms.RadioButton
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.cmbBeneficiario = New System.Windows.Forms.ComboBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.gvCajaChicaCabecera = New System.Windows.Forms.DataGridView
        Me.CCORRELATIVO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANEXO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADESANE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTIPO_MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CDOCUMENTO_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CDOCUMENTO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CDOCUMENTO_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CDOCUMENTO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CGLOSA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CIMPORTE_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CBASE_IMPONIBLE_GRAVADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CIMPORTE_EXONERADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CIGV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CCODIGO_UI = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvCajaChicaCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtBeneficiario
        '
        Me.rbtBeneficiario.AutoSize = True
        Me.rbtBeneficiario.Location = New System.Drawing.Point(12, 30)
        Me.rbtBeneficiario.Name = "rbtBeneficiario"
        Me.rbtBeneficiario.Size = New System.Drawing.Size(99, 17)
        Me.rbtBeneficiario.TabIndex = 9
        Me.rbtBeneficiario.Text = "BENEFICIARIO"
        Me.rbtBeneficiario.UseVisualStyleBackColor = True
        '
        'rbtTodos
        '
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Location = New System.Drawing.Point(12, 12)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(63, 17)
        Me.rbtTodos.TabIndex = 8
        Me.rbtTodos.TabStop = True
        Me.rbtTodos.Text = "TODOS"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'cmbBeneficiario
        '
        Me.cmbBeneficiario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBeneficiario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBeneficiario.BackColor = System.Drawing.Color.Azure
        Me.cmbBeneficiario.DisplayMember = "RAZON_SOCIAL"
        Me.cmbBeneficiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeneficiario.Enabled = False
        Me.cmbBeneficiario.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbBeneficiario.FormattingEnabled = True
        Me.cmbBeneficiario.Location = New System.Drawing.Point(118, 29)
        Me.cmbBeneficiario.MaxDropDownItems = 16
        Me.cmbBeneficiario.Name = "cmbBeneficiario"
        Me.cmbBeneficiario.Size = New System.Drawing.Size(588, 21)
        Me.cmbBeneficiario.TabIndex = 7
        Me.cmbBeneficiario.ValueMember = "CUENTA_COMERCIAL"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(959, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(131, 24)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "&BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gvCajaChicaCabecera
        '
        Me.gvCajaChicaCabecera.AllowUserToAddRows = False
        Me.gvCajaChicaCabecera.AllowUserToDeleteRows = False
        Me.gvCajaChicaCabecera.AllowUserToOrderColumns = True
        Me.gvCajaChicaCabecera.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCajaChicaCabecera.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvCajaChicaCabecera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCajaChicaCabecera.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CCORRELATIVO, Me.CANEXO, Me.ADESANE, Me.CTIPO_MONEDA, Me.CDOCUMENTO_TIPO, Me.CDOCUMENTO_SERIE, Me.CDOCUMENTO_NUMERO, Me.CDOCUMENTO_FECHA, Me.CGLOSA, Me.CIMPORTE_TOTAL, Me.CBASE_IMPONIBLE_GRAVADA, Me.CIMPORTE_EXONERADO, Me.CIGV, Me.CESTADO, Me.CCODIGO_UI})
        Me.gvCajaChicaCabecera.Location = New System.Drawing.Point(9, 60)
        Me.gvCajaChicaCabecera.MultiSelect = False
        Me.gvCajaChicaCabecera.Name = "gvCajaChicaCabecera"
        Me.gvCajaChicaCabecera.ReadOnly = True
        Me.gvCajaChicaCabecera.RowHeadersVisible = False
        Me.gvCajaChicaCabecera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCajaChicaCabecera.Size = New System.Drawing.Size(1081, 588)
        Me.gvCajaChicaCabecera.TabIndex = 5
        Me.gvCajaChicaCabecera.TabStop = False
        '
        'CCORRELATIVO
        '
        Me.CCORRELATIVO.DataPropertyName = "CCORRELATIVO"
        Me.CCORRELATIVO.HeaderText = "CORREL."
        Me.CCORRELATIVO.Name = "CCORRELATIVO"
        Me.CCORRELATIVO.ReadOnly = True
        Me.CCORRELATIVO.Width = 55
        '
        'CANEXO
        '
        Me.CANEXO.DataPropertyName = "CANEXO"
        Me.CANEXO.HeaderText = "ANEXO"
        Me.CANEXO.Name = "CANEXO"
        Me.CANEXO.ReadOnly = True
        Me.CANEXO.Width = 90
        '
        'ADESANE
        '
        Me.ADESANE.DataPropertyName = "ADESANE"
        Me.ADESANE.HeaderText = "PROVEEDOR"
        Me.ADESANE.Name = "ADESANE"
        Me.ADESANE.ReadOnly = True
        Me.ADESANE.Width = 300
        '
        'CTIPO_MONEDA
        '
        Me.CTIPO_MONEDA.DataPropertyName = "CTIPO_MONEDA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CTIPO_MONEDA.DefaultCellStyle = DataGridViewCellStyle2
        Me.CTIPO_MONEDA.HeaderText = "MON"
        Me.CTIPO_MONEDA.Name = "CTIPO_MONEDA"
        Me.CTIPO_MONEDA.ReadOnly = True
        Me.CTIPO_MONEDA.Width = 40
        '
        'CDOCUMENTO_TIPO
        '
        Me.CDOCUMENTO_TIPO.DataPropertyName = "CDOCUMENTO_TIPO"
        Me.CDOCUMENTO_TIPO.HeaderText = "TIPO"
        Me.CDOCUMENTO_TIPO.Name = "CDOCUMENTO_TIPO"
        Me.CDOCUMENTO_TIPO.ReadOnly = True
        Me.CDOCUMENTO_TIPO.Width = 40
        '
        'CDOCUMENTO_SERIE
        '
        Me.CDOCUMENTO_SERIE.DataPropertyName = "CDOCUMENTO_SERIE"
        Me.CDOCUMENTO_SERIE.HeaderText = "SERIE"
        Me.CDOCUMENTO_SERIE.Name = "CDOCUMENTO_SERIE"
        Me.CDOCUMENTO_SERIE.ReadOnly = True
        Me.CDOCUMENTO_SERIE.Width = 50
        '
        'CDOCUMENTO_NUMERO
        '
        Me.CDOCUMENTO_NUMERO.DataPropertyName = "CDOCUMENTO_NUMERO"
        Me.CDOCUMENTO_NUMERO.HeaderText = "NUMERO"
        Me.CDOCUMENTO_NUMERO.Name = "CDOCUMENTO_NUMERO"
        Me.CDOCUMENTO_NUMERO.ReadOnly = True
        Me.CDOCUMENTO_NUMERO.Width = 70
        '
        'CDOCUMENTO_FECHA
        '
        Me.CDOCUMENTO_FECHA.DataPropertyName = "CDOCUMENTO_FECHA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CDOCUMENTO_FECHA.DefaultCellStyle = DataGridViewCellStyle3
        Me.CDOCUMENTO_FECHA.HeaderText = "FECHA"
        Me.CDOCUMENTO_FECHA.Name = "CDOCUMENTO_FECHA"
        Me.CDOCUMENTO_FECHA.ReadOnly = True
        Me.CDOCUMENTO_FECHA.Width = 70
        '
        'CGLOSA
        '
        Me.CGLOSA.DataPropertyName = "CGLOSA"
        Me.CGLOSA.HeaderText = "GLOSA"
        Me.CGLOSA.Name = "CGLOSA"
        Me.CGLOSA.ReadOnly = True
        Me.CGLOSA.Visible = False
        '
        'CIMPORTE_TOTAL
        '
        Me.CIMPORTE_TOTAL.DataPropertyName = "CIMPORTE_TOTAL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.CIMPORTE_TOTAL.DefaultCellStyle = DataGridViewCellStyle4
        Me.CIMPORTE_TOTAL.HeaderText = "TOTAL"
        Me.CIMPORTE_TOTAL.Name = "CIMPORTE_TOTAL"
        Me.CIMPORTE_TOTAL.ReadOnly = True
        Me.CIMPORTE_TOTAL.Width = 80
        '
        'CBASE_IMPONIBLE_GRAVADA
        '
        Me.CBASE_IMPONIBLE_GRAVADA.DataPropertyName = "CBASE_IMPONIBLE_GRAVADA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CBASE_IMPONIBLE_GRAVADA.DefaultCellStyle = DataGridViewCellStyle5
        Me.CBASE_IMPONIBLE_GRAVADA.HeaderText = "AFECTO"
        Me.CBASE_IMPONIBLE_GRAVADA.Name = "CBASE_IMPONIBLE_GRAVADA"
        Me.CBASE_IMPONIBLE_GRAVADA.ReadOnly = True
        Me.CBASE_IMPONIBLE_GRAVADA.Width = 80
        '
        'CIMPORTE_EXONERADO
        '
        Me.CIMPORTE_EXONERADO.DataPropertyName = "CIMPORTE_EXONERADO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.CIMPORTE_EXONERADO.DefaultCellStyle = DataGridViewCellStyle6
        Me.CIMPORTE_EXONERADO.HeaderText = "EXENTO"
        Me.CIMPORTE_EXONERADO.Name = "CIMPORTE_EXONERADO"
        Me.CIMPORTE_EXONERADO.ReadOnly = True
        Me.CIMPORTE_EXONERADO.Width = 80
        '
        'CIGV
        '
        Me.CIGV.DataPropertyName = "CIGV"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.CIGV.DefaultCellStyle = DataGridViewCellStyle7
        Me.CIGV.HeaderText = "IMPUESTO"
        Me.CIGV.Name = "CIGV"
        Me.CIGV.ReadOnly = True
        Me.CIGV.Width = 70
        '
        'CESTADO
        '
        Me.CESTADO.DataPropertyName = "CESTADO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CESTADO.DefaultCellStyle = DataGridViewCellStyle8
        Me.CESTADO.HeaderText = "EST"
        Me.CESTADO.Name = "CESTADO"
        Me.CESTADO.ReadOnly = True
        Me.CESTADO.Width = 40
        '
        'CCODIGO_UI
        '
        Me.CCODIGO_UI.DataPropertyName = "CCODIGO_UI"
        Me.CCODIGO_UI.HeaderText = "CODIGO_UI"
        Me.CCODIGO_UI.Name = "CCODIGO_UI"
        Me.CCODIGO_UI.ReadOnly = True
        Me.CCODIGO_UI.Visible = False
        '
        'frmReembolsoGastoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 660)
        Me.Controls.Add(Me.rbtBeneficiario)
        Me.Controls.Add(Me.rbtTodos)
        Me.Controls.Add(Me.cmbBeneficiario)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.gvCajaChicaCabecera)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReembolsoGastoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE GASTOS REEMBOLSADOS"
        CType(Me.gvCajaChicaCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtBeneficiario As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbBeneficiario As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gvCajaChicaCabecera As System.Windows.Forms.DataGridView
    Friend WithEvents CCORRELATIVO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANEXO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADESANE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTIPO_MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDOCUMENTO_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDOCUMENTO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDOCUMENTO_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CDOCUMENTO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CGLOSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIMPORTE_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBASE_IMPONIBLE_GRAVADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIMPORTE_EXONERADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIGV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCODIGO_UI As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
