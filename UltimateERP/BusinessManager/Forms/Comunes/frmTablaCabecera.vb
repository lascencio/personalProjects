Public Class frmTablaCabecera
    Private MyTablaCabecera As New entTablaCabecera

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal TablaCabecera As entTablaCabecera, ByVal Privilegios As Byte, ByVal Permitir_Imprimir As Boolean)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyTablaCabecera = TablaCabecera
    End Sub

    Private Sub frmTablaCabecera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEmpresa.Text = MyTablaCabecera.empresa
        cmbNecesidad.DataSource = dalTablasGenericas.ObtenerDetalles("000", "NECESIDAD", "T")
        If String.IsNullOrEmpty(MyTablaCabecera.codigo_tabla) Then
            Me.Text = "CREAR TABLA"
            txtCodigo.ReadOnly = False : txtCodigo.Enabled = True
        Else
            Me.Text = "MODIFICAR TABLA"
            txtCodigo.ReadOnly = True : txtCodigo.Enabled = False
            With MyTablaCabecera
                txtCodigo.Text = .codigo_tabla
                txtDescripcion.Text = .nombre_corto
                txtDescripcionAmpliada.Text = .nombre_largo
                txtTexto1.Text = .ttexto_01.Trim
                txtTexto2.Text = .ttexto_02.Trim
                txtTexto3.Text = .ttexto_03.Trim
                txtTexto4.Text = .ttexto_04.Trim
                txtTexto5.Text = .ttexto_05.Trim
                txtValor1.Text = .tvalor_01
                txtValor2.Text = .tvalor_02
                txtValor3.Text = .tvalor_03
                txtValor4.Text = .tvalor_04
                txtValor5.Text = .tvalor_05
                txtLogico1.Text = .tlogico_01
                txtLogico2.Text = .tlogico_02
                txtLogico3.Text = .tlogico_03
                txtLogico4.Text = .tlogico_04
                txtLogico5.Text = .tlogico_05
                ckbActivo.Checked = IIf(.estado = "ACT", 1, 0)
                cmbNecesidad.SelectedValue = .necesidad
                cmbNecesidad.Enabled = IIf(.necesidad = "SIS", False, True)
                ckbActivo.Enabled = IIf(.necesidad = "SIS", False, True)
            End With
        End If

        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub txtDescripcion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.Validated
        If sender.Text.Length > 0 Then
            txtDescripcionAmpliada.Text = sender.Text
        End If
    End Sub

    Private Sub Grabar()
        MyTablaCabecera = New entTablaCabecera
        With MyTablaCabecera
            .empresa = txtEmpresa.Text
            .codigo_tabla = txtCodigo.Text.ToUpper.Trim
            .nombre_corto = txtDescripcion.Text.ToUpper.Trim
            .nombre_largo = IIf(txtDescripcionAmpliada.Text.Trim.Length = 0, txtDescripcion.Text.ToUpper.Trim, txtDescripcionAmpliada.Text.ToUpper.Trim)
            .necesidad = cmbNecesidad.SelectedValue
            .ttexto_01 = txtTexto1.Text.ToUpper.Trim
            .ttexto_02 = txtTexto2.Text.ToUpper.Trim
            .ttexto_03 = txtTexto3.Text.ToUpper.Trim
            .ttexto_04 = txtTexto4.Text.ToUpper.Trim
            .ttexto_05 = txtTexto5.Text.ToUpper.Trim
            .tvalor_01 = txtValor1.Text.ToUpper.Trim
            .tvalor_02 = txtValor2.Text.ToUpper.Trim
            .tvalor_03 = txtValor3.Text.ToUpper.Trim
            .tvalor_04 = txtValor4.Text.ToUpper.Trim
            .tvalor_05 = txtValor5.Text.ToUpper.Trim
            .tlogico_01 = txtLogico1.Text.ToUpper.Trim
            .tlogico_02 = txtLogico2.Text.ToUpper.Trim
            .tlogico_03 = txtLogico3.Text.ToUpper.Trim
            .tlogico_04 = txtLogico4.Text.ToUpper.Trim
            .tlogico_05 = txtLogico5.Text.ToUpper.Trim
            .estado = IIf(ckbActivo.Checked = True, "ACT", "INA")
            .usuario_registro = MyUsuario.usuario
            .CancelProcess = "NOT"
        End With

        Try
            MyTablaCabecera = dalTablasGenericas.Grabar(MyTablaCabecera)
            Me.Close()
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnGrabar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtCodigo.Text.Trim.Length = 0 Then
            Resp = MsgBox("El campo TABLA esta vacío." & vbCrLf & "Debe indicar un nombre para la tabla.", MsgBoxStyle.Critical, "PROCESO DENEGADO")
        Else
            Call Grabar()
        End If
    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
