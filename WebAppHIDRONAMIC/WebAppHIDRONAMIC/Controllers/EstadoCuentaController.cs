using System;
using System.Web;
using System.Web.Mvc;
using WebAppHIDRONAMIC.DAL;
using WebAppHIDRONAMIC.Utils;
using WebAppHIDRONAMIC.Reports;

namespace WebAppHIDRONAMIC.Controllers
{
    public class EstadoCuentaController : Controller
    {
        ClientesDAL clientesDL = new ClientesDAL();
        ProformasDAL proformaDL = new ProformasDAL();
        EmailDAL emailDL = new EmailDAL();
        TablesDAL tablesDL = new TablesDAL();
        LiquidacionRPT liquidacionRPT = new LiquidacionRPT();
        public ActionResult DetallesMes(string cuenta_comercial, string mes)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string idGenerado = Utilitarios.AutoGeneradoLiq();
                liquidacionRPT.ShowRemotePDF(idGenerado, mes, cuenta_comercial, Utilitarios.Ejercicio(), " ", " ");

                return RedirectToAction("EstadoCuentaPDF", new { ruta = idGenerado, cliente = cuenta_comercial });
            }
        }
        public ActionResult DetallesFechas(string cuenta_comercial, string fecha1, string fecha2)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {

                string cliente = cuenta_comercial;
                string rango1 = Utilitarios.FormatoFecha_AMD(fecha1);
                string rango2 = Utilitarios.FormatoFecha_AMD(fecha2);

                string idGenerado = Utilitarios.AutoGeneradoLiq();
                liquidacionRPT.ShowRemotePDF(idGenerado, " ", cuenta_comercial, " ", rango1, rango2);

                return RedirectToAction("EstadoCuentaPDF", new { ruta = idGenerado, cliente = cuenta_comercial });
            }
        }
        public ActionResult DetallesEstaSemana(string cuenta_comercial)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string rango1 = Utilitarios.fdcw;
                string rango2 = Utilitarios.ldcw;

                string idGenerado = Utilitarios.AutoGeneradoLiq();
                liquidacionRPT.ShowRemotePDF(idGenerado, " ", cuenta_comercial, " ", rango1, rango2);

                return RedirectToAction("EstadoCuentaPDF", new { ruta = idGenerado, cliente = cuenta_comercial });
            }
        }
        public ActionResult DetallesSemanaPasada(string cuenta_comercial)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string rango1 = Utilitarios.fdlw;
                string rango2 = Utilitarios.ldlw;

                string idGenerado = Utilitarios.AutoGeneradoLiq();
                liquidacionRPT.ShowRemotePDF(idGenerado, " ", cuenta_comercial, " ", rango1, rango2);

                return RedirectToAction("EstadoCuentaPDF", new { ruta = idGenerado, cliente = cuenta_comercial });
            }
        }
        public ActionResult DetallesEsteAnio(string cuenta_comercial)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                string rango1 = Utilitarios.Ejercicio() + "/01/01";
                string rango2 = Utilitarios.Ejercicio() + "/12/31";

                string idGenerado = Utilitarios.AutoGeneradoLiq();
                liquidacionRPT.ShowRemotePDF(idGenerado, " ", cuenta_comercial, " ", rango1, rango2);

                return RedirectToAction("EstadoCuentaPDF", new { ruta = idGenerado, cliente = cuenta_comercial });
            }
        }
        public FileResult DescargarPdf(string liquidacion)
        {
            var ruta = Server.MapPath("../UploadFiles/" + liquidacion + ".pdf");
            return File(ruta, "application/pdf", liquidacion + ".pdf");
        }
        public ActionResult EstadoCuentaPDF(string ruta, string cliente)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                ViewBag.generado = ruta;
                ViewBag.cliente = cliente;
                ViewBag.usuarios = new SelectList(tablesDL.UsuariosCorreo(), "ID", "DESCRIPCION");
                ViewBag.correo = clientesDL.CorreoPorCliente(cliente);
                //TempData["Embed"] = VirtualPathUtility.ToAbsolute("~/UploadFiles/" + ruta + ".pdf");
                return View();
            }
        }
        public ActionResult EnviarEstadoCuenta(string idGenerado, string cliente, string asunto, string cuerpo)
        {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login", "Usuarios", new { msg = "Inicie sesión de nuevo" });
            }
            else
            {
                try
                {
                    emailDL.EnviarEstadoCuenta(cliente, idGenerado, asunto, cuerpo);
                    return RedirectToAction("EstadosCuentas", new { msg = "success" });
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    return RedirectToAction("Error", "Errors", new { error = msg });
                }
            }
        }
        public ActionResult EstadosCuentas(string msg = null)
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
                return View(clientesDL.Clientes());
            }
        }
    }
}