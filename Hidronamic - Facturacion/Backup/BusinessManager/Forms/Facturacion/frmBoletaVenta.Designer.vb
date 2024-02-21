<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoletaVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoletaVenta))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.lblComprobante = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.txtLinea = New System.Windows.Forms.TextBox
        Me.btnDescartar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtValorExportacionOrige = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtImporteInafectoOrigen = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtOtrosTributosOrigen = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtIGVOrigen = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtImporteTotalOrigen = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtImporteExoneradoOrigen = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtBaseImponibleGravadaOrigen = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cmbCentroDistribucion = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.txtComprobanteNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbComprobanteTipo = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox
        Me.txtComprobanteSerie = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtComprobanteVencimiento = New System.Windows.Forms.TextBox
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtEditado = New System.Windows.Forms.TextBox
        Me.cmbProductos = New System.Windows.Forms.ComboBox
        Me.txtVendedorNombre = New System.Windows.Forms.TextBox
        Me.txtEjercicio = New System.Windows.Forms.TextBox
        Me.txtMes = New System.Windows.Forms.TextBox
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.gvVentaLineas = New System.Windows.Forms.DataGridView
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRECIO_UNITARIO_ME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IMPORTE_TOTAL_ME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_COMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_VALIDA_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbCondicionPago = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPrecioTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmbListaPrecios = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtVendedorCodigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVenta = New System.Windows.Forms.TextBox
        Me.txtIndicaCompuesto = New System.Windows.Forms.TextBox
        Me.txtIndicaValidaStock = New System.Windows.Forms.TextBox
        Me.Panel.SuspendLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(920, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.txtIndicaValidaStock)
        Me.Panel.Controls.Add(Me.txtIndicaCompuesto)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Controls.Add(Me.Label36)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.txtLinea)
        Me.Panel.Controls.Add(Me.btnDescartar)
        Me.Panel.Controls.Add(Me.btnAceptar)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.txtValorExportacionOrige)
        Me.Panel.Controls.Add(Me.Label26)
        Me.Panel.Controls.Add(Me.txtImporteInafectoOrigen)
        Me.Panel.Controls.Add(Me.Label32)
        Me.Panel.Controls.Add(Me.txtOtrosTributosOrigen)
        Me.Panel.Controls.Add(Me.Label27)
        Me.Panel.Controls.Add(Me.txtIGVOrigen)
        Me.Panel.Controls.Add(Me.Label29)
        Me.Panel.Controls.Add(Me.txtImporteTotalOrigen)
        Me.Panel.Controls.Add(Me.Label30)
        Me.Panel.Controls.Add(Me.txtImporteExoneradoOrigen)
        Me.Panel.Controls.Add(Me.Label31)
        Me.Panel.Controls.Add(Me.txtBaseImponibleGravadaOrigen)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.cmbCentroDistribucion)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.txtComprobanteNombre)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.cmbComprobanteTipo)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.txtComprobanteSerie)
        Me.Panel.Controls.Add(Me.Label19)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.txtComprobanteVencimiento)
        Me.Panel.Controls.Add(Me.txtCuentaComercial)
        Me.Panel.Controls.Add(Me.cmbDocumentoTipo)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txtTipoCambio)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtDocumentoNumero)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.txtEditado)
        Me.Panel.Controls.Add(Me.cmbProductos)
        Me.Panel.Controls.Add(Me.txtVendedorNombre)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.gvVentaLineas)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbCondicionPago)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtPrecioTotal)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtCantidad)
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.Label28)
        Me.Panel.Controls.Add(Me.cmbListaPrecios)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.txtVendedorCodigo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Size = New System.Drawing.Size(920, 651)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
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
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.Maroon
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(564, 2)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(351, 20)
        Me.lblComprobante.TabIndex = 43
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Chocolate
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(12, 222)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(894, 18)
        Me.Label36.TabIndex = 63
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
        Me.txtComentario.Location = New System.Drawing.Point(12, 241)
        Me.txtComentario.MaxLength = 150
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(894, 21)
        Me.txtComentario.TabIndex = 9
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtLinea.Location = New System.Drawing.Point(1, 307)
        Me.txtLinea.MaxLength = 1
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(10, 21)
        Me.txtLinea.TabIndex = 39
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
        Me.btnDescartar.Location = New System.Drawing.Point(866, 287)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(40, 40)
        Me.btnDescartar.TabIndex = 34
        Me.btnDescartar.TabStop = False
        Me.btnDescartar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(825, 288)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(40, 40)
        Me.btnAceptar.TabIndex = 33
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Chocolate
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(441, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 18)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "VAL. EXPORT."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label25.Visible = False
        '
        'txtValorExportacionOrige
        '
        Me.txtValorExportacionOrige.BackColor = System.Drawing.Color.Moccasin
        Me.txtValorExportacionOrige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorExportacionOrige.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtValorExportacionOrige.ForeColor = System.Drawing.Color.DarkRed
        Me.txtValorExportacionOrige.Location = New System.Drawing.Point(441, 199)
        Me.txtValorExportacionOrige.MaxLength = 14
        Me.txtValorExportacionOrige.Name = "txtValorExportacionOrige"
        Me.txtValorExportacionOrige.ReadOnly = True
        Me.txtValorExportacionOrige.Size = New System.Drawing.Size(84, 21)
        Me.txtValorExportacionOrige.TabIndex = 20
        Me.txtValorExportacionOrige.TabStop = False
        Me.txtValorExportacionOrige.Tag = "D"
        Me.txtValorExportacionOrige.Text = "0.00"
        Me.txtValorExportacionOrige.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValorExportacionOrige.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Chocolate
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(356, 180)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 18)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = "VAL. INAFEC."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label26.Visible = False
        '
        'txtImporteInafectoOrigen
        '
        Me.txtImporteInafectoOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteInafectoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteInafectoOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteInafectoOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteInafectoOrigen.Location = New System.Drawing.Point(356, 199)
        Me.txtImporteInafectoOrigen.MaxLength = 14
        Me.txtImporteInafectoOrigen.Name = "txtImporteInafectoOrigen"
        Me.txtImporteInafectoOrigen.ReadOnly = True
        Me.txtImporteInafectoOrigen.Size = New System.Drawing.Size(84, 21)
        Me.txtImporteInafectoOrigen.TabIndex = 19
        Me.txtImporteInafectoOrigen.TabStop = False
        Me.txtImporteInafectoOrigen.Tag = "D"
        Me.txtImporteInafectoOrigen.Text = "0.00"
        Me.txtImporteInafectoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteInafectoOrigen.Visible = False
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Chocolate
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(526, 180)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 18)
        Me.Label32.TabIndex = 59
        Me.Label32.Text = "OTROS TRIB."
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label32.Visible = False
        '
        'txtOtrosTributosOrigen
        '
        Me.txtOtrosTributosOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtOtrosTributosOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtrosTributosOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtOtrosTributosOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOtrosTributosOrigen.Location = New System.Drawing.Point(526, 199)
        Me.txtOtrosTributosOrigen.MaxLength = 14
        Me.txtOtrosTributosOrigen.Name = "txtOtrosTributosOrigen"
        Me.txtOtrosTributosOrigen.ReadOnly = True
        Me.txtOtrosTributosOrigen.Size = New System.Drawing.Size(84, 21)
        Me.txtOtrosTributosOrigen.TabIndex = 21
        Me.txtOtrosTributosOrigen.TabStop = False
        Me.txtOtrosTributosOrigen.Tag = "D"
        Me.txtOtrosTributosOrigen.Text = "0.00"
        Me.txtOtrosTributosOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOtrosTributosOrigen.Visible = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Chocolate
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(708, 180)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(94, 18)
        Me.Label27.TabIndex = 61
        Me.Label27.Text = "IGV"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIGVOrigen
        '
        Me.txtIGVOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtIGVOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIGVOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtIGVOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIGVOrigen.Location = New System.Drawing.Point(708, 199)
        Me.txtIGVOrigen.MaxLength = 14
        Me.txtIGVOrigen.Name = "txtIGVOrigen"
        Me.txtIGVOrigen.ReadOnly = True
        Me.txtIGVOrigen.Size = New System.Drawing.Size(94, 21)
        Me.txtIGVOrigen.TabIndex = 23
        Me.txtIGVOrigen.TabStop = False
        Me.txtIGVOrigen.Tag = "D"
        Me.txtIGVOrigen.Text = "0.00"
        Me.txtIGVOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Chocolate
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(803, 180)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 18)
        Me.Label29.TabIndex = 62
        Me.Label29.Text = "PRECIO VENTA"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImporteTotalOrigen
        '
        Me.txtImporteTotalOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteTotalOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteTotalOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteTotalOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteTotalOrigen.Location = New System.Drawing.Point(803, 199)
        Me.txtImporteTotalOrigen.MaxLength = 14
        Me.txtImporteTotalOrigen.Name = "txtImporteTotalOrigen"
        Me.txtImporteTotalOrigen.ReadOnly = True
        Me.txtImporteTotalOrigen.Size = New System.Drawing.Size(103, 21)
        Me.txtImporteTotalOrigen.TabIndex = 24
        Me.txtImporteTotalOrigen.TabStop = False
        Me.txtImporteTotalOrigen.Tag = "D"
        Me.txtImporteTotalOrigen.Text = "0.00"
        Me.txtImporteTotalOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Chocolate
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(271, 180)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(84, 18)
        Me.Label30.TabIndex = 56
        Me.Label30.Text = "VAL. EXONER."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label30.Visible = False
        '
        'txtImporteExoneradoOrigen
        '
        Me.txtImporteExoneradoOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtImporteExoneradoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteExoneradoOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtImporteExoneradoOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtImporteExoneradoOrigen.Location = New System.Drawing.Point(271, 199)
        Me.txtImporteExoneradoOrigen.MaxLength = 14
        Me.txtImporteExoneradoOrigen.Name = "txtImporteExoneradoOrigen"
        Me.txtImporteExoneradoOrigen.ReadOnly = True
        Me.txtImporteExoneradoOrigen.Size = New System.Drawing.Size(84, 21)
        Me.txtImporteExoneradoOrigen.TabIndex = 18
        Me.txtImporteExoneradoOrigen.TabStop = False
        Me.txtImporteExoneradoOrigen.Tag = "D"
        Me.txtImporteExoneradoOrigen.Text = "0.00"
        Me.txtImporteExoneradoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteExoneradoOrigen.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Chocolate
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(613, 180)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(94, 18)
        Me.Label31.TabIndex = 60
        Me.Label31.Text = "VALOR VENTA"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBaseImponibleGravadaOrigen
        '
        Me.txtBaseImponibleGravadaOrigen.BackColor = System.Drawing.Color.Moccasin
        Me.txtBaseImponibleGravadaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseImponibleGravadaOrigen.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtBaseImponibleGravadaOrigen.ForeColor = System.Drawing.Color.DarkRed
        Me.txtBaseImponibleGravadaOrigen.Location = New System.Drawing.Point(613, 199)
        Me.txtBaseImponibleGravadaOrigen.MaxLength = 14
        Me.txtBaseImponibleGravadaOrigen.Name = "txtBaseImponibleGravadaOrigen"
        Me.txtBaseImponibleGravadaOrigen.ReadOnly = True
        Me.txtBaseImponibleGravadaOrigen.Size = New System.Drawing.Size(94, 21)
        Me.txtBaseImponibleGravadaOrigen.TabIndex = 22
        Me.txtBaseImponibleGravadaOrigen.TabStop = False
        Me.txtBaseImponibleGravadaOrigen.Tag = "D"
        Me.txtBaseImponibleGravadaOrigen.Text = "0.00"
        Me.txtBaseImponibleGravadaOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Chocolate
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(256, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(218, 18)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "CENTRO DE DISTRIBUCION"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCentroDistribucion
        '
        Me.cmbCentroDistribucion.BackColor = System.Drawing.Color.Azure
        Me.cmbCentroDistribucion.DisplayMember = "DESCRIPCION"
        Me.cmbCentroDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroDistribucion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCentroDistribucion.FormattingEnabled = True
        Me.cmbCentroDistribucion.Location = New System.Drawing.Point(256, 31)
        Me.cmbCentroDistribucion.Name = "cmbCentroDistribucion"
        Me.cmbCentroDistribucion.Size = New System.Drawing.Size(218, 21)
        Me.cmbCentroDistribucion.TabIndex = 11
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
        Me.Label18.Location = New System.Drawing.Point(12, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(243, 18)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "ALMACEN"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(12, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(243, 21)
        Me.cmbAlmacen.TabIndex = 10
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'txtComprobanteNombre
        '
        Me.txtComprobanteNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteNombre.Location = New System.Drawing.Point(54, 157)
        Me.txtComprobanteNombre.MaxLength = 80
        Me.txtComprobanteNombre.Name = "txtComprobanteNombre"
        Me.txtComprobanteNombre.ReadOnly = True
        Me.txtComprobanteNombre.Size = New System.Drawing.Size(199, 21)
        Me.txtComprobanteNombre.TabIndex = 17
        Me.txtComprobanteNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Chocolate
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(12, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(241, 18)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "TIPO DOCUMENTO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComprobanteTipo
        '
        Me.cmbComprobanteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbComprobanteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprobanteTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteTipo.DisplayMember = "TEXTO_01"
        Me.cmbComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteTipo.Enabled = False
        Me.cmbComprobanteTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteTipo.FormattingEnabled = True
        Me.cmbComprobanteTipo.Location = New System.Drawing.Point(12, 157)
        Me.cmbComprobanteTipo.Name = "cmbComprobanteTipo"
        Me.cmbComprobanteTipo.Size = New System.Drawing.Size(41, 21)
        Me.cmbComprobanteTipo.TabIndex = 16
        Me.cmbComprobanteTipo.ValueMember = "CODIGO_ITEM"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Chocolate
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(390, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 51
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
        Me.Label17.Location = New System.Drawing.Point(304, 138)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 18)
        Me.Label17.TabIndex = 50
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
        Me.Label42.Location = New System.Drawing.Point(254, 138)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(49, 18)
        Me.Label42.TabIndex = 49
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
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(390, 157)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteFecha.TabIndex = 4
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(304, 157)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(85, 21)
        Me.txtComprobanteNumero.TabIndex = 3
        Me.txtComprobanteNumero.TabStop = False
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprobanteSerie
        '
        Me.txtComprobanteSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteSerie.Location = New System.Drawing.Point(254, 157)
        Me.txtComprobanteSerie.MaxLength = 4
        Me.txtComprobanteSerie.Name = "txtComprobanteSerie"
        Me.txtComprobanteSerie.Size = New System.Drawing.Size(49, 21)
        Me.txtComprobanteSerie.TabIndex = 2
        Me.txtComprobanteSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Chocolate
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(575, 138)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(156, 18)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "MONEDA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(575, 157)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cmbTipoMoneda.TabIndex = 6
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Chocolate
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(482, 138)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 18)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "F. VCMTO."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteVencimiento
        '
        Me.txtComprobanteVencimiento.BackColor = System.Drawing.Color.Moccasin
        Me.txtComprobanteVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteVencimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteVencimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteVencimiento.ForeColor = System.Drawing.Color.DarkRed
        Me.txtComprobanteVencimiento.Location = New System.Drawing.Point(482, 157)
        Me.txtComprobanteVencimiento.MaxLength = 10
        Me.txtComprobanteVencimiento.Name = "txtComprobanteVencimiento"
        Me.txtComprobanteVencimiento.ReadOnly = True
        Me.txtComprobanteVencimiento.Size = New System.Drawing.Size(91, 21)
        Me.txtComprobanteVencimiento.TabIndex = 5
        Me.txtComprobanteVencimiento.TabStop = False
        Me.txtComprobanteVencimiento.Tag = "F"
        Me.txtComprobanteVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(620, 31)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 28
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'cmbDocumentoTipo
        '
        Me.cmbDocumentoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbDocumentoTipo.DisplayMember = "NOMBRE_LARGO"
        Me.cmbDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDocumentoTipo.FormattingEnabled = True
        Me.cmbDocumentoTipo.Location = New System.Drawing.Point(12, 73)
        Me.cmbDocumentoTipo.Name = "cmbDocumentoTipo"
        Me.cmbDocumentoTipo.Size = New System.Drawing.Size(56, 21)
        Me.cmbDocumentoTipo.TabIndex = 13
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO_ITEM"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Chocolate
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(476, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 18)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "T. CAMBIO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.Moccasin
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTipoCambio.Location = New System.Drawing.Point(476, 31)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 21)
        Me.txtTipoCambio.TabIndex = 12
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Chocolate
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(184, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(722, 18)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "RAZON SOCIAL"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(184, 73)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(722, 21)
        Me.txtRazonSocial.TabIndex = 14
        Me.txtRazonSocial.TabStop = False
        '
        'txtDocumentoNumero
        '
        Me.txtDocumentoNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDocumentoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoNumero.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentoNumero.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDocumentoNumero.Location = New System.Drawing.Point(69, 73)
        Me.txtDocumentoNumero.MaxLength = 18
        Me.txtDocumentoNumero.Name = "txtDocumentoNumero"
        Me.txtDocumentoNumero.Size = New System.Drawing.Size(114, 21)
        Me.txtDocumentoNumero.TabIndex = 0
        Me.txtDocumentoNumero.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Chocolate
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(12, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 18)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "DOCUMENTO IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditado
        '
        Me.txtEditado.BackColor = System.Drawing.Color.Moccasin
        Me.txtEditado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEditado.Location = New System.Drawing.Point(1, 284)
        Me.txtEditado.MaxLength = 1
        Me.txtEditado.Name = "txtEditado"
        Me.txtEditado.Size = New System.Drawing.Size(10, 21)
        Me.txtEditado.TabIndex = 38
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
        Me.cmbProductos.Location = New System.Drawing.Point(95, 307)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(460, 21)
        Me.cmbProductos.TabIndex = 31
        Me.cmbProductos.ValueMember = "PRODUCTO"
        '
        'txtVendedorNombre
        '
        Me.txtVendedorNombre.BackColor = System.Drawing.Color.Moccasin
        Me.txtVendedorNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendedorNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedorNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendedorNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVendedorNombre.Location = New System.Drawing.Point(101, 115)
        Me.txtVendedorNombre.MaxLength = 120
        Me.txtVendedorNombre.Name = "txtVendedorNombre"
        Me.txtVendedorNombre.ReadOnly = True
        Me.txtVendedorNombre.Size = New System.Drawing.Size(805, 21)
        Me.txtVendedorNombre.TabIndex = 15
        Me.txtVendedorNombre.TabStop = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(564, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(32, 21)
        Me.txtEjercicio.TabIndex = 26
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
        Me.txtMes.Location = New System.Drawing.Point(598, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 27
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(700, 34)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(206, 18)
        Me.ckbIndicaAnulado.TabIndex = 29
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "COMPROBANTE ANULADO"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 307)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(82, 21)
        Me.txtProducto.TabIndex = 30
        Me.txtProducto.Tag = ""
        '
        'gvVentaLineas
        '
        Me.gvVentaLineas.AllowUserToAddRows = False
        Me.gvVentaLineas.AllowUserToDeleteRows = False
        Me.gvVentaLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvVentaLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvVentaLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gvVentaLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVentaLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.VENTA, Me.LINEA, Me.PRODUCTO, Me.DESCRIPCION_AMPLIADA, Me.CANTIDAD, Me.PRECIO_UNITARIO_ME, Me.IMPORTE_TOTAL_ME, Me.NUMERO_LOTE, Me.INDICA_COMPUESTO, Me.INDICA_VALIDA_STOCK})
        Me.gvVentaLineas.Enabled = False
        Me.gvVentaLineas.EnableHeadersVisualStyles = False
        Me.gvVentaLineas.Location = New System.Drawing.Point(12, 330)
        Me.gvVentaLineas.MultiSelect = False
        Me.gvVentaLineas.Name = "gvVentaLineas"
        Me.gvVentaLineas.ReadOnly = True
        Me.gvVentaLineas.RowHeadersVisible = False
        Me.gvVentaLineas.RowHeadersWidth = 13
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.OldLace
        Me.gvVentaLineas.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gvVentaLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVentaLineas.Size = New System.Drawing.Size(894, 314)
        Me.gvVentaLineas.TabIndex = 35
        Me.gvVentaLineas.TabStop = False
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
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.CANTIDAD.DefaultCellStyle = DataGridViewCellStyle9
        Me.CANTIDAD.HeaderText = "CANT."
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 55
        '
        'PRECIO_UNITARIO_ME
        '
        Me.PRECIO_UNITARIO_ME.DataPropertyName = "PRECIO_UNITARIO_ME"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.PRECIO_UNITARIO_ME.DefaultCellStyle = DataGridViewCellStyle10
        Me.PRECIO_UNITARIO_ME.HeaderText = "P.  UNIT."
        Me.PRECIO_UNITARIO_ME.MinimumWidth = 80
        Me.PRECIO_UNITARIO_ME.Name = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.ReadOnly = True
        Me.PRECIO_UNITARIO_ME.Width = 90
        '
        'IMPORTE_TOTAL_ME
        '
        Me.IMPORTE_TOTAL_ME.DataPropertyName = "IMPORTE_TOTAL_ME"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.IMPORTE_TOTAL_ME.DefaultCellStyle = DataGridViewCellStyle11
        Me.IMPORTE_TOTAL_ME.HeaderText = "P. TOTAL"
        Me.IMPORTE_TOTAL_ME.MinimumWidth = 90
        Me.IMPORTE_TOTAL_ME.Name = "IMPORTE_TOTAL_ME"
        Me.IMPORTE_TOTAL_ME.ReadOnly = True
        Me.IMPORTE_TOTAL_ME.Width = 90
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        Me.NUMERO_LOTE.HeaderText = "LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        Me.NUMERO_LOTE.Visible = False
        '
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.HeaderText = "ES_COMPUESTO"
        Me.INDICA_COMPUESTO.Name = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.ReadOnly = True
        Me.INDICA_COMPUESTO.Visible = False
        '
        'INDICA_VALIDA_STOCK
        '
        Me.INDICA_VALIDA_STOCK.DataPropertyName = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.HeaderText = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.Name = "INDICA_VALIDA_STOCK"
        Me.INDICA_VALIDA_STOCK.ReadOnly = True
        Me.INDICA_VALIDA_STOCK.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Chocolate
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(12, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(256, 18)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "MODALIDAD DE PAGO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCondicionPago
        '
        Me.cmbCondicionPago.BackColor = System.Drawing.Color.Azure
        Me.cmbCondicionPago.DisplayMember = "DESCRIPCION"
        Me.cmbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionPago.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCondicionPago.FormattingEnabled = True
        Me.cmbCondicionPago.Location = New System.Drawing.Point(12, 199)
        Me.cmbCondicionPago.Name = "cmbCondicionPago"
        Me.cmbCondicionPago.Size = New System.Drawing.Size(256, 21)
        Me.cmbCondicionPago.TabIndex = 8
        Me.cmbCondicionPago.ValueMember = "CODIGO"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(12, 269)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(894, 18)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "DETALLES DE LA VENTA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(729, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "P. TOTAL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioTotal
        '
        Me.txtPrecioTotal.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrecioTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioTotal.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrecioTotal.Location = New System.Drawing.Point(729, 307)
        Me.txtPrecioTotal.MaxLength = 10
        Me.txtPrecioTotal.Name = "txtPrecioTotal"
        Me.txtPrecioTotal.ReadOnly = True
        Me.txtPrecioTotal.Size = New System.Drawing.Size(90, 21)
        Me.txtPrecioTotal.TabIndex = 37
        Me.txtPrecioTotal.TabStop = False
        Me.txtPrecioTotal.Tag = "D"
        Me.txtPrecioTotal.Text = "0.00"
        Me.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(556, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 18)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "CANTIDAD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCantidad.Location = New System.Drawing.Point(556, 307)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(81, 21)
        Me.txtCantidad.TabIndex = 32
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(638, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 18)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "P. UNITARIO"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.Moccasin
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(638, 307)
        Me.txtPrecioUnitario.MaxLength = 10
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.ReadOnly = True
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(90, 21)
        Me.txtPrecioUnitario.TabIndex = 36
        Me.txtPrecioUnitario.TabStop = False
        Me.txtPrecioUnitario.Tag = "D"
        Me.txtPrecioUnitario.Text = "0.00"
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(95, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(460, 18)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 18)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "PRODUCTO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Chocolate
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(732, 138)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(174, 18)
        Me.Label28.TabIndex = 54
        Me.Label28.Text = "LISTA DE PRECIOS"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BackColor = System.Drawing.Color.Azure
        Me.cmbListaPrecios.DisplayMember = "DESCRIPCION"
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.Location = New System.Drawing.Point(732, 157)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(174, 21)
        Me.cmbListaPrecios.TabIndex = 7
        Me.cmbListaPrecios.TabStop = False
        Me.cmbListaPrecios.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(101, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(805, 18)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "NOMBRE DEL CONSULTOR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendedorCodigo
        '
        Me.txtVendedorCodigo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtVendedorCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendedorCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedorCodigo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendedorCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtVendedorCodigo.Location = New System.Drawing.Point(12, 115)
        Me.txtVendedorCodigo.MaxLength = 7
        Me.txtVendedorCodigo.Name = "txtVendedorCodigo"
        Me.txtVendedorCodigo.Size = New System.Drawing.Size(88, 21)
        Me.txtVendedorCodigo.TabIndex = 1
        Me.txtVendedorCodigo.Tag = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 18)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "CODIGO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(632, 31)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 25
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVenta.Visible = False
        '
        'txtIndicaCompuesto
        '
        Me.txtIndicaCompuesto.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaCompuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaCompuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaCompuesto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaCompuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaCompuesto.Location = New System.Drawing.Point(1, 330)
        Me.txtIndicaCompuesto.MaxLength = 1
        Me.txtIndicaCompuesto.Name = "txtIndicaCompuesto"
        Me.txtIndicaCompuesto.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaCompuesto.TabIndex = 70
        Me.txtIndicaCompuesto.TabStop = False
        Me.txtIndicaCompuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaCompuesto.Visible = False
        '
        'txtIndicaValidaStock
        '
        Me.txtIndicaValidaStock.BackColor = System.Drawing.Color.Moccasin
        Me.txtIndicaValidaStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIndicaValidaStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaValidaStock.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicaValidaStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIndicaValidaStock.Location = New System.Drawing.Point(1, 355)
        Me.txtIndicaValidaStock.MaxLength = 1
        Me.txtIndicaValidaStock.Name = "txtIndicaValidaStock"
        Me.txtIndicaValidaStock.Size = New System.Drawing.Size(10, 21)
        Me.txtIndicaValidaStock.TabIndex = 71
        Me.txtIndicaValidaStock.TabStop = False
        Me.txtIndicaValidaStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIndicaValidaStock.Visible = False
        '
        'frmBoletaVenta
        '
        Me.ClientSize = New System.Drawing.Size(920, 687)
        Me.Name = "frmBoletaVenta"
        Me.Text = " BV POR VENTA MOSTRADOR"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvVentaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtValorExportacionOrige As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtImporteInafectoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtOtrosTributosOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtIGVOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotalOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtImporteExoneradoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBaseImponibleGravadaOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroDistribucion As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents txtComprobanteNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEditado As System.Windows.Forms.TextBox
    Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents txtVendedorNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents gvVentaLineas As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbListaPrecios As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVendedorCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaCompuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtIndicaValidaStock As System.Windows.Forms.TextBox
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE_TOTAL_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_COMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VALIDA_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
