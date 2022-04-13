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
using System.IO; // Para el manejo de las fotos

namespace ProyVentas_GUI
{
    public partial class VendedorMan03 : Form
    {
        VendedorBE objVendedorBE = new VendedorBE();
        VendedorBL objVendedorBL = new VendedorBL();
        // Para controlar el cambio de foto 
        Boolean blnCambioFoto = false;
        
	public VendedorMan03()
        {
            InitializeComponent();
        }
        // Propiedad para identificar el codigo  del vendedor a actualizar
        private String _Codigo;

        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }

        }

        private void VendedorMan03_Load(object sender, EventArgs e)
        {
            try
            {                

                // Codifique:Mostramos los datos del vendedor
                objVendedorBE = objVendedorBL.ConsultarVendedor(this.Codigo);

                // Codifique:Cargamos el combo con los supervisores
                CargarSupervisores(objVendedorBE.Cod_Supervisor);

                lblCodigo.Text = objVendedorBE.Cod_ven;
                txtnom.Text = objVendedorBE.Nom_ven;
                txtape.Text = objVendedorBE.Ape_ven;
                dtpFecIng.Value = Convert.ToDateTime(objVendedorBE.Fec_ing);
                mskSueldo.Text = objVendedorBE.Sue_ven.ToString("##.##00");
                mskDNI.Text = objVendedorBE.DNI_ven;
                txtEmail.Text = objVendedorBE.Email_ven;

                if (objVendedorBE.Est_ven == 1)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }

                if (objVendedorBE.Tip_ven == 1)
                {
                    optSupervisor.Checked = true;
                }
                else
                {
                    optEjecutivo.Checked = true;
                }              

                lblRuta.Text = @"C:\fotosdeVendedores\" + mskDNI.Text+ ".jpg";

                Single cantidadSupervisados = objVendedorBL.ContarSupervisados(objVendedorBE.Cod_ven);
                lblNumSupervisados.Text = Convert.ToString(cantidadSupervisados);
                // Codifique:Quitamos el nombre de archivo por defecto del openfiledialog1                /
                openFileDialog1.FileName = "";


                // Codifique:Si existe un archivo con la foto la mostramos la foto ...
                    pcbFoto.Image = ObtenerImagen(@"C:\fotosdeVendedores\" + mskDNI.Text + ".jpg");
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }

        }
        public void CargarSupervisores(string Cod)
        {
            VendedorBL objVendedorBL = new VendedorBL();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnGrabar_Click(object sender, EventArgs e)
        {
           
            Single cantidadSupervisados = objVendedorBL.ContarSupervisados(objVendedorBE.Cod_ven);
            lblNumSupervisados.Text = Convert.ToString(cantidadSupervisados);
            try
            {
                // Codifique: Validamos la regla de negocio de actualizacion de vendedores supervisores.

                if (Convert.ToInt16(lblNumSupervisados.Text) > 0 && chkActivo.Checked == false)
                {
                    throw new Exception("No se puede inactivar Vendedor que tiene personal a cargo");
                }

                if (Convert.ToInt16(lblNumSupervisados.Text) > 0 && optEjecutivo.Checked == true)
                {
                    throw new Exception("No cambiar el Tipo de Vendedor porque tiene personal a cargo");
                }

                // Codifique: Agregar validaciones para nombres, apellidos, DNI , supervisor , sueldo y foto

                if (txtnom.Text.Length == 0)
                {
                    throw new Exception("El Nombre no puede estar vacio.");
                }

                if (txtape.Text.Length == 0)
                {
                    throw new Exception("El Apellido no puede estar vacio.");
                }

                Single sngSueldo = Convert.ToSingle(mskSueldo.Text);
                if (sngSueldo < 0)
                {
                    throw new Exception("Debe ingresar un sueldo valido.");

                }

                if (mskDNI.MaskFull == false)
                {
                    throw new Exception("El DNI debe tener 8 caracteres.");

                }

                // Codifique: Cargamos los valores ingresados desde el formulario...
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


                objVendedorBE.Sue_ven = sngSueldo;
                objVendedorBE.Usu_Registro = clsCredenciales.Usuario;
                // Codifique:Si se ha cambiado de foto se copia a la carpeta designada ...
                if (blnCambioFoto)
                {
                    string ruta = openFileDialog1.FileName;
                    File.Copy(ruta, @"C:\fotosdeVendedores\" + mskDNI.Text + ".jpg", true);
                }

                // Codifique: Actualizamos el vendedor.....

                if (objVendedorBL.ActualizarVendedor(objVendedorBE) == true)
                {
                    MessageBox.Show("Registro Actualizado");
                    this.Close();
                }
                else
                {
                    throw new Exception("Registro No se inserto. contacte con IT");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
          
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique: establecemos propiedades del openfiledialog
                openFileDialog1.Multiselect = false;
                openFileDialog1.Filter = "Fotos (solo jpg)| *.jpg";
                openFileDialog1.ShowDialog();

                
                // Si se escogio una foto se carga en el picture Box
                if (openFileDialog1.FileName != String.Empty)
                {
                    pcbFoto.Image = Image.FromFile(openFileDialog1.FileName);
                }
                blnCambioFoto = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }
    }
}
