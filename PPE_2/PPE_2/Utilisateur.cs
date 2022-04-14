using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Utilisateur
    {
        public static int id;
        public static string nom;
        public static string prenom;
        public static string adresse;
        public static string telephone;
        public static int id_Region;
        public static int id_specialite;
        public static int pointVisiteur;
        public static int nbVisites;
        public static DateTime embauche;
        public static int id_Login;
        public static int id_Type;

        public int ID { get { return id; } set { id = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public string Telephone { get { return telephone; } set { telephone = value; } }
        public int ID_specialite { get { return id_specialite; } set { id_specialite = value; } }
        public int PointVisiteur { get { return pointVisiteur; } set { pointVisiteur = value; } }
        public int NbVisites { get { return nbVisites; } set { nbVisites = value; } }
       public int ID_Login { get { return id_Login; } set { id_Login = value; } }
        public int ID_Type { get { return id_Type; } set { id_Type = value; } }
        public int ID_Region { get { return id_Region; } set { id_Region = value; } }
        public DateTime Embauche { get { return embauche; } set { embauche = value; } }

    }


}
