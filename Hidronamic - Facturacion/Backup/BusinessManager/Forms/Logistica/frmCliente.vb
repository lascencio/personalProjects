Public Class frmCliente

    Private MyAnexo As entCONCAR_Anexo

    Private m_TipoDocumentoIdentidad As String = Space(1)
    Private m_NumeroDocumentoIdentidad As String = Space(1)

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal TipoDocumentoIdentidad As String, ByVal NumeroDocumentoIdentidad As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        m_TipoDocumentoIdentidad = TipoDocumentoIdentidad
        m_NumeroDocumentoIdentidad = NumeroDocumentoIdentidad
    End Sub

    Private Sub frmCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarTabla("_TIPO_DOCUMENTO_IDENTIDAD", cmbDocumentoTipo, IIf(m_TipoDocumentoIdentidad <> Space(1), m_TipoDocumentoIdentidad, "01"))
        If m_NumeroDocumentoIdentidad <> Space(1) Then
            btnNuevo.Visible = False
            txtDocumentoNumero.Text = m_NumeroDocumentoIdentidad
            txtDocumentoNumero.TabStop = False
            txtDocumentoNumero.ReadOnly = True
            txtDocumentoNumero.BackColor = Color.LightYellow
            txtDocumentoNumero.ForeColor = Color.DarkRed
            txtRazonSocial.Focus()
        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            If txtDocumentoNumero.Text.Trim.Length = 0 Then Throw New BusinessException(MSG000 & "NUMERO DE DOCUMENTO")
            If txtRazonSocial.Text.Trim.Length = 0 Then Throw New BusinessException(MSG000 & "RAZON SOCIAL")
            If txtDomicilio.Text.Trim.Length = 0 Then Throw New BusinessException(MSG000 & "DOMICILIO")

            MyAnexo = New entCONCAR_Anexo

            With MyAnexo
                .avanexo = "C"
                .acodane = txtDocumentoNumero.Text.Trim
                .adesane = txtRazonSocial.Text.Trim
                .aruc = .acodane
                .adocide = Strings.Right(cmbDocumentoTipo.SelectedValue.ToString, 1)
                .anumide = .aruc
                .atiptra = IIf(.aruc.Length = 11, "J", "N")
                .amemo = txtDomicilio.Text.Trim
            End With

            MyAnexo = dalCONCAR_Anexo.Grabar(MyAnexo)

            If m_NumeroDocumentoIdentidad = Space(1) Then
                Resp = MsgBox("Los cambios se realizaron con éxito.", MsgBoxStyle.Information, "REGISTRO DE CLIENTE")
                Call LimpiarFormulario()
            Else
                Me.Close()
            End If

        Catch ex As BusinessException
            Resp = MsgBox(ex.Message)
        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarFormulario()
        cmbDocumentoTipo.Text = "DNI"
        txtDocumentoNumero.ReadOnly = False
        txtDocumentoNumero.BackColor = Color.Honeydew
        txtDocumentoNumero.ForeColor = Color.MediumBlue
        txtDocumentoNumero.TabStop = True
        txtDocumentoNumero.Text = Nothing
        txtRazonSocial.Text = Nothing
        txtDomicilio.Text = Nothing
        txtDocumentoNumero.Focus()
    End Sub

    Private Sub txtDocumentoNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumentoNumero.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        Dim MyDocumentoTipo As String = ""
        Dim MyCliente As String = ""
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            MyAnexo = New entCONCAR_Anexo
            MyCliente = sender.Text.Trim
            MyAnexo = dalCONCAR_Anexo.ObtenerAnexoRSCONCAR(MyCliente)
            If Not MyAnexo.acodane Is Nothing Then
                MyDocumentoTipo = Strings.Right("0" & MyAnexo.adocide.Trim, 2)
                cmbDocumentoTipo.SelectedValue = MyDocumentoTipo
                txtRazonSocial.Text = MyAnexo.adesane.Trim
                txtDomicilio.Text = MyAnexo.amemo
                sender.ReadOnly = True
                sender.BackColor = Color.LightYellow
                sender.ForeColor = Color.DarkRed
                sender.TabStop = False
            Else
                txtRazonSocial.Text = Nothing
                txtDomicilio.Text = Nothing
                sender.ReadOnly = False
                sender.BackColor = Color.Honeydew
                sender.ForeColor = Color.MediumBlue
                sender.TabStop = True
            End If
            txtRazonSocial.Focus()
        End If
    End Sub

    Private Sub ActualizarDomicilios()
        Dim ClientesRSCONCAR As dsCONCAR_Anexos.ANEXO_DETALLEDataTable
        Dim MyDomicilio As String
        ClientesRSCONCAR = dalCONCAR_Anexo.ObtenerAnexosRSCONCAR("C")

        If ClientesRSCONCAR.Rows.Count > 0 Then
            For NEle As Integer = 0 To ClientesRSCONCAR.Rows.Count - 1
                If ClientesRSCONCAR(NEle).ARUC.Trim <> "" Then
                    MyDomicilio = dalCONCAR_Anexo.ObtenerDomicilioSOFINET(ClientesRSCONCAR(NEle).ARUC.Trim)
                    If MyDomicilio <> "SIN DATOS" Then
                        If Not MyDomicilio Is Nothing Then
                            Call dalCONCAR_Anexo.ActualizarDomicilio(ClientesRSCONCAR(NEle).ARUC.Trim, MyDomicilio)
                        End If
                    End If
                End If
            Next
        End If

        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call LimpiarFormulario()
    End Sub
End Class