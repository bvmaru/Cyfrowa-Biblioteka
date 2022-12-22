using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka.klasy
{
    internal class Film : Item
    {
        public string Director { get; set; }
        public int Duration { get; set; }

        public Film(string title = " ", int rate = 0, int year_of_production = 0, string director = " ", int duration = 0, string komentarz = " ") : base(title, rate, year_of_production, komentarz)
        {
            this.Director = director;
            this.Duration = duration;
        }
    }
}
