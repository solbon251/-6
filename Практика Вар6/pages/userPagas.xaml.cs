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
    /// Логика взаимодействия для userr.xaml
    /// </summary>
    public partial class userr : Page
    {
        PraktikV6Entities context;
        public userr(PraktikV6Entities _cont)
        {
            InitializeComponent();
            context = _cont;
            countUsse.Text = "Введите данные для поиска";
            PoiskText.Text = Name;
            sumAut.Text = "Введите категорию для фильтрации";
            UsserData.ItemsSource = context.Author.ToList();
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уточно хотите удалить Пользователся?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Author Aut = (sender as Hyperlink).DataContext as Author;
                    context.Author.Remove(Aut);
                    context.SaveChanges();
                    UsserData.ItemsSource = context.Author.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void AddAuthorClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAutorPagas(context));
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Author Aut = (sender as Hyperlink).DataContext as Author;
            NavigationService.Navigate(new AddAutorPagas(context));
        }

    }
}
