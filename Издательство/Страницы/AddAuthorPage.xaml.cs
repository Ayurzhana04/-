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
using System.Xml.Linq;

namespace Издательство.Страницы
{
    /// <summary>
    /// Логика взаимодействия для AddAuthorPage.xaml
    /// </summary>
    public partial class AddAuthorPage : Page
    {
        ИздательствоEntities1 context;
        Author author;
        public AddAuthorPage(ИздательствоEntities1 c)
        {
            InitializeComponent();
            context = c;

        }

        public AddAuthorPage(ИздательствоEntities1 c, Author aut)
        {
            InitializeComponent();
            context = c;
            author= aut;
            buttonAU.Content = "Редактировать";
            buttonAU.Click += UpdateClick;
            NameBox.Text = author.Name;
            PhoneBox.Text = author.Phone;
            CommentBox.Text = author.Comment;
            adresBox.Text = author.adres.ToString();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                author.Name = NameBox.Text;
                author.Phone = PhoneBox.Text;
                author.Comment = CommentBox.Text;
                author.adres = adresBox.ToString();
                context.SaveChanges();
                NavigationService.Navigate(new AuthorPage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка!");

            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddAuthor(object sender, RoutedEventArgs e)
        {
            try
            {
                Author aut = new Author()
                {
                    idAuthor = context.Author.Count()+1,
                    Name= NameBox.Text,
                    Phone= PhoneBox.Text,
                    Comment= CommentBox.Text,
                    adres= adresBox.ToString(),
                };
                context.Author.Add(aut);
                context.SaveChanges();
                NavigationService.Navigate(new AuthorPage(context));
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
