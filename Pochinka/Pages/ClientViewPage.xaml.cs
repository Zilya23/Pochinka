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
    /// Логика взаимодействия для ClientViewPage.xaml
    /// </summary>
    public partial class ClientViewPage : Page
    {
        public List<Client_Servise> ClientsService { get; set; }
        public Client Client { get; set; }
        public ClientViewPage(Client client)
        {
            InitializeComponent();
            Client = client;
            ClientsService = bd_connection.connection.Client_Servise.Where(x => x.IdClien == client.Id).ToList();

            DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavnayaPage());
        }
    }
}
