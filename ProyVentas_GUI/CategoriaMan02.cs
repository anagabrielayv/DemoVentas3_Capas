using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Usings necesarios.....
using ProyVentas_BL;
using ProyVentas_BE;
using System.IO;

namespace ProyVentas_GUI
{
    public partial class CategoriaMan02 : Form
    {
        CategoriaBL objCategoriaBL = new CategoriaBL();
        CategoriaBE objCategoriaBE = new CategoriaBE();
        public CategoriaMan02()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar la Descripcion
                if (txtDes.Text.Trim() == String.Empty) 
                {
                    throw new Exception("La descripcion es obligatoria");
                }
                //Validamos la foto
                if (pcbFoto.Image == null) 
                {
                    throw new Exception("Debe registtrar la foto...");
                }
                //Pasamos los valores a las propiedades de la instancia...
                objCategoriaBE.Des_Cat = txtDes.Text.Trim();
                //Convertimos la foto en un arreglo de Bytes y lo almacenamos en su respectiva propiedad..
                objCategoriaBE.Foto_Cat = File.ReadAllBytes(openFileDialog1.FileName);

                //Insertamos el registro de nueva categoria...
                if (objCategoriaBL.InsertarCategoria(objCategoriaBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el registro. Contacte con IT.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();

                // Si se escogio una foto se carga en el picture Box
                if (openFileDialog1.FileName != String.Empty)
                {
                    pcbFoto.Image = Image.FromFile(openFileDialog1.FileName);
                }

              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }

        private void CategoriaMan02_Load(object sender, EventArgs e)
        {

        }

        private void pcbFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
