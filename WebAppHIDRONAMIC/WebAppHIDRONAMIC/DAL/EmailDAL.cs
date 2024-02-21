using System;
using System.Net.Mail;
using WebAppHIDRONAMIC.Reports;
using System.Net;
using System.Net.Mime;
using WebAppHIDRONAMIC.Utils;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Web;

namespace WebAppHIDRONAMIC.DAL
{
    public class EmailDAL
    {
        ConstanciaRPT constanciaRPT = new ConstanciaRPT();
        ConexionSQLServer conexion = new ConexionSQLServer();
        List<string> correos = HttpContext.Current.Session["correos"] as List<string>;
        List<string> correosLiq = HttpContext.Current.Session["correosLiq"] as List<string>;
        private Attachment myAttachment;

        /*******************************************************************
         *******************************************************************
         *MÉTODOS PARA ENVIAR Y GENERAR PDF DE CONSTANCIAS DE MANTENIMIENTOS 
         *******************************************************************
         *******************************************************************/
        public void EnviarConstancia(string constancia)
        {
            conexion.cn.Open();
            string emailDestinatario = "";
            string nombre = "";
            StringBuilder cuerpoEmail = new StringBuilder();
            string asuntoEmail = "Constancia de Mantenimiento de Piscina ";
            string sql = "SELECT EMAIL, ALIAS FROM COM.CUENTAS_COMERCIALES CC JOIN MAN.CONSTANCIAS C ON CC.CUENTA_COMERCIAL = C.CUENTA_COMERCIAL " +
                         "WHERE C.CONSTANCIA LIKE '" + constancia + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conexion.cn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emailDestinatario = dr[0].ToString();
                    nombre = dr[1].ToString();
                }
                dr.Close();
            }
            cuerpoEmail.Append("<br/>Estimado Cliente " + nombre + ": <br/><br/>");
            cuerpoEmail.Append("Por medio del presente estamos adjuntando la constancia de mantenimiento de su piscina para su consideración.<br/>");
            cuerpoEmail.Append("Quedamos a su disposición para absolver cualquier duda o consulta. <br/><br/>");
            cuerpoEmail.Append("<br/><br/>");
            cuerpoEmail.Append("Atentamente, <br/>");
            EnviarEmail(cuerpoEmail, asuntoEmail, emailDestinatario, constancia, null, null, 1);
        }

        /*******************************************************************
         *******************************************************************
         *MÉTODOS GENERAR PDF DE ESTADOS DE CUENTAS POR MES
         *******************************************************************
         *******************************************************************/
        public void EnviarEstadoCuenta(string cliente, string idGenerado, string asunto, string cuerpo)
        {
            conexion.cn.Open();
            string emailDestinatario = "";
            string nombre = "";
            StringBuilder cuerpoEmail = new StringBuilder();
            string asuntoEmail = asunto;
            string sql = "SELECT EMAIL, ALIAS FROM COM.CUENTAS_COMERCIALES WHERE CUENTA_COMERCIAL LIKE '" + cliente + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conexion.cn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emailDestinatario = dr[0].ToString();
                    nombre = dr[1].ToString();
                }
                dr.Close();
            }

            cuerpoEmail.Append("<br/>Estimado cliente " + nombre + ": <br/><br/>");
            //cuerpoEmail.Append("Por medio del presente estamos adjuntando su estado de cuenta para su consideración.<br/>");
            //cuerpoEmail.Append("Quedamos a su disposición para absolver cualquier duda o consulta. <br/><br/>");
            cuerpoEmail.Append(cuerpo);
            cuerpoEmail.Append("<br/><br/>");
            cuerpoEmail.Append("Atentamente, <br/>");
            EnviarEmail(cuerpoEmail, asuntoEmail, emailDestinatario, null, idGenerado, null, 2);
        }

        public void EnviarProforma(string proforma, string asunto, string cuerpo)
        {
            string emailDestinatario = "";
            string nombre = "";
            StringBuilder cuerpoEmail = new StringBuilder();
            string asuntoEmail = asunto;
            string sql = "SELECT EMAIL, RAZON_SOCIAL FROM COM.COTIZACION_DATOS WHERE COTIZACION LIKE '" + proforma + "'";
            conexion.cn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conexion.cn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emailDestinatario = dr[0].ToString();
                    nombre = dr[1].ToString();
                }
                dr.Close();
            }
            conexion.cn.Close();

            cuerpoEmail.Append("<br/>Estimado cliente " + nombre + ": <br/><br/>");
            //cuerpoEmail.Append("Por medio del presente estamos adjuntando la proforma solicitada para su consideración.<br/>");
            //cuerpoEmail.Append("Quedamos a su disposición para absolver cualquier duda o consulta. <br/><br/>");
            cuerpoEmail.Append(cuerpo);
            cuerpoEmail.Append("<br/><br/>");
            cuerpoEmail.Append("Atentamente, <br/>");
            EnviarEmail(cuerpoEmail, asuntoEmail, emailDestinatario, null, null,proforma,3);
        }

        /*******************************************************************
         *******************************************************************
         *******MÉTODO PARA ENVIAR PDF A LOS CORREOS ELECTRONICOS******
         *******************************************************************
         *******************************************************************/
        private void EnviarEmail(StringBuilder cuerpoEmail, string asuntoEmail, string emailDestinatario, string constancia, string idGenerado, string proforma, int tipo)
        {
            string correo, emisor, clave, ruta;
            MailMessage objEmail = new MailMessage();

            switch (tipo)
            {
                case 1:
                    ruta = constanciaRPT.RutaPDFs() + constancia + ".pdf";
                    //myAttachment = new Attachment(constanciaRPT.RutaPDFs() + constancia + ".pdf");
                    correo = "serviciotecnico@hidronamic.com";
                    emisor = "Servicio Técnico";
                    clave = "stecnico2018";
                    break;
                case 2:
                    ruta = constanciaRPT.RutaPDFs() + idGenerado + ".pdf";
                    //myAttachment = new Attachment(constanciaRPT.RutaPDFs() + idGenerado + ".pdf");
                    correo = "ventas@hidronamic.com";
                    emisor = "Ventas Hidronamic";
                    clave = "comienzo2016";
                    EnviarCorreos(objEmail, correosLiq);
                    break;
                default:
                    ruta = constanciaRPT.RutaPDFs() + proforma + ".pdf";
                    //myAttachment = new Attachment(constanciaRPT.RutaPDFs() + proforma + ".pdf");
                    correo = "ventas@hidronamic.com";
                    emisor = "Ventas Hidronamic";
                    clave = "comienzo2016";
                    EnviarCorreos(objEmail, correos);
                    break;
            }
            myAttachment = new Attachment(ruta);

            objEmail.From = new MailAddress(correo, emisor, Encoding.UTF8); //CAMBIAR VENTAS O PROYECTO
            objEmail.IsBodyHtml = true;
            objEmail.Priority = MailPriority.Normal;

            Bitmap b = new Bitmap(Properties.Resources.logo_email);
            ImageConverter ic = new ImageConverter();
            Byte[] ba = (Byte[])ic.ConvertTo(b, typeof(Byte[]));
            MemoryStream logo = new MemoryStream(ba);

            string rutaLogo = cuerpoEmail.ToString() + "<img src=cid:logoEmpresa >";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(rutaLogo, null, MediaTypeNames.Text.Html);

            LinkedResource myLogo = new LinkedResource(logo, MediaTypeNames.Image.Jpeg);
            myLogo.ContentId = "logoEmpresa";
            htmlView.LinkedResources.Add(myLogo);

            objEmail.AlternateViews.Add(htmlView);

            if (string.IsNullOrWhiteSpace(emailDestinatario) == false)
            {
                objEmail.To.Add(Utilitarios.USUARIO_CORREO);
                //objEmail.To.Add(emailDestinatario);
            }
            else
            {
                objEmail.To.Add(Utilitarios.USUARIO_CORREO);
            }
            objEmail.Bcc.Add("lascencio753@gmail.com");
            objEmail.Subject = asuntoEmail;
            objEmail.Attachments.Add(myAttachment);

            SmtpClient objSmtp = new SmtpClient("smtp.gmail.com");
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.UseDefaultCredentials = false;
            objSmtp.Credentials = new NetworkCredential(correo, clave);
            //objSmtp.Credentials = new NetworkCredential("webmaster@hidronamic.com", "qw89-2J@KIW");
            objSmtp.Send(objEmail);
        }

        private void EnviarCorreos(MailMessage objEmail, List<string> lista)
        {
            for(int i = 0; i <= lista.Count - 1; i++)
            {
                objEmail.Bcc.Add(lista[i].ToString().Trim());
            }
            lista.Clear();
        }
    }
}