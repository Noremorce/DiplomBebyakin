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
    /// Логика взаимодействия для EditLeftoversPage.xaml
    /// </summary>
    public partial class EditLeftoversPage : Page
    {
        private Products _currentProduct = new Products();
        public EditLeftoversPage(Products selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                _currentProduct = selectedProduct;

            DataContext = _currentProduct;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int correctly = 0;
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

            if (TBUnit.Text == "" && Convert.ToInt32(TBUnit.Text) < 4) MessageBox.Show("Введите единицу измерения (до 3х символов)!");
            else correctly++;

            if (correctly == 2)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}