using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lidoma_WebApplication.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Error(string error)
        {
            ViewBag.mensaje = error;
            return View();
        }

    }
}
