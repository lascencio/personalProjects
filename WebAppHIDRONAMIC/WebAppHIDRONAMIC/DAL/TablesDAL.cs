using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHIDRONAMIC.Utils;
using System.Data.SqlClient;
using System.Text;
using WebAppHIDRONAMIC.Entities;
using WebAppHIDRONAMIC.DS;

namespace WebAppHIDRONAMIC.DAL
{
    public class TablesDAL
    {
        ConexionSQLServer conexion = new ConexionSQLServer();
        private ProductosDS.ProductosDTDataTable dtProductos = MyModule.dtProductos;
        private ProductosDS.ServiciosDTDataTable dtServicios = MyModule.dtServicios;
        private MaestrosDS.ComboBoxDataTable dtDepartamentos = MyModule.dtDepartamentos;
        private MaestrosDS.ComboBoxDataTable dtProvincias = MyModule.dtProvincias;
        private MaestrosDS.ComboBoxDataTable dtDistritos = MyModule.dtDistritos;
        private MaestrosDS.ComboBoxDataTable dtTiposDoc = MyModule.dtTiposDoc;
        private MaestrosDS.ComboBoxDataTable dtTiposPisc = MyModule.dtTiposPisc;
        private MaestrosDS.ComboBoxDataTable dtFrecuenciasPisc = MyModule.dtFrecuenciasPisc;
        private MaestrosDS.ComboBoxDataTable dtTipoProformas = MyModule.dtTipoProformas;
        private MaestrosDS.ComboBoxDataTable dtTiposMoneda = MyModule.dtTiposMoneda;
        private MaestrosDS.ComboBoxDataTable dtTiposPiscProf = MyModule.dtTiposPiscProf;
        private MaestrosDS.ComboBoxDataTable dtFormPiscinas = MyModule.dtFormPiscinas;
        private MaestrosDS.ItemsProformaDTDataTable dtItemsProforma = MyModule.dtItemsProforma;
        private MaestrosDS.FamiliaDTDataTable dtFamilias = MyModule.dtFamilias;

