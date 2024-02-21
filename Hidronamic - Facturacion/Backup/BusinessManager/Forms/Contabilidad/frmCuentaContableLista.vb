Public Class frmCuentaContableLista

    Private MyCuentaContable As entCONCAR_Cuenta
    Private m_tipo_cuenta As String
    Private m_solo_imputable As Boolean

    Public Sub New(ByVal CuentaContable As entCONCAR_Cuenta, ByVal TipoCuenta As String, ByVal SoloImputable As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCuentaContable = CuentaContable
        m_tipo_cuenta = TipoCuenta
        m_solo_imputable = SoloImputable
    End Sub

    Private Sub gvCuentas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCuentas.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then Call ObtenerCuentaContable(sender, sender.CurrentRow.Index)
    End Sub

    Private Sub gvCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvCuentas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not sender.CurrentRow Is Nothing Then Call ObtenerCuentaContable(sender, sender.CurrentRow.Index)
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
            If gvCuentas.Rows.Count > 0 Then gvCuentas.Focus()
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
                gvCuentas.DataSource = dalCONCAR_Cuenta.BuscarCuentaCodigo(txtCodigoIntro.Text.Trim, m_tipo_cuenta, m_solo_imputable)
            Else
                gvCuentas.DataSource = dalCONCAR_Cuenta.BuscarCuentaNombre(txtNombreCodigoIntro.Text.Trim, m_tipo_cuenta, m_solo_imputable)
            End If
        End If
    End Sub

    Private Sub ObtenerCuentaContable(ByVal sender As Object, ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        MyCuentaContable.pcuenta = sender.Rows(Indice).Cells("pcuenta").Value
        MyCuentaContable.pdescri = sender.Rows(Indice).Cells("pdescri").Value
        Me.Close()
    End Sub


End Class