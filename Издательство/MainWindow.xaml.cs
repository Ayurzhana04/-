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

namespace Издательство
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ИздательствоEntities1 context; 
        public MainWindow()
        {
            InitializeComponent();
            DownloadPictures();
            context = new ИздательствоEntities1();
            myFrame.Navigate(new Страницы.Авторизация(context));
        }

        public void DownloadPictures()
        {
            using (ИздательствоEntities1 context = new ИздательствоEntities1())
            {
                foreach (var item in context.TypeProduction.ToList())
                {
                    item.Photo = File.ReadAllBytes($"C:/Users/aurza/Documents/практика 2023/image/{item.IdType}.jpg");
                }
                context.SaveChanges();
            }
        }
    }
}
