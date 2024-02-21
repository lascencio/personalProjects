<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacionesAlmacenes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvOperacionesAlmacen = New System.Windows.Forms.DataGridView()
        Me.lblTipoOperacion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALMACEN_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_OPERACION_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INDICA_CREDITO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvOperacionesAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvOperacionesAlmacen
        '
        Me.gvOperacionesAlmacen.AllowUserToAddRows = False
        Me.gvOperacionesAlmacen.AllowUserToDeleteRows = False
        Me.gvOperacionesAlmacen.AllowUserToOrderColumns = True
        Me.gvOperacionesAlmacen.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvOperacionesAlmacen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvOperacionesAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperacionesAlmacen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OPERACION, Me.ALMACEN, Me.ALMACEN_DESCRIPCION, Me.FECHA_REGISTRO, Me.TIPO_OPERACION, Me.TIPO_OPERACION_DESCRIPCION, Me.COMENTARIO, Me.INDICA_CREDITO, Me.ESTADO})
        Me.gvOperacionesAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvOperacionesAlmacen.Location = New System.Drawing.Point(0, 60)
        Me.gvOperacionesAlmacen.MultiSelect = False
        Me.gvOperacionesAlmacen.Name = "gvOperacionesAlmacen"
        Me.gvOperacionesAlmacen.ReadOnly = True
        Me.gvOperacionesAlmacen.RowHeadersVisible = False
        Me.gvOperacionesAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOperacionesAlmacen.Size = New System.Drawing.Size(974, 506)
        Me.gvOperacionesAlmacen.TabIndex = 2
        Me.gvOperacionesAlmacen.TabStop = False
        '
        'lblTipoOperacion
        '
        Me.lblTipoOperacion.BackColor = System.Drawing.Color.SteelBlue
        Me.lblTipoOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoOperacion.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.lblTipoOperacion.ForeColor = System.Drawing.Color.White
        Me.lblTipoOperacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoOperacion.Location = New System.Drawing.Point(517, 9)
        Me.lblTipoOperacion.Name = "lblTipoOperacion"
        Me.lblTipoOperacion.Size = New System.Drawing.Size(354, 18)
        Me.lblTipoOperacion.TabIndex = 4
        Me.lblTipoOperacion.Text = "TIPO DE OPERACION"
        Me.lblTipoOperacion.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(233, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ALMACEN"
        Me.Label1.Visible = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(233, 28)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(275, 21)
        Me.cmbAlmacen.TabIndex = 0
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        Me.cmbAlmacen.Visible = False
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoOperacion.DisplayMember = "NOMBRE_LARGO"
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(517, 28)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(354, 21)
        Me.cmbTipoOperacion.TabIndex = 1
        Me.cmbTipoOperacion.ValueMember = "CODIGO_ITEM"
        Me.cmbTipoOperacion.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(86, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 18)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 18)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "EJERCICIO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(86, 28)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 96
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 28)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 95
        Me.cmbEjercicio.TabStop = False
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.Label4)
        Me.pnlPrincipal.Controls.Add(Me.Label3)
        Me.pnlPrincipal.Controls.Add(Me.Label1)
        Me.pnlPrincipal.Controls.Add(Me.lblTipoOperacion)
        Me.pnlPrincipal.Controls.Add(Me.cmbMes)
        Me.pnlPrincipal.Controls.Add(Me.cmbAlmacen)
        Me.pnlPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.pnlPrincipal.Controls.Add(Me.cmbTipoOperacion)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(974, 60)
        Me.pnlPrincipal.TabIndex = 99
        '
        'OPERACION
        '
        Me.OPERACION.DataPropertyName = "OPERACION"
        Me.OPERACION.HeaderText = "OPERACION"
        Me.OPERACION.Name = "OPERACION"
        Me.OPERACION.ReadOnly = True
        Me.OPERACION.Width = 85
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
        Me.ALMACEN_DESCRIPCION.Width = 200
        '
        'FECHA_REGISTRO
        '
        Me.FECHA_REGISTRO.DataPropertyName = "FECHA_REGISTRO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHA_REGISTRO.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHA_REGISTRO.HeaderText = "FECHA"
        Me.FECHA_REGISTRO.Name = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.ReadOnly = True
        Me.FECHA_REGISTRO.Width = 70
        '
        'TIPO_OPERACION
        '
        Me.TIPO_OPERACION.DataPropertyName = "TIPO_OPERACION"
        Me.TIPO_OPERACION.HeaderText = "TIPO_OPERACION"
        Me.TIPO_OPERACION.Name = "TIPO_OPERACION"
        Me.TIPO_OPERACION.ReadOnly = True
        Me.TIPO_OPERACION.Visible = False
        '
        'TIPO_OPERACION_DESCRIPCION
        '
        Me.TIPO_OPERACION_DESCRIPCION.DataPropertyName = "TIPO_OPERACION_DESCRIPCION"
        Me.TIPO_OPERACION_DESCRIPCION.HeaderText = "TIPO OPERACION"
        Me.TIPO_OPERACION_DESCRIPCION.Name = "TIPO_OPERACION_DESCRIPCION"
        Me.TIPO_OPERACION_DESCRIPCION.ReadOnly = True
        Me.TIPO_OPERACION_DESCRIPCION.Width = 200
        '
        'COMENTARIO
        '
        Me.COMENTARIO.DataPropertyName = "COMENTARIO"
        Me.COMENTARIO.HeaderText = "COMENTARIO"
        Me.COMENTARIO.Name = "COMENTARIO"
        Me.COMENTARIO.ReadOnly = True
        Me.COMENTARIO.Width = 350
        '
        'INDICA_CREDITO
        '
        Me.INDICA_CREDITO.DataPropertyName = "INDICA_CREDITO"
        Me.INDICA_CREDITO.HeaderText = "INDICA_CREDITO"
        Me.INDICA_CREDITO.Name = "INDICA_CREDITO"
        Me.INDICA_CREDITO.ReadOnly = True
        Me.INDICA_CREDITO.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle3
        Me.ESTADO.HeaderText = "EST."
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 40
        '
        'frmOperacionesAlmacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 566)
        Me.Controls.Add(Me.gvOperacionesAlmacen)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOperacionesAlmacenes"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OPERACIONES DE ALMACEN"
        CType(Me.gvOperacionesAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvOperacionesAlmacen As System.Windows.Forms.DataGridView
    Friend WithEvents lblTipoOperacion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALMACEN_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_OPERACION_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INDICA_CREDITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
