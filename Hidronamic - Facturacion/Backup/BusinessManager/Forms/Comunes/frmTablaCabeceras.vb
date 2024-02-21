Public Class frmTablaCabeceras

    Private MyTablaCabecera As New entTablaCabecera
    Private TC_Codigo As String, TC_Nombre As String, TC_Necesidad As String

    Private Sub frmTablaCabeceras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEmpresa.DataSource = IIf(MyUsuario.privilegios = 1, MyDTEmpresasTodas, MyDTEmpresas)
        cmbEmpresa.SelectedValue = MyUsuario.empresa
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
    End Sub

    Private Sub EvaluarCambios(ByVal Tipo_Accion As String)
        If Tipo_Accion = "MODIFICAR" Then
            NFil = gvTablas.CurrentCell.RowIndex
            TC_Codigo = gvTablas.Rows(NFil).Cells(0).Value
            MyTablaCabecera = dalTablaCabecera.Obtener(cmbEmpresa.SelectedValue, TC_Codigo)
        Else
            MyTablaCabecera = New entTablaCabecera
        End If
        MyTablaCabecera.empresa = cmbEmpresa.SelectedValue
        Dim MyForm As New frmTablaCabecera(MyTablaCabecera, Me.Privilegios, Me.Permitir_imprimir)
        MyForm.ShowDialog()
        'If MyTablaCabecera.CancelProcess = "NOT" Then 
        ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        gvTablas.DataSource = dalTablaCabecera.ObtenerTablas(cmbEmpresa.SelectedValue)
        gvTablas.ClearSelection()
        gvTablas.CurrentCell = Nothing
    End Sub

    Private Sub gvTablas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvTablas.CellDoubleClick
        EvaluarCambios("MODIFICAR")
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If cmbEmpresa.SelectedIndex <> -1 Then
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnBorrar_Click() Handles UC_ToolBar.TB_btnBorrar_Click
        If gvTablas.CurrentCell Is Nothing Then
            MsgBox("Debe seleccionar una tabla de la lista", MsgBoxStyle.Information, "ELIMINAR")
        Else
            NFil = gvTablas.CurrentCell.RowIndex
            TC_Codigo = gvTablas.Rows(NFil).Cells(0).Value
            TC_Nombre = gvTablas.Rows(NFil).Cells(1).Value.ToString.ToUpper.Trim
            TC_Necesidad = gvTablas.Rows(NFil).Cells(18).Value
            If TC_Necesidad = "SISTEMAS" Then
                Resp = MsgBox("La tabla " & TC_Nombre & " es propia del SISTEMA." & Chr(13) & "No se puede eliminar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            Else
                dalTablaCabecera.Borrar(cmbEmpresa.SelectedValue, TC_Codigo, TC_Nombre)
                ActualizarGrilla()
            End If
        End If
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        If gvTablas.CurrentCell Is Nothing Then
            MsgBox("Debe seleccionar una tabla de la lista", MsgBoxStyle.Information, "MODIFICAR")
        Else
            EvaluarCambios("MODIFICAR")
        End If
    End Sub

    Private Sub btnImprimir_Click() Handles UC_ToolBar.TB_btnImprimir_Click

    End Sub

    Private Sub btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        EvaluarCambios("CREAR")
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

End Class
