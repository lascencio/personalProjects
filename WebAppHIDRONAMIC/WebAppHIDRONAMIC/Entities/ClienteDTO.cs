using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace WebAppHIDRONAMIC.Entities
{
    public class ClienteDTO
    {
        public string CUENTA_COMERCIAL { get; set; }

        public string TIPO_DOCUMENTO { get; set; }

        [RegularExpression("[0-9]*$", ErrorMessage = "Ingresa sólo dígitos")]
        public string NRO_DOCUMENTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DOMICILIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string INDICA_PISCINA { get; set; }
        public string INDICA_POST_VENTA { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }

        [RegularExpression("^[\\w-]+(\\.[\\w-]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Ingresa formato correcto.")]
        public string EMAIL { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public string FECHA_MODIFICA { get; set; }
        public int CANTIDAD_PISCINAS { get; set; }

        //ATRIBUTOS OPCIONALES EN CASO DE POSEER PISCINA
        public string TIPO_PISCINA { get; set; }
        public string FORMA_PISCINA { get; set; }
        public string LARGO_PISCINA { get; set; }
        public string ANCHO_PISCINA { get; set; }
        public string PROFUNDIDAD_PISCINA { get; set; }
        public string VOLUMEN_PISCINA { get; set; }

        private string m_TELEFONO;
        private string m_CELULAR;
        private string m_ALIAS;
        private string m_PISCINA;

        public ClienteDTO()
        {
            this.CELULAR = null;
            this.TELEFONO = null;
            this.ALIAS = null;
            this.PISCINA = null;
        }

        [RegularExpression("[0-9]*$", ErrorMessage = "Ingresa sólo dígitos")]
        public string CELULAR
        {
            get { return m_CELULAR; }
            set
            {
                m_CELULAR = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        [RegularExpression("[0-9]*$", ErrorMessage = "Ingresa sólo dígitos")]
        public string TELEFONO
        {
            get { return m_TELEFONO; }
            set
            {
                m_TELEFONO = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string ALIAS
        {
            get { return m_ALIAS; }
            set
            {
                m_ALIAS = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string PISCINA
        {
            get { return m_PISCINA; }
            set
            {
                m_PISCINA = (String.IsNullOrEmpty(value) ? "P0000000" : value);
            }
        }

    }
}