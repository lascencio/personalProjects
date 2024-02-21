<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesLista
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtDescripcionIntro = New System.Windows.Forms.TextBox()
        Me.txtCodigoIntro = New System.Windows.Forms.TextBox()
        Me.gvCuentasComerciales = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRUPO_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_CUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NRO_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOMICILIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_NO_DOMICILIADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONDICION_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINEA_CREDITO_MN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINEA_CREDITO_ME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LISTA_PRECIOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AFECTO_IGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AGENTE_RETENCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AGENTE_DETRACCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AGENTE_PERCEPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_PROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_VENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRADOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_ANTIGUO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(132, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(549, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "RAZON SOCIAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(114, 18)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "DOCUMENTO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionIntro
        '
        Me.txtDescripcionIntro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcionIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionIntro.Location = New System.Drawing.Point(132, 32)
        Me.txtDescripcionIntro.MaxLength = 100
        Me.txtDescripcionIntro.Name = "txtDescripcionIntro"
        Me.txtDescripcionIntro.Size = New System.Drawing.Size(549, 21)
        Me.txtDescripcionIntro.TabIndex = 6
        '
        'txtCodigoIntro
        '
        Me.txtCodigoIntro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoIntro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIntro.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoIntro.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoIntro.Location = New System.Drawing.Point(12, 32)
        Me.txtCodigoIntro.MaxLength = 20
        Me.txtCodigoIntro.Name = "txtCodigoIntro"
        Me.txtCodigoIntro.Size = New System.Drawing.Size(114, 21)
        Me.txtCodigoIntro.TabIndex = 7
        Me.txtCodigoIntro.TabStop = False
        Me.txtCodigoIntro.Tag = "EC"
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
        Me.gvCuentasComerciales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.CUENTA_COMERCIAL, Me.GRUPO_COMERCIAL, Me.TIPO_CUENTA, Me.TIPO_DOCUMENTO, Me.NRO_DOCUMENTO, Me.RAZON_SOCIAL, Me.DOMICILIO, Me.INDICA_NO_DOMICILIADO, Me.TIPO_MONEDA, Me.CONDICION_PAGO, Me.LINEA_CREDITO_MN, Me.LINEA_CREDITO_ME, Me.LISTA_PRECIOS, Me.AFECTO_IGV, Me.AGENTE_RETENCION, Me.AGENTE_DETRACCION, Me.AGENTE_PERCEPCION, Me.INDICA_CLIENTE, Me.INDICA_PROVEEDOR, Me.CODIGO_VENDEDOR, Me.CODIGO_COMPRADOR, Me.CODIGO_ANTIGUO, Me.ESTADO})
        Me.gvCuentasComerciales.Location = New System.Drawing.Point(12, 58)
        Me.gvCuentasComerciales.MultiSelect = False
        Me.gvCuentasComerciales.Name = "gvCuentasComerciales"
        Me.gvCuentasComerciales.ReadOnly = True
        Me.gvCuentasComerciales.RowHeadersVisible = False
        Me.gvCuentasComerciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCuentasComerciales.Size = New System.Drawing.Size(974, 572)
        Me.gvCuentasComerciales.TabIndex = 8
        Me.gvCuentasComerciales.TabStop = False
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "CUENTA COMERCIAL"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        Me.CUENTA_COMERCIAL.Visible = False
        Me.CUENTA_COMERCIAL.Width = 80
        '
        'GRUPO_COMERCIAL
        '
        Me.GRUPO_COMERCIAL.DataPropertyName = "GRUPO_COMERCIAL"
        Me.GRUPO_COMERCIAL.HeaderText = "GRUPO_COMERCIAL"
        Me.GRUPO_COMERCIAL.Name = "GRUPO_COMERCIAL"
        Me.GRUPO_COMERCIAL.ReadOnly = True
        Me.GRUPO_COMERCIAL.Visible = False
        '
        'TIPO_CUENTA
        '
        Me.TIPO_CUENTA.DataPropertyName = "TIPO_CUENTA"
        Me.TIPO_CUENTA.HeaderText = "TIPO_CUENTA"
        Me.TIPO_CUENTA.Name = "TIPO_CUENTA"
        Me.TIPO_CUENTA.ReadOnly = True
        Me.TIPO_CUENTA.Visible = False
        '
        'TIPO_DOCUMENTO
        '
        Me.TIPO_DOCUMENTO.DataPropertyName = "TIPO_DOCUMENTO"
        Me.TIPO_DOCUMENTO.HeaderText = "TIPO_DOCUMENTO"
        Me.TIPO_DOCUMENTO.Name = "TIPO_DOCUMENTO"
        Me.TIPO_DOCUMENTO.ReadOnly = True
        Me.TIPO_DOCUMENTO.Visible = False
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
        Me.RAZON_SOCIAL.Width = 465
        '
        'DOMICILIO
        '
        Me.DOMICILIO.DataPropertyName = "DOMICILIO"
        Me.DOMICILIO.HeaderText = "DOMICILIO"
        Me.DOMICILIO.Name = "DOMICILIO"
        Me.DOMICILIO.ReadOnly = True
        Me.DOMICILIO.Width = 327
        '
        'INDICA_NO_DOMICILIADO
        '
        Me.INDICA_NO_DOMICILIADO.DataPropertyName = "INDICA_NO_DOMICILIADO"
        Me.INDICA_NO_DOMICILIADO.HeaderText = "INDICA_NO_DOMICILIADO"
        Me.INDICA_NO_DOMICILIADO.Name = "INDICA_NO_DOMICILIADO"
        Me.INDICA_NO_DOMICILIADO.ReadOnly = True
        Me.INDICA_NO_DOMICILIADO.Visible = False
        '
        'TIPO_MONEDA
        '
        Me.TIPO_MONEDA.DataPropertyName = "TIPO_MONEDA"
        Me.TIPO_MONEDA.HeaderText = "TIPO_MONEDA"
        Me.TIPO_MONEDA.Name = "TIPO_MONEDA"
        Me.TIPO_MONEDA.ReadOnly = True
        Me.TIPO_MONEDA.Visible = False
        '
        'CONDICION_PAGO
        '
        Me.CONDICION_PAGO.DataPropertyName = "CONDICION_PAGO"
        Me.CONDICION_PAGO.HeaderText = "CONDICION_PAGO"
        Me.CONDICION_PAGO.Name = "CONDICION_PAGO"
        Me.CONDICION_PAGO.ReadOnly = True
        Me.CONDICION_PAGO.Visible = False
        '
        'LINEA_CREDITO_MN
        '
        Me.LINEA_CREDITO_MN.DataPropertyName = "LINEA_CREDITO_MN"
        Me.LINEA_CREDITO_MN.HeaderText = "LINEA_CREDITO_MN"
        Me.LINEA_CREDITO_MN.Name = "LINEA_CREDITO_MN"
        Me.LINEA_CREDITO_MN.ReadOnly = True
        Me.LINEA_CREDITO_MN.Visible = False
        '
        'LINEA_CREDITO_ME
        '
        Me.LINEA_CREDITO_ME.DataPropertyName = "LINEA_CREDITO_ME"
        Me.LINEA_CREDITO_ME.HeaderText = "LINEA_CREDITO_ME"
        Me.LINEA_CREDITO_ME.Name = "LINEA_CREDITO_ME"
        Me.LINEA_CREDITO_ME.ReadOnly = True
        Me.LINEA_CREDITO_ME.Visible = False
        '
        'LISTA_PRECIOS
        '
        Me.LISTA_PRECIOS.DataPropertyName = "LISTA_PRECIOS"
        Me.LISTA_PRECIOS.HeaderText = "LISTA_PRECIOS"
        Me.LISTA_PRECIOS.Name = "LISTA_PRECIOS"
        Me.LISTA_PRECIOS.ReadOnly = True
        Me.LISTA_PRECIOS.Visible = False
        '
        'AFECTO_IGV
        '
        Me.AFECTO_IGV.DataPropertyName = "AFECTO_IGV"
        Me.AFECTO_IGV.HeaderText = "AFECTO_IGV"
        Me.AFECTO_IGV.Name = "AFECTO_IGV"
        Me.AFECTO_IGV.ReadOnly = True
        Me.AFECTO_IGV.Visible = False
        '
        'AGENTE_RETENCION
        '
        Me.AGENTE_RETENCION.DataPropertyName = "AGENTE_RETENCION"
        Me.AGENTE_RETENCION.HeaderText = "AGENTE_RETENCION"
        Me.AGENTE_RETENCION.Name = "AGENTE_RETENCION"
        Me.AGENTE_RETENCION.ReadOnly = True
        Me.AGENTE_RETENCION.Visible = False
        '
        'AGENTE_DETRACCION
        '
        Me.AGENTE_DETRACCION.DataPropertyName = "AGENTE_DETRACCION"
        Me.AGENTE_DETRACCION.HeaderText = "AGENTE_DETRACCION"
        Me.AGENTE_DETRACCION.Name = "AGENTE_DETRACCION"
        Me.AGENTE_DETRACCION.ReadOnly = True
        Me.AGENTE_DETRACCION.Visible = False
        '
        'AGENTE_PERCEPCION
        '
        Me.AGENTE_PERCEPCION.DataPropertyName = "AGENTE_PERCEPCION"
        Me.AGENTE_PERCEPCION.HeaderText = "AGENTE_PERCEPCION"
        Me.AGENTE_PERCEPCION.Name = "AGENTE_PERCEPCION"
        Me.AGENTE_PERCEPCION.ReadOnly = True
        Me.AGENTE_PERCEPCION.Visible = False
        '
        'INDICA_CLIENTE
        '
        Me.INDICA_CLIENTE.DataPropertyName = "INDICA_CLIENTE"
        Me.INDICA_CLIENTE.HeaderText = "INDICA_CLIENTE"
        Me.INDICA_CLIENTE.Name = "INDICA_CLIENTE"
        Me.INDICA_CLIENTE.ReadOnly = True
        Me.INDICA_CLIENTE.Visible = False
        '
        'INDICA_PROVEEDOR
        '
        Me.INDICA_PROVEEDOR.DataPropertyName = "INDICA_PROVEEDOR"
        Me.INDICA_PROVEEDOR.HeaderText = "INDICA_PROVEEDOR"
        Me.INDICA_PROVEEDOR.Name = "INDICA_PROVEEDOR"
        Me.INDICA_PROVEEDOR.ReadOnly = True
        Me.INDICA_PROVEEDOR.Visible = False
        '
        'CODIGO_VENDEDOR
        '
        Me.CODIGO_VENDEDOR.DataPropertyName = "CODIGO_VENDEDOR"
        Me.CODIGO_VENDEDOR.HeaderText = "VENDEDOR"
        Me.CODIGO_VENDEDOR.Name = "CODIGO_VENDEDOR"
        Me.CODIGO_VENDEDOR.ReadOnly = True
        Me.CODIGO_VENDEDOR.Visible = False
        '
        'CODIGO_COMPRADOR
        '
        Me.CODIGO_COMPRADOR.DataPropertyName = "CODIGO_COMPRADOR"
        Me.CODIGO_COMPRADOR.HeaderText = "CODIGO_COMPRADOR"
        Me.CODIGO_COMPRADOR.Name = "CODIGO_COMPRADOR"
        Me.CODIGO_COMPRADOR.ReadOnly = True
        Me.CODIGO_COMPRADOR.Visible = False
        '
        'CODIGO_ANTIGUO
        '
        Me.CODIGO_ANTIGUO.DataPropertyName = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.HeaderText = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.Name = "CODIGO_ANTIGUO"
        Me.CODIGO_ANTIGUO.ReadOnly = True
        Me.CODIGO_ANTIGUO.Visible = False
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
        'frmClientesLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 642)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtDescripcionIntro)
        Me.Controls.Add(Me.txtCodigoIntro)
        Me.Controls.Add(Me.gvCuentasComerciales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientesLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RELACION DE CLIENTES"
        CType(Me.gvCuentasComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionIntro As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoIntro As System.Windows.Forms.TextBox
    Friend WithEvents gvCuentasComerciales As System.Windows.Forms.DataGridView
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRUPO_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_CUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRO_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOMICILIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_NO_DOMICILIADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONDICION_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINEA_CREDITO_MN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINEA_CREDITO_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LISTA_PRECIOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AFECTO_IGV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGENTE_RETENCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGENTE_DETRACCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGENTE_PERCEPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_PROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_VENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRADOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_ANTIGUO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
