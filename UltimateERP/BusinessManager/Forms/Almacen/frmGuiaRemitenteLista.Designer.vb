<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemitenteLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemitenteLista))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.gvGuias = New System.Windows.Forms.DataGridView()
        Me.GUIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTE_FECHA_TRASLADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZON_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panPrincipal.SuspendLayout()
        CType(Me.gvGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPrincipal
        '
        Me.panPrincipal.Controls.Add(Me.MyProgressBar)
        Me.panPrincipal.Controls.Add(Me.btnExportarExcel)
        Me.panPrincipal.Controls.Add(Me.Label3)
        Me.panPrincipal.Controls.Add(Me.Label2)
        Me.panPrincipal.Controls.Add(Me.cmbMes)
        Me.panPrincipal.Controls.Add(Me.cmbEjercicio)
        Me.panPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(985, 62)
        Me.panPrincipal.TabIndex = 1
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(12, 3)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(236, 14)
        Me.MyProgressBar.TabIndex = 28
        Me.MyProgressBar.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = CType(resources.GetObject("btnExportarExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportarExcel.FlatAppearance.BorderSize = 0
        Me.btnExportarExcel.Location = New System.Drawing.Point(208, 16)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(40, 40)
        Me.btnExportarExcel.TabIndex = 27
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(91, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "MES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "EJERCICIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(91, 35)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 24
        Me.cmbMes.TabStop = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 35)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 23
        Me.cmbEjercicio.TabStop = False
        '
        'gvGuias
        '
        Me.gvGuias.AllowUserToAddRows = False
        Me.gvGuias.AllowUserToDeleteRows = False
        Me.gvGuias.AllowUserToOrderColumns = True
        Me.gvGuias.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvGuias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvGuias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUIA, Me.COMPROBANTE_SERIE, Me.COMPROBANTE_NUMERO, Me.COMPROBANTE_FECHA, Me.COMPROBANTE_FECHA_TRASLADO, Me.RAZON_SOCIAL, Me.USUARIO_ENVIO, Me.FECHA_ENVIO, Me.ESTADO_ENVIO, Me.ESTADO})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvGuias.DefaultCellStyle = DataGridViewCellStyle5
        Me.gvGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvGuias.EnableHeadersVisualStyles = False
        Me.gvGuias.Location = New System.Drawing.Point(0, 62)
        Me.gvGuias.MultiSelect = False
        Me.gvGuias.Name = "gvGuias"
        Me.gvGuias.ReadOnly = True
        Me.gvGuias.RowHeadersVisible = False
        Me.gvGuias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvGuias.Size = New System.Drawing.Size(985, 595)
        Me.gvGuias.TabIndex = 14
        Me.gvGuias.TabStop = False
        '
        'GUIA
        '
        Me.GUIA.DataPropertyName = "GUIA"
        Me.GUIA.HeaderText = "GUIA"
        Me.GUIA.Name = "GUIA"
        Me.GUIA.ReadOnly = True
        Me.GUIA.Visible = False
        '
        'COMPROBANTE_SERIE
        '
        Me.COMPROBANTE_SERIE.DataPropertyName = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.HeaderText = "SERIE"
        Me.COMPROBANTE_SERIE.Name = "COMPROBANTE_SERIE"
        Me.COMPROBANTE_SERIE.ReadOnly = True
        Me.COMPROBANTE_SERIE.Width = 40
        '
        'COMPROBANTE_NUMERO
        '
        Me.COMPROBANTE_NUMERO.DataPropertyName = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.HeaderText = "NUMERO"
        Me.COMPROBANTE_NUMERO.Name = "COMPROBANTE_NUMERO"
        Me.COMPROBANTE_NUMERO.ReadOnly = True
        Me.COMPROBANTE_NUMERO.Width = 75
        '
        'COMPROBANTE_FECHA
        '
        Me.COMPROBANTE_FECHA.DataPropertyName = "COMPROBANTE_FECHA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COMPROBANTE_FECHA.DefaultCellStyle = DataGridViewCellStyle2
        Me.COMPROBANTE_FECHA.HeaderText = "FECHA EMISION"
        Me.COMPROBANTE_FECHA.Name = "COMPROBANTE_FECHA"
        Me.COMPROBANTE_FECHA.ReadOnly = True
        Me.COMPROBANTE_FECHA.Width = 75
        '
        'COMPROBANTE_FECHA_TRASLADO
        '
        Me.COMPROBANTE_FECHA_TRASLADO.DataPropertyName = "COMPROBANTE_FECHA_TRASLADO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.COMPROBANTE_FECHA_TRASLADO.DefaultCellStyle = DataGridViewCellStyle3
        Me.COMPROBANTE_FECHA_TRASLADO.HeaderText = "FECHA TRASLADO"
        Me.COMPROBANTE_FECHA_TRASLADO.Name = "COMPROBANTE_FECHA_TRASLADO"
        Me.COMPROBANTE_FECHA_TRASLADO.ReadOnly = True
        Me.COMPROBANTE_FECHA_TRASLADO.Width = 80
        '
        'RAZON_SOCIAL
        '
        Me.RAZON_SOCIAL.DataPropertyName = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.HeaderText = "DESTINATARIO"
        Me.RAZON_SOCIAL.Name = "RAZON_SOCIAL"
        Me.RAZON_SOCIAL.ReadOnly = True
        Me.RAZON_SOCIAL.Width = 400
        '
        'USUARIO_ENVIO
        '
        Me.USUARIO_ENVIO.DataPropertyName = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.HeaderText = "ENVIADO A SUNAT POR"
        Me.USUARIO_ENVIO.Name = "USUARIO_ENVIO"
        Me.USUARIO_ENVIO.ReadOnly = True
        Me.USUARIO_ENVIO.Width = 115
        '
        'FECHA_ENVIO
        '
        Me.FECHA_ENVIO.DataPropertyName = "FECHA_ENVIO"
        Me.FECHA_ENVIO.HeaderText = "FECHA DE ENVIO"
        Me.FECHA_ENVIO.Name = "FECHA_ENVIO"
        Me.FECHA_ENVIO.ReadOnly = True
        Me.FECHA_ENVIO.Width = 120
        '
        'ESTADO_ENVIO
        '
        Me.ESTADO_ENVIO.DataPropertyName = "ESTADO_ENVIO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ESTADO_ENVIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.ESTADO_ENVIO.HeaderText = "ESTADO"
        Me.ESTADO_ENVIO.Name = "ESTADO_ENVIO"
        Me.ESTADO_ENVIO.ReadOnly = True
        Me.ESTADO_ENVIO.Width = 50
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "EST"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        Me.ESTADO.Width = 40
        '
        'frmGuiaRemitenteLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 657)
        Me.Controls.Add(Me.gvGuias)
        Me.Controls.Add(Me.panPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemitenteLista"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELACION DE GUIAS DE REMITENTE"
        Me.panPrincipal.ResumeLayout(False)
        CType(Me.gvGuias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents gvGuias As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents GUIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPROBANTE_FECHA_TRASLADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAZON_SOCIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
