using System;
using WebAppHIDRONAMIC.Entities;
using System.Data.SqlClient;
using WebAppHIDRONAMIC.Utils;
using System.Text;

namespace WebAppHIDRONAMIC.DAL
{
    public class UsuarioDAL
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        MyModule myModule = new MyModule();

        public void LimpiarDataTables()
        {
            MyModule.dtConstanciasXcliente.Clear();

            //MyModule.dtPiscinasSmall.Clear();
            //MyModule.dtPiscinas.Clear();
            //MyModule.dtPiscinasInfo.Clear();

            MyModule.dtClientesXcuenta.Clear();
            MyModule.dtClientes.Clear();

            MyModule.dtProductos.Clear();
            MyModule.dtServicios.Clear();
            MyModule.dtDepartamentos.Clear();
            MyModule.dtTiposDoc.Clear();
            MyModule.dtTiposPisc.Clear();
            MyModule.dtFrecuenciasPisc.Clear();
            MyModule.dtDistritos.Clear();
            MyModule.dtProvincias.Clear();
            MyModule.dtProd_Serv.Clear();
            MyModule.dtTiposPiscProf.Clear();
            MyModule.dtFormPiscinas.Clear();
            MyModule.dtTipoProformas.Clear();

            MyModule.dtFamilias.Clear();
            MyModule.dtItemsProforma.Clear();
            MyModule.dtItemsProforma.Clear(); 
        }

        public string LLenarDataTables()
        {
            string result = "";

            LimpiarDataTables();

            try
            {
                //string piscinasSm = "SELECT CUENTA_COMERCIAL, PISCINA, TIPO_PISCINA FROM COM.INFO_PISCINAS ";
                //Utilitarios.ObtenerDataTableSQL(piscinasSm, MyModule.dtPiscinasSmall);

                ////ESTA PISCINA NO LA SUELO USAR
                //string piscinas = "SELECT EMPRESA, CUENTA_COMERCIAL, PISCINA, UBICACION, TIPO_PISCINA, LARGO, ANCHO, PROFUNDIDAD, VOLUMEN, FRECUENCIA_MANTENIMIENTO, USUARIO_REGISTRO, FECHA_REGISTRO FROM COM.PISCINAS";
                //Utilitarios.ObtenerDataTableSQL(piscinas, MyModule.dtPiscinas);

                //string piscinasInfo = "SELECT * FROM COM.INFO_PISCINAS";
                //Utilitarios.ObtenerDataTableSQL(piscinasInfo, MyModule.dtPiscinasInfo);

                string clientesXcuenta = "SELECT * FROM COM.CLIENTE_POR_CUENTA";
                Utilitarios.ObtenerDataTableSQL(clientesXcuenta, MyModule.dtClientesXcuenta);

                string clientes = "SELECT * FROM WEB.CLIENTES ORDER BY RAZON_SOCIAL";
                Utilitarios.ObtenerDataTableSQL(clientes, MyModule.dtClientes);

                string productos = "[GEN].[SERVICIOS_PRODUCTOS]";
                Utilitarios.ObtenerDT_Servicios(productos, MyModule.dtProductos,"P");

                string servicios = "[GEN].[SERVICIOS_PRODUCTOS]";
                Utilitarios.ObtenerDT_Servicios(servicios, MyModule.dtServicios, "S");

                string departamentos = "SELECT * FROM GEN.TABLA_UBIGEO_REGION ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(departamentos, MyModule.dtDepartamentos);

                string tiposDoc = "SELECT * FROM GEN.TIPOS_DOCUMENTO ORDER BY CODIGO";
                Utilitarios.ObtenerDataTableSQL(tiposDoc, MyModule.dtTiposDoc);

                string tiposPisc = "SELECT * FROM GEN.TIPOS_PISCINA ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(tiposPisc, MyModule.dtTiposPisc);

                string frecuenciasPisc = "SELECT * FROM GEN.FRECUENCIAS_PISCINA ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(frecuenciasPisc, MyModule.dtFrecuenciasPisc);

                string distritos = "SELECT * FROM [GEN].[TABLA_UBIGEO] ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(distritos, MyModule.dtDistritos);

                string provincias = "SELECT * FROM GEN.TABLA_UBIGEO_PROVINCIA ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(provincias, MyModule.dtProvincias);

                string productosServicios = "SELECT SERVICIO + '|' + DESCRIPCION AS MIXED_COLUMN, DESCRIPCION, PRECIO, SERVICIO FROM MAN.SERVICIOS";
                Utilitarios.ObtenerDataTableSQL(productosServicios, MyModule.dtProd_Serv);

                string familias = "SELECT * FROM [GEN].[TABLA_FAMILIA]";
                Utilitarios.ObtenerDataTableSQL(familias, MyModule.dtFamilias);

                string itemsProforma = "SELECT * FROM [GEN].[TABLA_PRODUCTOS]";
                Utilitarios.ObtenerDataTableSQL(itemsProforma, MyModule.dtItemsProforma);

                string tiposProformas = "SELECT * FROM [GEN].[TABLA_CLASE] WHERE CODIGO NOT IN ('000', '265','272') ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(tiposProformas, MyModule.dtTipoProformas);

                string tiposPiscProf = "SELECT * FROM [GEN].[TABLA_TIPOS_PISCINA_PROF] ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(tiposPiscProf, MyModule.dtTiposPiscProf);

                string formasPiscina = "SELECT * FROM [GEN].[TABLA_FORMAS_PISCINA] ORDER BY DESCRIPCION";
                Utilitarios.ObtenerDataTableSQL(formasPiscina, MyModule.dtFormPiscinas);


                result = "SUCCESS";
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public UsuarioDTO Loguearse(string user, string clave)
        {
            UsuarioDTO usuario = null;
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT CODIGO_ITEM AS ID, NOMBRE_CORTO, NOMBRE_LARGO ,TEXTO_01 AS CLAVE,TEXTO_02 AS EMAIL,EMPRESA,ESTADO,TEXTO_04 AS PERFIL, TEXTO_05 AS USUARIO ");
            sql.Append("FROM GEN.TABLAS_DETALLE WHERE CODIGO_TABLA = 'USUARIOS' AND EMPRESA = '001' AND TEXTO_05 = @vUSUARIO AND TEXTO_01 = @vCLAVE");

            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);
            cmd.Parameters.AddWithValue("vUSUARIO", user);
            cmd.Parameters.AddWithValue("vCLAVE", clave);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new UsuarioDTO();
                usuario.DNI = dr[0].ToString();
                usuario.NOMBRE_CORTO = dr[1].ToString();
                usuario.NOMBRE_LARGO = dr[2].ToString();
                usuario.CLAVE = dr[3].ToString();
                usuario.EMAIL = dr[4].ToString();
                usuario.EMPRESA = dr[5].ToString();
                usuario.ESTADO = dr[6].ToString();
                usuario.PERFIL = dr[7].ToString();
                usuario.USUARIO = dr[8].ToString();
            }
            dr.Close();
            conexion.cn.Close();
            return usuario;
        }

        public void ValidarTipoCambio()
        {
            conexion.cn.Open();
            string sql = "SELECT VENTA FROM GEN.TIPO_CAMBIO WHERE (DIA + MES + EJERCICIO) ='" + DateTime.Today.ToString("ddMMyyyy") + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Utilitarios.TIPO_CAMBIO = decimal.Parse(dr[0].ToString());
            }
            dr.Close();
            conexion.cn.Close();
        }

    }
}