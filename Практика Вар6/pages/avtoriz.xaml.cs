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
        lolEntities context;
        DispatcherTimer timer;
        public avtoriz(lolEntities cont)
        {
            InitializeComponent();
            context = cont;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;    
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
            User user = context.User.Find(log);
            if (user != null)
            {
                if (user.Password.Equals(pass))
                {
                    MessageBox.Show("Вы усвешно авторизовались");
                    countClick = 0;
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный пароль");
                    if (countClick >= 5)
                    {
                        buttonVhod.IsEnabled = false;
                        timer.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователься не сущеструет");
                if (countClick >= 5)
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
    }
}
