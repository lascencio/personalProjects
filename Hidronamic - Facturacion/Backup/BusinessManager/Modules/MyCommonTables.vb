Imports System.Data.SqlClient

Module MyCommonTables

    Private MyTablaGenerica As New dsTablasGenericas.TABLAS_DETALLEDataTable
    Private MyListaGenerica As New dsTablasGenericas.LISTADataTable
    Private MyListaEmpresa As New dsTablasGenericas.LISTADataTable

    Private myCommand As String

    Sub New()

        myCommand = "SELECT * FROM GEN.TABLAS_DETALLE WHERE EMPRESA='000' AND ESTADO='ACT'"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenerica)

        myCommand = "SELECT CODIGO_TABLA AS TABLA, CODIGO_ITEM AS CODIGO, NOMBRE_CORTO AS DESCRIPCION " & _
                    "FROM GEN.TABLAS_DETALLE WHERE EMPRESA='000' AND ESTADO='ACT'"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyListaGenerica)

        myCommand = "SELECT CODIGO_TABLA AS TABLA, CODIGO_ITEM AS CODIGO, NOMBRE_CORTO AS DESCRIPCION " & _
                    "FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & MyUsuario.empresa & "' AND ESTADO='ACT'"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyListaEmpresa)

    End Sub

    Public Sub ActualizarLista(ByRef Sender As ComboBox)
        Dim MyTabla As New dsTablasGenericas.LISTADataTable
        Select Case Sender.Name
            Case Is = "cmbListaPrecios"
                myCommand = "SELECT 'LISTA_PRECIO' AS TABLA, LISTA_PRECIOS AS CODIGO, COMENTARIO AS DESCRIPCION FROM COM.LISTA_PRECIOS"
        End Select
        myCommand = myCommand & " WHERE EMPRESA='" & MyUsuario.empresa & "' AND ESTADO='A' ORDER BY DESCRIPCION "
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTabla)
        Sender.DataSource = MyTabla
    End Sub

    Public Sub ActualizarLista(ByVal CodigoTabla As String, ByRef Sender As ComboBox)
        Dim MyLista As New dsTablasGenericas.LISTADataTable
        myCommand = "SELECT CODIGO_ITEM AS CODIGO, NOMBRE_CORTO AS DESCRIPCION " & _
                    "FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & MyUsuario.empresa & "' AND CODIGO_TABLA='" & CodigoTabla & "' AND ESTADO='ACT' " & _
                    "ORDER BY NOMBRE_CORTO"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyLista)
        Sender.DataSource = MyLista
    End Sub

    Public Sub ActualizarListaEmpresa(ByRef Sender As ComboBox, ByVal CodigoTabla As String)
        Sender.DataSource = MyListaEmpresa.Select("TABLA='" & CodigoTabla & "' ", "DESCRIPCION")
    End Sub

    Public Sub ActualizarListaGenerica(ByRef Sender As ComboBox, ByVal CodigoTabla As String)
        Sender.DataSource = MylistaGenerica.Select("TABLA='" & CodigoTabla & "' ", "DESCRIPCION")
    End Sub

    Public Sub ObtenerDescripcionListaEmpresa(ByRef Sender As TextBox, ByVal pTabla As String, ByVal pCodigo As String)
        Dim MyDR As dsTablasGenericas.LISTARow
        If MyListaEmpresa.Select("TABLA='" & pTabla & "' AND CODIGO='" & pCodigo & "'", "DESCRIPCION").Length = 0 Then
            Sender.Text = Nothing
        Else
            MyDR = MyListaEmpresa.Select("TABLA='" & pTabla & "' AND CODIGO='" & pCodigo & "'", "DESCRIPCION")(0)
            Sender.Text = MyDR.DESCRIPCION
        End If
    End Sub

    Public Sub AgregarFilaListaEmpresa(ByVal pTabla As String, ByVal pCodigo As String, ByVal pDescripcion As String)
        Dim MyDR As dsTablasGenericas.LISTARow
        MyDR = MyListaEmpresa.NewLISTARow
        MyDR.TABLA = pTabla
        MyDR.CODIGO = pCodigo
        MyDR.DESCRIPCION = pDescripcion
        MyListaEmpresa.Rows.Add(MyDR)
    End Sub

    Public Sub ModificarFilaListaEmpresa(ByVal pTabla As String, ByVal pCodigo As String, ByVal pDescripcion As String)
        Dim MyPosicion As Integer = -1
        Dim MyDR As dsTablasGenericas.LISTARow
        If MyListaEmpresa.Select("TABLA='" & pTabla & "' AND CODIGO='" & pCodigo & "'").Length <> 0 Then
            MyDR = MyListaEmpresa.Select("TABLA='" & pTabla & "' AND CODIGO='" & pCodigo & "'")(0)
            MyPosicion = MyListaEmpresa.Rows.IndexOf(MyDR)
            With MyListaEmpresa(MyPosicion)
                .DESCRIPCION = pDescripcion
            End With
        End If
    End Sub

    Public Sub ActualizarTabla(ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal ValorDefecto As String)
        NombreCombo.DataSource = MyTablaGenerica.Select("CODIGO_TABLA='" & CodigoTabla & "' ", "NOMBRE_CORTO")
        NombreCombo.SelectedValue = ValorDefecto
    End Sub

    Public Sub ActualizarTablaCodigo(ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal ValorDefecto As String)
        NombreCombo.DataSource = MyTablaGenerica.Select("CODIGO_TABLA='" & CodigoTabla & "' ", "CODIGO_ITEM")
        NombreCombo.SelectedValue = ValorDefecto
    End Sub

    Public Sub ActualizarCentroCosto(ByVal CodigoEmpresa As String, ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal ValorDefecto As String)
        Dim MyTablaGenericaSP As New dsTablasGenericas.TABLAS_DETALLEDataTable
        myCommand = "SELECT * FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & CodigoEmpresa & "' " & _
                    "AND CODIGO_TABLA='" & CodigoTabla & "' AND ESTADO='ACT' " & _
                    "ORDER BY CODIGO_ITEM "
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenericaSP)
        NombreCombo.DataSource = MyTablaGenericaSP
        NombreCombo.SelectedValue = ValorDefecto
    End Sub

    Public Sub ActualizarTablaTipoComprobante(ByVal CodigoEmpresa As String, ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal ValorDefecto As String)
        Dim MyTablaGenericaSP As New dsTablasGenericas.TABLAS_DETALLEDataTable
        myCommand = "SELECT * FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & CodigoEmpresa & "' " & _
                    "AND CODIGO_TABLA='" & CodigoTabla & "' AND ESTADO='ACT' AND LOGICO_01=1 " & _
                    "ORDER BY NOMBRE_LARGO"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenericaSP)
        NombreCombo.DataSource = MyTablaGenericaSP
        NombreCombo.SelectedValue = ValorDefecto
    End Sub

    Public Sub ActualizarTablaIF(ByVal CodigoEmpresa As String, ByRef NombreCombo As ComboBox)
        Dim MyTablaGenericaSP As New DataTable
        myCommand = "SELECT CODIGO_ITEM, CODIGO_ITEM+'   '+NOMBRE_LARGO AS NOMBRE_LARGO FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & CodigoEmpresa & "' " & _
                    "AND CODIGO_TABLA='CON_ITEM_FLUJO' AND ESTADO='ACT' " & _
                    "ORDER BY CODIGO_ITEM"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenericaSP)
        NombreCombo.DataSource = MyTablaGenericaSP
    End Sub

    Public Function ActualizarTablaIF(ByVal CodigoEmpresa As String) As DataTable
        Dim MyTablaGenericaSP As New DataTable
        myCommand = "SELECT CODIGO_ITEM, CODIGO_ITEM+'   '+NOMBRE_LARGO AS NOMBRE_LARGO FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & CodigoEmpresa & "' " & _
                    "AND CODIGO_TABLA='CON_ITEM_FLUJO' AND ESTADO='ACT' " & _
                    "ORDER BY CODIGO_ITEM"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenericaSP)
        Return MyTablaGenericaSP
    End Function

    Public Sub ActualizarTabla(ByVal CodigoEmpresa As String, ByVal CodigoTabla As String, ByVal CodigoSub As String, ByRef NombreCombo As ComboBox, ByVal ValorDefecto As String)
        Dim MyTablaGenericaSP As New dsTablasGenericas.TABLAS_DETALLEDataTable
        'myCommand = "SELECT ISNULL(CODIGO,'000') AS CODIGO, ISNULL(DESCRIPCION,'SIN DEFINIR') AS DESCRIPCION " & _
        myCommand = "SELECT * " & _
                    "FROM GEN.TABLAS_DETALLE WHERE EMPRESA='" & CodigoEmpresa & "' " & _
                    "AND CODIGO_TABLA='" & CodigoTabla & "' AND TEXTO_01='" & CodigoSub & "' AND ESTADO='ACT' " & _
                    "ORDER BY NOMBRE_CORTO"
        Call Procesos.ObtenerDataTableSQL(myCommand, MyTablaGenericaSP)
        NombreCombo.DataSource = MyTablaGenericaSP
    End Sub

    Public Sub DomicilioEnvio(ByVal pCuentaComercial As String, ByRef NombreCombo As ComboBox)
        Dim MyStoreProcedure As String = "COM.DOMICILIO_ENVIO"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = MyUsuario.empresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_COMERCIAL", SqlDbType.Char, 8) : MyParameter_2.Value = pCuentaComercial

        Dim MyDT As New DataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        NombreCombo.DataSource = MyDT
    End Sub

    Public Sub ActualizarTablaCabecera(ByVal CodigoEmpresa As String, ByRef NombreCombo As ComboBox)
        Dim myDT_Cabeceras As New dsTablasGenericas.TABLAS_CABECERADataTable
        myCommand = "SELECT * FROM GEN.TABLAS_CABECERA WHERE EMPRESA='" & CodigoEmpresa & "' ORDER BY NOMBRE_LARGO"
        Call Procesos.ObtenerDataTableSQL(myCommand, myDT_Cabeceras)
        NombreCombo.DataSource = myDT_Cabeceras
    End Sub

    Public Sub ActualizarTablaCabeceraLista(ByVal CodigoEmpresa As String, ByRef NombreGrilla As DataGridView)
        Dim myDT_CabecerasLista As New dsTablasCabeceraLista.TABLAS_CABECERA_LISTADataTable
        myCommand = "SELECT * FROM GEN.TABLAS_CABECERA_LISTA WHERE EMPRESA='" & CodigoEmpresa & "' ORDER BY DESCRIPCION"
        Call Procesos.ObtenerDataTableSQL(myCommand, myDT_CabecerasLista)
        NombreGrilla.DataSource = myDT_CabecerasLista
    End Sub

    Public Sub ActualizarTablaCtasBancariasLista(ByVal CodigoEmpresa As String, ByRef NombreGrilla As DataGridView)
        'Dim myDT_CtasBancariasLista As New dsCuentasBancariasLista.CUENTAS_BANCARIAS_LISTADataTable
        'myCommand = "SELECT * FROM GEN.CUENTAS_BANCARIAS_LISTA WHERE EMPRESA='" & CodigoEmpresa & "' ORDER BY BANCO"
        'Call Procesos.ObtenerDataTableSQL(myCommand, myDT_CtasBancariasLista)
        'NombreGrilla.DataSource = myDT_CtasBancariasLista
    End Sub

    Public Sub ActualizarTablaItemCompraLista(ByRef NombreGrilla As DataGridView)
        'Dim myDT_ItemCompraLista As New dsItemCompraLista.ITEM_COMPRA_LISTADataTable
        'myCommand = "SELECT * FROM GEN.ITEM_COMPRA_LISTA"
        'Call Procesos.ObtenerDataTableSQL(myCommand, myDT_ItemCompraLista)
        'NombreGrilla.DataSource = myDT_ItemCompraLista
    End Sub

    Public Sub ActualizarContable(ByVal CodigoEmpresa As String, ByRef NombreCombo As ComboBox, ByVal CodCuenta As String)
        Dim myDT_CtasContables As New dsCuentasContablesConcar.CUENTAS_CONTABLESDataTable
        myCommand = "SELECT * FROM GEN.CUENTAS_CONTABLES WHERE EMPRESA='" & CodigoEmpresa & "' AND SUBSTR(CUENTA_CONTABLE,1,4)='" & CodCuenta & "' AND LENGTH(CUENTA_CONTABLE)>4 "
        Call Procesos.ObtenerDataTableSQL(myCommand, myDT_CtasContables)
        NombreCombo.DataSource = myDT_CtasContables
        NombreCombo.ValueMember = "CUENTA_CONTABLE"
        NombreCombo.DisplayMember = "NOMBRE_CUENTA_CONTABLE"
    End Sub

    Public Sub ActualizarContableCompra(ByRef NombreCombo As ComboBox, ByVal CodCuenta As String)
        Dim myDT_CtasContables As New dsCuentasContablesConcar.CUENTAS_CONTABLESDataTable
        myCommand = "SELECT *FROM GEN.CUENTAS_CONTABLES WHERE EMPRESA='000' AND CUENTA_CONTABLE LIKE '" & CodCuenta & "%' AND LENGTH(CUENTA_CONTABLE)>3 "
        Call Procesos.ObtenerDataTableSQL(myCommand, myDT_CtasContables)
        NombreCombo.DataSource = myDT_CtasContables
        NombreCombo.ValueMember = "CUENTA_CONTABLE"
        NombreCombo.DisplayMember = "NOMBRE_CUENTA_CONTABLE"
    End Sub

    Public Sub ActualizarContableGasto(ByVal CodigoEmpresa As String, ByRef NombreCombo As ComboBox)
        Dim myDT_CtasContables As New dsCuentasContablesConcar.CUENTAS_CONTABLESDataTable
        myCommand = "SELECT * FROM GEN.CUENTAS_CONTABLES WHERE EMPRESA='" & CodigoEmpresa & "' AND INDICA_TABLA_ITEM_GASTO='-1' ORDER BY NOMBRE_CUENTA_CONTABLE "
        Call Procesos.ObtenerDataTableSQL(myCommand, myDT_CtasContables)
        NombreCombo.DataSource = myDT_CtasContables
        NombreCombo.ValueMember = "CUENTA_CONTABLE"
        NombreCombo.DisplayMember = "NOMBRE_CUENTA_CONTABLE"
    End Sub

    Public Sub ActualizarTablaItemGastosLista(ByVal CodigoEmpresa As String, ByVal CodCuenta As String, ByRef NombreGrilla As DataGridView)
        'Dim myDT_ItemGastoLista As New dsItemGasto.ITEM_GASTODataTable
        'myCommand = "SELECT * FROM GEN.ITEM_GASTO WHERE EMPRESA='" & CodigoEmpresa & "' AND CUENTA_CONTABLE='" & CodCuenta & "' ORDER BY DESCRIPCION"
        'Call Procesos.ObtenerDataTableSQL(myCommand, myDT_ItemGastoLista)
        'NombreGrilla.DataSource = myDT_ItemGastoLista
    End Sub

    Public Sub ActualizarTablaProvincia(ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal CodigoRegion As String)
        myCommand = "CODIGO_TABLA='" & CodigoTabla & "' AND SUBSTRING(CODIGO_ITEM,1,2)='" & CodigoRegion & "'"
        NombreCombo.DataSource = MyTablaGenerica.Select(myCommand, "NOMBRE_CORTO")
        NombreCombo.ValueMember = "CODIGO_ITEM"
        NombreCombo.DisplayMember = "NOMBRE_CORTO"
    End Sub

    Public Sub ActualizarTablaUbigeo(ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox, ByVal CodigoRegion As String, ByVal CodigoProvincia As String)
        myCommand = "CODIGO_TABLA='" & CodigoTabla & "' AND SUBSTRING(CODIGO_ITEM,1,4)='" & CodigoProvincia & "'"
        NombreCombo.DataSource = MyTablaGenerica.Select(myCommand, "NOMBRE_CORTO")
        NombreCombo.ValueMember = "CODIGO_ITEM"
        NombreCombo.DisplayMember = "NOMBRE_CORTO"
    End Sub

    Public Sub ActualizarTablaAFP(ByVal CodigoTabla As String, ByRef NombreCombo As ComboBox)
        NombreCombo.DataSource = MyTablaGenerica.Select("CODIGO_TABLA='" & CodigoTabla & "' AND TEXTO_01='AFP'", "NOMBRE_CORTO")
        NombreCombo.SelectedIndex = 0
    End Sub

    Public Function obtenerIGV() As Double
        Dim dr() As dsTablasGenericas.TABLAS_DETALLERow
        myCommand = "CODIGO_TABLA='_MONTO_IGV'"
        dr = MyTablaGenerica.Select(myCommand)
        Return dr(0).VALOR_01
    End Function

    Public Function obtenerITF() As Double
        Dim dr() As dsTablasGenericas.TABLAS_DETALLERow
        myCommand = "CODIGO_TABLA='_MONTO_ITF'"
        dr = MyTablaGenerica.Select(myCommand)
        Return dr(0).VALOR_01
    End Function

    Public Function obtenerCorreosEmpAseguradora(ByVal sCodigoEmpresaAseguradora As String) As DataTable
        Dim dr() As dsTablasGenericas.TABLAS_DETALLERow
        Dim dtt1 As New dsTablasGenericas.TABLAS_DETALLEDataTable

        dr = MyTablaGenerica.Select("CODIGO_TABLA='_CORREOS_AG_ASEGURADORA' AND TEXTO_01='" & sCodigoEmpresaAseguradora & "'")
        Dim dtt As New DataTable
        dtt.Columns.Add("CODIGO_ITEM")
        dtt.Columns.Add("CODIGO_EMPRESA")
        dtt.Columns.Add("NOMBRE")
        dtt.Columns.Add("CORREO")
        For i As Integer = 0 To dr.Length - 1
            dtt.Rows.Add(dr(i).CODIGO_ITEM, dr(i).TEXTO_01, dr(i).TEXTO_02, dr(i).TEXTO_03)
        Next
        Return dtt
    End Function

    Public Function NumeroAleatorio() As String
        Dim Random As New Random()
        Dim Numero As Long = Random.Next(1, 9999)
        Return Now.ToString("hhmmss") & Numero.ToString("0000")
    End Function

End Module

