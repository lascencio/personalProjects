using System;

namespace WebAppHIDRONAMIC.Entities
{
    public class ConstanciaDetalleDTO
    {
        public string EMPRESA { get; set; }
        public string CONSTANCIA { get; set; }
        public string SERVICIO { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal VALOR_UNITARIO { get; set; }
        public decimal VALOR_TOTAL { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }

        public string TIPO { get; set; }

        private string m_ESTADO;

        public ConstanciaDetalleDTO()
        {
            this.ESTADO = null;
        }
        public string ESTADO
        {
            get { return m_ESTADO; }
            set
            {
                m_ESTADO = (String.IsNullOrEmpty(value) ? "A" : value);
            }
        }
    }
}