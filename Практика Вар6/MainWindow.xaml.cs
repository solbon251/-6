using System;
using System.Collections.Generic;
using System.IO;
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

namespace Практика_Вар6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PraktikV6Entities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new PraktikV6Entities();
            myFrame.Navigate(new pages.avtoriz(context, this));
        }
        public void DownloadPictures()
        {
            using (PraktikV6Entities context = new PraktikV6Entities())
            {
                foreach (var item in context.Publication.ToList())
                {
                    item.Photo = File.ReadAllBytes($"C:/Games/Photo/{item.IdPublication}.jpg");
                }
                context.SaveChanges();
            }
        }
    }
}
