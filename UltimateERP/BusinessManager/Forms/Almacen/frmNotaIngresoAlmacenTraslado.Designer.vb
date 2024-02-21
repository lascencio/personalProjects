<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaIngresoAlmacenTraslado
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvOperacionAlmacenLineas = New System.Windows.Forms.DataGridView()
        Me.LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO_MN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_UNITARIO_ME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_LOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_RESUMEN_PERIODO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOperacionFecha = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFechaTraslado = New System.Windows.Forms.TextBox()
        Me.txtNumeroGuia = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.TextBox()
        Me.Panel.SuspendLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtFechaEmision)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label36)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.txtFechaTraslado)
        Me.Panel.Controls.Add(Me.txtNumeroGuia)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtOperacionFecha)
        Me.Panel.Controls.Add(Me.txtEjercicio)
        Me.Panel.Controls.Add(Me.txtMes)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.ckbIndicaAnulado)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtOperacion)
        Me.Panel.Controls.Add(Me.gvOperacionAlmacenLineas)
        Me.Panel.Size = New System.Drawing.Size(747, 369)
        Me.Panel.TabIndex = 0
        '
        'gvOperacionAlmacenLineas
        '
        Me.gvOperacionAlmacenLineas.AllowUserToAddRows = False
        Me.gvOperacionAlmacenLineas.AllowUserToDeleteRows = False
        Me.gvOperacionAlmacenLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvOperacionAlmacenLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOperacionAlmacenLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvOperacionAlmacenLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperacionAlmacenLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LINEA, Me.PRODUCTO, Me.CODIGO_COMPRA, Me.DESCRIPCION_AMPLIADA, Me.PRECIO_UNITARIO_MN, Me.PRECIO_UNITARIO_ME, Me.CANTIDAD, Me.NUMERO_LOTE, Me.FECHA_VENCIMIENTO, Me.INDICA_SERIE, Me.EXISTE_RESUMEN_ALMACEN, Me.EXISTE_RESUMEN_PERIODO, Me.ELIMINAR})
        Me.gvOperacionAlmacenLineas.EnableHeadersVisualStyles = False
        Me.gvOperacionAlmacenLineas.Location = New System.Drawing.Point(11, 102)
        Me.gvOperacionAlmacenLineas.MultiSelect = False
        Me.gvOperacionAlmacenLineas.Name = "gvOperacionAlmacenLineas"
        Me.gvOperacionAlmacenLineas.ReadOnly = True
        Me.gvOperacionAlmacenLineas.RowHeadersVisible = False
        Me.gvOperacionAlmacenLineas.RowHeadersWidth = 20
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.OldLace
        Me.gvOperacionAlmacenLineas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gvOperacionAlmacenLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOperacionAlmacenLineas.Size = New System.Drawing.Size(723, 254)
        Me.gvOperacionAlmacenLineas.TabIndex = 9
        Me.gvOperacionAlmacenLineas.TabStop = False
        '
        'LINEA
        '
        Me.LINEA.DataPropertyName = "LINEA"
        Me.LINEA.HeaderText = "LN"
        Me.LINEA.Name = "LINEA"
        Me.LINEA.ReadOnly = True
        Me.LINEA.Visible = False
        Me.LINEA.Width = 30
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        '
        'CODIGO_COMPRA
        '
        Me.CODIGO_COMPRA.DataPropertyName = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.HeaderText = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.Name = "CODIGO_COMPRA"
        Me.CODIGO_COMPRA.ReadOnly = True
        Me.CODIGO_COMPRA.Visible = False
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 525
        '
        'PRECIO_UNITARIO_MN
        '
        Me.PRECIO_UNITARIO_MN.DataPropertyName = "PRECIO_UNITARIO_MN"
        Me.PRECIO_UNITARIO_MN.HeaderText = "PRECIO_UNITARIO_MN"
        Me.PRECIO_UNITARIO_MN.Name = "PRECIO_UNITARIO_MN"
        Me.PRECIO_UNITARIO_MN.ReadOnly = True
        Me.PRECIO_UNITARIO_MN.Visible = False
        '
        'PRECIO_UNITARIO_ME
        '
        Me.PRECIO_UNITARIO_ME.DataPropertyName = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.HeaderText = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.Name = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.ReadOnly = True
        Me.PRECIO_UNITARIO_ME.Visible = False
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
        Me.CANTIDAD.Width = 70
        '
        'NUMERO_LOTE
        '
        Me.NUMERO_LOTE.DataPropertyName = "NUMERO_LOTE"
        Me.NUMERO_LOTE.HeaderText = "NUMERO_LOTE"
        Me.NUMERO_LOTE.Name = "NUMERO_LOTE"
        Me.NUMERO_LOTE.ReadOnly = True
        Me.NUMERO_LOTE.Visible = False
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Visible = False
        '
        'INDICA_SERIE
        '
        Me.INDICA_SERIE.DataPropertyName = "INDICA_SERIE"
        Me.INDICA_SERIE.HeaderText = "INDICA_SERIE"
        Me.INDICA_SERIE.Name = "INDICA_SERIE"
        Me.INDICA_SERIE.ReadOnly = True
        Me.INDICA_SERIE.Visible = False
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
        'ELIMINAR
        '
        Me.ELIMINAR.HeaderText = ""
        Me.ELIMINAR.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.ELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ELIMINAR.Name = "ELIMINAR"
        Me.ELIMINAR.ReadOnly = True
        Me.ELIMINAR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ELIMINAR.Visible = False
        Me.ELIMINAR.Width = 24
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(477, 31)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(34, 21)
        Me.txtEjercicio.TabIndex = 7
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
        Me.txtMes.Location = New System.Drawing.Point(512, 31)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(17, 21)
        Me.txtMes.TabIndex = 8
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(440, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(294, 20)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "NOTA DE INGRESO POR TRASLADO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(553, 32)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(178, 20)
        Me.ckbIndicaAnulado.TabIndex = 3
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "OPERACION ANULADA"
        Me.ckbIndicaAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = False
        Me.ckbIndicaAnulado.Visible = False
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(338, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 18)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "OPERACION"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacion
        '
        Me.txtOperacion.BackColor = System.Drawing.Color.Moccasin
        Me.txtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOperacion.Location = New System.Drawing.Point(338, 31)
        Me.txtOperacion.MaxLength = 8
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.ReadOnly = True
        Me.txtOperacion.Size = New System.Drawing.Size(84, 21)
        Me.txtOperacion.TabIndex = 6
        Me.txtOperacion.TabStop = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 18)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "F. RECEPCION"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperacionFecha
        '
        Me.txtOperacionFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOperacionFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperacionFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperacionFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacionFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtOperacionFecha.Location = New System.Drawing.Point(11, 75)
        Me.txtOperacionFecha.MaxLength = 50
        Me.txtOperacionFecha.Name = "txtOperacionFecha"
        Me.txtOperacionFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtOperacionFecha.TabIndex = 1
        Me.txtOperacionFecha.Tag = "F"
        Me.txtOperacionFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(233, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 18)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "F. TRASLADO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(11, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 18)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "NRO. GUIA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaTraslado
        '
        Me.txtFechaTraslado.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaTraslado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTraslado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaTraslado.Location = New System.Drawing.Point(233, 31)
        Me.txtFechaTraslado.MaxLength = 10
        Me.txtFechaTraslado.Name = "txtFechaTraslado"
        Me.txtFechaTraslado.ReadOnly = True
        Me.txtFechaTraslado.Size = New System.Drawing.Size(91, 21)
        Me.txtFechaTraslado.TabIndex = 5
        Me.txtFechaTraslado.TabStop = False
        Me.txtFechaTraslado.Tag = "F"
        Me.txtFechaTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumeroGuia
        '
        Me.txtNumeroGuia.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroGuia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroGuia.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroGuia.Location = New System.Drawing.Point(11, 31)
        Me.txtNumeroGuia.MaxLength = 10
        Me.txtNumeroGuia.Name = "txtNumeroGuia"
        Me.txtNumeroGuia.Size = New System.Drawing.Size(124, 21)
        Me.txtNumeroGuia.TabIndex = 0
        Me.txtNumeroGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComentario
        '
        Me.txtComentario.AcceptsReturn = True
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(103, 75)
        Me.txtComentario.MaxLength = 150
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(631, 21)
        Me.txtComentario.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.SteelBlue
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(103, 56)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(631, 18)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "COMENTARIO"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(141, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "F. EMISION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.BackColor = System.Drawing.Color.Moccasin
        Me.txtFechaEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaEmision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaEmision.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEmision.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFechaEmision.Location = New System.Drawing.Point(141, 31)
        Me.txtFechaEmision.MaxLength = 10
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(91, 21)
        Me.txtFechaEmision.TabIndex = 4
        Me.txtFechaEmision.TabStop = False
        Me.txtFechaEmision.Tag = "F"
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmNotaIngresoAlmacenTraslado
        '
        Me.ClientSize = New System.Drawing.Size(747, 423)
        Me.Name = "frmNotaIngresoAlmacenTraslado"
        Me.Text = "NOTA DE INGRESO POR TRASLADO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvOperacionAlmacenLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvOperacionAlmacenLineas As System.Windows.Forms.DataGridView
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtOperacion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOperacionFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFechaTraslado As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroGuia As System.Windows.Forms.TextBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents LINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_MN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_LOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_RESUMEN_PERIODO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn

End Class
