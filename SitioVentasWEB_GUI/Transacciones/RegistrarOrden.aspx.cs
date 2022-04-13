using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyVentas_BE;
using ProyVentas_BL;
using System.Threading;
using System.Globalization;
namespace SitioVentasWEB_GUI.Transacciones
{
    public partial class RegistrarOrden : System.Web.UI.Page
    {
        DataTable mitb;
        DataColumn Ccodigo;
        DataColumn Cdescripcion;
        DataColumn Ccantidad;

        private void CrearTabla()
        {
            mitb = new DataTable("TBCompras");
            //Creando las columnas para la tabla temporal de  detalle de compra
            //Columna Codigo
            DataColumn Ccodigo = new DataColumn("Cod_Pro");
            Ccodigo.DataType = Type.GetType("System.String");
            mitb.Columns.Add(Ccodigo);
            //Columna Descripcion
            DataColumn Cdescripcion = new DataColumn("Des_Pro");
            Cdescripcion.DataType = Type.GetType("System.String");
            mitb.Columns.Add(Cdescripcion);
            //Columna Cantidad
            Ccantidad = new DataColumn("Can_Ped");
            Ccantidad.DataType = Type.GetType("System.Int16");
            mitb.Columns.Add(Ccantidad);
            //definimos la PK
            mitb.PrimaryKey = new DataColumn[] { mitb.Columns["Cod_Pro"] };
            grDetalles.DataSource = mitb;
            grDetalles.DataBind();
            Session["Detalles"] = mitb;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Codifique
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    //Pintamos la fecha de hoy por defecto
                    txtFecOco.Text = DateTime.Now.Date.ToShortDateString();
                    txtFecAte.Text = DateTime.Now.Date.ToShortDateString();
                    //enlazamos el combo de proveedores (solo los activos)
                    ProveedorBL objProveedorBL = new ProveedorBL();
                    DataTable dt = objProveedorBL.ListarProveedoresActivos();
                    DataRow dr;
                    dr = dt.NewRow();
                    dr["cod_prv"] = "";
                    dr["raz_soc_prv"] = "(Seleccione)";
                    dt.Rows.InsertAt(dr, 0);
                    cboProveedor.DataSource = dt;
                    cboProveedor.DataValueField = "Cod_prv";
                    cboProveedor.DataTextField = "Raz_soc_prv";
                    cboProveedor.DataBind();
                    //creamos el datatable en memoria para almacenar los detalles
                    CrearTabla();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }

        }

        protected void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Codifique
                if (grDetalles.Rows.Count > 0)
                {
                    throw new Exception("Ya selecciono productos, no puede cambiar de proveedor");
                }
                ProveedorBL objProveedorBL = new ProveedorBL();
                //Mostramos solo los productos del proveedor seleccionado
                DataTable dt = objProveedorBL.ListarProveedoresProductos(cboProducto.SelectedValue.ToString());
                DataRow dr;
                dr = dt.NewRow();
                dr["cod_pro"] = "";
                dr["des_pro"] = "(Seleccione)";
                dt.Rows.InsertAt(dr, 0);
                cboProducto.DataSource = dt;
                cboProducto.DataValueField = "Cod_Pro";
                cboProducto.DataTextField = "Des_pro";
                cboProducto.DataBind();
                cboProducto.SelectedValue = "";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProveedor.SelectedValue == "")
                {
                    throw new Exception("Debe seleccionar un proveedor.");
                }
                // Mostramos el popup  de detalle
                cboProducto.SelectedIndex = 0;
                txtCanPed.Text = String.Empty;
                lblMensajeDetalle.Text = String.Empty;
                PopDetalle.Show();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }

        }

        protected void btnGrabarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                //Codifique
                if (cboProducto.SelectedValue == "")
                {
                    throw new Exception("Debe seleccionar un producto");
                }
                if (txtCanPed.Text == "")
                {
                    throw new Exception("Debe ingresar una cantidad");
                }
                //Casteamos la variable de sesion "Detalles" a DataTable
                mitb = (DataTable)Session["Detalles"];
                //Creamos una fila y la instanciamos como fila de mitb
                DataRow dr;
                dr = mitb.NewRow();
                //Llenanos los campos como lo ingresado en el formulario
                dr["Cod_Pro"] = cboProducto.SelectedValue.ToString();
                dr["Des_Pro"] = cboProducto.SelectedValue.ToString();
                dr["Can_Ped"] = Convert.ToInt16(txtCanPed.Text);
                //Agregamos la fila a la coleccion de filas
                mitb.Rows.Add(dr);
                //Lo mostramos en la grilla
                grDetalles.DataSource = mitb;
                grDetalles.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeDetalle.Text = "Error: " + ex.Message;
                PopDetalle.Show();
            }

        }
        protected void grDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Codifique
                int indicefila = Convert.ToInt16(e.CommandArgument);
                //si se pulso en el boton liminar , eliminamos el detalle de memoria
                if (e.CommandName == "Eliminar")
                {
                    mitb = (DataTable)Session["Detalles"];
                    mitb.Rows.RemoveAt(indicefila);
                    grDetalles.DataSource = mitb;
                    grDetalles.DataBind();
                    Session["Detalles"] = mitb;
                }

            }
            catch (Exception ex)
            {
                lblMensajeDetalle.Text = "Error :" + ex.Message;
                PopDetalle.Show();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            try
            {
                //Codifique
                mitb = (DataTable)Session["Detalles"];
                //Validamos las fechas....
                if (txtFecOco.Text == "")
                {
                    throw new Exception("Debe ingresar fecha de OC.");
                }
                if (txtFecAte.Text == "")
                {
                    throw new Exception("Debe ingresar fecha de Atencion.");
                }
                if (Convert.ToDateTime(txtFecOco.Text) > Convert.ToDateTime(txtFecAte.Text))
                {
                    throw new Exception("La fecha de orden no puede ser mayor que la de atencion.");
                }
                //si no hay detalles, no se puede registrar la orden
                if (mitb.Rows.Count == 0)
                {
                    throw new Exception("No puede registrar una orden sin detalles.");
                }
                //Si todo esta OK se registra la orden
                {
                    OrdenBE objOrdenBE = new OrdenBE();
                    OrdenBL objOrdenBL = new OrdenBL();

                    //Asignamos valores de cabecera (El nro lo genera el SP)
                    objOrdenBE.FecOco = Convert.ToDateTime(txtFecOco.Text);
                    objOrdenBE.FecAte = Convert.ToDateTime(txtFecAte.Text);
                    objOrdenBE.EstOco = "1";//se registra como pendiente
                    objOrdenBE.CodPrv = cboProveedor.SelectedValue;
                    objOrdenBE.Usu_Registro = "jleon";
                    //asignamos los detalles a la propiedad respectiva
                    objOrdenBE.DetallesOC = mitb;
                    //se evalua el exito del metodo
                    String strNumOC = objOrdenBL.RegistrarOrden(objOrdenBE);
                    if (strNumOC == String.Empty)
                    {
                        throw new Exception("Error, no se registro la orden. Revise");
                    }
                    else
                    {
                        lblMensaje.Text = "Se regisro la orden Nro:" + strNumOC + "exitosamente.";
                        mpeMensaje.Show();
                        //Reinicio los controles y la tabla por si se desea registrar una nueva orden de compra
                        txtFecAte.Text = "";
                        txtFecOco.Text = "";
                        cboProveedor.SelectedIndex = 0;
                        CrearTabla();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }


    }
}
