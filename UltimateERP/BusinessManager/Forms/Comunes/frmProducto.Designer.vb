<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducto
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.ckbIndicaNuevo = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUnidadVenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUnidadCompra = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoExistencia = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtCodigoCompra = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtDescripcionCompra = New System.Windows.Forms.TextBox()
        Me.cmbSubTipo = New System.Windows.Forms.ComboBox()
        Me.cmbSubFamilia = New System.Windows.Forms.ComboBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtCodigoAntiguo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPartidaArancelaria = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.cmbPrioridad = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbProcedencia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcionAmpliada = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox()
        Me.ckbIndicaActivo = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaValidaStock = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaAfecto = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaVencimiento = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaLote = New System.Windows.Forms.CheckBox()
        Me.ckbIndicaSerie = New System.Windows.Forms.CheckBox()
        Me.Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(815, 54)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Panel1)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.cmbTipo)
        Me.Panel.Controls.Add(Me.Label16)
        Me.Panel.Controls.Add(Me.cmbFamilia)
        Me.Panel.Controls.Add(Me.ckbIndicaNuevo)
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.cmbUnidadVenta)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbUnidadCompra)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbUnidadMedida)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Controls.Add(Me.cmbTipoExistencia)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.Label37)
        Me.Panel.Controls.Add(Me.txtCodigoCompra)
        Me.Panel.Controls.Add(Me.Label38)
        Me.Panel.Controls.Add(Me.txtDescripcionCompra)
        Me.Panel.Controls.Add(Me.cmbSubTipo)
        Me.Panel.Controls.Add(Me.cmbSubFamilia)
        Me.Panel.Controls.Add(Me.txtComentario)
        Me.Panel.Controls.Add(Me.Label35)
        Me.Panel.Controls.Add(Me.txtCodigoAntiguo)
        Me.Panel.Controls.Add(Me.Label26)
        Me.Panel.Controls.Add(Me.txtPartidaArancelaria)
        Me.Panel.Controls.Add(Me.Label25)
        Me.Panel.Controls.Add(Me.cmbUbicacion)
        Me.Panel.Controls.Add(Me.Label24)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Controls.Add(Me.cmbPrioridad)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbProcedencia)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtDescripcionAmpliada)
        Me.Panel.Controls.Add(Me.Label33)
        Me.Panel.Controls.Add(Me.txtProducto)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtDescripcion)
        Me.Panel.Size = New System.Drawing.Size(815, 409)
        Me.Panel.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(442, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(359, 18)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "MODELO DE PRODUCTO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(370, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(431, 18)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "SUBLINEA DE PRODUCTO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 195)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(353, 18)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "LINEA DE PRODUCTO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbTipo.DisplayMember = "DESCRIPCION"
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(11, 214)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(353, 21)
        Me.cmbTipo.TabIndex = 10
        Me.cmbTipo.ValueMember = "CODIGO"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(11, 238)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(425, 18)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "MARCA DE PRODUCTO"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFamilia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFamilia.BackColor = System.Drawing.Color.Azure
        Me.cmbFamilia.DisplayMember = "DESCRIPCION"
        Me.cmbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFamilia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbFamilia.FormattingEnabled = True
        Me.cmbFamilia.Location = New System.Drawing.Point(11, 257)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(425, 21)
        Me.cmbFamilia.TabIndex = 12
        Me.cmbFamilia.ValueMember = "CODIGO"
        '
        'ckbIndicaNuevo
        '
        Me.ckbIndicaNuevo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaNuevo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckbIndicaNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaNuevo.Location = New System.Drawing.Point(11, 6)
        Me.ckbIndicaNuevo.Name = "ckbIndicaNuevo"
        Me.ckbIndicaNuevo.Size = New System.Drawing.Size(153, 16)
        Me.ckbIndicaNuevo.TabIndex = 20
        Me.ckbIndicaNuevo.TabStop = False
        Me.ckbIndicaNuevo.Text = "PRODUCTO NUEVO"
        Me.ckbIndicaNuevo.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(624, 152)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(177, 18)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "MONEDA"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(624, 171)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(177, 21)
        Me.cmbTipoMoneda.TabIndex = 9
        Me.cmbTipoMoneda.ValueMember = "CODIGO"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(272, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 18)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "UNIDAD VENTA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnidadVenta
        '
        Me.cmbUnidadVenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnidadVenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnidadVenta.BackColor = System.Drawing.Color.Azure
        Me.cmbUnidadVenta.DisplayMember = "DESCRIPCION"
        Me.cmbUnidadVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbUnidadVenta.FormattingEnabled = True
        Me.cmbUnidadVenta.Location = New System.Drawing.Point(272, 171)
        Me.cmbUnidadVenta.Name = "cmbUnidadVenta"
        Me.cmbUnidadVenta.Size = New System.Drawing.Size(130, 21)
        Me.cmbUnidadVenta.TabIndex = 7
        Me.cmbUnidadVenta.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(141, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "UNIDAD COMPRA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnidadCompra
        '
        Me.cmbUnidadCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnidadCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnidadCompra.BackColor = System.Drawing.Color.Azure
        Me.cmbUnidadCompra.DisplayMember = "DESCRIPCION"
        Me.cmbUnidadCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadCompra.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbUnidadCompra.FormattingEnabled = True
        Me.cmbUnidadCompra.Location = New System.Drawing.Point(141, 171)
        Me.cmbUnidadCompra.Name = "cmbUnidadCompra"
        Me.cmbUnidadCompra.Size = New System.Drawing.Size(130, 21)
        Me.cmbUnidadCompra.TabIndex = 6
        Me.cmbUnidadCompra.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(10, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 18)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "UNIDAD MEDIDA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnidadMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnidadMedida.BackColor = System.Drawing.Color.Azure
        Me.cmbUnidadMedida.DisplayMember = "DESCRIPCION"
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(10, 171)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(130, 21)
        Me.cmbUnidadMedida.TabIndex = 5
        Me.cmbUnidadMedida.ValueMember = "CODIGO"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(403, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(220, 18)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "TIPO DE EXISTENCIA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoExistencia
        '
        Me.cmbTipoExistencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoExistencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoExistencia.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoExistencia.DisplayMember = "DESCRIPCION"
        Me.cmbTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoExistencia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTipoExistencia.FormattingEnabled = True
        Me.cmbTipoExistencia.Location = New System.Drawing.Point(403, 171)
        Me.cmbTipoExistencia.Name = "cmbTipoExistencia"
        Me.cmbTipoExistencia.Size = New System.Drawing.Size(220, 21)
        Me.cmbTipoExistencia.TabIndex = 8
        Me.cmbTipoExistencia.ValueMember = "CODIGO"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(11, 327)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(791, 18)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "COMENTARIO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.SteelBlue
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(11, 109)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(130, 18)
        Me.Label37.TabIndex = 27
        Me.Label37.Text = "CODIGO COMPRA"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoCompra
        '
        Me.txtCodigoCompra.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCompra.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoCompra.Location = New System.Drawing.Point(11, 128)
        Me.txtCodigoCompra.MaxLength = 20
        Me.txtCodigoCompra.Name = "txtCodigoCompra"
        Me.txtCodigoCompra.Size = New System.Drawing.Size(130, 21)
        Me.txtCodigoCompra.TabIndex = 3
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.SteelBlue
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(142, 109)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(660, 18)
        Me.Label38.TabIndex = 28
        Me.Label38.Text = "DESCRIPCION DE COMPRA"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionCompra
        '
        Me.txtDescripcionCompra.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcionCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionCompra.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionCompra.Location = New System.Drawing.Point(142, 128)
        Me.txtDescripcionCompra.MaxLength = 200
        Me.txtDescripcionCompra.Name = "txtDescripcionCompra"
        Me.txtDescripcionCompra.Size = New System.Drawing.Size(660, 21)
        Me.txtDescripcionCompra.TabIndex = 4
        '
        'cmbSubTipo
        '
        Me.cmbSubTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbSubTipo.DisplayMember = "DESCRIPCION"
        Me.cmbSubTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbSubTipo.FormattingEnabled = True
        Me.cmbSubTipo.Location = New System.Drawing.Point(370, 214)
        Me.cmbSubTipo.Name = "cmbSubTipo"
        Me.cmbSubTipo.Size = New System.Drawing.Size(431, 21)
        Me.cmbSubTipo.TabIndex = 11
        Me.cmbSubTipo.TabStop = False
        Me.cmbSubTipo.ValueMember = "CODIGO"
        '
        'cmbSubFamilia
        '
        Me.cmbSubFamilia.BackColor = System.Drawing.Color.Azure
        Me.cmbSubFamilia.DisplayMember = "DESCRIPCION"
        Me.cmbSubFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubFamilia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbSubFamilia.FormattingEnabled = True
        Me.cmbSubFamilia.Location = New System.Drawing.Point(442, 257)
        Me.cmbSubFamilia.Name = "cmbSubFamilia"
        Me.cmbSubFamilia.Size = New System.Drawing.Size(359, 21)
        Me.cmbSubFamilia.TabIndex = 13
        Me.cmbSubFamilia.TabStop = False
        Me.cmbSubFamilia.ValueMember = "CODIGO"
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.Color.AliceBlue
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtComentario.Location = New System.Drawing.Point(11, 346)
        Me.txtComentario.MaxLength = 100
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(790, 21)
        Me.txtComentario.TabIndex = 19
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(663, 67)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(139, 18)
        Me.Label35.TabIndex = 26
        Me.Label35.Text = "CODIGO ANTIGUO"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoAntiguo
        '
        Me.txtCodigoAntiguo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCodigoAntiguo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoAntiguo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoAntiguo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAntiguo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigoAntiguo.Location = New System.Drawing.Point(663, 86)
        Me.txtCodigoAntiguo.MaxLength = 20
        Me.txtCodigoAntiguo.Name = "txtCodigoAntiguo"
        Me.txtCodigoAntiguo.Size = New System.Drawing.Size(139, 21)
        Me.txtCodigoAntiguo.TabIndex = 21
        Me.txtCodigoAntiguo.TabStop = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.SteelBlue
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(130, 284)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(173, 18)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "PARTIDA ARANCELARIA"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartidaArancelaria
        '
        Me.txtPartidaArancelaria.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPartidaArancelaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartidaArancelaria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartidaArancelaria.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtPartidaArancelaria.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPartidaArancelaria.Location = New System.Drawing.Point(130, 303)
        Me.txtPartidaArancelaria.MaxLength = 20
        Me.txtPartidaArancelaria.Name = "txtPartidaArancelaria"
        Me.txtPartidaArancelaria.Size = New System.Drawing.Size(173, 21)
        Me.txtPartidaArancelaria.TabIndex = 15
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.SteelBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(625, 284)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(177, 18)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "UBICACION"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUbicacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUbicacion.BackColor = System.Drawing.Color.Azure
        Me.cmbUbicacion.DisplayMember = "DESCRIPCION"
        Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacion.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Location = New System.Drawing.Point(625, 303)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(177, 21)
        Me.cmbUbicacion.TabIndex = 18
        Me.cmbUbicacion.ValueMember = "CODIGO"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(391, 284)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(233, 18)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "ALMACEN"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAlmacen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(391, 303)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(233, 21)
        Me.cmbAlmacen.TabIndex = 17
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'cmbPrioridad
        '
        Me.cmbPrioridad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPrioridad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPrioridad.BackColor = System.Drawing.Color.Azure
        Me.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrioridad.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbPrioridad.FormattingEnabled = True
        Me.cmbPrioridad.Items.AddRange(New Object() {"BAJA", "MEDIA", "ALTA"})
        Me.cmbPrioridad.Location = New System.Drawing.Point(304, 303)
        Me.cmbPrioridad.Name = "cmbPrioridad"
        Me.cmbPrioridad.Size = New System.Drawing.Size(86, 21)
        Me.cmbPrioridad.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(304, 284)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 18)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "PRIORIDAD"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(11, 284)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 18)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "PROCEDENCIA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProcedencia
        '
        Me.cmbProcedencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProcedencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProcedencia.BackColor = System.Drawing.Color.Azure
        Me.cmbProcedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcedencia.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbProcedencia.FormattingEnabled = True
        Me.cmbProcedencia.Items.AddRange(New Object() {"NACIONAL", "IMPORTADO"})
        Me.cmbProcedencia.Location = New System.Drawing.Point(11, 303)
        Me.cmbProcedencia.Name = "cmbProcedencia"
        Me.cmbProcedencia.Size = New System.Drawing.Size(118, 21)
        Me.cmbProcedencia.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(105, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(697, 18)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "DESCRIPCION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionAmpliada
        '
        Me.txtDescripcionAmpliada.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcionAmpliada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionAmpliada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionAmpliada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionAmpliada.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcionAmpliada.Location = New System.Drawing.Point(105, 43)
        Me.txtDescripcionAmpliada.MaxLength = 200
        Me.txtDescripcionAmpliada.Name = "txtDescripcionAmpliada"
        Me.txtDescripcionAmpliada.Size = New System.Drawing.Size(697, 21)
        Me.txtDescripcionAmpliada.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(11, 24)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 18)
        Me.Label33.TabIndex = 23
        Me.Label33.Text = "CODIGO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(11, 43)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(93, 21)
        Me.txtProducto.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(646, 18)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "DESCRIPCION CORTA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDescripcion.Location = New System.Drawing.Point(11, 86)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(646, 21)
        Me.txtDescripcion.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(312, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(490, 20)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "MANTENIMIENTO DE PRODUCTOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtCuentaComercial)
        Me.Panel1.Controls.Add(Me.ckbIndicaActivo)
        Me.Panel1.Controls.Add(Me.ckbIndicaValidaStock)
        Me.Panel1.Controls.Add(Me.ckbIndicaAfecto)
        Me.Panel1.Controls.Add(Me.ckbIndicaVencimiento)
        Me.Panel1.Controls.Add(Me.ckbIndicaLote)
        Me.Panel1.Controls.Add(Me.ckbIndicaSerie)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(813, 31)
        Me.Panel1.TabIndex = 44
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.White
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.txtCuentaComercial.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentaComercial.Location = New System.Drawing.Point(9, 5)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(80, 14)
        Me.txtCuentaComercial.TabIndex = 6
        Me.txtCuentaComercial.TabStop = False
        '
        'ckbIndicaActivo
        '
        Me.ckbIndicaActivo.AutoSize = True
        Me.ckbIndicaActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaActivo.Checked = True
        Me.ckbIndicaActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaActivo.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaActivo.Location = New System.Drawing.Point(695, 6)
        Me.ckbIndicaActivo.Name = "ckbIndicaActivo"
        Me.ckbIndicaActivo.Size = New System.Drawing.Size(104, 17)
        Me.ckbIndicaActivo.TabIndex = 5
        Me.ckbIndicaActivo.TabStop = False
        Me.ckbIndicaActivo.Text = "INDICA ACTIVO"
        Me.ckbIndicaActivo.UseVisualStyleBackColor = True
        '
        'ckbIndicaValidaStock
        '
        Me.ckbIndicaValidaStock.AutoSize = True
        Me.ckbIndicaValidaStock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaValidaStock.Checked = True
        Me.ckbIndicaValidaStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaValidaStock.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaValidaStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaValidaStock.Location = New System.Drawing.Point(586, 6)
        Me.ckbIndicaValidaStock.Name = "ckbIndicaValidaStock"
        Me.ckbIndicaValidaStock.Size = New System.Drawing.Size(103, 17)
        Me.ckbIndicaValidaStock.TabIndex = 4
        Me.ckbIndicaValidaStock.TabStop = False
        Me.ckbIndicaValidaStock.Text = "VALIDA STOCK"
        Me.ckbIndicaValidaStock.UseVisualStyleBackColor = True
        '
        'ckbIndicaAfecto
        '
        Me.ckbIndicaAfecto.AutoSize = True
        Me.ckbIndicaAfecto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAfecto.Checked = True
        Me.ckbIndicaAfecto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbIndicaAfecto.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaAfecto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAfecto.Location = New System.Drawing.Point(446, 6)
        Me.ckbIndicaAfecto.Name = "ckbIndicaAfecto"
        Me.ckbIndicaAfecto.Size = New System.Drawing.Size(134, 17)
        Me.ckbIndicaAfecto.TabIndex = 3
        Me.ckbIndicaAfecto.TabStop = False
        Me.ckbIndicaAfecto.Text = "AFECTO IMPUESTOS"
        Me.ckbIndicaAfecto.UseVisualStyleBackColor = True
        '
        'ckbIndicaVencimiento
        '
        Me.ckbIndicaVencimiento.AutoSize = True
        Me.ckbIndicaVencimiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaVencimiento.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaVencimiento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaVencimiento.Location = New System.Drawing.Point(305, 6)
        Me.ckbIndicaVencimiento.Name = "ckbIndicaVencimiento"
        Me.ckbIndicaVencimiento.Size = New System.Drawing.Size(135, 17)
        Me.ckbIndicaVencimiento.TabIndex = 2
        Me.ckbIndicaVencimiento.TabStop = False
        Me.ckbIndicaVencimiento.Text = "EXIGE VENCIMIENTO"
        Me.ckbIndicaVencimiento.UseVisualStyleBackColor = True
        '
        'ckbIndicaLote
        '
        Me.ckbIndicaLote.AutoSize = True
        Me.ckbIndicaLote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaLote.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaLote.Location = New System.Drawing.Point(210, 6)
        Me.ckbIndicaLote.Name = "ckbIndicaLote"
        Me.ckbIndicaLote.Size = New System.Drawing.Size(89, 17)
        Me.ckbIndicaLote.TabIndex = 1
        Me.ckbIndicaLote.TabStop = False
        Me.ckbIndicaLote.Text = "EXIGE LOTE"
        Me.ckbIndicaLote.UseVisualStyleBackColor = True
        '
        'ckbIndicaSerie
        '
        Me.ckbIndicaSerie.AutoSize = True
        Me.ckbIndicaSerie.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaSerie.ForeColor = System.Drawing.Color.Navy
        Me.ckbIndicaSerie.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaSerie.Location = New System.Drawing.Point(111, 6)
        Me.ckbIndicaSerie.Name = "ckbIndicaSerie"
        Me.ckbIndicaSerie.Size = New System.Drawing.Size(93, 17)
        Me.ckbIndicaSerie.TabIndex = 0
        Me.ckbIndicaSerie.TabStop = False
        Me.ckbIndicaSerie.Text = "EXIGE SERIE"
        Me.ckbIndicaSerie.UseVisualStyleBackColor = True
        '
        'frmProducto
        '
        Me.ClientSize = New System.Drawing.Size(815, 463)
        Me.Name = "frmProducto"
        Me.Text = " Mantenimiento de Productos"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents ckbIndicaNuevo As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadVenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadCompra As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoExistencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionCompra As System.Windows.Forms.TextBox
    Friend WithEvents cmbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoAntiguo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPartidaArancelaria As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbProcedencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionAmpliada As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaValidaStock As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaAfecto As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaVencimiento As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaLote As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaSerie As System.Windows.Forms.CheckBox

End Class
