using Lidoma_WebApplication.Data;
using Lidoma_WebApplication.Entities;
using Lidoma_WebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.VisualBasic;
using System.Data;

namespace Lidoma_WebApplication.DAL
{
    public class dalFinanciamiento
    {
        private entCuentaComercial MyCuentaComercial = HttpContext.Current.Session["MyCuentaComercial"] as entCuentaComercial;
        //Esta variable se utiliza para almacenar los préstamos (incluido su importe y moneda) para ser mostrado en la cabecera del GUI.
        private dsFinanciero.PRESTAMOS_LISTADataTable MyPrestamosLista = HttpContext.Current.Session["MyPrestamosLista"] as dsFinanciero.PRESTAMOS_LISTADataTable;
        //Esta variable se utiliza para obtener las cuotas del prestamo seleccionado. También se utilizá para hacer el cálculo de las cuotas a pagar
        private dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable MyPrestamosCuotaLista = HttpContext.Current.Session["MyPrestamosCuotasLista"] as dsFinanciero.PRESTAMOS_CUOTAS_LISTADataTable;
        //Esta variable tipo List sólo sirve para almacenar por interno las cuotas que se agregan (seleccionan desde la GUI del usuario)
        private List<entPrestamoCuotas> MyListaCuotas = HttpContext.Current.Session["MyListaCuotas"] as List<entPrestamoCuotas>;
        //Esta variable se utiliza para almacenar el valor de TASA_MOROSIDAD y así utilizarlo en toda la clase, sin necesidad de calcularlo de nuevo
        private entPrestamo MyPrestamo = HttpContext.Current.Session["MyPrestamo"] as entPrestamo;
        private entUsuario MyUsuario = HttpContext.Current.Session["MyUsuario"] as entUsuario;

        //Declarar variables que se usarán en toda esta clase
        private decimal cuota_pago = 0, mora = 0, total_pago = 0;
        private dsFinanciero.COBRANZASDataTable MyCobranza;
        private dsFinanciero.PRESTAMOSDataTable MyPrestamoDT;

        //Instanciar clases de uso común
        ConexionSQLServer conexion = new ConexionSQLServer();
        Procesos procesos = new Procesos();

        public List<entPrestamo> ObtenerPrestamos(string pEstado)
        {
            //Reiniciamos el datatable
            MyPrestamosLista.Clear();

            StringBuilder CadenaSQL = new StringBuilder();
            CadenaSQL.Append("SELECT P.PRESTAMO, TP.DESCRIPCION AS TIPO_PRESTAMO, FECHA_REGISTRO, P.RAZON_SOCIAL, MONEDA=CASE WHEN P.TIPO_MONEDA='1' THEN 'PEN' ELSE 'USD' END, ");
            CadenaSQL.Append("P.CAPITAL, P.NUMERO_CUOTAS, VALOR_CUOTA, TOTAL_PRESTAMO  ");
            CadenaSQL.Append("FROM FIN.PRESTAMOS AS P INNER JOIN GEN.TABLA_TIPO_PRESTAMO AS TP ON P.EMPRESA=TP.EMPRESA AND P.TIPO_PRESTAMO=TP.CODIGO ");
            CadenaSQL.Append("WHERE P.EMPRESA='" + MyCuentaComercial.empresa + "' AND P.AGENCIA_REGISTRO='A0000001' ");
            CadenaSQL.Append("AND P.TIPO_DOCUMENTO='" + MyCuentaComercial.tipo_documento + "' AND P.NRO_DOCUMENTO='" + MyCuentaComercial.nro_documento + "");
            CadenaSQL.Append(pEstado == "TODOS" ? "' " : "' AND P.ESTADO='" + pEstado + "' ");
            CadenaSQL.Append(pEstado != "V" ? "" : " AND P.TOTAL_SALDO>0 ");

            procesos.ObtenerDataTableSQL(CadenaSQL.ToString(), MyPrestamosLista);

            List<entPrestamo> prestamos = new List<entPrestamo>();
            for (int i = 0; i <= MyPrestamosLista.Rows.Count - 1; i++)
            {
                entPrestamo prestamo = new entPrestamo();
                prestamo.PRESTAMO = MyPrestamosLista[i].PRESTAMO;
                prestamo.TIPO_PRESTAMO = MyPrestamosLista[i].TIPO_PRESTAMO;
                prestamo.FECHA_REGISTRO = MyPrestamosLista[i].FECHA_REGISTRO.ToString("dd/MM/yyyy");
                prestamo.RAZON_SOCIAL = MyPrestamosLista[i].RAZON_SOCIAL;
                prestamo.MONEDA = MyPrestamosLista[i].MONEDA.Equals("PEN") ? "SOLES" : "DÓLARES";
                prestamo.CAPITAL = MyPrestamosLista[i].CAPITAL;
                prestamo.NUMERO_CUOTAS = MyPrestamosLista[i].NUMERO_CUOTAS;
                prestamo.VALOR_CUOTA = MyPrestamosLista[i].VALOR_CUOTA;
                prestamo.TOTAL_PRESTAMO = MyPrestamosLista[i].TOTAL_PRESTAMO;

                prestamo.s_TOTAL_PRESTAMO = string.Format("{0:0,0.00}", prestamo.TOTAL_PRESTAMO);
                prestamos.Add(prestamo);
            }

            return prestamos;
        }

