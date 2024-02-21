using System.Configuration;
using WebAppHIDRONAMIC.DS;

namespace WebAppHIDRONAMIC
{
    public class MyModule
    {
        public static ConstanciasDS.ConstanciaDetallesDTDataTable dtDetalle = new ConstanciasDS.ConstanciaDetallesDTDataTable();
        public static ConstanciasDS.ConstanciasPorClienteDTDataTable dtConstanciasXcliente = new ConstanciasDS.ConstanciasPorClienteDTDataTable();
        public static ConstanciasDS.ConstanciasDTDataTable dtConstancias = new ConstanciasDS.ConstanciasDTDataTable();

        public static ProductosDS.ProductosDTDataTable dtProductos = new ProductosDS.ProductosDTDataTable();
        public static ProductosDS.ServiciosDTDataTable dtServicios = new ProductosDS.ServiciosDTDataTable();
        public static ProductosDS.Productos_ServiciosDTDataTable dtProd_Serv = new ProductosDS.Productos_ServiciosDTDataTable();

        public static PiscinasDS.Piscinas_S_DTDataTable dtPiscinasSmall = new PiscinasDS.Piscinas_S_DTDataTable();
        public static PiscinasDS.PiscinasDTDataTable dtPiscinas = new PiscinasDS.PiscinasDTDataTable();
        public static PiscinasDS.PiscinasInfoDTDataTable dtPiscinasInfo = new PiscinasDS.PiscinasInfoDTDataTable();

        public static MaestrosDS.ComboBoxDataTable dtProvincias = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtDepartamentos = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtDistritos = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtTiposDoc = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtTiposPisc = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtFrecuenciasPisc = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtTipoProformas = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtTiposMoneda = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtTiposPiscProf = new MaestrosDS.ComboBoxDataTable();
        public static MaestrosDS.ComboBoxDataTable dtFormPiscinas = new MaestrosDS.ComboBoxDataTable();

        public static MaestrosDS.ItemsProformaDTDataTable dtItemsProforma = new MaestrosDS.ItemsProformaDTDataTable();
        public static MaestrosDS.FamiliaDTDataTable dtFamilias = new MaestrosDS.FamiliaDTDataTable();

        public static ClientesDS.ClientesXcuentaDTDataTable dtClientesXcuenta = new ClientesDS.ClientesXcuentaDTDataTable();
        public static ClientesDS.ClientesDTDataTable dtClientes = new ClientesDS.ClientesDTDataTable();

        public static ProformasDS.CotizacionDetDTDataTable dtCotizacionDet = new ProformasDS.CotizacionDetDTDataTable();
        public static ProformasDS.CotizacionDatDTDataTable dtCotizacion = new ProformasDS.CotizacionDatDTDataTable();
        public static ProformasDS.CotizacionPorClienteDTDataTable dtCotizacionxCliente = new ProformasDS.CotizacionPorClienteDTDataTable();

        public static string myConnectionStringSQL_Repository { set; get; }

        public MyModule()
        {
            myConnectionStringSQL_Repository = ConfigurationManager.ConnectionStrings["cnnSQLRepositoryD"].ConnectionString;
        }

    }
}