using System.Data.SqlClient;
using WebAppHIDRONAMIC;
using System.Configuration;


namespace WebAppHIDRONAMIC.Utils
{
    public class ConexionSQLServer
    {
        MyModule mm = new MyModule();
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQLRepositoryD"].ConnectionString);

        public SqlConnection cn
        {
            get { return conexion; }
        }
    }
}