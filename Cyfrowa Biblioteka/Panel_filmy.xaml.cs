using Cyfrowa_Biblioteka.klasy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Cyfrowa_Biblioteka
{
    /// <summary>
    /// Interaction logic for Panel_filmy.xaml
    /// </summary>
    public partial class Panel_filmy : UserControl
    {
        private List<Film> filmsObjectFromFile { get; set; }
        public Panel_filmy()
        {
            InitializeComponent();
            usun.Visibility = Visibility.Hidden;
            if (File.Exists(SavePath.PathFilmy))
            { 
                var inputFilmsString = File.ReadAllText(SavePath.PathFilmy);
                filmsObjectFromFile = JsonConvert.DeserializeObject<List<Film>>(inputFilmsString);
            }

                YourListBox.ItemsSource = filmsObjectFromFile; 
        }

        //private void Szczegoly_Click(object sender, RoutedEventArgs e)
        //{
        //    //szczegoly.Text = film.Text;
        //    if (YourListBox.SelectedItem != null)
        //    {
        //        string info = $"Tytuł:   '{((Film)YourListBox.SelectedItem).Title}'\n" +
        //            $"Ocena:   {((Film)YourListBox.SelectedItem).Rate.ToString()}\n" +
        //            $"Rok produkcji:    {((Film)YourListBox.SelectedItem).Year_of_production.ToString()} \n" +
        //            $"Reżyser:   {((Film)YourListBox.SelectedItem).Director}\n" +
        //            $"Czas trwania:   {((Film)YourListBox.SelectedItem).Duration.ToString()} min\n\n\n" +
        //            $"------------------------------------\n" +
        //            $"Komentarz:\n{((Film)YourListBox.SelectedItem).Komentarz}";
        //        szczegoly.Text = info;
        //    }
        //}

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            AddFilm newFilm = new AddFilm();
            newFilm.ShowDialog();
            if (File.Exists(SavePath.PathFilmy))
            {
                var inputFilmsString = File.ReadAllText(SavePath.PathFilmy);
                filmsObjectFromFile = JsonConvert.DeserializeObject<List<Film>>(inputFilmsString);
                YourListBox.ItemsSource = filmsObjectFromFile;
            }


        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            filmsObjectFromFile.Remove((Film)YourListBox.SelectedItem);
            YourListBox.ItemsSource = null;

            string output = JsonConvert.SerializeObject(filmsObjectFromFile);
            File.WriteAllText(SavePath.PathFilmy, output);

            YourListBox.ItemsSource = filmsObjectFromFile;
            usun.Visibility = Visibility.Hidden;
        }

        private void YourListBox_Selected(object sender, RoutedEventArgs e)
        {
            usun.Visibility = Visibility.Visible;

            if (YourListBox.SelectedItem != null)
            {
                szczegoly.Text = ((Film)YourListBox.SelectedItem).Wypisz();
            }
            else { szczegoly.Text = null; }
        }
    }
}
