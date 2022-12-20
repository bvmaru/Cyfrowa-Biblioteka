﻿using Cyfrowa_Biblioteka.klasy;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            panel_filmy.Visibility = Visibility.Hidden;
            panel_ksiazki.Visibility = Visibility.Hidden;
        }

        private void Button_Wyjdz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Ksiazki(object sender, RoutedEventArgs e)
        {
            panel_filmy.Visibility = Visibility.Hidden;
            panel_ksiazki.Visibility= Visibility.Visible;
        }

        private void Button_Filmy(object sender, RoutedEventArgs e)
        {
            panel_filmy.Visibility = Visibility.Visible;
            panel_ksiazki.Visibility = Visibility.Hidden;
        }

        private void Panel_filmy_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
