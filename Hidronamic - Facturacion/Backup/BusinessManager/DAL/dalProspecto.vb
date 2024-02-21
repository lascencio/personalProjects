Imports System.Data.SqlClient

Public Class dalProspecto

    Private Sub New()
    End Sub

    Private Shared Function Existe(ByVal pEmpresa As String, ByVal pProspecto As String, ByVal pVersion As String) As Boolean
        If Not String.IsNullOrEmpty(pProspecto) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM COM.PROSPECTOS WHERE Empresa=@vEmpresa AND Prospecto=@vProspecto AND Version=@vVersion "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", pEmpresa)
                MySQLCommand.Parameters.AddWithValue("vProspecto", pProspecto)
                MySQLCommand.Parameters.AddWithValue("vVersion", pVersion)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function

    Private Shared Function Existe(ByVal cProspecto As entProspecto) As Boolean
        If Not String.IsNullOrEmpty(cProspecto.prospecto) Then
            Dim MySqlString As String = "SELECT COUNT(*) FROM COM.PROSPECTO WHERE Empresa=@vEmpresa AND Prospecto=@vProspecto AND Version=@vVersion "
            Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
                Dim MySQLCommand As New SqlCommand(MySqlString, MySQLDbconnection)
                MySQLCommand.Parameters.AddWithValue("vEmpresa", cProspecto.empresa)
                MySQLCommand.Parameters.AddWithValue("vProspecto", cProspecto.prospecto)
                MySQLCommand.Parameters.AddWithValue("vVersion", cProspecto.version)
                MySQLDbconnection.Open()
                Dim MyCount As Integer = CInt(MySQLCommand.ExecuteScalar)
                Return IIf(MyCount = 0, False, True)
            End Using
        End If
    End Function


    Public Shared Function Obtener(ByVal pEmpresa As String, ByVal pProspecto As String, ByVal pVersion As String) As entProspecto
        If Existe(pEmpresa, pProspecto, pVersion) Then
            CadenaSQL = "SELECT * FROM COM.PROSPECTO WHERE EMPRESA='" & pEmpresa & "' AND PROSPECTO='" & pProspecto & "' AND VERSION='" & pVersion & "'"
            Return Obtener(New entProspecto, CadenaSQL, myConnectionStringSQL_Repository)
        Else
            Return New entProspecto
        End If
    End Function

    Private Shared Function Obtener(ByVal cProspecto As entProspecto, ByVal MyStringSQL As String, ByVal myConnectionString As String) As entProspecto
        Dim MyDT As New dsProspectos.PROSPECTOSDataTable

        Call ObtenerDataTableSQL(MyStringSQL, MyDT)

        If MyDT.Count > 0 Then
            With cProspecto
                .empresa = MyDT(0).EMPRESA
                .prospecto = MyDT(0).PROSPECTO
                .version = MyDT(0).VERSION
                .ejercicio = MyDT(0).EJERCICIO
                .mes = MyDT(0).MES
                .descripcion = MyDT(0).DESCRIPCION
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .tipo_servicio = MyDT(0).TIPO_SERVICIO
                .cuenta_comercial = MyDT(0).CUENTA_COMERCIAL
                .responsable_venta = MyDT(0).RESPONSABLE_VENTA
                .responsable_ejecucion = MyDT(0).RESPONSABLE_EJECUCION
                .probabilidad = MyDT(0).PROBABILIDAD
                .etapa = MyDT(0).ETAPA

                If Not MyDT(0).IsNull("FECHA_COTIZACION") Then .fecha_cotizacion = MyDT(0).FECHA_COTIZACION
                If Not MyDT(0).IsNull("FECHA_APROBACION") Then .fecha_aprobacion = MyDT(0).FECHA_APROBACION
                If Not MyDT(0).IsNull("FECHA_ENTREGA") Then .fecha_entrega = MyDT(0).FECHA_ENTREGA

                .periodo_inicio = MyDT(0).PERIODO_INICIO
                .periodo_cierre = MyDT(0).PERIODO_CIERRE
                .tipo_moneda = MyDT(0).TIPO_MONEDA
                .monto_total = MyDT(0).MONTO_TOTAL
                .contacto_comercial = MyDT(0).CONTACTO_COMERCIAL
                .costo_bienes = MyDT(0).COSTO_BIENES
                .costo_subcontratas = MyDT(0).COSTO_SUBCONTRATAS
                .gastos_generales = MyDT(0).GASTOS_GENERALES
                .gastos_inversion = MyDT(0).GASTOS_INVERSION
                .gastos_financiamiento = MyDT(0).GASTOS_FINANCIAMIENTO
                .margen = MyDT(0).MARGEN
                .tipo_orden = MyDT(0).TIPO_ORDEN
                .codigo_proyecto = MyDT(0).CODIGO_PROYECTO
                .ultima_facturacion = MyDT(0).ULTIMA_FACTURACION
                .pendiente_facturar = MyDT(0).PENDIENTE_FACTURAR

                If Not MyDT(0).IsNull("FECHA_ENCUESTA") Then .fecha_encuesta = MyDT(0).FECHA_ENCUESTA

                .usuario_encuesta = MyDT(0).USUARIO_ENCUESTA
                .valorizacion_encuesta = MyDT(0).VALORIZACION_ENCUESTA
                .comentario = MyDT(0).COMENTARIO
                .origen = MyDT(0).ORIGEN
                .estado = MyDT(0).ESTADO

                .usuario_registro = MyDT(0).USUARIO_REGISTRO
                .fecha_registro = MyDT(0).FECHA_REGISTRO
                If Not MyDT(0).IsNull("USUARIO_MODIFICA") Then .usuario_modifica = MyDT(0).USUARIO_MODIFICA
                If Not MyDT(0).IsNull("FECHA_MODIFICA") Then .fecha_modifica = MyDT(0).FECHA_MODIFICA
            End With
        End If
        Return cProspecto
    End Function

    Public Shared Function Grabar(ByVal cProspecto As entProspecto) As entProspecto
        With cProspecto
            If String.IsNullOrEmpty(.cuenta_comercial) Then Throw New BusinessException(MSG000 & " RUC")
            If String.IsNullOrEmpty(.descripcion.Trim) Then Throw New BusinessException(MSG000 & " DESCRIPCION")
            If String.IsNullOrEmpty(.tipo_servicio.Trim) Then Throw New BusinessException(MSG000 & " TIPO DE SERVICIO")
            If String.IsNullOrEmpty(.responsable_venta.Trim) Then Throw New BusinessException(MSG000 & " RESPONSABLE COMERCIAL")
            If String.IsNullOrEmpty(.responsable_ejecucion.Trim) Then Throw New BusinessException(MSG000 & " LIDER EJECUTOR")
            If .monto_total = 0 Then Throw New BusinessException(MSG000 & " MONTO TOTAL")
            If String.IsNullOrEmpty(.periodo_inicio.Trim) Then Throw New BusinessException(MSG000 & " PERIODO DE INICIO")
            If String.IsNullOrEmpty(.periodo_cierre.Trim) Then Throw New BusinessException(MSG000 & " PERIODO DE CIERRE")
        End With

        If Not Existe(cProspecto) Then
            Return Insertar(cProspecto)
        Else
            Return Actualizar(cProspecto)
        End If
    End Function

    Private Shared Function Insertar(ByVal cProspecto As entProspecto) As entProspecto
        With cProspecto
            .prospecto = AsignarProspecto()
            .version = AsignarNumeroVersion(cProspecto.empresa, cProspecto.prospecto)
        End With

        Dim MySql As String = "INSERT INTO COM.PROSPECTOS " & _
                              "(empresa,prospecto,version,ejercicio,mes,descripcion,cuenta_comercial,tipo_servicio,responsable_venta,responsable_ejecucion," & _
                              "probabilidad,etapa,fecha_cotizacion,fecha_aprobacion,fecha_entrega,periodo_inicio,periodo_cierre,tipo_moneda,monto_total,contacto_comercial," & _
                              "costo_bienes,costo_subcontratas,gastos_generales,gastos_inversion,gastos_financiamiento,margen,tipo_orden,codigo_proyecto," & _
                              "ultima_facturacion,pendiente_facturar,fecha_encuesta,usuario_encuesta,valorizacion_encuesta,comentario,origen,estado,usuario_registro) " & _
                              "VALUES (" & _
                              "@vEmpresa,@vProspecto,@vVersion,@vEjercicio,@vMes,@vDescripcion,@vCuenta_comercial,@vTipo_servicio,@vResponsable_venta,@vResponsable_ejecucion," & _
                              "@vProbabilidad,@vEtapa,@vFecha_cotizacion,@vFecha_aprobacion,@vFecha_entrega,@vPeriodo_inicio,@vPeriodo_cierre,@vTipo_moneda,@vMonto_total,@vContacto_comercial," & _
                              "@vCosto_bienes,@vCosto_subcontratas,@vGastos_generales,@vGastos_inversion,@vGastos_financiamiento,@vMargen,@vTipo_orden,@vCodigo_proyecto," & _
                              "@vUltima_facturacion,@vPendiente_facturar,@vFecha_encuesta,@vUsuario_encuesta,@vValorizacion_encuesta,@vComentario,@vOrigen,@vEstado,@vUsuario_registro) "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEmpresa", cProspecto.empresa)
                .AddWithValue("vProspecto", cProspecto.prospecto)
                .AddWithValue("vVersion", cProspecto.version)
                .AddWithValue("vEjercicio", cProspecto.ejercicio)
                .AddWithValue("vMes", cProspecto.mes)
                .AddWithValue("vDescripcion", cProspecto.descripcion)
                .AddWithValue("vCuenta_comercial", cProspecto.cuenta_comercial)
                .AddWithValue("vTipo_servicio", cProspecto.tipo_servicio)
                .AddWithValue("vResponsable_venta", cProspecto.responsable_venta)
                .AddWithValue("vResponsable_ejecucion", cProspecto.responsable_ejecucion)
                .AddWithValue("vProbabilidad", cProspecto.probabilidad)
                .AddWithValue("vEtapa", cProspecto.etapa)
                .AddWithValue("vFecha_cotizacion", cProspecto.fecha_cotizacion)
                .AddWithValue("vFecha_aprobacion", cProspecto.fecha_aprobacion)
                .AddWithValue("vFecha_entrega", cProspecto.fecha_entrega)
                .AddWithValue("vPeriodo_inicio", cProspecto.periodo_inicio)
                .AddWithValue("vPeriodo_cierre", cProspecto.periodo_cierre)
                .AddWithValue("vTipo_moneda", cProspecto.tipo_moneda)
                .AddWithValue("vMonto_total", cProspecto.monto_total)
                .AddWithValue("vContacto_comercial", cProspecto.contacto_comercial)
                .AddWithValue("vCosto_bienes", cProspecto.costo_bienes)
                .AddWithValue("vCosto_subcontratas", cProspecto.costo_subcontratas)
                .AddWithValue("vGastos_generales", cProspecto.gastos_generales)
                .AddWithValue("vGastos_inversion", cProspecto.gastos_inversion)
                .AddWithValue("vGastos_financiamiento", cProspecto.gastos_financiamiento)
                .AddWithValue("vMargen", cProspecto.margen)
                .AddWithValue("vTipo_orden", cProspecto.tipo_orden)
                .AddWithValue("vCodigo_proyecto", cProspecto.codigo_proyecto)
                .AddWithValue("vUltima_facturacion", cProspecto.ultima_facturacion)
                .AddWithValue("vPendiente_facturar", cProspecto.pendiente_facturar)
                .AddWithValue("vFecha_encuesta", cProspecto.fecha_encuesta)
                .AddWithValue("vUsuario_encuesta", cProspecto.usuario_encuesta)
                .AddWithValue("vComentario", cProspecto.comentario)
                .AddWithValue("vOrigen", cProspecto.origen)
                .AddWithValue("vEstado", cProspecto.estado)
                .AddWithValue("vUsuario_registro", cProspecto.usuario_registro)
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

                Return cProspecto

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

    Private Shared Function AsignarProspecto() As String

        Dim MySql As String = "SELECT ISNULL(MAX(PROSPECTO),'') AS NUEVO_CODIGO FROM COM.PROSPECTOS "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "P00000000001"
            Else
                Correlativo = CLng(NewCode.Substring(1, 11)) + 1
                NewCode = "P" & Right("00000000000" & Correlativo.ToString, 11)
            End If
            Return NewCode

        End Using

    End Function

    Private Shared Function AsignarNumeroVersion(ByVal pEmpresa As String, ByVal pProspecto As String) As String

        Dim MySql As String = "SELECT ISNULL(MAX(VERSION),'') AS NUEVO_NUMERO " & _
                              "FROM COM.PROSPECTOS " & _
                              "WHERE EMPRESA='" & pEmpresa & "' AND PROSPECTO='" & pProspecto & "' "
        Dim Correlativo As Long

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)
            MySQLDbconnection.Open()

            Dim NewCode As String = MySQLCommand.ExecuteScalar

            If String.IsNullOrEmpty(NewCode.Trim) Then
                NewCode = "01"
            Else
                Correlativo = CLng(NewCode) + 1
                NewCode = Strings.Right("00" & Correlativo.ToString, 2)
            End If
            Return NewCode

        End Using
    End Function

    Private Shared Function Actualizar(ByVal cProspecto As entProspecto) As entProspecto

        Dim MySql As String = "UPDATE COM.PROSPECTOS SET " & _
        "(Ejercicio=@vEjercicio,Mes=@vMes,Descripcion=@vDescripcion,Cuenta_comercial=@vCuenta_comercial,Tipo_servicio=@vTipo_servicio," & _
        "Responsable_venta=@vResponsable_venta,Responsable_ejecucion=@vResponsable_ejecucion,Probabilidad=@vProbabilidad,Etapa=@vEtapa,Fecha_cotizacion=@vFecha_cotizacion," & _
        "Fecha_aprobacion=@vFecha_aprobacion,Fecha_entrega=@vFecha_entrega,Periodo_inicio=@vPeriodo_inicio,Periodo_cierre=@vPeriodo_cierre,Tipo_moneda=@vTipo_moneda," & _
        "Monto_total=@vMonto_total,Contacto_comercial=@vContacto_comercial,Costo_bienes=@vCosto_bienes,Costo_subcontratas=@vCosto_subcontratas,Gastos_generales=@vGastos_generales,Gastos_inversion=@vGastos_inversion," & _
        "Gastos_financiamiento=@vGastos_financiamiento,Margen=@vMargen,Tipo_orden=@vTipo_orden,Codigo_proyecto=@vCodigo_proyecto,Ultima_facturacion=@vUltima_facturacion,Pendiente_facturar=@vPendiente_facturar," & _
        "Fecha_encuesta=@vFecha_encuesta,Usuario_encuesta=@vUsuario_encuesta,Valorizacion_encuesta=@vValorizacion_encuesta,Comentario=@vComentario," & _
        "origen=@vOrigen,estado=@vEstado,usuario_modifica=@vUsuario_modifica,fecha_modifica=@vFecha_modifica  " & _
        "WHERE empresa=@vEmpresa AND prospecto=@vProspecto AND version=@vVersion "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)

            Dim MySQLTransaction As SqlTransaction
            Dim MySQLCommand As New SqlCommand(MySql, MySQLDbconnection)

            With MySQLCommand.Parameters
                .AddWithValue("vEjercicio", cProspecto.ejercicio)
                .AddWithValue("vMes", cProspecto.mes)
                .AddWithValue("vDescripcion", cProspecto.descripcion)
                .AddWithValue("vCuenta_comercial", cProspecto.cuenta_comercial)
                .AddWithValue("vTipo_servicio", cProspecto.tipo_servicio)
                .AddWithValue("vResponsable_venta", cProspecto.responsable_venta)
                .AddWithValue("vResponsable_ejecucion", cProspecto.responsable_ejecucion)
                .AddWithValue("vProbabilidad", cProspecto.probabilidad)
                .AddWithValue("vEtapa", cProspecto.etapa)
                .AddWithValue("vFecha_cotizacion", cProspecto.fecha_cotizacion)
                .AddWithValue("vFecha_aprobacion", cProspecto.fecha_aprobacion)
                .AddWithValue("vFecha_entrega", cProspecto.fecha_entrega)
                .AddWithValue("vPeriodo_inicio", cProspecto.periodo_inicio)
                .AddWithValue("vPeriodo_cierre", cProspecto.periodo_cierre)
                .AddWithValue("vTipo_moneda", cProspecto.tipo_moneda)
                .AddWithValue("vMonto_total", cProspecto.monto_total)
                .AddWithValue("vContacto_comercial", cProspecto.contacto_comercial)
                .AddWithValue("vCosto_bienes", cProspecto.costo_bienes)
                .AddWithValue("vCosto_subcontratas", cProspecto.costo_subcontratas)
                .AddWithValue("vGastos_generales", cProspecto.gastos_generales)
                .AddWithValue("vGastos_inversion", cProspecto.gastos_inversion)
                .AddWithValue("vGastos_financiamiento", cProspecto.gastos_financiamiento)
                .AddWithValue("vMargen", cProspecto.margen)
                .AddWithValue("vTipo_orden", cProspecto.tipo_orden)
                .AddWithValue("vCodigo_proyecto", cProspecto.codigo_proyecto)
                .AddWithValue("vUltima_facturacion", cProspecto.ultima_facturacion)
                .AddWithValue("vPendiente_facturar", cProspecto.pendiente_facturar)
                .AddWithValue("vFecha_encuesta", cProspecto.fecha_encuesta)
                .AddWithValue("vUsuario_encuesta", cProspecto.usuario_encuesta)
                .AddWithValue("vComentario", cProspecto.comentario)
                .AddWithValue("vOrigen", cProspecto.origen)
                .AddWithValue("vEstado", cProspecto.estado)
                .AddWithValue("vUsuario_modifica", cProspecto.usuario_registro)
                .AddWithValue("vFecha_modifica", Now)
                .AddWithValue("vEmpresa", cProspecto.empresa)
                .AddWithValue("vProspecto", cProspecto.prospecto)
                .AddWithValue("vVersion", cProspecto.version)
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
                Return cProspecto

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

End Class
