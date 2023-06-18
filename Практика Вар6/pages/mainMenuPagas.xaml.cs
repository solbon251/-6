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
    /// Логика взаимодействия для mainMenuPagas.xaml
    /// </summary>
    public partial class mainMenuPagas : Page
    {
        Window Window;
        PraktikV6Entities _context;
        public mainMenuPagas(PraktikV6Entities context, Window window)
        {
            InitializeComponent();
            Window = window;
            _context = context;
        }

        private void userClick(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new userr(_context));
        }

        private void publicClick(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new publicPagas(_context));
        }

        private void EscapeClick(object sender, RoutedEventArgs e)
        { 
              Window.Close();
        }

        
    }
}
