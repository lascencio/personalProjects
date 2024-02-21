using System;
using System.Web.Mvc;
using WebAppHIDRONAMIC.DAL;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.DS;
using System.Collections.Generic;
using WebAppHIDRONAMIC.Utils;

namespace WebAppHIDRONAMIC.Controllers
{
    public class UsuariosController : Controller
    {
        UsuarioDAL usuariosDL = new UsuarioDAL();

        public ActionResult Login(string msg = null)
        {
            if (string.IsNullOrEmpty(msg))
                ViewBag.mensaje = "";
            else
                ViewBag.mensaje = msg;

            return View(new UsuarioDTO());
        }

        [HttpPost]
        public ActionResult Login(UsuarioDTO reg)
        {
            UsuarioDTO usu = null;
            try
            {
                usu = usuariosDL.Loguearse(reg.USUARIO, reg.CLAVE);
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
                usuariosDL.ValidarTipoCambio();
                Session["NOMBRE"] = usu.NOMBRE_CORTO;
                Session["USUARIO"] = usu.USUARIO;
                Session["EMPRESA"] = usu.EMPRESA;
                Session["CLAVE"] = usu.CLAVE;
                Session["EMAIL"] = usu.EMAIL;
                Session["PERFIL"] = usu.PERFIL;

                if (usu.PERFIL.Equals("4")) {
                    Utilitarios.USUARIO_CORREO = usu.EMAIL;
                }

                //INICIAR DATATABLES DINÁMICOS
                Session["dtConstanciaDet"] = new ConstanciasDS.ConstanciaDetallesDTDataTable();
                Session["dtConstanciaCab"] = new ConstanciasDS.ConstanciasDTDataTable();
                Session["dtCotizacionDet"] = new ProformasDS.CotizacionDetDTDataTable();
                Session["dtCotizacionDet_cons"] = new ProformasDS.CotizacionDetDTDataTable();
                Session["dtCotizacionCab"] = new ProformasDS.CotizacionDatDTDataTable();
                Session["dtCotizacionxCliente"] = new ProformasDS.CotizacionPorClienteDTDataTable();
                Session["dtConstanciasXcliente"] = new ConstanciasDS.ConstanciasPorClienteDTDataTable();
                Session["correos"] = new List<string>();
                Session["correosLiq"] = new List<string>();

                string result = usuariosDL.LLenarDataTables();

                if (result.Equals("SUCCESS"))
                {
                    Session["dtClientesXcuenta"] = MyModule.dtClientesXcuenta;
                    return RedirectToAction("RegistrarConstancia", "Constancia");
                }
                else
                    return RedirectToAction("Error", "Errors", new { error = result });
            }
        }
    }
}
