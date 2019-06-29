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

        public List<string> filterList = new List<string>();
        public ObservableCollection<ListaKoncertów> tableList = new ObservableCollection<ListaKoncertów>();
        public WyszukajKoncert()
        {

            InitializeComponent();
            BotMessagePreset("Witaj, chciałbyś rozerwać się na najbliższych koncertach? Jeżeli tak to idealnie się składa. Podaj proszę nazwę zespołu, miejsce, datę lub wydarzenie a postaram się dopasować dla Ciebie najlepsze imprezy!");

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
            border.MaxWidth = 400;
            border.HorizontalAlignment = HorizontalAlignment.Right;

            textBlock.Text = chatMessage.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = Brushes.WhiteSmoke;
            textBlock.Padding = new Thickness(5);

            if (textBlock.Text.Length > 0)
                chatField.Children.Add(border);

            AddNewFilter();
            GenerateResponse(chatMessage.Text);
            chatMessage.Text = "";

        }

        public static dynamic items;
        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            tableList.Clear();
            PrepareReservationFile();
        }
        public void PrepareReservationFile()
        {
            //tableList.Clear();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/" + MainScreen.currentUser + ".res";
            int i = 0;
            foreach (var item in items)
            {
                var first = items[i].Date;
                var second = items[i].Event;
                var third = items[i].Artists;
                var fourth = items[i].Place;
                var fifth = items[i].Link;
                var newItem = new ListaKoncertów(first, second, third, fourth, fifth);
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Biletomat/Profiles/Reservations/");
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(first + '\t' + second + '\t' + third + '\t' + fourth + '\t' + fifth + '\t');
                    MessageBox.Show(third + " został dodany do listy rezerwacji", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                i++;
            }
        }
        public void GetSelectedItemsInChat(DataGrid dataGrid)
        {
            items = dataGrid.SelectedItems;
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
            border.MaxWidth = 400;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            textBlock.Text = str;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = Brushes.WhiteSmoke;
            textBlock.Padding = new Thickness(5);

            chatField.Children.Add(border);

        }

        public void BotResultPreset(string[] result)
        {
            if (result.Length > 0)
            {

                var nazwaSrch = "";
                var dataSrch = "";
                var miejsceSrch = "";
                var eventSrch = "";
                var link = "";

                var dataGrid = new DataGrid();
                var border = new Border();
                var button = new Button();
                var stackPanel = new StackPanel();
                stackPanel.Children.Add(dataGrid);
                stackPanel.Children.Add(button);
                dataGrid.Name = "chatTable";

                border.CornerRadius = new CornerRadius(0, 10, 10, 10);
                border.Child = stackPanel;
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                border.Background = new SolidColorBrush(Color.FromRgb(36, 92, 127));
                border.Margin = new Thickness(5);
                border.MaxWidth = 400;
                border.HorizontalAlignment = HorizontalAlignment.Left;

                var obs = new ObservableCollection<ListaKoncertów>();
                var col1 = new DataGridTextColumn();
                var col2 = new DataGridTextColumn();
                var col3 = new DataGridTextColumn();
                var col4 = new DataGridTextColumn();
                var col5 = new DataGridTextColumn();
                col1.Header = "Data";
                col2.Header = "Wydarzenie";
                col3.Header = "Artyści";
                col4.Header = "Miejsce";
                col5.Visibility = Visibility.Hidden;
                dataGrid.AutoGenerateColumns = false;
                GetSelectedItemsInChat(dataGrid);
                foreach (var line in result)
                {
                    nazwaSrch = line.Split('\t')[2];
                    dataSrch = line.Split('\t')[0];
                    eventSrch = line.Split('\t')[1];
                    miejsceSrch = line.Split('\t')[3];
                    link = line.Split('\t')[4];

                    obs.Add(new ListaKoncertów(dataSrch, eventSrch, nazwaSrch, miejsceSrch, link));
                }
                dataGrid.ItemsSource = obs;
                col1.Binding = new Binding("Date");
                col2.Binding = new Binding("Event");
                col3.Binding = new Binding("Artists");
                col4.Binding = new Binding("Place");
                col5.Binding = new Binding("Link");
                dataGrid.Columns.Add(col1);
                dataGrid.Columns.Add(col2);
                dataGrid.Columns.Add(col3);
                dataGrid.Columns.Add(col4);
                dataGrid.Columns.Add(col5);
                dataGrid.Foreground = Brushes.Black;
                dataGrid.GridLinesVisibility = DataGridGridLinesVisibility.All;
                dataGrid.Margin = new Thickness(5);


                button.Content = "Rezerwuj";
                button.BorderThickness = new Thickness(0);
                button.HorizontalAlignment = HorizontalAlignment.Right;
                button.VerticalAlignment = VerticalAlignment.Bottom;
                button.Click += MakeReservation;

                chatField.Children.Add(border);

            }
            else
                BotMessagePreset("Wygląda na to, że niczego nie znalazłem. Możesz bardziej sprecyzować jakich koncertów szukasz?");
        }

        private void GenerateResponse(string str)
        {
            string message = "";
            if (str.Length > 0)
            {

                message = "Oto lista propozycji dla zapytania: " + chatMessage.Text;

                BotMessagePreset(message);
                GenerateResult();
            }

        }
        private void GenerateResult()
        {
            var search = "";
            List<string> result = new List<string>();
            string path = @"ListaKoncertów.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (var filter in filterList)
            {
                search = filter;
                foreach (var line in lines)
                {
                    if (line.ToLower().StartsWith(search.ToLower()) || line.ToLower().StartsWith(search.ToLower()) || line.ToLower().Contains(search.ToLower()))
                        if (!result.Contains(line))
                            result.Add(line);
                }
            }
            BotResultPreset(result.ToArray());
        }
        private void AddNewFilter()
        {
            string result = "";
            foreach (var word in chatMessage.Text)
            {
                if (Char.IsLetter(word))
                    result += word;
                else
                {
                    if (!filterList.Contains(result) && result.Length > 2)
                        filterList.Add(result);
                    result = "";
                }

            }
            if (!filterList.Contains(result) && result.Length > 2)
                filterList.Add(result);
        }

        private void ResetChat(object sender, RoutedEventArgs e)
        {
            filterList.Clear();
            chatField.Children.Clear();
            BotMessagePreset("Witaj, chciałbyś rozerwać się na najbliższych koncertach? Jeżeli tak to idealnie się składa. Podaj proszę nazwę zespołu, miejsce, datę lub wydarzenie a postaram się dopasować dla Ciebie najlepsze imprezy!");

            chatMessage.Text = "";
        }

        private Boolean AutoScroll = true;

        private void ScrollViewer_ScrollChanged(Object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange == 0)
            {
                if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
                    AutoScroll = true;
                else
                    AutoScroll = false;
            }

            if (AutoScroll && e.ExtentHeightChange != 0)
                scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
        }

        private void SendMessageIfEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendMessage(sender, e);
        }
    }
}
