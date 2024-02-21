<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaPorTraslado
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaPorTraslado))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.txtIndicaSerie = New System.Windows.Forms.TextBox()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteSerie = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gvGuiaLineas = New System.Windows.Forms.DataGridView()
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCantidadStock = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.txtLinea = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.txtReferenciaCUO = New System.Windows.Forms.TextBox()
        Me.cmbDireccionEnvio = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtPuntoLlegada = New System.Windows.Forms.TextBox()
        Me.txtPuntoPartida = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTransportistaRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtTransportistaRUC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConductorNombre = New System.Windows.Forms.TextBox()
        Me.txtConductorDNI = New System.Windows.Forms.TextBox()
        Me.txtComprobanteFechaTraslado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumeroPlaca = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.obtIndicaTransportePrivado = New System.Windows.Forms.RadioButton()
        Me.obtIndicaTransportePublico = New System.Windows.Forms.RadioButton()
        Me.Panel.SuspendLayout()
        CType(Me.gvGuiaLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(846, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.obtIndicaTransportePublico)
        Me.Panel.Controls.Add(Me.obtIndicaTransportePrivado)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtNumeroPlaca)
        Me.Panel.Controls.Add(Me.txtComprobanteFechaTraslado)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtConductorNombre)
        Me.Panel.Controls.Add(Me.txtConductorDNI)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.txtTransportistaRazonSocial)
        Me.Panel.Controls.Add(Me.txtTransportistaRUC)
        Me.Panel.Controls.Add(Me.txtPuntoPartida)
        Me.Panel.Controls.Add(Me.txtPuntoLlegada)
        Me.Panel.Controls.Add(Me.cmbDireccionEnvio)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.txtReferenciaCUO)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txtGuia)
        Me.Panel.Controls.Add(Me.txtIndicaSerie)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.cmbComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtProductoDescripcion)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.gvGuiaLineas)
        Me.Panel.Controls.Add(Me.btnNuevo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtCantidadStock)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtOperacion)
        Me.Panel.Size = New System.Drawing.Size(846, 576)
        Me.Panel.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(819, 18)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "COMENTARIO/OBSERVACIONES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGuia
        '
        Me.txtGuia.BackColor = System.Drawing.Color.Moccasin
        Me.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGuia.Location = New System.Drawing.Point(432, 32)
        Me.txtGuia.MaxLength = 8
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(104, 21)
        Me.txtGuia.TabIndex = 16
        Me.txtGuia.TabStop = False
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIndicaSerie
        '
        Me.txtIndicaSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaSerie.Location = New System.Drawing.Point(0, 384)
        Me.txtIndicaSerie.MaxLength = 1
        Me.txtIndicaSerie.Name = "txtIndicaSerie"
        Me.txtIndicaSerie.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaSerie.TabIndex = 31
        Me.txtIndicaSerie.TabStop = False
        Me.txtIndicaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaSerie.Visible = False
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(621, 32)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 20
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDocumentoTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(12, 74)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 11
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(150, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(681, 18)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "NOMBRE O RAZON SOCIAL DEL DESTINATARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(150, 74)
        Me.txtRazonSocial.MaxLength = 100
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(681, 21)
        Me.txtRazonSocial.TabIndex = 1
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(69, 74)
        Me.txtDocumentoNumero.MaxLength = 15
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(80, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(12, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 18)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "DOC. IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(145, 32)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 9
        Me.txtComprobanteFecha.TabStop = False
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbComprobanteSerie
        '
        Me.cmbComprobanteSerie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteSerie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteSerie.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteSerie.DisplayMember = "CODIGO"
        Me.cmbComprobanteSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteSerie.Enabled = False
        Me.cmbComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteSerie.FormattingEnabled = True
        Me.cmbComprobanteSerie.Location = New System.Drawing.Point(11, 32)
        Me.cmbComprobanteSerie.Name = "cmbComprobanteSerie"
        Me.cmbComprobanteSerie.Size = New System.Drawing.Size(53, 21)
        Me.cmbComprobanteSerie.TabIndex = 21
        Me.cmbComprobanteSerie.TabStop = False
        Me.cmbComprobanteSerie.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(145, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "F. EMISION"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(65, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 18)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "NUMERO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(12, 13)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(52, 18)
        Me.Label42.TabIndex = 36
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(65, 32)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.ReadOnly = True
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(79, 21)
        Me.txtComprobanteNumero.TabIndex = 22
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(76, 302)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(530, 21)
        Me.txtProductoDescripcion.TabIndex = 32
        Me.txtProductoDescripcion.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(12, 302)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(63, 21)
        Me.txtProducto.TabIndex = 25
        Me.txtProducto.TabStop = False
        Me.txtProducto.Tag = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 283)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(594, 18)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvGuiaLineas
        '
        Me.gvGuiaLineas.AllowUserToAddRows = False
        Me.gvGuiaLineas.AllowUserToDeleteRows = False
        Me.gvGuiaLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvGuiaLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvGuiaLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvGuiaLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvGuiaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.CANTIDAD, Me.INDICA_SERIE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.EXISTE_RESUMEN_PERIODO2, Me.ELIMINAR})
        Me.gvGuiaLineas.EnableHeadersVisualStyles = False
        Me.gvGuiaLineas.Location = New System.Drawing.Point(11, 325)
        Me.gvGuiaLineas.MultiSelect = False
        Me.gvGuiaLineas.Name = "gvGuiaLineas"
        Me.gvGuiaLineas.ReadOnly = True
        Me.gvGuiaLineas.RowHeadersVisible = False
        Me.gvGuiaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.OldLace
        Me.gvGuiaLineas.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gvGuiaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvGuiaLineas.Size = New System.Drawing.Size(820, 238)
        Me.gvGuiaLineas.TabIndex = 28
        Me.gvGuiaLineas.TabStop = False
        '
        'LINEA
        '
        Me.LINEA.DataPropertyName = "LINEA"
        Me.LINEA.HeaderText = "LINEA"
        Me.LINEA.Name = "LINEA"
        Me.LINEA.ReadOnly = True
        Me.LINEA.Visible = False
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "CODIGO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 65
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 570
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle3
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 90
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.INDICA_SERIE.DefaultCellStyle = DataGridViewCellStyle4
        Me.INDICA_SERIE.HeaderText = "SERIE"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Width = 40
        '
        'EXISTE_RESUMEN_ALMACEN
        '
        Me.EXISTE_RESUMEN_ALMACEN.DataPropertyName = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.HeaderText = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.Name = "EXISTE_RESUMEN_ALMACEN"
        Me.EXISTE_RESUMEN_ALMACEN.ReadOnly = True
        Me.EXISTE_RESUMEN_ALMACEN.Visible = False
        '
        'EXISTE_RESUMEN_PERIODO
        '
        Me.EXISTE_RESUMEN_PERIODO.DataPropertyName = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.HeaderText = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.Name = "EXISTE_RESUMEN_PERIODO"
        Me.EXISTE_RESUMEN_PERIODO.ReadOnly = True
        Me.EXISTE_RESUMEN_PERIODO.Visible = False
        '
        'EXISTE_RESUMEN_PERIODO2
        '
        Me.EXISTE_RESUMEN_PERIODO2.DataPropertyName = "EXISTE_RESUMEN_PERIODO2"
        Me.EXISTE_RESUMEN_PERIODO2.HeaderText = "EXISTE_RESUMEN_PERIODO2"
        Me.EXISTE_RESUMEN_PERIODO2.Name = "EXISTE_RESUMEN_PERIODO2"
        Me.EXISTE_RESUMEN_PERIODO2.ReadOnly = True
        Me.EXISTE_RESUMEN_PERIODO2.Visible = False
        '
        'ELIMINAR
        '
        Me.ELIMINAR.HeaderText = ""
        Me.ELIMINAR.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.ELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ELIMINAR.Name = "ELIMINAR"
        Me.ELIMINAR.ReadOnly = True
        Me.ELIMINAR.Width = 24
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(790, 281)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(42, 42)
        Me.btnNuevo.TabIndex = 29
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(607, 283)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 18)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "STOCK"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidadStock
        '
        Me.txtCantidadStock.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadStock.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadStock.Location = New System.Drawing.Point(607, 302)
        Me.txtCantidadStock.MaxLength = 10
        Me.txtCantidadStock.Name = "txtCantidadStock"
        Me.txtCantidadStock.ReadOnly = True
        Me.txtCantidadStock.Size = New System.Drawing.Size(70, 21)
        Me.txtCantidadStock.TabIndex = 33
        Me.txtCantidadStock.TabStop = False
        Me.txtCantidadStock.Tag = "Z"
        Me.txtCantidadStock.Text = "0"
        Me.txtCantidadStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(576, 32)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(26, 21)
        Me.txtEjercicio.TabIndex = 18
        Me.txtEjercicio.TabStop = False
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEjercicio.Visible = False
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.Color.Moccasin
        Me.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMes.Location = New System.Drawing.Point(603, 32)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(17, 21)
        Me.txtMes.TabIndex = 19
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.Location = New System.Drawing.Point(749, 281)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 27
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(678, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "CANTIDAD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(678, 302)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(70, 21)
        Me.txtCantidad.TabIndex = 26
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(12, 259)
        Me.txtComentario.MaxLength = 200
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(819, 21)
        Me.txtComentario.TabIndex = 8
        Me.txtComentario.TabStop = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(542, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(293, 20)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "GUIA POR TRASLADO A TERCEROS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(639, 37)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(192, 16)
        Me.ckbIndicaAnulado.TabIndex = 24
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(819, 18)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "PUNTO DE PARTIDA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.Enabled = False
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(12, 115)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(145, 21)
        Me.cmbAlmacen.TabIndex = 13
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.Enabled = False
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(1, 357)
        Me.txtLinea.MaxLength = 3
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.ReadOnly = True
        Me.txtLinea.Size = New System.Drawing.Size(8, 21)
        Me.txtLinea.TabIndex = 30
        Me.txtLinea.Tag = ""
        Me.txtLinea.Visible = False
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(333, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(203, 18)
        Me.Label33.TabIndex = 35
        Me.Label33.Text = "OPERACION"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacion
        '
        Me.txtOperacion.BackColor = System.Drawing.Color.Moccasin
        Me.txtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOperacion.Location = New System.Drawing.Point(333, 32)
        Me.txtOperacion.MaxLength = 8
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.ReadOnly = True
        Me.txtOperacion.Size = New System.Drawing.Size(98, 21)
        Me.txtOperacion.TabIndex = 15
        Me.txtOperacion.TabStop = False
        '
        'txtReferenciaCUO
        '
        Me.txtReferenciaCUO.BackColor = System.Drawing.Color.Moccasin
        Me.txtReferenciaCUO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenciaCUO.Enabled = False
        Me.txtReferenciaCUO.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenciaCUO.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReferenciaCUO.Location = New System.Drawing.Point(556, 32)
        Me.txtReferenciaCUO.MaxLength = 8
        Me.txtReferenciaCUO.Name = "txtReferenciaCUO"
        Me.txtReferenciaCUO.ReadOnly = True
        Me.txtReferenciaCUO.Size = New System.Drawing.Size(19, 21)
        Me.txtReferenciaCUO.TabIndex = 17
        Me.txtReferenciaCUO.TabStop = False
        Me.txtReferenciaCUO.Visible = False
        '
        'cmbDireccionEnvio
        '
        Me.cmbDireccionEnvio.BackColor = System.Drawing.Color.Azure
        Me.cmbDireccionEnvio.DisplayMember = "DESCRIPCION"
        Me.cmbDireccionEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDireccionEnvio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDireccionEnvio.FormattingEnabled = True
        Me.cmbDireccionEnvio.Location = New System.Drawing.Point(12, 156)
        Me.cmbDireccionEnvio.Name = "cmbDireccionEnvio"
        Me.cmbDireccionEnvio.Size = New System.Drawing.Size(145, 21)
        Me.cmbDireccionEnvio.TabIndex = 12
        Me.cmbDireccionEnvio.TabStop = False
        Me.cmbDireccionEnvio.ValueMember = "DOMICILIO_ENVIO"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(12, 137)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(819, 18)
        Me.Label43.TabIndex = 43
        Me.Label43.Text = "PUNTO DE LLEGADA"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPuntoLlegada
        '
        Me.txtPuntoLlegada.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPuntoLlegada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPuntoLlegada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPuntoLlegada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuntoLlegada.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPuntoLlegada.Location = New System.Drawing.Point(158, 156)
        Me.txtPuntoLlegada.MaxLength = 200
        Me.txtPuntoLlegada.Name = "txtPuntoLlegada"
        Me.txtPuntoLlegada.Size = New System.Drawing.Size(673, 21)
        Me.txtPuntoLlegada.TabIndex = 2
        Me.txtPuntoLlegada.TabStop = False
        '
        'txtPuntoPartida
        '
        Me.txtPuntoPartida.BackColor = System.Drawing.Color.Moccasin
        Me.txtPuntoPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPuntoPartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPuntoPartida.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuntoPartida.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPuntoPartida.Location = New System.Drawing.Point(158, 115)
        Me.txtPuntoPartida.MaxLength = 200
        Me.txtPuntoPartida.Name = "txtPuntoPartida"
        Me.txtPuntoPartida.ReadOnly = True
        Me.txtPuntoPartida.Size = New System.Drawing.Size(673, 21)
        Me.txtPuntoPartida.TabIndex = 14
        Me.txtPuntoPartida.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(458, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "RUC "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransportistaRazonSocial
        '
        Me.txtTransportistaRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtTransportistaRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransportistaRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransportistaRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransportistaRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTransportistaRazonSocial.Location = New System.Drawing.Point(531, 216)
        Me.txtTransportistaRazonSocial.MaxLength = 100
        Me.txtTransportistaRazonSocial.Name = "txtTransportistaRazonSocial"
        Me.txtTransportistaRazonSocial.ReadOnly = True
        Me.txtTransportistaRazonSocial.Size = New System.Drawing.Size(300, 21)
        Me.txtTransportistaRazonSocial.TabIndex = 6
        Me.txtTransportistaRazonSocial.TabStop = False
        '
        'txtTransportistaRUC
        '
        Me.txtTransportistaRUC.BackColor = System.Drawing.Color.Moccasin
        Me.txtTransportistaRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransportistaRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransportistaRUC.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransportistaRUC.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTransportistaRUC.Location = New System.Drawing.Point(458, 216)
        Me.txtTransportistaRUC.MaxLength = 11
        Me.txtTransportistaRUC.Name = "txtTransportistaRUC"
        Me.txtTransportistaRUC.ReadOnly = True
        Me.txtTransportistaRUC.Size = New System.Drawing.Size(72, 21)
        Me.txtTransportistaRUC.TabIndex = 5
        Me.txtTransportistaRUC.TabStop = False
        Me.txtTransportistaRUC.Tag = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(12, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "DNI"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConductorNombre
        '
        Me.txtConductorNombre.BackColor = System.Drawing.Color.AliceBlue
        Me.txtConductorNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductorNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConductorNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConductorNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtConductorNombre.Location = New System.Drawing.Point(65, 216)
        Me.txtConductorNombre.MaxLength = 100
        Me.txtConductorNombre.Name = "txtConductorNombre"
        Me.txtConductorNombre.Size = New System.Drawing.Size(309, 21)
        Me.txtConductorNombre.TabIndex = 4
        Me.txtConductorNombre.TabStop = False
        '
        'txtConductorDNI
        '
        Me.txtConductorDNI.BackColor = System.Drawing.Color.AliceBlue
        Me.txtConductorDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductorDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConductorDNI.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConductorDNI.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtConductorDNI.Location = New System.Drawing.Point(12, 216)
        Me.txtConductorDNI.MaxLength = 8
        Me.txtConductorDNI.Name = "txtConductorDNI"
        Me.txtConductorDNI.Size = New System.Drawing.Size(52, 21)
        Me.txtConductorDNI.TabIndex = 3
        Me.txtConductorDNI.Tag = ""
        '
        'txtComprobanteFechaTraslado
        '
        Me.txtComprobanteFechaTraslado.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFechaTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFechaTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFechaTraslado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFechaTraslado.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFechaTraslado.Location = New System.Drawing.Point(237, 32)
        Me.txtComprobanteFechaTraslado.MaxLength = 10
        Me.txtComprobanteFechaTraslado.Name = "txtComprobanteFechaTraslado"
        Me.txtComprobanteFechaTraslado.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFechaTraslado.TabIndex = 10
        Me.txtComprobanteFechaTraslado.TabStop = False
        Me.txtComprobanteFechaTraslado.Tag = "F"
        Me.txtComprobanteFechaTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(237, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 18)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "F. TRASLADO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(375, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 16)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "NRO. PLACA"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroPlaca
        '
        Me.txtNumeroPlaca.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroPlaca.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroPlaca.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroPlaca.Location = New System.Drawing.Point(375, 216)
        Me.txtNumeroPlaca.MaxLength = 7
        Me.txtNumeroPlaca.Name = "txtNumeroPlaca"
        Me.txtNumeroPlaca.Size = New System.Drawing.Size(82, 21)
        Me.txtNumeroPlaca.TabIndex = 7
        Me.txtNumeroPlaca.TabStop = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Location = New System.Drawing.Point(65, 199)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(309, 16)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "NOMBRE DEL CONDUCTOR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(531, 199)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(300, 16)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "RAZON SOCIAL DEL TRANSPORTISTA"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obtIndicaTransportePrivado
        '
        Me.obtIndicaTransportePrivado.BackColor = System.Drawing.Color.SteelBlue
        Me.obtIndicaTransportePrivado.Checked = True
        Me.obtIndicaTransportePrivado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.obtIndicaTransportePrivado.ForeColor = System.Drawing.Color.White
        Me.obtIndicaTransportePrivado.Location = New System.Drawing.Point(11, 180)
        Me.obtIndicaTransportePrivado.Name = "obtIndicaTransportePrivado"
        Me.obtIndicaTransportePrivado.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.obtIndicaTransportePrivado.Size = New System.Drawing.Size(446, 18)
        Me.obtIndicaTransportePrivado.TabIndex = 53
        Me.obtIndicaTransportePrivado.TabStop = True
        Me.obtIndicaTransportePrivado.Text = "ENVIO POR TRANSPORTE PRIVADO"
        Me.obtIndicaTransportePrivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.obtIndicaTransportePrivado.UseVisualStyleBackColor = False
        '
        'obtIndicaTransportePublico
        '
        Me.obtIndicaTransportePublico.BackColor = System.Drawing.Color.SteelBlue
        Me.obtIndicaTransportePublico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.obtIndicaTransportePublico.ForeColor = System.Drawing.Color.White
        Me.obtIndicaTransportePublico.Location = New System.Drawing.Point(458, 180)
        Me.obtIndicaTransportePublico.Name = "obtIndicaTransportePublico"
        Me.obtIndicaTransportePublico.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.obtIndicaTransportePublico.Size = New System.Drawing.Size(373, 18)
        Me.obtIndicaTransportePublico.TabIndex = 54
        Me.obtIndicaTransportePublico.Text = "ENVIO POR TRANSPORTE PUBLICO"
        Me.obtIndicaTransportePublico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.obtIndicaTransportePublico.UseVisualStyleBackColor = False
        '
        'frmGuiaPorTraslado
        '
        Me.ClientSize = New System.Drawing.Size(846, 630)
        Me.Name = "frmGuiaPorTraslado"
        Me.Text = "GUIA POR TRASLADO A TERCEROS"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvGuiaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteSerie As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gvGuiaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadStock As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtOperacion As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenciaCUO As System.Windows.Forms.TextBox
    Friend WithEvents cmbDireccionEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFechaTraslado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConductorNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtConductorDNI As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTransportistaRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtTransportistaRUC As System.Windows.Forms.TextBox
    Friend WithEvents txtPuntoPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtPuntoLlegada As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents obtIndicaTransportePublico As System.Windows.Forms.RadioButton
    Friend WithEvents obtIndicaTransportePrivado As System.Windows.Forms.RadioButton

End Class
