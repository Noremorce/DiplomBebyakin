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

namespace StoreApp
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)//отображение привязки из бд
        {
            if (Visibility == Visibility.Visible)
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGProduct.ItemsSource = StoreEntities.GetContext().Products.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductPage((Products)DGProduct.Items[DGProduct.SelectedIndex]));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)//поиск по введенномиу названию
        {
            string search = TBSearch.Text;

            DGProduct.ItemsSource = StoreEntities.GetContext().Products.Where(c => c.Name.Contains(search)).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductPage(null));
        }

        private void BtnLeftovers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LeftoversPage());
        }

        private void TBSearch_MouseEnter(object sender, RoutedEventArgs e)//при наведении очистить текст бокс
        {
            TBSearch.Clear();
        }
    }
}
