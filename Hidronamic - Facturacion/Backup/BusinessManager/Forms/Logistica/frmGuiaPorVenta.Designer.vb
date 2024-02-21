<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaPorVenta
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaPorVenta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtComprobanteVentaNumero = New System.Windows.Forms.TextBox
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox
        Me.txtVenta = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cmbCentroDistribucion = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbAlmacenOrigen = New System.Windows.Forms.ComboBox
        Me.lblComprobante = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtDestinatarioNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbComprobanteVentaTipo = New System.Windows.Forms.ComboBox
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtComprobanteVentaFecha = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbAlmacenDestino = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtComprobanteFechaTraslado = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDestinatarioDomicilio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbTransportista = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbUnidadTransporte = New System.Windows.Forms.ComboBox
        Me.txtGuia = New System.Windows.Forms.TextBox
        Me.txtEjercicio = New System.Windows.Forms.TextBox
        Me.txtMes = New System.Windows.Forms.TextBox
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtIndicaValidaStock = New System.Windows.Forms.TextBox
        Me.txtIndicaCompuesto = New System.Windows.Forms.TextBox
        Me.txtLinea = New System.Windows.Forms.TextBox
        Me.btnDescartar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtEditado = New System.Windows.Forms.TextBox
        Me.cmbProductos = New System.Windows.Forms.ComboBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.gvGuiaLineas = New System.Windows.Forms.DataGridView
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_VALIDA_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNumeroLote = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtComprobanteVentaSerie = New System.Windows.Forms.TextBox
        Me.Panel.SuspendLayout()
        CType(Me.gvGuiaLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(852, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.txtComprobanteVentaSerie)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.txtNumeroLote)
        Me.Panel.Controls.Add(Me.txtIndicaValidaStock)
        Me.Panel.Controls.Add(Me.txtIndicaCompuesto)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.btnDescartar)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.txtEditado)
        Me.Panel.Controls.Add(Me.cmbProductos)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.gvGuiaLineas)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.txtGuia)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbUnidadTransporte)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.cmbTransportista)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtDestinatarioDomicilio)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtComprobanteFechaTraslado)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.cmbAlmacenDestino)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtComprobanteVentaFecha)
        Me.Panel.Controls.Add(Me.Label36)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.cmbComprobanteVentaTipo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtDestinatarioNombre)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.cmbCentroDistribucion)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbAlmacenOrigen)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtComprobanteVentaNumero)
        Me.Panel.Size = New System.Drawing.Size(852, 651)
        Me.Panel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(204, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "NUMERO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteVentaNumero
        '
        Me.txtComprobanteVentaNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteVentaNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteVentaNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteVentaNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobanteVentaNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteVentaNumero.Location = New System.Drawing.Point(204, 31)
        Me.txtComprobanteVentaNumero.MaxLength = 8
        Me.txtComprobanteVentaNumero.Name = "txtComprobanteVentaNumero"
        Me.txtComprobanteVentaNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteVentaNumero.TabIndex = 0
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(577, 31)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 23
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(564, 31)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 75
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVenta.Visible = False
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Chocolate
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(618, 180)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(218, 18)
        Me.Label24.TabIndex = 50
        Me.Label24.Text = "CENTRO DE DISTRIBUCION"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCentroDistribucion
        '
        Me.cmbCentroDistribucion.BackColor = System.Drawing.Color.Azure
        Me.cmbCentroDistribucion.DisplayMember = "DESCRIPCION"
        Me.cmbCentroDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroDistribucion.Enabled = False
        Me.cmbCentroDistribucion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCentroDistribucion.FormattingEnabled = True
        Me.cmbCentroDistribucion.Location = New System.Drawing.Point(618, 199)
        Me.cmbCentroDistribucion.Name = "cmbCentroDistribucion"
        Me.cmbCentroDistribucion.Size = New System.Drawing.Size(218, 21)
        Me.cmbCentroDistribucion.TabIndex = 10
        Me.cmbCentroDistribucion.TabStop = False
        Me.cmbCentroDistribucion.ValueMember = "CODIGO"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Chocolate
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(12, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(243, 18)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "ALMACEN DE PARTIDA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacenOrigen
        '
        Me.cmbAlmacenOrigen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacenOrigen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacenOrigen.Enabled = False
        Me.cmbAlmacenOrigen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacenOrigen.FormattingEnabled = True
        Me.cmbAlmacenOrigen.Location = New System.Drawing.Point(12, 199)
        Me.cmbAlmacenOrigen.Name = "cmbAlmacenOrigen"
        Me.cmbAlmacenOrigen.Size = New System.Drawing.Size(243, 21)
        Me.cmbAlmacenOrigen.TabIndex = 8
        Me.cmbAlmacenOrigen.TabStop = False
        Me.cmbAlmacenOrigen.ValueMember = "CODIGO"
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.Maroon
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(547, 0)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(296, 20)
        Me.lblComprobante.TabIndex = 37
        Me.lblComprobante.Text = "GUIA DE REMISION POR VENTA"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Chocolate
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(12, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(313, 18)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "DESTINATARIO"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDestinatarioNombre
        '
        Me.txtDestinatarioNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtDestinatarioNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestinatarioNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestinatarioNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestinatarioNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDestinatarioNombre.Location = New System.Drawing.Point(12, 115)
        Me.txtDestinatarioNombre.MaxLength = 120
        Me.txtDestinatarioNombre.Name = "txtDestinatarioNombre"
        Me.txtDestinatarioNombre.ReadOnly = True
        Me.txtDestinatarioNombre.Size = New System.Drawing.Size(313, 21)
        Me.txtDestinatarioNombre.TabIndex = 26
        Me.txtDestinatarioNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Chocolate
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(12, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 18)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "TIPO COMPROBANTE"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteVentaTipo
        '
        Me.cmbComprobanteVentaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteVentaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteVentaTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteVentaTipo.DisplayMember = "CODIGO"
        Me.cmbComprobanteVentaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteVentaTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteVentaTipo.FormattingEnabled = True
        Me.cmbComprobanteVentaTipo.Items.AddRange(New Object() {"BOLETA DE VENTA", "FACTURA"})
        Me.cmbComprobanteVentaTipo.Location = New System.Drawing.Point(12, 31)
        Me.cmbComprobanteVentaTipo.Name = "cmbComprobanteVentaTipo"
        Me.cmbComprobanteVentaTipo.Size = New System.Drawing.Size(141, 21)
        Me.cmbComprobanteVentaTipo.TabIndex = 16
        Me.cmbComprobanteVentaTipo.ValueMember = "CODIGO"
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(630, 34)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(206, 18)
        Me.ckbIndicaAnulado.TabIndex = 19
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "GUIA DE REMISION ANULADA"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Chocolate
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(12, 138)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(824, 18)
        Me.Label36.TabIndex = 47
        Me.Label36.Text = "COMENTARIO"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(12, 157)
        Me.txtComentario.MaxLength = 150
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(824, 21)
        Me.txtComentario.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(290, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 18)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "FECHA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteVentaFecha
        '
        Me.txtComprobanteVentaFecha.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteVentaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteVentaFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteVentaFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteVentaFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteVentaFecha.Location = New System.Drawing.Point(290, 31)
        Me.txtComprobanteVentaFecha.MaxLength = 10
        Me.txtComprobanteVentaFecha.Name = "txtComprobanteVentaFecha"
        Me.txtComprobanteVentaFecha.ReadOnly = True
        Me.txtComprobanteVentaFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteVentaFecha.TabIndex = 18
        Me.txtComprobanteVentaFecha.TabStop = False
        Me.txtComprobanteVentaFecha.Tag = "F"
        Me.txtComprobanteVentaFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Chocolate
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(181, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Chocolate
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(95, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "NUMERO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Chocolate
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(45, 54)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(49, 18)
        Me.Label42.TabIndex = 39
        Me.Label42.Text = "SERIE"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFecha
        '
        Me.txtComprobanteFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(181, 73)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 2
        Me.txtComprobanteFecha.Tag = "F"
        Me.txtComprobanteFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteNumero
        '
        Me.txtComprobanteNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(95, 73)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 1
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(45, 73)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteSerie.TabIndex = 25
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Chocolate
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(257, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(243, 18)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "ALMACEN DE LLEGADA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacenDestino
        '
        Me.cmbAlmacenDestino.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacenDestino.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacenDestino.Enabled = False
        Me.cmbAlmacenDestino.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacenDestino.FormattingEnabled = True
        Me.cmbAlmacenDestino.Location = New System.Drawing.Point(257, 199)
        Me.cmbAlmacenDestino.Name = "cmbAlmacenDestino"
        Me.cmbAlmacenDestino.Size = New System.Drawing.Size(243, 21)
        Me.cmbAlmacenDestino.TabIndex = 9
        Me.cmbAlmacenDestino.TabStop = False
        Me.cmbAlmacenDestino.ValueMember = "CODIGO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Chocolate
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(273, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 18)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "F. TRASLADO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFechaTraslado
        '
        Me.txtComprobanteFechaTraslado.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFechaTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFechaTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFechaTraslado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFechaTraslado.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFechaTraslado.Location = New System.Drawing.Point(273, 73)
        Me.txtComprobanteFechaTraslado.MaxLength = 10
        Me.txtComprobanteFechaTraslado.Name = "txtComprobanteFechaTraslado"
        Me.txtComprobanteFechaTraslado.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFechaTraslado.TabIndex = 3
        Me.txtComprobanteFechaTraslado.Tag = "F"
        Me.txtComprobanteFechaTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Chocolate
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(326, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(510, 18)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "DOMICILIO DEL DESTINATARIO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDestinatarioDomicilio
        '
        Me.txtDestinatarioDomicilio.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDestinatarioDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestinatarioDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestinatarioDomicilio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestinatarioDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDestinatarioDomicilio.Location = New System.Drawing.Point(326, 115)
        Me.txtDestinatarioDomicilio.MaxLength = 150
        Me.txtDestinatarioDomicilio.Name = "txtDestinatarioDomicilio"
        Me.txtDestinatarioDomicilio.Size = New System.Drawing.Size(510, 21)
        Me.txtDestinatarioDomicilio.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Chocolate
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(366, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(292, 18)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "TRANSPORTISTA / CONDUCTOR"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTransportista
        '
        Me.cmbTransportista.BackColor = System.Drawing.Color.Azure
        Me.cmbTransportista.DisplayMember = "DESCRIPCION"
        Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransportista.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTransportista.FormattingEnabled = True
        Me.cmbTransportista.Location = New System.Drawing.Point(366, 73)
        Me.cmbTransportista.Name = "cmbTransportista"
        Me.cmbTransportista.Size = New System.Drawing.Size(292, 21)
        Me.cmbTransportista.TabIndex = 4
        Me.cmbTransportista.TabStop = False
        Me.cmbTransportista.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 40)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "G/R"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Chocolate
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(661, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(175, 18)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "UNIDAD TRANSPORTE"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnidadTransporte
        '
        Me.cmbUnidadTransporte.BackColor = System.Drawing.Color.Azure
        Me.cmbUnidadTransporte.DisplayMember = "DESCRIPCION"
        Me.cmbUnidadTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadTransporte.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbUnidadTransporte.FormattingEnabled = True
        Me.cmbUnidadTransporte.Location = New System.Drawing.Point(661, 73)
        Me.cmbUnidadTransporte.Name = "cmbUnidadTransporte"
        Me.cmbUnidadTransporte.Size = New System.Drawing.Size(175, 21)
        Me.cmbUnidadTransporte.TabIndex = 5
        Me.cmbUnidadTransporte.TabStop = False
        Me.cmbUnidadTransporte.ValueMember = "CODIGO"
        '
        'txtGuia
        '
        Me.txtGuia.BackColor = System.Drawing.Color.Moccasin
        Me.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGuia.Location = New System.Drawing.Point(551, 31)
        Me.txtGuia.MaxLength = 8
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(10, 21)
        Me.txtGuia.TabIndex = 22
        Me.txtGuia.TabStop = False
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGuia.Visible = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(492, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(32, 21)
        Me.txtEjercicio.TabIndex = 20
        Me.txtEjercicio.TabStop = False
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.Color.Moccasin
        Me.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMes.Location = New System.Drawing.Point(526, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 21
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ilBotones
        '
        Me.ilBotones.ImageStream = CType(resources.GetObject("ilBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ilBotones.Images.SetKeyName(0, "smallFail.gif")
        Me.ilBotones.Images.SetKeyName(1, "smallSuccess.gif")
        Me.ilBotones.Images.SetKeyName(2, "smallFail BW.gif")
        Me.ilBotones.Images.SetKeyName(3, "smallSuccess BW.gif")
        '
        'txtIndicaValidaStock
        '
        Me.txtIndicaValidaStock.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaValidaStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaValidaStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaValidaStock.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaValidaStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaValidaStock.Location = New System.Drawing.Point(1, 314)
        Me.txtIndicaValidaStock.MaxLength = 1
        Me.txtIndicaValidaStock.Name = "txtIndicaValidaStock"
        Me.txtIndicaValidaStock.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaValidaStock.TabIndex = 14
        Me.txtIndicaValidaStock.TabStop = False
        Me.txtIndicaValidaStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaValidaStock.Visible = False
        '
        'txtIndicaCompuesto
        '
        Me.txtIndicaCompuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaCompuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaCompuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaCompuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaCompuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaCompuesto.Location = New System.Drawing.Point(1, 289)
        Me.txtIndicaCompuesto.MaxLength = 1
        Me.txtIndicaCompuesto.Name = "txtIndicaCompuesto"
        Me.txtIndicaCompuesto.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaCompuesto.TabIndex = 29
        Me.txtIndicaCompuesto.TabStop = False
        Me.txtIndicaCompuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaCompuesto.Visible = False
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(1, 266)
        Me.txtLinea.MaxLength = 1
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(10, 21)
        Me.txtLinea.TabIndex = 28
        Me.txtLinea.TabStop = False
        Me.txtLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLinea.Visible = False
        '
        'btnDescartar
        '
        Me.btnDescartar.BackgroundImage = CType(resources.GetObject("btnDescartar.BackgroundImage"), System.Drawing.Image)
        Me.btnDescartar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDescartar.ImageIndex = 2
        Me.btnDescartar.ImageList = Me.ilBotones
        Me.btnDescartar.Location = New System.Drawing.Point(794, 246)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(42, 42)
        Me.btnDescartar.TabIndex = 15
        Me.btnDescartar.TabStop = False
        Me.btnDescartar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(751, 246)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'txtEditado
        '
        Me.txtEditado.BackColor = System.Drawing.Color.Moccasin
        Me.txtEditado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEditado.Location = New System.Drawing.Point(1, 243)
        Me.txtEditado.MaxLength = 1
        Me.txtEditado.Name = "txtEditado"
        Me.txtEditado.Size = New System.Drawing.Size(10, 21)
        Me.txtEditado.TabIndex = 27
        Me.txtEditado.TabStop = False
        Me.txtEditado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEditado.Visible = False
        '
        'cmbProductos
        '
        Me.cmbProductos.BackColor = System.Drawing.Color.Azure
        Me.cmbProductos.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductos.Enabled = False
        Me.cmbProductos.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(95, 266)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(460, 21)
        Me.cmbProductos.TabIndex = 31
        Me.cmbProductos.ValueMember = "PRODUCTO"
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 266)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(82, 21)
        Me.txtProducto.TabIndex = 11
        Me.txtProducto.Tag = ""
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
        Me.gvGuiaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.VENTA, Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.NUMERO_LOTE, Me.CANTIDAD, Me.INDICA_VALIDA_STOCK})
        Me.gvGuiaLineas.Enabled = False
        Me.gvGuiaLineas.EnableHeadersVisualStyles = False
        Me.gvGuiaLineas.Location = New System.Drawing.Point(12, 289)
        Me.gvGuiaLineas.MultiSelect = False
        Me.gvGuiaLineas.Name = "gvGuiaLineas"
        Me.gvGuiaLineas.ReadOnly = True
        Me.gvGuiaLineas.RowHeadersVisible = False
        Me.gvGuiaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.OldLace
        Me.gvGuiaLineas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gvGuiaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvGuiaLineas.Size = New System.Drawing.Size(824, 349)
        Me.gvGuiaLineas.TabIndex = 30
        Me.gvGuiaLineas.TabStop = False
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.Visible = False
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
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 70
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 570
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        Me.NUMERO_LOTE.HeaderText = "LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle3
        Me.CANTIDAD.HeaderText = "CANT."
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 60
        '
        'INDICA_VALIDA_STOCK
        '
        Me.INDICA_VALIDA_STOCK.DataPropertyName = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.HeaderText = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.Name = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.ReadOnly = True
        Me.INDICA_VALIDA_STOCK.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(12, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(824, 18)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "DETALLES DE LA GUIA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(665, 247)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 18)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "CANTIDAD"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(665, 266)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(81, 21)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.Location = New System.Drawing.Point(95, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(460, 18)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.Location = New System.Drawing.Point(12, 247)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 18)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "PRODUCTO"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(556, 247)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 18)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "NRO. LOTE"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroLote
        '
        Me.txtNumeroLote.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroLote.Enabled = False
        Me.txtNumeroLote.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroLote.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroLote.Location = New System.Drawing.Point(556, 266)
        Me.txtNumeroLote.MaxLength = 10
        Me.txtNumeroLote.Name = "txtNumeroLote"
        Me.txtNumeroLote.ReadOnly = True
        Me.txtNumeroLote.Size = New System.Drawing.Size(108, 21)
        Me.txtNumeroLote.TabIndex = 32
        Me.txtNumeroLote.TabStop = False
        Me.txtNumeroLote.Tag = ""
        Me.txtNumeroLote.Text = "0"
        Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Chocolate
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(154, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 18)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "SERIE"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteVentaSerie
        '
        Me.txtComprobanteVentaSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteVentaSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteVentaSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteVentaSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteVentaSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteVentaSerie.Location = New System.Drawing.Point(154, 31)
        Me.txtComprobanteVentaSerie.MaxLength = 4
        Me.txtComprobanteVentaSerie.Name = "txtComprobanteVentaSerie"
        Me.txtComprobanteVentaSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteVentaSerie.TabIndex = 17
        Me.txtComprobanteVentaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmGuiaPorVenta
        '
        Me.ClientSize = New System.Drawing.Size(852, 687)
        Me.Name = "frmGuiaPorVenta"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvGuiaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteVentaNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroDistribucion As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDestinatarioNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteVentaTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteVentaFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFechaTraslado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDestinatarioDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTransportista As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroLote As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaValidaStock As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaCompuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtEditado As System.Windows.Forms.TextBox
    Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents gvGuiaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteVentaSerie As System.Windows.Forms.TextBox
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VALIDA_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
