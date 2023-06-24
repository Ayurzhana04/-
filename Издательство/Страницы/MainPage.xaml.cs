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

namespace Издательство.Страницы
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Window Window;
        ИздательствоEntities1 _context;
        public MainPage(ИздательствоEntities1 context, Window window)
        {
            InitializeComponent();
            Window = window;
            _context = context;
        }

        private void EscapeClick(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void AuthorClick(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new AuthorPage(_context));
        }

        private void PublicClick(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new PublicPage(_context));
        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new ZakazPage(_context));
        }
    }
}
