using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE_2
{
    public partial class ACCUEIL_GESTIONNAIRE : Form
    {
        MySqlConnection maConnection;
        DataSet monDataSet = new DataSet();

        //MySqlDataAdapter monDataAdapterRegion;
        //MySqlDataAdapter monDataAdapterPDispo;


        //DataTable test;
        //DataTable test2;

        private void SetDataGrid(string req, string tab)
        {

            maConnection = new MySqlConnection();
            maConnection.ConnectionString = "SERVER = localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202";
            maConnection.Open();


            DataTable maTable;

            monDataAdapREG = new MySqlDataAdapter(req, maConnection);
            monDataAdapREG.Fill(mesDonneesREG, tab);

            maTable = mesDonneesREG.Tables[tab];
            dataGridView1.DataSource = maTable;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows[0].Selected = true;
            maConnection.Close();
        }
        MySqlDataAdapter monDataAdapREG;
        DataSet mesDonneesREG = new DataSet();
        private void SetDataGrid2(string req, string tab)
        {
            MySqlDataAdapter monDataAdapG;
            DataSet mesDonnees = new DataSet();

            maConnection = new MySqlConnection();
            maConnection.ConnectionString = "SERVER = localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202";
            maConnection.Open();


            DataTable maTable;

            monDataAdapG = new MySqlDataAdapter(req, maConnection);
            monDataAdapG.Fill(mesDonnees, tab);

            maTable = mesDonnees.Tables[tab];
            dataGridView2.DataSource = maTable;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.Rows[0].Selected = true;
            maConnection.Close();
        }

        public ACCUEIL_GESTIONNAIRE()
        {
            InitializeComponent();
            textBox1.Text = (Admin.nom + " " + Admin.prenom);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PAGE_D_INSCRIPTION().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommandBuilder bc = new MySqlCommandBuilder(monDataAdapREG);
                monDataAdapREG.Update(mesDonneesREG, "region");

                mesDonneesREG.Tables["region"].Clear();
                string req = "SELECT NOM, NB_PLACE, NB_PLACE_DISPO, ID FROM region ORDER BY ID";
                string tab = "region";
                SetDataGrid(req, tab);
            }
            catch
            {
                MessageBox.Show("Vous ne pouvez pas modifier deux lignes en même temps");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PAGE_LOGIN().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new GESTION_COMPTE_VISITEUR().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //     textBox1.Text = Program.current_user.Nom + " " + Program.current_user.Prenom;
        }

        private void ACCUEIL_GESTIONNAIRE_Load(object sender, EventArgs e)
        {
            string req = "SELECT NOM, NB_PLACE, NB_PLACE_DISPO, ID FROM region ORDER BY ID";
            string tab = "region";
            SetDataGrid(req, tab);

            req = "SELECT  ORDRE_PRIORITE, (SELECT region.NOM FROM region WHERE region.ID = ID_REGION) as NOM, (SELECT medecin.NOM FROM medecin WHERE medecin.ID = ID_MEDECIN) as NOM_UTILISATEUR FROM voeux";
            tab = "voeux";
            SetDataGrid2(req, tab);

            //monDataAdapterRegion = new MySqlDataAdapter("SELECT NOM , NB_PLACE_DISPO FROM region", maConnection);
            //monDataAdapterRegion.Fill(monDataSet, "Nom");
            //monDataAdapterPDispo = new MySqlDataAdapter("SELECT * FROM region", maConnection);
            //monDataAdapterPDispo.Fill(monDataSet, "NB_PLACE_DISPO");

            //test = monDataSet.Tables["NOM"];
            //test2 = monDataSet.Tables["NB_PLACE_DISPO"];

            //dataGridView1.DataSource = test;
            //dataGridView1.DataSource = test2;

            //this.dataGridView1.Columns["ID"].Visible = false;
            //this.dataGridView1.Columns["NB_PLACE"].Visible = false;

            //dataGridView1.Columns["NOM"].HeaderText = "Nom de la région";
            //dataGridView1.Columns["NB_PLACE_DISPO"].HeaderText = "Nombre de place disponibles";

            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            ////dataGridView1.MultiSelect = false;
            ////dataGridView1.Rows[i].Selected = true;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
