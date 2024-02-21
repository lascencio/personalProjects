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
    public class PiscinasController : Controller
    {
        PiscinasDAL piscinasDL = new PiscinasDAL();
        TablesDAL tablesDL = new TablesDAL();

        [HttpPost]
        public ActionResult Consultar(string piscina)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                PiscinaDTO result = piscinasDL.PiscinaPorId(piscina);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        //ESTE MÉTODO LO USABA PARA QUE AL REGISTRAR CLIENTE, AHÍ MISMO SE REGISTRE Y ELIMINE UNA PISCINA.
        //[HttpPost]
        //public ActionResult EliminarPiscinaDS(string piscina)
        //{
        //    if (Session["USUARIO"] == null)
        //    {
        //        return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
        //    }
        //    else
        //    {
        //        var result = piscinasDL.EliminarPiscinaDS(piscina);
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public ActionResult EliminarPiscinaBD(string piscina, string cliente)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = piscinasDL.EliminarPiscinaBD(piscina, cliente);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        //ESTE MÉTODO LO USABA PARA QUE AL REGISTRAR CLIENTE, AHÍ MISMO SE REGISTRE UNA PISCINA.
        //[HttpPost]
        //public ActionResult GrabarPiscina(PiscinaDTO piscina)
        //{
        //    if (Session["USUARIO"] == null)
        //    {
        //        return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
        //    }
        //    else
        //    {
        //        var result = piscinasDL.Grabar(piscina);
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public ActionResult GrabarPiscinaBD(PiscinaDTO piscina)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string usuario = Session["USUARIO"].ToString();
                var result = piscinasDL.GrabarBD(piscina, usuario);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult InfoQuimicos(string piscina)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                PiscinaDTO pisc = piscinasDL.PiscinaPorId(piscina);
                return View(pisc);
            }
        }

        public ActionResult ModificarPiscina(string cuenta, string razon)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ViewBag.cliente = cuenta;
                ViewBag.razon = razon;
                List<PiscinaDTO> piscinas = piscinasDL.PiscinasPorCliente(cuenta);
                ViewBag.tiposPiscina = new SelectList(tablesDL.TipoPiscinas(), "ID", "DESCRIPCION");
                ViewBag.frecuenciaMant = new SelectList(tablesDL.FrecuenciasMant(), "ID", "DESCRIPCION");
                return View(piscinas);
            }
        }

        [HttpPost]
        public ActionResult Modificar(PiscinaDTO piscina)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                List<PiscinaDTO> result = piscinasDL.Modificar(piscina);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}