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
        lolEntities context;
        public REGISTR(lolEntities cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                email = emailBox.Text,
                Password = passBox.Text,
                age = Convert.ToInt32(ageBox.Text),
                DateOfregistration = DateTime.Now,
                DateOfLastLog = DateTime.Now
            };
            context.User.Add(user);
            context.SaveChanges();
            this.Close();
        }
    }
}
