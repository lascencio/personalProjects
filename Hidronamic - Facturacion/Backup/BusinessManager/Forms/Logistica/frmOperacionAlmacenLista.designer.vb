<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperacionAlmacenLista
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gvOperacionesAlmacen = New System.Windows.Forms.DataGridView
        Me.OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FECHA_REGISTRO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        CType(Me.gvOperacionesAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvOperacionesAlmacen
        '
        Me.gvOperacionesAlmacen.AllowUserToAddRows = False
        Me.gvOperacionesAlmacen.AllowUserToDeleteRows = False
        Me.gvOperacionesAlmacen.AllowUserToOrderColumns = True
        Me.gvOperacionesAlmacen.AllowUserToResizeRows = False
        Me.gvOperacionesAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOperacionesAlmacen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OPERACION, Me.FECHA_REGISTRO, Me.COMENTARIO, Me.ESTADO})
        Me.gvOperacionesAlmacen.Location = New System.Drawing.Point(12, 58)
        Me.gvOperacionesAlmacen.MultiSelect = False
        Me.gvOperacionesAlmacen.Name = "gvOperacionesAlmacen"
        Me.gvOperacionesAlmacen.ReadOnly = True
        Me.gvOperacionesAlmacen.RowHeadersVisible = False
        Me.gvOperacionesAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOperacionesAlmacen.Size = New System.Drawing.Size(859, 489)
        Me.gvOperacionesAlmacen.TabIndex = 2
        Me.gvOperacionesAlmacen.TabStop = False
        '
        'OPERACION
        '
        Me.OPERACION.DataPropertyName = "OPERACION"
        Me.OPERACION.HeaderText = "OPERACION"
        Me.OPERACION.Name = "OPERACION"
        Me.OPERACION.ReadOnly = True
        Me.OPERACION.Width = 85
        '
        'FECHA_REGISTRO
        '
        Me.FECHA_REGISTRO.DataPropertyName = "FECHA_REGISTRO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.FECHA_REGISTRO.DefaultCellStyle = DataGridViewCellStyle7
        Me.FECHA_REGISTRO.HeaderText = "FECHA"
        Me.FECHA_REGISTRO.Name = "FECHA_REGISTRO"
        Me.FECHA_REGISTRO.ReadOnly = True
        Me.FECHA_REGISTRO.Width = 70
        '
        'COMENTARIO
        '
        Me.COMENTARIO.DataPropertyName = "COMENTARIO"
        Me.COMENTARIO.HeaderText = "COMENTARIO"
        Me.COMENTARIO.Name = "COMENTARIO"
        Me.COMENTARIO.ReadOnly = True
        Me.COMENTARIO.Width = 640
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle8
        Me.ESTADO.HeaderText = "EST."
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 40
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(517, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TIPO DE OPERACION"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(233, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ALMACEN"
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(233, 31)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(275, 21)
        Me.cmbAlmacen.TabIndex = 0
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.Color.Azure
        Me.cmbTipoOperacion.DisplayMember = "DESCRIPCION"
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(517, 31)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(354, 21)
        Me.cmbTipoOperacion.TabIndex = 1
        Me.cmbTipoOperacion.ValueMember = "CODIGO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(91, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
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
        Me.cmbMes.Location = New System.Drawing.Point(91, 31)
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
        Me.cmbEjercicio.Items.AddRange(New Object() {"2015", "2016", "2017"})
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 31)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 95
        Me.cmbEjercicio.TabStop = False
        '
        'frmOperacionAlmacenLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 566)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Controls.Add(Me.cmbTipoOperacion)
        Me.Controls.Add(Me.cmbAlmacen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gvOperacionesAlmacen)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOperacionAlmacenLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OPERACIONES DE ALMACEN"
        CType(Me.gvOperacionesAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvOperacionesAlmacen As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OPERACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGISTRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
End Class
