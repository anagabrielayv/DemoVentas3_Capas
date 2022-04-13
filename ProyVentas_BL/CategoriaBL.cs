using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Using necesarios...
using System.Data;
using ProyVentas_ADO;
using ProyVentas_BE;

namespace ProyVentas_BL
{
    public class CategoriaBL
    {
        CategoriaADO objCategoriaADO = new CategoriaADO();
        public Boolean InsertarCategoria(CategoriaBE objCategoriaBE)
        {
            return objCategoriaADO.InsertarCategoria(objCategoriaBE);
        }
        public Boolean ActualizarCategoria(CategoriaBE objCategoriaBE)
        {
            return objCategoriaADO.ActualizarCategoria(objCategoriaBE);
        }
        public Boolean EliminarCategoria(Int16 strCod)
        {
            return objCategoriaADO.EliminarCategoria(strCod);
        }
        public CategoriaBE ConsultarCategoria(Int16 strCod)
        {
            return objCategoriaADO.ConsultarCategoria(strCod);
        }
        public DataTable ListarCategoria()
        {
            return objCategoriaADO.ListarCategoria();
        }

    }
}
