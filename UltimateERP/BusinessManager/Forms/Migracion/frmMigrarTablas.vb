Imports System.IO

Public Class frmMigrarTablas
    Private MyAlmacen As dsTablasGenericas.LISTADataTable
    Private MyCarpeta As String
    Dim MyDT_Migrar As DataTable

    Private Sub frmMigrarTablas_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyAlmacen = New dsTablasGenericas.LISTADataTable

        For I = 0 To MyDTAlmacenes.Rows.Count - 1
            With MyDTAlmacenes(I)
                MyAlmacen.Rows.Add(.TABLA, .CODIGO, .DESCRIPCION, .DESCRIPCION_AMPLIADA, .REFERENCIA, .ES_VEHICULAR)
            End With
        Next I

        cmbAlmacen.DataSource = MyAlmacen
        cmbTabla.SelectedIndex = -1

        UC_ToolBar.btnNuevo_Visible = False
        UC_ToolBar.btnEditar_Visible = False
    End Sub

#Region "Botones"

    Private Sub btnSeleccionarCarpeta_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCarpeta.Click
        Dim MyFolderDialog As New FolderBrowserDialog

        If (MyFolderDialog.ShowDialog = DialogResult.OK) Then MyCarpeta = MyFolderDialog.SelectedPath

        If Directory.Exists(MyCarpeta) Then
            txtCarpetaArchivos.Text = MyCarpeta
        Else
            txtCarpetaArchivos.Text = Nothing
            Resp = MsgBox("La carpeta " & MyCarpeta & " no existe.", MsgBoxStyle.Critical, "MIGRAR TABLAS VFP")
        End If
    End Sub

    Private Sub UC_ToolBar_btnAceptar_Click() Handles UC_ToolBar.TB_btnAceptar_Click
        Dim NombreTabla As String
        If txtCarpetaArchivos.Text.Trim.Length <> 0 Then
            If cmbAlmacen.SelectedIndex <> -1 And cmbTabla.SelectedIndex <> -1 Then
                MyDT_Migrar = New DataTable
                gvRegistros.DataSource = MyDT_Migrar
                NombreTabla = MyCarpeta & "\" & cmbTabla.Text & ".dbf"
                If File.Exists(NombreTabla) Then
                    MyDT_Migrar = dalMigracion.ObtenerDetalles(cmbAlmacen.SelectedValue, cmbTabla.Text, MyCarpeta)
                    If MyDT_Migrar.Rows.Count <> 0 Then

                        'If dalMigracion.InsertarRegistros(MyProgressBar, cmbAlmacen.SelectedValue, cmbTabla.Text, MyDT_Migrar) = True Then
                        '    Resp = MsgBox("La tabla " & NombreTabla & " fué migrada exitósamente.", MsgBoxStyle.Information, "MIGRAR TABLAS VFP")
                        'Else
                        '    Throw New BusinessException("No se migraron registro de la tabla.")
                        'End If

                        If dalMigracion.Insertar(cmbAlmacen.SelectedValue, cmbTabla.Text, MyDT_Migrar) = True Then
                            Resp = MsgBox("La tabla " & NombreTabla & " fué migrada exitósamente.", MsgBoxStyle.Information, "MIGRAR TABLAS VFP")
                        Else
                            Throw New BusinessException("No se migraron registro de la tabla.")
                        End If

                    Else
                        Resp = MsgBox("La tabla " & NombreTabla & " no contiene registros a migrar.", MsgBoxStyle.Exclamation, "MIGRAR TABLAS VFP")
                    End If
                Else
                    Resp = MsgBox("La tabla " & NombreTabla & " no existe.", MsgBoxStyle.Critical, "MIGRAR TABLAS VFP")
                End If
                gvRegistros.DataSource = MyDT_Migrar
            End If
        End If
    End Sub

    Private Sub UC_ToolBar_btnSalir_Click() Handles UC_ToolBar.TB_btnSalir_Click
        Me.Close()
    End Sub

#End Region

End Class
