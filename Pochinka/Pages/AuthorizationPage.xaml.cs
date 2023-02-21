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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            if (tbLog.Text.Trim().Length != 0 && pbPass.Password.Trim().Length != 0)
            {
                string log = tbLog.Text.Trim();
                string pas = pbPass.Password.Trim();
                User userExcist = bd_connection.connection.User.Where(x => x.Password == pas && x.Login == log).FirstOrDefault();
                if (userExcist != null)
                {
                    user = userExcist;
                    NavigationService.Navigate(new GlavnayaPage());
                }
                else
                    MessageBox.Show("Неверные данные");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
