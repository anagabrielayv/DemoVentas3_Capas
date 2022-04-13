using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//agrego...
using ProyVentas_BL;

namespace SitioVentasWEB_GUI.Consultas
{
    public partial class WebFacturacionVendedor : System.Web.UI.Page
    {
        //declaramos instancias
        VendedorBL objVendedorBL = new VendedorBL();
        FacturaBL objFacturaBL = new FacturaBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Enlaza combo de vendedores
                    cboVendedor.DataSource = objVendedorBL.ListarVendedor();
                    cboVendedor.DataValueField = "cod_ven";
                    cboVendedor.DataTextField = "ApellNombres";
                    cboVendedor.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
               grvFacturas.DataSource = objFacturaBL.ListarFacturasVendedorFechas(cboVendedor.SelectedValue.ToString(), Convert.ToDateTime(txtFI.Text.Trim()),
                Convert.ToDateTime(txtFF.Text.Trim()));
                grvFacturas.DataBind();
                lblRegistros.Text = grvFacturas.Rows.Count.ToString(); 

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message; 
            }
        }
    }
}