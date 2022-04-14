using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPE_2;
using MySql.Data.MySqlClient;

namespace PPE_2
{
    public partial class ACCUEIL_VISITEUR : Form
    {
        MySqlConnection maConnection;
        DataSet monDataSet = new DataSet();

        MySqlDataAdapter monDataAdapterRegion;
        MySqlDataAdapter monDataAdapterPDispo;
        MySqlDataAdapter monDataAdapterVoeux;

        MySqlCommandBuilder sqlCommandBuilder;
        DataTable dataTable;

        //int id = Program.current_user.ID; 

        DataRow dataRow;

        int id = 1;
        int id2 = 2;
        int id3 = 3;
        int id4 = 4;

        int i;
        int maPos;

        public ACCUEIL_VISITEUR()
        {
            InitializeComponent();

            textBox1.Text = (Utilisateur.nom + " " + Utilisateur.prenom);
            Voeux voeux = new Voeux();
            string req = "SELECT (SELECT NOM_UTILISATEUR FROM login WHERE ID = '" + Utilisateur.id_Login + "') as NOM, (SELECT NOM FROM region WHERE ID = ID_REGION) as ID_REGION, ORDRE_PRIORITE as VOS_PRIORITES FROM voeux WHERE ID_MEDECIN = '" + Utilisateur.id + "'";
            string tab = "voeux";
            SetDataGrid(req);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            new PAGE_LOGIN().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GESTION_COMPTE_VISITEUR().Show();
            this.Hide();
        }

        private void SetDataGrid(string req)
        {

            maConnection = new MySqlConnection();
            maConnection.ConnectionString = "SERVER = localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202";
            maConnection.Open();

            DataSet mesDonnees = new DataSet();
            DataTable maTable;
            MySqlDataAdapter monDataAdapG;
            monDataAdapG = new MySqlDataAdapter(req, maConnection);
            monDataAdapG.Fill(mesDonnees, "voeux");

            maTable = mesDonnees.Tables["voeux"];
            dataGridView1.DataSource = maTable;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows[0].Selected = true;
            maConnection.Close();
        }

        private void ACCUEIL_VISITEUR_Load(object sender, EventArgs e)
        {

            MessageBox.Show(Utilisateur.id_Login.ToString());
            Voeux voeux = new Voeux();
           string req = "SELECT (SELECT NOM_UTILISATEUR FROM login WHERE ID = '" + Utilisateur.id_Login + "') as NOM, (SELECT NOM FROM region WHERE ID = ID_REGION) as ID_REGION, ORDRE_PRIORITE as VOS_PRIORITES FROM voeux WHERE ID_MEDECIN = '" + Utilisateur.id + "'";
            MessageBox.Show("Utilisateur id : " + Utilisateur.id.ToString());
            string tab = "voeux";
            SetDataGrid(req);



            //maConnection = new MySqlConnection();
            //maConnection.ConnectionString = "SERVER = localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202;";
            //maConnection.Open();



            //monDataAdapterRegion = new MySqlDataAdapter("SELECT `region`.`NOM`, `region`.`NB_PLACE_DISPO`, `voeux`.`ORDRE_PRIORITE` FROM `voeux`, `region` WHERE `ID_MEDECIN`=" + id, maConnection); //Program.current_user.ID
            //monDataAdapterRegion.Fill(monDataSet, "NOM");


            //dataTable = monDataSet.Tables["NOM"];
            //dataGridView1.DataSource = dataTable;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //dataGridView1.Columns["NOM"].HeaderText = "Nom de la région";
            //dataGridView1.Columns["NB_PLACE_DISPO"].HeaderText = "Nombre de place disponibles";
            //dataGridView1.Columns["ORDRE_PRIORITE"].HeaderText = "Mon ordre de préférence";

            //dataGridView1.MultiSelect = false;
            //dataGridView1.Rows[0].Selected = true;

            //maConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GESTION_VOEUX().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new PAGE_LOGIN().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
