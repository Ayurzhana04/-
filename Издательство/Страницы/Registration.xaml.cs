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
using System.Windows.Shapes;

namespace Издательство.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        ИздательствоEntities1 context;
        public Registration(ИздательствоEntities1 cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        { 
            User user = new User() 
            { 
                Name = NameBox.Text,
                Password = PasswordBox.Text,
                TabNumber = Convert.ToInt32(tabnumBox.Text),
                Post = postBox.Text,
                Login = loginBox.Text,
            };
            context.User.Add(user);
            context.SaveChanges();
            this.Close();
        }
    }
}
