<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEComprobantes
    Inherits BusinessManager.frmBase

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmailFacturacion = New System.Windows.Forms.TextBox()
        Me.txtComprobanteTipo = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.rbtMovimientosDia = New System.Windows.Forms.RadioButton()
        Me.rbtMovimientosMes = New System.Windows.Forms.RadioButton()
        Me.txtIGVOrigen = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtAnexo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImporteTotalOrigen = New System.Windows.Forms.TextBox()
        Me.txtAnexoNombre = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSignatureValue = New System.Windows.Forms.TextBox()
        Me.txtDigestValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.txtFechaBuscar = New System.Windows.Forms.TextBox()
        Me.gvVentas = New System.Windows.Forms.DataGridView()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTA_COMERCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIENE_EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIENTO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_CAMBIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOSA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTO_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_AFECTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR_EXENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(1254, 36)
        Me.UC_ToolBar.TabIndex = 0
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.gvVentas)
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Size = New System.Drawing.Size(1254, 614)
        Me.Panel.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtEmailFacturacion)
        Me.Panel1.Controls.Add(Me.txtComprobanteTipo)
        Me.Panel1.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel1.Controls.Add(Me.rbtMovimientosDia)
        Me.Panel1.Controls.Add(Me.rbtMovimientosMes)
        Me.Panel1.Controls.Add(Me.txtIGVOrigen)
        Me.Panel1.Controls.Add(Me.txtTipoCambio)
        Me.Panel1.Controls.Add(Me.txtAnexo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtImporteTotalOrigen)
        Me.Panel1.Controls.Add(Me.txtAnexoNombre)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtSignatureValue)
        Me.Panel1.Controls.Add(Me.txtDigestValue)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label42)
        Me.Panel1.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel1.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel1.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel1.Controls.Add(Me.txtVenta)
        Me.Panel1.Controls.Add(Me.txtFechaBuscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1252, 62)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(805, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 18)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "CORREO  PARA ENVIO DE COMPROBANTES ELECTRONICOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'txtEmailFacturacion
        '
        Me.txtEmailFacturacion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtEmailFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailFacturacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailFacturacion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtEmailFacturacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmailFacturacion.Location = New System.Drawing.Point(805, 29)
        Me.txtEmailFacturacion.MaxLength = 80
        Me.txtEmailFacturacion.Name = "txtEmailFacturacion"
        Me.txtEmailFacturacion.Size = New System.Drawing.Size(340, 21)
        Me.txtEmailFacturacion.TabIndex = 5
        Me.txtEmailFacturacion.TabStop = False
        Me.txtEmailFacturacion.Visible = False
        '
        'txtComprobanteTipo
        '
        Me.txtComprobanteTipo.BackColor = System.Drawing.Color.Cornsilk
        Me.txtComprobanteTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteTipo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteTipo.ForeColor = System.Drawing.Color.Red
        Me.txtComprobanteTipo.Location = New System.Drawing.Point(180, 102)
        Me.txtComprobanteTipo.MaxLength = 4
        Me.txtComprobanteTipo.Name = "txtComprobanteTipo"
        Me.txtComprobanteTipo.ReadOnly = True
        Me.txtComprobanteTipo.Size = New System.Drawing.Size(26, 21)
        Me.txtComprobanteTipo.TabIndex = 16
        Me.txtComprobanteTipo.TabStop = False
        Me.txtComprobanteTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtComprobanteTipo.Visible = False
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Moccasin
        Me.cmbComprobanteTipo.DisplayMember = "TEXTO_01"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(328, 29)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(40, 21)
        Me.cmbComprobanteTipo.TabIndex = 0
        Me.cmbComprobanteTipo.TabStop = False
        Me.cmbComprobanteTipo.ValueMember = "CODIGO_ITEM"
        '
        'rbtMovimientosDia
        '
        Me.rbtMovimientosDia.AutoSize = True
        Me.rbtMovimientosDia.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtMovimientosDia.Location = New System.Drawing.Point(14, 105)
        Me.rbtMovimientosDia.Name = "rbtMovimientosDia"
        Me.rbtMovimientosDia.Size = New System.Drawing.Size(152, 18)
        Me.rbtMovimientosDia.TabIndex = 7
        Me.rbtMovimientosDia.TabStop = True
        Me.rbtMovimientosDia.Text = "MOVIMIENTOS DEL DIA"
        Me.rbtMovimientosDia.UseVisualStyleBackColor = True
        '
        'rbtMovimientosMes
        '
        Me.rbtMovimientosMes.AutoSize = True
        Me.rbtMovimientosMes.Checked = True
        Me.rbtMovimientosMes.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtMovimientosMes.Location = New System.Drawing.Point(14, 84)
        Me.rbtMovimientosMes.Name = "rbtMovimientosMes"
        Me.rbtMovimientosMes.Size = New System.Drawing.Size(154, 18)
        Me.rbtMovimientosMes.TabIndex = 6
        Me.rbtMovimientosMes.TabStop = True
        Me.rbtMovimientosMes.Text = "MOVIMIENTOS DEL MES"
        Me.rbtMovimientosMes.UseVisualStyleBackColor = True
        '
        'txtIGVOrigen
        '
        Me.txtIGVOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIGVOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIGVOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtIGVOrigen.ForeColor = System.Drawing.Color.DimGray
        Me.txtIGVOrigen.Location = New System.Drawing.Point(206, 79)
        Me.txtIGVOrigen.MaxLength = 14
        Me.txtIGVOrigen.Name = "txtIGVOrigen"
        Me.txtIGVOrigen.ReadOnly = True
        Me.txtIGVOrigen.Size = New System.Drawing.Size(29, 21)
        Me.txtIGVOrigen.TabIndex = 12
        Me.txtIGVOrigen.TabStop = False
        Me.txtIGVOrigen.Tag = "D"
        Me.txtIGVOrigen.Text = "0.00"
        Me.txtIGVOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIGVOrigen.Visible = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.Moccasin
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTipoCambio.Location = New System.Drawing.Point(241, 79)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(22, 21)
        Me.txtTipoCambio.TabIndex = 13
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.Visible = False
        '
        'txtAnexo
        '
        Me.txtAnexo.BackColor = System.Drawing.Color.Honeydew
        Me.txtAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnexo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtAnexo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtAnexo.Location = New System.Drawing.Point(180, 80)
        Me.txtAnexo.MaxLength = 11
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(21, 21)
        Me.txtAnexo.TabIndex = 11
        Me.txtAnexo.Tag = ""
        Me.txtAnexo.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(554, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "PRECIO VENTA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotalOrigen
        '
        Me.txtImporteTotalOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotalOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotalOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotalOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotalOrigen.Location = New System.Drawing.Point(554, 29)
        Me.txtImporteTotalOrigen.MaxLength = 14
        Me.txtImporteTotalOrigen.Name = "txtImporteTotalOrigen"
        Me.txtImporteTotalOrigen.ReadOnly = True
        Me.txtImporteTotalOrigen.Size = New System.Drawing.Size(94, 21)
        Me.txtImporteTotalOrigen.TabIndex = 10
        Me.txtImporteTotalOrigen.TabStop = False
        Me.txtImporteTotalOrigen.Tag = "D"
        Me.txtImporteTotalOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnexoNombre
        '
        Me.txtAnexoNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtAnexoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnexoNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtAnexoNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAnexoNombre.Location = New System.Drawing.Point(11, 29)
        Me.txtAnexoNombre.MaxLength = 120
        Me.txtAnexoNombre.Name = "txtAnexoNombre"
        Me.txtAnexoNombre.ReadOnly = True
        Me.txtAnexoNombre.Size = New System.Drawing.Size(316, 21)
        Me.txtAnexoNombre.TabIndex = 9
        Me.txtAnexoNombre.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(11, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(316, 18)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "CLIENTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSignatureValue
        '
        Me.txtSignatureValue.BackColor = System.Drawing.Color.Moccasin
        Me.txtSignatureValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSignatureValue.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtSignatureValue.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSignatureValue.Location = New System.Drawing.Point(294, 79)
        Me.txtSignatureValue.MaxLength = 0
        Me.txtSignatureValue.Name = "txtSignatureValue"
        Me.txtSignatureValue.ReadOnly = True
        Me.txtSignatureValue.Size = New System.Drawing.Size(14, 21)
        Me.txtSignatureValue.TabIndex = 15
        Me.txtSignatureValue.TabStop = False
        Me.txtSignatureValue.Visible = False
        '
        'txtDigestValue
        '
        Me.txtDigestValue.BackColor = System.Drawing.Color.Moccasin
        Me.txtDigestValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDigestValue.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtDigestValue.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDigestValue.Location = New System.Drawing.Point(281, 79)
        Me.txtDigestValue.MaxLength = 0
        Me.txtDigestValue.Name = "txtDigestValue"
        Me.txtDigestValue.ReadOnly = True
        Me.txtDigestValue.Size = New System.Drawing.Size(10, 21)
        Me.txtDigestValue.TabIndex = 14
        Me.txtDigestValue.TabStop = False
        Me.txtDigestValue.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(328, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "TIPO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(359, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 40)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "DOCUMENTO SELECCIONADO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(483, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "F. EMISION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(410, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 18)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "NUMERO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(369, 10)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(40, 18)
        Me.Label42.TabIndex = 18
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(483, 29)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.ReadOnly = True
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(70, 21)
        Me.txtComprobanteFecha.TabIndex = 3
        Me.txtComprobanteFecha.TabStop = False
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(410, 29)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.ReadOnly = True
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(72, 21)
        Me.txtComprobanteNumero.TabIndex = 2
        Me.txtComprobanteNumero.TabStop = False
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(369, 29)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.ReadOnly = True
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(40, 21)
        Me.txtComprobanteSerie.TabIndex = 1
        Me.txtComprobanteSerie.TabStop = False
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(649, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 18)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "MONEDA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Moccasin
        Me.cmbTipoMoneda.DisplayMember = "NOMBRE_LARGO"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(649, 29)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(145, 21)
        Me.cmbTipoMoneda.TabIndex = 4
        Me.cmbTipoMoneda.TabStop = False
        Me.cmbTipoMoneda.ValueMember = "CODIGO_ITEM"
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(269, 79)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 69
        Me.txtVenta.TabStop = False
        Me.txtVenta.Visible = False
        '
        'txtFechaBuscar
        '
        Me.txtFechaBuscar.BackColor = System.Drawing.Color.Honeydew
        Me.txtFechaBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaBuscar.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtFechaBuscar.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFechaBuscar.Location = New System.Drawing.Point(247, 102)
        Me.txtFechaBuscar.MaxLength = 10
        Me.txtFechaBuscar.Name = "txtFechaBuscar"
        Me.txtFechaBuscar.Size = New System.Drawing.Size(67, 21)
        Me.txtFechaBuscar.TabIndex = 8
        Me.txtFechaBuscar.Tag = "F"
        Me.txtFechaBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gvVentas
        '
        Me.gvVentas.AllowUserToAddRows = False
        Me.gvVentas.AllowUserToDeleteRows = False
        Me.gvVentas.AllowUserToOrderColumns = True
        Me.gvVentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VENTA, Me.COMPROBANTE_FECHA, Me.COMPROBANTE_TIPO, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.CUENTA_COMERCIAL, Me.RAZON_SOCIAL, Me.TIENE_EMAIL, Me.ASIENTO_NUMERO, Me.ASIENTO_FECHA, Me.MONEDA, Me.TIPO_CAMBIO, Me.GLOSA, Me.MONTO_TOTAL, Me.VALOR_AFECTO, Me.VALOR_EXENTO, Me.IMPUESTO, Me.USUARIO_ENVIO, Me.FECHA_ENVIO, Me.ESTADO, Me.EMAIL})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvVentas.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvVentas.EnableHeadersVisualStyles = False
        Me.gvVentas.Location = New System.Drawing.Point(0, 62)
        Me.gvVentas.MultiSelect = False
        Me.gvVentas.Name = "gvVentas"
        Me.gvVentas.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.gvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentas.Size = New System.Drawing.Size(1252, 550)
        Me.gvVentas.TabIndex = 1
        Me.gvVentas.TabStop = False
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VENTA.Visible = False
        Me.VENTA.Width = 85
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPROBANTE_FECHA.HeaderText = "FECHA EMISION"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_FECHA.Width = 140
        '
        'COMPROBANTE_TIPO
        '
        Me.COMPROBANTE_TIPO.DataPropertyName = "COMPROBANTE_TIPO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COMPROBANTE_TIPO.DefaultCellStyle = DataGridViewCellStyle3
        Me.COMPROBANTE_TIPO.HeaderText = "TIPO"
        Me.COMPROBANTE_TIPO.Name = "COMPROBANTE_TIPO"
        Me.COMPROBANTE_TIPO.ReadOnly = True
        Me.COMPROBANTE_TIPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_TIPO.Width = 35
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_SERIE.Width = 45
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        Me.COMPROBANTE_NUMERO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COMPROBANTE_NUMERO.Width = 70
        '
        'CUENTA_COMERCIAL
        '
        Me.CUENTA_COMERCIAL.DataPropertyName = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.HeaderText = "RUC"
        Me.CUENTA_COMERCIAL.Name = "CUENTA_COMERCIAL"
        Me.CUENTA_COMERCIAL.ReadOnly = True
        Me.CUENTA_COMERCIAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CUENTA_COMERCIAL.Width = 90
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "CLIENTE"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RAZON_SOCIAL.Width = 280
        '
        'TIENE_EMAIL
        '
        Me.TIENE_EMAIL.DataPropertyName = "TIENE_EMAIL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TIENE_EMAIL.DefaultCellStyle = DataGridViewCellStyle4
        Me.TIENE_EMAIL.HeaderText = "EMAIL"
        Me.TIENE_EMAIL.Name = "TIENE_EMAIL"
        Me.TIENE_EMAIL.ReadOnly = True
        Me.TIENE_EMAIL.Width = 40
        '
        'ASIENTO_NUMERO
        '
        Me.ASIENTO_NUMERO.DataPropertyName = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.HeaderText = "ASIENTO"
        Me.ASIENTO_NUMERO.Name = "ASIENTO_NUMERO"
        Me.ASIENTO_NUMERO.ReadOnly = True
        Me.ASIENTO_NUMERO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ASIENTO_NUMERO.Visible = False
        Me.ASIENTO_NUMERO.Width = 60
        '
        'ASIENTO_FECHA
        '
        Me.ASIENTO_FECHA.DataPropertyName = "ASIENTO_FECHA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ASIENTO_FECHA.DefaultCellStyle = DataGridViewCellStyle5
        Me.ASIENTO_FECHA.HeaderText = "FECHA"
        Me.ASIENTO_FECHA.Name = "ASIENTO_FECHA"
        Me.ASIENTO_FECHA.ReadOnly = True
        Me.ASIENTO_FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ASIENTO_FECHA.Visible = False
        Me.ASIENTO_FECHA.Width = 140
        '
        'MONEDA
        '
        Me.MONEDA.DataPropertyName = "MONEDA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MONEDA.DefaultCellStyle = DataGridViewCellStyle6
        Me.MONEDA.HeaderText = "MON"
        Me.MONEDA.Name = "MONEDA"
        Me.MONEDA.ReadOnly = True
        Me.MONEDA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MONEDA.Width = 40
        '
        'TIPO_CAMBIO
        '
        Me.TIPO_CAMBIO.DataPropertyName = "TIPO_CAMBIO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TIPO_CAMBIO.DefaultCellStyle = DataGridViewCellStyle7
        Me.TIPO_CAMBIO.HeaderText = "TC"
        Me.TIPO_CAMBIO.Name = "TIPO_CAMBIO"
        Me.TIPO_CAMBIO.ReadOnly = True
        Me.TIPO_CAMBIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TIPO_CAMBIO.Visible = False
        Me.TIPO_CAMBIO.Width = 40
        '
        'GLOSA
        '
        Me.GLOSA.DataPropertyName = "GLOSA"
        Me.GLOSA.HeaderText = "GLOSA"
        Me.GLOSA.Name = "GLOSA"
        Me.GLOSA.ReadOnly = True
        Me.GLOSA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOSA.Visible = False
        '
        'MONTO_TOTAL
        '
        Me.MONTO_TOTAL.DataPropertyName = "MONTO_TOTAL"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.MONTO_TOTAL.DefaultCellStyle = DataGridViewCellStyle8
        Me.MONTO_TOTAL.HeaderText = "PRECIO_VENTA"
        Me.MONTO_TOTAL.Name = "MONTO_TOTAL"
        Me.MONTO_TOTAL.ReadOnly = True
        Me.MONTO_TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'VALOR_AFECTO
        '
        Me.VALOR_AFECTO.DataPropertyName = "VALOR_AFECTO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.VALOR_AFECTO.DefaultCellStyle = DataGridViewCellStyle9
        Me.VALOR_AFECTO.HeaderText = "AFECTO"
        Me.VALOR_AFECTO.Name = "VALOR_AFECTO"
        Me.VALOR_AFECTO.ReadOnly = True
        Me.VALOR_AFECTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VALOR_AFECTO.Visible = False
        Me.VALOR_AFECTO.Width = 80
        '
        'VALOR_EXENTO
        '
        Me.VALOR_EXENTO.DataPropertyName = "VALOR_EXENTO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.VALOR_EXENTO.DefaultCellStyle = DataGridViewCellStyle10
        Me.VALOR_EXENTO.HeaderText = "EXENTO"
        Me.VALOR_EXENTO.Name = "VALOR_EXENTO"
        Me.VALOR_EXENTO.ReadOnly = True
        Me.VALOR_EXENTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VALOR_EXENTO.Visible = False
        Me.VALOR_EXENTO.Width = 80
        '
        'IMPUESTO
        '
        Me.IMPUESTO.DataPropertyName = "IMPUESTO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.IMPUESTO.DefaultCellStyle = DataGridViewCellStyle11
        Me.IMPUESTO.HeaderText = "IMPUESTO"
        Me.IMPUESTO.Name = "IMPUESTO"
        Me.IMPUESTO.ReadOnly = True
        Me.IMPUESTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IMPUESTO.Visible = False
        Me.IMPUESTO.Width = 70
        '
        'USUARIO_ENVIO
        '
        Me.USUARIO_ENVIO.DataPropertyName = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.HeaderText = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.Name = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.ReadOnly = True
        Me.USUARIO_ENVIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.USUARIO_ENVIO.Width = 120
        '
        'FECHA_ENVIO
        '
        Me.FECHA_ENVIO.DataPropertyName = "FECHA_ENVIO"
        DataGridViewCellStyle12.Format = "G"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.FECHA_ENVIO.DefaultCellStyle = DataGridViewCellStyle12
        Me.FECHA_ENVIO.HeaderText = "FECHA_ENVIO"
        Me.FECHA_ENVIO.Name = "FECHA_ENVIO"
        Me.FECHA_ENVIO.ReadOnly = True
        Me.FECHA_ENVIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FECHA_ENVIO.Width = 140
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle13
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ESTADO.Width = 80
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        Me.EMAIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EMAIL.Visible = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'frmEComprobantes
        '
        Me.ClientSize = New System.Drawing.Size(1254, 650)
        Me.Name = "frmEComprobantes"
        Me.Text = " COMPROBANTES ELECTRONICOS"
        Me.Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtComprobanteTipo As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents rbtMovimientosDia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMovimientosMes As System.Windows.Forms.RadioButton
    Friend WithEvents txtIGVOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotalOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSignatureValue As System.Windows.Forms.TextBox
    Friend WithEvents txtDigestValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaBuscar As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtEmailFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA_COMERCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIENE_EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIENTO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_CAMBIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONTO_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_AFECTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR_EXENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
