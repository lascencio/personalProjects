using Lidoma_WebApplication.DAL;
using System;
using Lidoma_WebApplication.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lidoma_WebApplication.Data;
using TextmagicRest;
using TextmagicRest.Model;

namespace Lidoma_WebApplication.Controllers
{
    public class CobranzasController : Controller
    {
        //Instanciar clases utilizar dentro del controller
        dalFinanciamiento financiamientoDal = new dalFinanciamiento();

        public ActionResult RegistroCobranzaPrestamo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerPrestamos()
        {
            var prestamos = financiamientoDal.ObtenerPrestamos("V");
            return Json(prestamos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SeleccionarPrestamo(string prestamo)
        {
            var prestamos = financiamientoDal.SeleccionarPrestamo(prestamo);
            return Json(prestamos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ObtenerPrestamoCuotasLista(string prestamo)
        {
            var prestamos = financiamientoDal.ObtenerPrestamoCuotasLista(prestamo);
            return Json(prestamos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarCuota(string cuota)
        {
            var vCuota = financiamientoDal.AgregarCuota(cuota);
            return Json(vCuota, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarCuotasTodas()
        {
            var vCuota = financiamientoDal.AgregarCuotasTodas();
            return Json(vCuota, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult QuitarCuota(string cuota)
        {
            var vCuota = financiamientoDal.QuitarCuota(cuota);
            return Json(vCuota, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult QuitarCuotasTodas()
        {
            var vCuota = financiamientoDal.QuitarCuotasTodas();
            return Json(vCuota, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GrabarCobranza(string totalCuotas, string totalPagar)
        {
            string vCuota = financiamientoDal.GrabrarCobranza(totalCuotas, totalPagar);
            return Json(vCuota, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MostrarCuotasCobro()
        {
            var cuotas = financiamientoDal.ObtenerCuotasCobro();
            return Json(cuotas, JsonRequestBehavior.AllowGet);
        }

    }
}
