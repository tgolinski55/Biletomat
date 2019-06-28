using Biletomat.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for WyszukajKoncert.xaml
    /// </summary>
    public partial class WyszukajKoncert : Page
    {
        public static ObservableCollection<string> czatek = new ObservableCollection<string>();
        public WyszukajKoncert()
        {

            InitializeComponent();
            var con = new GetConcerts();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            var textBlock = new TextBlock();
            var border = new Border();
            border.CornerRadius = new CornerRadius(10);
            border.Child = textBlock;
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.Background = new SolidColorBrush(Color.FromRgb(102, 155, 188));
            border.Margin = new Thickness(5);
            border.MaxWidth = 300;
            border.HorizontalAlignment = HorizontalAlignment.Right;

            textBlock.Text = chatMessage.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = Brushes.WhiteSmoke;
            textBlock.Padding = new Thickness(5);

            if (textBlock.Text.Length > 0)
                chatField.Children.Add(border);

            GenerateResponse(chatMessage.Text);


        }
        private void BotMessagePreset(string str)
        {
            var textBlock = new TextBlock();
            var border = new Border();
            border.CornerRadius = new CornerRadius(10);
            border.Child = textBlock;
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.Background = new SolidColorBrush(Color.FromRgb(36, 92, 127));
            border.Margin = new Thickness(5);
            border.MaxWidth = 300;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            textBlock.Text = str;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = Brushes.WhiteSmoke;
            textBlock.Padding = new Thickness(5);

            chatField.Children.Add(border);

        }

        private void GenerateResponse(string str)
        {
            string message = "";
            if (str.Length > 0)
            {
                if (str.Contains("Lewicki"))
                    message = "Jak ja go kurwa nienawidze...";
                else
                    message = "Interesuje Cię zespół Karol Krawczyk? Oto lista koncertów tego zespołu";

                BotMessagePreset(message);
            }

        }
    }
}
