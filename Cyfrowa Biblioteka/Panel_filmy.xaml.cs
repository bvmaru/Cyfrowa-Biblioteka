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
            var inputFilmsString = File.ReadAllText(@"E:\c# nauka\filmsfile.txt");
            filmsObjectFromFile = JsonConvert.DeserializeObject<List<Film>>(inputFilmsString);

            var namelist = new List<string>();

            foreach (Film film in filmsObjectFromFile)
            {
                namelist.Add(film.Title);
            }
            YourListBox.ItemsSource = filmsObjectFromFile;
        }

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            //szczegoly.Text = film.Text;
            if (YourListBox.SelectedItem != null)
            {
                szczegoly.Text = ((Film)YourListBox.SelectedItem).Rate.ToString();
            }
        }
    }
}
