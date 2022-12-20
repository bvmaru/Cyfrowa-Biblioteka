using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka.klasy
{
    internal class Film : Item
    {
        private string Director { get; set; }
        private int Duration { get; set; }

        public Film(string title = " ", int rate = 0, int year_of_production = 0, string director = " ", int duration = 0) : base(title, rate, year_of_production)
        {
            this.Director = director;
            this.Duration = duration;
        }
    }
}
