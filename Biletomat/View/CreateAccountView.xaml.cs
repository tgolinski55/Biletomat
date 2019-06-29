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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biletomat.View
{
    /// <summary>
    /// Logika interakcji dla klasy CreateAccountView.xaml
    /// </summary>
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (nameFld.Text.Length == 0 || passFld.Password.Length == 0 || passReFld.Password.Length == 0 || mailFld.Text.Length == 0)
                MessageBox.Show("Wszystkie pola muszą być wypełnione", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (passFld.Password != passReFld.Password)
                MessageBox.Show("Podane hasła się różnią", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (nameFld.Text == "admin" || passFld.Password == "admin")
                MessageBox.Show("Nie można utworzyć konta z podanymi danymi", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                using (var sw = new StreamWriter(path + "/" + nameFld.Text + ".profile", false))
                {
                    sw.WriteLine("Nazwa: " + nameFld.Text);
                    sw.WriteLine("Hasło: " + passFld.Password);
                    sw.WriteLine("E-mail: " + mailFld.Text);
                }
                PageNavigator.Switch(new LoginView());
            }
        }

        private void PreviousWindow(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new LoginView());
        }
    }
}
