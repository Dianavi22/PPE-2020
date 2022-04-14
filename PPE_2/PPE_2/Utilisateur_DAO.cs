using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPE_2;

namespace PPE_2
{
    class Utilisateur_DAO
    {
        ConnectionMySQL connexion;

        public void SetConnection()
        {
           connexion = new ConnectionMySQL();
        }
        public void Insert(Utilisateur user)
        {
            connexion.MaRequete = "INSERT INTO medecin (NOM, PRENOM, ADRESSE, TELEPHONE, ID_SPECIALITE, POINTS_UTILISATEUR, NB_VISITE, ID_LOGIN, ID_REGION, DATE_ARRIVEE) VALUES('" + user.Nom + "', '" + user.Prenom + "', '" + user.Adresse + "', '"  + user.Telephone + "' , '" + user.ID_specialite + "', '" + user.PointVisiteur + "' , '" + user.NbVisites + "' , '" + user.ID_Login + "' ,  '" + user.ID_Region + "' , '" + user.Embauche.ToString("yyyy-MM-dd") + "')";
            connexion.ExcecuteDB();
        }

        public void Select(int id)
        {
            connexion.MaRequete = "SELECT * FROM medecin WHERE ID_LOGIN =" + id;
            connexion.ExcecuteDB();
         //   connexion.MonReader.Read();
            Utilisateur utilisateur = new Utilisateur();

            /// A changer si on change la base de données
            while (connexion.MonReader.Read())
            {
                utilisateur.ID = int.Parse(connexion.MonReader.GetString(0));
                utilisateur.Nom = connexion.MonReader.GetString(1);
                utilisateur.Prenom = connexion.MonReader.GetString(2);
                utilisateur.Adresse = connexion.MonReader.GetString(3);
                utilisateur.Telephone = connexion.MonReader.GetString(4);
                utilisateur.ID_specialite = connexion.MonReader.GetInt32(5);
                utilisateur.PointVisiteur = connexion.MonReader.GetInt32(6);
                utilisateur.NbVisites = connexion.MonReader.GetInt32(7);
                utilisateur.ID_Login = connexion.MonReader.GetInt32(8);
                utilisateur.ID_Region = connexion.MonReader.GetInt32(9);
                utilisateur.Embauche = connexion.MonReader.GetDateTime(10);
            }
           
         //   return utilisateur;
        }

        public List<string> FindAll()
        {
            connexion.MaRequete = "SELECT * FROM medecin";
            connexion.ExcecuteDB();

            List<string> utilisateurs = new List<string>();

            Utilisateur utilisateur = new Utilisateur();

            while (connexion.MonReader.Read())
            {
                utilisateur = new Utilisateur();

                utilisateur.ID = int.Parse(connexion.MonReader.GetString(0));
                utilisateur.Nom = connexion.MonReader.GetString(1);
                utilisateur.Prenom = connexion.MonReader.GetString(2);
                utilisateur.Adresse = connexion.MonReader.GetString(3);
                utilisateur.Telephone = connexion.MonReader.GetString(4);
                utilisateur.ID_specialite = connexion.MonReader.GetInt32(5);
                utilisateur.PointVisiteur = connexion.MonReader.GetInt32(6);
                utilisateur.NbVisites = connexion.MonReader.GetInt32(7);
                utilisateur.ID_Login = connexion.MonReader.GetInt32(8);
                utilisateur.ID_Region = connexion.MonReader.GetInt32(9);
                utilisateur.Embauche = connexion.MonReader.GetDateTime(10);

                utilisateurs.Add(connexion.MonReader.GetString(1));

            }

            return utilisateurs;
        }

        public void Update()
        {
            connexion.MaRequete = "UPDATE medecin SET NOM = '" + Utilisateur.nom + "' , PRENOM = '" +Utilisateur.prenom+ "', ADRESSE = '" +Utilisateur.adresse+ "', TELEPHONE ='"+ Utilisateur.telephone +"', ID_SPECIALITE ='" + Utilisateur.id_specialite + "' , ID_REGION = '" + Utilisateur.id_Region + "' WHERE ID = '" + Utilisateur.id + "'";
            connexion.ExcecuteDB();
        }

        public void UpdateNbVisite()
        {
            connexion.MaRequete = "UPDATE medecin SET NB_VISITE = '" + Utilisateur.nbVisites + "' WHERE ID = '" + Utilisateur.id + "'";
            connexion.ExcecuteDB();
        }
          
        public void UpdatePtsUser()

        {
            connexion.MaRequete = "UPDATE medecin SET POINTS_UTILISATEUR = '" + (Utilisateur.pointVisiteur + 10) + "' WHERE ID = '" + Utilisateur.id + "'";
            connexion.ExcecuteDB();
        }

    }

 

}
