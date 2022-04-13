using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ProyVentas_BE;
namespace ProyVentas_ADO
{
    public class ProveedorADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;


        // Metodos de mantenimiento
        public Boolean InsertarProveedor(ProveedorBE objProveedorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarProveedor";

            //Agregamos parametros 
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@vraz", objProveedorBE.Raz_soc_prv);
            cmd.Parameters.AddWithValue("@vdir", objProveedorBE.Dir_prv);
            cmd.Parameters.AddWithValue("@vtel", objProveedorBE.Tel_prv);
            cmd.Parameters.AddWithValue("@vRUC", objProveedorBE.Ruc_prv);
            cmd.Parameters.AddWithValue("@vrep", objProveedorBE.Rep_ven);
            cmd.Parameters.AddWithValue("@vId_Ubigeo", objProveedorBE.Id_Ubigeo);
            cmd.Parameters.AddWithValue("@vUsu_Registro", objProveedorBE.Usu_Registro);
            cmd.Parameters.AddWithValue("@vEst_prv", objProveedorBE.Est_prv);


            try
            {
                //esto se hace para insertar
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
        public Boolean ActualizarProveedor(ProveedorBE objProveedorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ActualizarProveedor";
            //Agregamos parametros 

            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@vcod", objProveedorBE.Cod_prv);
            cmd.Parameters.AddWithValue("@vraz", objProveedorBE.Raz_soc_prv);
            cmd.Parameters.AddWithValue("@vdir", objProveedorBE.Dir_prv);
            cmd.Parameters.AddWithValue("@vtel", objProveedorBE.Tel_prv);
            cmd.Parameters.AddWithValue("@vRUC", objProveedorBE.Ruc_prv);
            cmd.Parameters.AddWithValue("@vrep", objProveedorBE.Rep_ven);
            cmd.Parameters.AddWithValue("@vIdUbigeo", objProveedorBE.Id_Ubigeo);
            cmd.Parameters.AddWithValue("@vUsu_Ult_Mod", objProveedorBE.Usu_Ult_Mod);
            cmd.Parameters.AddWithValue("@vEst_prv", objProveedorBE.Est_prv);


            try
            {
                //Codifique

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

        public Boolean EliminarProveedor(String strcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EliminarProveedor";
            //Agregamos parametros 
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@vcod", strcod);

            try
            {
                //Codifique
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

        public ProveedorBE ConsultarProveedor(String strCod)
        {
            //instancia de la clase proveedor Be que será devuelto po el metodo
            ProveedorBE objProveedorBE = new ProveedorBE();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ConsultarProveedor";

            //parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@vcod", strCod);

            try
            {
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {

                    dtr.Read();
                    //Asignamos los valores de las columnas del dtr a las propiedades de ObjProveedorBE

                    objProveedorBE.Cod_prv = dtr["Cod_prv"].ToString();
                    objProveedorBE.Raz_soc_prv = dtr["Raz_soc_prv"].ToString();
                    objProveedorBE.Dir_prv = dtr["Dir_prv"].ToString();
                    objProveedorBE.Tel_prv = dtr["Tel_prv"].ToString();
                    objProveedorBE.Ruc_prv = dtr["Ruc_prv"].ToString();
                    objProveedorBE.Rep_ven = dtr["Rep_ven"].ToString();
                    objProveedorBE.Id_Ubigeo = dtr["Id_Ubigeo"].ToString();
                    objProveedorBE.Est_prv = Convert.ToInt16(dtr["Est_prv"]);


                }
                dtr.Close();
                return objProveedorBE;


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

        public DataTable ListarProveedor()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarProveedor";
            cmd.Parameters.Clear();
            try
            {
                //Codifique
                //se contruye el ada
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Proveedores");


            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["Proveedores"];
        }

        public DataTable ListarProveedoresActivos()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarProveedoresActivos";
            cmd.Parameters.Clear();
            try
            {
                //Codifique
                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "ProveedoresActivos");
                return dts.Tables["ProveedoresActivos"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarProveedoresProductos(String cod_prv)
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarProveedoresProductos";
            cmd.Parameters.Clear();
            try
            {
                //Codifique
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod_prv", cod_prv);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "ProveedoresActivos");
                return dts.Tables["ProveedoresActivos"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
