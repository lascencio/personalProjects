Imports System.IO

Public Class frmLogin
    Private MainMenu As New MenuStrip
    Private MyMenu As New BindingSource

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyDTEmpresas = New dsEmpresas.EMPRESASDataTable
        MyDTEmpresasTodas = New dsEmpresas.EMPRESASDataTable
        MyDTModulos = New dsTablasGenericas.LISTADataTable

        Try
            CadenaSQL = "SELECT * FROM GEN.EMPRESAS WHERE ESTADO='ACT' AND EMPRESA<>'000'"
            Call ObtenerDataTableSQL(CadenaSQL, MyDTEmpresas)

            CadenaSQL = "SELECT * FROM GEN.EMPRESAS "
            Call ObtenerDataTableSQL(CadenaSQL, MyDTEmpresasTodas)

            CadenaSQL = "SELECT CODIGO_TABLA AS TABLA, CODIGO_ITEM AS CODIGO, NOMBRE_CORTO AS DESCRIPCION, TEXTO_01 AS REFERENCIA, LOGICO_01 AS ES_VEHICULAR " & _
                        "FROM GEN.TABLAS_DETALLE " & _
                        "WHERE EMPRESA='000' AND CODIGO_TABLA='MODULOS' AND ESTADO='ACT' " & _
                        "ORDER BY NOMBRE_CORTO "
            Call ObtenerDataTableSQL(CadenaSQL, MyDTModulos)

            cmbEmpresa.DataSource = MyDTEmpresas
            cmbModulo.DataSource = MyDTModulos
            MainMenu = frmMenu.MenuPrincipal

            If MyDTEmpresas.Rows.Count <> 0 Then cmbEmpresa.SelectedIndex = 0
            If MyDTModulos.Rows.Count <> 0 Then cmbModulo.SelectedIndex = 0

        Catch ex As Exception
            Throw New BusinessException("ERROR: " & ex.Message & Chr(13) & "ORIGEN: " & ex.Source)
        End Try
    End Sub

    Private Sub frmLogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAcceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceder.Click
        Dim MyOpenForms(Application.OpenForms.Count - 1) As String
        Dim Es_Conforme As Boolean = True

        Dim objReader As New StreamReader("C:\UltimateERP\Parametros.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        If cmbModulo.SelectedIndex <> -1 Then
            Try
                frmMenu.lblUsuario.Text = Nothing
                btnAcceder.Enabled = False

                MyUsuario = New entUsuario
                MyUser = New dsUsuarios.USERSDataTable
                MyAgencia = New dsAgencias.AGENCIASDataTable

                MyModulo = cmbModulo.Text
                MyEmpresa = cmbEmpresa.SelectedValue

                MyCodigo_CONCAR = MyDTEmpresas(cmbEmpresa.SelectedIndex).CODIGO_CONCAR
                MyIGV = MyDTEmpresas(cmbEmpresa.SelectedIndex).IGV
                MyISC = MyDTEmpresas(cmbEmpresa.SelectedIndex).ISC
                MyIPM = 2
                MyDetraccion = MyDTEmpresas(cmbEmpresa.SelectedIndex).DETRACCION
                MyPercepcion = 3.5

                MyRazonSocial = MyDTEmpresas(cmbEmpresa.SelectedIndex).RAZON_SOCIAL
                MyRUC = MyDTEmpresas(cmbEmpresa.SelectedIndex).RUC

                MySobreSeguro = MyDTEmpresas(cmbEmpresa.SelectedIndex).SOBRESEGURO
                MyTasaSeguro = MyDTEmpresas(cmbEmpresa.SelectedIndex).TASA_SEGURO

                MyCuentaDetraccion = MyDTEmpresas(cmbEmpresa.SelectedIndex).CUENTA_DETRACCION

                MyUsuario.usuario = txtUsuario.Text.ToUpper.Trim
                MyUsuario.clave = txtClave.Text.ToUpper.Trim

                MyUsuario = dalUsuario.Obtener(MyUsuario.usuario, MyUsuario.clave)

                MyUsuario.empresa = MyEmpresa

                MyUsuario.cambiar_clave = ckbCambiarClave.Checked

                Dim MyDatosEmpresa As dsTablasGenericas.TABLAS_DETALLE_LISTADataTable
                MyDatosEmpresa = dalTablasGenericas.BuscarElementosCodigo(MyUsuario.empresa, "_SUNAT", "0")

                If MyDatosEmpresa.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MyDatosEmpresa.Rows.Count - 1
                        Select Case MyDatosEmpresa(NEle).CODIGO
                            Case Is = "001"
                                MyCertificado = MyDatosEmpresa(NEle).T1
                                MyCertificadoClave = MyDatosEmpresa(NEle).T2
                            Case Is = "002"
                                'myConnectionStringSQL_Repository_Web = "Data Source=" & MyDatosEmpresa(NEle).T1 & ".amazonaws.com;" & _
                                '                                       "Initial Catalog=" & MyDatosEmpresa(NEle).T2 & ";" & _
                                '                                       "Persist Security Info=True;" & _
                                '                                       "User ID=" & MyDatosEmpresa(NEle).T3 & ";" & _
                                '                                       "Password=" & MyDatosEmpresa(NEle).T4
                        End Select
                    Next
                End If

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

                If String.IsNullOrEmpty(MyUsuario.usuario) Then
                    Es_Conforme = False
                    Resp = MsgBox("El USUARIO no esta registrado o la CLAVE es incorrecta", MsgBoxStyle.Information, "CONTROL DE ACCESO")
                Else
                    If MyUsuario.estado <> "ACT" Then
                        Es_Conforme = False
                        Resp = MsgBox("El USUARIO existe pero no se encuentra ACTIVO", MsgBoxStyle.Information, "CONTROL DE ACCESO")
                    Else
                        If MyUsuario.cambiar_clave = True Then
                            If txtClaveNueva.Text.Length = 0 And txtClaveConfirmar.Text.Length = 0 Then
                                MyUsuario.cambiar_clave = False
                            Else
                                If txtClaveNueva.Text.ToUpper.Trim = txtClaveConfirmar.Text.ToUpper.Trim Then
                                    MyUsuario.clave = txtClaveNueva.Text.ToUpper.Trim
                                    MyUsuario = dalUsuario.CambiarClave(MyUsuario)
                                    Resp = MsgBox("La NUEVA CLAVE ha sido grabada", MsgBoxStyle.Information, "CLAVE DE ACCESO CAMBIADA")
                                Else
                                    Resp = MsgBox("La NUEVA CLAVE no es igual a CONFIRMAR", MsgBoxStyle.Information, "CAMBIAR CLAVE DE ACCESO")
                                End If
                            End If
                        End If
                    End If
                End If

                If Es_Conforme = True Then
                    If ValidarPeriodos() = True Then
                        Call ActualizarMyDTProductos()
                        Call ActualizarMyDTCuentasComerciales()
                        Call ActualizarMyDTAlmacenes()
                        Call ActualizarMyDTClientes()
                        Call ValidarAccesos()

                        Me.Close()
                    End If

                    frmMenu.lblUsuario.Text = "USUARIO: " & MyUsuario.usuario.Trim
                End If

                MyUser = dalUser.Obtener(MyUsuario.empresa, MyUsuario.usuario)

                If MyUser.Rows.Count = 0 Then
                    Resp = MsgBox("Error en la integridad del Usuario, no puede ingresar al sistema.", MsgBoxStyle.Information, "ACCESO DENEGADO")
                    frmMenu.MenuPrincipal.Enabled = False
                Else
                    If MyUsuario.privilegios = "1" Then ' 1 - Control Total, 4 - Personalizado
                        MyUsuario.serie_asignada = arrText(0).ToString
                        MyUser(0).AGENCIA_ASIGNADA = "A0000" & arrText(0).ToString
                    Else
                        MyUsuario.serie_asignada = MyUser(0).AGENCIA_ASIGNADA.Substring(5, 3)
                    End If

                    MyAgencia = dalAgencia.Obtener(MyUsuario.empresa, MyUser(0).AGENCIA_ASIGNADA)
                    MyDomicilioFiscal = MyAgencia(0).DOMICILIO
                    MyDomicilioUbigeo = MyAgencia(0).UBIGEO
                    MyDomicilioDepartamento = ObtenerDescripcion("_UBIGEO_REGION", MyAgencia(0).DEPARTAMENTO, True)
                    MyDomicilioProvincia = ObtenerDescripcion("_UBIGEO_PROVINCIA", MyAgencia(0).PROVINCIA, True)
                    MyDomicilioDistrito = ObtenerDescripcion("_UBIGEO", MyAgencia(0).UBIGEO, True)

                    If MyUsuario.serie_asignada <> arrText(0).ToString Then
                        Resp = MsgBox("Inconsistencia relacionada con la Agencia Asignada, no puede ingresar al sistema.", MsgBoxStyle.Information, "ACCESO DENEGADO")
                        frmMenu.MenuPrincipal.Enabled = False
                        Me.Close()
                    Else
                        Dim MyCredenciales As String = My.Settings.cnnSQLDeveloping.ToString

                        If Servidor = "Desarrollo" Then Resp = MsgBox(MyCredenciales, MsgBoxStyle.Information, "TEST SERVER")

                        MyUsuario.almacen = arrText(0).ToString
                        frmMenu.Text = MyAgencia(0).RAZON_SOCIAL & " - PERIODO: " & EvalMes(MyUsuario.mes, "L").ToUpper & " " & MyUsuario.ejercicio & " - USUARIO: " & MyUser(0).NOMBRE_COMPLETO & IIf(Servidor = "Desarrollo", " - SERVIDOR DE DESARROLLO", "")
                    End If
                End If
            Catch ex As Exception
                'Try
                Resp = MsgBox("ERROR: " & ex.Message & Chr(13) & " ORIGEN: " & ex.Source)
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
        Dim FechaAnterior As Date

        MyUsuario.ejercicio = MyFechaServidor.Year.ToString
        MyUsuario.mes = MyFechaServidor.Month
        MyUsuario.periodo_actual = MyUsuario.ejercicio & MyUsuario.mes.ToString("00")

        MyPrimerDiaMes = CDate("01/" & MyUsuario.mes.ToString & "/" & MyUsuario.ejercicio)
        MyUltimoDiaMes = DateAdd(DateInterval.Month, 1, MyPrimerDiaMes)
        MyUltimoDiaMes = DateAdd(DateInterval.Day, -1, MyUltimoDiaMes)
        FechaAnterior = DateAdd(DateInterval.Month, -1, MyPrimerDiaMes)
        MyUsuario.ejercicio_anterior = FechaAnterior.Year.ToString
        MyUsuario.mes_anterior = FechaAnterior.Month
        'frmMenu.Text = "MODULO " & MyModulo & " - PERIODO: " & EvalMes(MyUsuario.mes, "L").ToUpper & " " & MyUsuario.ejercicio & " - USUARIO: " & MyUsuario.usuario.Trim & IIf(Servidor = "Desarrollo", " - SERVIDOR DE DESARROLLO", "")
        Return True

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

End Class