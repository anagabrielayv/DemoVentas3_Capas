using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProyVentas_BE
{
    public class OrdenBE
    {
        private String mvarnumoco;
        private System.DateTime mvarfechaoc;
        private String mvarcodprv;
        private System.DateTime mvarfecate;
        private String mvarestoco;
        private DataTable Detalles;
                
        public String NumOco
        {
            get { return mvarnumoco; }
            set { mvarnumoco = value; }
        }
        public System.DateTime FecOco
        {
            get { return mvarfechaoc; }
            set { mvarfechaoc = value; }
        }
        public String CodPrv
        {
            get { return mvarcodprv; }
            set { mvarcodprv = value; }
        }
        public System.DateTime FecAte
        {
            get { return mvarfecate; }
            set { mvarfecate = value; }
        }
        public String EstOco
        {
            get { return mvarestoco; }
            set { mvarestoco = value; }
        }
        
        public DataTable DetallesOC
        {
            get { return Detalles; }
            set { Detalles = value; }

        }
        // Propiedades de Auditoria
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
    }
}
