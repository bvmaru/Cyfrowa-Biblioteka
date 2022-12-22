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
using System.Windows.Shapes;

namespace Cyfrowa_Biblioteka
{
    /// <summary>
    /// Interaction logic for AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        private List<Film> filmsObjectFromFile { get; set; }
        public AddFilm()
        {
            InitializeComponent();

            if (File.Exists(SavePath.PathFilmy))
            {
                var inputFilmsString = File.ReadAllText(SavePath.PathFilmy);
                filmsObjectFromFile = JsonConvert.DeserializeObject<List<Film>>(inputFilmsString);
            }
            else
            {
                filmsObjectFromFile= new List<Film>();
            }

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userTitle.Text) && !string.IsNullOrEmpty(userRate.Text) && !string.IsNullOrEmpty(userYear.Text) && !string.IsNullOrEmpty(userDirector.Text))
            {
                Film newFilm = new Film(
                    userTitle.Text,
                    int.Parse(userRate.Text),
                    int.Parse(userYear.Text),
                    userDirector.Text,
                    int.Parse(userDuration.Text),
                    userComment.Text
                    );
                filmsObjectFromFile.Add(newFilm);

                string output = JsonConvert.SerializeObject(filmsObjectFromFile);
                File.WriteAllText(SavePath.PathFilmy, output);
                this.Close();
            }
        }


        private void userYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void userDuration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void userRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }
    }
}
