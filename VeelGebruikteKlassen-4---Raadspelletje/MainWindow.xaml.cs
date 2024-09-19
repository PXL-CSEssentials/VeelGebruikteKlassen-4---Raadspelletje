using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace VeelGebruikteKlassen_4___Raadspelletje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            int numberOfAttempts = 0;
            int guessed = -1;

            string answer = Interaction.InputBox("Geef een getal tussen 0 en 100", "Raadspel", "50");

            // Testen tot er een (juiste) invoer is.
            while (guessed != randomNumber)
            {
                numberOfAttempts++;
                if (string.IsNullOrEmpty(answer) || !int.TryParse(answer, out guessed))
                {
                    MessageBox.Show("Geef een getal in", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (guessed < randomNumber)
                {
                    MessageBox.Show("Raad hoger!", "Raadspel");
                }
                else
                {
                    MessageBox.Show("Raad lager!", "Raadspel");
                }

                answer = Interaction.InputBox("Geef een getal tussen 0 en 100", "Raadspel", "50");
            }

            MessageBox.Show($"U heeft het getal geraden in {numberOfAttempts} beurten.", "Proficiat!");
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
