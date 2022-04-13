using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
// Agregar...
using ProyVentas_BE;

namespace ProyVentas_ADO
{
    public class VendedorADO
    {
	// Insumos...
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
       

        public Boolean  InsertarVendedor(VendedorBE  objVendedorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarVendedor";

           
            try
            {
                //Agregamos parametros 
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vnom", objVendedorBE.Nom_ven);
                cmd.Parameters.AddWithValue("@vape", objVendedorBE.Ape_ven);
                cmd.Parameters.AddWithValue("@vsue", objVendedorBE.Sue_ven);
                cmd.Parameters.AddWithValue("@vfec", objVendedorBE.Fec_ing);
                cmd.Parameters.AddWithValue("@vtip", objVendedorBE.Tip_ven);
                cmd.Parameters.AddWithValue("@vDNI_ven", objVendedorBE.DNI_ven);
                cmd.Parameters.AddWithValue("@vEmail_ven", objVendedorBE.Email_ven);
                cmd.Parameters.AddWithValue("@vCod_Supervisor", objVendedorBE.Cod_Supervisor);
                cmd.Parameters.AddWithValue("@vUsu_registro", objVendedorBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vEst_ven", objVendedorBE.Est_ven);


                cnx.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
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
        public Boolean ActualizarVendedor(VendedorBE objVendedorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ActualizarVendedor";

            
            try
            {
                //Agregamos parametros 
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", objVendedorBE.Cod_ven);
                cmd.Parameters.AddWithValue("@vnom", objVendedorBE.Nom_ven);
                cmd.Parameters.AddWithValue("@vape", objVendedorBE.Ape_ven);
                cmd.Parameters.AddWithValue("@vsue", objVendedorBE.Sue_ven);
                cmd.Parameters.AddWithValue("@vfec", objVendedorBE.Fec_ing);
                cmd.Parameters.AddWithValue("@vtip", objVendedorBE.Tip_ven);
                cmd.Parameters.AddWithValue("@vDNI", objVendedorBE.DNI_ven);
                cmd.Parameters.AddWithValue("@vEmail", objVendedorBE.Email_ven);
                cmd.Parameters.AddWithValue("@vcodSup", objVendedorBE.Cod_Supervisor);
                cmd.Parameters.AddWithValue("@vUsu_ult_mod", objVendedorBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vest_ven", objVendedorBE.Est_ven);


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

        public Boolean EliminarVendedor(String strCod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EliminarVendedor";

            try
            {
                //Agregamos parametros 
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", strCod);

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

        public VendedorBE ConsultarVendedor(String strCod)
        {
            VendedorBE objVendedorBE = new VendedorBE();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ConsultarVendedor";

            try
            {
                //Agregamos parametros 
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", strCod);

                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {

                    dtr.Read();
                    //Asignamos los valores de las columnas del dtr a las propiedades de ObjProveedorBE

                    objVendedorBE.Cod_ven = dtr["Cod_ven"].ToString();
                    objVendedorBE.Nom_ven = dtr["Nom_ven"].ToString();
                    objVendedorBE.Ape_ven = dtr["Ape_ven"].ToString();
                    objVendedorBE.DNI_ven = dtr["DNI_ven"].ToString();
                    objVendedorBE.Email_ven = dtr["Email_ven"].ToString();
                    objVendedorBE.Usu_Registro = dtr["Usu_Registro"].ToString();
                    objVendedorBE.Cod_Supervisor = dtr["Cod_Supervisor"].ToString();
                    objVendedorBE.Usu_Ult_Mod = dtr["Usu_Ult_Mod"].ToString();
                    objVendedorBE.Est_ven = Convert.ToInt16(dtr["Est_ven"]);
                    objVendedorBE.Fec_ing = Convert.ToDateTime(dtr["Fec_ing"]);
                    objVendedorBE.Tip_ven = Convert.ToInt16(dtr["Tip_ven"]);
                    objVendedorBE.Sue_ven = Convert.ToSingle(dtr["Sue_ven"].ToString());
                }
                dtr.Close();
                return objVendedorBE;


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
        
        public DataTable ListarVendedor()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarVendedor";
            try
            {
                //Limpiamos 
                cmd.Parameters.Clear();
                //se contruye el ada
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Vendedores");
              

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["Vendedores"];
        }

        

        public DataTable ListarVendedoresSuper()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarVendedoresSuper";
            try
            {

                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "VendedoresSuper");

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["VendedoresSuper"];
        }


        public Int16 ContarSupervisados(String strCod)
        {
            VendedorBE objVendedorBE = new VendedorBE();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ContarSupervisados";
            try
            {
                // Agregamos el parametro...
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod_ven", strCod);
                cnx.Open();
                Int16 intCuenta = Convert.ToInt16 (cmd.ExecuteScalar());
                return intCuenta;
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
