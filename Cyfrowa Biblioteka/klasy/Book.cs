using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka.klasy
{
    internal class Book : Item
    {
        public string Author { get; set; }
        public int Pages { get; set; }

        public Book(string title = " ", int rate = 0, int year_of_production = 0, string author = " ", int pages = 0, string komentarz = " ") : base(title, rate, year_of_production, komentarz)
        {
            this.Author = author;
            this.Pages = pages;
        }

        public override string Wypisz()
        {
            string info = $"Tytuł:   '{this.Title}'\n" +
                $"Ocena:   {this.Rate.ToString()}\n" +
                $"Rok wydania:    {this.Year_of_production.ToString()} \n" +
                $"Reżyser:   {this.Author}\n" +
                $"Strony:   {this.Pages.ToString()}\n\n\n" +
                $"---------------------------------------\n" +
                $"Komentarz:\n{this.Komentarz}";

            return info;
        }
    }
}
