using System;
using System.Collections.Generic;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.Utils;
using WebAppHIDRONAMIC.DS;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebAppHIDRONAMIC.Reports;
using System.Web;

namespace WebAppHIDRONAMIC.DAL
{
    public class ProformasDAL
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        ProformasRPT proformaRPT = new ProformasRPT();
        EmailDAL emailDL = new EmailDAL();

        ProformasDS.CotizacionDetDTDataTable dtCotizacionDet = HttpContext.Current.Session["dtCotizacionDet"] as ProformasDS.CotizacionDetDTDataTable;
        ProformasDS.CotizacionDatDTDataTable dtCotizacionCab = HttpContext.Current.Session["dtCotizacionCab"] as ProformasDS.CotizacionDatDTDataTable;
        ProformasDS.CotizacionPorClienteDTDataTable dtCotizacionxCliente = HttpContext.Current.Session["dtCotizacionxCliente"] as ProformasDS.CotizacionPorClienteDTDataTable;
        ProformasDS.CotizacionDetDTDataTable dtCotizacionDet_cons = HttpContext.Current.Session["dtCotizacionDet_cons"] as ProformasDS.CotizacionDetDTDataTable;
        List<string> correos = HttpContext.Current.Session["correos"] as List<string>;
        List<string> correosLiq = HttpContext.Current.Session["correosLiq"] as List<string>;

