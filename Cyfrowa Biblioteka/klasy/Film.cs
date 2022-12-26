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

        public override string Wypisz()
        {
            string info = $"Tytuł:   '{this.Title}'\n" +
                $"Ocena:   {this.Rate.ToString()}\n" +
                $"Rok produkcji:    {this.Year_of_production.ToString()} \n" +
                $"Reżyser:   {this.Director}\n" +
                $"Czas trwania:   {this.Duration.ToString()} min\n\n\n" +
                $"---------------------------------------\n" +
                $"Komentarz:\n{this.Komentarz}";

            return info;
        }
    }
}
