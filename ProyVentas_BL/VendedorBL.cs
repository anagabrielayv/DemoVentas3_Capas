using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProyVentas_BE;
using ProyVentas_ADO;
namespace ProyVentas_BL
{
    public class VendedorBL
    {
        VendedorADO objVendedorADO = new VendedorADO();
  
        public Boolean InsertarVendedor(VendedorBE objVendedorBE)
        {
            return objVendedorADO.InsertarVendedor(objVendedorBE);
        }
        public Boolean ActualizarVendedor(VendedorBE objVendedorBE)
        {
            return objVendedorADO.ActualizarVendedor(objVendedorBE);
        }
      public Boolean EliminarVendedor(String strCod)
        {
            return objVendedorADO.EliminarVendedor(strCod);
        }
      public VendedorBE ConsultarVendedor(String strCod)
      {
          return objVendedorADO.ConsultarVendedor(strCod);
        }
         public DataTable ListarVendedor()
        {
            return objVendedorADO.ListarVendedor();
        }
       
       public DataTable ListarVendedoresSuper()
        {
            return objVendedorADO.ListarVendedoresSuper();
        }
        public Int16 ContarSupervisados(String strCod)
        {
            return objVendedorADO.ContarSupervisados(strCod);
        }

       

    }
}
