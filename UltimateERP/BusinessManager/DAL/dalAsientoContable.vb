Imports System.Data.SqlClient

Public Class dalAsientoContable
    Private Shared MySqlString As String
    Private Shared MySQLCommand As SqlCommand

    Public Shared Function ObtenerFecha(ByVal pFecha As Date, ByVal pPeriodo As Long) As Date
        Dim MyFecha As Date

        MySqlString = "SELECT UTI.EVAL_FECHA_ASIENTO(@vFecha,@vPeriodo)"

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vFecha", pFecha)
            MySQLCommand.Parameters.AddWithValue("vPeriodo", pPeriodo)
            MySQLDbconnection.Open()

            MyFecha = MySQLCommand.ExecuteScalar
        End Using
        Return MyFecha
    End Function

    Public Shared Function ObtenerTipoCambio(ByVal pEjercicio As String, ByVal pMes As String, ByVal pDia As String, ByVal pTipo As String) As Decimal
        Dim MyTipoCambio As Decimal = 0

        MySqlString = "SELECT ISNULL(" & pTipo & ",0) AS TIPO_CAMBIO FROM GEN.TIPO_CAMBIO WHERE EJERCICIO=@vEjercicio AND MES=@vMes AND DIA=@vDia "

        Using MySQLDbconnection As New SqlConnection(myConnectionStringSQL_Repository)
            MySQLCommand = New SqlCommand(MySqlString, MySQLDbconnection)
            MySQLCommand.Connection = MySQLDbconnection
            MySQLCommand.CommandType = CommandType.Text
            MySQLCommand.Parameters.AddWithValue("vEjercicio", pEjercicio)
            MySQLCommand.Parameters.AddWithValue("vMes", pMes)
            MySQLCommand.Parameters.AddWithValue("vDia", pDia)
            MySQLDbconnection.Open()

            MyTipoCambio = MySQLCommand.ExecuteScalar
        End Using
        If MyTipoCambio = 0 Then MyTipoCambio = 1
        Return MyTipoCambio
    End Function



End Class
