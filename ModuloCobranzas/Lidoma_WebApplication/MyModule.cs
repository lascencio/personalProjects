using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lidoma_WebApplication.Data;

namespace Lidoma_WebApplication
{
    public class MyModule
    {
        public static dsCuentasComerciales.MyDTCuentasComercialesDataTable MyDTCuentasComercialesDataTable = new dsCuentasComerciales.MyDTCuentasComercialesDataTable();
        public static dsFinanciero.PRESTAMOS_LISTADataTable MyDTPrestamosListaDataTable = new dsFinanciero.PRESTAMOS_LISTADataTable();
        public string myConnectionStringSQL_Repository { set; get; }

        public MyModule()
        {
            myConnectionStringSQL_Repository = "Data Source=3.18.124.90;Initial Catalog=Test;User ID=sa;Password=Lidoma2019!";
        }
    }
}