        public dsFinanciero.PRESTAMOSDataTable ObtenerPrestamo(string pEmpresa, string pPrestamo)
        {
            dsFinanciero.PRESTAMOSDataTable MyDT = new dsFinanciero.PRESTAMOSDataTable();
            string CadenaSQL = "SELECT *  FROM FIN.PRESTAMOS WHERE EMPRESA='" + pEmpresa + "' AND PRESTAMO='" + pPrestamo + "' ";
            procesos.ObtenerDataTableSQL(CadenaSQL, MyDT);
            return MyDT;
        }

        public entPrestamo SeleccionarPrestamo(string prestamo)
        {
            entPrestamo ePrestamo = new entPrestamo();
            var prestamos = from p in MyPrestamosLista
                            where p.PRESTAMO == prestamo
                            select new
                            {
                                TOTAL_PRESTAMO = p.TOTAL_PRESTAMO,
                                MONEDA = p.MONEDA,
                                PRESTAMO = p.PRESTAMO
                            };
            foreach (var p in prestamos)
            {
                ePrestamo.PRESTAMO = p.PRESTAMO;
                ePrestamo.TOTAL_PRESTAMO = p.TOTAL_PRESTAMO;
                ePrestamo.MONEDA = p.MONEDA;
                ePrestamo.s_TOTAL_PRESTAMO = string.Format("{0:0,0.00}", p.TOTAL_PRESTAMO);
            }
            return ePrestamo;
        }

        public decimal ObtenerTasaMorosidad(string prestamo)
        {
            decimal tasa_morosidad = 0;
            string CadenaSQL = "SELECT TASA_MOROSIDAD FROM FIN.PRESTAMOS WHERE EMPRESA='001' AND PRESTAMO='" + prestamo + "' ";

            conexion.cn.Open();
            SqlCommand cmd = new SqlCommand(CadenaSQL, conexion.cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                tasa_morosidad = Decimal.Parse(dr[0].ToString());
            }
            dr.Close();
            conexion.cn.Close();

            return tasa_morosidad;
        }

