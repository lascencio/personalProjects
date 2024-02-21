using Lidoma_WebApplication.Data;
using Lidoma_WebApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lidoma_WebApplication
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("MyCuentaComercial", new entCuentaComercial());
            HttpContext.Current.Session.Add("MyPrestamosLista", new dsFinanciero.PRESTAMOS_LISTADataTable());
            HttpContext.Current.Session.Add("MyPrestamosCuotasLista", new dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable());
            HttpContext.Current.Session.Add("MyListaCuotas", new List<entPrestamoCuotas>());
            HttpContext.Current.Session.Add("MyPrestamo", new entPrestamo());
        }
    }
}