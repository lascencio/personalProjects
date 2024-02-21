using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WebAppHIDRONAMIC.Entities
{
    public class UsuarioDTO
    {
        public string DNI { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_CORTO { get; set; }
        public string NOMBRE_LARGO { get; set; }
        public string CLAVE { get; set; }
        public string EMAIL { get; set; }
        public string EMPRESA { get; set; }
        public string PERFIL { get; set; }

        private string m_ESTADO;
        private string m_PRIVILEGIOS;
        public UsuarioDTO()
        {
            this.ESTADO = null;
            this.PRIVILEGIOS = null;
        }

        public string ESTADO
        {
            get { return m_ESTADO; }
            set
            {
                m_ESTADO = (String.IsNullOrEmpty(value) ? "A" : value);
            }
        }

        public string PRIVILEGIOS
        {
            get { return m_PRIVILEGIOS; }
            set
            {
                m_PRIVILEGIOS = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

    }
}