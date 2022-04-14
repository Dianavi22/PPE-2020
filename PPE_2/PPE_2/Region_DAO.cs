using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPE_2;

namespace PPE_2
{
    class Region_DAO
    {

        ConnectionMySQL connexion;
        public void SetConnection()
        {
            connexion = new ConnectionMySQL();
        }

        public Region Select(int id)
        {
            connexion.MaRequete = "SELECT * FROM region WHERE ID =" + id + " ORDER BY ID";
            connexion.ExcecuteDB();
            
            Region region = new Region();

            /// A changer si on change la base de données

            while(connexion.MonReader.Read())
            {
                region.ID = int.Parse(connexion.MonReader.GetString(0));
                region.Nom = connexion.MonReader.GetString(1);
                region.Nb_Place = connexion.MonReader.GetInt32(2);
                region.Nb_place_dispo = connexion.MonReader.GetInt32(3);
            }


            return region;

        }

        public List<Region> ListeRegionsDispo()
        {
            connexion.MaRequete = "SELECT * FROM region WHERE NB_PLACE_DISPO > 0 ORDER BY ID";
            connexion.ExcecuteDB();

            List<Region> region = new List<Region>();

            Region regions = new Region();


            while (connexion.MonReader.Read())
            {
                regions = new Region();

                regions.ID = int.Parse(connexion.MonReader.GetString(0));
                regions.Nom = connexion.MonReader.GetString(1);
                regions.Nb_Place = connexion.MonReader.GetInt32(2);
                regions.Nb_place_dispo = connexion.MonReader.GetInt32(3);

                region.Add(regions);
            }
            return region;
        }

        public List<Region> FindAll()
        {
            connexion.MaRequete = "SELECT * FROM region ORDER BY ID";
            connexion.ExcecuteDB();

            List<Region> region = new List<Region>();

            Region regions = new Region();


            while (connexion.MonReader.Read())
            {
                regions = new Region();

                regions.ID = int.Parse(connexion.MonReader.GetString(0));
                regions.Nom = connexion.MonReader.GetString(1);
                regions.Nb_Place = connexion.MonReader.GetInt32(2);
                regions.Nb_place_dispo = connexion.MonReader.GetInt32(3);

                region.Add(regions);
            }
            return region;
        }

        public void Update(Region reg)
        {
            connexion.MaRequete = "UPDATE region SET NOM = '" + reg.Nom + "' , NB_PLACES = '" + reg.Nb_Place + "', NB_PLACES_DISPO = '" + reg.Nb_place_dispo + "'";
            connexion.ExcecuteDB();
        }

        public void UpdateReg(Region reg)
        {
            connexion.MaRequete = "UPDATE region SET NB_PLACES = '" + reg.Nb_Place + "', NB_PLACES_DISPO = '" + reg.Nb_place_dispo + "'";
            connexion.ExcecuteDB();
        }

        
    }
}
