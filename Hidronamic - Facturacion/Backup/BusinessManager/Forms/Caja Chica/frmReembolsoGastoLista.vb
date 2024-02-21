Public Class frmReembolsoGastoLista

    Private MyCajaChica As entCajaChica
    Private MyCajaChicaCabecera As entCajaChicaCabecera
    Private m_Tipo_Registro As String

    Public Sub New(ByVal CajaChica As entCajaChica, ByVal CajaChicaCabecera As entCajaChicaCabecera, ByVal TipoRegistro As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyCajaChica = CajaChica
        MyCajaChicaCabecera = CajaChicaCabecera
        m_Tipo_Registro = TipoRegistro
    End Sub

    Private Sub frmReembolsoGastoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With MyCajaChica
            cmbBeneficiario.DataSource = dalCajaChica.BuscarBeneficiarios(.empresa, .ejercicio, .mes, .area, .numero_caja)
            cmbBeneficiario.SelectedIndex = -1
            gvCajaChicaCabecera.DataSource = dalCajaChica.BuscarDocumentos(.empresa, .ejercicio, .mes, .area, .numero_caja, m_Tipo_Registro, "TODOS")
        End With
    End Sub

    Private Sub gvCajaChicaCabecera_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCajaChicaCabecera.CellDoubleClick
        If Not sender.CurrentRow Is Nothing Then
            MyCajaChicaCabecera.codigo_ui = sender.Rows(sender.CurrentRow.Index).Cells("CCODIGO_UI").Value
            Me.Close()
        End If
    End Sub

    Private Sub rbtTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        If sender.checked = True Then
            cmbBeneficiario.SelectedIndex = -1
            cmbBeneficiario.Enabled = False
        End If
    End Sub

    Private Sub rbtBeneficiario_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtBeneficiario.CheckedChanged
        If sender.checked = True Then cmbBeneficiario.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If rbtTodos.Checked = True Or (rbtBeneficiario.Checked = True And cmbBeneficiario.SelectedIndex <> -1) Then
            With MyCajaChica
                gvCajaChicaCabecera.DataSource = dalCajaChica.BuscarDocumentos(.empresa, .ejercicio, .mes, .area, .numero_caja, m_Tipo_Registro, IIf(rbtTodos.Checked = True, "TODOS", cmbBeneficiario.SelectedValue))
            End With
        End If
    End Sub
End Class