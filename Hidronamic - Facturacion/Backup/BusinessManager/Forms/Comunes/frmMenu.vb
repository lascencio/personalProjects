
Public Class frmMenu

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActivarMenu()
    End Sub

    Sub ActivarMenu()
        Try
            For Each OpcionMenu In MenuPrincipal.Items
                If OpcionMenu.Tag <> "P" Then OpcionMenu.Visible = False
                For Each OpcionSubMenu In OpcionMenu.DropDown.Items
                    If OpcionSubMenu.Tag <> "P" Then OpcionSubMenu.Visible = False
                    For Each OpcionSubMenuItem In OpcionSubMenu.DropDown.Items
                        If OpcionSubMenuItem.Tag <> "P" Then OpcionSubMenuItem.Visible = False
                    Next
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Message)
        End Try
    End Sub

    Private Sub LanzarFormulario(ByRef Formulario As System.Object, ByVal MyMenuItem As ToolStripMenuItem, ByVal Nivel As Byte)
        If MyUsuario.privilegios = 4 Then
            Dim Nivel1, Nivel2, Nivel3 As String
            Nivel1 = "" : Nivel2 = Nivel1 : Nivel3 = Nivel2

            With MyMenuItem
                If Nivel = 2 Then
                    If Not .OwnerItem.Text Is Nothing Then
                        Nivel1 = .OwnerItem.Text
                        Nivel2 = .Text
                    End If
                Else
                    Nivel1 = .OwnerItem.OwnerItem.Text
                    Nivel2 = .OwnerItem.Text
                    Nivel3 = .Text
                End If
            End With

            Dim MyControlAcceso As New dsControlAcceso.CONTROL_ACCESODataTable
            MyControlAcceso = dalControlAcceso.ObtenerAcceso(MyUsuario.empresa, MyUsuario.usuario, Nivel1, Nivel2, Nivel3)
            If MyControlAcceso.Count > 0 Then
                Formulario.Privilegios = MyControlAcceso(0).PRIVILEGIOS
                Formulario.Permitir_imprimir = MyControlAcceso(0).PERMITIR_IMPRIMIR
            End If
        End If

        Formulario.MdiParent = Me
        Formulario.Show()
    End Sub

    Private Sub LanzarFormulario(ByRef Formulario As System.Object, ByVal EsDialog As Boolean)
        If EsDialog = True Then
            Formulario.ShowDialog()
        Else
            Formulario.MdiParent = Me
            Formulario.Show()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ControlDeAccesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeAccesosToolStripMenuItem.Click
        LanzarFormulario(frmControlAccesos, True)
    End Sub

    Private Sub ParametrosDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametrosDelSistemaToolStripMenuItem.Click
        'frmParametros.Show()
    End Sub

    Private Sub ControlDePeriodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDePeriodosToolStripMenuItem.Click
        LanzarFormulario(frmControlPeriodos, False)
    End Sub

    Private Sub PeriodoDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmPeriodoTrabajo, True)
    End Sub

    Private Sub SesionDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SesionDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmLogin, False)
    End Sub

    Private Sub TablasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablasToolStripMenuItem.Click
        LanzarFormulario(frmTablaCabeceras, sender, 3)
    End Sub

    Private Sub ElementosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElementosToolStripMenuItem.Click
        LanzarFormulario(frmTablaDetalles, sender, 3)
    End Sub

    Private Sub LiquidarCajaChicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidarCajaChicaToolStripMenuItem.Click
        LanzarFormulario(frmLiquidarCajaChica, False)
    End Sub

    Private Sub MigrarInformaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmMigrar, False)
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeCambioToolStripMenuItem.Click
        LanzarFormulario(frmTipoCambio, False)
    End Sub

    Private Sub ConsultarRUCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LanzarFormulario(frmSUNAT, True)
    End Sub

    Private Sub ExportarAlCONCARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAlCONCARToolStripMenuItem.Click
        LanzarFormulario(frmExportarFacturacion, False)
    End Sub

    Private Sub DomicilioDeFacturacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DomicilioDeFacturacionToolStripMenuItem.Click
        LanzarFormulario(frmDomicilioNew, sender, 2)
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        LanzarFormulario(frmProducto, sender, 2)
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        LanzarFormulario(frmClientes, sender, 2)
    End Sub

    Private Sub CompuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompuestosToolStripMenuItem.Click
        LanzarFormulario(frmProductoCompuesto, sender, 2)
    End Sub

    Private Sub OrdenDePedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenDePedidoToolStripMenuItem.Click
        LanzarFormulario(frmOrdenPedido, sender, 2)
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        LanzarFormulario(frmProveedores, sender, 2)
    End Sub

    Private Sub OperacionesDeAlmacénToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperacionesDeAlmacénToolStripMenuItem.Click
        LanzarFormulario(frmOperacionAlmacen, sender, 2)
    End Sub

    Private Sub ReporteDeStocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeStocksToolStripMenuItem.Click
        frmStockProductos.ShowDialog()
    End Sub

    Private Sub BVPorOrdenDePedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVPorOrdenDePedidoToolStripMenuItem.Click
        If BV(1) = False Then
            BV(1) = True
            Dim MyForm As New frmFacturacionPedido("O", True, "BOLETA", "B1")
            LanzarFormulario(MyForm, sender, 2)
        End If
    End Sub

    Private Sub BVPorTransferenciaGratuitaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVPorTransferenciaGratuitaToolStripMenuItem.Click
        If BV(2) = False Then
            BV(2) = True
            Dim MyForm As New frmBoletaVenta("O", False, "BOLETA", "B2")
            LanzarFormulario(MyForm, sender, 2)
        End If
    End Sub

    Private Sub BVPorVentaMostradorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVPorVentaMostradorToolStripMenuItem.Click
        If BV(3) = False Then
            BV(3) = True
            Dim MyForm As New frmBoletaVenta("O", False, "BOLETA", "B3")
            LanzarFormulario(MyForm, sender, 2)
        End If
    End Sub

    Private Sub FacturaPorOrdenDePedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaPorOrdenDePedidoToolStripMenuItem.Click
        If BV(4) = False Then
            BV(4) = True
            Dim MyForm As New frmFacturacionPedido("O", True, "FACTURA", "F1")
            LanzarFormulario(MyForm, sender, 2)
        End If
    End Sub

    Private Sub FacturaPorVentaDeMostradorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaPorVentaDeMostradorToolStripMenuItem.Click
        If BV(5) = False Then
            BV(5) = True
            Dim MyForm As New frmBoletaVenta("O", False, "FACTURA", "F2")
            LanzarFormulario(MyForm, sender, 2)
        End If
    End Sub

    Private Sub GuiaDeRemisiónPorVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuiaDeRemisiónPorVentaToolStripMenuItem.Click
        LanzarFormulario(frmGuiaPorVenta, sender, 2)
    End Sub
End Class