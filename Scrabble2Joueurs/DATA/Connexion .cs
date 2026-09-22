using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using Mysqlx.Sql;

namespace Scrabble2Joueurs.DATA
{
    internal static class Connexion
    {
        public static MySqlConnection Connect()
        {
            MySqlConnection connex = null;
            string chaineConnex = "serveur=localhost:3306; user id=root; password= ; database=bdd_scrable;");
            MySqlConnection connexion = new MySqlConnection(chaineConnex);

            connexion.Open();

            connexion.Close();
        }
        
    }
}
