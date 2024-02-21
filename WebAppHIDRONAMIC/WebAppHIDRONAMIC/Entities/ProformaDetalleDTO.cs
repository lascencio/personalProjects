using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHIDRONAMIC.Entities
{
    public class ProformaDetalleDTO
    {
        public string EMPRESA { get; set; }
        public string COTIZACION { get; set; }
        public string PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int CANTIDAD { get; set; }
        public decimal PRECIO_UNITARIO_MN { get; set; }
        public decimal PRECIO_UNITARIO_ME { get; set; }
        public decimal IMPORTE_TOTAL_MN { get; set; }
        public decimal IMPORTE_TOTAL_ME { get; set; }
        public string COMENTARIO { get; set; }
        public string INDICA_DESCUENTO { get; set; }
        public decimal DESCUENTO_PORCENTUAL { get; set; }
        public string ESTADO { get; set; }
        public string FAMILIA { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }

    }
}