        public List<TablesDTO> Productos()
        {
            List<TablesDTO> productos = new List<TablesDTO>();
            for (int i = 0; i <= dtProductos.Rows.Count - 1; i++)
            {
                TablesDTO producto = new TablesDTO();
                producto.ID = dtProductos[i].MIXED_COLUMN;
                producto.DESCRIPCION = dtProductos[i].DESCRIPCION;
                producto.VALOR = dtProductos[i].PRECIO;
                //el campo estado equivale al id del producto
                producto.ESTADO = dtProductos[i].SERVICIO;
                producto.TIPO = dtProductos[i].TIPO;
                productos.Add(producto);
            }
            return productos;
        }
        public List<TablesDTO> Servicios()
        {
            List<TablesDTO> servicios = new List<TablesDTO>();
            for (int i = 0; i <= MyModule.dtServicios.Rows.Count - 1; i++)
            {
                TablesDTO servicio = new TablesDTO();
                servicio.ID = dtServicios[i].MIXED_COLUMN;
                servicio.DESCRIPCION = dtServicios[i].DESCRIPCION;
                servicio.VALOR = dtServicios[i].PRECIO;
                //el campo estado equivale al id del servicio
                servicio.ESTADO = dtServicios[i].SERVICIO;
                servicio.TIPO = dtServicios[i].TIPO;
                servicios.Add(servicio);
            }
            return servicios;
        }
        public List<TablesDTO> Departamentos()
        {
            List<TablesDTO> departamentos = new List<TablesDTO>();
            for (int i = 0; i <= dtDepartamentos.Rows.Count - 1; i++)
            {
                TablesDTO departamento = new TablesDTO();
                departamento.ID = dtDepartamentos[i].CODIGO;
                departamento.DESCRIPCION = dtDepartamentos[i].DESCRIPCION;
                departamentos.Add(departamento);
            }
            return departamentos;
        }
        public List<TablesDTO> TiposDocumento()
        {
            List<TablesDTO> tiposDocumento = new List<TablesDTO>();
            for (int i = 0; i <= dtTiposDoc.Rows.Count - 1; i++)
            {
                TablesDTO tipo = new TablesDTO();
                tipo.ID = dtTiposDoc[i].CODIGO;
                tipo.DESCRIPCION = dtTiposDoc[i].DESCRIPCION;
                tiposDocumento.Add(tipo);
            }
            return tiposDocumento;
            //List<TablesDTO> tipos = new List<TablesDTO>();
            //conexion.cn.Open();
            //string sql = "SELECT * FROM GEN.TIPOS_DOCUMENTO ORDER BY CODIGO";
            //SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    TablesDTO servicio = new TablesDTO();
            //    servicio.ID = dr[0].ToString();
            //    servicio.DESCRIPCION = dr[1].ToString();
            //    tipos.Add(servicio);
            //}
            //dr.Close();
            //conexion.cn.Close();
            //return tipos;
        }
        public List<TablesDTO> Provincias(string depa)
        {
            List<TablesDTO> provincias = new List<TablesDTO>();
            var pro = from p in dtProvincias
                      where p.CODIGO.StartsWith(depa)
                      select new
                      {
                          CODIGO = p.CODIGO,
                          DESCRIPCION = p.DESCRIPCION,
                      };
            foreach (var p in pro)
            {
                TablesDTO provincia = new TablesDTO();
                provincia.ID = p.CODIGO;
                provincia.DESCRIPCION = p.DESCRIPCION;
                provincias.Add(provincia);
            }
            //string sql = "";
            //if (String.IsNullOrEmpty(depa))
            //    sql = "SELECT * FROM GEN.TABLA_UBIGEO_PROVINCIA ORDER BY DESCRIPCION";
            //else
            //    sql = "SELECT * FROM GEN.TABLA_UBIGEO_PROVINCIA WHERE CODIGO LIKE '" + depa + "%' ORDER BY DESCRIPCION";
            //List<TablesDTO> servicios = new List<TablesDTO>();
            //conexion.cn.Open();
            //SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    TablesDTO servicio = new TablesDTO();
            //    servicio.ID = dr[0].ToString();
            //    servicio.DESCRIPCION = dr[1].ToString();
            //    servicios.Add(servicio);
            //}
            //dr.Close();
            //conexion.cn.Close();
            return provincias;
        }
        public List<TablesDTO> Distritos(string prov)
        {
            List<TablesDTO> distritos = new List<TablesDTO>();
            var dis = from d in dtDistritos
                      where d.CODIGO.StartsWith(prov)
                      select new
                      {
                          CODIGO = d.CODIGO,
                          DESCRIPCION = d.DESCRIPCION,
                      };
            foreach (var d in dis)
            {
                TablesDTO provincia = new TablesDTO();
                provincia.ID = d.CODIGO;
                provincia.DESCRIPCION = d.DESCRIPCION;
                distritos.Add(provincia);
            }
            return distritos;
            //string sql = "";
            //if (String.IsNullOrEmpty(prov))
            //    sql = "SELECT * FROM [GEN].[TABLA_UBIGEO] ORDER BY DESCRIPCION";
            //else
            //    sql = "SELECT * FROM [GEN].[TABLA_UBIGEO] WHERE CODIGO LIKE '" + prov + "%' ORDER BY DESCRIPCION";
            //List<TablesDTO> servicios = new List<TablesDTO>();
            //conexion.cn.Open();

            //SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    TablesDTO servicio = new TablesDTO();
            //    servicio.ID = dr[0].ToString();
            //    servicio.DESCRIPCION = dr[1].ToString();
            //    servicios.Add(servicio);
            //}
            //dr.Close();
            //conexion.cn.Close();
            //return servicios;
        }
        public List<TablesDTO> TipoPiscinasProf()
        {
            List<TablesDTO> tiposPiscinasProf = new List<TablesDTO>();
            for (int i = 0; i <= dtTiposPiscProf.Rows.Count - 1; i++)
            {
                TablesDTO tipo = new TablesDTO();
                tipo.ID = dtTiposPiscProf[i].CODIGO;
                tipo.DESCRIPCION = dtTiposPiscProf[i].DESCRIPCION;
                tiposPiscinasProf.Add(tipo);
            }
            return tiposPiscinasProf;
        }
        public List<TablesDTO> FormaPiscinas()
        {
            List<TablesDTO> tiposPiscinasProf = new List<TablesDTO>();
            for (int i = 0; i <= dtFormPiscinas.Rows.Count - 1; i++)
            {
                TablesDTO tipo = new TablesDTO();
                tipo.ID = dtFormPiscinas[i].CODIGO;
                tipo.DESCRIPCION = dtFormPiscinas[i].DESCRIPCION;
                tiposPiscinasProf.Add(tipo);
            }
            return tiposPiscinasProf;
        }

