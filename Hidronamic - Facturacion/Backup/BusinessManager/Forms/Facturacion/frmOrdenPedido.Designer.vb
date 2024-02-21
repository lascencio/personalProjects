<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPedido
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenPedido))
        Me.ilBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.gvOrdenesPendientes = New System.Windows.Forms.DataGridView
        Me.EMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORDENPEDIDO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGOFECHADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGOBANCODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGOMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGOIMPORTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAGOREFERENCIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.USUARIOREGISTRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHAREGISTRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.USUARIOMODIFICADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHAMODIFICADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORDENPEDIDOPENDIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOrdenPedido = New BusinessManager.dsOrdenPedido
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.gvOrdenPedidoLineas = New System.Windows.Forms.DataGridView
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORDEN_PEDIDO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_AMPLIADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_COMPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INDICA_VALIDA_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRECIO_UNITARIO_ME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IMPORTE_TOTAL_ME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VENTA_LINEA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtPagoReferencia = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPagoImporte = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtOrdenFecha = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPagoFecha = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbPagoMoneda = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbPagoBanco = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbPagoTipo = New System.Windows.Forms.ComboBox
        Me.ckbIndicaPrimeraCompra = New System.Windows.Forms.CheckBox
        Me.ckbIndicaAscenso = New System.Windows.Forms.CheckBox
        Me.ckbIndicaMantenimiento = New System.Windows.Forms.CheckBox
        Me.ckbIndicaCompraExtra = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnDescartar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOrdenPedido = New System.Windows.Forms.TextBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.ckbIndicaAnulado = New System.Windows.Forms.CheckBox
        Me.txtMes = New System.Windows.Forms.TextBox
        Me.txtEjercicio = New System.Windows.Forms.TextBox
        Me.txtVendedorNombre = New System.Windows.Forms.TextBox
        Me.cmbProductos = New System.Windows.Forms.ComboBox
        Me.txtEditado = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtDocumentoNumero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.cmbDocumentoTipo = New System.Windows.Forms.ComboBox
        Me.txtCuentaComercial = New System.Windows.Forms.TextBox
        Me.txtVenta = New System.Windows.Forms.TextBox
        Me.txtVentaLinea = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmbCentroDistribucion = New System.Windows.Forms.ComboBox
        Me.Panel.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.gvOrdenesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORDENPEDIDOPENDIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrdenPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOrdenPedidoLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(1350, 36)
        Me.UC_ToolBar.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label23)
        Me.Panel.Controls.Add(Me.cmbCentroDistribucion)
        Me.Panel.Controls.Add(Me.txtVentaLinea)
        Me.Panel.Controls.Add(Me.txtVenta)
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
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.gvOrdenPedidoLineas)
        Me.Panel.Controls.Add(Me.txtPagoReferencia)
        Me.Panel.Controls.Add(Me.Label14)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.txtPagoImporte)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.txtOrdenFecha)
        Me.Panel.Controls.Add(Me.Label10)
        Me.Panel.Controls.Add(Me.txtPagoFecha)
        Me.Panel.Controls.Add(Me.Label18)
        Me.Panel.Controls.Add(Me.cmbPagoMoneda)
        Me.Panel.Controls.Add(Me.Label9)
        Me.Panel.Controls.Add(Me.cmbPagoBanco)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.cmbPagoTipo)
        Me.Panel.Controls.Add(Me.ckbIndicaPrimeraCompra)
        Me.Panel.Controls.Add(Me.ckbIndicaAscenso)
        Me.Panel.Controls.Add(Me.ckbIndicaMantenimiento)
        Me.Panel.Controls.Add(Me.ckbIndicaCompraExtra)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.btnDescartar)
        Me.Panel.Controls.Add(Me.btnAceptar)
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
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.txtOrdenPedido)
        Me.Panel.Controls.Add(Me.SplitContainer)
        Me.Panel.Size = New System.Drawing.Size(1350, 654)
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
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer.Location = New System.Drawing.Point(920, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.gvOrdenesPendientes)
        Me.SplitContainer.Panel1.Controls.Add(Me.Label17)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.Label19)
        Me.SplitContainer.Size = New System.Drawing.Size(425, 646)
        Me.SplitContainer.SplitterDistance = 193
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 0
        '
        'gvOrdenesPendientes
        '
        Me.gvOrdenesPendientes.AllowUserToAddRows = False
        Me.gvOrdenesPendientes.AllowUserToDeleteRows = False
        Me.gvOrdenesPendientes.AllowUserToOrderColumns = True
        Me.gvOrdenesPendientes.AllowUserToResizeRows = False
        Me.gvOrdenesPendientes.AutoGenerateColumns = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOrdenesPendientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gvOrdenesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOrdenesPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESADataGridViewTextBoxColumn, Me.ORDENPEDIDO, Me.PAGOFECHADataGridViewTextBoxColumn, Me.PAGOBANCODataGridViewTextBoxColumn, Me.PAGOMONEDADataGridViewTextBoxColumn, Me.PAGOIMPORTEDataGridViewTextBoxColumn, Me.PAGOREFERENCIADataGridViewTextBoxColumn, Me.ESTADODataGridViewTextBoxColumn, Me.USUARIOREGISTRODataGridViewTextBoxColumn, Me.FECHAREGISTRODataGridViewTextBoxColumn, Me.USUARIOMODIFICADataGridViewTextBoxColumn, Me.FECHAMODIFICADataGridViewTextBoxColumn})
        Me.gvOrdenesPendientes.DataSource = Me.ORDENPEDIDOPENDIENTESBindingSource
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvOrdenesPendientes.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvOrdenesPendientes.Location = New System.Drawing.Point(1, 21)
        Me.gvOrdenesPendientes.MultiSelect = False
        Me.gvOrdenesPendientes.Name = "gvOrdenesPendientes"
        Me.gvOrdenesPendientes.ReadOnly = True
        Me.gvOrdenesPendientes.RowHeadersVisible = False
        Me.gvOrdenesPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOrdenesPendientes.Size = New System.Drawing.Size(420, 169)
        Me.gvOrdenesPendientes.TabIndex = 91
        Me.gvOrdenesPendientes.TabStop = False
        '
        'EMPRESADataGridViewTextBoxColumn
        '
        Me.EMPRESADataGridViewTextBoxColumn.DataPropertyName = "EMPRESA"
        Me.EMPRESADataGridViewTextBoxColumn.HeaderText = "EMPRESA"
        Me.EMPRESADataGridViewTextBoxColumn.Name = "EMPRESADataGridViewTextBoxColumn"
        Me.EMPRESADataGridViewTextBoxColumn.ReadOnly = True
        Me.EMPRESADataGridViewTextBoxColumn.Visible = False
        '
        'ORDENPEDIDO
        '
        Me.ORDENPEDIDO.DataPropertyName = "ORDEN_PEDIDO"
        Me.ORDENPEDIDO.HeaderText = "PEDIDO"
        Me.ORDENPEDIDO.Name = "ORDENPEDIDO"
        Me.ORDENPEDIDO.ReadOnly = True
        Me.ORDENPEDIDO.Width = 90
        '
        'PAGOFECHADataGridViewTextBoxColumn
        '
        Me.PAGOFECHADataGridViewTextBoxColumn.DataPropertyName = "PAGO_FECHA"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.PAGOFECHADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.PAGOFECHADataGridViewTextBoxColumn.HeaderText = "P_FECHA"
        Me.PAGOFECHADataGridViewTextBoxColumn.Name = "PAGOFECHADataGridViewTextBoxColumn"
        Me.PAGOFECHADataGridViewTextBoxColumn.ReadOnly = True
        Me.PAGOFECHADataGridViewTextBoxColumn.Width = 75
        '
        'PAGOBANCODataGridViewTextBoxColumn
        '
        Me.PAGOBANCODataGridViewTextBoxColumn.DataPropertyName = "PAGO_BANCO"
        Me.PAGOBANCODataGridViewTextBoxColumn.HeaderText = "P_BANCO"
        Me.PAGOBANCODataGridViewTextBoxColumn.Name = "PAGOBANCODataGridViewTextBoxColumn"
        Me.PAGOBANCODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PAGOMONEDADataGridViewTextBoxColumn
        '
        Me.PAGOMONEDADataGridViewTextBoxColumn.DataPropertyName = "PAGO_MONEDA"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PAGOMONEDADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.PAGOMONEDADataGridViewTextBoxColumn.HeaderText = "P_MONEDA"
        Me.PAGOMONEDADataGridViewTextBoxColumn.Name = "PAGOMONEDADataGridViewTextBoxColumn"
        Me.PAGOMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.PAGOMONEDADataGridViewTextBoxColumn.Width = 85
        '
        'PAGOIMPORTEDataGridViewTextBoxColumn
        '
        Me.PAGOIMPORTEDataGridViewTextBoxColumn.DataPropertyName = "PAGO_IMPORTE"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.PAGOIMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.PAGOIMPORTEDataGridViewTextBoxColumn.HeaderText = "P_IMPORTE"
        Me.PAGOIMPORTEDataGridViewTextBoxColumn.Name = "PAGOIMPORTEDataGridViewTextBoxColumn"
        Me.PAGOIMPORTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PAGOREFERENCIADataGridViewTextBoxColumn
        '
        Me.PAGOREFERENCIADataGridViewTextBoxColumn.DataPropertyName = "PAGO_REFERENCIA"
        Me.PAGOREFERENCIADataGridViewTextBoxColumn.HeaderText = "REFERENCIA"
        Me.PAGOREFERENCIADataGridViewTextBoxColumn.Name = "PAGOREFERENCIADataGridViewTextBoxColumn"
        Me.PAGOREFERENCIADataGridViewTextBoxColumn.ReadOnly = True
        '
        'ESTADODataGridViewTextBoxColumn
        '
        Me.ESTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.ESTADODataGridViewTextBoxColumn.HeaderText = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.Name = "ESTADODataGridViewTextBoxColumn"
        Me.ESTADODataGridViewTextBoxColumn.ReadOnly = True
        Me.ESTADODataGridViewTextBoxColumn.Width = 75
        '
        'USUARIOREGISTRODataGridViewTextBoxColumn
        '
        Me.USUARIOREGISTRODataGridViewTextBoxColumn.DataPropertyName = "USUARIO_REGISTRO"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.USUARIOREGISTRODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.USUARIOREGISTRODataGridViewTextBoxColumn.HeaderText = "USU_REGISTRO"
        Me.USUARIOREGISTRODataGridViewTextBoxColumn.Name = "USUARIOREGISTRODataGridViewTextBoxColumn"
        Me.USUARIOREGISTRODataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHAREGISTRODataGridViewTextBoxColumn
        '
        Me.FECHAREGISTRODataGridViewTextBoxColumn.DataPropertyName = "FECHA_REGISTRO"
        Me.FECHAREGISTRODataGridViewTextBoxColumn.HeaderText = "FEC_REGISTRO"
        Me.FECHAREGISTRODataGridViewTextBoxColumn.Name = "FECHAREGISTRODataGridViewTextBoxColumn"
        Me.FECHAREGISTRODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAREGISTRODataGridViewTextBoxColumn.Width = 120
        '
        'USUARIOMODIFICADataGridViewTextBoxColumn
        '
        Me.USUARIOMODIFICADataGridViewTextBoxColumn.DataPropertyName = "USUARIO_MODIFICA"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.USUARIOMODIFICADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.USUARIOMODIFICADataGridViewTextBoxColumn.HeaderText = "USU_MODIFICA"
        Me.USUARIOMODIFICADataGridViewTextBoxColumn.Name = "USUARIOMODIFICADataGridViewTextBoxColumn"
        Me.USUARIOMODIFICADataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHAMODIFICADataGridViewTextBoxColumn
        '
        Me.FECHAMODIFICADataGridViewTextBoxColumn.DataPropertyName = "FECHA_MODIFICA"
        Me.FECHAMODIFICADataGridViewTextBoxColumn.HeaderText = "FEC_MODIFICA"
        Me.FECHAMODIFICADataGridViewTextBoxColumn.Name = "FECHAMODIFICADataGridViewTextBoxColumn"
        Me.FECHAMODIFICADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAMODIFICADataGridViewTextBoxColumn.Width = 120
        '
        'ORDENPEDIDOPENDIENTESBindingSource
        '
        Me.ORDENPEDIDOPENDIENTESBindingSource.DataMember = "ORDEN_PEDIDO_PENDIENTES"
        Me.ORDENPEDIDOPENDIENTESBindingSource.DataSource = Me.DsOrdenPedido
        '
        'DsOrdenPedido
        '
        Me.DsOrdenPedido.DataSetName = "dsOrdenPedido"
        Me.DsOrdenPedido.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(423, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "PEDIDOS POR FACTURAR"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(423, 20)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "PEDIDOS FACTURADOS"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(673, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(232, 20)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "ORDEN DE PEDIDO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gvOrdenPedidoLineas
        '
        Me.gvOrdenPedidoLineas.AllowUserToAddRows = False
        Me.gvOrdenPedidoLineas.AllowUserToDeleteRows = False
        Me.gvOrdenPedidoLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.gvOrdenPedidoLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOrdenPedidoLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvOrdenPedidoLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOrdenPedidoLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.ORDEN_PEDIDO, Me.PRODUCTO, Me.DESCRIPCION, Me.DESCRIPCION_AMPLIADA, Me.INDICA_COMPUESTO, Me.INDICA_VALIDA_STOCK, Me.CANTIDAD, Me.PRECIO_UNITARIO_ME, Me.IMPORTE_TOTAL_ME, Me.VENTA, Me.VENTA_LINEA})
        Me.gvOrdenPedidoLineas.Enabled = False
        Me.gvOrdenPedidoLineas.EnableHeadersVisualStyles = False
        Me.gvOrdenPedidoLineas.Location = New System.Drawing.Point(12, 245)
        Me.gvOrdenPedidoLineas.MultiSelect = False
        Me.gvOrdenPedidoLineas.Name = "gvOrdenPedidoLineas"
        Me.gvOrdenPedidoLineas.ReadOnly = True
        Me.gvOrdenPedidoLineas.RowHeadersVisible = False
        Me.gvOrdenPedidoLineas.RowHeadersWidth = 13
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.OldLace
        Me.gvOrdenPedidoLineas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gvOrdenPedidoLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOrdenPedidoLineas.Size = New System.Drawing.Size(893, 396)
        Me.gvOrdenPedidoLineas.TabIndex = 54
        Me.gvOrdenPedidoLineas.TabStop = False
        '
        'EMPRESA
        '
        Me.EMPRESA.DataPropertyName = "EMPRESA"
        Me.EMPRESA.HeaderText = "EMPRESA"
        Me.EMPRESA.Name = "EMPRESA"
        Me.EMPRESA.ReadOnly = True
        Me.EMPRESA.Visible = False
        '
        'ORDEN_PEDIDO
        '
        Me.ORDEN_PEDIDO.DataPropertyName = "ORDEN_PEDIDO"
        Me.ORDEN_PEDIDO.HeaderText = "ORDEN_PEDIDO"
        Me.ORDEN_PEDIDO.Name = "ORDEN_PEDIDO"
        Me.ORDEN_PEDIDO.ReadOnly = True
        Me.ORDEN_PEDIDO.Visible = False
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 70
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Visible = False
        '
        'DESCRIPCION_AMPLIADA
        '
        Me.DESCRIPCION_AMPLIADA.DataPropertyName = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.HeaderText = "DESCRIPCION DEL PRODUCTO"
        Me.DESCRIPCION_AMPLIADA.Name = "DESCRIPCION_AMPLIADA"
        Me.DESCRIPCION_AMPLIADA.ReadOnly = True
        Me.DESCRIPCION_AMPLIADA.Width = 570
        '
        'INDICA_COMPUESTO
        '
        Me.INDICA_COMPUESTO.DataPropertyName = "INDICA_COMPUESTO"
        Me.INDICA_COMPUESTO.HeaderText = "INDICA_COMPUESTO"
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
        Me.CANTIDAD.Width = 55
        '
        'PRECIO_UNITARIO_ME
        '
        Me.PRECIO_UNITARIO_ME.DataPropertyName = "PRECIO_UNITARIO_ME"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PRECIO_UNITARIO_ME.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRECIO_UNITARIO_ME.HeaderText = "P.  UNIT."
        Me.PRECIO_UNITARIO_ME.MinimumWidth = 80
        Me.PRECIO_UNITARIO_ME.Name = "PRECIO_UNITARIO_ME"
        Me.PRECIO_UNITARIO_ME.ReadOnly = True
        Me.PRECIO_UNITARIO_ME.Width = 90
        '
        'IMPORTE_TOTAL_ME
        '
        Me.IMPORTE_TOTAL_ME.DataPropertyName = "IMPORTE_TOTAL_ME"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.IMPORTE_TOTAL_ME.DefaultCellStyle = DataGridViewCellStyle5
        Me.IMPORTE_TOTAL_ME.HeaderText = "P. TOTAL"
        Me.IMPORTE_TOTAL_ME.MinimumWidth = 90
        Me.IMPORTE_TOTAL_ME.Name = "IMPORTE_TOTAL_ME"
        Me.IMPORTE_TOTAL_ME.ReadOnly = True
        Me.IMPORTE_TOTAL_ME.Width = 90
        '
        'VENTA
        '
        Me.VENTA.DataPropertyName = "VENTA"
        Me.VENTA.HeaderText = "VENTA"
        Me.VENTA.Name = "VENTA"
        Me.VENTA.ReadOnly = True
        Me.VENTA.Visible = False
        '
        'VENTA_LINEA
        '
        Me.VENTA_LINEA.DataPropertyName = "VENTA_LINEA"
        Me.VENTA_LINEA.HeaderText = "VENTA_LINEA"
        Me.VENTA_LINEA.Name = "VENTA_LINEA"
        Me.VENTA_LINEA.ReadOnly = True
        Me.VENTA_LINEA.Visible = False
        '
        'txtPagoReferencia
        '
        Me.txtPagoReferencia.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPagoReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagoReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagoReferencia.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoReferencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPagoReferencia.Location = New System.Drawing.Point(698, 157)
        Me.txtPagoReferencia.MaxLength = 10
        Me.txtPagoReferencia.Name = "txtPagoReferencia"
        Me.txtPagoReferencia.Size = New System.Drawing.Size(207, 21)
        Me.txtPagoReferencia.TabIndex = 8
        Me.txtPagoReferencia.Tag = ""
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Chocolate
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(698, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(207, 18)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "REFERENCIA"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Chocolate
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(608, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 18)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "IMPORTE U$"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPagoImporte
        '
        Me.txtPagoImporte.BackColor = System.Drawing.Color.Moccasin
        Me.txtPagoImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagoImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagoImporte.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoImporte.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPagoImporte.Location = New System.Drawing.Point(608, 157)
        Me.txtPagoImporte.MaxLength = 10
        Me.txtPagoImporte.Name = "txtPagoImporte"
        Me.txtPagoImporte.ReadOnly = True
        Me.txtPagoImporte.Size = New System.Drawing.Size(88, 21)
        Me.txtPagoImporte.TabIndex = 9
        Me.txtPagoImporte.TabStop = False
        Me.txtPagoImporte.Tag = "D"
        Me.txtPagoImporte.Text = "0.00"
        Me.txtPagoImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Chocolate
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(111, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 18)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "FEC. PEDIDO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrdenFecha
        '
        Me.txtOrdenFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOrdenFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrdenFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrdenFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrdenFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtOrdenFecha.Location = New System.Drawing.Point(111, 31)
        Me.txtOrdenFecha.MaxLength = 10
        Me.txtOrdenFecha.Name = "txtOrdenFecha"
        Me.txtOrdenFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtOrdenFecha.TabIndex = 0
        Me.txtOrdenFecha.Tag = "F"
        Me.txtOrdenFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Chocolate
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(515, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 18)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "FEC. PAGO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPagoFecha
        '
        Me.txtPagoFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPagoFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagoFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagoFecha.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPagoFecha.Location = New System.Drawing.Point(515, 157)
        Me.txtPagoFecha.MaxLength = 10
        Me.txtPagoFecha.Name = "txtPagoFecha"
        Me.txtPagoFecha.Size = New System.Drawing.Size(91, 21)
        Me.txtPagoFecha.TabIndex = 7
        Me.txtPagoFecha.Tag = "F"
        Me.txtPagoFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Chocolate
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(384, 138)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 18)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "MONEDA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPagoMoneda
        '
        Me.cmbPagoMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPagoMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPagoMoneda.BackColor = System.Drawing.Color.Azure
        Me.cmbPagoMoneda.DisplayMember = "DESCRIPCION"
        Me.cmbPagoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagoMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPagoMoneda.FormattingEnabled = True
        Me.cmbPagoMoneda.Location = New System.Drawing.Point(384, 157)
        Me.cmbPagoMoneda.Name = "cmbPagoMoneda"
        Me.cmbPagoMoneda.Size = New System.Drawing.Size(129, 21)
        Me.cmbPagoMoneda.TabIndex = 6
        Me.cmbPagoMoneda.ValueMember = "CODIGO"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Chocolate
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(215, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(167, 18)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "INSTITUCION FINANCIERA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPagoBanco
        '
        Me.cmbPagoBanco.BackColor = System.Drawing.Color.Azure
        Me.cmbPagoBanco.DisplayMember = "DESCRIPCION"
        Me.cmbPagoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagoBanco.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPagoBanco.FormattingEnabled = True
        Me.cmbPagoBanco.Location = New System.Drawing.Point(215, 157)
        Me.cmbPagoBanco.Name = "cmbPagoBanco"
        Me.cmbPagoBanco.Size = New System.Drawing.Size(167, 21)
        Me.cmbPagoBanco.TabIndex = 5
        Me.cmbPagoBanco.ValueMember = "CODIGO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Chocolate
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(12, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(201, 18)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "MODALIDAD DE PAGO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPagoTipo
        '
        Me.cmbPagoTipo.BackColor = System.Drawing.Color.Azure
        Me.cmbPagoTipo.DisplayMember = "DESCRIPCION"
        Me.cmbPagoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagoTipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbPagoTipo.FormattingEnabled = True
        Me.cmbPagoTipo.Location = New System.Drawing.Point(12, 157)
        Me.cmbPagoTipo.Name = "cmbPagoTipo"
        Me.cmbPagoTipo.Size = New System.Drawing.Size(201, 21)
        Me.cmbPagoTipo.TabIndex = 4
        Me.cmbPagoTipo.ValueMember = "CODIGO"
        '
        'ckbIndicaPrimeraCompra
        '
        Me.ckbIndicaPrimeraCompra.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaPrimeraCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaPrimeraCompra.ForeColor = System.Drawing.Color.Black
        Me.ckbIndicaPrimeraCompra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaPrimeraCompra.Location = New System.Drawing.Point(388, 15)
        Me.ckbIndicaPrimeraCompra.Name = "ckbIndicaPrimeraCompra"
        Me.ckbIndicaPrimeraCompra.Size = New System.Drawing.Size(140, 18)
        Me.ckbIndicaPrimeraCompra.TabIndex = 11
        Me.ckbIndicaPrimeraCompra.TabStop = False
        Me.ckbIndicaPrimeraCompra.Text = "PRIMERA COMPRA"
        Me.ckbIndicaPrimeraCompra.UseVisualStyleBackColor = True
        '
        'ckbIndicaAscenso
        '
        Me.ckbIndicaAscenso.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAscenso.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAscenso.ForeColor = System.Drawing.Color.Black
        Me.ckbIndicaAscenso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAscenso.Location = New System.Drawing.Point(388, 34)
        Me.ckbIndicaAscenso.Name = "ckbIndicaAscenso"
        Me.ckbIndicaAscenso.Size = New System.Drawing.Size(140, 18)
        Me.ckbIndicaAscenso.TabIndex = 12
        Me.ckbIndicaAscenso.TabStop = False
        Me.ckbIndicaAscenso.Text = "ASCENSO"
        Me.ckbIndicaAscenso.UseVisualStyleBackColor = True
        '
        'ckbIndicaMantenimiento
        '
        Me.ckbIndicaMantenimiento.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaMantenimiento.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaMantenimiento.ForeColor = System.Drawing.Color.Black
        Me.ckbIndicaMantenimiento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaMantenimiento.Location = New System.Drawing.Point(537, 15)
        Me.ckbIndicaMantenimiento.Name = "ckbIndicaMantenimiento"
        Me.ckbIndicaMantenimiento.Size = New System.Drawing.Size(140, 18)
        Me.ckbIndicaMantenimiento.TabIndex = 13
        Me.ckbIndicaMantenimiento.TabStop = False
        Me.ckbIndicaMantenimiento.Text = "MANTENIMIENTO"
        Me.ckbIndicaMantenimiento.UseVisualStyleBackColor = True
        '
        'ckbIndicaCompraExtra
        '
        Me.ckbIndicaCompraExtra.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaCompraExtra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaCompraExtra.ForeColor = System.Drawing.Color.Black
        Me.ckbIndicaCompraExtra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaCompraExtra.Location = New System.Drawing.Point(537, 34)
        Me.ckbIndicaCompraExtra.Name = "ckbIndicaCompraExtra"
        Me.ckbIndicaCompraExtra.Size = New System.Drawing.Size(140, 18)
        Me.ckbIndicaCompraExtra.TabIndex = 14
        Me.ckbIndicaCompraExtra.TabStop = False
        Me.ckbIndicaCompraExtra.Text = "COMPRA EXTRA"
        Me.ckbIndicaCompraExtra.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(12, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(893, 18)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "DETALLES DEL PEDIDO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDescartar
        '
        Me.btnDescartar.BackgroundImage = CType(resources.GetObject("btnDescartar.BackgroundImage"), System.Drawing.Image)
        Me.btnDescartar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDescartar.ImageIndex = 2
        Me.btnDescartar.ImageList = Me.ilBotones
        Me.btnDescartar.Location = New System.Drawing.Point(865, 202)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(40, 40)
        Me.btnDescartar.TabIndex = 51
        Me.btnDescartar.TabStop = False
        Me.btnDescartar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ilBotones
        Me.btnAceptar.Location = New System.Drawing.Point(824, 203)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(40, 40)
        Me.btnAceptar.TabIndex = 50
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(729, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 43
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
        Me.txtPrecioTotal.Location = New System.Drawing.Point(729, 222)
        Me.txtPrecioTotal.MaxLength = 10
        Me.txtPrecioTotal.Name = "txtPrecioTotal"
        Me.txtPrecioTotal.ReadOnly = True
        Me.txtPrecioTotal.Size = New System.Drawing.Size(90, 21)
        Me.txtPrecioTotal.TabIndex = 53
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
        Me.Label6.Location = New System.Drawing.Point(556, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 18)
        Me.Label6.TabIndex = 41
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
        Me.txtCantidad.Location = New System.Drawing.Point(556, 222)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(81, 21)
        Me.txtCantidad.TabIndex = 49
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
        Me.Label20.Location = New System.Drawing.Point(638, 203)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 18)
        Me.Label20.TabIndex = 42
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
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(638, 222)
        Me.txtPrecioUnitario.MaxLength = 10
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.ReadOnly = True
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(90, 21)
        Me.txtPrecioUnitario.TabIndex = 52
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
        Me.Label4.Location = New System.Drawing.Point(95, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(460, 18)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "DESCRIPCION DEL PRODUCTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 18)
        Me.Label5.TabIndex = 39
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
        Me.Label28.Location = New System.Drawing.Point(755, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(150, 18)
        Me.Label28.TabIndex = 26
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
        Me.cmbListaPrecios.Location = New System.Drawing.Point(755, 73)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(150, 21)
        Me.cmbListaPrecios.TabIndex = 18
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
        Me.Label3.Size = New System.Drawing.Size(653, 18)
        Me.Label3.TabIndex = 28
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
        Me.txtVendedorCodigo.TabIndex = 3
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
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "CODIGO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "PEDIDO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrdenPedido
        '
        Me.txtOrdenPedido.BackColor = System.Drawing.Color.Moccasin
        Me.txtOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrdenPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrdenPedido.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrdenPedido.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOrdenPedido.Location = New System.Drawing.Point(12, 31)
        Me.txtOrdenPedido.MaxLength = 8
        Me.txtOrdenPedido.Name = "txtOrdenPedido"
        Me.txtOrdenPedido.ReadOnly = True
        Me.txtOrdenPedido.Size = New System.Drawing.Size(98, 21)
        Me.txtOrdenPedido.TabIndex = 15
        Me.txtOrdenPedido.TabStop = False
        Me.txtOrdenPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProducto.Location = New System.Drawing.Point(12, 222)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(82, 21)
        Me.txtProducto.TabIndex = 47
        Me.txtProducto.Tag = ""
        '
        'ckbIndicaAnulado
        '
        Me.ckbIndicaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.ckbIndicaAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbIndicaAnulado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbIndicaAnulado.ForeColor = System.Drawing.Color.DarkRed
        Me.ckbIndicaAnulado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ckbIndicaAnulado.Location = New System.Drawing.Point(755, 34)
        Me.ckbIndicaAnulado.Name = "ckbIndicaAnulado"
        Me.ckbIndicaAnulado.Size = New System.Drawing.Size(150, 18)
        Me.ckbIndicaAnulado.TabIndex = 10
        Me.ckbIndicaAnulado.TabStop = False
        Me.ckbIndicaAnulado.Text = "PEDIDO ANULADO"
        Me.ckbIndicaAnulado.UseVisualStyleBackColor = True
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.Color.Moccasin
        Me.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMes.Location = New System.Drawing.Point(714, 25)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(10, 21)
        Me.txtMes.TabIndex = 46
        Me.txtMes.TabStop = False
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMes.Visible = False
        '
        'txtEjercicio
        '
        Me.txtEjercicio.BackColor = System.Drawing.Color.Moccasin
        Me.txtEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjercicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEjercicio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjercicio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEjercicio.Location = New System.Drawing.Point(698, 25)
        Me.txtEjercicio.MaxLength = 4
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.ReadOnly = True
        Me.txtEjercicio.Size = New System.Drawing.Size(10, 21)
        Me.txtEjercicio.TabIndex = 36
        Me.txtEjercicio.TabStop = False
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEjercicio.Visible = False
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
        Me.txtVendedorNombre.Size = New System.Drawing.Size(653, 21)
        Me.txtVendedorNombre.TabIndex = 19
        Me.txtVendedorNombre.TabStop = False
        '
        'cmbProductos
        '
        Me.cmbProductos.BackColor = System.Drawing.Color.Azure
        Me.cmbProductos.DisplayMember = "DESCRIPCION_AMPLIADA"
        Me.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductos.Enabled = False
        Me.cmbProductos.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(95, 222)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(460, 21)
        Me.cmbProductos.TabIndex = 48
        Me.cmbProductos.ValueMember = "PRODUCTO"
        '
        'txtEditado
        '
        Me.txtEditado.BackColor = System.Drawing.Color.Moccasin
        Me.txtEditado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEditado.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditado.ForeColor = System.Drawing.Color.DarkRed
        Me.txtEditado.Location = New System.Drawing.Point(1, 222)
        Me.txtEditado.MaxLength = 1
        Me.txtEditado.Name = "txtEditado"
        Me.txtEditado.Size = New System.Drawing.Size(10, 21)
        Me.txtEditado.TabIndex = 44
        Me.txtEditado.TabStop = False
        Me.txtEditado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEditado.Visible = False
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
        Me.Label16.Size = New System.Drawing.Size(570, 18)
        Me.Label16.TabIndex = 25
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
        Me.txtRazonSocial.Size = New System.Drawing.Size(570, 21)
        Me.txtRazonSocial.TabIndex = 17
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
        Me.txtDocumentoNumero.TabIndex = 2
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
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "DOCUMENTO IDENTIDAD"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Chocolate
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(826, 96)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 18)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "T. CAMBIO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTipoCambio.Location = New System.Drawing.Point(826, 115)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 21)
        Me.txtTipoCambio.TabIndex = 20
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.cmbDocumentoTipo.TabIndex = 16
        Me.cmbDocumentoTipo.TabStop = False
        Me.cmbDocumentoTipo.ValueMember = "CODIGO_ITEM"
        '
        'txtCuentaComercial
        '
        Me.txtCuentaComercial.BackColor = System.Drawing.Color.Moccasin
        Me.txtCuentaComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaComercial.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.txtCuentaComercial.Location = New System.Drawing.Point(730, 25)
        Me.txtCuentaComercial.MaxLength = 8
        Me.txtCuentaComercial.Name = "txtCuentaComercial"
        Me.txtCuentaComercial.ReadOnly = True
        Me.txtCuentaComercial.Size = New System.Drawing.Size(10, 21)
        Me.txtCuentaComercial.TabIndex = 37
        Me.txtCuentaComercial.TabStop = False
        Me.txtCuentaComercial.Visible = False
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Moccasin
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVenta.Location = New System.Drawing.Point(1, 245)
        Me.txtVenta.MaxLength = 12
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(10, 21)
        Me.txtVenta.TabIndex = 45
        Me.txtVenta.TabStop = False
        Me.txtVenta.Visible = False
        '
        'txtVentaLinea
        '
        Me.txtVentaLinea.BackColor = System.Drawing.Color.Moccasin
        Me.txtVentaLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVentaLinea.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaLinea.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVentaLinea.Location = New System.Drawing.Point(1, 268)
        Me.txtVentaLinea.MaxLength = 3
        Me.txtVentaLinea.Name = "txtVentaLinea"
        Me.txtVentaLinea.Size = New System.Drawing.Size(10, 21)
        Me.txtVentaLinea.TabIndex = 46
        Me.txtVentaLinea.TabStop = False
        Me.txtVentaLinea.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Chocolate
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(203, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(167, 18)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "CENTRO DISTRIBUCION"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCentroDistribucion
        '
        Me.cmbCentroDistribucion.BackColor = System.Drawing.Color.Azure
        Me.cmbCentroDistribucion.DisplayMember = "DESCRIPCION"
        Me.cmbCentroDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroDistribucion.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbCentroDistribucion.FormattingEnabled = True
        Me.cmbCentroDistribucion.Location = New System.Drawing.Point(203, 31)
        Me.cmbCentroDistribucion.Name = "cmbCentroDistribucion"
        Me.cmbCentroDistribucion.Size = New System.Drawing.Size(167, 21)
        Me.cmbCentroDistribucion.TabIndex = 1
        Me.cmbCentroDistribucion.ValueMember = "CODIGO"
        '
        'frmOrdenPedido
        '
        Me.ClientSize = New System.Drawing.Size(1350, 690)
        Me.Name = "frmOrdenPedido"
        Me.Text = " ORDEN DE PEDIDO"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.gvOrdenesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORDENPEDIDOPENDIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOrdenPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOrdenPedidoLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilBotones As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gvOrdenPedidoLineas As System.Windows.Forms.DataGridView
    Friend WithEvents txtPagoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPagoImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPagoFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbPagoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbPagoBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPagoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ckbIndicaPrimeraCompra As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaAscenso As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaMantenimiento As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIndicaCompraExtra As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents ckbIndicaAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedorNombre As System.Windows.Forms.TextBox
    Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents txtEditado As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuentaComercial As System.Windows.Forms.TextBox
    Friend WithEvents gvOrdenesPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents ORDENPEDIDOPENDIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsOrdenPedido As BusinessManager.dsOrdenPedido
    Friend WithEvents EMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDENPEDIDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOFECHADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOBANCODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOIMPORTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOREFERENCIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIOREGISTRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAREGISTRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIOMODIFICADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMODIFICADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVentaLinea As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroDistribucion As System.Windows.Forms.ComboBox
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDEN_PEDIDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_AMPLIADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_COMPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_VALIDA_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_UNITARIO_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE_TOTAL_ME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA_LINEA As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
