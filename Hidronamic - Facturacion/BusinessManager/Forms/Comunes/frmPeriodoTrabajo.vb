Public Class frmPeriodoTrabajo

    'Private MyParametros As dsParamtrosRemuneraciones.PARAMETROSDataTable
    Private MesBase As String, EjercicioBase As String
    Private MesCambiar As String, EjercicioCambiar As String
    Private MyMaximoPeriodo As String
    Private MyPeriodoActual As String

    Private FechaIni As Date

    Private Sub frmPeriodoTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyDT As New dsPeriodos.PERIODOSDataTable
        Dim MySQL As String = "SELECT * FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                              "WHERE EMPRESA='" & MyUsuario.empresa & "' AND INDICA_ACTIVO='SI' " & _
                              "ORDER BY EJERCICIO"
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
            Resp = MsgBox("No hay PERIODOS DE TRABAJO activos", MsgBoxStyle.Information, "EJERCICIO DE TRABAJO")
            Me.Close()
        Else
            cmbAño.Items.Clear()
            For NEle = 0 To MyDT.Rows.Count - 1
                cmbAño.Items.Add(MyDT(NEle).EJERCICIO)
            Next
            cmbAño.Text = MyUsuario.ejercicio
            Call ActualizarMeses()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cmbAño.Text <> "" And cmbMes.Text <> "" Then
            'Dim MyParametrosMensuales As entParametrosMensualesRemuneraciones
            EjercicioBase = MyUsuario.ejercicio : MesBase = Strings.Right("00" & MyUsuario.mes.ToString, 2)
            EjercicioCambiar = cmbAño.Text : MesCambiar = Strings.Right("00" & EvalMesNombre(cmbMes.Text), 2)

            Try
                'If MyModulo.Substring(0, 3) = "REM" Then
                '    'Averiguar si el período a cambiar existe en las tablas PARAMETROS_MENSUALES
                '    MyParametrosMensuales = dalParametrosMensualesRemuneraciones.Obtener(MyUsuario.empresa, EjercicioCambiar, MesCambiar)
                '    If String.IsNullOrEmpty(MyParametrosMensuales.empresa) Then
                '        'Si no existe, conseguir los parametros mensuales del máximo periodo y asignarlos a la entidad
                '        MyMaximoPeriodo = dalParametrosMensualesRemuneraciones.ObtenerMaximoPeriodoMensuales()
                '        If MyMaximoPeriodo = "000000" Then
                '            'Si no existe ningun periodo, crear uno nuevo 
                '            MyParametrosMensuales.empresa = MyUsuario.empresa
                '            MyParametrosMensuales.ejercicio = EjercicioCambiar
                '            MyParametrosMensuales.mes = MesCambiar
                '            MyParametrosMensuales = dalParametrosMensualesRemuneraciones.Grabar(MyParametrosMensuales)
                '        Else
                '            'Si existe obtener los datos del máximo período
                '            MyParametrosMensuales = dalParametrosMensualesRemuneraciones.Obtener(MyUsuario.empresa, MyMaximoPeriodo.Substring(0, 4), MyMaximoPeriodo.Substring(4, 2))
                '        End If
                '    End If

                '    If dalParametrosMensualesRemuneraciones.CopiarRegistros(MyUsuario.empresa, EjercicioBase, MesBase, EjercicioCambiar, MesCambiar) = True Then
                '        If dalParametrosMensualesRemuneraciones.ReemplazarParametrosActuales(MyUsuario.empresa, EjercicioCambiar, MesCambiar) = True Then
                '            Call ActualizarDatos()
                '        End If
                '    End If
                'Else
                '    Call ActualizarDatos()
                'End If

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
        MyUsuario.ejercicio = cmbAño.Text
        MyUsuario.mes = CByte(EvalMesNombre(cmbMes.Text))
        Resp = MsgBox("El periodo de trabajo actual es: " & cmbMes.Text & " " & cmbAño.Text, MsgBoxStyle.Information, "PERIODO DE TRABAJO")
        'frmMenu.Text = MyModulo & ":  PERIODO " & EvalMes(MyUsuario.mes, "L") & " - " & MyUsuario.ejercicio
        frmMenu.Text = "FACTURACION ELECTRONICA - PERIODO " & EvalMes(MyUsuario.mes, "L").ToUpper & " - " & MyUsuario.ejercicio & IIf(Servidor <> "", " :  SERVIDOR DE DESARROLLO", "")
        FechaIni = CDate("01/" & CStr(MyUsuario.mes) & "/" & MyUsuario.ejercicio)
        FechaIni = DateAdd(DateInterval.Month, -1, FechaIni)
        MyUsuario.ejercicio_anterior = CStr(Year(FechaIni))
        MyUsuario.mes_anterior = Month(FechaIni)
    End Sub

    Private Sub cmbAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAño.SelectedIndexChanged
        If cmbAño.SelectedIndex <> -1 Then Call ActualizarMeses()
        If cmbAño.Text = MyUsuario.ejercicio Then cmbMes.Text = EvalMes(MyUsuario.mes, "L")
    End Sub

    Private Sub ActualizarMeses()
        cmbMes.Items.Clear()
        Dim MyDT As New dsPeriodos.PERIODOSDataTable
        Dim MySQL As String = "SELECT * FROM " & MyModulo.Substring(0, 3) & ".PERIODOS " & _
                              "WHERE EMPRESA='" & MyUsuario.empresa & "' AND EJERCICIO='" & cmbAño.Text & "' AND INDICA_ACTIVO='SI' " & _
                              "ORDER BY EJERCICIO"
        Call ObtenerDataTableSQL(MySQL, MyDT)
        For NEle = 3 To 14
            If MyDT(0)(NEle) = 1 Then
                cmbMes.Items.Add(EvalMes(NEle - 2, "L").ToUpper)
            End If
        Next
        cmbMes.Text = EvalMes(MyUsuario.mes, "L")
    End Sub
End Class