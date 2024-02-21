<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaComercialLista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvCuentasComerciales = New System.Windows.Forms.DataGridView
        Me.NRO_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TIPO_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CODIGO_VENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DsCuentasComercialesListaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCuentasComercialesLista = New BusinessManager.dsCuentasComercialesLista
        Me.txtNombreCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCuentasComercialesListaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCuentasComercialesLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvCuentasComerciales
        '
        Me.gvCuentasComerciales.AllowUserToAddRows = False
        Me.gvCuentasComerciales.AllowUserToDeleteRows = False
        Me.gvCuentasComerciales.AllowUserToOrderColumns = True
        Me.gvCuentasComerciales.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvCuentasComerciales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvCuentasComerciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCuentasComerciales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NRO_DOCUMENTO, Me.RAZON_SOCIAL, Me.ESTADO, Me.TIPO_DOCUMENTO, Me.CUENTA_COMERCIAL, Me.CODIGO_VENDEDOR})
        Me.gvCuentasComerciales.Location = New System.Drawing.Point(12, 58)
        Me.gvCuentasComerciales.MultiSelect = False
        Me.gvCuentasComerciales.Name = "gvCuentasComerciales"
        Me.gvCuentasComerciales.ReadOnly = True
        Me.gvCuentasComerciales.RowHeadersVisible = False
        Me.gvCuentasComerciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuentasComerciales.Size = New System.Drawing.Size(974, 572)
        Me.gvCuentasComerciales.TabIndex = 2
        Me.gvCuentasComerciales.TabStop = False
        '
        'NRO_DOCUMENTO
        '
        Me.NRO_DOCUMENTO.DataPropertyName = "NRO_DOCUMENTO"
        Me.NRO_DOCUMENTO.HeaderText = "RUC/DNI"
        Me.NRO_DOCUMENTO.Name = "NRO_DOCUMENTO"
        Me.NRO_DOCUMENTO.ReadOnly = True
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "RAZON SOCIAL"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 780
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle2
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 60
        '
        'TIPO_DOCUMENTO
        '
        Me.TIPO_DOCUMENTO.DataPropertyName = "TIPO_DOCUMENTO"
        Me.TIPO_DOCUMENTO.HeaderText = "TIPO_DOCUMETO"
        Me.TIPO_DOCUMENTO.Name = "TIPO_DOCUMENTO"
        Me.TIPO_DOCUMENTO.ReadOnly = True
        Me.TIPO_DOCUMENTO.Visible = False
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "CODIGO"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        Me.CUENTA_COMERCIAL.Visible = False
        Me.CUENTA_COMERCIAL.Width = 80
        '
        'CODIGO_VENDEDOR
        '
        Me.CODIGO_VENDEDOR.DataPropertyName = "CODIGO_VENDEDOR"
        Me.CODIGO_VENDEDOR.HeaderText = "VENDEDOR"
        Me.CODIGO_VENDEDOR.Name = "CODIGO_VENDEDOR"
        Me.CODIGO_VENDEDOR.ReadOnly = True
        Me.CODIGO_VENDEDOR.Visible = False
        '
        'DsCuentasComercialesListaBindingSource
        '
        Me.DsCuentasComercialesListaBindingSource.DataSource = Me.DsCuentasComercialesLista
        Me.DsCuentasComercialesListaBindingSource.Position = 0
        '
        'DsCuentasComercialesLista
        '
        Me.DsCuentasComercialesLista.DataSetName = "dsCuentasComercialesLista"
        Me.DsCuentasComercialesLista.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtNombreCodigoIntro
        '
        Me.txtNombreCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtNombreCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCodigoIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombreCodigoIntro.Location = New System.Drawing.Point(132, 32)
        Me.txtNombreCodigoIntro.MaxLength = 100
        Me.txtNombreCodigoIntro.Name = "txtNombreCodigoIntro"
        Me.txtNombreCodigoIntro.Size = New System.Drawing.Size(663, 21)
        Me.txtNombreCodigoIntro.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(132, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "RAZON SOCIAL"
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.Honeydew
        Me.txtCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 32)
        Me.txtCodigoIntro.MaxLength = 20
        Me.txtCodigoIntro.Name = "txtCodigoIntro"
        Me.txtCodigoIntro.Size = New System.Drawing.Size(114, 21)
        Me.txtCodigoIntro.TabIndex = 0
        Me.txtCodigoIntro.Tag = "EC"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "RUC/DNI"
        '
        'frmCuentaComercialLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 642)
        Me.Controls.Add(Me.txtNombreCodigoIntro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvCuentasComerciales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaComercialLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE CUENTAS COMERCIALES"
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCuentasComercialesListaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCuentasComercialesLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvCuentasComerciales As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NRO_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_VENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsCuentasComercialesListaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCuentasComercialesLista As BusinessManager.dsCuentasComercialesLista
End Class
