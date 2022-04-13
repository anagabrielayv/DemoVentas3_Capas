using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
// Agregar...
using ProyVentas_BE;
namespace ProyVentas_ADO
{
    public class RepositorioADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada;

        public Boolean InsertarRepositorio(String strRuta, String strUsuRegistro)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarRepositorio";

            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Ruta", strRuta);
                cmd.Parameters.AddWithValue("@UsuRegistro", strUsuRegistro);
                cnx.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }

        }

        public DataTable ListarRepositorio()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarRepositorio";

            try
            {
                cmd.Parameters.Clear();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Repositorio");
                return dts.Tables["Repositorio"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}