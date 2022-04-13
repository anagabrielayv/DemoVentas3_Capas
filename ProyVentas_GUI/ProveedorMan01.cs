using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Agregar...
using ProyVentas_BL;

namespace ProyVentas_GUI
{
    public partial class ProveedorMan01 : Form
    {
       
        ProveedorBL objProveedorBL = new ProveedorBL();
        DataView dtv;
       
       
        public ProveedorMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        {
            dtv.RowFilter = "raz_soc_prv like '%" + strFiltro + "%'";
            dtgProveedor.DataSource = dtv;

            lblRegistros.Text = dtgProveedor.Rows.Count.ToString();
        }

        private void ProveedorMan01_Load(object sender, EventArgs e)
        {
            try
            {
                //Configuramos el datagridview para que no muestre más columnas que las definidas
                dtgProveedor.AutoGenerateColumns = false;
                //Creamos la vista en función del método ListarProveedor
                dtv = new DataView(objProveedorBL.ListarProveedor());
                CargarDatos("");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
           try
            {
                //Codifique
                ProveedorMan02 oProveedorMan02 = new ProveedorMan02();
                oProveedorMan02.ShowDialog();

                //Al cerrar el formulario oProveedorMan02, refrescamos el datagridview

                dtv = new DataView(objProveedorBL.ListarProveedor());
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
                //Codifique
                //Tomamos el valor de la columna 0 de la fila seleccionada
                //Y se lo cargamos a la propiedad código del formulario ProveedorMan03

                ProveedorMan03 oProveedorMan03 = new ProveedorMan03();
                oProveedorMan03.Codigo = dtgProveedor.CurrentRow.Cells[0].Value.ToString();
                oProveedorMan03.ShowDialog();

                //Refresco el datagridview
                dtv = new DataView(objProveedorBL.ListarProveedor());
                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtFiltro.Text.Trim());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
