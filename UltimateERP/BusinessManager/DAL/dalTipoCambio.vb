Imports System.Data.SqlClient

Public Class dalTipoCambio
    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pMoneda As String) As Boolean
        If Not String.IsNullOrEmpty(pMes) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM GEN.TIPO_CAMBIO WHERE Ejercicio=@vEjercicio AND Mes=@vMes AND Dia=@vDia AND Moneda=@vMoneda"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", pMes)
                MySQLCommand.Parameters.AddWithValue("vDia", pDia)
                MySQLCommand.Parameters.AddWithValue("vMoneda", pMoneda)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cTipoCambio As entTipoCambio) As Boolean
        If Not String.IsNullOrEmpty(cTipoCambio.mes) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM GEN.TIPO_CAMBIO WHERE Ejercicio=@vEjercicio AND Mes=@vMes AND Dia=@vDia AND Moneda=@vMoneda"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEjercicio", cTipoCambio.ejercicio)
                MySQLCommand.Parameters.AddWithValue("vMes", cTipoCambio.mes)
                MySQLCommand.Parameters.AddWithValue("vDia", cTipoCambio.dia)
                MySQLCommand.Parameters.AddWithValue("vMoneda", cTipoCambio.moneda)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pMoneda As String) As entTipoCambio
        If Existe(pEjercicio, pMes, pDia, pMoneda) Then
            CadenaSQL = "SELECT * FROM GEN.TIPO_CAMBIO WHERE Ejercicio='" & pEjercicio & "' AND Mes='" & pMes & "' AND Dia='" & pDia & "' AND Moneda='" & pMoneda & "' "
            Return Obtener(New entTipoCambio, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entTipoCambio
        End If
    End Function

    Private Shared Function Obtener(ByVal cTipoCambio As entTipoCambio, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entTipoCambio
        Dim MyDT As New dsTipoCambio.TIPO_CAMBIODataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cTipoCambio
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .dia = MyDT(0).DIA
                .moneda = MyDT(0).MONEDA
                .compra = MyDT(0).COMPRA
                .venta = MyDT(0).VENTA
                .promedio = MyDT(0).PROMEDIO
                .compra_preferencial = MyDT(0).COMPRA_PREFERENCIAL
                .venta_preferencial = MyDT(0).VENTA_PREFERENCIAL
                .compra_referencial = MyDT(0).COMPRA_REFERENCIAL
                .venta_referencial = MyDT(0).VENTA_REFERENCIAL
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cTipoCambio
    End Function

    Public Shared Function Grabar(ByVal cTipoCambio As entTipoCambio) As entTipoCambio
        With cTipoCambio
            If String.IsNullOrEmpty(.ejercicio) Then Throw New BusinessException(MSG000 & " EJERCICIO")
            If String.IsNullOrEmpty(.mes) Then Throw New BusinessException(MSG000 & " MES")
            If String.IsNullOrEmpty(.dia) Then Throw New BusinessException(MSG000 & " DIA")
            If String.IsNullOrEmpty(.moneda) Then Throw New BusinessException(MSG000 & " MONEDA")
            If .compra = 0 Then Throw New BusinessException(MSG000 & " COMPRA")
            If .venta = 0 Then Throw New BusinessException(MSG000 & " VENTA")

            If .compra > .venta Then
                Throw New BusinessException("El Tipo Cambio Compra no debe ser mayor que el de Venta")
            End If

        End With

        If Not Existe(cTipoCambio) Then
            Return Insertar(cTipoCambio, myConnectionStringSQL_Repository)
        Else
            Return Actualizar(cTipoCambio)
        End If
    End Function

    Private Shared Function Insertar(ByVal cTipoCambio As entTipoCambio, ByVal MyConnectionString As String) As entTipoCambio
        Dim MyStringSql As String = "INSERT INTO GEN.TIPO_CAMBIO " & _
        "(ejercicio,mes,dia,moneda,compra,venta,promedio,compra_preferencial,venta_preferencial," & _
        "compra_referencial,venta_referencial,usuario_registro) " & _
        "VALUES (@vEjercicio,@vMes,@vDia,@vMoneda,@vCompra,@vVenta,@vPromedio,@vCompra_preferencial,@vVenta_preferencial," & _
        "@vCompra_referencial,@vVenta_referencial,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MyStringSql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEjercicio", cTipoCambio.ejercicio)
                .AddWithValue("vMes", cTipoCambio.mes)
                .AddWithValue("vDia", cTipoCambio.dia)
                .AddWithValue("vMoneda", cTipoCambio.moneda)
                .AddWithValue("vCompra", cTipoCambio.compra)
                .AddWithValue("vVenta", cTipoCambio.venta)
                .AddWithValue("vPromedio", cTipoCambio.promedio)
                .AddWithValue("vCompra_preferencial", cTipoCambio.compra_preferencial)
                .AddWithValue("vVenta_preferencial", cTipoCambio.venta_preferencial)
                .AddWithValue("vCompra_referencial", cTipoCambio.compra_referencial)
                .AddWithValue("vVenta_referencial", cTipoCambio.venta_referencial)
                .AddWithValue("vUsuario_registro", MyUsuario.usuario)
            End With

            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return cTipoCambio

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Function

    Private Shared Function Actualizar(ByVal cTipoCambio As entTipoCambio) As entTipoCambio

        Dim MySql As String = "UPDATE GEN.TIPO_CAMBIO SET " & _
        "compra=@vCompra,venta=@vVenta,promedio=@vPromedio,compra_preferencial=@vCompra_preferencial,venta_preferencial=@vVenta_preferencial," & _
        "compra_referencial=@vCompra_referencial,venta_referencial=@vVenta_referencial,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica " & _
        "WHERE Ejercicio=@vEjercicio AND Mes=@vMes AND Dia=@vDia AND Moneda=@vMoneda"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vCompra", cTipoCambio.compra)
                .AddWithValue("vVenta", cTipoCambio.venta)
                .AddWithValue("vPromedio", cTipoCambio.promedio)
                .AddWithValue("vCompra_preferencial", cTipoCambio.compra_preferencial)
                .AddWithValue("vVenta_preferencial", cTipoCambio.venta_preferencial)
                .AddWithValue("vCompra_referencial", cTipoCambio.compra_referencial)
                .AddWithValue("vVenta_referencial", cTipoCambio.venta_referencial)
                .AddWithValue("vUsuario_modifica", MyUsuario.usuario)
                .AddWithValue("vFecha_modifica", cTipoCambio.fecha_modifica)
                .AddWithValue("vEjercicio", cTipoCambio.ejercicio)
                .AddWithValue("vMes", cTipoCambio.mes)
                .AddWithValue("vDia", cTipoCambio.dia)
                .AddWithValue("vMoneda", cTipoCambio.moneda)
            End With
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()
                Return cTipoCambio

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function Borrar(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pMoneda As String) As Boolean
        If Not String.IsNullOrEmpty(pMes) Then
            Resp = MsgBox("Confirmar proceso de eliminación.", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                Call Eliminar(pEjercicio, pMes, pDia, pMoneda)
                Return True
            End If
        End If
    End Function

    Private Shared Function Eliminar(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pMoneda As String) As Boolean
        Dim MySqlString As String = "DELETE FROM GEN.TIPO_CAMBIO WHERE Ejercicio=@vEjercicio AND Mes=@vMes AND Dia=@vDia AND Moneda=@vMoneda "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vDia", pDia)
            MySQLCommand.Parameters.AddWithValue("vMoneda", pMoneda)
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                Return True

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using
    End Function

    Public Shared Function BuscarTipoCambioMes(ByVal pEjercicio As String, ByVal pMes As String, ByVal pMoneda As String) As dsTipoCambio.TIPO_CAMBIODataTable
        Dim MyStoreProcedure As String = "GEN.TIPO_CAMBIO_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EJERCICIO", SqlDbType.Char, 4) : MyParameter_1.Value = pEjercicio
        Dim MyParameter_2 As New SqlParameter("@MES", SqlDbType.Char, 2) : MyParameter_2.Value = pMes
        Dim MyParameter_3 As New SqlParameter("@MONEDA", SqlDbType.Char, 1) : MyParameter_3.Value = pMoneda

        Dim MyDT As New dsTipoCambio.TIPO_CAMBIODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarTipoCambio(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pMoneda As String) As dsTipoCambio.TIPO_CAMBIODataTable
        Dim MySqlString As String = "SELECT * FROM GEN.TIPO_CAMBIO WHERE Ejercicio=@vEjercicio AND Mes=@vMes AND Dia=@vDia AND Moneda=@vMoneda "

        Dim MyDT As New dsTipoCambio.TIPO_CAMBIODataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vDia", pDia)
            MySQLCommand.Parameters.AddWithValue("vMoneda", pMoneda)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

End Class
