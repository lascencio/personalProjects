using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.Utils;
using WebAppHIDRONAMIC.DS;
using System.Text;

namespace WebAppHIDRONAMIC.DAL
{
    public class PiscinasDAL
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        private string CodigoPiscina()
        {
            string sql = "select COM.FUNC_CODIGO_PISCINA()";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            string codigoNuevo = cmd.ExecuteScalar().ToString();
            return codigoNuevo;
        }

        //ESTE MÉTODO LO USABA PARA QUE AL REGISTRAR CLIENTE, AHÍ MISMO SE REGISTRE Y ELIMINE UNA PISCINA.
        //public List<PiscinaDTO> EliminarPiscinaDS(string piscina)
        //{
        //    for (int i = 0; i <= piscinasDS.Rows.Count - 1; i++)
        //    {
        //        DataRow dr = piscinasDS.Rows[i];
        //        if (dr["PISCINA"].ToString() == piscina)
        //        {
        //            dr.Delete();
        //        }
        //    }
        //    return ListarDSPiscinas();
        //}

        public List<PiscinaDTO> EliminarPiscinaBD(string piscina, string cliente)
        {
            string msg = "";
            conexion.cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM COM.PISCINAS WHERE PISCINA LIKE '" + piscina + "'", conexion.cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return PiscinasPorCliente(cliente);
        }

        //ESTE MÉTODO LO USABA PARA QUE AL REGISTRAR CLIENTE, AHÍ MISMO SE REGISTRE UNA PISCINA.
        //public List<PiscinaDTO> Grabar(PiscinaDTO piscina)
        //{
        //    conexion.cn.Open();
        //    piscinasDS.Rows.Add(" ", " ", Utilitarios.Aleatorio1(), piscina.UBICACION, piscina.TIPO_PISCINA, piscina.LARGO, piscina.ANCHO, piscina.PROFUNDIDAD,
        //        piscina.VOLUMEN, piscina.FRECUENCIA, " ", null, null, null);
        //    return ListarDSPiscinas();
        //}

        public List<PiscinaDTO> GrabarBD(PiscinaDTO piscina, string usuario)
        {
            conexion.cn.Open();

            StringBuilder sql = new StringBuilder("INSERT INTO COM.PISCINAS ");
            sql.Append("(EMPRESA,CUENTA_COMERCIAL, PISCINA, UBICACION, TIPO_PISCINA, LARGO, ANCHO, PROFUNDIDAD, VOLUMEN, FRECUENCIA_MANTENIMIENTO, USUARIO_REGISTRO) ");
            sql.Append("VALUES ");
            sql.Append("(@vEMPRESA, @vCUENTA_COMERCIAL, @vPISCINA, @vUBICACION, @vTIPO_PISCINA, @vLARGO, @vANCHO, @vPROFUNDIDAD, @vVOLUMEN, @vFRECUENCIA, @vUSUARIO_REGISTRO)");

            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);
                cmd.Parameters.AddWithValue("vEMPRESA", "001");
                cmd.Parameters.AddWithValue("vCUENTA_COMERCIAL", piscina.CUENTA_COMERCIAL);
                cmd.Parameters.AddWithValue("vPISCINA", CodigoPiscina());
                cmd.Parameters.AddWithValue("vUBICACION", piscina.UBICACION);
                cmd.Parameters.AddWithValue("vTIPO_PISCINA", piscina.TIPO_PISCINA);
                cmd.Parameters.AddWithValue("vLARGO", piscina.LARGO);
                cmd.Parameters.AddWithValue("vANCHO", piscina.ANCHO);
                cmd.Parameters.AddWithValue("vPROFUNDIDAD", piscina.PROFUNDIDAD);
                cmd.Parameters.AddWithValue("vVOLUMEN", (piscina.LARGO * piscina.ANCHO * piscina.PROFUNDIDAD));
                cmd.Parameters.AddWithValue("vFRECUENCIA", piscina.FRECUENCIA);
                cmd.Parameters.AddWithValue("vUSUARIO_REGISTRO", usuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return PiscinasPorCliente(piscina.CUENTA_COMERCIAL);
        }

        //ESTE MÉTODO LO USABA PARA LISTAR PISCINAS TEMPORALES.
        //public List<PiscinaDTO> ListarDSPiscinas()
        //{
        //    List<PiscinaDTO> piscinas = new List<PiscinaDTO>();
        //    PiscinaDTO piscina;
        //    for (int i = 0; i <= piscinasDS.Rows.Count - 1; i++)
        //    {
        //        piscina = new PiscinaDTO();
        //        piscina.PISCINA = piscinasDS[i].PISCINA;
        //        piscina.TIPO_PISCINA = Utilitarios.HallarTipoPiscina(piscinasDS[i].TIPO_PISCINA);
        //        piscina.UBICACION = piscinasDS[i].UBICACION;
        //        piscina.FRECUENCIA = Utilitarios.FrecuenciaMant(piscinasDS[i].FRECUENCIA_MANTENIMIENTO);
        //        piscina.LARGO = piscinasDS[i].LARGO;
        //        piscina.ANCHO = piscinasDS[i].ANCHO;
        //        piscina.PROFUNDIDAD = piscinasDS[i].PROFUNDIDAD;
        //        piscina.VOLUMEN = piscinasDS[i].VOLUMEN;
        //        piscinas.Add(piscina);
        //    }
        //    return piscinas;
        //}

