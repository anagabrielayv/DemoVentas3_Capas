using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using  ProyVentas_BL;

namespace ProyVentas_GUI
{
    public partial class VendedorMan01 : Form
    {
	// Insumos
        VendedorBL objVendedorBL = new VendedorBL();
        DataView dtv;
       
        public VendedorMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        {
            //Por ahora deje esto comentado: dtgVendedor.AutoGenerateColumns = false;
            dtv.RowFilter = "ape_ven like '%" + strFiltro + "%'";
            dtgVendedor.DataSource = dtv;
            lblRegistros.Text = dtgVendedor.Rows.Count.ToString();
        }

        private void VendedorMan01_Load(object sender, EventArgs e)
        {
            try
            {
                // Creamos la vista en memoria y cargamos los datos
                dtv = new DataView(objVendedorBL.ListarVendedor());
                CargarDatos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

      
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //Codifique
                VendedorMan02 oVendedorMan02 = new VendedorMan02();
                oVendedorMan02.ShowDialog();

                //Al cerrar el formulario oProveedorMan02
                dtv = new DataView(objVendedorBL.ListarVendedor());
                CargarDatos(txtFiltro.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }

      

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Tomamos el valor de la columna 0 de la fila selecionada
                //y se lo cargamos a la propiedad codigo del formulario proveedorMan03
                VendedorMan03 oVendedorMan03 = new VendedorMan03();
                oVendedorMan03.Codigo = dtgVendedor.CurrentRow.Cells[0].Value.ToString();
                oVendedorMan03.ShowDialog();
                //Refresco el DataGridView
                dtv = new DataView(objVendedorBL.ListarVendedor());
                CargarDatos(txtFiltro.Text.Trim());

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        { 
            try
            {
               CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : "  + ex.Message );
            }
            
        }
    }
}
