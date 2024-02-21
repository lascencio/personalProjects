<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaDetalleComponentesSeries
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaDetalleComponentesSeries))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidadSolicitada = New System.Windows.Forms.TextBox()
        Me.gvSeries = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_CONTROL_SERIES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lblNumeroSerie = New System.Windows.Forms.Label()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidadAtendida = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtCodigoCompra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcionAmpliada = New System.Windows.Forms.TextBox()
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CANTIDAD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCantidadSolicitada
        '
        Me.txtCantidadSolicitada.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadSolicitada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadSolicitada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadSolicitada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadSolicitada.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadSolicitada.Location = New System.Drawing.Point(12, 112)
        Me.txtCantidadSolicitada.MaxLength = 10
        Me.txtCantidadSolicitada.Name = "txtCantidadSolicitada"
        Me.txtCantidadSolicitada.Size = New System.Drawing.Size(74, 21)
        Me.txtCantidadSolicitada.TabIndex = 5
        Me.txtCantidadSolicitada.TabStop = False
        Me.txtCantidadSolicitada.Tag = "E"
        Me.txtCantidadSolicitada.Text = "0"
        Me.txtCantidadSolicitada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.gvSeries.ColumnHeadersVisible = False
        Me.gvSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.VENTA, Me.PRODUCTO, Me.NUMERO_SERIE, Me.ESTADO, Me.EXISTE_CONTROL_SERIES, Me.ELIMINAR})
        Me.gvSeries.EnableHeadersVisualStyles = False
        Me.gvSeries.Location = New System.Drawing.Point(12, 136)
        Me.gvSeries.MultiSelect = False
        Me.gvSeries.Name = "gvSeries"
        Me.gvSeries.ReadOnly = True
        Me.gvSeries.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvSeries.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSeries.Size = New System.Drawing.Size(301, 398)
        Me.gvSeries.TabIndex = 1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NUMERO_SERIE.DefaultCellStyle = DataGridViewCellStyle2
        Me.NUMERO_SERIE.HeaderText = "NUMERO SERIE"
        Me.NUMERO_SERIE.Name = "NUMERO_SERIE"
        Me.NUMERO_SERIE.ReadOnly = True
        Me.NUMERO_SERIE.Width = 255
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
        'lblNumeroSerie
        '
        Me.lblNumeroSerie.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSerie.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNumeroSerie.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroSerie.Location = New System.Drawing.Point(162, 93)
        Me.lblNumeroSerie.Name = "lblNumeroSerie"
        Me.lblNumeroSerie.Size = New System.Drawing.Size(108, 18)
        Me.lblNumeroSerie.TabIndex = 11
        Me.lblNumeroSerie.Text = "NRO. DE SERIE"
        Me.lblNumeroSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroSerie.Location = New System.Drawing.Point(162, 112)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.Size = New System.Drawing.Size(108, 21)
        Me.txtNumeroSerie.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(88, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ATENDIDA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCantidadAtendida
        '
        Me.txtCantidadAtendida.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadAtendida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadAtendida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadAtendida.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadAtendida.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadAtendida.Location = New System.Drawing.Point(88, 112)
        Me.txtCantidadAtendida.MaxLength = 10
        Me.txtCantidadAtendida.Name = "txtCantidadAtendida"
        Me.txtCantidadAtendida.Size = New System.Drawing.Size(72, 21)
        Me.txtCantidadAtendida.TabIndex = 6
        Me.txtCantidadAtendida.TabStop = False
        Me.txtCantidadAtendida.Tag = "E"
        Me.txtCantidadAtendida.Text = "0"
        Me.txtCantidadAtendida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(272, 93)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Chocolate
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(12, 9)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(130, 18)
        Me.Label37.TabIndex = 7
        Me.Label37.Text = "CODIGO COMPRA"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoCompra
        '
        Me.txtCodigoCompra.BackColor = System.Drawing.Color.Moccasin
        Me.txtCodigoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCompra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCompra.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCodigoCompra.Location = New System.Drawing.Point(12, 28)
        Me.txtCodigoCompra.MaxLength = 20
        Me.txtCodigoCompra.Name = "txtCodigoCompra"
        Me.txtCodigoCompra.Size = New System.Drawing.Size(130, 21)
        Me.txtCodigoCompra.TabIndex = 3
        Me.txtCodigoCompra.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Chocolate
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "DESCRIPCION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescripcionAmpliada
        '
        Me.txtDescripcionAmpliada.BackColor = System.Drawing.Color.Moccasin
        Me.txtDescripcionAmpliada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionAmpliada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionAmpliada.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionAmpliada.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDescripcionAmpliada.Location = New System.Drawing.Point(12, 69)
        Me.txtDescripcionAmpliada.MaxLength = 200
        Me.txtDescripcionAmpliada.Name = "txtDescripcionAmpliada"
        Me.txtDescripcionAmpliada.Size = New System.Drawing.Size(300, 21)
        Me.txtDescripcionAmpliada.TabIndex = 4
        Me.txtDescripcionAmpliada.TabStop = False
        '
        'frmVentaDetalleComponentesSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 546)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescripcionAmpliada)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtCodigoCompra)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCantidadAtendida)
        Me.Controls.Add(Me.lblNumeroSerie)
        Me.Controls.Add(Me.txtNumeroSerie)
        Me.Controls.Add(Me.gvSeries)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCantidadSolicitada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentaDetalleComponentesSeries"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "REGISTRAR NUMEROS DE SERIE"
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadSolicitada As System.Windows.Forms.TextBox
    Friend WithEvents gvSeries As System.Windows.Forms.DataGridView
    Friend WithEvents lblNumeroSerie As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadAtendida As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_CONTROL_SERIES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionAmpliada As System.Windows.Forms.TextBox
End Class
