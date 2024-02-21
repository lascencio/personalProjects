Imports System.Data.SqlClient

Public Class dalCuentaComercial
    Private Shared MySql As String
    Private Shared MySqlString As String
    Private Shared MyStoreProcedure As String

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal cCliente As entCONCAR_Cliente) As Boolean
        MySqlString = "SELECT COUNT(*) FROM COM.CLIENTES WHERE AVANEXO='C' AND ACODANE=@vCuentaComercial"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vCuentaComercial", cCliente.acodane)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function

    Public Shared Function Obtener(ByRef cCliente As entCONCAR_Cliente) As entCONCAR_Cliente
        Dim MyDT As New dsClientes.CONCAR_CLIENTESDataTable

        MySql = "SELECT * FROM COM.CLIENTES WHERE AVANEXO='" & cCliente.avanexo & "' AND ACODANE='" & cCliente.acodane & "' "

        Call ObtenerDataTableSQL_Web(MySql, MyDT)

        cCliente = New entCONCAR_Cliente

        If MyDT.Count > 0 Then
            With cCliente
                .avanexo = MyDT(0).AVANEXO
                .acodane = MyDT(0).ACODANE
                .adesane = MyDT(0).ADESANE.Trim
                .arefane = MyDT(0).AREFANE.Trim
                .aruc = MyDT(0).ARUC_
                .acodmon = MyDT(0).ACODMON
                .aestado = MyDT(0).AESTADO
                .atiptra = MyDT(0).ATIPTRA
                .apaterno = MyDT(0).APATERNO
                .amaterno = MyDT(0).AMATERNO
                .anombre = MyDT(0).ANOMBRE
                .aemail = MyDT(0).AEMAIL
                .ahost = MyDT(0).AHOST
                .adocide = MyDT(0).ADOCIDE
                .anumide = MyDT(0).ANUMIDE
            End With
        End If
        Return cCliente
    End Function

    Public Shared Function Grabar(ByVal cCliente As entCONCAR_Cliente) As entCONCAR_Cliente
        With cCliente
            If String.IsNullOrEmpty(.adesane.Trim) Then Throw New BusinessException(MSG000 & " RAZON SOCIAL")

        End With

        If Not Existe(cCliente) Then
            Return Insertar(cCliente)
        Else
            Return Actualizar(cCliente)
        End If
    End Function

    Private Shared Function Insertar(ByVal cCliente As entCONCAR_Cliente) As entCONCAR_Cliente
        MySql = "INSERT INTO COM.CLIENTES " & _
                "(avanexo,acodane,adesane,arefane,aruc,atiptra,aemail,ahost,aestado) " & _
                "VALUES (@vAvanexo,@vAcodane,@vAdesane,@vArefane,@vAruc,@vAtiptra,@vAemail,@vAhost,@vAestado)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAvanexo", cCliente.avanexo)
                .AddWithValue("vAcodane", cCliente.acodane)
                .AddWithValue("vAdesane", cCliente.adesane)
                .AddWithValue("vArefane", cCliente.arefane)
                .AddWithValue("vAruc", cCliente.aruc)
                .AddWithValue("vAtiptra", cCliente.atiptra)
                .AddWithValue("vAemail", cCliente.aemail)
                .AddWithValue("vAhost", cCliente.ahost)
                .AddWithValue("vAestado", cCliente.aestado)
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

                Return cCliente

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

    Private Shared Function Actualizar(ByVal cCliente As entCONCAR_Cliente) As entCONCAR_Cliente
        MySql = "UPDATE COM.CLIENTES SET " & _
                "adesane=@vAdesane,arefane=@vArefane,atiptra=@vAtiptra,aemail=@vAemail,ahost=@vAhost,aestado=@vAestado " & _
                "WHERE avanexo=@vAvanexo AND acodane=@vAcodane "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAdesane", cCliente.adesane)
                .AddWithValue("vArefane", cCliente.arefane)
                .AddWithValue("vAruc", cCliente.aruc)
                .AddWithValue("vAtiptra", cCliente.atiptra)
                .AddWithValue("vAemail", cCliente.aemail)
                .AddWithValue("vAhost", cCliente.ahost)
                .AddWithValue("vAestado", cCliente.aestado)
                .AddWithValue("vAvanexo", cCliente.avanexo)
                .AddWithValue("vAcodane", cCliente.acodane)
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

                Return cCliente

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

    Public Shared Function ConsultarDatosRUC(NumeroRUC As String) As dsClientes.CONSULTAR_DATOS_RUCDataTable
        MyStoreProcedure = "GEN.CONSULTAR_DATOS_RUC"
        Dim MyParameter_1 As New SqlParameter("@RUC", SqlDbType.Char, 11) : MyParameter_1.Value = NumeroRUC

        Dim MyDT As New dsClientes.CONSULTAR_DATOS_RUCDataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Consulta_RUC)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerECliente(ByRef cCliente As entCliente) As entCliente

        Dim MyDT As New dsCuentasComerciales.CLIENTEDataTable
        MySql = "SELECT * FROM COM.CLIENTES WHERE EMPRESA='" & cCliente.empresa & "' AND CUENTA_COMERCIAL='" & cCliente.cuenta_comercial.Trim & "' "

        Call ObtenerDataTableSQL_EComprobantes(MySql, MyDT)
        cCliente = New entCliente

        If MyDT.Count > 0 Then
            With cCliente
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .razon_social = MyDT(0).RAZON_SOCIAL.Trim
                .prefijo = MyDT(0).PREFIJO.Trim
                .indica_no_domiciliado = MyDT(0).INDICA_NO_DOMICILIADO
                .domicilio = MyDT(0).DOMICILIO.Trim
                .email_contacto = MyDT(0).EMAIL_CONTACTO.Trim
                .email_facturacion = MyDT(0).EMAIL_FACTURACION.Trim
                .usuario_web = MyDT(0).USUARIO_WEB.Trim
                .clave_web = MyDT(0).CLAVE_WEB.Trim
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cCliente

    End Function

    Public Shared Function ObtenerClienteRUC(ByVal pNumeroDocumento As String) As entCuentaComercial
        CadenaSQL = "SELECT * FROM COM.CUENTAS_COMERCIALES WHERE EMPRESA='" & MyUsuario.empresa & "' AND NRO_DOCUMENTO='" & pNumeroDocumento & "' AND INDICA_CLIENTE='SI' "
        Return Obtener(New entCuentaComercial, CadenaSQL, myConnectionStringSQL_Repository)
    End Function

    Private Shared Function Obtener(ByVal cCuentaComercial As entCuentaComercial, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entCuentaComercial
        Dim MyDT As New dsCuentasComerciales.CUENTAS_COMERCIALESDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cCuentaComercial
                .empresa = MyDT(0).EMPRESA
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .tipo_documento = MyDT(0).TIPO_DOCUMENTO
                .nro_documento = MyDT(0).NRO_DOCUMENTO
                .razon_social = MyDT(0).RAZON_SOCIAL
                .domicilio = MyDT(0).DOMICILIO
                .siglas = MyDT(0).SIGLAS
                .via_tipo = MyDT(0).VIA_TIPO
                .via_nombre = MyDT(0).VIA_NOMBRE
                .via_numero = MyDT(0).VIA_NUMERO
                .via_interior = MyDT(0).VIA_INTERIOR
                .zona_tipo = MyDT(0).ZONA_TIPO
                .zona_nombre = MyDT(0).ZONA_NOMBRE
                .referencia = MyDT(0).REFERENCIA
                .pais = MyDT(0).PAIS
                .departamento = MyDT(0).DEPARTAMENTO
                .provincia = MyDT(0).PROVINCIA
                .ubigeo = MyDT(0).UBIGEO
                .indica_no_domiciliado = MyDT(0).INDICA_NO_DOMICILIADO
                .domicilio_envio = MyDT(0).DOMICILIO_ENVIO
                .codigo_postal = MyDT(0).CODIGO_POSTAL
                .telefono = MyDT(0).TELEFONO
                .celular = MyDT(0).CELULAR
                .fax = MyDT(0).FAX
                .email = MyDT(0).EMAIL
                .pagina_web = MyDT(0).PAGINA_WEB
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .contacto_comercial = MyDT(0).CONTACTO_COMERCIAL
                .condicion_pago = MyDT(0).CONDICION_PAGO
                .tipo_pago = MyDT(0).TIPO_PAGO
                .tipo_documento_pago = MyDT(0).TIPO_DOCUMENTO_PAGO
                .linea_credito_mn = MyDT(0).LINEA_CREDITO_MN
                .linea_credito_me = MyDT(0).LINEA_CREDITO_ME
                If Not MyDT(0).IsNull("VIGENCIA_CREDITO") Then .vigencia_credito = MyDT(0).VIGENCIA_CREDITO
                .lista_precios = MyDT(0).LISTA_PRECIOS
                .porcentaje_descuento_1 = MyDT(0).PORCENTAJE_DESCUENTO_1
                .porcentaje_descuento_2 = MyDT(0).PORCENTAJE_DESCUENTO_2
                .porcentaje_descuento_3 = MyDT(0).PORCENTAJE_DESCUENTO_3
                .cuenta_contable_cliente_mn = MyDT(0).CUENTA_CONTABLE_CLIENTE_MN
                .cuenta_contable_cliente_me = MyDT(0).CUENTA_CONTABLE_CLIENTE_ME
                .cuenta_contable_proveedor_mn = MyDT(0).CUENTA_CONTABLE_PROVEEDOR_MN
                .cuenta_contable_proveedor_me = MyDT(0).CUENTA_CONTABLE_PROVEEDOR_ME
                .cuenta_contable_ingreso = MyDT(0).CUENTA_CONTABLE_INGRESO
                .cuenta_contable_gasto = MyDT(0).CUENTA_CONTABLE_GASTO
                .cuenta_bancaria_mn = MyDT(0).CUENTA_BANCARIA_MN
                .cuenta_bancaria_me = MyDT(0).CUENTA_BANCARIA_ME
                .banco_pago_me = MyDT(0).BANCO_PAGO_ME
                .banco_pago_mn = MyDT(0).BANCO_PAGO_MN
                .vigente_sunat = MyDT(0).VIGENTE_SUNAT

                If Not MyDT(0).IsNull("FECHA_ALTA_SUNAT") Then .fecha_alta_sunat = MyDT(0).FECHA_ALTA_SUNAT
                .afecto_igv = MyDT(0).AFECTO_IGV
                .agente_retencion = MyDT(0).AGENTE_RETENCION
                .agente_detraccion = MyDT(0).AGENTE_DETRACCION
                .agente_percepcion = MyDT(0).AGENTE_PERCEPCION
                .indica_cliente = MyDT(0).INDICA_CLIENTE
                .indica_proveedor = MyDT(0).INDICA_PROVEEDOR
                .codigo_vendedor = MyDT(0).CODIGO_VENDEDOR
                .codigo_comprador = MyDT(0).CODIGO_COMPRADOR
                .ultima_compra = MyDT(0).ULTIMA_COMPRA
                .ultima_venta = MyDT(0).ULTIMA_VENTA
                .apellido_paterno = MyDT(0).APELLIDO_PATERNO
                .apellido_materno = MyDT(0).APELLIDO_MATERNO
                .nombres = MyDT(0).NOMBRES

                If Not MyDT(0).IsNull("FECHA_NACIMIENTO") Then .fecha_nacimiento = MyDT(0).FECHA_NACIMIENTO
                .sexo = MyDT(0).SEXO
                .calificacion = MyDT(0).CALIFICACION
                .zona_comercial = MyDT(0).ZONA_COMERCIAL
                .comentario = MyDT(0).COMENTARIO
                .usuario_web = MyDT(0).USUARIO_WEB
                .clave_web = MyDT(0).CLAVE_WEB
                .codigo_antiguo = MyDT(0).CODIGO_ANTIGUO
                .cuenta_detraccion = MyDT(0).CUENTA_DETRACCION
                .porcentaje_detraccion = MyDT(0).PORCENTAJE_DETRACCION
                .estado = MyDT(0).ESTADO
                .item_flujo = MyDT(0).ITEM_FLUJO
                .exige_orden_compra = MyDT(0).EXIGE_ORDEN_COMPRA
                .tipo_orden_compra = MyDT(0).TIPO_ORDEN_COMPRA
                .exige_orden_pago = MyDT(0).EXIGE_ORDEN_PAGO
                .tipo_orden_pago = MyDT(0).TIPO_ORDEN_PAGO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO

                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cCuentaComercial
    End Function

    Public Shared Function GrabarECliente(ByVal cCliente As entCliente) As entCliente
        With cCliente
            If String.IsNullOrEmpty(.cuenta_comercial) Then Throw New BusinessException(MSG000 & " DOCUMENTO IDENTIDAD")
            If String.IsNullOrEmpty(.razon_social.Trim) Then Throw New BusinessException(MSG000 & " RAZON SOCIAL")
            'If String.IsNullOrEmpty(.prefijo.Trim) Then Throw New BusinessException(MSG000 & " PREFIJO")
        End With

        If Not ExisteECliente(cCliente) Then
            Return InsertarECliente(cCliente)
        Else
            Return ActualizarECliente(cCliente)
        End If
    End Function

    Public Shared Function ExisteECliente(ByVal cCliente As entCliente) As Boolean        MySqlString = "SELECT COUNT(*) FROM COM.CLIENTES WHERE Empresa=@vEmpresa AND Cuenta_Comercial=@vCuentaComercial"        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", cCliente.empresa)
            MySQLCommand.Parameters.AddWithValue("vCuentaComercial", cCliente.cuenta_comercial.Trim)
            MySQLDbconnection.Open()
            Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
            Return IIf(MyCount = 0, False, True)
        End Using
    End Function
    Public Shared Function InsertarECliente(ByVal cCliente As entCliente) As entCliente
        MySql = "INSERT INTO COM.CLIENTES " & _
                "(empresa,cuenta_comercial,razon_social,prefijo,domicilio,email_contacto,email_facturacion,indica_no_domiciliado,usuario_web,clave_web,usuario_registro) " & _
                "VALUES (@vEmpresa,@vCuenta_comercial,@vRazon_social,@vPrefijo,@vDomicilio,@vEmail_contacto,@vEmail_facturacion,@vIndica_no_domiciliado," & _
                "@vUsuario_web,@vClave_web,@vUsuario_registro)"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cCliente.empresa)
                .AddWithValue("vCuenta_comercial", cCliente.cuenta_comercial)
                .AddWithValue("vRazon_social", cCliente.razon_social)
                .AddWithValue("vPrefijo", cCliente.prefijo)
                .AddWithValue("vDomicilio", cCliente.domicilio)
                .AddWithValue("vEmail_contacto", cCliente.email_contacto)
                .AddWithValue("vEmail_facturacion", cCliente.email_facturacion)
                .AddWithValue("vIndica_no_domiciliado", cCliente.indica_no_domiciliado)
                '.AddWithValue("vUsuario_web", cCliente.usuario_web)
                .AddWithValue("vUsuario_web", cCliente.email_facturacion)
                .AddWithValue("vClave_web", cCliente.clave_web)
                .AddWithValue("vUsuario_registro", cCliente.usuario_registro)
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
                Return cCliente
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
    Private Shared Function ActualizarECliente(ByVal cCliente As entCliente) As entCliente
        MySql = "UPDATE COM.CLIENTES SET " & _
                "razon_social=@vRazon_social,prefijo=@vPrefijo,domicilio=@vDomicilio,email_contacto=@vEmail_contacto,email_facturacion=@vEmail_facturacion," & _
                "indica_no_domiciliado=@vIndica_no_domiciliado,usuario_web=@vUsuario_web,clave_web=@vClave_web,usuario_modifica=@vUsuario_modifica,fecha_modifica=GETDATE() " & _
                "WHERE empresa=@vEmpresa AND cuenta_comercial=@vCuenta_comercial"
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters
                .AddWithValue("vRazon_social", cCliente.razon_social)
                .AddWithValue("vPrefijo", cCliente.prefijo)
                .AddWithValue("vDomicilio", cCliente.domicilio)
                .AddWithValue("vEmail_contacto", cCliente.email_contacto)
                .AddWithValue("vEmail_facturacion", cCliente.email_facturacion)
                .AddWithValue("vIndica_no_domiciliado", cCliente.indica_no_domiciliado)
                '.AddWithValue("vUsuario_web", cCliente.usuario_web)
                .AddWithValue("vUsuario_web", cCliente.email_facturacion)
                .AddWithValue("vClave_web", cCliente.clave_web)
                .AddWithValue("vUsuario_modifica", cCliente.usuario_registro)
                .AddWithValue("vEmpresa", cCliente.empresa)
                .AddWithValue("vCuenta_comercial", cCliente.cuenta_comercial)
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
                Return cCliente
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
End Class
