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
    /// Interaction logic for Koncerty.xaml
    /// </summary>
    public partial class Koncerty : Page
    {
        public static ObservableCollection<ListaKoncertów> listaKoncertów = new ObservableCollection<ListaKoncertów>();
        public Koncerty()
        {
            InitializeComponent();
            GetConcertsList();
        }

        public void GetConcertsList()
        {
            listaKoncertów.Clear();
            string path = @"ListaKoncertów.txt";
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

                    listaKoncertów.Add(new ListaKoncertów(firstValue, secondValue, thirdValue, fourthValue, fifthValue));
                    concertsList.ItemsSource = listaKoncertów;
                }
            }
        }
        public void EnableButtonIfAdmin()
        {
            if (MainScreen.isAdmin)
                dodajKoncert.Visibility = Visibility.Visible;
            else
                dodajKoncert.Visibility = Visibility.Hidden;
        }

        private void AddNewConcert(object sender, RoutedEventArgs e)
        {
            NewConcert newConcert = new NewConcert();
            newConcert.ShowDialog();
            GetConcertsList();
        }
    }
}
