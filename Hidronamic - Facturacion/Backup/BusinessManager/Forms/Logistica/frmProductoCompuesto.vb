Public Class frmProductoCompuesto

    Private MyAccion As String = "NUEVO"
    Private MyProducto As entProducto
    Private MyComponentes As dsProductos.COMPUESTOSDataTable

    Private Sub frmProductoCompuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmProductoCompuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
    End Sub

    Private Sub txtCompuesto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompuesto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProducto = New entProducto
            MyCodigo = sender.Text.Trim
            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto, "SI", "T")
                MyForm.ShowDialog()
            Else
                MyProducto = dalProducto.Obtener(MyCodigo)
            End If
            If Not MyProducto.producto Is Nothing Then
                Call LimpiarFormulario(False)
                Call LlenarFormulario()
            Else
                Call LimpiarFormulario(True)
            End If
        End If
    End Sub


    Private Sub txtComponente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComponente.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyCodigo As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProducto = New entProducto
            MyCodigo = sender.Text.Trim
            If String.IsNullOrEmpty(MyCodigo) Then
                Dim MyForm As New frmProductoLista(MyProducto, "NO", "T")
                MyForm.ShowDialog()
            Else
                MyProducto = dalProducto.Obtener(MyCodigo)
            End If

            txtCantidad.Text = "0"

            If Not MyProducto.producto Is Nothing Then
                txtComponente.Text = MyProducto.producto
                txtComponenteDescripcion.Text = MyProducto.descripcion_ampliada
                For NEle As Integer = 0 To MyComponentes.Rows.Count - 1
                    If MyComponentes(NEle).PRODUCTO = MyProducto.producto Then
                        txtCantidad.Text = EvalDato(MyComponentes(NEle).CANTIDAD, txtCantidad.Tag)
                    End If
                Next
                txtCantidad.Focus()
            Else
                txtComponente.Text = Nothing
                txtComponenteDescripcion.Text = Nothing
                txtComponente.Focus()
            End If
        End If
    End Sub

    Private Sub gvComponentes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvComponentes.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            With sender.Rows(sender.CurrentRow.Index)
                txtComponente.Text = .Cells("PRODUCTO").Value
                txtComponenteDescripcion.Text = .Cells("DESCRIPCION").Value
                txtCantidad.Text = EvalDato(.Cells("CANTIDAD").Value, txtCantidad.Tag)
                sender.ClearSelection()
                txtCantidad.Focus()
            End With
        End If
    End Sub

#Region "Botones"

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        MyAccion = "NUEVO"
        Call LimpiarFormulario(True)
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        MyProducto = New entProducto
        MyAccion = "MODIFICAR"
        Dim MyForm As New frmProductoLista(MyProducto, "SI", "T")
        MyForm.ShowDialog()
        If Not MyProducto.producto Is Nothing Then
            Call LimpiarFormulario(False)
            Call LlenarFormulario()
        End If
    End Sub

#End Region

#Region "Funciones"

    Private Sub LimpiarFormulario(ByVal ActivarCompuesto As Boolean)
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = ""
                End Select
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            End If
        Next
        gvComponentes.DataSource = New dsProductos.COMPUESTOSDataTable

        If ActivarCompuesto = True Then
            txtCompuesto.ReadOnly = False
            txtCompuesto.ForeColor = Color.MediumBlue
            txtCompuesto.BackColor = Color.Honeydew
            txtCompuesto.Focus()
        Else
            txtCompuesto.Text = MyProducto.producto
            txtCompuesto.ReadOnly = True
            txtCompuesto.ForeColor = Color.DarkRed
            txtCompuesto.BackColor = Color.LightYellow
            txtComponente.Focus()
        End If

    End Sub

    Private Sub LlenarFormulario()
        txtCompuestoDescripcion.Text = MyProducto.descripcion_ampliada
        Call ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        MyComponentes = dalProducto.ObtenerComponentes(MyUsuario.empresa, txtCompuesto.Text)
        gvComponentes.DataSource = MyComponentes
        gvComponentes.ClearSelection()
    End Sub

    Private Sub ActualizarComponentes() Handles UC_ToolBar.TB_btnGrabar_Click, UC_ToolBar.TB_btnBorrar_Click
        If txtCompuesto.TextLength <> 0 And txtComponente.TextLength <> 0 And txtCantidad.Text <> "0" Then
            Try
                If dalProducto.Grabar(txtCompuesto.Text, txtComponente.Text, CInt(txtCantidad.Text)) = True Then
                    Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "ACTUALIZAR REGISTRO")
                    txtComponente.Text = Nothing
                    txtComponenteDescripcion.Text = Nothing
                    txtCantidad.Text = "0"
                    Call ActualizarGrilla()
                    txtComponente.Focus()
                End If
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

#End Region

End Class
