using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Scrabble2Joueurs.DATA
{
    internal class PartieDAO
    {
        public void Connexion()
        {
             string chaineConnex = "server=localhost; user id=Mdk; password=Soleil@; database=bdd_scrable";

            MySqlConnection connexion = new MySqlConnection(chaineConnex);

            connexion.Open();
        }
    }
}
