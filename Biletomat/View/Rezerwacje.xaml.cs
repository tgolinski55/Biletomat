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

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/" + MainScreen.currentUser + ".res";
        public void ReservationListLoaded()
        {
            reservationList.ItemsSource = rezerwacje;
            rezerwacje.Clear();
            if (File.Exists(path))
            {
                //File.Create(path);
                string[] lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    if (line.Length > 0)
                    {
                        var firstValue = line.Split('\t')[0];
                        var secondValue = line.Split('\t')[1];
                        var thirdValue = line.Split('\t')[2];
                        var fourthValue = line.Split('\t')[3];
                        var fifthValue = line.Split('\t')[4];
                        rezerwacje.Add(new ListaKoncertów(firstValue, secondValue, thirdValue, fourthValue, fifthValue));
                        reservationList.ItemsSource = rezerwacje;
                    }
                }
            }
        }



        private void DeleteReservation(object sender, RoutedEventArgs e)
        {
            rezerwacje.RemoveAt(reservationList.SelectedIndex);
            UpdateReservations();
        }
        private void UpdateReservations()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/" + MainScreen.currentUser + ".res";
            int i = 0;
            if (rezerwacje.Count == 0)
                using (var sw = new StreamWriter(path, false))
                    sw.WriteLine();
            else
            {
                using (var sw = new StreamWriter(path, false))
                {
                    foreach (var item in rezerwacje)
                    {
                        var first = rezerwacje[i].Date;
                        var second = rezerwacje[i].Event;
                        var third = rezerwacje[i].Artists;
                        var fourth = rezerwacje[i].Place;
                        var fifth = rezerwacje[i].Link;
                        var newItem = new ListaKoncertów(first, second, third, fourth, fifth);
                        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/"))
                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/");
                        sw.WriteLine(first + '\t' + second + '\t' + third + '\t' + fourth + '\t' + fifth + '\t');
                        i++;
                    }
                }
            }
        }

        private void OpenExternalLink(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(rezerwacje[reservationList.SelectedIndex].Link);

            }
            catch
            {
                MessageBox.Show("Nie można wyświetlić strony z rezerwacją biletów", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
