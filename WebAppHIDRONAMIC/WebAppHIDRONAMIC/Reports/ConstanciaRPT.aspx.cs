using System;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using WebAppHIDRONAMIC.Utils;
using System.IO;
using System.Net;

namespace WebAppHIDRONAMIC.Reports
{
    public partial class ConstanciaRPT : System.Web.UI.Page
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowLocalPDF(string constancia)
        {
            PDFConstancia(constancia);
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            string constancia = "ST-000000090";
            try { PDFConstancia(constancia); }
            catch (Exception x)
            {
                string msg = x.Message;
            }
        }

        public string RutaPDFs()
        {
            return Server.MapPath("../UploadFiles/");
        }

        public void ShowRemotePDF(string constancia)
        {
            //string constancia = Request.QueryString["constancia"];
            string reporterRemoto = "ConstanciaRPT";
            string nombrePath = "lascencio-001";
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("CONSTANCIA", constancia);

            try
            {
                rvConstancia = new ReportViewer();
                rvConstancia.Reset();

                rvConstancia.Width = 793;
                rvConstancia.Height = 1096;
                IReportServerCredentials irsc = new CustomReportCredentials(@"lascencio-001", "TerminatorPony36", "ifc");
                rvConstancia.ServerReport.ReportServerCredentials = irsc;


                rvConstancia.ProcessingMode = ProcessingMode.Remote;

                rvConstancia.ServerReport.ReportServerUrl = new Uri("http://sql5030.site4now.net/ReportServer");
                rvConstancia.ServerReport.ReportPath = "/" + nombrePath + "/" + reporterRemoto;
                rvConstancia.ServerReport.SetParameters(parameters);
                rvConstancia.ServerReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;
                byte[] bytes = rvConstancia.ServerReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                try
                {
                    FileStream fs = new FileStream(RutaPDFs() + constancia + ".pdf", FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }

        public class CustomReportCredentials : IReportServerCredentials
        {
            private string _UserName;
            private string _PassWord;
            private string _DomainName;

            public CustomReportCredentials(string UserName, string PassWord, string DomainName)
            {
                _UserName = UserName;
                _PassWord = PassWord;
                _DomainName = DomainName;
            }

            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get { return null; }
            }

            public ICredentials NetworkCredentials
            {
                get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
            }

            public bool GetFormsCredentials(out Cookie authCookie, out string user,
             out string password, out string authority)
            {
                authCookie = null;
                user = password = authority = null;
                return false;
            }
        }

        //******MÉTODOS PARA TRABAJAR CON EL SERVIDOR DE REPORTE LOCAL(PRUEBAS)*****//
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

            /*-------------------------------------*/
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = rvConstancia.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            FileStream fs = new FileStream(RutaPDFs() + constancia + ".pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            /*-------------------------------------*/
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