        public List<PiscinaDTO> Modificar(PiscinaDTO piscina)
        {
            List<PiscinaDTO> piscinas = new List<PiscinaDTO>();
            conexion.cn.Open();

            StringBuilder sql = new StringBuilder("UPDATE COM.PISCINAS ");
            sql.Append("SET UBICACION = @vUBICACION,TIPO_PISCINA = @vTIPO_PISCINA, LARGO = @vLARGO, ANCHO = @vANCHO, PROFUNDIDAD = @vPROFUNDIDAD, ");
            sql.Append("VOLUMEN = @vVOLUMEN, FRECUENCIA_MANTENIMIENTO = @vFRECUENCIA,USUARIO_MODIFICA = @vUSUARIO_MODIFICA,FECHA_MODIFICA = GETDATE() ");
            sql.Append("WHERE PISCINA = @vPISCINA ");

            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), conexion.cn);
                cmd.Parameters.AddWithValue("vUBICACION", piscina.UBICACION);
                cmd.Parameters.AddWithValue("vTIPO_PISCINA", piscina.TIPO_PISCINA);
                cmd.Parameters.AddWithValue("vLARGO", piscina.LARGO);
                cmd.Parameters.AddWithValue("vANCHO", piscina.ANCHO);
                cmd.Parameters.AddWithValue("vPROFUNDIDAD", piscina.PROFUNDIDAD);
                cmd.Parameters.AddWithValue("vVOLUMEN", (piscina.LARGO * piscina.ANCHO * piscina.PROFUNDIDAD));
                cmd.Parameters.AddWithValue("vFRECUENCIA", piscina.FRECUENCIA);
                cmd.Parameters.AddWithValue("vUSUARIO_MODIFICA", "SISTEMAS");
                cmd.Parameters.AddWithValue("vPISCINA", piscina.PISCINA);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return PiscinasPorCliente(piscina.CUENTA_COMERCIAL);
        }
        public List<PiscinaDTO> PiscinasPorCliente(string cuenta_comercial)
        {
            conexion.cn.Open();
            List<PiscinaDTO> piscinas = new List<PiscinaDTO>();
            string sql = "SELECT * FROM  [COM].[INFO_PISCINAS] WHERE CUENTA_COMERCIAL = '" + cuenta_comercial + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PiscinaDTO piscina = new PiscinaDTO();
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
                piscinas.Add(piscina);
            }

            conexion.cn.Close();
            return piscinas;
        }
        public PiscinaDTO PiscinaPorId(string idPiscina)
        {
            conexion.cn.Open();
            PiscinaDTO piscina = null;
            string sql = "SELECT * FROM  [COM].[INFO_PISCINAS] WHERE PISCINA = '" + idPiscina + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
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

                piscina.acido10 = string.Format("{0:0.00}", (piscina.VOLUMEN / 10)) + " Lt.";
                piscina.acido20 = string.Format("{0:0.00}", (piscina.VOLUMEN / 20)) + " Lt.";
                piscina.soda = string.Format("{0:0.00}", ((piscina.VOLUMEN * 100) / 10)) + " gr.";
                piscina.cloGra5 = string.Format("{0:0.00}", (piscina.VOLUMEN * 5)) + " gr.";
                piscina.cloGra7 = string.Format("{0:0.00}", (piscina.VOLUMEN * 7)) + " gr.";
                piscina.cloGra15 = string.Format("{0:0.00}", (piscina.VOLUMEN * 15)) + " gr.";
                piscina.cloGra21 = string.Format("{0:0.00}", (piscina.VOLUMEN * 21)) + " gr.";
                piscina.cloPas20 = string.Format("{0:0.00}", (piscina.VOLUMEN / 20)) + " past.";
                piscina.sulfAl10 = string.Format("{0:0.00}", (piscina.VOLUMEN * 10)) + " gr.";
                piscina.sulfCo3 = string.Format("{0:0.00}", (piscina.VOLUMEN * 3)) + " gr.";
                piscina.sulfCo10 = string.Format("{0:0.00}", (piscina.VOLUMEN * 10)) + " gr.";

                double vol = (double)piscina.VOLUMEN;

                string strHay = vol / 931.52 + "";
                string strPen = vol / 989.74 + "";

                double resHay = Double.Parse(strHay);
                double resPen = Double.Parse(strPen);

                piscina.piscSal3000 = string.Format("{0:0.00}", (200 * resHay)) + " kg.";
                piscina.piscSal4000 = string.Format("{0:0.00}", (600 * resPen)) + " kg.";
            }

            conexion.cn.Close();
            return piscina;
        }

    }


}
