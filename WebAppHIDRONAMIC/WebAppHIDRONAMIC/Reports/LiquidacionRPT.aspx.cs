using Microsoft.Reporting.WebForms;
using System;
using System.Net;
using System.IO;
using WebAppHIDRONAMIC.Utils;

namespace WebAppHIDRONAMIC.Reports
{
    public partial class LiquidacionRPT : System.Web.UI.Page
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ShowRep("lascencio-001", "Liquidacion_M_RPT");
        }

        public void ShowRemotePDF(string idGenerado, string mes, string cliente, string anio,string rango1, string rango2)
        {
            if (!IsPostBack)
            {
                rpvLiquidacionM = new ReportViewer();
                rpvLiquidacionM.Reset();

                string reporterRemoto = "LiquidacionRPT";
                string nombrePath = "lascencio-001";


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("CLIENTE", cliente);
                parameters[1] = new ReportParameter("MES", mes);
                parameters[2] = new ReportParameter("ANIO", anio);
                parameters[3] = new ReportParameter("RANGO1", rango1);
                parameters[4] = new ReportParameter("RANGO2", rango2);

                try
                {
                    rpvLiquidacionM.Width = 793;
                    rpvLiquidacionM.Height = 1096;
                    IReportServerCredentials irsc = new CustomReportCredentials(@"lascencio-001", "TerminatorPony36", "ifc");
                    rpvLiquidacionM.ServerReport.ReportServerCredentials = irsc;


                    rpvLiquidacionM.ProcessingMode = ProcessingMode.Remote;

                    rpvLiquidacionM.ServerReport.ReportServerUrl = new Uri("http://sql5030.site4now.net/ReportServer");
                    rpvLiquidacionM.ServerReport.ReportPath = "/" + nombrePath + "/" + reporterRemoto;
                    rpvLiquidacionM.ServerReport.SetParameters(parameters);

                    rpvLiquidacionM.ServerReport.Refresh();

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;
                    byte[] bytes = rpvLiquidacionM.ServerReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                    try
                    {
                        FileStream fs = new FileStream(RutaPDFs() + idGenerado + ".pdf", FileMode.Create);
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
        }

        public string RutaPDFs()
        {
            return Server.MapPath("../UploadFiles/");
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
        //public void ShowLocalPDF(string cuenta_comercial, string mes, string idGenerado)
        //{
        //    string cliente = cuenta_comercial;
        //    string mesP = mes;
        //    string anio = "2018";
        //    string emisor = "LISSETTE LOPEZ";

        //    rpvLiquidacionM = new ReportViewer();
        //    rpvLiquidacionM.Reset();
        //    Datasource
        //    DataTable dtEstadoCuenta = EstadoCuenta();
        //    DataTable dtServicios = ECServicios();
        //    DataTable dtProductos = ECProductos();
        //    DataTable dtDiasPiscina = DiasPiscina();
        //    DataTable dtDiasSpa = DiasSpa();
        //    DataTable dtDiasEspejo = DiasEspejo();

        //    ReportDataSource rdsEstadoCuenta = new ReportDataSource("RdsEstadoCuenta", dtEstadoCuenta);
        //    ReportDataSource rdsServicios = new ReportDataSource("RdsECServicios", dtServicios);
        //    ReportDataSource rdsProductos = new ReportDataSource("RdsECProductos", dtProductos);
        //    ReportDataSource rdSP = new ReportDataSource("RdsDiasSpa", dtDiasSpa);
        //    ReportDataSource rdPI = new ReportDataSource("RdsDiasPiscina", dtDiasPiscina);
        //    ReportDataSource rdES = new ReportDataSource("RdsDiasEspejo", dtDiasEspejo);

        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdsEstadoCuenta);
        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdsServicios);
        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdsProductos);
        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdSP);
        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdPI);
        //    rpvLiquidacionM.LocalReport.DataSources.Add(rdES);

        //    rpvLiquidacionM.LocalReport.ReportPath = "Reports/ReportEstadoCuenta.rdlc";

        //    rpvLiquidacionM.LocalReport.Refresh();

        //    Warning[] warnings;
        //    string[] streamids;
        //    string mimeType;
        //    string encoding;
        //    string filenameExtension;
        //    byte[] bytes = rpvLiquidacionM.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        //    FileStream fs = new FileStream(RutaPDFs() + idGenerado + ".pdf", FileMode.Create);
        //    fs.Write(bytes, 0, bytes.Length);
        //    fs.Close();
        //}

        //private DataTable EstadoCuenta()
        //{
        //    conexion.cn.Open();
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.ESTADO_CUENTA_CABECERA", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    cmd.Parameters.AddWithValue("@EMISOR", emisor);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
        //private DataTable ECServicios()
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.E_C_SERVICIOS", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
        //private DataTable ECProductos()
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.E_C_PRODUCTOS", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
        //private DataTable DiasPiscina()
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.SERVICIOS_DIAS_PISCINA", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
        //private DataTable DiasSpa()
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.SERVICIOS_DIAS_SPA", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
        //private DataTable DiasEspejo()
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand("REP.SERVICIOS_DIAS_ESPEJO", conexion.cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
        //    cmd.Parameters.AddWithValue("@MES", mesP);
        //    cmd.Parameters.AddWithValue("@ANIO", anio);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    return dt;
        //}
    }
}