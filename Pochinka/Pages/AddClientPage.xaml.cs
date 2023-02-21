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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public List<Gender> genders { get; set; }
        public Client Client { get; set; }
        public AddClientPage()
        {
            InitializeComponent();
            genders = bd_connection.connection.Gender.ToList();
            cbGender.ItemsSource = genders;
            cbGender.DisplayMemberPath = "Name";
            Client = new Client();

            DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavnayaPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Client.Surname))
                stringBuilder.AppendLine("Фамилия обязательна для заполенения!");
            if (string.IsNullOrWhiteSpace(Client.Name))
                stringBuilder.AppendLine("Имя обязательно для заполенения!");
            if (string.IsNullOrWhiteSpace(Client.Lastname))
                stringBuilder.AppendLine("Отчество обязательно для заполенения!");
            if (string.IsNullOrWhiteSpace(Client.Email))
                stringBuilder.AppendLine("Почта обязательна для заполенения!");
            if (string.IsNullOrWhiteSpace(Client.Phone))
                stringBuilder.AppendLine("Телефон обязателен для заполенения!");
            if (Client.DateBirth == null)
                stringBuilder.AppendLine("Дата рождения обязательна для заполенения!");
            if(Client.Gender == null)
                stringBuilder.AppendLine("Пол обязателен для заполенения!");
            
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }

            bd_connection.connection.Client.Add(Client);
            bd_connection.connection.SaveChanges();

            NavigationService.Navigate(new GlavnayaPage());
        }
    }
}
