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
            AddBook newBook = new AddBook();
            newBook.ShowDialog();
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
                szczegoly.Text = ((Book)YourListBox.SelectedItem).Wypisz();
            }
            else { szczegoly.Text = null; }
        }
    }
}
