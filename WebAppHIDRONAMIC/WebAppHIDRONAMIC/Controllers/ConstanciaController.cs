using System.Web.Mvc;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.DAL;
using WebAppHIDRONAMIC.Reports;
using WebAppHIDRONAMIC.Utils;
using System.Web;

namespace WebAppHIDRONAMIC.Controllers
{
    public class ConstanciaController : Controller
    {
        ConstanciaDAL constanciaDL = new ConstanciaDAL();
        PiscinasDAL piscinasDL = new PiscinasDAL();
        TablesDAL tablesDL = new TablesDAL();
        ConstanciaRPT rpt = new ConstanciaRPT();
        private string firmaURL = "FirmaConstancia";

        public ActionResult Constancias(string msg = null)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                //MÉTODO PARA GENERAR TODAS LAS CONSTANCIAS EN PDF
                //List<string> ids = constanciaDL.ConstanciasID();
                //string id;
                //try {
                //    for (int i = 0; i < ids.Count; i++)
                //    {
                //        id = ids[i];
                //        constanciaDL.GenerarConstanciaPDF(id);
                //    }
                //}
                //catch(Exception e)
                //{
                //    string mg = e.Message;
                //    return RedirectToAction("Error", "Errors", new { error = mg });
                //}

                if (string.IsNullOrEmpty(msg))
                    ViewBag.mensaje = "";
                else
                    ViewBag.mensaje = msg;
                return View(constanciaDL.ConstanciasPorMes(""));
            }
        }

        [HttpPost]
        public ActionResult ConstanciasPorMes(string mes)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                if (string.IsNullOrEmpty(mes))
                {
                    mes = "";
                }
                var result = constanciaDL.ConstanciasPorMes(mes);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ConstanciasPorSemanaActual()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.ConstanciasPorFechas(Utilitarios.fdcw, Utilitarios.ldcw);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ConstanciasPorSemanaPasada()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.ConstanciasPorFechas(Utilitarios.fdlw, Utilitarios.ldlw);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ConstanciasPorAnio(string anio)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.ConstanciasPorAnio(anio);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ConstanciasPorCliente(string cliente)
        {
            string param = cliente.ToUpper().Trim();
            var result = constanciaDL.ConstanciasPorCliente(param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConstanciasPorFechas(string fecha1, string fecha2)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.ConstanciasPorFechas(Utilitarios.FormatoFecha_AMD(fecha1), Utilitarios.FormatoFecha_AMD(fecha2));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detalles(string constancia)
        {
            string id = constancia.Substring(0, 12);
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                if (constancia.Length == 13)
                {
                    string ruta = Server.MapPath("../UploadFiles/" + id + ".pdf");
                    if (System.IO.File.Exists(@"" + ruta))
                    {
                        ViewBag.constancia = id;
                        ViewBag.opciones = "nulo";
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Constancias", new { msg = "Constancia " + id + " no encontrada. Por favor vuela a generar." });
                    }

                    //ESTE MÉTODO ES TEMPORAL...MIENTRAS SE GENEREN LOS PDFS
                    //constanciaDL.GenerarConstanciaPDF(id);
                    //TempData["Embed"] = VirtualPathUtility.ToAbsolute("~/UploadFiles/" + id + ".pdf");
                    //ViewBag.constancia = id;
                    //ViewBag.opciones = "nulo";
                    //return View();
                }
                else
                {
                    string result = constanciaDL.GenerarConstanciaPDF(id);
                    if (result.Equals("SUCCESS"))
                    {
                        ViewBag.constancia = constancia;
                        //TempData["Embed"] = VirtualPathUtility.ToAbsolute("~/UploadFiles/" + id + ".pdf");
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Error", "Errors", new { error = result });
                    }
                }
            }
        }
        
        public FileResult DescargarPdf(string constancia)
        {
            var ruta = Server.MapPath("../UploadFiles/" + constancia + ".pdf");
            return File(ruta, "application/pdf", constancia + ".pdf");
        }
        
        public ActionResult EnviarConstancia(string constancia)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string result = constanciaDL.EnviarConstanciaEmail(constancia);
                if (result.Equals("SUCCESS"))
                    return RedirectToAction("Constancias", new { msg = "Constancia "+constancia+" enviada!" });
                else
                    return RedirectToAction("Error", "Errors", new { error = result });
            }
        }

        [HttpPost]
        public ActionResult EliminarDetalle(string serv)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.EliminarDetalle(serv);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string constancia)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.Eliminar(constancia);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GrabarDetalle(string servicio, string cantidad, string descripcionServicio, string tipo)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = constanciaDL.GrabarDetalles(servicio, cantidad, descripcionServicio, tipo);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult LimpiarDSDetalles()
        {
            var result = constanciaDL.LimpiarDSDetalles();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListarDSDetalles()
        {
            var result = constanciaDL.ListarDSDetalle();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ModificarConstancia(string constancia)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ConstanciaDTO reg = constanciaDL.EliminarConstancia(constancia);//implemento método que captura los dtSets constancias y detalles
                ViewBag.serviciosS = new SelectList(tablesDL.Servicios(), "ID", "DESCRIPCION");
                ViewBag.serviciosP = new SelectList(tablesDL.Productos(), "ID", "DESCRIPCION");
                return View(reg);
            }
        }

        //[HttpPost]
        //public ActionResult ModificarConstancia(ConstanciaDTO constancia)
        //{
        //    if (Session["USUARIO"] == null)
        //    {
        //        return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
        //    }
        //    else
        //    {
        //        string usuario = Session["NOMBRE"].ToString();
        //        string empresa = Session["EMPRESA"].ToString();
        //        string[] result = constanciaDL.GrabarConstancia(constancia, usuario, empresa).Split('|');
        //        if (result[0].Equals("success")&& constancia.INDICA_FIRMA.Equals("SI"))
        //        {
        //            return Redirect("/Reports/"+ firmaURL + ".aspx");
        //        }
        //        if (constancia.INDICA_FIRMA.Equals("NO") && result[0].Equals("success"))
        //        {
        //            string codConstancia = result[1].ToString();
        //            return RedirectToAction("Detalles", new { constancia = codConstancia });
        //        }
        //        else
        //        {
        //            return RedirectToAction("Error", "Errors", new { error = result });
        //        }
        //    }
        //}
        public ActionResult RegistrarConstancia()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ViewBag.serviciosS = new SelectList(tablesDL.Servicios(), "ID", "DESCRIPCION");
                ViewBag.serviciosP = new SelectList(tablesDL.Productos(), "ID", "DESCRIPCION");
                return View(new ConstanciaDTO());
            }
        }

        [HttpPost]
        public ActionResult RegistrarConstancia(ConstanciaDTO constancia)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string usuario = Session["NOMBRE"].ToString();
                string empresa = Session["EMPRESA"].ToString();
                string[] result = constanciaDL.GrabarConstancia(constancia, usuario, empresa).Split('|');
                if (constancia.INDICA_FIRMA.Equals("SI") && result[0].Equals("success"))
                {
                    return Redirect("/Reports/" + firmaURL + ".aspx");
                }
                if (constancia.INDICA_FIRMA.Equals("NO") && result[0].Equals("success"))
                {
                    string codConstancia = result[1].ToString();
                    return RedirectToAction("Detalles", new { constancia = codConstancia });
                }

                else
                {
                    return RedirectToAction("Error", "Errors", new { error = result[0].ToString() });
                }
            }
        }
        public ActionResult Signature()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                return Redirect("/Reports/" + firmaURL + ".aspx");
            }
        }
    }
}