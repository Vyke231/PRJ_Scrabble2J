using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scrabble2Joueurs
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public Joueur J1;
        public Joueur J2;

        private int nbmotJ1 = 0;
        private int nbmotJ2 = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
private void btnCommencer_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomJ1.Text != "" && txtNomJ2.Text != "")
            {
                if (txtNomJ1.Text != txtNomJ2.Text)
                {
                    //
                    this.J1 = new Joueur(txtNomJ1.Text);
                    this.J2 = new Joueur(txtNomJ2.Text);
                    //
                    Random rnd = new Random();
                    int rng = rnd.Next(0, 2);
                    //
                    if (rng == 1)
                    {
                        BordureJoueur1.IsEnabled = false;
                        BordureJoueur2.IsEnabled = true;
                        rnglettreJ2.Content = Utilitaire.RngLettre();
                        btnCommencer.Visibility = Visibility.Hidden;

                    }
                    else
                    {
                        BordureJoueur2.IsEnabled = false;
                        BordureJoueur1.IsEnabled = true;
                        rnglettreJ1.Content = Utilitaire.RngLettre();
                        btnCommencer.Visibility = Visibility.Hidden;
                    }
                }
                else MessageBox.Show("Merci de mettre des Noms Differents", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Merci de remplir les NomS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            {
            }
        }
private void btnValiderJ1_Click(object sender, RoutedEventArgs e)
        {
            string motJ1 = textboxJ1.Text.ToUpper();
            string rngJ = rnglettreJ1.Content.ToString().ToUpper();

            foreach (char lettre in motJ1)
            {
                int index = rngJ.IndexOf(lettre);
                if (index == -1)
                {
                    MessageBox.Show("La lettre " + lettre + " nest pas valide.");
                    return;
                }
                rngJ = rngJ.Remove(index, 1);
            }

            int points = Utilitaire.PointsMot(motJ1);
            MessageBox.Show("Votre mot a fait " + points + " points. " + (nbmotJ1+1) + "/10");
            this.J1.AjouterMot(motJ1);
            nbmotJ1++;

            ptsJ1.Content = J1.GetTotalPoints().ToString();

            VerifierFinPartie();

            BordureJoueur1.IsEnabled = false;
            BordureJoueur2.IsEnabled = true;
            textboxJ1.Clear();
            rnglettreJ2.Content = Utilitaire.RngLettre();
        }

private void btnValiderJ2_Click(object sender, RoutedEventArgs e)
        {
            string motJ2 = textboxJ2.Text.ToUpper();
            string rngJ = rnglettreJ2.Content.ToString().ToUpper();

            foreach (char lettre in motJ2)
            {
                int index = rngJ.IndexOf(lettre);
                if (index == -1)
                {
                    MessageBox.Show("La lettre " + lettre + " nest pas valide.");
                    return;
                }
                rngJ = rngJ.Remove(index, 1);
            }

            int points = Utilitaire.PointsMot(motJ2);
            MessageBox.Show("Votre mot a fait " + points + " points. " + (nbmotJ2+1) + "/10");
            this.J2.AjouterMot(motJ2);
            nbmotJ2++;

            ptsJ2.Content = J2.GetTotalPoints().ToString();

            VerifierFinPartie();

            BordureJoueur2.IsEnabled = false;
            BordureJoueur1.IsEnabled = true;
            textboxJ2.Clear();
            rnglettreJ1.Content = Utilitaire.RngLettre();
        }
        

        private void txtNomJ1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void txtNomJ2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_j2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VerifierFinPartie()
        {
            if (nbmotJ1 >= 10 && nbmotJ2 >= 10)
            {
                string resultatTexte = "--- FIN DE LA PARTIE ---\n\n";
                Joueur gagnant = null;

                if (J1.GetTotalPoints() > J2.GetTotalPoints())
                {
                    gagnant = J1;
                }
                else if (J2.GetTotalPoints() > J1.GetTotalPoints())
                {
                    gagnant = J2;
                }

                resultatTexte += J1.Nom + " : " + J1.GetTotalPoints() + " pts\n";
                resultatTexte += J2.Nom + " : " + J2.GetTotalPoints() + " pts\n\n";

                if (gagnant != null)
                {
                    string topMot = gagnant.MotMeilleur();
                    int ptsTopMot = Utilitaire.PointsMot(topMot);

                    resultatTexte += "le gangant est : " + gagnant.Nom + "\n";
                    resultatTexte += "son meilleur mot : " + topMot + " (" + ptsTopMot + " pts)";
                }
                else
                {
                    resultatTexte += "Match nul !";
                }

                MessageBox.Show(resultatTexte, "Resultats Final", MessageBoxButton.OK, MessageBoxImage.Information);

                BordureJoueur1.IsEnabled = false;
                BordureJoueur2.IsEnabled = false;
            }
        }
    }
}
