using Biletomat.Logic;
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
    /// Interaction logic for Rezerwacje.xaml
    /// </summary>
    public partial class Rezerwacje : Page
    {
        public ObservableCollection<Rezerwacja> rezerwacje = new ObservableCollection<Rezerwacja>();
        public Rezerwacje()
        {
            InitializeComponent();
        }

        private void ReservationListLoaded(object sender, RoutedEventArgs e)
        {
            rezerwacje.Add(new Rezerwacja("Koncert Adama Małysza", DateTime.Now));
            rezerwacje.Add(new Rezerwacja("Tadeusz Norek", DateTime.Now));
            rezerwacje.Add(new Rezerwacja("Karol Krawczyk", DateTime.Now));
            reservationList.ItemsSource = rezerwacje;
        }

        private void DeleteReservation(object sender, RoutedEventArgs e)
        {

        }
    }
}
