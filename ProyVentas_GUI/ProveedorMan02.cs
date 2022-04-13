using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Agregar...
using ProyVentas_BL;
using ProyVentas_BE;
namespace ProyVentas_GUI
{
    public partial class ProveedorMan02 : Form
    {
        //Instancias de ProveedorBE y ProveedorBL
        ProveedorBL objProveedorBL = new ProveedorBL();
        ProveedorBE objProveedorBE = new ProveedorBE();
            

        public ProveedorMan02()
        {
            InitializeComponent();
        }

        private void ProveedorMan02_Load(object sender, EventArgs e)
        {
            try
            {
                //Codifique
                // Cargamos los combos de Ubigeo
                // Por defecto elegiremos Lima, Lima , Lima (14,01,01)
                CargarUbigeo("14","01","01");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            
            }
        }

        private void CargarUbigeo(String IdDepa,String IdProv,String IdDist)
        {
            //Cargamos los combos de Ubigeo
            UbigeoBL objubigeoBL = new UbigeoBL();
            cboDepartamento.DataSource = objubigeoBL.Ubigeo_Departamentos();
            cboDepartamento.ValueMember = "IdDepa";
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.SelectedValue = IdDepa;

            cboProvincia.DataSource = objubigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
            cboProvincia.ValueMember = "IdProv";
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.SelectedValue = IdProv;

            cboDistrito.DataSource = objubigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
            cboDistrito.ValueMember = "IdDist";
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.SelectedValue = IdDist;

        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Codifique
                //Validar que la Razón social no esté vacía
                if(txtRS.Text.Trim() == String.Empty)
                {
                    throw new Exception("La rázón social es obligatoria");
                }
                //Llenar todo el RUC
                if(mskRuc.MaskFull == false)
                {
                    throw new Exception("El RUC tiene 11 caracteres");
                }

                //Si todo está correcto, registramos los datos del nuevo proveedor en objProveedorBE
                objProveedorBE.Raz_soc_prv = txtRS.Text.Trim();
                objProveedorBE.Dir_prv = txtDir.Text.Trim();
                objProveedorBE.Ruc_prv = mskRuc.Text;
                objProveedorBE.Tel_prv = txtTel.Text.Trim();
                objProveedorBE.Rep_ven = txtRepVen.Text;

                objProveedorBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() +
                                           cboProvincia.SelectedValue.ToString() +
                                           cboDistrito.SelectedValue.ToString();

                objProveedorBE.Usu_Registro = clsCredenciales.Usuario; //Aquí sabemos qué usuario es el que ha hecho la inserción del registro
                objProveedorBE.Est_prv = Convert.ToInt16(chkEstado.Checked);

                //Llamamos al método
                if(objProveedorBL.InsertarProveedor (objProveedorBE) ==true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("Registro no se insertó. Contacte con IT");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }


        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Refrescamos 
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");

        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Refrescamos 
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString(), "01");


        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