        public List<entPrestamoCuotas> ObtenerPrestamoCuotasLista(string prestamo)
        {
            //Limpiamos/Reiniciamos variables Session
            MyPrestamosCuotaLista.Clear();
            MyListaCuotas.Clear();

            StringBuilder CadenaSQL = new StringBuilder();
            CadenaSQL.Append("SELECT CUOTA AS NUMERO_CUOTA, FECHA_VENCIMIENTO, VALOR_CUOTA,FECHA_PAGO=CASE WHEN YEAR(FECHA_PAGO)<=1900 THEN '" + procesos.FechaNulo + "' ELSE FECHA_PAGO END,SALDO_CUOTA, ");
            CadenaSQL.Append("DIAS_MORA=CASE WHEN SALDO_CUOTA=0 THEN 0 ELSE (CASE WHEN UTI.DIAS_MORA(CASE WHEN YEAR(FECHA_PAGO)>1900 THEN FECHA_PAGO ELSE FECHA_VENCIMIENTO END)<0 THEN 0 ELSE UTI.DIAS_MORA(CASE WHEN YEAR(FECHA_PAGO)>1900 THEN FECHA_PAGO ELSE FECHA_VENCIMIENTO END) END) END, MORA, ");
            CadenaSQL.Append("CUOTA_PAGO=SALDO_CUOTA,MORA_PAGO=MORA, 0 AS TOTAL_PAGO, ");
            CadenaSQL.Append("COMPROMISO_FECHA=CASE WHEN YEAR(COMPROMISO_FECHA)<=1900 THEN '" + procesos.FechaNulo + "' ELSE COMPROMISO_FECHA END, COMPROMISO_COMENTARIO ");
            CadenaSQL.Append("FROM FIN.PRESTAMOS_CUOTAS WHERE EMPRESA='001' AND PRESTAMO='" + prestamo + "' AND SALDO_CUOTA<>0");

            procesos.ObtenerDataTableSQL(CadenaSQL.ToString(), MyPrestamosCuotaLista);

            //Asignamos valores a nuestra variable session tipo entPrestamo para ser usada en otros métodos
            MyPrestamo.TASA_MOROSIDAD = ObtenerTasaMorosidad(prestamo);
            MyPrestamo.PRESTAMO = prestamo;

            List<entPrestamoCuotas> cuotas = new List<entPrestamoCuotas>();
            for (int i = 0; i <= MyPrestamosCuotaLista.Rows.Count - 1; i++)
            {
                entPrestamoCuotas cuota = new entPrestamoCuotas();
                cuota.CUOTA_PAGO = MyPrestamosCuotaLista[i].CUOTA_PAGO;
                cuota.DIAS_MORA = MyPrestamosCuotaLista[i].DIAS_MORA;
                //cuota.FECHA_PAGO = MyPrestamosCuotaLista[i].FECHA_PAGO == null ? "" : MyPrestamosCuotaLista[i].FECHA_PAGO.ToString("dd/MM/yyyy");
                cuota.FECHA_VENCIMIENTO = MyPrestamosCuotaLista[i].FECHA_VENCIMIENTO.ToString("dd/MM/yyyy");
                cuota.MORA = MyPrestamosCuotaLista[i].MORA;
                cuota.MORA_PAGO = MyPrestamosCuotaLista[i].MORA_PAGO;
                cuota.NUMERO_CUOTA = MyPrestamosCuotaLista[i].NUMERO_CUOTA;
                cuota.SALDO_CUOTA = MyPrestamosCuotaLista[i].SALDO_CUOTA;
                if (cuota.SALDO_CUOTA > 0)
                {
                    cuota.MORA = cuota.SALDO_CUOTA * MyPrestamo.TASA_MOROSIDAD / 100 / 30 * cuota.DIAS_MORA;
                }
                cuota.TOTAL_PAGO = cuota.CUOTA_PAGO + cuota.MORA;
                cuota.VALOR_CUOTA = MyPrestamosCuotaLista[i].VALOR_CUOTA;

                MyPrestamosCuotaLista[i].MORA = cuota.MORA;
                MyPrestamosCuotaLista[i].TOTAL_PAGO = cuota.TOTAL_PAGO;
                MyPrestamosCuotaLista[i].VALOR_CUOTA = cuota.VALOR_CUOTA;
                MyPrestamosCuotaLista[i].MORA_PAGO = cuota.MORA;

                //Dar formato a resultados finales
                cuota.s_MORA = string.Format("{0:0,0.00}", cuota.MORA);
                cuota.s_CUOTA_PAGO = string.Format("{0:0,0.00}", cuota.CUOTA_PAGO);
                cuota.s_TOTAL_PAGO = string.Format("{0:0,0.00}", cuota.TOTAL_PAGO);
                cuotas.Add(cuota);
            }

            return cuotas;
        }

        public entPrestamoCuotas AgregarCuota(string pCuota)
        {
            entPrestamoCuotas cuota = new entPrestamoCuotas();
            bool nuevaLinea = true;

            if (MyListaCuotas.Count != 0)
            {
                for (int i = 0; i <= MyListaCuotas.Count - 1; i++)
                {
                    if (MyListaCuotas[i].NUMERO_CUOTA.Equals(pCuota))
                    {
                        nuevaLinea = false;
                    }
                }
            }
            //Si el prestamo no se encuentra en el List<cuota>, se agrega uno nuevo
            if (nuevaLinea == true)
            {
                entPrestamoCuotas lineaCuota = new entPrestamoCuotas();
                //Obtengo la cuota del DataTable MyPrestamosCuotaLista
                lineaCuota = ObtenerCuota(pCuota);
                //Agrego la cuota al List<cuota> MyListaCuotas
                MyListaCuotas.Add(lineaCuota);
            }
            if (MyListaCuotas.Count > 0)
            {
                for (int i = 0; i <= MyListaCuotas.Count - 1; i++)
                {
                    cuota_pago += MyListaCuotas[i].CUOTA_PAGO;
                    mora += MyListaCuotas[i].MORA;
                    total_pago += MyListaCuotas[i].TOTAL_PAGO;
                }

                cuota.s_CUOTA_PAGO = string.Format("{0:0,0.00}", cuota_pago);
                cuota.s_MORA = string.Format("{0:0,0.00}", mora);
                cuota.s_TOTAL_PAGO = string.Format("{0:0,0.00}", total_pago);
            }

            return cuota;
        }

