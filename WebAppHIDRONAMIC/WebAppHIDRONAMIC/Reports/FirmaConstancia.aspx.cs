using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WebAppHIDRONAMIC.Utils;
using System.Text;

namespace WebAppHIDRONAMIC.Reports
{
    public partial class FirmaConstancia : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQLRepositoryD"].ConnectionString);
        private string codigoNuevo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
            //Obtengo el el último correlativo de constancia
            string sql1 = "SELECT MAN.FUNC_CODIGO_CONSTANCIA()";
            string cod = "";
            using (SqlCommand cmd = new SqlCommand(sql1, cn))
            {
                cod = cmd.ExecuteScalar().ToString();
            }
            cn.Close();
            string resta = cod.Substring(3);
            long id = long.Parse(resta) - 1;
            codigoNuevo = Utilitarios.CorrelativoConstancia(id);
            Response.Write("<div style='display:none;'><label id='cod'>"+ codigoNuevo+ "</label></div>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string signature = hfimg.Value;
            if (!string.IsNullOrEmpty(signature.Trim()))
            {
                try
                {
                    cn.Open();
                    //realizo la conversion de la imagen a bytes
                    string concat = signature.Replace("data:image/png;base64,", "");
                    byte[] imageBytes = Convert.FromBase64String(concat);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    string sql = "UPDATE MAN.CONSTANCIAS SET FIRMA = @vIMAGEN, INDICA_FIRMA = @vINDICA WHERE CONSTANCIA = @vCONSTANCIA";

                    int result = 0;

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add("vIMAGEN", SqlDbType.Image).Value = imageBytes;
                        cmd.Parameters.AddWithValue("vINDICA", "SI");
                        cmd.Parameters.AddWithValue("vCONSTANCIA", codigoNuevo);
                        result = cmd.ExecuteNonQuery();
                    }

                    if (result > 0)
                    {
                        StringBuilder msg = new StringBuilder("<script>if(confirm('Firma Registrada!')){window.location.href = '/Constancia/Detalles?constancia=" + codigoNuevo + "';}");
                        msg.Append("else{window.location.href = '/Constancia/Detalles?constancia=" + codigoNuevo + "';}</script>");
                        Response.Write(msg.ToString());
                    }

                    else
                        Response.Write("<script>alert('Error al registrar firma...vuelva a intentarlo');</script>");
                }
                catch (Exception x)
                {
                    string s = x.Message;
                    Response.Write("<script>alert('error:   " + s + "');</script>");
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}