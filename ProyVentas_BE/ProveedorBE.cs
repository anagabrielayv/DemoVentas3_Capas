using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyVentas_BE
{
  public  class ProveedorBE
    {
        private String mvarcod_prv;
        public String Cod_prv
        {
            get { return mvarcod_prv; }
            set { mvarcod_prv = value; }
        }
        private String mvarraz_soc_prv;
        public String Raz_soc_prv
        {
            get { return mvarraz_soc_prv; }
            set { mvarraz_soc_prv = value; }
        }
        private String mvardir_prv;
        public String Dir_prv
        {
            get { return mvardir_prv; }
            set { mvardir_prv = value; }
        }

        private String mvartel_prv;
        public String Tel_prv
        {
            get { return mvartel_prv; }
            set { mvartel_prv = value; }
        }

        private String mvarruc_prv;
        public String Ruc_prv
        {
            get { return mvarruc_prv; }
            set { mvarruc_prv = value; }
        }

        private String mvarrep_ven;
        public String Rep_ven
        {
            get { return mvarrep_ven; }
            set { mvarrep_ven = value; }
        }

        private String mvarid_ubigeo;
        public String Id_Ubigeo
        {
            get { return mvarid_ubigeo; }
            set { mvarid_ubigeo = value; }
        }

        private DateTime mvarfec_registro;
             public DateTime Fec_Registro
        {
            get { return mvarfec_registro; }
            set { mvarfec_registro = value; }
        }

        private String mvarusu_registro;
        public String Usu_Registro
        {
            get { return mvarusu_registro; }
            set { mvarusu_registro = value; }
        }

        private DateTime mvarfec_ult_mod;
        public DateTime Fec_Ult_Mod
        {
            get { return mvarfec_ult_mod; }
            set { mvarfec_ult_mod = value; }
        }

        private String mvarusu_ult_mod;
        public String Usu_Ult_Mod
        {
            get { return mvarusu_ult_mod; }
            set { mvarusu_ult_mod = value; }
        }

        private Int16 mvarest_prv;
        public Int16 Est_prv
        {
            get { return mvarest_prv; }
            set { mvarest_prv = value; }
        }
    }
}
