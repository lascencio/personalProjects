using Lidoma_WebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lidoma_WebApplication.Data;
using Lidoma_WebApplication.Entities;

namespace Lidoma_WebApplication.DAL
{
    public class dalClientes
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        private dsCuentasComerciales.MyDTCuentasComercialesDataTable myDTCuentasComerciales = MyModule.MyDTCuentasComercialesDataTable;
        private entCuentaComercial MyCuentaComercial = HttpContext.Current.Session["MyCuentaComercial"] as entCuentaComercial;

        //public List<entCuentaComercial> Clientes()
        //{
        //    List<entCuentaComercial> clientes = new List<entCuentaComercial>();
        //    for (int i = 0; i <= myDTCuentasComerciales.Rows.Count - 1; i++)
        //    {
        //        entCuentaComercial cliente = new entCuentaComercial();
        //        cliente.empresa = myDTCuentasComerciales[i].EMPRESA;
        //        cliente.cuenta_comercial = myDTCuentasComerciales[i].CUENTA_COMERCIAL;
        //        cliente.grupo_comercial = myDTCuentasComerciales[i].GRUPO_COMERCIAL;
        //        cliente.tipo_cuenta = myDTCuentasComerciales[i].TIPO_CUENTA;
        //        cliente.tipo_documento = myDTCuentasComerciales[i].TIPO_DOCUMENTO;
        //        cliente.nro_documento = myDTCuentasComerciales[i].NRO_DOCUMENTO;
        //        cliente.razon_social = myDTCuentasComerciales[i].RAZON_SOCIAL;
        //        cliente.domicilio = myDTCuentasComerciales[i].DOMICILIO;
        //        cliente.indica_no_domiciliado = myDTCuentasComerciales[i].INDICA_NO_DOMICILIADO;
        //        cliente.tipo_moneda = myDTCuentasComerciales[i].TIPO_MONEDA;
        //        cliente.condicion_pago = myDTCuentasComerciales[i].CONDICION_PAGO;
        //        cliente.linea_credito_mn = myDTCuentasComerciales[i].LINEA_CREDITO_MN;
        //        cliente.linea_credito_me = myDTCuentasComerciales[i].LINEA_CREDITO_ME;
        //        cliente.lista_precios = myDTCuentasComerciales[i].LISTA_PRECIOS;
        //        cliente.afecto_igv = myDTCuentasComerciales[i].AFECTO_IGV;
        //        cliente.agente_retencion = myDTCuentasComerciales[i].AGENTE_RETENCION;
        //        cliente.agente_detraccion = myDTCuentasComerciales[i].AGENTE_DETRACCION;
        //        cliente.agente_percepcion = myDTCuentasComerciales[i].AGENTE_PERCEPCION;
        //        cliente.indica_cliente = myDTCuentasComerciales[i].INDICA_CLIENTE;
        //        cliente.indica_proveedor = myDTCuentasComerciales[i].INDICA_PROVEEDOR;
        //        cliente.codigo_vendedor = myDTCuentasComerciales[i].CODIGO_VENDEDOR;
        //        cliente.codigo_comprador = myDTCuentasComerciales[i].CODIGO_COMPRADOR;
        //        cliente.codigo_antiguo = myDTCuentasComerciales[i].CODIGO_ANTIGUO;
        //        cliente.estado = myDTCuentasComerciales[i].ESTADO.Equals("A") ? "ACTIVO" : "INACTIVO";
        //        clientes.Add(cliente);
        //    }
        //    return clientes;
        //}

