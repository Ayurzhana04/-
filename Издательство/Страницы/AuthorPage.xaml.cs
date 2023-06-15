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
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        ИздательствоEntities1 context;
        public AuthorPage(ИздательствоEntities1 _cont)
        {
            InitializeComponent();
            context = _cont;
            countAut.Text = $"{context.Author.Count()} Пользователей";
            sumAut.Text = $"Общее количество произведений : {context.Publication.Count()}";
            AuthorData.ItemsSource = context.Author.ToList();

        }

        private void AddAuthorClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
