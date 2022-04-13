using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyVentas_GUI
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void provedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorMan01 oProveedorMan01=new ProveedorMan01();
            oProveedorMan01.MdiParent = this;   
            oProveedorMan01.Show();
        }

        private void facturaciónClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsFacturasCliente ofrmConsFacturasCliente = new frmConsFacturasCliente();  
            ofrmConsFacturasCliente.MdiParent = this;
            ofrmConsFacturasCliente.Show();

        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult vrpta;
            vrpta = MessageBox.Show("Seguro de tu de lo que quieres?","confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (vrpta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Vuelva pronto","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            Application.Exit();

        }
        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            //mostramos el nombre de el usuario en la parte inferior
            lblUsuario.Text = "usuario actual" + clsCredenciales.Usuario;

            //dependiendo de el nivel se le da accesos

            if (clsCredenciales.Nivel == 1)//Administrador
            {
                mantenimientosToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;
                listadosToolStripMenuItem.Visible = true;
                salirToolStripMenuItem.Visible = true;

            }
            else if (clsCredenciales.Nivel == 2)//Supervisor
            {
                consultasToolStripMenuItem.Visible = false;
                mantenimientosToolStripMenuItem.Visible = true;
                listadosToolStripMenuItem.Visible = true;
                salirToolStripMenuItem.Visible = true;
            }

        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportesExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadosExcel ofrmListadosExcel = new FrmListadosExcel();
            ofrmListadosExcel.MdiParent = this;
            ofrmListadosExcel.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaMan01 oCategoriaMan01 = new CategoriaMan01();
            oCategoriaMan01.MdiParent = this;
            oCategoriaMan01.Show();
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendedorMan01 oVendedorMan01 = new VendedorMan01();
            oVendedorMan01.MdiParent = this;
            oVendedorMan01.Show();
        }
    }
}
