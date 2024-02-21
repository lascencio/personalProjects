Public Class frmTablaDetalle
    Private MyTablaDetalle As New entTablaDetalle
    Private myTablaCabecera As New entTablaCabecera

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByRef TablaDetalle As entTablaDetalle, ByVal Privilegios As Byte, ByVal Permitir_Imprimir As Boolean)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyTablaDetalle = TablaDetalle
        Me.Privilegios = Privilegios
        Me.Permitir_imprimir = Permitir_Imprimir
    End Sub

    Private Sub frmTablaDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDetalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEmpresa.Text = MyTablaDetalle.empresa
        txtCodigoTabla.Text = MyTablaDetalle.codigo_tabla
        txtDescripcionTabla.Text = MyTablaDetalle.nombre_tabla
        myTablaCabecera = dalTablaCabecera.Obtener(MyTablaDetalle.empresa, MyTablaDetalle.codigo_tabla)
        With myTablaCabecera
            lblTexto1.Text = .ttexto_01 : txtTexto1.Visible = IIf(lblTexto1.Text.Trim.Length = 0, False, True)
            lblTexto2.Text = .ttexto_02 : txtTexto2.Visible = IIf(lblTexto2.Text.Trim.Length = 0, False, True)
            lblTexto3.Text = .ttexto_03 : txtTexto3.Visible = IIf(lblTexto3.Text.Trim.Length = 0, False, True)
            lblTexto4.Text = .ttexto_04 : txttexto4.Visible = IIf(lblTexto4.Text.Trim.Length = 0, False, True)
            lblTexto5.Text = .ttexto_05 : txttexto5.Visible = IIf(lblTexto5.Text.Trim.Length = 0, False, True)
            lblValor1.Text = .tvalor_01 : txtValor1.Visible = IIf(lblValor1.Text.Trim.Length = 0, False, True)
            lblValor2.Text = .tvalor_02 : txtValor2.Visible = IIf(lblValor2.Text.Trim.Length = 0, False, True)
            lblValor3.Text = .tvalor_03 : txtValor3.Visible = IIf(lblValor3.Text.Trim.Length = 0, False, True)
            lblValor4.Text = .tvalor_04 : txtValor4.Visible = IIf(lblValor4.Text.Trim.Length = 0, False, True)
            lblValor5.Text = .tvalor_05 : txtValor5.Visible = IIf(lblValor5.Text.Trim.Length = 0, False, True)
            lblLogico1.Text = .tlogico_01 : ckbLogico1.Visible = IIf(lblLogico1.Text.Trim.Length = 0, False, True)
            lblLogico2.Text = .tlogico_02 : ckbLogico2.Visible = IIf(lblLogico2.Text.Trim.Length = 0, False, True)
            lblLogico3.Text = .tlogico_03 : ckbLogico3.Visible = IIf(lblLogico3.Text.Trim.Length = 0, False, True)
            lblLogico4.Text = .tlogico_04 : ckbLogico4.Visible = IIf(lblLogico4.Text.Trim.Length = 0, False, True)
            lblLogico5.Text = .tlogico_05 : ckbLogico5.Visible = IIf(lblLogico5.Text.Trim.Length = 0, False, True)
        End With

        If lblTexto3.Text = "EMPRESA" And txtCodigoTabla.Text = "USUARIOS" Then
            Dim MyDT As New dsTablasGenericas.TABLAS_DETALLEDataTable
            cmbTexto3.DataSource = dalTablaDetalle.ObtenerDetalles(txtEmpresa.Text, "EMPRESAS", "T")
            cmbTexto3.Visible = True
            cmbTexto4.DataSource = dalTablaDetalle.ObtenerDetalles(txtEmpresa.Text, "USUARIOS", "T")
            cmbTexto4.Visible = True : cmbTexto5.Visible = True
        Else
            cmbTexto3.Visible = False : cmbTexto4.Visible = False : cmbTexto5.Visible = False
        End If

        If String.IsNullOrEmpty(MyTablaDetalle.codigo_item) Then
            Me.Text = "CREAR ELEMENTO"
            txtCodigo.Enabled = True
        Else
            Me.Text = "MODIFICAR ELEMENTO"
            txtCodigo.Enabled = False
            With MyTablaDetalle
                txtCodigo.Text = .codigo_item
                txtDescripcion.Text = .nombre_corto
                txtDescripcionAmpliada.Text = .nombre_largo
                txtTexto1.Text = .texto_01
                txtTexto2.Text = .texto_02
                txtTexto3.Text = .texto_03
                txttexto4.Text = .texto_04
                txttexto5.Text = .texto_05
                txtValor1.Text = EvalDato(.valor_01, "V")
                txtValor2.Text = EvalDato(.valor_02, "V")
                txtValor3.Text = EvalDato(.valor_03, "V")
                txtValor4.Text = EvalDato(.valor_04, "V")
                txtValor5.Text = EvalDato(.valor_05, "V")
                ckbLogico1.Checked = .logico_01
                ckbLogico2.Checked = .logico_02
                ckbLogico3.Checked = .logico_03
                ckbLogico4.Checked = .logico_04
                ckbLogico5.Checked = .logico_05
                ckbActivo.Checked = IIf(.estado = "ACT", True, False)
                If lblTexto3.Text = "EMPRESA" And txtCodigoTabla.Text = "USUARIOS" Then
                    cmbTexto3.SelectedValue = .texto_03
                    cmbTexto4.SelectedValue = .texto_04
                    cmbTexto5.SelectedIndex = CByte(.texto_05) - 1
                End If
            End With
        End If

        TabControl1.SelectedIndex = 0
        If MyUsuario.privilegios = 4 Then
            If Me.Privilegios = 3 Then btnGrabar.Visible = False
        Else
            If MyUsuario.privilegios = 3 Then btnGrabar.Visible = False
        End If

    End Sub

    Private Sub txtValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor1.Validated, txtValor2.Validated, txtValor3.Validated
        If Not sender Is Nothing Then sender.Text = EvalDato(sender.Text, "V")
    End Sub

    Private Sub txtDescripcion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.Validated
        If sender.Text.Length > 0 Then
            txtDescripcionAmpliada.Text = sender.Text
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        MyTablaDetalle = New entTablaDetalle
        With MyTablaDetalle
            .empresa = txtEmpresa.Text
            .codigo_tabla = txtCodigoTabla.Text.ToUpper.Trim
            .codigo_item = txtCodigo.Text.ToUpper.Trim
            .nombre_corto = txtDescripcion.Text.ToUpper.Trim
            .nombre_largo = IIf(txtDescripcionAmpliada.Text.Trim.Length = 0, txtDescripcion.Text.ToUpper.Trim, txtDescripcionAmpliada.Text.ToUpper.Trim)
            .texto_01 = txtTexto1.Text.ToUpper.Trim
            .texto_02 = txtTexto2.Text.ToUpper.Trim
            .texto_03 = txtTexto3.Text.ToUpper.Trim
            .texto_04 = txttexto4.Text.ToUpper.Trim
            .texto_05 = txttexto5.Text.ToUpper.Trim
            .valor_01 = CSng(txtValor1.Text)
            .valor_02 = CSng(txtValor2.Text)
            .valor_03 = CSng(txtValor3.Text)
            .valor_04 = CSng(txtValor4.Text)
            .valor_05 = CSng(txtValor5.Text)
            .logico_01 = ckbLogico1.Checked
            .logico_02 = ckbLogico2.Checked
            .logico_03 = ckbLogico3.Checked
            .logico_04 = ckbLogico4.Checked
            .logico_05 = ckbLogico5.Checked
            .estado = IIf(ckbActivo.Checked = True, "ACT", "INA")
            .usuario_registro = MyUsuario.usuario

            If lblTexto3.Text = "EMPRESA" And txtCodigoTabla.Text = "USUARIOS" Then
                .texto_03 = cmbTexto3.SelectedValue
                .texto_04 = cmbTexto4.SelectedValue
                .texto_05 = cmbTexto5.SelectedIndex + 1
            End If

        End With

        Try
            MyTablaDetalle = dalTablaDetalle.Grabar(MyTablaDetalle)
            MyTablaDetalle.CancelProcess = "NOT"
            Me.Close()
        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
