using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregamos
using System.Data;
using System.Data.SqlClient;
namespace ProyVentas_ADO
{
    public class FacturaADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada;

        public DataTable ListarFacturasClienteFechas(String strCodcli, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarFacturasClienteFechas";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codcli", strCodcli);
                cmd.Parameters.AddWithValue("@fecini", fecIni);
                cmd.Parameters.AddWithValue("@fecfin", fecFin);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "FacturasCliente");

                return dts.Tables["FacturasCliente"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarFacturasVendedorFechas(String strCodven, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarFacturasVendedorFechas";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codven", strCodven);
                cmd.Parameters.AddWithValue("@fecini", fecIni);
                cmd.Parameters.AddWithValue("@fecfin", fecFin);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "FacturasVendedor");

                return dts.Tables["FacturasVendedor"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable VentasPorAño()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_VentasPorAño";
                SqlDataAdapter ada;
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "VentasPorAño");
                return dts.Tables["VentasPorAño"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable ListarFacturas_Paginacion(String strCodcli, String strCodven,String strEstado, Int16 intNumPag)
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarFacturas_Paginacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Cod_cli", strCodcli);
                cmd.Parameters.AddWithValue("@Cod_ven", strCodven);
                cmd.Parameters.AddWithValue("@Estado", strEstado);
                cmd.Parameters.AddWithValue("@Numpag", intNumPag);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "FacturasPaginacion");

                return dts.Tables["FacturasPaginacion"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Int16 NumPag_ListarFacturas_Paginacion(String strCodcli, String strCodven, String strEstado)
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_NumPag_ListarFacturas_Paginacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Cod_cli", strCodcli);
                cmd.Parameters.AddWithValue("@Cod_ven", strCodven);
                cmd.Parameters.AddWithValue("@Estado", strEstado);
                //agregamos el parametro de salida ...
                cmd.Parameters.Add("@NumReg", SqlDbType.Int);
                cmd.Parameters["@NumReg"].Direction = ParameterDirection.Output;

                //ejecutamos...
                cnx.Open();
                cmd.ExecuteScalar();

                Int16 NumReg = Convert.ToInt16(cmd.Parameters["@NumReg"].Value);
                return NumReg;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
    }
}

   