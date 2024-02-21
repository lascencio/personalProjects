Imports System.Data.SqlClient

Public Class dalCliente


    Private Shared MySql As String
    Private Shared MySqlString As String

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pCliente As String) As Boolean
        If Not String.IsNullOrEmpty(pCliente) Then
            MySqlString = "SELECT COUNT(*) FROM COM.CLIENTES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaComercial", pCliente)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pCliente As String) As entCliente
        If Existe(pEmpresa, pCliente) Then
            CadenaSQL = "SELECT * FROM COM.CLIENTES WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_COMERCIAL='" & pCliente & "'"
            Return Obtener(New entCliente, CadenaSQL)
        Else
            Return New entCliente
        End If
    End Function

    Private Shared Function Obtener(ByVal cCliente As entCliente, ByVal MyStringSQL As String) As entCliente
        Dim MyDT As New dsClientes.CLIENTESDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCliente
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .razon_social = MyDT(0).RAZON_SOCIAL
                .prefijo = MyDT(0).PREFIJO
                .domicilio = MyDT(0).DOMICILIO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .celular = MyDT(0).CELULAR
                .email_contacto = MyDT(0).EMAIL_CONTACTO
                .email_facturacion = MyDT(0).EMAIL_FACTURACION
                .pagina_web = MyDT(0).PAGINA_WEB
                .contacto_venta = MyDT(0).CONTACTO_VENTA
                .contacto_compra = MyDT(0).CONTACTO_COMPRA
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .indica_no_domiciliado = MyDT(0).INDICA_NO_DOMICILIADO
                .condicion_pago = MyDT(0).CONDICION_PAGO
                .tipo_pago = MyDT(0).TIPO_PAGO
                .exige_orden_compra = MyDT(0).EXIGE_ORDEN_COMPRA
                .exige_orden_pago = MyDT(0).EXIGE_ORDEN_PAGO
                .exige_acta_conformidad = MyDT(0).EXIGE_ACTA_CONFORMIDAD
                .usuario_web = MyDT(0).USUARIO_WEB
                .clave_web = MyDT(0).CLAVE_WEB
                .comentario = MyDT(0).COMENTARIO
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cCliente
    End Function

End Class
