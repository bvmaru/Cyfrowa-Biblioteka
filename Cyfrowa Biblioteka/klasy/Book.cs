using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka.klasy
{
    internal class Book : Item
    {
        private string Author { get; set; }
        private int Pages { get; set; }

        public Book(string title = " ", int rate = 0, int year_of_production = 0, string author = " ", int pages = 0) : base(title, rate, year_of_production)
        {
            this.Author = author;
            this.Pages = pages;
        }
    }
}