        private string CodigoCorrelativo()
        {
            string sql = "SELECT COM.FUNC_CODIGO_COTIZACION()";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            string codigoNuevo = cmd.ExecuteScalar().ToString();
            return codigoNuevo;
        }
        public ProformaDTO ConsultarProforma(string id)
        {
            ProformaDTO proforma = new ProformaDTO();
            List<ProformaDetalleDTO> detalles = new List<ProformaDetalleDTO>();
            string sql = "SELECT * FROM [COM].[DETALLES_PROFORMA] WHERE COTIZACION ='" + id + "'";
            conexion.cn.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //proforma.TIPO = null;
                //proforma.TIPO_MONEDA = null;
                ProformaDetalleDTO detalle = new ProformaDetalleDTO();
                detalle.COTIZACION = dr["COTIZACION"].ToString();
                detalle.PRODUCTO = dr["PRODUCTO"].ToString();
                detalle.DESCRIPCION = dr["DESCRIPCION"].ToString();
                detalle.CANTIDAD = int.Parse(dr["CANTIDAD"].ToString());
                detalle.PRECIO_UNITARIO_ME = decimal.Parse(dr["PRECIO_UNITARIO_ME"].ToString());
                detalle.PRECIO_UNITARIO_MN = Utilitarios.CambioSoles(detalle.PRECIO_UNITARIO_ME);
                detalle.IMPORTE_TOTAL_ME = decimal.Parse(dr["IMPORTE_TOTAL_ME"].ToString());
                detalle.IMPORTE_TOTAL_MN = Utilitarios.CambioSoles(detalle.IMPORTE_TOTAL_ME);
                detalle.FAMILIA = Utilitarios.HallarFamilia(dr["FAMILIA"].ToString());
                detalle.DESCUENTO_PORCENTUAL = 0;
                proforma.TIPO = dr["TIPO"].ToString();
                proforma.TIPO_MONEDA = dr["TIPO_MONEDA"].ToString();
                detalles.Add(detalle);
            }
            proforma.DESCUENTO_GLOBAL = 0;
            PoblarDtCotizacionesDet(detalles);
            conexion.cn.Close();
            return proforma;
        }
        public string DeletePDF(string id)
        {
            string result = "UBICACIÓN DE PROFORMA NO HALLADA";
            string filePath = proformaRPT.RutaPDFs() + id + ".pdf";
            if (System.IO.File.Exists(@"" + filePath))
            {
                try
                {
                    System.IO.File.Delete(@"" + filePath);
                    result = "SUCCESS";
                }
                catch (System.IO.IOException e)
                {
                    result = e.Message;
                }

            }
            return result;
        }

        public List<ProformaDTO> Eliminar(string proforma)
        {
            conexion.cn.Open();
            SqlTransaction tx = conexion.cn.BeginTransaction();
            string sqlCab = "DELETE FROM [COM].[COTIZACION] WHERE COTIZACION LIKE '" + proforma + "'";
            string sqlDat = "DELETE FROM [COM].[COTIZACION_DATOS] WHERE COTIZACION LIKE '" + proforma + "'";
            string sqlDet = "DELETE FROM [COM].[COTIZACION_DET] WHERE COTIZACION LIKE '" + proforma + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlDet.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlDat.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlCab.ToString(), conexion.cn, tx))
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
            return ProformasPorMes("");
        }
        public List<ProformaDetalleDTO> EliminarDetalle(string producto)
        {
            for (int i = 0; i <= dtCotizacionDet.Rows.Count - 1; i++)
            {
                DataRow dr = dtCotizacionDet.Rows[i];
                if (dr["PRODUCTO"].ToString() == producto)
                {
                    dr.Delete();
                }
            }
            return ListarDSDetalle();
        }
        public string EnviarProformaEmail(string proforma, string asunto, string cuerpo)
        {
            string result = "";
            try
            {
                emailDL.EnviarProforma(proforma, asunto, cuerpo);
                result = "SUCCESS";
            }
            catch (Exception x)
            {
                result = x.Message;
            }
            return result;
        }
        public ProformaDTO EliminarProforma(string cotizacion)
        {
            string result = "";
            ProformaDTO proforma = new ProformaDTO();
            conexion.cn.Open();
            SqlTransaction tx = conexion.cn.BeginTransaction();
            string sqlCab = "DELETE FROM [COM].[COTIZACION] WHERE COTIZACION LIKE '" + cotizacion + "'";
            string sqlDat = "DELETE FROM [COM].[COTIZACION_DATOS] WHERE COTIZACION LIKE '" + cotizacion + "'";
            string sqlDet = "DELETE FROM [COM].[COTIZACION_DET] WHERE COTIZACION LIKE '" + cotizacion + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlDet.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlDat.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlCab.ToString(), conexion.cn, tx))
                {
                    cmd.ExecuteNonQuery();
                }
                proforma = PoblarProformaDT();
                proforma.DESCUENTO_GLOBAL = 0;
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
            return proforma;
        }
        public string GenerarProforma(ProformaDTO proforma, string usuario, string codUsuario, string empresa)
        {
            StringBuilder result = new StringBuilder();
            conexion.cn.Open();
            proforma.COTIZACION = CodigoCorrelativo();
            proforma.USUARIO_REGISTRO = usuario;
            proforma.EMPRESA = empresa;
            proforma.CODIGO_VENDEDOR = codUsuario;
            proforma.EMPRESA = empresa;
            proforma.EJERCICIO = Utilitarios.Ejercicio();
            proforma.MES = Utilitarios.Mes();
            proforma.TIPO_CAMBIO = Utilitarios.TIPO_CAMBIO;
            decimal IMPORTE_TOTAL_S = 0;
            decimal IMPORTE_TOTAL_D = 0;
            //Utilitarios.DeletePDF(proforma.COTIZACION);
            dtCotizacionCab.Clear();

            SqlTransaction tx = conexion.cn.BeginTransaction();

            StringBuilder sqlCotizacion = new StringBuilder("INSERT INTO COM.COTIZACION ");
            sqlCotizacion.Append("(EMPRESA, COTIZACION, EJERCICIO, MES, COTIZACION_FECHA, CODIGO_VENDEDOR, LISTA_PRECIOS, IMPORTE_TOTAL_ME, IMPORTE_TOTAL_MN, ");
            sqlCotizacion.Append("DESCUENTO_GLOBAL,TIPO_CAMBIO,COMENTARIO,USUARIO_REGISTRO,TIPO,TIPO_MONEDA) ");
            sqlCotizacion.Append("VALUES ");
            sqlCotizacion.Append("(@vEMPRESA, @vCOTIZACION, @vEJERCICIO, @vMES, @vCOTIZACION_FECHA, @vCODIGO_VENDEDOR, @vLISTA_PRECIOS, @vIMPORTE_TOTAL_ME, ");
            sqlCotizacion.Append("@vIMPORTE_TOTAL_MN, @vDESCUENTO_GLOBAL,@vTIPO_CAMBIO,@vCOMENTARIO, @vUSUARIO_REGISTRO, @vTIPO, @vTIPO_MONEDA)");

            StringBuilder sqlCDatos = new StringBuilder("INSERT INTO COM.COTIZACION_DATOS ");
            sqlCDatos.Append("(EMPRESA, COTIZACION, RAZON_SOCIAL, REFERENCIA, DOMICILIO, TELEFONO, CELULAR, EMAIL, FORMA_PISCINA, TIPO_PISCINA, LARGO, ANCHO, PROFUNDIDAD, ");
            sqlCDatos.Append("VOLUMEN, CAUDAL, TIEMPO_FILTRADO, COMENTARIO, USUARIO_REGISTRO) ");
            sqlCDatos.Append("VALUES ");
            sqlCDatos.Append("(@vEMPRESA, @vCOTIZACION, @vRAZON_SOCIAL, @vREFERENCIA, @vDOMICILIO, @vTELEFONO, @vCELULAR, @vEMAIL, @vFORMA_PISCINA, @vTIPO_PISCINA, ");
            sqlCDatos.Append("@vLARGO, @vANCHO, @vPROFUNDIDAD, @vVOLUMEN, @vCAUDAL, @vTIEMPO_FILTRADO, @vCOMENTARIO, @vUSUARIO_REGISTRO)");

            StringBuilder sqlDetalles = new StringBuilder("INSERT INTO COM.COTIZACION_DET ");
            sqlDetalles.Append("(EMPRESA, COTIZACION, PRODUCTO, CANTIDAD, PRECIO_UNITARIO_MN, PRECIO_UNITARIO_ME, IMPORTE_TOTAL_MN,IMPORTE_TOTAL_ME, ");
            sqlDetalles.Append("DESCUENTO_PORCENTUAL,USUARIO_REGISTRO) ");
            sqlDetalles.Append("VALUES ");
            sqlDetalles.Append("(@vEMPRESA, @vCOTIZACION, @vPRODUCTO, @vCANTIDAD, @vPRECIO_UNITARIO_MN, @vPRECIO_UNITARIO_ME, @vIMPORTE_TOTAL_MN, @vIMPORTE_TOTAL_ME, ");
            sqlDetalles.Append(" @vDESCUENTO_PORCENTUAL,@vUSUARIO_REGISTRO)");

            string sqlUpdate = "UPDATE COM.COTIZACION SET IMPORTE_TOTAL_ME = @vIMPORTE_TOTAL_ME, IMPORTE_TOTAL_MN = @vIMPORTE_TOTAL_MN WHERE COTIZACION LIKE @vCOTIZACION";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlCotizacion.ToString(), conexion.cn, tx))
                {
                    cmd.Parameters.AddWithValue("vEMPRESA", proforma.EMPRESA);
                    cmd.Parameters.AddWithValue("vCOTIZACION", proforma.COTIZACION);
                    cmd.Parameters.AddWithValue("vEJERCICIO", proforma.EJERCICIO);
                    cmd.Parameters.AddWithValue("vMES", proforma.MES);
                    cmd.Parameters.AddWithValue("vCOTIZACION_FECHA", proforma.COTIZACION_FECHA);
                    cmd.Parameters.AddWithValue("vCODIGO_VENDEDOR", proforma.CODIGO_VENDEDOR);
                    cmd.Parameters.AddWithValue("vLISTA_PRECIOS", proforma.LISTA_PRECIOS);
                    cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_ME", proforma.IMPORTE_TOTAL_ME);
                    cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_MN", proforma.IMPORTE_TOTAL_MN);
                    cmd.Parameters.AddWithValue("vDESCUENTO_GLOBAL", proforma.DESCUENTO_GLOBAL);
                    cmd.Parameters.AddWithValue("vTIPO_CAMBIO", proforma.TIPO_CAMBIO);
                    cmd.Parameters.AddWithValue("vCOMENTARIO", proforma.COMENTARIO);
                    cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", proforma.USUARIO_REGISTRO);
                    cmd.Parameters.AddWithValue("vTIPO", proforma.TIPO);
                    cmd.Parameters.AddWithValue("vTIPO_MONEDA", proforma.TIPO_MONEDA);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlCDatos.ToString(), conexion.cn, tx))
                {
                    decimal volumen = proforma.PROFUNDIDAD * proforma.ANCHO * proforma.LARGO;
                    decimal caudal = (volumen * (1000m / 3.785m) * (1m / 60m)) / proforma.TIEMPO_FILTRADO;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("vEMPRESA", proforma.EMPRESA);
                    cmd.Parameters.AddWithValue("vCOTIZACION", proforma.COTIZACION);
                    cmd.Parameters.AddWithValue("vRAZON_SOCIAL", proforma.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("vDOMICILIO", proforma.DOMICILIO);
                    cmd.Parameters.AddWithValue("vREFERENCIA", proforma.REFERENCIA);
                    cmd.Parameters.AddWithValue("vTELEFONO", proforma.TELEFONO);
                    cmd.Parameters.AddWithValue("vCELULAR", proforma.CELULAR);
                    cmd.Parameters.AddWithValue("vEMAIL", proforma.EMAIL);
                    cmd.Parameters.AddWithValue("vFORMA_PISCINA", proforma.FORMA_PISCINA);
                    cmd.Parameters.AddWithValue("vTIPO_PISCINA", proforma.TIPO_PISCINA);
                    cmd.Parameters.AddWithValue("vLARGO", proforma.LARGO);
                    cmd.Parameters.AddWithValue("vANCHO", proforma.ANCHO);
                    cmd.Parameters.AddWithValue("vPROFUNDIDAD", proforma.PROFUNDIDAD);
                    cmd.Parameters.AddWithValue("vVOLUMEN", volumen);
                    cmd.Parameters.AddWithValue("vTIEMPO_FILTRADO", proforma.TIEMPO_FILTRADO);
                    cmd.Parameters.AddWithValue("vCAUDAL", caudal);
                    cmd.Parameters.AddWithValue("vCOMENTARIO", proforma.COMENTARIO);
                    cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", proforma.USUARIO_REGISTRO);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sqlDetalles.ToString(), conexion.cn, tx))
                {
                    for (int i = 0; i <= dtCotizacionDet.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();
                        if (dtCotizacionDet[i].DESCUENTO_PORCENTUAL != 0)
                        {
                            dtCotizacionDet[i].PRECIO_UNITARIO_ME = Utilitarios.AplicarDescuento(dtCotizacionDet[i].PRECIO_UNITARIO_ME, dtCotizacionDet[i].DESCUENTO_PORCENTUAL);
                            dtCotizacionDet[i].PRECIO_UNITARIO_MN = Utilitarios.AplicarDescuento(dtCotizacionDet[i].PRECIO_UNITARIO_MN, dtCotizacionDet[i].DESCUENTO_PORCENTUAL);
                            dtCotizacionDet[i].IMPORTE_TOTAL_ME = dtCotizacionDet[i].PRECIO_UNITARIO_ME * dtCotizacionDet[i].CANTIDAD;
                            dtCotizacionDet[i].IMPORTE_TOTAL_MN = dtCotizacionDet[i].PRECIO_UNITARIO_MN * dtCotizacionDet[i].CANTIDAD;
                        }
                        IMPORTE_TOTAL_D = IMPORTE_TOTAL_D + dtCotizacionDet[i].IMPORTE_TOTAL_ME;
                        IMPORTE_TOTAL_S = IMPORTE_TOTAL_S + dtCotizacionDet[i].IMPORTE_TOTAL_MN;
                        cmd.Parameters.AddWithValue("vEMPRESA", proforma.EMPRESA);
                        cmd.Parameters.AddWithValue("vCOTIZACION", proforma.COTIZACION);
                        cmd.Parameters.AddWithValue("vPRODUCTO", dtCotizacionDet[i].PRODUCTO);
                        cmd.Parameters.AddWithValue("vCANTIDAD", dtCotizacionDet[i].CANTIDAD);
                        cmd.Parameters.AddWithValue("vPRECIO_UNITARIO_MN", dtCotizacionDet[i].PRECIO_UNITARIO_MN);
                        cmd.Parameters.AddWithValue("vPRECIO_UNITARIO_ME", dtCotizacionDet[i].PRECIO_UNITARIO_ME);
                        cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_MN", dtCotizacionDet[i].IMPORTE_TOTAL_MN);
                        cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_ME", dtCotizacionDet[i].IMPORTE_TOTAL_ME);
                        cmd.Parameters.AddWithValue("vDESCUENTO_PORCENTUAL", dtCotizacionDet[i].DESCUENTO_PORCENTUAL);
                        cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", proforma.USUARIO_REGISTRO);
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(sqlUpdate.ToString(), conexion.cn, tx))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_ME", IMPORTE_TOTAL_D);
                    cmd.Parameters.AddWithValue("vIMPORTE_TOTAL_MN", IMPORTE_TOTAL_S);
                    cmd.Parameters.AddWithValue("vCOTIZACION", proforma.COTIZACION);
                    cmd.ExecuteNonQuery();
                }
                dtCotizacionCab.Rows.Add(proforma.EMPRESA, proforma.COTIZACION, proforma.TIPO, Utilitarios.TIPO_CAMBIO, proforma.COMENTARIO,
                    proforma.RAZON_SOCIAL, proforma.DOMICILIO, proforma.TELEFONO, proforma.CELULAR, proforma.EMAIL, proforma.FORMA_PISCINA,
                    proforma.TIPO_PISCINA, proforma.LARGO, proforma.ANCHO, proforma.PROFUNDIDAD, proforma.TIEMPO_FILTRADO, proforma.DESCUENTO_GLOBAL,
                    "", proforma.REFERENCIA, proforma.TIPO_MONEDA, IMPORTE_TOTAL_D, IMPORTE_TOTAL_S);
                tx.Commit();

                try
                {
                    proformaRPT.ShowRemotePDF(proforma.COTIZACION);
                    result.Append("success/" + proforma.COTIZACION + "/" + proforma.EMAIL);
                }
                catch (Exception x)
                {
                    result.Append(x.Message).Append(Environment.NewLine);
                }
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
        public string GenerarProformaPDF(string proforma)
        {
            string result = "";
            try
            {
                proformaRPT.ShowRemotePDF(proforma);
                result = "SUCCESS";
            }
            catch (Exception x)
            {
                result = x.Message;
            }
            return result;
        }

        public List<ProformaDetalleDTO> GrabarDetalles(string producto, string descripcion, string cantidad, string precio, string familia, string descuento)
        {
            int cant = int.Parse(cantidad);
            decimal precDol = decimal.Parse(precio);
            decimal precSol = decimal.Parse((precDol * Utilitarios.TIPO_CAMBIO).ToString("#.##"));
            decimal desc = decimal.Parse(descuento);
            bool nuevaLinea = true;
            try
            {
                if (dtCotizacionDet.Rows.Count != 0)
                {
                    for (int i = 0; i <= dtCotizacionDet.Rows.Count - 1; i++)
                    {
                        if (dtCotizacionDet[i].PRODUCTO.Equals(producto))
                        {
                            dtCotizacionDet[i].DESCRIPCION = descripcion;
                            dtCotizacionDet[i].CANTIDAD = (byte)cant;
                            dtCotizacionDet[i].PRECIO_UNITARIO_MN = precSol;
                            dtCotizacionDet[i].PRECIO_UNITARIO_ME = precDol;
                            dtCotizacionDet[i].IMPORTE_TOTAL_MN = cant * precSol;
                            dtCotizacionDet[i].IMPORTE_TOTAL_ME = cant * precDol;
                            dtCotizacionDet[i].FAMILIA = familia;
                            dtCotizacionDet[i].DESCUENTO_PORCENTUAL = desc;

                            nuevaLinea = false;
                        }
                    }
                }
                if (nuevaLinea == true)
                {
                    dtCotizacionDet.Rows.Add("", "", producto, (Int16)cant, precSol, precDol, cant * precSol, cant * precDol, "", descripcion, familia, descuento);
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
            return ListarDSDetalle();
        }

        public List<string> AgregarCorreosLiq(string usuario)
        {
            bool nuevaLinea = true;
            if (correosLiq.Count != 0)
            {
                for (int i = 0; i <= correosLiq.Count - 1; i++)
                {
                    if (correosLiq[i].Equals(usuario))
                    {
                        nuevaLinea = false;
                    }
                }
            }
            if (nuevaLinea == true)
            {
                correosLiq.Add(usuario);
            }
            return correosLiq;
        }

        public List<string> EliminarCorreoLiq(string correo)
        {
            correosLiq.Remove(correo);
            return correosLiq;
        }

        public List<string> AgregarCorreos(string usuario)
        {
            bool nuevaLinea = true;
            if (correos.Count != 0)
            {
                for (int i = 0; i <= correos.Count - 1; i++)
                {
                    if (correos[i].Equals(usuario))
                    {
                        nuevaLinea = false;
                    }
                }
            }
            if (nuevaLinea == true)
            {
                correos.Add(usuario);
            }
            return correos;
        }

        public List<string> EliminarCorreo(string correo)
        {
            correos.Remove(correo);
            return correos;
        }
        private void HallarTipoCambioHoy(TipoCambioDTO cambio)
        {
            string fechaHoy = DateTime.Today.ToString("dd/MM/yyyy");
            string fechaRec = cambio.DIA + "/" + cambio.MES + "/" + cambio.EJERCICIO;
            if (fechaHoy.Equals(fechaRec))
            {
                Utilitarios.TIPO_CAMBIO = cambio.VENTA;
            }
        }
        public string LimpiarDSDetalles()
        {
            dtCotizacionDet.Clear();
            return "limpio";
        }
        public List<ProformaDetalleDTO> ListarDSDetalle()
        {
            List<ProformaDetalleDTO> detalles = new List<ProformaDetalleDTO>();
            ProformaDetalleDTO detalle;
            for (int i = 0; i <= dtCotizacionDet.Rows.Count - 1; i++)
            {
                decimal descuento = 0;
                descuento = dtCotizacionDet[i].DESCUENTO_PORCENTUAL;
                detalle = new ProformaDetalleDTO();
                detalle.PRODUCTO = dtCotizacionDet[i].PRODUCTO;
                detalle.DESCRIPCION = dtCotizacionDet[i].DESCRIPCION;
                detalle.FAMILIA = dtCotizacionDet[i].FAMILIA;
                detalle.CANTIDAD = dtCotizacionDet[i].CANTIDAD;
                detalle.IMPORTE_TOTAL_ME = dtCotizacionDet[i].IMPORTE_TOTAL_ME;
                detalle.IMPORTE_TOTAL_MN = dtCotizacionDet[i].IMPORTE_TOTAL_MN;
                detalle.PRECIO_UNITARIO_ME = dtCotizacionDet[i].PRECIO_UNITARIO_ME;
                detalle.PRECIO_UNITARIO_MN = dtCotizacionDet[i].PRECIO_UNITARIO_MN;
                detalle.DESCUENTO_PORCENTUAL = dtCotizacionDet[i].DESCUENTO_PORCENTUAL;
                detalles.Add(detalle);
            }
            return detalles;
        }
        public List<ProformaDetalleDTO> ListarDSDetalleCons()
        {
            List<ProformaDetalleDTO> detalles = new List<ProformaDetalleDTO>();
            ProformaDetalleDTO detalle;
            for (int i = 0; i <= dtCotizacionDet_cons.Rows.Count - 1; i++)
            {
                decimal descuento = 0;
                descuento = dtCotizacionDet_cons[i].DESCUENTO_PORCENTUAL;
                detalle = new ProformaDetalleDTO();
                detalle.PRODUCTO = dtCotizacionDet_cons[i].PRODUCTO;
                detalle.DESCRIPCION = dtCotizacionDet_cons[i].DESCRIPCION;
                detalle.FAMILIA = dtCotizacionDet_cons[i].FAMILIA;
                detalle.CANTIDAD = dtCotizacionDet_cons[i].CANTIDAD;
                detalle.IMPORTE_TOTAL_ME = dtCotizacionDet_cons[i].IMPORTE_TOTAL_ME;
                detalle.IMPORTE_TOTAL_MN = dtCotizacionDet_cons[i].IMPORTE_TOTAL_MN;
                detalle.PRECIO_UNITARIO_ME = dtCotizacionDet_cons[i].PRECIO_UNITARIO_ME;
                detalle.PRECIO_UNITARIO_MN = dtCotizacionDet_cons[i].PRECIO_UNITARIO_MN;
                detalle.DESCUENTO_PORCENTUAL = dtCotizacionDet_cons[i].DESCUENTO_PORCENTUAL;
                detalles.Add(detalle);
            }
            return detalles;
        }
        public List<TipoCambioDTO> ListarTiposCambio(TipoCambioDTO tipo)
        {
            List<TipoCambioDTO> cambios = new List<TipoCambioDTO>();
            string sql = null;

            if (tipo == null)
                cambios = null;
            else
            {
                if (tipo.TIPO_OPERACION.Equals("CONS"))
                {
                    sql = "SELECT EJERCICIO,MES,DIA,MONEDA,COMPRA,VENTA, PROMEDIO FROM GEN.TIPO_CAMBIO WHERE EJERCICIO LIKE '" + tipo.EJERCICIO + "' AND MES LIKE '" +
                    tipo.MES + "' AND DIA LIKE '" + tipo.DIA + "'";
                }
                else
                {
                    sql = "SELECT EJERCICIO,MES,DIA,MONEDA,COMPRA,VENTA, PROMEDIO FROM GEN.TIPO_CAMBIO WHERE EJERCICIO LIKE '" + tipo.EJERCICIO + "' AND MES LIKE '" +
                                        tipo.MES + "'";
                }
                conexion.cn.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoCambioDTO cambio = new TipoCambioDTO();
                    cambio.EJERCICIO = dr[0].ToString();
                    cambio.MES = dr[1].ToString();
                    cambio.DIA = dr[2].ToString();
                    cambio.MONEDA = dr[3].ToString();
                    cambio.COMPRA = decimal.Parse(dr[4].ToString());
                    cambio.VENTA = decimal.Parse(dr[5].ToString());
                    cambio.PROMEDIO = decimal.Parse(dr[6].ToString());
                    cambios.Add(cambio);
                    HallarTipoCambioHoy(cambio);
                }
                dr.Close();
                conexion.cn.Close();
            }
            return cambios;
        }
        public List<TablesDTO> ListarDias(string anio, string mes)
        {
            List<TablesDTO> dias = new List<TablesDTO>();
            int days = DateTime.DaysInMonth(int.Parse(anio), int.Parse(mes));
            for (int i = 1; i <= days; i++)
            {
                TablesDTO dia = new TablesDTO();
                string formato = "0" + i;
                dia.ID = formato.Substring(formato.Length - 2);
                dia.DESCRIPCION = dia.ID;
                dias.Add(dia);
            }
            return dias;
        }
        public List<TipoCambioDTO> MantenimientoCambio(TipoCambioDTO cambio, string usuario)
        {
            cambio.USUARIO_REGISTRO = usuario;
            string sql;
            if (cambio.TIPO_OPERACION.Equals("REG"))
            {
                sql = "INSERT INTO GEN.TIPO_CAMBIO (EJERCICIO,MES,DIA,COMPRA,VENTA,PROMEDIO,USUARIO_REGISTRO) " +
                    "VALUES (@vEJERCICIO,@vMES,@vDIA,@vCOMPRA,@vVENTA,@vPROMEDIO,'" + cambio.USUARIO_REGISTRO + "')";
            }
            else
            {
                sql = "UPDATE GEN.TIPO_CAMBIO SET COMPRA = @vCOMPRA,VENTA = @vVENTA, PROMEDIO = @vPROMEDIO, USUARIO_MODIFICA='" + cambio.USUARIO_REGISTRO + "' " +
                    "WHERE EJERCICIO = @vEJERCICIO AND MES = @vMES AND DIA = @vDIA";
            }
            conexion.cn.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conexion.cn))
                {
                    cmd.Parameters.AddWithValue("vEJERCICIO", cambio.EJERCICIO);
                    cmd.Parameters.AddWithValue("vMES", cambio.MES);
                    cmd.Parameters.AddWithValue("vDIA", cambio.DIA);
                    cmd.Parameters.AddWithValue("vCOMPRA", cambio.COMPRA);
                    cmd.Parameters.AddWithValue("vVENTA", cambio.VENTA);
                    cmd.Parameters.AddWithValue("vPROMEDIO", cambio.PROMEDIO);
                    int res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
                cambio = null;
            }
            finally
            {
                conexion.cn.Close();
            }
            return ListarTiposCambio(cambio);
        }
        private void PoblarDtCotizacionesXcliente(List<ProformaDTO> proformas)
        {
            dtCotizacionxCliente.Clear();
            foreach (ProformaDTO c in proformas)
            {
                dtCotizacionxCliente.Rows.Add(c.IMPORTE_TOTAL_MN, c.TIPO_MONEDA, c.TIPO, c.RAZON_SOCIAL.ToUpper(), c.COTIZACION, c.FECHA_REGISTRO, c.USUARIO_REGISTRO);
            }
        }
        private ProformaDTO PoblarProformaDT()
        {
            ProformaDTO proforma = new ProformaDTO();
            proforma.CUENTA_COMERCIAL = dtCotizacionCab[0].CUENTA_COMERCIAL;
            proforma.RAZON_SOCIAL = dtCotizacionCab[0].RAZON_SOCIAL;
            proforma.DOMICILIO = dtCotizacionCab[0].DOMICILIO;
            proforma.PROFUNDIDAD = dtCotizacionCab[0].PROFUNDIDAD;
            proforma.ANCHO = dtCotizacionCab[0].ANCHO;
            proforma.LARGO = dtCotizacionCab[0].LARGO;
            proforma.EMAIL = dtCotizacionCab[0].EMAIL;
            proforma.CELULAR = dtCotizacionCab[0].CELULAR;
            proforma.TELEFONO = dtCotizacionCab[0].TELEFONO;
            proforma.TIPO = dtCotizacionCab[0].TIPO;
            proforma.TIPO_CAMBIO = dtCotizacionCab[0].TIPO_CAMBIO;
            proforma.TIEMPO_FILTRADO = dtCotizacionCab[0].TIEMPO_FILTRADO;
            proforma.DESCUENTO_GLOBAL = dtCotizacionCab[0].DESCUENTO_GLOBAL;
            proforma.FORMA_PISCINA = dtCotizacionCab[0].FORMA_PISCINA;
            proforma.TIPO_PISCINA = dtCotizacionCab[0].TIPO_PISCINA;
            proforma.REFERENCIA = dtCotizacionCab[0].REFERENCIA;
            proforma.TIPO_MONEDA = dtCotizacionCab[0].TIPO_MONEDA;
            proforma.IMPORTE_TOTAL_ME = dtCotizacionCab[0].IMPORTE_TOTAL_ME;
            proforma.IMPORTE_TOTAL_MN = dtCotizacionCab[0].IMPORTE_TOTAL_MN;
            return proforma;
        }
        private void PoblarDtCotizacionesDet(List<ProformaDetalleDTO> detalles)
        {
            //dtCotizacionDet_cons.Clear();
            //foreach (ProformaDetalleDTO d in detalles)
            //{
            //    dtCotizacionDet_cons.Rows.Add("", d.COTIZACION, d.PRODUCTO, d.CANTIDAD, d.PRECIO_UNITARIO_MN, d.PRECIO_UNITARIO_ME, d.IMPORTE_TOTAL_MN, d.IMPORTE_TOTAL_ME,"",d.DESCRIPCION,d.FAMILIA, d.DESCUENTO_PORCENTUAL);
            //}
            dtCotizacionDet.Clear();
            foreach (ProformaDetalleDTO d in detalles)
            {
                dtCotizacionDet.Rows.Add("", d.COTIZACION, d.PRODUCTO, d.CANTIDAD, d.PRECIO_UNITARIO_MN, d.PRECIO_UNITARIO_ME, d.IMPORTE_TOTAL_MN, d.IMPORTE_TOTAL_ME, "", d.DESCRIPCION, d.FAMILIA, d.DESCUENTO_PORCENTUAL);
            }
        }
        public List<ProformaDTO> ProformasPorMes(string mes)
        {
            List<ProformaDTO> proformas = new List<ProformaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_COTIZACIONES] ");
            if (!String.IsNullOrEmpty(mes))
            {
                sql.Append("WHERE MONTH(FECHA_CONSULTA) = '" + mes + "' ");
            }
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProformaDTO proforma = new ProformaDTO();
                proforma.COTIZACION = dr["COTIZACION"].ToString();
                proforma.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                proforma.TIPO = dr["TIPO"].ToString();
                proforma.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                proforma.TIPO_MONEDA = dr["MONEDA"].ToString();
                proforma.IMPORTE_TOTAL_MN = decimal.Parse(dr["TOTAL"].ToString());
                proforma.USUARIO_REGISTRO = dr["USUARIO"].ToString();
                proformas.Add(proforma);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtCotizacionesXcliente(proformas);

            return proformas;
        }
        public List<ProformaDTO> ProformasPorAnio(string anio)
        {
            List<ProformaDTO> proformas = new List<ProformaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_COTIZACIONES] ");
            sql.Append("WHERE YEAR(FECHA_CONSULTA) = '" + anio + "' ");
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProformaDTO proforma = new ProformaDTO();
                proforma.COTIZACION = dr["COTIZACION"].ToString();
                proforma.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                proforma.TIPO = dr["TIPO"].ToString();
                proforma.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                proforma.TIPO_MONEDA = dr["MONEDA"].ToString();
                proforma.IMPORTE_TOTAL_MN = decimal.Parse(dr["TOTAL"].ToString());
                proformas.Add(proforma);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtCotizacionesXcliente(proformas);

            return proformas;
        }
        public List<ProformaDTO> ProformasPorFechas(string fecha1, string fecha2)
        {
            List<ProformaDTO> proformas = new List<ProformaDTO>();
            conexion.cn.Open();
            StringBuilder sql = new StringBuilder("SELECT * FROM [MAN].[CONSULTA_COTIZACIONES] ");
            sql.Append("WHERE FORMAT(FECHA_CONSULTA, 'yyyy/MM/dd')BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' ");
            sql.Append("ORDER BY FECHA_CONSULTA DESC");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProformaDTO proforma = new ProformaDTO();
                proforma.COTIZACION = dr["COTIZACION"].ToString();
                proforma.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                proforma.TIPO = dr["TIPO"].ToString();
                proforma.FECHA_REGISTRO = dr["FECHA_FORMATO"].ToString();
                proforma.TIPO_MONEDA = dr["MONEDA"].ToString();
                proforma.IMPORTE_TOTAL_MN = decimal.Parse(dr["TOTAL"].ToString());
                proforma.USUARIO_REGISTRO = dr["USUARIO"].ToString();
                proformas.Add(proforma);
            }
            dr.Close();
            conexion.cn.Close();

            PoblarDtCotizacionesXcliente(proformas);

            return proformas;
        }
        public List<ProformaDTO> ProformasPorCliente(string cliente)
        {
            List<ProformaDTO> proformas = new List<ProformaDTO>();
            var pro = from c in dtCotizacionxCliente
                      where c.RAZON_SOCIAL.Contains(cliente)
                      select new
                      {
                          RAZON_SOCIAL = c.RAZON_SOCIAL,
                          COTIZACION = c.COTIZACION,
                          FECHA_REGISTRO = c.FECHA_FORMATO,
                          TIPO_MONEDA = c.MONEDA,
                          TOTAL = c.TOTAL,
                          TIPO = c.TIPO,
                          USUARIO_REGISTRO = c.USUARIO_REGISTRO
                      };
            foreach (var c in pro)
            {
                ProformaDTO proforma = new ProformaDTO();
                proforma.RAZON_SOCIAL = c.RAZON_SOCIAL;
                proforma.TIPO = c.TIPO;
                proforma.FECHA_REGISTRO = c.FECHA_REGISTRO;
                proforma.COTIZACION = c.COTIZACION;
                proforma.TIPO_MONEDA = c.TIPO_MONEDA;
                proforma.IMPORTE_TOTAL_MN = c.TOTAL;
                proforma.USUARIO_REGISTRO = c.USUARIO_REGISTRO;
                proformas.Add(proforma);
            }
            return proformas;
        }

    }
}