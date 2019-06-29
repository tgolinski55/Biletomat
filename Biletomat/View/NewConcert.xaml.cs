using Biletomat.Logic;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Biletomat.View
{
    /// <summary>
    /// Logika interakcji dla klasy NewConcert.xaml
    /// </summary>
    public partial class NewConcert : Window
    {
        public NewConcert()
        {
            InitializeComponent();
        }

        private void AddConcert(object sender, RoutedEventArgs e)
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/" + MainScreen.currentUser + ".res";
            ViewProvider.GetKoncerty().GetConcertsList();
            var newConcert = '\r'+dateFld.Text + '\t' + eventFld.Text + '\t' + artFld.Text + '\t' + placeFld.Text+'\t' + linkFld.Text + '\t' + tagFld.Text+'\t';
            string path = @"ListaKoncertów.txt";
            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine(newConcert);
            }
            this.Close();
        }
    }
}
