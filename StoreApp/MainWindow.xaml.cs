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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string Name = TBName.Text;
            string Password = PBPassword.Password;

            for (int i = Name.Length; i < 120; i++)//доставление пробелов
            {
                Name += " ";
            }
            for (int i = Password.Length; i < 15; i++)
            {
                Password += " ";
            }

            StoreEntities db = new StoreEntities();//экземпляр бд
            try
            {
                Specialists Specialist = db.Specialists.Where((u) => u.Name == Name && u.Password == Password).Single();
                ActiveWindow main = new ActiveWindow();
                main.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
