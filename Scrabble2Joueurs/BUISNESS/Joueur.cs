using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrabble2Joueurs
{
    /// <summary>
    /// Classe Joueur
    /// </summary>
    public class Joueur
    {
        #region attributs privés
        private string nom;
        private List<string> lesMots;
        private int totalPoints;
        #endregion

        #region constructeur
        /// <summary>
        /// Constructeur de la classe Joueur
        /// Initialise l'attribut lesMots à une liste vide et l'attribut totalPoints à zéro
        /// </summary>
        /// <param name="unNom">nom du joueur</param>
        public Joueur(string unNom)
        {
            this.nom = unNom;
            this.lesMots = new List<string>();
            this.totalPoints = 0;
        }
        #endregion

        #region méthodes
        /// <summary>
        /// Méthode qui permet d'ajouter un mot à la liste des mots du joueur
        /// et qui actualise le nombre total de points du joueur
        /// </summary>
        /// <param name="unMot">mot proposé par le joueur</param>
        public void AjouterMot(string unMot)
        {
            if (!string.IsNullOrEmpty(unMot))
            {
                this.lesMots.Add(unMot);
                this.totalPoints += CalculerPoints(unMot);
            }
        }

        /// <summary>
        /// retourne le nombre total de points du joueur
        /// </summary>
        /// <returns>nombre total de points du joueur</returns>
        public int GetTotalPoints()
        {
            return this.totalPoints;
        }

        /// <summary>
        /// retourne le nombre de mots du joueur
        /// </summary>
        /// <returns>nombre de mots du joueur</returns>
        public int GetNbMots()
        {
            return this.lesMots.Count;
        }

        /// <summary>
        /// retourne la liste des mots du joueur
        /// </summary>
        /// <returns>liste de mots du joueur</returns>
        public List<string> GetLesMots()
        {
            return this.lesMots;
        }

        /// <summary>
        /// retourne le mot qui a rapporté le plus grand nombre de points 
        /// parmi les mots proposés par le joueur
        /// </summary>
        /// <returns>mot qui a rapporté le plus grand nombre de points</returns>
        public string MotMeilleur()
        {
            if (lesMots.Count == 0) return "";

            string meilleurMot = lesMots[0];
            foreach (string mot in lesMots)
            {
                if (CalculerPoints(mot) > CalculerPoints(meilleurMot))
                {
                    meilleurMot = mot;
                }
            }
            return meilleurMot;
        }
        /// <summary>
        /// Méthode utilitaire pour simuler le calcul des points d'un mot
        /// </summary>
        private int CalculerPoints(string mot)
        {
            return Utilitaire.PointsMot(mot);
        }
        public string Nom
        {
            get { return this.nom; }
        }
        #endregion
    }
}