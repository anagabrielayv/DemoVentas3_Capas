using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyVentas_BE
{
    public class CategoriaBE
    {
        private Int16 mvarId_Cat;
        public Int16 Id_Cat
        {
            get { return mvarId_Cat; }
            set { mvarId_Cat = value; }
        }

        private String mvarDes_Cat;
        public String Des_Cat
        {
            get { return mvarDes_Cat; }
            set { mvarDes_Cat = value; }
        }

// Propiedad tipo Array de Bytes para la foto
        private Byte[] mvarFoto_Cat; 
        public Byte[] Foto_Cat
        {
            get { return mvarFoto_Cat; }
            set { mvarFoto_Cat = value; }
        }

    }
}
