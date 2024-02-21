Public Class frmLogin

    Private MainMenu As New MenuStrip
    Private MyMenu As New BindingSource

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbEmpresa.DataSource = MyDTEmpresas
            MainMenu = frmMenu.MenuPrincipal
            cmbEmpresa.SelectedIndex = 0
            cmbModulo.SelectedIndex = 0
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.InnerException.Message & Chr(13) & " ORIGEN: " & ex.InnerException.Source)
        End Try
    End Sub

    Private Sub frmLogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAcceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceder.Click
        If cmbModulo.SelectedIndex <> -1 Then
            Try
                frmMenu.lblUsuario.Text = Nothing

                MyUsuario = New entUsuario
                MyModulo = cmbModulo.Text
                'MyEmpresa = Strings.Right("000" & CStr(cmbEmpresa.SelectedIndex + 1), 3)
                MyEmpresa = cmbEmpresa.SelectedValue

                MyCodigo_CONCAR = MyDTEmpresas(cmbEmpresa.SelectedIndex).CODIGO_CONCAR
                MyIGV = MyDTEmpresas(cmbEmpresa.SelectedIndex).IGV
                MyIGV = MyDTEmpresas(cmbEmpresa.SelectedIndex).IGV
                MyISC = MyDTEmpresas(cmbEmpresa.SelectedIndex).ISC
                MyDetraccion = MyDTEmpresas(cmbEmpresa.SelectedIndex).DETRACCION
                MyDomicilioFiscal = MyDTEmpresas(cmbEmpresa.SelectedIndex).DOMICILIO
                MyDistrito = MyDTEmpresas(cmbEmpresa.SelectedIndex).DISTRITO
                MyCuentaDetraccion = MyDTEmpresas(cmbEmpresa.SelectedIndex).CUENTA_DETRACCION

                MyUsuario.usuario = txtUsuario.Text.ToUpper.Trim
                MyUsuario.clave = txtClave.Text.ToUpper.Trim

                MyUsuario = dalUsuario.Obtener(MyUsuario.usuario, MyUsuario.clave)

                MyUsuario.empresa = MyEmpresa

                MyUsuario.cambiar_clave = ckbCambiarClave.Checked

                If String.IsNullOrEmpty(MyUsuario.usuario) Then
                    Resp = MsgBox("El USUARIO no esta registrado o la CLAVE es incorrecta", MsgBoxStyle.Information, "CONTROL DE ACCESO")
                Else
                    If MyUsuario.estado <> "ACT" Then
                        Resp = MsgBox("El USUARIO existe pero no se encuentra ACTIVO", MsgBoxStyle.Information, "CONTROL DE ACCESO")
                    Else
                        If Not MyUsuario.cambiar_clave Then
                            MyUsuario.es_conforme = True
                        Else
                            If txtClaveNueva.Text.Length = 0 And txtClaveConfirmar.Text.Length = 0 Then
                                MyUsuario.cambiar_clave = False
                                MyUsuario.es_conforme = True
                            Else
                                If txtClaveNueva.Text.ToUpper.Trim = txtClaveConfirmar.Text.ToUpper.Trim Then
                                    MyUsuario.clave = txtClaveNueva.Text.ToUpper.Trim
                                    MyUsuario = dalUsuario.CambiarClave(MyUsuario)
                                    Resp = MsgBox("La NUEVA CLAVE ha sido grabada", MsgBoxStyle.Information, "CLAVE DE ACCESO CAMBIADA")
                                    MyUsuario.es_conforme = True
                                Else
                                    Resp = MsgBox("La NUEVA CLAVE no es igual a CONFIRMAR", MsgBoxStyle.Information, "CAMBIAR CLAVE DE ACCESO")
                                End If
                            End If
                        End If
                    End If
                End If
                If MyUsuario.es_conforme Then
                    If ValidarPeriodos() = True Then Call ValidarAccesos()
                    Me.Close()
                End If
                frmMenu.lblUsuario.Text = "USUARIO: " & MyUsuario.usuario
            Catch ex As Exception
                'Try
                Resp = MsgBox("ERROR: " & ex.InnerException.Message & Chr(13) & " ORIGEN: " & ex.InnerException.Source)
                'Catch
                ' Do nothing here.
                'End Try
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ValidarAccesos()
        If MyUsuario.privilegios = 1 Then
            For Each OpcionMenu In MainMenu.Items
                OpcionMenu.Visible = True
                For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                    OpcionSubMenu.Visible = True
                    For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                        OpcionSubMenuItem.Visible = True
                    Next
                Next
            Next
        Else
            Dim MyOpcionMenu, MyOpcionSubMenu, MyOpcionSubMenuItem As String
            MyMenu.DataSource = dalControlAcceso.ObtenerAccesos(MyUsuario)

            'Ocultar todas las opciones del Menu
            For Each OpcionMenu In MainMenu.Items
                If OpcionMenu.Tag <> "P" Then OpcionMenu.Visible = False
                For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                    If OpcionSubMenu.Tag <> "P" Then OpcionSubMenu.Visible = False
                    For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                        If OpcionSubMenuItem.Tag <> "P" Then OpcionSubMenuItem.Visible = False
                    Next
                Next
            Next

            'Mostrar solo las opciones de Menu asignadas al usuario
            For Each OpcionMenu In MainMenu.Items
                MyOpcionMenu = "NIVEL_1='" & OpcionMenu.Text & "'"
                MyMenu.Filter = MyOpcionMenu
                If MyMenu.Count <> 0 Then
                    OpcionMenu.Visible = True
                    If OpcionMenu.Tag <> "P" Then OpcionMenu.Tag = MyMenu.Current("PRIVILEGIOS_CODIGO").ToString
                    If OpcionMenu.DropDownItems.Count > 0 Then
                        For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                            MyOpcionSubMenu = MyOpcionMenu & " AND NIVEL_2='" & OpcionSubMenu.Text & "'"
                            MyMenu.Filter = MyOpcionSubMenu
                            If MyMenu.Count <> 0 Then
                                OpcionSubMenu.Visible = True
                                If OpcionSubMenu.Tag <> "P" Then OpcionSubMenu.Tag = MyMenu.Current("PRIVILEGIOS_CODIGO").ToString
                                If OpcionSubMenu.DropDownItems.Count > 0 Then
                                    For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                                        MyOpcionSubMenuItem = MyOpcionSubMenu & " AND NIVEL_3='" & OpcionSubMenuItem.Text & "'"
                                        MyMenu.Filter = MyOpcionSubMenuItem
                                        If MyMenu.Count <> 0 Then
                                            OpcionSubMenuItem.Visible = True
                                            If OpcionSubMenuItem.Tag <> "P" Then OpcionSubMenuItem.Tag = MyMenu.Current("PRIVILEGIOS_CODIGO").ToString
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        End If
    End Sub

    Private Function ValidarPeriodos() As Boolean
        Dim MyPeriodos As New dsPeriodos.PERIODOSDataTable
        'Dim MyParametros As dsParamtrosRemuneraciones.PARAMETROSDataTable

        'MyPeriodos = dalPeriodo.ObtenerPeriodos(MyUsuario)
        'Continuar = False
        'If MyPeriodos.Rows.Count > 0 Then
        '    For NFil = 0 To MyPeriodos.Rows.Count - 1
        '        For NCol = 3 To 14
        '            If MyPeriodos(NFil)(NCol) = 1 Then
        '                Continuar = True
        '                MyUsuario.ejercicio = MyPeriodos(NFil).EJERCICIO
        '                MyUsuario.mes = NCol - 2
        '            End If
        '        Next
        '    Next
        'End If
        'If Not Continuar Then
        MyUsuario.ejercicio = Now.Year
        MyUsuario.mes = Now.Month
        'Resp = MsgBox("No hay PERIODOS DE TRABAJO activos.", MsgBoxStyle.Information, "CONTROL DE ACCESO")
        'Return False
        'Else
        Dim FechaIni As Date
        'If MyModulo.Substring(0, 3) = "REM" Then
        '    MyParametros = dalConceptoRemuneracionesTrabajador.Parametros(MyUsuario.empresa)
        '    If MyParametros.Count = 0 Then
        '        Resp = MsgBox("No hay PARAMETROS definidos para esta empresa.", MsgBoxStyle.Information, "CONTROL DE ACCESO")
        '        Return False
        '    Else
        '        MyUsuario.ejercicio = MyParametros(0).EJERCICIO_ACTUAL
        '        MyUsuario.mes = MyParametros(0).MES_ACTUAL
        '    End If
        'End If
        FechaIni = CDate("01/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio)
        FechaIni = DateAdd(DateInterval.Month, -1, FechaIni)
        MyUsuario.ejercicio_anterior = CStr(Year(FechaIni))
        MyUsuario.mes_anterior = Month(FechaIni)
        'frmMenu.Text = cmbEmpresa.Text & " - " & MyModulo & ":  PERIODO " & EvalMes(MyUsuario.mes, "L") & " - " & MyUsuario.ejercicio & IIf(Servidor <> "", " :  SERVIDOR DE DESARROLLO", "")
        frmMenu.Text = "SISTEMA DE GESTION - PERIODO " & EvalMes(MyUsuario.mes, "L").ToUpper & " - " & MyUsuario.ejercicio & IIf(Servidor <> "", " :  SERVIDOR DE DESARROLLO", "")
        Return True
        'End If

    End Function

    Private Sub ckbCambiarClave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbCambiarClave.CheckedChanged
        If ckbCambiarClave.Checked Then
            Me.Height = 325
        Else
            Me.Height = 230
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbModulo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModulo.Validated
        If cmbModulo.SelectedIndex = -1 Then cmbModulo.Focus()
    End Sub

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    MyBase.OnPaint(e)
    '    Dim AnchoBorde As Integer = 4
    '    Dim ColorBorde As Color = ColorTranslator.FromOle(RGB(239, 130, 0))

    '    ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, ColorBorde, _
    '    AnchoBorde, ButtonBorderStyle.Solid, ColorBorde, AnchoBorde, _
    '    ButtonBorderStyle.Solid, ColorBorde, AnchoBorde, ButtonBorderStyle.Solid, _
    '    ColorBorde, AnchoBorde, ButtonBorderStyle.Solid)
    'End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
End Class