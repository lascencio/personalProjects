using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WebAppHIDRONAMIC.Entities
{
    public class PiscinaDTO
    {
        public string EMPRESA { get; set; }
        public string CUENTA_COMERCIAL { get; set; }
        public string UBICACION { get; set; }
        public string PISCINA { get; set; }
        public string FRECUENCIA { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public string FECHA_MODIFICA { get; set; }

        //ATRIBUTOS DE LA INFORMACION QUIMICA DE CADA PISCINA
        public string acido10 { get; set; }
        public string acido20 { get; set; }
        public string soda { get; set; }
        public string cloGra5 { get; set; }
        public string cloGra7 { get; set; }
        public string cloGra15 { get; set; }
        public string cloGra21 { get; set; }
        public string cloPas20 { get; set; }
        public string sulfAl10 { get; set; }
        public string sulfCo3 { get; set; }
        public string sulfCo10 { get; set; }
        public string piscSal3000 { get; set; }
        public string piscSal4000 { get; set; }

        //ATRIBUTOS EXTRAS
        public string s_LARGO { get; set; }
        public string s_ANCHO { get; set; }
        public string s_PROFUNDIDAD { get; set; }
        public string s_VOLUMEN { get; set; }
        public string s_FORMA_PISCINA { get; set; }
        public string s_TIPO_PISCINA { get; set; }
        public string s_FRECUENCIA_MANTENIMIENTO { get; set; }

        //ATRIBUTOS PRIVADAS
        private decimal m_VOLUMEN;
        private decimal m_PROFUNDIDAD;
        private decimal m_ANCHO;
        private decimal m_LARGO;
        private string m_FORMA_PISCINA;
        private string m_TIPO_PISCINA;


        public PiscinaDTO()
        {
            this.VOLUMEN = 0;
            this.PROFUNDIDAD = 0;
            this.ANCHO = 0;
            this.LARGO = 0;
            this.FORMA_PISCINA = null;
            this.TIPO_PISCINA = null;
        }

        public string TIPO_PISCINA
        {
            get { return m_TIPO_PISCINA; }
            set
            {
                m_TIPO_PISCINA = (String.IsNullOrEmpty(value) ? "RESIDENCIAL" : value);
            }
        }

        public string FORMA_PISCINA
        {
            get { return m_FORMA_PISCINA; }
            set
            {
                m_FORMA_PISCINA = (String.IsNullOrEmpty(value) ? "RECTANGULAR" : value);
            }
        }

        public decimal VOLUMEN
        {
            get { return m_VOLUMEN; }
            set
            {
                m_VOLUMEN = (string.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal PROFUNDIDAD
        {
            get { return m_PROFUNDIDAD; }
            set
            {
                m_PROFUNDIDAD = (string.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal ANCHO
        {
            get { return m_ANCHO; }
            set
            {
                m_ANCHO = (string.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal LARGO
        {
            get { return m_LARGO; }
            set
            {
                m_LARGO = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }


    }
}