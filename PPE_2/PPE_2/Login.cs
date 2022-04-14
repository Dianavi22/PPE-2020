using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_2
{
    class Login
    {
        public static int id;
       
        public static string identifiant;
        public static string passord;
        public static int id_type;

        public int ID { get { return id; } set { id = value; } }
        public string Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string Password { get { return passord; } set { passord = value; } }
        public int ID_Type { get { return id_type; } set { id_type = value; } }

    }
}
