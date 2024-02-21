Public Class frmSerieConsulta
    Private MyProductosSerie As dsControlSeries.PRODUCTOS_SERIEDataTable
    Private MySerieHistorico As dsControlSeries.SERIES_HISTORICODataTable

    Private Sub frmSerieConsulta_Load(sender As Object, e As EventArgs) Handles Me.Load
        UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnInformacion_Visible = False
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnNuevo_Visible = True
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnImprimir_Visible = False
        UC_ToolBar.btnEditar_Visible = False

    End Sub

    Private Sub txtNumeroSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroSerie.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyProductosSerie = New dsControlSeries.PRODUCTOS_SERIEDataTable
            MySerieHistorico = New dsControlSeries.SERIES_HISTORICODataTable
            If txtNumeroSerie.TextLength <> 0 Then

                gvSerieHistorico.DataSource = MySerieHistorico
                gvSerieHistorico.ClearSelection()

                MyProductosSerie = dalProducto.BuscarProductosSerie(txtNumeroSerie.Text.Trim)
                gvProductosSerie.DataSource = MyProductosSerie
                gvProductosSerie.ClearSelection()
                txtNumeroSerie.Focus()
            End If
        End If
    End Sub

    Private Sub LimpiarFormulario()
        MyProductosSerie = New dsControlSeries.PRODUCTOS_SERIEDataTable
        MySerieHistorico = New dsControlSeries.SERIES_HISTORICODataTable

        Dim MyTabControl As TabControl
        Dim MyTabPage As TabPage
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is TextBox Then
                Select Case ctrl.tag
                    Case Is = "V" : ctrl.text = "0.000000"
                    Case Is = "C" : ctrl.text = "0.000"
                    Case Is = "D" : ctrl.text = "0.00"
                    Case Is = "E" : ctrl.text = "0"
                    Case Else : ctrl.text = Nothing
                End Select
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.SelectedIndex = -1
            ElseIf TypeOf ctrl Is TabControl Then
                MyTabControl = ctrl
                For Each TCctrl As Object In MyTabControl.Controls
                    MyTabPage = TCctrl
                    For Each TPctrl As Object In MyTabPage.Controls
                        If TypeOf TPctrl Is TextBox Then
                            Select Case TPctrl.tag
                                Case Is = "V" : TPctrl.text = "0.0000"
                                Case Is = "C" : TPctrl.text = "0.000"
                                Case Is = "D" : TPctrl.text = "0.00"
                                Case Is = "E" : TPctrl.text = "0"
                                Case Else : TPctrl.text = Nothing
                            End Select
                        ElseIf TypeOf TPctrl Is CheckBox Then
                            TPctrl.Checked = False
                        ElseIf TypeOf TPctrl Is ComboBox Then
                            TPctrl.SelectedIndex = -1
                        End If
                    Next
                Next
            End If
        Next

        gvProductosSerie.DataSource = MyProductosSerie
        gvSerieHistorico.DataSource = MySerieHistorico

        txtNumeroSerie.Text = Nothing

        txtNumeroSerie.Focus()
    End Sub

    Private Sub UC_ToolBar_btnNuevo_Click() Handles UC_ToolBar.TB_btnNuevo_Click
        Call LimpiarFormulario()
    End Sub

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

    Private Sub gvProductosSerie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvProductosSerie.CellDoubleClick
        Dim MyIndex As Integer
        If gvProductosSerie.Rows.Count <> 0 Then
            If Not gvProductosSerie.CurrentRow Is Nothing Then
                MySerieHistorico = New dsControlSeries.SERIES_HISTORICODataTable
                MyIndex = gvProductosSerie.CurrentRow.Index
                MySerieHistorico = dalProducto.BuscarNumeroSerie(MyProductosSerie(MyIndex).NUMERO_SERIE)
                gvSerieHistorico.DataSource = MySerieHistorico
                gvSerieHistorico.ClearSelection()
            End If
        End If
    End Sub

End Class
