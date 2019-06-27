﻿using Biletomat.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Biletomat.View
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        public ObservableCollection<OptionsList> options = new ObservableCollection<OptionsList>(); 
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new LoginView());
        }

        private void OptionsListLoaded(object sender, RoutedEventArgs e)
        {
            options.Add(new OptionsList("Rezerwacje", false));
            options.Add(new OptionsList("Wyszukaj", false));
            options.Add(new OptionsList("Koncerty", true));
            optionsList.ItemsSource = options;
        }

        private void ChangeOption(object sender, SelectionChangedEventArgs e)
        {
            if (optionsList.SelectedIndex == 0)
                optionsFrame.Navigate(new Rezerwacje());
            else if (optionsList.SelectedIndex == 1)
                optionsFrame.Navigate(new WyszukajKoncert());
            else if (optionsList.SelectedIndex == 2)
                optionsFrame.Navigate(new Koncerty());
        }
    }
}