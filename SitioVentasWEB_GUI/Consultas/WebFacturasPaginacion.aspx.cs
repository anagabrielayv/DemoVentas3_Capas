using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyVentas_BL;
using System.Data;

namespace SitioVentasWEB_GUI.Consultas
{
    public partial class WebFacturasPaginacion : System.Web.UI.Page
    {
        // Creamos las instancias de los servicios involucrados....
        FacturaBL objFactura = new FacturaBL();
        ClienteBL  objCliente = new ClienteBL ();
        VendedorBL objVendedor = new VendedorBL();
        // Variable paginacion....
        String strText;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                                      
                    LlenarCombos();
                    
                    //Llenamos la grilla, llamando al metodo con el flag en falso
                    Filtrar(false);

                }
  
            }
            catch (Exception ex)
            {
                lblMensaje .Text = ex.Message ;
            }

        }

       private void LlenarCombos()
        {
            // Creamos un nuevo item de cliente
            DataTable dtCombos = new DataTable();
            DataRow drFila;

            // Llenamos la tabla de clientes
            dtCombos = objCliente.ListarCliente();
            // Creamos un nuevo item de cliente ....
            drFila = dtCombos.NewRow();
            drFila["Cod_cli"] = "X";
            drFila["Raz_soc_cli"] = "--Todos--";
            // Lo insertamos a la tabla de clientes en la posicion 0
            dtCombos.Rows.InsertAt(drFila, 0);
            // Enlazamos la lista al combo de clientes...
            cboCliente.DataSource = dtCombos;
            cboCliente.DataTextField = "Raz_soc_cli";
            cboCliente.DataValueField = "Cod_cli";
            cboCliente.DataBind();

            // Ahora lo mismo pero con el combo de vendedores....
            dtCombos = objVendedor.ListarVendedor ();
            drFila = dtCombos.NewRow();
            drFila["Cod_ven"] = "X";
            drFila["ApellNombres"] = "--Todos--";
            dtCombos.Rows.InsertAt(drFila, 0);
            cboVendedor.DataSource = dtCombos ;
            cboVendedor.DataTextField = "ApellNombres";
            cboVendedor.DataValueField = "Cod_ven";
            cboVendedor.DataBind();

            
            

        }

        private void Filtrar(Boolean blnFlag)
        {
          
            Int16 pagina = 0;
            String estado;
            String codcli;
            String codven;

            // Tamaño de pagina : 50
            Int16 intsize = 50;
            Int16 intnumpag;

            // Configuramos los parametros ....
            if (cboCliente.SelectedValue == "X") // si eligio Todos
            {
                codcli = "";
                
            }
            else
            {
                codcli = cboCliente.SelectedValue;
            }

            if (cboVendedor.SelectedValue == "X") // si eligio todos
            {
                codven = "";
            }
            else
            {
                codven = cboVendedor.SelectedValue;
            }

            if (cboEstado.SelectedValue == "X") // si eligio todos
            {
                estado = "";
            }
            else
            {
                estado = cboEstado .SelectedValue ;
            }

            // Si el flag este en verdadero es porque selecciono un numero de pagina del combo de paginas...
            if (blnFlag == true)
            {
                //Se obtiene el nro de pagina desde el dropdown menos 1

                strText = cboPaginas.SelectedItem.ToString();
                pagina = Convert.ToInt16(strText);
                pagina = Convert.ToInt16(pagina - 1);


            }
            else // caso contrario sera siempre la primera pagina
            {
                pagina = 0;

            }

            // Si el combo de paginas esta aun vacio , se carga todo sin filtros, obteniendo los primeros 50
            if (cboPaginas.Items.Count == 0)
            {
                grvFacturas.DataSource = objFactura.ListarFacturas_Paginacion ("", "", "", 0);
               
            }
            else // caso contrario ya se genero un filtro, por eso se le pasan las variables del filtro al metodo
            {
                grvFacturas.DataSource = objFactura.ListarFacturas_Paginacion(codcli , codven, estado, pagina);
             
            }
            grvFacturas.DataBind();

            // Obtenemos la cantidad de paginas...

            Int16 intNumReg;
            intNumReg = objFactura.NumPag_ListarFacturas_Paginacion (codcli, codven, estado);
        

            //Se carga el numero de paginas
            String strValue = cboPaginas.Text;
            cboPaginas.Items.Clear();

            if (intNumReg == 0)
            {
                cboPaginas.Items.Add("0");
                cboPaginas.SelectedIndex = 0;

            }
            else
            {
               
                if (intNumReg % intsize == 0)
                {
                    intnumpag = Convert.ToInt16(intNumReg / intsize);

                }
                else
                {
                    intnumpag = Convert.ToInt16 ((intNumReg / intsize ) + 1);
                }
                for (int indice = 1; indice <= intnumpag ;indice=indice+1)
                {
                    cboPaginas.Items.Add(indice.ToString());
                }

            }

            if (blnFlag == true)
            {
                cboPaginas.Text = strValue;
            }
   
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                Filtrar(false);
            }
            catch (Exception ex)
            {

                lblMensaje .Text = ex.Message ;
            }
        }

        protected void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando hay paginas se llama al metodo con el flag en verdadero
            Filtrar(true);
        }
    }
}