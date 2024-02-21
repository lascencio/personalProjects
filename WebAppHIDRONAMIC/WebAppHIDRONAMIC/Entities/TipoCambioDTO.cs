using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHIDRONAMIC.Entities
{
    public class TipoCambioDTO
    {
        public string EJERCICIO { set; get; }
        public string MES { set; get; }
        public string DIA { set; get; }
        public string MONEDA { set; get; }
        public decimal COMPRA { set; get; }
        public decimal VENTA { set; get; }
        public decimal PROMEDIO { set; get; }
        public decimal COMPRA_PREFERENCIAL { set; get; }
        public decimal VENTA_PREFERENCIAL { set; get; }
        public decimal COMPRA_REFERENCIAL { set; get; }
        public decimal VENTA_REFERENCIAL { set; get; }
        public string USUARIO_REGISTRO { set; get; }

        //ATRIBUTOS PARA DEFINIR TIPOS DE OPERACIONES SOBRE LA CLASE
        public string TIPO_OPERACION { get; set; }

    }
}