        public List<entCuentaComercial> ClientesPorRazon(string razon)
        {
            List<entCuentaComercial> clientes = new List<entCuentaComercial>();
            var clies = (from c in myDTCuentasComerciales
                         where c.RAZON_SOCIAL.Contains(razon)
                         orderby c.RAZON_SOCIAL
                         select new
                         {
                             empresa = c.EMPRESA,
                             cuenta_comercial = c.CUENTA_COMERCIAL,
                             grupo_comercial = c.GRUPO_COMERCIAL,
                             tipo_cuenta = c.TIPO_CUENTA,
                             tipo_documento = c.TIPO_DOCUMENTO,
                             nro_documento = c.NRO_DOCUMENTO,
                             razon_social = c.RAZON_SOCIAL,
                             domicilio = c.DOMICILIO,
                             indica_no_domiciliado = c.INDICA_NO_DOMICILIADO,
                             tipo_moneda = c.TIPO_MONEDA,
                             condicion_pago = c.CONDICION_PAGO,
                             linea_credito_mn = c.LINEA_CREDITO_MN,
                             linea_credito_me = c.LINEA_CREDITO_ME,
                             lista_precios = c.LISTA_PRECIOS,
                             afecto_igv = c.AFECTO_IGV,
                             agente_retencion = c.AGENTE_RETENCION,
                             agente_detraccion = c.AGENTE_DETRACCION,
                             agente_percepcion = c.AGENTE_PERCEPCION,
                             indica_cliente = c.INDICA_CLIENTE,
                             indica_proveedor = c.INDICA_PROVEEDOR,
                             codigo_vendedor = c.CODIGO_VENDEDOR,
                             codigo_comprador = c.CODIGO_COMPRADOR,
                             codigo_antiguo = c.CODIGO_ANTIGUO,
                             estado = c.ESTADO
                         }).Take(100);
            foreach (var c in clies)
            {
                entCuentaComercial cliente = new entCuentaComercial();
                cliente.empresa = c.empresa;
                cliente.cuenta_comercial = c.cuenta_comercial;
                cliente.grupo_comercial = c.grupo_comercial;
                cliente.tipo_cuenta = c.tipo_cuenta;
                cliente.tipo_documento = c.tipo_documento;
                cliente.nro_documento = c.nro_documento;
                cliente.razon_social = c.razon_social;
                cliente.domicilio = c.domicilio;
                cliente.indica_no_domiciliado = c.indica_no_domiciliado;
                cliente.tipo_moneda = c.tipo_moneda;
                cliente.condicion_pago = c.condicion_pago;
                cliente.linea_credito_mn = c.linea_credito_mn;
                cliente.linea_credito_me = c.linea_credito_me;
                cliente.lista_precios = c.lista_precios;
                cliente.afecto_igv = c.afecto_igv;
                cliente.agente_retencion = c.agente_retencion;
                cliente.agente_detraccion = c.agente_detraccion;
                cliente.agente_percepcion = c.agente_percepcion;
                cliente.indica_cliente = c.indica_cliente;
                cliente.indica_proveedor = c.indica_proveedor;
                cliente.codigo_vendedor = c.codigo_vendedor;
                cliente.codigo_comprador = c.codigo_comprador;
                cliente.codigo_antiguo = c.codigo_antiguo;
                cliente.estado = c.estado.Equals("A") ? "ACTIVO" : "INACTIVO";
                clientes.Add(cliente);
            }
            return clientes;
        }

        public List<entCuentaComercial> ClientesPorCuenta(string documento)
        {
            List<entCuentaComercial> clientes = new List<entCuentaComercial>();
            var clies = (from c in myDTCuentasComerciales
                         where c.NRO_DOCUMENTO.StartsWith(documento)
                         orderby c.NRO_DOCUMENTO
                         select new
                         {
                             empresa = c.EMPRESA,
                             cuenta_comercial = c.CUENTA_COMERCIAL,
                             grupo_comercial = c.GRUPO_COMERCIAL,
                             tipo_cuenta = c.TIPO_CUENTA,
                             tipo_documento = c.TIPO_DOCUMENTO,
                             nro_documento = c.NRO_DOCUMENTO,
                             razon_social = c.RAZON_SOCIAL,
                             domicilio = c.DOMICILIO,
                             indica_no_domiciliado = c.INDICA_NO_DOMICILIADO,
                             tipo_moneda = c.TIPO_MONEDA,
                             condicion_pago = c.CONDICION_PAGO,
                             linea_credito_mn = c.LINEA_CREDITO_MN,
                             linea_credito_me = c.LINEA_CREDITO_ME,
                             lista_precios = c.LISTA_PRECIOS,
                             afecto_igv = c.AFECTO_IGV,
                             agente_retencion = c.AGENTE_RETENCION,
                             agente_detraccion = c.AGENTE_DETRACCION,
                             agente_percepcion = c.AGENTE_PERCEPCION,
                             indica_cliente = c.INDICA_CLIENTE,
                             indica_proveedor = c.INDICA_PROVEEDOR,
                             codigo_vendedor = c.CODIGO_VENDEDOR,
                             codigo_comprador = c.CODIGO_COMPRADOR,
                             codigo_antiguo = c.CODIGO_ANTIGUO,
                             estado = c.ESTADO
                         }).Take(100);
            foreach (var c in clies)
            {
                entCuentaComercial cliente = new entCuentaComercial();
                cliente.empresa = c.empresa;
                cliente.cuenta_comercial = c.cuenta_comercial;
                cliente.grupo_comercial = c.grupo_comercial;
                cliente.tipo_cuenta = c.tipo_cuenta;
                cliente.tipo_documento = c.tipo_documento;
                cliente.nro_documento = c.nro_documento;
                cliente.razon_social = c.razon_social;
                cliente.domicilio = c.domicilio;
                cliente.indica_no_domiciliado = c.indica_no_domiciliado;
                cliente.tipo_moneda = c.tipo_moneda;
                cliente.condicion_pago = c.condicion_pago;
                cliente.linea_credito_mn = c.linea_credito_mn;
                cliente.linea_credito_me = c.linea_credito_me;
                cliente.lista_precios = c.lista_precios;
                cliente.afecto_igv = c.afecto_igv;
                cliente.agente_retencion = c.agente_retencion;
                cliente.agente_detraccion = c.agente_detraccion;
                cliente.agente_percepcion = c.agente_percepcion;
                cliente.indica_cliente = c.indica_cliente;
                cliente.indica_proveedor = c.indica_proveedor;
                cliente.codigo_vendedor = c.codigo_vendedor;
                cliente.codigo_comprador = c.codigo_comprador;
                cliente.codigo_antiguo = c.codigo_antiguo;
                cliente.estado = c.estado.Equals("A") ? "ACTIVO" : "INACTIVO";
                clientes.Add(cliente);
            }
            return clientes;
        }

