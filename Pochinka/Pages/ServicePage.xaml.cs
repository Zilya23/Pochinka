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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public List<Service> Services { get; set; }
        public ServicePage()
        {
            InitializeComponent();
            Services = bd_connection.connection.Service.ToList();

            DataContext = this;
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavnayaPage());
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbSearch.Text.Trim().Length != 0)
            {
                List<Service> client_Servises = bd_connection.connection.Service.ToList();

                client_Servises = client_Servises.Where(x => x.Name.Contains(tbSearch.Text.Trim())).ToList();

                lvService.ItemsSource = client_Servises;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage());
        }
    }
}
