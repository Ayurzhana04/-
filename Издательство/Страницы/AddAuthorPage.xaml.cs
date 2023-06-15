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
    /// Логика взаимодействия для AddAuthorPage.xaml
    /// </summary>
    public partial class AddAuthorPage : Page
    {
        ИздательствоEntities1 context;
        public AddAuthorPage(ИздательствоEntities1 c)
        {
            InitializeComponent();
            context = c;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddAuthor(object sender, RoutedEventArgs e)
        {
            Author aut = new Author()
            {

            };
            context.Author.Add(aut);
            context.SaveChanges();
        }
        
    }
}
