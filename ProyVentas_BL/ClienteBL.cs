using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVentas_ADO;
using ProyVentas_BE;
using System.Data;
namespace ProyVentas_BL
{
    public class ClienteBL
    {
        ClienteADO objClienteADO = new ClienteADO();

        public ClienteBE ConsultarCliente(String strCodCli)
        {
            return objClienteADO.ConsultarCliente(strCodCli);
        }
        public DataTable ListarCliente()
        {
            return objClienteADO.ListarCliente();
        }
    }
}
