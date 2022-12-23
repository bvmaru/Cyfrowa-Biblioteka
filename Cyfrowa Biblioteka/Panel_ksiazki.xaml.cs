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
    /// Interaction logic for Panel_ksiazki.xaml
    /// </summary>
    public partial class Panel_ksiazki : UserControl
    {
        private List<Book> booksObjectFromFile { get; set; }
        public Panel_ksiazki()
        {
            InitializeComponent();
            usun.Visibility = Visibility.Hidden;
            if (File.Exists(SavePath.PathKsiazki))
            {
                var inputBooksString = File.ReadAllText(SavePath.PathKsiazki);
                booksObjectFromFile = JsonConvert.DeserializeObject<List<Book>>(inputBooksString);
            }

            YourListBox.ItemsSource = booksObjectFromFile;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            AddFilm newFilm = new AddFilm();
            newFilm.ShowDialog();
            if (File.Exists(SavePath.PathKsiazki))
            {
                var inputBooksString = File.ReadAllText(SavePath.PathKsiazki);
                booksObjectFromFile = JsonConvert.DeserializeObject<List<Book>>(inputBooksString);
                YourListBox.ItemsSource = booksObjectFromFile;
            }
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            booksObjectFromFile.Remove((Book)YourListBox.SelectedItem);
            YourListBox.ItemsSource = null;

            string output = JsonConvert.SerializeObject(booksObjectFromFile);
            File.WriteAllText(SavePath.PathKsiazki, output);

            YourListBox.ItemsSource = booksObjectFromFile;
            usun.Visibility = Visibility.Hidden;
        }

        private void YourListBox_Selected(object sender, RoutedEventArgs e)
        {
            usun.Visibility = Visibility.Visible;

            if (YourListBox.SelectedItem != null)
            {
                string info = $"Tytuł:   '{((Book)YourListBox.SelectedItem).Title}'\n" +
                    $"Ocena:   {((Book)YourListBox.SelectedItem).Rate.ToString()}\n" +
                    $"Rok Wydania:    {((Book)YourListBox.SelectedItem).Year_of_production.ToString()} \n" +
                    $"Autor:   {((Book)YourListBox.SelectedItem).Author}\n" +
                    $"Liczba stron:   {((Book)YourListBox.SelectedItem).Pages.ToString()} min\n\n\n" +
                    $"---------------------------------------\n" +
                    $"Komentarz:\n{((Book)YourListBox.SelectedItem).Komentarz}";
                szczegoly.Text = info;
            }
            else { szczegoly.Text = null; }
        }
    }
}
