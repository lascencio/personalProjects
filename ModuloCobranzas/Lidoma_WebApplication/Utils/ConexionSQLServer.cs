using System.Data.SqlClient;
using System.Configuration;

namespace Lidoma_WebApplication.Utils
{
    public class ConexionSQLServer
    {
        //MyModule mm = new MyModule();
        SqlConnection conexion = new SqlConnection("Data Source=3.18.124.90;Initial Catalog=Test;User ID=sa;Password=Lidoma2019!");

        public SqlConnection cn
        {
            get { return conexion; }
        }
    }
}