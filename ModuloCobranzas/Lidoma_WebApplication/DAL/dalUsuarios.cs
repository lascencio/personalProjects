using Lidoma_WebApplication.Entities;
using Lidoma_WebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Lidoma_WebApplication.DAL
{
    public class dalUsuarios
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        public entUsuario Obtener(string user, string clave)
        {
            entUsuario usuario = new entUsuario();
            conexion.cn.Open();
            string sql = "SELECT * FROM GEN.USUARIOS WHERE Usuario='" + user + "' AND Clave='" + clave + "'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new entUsuario();
                usuario.empresa = dr[0].ToString();
                usuario.usuario = dr[1].ToString();
                usuario.descripcion = dr[2].ToString();
                usuario.clave = dr[3].ToString();
                usuario.email = dr[4].ToString();
                usuario.perfil = dr[5].ToString();
                usuario.privilegios = int.Parse(dr[6].ToString());
                usuario.aprobar_mn = decimal.Parse(dr[7].ToString());
                usuario.aprobar_me = decimal.Parse(dr[8].ToString());
                usuario.serie_asignada = dr[9].ToString();
                usuario.es_plantilla = dr[10].ToString().Equals("1") ? true : false;
                usuario.emite_ticket = dr[10].ToString().Equals("1") ? true : false;
                usuario.estado = dr[12].ToString();
            }
            dr.Close();
            conexion.cn.Close();
            return usuario;
        }
    }
}