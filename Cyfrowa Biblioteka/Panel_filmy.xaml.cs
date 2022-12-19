using System;
using System.Collections.Generic;
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
    /// Interaction logic for Panel_filmy.xaml
    /// </summary>
    public partial class Panel_filmy : UserControl
    {
        public Panel_filmy()
        {
            InitializeComponent();
            List<Test> testlist = new List<Test>();
            testlist.Add(new Test("test"));
            testlist.Add(new Test("test1"));
            testlist.Add(new Test("test2"));
            List<string> namelist = new List<string>();
            foreach (Test test in testlist)
            {
                namelist.Add(test.name);
            }
            YourListBox.ItemsSource = namelist;
        }


    }
}
