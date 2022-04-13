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
    public partial class ProveedorMan03 : Form
    {
        
        ProveedorBL objProveedorBL = new ProveedorBL();
        ProveedorBE objProveedorBE = new ProveedorBE();
            

        public ProveedorMan03()
        {
            InitializeComponent();
        }

        // IMPORTANTE: Creamos la propiedad Codigo ,que recepcionara el valor del codigo del proveedor
        // a actualizar enviado desde el formulario ProveedorMan01
        
        private String _Codigo;

        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }

        }

         private void ProveedorMan03_Load(object sender, EventArgs e)
        {
            try
            {
                // Codifique...
                objProveedorBE = objProveedorBL.ConsultarProveedor(this.Codigo);

                //Mostramos los datos del proveedor consultado...
                lblCod.Text = objProveedorBE.Cod_prv;
                txtRS.Text = objProveedorBE.Raz_soc_prv;
                txtDir.Text = objProveedorBE.Dir_prv;
                txtTel.Text = objProveedorBE.Tel_prv;
                mskRuc.Text = objProveedorBE.Ruc_prv;
                txtRepVen.Text = objProveedorBE.Rep_ven;
                chkEstado.Checked = Convert.ToBoolean(objProveedorBE.Est_prv);

                //Ubigeo
                //Caracteres 1 y 2 :Departamento
                //Caracteres 3 y 4 :Provincia
                //Caracteres 5 y 6 :Distrito
                String strId_Ubigeo = objProveedorBE.Id_Ubigeo;

                CargarUbigeo(strId_Ubigeo.Substring(0, 2), strId_Ubigeo.Substring(2, 2), strId_Ubigeo.Substring(4, 2));


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void CargarUbigeo(String IdDepa, String IdProv, String IdDist)
        {
            
            UbigeoBL objUbigeoBL = new UbigeoBL();
            cboDepartamento.DataSource = objUbigeoBL.Ubigeo_Departamentos();
            cboDepartamento.ValueMember = "IdDepa";
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.SelectedValue = IdDepa;

            cboProvincia.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
            cboProvincia.ValueMember = "IdProv";
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.SelectedValue = IdProv;

            cboDistrito.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa , IdProv );
            cboDistrito.ValueMember = "IdDist";
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.SelectedValue = IdDist ;


        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Codifique
                try
                {
                    //Codifique
                    //Validar que la Razón social no esté vacía
                    if (txtRS.Text.Trim() == String.Empty)
                    {
                        throw new Exception("La rázón social es obligatoria");
                    }
                    //Llenar todo el RUC
                    if (mskRuc.MaskFull == false)
                    {
                        throw new Exception("El RUC tiene 11 caracteres");
                    }

                    //Si todo está correcto, registramos los datos del nuevo proveedor a actualizar en objProveedorBE
                    objProveedorBE.Cod_prv = lblCod.Text;
                    objProveedorBE.Raz_soc_prv = txtRS.Text.Trim();
                    objProveedorBE.Dir_prv = txtDir.Text.Trim();
                    objProveedorBE.Ruc_prv = mskRuc.Text;
                    objProveedorBE.Tel_prv = txtTel.Text.Trim();
                    objProveedorBE.Rep_ven = txtRepVen.Text;

                    objProveedorBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() +
                                               cboProvincia.SelectedValue.ToString() +
                                               cboDistrito.SelectedValue.ToString();

                    objProveedorBE.Usu_Ult_Mod = clsCredenciales.Usuario; //Aquí sabemos qué usuario es el que ha hecho la inserción del registro
                    objProveedorBE.Est_prv = Convert.ToInt16(chkEstado.Checked);

                    //Llamamos al método
                    if (objProveedorBL.ActualizarProveedor(objProveedorBE) == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Registro no se Actualizó. Contacte con IT");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido el error: " + ex.Message);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }


        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(),
                                cboProvincia.SelectedValue.ToString(), "01");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       

       
    }
}
