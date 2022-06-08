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
    /// Логика взаимодействия для ChoicePage.xaml
    /// </summary>
    public partial class ChoicePage : Page
    {
        public ChoicePage()
        {
            InitializeComponent();
        }

        private void ButProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductPage());
        }

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierPage());
        }

        private void BtnPurchase_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PurchasePage());
        }

        private void BtnArrival_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ArrivalPage());
        }
    }
}
