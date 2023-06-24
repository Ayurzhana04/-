//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using Издательство;

//namespace Издательство
//{
//    /// <summary>
//    /// Логика взаимодействия для ZakazPage.xaml   
//    /// </summary>
//    public partial class ZakazPage : Page
//    {
//        private const string V = "все";
//        ИздательствоEntities1 context;
//        public ZakazPage(ИздательствоEntities1 cont)
//        {
//            InitializeComponent();
//            context = cont;
//            listClient.ItemsSource = cont.Client.ToList();

//            var clientList = context.Client.ToList();
//            clientList.Insert(0, item: new Client() { idType = V });
//            typeclientBox.ItemsSource = clientList;
//            typeclientBox.SelectedIndex = 0;
//        }
//        void FilterData()
//        {
//            var list = context.Client.ToList();
//            if (typeclientBox.SelectedIndex != 0)
//            {
//                Client idType = typeclientBox.SelectedItem as Client;
//                list = list.Where(x => x.idType == idType.idType).ToList();
//            }
//            if (!string.IsNullOrWhiteSpace(searchBox.Text))
//            {
//                list = list.Where(x => x.idType.ToLower.Contains(searchBox.Text.ToLower())).ToList();
//            }
//            listClient.ItemsSource = list;
//        }

//        private void SearcChange(object sender, TextChangedEventArgs e)
//        {
//            FilterData();
//        }

//        private void ChanType(object sender, SelectionChangedEventArgs e)
//        {
//            FilterData();
//        }
//    }
//}
