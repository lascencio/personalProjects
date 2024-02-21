using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace WebAppHIDRONAMIC.Entities
{
    public class ConstanciaDTO
    {
        public string EMPRESA { get; set; }
        public string CONSTANCIA { get; set; }
        public string CUENTA_COMERCIAL { get; set; }
        public string INDICA_CLIENTE { get; set; }
        public string PISCINA { get; set; }
        public decimal NIVEL_CLORO { get; set; }
        public decimal VALOR_TOTAL { get; set; }
        public decimal NIVEL_PH { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public string FECHA_MODIFICA { get; set; }

        //public byte[] FIRMA { get; set; }

        //ATRIBUTOS OPCIONALES
        public string RAZON_C { get; set; }
        public string DOMICILIO_C { get; set; }

        private string m_REFERENCIA_NOMBRE;
        private string m_REFERENCIA_DNI;
        private string m_COMENTARIO;
        private string m_ESTADO;
        private string m_INDICA_CONDICION;
        private string m_INDICA_PISCINA;
        private string m_INDICA_SAUNA;
        private string m_INDICA_PRESSION;
        private string m_INDICA_INCENDIO;
        private string m_INDICA_FIRMA;
        public ConstanciaDTO()
        {
            this.COMENTARIO = null;
            this.ESTADO = null;
            this.INDICA_CONDICION = null;
            this.INDICA_PISCINA = null;
            this.INDICA_SAUNA = null;
            this.INDICA_PRESION = null;
            this.INDICA_INCENDIO = null;
            this.REFERENCIA_DNI = null;
            this.REFERENCIA_NOMBRE = null;
            this.INDICA_FIRMA = null;
        }

        public string INDICA_FIRMA
        {
            get { return m_INDICA_FIRMA; }
            set
            {
                m_INDICA_FIRMA = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }

        public string REFERENCIA_NOMBRE {
            get { return m_REFERENCIA_NOMBRE; }
            set
            {
                m_REFERENCIA_NOMBRE = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string REFERENCIA_DNI {
            get { return m_REFERENCIA_DNI; }
            set
            {
                m_REFERENCIA_DNI = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string INDICA_CONDICION
        {
            get { return m_INDICA_CONDICION; }
            set
            {
                m_INDICA_CONDICION = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }
        public string INDICA_PISCINA
        {
            get { return m_INDICA_PISCINA; }
            set
            {
                m_INDICA_PISCINA = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }
        public string INDICA_SAUNA
        {
            get { return m_INDICA_SAUNA; }
            set
            {
                m_INDICA_SAUNA = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }
        public string INDICA_PRESION
        {
            get { return m_INDICA_PRESSION; }
            set
            {
                m_INDICA_PRESSION = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }

        public string INDICA_INCENDIO
        {
            get { return m_INDICA_INCENDIO; }
            set
            {
                m_INDICA_INCENDIO = (String.IsNullOrEmpty(value) ? "NO" : value);
            }
        }

        public string ESTADO
        {
            get { return m_ESTADO; }
            set
            {
                m_ESTADO = (String.IsNullOrEmpty(value) ? "A" : value);
            }
        }

        public string COMENTARIO
        {
            get { return m_COMENTARIO; }
            set
            {
                m_COMENTARIO = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

    }
}