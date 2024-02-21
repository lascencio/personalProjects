Public Class frmCuentaComercialLista

    Private MyCuentaComercial As entCuentaComercial
    Private m_tipo_cuenta As String

    Public Sub New(ByVal CuentaComercial As entCuentaComercial, ByVal TipoCuenta As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCuentaComercial = CuentaComercial
        m_tipo_cuenta = TipoCuenta
    End Sub

    Private Sub gvCuentasComerciales_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCuentasComerciales.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerCuentaComercial(sender.CurrentRow.Index)
    End Sub

    Private Sub gvCuentasComerciales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvCuentasComerciales.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerCuentaComercial(sender.CurrentRow.Index)
        ElseIf e.KeyCode = Keys.Up Then
            If sender.CurrentRow.Index = 0 Then txtCodigoIntro.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Intro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoIntro.KeyDown, txtNombreCodigoIntro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            If sender.Name = "txtCodigoIntro" Then
                txtNombreCodigoIntro.Focus()
            Else
                txtCodigoIntro.Focus()
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If gvCuentasComerciales.Rows.Count > 0 Then gvCuentasComerciales.Focus()
        End If
    End Sub

    Private Sub Intro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoIntro.KeyPress, txtNombreCodigoIntro.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Intro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoIntro.TextChanged, txtNombreCodigoIntro.TextChanged
        If txtCodigoIntro.Text.Trim.Length > 0 And txtNombreCodigoIntro.Text.Trim.Length > 0 Then
            If sender.Name = "txtCodigoIntro" Then
                txtNombreCodigoIntro.Text = Nothing
            Else
                txtCodigoIntro.Text = Nothing
            End If
        End If
        Call ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        If txtCodigoIntro.Text.Trim.Length > 0 Or txtNombreCodigoIntro.Text.Trim.Length > 0 Then
            If txtCodigoIntro.Text.Trim.Length > 0 Then
                gvCuentasComerciales.DataSource = dalCuentaComercial.BuscarCuentaComercialCodigo(MyUsuario.empresa, txtCodigoIntro.Text.Trim, m_tipo_cuenta)
            Else
                gvCuentasComerciales.DataSource = dalCuentaComercial.BuscarCuentaComercialNombre(MyUsuario.empresa, txtNombreCodigoIntro.Text.Trim, m_tipo_cuenta)
            End If
        Else
            'gvCuentasComerciales.Rows.Clear()
            gvCuentasComerciales.DataSource = New dsCuentasComercialesLista.CUENTAS_COMERCIALES_LISTADataTable
        End If
    End Sub

    Private Sub ObtenerCuentaComercial(ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        With MyCuentaComercial
            .cuenta_comercial = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("CUENTA_COMERCIAL").Value
            .tipo_documento = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("TIPO_DOCUMENTO").Value
            .nro_documento = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("NRO_DOCUMENTO").Value
            .razon_social = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("RAZON_SOCIAL").Value
            .codigo_vendedor = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("CODIGO_VENDEDOR").Value
        End With

        Me.Close()
    End Sub

    'Private Sub frmCuentaComercialLista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    gvCuentasComerciales.Rows.Clear()
    'End Sub

End Class