using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Agregar
using ProyVentas_BL;
using ProyVentas_BE;
using System.Data.SqlClient;
namespace ProyVentas_GUI
{
    public partial class frmConsFacturasCliente : Form
    {
        FacturaBL objFacturaBL = new FacturaBL();
        ClienteBL objClienteBL = new ClienteBL();
        public frmConsFacturasCliente()
        {
            InitializeComponent();
        }

        private void frmConsFacturasCliente_Load(object sender, EventArgs e)
        {
            try
            {               

                // Desactivamos la generacion de columnas automaticas del datagrid...
                dtgFacturas.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique...
                /*no funciona*/
                dtgFacturas.DataSource = objFacturaBL.ListarFacturasClientesFechas
                    (txtCod.Text.Trim(), dtpFecIni.Value.Date, dtpFecIni.Value.Date);
                lblRegistros.Text = dtgFacturas.Rows.Count.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == 13)
                {
                    ClienteBE objClienteBE = new ClienteBE();
                    objClienteBE = objClienteBL.ConsultarCliente(txtCod.Text.Trim());

                    if(objClienteBE.Cod_cli != null)
                    {
                        lblRazSoc.Text = objClienteBE.Raz_soc_cli;
                        lblRuc.Text = objClienteBE.Ruc_cli;
                        lblDir.Text = objClienteBE.Dir_cli;
                        lblTel.Text = objClienteBE.Tel_cli;
                        lblUbicacion.Text = objClienteBE.Departamento + "-" + objClienteBE.Provincia + "-" + objClienteBE.Distrito;
                        lblEstado.Text = objClienteBE.Estado;

                        Single sngDeuda = objClienteBE.Deuda;
                        lblDeuda.Text = sngDeuda.ToString("#,###,##0.00");
                        btnConsultar.Enabled = true;
                    }
                    else
                    {
                        lblRazSoc.Text = "";
                        lblRuc.Text = "";
                        lblDir.Text = "";
                        lblTel.Text = "";
                        lblUbicacion.Text = "";
                        lblEstado.Text = "";
                        lblDeuda.Text = "";
                        btnConsultar.Enabled = false;
                        MessageBox.Show("Cliente no existe");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

     
    }
}
