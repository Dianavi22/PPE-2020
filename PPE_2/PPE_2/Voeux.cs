using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Voeux
    {
      public static int id_medecin;
       public static int id_region;
        public static int ordre_priorite;
        public static int id_region2;
        public static int id_region3;

        public int ID_Medecin { get { return id_medecin; } set { id_medecin = value; } }
        public int ID_Region { get { return id_region; } set { id_region = value; } }
        public int Ordre_Priorite { get { return ordre_priorite; } set { ordre_priorite = value; } }
        public int ID_Region2 { get { return id_region2; } set { id_region2 = value; } }
        public int ID_Region3 { get { return id_region3; } set { id_region3 = value; } }

    }
}
