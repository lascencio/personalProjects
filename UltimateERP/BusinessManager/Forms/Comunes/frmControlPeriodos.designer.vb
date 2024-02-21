<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlPeriodos
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbModulo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.ckbActivo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckbMes12 = New System.Windows.Forms.CheckBox()
        Me.ckbMes11 = New System.Windows.Forms.CheckBox()
        Me.ckbMes10 = New System.Windows.Forms.CheckBox()
        Me.ckbMes09 = New System.Windows.Forms.CheckBox()
        Me.ckbMes08 = New System.Windows.Forms.CheckBox()
        Me.ckbMes07 = New System.Windows.Forms.CheckBox()
        Me.ckbMes06 = New System.Windows.Forms.CheckBox()
        Me.ckbMes05 = New System.Windows.Forms.CheckBox()
        Me.ckbMes04 = New System.Windows.Forms.CheckBox()
        Me.ckbMes03 = New System.Windows.Forms.CheckBox()
        Me.ckbMes02 = New System.Windows.Forms.CheckBox()
        Me.ckbMes01 = New System.Windows.Forms.CheckBox()
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_ToolBar
        '
        Me.UC_ToolBar.btnAceptar_Visible = True
        Me.UC_ToolBar.btnEditar_Visible = True
        Me.UC_ToolBar.btnGrabar_Visible = True
        Me.UC_ToolBar.btnInformacion_Visible = True
        Me.UC_ToolBar.btnSalir_Visible = True
        Me.UC_ToolBar.Size = New System.Drawing.Size(660, 54)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.cmbModulo)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.cmbEmpresa)
        Me.Panel.Controls.Add(Me.ckbActivo)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.ckbMes12)
        Me.Panel.Controls.Add(Me.ckbMes11)
        Me.Panel.Controls.Add(Me.ckbMes10)
        Me.Panel.Controls.Add(Me.ckbMes09)
        Me.Panel.Controls.Add(Me.ckbMes08)
        Me.Panel.Controls.Add(Me.ckbMes07)
        Me.Panel.Controls.Add(Me.ckbMes06)
        Me.Panel.Controls.Add(Me.ckbMes05)
        Me.Panel.Controls.Add(Me.ckbMes04)
        Me.Panel.Controls.Add(Me.ckbMes03)
        Me.Panel.Controls.Add(Me.ckbMes02)
        Me.Panel.Controls.Add(Me.ckbMes01)
        Me.Panel.Controls.Add(Me.cmbEjercicio)
        Me.Panel.Size = New System.Drawing.Size(660, 192)
        '
        'MyPrintPreview
        '
        Me.MyPrintPreview.ClientSize = New System.Drawing.Size(1366, 705)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(382, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 18)
        Me.Label3.TabIndex = 334
        Me.Label3.Text = "MODULO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbModulo
        '
        Me.cmbModulo.DisplayMember = "DESCRIPCION"
        Me.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModulo.Enabled = False
        Me.cmbModulo.FormattingEnabled = True
        Me.cmbModulo.Location = New System.Drawing.Point(382, 49)
        Me.cmbModulo.Name = "cmbModulo"
        Me.cmbModulo.Size = New System.Drawing.Size(254, 21)
        Me.cmbModulo.TabIndex = 333
        Me.cmbModulo.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(364, 18)
        Me.Label2.TabIndex = 332
        Me.Label2.Text = "EMPRESA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DisplayMember = "RAZON_SOCIAL"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.Enabled = False
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 49)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(364, 21)
        Me.cmbEmpresa.TabIndex = 331
        Me.cmbEmpresa.ValueMember = "EMPRESA"
        '
        'ckbActivo
        '
        Me.ckbActivo.BackColor = System.Drawing.Color.Transparent
        Me.ckbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbActivo.Enabled = False
        Me.ckbActivo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbActivo.ForeColor = System.Drawing.Color.Black
        Me.ckbActivo.Location = New System.Drawing.Point(495, 76)
        Me.ckbActivo.Name = "ckbActivo"
        Me.ckbActivo.Size = New System.Drawing.Size(141, 18)
        Me.ckbActivo.TabIndex = 330
        Me.ckbActivo.TabStop = False
        Me.ckbActivo.Text = "PERIODO ACTIVO"
        Me.ckbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbActivo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 329
        Me.Label1.Text = "AÑO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckbMes12
        '
        Me.ckbMes12.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes12.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes12.ForeColor = System.Drawing.Color.Black
        Me.ckbMes12.Location = New System.Drawing.Point(536, 144)
        Me.ckbMes12.Name = "ckbMes12"
        Me.ckbMes12.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes12.TabIndex = 328
        Me.ckbMes12.Text = "DICIEMBRE"
        Me.ckbMes12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes12.UseVisualStyleBackColor = False
        '
        'ckbMes11
        '
        Me.ckbMes11.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes11.ForeColor = System.Drawing.Color.Black
        Me.ckbMes11.Location = New System.Drawing.Point(536, 118)
        Me.ckbMes11.Name = "ckbMes11"
        Me.ckbMes11.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes11.TabIndex = 327
        Me.ckbMes11.Text = "NOVIEMBRE"
        Me.ckbMes11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes11.UseVisualStyleBackColor = False
        '
        'ckbMes10
        '
        Me.ckbMes10.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes10.ForeColor = System.Drawing.Color.Black
        Me.ckbMes10.Location = New System.Drawing.Point(427, 144)
        Me.ckbMes10.Name = "ckbMes10"
        Me.ckbMes10.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes10.TabIndex = 326
        Me.ckbMes10.Text = "OCTUBRE"
        Me.ckbMes10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes10.UseVisualStyleBackColor = False
        '
        'ckbMes09
        '
        Me.ckbMes09.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes09.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes09.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes09.ForeColor = System.Drawing.Color.Black
        Me.ckbMes09.Location = New System.Drawing.Point(427, 118)
        Me.ckbMes09.Name = "ckbMes09"
        Me.ckbMes09.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes09.TabIndex = 325
        Me.ckbMes09.Text = "SETIEMBRE"
        Me.ckbMes09.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes09.UseVisualStyleBackColor = False
        '
        'ckbMes08
        '
        Me.ckbMes08.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes08.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes08.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes08.ForeColor = System.Drawing.Color.Black
        Me.ckbMes08.Location = New System.Drawing.Point(318, 144)
        Me.ckbMes08.Name = "ckbMes08"
        Me.ckbMes08.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes08.TabIndex = 324
        Me.ckbMes08.Text = "AGOSTO"
        Me.ckbMes08.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes08.UseVisualStyleBackColor = False
        '
        'ckbMes07
        '
        Me.ckbMes07.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes07.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes07.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes07.ForeColor = System.Drawing.Color.Black
        Me.ckbMes07.Location = New System.Drawing.Point(318, 118)
        Me.ckbMes07.Name = "ckbMes07"
        Me.ckbMes07.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes07.TabIndex = 323
        Me.ckbMes07.Text = "JULIO"
        Me.ckbMes07.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes07.UseVisualStyleBackColor = False
        '
        'ckbMes06
        '
        Me.ckbMes06.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes06.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes06.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes06.ForeColor = System.Drawing.Color.Black
        Me.ckbMes06.Location = New System.Drawing.Point(210, 144)
        Me.ckbMes06.Name = "ckbMes06"
        Me.ckbMes06.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes06.TabIndex = 322
        Me.ckbMes06.Text = "JUNIO"
        Me.ckbMes06.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes06.UseVisualStyleBackColor = False
        '
        'ckbMes05
        '
        Me.ckbMes05.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes05.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes05.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes05.ForeColor = System.Drawing.Color.Black
        Me.ckbMes05.Location = New System.Drawing.Point(210, 118)
        Me.ckbMes05.Name = "ckbMes05"
        Me.ckbMes05.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes05.TabIndex = 321
        Me.ckbMes05.Text = "MAYO"
        Me.ckbMes05.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes05.UseVisualStyleBackColor = False
        '
        'ckbMes04
        '
        Me.ckbMes04.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes04.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes04.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes04.ForeColor = System.Drawing.Color.Black
        Me.ckbMes04.Location = New System.Drawing.Point(102, 144)
        Me.ckbMes04.Name = "ckbMes04"
        Me.ckbMes04.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes04.TabIndex = 320
        Me.ckbMes04.Text = "ABRIL"
        Me.ckbMes04.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes04.UseVisualStyleBackColor = False
        '
        'ckbMes03
        '
        Me.ckbMes03.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes03.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes03.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes03.ForeColor = System.Drawing.Color.Black
        Me.ckbMes03.Location = New System.Drawing.Point(102, 118)
        Me.ckbMes03.Name = "ckbMes03"
        Me.ckbMes03.Size = New System.Drawing.Size(100, 18)
        Me.ckbMes03.TabIndex = 319
        Me.ckbMes03.Text = "MARZO"
        Me.ckbMes03.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes03.UseVisualStyleBackColor = False
        '
        'ckbMes02
        '
        Me.ckbMes02.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes02.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes02.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes02.ForeColor = System.Drawing.Color.Black
        Me.ckbMes02.Location = New System.Drawing.Point(3, 144)
        Me.ckbMes02.Name = "ckbMes02"
        Me.ckbMes02.Size = New System.Drawing.Size(91, 18)
        Me.ckbMes02.TabIndex = 318
        Me.ckbMes02.Text = "FEBRERO"
        Me.ckbMes02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes02.UseVisualStyleBackColor = False
        '
        'ckbMes01
        '
        Me.ckbMes01.BackColor = System.Drawing.Color.Transparent
        Me.ckbMes01.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes01.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMes01.ForeColor = System.Drawing.Color.Black
        Me.ckbMes01.Location = New System.Drawing.Point(3, 118)
        Me.ckbMes01.Name = "ckbMes01"
        Me.ckbMes01.Size = New System.Drawing.Size(91, 18)
        Me.ckbMes01.TabIndex = 317
        Me.ckbMes01.Text = "ENERO"
        Me.ckbMes01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMes01.UseVisualStyleBackColor = False
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 92)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(91, 21)
        Me.cmbEjercicio.TabIndex = 316
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(181, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(460, 20)
        Me.Label21.TabIndex = 335
        Me.Label21.Text = "ACTIVAR/DESACTIVAR PERIODOS DE TRABAJO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmControlPeriodos
        '
        Me.ClientSize = New System.Drawing.Size(660, 246)
        Me.Name = "frmControlPeriodos"
        Me.Text = " CONTROL DE PERIODOS"
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents ckbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckbMes12 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes11 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes10 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes09 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes08 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes07 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes06 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes05 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes04 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes03 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes02 As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMes01 As System.Windows.Forms.CheckBox
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
