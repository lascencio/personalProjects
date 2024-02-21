using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.DAL;
using WebAppHIDRONAMIC.Utils;

namespace WebAppHIDRONAMIC.Controllers
{
    public class ClientesController : Controller
    {
        ClientesDAL clientesDL = new ClientesDAL();
        PiscinasDAL piscinasDL = new PiscinasDAL();
        TablesDAL tablesDL = new TablesDAL();

        [HttpPost]
        public ActionResult ClientesPorRazon(string razon_social)
        {
            string param = razon_social.Trim().ToUpper();
            var clientes = clientesDL.ClientesPorRazon(param);
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CorreoPorClienet(string cliente)
        {
            var clien = clientesDL.CorreoPorCliente(cliente);
            return Json(clien, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ClientePorCuenta(string cuenta_comercial)
        {
            var clientes = clientesDL.ClientePorCuenta(cuenta_comercial);
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SeleccionPiscina(string cuenta_comercial)
        {
            var piscinas = piscinasDL.PiscinasPorCliente(cuenta_comercial);
            return Json(piscinas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Clientes()
        {
            var clientes = clientesDL.Clientes();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModificarCliente(string id)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ClienteDTO cliente = clientesDL.ClientePorCuenta(id);
                ViewBag.departamentos = new SelectList(tablesDL.Departamentos(), "ID", "DESCRIPCION");
                ViewBag.provincias = new SelectList(tablesDL.Provincias(Utilitarios.SubStrings(cliente.PROVINCIA, 0, 2)), "ID", "DESCRIPCION");
                ViewBag.distritos = new SelectList(tablesDL.Distritos(Utilitarios.SubStrings(cliente.DISTRITO, 0, 4)), "ID", "DESCRIPCION");
                ViewBag.documentos = new SelectList(tablesDL.TiposDocumento(), "ID", "DESCRIPCION");
                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Modificar(ClienteDTO cliente)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string usuario_modifica = Session["NOMBRE"].ToString();
                var result = clientesDL.Editar(cliente, usuario_modifica);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RegistrarCliente(string msg = null)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ViewBag.departamentos = new SelectList(tablesDL.Departamentos(), "ID", "DESCRIPCION");
                ViewBag.provincias = new SelectList(tablesDL.Provincias("15"), "ID", "DESCRIPCION");
                ViewBag.distritos = new SelectList(tablesDL.Distritos("1501"), "ID", "DESCRIPCION");
                ViewBag.documentos = new SelectList(tablesDL.TiposDocumento(), "ID", "DESCRIPCION");
                ViewBag.tiposPiscina = new SelectList(tablesDL.TipoPiscinas(), "ID", "DESCRIPCION");
                ViewBag.frecuenciaMant = new SelectList(tablesDL.FrecuenciasMant(), "ID", "DESCRIPCION");

                if (string.IsNullOrEmpty(msg))
                    ViewBag.mensaje = "";
                else
                    ViewBag.mensaje = msg;

                return View(new ClienteDTO());
            }
        }

        [HttpPost]
        public ActionResult RegistrarCliente(ClienteDTO cliente)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string USUARIO_REGISTRO = Session["NOMBRE"].ToString();
                string EMPRESA = Session["EMPRESA"].ToString();
                string result = clientesDL.Registrar(cliente, USUARIO_REGISTRO, EMPRESA);
                if (result.Equals("success"))
                    return RedirectToAction("RegistrarCliente", new { msg = "success" });
                else
                    return RedirectToAction("Error", "Errors", new { error = result });
            }
        }

        [HttpPost]
        public ActionResult Provincias(string depa)
        {
            var provincias = tablesDL.Provincias(depa);
            return Json(provincias, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Distritos(string prov)
        {
            var distritos = tablesDL.Distritos(prov);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Auditoria(string cuenta)
        {
            var auditoria = clientesDL.Auditoria(cuenta);
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

    }
}