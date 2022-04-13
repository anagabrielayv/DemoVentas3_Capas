using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyVentas_BL;


namespace ProyVentas_GUI
{
    public partial class CategoriaMan01 : Form
    {
        CategoriaBL objCategoriaBL = new CategoriaBL();
        DataView dtv;
        public CategoriaMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        {

            dtv.RowFilter = "Des_Cat like  '%" + strFiltro + "%'";
            dtgCategoria.DataSource = dtv;

            lblRegistros.Text = dtgCategoria.Rows.Count.ToString();
        }
        private void CategoriaMan01_Load(object sender, EventArgs e)
        {

            try
            {
                // configuramos el datagrid para que no se generen columnas automaticamente
                // dtgCategoria.AutoGenerateColumns = false;
                // Creamos la vista en memoria y cargamos los datos
                dtv = new DataView(objCategoriaBL.ListarCategoria());
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
                // Creamos una instancia de CategoriaMan02 y lo mostramos de manera modal
                CategoriaMan02 cate02 = new CategoriaMan02();
                cate02.ShowDialog();

                // Al retornar, refrescamos la vista y cargamos los datos para visualizar
                // al Categoria agregado
                dtv = new DataView(objCategoriaBL.ListarCategoria());
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
                CategoriaMan03 cate03 = new CategoriaMan03();
                // Se toma el valor de la columna cero de la fila seleccionada en el
                // datagridview ....
                cate03.Codigo = Convert.ToInt16 (dtgCategoria.CurrentRow.Cells[0].Value);
                cate03.ShowDialog();

                // Al retornar, refrescamos la vista y cargamos los datos para ver los
                // cambios del Categoria actualizado
                dtv = new DataView(objCategoriaBL.ListarCategoria());
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

        private void dtgCategoria_DoubleClick(object sender, EventArgs e)
        {
            btnActualizar.PerformClick();
        }
    }
}
