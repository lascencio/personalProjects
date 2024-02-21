using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lidoma_WebApplication.Entities
{
    public class entPrestamo
    {
        public string PRESTAMO { get; set; }
        public string TIPO_PRESTAMO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string MONEDA { get; set; }
        public decimal TASA_MOROSIDAD { get; set; }
        public decimal CAPITAL { get; set; }
        public decimal NUMERO_CUOTAS { get; set; }
        public decimal VALOR_CUOTA { get; set; }
        public decimal TOTAL_PRESTAMO { get; set; }

        public string s_TOTAL_PRESTAMO { get; set; }
    }
}