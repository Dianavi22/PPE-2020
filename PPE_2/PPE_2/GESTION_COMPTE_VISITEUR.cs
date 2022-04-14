using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_2
{
    public partial class GESTION_COMPTE_VISITEUR : Form
    {
        public GESTION_COMPTE_VISITEUR()
        {
            InitializeComponent();
         
        }

        private void GESTION_COMPTE_VISITEUR_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.identifiant;
            textBox2.Text = Login.passord;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Login.identifiant = textBox1.Text;
            Login.passord = textBox2.Text;
          
            Login_DAO login = new Login_DAO();
            login.SetConnection();
            login.Update();

            MessageBox.Show("Vos modifications ont bien été enregistrées");
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Login.id_type == 1)
            {
                
                new ACCUEIL_VISITEUR().Show();
                this.Hide();
            }
            else
            {
                new ACCUEIL_GESTIONNAIRE().Show();
                this.Hide();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
