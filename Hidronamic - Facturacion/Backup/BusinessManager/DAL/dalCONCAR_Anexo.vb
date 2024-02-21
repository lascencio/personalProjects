Imports System.Data.SqlClient

Public Class dalCONCAR_Anexo

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pAnexo As String, ByVal pAnexoTipo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXOS_DETALLE WHERE avanexo=@vAnexo_Tipo AND acodane=@vAnexo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo_Tipo", pAnexoTipo)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteBeneficiario(ByVal pAnexo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXOS_DETALLE WHERE avanexo IN ('T','V') AND acodane=@vAnexo " 
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteProveedor(ByVal pAnexo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXOS_DETALLE WHERE avanexo IN ('P','H') AND acodane=@vAnexo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteCliente(ByVal pAnexo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXOS_DETALLE WHERE avanexo='C' AND acodane=@vAnexo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteProyecto(ByVal pAnexo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXO_PROYECTO WHERE acodane=@vAnexo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function ExisteCuentaCorriente(ByVal pAnexo As String) As Boolean
        If Not String.IsNullOrEmpty(pAnexo) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane=@vAnexo "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vAnexo", pAnexo)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Public Shared Function Obtener(ByVal pAnexo As String, ByVal pAnexoTipo As String) As entCONCAR_Anexo
        If Existe(pAnexo, pAnexoTipo) Then
            CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXOS_DETALLE WHERE avanexo='" & pAnexoTipo & "' AND acodane='" & pAnexo & "'"
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerBeneficiario(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteBeneficiario(pAnexo) Then
            CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXOS_DETALLE WHERE avanexo IN ('T','V') AND acodane='" & pAnexo & "' " & _
                        "ORDER BY avanexo "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerProveedor(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteProveedor(pAnexo) Then
            CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXOS_DETALLE WHERE avanexo IN ('P','H') AND acodane='" & pAnexo & "' " & _
                        "ORDER BY avanexo "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerCliente(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteCliente(pAnexo) Then
            CadenaSQL = "SELECT AVANEXO, ACODANE, ADESANE, ARUC, ACODMON, AESTADO, ADATE, AHORA, APATERNO, AMATERNO, " & _
                        "ANOMBRE, ATIPTRA, ADOCIDE, ANUMIDE, ATIPPRO, ANACIO, AESSAL, ADOMIC, ASITUA, ATICONV, AMEMO " & _
                        "FROM CON.ANEXOS_DETALLE " & _
                        "WHERE AVANEXO='C' AND ACODANE='" & pAnexo & "' "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerNombreCliente(ByVal pAnexo As String) As String
        CadenaSQL = "SELECT ADESANE FROM CON.ANEXOS_DETALLE WHERE AVANEXO='C' AND ACODANE='" & pAnexo & "' "
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(CadenaSQL, MySQLDbconnection)
            MySQLDbconnection.Open()

            Return MySQLCommand.ExecuteScalar
        End Using
    End Function

    Public Shared Function ObtenerProyecto(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteProyecto(pAnexo) Then
            CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXO_PROYECTO WHERE acodane='" & pAnexo & "' "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerCuentaCorriente(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteCuentaCorriente(pAnexo) Then
            CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane='" & pAnexo & "' "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerAnexo(ByVal pAnexo As String, ByVal pAnexoTipo As String) As entCONCAR_Anexo
        CadenaSQL = "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM CON.ANEXOS_DETALLE WHERE avanexo='" & pAnexoTipo & "' AND acodane='" & pAnexo & "' " & _
                        "UNION ALL " & _
                        "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora, SPACE(1) AS asitua, 0 AS aticonv " & _
                        "FROM AUX.ANEXOS_X_MIGRAR WHERE avanexo='" & pAnexoTipo & "' AND acodane='" & pAnexo & "' AND indica_proceso='NO' " & _
                        "ORDER BY avanexo "
        Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Repository)
        Return New entCONCAR_Anexo
    End Function

    Public Shared Function ObtenerAnexoRSCONCAR(ByVal pAnexo As String) As entCONCAR_Anexo
        If ExisteCliente(pAnexo) Then
            CadenaSQL = "SELECT AVANEXO, ACODANE, ADESANE, ARUC, ACODMON, AESTADO, ADATE, AHORA, APATERNO, AMATERNO, " & _
                        "ANOMBRE, ATIPTRA, ADOCIDE, ANUMIDE, ATIPPRO, ANACIO, AESSAL, ADOMIC, ASITUA, ATICONV, AMEMO " & _
                        "FROM CT0004ANEX " & _
                        "WHERE AVANEXO='C' AND ACODANE='" & pAnexo & "' "
            Return Obtener(New entCONCAR_Anexo, CadenaSQL, myConnectionStringSQL_Concar)
        Else
            Return New entCONCAR_Anexo
        End If
    End Function

    Public Shared Function ObtenerAnexosRSCONCAR(ByVal pAvanexo As String) As dsCONCAR_Anexos.ANEXO_DETALLEDataTable
        Dim MySqlString As String
        MySqlString = "SELECT AVANEXO, ACODANE, ADESANE, ARUC, ACODMON, AESTADO, ADATE, AHORA, APATERNO, AMATERNO, " & _
                      "ANOMBRE, ATIPTRA, ADOCIDE, ANUMIDE, ATIPPRO, ANACIO, AESSAL, ADOMIC, ASITUA, ATICONV, AMEMO " & _
                      "FROM CT0004ANEX " & _
                      "WHERE AVANEXO=@vAvanexo "
        Dim MyDT As New dsCONCAR_Anexos.ANEXO_DETALLEDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Concar)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vAvanexo", pAvanexo)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerDomicilioSOFINET(ByVal pNumeroDocumento As String) As String

        Dim MySql As String = "SELECT ISNULL(direccion,'SIN DATOS') AS DOMICILIO FROM CLIENTES_SOFINETContable " & _
                              "WHERE IdEmpresa='1' AND RUC='" & pNumeroDocumento & "' "

        Dim MyDomicilio As String

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            MyDomicilio = MySQLCommand.ExecuteScalar

            Return MyDomicilio

        End Using

    End Function

    Private Shared Function Obtener(ByVal cAnexo As entCONCAR_Anexo, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entCONCAR_Anexo
        Dim MyDT As New dsCONCAR_Anexos.ANEXO_DETALLEDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT, myConnectionString)

        If MyDT.Count > 0 Then
            With cAnexo
                .avanexo = MyDT(0).AVANEXO
                .acodane = MyDT(0).ACODANE
                .adesane = MyDT(0).ADESANE
                .aruc = MyDT(0).ARUC
                .acodmon = MyDT(0).ACODMON
                .aestado = MyDT(0).AESTADO
                If Not MyDT(0).IsNull("adate") Then .adate = MyDT(0).ADATE
                .ahora = MyDT(0).AHORA
                .apaterno = MyDT(0).APATERNO
                .amaterno = MyDT(0).AMATERNO
                .anombre = MyDT(0).ANOMBRE
                .atiptra = MyDT(0).ATIPTRA
                .adocide = MyDT(0).ADOCIDE
                .anumide = MyDT(0).ANUMIDE
                .atippro = MyDT(0).ATIPPRO
                .anacio = MyDT(0).ANACIO
                .aessal = MyDT(0).AESSAL
                .adomic = MyDT(0).ADOMIC
                .asitua = MyDT(0).ASITUA
                .aticonv = MyDT(0).ATICONV
                .amemo = MyDT(0).AMEMO
            End With
        End If
        Return cAnexo
    End Function

    Public Shared Function Grabar(ByVal cAnexo As entCONCAR_Anexo) As entCONCAR_Anexo
        Dim MySqlString As String = "SELECT COUNT(*) FROM CON.ANEXOS_DETALLE WHERE avanexo=@vAvnexo AND acodane=@vAcodane "
        Dim MyCount As Integer
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vAvnexo", cAnexo.avanexo)
            MySQLCommand.Parameters.AddWithValue("vAcodane", cAnexo.acodane)
            MySQLDbconnection.Open()
            MyCount = CInt(MySQLCommand.ExecuteScalar)
        End Using
        If MyCount = 0 Then
            Return Insertar(cAnexo)
        Else
            Return Actualizar(cAnexo)
        End If
    End Function

    Public Shared Sub ActualizarDomicilio(ByVal cRuc As String, ByVal cDomicilio As String)

        Dim MySqlString As String = "UPDATE CT0004ANEX " & _
                                    "SET amemo=@vAmemo " & _
                                    "WHERE avanexo='C' AND aruc=@vRuc "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Concar)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAmemo", cDomicilio)
                .AddWithValue("vRuc", cRuc)
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

                MySQLTransaction.Commit()

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
    End Sub

    Private Shared Function Insertar(ByVal cAnexo As entCONCAR_Anexo) As entCONCAR_Anexo

        Dim MySqlString As String = "INSERT INTO CT0004ANEX " & _
                                    "(avanexo,acodane,adesane,aruc,acodmon,aestado,adate,ahora,apaterno,amaterno,anombre,atiptra,adocide,anumide," & _
                                    "atippro,anacio,aessal,adomic,asitua,aticonv,amemo) " & _
                                    "VALUES (" & _
                                    "@vAvanexo,@vAcodane,@vAdesane,@vAruc,@vAcodmon,@vAestado,@vAdate,@vAhora,@vApaterno,@vAmaterno,@vAnombre,@vAtiptra,@vAdocide,@vAnumide," & _
                                    "@vAtippro,@vAnacio,@vAessal,@vAdomic,@vAsitua,@vAticonv,@vAmemo) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Concar)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAvanexo", cAnexo.avanexo)
                .AddWithValue("vAcodane", cAnexo.acodane)
                .AddWithValue("vAdesane", cAnexo.adesane.Substring(0, IIf(cAnexo.adesane.Trim.Length > 40, 40, cAnexo.adesane.Length)))
                .AddWithValue("vAruc", cAnexo.aruc)
                .AddWithValue("vAcodmon", cAnexo.acodmon)
                .AddWithValue("vAestado", cAnexo.aestado)
                .AddWithValue("vAdate", cAnexo.adate)
                .AddWithValue("vAhora", cAnexo.ahora)
                .AddWithValue("vApaterno", cAnexo.apaterno)
                .AddWithValue("vAmaterno", cAnexo.amaterno)
                .AddWithValue("vAnombre", cAnexo.anombre)
                .AddWithValue("vAtiptra", cAnexo.atiptra)
                .AddWithValue("vAdocide", cAnexo.adocide)
                .AddWithValue("vAnumide", cAnexo.anumide)
                .AddWithValue("vAtippro", cAnexo.atippro)
                .AddWithValue("vAnacio", cAnexo.anacio)
                .AddWithValue("vAessal", cAnexo.aessal)
                .AddWithValue("vAdomic", cAnexo.adomic)
                .AddWithValue("vAsitua", cAnexo.asitua)
                .AddWithValue("vAticonv", cAnexo.aticonv)
                .AddWithValue("vAmemo", cAnexo.amemo)
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

                MySQLTransaction.Commit()

                Return cAnexo

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

    Private Shared Function Actualizar(ByVal cAnexo As entCONCAR_Anexo) As entCONCAR_Anexo

        Dim MySqlString As String = "UPDATE CT0004ANEX " & _
                                    "SET adesane=@vAdesane, adocide=@vAdocide, amemo=@vAmemo " & _
                                    "WHERE avanexo=@vAvanexo AND acodane=@vAcodane "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Concar)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vAdesane", cAnexo.adesane.Substring(0, IIf(cAnexo.adesane.Trim.Length > 40, 40, cAnexo.adesane.Length)))
                .AddWithValue("vAdocide", cAnexo.adocide)
                .AddWithValue("vAmemo", cAnexo.amemo)
                .AddWithValue("vAvanexo", cAnexo.avanexo)
                .AddWithValue("vAcodane", cAnexo.acodane)
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

                MySQLTransaction.Commit()

                Return cAnexo

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

    Public Shared Function BuscarAnexoCodigo(ByVal pAnexo As String, ByVal pAnexoTipo As String) As DataTable
        Dim MySqlString As String
        If pAnexoTipo = "TODOS" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' "
        ElseIf pAnexoTipo = "BENEFICIARIO" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' AND avanexo IN ('T','V') "
        ElseIf pAnexoTipo = "PROVEEDOR" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' AND avanexo IN ('P','H') "
        ElseIf pAnexoTipo = "CLIENTE" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' AND avanexo IN ('C') "
        ElseIf pAnexoTipo = "PROYECTO" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_PROYECTO WHERE acodane LIKE @vNro_Documento+'%' "
        ElseIf pAnexoTipo = "CUENTA CORRIENTE" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' "
        Else
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE acodane LIKE @vNro_Documento+'%' AND avanexo='" & pAnexoTipo & "' "
        End If
        MySqlString = MySqlString & "ORDER BY acodane "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vNro_Documento", pAnexo.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarAnexoNombre(ByVal pAnexoDescripcion As String, ByVal pAnexoTipo As String) As DataTable
        Dim MySqlString As String
        If pAnexoTipo = "TODOS" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' "
        ElseIf pAnexoTipo = "BENEFICIARIO" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' AND avanexo IN ('T','V') "
        ElseIf pAnexoTipo = "PROVEEDOR" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' AND avanexo IN ('P','H') "
        ElseIf pAnexoTipo = "CLIENTE" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' AND avanexo IN ('C') "
        ElseIf pAnexoTipo = "PROYECTO" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_PROYECTO WHERE adesane LIKE '%'+@vRazon_Social+'%' "
        ElseIf pAnexoTipo = "CUENTA CORRIENTE" Then
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' "
        Else
            MySqlString = "SELECT acodane, adesane, avanexo, arefane, aestado FROM CON.ANEXO_CUENTA_CORRIENTE WHERE adesane LIKE '%'+@vRazon_Social+'%' AND avanexo='" & pAnexoTipo & "' "
        End If
        MySqlString = MySqlString & "ORDER BY adesane "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vRazon_Social", pAnexoDescripcion.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarElementoCodigo(ByVal pElementoCodigo As String, ByVal pTablaTipo As String) As DataTable
        Dim MySqlString As String = "SELECT tcod, tclave, tdescri, tdate, thora FROM CON.ANEXOS WHERE tcod=@vTabla_tipo AND tclave LIKE @vElemento_codigo+'%' " & _
                                    "ORDER BY tclave "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vTabla_tipo", pTablaTipo.Trim)
            MySQLCommand.Parameters.AddWithValue("vElemento_codigo", pElementoCodigo.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarElementoNombre(ByVal pElementoDescripcion As String, ByVal pTablaTipo As String) As DataTable
        Dim MySqlString As String = "SELECT tcod, tclave, tdescri, tdate, thora FROM CON.ANEXOS WHERE tcod=@vTabla_tipo AND tdescri LIKE '%'+@vElemento_descripcion+'%' " & _
                                    "ORDER BY tdescri "
        Dim MyDT As New DataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vTabla_tipo", pTablaTipo.Trim)
            MySQLCommand.Parameters.AddWithValue("vElemento_descripcion", pElementoDescripcion.Trim)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function ObtenerElemento(ByVal pElemento As String, ByVal pTipoTabla As String) As entCONCAR_Tabla
        Dim MyDT As New dsCONCAR_Anexos.ANEXOSDataTable
        Dim cElemento As New entCONCAR_Tabla
        CadenaSQL = "SELECT tcod, tclave, tdescri, tdate, thora FROM CON.ANEXOS WHERE tcod='" & pTipoTabla & "' AND tclave='" & pElemento & "' "

        Call ObtenerDataTableSQL(CadenaSQL, MyDT)

        If MyDT.Count > 0 Then
            With cElemento
                .tcod = MyDT(0).tcod
                .tclave = MyDT(0).tclave
                .tdescri = MyDT(0).tdescri
                .tdate = MyDT(0).tdate
                .thora = MyDT(0).thora
            End With
        End If
        Return cElemento
    End Function

    Public Shared Function AnexosMigrar() As dsCONCAR_Anexos.ANEXOS_DETALLEDataTable
        Dim MySqlString As String = "SELECT * FROM CON.ANEXOS_X_MIGRAR "
        Dim MyDT As New dsCONCAR_Anexos.ANEXOS_DETALLEDataTable
        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function


End Class