        public entPrestamoCuotas QuitarCuota(string pCuota)
        {
            entPrestamoCuotas cuota = new entPrestamoCuotas();

            MyListaCuotas.RemoveAll(c => c.NUMERO_CUOTA.Equals(pCuota));
            //Cambio el valor del campo SELECCIONAR a 0 para que no considere el el cálculo de las cuotas del método GrabarCobranza()
            for (int i = 0; i <= MyPrestamosCuotaLista.Count - 1; i++)
            {
                if (MyPrestamosCuotaLista[i].NUMERO_CUOTA.Equals(pCuota))
                {
                    MyPrestamosCuotaLista[i].SELECCIONAR = 0;
                }
            }

            if (MyListaCuotas.Count > 0)
            {
                for (int i = 0; i <= MyListaCuotas.Count - 1; i++)
                {
                    cuota_pago += MyListaCuotas[i].CUOTA_PAGO;
                    mora += MyListaCuotas[i].MORA;
                    total_pago += MyListaCuotas[i].TOTAL_PAGO;
                }
                //Retorno objeto tipo class cuota para mostrar los totales en la pantalla
                cuota.s_CUOTA_PAGO = string.Format("{0:0,0.00}", cuota_pago);
                cuota.s_MORA = string.Format("{0:0,0.00}", mora);
                cuota.s_TOTAL_PAGO = string.Format("{0:0,0.00}", total_pago);
            }
            return cuota;
        }

        public entPrestamoCuotas AgregarCuotasTodas()
        {
            entPrestamoCuotas cuotaTotal = new entPrestamoCuotas();
            MyListaCuotas.Clear();

            for (int i = 0; i <= MyPrestamosCuotaLista.Rows.Count - 1; i++)
            {
                entPrestamoCuotas cuota = new entPrestamoCuotas();
                cuota.CUOTA_PAGO = MyPrestamosCuotaLista[i].CUOTA_PAGO;
                cuota.SALDO_CUOTA = MyPrestamosCuotaLista[i].SALDO_CUOTA;
                if (cuota.SALDO_CUOTA > 0)
                {
                    cuota.MORA = cuota.SALDO_CUOTA * MyPrestamo.TASA_MOROSIDAD / 100 / 30 * MyPrestamosCuotaLista[i].DIAS_MORA;
                }
                cuota.TOTAL_PAGO = cuota.CUOTA_PAGO + cuota.MORA;
                cuota.NUMERO_CUOTA = MyPrestamosCuotaLista[i].NUMERO_CUOTA;
                //En el método GrabarCobranza() sólo se trabajará las cuotas cuyo campo SELECCIONAR sea 1
                MyPrestamosCuotaLista[i].SELECCIONAR = 1;

                //Acumulo los totales para luego mostrarlos en la pantalla
                cuotaTotal.CUOTA_PAGO += cuota.SALDO_CUOTA;
                cuotaTotal.MORA += cuota.MORA;
                cuotaTotal.TOTAL_PAGO += cuota.TOTAL_PAGO;

                MyListaCuotas.Add(cuota);
            }

            cuotaTotal.s_CUOTA_PAGO = string.Format("{0:0,0.00}", cuotaTotal.CUOTA_PAGO);
            cuotaTotal.s_MORA = string.Format("{0:0,0.00}", cuotaTotal.MORA);
            cuotaTotal.s_TOTAL_PAGO = string.Format("{0:0,0.00}", cuotaTotal.TOTAL_PAGO);

            return cuotaTotal;


        }

        public entPrestamoCuotas QuitarCuotasTodas()
        {
            entPrestamoCuotas cuota = new entPrestamoCuotas();
            MyListaCuotas.Clear();

            //Cambio el valor del campo SELECCIONAR a 0 para que no considere el el cálculo de las cuotas del método GrabarCobranza()
            for (int i = 0; i <= MyPrestamosCuotaLista.Count - 1; i++)
            {
                MyPrestamosCuotaLista[i].SELECCIONAR = 0;
            }

            return cuota;
        }

