using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lidoma_WebApplication.Entities
{
    public class entCuentaComercial
    {
        private string m_empresa;
        private string m_cuenta_comercial;
        private string m_grupo_comercial;
        private string m_tipo_cuenta;
        private string m_tipo_documento;
        private string m_nro_documento;
        private string m_razon_social;
        private string m_siglas;
        private string m_via_tipo;
        private string m_via_nombre;
        private string m_via_numero;
        private string m_via_interior;
        private string m_zona_tipo;
        private string m_zona_nombre;
        private string m_referencia;
        private string m_pais;
        private string m_departamento;
        private string m_provincia;
        private string m_ubigeo;
        private string m_indica_no_domiciliado;
        private string m_domicilio_envio;
        private string m_domicilio;
        private string m_codigo_postal;
        private string m_telefono;
        private string m_telefono_otro;
        private string m_celular;
        private string m_fax;
        private string m_email;
        private string m_pagina_web;
        private string m_direccion_trabajo;
        private string m_referencia_trabajo;
        private string m_telefono_trabajo;
        private string m_tipo_moneda;
        private string m_contacto_comercial;
        private string m_condicion_pago;
        private string m_forma_pago;
        private string m_documento_pago;
        private decimal m_linea_credito_mn;
        private decimal m_linea_credito_me;
        private decimal m_saldo_pagar_mn;
        private decimal m_saldo_pagar_me;
        private string m_vigencia_credito;
        private string m_lista_precios;
        private decimal m_porcentaje_descuento_1;
        private decimal m_porcentaje_descuento_2;
        private decimal m_porcentaje_descuento_3;
        private string m_cuenta_contable_cliente_mn;
        private string m_cuenta_contable_cliente_me;
        private string m_cuenta_contable_proveedor_mn;
        private string m_cuenta_contable_proveedor_me;
        private string m_cuenta_contable_ingreso;
        private string m_cuenta_contable_gasto;
        private string m_cuenta_bancaria_mn;
        private string m_cuenta_bancaria_me;
        private string m_banco_pago_mn;
        private string m_banco_pago_me;
        private string m_tipo_contable;
        private string m_vigente_sunat;
        private string m_fecha_alta_sunat;
        private string m_afecto_igv;
        private string m_agente_retencion;
        private string m_agente_detraccion;
        private string m_agente_percepcion;
        private decimal m_porcentaje_detraccion;
        private string m_cuenta_detraccion;
        private string m_indica_cliente;
        private string m_indica_proveedor;
        private string m_codigo_vendedor;
        private string m_codigo_comprador;
        private string m_ultima_compra;
        private string m_ultima_venta;
        private string m_apellido_paterno;
        private string m_apellido_materno;
        private string m_apellido_casada;
        private string m_nombres;
        private string m_fecha_nacimiento;
        private string m_sexo;

        private string m_estado_civil;
        private string m_nivel_educativo;
        private string m_ocupacion;
        private string m_situacion_crediticia;

        private string m_calificacion;

        private string m_indica_preferente;
        private string m_indica_fallecido;
        private string m_exige_garante;

        private string m_zona_comercial;
        private string m_comentario;
        private string m_usuario_web;
        private string m_clave_web;
        private string m_codigo_antiguo;
        private string m_item_flujo;
        private string m_exige_orden_compra;
        private string m_tipo_orden_compra;
        private string m_exige_orden_pago;
        private string m_tipo_orden_pago;
        private string m_estado;

        private string m_agencia_registro;

        private string m_usuario_registro;
        private string m_fecha_registro;

        private string m_agencia_modifica;

        private string m_usuario_modifica;
        private string m_fecha_modifica;

        private string m_usuario_aprobacion;
        private string m_fecha_aprobacion;

        private string m_ultimo_producto_codigo;
        private string m_ultimo_producto_fecha;

        private string m_nombre_conviviente;

        public entCuentaComercial()
        {
            this.empresa = null;
            this.cuenta_comercial = null;
            this.grupo_comercial = null;
            this.tipo_cuenta = null;
            this.tipo_documento = null;
            this.nro_documento = null;
            this.razon_social = null;
            this.siglas = null;
            this.via_tipo = null;
            this.via_nombre = null;
            this.via_numero = null;
            this.via_interior = null;
            this.zona_tipo = null;
            this.zona_nombre = null;
            this.referencia = null;
            this.pais = null;
            this.departamento = null;
            this.provincia = null;
            this.ubigeo = null;
            this.indica_no_domiciliado = null;
            this.domicilio_envio = null;
            this.domicilio = null;
            this.codigo_postal = null;
            this.telefono = null;
            this.telefono_otro = null;
            this.celular = null;
            this.fax = null;
            this.email = null;
            this.pagina_web = null;
            this.direccion_trabajo = null;
            this.referencia_trabajo = null;
            this.telefono_trabajo = null;
            this.tipo_moneda = null;
            this.contacto_comercial = null;
            this.condicion_pago = null;
            this.forma_pago = null;
            this.documento_pago = null;
            this.linea_credito_mn = 0;
            this.linea_credito_me = 0;
            this.saldo_pagar_mn = 0;
            this.saldo_pagar_me = 0;
            this.vigencia_credito = null;
            this.lista_precios = null;
            this.porcentaje_descuento_1 = 0;
            this.porcentaje_descuento_2 = 0;
            this.porcentaje_descuento_3 = 0;
            this.cuenta_contable_cliente_mn = null;
            this.cuenta_contable_cliente_me = null;
            this.cuenta_contable_proveedor_mn = null;
            this.cuenta_contable_proveedor_me = null;
            this.cuenta_contable_ingreso = null;
            this.cuenta_contable_gasto = null;
            this.cuenta_bancaria_mn = null;
            this.cuenta_bancaria_me = null;
            this.banco_pago_mn = null;
            this.banco_pago_me = null;
            this.tipo_contable = null;
            this.vigente_sunat = null;
            this.fecha_alta_sunat = null;
            this.afecto_igv = null;
            this.agente_retencion = null;
            this.agente_detraccion = null;
            this.agente_percepcion = null;
            this.porcentaje_detraccion = 0;
            this.cuenta_detraccion = null;
            this.indica_cliente = null;
            this.indica_proveedor = null;
            this.codigo_vendedor = null;
            this.codigo_comprador = null;
            this.ultima_compra = null;
            this.ultima_venta = null;
            this.apellido_paterno = null;
            this.apellido_materno = null;
            this.apellido_casada = null;
            this.nombres = null;
            this.fecha_nacimiento = null;
            this.sexo = null;
            this.estado_civil = null;
            this.nivel_educativo = null;
            this.ocupacion = null;
            this.situacion_crediticia = null;
            this.calificacion = null;
            this.indica_preferente = null;
            this.indica_fallecido = null;
            this.exige_garante = null;
            this.zona_comercial = null;
            this.comentario = null;
            this.usuario_web = null;
            this.clave_web = null;
            this.codigo_antiguo = null;
            this.item_flujo = null;
            this.exige_orden_compra = null;
            this.tipo_orden_compra = null;
            this.exige_orden_pago = null;
            this.tipo_orden_pago = null;
            this.estado = null;
            this.agencia_registro = null;
            this.usuario_registro = null;
            this.fecha_registro = null;
            this.agencia_modifica = null;
            this.usuario_modifica = null;
            this.fecha_modifica = null;
            this.usuario_aprobacion = null;
            this.fecha_aprobacion = null;
            this.ultimo_producto_codigo = null;
            this.ultimo_producto_fecha = null;
            this.nombre_conviviente = null;
        }

        public string empresa { get { return m_empresa; } set { m_empresa = value; } }
        public string cuenta_comercial { get { return m_cuenta_comercial; } set { m_cuenta_comercial = value; } }
        public string grupo_comercial { get { return m_grupo_comercial; } set { m_grupo_comercial = (String.IsNullOrEmpty(value) ? "G0000000" : value); } }
        public string tipo_cuenta { get { return m_tipo_cuenta; } set { m_tipo_cuenta = (String.IsNullOrEmpty(value) ? "N" : value); } }
        public string tipo_documento { get { return m_tipo_documento; } set { m_tipo_documento = value; } }
        public string nro_documento { get { return m_nro_documento; } set { m_nro_documento = value; } }
        public string razon_social { get { return m_razon_social; } set { m_razon_social = value; } }
        public string siglas { get { return m_siglas; } set { m_siglas = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string via_tipo { get { return m_via_tipo; } set { m_via_tipo = (String.IsNullOrEmpty(value) ? "01" : value); } }
        public string via_nombre { get { return m_via_nombre; } set { m_via_nombre = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string via_numero { get { return m_via_numero; } set { m_via_numero = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string via_interior { get { return m_via_interior; } set { m_via_interior = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string zona_tipo { get { return m_zona_tipo; } set { m_zona_tipo = (String.IsNullOrEmpty(value) ? "01" : value); } }
        public string zona_nombre { get { return m_zona_nombre; } set { m_zona_nombre = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string referencia { get { return m_referencia; } set { m_referencia = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string pais { get { return m_pais; } set { m_pais = (String.IsNullOrEmpty(value) ? "9589" : value); } }
        public string departamento { get { return m_departamento; } set { m_departamento = (String.IsNullOrEmpty(value) ? "15" : value); } }
        public string provincia { get { return m_provincia; } set { m_provincia = (String.IsNullOrEmpty(value) ? "1501" : value); } }
        public string ubigeo { get { return m_ubigeo; } set { m_ubigeo = (String.IsNullOrEmpty(value) ? "150101" : value); } }
        public string indica_no_domiciliado { get { return m_indica_no_domiciliado; } set { m_indica_no_domiciliado = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string domicilio_envio { get { return m_domicilio_envio; } set { m_domicilio_envio = (String.IsNullOrEmpty(value) ? "01" : value); } }
        public string domicilio { get { return m_domicilio; } set { m_domicilio = value; } }
        public string codigo_postal { get { return m_codigo_postal; } set { m_codigo_postal = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string telefono { get { return m_telefono; } set { m_telefono = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string telefono_otro { get { return m_telefono_otro; } set { m_telefono_otro = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string celular { get { return m_celular; } set { m_celular = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string fax { get { return m_fax; } set { m_fax = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string email { get { return m_email; } set { m_email = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string pagina_web { get { return m_pagina_web; } set { m_pagina_web = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string direccion_trabajo { get { return m_direccion_trabajo; } set { m_direccion_trabajo = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string referencia_trabajo { get { return m_referencia_trabajo; } set { m_referencia_trabajo = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string telefono_trabajo { get { return m_telefono_trabajo; } set { m_telefono_trabajo = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string tipo_moneda { get { return m_tipo_moneda; } set { m_tipo_moneda = (String.IsNullOrEmpty(value) ? "1" : value); } }
        public string contacto_comercial { get { return m_contacto_comercial; } set { m_contacto_comercial = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string condicion_pago { get { return m_condicion_pago; } set { m_condicion_pago = (String.IsNullOrEmpty(value) ? "00" : value); } }
        public string forma_pago { get { return m_forma_pago; } set { m_forma_pago = (String.IsNullOrEmpty(value) ? "EF" : value); } }
        public string documento_pago { get { return m_documento_pago; } set { m_documento_pago = (String.IsNullOrEmpty(value) ? "01" : value); } }
        public decimal linea_credito_mn { get { return m_linea_credito_mn; } set { m_linea_credito_mn = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public decimal linea_credito_me { get { return m_linea_credito_me; } set { m_linea_credito_me = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public decimal saldo_pagar_mn { get { return m_saldo_pagar_mn; } set { m_saldo_pagar_mn = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public decimal saldo_pagar_me { get { return m_saldo_pagar_me; } set { m_saldo_pagar_me = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public string vigencia_credito { get { return m_vigencia_credito; } set { m_vigencia_credito = (String.IsNullOrEmpty(value) ? "01/01/1900" : value); } }
        public string lista_precios { get { return m_lista_precios; } set { m_lista_precios = (String.IsNullOrEmpty(value) ? "LP0000000000" : value); } }
        public decimal porcentaje_descuento_1 { get { return m_porcentaje_descuento_1; } set { m_porcentaje_descuento_1 = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public decimal porcentaje_descuento_2 { get { return m_porcentaje_descuento_2; } set { m_porcentaje_descuento_2 = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public decimal porcentaje_descuento_3 { get { return m_porcentaje_descuento_3; } set { m_porcentaje_descuento_3 = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public string cuenta_contable_cliente_mn { get { return m_cuenta_contable_cliente_mn; } set { m_cuenta_contable_cliente_mn = (String.IsNullOrEmpty(value) ? "121201" : value); } }
        public string cuenta_contable_cliente_me { get { return m_cuenta_contable_cliente_me; } set { m_cuenta_contable_cliente_me = (String.IsNullOrEmpty(value) ? "121202" : value); } }
        public string cuenta_contable_proveedor_mn { get { return m_cuenta_contable_proveedor_mn; } set { m_cuenta_contable_proveedor_mn = (String.IsNullOrEmpty(value) ? "421201" : value); } }
        public string cuenta_contable_proveedor_me { get { return m_cuenta_contable_proveedor_me; } set { m_cuenta_contable_proveedor_me = (String.IsNullOrEmpty(value) ? "421202" : value); } }
        public string cuenta_contable_ingreso { get { return m_cuenta_contable_ingreso; } set { m_cuenta_contable_ingreso = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string cuenta_contable_gasto { get { return m_cuenta_contable_gasto; } set { m_cuenta_contable_gasto = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string cuenta_bancaria_mn { get { return m_cuenta_bancaria_mn; } set { m_cuenta_bancaria_mn = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string cuenta_bancaria_me { get { return m_cuenta_bancaria_me; } set { m_cuenta_bancaria_me = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string banco_pago_mn { get { return m_banco_pago_mn; } set { m_banco_pago_mn = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string banco_pago_me { get { return m_banco_pago_me; } set { m_banco_pago_me = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string tipo_contable { get { return m_tipo_contable; } set { m_tipo_contable = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string vigente_sunat { get { return m_vigente_sunat; } set { m_vigente_sunat = (String.IsNullOrEmpty(value) ? "SI" : value); } }
        public string fecha_alta_sunat { get { return m_fecha_alta_sunat; } set { m_fecha_alta_sunat = (String.IsNullOrEmpty(value) ? "01/01/1900" : value); } }
        public string afecto_igv { get { return m_afecto_igv; } set { m_afecto_igv = (String.IsNullOrEmpty(value) ? "SI" : value); } }
        public string agente_retencion { get { return m_agente_retencion; } set { m_agente_retencion = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string agente_detraccion { get { return m_agente_detraccion; } set { m_agente_detraccion = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string agente_percepcion { get { return m_agente_percepcion; } set { m_agente_percepcion = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public decimal porcentaje_detraccion { get { return m_porcentaje_detraccion; } set { m_porcentaje_detraccion = (String.IsNullOrEmpty(value.ToString()) ? 0 : value); } }
        public string cuenta_detraccion { get { return m_cuenta_detraccion; } set { m_cuenta_detraccion = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string indica_cliente { get { return m_indica_cliente; } set { m_indica_cliente = (String.IsNullOrEmpty(value) ? "SI" : value); } }
        public string indica_proveedor { get { return m_indica_proveedor; } set { m_indica_proveedor = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string codigo_vendedor { get { return m_codigo_vendedor; } set { m_codigo_vendedor = (String.IsNullOrEmpty(value) ? "000" : value); } }
        public string codigo_comprador { get { return m_codigo_comprador; } set { m_codigo_comprador = (String.IsNullOrEmpty(value) ? "000" : value); } }
        public string ultima_compra { get { return m_ultima_compra; } set { m_ultima_compra = (String.IsNullOrEmpty(value) ? "000000000000" : value); } }
        public string ultima_venta { get { return m_ultima_venta; } set { m_ultima_venta = (String.IsNullOrEmpty(value) ? "000000000000" : value); } }
        public string apellido_paterno { get { return m_apellido_paterno; } set { m_apellido_paterno = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string apellido_materno { get { return m_apellido_materno; } set { m_apellido_materno = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string apellido_casada { get { return m_apellido_casada; } set { m_apellido_casada = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string nombres { get { return m_nombres; } set { m_nombres = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string fecha_nacimiento { get { return m_fecha_nacimiento; } set { m_fecha_nacimiento = (String.IsNullOrEmpty(value) ? "01/01/1900" : value); } }
        public string sexo { get { return m_sexo; } set { m_sexo = (String.IsNullOrEmpty(value) ? "M" : value); } }

        public string estado_civil { get { return m_estado_civil; } set { m_estado_civil = (String.IsNullOrEmpty(value) ? "01" : value); } }
        public string nivel_educativo { get { return m_nivel_educativo; } set { m_nivel_educativo = (String.IsNullOrEmpty(value) ? "07" : value); } }
        public string ocupacion { get { return m_ocupacion; } set { m_ocupacion = (String.IsNullOrEmpty(value) ? "002" : value); } }
        public string situacion_crediticia { get { return m_situacion_crediticia; } set { m_situacion_crediticia = (String.IsNullOrEmpty(value) ? "NEW" : value); } }

        public string calificacion { get { return m_calificacion; } set { m_calificacion = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }

        public string indica_preferente { get { return m_indica_preferente; } set { m_indica_preferente = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string indica_fallecido { get { return m_indica_fallecido; } set { m_indica_fallecido = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string exige_garante { get { return m_exige_garante; } set { m_exige_garante = (String.IsNullOrEmpty(value) ? "NO" : value); } }

        public string zona_comercial { get { return m_zona_comercial; } set { m_zona_comercial = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string comentario { get { return m_comentario; } set { m_comentario = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string usuario_web { get { return m_usuario_web; } set { m_usuario_web = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string clave_web { get { return m_clave_web; } set { m_clave_web = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string codigo_antiguo { get { return m_codigo_antiguo; } set { m_codigo_antiguo = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string item_flujo { get { return m_item_flujo; } set { m_item_flujo = (String.IsNullOrEmpty(value) ? "9999" : value); } }
        public string exige_orden_compra { get { return m_exige_orden_compra; } set { m_exige_orden_compra = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string tipo_orden_compra { get { return m_tipo_orden_compra; } set { m_tipo_orden_compra = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string exige_orden_pago { get { return m_exige_orden_pago; } set { m_exige_orden_pago = (String.IsNullOrEmpty(value) ? "NO" : value); } }
        public string tipo_orden_pago { get { return m_tipo_orden_pago; } set { m_tipo_orden_pago = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
        public string estado { get { return m_estado; } set { m_estado = (String.IsNullOrEmpty(value) ? "A" : value); } }

        public string agencia_registro { get { return m_agencia_registro; } set { m_agencia_registro = (String.IsNullOrEmpty(value) ? "A0000000" : value); } }

        public string usuario_registro { get { return m_usuario_registro; } set { m_usuario_registro = value; } }
        public string fecha_registro { get { return m_fecha_registro; } set { m_fecha_registro = DateTime.Now.ToString(); } }

        public string agencia_modifica { get { return m_agencia_modifica; } set { m_agencia_modifica = value; } }

        public string usuario_modifica { get { return m_usuario_modifica; } set { m_usuario_modifica = value; } }
        public string fecha_modifica { get { return m_fecha_modifica; } set { m_fecha_modifica = DateTime.Now.ToString(); } }

        public string usuario_aprobacion { get { return m_usuario_aprobacion; } set { m_usuario_aprobacion = value; } }
        public string fecha_aprobacion { get { return m_fecha_aprobacion; } set { m_fecha_aprobacion = DateTime.Now.ToString(); } }

        public string ultimo_producto_codigo { get { return m_ultimo_producto_codigo; } set { m_ultimo_producto_codigo = value; } }
        public string ultimo_producto_fecha { get { return m_ultimo_producto_fecha; } set { m_ultimo_producto_fecha = DateTime.Now.ToString(); } }

        public string nombre_conviviente { get { return m_nombre_conviviente; } set { m_nombre_conviviente = (String.IsNullOrEmpty(value) ? Strings.Space(1) : value); } }
    }
}