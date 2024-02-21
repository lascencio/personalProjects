Imports System.Data.SqlClient

Public Class dalCuentaContable

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pCuentaContable As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaContable) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM CON.CUENTAS_CONTABLES WHERE Empresa=@vEmpresa AND Cuenta_Contable=@vCuentaContable"
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vCuentaContable", pCuentaContable)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal CuentaContable As entCuentaContable) As Boolean
        Return Existe(CuentaContable.empresa, CuentaContable.cuenta_contable)
    End Function

    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pCuentaContable As String) As entCuentaContable
        If Existe(pEmpresa, pCuentaContable) Then
            CadenaSQL = "SELECT * FROM CON.CUENTAS_CONTABLES " & _
                         "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_CONTABLE='" & pCuentaContable & "' "
            Return Obtener(New entCuentaContable, CadenaSQL)
        Else
            Return New entCuentaContable
        End If
    End Function

    Private Shared Function Obtener(ByVal CuentaContable As entCuentaContable, ByVal MyStringSQL As String) As entCuentaContable
        Dim MyDT As New dsCuentasContables.CUENTAS_CONTABLESDataTable
        Call ObtenerDataTableSQL(MyStringSQL, MyDT)
        If MyDT.Count > 0 Then
            With CuentaContable
                .empresa = MyDT(0).EMPRESA
                .cuenta_contable = MyDT(0).CUENTA_CONTABLE
                .nombre_cuenta_contable = MyDT(0).NOMBRE_CUENTA_CONTABLE
                .cuenta_equivalente = MyDT(0).CUENTA_EQUIVALENTE
                .nombre_cuenta_equivalente = MyDT(0).NOMBRE_CUENTA_EQUIVALENTE
                .tipo_cuenta = MyDT(0).TIPO_CUENTA
                .indica_movimiento = MyDT(0).INDICA_MOVIMIENTO
                .indica_conciliacion = MyDT(0).INDICA_CONCILIACION
                .indica_moneda_extranjera = MyDT(0).INDICA_MONEDA_EXTRANJERA
                .indica_cuenta_corriente = MyDT(0).INDICA_CUENTA_CORRIENTE
                .indica_documento_tipo = MyDT(0).INDICA_DOCUMENTO_TIPO
                .indica_documento_serie = MyDT(0).INDICA_DOCUMENTO_SERIE
                .indica_documento_numero = MyDT(0).INDICA_DOCUMENTO_NUMERO
                .indica_documento_fecha = MyDT(0).INDICA_DOCUMENTO_FECHA
                .indica_documento_vencimiento = MyDT(0).INDICA_DOCUMENTO_VENCIMIENTO
                .indica_documento_rellenar = MyDT(0).INDICA_DOCUMENTO_RELLENAR
                .indica_tabla_gastos_funcion = MyDT(0).INDICA_TABLA_GASTOS_FUNCION
                .indica_tabla_centro_costo = MyDT(0).INDICA_TABLA_CENTRO_COSTO
                .indica_tabla_item_flujo = MyDT(0).INDICA_TABLA_ITEM_FLUJO
                .indica_tabla_item_gasto = MyDT(0).INDICA_TABLA_ITEM_GASTO
                .indica_tabla_area_negocio = MyDT(0).INDICA_TABLA_AREA_NEGOCIO
                .indica_tabla_linea_negocio = MyDT(0).INDICA_TABLA_LINEA_NEGOCIO
                .indica_tabla_proyecto = MyDT(0).INDICA_TABLA_PROYECTO
                .indica_tabla_zona = MyDT(0).INDICA_TABLA_ZONA
                .indica_tabla_vendedor = MyDT(0).INDICA_TABLA_VENDEDOR
                .indica_tabla_comprador = MyDT(0).INDICA_TABLA_COMPRADOR
                .indica_tabla_transportista = MyDT(0).INDICA_TABLA_TRANSPORTISTA
                .indica_analisis_01 = MyDT(0).INDICA_ANALISIS_01
                .indica_analisis_02 = MyDT(0).INDICA_ANALISIS_02
                .indica_analisis_03 = MyDT(0).INDICA_ANALISIS_03
                .indica_analisis_04 = MyDT(0).INDICA_ANALISIS_04
                .indica_analisis_05 = MyDT(0).INDICA_ANALISIS_05
                .indica_analisis_06 = MyDT(0).INDICA_ANALISIS_06
                .indica_analisis_07 = MyDT(0).INDICA_ANALISIS_07
                .indica_analisis_08 = MyDT(0).INDICA_ANALISIS_08
                .indica_analisis_09 = MyDT(0).INDICA_ANALISIS_09
                .indica_analisis_10 = MyDT(0).INDICA_ANALISIS_10
                .generar_destino_automatico = MyDT(0).GENERAR_DESTINO_AUTOMATICO
                .tipo_tabla_cuenta_corriente = MyDT(0).TIPO_TABLA_CUENTA_CORRIENTE
                .tipo_tabla_documento = MyDT(0).TIPO_TABLA_DOCUMENTO
                .item_flujo = MyDT(0).ITEM_FLUJO
                .item_gasto = MyDT(0).ITEM_GASTO
                .partida_presupuestal = MyDT(0).PARTIDA_PRESUPUESTAL
                .cuenta_cargo = MyDT(0).CUENTA_CARGO
                .cuenta_abono = MyDT(0).CUENTA_ABONO
                .aplicable_compras = MyDT(0).APLICABLE_COMPRAS
                .aplicable_ventas = MyDT(0).APLICABLE_VENTAS
                .aplicable_ingresos = MyDT(0).APLICABLE_INGRESOS
                .aplicable_egresos = MyDT(0).APLICABLE_EGRESOS
                .aplicable_honorarios = MyDT(0).APLICABLE_HONORARIOS
                .aplicable_planillas = MyDT(0).APLICABLE_PLANILLAS
                .indica_cuenta_compra = MyDT(0).INDICA_CUENTA_COMPRA
                .indica_cuenta_venta = MyDT(0).INDICA_CUENTA_VENTA
                .indica_cuenta_costo = MyDT(0).INDICA_CUENTA_COSTO
                .indica_cuenta_reparable = MyDT(0).INDICA_CUENTA_REPARABLE
                .estado = MyDT(0).ESTADO
                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return CuentaContable
    End Function

    Public Shared Function Grabar(ByVal CuentaContable As entCuentaContable) As entCuentaContable
        With CuentaContable
            If String.IsNullOrEmpty(.cuenta_contable.Trim) Then Throw New BusinessException(MSG000 & " CUENTA CONTABLE")
            If String.IsNullOrEmpty(.nombre_cuenta_contable.Trim) Then Throw New BusinessException(MSG000 & " DESCRIPCION DE LA CUENTA")
            If .indica_cuenta_corriente = "SI" And .tipo_tabla_cuenta_corriente.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " TABLA ANEXO")
            If .indica_documento_tipo = "SI" And .tipo_tabla_documento.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " TABLA TIPO DE DOCUMENTO")
            If .generar_destino_automatico = "SI" And .cuenta_cargo.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " CUENTA CONTABLE CARGO")
            If .generar_destino_automatico = "SI" And .cuenta_abono.Trim.Length = 0 Then Throw New BusinessException(MSG000 & " CUENTA CONTABLE ABONO")
        End With
        If Not Existe(CuentaContable) Then
            Return Insertar(CuentaContable)
        Else
            Return Actualizar(CuentaContable)
        End If
    End Function

    Private Shared Function Insertar(ByVal CuentaContable As entCuentaContable) As entCuentaContable

        Dim MySql As String = "INSERT INTO CON.CUENTAS_CONTABLES " & _
        "(empresa,cuenta_contable,nombre_cuenta_contable,cuenta_equivalente,nombre_cuenta_equivalente,tipo_cuenta,indica_movimiento,indica_conciliacion," & _
        "indica_moneda_extranjera,indica_cuenta_corriente,indica_documento_tipo,indica_documento_serie,indica_documento_numero,indica_documento_fecha,indica_documento_vencimiento,indica_documento_rellenar," & _
        "indica_tabla_gastos_funcion,indica_tabla_centro_costo,indica_tabla_item_flujo,indica_tabla_item_gasto,indica_tabla_area_negocio,indica_tabla_linea_negocio," & _
        "indica_tabla_proyecto,indica_tabla_zona,indica_tabla_vendedor,indica_tabla_comprador,indica_tabla_transportista,indica_analisis_01,indica_analisis_02," & _
        "indica_analisis_03,indica_analisis_04,indica_analisis_05,indica_analisis_06,indica_analisis_07,indica_analisis_08,indica_analisis_09,indica_analisis_10," & _
        "tipo_tabla_cuenta_corriente,tipo_tabla_documento,item_flujo,item_gasto,partida_presupuestal,cuenta_cargo,cuenta_abono,aplicable_compras," & _
        "aplicable_ventas,aplicable_ingresos,aplicable_egresos,aplicable_honorarios,aplicable_planillas," & _
        "indica_cuenta_reparable,indica_cuenta_compra,indica_cuenta_venta,indica_cuenta_costo,vgenerar_destino_automatico,estado,usuario_registro) " & _
        "VALUES (@vempresa,@vcuenta_contable,@vnombre_cuenta_contable,@vcuenta_equivalente,@vnombre_cuenta_equivalente,@vtipo_cuenta,@vindica_movimiento," & _
        "@vindica_conciliacion,@vindica_moneda_extranjera,@vindica_cuenta_corriente,@vindica_documento_serie,@vindica_documento_tipo,@vindica_documento_numero,@vindica_documento_fecha," & _
        "@vindica_documento_vencimiento,@vindica_documento_rellenar,@vindica_tabla_gastos_funcion,@vindica_tabla_centro_costo,@vindica_tabla_item_flujo,@vindica_tabla_item_gasto," & _
        "@vindica_tabla_area_negocio,@vindica_tabla_linea_negocio,@vindica_tabla_proyecto,@vindica_tabla_zona,@vindica_tabla_vendedor,@vindica_tabla_comprador," & _
        "@vindica_tabla_transportista,@vindica_analisis_01,@vindica_analisis_02,@vindica_analisis_03,@vindica_analisis_04,@vindica_analisis_05,@vindica_analisis_06," & _
        "@vindica_analisis_07,@vindica_analisis_08,@vindica_analisis_09,@vindica_analisis_10,@vtipo_tabla_cuenta_corriente,@vtipo_tabla_documento,@vitem_flujo,@vitem_gasto," & _
        "@vpartida_presupuestal,@vcuenta_cargo,@vcuenta_abono,@vaplicable_compras,@vaplicable_ventas,@vaplicable_ingresos,@vaplicable_egresos,@vaplicable_honorarios,@vaplicable_planillas," & _
        "@vindica_cuenta_compra,@vindica_cuenta_venta,@vindica_cuenta_costo,@vgenerar_destino_automatico,@vindica_cuenta_reparable,@vestado,@vusuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters

                .AddWithValue("vempresa", CuentaContable.empresa)
                .AddWithValue("vcuenta_contable", CuentaContable.cuenta_contable.Trim)
                .AddWithValue("vnombre_cuenta_contable", CuentaContable.nombre_cuenta_contable)
                .AddWithValue("vcuenta_equivalente", CuentaContable.cuenta_equivalente)
                .AddWithValue("vnombre_cuenta_equivalente", CuentaContable.nombre_cuenta_equivalente)
                .AddWithValue("vtipo_cuenta", CuentaContable.tipo_cuenta)
                .AddWithValue("vindica_movimiento", CuentaContable.indica_movimiento)
                .AddWithValue("vindica_conciliacion", CuentaContable.indica_conciliacion)
                .AddWithValue("vindica_moneda_extranjera", CuentaContable.indica_moneda_extranjera)
                .AddWithValue("vindica_cuenta_corriente", CuentaContable.indica_cuenta_corriente)
                .AddWithValue("vindica_documento_tipo", CuentaContable.indica_documento_tipo)
                .AddWithValue("vindica_documento_numero", CuentaContable.indica_documento_numero)
                .AddWithValue("vindica_documento_serie", CuentaContable.indica_documento_serie)
                .AddWithValue("vindica_documento_fecha", CuentaContable.indica_documento_fecha)
                .AddWithValue("vindica_documento_vencimiento", CuentaContable.indica_documento_vencimiento)
                .AddWithValue("vindica_documento_rellenar", CuentaContable.indica_documento_rellenar)
                .AddWithValue("vindica_tabla_gastos_funcion", CuentaContable.indica_tabla_gastos_funcion)
                .AddWithValue("vindica_tabla_centro_costo", CuentaContable.indica_tabla_centro_costo)
                .AddWithValue("vindica_tabla_item_flujo", CuentaContable.indica_tabla_item_flujo)
                .AddWithValue("vindica_tabla_item_gasto", CuentaContable.indica_tabla_item_gasto)
                .AddWithValue("vindica_tabla_area_negocio", CuentaContable.indica_tabla_area_negocio)
                .AddWithValue("vindica_tabla_linea_negocio", CuentaContable.indica_tabla_linea_negocio)
                .AddWithValue("vindica_tabla_proyecto", CuentaContable.indica_tabla_proyecto)
                .AddWithValue("vindica_tabla_zona", CuentaContable.indica_tabla_zona)
                .AddWithValue("vindica_tabla_vendedor", CuentaContable.indica_tabla_vendedor)
                .AddWithValue("vindica_tabla_comprador", CuentaContable.indica_tabla_comprador)
                .AddWithValue("vindica_tabla_transportista", CuentaContable.indica_tabla_transportista)
                .AddWithValue("vindica_analisis_01", CuentaContable.indica_analisis_01)
                .AddWithValue("vindica_analisis_02", CuentaContable.indica_analisis_02)
                .AddWithValue("vindica_analisis_03", CuentaContable.indica_analisis_03)
                .AddWithValue("vindica_analisis_04", CuentaContable.indica_analisis_04)
                .AddWithValue("vindica_analisis_05", CuentaContable.indica_analisis_05)
                .AddWithValue("vindica_analisis_06", CuentaContable.indica_analisis_06)
                .AddWithValue("vindica_analisis_07", CuentaContable.indica_analisis_07)
                .AddWithValue("vindica_analisis_08", CuentaContable.indica_analisis_08)
                .AddWithValue("vindica_analisis_09", CuentaContable.indica_analisis_09)
                .AddWithValue("vindica_analisis_10", CuentaContable.indica_analisis_10)
                .AddWithValue("vtipo_tabla_cuenta_corriente", CuentaContable.tipo_tabla_cuenta_corriente)
                .AddWithValue("vtipo_tabla_documento", CuentaContable.tipo_tabla_documento)
                .AddWithValue("vitem_flujo", CuentaContable.item_flujo)
                .AddWithValue("vitem_gasto", CuentaContable.item_gasto)
                .AddWithValue("vpartida_presupuestal", CuentaContable.partida_presupuestal)
                .AddWithValue("vcuenta_cargo", CuentaContable.cuenta_cargo)
                .AddWithValue("vcuenta_abono", CuentaContable.cuenta_abono)
                .AddWithValue("vaplicable_compras", CuentaContable.aplicable_compras)
                .AddWithValue("vaplicable_ventas", CuentaContable.aplicable_ventas)
                .AddWithValue("vaplicable_ingresos", CuentaContable.aplicable_ingresos)
                .AddWithValue("vaplicable_egresos", CuentaContable.aplicable_egresos)
                .AddWithValue("vaplicable_honorarios", CuentaContable.aplicable_honorarios)
                .AddWithValue("vaplicable_planillas", CuentaContable.aplicable_planillas)
                .AddWithValue("vindica_cuenta_reparable", CuentaContable.indica_cuenta_reparable)
                .AddWithValue("vindica_cuenta_compra", CuentaContable.indica_cuenta_compra)
                .AddWithValue("vindica_cuenta_venta", CuentaContable.indica_cuenta_venta)
                .AddWithValue("vindica_cuenta_costo", CuentaContable.indica_cuenta_costo)
                .AddWithValue("vgenerar_destino_automatico", CuentaContable.generar_destino_automatico)
                .AddWithValue("vestado", CuentaContable.estado)
                .AddWithValue("vusuario_registro", MyUsuario.usuario)
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
                Return CuentaContable

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Private Shared Function Actualizar(ByVal CuentaContable As entCuentaContable) As entCuentaContable

        Dim MySql As String = "UPDATE CON.CUENTAS_CONTABLES SET nombre_cuenta_contable=@vnombre_cuenta_contable,cuenta_equivalente=@vcuenta_equivalente," & _
        "nombre_cuenta_equivalente=@vnombre_cuenta_equivalente,tipo_cuenta=@vtipo_cuenta,indica_movimiento=@vindica_movimiento,indica_conciliacion=@vindica_conciliacion," & _
        "indica_moneda_extranjera=@vindica_moneda_extranjera,indica_cuenta_corriente=@vindica_cuenta_corriente,indica_documento_tipo=@vindica_documento_tipo," & _
        "indica_documento_serie=@vindica_documento_serie,indica_documento_numero=@vindica_documento_numero,indica_documento_fecha=@vindica_documento_fecha," & _
        "indica_documento_vencimiento=@vindica_documento_vencimiento,indica_documento_rellenar=@vindica_documento_rellenar," & _
        "indica_tabla_gastos_funcion=@vindica_tabla_gastos_funcion,indica_tabla_centro_costo=@vindica_tabla_centro_costo,indica_tabla_item_flujo=@vindica_tabla_item_flujo," & _
        "indica_tabla_item_gasto=@vindica_tabla_item_gasto,indica_tabla_area_negocio=@vindica_tabla_area_negocio,indica_tabla_linea_negocio=@vindica_tabla_linea_negocio," & _
        "indica_tabla_proyecto=@vindica_tabla_proyecto,indica_tabla_zona=@vindica_tabla_zona,indica_tabla_vendedor=@vindica_tabla_vendedor,indica_tabla_comprador=@vindica_tabla_comprador," & _
        "indica_tabla_transportista=@vindica_tabla_transportista,indica_analisis_01=@vindica_analisis_01,indica_analisis_02=@vindica_analisis_02,indica_analisis_03=@vindica_analisis_03," & _
        "indica_analisis_04=@vindica_analisis_04,indica_analisis_05=@vindica_analisis_05,indica_analisis_06=@vindica_analisis_06,indica_analisis_07=@vindica_analisis_07," & _
        "indica_analisis_08=@vindica_analisis_08,indica_analisis_09=@vindica_analisis_09,indica_analisis_10=@vindica_analisis_10,tipo_tabla_cuenta_corriente=@vtipo_tabla_cuenta_corriente," & _
        "tipo_tabla_documento=@vtipo_tabla_documento,item_flujo=@vitem_flujo,item_gasto=@vitem_gasto,partida_presupuestal=@vpartida_presupuestal,cuenta_cargo=@vcuenta_cargo," & _
        "cuenta_abono=@vcuenta_abono,aplicable_compras=@vaplicable_compras,aplicable_ventas=@vaplicable_ventas,aplicable_ingresos=@vaplicable_ingresos," & _
        "aplicable_egresos=@vaplicable_egresos,aplicable_honorarios=@vaplicable_honorarios,aplicable_planillas=@vaplicable_planillas," & _
        "indica_cuenta_compra=@vindica_cuenta_compra,indica_cuenta_venta=@vindica_cuenta_venta,indica_cuenta_costo=@vindica_cuenta_costo,generar_destino_automatico=@vgenerar_destino_automatico," & _
        "indica_cuenta_reparable=@vindica_cuenta_reparable,estado=@vestado,usuario_modifica=@vusuario_modifica,fecha_modifica=@vfecha_modifica " & _
        " WHERE  empresa=@vempresa AND cuenta_contable=@vcuenta_contable"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            With MySQLCommand.Parameters

                .AddWithValue("vnombre_cuenta_contable", CuentaContable.nombre_cuenta_contable)
                .AddWithValue("vcuenta_equivalente", CuentaContable.cuenta_equivalente)
                .AddWithValue("vnombre_cuenta_equivalente", CuentaContable.nombre_cuenta_equivalente)
                .AddWithValue("vtipo_cuenta", CuentaContable.tipo_cuenta)
                .AddWithValue("vindica_movimiento", CuentaContable.indica_movimiento)
                .AddWithValue("vindica_conciliacion", CuentaContable.indica_conciliacion)
                .AddWithValue("vindica_moneda_extranjera", CuentaContable.indica_moneda_extranjera)
                .AddWithValue("vindica_cuenta_corriente", CuentaContable.indica_cuenta_corriente)
                .AddWithValue("vindica_documento_serie", CuentaContable.indica_documento_serie)
                .AddWithValue("vindica_documento_tipo", CuentaContable.indica_documento_tipo)
                .AddWithValue("vindica_documento_numero", CuentaContable.indica_documento_numero)
                .AddWithValue("vindica_documento_fecha", CuentaContable.indica_documento_fecha)
                .AddWithValue("vindica_documento_vencimiento", CuentaContable.indica_documento_vencimiento)
                .AddWithValue("vindica_documento_rellenar", CuentaContable.indica_documento_rellenar)
                .AddWithValue("vindica_tabla_gastos_funcion", CuentaContable.indica_tabla_gastos_funcion)
                .AddWithValue("vindica_tabla_centro_costo", CuentaContable.indica_tabla_centro_costo)
                .AddWithValue("vindica_tabla_item_flujo", CuentaContable.indica_tabla_item_flujo)
                .AddWithValue("vindica_tabla_item_gasto", CuentaContable.indica_tabla_item_gasto)
                .AddWithValue("vindica_tabla_area_negocio", CuentaContable.indica_tabla_area_negocio)
                .AddWithValue("vindica_tabla_linea_negocio", CuentaContable.indica_tabla_linea_negocio)
                .AddWithValue("vindica_tabla_proyecto", CuentaContable.indica_tabla_proyecto)
                .AddWithValue("vindica_tabla_zona", CuentaContable.indica_tabla_zona)
                .AddWithValue("vindica_tabla_vendedor", CuentaContable.indica_tabla_vendedor)
                .AddWithValue("vindica_tabla_comprador", CuentaContable.indica_tabla_comprador)
                .AddWithValue("vindica_tabla_transportista", CuentaContable.indica_tabla_transportista)
                .AddWithValue("vindica_analisis_01", CuentaContable.indica_analisis_01)
                .AddWithValue("vindica_analisis_02", CuentaContable.indica_analisis_02)
                .AddWithValue("vindica_analisis_03", CuentaContable.indica_analisis_03)
                .AddWithValue("vindica_analisis_04", CuentaContable.indica_analisis_04)
                .AddWithValue("vindica_analisis_05", CuentaContable.indica_analisis_05)
                .AddWithValue("vindica_analisis_06", CuentaContable.indica_analisis_06)
                .AddWithValue("vindica_analisis_07", CuentaContable.indica_analisis_07)
                .AddWithValue("vindica_analisis_08", CuentaContable.indica_analisis_08)
                .AddWithValue("vindica_analisis_09", CuentaContable.indica_analisis_09)
                .AddWithValue("vindica_analisis_10", CuentaContable.indica_analisis_10)
                .AddWithValue("vtipo_tabla_cuenta_corriente", CuentaContable.tipo_tabla_cuenta_corriente)
                .AddWithValue("vtipo_tabla_documento", CuentaContable.tipo_tabla_documento)
                .AddWithValue("vitem_flujo", CuentaContable.item_flujo)
                .AddWithValue("vitem_gasto", CuentaContable.item_gasto)
                .AddWithValue("vpartida_presupuestal", CuentaContable.partida_presupuestal)
                .AddWithValue("vcuenta_cargo", CuentaContable.cuenta_cargo)
                .AddWithValue("vcuenta_abono", CuentaContable.cuenta_abono)
                .AddWithValue("vaplicable_compras", CuentaContable.aplicable_compras)
                .AddWithValue("vaplicable_ventas", CuentaContable.aplicable_ventas)
                .AddWithValue("vaplicable_ingresos", CuentaContable.aplicable_ingresos)
                .AddWithValue("vaplicable_egresos", CuentaContable.aplicable_egresos)
                .AddWithValue("vaplicable_honorarios", CuentaContable.aplicable_honorarios)
                .AddWithValue("vaplicable_planillas", CuentaContable.aplicable_planillas)
                .AddWithValue("vindica_cuenta_reparable", CuentaContable.indica_cuenta_reparable)
                .AddWithValue("vindica_cuenta_compra", CuentaContable.indica_cuenta_compra)
                .AddWithValue("vindica_cuenta_venta", CuentaContable.indica_cuenta_venta)
                .AddWithValue("vindica_cuenta_costo", CuentaContable.indica_cuenta_costo)
                .AddWithValue("vgenerar_destino_automatico", CuentaContable.generar_destino_automatico)
                .AddWithValue("vestado", CuentaContable.estado)
                .AddWithValue("vusuario_modifica", MyUsuario.usuario)
                .AddWithValue("vfecha_modifica", Now)
                .AddWithValue("vempresa", CuentaContable.empresa)
                .AddWithValue("vcuenta_contable", CuentaContable.cuenta_contable.Trim)
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
                Return CuentaContable

            Catch ex As Exception
                'Try to rollback the transaction
                Try
                    MySQLTransaction.Rollback()
                Catch
                    ' Do nothing here; transaction is not active.
                End Try
                Throw New BusinessException(ERR1000 & ": " & ex.Message)
            End Try
        End Using
    End Function

    Public Shared Function Borrar(ByVal pEmpresa As String, ByVal pCuentaContable As String) As Boolean
        If Not String.IsNullOrEmpty(pCuentaContable) Then
            Resp = MsgBox("Confirmar proceso de eliminación.", MsgBoxStyle.YesNo, "ELIMINAR")
            If Resp.ToString = vbYes Then
                Call Eliminar(pEmpresa, pCuentaContable)
                Return True
            End If
        End If
    End Function

    Private Shared Function Eliminar(ByVal pEmpresa As String, ByVal pCuentaContable As String) As Boolean
        Dim MySqlString As String = "DELETE FROM CON.CUENTAS_CONTABLES WHERE Empresa=@vEmpresa AND Cuenta_Contable=@vCuentaContable "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vCuentaContable", pCuentaContable)
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

                Return True

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

    Public Shared Function BuscarCuentaContableNombre(ByVal pEmpresa As String, ByVal pNombreCuentacontable As String, ByVal pEstado As String, ByVal pSoloImputables As Boolean) As dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, NOMBRE_CUENTA_CONTABLE, TIPO_CUENTA, INDICA_MOVIMIENTO, ESTADO " & _
                                    "FROM CON.CUENTAS_CONTABLES_" & IIf(pEstado = "T", "TODAS ", "X_NATURALEZA ") & _
                                    "WHERE EMPRESA=@vEmpresa AND NOMBRE_CUENTA_CONTABLE LIKE '%'+@vNombre_Cuenta_Contable+'%' " & _
                                    IIf(pEstado <> "T", "AND LEFT(ESTADO,1)=@vEstado ", "") & _
                                    IIf(pSoloImputables = True, "AND INDICA_MOVIMIENTO='SI' ", "") & _
                                    "ORDER BY NOMBRE_CUENTA_CONTABLE"

        Dim MyDT As New dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vNombre_Cuenta_Contable", pNombreCuentacontable)
            If pEstado <> "T" Then MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function BuscarCuentaContableNombre(ByVal pEmpresa As String, ByVal pDescripcion As String, ByVal pEstado As String) As dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable
        Dim MyStoreProcedure As String = "CON.CUENTAS_CONTABLES_LISTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@NOMBRE_CUENTA_CONTABLE", SqlDbType.VarChar, 100) : MyParameter_2.Value = pDescripcion.Trim
        Dim MyParameter_3 As New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_3.Value = pEstado

        Dim MyDT As New dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarCuentaContableCuenta(ByVal pEmpresa As String, ByVal pCuentacontable As String, ByVal pEstado As String, ByVal pSoloImputables As Boolean) As dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, NOMBRE_CUENTA_CONTABLE, TIPO_CUENTA, INDICA_MOVIMIENTO, ESTADO " & _
                                    "FROM CON.CUENTAS_CONTABLES_" & IIf(pEstado = "T", "TODAS ", "X_NATURALEZA ") & _
                                    "WHERE EMPRESA=@vEmpresa AND CUENTA_CONTABLE LIKE @vCuenta_Contable+'%' " & _
                                    IIf(pEstado <> "T", "AND LEFT(ESTADO,1)=@vEstado ", "") & _
                                    IIf(pSoloImputables = True, "AND INDICA_MOVIMIENTO='SI' ", "") & _
                                    "ORDER BY CUENTA_CONTABLE"

        Dim MyDT As New dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
            MySQLCommand.Parameters.AddWithValue("vCuenta_Contable", pCuentacontable)
            If pEstado <> "T" Then MySQLCommand.Parameters.AddWithValue("vEstado", pEstado)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT

    End Function

    Public Shared Function BuscarCuentaContableCuenta(ByVal pEmpresa As String, ByVal pCuentaContable As String, ByVal pEstado As String) As dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable
        Dim MyStoreProcedure As String = "CON.CUENTAS_CONTABLES_X_CUENTA"
        Dim MyParameter_1 As New SqlParameter("@EMPRESA", SqlDbType.Char, 3) : MyParameter_1.Value = pEmpresa
        Dim MyParameter_2 As New SqlParameter("@CUENTA_CONTABLE", SqlDbType.VarChar, 20) : MyParameter_2.Value = pCuentaContable.Trim
        Dim MyParameter_3 As New SqlParameter("@ESTADO", SqlDbType.Char, 1) : MyParameter_3.Value = pEstado

        Dim MyDT As New dsCuentasContablesLista.CUENTAS_CONTABLES_LISTADataTable

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            Dim MySQLCommand As New SqlCommand(MyStoreProcedure, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.StoredProcedure
            MySQLCommand.Parameters.Add(MyParameter_1)
            MySQLCommand.Parameters.Add(MyParameter_2)
            MySQLCommand.Parameters.Add(MyParameter_3)
            Dim MyDA As New SqlDataAdapter(MySQLCommand)
            MyDA.Fill(MyDT)
        End Using
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasCargo(ByVal pEmpresa As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND TIPO_CUENTA='6' AND INDICA_CUENTA_REPARABLE='NO' " & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasAbono(ByVal pEmpresa As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND LEFT(CUENTA_CONTABLE,2) IN ('79','61') " & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasBalance(ByVal pEmpresa As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND TIPO_CUENTA<'6' " & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasBancos(ByVal pEmpresa As String, ByVal pTipoMoneda As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND LEFT(CUENTA_CONTABLE,2)='10' " & _
                                    IIf(pTipoMoneda = "T", "", "AND INDICA_MONEDA_EXTRANJERA='" & IIf(pTipoMoneda = "1", "NO", "SI") & "' ") & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasEventuales(ByVal pEmpresa As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND (LEFT(CUENTA_CONTABLE,3) IN ('632','633','659','639')) " & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasCompras(ByVal pEmpresa As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND (" & _
                                    "(LEFT(CUENTA_CONTABLE,1)='6') OR (LEFT(CUENTA_CONTABLE,2) IN ('14','18','32','33','34','40','45','46','48')) OR " & _
                                    "(LEFT(CUENTA_CONTABLE,4) IN ('2524')))" & _
                                    "ORDER BY CUENTA_CONTABLE "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasProveedores(ByVal pEmpresa As String, ByVal pMonedaExtranjera As String) As DataTable
        'Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
        '                            "FROM CON.CUENTAS_CONTABLES " & _
        '                            "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND (LEFT(CUENTA_CONTABLE,2) IN ('42','43')) " & _
        '                            IIf(pMonedaExtranjera = "T", "", "AND INDICA_MONEDA_EXTRANJERA='" & pMonedaExtranjera & "' ") & _
        '                            "ORDER BY CUENTA_CONTABLE "

        Dim MySqlString As String = "SELECT pcuenta AS CUENTA_CONTABLE, pcuenta + '- ' + pdescri AS NOMBRE_CUENTA_CONTABLE  " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE pvtipcta='P' AND (LEFT(pcuenta,2) IN ('42','43')) AND pmonref='" & IIf(pMonedaExtranjera = "NO", "MN", "US") & "' " & _
                                    "ORDER BY pcuenta "

        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasClientes(ByVal pEmpresa As String, ByVal pMonedaExtranjera As String) As DataTable
        'Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
        '                            "FROM CON.CUENTAS_CONTABLES " & _
        '                            "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND (LEFT(CUENTA_CONTABLE,2) IN ('12','13')) " & _
        '                            IIf(pMonedaExtranjera = "T", "", "AND INDICA_MONEDA_EXTRANJERA='" & pMonedaExtranjera & "' ") & _
        '                            "ORDER BY CUENTA_CONTABLE "

        Dim MySqlString As String = "SELECT pcuenta AS CUENTA_CONTABLE, pcuenta + '- ' + pdescri AS NOMBRE_CUENTA_CONTABLE  " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE pvtipcta='A' AND (LEFT(pcuenta,2) IN ('12','13')) AND pmonref='" & IIf(pMonedaExtranjera = "NO", "MN", "US") & "' " & _
                                    "ORDER BY pcuenta "

        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasGeneral(ByVal pEmpresa As String, ByVal pCuenta As String, ByVal pMonedaExtranjera As String) As DataTable
        'Dim MySqlString As String = "SELECT CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS NOMBRE_CUENTA_CONTABLE " & _
        '                            "FROM CON.CUENTAS_CONTABLES " & _
        '                            "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND (CUENTA_CONTABLE LIKE '" & pCuenta & "%') " & _
        '                            IIf(pMonedaExtranjera = "T", "", "AND INDICA_MONEDA_EXTRANJERA='" & pMonedaExtranjera & "' ") & _
        '                            "ORDER BY CUENTA_CONTABLE "

        Dim MySqlString As String = "SELECT pcuenta AS CUENTA_CONTABLE, pcuenta + '- ' + pdescri AS NOMBRE_CUENTA_CONTABLE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE pvtipcta<>'X' AND (pcuenta LIKE '" & pCuenta & "%') AND pmonref='" & IIf(pMonedaExtranjera = "NO", "MN", "US") & "' " & _
                                    "ORDER BY pcuenta "

        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function

    Public Shared Function BuscarCuentasMenorMayor(ByVal pEmpresa As String, ByVal pCuentaMenor As String, ByVal pCuentaMayor As String) As DataTable
        Dim MySqlString As String = "SELECT CUENTA_CONTABLE, NOMBRE_CUENTA_CONTABLE, CUENTA_CONTABLE + '- ' + NOMBRE_CUENTA_CONTABLE AS CUENTA_NOMBRE " & _
                                    "FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND CUENTA_CONTABLE IN (" & _
                                    "SELECT TOP 1 MIN(CUENTA_CONTABLE) AS CUENTA_CONTABLE FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND CUENTA_CONTABLE LIKE '" & pCuentaMenor & "%' " & _
                                    "UNION ALL " & _
                                    "SELECT TOP 1 MAX(CUENTA_CONTABLE) AS CUENTA_CONTABLE FROM CON.CUENTAS_CONTABLES " & _
                                    "WHERE EMPRESA='" & pEmpresa & "' AND INDICA_MOVIMIENTO='SI' AND CUENTA_CONTABLE LIKE '" & pCuentaMayor & "%') "
        Dim MyDT As New DataTable
        Call ObtenerDataTableSQL(MySqlString, MyDT)
        Return MyDT
    End Function
End Class
