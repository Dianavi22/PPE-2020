using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Admin_DAO
    {
        ConnectionMySQL connexion;

        public void SetConnection()
        {
            connexion = new ConnectionMySQL();
        }

        public Utilisateur Select(int id)
        {
            connexion.MaRequete = "SELECT * FROM admin WHERE ID =" + id;
            connexion.ExcecuteDB();
            connexion.MonReader.Read();
            Utilisateur utilisateur = new Utilisateur();

            /// A changer si on change la base de données

            utilisateur.ID = int.Parse(connexion.MonReader.GetString(0));
            utilisateur.Nom = connexion.MonReader.GetString(1);
            utilisateur.Prenom = connexion.MonReader.GetString(2);
            utilisateur.ID_Login = connexion.MonReader.GetInt32(3);
            

            return utilisateur;

        }



    }
}
