using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace PPE_2
{
    public class ConnectionMySQL
    {
        private string maChaineConnexion;
        private MySqlConnection maConnexion;
        private string maRequete;
        private MySqlDataReader monReader;

        public string MaChaineConnexion { get { return maChaineConnexion; } set { maChaineConnexion = value; } }
        public MySqlConnection MaConnexion { get { return maConnexion; } set { maConnexion = value; } }
        public string MaRequete { get { return maRequete; } set { maRequete = value; } }
        public MySqlDataReader MonReader { get { return monReader; } set { monReader = value; } }


        public ConnectionMySQL()
        {
            maChaineConnexion = "SERVER = 127.0.0.1; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202; ";
            maConnexion = new MySqlConnection(maChaineConnexion);
            
        }

        public void ExcecuteDB()
        {
            MySqlCommand maCommand = new MySqlCommand();
            maConnexion.Open();
            maCommand.Connection = maConnexion;
            maCommand.CommandType = System.Data.CommandType.Text;
            
           maCommand.CommandText = maRequete;
            monReader = maCommand.ExecuteReader();
           

        }

        public void FermeDB()
        {
            maConnexion.Close();
        }
    }
}
