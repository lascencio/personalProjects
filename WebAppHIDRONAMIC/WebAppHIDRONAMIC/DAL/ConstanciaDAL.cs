using System;
using System.Collections.Generic;
using WebAppHIDRONAMIC.Utils;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.DS;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using WebAppHIDRONAMIC.Reports;
using System.Web;

namespace WebAppHIDRONAMIC.DAL
{
    public class ConstanciaDAL
    {
        ConstanciaRPT constanciaRPT = new ConstanciaRPT();
        ConexionSQLServer conexion = new ConexionSQLServer();
        EmailDAL emailDL = new EmailDAL();

        ConstanciasDS.ConstanciaDetallesDTDataTable dtConstanciaDet = HttpContext.Current.Session["dtConstanciaDet"] as ConstanciasDS.ConstanciaDetallesDTDataTable;
        ConstanciasDS.ConstanciasPorClienteDTDataTable dtConstanciasXcliente = HttpContext.Current.Session["dtConstanciasXcliente"] as ConstanciasDS.ConstanciasPorClienteDTDataTable;
        ConstanciasDS.ConstanciasDTDataTable dtConstanciaCab = HttpContext.Current.Session["dtConstanciaCab"] as ConstanciasDS.ConstanciasDTDataTable;
        private ProductosDS.ServiciosDTDataTable dtServicios = MyModule.dtServicios;
        private ProductosDS.Productos_ServiciosDTDataTable dtProd_Serv = MyModule.dtProd_Serv;

        private string CodigoCorrelativo()
        {
            string sql = "SELECT MAN.FUNC_CODIGO_CONSTANCIA()";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            string codigoNuevo = cmd.ExecuteScalar().ToString();
            return codigoNuevo;
        }

        public List<ConstanciaDTO> ConstanciasPorAnio(string anio)
        {
            List<ConstanciaDTO> constancias = new List<ConstanciaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_CONSTANCIAS] ");
            sql.Append("WHERE YEAR(FECHA_CONSULTA) = '" + anio + "' ");
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ConstanciaDTO constancia = new ConstanciaDTO();
                constancia.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                constancia.FECHA_MODIFICA = Utilitarios.FormatoHora(dr["HORA"].ToString());
                constancia.CONSTANCIA = dr["CONSTANCIA"].ToString();
                constancia.CUENTA_COMERCIAL = dr["RAZON_SOCIAL"].ToString().ToUpper();
                constancia.COMENTARIO = dr["COMENTARIO"].ToString();
                constancia.ESTADO = dr["ESTADO"].ToString();
                constancia.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                constancias.Add(constancia);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtConstanciasXcliente(constancias);

            return constancias;
        }
        public List<ConstanciaDTO> ConstanciasPorCliente(string cliente)
        {
            List<ConstanciaDTO> constancias = new List<ConstanciaDTO>();
            var cons = from c in dtConstanciasXcliente
                       where c.RAZON_SOCIAL.Contains(cliente)
                       select new
                       {
                           RAZON_SOCIAL = c.RAZON_SOCIAL,
                           CONSTANCIA = c.CONSTANCIA,
                           COMENTARIO = c.COMENTARIO,
                           FECHA = c.FECHA,
                           HORA = c.HORA,
                           ESTADO = c.ESTADO,
                           USUARIO_REGISTRO = c.USUARIO_REGISTRO
                       };
            foreach (var c in cons)
            {
                ConstanciaDTO constancia = new ConstanciaDTO();
                constancia.CUENTA_COMERCIAL = c.RAZON_SOCIAL;
                constancia.ESTADO = c.ESTADO;
                constancia.CONSTANCIA = c.CONSTANCIA;
                constancia.FECHA_MODIFICA = c.HORA;
                constancia.FECHA_REGISTRO = c.FECHA;
                constancia.USUARIO_REGISTRO = c.USUARIO_REGISTRO;
                constancias.Add(constancia);
            }
            return constancias;
        }
        public List<ConstanciaDTO> ConstanciasPorMes(string mes)
        {
            List<ConstanciaDTO> constancias = new List<ConstanciaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_CONSTANCIAS] ");
            if (!String.IsNullOrEmpty(mes))
            {
                sql.Append("WHERE MONTH(FECHA_CONSULTA) = '" + mes + "' ");
            }
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ConstanciaDTO constancia = new ConstanciaDTO();
                constancia.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                constancia.FECHA_MODIFICA = Utilitarios.FormatoHora(dr["HORA"].ToString());
                constancia.CONSTANCIA = dr["CONSTANCIA"].ToString();
                constancia.CUENTA_COMERCIAL = dr["RAZON_SOCIAL"].ToString().ToUpper();
                constancia.COMENTARIO = dr["COMENTARIO"].ToString();
                constancia.ESTADO = dr["ESTADO"].ToString();
                constancia.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                constancias.Add(constancia);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtConstanciasXcliente(constancias);

