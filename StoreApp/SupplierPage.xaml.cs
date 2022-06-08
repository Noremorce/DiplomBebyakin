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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGSupplier.ItemsSource = StoreEntities.GetContext().Suppliers.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplierPage((Suppliers)DGSupplier.Items[DGSupplier.SelectedIndex]));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text;

            DGSupplier.ItemsSource = StoreEntities.GetContext().Suppliers.Where(c => c.Name.Contains(search)).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplierPage(null));
        }
        private void TBSearch_MouseEnter(object sender, RoutedEventArgs e)
        {
            TBSearch.Clear();
        }

    }
}
