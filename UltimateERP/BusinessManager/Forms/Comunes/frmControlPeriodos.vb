Public Class frmControlPeriodos

    Dim MyPeriodo As entPeriodo

    Private Sub frmControlPeriodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(MyUsuario.empresa) Then
            cmbEmpresa.DataSource = MyDTEmpresasTodas
            cmbModulo.DataSource = MyDTModulos
            If MyUsuario.empresa <> "000" Then
                cmbEmpresa.SelectedValue = MyUsuario.empresa
                cmbEmpresa.Enabled = False
            End If
            LlenarPeriodos(cmbEjercicio)

            UC_ToolBar.CambiarEstados(MyUsuario.privilegios, Me.Privilegios, Me.Permitir_imprimir)

            UC_ToolBar.btnEditar_Visible = False
            UC_ToolBar.btnImprimir_Visible = False
            UC_ToolBar.btnNuevo_Visible = False
            UC_ToolBar.btnBorrar_Visible = False

        End If
    End Sub

    Private Sub EventoSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged, cmbEjercicio.SelectedIndexChanged, cmbModulo.SelectedIndexChanged
        If cmbEmpresa.SelectedIndex <> -1 And cmbEjercicio.SelectedIndex <> -1 And cmbModulo.SelectedIndex <> -1 Then
            Call ActualizarFormulario()
        End If
    End Sub

#Region "Funciones"

    Private Sub LimpiarFormulario()
        MyPeriodo = New entPeriodo
        For Each ctrl As Object In Panel.Controls
            If TypeOf ctrl Is CheckBox Then
                ctrl.Checked = False
            End If
        Next
        Call PonerValoresDefault()
    End Sub

    Private Sub PonerValoresDefault()
        ckbActivo.Checked = True
    End Sub

    Private Sub ActualizarFormulario()
        If cmbEmpresa.SelectedIndex <> -1 And cmbEjercicio.SelectedIndex <> -1 And cmbModulo.SelectedIndex <> -1 Then
            MyPeriodo = dalPeriodo.Obtener(cmbEmpresa.SelectedValue, cmbEjercicio.Text, cmbModulo.SelectedValue)
            If MyPeriodo.ejercicio <> "" Then
                With MyPeriodo
                    ckbMes01.Checked = IIf(.mes_01 = 1, True, False)
                    ckbMes02.Checked = IIf(.mes_02 = 1, True, False)
                    ckbMes03.Checked = IIf(.mes_03 = 1, True, False)
                    ckbMes04.Checked = IIf(.mes_04 = 1, True, False)
                    ckbMes05.Checked = IIf(.mes_05 = 1, True, False)
                    ckbMes06.Checked = IIf(.mes_06 = 1, True, False)
                    ckbMes07.Checked = IIf(.mes_07 = 1, True, False)
                    ckbMes08.Checked = IIf(.mes_08 = 1, True, False)
                    ckbMes09.Checked = IIf(.mes_09 = 1, True, False)
                    ckbMes10.Checked = IIf(.mes_10 = 1, True, False)
                    ckbMes11.Checked = IIf(.mes_11 = 1, True, False)
                    ckbMes12.Checked = IIf(.mes_12 = 1, True, False)
                    ckbActivo.Checked = IIf(.indica_activo = "SI", True, False)
                End With
            Else
                Call LimpiarFormulario()
            End If
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub btnGrabar_Click() Handles UC_ToolBar.TB_btnGrabar_Click
        If cmbEmpresa.SelectedIndex <> -1 And cmbEjercicio.SelectedIndex <> -1 And cmbModulo.SelectedIndex <> -1 Then
            With MyPeriodo
                .empresa = cmbEmpresa.SelectedValue
                .ejercicio = cmbEjercicio.Text
                .modulo = cmbModulo.Text.Substring(0, 3)
                .mes_01 = IIf(ckbMes01.Checked = True, 1, 0)
                .mes_02 = IIf(ckbMes02.Checked = True, 1, 0)
                .mes_03 = IIf(ckbMes03.Checked = True, 1, 0)
                .mes_04 = IIf(ckbMes04.Checked = True, 1, 0)
                .mes_05 = IIf(ckbMes05.Checked = True, 1, 0)
                .mes_06 = IIf(ckbMes06.Checked = True, 1, 0)
                .mes_07 = IIf(ckbMes07.Checked = True, 1, 0)
                .mes_08 = IIf(ckbMes08.Checked = True, 1, 0)
                .mes_09 = IIf(ckbMes09.Checked = True, 1, 0)
                .mes_10 = IIf(ckbMes10.Checked = True, 1, 0)
                .mes_11 = IIf(ckbMes11.Checked = True, 1, 0)
                .mes_12 = IIf(ckbMes12.Checked = True, 1, 0)
                .indica_activo = IIf(ckbActivo.Checked = True, "SI", "NO")
            End With

            Try
                MyPeriodo = dalPeriodo.Grabar(MyPeriodo)
                Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "CONTROL DE PERIODOS")
                Call ActualizarFormulario()
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

#End Region

End Class
