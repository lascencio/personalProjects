Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class dalMigracion

    Private Shared MySqlString As String
    Private Shared MyOleString As String
    Private Shared MySQLCommand As SqlCommand
    Private Shared MyOleDbCommand As OleDbCommand

    Public Shared Function ObtenerDetalles(ByVal Agencia As String, ByVal TablaOrigen As String, Carpeta As String) As DataTable
        Dim MyDT As New DataTable
        Dim TablaDestino As String = TablaOrigen & "_" & Agencia

        Select Case TablaOrigen
            Case Is = "maecli" : MyDT = New dsTablasVFP.maecliDataTable
            Case Is = "maecon" : MyDT = New dsTablasVFP.maeconDataTable
            Case Is = "maedis" : MyDT = New dsTablasVFP.maedisDataTable
            Case Is = "maegar" : MyDT = New dsTablasVFP.maegarDataTable
            Case Is = "maeper" : MyDT = New dsTablasVFP.maeperDataTable
            Case Is = "trbcpre" : MyDT = New dsTablasVFP.trbcpreDataTable
            Case Is = "trbdesc" : MyDT = New dsTablasVFP.trbdescDataTable
            Case Is = "trbdope" : MyDT = New dsTablasVFP.trbdopeDataTable
            Case Is = "trbdpre" : MyDT = New dsTablasVFP.trbdpreDataTable
            Case Is = "trbope" : MyDT = New dsTablasVFP.trbopeDataTable
            Case Is = "trbopusr" : MyDT = New dsTablasVFP.trbopusrDataTable
        End Select

        myConnectionStringVFP = "Provider=VFPOLEDB.1;Data Source=" & Carpeta

        'myConnectionStringOleDB_Concar = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Carpeta & ";Extended Properties=" & """" & "dBASE IV" & """"

        MySqlString = "TRUNCATE TABLE dbo." & TablaDestino
        Using MySQLDbConnection As New SqlConnection(myConnectionStringSQL_MIGRAR)
            Dim MySQLTransaction As SqlTransaction
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbConnection)
            Try
                MySQLDbConnection.Open()

                MySQLTransaction = MySQLDbConnection.BeginTransaction()
                MySQLCommand.Connection = MySQLDbConnection
                MySQLCommand.Transaction = MySQLTransaction
                MySQLCommand.ExecuteNonQuery()

                If TablaOrigen = "trbcpre" Then
                    MyOleString = "SELECT dcpreope, dcliid, dcpremon, dcprepre, dcpref_p, dcprecuo, dcprefec, dcprefepp, VAL(STR(dcpretasa)) AS dcpretasa, dcpreint, " &
                                  "dcpretot, dcpresdo, dcpresta, dpercod, dcprepro, dcpreref, dtippre, ddesart, sectoristas " &
                                  "FROM trbcpre "
                Else
                    MyOleString = "SELECT * FROM " & TablaOrigen & ".dbf"
                End If

                Using MyOleDbConnection As New OleDbConnection(myConnectionStringVFP)
                    MyOleDbCommand = New OleDbCommand(MySqlString, MyOleDbConnection)
                    MyOleDbCommand.Connection = MyOleDbConnection
                    MyOleDbCommand.CommandType = CommandType.Text
                    MyOleDbCommand.CommandText = MyOleString
                    Dim MyDA As New OleDbDataAdapter(MyOleDbCommand)
                    MyDA.Fill(MyDT)
                End Using

                Return MyDT
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

    Public Shared Function Insertar(ByVal Agencia As String, ByVal TablaOrigen As String, MyDT_Migrar As DataTable) As Boolean
        Dim TablaDestino As String = TablaOrigen & "_" & Agencia
        '====================================================
        '====================================================

        Dim MySQLDbconnection As New SqlConnection(myConnectionStringSQL_MIGRAR)

        Dim MySql As String = "TRUNCATE TABLE dbo." & TablaDestino

        Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

        ' creo el objeto BulkCopy
        Dim copia As New SqlBulkCopy(MySQLDbconnection)

        'abro la conexión de destino
        MySQLDbconnection.Open()

        MySQLCommand.ExecuteNonQuery()

        'le digo la tabla que va migrar
        copia.DestinationTableName = "dbo." & TablaDestino

        'copio los datos
        copia.WriteToServer(MyDT_Migrar)

        'cierro la conexión
        MySQLDbconnection.Close()

        Return True
        '====================================================
        '====================================================
    End Function

    Public Shared Function InsertarRegistros(ByRef MyProgressBar As ProgressBar, ByVal Agencia As String, ByVal TablaOrigen As String, MyDT_Migrar As DataTable) As Boolean
        Dim TablaDestino As String = TablaOrigen & "_" & Agencia
        Dim MySQLColumnsSource As String
        Dim MySQLColumnsTarget As String

        Select Case TablaOrigen
            Case Is = "maecli"
                MySQLColumnsSource = "dcliid, dtipdoc, dnrodoc, dcliraz, dclidir, ddiscod, dclitel, dclicorreo, dcliref, dtrbdir, dtrbref, dtrbtel"
                MySQLColumnsTarget = "@vdcliid, @vdtipdoc, @vdnrodoc, @vdcliraz, @vdclidir, @vddiscod, @vdclitel, @vdclicorreo, @vdcliref, @vdtrbdir, @vdtrbref, @vdtrbtel"
            Case Is = "maecon"
                MySQLColumnsSource = "dconcod, dcondes"
                MySQLColumnsTarget = "@vdconcod, @vdcondes"
            Case Is = "maedis"
                MySQLColumnsSource = "ddiscod, ddisnom, ddisnoa"
                MySQLColumnsTarget = "@vddiscod, @vddisnom, @vddisnoa"
            Case Is = "maegar"
                MySQLColumnsSource = "dcliid, dgarid, dgarnom, dgardir, ddiscod, dgartel, dtipdoc, dnrodoc"
                MySQLColumnsTarget = "@vdcliid, @vdgarid, @vdgarnom, @vdgardir, @vddiscod, @vdgartel, @vdtipdoc, @vdnrodoc"
            Case Is = "maeper"
                MySQLColumnsSource = "dpercod, dareacod, dpernom, dperdni, dperlm, dperdir, dpertelefonos, dpercorreo, ddiscod, dperfna, dpersta, dperarc, dpercom, dsegcod, dsegniv, dsegnom, dsegfec, dsegfee"
                MySQLColumnsTarget = "@vdpercod, @vdareacod, @vdpernom, @vdperdni, @vdperlm, @vdperdir, @vdpertelefonos, @vdpercorreo, @vddiscod, @vdperfna, @vdpersta, @vdperarc, @vdpercom, @vdsegcod, @vdsegniv, @vdsegnom, @vdsegfec, @vdsegfee"
            Case Is = "trbcpre"
                MySQLColumnsSource = "dcpreope, dcliid, dcpremon, dcprepre, dcpref_p, dcprecuo, dcprefec, dcprefepp, dcpretasa, dcpreint, dcpretot, dcpresdo, dcpresta, dpercod, dcprepro, dcpreref, dtippre, ddesart, sectoristas"
                MySQLColumnsTarget = "@vdcpreope, @vdcliid, @vdcpremon, @vdcprepre, @vdcpref_p, @vdcprecuo, @vdcprefec, @vdcprefepp, @vdcpretasa, @vdcpreint, @vdcpretot, @vdcpresdo, @vdcpresta, @vdpercod, @vdcprepro, @vdcpreref, @vdtippre, @vddesart, @vsectoristas"
            Case Is = "trbdesc"
                MySQLColumnsSource = "ddesano, ddesmes, ddesnro, dcpreope, ddesfec, ddesmon, ddesdes, dpercod, ddespro"
                MySQLColumnsTarget = "@vddesano, @vddesmes, @vddesnro, @vdcpreope, @vddesfec, @vddesmon, @vddesdes, @vdpercod, @vddespro"
            Case Is = "trbdope"
                MySQLColumnsSource = "dopenro, dcpreope, ddprencu, dopemon, dopemor, ddopesta"
                MySQLColumnsTarget = "@vdopenro, @vdcpreope, @vddprencu, @vdopemon, @vdopemor, @vddopesta"
            Case Is = "trbdpre"
                MySQLColumnsSource = "dcpreope, ddprencu, ddprefev, ddprecuo, ddprefea, ddpresdo, ddprecom, dpercod, ddprepro"
                MySQLColumnsTarget = "@vdcpreope, @vddprencu, @vddprefev, @vddprecuo, @vddprefea, @vddpresdo, @vddprecom, @vdpercod, @vddprepro"
            Case Is = "trbope"
                MySQLColumnsSource = "dopeano, dopemes, dopenro, dopefec, dcpreope, dopemon, dopesta, dpercod, dopepro, dopedes"
                MySQLColumnsTarget = "@vdopeano, @vdopemes, @vdopenro, @vdopefec, @vdcpreope, @vdopemon, @vdopesta, @vdpercod, @vdopepro, @vdopedes"
            Case Is = "trbopusr"
                MySQLColumnsSource = "dpercod, dopcmenu, dtitulo, dopcord, dopcnom, dopcion"
                MySQLColumnsTarget = "@vdpercod, @vdopcmenu, @vdtitulo, @vdopcord, @vdopcnom, @vdopcion"
        End Select

        Using MySQLTransactionScope As New Transactions.TransactionScope
            Try
                MySqlString = "INSERT INTO dbo." & TablaDestino & " (" & MySQLColumnsSource & ") VALUES (" & MySQLColumnsTarget & ")"

                Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_MIGRAR)
                    MySQLDbconnection.Open()

                    MyProgressBar.Visible = True

                    MyProgressBar.Minimum = 0
                    MyProgressBar.Maximum = MyDT_Migrar.Rows.Count
                    MyProgressBar.Value = 0
                    MyProgressBar.Step = 1

                    Using MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                        For NEle As Long = 0 To MyDT_Migrar.Rows.Count - 1
                            MySQLCommand.CommandType = CommandType.Text
                            MySQLCommand.CommandText = MySqlString
                            MySQLCommand.Parameters.Clear()

                            With MySQLCommand.Parameters
                                Select Case TablaOrigen
                                    Case Is = "maecli"
                                        .AddWithValue("vdcliid", MyDT_Migrar(NEle).Item("dcliid"))
                                        .AddWithValue("vdtipdoc", MyDT_Migrar(NEle).Item("dtipdoc"))
                                        .AddWithValue("vdnrodoc", MyDT_Migrar(NEle).Item("dnrodoc"))
                                        .AddWithValue("vdcliraz", MyDT_Migrar(NEle).Item("dcliraz"))
                                        .AddWithValue("vdclidir", MyDT_Migrar(NEle).Item("dclidir"))
                                        .AddWithValue("vddiscod", MyDT_Migrar(NEle).Item("ddiscod"))
                                        .AddWithValue("vdclitel", MyDT_Migrar(NEle).Item("dclitel"))
                                        .AddWithValue("vdclicorreo", MyDT_Migrar(NEle).Item("dclicorreo"))
                                        .AddWithValue("vdcliref", MyDT_Migrar(NEle).Item("dcliref"))
                                        .AddWithValue("vdtrbdir", MyDT_Migrar(NEle).Item("dtrbdir"))
                                        .AddWithValue("vdtrbref", MyDT_Migrar(NEle).Item("dtrbref"))
                                        .AddWithValue("vdtrbtel", MyDT_Migrar(NEle).Item("dtrbtel"))
                                    Case Is = "maecon"
                                        .AddWithValue("vdconcod", MyDT_Migrar(NEle).Item("dconcod"))
                                        .AddWithValue("vdcondes", MyDT_Migrar(NEle).Item("dcondes"))
                                    Case Is = "maedis"
                                        .AddWithValue("vddiscod", MyDT_Migrar(NEle).Item("ddiscod"))
                                        .AddWithValue("vddisnom", MyDT_Migrar(NEle).Item("ddisnom"))
                                        .AddWithValue("vddisnoa", MyDT_Migrar(NEle).Item("ddisnoa"))
                                    Case Is = "maegar"
                                        .AddWithValue("vdcliid", MyDT_Migrar(NEle).Item("dcliid"))
                                        .AddWithValue("vdgarid", MyDT_Migrar(NEle).Item("dgarid"))
                                        .AddWithValue("vdgarnom", MyDT_Migrar(NEle).Item("dgarnom"))
                                        .AddWithValue("vdgardir", MyDT_Migrar(NEle).Item("dgardir"))
                                        .AddWithValue("vddiscod", MyDT_Migrar(NEle).Item("ddiscod"))
                                        .AddWithValue("vdgartel", MyDT_Migrar(NEle).Item("dgartel"))
                                        .AddWithValue("vdtipdoc", MyDT_Migrar(NEle).Item("dtipdoc"))
                                        .AddWithValue("vdnrodoc", MyDT_Migrar(NEle).Item("dnrodoc"))
                                    Case Is = "maeper"
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vdareacod", MyDT_Migrar(NEle).Item("dareacod"))
                                        .AddWithValue("vdpernom", MyDT_Migrar(NEle).Item("dpernom"))
                                        .AddWithValue("vdperdni", MyDT_Migrar(NEle).Item("dperdni"))
                                        .AddWithValue("vdperlm", MyDT_Migrar(NEle).Item("dperlm"))
                                        .AddWithValue("vdperdir", MyDT_Migrar(NEle).Item("dperdir"))
                                        .AddWithValue("vdpertelefonos", MyDT_Migrar(NEle).Item("dpertelefonos"))
                                        .AddWithValue("vdpercorreo", MyDT_Migrar(NEle).Item("dpercorreo"))
                                        .AddWithValue("vddiscod", MyDT_Migrar(NEle).Item("ddiscod"))
                                        .AddWithValue("vdperfna", MyDT_Migrar(NEle).Item("dperfna"))
                                        .AddWithValue("vdpersta", MyDT_Migrar(NEle).Item("dpersta"))
                                        .AddWithValue("vdperarc", MyDT_Migrar(NEle).Item("dperarc"))
                                        .AddWithValue("vdpercom", MyDT_Migrar(NEle).Item("dpercom"))
                                        .AddWithValue("vdsegcod", MyDT_Migrar(NEle).Item("dsegcod"))
                                        .AddWithValue("vdsegniv", MyDT_Migrar(NEle).Item("dsegniv"))
                                        .AddWithValue("vdsegnom", MyDT_Migrar(NEle).Item("dsegnom"))
                                        .AddWithValue("vdsegfec", MyDT_Migrar(NEle).Item("dsegfec"))
                                        .AddWithValue("vdsegfee", MyDT_Migrar(NEle).Item("dsegfee"))
                                    Case Is = "trbcpre"
                                        .AddWithValue("vdcpreope", MyDT_Migrar(NEle).Item("dcpreope"))
                                        .AddWithValue("vdcliid", MyDT_Migrar(NEle).Item("dcliid"))
                                        .AddWithValue("vdcpremon", MyDT_Migrar(NEle).Item("dcpremon"))
                                        .AddWithValue("vdcprepre", MyDT_Migrar(NEle).Item("dcprepre"))
                                        .AddWithValue("vdcpref_p", MyDT_Migrar(NEle).Item("dcpref_p"))
                                        .AddWithValue("vdcprecuo", MyDT_Migrar(NEle).Item("dcprecuo"))
                                        .AddWithValue("vdcprefec", MyDT_Migrar(NEle).Item("dcprefec"))
                                        .AddWithValue("vdcprefepp", MyDT_Migrar(NEle).Item("dcprefepp"))
                                        .AddWithValue("vdcpretasa", MyDT_Migrar(NEle).Item("dcpretasa"))
                                        .AddWithValue("vdcpreint", MyDT_Migrar(NEle).Item("dcpreint"))
                                        .AddWithValue("vdcpretot", MyDT_Migrar(NEle).Item("dcpretot"))
                                        .AddWithValue("vdcpresdo", MyDT_Migrar(NEle).Item("dcpresdo"))
                                        .AddWithValue("vdcpresta", MyDT_Migrar(NEle).Item("dcpresta"))
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vdcprepro", MyDT_Migrar(NEle).Item("dcprepro"))
                                        .AddWithValue("vdcpreref", MyDT_Migrar(NEle).Item("dcpreref"))
                                        .AddWithValue("vdtippre", MyDT_Migrar(NEle).Item("dtippre"))
                                        .AddWithValue("vddesart", MyDT_Migrar(NEle).Item("ddesart"))
                                        .AddWithValue("vsectoristas", MyDT_Migrar(NEle).Item("sectoristas"))
                                    Case Is = "trbdesc"
                                        .AddWithValue("vddesano", MyDT_Migrar(NEle).Item("ddesano"))
                                        .AddWithValue("vddesmes", MyDT_Migrar(NEle).Item("ddesmes"))
                                        .AddWithValue("vddesnro", MyDT_Migrar(NEle).Item("ddesnro"))
                                        .AddWithValue("vdcpreope", MyDT_Migrar(NEle).Item("dcpreope"))
                                        .AddWithValue("vddesfec", MyDT_Migrar(NEle).Item("ddesfec"))
                                        .AddWithValue("vddesmon", MyDT_Migrar(NEle).Item("ddesmon"))
                                        .AddWithValue("vddesdes", MyDT_Migrar(NEle).Item("ddesdes"))
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vddespro", MyDT_Migrar(NEle).Item("ddespro"))
                                    Case Is = "trbdope"
                                        .AddWithValue("vdopenro", MyDT_Migrar(NEle).Item("dopenro"))
                                        .AddWithValue("vdcpreope", MyDT_Migrar(NEle).Item("dcpreope"))
                                        .AddWithValue("vddprencu", MyDT_Migrar(NEle).Item("ddprencu"))
                                        .AddWithValue("vdopemon", MyDT_Migrar(NEle).Item("dopemon"))
                                        .AddWithValue("vdopemor", MyDT_Migrar(NEle).Item("dopemor"))
                                        .AddWithValue("vddopesta", MyDT_Migrar(NEle).Item("ddopesta"))
                                    Case Is = "trbdpre"
                                        .AddWithValue("vdcpreope", MyDT_Migrar(NEle).Item("dcpreope"))
                                        .AddWithValue("vddprencu", MyDT_Migrar(NEle).Item("ddprencu"))
                                        .AddWithValue("vddprefev", MyDT_Migrar(NEle).Item("ddprefev"))
                                        .AddWithValue("vddprecuo", MyDT_Migrar(NEle).Item("ddprecuo"))
                                        .AddWithValue("vddprefea", MyDT_Migrar(NEle).Item("ddprefea"))
                                        .AddWithValue("vddpresdo", MyDT_Migrar(NEle).Item("ddpresdo"))
                                        .AddWithValue("vddprecom", MyDT_Migrar(NEle).Item("ddprecom"))
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vddprepro", MyDT_Migrar(NEle).Item("ddprepro"))
                                    Case Is = "trbope"
                                        .AddWithValue("vdopeano", MyDT_Migrar(NEle).Item("dopeano"))
                                        .AddWithValue("vdopemes", MyDT_Migrar(NEle).Item("dopemes"))
                                        .AddWithValue("vdopenro", MyDT_Migrar(NEle).Item("dopenro"))
                                        .AddWithValue("vdopefec", MyDT_Migrar(NEle).Item("dopefec"))
                                        .AddWithValue("vdcpreope", MyDT_Migrar(NEle).Item("dcpreope"))
                                        .AddWithValue("vdopemon", MyDT_Migrar(NEle).Item("dopemon"))
                                        .AddWithValue("vdopesta", MyDT_Migrar(NEle).Item("dopesta"))
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vdopepro", MyDT_Migrar(NEle).Item("dopepro"))
                                        .AddWithValue("vdopedes", MyDT_Migrar(NEle).Item("dopedes"))
                                    Case Is = "trbopusr"
                                        .AddWithValue("vdpercod", MyDT_Migrar(NEle).Item("dpercod"))
                                        .AddWithValue("vdopcmenu", MyDT_Migrar(NEle).Item("dopcmenu"))
                                        .AddWithValue("vdtitulo", MyDT_Migrar(NEle).Item("dtitulo"))
                                        .AddWithValue("vdopcord", MyDT_Migrar(NEle).Item("dopcord"))
                                        .AddWithValue("vdopcnom", MyDT_Migrar(NEle).Item("dopcnom"))
                                        .AddWithValue("vdopcion", MyDT_Migrar(NEle).Item("dopcion"))
                                End Select
                            End With
                            MySQLCommand.ExecuteNonQuery()

                            MyProgressBar.Value += 1
                            MyProgressBar.Refresh()

                            frmMigrarTablas.lblProgress.Text = MyProgressBar.Value & " REGISTROS DE " & MyDT_Migrar.Rows.Count
                            frmMigrarTablas.lblProgress.Refresh()
                        Next
                    End Using
                    MySQLTransactionScope.Complete()
                End Using

                MyProgressBar.Visible = False
                MyProgressBar.Refresh()

                Return True
            Catch ex As Exception
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function


End Class
