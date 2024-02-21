using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace Lidoma_WebApplication.Entities
{
    public class entUsuario
    {
        private string m_empresa;
        private string m_usuario;
        private string m_descripcion;
        private string m_clave;
        private string m_periodo_actual;
        private string m_email;
        private string m_perfil;
        private decimal m_aprobar_mn;
        private decimal m_aprobar_me;
        private int m_privilegios;
        private bool m_es_plantilla;
        private bool m_emite_ticket;
        private string m_estado;
        private bool m_es_conforme;
        private bool m_cambiar_clave;
        private string m_ejercicio;
        private int m_mes;
        private string m_ejercicio_anterior;
        private int m_mes_anterior;
        private string m_serie_asignada;
        private string m_almacen;

        public entUsuario()
        {
            this.empresa = null;
            this.usuario = null;
            this.descripcion = null;
            this.clave = null;
            this.periodo_actual = null;
            this.email = null;
            this.perfil = null;
            this.aprobar_mn = 0;
            this.aprobar_me = 0;
            this.privilegios = 0;
            this.es_plantilla = false;
            this.emite_ticket = false;
            this.estado = null;
            this.es_conforme = false;
            this.cambiar_clave = false;
            this.ejercicio = null;
            this.mes = 0;
            this.ejercicio_anterior = null;
            this.mes_anterior = 0;
            this.serie_asignada = null;
            this.almacen = null;
        }

        public string empresa
        {
            get { return m_empresa; }
            set
            {
                m_empresa = value;
            }
        }

        public string usuario
        {
            get { return m_usuario; }
            set
            {
                m_usuario = value;
            }
        }

        public string descripcion
        {
            get { return m_descripcion; }
            set
            {
                m_descripcion = value;
            }
        }

        public string clave
        {
            get { return m_clave; }
            set
            {
                m_clave = value;
            }
        }

        public string email
        {
            get { return m_email; }
            set
            {
                m_email = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string perfil
        {
            get { return m_perfil; }
            set
            {
                m_perfil = (String.IsNullOrEmpty(value) ? usuario : value);
            }
        }

        public decimal aprobar_mn
        {
            get { return m_aprobar_mn; }
            set
            {
                m_aprobar_mn = value == 0 ? 0 : value;
            }
        }

        public decimal aprobar_me
        {
            get { return m_aprobar_me; }
            set
            {
                m_aprobar_me = value == 0 ? 0 : value;
            }
        }

        public int privilegios
        {
            get { return m_privilegios; }
            set
            {
                m_privilegios = value == 0 ? 4 : value;
            }
        }

        public bool es_plantilla
        {
            get { return m_es_plantilla; }
            set
            {
                m_es_plantilla = value = false ? false : value;
            }
        }

        public bool emite_ticket
        {
            get { return m_emite_ticket; }
            set
            {
                m_emite_ticket = value = false ? false : value;
            }
        }

        public string estado
        {
            get { return m_estado; }
            set
            {
                m_estado = (String.IsNullOrEmpty(value) ? "INA" : value);
            }
        }

        public bool es_conforme
        {
            get { return m_es_conforme; }
            set
            {
                m_es_conforme = value = false ? false : value;
            }
        }

        public bool cambiar_clave
        {
            get { return m_cambiar_clave; }
            set
            {
                m_cambiar_clave = value = false ? false : value;
            }
        }

        public string ejercicio
        {
            get { return m_ejercicio; }
            set
            {
                m_ejercicio = (String.IsNullOrEmpty(value) ? DateTime.Now.Year.ToString() : value);
            }
        }

        public int mes
        {
            get { return m_mes; }
            set
            {
                m_mes = value == 0 ? DateTime.Now.Month : value;
            }
        }

        public string periodo_actual
        {
            get { return m_periodo_actual; }
            set
            {
                m_periodo_actual = (String.IsNullOrEmpty(value) ? String.Concat(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("00")) : value);
            }
        }

        public string ejercicio_anterior
        {
            get { return m_ejercicio_anterior; }
            set
            {
                m_ejercicio_anterior = (String.IsNullOrEmpty(value) ? DateTime.Now.Year.ToString() : value);
            }
        }

        public int mes_anterior
        {
            get { return m_mes_anterior; }
            set
            {
                m_mes_anterior = value == 0 ? DateTime.Now.Month : value;
            }
        }

        public string serie_asignada
        {
            get { return m_serie_asignada; }
            set
            {
                m_serie_asignada = (String.IsNullOrEmpty(value) ? "1" : value);
            }
        }

        public string almacen
        {
            get { return m_almacen; }
            set
            {
                m_almacen = (String.IsNullOrEmpty(value) ? "001" : value);
            }
        }


    }
}