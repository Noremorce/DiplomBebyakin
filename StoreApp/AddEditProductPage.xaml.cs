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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        private Products _currentProduct = new Products();
        public AddEditProductPage(Products selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                _currentProduct = selectedProduct;

            DataContext = _currentProduct;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int correctly = 0;
            if (TBName.Text == "") MessageBox.Show("Введите Название товара!");
            else correctly++;

            if (TBCountry.Text == "") MessageBox.Show("Введите страну производителя товара!");
            else correctly++;

            if (TBPrice.Text == "") MessageBox.Show("Введите цену товара!");
            else
            {
                int error = 0;
                string[] price = TBPrice.Text.Split('.');

                for (int g = 0; g < price.Length; g++)
                {
                    for (int i = 0; i < price[g].Length; i++)
                    {
                        if (Convert.ToChar(price[g][i]) < 48 || 57 < Convert.ToChar(price[g][i]))
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
                    MessageBox.Show("Некорректно введена цена!");
                }
            }

            if (correctly == 3)
            {

                if (_currentProduct.Id_Product == 0)
                {
                    StoreEntities.GetContext().Products.Add(_currentProduct);
                }

                try
                {
                    StoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)//проверка нна исключения
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}