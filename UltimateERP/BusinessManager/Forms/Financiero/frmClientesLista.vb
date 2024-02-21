Public Class frmClientesLista
    Private MyCuentaComercial As entCuentaComercial
    Private MyLista As New dsCuentasComerciales.CUENTAS_COMERCIALES_LISTADataTable

    Public Sub New(ByVal CuentaComercial As entCuentaComercial)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCuentaComercial = CuentaComercial
    End Sub

    Private Sub frmClientesLista_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtDescripcionIntro.Focus()
    End Sub

    Private Sub Intro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoIntro.KeyDown, txtDescripcionIntro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            If sender.Name = "txtCodigoIntro" Then
                txtDescripcionIntro.Focus()
            Else
                txtCodigoIntro.Focus()
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If gvCuentasComerciales.Rows.Count > 0 Then gvCuentasComerciales.Focus()
        End If
    End Sub

    Private Sub Intro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoIntro.KeyPress, txtDescripcionIntro.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Intro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoIntro.TextChanged, txtDescripcionIntro.TextChanged
        If txtCodigoIntro.Text.Trim.Length > 0 And txtDescripcionIntro.Text.Trim.Length > 0 Then
            If sender.Name = "txtCodigoIntro" Then
                txtDescripcionIntro.Text = Nothing
            Else
                txtCodigoIntro.Text = Nothing
            End If
        End If
        Call ActualizarGrilla()
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

    Private Sub ActualizarGrilla()
        Dim MyCode As String = txtCodigoIntro.Text.Trim
        Dim MyDescription As String = txtDescripcionIntro.Text.Trim

        Dim query As System.Data.EnumerableRowCollection(Of BusinessManager.dsCuentasComerciales.MyDTCuentasComercialesRow)

        If txtCodigoIntro.Text.Trim.Length > 0 Or txtDescripcionIntro.Text.Trim.Length > 0 Then
            If txtCodigoIntro.Text.Trim.Length > 0 Then
                query = From BusinessAccount In MyDTClientes _
                        Where BusinessAccount.NRO_DOCUMENTO.StartsWith(MyCode) _
                        Order By BusinessAccount.NRO_DOCUMENTO _
                        Select BusinessAccount
            Else
                query = From BusinessAccount In MyDTClientes _
                            Where BusinessAccount.RAZON_SOCIAL.Contains(MyDescription) _
                            Order By BusinessAccount.RAZON_SOCIAL _
                            Select BusinessAccount
            End If
            Dim MyDTClientesView As DataView = query.AsDataView()
            Dim MyCounter As Integer = MyDTClientesView.Count

            If MyCounter = 0 Then
                gvCuentasComerciales.DataSource = New dsCuentasComerciales.MyDTCuentasComercialesDataTable
            Else
                gvCuentasComerciales.DataSource = MyDTClientesView
            End If
        End If
    End Sub

    Private Sub ObtenerCuentaComercial(ByVal Indice As Integer)
        If Indice < 0 Then Indice = 0
        With MyCuentaComercial
            .empresa = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("EMPRESA").Value
            .tipo_documento = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("TIPO_DOCUMENTO").Value
            .nro_documento = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("NRO_DOCUMENTO").Value
            .razon_social = gvCuentasComerciales.Rows(gvCuentasComerciales.CurrentRow.Index).Cells("RAZON_SOCIAL").Value
        End With

        Me.Close()
    End Sub



End Class