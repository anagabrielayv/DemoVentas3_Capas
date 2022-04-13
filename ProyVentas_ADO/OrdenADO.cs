using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ProyVentas_BE;

namespace ProyVentas_ADO
{
   public  class OrdenADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public String RegistrarOrden(OrdenBE objOrdenBE)
        {
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RegistrarOCompra";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vfecoco", objOrdenBE.FecOco);
                cmd.Parameters.AddWithValue("@vcodprv", objOrdenBE.CodPrv);
                cmd.Parameters.AddWithValue("@vfecate", objOrdenBE.FecAte);
                cmd.Parameters.AddWithValue("@vestoco", objOrdenBE.EstOco);
                cmd.Parameters.AddWithValue("@vUsu_registro", objOrdenBE.Usu_Registro);
                //Parametro de Salida
                cmd.Parameters.Add(new SqlParameter("@vnumoco", SqlDbType.Char, 6));
                cmd.Parameters["@vnumoco"].Direction = ParameterDirection.Output;
                //Parametro tipo tabla con los detalles
                cmd.Parameters.Add(new SqlParameter("@detalles", SqlDbType.Structured));
                cmd.Parameters["@detalles"].Value = objOrdenBE.DetallesOC;
                cnx.Open();
                cmd.ExecuteNonQuery();
                //Retorna el NUMOCO generado
                return cmd.Parameters["@vnumoco"].Value.ToString();
            }
            catch (Exception ex)
            {
                return String.Empty;
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
