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
    /// Логика взаимодействия для PublicPagexaml.xaml
    /// </summary>
    public partial class PublicPage : Page
    {
        ИздательствоEntities1 context;
        public PublicPage(ИздательствоEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            listPublic.ItemsSource = cont.TypeProduction.ToList();

            var typeproductList = context.TypeProduction.ToList();
            typeproductList.Insert(0, new TypeProduction() { Title = "Все типы продукции"});
            typeBox.ItemsSource = typeproductList;
            typeBox.SelectedIndex= 0;
        }

        void FilterData()
        {
            var list = context.TypeProduction.ToList();
            if (typeBox.SelectedIndex !=0)
            {
                TypeProduction typeProduction = typeBox.SelectedItem as TypeProduction;
                list = list.Where(x=> x.IdType == typeProduction.IdType).ToList();
            }
            if(! string.IsNullOrWhiteSpace(searchBox.Text))
            {
                list = list.Where(x=> x.Title.ToLower().Contains(searchBox.Text.ToLower())).ToList();
            }
            listPublic.ItemsSource = list;
        }

        private void ChaneType(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
    }
}
