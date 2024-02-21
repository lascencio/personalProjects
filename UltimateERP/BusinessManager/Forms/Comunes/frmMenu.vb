
Public Class frmMenu

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActivarMenu()

        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Me.Location = New Point(0, 0)
        'Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)

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

    Private Sub SesionDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SesionDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmLogin, False)
    End Sub

    Private Sub ControlDeAccesosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeAccesosToolStripMenuItem.Click
        LanzarFormulario(frmControlAccesos, sender, 3)
    End Sub

    Private Sub ControlDePeriodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDePeriodosToolStripMenuItem.Click
        LanzarFormulario(frmControlPeriodos, sender, 3)
    End Sub

    Private Sub PeriodoDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodoDeTrabajoToolStripMenuItem.Click
        LanzarFormulario(frmPeriodoTrabajo, True)
    End Sub

    Private Sub PersonaNaturalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonaNaturalToolStripMenuItem.Click
        LanzarFormulario(frmClientePersonaNatural, sender, 2)
    End Sub

    Private Sub PersonaJuridicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonaJuridicaToolStripMenuItem.Click
        LanzarFormulario(frmClientePersonaJuridica, sender, 2)
    End Sub

    Private Sub GruposComercialesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DomicilioDeEnv�oToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AccesoWebToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MantenimientoDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeProveedoresToolStripMenuItem.Click
        LanzarFormulario(frmProveedor, sender, 2)
    End Sub

    Private Sub MantenimientoDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeProductosToolStripMenuItem.Click
        LanzarFormulario(frmProducto, sender, 2)
    End Sub

    Private Sub MantenimientoDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeUsuariosToolStripMenuItem.Click
        LanzarFormulario(frmUsuario, sender, 2)
    End Sub

    Private Sub TablasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TablasToolStripMenuItem.Click
        LanzarFormulario(frmTablaCabeceras, sender, 3)
    End Sub

    Private Sub ElementosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementosToolStripMenuItem.Click
        LanzarFormulario(frmTablaDetalles, sender, 3)
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeCambioToolStripMenuItem.Click
        LanzarFormulario(frmTipoCambio, sender, 2)
    End Sub

    Private Sub NotaDeSalidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeSalidaToolStripMenuItem.Click
        LanzarFormulario(frmNotaSalidaAlmacen, sender, 3)
    End Sub

    Private Sub NotaDeIngresoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeIngresoToolStripMenuItem.Click
        LanzarFormulario(frmNotaIngresoAlmacen, sender, 3)
    End Sub

    Private Sub NotaPorCompraVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaPorCompraVehicularToolStripMenuItem.Click
        frmNotaIngresoAlmacenVehiculo.Tipo_accion = "CONTADO"
        LanzarFormulario(frmNotaIngresoAlmacenVehiculo, sender, 3)
    End Sub

    Private Sub NotaPorCompraAlCr�ditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaPorCompraAlCr�ditoToolStripMenuItem.Click
        frmNotaIngresoAlmacenVehiculo.Tipo_accion = "CREDITO"
        LanzarFormulario(frmNotaIngresoAlmacenVehiculo, sender, 3)
    End Sub

    Private Sub NotaDeIngresoPorConsignacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeIngresoPorConsignacionToolStripMenuItem.Click
        frmNotaIngresoAlmacenVehiculo.Tipo_accion = "CONSIGNACION"
        LanzarFormulario(frmNotaIngresoAlmacenVehiculo, sender, 3)
    End Sub

    Private Sub NotaDeIngresoPorTrasladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeIngresoPorTrasladoToolStripMenuItem.Click
        LanzarFormulario(frmNotaIngresoAlmacenTraslado, sender, 3)
    End Sub

    Private Sub MovimientosPorProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorProductoToolStripMenuItem.Click
        Dim MyForm As New frmMovimientosProducto()
        MyForm.Show()
    End Sub

    Private Sub StockDeProductosPorAlmac�nToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockDeProductosPorAlmac�nToolStripMenuItem.Click
        Dim MyForm As New frmStockProductoAlmacenImprimir()
        MyForm.Show()
    End Sub

    Private Sub StockPorProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockPorProductoToolStripMenuItem.Click
        frmStockProducto.Show()
    End Sub

    Private Sub StockVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockVehicularToolStripMenuItem.Click
        Dim MyForm As New frmStockVehicularImprimir()
        MyForm.Show()
    End Sub

    Private Sub ConsultarN�meroDeSerieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarN�meroDeSerieToolStripMenuItem.Click
        LanzarFormulario(frmSerieConsulta, sender, 2)
    End Sub

    Private Sub VentaDirectaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaDirectaToolStripMenuItem.Click
        LanzarFormulario(frmVentaDirecta, sender, 2)
    End Sub

    Private Sub VentaVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaVehicularToolStripMenuItem.Click
        LanzarFormulario(frmVentaVehiculo, sender, 2)
    End Sub

    Private Sub NotaDeCr�ditoPorDevoluci�nToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCr�ditoPorDevoluci�nToolStripMenuItem.Click
        LanzarFormulario(frmNotaCreditoDevolucion, sender, 2)
    End Sub

    Private Sub NotaDeCr�ditoVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCr�ditoVehicularToolStripMenuItem.Click
        LanzarFormulario(frmNotaCreditoVehiculo, sender, 2)
    End Sub

    Private Sub Separaci�nVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Separaci�nVehicularToolStripMenuItem.Click
        LanzarFormulario(frmSeparacionVehiculo, sender, 2)
    End Sub

    Private Sub ComprobantesElectr�nicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobantesElectr�nicosToolStripMenuItem.Click
        LanzarFormulario(frmEComprobantes, sender, 2)
    End Sub

    Private Sub ConsultarCDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarCDRToolStripMenuItem.Click
        LanzarFormulario(frmEstadoCDR, sender, 2)
    End Sub

    Private Sub Gu�aPorVentaVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Gu�aPorVentaVehicularToolStripMenuItem.Click
        LanzarFormulario(frmGuiaPorVentaVehiculo, sender, 3)
    End Sub

    Private Sub Gu�aPorVentaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LanzarFormulario(frmGuiaPorVenta, sender, 3)
    End Sub

    Private Sub Gu�aPorVentaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles Gu�aPorVentaToolStripMenuItem.Click
        LanzarFormulario(frmGuiaPorVentaOtros, sender, 3)
    End Sub

    Private Sub Gu�aPorTrasladoInternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Gu�aPorTrasladoInternoToolStripMenuItem.Click
        LanzarFormulario(frmGuiaPorTrasladoInterno, sender, 3)
    End Sub

    Private Sub Gu�aPorTrasladoExternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Gu�aPorTrasladoExternoToolStripMenuItem.Click
        LanzarFormulario(frmGuiaPorTrasladoExterno, sender, 3)
    End Sub

    Private Sub ReporteDeGu�asDeRemisi�nToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeGu�asDeRemisi�nToolStripMenuItem.Click
        LanzarFormulario(frmReporteGuiasRemision, sender, 3)
    End Sub

    Private Sub CalculoDeLaUtilidadPromedioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculoDeLaUtilidadPromedioToolStripMenuItem.Click
        Dim MyForm As New frmReporteUtilidadProducto()
        MyForm.Show()
    End Sub

    Private Sub CalculoDeLaUtilidadEspecificoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculoDeLaUtilidadEspecificoToolStripMenuItem.Click
        Dim MyForm As New frmReporteUtilidadEspecifica()
        MyForm.Show()
    End Sub

    Private Sub SaldoValorizadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaldoValorizadoToolStripMenuItem.Click
        Dim MyForm As New frmReporteSaldoValorizado()
        MyForm.Show()
    End Sub

    Private Sub InventarioPermanenteValorizadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioPermanenteValorizadoToolStripMenuItem.Click
        Dim MyForm As New frmReporteInventarioValorizado()
        MyForm.Show()
    End Sub

    Private Sub ReporteDeComprobantesDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprobantesDeVentaToolStripMenuItem.Click
        Dim MyForm As New frmReporteComprobantesVenta()
        MyForm.Show()
    End Sub

    Private Sub ReporteDeComprobantesDeVentaMensualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprobantesDeVentaMensualToolStripMenuItem.Click
        Dim MyForm As New frmReporteComprobantesVentaMensual()
        MyForm.Show()
    End Sub

    Private Sub ReporteDeVentasPorProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorProductoToolStripMenuItem.Click
        Dim MyForm As New frmReporteVentaPorProducto()
        MyForm.Show()
    End Sub

    Private Sub MigrarTablasVFPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MigrarTablasVFPToolStripMenuItem.Click
        LanzarFormulario(frmMigrarTablas, sender, 2)
    End Sub

    Private Sub ActualizarMaestroDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMaestroDeClientesToolStripMenuItem.Click
        Call ActualizarMyDTCuentasComerciales()
        Resp = MsgBox("La actualizaci�n del Maestro de Clientes/Proveedores termin� con �xito.", MsgBoxStyle.Information, " ACTUALIZAR MAESTROS")
    End Sub

    Private Sub ActualizarMaestroDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMaestroDeProductosToolStripMenuItem.Click
        Call ActualizarMyDTProductos()
        Resp = MsgBox("La actualizaci�n del Maestro de Productos termin� con �xito.", MsgBoxStyle.Information, " ACTUALIZAR MAESTROS")
    End Sub

    Private Sub ActualizarTablasGeneralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarTablasGeneralesToolStripMenuItem.Click
        Call ActualizarTablasGenericas()
        Resp = MsgBox("La actualizaci�n de las Tablas Generales termin� con �xito.", MsgBoxStyle.Information, " ACTUALIZAR TABLAS GENERALES")
    End Sub

    Private Sub ReporteDeComprasLocalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasLocalesToolStripMenuItem.Click
        Dim MyForm As New frmReporteComprasLocales()
        MyForm.Show()
    End Sub

    Private Sub CobranzaDePr�stamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobranzaDePr�stamoToolStripMenuItem.Click
        LanzarFormulario(frmCobranzaPrestamo, sender, 3)
    End Sub

    Private Sub CobranzaDeGastosAdministrativosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobranzaDeGastosAdministrativosToolStripMenuItem.Click
        LanzarFormulario(frmCobranzaGastos, sender, 3)
    End Sub

    Private Sub CobranzaPorProntoPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobranzaPorProntoPagoToolStripMenuItem.Click
        LanzarFormulario(frmCobranzaProntoPago, sender, 3)
    End Sub

    Private Sub ResumenDeVentaDiarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenDeVentaDiarioToolStripMenuItem.Click
        Dim MyForm As New frmTResumenDiarioImprimir()
        MyForm.Show()
    End Sub

    Private Sub Pr�stamoVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Pr�stamoVehicularToolStripMenuItem.Click
        frmProformaPrestamo.Tipo_accion = "VEHICULAR"
        LanzarFormulario(frmProformaPrestamo, sender, 3)
    End Sub

    Private Sub Pr�stamoPersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Pr�stamoPersonalToolStripMenuItem.Click
        frmProformaPrestamo.Tipo_accion = "PERSONAL"
        LanzarFormulario(frmProformaPrestamo, sender, 3)
    End Sub

    Private Sub RegistrarPr�stamoVehicularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPr�stamoVehicularToolStripMenuItem.Click
        frmRegistrarPrestamo.Tipo_accion = "VEHICULAR"
        LanzarFormulario(frmRegistrarPrestamo, sender, 3)
    End Sub

    Private Sub RegistrarPr�stamoPersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPr�stamoPersonalToolStripMenuItem.Click
        frmRegistrarPrestamo.Tipo_accion = "PERSONAL"
        LanzarFormulario(frmRegistrarPrestamo, sender, 3)
    End Sub

    Private Sub ReprogramarCuotasPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprogramarCuotasPendientesToolStripMenuItem.Click
        LanzarFormulario(frmReprogramarCuotasPendientes, sender, 2)
    End Sub

    Private Sub ResumenDeCobranzasDiarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenDeCobranzasDiarioToolStripMenuItem.Click
        Dim MyForm As New frmTResumenCobranzaDiaria()
        MyForm.Show()
    End Sub

    Private Sub RefinanciarPr�stamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefinanciarPr�stamoToolStripMenuItem.Click
        LanzarFormulario(frmRefinanciarPrestamo, sender, 2)
    End Sub

    Private Sub EstadoDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentaToolStripMenuItem.Click
        Dim MyForm As New frmEstadoCuenta
        MyForm.Show()
    End Sub

    Private Sub MantenimientoDeClientesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MantenimientoDeClientesToolStripMenuItem1.Click
        LanzarFormulario(frmClientes, sender, 2)
    End Sub

    Private Sub Hist�ricoDePr�stamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Hist�ricoDePr�stamosToolStripMenuItem.Click
        LanzarFormulario(frmHistoricoPrestamos, sender, 2)
    End Sub



End Class