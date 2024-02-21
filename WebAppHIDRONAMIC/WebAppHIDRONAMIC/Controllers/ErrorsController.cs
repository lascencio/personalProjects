using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHIDRONAMIC.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Error(string error)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ViewBag.mensaje = error;
                return View();
            }
        }
    }
}