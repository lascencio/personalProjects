using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Lidoma_WebApplication.Utils
{
    public class Procesos
    {
        static SqlConnection conexion = new SqlConnection("Data Source=3.18.124.90;Initial Catalog=Test;User ID=sa;Password=Lidoma2019!");
        public DateTime FechaNulo = System.Convert.ToDateTime("01/01/1900");

        public void ObtenerDataTableSQL(string myStringCommand, DataTable myDataTable)
        {
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(myStringCommand, conexion);
            myDataAdapter.Fill(myDataTable);
        }

        public void LLenarDataTables()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT EMPRESA,  ROW_NUMBER() OVER (ORDER BY CODIGO_ANTIGUO) AS CUENTA_COMERCIAL, SPACE(1) AS GRUPO_COMERCIAL, SPACE(1) AS TIPO_CUENTA, ");
            sql.Append("TIPO_DOCUMENTO, NRO_DOCUMENTO,RTRIM(RAZON_SOCIAL) AS RAZON_SOCIAL, RTRIM(DOMICILIO) AS DOMICILIO, INDICA_NO_DOMICILIADO='NO', TIPO_MONEDA='1', ");
            sql.Append("SPACE(1) AS CONDICION_PAGO, LINEA_CREDITO_MN, LINEA_CREDITO_ME, SPACE(1) AS LISTA_PRECIOS, AFECTO_IGV, AGENTE_RETENCION='NO', AGENTE_DETRACCION='NO', ");
            sql.Append("AGENTE_PERCEPCION='NO', INDICA_CLIENTE='SI', INDICA_PROVEEDOR='NO', SPACE(1) AS CODIGO_VENDEDOR, SPACE(1) AS CODIGO_COMPRADOR, CODIGO_ANTIGUO, ");
            sql.Append("CASE WHEN ESTADO = 'A' THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO FROM FIN.CLIENTES");

            ObtenerDataTableSQL(sql.ToString(), MyModule.MyDTCuentasComercialesDataTable);
        }
    }
}