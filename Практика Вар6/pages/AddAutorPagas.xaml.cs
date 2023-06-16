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
    /// Логика взаимодействия для AddAutorPagas.xaml
    /// </summary>
    public partial class AddAutorPagas : Page
    {
        PraktikV6Entities context;
        Author autor;
        public AddAutorPagas(PraktikV6Entities c)
        {
            InitializeComponent();
            context = c;
        }

        private void CanselCkick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddAutor(object sender, RoutedEventArgs e)
        {
            try
            {
                Author ing = new Author()
                {
                    idAuthor = context.Author.ToList().Last().idAuthor + 1,
                    Name = NameBox.Text,
                    Phone = TelBox.Text,
                    Comment = CommBox.Text,
                    adres = DollBox.Text,
                };
                context.Author.Add(ing);
                context.SaveChanges();
                NavigationService.Navigate(new userr(context));
            }
            catch (FormatException) 
            {
                MessageBox.Show("Ошибка вводимых данных!");
            }
            catch 
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
