using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyVentas_BE;
using ProyVentas_BL;
using System.IO;// Para el manejo de la copia de la foto del vendedor...

namespace ProyVentas_GUI
{
    public partial class VendedorMan02 : Form
    {
        VendedorBL  objVendedorBL = new VendedorBL();
        VendedorBE objVendedorBE = new VendedorBE();

        public VendedorMan02()
        {
            InitializeComponent();
        }

        private void VendedorMan02_Load(object sender, EventArgs e)
        {
            try
            {
                // Codifique:Cargamos el combo con los supervisores
                CargarSupervisores("v03");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }
        public void CargarSupervisores(string Cod)
        {
            VendedorBL objSupervisores = new VendedorBL();

            cboSupervisor.DataSource = objVendedorBL.ListarVendedoresSuper();
            cboSupervisor.ValueMember = "cod_ven";
            cboSupervisor.DisplayMember = "ApellNombres";
            cboSupervisor.SelectedValue = Cod;

        }
        private Image ObtenerImagen(String strRuta)
        {

            byte[] imagebuffer = File.ReadAllBytes(strRuta);
            using (MemoryStream ms = new MemoryStream(imagebuffer))
            {
                Image img = Image.FromStream(ms);
                ms.Close();
                return img;

            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Multiselect = false;
                openFileDialog1.Filter = "Fotos (solo jpg) | *.jpg";
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
        private void btnGrabar_Click(object sender, EventArgs e)
        {
           try
            {

                // Codifique: Validamos que el nombre, apellido , foto DNI  y sueldo no esten vacios
                if (txtnom.Text.Length == 0)
                {
                    throw new Exception ("El Nombre no puede estar vacio.");
                }

                if (txtape.Text.Length == 0)
                {
                    throw new Exception ("El Apellido no puede estar vacio.");
                }

                if (mskSueldo.Text == "")
                {
                    throw new Exception ("Debe ingresar un sueldo valido.");

                }

                if (mskDNI.MaskFull  == false)
                {
                    throw new Exception("El DNI debe tener 8 caracteres.");

                }

               if (pcbFoto.Image == null)
               {
                   throw new Exception("Debe ingresar una foto.");

               }

                // Codifique: Si todo esta bien asignamos los datos del nuevo vendedor...

                objVendedorBE.Nom_ven = txtnom.Text.Trim();
                objVendedorBE.Ape_ven = txtape.Text.Trim();
                objVendedorBE.DNI_ven = mskDNI.Text.Trim();
                objVendedorBE.Fec_ing = dtpFecIng.Value.Date;
                objVendedorBE.Email_ven = txtEmail.Text.Trim();
                objVendedorBE.Cod_Supervisor = cboSupervisor.SelectedValue.ToString();                
                
                int valorSupervisor = optSupervisor.Checked ? 1 : 2; //operador ternario               
                objVendedorBE.Tip_ven = Convert.ToInt16(valorSupervisor);
                
                int valorEstado = chkActivo.Checked ? 1 : 0; //operador ternario               
                objVendedorBE.Est_ven = Convert.ToInt16(valorEstado);//por defecto todos son activos pero se le puede dar la opcion de ingresar como inactivo


                Single sngSueldo = Convert.ToSingle(mskSueldo.Text);
                objVendedorBE.Sue_ven = sngSueldo;
                objVendedorBE.Usu_Registro = clsCredenciales.Usuario;

                // Codifique:Se copia la foto en la carpeta designada                 
                string ruta = openFileDialog1.FileName;
                File.Copy(ruta, @"C:\fotosdeVendedores\" + mskDNI.Text + ".jpg", true);//es necesario crear la carpeta

                if (objVendedorBL.InsertarVendedor(objVendedorBE) == true)
                {
                    MessageBox.Show("Registro Guardado");
                    this.Close();
                }
                else
                {
                    throw new Exception("Registro No se inserto. contacte con IT");
                }
            }

            catch ( Exception ex)
            {
           MessageBox .Show ("Se ha producido el error: " + ex.Message );
           }

         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