        public List<TablesDTO> TipoPiscinas()
        {
            List<TablesDTO> tiposPiscinas = new List<TablesDTO>();
            for (int i = 0; i <= dtTiposPisc.Rows.Count - 1; i++)
            {
                TablesDTO tipo = new TablesDTO();
                tipo.ID = dtTiposPisc[i].CODIGO;
                tipo.DESCRIPCION = dtTiposPisc[i].DESCRIPCION;
                tiposPiscinas.Add(tipo);
            }
            return tiposPiscinas;
        }
        public List<TablesDTO> FrecuenciasMant()
        {
            List<TablesDTO> frecuenciasMant = new List<TablesDTO>();
            for (int i = 0; i <= dtFrecuenciasPisc.Rows.Count - 1; i++)
            {
                TablesDTO frecuencia = new TablesDTO();
                frecuencia.ID = dtFrecuenciasPisc[i].CODIGO;
                frecuencia.DESCRIPCION = dtFrecuenciasPisc[i].DESCRIPCION;
                frecuenciasMant.Add(frecuencia);
            }
            return frecuenciasMant;
        }
        public List<TablesDTO> Familias(string subClase)
        {
            List<TablesDTO> familias = new List<TablesDTO>();
            var fam = from p in dtFamilias
                      where p.SUBCLASE == subClase
                      select new
                      {
                          CODIGO = p.CODIGO,
                          DESCRIPCION = p.DESCRIPCION,
                          SUBCLASE = p.SUBCLASE,
                      };
            foreach (var f in fam)
            {
                TablesDTO familia = new TablesDTO();
                familia.ID = f.CODIGO;
                familia.DESCRIPCION = f.DESCRIPCION;
                familia.ESTADO = f.SUBCLASE; //-->ESTADO EQUIVALE A SUBCLASE
                familias.Add(familia);
            }
            return familias;
        }
        public List<TablesDTO> TiposProforma()
        {
            List<TablesDTO> tiposProforma = new List<TablesDTO>();
            for (int i = 0; i <= dtTipoProformas.Rows.Count - 1; i++)
            {
                TablesDTO tipo = new TablesDTO();
                tipo.ID = dtTipoProformas[i].CODIGO;
                tipo.DESCRIPCION = dtTipoProformas[i].DESCRIPCION;
                tiposProforma.Add(tipo);
            }
            return tiposProforma;
        }
        public List<TablesDTO> TipoMonedas()
        {
            TablesDTO c1 = new TablesDTO();
            TablesDTO c2 = new TablesDTO();
            c1.ID = "1";
            c1.DESCRIPCION = "SOLES";
            c2.ID = "2";
            c2.DESCRIPCION = "DÓLARES";
            List<TablesDTO> cambio = new List<TablesDTO>();
            cambio.Add(c1);
            cambio.Add(c2);
            return cambio;
        }
        public List<TablesDTO> ItemsProforma(string familia)
        {
            List<TablesDTO> productos = new List<TablesDTO>();
            var pro = from p in dtItemsProforma
                      where p.FAMILIA == familia
                      select new
                      {
                          MIXED_COLUMN = p.MIXED_COLUMN,
                          DESCRIPCION = p.DESCRIPCION,
                          FAMILIA = p.FAMILIA,
                          MARCA = p.MARCA
                      };
            foreach (var p in pro)
            {
                TablesDTO producto = new TablesDTO();
                producto.ID = p.MIXED_COLUMN + "|" + p.MARCA;
                producto.DESCRIPCION = p.DESCRIPCION + " - " + p.MARCA;
                producto.ESTADO = p.FAMILIA; //-->ESTADO EQUIVALE A SUBCLASE(FAMILIA)
                producto.TEXTO_01 = p.MARCA;
                productos.Add(producto);
            }
            return productos;
        }

        public List<TablesDTO> UsuariosCorreo()
        {
            List<TablesDTO> usuarios = new List<TablesDTO>();
            conexion.cn.Open();
            string sql = "SELECT NOMBRE_CORTO, CORREO FROM [GEN].[USUARIOS_SIST] WHERE TIPO_USUARIO = '2'";
            SqlCommand cmd = new SqlCommand(sql, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TablesDTO usuario = new TablesDTO();
                usuario.ID = dr[1].ToString();
                usuario.DESCRIPCION = dr[0].ToString();
                usuarios.Add(usuario);
            }
            TablesDTO otros = new TablesDTO();
            otros.ID = "otros";
            otros.DESCRIPCION = "Otros";
            usuarios.Add(otros);
            dr.Close();
            conexion.cn.Close();
            return usuarios;
        }

    }
}