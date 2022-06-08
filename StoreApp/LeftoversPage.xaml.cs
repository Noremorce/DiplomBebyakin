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
    /// Логика взаимодействия для LeftoversPage.xaml
    /// </summary>
    public partial class LeftoversPage : Page
    {
        public LeftoversPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGProduct.ItemsSource = StoreEntities.GetContext().Products.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditLeftoversPage((sender as Button).DataContext as Products));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text;

            DGProduct.ItemsSource = StoreEntities.GetContext().Products.Where(c => c.Name.Contains(search)).ToList();
        }


        private void TBSearch_MouseEnter(object sender, RoutedEventArgs e)
        {
            TBSearch.Clear();
        }
    }
}