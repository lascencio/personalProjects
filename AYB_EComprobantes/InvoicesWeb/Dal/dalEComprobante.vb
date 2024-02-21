Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Net

Public Class dalEComprobante
    Private Shared MySQL As String
    Private Shared MyOleDBString As String
    Private Shared MySQLString As String
    Private Shared MyStoreProcedure As String
    Private Shared MySQLCommand As SqlCommand

#Region "EComprobante"

    Public Shared Function ExisteEComprobante(ByVal cEmpresa As String, cVenta As String) As Boolean
        If Not String.IsNullOrEmpty(cVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cVenta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function ExisteEComprobanteFirma(ByVal cEmpresa As String, cVenta As String) As Boolean
        If Not String.IsNullOrEmpty(cVenta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEmpresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cVenta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cEComprobante As entEComprobante) As Boolean
        If Not String.IsNullOrEmpty(cEComprobante.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES " & _
                          "WHERE Empresa=@vEmpresa AND Cuenta_comercial=@vCuenta_comercial AND " & _
                          "Comprobante_tipo=@vComprobante_tipo AND Comprobante_serie=@vComprobante_serie AND " & _
                          "Comprobante_numero=@vComprobante_numero "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
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

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String) As Boolean
        MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES " & _
                      "WHERE Empresa=@vEmpresa AND Comprobante_tipo=@vComprobante_tipo AND " & _
                      "Comprobante_serie=@vComprobante_serie AND " & _
                      "Comprobante_numero=@vComprobante_numero AND LEN(RTRIM(Usuario_descarga_web))=0 "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vComprobante_tipo", pTipo)
            MySQLCommand.Parameters.AddWithValue("vComprobante_serie", pSerie)
            MySQLCommand.Parameters.AddWithValue("vComprobante_numero", pNumero)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Private Shared Function Existe(ByVal cEComprobanteFirma As entEComprobanteFirma) As Boolean
        If Not String.IsNullOrEmpty(cEComprobanteFirma.venta) Then
            MySQLString = "SELECT COUNT(*) FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa=@vEmpresa AND Venta=@vVenta "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
                Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cEComprobanteFirma.empresa)
                MySQLCommand.Parameters.AddWithValue("vVenta", cEComprobanteFirma.venta)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal cEComprobante As dsEComprobantes.ECOMPROBANTESDataTable) As dsEComprobantes.ECOMPROBANTESDataTable
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

    Public Shared Function Obtener(cEmpresa As String, cVenta As String) As entEComprobanteFirma
        If ExisteEComprobanteFirma(cEmpresa, cVenta) Then
            CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES_FIRMA WHERE Empresa='" & cEmpresa & "' AND Venta='" & cVenta & "' "
            Return Obtener(New entEComprobanteFirma, CadenaSQL)
        Else
            Return New entEComprobanteFirma
        End If
    End Function

    Public Shared Function Obtener(ByVal cEComprobante As entEComprobante) As entEComprobante
        If Existe(cEComprobante) Then
            With cEComprobante
                CadenaSQL = "SELECT * FROM COM.ECOMPROBANTES " & _
                            "WHERE Empresa='" & .empresa & "' AND Cuenta_comercial='" & .cuenta_comercial & "' AND " & _
                            "Comprobante_tipo='" & .comprobante_tipo & "' AND Comprobante_serie='" & .comprobante_serie & "' AND " & _
                            "Comprobante_numero='" & .comprobante_numero & "' "
            End With
            Return Obtener(New entEComprobante, CadenaSQL)
        Else
            Return New entEComprobante
        End If
    End Function

    Private Shared Function Obtener(ByVal cEComprobante As entEComprobante, ByVal MySQLString As String) As entEComprobante
        Dim MyDT As New dsEComprobantes.ECOMPROBANTESDataTable
        Call ObtenerDataTableSQL_EComprobantes(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cEComprobante
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .comprobante_tipo = MyDT(0).COMPROBANTE_TIPO
                .comprobante_serie = MyDT(0).COMPROBANTE_SERIE
                .comprobante_numero = MyDT(0).COMPROBANTE_NUMERO
                .comprobante_fecha = MyDT(0).COMPROBANTE_FECHA
                .comprobante_vencimiento = MyDT(0).COMPROBANTE_VENCIMIENTO
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .dia = MyDT(0).DIA
                .tipo_cambio = MyDT(0).TIPO_CAMBIO
                .moneda = MyDT(0).MONEDA
                .valor_exportacion = MyDT(0).VALOR_EXPORTACION
                .base_imponible_gravada = MyDT(0).BASE_IMPONIBLE_GRAVADA
                .importe_exonerado = MyDT(0).IMPORTE_EXONERADO
                .importe_inafecto = MyDT(0).IMPORTE_INAFECTO
                .isc = MyDT(0).ISC
                .igv = MyDT(0).IGV
                .ipm = MyDT(0).IPM
                .base_imponible_gravada2 = MyDT(0).BASE_IMPONIBLE_GRAVADA2
                .igv2 = MyDT(0).IGV2
                .otros_tributos = MyDT(0).OTROS_TRIBUTOS
                .descuento_global = MyDT(0).DESCUENTO_GLOBAL
                .importe_total = MyDT(0).IMPORTE_TOTAL
                .referencia_tipo = MyDT(0).REFERENCIA_TIPO
                .referencia_serie = MyDT(0).REFERENCIA_SERIE
                .referencia_numero = MyDT(0).REFERENCIA_NUMERO
                If Not MyDT(0).IsNull("REFERENCIA_FECHA") Then .referencia_fecha = MyDT(0).REFERENCIA_FECHA
                .nombre_archivo = MyDT(0).NOMBRE_ARCHIVO
                .usuario_envio = MyDT(0).USUARIO_ENVIO
                .fecha_envio = MyDT(0).FECHA_ENVIO
                .estado_ticket = MyDT(0).ESTADO_TICKET
                .estado_comprobante = MyDT(0).ESTADO_COMPROBANTE
                .email_contacto = MyDT(0).EMAIL_CONTACTO
                .email_facturacion = MyDT(0).EMAIL_FACTURACION
                .usuario_descarga_web = MyDT(0).USUARIO_DESCARGA_WEB
                .fecha_descarga_web = MyDT(0).FECHA_DESCARGA_WEB
                .venta = MyDT(0).VENTA
                .razon_social = MyDT(0).RAZON_SOCIAL
                .mensaje = MyDT(0).MENSAJE
                .digest_value = MyDT(0).DIGEST_VALUE
                .signature_value = MyDT(0).SIGNATURE_VALUE
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cEComprobante
    End Function

    Private Shared Function Obtener(ByVal cEComprobanteFirma As entEComprobanteFirma, ByVal MySQLString As String) As entEComprobanteFirma
        Dim MyDT As New dsEComprobantes.ECOMPROBANTES_FIRMADataTable
        Call ObtenerDataTableSQL_EComprobantes(MySQLString, MyDT)
        If MyDT.Count > 0 Then
            With cEComprobanteFirma
                .empresa = MyDT(0).EMPRESA
                .venta = MyDT(0).VENTA
                .digest_value = MyDT(0).DIGEST_VALUE
                .signature_value = MyDT(0).SIGNATURE_VALUE
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cEComprobanteFirma
    End Function

    Public Shared Function ObtenerEComprobantes(ByVal pEmpresa As String, ByVal pCuentaComercial As String, ByVal pFechaDesde As String, ByVal pFechaHasta As String) As dsEComprobantes.ECOMPROBANTES_LISTADataTable

        MySQLString = "SELECT COMPROBANTE_TIPO, COMPROBANTE_SERIE, COMPROBANTE_NUMERO, COMPROBANTE_FECHA, COMPROBANTE_VENCIMIENTO, " & _
                      "MONEDA, BASE_IMPONIBLE_GRAVADA+IMPORTE_EXONERADO+IMPORTE_INAFECTO AS VALOR_VENTA, " & _
                      "IGV, IMPORTE_TOTAL, NOMBRE_ARCHIVO, RAZON_SOCIAL, MENSAJE " & _
                      "FROM COM.ECOMPROBANTES " & _
                      "WHERE EMPRESA=@vEmpresa " & IIf(pCuentaComercial = "TODOS", "", "AND CUENTA_COMERCIAL=@vCuenta_comercial ") & _
                      "AND (EJERCICIO+MES+DIA BETWEEN @vFecha_desde AND @vFecha_hasta) " & _
                      "ORDER BY COMPROBANTE_FECHA, COMPROBANTE_TIPO, COMPROBANTE_SERIE, COMPROBANTE_NUMERO "

        Dim MyDT As New dsEComprobantes.ECOMPROBANTES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLCommand As New SqlCommand(MySQLString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            If pCuentaComercial <> "TODOS" Then MySQLCommand.Parameters.AddWithValue("vCuenta_comercial", pCuentaComercial)
            MySQLCommand.Parameters.AddWithValue("vFecha_desde", pFechaDesde)
            MySQLCommand.Parameters.AddWithValue("vFecha_hasta", pFechaHasta)

            'MySQLCommand.Connection = MySQLDbconnection
            'MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Sub Actualizar(ByVal pEmpresa As String, ByVal pTipo As String, ByVal pSerie As String, ByVal pNumero As String, ByVal pUsuario As String)
        If Existe(pEmpresa, pTipo, pSerie, pNumero) = True Then
            MySQL = "UPDATE COM.ECOMPROBANTES SET " & _
                    "USUARIO_DESCARGA_WEB=@vUsuario, FECHA_DESCARGA_WEB=GETDATE() " & _
                    "WHERE Empresa=@vEmpresa AND Comprobante_tipo=@vComprobante_tipo AND " & _
                    "Comprobante_serie=@vComprobante_serie AND " & _
                    "Comprobante_numero=@vComprobante_numero "

            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)

                Dim MySQLTransaction As SqlTransaction
                MySQLCommand = New SqlCommand(MySQL, MySQLDbconnection)

                With MySQLCommand.Parameters
                    .AddWithValue("vUsuario", pUsuario)
                    .AddWithValue("vEmpresa", pEmpresa)
                    .AddWithValue("vComprobante_tipo", pTipo)
                    .AddWithValue("vComprobante_serie", pSerie)
                    .AddWithValue("vComprobante_numero", pNumero)
                End With

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
            End Using
        End If
    End Sub

#End Region

End Class
