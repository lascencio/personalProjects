Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalMigrar

    Public Shared Function EjecutarProcesos(ByRef MyProgressBar As ProgressBar, ByVal pEmpresa As String, ByVal pEjercicio As String, ByVal pMes As String, ByVal pTipoCambio As Decimal) As dsMigrarDetalles.MIGRAR_DETALLESDataTable

        Dim MyFile1 As String = "MOV" & pMes & pEjercicio
        Dim MyFile2 As String = "BOL" & pMes & pEjercicio

        Dim pFecha As Date = CDate("01/" & pMes & "/" & pEjercicio)

        Dim MyDT_Cabecera As New dsMigrarCabeceras.MIGRAR_CABECERASDataTable
        Dim MyDT_Detalle As New dsMigrarDetalles.MIGRAR_DETALLESDataTable

        pFecha = DateAdd(DateInterval.Month, 1, pFecha)
        pFecha = DateAdd(DateInterval.Day, -1, pFecha)

        Dim pFechaComprobante As String = pEjercicio.Substring(2, 2) & pMes & Strings.Right("00" & pFecha.Day.ToString, 2)

        Dim MySqlString As String = "TRUNCATE TABLE dbo.ASIENTO_DATOS_BOLETA "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_StarSoft)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            Try
                MySQLDbconnection.Open()

                ' Start a local transaction.
                MySQLTransaction = MySQLDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MySQLCommand.Connection = MySQLDbconnection
                MySQLCommand.Transaction = MySQLTransaction

                ' Execute the commands.
                MySQLCommand.ExecuteNonQuery()

                MySqlString = "TRUNCATE TABLE dbo.ASIENTO_DATOS_MOVIMIENTO "

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.ExecuteNonQuery()

                MySqlString = "INSERT INTO dbo.ASIENTO_DATOS_MOVIMIENTO (INUMBOL, CONCEPTO, MONTO, CODNOMBOL) " & _
                              "SELECT INUMBOL, CONCEPTO, MONTO, CODNOMBOL " & _
                              "FROM " & MyFile1

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.ExecuteNonQuery()

                MySqlString = "INSERT INTO dbo.ASIENTO_DATOS_BOLETA (INUMBOL,CODNOMBOL,CODTRAB,CODAFP,CCOSTO,TOTING,TOTEGR, " & _
                              "DEMPRESA,DEJERCICIO,DMES,DSUBDIA,DCOMPRO,DSECUE,DFECCOM,DNUMDOC,DDATE,DTIPCAM) " & _
                              "SELECT INUMBOL,CODNOMBOL,CODTRAB,CODAFP,CCOSTO,TOTING,TOTEGR," & _
                              "@vDEMPRESA,@vDEJERCICIO,@vDMES,@vDSUBDIA,@vDCOMPRO,@vDSECUE,@vDFECCOM,@vDNUMDOC,@vDDATE,@vDTIPCAM " & _
                              "FROM dbo." & MyFile2

                MySQLCommand.CommandType = CommandType.Text
                MySQLCommand.CommandText = MySqlString
                MySQLCommand.Parameters.Clear()

                MySQLCommand.Parameters.AddWithValue("vDEMPRESA", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vDEJERCICIO", pEjercicio)
                MySQLCommand.Parameters.AddWithValue("vDMES", pMes)
                MySQLCommand.Parameters.AddWithValue("vDSUBDIA", "35")
                MySQLCommand.Parameters.AddWithValue("vDCOMPRO", pMes & "0001")
                MySQLCommand.Parameters.AddWithValue("vDSECUE", "0000")
                MySQLCommand.Parameters.AddWithValue("vDFECCOM", pFechaComprobante)
                MySQLCommand.Parameters.AddWithValue("vDNUMDOC", pMes & "-" & pEjercicio)
                MySQLCommand.Parameters.AddWithValue("vDDATE", pEjercicio & "-" & pMes & "-" & Strings.Right("00" & pFecha.Day.ToString, 2))
                MySQLCommand.Parameters.AddWithValue("vDTIPCAM", pTipoCambio)

                MySQLCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MySQLTransaction.Commit()

                'Return True

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

        MySqlString = "SELECT csubdia,ccompro,cfeccom,ccodmon,csitua,ctipcam,cglosa,ctotal,ctipo,cflag,cdate,chora,cuser,cfeccam,corig,cform,ctipcom,cextor,cfeccom2,cfeccam2 " & _
                      "FROM MIGRAR_CABECERAS "

        Call ObtenerDataTableSQL(MySqlString, MyDT_Cabecera)

        MySqlString = "SELECT dsubdia,dcompro,dsecue,dfeccom,dcuenta,dcodane,dcencos,dcodmon,ddh,dimport,dtipdoc,dnumdoc,dfecdoc,dfecven,darea,dflag,ddate,dxglosa," & _
                      "dusimpor,dmnimpor,dcodarc,dfeccom2,dfecdoc2,dfecven2,dcodane2,dvanexo,dvanexo2,dtipcam,dcantid,drete,dporre,dtipdor,dnumdor,dfecdo2,dtiptas," & _
                      "dimptas,dimpbmn,dimpbus,dinacom,digvcom,dmedpag,dmoncom,dcolcom,dbascom,dtpconv,dflgcom,dtipaco,danecom " & _
                      "FROM MIGRAR_DETALLES "

        Call ObtenerDataTableSQL(MySqlString, MyDT_Detalle)

        Dim MyOleDBString As String = "DELETE FROM ccdbx" & pEjercicio.Substring(2, 2) & " WHERE dsubdia='35' AND dcompro=? "

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)
            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyOleDBCommand.Parameters.AddWithValue("DCOMPRO", pMes & "0001")

                ' Execute the commands.
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "DELETE FROM cccbx" & pEjercicio.Substring(2, 2) & " WHERE csubdia='35' AND ccompro=? "
                MyOleDBCommand.CommandText = MyOleDBString
                MyOleDBCommand.Parameters.Clear()
                MyOleDBCommand.Parameters.AddWithValue("CCOMPRO", pMes & "0001")
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "DELETE FROM ccdbx" & pEjercicio.Substring(2, 2) & " WHERE dsubdia='35' AND dcompro=? "
                MyOleDBCommand.CommandText = MyOleDBString
                MyOleDBCommand.Parameters.Clear()
                MyOleDBCommand.Parameters.AddWithValue("DCOMPRO", pMes & "0002")
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "DELETE FROM cccbx" & pEjercicio.Substring(2, 2) & " WHERE csubdia='35' AND ccompro=? "
                MyOleDBCommand.CommandText = MyOleDBString
                MyOleDBCommand.Parameters.Clear()
                MyOleDBCommand.Parameters.AddWithValue("CCOMPRO", pMes & "0002")
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
                                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                For NEle As Long = 1 To MyDT_Cabecera.Rows.Count
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("csubdia", MyDT_Cabecera(NEle - 1).csubdia)
                    MyOleDBCommand.Parameters.AddWithValue("ccompro", MyDT_Cabecera(NEle - 1).ccompro)
                    MyOleDBCommand.Parameters.AddWithValue("cfeccom", MyDT_Cabecera(NEle - 1).cfeccom)
                    MyOleDBCommand.Parameters.AddWithValue("ccodmon", MyDT_Cabecera(NEle - 1).ccodmon)
                    MyOleDBCommand.Parameters.AddWithValue("csitua", MyDT_Cabecera(NEle - 1).csitua)
                    MyOleDBCommand.Parameters.AddWithValue("ctipcam", MyDT_Cabecera(NEle - 1).ctipcam)
                    MyOleDBCommand.Parameters.AddWithValue("cglosa", MyDT_Cabecera(NEle - 1).cglosa)
                    MyOleDBCommand.Parameters.AddWithValue("ctotal", MyDT_Cabecera(NEle - 1).ctotal)
                    MyOleDBCommand.Parameters.AddWithValue("ctipo", MyDT_Cabecera(NEle - 1).ctipo)
                    MyOleDBCommand.Parameters.AddWithValue("cflag", MyDT_Cabecera(NEle - 1).cflag)
                    MyOleDBCommand.Parameters.AddWithValue("cfeccom2", MyDT_Cabecera(NEle - 1).cfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("chora", MyDT_Cabecera(NEle - 1).chora)
                    MyOleDBCommand.Parameters.AddWithValue("cuser", MyDT_Cabecera(NEle - 1).cuser)
                    MyOleDBCommand.Parameters.AddWithValue("cfeccam", MyDT_Cabecera(NEle - 1).cfeccam)
                    MyOleDBCommand.Parameters.AddWithValue("corig", MyDT_Cabecera(NEle - 1).corig)
                    MyOleDBCommand.Parameters.AddWithValue("cform", MyDT_Cabecera(NEle - 1).cform)
                    MyOleDBCommand.Parameters.AddWithValue("ctipcom", MyDT_Cabecera(NEle - 1).ctipcom)
                    MyOleDBCommand.Parameters.AddWithValue("cextor", MyDT_Cabecera(NEle - 1).cextor)
                    MyOleDBCommand.Parameters.AddWithValue("cfeccom2", MyDT_Cabecera(NEle - 1).cfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("cfeccam2", MyDT_Cabecera(NEle - 1).cfeccam2)
                    MyOleDBCommand.ExecuteNonQuery()
                Next

                MyProgressBar.Maximum = MyDT_Detalle.Rows.Count
                MyProgressBar.Value = 0
                MyProgressBar.Visible = True

                MyOleDBString = "INSERT INTO ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                MyProgressBar.Visible = True

                For NEle As Long = 1 To MyDT_Detalle.Rows.Count
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("dsubdia", MyDT_Detalle(NEle - 1).dsubdia)
                    MyOleDBCommand.Parameters.AddWithValue("dcompro", MyDT_Detalle(NEle - 1).dcompro)
                    MyOleDBCommand.Parameters.AddWithValue("dsecue", MyDT_Detalle(NEle - 1).dsecue)
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom", MyDT_Detalle(NEle - 1).dfeccom)
                    MyOleDBCommand.Parameters.AddWithValue("dcuenta", MyDT_Detalle(NEle - 1).dcuenta)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane", MyDT_Detalle(NEle - 1).dcodane)
                    MyOleDBCommand.Parameters.AddWithValue("dcencos", MyDT_Detalle(NEle - 1).dcencos)
                    MyOleDBCommand.Parameters.AddWithValue("dcodmon", MyDT_Detalle(NEle - 1).dcodmon)
                    MyOleDBCommand.Parameters.AddWithValue("ddh", MyDT_Detalle(NEle - 1).ddh)
                    MyOleDBCommand.Parameters.AddWithValue("dimport", MyDT_Detalle(NEle - 1).dimport)
                    MyOleDBCommand.Parameters.AddWithValue("dtipdoc", MyDT_Detalle(NEle - 1).DTIPDOC)
                    MyOleDBCommand.Parameters.AddWithValue("dnumdoc", MyDT_Detalle(NEle - 1).dnumdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc", MyDT_Detalle(NEle - 1).dfecdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven", MyDT_Detalle(NEle - 1).dfecven)
                    MyOleDBCommand.Parameters.AddWithValue("darea", MyDT_Detalle(NEle - 1).darea)
                    MyOleDBCommand.Parameters.AddWithValue("dflag", MyDT_Detalle(NEle - 1).dflag)
                    MyOleDBCommand.Parameters.AddWithValue("ddate", MyDT_Detalle(NEle - 1).ddate)
                    MyOleDBCommand.Parameters.AddWithValue("dxglosa", MyDT_Detalle(NEle - 1).dxglosa)
                    MyOleDBCommand.Parameters.AddWithValue("dusimpor", MyDT_Detalle(NEle - 1).dusimpor)
                    MyOleDBCommand.Parameters.AddWithValue("dmnimpor", MyDT_Detalle(NEle - 1).dmnimpor)
                    MyOleDBCommand.Parameters.AddWithValue("dcodarc", MyDT_Detalle(NEle - 1).dcodarc)
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom2", MyDT_Detalle(NEle - 1).dfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc2", MyDT_Detalle(NEle - 1).dfecdoc2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven2", MyDT_Detalle(NEle - 1).dfecven2)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane2", MyDT_Detalle(NEle - 1).dcodane2)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo", MyDT_Detalle(NEle - 1).DVANEXO)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo2", MyDT_Detalle(NEle - 1).DVANEXO2)
                    MyOleDBCommand.Parameters.AddWithValue("dtipcam", MyDT_Detalle(NEle - 1).dtipcam)
                    MyOleDBCommand.Parameters.AddWithValue("dcantid", MyDT_Detalle(NEle - 1).dcantid)
                    MyOleDBCommand.Parameters.AddWithValue("drete", MyDT_Detalle(NEle - 1).drete)
                    MyOleDBCommand.Parameters.AddWithValue("dporre", MyDT_Detalle(NEle - 1).dporre)
                    MyOleDBCommand.Parameters.AddWithValue("dtipdor", MyDT_Detalle(NEle - 1).dtipdor)
                    MyOleDBCommand.Parameters.AddWithValue("dnumdor", MyDT_Detalle(NEle - 1).dnumdor)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdo2", MyDT_Detalle(NEle - 1).dfecdo2)
                    MyOleDBCommand.Parameters.AddWithValue("dtiptas", MyDT_Detalle(NEle - 1).dtiptas)
                    MyOleDBCommand.Parameters.AddWithValue("dimptas", MyDT_Detalle(NEle - 1).dimptas)
                    MyOleDBCommand.Parameters.AddWithValue("dimpbmn", MyDT_Detalle(NEle - 1).dimpbmn)
                    MyOleDBCommand.Parameters.AddWithValue("dimpbus", MyDT_Detalle(NEle - 1).dimpbus)
                    MyOleDBCommand.Parameters.AddWithValue("dinacom", MyDT_Detalle(NEle - 1).dinacom)
                    MyOleDBCommand.Parameters.AddWithValue("digvcom", MyDT_Detalle(NEle - 1).digvcom)
                    MyOleDBCommand.Parameters.AddWithValue("dmedpag", MyDT_Detalle(NEle - 1).dmedpag)
                    MyOleDBCommand.Parameters.AddWithValue("dmoncom", MyDT_Detalle(NEle - 1).dmoncom)
                    MyOleDBCommand.Parameters.AddWithValue("dcolcom", MyDT_Detalle(NEle - 1).dcolcom)
                    MyOleDBCommand.Parameters.AddWithValue("dbascom", MyDT_Detalle(NEle - 1).dbascom)
                    MyOleDBCommand.Parameters.AddWithValue("dtpconv", MyDT_Detalle(NEle - 1).dtpconv)
                    MyOleDBCommand.Parameters.AddWithValue("dflgcom", MyDT_Detalle(NEle - 1).dflgcom)
                    MyOleDBCommand.Parameters.AddWithValue("dtipaco", MyDT_Detalle(NEle - 1).dtipaco)
                    MyOleDBCommand.Parameters.AddWithValue("danecom", MyDT_Detalle(NEle - 1).danecom)
                    MyOleDBCommand.ExecuteNonQuery()

                    MyProgressBar.Value += 1
                Next

                MyProgressBar.Visible = False

                ' Commit the transaction.
                MyOleDBTransaction.Commit()

                Return MyDT_Detalle

            Catch ex As Exception
                ' Try to rollback the transaction
                Try
                    MyOleDBTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try

        End Using

    End Function

    Private Sub ScriptsInsercion()
        '---------------------------
        '----- METODO 1 DE INSERCION 
        '---------------------------
        'MyOleDBString = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
        '                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        'MyOleDBCommand.CommandType = CommandType.Text
        'MyOleDBCommand.CommandText = MyOleDBString
        'MyOleDBCommand.Parameters.Clear()

        'MyOleDBCommand.Parameters.AddWithValue("csubdia", MyDT_Cabecera(0).csubdia)
        'MyOleDBCommand.Parameters.AddWithValue("ccompro", MyDT_Cabecera(0).ccompro)
        'MyOleDBCommand.Parameters.AddWithValue("cfeccom", MyDT_Cabecera(0).cfeccom)
        'MyOleDBCommand.Parameters.AddWithValue("ccodmon", MyDT_Cabecera(0).ccodmon)
        'MyOleDBCommand.Parameters.AddWithValue("csitua", MyDT_Cabecera(0).csitua)
        'MyOleDBCommand.Parameters.AddWithValue("ctipcam", MyDT_Cabecera(0).ctipcam)
        'MyOleDBCommand.Parameters.AddWithValue("cglosa", MyDT_Cabecera(0).cglosa)
        'MyOleDBCommand.Parameters.AddWithValue("ctotal", MyDT_Cabecera(0).ctotal)
        'MyOleDBCommand.Parameters.AddWithValue("ctipo", MyDT_Cabecera(0).ctipo)
        'MyOleDBCommand.Parameters.AddWithValue("cflag", MyDT_Cabecera(0).cflag)
        'MyOleDBCommand.Parameters.AddWithValue("cfeccom2", MyDT_Cabecera(0).cfeccom2)
        'MyOleDBCommand.Parameters.AddWithValue("chora", MyDT_Cabecera(0).chora)
        'MyOleDBCommand.Parameters.AddWithValue("cuser", MyDT_Cabecera(0).cuser)
        'MyOleDBCommand.Parameters.AddWithValue("cfeccam", MyDT_Cabecera(0).cfeccam)
        'MyOleDBCommand.Parameters.AddWithValue("corig", MyDT_Cabecera(0).corig)
        'MyOleDBCommand.Parameters.AddWithValue("cform", MyDT_Cabecera(0).cform)
        'MyOleDBCommand.Parameters.AddWithValue("ctipcom", MyDT_Cabecera(0).ctipcom)
        'MyOleDBCommand.Parameters.AddWithValue("cextor", MyDT_Cabecera(0).cextor)
        'MyOleDBCommand.Parameters.AddWithValue("cfeccom2", MyDT_Cabecera(0).cfeccom2)
        'MyOleDBCommand.Parameters.AddWithValue("cfeccam2", MyDT_Cabecera(0).cfeccam2)

        '---------------------------
        '----- METODO 2 DE INSERCION 
        '---------------------------
        'MyOleDBString = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
        '                "VALUES(@csubdia,@ccompro,@cfeccom,@ccodmon,@csitua,@ctipcam,@cglosa,@ctotal,@ctipo,@cflag," & _
        '                "@cdate,@chora,@cuser,@cfeccam,@corig,@cform,@ctipcom,@cextor,@cfeccom2,@cfeccam2)"

        'MyOleDBCommand.CommandType = CommandType.Text
        'MyOleDBCommand.CommandText = MyOleDBString
        'MyOleDBCommand.Parameters.Clear()

        'MyOleDBCommand.Parameters.Add("@csubdia", OleDbType.Char, 2).Value = MyDT_Cabecera(0).csubdia
        'MyOleDBCommand.Parameters.Add("@ccompro", OleDbType.Char, 6).Value = MyDT_Cabecera(0).ccompro
        'MyOleDBCommand.Parameters.Add("@cfeccom", OleDbType.Char, 6).Value = MyDT_Cabecera(0).cfeccom
        'MyOleDBCommand.Parameters.Add("@ccodmon", OleDbType.Char, 2).Value = MyDT_Cabecera(0).ccodmon
        'MyOleDBCommand.Parameters.Add("@csitua", OleDbType.Char, 1).Value = MyDT_Cabecera(0).csitua
        'MyOleDBCommand.Parameters.Add("@ctipcam", OleDbType.Numeric).Value = MyDT_Cabecera(0).ctipcam
        'MyOleDBCommand.Parameters.Add("@cglosa", OleDbType.Char, 40).Value = MyDT_Cabecera(0).cglosa
        'MyOleDBCommand.Parameters.Add("@ctotal", OleDbType.Numeric).Value = MyDT_Cabecera(0).ctotal
        'MyOleDBCommand.Parameters.Add("@ctipo", OleDbType.Char, 1).Value = MyDT_Cabecera(0).ctipo
        'MyOleDBCommand.Parameters.Add("@cflag", OleDbType.Char, 1).Value = MyDT_Cabecera(0).cflag
        'MyOleDBCommand.Parameters.Add("@cdate", OleDbType.DBDate).Value = MyDT_Cabecera(0).cfeccom2
        'MyOleDBCommand.Parameters.Add("@chora", OleDbType.Char, 6).Value = MyDT_Cabecera(0).chora
        'MyOleDBCommand.Parameters.Add("@cuser", OleDbType.Char, 5).Value = MyDT_Cabecera(0).cuser
        'MyOleDBCommand.Parameters.Add("@cfeccam", OleDbType.Char, 6).Value = MyDT_Cabecera(0).cfeccam
        'MyOleDBCommand.Parameters.Add("@corig", OleDbType.Char, 2).Value = MyDT_Cabecera(0).corig
        'MyOleDBCommand.Parameters.Add("@cform", OleDbType.Char, 1).Value = MyDT_Cabecera(0).cform
        'MyOleDBCommand.Parameters.Add("@ctipcom", OleDbType.Char, 2).Value = MyDT_Cabecera(0).ctipcom
        'MyOleDBCommand.Parameters.Add("@cextor", OleDbType.Char, 1).Value = MyDT_Cabecera(0).cextor
        'MyOleDBCommand.Parameters.Add("@cfeccom2", OleDbType.DBDate).Value = MyDT_Cabecera(0).cfeccom2
        'MyOleDBCommand.Parameters.Add("@cfeccam2", OleDbType.DBDate).Value = MyDT_Cabecera(0).cfeccam2

        '---------------------------
        '----- METODO 3 DE INSERCION 
        '---------------------------
        'MyOleDBString = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
        '                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        'MyOleDBCommand.CommandType = CommandType.Text
        'MyOleDBCommand.CommandText = MyOleDBString
        'MyOleDBCommand.Parameters.Clear()

        'Dim MyParameter_1 As New OleDbParameter("csubdia", OleDbType.Char, 2) : MyParameter_1.Value = MyDT_Cabecera(0).csubdia
        'Dim MyParameter_2 As New OleDbParameter("ccompro", OleDbType.Char, 6) : MyParameter_2.Value = MyDT_Cabecera(0).ccompro
        'Dim MyParameter_3 As New OleDbParameter("cfeccom", OleDbType.Char, 6) : MyParameter_3.Value = MyDT_Cabecera(0).cfeccom
        'Dim MyParameter_4 As New OleDbParameter("ccodmon", OleDbType.Char, 2) : MyParameter_4.Value = MyDT_Cabecera(0).ccodmon
        'Dim MyParameter_5 As New OleDbParameter("csitua", OleDbType.Char, 1) : MyParameter_5.Value = MyDT_Cabecera(0).csitua
        'Dim MyParameter_6 As New OleDbParameter("ctipcam", OleDbType.Numeric) : MyParameter_6.Value = MyDT_Cabecera(0).ctipcam
        'Dim MyParameter_7 As New OleDbParameter("cglosa", OleDbType.Char, 40) : MyParameter_7.Value = MyDT_Cabecera(0).cglosa
        'Dim MyParameter_8 As New OleDbParameter("ctotal", OleDbType.Numeric) : MyParameter_8.Value = MyDT_Cabecera(0).ctotal
        'Dim MyParameter_9 As New OleDbParameter("ctipo", OleDbType.Char, 1) : MyParameter_9.Value = MyDT_Cabecera(0).ctipo
        'Dim MyParameter_10 As New OleDbParameter("cflag", OleDbType.Char, 1) : MyParameter_10.Value = MyDT_Cabecera(0).cflag
        'Dim MyParameter_11 As New OleDbParameter("cdate", OleDbType.DBDate) : MyParameter_11.Value = MyDT_Cabecera(0).cfeccom2
        'Dim MyParameter_12 As New OleDbParameter("chora", OleDbType.Char, 6) : MyParameter_12.Value = MyDT_Cabecera(0).chora
        'Dim MyParameter_13 As New OleDbParameter("cuser", OleDbType.Char, 5) : MyParameter_13.Value = MyDT_Cabecera(0).cuser
        'Dim MyParameter_14 As New OleDbParameter("cfeccam", OleDbType.Char, 6) : MyParameter_14.Value = MyDT_Cabecera(0).cfeccam
        'Dim MyParameter_15 As New OleDbParameter("corig", OleDbType.Char, 2) : MyParameter_15.Value = MyDT_Cabecera(0).corig
        'Dim MyParameter_16 As New OleDbParameter("cform", OleDbType.Char, 1) : MyParameter_16.Value = MyDT_Cabecera(0).cform
        'Dim MyParameter_17 As New OleDbParameter("ctipcom", OleDbType.Char, 2) : MyParameter_17.Value = MyDT_Cabecera(0).ctipcom
        'Dim MyParameter_18 As New OleDbParameter("cextor", OleDbType.Char, 1) : MyParameter_18.Value = MyDT_Cabecera(0).cextor
        'Dim MyParameter_19 As New OleDbParameter("cfeccom2", OleDbType.DBDate) : MyParameter_19.Value = MyDT_Cabecera(0).cfeccom2
        'Dim MyParameter_20 As New OleDbParameter("cfeccam2", OleDbType.DBDate) : MyParameter_20.Value = MyDT_Cabecera(0).cfeccam2

        'MyOleDBCommand.Parameters.Add(MyParameter_1)
        'MyOleDBCommand.Parameters.Add(MyParameter_2)
        'MyOleDBCommand.Parameters.Add(MyParameter_3)
        'MyOleDBCommand.Parameters.Add(MyParameter_4)
        'MyOleDBCommand.Parameters.Add(MyParameter_5)
        'MyOleDBCommand.Parameters.Add(MyParameter_6)
        'MyOleDBCommand.Parameters.Add(MyParameter_7)
        'MyOleDBCommand.Parameters.Add(MyParameter_8)
        'MyOleDBCommand.Parameters.Add(MyParameter_9)
        'MyOleDBCommand.Parameters.Add(MyParameter_10)
        'MyOleDBCommand.Parameters.Add(MyParameter_11)
        'MyOleDBCommand.Parameters.Add(MyParameter_12)
        'MyOleDBCommand.Parameters.Add(MyParameter_13)
        'MyOleDBCommand.Parameters.Add(MyParameter_14)
        'MyOleDBCommand.Parameters.Add(MyParameter_15)
        'MyOleDBCommand.Parameters.Add(MyParameter_16)
        'MyOleDBCommand.Parameters.Add(MyParameter_17)
        'MyOleDBCommand.Parameters.Add(MyParameter_18)
        'MyOleDBCommand.Parameters.Add(MyParameter_19)
        'MyOleDBCommand.Parameters.Add(MyParameter_20)
    End Sub

End Class


