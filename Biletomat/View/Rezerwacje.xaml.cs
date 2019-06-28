using Biletomat.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for Rezerwacje.xaml
    /// </summary>
    public partial class Rezerwacje : Page
    {
        public ObservableCollection<ListaKoncertów> rezerwacje = new ObservableCollection<ListaKoncertów>();
        public Rezerwacje()
        {
            InitializeComponent();
            ReservationListLoaded();
        }

        private void ReservationListLoaded()
        {
            string path = @"Profiles/user/Rezerwacje.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var firstValue = line.Split('\t')[0];
                var secondValue = line.Split('\t')[1];
                var thirdValue = line.Split('\t')[2];
                var fourthValue = line.Split('\t')[3];
            rezerwacje.Add(new ListaKoncertów(firstValue, secondValue, thirdValue, fourthValue));
            reservationList.ItemsSource = rezerwacje;
            }
        }

        private void DeleteReservation(object sender, RoutedEventArgs e)
        {

        }
    }
}
