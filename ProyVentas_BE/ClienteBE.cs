using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyVentas_BE
{
    public class ClienteBE
    {
        private String mvarcod_cli;
        public String Cod_cli
        {
            get { return mvarcod_cli; }
            set { mvarcod_cli = value; }
        }
        private String mvarraz_soc_cli;
        public String Raz_soc_cli
        {
            get { return mvarraz_soc_cli; }
            set { mvarraz_soc_cli = value; }
        }
        private String mvardir_cli;
        public String Dir_cli
        {
            get { return mvardir_cli; }
            set { mvardir_cli = value; }
        }

        private String mvartel_cli;
        public String Tel_cli
        {
            get { return mvartel_cli; }
            set { mvartel_cli = value; }
        }

        private String mvarruc_cli;
        public String Ruc_cli
        {
            get { return mvarruc_cli; }
            set { mvarruc_cli = value; }
        }

        private String mvarContacto;
        public String Contacto
        {
            get { return mvarContacto; }
            set { mvarContacto = value; }
        }


        private String mvarid_ubigeo;
        public String Id_Ubigeo
        {
            get { return mvarid_ubigeo; }
            set { mvarid_ubigeo = value; }
        }

        private String mvarDepartamento;
        public String Departamento
        {
            get { return mvarDepartamento; }
            set { mvarDepartamento = value; }
        }

        private String mvarProvincia;
        public String Provincia
        {
            get { return mvarProvincia; }
            set { mvarProvincia = value; }
        }

        private String mvarDistrito;
        public String Distrito
        {
            get { return mvarDistrito; }
            set { mvarDistrito = value; }
        }

        private String mvartip_cli;
        public String Tip_cli
        {
            get { return mvartip_cli; }
            set { mvartip_cli = value; }
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

        private Int16 mvarest_cli;
        public Int16 Est_cli
        {
            get { return mvarest_cli; }
            set { mvarest_cli = value; }
        }

        private String mvarestado;
        public String Estado
        {
            get { return mvarestado; }
            set { mvarestado = value; }
        }

        private Single mvardeuda;
        public Single Deuda
        {
            get { return mvardeuda; }
            set { mvardeuda = value; }
        }

    }

}

