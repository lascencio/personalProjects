using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using WebAppHIDRONAMIC.Reports;

namespace WebAppHIDRONAMIC.Utils
{
    public static class Utilitarios
    {
        static SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQLRepositoryD"].ConnectionString);
        //static ConstanciaRPT rpt = new ConstanciaRPT();
        public static string USUARIO_REGISTRO = "SISTEMAS";
        public static string USUARIO_CORREO = "l.lopez@hidronamic.com";

        public static string EMPRESA = "001";
        //public static string DOCUMENTS_PATH = rpt.RutaPDFs();
        public static string DOCUMENTS_PATH = "";
        private static readonly Random getRandom2 = new Random();
        private static readonly Random getRandom1 = new Random();
        private static string[] cadenaFecha = DateTime.Today.ToString("dd/MM/yyyy").Split('/');
        public static decimal TIPO_CAMBIO = 0;
        //First date current week
        public static string fdcw = FormatoFecha_AMD(FirstDateCurWeek().ToShortDateString());
        //Last date current week
        public static string ldcw = FormatoFecha_AMD(LastDateCurWeek().ToShortDateString());
        //First date last week
        public static string fdlw = FormatoFecha_AMD(FirstDateLastWeek().ToShortDateString());
        //Last date last week
        public static string ldlw = FormatoFecha_AMD(LastDateLastWeek().ToShortDateString());
        public static int Aleatorio1()
        {
            lock (getRandom1)
            {
                return getRandom1.Next(1111, 5555);
            }
        }
        public static int Aleatorio2()
        {
            lock (getRandom2)
            {
                return getRandom2.Next(6666, 9999);
            }
        }
        public static string AutoGeneradoLiq()
        {
            return "EC-" + Aleatorio1() + Aleatorio2();
        }
        public static decimal AplicarDescuento(decimal precio, decimal descuento)
        {
            return FormatoDecimal(precio - (precio * (descuento / 100)));
        }
        public static string Ejercicio()
        {
            return cadenaFecha[2];
        }
        public static decimal CambioSoles(decimal valor)
        {
            return FormatoDecimal(TIPO_CAMBIO * valor);
        }
        public static string CorrelativoPiscina(long numero)
        {
            string cadena = numero.ToString();
            switch (cadena.Length)
            {
                case 1:
                    return "P000000" + cadena;
                case 2:
                    return "P00000" + cadena;
                case 3:
                    return "P0000" + cadena;
                case 4:
                    return "P000" + cadena;
                case 5:
                    return "P00" + cadena;
                case 6:
                    return "P0" + cadena;
                default:
                    return "P" + cadena;
            }
        }
        public static string CorrelativoConstancia(long numero)
        {
            string cadena = numero.ToString();
            switch (cadena.Length)
            {
                case 1:
                    return "ST-00000000" + cadena;
                case 2:
                    return "ST-0000000" + cadena;
                case 3:
                    return "ST-000000" + cadena;
                case 4:
                    return "ST-00000" + cadena;
                case 5:
                    return "ST-0000" + cadena;
                case 6:
                    return "ST-000" + cadena;
                case 7:
                    return "ST-00" + cadena;
                case 8:
                    return "ST-0" + cadena;
                default:
                    return "ST-" + cadena;
            }
        }
        public static string DatetimeToDate(string datetime)
        {
            string[] fecha = datetime.Split(' ');
            return fecha[0];
        }
        public static DateTime FirstDateCurWeek()
        {
            var now = System.DateTime.Now;
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - now.DayOfWeek;
            DateTime fdowDate = now.AddDays(offset);
            return fdowDate;
        }
        public static DateTime FirstDateLastWeek()
        {
            int days = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            DateTime pastDate = DateTime.Now.AddDays(-(days + 7));
            return pastDate;
        }
        public static string FormatoHora(string fecha)
        {//12:42PM
            string[] cadena = fecha.Trim().Split(':');
            string minutos = cadena[1].Substring(0, 2);
            string tiempo = cadena[1].Substring(2);
            string hora = cadena[0];
            switch (hora)
            {
                case "1":
                    return "03:" + minutos + " " + tiempo;
                    break;
                case "2":
                    return "04:" + minutos + " " + tiempo;
                    break;
                case "3":
                    return "05:" + minutos + " " + tiempo;
                    break;
                case "4":
                    return "06:" + minutos + " " + tiempo;
                    break;
                case "5":
                    return "07:" + minutos + " " + tiempo;
                    break;
                case "6":
                    return "08:" + minutos + " " + tiempo;
                    break;
                case "7":
                    return "09:" + minutos + " " + tiempo;
                    break;
                case "8":
                    return "10:" + minutos + " " + tiempo;
                    break;
                case "9":
                    return "11:" + minutos + " " + tiempo;
                    break;
                case "10":
                    return "12:" + minutos + " " + tiempo;
                    break;
                case "11":
                    if (tiempo.Equals("AM"))
                        return "01:" + minutos + " PM";
                    else
                        return "01:" + minutos + " AM";
                    break;
                case "12":
                    if (tiempo.Equals("AM"))
                        return "02:" + minutos + " PM";
                    else
                        return "02:" + minutos + " AM";
                    break;
                default:
                    return "00:" + "00PM";
                    break;
            }
        }
        public static string FormatoFecha_AMD(string fechas)
        {
            string[] fecha = fechas.Split('/');
            return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        }
        public static string FormatoFecha_DMA(string fechas)
        {
            string[] fecha = fechas.Split('/');
            return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        }
        public static string FrecuenciaMant(string frecuenia)
        {
            switch (frecuenia)
            {
                case "QUI":
                    return "QUINCENAL";
                case "SEM":
                    return "SEMANAL";
                default:
                    return "MENSUAL";
            }
        }
        public static decimal FormatoDecimal(decimal monto)
        {
            return decimal.Parse(monto.ToString("#.##"));
        }
        public static string HallarTipoPiscina(string tipo_piscina)
        {
            switch (tipo_piscina)
            {
                case "PI":
                    return "PISCINA";
                case "SP":
                    return "SPA";
                default:
                    return "ESPEJO";
            }
        }
        public static string HallarFamilia(string familia)
        {
            switch (familia)
            {
                case "1041":
                    return "C";
                case "1049":
                    return "E";
                case "1043":
                    return "I";
                case "1046":
                    return "T";
                case "1047":
                    return "A";
                default:
                    return "L";
            }
        }
        public static string Mes()
        {
            return cadenaFecha[1];
        }
        public static DateTime LastDateCurWeek()
        {
            DateTime ldowDate = FirstDateCurWeek().AddDays(6);
            return ldowDate;
        }
        public static DateTime LastDateLastWeek()
        {
            return FirstDateLastWeek().AddDays(6);
        }
        public static void ObtenerDataTableSQL(string myStringCommand, DataTable myDataTable)
        {
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(myStringCommand, conexion);
            myDataAdapter.Fill(myDataTable);
        }
        public static void ObtenerDT_Servicios(string myStringCommand, DataTable myDataTable, string tipo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(myStringCommand, conexion);
            cmd.Parameters.AddWithValue("@TIPO", tipo);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(myDataTable);
        }
        public static string SubStrings(string cadena, int startIndex, int length)
        {
            return cadena.Substring(startIndex, length);
        }
    }
}