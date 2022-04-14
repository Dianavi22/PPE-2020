using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Region
    {
        int id;
        string nom;
         int nb_place;
         int nb_place_dispo;
        //int id2;
        //int id3;

        public int ID { get { return id; } set { id = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public int Nb_Place { get { return nb_place; } set { nb_place = value; } }
        public int Nb_place_dispo { get { return nb_place_dispo; } set { nb_place_dispo = value; } }
        //public int ID2 { get { return id2; } set { id2 = value; } }
        //public int ID3 { get { return id3; } set { id3 = value; } }
    }
}
