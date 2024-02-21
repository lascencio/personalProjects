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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlToolBar))
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnInformacion = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnSUNAT = New System.Windows.Forms.Button()
        Me.ToolTipToolBar = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.AccessibleName = "Imprimir"
        Me.btnImprimir.BackgroundImage = CType(resources.GetObject("btnImprimir.BackgroundImage"), System.Drawing.Image)
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.Location = New System.Drawing.Point(106, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(48, 48)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleName = "Eliminar"
        Me.btnBorrar.BackgroundImage = CType(resources.GetObject("btnBorrar.BackgroundImage"), System.Drawing.Image)
        Me.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBorrar.FlatAppearance.BorderSize = 0
        Me.btnBorrar.Location = New System.Drawing.Point(259, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(48, 48)
        Me.btnBorrar.TabIndex = 5
        Me.btnBorrar.TabStop = False
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleName = "Nuevo"
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(48, 48)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleName = "Editar"
        Me.btnEditar.BackgroundImage = CType(resources.GetObject("btnEditar.BackgroundImage"), System.Drawing.Image)
        Me.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditar.FlatAppearance.BorderSize = 0
        Me.btnEditar.Location = New System.Drawing.Point(55, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(48, 48)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.TabStop = False
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.AccessibleName = "Grabar"
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.Location = New System.Drawing.Point(157, 3)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(48, 48)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleName = "Salir"
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.Location = New System.Drawing.Point(464, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(48, 48)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnInformacion
        '
        Me.btnInformacion.AccessibleName = "Información"
        Me.btnInformacion.BackgroundImage = CType(resources.GetObject("btnInformacion.BackgroundImage"), System.Drawing.Image)
        Me.btnInformacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInformacion.FlatAppearance.BorderSize = 0
        Me.btnInformacion.Location = New System.Drawing.Point(361, 3)
        Me.btnInformacion.Name = "btnInformacion"
        Me.btnInformacion.Size = New System.Drawing.Size(48, 48)
        Me.btnInformacion.TabIndex = 7
        Me.btnInformacion.TabStop = False
        Me.btnInformacion.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleName = "Check Final"
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.Location = New System.Drawing.Point(310, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(48, 48)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.TabStop = False
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.AccessibleName = "Enviar"
        Me.btnEnviar.BackgroundImage = CType(resources.GetObject("btnEnviar.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEnviar.FlatAppearance.BorderSize = 0
        Me.btnEnviar.Location = New System.Drawing.Point(208, 3)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(48, 48)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'btnSUNAT
        '
        Me.btnSUNAT.AccessibleName = "Consulta SUNAT"
        Me.btnSUNAT.BackgroundImage = CType(resources.GetObject("btnSUNAT.BackgroundImage"), System.Drawing.Image)
        Me.btnSUNAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSUNAT.FlatAppearance.BorderSize = 0
        Me.btnSUNAT.Location = New System.Drawing.Point(413, 3)
        Me.btnSUNAT.Name = "btnSUNAT"
        Me.btnSUNAT.Size = New System.Drawing.Size(48, 48)
        Me.btnSUNAT.TabIndex = 8
        Me.btnSUNAT.TabStop = False
        Me.btnSUNAT.UseVisualStyleBackColor = True
        '
        'ToolTipToolBar
        '
        Me.ToolTipToolBar.AutoPopDelay = 5000
        Me.ToolTipToolBar.BackColor = System.Drawing.Color.Yellow
        Me.ToolTipToolBar.InitialDelay = 1000
        Me.ToolTipToolBar.IsBalloon = True
        Me.ToolTipToolBar.ReshowDelay = 250
        '
        'UserControlToolBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnSUNAT)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnInformacion)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEditar)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserControlToolBar"
        Me.Size = New System.Drawing.Size(519, 55)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnInformacion As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnSUNAT As System.Windows.Forms.Button
    Friend WithEvents ToolTipToolBar As System.Windows.Forms.ToolTip

End Class
