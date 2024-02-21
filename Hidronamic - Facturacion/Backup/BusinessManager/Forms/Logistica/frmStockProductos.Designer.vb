<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockProductos))
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbEjercicio = New System.Windows.Forms.ComboBox
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtProductoDesde = New System.Windows.Forms.TextBox
        Me.txtProductoDesdeNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtProductoHasta = New System.Windows.Forms.TextBox
        Me.txtProductoHastaNombre = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(99, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 18)
        Me.Label7.TabIndex = 707
        Me.Label7.Text = "MES"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Azure
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(99, 28)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(132, 21)
        Me.cmbMes.TabIndex = 706
        Me.cmbMes.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 705
        Me.Label1.Text = "EJERCICIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BackColor = System.Drawing.Color.Azure
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.Location = New System.Drawing.Point(12, 28)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(85, 21)
        Me.cmbEjercicio.TabIndex = 704
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.BackColor = System.Drawing.Color.Azure
        Me.cmbAlmacen.DisplayMember = "DESCRIPCION"
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(237, 28)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(245, 21)
        Me.cmbAlmacen.TabIndex = 708
        Me.cmbAlmacen.TabStop = False
        Me.cmbAlmacen.ValueMember = "CODIGO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(237, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 18)
        Me.Label2.TabIndex = 709
        Me.Label2.Text = "ALMACEN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SteelBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(12, 56)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(600, 18)
        Me.Label33.TabIndex = 712
        Me.Label33.Text = "DESDE EL PRODUCTO"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductoDesde
        '
        Me.txtProductoDesde.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProductoDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDesde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDesde.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProductoDesde.Location = New System.Drawing.Point(12, 75)
        Me.txtProductoDesde.MaxLength = 8
        Me.txtProductoDesde.Name = "txtProductoDesde"
        Me.txtProductoDesde.Size = New System.Drawing.Size(93, 21)
        Me.txtProductoDesde.TabIndex = 710
        '
        'txtProductoDesdeNombre
        '
        Me.txtProductoDesdeNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoDesdeNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoDesdeNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoDesdeNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDesdeNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoDesdeNombre.Location = New System.Drawing.Point(106, 75)
        Me.txtProductoDesdeNombre.MaxLength = 50
        Me.txtProductoDesdeNombre.Name = "txtProductoDesdeNombre"
        Me.txtProductoDesdeNombre.Size = New System.Drawing.Size(506, 21)
        Me.txtProductoDesdeNombre.TabIndex = 711
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(600, 18)
        Me.Label3.TabIndex = 716
        Me.Label3.Text = "HASTA EL PRODUCTO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductoHasta
        '
        Me.txtProductoHasta.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProductoHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoHasta.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoHasta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtProductoHasta.Location = New System.Drawing.Point(12, 118)
        Me.txtProductoHasta.MaxLength = 8
        Me.txtProductoHasta.Name = "txtProductoHasta"
        Me.txtProductoHasta.Size = New System.Drawing.Size(93, 21)
        Me.txtProductoHasta.TabIndex = 714
        '
        'txtProductoHastaNombre
        '
        Me.txtProductoHastaNombre.BackColor = System.Drawing.Color.LightYellow
        Me.txtProductoHastaNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoHastaNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoHastaNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoHastaNombre.ForeColor = System.Drawing.Color.DarkRed
        Me.txtProductoHastaNombre.Location = New System.Drawing.Point(106, 118)
        Me.txtProductoHastaNombre.MaxLength = 50
        Me.txtProductoHastaNombre.Name = "txtProductoHastaNombre"
        Me.txtProductoHastaNombre.Size = New System.Drawing.Size(506, 21)
        Me.txtProductoHastaNombre.TabIndex = 715
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(572, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(40, 40)
        Me.btnSalir.TabIndex = 718
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.BusinessManager.My.Resources.Resources.Print_48
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.Location = New System.Drawing.Point(526, 9)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(40, 40)
        Me.btnImprimir.TabIndex = 719
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'frmStockProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProductoHasta)
        Me.Controls.Add(Me.txtProductoHastaNombre)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtProductoDesde)
        Me.Controls.Add(Me.txtProductoDesdeNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbAlmacen)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEjercicio)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockProductos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE STOCKS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtProductoDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoDesdeNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProductoHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtProductoHastaNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
