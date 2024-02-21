using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Infraestructura.Data.Conexion
{
    public class ConexionSQLServer
    {
        SqlConnection conexion = new SqlConnection("@server = LADY; database=Repository_HIDRONAMIC;uid=sa;pwd=Terminator1");

        public SqlConnection cn
        {
            get { return conexion; }
        }
    }
}
