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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public Service Service { get; set; }  
        public AddServicePage()
        {
            InitializeComponent();
            Service = new Service();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Service.Name))
                stringBuilder.AppendLine("Название обязательно для заполенения!");
            if (string.IsNullOrWhiteSpace(Service.Duration.ToString()))
                stringBuilder.AppendLine("Название обязательно для заполенения!");
            if (string.IsNullOrWhiteSpace(Service.Price.ToString()))
                stringBuilder.AppendLine("Название обязательно для заполенения!");

            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }

            bd_connection.connection.Service.Add(Service);
            bd_connection.connection.SaveChanges();

            NavigationService.Navigate(new ServicePage());
        }
    }
}
