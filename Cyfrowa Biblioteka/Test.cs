using Cyfrowa_Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyfrowa_Biblioteka
{
    internal class Test
    {
        public string name;
        public int ocena;

        public Test(string name, int ocena)
        {
            this.name = name;
            this.ocena = ocena;
        }
    }
}

//List<Test> testlist = new List<Test>();
//testlist.Add(new Test("test"));
//testlist.Add(new Test("test1"));
//testlist.Add(new Test("test2"));
//YourListBox.ItemsSource = new List<String> { "One", "Two", "Three" };