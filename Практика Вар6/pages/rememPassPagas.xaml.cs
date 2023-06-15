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

namespace Практика_Вар6.pages
{
    /// <summary>
    /// Логика взаимодействия для rememPassPagas.xaml
    /// </summary>
    public partial class rememPassPagas : Page
    {
        Users _user;
        public rememPassPagas(Users user)
        {
            InitializeComponent();
            loginBox.Text = user.email;
            _user = user;
        }

        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            if (_user.email == loginBox.Text && _user.serverNum == Convert.ToInt32(serverNumBox.Text))
                MessageBox.Show($"Ваш пароль: {_user.password}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
