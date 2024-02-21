Public Class frmProformasLista
    Private MyProforma As dsFinanciero.PROFORMASDataTable
    Private MyProformas As New dsFinanciero.PROFORMAS_LISTADataTable

    Private MyEjercicio As String
    Private MyMes As String
    Private MyEstado As String

    Private IndicaVehicular As Boolean

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal Proforma As dsFinanciero.PROFORMASDataTable, ByVal Ejercicio As String, ByVal Mes As String, EsVehicular As Boolean)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyProforma = Proforma
        MyEjercicio = Ejercicio
        MyMes = Mes
        IndicaVehicular = EsVehicular
    End Sub

    Private Sub frmProformasLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For NEle As Integer = 2019 To Year(Now)
            cmbEjercicio.Items.Add(NEle)
        Next

        cmbEjercicio.Text = MyEjercicio
        cmbMes.SelectedIndex = CByte(MyMes) - 1
    End Sub

    Private Sub gvProformas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvProformas.CellDoubleClick
        If Not gvProformas.CurrentRow Is Nothing Then
            MyProforma(0).PROFORMA = gvProformas.Rows(gvProformas.CurrentRow.Index).Cells("PROFORMA").Value
            Me.Close()
        End If
    End Sub

    Private Sub PoblarGrilla()
        Dim MyProformasNew As New dsFinanciero.PROFORMAS_LISTADataTable

        MyProformasNew = dalFinanciamiento.ObtenerProformas(MyUsuario.empresa, "A0000" & MyUsuario.almacen, MyEjercicio, MyMes)

        If MyProformasNew.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyProformasNew.Rows.Count - 1
                If IndicaVehicular = True Then
                    If MyProformasNew(NEle).TIPO_PRESTAMO = "CREDITO VEHICULAR" Then
                        MyProformas.ImportRow(MyProformasNew(NEle))
                    End If
                Else
                    If MyProformasNew(NEle).TIPO_PRESTAMO <> "CREDITO VEHICULAR" Then
                        MyProformas.ImportRow(MyProformasNew(NEle))
                    End If
                End If
            Next
        End If
        gvProformas.DataSource = MyProformas
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim MyDS As New DataSet
        Call ExportarExcel(MyProgressBar, MyProformas)
    End Sub

    Private Sub cmbEjercicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEjercicio.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyEjercicio = cmbEjercicio.Text
            Call PoblarGrilla()
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        If cmbEjercicio.SelectedIndex <> -1 And cmbMes.SelectedIndex <> -1 Then
            MyMes = Strings.Right("00" & CStr(cmbMes.SelectedIndex + 1), 2)
            Call PoblarGrilla()
        End If
    End Sub

End Class