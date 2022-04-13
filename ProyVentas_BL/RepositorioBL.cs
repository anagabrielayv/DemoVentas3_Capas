using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVentas_ADO;
using System.Data;

namespace ProyVentas_BL
{
    public class RepositorioBL
    {
        RepositorioADO objRepositorioADO = new RepositorioADO();

        public Boolean InsertarRepositorio(String strRuta, String strUsuRegistro)
        {
            return objRepositorioADO.InsertarRepositorio(strRuta, strUsuRegistro);
        }
        public DataTable ListarRepositorio()
        {
            return objRepositorioADO.ListarRepositorio();
        }
    }
}