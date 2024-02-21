<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaDetalleSeriesVehiculares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaDetalleSeriesVehiculares))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumeroSerieChasis = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidadAtendida = New System.Windows.Forms.TextBox()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.gvSeries = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE_CHASIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_CONTROL_SERIES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(363, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "COLOR"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(188, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "SERIE DE CHASIS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(13, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "SERIE DE MOTOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumeroSerieChasis
        '
        Me.txtNumeroSerieChasis.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroSerieChasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerieChasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerieChasis.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroSerieChasis.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroSerieChasis.Location = New System.Drawing.Point(188, 76)
        Me.txtNumeroSerieChasis.MaxLength = 20
        Me.txtNumeroSerieChasis.Name = "txtNumeroSerieChasis"
        Me.txtNumeroSerieChasis.Size = New System.Drawing.Size(174, 21)
        Me.txtNumeroSerieChasis.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(13, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 21)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "CANTIDAD ATENDIDA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidadAtendida
        '
        Me.txtCantidadAtendida.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadAtendida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadAtendida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadAtendida.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadAtendida.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadAtendida.Location = New System.Drawing.Point(172, 31)
        Me.txtCantidadAtendida.MaxLength = 10
        Me.txtCantidadAtendida.Name = "txtCantidadAtendida"
        Me.txtCantidadAtendida.Size = New System.Drawing.Size(44, 21)
        Me.txtCantidadAtendida.TabIndex = 7
        Me.txtCantidadAtendida.TabStop = False
        Me.txtCantidadAtendida.Tag = "E"
        Me.txtCantidadAtendida.Text = "0"
        Me.txtCantidadAtendida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroSerie.Location = New System.Drawing.Point(13, 76)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.Size = New System.Drawing.Size(174, 21)
        Me.txtNumeroSerie.TabIndex = 0
        '
        'gvSeries
        '
        Me.gvSeries.AllowUserToAddRows = False
        Me.gvSeries.AllowUserToDeleteRows = False
        Me.gvSeries.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvSeries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.VENTA, Me.PRODUCTO, Me.NUMERO_SERIE, Me.NUMERO_SERIE_CHASIS, Me.COLOR, Me.ESTADO, Me.EXISTE_CONTROL_SERIES, Me.ELIMINAR})
        Me.gvSeries.EnableHeadersVisualStyles = False
        Me.gvSeries.Location = New System.Drawing.Point(13, 103)
        Me.gvSeries.MultiSelect = False
        Me.gvSeries.Name = "gvSeries"
        Me.gvSeries.ReadOnly = True
        Me.gvSeries.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvSeries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSeries.Size = New System.Drawing.Size(529, 418)
        Me.gvSeries.TabIndex = 4
        Me.gvSeries.TabStop = False
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
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Visible = False
        '
        'NUMERO_SERIE
        '
        Me.NUMERO_SERIE.DataPropertyName = "NUMERO_SERIE"
        Me.NUMERO_SERIE.HeaderText = "SERIE DE MOTOR"
        Me.NUMERO_SERIE.Name = "NUMERO_SERIE"
        Me.NUMERO_SERIE.ReadOnly = True
        Me.NUMERO_SERIE.Width = 175
        '
        'NUMERO_SERIE_CHASIS
        '
        Me.NUMERO_SERIE_CHASIS.DataPropertyName = "NUMERO_SERIE_CHASIS"
        Me.NUMERO_SERIE_CHASIS.HeaderText = "SERIE DE CHASIS"
        Me.NUMERO_SERIE_CHASIS.Name = "NUMERO_SERIE_CHASIS"
        Me.NUMERO_SERIE_CHASIS.ReadOnly = True
        Me.NUMERO_SERIE_CHASIS.Width = 175
        '
        'COLOR
        '
        Me.COLOR.DataPropertyName = "COLOR"
        Me.COLOR.HeaderText = "COLOR"
        Me.COLOR.Name = "COLOR"
        Me.COLOR.ReadOnly = True
        Me.COLOR.Width = 145
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'EXISTE_CONTROL_SERIES
        '
        Me.EXISTE_CONTROL_SERIES.DataPropertyName = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.HeaderText = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.Name = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.ReadOnly = True
        Me.EXISTE_CONTROL_SERIES.Visible = False
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(13, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CANTIDAD SOLICITADA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidad.Location = New System.Drawing.Point(172, 9)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(44, 21)
        Me.txtCantidad.TabIndex = 6
        Me.txtCantidad.TabStop = False
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 24
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.Location = New System.Drawing.Point(500, 55)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(42, 42)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(499, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(43, 43)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.Azure
        Me.cmbColor.DisplayMember = "DESCRIPCION"
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(363, 76)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(134, 21)
        Me.cmbColor.TabIndex = 2
        Me.cmbColor.ValueMember = "CODIGO"
        '
        'frmVentaDetalleSeriesVehiculares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumeroSerieChasis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtCantidadAtendida)
        Me.Controls.Add(Me.txtNumeroSerie)
        Me.Controls.Add(Me.gvSeries)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCantidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentaDetalleSeriesVehiculares"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SELECCIONAR  SERIES DE MOTOR Y CHASIS "
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerieChasis As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtCantidadAtendida As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents gvSeries As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE_CHASIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_CONTROL_SERIES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
End Class
