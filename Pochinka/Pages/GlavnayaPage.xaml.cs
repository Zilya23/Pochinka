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
using Pochinka.DataBase;

namespace Pochinka.Pages
{
    /// <summary>
    /// Логика взаимодействия для GlavnayaPage.xaml
    /// </summary>
    public partial class GlavnayaPage : Page
    {
        public static List<Client> clients { get; set; }
        public static List<Gender> genders { get; set; }
        public GlavnayaPage()
        {
            InitializeComponent();
            clients = bd_connection.connection.Client.ToList();
            genders = bd_connection.connection.Gender.ToList();

            cbFilter.ItemsSource = genders;
            cbFilter.DisplayMemberPath = "Name";

            DataContext = this;
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePage());
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvClients.SelectedItems != null)
            {
                var client = lvClients.SelectedItem as Client;
                NavigationService.Navigate(new ClientViewPage(client));
            }
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }

        public void Filter()
        {
            List<Client> filterClients = bd_connection.connection.Client.ToList();

            if(cbFilter.SelectedItem != null)
            {
                var gender = cbFilter.SelectedItem as Gender;
                filterClients = filterClients.Where(x => x.Gender == gender).ToList();
            }

            if(tbSearch.Text.Trim().Length != 0)
            {
                filterClients = filterClients.Where(x => x.Name.Contains(tbSearch.Text.Trim()) || x.Surname.Contains(tbSearch.Text.Trim()) || x.Lastname.Contains(tbSearch.Text.Trim())).ToList();
            }

            lvClients.ItemsSource = filterClients;
        }
    }
}
