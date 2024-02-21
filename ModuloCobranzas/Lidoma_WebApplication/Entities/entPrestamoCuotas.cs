using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lidoma_WebApplication.Entities
{
    public class entPrestamoCuotas
    {
        public string NUMERO_CUOTA { get; set; }
        public string FECHA_VENCIMIENTO { get; set; }
        public decimal VALOR_CUOTA { get; set; }
        public string FECHA_PAGO { get; set; }
        public decimal SALDO_CUOTA { get; set; }
        public decimal DIAS_MORA { get; set; }
        public decimal MORA { get; set; }
        public decimal CUOTA_PAGO { get; set; }
        public decimal MORA_PAGO { get; set; }
        public decimal TOTAL_PAGO { get; set; }

        //Formatear los decimales para mostrarlos al usuario
        public string s_CUOTA_PAGO {get;set;}

        public string s_MORA { get; set; }

        public string s_TOTAL_PAGO {get;set;}

    }
}