        //Método para obtener la cuota del DataTable MyPrestamosCuotaLista
        public entPrestamoCuotas ObtenerCuota(string pCuota)
        {
            entPrestamoCuotas cuota = new entPrestamoCuotas();
            for (int i = 0; i <= MyPrestamosCuotaLista.Count - 1; i++)
            {
                if (MyPrestamosCuotaLista[i].NUMERO_CUOTA.Equals(pCuota))
                {
                    cuota.CUOTA_PAGO = MyPrestamosCuotaLista[i].CUOTA_PAGO;
                    cuota.SALDO_CUOTA = MyPrestamosCuotaLista[i].SALDO_CUOTA;
                    if (cuota.SALDO_CUOTA > 0)
                    {
                        cuota.MORA = cuota.SALDO_CUOTA * MyPrestamo.TASA_MOROSIDAD / 100 / 30 * MyPrestamosCuotaLista[i].DIAS_MORA;
                    }
                    cuota.TOTAL_PAGO = cuota.CUOTA_PAGO + cuota.MORA;
                    cuota.NUMERO_CUOTA = MyPrestamosCuotaLista[i].NUMERO_CUOTA;
                    //Agrego valor 1 al campo SELEECION del DataTable MyPrestamosCuotaLista para ser usado en el método GrabarCobranza()
                    MyPrestamosCuotaLista[i].SELECCIONAR = 1;
                }
            }
            return cuota;
        }

        public dsFinanciero.COBRANZASDataTable ObtenerCobranzaNueva()
        {
            dsFinanciero.COBRANZASDataTable MyDT = new dsFinanciero.COBRANZASDataTable();

            StringBuilder CadenaSQL = new StringBuilder();
            CadenaSQL.Append("SELECT EMPRESA=SPACE(1), COBRANZA=SPACE(1), PRESTAMO=SPACE(1), EJERCICIO=SPACE(1), MES=SPACE(1), TIPO=SPACE(1), IMPORTE=0,FECHA=GETDATE(), ");
            CadenaSQL.Append("GLOSA=SPACE(1), ESTADO=SPACE(1), AGENCIA_REGISTRO=SPACE(1), USUARIO_REGISTRO=SPACE(1), FECHA_REGISTRO=GETDATE(), AGENCIA_MODIFICA=SPACE(1), ");
            CadenaSQL.Append("USUARIO_MODIFICA=SPACE(1), FECHA_MODIFICA=GETDATE() ");

            procesos.ObtenerDataTableSQL(CadenaSQL.ToString(), MyDT);

            return MyDT;
        }

        public string AsignarCobranza()
        {
            StringBuilder CadenaSQL = new StringBuilder("SELECT ISNULL(MAX(COBRANZA),'') AS NUEVO_CODIGO FROM FIN.COBRANZAS WHERE EMPRESA='" + MyUsuario.empresa + "' AND ");
            CadenaSQL.Append("EJERCICIO='" + MyUsuario.ejercicio + "' AND ");
            CadenaSQL.Append("MES='" + MyUsuario.mes.ToString("00") + "' AND ");
            CadenaSQL.Append("AGENCIA_REGISTRO='A0000" + MyUsuario.almacen + "'");

            conexion.cn.Open();
            SqlCommand cmd = new SqlCommand(CadenaSQL.ToString(), conexion.cn);
            string NewCode = cmd.ExecuteScalar().ToString();
            if (String.IsNullOrEmpty(NewCode.Trim()))
            {
                NewCode = "K" + MyUsuario.almacen + MyUsuario.periodo_actual.Substring(2, 4) + "0001";
            }
            else
            {
                long Correlativo = System.Convert.ToInt64(NewCode.Substring(8, 4)) + 1;
                NewCode = "K" + MyUsuario.almacen + MyUsuario.periodo_actual.Substring(2, 4) + Strings.Right("0000" + Correlativo.ToString(), 4);
            }
            return NewCode;
        }

