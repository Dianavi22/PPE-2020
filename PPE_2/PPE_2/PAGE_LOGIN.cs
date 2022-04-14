using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPE_2;

namespace PPE_2
{
    public partial class PAGE_LOGIN : Form
    {
        public PAGE_LOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                MessageBox.Show("Veuillez accepter les conditions d'utilisations");
            }
            else
            {
                try
                {
                string identifiant;
                string password;


                identifiant = textBox1.Text;
                password = textBox2.Text;



                ConnectionMySQL connexion = new ConnectionMySQL();
                connexion.MaRequete = "Select * from login WHERE NOM_UTILISATEUR ='" + identifiant + "' AND MOT_DE_PASSE ='" + password + "'";
                connexion.ExcecuteDB();
                
                int current_id = 0;
                int current_status = 0;
                while (connexion.MonReader.Read())
                {
                    current_id = connexion.MonReader.GetInt32(0);
                    current_status = connexion.MonReader.GetInt32(4);
                }
                Login_DAO login = new Login_DAO();

                    login.SetConnection();
                    login.Select(current_id);
                    connexion.FermeDB();


                    Utilisateur user = new Utilisateur();
                    Utilisateur_DAO utilisateur = new Utilisateur_DAO();

                    utilisateur.SetConnection();
                    utilisateur.Select(current_id);

                    connexion.FermeDB();
                    utilisateur.SetConnection();
                    Utilisateur.nbVisites++;
                    utilisateur.UpdateNbVisite();
                    connexion.FermeDB();
                    connexion.FermeDB();
                    try
                    {
                        connexion.MaRequete = "Select * from medecin WHERE ID_LOGIN ='" + Utilisateur.id_Login + "'";

                    }
                    catch
                    {
                        connexion.MaRequete = "Select * from admin WHERE ID_LOGIN ='" + Utilisateur.id_Login + "'";

                    }

                    if (current_status == 1)
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
                    catch
                { 
                       MessageBox.Show("connexion Impossible");
                }

            }
        }

        private void PAGE_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RGPD().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
