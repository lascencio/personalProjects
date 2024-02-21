<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacionDetalleSeries
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperacionDetalleSeries))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.gvSeries = New System.Windows.Forms.DataGridView()
        Me.EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_MODIFICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTE_CONTROL_SERIES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNumeroSerie = New System.Windows.Forms.Label()
        Me.txtNumeroSerie = New System.Windows.Forms.TextBox()
        Me.txtCantidadAtendida = New System.Windows.Forms.TextBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ELIMINAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Label4.Location = New System.Drawing.Point(12, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 21)
        Me.Label4.TabIndex = 5
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
        Me.txtCantidad.Location = New System.Drawing.Point(171, 6)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(44, 21)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TabStop = False
        Me.txtCantidad.Tag = "E"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gvSeries
        '
        Me.gvSeries.AllowUserToAddRows = False
        Me.gvSeries.AllowUserToDeleteRows = False
        Me.gvSeries.AllowUserToResizeRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvSeries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.gvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvSeries.ColumnHeadersVisible = False
        Me.gvSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EMPRESA, Me.OPERACION, Me.PRODUCTO, Me.NUMERO_SERIE, Me.ESTADO, Me.USUARIO_REGISTRO, Me.FECHA_REGISTRO, Me.USUARIO_MODIFICA, Me.FECHA_MODIFICA, Me.EXISTE_CONTROL_SERIES, Me.ELIMINAR})
        Me.gvSeries.EnableHeadersVisualStyles = False
        Me.gvSeries.Location = New System.Drawing.Point(12, 78)
        Me.gvSeries.MultiSelect = False
        Me.gvSeries.Name = "gvSeries"
        Me.gvSeries.ReadOnly = True
        Me.gvSeries.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvSeries.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSeries.Size = New System.Drawing.Size(296, 467)
        Me.gvSeries.TabIndex = 0
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
        'OPERACION
        '
        Me.OPERACION.DataPropertyName = "OPERACION"
        Me.OPERACION.HeaderText = "OPERACION"
        Me.OPERACION.Name = "OPERACION"
        Me.OPERACION.ReadOnly = True
        Me.OPERACION.Visible = False
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
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NUMERO_SERIE.DefaultCellStyle = DataGridViewCellStyle11
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
        'USUARIO_REGISTRO
        '
        Me.USUARIO_REGISTRO.DataPropertyName = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.HeaderText = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.Name = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.ReadOnly = True
        Me.USUARIO_REGISTRO.Visible = False
        '
        'FECHA_REGISTRO
        '
        Me.FECHA_REGISTRO.DataPropertyName = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.HeaderText = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.Name = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.ReadOnly = True
        Me.FECHA_REGISTRO.Visible = False
        '
        'USUARIO_MODIFICA
        '
        Me.USUARIO_MODIFICA.DataPropertyName = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.HeaderText = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.Name = "USUARIO_MODIFICA"
        Me.USUARIO_MODIFICA.ReadOnly = True
        Me.USUARIO_MODIFICA.Visible = False
        '
        'FECHA_MODIFICA
        '
        Me.FECHA_MODIFICA.DataPropertyName = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.HeaderText = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.Name = "FECHA_MODIFICA"
        Me.FECHA_MODIFICA.ReadOnly = True
        Me.FECHA_MODIFICA.Visible = False
        '
        'EXISTE_CONTROL_SERIES
        '
        Me.EXISTE_CONTROL_SERIES.DataPropertyName = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.HeaderText = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.Name = "EXISTE_CONTROL_SERIES"
        Me.EXISTE_CONTROL_SERIES.ReadOnly = True
        Me.EXISTE_CONTROL_SERIES.Visible = False
        '
        'lblNumeroSerie
        '
        Me.lblNumeroSerie.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSerie.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblNumeroSerie.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroSerie.Location = New System.Drawing.Point(12, 52)
        Me.lblNumeroSerie.Name = "lblNumeroSerie"
        Me.lblNumeroSerie.Size = New System.Drawing.Size(120, 21)
        Me.lblNumeroSerie.TabIndex = 7
        Me.lblNumeroSerie.Text = "NUMERO DE SERIE"
        Me.lblNumeroSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroSerie
        '
        Me.txtNumeroSerie.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSerie.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroSerie.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNumeroSerie.Location = New System.Drawing.Point(134, 52)
        Me.txtNumeroSerie.MaxLength = 20
        Me.txtNumeroSerie.Name = "txtNumeroSerie"
        Me.txtNumeroSerie.Size = New System.Drawing.Size(174, 21)
        Me.txtNumeroSerie.TabIndex = 2
        '
        'txtCantidadAtendida
        '
        Me.txtCantidadAtendida.BackColor = System.Drawing.Color.Moccasin
        Me.txtCantidadAtendida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadAtendida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadAtendida.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadAtendida.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadAtendida.Location = New System.Drawing.Point(171, 28)
        Me.txtCantidadAtendida.MaxLength = 10
        Me.txtCantidadAtendida.Name = "txtCantidadAtendida"
        Me.txtCantidadAtendida.Size = New System.Drawing.Size(44, 21)
        Me.txtCantidadAtendida.TabIndex = 4
        Me.txtCantidadAtendida.TabStop = False
        Me.txtCantidadAtendida.Tag = "E"
        Me.txtCantidadAtendida.Text = "0"
        Me.txtCantidadAtendida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.BusinessManager.My.Resources.Resources.smallFail
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 24
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(265, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(43, 43)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.UseVisualStyleBackColor = False
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "CANTIDAD ATENDIDA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmOperacionDetalleSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 553)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtCantidadAtendida)
        Me.Controls.Add(Me.lblNumeroSerie)
        Me.Controls.Add(Me.txtNumeroSerie)
        Me.Controls.Add(Me.gvSeries)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCantidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOperacionDetalleSeries"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "REGISTRAR NUMEROS DE SERIE"
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents gvSeries As System.Windows.Forms.DataGridView
    Friend WithEvents lblNumeroSerie As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadAtendida As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_MODIFICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_MODIFICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXISTE_CONTROL_SERIES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ELIMINAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
