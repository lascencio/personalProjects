﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaPorVentaVehiculo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaPorVentaVehiculo))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtComprobanteFecha = New System.Windows.Forms.TextBox()
        Me.txtComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtComprobanteFechaTraslado = New System.Windows.Forms.TextBox()
        Me.cmbDomicilioEnvio = New System.Windows.Forms.ComboBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.cmbComprobanteSerie = New System.Windows.Forms.ComboBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.obtIndicaTransportePublico = New System.Windows.Forms.RadioButton()
        Me.obtIndicaTransportePrivado = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumeroPlaca = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConductorNombre = New System.Windows.Forms.TextBox()
        Me.txtConductorDNI = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTransportistaRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtTransportistaRUC = New System.Windows.Forms.TextBox()
        Me.txtVehiculoModelo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtVehiculoMarca = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumeroSerieChasis = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProductoDescripcion = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
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
        Me.Panel.Controls.Add(Me.txtVehiculoModelo)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.txtVehiculoMarca)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.txtColor)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.txtNumeroSerieChasis)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.txtNumeroSerie)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtProductoDescripcion)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label15)
        Me.Panel.Controls.Add(Me.obtIndicaTransportePublico)
        Me.Panel.Controls.Add(Me.obtIndicaTransportePrivado)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtNumeroPlaca)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtConductorNombre)
        Me.Panel.Controls.Add(Me.txtConductorDNI)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.txtTransportistaRazonSocial)
        Me.Panel.Controls.Add(Me.txtTransportistaRUC)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txtVenta)
        Me.Panel.Controls.Add(Me.cmbComprobanteSerie)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.cmbDomicilioEnvio)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.txtComprobanteFechaTraslado)
        Me.Panel.Controls.Add(Me.Label43)
        Me.Panel.Controls.Add(Me.lblComprobante)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtComprobante)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label17)
        Me.Panel.Controls.Add(Me.Label42)
        Me.Panel.Controls.Add(Me.txtComprobanteFecha)
        Me.Panel.Controls.Add(Me.txtComprobanteNumero)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.txtRazonSocial)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.txtGuia)
        Me.Panel.Size = New System.Drawing.Size(846, 316)
        Me.Panel.TabIndex = 0
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1350, 689)
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(117, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(442, 18)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "NOMBRE DEL CLIENTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.Moccasin
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRazonSocial.Location = New System.Drawing.Point(117, 31)
        Me.txtRazonSocial.MaxLength = 120
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(442, 21)
        Me.txtRazonSocial.TabIndex = 9
        Me.txtRazonSocial.TabStop = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(642, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(18, 21)
        Me.txtEjercicio.TabIndex = 14
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
        Me.txtMes.Location = New System.Drawing.Point(666, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(18, 21)
        Me.txtMes.TabIndex = 13
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(690, 34)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(143, 18)
        Me.ckbIndicaAnulado.TabIndex = 22
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "GUIA  ANULADA"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        '
        'txtGuia
        '
        Me.txtGuia.BackColor = System.Drawing.Color.Moccasin
        Me.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.ForeColor = System.Drawing.Color.DarkRed
        Me.txtGuia.Location = New System.Drawing.Point(598, 31)
        Me.txtGuia.MaxLength = 8
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(16, 21)
        Me.txtGuia.TabIndex = 19
        Me.txtGuia.TabStop = False
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGuia.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(137, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 18)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "F. EMISION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(66, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 18)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "NUMERO"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.SteelBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(12, 55)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(53, 18)
        Me.Label42.TabIndex = 29
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
        Me.txtComprobanteFecha.Location = New System.Drawing.Point(137, 74)
        Me.txtComprobanteFecha.MaxLength = 10
        Me.txtComprobanteFecha.Name = "txtComprobanteFecha"
        Me.txtComprobanteFecha.Size = New System.Drawing.Size(86, 21)
        Me.txtComprobanteFecha.TabIndex = 1
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
        Me.txtComprobanteNumero.Location = New System.Drawing.Point(66, 74)
        Me.txtComprobanteNumero.MaxLength = 10
        Me.txtComprobanteNumero.Name = "txtComprobanteNumero"
        Me.txtComprobanteNumero.ReadOnly = True
        Me.txtComprobanteNumero.Size = New System.Drawing.Size(70, 21)
        Me.txtComprobanteNumero.TabIndex = 12
        Me.txtComprobanteNumero.TabStop = False
        Me.txtComprobanteNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.Enabled = False
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(570, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(22, 21)
        Me.cmbAlmacen.TabIndex = 7
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        Me.cmbAlmacen.Visible = False
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
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.Azure
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobante.Location = New System.Drawing.Point(12, 31)
        Me.txtComprobante.MaxLength = 12
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(104, 21)
        Me.txtComprobante.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 18)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "COMPROBANTE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblComprobante
        '
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComprobante.Location = New System.Drawing.Point(573, 0)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(260, 20)
        Me.lblComprobante.TabIndex = 23
        Me.lblComprobante.Text = "GUIA POR VENTA VEHICULAR"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.SteelBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(12, 98)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(820, 18)
        Me.Label43.TabIndex = 28
        Me.Label43.Text = "PUNTO DE LLEGADA"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(224, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 18)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "F. TRASLADO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComprobanteFechaTraslado
        '
        Me.txtComprobanteFechaTraslado.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComprobanteFechaTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobanteFechaTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobanteFechaTraslado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtComprobanteFechaTraslado.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComprobanteFechaTraslado.Location = New System.Drawing.Point(224, 74)
        Me.txtComprobanteFechaTraslado.MaxLength = 10
        Me.txtComprobanteFechaTraslado.Name = "txtComprobanteFechaTraslado"
        Me.txtComprobanteFechaTraslado.Size = New System.Drawing.Size(86, 21)
        Me.txtComprobanteFechaTraslado.TabIndex = 2
        Me.txtComprobanteFechaTraslado.Tag = "F"
        Me.txtComprobanteFechaTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbDomicilioEnvio
        '
        Me.cmbDomicilioEnvio.BackColor = System.Drawing.Color.Azure
        Me.cmbDomicilioEnvio.DisplayMember = "DIRECCION"
        Me.cmbDomicilioEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbDomicilioEnvio.Enabled = False
        Me.cmbDomicilioEnvio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbDomicilioEnvio.FormattingEnabled = True
        Me.cmbDomicilioEnvio.Location = New System.Drawing.Point(12, 117)
        Me.cmbDomicilioEnvio.MaxLength = 200
        Me.cmbDomicilioEnvio.Name = "cmbDomicilioEnvio"
        Me.cmbDomicilioEnvio.Size = New System.Drawing.Size(820, 21)
        Me.cmbDomicilioEnvio.TabIndex = 10
        Me.cmbDomicilioEnvio.ValueMember = "DOMICILIO_ENVIO"
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(311, 74)
        Me.txtComentario.MaxLength = 100
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(522, 21)
        Me.txtComentario.TabIndex = 5
        '
        'cmbComprobanteSerie
        '
        Me.cmbComprobanteSerie.BackColor = System.Drawing.Color.Azure
        Me.cmbComprobanteSerie.DisplayMember = "CODIGO"
        Me.cmbComprobanteSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobanteSerie.Enabled = False
        Me.cmbComprobanteSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbComprobanteSerie.FormattingEnabled = True
        Me.cmbComprobanteSerie.Location = New System.Drawing.Point(12, 74)
        Me.cmbComprobanteSerie.Name = "cmbComprobanteSerie"
        Me.cmbComprobanteSerie.Size = New System.Drawing.Size(53, 21)
        Me.cmbComprobanteSerie.TabIndex = 11
        Me.cmbComprobanteSerie.TabStop = False
        Me.cmbComprobanteSerie.ValueMember = "CODIGO"
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(620, 31)
        Me.txtVenta.MaxLength = 8
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.Size = New System.Drawing.Size(16, 21)
        Me.txtVenta.TabIndex = 18
        Me.txtVenta.TabStop = False
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVenta.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(311, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(522, 18)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "COMENTARIO/OBSERVACIONES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obtIndicaTransportePublico
        '
        Me.obtIndicaTransportePublico.BackColor = System.Drawing.Color.SteelBlue
        Me.obtIndicaTransportePublico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.obtIndicaTransportePublico.ForeColor = System.Drawing.Color.White
        Me.obtIndicaTransportePublico.Location = New System.Drawing.Point(459, 144)
        Me.obtIndicaTransportePublico.Name = "obtIndicaTransportePublico"
        Me.obtIndicaTransportePublico.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.obtIndicaTransportePublico.Size = New System.Drawing.Size(373, 18)
        Me.obtIndicaTransportePublico.TabIndex = 119
        Me.obtIndicaTransportePublico.Text = "ENVIO POR TRANSPORTE PUBLICO"
        Me.obtIndicaTransportePublico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.obtIndicaTransportePublico.UseVisualStyleBackColor = False
        '
        'obtIndicaTransportePrivado
        '
        Me.obtIndicaTransportePrivado.BackColor = System.Drawing.Color.SteelBlue
        Me.obtIndicaTransportePrivado.Checked = True
        Me.obtIndicaTransportePrivado.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.obtIndicaTransportePrivado.ForeColor = System.Drawing.Color.White
        Me.obtIndicaTransportePrivado.Location = New System.Drawing.Point(12, 144)
        Me.obtIndicaTransportePrivado.Name = "obtIndicaTransportePrivado"
        Me.obtIndicaTransportePrivado.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.obtIndicaTransportePrivado.Size = New System.Drawing.Size(446, 18)
        Me.obtIndicaTransportePrivado.TabIndex = 118
        Me.obtIndicaTransportePrivado.TabStop = True
        Me.obtIndicaTransportePrivado.Text = "ENVIO POR TRANSPORTE PRIVADO"
        Me.obtIndicaTransportePrivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.obtIndicaTransportePrivado.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(532, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(300, 16)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "RAZON SOCIAL DEL TRANSPORTISTA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Location = New System.Drawing.Point(66, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(309, 16)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "NOMBRE DEL CONDUCTOR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(376, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 16)
        Me.Label12.TabIndex = 117
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
        Me.txtNumeroPlaca.Location = New System.Drawing.Point(376, 180)
        Me.txtNumeroPlaca.MaxLength = 7
        Me.txtNumeroPlaca.Name = "txtNumeroPlaca"
        Me.txtNumeroPlaca.Size = New System.Drawing.Size(82, 21)
        Me.txtNumeroPlaca.TabIndex = 112
        Me.txtNumeroPlaca.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(13, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "DNI"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConductorNombre
        '
        Me.txtConductorNombre.BackColor = System.Drawing.Color.AliceBlue
        Me.txtConductorNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductorNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConductorNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConductorNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtConductorNombre.Location = New System.Drawing.Point(66, 180)
        Me.txtConductorNombre.MaxLength = 100
        Me.txtConductorNombre.Name = "txtConductorNombre"
        Me.txtConductorNombre.Size = New System.Drawing.Size(309, 21)
        Me.txtConductorNombre.TabIndex = 109
        Me.txtConductorNombre.TabStop = False
        '
        'txtConductorDNI
        '
        Me.txtConductorDNI.BackColor = System.Drawing.Color.AliceBlue
        Me.txtConductorDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductorDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConductorDNI.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConductorDNI.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtConductorDNI.Location = New System.Drawing.Point(13, 180)
        Me.txtConductorDNI.MaxLength = 8
        Me.txtConductorDNI.Name = "txtConductorDNI"
        Me.txtConductorDNI.Size = New System.Drawing.Size(52, 21)
        Me.txtConductorDNI.TabIndex = 108
        Me.txtConductorDNI.Tag = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(459, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 115
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
        Me.txtTransportistaRazonSocial.Location = New System.Drawing.Point(532, 180)
        Me.txtTransportistaRazonSocial.MaxLength = 100
        Me.txtTransportistaRazonSocial.Name = "txtTransportistaRazonSocial"
        Me.txtTransportistaRazonSocial.ReadOnly = True
        Me.txtTransportistaRazonSocial.Size = New System.Drawing.Size(300, 21)
        Me.txtTransportistaRazonSocial.TabIndex = 111
        Me.txtTransportistaRazonSocial.TabStop = False
        '
        'txtTransportistaRUC
        '
        Me.txtTransportistaRUC.BackColor = System.Drawing.Color.Moccasin
        Me.txtTransportistaRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransportistaRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransportistaRUC.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransportistaRUC.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTransportistaRUC.Location = New System.Drawing.Point(459, 180)
        Me.txtTransportistaRUC.MaxLength = 11
        Me.txtTransportistaRUC.Name = "txtTransportistaRUC"
        Me.txtTransportistaRUC.ReadOnly = True
        Me.txtTransportistaRUC.Size = New System.Drawing.Size(72, 21)
        Me.txtTransportistaRUC.TabIndex = 110
        Me.txtTransportistaRUC.TabStop = False
        Me.txtTransportistaRUC.Tag = ""
        '
        'txtVehiculoModelo
        '
        Me.txtVehiculoModelo.BackColor = System.Drawing.Color.Moccasin
        Me.txtVehiculoModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehiculoModelo.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVehiculoModelo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVehiculoModelo.Location = New System.Drawing.Point(179, 272)
        Me.txtVehiculoModelo.MaxLength = 20
        Me.txtVehiculoModelo.Name = "txtVehiculoModelo"
        Me.txtVehiculoModelo.ReadOnly = True
        Me.txtVehiculoModelo.Size = New System.Drawing.Size(166, 21)
        Me.txtVehiculoModelo.TabIndex = 123
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label24.Location = New System.Drawing.Point(179, 250)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(166, 21)
        Me.Label24.TabIndex = 133
        Me.Label24.Text = "MODELO"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVehiculoMarca
        '
        Me.txtVehiculoMarca.BackColor = System.Drawing.Color.Moccasin
        Me.txtVehiculoMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculoMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehiculoMarca.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtVehiculoMarca.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVehiculoMarca.Location = New System.Drawing.Point(12, 272)
        Me.txtVehiculoMarca.MaxLength = 20
        Me.txtVehiculoMarca.Name = "txtVehiculoMarca"
        Me.txtVehiculoMarca.ReadOnly = True
        Me.txtVehiculoMarca.Size = New System.Drawing.Size(166, 21)
        Me.txtVehiculoMarca.TabIndex = 122
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label25.Location = New System.Drawing.Point(13, 250)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(165, 21)
        Me.Label25.TabIndex = 132
        Me.Label25.Text = "MARCA"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.Moccasin
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColor.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtColor.ForeColor = System.Drawing.Color.DarkRed
        Me.txtColor.Location = New System.Drawing.Point(680, 272)
        Me.txtColor.MaxLength = 20
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(153, 21)
        Me.txtColor.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(680, 250)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 21)
        Me.Label6.TabIndex = 136
        Me.Label6.Text = "COLOR"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroSerieChasis
        '
        Me.txtNumeroSerieChasis.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroSerieChasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerieChasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerieChasis.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroSerieChasis.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroSerieChasis.Location = New System.Drawing.Point(513, 272)
        Me.txtNumeroSerieChasis.MaxLength = 20
        Me.txtNumeroSerieChasis.Name = "txtNumeroSerieChasis"
        Me.txtNumeroSerieChasis.ReadOnly = True
        Me.txtNumeroSerieChasis.Size = New System.Drawing.Size(166, 21)
        Me.txtNumeroSerieChasis.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(513, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(166, 21)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "NUMERO SERIE CHASIS (VIN)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.Moccasin
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNumeroSerie.Location = New System.Drawing.Point(346, 272)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.ReadOnly = True
        Me.txtNumeroSerie.Size = New System.Drawing.Size(166, 21)
        Me.txtNumeroSerie.TabIndex = 124
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.Location = New System.Drawing.Point(346, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 21)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "NUMERO SERIE MOTOR"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.BackColor = System.Drawing.Color.Moccasin
        Me.txtProductoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtProductoDescripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(77, 226)
        Me.txtProductoDescripcion.MaxLength = 150
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.ReadOnly = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(755, 21)
        Me.txtProductoDescripcion.TabIndex = 127
        Me.txtProductoDescripcion.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Moccasin
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProducto.Location = New System.Drawing.Point(13, 226)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(63, 21)
        Me.txtProducto.TabIndex = 120
        Me.txtProducto.Tag = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.Location = New System.Drawing.Point(13, 207)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(819, 18)
        Me.Label15.TabIndex = 129
        Me.Label15.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmGuiaPorVentaVehiculo
        '
        Me.ClientSize = New System.Drawing.Size(846, 370)
        Me.Name = "frmGuiaPorVentaVehiculo"
        Me.Text = "GUIA POR VENTA VEHICULAR"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtComprobanteFechaTraslado As System.Windows.Forms.TextBox
    Friend WithEvents cmbDomicilioEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents cmbComprobanteSerie As System.Windows.Forms.ComboBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obtIndicaTransportePublico As System.Windows.Forms.RadioButton
    Friend WithEvents obtIndicaTransportePrivado As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtConductorNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtConductorDNI As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTransportistaRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtTransportistaRUC As System.Windows.Forms.TextBox
    Friend WithEvents txtVehiculoModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculoMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerieChasis As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProductoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label

End Class
