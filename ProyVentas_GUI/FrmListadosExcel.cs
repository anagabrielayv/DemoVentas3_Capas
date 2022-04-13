using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Agregamos Using
using System.IO;
using OfficeOpenXml;
using ProyVentas_BL;


namespace ProyVentas_GUI
{
    public partial class FrmListadosExcel : Form
    {
        //Creamos las instancias de proveedorBL y Factura BL
        ProveedorBL objProveedorBL = new ProveedorBL();
        FacturaBL objfacturaBL = new FacturaBL();
        public FrmListadosExcel()
        {
            InitializeComponent();
        }

        private void btnListarProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                //Definimos la ruta del archivo plantilla del reporte...
                String rutaArchivo = @"C:\MisExcel\ListadoProveedores.xlsx";
                //Obtener el listado de proveedores...
                DataTable dtProveedores = new DataTable();
                dtProveedores = objProveedorBL.ListarProveedor();

                //Definimos la fila de inicio del reporte..
                Int16 fila = 5;

                //Creamos una instancia de clase ExcelPackage en base a la planilla excel...
                using (var pck = new ExcelPackage(new FileInfo(rutaArchivo)))
                {
                    //Instanciamos la hoja1 del archivo plantilla

                    ExcelWorksheet ws = pck.Workbook.Worksheets["Hoja1"];

                    //Escribimos en la hoja instanciada los registros del dataTable

                    foreach(DataRow drProveedor in dtProveedores.Rows)
                    {
                        ws.Cells[fila, 1].Value = drProveedor["cod_prv"].ToString();
                        ws.Cells[fila, 2].Value = drProveedor["Raz_soc_prv"].ToString();
                        ws.Cells[fila, 3].Value = drProveedor["Dir_prv"].ToString();
                        ws.Cells[fila, 4].Value = drProveedor["Tel_prv"].ToString();
                        ws.Cells[fila, 5].Value = drProveedor["Departamento"].ToString() + " _" +
                                                  drProveedor["Provincia"].ToString() +"_" +
                                                 drProveedor["Distrito"].ToString();
                        ws.Cells[fila, 6].Value = drProveedor["Rep_Ven"].ToString();
                        fila += 1;
                    }
                    //Modificamos el ancho de las columnas...
                    ws.Column(1).Width = 30;
                    ws.Column(1).Width = 50;
                    ws.Column(1).Width = 90;
                    ws.Column(1).Width = 40;
                    ws.Column(1).Width = 50;
                    ws.Column(1).Width = 45;

                    //Creamos un nombre de archivo asociado al login del usuario..
                    string fileName = "ListadoProveedores_" + clsCredenciales.Usuario + ".xlsx";

                    //Creamos el archivo con el nombre defindo
                    FileStream fs = new FileStream(@"C:\MisExcel\" + fileName, FileMode.Create);
                    pck.SaveAs(fs);

                    //Destruir las instancias de EPPLUS y del archivo...
                    pck.Dispose();
                    fs.Dispose();

                    //Enviamos mensaje al usuario...
                    MessageBox.Show("El archivo: "+ fileName + "Se ha generado con exito", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" + ex.Message);
            }
        }

        private void FrmListadosExcel_Load(object sender, EventArgs e)
        {
            MostrarControles(false);
        }

        private void MostrarControles(bool valor)
        {
            pcbImagen.Visible = valor;
            lblMensaje.Visible = valor;
            prgBar.Visible = valor;
        }
    }
}
