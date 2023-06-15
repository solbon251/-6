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
using System.Windows.Threading;

namespace Практика_Вар6.pages
{
    /// <summary>
    /// Логика взаимодействия для avtoriz.xaml
    /// </summary>
    public partial class avtoriz : Page
    {
        PraktikV6Entities context;
        DispatcherTimer timer;
        Window window;
        public avtoriz(PraktikV6Entities cont, Window w)
        {
            InitializeComponent();
            context = cont;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;
            window = w;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            buttonVhod.IsEnabled = true;
            timer.Stop();

        }
        int countClick = 0;
        private void VhodClick(object sender, RoutedEventArgs e)
        {
            countClick++;
            string log = LoginBox.Text;
            string pass = PasswordBox.Password;
                Users user = context.Users.Find(log);
            if (user != null)
            {
                if (user.password.Equals(pass))
                {
                    
                    countClick = 0;
                    NavigationService.Navigate(new mainMenuPagas(context, window));
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный пароль");
                    if (countClick >= 3)
                    {
                        Remem.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователься не сущеструет");
                if (countClick >= 3)
                {
                    buttonVhod.IsEnabled = false;
                    timer.Start();
                }
            }
        }

        private void RegistrClick(object sender, RoutedEventArgs e)
        {
            REGISTR regWindow = new REGISTR(context);
            regWindow.Show();
        }

        private void RememPassClick(object sender, RoutedEventArgs e)
        {
            Users us = context.Users.Find(LoginBox.Text);
            NavigationService.Navigate(new rememPassPagas(us));
        }
    }
}
