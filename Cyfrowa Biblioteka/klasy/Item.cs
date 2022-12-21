﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka.klasy
{
    internal class Item
    {
        public string Title { get; set; }
        public int rate;
        public int Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (value < 0 || value > 10) this.rate = 0; else this.rate = value;
            }
        }
        public int Year_of_production { get; set; }

        public Item(string title = " ", int rate = 0, int year_of_production = 0)
        {
            this.Title = title;
            this.Rate = rate;
            this.Year_of_production = year_of_production;
        }
    }
}
