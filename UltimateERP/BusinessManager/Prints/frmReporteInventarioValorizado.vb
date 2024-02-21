Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class frmReporteInventarioValorizado

    Private MyAlmacen As dsTablasGenericas.LISTADataTable
    Private MyProducto As entProducto
    Private MyTipos As dsTablasGenericas.LISTADataTable
    Private MySubTipos As dsTablasGenericas.LISTADataTable
    Private MyFamilias As dsTablasGenericas.LISTADataTable
    Private MySubFamilias As dsTablasGenericas.LISTADataTable

    Private MyMovimientosProducto As dsCostos.MOVIMIENTOS_PRODUCTODataTable

    Private MyPeriodo As String
    Private MyTipoMoneda As String

    Private Procesado As Boolean

    Private MyInventarioValorizado As dsCostos.INVENTARIO_VALORIZADODataTable

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmReporteInventarioValorizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaGenerica(cmbTipoMoneda, "_TIPO_MONEDA")

        MyFamilias = ObtenerListaEmpresa("PRODUCTO_FAMILIA", "DESCRIPCION")
        MyTipos = ObtenerListaEmpresa("PRODUCTO_TIPO", "DESCRIPCION")

        MyAlmacen = New dsTablasGenericas.LISTADataTable

        MyAlmacen.Rows.Add("COM_ALMACEN", "TODOS", "TODOS", "TODOS", Space(1), 0)

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbTipo.DataSource = MyTipos
        cmbSubTipo.DataSource = MySubTipos
        cmbFamilia.DataSource = MyFamilias
        cmbSubFamilia.DataSource = MySubFamilias
        cmbAlmacen.DataSource = MyAlmacen

        cmbAlmacen.SelectedValue = MyUsuario.almacen

        cmbTipoMoneda.SelectedIndex = 1
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim MyKeyDown As Keys = e.KeyCode
        If MyKeyDown = Keys.Enter Or MyKeyDown = Keys.Return Then
            e.Handled = True : e.SuppressKeyPress = True
            Call ValidarProducto(sender)
            txtProductoDesdeNombre.Text = MyProducto.descripcion_ampliada
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubFamiliasNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubFamilias = New dsTablasGenericas.LISTADataTable
            MySubFamilias.Rows.Add("PRODUCTO_SUB_FAMILIA", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyFamilias(MyIndex).CODIGO <> "TODOS" Then
                MySubFamiliasNew = ObtenerListaEmpresa("PRODUCTO_SUB_FAMILIA", "DESCRIPCION")
                If MySubFamiliasNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubFamiliasNew.Rows.Count - 1
                        With MySubFamiliasNew(NEle)
                            If .REFERENCIA = MyFamilias(MyIndex).REFERENCIA Then
                                MySubFamilias.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubFamilia.DataSource = MySubFamilias
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Dim MyIndex As Integer
        Dim MySubTiposNew As dsTablasGenericas.LISTADataTable
        If sender.SelectedIndex <> -1 Then
            MyIndex = sender.SelectedIndex
            MySubTipos = New dsTablasGenericas.LISTADataTable
            MySubTipos.Rows.Add("PRODUCTO_SUB_TIPO", "TODOS", "TODOS", "TODOS", Space(1), 0)
            If MyTipos(MyIndex).CODIGO <> "TODOS" Then
                MySubTiposNew = ObtenerListaEmpresa("PRODUCTO_SUB_TIPO", "DESCRIPCION")
                If MySubTiposNew.Rows.Count <> 0 Then
                    For NEle As Integer = 0 To MySubTiposNew.Rows.Count - 1
                        With MySubTiposNew(NEle)
                            If .REFERENCIA = MyTipos(MyIndex).REFERENCIA Then
                                MySubTipos.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
                            End If
                        End With
                    Next
                End If
            End If
            cmbSubTipo.DataSource = MySubTipos
        End If
    End Sub

    Private Sub ckbProductoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProductoTodos.CheckedChanged
        If ckbProductoTodos.Checked = False Then
            EnableTextBox(txtProducto, True)
            cmbTipo.SelectedValue = "TODOS"
            cmbFamilia.SelectedValue = "TODOS"
            txtProducto.Focus()
        Else
            txtProducto.Text = Nothing
            txtProductoDesdeNombre.Text = Nothing
            EnableTextBox(txtProducto, False)
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub ValidarProducto(ByVal sender As Object)
        Dim MyCodigo As String = ""

        MyProducto = New entProducto
        MyCodigo = sender.Text.Trim
        If String.IsNullOrEmpty(MyCodigo) Then
            Dim MyForm As New frmProductoLista(MyProducto)
            MyForm.ShowDialog()
        Else
            If IsNumeric(MyCodigo) Then MyCodigo = "P" & Strings.Right("0000000" & MyCodigo, 7)
            MyProducto = dalProducto.Obtener(MyUsuario.empresa, MyCodigo)
        End If

        If Not MyProducto.producto Is Nothing Then
            sender.Text = MyProducto.producto
            btnGenerar.Focus()
        Else
            sender.Text = Nothing
            sender.Focus()
        End If
    End Sub

    Private Sub ImprimirReporte()
        Dim pAlmacen As String = cmbAlmacen.SelectedValue
        Dim pMarca As String = cmbFamilia.SelectedValue
        Dim pModelo As String = cmbSubFamilia.SelectedValue
        Dim pLinea As String = cmbTipo.SelectedValue
        Dim pSubLinea As String = cmbSubTipo.SelectedValue

        Dim pProducto As String = txtProducto.Text.Trim

        MyPeriodo = MyUsuario.ejercicio

        If cmbTipoMoneda.SelectedIndex = 1 Then
            MyInventarioValorizado = dalCostoPromedio.ObtenerInventarioValorizadoMN(MyUsuario.empresa, MyPeriodo, pAlmacen, pProducto, pLinea, pSubLinea, pMarca, pModelo)
        Else
            MyInventarioValorizado = dalCostoPromedio.ObtenerInventarioValorizadoME(MyUsuario.empresa, MyPeriodo, pAlmacen, pProducto, pLinea, pSubLinea, pMarca, pModelo)
        End If

        Dim MyParams(2) As Microsoft.Reporting.WinForms.ReportParameter
        MyParams(0) = New Microsoft.Reporting.WinForms.ReportParameter("pEjercicio", MyPeriodo, False)
        MyParams(1) = New Microsoft.Reporting.WinForms.ReportParameter("pMoneda", cmbTipoMoneda.Text, False)
        MyParams(2) = New Microsoft.Reporting.WinForms.ReportParameter("pAgencia", cmbAlmacen.Text, False)

        Me.rvInventarioValorizado.LocalReport.SetParameters(MyParams)

        Me.rvInventarioValorizado.LocalReport.DataSources.Clear()
        Me.rvInventarioValorizado.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsDetalles", DirectCast(MyInventarioValorizado, DataTable)))
        Me.rvInventarioValorizado.DocumentMapCollapsed = True

        Me.rvInventarioValorizado.RefreshReport()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If Procesado = False Then
            Procesado = dalCostoPromedio.CalcularCostoPromedio(MyProgressBar)

            MyProgressBar.Visible = False
        End If

        Call ImprimirReporte()
    End Sub


End Class