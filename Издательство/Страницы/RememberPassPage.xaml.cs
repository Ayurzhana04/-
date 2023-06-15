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
    /// Логика взаимодействия для RememberPassPage.xaml
    /// </summary>
    public partial class RememberPassPage : Page
    {
        User user1; 
        public RememberPassPage(User user)
        {
            InitializeComponent();
            NameBox.Text = user.Name;
            user1 = user;
        }

        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            if (user1.Name == NameBox.Text && user1.TabNumber == Convert.ToInt32(tabnumBox.Text))
                MessageBox.Show($"Ваш пароль: {user1.Password}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
