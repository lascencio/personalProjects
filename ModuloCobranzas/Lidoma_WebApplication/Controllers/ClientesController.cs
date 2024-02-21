using Lidoma_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lidoma_WebApplication.Controllers
{
    public class ClientesController : Controller
    {
        //Instanciar clases utilizar dentro del controller
        dalClientes clientesDL = new dalClientes();

        //[HttpPost]
        //public ActionResult Clientes()
        //{
        //    var clientes = clientesDL.Clientes();
        //    return Json(clientes, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult ClientesPorRazon(string razon_social)
        {
            var clientes = clientesDL.ClientesPorRazon(razon_social.Trim().ToUpper());
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ClientesPorCuenta(string documento)
        {
            var clientes = clientesDL.ClientesPorCuenta(documento.Trim());
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SeleccionarCliente(string cuenta)
        {
            var cliente = clientesDL.SeleccionarCliente(cuenta.Trim());
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

    }
}
