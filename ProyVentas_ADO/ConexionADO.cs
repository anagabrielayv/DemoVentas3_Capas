using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//No olvidar agregar la REFERENCIA
using System.Configuration;

namespace ProyVentas_ADO
{
    class ConexionADO
    {
        public string GetCnx()
        {
            string strCnx = 
                ConfigurationManager.ConnectionStrings["Ventas"].ConnectionString;
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }

    }
}
