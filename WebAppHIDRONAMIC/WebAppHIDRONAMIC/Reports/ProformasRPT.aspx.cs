using System;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using WebAppHIDRONAMIC.Utils;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace WebAppHIDRONAMIC.Reports
{
    public partial class ProformasRPT : System.Web.UI.Page
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

        public void ShowRemotePDF(string proforma)
        {
            //string msg = null;
            string reporterRemoto = "ProformaRPT";
            string nombrePath = "lascencio-001";
            //try
            //{
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("PROFORMA", proforma);

            rvProforma = new ReportViewer();
            rvProforma.Reset();

            rvProforma.Width = 793;
            rvProforma.Height = 1096;
            IReportServerCredentials irsc = new CustomReportCredentials(@"lascencio-001", "TerminatorPony36", "ifc");
            rvProforma.ServerReport.ReportServerCredentials = irsc;


            rvProforma.ProcessingMode = ProcessingMode.Remote;

            rvProforma.ServerReport.ReportServerUrl = new Uri("http://sql5030.site4now.net/ReportServer");
            rvProforma.ServerReport.ReportPath = "/" + nombrePath + "/" + reporterRemoto;
            rvProforma.ServerReport.SetParameters(parameters);
            rvProforma.ServerReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvProforma.ServerReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            FileStream fs = new FileStream(RutaPDFs() + proforma + ".pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
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

        //******Métodos para trabajar en el servidor de reportes local(Pruebas)******//
        public void ShowLocalPDF(string proforma, string moneda)
        {
            rvProforma = new ReportViewer();
            rvProforma.Reset();
            //Datasource
            DataTable dt = GetProformaDat(proforma, moneda);

            ReportDataSource rds = new ReportDataSource("RdsCotizacionCabDatos", dt);

            rvProforma.LocalReport.DataSources.Add(rds);

            rvProforma.LocalReport.ReportPath = "Reports/ReportProformas.rdlc";

            rvProforma.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvProforma.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            FileStream fs = new FileStream(RutaPDFs() + proforma + ".pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        private DataTable GetProformaDat(string proformas, string moneda)
        {
            conexion.cn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REP.COTIZACION_CAB_DATOS", conexion.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROFORMA", proformas);
            cmd.Parameters.AddWithValue("@TIPO_MONEDA", moneda);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}