            return constancias;
        }
        public List<ConstanciaDTO> ConstanciasPorFechas(string fecha1, string fecha2)
        {
            List<ConstanciaDTO> constancias = new List<ConstanciaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_CONSTANCIAS] ");
            sql.Append("WHERE FORMAT(FECHA_CONSULTA, 'yyyy/MM/dd')BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' ");
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ConstanciaDTO constancia = new ConstanciaDTO();
                constancia.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                constancia.FECHA_MODIFICA = Utilitarios.FormatoHora(dr["HORA"].ToString());
                constancia.CONSTANCIA = dr["CONSTANCIA"].ToString();
                constancia.CUENTA_COMERCIAL = dr["RAZON_SOCIAL"].ToString().ToUpper();
                constancia.COMENTARIO = dr["COMENTARIO"].ToString();
                constancia.ESTADO = dr["ESTADO"].ToString();
                constancia.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                constancias.Add(constancia);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtConstanciasXcliente(constancias);

            return constancias;
        }
        public string EnviarConstanciaEmail(string constancia)
        {
            string result = "";
            try
            {
                emailDL.EnviarConstancia(constancia);
                result = "SUCCESS";
            }
            catch (Exception x)
            {
                result = x.Message;
            }
            finally
            {
                dtConstanciaDet.Clear();
                dtConstanciaCab.Clear();
            }
            return result;
        }
        public ConstanciaDTO EliminarConstancia(string constancia)
        {
            string result = "";
            ConstanciaDTO consta = new ConstanciaDTO();
            conexion.cn.Open();
            SqlTransaction tx = conexion.cn.BeginTransaction();
            string sqlCons = "DELETE FROM MAN.CONSTANCIAS_DETALLE WHERE CONSTANCIA LIKE '" + constancia + "'";
            string sqlDet = "DELETE FROM MAN.CONSTANCIAS WHERE CONSTANCIA LIKE '" + constancia + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlDet.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlCons.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                consta = PoblarConstanciaDT();
                tx.Commit();
                result = "SUCCESS";
            }
            catch (Exception e)
            {
                tx.Rollback();
                result = e.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return consta;
        }

        public List<ConstanciaDTO> Eliminar(string constancia)
        {
            conexion.cn.Open();
            SqlTransaction tx = conexion.cn.BeginTransaction();
            string sqlCons = "DELETE FROM MAN.CONSTANCIAS_DETALLE WHERE CONSTANCIA LIKE '" + constancia + "'";
            string sqlDet = "DELETE FROM MAN.CONSTANCIAS WHERE CONSTANCIA LIKE '" + constancia + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlDet.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlCons.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
            finally
            {
                conexion.cn.Close();
            }
            return ConstanciasPorMes("");
        }

        public List<ConstanciaDetalleDTO> EliminarDetalle(string servicio)
        {
            for (int i = 0; i <= dtConstanciaDet.Rows.Count - 1; i++)
            {
                DataRow dr = dtConstanciaDet.Rows[i];
                if (dr["SERVICIO"].ToString() == servicio)
                {
                    dr.Delete();
                }
            }
            return ListarDSDetalle();
        }

        public List<ConstanciaDetalleDTO> GrabarDetalles(string servicio, string cantidad, string descripcionServicio, string tipo)
        {
            int cant = int.Parse(cantidad);
            bool nuevaLinea = true;
            conexion.cn.Open();
            try
            {
                if (dtConstanciaDet.Rows.Count != 0)
                {
                    for (int i = 0; i <= dtConstanciaDet.Rows.Count - 1; i++)
                    {
                        if (dtConstanciaDet[i].SERVICIO.Equals(servicio))
                        {
                            dtConstanciaDet[i].DESCRIPCION_SERVICIO = descripcionServicio;
                            dtConstanciaDet[i].CANTIDAD = (byte)cant;
                            dtConstanciaDet[i].VALOR_UNITARIO = PrecioServicio(servicio);
                            dtConstanciaDet[i].VALOR_TOTAL = cant * PrecioServicio(servicio);
                            dtConstanciaDet[i].TIPO = tipo;
                            nuevaLinea = false;
                        }
                    }
                }
                if (nuevaLinea == true)
                {
                    dtConstanciaDet.Rows.Add("", "", servicio, (Int16)cant, PrecioServicio(servicio), cant * PrecioServicio(servicio), "A", "SISTEMAS", new DateTime(2018, 02, 28), null, null, descripcionServicio, tipo);
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return ListarDSDetalle();
        }

        public string GrabarConstancia(ConstanciaDTO constancia, string usuario, string empresa)
        {
            StringBuilder result = new StringBuilder();
            dtConstanciaCab.Clear();
            conexion.cn.Open();
            constancia.CONSTANCIA = CodigoCorrelativo();
            constancia.EMPRESA = empresa;
            constancia.USUARIO_REGISTRO = usuario;
            SqlTransaction tx = conexion.cn.BeginTransaction();
            //Utilitarios.DeletePDF(constancia.CONSTANCIA);
            try
            {
                DeletePDF(constancia.CONSTANCIA);
                StringBuilder sqlCabecera = new StringBuilder("INSERT INTO MAN.CONSTANCIAS ");
                sqlCabecera.Append("(EMPRESA,CONSTANCIA,CUENTA_COMERCIAL,PISCINA,COMENTARIO, VALOR_TOTAL,NIVEL_CLORO,NIVEL_PH,INDICA_CLIENTE,INDICA_CONDICION, ");
                sqlCabecera.Append("INDICA_PISCINA,INDICA_SAUNA,INDICA_PRESION,INDICA_INCENDIO,INDICA_FIRMA, USUARIO_REGISTRO,REFERENCIA_NOMBRE,REFERENCIA_DNI) ");
                sqlCabecera.Append("VALUES ");
                sqlCabecera.Append("(@vEMPRESA,@vCONSTANCIA,@vCUENTA_COMERCIAL,@vPISCINA,@vCOMENTARIO,@vVALOR_TOTAL,@vNIVEL_CLORO,@vNIVEL_PH,@vINDICA_CLIENTE, ");
                sqlCabecera.Append("@vINDICA_CONDICION,@vINDICA_PISCINA,@vINDICA_SAUNA,@vINDICA_PRESION,@vINDICA_INCENDIO,@vINDICA_FIRMA,@vUSUARIO_REGISTRO,@vREFERENCIA_NOMBRE,@vREFERENCIA_DNI)");

                StringBuilder sqlDetalle = new StringBuilder("INSERT INTO MAN.CONSTANCIAS_DETALLE ");
                sqlDetalle.Append("(EMPRESA,CONSTANCIA,SERVICIO,CANTIDAD,VALOR_UNITARIO,VALOR_TOTAL,USUARIO_REGISTRO) ");
                sqlDetalle.Append("VALUES ");
                sqlDetalle.Append("(@vEMPRESA,@vCONSTANCIA,@vSERVICIO,@vCANTIDAD,@vVALOR_UNITARIO,@vVALOR_TOTAL,@vUSUARIO_REGISTRO)");


                using (SqlCommand cmd = new SqlCommand(sqlCabecera.ToString(), conexion.cn, tx))
                {
                    cmd.Parameters.AddWithValue("vEMPRESA", constancia.EMPRESA);
                    cmd.Parameters.AddWithValue("vCONSTANCIA", constancia.CONSTANCIA);
                    cmd.Parameters.AddWithValue("vCUENTA_COMERCIAL", constancia.CUENTA_COMERCIAL);
                    cmd.Parameters.AddWithValue("vPISCINA", constancia.PISCINA);
                    cmd.Parameters.AddWithValue("vCOMENTARIO", constancia.COMENTARIO.Trim());
                    cmd.Parameters.AddWithValue("vVALOR_TOTAL", ValorTotalConstancia());
                    cmd.Parameters.AddWithValue("vNIVEL_CLORO", constancia.NIVEL_CLORO);
                    cmd.Parameters.AddWithValue("vNIVEL_PH", constancia.NIVEL_PH);
                    cmd.Parameters.AddWithValue("vINDICA_CLIENTE", constancia.INDICA_CLIENTE);
                    cmd.Parameters.AddWithValue("vINDICA_CONDICION", constancia.INDICA_CONDICION);
                    cmd.Parameters.AddWithValue("vINDICA_PISCINA", constancia.INDICA_PISCINA);
                    cmd.Parameters.AddWithValue("vINDICA_SAUNA", constancia.INDICA_SAUNA);
                    cmd.Parameters.AddWithValue("vINDICA_PRESION", constancia.INDICA_PRESION);
                    cmd.Parameters.AddWithValue("vINDICA_INCENDIO", constancia.INDICA_INCENDIO);
                    cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", constancia.USUARIO_REGISTRO);
                    cmd.Parameters.AddWithValue("vREFERENCIA_NOMBRE", constancia.REFERENCIA_NOMBRE);
                    cmd.Parameters.AddWithValue("vREFERENCIA_DNI", constancia.REFERENCIA_DNI);
                    if (constancia.INDICA_FIRMA.Equals("SI"))
                        cmd.Parameters.AddWithValue("vINDICA_FIRMA", "SI");
                    else
                        cmd.Parameters.AddWithValue("vINDICA_FIRMA", "NO");
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlDetalle.ToString(), conexion.cn, tx))
                {
                    for (int i = 0; i <= dtConstanciaDet.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("vEMPRESA", constancia.EMPRESA);
                        cmd.Parameters.AddWithValue("vCONSTANCIA", constancia.CONSTANCIA);
                        cmd.Parameters.AddWithValue("vSERVICIO", dtConstanciaDet[i].SERVICIO);
                        cmd.Parameters.AddWithValue("vCANTIDAD", dtConstanciaDet[i].CANTIDAD);
                        cmd.Parameters.AddWithValue("vVALOR_UNITARIO", dtConstanciaDet[i].VALOR_UNITARIO);
                        cmd.Parameters.AddWithValue("vVALOR_TOTAL", dtConstanciaDet[i].VALOR_TOTAL);
                        cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", constancia.USUARIO_REGISTRO);
                        cmd.ExecuteNonQuery();
                    }
                }
                dtConstanciaCab.Rows.Add(constancia.EMPRESA, constancia.CONSTANCIA, constancia.CUENTA_COMERCIAL, constancia.PISCINA, constancia.COMENTARIO, constancia.ESTADO,
                    constancia.VALOR_TOTAL, constancia.NIVEL_CLORO, constancia.NIVEL_PH, constancia.INDICA_CONDICION, constancia.INDICA_CLIENTE,
                    constancia.INDICA_PISCINA, constancia.INDICA_SAUNA, constancia.INDICA_PRESION, constancia.INDICA_INCENDIO, constancia.REFERENCIA_NOMBRE.Trim(),
                    constancia.REFERENCIA_DNI.Trim(), constancia.USUARIO_REGISTRO, new DateTime(2018, 02, 28), null, null, constancia.RAZON_C, constancia.DOMICILIO_C, constancia.INDICA_FIRMA);
                tx.Commit();
                result.Append("success|" + constancia.CONSTANCIA);
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

        public void DeletePDF(string id)
        {
            string filePath = constanciaRPT.RutaPDFs() + id + ".pdf";
            if (System.IO.File.Exists(@"" + filePath))
            {
                try
                {
                    System.IO.File.Delete(@"" + filePath);
                }
                catch (System.IO.IOException e)
                {
                    string msg = e.Message;
                }
            }
        }

        //******este método genera reportes desde el servidor alquilado (usar en deployment)******//
        public string GenerarConstanciaPDF(string constancia)
        {
            string result = "";
            try
            {
                constanciaRPT.ShowRemotePDF(constancia);
                result = "SUCCESS";
            }
            catch (Exception x)
            {
                result = x.Message;
            }
            return result;
        }

        //******este método genera reportes desde el la librería ReportViewer local (usar para pruebas)******//
        public string GenerarConstanciaPDF_test(string constancia)
        {
            string result = "";
            try
            {
                constanciaRPT.ShowLocalPDF(constancia);
                result = "SUCCESS";
            }
            catch (Exception x)
            {
                result = x.Message;
            }
            return result;
        }

        public List<ConstanciaDetalleDTO> ListarDSDetalle()
        {
            List<ConstanciaDetalleDTO> detalles = new List<ConstanciaDetalleDTO>();
            ConstanciaDetalleDTO detalle;
            for (int i = 0; i <= dtConstanciaDet.Rows.Count - 1; i++)
            {
                detalle = new ConstanciaDetalleDTO();
                detalle.SERVICIO = dtConstanciaDet[i].SERVICIO;
                detalle.DESCRIPCION_SERVICIO = dtConstanciaDet[i].DESCRIPCION_SERVICIO;
                detalle.CANTIDAD = dtConstanciaDet[i].CANTIDAD;
                detalle.TIPO = dtConstanciaDet[i].TIPO;
                detalles.Add(detalle);
            }
            return detalles;
        }

        public string LimpiarDSDetalles()
        {
            dtConstanciaDet.Clear();
            return "limpio";
        }

        public List<String> ConstanciasID()
        {
            List<String> ids = new List<string>();
            string id = null;
            conexion.cn.Open();
            string sql = "SELECT CONSTANCIA FROM MAN.CONSTANCIAS";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = dr[0].ToString();
                ids.Add(id);
            }
            dr.Close();
            conexion.cn.Close();
            return ids;
        }

        public ConstanciaDTO ModificarConstancia(string constancia)
        {
            ConstanciaDTO consta = null;
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM MAN.CONSTANCIAS WHERE CONSTANCIA ='" + constancia + "'");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                consta = new ConstanciaDTO();
                consta.CUENTA_COMERCIAL = dr["CUENTA_COMERCIAL"].ToString();
                consta.PISCINA = dr["PISCINA"].ToString();
                consta.COMENTARIO = dr["COMENTARIO"].ToString();
                consta.NIVEL_CLORO = Decimal.Parse(dr["NIVEL_CLORO"].ToString());
                consta.NIVEL_PH = Decimal.Parse(dr["NIVEL_PH"].ToString());
                consta.RAZON_C = dtConstanciaCab[0].RAZON;
                consta.DOMICILIO_C = dtConstanciaCab[0].DOMICILIO;
                consta.REFERENCIA_NOMBRE = dr["REFERENCIA_NOMBRE"].ToString();
                consta.REFERENCIA_DNI = dr["REFERENCIA_DNI"].ToString();
                consta.INDICA_CLIENTE = dr["INDICA_CLIENTE"].ToString();
                consta.INDICA_CONDICION = dr["INDICA_CONDICION"].ToString();
                consta.INDICA_INCENDIO = dr["INDICA_INCENDIO"].ToString();
                consta.INDICA_PISCINA = dr["INDICA_PISCINA"].ToString();
                consta.INDICA_PRESION = dr["INDICA_PRESION"].ToString();
                consta.INDICA_SAUNA = dr["INDICA_SAUNA"].ToString();
                //consta.FIRMA = (byte[])dr["FIRMA"];
            }
            dr.Close();
            int num = dtConstanciaDet.Rows.Count;
            conexion.cn.Close();
            //ConstanciaDTO constancia = new ConstanciaDTO();
            //constancia.CUENTA_COMERCIAL = dtConstancias[0].CUENTA_COMERCIAL;
            //constancia.RAZON = dtConstancias[0].RAZON;
            //constancia.DOMICILIO = dtConstancias[0].DOMICILIO;
            //constancia.PISCINA = dtConstancias[0].PISCINA;
            //constancia.INDICA_CLIENTE = dtConstancias[0].INDICA_CLIENTE;
            //constancia.INDICA_CONDICION = dtConstancias[0].INDICA_CONDICION;
            //constancia.INDICA_INCENDIO = dtConstancias[0].INDICA_INCENDIO;
            //constancia.INDICA_PISCINA = dtConstancias[0].INDICA_PISCINA;
            //constancia.INDICA_PRESION = dtConstancias[0].INDICA_PRESION;
            //constancia.INDICA_SAUNA = dtConstancias[0].INDICA_SAUNA;
            //constancia.NIVEL_CLORO = dtConstancias[0].NIVEL_CLORO;
            //constancia.NIVEL_PH = dtConstancias[0].NIVEL_PH;
            //constancia.REFERENCIA_NOMBRE = dtConstancias[0].REFERENCIA_NOMBRE;
            //constancia.REFERENCIA_DNI = dtConstancias[0].REFERENCIA_DNI;

            return consta;
        }

        private ConstanciaDTO PoblarConstanciaDT()
        {
            ConstanciaDTO constancia = new ConstanciaDTO();
            constancia.CUENTA_COMERCIAL = dtConstanciaCab[0].CUENTA_COMERCIAL;
            constancia.COMENTARIO = dtConstanciaCab[0].COMENTARIO;
            constancia.RAZON_C = dtConstanciaCab[0].RAZON;
            constancia.DOMICILIO_C = dtConstanciaCab[0].DOMICILIO;
            constancia.PISCINA = dtConstanciaCab[0].PISCINA;
            constancia.INDICA_CLIENTE = dtConstanciaCab[0].INDICA_CLIENTE;
            constancia.INDICA_CONDICION = dtConstanciaCab[0].INDICA_CONDICION;
            constancia.INDICA_INCENDIO = dtConstanciaCab[0].INDICA_INCENDIO;
            constancia.INDICA_PISCINA = dtConstanciaCab[0].INDICA_PISCINA;
            constancia.INDICA_PRESION = dtConstanciaCab[0].INDICA_PRESION;
            constancia.INDICA_SAUNA = dtConstanciaCab[0].INDICA_SAUNA;
            constancia.NIVEL_CLORO = dtConstanciaCab[0].NIVEL_CLORO;
            constancia.NIVEL_PH = dtConstanciaCab[0].NIVEL_PH;
            constancia.REFERENCIA_NOMBRE = dtConstanciaCab[0].REFERENCIA_NOMBRE;
            constancia.REFERENCIA_DNI = dtConstanciaCab[0].REFERENCIA_DNI;
            constancia.INDICA_FIRMA = dtConstanciaCab[0].INDICA_FIRMA;

            return constancia;
        }

        private void PoblarDtConstanciasXcliente(List<ConstanciaDTO> constancias)
        {
            dtConstanciasXcliente.Clear();
            foreach (ConstanciaDTO c in constancias)
            {
                dtConstanciasXcliente.Rows.Add(c.CUENTA_COMERCIAL, c.COMENTARIO, c.ESTADO, c.FECHA_REGISTRO, c.FECHA_MODIFICA, c.CONSTANCIA, c.USUARIO_REGISTRO);
            }

        }

        private decimal PrecioServicio(string servicio)
        {
            //string sql = "SELECT PRECIO FROM MAN.SERVICIOS WHERE SERVICIO LIKE '" + servicio + "'";
            //decimal valor = 0;
            //SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    valor = decimal.Parse(dr[0].ToString());
            //}
            //dr.Close();
            //return valor;
            decimal precio = -1;
            var pre = from p in dtProd_Serv
                      where p.SERVICIO == servicio
                      select new
                      {
                          PRECIO = p.PRECIO
                      };
            foreach (var s in pre)
            {
                precio = s.PRECIO;
            }
            return precio;
        }

        private decimal ValorTotalConstancia()
        {
            decimal total = 0;
            for (int i = 0; i <= dtConstanciaDet.Rows.Count - 1; i++)
            {
                total += dtConstanciaDet[i].VALOR_TOTAL;
            }
            return total;
        }

    }
}