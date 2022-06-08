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
    /// Логика взаимодействия для AddEditPurchasePage.xaml
    /// </summary>
    public partial class AddEditPurchasePage : Page
    {
        private Purchases _currentPurchase = new Purchases();
        public AddEditPurchasePage(Purchases selectedPurchase)
        {
            InitializeComponent();

            if (selectedPurchase != null)
                _currentPurchase = selectedPurchase;

            DataContext = _currentPurchase;
            CBProduct.ItemsSource = StoreEntities.GetContext().Products.ToList();
            CBSupplier.ItemsSource = StoreEntities.GetContext().Suppliers.ToList();
            CBSpecialist.ItemsSource = StoreEntities.GetContext().Specialists.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int correctly = 0;

            if (CBProduct.SelectedItem == null) MessageBox.Show("Выберите товар!");
            else correctly++;

            if (TBAmount.Text == "") MessageBox.Show("Введите количество товара!");
            else
            {
                int error = 0;
                for (int i = 0; i < TBAmount.Text.Length; i++)
                {
                    if (Convert.ToChar(TBAmount.Text[i]) < 48 || 57 < Convert.ToChar(TBAmount.Text[i]))
                    {
                        error++;
                    }
                }
                if (error == 0)
                {
                    correctly++;
                }
                else
                {
                    MessageBox.Show("Некорректно введено количество товара!");
                }
            }
            
            if (DPOrder_date.Text == "") MessageBox.Show("Введите дату заказа!");
            else
            {
                int error = 0;
                string[] date = DPOrder_date.Text.Split('.');

                for (int g = 0; g < date.Length; g++)
                {
                    for (int i = 0; i < date[g].Length; i++)
                    {
                        if (Convert.ToChar(date[g][i]) < 48 || 57 < Convert.ToChar(date[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    correctly++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена дата заказа!");
                }
            }

            if (CBSupplier.SelectedItem == null) MessageBox.Show("Выберите поставщика!");
            else correctly++;

            if (CBSpecialist.SelectedItem == null) MessageBox.Show("Выберите специалиста!");
            else correctly++;

            if (correctly == 5)
            {
                string price = (Convert.ToDouble(TBAmount.Text) * Convert.ToDouble(_currentPurchase.Products.Price)) + "";
                TBPrice.Text = price.Replace(',', '.');
                _currentPurchase.Price = Convert.ToDecimal(price);
                if (_currentPurchase.Id_Purchase == 0)
                {
                    StoreEntities.GetContext().Purchases.Add(_currentPurchase);
                }

                try
                {
                    StoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
