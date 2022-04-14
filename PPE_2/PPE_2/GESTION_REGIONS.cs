using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE_2
{
    public partial class GESTION_REGIONS : Form
    {
        public GESTION_REGIONS()
        {
            InitializeComponent();
          //  this.textBox3.Text = Program.current_login.Identifiant;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadgrid()
        {

            MySqlConnection maConnexion;
            String maChaineConnexion;
            maChaineConnexion = "SERVER =localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202; ";
            maConnexion = new MySqlConnection(maChaineConnexion);
            string maRequete;
            maConnexion.Open();
            maRequete = "select * from region";
            MySqlDataReader reader;
            MySqlCommand maCommande = maConnexion.CreateCommand();
            maCommande.CommandText = maRequete;
            reader = maCommande.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            maConnexion.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ACCUEIL_GESTIONNAIRE().Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection maConnexion;
            String maChaineConnexion;
            maChaineConnexion = "SERVER =localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202; ";
            maConnexion = new MySqlConnection(maChaineConnexion);
            maConnexion.Open();

            DataSet dataR = new DataSet();
            MySqlDataAdapter RegionAdapter;
            MySqlCommandBuilder RBuilder;
            DataTable regions;
            RegionAdapter = new MySqlDataAdapter("select * From region", maConnexion);
            RegionAdapter.Fill(dataR, "region");
            regions = dataR.Tables["region"];

            dataGridView1.DataSource = regions;


            // Position

            //int po = dataGridView1.CurrentRow.Index;
            //   regions.Rows[po]["NB_PLACE"] = textBox1.Text; 

            dataGridView1.CurrentCell.Value = int.Parse(textBox1.Text);
            RBuilder = new MySqlCommandBuilder(RegionAdapter);
            RegionAdapter.Update(dataR, "region");
            dataR.Clear();
          
            RegionAdapter.Fill(dataR, "region");

        }


        private void GESTION_REGIONS_Load(object sender, EventArgs e)
        {
            MySqlConnection maConnexion;
            String maChaineConnexion;
            maChaineConnexion = "SERVER =localhost; DATABASE = ppe_2; UID = Jade; PASSWORD = Jado2202; ";
            maConnexion = new MySqlConnection(maChaineConnexion);
            loadgrid();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
        }
    }
}
