Public Class frmPeriodoTrabajo

    Private MesBase As String, EjercicioBase As String
    Private MesCambiar As String, EjercicioCambiar As String
    Private MyMaximoPeriodo As String
    Private MyPeriodoActual As String

    Private FechaAnterior As Date

    Private Sub frmPeriodoTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyDT As New dsPeriodos.PERIODOSDataTable
        Dim MySQL As String = "SELECT * FROM GEN.PERIODOS " & _
                              "WHERE EMPRESA='" & MyUsuario.empresa & "' AND MODULO='" & MyModulo.Substring(0, 3) & "' AND INDICA_ACTIVO='SI' " & _
                              "ORDER BY EJERCICIO"

        Dim ExistePeriodoActual As Boolean = False

        Call ObtenerDataTableSQL(MySQL, MyDT)
        Continuar = False
        If MyDT.Rows.Count > 0 Then
            For NFil = 0 To MyDT.Rows.Count - 1
                For NCol = 3 To 14
                    If MyDT(NFil)(NCol) = 1 Then
                        Continuar = 1
                    End If
                Next
            Next
        End If
        If Not Continuar Then
            Resp = MsgBox("No es posible utilizar esta opción", MsgBoxStyle.Information, "PERIODO DE TRABAJO")
            Me.Close()
        Else
            cmbAño.Items.Clear()
            For NEle = 0 To MyDT.Rows.Count - 1
                cmbAño.Items.Add(MyDT(NEle).EJERCICIO)
                If MyDT(NEle).EJERCICIO = MyUsuario.ejercicio Then ExistePeriodoActual = True
            Next
            If ExistePeriodoActual = True Then cmbAño.Text = MyUsuario.ejercicio
            Call ActualizarMeses()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cmbAño.Text <> "" And cmbMes.Text <> "" Then
            EjercicioBase = MyUsuario.ejercicio : MesBase = Strings.Right("00" & MyUsuario.mes.ToString, 2)
            EjercicioCambiar = cmbAño.Text : MesCambiar = Strings.Right("00" & EvalMesNombre(cmbMes.Text), 2)

            Try
                Call ActualizarDatos()
            Catch ex As BusinessException
                Resp = MsgBox(ex.Message)
            Catch ex As Exception
                Resp = MsgBox("ERROR: " & ex.Message.ToString)
            End Try

            Me.Close()
        End If
    End Sub

    Private Sub ActualizarDatos()
        Dim MyOpenForms(Application.OpenForms.Count - 1) As String
        MyUsuario.ejercicio = cmbAño.Text
        MyUsuario.mes = CByte(EvalMesNombre(cmbMes.Text))
        MyUsuario.periodo_actual = MyUsuario.ejercicio & Strings.Right("00" & MyUsuario.mes.ToString, 2)
        Resp = MsgBox("El periodo de trabajo actual es: " & cmbMes.Text & " " & cmbAño.Text, MsgBoxStyle.Information, "PERIODO DE TRABAJO")
        frmMenu.Text = "MODULO " & MyModulo & " - PERIODO: " & EvalMes(MyUsuario.mes, "L").ToUpper & " " & MyUsuario.ejercicio & " - USUARIO: " & MyUsuario.usuario.Trim & IIf(Servidor = "Desarrollo", " - SERVIDOR DE DESARROLLO", "")

        MyPrimerDiaMes = CDate("01/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio)
        MyUltimoDiaMes = DateAdd(DateInterval.Month, 1, MyPrimerDiaMes)
        MyUltimoDiaMes = DateAdd(DateInterval.Day, -1, MyUltimoDiaMes)

        FechaAnterior = DateAdd(DateInterval.Month, -1, MyPrimerDiaMes)
        MyUsuario.ejercicio_anterior = FechaAnterior.Year.ToString
        MyUsuario.mes_anterior = FechaAnterior.Month

        NEle = 0
        For Each frm As Form In Application.OpenForms
            MyOpenForms(NEle) = frm.Name
            NEle = NEle + 1
        Next

        For NEle As Integer = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms(MyOpenForms(NEle)).Name <> "frmMenu" Then
                If Application.OpenForms(MyOpenForms(NEle)).Name <> "frmPeriodoTrabajo" Then
                    Application.OpenForms(MyOpenForms(NEle)).Close()
                End If
            End If
        Next
    End Sub

    Private Sub cmbAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAño.SelectedIndexChanged
        If cmbAño.SelectedIndex <> -1 Then Call ActualizarMeses()
        If cmbAño.Text = MyUsuario.ejercicio Then cmbMes.Text = EvalMes(MyUsuario.mes, "L")
    End Sub

    Private Sub ActualizarMeses()
        cmbMes.Items.Clear()
        Dim MyDT As New dsPeriodos.PERIODOSDataTable
        Dim MySQL As String = "SELECT * FROM GEN.PERIODOS " & _
                              "WHERE EMPRESA='" & MyUsuario.empresa & "' AND MODULO='" & MyModulo.Substring(0, 3) & "' AND EJERCICIO='" & cmbAño.Text & "' AND INDICA_ACTIVO='SI' " & _
                              "ORDER BY EJERCICIO"
        Call ObtenerDataTableSQL(MySQL, MyDT)
        If MyDT.Rows.Count <> 0 Then
            For NEle = 3 To 14
                If MyDT(0)(NEle) = 1 Then
                    cmbMes.Items.Add(EvalMes(NEle - 2, "L").ToUpper)
                End If
            Next
        End If
    End Sub

End Class