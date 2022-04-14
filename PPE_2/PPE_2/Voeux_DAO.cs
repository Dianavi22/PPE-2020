using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPE_2;

namespace PPE_2
{
    class Voeux_DAO
    {

        ConnectionMySQL connexion;

        public void SetConnection()
        {
            connexion = new ConnectionMySQL();
        }

        public void Update1(int ID_Region)
        {
            Region region = new Region();
            connexion.MaRequete = "UPDATE voeux SET ID_REGION = '" + ID_Region + "' WHERE ORDRE_PRIORITE = 1 AND ID_MEDECIN = " + Utilisateur.id ;
            connexion.ExcecuteDB();
        }

        public void Update2(int ID_Region)
        {
            connexion.MaRequete = "UPDATE voeux SET ID_REGION = '" + ID_Region + "'  WHERE ORDRE_PRIORITE = 2 AND ID_MEDECIN = " + Utilisateur.id;
            connexion.ExcecuteDB();
        }

        public void Update3(int ID_Region)
        {
            connexion.MaRequete = "UPDATE voeux SET ID_REGION = '" + ID_Region + "' WHERE ORDRE_PRIORITE = 3 AND ID_MEDECIN = " + Utilisateur.id;
            connexion.ExcecuteDB();
        }

        public void Insert(Voeux voeux)
        {
            connexion.MaRequete = "INSERT INTO voeux (ID_MEDECIN, ID_REGION, ORDRE_PRIORITE) VALUES('" + voeux.ID_Medecin + "', '" + voeux.ID_Region + "', '" + voeux.Ordre_Priorite + "')";
            connexion.ExcecuteDB();
        }

        public Voeux Select(int id)
        {
            connexion.MaRequete = "SELECT * FROM voeux WHERE ID =" + id;
            connexion.ExcecuteDB();
            //   connexion.MonReader.Read();
            Voeux voeux = new Voeux();

            /// A changer si on change la base de données
            while (connexion.MonReader.Read())
            {
                voeux.ID_Medecin = int.Parse(connexion.MonReader.GetString(0));
                voeux.ID_Region = int.Parse(connexion.MonReader.GetString(1));

                voeux.Ordre_Priorite = int.Parse(connexion.MonReader.GetString(2));
               
            }

            return voeux;
        }

    }
}
