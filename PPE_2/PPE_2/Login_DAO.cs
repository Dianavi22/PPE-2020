using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPE_2;

namespace PPE_2
{
    class Login_DAO
    {
      public ConnectionMySQL connexion;
        public void SetConnection()
        {
            connexion = new ConnectionMySQL();
        }

        public void Select(int id)
        {
            connexion.MaRequete = "SELECT * FROM login WHERE ID =" + id;
            connexion.ExcecuteDB();
           
            Login login = new Login();

            /// A changer si on change la base de données
            while (connexion.MonReader.Read())
            {
                login.ID = int.Parse(connexion.MonReader.GetString(0));
                login.Identifiant = connexion.MonReader.GetString(1);
                login.Password = connexion.MonReader.GetString(2);
                login.ID_Type = connexion.MonReader.GetInt32(4);
            }

       //     return login;

        }

        public void Update()
        {
            connexion.MaRequete = "UPDATE login SET NOM_UTILISATEUR = '" + Login.identifiant + "' , MOT_DE_PASSE = '" + Login.passord + "' WHERE ID = '" + Login.id + "'";
            connexion.ExcecuteDB();
        }

        public void Insert(Login login)
        {
            connexion.MaRequete = "INSERT INTO login (NOM_UTILISATEUR, MOT_DE_PASSE, ID_STATUT) VALUES('" + login.Identifiant + "', '" + login.Password + "', '" + login.ID_Type + "')";
            connexion.ExcecuteDB();
            connexion.FermeDB();
            connexion.MaRequete = "SELECT ID FROM login WHERE NOM_UTILISATEUR ='" + login.Identifiant + "'";
            connexion.ExcecuteDB();

            int id_login = 0;
            while (connexion.MonReader.Read())
            {
                 id_login = connexion.MonReader.GetInt32(0);
            }
            connexion.FermeDB();
            connexion.MaRequete = "UPDATE login SET ID_LOGIN = " + id_login +" WHERE NOM_UTILISATEUR ='" + login.Identifiant +"'";
            connexion.ExcecuteDB();
            connexion.FermeDB();
        }
      


    }
}
