using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPE_2;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace PPE_2
{
    public partial class PAGE_D_INSCRIPTION : Form
    {
        List<string> utilisateurs = new List<string>();
        List<Region> regions = new List<Region>();

        MySqlConnection maConnection;
        DataSet monDataSet = new DataSet();
        MySqlDataAdapter monDataAdapterRegion;
        public PAGE_D_INSCRIPTION()
        {
            InitializeComponent();
            textBox8.Text = (Admin.nom + " " + Admin.prenom);

        }

        //public string nomRegion;

        //public string TrouveRegion()
        //{
        //    Utilisateur utilisateur = new Utilisateur();
        //    string connectionString = "SERVER =localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202;";

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();

        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandText = "SELECT NOM FROM region WHERE ID =" + utilisateur.ID_Region;
        //    SqlDataReader dataReader = command.ExecuteReader();
        //     string nomRegion = dataReader.ToString();
        //    return nomRegion;
        //}

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else 
            {


                Utilisateur_DAO user = new Utilisateur_DAO();
                user.SetConnection();
             
                ConnectionMySQL connexion = new ConnectionMySQL();

                //remplissage du comboBox2 des regions
                string req = "Select * from medecin where NOM ='" + utilisateurs[comboBox1.SelectedIndex - 1] + "'";
                connexion.MaRequete = req;
               
                connexion.ExcecuteDB();

                while (connexion.MonReader.Read())
                {
                    textBox1.Text = connexion.MonReader.GetString(1);
                    textBox2.Text = connexion.MonReader.GetString(2);
                    comboBox2.Text = "Assigner une nouvelle région";
                    textBox3.Text = connexion.MonReader.GetString(6);
                    textBox4.Text = connexion.MonReader.GetString(7);
                    textBox6.Text = connexion.MonReader.GetString(3);
                    textBox7.Text = connexion.MonReader.GetDateTime(10).ToString("dd-MM-yyyy");
                    textBox9.Text = connexion.MonReader.GetString(4);

                    id_select = connexion.MonReader.GetInt32(0);
                }
                
                connexion.FermeDB();
            }

        }
        int id_select = 0;
        private void UpdateAll()
        {
            comboBox1.Items.Clear();
            //Utilisateur_DAO utilisateur = new Utilisateur_DAO();
            //utilisateur.SetConnection();
            //utilisateurs = utilisateur.FindAll();
            //List<String> noms = new List<string>();
            //noms.Add("Nouveau");
            //foreach (Utilisateur user in utilisateurs)
            //{
            //    noms.Add(user.Nom);
            //}
            //comboBox1.Items.AddRange(noms.ToArray());

            Utilisateur_DAO utilisateur = new Utilisateur_DAO();
            utilisateur.SetConnection();
            utilisateurs = utilisateur.FindAll();
            ConnectionMySQL connexion = new ConnectionMySQL();

            //remplissage du comboBox2 des regions
            string req = "Select NOM from medecin";
            connexion.MaRequete = req;
            comboBox1.Items.Insert(0, "Nouveau");
            connexion.ExcecuteDB();

            while (connexion.MonReader.Read())
            {
                comboBox1.Items.Add(connexion.MonReader.GetString(0));
            }
            comboBox1.SelectedIndex = 0;

            connexion.FermeDB();


            Region_DAO region = new Region_DAO();
            region.SetConnection();
            regions = region.ListeRegionsDispo();
            List<String> noms_reg = new List<string>();
            foreach (Region regs in regions)
            {
                noms_reg.Add(regs.Nom);
            }
            comboBox2.Items.AddRange(noms_reg.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Voeux voeu = new Voeux();
                Voeux_DAO voeux = new Voeux_DAO();

                Login log = new Login();
                Login_DAO login = new Login_DAO();


                

             
               

                Utilisateur_DAO user = new Utilisateur_DAO();
                
                Utilisateur utilisateur = new Utilisateur();
           
                utilisateur.Nom = textBox1.Text;
                utilisateur.Prenom = textBox2.Text;


             



                utilisateur.ID_Region = 1 + int.Parse(comboBox2.SelectedIndex.ToString());
                utilisateur.PointVisiteur = 0;
                utilisateur.NbVisites = 0;
                utilisateur.Embauche = DateTime.Now;
                utilisateur.ID_Login = 0;
                utilisateur.ID_specialite = 1;
                utilisateur.Adresse = textBox6.Text;
                utilisateur.Telephone = textBox9.Text;

                string nom_cree = textBox2.Text;

               

                Region region = new Region();
                Region_DAO reg = new Region_DAO();

               
                


                user.SetConnection();
                user.Insert(utilisateur);

                MessageBox.Show("Vous venez de créer " + utilisateur.Nom + " " + utilisateur.Prenom);
                MessageBox.Show("Le nom d'utilisateur est : NUtilisateur, Le mot de passe est : New.User");

                user.SetConnection();
                ConnectionMySQL connexion = new ConnectionMySQL();

                connexion.MaRequete = "SELECT ID FROM medecin WHERE NOM = '" + nom_cree + "'";
                connexion.ExcecuteDB();
                int id_cree = 0;
                while (connexion.MonReader.Read())
                {
                     id_cree = connexion.MonReader.GetInt32(0);
                }
                  
                
                connexion.FermeDB();

                voeu.ID_Medecin = id_cree;
                voeu.ID_Region = 1;
                voeu.Ordre_Priorite = 1;
                voeux.SetConnection();
                voeux.Insert(voeu);

                voeu.ID_Medecin = id_cree;
                voeu.ID_Region = 2;
                voeu.Ordre_Priorite = 2;
                voeux.SetConnection();
                voeux.Insert(voeu);

                voeu.ID_Medecin = id_cree;
                voeu.ID_Region = 3;
                voeu.Ordre_Priorite = 3;
                voeux.SetConnection();
                voeux.Insert(voeu);


                log.Identifiant = "NUtilisateur";
                log.Password = "New.User";
                log.ID_Type = 1;
                login.SetConnection();
                login.Insert(log);


                utilisateur.ID_Login = utilisateur.ID;
                user.SetConnection();
                

                connexion.MaRequete = "update region set NB_PLACE_DISPO = NB_PLACE_DISPO - 1 where id = " + (comboBox2.SelectedIndex + 1);

                connexion.ExcecuteDB();

                connexion.FermeDB();

                connexion.MaRequete = "UPDATE login set ID = '"+ id_cree + "' WHERE NOM_UTILISATEUR = 'NUtilisateur'";
                connexion.ExcecuteDB();
                connexion.FermeDB();

                connexion.MaRequete = "UPDATE medecin set ID_LOGIN = '"+ id_cree +"' WHERE ID = '" + id_cree + "'";
                connexion.ExcecuteDB();
                connexion.FermeDB();

                UpdateAll();

            }
            else
            {
                int ID_region = Utilisateur.id_Region;

                Utilisateur.id = id_select;
                Utilisateur.nom = textBox1.Text;
                Utilisateur.prenom = textBox2.Text;
                Utilisateur.id_Region = 1 + int.Parse(comboBox2.SelectedIndex.ToString());
                Utilisateur.adresse = textBox6.Text;
                Utilisateur.telephone = textBox9.Text;
                
                Utilisateur_DAO user = new Utilisateur_DAO();
                user.SetConnection();
                user.Update();

                ConnectionMySQL connexion = new ConnectionMySQL();

                user.SetConnection();
               
                connexion.MaRequete = "update region set NB_PLACE_DISPO = NB_PLACE_DISPO - 1 where id = " + (comboBox2.SelectedIndex + 1) ;

                connexion.ExcecuteDB();

                connexion.FermeDB();

                user.SetConnection();
           
                connexion.MaRequete = "update region set NB_PLACE_DISPO = NB_PLACE_DISPO + 1 where ID = " + ID_region;

                connexion.ExcecuteDB();

                connexion.FermeDB();


                MessageBox.Show("Vous venez de modifier " + Utilisateur.nom + " " + Utilisateur.prenom);
                comboBox2.Items.Clear();
                UpdateAll();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void PAGE_D_INSCRIPTION_Load(object sender, EventArgs e)
        {
         
            UpdateAll();
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ACCUEIL_GESTIONNAIRE().Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Region region = regions[comboBox2.SelectedIndex];

            if (comboBox2.SelectedIndex < 0)
            {
                Utilisateur user = new Utilisateur();
                user.ID_Region = region.ID;
               
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
                
        }
    }
}
