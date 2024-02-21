using System.Web;
using WebAppHIDRONAMIC.DAL;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.Utils;
using System.Web.Mvc;
using System.Collections.Generic;

namespace WebAppHIDRONAMIC.Controllers
{
    public class ProformasController : Controller
    {
        ProformasDAL proformaDL = new ProformasDAL();
        TablesDAL tablesDL = new TablesDAL();

        [HttpPost]
        public ActionResult AgregarCorreosLiq(string usuario)
        {
            var result = proformaDL.AgregarCorreosLiq(usuario);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarCorreoLiq(string correo)
        {
            var result = proformaDL.EliminarCorreoLiq(correo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarCorreos(string usuario)
        {
            var result = proformaDL.AgregarCorreos(usuario);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarCorreo(string correo)
        {
            var result = proformaDL.EliminarCorreo(correo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarDetalle(string producto)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.EliminarDetalle(producto);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EnviarProforma(string proforma, string asunto, string cuerpo)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string result = proformaDL.EnviarProformaEmail(proforma, asunto, cuerpo);
                if (result.Equals("SUCCESS"))
                    return RedirectToAction("Proformas", new { msg = "Proforma "+proforma+" enviada!" });
                else
                    return RedirectToAction("Error", "Errors", new { error = result });
            }
        }

        [HttpPost]
        public ActionResult EliminarUbicacion(string proforma)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.DeletePDF(proforma);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string proforma)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.Eliminar(proforma);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ReconstruirPDF(string proforma)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
               // ESTE MÉTODO ES TEMPORAL...MIENTRAS SE GENEREN LOS PDFS
                string result = proformaDL.GenerarProformaPDF(proforma);
                if (result[0].Equals("SUCCESS"))
                {
                    return RedirectToAction("Proformas", new { msg = "PDF de proforma " + proforma + " generada. Puede visualizarla" });
                }

                else
                {
                    return RedirectToAction("Error", "Errors", new { error = result });
                }
            }
        }

        public FileResult DescargarPdf(string proforma)
        {
            var ruta = Server.MapPath("../UploadFiles/"+proforma+".pdf");
            return File(ruta, "application/pdf", proforma + ".pdf");
        }

        public ActionResult GenerarProforma()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                //**********************COMBOS BOXEX PARA PRODUCTOS Y FAMILIAS***********************//
                ViewBag.famCaseta = new SelectList(tablesDL.Familias("1041"), "ID", "DESCRIPCION");
                ViewBag.productoCas = new SelectList(tablesDL.ItemsProforma("27"), "ID", "DESCRIPCION");

                ViewBag.famEmpotrable = new SelectList(tablesDL.Familias("1049"), "ID", "DESCRIPCION");
                ViewBag.productoEmp = new SelectList(tablesDL.ItemsProforma("29"), "ID", "DESCRIPCION");

                ViewBag.famIluminacion = new SelectList(tablesDL.Familias("1043"), "ID", "DESCRIPCION");
                ViewBag.productoIlu = new SelectList(tablesDL.ItemsProforma("32"), "ID", "DESCRIPCION");

                ViewBag.famTemperado = new SelectList(tablesDL.Familias("1046"), "ID", "DESCRIPCION");
                ViewBag.productoTem = new SelectList(tablesDL.ItemsProforma("40"), "ID", "DESCRIPCION");

                ViewBag.famAcabado = new SelectList(tablesDL.Familias("1047"), "ID", "DESCRIPCION");
                ViewBag.productoAca = new SelectList(tablesDL.ItemsProforma("55"), "ID", "DESCRIPCION");

                ViewBag.famLimpieza = new SelectList(tablesDL.Familias("1068"), "ID", "DESCRIPCION");
                ViewBag.productoLim = new SelectList(tablesDL.ItemsProforma("60"), "ID", "DESCRIPCION");

                //**********************COMBOS BOXEX PARA PRODUCTOS Y FAMILIAS***********************//
                ViewBag.tipProformas = new SelectList(tablesDL.TiposProforma(), "ID", "DESCRIPCION");
                ViewBag.tipMonedas = new SelectList(tablesDL.TipoMonedas(), "ID", "DESCRIPCION");
                ViewBag.tipPiscinas = new SelectList(tablesDL.TipoPiscinasProf(), "DESCRIPCION", "DESCRIPCION");
                ViewBag.formPiscinas = new SelectList(tablesDL.FormaPiscinas(), "DESCRIPCION", "DESCRIPCION");

                return View(new ProformaDTO());

            }
        }

        [HttpPost]
        public ActionResult GenerarProforma(ProformaDTO proforma)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string usuario = Session["NOMBRE"].ToString();
                string empresa = Session["EMPRESA"].ToString();
                string codUsuario = Session["USUARIO"].ToString();
                string[] result = proformaDL.GenerarProforma(proforma, usuario, codUsuario, empresa).Split('/');
                string r = result[0];
                if (result[0].Equals("success"))
                {
                    return RedirectToAction("ProformaPDF", new { proforma = result[1].ToString(), cliente = result[2].ToString() });
                }

