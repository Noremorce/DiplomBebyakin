using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddEditSupplierPage.xaml
    /// </summary>
    public partial class AddEditSupplierPage : Page
    {
        private Suppliers _currentSupplier = new Suppliers();
        public AddEditSupplierPage(Suppliers selectedSupplier)
        {
            InitializeComponent();
            if (selectedSupplier != null)
                _currentSupplier = selectedSupplier;

            DataContext = _currentSupplier;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int kol = 0;
            int correctly = 0;

            if (TBName.Text == "") MessageBox.Show("Введите имя поставщика!");
            else correctly++;

            if (TBAddress.Text == "") MessageBox.Show("Введите адрес!");
            else correctly++;

            if (TBPhone.Text == "") MessageBox.Show("Введите номер телефона!");
            else if ("+".CompareTo(Convert.ToString(TBPhone.Text[0])) == 0)//проверка на правильность введенного н.телефона
            {
                TBPhone.Text = TBPhone.Text.Trim(' ');
                kol = 0;
                for (int i = 1; i < TBPhone.Text.Length; i++)
                {
                    if (Convert.ToChar(TBPhone.Text[i]) >= 48 && 57 >= Convert.ToChar(TBPhone.Text[i]))
                    {
                        kol++;
                    }
                }
                if (kol != 11)
                {
                    MessageBox.Show("Некорректно введен номер телефона!");
                }
                else correctly++;
            }
            else
            {
                TBPhone.Text = TBPhone.Text.Trim(' ');
                if (TBPhone.Text.Length == 11)
                {
                    kol = 0;
                    for (int i = 0; i < TBPhone.Text.Length; i++)
                    {
                        if (Convert.ToChar(TBPhone.Text[i]) >= 48 && 57 >= Convert.ToChar(TBPhone.Text[i]))
                        {
                            kol++;
                        }
                    }
                    if (kol != 11)
                    {
                        MessageBox.Show("Некорректно введен номер телефона!");
                    }
                    else correctly++;
                }
                else MessageBox.Show("Некорректно введен номер телефона!");
            }


            if (TBTIN.Text == "") MessageBox.Show("Введите ИНН!");
            else
            {
                kol = 0;
                for (int i = 0; i < TBTIN.Text.Length; i++)
                {
                    if (Convert.ToChar(TBTIN.Text[i]) >= 48 && 57 >= Convert.ToChar(TBTIN.Text[i]))
                    {
                        kol++;
                    }
                }
                if (kol != 12)
                {
                    MessageBox.Show("Некорректно введен ИНН!");
                }
                else correctly++;
            }

            if (TBSA.Text == "") MessageBox.Show("Введите номер расчетного счета!");
            else
            {
                kol = 0;
                for (int i = 0; i < TBSA.Text.Length; i++)
                {
                    if (Convert.ToChar(TBSA.Text[i]) >= 48 && 57 >= Convert.ToChar(TBSA.Text[i]))
                    {
                        kol++;
                    }
                }
                if (kol != 20)
                {
                    MessageBox.Show("Некорректно введен номер расчетного счета!");
                }
                else correctly++;
            }

            if (correctly == 5)
            {

                if (_currentSupplier.Id_Supplier == 0)
                {
                    StoreEntities.GetContext().Suppliers.Add(_currentSupplier);
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