        public string GrabrarCobranza(string txtTotalCuotas, string txtTotalPagar)
        {
            string msg = "SUCCESS";

            decimal TotalCuotasPagar = System.Convert.ToDecimal(txtTotalCuotas);
            decimal TotalPagar = System.Convert.ToDecimal(txtTotalPagar);

            MyCobranza = ObtenerCobranzaNueva();

            MyCobranza[0].EMPRESA = MyUsuario.empresa;
            MyCobranza[0].PRESTAMO = MyPrestamo.PRESTAMO;
            MyCobranza[0].EJERCICIO = MyUsuario.ejercicio;
            MyCobranza[0].MES = MyUsuario.mes.ToString("00");
            MyCobranza[0].TIPO = "CR";
            MyCobranza[0].IMPORTE = TotalPagar;
            MyCobranza[0].GLOSA = Strings.Space(1);
            MyCobranza[0].FECHA = DateTime.Now;
            MyCobranza[0].AGENCIA_REGISTRO = "A0000001";
            MyCobranza[0].USUARIO_REGISTRO = MyUsuario.usuario;

            MyPrestamoDT = ObtenerPrestamo(MyUsuario.empresa, MyPrestamo.PRESTAMO);

            MyPrestamoDT[0].TOTAL_SALDO = MyPrestamoDT[0].TOTAL_SALDO - TotalCuotasPagar;
            if (MyPrestamoDT[0].TOTAL_SALDO <= 0)
            {
                MyPrestamoDT[0].ESTADO = "C";
            }

            //MÉTODO GrabarCobranza
            decimal TotalPagoCuotas = 0;
            MyCobranza[0].COBRANZA = AsignarCobranza();

            StringBuilder sqlCobranzas = new StringBuilder("INSERT INTO FIN.COBRANZAS ");
            sqlCobranzas.Append("(EMPRESA,COBRANZA,PRESTAMO,EJERCICIO, MES,TIPO,IMPORTE,GLOSA,FECHA,AGENCIA_REGISTRO,USUARIO_REGISTRO) ");
            sqlCobranzas.Append("VALUES ");
            sqlCobranzas.Append("(@vEmpresa,@vCobranza,@vPrestamo,@vEjercicio,@vMes,@vTipo,@vImporte,@vGlosa,@vFecha,@vAgencia_registro,@vUsuario_registro)");

            StringBuilder sqlCobranzasDet = new StringBuilder("INSERT INTO FIN.COBRANZAS_DETALLES ");
            sqlCobranzasDet.Append("(Empresa,Cobranza,Prestamo,Concepto,Cuota,Valor_cuota,Saldo_cuota,Dias_mora,Mora,Cuota_pago,Mora_pago,Total_pago,");
            sqlCobranzasDet.Append("Fecha_pago,Compromiso_fecha,Compromiso_comentario,Agencia_registro,Usuario_registro) ");
            sqlCobranzasDet.Append("VALUES ");
            sqlCobranzasDet.Append("(@vEmpresa,@vCobranza,@vPrestamo,@vConcepto,@vCuota,@vValor_cuota,@vSaldo_cuota,@vDias_mora,@vMora,@vCuota_pago,@vMora_pago,@vTotal_pago,");
            sqlCobranzasDet.Append("@vFecha_pago,@vCompromiso_fecha,@vCompromiso_comentario,@vAgencia_registro,@vUsuario_registro) ");

            StringBuilder sqlPrestamoCuotas = new StringBuilder("UPDATE FIN.PRESTAMOS_CUOTAS SET FECHA_PAGO=@vFecha_pago, SALDO_CUOTA=SALDO_CUOTA-@vCuota_pago, MORA=MORA+@vMora_pago, ");
            sqlPrestamoCuotas.Append("ESTADO=CASE WHEN SALDO_CUOTA-@vCuota_pago=0 THEN 'C' ELSE ESTADO END, AGENCIA_MODIFICA=@vAgencia_modifica, ");
            sqlPrestamoCuotas.Append("USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() ");
            sqlPrestamoCuotas.Append("WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo AND CUOTA=@vCuota");

            StringBuilder sqlPrestamos = new StringBuilder("UPDATE FIN.PRESTAMOS SET TOTAL_SALDO=@vTotal_saldo, ESTADO=@vEstado, AGENCIA_MODIFICA=@vAgencia_modifica, ");
            sqlPrestamos.Append("USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() ");
            sqlPrestamos.Append("WHERE EMPRESA=@vEmpresa AND PRESTAMO=@vPrestamo ");

            StringBuilder sqlClientes = new StringBuilder("UPDATE FIN.CLIENTES SET SALDO_PAGAR_MN=SALDO_PAGAR_MN-@vSaldo_pagar_mn, SALDO_PAGAR_ME=SALDO_PAGAR_ME-@vSaldo_pagar_me, ");
            sqlClientes.Append("AGENCIA_MODIFICA=@vAgencia_modifica, USUARIO_MODIFICA=@vUsuario_modifica, FECHA_MODIFICA=GETDATE() ");
            sqlClientes.Append("WHERE EMPRESA=@vEmpresa AND TIPO_DOCUMENTO=@vTipo_documento AND NRO_DOCUMENTO=@vNro_documento ");

            try
            {
                //conexion.cn.Open();
                SqlTransaction tx = conexion.cn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand(sqlCobranzas.ToString(), conexion.cn, tx))
                {
                    cmd.Parameters.AddWithValue("vEmpresa", MyCobranza[0].EMPRESA);
                    cmd.Parameters.AddWithValue("vCobranza", MyCobranza[0].COBRANZA);
                    cmd.Parameters.AddWithValue("vPrestamo", MyCobranza[0].PRESTAMO);
                    cmd.Parameters.AddWithValue("vEjercicio", MyCobranza[0].EJERCICIO);
                    cmd.Parameters.AddWithValue("vMes", MyCobranza[0].MES);
                    cmd.Parameters.AddWithValue("vTipo", MyCobranza[0].TIPO);
                    cmd.Parameters.AddWithValue("vImporte", MyCobranza[0].IMPORTE);
                    cmd.Parameters.AddWithValue("vGlosa", MyCobranza[0].GLOSA);
                    cmd.Parameters.AddWithValue("vFecha", MyCobranza[0].FECHA);
                    cmd.Parameters.AddWithValue("vAgencia_registro", MyCobranza[0].AGENCIA_REGISTRO);
                    cmd.Parameters.AddWithValue("vUsuario_registro", MyCobranza[0].USUARIO_REGISTRO);

                    cmd.ExecuteNonQuery();
                }

                if (MyCobranza[0].TIPO.Equals("CR"))
                {
                    for (int i = 0; i <= MyPrestamosCuotaLista.Rows.Count - 1; i++)
                    {
                        if (MyPrestamosCuotaLista[i].SELECCIONAR == 1)
                        {
                            using (SqlCommand cmd = new SqlCommand(sqlCobranzasDet.ToString(), conexion.cn, tx))
                            {
                                cmd.Parameters.Clear();

                                if (String.IsNullOrEmpty(MyPrestamosCuotaLista[i].COMPROMISO_COMENTARIO))
                                    MyPrestamosCuotaLista[i].COMPROMISO_COMENTARIO = Strings.Space(1);

                                cmd.Parameters.AddWithValue("vEmpresa", MyCobranza[0].EMPRESA);
                                cmd.Parameters.AddWithValue("vCobranza", MyCobranza[0].COBRANZA);
                                cmd.Parameters.AddWithValue("vPrestamo", MyCobranza[0].PRESTAMO);
                                cmd.Parameters.AddWithValue("vConcepto", "PC");
                                cmd.Parameters.AddWithValue("vCuota", MyPrestamosCuotaLista[i].NUMERO_CUOTA);
                                cmd.Parameters.AddWithValue("vValor_cuota", MyPrestamosCuotaLista[i].VALOR_CUOTA);
                                cmd.Parameters.AddWithValue("vSaldo_cuota", MyPrestamosCuotaLista[i].SALDO_CUOTA);
                                cmd.Parameters.AddWithValue("vDias_mora", MyPrestamosCuotaLista[i].DIAS_MORA);
                                cmd.Parameters.AddWithValue("vMora", MyPrestamosCuotaLista[i].MORA);
                                cmd.Parameters.AddWithValue("vCuota_pago", MyPrestamosCuotaLista[i].CUOTA_PAGO);
                                cmd.Parameters.AddWithValue("vMora_pago", MyPrestamosCuotaLista[i].MORA_PAGO);
                                cmd.Parameters.AddWithValue("vTotal_pago", MyPrestamosCuotaLista[i].TOTAL_PAGO);
                                cmd.Parameters.AddWithValue("vFecha_pago", MyPrestamosCuotaLista[i].FECHA_PAGO);
                                cmd.Parameters.AddWithValue("vCompromiso_fecha", MyPrestamosCuotaLista[i].COMPROMISO_FECHA);
                                cmd.Parameters.AddWithValue("vCompromiso_comentario", MyPrestamosCuotaLista[i].COMPROMISO_COMENTARIO);
                                cmd.Parameters.AddWithValue("vAgencia_registro", MyCobranza[0].AGENCIA_REGISTRO);
                                cmd.Parameters.AddWithValue("vUsuario_registro", MyCobranza[0].USUARIO_REGISTRO);

                                cmd.ExecuteNonQuery();
                            }
                            using (SqlCommand cmd = new SqlCommand(sqlPrestamoCuotas.ToString(), conexion.cn, tx))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("vFecha_pago", DateTime.Now);
                                cmd.Parameters.AddWithValue("vCuota_pago", MyPrestamosCuotaLista[i].CUOTA_PAGO);
                                cmd.Parameters.AddWithValue("vMora_pago", MyPrestamosCuotaLista[i].MORA_PAGO);
                                cmd.Parameters.AddWithValue("vAgencia_modifica", "A0000001");
                                cmd.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario);
                                cmd.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa);
                                cmd.Parameters.AddWithValue("vPrestamo", MyPrestamoDT[0].PRESTAMO);
                                cmd.Parameters.AddWithValue("vCuota", MyPrestamosCuotaLista[i].NUMERO_CUOTA);

                                cmd.ExecuteNonQuery();
                            }
                            TotalPagoCuotas = TotalPagoCuotas + MyPrestamosCuotaLista[i].CUOTA_PAGO;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlPrestamos.ToString(), conexion.cn, tx))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("vTotal_saldo", MyPrestamoDT[0].TOTAL_SALDO);
                        cmd.Parameters.AddWithValue("vEstado", MyPrestamoDT[0].ESTADO);
                        cmd.Parameters.AddWithValue("vAgencia_modifica", "A0000001");
                        cmd.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario);
                        cmd.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa);
                        cmd.Parameters.AddWithValue("vPrestamo", MyPrestamoDT[0].PRESTAMO);

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlClientes.ToString(), conexion.cn, tx))
                    {
                        cmd.Parameters.Clear();
                        if (MyPrestamoDT[0].TIPO_MONEDA.Equals("1"))
                        {
                            cmd.Parameters.AddWithValue("vSaldo_pagar_mn", TotalPagoCuotas);
                            cmd.Parameters.AddWithValue("vSaldo_pagar_me", 0);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("vSaldo_pagar_mn", 0);
                            cmd.Parameters.AddWithValue("vSaldo_pagar_me", TotalPagoCuotas);
                        }
                        cmd.Parameters.AddWithValue("vAgencia_modifica", "A0000001");
                        cmd.Parameters.AddWithValue("vUsuario_modifica", MyUsuario.usuario);
                        cmd.Parameters.AddWithValue("vEmpresa", MyUsuario.empresa);
                        cmd.Parameters.AddWithValue("vTipo_documento", MyPrestamoDT[0].TIPO_DOCUMENTO);
                        cmd.Parameters.AddWithValue("vNro_documento", MyPrestamoDT[0].NRO_DOCUMENTO);

                        cmd.ExecuteNonQuery();
                    }

                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand(sqlCobranzasDet.ToString(), conexion.cn, tx))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("vEmpresa", MyCobranza[0].EMPRESA);
                        cmd.Parameters.AddWithValue("vCobranza", MyCobranza[0].COBRANZA);
                        cmd.Parameters.AddWithValue("vPrestamo", MyCobranza[0].PRESTAMO);
                        cmd.Parameters.AddWithValue("vConcepto", MyCobranza[0].TIPO);
                        cmd.Parameters.AddWithValue("vCuota", "000");
                        cmd.Parameters.AddWithValue("vValor_cuota", 0);
                        cmd.Parameters.AddWithValue("vSaldo_cuota", 0);
                        cmd.Parameters.AddWithValue("vDias_mora", 0);
                        cmd.Parameters.AddWithValue("vMora", 0);
                        cmd.Parameters.AddWithValue("vCuota_pago", MyCobranza[0].IMPORTE);
                        cmd.Parameters.AddWithValue("vMora_pago", 0);
                        cmd.Parameters.AddWithValue("vTotal_pago", MyCobranza[0].IMPORTE);
                        cmd.Parameters.AddWithValue("vFecha_pago", MyCobranza[0].FECHA);
                        cmd.Parameters.AddWithValue("vCompromiso_fecha", MyCobranza[0].FECHA);
                        cmd.Parameters.AddWithValue("vCompromiso_comentario", MyCobranza[0].GLOSA);
                        cmd.Parameters.AddWithValue("vAgencia_registro", MyCobranza[0].AGENCIA_REGISTRO);
                        cmd.Parameters.AddWithValue("vUsuario_registro", MyCobranza[0].USUARIO_REGISTRO);

                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                conexion.cn.Close();
            }
            return msg;
        }

        public List<entPrestamoCuotas> ObtenerCuotasCobro()
        {
            return MyListaCuotas;
        }

    }
}