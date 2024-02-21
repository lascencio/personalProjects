Public Class frmAuditoria
    Private MyVentas As dsVentas.VENTAS_LISTA_AUDIDataTable

    Private Sub frmAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UC_ToolBar.btnGrabar_Visible = False
        UC_ToolBar.btnEditar_Visible = False
        UC_ToolBar.btnBorrar_Visible = False
        UC_ToolBar.btnAceptar_Visible = False
        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnSUNAT_Visible = False
        UC_ToolBar.btnInformacion_Visible = True

        PoblarGrilla()
    End Sub

#Region "Funciones"
    Private Sub PoblarGrilla()
        MyVentas = New dsVentas.VENTAS_LISTA_AUDIDataTable
        MyVentas = dalVenta.BuscarVentasAud(MyUsuario.empresa, MyUsuario.ejercicio, Strings.Right("00" & MyUsuario.mes.ToString, 2), "", "")
        gvVentas.DataSource = MyVentas
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub
#End Region

#Region "Botones"
    Private Sub UC_ToolBar_TB_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Call Salir()
    End Sub
    Private Sub UC_ToolBar_Load(sender As Object, e As EventArgs) Handles UC_ToolBar.Load

    End Sub
    Private Sub UC_ToolBar_TB_btnInformacion_Click() Handles UC_ToolBar.TB_btnInformacion_Click
        Call PoblarGrilla()
    End Sub
#End Region
   
    Private Sub gvVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class
