using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class entConstanciaServicio
    {
        [DisplayName("EMPRESA")]
        public string empresa { get; set; }

        [DisplayName("N° CONSTANCIA")]
        public string mantenimiento { get; set; }

        [DisplayName("CLIENTE")]
        public string cuenta_comercial { get; set; }

        [DisplayName("FECHA")]
        public DateTime fecha { get; set; }

        [DisplayName("USUARIO")]
        public string trabajador { get; set; }

        [DisplayName("COMENTARIO")]
        public string comentario { get; set; }

        [DisplayName("ESTADO")]
        public string estado { get; set; }

        [DisplayName("INDICA CLIENTE")]
        public string indica_cliente { get; set; }

        [DisplayName("USUARIO REGISTRO")]
        public string usuario_registro { get; set; }

        [DisplayName("FECHA_REGISTRO")]
        public DateTime fecha_registro { get; set; }

        [DisplayName("USUARIO_MODIFICA")]
        public string usuario_modifica { get; set; }

        [DisplayName("FECHA_MODIFICA")]
        public DateTime fecha_modifica { get; set; }
    }
}
