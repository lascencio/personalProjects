Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalLiquidarCaja

    Public Shared Function BuscarRegistros(ByVal pEjercicio As String) As dsAsientoContable.DETALLEDataTable
        Dim MyDT As New dsAsientoContable.DETALLEDataTable

        'Dim MyOleDBString As String = "SELECT dsubdia, dcompro, dsecue, dfeccom, dcuenta, dcodane, dcencos, dcodmon, ddh, dimport, dtipdoc, dnumdoc, dfecdoc, dfecven, darea, dflag, ddate, dxglosa, " & _
        '                            "dusimpor, dmnimpor, dcodarc, dfeccom2, dfecdoc2, dfecven2, dcodane2, dvanexo, dvanexo2, dtipcam, dcantid, drete, dporre, dtipdor, dnumdor, dfecdo2, dtiptas, " & _
        '                            "dimptas, dimpbmn, dimpbus, dinacom, digvcom, dmedpag, dmoncom, dcolcom, dbascom, dtpconv, dflgcom, dtipaco, danecom " & _
        '                            "FROM ccdbx" & pPeriodo.Substring(2, 2) & " " & _
        '                            "WHERE dsubdia='02' AND ddh='H' AND dbascom=0 "

        Dim MyOleDBString As String = "SELECT * " & _
                                    "FROM ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                    "WHERE dsubdia='02' AND ddh='H' AND dbascom=0 "

        Call ObtenerDataTableVFP(MyOleDBString, MyDT)

        Return MyDT

    End Function

    Public Shared Function Existe(ByVal pEjercicio As String, ByVal pSubDiario As String, ByVal pComprobante As String) As Boolean
        Dim MyCount As Integer
        Dim MyOleDBString As String = "SELECT COUNT(*) FROM cccbx" & pEjercicio.Substring(2, 2) & " " & _
                                    "WHERE csubdia=? AND ccompro=? "

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)
            MyOleDBCommand.Parameters.AddWithValue("csubdia", pSubDiario)
            MyOleDBCommand.Parameters.AddWithValue("ccompro", pComprobante)
            MyOleDBDbconnection.Open()
            MyCount = CInt(MyOleDBCommand.ExecuteScalar)
        End Using

        Return IIf(MyCount = 0, False, True)

    End Function

    Public Shared Function Insertar(ByRef MyProgressBar As ProgressBar, ByVal pEjercicio As String, ByVal pMes As String, ByVal pFecha As Date, ByVal pTipoCambio As Decimal, ByVal pSubDiario As String, ByVal pComprobante As String, ByVal pGlosa As String, ByVal pTotalMN As Decimal, ByVal pTotalME As Decimal, ByVal pOrigenFondos As String, ByVal pReemplazar As Boolean, ByVal MyDT_Detalle As dsAsientoContable.DETALLEDataTable) As Boolean

        If pReemplazar = True Then Call Eliminar(pEjercicio, pSubDiario, pComprobante)

        Dim pFechaComprobante As String = pEjercicio.Substring(2, 2) & pMes & Strings.Right("00" & pFecha.Day.ToString, 2)

        Dim MyOleDBString As String = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
                                      "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)
            Dim NEle As Long

            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyOleDBCommand.Parameters.AddWithValue("csubdia", pSubDiario)
                MyOleDBCommand.Parameters.AddWithValue("ccompro", pComprobante)
                MyOleDBCommand.Parameters.AddWithValue("cfeccom", pFechaComprobante)
                MyOleDBCommand.Parameters.AddWithValue("ccodmon", "MN")
                MyOleDBCommand.Parameters.AddWithValue("csitua", "F")
                MyOleDBCommand.Parameters.AddWithValue("ctipcam", pTipoCambio)
                MyOleDBCommand.Parameters.AddWithValue("cglosa", pGlosa)
                MyOleDBCommand.Parameters.AddWithValue("ctotal", pTotalMN)
                MyOleDBCommand.Parameters.AddWithValue("ctipo", "V")
                MyOleDBCommand.Parameters.AddWithValue("cflag", "S")
                MyOleDBCommand.Parameters.AddWithValue("cdate", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("chora", "00:00:")
                MyOleDBCommand.Parameters.AddWithValue("cuser", "SIST")
                MyOleDBCommand.Parameters.AddWithValue("cfeccam", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("corig", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cform", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("ctipcom", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cextor", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cfeccom2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("cfeccam2", pFecha)

                ' Execute the commands.
                MyOleDBCommand.ExecuteNonQuery()

                MyProgressBar.Visible = True

                MyProgressBar.Maximum = MyDT_Detalle.Rows.Count
                MyProgressBar.Value = 0
                MyProgressBar.Step = 1

                MyOleDBString = "INSERT INTO ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString


                For NEle = 1 To MyDT_Detalle.Rows.Count
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("dsubdia", pSubDiario)
                    MyOleDBCommand.Parameters.AddWithValue("dcompro", pComprobante)
                    MyOleDBCommand.Parameters.AddWithValue("dsecue", Strings.Right("0000" & NEle.ToString.Trim, 4))
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom", pFechaComprobante)
                    MyOleDBCommand.Parameters.AddWithValue("dcuenta", MyDT_Detalle(NEle - 1).dcuenta)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane", MyDT_Detalle(NEle - 1).dcodane)
                    MyOleDBCommand.Parameters.AddWithValue("dcencos", MyDT_Detalle(NEle - 1).dcencos)
                    MyOleDBCommand.Parameters.AddWithValue("dcodmon", MyDT_Detalle(NEle - 1).dcodmon)
                    MyOleDBCommand.Parameters.AddWithValue("ddh", "D")
                    MyOleDBCommand.Parameters.AddWithValue("dimport", MyDT_Detalle(NEle - 1).dimport)
                    MyOleDBCommand.Parameters.AddWithValue("dtipdoc", MyDT_Detalle(NEle - 1).dtipdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dnumdoc", MyDT_Detalle(NEle - 1).dnumdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc", MyDT_Detalle(NEle - 1).dfecdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven", MyDT_Detalle(NEle - 1).dfecven)
                    MyOleDBCommand.Parameters.AddWithValue("darea", MyDT_Detalle(NEle - 1).darea)
                    MyOleDBCommand.Parameters.AddWithValue("dflag", MyDT_Detalle(NEle - 1).dflag)
                    MyOleDBCommand.Parameters.AddWithValue("ddate", MyDT_Detalle(NEle - 1).ddate)
                    MyOleDBCommand.Parameters.AddWithValue("dxglosa", MyDT_Detalle(NEle - 1).dxglosa)
                    MyOleDBCommand.Parameters.AddWithValue("dusimpor", Math.Round(MyDT_Detalle(NEle - 1).dmnimpor / pTipoCambio, 2))
                    MyOleDBCommand.Parameters.AddWithValue("dmnimpor", MyDT_Detalle(NEle - 1).dmnimpor)
                    MyOleDBCommand.Parameters.AddWithValue("dcodarc", MyDT_Detalle(NEle - 1).dcodarc)
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom2", MyDT_Detalle(NEle - 1).dfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc2", MyDT_Detalle(NEle - 1).dfecdoc2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven2", MyDT_Detalle(NEle - 1).dfecven2)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane2", MyDT_Detalle(NEle - 1).dcodane2)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo", MyDT_Detalle(NEle - 1).dvanexo)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo2", MyDT_Detalle(NEle - 1).dvanexo2)
                    MyOleDBCommand.Parameters.AddWithValue("dtipcam", pTipoCambio)
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
                    MyOleDBCommand.Parameters.AddWithValue("dbascom", 0)
                    MyOleDBCommand.Parameters.AddWithValue("dtpconv", MyDT_Detalle(NEle - 1).dtpconv)
                    MyOleDBCommand.Parameters.AddWithValue("dflgcom", MyDT_Detalle(NEle - 1).dflgcom)
                    MyOleDBCommand.Parameters.AddWithValue("dtipaco", MyDT_Detalle(NEle - 1).dtipaco)
                    MyOleDBCommand.Parameters.AddWithValue("danecom", MyDT_Detalle(NEle - 1).danecom)
                    MyOleDBCommand.ExecuteNonQuery()

                Next

                MyOleDBCommand.Parameters.Clear()
                MyOleDBCommand.Parameters.AddWithValue("dsubdia", pSubDiario)
                MyOleDBCommand.Parameters.AddWithValue("dcompro", pComprobante)
                MyOleDBCommand.Parameters.AddWithValue("dsecue", Strings.Right("0000" & NEle.ToString.Trim, 4))
                MyOleDBCommand.Parameters.AddWithValue("dfeccom", pFechaComprobante)
                MyOleDBCommand.Parameters.AddWithValue("dcuenta", pOrigenFondos)
                MyOleDBCommand.Parameters.AddWithValue("dcodane", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dcencos", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dcodmon", MyDT_Detalle(0).dcodmon)
                MyOleDBCommand.Parameters.AddWithValue("ddh", "H")
                MyOleDBCommand.Parameters.AddWithValue("dimport", pTotalMN)
                MyOleDBCommand.Parameters.AddWithValue("dtipdoc", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dnumdoc", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dfecdoc", pFechaComprobante)
                MyOleDBCommand.Parameters.AddWithValue("dfecven", pFechaComprobante)
                MyOleDBCommand.Parameters.AddWithValue("darea", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dflag", MyDT_Detalle(0).dflag)
                MyOleDBCommand.Parameters.AddWithValue("ddate", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("dxglosa", pGlosa)
                MyOleDBCommand.Parameters.AddWithValue("dusimpor", pTotalME)
                MyOleDBCommand.Parameters.AddWithValue("dmnimpor", pTotalMN)
                MyOleDBCommand.Parameters.AddWithValue("dcodarc", MyDT_Detalle(0).dcodarc)
                MyOleDBCommand.Parameters.AddWithValue("dfeccom2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("dfecdoc2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("dfecven2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("dcodane2", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dvanexo", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dvanexo2", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("dtipcam", pTipoCambio)
                MyOleDBCommand.Parameters.AddWithValue("dcantid", MyDT_Detalle(0).dcantid)
                MyOleDBCommand.Parameters.AddWithValue("drete", MyDT_Detalle(0).drete)
                MyOleDBCommand.Parameters.AddWithValue("dporre", MyDT_Detalle(0).dporre)
                MyOleDBCommand.Parameters.AddWithValue("dtipdor", MyDT_Detalle(0).dtipdor)
                MyOleDBCommand.Parameters.AddWithValue("dnumdor", MyDT_Detalle(0).dnumdor)
                MyOleDBCommand.Parameters.AddWithValue("dfecdo2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("dtiptas", MyDT_Detalle(0).dtiptas)
                MyOleDBCommand.Parameters.AddWithValue("dimptas", MyDT_Detalle(0).dimptas)
                MyOleDBCommand.Parameters.AddWithValue("dimpbmn", MyDT_Detalle(0).dimpbmn)
                MyOleDBCommand.Parameters.AddWithValue("dimpbus", MyDT_Detalle(0).dimpbus)
                MyOleDBCommand.Parameters.AddWithValue("dinacom", MyDT_Detalle(0).dinacom)
                MyOleDBCommand.Parameters.AddWithValue("digvcom", MyDT_Detalle(0).digvcom)
                MyOleDBCommand.Parameters.AddWithValue("dmedpag", MyDT_Detalle(0).dmedpag)
                MyOleDBCommand.Parameters.AddWithValue("dmoncom", MyDT_Detalle(0).dmoncom)
                MyOleDBCommand.Parameters.AddWithValue("dcolcom", MyDT_Detalle(0).dcolcom)
                MyOleDBCommand.Parameters.AddWithValue("dbascom", 0)
                MyOleDBCommand.Parameters.AddWithValue("dtpconv", MyDT_Detalle(0).dtpconv)
                MyOleDBCommand.Parameters.AddWithValue("dflgcom", MyDT_Detalle(0).dflgcom)
                MyOleDBCommand.Parameters.AddWithValue("dtipaco", MyDT_Detalle(0).dtipaco)
                MyOleDBCommand.Parameters.AddWithValue("danecom", MyDT_Detalle(0).danecom)
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "UPDATE ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                "SET dbascom=1 " & _
                                "WHERE dsubdia=? AND dcompro=? AND dsecue=? "

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                For NEle = 1 To MyDT_Detalle.Rows.Count
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("dsubdia", MyDT_Detalle(NEle - 1).dsubdia)
                    MyOleDBCommand.Parameters.AddWithValue("dcompro", MyDT_Detalle(NEle - 1).dcompro)
                    MyOleDBCommand.Parameters.AddWithValue("dsecue", MyDT_Detalle(NEle - 1).dsecue)
                    MyOleDBCommand.ExecuteNonQuery()
                    MyProgressBar.Value += 1
                    MyProgressBar.Refresh()

                Next

                ' Commit the transaction.
                MyOleDBTransaction.Commit()

                MyProgressBar.Visible = False

                Return True

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

    Public Shared Function InsertarCajaChica(ByRef MyProgressBar As ProgressBar, ByVal pEjercicio As String, ByVal pMes As String, ByVal pFecha As Date, ByVal pComprobanteCaja As String, ByVal pComprobanteRendicion As String, ByVal pComprobanteHonorarios As String, ByVal pTipoCambio As Decimal, ByVal pGlosa As String, ByVal pTotalCaja As Decimal, ByVal pTotalRendicion As Decimal, ByVal pTotalHonorarios As Decimal, ByVal MyDT_Detalle As dsAsientoContable.DETALLEDataTable) As Boolean

        Dim MyAnexos As New dsCONCAR_Anexos.ANEXOS_DETALLEDataTable
        Dim MyComprobante As String
        Dim MyGlosa As String

        MyAnexos = dalCONCAR_Anexo.AnexosMigrar()

        Dim pFechaComprobante As String = pEjercicio.Substring(2, 2) & pMes & Strings.Right("00" & pFecha.Day.ToString, 2)

        Dim MyOleDBString As String = "INSERT INTO cccbx" & pEjercicio.Substring(2, 2) & " " & _
                                      "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)
            Dim NEle As Long

            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyOleDBCommand.Parameters.AddWithValue("csubdia", "01")
                MyOleDBCommand.Parameters.AddWithValue("ccompro", pMes & pComprobanteCaja)
                MyOleDBCommand.Parameters.AddWithValue("cfeccom", pFechaComprobante)
                MyOleDBCommand.Parameters.AddWithValue("ccodmon", "MN")
                MyOleDBCommand.Parameters.AddWithValue("csitua", "F")
                MyOleDBCommand.Parameters.AddWithValue("ctipcam", pTipoCambio)
                MyOleDBCommand.Parameters.AddWithValue("cglosa", pGlosa)
                MyOleDBCommand.Parameters.AddWithValue("ctotal", pTotalCaja)
                MyOleDBCommand.Parameters.AddWithValue("ctipo", "V")
                MyOleDBCommand.Parameters.AddWithValue("cflag", "S")
                MyOleDBCommand.Parameters.AddWithValue("cdate", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("chora", "00:00:")
                MyOleDBCommand.Parameters.AddWithValue("cuser", "SIST")
                MyOleDBCommand.Parameters.AddWithValue("cfeccam", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("corig", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cform", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("ctipcom", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cextor", Valor_Nulo)
                MyOleDBCommand.Parameters.AddWithValue("cfeccom2", pFecha)
                MyOleDBCommand.Parameters.AddWithValue("cfeccam2", pFecha)

                ' Execute the commands.
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                For NEle = 0 To MyDT_Detalle.Rows.Count - 1
                    If MyDT_Detalle(NEle).dsubdia = "02" Then
                        MyComprobante = MyDT_Detalle(NEle).dcompro
                        MyGlosa = MyDT_Detalle(NEle).dxglosa
                        pTotalRendicion = 0
                        Do While MyDT_Detalle(NEle).dcompro = MyComprobante
                            If MyDT_Detalle(NEle).ddh = "H" Then pTotalRendicion = pTotalRendicion + MyDT_Detalle(NEle).dmnimpor
                            NEle = NEle + 1
                            If NEle > MyDT_Detalle.Rows.Count - 1 Then Exit Do
                        Loop
                        MyOleDBCommand.Parameters.Clear()
                        MyOleDBCommand.Parameters.AddWithValue("csubdia", "02")
                        MyOleDBCommand.Parameters.AddWithValue("ccompro", MyComprobante)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom", pFechaComprobante)
                        MyOleDBCommand.Parameters.AddWithValue("ccodmon", "MN")
                        MyOleDBCommand.Parameters.AddWithValue("csitua", "F")
                        MyOleDBCommand.Parameters.AddWithValue("ctipcam", pTipoCambio)
                        MyOleDBCommand.Parameters.AddWithValue("cglosa", MyGlosa)
                        MyOleDBCommand.Parameters.AddWithValue("ctotal", pTotalRendicion)
                        MyOleDBCommand.Parameters.AddWithValue("ctipo", "V")
                        MyOleDBCommand.Parameters.AddWithValue("cflag", "S")
                        MyOleDBCommand.Parameters.AddWithValue("cdate", pFecha)
                        MyOleDBCommand.Parameters.AddWithValue("chora", "00:00:")
                        MyOleDBCommand.Parameters.AddWithValue("cuser", "SIST")
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("corig", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cform", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("ctipcom", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cextor", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom2", pFecha)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam2", pFecha)
                        MyOleDBCommand.ExecuteNonQuery()
                        If NEle > MyDT_Detalle.Rows.Count - 1 Then
                            Exit For
                        Else
                            NEle = NEle - 1
                        End If
                    End If
                Next

                For NEle = 0 To MyDT_Detalle.Rows.Count - 1
                    If MyDT_Detalle(NEle).dsubdia = "15" Then
                        MyComprobante = MyDT_Detalle(NEle).dcompro
                        MyGlosa = MyDT_Detalle(NEle).dxglosa
                        pTotalHonorarios = 0
                        Do While MyDT_Detalle(NEle).dcompro = MyComprobante
                            If MyDT_Detalle(NEle).ddh = "H" Then pTotalHonorarios = pTotalHonorarios + MyDT_Detalle(NEle).dmnimpor
                            NEle = NEle + 1
                            If NEle > MyDT_Detalle.Rows.Count - 1 Then Exit Do
                        Loop
                        MyOleDBCommand.Parameters.Clear()
                        MyOleDBCommand.Parameters.AddWithValue("csubdia", "15")
                        MyOleDBCommand.Parameters.AddWithValue("ccompro", MyComprobante)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom", pFechaComprobante)
                        MyOleDBCommand.Parameters.AddWithValue("ccodmon", "MN")
                        MyOleDBCommand.Parameters.AddWithValue("csitua", "F")
                        MyOleDBCommand.Parameters.AddWithValue("ctipcam", pTipoCambio)
                        MyOleDBCommand.Parameters.AddWithValue("cglosa", MyGlosa)
                        MyOleDBCommand.Parameters.AddWithValue("ctotal", pTotalHonorarios)
                        MyOleDBCommand.Parameters.AddWithValue("ctipo", "V")
                        MyOleDBCommand.Parameters.AddWithValue("cflag", "S")
                        MyOleDBCommand.Parameters.AddWithValue("cdate", pFecha)
                        MyOleDBCommand.Parameters.AddWithValue("chora", "00:00:")
                        MyOleDBCommand.Parameters.AddWithValue("cuser", "SIST")
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("corig", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cform", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("ctipcom", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cextor", Valor_Nulo)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccom2", pFecha)
                        MyOleDBCommand.Parameters.AddWithValue("cfeccam2", pFecha)
                        MyOleDBCommand.ExecuteNonQuery()
                        If NEle > MyDT_Detalle.Rows.Count - 1 Then
                            Exit For
                        Else
                            NEle = NEle - 1
                        End If
                    End If
                Next

                MyProgressBar.Visible = True

                MyProgressBar.Minimum = 0
                MyProgressBar.Maximum = MyDT_Detalle.Rows.Count
                MyProgressBar.Value = 0
                MyProgressBar.Step = 1

                MyOleDBString = "INSERT INTO ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                "(dsubdia, dcompro, dsecue, dfeccom, dcuenta, dcodane, dcencos, dcodmon, ddh, dimport, dtipdoc, dnumdoc, dfecdoc, dfecven, darea, dflag, ddate, dxglosa, " & _
                                "dusimpor, dmnimpor, dcodarc, dfeccom2, dfecdoc2, dfecven2, dcodane2, dvanexo, dvanexo2, dtipcam, dcantid, drete, dporre, dtipdor, dnumdor, dfecdo2, dtiptas, " & _
                                "dimptas, dimpbmn, dimpbus, dinacom, digvcom, dmedpag, dmoncom, dcolcom, dbascom, dtpconv, dflgcom, dtipaco, danecom) " & _
                                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                For NEle = 0 To MyDT_Detalle.Rows.Count - 1
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("dsubdia", MyDT_Detalle(NEle).dsubdia)
                    MyOleDBCommand.Parameters.AddWithValue("dcompro", MyDT_Detalle(NEle).dcompro)
                    MyOleDBCommand.Parameters.AddWithValue("dsecue", MyDT_Detalle(NEle).dsecue)
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom", pFechaComprobante)
                    MyOleDBCommand.Parameters.AddWithValue("dcuenta", MyDT_Detalle(NEle).dcuenta)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane", MyDT_Detalle(NEle).dcodane.Trim)
                    MyOleDBCommand.Parameters.AddWithValue("dcencos", MyDT_Detalle(NEle).dcencos.Trim)
                    MyOleDBCommand.Parameters.AddWithValue("dcodmon", MyDT_Detalle(NEle).dcodmon)
                    MyOleDBCommand.Parameters.AddWithValue("ddh", MyDT_Detalle(NEle).ddh)
                    MyOleDBCommand.Parameters.AddWithValue("dimport", MyDT_Detalle(NEle).dimport)
                    MyOleDBCommand.Parameters.AddWithValue("dtipdoc", MyDT_Detalle(NEle).dtipdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dnumdoc", MyDT_Detalle(NEle).dnumdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc", MyDT_Detalle(NEle).dfecdoc)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven", MyDT_Detalle(NEle).dfecven)
                    MyOleDBCommand.Parameters.AddWithValue("darea", MyDT_Detalle(NEle).darea)
                    MyOleDBCommand.Parameters.AddWithValue("dflag", MyDT_Detalle(NEle).dflag)
                    'MyOleDBCommand.Parameters.AddWithValue("ddate", MyDT_Detalle(NEle).ddate)
                    MyOleDBCommand.Parameters.AddWithValue("ddate", MyDT_Detalle(NEle).dfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("dxglosa", MyDT_Detalle(NEle).dxglosa.Trim)
                    MyOleDBCommand.Parameters.AddWithValue("dusimpor", MyDT_Detalle(NEle).dusimpor)
                    MyOleDBCommand.Parameters.AddWithValue("dmnimpor", MyDT_Detalle(NEle).dmnimpor)
                    MyOleDBCommand.Parameters.AddWithValue("dcodarc", MyDT_Detalle(NEle).dcodarc)
                    MyOleDBCommand.Parameters.AddWithValue("dfeccom2", MyDT_Detalle(NEle).dfeccom2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdoc2", MyDT_Detalle(NEle).dfecdoc2)
                    MyOleDBCommand.Parameters.AddWithValue("dfecven2", MyDT_Detalle(NEle).dfecven2)
                    MyOleDBCommand.Parameters.AddWithValue("dcodane2", MyDT_Detalle(NEle).dcodane2.Trim)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo", MyDT_Detalle(NEle).dvanexo)
                    MyOleDBCommand.Parameters.AddWithValue("dvanexo2", MyDT_Detalle(NEle).dvanexo2)
                    MyOleDBCommand.Parameters.AddWithValue("dtipcam", pTipoCambio)
                    MyOleDBCommand.Parameters.AddWithValue("dcantid", MyDT_Detalle(NEle).dcantid)
                    MyOleDBCommand.Parameters.AddWithValue("drete", MyDT_Detalle(NEle).drete)
                    MyOleDBCommand.Parameters.AddWithValue("dporre", MyDT_Detalle(NEle).dporre)
                    MyOleDBCommand.Parameters.AddWithValue("dtipdor", MyDT_Detalle(NEle).dtipdor)
                    MyOleDBCommand.Parameters.AddWithValue("dnumdor", MyDT_Detalle(NEle).dnumdor)
                    MyOleDBCommand.Parameters.AddWithValue("dfecdo2", MyDT_Detalle(NEle).dfecdo2)
                    MyOleDBCommand.Parameters.AddWithValue("dtiptas", MyDT_Detalle(NEle).dtiptas)
                    MyOleDBCommand.Parameters.AddWithValue("dimptas", MyDT_Detalle(NEle).dimptas)
                    MyOleDBCommand.Parameters.AddWithValue("dimpbmn", MyDT_Detalle(NEle).dimpbmn)
                    MyOleDBCommand.Parameters.AddWithValue("dimpbus", MyDT_Detalle(NEle).dimpbus)
                    MyOleDBCommand.Parameters.AddWithValue("dinacom", MyDT_Detalle(NEle).dinacom)
                    MyOleDBCommand.Parameters.AddWithValue("digvcom", MyDT_Detalle(NEle).digvcom)
                    MyOleDBCommand.Parameters.AddWithValue("dmedpag", MyDT_Detalle(NEle).dmedpag)
                    MyOleDBCommand.Parameters.AddWithValue("dmoncom", MyDT_Detalle(NEle).dmoncom)
                    MyOleDBCommand.Parameters.AddWithValue("dcolcom", MyDT_Detalle(NEle).dcolcom)
                    MyOleDBCommand.Parameters.AddWithValue("dbascom", 1)
                    MyOleDBCommand.Parameters.AddWithValue("dtpconv", MyDT_Detalle(NEle).dtpconv)
                    MyOleDBCommand.Parameters.AddWithValue("dflgcom", MyDT_Detalle(NEle).dflgcom)
                    MyOleDBCommand.Parameters.AddWithValue("dtipaco", MyDT_Detalle(NEle).dtipaco)
                    MyOleDBCommand.Parameters.AddWithValue("danecom", MyDT_Detalle(NEle).danecom)
                    MyOleDBCommand.ExecuteNonQuery()
                    MyProgressBar.Value += 1
                    MyProgressBar.Refresh()
                Next
                MyProgressBar.Value = MyDT_Detalle.Rows.Count
                MyProgressBar.Refresh()

                MyOleDBString = "INSERT INTO canbx (avanexo,acodane,adesane,arefane,aruc,acodmon,aestado,adate,ahora,avrete,aporre) " & _
                                "VALUES(?,?,?,?,?,?,?,?,?,?,?)"

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                For NEle = 1 To MyAnexos.Rows.Count
                    MyOleDBCommand.Parameters.Clear()
                    MyOleDBCommand.Parameters.AddWithValue("avanexo", MyAnexos(NEle - 1).avanexo)
                    MyOleDBCommand.Parameters.AddWithValue("acodane", MyAnexos(NEle - 1).acodane)
                    MyOleDBCommand.Parameters.AddWithValue("adesane", MyAnexos(NEle - 1).adesane)
                    MyOleDBCommand.Parameters.AddWithValue("arefane", MyAnexos(NEle - 1).arefane)
                    MyOleDBCommand.Parameters.AddWithValue("aruc", MyAnexos(NEle - 1).aruc)
                    MyOleDBCommand.Parameters.AddWithValue("acodmon", MyAnexos(NEle - 1).acodmon)
                    MyOleDBCommand.Parameters.AddWithValue("aestado", MyAnexos(NEle - 1).aestado)
                    MyOleDBCommand.Parameters.AddWithValue("adate", MyAnexos(NEle - 1).adate)
                    MyOleDBCommand.Parameters.AddWithValue("ahora", MyAnexos(NEle - 1).ahora)
                    MyOleDBCommand.Parameters.AddWithValue("avrete", MyAnexos(NEle - 1).avrete)
                    MyOleDBCommand.Parameters.AddWithValue("aporre", MyAnexos(NEle - 1).aporre)
                    MyOleDBCommand.ExecuteNonQuery()
                Next

                MyProgressBar.Visible = False

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

        If MyAnexos.Rows.Count > 0 Then
            Dim MySql = "INSERT INTO CON.ANEXOS_DETALLE  (avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora) " & _
                        "SELECT avanexo, acodane, adesane, arefane, aruc, acodmon, aestado, adate, ahora " & _
                        "FROM CON.ANEXOS_X_MIGRAR "

            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

                Dim MySQLTransaction As SqlTransaction
                Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

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
        End If

        Return True

    End Function

    Public Shared Function Eliminar(ByVal pEjercicio As String, ByVal pSubDiario As String, ByVal pComprobante As String) As Boolean

        Dim MyOleDBString As String = "DELETE FROM cccbx" & pEjercicio.Substring(2, 2) & " " & _
                                      "WHERE csubdia=? AND ccompro=? "

        Using MyOleDBDbconnection As New OleDbConnection(myConnectionStringOleDB_Concar)
            Dim MyOleDBTransaction As OleDbTransaction
            Dim MyOleDBCommand As New OleDbCommand(MyOleDBString, MyOleDBDbconnection)
            Dim NEle As Long

            Try
                MyOleDBDbconnection.Open()

                ' Start a local transaction.
                MyOleDBTransaction = MyOleDBDbconnection.BeginTransaction()

                ' Assign transaction object for a pending local transaction.
                MyOleDBCommand.Connection = MyOleDBDbconnection
                MyOleDBCommand.Transaction = MyOleDBTransaction

                MyOleDBCommand.Parameters.AddWithValue("csubdia", pSubDiario)
                MyOleDBCommand.Parameters.AddWithValue("ccompro", pComprobante)

                ' Execute the commands.
                MyOleDBCommand.ExecuteNonQuery()

                MyOleDBString = "DELETE FROM ccdbx" & pEjercicio.Substring(2, 2) & " " & _
                                "WHERE dsubdia=? AND dcompro=? "

                MyOleDBCommand.CommandType = CommandType.Text
                MyOleDBCommand.CommandText = MyOleDBString

                MyOleDBCommand.Parameters.Clear()
                MyOleDBCommand.Parameters.AddWithValue("dsubdia", pSubDiario)
                MyOleDBCommand.Parameters.AddWithValue("dcompro", pComprobante)
                MyOleDBCommand.ExecuteNonQuery()

                ' Commit the transaction.
                MyOleDBTransaction.Commit()

                Return True

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


End Class
