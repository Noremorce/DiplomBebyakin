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
    /// Логика взаимодействия для ArrivalPage.xaml
    /// </summary>
    public partial class ArrivalPage : Page
    {
        public ArrivalPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGArrival.ItemsSource = StoreEntities.GetContext().Arrival.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditArrivalPage((Arrival)DGArrival.Items[DGArrival.SelectedIndex]));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            int error = 0;
            string search = TBSearch.Text;
            for (int i = 0; i < search.Length; i++)
            {
                if (Convert.ToChar(search[i]) < 48 || 57 < Convert.ToChar(search[i]))
                {
                    error++;
                }
            }
            if (search=="")
            {
                StoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGArrival.ItemsSource = StoreEntities.GetContext().Arrival.ToList();
            }
            else if (error == 0)
            {
                int id = Convert.ToInt32(search);
                DGArrival.ItemsSource = StoreEntities.GetContext().Arrival.Where(c => c.Purchases.Id_Purchase == id).ToList();
            }
            else
            {
                MessageBox.Show("Некорректно введен номер заказа!");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditArrivalPage(null));
        }

        private void TBSearch_MouseEnter(object sender, RoutedEventArgs e)
        {
            TBSearch.Clear();
        }
    }
}
