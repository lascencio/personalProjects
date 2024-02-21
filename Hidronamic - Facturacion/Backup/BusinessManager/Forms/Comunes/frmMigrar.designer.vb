<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMigrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMigrar))
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnMigrar = New System.Windows.Forms.Button
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.gvCabeceras = New System.Windows.Forms.DataGridView
        Me.MyProgressBar = New System.Windows.Forms.ProgressBar
        CType(Me.gvCabeceras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(103, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "MES"
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(106, 25)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "EJERCICIO"
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(15, 25)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(73, 21)
        Me.cmbEjercicio.TabIndex = 0
        Me.cmbEjercicio.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(238, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TIPO DE CAMBIO"
        '
        'btnMigrar
        '
        Me.btnMigrar.AutoSize = True
        Me.btnMigrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnMigrar.Location = New System.Drawing.Point(369, 23)
        Me.btnMigrar.Name = "btnMigrar"
        Me.btnMigrar.Size = New System.Drawing.Size(112, 23)
        Me.btnMigrar.TabIndex = 3
        Me.btnMigrar.Text = "MIGRAR DATOS"
        Me.btnMigrar.UseVisualStyleBackColor = True
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.Honeydew
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTipoCambio.Location = New System.Drawing.Point(241, 26)
        Me.txtTipoCambio.MaxLength = 10
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(105, 20)
        Me.txtTipoCambio.TabIndex = 2
        Me.txtTipoCambio.Tag = "C"
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gvCabeceras
        '
        Me.gvCabeceras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCabeceras.Location = New System.Drawing.Point(15, 79)
        Me.gvCabeceras.Name = "gvCabeceras"
        Me.gvCabeceras.Size = New System.Drawing.Size(1126, 480)
        Me.gvCabeceras.TabIndex = 7
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Location = New System.Drawing.Point(15, 52)
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(330, 14)
        Me.MyProgressBar.TabIndex = 41
        Me.MyProgressBar.Visible = False
        '
        'frmMigrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 571)
        Me.Controls.Add(Me.MyProgressBar)
        Me.Controls.Add(Me.gvCabeceras)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.btnMigrar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMigrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIGRAR INFORMACION DEL STARSOFT AL CONCAR"
        CType(Me.gvCabeceras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnMigrar As System.Windows.Forms.Button
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents gvCabeceras As System.Windows.Forms.DataGridView
    Friend WithEvents MyProgressBar As System.Windows.Forms.ProgressBar
End Class
