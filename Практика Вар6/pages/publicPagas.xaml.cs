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
    /// Логика взаимодействия для publicPagas.xaml
    /// </summary>
    public partial class publicPagas : Page
    {
        PraktikV6Entities context;
        
        public publicPagas(PraktikV6Entities cont)
        {
            InitializeComponent();
            context = cont;
            listDishes.ItemsSource = cont.Order.ToList();

            var categoryList = context.Publication.ToList();
            categoryList.Insert(0, new Publication() { Title = "Все категории" });
            categoryBox.ItemsSource = categoryList;
            categoryBox.SelectedIndex = 0;
        }

        void FilterData()
        {
            var list = context.Publication.ToList();
            if (categoryBox.SelectedIndex != 0)
            {
                Order category = categoryBox.SelectedItem as Order;
                list = list.Where(x => x.IdOrder == category.IdTypeProduction).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                list = list.Where(x => x.Title.Contains(searchBox.Text)).ToList();
            }

            listDishes.ItemsSource = list;

        }


        private void ChaneCategory(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
    
    }
}