                else
                {
                    return RedirectToAction("Error", "Errors", new { error = result[0].ToString() });
                }
            }
        }

        [HttpPost]
        public ActionResult GrabarDetalle(string producto, string descripcion, string cantidad, string precio, string familia, string indica, string descuento)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.GrabarDetalles(producto, descripcion, cantidad, precio, familia, descuento);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult ListarDias(string anio, string mes)
        {
            var result = proformaDL.ListarDias(anio, mes);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LimpiarDSDetalles()
        {
            var result = proformaDL.LimpiarDSDetalles();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListarDSDetalle()
        {
            var result = proformaDL.ListarDSDetalle();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListarDSDetalleCons()
        {
            var result = proformaDL.ListarDSDetalleCons();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListaTiposCambio(TipoCambioDTO tipo)
        {
            var result = proformaDL.ListarTiposCambio(tipo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MantenimientoCambio(TipoCambioDTO tipo)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string usuario = Session["NOMBRE"].ToString();
                var result = proformaDL.MantenimientoCambio(tipo, usuario);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ModificarProforma(string proforma, string accion)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ProformaDTO reg;
                if (accion.Equals("modificar"))
                {
                    ViewBag.tipo = "modificar";
                    reg = proformaDL.EliminarProforma(proforma);
                }
                else
                {
                    ViewBag.tipo = "consultar";
                    reg = proformaDL.ConsultarProforma(proforma);
                }

                //**********************COMBOS BOXEX PARA PRODUCTOS Y FAMILIAS***********************//
                ViewBag.serviciosS = new SelectList(tablesDL.Servicios(), "ID", "DESCRIPCION");
                ViewBag.serviciosP = new SelectList(tablesDL.Productos(), "ID", "DESCRIPCION");

                ViewBag.famCaseta = new SelectList(tablesDL.Familias("1041"), "ID", "DESCRIPCION");
                ViewBag.productoCas = new SelectList(tablesDL.ItemsProforma("37"), "ID", "DESCRIPCION");

                ViewBag.famEmpotrable = new SelectList(tablesDL.Familias("1049"), "ID", "DESCRIPCION");
                ViewBag.productoEmp = new SelectList(tablesDL.ItemsProforma("49"), "ID", "DESCRIPCION");

                ViewBag.famIluminacion = new SelectList(tablesDL.Familias("1043"), "ID", "DESCRIPCION");
                ViewBag.productoIlu = new SelectList(tablesDL.ItemsProforma("33"), "ID", "DESCRIPCION");

                ViewBag.famTemperado = new SelectList(tablesDL.Familias("1046"), "ID", "DESCRIPCION");
                ViewBag.productoTem = new SelectList(tablesDL.ItemsProforma("40"), "ID", "DESCRIPCION");

                ViewBag.famAcabado = new SelectList(tablesDL.Familias("1047"), "ID", "DESCRIPCION");
                ViewBag.productoAca = new SelectList(tablesDL.ItemsProforma("55"), "ID", "DESCRIPCION");

                ViewBag.famLimpieza = new SelectList(tablesDL.Familias("1068"), "ID", "DESCRIPCION");
                ViewBag.productoLim = new SelectList(tablesDL.ItemsProforma("60"), "ID", "DESCRIPCION");

                //**********************COMBOS BOXEX PARA PRODUCTOS Y FAMILIAS***********************//
                ViewBag.tipProformas = new SelectList(tablesDL.TiposProforma(), "ID", "DESCRIPCION");
                ViewBag.tipMonedas = new SelectList(tablesDL.TipoMonedas(), "ID", "DESCRIPCION");
                ViewBag.tipPiscinas = new SelectList(tablesDL.TipoPiscinasProf(), "DESCRIPCION", "DESCRIPCION");
                ViewBag.formPiscinas = new SelectList(tablesDL.FormaPiscinas(), "DESCRIPCION", "DESCRIPCION");

                return View(reg);
            }
        }

        [HttpPost]
        public ActionResult Productos(string familia)
        {
            var productos = tablesDL.ItemsProforma(familia);
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Proformas(string msg = null)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                if (string.IsNullOrEmpty(msg))
                    ViewBag.mensaje = "";
                else
                    ViewBag.mensaje = msg;
                return View(proformaDL.ProformasPorMes(""));
            }
        }
        public ActionResult ProformaPDF(string proforma, string cliente)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                if (string.IsNullOrEmpty(cliente))
                    ViewBag.opciones = "nulo";
                else
                    ViewBag.opciones = "nonulo";

                string ruta = Server.MapPath("../UploadFiles/" + proforma + ".pdf");
                if (System.IO.File.Exists(@"" + ruta))
                {
                    ViewBag.usuarios = new SelectList(tablesDL.UsuariosCorreo(), "ID", "DESCRIPCION");
                    ViewBag.proforma = proforma;
                    ViewBag.cliente = cliente;
                    //TempData["Embed"] = VirtualPathUtility.ToAbsolute("~/UploadFiles/" + proforma + ".pdf");
                    return View();
                }
                else
                {
                    return RedirectToAction("Proformas", new { msg = "Proforma " + proforma + " no encontrada. Por favor vuela a generar." });
                }
                
            }
        }

        [HttpPost]
        public ActionResult ProformasPorFechas(string fecha1, string fecha2)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.ProformasPorFechas(Utilitarios.FormatoFecha_AMD(fecha1), Utilitarios.FormatoFecha_AMD(fecha2));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProformasPorSemanaActual()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.ProformasPorFechas(Utilitarios.fdcw, Utilitarios.ldcw);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProformasPorSemanaPasada()
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.ProformasPorFechas(Utilitarios.fdlw, Utilitarios.ldlw);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProformasPorMes(string mes)
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
                var result = proformaDL.ProformasPorMes(mes);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProformasPorAnio(string anio)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                var result = proformaDL.ProformasPorAnio(anio);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProformasPorCliente(string cliente)
        {
            string param = cliente.ToUpper().Trim();
            var result = proformaDL.ProformasPorCliente(param);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TiposDeCambio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarTipoCamHoy()
        {
            TablesDTO tab = new TablesDTO();
            if (Utilitarios.TIPO_CAMBIO != 0)
                tab.DESCRIPCION = "SI";
            else
                tab.DESCRIPCION = "NO";
            var tipos = tab;

            return Json(tipos, JsonRequestBehavior.AllowGet);
        }

    }
}