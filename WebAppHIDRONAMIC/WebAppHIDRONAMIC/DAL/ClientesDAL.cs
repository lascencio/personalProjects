using System.Collections.Generic;
using System.Data.SqlClient;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.Utils;
using WebAppHIDRONAMIC.DS;
using System.Text;
using System.Data;
using System;
using System.Linq;
using System.Web;

namespace WebAppHIDRONAMIC.DAL
{
    public class ClientesDAL
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        PiscinasDAL piscinasDL = new PiscinasDAL();

        private PiscinasDS.Piscinas_S_DTDataTable dtPiscinasSmall = MyModule.dtPiscinasSmall;
        private PiscinasDS.PiscinasDTDataTable dtPiscinas = MyModule.dtPiscinas;
        private PiscinasDS.PiscinasInfoDTDataTable dtPiscinasInfo = MyModule.dtPiscinasInfo;


        private ClientesDS.ClientesDTDataTable dtClientes = MyModule.dtClientes;
        ClientesDS.ClientesXcuentaDTDataTable dtClientesXcuenta = HttpContext.Current.Session["dtClientesXcuenta"] as ClientesDS.ClientesXcuentaDTDataTable;

        public string CorreoPorCliente(string cliente)
        {
            conexion.cn.Open();
            string result = "";
            string sql = "SELECT EMAIL FROM WEB.CLIENTES WHERE CUENTA_COMERCIAL = '" + cliente + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr["EMAIL"].ToString();
            }
            dr.Close();
            conexion.cn.Close();
            return result;
        }

        public List<ClienteDTO> Clientes()
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            for (int i = 0; i <= dtClientes.Rows.Count - 1; i++)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.CUENTA_COMERCIAL = dtClientes[i].CUENTA_COMERCIAL;
                cliente.RAZON_SOCIAL = dtClientes[i].RAZON_SOCIAL;
                cliente.ALIAS = dtClientes[i].ALIAS;
                cliente.FECHA_REGISTRO = Utilitarios.DatetimeToDate(dtClientes[i].FECHA_REGISTRO.ToString());
                clientes.Add(cliente);
            }
            return clientes;
        }

        public List<ClienteDTO> ClientesPorRazon(string razon)
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            var clies = (from c in dtClientes
                        where c.RAZON_SOCIAL.Contains(razon)
                        orderby c.RAZON_SOCIAL
                        select new
                        {
                            CUENTA_COMERCIAL = c.CUENTA_COMERCIAL,
                            RAZON_SOCIAL = c.RAZON_SOCIAL,
                            ALIAS = c.ALIAS,
                            FECHA_REGISTRO = c.FECHA_REGISTRO,
                            EMAIL = c.EMAIL
                        }).Take(3);
            foreach (var c in clies)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.CUENTA_COMERCIAL = c.CUENTA_COMERCIAL;
                cliente.RAZON_SOCIAL = c.RAZON_SOCIAL;
                cliente.ALIAS = c.ALIAS;
                cliente.FECHA_REGISTRO = Utilitarios.DatetimeToDate(c.FECHA_REGISTRO.ToString());
                cliente.EMAIL = c.EMAIL;
                clientes.Add(cliente);
            }
            return clientes;
        }

        public ClienteDTO ClientePorCuenta(string cuenta)
        {
            ClienteDTO cliente = new ClienteDTO();
            var clies = from c in dtClientesXcuenta
                        where c.ID == cuenta
                        select new
                        {
                            CUENTA_COMERCIAL = c.ID,
                            RAZON_SOCIAL = c.RAZON_SOCIAL,
                            ALIAS = c.ALIAS,
                            DOMICILIO = c.DOMICILIO,
                            NRO_DOCUMENTO = c.NRO_DOCUMENTO,
                            TIPO_DOCUMENTO = c.TIPO_DOCUMENTO,
                            TELEFONO = c.TELEFONO,
                            CELULAR = c.CELULAR,
                            EMAIL = c.EMAIL,
                            DEPARTAMENTO = c.DEPARTAMENTO,
                            PROVINCIA = c.PROVINCIA,
                            DISTRITO = c.UBIGEO,
                            CANTIDAD_PISCINAS = c.CANTIDAD_PISCINAS
                        };
            foreach (var c in clies)
            {
                cliente.CUENTA_COMERCIAL = c.CUENTA_COMERCIAL;
                cliente.ALIAS = c.ALIAS;
                cliente.RAZON_SOCIAL = c.RAZON_SOCIAL;
                cliente.DOMICILIO = c.DOMICILIO;
                cliente.NRO_DOCUMENTO = c.NRO_DOCUMENTO;
                cliente.TIPO_DOCUMENTO = c.TIPO_DOCUMENTO;
                cliente.TELEFONO = c.TELEFONO;
                cliente.CELULAR = c.CELULAR;
                cliente.EMAIL = c.EMAIL;
                cliente.DEPARTAMENTO = c.DEPARTAMENTO;
                cliente.PROVINCIA = c.PROVINCIA;
                cliente.DISTRITO = c.DISTRITO;
                cliente.CANTIDAD_PISCINAS = int.Parse(c.CANTIDAD_PISCINAS.ToString());

                if (cliente.CANTIDAD_PISCINAS == 1)
                {
                    PiscinaDTO p = PiscinaPorCliente(cliente.CUENTA_COMERCIAL);
                    cliente.PISCINA = p.PISCINA;
                    cliente.VOLUMEN_PISCINA = p.s_VOLUMEN;
                    cliente.PROFUNDIDAD_PISCINA = p.s_PROFUNDIDAD;
                    cliente.ANCHO_PISCINA = p.s_ANCHO;
                    cliente.LARGO_PISCINA = p.s_LARGO;
                    cliente.TIPO_PISCINA = Utilitarios.HallarTipoPiscina(p.s_TIPO_PISCINA);
                    cliente.FORMA_PISCINA = p.s_FORMA_PISCINA;
                };
            }
            return cliente;
        }

        public PiscinaDTO PiscinaPorCliente(string cliente)
        {
            conexion.cn.Open();
            PiscinaDTO piscina = null;
            string sql = "SELECT * FROM  [COM].[INFO_PISCINAS] WHERE CUENTA_COMERCIAL = '" + cliente + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                piscina = new PiscinaDTO();
                piscina.PISCINA = dr["PISCINA"].ToString();
                piscina.FRECUENCIA = dr["FRECUENCIA_MANTENIMIENTO"].ToString();
                piscina.TIPO_PISCINA = dr["TIPO_PISCINA"].ToString();
                piscina.FORMA_PISCINA = dr["FORMA_PISCINA"].ToString();
                piscina.UBICACION = dr["UBICACION"].ToString();
                piscina.LARGO = decimal.Parse(dr["LARGO"].ToString());
                piscina.ANCHO = decimal.Parse(dr["ANCHO"].ToString());
                piscina.PROFUNDIDAD = decimal.Parse(dr["PROFUNDIDAD"].ToString());
                piscina.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());

                piscina.s_LARGO = dr["LARGO"].ToString();
                piscina.s_ANCHO = dr["ANCHO"].ToString();
                piscina.s_PROFUNDIDAD = dr["PROFUNDIDAD"].ToString();
                piscina.s_VOLUMEN = dr["VOLUMEN"].ToString();
            }

            conexion.cn.Close();
            return piscina;
        }

        public ClienteDTO Auditoria(string cuenta_comercial)
        {
            conexion.cn.Open();
            ClienteDTO cliente = null;
            StringBuilder sql = new StringBuilder("SELECT USUARIO_MODIFICA, FECHA_MODIFICA ");
            sql.Append("FROM COM.CUENTAS_COMERCIALES WHERE CUENTA_COMERCIAL ='" + cuenta_comercial + "' ");
            string msg;

            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente = new ClienteDTO();
                    if (String.IsNullOrEmpty(dr[0].ToString()))
                    {
                        cliente.USUARIO_MODIFICA = "";
                        cliente.FECHA_MODIFICA = "";
                    }
                    else
                    {
                        cliente.USUARIO_MODIFICA = dr[0].ToString();
                        cliente.FECHA_MODIFICA = dr[1].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            {
                msg = e.Message;
                string res = msg;
            }
            finally { conexion.cn.Close(); }
            return cliente;
        }

        public string Registrar(ClienteDTO cliente, string usuario, string empresa)
        {
            StringBuilder result = new StringBuilder();
            conexion.cn.Open();
            cliente.CUENTA_COMERCIAL = CodigoCliente();
            cliente.USUARIO_REGISTRO = usuario;
            //long piscina = CodigoPiscina();

            SqlTransaction tx = conexion.cn.BeginTransaction();

            StringBuilder sqlCliente = new StringBuilder("INSERT INTO COM.CUENTAS_COMERCIALES ");
            sqlCliente.Append("(EMPRESA,CUENTA_COMERCIAL,TIPO_DOCUMENTO,NRO_DOCUMENTO,RAZON_SOCIAL,ALIAS,INDICA_POST_VENTA,DEPARTAMENTO,PROVINCIA,UBIGEO,DOMICILIO,TELEFONO,CELULAR,EMAIL,INDICA_PISCINA,USUARIO_REGISTRO) ");
            sqlCliente.Append("VALUES ");
            sqlCliente.Append("(@vEMPRESA,@vCUENTA_COMERCIAL,@vTIPO_DOCUMENTO,@vNRO_DOCUMENTO,@vRAZON_SOCIAL,@vALIAS,'SI',@vDEPARTAMENTO,@vPROVINCIA,@vUBIGEO,@vDOMICILIO,@vTELEFONO,@vCELULAR,@vEMAIL,@vINDICA_PISCINA,@vUSUARIO_REGISTRO)");

            StringBuilder sqlPiscina = new StringBuilder("INSERT INTO COM.PISCINAS ");
            sqlPiscina.Append("(EMPRESA,CUENTA_COMERCIAL, PISCINA, UBICACION, TIPO_PISCINA, LARGO, ANCHO, PROFUNDIDAD, VOLUMEN, FRECUENCIA_MANTENIMIENTO, USUARIO_REGISTRO) ");
            sqlPiscina.Append("VALUES ");
            sqlPiscina.Append("(@vEMPRESA, @vCUENTA_COMERCIAL, @vPISCINA, @vUBICACION, @vTIPO_PISCINA, @vLARGO, @vANCHO, @vPROFUNDIDAD, @vVOLUMEN, @vFRECUENCIA, @vUSUARIO_REGISTRO)");

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlCliente.ToString(), conexion.cn, tx))
                {
                    cmd.Parameters.AddWithValue("vEMPRESA", empresa);
                    cmd.Parameters.AddWithValue("vCUENTA_COMERCIAL", cliente.CUENTA_COMERCIAL);
                    cmd.Parameters.AddWithValue("vTIPO_DOCUMENTO", cliente.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("vNRO_DOCUMENTO", cliente.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("vRAZON_SOCIAL", cliente.RAZON_SOCIAL.ToUpper());
                    cmd.Parameters.AddWithValue("vALIAS", cliente.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("vDEPARTAMENTO", cliente.DEPARTAMENTO);
                    cmd.Parameters.AddWithValue("vPROVINCIA", cliente.PROVINCIA);
                    cmd.Parameters.AddWithValue("vUBIGEO", cliente.DISTRITO);
                    cmd.Parameters.AddWithValue("vDOMICILIO", cliente.DOMICILIO);
                    cmd.Parameters.AddWithValue("vTELEFONO", cliente.TELEFONO);
                    cmd.Parameters.AddWithValue("vCELULAR", cliente.CELULAR);
                    cmd.Parameters.AddWithValue("vEMAIL", cliente.EMAIL);
                    cmd.Parameters.AddWithValue("vINDICA_PISCINA", cliente.INDICA_PISCINA);
                    cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", cliente.USUARIO_REGISTRO);
                    cmd.ExecuteNonQuery();
                }
                //if (dtPiscinas.Rows.Count != 0)
                //{
                //    for (int i = 0; i <= dtPiscinas.Rows.Count - 1; i++)
                //    {
                //        long secuencia = piscina += 1;
                //        using (SqlCommand cmd = new SqlCommand(sqlPiscina.ToString(), conexion.cn, tx))
                //        {
                //            cmd.Parameters.Clear();
                //            cmd.Parameters.AddWithValue("vEMPRESA", empresa);
                //            cmd.Parameters.AddWithValue("vCUENTA_COMERCIAL", cliente.CUENTA_COMERCIAL);
                //            cmd.Parameters.AddWithValue("vPISCINA", Utilitarios.CorrelativoPiscina(secuencia));
                //            cmd.Parameters.AddWithValue("vUBICACION", dtPiscinas[i].UBICACION);
                //            cmd.Parameters.AddWithValue("vTIPO_PISCINA", dtPiscinas[i].TIPO_PISCINA);
                //            cmd.Parameters.AddWithValue("vLARGO", dtPiscinas[i].LARGO);
                //            cmd.Parameters.AddWithValue("vANCHO", dtPiscinas[i].ANCHO);
                //            cmd.Parameters.AddWithValue("vPROFUNDIDAD", dtPiscinas[i].PROFUNDIDAD);
                //            cmd.Parameters.AddWithValue("vVOLUMEN", dtPiscinas[i].VOLUMEN);
                //            cmd.Parameters.AddWithValue("vFRECUENCIA", dtPiscinas[i].FRECUENCIA_MANTENIMIENTO);
                //            cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", cliente.USUARIO_REGISTRO);
                //            cmd.ExecuteNonQuery();
                //        }
                //    }
                //}
                tx.Commit();

                UpdateDTClientes();

                result.Append("success");
            }
            catch (Exception e)
            {
                result.Append(e.Message);
                tx.Rollback();
            }
            finally
            {
                conexion.cn.Close();
            }
            return result.ToString();
        }

        private void UpdateDTClientes()
        {
            //ACTUALIZO MI DATATABLE CLIENTES
            MyModule.dtClientes.Clear();
            string clientes = "SELECT * FROM COM.CLIENTES ORDER BY RAZON_SOCIAL";
            Utilitarios.ObtenerDataTableSQL(clientes, MyModule.dtClientes);

            MyModule.dtClientesXcuenta.Clear();
            string clientesXcuenta = "SELECT * FROM COM.CLIENTE_POR_CUENTA";
            Utilitarios.ObtenerDataTableSQL(clientesXcuenta, MyModule.dtClientesXcuenta);
        }

        public string Editar(ClienteDTO cliente, string usuarioModifica)
        {
            StringBuilder result = new StringBuilder();
            conexion.cn.Open();

            StringBuilder sql = new StringBuilder("UPDATE COM.CUENTAS_COMERCIALES ");
            sql.Append("SET TIPO_DOCUMENTO = @vTIPO_DOCUMENTO,NRO_DOCUMENTO = @vNRO_DOCUMENTO,RAZON_SOCIAL = @vRAZON_SOCIAL,ALIAS = @vALIAS, ");
            sql.Append("DEPARTAMENTO = @vDEPARTAMENTO,PROVINCIA = @vPROVINCIA,UBIGEO = @vUBIGEO,DOMICILIO = @vDOMICILIO,TELEFONO = @vTELEFONO, ");
            sql.Append("CELULAR = @vCELULAR,EMAIL = @vEMAIL,USUARIO_MODIFICA = @vUSUARIO_MODIFICA,FECHA_MODIFICA = GETDATE() ");
            sql.Append("WHERE CUENTA_COMERCIAL = @vCUENTA_COMERCIAL ");

            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);
                cmd.Parameters.AddWithValue("vCUENTA_COMERCIAL", cliente.CUENTA_COMERCIAL);
                cmd.Parameters.AddWithValue("vTIPO_DOCUMENTO", cliente.TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("vNRO_DOCUMENTO", cliente.NRO_DOCUMENTO);
                cmd.Parameters.AddWithValue("vRAZON_SOCIAL", cliente.ALIAS.ToUpper());
                cmd.Parameters.AddWithValue("vALIAS", cliente.ALIAS);
                cmd.Parameters.AddWithValue("vDEPARTAMENTO", cliente.DEPARTAMENTO);
                cmd.Parameters.AddWithValue("vPROVINCIA", cliente.PROVINCIA);
                cmd.Parameters.AddWithValue("vUBIGEO", cliente.DISTRITO);
                cmd.Parameters.AddWithValue("vDOMICILIO", cliente.DOMICILIO);
                cmd.Parameters.AddWithValue("vTELEFONO", cliente.TELEFONO);
                cmd.Parameters.AddWithValue("vCELULAR", cliente.CELULAR);
                cmd.Parameters.AddWithValue("vEMAIL", cliente.EMAIL);
                cmd.Parameters.AddWithValue("vUSUARIO_MODIFICA", usuarioModifica);
                cmd.ExecuteNonQuery();

                UpdateDTClientes();

                result.Append("success");
            }
            catch (Exception e)
            {
                result.Append(e.Message);
            }
            finally
            {
                conexion.cn.Close();
            }
            return result.ToString();
        }

        private string CodigoCliente()
        {
            string sql = "select COM.FUNC_CODIGO_CUENTA_COMERCIAL()";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            string codigoNuevo = cmd.ExecuteScalar().ToString();
            return codigoNuevo;
        }

        //RETORNA EL ÚLTIMO CÓDIGO CORRELATIVO DE PISCINA RESTADO EN UNO.
        private long CodigoPiscina()
        {
            string sql = "select COM.FUNC_CODIGO_PISCINA()";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            string codigoNuevo = cmd.ExecuteScalar().ToString();
            long idPiscina = long.Parse(Utilitarios.SubStrings(codigoNuevo, 1, 7));
            return idPiscina - 1;
        }

        //RETORNA EL VOLUMEN DE UNA PISCINA
    }
}