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
using System.Windows.Shapes;

namespace Практика_Вар6.pages
{
    /// <summary>
    /// Логика взаимодействия для REGISTR.xaml
    /// </summary>
    public partial class REGISTR : Window
    {
        PraktikV6Entities context;
        public REGISTR(PraktikV6Entities cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            Users user = new Users()
            {
                email = emailBox.Text,
                password = passBox.Text,
                serverNum = Convert.ToInt32(serverNumBox.Text),
                FIO = FIOBox.Text,
                post = postBox.Text
            };
            context.Users.Add(user);
            context.SaveChanges();
            this.Close();
        }
    }
}
