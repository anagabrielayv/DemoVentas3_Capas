using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregue
using ProyVentas_BL;
using System.IO;

namespace SitioVentasWEB_GUI.Mantenimientos
{
    public partial class WebListadoRepositorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Codifique
                //Cargamos el Grid
                RepositorioBL objRepositorioBL = new RepositorioBL();
                grvRepositorio.DataSource = objRepositorioBL.ListarRepositorio();
                grvRepositorio.DataBind();

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
        }

        protected void grvRepositorio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Codifique
                Int16 fila = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "Descargar")
                {
                    //Se obtiene el nombre de archivo de la fila seleccionada en el gridview
                    String NomArchivo = grvRepositorio.Rows[fila].Cells[2].Text;
                    //Se procede a descargar el documento
                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", NomArchivo));
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(Server.MapPath(Path.Combine("～/Documentos", NomArchivo)));
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}