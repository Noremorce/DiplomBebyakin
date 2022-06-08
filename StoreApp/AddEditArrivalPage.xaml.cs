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
    /// Логика взаимодействия для AddEditArrivalPage.xaml
    /// </summary>
    public partial class AddEditArrivalPage : Page
    {
        private Arrival _currentArrival = new Arrival();
        public AddEditArrivalPage(Arrival selectedArrival)
        {
            InitializeComponent();

            if (selectedArrival != null)
                _currentArrival = selectedArrival;

            DataContext = _currentArrival;
            CBPurchase.ItemsSource = StoreEntities.GetContext().Purchases.ToList();
            CBSpecialist.ItemsSource = StoreEntities.GetContext().Specialists.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int correctly = 0;

            if (CBPurchase.SelectedItem == null) MessageBox.Show("Выберите номер заказа!");
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

            if (DPDate.Text == "") MessageBox.Show("Введите дату приема заказа!");
            else
            {
                int error = 0;
                string[] date = DPDate.Text.Split('.');

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
                    MessageBox.Show("Некорректно введена дата приема заказа!");
                }
            }

            if (CBSpecialist.SelectedItem == null) MessageBox.Show("Выберите специалиста!");
            else correctly++;

            if (correctly == 4)
            { 
                if (_currentArrival.Id_Arrival == 0)
                {
                    StoreEntities.GetContext().Arrival.Add(_currentArrival);
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