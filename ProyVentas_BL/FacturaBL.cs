using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVentas_ADO;
using System.Data;
namespace ProyVentas_BL
{
    public class FacturaBL
    {
        FacturaADO objFacturaADO = new FacturaADO();

        public DataTable ListarFacturasClientesFechas(String strCodCli, DateTime fecIni, DateTime fecFin)
        {
            return objFacturaADO.ListarFacturasClienteFechas(strCodCli, fecIni, fecFin);
        }
        public DataTable ListarFacturasVendedorFechas(String strCodven, DateTime fecIni, DateTime fecFin)
        {
            return objFacturaADO.ListarFacturasVendedorFechas(strCodven, fecIni, fecFin);
        }
        public DataTable VentasPorAño()
        {
            return objFacturaADO.VentasPorAño();
        }
        public DataTable ListarFacturas_Paginacion(String strCodcli, String strCodven, String strEstado, Int16 intNumPag)
        {
            return objFacturaADO.ListarFacturas_Paginacion(strCodcli,  strCodven,  strEstado,  intNumPag);
        }
        public Int16 NumPag_ListarFacturas_Paginacion(String strCodcli, String strCodven, String strEstado)
        {
            return objFacturaADO.NumPag_ListarFacturas_Paginacion( strCodcli,  strCodven,  strEstado);
        }
    }
}
