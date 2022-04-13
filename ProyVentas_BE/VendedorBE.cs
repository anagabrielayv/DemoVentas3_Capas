using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyVentas_BE
{
    public class VendedorBE
    {
        private String  mvarcod_ven;
        public String Cod_ven
        {
            get { return mvarcod_ven; }
            set { mvarcod_ven = value; }
        }
        private String mvarnom_ven;
        public String Nom_ven
        {
            get { return mvarnom_ven; }
            set { mvarnom_ven = value; }
        }
        private String mvarape_ven;
        public String Ape_ven
        {
            get { return mvarape_ven; }
            set { mvarape_ven = value; }
        }
        
        private Single mvarsue_ven;
        public Single Sue_ven
        {
            get { return mvarsue_ven; }
            set { mvarsue_ven = value; }
        }
                  
        private DateTime mvarfec_ing;
        public DateTime Fec_ing
        {
            get { return mvarfec_ing; }
            set { mvarfec_ing = value; }
        }
         private Int16 mvartip_ven;
        public Int16 Tip_ven
        {
            get { return mvartip_ven; }
            set { mvartip_ven = value; }
        }

        private String mvarDNI_ven;
        public String DNI_ven
        {
            get { return mvarDNI_ven; }
            set { mvarDNI_ven = value; }
        }

        private String mvaremail_ven;
        public String Email_ven
        {
            get { return mvaremail_ven; }
            set { mvaremail_ven = value; }
        }

        private String mvarcod_supervisor;
        public String Cod_Supervisor
        {
            get { return mvarcod_supervisor; }
            set { mvarcod_supervisor = value; }
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

        private Int16 mvarest_ven;
        public Int16 Est_ven
        {
            get { return mvarest_ven; }
            set { mvarest_ven = value; }
        }
    }
    }

