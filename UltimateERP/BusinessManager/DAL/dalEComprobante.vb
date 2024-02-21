Imports System.Data.SqlClient

Public Class dalEComprobante
    Private Shared MyOleDBString As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String
    Private Shared MySQLCommand As SqlCommand

    Public Shared Function ExisteEComprobante(ByVal cEmpresa As String, cVenta As String) As Boolean
        If Not String.IsNullOrEmpty(cVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cVenta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Sub GrabarFirma(ByVal cEComprobanteFirma As entEComprobanteFirma)
        If Not ExisteFirma(cEComprobanteFirma) Then
            InsertarFirma(cEComprobanteFirma)
        Else
            ActualizarFirma(cEComprobanteFirma)
        End If
    End Sub

    Private Shared Function ExisteFirma(ByVal cEComprobanteFirma As entEComprobanteFirma) As Boolean
        If Not String.IsNullOrEmpty(cEComprobanteFirma.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cEComprobanteFirma.venta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function InsertarFirma(ByVal cEComprobanteFirma As entEComprobanteFirma) As entEComprobanteFirma
        MySQLString = "INSERT INTO COM.ECOMPROBANTES_FIRMA " & _
                      "(empresa,venta,digest_value,signature_value,usuario_registro) " & _
                      "VALUES (@vEmpresa,@vVenta,@vDigest_value,@vSignature_value,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                .AddWithValue("vVenta", cEComprobanteFirma.venta)
                .AddWithValue("vDigest_value", cEComprobanteFirma.digest_value)
                .AddWithValue("vSignature_value", cEComprobanteFirma.signature_value)
                .AddWithValue("vUsuario_registro", cEComprobanteFirma.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobanteFirma
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function ActualizarFirma(ByVal cEComprobanteFirma As entEComprobanteFirma) As entEComprobanteFirma
        MySQLString = "UPDATE COM.ECOMPROBANTES_FIRMA SET " & _
                      "Digest_value=@vDigest_value,Signature_value=@vSignature_value,Usuario_modifica=@vUsuario_modifica,Fecha_modifica=GETDATE() " & _
                      "WHERE Empresa=@vEmpresa AND Venta=@vVenta "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vDigest_value", cEComprobanteFirma.digest_value)
                .AddWithValue("vSignature_value", cEComprobanteFirma.signature_value)
                .AddWithValue("vUsuario_modifica", cEComprobanteFirma.usuario_registro)
                .AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                .AddWithValue("vVenta", cEComprobanteFirma.venta)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobanteFirma
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function ObtenerEComprobante(ByVal cEComprobante As dsEComprobantes.ECOMPROBANTESDataTable) As dsEComprobantes.ECOMPROBANTESDataTable
        Dim MyDT As New dsEComprobantes.ECOMPROBANTESDataTable
        If ExisteEComprobante(cEComprobante(0).EMPRESA, cEComprobante(0).VENTA) Then
            With cEComprobante(0)
                CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES " & _
                            "WHERE Empresa='" & .EMPRESA & "' AND Cuenta_comercial='" & .CUENTA_COMERCIAL & "' AND " & _
                            "Comprobante_tipo='" & .COMPROBANTE_TIPO & "' AND Comprobante_serie='" & .COMPROBANTE_SERIE & "' AND " & _
                            "Comprobante_numero='" & .COMPROBANTE_NUMERO & "' "
            End With
            Call ObtenerDataTableSQL_EComprobantes(CadenaSQL, MyDT)
        End If
        Return MyDT
    End Function

    Public Shared Sub GrabarEComprobante(ByVal cEComprobante As entEComprobante)
        If Not ExisteEComprobante(cEComprobante) Then
            InsertarEComprobante(cEComprobante)
        End If
    End Sub

    Private Shared Function ExisteEComprobante(ByVal cEComprobante As entEComprobante) As Boolean
        If Not String.IsNullOrEmpty(cEComprobante.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES " & _
                          "WHERE Empresa=@vEmpresa AND Cuenta_comercial=@vCuenta_comercial AND " & _
                          "Comprobante_tipo=@vComprobante_tipo AND Comprobante_serie=@vComprobante_serie AND " & _
                          "Comprobante_numero=@vComprobante_numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                MySQLCommand = New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEComprobante.empresa)
                MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial)
                MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                MySQLCommand.Parameters.AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                MySQLCommand.Parameters.AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function InsertarEComprobante(ByVal cEComprobante As entEComprobante) As entEComprobante
        MySQLString = "INSERT INTO COM.ECOMPROBANTES " & _
                      "(empresa,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero,comprobante_fecha,comprobante_vencimiento," & _
                      "ejercicio,mes,dia,tipo_cambio,moneda,valor_exportacion,base_imponible_gravada,importe_exonerado,importe_inafecto,isc,igv,ipm," & _
                      "base_imponible_gravada2,igv2,otros_tributos,descuento_global,importe_total,referencia_tipo,referencia_serie,referencia_numero,referencia_fecha," & _
                      "nombre_archivo,usuario_envio,fecha_envio,estado_ticket,estado_comprobante,email_contacto,email_facturacion,venta, razon_social," & _
                      "mensaje,digest_value,signature_value,usuario_registro) " & _
                      "VALUES (@vEmpresa,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero,@vComprobante_fecha,@vComprobante_vencimiento," & _
                      "@vEjercicio,@vMes,@vDia,@vTipo_cambio,@vMoneda,@vValor_exportacion,@vBase_imponible_gravada,@vImporte_exonerado,@vImporte_inafecto,@vIsc,@vIgv,@vIpm," & _
                      "@vBase_imponible_gravada2,@vIgv2,@vOtros_tributos,@vDescuento_global,@vImporte_total,@vReferencia_tipo,@vReferencia_serie,@vReferencia_numero,@vReferencia_fecha," & _
                      "@vNombre_archivo,@vUsuario_envio,@vFecha_envio,@vEstado_ticket,@vEstado_comprobante,@vEmail_contacto,@vEmail_facturacion,@vVenta,@vRazon_social," & _
                      "@vMensaje,@vDigest_value,@vSignature_value,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobante.empresa)
                .AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial.Trim)
                .AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                .AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                .AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                .AddWithValue("vComprobante_fecha", cEComprobante.comprobante_fecha)
                .AddWithValue("vComprobante_vencimiento", cEComprobante.comprobante_vencimiento)
                .AddWithValue("vEjercicio", cEComprobante.ejercicio)
                .AddWithValue("vMes", cEComprobante.mes)
                .AddWithValue("vDia", cEComprobante.dia)
                .AddWithValue("vTipo_cambio", cEComprobante.tipo_cambio)
                .AddWithValue("vMoneda", cEComprobante.moneda)
                .AddWithValue("vValor_exportacion", cEComprobante.valor_exportacion)
                .AddWithValue("vBase_imponible_gravada", cEComprobante.base_imponible_gravada)
                .AddWithValue("vImporte_exonerado", cEComprobante.importe_exonerado)
                .AddWithValue("vImporte_inafecto", cEComprobante.importe_inafecto)
                .AddWithValue("vIsc", cEComprobante.isc)
                .AddWithValue("vIgv", cEComprobante.igv)
                .AddWithValue("vIpm", cEComprobante.ipm)
                .AddWithValue("vBase_imponible_gravada2", cEComprobante.base_imponible_gravada2)
                .AddWithValue("vIgv2", cEComprobante.igv2)
                .AddWithValue("vOtros_tributos", cEComprobante.otros_tributos)
                .AddWithValue("vDescuento_global", cEComprobante.descuento_global)
                .AddWithValue("vImporte_total", cEComprobante.importe_total)
                .AddWithValue("vReferencia_tipo", cEComprobante.referencia_tipo)
                .AddWithValue("vReferencia_serie", cEComprobante.referencia_serie)
                .AddWithValue("vReferencia_numero", cEComprobante.referencia_numero)
                .AddWithValue("vReferencia_fecha", cEComprobante.referencia_fecha)
                .AddWithValue("vNombre_archivo", cEComprobante.nombre_archivo)
                .AddWithValue("vUsuario_envio", cEComprobante.usuario_envio)
                .AddWithValue("vFecha_envio", cEComprobante.fecha_envio)
                .AddWithValue("vEstado_ticket", cEComprobante.estado_ticket)
                .AddWithValue("vEstado_comprobante", cEComprobante.estado_comprobante)
                .AddWithValue("vEmail_contacto", cEComprobante.email_contacto)
                .AddWithValue("vEmail_facturacion", cEComprobante.email_facturacion)
                .AddWithValue("vVenta", cEComprobante.venta)
                .AddWithValue("vRazon_social", cEComprobante.razon_social)
                .AddWithValue("vMensaje", cEComprobante.mensaje)
                .AddWithValue("vDigest_value", cEComprobante.digest_value)
                .AddWithValue("vSignature_value", cEComprobante.signature_value)
                .AddWithValue("vUsuario_registro", cEComprobante.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobante
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Sub GrabarError(ByVal cEComprobante As entEComprobante)
        InsertarError(cEComprobante)
    End Sub

    Private Shared Function InsertarError(ByVal cEComprobante As entEComprobante) As entEComprobante
        MySQLString = "INSERT INTO COM.ECOMPROBANTES_ERROR " & _
                      "(empresa,cuenta_comercial,comprobante_tipo,comprobante_serie,comprobante_numero," & _
                      "estado_ticket,estado_comprobante,mensaje,usuario_registro) " & _
                      "VALUES (@vEmpresa,@vCuenta_comercial,@vComprobante_tipo,@vComprobante_serie,@vComprobante_numero," & _
                      "@vEstado_ticket,@vEstado_comprobante,@vMensaje,@vUsuario_registro) "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cEComprobante.empresa)
                .AddWithValue("vCuenta_comercial", cEComprobante.cuenta_comercial.Trim)
                .AddWithValue("vComprobante_tipo", cEComprobante.comprobante_tipo)
                .AddWithValue("vComprobante_serie", cEComprobante.comprobante_serie)
                .AddWithValue("vComprobante_numero", cEComprobante.comprobante_numero)
                .AddWithValue("vEstado_ticket", cEComprobante.estado_ticket)
                .AddWithValue("vEstado_comprobante", cEComprobante.estado_comprobante)
                .AddWithValue("vMensaje", cEComprobante.mensaje)
                .AddWithValue("vUsuario_registro", cEComprobante.usuario_registro)
            End With
            Try
                MySQLDbconnection.Open()
                MySQLTransaction = MySQLDbconnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()
                MySQLTransaction.Commit()
                Return cEComprobante
            Catch ex As Exception
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Sub CargarEComprobante(NombreArchivo As String)
        Dim miUri As String = "ftp://ftp.smarterasp.net/" & NombreArchivo

        Dim miRequest As Net.FtpWebRequest = Net.WebRequest.Create(miUri)
        miRequest.Credentials = New Net.NetworkCredential("userftp_lidoma", "lidoma2019")
        miRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
        Try
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(MyTempPath & "\" & NombreArchivo)
            Dim miStream As System.IO.Stream = miRequest.GetRequestStream()
            miStream.Write(bFile, 0, bFile.Length)
            miStream.Close()
            miStream.Dispose()

            'My.Computer.FileSystem.DeleteFile(MyTempPath & "\" & NombreArchivo)

        Catch ex As Exception
            Resp = MsgBox("ERROR: " & ex.Message.ToString)
        End Try
    End Sub

End Class
