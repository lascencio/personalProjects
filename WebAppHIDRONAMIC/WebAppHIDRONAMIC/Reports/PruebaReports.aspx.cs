using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using WebAppHIDRONAMIC.Utils;
using System.IO;

namespace WebAppHIDRONAMIC.Reports
{
    public partial class PruebaReports : System.Web.UI.Page
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        public string RutaPDFs()
        {
            return Server.MapPath("../UploadFiles/");
        }

        public void PDFConstancia(string constancia)
        {
            rvConstancia = new ReportViewer();
            rvConstancia.Reset();
            //Datasource
            DataTable dt = GetConstanciaCab(constancia);
            DataTable dt2 = GetConstanciaDet(constancia);

            ReportDataSource rds = new ReportDataSource("RdsConstancia", dt);
            ReportDataSource rds2 = new ReportDataSource("RdsConstanciaDetalles", dt2);

            rvConstancia.LocalReport.DataSources.Add(rds);
            rvConstancia.LocalReport.DataSources.Add(rds2);

            rvConstancia.LocalReport.ReportPath = "Reports/ReportConstancia.rdlc";

            rvConstancia.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvConstancia.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            FileStream fs = new FileStream(RutaPDFs() + constancia + ".pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        private DataTable GetConstanciaCab(string constancia)
        {
            conexion.cn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REP.CONSTANCIA_CABECERA", conexion.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CONSTANCIA", constancia);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
        private DataTable GetConstanciaDet(string constancia)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REP.CONSTANCIA_DETALLES", conexion.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CONSTANCIA", constancia);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

    }
}