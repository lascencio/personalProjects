<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMigrarTablas
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTabla = New System.Windows.Forms.ComboBox()
        Me.btnSeleccionarCarpeta = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCarpetaArchivos = New System.Windows.Forms.TextBox()
        Me.gvRegistros = New System.Windows.Forms.DataGridView()
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.gvRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnNuevo_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(1200, 54)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.lblProgress)
        Me.Panel.Controls.Add(Me.MyProgressBar)
        Me.Panel.Controls.Add(Me.gvRegistros)
        Me.Panel.Controls.Add(Me.btnSeleccionarCarpeta)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.txtCarpetaArchivos)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.cmbTabla)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbAlmacen)
        Me.Panel.Size = New System.Drawing.Size(1200, 596)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(860, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "AGENCIA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(860, 41)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(186, 21)
        Me.cmbAlmacen.TabIndex = 14
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(1052, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 705
        Me.Label7.Text = "TABLA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTabla
        '
        Me.cmbTabla.BackColor = System.Drawing.Color.Azure
        Me.cmbTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTabla.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbTabla.FormattingEnabled = True
        Me.cmbTabla.Items.AddRange(New Object() {"maecli", "maecon", "maedis", "maegar", "maeper", "trbcpre", "trbdesc", "trbdope", "trbdpre", "trbope", "trbopusr"})
        Me.cmbTabla.Location = New System.Drawing.Point(1052, 41)
        Me.cmbTabla.Name = "cmbTabla"
        Me.cmbTabla.Size = New System.Drawing.Size(132, 21)
        Me.cmbTabla.TabIndex = 704
        Me.cmbTabla.TabStop = False
        '
        'btnSeleccionarCarpeta
        '
        Me.btnSeleccionarCarpeta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionarCarpeta.Location = New System.Drawing.Point(430, 40)
        Me.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta"
        Me.btnSeleccionarCarpeta.Size = New System.Drawing.Size(24, 21)
        Me.btnSeleccionarCarpeta.TabIndex = 708
        Me.btnSeleccionarCarpeta.Text = "..."
        Me.btnSeleccionarCarpeta.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(419, 18)
        Me.Label5.TabIndex = 707
        Me.Label5.Text = "CARPETA DE ARCHIVOS A MIGRAR"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCarpetaArchivos
        '
        Me.txtCarpetaArchivos.BackColor = System.Drawing.Color.LightYellow
        Me.txtCarpetaArchivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarpetaArchivos.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCarpetaArchivos.Location = New System.Drawing.Point(11, 40)
        Me.txtCarpetaArchivos.MaxLength = 2
        Me.txtCarpetaArchivos.Name = "txtCarpetaArchivos"
        Me.txtCarpetaArchivos.ReadOnly = True
        Me.txtCarpetaArchivos.Size = New System.Drawing.Size(419, 20)
        Me.txtCarpetaArchivos.TabIndex = 706
        Me.txtCarpetaArchivos.TabStop = False
        '
        'gvRegistros
        '
        Me.gvRegistros.AllowUserToAddRows = False
        Me.gvRegistros.AllowUserToDeleteRows = False
        Me.gvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRegistros.Location = New System.Drawing.Point(11, 68)
        Me.gvRegistros.Name = "gvRegistros"
        Me.gvRegistros.ReadOnly = True
        Me.gvRegistros.Size = New System.Drawing.Size(1176, 515)
        Me.gvRegistros.TabIndex = 709
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(910, 3)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(274, 15)
        Me.MyProgressBar.TabIndex = 710
        Me.MyProgressBar.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(686, 3)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(181, 15)
        Me.lblProgress.TabIndex = 711
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMigrarTablas
        '
        Me.ClientSize = New System.Drawing.Size(1200, 650)
        Me.Name = "frmMigrarTablas"
        Me.Text = " MIGRAR TABLAS VFP"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.gvRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTabla As System.Windows.Forms.ComboBox
    Friend WithEvents btnSeleccionarCarpeta As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCarpetaArchivos As System.Windows.Forms.TextBox
    Friend WithEvents gvRegistros As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label

End Class
