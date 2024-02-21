using Lidoma_WebApplication.DAL;
using Lidoma_WebApplication.Data;
using Lidoma_WebApplication.Entities;
using Lidoma_WebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lidoma_WebApplication.Controllers
{
    public class UsuariosController : Controller
    {
        Procesos procesos = new Procesos();
        public ActionResult Login(string msg = null)
        {
            if (string.IsNullOrEmpty(msg))
                ViewBag.mensaje = "";
            else
                ViewBag.mensaje = msg;

            return View(new entUsuario());
        }

        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {
            entUsuario usu = new entUsuario();
            dalUsuarios dlUsuario = new dalUsuarios();
            try
            {
                usu = dlUsuario.Obtener(usuario, clave);
            }
            catch (Exception e)
            {
                return RedirectToAction("Login", new { msg = "Error al iniciar sesión...inténtelo de nuevo." });
            }

            if (usu == null)
            {
                return RedirectToAction("Login", new { msg = "Usuario y/o clave incorrectos" });
            }
            else
            {
                Session["MyUsuario"] = usu;
                procesos.LLenarDataTables();
                return RedirectToAction("RegistroCobranzaPrestamo", "Cobranzas");
            }
        }

    }
}
