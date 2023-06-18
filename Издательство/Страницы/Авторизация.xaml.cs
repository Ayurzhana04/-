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
using System.Windows.Threading;

namespace Издательство.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Page
    {
        ИздательствоEntities1 context;
        DispatcherTimer timer;
        Window window;
        public Авторизация(ИздательствоEntities1 cont, Window w)
        {
            InitializeComponent();
            context= cont;
            window= w;
            timer= new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,30);
            timer.Tick += Timer_Tick;
        } 

        private void Timer_Tick(object sender, EventArgs e)
        {
            buttonEnter.IsEnabled= true;
            timer.Stop();
        }

        int countClick = 0;

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            countClick++;
            string name = NameBox.Text;
            string pass = passwordBox.Password;
            User user = context.User.Find(name);
            if (user!=null) 
            {
                if (user.Password.Equals(pass)) 
                {
                    passwordBox.Background = Brushes.Green;
                    MessageBox.Show("Вы успешно авторизованы!");
                    countClick = 0;
                    NavigationService.Navigate(new MainPage(context, window));
                }
                else 
                {
                    passwordBox.Background = Brushes.Red;
                    MessageBox.Show("Некорректный ввод пароля!!!");
                    if (countClick >= 3) 
                    {
                        remindBtn.Visibility= Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует.");
                if (countClick >= 3)
                {
                    remindBtn.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(context);
            registration.Show();
            //NavigationService.Navigate(new ());
        }

        private void RememberPassClick(object sender, RoutedEventArgs e)
        {
            User us = context.User.Find(NameBox.Text);
            NavigationService.Navigate(new RememberPassPage(us));


        }
    }
}
