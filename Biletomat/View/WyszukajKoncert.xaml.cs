using Biletomat.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            border.CornerRadius = new CornerRadius(10, 0, 10, 10);
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
            border.CornerRadius = new CornerRadius(0, 10, 10, 10);
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

        private void BotResultPreset(string[] result)
        {
            var nazwaSrch = "";
            var dataSrch = "";
            var miejsceSrch = "";

            var dataGrid = new DataGrid();
            var border = new Border();
            var button = new Button();
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(dataGrid);
            stackPanel.Children.Add(button);

            border.CornerRadius = new CornerRadius(0, 10, 10, 10);
            border.Child = stackPanel;
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.Background = new SolidColorBrush(Color.FromRgb(36, 92, 127));
            border.Margin = new Thickness(5);
            border.MaxWidth = 300;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            var col1 = new DataGridTextColumn();
            var col2 = new DataGridTextColumn();
            var col3 = new DataGridTextColumn();
            col1.Header = "Nazwa";
            col2.Header = "Data";
            col3.Header = "Miejsce";
            dataGrid.Columns.Add(col1);
            dataGrid.Columns.Add(col2);
            dataGrid.Columns.Add(col3);
            foreach (var line in result)
            {
                nazwaSrch = line.Split('\t')[2];
                dataSrch = line.Split('\t')[0];
                miejsceSrch = line.Split('\t')[3];
                dataGrid.ItemsSource = result;
            }
            col1.Binding = new Binding(nazwaSrch);
            col2.Binding = new Binding(dataSrch);
            col3.Binding = new Binding(miejsceSrch);
            dataGrid.Margin = new Thickness(5);


            button.Content = "Rezerwuj";
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Bottom;

            //textBlock.Text = str;
            //textBlock.TextWrapping = TextWrapping.Wrap;
            //textBlock.Foreground = Brushes.WhiteSmoke;
            //textBlock.Padding = new Thickness(5);

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
                    message = "Interesuje Cię zespół " + chatMessage.Text + "? Oto lista propozycji dla tego zapytania:";

                BotMessagePreset(message);
                GenerateResult();
            }

        }

        private void GenerateResult()
        {
            var search = chatMessage.Text;
            List<string> result = new List<string>();
            string path = @"ListaKoncertów.txt";
            string[] lines = File.ReadAllLines(path);
            int i = 0;
            foreach (var line in lines)
            {
                if (line.ToLower().Contains(search.ToLower()))
                    result.Add(line);


                //var firstValue = line.Split('\t')[0];
                //var secondValue = line.Split('\t')[1];
                //var thirdValue = line.Split('\t')[2];
                //var fourthValue = line.Split('\t')[3];
                i++;
            }
            BotResultPreset(result.ToArray());
        }
    }
}
