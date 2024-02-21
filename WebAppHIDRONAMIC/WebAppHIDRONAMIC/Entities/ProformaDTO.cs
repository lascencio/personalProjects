using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WebAppHIDRONAMIC.Entities
{
    public class ProformaDTO
    {
        public string EMPRESA { get; set; }
        public string COTIZACION { get; set; }
        public string EJERCICIO { get; set; }
        public string MES { get; set; }
        public string CODIGO_VENDEDOR { get; set; }
        public string CENTRO_DISTRIBUCION { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public string ORDEN_PEDIDO { get; set; }
        public string USUARIO_APROBACION { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public string FECHA_MODIFICA { get; set; }

        //ATRIBUTOS DE TABLA COTIZACION_DATOS
        public string RAZON_SOCIAL { get; set; }
        public string DOMICILIO { get; set; }
        public string EMAIL { get; set; }

        private DateTime FechaNulo = DateTime.Parse("01/01/1900");
        private DateTime FechaActual = DateTime.Now;

        private string m_LISTA_PRECIOS;
        private string m_CUENTA_COMERCIAL;
        private string m_PISCINA;
        private string m_ESTADO;
        private string m_INDICA_CLIENTE_NUEVO;
        private decimal m_IMPORTE_TOTAL_ME;
        private decimal m_IMPORTE_TOTAL_MN;
        private DateTime m_FECHA_APROBACION;
        private decimal m_VOLUMEN;
        private decimal m_PROFUNDIDAD;
        private decimal m_ANCHO;
        private decimal m_LARGO;
        private decimal m_CAUDAL;
        private decimal m_TIEMPO_FILTRADO;
        private string m_TIPO_PISCINA;
        private string m_FORMA_PISCINA;
        private string m_COMENTARIO;
        private string m_CELULAR;
        private string m_TELEFONO;
        private DateTime m_COTIZACION_FECHA;
        private string m_TIPO_MONEDA;
        private string m_TIPO;
        private string m_REFERENCIA;
        private decimal m_DESCUENTO_GLOBAL;

        public ProformaDTO()
        {
            this.CUENTA_COMERCIAL = null;
            this.PISCINA = null;
            this.ESTADO = null;
            this.INDICA_CLIENTE_NUEVO = null;
            this.IMPORTE_TOTAL_MN = 0;
            this.IMPORTE_TOTAL_ME = 0;
            this.COMENTARIO = null;
            this.FECHA_APROBACION = FechaNulo;
            this.VOLUMEN = 0;
            this.ANCHO = 0;
            this.LARGO = 0;
            this.PROFUNDIDAD = 0;
            this.TIPO_PISCINA = null;
            this.FORMA_PISCINA = null;
            this.TIEMPO_FILTRADO = 0;
            this.CAUDAL = 0;
            this.TELEFONO = null;
            this.CELULAR = null;
            this.COTIZACION_FECHA = FechaActual;
            this.LISTA_PRECIOS = null;
            this.TIPO_MONEDA = null;
            this.TIPO = null;
            this.REFERENCIA = null;
            this.DESCUENTO_GLOBAL = 0;
        }

        public decimal DESCUENTO_GLOBAL
        {
            get { return m_DESCUENTO_GLOBAL; }
            set
            {
                m_DESCUENTO_GLOBAL = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public string REFERENCIA {
            get { return m_REFERENCIA; }
            set
            {
                m_REFERENCIA = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }

        public string TIPO
        {
            get { return m_TIPO; }
            set
            {
                m_TIPO = (String.IsNullOrEmpty(value) ? "263" : value);
            }
        }

        public string TIPO_MONEDA
        {
            get { return m_TIPO_MONEDA; }
            set
            {
                m_TIPO_MONEDA = (String.IsNullOrEmpty(value) ? "1" : value);
            }
        }

        public string LISTA_PRECIOS
        {
            get { return m_LISTA_PRECIOS; }
            set
            {
                m_LISTA_PRECIOS = (String.IsNullOrEmpty(value) ? "LP0000000000" : value);
            }
        }

        public DateTime COTIZACION_FECHA
        {
            get { return m_COTIZACION_FECHA; }
            set
            {
                m_COTIZACION_FECHA = ((value.Ticks == 0) ? FechaActual : value);
            }
        }
        public string TELEFONO
        {
            get { return m_TELEFONO; }
            set
            {
                m_TELEFONO = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }
        public string CELULAR
        {
            get { return m_CELULAR; }
            set
            {
                m_CELULAR = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value);
            }
        }
        public decimal TIEMPO_FILTRADO
        {
            get { return m_TIEMPO_FILTRADO; }
            set
            {
                m_TIEMPO_FILTRADO = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }
        public decimal CAUDAL
        {
            get { return m_CAUDAL; }
            set
            {
                m_CAUDAL = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
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
        public decimal PROFUNDIDAD
        {
            get { return m_PROFUNDIDAD; }
            set
            {
                m_PROFUNDIDAD = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal ANCHO
        {
            get { return m_ANCHO; }
            set
            {
                m_ANCHO = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal VOLUMEN
        {
            get { return m_VOLUMEN; }
            set
            {
                m_VOLUMEN = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public string TIPO_PISCINA
        {
            get { return m_TIPO_PISCINA; }
            set
            {
                m_TIPO_PISCINA = (String.IsNullOrEmpty(value) ? "PISCINA" : value);
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

        public DateTime FECHA_APROBACION
        {
            get { return m_FECHA_APROBACION; }
            set
            {
                m_FECHA_APROBACION = ((value.Ticks == 0) ? FechaActual : value);
            }
        }

        public decimal IMPORTE_TOTAL_MN
        {
            get { return m_IMPORTE_TOTAL_MN; }
            set
            {
                m_IMPORTE_TOTAL_MN = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public decimal IMPORTE_TOTAL_ME
        {
            get { return m_IMPORTE_TOTAL_ME; }
            set
            {
                m_IMPORTE_TOTAL_ME = (String.IsNullOrEmpty(value.ToString()) ? 0 : value);
            }
        }

        public string INDICA_CLIENTE_NUEVO
        {
            get { return m_INDICA_CLIENTE_NUEVO; }
            set
            {
                m_INDICA_CLIENTE_NUEVO = (String.IsNullOrEmpty(value) ? "SI" : value);
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

        public string CUENTA_COMERCIAL
        {
            get { return m_CUENTA_COMERCIAL; }
            set
            {
                m_CUENTA_COMERCIAL = (String.IsNullOrEmpty(value) ? "G0000000" : value);
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

        public string ESTADO
        {
            get { return m_ESTADO; }
            set
            {
                m_ESTADO = (String.IsNullOrEmpty(value) ? "P" : value);
            }
        }

    }
}