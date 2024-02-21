<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlToolBar
    Inherits System.Windows.Forms.UserControl

    'UserControl1 reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlToolBar))
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnBorrar = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEditar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnInformacion = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = CType(resources.GetObject("btnImprimir.BackgroundImage"), System.Drawing.Image)
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.Location = New System.Drawing.Point(75, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(30, 30)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.BackgroundImage = CType(resources.GetObject("btnBorrar.BackgroundImage"), System.Drawing.Image)
        Me.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBorrar.FlatAppearance.BorderSize = 0
        Me.btnBorrar.Location = New System.Drawing.Point(172, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(30, 30)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.TabStop = False
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(30, 30)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = CType(resources.GetObject("btnEditar.BackgroundImage"), System.Drawing.Image)
        Me.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditar.FlatAppearance.BorderSize = 0
        Me.btnEditar.Location = New System.Drawing.Point(39, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(30, 30)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.TabStop = False
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(111, 3)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(30, 30)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(297, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(30, 30)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnInformacion
        '
        Me.btnInformacion.BackgroundImage = CType(resources.GetObject("btnInformacion.BackgroundImage"), System.Drawing.Image)
        Me.btnInformacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInformacion.FlatAppearance.BorderSize = 0
        Me.btnInformacion.Location = New System.Drawing.Point(262, 3)
        Me.btnInformacion.Name = "btnInformacion"
        Me.btnInformacion.Size = New System.Drawing.Size(30, 30)
        Me.btnInformacion.TabIndex = 6
        Me.btnInformacion.TabStop = False
        Me.btnInformacion.UseVisualStyleBackColor = True
        '
        'UserControlToolBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnInformacion)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEditar)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserControlToolBar"
        Me.Size = New System.Drawing.Size(330, 36)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnInformacion As System.Windows.Forms.Button

End Class
