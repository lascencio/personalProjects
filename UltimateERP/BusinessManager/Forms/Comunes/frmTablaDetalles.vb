Public Class frmTablaDetalles
    Private MyTablaDetalle As New entTablaDetalle
    Private TD_Codigo As String, TD_Nombre As String
    Public Titulos(0 To 14) As String

    Private Sub frmTablaDetalles_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbEmpresa.DataSource = IIf(MyUsuario.privilegios = 1, MyDTEmpresasTodas, MyDTEmpresas)
        cmbEmpresa.SelectedValue = MyUsuario.empresa
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)
        UC_ToolBar.btnBorrar_Visible = True
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
    End Sub

    Private Sub EvaluarCambios(ByVal Tipo_Accion As String)
        If Tipo_Accion = "MODIFICAR" Then
            NFil = gvElementos.CurrentCell.RowIndex
            TD_Codigo = gvElementos.Rows(NFil).Cells(0).Value
            MyTablaDetalle = dalTablasGenericas.Obtener(cmbEmpresa.SelectedValue, cmbTablas.SelectedValue, TD_Codigo)
        Else
            MyTablaDetalle = New entTablaDetalle
        End If
        MyTablaDetalle.empresa = cmbEmpresa.SelectedValue
        MyTablaDetalle.codigo_tabla = cmbTablas.SelectedValue
        MyTablaDetalle.nombre_tabla = cmbTablas.Text
        Dim MyForm As New frmTablaDetalle(MyTablaDetalle, Me.Privilegios, Me.Permitir_imprimir)
        MyForm.ShowDialog()
        ActualizarGrilla()
    End Sub

    Private Sub ActualizarTablas()
        If cmbEmpresa.SelectedIndex <> -1 Then
            cmbTablas.DataSource = dalTablasGenericas.ObtenerTablas(cmbEmpresa.SelectedValue)
        End If
    End Sub

    Private Sub ActualizarGrilla()
        gvElementos.DataSource = dalTablasGenericas.ObtenerDetalles(cmbEmpresa.SelectedValue, cmbTablas.SelectedValue, "T")
        gvElementos.ClearSelection()
        gvElementos.CurrentCell = Nothing
    End Sub

    Private Sub gvElementos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvElementos.CellDoubleClick
        EvaluarCambios("MODIFICAR")
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If cmbEmpresa.SelectedIndex <> -1 Then
            ActualizarTablas()
            ActualizarGrilla()
        End If
    End Sub

    Private Sub cmbTablas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTablas.SelectedIndexChanged
        Dim Titulo As String
        If cmbTablas.SelectedIndex <> -1 Then
            Dim MyDR As DataRowView = CType(cmbTablas.Items.Item(cmbTablas.SelectedIndex), DataRowView)
            For NEle = 2 To 16
                Titulo = MyDR(NEle).ToString.Trim
                Titulos(NEle - 2) = Titulo
                If Len(Titulo) > 0 Then
                    gvElementos.Columns(NEle).Visible = True
                    gvElementos.Columns(NEle).HeaderText = Titulo
                Else
                    gvElementos.Columns(NEle).Visible = False
                End If
            Next
            Call ActualizarGrilla()
        End If
    End Sub

    Private Sub btnBorrar_Click() Handles UC_ToolBar.TB_btnBorrar_Click
        Dim TE_Codigo As String, TE_Nombre As String
        If gvElementos.CurrentCell Is Nothing Then
            MsgBox("Debe seleccionar un elemento de la tabla", MsgBoxStyle.Information, "ELIMINAR")
        Else
            NFil = gvElementos.CurrentCell.RowIndex
            TE_Codigo = gvElementos.Rows(NFil).Cells(0).Value
            TE_Nombre = gvElementos.Rows(NFil).Cells(1).Value.ToString.ToUpper.Trim
            If cmbEmpresa.SelectedValue = "000" And TE_Codigo = "000" Then
                Resp = MsgBox("Registro del SISTEMA." & Chr(13) & "No se puede eliminar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            Else
                dalTablasGenericas.Borrar(cmbEmpresa.SelectedValue, cmbTablas.SelectedValue, TE_Codigo, TE_Nombre)
                ActualizarGrilla()
            End If
        End If
    End Sub

    Private Sub btnEditar_Click() Handles UC_ToolBar.TB_btnEditar_Click
        If gvElementos.CurrentCell Is Nothing Then
            MsgBox("Debe seleccionar un elemento de la tabla", MsgBoxStyle.Information, "MODIFICAR")
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
