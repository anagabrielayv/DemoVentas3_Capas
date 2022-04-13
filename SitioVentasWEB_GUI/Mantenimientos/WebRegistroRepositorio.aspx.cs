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
	public partial class WebRegistroRepositorio : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnEnviar_Click(object sender, EventArgs e)
		{
			try
			{
				//Codifique
				String savePath = Server.MapPath("/") + @"Documentos\";
				if (fulDocumento.HasFile)
				{
					//Evaluamos el peso del archivo
					if (fulDocumento.PostedFile.ContentLength <= 4200000)       //aprox 4 MG
					{
						String fileExtension;
						fileExtension = Path.GetExtension(fulDocumento.FileName).ToLower();
						if (fileExtension == ".pdf") //Si es PDF

						{
							// Enviamos el archivo al servidor
							fulDocumento.SaveAs(savePath + fulDocumento.FileName);
							//Insertamos el registro en el repositorio (con el nombre y el usuario de registro "jleon")
							RepositorioBL objRepositorioBL = new RepositorioBL();
							if (objRepositorioBL.InsertarRepositorio(fulDocumento.FileName, "jleon") == true)
							{
								Response.Redirect("WebListadoRepositorio.aspx");
							}
						}
						else
						{
							lblMensaje.Text = "No se aceptan archivos de este tipo.";
						}
					}
					else
					{
						lblMensaje.Text = "No se pudo cargar el archivo porque se 		sobrepasa del maximo permitido.";
					}
				}
			}
			catch (Exception ex)
			{
				lblMensaje.Text = "No se pudo cargar el archivo. Contacte con IT." + ex.Message;
			}
		}
	}
}