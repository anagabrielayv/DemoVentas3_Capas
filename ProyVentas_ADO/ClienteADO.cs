using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyVentas_BE;
namespace ProyVentas_ADO
{
    public class ClienteADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;

        public ClienteBE ConsultarCliente(String strCodcli)
        {
            //Instancia de la clase ClienteBE que será devuelta por el método
            ClienteBE objClienteBE = new ClienteBE();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ConsultarCliente";
            //Parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@vcod", strCodcli);
            try
            {
                //Codifique
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    // Asignamos los valores de las columnas del dtr a las propiedades de
                    //objClienteBE
                    objClienteBE.Cod_cli = dtr["Cod_cli"].ToString();
                    objClienteBE.Raz_soc_cli = dtr["raz_soc_cli"].ToString();
                    objClienteBE.Dir_cli = dtr["Dir_cli"].ToString();
                    objClienteBE.Tel_cli = dtr["Tel_cli"].ToString();
                    objClienteBE.Ruc_cli = dtr["Ruc_cli"].ToString();
                    objClienteBE.Departamento = dtr["Departamento"].ToString();
                    objClienteBE.Provincia = dtr["Provincia"].ToString();
                    objClienteBE.Distrito = dtr["Distrito"].ToString();
                    objClienteBE.Estado = dtr["Estado"].ToString();
                    objClienteBE.Deuda = Convert.ToSingle(dtr["Deuda"]);

                }
                dtr.Close();
                return objClienteBE;

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

        public DataTable ListarCliente()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarCliente";
            cmd.Parameters.Clear();
            try
            {
                //Codifique
                //se contruye el ada
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Cliente");
                return dts.Tables["Cliente"];


            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