        public entCuentaComercial SeleccionarCliente(string cuenta)
        {
            var clie = from c in myDTCuentasComerciales
                       where c.CUENTA_COMERCIAL == cuenta
                       orderby c.RAZON_SOCIAL
                       select new
                       {
                           empresa = c.EMPRESA,
                           cuenta_comercial = c.CUENTA_COMERCIAL,
                           grupo_comercial = c.GRUPO_COMERCIAL,
                           tipo_cuenta = c.TIPO_CUENTA,
                           tipo_documento = c.TIPO_DOCUMENTO,
                           nro_documento = c.NRO_DOCUMENTO,
                           razon_social = c.RAZON_SOCIAL,
                           domicilio = c.DOMICILIO,
                           indica_no_domiciliado = c.INDICA_NO_DOMICILIADO,
                           tipo_moneda = c.TIPO_MONEDA,
                           condicion_pago = c.CONDICION_PAGO,
                           linea_credito_mn = c.LINEA_CREDITO_MN,
                           linea_credito_me = c.LINEA_CREDITO_ME,
                           lista_precios = c.LISTA_PRECIOS,
                           afecto_igv = c.AFECTO_IGV,
                           agente_retencion = c.AGENTE_RETENCION,
                           agente_detraccion = c.AGENTE_DETRACCION,
                           agente_percepcion = c.AGENTE_PERCEPCION,
                           indica_cliente = c.INDICA_CLIENTE,
                           indica_proveedor = c.INDICA_PROVEEDOR,
                           codigo_vendedor = c.CODIGO_VENDEDOR,
                           codigo_comprador = c.CODIGO_COMPRADOR,
                           codigo_antiguo = c.CODIGO_ANTIGUO,
                           estado = c.ESTADO
                       };
            foreach (var c in clie)
            {
                MyCuentaComercial.empresa = c.empresa;
                MyCuentaComercial.cuenta_comercial = c.cuenta_comercial;
                MyCuentaComercial.grupo_comercial = c.grupo_comercial;
                MyCuentaComercial.tipo_cuenta = c.tipo_cuenta;
                MyCuentaComercial.tipo_documento = c.tipo_documento;
                MyCuentaComercial.nro_documento = c.nro_documento;
                MyCuentaComercial.razon_social = c.razon_social;
                MyCuentaComercial.domicilio = c.domicilio;
                MyCuentaComercial.indica_no_domiciliado = c.indica_no_domiciliado;
                MyCuentaComercial.tipo_moneda = c.tipo_moneda;
                MyCuentaComercial.condicion_pago = c.condicion_pago;
                MyCuentaComercial.linea_credito_mn = c.linea_credito_mn;
                MyCuentaComercial.linea_credito_me = c.linea_credito_me;
                MyCuentaComercial.lista_precios = c.lista_precios;
                MyCuentaComercial.afecto_igv = c.afecto_igv;
                MyCuentaComercial.agente_retencion = c.agente_retencion;
                MyCuentaComercial.agente_detraccion = c.agente_detraccion;
                MyCuentaComercial.agente_percepcion = c.agente_percepcion;
                MyCuentaComercial.indica_cliente = c.indica_cliente;
                MyCuentaComercial.indica_proveedor = c.indica_proveedor;
                MyCuentaComercial.codigo_vendedor = c.codigo_vendedor;
                MyCuentaComercial.codigo_comprador = c.codigo_comprador;
                MyCuentaComercial.codigo_antiguo = c.codigo_antiguo;
                MyCuentaComercial.estado = c.estado.Equals("A") ? "ACTIVO" : "INACTIVO";
            }
            return MyCuentaComercial;
        }
    }
}