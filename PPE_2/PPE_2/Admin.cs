using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Admin
    {
        public static int id;
        public static string nom;
        public static string prenom;
        public static int id_login;

        public int ID { get { return id; } set { id = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public int ID_Login { get { return id_login; } set { id_login = value; } }


    }
}
