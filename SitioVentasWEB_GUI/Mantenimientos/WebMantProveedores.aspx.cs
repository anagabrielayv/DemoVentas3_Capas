using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Agregar ....
using ProyVentas_BE;
using ProyVentas_BL;
using System.Data;
using OfficeOpenXml;
using System.IO;

namespace SitioVentasWEB_GUI.Mantenimientos
{
    public partial class WebMantProveedores : System.Web.UI.Page
    {
        //declaramos las instancias...
        ProveedorBL objProveedorBL = new ProveedorBL();
        ProveedorBE objProveedorBE = new ProveedorBE();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        DataView dtv;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnDescargar);
                if(Page.IsPostBack == false)
                {
                    //creamos la vista en memoria ....
                    dtv = new DataView(objProveedorBL.ListarProveedor());
                    Session["Vista"] = dtv;
                    CargarDatos("");
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error:" + ex.Message;
                mpeMensaje.Show();
            }
        }
        private void CargarDatos(String strFiltro)
        {
            dtv = (DataView)Session["Vista"];
            dtv.RowFilter = "raz_soc_prv like '%" + strFiltro + "%'";
            grvProveedor.DataSource = dtv;
            grvProveedor.DataBind();

            if(grvProveedor.Rows.Count == 0)
            {
                lblMensaje.Text = "No existen registros con el filtro ingresado";
                mpeMensaje.Show();
            }
        }

        protected void btnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error:" + ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void grvProveedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProveedor.PageIndex = e.NewPageIndex;
            dtv = new DataView(objProveedorBL.ListarProveedor());
            Session["Vista"] = dtv;
            CargarDatos(txtFiltro.Text.Trim());
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //preparamos el popad PopMant

                //tenemos que limpiar sus txbox
                txtRS.Text = "";
                txtDir.Text = "";
                txtTel.Text = "";
                txtRUC.Text = "";
                lblMensaje2.Text = "";
                txtRepVen.Text = "";

                //por defecto activamos el check de estado
                chkActivo.Checked = true;

                //cargamos el ubigeo
                CargarUbigeo("14", "01", "01");

                //mostramos el popad
                txtRS.Focus();

                PopMant.Show();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error" + ex.Message;
                mpeMensaje.Show();
            }
        }
        private void CargarUbigeo(String IdDepa, string IdProv, String IdDist)
        {
            // Combos de ubigeo para la insercion del proveedor
            cboDepartamento.DataSource = objUbigeoBL.Ubigeo_Departamentos();
            cboDepartamento.DataValueField = "IdDepa";
            cboDepartamento.DataTextField = "Departamento";
            cboDepartamento.DataBind();
            cboDepartamento.SelectedValue = IdDepa;
            cboProvincia.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
            cboProvincia.DataValueField = "IdProv";
            cboProvincia.DataTextField = "Provincia";
            cboProvincia.DataBind();
            cboProvincia.SelectedValue = IdProv;
            cboDistrito.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
            cboDistrito.DataValueField = "IdDist";
            cboDistrito.DataTextField = "Distrito";
            cboDistrito.DataBind();
            cboDistrito.SelectedValue = IdDist;


        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vamos a cargar los datos del ubigeo de departamaneto

            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");

            //Para mantener un popad abierto en el programa tenemos que hacer
            PopMant.Show();

        }

        protected void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString(), "01");

            //Para mantener un popad abierto en el programa tenemos que hacer
            PopMant.Show();

        }

        protected void grvProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //poner en rojo las personas inactivas

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //obtenemos el valor de la celda 8 de cada celda

                String strEstado = e.Row.Cells[8].Text;//guardamos el valor 8 de cada celda

                if (strEstado == "Inactivo")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }

            try
            {

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error" + ex.Message;
                mpeMensaje.Show();
            }

        }

        protected void grvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //vamos a identificar donde se iso el clip

                Int16 intfila = Convert.ToInt16(e.CommandArgument);//aca tenemos donde se hizo el clip

                //validamos si se ha hecho en la columna validar

                if (e.CommandName == "Editar")
                {
                    //Preparamos el Popad
                    lblMensaje3.Text = "";
                    //obtenemos el codigo del proveedor seleccionado

                    //obtenemos el codigo del proveedor

                    String strCod = grvProveedor.Rows[intfila].Cells[1].Text;

                    //obtenemos la instancia del proveedor a consultar
                    objProveedorBE = objProveedorBL.ConsultarProveedor(strCod);

                    //mostramos los datos del provedor
                    lblCod.Text = objProveedorBE.Cod_prv;
                    txtRS2.Text = objProveedorBE.Raz_soc_prv;
                    txtDir2.Text = objProveedorBE.Dir_prv;
                    txtTel2.Text = objProveedorBE.Tel_prv;
                    txtRUC2.Text = objProveedorBE.Ruc_prv;
                    txtRepVen2.Text = objProveedorBE.Rep_ven;
                    chkActivo2.Checked = Convert.ToBoolean(objProveedorBE.Est_prv);

                    String Id_Ubigeo = objProveedorBE.Id_Ubigeo;

                    //Manejamos el ubigeo para el popadActualizar 

                    CargarUbigeo2(Id_Ubigeo.Substring(0, 2), Id_Ubigeo.Substring(2, 2), Id_Ubigeo.Substring(4, 2));

                    //Mostramos el popad de Actualización
                    PopMant2.Show();

                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error:" + ex.Message;
                mpeMensaje.Show();
            }
        }
        private void CargarUbigeo2(String IdDepa, String IdProv, String IdDist)
        {
            cboDepartamento2.DataSource = objUbigeoBL.Ubigeo_Departamentos();
            cboDepartamento2.DataValueField = "IdDepa";
            cboDepartamento2.DataTextField = "Departamento";
            cboDepartamento2.DataBind();
            cboDepartamento2.SelectedValue = IdDepa;
            cboProvincia2.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
            cboProvincia2.DataValueField = "IdProv";
            cboProvincia2.DataTextField = "Provincia";
            cboProvincia2.DataBind();
            cboProvincia2.SelectedValue = IdProv;
            cboDistrito2.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
            cboDistrito2.DataValueField = "IdDist";
            cboDistrito2.DataTextField = "Distrito";
            cboDistrito2.DataBind();
            cboDistrito2.SelectedValue = IdDist;

        }

        protected void cboDepartamento2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo2(cboDepartamento2.SelectedValue.ToString(), "01", "01");
            PopMant2.Show();

        }

        protected void cboProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo2(cboDepartamento2.SelectedValue.ToString(), cboProvincia2.SelectedValue.ToString(), "01");
            PopMant2.Show();

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                //valimos la razon social ...
                if (txtRS.Text == "")
                {
                    throw new Exception("La Razon social es obligatoria");
                }
                //llenamos el RUC
                if (txtRUC.Text == "")
                {
                    throw new Exception("El RUC es obligatorio");
                }

                //configuramos la instancia de objProveedorBE y se invoca el metodo insertar del objProveedorBL
                objProveedorBE.Raz_soc_prv = txtRS.Text;
                objProveedorBE.Dir_prv = txtDir.Text;
                objProveedorBE.Ruc_prv = txtRUC.Text;
                objProveedorBE.Tel_prv = txtTel.Text;
                objProveedorBE.Rep_ven = txtRepVen.Text;
                objProveedorBE.Id_Ubigeo = cboDepartamento.SelectedValue +
                                             cboProvincia.SelectedValue +
                                             cboDistrito.SelectedValue;
                objProveedorBE.Usu_Registro = "jleon";
                objProveedorBE.Est_prv = Convert.ToInt16(chkActivo.Checked);

                if (objProveedorBL.InsertarProveedor(objProveedorBE) == true)
                {
                    dtv = new DataView(objProveedorBL.ListarProveedor());
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
                }
                else
                {
                    throw new Exception("No se inserto el registro. Contacte con IT.");
                }
            }
            catch (Exception ex)
            {
                lblMensaje2.Text = ex.Message;
                PopMant.Show();     //mantener el popup abierto 
            }
        }


        protected void btnGrabar2_Click(object sender, EventArgs e)
        {
            try
            {
                //valimos la razon social ...
                if (txtRS2.Text == "")
                {
                    throw new Exception("La Razon social es obligatoria");
                }
                //llenamos  el RUC
                if (txtRUC2.Text == "")
                {
                    throw new Exception("El RUC es obligatorio");
                }

                objProveedorBE.Cod_prv = lblCod.Text;
                objProveedorBE.Raz_soc_prv = txtRS2.Text;
                objProveedorBE.Dir_prv = txtDir2.Text;
                objProveedorBE.Ruc_prv = txtRUC2.Text;
                objProveedorBE.Tel_prv = txtTel2.Text;
                objProveedorBE.Rep_ven = txtRepVen2.Text;
                objProveedorBE.Id_Ubigeo = cboDepartamento2.SelectedValue +
                                             cboProvincia2.SelectedValue +
                                             cboDistrito2.SelectedValue;
                objProveedorBE.Usu_Ult_Mod = "jleon";
                objProveedorBE.Est_prv = Convert.ToInt16(chkActivo2.Checked);

                //actualizar registro ...
                if (objProveedorBL.ActualizarProveedor(objProveedorBE) == true)
                {
                    dtv = new DataView(objProveedorBL.ListarProveedor());
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
                }
                else
                {
                    throw new Exception("No se inserto el registro. Contacte con IT.");
                }
            }
            catch (Exception ex)
            {
                lblMensaje3.Text = ex.Message;
                PopMant2.Show(); //mantener el popup abierto 
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                String rutaarchivo = Server.MapPath("/") + @"\Mantenimientos\ListadoProveedores.xlsx";
                DataTable dtProveedores = new DataTable();
                dtProveedores = objProveedorBL.ListarProveedor();
                //fila de inicio de reporte
                Int16 fila1 = 5;
                using (var pck = new OfficeOpenXml.ExcelPackage(new FileInfo(rutaarchivo))) 
                {
                    //nombre de archivo para descargar
                    String filename = "ListadoProveedores" + DateTime.Today.ToShortDateString();
                    ExcelWorksheet ws = pck.Workbook.Worksheets["Hoja1"];

                    //llenamos el excel con los proveedores
                    foreach (DataRow drProveedor in dtProveedores.Rows)
                    {
                        ws.Cells[fila1, 1].Value = drProveedor["Cod_prv"].ToString();
                        ws.Cells[fila1, 2].Value = drProveedor["Raz_Soc_prv"].ToString();
                        ws.Cells[fila1, 3].Value = drProveedor["Dir_prv"].ToString();
                        ws.Cells[fila1, 4].Value = drProveedor["Tel_prv"].ToString();
                        ws.Cells[fila1, 5].Value = drProveedor["Departamento"].ToString() + "." + drProveedor["Provincia"].ToString() + "." + drProveedor["Distrito"].ToString();
                        ws.Cells[fila1, 6].Value = drProveedor["Rep_ven"].ToString();
                        fila1 += 1;
                    }
                    //modificando el ancho de las columnas
                    ws.Column(1).Width = 30;
                    ws.Column(2).Width = 50;
                    ws.Column(3).Width = 50;
                    ws.Column(4).Width = 40;
                    ws.Column(5).Width = 45;
                    ws.Column(6).Width = 45;
                    // escribir denuevo al cliente y descargar el archivo desde el navegador
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xlsx");
                    using (var memoryStream = new MemoryStream())
                    {
                        pck.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                    }
                    Response.End();
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