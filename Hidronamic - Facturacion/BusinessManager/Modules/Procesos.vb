﻿Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text
Imports System.Drawing.Imaging
Imports Microsoft.Office.Interop
Imports ZXing

Public Module Procesos

    Public NFil, NCol, NEle, NAño, NMes As Integer, FecIni As DateTime, FecFin As DateTime

    Public MyUsuario As New entUsuario

    Public MyModulo As String

    Public MyEmpresa As String

    Public MyEjercicio As String = Now.Year.ToString
    Public MyMes As String = Strings.Right("00" & Now.Month.ToString, 2)
    Public MyFecha As Date = Now.Date

    Public MyCodigo_CONCAR As String

    Public MyIGV, MyISC, MyDetraccion, MyMinimoDetraccion As Decimal

    Public MyRazonSocial, MyRUC, MyDomicilioFiscal, MyDistrito, MyCuentaDetraccion, MyAfectoDetraccion As String

    Public Servidor As String

    Public MyFechaServidor As Date

    Public MyTempPath As String = "D:\Temp_Hidronamic"

    Public MyFileServerPath As String = "D:\FACTURAS ELECTRONICAS"
    'Public MyFileServerPath As String = "\\192.168.2.10\facturas electronicas"

    Public FechaNulo As Date = CDate("01/01/1900")
    Public CUO_Nulo As String = "000000000000"
    Public Valor_Nulo As String = " "

    Public myConnectionStringSQL_Development As String
    Public myConnectionStringSQL_Repository As String
    'Public myConnectionStringSQL_Repository As String
    Public myConnectionStringSQL_EComprobantes As String
    Public myConnectionStringSQL_Consulta_RUC As String

    Public myConnectionStringSQL_Concar As String
    Public myConnectionStringOleDB_Concar As String

    Public MyDTEmpresas As New dsEmpresas.EMPRESASDataTable
    Public MyDTEmpresasTodas As New dsEmpresas.EMPRESASDataTable

    Public myCommand, CadenaSQL, Resp, strFiltro As String, Continuar As Boolean

    Public MSG000 As String = "Debe registrar información en el campo "
    Public MSG001 As String = "Falta información en la fila "
    Public ERR1000 As String = "La transacción no se pudo realizar"
    Public ERR1001 As String = "El registro no existe"
    Public MSG1000 As String = "ERROR EN LA ACTUALIZACION"
    Public MSG1001 As String = "Registro actualizado correctamente. Id = {0}"
    Public MSG1002 As String = "El cheque ya fué registrado anteriormente. Comprobante: "
    Public MSG1003 As String = "El Comprobante ya fué registrado anteriormente. Asiento: "
    Public MSG1004 As String = "El Documento ya fué registrado anteriormente. "
    Public MSG1099 As String = "Dato no válido"

    Public SEE1000 As String = "MONTO EN LETRAS"
    Public SEE1002 As String = "TRANSFERENCIA GRATUITA"

    Public BV(5) As Boolean
    Public GR(3) As Boolean

    Public ImpresionCancelada As Boolean

    Public MyListaClientes As dsClientes.CLIENTES_LISTADataTable

    Sub New()
        Dim MyIP As String = "3.138.253.160"
        'Desarrollo
        'myConnectionStringSQL_Repository = My.Settings.cnnSQLRepositoryD : Servidor = "Desarrollo"
        'myConnectionStringSQL_Consulta_RUC = My.Settings.cnnConsultaRUCD.ToString
        'myConnectionStringOleDB_Concar = My.Settings.cnnVFPDemo
        'myConnectionStringOleDB_Concar = My.Settings.cnnJETDemo

        'Produccion
        myConnectionStringSQL_Repository = My.Settings.cnnSQLRepository.ToString
        myConnectionStringSQL_Consulta_RUC = My.Settings.cnnConsultaRUC.ToString
        myConnectionStringOleDB_Concar = My.Settings.cnnVFPConcar
        myConnectionStringOleDB_Concar = My.Settings.cnnJETConcar

        myConnectionStringSQL_Consulta_RUC = "Data Source=" & MyIP & ";Initial Catalog=Consulta_RUC;User ID=UserConsultas;Password=ConsultaRuc!"

        'Produccion Web
        'myConnectionStringSQL_Repository = My.Settings.cnnSQLRepository_Web.ToString

        myConnectionStringSQL_EComprobantes = My.Settings.cnnEComprobantes.ToString

        CadenaSQL = "SELECT CODIGO_ITEM AS EMPRESA, NOMBRE_LARGO AS RAZON_SOCIAL, VALOR_01 AS IGV, VALOR_02 AS ISC, VALOR_03 AS DETRACCION, VALOR_04 AS MINIMO_DETRACCION," & _
                    "TEXTO_01 AS RUC, TEXTO_02 AS DOMICILIO, TEXTO_03 AS DISTRITO, TEXTO_04 AS CUENTA_DETRACCION," & _
                    "TEXTO_05 AS CODIGO_CONCAR, CASE WHEN LOGICO_01=1 THEN 'SI' ELSE 'NO ' END AS AFECTO_DETRACCION, ESTADO " & _
                    "FROM GEN.TABLAS_DETALLE " & _
                    "WHERE CODIGO_TABLA='EMPRESAS' AND CODIGO_ITEM<>'000' AND ESTADO='ACT' "
        Call ObtenerDataTableSQL_Web(CadenaSQL, MyDTEmpresas)
        CadenaSQL = "SELECT CODIGO_ITEM AS EMPRESA, NOMBRE_LARGO AS RAZON_SOCIAL, VALOR_01 AS IGV, VALOR_02 AS ISC, VALOR_03 AS DETRACCION, VALOR_04 AS MINIMO_DETRACCION," & _
                    "TEXTO_01 AS RUC, TEXTO_02 AS DOMICILIO, TEXTO_03 AS DISTRITO, TEXTO_04 AS CUENTA_DETRACCION," & _
                    "TEXTO_05 AS CODIGO_CONCAR, CASE WHEN LOGICO_01=1 THEN 'SI' ELSE 'NO ' END AS AFECTO_DETRACCION, ESTADO " & _
                    "FROM GEN.TABLAS_DETALLE " & _
                    "WHERE CODIGO_TABLA='EMPRESAS' AND EMPRESA='000' "
        Call ObtenerDataTableSQL_Web(CadenaSQL, MyDTEmpresasTodas)
    End Sub

    Sub main()
    End Sub

    Public Function ObtenerUsuarios() As dsUsuarios.USUARIOS_LISTADataTable
        Dim MyDT As New dsUsuarios.USUARIOS_LISTADataTable

        CadenaSQL = "SELECT USUARIO, DESCRIPCION FROM GEN.USUARIOS " & _
                    "WHERE NOT (LEFT(DESCRIPCION,4) IN ('DEMO')) " & _
                    "ORDER BY DESCRIPCION "

        Call ObtenerDataTableSQL_Web(CadenaSQL, MyDT)

        Return MyDT
    End Function


    Public Sub ObtenerDataTableVFP(ByVal myStringCommand As String, ByRef myDataTable As Object)
        Dim myConnection As New OleDbConnection(myConnectionStringOleDB_Concar)
        Dim myDataAdapter As New OleDbDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Public Sub ObtenerDataTableSQL(ByVal myStringCommand As String, ByRef myDataTable As Object)
        Dim myConnection As New SqlConnection(myConnectionStringSQL_Repository)
        Dim myDataAdapter As New SqlDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Public Sub ObtenerDataTableSQL_Web(ByVal myStringCommand As String, ByRef myDataTable As Object)
        Dim myConnection As New SqlConnection(myConnectionStringSQL_Repository)
        Dim myDataAdapter As New SqlDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Public Sub ObtenerDataTableSQL_EComprobantes(ByVal myStringCommand As String, ByRef myDataTable As Object)
        Dim myConnection As New SqlConnection(myConnectionStringSQL_EComprobantes)
        Dim myDataAdapter As New SqlDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Public Sub ObtenerDataTableSQL(ByVal myStringCommand As String, ByRef myDataTable As Object, ByVal myCnn As String)
        Dim myConnection As New SqlConnection(myCnn)
        Dim myDataAdapter As New SqlDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Function EvalDato(ByVal Valor As String, ByVal Tipo As String) As String
        Dim ValorN As Decimal, ValorD As Date

        If Tipo = "FE" Then
            If Not IsDate(Valor) Then
                EvalDato = Nothing
            Else
                ValorD = CType(Valor, Date)
                EvalDato = Right("00" & ValorD.Day, 2) & " " & Right("00" & ValorD.Month, 2) & " " & ValorD.Year
            End If
        ElseIf Tipo = "FV" Then
            If Not IsDate(Valor) Then Valor = Now
            ValorD = CType(Valor, Date)
            EvalDato = Right("00" & ValorD.Day, 2) & "/" & Right("00" & ValorD.Month, 2) & "/" & ValorD.Year
        ElseIf Tipo = "F" Then
            If Not IsDate(Valor) Then
                EvalDato = Nothing
            Else
                ValorD = CType(Valor, Date)
                EvalDato = Right("00" & ValorD.Day, 2) & "/" & Right("00" & ValorD.Month, 2) & "/" & ValorD.Year
            End If
        ElseIf Tipo = "FSEE" Then
            If Not IsDate(Valor) Then
                EvalDato = Nothing
            Else
                ValorD = CType(Valor, Date)
                EvalDato = ValorD.Year & "-" & Right("00" & ValorD.Month, 2) & "-" & Right("00" & ValorD.Day, 2)
            End If
        Else
            If Not IsNumeric(Valor) Then
                ValorN = 0
            Else
                ValorN = CType(Valor, Decimal)
            End If
            If Tipo <> "Z" Then
                If Tipo = "DS" Then
                    Tipo = "D"
                Else
                    If ValorN < 0 Then ValorN = 0
                End If
                Select Case Tipo
                    Case Is = "DSEE"
                        EvalDato = Format(ValorN, "#0.00")
                    Case Is = "V"
                        EvalDato = Format(ValorN, "#,##0.0000")
                    Case Is = "C"
                        EvalDato = Format(ValorN, "#,##0.000")
                    Case Is = "D"
                        EvalDato = Format(ValorN, "#,##0.00")
                    Case Is = "E"
                        EvalDato = Format(ValorN, "#,##0")
                    Case Is = "PD"
                        ValorN = Math.Round(ValorN / 100, 4)
                        EvalDato = Format(ValorN, "#0.00%")
                    Case Is = "PE"
                        ValorN = Math.Round(ValorN / 100, 2)
                        EvalDato = Format(ValorN, "#0%")
                    Case Is = "EC"
                        EvalDato = Format(ValorN, "#0")
                        If EvalDato = "0" Then EvalDato = ""
                    Case Else
                        EvalDato = Format(ValorN, "#0")
                End Select
            Else
                EvalDato = Format(ValorN, "#,##0")
            End If
        End If
    End Function

    Function EvalMes(ByVal ValMes As Byte, ByVal Tipo As String) As String
        EvalMes = ""
        Select Case ValMes
            Case Is = 1 : EvalMes = IIf(Tipo = "C", "ENE", "Enero")
            Case Is = 2 : EvalMes = IIf(Tipo = "C", "FEB", "Febrero")
            Case Is = 3 : EvalMes = IIf(Tipo = "C", "MAR", "Marzo")
            Case Is = 4 : EvalMes = IIf(Tipo = "C", "ABR", "Abril")
            Case Is = 5 : EvalMes = IIf(Tipo = "C", "MAY", "Mayo")
            Case Is = 6 : EvalMes = IIf(Tipo = "C", "JUN", "Junio")
            Case Is = 7 : EvalMes = IIf(Tipo = "C", "JUL", "Julio")
            Case Is = 8 : EvalMes = IIf(Tipo = "C", "AGO", "Agosto")
            Case Is = 9 : EvalMes = IIf(Tipo = "C", "SET", "Setiembre")
            Case Is = 10 : EvalMes = IIf(Tipo = "C", "OCT", "Octubre")
            Case Is = 11 : EvalMes = IIf(Tipo = "C", "NOV", "Noviembre")
            Case Is = 12 : EvalMes = IIf(Tipo = "C", "DIC", "Diciembre")
        End Select
    End Function

    Function EvalMesNombre(ByVal NombreMes As String) As String
        Dim NumMes As String = ""
        Select Case NombreMes
            Case Is = "ENERO" : NumMes = "01"
            Case Is = "FEBRERO" : NumMes = "02"
            Case Is = "MARZO" : NumMes = "03"
            Case Is = "ABRIL" : NumMes = "04"
            Case Is = "MAYO" : NumMes = "05"
            Case Is = "JUNIO" : NumMes = "06"
            Case Is = "JULIO" : NumMes = "07"
            Case Is = "AGOSTO" : NumMes = "08"
            Case Is = "SETIEMBRE" : NumMes = "09"
            Case Is = "OCTUBRE" : NumMes = "10"
            Case Is = "NOVIEMBRE" : NumMes = "11"
            Case Is = "DICIEMBRE" : NumMes = "12"
        End Select
        EvalMesNombre = NumMes
    End Function

    Sub LlenarPeriodos(ByRef NomCombo As ComboBox)
        NomCombo.Items.Clear()
        For NAño = 2013 To Now.Year + 2
            NomCombo.Items.Add(NAño)
        Next
        NomCombo.Text = Now.Year
    End Sub

    Public Function NumeroLoteAleatorio() As String
        Dim Random As New Random()
        Dim Numero As Long = Random.Next(1, 999999)
        Return Now.ToString("hhmmss") & Numero.ToString("000000")
    End Function

    Function ProperCase(ByVal txt As String) As String
        Dim need_cap As Boolean
        Dim i As Integer
        Dim ch As String

        txt = LCase(RTrim(txt))
        need_cap = True
        For i = 1 To Len(txt)
            ch = Mid$(txt, i, 1)
            If ch >= "a" And ch <= "z" Then

                If need_cap Then
                    Mid$(txt, i, 1) = UCase(ch)
                    need_cap = False
                End If
            Else
                need_cap = True
            End If
        Next i
        ProperCase = txt
    End Function

    Function ConvertNumText(ByVal Number As Double, ByVal TipoMoneda As String) As String
        Dim TxtNumber As String, TextInt As String, TextDec As String
        Dim LngNumber As Integer
        Dim NEle As Integer, Factor As Integer, NumPart As Integer
        Dim TxtPart(2) As String

        TxtNumber = Strings.Format(Number, "#0.00")
        'TextDec = " Y " & Strings.Right(TxtNumber, 2) & "/100 " & IIf(TipoMoneda = "2", "DOLARES AMERICANOS", "SOLES")
        TextDec = " Y " & Strings.Right(TxtNumber, 2) & "/100 " & TipoMoneda
        LngNumber = TxtNumber.Length
        TextInt = Strings.Left(TxtNumber, LngNumber - 3) : Factor = 0
        For NEle = 1 To LngNumber - 3 Step 3
            Factor = Factor + 1
            TxtPart(Factor - 1) = Nothing
            NumPart = CInt(Strings.Left(Strings.Right("000" & TextInt, 3 * Factor), 3))
            TxtPart(Factor - 1) = EvalNumber(NumPart.ToString)
        Next NEle
        TxtNumber = TxtPart(2) & IIf(TxtPart(2) <> "", " MILLONES ", "") & _
                    TxtPart(1) & IIf(TxtPart(1) <> "", " MIL ", "") & _
                    TxtPart(0)
        TxtNumber = Strings.Replace(TxtNumber, "UNO MILLONES", "UN MILLON")
        TxtNumber = Strings.Replace(TxtNumber, "UNO MIL", "UN MIL")
        ConvertNumText = TxtNumber & TextDec

    End Function

    Function EvalNumber(ByVal TxtPart As String)
        Dim AuxNumber As String
        If CInt(TxtPart) < 30 Then
            Select Case TxtPart.ToString.Trim
                Case Is = "1" : AuxNumber = "UNO"
                Case Is = "2" : AuxNumber = "DOS"
                Case Is = "3" : AuxNumber = "TRES"
                Case Is = "4" : AuxNumber = "CUATRO"
                Case Is = "5" : AuxNumber = "CINCO"
                Case Is = "6" : AuxNumber = "SEIS"
                Case Is = "7" : AuxNumber = "SIETE"
                Case Is = "8" : AuxNumber = "OCHO"
                Case Is = "9" : AuxNumber = "NUEVE"
                Case Is = "10" : AuxNumber = "DIEZ"
                Case Is = "11" : AuxNumber = "ONCE"
                Case Is = "12" : AuxNumber = "DOCE"
                Case Is = "13" : AuxNumber = "TRECE"
                Case Is = "14" : AuxNumber = "CATORCE"
                Case Is = "15" : AuxNumber = "QUINCE"
                Case Is = "16" : AuxNumber = "DIECISÉIS"
                Case Is = "17" : AuxNumber = "DIECISIETE"
                Case Is = "18" : AuxNumber = "DIECIOCHO"
                Case Is = "19" : AuxNumber = "DIECINUEVE"
                Case Is = "20" : AuxNumber = "VEINTE"
                Case Is = "21" : AuxNumber = "VEINTIUNO"
                Case Is = "22" : AuxNumber = "VEINTIDÓS"
                Case Is = "23" : AuxNumber = "VEINTITRÉS"
                Case Is = "24" : AuxNumber = "VEINTICUATRO"
                Case Is = "25" : AuxNumber = "VEINTICINCO"
                Case Is = "26" : AuxNumber = "VEINTISEÍS"
                Case Is = "27" : AuxNumber = "VEINTISIETE"
                Case Is = "28" : AuxNumber = "VEINTIOCHO"
                Case Is = "29" : AuxNumber = "VEINTINUEVE"
            End Select
        ElseIf CInt(TxtPart) >= 30 And CInt(TxtPart) <= 99 Then
            Select Case Strings.Left(TxtPart, 1) & "0"
                'Case Is = "10" : AuxNumber = "DIEZ"
                'Case Is = "20" : AuxNumber = "VEINTE"
                Case Is = "30" : AuxNumber = "TREINTA"
                Case Is = "40" : AuxNumber = "CUARENTA"
                Case Is = "50" : AuxNumber = "CINCUENTA"
                Case Is = "60" : AuxNumber = "SESENTA"
                Case Is = "70" : AuxNumber = "SETENTA"
                Case Is = "80" : AuxNumber = "OCHENTA"
                Case Is = "90" : AuxNumber = "NOVENTA"
            End Select
            If Strings.Right(TxtPart, 1) <> "0" Then
                AuxNumber = AuxNumber & " Y " & EvalNumber(Strings.Right(TxtPart, 1))
            End If
        Else
            Select Case Strings.Left(TxtPart, 1) & "00"
                Case Is = "100" : AuxNumber = "CIEN"
                Case Is = "200" : AuxNumber = "DOSCIENTOS"
                Case Is = "300" : AuxNumber = "TRESCIENTOS"
                Case Is = "400" : AuxNumber = "CUATROCIENTOS"
                Case Is = "500" : AuxNumber = "QUINIENTOS"
                Case Is = "600" : AuxNumber = "SEISCIENTOS"
                Case Is = "700" : AuxNumber = "SETECIENTOS"
                Case Is = "800" : AuxNumber = "OCHOCIENTOS"
                Case Is = "900" : AuxNumber = "NOVECIENTOS"
            End Select
            If Strings.Right(TxtPart, 2) <> "00" Then
                If AuxNumber = "CIEN" Then AuxNumber = "CIENTO"
                AuxNumber = AuxNumber & " " & EvalNumber(CStr(CInt(Strings.Right(TxtPart, 2))))
            End If
        End If
        EvalNumber = AuxNumber
    End Function

    Public Sub ExportarExcel(ByRef MyProgressBar As ProgressBar, ByVal ds As DataSet)
        '/////////////////////////////
        '// Creamos el Objeto Excel
        '/////////////////////////////

        Dim m_Excel As New Excel.Application
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add()
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        Dim objCelda As Excel.Range

        objHojaExcel.Name = "Data"
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator

        '/////////////////////////////////////////////////////////
        '// Definimos dos variables para controlar fila y columna
        '/////////////////////////////////////////////////////////
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////
        objHojaExcel.Range("A1").Select()
        For Each dc In ds.Tables(0).Columns
            objHojaExcel.Range(nombreColumna(columna) & 1).Value = dc.ColumnName
            objCelda = objHojaExcel.Range(nombreColumna(columna) & 1, Type.Missing)
            If ds.Tables(0).Columns(columna - 1).DataType Is GetType(Decimal) OrElse dc.GetType Is GetType(Decimal) Then
                objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
            ElseIf ds.Tables(0).Columns(columna - 1).DataType Is GetType(String) Then
                objCelda.EntireColumn.NumberFormat = "@"
            End If
            columna += 1
        Next
        fila += 1

        '/////////////////////////////////////////////
        '// Le damos formato a la fila de los títulos
        '/////////////////////////////////////////////
        Dim objRango As Excel.Range = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & "1")
        objRango.Font.Bold = True
        objRango.Cells.Interior.ColorIndex = 35
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        '//////////////////////////////////////////
        '// Cargamos todas las filas del datatable
        '//////////////////////////////////////////
        MyProgressBar.Maximum = ds.Tables(0).Rows.Count
        columna = 1
        MyProgressBar.Value = 0
        MyProgressBar.Visible = True
        For Each dr In ds.Tables(0).Rows
            columna = 1
            For Each dc In ds.Tables(0).Columns
                objHojaExcel.Range(nombreColumna(columna) & fila).Value = dr(dc.ColumnName)
                columna += 1
            Next
            fila += 1
            MyProgressBar.Value += 1
        Next
        MyProgressBar.Visible = False

        '//////////////////////////////////////
        '// Ajustamos automaticamente el ancho
        '// de todas las columnas utilizada
        '//////////////////////////////////////
        If ds.Tables(0).Rows.Count > 0 Then
            objRango = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & ds.Tables(0).Rows.Count.ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
        End If
        '/////////////////////////////////////
        '// Le decimos a Excel que se muestre
        '/////////////////////////////////////
        MsgBox("Exportación a Excel completa", MsgBoxStyle.Information, "EXPORTAR A EXCEL")
        m_Excel.Visible = True
    End Sub

    Public Sub ExportarExcel(ByRef MyProgressBar As ProgressBar, ByVal dt As DataTable)
        '/////////////////////////////
        '// Creamos el Objeto Excel
        '/////////////////////////////

        Dim m_Excel As New Excel.Application
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add()
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        Dim objCelda As Excel.Range

        objHojaExcel.Name = "Data"
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator

        '/////////////////////////////////////////////////////////
        '// Definimos dos variables para controlar fila y columna
        '/////////////////////////////////////////////////////////
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////
        objHojaExcel.Range("A1").Select()
        For Each dc In dt.Columns
            objHojaExcel.Range(nombreColumna(columna) & 1).Value = dc.ColumnName
            objCelda = objHojaExcel.Range(nombreColumna(columna) & 1, Type.Missing)
            If dt.Columns(columna - 1).DataType Is GetType(Decimal) OrElse dc.GetType Is GetType(Decimal) Then
                objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
            ElseIf dt.Columns(columna - 1).DataType Is GetType(String) Then
                objCelda.EntireColumn.NumberFormat = "@"
            End If
            columna += 1
        Next
        fila += 1

        '/////////////////////////////////////////////
        '// Le damos formato a la fila de los títulos
        '/////////////////////////////////////////////
        Dim objRango As Excel.Range = objHojaExcel.Range("A1:" & nombreColumna(dt.Columns.Count) & "1")
        objRango.Font.Bold = True
        objRango.Cells.Interior.ColorIndex = 35
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        '//////////////////////////////////////////
        '// Cargamos todas las filas del datatable
        '//////////////////////////////////////////
        MyProgressBar.Maximum = dt.Rows.Count
        columna = 1
        MyProgressBar.Value = 0
        MyProgressBar.Visible = True
        For Each dr In dt.Rows
            columna = 1
            For Each dc In dt.Columns
                objHojaExcel.Range(nombreColumna(columna) & fila).Value = dr(dc.ColumnName)
                columna += 1
            Next
            fila += 1
            MyProgressBar.Value += 1
        Next
        MyProgressBar.Visible = False

        '//////////////////////////////////////
        '// Ajustamos automaticamente el ancho
        '// de todas las columnas utilizada
        '//////////////////////////////////////
        objRango = objHojaExcel.Range("A1:" & nombreColumna(dt.Columns.Count) & dt.Rows.Count.ToString)
        objRango.Select()
        objRango.Columns.AutoFit()

        '/////////////////////////////////////
        '// Le decimos a Excel que se muestre
        '/////////////////////////////////////
        MsgBox("Exportación a Excel completa", MsgBoxStyle.Information, "EXPORTAR A EXCEL")
        m_Excel.Visible = True
    End Sub

    Public Function nombreColumna(ByVal numero As Integer) As String
        Dim columna(256) As String

        columna(1) = "A" : columna(2) = "B" : columna(3) = "C" : columna(4) = "D" : columna(5) = "E" : columna(6) = "F" : columna(7) = "G" : columna(8) = "H"
        columna(9) = "I" : columna(10) = "J" : columna(11) = "K" : columna(12) = "L" : columna(13) = "M" : columna(14) = "N" : columna(15) = "O" : columna(16) = "P"
        columna(17) = "Q" : columna(18) = "R" : columna(19) = "S" : columna(20) = "T" : columna(21) = "U" : columna(22) = "V" : columna(23) = "W" : columna(24) = "X"
        columna(25) = "Y" : columna(26) = "Z" : columna(27) = "AA" : columna(28) = "AB" : columna(29) = "AC" : columna(30) = "AD" : columna(31) = "AE"
        columna(32) = "AF" : columna(33) = "AG" : columna(34) = "AH" : columna(35) = "AI" : columna(36) = "AJ" : columna(37) = "AK" : columna(38) = "AL"
        columna(39) = "AM" : columna(40) = "AN" : columna(41) = "AO" : columna(42) = "AP" : columna(43) = "AQ" : columna(44) = "AR" : columna(45) = "AS"
        columna(46) = "AT" : columna(47) = "AU" : columna(48) = "AV" : columna(49) = "AW" : columna(50) = "AX" : columna(51) = "AY" : columna(52) = "AZ"
        columna(53) = "BA" : columna(54) = "BB" : columna(55) = "BC" : columna(56) = "BD" : columna(57) = "BE" : columna(58) = "BF" : columna(59) = "BG"
        columna(60) = "BH" : columna(61) = "BI" : columna(62) = "BJ" : columna(63) = "BK" : columna(64) = "BL" : columna(65) = "BM" : columna(66) = "BN"
        columna(67) = "BO" : columna(68) = "BP" : columna(69) = "BQ" : columna(70) = "BR" : columna(71) = "BS" : columna(72) = "BT" : columna(73) = "BU"
        columna(74) = "BV" : columna(75) = "BW" : columna(76) = "BX" : columna(77) = "BY" : columna(78) = "BZ" : columna(79) = "CA" : columna(80) = "CB"
        columna(81) = "CC" : columna(82) = "CD" : columna(83) = "CE" : columna(84) = "CF" : columna(85) = "CG" : columna(86) = "CH" : columna(87) = "CI"
        columna(88) = "CJ" : columna(89) = "CK" : columna(90) = "CL" : columna(91) = "CM" : columna(92) = "CN" : columna(93) = "CO" : columna(94) = "CP"
        columna(95) = "CQ" : columna(96) = "CR" : columna(97) = "CS" : columna(98) = "CT" : columna(99) = "CU" : columna(100) = "CV" : columna(101) = "CW"
        columna(102) = "CX" : columna(103) = "CY" : columna(104) = "CZ" : columna(105) = "DA" : columna(106) = "DB" : columna(107) = "DC" : columna(108) = "DD"
        columna(109) = "DE" : columna(110) = "DF" : columna(111) = "DG" : columna(112) = "DH" : columna(113) = "DI" : columna(114) = "DJ" : columna(115) = "DK"
        columna(116) = "DL" : columna(117) = "DM" : columna(118) = "DN" : columna(119) = "DO" : columna(120) = "DP" : columna(121) = "DQ" : columna(122) = "DR"
        columna(123) = "DS" : columna(124) = "DT" : columna(125) = "DU" : columna(126) = "DV" : columna(127) = "DW" : columna(128) = "DX" : columna(129) = "DY"
        columna(130) = "DZ" : columna(131) = "EA" : columna(132) = "EB" : columna(133) = "EC" : columna(134) = "ED" : columna(135) = "EE" : columna(136) = "EF"
        columna(137) = "EG" : columna(138) = "EH" : columna(139) = "EI" : columna(140) = "EJ" : columna(141) = "EK" : columna(142) = "EL" : columna(143) = "EM"
        columna(144) = "EN" : columna(145) = "EO" : columna(146) = "EP" : columna(147) = "EQ" : columna(148) = "ER" : columna(149) = "ES" : columna(150) = "ET"
        columna(151) = "EU" : columna(152) = "EV" : columna(153) = "EW" : columna(154) = "EX" : columna(155) = "EY" : columna(156) = "EZ" : columna(157) = "FA"
        columna(158) = "FB" : columna(159) = "FC" : columna(160) = "FD" : columna(161) = "FE" : columna(162) = "FF" : columna(163) = "FG" : columna(164) = "FH"
        columna(165) = "FI" : columna(166) = "FJ" : columna(167) = "FK" : columna(168) = "FL" : columna(169) = "FM" : columna(170) = "FN" : columna(171) = "FO"
        columna(172) = "FP" : columna(173) = "FQ" : columna(174) = "FR" : columna(175) = "FS" : columna(176) = "FT" : columna(177) = "FU" : columna(178) = "FV"
        columna(179) = "FW" : columna(180) = "FX" : columna(181) = "FY" : columna(182) = "FZ" : columna(183) = "GA" : columna(184) = "GB" : columna(185) = "GC"
        columna(186) = "GD" : columna(187) = "GE" : columna(188) = "GF" : columna(189) = "GG" : columna(190) = "GH" : columna(191) = "GI" : columna(192) = "GJ"
        columna(193) = "GK" : columna(194) = "GL" : columna(195) = "GM" : columna(196) = "GN" : columna(197) = "GO" : columna(198) = "GP" : columna(199) = "GQ"
        columna(200) = "GR" : columna(201) = "GS" : columna(202) = "GT" : columna(203) = "GU" : columna(204) = "GV" : columna(205) = "GW" : columna(206) = "GX"
        columna(207) = "GY" : columna(208) = "GZ" : columna(209) = "HA" : columna(210) = "HB" : columna(211) = "HC" : columna(212) = "HD" : columna(213) = "HE"
        columna(214) = "HF" : columna(215) = "HG" : columna(216) = "HH" : columna(217) = "HI" : columna(218) = "HJ" : columna(219) = "HK" : columna(220) = "HL"
        columna(221) = "HM" : columna(222) = "HN" : columna(223) = "HO" : columna(224) = "HP" : columna(225) = "HQ" : columna(226) = "HR" : columna(227) = "HS"
        columna(228) = "HT" : columna(229) = "HU" : columna(230) = "HV" : columna(231) = "HW" : columna(232) = "HX" : columna(233) = "HY" : columna(234) = "HZ"
        columna(235) = "IA" : columna(236) = "IB" : columna(237) = "IC" : columna(238) = "ID" : columna(239) = "IE" : columna(240) = "IF" : columna(241) = "IG"
        columna(242) = "IH" : columna(243) = "II" : columna(244) = "IJ" : columna(245) = "IK" : columna(246) = "IL" : columna(247) = "IM" : columna(248) = "IN"
        columna(249) = "IO" : columna(250) = "IP" : columna(251) = "IQ" : columna(252) = "IR" : columna(253) = "IS" : columna(254) = "IT" : columna(255) = "IU"
        columna(256) = "IV"

        Return columna(numero)
    End Function

    Public Sub EvaluarFormulario(ByRef MyForm As Form)
        Dim EstaInstanciado As Boolean

        'Chequeo si ya está abierto.
        For Each f As Form In Application.OpenForms
            'Si está abierto devuelvo False (no se puede abrir).
            If f.Name = MyForm.Name Then EstaInstanciado = True
        Next

        If EstaInstanciado = True Then
            MyForm.BringToFront()
            MyForm.Focus()
        Else
            MyForm.MdiParent = frmMenu
            MyForm.Show()
        End If

    End Sub

    Public Sub EnableTextBox(ByRef MyTextBox As TextBox, ByVal MyStatus As Boolean)
        If MyStatus = True Then
            MyTextBox.BackColor = Color.AliceBlue
            MyTextBox.ForeColor = Color.MediumBlue
            MyTextBox.ReadOnly = False
            MyTextBox.TabStop = True
        Else
            MyTextBox.BackColor = Color.Moccasin
            MyTextBox.ForeColor = Color.DarkRed
            MyTextBox.ReadOnly = True
            MyTextBox.TabStop = False
        End If
    End Sub

    Public Sub EnableComboBox(ByRef MyComboBox As ComboBox, ByVal MyStatus As Boolean)
        MyComboBox.Enabled = MyStatus
        MyComboBox.TabStop = MyStatus
    End Sub

    Public Sub GenerarQR(MyTexto As String)
        Dim MyGenerador As BarcodeWriter = New BarcodeWriter
        MyGenerador.Format = BarcodeFormat.QR_CODE

        Dim MyImagen As Bitmap = New Bitmap(MyGenerador.Write(MyTexto), New System.Drawing.Size(225, 225))
        MyImagen.Save(MyTempPath & "\QR.png", Imaging.ImageFormat.Png)

    End Sub

    Public Sub GenerarPDF417(MyTexto As String)
        Dim MyGenerador As BarcodeWriter = New BarcodeWriter
        MyGenerador.Format = BarcodeFormat.PDF_417

        Dim MyImagen As Bitmap = New Bitmap(MyGenerador.Write(MyTexto), New System.Drawing.Size(225, 108))
        MyImagen.Save(MyTempPath & "\PDF417.png", Imaging.ImageFormat.Png)
    End Sub

End Module
