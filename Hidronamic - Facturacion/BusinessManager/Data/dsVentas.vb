Partial Class dsVentas
    Partial Class VENTAS_LISTA_AUDIDataTable

        Private Sub VENTAS_LISTA_AUDIDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.USUARIO_REGISTROColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Class VENTASDataTable

    End Class

End Class
