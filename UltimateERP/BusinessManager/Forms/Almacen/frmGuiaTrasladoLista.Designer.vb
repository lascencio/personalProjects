<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaTrasladoLista
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvGuias = New System.Windows.Forms.DataGridView()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.GUIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA_TRASLADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA_CUO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvGuias
        '
        Me.gvGuias.AllowUserToAddRows = False
        Me.gvGuias.AllowUserToDeleteRows = False
        Me.gvGuias.AllowUserToOrderColumns = True
        Me.gvGuias.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvGuias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvGuias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUIA, Me.ALMACEN, Me.ALMACEN_DESCRIPCION, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.COMPROBANTE_FECHA, Me.COMPROBANTE_FECHA_TRASLADO, Me.USUARIO_REGISTRO, Me.COMENTARIO, Me.REFERENCIA_CUO})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvGuias.DefaultCellStyle = DataGridViewCellStyle6
        Me.gvGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvGuias.Location = New System.Drawing.Point(0, 56)
        Me.gvGuias.MultiSelect = False
        Me.gvGuias.Name = "gvGuias"
        Me.gvGuias.ReadOnly = True
        Me.gvGuias.RowHeadersVisible = False
        Me.gvGuias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvGuias.Size = New System.Drawing.Size(780, 501)
        Me.gvGuias.TabIndex = 13
        Me.gvGuias.TabStop = False
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.Label3)
        Me.pnlPrincipal.Controls.Add(Me.Label2)
        Me.pnlPrincipal.Controls.Add(Me.cmbMes)
        Me.pnlPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(780, 56)
        Me.pnlPrincipal.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(657, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(578, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "EJERCICIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(657, 29)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 28
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(578, 29)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 27
        Me.cmbEjercicio.TabStop = False
        '
        'GUIA
        '
        Me.GUIA.DataPropertyName = "GUIA"
        Me.GUIA.HeaderText = "GUIA"
        Me.GUIA.Name = "GUIA"
        Me.GUIA.ReadOnly = True
        Me.GUIA.Visible = False
        '
        'ALMACEN
        '
        Me.ALMACEN.DataPropertyName = "ALMACEN"
        Me.ALMACEN.HeaderText = "ALMACEN"
        Me.ALMACEN.Name = "ALMACEN"
        Me.ALMACEN.ReadOnly = True
        Me.ALMACEN.Visible = False
        '
        'ALMACEN_DESCRIPCION
        '
        Me.ALMACEN_DESCRIPCION.DataPropertyName = "ALMACEN_DESCRIPCION"
        Me.ALMACEN_DESCRIPCION.HeaderText = "ALMACEN"
        Me.ALMACEN_DESCRIPCION.Name = "ALMACEN_DESCRIPCION"
        Me.ALMACEN_DESCRIPCION.ReadOnly = True
        Me.ALMACEN_DESCRIPCION.Width = 180
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COMPROBANTE_SERIE.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.Width = 40
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COMPROBANTE_NUMERO.DefaultCellStyle = DataGridViewCellStyle3
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        Me.COMPROBANTE_NUMERO.Width = 80
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle4
        Me.COMPROBANTE_FECHA.HeaderText = "F_EMISION"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.Width = 75
        '
        'COMPROBANTE_FECHA_TRASLADO
        '
        Me.COMPROBANTE_FECHA_TRASLADO.DataPropertyName = "COMPROBANTE_FECHA_TRASLADO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.COMPROBANTE_FECHA_TRASLADO.DefaultCellStyle = DataGridViewCellStyle5
        Me.COMPROBANTE_FECHA_TRASLADO.HeaderText = "F_TRASLADO"
        Me.COMPROBANTE_FECHA_TRASLADO.Name = "COMPROBANTE_FECHA_TRASLADO"
        Me.COMPROBANTE_FECHA_TRASLADO.ReadOnly = True
        Me.COMPROBANTE_FECHA_TRASLADO.Width = 80
        '
        'USUARIO_REGISTRO
        '
        Me.USUARIO_REGISTRO.DataPropertyName = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.HeaderText = "USUARIO"
        Me.USUARIO_REGISTRO.Name = "USUARIO_REGISTRO"
        Me.USUARIO_REGISTRO.ReadOnly = True
        '
        'COMENTARIO
        '
        Me.COMENTARIO.DataPropertyName = "COMENTARIO"
        Me.COMENTARIO.HeaderText = "COMENTARIO"
        Me.COMENTARIO.Name = "COMENTARIO"
        Me.COMENTARIO.ReadOnly = True
        Me.COMENTARIO.Width = 200
        '
        'REFERENCIA_CUO
        '
        Me.REFERENCIA_CUO.DataPropertyName = "REFERENCIA_CUO"
        Me.REFERENCIA_CUO.HeaderText = "REFERENCIA_CUO"
        Me.REFERENCIA_CUO.Name = "REFERENCIA_CUO"
        Me.REFERENCIA_CUO.ReadOnly = True
        Me.REFERENCIA_CUO.Visible = False
        '
        'frmGuiaTrasladoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 557)
        Me.Controls.Add(Me.gvGuias)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaTrasladoLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE GUIAS DE TRASLADO"
        CType(Me.gvGuias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvGuias As System.Windows.Forms.DataGridView
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents GUIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA_TRASLADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA_CUO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
