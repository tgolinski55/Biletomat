using Biletomat.Logic;
using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biletomat.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : MetroWindow
    {
        public Home()
        {
            InitializeComponent();
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/");
            PageNavigator.pageSwitcher = this;
            PageNavigator.Switch(new LoginView());
        }
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
    }
}
