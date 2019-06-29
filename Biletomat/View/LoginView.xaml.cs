using Biletomat.Logic;
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

namespace Biletomat.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            if (Login.ValidateUser(loginField.Text, passwordField.Password)||(loginField.Text=="admin"&&passwordField.Password=="admin"))
            {
                PageNavigator.Switch(new MainScreen());
                if (loginField.Text == "admin" && passwordField.Password == "admin")
                    MainScreen.isAdmin = true;
                else
                    MainScreen.isAdmin = false;
                MainScreen.currentUser = loginField.Text;
            }
            else
                MessageBox.Show("Login lub/i hasło są nieprawidłowe.", "Błąd uwierzytelniania", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OpenCreateAccountView(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new CreateAccountView());
        }
    }
}
