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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        public PurchasePage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGPurchase.ItemsSource = StoreEntities.GetContext().Purchases.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPurchasePage((Purchases)DGPurchase.Items[DGPurchase.SelectedIndex]));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text;

            DGPurchase.ItemsSource = StoreEntities.GetContext().Purchases.Where(c => c.Products.Name.Contains(search)).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPurchasePage(null));
        }

        private void TBSearch_MouseEnter(object sender, RoutedEventArgs e)
        {
            TBSearch.Clear();
        }

    }
}
