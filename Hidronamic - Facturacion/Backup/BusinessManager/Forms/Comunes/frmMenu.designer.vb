<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.MenuPrincipal = New System.Windows.Forms.MenuStrip
        Me.AplicacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ControlDeAccesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametrosDelSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ControlDePeriodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PeriodoDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SesionDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CompuestosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TipoDeCambioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TablasGenéricasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TablasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ElementosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LiquidarCajaChicaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BoletasDeVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BVPorOrdenDePedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BVPorTransferenciaGratuitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BVPorVentaMostradorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturaPorOrdenDePedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturaPorVentaDeMostradorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarAlCONCARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DomicilioDeFacturacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrdenDePedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AlmacenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OperacionesDeAlmacénToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReporteDeStocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuiasDeRemisiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuiaDeRemisiónPorVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuiaDeRemisiónPorTrasladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AbiertoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VentanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.GuiaDeRemisiónPorTransporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPrincipal
        '
        Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AplicacionToolStripMenuItem, Me.MantenimientoToolStripMenuItem, Me.ContabilidadToolStripMenuItem, Me.VentasToolStripMenuItem, Me.ToolStripMenuItem1, Me.AlmacenToolStripMenuItem, Me.ArchivoToolStripMenuItem, Me.VentanaToolStripMenuItem})
        Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal.MdiWindowListItem = Me.VentanaToolStripMenuItem
        Me.MenuPrincipal.Name = "MenuPrincipal"
        Me.MenuPrincipal.Size = New System.Drawing.Size(1356, 24)
        Me.MenuPrincipal.TabIndex = 1
        '
        'AplicacionToolStripMenuItem
        '
        Me.AplicacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem, Me.ConfiguracionToolStripMenuItem, Me.SesionDeTrabajoToolStripMenuItem})
        Me.AplicacionToolStripMenuItem.Name = "AplicacionToolStripMenuItem"
        Me.AplicacionToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.AplicacionToolStripMenuItem.Tag = "P"
        Me.AplicacionToolStripMenuItem.Text = "Aplicacion"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SalirToolStripMenuItem.Tag = "P"
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlDeAccesosToolStripMenuItem, Me.ParametrosDelSistemaToolStripMenuItem, Me.ControlDePeriodosToolStripMenuItem, Me.PeriodoDeTrabajoToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ConfiguracionToolStripMenuItem.Tag = ""
        Me.ConfiguracionToolStripMenuItem.Text = "Configuracion"
        '
        'ControlDeAccesosToolStripMenuItem
        '
        Me.ControlDeAccesosToolStripMenuItem.Name = "ControlDeAccesosToolStripMenuItem"
        Me.ControlDeAccesosToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ControlDeAccesosToolStripMenuItem.Text = "Control de Accesos"
        '
        'ParametrosDelSistemaToolStripMenuItem
        '
        Me.ParametrosDelSistemaToolStripMenuItem.Name = "ParametrosDelSistemaToolStripMenuItem"
        Me.ParametrosDelSistemaToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ParametrosDelSistemaToolStripMenuItem.Text = "Parametros del Sistema"
        '
        'ControlDePeriodosToolStripMenuItem
        '
        Me.ControlDePeriodosToolStripMenuItem.Name = "ControlDePeriodosToolStripMenuItem"
        Me.ControlDePeriodosToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ControlDePeriodosToolStripMenuItem.Tag = ""
        Me.ControlDePeriodosToolStripMenuItem.Text = "Control de Periodos"
        '
        'PeriodoDeTrabajoToolStripMenuItem
        '
        Me.PeriodoDeTrabajoToolStripMenuItem.Name = "PeriodoDeTrabajoToolStripMenuItem"
        Me.PeriodoDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PeriodoDeTrabajoToolStripMenuItem.Text = "Periodo de Trabajo"
        '
        'SesionDeTrabajoToolStripMenuItem
        '
        Me.SesionDeTrabajoToolStripMenuItem.Name = "SesionDeTrabajoToolStripMenuItem"
        Me.SesionDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SesionDeTrabajoToolStripMenuItem.Tag = "P"
        Me.SesionDeTrabajoToolStripMenuItem.Text = "Sesion de Trabajo"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.CompuestosToolStripMenuItem, Me.TipoDeCambioToolStripMenuItem, Me.TablasGenéricasToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.MantenimientoToolStripMenuItem.Text = "Mantenimiento"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'CompuestosToolStripMenuItem
        '
        Me.CompuestosToolStripMenuItem.Name = "CompuestosToolStripMenuItem"
        Me.CompuestosToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CompuestosToolStripMenuItem.Text = "Compuestos"
        '
        'TipoDeCambioToolStripMenuItem
        '
        Me.TipoDeCambioToolStripMenuItem.Name = "TipoDeCambioToolStripMenuItem"
        Me.TipoDeCambioToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TipoDeCambioToolStripMenuItem.Text = "Tipo de Cambio"
        '
        'TablasGenéricasToolStripMenuItem
        '
        Me.TablasGenéricasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TablasToolStripMenuItem, Me.ElementosToolStripMenuItem})
        Me.TablasGenéricasToolStripMenuItem.Name = "TablasGenéricasToolStripMenuItem"
        Me.TablasGenéricasToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TablasGenéricasToolStripMenuItem.Text = "Tablas Genéricas"
        '
        'TablasToolStripMenuItem
        '
        Me.TablasToolStripMenuItem.Name = "TablasToolStripMenuItem"
        Me.TablasToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.TablasToolStripMenuItem.Text = "Tablas"
        '
        'ElementosToolStripMenuItem
        '
        Me.ElementosToolStripMenuItem.Name = "ElementosToolStripMenuItem"
        Me.ElementosToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ElementosToolStripMenuItem.Text = "Elementos"
        '
        'ContabilidadToolStripMenuItem
        '
        Me.ContabilidadToolStripMenuItem.Checked = True
        Me.ContabilidadToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ContabilidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidarCajaChicaToolStripMenuItem})
        Me.ContabilidadToolStripMenuItem.Name = "ContabilidadToolStripMenuItem"
        Me.ContabilidadToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ContabilidadToolStripMenuItem.Text = "Contabilidad"
        '
        'LiquidarCajaChicaToolStripMenuItem
        '
        Me.LiquidarCajaChicaToolStripMenuItem.Name = "LiquidarCajaChicaToolStripMenuItem"
        Me.LiquidarCajaChicaToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LiquidarCajaChicaToolStripMenuItem.Text = "Liquidar Caja Chica"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BoletasDeVentaToolStripMenuItem, Me.FacturasToolStripMenuItem, Me.ExportarAlCONCARToolStripMenuItem, Me.DomicilioDeFacturacionToolStripMenuItem, Me.OrdenDePedidoToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'BoletasDeVentaToolStripMenuItem
        '
        Me.BoletasDeVentaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BVPorOrdenDePedidoToolStripMenuItem, Me.BVPorTransferenciaGratuitaToolStripMenuItem, Me.BVPorVentaMostradorToolStripMenuItem})
        Me.BoletasDeVentaToolStripMenuItem.Name = "BoletasDeVentaToolStripMenuItem"
        Me.BoletasDeVentaToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.BoletasDeVentaToolStripMenuItem.Text = "Boletas de Venta"
        '
        'BVPorOrdenDePedidoToolStripMenuItem
        '
        Me.BVPorOrdenDePedidoToolStripMenuItem.Name = "BVPorOrdenDePedidoToolStripMenuItem"
        Me.BVPorOrdenDePedidoToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BVPorOrdenDePedidoToolStripMenuItem.Text = "Boleta por Orden de Pedido"
        '
        'BVPorTransferenciaGratuitaToolStripMenuItem
        '
        Me.BVPorTransferenciaGratuitaToolStripMenuItem.Name = "BVPorTransferenciaGratuitaToolStripMenuItem"
        Me.BVPorTransferenciaGratuitaToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BVPorTransferenciaGratuitaToolStripMenuItem.Text = "Boleta por Transferencia Gratuita"
        '
        'BVPorVentaMostradorToolStripMenuItem
        '
        Me.BVPorVentaMostradorToolStripMenuItem.Name = "BVPorVentaMostradorToolStripMenuItem"
        Me.BVPorVentaMostradorToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BVPorVentaMostradorToolStripMenuItem.Text = "Boleta por Venta Mostrador"
        '
        'FacturasToolStripMenuItem
        '
        Me.FacturasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturaPorOrdenDePedidoToolStripMenuItem, Me.FacturaPorVentaDeMostradorToolStripMenuItem})
        Me.FacturasToolStripMenuItem.Name = "FacturasToolStripMenuItem"
        Me.FacturasToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.FacturasToolStripMenuItem.Text = "Facturas"
        '
        'FacturaPorOrdenDePedidoToolStripMenuItem
        '
        Me.FacturaPorOrdenDePedidoToolStripMenuItem.Name = "FacturaPorOrdenDePedidoToolStripMenuItem"
        Me.FacturaPorOrdenDePedidoToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.FacturaPorOrdenDePedidoToolStripMenuItem.Text = "Factura por Orden de Pedido"
        '
        'FacturaPorVentaDeMostradorToolStripMenuItem
        '
        Me.FacturaPorVentaDeMostradorToolStripMenuItem.Name = "FacturaPorVentaDeMostradorToolStripMenuItem"
        Me.FacturaPorVentaDeMostradorToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.FacturaPorVentaDeMostradorToolStripMenuItem.Text = "Factura por Venta de Mostrador"
        '
        'ExportarAlCONCARToolStripMenuItem
        '
        Me.ExportarAlCONCARToolStripMenuItem.Name = "ExportarAlCONCARToolStripMenuItem"
        Me.ExportarAlCONCARToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ExportarAlCONCARToolStripMenuItem.Text = "Exportar al CONCAR"
        '
        'DomicilioDeFacturacionToolStripMenuItem
        '
        Me.DomicilioDeFacturacionToolStripMenuItem.Name = "DomicilioDeFacturacionToolStripMenuItem"
        Me.DomicilioDeFacturacionToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.DomicilioDeFacturacionToolStripMenuItem.Text = "Domicilio de Facturacion"
        '
        'OrdenDePedidoToolStripMenuItem
        '
        Me.OrdenDePedidoToolStripMenuItem.Name = "OrdenDePedidoToolStripMenuItem"
        Me.OrdenDePedidoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OrdenDePedidoToolStripMenuItem.Text = "Orden de Pedido"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'AlmacenToolStripMenuItem
        '
        Me.AlmacenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesDeAlmacénToolStripMenuItem, Me.ReporteDeStocksToolStripMenuItem, Me.GuiasDeRemisiónToolStripMenuItem})
        Me.AlmacenToolStripMenuItem.Name = "AlmacenToolStripMenuItem"
        Me.AlmacenToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.AlmacenToolStripMenuItem.Text = "Almacen"
        '
        'OperacionesDeAlmacénToolStripMenuItem
        '
        Me.OperacionesDeAlmacénToolStripMenuItem.Name = "OperacionesDeAlmacénToolStripMenuItem"
        Me.OperacionesDeAlmacénToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OperacionesDeAlmacénToolStripMenuItem.Text = "Operaciones de Almacén"
        '
        'ReporteDeStocksToolStripMenuItem
        '
        Me.ReporteDeStocksToolStripMenuItem.Name = "ReporteDeStocksToolStripMenuItem"
        Me.ReporteDeStocksToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ReporteDeStocksToolStripMenuItem.Text = "Reporte de Stocks"
        '
        'GuiasDeRemisiónToolStripMenuItem
        '
        Me.GuiasDeRemisiónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuiaDeRemisiónPorVentaToolStripMenuItem, Me.GuiaDeRemisiónPorTrasladoToolStripMenuItem, Me.GuiaDeRemisiónPorTransporteToolStripMenuItem})
        Me.GuiasDeRemisiónToolStripMenuItem.Name = "GuiasDeRemisiónToolStripMenuItem"
        Me.GuiasDeRemisiónToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.GuiasDeRemisiónToolStripMenuItem.Text = "Guias de Remisión"
        '
        'GuiaDeRemisiónPorVentaToolStripMenuItem
        '
        Me.GuiaDeRemisiónPorVentaToolStripMenuItem.Name = "GuiaDeRemisiónPorVentaToolStripMenuItem"
        Me.GuiaDeRemisiónPorVentaToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.GuiaDeRemisiónPorVentaToolStripMenuItem.Text = "Guia de Remisión por Venta"
        '
        'GuiaDeRemisiónPorTrasladoToolStripMenuItem
        '
        Me.GuiaDeRemisiónPorTrasladoToolStripMenuItem.Name = "GuiaDeRemisiónPorTrasladoToolStripMenuItem"
        Me.GuiaDeRemisiónPorTrasladoToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.GuiaDeRemisiónPorTrasladoToolStripMenuItem.Text = "Guia de Remisión Por Traslado"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbiertoToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'AbiertoToolStripMenuItem
        '
        Me.AbiertoToolStripMenuItem.Name = "AbiertoToolStripMenuItem"
        Me.AbiertoToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.AbiertoToolStripMenuItem.Text = "&Abierto"
        '
        'VentanaToolStripMenuItem
        '
        Me.VentanaToolStripMenuItem.Name = "VentanaToolStripMenuItem"
        Me.VentanaToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.VentanaToolStripMenuItem.Text = "&Ventana"
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuario.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.Chocolate
        Me.lblUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUsuario.Location = New System.Drawing.Point(1121, 28)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(229, 20)
        Me.lblUsuario.TabIndex = 46
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GuiaDeRemisiónPorTransporteToolStripMenuItem
        '
        Me.GuiaDeRemisiónPorTransporteToolStripMenuItem.Name = "GuiaDeRemisiónPorTransporteToolStripMenuItem"
        Me.GuiaDeRemisiónPorTransporteToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.GuiaDeRemisiónPorTransporteToolStripMenuItem.Text = "Guia de Remisión por Transporte"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1356, 687)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.MenuPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuPrincipal
        Me.MaximizeBox = False
        Me.Name = "frmMenu"
        Me.Text = "SISTEMA DE GESTION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuPrincipal.ResumeLayout(False)
        Me.MenuPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents AplicacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SesionDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDeAccesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametrosDelSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PeriodoDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDePeriodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TablasGenéricasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TablasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElementosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContabilidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquidarCajaChicaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeCambioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAlCONCARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DomicilioDeFacturacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompuestosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenDePedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbiertoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlmacenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesDeAlmacénToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoletasDeVentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteDeStocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BVPorOrdenDePedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BVPorTransferenciaGratuitaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BVPorVentaMostradorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturaPorOrdenDePedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturaPorVentaDeMostradorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuiasDeRemisiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuiaDeRemisiónPorVentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuiaDeRemisiónPorTrasladoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuiaDeRemisiónPorTransporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
