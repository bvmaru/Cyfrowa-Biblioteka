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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private List<Book> booksObjectFromFile { get; set; }
        public AddBook()
        {
            InitializeComponent();
            if (File.Exists(SavePath.PathKsiazki))
            {
                var inputBooksString = File.ReadAllText(SavePath.PathKsiazki);
                booksObjectFromFile = JsonConvert.DeserializeObject<List<Book>>(inputBooksString);
            }
            else
            {
                booksObjectFromFile = new List<Book>();
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userTitle.Text) && !string.IsNullOrEmpty(userRate.Text) && !string.IsNullOrEmpty(userYear.Text) && !string.IsNullOrEmpty(userAuthor.Text))
            {
                Book newBook = new Book(
                    userTitle.Text,
                    int.Parse(userRate.Text),
                    int.Parse(userYear.Text),
                    userAuthor.Text,
                    int.Parse(userPages.Text),
                    userComment.Text
                    );
                booksObjectFromFile.Add(newBook);

                string output = JsonConvert.SerializeObject(booksObjectFromFile);
                File.WriteAllText(SavePath.PathKsiazki, output);
                this.Close();
            }
        }

        private void userPages_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void userRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void userYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

    }
}
