<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEjecutarDTS
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
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Location = New System.Drawing.Point(583, 60)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(75, 23)
        Me.btnEjecutar.TabIndex = 0
        Me.btnEjecutar.Text = "EJECUTAR"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'frmEjecutarDTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 124)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Name = "frmEjecutarDTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ejecutar DTS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
End Class
