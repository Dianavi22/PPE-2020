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

namespace PPE_2
{
    public partial class GESTION_VOEUX : Form
    {
        List<Region> regions = new List<Region>();

        public GESTION_VOEUX()
        {
            InitializeComponent();
            textBox3.Text = (Utilisateur.nom + " " + Utilisateur.prenom);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ACCUEIL_VISITEUR().Show();
            this.Hide();
        }

        private void GESTION_VOEUX_Load(object sender, EventArgs e)
        {
            UpdateAll();
       
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateAll()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            Region_DAO region = new Region_DAO();
            region.SetConnection();
            regions = region.FindAll();
            List<String> noms = new List<string>();
            foreach (Region reg in regions)
            {
                noms.Add(reg.Nom);
            }
            comboBox1.Items.AddRange(noms.ToArray());
            comboBox2.Items.AddRange(noms.ToArray());
            comboBox3.Items.AddRange(noms.ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Region region = regions[comboBox1.SelectedIndex];

            //if (comboBox1.SelectedIndex < 0)
            //{
            //    Voeux voeux = new Voeux();
            //    Region_DAO reg = new Region_DAO();
            //    reg.Select(comboBox1.SelectedIndex+1);
            //    voeux.ID_Medecin = Program.current_user.ID;
            //    voeux.ID_Region = region.ID;
            //    voeux.Ordre_Priorite = 1;
            //}

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Region region = regions[comboBox2.SelectedIndex];

            //if (comboBox2.SelectedIndex < 0)
            //{
            //    Voeux voeux = new Voeux();
            //    Region_DAO reg = new Region_DAO();
            //    reg.Select(comboBox2.SelectedIndex + 1);
            //    voeux.ID_Medecin = Program.current_user.ID;
            //    voeux.ID_Region2 = region.ID;
            //    voeux.Ordre_Priorite = 2;
            //}
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    Region region = regions[comboBox3.SelectedIndex];

            //    if (comboBox3.SelectedIndex < 0)
            //    {
            //        Voeux voeux = new Voeux();
            //        Region_DAO reg = new Region_DAO();
            //        reg.Select(comboBox3.SelectedIndex + 1);
            //        voeux.ID_Medecin = Program.current_user.ID;
            //        voeux.ID_Region3 = region.ID;
            //        voeux.Ordre_Priorite = 3;
            //    }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {

            
                Region region = regions[comboBox1.SelectedIndex];
                Voeux voeux = new Voeux();
                voeux.ID_Medecin = Utilisateur.id;
               // voeux.ID_Region = region.ID;
                Voeux_DAO voeu = new Voeux_DAO();
                voeu.SetConnection();
                int position = (comboBox1.SelectedIndex + 1);
                voeu.Update1(position);
                voeux.ID_Region = comboBox1.SelectedIndex + 1;

            }

            if (comboBox2.SelectedIndex >= 0)
            {

           
                Region region = regions[comboBox2.SelectedIndex];
                Voeux voeux = new Voeux();
                voeux.ID_Medecin = Utilisateur.id;
              //  voeux.ID_Region = region.ID;
                Voeux_DAO voeu = new Voeux_DAO();
                voeu.SetConnection();
                int position = (comboBox2.SelectedIndex + 1);
                voeu.Update2(position);
                voeux.ID_Region2 = comboBox2.SelectedIndex + 1;


            }

            if (comboBox3.SelectedIndex >= 0)
            {

           
                Region region = regions[comboBox3.SelectedIndex];
                Voeux voeux = new Voeux();
                voeux.ID_Medecin = Utilisateur.id;
              //  voeux.ID_Region = region.ID;
                Voeux_DAO voeu = new Voeux_DAO();
                voeu.SetConnection();
                int position = (comboBox3.SelectedIndex + 1);
                MessageBox.Show(position.ToString());
                voeu.Update3(position);
                voeux.ID_Region3 = comboBox3.SelectedIndex + 1;
            }

            ConnectionMySQL connexion = new ConnectionMySQL();
            Utilisateur user = new Utilisateur();
            Utilisateur_DAO utilisateur = new Utilisateur_DAO();
            utilisateur.SetConnection();
            
            utilisateur.UpdatePtsUser();
         //   connexion.MonReader.Close();

            MessageBox.Show("Vous venez de modifier vos voeux");
            UpdateAll();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
