using System.Web;
using System.Web.Optimization;

namespace Lidoma_WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/admin2-css/bootstrap.min.css",
                      "~/Content/admin2-css/sb-admin-2.css",
                      "~/Content/admin2-css/metisMenu.min.css",
                      "~/Content/admin2-css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/admin2-js/jquery.min.js",
                      "~/Content/admin2-js/bootstrap.min.js",
                      "~/Content/admin2-js/metisMenu.min.js",
                      "~/Content/admin2-js/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

        }
    }
}